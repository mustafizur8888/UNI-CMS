<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelUpload.aspx.cs" MasterPageFile="~/UniSite.Master" Inherits="CMS.Pages.BulkUpload.ExcelUpload" %>


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
            <label for="fileUpload" class="col-lg-2 col-md-2 control-label text-right">Select Excel:</label>
            <div class="col-lg-4 col-md-6">
                <asp:FileUpload runat="server" CssClass="form-control" ID="fuExcel"></asp:FileUpload>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="form-group col-lg-offset-3 col-md-offset-1">

            <div class="col-lg-4 col-md-6">
                <asp:Button runat="server" CssClass="form-control btn btn-primary" ID="btnUpload" Text="Upload" OnClick="btnUpload_OnClick"></asp:Button>
            </div>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <label for="ddlYear" class="col-lg-2 col-md-2 control-label text-right">Select Year</label>
            <div class="col-lg-2 col-md-2">
                <%--<asp:TextBox runat="server" CssClass="form-control" ID="TextBox1"></asp:TextBox>--%>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlYear">
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                </asp:DropDownList>
            </div>
            <label for="ddlMonth" class="col-lg-2 col-md-2 control-label text-right">Select Month</label>
            <div class="col-lg-2 col-md-2">
                <%--<asp:TextBox runat="server" CssClass="form-control" ID="TextBox1"></asp:TextBox>--%>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMonth">
                    <asp:ListItem Value="1">Jan</asp:ListItem>
                    <asp:ListItem Value="2">Feb</asp:ListItem>
                    <asp:ListItem Value="3">Mar</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">Jun</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">Aug</asp:ListItem>
                    <asp:ListItem Value="9">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group  col-md-offset-1">
                <label for="ddlMenuName1" class="col-lg-2 col-md-2 control-label text-right">Select ServiceId</label>
                <div class="col-lg-2 col-md-2">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlServiceId" />
                </div>

            </div>

        </div>

    </div>
    <br />


    <div class="row">
        <div class="form-group col-lg-offset-3 col-md-offset-3">
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnShow" Text="Show" OnClick="btnShow_OnClick"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnSync" Visible="False" Text="Sync" OnClick="btnSync_OnClick"></asp:Button>

            <%--<button type="reset" class="btn btn-danger">Cancel</button>--%>
            <%-- <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancel_OnClick" />
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save"  OnClick="btnSave_OnClick" />
            <asp:Button runat="server" ID="btnLoad" CssClass="btn btn-primary" Text="LoadAll" OnClick="btnLoad_OnClick" />--%>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 col-lg-12 col-sm-12">
            <asp:GridView runat="server" ID="grdData" CssClass="table table-striped table-hover  table-condensed "></asp:GridView>
        </div>

    </div>


</asp:Content>
