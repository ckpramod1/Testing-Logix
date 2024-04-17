<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Branch_home.aspx.cs" Inherits="logix.Home.Branch_home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

      <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />

    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

<%--    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>--%>
    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <!-- App -->

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
        #Panel11 {
            top: 110px !important;
        }

        .hide {
            display: none;
        }

        div#Div_chart {
            display: none;
        }

        .menubox .title {
            font-size: 14px !important;
            width: 100%;
            display: inline-block;
            color: var(--labelblack);
            font-weight: 600;
        }

        .panel_09,
        .panel_13,
        .panel_19 {
            max-height: 80vh !important;
            min-height: 85vh !important;
        }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 32px;
            padding: 2px 2px 2px 5px;
            width: 100%;
        }

            .BandTop h3 a {
                color: #ffffff;
                font-family: sans-serif;
                font-size: 11px;
                margin: 0;
                padding: 2px 0;
            }

            .BandTop h3 {
                color: #ffffff;
                padding: 0px 5px 0px 5px;
                margin: 0px 0px 0px 0px;
            }

        /*.PaymentBox1 {
            float: left;
            width: 13%;
            margin: 0px 0px 0px 0px;
            min-height: 114px;
        }*/
        .PaymentBox1 {
            width: 14.28%;
            min-height: 117px;
            background-color: #16365c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox1 h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 3px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentBox1 span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: 30px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: normal;
            }

        #logix_CPH_pln_Trialbalance {
            left: -8px;
            top: 4px;
        }

        /*.PaymentBox2 {
            float: left;
            width: 13%;
            margin: 0px 0px 0px 0px;
            min-height: 114px;
        }*/

        .PaymentBox2 {
            width: 14.28%;
            min-height: 117px;
            background-color: #963634;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox2 h3 {
                color: #daeef3;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentBox2 span {
                color: #000000;
                display: block;
                float: right;
                margin: 30px 5px 0px 0px;
                text-align: right;
                padding: 0px 0px 9px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: normal;
            }

        .PaymentBox4 {
            float: left;
            width: 14.28%;
            margin: 0px 0px 0px 0px;
            min-height: 114px;
        }

        /*.PaymentBox5 {
            float: left;
            width: 13%;
            margin: 0px 0px 0px 0px;
            min-height: 114px;
        }*/

        /*.PaymentBox6 {
            float: left;
            width: 13%;
            margin: 0px 0px 0px 0px;
            min-height: 114px;
        }*/

        .BandMiddle {
            background-color: #98AFC7;
            float: left;
            min-height: 25px;
            padding: 2px 2px 2px 5px;
            margin: 0px 0px 0px 0px;
            width: 100%;
        }

        .Clear {
            clear: both;
        }

        .PaymentBox5 {
            width: 14.28%;
            min-height: 117px;
            background-color: #215967;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox5 h3 {
                color: #000000;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentBox5 span {
                color: #000000;
                display: block;
                float: right;
                margin: 42px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .CNOPS {
            width: 72px;
            float: left;
            margin: 5px 0px 0px 9px;
            color: #ecf7f8;
            font-size: 11px;
        }

        .CN {
            width: 46px;
            float: left;
            margin: 5px 0px 0px 0px;
            color: #ecf7f8;
            font-size: 11px;
        }

        .CNAdmin {
            width: 67px;
            float: right;
            text-align: right;
            margin: 5px 1px 0px 0px;
            color: #ecf7f8;
            font-size: 11px;
        }

        .CNopsCount1 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 10px;
        }

            .CNopsCount1 a {
                color: #ecf7f8 !important;
                font-size: 24px !important;
            }

        .CNopsCount2 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 10px;
            text-align: center;
        }

            .CNopsCount2 a {
                color: #ecf7f8 !important;
                font-size: 24px !important;
            }

        .CNopsCount3 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 14px;
            text-align: right;
        }

        .CNopsCount3s {
            float: left;
            width: 65px;
            margin: 5px 0px 0px 0px;
            text-align: right;
        }

            .CNopsCount3s a {
                color: #ecf7f8 !important;
                font-size: 24px !important;
            }

        .CNopsCount3 a {
            color: #ecf7f8 !important;
            font-size: 24px !important;
        }

        .CNopsCount4 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 10px;
            text-align: center;
        }

            .CNopsCount4 a {
                color: #000000 !important;
                font-size: 24px !important;
            }

        .PaymentBox7 {
            width: 14.3%;
            min-height: 117px;
            background-color: #60497a;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox7 h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentBox7 span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: 30px 0px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: normal;
            }

        .PaymentBox6 {
            width: 14.28%;
            min-height: 117px;
            background-color: #16365c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox6 h3 {
                color: #000000;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

        .OceanImports {
            margin: 5px 0px 0px 5px;
            width: 45px;
            float: left;
        }

        .OceanTxt {
            width: 103px;
            float: left;
            margin: 13px 0px 0px 0px;
        }

        .PaymentBox6 span {
            color: #000000;
            display: block;
            float: right;
            margin: 30px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: normal;
        }

        .PaymentBox3 {
            width: 14.28%;
            min-height: 117px;
            background-color: #8a933c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox3 h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentBox3 span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: 39px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .PaymentBox4 {
            width: 14.28%;
            min-height: 117px;
            background-color: #735360;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox4 h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentBox4 span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: 39px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 32px;
            padding: 2px 2px 2px 5px;
            width: 100%;
        }

            .BandTop h3 a {
                color: #ffffff;
                font-family: sans-serif;
                font-size: 11px;
                margin: 0;
                padding: 2px 0;
            }

            .BandTop h3 {
                color: #ffffff;
                padding: 0px 5px 0px 5px;
                margin: 0px 0px 0px 0px;
            }

        .OCEANEXPORT {
            width: 140px;
            float: left;
        }

        .OCEAMIMPORT {
            width: 140px;
            float: left;
        }

        .AIREXPORT {
            width: 120px;
            float: left;
        }

        .AIRIMPORT {
            width: 120px;
            float: left;
        }

        .CostSheet {
            width: 120px;
            float: left;
        }

        .CostSheet1 {
            width: 149px;
            float: left;
        }

        .CostSheet2 {
            width: 145px;
            float: left;
        }

        .PadCtrlN {
            padding: 10px 10px 10px 10px;
        }

        .PendingRightChequApUnclosed {
            float: left;
            width: 18%;
            margin: 11px 0px 0px 0px;
        }

        .PendingTbl2 {
            max-height: 350px;
            min-height: 350px;
        }

        .PendingRightnewLRightNew_Un {
            float: left;
            width: 86%;
            margin: 0px 0px 0px 10px;
        }

        .PendingRightnewLRightNew1 {
            float: left;
            width: 43%;
            background-color: var(--white);
            margin: 0px 0px 3px 10px;
            /* margin: -141px 0px 0px 0px; */
        }

        a#logix_CPH_lbtn_jobno {
            font-size: 11px;
            font-family: sans-serif;
        }

        .GridN1 {
            width: 100%;
            border: 0px solid #b1b1b1;
            height: 351px !important;
            margin: 3px 3px 3px 3px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

            .GridN1 th {
                background-color: #003a65 !important;
                border-right: 1px solid #edf8ff;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #ffffff !important;
                border-top: 1px solid #003a65;
            }

        .PendingTblGrid th {
            text-align: left;
            color: #ffffff;
            font-size: 11px;
            font-family: sans-serif, Geneva, sans-serif;
            background-color: #003a65;
            padding: 5px 2px 5px 3px;
            margin: 0px;
            border-right: 1px solid #edf8ff;
            border-top: 1px solid #003a65;
        }

            .PendingTblGrid th:last-child {
                border-right: 1px solid #003a65;
            }

        .PaymentBox3 h3 img {
            margin-right: 5px;
        }

        .SalesheadDetails {
            font-size: 11px;
            font-family: sans-serif;
            /*margin: 0px 0px -8px -24px;*/
            padding: 2px 5px 8px 0px;
            color: var(--grey);
            width: 188px;
            float: left;
        }

        .GridHead {
            font-size: 14px;
            font-family: sans-serif;
            margin: 0px 0px 0px 4px;
            padding: 0px 5px 5px 0px;
            color: var(--grey);
            width: 188px;
            float: left;
            font-weight: 500;
        }

        .widget.box .widget-content {
            display: block;
            float: left;
            left: 0;
            padding: 1px;
            position: relative;
            top: -2px;
            width: 100%;
        }

        .widget-content {
            padding: 5px;
        }

        .widget {
            margin-bottom: 0px;
        }

        div#Home_header {
            color: #fff;
            margin: 3px 0px 0px 24px;
        }

        .TblGrid th {
            background-color: #003a65;
            border-right: 1px solid #51789d;
            color: #ffffff;
            font-family: tahoma;
            font-size: 11px;
            padding: 2px 5px;
        }

        .GrdAltRow {
            background-color: #cee9fd;
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-left: 4px;
            margin-bottom: 0px;
        }

        .DptLink {
            float: right;
            margin: 0px 5px 0px 0px;
        }

            .DptLink a {
                text-decoration: none;
                font-size: 24px;
                color: #daeef3;
                display: inline-block;
                margin: 22px 0px 0px 0px;
            }

        .DateCal4 {
            width: 43%;
            float: right;
            margin: -21px 2.5% 3px 0px;
        }

        .OutstandingHead {
            float: left;
            width: 29%;
            margin: 0px 0px 0px 0px;
        }

        .right_btnN1 {
            float: right;
            margin: 0px -9px 4px 0px;
        }

        .UnclosedJobs2 h3 {
            color: #daeef3;
            padding: 4px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .UnclosedJobs2 span {
            color: #daeef3;
            display: block;
            margin: 31px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: normal;
        }

        .boxheight {
            height: 395px;
            overflow: auto;
        }

        .Hide {
            display: none;
        }

        .PaDtopCtrl {
            padding: 0px 0px 0px 0px !important;
        }

        .div_GridNew {
            height: 255px;
            overflow: auto;
            margin: 0px 5px 0px 5px;
            width: 99%;
            border: 1px solid #b1b1b1;
        }

        .div_GridNew1 {
            height: auto;
            overflow: auto;
            /* margin: 0px 5px 0px -24px; */
            width: 29%;
            float: left;
            background-color: var(--white);
        }

        #ddl_module_chzn {
            width: 100% !important;
        }

        .ModeDropCN3 {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 8px;
        }

        .PaymentBox5 h3 img {
            float: left;
            width: 42px;
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
            width: 93%;
            font-size: 20px !important;
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
            margin: 0px 0px 0px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDown {
            color: #1cc88a !important;
            margin: 8px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 20px !important;
            width: 93%;
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
            font-size: 20px !important;
            width: 93%;
            text-align: right;
        }

        .LiteBlueOuter1 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 5px 0px 0px;
        }

            .LiteBlueOuter1:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .LiteBlueText1 {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 35px 15px;
            float: left;
            color: #36b9cc !important;
        }

        .LtBlueRightSideDown1 {
            color: #36b9cc !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 20px;
            width: 93%;
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
            margin: 0px 0px 0px 11px;
            float: left;
            color: #f6c23e !important;
        }

        .YellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 20px !important;
            width: 93%;
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
            font-size: 13px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 10px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDown2 {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            float: right;
            font-family: 'OpenSansSemibold';
            font-size: 22px;
            width: 93%;
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
            font-size: 20px !important;
            width: 93%;
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
            font-size: 20px !important;
            width: 93%;
            text-align: right;
        }

        .PageHeight {
            background-color: #f8f9fc !important;
        }

        .Counttext1 {
            width: 29%;
            font-size: 11px;
            font-family: 'OpenSansSemibold';
            margin: 5px 0px 0px 10px;
            float: left;
            color: #f6c23e !important;
        }

        .Counttext2 {
            width: 28%;
            font-size: 11px;
            font-family: 'OpenSansSemibold';
            margin: 5px 0px 0px 0px;
            float: left;
            color: #f6c23e !important;
        }

        .Counttext3 {
            width: 36%;
            font-size: 11px;
            font-family: 'OpenSansSemibold';
            margin: 5px 0px 0px 0px;
            float: left;
            color: #f6c23e !important;
        }

        .Counttext1_1 {
            width: 29%;
            font-size: 11px;
            font-family: 'OpenSansSemibold';
            margin: 5px 0px 0px 10px;
            float: left;
            color: #1cc88a !important;
        }

        .Counttext2_1 {
            width: 28%;
            font-size: 11px;
            font-family: 'OpenSansSemibold';
            margin: 5px 0px 0px 0px;
            float: left;
            color: #1cc88a !important;
        }

        .Counttext3_1 {
            width: 36%;
            font-size: 11px;
            font-family: 'OpenSansSemibold';
            margin: 5px 0px 0px 0px;
            float: left;
            color: #1cc88a !important;
        }

        .CountNum1 {
            color: #f6c23e !important;
            margin: 14px 0px 0px 16px;
            float: left;
            font-family: 'OpenSansSemibold';
            width: 36%;
            font-size: 20px !important;
            text-align: left;
        }

        .CountNum2 {
            color: #f6c23e !important;
            margin: 14px 0px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: left;
            font-size: 20px !important;
            width: 30%;
            text-align: left;
        }

        .CountNum3 {
            color: #f6c23e !important;
            font-family: 'OpenSansSemibold';
            margin: 14px 0px 0px 0px;
            float: left;
            width: 25%;
            font-size: 20px !important;
            text-align: left;
        }

        .CountNum2_1 {
            color: #1cc88a !important;
            margin: 16px 0px 0px 16px;
            float: left;
            font-family: 'OpenSansSemibold';
            width: 27%;
            font-size: 20px !important;
            text-align: left;
        }

        .CountNum2_2 {
            color: #1cc88a !important;
            margin: 16px 0px 0px 0px;
            float: left;
            font-family: 'OpenSansSemibold';
            font-size: 20px !important;
            width: 30%;
            text-align: left;
        }

        .CountNum2_3 {
            color: #1cc88a !important;
            margin: 16px 0px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            width: 25%;
            font-size: 20px !important;
            text-align: left;
        }

        form {
            /* margin: 0 5px; */
            /*height: 652px !important;*/
            overflow-x: hidden;
            width: 1366px;
            margin: 0px auto;
            overflow-y: auto
        }

        .HomeMenuBox {
            width: 100%;
            float: left;
            margin: 0px 0px 10px 0px;
            display: flex;
            display: none !important;
        }

        /* FixedHeader */

        div#Panel13 {
            margin: 0px 0px 0px 0px;
            height: calc(100vh - 54px);
        }

        div#Panel_unc {
            height: calc(100vh - 54px);
        }

        .PendingRightnewLRightNew {
            /* float: right; */
            width: 82%;
            overflow-x: hidden;
            margin: 11px 0px 0px 0px;
            position: relative;
            left: 5px;
        }

        .widget.box .widget-header {
            background: #dbdbdb !important;
        }


        div#div_iframe {
            position: relative;
            top: -12px;
        }

        div#div_ComApproval {
            width: 98%;
            margin: 0 0 0 16px;
            border: 1px solid #D9D9D9;
        }

        .SalesheadDetails {
            padding: 10px 5px 0px 0px;
        }

        a#excportexc {
            margin-bottom: 5px;
            display: inline-block;
        }

        div#div_iframe {
            position: relative;
            top: -13px;
        }

        .widget-header h4 {
            display: block !important;
        }

        div#panel {
            width: 99%;
            margin: 5px 0px 0 10px !important;
        }

        .modalPopupss {
            top: 40px !important;
        }

        .pop_head {
            font-size: 10px;
            margin: 5px 0 0 5px;
            display: inline-block;
        }

        img#Image8 {
            background-color: black;
            color: white;
            position: relative;
            top: -15px;
            border-radius: 50%;
            cursor: pointer;
        }

        .shadow_box .title3 {
            position: absolute;
            bottom: 35px;
            left: 60px;
            margin: 0;
            font-size: 12px;
            font-weight: normal !important;
        }

        .shadow_box .Amount2 {
            position: absolute;
            bottom: 5px;
            left: 85px;
            font-size: 18px !important;
        }

        table#Grid_salesout td:first-child {
            max-width: 130px !important;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .HomeMenuContent {
            width: 100%;
            float: left;
            margin: 21px 0 0 0px;
        }

        .UnclosedJobhead {
            font-size: 14px;
            font-family: sans-serif;
            margin: 0px 0px 0px 0px;
            padding: 3px 5px 0px 0px;
            color: var(--grey);
            width: 110px;
            font-weight: 500;
            float: left;
        }

        .HomeMenuBox {
            /*using 60vh to maintain proportion by praveen 14Jun2023*/
            height: 60vh !important;
        }

        a#link_CNOP {
            font-size: 18px !important;
        }
        /*.gridpnl {
    height: calc(100vh - 120px);
}
*/

        .BacktoPrevious {
            width: 95%;
            text-align: right;
            float: left;
            margin: 4px 0.5% 4px 0px;
        }

        a#lnk_back {
            font-size: 17px !important;
        }
