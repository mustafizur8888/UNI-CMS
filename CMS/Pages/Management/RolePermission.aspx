<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolePermission.aspx.cs" MasterPageFile="~/UniSite.Master" Inherits="CMS.Pages.Management.RolePermission" %>
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
            <label for="ddlRoleName" class="col-lg-2 col-md-2 control-label text-right">Role Name</label>
            <div class="col-lg-4 col-md-6">
                <asp:DropDownList runat="server" ID="ddlRoleName" OnSelectedIndexChanged="ddlRoleName_OnSelectedIndexChanged" class="select-chosen" data-placeholder="Choose a Role" Style="width: 100%;"  />
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
            <asp:GridView ID="grdRole" runat="server" CssClass="table table-striped table-hover  table-condensed " AutoGenerateColumns="False" GridLines="None">
                <Columns>

                    <asp:TemplateField HeaderText="SubMenuName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblAlbumName" Text='<%# Bind("MenuName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MID" Visible="False">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMenuid" Text='<%# Bind("mid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SID" Visible="False">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSubmenuid" Text='<%# Bind("sid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MenuUel">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblIsActive" Text='<%# Bind("MenuURL") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SubMenuName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreatedBy" Text='<%# Bind("SubMenuName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SubMenuURL">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUpdatedBy" Text='<%# Bind("SubMenuURL") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="hasPermission">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" CssClass="text-center"  ID="Permission" Checked='<%# bool.Parse(Eval("RoleId").ToString() == "0" ? "false": "true") %>' />
                           
                        </ItemTemplate>
                    </asp:TemplateField>

                   <%-- <asp:TemplateField HeaderText="CreatedDate">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreatedDate" Text='<%# Bind("RoleId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                   
                  
               <%--     <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hiMasterId" Value='<%# Bind("Id") %>' />
                            <asp:HiddenField runat="server" ID="hidOwnerId" Value='<%# Bind("OwnerId") %>' />
                            <asp:HiddenField runat="server" ID="hidGenreId" Value='<%# Bind("GenreId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                </Columns>
            </asp:GridView>
        </div>
        <%--<asp:HiddenField runat="server" ID="hidIdPrimary" />
        <asp:HiddenField runat="server" ID="hidGenreIdPrimary" />
        <asp:HiddenField runat="server" ID="hidOwnerIdPrimary" />--%>
    </div>


</asp:Content>
