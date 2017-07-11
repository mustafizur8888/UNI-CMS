<%@ Page Title="UniFon CMS:Home" Language="C#" MasterPageFile="~/UniSite.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CMS.Pages.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Dashboard 2 Header -->
    <div class="content-header">
        <div class="header-section">
            <h1>aaaa</h1>
        </div>
    </div>
    <!-- END Dashboard 2 Header -->

    <!-- Dashboard 2 Content -->
    <div class="row">
        <div class="col-md-12">
            <!-- Web Server Block -->
            <div class="block full">
                <!-- Web Server Title -->
                <div class="block-title">
                    <div class="block-options pull-right">
                        <span id="dash-chart-live-info" class="label label-primary">%</span>
                        <span class="label label-danger animation-pulse">CPU Load</span>
                    </div>
                    <h2><strong>Web</strong> Server #1</h2>
                </div>
                <!-- END Web Server Title -->

                <!-- Web Server Content -->
                <!-- Flot Charts (initialized in js/pages/index2.js), for more examples you can check out http://www.flotcharts.org/ -->
                <div id="dash-chart-live" class="chart"></div>
                <!-- END Web Server Content -->
            </div>
        </div>

    </div>
    <!-- END Dashboard 2 Content -->
</asp:Content>
