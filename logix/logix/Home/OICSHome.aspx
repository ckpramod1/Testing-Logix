<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="OICSHome.aspx.cs" Inherits="logix.Home.OICSHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title></title>
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
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

    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <style type="text/css">
        .widget-content span {
            font-size: 11px;
            color: var(--labelblack);
            font-weight: normal !important;
        }

        #Test_foregroundElement {
            left: 55px !important;
            top: 285px !important;
        }

        #Test1_foregroundElement {
            left: 147px !important;
            top: 3285px !important;
        }

        #Test2_foregroundElement {
            left: 211px !important;
            top: 285px !important;
        }

        #Test3_foregroundElement {
            left: 282px !important;
            top: 285px !important;
        }

        #Test4_foregroundElement {
            left: 525px !important;
            top: 285px !important;
        }

        .row {
            clear: both;
            height: 448px !important;
            margin: 0 5px 0 -15px;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
        }

        .TblScroll {
            height: 356px;
            width: 100%;
            border: 0px solid #003a65;
        }

        .Brder {
            border: 1px solid #b1b1b1;
        }

        .divbtn1 {
            width: 175px;
            background-color: var(--tablerowcolor) !important;
            float: left;
            text-align: left;
            margin: 5px 0.5% 0px 0px;
            border: 1px solid var(--inputborder);
            border-bottom: none;
        }

        .divbtn2 {
            width: 175px;
            background-color: #fff;
            float: left;
            text-align: left;
            margin: 0px 0.5% 0px 0px;
            border: 1px solid var(--inputborder);
            border-top: 0px;
            border-bottom: none;
        }

        .divbtn3 {
            width: 175px;
            text-align: left;
            float: left;
            background: var(--tablerowcolor) !important;
            margin: 0px 0.5% 0px 0px;
            border: 1px solid var(--inputborder);
            border-top: none;
        }

            .divbtn1 a,
            .divbtn2 a,
            .divbtn3 a {
                display: inline-block;
                padding: 5px;
                font-size: 11px !important;
                text-align: left;
                color: var(--grey) !important;
                margin: 0px;
                font-weight: normal !important;
            }

        .LoginCompanyDrop {
            width: 334px;
            float: left;
            margin: 25px 10px 10px 18px;
        }

        .LoginCompanyDropN1 {
            width: 334px;
            float: left;
            margin: 0px 10px 10px 0px;
        }

        .div_data {
            float: left;
            width: 60px;
            margin: 15px 5px 0px 56px;
        }

        .div_graph {
            float: left;
            width: 60px;
            margin: 15px 5px 0px 56px;
        }

        .BrderVisible {
            height: 429px;
            margin: 2px 0px 0px 0px;
            border: 1px solid #b1b1b1;
        }

        .div_Grd1 {
            float: left;
            width: 100%;
            height: 450px;
            overflow: auto;
            margin-top: 1%;
            font-family: sans-serif;
            font-size: 10pt;
            /*overflow-y:scroll;*/
        }

        .div_total1 {
            border: 0px solid black;
            width: 600px;
            float: left;
            margin-left: 0.5%;
            background: white;
        }

        .div_Grd2 {
            float: left;
            width: 99%;
            /*height: 480px;*/
            /*overflow: auto;*/
            font-family: sans-serif;
            font-size: 10pt;
            margin-left: 0.5%;
            margin-bottom: 0.5%;
            margin-top: 1%;
            /*overflow-y:scroll;*/
        }

        .div_total2 {
            border: 0px solid black;
            width: 100%;
            float: left;
            margin-left: 0.5%;
            background: white;
        }

        .div_frame {
            /*width: 100%;
    height: 90%;*/
            width: 250px;
            Height: 355px;
            float: left;
            text-align: center;
            /*overflow-y:scroll;*/
        }

        .div_lbl_vslvoy {
            width: 15%;
            float: left;
            margin-top: 0.5%;
            margin-right: 1%;
        }

        .div_txt_vslvoy {
            width: 98%;
            float: left;
            margin-top: 0.5%;
            margin-right: 1%;
            margin-left: 1%;
        }

            .div_txt_vslvoy input {
                width: 100%;
            }

        .div_lbl_eta {
            width: 15%;
            float: left;
            margin-top: 0.5%;
            margin-right: 1%;
        }

        .div_txt_eta {
            width: 26%;
            float: left;
            margin-top: 0.5%;
            margin-left: 1%;
        }

            .div_txt_eta input {
                width: 100%;
            }

        .div_lbl_etb {
            width: 5%;
            float: left;
            margin-top: 0.5%;
            margin-left: 1%;
        }

        .div_txt_etb {
            width: 15%;
            float: left;
            margin-top: 0.5%;
            margin-left: 1%;
        }

            .div_txt_etb input {
                width: 100%;
            }

        .div_ddl_hblno {
            width: 55%;
            float: left;
            margin-top: 0.5%;
            margin-right: 1%;
            margin-left: 1%;
        }

            .div_ddl_hblno select {
                width: 100%;
            }

        .div_txt_agent {
            width: 98%;
            float: left;
            margin-top: 0.5%;
            margin-right: 1%;
            margin-left: 1%;
        }

            .div_txt_agent input {
                width: 100%;
            }

        .div_txt_line {
            width: 98%;
            float: left;
            margin-top: 0.5%;
            margin-right: 1%;
            margin-left: 1%;
        }

            .div_txt_line input {
                width: 100%;
            }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 32px;
            padding: 2px 2px 2px 5px;
            width: 100%;
        }

            .BandTop img {
                padding: 2px 4px 0px 5px;
            }

            .BandTop h3 {
                color: #ffffff;
                padding: 2px 5px 2px 5px;
                margin: 0px 0px 0px 0px;
            }

                .BandTop h3 a {
                    color: #ffffff;
                    font-size: 11px;
                    font-family: sans-serif;
                    padding: 2px 5px 2px 0px;
                    margin: 0px 0px 0px 0px;
                }

        .BandLeft {
            float: left;
            width: 50%;
        }

        .BandRight {
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .linkfinal {
            margin-right: 1%;
            margin-top: 1%;
        }

        .TitleLeft1 {
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TitleLeft2 {
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PendingTblUC3 {
            float: left;
            margin: 5px 0 0 10px;
            height: 394px;
            overflow: auto;
            width: 721px;
        }

        .GridHeightN1 {
            border: 0px solid #b1b1b1;
        }

        .TableGrid {
            width: 100%;
            float: left;
            height: 360px;
            padding: 0px 0px 0px 10px;
            margin: 5px 0px 0px 0px;
            overflow: auto;
        }

        .SalesTitleBooking {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 0px 0 0;
            padding: 0 5px 0px 0;
            width: 250px;
        }

        .GrdAltRow {
            background-color: #cee9fd;
            color: Black;
            font-family: sans-serif;
            font-size: 8pt;
            margin-bottom: 0;
            margin-left: 4px;
        }

        .col-md-12 {
            padding-left: 10px !important;
        }

        .PendingTblGrid th {
            text-align: left;
            color: #fff;
            font-size: 11px;
            font-family: sans-serif, Geneva, sans-serif;
            background-color: #003a65;
            padding: 5px 2px 5px 3px;
            margin: 0px;
        }

        .SalesTitlePerN1 {
            font-size: 11px;
            font-family: sans-serif;
            color: var(--grey);
            width: 250px;
            float: left;
            font-weight: 600;
            margin: 10px 0px 0px 0px;
            padding: 0px 5px 0px 0px;
        }

        .SalesTitlePerP1 {
            font-size: 11px;
            font-family: sans-serif;
            margin: 4px 0px 0px 10px;
            padding: 0px 5px 0px 0px;
            color: var(--grey);
            width: 328px;
            font-weight: 600;
            float: left;
        }

        .SalesTitlePerC1 {
            font-size: 11px;
            font-family: sans-serif;
            margin: -24px 0px 0px 10px;
            padding: 0px 5px 0px 0px;
            color: var(--grey);
            width: 35%;
            font-weight: 600;
            float: left;
        }

        .MB13 {
            margin: -24px 0px 0px 0px;
        }

        .MBQ {
            margin-top: -5px;
        }

        .SalesTitlePerN2 {
            font-size: 11px;
            font-family: sans-serif;
            margin: 4px 0px 0px 0px;
            padding: 0px 5px 5px 0px;
            color: var(--grey);
            width: 250px;
            font-weight: 600;
            float: left;
        }

        .SalesTitlePreAlert {
            font-size: 11px;
            font-family: sans-serif;
            margin: -1px 0px 0px 0px;
            padding: 0px 5px 5px 0px;
            color: var(--grey);
            width: 250px;
            font-weight: 600;
            float: left;
        }

        .SalesTitlePre {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 0;
            padding: 0 5px 0px 0;
            font-weight: 600;
            width: 250px;
        }
        div#logix_CPH_Quotations {
    margin: 15px 0 3px;
}
        .Unclosed2 h3 {
            font-size: 11px;
            font-family: sans-serif;
            margin: 3px 0px 5px 0px;
            padding: 0px 5px 2px 0px;
            color: var(--grey);
            width: 250px;
            float: left;
            font-weight: 600;
        }

        .PendingTbl3 {
            width: 185px;
            float: left;
            margin: 5px 0px 0px 10px;
            max-height: 395px;
            overflow: auto;
        }

        .FinalGrid {
            height: 337px;
            overflow: auto;
            margin: 15px 0px 0px 0px;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            width: 635px !important;
            height: 190px;
            margin-left: -6%;
            margin-top: 6.1%;
            position: absolute;
            z-index: 999999;
        }

        .modalPopupss1 {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            width: 635px !important;
            height: 190px;
            margin-left: -5%;
            margin-top: 2.1%;
            position: absolute;
            z-index: 999999;
        }

        .MBCL {
            margin-top: -5px !important;
        }

        .MBCan {
            margin-top: -5px;
        }

        .MBBooking {
            margin-top: -5px;
        }

        .QuotImg1 {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .QuotTxt1 {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .BookingImg1 {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .BookingTxt1 {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .PreAlertImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .PreAlertTxt1 {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .CanImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .CanTxt1 {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .ReminderImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .ReminderTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .FinalNotice {
            float: left;
            width: 56%;
            margin: 2px 0px 0px 5px;
        }

        .ReminderNotice {
            float: right;
            width: 41%;
            margin: -25px 0px 0px;
        }

        .PendingImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .PendingTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .CargoImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .CargoTxt {
            width: 128px;
            float: left;
            margin: 8px 0px 0px 0px;
        }

        .GridpnlexN1 {
            height: 255px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        .Unclosed2 {
            float: right;
            margin: 5px 0px 0px 0px;
            width: 17%;
        }

        .ReminderHead {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 2px 0px 0px 0px;
            padding: 0 5px 0px 0;
            width: 250px;
            position: absolute;
            z-index: 9999999;
        }

        .FinalHead {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 4px 0px 0px 10px;
            padding: 0 5px 5px 0;
            width: 250px;
            z-index: 999999;
            position: absolute;
        }

        div#UpdatePanel1 {
            height: fit-content;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .BlueOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 8px;
        }

            .BlueOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .BlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #4e73df !important;
        }

        .BlueRightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 5px 10px 0px 0px;
            float: right;
            text-align: right;
            width: 75%;
            font-size: 22px;
        }

        .GreenOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .GreenOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .GreenText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 35px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDown {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
        }

        .LiteBlueOuter {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .LiteBlueOuter:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .LiteBlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 35px 15px;
            float: left;
            color: #36b9cc !important;
        }

        .LtBlueRightSideDown {
            color: #36b9cc !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
        }

        .YellowOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #f6c23e !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .YellowOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .YellowText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 35px 15px;
            float: left;
            color: #f6c23e !important;
        }

        .YellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
            /*transform: rotate(-179deg);*/
        }

        .GreenOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .GreenOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .GreenText2 {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 12px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDown2 {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            float: right;
            font-family: 'OpenSansSemibold';
            font-size: 22px;
            width: 75%;
            text-align: right;
        }

        .BlueOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .BlueOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .Blue2Text {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 35px 15px;
            float: left;
            color: #4e73df !important;
        }

        .Blue2RightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 0px 10px 0px 0px;
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
        }

        .RedOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #e74a3b !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .RedOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .RedText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 35px 15px;
            float: left;
            color: #e74a3b !important;
        }

        .RedRightSideDown {
            color: #e74a3b !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
        }

        .LeftSideValue {
            float: left;
            width: 60px;
            font-family: 'OpenSansRegular';
            margin: 5px 0px 0px 15px;
            font-size: 11px;
            color: #4e73df !important;
        }

        .RightSideValue {
            float: right;
            width: 80px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            margin: 5px 3px 0px 0px;
            color: #4e73df !important;
        }

        .LeftNumValue {
            color: #4e73df !important;
            margin: 10px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 25px;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue {
            color: #4e73df !important;
            margin: 10px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 25px;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }

        .LeftSideValue2 {
            float: left;
            width: 99px;
            font-family: 'OpenSansRegular';
            margin: 5px 0px 0px 12px;
            font-size: 11px;
            color: #1cc88a !important;
        }

        .RightSideValue2 {
            float: right;
            width: 66px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            margin: 5px 3px 0px 0px;
            color: #1cc88a !important;
        }

        .LeftNumValue2 {
            color: #1cc88a !important;
            margin: 12px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 22px;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue2 {
            color: #1cc88a !important;
            margin: 12px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 22px;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }

        .widget.box .widget-content {
            padding: 10px;
            position: relative;
            display: block;
            top: -9px;
            left: 0px;
        }

        .TblScroll {
            height: 365px;
            width: 100%;
            border: 0px solid #003a65;
        }

        div#logix_CPH_pnlPortCountry1 {
            float: left;
        }

        div#logix_CPH_Panel5 {
            float: left;
            width: 59%;
            position: relative;
            top: -29px;
            margin-left: 5px !important;
        }

        a#logix_CPH_lnk_CustomerLbl {
            position: relative;
            top: -30px;
        }

        .FinalHead {
            margin: 21px 0 0 0px;
            top: 0px;
        }
        span#logix_CPH_Label1 {
    font-weight: 600!important;
}
        div#logix_CPH_BookingUpdates, div#logix_CPH_PreAlert1, div#logix_CPH_CAN {
            margin: 10px 0 0 3px;
        }

        .divRoated {
            /* height: 80vh !important; */
        }

        div#logix_CPH_CustomerLbl {
            margin: -15px 0 0 10px;
        }

        div#logix_CPH_Customer1 {
            margin: 12px 0px 0px 0px;
        }

        div#logix_CPH_CargoPickedUp {
            margin: 7px 0 0 0px;
        }

        .div_close {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            /* margin-left: 98%; */
            margin-top: -7%;
            /* margin-top: -7.5%; */
            border-radius: 90px 90px 90px 90px;
        }

        .DivSecPanel {
            margin: 0 !important;
        }

        .divRoated {
            height: 27vh !important;
            border: 2px solid #CCCCCC;
        }

        div#logix_CPH_pnl_rnotice {
            background: 0 !important;
            border: none !important;
            left: 315px !important;
        }

        .divRoated {
            height: 40vh !important;
            border: 2px solid #CCCCCC;
            overflow: visible !important;
            width: 46% !important;
        }

        .modalPopupss {
            width: 100% !important;
        }

        select#logix_CPH_txthbl {
            border: 1px solid var(--inputborder) !important;
            height: 36px;
            margin: 10px 0px 0px 0px;
        }

        .BandMiddle {
            width: 100%;
        }

        .divbtn1, .divbtn2, .divbtn3 {
            width: 100%;
        }

        .widget-content {
            background: none !important;
        }

        div#logix_CPH_PanelPendingEvent {
            border-bottom: none;
        }

        .custom-col.custom-mr-05 .title1 {
            font-size: 11px;
        }

        .custom-col.custom-mr-05 .title2 {
            font-size: 11px;
        }

        .HomeMenuContent {
            width: 85%;
            float: left;
            margin: -30px 0 0;
        }
        span#logix_CPH_lbl_hdr1 {
    position: relative;
    top: 10px;
    font-weight: 600!important;
}div#logix_CPH_FinalNotice1 {
    width: 100%!important;
    padding: 0;
    margin: 24px 0 0;
}
    </style>

    <style type="text/css">
        @media only screen and (max-width: 1280px) {

            .PendingTblUC3 {
                float: left;
                margin: 5px 0 0 10px;
                height: 394px;
                overflow: auto;
                width: 62%;
            }

            .CargoTxt {
                width: 70%;
                float: left;
                margin: 8px 0px 0px 0px;
            }

            .CustomerReminder h3 {
                font-size: 13px;
            }
        }
    </style>

    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />

    <%--TEST--%>

    <script type="text/javascript">

        function pageLoad() {
            //$(document).ready(function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            //});
        }

    </script>
    <script type="text/javascript">

        //window.onload = function ()
        function PieChart() {
            var l1 = $("#<%=hid_Cover.ClientID %>").html();
            var l2 = $("#<%=hid_Pre.ClientID %>").html();
            var l3 = $("#<%=hid_Can.ClientID %>").html();
            var l4 = $("#<%=hid_PA2Accs.ClientID %>").html();
            var l5 = $("#<%=hid_Cheque.ClientID %>").html();
            var l6 = $("#<%=hid_Line.ClientID %>").html();
            var l7 = $("#<%=hid_Destuffed.ClientID %>").html();
            var l8 = $("#<%=hid_DeVanning.ClientID %>").html();
            var l9 = $("#<%=hid_Refund.ClientID %>").html();
            var l10 = $("#<%=hid_cargiPickup.ClientID %>").html();
            var chart = new CanvasJS.Chart("chartContainer2",
            {
                title: {
                    text: ""
                },
                data: [
                {
                    type: "pie",
                    dataPoints: [
                        { y: l1 - 0, indexLabel: "Pending Update Booking Status" },
                        { y: l2 - 0, indexLabel: "Pending Pre-Alert" },
                        { y: l3 - 0, indexLabel: "Pending CAN" },
                        { y: l10 - 0, indexLabel: "Pending Cargo Picked up" }
                    ]
                }
                ]
            });

            chart.render();
        }

    </script>

    <noscript>
        Your browser does not support JavaScript!
    </noscript>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="Clear"></div>
    <div class="BandMiddle">
        <div class="BreadLabel" id="OptionDoc" runat="server">Customer Support - Ocean Imports</div>

    </div>
    <div class="BandTop">
        <div class="BandLeft">
            <div style="float: left; margin: 0px 0.5% 0px 0px;">

                <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png"><asp:LinkButton ID="link_button1" runat="server" Text="New CustomerRequest" OnClick="link_button1_Click"></asp:LinkButton></h3>
            </div>

            <div style="float: left; margin: 0px 0.5% 0px 0px;">

                <h3>
                    <img src="../Theme/assets/img/status_report.png"><asp:LinkButton ID="LinkButton1" runat="server" Text="Daily Status Reports" OnClick="LinkButton1_Click"></asp:LinkButton></h3>
            </div>
            <div style="float: left; width: 100px;">
                <h3>
                    <img src="../Theme/assets/img/costing.png"><asp:LinkButton ID="LinkButton8" runat="server" Text="Costing" OnClick="LinkButton8_Click"></asp:LinkButton>
                </h3>
            </div>
            <div style="float: left; width: 172px; margin: 0px 0.5% 0px 0px;">
                <h3>
                    <img src="../Theme/assets/img/events_ic.png" /><asp:LinkButton ID="Lnk_events" runat="server" Text="Events" OnClick="Lnk_events_Click"></asp:LinkButton></h3>
            </div>
        </div>
        <div class="BandRight">
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/job_ic.png">
                    <asp:LinkButton ID="lbl_jobclosing" runat="server" Text="Job Closing" OnClick="lbl_jobclosing_Click"></asp:LinkButton>
            </div>
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/customerprofile_ic.png"><asp:LinkButton ID="lbl_customerprofile" runat="server" Text="Customer Profile" OnClick="lbl_customerprofile_Click"></asp:LinkButton></h3>
            </div>
        </div>

    </div>
    <div class="HomeMenuBox custom-d-flex custom-mt-05">

        <asp:LinkButton ID="Quotation" runat="server" OnClick="Quotation_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Unapproved Quotations</span>
                    <span id="span_quotunapp" runat="server" class="Amount"></span>

                </div>
            </div>

        </asp:LinkButton>
        <asp:LinkButton ID="Quotation_app" runat="server">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Approved Quotations</span>
                    <span id="span_quotapp" runat="server" class=" Amount"></span>
                </div>
            </div>

        </asp:LinkButton>
        <asp:LinkButton ID="pendingupdatebookingstatus" runat="server" OnClick="pendingupdatebookingstatus_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Booking Updates</span>
                    <span id="span_bookstatus" runat="server" class=" Amount"></span>
                </div>
            </div>
        </asp:LinkButton>

        <asp:LinkButton ID="prealert" runat="server" OnClick="prealert_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Pre-Alert</span>
                    <span id="span_prealert" runat="server" class=" Amount"></span>
                </div>
            </div>
        </asp:LinkButton>

        <asp:LinkButton ID="pendingCAN" runat="server" OnClick="pendingCAN_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">CAN </span>
                    <span id="span_pendcan" runat="server" class=" Amount"></span>
                </div>
            </div>
        </asp:LinkButton>

                <asp:LinkButton ID="reminder" runat="server" OnClick="reminder_Click">
                     <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Reminder Notice </span>
                    <span id="spanreminder" runat="server" class=" Amount"></span>

                </div>
            </div>

                </asp:LinkButton>
                <asp:LinkButton ID="finalnotice" runat="server" OnClick="finalnotice_Click">
                     <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Final Notice </span>
                    <span id="spanfinal" runat="server" class=" Amount"></span>

                </div>
            </div>
                </asp:LinkButton>

        <asp:LinkButton ID="pendingDO" runat="server" OnClick="pendingDO_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Pending Do </span>
                    <span id="span_pendingdo" runat="server" class=" Amount"></span>
                </div>
            </div>

        </asp:LinkButton>

        <asp:LinkButton ID="pendingcargo" runat="server" OnClick="pendingcargo_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Cargo Pickedup</span>
                    <span id="span_cargo" runat="server" class=" Amount"></span>
                </div>
            </div>

        </asp:LinkButton>

    </div>

    <div class="HomeMenuContent">
        <div class="col-md-12  maindiv">
            <!-- Tabs-->
            <div class="widget box borderremove">
                <%-- <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                <div class="widget-content">
                    <div style="float: left; width: 82.5%; position: relative; top: -12px;">

                        <div class="LoginCompanyDropN1" style="display: none;">
                            <asp:DropDownList data-placeholder="Events" ID="ddlEvents" runat="server" TabIndex="1" CssClass="chzn-select form-control"
                                AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Pending Update Booking Status" Value="PA"></asp:ListItem>
                                <asp:ListItem Text="Pending Pre-Alert" Value="PS"></asp:ListItem>
                                <asp:ListItem Text="Pending CAN" Value="CI"></asp:ListItem>
                                <asp:ListItem Text="Pending Cargo Picked up" Value="PC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="right_btn" style="display: none;">

                            <div class="btn btn-acd1">

                                <asp:Button ID="btn_data" runat="server" Text="Data" OnClick="btn_data_Click" />
                            </div>
                            <div class="btn ico-save">
                                <asp:Button ID="btn_graph" runat="server" Text="Graph" OnClick="btn_graph_Click" />
                            </div>
                        </div>
                        <div class="div_Break"></div>
                        <asp:Panel ID="Panel3" runat="server" Visible="false" CssClass="panel_19" ScrollBars="Auto">
                            <asp:GridView ID="Gridbook" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                        <div class="SalesTitlePerN1" id="Quotations" runat="server" visible="false">Quotations</div>

                        <div class="right_btn">
                            <asp:LinkButton ID="lnk_Quotationsexp2exc" runat="server" OnClick="lnk_Quotationsexp2exc_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <div style="clear: both;"></div>
                        <asp:Panel ID="Panel4" runat="server" Visible="false" CssClass="panel_19" ScrollBars="Auto">
                            <asp:GridView ID="grdQuatotion" CssClass="PendingTblGrid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="grdQuatotion_SelectedIndexChanged" OnRowDataBound="grdQuatotion_RowDataBound" OnPreRender="grdQuatotion_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="S #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" Width="30px" />
                                        <HeaderStyle Wrap="true" Width="30px" />
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                        <div class="SalesTitlePerP1" id="Customer1" runat="server" visible="false">Pending Do</div>
                        <div class="left_btn">
                            <asp:LinkButton ID="link_pendingdo" runat="server" OnClick="link_pendingdo_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>
                        <div class="Clear"></div>
                        <asp:Panel ID="pnlPortCountry1" runat="server" Visible="false" CssClass="panel_19" Height="367px" Width="352px">
                            <asp:GridView ID="GrdPort1" CssClass="PendingTblGrid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrdPort1_RowDataBound" OnSelectedIndexChanged="GrdPort1_SelectedIndexChanged" OnPreRender="GrdPort1_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="SI" HeaderText="S#">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="20px" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" Width="20px" />
                                    </asp:BoundField>
                                    <%-- <asp:BoundField DataField="blno" HeaderText="BL #" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />--%>
                                    <%-- <asp:BoundField DataField="shipper" HeaderText="Customer" />--%>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                <asp:Label ID="shipperName" runat="server" Text='<%# Bind("shipper") %>' ToolTip='<%#Bind("shipper")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="180px" />
                                        <ItemStyle HorizontalAlign="Left" Width="180px" Wrap="false" />

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="counts" HeaderText="">
                                        <HeaderStyle HorizontalAlign="right" Wrap="true" Width="50px" />
                                        <ItemStyle HorizontalAlign="right" Wrap="true" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="shipperid" HeaderText="shipperid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                        <div class="SalesTitlePerC1" id="CustomerLbl" runat="server">Pending Do</div>
                        <div class="right_btn">
                            <asp:LinkButton ID="lnk_CustomerLbl" runat="server" OnClick="lnk_CustomerLbl_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="Panel5" runat="server" Visible="false" CssClass="panel_19">

                            <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
                                <Columns>
                                    <asp:BoundField DataField="SI" HeaderText="S#" />
                                    <asp:BoundField DataField="blno" HeaderText="BL #" />
                                    <asp:BoundField DataField="bldate" HeaderText="BL Date" />
                                    <asp:BoundField DataField="por" HeaderText="PoR" />
                                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                                    <asp:BoundField DataField="pod" HeaderText="PoD" />
                                    <asp:BoundField DataField="fd" HeaderText="PlD" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                        <div class="SalesTitleBooking" id="BookingUpdates" runat="server">Booking Updates</div>
                        <div class="right_btn ">
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <div class="SalesTitlePre" id="PreAlert1" runat="server" visible="true">Pre-Alert</div>
                        <div class="right_btn">
                            <asp:LinkButton ID="Link_prealert" runat="server" OnClick="Link_prealert_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <div class="SalesTitlePreAlert" id="CAN" runat="server">CAN</div>
                        <div class="right_btn ">
                            <asp:LinkButton ID="link_canexp2exc" runat="server" OnClick="link_canexp2exc_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <div class="SalesTitlePerN2" id="CargoPickedUp" runat="server">Cargo Pickedup</div>
                        <div class="right_btn">
                            <asp:LinkButton ID="link_cargo" runat="server" OnClick="link_cargo_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="Panel1" runat="server" CssClass="panel_19" Visible="false" ScrollBars="Auto">

                            <asp:GridView ID="Grd_Status" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="Grd_Status_RowDataBound" OnSelectedIndexChanged="Grd_Status_SelectedIndexChanged" OnPreRender="Grd_Status_PreRender">
                                <Columns>

                                    <asp:TemplateField HeaderText="S #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 20px">
                                                <asp:Label ID="lbl_Slno" runat="server" Text='<%# Bind("Slno") %>' ToolTip='<%# Bind("Slno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="20px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Booking #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 110px">
                                                <asp:Label ID="lbl_Booking" runat="server" Text='<%# Bind("Booking") %>' ToolTip='<%# Bind("Booking") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="41px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                <asp:Label ID="lbl_bookingdate" runat="server" Text='<%# Bind("bookingdate") %>' ToolTip='<%# Bind("bookingdate") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="40px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Job #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 35px">
                                                <asp:Label ID="lbl_Job" runat="server" Text='<%# Bind("Job") %>' ToolTip='<%# Bind("Job") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="BL #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                <asp:Label ID="lbl_BL" runat="server" Text='<%# Bind("BL") %>' ToolTip='<%# Bind("BL") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="65px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                <asp:Label ID="lbl_bldate" runat="server" Text='<%# Bind("Date") %>' ToolTip='<%# Bind("Date") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="126px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                <asp:Label ID="lbl_Customer" runat="server" Text='<%# Bind("Customer") %>' ToolTip='<%# Bind("Customer") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoR">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                <asp:Label ID="lbl_POR" runat="server" Text='<%# Bind("POR") %>' ToolTip='<%# Bind("POR") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoL">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                <asp:Label ID="lbl_POL" runat="server" Text='<%# Bind("POL") %>' ToolTip='<%# Bind("POL") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                <asp:Label ID="lbl_POD" runat="server" Text='<%# Bind("POD") %>' ToolTip='<%# Bind("POD") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="195px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PlD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                <asp:Label ID="lbl_PlD" runat="server" Text='<%# Bind("PlD") %>' ToolTip='<%# Bind("PlD") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="195px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                            <asp:GridView ID="Grd_Status1" CssClass="PendingTblGrid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="Grd_Status1_RowDataBound" OnSelectedIndexChanged="Grd_Status1_SelectedIndexChanged" OnPreRender="Grd_Status1_PreRender">

                                <Columns>

                                    <asp:TemplateField HeaderText="S #">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Slno" runat="server" Text='<%# Bind("Slno") %>' ToolTip='<%# Bind("Slno") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Booking #">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Booking" runat="server" Text='<%# Bind("Booking") %>' ToolTip='<%# Bind("Booking") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_bookingdate" runat="server" Text='<%# Bind("bookingdate") %>' ToolTip='<%# Bind("bookingdate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Customer" runat="server" Text='<%# Bind("Customer") %>' ToolTip='<%# Bind("Customer") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoR">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_POR" runat="server" Text='<%# Bind("POR") %>' ToolTip='<%# Bind("POR") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoL">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_POL" runat="server" Text='<%# Bind("POL") %>' ToolTip='<%# Bind("POL") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoD">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_POD" runat="server" Text='<%# Bind("POD") %>' ToolTip='<%# Bind("POD") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PlD">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PlD" runat="server" Text='<%# Bind("PlD") %>' ToolTip='<%# Bind("PlD") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                            <asp:GridView ID="GrdPendingCargo" CssClass="PendingTblGrid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPendingCargo_RowDataBound" OnSelectedIndexChanged="GrdPendingCargo_SelectedIndexChanged" OnPreRender="GrdPendingCargo_PreRender">
                                <Columns>

                                    <asp:TemplateField HeaderText="S #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 20px">
                                                <asp:Label ID="lbl_Slno" runat="server" Text='<%# Bind("Sno") %>' ToolTip='<%# Bind("Sno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="20px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Job #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                <asp:Label ID="lblJobno" runat="server" Text='<%# Bind("jobno") %>' ToolTip='<%# Bind("jobno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="41px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bl #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                <asp:Label ID="lblblno" runat="server" Text='<%# Bind("blno") %>' ToolTip='<%# Bind("blno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Consignee">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 220px">
                                                <asp:Label ID="lbl_consignee" runat="server" Text='<%# Bind("consignee") %>' ToolTip='<%# Bind("consignee") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="220px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Vessel">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="lbl_Vessel" runat="server" Text='<%# Bind("vessel") %>' ToolTip='<%# Bind("vessel") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="200px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cargopickup">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                <asp:Label ID="lbl_cargopickup" runat="server" Text='<%# Bind("cargopickup") %>' ToolTip='<%# Bind("cargopickup") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Do Date">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                <asp:Label ID="lbl_doissuedon" runat="server" Text='<%# Bind("doissuedon") %>' ToolTip='<%# Bind("doissuedon") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="left" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="consigneeid" HeaderText="consigID #" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server" Visible="true">
                            <div id="chartContainer2" style="width: 100%;"></div>
                        </asp:Panel>

                        <div id="Widhead" runat="server" visible="false">

                            <div class="ReminderHead">
                                <asp:Label ID="lbl_hdr1" runat="server" Text="Reminder Notice"></asp:Label>
                            </div>
                            <div class="right_btn ">
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Visible="true">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                </asp:LinkButton>

                                <div style="clear: both;"></div>
                            </div>
                            <div id="formgroup" runat="server" visible="false">
                                <div class="FormGroupContent4">
                                    <asp:Panel ID="paneremin" CssClass="panel_19" runat="server">
                                        <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" CssClass="Grid FixedHeader"
                                            PageSize="10" AllowPaging="false" OnPageIndexChanging="grd_job_PageIndexChanging" OnRowDataBound="grd_job_RowDataBound" OnSelectedIndexChanged="grd_job_SelectedIndexChanged" OnPreRender="grd_job_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" Width="50px" />
                                                    <HeaderStyle Wrap="true" Width="50px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Job">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                            <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="52px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Vessel">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                                            <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Agent">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                                            <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="MLO">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                                            <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ETA">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 85px">
                                                            <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ETB">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                            <asp:Label ID="ETB" runat="server" Text='<%# Bind("etb") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POL">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                            <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Can Date">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                            <asp:Label ID="candate" runat="server" Text='<%# Bind("candate") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="71px" HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Arrow" CommandName="select"
                                    Font-Underline="false">⇛</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                                            </Columns>
                                            <%--  <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
                <RowStyle CssClass="GridviewScrollItem" /> 
                <PagerStyle CssClass="GridviewScrollPager" />
                <AlternatingRowStyle CssClass="GrdAltRow"/>--%>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                                <div class="FormGroupContent">

                                    <ajax:ModalPopupExtender ID="Mdl_rnotice" runat="server" CancelControlID="btn_cancel" TargetControlID="Label2" BackgroundCssClass=""
                                        PopupControlID="pnl_rnotice">
                                    </ajax:ModalPopupExtender>

                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hf_mdl" runat="server" />
                                    <asp:HiddenField ID="hf_grdjob_index" runat="server" />
                                    <asp:HiddenField ID="hf_jobno" runat="server" />
                                </div>
                            </div>
                        </div>

                        <%-- POPUP --%>
                        <asp:Panel ID="pnl_rnotice" runat="server" Width="100%" CssClass="modalPopup" Style="display: none;">
                            <div class="div_close hide">
                                <asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="divRoated">
                                <div class="div_Grd1">
                                    <div class="div_total1">
                                        <div class="Header1">
                                            <asp:Label ID="lbl_hdr" runat="server" Text="Reminder Notice" CssClass="lbl_Header"></asp:Label>
                                        </div>
                                        <div class="div_Break"></div>
                                        <%--<div class="div_lbl_vslvoy"><asp:Label ID="lbl_vslvoy" runat="server" Text="Vessel&Voy" CssClass="LabelValue"></asp:Label></div>--%>
                                        <div class="div_txt_vslvoy">
                                            <asp:TextBox ID="txt_vslvoy" runat="server" placeholder="Vessel&Voy" ToolTip="Vessel&Voy" CssClass="Text"></asp:TextBox>
                                        </div>
                                        <div class="div_Break"></div>
                                        <%--<div class="div_lbl_eta"><asp:Label ID="lbl_eta" runat="server" Text="ETA" CssClass="LabelValue"></asp:Label></div>--%>
                                        <div class="div_txt_eta">
                                            <asp:TextBox ID="txt_eta" runat="server" placeholder="ETA" ToolTip="ETA" CssClass="Text"></asp:TextBox>
                                        </div>
                                        <%--<div class="div_lbl_etb"><asp:Label ID="lbl_etb" runat="server" Text="ETB" CssClass="LabelValue"></asp:Label></div>--%>
                                        <div class="div_txt_etb">
                                            <asp:TextBox ID="txt_etb" runat="server" ToolTip="ETB" placeholder="ETB" CssClass="Text"></asp:TextBox>
                                        </div>
                                        <div class="div_ddl_hblno">
                                            <asp:DropDownList ID="ddl_hblno" runat="server" ToolTip="HBL#" Data-placeholder="HBL NUMBER" CssClass="Text">
                                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="div_Break"></div>
                                        <%--<div class="div_lbl_agent"><asp:Label ID="lbl_agent" runat="server" Text="Agent" CssClass="LabelValue"></asp:Label></div>--%>
                                        <div class="div_txt_agent">
                                            <asp:TextBox ID="txt_agent" runat="server" ToolTip="Agent" placeholder="Agent" CssClass="Text"></asp:TextBox>
                                        </div>
                                        <div class="div_Break"></div>
                                        <%--<div class="div_lbl_line"><asp:Label ID="lbl_line" runat="server" Text="Line" CssClass="LabelValue"></asp:Label></div>--%>
                                        <div class="div_txt_line">
                                            <asp:TextBox ID="txt_line" runat="server" ToolTip="Line" placeholder="Line" CssClass="Text"></asp:TextBox>
                                        </div>
                                        <div class="div_Break"></div>
                                        <%--<div class="div_lbl_hblno"><asp:Label ID="lbl_hblno" runat="server" Text="HBL#" CssClass="LabelValue"></asp:Label></div>--%>

                                        <div class="div_Break"></div>
                                        <div class="right_btn">
                                            <div class="btn btn-acd1">
                                                <asp:Button ID="btn_forwarder" runat="server" Text="Forwarder" OnClick="btn_forwarder_Click" />
                                            </div>
                                            <div class="btn ico-view">
                                                <asp:Button ID="btn_cnsg" runat="server" Text="Consignee" OnClick="btn_cnsg_Click" />
                                            </div>
                                            <div class="btn ico-cancel">
                                                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" />
                                            </div>
                                        </div>
                                        <div class="div_Break"></div>
                                    </div>
                                </div>

                            </div>
                        </asp:Panel>
                        <%-- EndPopup --%>

                        <div id="FinalNotice2" runat="server">
                            <div class="FinalHead">

                                <asp:Label ID="Label1" runat="server" Text="Final Notice"></asp:Label>

                            </div>
                            <div class="widget-content" id="FinalNotice1" runat="server">
                                <div class="FormGroupContent4">
                                    <asp:Panel ID="FinalNoticeGrid" runat="server" CssClass="panel_19 MB0">
                                        <asp:GridView ID="Gridfinal" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" AllowPaging="false" EmptyDataText="No Record Found"
                                            PageSize="10" BackColor="White" OnPageIndexChanging="Gridfinal_PageIndexChanging" OnRowDataBound="Gridfinal_RowDataBound" OnSelectedIndexChanged="Gridfinal_SelectedIndexChanged" CssClass="Grid FixedHeader">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Job">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                            <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="52px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Vessel">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                            <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Agent">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                            <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="MLO">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                            <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ETA">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                            <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ETB">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                            <asp:Label ID="ETB" runat="server" Text='<%# Bind("etb") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POL">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                            <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="candate">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                            <asp:Label ID="candate" runat="server" Text='<%# Bind("candate") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <%--<HeaderStyle Wrap="true" width="71px" HorizontalAlign="Center"  />--%>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Arrow" CommandName="select"
                                        Font-Underline="false">⇛</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>--%>
                                            </Columns>
                                            <%-- <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
                <RowStyle CssClass="GridviewScrollItem" /> 
                <PagerStyle CssClass="GridviewScrollPager" />
                <AlternatingRowStyle CssClass="GrdAltRow"/>--%>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>

                                <%-- POPUP --%>
                                <asp:Panel ID="Panel6" runat="server" Width="100%" CssClass="modalPopup">
                                    <%--<div class="div_close"><asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" width="100%" Height="100%" ImageUrl="~/images/close2.png"/></div>--%>
                                    <div class="divRoated">
                                        <div class="div_Break"></div>

                                        <div class="div_Grd2">
                                            <div class="div_total2">
                                                <div class="Header1">
                                                    <asp:Label ID="Label3" runat="server" Text="Final Notice" CssClass="lbl_Header"></asp:Label>
                                                </div>
                                                <div class="div_Break"></div>
                                                <%--<div class="div_lbl_vslvoy"><asp:Label ID="lbl_vslvoy" runat="server" Text="Vessel&Voy"  CssClass="LabelValue"></asp:Label></div>--%>
                                                <div class="div_txt_vslvoy">
                                                    <asp:TextBox ID="txt_vessel" runat="server" ToolTip="Vessel&Voy" placeholder="Vessel&Voy" CssClass="Text"></asp:TextBox>
                                                </div>
                                                <div class="div_Break"></div>
                                                <%--<div class="div_lbl_eta"><asp:Label ID="lbl_eta" runat="server" Text="ETA" CssClass="LabelValue"></asp:Label></div>--%>
                                                <div class="div_txt_eta">
                                                    <asp:TextBox ID="txteta" runat="server" CssClass="Text" ToolTip="ETA" placeholder="ETA"></asp:TextBox>
                                                </div>
                                                <%--<div class="div_lbl_etb"><asp:Label ID="lbl_etb" runat="server" Text="ETB" CssClass="LabelValue"></asp:Label></div>--%>
                                                <div class="div_txt_etb">
                                                    <asp:TextBox ID="txtetb" runat="server" CssClass="Text" ToolTip="ETB" placeholder="ETB"></asp:TextBox>
                                                </div>
                                                <div class="div_ddl_hblno">
                                                    <asp:DropDownList ID="txthbl" ToolTip="HBL Number" runat="server" data-placeholder="HBL#" CssClass="Text">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="div_Break"></div>
                                                <%--<div class="div_lbl_agent"><asp:Label ID="lbl_agent" runat="server" Text="Agent" CssClass="LabelValue"></asp:Label></div>--%>
                                                <div class="div_txt_agent">
                                                    <asp:TextBox ID="txtagent" runat="server" CssClass="Text" ToolTip="Agent" placeholder="Agent"></asp:TextBox>
                                                </div>
                                                <div class="div_Break"></div>
                                                <%--<div class="div_lbl_line"><asp:Label ID="lbl_line" runat="server" Text="Line" CssClass="LabelValue"></asp:Label></div>--%>
                                                <div class="div_txt_line">
                                                    <asp:TextBox ID="txtline" runat="server" CssClass="Text" ToolTip="Line" placeholder="Line"></asp:TextBox>
                                                </div>
                                                <div class="div_Break"></div>
                                                <%--<div class="div_lbl_hblno"><asp:Label ID="lbl_hblno" runat="server" Text="HBL#" CssClass="LabelValue"></asp:Label></div>--%>

                                                <div class="div_Break"></div>
                                                <div class="right_btn">
                                                    <div class="btn ico-cancel">
                                                        <asp:Button ID="btn_cancelfn" runat="server" Text="Cancel" Width="100%" />
                                                    </div>
                                                    <div class="btn ico-print">
                                                        <asp:Button ID="btn_print" runat="server" Text="Print" Width="100%" OnClick="btn_print_Click" />
                                                    </div>
                                                </div>

                                                <div class="div_Break"></div>
                                            </div>
                                        </div>

                                    </div>
                                </asp:Panel>

                                <div class="FormGroupContent4">
                                    <ajax:ModalPopupExtender ID="Mbl_popup" runat="server" CancelControlID="btn_cancelfn" TargetControlID="Label4" BackgroundCssClass="" PopupControlID="Panel6">
                                    </ajax:ModalPopupExtender>
                                    <asp:HiddenField ID="HiddenField3" runat="server" />

                                    <asp:Label ID="Label4" runat="server"></asp:Label>

                                    <div class="div_Break"></div>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="Unclosed2">
                        <h3>
                            <span>Events</span></h3>
                        <asp:Panel ID="PanelPendingEvent" runat="server" CssClass="relative " Visible="true">

                            <asp:GridView ID="GrdOceanExp1" CssClass="PendingTblGrid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdOceanExp1_RowDataBound"
                                OnSelectedIndexChanged="GrdOceanExp1_SelectedIndexChanged" Visible="false" OnPreRender="GrdOceanExp1_PreRender">
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>

                        <div class="div_Break"></div>

                        <%-- <div style="margin-top:0.5%"></div>--%>
                        <div class="divbtn1">
                            <asp:LinkButton ID="lnk_preform" runat="server" OnClick="lnk_preform_Click">Performance Tracking</asp:LinkButton>
                        </div>

                        <div class="divbtn2">
                            <asp:LinkButton ID="lnk_ship_query" runat="server" OnClick="lnk_ship_query_Click">Shipment Query</asp:LinkButton>
                        </div>

                        <div class="divbtn3">
                            <asp:LinkButton ID="lnk_preform_track" runat="server" OnClick="lnk_preform_track_Click">PerformanceTracking - Operations</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>

        </div>
        <!--END TABS-->

    </div>
    <div style="display: none;">
        <asp:Label ID="hid_Cover" runat="server" />
        <asp:Label ID="hid_Pre" runat="server" />
        <asp:Label ID="hid_Can" runat="server" />
        <asp:Label ID="hid_PA2Accs" runat="server" />
        <asp:Label ID="hid_Cheque" runat="server" />
        <asp:Label ID="hid_Line" runat="server" />
        <asp:Label ID="hid_Destuffed" runat="server" />
        <asp:Label ID="hid_DeVanning" runat="server" />
        <asp:Label ID="hid_Refund" runat="server" />
        <asp:Label ID="hid_cargiPickup" runat="server" />
        <asp:HiddenField ID="hid_value" runat="server" />

        <%-- <asp:Label ID="hidapprovalProOSdn" runat="server" />
            <asp:Label ID="hidapprovalOSDebit" runat="server" />
            <asp:Label ID="hidapprovalOScrdit" runat="server" />
            <asp:Label ID="hidapprovalProOtherDN" runat="server" />
            <asp:Label ID="hidapprovalProOtherCN" runat="server" />
            <asp:Label ID="hidapprovalOSCredit" runat="server" />
            <asp:Label ID="hidapprovalOtherDebitNotes" runat="server" />
            <asp:Label ID="hidapprovalOtherCreditNotes" runat="server" />--%>
    </div>

</asp:Content>
