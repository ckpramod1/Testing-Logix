<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorporateHome.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.CorporateHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <!-- App -->




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

    <%--  <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
    <script src="../Scripts/Validation.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .OutstandingSales {
            font-size: 11px;
            font-family: sans-serif;
            margin: -7px -222px 0px 2px;
            padding: 2px 5px 8px 0px;
            color: var(--grey);
            width: 188px;
            float: left;
        }

        .PaymentBox {
            width: 14.28%;
            min-height: 117px;
            background-color: #16365c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentBox h3 {
                color: #000000;
                padding: 5px 0px 0px 3px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

                .PaymentBox h3 img {
                    float: left;
                    width: 42px;
                }

            .PaymentBox span {
                color: #000000;
                display: block;
                float: right;
                margin: 18px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .Clear {
            clear: both;
        }

        .CNOPS {
            width: 72px;
            float: left;
            margin: 5px 0px 0px 9px;
            color: #ecf7f8;
        }

        .CN {
            width: 22px;
            float: left;
            margin: 5px 0px 0px 0px;
            color: #ecf7f8;
        }

        .CNAdmin {
            width: 67px;
            float: right;
            text-align: right;
            margin: 5px 5px 0px 0px;
            color: #ecf7f8;
        }

        .PaymentRequestBox {
            width: 14.28%;
            min-height: 117px;
            background-color: #963634;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentRequestBox h3 {
                color: #daeef3;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentRequestBox span {
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

        .PaymentApprovalBox {
            width: 14.28%;
            min-height: 117px;
            background-color: #8a933c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PaymentApprovalBox h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PaymentApprovalBox span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: 34px 2px 0px 0px;
                text-align: right;
                padding: 0px 0px 12px 0px;
                font-family: "Segoe UI";
                font-size: 22px;
                font-weight: normal;
            }

        .ApprovalBox {
            width: 14.28%;
            min-height: 117px;
            background-color: #735360;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .ApprovalBox h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .ApprovalBox span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: -1px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 9px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: normal;
            }

        .BankBalanceBox {
            width: 14.28%;
            min-height: 117px;
            background-color: #215967;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .BankBalanceBox h3 {
                color: #daeef3;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .BankBalanceBox span {
                color: #daeef3;
                display: block;
                float: right;
                margin: 39px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .INRSympol {
            float: right;
            margin: -11px 10px 0px 0px;
            width: 24px;
        }

        .CNopsBank2 {
            float: right;
            margin: 16px 5px 0px 10px;
        }

            .CNopsBank2 a {
                color: #daeef3 !important;
                font-size: 20px !important;
            }

        .CNOPSnew {
            width: 10%;
            font-family: 'OpenSansRegular';
            font-size: 16px;
            font-weight: bold;
            margin: 3px 0px 0px 16px;
            float: left;
            color: #1cc88a !important;
        }

        .CNOPSnew1 {
            width: 22px;
            float: left;
            margin: 36px 0px 0px 21px;
            color: #daeef3;
        }

        .PettycashBox {
            width: 14.28%;
            min-height: 117px;
            background-color: #16365c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .PettycashBox h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PettycashBox span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: 15px 10px -1px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 20px;
                font-weight: normal;
            }

        .BRSUncleared {
            width: 14.3%;
            min-height: 117px;
            background-color: #60497a;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .BRSUncleared h3 {
                color: #ecf7f8;
                padding: 5px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .BRSUncleared span {
                color: #ecf7f8;
                display: block;
                float: right;
                margin: 42px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .Receipt {
            float: left;
            margin: 5px 0px 0px 5px;
            color: #ecf7f8;
        }

        .Payment {
            float: right;
            margin: 5px 5px 0px 0px;
            color: #ecf7f8;
        }

        .CNopsCount1 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 10px;
        }

            .CNopsCount1 a {
                color: #ecf7f8 !important;
                font-size: 22px !important;
            }

        .CNopsCount2 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 10px;
            text-align: center;
        }

            .CNopsCount2 a {
                color: #ecf7f8 !important;
                font-size: 22px !important;
            }

        .CNopsCount3 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 10px;
            text-align: right;
        }

            .CNopsCount3 a {
                color: #ecf7f8 !important;
                font-size: 22px !important;
            }

        .CNopsCount4 {
            float: left;
            width: 50px;
            margin: 5px 0px 0px 10px;
            text-align: center;
        }

            .CNopsCount4 a {
                color: #ecf7f8 !important;
                font-size: 24px !important;
            }

        .PadCtrlN {
            padding: 0px 10px 10px 10px;
        }

        .BankBalancetitle {
            width: 300px;
            float: left;
        }

            .BankBalancetitle h3 {
                color: var(--grey);
                font-family: sans-serif;
                font-size: 11px;
                padding-left: 0px;
                margin: 0px;
            }

        .Outstanding {
            width: 300px;
            float: left;
            margin: 16px 0px 0px 0px;
        }

            .Outstanding h3 {
                color: var(--grey);
                font-family: sans-serif;
                font-size: 14px;
                padding-left: 0px;
                margin-top: -4px;
                font-weight: 600;
            }

        .right_btn {
            float: right;
            margin: 5px 0px 0px 0px;
        }



        .div_Gridnew {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 356px;
            /*Border: 1px solid #b1b1b1;*/
            float: left;
            overflow: auto;
        }

        .div_Gridnew1 {
            width: 31%;
            margin-left: 0%;
            margin-bottom: 1%;
            margin-top: -0.9px;
            height: 330px;
            /*Border: 1px solid #b1b1b1;*/
            float: left;
            overflow: auto;
        }

        .DateCal4 {
            width: 48%;
            float: right;
            margin: 0px 2.5% 0px 0px;
        }

        .DropDownBox {
            float: left;
            margin: 10px 0px 10px 10px;
        }

        .ReceiptTxt {
            float: left;
            margin: 5px 0px 0px 5px;
            width: 40%;
        }

            .ReceiptTxt a {
                color: #ecf7f8 !important;
                text-decoration: none;
                text-align: left;
                font-size: 22px;
            }

        .PaymentTxt {
            float: right;
            margin: 5px 0px 0px 5px;
            width: 40%;
            text-align: right;
        }

            .PaymentTxt a {
                color: #ecf7f8 !important;
                text-decoration: none;
                text-align: right;
                font-size: 22px;
            }

        .CustomsBrokingN1 {
            width: 99%;
            float: left;
            height: 356px;
            overflow: auto;
            padding: 0px 10px;
            margin: -10px 0px 0px 0px;
        }

        .GrdAltRow {
            background-color: #cee9fd;
            color: Black;
            font-family: sans-serif;
            font-size: 8pt;
            margin-bottom: 0;
            margin-left: 4px;
        }

        .BankbalanceGrid {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
        }

            .BankbalanceGrid th {
                text-align: center;
                color: #fff;
                font-size: 11px;
                font-family: sans-serif, Geneva, sans-serif;
                background-color: #4a9cce;
                padding: 2px 0px 2px 3px;
                margin: 0px;
            }

            .BankbalanceGrid td {
                font-family: sans-serif, Geneva, sans-serif;
                font-size: 11px;
                color: #515151;
                border: 1px solid #b1b1b1;
                padding: 5px;
            }

        .BandMiddle {
            background-color: #98AFC7;
            float: left;
            min-height: 25px;
            padding: 2px 2px 2px 5px;
            margin: 0px 0px 0px 0px;
            width: 100%;
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

        .PaymentCancel {
            width: 130px;
            float: left;
        }

        .NovOverCheque {
            width: 140px;
            float: left;
        }

        .VoucherRegister {
            width: 140px;
            float: left;
        }

        .SinceAudit {
            width: 103px;
            float: left;
        }

        .CustomerTDS {
            width: 120px;
            float: left;
        }

        .CostSheet {
            width: 103px;
            float: left;
        }

        .Osdn {
            width: 72px;
            float: left;
        }

        .Oscn {
            width: 110px;
            float: left;
        }

        .MB13 {
            margin-right: 17px !important;
            margin-top: -10px;
            margin-bottom: 15px;
        }

        div#OptionDoc {
            margin: -1px 0px 0px 24px;
            color: #fff;
        }

        .TblGrid th {
            background-color: #003a65;
            border-right: 1px solid #51789d;
            color: #ffffff;
            font-family: tahoma;
            font-size: 11px;
            padding: 2px 5px;
        }

        .BranchTitle {
            width: 80px;
            float: left;
            margin: 15px 7px 0px 10px;
        }

            .BranchTitle h3 {
                color: var(--grey);
                font-family: sans-serif;
                font-size: 11px;
                padding-left: 0px;
                margin: 0px;
            }

        .PendingRightnewLRightNew1 {
            float: left;
            width: 550px;
            margin: 0px 0px 3px 10px;
            /*margin: -141px 0px 0px 0px;*/
        }

        .PendingRightnewLRightNew {
            float: right;
            width: 338px;
            margin: 0px 0px 0px 0px;
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
            margin: 0px 0px 0px 15px;
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
            font-size: 20px;
            width: 90%;
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
            margin: 0px 0px 25px 15px;
            float: left;
            color: #f6c23e !important;
        }

        .YellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 20px;
            width: 90%;
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
            font-size: 20px;
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
            margin: 0px 0px 30px 15px;
            float: left;
            color: #4e73df !important;
        }

        .Blue2RightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 0px 10px 0px 0px;
            float: right;
            font-size: 20px;
            width: 94%;
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
            margin: 0px 0px 0px 15px;
            float: left;
            color: #e74a3b !important;
        }

        .Divimg {
            float: right;
            width: 12%;
            margin: 2px 0px 0px 10px;
        }

        .TextOne {
            width: 35%;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 0px 0px 15px;
            float: left;
            color: #4e73df !important;
        }

        .TextTwo {
            width: 20%;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 0px 0px 0px;
            float: left;
            text-align: left;
            color: #4e73df !important;
        }

        .TextThree {
            width: 36%;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 0px 0px 0px;
            float: left;
            color: #4e73df !important;
        }

        .Countone {
            color: #4e73df !important;
            margin: 13px 0px 0px 14px;
            float: left;
            font-family: 'OpenSansSemibold';
            width: 36%;
            font-size: 20px;
            text-align: left;
        }

        .CountTwo {
            color: #4e73df !important;
            margin: 13px 0px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: left;
            font-size: 20px;
            width: 30%;
            text-align: left;
        }

        .CountThree {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 13px 0px 0px 0px;
            float: left;
            width: 25%;
            font-size: 20px;
            text-align: left;
        }

        .TextOne1 {
            width: 35%;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 0px 0px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .TextTwo1 {
            width: 20%;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 0px 0px 0px;
            float: left;
            text-align: left;
            color: #1cc88a !important;
        }

        .TextThree1 {
            width: 36%;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 0px 0px 0px;
            float: left;
            color: #1cc88a !important;
        }

        .Countone1 {
            color: #1cc88a !important;
            margin: 13px 0px 0px 14px;
            float: left;
            font-family: 'OpenSansSemibold';
            width: 36%;
            font-size: 20px;
            text-align: left;
        }

        .CountTwo1 {
            color: #1cc88a !important;
            margin: 13px 0px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: left;
            font-size: 20px;
            width: 30%;
            text-align: left;
        }

        .CountThree1 {
            color: #1cc88a !important;
            font-family: 'OpenSansSemibold';
            margin: 13px 0px 0px 0px;
            float: left;
            width: 25%;
            font-size: 20px;
            text-align: left;
        }

        .LeftSideValue {
            float: left;
            width: 60px;
            font-family: 'OpenSansRegular';
            margin: 0px 0px 0px 15px;
            font-size: 11px;
            font-weight: bold;
            color: #e74a3b !important;
        }

        .RightSideValue {
            float: right;
            width: 60px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 0px 3px 0px 0px;
            color: #e74a3b !important;
        }

        .LeftNumValue {
            color: #e74a3b !important;
            margin: 11px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 21px;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue {
            color: #e74a3b !important;
            margin: 11px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 21px;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }

        .HomeMenuBox a {
            font-size: 20px !important;
        }

        /*.HomeMenuBox > a:first-child {
            margin-left: 0.5% !important;
        }*/

        .shadow_box .title3 {
            position: absolute;
            left: 69px !important;
            top: 47px;
            font-size: 12px !important;
        }

        .shadow_box .Amount2 {
            position: absolute;
            bottom: 5px;
            left: 70px;
            font-size: 18px !important;
        }

        .HomeMenuBox {
            width: 100%;
            float: left;
        }

        div#Div1 {
            width: 31%;
            float: left;
        }

        table#Grid_salesout td:first-child {
            max-width: 100px;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        div#outstanding {
            width: 98.8%;
            margin-left: 8px !important;
            position: relative;
            top: -34px;
        }

        a#exp2excgrdunc {
            margin-bottom: 5px;
            display: inline-block;
        }

        .buttongroup {
            text-align: right;
                margin-top: 45px;
        }
    </style>
    <style type="text/css">
        .Linkbtn1 {
            float: right;
            margin: -7px 5px 0px 0px;
        }

        .FloatCtrl {
            float: left;
            margin: 0px 0px 0px 0px;
            width: 31%;
        }

        .HomeMenuBox {
            height: 80vh !important;
        }


        .HomeMenuContent {
            width: 100%;
            float: left;
            margin: 6px 0px 0px 0px;
        }

        .gridpnl {
            height: calc(100vh - 130px);
        }

        .HomeMenuBox {
            width: 20% !important;
            float: left !important;
            /* margin: 0px 0px 0px 0px !important; */
            display: flex !important;
            flex-direction: column !important;
            justify-content: space-around !important;
            /* height: 89vh !important; */
            height: 100vh !important;
            padding-top: 103px;
            position: relative;
            top: -103px;
        }

        .fc-row.fc-week.fc-widget-content {
            height: 114px !important;
        }

        .fc-day-grid-container.fc-scroller {
            height: 720px !important;
        }

        .widget.box {
            height: 100vh;
            overflow: auto;
        }
    </style>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>



