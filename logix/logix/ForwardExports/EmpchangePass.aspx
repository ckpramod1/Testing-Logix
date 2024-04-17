<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="EmpchangePass.aspx.cs" Inherits="logix.ForwardExports.EmpchangePass" %>

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
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
   <%-- <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />--%>
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>

     <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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
        Gridpnl {
            width: 745px !important;
            height: 377px !important;
        }

        .ChangePasword {
            width: 100% !important;
        }

        .crumbs1 {
            display: none;
        }

        body {
            overflow: hidden;
        }

        .Passwordtext {
            width: auto;
            float: left;
            margin: 10px 0px 0px 0px;
        }

        div#UpdatePanel1 {
            height: 92vh;
            overflow-x: hidden;
            overflow-y: hidden;
        }
        div.TextField input[type="password"] {
    border: 0px!important;
    border-bottom: 1px solid var(--inputborder) !important;
    border-radius: 0!important;
}
        .FieldInput {
            float: left;
        }
        span#logix_CPH_lbl_chara {
    font-weight: normal!important;
    font-size: 8px;
}
   div.TextField input[type="password"]::placeholder {
    font-size: 8px;
}
 .widget-header p {
    margin: 0 15px;
}
    </style>
    <link href="../Styles/EmpChangepass.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->

    <div class="widget box">
        <div class="widget-header">
            <h3 class="hide">
                <%--<img src="../Theme/newTheme/img/changepassword_ic.png" />--%>
                <asp:Label ID="lbl_Header" runat="server" Text="Change Password"></asp:Label></h3>
            <p>Change Password</p>
               <!-- Breadcrumbs line -->
            <div class="hide">
    <div class="crumbs" id="crumbsid" runat="server">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <%-- <li><a href="#" title="">Utility</a> </li>--%>
            <%--   <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>--%>
            <li class="current"><a href="#" title="">Change Password</a> </li>
        </ul>
    </div>
                </div>
        </div>
        <div class="widget-content">
            <div class="ChangePasword">
                <div class="FormGroupContent4">
                    <div class="LabelWidth hide">Employee Name</div>
                    <div class="FieldInput">
                    <span>Employee Name</span>
                        <asp:TextBox ID="txt_EmpName" runat="server" CssClass="form-control" OnTextChanged="txt_EmpName_TextChanged" placeholder="" ToolTip="Employee Name"></asp:TextBox></div>
                </div>
                <div class="FormGroupContent4">
                    <div class="ITLeft hide">

                        <div class="FieldInput">
                            <span>Division</span>
                            <asp:TextBox ID="txt_Division" runat="server" CssClass="form-control" placeholder="" ToolTip="Division"></asp:TextBox></div>

                    </div>
                    <div class="FormGroupContent4">
                        <div class="LabelWidth hide">Branch</div>
                        <div class="FieldInput">
                            <span>Branch</span>
                            <asp:TextBox ID="txt_Branch" runat="server" CssClass="form-control" placeholder="" ToolTip="Branch"></asp:TextBox></div>

                    </div>
                </div>
                <div class="FormGroupContent4">
                    <div class="ITLeft">
                        <div class="LabelWidth hide">Department</div>
                        <div class="FieldInput">
                            <span>Department</span>
                            <asp:TextBox ID="txt_Department" runat="server" CssClass="form-control" placeholder="" ToolTip="Department"></asp:TextBox></div>

                    </div>
                    <div class="ITRight">
                        <div class="LabelWidth hide">Designation</div>
                        <div class="FieldInput">
                            <span>Designation</span>
                            <asp:TextBox ID="txt_Desgination" runat="server" CssClass="form-control" placeholder="" ToolTip="Designation"></asp:TextBox></div>
                    </div>

                </div>

                <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="LabelWidth hide">Old Password</div>
                    <div class="FieldInput">
                        <span>Old Password</span>
                        <asp:TextBox ID="txt_OldPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="10" placeholder=" " ToolTip="Old Password"></asp:TextBox></div>

                </div>
                <div class="FormGroupContent4">
                    <div class="LabelWidth hide">New Password</div>
                    <div class="FieldInput">
                        <span>New Password</span>
                        <asp:TextBox ID="txt_NewPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password Should be 6 to 10 characters(one uppercase,one Lower Case,one Numeric is must)" MaxLength="10" ToolTip="New Password"></asp:TextBox></div>

                </div>
                <div class="FormGroupContent4">
                    <div class="LabelWidth hide">Confirm Password</div>
                    <div class="FieldInput">
                        <span>Confirm Password</span>
                        <asp:TextBox ID="txt_ConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password Should be 6 to 10 characters(one uppercase,one Lower Case,one Numeric is must)" MaxLength="10" ToolTip="Confirm Password"></asp:TextBox></div>
                </div>
                <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="Passwordtext hide">

                        <asp:Label ID="lbl_chara" runat="server" Text="Password Should be 6 to 10 characters(one uppercase,one Lower Case,one Numeric is must)" CssClass="LabelValue"></asp:Label>
                    </div>
                    <div class="right_btn MB10 MT10">
                        <div class="btn ico-save">
                            <asp:Button ID="btn_confirm" runat="server" ToolTip="Save" OnClick="btn_confirm_Click1" />
                        </div>
                        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                            <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click1" /></div>

                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>