/*
        .gridpnl {
            height: calc(100vh - 109px) !important;
        }
*/

        a#btnexcelsrp {
            /* top: -23px !important; */
            margin-right: 10px !important;
        }

            a#btnexcelsrp img {
                margin-top: -3px !important;
                width: 28px !important;
                height: 28px !important;
            }

        .dynamic {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            row-gap: 64px;
            padding: 0px 50px 10px 50px;
            margin-top: 60px;
            column-gap: 218px;
        }


        .cardfa img {
            scale: 1;
            margin-top: 15px;
            margin-left: 15px;
            width: 30px !important;
            position: relative;
            top: -18px;
            left: -9px;
        }





        .cardfa {
            padding: 0px;
            width: 200px;
            height: 60px !important;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }

            .cardfa .span1 {
                color: #06529c !important;
                font-size: 16px !important;
                font-weight: 400 !important;
                cursor: pointer;
            }










        .cardfa {
            /* box-shadow: rgb(239 239 246 / 96%) 0px 0px 0px 0px, rgb(200 211 242) 5px 5px 9px 0px; */
            /*  box-shadow: -1px 0px 13px 0px #80808073;
    transform: translateY(-4px) !important;
    -webkit-transition: box-shadow .6s ease-in;*/
            cursor: pointer;
        }



            .cardfa:hover > .span1 {
                color: #f67e09 !important;
            }

            .cardfa:hover > .cardfaborder {
                border: 1px solid #f67e09 !important;
            }

        .group1 {
            display: flex;
            row-gap: 86px;
            width: 93%;
            column-gap: 150px;
            margin: 0px 0px 10px 29px;
            padding: 34px 38px 28px 44px;
        }

        .group2 {
            display: flex;
            row-gap: 86px;
            width: 93%;
            column-gap: 150px;
            margin: 0px 0px 10px 29px;
            padding: 34px 38px 28px 44px;
        }

        .group3 {
            display: flex;
            row-gap: 86px;
            width: 93%;
            column-gap: 150px;
            margin: 0px 0px 10px 29px;
            padding: 34px 38px 28px 44px;
        }

        .group4 {
            display: flex;
            row-gap: 86px;
            width: 93%;
            column-gap: 150px;
            margin: 0px 0px 10px 29px;
            padding: 34px 38px 28px 44px;
        }

        .group5 {
            display: flex;
            row-gap: 86px;
            width: 93%;
            column-gap: 150px;
            margin: 0px 0px 10px 29px;
            padding: 34px 38px 28px 44px;
        }

        .cardbox {
            width: 100%;
            margin-left: -61px;
        }
    </style>

    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        // Global variable to hold data
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>