</head>
<body>
    <%--   <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <%--  <script type="text/javascript">

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
                draw(data, { title: "Operating Profits", colors: ['#4ebcd5', '#bce3c8', '#408fdc', '#5765b2'], });
            }
        }
    </script>--%>



    <%--Calender Form St--%>


    <%--    <script type="text/javascript">
        $(document).ready(function () {
            InitializeCalendar();
            debugger;
            function InitializeCalendar() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../FAForms/OutstandingCalendar.aspx/GetCalendarData",
                    dataType: "json",
                    success: function (data) {
                        //var firstSetEvents = $.map(data.d, function (item, i) {
                        //    return {
                        //        id: item.slotID,
                        //        title: item.EventTitle,
                        //        start: new Date(item.slotStartTime),
                        //        end: new Date(item.slotEndTime),
                        //        backgroundColor: item.color,
                        //        allDay: true
                        //    };
                        //});

                        //var secondSetEvents = $.map(data.e, function (item, j) {
                        //    return {
                        //         id: item.slotID1,
                        //        title: item.EventTitle1,
                        //        start: new Date(item.slotStartTime1),
                        //        end: new Date(item.slotEndTime1),
                        //        backgroundColor: item.color1,
                        //        allDay: true
                        //    };
                        //});

                        var mergedEvents = [firstSetEvents, secondSetEvents];

                        $('#calendar').fullCalendar({
                            header: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'month,agendaWeek,agendaDay'
                            },
                            height: 600,
                            width: 100,
                            allDayText: 'Events',
                            selectable: true,
                            overflow: 'auto',
                            editable: true,
                            firstDay: 1,
                            slotEventOverlap: true,
                            events: $.map(data.d, function (item, i) {
                                var eventStartDate = new Date(parseInt(item.slotStartTime.substr(6)));
                                var eventEndDate = new Date(parseInt(item.slotEndTime.substr(6)));
                                var eventTitle = item.EventTitle;
                                var event = new Object();
                                event.id = item.slotID;
                                event.start = eventStartDate; 
                                event.end = eventEndDate;

                                event.title = eventTitle;
                                //event.title = formatAMPM(eventStartDate) + "-" + formatAMPM(eventEndDate); //event.allDay = item.AllDayEvent;

                                event.backgroundColor = item.color;
                                event.allDay= true;
                                return event; 


                                //var event = new Object();
                                //event.id= item.slotID,
                                //event.title = item.eventTitle,
                                //event.start = new Date(item.StartDate),
                                //event.end = new Date(item.EndDate),
                                //event.backgroundColor = item.color
                                //event.allDay = true

                                //event.id = item.EventID;
                                //event.start = new Date(item.StartDate);
                                //event.end = new Date(item.EndDate);
                                //event.title = item.EventName;
                                //event.url = item.Url;
                                //event.ImageType = item.ImageType;
                                //return event;
                            }),
                            eventClick: function () {
                                alertify.alert('a day has been clicked!');
                            },
                            dayClick: function (date, jsEvent, view) {
                                // Show a modal or form to add a new event 
                                $('#addEventModal').modal('show'); // Assuming you have a modal with the ID 'addEventModal' 
                                $('#eventStartDate').val(date.format()); // Pre-fill the selected date in the form 
                            },
                            events: mergedEvents,
                            // Other FullCalendar options...
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.error("Error fetching data:", errorThrown);
                    }
            }
        });

    </script>
    --%>


    <%--<script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json",
        		data: "{}",
                url: "Default.aspx/GetEvents",
                dataType: "json",
                success: function (data) {
                    $('div[id*=fullcal]').fullCalendar({
                        header: {
                            left: 'prev,next today',
                            center: 'title',
                            right: 'month,agendaWeek,agendaDay'
                        },
                        editable: true,
                        events: $.map(data.d, function (item, i)
                        {
                            var event = new Object();
                            event.id = item.EventID;
                            event.start = new Date(item.StartDate);
                            event.end = new Date(item.EndDate);
                            event.title = item.EventName;
                            event.url = item.Url;
                            event.ImageType = item.ImageType;
                            return event;
                        }),
                        eventRender: function (event, eventElement)
                        {
                            if (event.ImageType)
                            {
                                if (eventElement.find('span.fc-event-time').length)
                                {
                                    eventElement.find('span.fc-event-time').before($(GetImage(event.ImageType)));
                                }
                                else {
                                    eventElement.find('span.fc-event-title').before($(GetImage(event.ImageType)));
                                }
                            }
                        },
                        loading: function (bool)
                        {
                            if (bool) $('#loading').show();
                            else $('#loading').hide();}});
                },
                error: function (XMLHttpRequest, textStatus, errorThrown)
                {debugger;}});$('#loading').hide();$('div[id*=fullcal]').show();
        });
        function GetImage(type)
        {
            if (type == 0) {
                return "<br/><img src = 'Styles/Images/attendance.png' style='width:24px;height:24px'/><br/>"
            }
            else if (type == 1) {
                return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
            }
            else
                return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
        }
