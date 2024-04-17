<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="EmpchangePass.aspx.cs"
    Inherits="logix.FAForm.EmpchangePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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
    <style type="text/css">
        .Gridpnl {
            width: 745px !important;
            height: 377px !important;
        }

        .ChangePasword {
            width: 750px !important;
        }

        .crumbs1 {
            display: none;
        }

        .Passwordtext {
            width: 100%;
            float: left;
            margin: 10px 0px 0px 0px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .FormGroupContent4 label {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        input#logix_CPH_txt_OldPassword {
            -webkit-box-shadow: 0 0 0 30px white inset !important;
        }

        input#logix_CPH_txt_OldPassword, input#logix_CPH_txt_NewPassword, input#logix_CPH_txt_ConfirmPassword {
            border: 0px solid var(--inputborder) !important;
            height: 36px !important;
            border-radius: 0px !important;
            margin: 10px 0px 0px 0px !important;
            border-bottom: 1px solid var(--inputborder) !important;
        }

            input#logix_CPH_txt_OldPassword:focus {
                -webkit-box-shadow: 0 0 0 30px white inset !important;
                border-bottom: 1px solid var(--labelblue) !important;
            }

        input#logix_CPH_txt_OldPassword {
            -webkit-box-shadow: 0 0 0 30px white inset !important;
        }

            input#logix_CPH_txt_OldPassword:focus,
            input#logix_CPH_txt_NewPassword:focus,
            input#logix_CPH_txt_ConfirmPassword:focus {
                border-bottom: 1px solid var(--labelblue) !important;
            }
            .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
            .FixedButtonsss {
    position: fixed;
    top: 30px;
    left: 0;
    background: #fff;
    z-index: 10;
    box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
    width: calc(100vw - 530px);
    border-bottom: 0.5px solid #00000010;
    padding: 1px 0 5px 10px;
}
    </style>
    <link href="../Styles/EmpChangepass.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="ChangePasword">

        <div>
            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server">

                    <div class="widget-header">
                        <div>
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Change Password"></asp:Label></h4>
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#">Home</a> </li>
                                <li><a href="#">Utility</a> </li>
                                <li><a href="#" title="">Change Password</a> </li>
                                <li>
                                    <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                            </ul>
                        </div>
                            </div>

                        <div class="FixedButtons">
      <div class="right_btn">
        <div class="btn ico-save">
            <asp:Button ID="btn_confirm" runat="server" Text="Save" ToolTip="Save" OnClick="btn_confirm_Click1" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click1" />
        </div>

    </div>
</div>

                    </div>
                    <div class="widget-content">
                        
                        <div class="FormGroupContent4 boxmodal">
                            <div class="FormGroupContent4">

                                <asp:Label ID="Label1" runat="server" Text="Employee Name"> </asp:Label>
                                <asp:TextBox ID="txt_EmpName" runat="server" CssClass="form-control" OnTextChanged="txt_EmpName_TextChanged" placeholder="" ToolTip="Employee Name"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="ITLeft">
                                <asp:Label ID="Label2" runat="server" Text="Division"> </asp:Label>
                                <asp:TextBox ID="txt_Division" runat="server" CssClass="form-control" placeholder="" ToolTip="Division"></asp:TextBox>
                            </div>
                            <div class="ITRight">
                                <asp:Label ID="Label3" runat="server" Text="Branch"> </asp:Label>
                                <asp:TextBox ID="txt_Branch" runat="server" CssClass="form-control" placeholder="" ToolTip="Branch"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="ITLeft">
                                <asp:Label ID="Label4" runat="server" Text="Department"> </asp:Label>
                                <asp:TextBox ID="txt_Department" runat="server" CssClass="form-control" placeholder="" ToolTip="Department"></asp:TextBox>
                            </div>
                            <div class="ITRight">
                                <asp:Label ID="Label5" runat="server" Text="Designation"> </asp:Label>
                                <asp:TextBox ID="txt_Desgination" runat="server" CssClass="form-control" placeholder="" ToolTip="Designation"></asp:TextBox>
                            </div>

                        </div>

                        <div class="bordertopNew"></div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="FormGroupContent4">
                                <asp:Label ID="Label6" runat="server" Text="Old Password"> </asp:Label>
                                <asp:TextBox ID="txt_OldPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="10" placeholder="" ToolTip="Old Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="FormGroupContent4">

                                <asp:Label ID="Label7" runat="server" Text="New Password"> </asp:Label>
                                <asp:TextBox ID="txt_NewPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="" MaxLength="10" ToolTip="New Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="FormGroupContent4">

                                <asp:Label ID="Label8" runat="server" Text="Confirm Password"> </asp:Label>
                                <asp:TextBox ID="txt_ConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="" MaxLength="10" ToolTip="Confirm Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="bordertopNew"></div>
                        <div class="FormGroupContent4">
                            <div class="Passwordtext">
                                <asp:Label ID="lbl_chara" runat="server" Text="Password Should be 6 to 10 characters (it should contain one uppercase,one Lower Case,one Numeric)" CssClass="LabelValue"></asp:Label>
                            </div>
                          

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