</head>
<body>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" /> 
     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
      
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: '../Home/Branch_home.aspx/GetChartDataBooking',
                    data: '{}',
                    success:
                        function (response) {
                            drawchart(response.d);
                        },

                    error: function () {
                        alertify.alert("Error loading data! Please try again.");
                    }
                });
            })
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        })

        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            if (dataValues.length != 0) {
                for (var i = 0; i < dataValues.length; i++) {
                    data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
                }

                new google.visualization.PieChart(document.getElementById('chart4Outstanding')).
                    draw(data, {
                        height: "300", title: "Operating Profits", colors: ['#4ebcd5', '#bce3c8', '#408fdc', '#5765b2'],
                    });
            }
        }

    </script>

    <noscript>

Your browser does not support JavaScript!

</noscript>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div class="maindiv">
        <div class="BandMiddle">
            <div class="BreadLabel" id="Home_header" runat="server">Financial Account <span style="display:inline-block;  font-weight:bold; margin:0px 9px 0px 10px; color:#000;"><asp:Label ID="lblLoginYear" runat="server" Visible="false"></asp:Label></span></div>

        </div>
        <div class="BandTop">
            <div class="OCEANEXPORT">

                <h3>
                    <img src="../Theme/assets/corporate/oceanexport_ic1s.png" />
                    <asp:LinkButton ID="lnk_query_OE" runat="server" OnClick="lnk_query_OE_Click">OCEAN EXPORT</asp:LinkButton></h3>
            </div>
            <div class="OCEAMIMPORT">
                
                <h3>
                    <img src="../Theme/assets/corporate/shipimport_ic1s.png" />
                    <asp:LinkButton ID="lnk_query_OI" runat="server" OnClick="lnk_query_OI_Click">OCEAN IMPORT</asp:LinkButton></h3>

            </div>
            <div class="AIREXPORT">

                <h3>
                    <img src="../Theme/assets/corporate/airexport_ic1s.png" />

                    <asp:LinkButton ID="lnk_query_AIRExport" runat="server" OnClick="lnk_query_AIRExport_Click">AIR EXPORT</asp:LinkButton></h3>
            </div>
            <div class="AIRIMPORT">

                <h3>
                    <img src="../Theme/assets/corporate/airimport_ic1s.png" />
                    <asp:LinkButton ID="lnk_query_AIRImport" runat="server" OnClick="lnk_query_AIRImport_Click">AIR IMPORT</asp:LinkButton></h3>
            </div>
            <div class="CostSheet">
                <h3>
                    <img src="../Theme/assets/corporate/exemptionlisits.png" />
                    <asp:LinkButton ID="lnk_cost_sheet" runat="server" OnClick="lnk_cost_sheet_Click">COST SHEET</asp:LinkButton></h3>
            </div>

            <div class="CostSheet1">
                <h3>
                    <img src="../Theme/assets/corporate/profomainvocie_ic.png" />
                    <asp:LinkButton ID="lnk_proInvoice" runat="server" OnClick="lnk_proInvoice_Click" >PROFOMA INVOICE</asp:LinkButton></h3>
            </div>

              <div class="CostSheet2">
                <h3>
                    <img src="../Theme/assets/corporate/profomacnops_ic.png" />
                    <asp:LinkButton ID="lnk_Prooncps" runat="server" OnClick="lnk_Prooncps_Click" >PROFOMA CN-OPS</asp:LinkButton></h3>
            </div>
            <div class="ExRate Change">
                <h3>
                    <img src="../Theme/assets/img/ex_rate.png"" />
                    <asp:LinkButton ID="ExRate_Change" runat="server" OnClick="ExRate_Change_Click">EXRATE CHANGE</asp:LinkButton></h3>
            </div>
        </div>
        <div class="HomeMenuBox ">
            <div class=" hide">
                <asp:LinkButton ID="link_collection" runat="server">
                      <div class="title">Collection</div>
                    <asp:Label ID="lbl_collection" runat="server" CssClass=" Amount">0</asp:Label>
                   
                </asp:LinkButton>
            </div>
                <div class="hide ">
                 <div id="Div1" runat="server">
                    <div class="title">
                        Deposit </div>
                    <div class="DateCal4">
                        <span>From</span>
                        <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" ToolTip="GetDate" AutoPostBack="true"
                            OnTextChanged="txt_date_TextChanged"></asp:TextBox>
                    </div>
                  
                        <asp:LinkButton ID="link_deposit" runat="server" OnClick="link_deposit_Click" CssClass=" Amount"/>
                  
               </div>
            </div>
      <%--      <div class="PaymentBox2">
                <asp:LinkButton ID="link_deposit" runat="server">
                    <h3>
                        <img src="../Theme/assets/corporate/dsodays_ic.png" />
                        Deposit </h3>
                    <div class="Clear"></div>
                    <asp:Label ID="lbl_deposit" runat="server">0</asp:Label>
                </asp:LinkButton>
            </div>--%>
            <div class=" hide ">
                <asp:LinkButton ID="link_funds" runat="server">
                    <div class="title">Funds Flow </div>
                    <asp:LinkButton ID="lnk_fund" runat="server" OnClick="lnk_fund_Click" CssClass=" Amount" Enabled="false">0</asp:LinkButton>
                </asp:LinkButton>
            </div>
            <div class="hide ">
                <div id="link_tds" runat="server">
                    <div class=" title">
                        TDS </div>
                    <div class=" title1">CN Ops</div>
                    <div class="title3">Oth-CN</div>
                    <div class="title2">CN Admin</div>
                  
                        <asp:LinkButton ID="lnk_cnopstds" runat="server" CssClass=" Amount1" OnClick="lnk_cnopstds_Click" Enabled="false">0</asp:LinkButton>

                        <asp:LinkButton ID="lnk_cntds" runat="server" CssClass=" Amount2" OnClick="lnk_cntds_Click" Enabled="false">0</asp:LinkButton>

                        <asp:LinkButton ID="lnk_admincntds" runat="server" CssClass=" Amount" OnClick="lnk_admincntds_Click" Enabled="false">0</asp:LinkButton>
                   
                </div>
            </div>
        
                <div id="link_chequerequestapproval" runat="server">

                     <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/paymentrequestapproval.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Payment Req Approval</span>
                        <span class="Amount">
                         <asp:LinkButton ID="link_CNOP" runat="server"  CssClass="Amount" OnClick="link_CNOP_Click" Enabled="false">0</asp:LinkButton>
                            </span>
                    <div class="hide">
                        <asp:LinkButton ID="link_cnn" runat="server" CssClass="Amount2" OnClick="link_cnn_Click" Enabled="false">0</asp:LinkButton>
                    
                        <asp:LinkButton ID="link_cnadmins" runat="server" CssClass="Amount" OnClick="link_cnadmins_Click" Enabled="false">0</asp:LinkButton>
                   </div>
                    </div>
                      </div>

                </div>

                <asp:LinkButton ID="Lnk_unclosed" runat="server" OnClick="Lnk_unclosed_Click" >

                     <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/openjobs.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title"> Open Jobs</span>
                        <span id="unclosed" runat="server" class=" Amount"></span>
                    </div>
                </div>

                     </asp:LinkButton>

                <asp:LinkButton ID="link_outstanding" runat="server" CssClass="hide" >

                         <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/outstanding.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title"> Outstanding</span>
                                           <asp:Label ID="lbl_outTot" runat="server" class=" Amount">0</asp:Label>

                    </div>
                </div>

                </asp:LinkButton>
         
    </div>

        <div class=" HomeMenuContent">
            

         <%--  Cards Start --%>
            <div class="cardbox">


                <div class="group1">
                     <asp:LinkButton ID="lnk_group" runat="server" OnClick="lnk_group_Click">

                  <div class="cardfa box-shadow">
  <img src="../Theme/assets/img/BranchFaDashBoardIcon/Group.png" />
  <a  class="span1">Groups</a>

