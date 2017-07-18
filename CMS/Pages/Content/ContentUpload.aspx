<%@ Page Title="CMS:Contetnt-Upload" Language="C#" MasterPageFile="~/UniSite.Master" AutoEventWireup="true" CodeBehind="ContentUpload.aspx.cs" Inherits="CMS.Pages.Content.ContentUpload" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="block">
        <!-- Clickable Wizard Title -->
        <div class="block-title">
            <h2><strong>Upload</strong> Content</h2>
        </div>
        <!-- END Clickable Wizard Title -->

        <!-- Clickable Wizard Content -->
        <div id="clickable-wizard" class="form-horizontal form-bordered">
            <!-- First Step -->
            <div id="clickable-first" class="step">
          
                <div class="form-group">
                    <label class="col-md-4 control-label" for="example-clickable-username">Username</label>
                    <div class="col-md-5">
                        <input type="text" id="example-clickable-username" name="example-clickable-username" class="form-control" placeholder="Your username..">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="example-clickable-email">Email</label>
                    <div class="col-md-5">
                        <input type="text" id="example-clickable-email" name="example-clickable-email" class="form-control" placeholder="test@example.com">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="example-clickable-password">Password</label>
                    <div class="col-md-5">
                        <input type="password" id="example-clickable-password" name="example-clickable-password" class="form-control" placeholder="Choose a crazy one..">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="example-clickable-password2">Confirm Password</label>
                    <div class="col-md-5">
                        <input type="password" id="example-clickable-password2" name="example-clickable-password2" class="form-control" placeholder="..and confirm it!">
                    </div>
                </div>
            </div>
            <!-- END First Step -->

            <!-- Form Buttons -->
            <div class="form-group form-actions">
                <div class="col-md-8 col-md-offset-4">
                    <button type="reset" class="btn btn-sm btn-warning" id="back4">Previous</button>
                    <button type="submit" class="btn btn-sm btn-primary" id="next4">Next</button>
                </div>
            </div>
            <!-- END Form Buttons -->
        </div>
        <!-- END Clickable Wizard Content -->
    </div>


</asp:Content>
