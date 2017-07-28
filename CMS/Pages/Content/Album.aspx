<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" MasterPageFile="~/UniSite.Master" Inherits="CMS.Pages.Content.Album" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">


        <div class="alert  alert-danger text-center" runat="server" id="divError">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <asp:Label runat="server" ID="lblError"></asp:Label>
        </div>
        <div class="alert  alert-success text-center" runat="server" id="divSucc">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
        </div>

    </div>
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="txtAlbumName" class="col-lg-2 col-md-2 control-label text-right">Album Name</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtAlbumName"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="ddlOwnerName" class="col-lg-2 col-md-2 control-label text-right">Owner Name</label>
            <div class="col-lg-4 col-md-6">
                <%--<asp:TextBox runat="server" CssClass="form-control" ID="TextBox1"></asp:TextBox>--%>
                <%--<asp:DropDownList runat="server" CssClass="form-control" ID="ddlPortalMenu" AutoPostBack="True"  OnSelectedIndexChanged="ddlMasterMenu_OnSelectedIndexChanged" />--%>
                <asp:DropDownList runat="server" ID="ddlOwnerName" class="select-chosen" data-placeholder="Choose a owner" Style="width: 100%;"  />
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="ddlGenre" class="col-lg-2 col-md-2 control-label text-right">Album Type</label>
            <div class="col-lg-4 col-md-6">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlGenre" data-placeholder="Choose a Genre" AutoPostBack="True" />
            </div>

        </div>

    </div>
    <br />
   
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="checkIsActive" class="col-lg-2 col-md-2 control-label text-right">Is Active? </label>
            <div class="col-lg-4 col-md-6">
                <asp:CheckBox runat="server" ID="checkIsActive"></asp:CheckBox>
            </div>

        </div>

    </div>
    <br />
    
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="checkIsActive" class="col-lg-2 col-md-2 control-label text-right">Image Preview </label>
            <div class="col-lg-4 col-md-6">
               <asp:FileUpload runat="server" ID="fuImg"/>
            </div>

        </div>

    </div>
    <br />
   

    <div class="row">
        <div class="form-group col-lg-offset-3 col-md-offset-3">

            <%--<button type="reset" class="btn btn-danger">Cancel</button>--%>
            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancel_OnClick" />
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_OnClick" />
            <asp:Button runat="server" ID="btnLoad" CssClass="btn btn-primary" Text="LoadAll" OnClick="btnLoad_OnClick" />
           

        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 col-lg-12 col-sm-12">
            <asp:GridView ID="grdAlbumInfo" runat="server" CssClass="table table-striped table-hover  table-condensed " AutoGenerateColumns="False" GridLines="None">
                <Columns>

                    <asp:TemplateField HeaderText="SubMenuName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblAlbumName" Text='<%# Bind("AlbumName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is_Active">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblIsActive" Text='<%# Bind("Is_Active") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created_By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreatedBy" Text='<%# Bind("CreatedBy") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Updated_By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUpdatedBy" Text='<%# Bind("Update_By") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CreatedDate">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreatedDate" Text='<%# Bind("CreatedDate") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update_Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUpdateDate" Text='<%# Bind("Update_Date") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                  
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hiMasterId" Value='<%# Bind("Id") %>' />
                            <asp:HiddenField runat="server" ID="hidOwnerId" Value='<%# Bind("OwnerId") %>' />
                            <asp:HiddenField runat="server" ID="hidGenreId" Value='<%# Bind("GenreId") %>' />
                            <div class="btn-group btn-group-sm">
                                <asp:Button runat="server" CssClass="btn btn-primary btn-sm " Text="Edit" ID="btnEdit" OnClick="btnEdit_OnClick" />
                                <asp:Button runat="server" CssClass="btn btn-danger  btn-sm" Text="Delete" ID="btnDelete" OnClick="btnDelete_OnClick" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
        <asp:HiddenField runat="server" ID="hidIdPrimary" />
        <asp:HiddenField runat="server" ID="hidGenreIdPrimary" />
        <asp:HiddenField runat="server" ID="hidOwnerIdPrimary" />
    </div>


</asp:Content>