</script>--%>

    <%--    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<script src="Scripts/fullcalendar.js" type="text/javascript"></script>
<link href="Styles/fullcalendar.css" rel="stylesheet" type="text/css" />
<link href="Styles/Site.css" rel="stylesheet" type="text/css" />



    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json",
        		data: "{}",
        		url: "../FAForms/OutstandingCalendar.aspx/GetOutstanding",
                dataType: "json",
                success: function (data) {
                    $('div[id*=divcalendar]').fullCalendar({
                        header: {
                            left: 'prev,next today',
                            center: 'title',
                            right: 'month,agendaWeek,agendaDay'
                        },
                        editable: true,
                        events: $.map(data.d, function (item, i)
                        {
                            var event = new Object();
                            event.id = item.EventID;
                            event.start = new Date(item.StartDate);
                            event.end = new Date(item.EndDate);
                            event.title = item.EventName;
                            event.url = item.Url;
                            event.ImageType = item.ImageType;
                            return event;
                        }),
                        eventRender: function (event, eventElement)
                        {
                            if (event.ImageType)
                            {
                                if (eventElement.find('span.fc-event-time').length)
                                {
                                    eventElement.find('span.fc-event-time').before($(GetImage(event.ImageType)));
                                }
                                else {
                                    eventElement.find('span.fc-event-title').before($(GetImage(event.ImageType)));
                                }
                            }
                        },
                        loading: function (bool)
                        {
                            if (bool) $('#loading').show();
                            else $('#loading').hide();}});
                },
                error: function (XMLHttpRequest, textStatus, errorThrown)
                { debugger; }
            }); $('#loading').hide(); $('div[id*=divcalendar]').show();
        });
        function GetImage(type)
        {
            if (type == 0) {
                return "<br/><img src = 'Styles/Images/attendance.png' style='width:24px;height:24px'/><br/>"
            }
            else if (type == 1) {
                return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
            }
            else
                return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
        }
