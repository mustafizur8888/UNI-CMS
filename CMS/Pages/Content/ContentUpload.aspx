<%@ Page Title="CMS:Contetnt-Upload" Language="C#" MasterPageFile="~/UniSite.Master" AutoEventWireup="true" CodeBehind="ContentUpload.aspx.cs" Inherits="CMS.Pages.Content.ContentUpload" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="header-section">
            <div class="alert alert-success text-center alert-dismissable" runat="server" id="divSucc" visible="False">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <asp:Label runat="server" ID="lblSucc"></asp:Label>
            </div>
            <div class="alert alert-danger text-center alert-dismissable" runat="server" id="divError" visible="False">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </div>
        </div>
    </div>
    <div class="block">
        <!-- Clickable Wizard Title -->
        <div class="block-title">
            <h2><strong>Upload</strong> Content</h2>
        </div>
        <!-- END Clickable Wizard Title -->

        <!-- Clickable Wizard Content -->
        <div class="form-horizontal form-bordered">
            <!-- First Step -->
            <div class="step">
                <div class="form-group">
                    <label class="col-md-4 control-label" for="ddlContentCategory">Category</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlContentCategory" class="select-chosen" data-placeholder="Choose a category" Style="width: 100%;" AutoPostBack="True" OnSelectedIndexChanged="ddlContentCategory_OnSelectedIndexChanged" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="ddlContentCategory">Sub-Category</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlContentSubCategory" class="select-chosen" data-placeholder="Choose a sub-category" Style="width: 100%;" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="ddlArtist">Artist</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlArtist" class="select-chosen" data-placeholder="Choose a artist" />

                        <div class="checkbox">
                            <label class="control-label">
                                <asp:CheckBox runat="server" ID="chkIsOwner" OnCheckedChanged="chkIsOwner_OnCheckedChanged" AutoPostBack="True" />Is Owner</label>

                        </div>
                    </div>

                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="ddlOwner">Owner</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlOwner" class="select-chosen" data-placeholder="Choose a owner" Style="width: 100%;" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-4 control-label" for="ddlAlbum">Album</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlAlbum" class="select-chosen" data-placeholder="Choose a album" Style="width: 100%;" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtTitle">Title</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Title"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtInfo">Info</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtInfo" CssClass="form-control" placeholder="Info"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtDuration">Duration</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtDuration" CssClass="form-control" placeholder="Duration"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4  control-label" for="fuThumbnail">Thumbnail</label>
                    <div class="col-md-5">
                        <asp:FileUpload runat="server" ID="fuThumbnail" AllowMultiple="False" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4  control-label" for="fuUploadFile">Content</label>
                    <div class="col-md-5">
                        <asp:FileUpload runat="server" ID="fuUploadFile" AllowMultiple="False" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4  control-label" for="fuPreviewImg">Preview Image</label>
                    <div class="col-md-5">
                        <asp:FileUpload runat="server" ID="fuPreviewImg" AllowMultiple="False" />
                    </div>
                </div>


                <%--  <div class="form-group dropzone">
                    <label class="col-md-4  control-label" for="fuUploadFile">Upload File</label>
                    <div class="col-md-5 fallback dz-default dz-message">
                        <asp:FileUpload runat="server" ID="fuUploadFile" AllowMultiple="False" />
                    </div>
                </div>--%>
            </div>


            <!-- END First Step -->

            <!-- Form Buttons -->
            <div class="form-group form-actions">
                <div class="col-md-8 col-md-offset-4">
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnSave" Text="Save" OnClick="btnSave_OnClick" />
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnCanel" Text="Cancel" OnClick="btnCanel_OnClick" />
                </div>
            </div>
            <asp:GridView ID="grdContent" CssClass="table table-striped table-vcenter table-hover table-responsive" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Thumbnail">
                        <ItemStyle Width="150px"></ItemStyle>
                        <ItemTemplate>
                            <asp:Image runat="server" Width="150px" ID="imgThumb" ImageUrl='<%# Bind("ThumbnailUrl") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTitle" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hidId" Value='<%# Bind("id") %>' />
                            <asp:Label runat="server" ID="lblContentCategoryName" Text='<%# Bind("ContentCategoryName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sub-Category">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblConSubCatName" Text='<%# Bind("ConSubCatName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Artist Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblArtistName" Text='<%# Bind("ArtistName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Portal Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPortalName" Text='<%# Bind("PortalName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Owner Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblOwnerName" Text='<%# Bind("OwnerName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Album Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblAlbumName" Text='<%# Bind("AlbumName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Publish">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPublish" Text='<%# Bind("Publish") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <div class="btn-group btn-group-xs">
                                <asp:LinkButton runat="server" CssClass="btn btn-danger btn-xs" ID="grdDelete" OnClick="grdDelete_OnClick">
                                <i class="fa fa-times"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="btn btn-default btn-xs" ID="grdEdit" OnClick="grdEdit_OnClick">
                                <i class="fa fa-pencil"></i>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>



        </div>
    </div>

    <script>
        $(document).ready(function () {
            Dropzone.autoDiscover = false;
            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                url: '<%= ResolveUrl("~/Pages/Content/ContentUpload.aspx") %>' + '/SaveUploadedFile',
                addRemoveLinks: true,
                clickable: true,
                maxFilesize: 1,
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    // console.log(this.files);
                },
                error: function (file, response) {
                    console.log(file);
                    file.previewElement.classList.add("dz-error");
                    this.files.remove(file);
                },
            });
        });

       <%-- $(document).ready(function () {
            Dropzone.autoDiscover = false;
          <%--  var myDropzone = new Dropzone("#dZUpload", {
                url: '<%= ResolveUrl("~/Pages/Content/ContentUpload.aspx") %>',
                addRemoveLinks: true,
                autoProcessQueue: false
            });--%>

          <%--  var myDropzone = new Dropzone("#dZUpload", {
                url: '<%= ResolveUrl("~/Pages/Content/ContentUpload.aspx") %>',
                addRemoveLinks: true,
                autoProcessQueue: false
            });
            myDropzone.init = function () {

            }--%>

           <%-- $('#' +'<%= btnSave.ClientID %>').on('click', function (e) {
                e.preventDefault();
                e.stopPropagation();
                myDropzone.processQueue();

            });--%>
       // }); --%>

    </script>

</asp:Content>
