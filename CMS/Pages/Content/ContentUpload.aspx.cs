using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DAL;

namespace CMS.Pages.Content
{
    public partial class ContentUpload : System.Web.UI.Page
    {

        private static List<HttpPostedFile> Files = new List<HttpPostedFile>();
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {

                Initialization();
            }
        }

        private void SaveUploadedFile(HttpFileCollection requestFiles)
        {
            HttpPostedFile firstOrDefault = Files.FirstOrDefault(x => x.FileName == requestFiles[0].FileName);

            if (Files.Contains(firstOrDefault))
            {

            }
            else
            {
                for (int i = 0; i < requestFiles.Count; i++)
                {
                    Files.Add(requestFiles[i]);
                }
            }

        }



        private void Initialization()
        {
            //GetPortalList();
            GetContentCategoryList();
            ddlContentCategory_OnSelectedIndexChanged(null, null);
            GetOwnerList();
            GetArtistList();
            GetAlbumList();
            ddlOwner.Enabled = true;
            ShowGrd();
            txtDuration.Text = string.Empty;
            txtInfo.Text = string.Empty;
            txtTitle.Text = string.Empty;
            chkIsOwner.Checked = false;
            ddlContentCategory.Enabled = true;
            ddlContentSubCategory.Enabled = true;
        }

        //private void GetPortalList()
        //{

        //    DataSet ds = _db.GetDataSet("GetPortalList");
        //    ddlPortal.DataSource = ds;
        //    ddlPortal.DataValueField = "Id";
        //    ddlPortal.DataTextField = "PortalName";
        //    ddlPortal.DataBind();
        //}

        private void GetContentCategoryList()
        {

            DataSet ds = _db.GetDataSet("SpGetContentCategory");
            ddlContentCategory.DataSource = ds;
            ddlContentCategory.DataValueField = "ContentCategoryId";
            ddlContentCategory.DataTextField = "ContentCategoryName";
            ddlContentCategory.DataBind();
        }
        private void GetContentSubCategoryList()
        {

            DataSet ds = _db.GetDataSet("SpGetContentCategoryList", new List<SqlParameter>() { new SqlParameter { Value = ddlContentCategory.SelectedValue, ParameterName = "@catId" } });
            ddlContentSubCategory.DataSource = ds;
            ddlContentSubCategory.DataValueField = "ContentSubCatId";
            ddlContentSubCategory.DataTextField = "ConSubCatName";
            ddlContentSubCategory.DataBind();
        }