</script>
    --%>

    <script type="text/javascript"> 
        $(document).ready(function () {
            //debugger;
            $(document).ready(function () {
                InitializeCalendar();
            });

            function InitializeCalendar() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../Home/CorporateHome.aspx/GetCalendarData",
                    dataType: "json",
                    success: function (data) {
                        $('#calendar').empty();
                        $('#calendar').fullCalendar({
                            header: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'month,agendaWeek,agendaDay'
                            }, //weekNumbers: true, 
                            height: 600,
                            width: 100,
                            allDayText: 'Events',
                            selectable: true,
                            overflow: 'auto',
                            editable: true,
                            firstDay: 1,
                            slotEventOverlap: true,
                            eventClick: function (event) {
                                // opens events in a popup window
                                $('#popup').html('<iframe src="' + event.url + '" width="700" height="600"></iframe>');
                                $('#popup').dialog({ autoOpen: false, modal: true, width: 750, height: 675 });
                                return false;
                            },

                            dayClick: function (date, jsEvent, view) {
                                // Show a modal or form to add a new event 
                                $('#addEventModal').modal('show'); // Assuming you have a modal with the ID 'addEventModal' 
                                $('#eventStartDate').val(date.format()); // Pre-fill the selected date in the form 
                                //$('#eventurl').val(jsEvent.eventUrl); // Pre-fill the selected date in the form 
                                //jsEvent.
                            },

                            events: $.map(data.d, function (item, i) {
                                var eventStartDate = new Date(parseInt(item.Start.substr(6)));
                                var eventEndDate = new Date(parseInt(item.End.substr(6)));

                                var event = {
                                    id: i,
                                    start: eventStartDate,
                                    end: eventEndDate,
                                    title: item.Title,
                                    backgroundColor: item.Color,
                                    url: item.Url
                                };

                                return event;
                            }),

                            eventRender: function (event, element) {

                                // Hide the time portion of the event
                                element.find('.fc-time').hide();

                                var fontColor = 'black'; // Default color
                                var wordsToCheck = ['R :']; // Words to check for
                                var wordsToCheck1 = ['P :']; // Words to check for


                                // Loop through each word to check
                                for (var i = 0; i < wordsToCheck.length; i++) {
                                    if (event.title.toLowerCase().includes(wordsToCheck[i].toLowerCase())) {
                                        // If the event title contains the word, set font color
                                        fontColor = 'green'; // Set the desired font color
                                        break; // Exit the loop once a match is found
                                    }
                                    if (event.title.toLowerCase().includes(wordsToCheck1[i].toLowerCase())) {
                                        // If the event title contains the word, set font color
                                        fontColor = 'orange'; // Set the desired font color
                                        break; // Exit the loop once a match is found
                                    }
                                }

                                // Apply font color to the event element
                                element.attr('style', 'color: ' + fontColor + ' !important');
                            }


                        });

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //-- log error 
                        console.error("Error fetching data:", errorThrown);
                    }
                });
            }
            $('#addEventForm').on('click', function (e) {
                //debugger;
                var formData = $('#frm').serializeArray();
                var newEvent = {
                    slotDate: new Date($('#eventStartDate').val()),
                    slotStartTime: $('#eventStartDate').val() + ' ' + $('#eventStartTime').val(),
                    slotEndTime: $('#eventStartDate').val() + ' ' + $('#eventEndTime').val(),
                    url: $('#url').val() + ' ' + $('#url').val(),
                    // Other event properties... 
                }; // Send the new event data to the server using Ajax 

            });
        })
        function formatAMPM(date) {
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am'; hours = hours % 12; hours = hours ? hours : 12; // the hour '0' should be '12' 
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;
            return strTime;
        }

    </script>

    <style type="text/css">
        #popup {
            display: none;
        }

        div#calendar {
            width: 97%;
            margin-left: 32px;
            margin-top: 27px;
        }

        .fc-event, .fc-event-dot {
            background-color: white !important;
            border: none !important;
        }

            .fc-event, .fc-event:hover {
                color: black !important;
            }

        h2 {
            text-shadow: -1px 1px 0px rgba(0, 0, 0, 0.15);
            color: black;
        }

        .fc-event .fc-content {
            position: relative;
            z-index: 2;
            text-align: right;
        }

      .fc-row.fc-widget-header table thead tr th {
    padding: 10px !important;
    font-size: 14px !important;
    color: #f67e09 !important;
    font-weight: 400 !important;
    background: #80808029;
}
      a#card {
    margin-right: 10px;
}

        button.fc-agendaWeek-button.fc-button.fc-state-default {
            display: none;
        }

        button.fc-agendaDay-button.fc-button.fc-state-default.fc-corner-right {
            display: none;
        }

        button.fc-month-button.fc-button.fc-state-default.fc-corner-left.fc-state-active {
            display: none;
        }

        .fc-toolbar .fc-center {
            display: inline-block;
            padding-bottom: 15px;
        }

        .fc-toolbar .fc-center {
            display: inline-block;
            padding-bottom: 15px;
            margin-right: 128px;
        }

        .fc-view-container *, .fc-view-container :after, .fc-view-container :before {
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
            font-size: 15px;
            font-weight: 350;
        }

        .fc-center h2 {
            font-weight: 400 !important;
            color: var(--labelblue) !important;
        }

        button.fc-today-button.fc-button.fc-state-default.fc-corner-left.fc-corner-right.fc-state-disabled {
            text-transform: capitalize;
        }

        .fc-unthemed td.fc-today {
            background: #06529c14 !important;
        }

      .fc-basic-view .fc-day-number, .fc-basic-view .fc-week-number {
    padding: 2px !important;
    font-size: 30px !important;
}
        .fc-state-highlight {
            color: var(--labelblue) !important;
        }

        .fc .fc-row .fc-content-skeleton table, .fc .fc-row .fc-content-skeleton td, .fc .fc-row .fc-helper-skeleton td {
            background: 0 0;
            border-color: white !important;
        }

        .fc-unthemed .fc-content, .fc-unthemed .fc-divider, .fc-unthemed .fc-list-heading td, .fc-unthemed .fc-list-view, .fc-unthemed .fc-popover, .fc-unthemed .fc-row, .fc-unthemed tbody, .fc-unthemed td, .fc-unthemed th, .fc-unthemed thead {
            border-color: white !important;
        }

        .fc-view, .fc-view > table {
            position: relative;
            z-index: 1;
            height: 620px;
        }