</div>
 </asp:LinkButton>

           <asp:LinkButton ID="lnk_subgroup" runat="server" OnClick="lnk_subgroup_Click">
    
<div class="cardfa box-shadow" >
    <img src="../Theme/assets/img/BranchFaDashBoardIcon/SubGroup.png" />
  <a  class="span1">Sub Groups</a>

</div>
               </asp:LinkButton>
                      <asp:LinkButton ID="lnk_ledger" runat="server" OnClick="lnk_ledger_Click">

<div class="cardfa box-shadow">
  <img src="../Theme/assets/img/BranchFaDashBoardIcon/Ledger.png" />
  <a  class="span1">Ledger</a>

</div>
                          </asp:LinkButton>
            </div>         

                


                <div class="group2">
                     <asp:LinkButton ID="lnk_daybook" runat="server" OnClick="lnk_daybook_Click">
                <div class="cardfa box-shadow">
    <img src="../Theme/assets/img/BranchFaDashBoardIcon/DayBook.png" />
  <a  class="span1">Day Book</a>

</div>
                         </asp:LinkButton>
                     <asp:LinkButton ID="lnk_reg" runat="server" OnClick="lnk_reg_Click">
<div class="cardfa box-shadow" >
    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Registers.png" />
  <a  class="span1">Registers</a>

