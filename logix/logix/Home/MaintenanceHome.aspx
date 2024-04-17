<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MaintenanceHome.aspx.cs" Inherits="logix.Home.MaintenanceHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>

    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

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
            margin: 0 5px 0 -15px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        .divbtn1 {
            width: 160px;
            background-color: #2c60a1;
            text-align: center;
            float: left;
            margin: 10px 0.5% 0px 0px;
        }

            .divbtn1 a {
                display: inline-block;
                padding: 5px;
                font-size: 11px;
                color: #dce9f9;
                margin: 0px;
            }

        .divbtn2 {
            width: 160px;
            background-color: #0092fb;
            text-align: center;
            float: left;
            margin: 10px 0.5% 0px 0px;
        }

            .divbtn2 a {
                display: inline-block;
                color: #f5ffdf;
                font-size: 11px;
                padding: 5px;
                margin: 0px;
            }

        .divbtn3 {
            width: 160px;
            text-align: center;
            text-align: center;
            background-color: #883028;
            float: left;
            margin: 10px 0.5% 0px 0px;
        }

            .divbtn3 a {
                display: inline-block;
                color: #dfe1dd;
                font-size: 11px;
                padding: 5px;
                margin: 0px;
            }

        .divbtn4 {
            width: 160px;
            text-align: center;
            background-color: #501e4d;
            float: left;
            margin: 10px 0% 0px 0px;
        }

            .divbtn4 a {
                display: inline-block;
                color: #dfe1dd;
                font-size: 11px;
                padding: 5px;
                margin: 0px;
            }

        .BrderVisible {
            height: 429px;
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

        .Unclosed2 {
            float: right;
            width: 15%;
        }

        .BandMiddle {
            background-color: #98AFC7;
            float: left;
            min-height: 25px;
            padding: 2px 2px 2px 5px;
            margin: 0px 0px 0px 0px;
            width: 100%;
        }

        .BreadLabel {
            width: 15%;
            color: #ffffff;
            float: left;
            margin: 1px 0.5% 0px 21px;
            font-weight: normal;
            font-size: 11px;
        }

        .CusQuotation {
            width: 14.3%;
            min-height: 96px;
            background-color: #16365c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .CusQuotation span {
                display: inline-block;
                float: right;
                margin: 10px 10px 5px 0px;
                color: #fff;
                font-size: 20px;
            }

        .CusBooking span {
            display: inline-block;
            float: right;
            margin: 10px 10px 5px 0px;
            color: #fff;
            font-size: 20px;
        }

        .CusStuffing span {
            display: inline-block;
            float: right;
            margin: 10px 10px 5px 0px;
            color: #fff;
            font-size: 20px;
        }

        .CusSailing span {
            display: inline-block;
            float: right;
            margin: 10px 10px 5px 0px;
            color: #fff;
            font-size: 20px;
        }

        .CusTranship span {
            display: inline-block;
            float: right;
            margin: 10px 10px 5px 0px;
            color: #fff;
            font-size: 20px;
        }

        .CusDoconfirmationR span {
            display: inline-block;
            float: right;
            margin: 10px 10px 5px 0px;
            color: #fff;
            font-size: 20px;
        }

        .CusDOconri span {
            display: inline-block;
            float: right;
            margin: 10px 10px 5px 0px;
            color: #fff;
            font-size: 20px;
        }

        .CusBooking {
            width: 14.3%;
            min-height: 96px;
            background-color: #963634;
            margin: 0px 0px 0px 0px;
            float: left;
        }

        .CusStuffing {
            width: 14.3%;
            min-height: 96px;
            float: left;
            background-color: #8a933c;
            margin: 0px 0px 0px 0px;
        }

        .CusSailing {
            width: 14.3%;
            min-height: 96px;
            float: left;
            background-color: #60497a;
            margin: 0px 0px 0px 0px;
        }

        .CusTranship {
            width: 14.3%;
            min-height: 96px;
            float: left;
            background-color: #974706;
            margin: 0px 0px 0px 0px;
        }

        .CusDoconfirmationR {
            width: 14.3%;
            min-height: 96px;
            float: left;
            background-color: #215967;
            margin: 0px 0px 0px 0px;
        }

        .CusDOconri {
            width: 14.2%;
            min-height: 96px;
            float: left;
            background-color: #7b8d8e;
            margin: 0px 0px 0px 0px;
        }

        .CusQuotation h3 {
            color: #c5d9f1;
            padding: 7px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .CusBooking h3 {
            color: #f2dcdb;
            padding: 7px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .CusStuffing h3 {
            color: #ebf1de;
            padding: 7px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .CusSailing h3 {
            color: #e4dfec;
            padding: 7px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .CusTranship h3 {
            color: #fde9d9;
            padding: 7px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .CusDoconfirmationR h3 {
            color: #daeef3;
            padding: 7px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .CusDOconri h3 {
            color: #ecf7f8;
            padding: 7px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .QuotImg {
            float: left;
            width: 42px;
            margin: 9px 2px 0px 5px;
        }

        .BookingImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .StuffImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .SailingImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .TrashipImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .DocImg {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .DOCR1 {
            width: 42px;
            float: left;
            margin: 9px 2px 0px 5px;
        }

        .QuotTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .CusQuotation label.Approved {
            color: #ffffff;
            width: 65px;
            float: left;
            display: block;
            padding: 1px 0px 0px 0px;
            text-align: left;
            margin: 0px 0px 0px 10px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .CusQuotation label.Unapproved {
            color: #ffffff;
            display: block;
            width: 85px;
            float: right;
            padding: 1px 0px 0px 0px;
            text-align: left;
            margin: 0px 0px 0px 5px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .BookingTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .StuffTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .SailingTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .TranshipTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .DocTxt {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .DOCTxt1 {
            width: 132px;
            float: left;
            margin: 12px 0px 0px 0px;
        }

        .Gridpnlex {
            float: left;
            width: 100%;
            height: 400px;
            overflow: auto;
            margin-top: 0px;
        }

        .Gridpnlexcus {
            float: left;
            width: 100%;
            height: 348px;
            overflow-x: auto;
            overflow-y: hidden;
            margin-top: 0px;
        }

        .GridpnlexCha {
            float: left;
            width: 100%;
            height: 375px;
            overflow-y: hidden;
            overflow-x: auto;
            margin-top: 0px;
        }

        .LabelHead {
            color: #1373be;
            font-size: 14px;
            font-weight: bold;
            margin: 10px 0px 0px 0px;
            float: left;
        }

        .PendingTblGrid {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
        }

            .PendingTblGrid th {
                background-color: #003a65;
                color: #fff;
                font-family: sans-serif,Geneva,sans-serif;
                font-size: 11px;
                margin: 0;
                padding: 5px 5px 5px 5px;
                text-align: center;
            }

            .PendingTblGrid td {
                font-family: sans-serif, Geneva, sans-serif;
                font-size: 11px;
                color: #515151;
                border: 1px solid #b1b1b1;
                padding: 5px;
            }

        .GrdAltRow {
            background-color: #cee9fd;
            color: Black;
            font-family: sans-serif;
            font-size: 8pt;
            margin-bottom: 0;
            margin-left: 4px;
        }

        .MT5 {
            margin-bottom: 5px !important;
        }

        .CustomerGridHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .CustomerGridHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .CustomerGridHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 300px;
                overflow: auto;
            }

            .CustomerGridHeader th {
                min-width: 140px;
            }

            .CustomerGridHeader td {
                min-width: 140px;
            }

            .CustomerGridHeader th:nth-child(1) {
                min-width: 100px;
            }

            .CustomerGridHeader td:nth-child(1) {
                min-width: 100px;
            }

            .CustomerGridHeader th:nth-child(2) {
                min-width: 300px;
            }

            .CustomerGridHeader td:nth-child(2) {
                min-width: 300px;
            }

            .CustomerGridHeader th:nth-child(3) {
                min-width: 90px;
            }

            .CustomerGridHeader td:nth-child(3) {
                min-width: 90px;
            }

            .CustomerGridHeader th:nth-child(4) {
                min-width: 280px;
            }

            .CustomerGridHeader td:nth-child(4) {
                min-width: 280px;
            }

            .CustomerGridHeader th:nth-child(5) {
                min-width: 180px;
            }

            .CustomerGridHeader td:nth-child(5) {
                min-width: 180px;
            }

            .CustomerGridHeader th:nth-child(6) {
                min-width: 180px;
            }

            .CustomerGridHeader td:nth-child(6) {
                min-width: 180px;
            }

            .CustomerGridHeader th:nth-child(7) {
                min-width: 180px;
            }

            .CustomerGridHeader td:nth-child(7) {
                min-width: 180px;
            }

            .CustomerGridHeader th:nth-child(8) {
                min-width: 380px;
            }

            .CustomerGridHeader td:nth-child(8) {
                min-width: 380px;
            }

            .CustomerGridHeader th:nth-child(9) {
                min-width: 180px;
            }

            .CustomerGridHeader td:nth-child(9) {
                min-width: 180px;
            }

            .CustomerGridHeader th:nth-child(10) {
                min-width: 180px;
            }

            .CustomerGridHeader td:nth-child(10) {
                min-width: 180px;
            }

            .CustomerGridHeader th:nth-child(11) {
                min-width: 80px;
            }

            .CustomerGridHeader td:nth-child(11) {
                min-width: 80px;
            }

            .CustomerGridHeader th:nth-child(12) {
                min-width: 80px;
            }

            .CustomerGridHeader td:nth-child(12) {
                min-width: 80px;
            }

            .CustomerGridHeader th:nth-child(13) {
                min-width: 80px;
            }

            .CustomerGridHeader td:nth-child(13) {
                min-width: 80px;
            }

            .CustomerGridHeader th:nth-child(14) {
                min-width: 80px;
            }

            .CustomerGridHeader td:nth-child(14) {
                min-width: 80px;
            }

            .CustomerGridHeader th:nth-child(15) {
                min-width: 80px;
            }

            .CustomerGridHeader td:nth-child(15) {
                min-width: 80px;
            }

            .CustomerGridHeader th:nth-child(16) {
                min-width: 80px;
            }

            .CustomerGridHeader td:nth-child(16) {
                min-width: 80px;
            }

            .CustomerGridHeader th:nth-child(17) {
                min-width: 300px;
            }

            .CustomerGridHeader td:nth-child(17) {
                min-width: 280px;
            }

        tr.Pagination1 td table tbody {
            height: 45px !important;
        }

            tr.Pagination1 td table tbody td {
                min-width: 35px !important;
                padding: 0px !important;
                margin: 0px !important;
                text-align: center !important;
            }

        .ChargesGridHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .ChargesGridHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .ChargesGridHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 327px;
                overflow: auto;
            }

            .ChargesGridHeader th {
                min-width: 140px;
            }

            .ChargesGridHeader td {
                min-width: 140px;
            }

            .ChargesGridHeader th:nth-child(1) {
                min-width: 100px;
            }

            .ChargesGridHeader td:nth-child(1) {
                min-width: 100px;
            }

            .ChargesGridHeader th:nth-child(2) {
                min-width: 900px;
            }

            .ChargesGridHeader td:nth-child(2) {
                min-width: 900px;
            }

            .ChargesGridHeader th:nth-child(3) {
                min-width: 100px;
            }

            .ChargesGridHeader td:nth-child(3) {
                min-width: 100px;
            }

            .ChargesGridHeader th:nth-child(4) {
                min-width: 100px;
            }

            .ChargesGridHeader td:nth-child(4) {
                min-width: 100px;
            }

            .ChargesGridHeader th:nth-child(5) {
                min-width: 100px;
            }

            .ChargesGridHeader td:nth-child(5) {
                min-width: 100px;
            }

        .PortGridHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .PortGridHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .PortGridHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 327px;
                overflow: auto;
            }

            .PortGridHeader th {
                min-width: 140px;
            }

            .PortGridHeader td {
                min-width: 140px;
            }

            .PortGridHeader th:nth-child(1) {
                min-width: 50px;
            }

            .PortGridHeader td:nth-child(1) {
                min-width: 50px;
            }

            .PortGridHeader th:nth-child(2) {
                min-width: 250px;
            }

            .PortGridHeader td:nth-child(2) {
                min-width: 250px;
            }

            .PortGridHeader th:nth-child(3) {
                min-width: 100px;
            }

            .PortGridHeader td:nth-child(3) {
                min-width: 100px;
            }

            .PortGridHeader th:nth-child(4) {
                min-width: 250px;
            }

            .PortGridHeader td:nth-child(4) {
                min-width: 250px;
            }

            .PortGridHeader th:nth-child(5) {
                min-width: 250px;
            }

            .PortGridHeader td:nth-child(5) {
                min-width: 250px;
            }

            .PortGridHeader th:nth-child(6) {
                min-width: 250px;
            }

            .PortGridHeader td:nth-child(6) {
                min-width: 250px;
            }

            .PortGridHeader th:nth-child(7) {
                min-width: 150px;
            }

            .PortGridHeader td:nth-child(7) {
                min-width: 150px;
            }

        .GridExRateHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .GridExRateHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .GridExRateHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 352px;
                overflow: auto;
            }

            .GridExRateHeader th {
                min-width: 140px;
            }

            .GridExRateHeader td {
                min-width: 140px;
            }

            .GridExRateHeader th:nth-child(1) {
                min-width: 60px;
            }

            .GridExRateHeader td:nth-child(1) {
                min-width: 60px;
            }

            .GridExRateHeader th:nth-child(2) {
                min-width: 650px;
            }

            .GridExRateHeader td:nth-child(2) {
                min-width: 650px;
            }

            .GridExRateHeader th:nth-child(3) {
                min-width: 100px;
            }

            .GridExRateHeader td:nth-child(3) {
                min-width: 100px;
            }

            .GridExRateHeader th:nth-child(4) {
                min-width: 100px;
            }

            .GridExRateHeader td:nth-child(4) {
                min-width: 100px;
            }

            .GridExRateHeader th:nth-child(5) {
                min-width: 200px;
            }

            .GridExRateHeader td:nth-child(5) {
                min-width: 200px;
            }

            .GridExRateHeader th:nth-child(6) {
                min-width: 200px;
            }

            .GridExRateHeader td:nth-child(6) {
                min-width: 200px;
            }

        .GridVesselHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .GridVesselHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .GridVesselHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 327px;
                overflow: auto;
            }

            .GridVesselHeader th {
                min-width: 140px;
            }

            .GridVesselHeader td {
                min-width: 140px;
            }

            .GridVesselHeader th:nth-child(1) {
                min-width: 80px;
            }

            .GridVesselHeader td:nth-child(1) {
                min-width: 80px;
            }

            .GridVesselHeader th:nth-child(2) {
                min-width: 880px;
            }

            .GridVesselHeader td:nth-child(2) {
                min-width: 880px;
            }

            .GridVesselHeader th:nth-child(3) {
                min-width: 340px;
            }

            .GridVesselHeader td:nth-child(3) {
                min-width: 340px;
            }

        .GridLocationHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .GridLocationHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .GridLocationHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 327px;
                overflow-x: hidden;
                overflow-y: auto;
            }

            .GridLocationHeader th {
                min-width: 140px;
            }

            .GridLocationHeader td {
                min-width: 140px;
            }

            .GridLocationHeader th:nth-child(1) {
                min-width: 80px;
            }

            .GridLocationHeader td:nth-child(1) {
                min-width: 80px;
            }

            .GridLocationHeader th:nth-child(2) {
                min-width: 300px;
            }

            .GridLocationHeader td:nth-child(2) {
                min-width: 300px;
            }

            .GridLocationHeader th:nth-child(3) {
                min-width: 180px;
            }

            .GridLocationHeader td:nth-child(3) {
                min-width: 180px;
            }

            .GridLocationHeader th:nth-child(4) {
                min-width: 180px;
            }

            .GridLocationHeader td:nth-child(4) {
                min-width: 180px;
            }

            .GridLocationHeader th:nth-child(5) {
                min-width: 200px;
            }

            .GridLocationHeader td:nth-child(5) {
                min-width: 200px;
            }

            .GridLocationHeader th:nth-child(6) {
                min-width: 300px;
            }

            .GridLocationHeader td:nth-child(6) {
                min-width: 300px;
            }

            .GridLocationHeader th:nth-child(7) {
                min-width: 200px;
            }

            .GridLocationHeader td:nth-child(7) {
                min-width: 200px;
            }

            .GridLocationHeader th:nth-child(8) {
                min-width: 90px;
            }

            .GridLocationHeader td:nth-child(8) {
                min-width: 70px;
            }

        .EmpGridHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .EmpGridHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .EmpGridHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 327px;
                overflow-x: hidden;
                overflow-y: auto;
            }

            .EmpGridHeader th {
                min-width: 140px;
            }

            .EmpGridHeader td {
                min-width: 140px;
            }

            .EmpGridHeader th:nth-child(1) {
                min-width: 50px;
            }

            .EmpGridHeader td:nth-child(1) {
                min-width: 50px;
            }

            .EmpGridHeader th:nth-child(3) {
                min-width: 450px;
            }

            .EmpGridHeader td:nth-child(3) {
                min-width: 450px;
            }

            .EmpGridHeader th:nth-child(4) {
                min-width: 150px;
            }

            .EmpGridHeader td:nth-child(4) {
                min-width: 150px;
            }

            .EmpGridHeader th:nth-child(6) {
                min-width: 100px;
            }

            .EmpGridHeader td:nth-child(6) {
                min-width: 100px;
            }

            .EmpGridHeader th:nth-child(7) {
                min-width: 100px;
            }

            .EmpGridHeader td:nth-child(7) {
                min-width: 100px;
            }

            .EmpGridHeader th:nth-child(10) {
                min-width: 475px;
            }

            .EmpGridHeader td:nth-child(10) {
                min-width: 455px;
                text-align: left;
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
            margin: 5px 8px 0px 12px;
        }

            .BlueOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .BlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 30px 15px;
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

        .widget.box .widget-content {
            padding: 10px;
            position: relative;
            display: block;
            top: -9px;
            left: 0px;
        }

        .HomeMenuBox {
            width: 100%;
            float: left;
        }
        div#UpdatePanel1 {
    /* height: 92vh; */
    height: 100vh;
    overflow-x: hidden;
    overflow-y: hidden;
}
        /*.widget.box .widget-content {
            top: 5px !important;
        }*/

        /*Commented by Praveen 6June2023*/
        /*.HomeMenuBox {
            margin: -15px 0 0 !important;
        }*/


        .HomeMenuContent {
            margin: -15px 0 0 0px;
        }

       

        /*Modified by Praveen 6June2023*/
        .HomeMenuBox {
            height: 108vh !important;
        }
        div#UpdatePanel1 {
    overflow-x: hidden !important;
    overflow-y: hidden !important;
}

        .right_btn {
            float: right !important;
            margin: 7px 0 0 0 !important;
        }
        .HomeMenuContent {
    width: 87%;
    float: left;
}
        .gridpnl {
    height: calc(100vh - 65px);
}
        .HomeMenuBox {
    width: 13% !important;
}
        .PageHeight {
    padding-top: 0px;
}
    </style>
    <%--TEST--%>

    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />

    <%--TEST--%>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
    <noscript>
        Your browser does not support JavaScript!
    </noscript>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="maindiv">
    <div class="BandMiddle">
        <div class="BreadLabel" id="OptionDoc" runat="server">Maintenance</div>

    </div>
    <div class="BandTop" style="display: none;">
        <div style="display: none;">
            <div style="float: left; width: 136px; margin: 0px 0.5% 0px 0px;">
                <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png"><asp:LinkButton ID="link_button1" runat="server" Text="MasterCustomer" OnClick="link_button1_Click"></asp:LinkButton></h3>
            </div>
            <div style="float: left; width: 10%; margin: 0px 0.5% 0px 0px;">
                <h3>
                    <img src="../Theme/assets/img/costing.png"><asp:LinkButton ID="LinkButton8" runat="server" Text="Master Vessel" OnClick="LinkButton8_Click1"></asp:LinkButton>
                </h3>
            </div>

            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/job_ic.png">
                    <asp:LinkButton ID="lbl_jobclosing" runat="server" Text="Master Port" OnClick="LinkButton8_Click"></asp:LinkButton>
            </div>
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/ex_rate.png"><asp:LinkButton ID="lbl_customerprofile" runat="server" Text="Master Exrate" OnClick="lbl_customerprofile_Click"></asp:LinkButton></h3>
            </div>

        </div>

    </div>

    <div class="HomeMenuBox">

        <div class="menubox">
            <div class="menuboximage">
                <img src="../Theme/assets/img/dashboard/customerlist.png" />
            </div>
            <div class="menuboxcontent">
                <asp:LinkButton ID="Quotation" runat="server" OnClick="Quotation_Click">
                <span class=" title">Customer</span>
                </asp:LinkButton>
                <asp:LinkButton ID="Lnt_custonmer" runat="server" OnClick="Lnt_custonmer_Click">
                    <span id="spcust" runat="server" class=" Amount"></span>
                </asp:LinkButton>
            </div>
        </div>

        <div class="menubox">
            <div class="menuboximage">
                <img src="../Theme/assets/img/dashboard/chargeslist.png" />
            </div>
            <div class="menuboxcontent">
                <asp:LinkButton ID="linkoust" runat="server" OnClick="linkoust_Click">
                  <span class=" title">Charges</span>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkcharges" runat="server" OnClick="lnkcharges_Click">
                    <span id="spcharge" runat="server" class=" Amount"></span>
                </asp:LinkButton>
            </div>
        </div>

        <div class="menubox">
            <div class="menuboximage">
                <img src="../Theme/assets/img/dashboard/portlist.png" />
            </div>
            <div class="menuboxcontent">

                <asp:LinkButton ID="Stuffingconfirmation" runat="server" OnClick="Stuffingconfirmation_Click">          <span class=" title">Port</span>
                </asp:LinkButton>

                <asp:LinkButton ID="lnkMasterPort" runat="server" OnClick="lnkMasterPort_Click">
                    <span id="spport1" runat="server" class=" Amount"></span>
                </asp:LinkButton>

            </div>
        </div>

        <div class="menubox">
            <div class="menuboximage">
                <img src="../Theme/assets/img/dashboard/exrates.png" />
            </div>
            <div class="menuboxcontent">
                <asp:LinkButton ID="sailingConfirmation" runat="server" OnClick="sailingConfirmation_Click">
                      <span class="title">Ex Rate</span>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkExrate" runat="server" OnClick="lnkExrate_Click">
                    <span id="spexrate1" runat="server" class=" Amount"></span>
                </asp:LinkButton>
            </div>
        </div>

        <div class="menubox">
            <div class="menuboximage">
                <img src="../Theme/assets/img/dashboard/vessellist.png" />
            </div>
            <div class="menuboxcontent">
                <asp:LinkButton ID="Transhipment" runat="server" OnClick="Transhipment_Click">                   
                    <span class="title">Vessel</span>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkMaster" runat="server" OnClick="lnkMaster_Click">
                    <span id="spaiirlinecode" runat="server" class=" Amount"></span>
                </asp:LinkButton>
            </div>
        </div>

        <div class="menubox hide">
            <div class="menuboximage">
                <img src="../Theme/assets/img/dashboard/userlist.png" />
            </div>
            <div class="menuboxcontent">
                <asp:LinkButton ID="DORequest" runat="server" OnClick="DORequest_Click">                    
                    <span class=" title">City / Location</span>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkCity" runat="server" OnClick="lnkCity_Click">
                    <span id="spcity" runat="server" class=" Amount"></span>
                </asp:LinkButton>
            </div>
        </div>

        <div class="menubox">
            <div class="menuboximage">
                <img src="../Theme/assets/img/dashboard/userlist.png" />
            </div>
            <div class="menuboxcontent">
                <asp:LinkButton ID="DoConfirmation" runat="server" OnClick="DoConfirmation_Click">
                   <span class="title">User</span>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkMasterEmployee" runat="server" OnClick="lnkMasterEmployee_Click">
                    <span id="spemp" runat="server" class=" Amount"></span>
                </asp:LinkButton>
            </div>
        </div>

    </div>

    <div class="HomeMenuContent">
        <div class="col-md-12  maindiv">

            <div class="widget box borderremove">
                <%-- <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                <div class="widget-content">

                    <div id="Divcustomerdetails" runat="server">

                        <div class="LabelHead">
                            <asp:Label Text="Customer" ID="Lblcustomer" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5">
                            <asp:LinkButton ID="linkexprcustomer" runat="server" OnClick="linkexprcustomer_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="Panelexrate" runat="server" CssClass="gridpnl MB0" Visible="true" Width="100%">
                            <asp:GridView ID="grdcustomer" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" AllowPaging="false" PageSize="10" OnPageIndexChanging="grdcustomer_PageIndexChanging" OnPreRender="grdcustomer_PreRender">
                                <%-- --%>
                                <Columns>
                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="CustomerName">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 240px">
                                                <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="180px" />
                                        <ItemStyle HorizontalAlign="Left" Width="180px" Wrap="false" />

                                    </asp:TemplateField>

                                    <asp:BoundField DataField="customertype" HeaderText="Type">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <%--  -- add all address--%>

                                    <asp:BoundField DataField="unit#" HeaderText="Unit#">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="door#" HeaderText="Door#">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BuildingName" HeaderText="BuildingName">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Street" HeaderText="Street">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="City" HeaderText="City">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Pincode" HeaderText="Pincode">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="District" HeaderText="District">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="countryname" HeaderText="CountryName">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <%--end --%>

                                    <%--<asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 240px">
                                                <asp:Label ID="address" runat="server" Text='<%# Bind("address") %>' ToolTip='<%#Bind("address")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="180px" />
                                        <ItemStyle HorizontalAlign="Left" Width="180px" Wrap="false" />

                                    </asp:TemplateField>--%>

                                    <%--<asp:BoundField DataField="address" HeaderText="Address">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="left" />
                                        </asp:BoundField>
                                    --%>
                                    <%-- <asp:BoundField DataField="City" HeaderText="City">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="left" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="LandLineno" HeaderText="LandLine #">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Mobileno" HeaderText="Mobile #">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EmailID" HeaderText="EmailID">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="panno" HeaderText="Pan #">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="gstin" HeaderText="GSTIN">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RCM" HeaderText="RCM">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnRegistered" HeaderText="Un REG">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="gstexemption" HeaderText="GST EXE">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sez" HeaderText="Sez">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Register" HeaderText="Register">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="tdspercentage" HeaderText="TDS %">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                    </asp:BoundField>
                                    <%--   <asp:BoundField DataField="ledgername" HeaderText="LeggerName">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                        </asp:BoundField>
                                    --%>

                                    <asp:TemplateField HeaderText="LegerName">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 240px">
                                                <asp:Label ID="ledgername" runat="server" Text='<%# Bind("ledgername") %>' ToolTip='<%#Bind("ledgername")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="180px" />
                                        <ItemStyle HorizontalAlign="Left" Width="180px" Wrap="false" />

                                    </asp:TemplateField>

                                    <%-- <asp:BoundField DataField="LiveorHold" HeaderText="Live/Hold">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                        </asp:BoundField>
                                    --%>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="Pagination1" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>

                    <div id="divemployee" runat="server">
                        <div class="LabelHead">
                            <asp:Label Text="Employee" ID="lblEmp" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5"  >
                            <asp:LinkButton ID="lnkexpemp" runat="server" OnClick="lnkexpemp_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="emp_pln" runat="server" CssClass="gridpnl MB0" Width="100%" >
                            <asp:GridView ID="grd_empcount" CssClass="Grid FixedHeader" runat="server" Visible="true" AutoGenerateColumns="false"
                                Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnPreRender="grd_empcount_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="empcode" HeaderText="empcode" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide"></asp:BoundField>
                                    <asp:BoundField DataField="empname" HeaderText="Empname">
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="username" HeaderText="UserName">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="employeeid" HeaderText="employeeid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="dob" HeaderText="DoB">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="doj" HeaderText="DoJ">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="doc" HeaderText="doc" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide"></asp:BoundField>

                                    <%-- <asp:BoundField DataField="phonehp" HeaderText="phonehp">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="120px" />
                                                <ItemStyle HorizontalAlign="right" Wrap="false" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="phoneres" HeaderText="phoneres">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="120px" />
                                                <ItemStyle HorizontalAlign="right" Wrap="false" Width="120px" />
                                            </asp:BoundField>--%>
                                    <asp:BoundField DataField="email" HeaderText="Email Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="offmailid" HeaderText="Email Id[Official]">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="right" Wrap="false" />
                                    </asp:BoundField>

                                    <%-- <asp:BoundField DataField="lastupdatedon" HeaderText="lastupdatedon">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="right" Wrap="false"  />
                                    </asp:BoundField>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>

                    </div>

                    <div id="divcharges" runat="server">

                        <div class="LabelHead">
                            <asp:Label Text="Charges" ID="Label1" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5">
                            <asp:LinkButton ID="lnkexpcharges" runat="server" OnClick="lnkexpcharges_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl MB0" Visible="true" Width="100%">

                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"
                                BorderStyle="None" ShowHeaderWhenEmpty="True" OnPreRender="grd_PreRender">
                                <Columns>

                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="chargename" HeaderText="Charges" />

                                    <asp:BoundField DataField="chargetype" HeaderText="Charge Type" DataFormatString="{0:#,##0.00}" Visible="false"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SACCode" HeaderText="SACCode" DataFormatString="{0:#,##0.00}"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GSTP" HeaderText="GST %" DataFormatString="{0:#,##0.00}"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div id="divport" runat="server">

                        <div class="LabelHead">
                            <asp:Label Text="Port" ID="Label2" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5">
                            <asp:LinkButton ID="lnkexpexcelport" runat="server" OnClick="lnkexpexcelport_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="Panel2" runat="server" CssClass="gridpnl MB0" Visible="true" Width="100%">

                            <asp:GridView CssClass="Grid FixedHeader" ID="grd1" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" OnPreRender="grd1_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="portname" HeaderText="Port">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="portcode" HeaderText="Port Code">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="portname" HeaderText="Port Name">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="districtname" HeaderText="District">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="statename" HeaderText="State">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="countryname" HeaderText="Country">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />

                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div id="divexrate" runat="server">

                        <div class="LabelHead">
                            <asp:Label Text="ExRate" ID="Label3" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5">
                            <asp:LinkButton ID="lnkexpexrate" runat="server" OnClick="lnkexpexrate_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>
                        <asp:Panel ID="Panel3" runat="server" CssClass="gridpnl MB0" Visible="true" Width="100%">

                            <asp:GridView ID="GridExrate" runat="server" AutoGenerateColumns="false" Height="100%" Width="100%" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" OnPreRender="GridExrate_PreRender">
                                <%-- OnPreRender="GridExrate_PreRender"--%>

                                <Columns>
                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="LocalExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="typecr" runat="server" Text='<%# Bind("extype") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField DataField="extype" HeaderText="ExType" Visible="false" />--%>
                                    <asp:BoundField DataField="extype1" HeaderText="Type" />
                                    <asp:BoundField DataField="exdate" HeaderText="ExDate" DataFormatString="{0:dd/MM/yyyy}" />

                                    <asp:BoundField DataField="excurr" HeaderText="ExCurrency"></asp:BoundField>

                                    <asp:TemplateField HeaderText="LocalExRate">
                                        <ItemTemplate>
                                            <%--<asp:Textbox id="Txt_LocalExRate" runat="server" CssClass="form-control"   Text='<%# Bind("LoExRate") %>'  />--%>
                                            <asp:Label ID="Txt_LocalExRate" runat="server" Text='<%# Bind("LoExRate") %>' />

                                        </ItemTemplate>
                                        <ItemStyle CssClass="TxtAlign1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OSExRate">
                                        <ItemTemplate>
                                            <%--   <asp:Textbox id="Txt_OSExRate" runat="server"  CssClass="form-control"   Text='<%# Bind("OsExRate") %>'/>--%>
                                            <asp:Label ID="Txt_OSExRate" runat="server" Text='<%# Bind("OsExRate") %>' />

                                        </ItemTemplate>
                                        <ItemStyle CssClass="TxtAlign1" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Old_LocalExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="old_LocalExRate" runat="server" CssClass="form-control" Visible="false" Text='<%# Bind("localexrate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Old_OSExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="old_OSExRate" runat="server" CssClass="form-control" Visible="false" Text='<%# Bind("osexRate1") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>

                        </asp:Panel>
                        <div class="Clear"></div>
                    </div>

                    <div id="divcityup" runat="server">

                        <div class="LabelHead">
                            <asp:Label Text="Locations" ID="Label4" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5">
                            <asp:LinkButton ID="lnkexploc" runat="server" OnClick="lnkexploc_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="Panel4" runat="server" CssClass="gridpnl MB0 " Visible="true" Width="100%">
                            <asp:GridView ID="grdloc" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" BorderStyle="None" ShowHeaderWhenEmpty="True" OnPreRender="grdloc_PreRender">
                                <Columns>

                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location Name">

                                        <ItemTemplate>
                                            <div class="wrap150">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Locationname") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="155" />
                                        <ItemStyle Font-Bold="False" HorizontalAlign="Justify" Width="155" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="portname" HeaderText="Port">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="portname" HeaderText="Port Name">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="districtname" HeaderText="District">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="statename" HeaderText="State">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="countryname" HeaderText="Country">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pincode" HeaderText="Pincode">
                                        <HeaderStyle Wrap="true" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Wrap="false" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>
                    </div>

                    <div id="divvessel1" runat="server">

                        <div class="LabelHead">
                            <asp:Label Text="Vessel" ID="Label5" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5">
                            <asp:LinkButton ID="lnkexpvessel" runat="server" OnClick="lnkexpvessel_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="Panel5" runat="server" CssClass="gridpnl MB0" Visible="true" Width="100%">

                            <asp:GridView CssClass="Grid FixedHeader" ID="grdvesss" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" OnPreRender="grdvesss_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="vesselname" HeaderText="Vessel">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="imocode" HeaderText="IMOCode" ItemStyle-HorizontalAlign="Right">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Right" />

                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />

                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div style="clear: both;"></div>

                </div>

            </div>
        </div>
    </div>
        </div>
</asp:Content>