span.fc-title {
    font-size: 12px;
    font-weight: 300;
}

        .current-month {
            font-weight: bold;
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
            display: none;
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
        .fc {
    direction: ltr;
    text-align: right !important;
}

     .cardbox {
    width: 100%;
    margin-top: 15px;
}
        a#calender img {
    border: 1px solid #808080;
    padding: 3px;
}
        a#card img{
 border: 1px solid #808080;
 padding: 3px;
        }
        a#calender {
    margin-right: 10px;
}
    </style>

    <%--Calender Form End--%>

    <noscript>
        Your browser does not support JavaScript!

    </noscript>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div class="maindiv">
        <%--<div class="BandMiddle">
            <div class="BreadLabel" id="OptionDoc" runat="server">
                Financial Accounts <span style="display: inline-block; font-weight: bold; margin: 0px 9px 0px 10px; color: #000;">
                    <asp:Label ID="lblLoginYear" runat="server" Visible="false"></asp:Label></span>
            </div>
        </div>
        <div class="BandTop">
            <div class="PaymentCancel">
                <h3>
                    <img src="../Theme/assets/corporate/PaymentCancel_ic.png" />
                    <asp:LinkButton ID="link_button" runat="server" Text="Payment Cancel"></asp:LinkButton></h3>  <%--OnClick="link_button_Click"--%>

        <%-- </div>
            <div class="NovOverCheque">
                <h3>
                    <img src="../Theme/assets/corporate/overcheque_ic.png" />
                    <asp:LinkButton ID="LinkButton4" runat="server" Text="Not Over Cheque"></asp:LinkButton></h3> <%--OnClick="LinkButton4_Click"--%>

        <%-- </div>
            <div class="VoucherRegister">
                <h3>
                    <img src="../Theme/assets/corporate/voucherregister.png" />

                    <asp:LinkButton ID="LinkButton5" runat="server" Text="Voucher Register"></asp:LinkButton></h3> <%--OnClick="LinkButton5_Click"--%>

        <%--</div>
            <div class="SinceAudit">

                <h3>

                    <img src="../Theme/assets/corporate/sinceaudit_ic.png" />

                    <asp:LinkButton ID="LinkButton6" runat="server" Text="Since Audit"></asp:LinkButton></h3> <%--OnClick="LinkButton6_Click"--%>
        <%-- </div>

            <div class="CustomerTDS">
                <h3>
                    <img src="../Theme/assets/corporate/customer_Profile.png" />

                    <asp:LinkButton ID="LinkButton7" runat="server" Text="Customer TDS"></asp:LinkButton></h3><%-- OnClick="LinkButton7_Click"--%>

        <%-- </div>
            <div class="CostSheet">
                <h3>
                    <img src="../Theme/assets/corporate/exemptionlisits.png" />

                    <asp:LinkButton ID="LinkButton8" runat="server" Text="Cost Sheet"></asp:LinkButton></h3> <%--OnClick="LinkButton8_Click"--%>
        <%--</div>
            <div class="Osdn">
                <h3>
                    <img src="../Theme/assets/corporate/overseasdebitnote_ic.png" />
                    <asp:LinkButton ID="LinkButton9" runat="server" Text="OSDN" /> <%--OnClick="LinkButton9_Click"--%>
        <%--</h3>--%>
        <%-- </div>

            <div class="Oscn">
                <h3>
                    <img src="../Theme/assets/corporate/overseascreditnote_ic.png" />
                    <asp:LinkButton ID="LinkButton10" runat="server" Text="OSCN" /> <%--OnClick="LinkButton10_Click"--%>
        <%-- </h3>
            </div>
        </div>
        <div class="HomeMenuBox">
            <div>
            <asp:LinkButton ID="link_cheque" runat="server" CssClass="">

                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/paymentrequestapproval.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Payment Request Approval</span>

                        <asp:LinkButton ID="Link_CNOPS" runat="server" CssClass=" Amount1">CN Ops</asp:LinkButton>  <%--OnClick="Link_CNOPS_Click"--%>
        <%--<div class="hide">
                            <asp:LinkButton ID="Link_CN" runat="server" CssClass=" Amount2">CN</asp:LinkButton>  <%--OnClick="Link_CN_Click"--%>

        <%-- <asp:LinkButton ID="link_CNADmin" runat="server" CssClass=" Amount">CN Admin</asp:LinkButton>  <%--OnClick="link_CNADmin_Click"--%>
        <%-- </div>
                    </div>
                </div>

            </asp:LinkButton>
                </div>

            <asp:LinkButton ID="openjobs" runat="server" CssClass="">

                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/openjobs.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Open Jobs</span>
                        <span id="OpenJonsTotal" runat="server" class=" Amount">0</span>
                    </div>
                </div>
            </asp:LinkButton>

            <div class="hide">

