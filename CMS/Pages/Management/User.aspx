<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="User.aspx.cs" MasterPageFile="~/UniSite.Master" Inherits="AMAR.Web.Pages.CMS.User" %>


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
            <label for="txtFullName" class="col-lg-2 col-md-2 control-label text-right">Full Name</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFullName"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />

    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="txtUserName" class="col-lg-2 col-md-2 control-label text-right">User Name</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUserName"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="txtPassword" class="col-lg-2 col-md-2 control-label text-right">Password</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtPassword"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="ddlMasterMenu" class="col-lg-2 col-md-2 control-label text-right">Role</label>
            <div class="col-lg-4 col-md-6">
                <%--<asp:TextBox runat="server" CssClass="form-control" ID="TextBox1"></asp:TextBox>--%>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRole" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_OnSelectedIndexChanged" />
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="txtEmail" class="col-lg-2 col-md-2 control-label text-right">Email</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="txtPhoneNumber" class="col-lg-2 col-md-2 control-label text-right">Phone Number</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPhoneNumber"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="txtDesignation" class="col-lg-2 col-md-2 control-label text-right">Designation </label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDesignation"></asp:TextBox>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-1 col-md-offset-1">
            <label for="txtCompany" class="col-lg-2 col-md-2 control-label text-right">Company</label>
            <div class="col-lg-4 col-md-6">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCompany"></asp:TextBox>
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
            <asp:GridView ID="grdUser" runat="server" CssClass="table table-striped table-hover  table-condensed " AutoGenerateColumns="False" GridLines="None">
                <Columns>

                    <asp:TemplateField HeaderText="UserName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblUserName" Text='<%# Bind("UserName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblName" Text='<%# Bind("Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Password" Visible="False">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPassword" Text='<%# Bind("Password") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Roleid">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblRoleId" Text='<%# Bind("roleid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CreatedDate">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreatedDate" Text='<%# Bind("CreatedDate") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                   
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEmail" Text='<%# Bind("Email") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPhone" Text='<%# Bind("Phone") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDesignation" Text='<%# Bind("Designation") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCompany" Text='<%# Bind("Company") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IsActive">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblIsActive" Text='<%# Bind("IsActive") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            
                            <asp:HiddenField runat="server" ID="hidId" Value='<%# Bind("Id") %>' />
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
       
    </div>


</asp:Content>
