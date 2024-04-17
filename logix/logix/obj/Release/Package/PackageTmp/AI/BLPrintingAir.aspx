<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="BLPrintingAir.aspx.cs" Inherits="logix.AI.BLPrintingAir" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

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

    <link href="../Styles/BLPrintingAir.css" rel="stylesheet" />
    <%--    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../StylesAuto/Jquery.css" rel="Stylesheet" type="text/css" />
    <link href="../StylesAuto/jquery-ui.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txtblno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "BLPrintingAir.aspx/GetAIEBLDetails",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }

                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);
                        $("#<%=txtblno.ClientID %>").change();

                        $("#<%=hd_hawl.ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {

                        $("#<%=txtblno.ClientID %>").val(i.item.value);
                        $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.value);
                        $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.value);
                        $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
        }

    </script>
    <style type="text/css">
        .crumbslbl {
            display: none;
        }

        .div_Grid {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 200px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow: auto;
        }

        .Booking {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            height: 17px;
        }

        /*LOG DETAILS CSS*/

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

        .modalPopupLog {
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

        .HAWBLInput {
            width: 18%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .IssuedAtInput {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .IssueOn {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FrieghtInput {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px !important;
        }

        .LogHeadJobInput label {
            font-size: 11px;
            font-family: sans-serif;
            color: #4e4e4c;
        }

        .BLTab1 {
            float: left;
            width: 85%;
            margin: 0px 0.5% 0px 0px;
            border-bottom: 0px;
            /* border-bottom: 1px solid #dc6465; */
        }

        .JobInput20 {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FlightInput {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ManiFeast {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MawblInput {
            width: 11%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
    </style>
    <style type="text/css">

    div#logix_CPH_div_BLfreigthdetail {
    width: 60%;
}

        .BackView {
            float: right;
            margin: 0px 0% 0px 0px;
            width: 8.5%;
        }

            .BackView a {
                color: #034aa6;
            }

        .OutStandingLbl1 {
            float: left;
            width: 10%;
        }

            .OutStandingLbl1 h3 {
                font-size: 14px;
                color: #034aa6;
                padding: 5px 0px 5px 3px;
                margin: 0px 0px 0px 0px;
                font-family: 'OpenSansRegular';
                font-weight: normal;
            }

        .OutStandingLbl2 {
            float: left;
            width: 65%;
            padding: 3px 0px 5px 0px;
            margin: 0px 0px 0px 0px;
            font-weight: bold;
            color: #4e4e4c;
        }

            .OutStandingLbl2 span {
                font-size: 11px;
                color: brown;
                font-family: sans-serif;
                display: inline-block;
                color: Brown;
                font-weight: normal;
                padding: 3px 0px 5px 0px;
                margin: 0px 0px 0px 0px;
            }

        .BLPrint table {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

        .BLPrint thead {
            position: relative;
            display: block;
            width: 100%;
            overflow: visible;
        }

            .BLPrint thead th {
                min-width: 182px;
            }

        .BLPrint tbody td {
            min-width: 182px;
        }

        .BLPrint tbody {
            position: relative;
            display: block; /*seperates the tbody from the header*/
            width: 100%;
            height: 410px;
            overflow: auto;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 12px;
        }

        .chzn-container-single .chzn-single span {
            color: #4e4e4c !important;
        }

        a {
            font-size: 12px;
            color: #ee3926;
        }

        .BookingInput11 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .QuotationInput1 {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Shipper1 {
            width: 33%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Consignee5 {
            width: 33%;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }

        .quotaion {
            width: 33%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .marketed {
            width: 16.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CargoInput2 {
            width: 19.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PackagesInput2 {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ChargeWt1 {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GrossWt1 {
            width: 6.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .dodate {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .dopending {
            width: 10.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .notify {
            width: 33%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .CHA_CNF {
            width: 33%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Handling {
            width: 33%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
        .Carrier1{
            width: 21.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
         .Carrier2{
            width: 22%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
          .Carrier3{
            width: 22%;
            float: left;
            margin: 0px 0% 0px 0px;
        }
          .from {
    width: 16%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
           .to {
    width: 16.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
           .Description {
    width: 50%;
    float: left;
       margin-right: 0.5% !important;
}
           .Other_Charges {
    width: 49.5%;
    float: left;
    margin: 0px;
}
           th:nth-child(6) {
    width: 160px;
}
           th:nth-child(5) {
    width: 160px;
}
           th:nth-child(4) {
    width: 160px;
}
           th:nth-child(3) {
    width: 160px;
}
           th:nth-child(2) {
    width: 160px;
}
           a#logix_CPH_lnk_bl,a#logix_CPH_lnk_blvoucher,a#logix_CPH_lnk_blfreight {
    background: var(--navbarcolor);
    border-radius: 3px;
    margin: 2px 0px 0px;
    color: var(--white)!important;
}
       div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 58px !important;
}   
       div#UpdatePanel1 {
    /* height: 100vh; */
    height: 89vh;
    overflow-x: hidden;
    overflow-y: auto;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_header" runat="server" Text="DODetails"></asp:Label></h4>
                         <!-- Breadcrumbs line -->
    <div id="crumbslbl" class="crumbs" runat="server">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Ops & Docs</a> </li>
            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>
            <li class="current"><a href="#" title="" id="Headerlable" runat="server">DO Details</a> </li>
        </ul>
    </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent FixedButtons">
                         <div class="right_btn " id="div_Bltbn" runat="server">
                            <div class="btn ico-print" id="btnprint_id" runat="server" >
                                <asp:Button ID="btnprint" Text="Print" runat="server" ToolTip="Print" OnClick="btnprint_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_back1" runat="server">
                                <asp:Button ID="btnback" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnback_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="FormGroupContent">
                        <div class="BLTab1">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk_bl" runat="server" OnClick="lnk_bl_Click">BL Details</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk_blvoucher" runat="server" OnClick="lnk_blvoucher_Click">BL Voucher Details</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk_blfreight" runat="server" OnClick="lnk_blfreight_Click">BL freight Details</asp:LinkButton></li>
                            </ul>
                        </div>
                        <div class="BackView">
                            <asp:LinkButton ID="lnk_Creditdet" runat="server" OnClick="lnk_Creditdet_Click" Visible="false">View OutStanding</asp:LinkButton>
                        </div>
                        <div class="BLBackRight" style="display: none;">
                            <asp:LinkButton ID="lnk_back" Style="text-decoration: none; font-weight: bold" ForeColor="Red" runat="server" Visible="false" OnClick="lnk_back_Click">Back to Previous</asp:LinkButton>
                        </div>

                    </div>
                    <div id="div_BLDetails" runat="server">
                        <div class="FormGroupContent4 boxmodal">
                            <div class="HAWBLInput">
                                <asp:Label ID="Label2" runat="server" Text="HAWBL#"></asp:Label>
                                <asp:TextBox ID="txtblno" runat="server" AutoPostBack="True" CssClass="form-control" PlaceHolder=" " ToolTip=" HAWBL#" OnTextChanged="txtblno_TextChanged"></asp:TextBox>
                            </div>
                            <div class="IssuedAtInput">
                                <asp:Label ID="Label1" runat="server" Text="Issued At"></asp:Label>
                                <asp:TextBox ID="txtissue" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Issued At" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="IssueOn">
                                <asp:Label ID="Label3" runat="server" Text="Issued On"></asp:Label>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Issued On" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="FrieghtInput">
                                <asp:Label ID="Label5" runat="server" Text="Freight"></asp:Label>
                                <asp:TextBox ID="txtfreight" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Freight" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="JobInput20">
                                <asp:Label ID="Label6" runat="server" Text="Job #"></asp:Label>
                                <asp:TextBox ID="txtjobno" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Job #" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="FlightInput">
                                <asp:Label ID="Label7" runat="server" Text="Flight"></asp:Label>
                                <asp:TextBox ID="txtFlight" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Flight" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="ManiFeast">
                                <asp:Label ID="Label8" runat="server" Text="MAWB#"></asp:Label>
                                <asp:TextBox ID="txtMBL" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" MAWBL#" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="MawblInput">
                                <asp:Label ID="Label9" runat="server" Text="Manifeast #"></asp:Label>
                                <asp:TextBox ID="txtManiFest" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Manifeast #" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="FormGroupContent4 custom-d-flex">
                            <div class="BookingInput11">
                                <span>Booking #</span>
                                
                                <asp:TextBox ID="txtbooking" runat="server" ReadOnly="True" CssClass="form-control" PlaceHolder=" " ToolTip=" Booking Number" AutoPostBack="True" ForeColor="Teal"></asp:TextBox>
                            </div>
                              <asp:LinkButton ID="lnk_book" CssClass="acn ico-find-sm" runat="server" ForeColor="Red" Style="text-decoration: none;" OnClick="lnk_book_Click"></asp:LinkButton>
                            <div class="QuotationInput1 LinkButton">
                                <span>Quotation #</span>
                                
                                <asp:TextBox ID="txtquot" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Quotation Number" ReadOnly="True" ForeColor="Teal"></asp:TextBox>
                            </div>
                               <asp:LinkButton ID="lnk_Quotation"  CssClass="acn ico-find-sm"  runat="server" ForeColor="Red" Style="text-decoration: none;" OnClick="lnk_Quotation_Click"></asp:LinkButton>
                            <div class="custom-col custom-mr-05">
                                <asp:Label ID="Label13" runat="server" Text="Marketed By"></asp:Label>
                                <asp:TextBox ID="txtmartketed" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Marketed By" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="custom-col custom-mr-05">
                                <asp:Label ID="Label24" runat="server" Text="Cargo"></asp:Label>
                                <asp:TextBox ID="txtcargo" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="Cargo" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="PackagesInput2">
                                <asp:Label ID="Label25" runat="server" Text="Packages"></asp:Label>
                                <asp:TextBox ID="txtpackage" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Packages" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="ChargeWt1">
                                <asp:Label ID="Label26" runat="server" Text="Charge Wt."></asp:Label>
                                <asp:TextBox ID="txtcbm" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Charge Wt." ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="GrossWt1">
                                <asp:Label ID="Label27" runat="server" Text="Gross Wt."></asp:Label>
                                <asp:TextBox ID="txtweight" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Gross Wt." ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="dodate" id="div_cha" runat="server">
                                <asp:Label ID="Label31" runat="server" Text="DO Date"></asp:Label>
                                <asp:TextBox ID="txtDOdate" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="DO Date" ReadOnly="True" ForeColor="Teal"></asp:TextBox>
                            </div>
                            <div class="dopending" id="dodaytxt" runat="server">
                                <asp:Label ID="Label32" runat="server" Text="DO Pending Days"></asp:Label>
                                <asp:TextBox ID="txtDOPDays" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="Delivery Order Pending Days" ReadOnly="True"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="Shipper1">
                                <asp:Label ID="Label10" runat="server" Text="Air Liner"></asp:Label>
                                <asp:TextBox ID="txtmlo" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Air Liner" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="Consignee5">
                                <asp:Label ID="Label11" runat="server" Text="Agent"></asp:Label>
                                <asp:TextBox ID="txtagent" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Agent" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="quotaion">
                                <asp:Label ID="Label12" runat="server" Text="Quotation Customer"></asp:Label>
                                <asp:TextBox ID="txtQuotCustomer" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Quotation Customer" ReadOnly="True" ForeColor="Teal"></asp:TextBox>
                            </div>
                        </div>

                        <div class="FormGroupContent4 boxmodal">
                            <div class="Shipper1">
                                <asp:Label ID="Label14" runat="server" Text="Shipper"></asp:Label>
                                <asp:TextBox ID="txtshipper" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Shipper" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="Consignee5">
                                <asp:Label ID="Label15" runat="server" Text="Consignee"></asp:Label>
                                <asp:TextBox ID="txtconsignee" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Consignee" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="notify">
                                <asp:Label ID="Label16" runat="server" Text="Notify 1"></asp:Label>
                                <asp:TextBox ID="txtnotify1" runat="server" CssClass="form-control" PlaceHolder="" ToolTip=" Notify 1" ReadOnly="True"></asp:TextBox>
                            </div>

                            <div class="Consignee5">
                                <asp:Label ID="Label17" runat="server" Text="Notify 2"></asp:Label>
                                <asp:TextBox ID="TxtNotify2" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" Notify 2" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="CHA_CNF">
                                <asp:Label ID="Label23" runat="server" Text="CHA/CNF"></asp:Label>
                                <asp:TextBox ID="txtcnf" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="CHA/CNF" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="Handling">
                                <asp:Label ID="Label28" runat="server" Text="Handling Info"></asp:Label>
                                <asp:TextBox ID="txthandling" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="Handling Info" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div class="from">
                            <asp:Label ID="Label18" runat="server" Text="From Port"></asp:Label>
                            <asp:TextBox ID="txtpol" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" From Port" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="to">
                            <asp:Label ID="Label19" runat="server" Text="To Port"></asp:Label>
                            <asp:TextBox ID="txtfd" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip=" To Port" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="Carrier1">
                            <asp:Label ID="Label20" runat="server" Text="Carrier 1"></asp:Label>
                            <asp:TextBox ID="txtCarrier1" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="Carrier 1" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="Carrier2">
                            <asp:Label ID="Label21" runat="server" Text="Carrier 2"></asp:Label>
                            <asp:TextBox ID="txtCarrier2" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="Carrier 2" ReadOnly="True"></asp:TextBox>
                        </div>
                         <div class="Carrier3">
                            <asp:Label ID="Label22" runat="server" Text="Carrier 3"></asp:Label>
                            <asp:TextBox ID="txtCarrier3" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="Carrier 3" ReadOnly="True"></asp:TextBox>
                        </div>

                    </div>
                  
                    <div class="FormGroupContent4">
                   
                        <div class="Description boxmodal">
                    <div class="FormGroupContent4">
                            <asp:Label ID="Label29" runat="server" Text="Description"></asp:Label>
                            <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control" PlaceHolder=" " ToolTip="Description" Width="100%" TextMode="MultiLine" Style="resize: none;" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>

                        <div class="Other_Charges boxmodal">
                    <div class="FormGroupContent4">

                            <asp:Label ID="Label30" runat="server" Text="Other Charges"></asp:Label>
                            <asp:TextBox ID="txtothchg" runat="server" CssClass="form-control" PlaceHolder=" " TextMode="MultiLine" Width="100%" Style="resize: none;" ToolTip="Other Charges" ReadOnly="True"></asp:TextBox>
                        </div>
                        </div>
                        </div>
                    <div class="FormGroupContent4">
                    </div>
                    <div id="div_cfstxt" class="div_cfstxt" runat="server">
                    </div>
                  
                </div>
                <div class="FormGroupContent4">

                    <div class="div_view" id="div_BLvoucherdetail" runat="server" visible="false" style="width:60%">
                        <div class="panel_05">
                            <asp:GridView CssClass="Grid FixedHeader"  ID="Grd_Invoice" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" PageSize="15"
                                DataKeyNames="billtype,vouyear"
                                ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:BoundField DataField="invoiceno" HeaderText="Inv #" />
                                    <asp:BoundField DataField="customername" HeaderText="Customer" />
                                    <asp:BoundField DataField="amount" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle CssClass="align-right" />

                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>
                        <div class="div_Break">
                        </div>
                        <div class="panel_05">
                            <asp:GridView CssClass="Grid FixedHeader"  ID="Grd_DN" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" PageSize="15"
                                DataKeyNames="vouyear" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:BoundField DataField="dnno" HeaderText="DN #" />
                                    <asp:BoundField DataField="customername" HeaderText="Customer" />
                                    <asp:BoundField DataField="amount" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle CssClass="align-right" />

                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>
                        <div class="div_Break">
                        </div>
                        <div class="panel_05">
                            <asp:GridView CssClass="Grid FixedHeader"  ID="Grd_receipt" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                                PageSize="15" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:BoundField DataField="receipt" HeaderText="Receipt #" />
                                    <asp:BoundField DataField="receiptdate" HeaderText="Date" />
                                    <asp:BoundField DataField="receiptamount" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle CssClass="align-right" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="chequeno" HeaderText="Cheque #" />
                                    <asp:BoundField DataField="bank" HeaderText="Bank" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <div class="div_break"></div>
                        </div>
                        <div class="div_break"></div>
                    </div>
                    <div class="div_view" id="div_BLfreigthdetail" runat="server" visible="false">
                        <div class="panel_16">
                            <asp:GridView CssClass="Grid FixedHeader"  ID="Grd_freightdetail" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                                PageSize="15" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:BoundField DataField="charge" HeaderText="Charge" />
                                    <asp:BoundField DataField="curr" HeaderText="Curr" />
                                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle CssClass="align-right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="exrate" HeaderText="Ex.Rate" DataFormatString="{0:#,##0.00}">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle CssClass="align-right" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="base" HeaderText="Base" />
                                    <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle CssClass="align-right" />

                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>
                        <div class="div_break"></div>
                    </div>
                </div>

                <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                    <div class="divRoated">
                        <div class="LogHeadLbl">
                            <div class="LogHeadJob">
                                <label>HAWBL # :</label>

                            </div>
                            <div class="LogHeadJobInput">

                                <asp:Label ID="JobInput" runat="server"></asp:Label>

                            </div>

                        </div>
                        <div class="DivSecPanel">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                        </div>

                        <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                            <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                                ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                BackColor="White">
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

            </div>
        </div>
    </div>

    <asp:Label ID="Label4" runat="server"></asp:Label>

        <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
            DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
        </asp:ModalPopupExtender>

        <%-- Elengo --%>
        <asp:Label ID="LblCncl" runat="server"></asp:Label>
        <asp:ModalPopupExtender ID="PopCreditdet" runat="server" TargetControlID="LblCncl"
            BehaviorID="frgtydfdfdf" PopupControlID="pnlCreditdet" CancelControlID="imgcls" DropShadow="false">
        </asp:ModalPopupExtender>

        <asp:Panel ID="pnlCreditdet" runat="server" CssClass="modalPopup" Style="display: none;">
            <div class="OutStandingLbl1">
                <h3>Out Standing</h3>
            </div>
            <div class="OutStandingLbl2">Credit Customerwise OutStanding - <span id="CustomerLbl1" runat="server"></span></div>
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:GridView ID="grdCridtDet" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False"
                    OnRowDataBound="grdCridtDet_RowDataBound" OnPreRender="grdCridtDet_PreRender">
                    <Columns>
                        <asp:BoundField DataField="shortname" HeaderText="Branch">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 0 --%>
                        <asp:BoundField DataField="customername" HeaderText="Individual Customer  Names">
                            <HeaderStyle Width="250px" />
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <%-- 1 --%>
                        <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 2 --%>
                        <asp:BoundField DataField="invdate" HeaderText="Date">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 3 --%>
                        <asp:BoundField DataField="days" HeaderText="O/S Days">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 4 --%>
                        <asp:BoundField DataField="osamount" HeaderText="O/S Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <%-- 5 --%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False" />
                </asp:GridView>
                <div class="Break"></div>
            </div>
            <div class="Break"></div>
        </asp:Panel>

        <asp:HiddenField ID="hid_BL" runat="server" Value="false" />
        <asp:HiddenField ID="hid_job" runat="server" />
        <asp:HiddenField ID="hid_contno" runat="server" />
        <asp:HiddenField ID="hid_customer" runat="server" />
        <asp:HiddenField ID="hid_BookingNo" runat="server" />
        <asp:HiddenField ID="hid_head" runat="server" />
        <asp:HiddenField ID="hid_cha" runat="server" />
        <asp:HiddenField ID="hid_split" runat="server" />
        <asp:HiddenField ID="hd_hawl" runat="server" />
        <asp:HiddenField ID="hid_CustomerId" runat="server" />
           <asp:HiddenField ID="hidnoinvchk" Value="Y" runat="server" />
         <asp:HiddenField ID="hidinvmailchk" runat="server" />
         <asp:HiddenField ID="hidcustname" runat="server" />
</asp:Content>