<%--                <asp:LinkButton ID="Lnk_payment" runat="server" CssClass="">
                    <div class=" shadow_box Green">
                        <p class="title">Payment</p>
                        <p class="title1">CN Ops</p>
                        <p class="title3">CN</p>
                        <p class="title2">CN Admin</p>

                        <asp:LinkButton ID="link_CNOP" runat="server" CssClass=" Amount1" OnClick="link_CNOP_Click">CN Ops</asp:LinkButton>
                        <asp:LinkButton ID="link_cnn" runat="server" CssClass="Amount2" OnClick="link_cnn_Click">CN</asp:LinkButton>
                        <asp:LinkButton ID="link_cnadmins" runat="server" CssClass="Amount" OnClick="link_cnadmins_Click">CN Admin</asp:LinkButton>
                    </div>
                </asp:LinkButton>--%>
        <%-- </div>

            <div class="hide">
                <%--<asp:LinkButton ID="link_collection" runat="server" OnClick="link_collection_Click">
                    <div class=" shadow_box SkyBlue" runat="server">
                        <div class=" title">Collection Pending</div>
                        <asp:Label ID="lbl_collection" CssClass=" Amount" runat="server">0</asp:Label>
                    </div>
                </asp:LinkButton>--%>
        <%--</div>

            <div class="hide">
               <%-- <div class=" shadow_box Yellow">
                    <div id="link_deposit" class="title" runat="server">
                        Deposit
                        <div class="DateCal4">
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" ToolTip="GetDate" AutoPostBack="true"
                                OnTextChanged="txt_date_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Label ID="lbl_deposit" runat="server">
                        <div class="DptLink">
                            <asp:LinkButton ID="lnk_deposit" CssClass=" Amount" runat="server" OnClick="lnk_deposit_Click">0</asp:LinkButton>
                        </div>
                    </asp:Label>
                </div>--%>
        <%-- </div>

            <div class="hide">
                <%--<asp:LinkButton ID="Lnk_BankBal1" runat="server" CssClass="">
                    <div class=" shadow_box Green">

                        <div class=" title">Bank Balance</div>
                        <div class=" Amount1" id="id_bnk" runat="server"></div>

                        <asp:LinkButton ID="Lnk_BankBal" CssClass=" Amount" runat="server" OnClick="Lnk_BankBal_Click"> Bank Balance</asp:LinkButton>

                    </div>
                </asp:LinkButton>--%>
        <%--</div>

            <%--<asp:LinkButton ID="link_outstanding" runat="server" OnClick="link_outstanding_Click" CssClass="">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/outstanding.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Outstanding</span>
                        <span id="SPoutstOI" runat="server" visible="false"></span>
                        <span id="SPoutstOE" runat="server" visible="false"></span>
                        <span id="SPoutstCH" runat="server" visible="false"></span>
                        <span id="SPoutstBT" runat="server" visible="false"></span>
                        <span id="SPoutstAI" runat="server" visible="false"></span>
                        <span id="SPoutstAE" runat="server" visible="false"></span>
                        <span id="SPoutsttot" runat="server" class=" Amount"></span>
                    </div>
                </div>
            </asp:LinkButton>--%>

        <%-- <div>
            <asp:LinkButton ID="link_unlosed" runat="server">
                <%--<div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/brsuncleared.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">BRS UnCleared  </span>
                        <asp:LinkButton ID="lnk_receipt" CssClass=" Amount1" runat="server" OnClick="lnk_receipt_Click">0</asp:LinkButton>

                        <asp:LinkButton ID="lnk_payment1" CssClass="Amount" runat="server" OnClick="lnk_payment1_Click">0</asp:LinkButton>
                    </div>
                </div>--%>

        <%--</asp:LinkButton>
            
            </div>
        </div>--%>

        <div class=" HomeMenuContent">
            <%--Vino Hide on [19-11-2023]--%>

            <%--            <div class="FormGroupContent4">
                <div class="BranchTitle" id="BranchTitle1" runat="server">
                    <h3>
                        <asp:Label ID="lbl_branch" runat="server" /></h3>

                </div>
                <div class="DropDownBox">
                    <asp:DropDownList ID="ddl_branch" runat="server" CssClass="chzn-select" data-placeholder="Branch" ToolTip="Branch" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" AutoPostBack="true" Visible="false" />
                </div>
            </div>
            <div class="FormGroupContent4 hide">
                <div class="PadCtrlN" runat="server" id="Div_chart">
                    <div class="FloatCtrl">
                        <div class="OutstandingSales">
                            Outstanding Details
                                      
                        </div>
                        <div class="Linkbtn1">
                            <asp:LinkButton ID="excportexc" runat="server" OnClick="excportexc_Click"> <img src="../Theme/assets/img/exportexcel_ic.png" title="Export to Excel"/></asp:LinkButton>
                        </div>
                    </div>
                    <div class="Clear"></div>
                    <div class="" runat="server" id="Div1">
                        <asp:Panel ID="panel4Outsales" runat="server" ScrollBars="Auto" CssClass="gridpnl" Width="100%" >
                            <asp:GridView ID="Grid_salesout" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" OnRowDataBound="Grid_salesout_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="salesname" HeaderText="Sales Person" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="amount" HeaderText="Outstanding" HeaderStyle-CssClass="align-right" />
                                    <asp:BoundField DataField="overdue" HeaderText="Over Due" HeaderStyle-CssClass="align-right" />
                                    <asp:BoundField DataField="salesid" HeaderText="salesid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div id="div_bar" runat="server" class="PendingRightnewLRightNew1" visible="false">
                        <asp:Literal ID="lts" runat="server"></asp:Literal><div id="chart_divbar"></div>

                    </div>
                    <div runat="server" id="div2_Bookchart" class="PendingRightnewLRightNew">
                        <div id="chart4Outstanding" style="width: 395px; height: 310px; margin-left: 20px;">
                        </div>
                    </div>

                </div>
            </div>
            <div class="FormGroupContent4">
                <div class="PadCtrlN" runat="server" id="Bankbalancetitle">
                    <div class="BankBalancetitle">
                        <h3>Bank Balance</h3>
                    </div>
                    <div class="right_btn">
                        <asp:LinkButton ID="lnk_Grid_bankbalance" runat="server" OnClick="lnk_Grid_bankbalance_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                        </asp:LinkButton>
                        <div style="clear: both;"></div>
                    </div>
                    <div class="div_Gridnew" runat="server" id="GridbankBNL">
                        <asp:GridView ID="Grid_bankbalance" runat="server" AutoGenerateColumns="true" CssClass="Grid FixedHeader"
                            Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_bankbalance_RowDataBound"
                            OnSelectedIndexChanged="Grid_bankbalance_SelectIndexChanged">
                            <Columns>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                    </div>
                </div>
            </div>
            <div id="outstanding" runat="server" visible="false">
                <div class="Outstanding">
                    <h3>Outstanding</h3>
                </div>
                <div class="right_btn">
                    <asp:LinkButton ID="exp2excgrdunc" runat="server" OnClick="exp2excgrdunc_Click">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                    </asp:LinkButton>
                    <div style="clear: both;"></div>
                </div>
                <asp:Panel ID="Panel1" runat="server" Visible="true" CssClass="gridpnl" Width="100%">

                    <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
                        EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true"
                        OnRowDataBound="GridView2_RowDataBound" GridLines="None">
                        <%--  AllowPaging="false" PageSize="15" OnPageIndexChanging="GridView2_PageIndexChanging"--%>
            <%-- <Columns>
                            <%-- <asp:BoundField DataField="shortname" HeaderText="Branch" />--%>
            <%-- <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                        <asp:Label ID="shortname" runat="server" Text='<%# Bind("shortname") %>' ToolTip='<%# Bind("shortname") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                        <asp:Label ID="trantype" runat="server" Text='<%# Bind("trantype") %>' ToolTip='<%# Bind("trantype") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="105" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" Width="105" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VouType">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 85px">
                                        <asp:Label ID="voutype" runat="server" Text='<%# Bind("voutype") %>' ToolTip='<%# Bind("voutype") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="90" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" Width="90" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Vou #">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                        <asp:Label ID="vouno" runat="server" Text='<%# Bind("vouno") %>' ToolTip='<%# Bind("vouno") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                        <asp:Label ID="voudate" runat="server" Text='<%# Bind("voudate") %>' ToolTip='<%# Bind("voudate") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="BL #">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                        <asp:Label ID="refno" runat="server" Text='<%# Bind("refno") %>' ToolTip='<%# Bind("refno") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SalesPerson">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 145px">
                                        <asp:Label ID="salesname" runat="server" Text='<%# Bind("salesname") %>' ToolTip='<%# Bind("salesname") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" Width="150px" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 145px">
                                        <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%# Bind("customer") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" Width="150px" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Amount" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                        <asp:Label ID="amount" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
            <%-- <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nodays" HeaderText="NoOfDays" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <%--   <asp:TemplateField HeaderText="NoOfDays" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                        <asp:Label ID="nodays" runat="server" Text='<%# Bind("nodays") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
            <%--<asp:TemplateField HeaderText="AppAmt" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                        <asp:Label ID="appamt" runat="server" Text='<%# Bind("appamt") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

            <%-- <asp:BoundField DataField="appamt" HeaderText="AppAmt" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="appdays" HeaderText="AppDays" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <%--<asp:TemplateField HeaderText="AppDays" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                        <asp:Label ID="appdays" runat="server" Text='<%# Bind("appdays") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

            <%-- <asp:BoundField DataField="overdue" HeaderText="OverDue" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="overduedays" HeaderText="OverDueDays" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <%--  <asp:TemplateField HeaderText="OverDueDays" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                        <asp:Label ID="overduedays" runat="server" Text='<%# Bind("overduedays") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
            <%--  <asp:BoundField DataField="trantype" HeaderText="Product" />
                                                  <asp:BoundField DataField="voutype" HeaderText="VouType" />
                                                  <asp:BoundField DataField="vouno" HeaderText="Vou #" />
                                                  <asp:BoundField DataField="voudate" HeaderText="Date" />
                                                  <asp:BoundField DataField="refno" HeaderText="BL #" />
                                                  <asp:BoundField DataField="salesname" HeaderText="SalesPerson" />
                                                  <asp:BoundField DataField="customer" HeaderText="Ledger" />
                                                  <asp:BoundField DataField="amount" HeaderText="Amount" />
                                                 <asp:BoundField DataField="nodays" HeaderText="NoOfDays" />
                                                 <asp:BoundField DataField="appamt" HeaderText="AppAmt" />
                                                 <asp:BoundField DataField="appdays" HeaderText="AppDays" />
                                                 <asp:BoundField DataField="overdue" HeaderText="OverDue" />
                                                 <asp:BoundField DataField="overduedays" HeaderText="OverDueDays" />--%>
            <%-- </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <%-- <HeaderStyle CssClass="GridviewScrollHeader" /> 
    <RowStyle CssClass="GridviewScrollItem" /> 
    <PagerStyle CssClass="GridviewScrollPager" /> --%>
            <%-- </asp:GridView>
                </asp:Panel>
            </div>--%>

            <%--Vino Hide on [19-11-2023] End--%>


            <%--Calendar set Start--%>


            <link href="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.10.2/fullcalendar.min.css" rel="stylesheet" />
            <script src='https://fullcalendar.io/js/fullcalendar-2.1.1/lib/moment.min.js'></script>
            <script src='https://fullcalendar.io/js/fullcalendar-2.1.1/lib/jquery.min.js'></script>
            <script src="https://fullcalendar.io/js/fullcalendar-2.1.1/lib/jquery-ui.custom.min.js"></script>
            <script src='https://fullcalendar.io/js/fullcalendar-2.1.1/fullcalendar.min.js'></script>
            <link href="Content/bootstrap.css" rel="stylesheet" />
            <script src="Scripts/bootstrap.min.js"></script>

            <!-- Latest compiled JavaScript -->
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

            <div>
                <div class="col-md-12  maindiv">
                    <div class="widget box " runat="server">
                        <%--<div class="widget-header">
                <h4 class="hide"><i class="icon-umbrella"></i>
                    <asp:Label ID="LblHead" runat="server"></asp:Label>
                </h4>
                <div class="crumbs">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i><a href="#">Home</a> </li>
                        <li><a href="#">Outstanding</a> </li>
                        <li><a href="#" title="">Outstanding Calendar</a> </li>
                        <li>
                        <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                    </ul>
                </div>
                <div style="float: right; margin: 0px -0.5% 0px 0px;" class="btn-logic1">
                    <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                </div>
            </div>--%>
                        <div class="buttongroup">
                            <%--<a href="#" id="calender" runat="server">

                            </a>--%>
                            <asp:LinkButton ID="calender" runat="server" OnClick="calender_Click" >
                                <img src="../Theme/assets/img/BranchFaDashBoardIcon/ReceivablePayableCalendar.png" />

                            </asp:LinkButton>
                            

                           <%-- <a href="#" id="card" runat="server">

                            </a>--%>

                            <asp:LinkButton ID="card" runat="server" OnClick="card_Click" >
