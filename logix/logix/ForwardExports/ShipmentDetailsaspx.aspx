<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ShipmentDetailsaspx.aspx.cs" Inherits="logix.ForwardExports.ShipmentDetailsaspx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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

    <link rel="Stylesheet" href="../Styles/Shipmentdetails.css" />
    <%--<script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <%--<script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
      <script src="../Scripts/Validation.js" type="text/javascript"></script>--%>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }

        .headlbl {
            display: none;
        }

        .Branchtxt1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 3%;
        }

        .Producttxt {
            float: left;
            margin: 0 0.5% 0 0;
            width: 3.5%;
        }

        .BranchDropN1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 20%;
        }

        .FromTxt1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 2.5%;
        }

        .totxt1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 1%;
        }

        .ForwardingDrop {
            float: left;
            margin: 0 0.5% 0 0;
            width: 16.5%;
        }

        .ByDrop {
            float: left;
            margin: 0 0.5% 0 0;
            width: 12.5%;
        }

        .BranchDropN1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 13%;
        }

        .MT17 {
            margin: 17px 0px 0px 0px !important;
        }

        .JoblinkGross1 {
            width: 32%;
            float: left;
            margin: 0px 3px 0px 0px;
        }
        .ToCal6 {
    width: 7%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .FromCalNew {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
            .JoblinkGross1 a {
                color: red;
                display: block;
                padding: 0px 0px 3px 0px;
            }

            .JoblinkGross1 span {
                display: block;
                padding: 0px 0px 3px 0px;
            }

            .JoblinkGross1 label {
                display: block;
                padding: 0px 0px 0px 0px;
            }

        .JoblinkGross2 {
            width: 32%;
            float: left;
            margin: 17px 1px 0px 0px;
        }

            .JoblinkGross2 a {
                color: red;
                display: block;
                padding: 0px 0px 3px 0px;
            }

            .JoblinkGross2 span {
                display: block;
                padding: 0px 0px 3px 0px;
            }

            .JoblinkGross2 label {
                display: block;
                padding: 0px 0px 0px 0px;
            }

        .JoblinkCha1 {
            width: 34.7%;
            float: left;
            margin: 0px 1px 0px 0px;
        }

            .JoblinkCha1 a {
                color: red;
                display: block;
                padding: 0px 0px 3px 0px;
            }

            .JoblinkCha1 span {
                display: block;
                padding: 0px 0px 3px 0px;
            }

            .JoblinkCha1 label {
                display: block;
                padding: 0px 0px 0px 0px;
            }

        .GridPalICD1 {
            height: 402px !important;
            width: 100% !important;
            border: 1px solid #b1b1b1;
            overflow: auto;
        }
        /*-----log*/
        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }

        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

            .DivSecPanelLog img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }

        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

        .LogHeadLbl {
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        /*logix_CPH_PanelLog {
            top: 200px !important;
        }*/
        .widget.box {
            position: relative;
            top: -8px;
        }
 

  div#logix_CPH_Panel1 {
    height: 309px !important;
}
  div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
  .widget.box .widget-content {
    top: 0px !important;
    padding-top: 50px !important;
}
  div#logix_CPH_Panel2 {
    height: calc(100vh - 406px);
}
    </style>

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });

            <%-- $(document).ready(function () {
                $('#<%=GrdJob.ClientID%>').gridviewScroll({
                    width: 840,
                    height: 415,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>
            <%--$(document).ready(function () {
                $('#<%=GrdBL.ClientID%>').gridviewScroll({
                     width: 840,
                     height: 415,
                     arrowsize: 30,

                     varrowtopimg: "../images/arrowvt.png",
                     varrowbottomimg: "../images/arrowvb.png",
                     harrowleftimg: "../images/arrowhl.png",
                     harrowrightimg: "../images/arrowhr.png"
                 });
             });--%>

            <%-- $(document).ready(function () {
                 $('#<%=grdbudget.ClientID%>').gridviewScroll({
                    width: 225,
                    height: 425,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>
        }
    </script>
    <style type="text/css">
        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Shipment Details"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="" id="headerlable2" runat="server">MIS  and Analytics</a> </li>
                            <li id="headlbl" runat="server"><a href="#" title="" id="headerlable1" runat="server"></a></li>
                            <li class="current"><a href="#" title="">Shipment Details</a> </li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons">
     <div class="right_btn">
        <div class="btn ico-get">
            <asp:Button ID="btnget" runat="server"  Text="Get" ToolTip ="Get" OnClick="btnget_Click" />
        </div>
        <div class="btn ico-excel">
            <asp:Button ID="btn_exp1" runat="server" Text="Export Excel" ToolTip="Export Excel" OnClick="btn_exp1_Click" />

        </div>

        <div class="btn ico-cancel" id="btncancel1" runat="server">
            <asp:Button ID="btncancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
        </div>
    </div>
</div>


                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">

                        <div class="BranchDropN1 fit-content">
                            <asp:Label ID="lbl_branch" runat="server" Text="Branch" CssClass="LabelValue"></asp:Label>
                            <asp:DropDownList ID="ddl_branch" runat="server" AppendDataBoundItems="True" CssClass="chzn-select"
                                AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" data-placeholder="Branch" ToolTip="Branch">
                            </asp:DropDownList>
                        </div>

                        <div class="ForwardingDrop fit-content">
                            <asp:Label ID="lbl_product" runat="server" Text="Product" CssClass="LabelValue"></asp:Label>
                            <%--            <asp:DropDownList ID="ddl_product" runat="server" AppendDataBoundItems="True" CssClass="chzn-select"
                AutoPostBack="True" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged" data-placeholder="Product" ToolTip="Product">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>ALL</asp:ListItem>
                <asp:ListItem Value="AE">Air Exports</asp:ListItem>
                <asp:ListItem Value="AI">Air Imports</asp:ListItem>
                <asp:ListItem Value="CH">Custom House Agent</asp:ListItem>
                <asp:ListItem Value="FE">Ocean Exports</asp:ListItem>
                <asp:ListItem Value="FI">Ocean Imports</asp:ListItem>
            </asp:DropDownList>--%>
                            <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="ByDrop">
                            <asp:Label ID="lbl_by" runat="server" Text="By"></asp:Label>
                            <asp:DropDownList ID="ddl_by" runat="server" AppendDataBoundItems="True" CssClass="chzn-select"
                                AutoPostBack="True" OnSelectedIndexChanged="ddl_by_SelectedIndexChanged" data-placeholder="By" ToolTip="By">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="FromCalNew">
                            <asp:Label ID="lbl_frm" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <asp:CalendarExtender ID="from" runat="server" TargetControlID="txt_from" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <div class="ToCal6">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <asp:CalendarExtender ID="to" runat="server" TargetControlID="txt_to" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                       

                    </div>

                    <div class="FormGroupContent4">
                        <div class="JobLeft">
                            <div class="FormGroupContent4">

                             <%-- commented and added labels in the span tag to add missing text in the anchor tag -- Praveen & Daya 2023-May-12  --%>
                             <%--   <asp:LinkButton ID="link_job" CssClass="anc ico-find-sm" runat="server" ForeColor="Red" OnClick="link_job_Click">No.of Jobs</asp:LinkButton>
                                <asp:LinkButton ID="link_hbl" runat="server" CssClass="anc ico-find-sm" ForeColor="Red"  OnClick="link_hbl_Click">No.of HBL</asp:LinkButton> --%>

                                <asp:LinkButton ID="link_job" CssClass="anc ico-find-sm"  runat="server" ForeColor="Red" OnClick="link_job_Click"></asp:LinkButton>
                                     <span style="display: inline-block;float: left; margin: 19px 7px 0px 9px;"> No. of jobs</span>
                                <asp:LinkButton ID="link_hbl" runat="server" CssClass="anc ico-find-sm" ForeColor="Red"  OnClick="link_hbl_Click"></asp:LinkButton>
                                     <span style="display: inline-block;float: left; margin: 19px 7px 0px 9px;"> No.of HBL </span>
                        </div>



                            <div class="FormGroupContent4 boxmodal">
                                <div class="Joblink">
                                    <span>No.of Jobs</span>
                                    <asp:TextBox ID="txt_linkjob" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="Joblink LinkButton">
                                    <span>No.of Jobs</span>

                                    <asp:TextBox ID="txt_linkhbl" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="Joblink1">

                                    <asp:Label ID="lbl_spiltbl" runat="server" Text="Spilt BL"></asp:Label>
                                    <asp:TextBox ID="txt_splitbl" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <a>
                                    <asp:Label ID="lbl_fcl" runat="server" Text="FCL" ></asp:Label>
                                </a>
                            </div>

                            <div class="FormGroupContent4 boxmodal">
                                <div class="Joblink">
                                    <asp:Label ID="lbl_fcl20" runat="server" Text="No. of 20'"></asp:Label>
                                    <asp:TextBox ID="txt_fcl20" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="Joblink ">
                                    <asp:Label ID="lbl_fcl40" runat="server" Text="No. of 40'"></asp:Label>
                                    <asp:TextBox ID="txt_fcl40" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="Joblink1 ">
                                    <asp:Label ID="lbl_fcltues" runat="server" Text="No. of Teus"></asp:Label>
                                    <asp:TextBox ID="txt_fcltues" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <a>
                                    <asp:Label ID="lbl_console" runat="server" Text="Consol"></asp:Label>
                                </a>
                            </div>
                            <div class="FormGroupContent4 boxmodal">
                                <div class="Joblink">
                                    <asp:Label ID="lbl_concol20" runat="server" Text="No. of 20'"></asp:Label>

                                    <asp:TextBox ID="txt_consol20" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="Joblink">
                                    <asp:Label ID="lbl_concol40" runat="server" Text="No. of 40'"></asp:Label>
                                    <asp:TextBox ID="txt_consol40" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="Joblink1 ">

                                    <asp:Label ID="lbl_consolcbm" runat="server" Text="No. of CBM"></asp:Label>
                                    <asp:TextBox ID="txt_consolcbm" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <a>
                                    <asp:Label ID="lbl_AE" runat="server" Text="Air Exports" ></asp:Label>
                                </a>
                                <a style="position: relative;left: 72px;">
                                    <asp:Label ID="lbl_lcl" runat="server" Text="LCL"></asp:Label>
                                </a>
                                <a style="position: relative;left: 171px;">
                                    <asp:Label ID="lbl_CHA" runat="server" Text="CHA" ></asp:Label></a>
                            </div>
                            <div class="FormGroupContent4 boxmodal">

                                <%--<div class="Joblink">--%>

                                    <asp:Label ID="lbl_cmb" runat="server" Text="CBM"></asp:Label>
                                    <asp:TextBox ID="txt_cbm" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div class="JoblinkGross1 LinkButton" runat="server" id="div_AirExports">
                                    <asp:Label ID="lbl_GW" runat="server" Text="Gross Wt."></asp:Label>
                                    <asp:TextBox ID="txt_GW" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div class="JoblinkCha1 LinkButton">
                                    <asp:Label ID="lbl_Shpts" runat="server" Text="Shpts"></asp:Label>
                                    <asp:TextBox ID="txt_Shpts" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        <div class="JobRight">
                            <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="Panel1" runat="server" CssClass="panel_14 MB0">
                                    <%--<div class="div_Grid">--%>
                                    <asp:GridView CssClass="Grid FixedHeader" ID="GrdJob" runat="server" AutoGenerateColumns="False"
                                        Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdJob_RowDataBound" OnPageIndexChanging="GrdJob_PageIndexChanging"
                                        DataKeyNames="bid,cid" OnSelectedIndexChanged="GrdJob_SelectedIndexChanged" OnPreRender="GrdJob_PreRender">
                                        <%--PageSize="15" AllowPaging="false"--%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.L #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="jobdate" HeaderText="OpenedOn">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="vslvoy" HeaderText="VslVoy">
                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="VslVoy">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                        <asp:Label ID="lbl_vessel" runat="server" Text='<%# Eval("vslvoy")%>' ToolTip='<%# Eval("vslvoy")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="eta" HeaderText="ETA/ETD">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="agent" HeaderText="Agent">
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Agent">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                                        <asp:Label ID="lbl_Agent" runat="server" Text=' <%# Eval("agent")%>' ToolTip=' <%# Eval("agent")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="preparedby" HeaderText="OpenedBy">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bid" HeaderText="bid" Visible="False">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="cid" HeaderText="cid" Visible="False">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ClosedOn" HeaderText="ClosedOn">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_consignee" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">&#8667;</asp:LinkButton>
                           
                        </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="1%"  HorizontalAlign="Center"  />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>--%>
                                        </Columns>
                                        <%--<EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />--%>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />

                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                    <%--  </asp:Panel>--%>
                                    <%--</div>--%>
                                    <div class="div_Break"></div>
                                    <div class="">
                                        <%-- <asp:Panel ID="Panel2" runat="server" CssClass="GridPalICD">--%>
                                        <asp:GridView CssClass="Grid FixedHeader" ID="GrdBL" runat="server" AutoGenerateColumns="False" OnRowDataBound="GrdBL_RowDataBound"
                                            Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" OnPageIndexChanging="GrdBL_PageIndexChanging"
                                            OnSelectedIndexChanged="GrdBL_SelectedIndexChanged" OnPreRender="GrdBL_PreRender">
                                            <%-- PageSize="15" AllowPaging="false"--%>
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.L #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="false" Width="1%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="70px" />
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="20px" />
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:BoundField>
                                                <%-- <asp:BoundField DataField="blno" HeaderText="BL#">
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="2%" Wrap="false" />
                    </asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="BL#">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                            <asp:Label ID="blno" runat="server" Text='<%# Bind("blno") %>'></asp:Label>
                                                        </div>

                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="50%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="nomination" HeaderText="Nomination">
                                                    <HeaderStyle HorizontalAlign="Center" Width="2%" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="shipper" HeaderText="Shipper">
                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Shipper">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                            <asp:Label ID="shipper" runat="server" Text='<%# Bind("shipper") %>'></asp:Label>
                                                        </div>

                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="25%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PoL">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                            <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                        </div>

                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="25%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <%-- <asp:BoundField DataField="pol" HeaderText="PoL">
                        <HeaderStyle HorizontalAlign="Center"  Width="9%" Wrap="false" />
                        <ItemStyle HorizontalAlign="Left" Width="9%" Wrap="false"  />
                    </asp:BoundField>--%>
                                                <%-- <asp:BoundField DataField="fd" HeaderText="FD">
                        <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="false" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" Wrap="false" />
                    </asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Place of Delivery">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                            <asp:Label ID="fd" runat="server" Text='<%# Bind("fd") %>'></asp:Label>

                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="false" Width="25%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="cbm" HeaderText="CBM">
                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Right" Width="5%" Wrap="false" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="agent" HeaderText="Agent">
                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Agent">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                            <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>

                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="25%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <%--   <asp:BoundField DataField="preparedby" HeaderText="Preparedby">
                        <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="1%" Wrap="false" />
                    </asp:BoundField>--%>

                                                <asp:TemplateField HeaderText="Preparedby">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                            <asp:Label ID="preparedby" runat="server" Text='<%# Bind("preparedby") %>'></asp:Label>

                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="25%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Back">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnk_back" runat="server" CommandName="Select" Font-Underline="false"
                                CssClass="Arrow">&#8666;</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:TemplateField>--%>
                                            </Columns>
                                            <%-- <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />--%>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                        </asp:GridView>

                                    </div>
                                </asp:Panel>
                            </div>

                        </div>
                           
                        </div>






                     <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="Panel2" runat="server" CssClass="gridpnl">
                                    <asp:GridView CssClass="Grid FixedHeader" ID="grdbudget" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdbudget_RowDataBound"
                                        Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" OnPreRender="grdbudget_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="Product" HeaderText="Product">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" Width="40%" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AgentBL" HeaderText="AgentBL">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="28%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OurBL" HeaderText="OurBL">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="28%" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hid_Str_Trantype" runat="server" />
    <%--</div>--%>

    <asp:GridView ID="grdexcel" runat="server"></asp:GridView>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_no" runat="server"></label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="GridNew FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                    BackColor="White" OnPreRender="GridViewlog_PreRender">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="myGridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>

    </asp:Panel>
    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
