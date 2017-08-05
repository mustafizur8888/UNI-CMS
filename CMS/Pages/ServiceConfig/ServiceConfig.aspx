<%@ Page Title="" Language="C#" MasterPageFile="~/UniSite.Master" AutoEventWireup="true" CodeBehind="ServiceConfig.aspx.cs" Inherits="CMS.Pages.ServiceConfig.ServiceConfig" %>

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
            <h2><strong>Service</strong> Configuration</h2>
        </div>
        <!-- END Clickable Wizard Title -->

        <!-- Clickable Wizard Content -->
        <div class="form-horizontal form-bordered">
            <!-- First Step -->
            <div class="step">
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtServiceName">Service Name</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtServiceName" CssClass="form-control" placeholder="Service Name"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtServiceIdTelco">Service Id Telco</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtServiceIdTelco" CssClass="form-control" placeholder="Service Id Telco"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtServiceIdTelco">Key word</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtKeWord" CssClass="form-control" placeholder="Key word"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtTypeOfService">Type Of Service</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtTypeOfService" CssClass="form-control" placeholder="Type Of Service"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="ddlChargingType">Charging Type</label>
                    <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlChargingType" class="select-chosen" data-placeholder="Choose a charging type" Style="width: 100%;" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtDailySms">Daily SMS</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtDailySms" CssClass="form-control" placeholder="number of Daily Sms"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="txtSMSScripts">SMS Scripts</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="txtSMSScripts" CssClass="form-control" placeholder="SMS Scripts" TextMode="MultiLine"></asp:TextBox>
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
                    <asp:Button runat="server" CssClass="btn btn-sm btn-warning" ID="btnLoad" Text="Load" OnClick="btnLoad_OnClick" />
                </div>
            </div>

            <asp:GridView ID="grdServiceConfig" CssClass="table table-striped table-vcenter table-hover table-responsive" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Service Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblServiceName" Text='<%# Bind("ServiceName") %>'></asp:Label>
                            <asp:HiddenField runat="server" ID="hidId" Value='<%# Bind("Id") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ServiceId Telco">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblServiceIdTelco" Text='<%# Bind("ServiceIdTelco") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KeyWord">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblKeyWord" Text='<%# Bind("KeyWord") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type Of Service">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTypeOfService" Text='<%# Bind("TypeOfService") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Daily SMS">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDailySMS" Text='<%# Bind("DailySMS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SMS Scripts">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSMSScripts" Text='<%# Bind("SMSScripts") %>'></asp:Label>
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
                                <asp:LinkButton runat="server" CssClass="btn btn-danger btn-xs" ID="grdDelete" OnClientClick="return confirm('Are you sure you want to delete this record?');"  OnClick="grdDelete_OnClick">
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

        <asp:HiddenField runat="server" ID="hidId" />
    </div>
</asp:Content>