<img src="../Theme/assets/img/BranchFaDashBoardIcon/accounting.png" />
                            </asp:LinkButton>

                        </div>


                        <%-- Cards Start --%>
                        <div class="cardbox" id="div_card" runat="server"  >


                            <div class="group1">

                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Group.png" />
                                    <a class="span1">Payment By Approval</a>

                                </div>

                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/folder-open.png" />
                                    <a class="span1">Open Jobs</a>

                                </div>

                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/folder-open.png" />
                                    <a class="span1">Sales Vs Purchase</a>
                                    <a class="span1">&</a>
                                    <a class="span1">Receipt Vs Payment</a>



                                </div>



                            </div>




                            <div class="group2">




                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Group.png" />
                                    <a class="span1">Groups</a>

                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/SubGroup.png" />
                                    <a class="span1">Sub Groups</a>

                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Ledger.png" />
                                    <a class="span1">Ledger</a>

                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Ledger.png" />
                                    <a class="span1">Chart of Accounts</a>

                                </div>







                            </div>












                            <div class="group3">
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Statistics.png" />
                                    <a class="span1">Statistics</a>

                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/DayBook.png" />
                                    <a class="span1">Day Book</a>

                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Registers.png" />
                                    <a class="span1">Registers</a>

                                </div>

                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Ledgers.png" />
                                    <a class="span1">Ledgers</a>

                                </div>



                                <%-- <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/SalesPurchaseReceiptPayment.png" />
                                    <a class="span1">Sales vs Purchase</a>

                                </div>--%>
                            </div>






                            <div class="group4">
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/TrialBalance.png" />
                                    <a class="span1">Trail Balance</a>

                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/P_L.png" />
                                    <a class="span1">Profit And Loss A/C</a>


                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/BalanceSheet.png" />
                                    <a class="span1">Balance Sheet</a>

                                </div>
                                <div class="cardfa box-shadow">
                                    <img src="../Theme/assets/img/BranchFaDashBoardIcon/Outstanding.png" />
                                    <a class="span1">OutStanding</a>

                                </div>
                            </div>



                            <div class="group5">
                                <div class="cardfa box-shadow hide">

                                    <a class="span1">Payment Request Approval</a>
                                </div>

                            </div>

                        </div>


                        <%-- Cards End --%>



                       
                            <section class="content" style="background-color: white;" id="div_calender" runat="server"   visible="false" >
                                <div class="">
                                    <div class="col-md-12  maindiv">
                                        <div id="calendar">
                                            <div id="popup"></div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        
                        <!-- Add Event Modal -->
                        <%--<div class="modal fade" id="addEventModal" tabindex="-1" role="dialog" aria-labelledby="addEventModalLabel" aria-hidden="true"> 
                    <div class="modal-dialog" role="document"> 
                        <div class="modal-content"> 
                            <div class="modal-header"> 
                                <h5 class="modal-title" id="addEventModalLabel">Add Event</h5> 
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"> 
                                    <span aria-hidden="true">&times;</span> 
                                </button> </div> <div class="modal-body"> 
                                    <form id="frm"> <div class="form-group"> 
                                        <label for="eventStartDate">Start Date</label> 
                                        <input type="date" class="form-control" id="eventStartDate" name="startDate" required> 

                                                    </div> 
                                        <div class="form-group"> 
                                            <label for="eventStartTime">Start Time</label> 
                                            <input type="time" class="form-control" id="eventStartTime" name="startTime" required> 

                                        </div> <div class="form-group"> 
                                            <label for="eventEndTime">End Time</label> 
                                            <input type="time" class="form-control" id="eventEndTime" name="endTime" required> 

                                         </div> 
                                        <!-- Other event fields... --> 
                                        <button type="button" id="addEventForm" class="btn btn-primary">Add Event</button> 

                                </form>                                                  
                            </div> 
                        </div> 
                    </div> 
                </div> --%>

                        <%--<div class="widget-content">
                
                <div id="divcalendar">
                </div>


              <%-- <div class="divcalendar">
                    <asp:Calendar ID="OutstdCal" runat="server" CellSpacing="1" Font-Bold="False" Font-Size="Medium" >
                        <DayHeaderStyle BorderStyle="Solid" BorderWidth="1px" Font-Names="Rockwell Condensed" />
                        
                    </asp:Calendar>--%>






                        <%--</div>--%>
                    </div>
                </div>
            </div>

            <%--Calendar set end--%>
        </div>
        <%--<asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" Format="dd/MM/yyyy"></asp:CalendarExtender>--%>

        <asp:HiddenField ID="hid_ledgerid" runat="server" />
        </div>
    </form>


</body>




<%--<script type="text/javascript">
    var card = document.getElementById("card");
    var calender = document.getElementById("calender");
    var div_card = document.getElementById("div_card");
    var div_calender = document.getElementById("div_calender");


    calender.addEventListener("click", function () {
        div_card.style.display = "block";
        div_calender.style.display = "none";
    });

    card.addEventListener("click", function () {
        div_calender.style.display = "block";
        div_card.style.display = "none";
    });


</script>--%>
</html>
