<%@ Page Title="CMS: Category" Language="C#" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" MasterPageFile="~/UniSite.Master" Inherits="CMS.Pages.Content.CreateCategory" %>


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
            <label for="txtCategory" class="col-lg-2 col-md-2 control-label text-right">Category Name</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCategory"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />
    <div class="row" runat="server" Visible="False">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="ddlPortalMenu" class="col-lg-2 col-md-2 control-label text-right">Select Portal</label>
            <div class="col-lg-4 col-md-6">
                <%--<asp:TextBox runat="server" CssClass="form-control" ID="TextBox1"></asp:TextBox>--%>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPortalMenu" AutoPostBack="True" />
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
            <label for="checkHasSubMenu" class="col-lg-2 col-md-2 control-label text-right">Has SubMenu? </label>
            <div class="col-lg-4 col-md-6">
                <asp:CheckBox runat="server" ID="checkHasSubMenu" AutoPostBack="True"></asp:CheckBox>
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
            <asp:GridView ID="grdMenu" runat="server" CssClass="table table-striped table-hover  table-condensed " AutoGenerateColumns="False" GridLines="None">
                <Columns>

                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCategoryName" Text='<%# Bind("CategoryName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is_Active">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblIsActive" Text='<%# Bind("Is_Active") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Has_SubMenu">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblHasSubManu" Text='<%# Bind("Has_SubMenu") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created_By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreatedBy" Text='<%# Bind("Created_By") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Updated_By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUpdatedBy" Text='<%# Bind("Updated_By") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CreatedDate">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreatedDate" Text='<%# Bind("Created_Date") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update_Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUpdateDate" Text='<%# Bind("Update_Date") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <%--<asp:HiddenField runat="server" ID="hiMasterId" Value='<%# Bind("PortalId") %>' />--%>
                            <asp:HiddenField runat="server" ID="hidId" Value='<%# Bind("Id") %>' />
                            <div class="btn-group btn-group-sm">
                                <asp:Button runat="server" CssClass="btn btn-primary btn-sm " Text="Edit" ID="btnEdit" OnClick="btnEdit_OnClick" />
                                <asp:Button runat="server" CssClass="btn btn-danger  btn-sm" Text="Delete" ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="btnDelete_OnClick" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
        <asp:HiddenField runat="server" ID="hidIdPrimary" />
        <asp:HiddenField runat="server" ID="hidMasterMenuId" />
    </div>


</asp:Content>