</div>
                         </asp:LinkButton>
                     <asp:LinkButton ID="lnk_ledg" runat="server" OnClick="lnk_ledg_Click">
<div class="cardfa box-shadow">
    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Ledgers.png" />
  <a  class="span1">Ledgers</a>

</div>
                         </asp:LinkButton>
                    </div>


 





     
      
                     
      
                <div class="group3">
                     <asp:LinkButton ID="lnk_statistics" runat="server" OnClick="lnk_statistics_Click">
      <div class="cardfa box-shadow" >
          <img src="../Theme/assets/img/BranchFaDashBoardIcon/Statistics.png" />
        <a  class="span1">Statistics</a>

      </div>
                         </asp:LinkButton>
                     <asp:LinkButton ID="lnk_outst" runat="server" OnClick="lnk_outst_Click">
                  <div class="cardfa box-shadow" >
                      <img src="../Theme/assets/img/BranchFaDashBoardIcon/Outstanding.png" />
    <a  class="span1">Outstanding</a>

  </div>
                         </asp:LinkButton>
                     <asp:LinkButton ID="lnk_svp" runat="server" OnClick="lnk_svp_Click">
                <div class="cardfa box-shadow">
                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/SalesPurchaseReceiptPayment.png" />
  <a  class="span1">Sales vs Purchase</a>

