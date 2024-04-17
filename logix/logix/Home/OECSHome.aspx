<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="OECSHome.aspx.cs" Inherits="logix.Home.OECSHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">
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
            height: 566px !important;
            margin: 0 5px 0 -10px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        .divbtn1 {
            
            background-color: var(--tablerowcolor) !important;
            float: left;
            margin: 5px 0.5% 0px 0px;
            border: 1px solid  var(--inputborder);
            border-bottom: none;
           
        }

        .divbtn2 {
         
            background-color: #fff;
            float: left;
            margin: 0px 0.5% 0px 0px;
            border: 1px solid  var(--inputborder);
            border-top: 0px;
            border-bottom: none;
        }

        .divbtn3 {
          
            background-color: var(--tablerowcolor) !important;
            float: left;
            margin: 0px 0.5% 0px 0px;
            border: 1px solid  var(--inputborder);
            border-top: 0px;
            border-bottom: none;
        }

        .divbtn4 {
         
            background-color: #fff;
            float: left;
            margin: 0px 0.5% 0px 0px;
            border: 1px solid  var(--inputborder);
            border-top: 0px;
        }

          .divbtn1 a, .divbtn2 a, .divbtn3 a, .divbtn4 a {
    display: inline-block;
    padding: 5px;
    font-size: 11px!important;
    color: var(--grey) !important;
    margin: 0px;
    font-weight: normal!important;
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
            margin: 15px 5px 0px 56px;
        }

        .div_graph {
            float: left;
            margin: 15px 5px 0px 56px;
        }

        .BrderVisible {
            height: 381px;
            width: 100%;
            border: 1px solid #b1b1b1;
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
            width: 35%;
        }

        .BandRight {
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .PerformBox {
            width: 195px;
            min-height: 102px;
            background-color: #16365c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PerformBox h3 {
                color: #c5d9f1;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PerformBox img {
                text-align: center;
                margin: 0px 10px 0px 85px;
                float: right;
            }

            .PerformBox span {
                color: #c5d9f1;
                display: block;
                margin: 1px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .OutStandingBox {
            width: 195px;
            min-height: 91px;
            background-color: #963634;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .OutStandingBox h3 {
                color: #f2dcdb;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .OutStandingBox span {
                color: #f2dcdb;
                display: block;
                margin: 1px 10px 0px 0px;
                float: right;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .BookingBox {
            width: 195px;
            min-height: 102px;
            float: left;
            background-color: #8a933c;
            margin: 0px 0px 0px 0px;
        }

            .BookingBox h3 {
                color: #ebf1de;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .BookingBox span {
                color: #ebf1de;
                display: block;
                margin: 28px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .QuotationBox {
            width: 173px;
            min-height: 102px;
            float: left;
            background-color: #60497a;
            margin: 0px 0px 0px 0px;
        }

        .QuotationBox1 {
            width: 195px;
            min-height: 103px;
            float: left;
            background-color: #974706;
            margin: 0px 0px 0px 0px;
        }

            .QuotationBox1 h3 {
                color: #fde9d9;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

                .QuotationBox1 h3 label {
                    color: #ffffff;
                    display: block;
                    padding: 1px 0px 0px 0px;
                    text-align: left;
                    margin: 0px;
                    font-family: "Segoe UI";
                    font-size: 14px;
                    font-weight: normal;
                }

            .QuotationBox1 span {
                color: #fde9d9;
                display: block;
                margin: 27px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 5px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .CreditRequest {
            width: 194px;
            min-height: 103px;
            float: left;
            background-color: #215967;
            margin: 0px 0px 0px 0px;
        }

            .CreditRequest h3 {
                color: #daeef3;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .CreditRequest span {
                color: #daeef3;
                display: block;
                margin: 27px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 5px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .CreditExemptions {
            width: 197px;
            min-height: 103px;
            float: left;
            background-color: #7b8d8e;
            margin: 0px 0px 0px 0px;
        }

            .CreditExemptions h3 {
                color: #ecf7f8;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .CreditExemptions span {
                color: #ecf7f8;
                display: block;
                margin: 27px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 5px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .DOconfirmation {
            width: 194px;
            min-height: 103px;
            float: left;
            background-color: #c287eb;
            margin: 0px 0px 0px 0px;
        }

            .DOconfirmation h3 {
                color: #ecf7f8;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .DOconfirmation span {
                color: #ecf7f8;
                display: block;
                margin: 27px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 5px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .TblScroll {
            height: 380px;
            width: 100%;
            border: 0px solid #003a65;
        }

        .QuotationBox span.AppCount {
            color: #e4dfec;
            display: block;
            margin: 7px 0px 0px 15px;
            text-align: left;
            width: 35px;
            float: left;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .QuotationBox span.UnAppCount {
            color: #e4dfec;
            display: block;
            margin: 7px 33px 0px 0px;
            text-align: right;
            width: 35px;
            float: right;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .SalesTitlePerQ1 {
            font-size: 11px;
            font-family: sans-serif;
            margin: -9px 0px 0px -1px;
            padding: 0px 5px 5px 0px;
            color: var(--grey);
            width: 250px;
            float: left;
        }

        .SalesTitlePerQ2 {
            font-size: 11px;
            font-family: sans-serif;
            margin: -5px 0px 0px -1px;
            padding: 0px 5px 5px 0px;
            color: var(--grey);
            width: 250px;
            float: left;
        }

        .Unclosed2 h3 {
            font-size: 11px;
            font-family: sans-serif;
            margin: -5px 0px 0px -1px;
            padding: 0px 5px 14px 0px;
            color: var(--grey);
            float: left;
        }

        .PendingTblGrid th {
            text-align: center;
            color: #fff;
            font-size: 11px;
            font-family: sans-serif, Geneva, sans-serif;
            /*background-color: #003a65;*/
            background-color: var(--navbarcolor) !important;
            padding: 2px 5px !important;
            margin: 0px;
        }

        .GrdAltRow {
            background-color: #cee9fd;
            color: Black;
            font-family: sans-serif;
            font-size: 8pt;
            margin-bottom: 0;
            margin-left: 4px;
        }

        .MB13 {
            margin: -10px 4px 0px 0px !important;
        }

        .SailingImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .SailingTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .QuotImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .QuotTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .BookingImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .BookingTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .StuffImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .StuffTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .SailingImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .SailingTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .TrashipImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .TranshipTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .DocImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .DocTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .DOCR1 {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .DOCTxt1 {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .widget.box .widget-content {
            padding: 10px;
            position: relative;
            display: block;
            top: -9px;
            left: 0px;
            background: none;
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
            margin: 0px 0px 35px 15px;
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
            margin: 0px 0px 15px 15px;
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
            font-weight: bold;
            color: #4e73df !important;
        }

        .RightSideValue {
            float: right;
            width: 80px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
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

        .BrderVisible {
            height: 367px;
            width: 100%;
            border: 1px solid #b1b1b1;
        }

        .TblScroll {
            height: 365px;
            width: 100%;
            border: 0px solid #003a65;
        }

        .Unclosed2 {
            margin:0;
            float: right;
            width: 16% !important;
        }

        div#logix_CPH_QuoTitle {
            position: relative;
            top: 20px;
            font-weight:600;
        }

        .divbtn1, .divbtn2, .divbtn3, .divbtn4 {
            width: 100%;
            border-right: 0.5px solid var(--inputborder) !important;
        }

        div#logix_CPH_StuffConfir {
            margin: 10px 0 0 0;
            padding: 0;
        }

        div#logix_CPH_StuffConfir, div#logix_CPH_Div1, div#logix_CPH_Div5, div#logix_CPH_Div4, div#logix_CPH_Div3, div#logix_CPH_Div2 {
            margin: 10px 0 0 0;
            padding: 0;
            font-weight:600;
        }

        a#logix_CPH_lnk_confirmationex2ex {
            margin-bottom: 5px;
            display: inline-block;
        }

        .BandMiddle {
            width: 100%;
        }
.HomeMenuBox {
    width: 16%!important;
}
.HomeMenuContent {
    width: 84%;
    float: left;
    margin: -25px 0 0;
}
    </style>

    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <script type="text/javascript">

        //window.onload = function ()
        function PieChart() {
            var l1 = $("#<%=hidStuffing.ClientID %>").html();
            var l2 = $("#<%=hidloading.ClientID %>").html();
            var l3 = $("#<%=hidInvoice.ClientID %>").html();
            var l4 = $("#<%=hidPreAlert.ClientID %>").html();
            var l5 = $("#<%=hidDocsSentOn.ClientID %>").html();
            var l6 = $("#<%=hidTranShipment.ClientID %>").html();
            var l7 = $("#<%=hidDeliveryRequest.ClientID %>").html();
            var l8 = $("#<%=hidDeliveryStatus.ClientID %>").html();

            var chart = new CanvasJS.Chart("chartContainer2",
            {
                title: {
                    text: ""
                },
                data: [
                {
                    type: "pie",
                    dataPoints: [
                        { y: l1 - 0, indexLabel: "Stuffing Confirmation" },
                        { y: l2 - 0, indexLabel: "Sailing Confirmation" },
                        { y: l8 - 0, indexLabel: "DO Confirmation" },
                        { y: l6 - 0, indexLabel: "Transhipment Confirmation" },
                        { y: l7 - 0, indexLabel: "DO Confirmation Request" }
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
        <div class="BreadLabel" id="OptionDoc" runat="server">Customer Support - Ocean Exports</div>

    </div>
    <div class="BandTop">
        <div style="float: left; margin: 0px 0.5% 0px 0px;">
            <h3>
                <img src="../Theme/assets/img/newcustomer_ic.png" /><asp:LinkButton ID="link_button1" runat="server" Text="New CustomerRequest" OnClick="link_button1_Click"></asp:LinkButton></h3>
        </div>
        <div style="float: left; width: 100px;">
            <h3>
                <img src="../Theme/assets/img/costing.png" /><asp:LinkButton ID="LinkButton8" runat="server" Text="Costing" OnClick="LinkButton8_Click"></asp:LinkButton>
            </h3>
        </div>
        <div style="float: left; width: 172px; margin: 0px 0.5% 0px 0px;">
            <h3>
                <img src="../Theme/assets/img/events_ic.png" /><asp:LinkButton ID="Lnk_events" runat="server" Text="Events" OnClick="Lnk_events_Click"></asp:LinkButton></h3>
        </div>
        <div class="BandRight">
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/job_ic.png" />
                    <asp:LinkButton ID="lbl_jobclosing" runat="server" Text="Job Closing" OnClick="lbl_jobclosing_Click"></asp:LinkButton></h3>
            </div>
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/customerprofile_ic.png" /><asp:LinkButton ID="lbl_customerprofile" runat="server" Text="Customer Profile" OnClick="lbl_customerprofile_Click"></asp:LinkButton></h3>
            </div>
        </div>

    </div>
    <div class="HomeMenuBox ">

        <asp:LinkButton ID="Quotation" runat="server" OnClick="Quotation_Click1">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Unapproved Quotations</span>
                    <span id="span_quotunapp" runat="server" class=" Amount"></span>

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
        <asp:LinkButton ID="linkoust" runat="server" OnClick="linkoust_Click">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Booking </span>
                    <span id="lbl_outstanding" runat="server" class=" Amount"></span>
                </div>
            </div>

        </asp:LinkButton>

        <asp:LinkButton ID="Stuffingconfirmation" runat="server" OnClick="Stuffingconfirmation_Click">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Stuffing Confirmation</span>
                    <span id="span_stuff" runat="server" class=" Amount"></span>

                </div>
            </div>

        </asp:LinkButton>

        <%--     <a href="#">
                      <asp:LinkButton ID="lnkApproved" runat="server"  CssClass="AppLink">
                <div class="QuotationBox">
                    <h3>Quotations</h3>
                       
  <label class="Approved">Approved</label>

                         <label class="Unapproved">UnApproved</label>
                     <%--<asp:LinkButton ID="lnkUnapp" runat="server" OnClick="lnkUnapp_Click" CssClass="UnAppLink">
                             </asp:LinkButton>--%>
        <%--   <span id="span_quotapp" runat="server" class="AppCount"></span>
                    <span id="span_quotunapp" runat="server" class="UnAppCount"></span>
                    <div style="clear:both;"></div>
                </div>
                          
                     </asp:LinkButton>
            </a>--%>

        <asp:LinkButton ID="sailingConfirmation" runat="server" OnClick="sailingConfirmation_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/homeimg/testimage48.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Sailing  Confirmation</span>
                    <span id="span_sailcount" runat="server" class=" Amount"></span>
                </div>
            </div>
        </asp:LinkButton>

        <asp:LinkButton ID="Transhipment" runat="server" OnClick="Transhipment_Click">
             <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/homeimg/testimage48.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">T/S Confirmation</span>
                            <span id="span_transcount" runat="server" class=" Amount"></span>
                    </div>
                </div>
        </asp:LinkButton>

        <asp:LinkButton ID="DORequest" runat="server" OnClick="DORequest_Click">
             <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/homeimg/testimage48.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">DO Confirmation Request</span>
                        <span id="span_DOReq" runat="server" class=" Amount"></span>
                    </div>
                </div>

        </asp:LinkButton>
        <asp:LinkButton ID="DoConfirmation" runat="server" OnClick="DoConfirmation_Click">
             <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/homeimg/testimage48.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">DO Confirmation</span>
                        <span id="Span_DO" runat="server" class=" Amount"></span>
                    </div>
                </div>
        </asp:LinkButton>

    </div>
    <div class=" HomeMenuContent">
        <div class="col-md-12  maindiv">
            <!-- Tabs-->
            <div class="widget box">
                <%-- <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                <div class="widget-content">
                    <div style="float: left; width: 83.5%; position: relative; top: -13px;">

                        <%--<h3>  <span>Pending Status</span></h3>--%>
                        <div runat="server" class="LoginCompanyDropN1" id="dropdown">
                            <asp:DropDownList data-placeholder="Events" ID="ddlEvents" runat="server" TabIndex="1" CssClass="chzn-select form-control"
                                AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Stuffing Confirmation" Value="SC"></asp:ListItem>
                                <asp:ListItem Text="Sailing Confirmation" Value="LC"></asp:ListItem>
                                <asp:ListItem Text="DO Confirmation" Value="DO"></asp:ListItem>
                                <asp:ListItem Text="Transhipment Confirmation" Value="TS"></asp:ListItem>
                                <asp:ListItem Text="DO Confirmation Request" Value="DR"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="right_btn" id="btngraph" runat="server">

                            <div class="btn btn-acd1">
                                <asp:Button ID="btn_data" runat="server" ToolTip="Data" OnClick="btn_data_Click" />
                            </div>

                            <div class="btn ico-save">
                                <asp:Button ID="btn_graph" runat="server" ToolTip="Graph" OnClick="btn_graph_Click" />
                            </div>
                        </div>

                        <div class="div_Break"></div>
                        <div class="SalesTitlePerQ2" id="StuffConfir" runat="server">Stuffing Confirmation</div>
                        <div class="SalesTitlePerQ2" id="Div1" runat="server">Sailing Confirmation</div>
                        <div class="SalesTitlePerQ2" id="Div2" runat="server">DO Confirmation</div>
                        <div class="SalesTitlePerQ2" id="Div3" runat="server">Transhipment Confirmation</div>
                        <div class="SalesTitlePerQ2" id="Div4" runat="server">DO Confirmation Request</div>

                        <div class="right_btn ">
                            <asp:LinkButton ID="lnk_confirmationex2ex" runat="server" OnClick="lnk_confirmationex2ex_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>
                            <div style="clear: both;"></div>
                        </div>
                        <asp:Panel ID="panelser" runat="server" CssClass="panel_19" ScrollBars="Auto" Visible="false">
                            <asp:GridView ID="Grd_Status" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="Grd_Status_SelectedIndexChanged" OnRowDataBound="Grd_Status_RowDataBound" OnPreRender="Grd_Status_PreRender">
                                <Columns>
                                    <asp:BoundField
                                        DataField="Slno" HeaderText="S #">
                                        <ItemStyle Wrap="false" Width="30px" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:BoundField>
                                    <%-- <asp:TemplateField HeaderText="S #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 20px">
                                                    <asp:Label ID="lbl_Slno" runat="server" Text='<%# Bind("Slno") %>' ToolTip='<%# Bind("Slno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="160px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Booking #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 110px">
                                                <asp:Label ID="lbl_Booking" runat="server" Text='<%# Bind("Booking") %>' ToolTip='<%# Bind("Booking") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="41px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <%-- <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">--%>
                                            <asp:Label ID="lbl_bookingdate" runat="server" Text='<%# Bind("bookingdate") %>' ToolTip='<%# Bind("bookingdate") %>'></asp:Label>
                                            <%-- </div>--%>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="40px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Job #">
                                        <ItemTemplate>
                                            <%--<div style="overflow: hidden; text-overflow: ellipsis; width: 35px">--%>
                                            <asp:Label ID="lbl_Job" runat="server" Text='<%# Bind("Job") %>' ToolTip='<%# Bind("Job") %>'></asp:Label>
                                            <%--</div>--%>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="BL #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                <asp:Label ID="lbl_BL" runat="server" Text='<%# Bind("BL") %>' ToolTip='<%# Bind("BL") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="65px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <%--<div style="overflow: hidden; text-overflow: ellipsis; width: 70px">--%>
                                            <asp:Label ID="lbl_bldate" runat="server" Text='<%# Bind("bldate") %>' ToolTip='<%# Bind("bldate") %>'></asp:Label>
                                            <%-- </div>--%>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="lbl_Customer" runat="server" Text='<%# Bind("Customer") %>' ToolTip='<%# Bind("Customer") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="105" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="105" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoR">
                                        <ItemTemplate>
                                            <%-- <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">--%>
                                            <asp:Label ID="lbl_POR" runat="server" Text='<%# Bind("POR") %>' ToolTip='<%# Bind("POR") %>'></asp:Label>
                                            <%--</div>--%>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoL">
                                        <ItemTemplate>
                                            <%-- <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">--%>
                                            <asp:Label ID="lbl_POL" runat="server" Text='<%# Bind("POL") %>' ToolTip='<%# Bind("POL") %>'></asp:Label>
                                            <%-- </div>--%>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PoD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                                <asp:Label ID="lbl_POD" runat="server" Text='<%# Bind("POD") %>' ToolTip='<%# Bind("POD") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="100" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PlD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                                <asp:Label ID="lbl_PlD" runat="server" Text='<%# Bind("PlD") %>' ToolTip='<%# Bind("PlD") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false"  Width="100" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false"  Width="100" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>

                        <div class="SalesTitlePerQ1" id="QuoTitle" runat="server">Quotation</div>
                        <div class="right_btn">
                            <asp:LinkButton ID="lnk_QuoTitle" runat="server" OnClick="lnk_QuoTitle_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>
                            <div style="clear: both;"></div>
                       
                        <asp:Panel ID="Panel3" runat="server" Visible="false" CssClass="panel_19" ScrollBars="Auto">
                            <asp:GridView ID="grdQuatotion" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
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
                        <div class="SalesTitlePerQ1" id="Div5" runat="server">Booking</div>
                        <div class="right_btn">
                            <asp:LinkButton ID="lnk_Div5" runat="server" OnClick="lnk_Div5_Click">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>
                       
                        <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="panel_19" ScrollBars="Auto">
                            <asp:GridView ID="Gridbook" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnPreRender="Gridbook_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server" Visible="true">
                            <div id="chartContainer2" style="width: 100%;"></div>
                        </asp:Panel>
                    </div>

                    <div class="Unclosed2">
                        <h3>
                            <span>Events</span></h3>
                        <asp:Panel ID="PanelPendingEvent" runat="server" CssClass="relative" Visible="true">

                            <asp:GridView ID="Grd_Events" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%"
                                ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false"
                                OnRowDataBound="Grd_Events_RowDataBound" OnSelectedIndexChanged="Grd_Events_SelectedIndexChanged">
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>

                        <div class="div_Break"></div>
                        <div class="divbtn1">
                            <asp:LinkButton ID="lnk_preform" runat="server" OnClick="lnk_preform_Click">Performance Tracking</asp:LinkButton>
                        </div>
                        <div class="divbtn2">
                            <asp:LinkButton ID="lnk_event_track" runat="server" OnClick="lnk_event_track_Click">Event Tracking Job-wise</asp:LinkButton>
                        </div>
                        <div class="divbtn3">
                            <asp:LinkButton ID="lnk_ship_query" runat="server" OnClick="lnk_ship_query_Click">Shipment Query </asp:LinkButton>
                        </div>
                        <div class="divbtn4">
                            <asp:LinkButton ID="lnk_vessel_sch" runat="server" OnClick="lnk_vessel_sch_Click">Vessel Schedule</asp:LinkButton>
                        </div>

                    </div>

                </div>
            </div>

        </div>
        <!--END TABS-->

    </div>

    <div style="display: none;">

        <asp:Label ID="hidStuffing" runat="server" />
        <asp:Label ID="hidloading" runat="server" />

        <asp:Label ID="hidInvoice" runat="server" />
        <asp:Label ID="hidPreAlert" runat="server" />
        <asp:Label ID="hidDocsSentOn" runat="server" />
        <asp:Label ID="hidTranShipment" runat="server" />
        <asp:Label ID="hidDeliveryRequest" runat="server" />
        <asp:Label ID="hidDeliveryStatus" runat="server" />
        <asp:HiddenField ID="hid_stuffing" runat="server" />
        <%-- <asp:Label ID="hidapprovalProCNOp" runat="server" />
            <asp:Label ID="hidapprovalProOSdn" runat="server" />
            <asp:Label ID="hidapprovalOSDebit" runat="server" />
            <asp:Label ID="hidapprovalOScrdit" runat="server" />
            <asp:Label ID="hidapprovalProOtherDN" runat="server" />
            <asp:Label ID="hidapprovalProOtherCN" runat="server" />
            <asp:Label ID="hidapprovalOSCredit" runat="server" />
            <asp:Label ID="hidapprovalOtherDebitNotes" runat="server" />
            <asp:Label ID="hidapprovalOtherCreditNotes" runat="server" />
            <asp:Label ID="hidapprovalquo" runat="server" />
            <asp:Label ID="hidapprovalInvoices" runat="server" />
            <asp:Label ID="hidapprovalCNOp" runat="server" />--%>
    </div>

</asp:Content>
