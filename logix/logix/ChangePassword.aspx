<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="logix.ChangePassword" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
   <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>logix</title>
        <script type="text/javascript" src="Scripts/Calendar.js"></script> 
    <script type="text/javascript" src="Scripts/Validation.js"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Style/jquery-ui.css" rel="Stylesheet" type="text/css" />
     <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.form-components.js"></script>
    <script>
        $(document).ready(function () {



            $('.selectpicker').selectpicker();

            "use strict";

            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins

            //$('select.styled').customSelect();

        });




    </script>

   

    <!-- Demo JS -->
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
    <script type="text/javascript" src="Scripts/Calendar.js"></script> 
    <style type="text/css">
        .style1
        {
            width: 184px;
        }

       .Error {
    text-align: center;
    color: red;
    font-size: 13px;
    font-weight: bold;
    width: 60%;
   
    display: block;
    margin-top: -4px;
    margin-bottom: 5px;
}
    </style>
</head>
<body style="margin-left:10px;margin-top:10px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdateProgress id="UpdateProgress1" runat="server">
        <progresstemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
</progresstemplate>
    </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
 
            <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i>Home </li>
           
              <li>Change Password</li>
              <li class="current">Change Password</li>
            </ul>
      </div>

<div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box">
     
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="Label5" runat="server"  Text="Change Password"></asp:Label></h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4"><asp:Label ID="LBLStatus" runat="server" CssClass="Error"></asp:Label></div>
              <div class="FormGroupContent4">
                  <div class="UsernameTxt"><asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label></div>
                  <div class="UserNameTxtbox"><asp:TextBox ID="txtUserName" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="CurrentPassword"><asp:Label ID="Label2" runat="server" Text="Current PassWord"></asp:Label></div>
                  <div class="CurrentTxtBox"><asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" CssClass="form-control1"></asp:TextBox>
                            </div>
                  <div class="RequiredField"><span style="color: #ff0033">*</span></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="NewPassword"><asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label></div>
                  <div class="NewpassTxtBox"> <asp:TextBox ID="txtNewpwd" runat="server" MaxLength="10" TextMode="Password" CssClass="form-control1"></asp:TextBox>
                            </div>
                  <div class="RequiredField"><span style="color: #ff0033">*</span></div>
                  </div>
               <div class="FormGroupContent4">
                   <div class="ConfirmPass"><asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label></div>
                   <div class="ConfirmPassTxt"><asp:TextBox ID="txtConfpwd" runat="server" MaxLength="10" TextMode="Password" CssClass="form-control1"></asp:TextBox>
                            </div>
                   <div class="RequiredField"><span style="color: #ff0033">*</span></div>
                   </div>
              <div class="FormGroupContent4">

                  <div class="LeftBtn1">
                      <div class="right_btn MT0"><div class="btn btn-change"><asp:Button ID="BtnChange" runat="server" OnClick="BtnChange_Click" Text="Change"  /></div>
                       <div class="btn ico-cancel"><asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" /></div></div>
 

                  </div>


                  

                  </div>
              </div>
         </div>
            </div>
    </div>








   </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>