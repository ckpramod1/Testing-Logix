<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage4CustPortal.aspx.cs" Inherits="logix.MainPage4CustPortal" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script language="javascript" type="text/javascript" src="niceforms.js"></script>
    <link rel="stylesheet" type="text/css" media="all" href="niceforms-default.css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>

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
    <link href="Theme/assets/css/buttonicon.css" rel="stylesheet" />
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


    <style type="text/css">
        .Caddress {
            color: #fff;
            float: left;
            font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
            font-size: 18px;
            font-weight: normal;
            height: 34px;
            line-height: 18px;
            margin: 0 10px 0 0;
            padding: 2px 0 8px 8px;
            width: auto;
        }

        .navbar .navbar-brand {
            margin-top: -2px;
        }

        .ContainerPopupdiv {
            background-color: #fff;
            padding: 10px;
        }



        .SearchTxtbox1 {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SearchTxtbox2 {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SearchTxtbox3 {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .header {
    z-index: 10030;
    width: 1366px;
    margin: 0px auto;
}
    </style>









    <script type="text/javascript">
        history.forward(0);
        document.oncontextmenu = function () { return false };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="main_container">


                    <header class="header navbar navbar-fixed-top" role="banner"> 
      <!-- Top Navigation Bar -->

                       <div class="container"> 
                            <div class="LoginCompanyName">

         <a class="navbar-brand" href="#"><asp:Image ID="img_Logo" runat="server" Width="75" Height="48" ImageUrl="~/images/MR.png" /> </a>
             
         
             <div id="div_address" runat="server" class="Caddress">
                       <asp:Label ID="lblcompany" runat="server" style ="text-transform: capitalize;"></asp:Label>
                    </div>
                                <div class="Clear"></div>
                                <div class="CustomerAddress">Customer Name:</div>
                                  <div class="menu NAME" id="div_name" runat="server"></div>
                                <div class="UserTxt1">User ID:</div>
<span id="div_user" runat="server" class="CNAME"></span>

    </div>
                           <div class="FloatRightbtn1">
                           <div class="HomeIc">
                             
                               <asp:LinkButton ID="lnkhome" runat="server" OnClick="lnkhome_Click" style ="text-transform: capitalize;color:#ffffff;text-decoration:none;" ToolTip="Home"><img src="Theme/assets/img/home_ic.png" /></asp:LinkButton>
                           </div>
                               <div class="ChangepassIc">  <asp:LinkButton ID="lnkchange" runat="server"  style ="text-transform: capitalize;color:#ffffff;text-decoration:none;" ToolTip="Change Password" 
                                   OnClick="lnkchange_Click"><img src="Theme/assets/img/changepassword_ic.png" /></asp:LinkButton></div>
                           <div class="LogoutBtn">


                           
                                <asp:LinkButton role="menuitem"  ID="LinkButton2"  CssClass="SignOut"  OnClick ="LinkButton2_Click" runat="server"></asp:LinkButton>
                           </div>
                           </div>

                           </div>
                      </header>















                    <div class="main_content">
                        <div class="mainPageBg">
                            <div class="menu" id="div_menu" runat="server">
                                
                            </div>
                            <div class="clear">
                            </div>

                            <div class="clear"></div>

                            <iframe name="frmContent" id="frmContent" runat="server" src="Default.aspx" class="main_frame"></iframe>
                        </div>
                    </div>
                  
                </div>
                

                 <panel id="divchangepassword" runat="server" class="ContainerPopupdiv">
            <div class="DivSecPanel">
                <asp:Image ID="imgfgok1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="150%" />
            </div>
            <div class="FormGroupContent4">
                <div class="SearchTxtbox1">
                    <asp:TextBox ID="txtcustomername" runat="server" placeholder="Customer Name" AutoPostBack="true" ToolTip="Customername" CssClass="form-control" TabIndex="1" Enabled="false">
                    </asp:TextBox>
                </div>
            </div>
            <div class="FormGroupContent4">
                <div class="SearchTxtbox2">
                    <asp:TextBox ID="txtoldpassword" runat="server"  placeholder="Old Password" ToolTip="OldPassword" CssClass="form-control" AutoPostBack="true"
                        OnTextChanged="txtoldpassword_TextChanged" TabIndex="2">

                    </asp:TextBox>
                </div>
            </div>
            <div class="FormGroupContent4">
                <div class="SearchTxtbox3">
                    <asp:TextBox ID="txtnewpassword" runat="server" placeholder="New Password" ToolTip="NewPassword" TabIndex="3" CssClass="form-control">
                    </asp:TextBox>
                </div>

            </div>
            <div class="FormGroupContent4">
                <div class="right_btn MT0">
                    <div class="btn btn-find">
                        <asp:Button ID="btnchangepwd" runat="server" ToolTip="Update Password" OnClick="btnchangepwd_Click" />

                    </div>
                    <div class="btn ico-cancel">
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" ToolTip="Cancel" />
                    </div>
                </div>
            </div>
        </panel>
                  <asp:Label ID="Label1" runat="server"></asp:Label>
        <ajaxtoolkit:ModalPopupExtender ID="popupChangePassword" runat="server" TargetControlID="Label1" BehaviorID="programmaticModalPopupBehavior2"
            PopupControlID="divchangepassword" Drag="true" BackgroundCssClass="modalBackground" CancelControlID="imgfgok1">
        </ajaxtoolkit:ModalPopupExtender>

            </ContentTemplate>
        </asp:UpdatePanel>

      
       

    </form>
</body>
</html>