        protected void ddlContentCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetContentSubCategoryList();
        }

        private void GetOwnerList()
        {
            DataSet ds = _db.GetDataSet("SpGetOwnerList");
            ddlOwner.DataSource = ds;
            ddlOwner.DataValueField = "OwnerId";
            ddlOwner.DataTextField = "OwnerName";
            ddlOwner.DataBind();
        }

        private void GetArtistList()
        {
            DataSet ds = _db.GetDataSet("SpGetArtistList");
            ddlArtist.DataSource = ds;
            ddlArtist.DataValueField = "ArtistId";
            ddlArtist.DataTextField = "ArtistName";
            ddlArtist.DataBind();
        }
        private void GetAlbumList()
        {
            DataSet ds = _db.GetDataSet("spGetAlbumList");
            ddlAlbum.DataSource = ds;
            ddlAlbum.DataValueField = "AlbumId";
            ddlAlbum.DataTextField = "AlbumName";
            ddlAlbum.DataBind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {

                string thumbNailUrl = null;
                string uploded = null;
                string previewUrl = null;
                if (fuThumbnail.HasFile)
                {
                    thumbNailUrl = "~/UplodedFile/Thumbnail/" + ddlContentCategory.SelectedItem.Text.Trim() + "/" +
                                   ddlContentSubCategory.SelectedItem.Text.Trim();
                    CreateDirectory(thumbNailUrl);
                    thumbNailUrl = thumbNailUrl + "/" + DateTime.Now.ToString("yyyyMdHHMMSS") + new FileInfo(fuThumbnail.FileName).Extension;
                    fuThumbnail.SaveAs(Server.MapPath(thumbNailUrl));
                }
                else
                {
                    thumbNailUrl = "~/UplodedFile/Thumbnail/" + "avatar2.jpg";
                }

                if (fuUploadFile.HasFile)
                {
                    uploded = "~/UplodedFile/Content/" +
                                    ddlContentCategory.SelectedItem.Text.Trim() + "/" + ddlContentSubCategory.SelectedItem.Text.Trim();

                    CreateDirectory(uploded);
                    string uplodExt = new FileInfo(fuUploadFile.FileName).Extension;
                    uploded = "~/UplodedFile/Content/" + ddlContentCategory.SelectedItem.Text.Trim() + "/" +
                              ddlContentSubCategory.SelectedItem.Text.Trim() + "/" + txtTitle.Text.Trim() + "_" +
                              DateTime.Now.ToString("yyyyMdHHMMSS") + uplodExt;
                    fuUploadFile.SaveAs(Server.MapPath(uploded));
                }

                if (fuPreviewImg.HasFile)
                {
                    previewUrl = "~/UplodedFile/PreviewImage/" + ddlContentCategory.SelectedItem.Text.Trim() + "/" +
                                       ddlContentSubCategory.SelectedItem.Text.Trim();
                    CreateDirectory(previewUrl);
                    previewUrl = previewUrl + "/" + DateTime.Now.ToString("yyyyMdHHMMSS") + new FileInfo(fuPreviewImg.FileName).Extension;
                    fuPreviewImg.SaveAs(Server.MapPath(previewUrl));
                }

                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        Value = 0,
                        ParameterName = "@Id"
                    },
                    new SqlParameter
                    {
                        Value = ddlContentCategory.SelectedValue,
                        ParameterName = "@ContentCategoryId"
                    },
                    new SqlParameter
                    {
                        Value = ddlContentSubCategory.SelectedValue,
                        ParameterName = "@ConSubCatId"
                    },
                    new SqlParameter
                    {
                        Value = ddlArtist.Items.Count > 0 ? ddlArtist.SelectedValue : "",
                        ParameterName = "@ArtistId"
                    },
                    new SqlParameter
                    {
                        Value = "1",
                        ParameterName = "@Portalid"
                    },
                    new SqlParameter
                    {
                        Value = ddlAlbum.Items.Count > 0 ? ddlAlbum.SelectedValue : "",
                        ParameterName = "@AlbumId"
                    },
                    new SqlParameter
                    {
                        Value = ddlOwner.Items.Count > 0 ? ddlOwner.SelectedValue : "",
                        ParameterName = "@OwnerId"
                    },
                    new SqlParameter
                    {
                        Value = txtTitle.Text,
                        ParameterName = "@Title"
                    },
                    new SqlParameter
                    {
                        Value = txtDuration.Text,
                        ParameterName = "@Duration"
                    },
                    new SqlParameter
                    {
                        Value = thumbNailUrl,
                        ParameterName = "@ThumbnailUrl"
                    },
                    new SqlParameter
                    {
                        Value = uploded,
                        ParameterName = "@FIleUrl"
                    },
                    new SqlParameter
                    {
                        Value = "",
                        ParameterName = "@Created_By"
                    },
                    new SqlParameter
                    {
                        Value = "",
                        ParameterName = "@Updated_By"
                    }, new SqlParameter
                    {
                        Value = chkIsOwner.Checked,
                        ParameterName = "@ISOwner"
                    },
                    new SqlParameter
                    {
                        Value =txtInfo.Text,
                        ParameterName = "@Info"
                    },   new SqlParameter
                    {
                        Value =previewUrl,
                        ParameterName = "@PreviewUrl"
                    }
                };
                if (_db.ExecuteNonQuery("SpSavetblUplodedContent", sqlParameters) > 0)
                {
                    ShowSucc("Saved Succefully");
                    Initialization();
                }
                else
                {
                    ShowError("Failed to save");
                }


            }
        }

        private void CreateDirectory(string uploded)
        {
            if (!Directory.Exists(Server.MapPath(uploded)))
            {
                Directory.CreateDirectory(Server.MapPath(uploded));
            }
        }

        private void ShowGrd()
        {
            DataSet ds = _db.GetDataSet("spGetUplodedContent");
            grdContent.DataSource = ds;
            grdContent.DataBind();
        }

        protected void btnCanel_OnClick(object sender, EventArgs e)
        {
            Initialization();
        }

        protected void chkIsOwner_OnCheckedChanged(object sender, EventArgs e)
        {
            ddlOwner.Enabled = !chkIsOwner.Checked;
        }

        private bool Validation()
        {
            bool result = true;
            string msg = string.Empty;
            //if (ddlPortal.Items.Count == 0)
            //{
            //    msg += "Select a portal" + "<br>";
            //}
            if (ddlContentCategory.Items.Count == 0)
            {
                msg += "Select a category" + "<br>";
            }
            if (ddlContentSubCategory.Items.Count == 0)
            {
                msg += "Select a sub-category" + "<br>";
            }

            if (String.IsNullOrWhiteSpace(txtTitle.Text))
            {
                msg += "Titile is empty" + "<br>";
            }
            if (String.IsNullOrWhiteSpace(txtTitle.Text))
            {
                msg += "Info is empty" + "<br>";
            }
            if (String.IsNullOrWhiteSpace(txtTitle.Text))
            {
                msg += "Info is empty" + "<br>";
            }
            if (fuThumbnail.HasFile)
            {
                if (!ValidThumbNail(new FileInfo(fuThumbnail.FileName).Extension))
                {
                    msg += "Thumbnail extenshion should be jpg,jpeg,png,gif" + "<br>";
                }
            }
            if (!fuUploadFile.HasFile)
            {

                msg += "No file uploded" + "<br>";
            }
            if (!fuPreviewImg.HasFile)
            {

                msg += "No preview uploded" + "<br>";
            }
            if (fuPreviewImg.HasFile)
            {
                if (!ValidThumbNail(new FileInfo(fuPreviewImg.FileName).Extension))
                {
                    msg += "Preview image extenshion should be jpg,jpeg,png,gif" + "<br>";
                }
            }

            if (string.IsNullOrEmpty(msg)) return result;
            result = false;
            ShowError(msg);


            return result;
        }

        private void ShowError(string msg)
        {
            divError.Visible = true;
            lblError.Text = msg;
        }
        private void ShowSucc(string msg)
        {
            divSucc.Visible = true;
            lblSucc.Text = msg;
        }

        private bool ValidThumbNail(string ext)
        {
            var extenstions = new string[] { ".JPG", ".PNG", ".GIF", ".JPEG" };
            return extenstions.Contains(ext.ToUpper());
        }


        protected void grdDelete_OnClick(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string id = ((HiddenField)gvr.FindControl("hidId")).Value;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = id,ParameterName = "@Id"}
            };
            int executeNonQuery = _db.ExecuteNonQuery("spDeleteUplodedContent", sqlParameters);

            if (executeNonQuery > 0)
            {
                ShowSucc("Delete Succefully");
                ShowGrd();
            }
            else
            {
                ShowSucc("Failed.Content already published");

            }
        }

        protected void grdEdit_OnClick(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string id = ((HiddenField)gvr.FindControl("hidId")).Value;
            DataSet ds = _db.GetDataSet("spGetContent", new List<SqlParameter>{new SqlParameter
                {Value = id,ParameterName = "@Id"}});

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                ddlContentCategory.SelectedValue = row["ContentCategoryId"].ToString();
                ddlContentSubCategory.SelectedValue = string.IsNullOrWhiteSpace(row["ConSubCatId"].ToString()) ? "0" : row["ConSubCatId"].ToString();
                ddlAlbum.SelectedValue = string.IsNullOrWhiteSpace(row["AlbumId"].ToString()) ? "0" : row["AlbumId"].ToString();
                ddlArtist.SelectedValue = string.IsNullOrWhiteSpace(row["ArtistId"].ToString()) ? "0" : row["ArtistId"].ToString();
                ddlContentCategory.Enabled = false;
                ddlContentSubCategory.Enabled = false;
                txtTitle.Text = row["Title"].ToString();
                txtDuration.Text = row["Duration"].ToString();
                txtInfo.Text = row["Info"].ToString();
                chkIsOwner.Checked = (bool)row["IsOwner"];

            }



        }
    }
}