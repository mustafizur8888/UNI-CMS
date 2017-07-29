<%@ Page Title="CMS:Content Publish" Language="C#" MasterPageFile="~/UniSite.Master" AutoEventWireup="true" CodeBehind="ContentPublish.aspx.cs" Inherits="CMS.Pages.Content.ContentPublish" %>

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
            <h2><strong>Publish</strong> Content</h2>
        </div>
        <div class="form-horizontal form-bordered">
            <div class="step">
                <div class="form-group">
                    <label class="col-md-4 control-label" for="ddlPortal">Portal</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlPortal" class="select-chosen" data-placeholder="Choose a category" Style="width: 100%;" AutoPostBack="True" />
                    </div>
                </div>


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
                    <label class="col-md-4 control-label" for="ddlFilter">Action</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlFilter" class="select-chosen" Style="width: 100%;">
                            <asp:ListItem Text="Publish" Value="P">
                                </asp:ListItem>
                            <asp:ListItem Text="UnPublish" Value="UP">
                                </asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="form-group form-actions">
                <div class="col-md-8 col-md-offset-4">
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnLoad" Text="Load ALL" OnClick="btnLoad_OnClick" />
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnSave" Text="Save" OnClick="btnSave_OnClick" />
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnCanel" Text="Cancel" OnClick="btnCanel_OnClick" />
                </div>
            </div>
            <asp:GridView ID="grdUnpublish" CssClass="table table-striped table-vcenter table-hover table-responsive" runat="server" AutoGenerateColumns="False">
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
                    <asp:TemplateField HeaderText="Info">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblInfo" Text='<%# Bind("Info") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Duration">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDuration" Text='<%# Bind("Duration") %>'></asp:Label>
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
                            <asp:CheckBox runat="server" ID="checkP" Checked='<%# bool.Parse(Eval("Publish").ToString()=="No"?"false":"true") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Creation Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDate" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            
            <asp:GridView ID="grdPublish" CssClass="table table-striped table-vcenter table-hover table-responsive" runat="server" AutoGenerateColumns="False">
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
                    <asp:TemplateField HeaderText="Info">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblInfo" Text='<%# Bind("Info") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Duration">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDuration" Text='<%# Bind("Duration") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Publish Date">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="checkP" Checked='<%# bool.Parse(Eval("Publish").ToString()=="No"?"false":"true") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Creation Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDate" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