</div>
                         </asp:LinkButton>
                    </div>






                <div class="group4">
                     <asp:LinkButton ID="lnk_trialba" runat="server" OnClick="lnk_trialba_Click">
      <div class="cardfa box-shadow" >
          <img src="../Theme/assets/img/BranchFaDashBoardIcon/TrialBalance.png" />
        <a  class="span1">Trail Balance</a>

     </div>
                         </asp:LinkButton>
                     <asp:LinkButton ID="lnk_pl" runat="server" OnClick="lnk_pl_Click">
      <div class="cardfa box-shadow">
          <img src="../Theme/assets/img/BranchFaDashBoardIcon/P_L.png" />
        <a  class="span1">Profit And Loss</a>


      </div>
                         </asp:LinkButton>
                     <asp:LinkButton ID="lnk_balsheet" runat="server" OnClick="lnk_balsheet_Click">
      <div class="cardfa box-shadow" >
          <img src="../Theme/assets/img/BranchFaDashBoardIcon/BalanceSheet.png" />
         <a class="span1">Balance Sheet</a>

      </div>
                         </asp:LinkButton>
                    </div>
                   

               
                <div class="group5">
                 <div class="cardfa box-shadow hide" >
    
   <a  class="span1">Payment Request Approval</a>
 </div>
 <div class="cardfa box-shadow" style="margin-left: 533px;" >
     <img src="../Theme/assets/img/BranchFaDashBoardIcon/folder-open.png" />
   <a  class="span1">open Jobs</a>

 </div> 
                    </div>
    
    </div>
            <%-- Cards End--%>



            <div class="gridcontent">
                <!-- Tabs-->
                <div class="widget box borderremove">

                    <div class="widget-content">

                        <%--FOR OUTSTANDING--%>
                        <div class="FormGroupContent4">
                            <div class="PadCtrlN" runat="server" id="Div_chart">
                                <div class="OutstandingHead">
                               <div class="SalesheadDetails">Outstanding</div>  
  <div class="right_btn">
                                    <asp:LinkButton ID="excportexc" runat="server" OnClick="excportexc_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                                </div>
                                    </div>
  <div class="Clear"></div>

                                <div class="div_GridNew1" runat="server" id="GridbankBNL">
                                    <asp:Panel ID="panel4Outsales" runat="server" ScrollBars="Auto"  CssClass="gridpnl" Width="100%" >
                                        <asp:GridView ID="Grid_salesout" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" OnRowDataBound="Grid_salesout_RowDataBound" OnPreRender="Grid_salesout_PreRender" >
                                            <Columns>
                                                <asp:BoundField DataField="salesname" HeaderText="Sales Person" HeaderStyle-Wrap="false" />
                                                <asp:BoundField DataField="amount" HeaderText="Outstanding" />
                                                <asp:BoundField DataField="overdue" HeaderText="Over Due" />
                                                <asp:BoundField DataField="salesid" HeaderText="salesid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                                <div id="div_bar" runat="server" class="PendingRightnewLRightNew1" visible="false">
                            <asp:Literal ID="lts" runat="server"></asp:Literal>
                            <div id="chart_divbar"></div>

                        </div>
                                 <div runat="server" id="div2_Bookchart" class="PendingRightnewLRightNew" style="width: 27%;">
                            <div id="chart4Outstanding" style="width: 395px; height: 299px; margin-left: 20px;">
                            </div>
                        </div>

                            </div>
                        </div>


                        
                        <%--For Finance Sales, Receipt, Purchase adn Payment Details--%>
                        <div class="FormGroupContent4">
                            <div class="Clear"></div>
                            <asp:Panel ID="PnlBranchSPRDet" runat="server" CssClass="gridpnl" Width="50%">
                                <asp:GridView ID="grdBranchSPRDet" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdBranchSPRDet_RowDataBound" 
                                    ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found" OnRowCommand="grdBranchSPRDet_RowCommand" DataKeyNames="voumonth" > 
                                    <Columns>
                                        <asp:ButtonField CommandName="ColumnClick" Visible="false" />
                                        <%--<asp:BoundField DataField="voumonth" HeaderText="voumonth" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />--%>
                                        <asp:BoundField DataField="vmonths" HeaderText="Month">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="130px" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" Width="130px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="salesamt" HeaderText="Sales" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" >
                                            <HeaderStyle Wrap="false" HorizontalAlign="Right" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="recamt" HeaderText="Receipts" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" >
                                            <HeaderStyle Wrap="false" HorizontalAlign="Right" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="purchaseamt" HeaderText="Purchase" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" >
                                            <HeaderStyle Wrap="false" HorizontalAlign="Right" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="payamt" HeaderText="Payments" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" >
                                            <HeaderStyle Wrap="false" HorizontalAlign="Right" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>


                            
                          <div class="DivBreak"></div>
                            
                            <div class="FormGroupContent4" style="margin-top:8px !important" >
                           <%-- <div class="BacktoPrevious">
                                <asp:LinkButton ID="lnk_back" Style="text-decoration: none; font-weight: bold" ForeColor="Red" runat="server" 
                                     OnClick="lnk_back_Click">Back to Previous</asp:LinkButton>   
                            </div>--%>
                                <div class="left_btn">
                                       <asp:Label ID="lblheadersrp" runat="server" Text=""></asp:Label>
                                </div>
                            <div class="right_btn">
                                <asp:LinkButton ID="btnexcelsrp" runat="server" OnClick="btnexcelsrp_Click"> 
                                    <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                                <div class="btn ico-cancel right_btn">
                                    <asp:Button ID="btncancel" runat="server" Text="Back" ToolTip="Back" OnClick="btncancel_Click" Style="margin-top:-8px !important;margin-bottom:5px !important;" />
                                </div>
                            </div>

                                </div>


                          <div class="DivBreak"></div>
                            <asp:Panel ID="PnlB_SPRDet" runat="server" CssClass="gridpnl" Width="100%">
                            <asp:GridView ID="grdB_SPRDet" runat="server" AutoGenerateColumns="true" Width="100%" Height="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found"
                                EnableTheming="False" class="GridOutStandingN" OnRowDataBound="grdB_SPRDet_RowDataBound">
                                <Columns>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <FooterStyle CssClass="Footer" />
                            </asp:GridView>
                            </asp:Panel>

                            
                          <div class="DivBreak"></div>
                            <div>

                            </div>

                        </div>


                      <%--  End--%>

                        <%--FOR UNCLOSED JOBS--%>

                        <div class="PendingRightChequApUnclosed" id="div_UnClos" runat="server" visible="false">
                            <div class="UnclosedJobhead">Unclosed Jobs</div>
                             <div style="float: right;margin: 0 0 5px 0;">
                                    <asp:LinkButton ID="excportexc1" runat="server" OnClick="excportexc1_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                                </div>
                            <asp:Panel ID="Panel13" runat="server" Visible="false" CssClass="gridpnl" Width="100%" >
                                <asp:GridView ID="grdunclosejobs" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdunclosejobs_RowDataBound" OnSelectedIndexChanged="grdunclosejobs_SelectedIndexChanged" Visible="true">
                                    <Columns>
                                        <asp:BoundField DataField="Product" HeaderText="Product">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnClosed Jobs" HeaderText="UnClosed Jobs">
                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" Width="50px" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" Width="50px" />

                                        </asp:BoundField>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <div class="clear"></div>

                        <%--Pie-Chart--%>
                       
                          <%--Bar-Chart--%>

                        <div class="PendingRightnewLRightNew" id="_Pend_UN" runat="server" visible="false">
                            <div style="float: right;margin-top: 0px; margin-bottom: 5px;">
                                <asp:LinkButton ID="exp2excgrdunc" runat="server" OnClick="exp2excgrdunc_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                            </div>

                            <div class="GridHead" id="div_unClos_new" runat="server"></div>
                            <asp:Panel ID="Panel_unc" runat="server" Visible="false" CssClass="gridpnl" Width="100%" >
                                <asp:GridView ID="grd_UNC" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" OnRowDataBound="grd_UNC_RowDataBound" ShowHeaderWhenEmpty="true" Visible="true">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <%--FundsFlow-Branch--%>

                        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender_fund"
                            PopupControlID="Panel_4fundflow" CancelControlID="Image8" TargetControlID="Label8" DropShadow="false">
                        </ajax:ModalPopupExtender>
                        <asp:Label ID="Label8" runat="server"></asp:Label>

                        <asp:Panel ID="Panel_4fundflow" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">

                            <div class="pop_head">FundsFlow-Branch</div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image8" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                            </div>
                                <asp:Panel ID="Panel4" runat="server"  CssClass="Gridpnl" Visible="false">
                                    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White"
                                        ShowHeaderWhenEmpty="true" Visible="false" CssClass="Grid FixedHeader">

                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                                </div>
                        </asp:Panel>

                        <div style="display: none;">
                            <asp:Label ID="hidunclosed" runat="server" />
                        </div>
                    </div>
                </div>
             </div>

                        <div runat="server" id="div_ComApproval" class="PendingRightnewComapp" visible="false">
                            <div class="col-md-12  maindiv">

                                <div class="widget box boxheight" runat="server" id="div_iframe">

                                    <div class="widget-header">
                                        <h4><i class="icon-umbrella"></i>
                                            <asp:Label ID="lbl_Header" runat="server" Text="Transfer To Commercial Invoice"></asp:Label>
                                        </h4>
                                    </div>

                 <%-- <asp:ContentPlaceHolder ID="logix_CPH" runat="server"> --%>
                                      <div class="widget-content">
                                         <div class="FormGroupContent4">
                    <div class="ModeDropCN3">  
                        <span>Product</span>
                        <asp:DropDownList ID="ddl_module" runat="server" CssClass="chzn-select" Data-placeholder="Product" ToolTip="Product"
            AutoPostBack="True" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="AE">Air Exports</asp:ListItem>
            <asp:ListItem Value="AI">Air Imports</asp:ListItem>
            <asp:ListItem Value="CH">Custom House Agent</asp:ListItem>
            <asp:ListItem Value="FE">Ocean Exports</asp:ListItem>
            <asp:ListItem Value="FI">Ocean Imports</asp:ListItem>
              
        </asp:DropDownList></div>

                    </div>
                                  
                                        <div class="FormGroupContent4">
                                            <asp:Panel ID="panel" runat="server" CssClass="gridpnl" Width="100%" >
                                                <%--Height="330px">  OnRowCommand="Grd_Approval_RowCommand" OnRowCreated="Grd_Approval_RowCreated" --%>
                                                
                                            <asp:GridView CssClass="Grid FixedHeader"  ID="Grd_Approval"  runat="server" AutoGenerateColumns="False" OnRowDataBound="Grd_Approval_RowDataBound"
                                                    ForeColor="Black" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="Grd_Approval_SelectedIndexChanged" DataKeyNames="vouyear,customerid">
                                                    <Columns>
                                                        <asp:BoundField DataField="vouno" HeaderText="Ref #">
                                                            <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                            <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="bjno" HeaderText="BL #">
                                                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="customer" HeaderText="Customer">
                                                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle Wrap="false" HorizontalAlign="Right" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="preparedby" HeaderText="Prepared by">
                                                            <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                                                            <ItemStyle Wrap="false" Width="170px" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>

                                                         <asp:BoundField DataField="tdstype" HeaderText="TDS Type">                <%--5--%> 
                                                            <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="tdsdesc" HeaderText="TDS Desc">                <%--6--%>
                                                            <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                                        </asp:BoundField>

                                                         <asp:TemplateField HeaderText="TDS %">                                   <%--7--%>
                                                            <ItemTemplate>
                                                            <asp:TextBox ID="TDSPERS" runat="server" Text='<%#Eval("tdsper")%>' ToolTip='<%#Eval("tdsper")%>'  Font-Size="10pt" Style="text-align: right; width: 100%; height: 15px;" ></asp:TextBox>   <%--onkeyup="IsDoubleCheck_Grid(this);"  OnTextChanged="TDSPERS_TextChanged" AutoPostBack="true" --%>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" HorizontalAlign="Right" Width="60px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Transfer">              <%--8--%>
                                                            <HeaderStyle Width="20px" />
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="Chk_transfer" runat="server" AutoPostBack="true" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">                           <%--9--%>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                                                                    CssClass="Arrow">⇛</asp:LinkButton>
                                                                <br />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="stamt" HeaderText="stamt"  DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"/>   <%--10--%> <%-- ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"--%>
                                       <asp:BoundField DataField="SupplyTo" HeaderText="SupplyTo" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"/>    <%--11--%>
                                                        <asp:BoundField DataField="DateApp" HeaderText="DateApp" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"/>   <%--12--%>
                                                        <%--<asp:ButtonField CommandName="ColumnClickNew" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                       <asp:BoundField DataField="tdstypename" HeaderText="tdstypename" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />   <%--13--%>
                                                    
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                                
                                                 </asp:Panel>

                                        </div>

                                        <div class="FormGroupContent4">
                                            <div class="right_btn">
                                                <div class="btn ico-delete">
                                                    <asp:Button ID="btn_delete" runat="server" ToolTip="Delete" Visible="false" />
                                                </div>
                                                <div class="btn ico-view">
                                                    <asp:Button ID="btn_view" runat="server" ToolTip="View" Visible="False" />
                                                </div>
                                                
                                                <div class="btn btn-Gst1">
                                                    <asp:Button ID="btn_transfer" runat="server" ToolTip="GST" OnClick="btn_transfer_Click" />
                                                </div>
                                                <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                                    <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                      <%--  </asp:ContentPlaceHolder> --%>

                            </div>
                        </div>
                        <div class="Clear"></div>

            </div>
            </div>
              <div class="Clear"></div>

               <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" Format="dd/MM/yyyy">
            </asp:CalendarExtender>

         <asp:HiddenField ID="hid_type" runat="server" />
           <asp:HiddenField ID="hid_debit" runat="server" />
            <asp:HiddenField ID="hid_credit" runat="server" />
           <asp:HiddenField ID="hid_container" runat="server" />

          <asp:HiddenField ID="hid_supplyto" runat="server" />
            <asp:HiddenField ID="hid_stamt" runat="server" />
            </div>
    </form>
</body>

</html>
