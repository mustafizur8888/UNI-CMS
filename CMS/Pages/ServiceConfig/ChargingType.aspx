<%@ Page Title="" Language="C#" MasterPageFile="~/UniSite.Master" AutoEventWireup="true" CodeBehind="ChargingType.aspx.cs" Inherits="CMS.Pages.ServiceConfig.ChargingType" %>

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
            <div class="step">
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtCType">Charging Type</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtCType" CssClass="form-control" placeholder="Charging Type"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtDayDuration">Day Duration</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtDayDuration" CssClass="form-control" placeholder="Day Duration"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="chkActive">Active</label>
                    <div class="col-md-5">
                        <div class="checkbox">
                            <asp:CheckBox runat="server" ID="chkActive" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group form-actions">
                <div class="col-md-8 col-md-offset-4">
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnSave" Text="Save" OnClick="btnSave_OnClick" />
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnCanel" Text="Cancel" OnClick="btnCanel_OnClick" />
                </div>
            </div>

            <asp:GridView ID="grdServiceType" CssClass="table table-striped table-vcenter table-hover table-responsive" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblType" Text='<%# Bind("Type") %>'></asp:Label>
                            <asp:HiddenField runat="server" ID="hidId" Value='<%# Bind("Id") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Day Duration">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDayDuration" Text='<%# Bind("DayDuration") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Active">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblIsActive" Text='<%# Bind("IsActive") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <div class="btn-group btn-group-xs">
                                <asp:LinkButton runat="server" CssClass="btn btn-danger btn-xs" ID="grdDelete" OnClick="grdDelete_OnClick">
                                    <i class="fa fa-times"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="btn btn-default btn-xs" ID="grdEdit" OnClick="grdEdit_OnClick" 
                                                >
                                    <i class="fa fa-pencil"></i>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HiddenField runat="server" ID="hidId"/>
        </div>
    </div>
   

</asp:Content>
