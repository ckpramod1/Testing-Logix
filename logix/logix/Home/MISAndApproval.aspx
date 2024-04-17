<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="MISAndApproval.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.MISAndApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />


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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/MoveLabelAfter.js"></script>
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

    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />


    <%--TEST--%>

    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css" />

    <link rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" type="text/javascript"></script>--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://kit.fontawesome.com/169cce9a93.css" crossorigin="anonymous" />

    <script src="https://kit.fontawesome.com/169cce9a93.js" crossorigin="anonymous"></script>

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>

    <script src="http://www.google.com/jsapi" type="text/javascript"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

    <script type="text/javascript" src="../js/helper.js"></script>

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

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

    <link href="../Styles/MIS.css" rel="stylesheet" />
    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .Hide {
            display: none;
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

        .BarChartsales {
            float: left;
            width: 810px;
            margin: 0px 10px 0px 0px;
        }

        .PendingBookingSale {
            float: left;
            width: 810px;
            margin: 5px 0px 0px 0px;
        }

        .PendingTblGridNew {
            /*border: 1px solid #a9b1bd;*/
            border-collapse: collapse;
            margin: 0px 0px 5px 0px;
        }

            .PendingTblGridNew th {
                text-align: left;
                color: #4e4e4c;
                font-size: 11px;
                font-family: sans-serif, Geneva, sans-serif;
                font-weight: bold;
                /*background-color: #cdd7e6;*/
                padding: 4px 3px 4px 6px;
                margin: 0px 0px 0px 0px;
            }

        .PendingTblGridNew1 td {
            font-size: 11px;
            color: #4e4e4c;
        }

        .Div_GridHome {
            width: 64.8%;
            float: left;
            height: 372px;
            margin-top: 0%;
            margin-left: -10px;
        }

        .Div_GridHomeC {
            width: 34.5%;
            float: left;
            height: 370px;
            margin-top: 19px;
            margin-right: 1%;
        }

        /*.PendingRightnew {
            float: left;
            width: 218px;
            margin: 0px 0px 0px 65px;
        }*/

        .PendingTblGridNew1 {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
        }

            .PendingTblGridNew1 th {
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

                .PendingTblGridNew1 th:last-child {
                    border-right: 1px solid #003a65;
                }

                .PendingTblGridNew1 th:first-child {
                    border-left: 1px solid #003a65;
                }

        .PendingTblGridNewOutW1 {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
            width: 384px !important;
        }

            .PendingTblGridNewOutW1 th {
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

                .PendingTblGridNewOutW1 th:last-child {
                    border-right: 1px solid #003a65;
                }

                .PendingTblGridNewOutW1 th:first-child {
                    border-left: 1px solid #003a65;
                }

            .PendingTblGridNewOutW1 td {
                font-size: 11px;
                color: #4e4e4c;
            }

        .ByDrop1 {
            width: 35%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_div_fivolume {
            height: 260px;
            width: 100%;
            overflow: auto;
            border: 1px solid #b1b1b1;
            margin: 10px 0px 0px -13px;
        }

        #logix_CPH_Event_Tracking {
            width: 100%;
            margin: 9px 0px 0px -14px;
        }

        .LostCustomer {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            color: #ffffff;
        }

        .NewCustomer1 {
            width: 9%;
            float: left;
            margin: 0px 0px 0px 0px;
            color: #ffffff;
        }

        .ByRight1 {
            width: 12%;
            float: left;
        }

        .PendingTblGridNewPer1 {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
        }

            .PendingTblGridNewPer1 th {
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

                .PendingTblGridNewPer1 th:last-child {
                    border-right: 1px solid #003a65;
                }

                .PendingTblGridNewPer1 th:first-child {
                    border-left: 1px solid #003a65;
                }

            .PendingTblGridNewPer1 td {
                font-size: 11px;
                color: #4e4c4c;
            }

        .PendingTblGridNewPn1 {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
            width: 100% !important;
        }

            .PendingTblGridNewPn1 th {
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

                .PendingTblGridNewPn1 th:last-child {
                    border-right: 1px solid #003a65;
                }

        .PendingTblGridNew1 th:first-child {
            border-left: 1px solid #003a65;
        }

        .PendingTblGridNewPn1 td {
            font-size: 11px;
        }

        .PendingTbl4Sales {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
            height: 210px;
            overflow: auto;
        }

        .PorttxtNew {
            float: left;
            margin: 1px 0px 0px 0px;
            width: 73px;
        }

        .PorttxtNew1 {
            float: left;
            margin: 1px 1.4% 0px 0px;
            width: 73px;
        }

        .PendingEventSales {
            float: left;
            width: 100%;
            margin: 10px 0px 15px 0px;
        }

        .PendingLeftNew {
            float: left;
            width: 204px;
            margin: 0px 5px 0px -5px;
            min-height: 650px;
        }

        .divSalesN1 {
            float: left;
            width: 102px;
            margin: 0px 0.5% 0px 0px;
        }

        .divSalesN2 {
            float: right;
            width: 104px;
            margin: 0px 0.5% 0px 0px;
        }

        .divSales {
            float: right;
            width: 175px;
            margin: 7px 0.5% 0px 0px;
        }

        .divSales1 {
            float: right;
            width: 197px;
            margin: 0px 0px 0px 0px;
        }

        .PendingTbl4SalesNew {
            width: 198px;
            float: left;
            margin: 0px 5px 0px 0px;
            overflow: auto;
        }

        .div_btn {
            float: right;
            margin-right: 0.5%;
        }

        .PendingRightSales {
            float: left;
            margin: 0px 5px 0px 5px;
            width: 20%;
        }

        #Panel2 {
            margin: 6px 0px 0px -8px;
            float: left;
            float: left;
            width: 100%;
        }

        div#PanelAI {
            width: 100%;
            float: left;
            margin-top: 66px !important;
        }

        .PendingRightSalesCreditEx {
            float: left;
            width: 99%;
            margin: 0px 5px 0px 5px;
        }

        .PendingTblSalOut {
            width: 386px;
            float: left;
            margin: 0px 0px 0px 4px;
            overflow: auto;
            height: 410px;
            /*border: 1px solid #b1b1b1;*/
        }

        .PendingRightSalesNew {
            float: left;
            margin: 0px 0px 0px 5px;
            /*height: 274px;
            width: 530px;*/
        }

        .PortCountryQuation {
            float: left;
            width: 325px;
            margin: 0px 0px 10px 0px;
        }

        .PendingTblSalOutGrd {
            float: left;
            margin: 0px 0px 0px 0px;
            height: 385px;
            border: 0px solid #b1b1b1;
            width: 100%;
            overflow: auto;
        }

        .PendingRightSalesSub {
            float: left;
            /*width: 250px;*/
            margin: 0px 0px 0px 0px;
            width: 100%;
        }

        #programmaticModalPopupBehaviordf4_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .pnlgrd {
            width: 100%;
            height: 265px;
            overflow: auto;
            margin: 6px 0px 0px -13px;
        }

        #AePopUpNewDate {
            left: 12.5px !important;
        }

        /*.divRoated
        {
           width: 1042px;
            Height:303px;            
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/
        .DivSecPanel {
            width: 20px;
            Height: 20px;
            margin-left: 96.3%;
            margin-top: -7%;
            /*border:1px solid blue;*/
            border-radius: 90px 90px 90px 90px;
        }

        .Gridpnl {
            width: 100%;
            Height: 498px;
            margin-bottom: 0.5%;
            margin-left: 0.2%;
            /*margin-left:0.2%;
            overflow-y :scroll;*/
            background-color: #ffffff !important;
            overflow: auto;
        }

        .frames {
            width: 99.5%;
            height: 97%;
        }

        #GrdFEIBL th {
            text-align: center !important;
        }

        #AePopUpNewDate {
            top: 35px !important;
        }

        .divbtn1 {
            width: 179px;
            background-color: #2c60a1;
            float: left;
            margin: 2px 0.5% 0px 0px;
            text-align: center;
        }

            .divbtn1 a {
                display: inline-block;
                padding: 5px;
                color: #dce9f9;
                margin: 0px;
            }

        .divbtn2 {
            width: 179px;
            background-color: #0092fb;
            float: left;
            margin: 2px 0.5% 0px 0px;
            text-align: center;
        }

            .divbtn2 a {
                display: inline-block;
                color: #f5ffdf;
                padding: 5px;
                margin: 0px;
            }

        .divbtn3 {
            width: 179px;
            text-align: center;
            background-color: #883028;
            float: left;
            margin: 2px 0% 0px 0px;
        }

            .divbtn3 a {
                display: inline-block;
                color: #dfe1dd;
                padding: 5px;
                margin: 0px;
            }

        .PendingLeft1 {
            float: left;
            width: 180px;
            margin: 0px 0.5% 0px 0px;
        }

            .PendingLeft1 h3 {
                font-size: 14px;
            }

        .PendingLeft2 {
            float: left;
            width: 400px;
            margin: 0px 0% 0px 0%;
        }

            .PendingLeft2 h3 {
                font-size: 14px;
            }

        .PendingLeft3 {
            float: left;
            width: 135px;
            margin: 0px 0.5% 0px 0.5%;
        }

            .PendingLeft3 h3 {
                font-size: 14px;
            }

        .PendingBookingSalesHome {
            float: left;
            width: 814px;
            margin: 5px 0px 0px 0px;
        }

        .PendingLeft4 {
            float: left;
            width: 542px;
            margin: 0px 0px 0px 0px;
        }

        .PendingTbl2 {
            width: 191px;
            float: left;
            margin: 5px 0px 0px 10px;
            max-height: 136px;
            min-height: 449px;
            overflow: auto;
        }

        .TblScroll {
            height: 380px;
            border: 1px solid #003a65;
        }

        #Panel5 {
            float: left;
            width: 100%;
        }

        .Unclosed {
            float: left;
            width: 192px;
            margin: 0px 0px 0px 5px;
        }

        .panel-title {
            color: #2F3C4D !important;
            font-size: 14px;
            font-weight: 400;
            text-overflow: ellipsis;
            white-space: nowrap;
            font-weight: bold;
        }

        .SalesTitleBN1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: -16px 0px 0px 9px;
            padding: 0px 5px 2px 0px;
            color: #4e4c4c;
        }

        .FromLabel4 {
            width: 2%;
            float: left;
            margin: 4px 0.5% 0px 0px;
        }

        .ToLabel4 {
            width: 1%;
            float: left;
            margin: 3px 0.5% 0px 0px;
        }

        .BandTop img {
            padding: 0px 4px 0px 5px;
        }

        .BandTop h3 {
            color: #ffffff;
            padding: 0px 5px 0px 5px;
            margin: 0px 0px 0px 0px;
        }

            .BandTop h3 a {
                color: #ffffff;
                font-size: 11px;
                font-family: sans-serif;
                padding: 0px 5px 0px 0px;
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

        .PendingBookingSalesHome ul {
            padding: 0px 0px 0px 0px;
            margin: 0px 0px 0px 0px;
        }

        .PendingBookingSalesHome li {
            list-style: none;
            float: left;
            padding: 0px 20px 10px 0px;
            margin: 0px 0px 0px 0px;
        }

            .PendingBookingSalesHome li img {
                list-style: none;
                padding: 0px 5px 0px 0px;
                margin: 0px 0px 0px 0px;
            }

            .PendingBookingSalesHome li a {
                color: #184684;
                text-decoration: none;
                font-size: 14px;
                font-weight: normal;
            }

        .SalesTitle {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 0px;
            padding: 0px 5px 2px 0px;
            color: #4e4c4c;
        }

        .SalesTitleB {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 4px;
            padding: 0px 5px 2px 0px;
            color: #4e4c4c;
        }

        .SalesTitleB1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 9px;
            padding: 0px 5px 2px 0px;
            color: #4e4c4c;
        }

        .widget.box .widget-content {
            padding: 0px 10px 0px 10px;
            position: relative;
            background-color: #fff;
            display: block;
            overflow: hidden;
        }

        .PortCountryC {
            float: left;
            width: 515px;
            margin: 0px 0px 0px -4px;
        }

        .TblHeight4 {
            border: 0px solid #b1b1b1;
            margin: 9px 3px 0px 8px;
        }

        #Panel7 {
            float: left;
            width: 100%;
            margin: -3px 0px 0px 10px;
        }

        #classDiv {
            float: left;
            width: 27.9%;
            margin: -16px 0px 0px 10px;
        }

        .POLForm {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PODForm {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        /*.modalPopupss {
            background-color: #FFFFFF !important;
            border-width: 0px;
            border-style: solid;
            border-color: #CCCCCC;
            width: 100%;
            /*Height: 264px;
            margin-left: 0%;
            margin-top: 0.5%;
            background-color: #ffffff;
        }*/





        .SalesTitleNew {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 2px 0px;
            margin: 10px 0px 0px -2px;
            color: #4e4c4c;
            float: left;
            width: 80px;
        }

        .SalesTitleNew1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 2px 0px;
            color: #4e4c4c;
            float: left;
            width: 100px;
        }

        .divSalesNew {
            float: right;
            width: 101px;
            margin: 0px 0.5% 0px 0px;
        }

        .MB3 {
            margin-bottom: 3px !important;
            margin-right: 10px;
            margin-top: 10px;
        }

        .PendingTblGrid td {
            font-family: sans-serif, Geneva, sans-serif;
            font-size: 11px;
            color: #515151;
            border: 1px solid #b1b1b1;
            padding: 2px 3px 3px 3px;
        }

        .SalesTitlePer {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 1px 0px -5px 0px;
            padding: 2px 5px 0px 0px;
            color: #4e4c4c;
            width: 188px;
            float: left;
        }

        .SalesTitlePerP {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 4px 0px 0px 0px;
            padding: 2px 5px 0px 0px;
            color: #4e4c4c;
            width: 300px;
            float: left;
        }

        .PendingRightnewLRightNew {
            float: left;
            overflow: hidden;
            width: 315px;
            margin: 0px 0px 0px 5px;
            background-color: var(--white);
            position: relative;
            left: 0px;
            display: none;
        }

        .PendingRightnewLRightNew1 {
            float: left;
            overflow: hidden;
            width: 492px;
            margin: 0px 0px 0px 5px;
            background-color: var(--white);
            position: relative;
            left: 8px;
        }

        .SalesTitlePer1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 2px 0px;
            padding: 2px 5px 2px 0px;
            color: #4e4c4c;
            width: 300px;
            float: left;
        }

        .divSalesN1 {
            float: right;
            width: 85px;
            margin: 0px 0.5% 0px 0px;
        }

        .TblWidScroll {
            overflow: auto;
            height: 190px;
            width: 84.9%;
            margin: 32px 10px 10px 10px;
        }

        .GrdAltRow {
            background-color: #cee9fd;
            color: Black;
            font-family: sans-serif;
            font-size: 8pt;
            margin-bottom: 0;
            margin-left: 4px;
        }

        .btn-get input {
            color: #ffffff !important;
        }

        .grid_1 {
            float: left;
            width: 78.9%;
            margin: 0px 0px 10px 0px;
        }

        .grid_2 {
            float: left;
            width: 84.9%;
            margin: 32px 0px 10px 0px;
        }

        .grid_3 {
            float: left;
            margin: 2px 0 10px -8px;
            width: 84.9%;
            min-height: 380px;
            /*border:1px solid #003a65 !important;*/
        }

        .PendingTblGrid th {
            background-color: #003a65;
            border-right: 1px solid #edf8ff;
            border-top: 1px solid #003a65;
            color: #ffffff;
            font-family: sans-serif,Geneva,sans-serif;
            font-size: 11px;
            margin: 0;
            padding: 5px 2px 5px 3px;
            text-align: left;
        }

            .PendingTblGrid th:last-child {
                border-right: 1px solid #003a65;
            }

            .PendingTblGrid th:first-child {
                border-left: 1px solid #003a65;
            }

        #cutnew {
            width: 27.5%;
            float: left;
            margin: 0px 10px 0px 0px;
        }

        #pnl_credit {
            height: 372px;
            overflow-x: hidden;
            overflow-y: auto;
            margin: 0px 0px 0px -10px;
        }

        .PendingRightSalesNewQ {
            float: left;
            margin: -10px 0 0 -4px;
            width: 100%;
        }

        .MB2 {
            margin-bottom: 4px;
            margin-top: 3px;
            margin-right: 1px;
        }

        .SalesTitleB2 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px -10px;
            padding: 5px 5px 2px 0px;
            color: #4e4c4c;
            width: 300px;
            float: left;
        }

        .SalesTitleB3 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px -12px 0px;
            padding: 2px 5px 2px 0px;
            color: #4e4c4c;
            width: 220px;
            float: left;
        }

        .SalesTitleB4 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: -8px 0px 0px -10px;
            padding: 2px 5px 2px 0px;
            color: #4e4c4c;
            width: 380px;
            float: left;
        }

        .PendingRightSalesN12 {
            margin: 0px 0px 0px -6px;
        }

        .Hide {
            display: none;
        }

        .form-control {
            height: 23px;
            font-size: 11px;
            -webkit-border-radius: 0;
            -moz-border-radius: 0;
            border-radius: 0;
            text-transform: uppercase;
            padding: 1px 0px 1px 1px !important;
        }

        .PaDtopCtrl {
            padding: 2px 0px 0px 0px !important;
        }

        .MB13 {
            margin-top: -8px !important;
            margin-right: 4px;
        }

        .SalesTitleNewWip {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 2px 0px;
            margin: -8px 0px 0px 0px;
            color: #4e4c4c;
            width: 130px;
            float: left;
        }

        #Panel9 {
            height: 380px;
            overflow-x: hidden;
            overflow-y: auto;
            margin: -16px 0px 0px 2px;
            width: 100%;
        }

        .hide {
            display: none;
        }

        /*.HideGet {
            display:none;
        }*/

        .PieChart {
            float: left;
            width: 800px;
            margin: 15px 0px 0px 40px;
        }

            .PieChart img {
                width: 550px;
                height: 100%;
            }

        .MBC2 {
            margin-bottom: 2px !important;
        }

        .Chart1 {
            width: 650px;
            float: left;
            margin: 10px 0px 0px 15px;
        }

        .Chart2 {
            width: 582px;
            float: left;
            margin: 10px 10px 0px 0px;
        }

        .grid_P3 {
            float: left;
            margin: -3px 0 3px -8px;
            width: 84.9%;
        }

        .SalesTitlePerN1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: -3px 0px 0px 8px;
            padding: 2px 5px 0px 0px;
            color: #4e4c4c;
            width: 188px;
            float: left;
        }

        .SalesTitleBooking {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: -15px 0px 5px 0px;
            padding: 0px 5px 2px 0px;
            color: #4e4c4c;
        }

        .SalesTitleBooking1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 5px 0px;
            padding: 0px 5px 2px 0px;
            color: #4e4c4c;
        }

        .MB21 {
            margin-bottom: 4px;
            margin-top: -10px;
            margin-right: 1px;
        }

        .PendingRightnew1 {
            float: left;
            width: 452px;
            margin: 0px 0px 0px -6px;
            background-color: var(--white);
            position: relative;
            left: -7px;
        }

        .PendingRightnew2 {
            float: left;
            width: 376px;
            margin: 0px 0px 0px 10px;
        }

        .PendingTbl3 {
            width: 1342px;
            float: left;
            margin: 7px 0px 0px 0px;
            height: 264px;
            max-height: 264px;
            overflow-y: auto;
            overflow-x: auto;
            border: 1px solid #b1b1b1;
        }

        .PendingTblGrid {
            border: 0 solid #b1b1b1;
            border-collapse: collapse;
        }

        .PendingRight {
            float: left;
            width: 150px;
            margin: 0px 0px 0px 10px;
        }

        .PortCountryJob h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 76px 0px 0px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }

        .PortCountryJobNew3 h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            /*margin: 4px 0px -2px -15px;*/
            padding: 2px 0px 0 0;
            /*width: 700px;*/
        }

        .PendingRightnew3 {
            float: left;
            width: 218px;
            margin: 0px 0px 0px 10px;
        }

        .lbl_cutlnkAI {
            color: #963634;
        }

        .lbl_cutlnkBT {
            color: #8a933c;
        }

        .lbl_cutlnkCH {
            color: #60497a;
        }

        .lbl_cutlnkOE {
            color: #974706;
        }

        .lbl_cutlnkOI {
            color: #215967;
        }

        .PendingRightnewComapp {
            float: left;
            width: 100%;
            /*margin: 5px 0px 0px -15px;*/
            margin-top: 65px !important;
        }

        .ToLabel4 span {
            font-size: 11px;
            color: #ffffff !important;
        }

        .VolumeGrid {
            width: 100%;
            height: 255px;
            overflow: auto;
        }

        .div_grdFI {
            width: 100%;
            height: 250px;
            overflow: auto;
        }

        /* FixedHeader */

        div#logix_CPH_pnl_MISA,
        div#logix_CPH_Panel_MISC,
        div#logix_CPH_pnl_MISB,
        div#logix_CPH_Panel_MISD {
            height: 107px;
            overflow: auto;
            border: 1px solid var(--inputborder);
            margin: 5px 0;
        }

        div#logix_CPH_Pln_MIS {
            padding: 0 10px 0 0;
        }

        .div_chat {
            display: none;
        }

        .btn.btn-get1 {
            margin: 15px 0 0 0;
        }

        .OutstandingBox h3 {
            padding: 2px 5px 0px 10px;
        }

        div#logix_CPH_div_line, div#logix_CPH_div2_Bookchart, div#logix_CPH_div_bar {
            margin: 6px 0px 0px 0px;
            display: none;
        }

        div#logix_CPH_outstanding {
            width: 99.5%;
        }

        div#logix_CPH_PanelAI {
            width: 99.5%;
        }

        .row {
            height: 290px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            /* width: 100%; */
        }

            .row.PaDtopCtrl {
                height: 290px !important;
            }

        /*h3#logix_CPH_h1 {
            margin: 10px 0 10px 10px;
        }*/

        div#logix_CPH_Pnl_total_grid {
            width: 99.5%;
        }

        a#logix_CPH_btn_Export {
            margin-left: 10px;
        }

        div#logix_CPH_bnt_cancel1 {
            margin-right: 8px;
        }

        div#logix_CPH_Panel3 {
            width: 99.5%;
        }

        div#logix_CPH_PanelOE {
            position: relative;
        }

        div#logix_CPH_Panel4 {
            width: 99.5%;
        }

        div#logix_CPH_PanelOI {
            width: 99.5%;
        }

        .MT25 {
            margin-top: 0px !important;
        }

        .shadow_box {
            height: 75px !important;
            padding: 5px !important;
        }

        .shadow_box1 {
            height: 60px !important;
            padding: 5px !important;
        }

        table#logix_CPH_GRD_DoRegister th {
            font-weight: normal;
            border-right: 1px solid var(--inputborder);
        }

        /*.HomeMenuBox {
    height: 79vh !important;
    position:relative;
    top:-30px;
}*/
        .borderremove text {
            font-weight: normal;
        }

        .btn.ico-get {
            margin-top: 12px;
        }

        .HomeMenuContent {
            width: 84%;
            float: left;
            /*margin-top: 21px;*/
        }
        /*.gridpnl {
    height: calc(100vh - 122px);
}*/
        .HomeMenuBox {
            width: 14% !important;
            float: left !important;
            display: flex !important;
            flex-direction: column !important;
            justify-content: space-around !important;
            height: 110vh !important;
            padding-top: 102px;
            position: relative;
            top: -124px;
        }

      form#form1 {
    overflow-y: auto;
    margin-top: 25px;
     height: 98vh !important;
 
}

        .modalPopupss iframe {
            width: 100% !important;
            height: 90vh !important;
            overflow: auto !important;
            bottom: 0px !important;
            margin: 0 !important;
            border: 0 !important;
        }

        table#grdyear tbody tr td:nth-child(1) {
            background: white !important;
        }

        table#grdyear tbody tr td:nth-child(2) {
            background: white !important;
        }

        table#grdyear tbody tr td:nth-child(3) {
            background: white !important;
        }

        table#grdyear tbody tr:nth-child(2) td {
            background: white !important;
        }
    </style>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=lnk_PendingHBL]").click(function () {
                ShowPopup();
                return false;
            });

            $("[id*=lnk_PendingHBL]").click(function () {
                ShowPopup1();
                return false;
            });
            $("[id*=lnk_PendingMBL]").click(function () {
                ShowPopup2();
                return false;
            });
            $("[id*=lnk_unclosedjobs]").click(function () {
                ShowPopup3();
                return false;
            });
            $("[id*=lnk_PendingApproval]").click(function () {
                ShowPopup4();
                return false;
            });
        });

        function ShowPopup() {
            $("#dialog").dialog({
                title: "Booking Details",
                width: 200,
                height: 270,
                modal: true
            });
        }

        function ShowPopup1() {
            $("#dialog1").dialog({
                title: "HBL",
                width: 200,
                height: 270,
                modal: true
            });
        }
        function ShowPopup2() {
            $("#dialog2").dialog({
                title: "MBL",
                width: 200,
                height: 270,
                modal: true
            });
        }
        function ShowPopup3() {
            $("#dialog3").dialog({
                title: "Unclosed",
                width: 200,
                height: 270,
                modal: true
            });
        }
        function ShowPopup4() {
            $("#dialog4").dialog({
                title: "Approval",
                width: 200,
                height: 270,
                modal: true
            });
        }

    </script>

    <%-- MIS --%>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -0.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .ddl_graph {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            text-align: center;
        }

            .ddl_graph input, select {
                width: 100%;
            }

        .ddl_graph1 {
            width: 13.5%;
            float: left;
            margin-top: 1%;
            margin-left: 0%;
            text-align: center;
        }

            .ddl_graph1 input, select {
                width: 100%;
            }

        .DivAllChart2 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
        }

        .DivAllChart3 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
        }

        .DivAllChart4 {
            Width: 23%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
        }

        .DivAllChart5 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-top: 2%;
            margin-left: 1%;
        }

        .DivAllChart6 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
            margin-top: 2%;
        }

        .DivAllChart7 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
            margin-top: 2%;
        }

        .DivAllChart8 {
            Width: 23%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
            margin-top: 2%;
        }

        .Break {
            clear: both;
        }

        .BandTop {
            float: left;
            padding: 0px 2px 0px 45px;
            margin: -4px 0 0 0;
            display: block;
            border-bottom: 0px solid #e0e0e0;
        }

        div#UpdatePanel1 {
            height: 93vh;
            overflow-x: hidden;
            overflow-y: hidden;
        }

        .panel_17 {
            max-height: 73vh !important;
            min-height: 73vh !important;
        }

        .cal {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .calnew {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        div#ddl_Report_chzn {
    width: 100% !important;
}
        .ReportBranch {
            width: 26%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .fil {
            width: 31.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .fil input {
                cursor: default !important;
            }

        .chzn-drop {
            height: 275px !important;
        }

        #IMGDIV {
            top: 300px !important;
            position: absolute;
            z-index: 9999999;
        }

        .row {
            height: 320px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            /* width: 100%; */
        }

        .div_GridNew3 {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 216px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow: auto;
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

        .Divimg {
            width: 13%;
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .NewBlueOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 8px;
        }

            .NewBlueOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewBlueRightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 5px 10px 0px 0px;
            float: right;
            text-align: right;
            width: 75%;
            font-size: 21px;
        }

        .NewGreenOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewGreenOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewGreenRightSideDown {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .NewLiteBlueOuter {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewLiteBlueOuter:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewLtBlueRightSideDown {
            color: #36b9cc !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .NewYellowOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #f6c23e !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewYellowOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewYellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
            /*transform: rotate(-179deg);*/
        }

        .NewGreenOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewGreenOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewGreenRightSideDown2 {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            float: right;
            font-family: 'OpenSansSemibold';
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .NewBlueOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewBlueOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewBlue2RightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 0px 10px 0px 0px;
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .NewRedOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #e74a3b !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewRedOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewRedRightSideDown {
            color: #e74a3b !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }
    </style>

    <style type="text/css">
        .VoyageInputN4New {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OutstandingBox {
            float: left;
            height: 126px;
            /* margin: -4px 0px -11px 10px; */
            width: 100%;
        }

        @media screen and (-webkit-min-device-pixel-ratio:0) {

            .OutstandingBox {
                margin: 0px 0 10px;
            }
        }

        .FromLabel4 span {
            color: #ffffff !important;
        }

        .ML8 {
            margin-left: 0px !important;
        }

        .divTues {
            width: 65%;
            float: left;
        }

        .FromLabl {
            color: #ffffff !important;
        }

        .ToLabel6 {
            color: #ffffff;
        }

        .ByLabel1 {
            color: #ffffff;
        }

        .MR25 {
            margin-right: 25px;
        }

        .btn-get1 input.txtclr {
            color: #ffffff !important;
        }

        .MR4 {
            margin-right: 5px !important;
        }

        ul#breadcrumbs {
            background: none;
        }

        .BandMiddle, .BandTop {
            width: 100%;
            position: relative;
            z-index: 13;
        }

        .left_btn p {
            margin: 0px 0px 0px 8px;
            font-size: 12px;
            color: var(--grey);
        }
    </style>

    <style type="text/css">
        @media only screen and (max-width: 1280px) {

            .PendingTbl3 {
                width: 100%;
                float: left;
                margin: 7px 0px 0px -8px;
                height: 285px;
                max-height: 285px;
                overflow: auto;
                border: 1px solid #b1b1b1;
            }
        }

        table#logix_CPH_grdyear td {
            color: #fff !important;
        }

        div#chart {
            width: 100% !important;
            margin: 38px 0px 0px 55px !important;
        }

        .piechart1 {
            float: left;
            width: 24%;
            margin: 0px 0.5% 0px 0px;
            font-size: 14px;
        }

        .TitleLeft1 {
            float: left;
            margin: 0px 0px 0px 0px !important;
        }

        div#div4 {
            display: none;
        }

        div#panelSerch {
            Height: 696px !important;
        }
 
 
    </style>

    <%-- MIS END --%>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <%--  <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>--%>
    <%-- <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>--%>
    <%--    <link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />--%>

    <%--TEST--%>
</head>
<body>
    <script type="text/javascript">
        // Global variable to hold data
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: '../Home/MISAndApproval.aspx/GetChartDataBooking',
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
        })

        function drawchart(dataValues) {

            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Column Name');

            data.addColumn('number', 'Column Value');

            for (var i = 0; i < dataValues.length; i++) {

                data.addRow([dataValues[i].Countryname, dataValues[i].Total]);

            }

            new google.visualization.PieChart(document.getElementById('chartdiv1')).
                draw(data, {
                    height: "300", title: "Outstanding", colors: ['#4ebcd5', '#bce3c8', '#408fdc', '#5765b2'],
                });

        }

    </script>

    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

                $("#<%=txt_Filter.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hidId.ClientID %>").val(0);
                        $.ajax({
                            url: "../Home/MISAndApproval.aspx/GetCustomers",
                            data: "{ 'prefix': '" + request.term + "','FType':'" + $("#<%=hid_text.ClientID %>").val() + "'}",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_Filter.ClientID %>").change();
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hidId.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

      <%--   $(document).ready(function () {

                var GridId = "<%=GridView2.ClientID %>";
                 var ScrollHeight = 220;

                 //window.onload = function () {
                 var grid = document.getElementById(GridId);
                 var gridWidth = grid.offsetWidth;
                 var gridHeight = grid.offsetHeight;
                 var headerCellWidths = new Array();
                 for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                     headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
                 }
                 grid.parentNode.appendChild(document.createElement("div"));
                 var parentDiv = grid.parentNode;

                 var table = document.createElement("table");
                 for (i = 0; i < grid.attributes.length; i++) {
                     if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                         table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                     }
                 }
                 table.style.cssText = grid.style.cssText;
                 table.style.width = gridWidth + "px";
                 table.appendChild(document.createElement("tbody"));
                 table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
                 var cells = table.getElementsByTagName("TH");

                 var gridRow = grid.getElementsByTagName("TR")[0];
                 for (var i = 0; i < cells.length; i++) {
                     var width;
                     if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                         width = headerCellWidths[i];
                     }
                     else {
                         width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                     }
                     cells[i].style.width = parseInt(width - 3) + "px";
                     gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
                 }
                 parentDiv.removeChild(grid);

                 var dummyHeader = document.createElement("div");
                 dummyHeader.appendChild(table);
                 parentDiv.appendChild(dummyHeader);
                 var scrollableDiv = document.createElement("div");
                 if (parseInt(gridHeight) > ScrollHeight) {
                     gridWidth = parseInt(gridWidth) + 17;
                 }
                 scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
                 scrollableDiv.appendChild(grid);
                 parentDiv.appendChild(scrollableDiv);
             });--%>

            function DoAction(Text) {
                $("#<%=hd_op.ClientID %>").val('');
                $("#<%=hd_op.ClientID %>").val(Text);
                $("#<%=btn_show.ClientID %>").click();
            }
            $(function () {
                $(".grd_operProfit_AC > tbody > tr:not(:has(table, th))")
                    .css("cursor", "pointer")
                    .click(function (e) {
                        $(".grd_operProfit_AC td").removeClass("highlite");
                        var $cell = $(e.target).closest("td");
                        $cell.addClass('highlite');
                        var $currentCellText = $cell.text();
                        var $leftCellText = $cell.prev().text();
                        var $rightCellText = $cell.next().text();
                        var $colIndex = $cell.parent().children().index($cell);
                        var $colName = $cell.closest("table")
                            .find('th:eq(' + $colIndex + ')').text();
                        $("#para").empty()
                            .append("<b>Current Cell Text: </b>"
                                + $currentCellText + "<br/>")
                            .append("<b>Text to Left of Clicked Cell: </b>"
                                + $leftCellText + "<br/>")
                            .append("<b>Text to Right of Clicked Cell: </b>"
                                + $rightCellText + "<br/>")
                            .append("<b>Column Name of Clicked Cell: </b>"
                                + $colName)
                    });

            });
        }

    </script>

    <%--<script type="text/javascript">
        function DoAction(Text) {
            $("#<%=hd_op.ClientID %>").val('');
            $("#<%=hd_op.ClientID %>").val(Text);
            $("#<%=btn_show.ClientID %>").click();
        }
    </script>--%>

    <%--    <script type="text/javascript">
        $(function () {
            $(".grd_operProfit_AC > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".grd_operProfit_AC td").removeClass("highlite");
                    var $cell = $(e.target).closest("td");
                    $cell.addClass('highlite');
                    var $currentCellText = $cell.text();
                    var $leftCellText = $cell.prev().text();
                    var $rightCellText = $cell.next().text();
                    var $colIndex = $cell.parent().children().index($cell);
                    var $colName = $cell.closest("table")
                        .find('th:eq(' + $colIndex + ')').text();
                    $("#para").empty()
                    .append("<b>Current Cell Text: </b>"
                        + $currentCellText + "<br/>")
                    .append("<b>Text to Left of Clicked Cell: </b>"
                        + $leftCellText + "<br/>")
                    .append("<b>Text to Right of Clicked Cell: </b>"
                        + $rightCellText + "<br/>")
                    .append("<b>Column Name of Clicked Cell: </b>"
                        + $colName)
                });

        });

    </script>--%>
    <%--</asp:Content>--%>
    <%--<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">--%>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div class="Clear"></div>
        <div class="maindiv">
        <div class="BandMiddle hide">

            <div class="BreadLabel" id="OptionDoc" runat="server">MIS and Analytics</div>
        </div>

        <div class="BandTop">
            <div class="Clear"></div>
            <div class="BandLeft">
                <%-- <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png"/>
                    <asp:LinkButton ID="lnkNewCustomerRequest" runat="server" Style="text-decoration: none">New Customer Request</asp:LinkButton></h3>--%>
            </div>

            <div class="BandRight">

                <div style="float: left; margin-right: 20px;">
                    <%--<h3>
                        <img src="../Theme/assets/img/stationary.png"/><asp:LinkButton ID="lnkauo" runat="server" Text="Quotation Multiport"></asp:LinkButton></h3>--%>
                </div>
            </div>
        </div>

        <div class="FormGroupContent4">

        <div class="HomeMenuBox custom-d-flex custom-mt-05">
            <asp:LinkButton ID="lnkAE" runat="server" OnClick="lnkAE_Click">
                <div class="menubox">
                    <div class="menuboximage">

                        <img src="../Theme/assets/img/dashboard/airexport.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Air Exports </span>
                        <span id="SPANAE" runat="server" class=" Amount1"></span>
                        <asp:LinkButton ID="lnkoutstAE" runat="server" OnClick="lnkoutstAE_Click">
                            <span id="SPoutstAE" runat="server" class="Amount"></span>
                        </asp:LinkButton>
                    </div>
                </div>
            </asp:LinkButton>

            <asp:LinkButton ID="lnkAI" runat="server" OnClick="lnkAI_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/airimport.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Air Imports </span>
                        <span id="SPANAI" runat="server" class=" Amount1"></span>
                        <asp:LinkButton ID="lnkoutstAI" runat="server" OnClick="lnkoutstAI_Click">
                            <span id="SPoutstAI" runat="server" class="Amount"></span>
                        </asp:LinkButton>
                    </div>
                </div>

            </asp:LinkButton>
            <div class="hide">
                <asp:LinkButton ID="lnkBT" runat="server" OnClick="lnkBT_Click">

                    <div class="menubox">
                        <div class="menuboximage">
                            <img src="../Theme/assets/img/dashboard/testimage48.png" />
                        </div>
                        <div class="menuboxcontent">
                            <span class="title">Bonded Trucking </span>
                            <span id="SPANBT" runat="server" class=" Amount1"></span>
                            <asp:LinkButton ID="lnkoutstBT" runat="server" OnClick="lnkoutstBT_Click">
                                <span id="SPoutstBT" runat="server" class=" Amount"></span>
                            </asp:LinkButton>

                        </div>
                    </div>

                </asp:LinkButton>

                <asp:LinkButton ID="lnkCH" runat="server" OnClick="lnkCH_Click">
                    <div class="menubox">
                        <div class="menuboximage">
                            <img src="../Theme/assets/img/dashboard/testimage48.png" />
                        </div>
                        <div class="menuboxcontent">
                            <span class="title">Customs Broking</span>
                            <span id="spanCH" runat="server" class=" Amount1"></span>
                            <asp:LinkButton ID="lnkoutstCH" runat="server" OnClick="lnkoutstCH_Click">
                                <span id="SPoutstCH" runat="server" class=" Amount"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </asp:LinkButton>
            </div>




            <asp:LinkButton ID="lnkOE" runat="server" OnClick="lnkOE_Click">

                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/exports.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Ocean Exports  </span>
                        <span id="SpanOE" runat="server" class=" Amount1"></span>
                        <asp:LinkButton ID="lnkoutstOE" runat="server" OnClick="lnkoutstOE_Click">
                            <span id="SPoutstOE" runat="server" class="Amount"></span>
                        </asp:LinkButton>
                    </div>
                </div>

            </asp:LinkButton>

            <asp:LinkButton ID="lnkOI" runat="server" OnClick="lnkOI_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/imports.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Ocean Imports  </span>
                        <span id="SpanOI" runat="server" class=" Amount1"></span>
                        <asp:LinkButton ID="lnkoutstOI" runat="server" OnClick="lnkoutstOI_Click">
                            <span id="SPoutstOI" runat="server" class="Amount"></span>
                        </asp:LinkButton>
                    </div>
                </div>

            </asp:LinkButton>

            <asp:LinkButton ID="lnkTotRen" runat="server" OnClick="lnkTotRen_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/summation.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Total </span>
                        <span id="SpanTOTAL" runat="server" class=" Amount1"></span>
                        <asp:LinkButton ID="lnkoutsttot" runat="server" OnClick="lnkoutsttot_Click">
                            <span id="SPoutsttot" runat="server" class="Amount"></span>
                        </asp:LinkButton>
                    </div>
                </div>

            </asp:LinkButton>

        </div>

        <div class="HomeMenuContent" runat="server">
            <div class="FormGroupContent4">
                <%--<div id="txt_mis" runat="server" visible="true">--%>

                <div class="calnew" style="margin-left: 0px;">
                    <asp:Label ID="lbl_From" runat="server" Text="From" CssClass="hide"></asp:Label>
                    <asp:TextBox ID="txt_From" runat="server" CssClass="form-control" TabIndex="1" placeholder="From"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_From" Format="dd/MM/yyyy"></asp:CalendarExtender>
                </div>

                <div class="calnew">
                    <asp:Label ID="lbl_To" runat="server" Text="To" CssClass="hide"></asp:Label>
                    <asp:TextBox ID="txt_To" runat="server" CssClass="form-control" TabIndex="2" placeholder="To"></asp:TextBox>
                    <asp:CalendarExtender ID="dt_validity" runat="server" TargetControlID="txt_To" Format="dd/MM/yyyy"></asp:CalendarExtender>
                </div>
                <%-- </div>--%>

                <div class="VoyageInputN4New fit-content">
                    <asp:DropDownList ID="ddl_product" TabIndex="3" AutoPostBack="true" runat="server" Width="100%" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="ReportBranch">
                    <asp:DropDownList ID="ddl_Report" TabIndex="4" runat="server" ToolTip="Report" data-placeholder="Report"
                        OnSelectedIndexChanged="ddl_Report_SelectedIndexChanged" AutoPostBack="True" CssClass="chzn-select">
                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="div_mis1" runat="server" visible="true">
                    <div class="fil">
                        <asp:TextBox ID="txt_Filter" runat="server" CssClass="form-control" placeholder="" ToolTip="Filter"></asp:TextBox>
                    </div>
                    <div class="btn ico-get">
                        <asp:Button ID="btn_Get" runat="server" Text="Get" CssClass="txtclr" ToolTip="Get" OnClick="btn_Get_Click" />
                    </div>
                    <div class="Break"></div>

                    <div class="ddl_graph" style="display: none; position: relative;">
                        <asp:DropDownList ID="ddl_graph1" runat="server" CssClass="chzn-select" ToolTip="Report Type" AutoPostBack="True" data-placeholder="Report Type" Width="100%" OnSelectedIndexChanged="ddl_graph1_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1">Data</asp:ListItem>
                            <asp:ListItem Value="2">Graph</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="ddl_graph1" style="display: none; position: relative;">
                        <asp:DropDownList ID="ddl_graph2" runat="server" CssClass="chzn-select" data-placeholder="Graph" ToolTip="Graph" AutoPostBack="True" Visible="false" Width="100%" OnSelectedIndexChanged="ddl_graph2_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1">Line</asp:ListItem>
                            <asp:ListItem Value="2">Bar</asp:ListItem>
                            <asp:ListItem Value="3">Pie</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="div_customerwise" runat="server" visible="false" style="float: left; width: 24%;">
                    <div class="ByDrop1">
                        <asp:DropDownList ID="ddl_By" runat="server" CssClass="chzn-select" ToolTip="By" data-placeholder="BY">
                            <%--  <asp:ListItem Text=""></asp:ListItem>--%>
                            <asp:ListItem Value="1" Text="ETA"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Job Close"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="btn ico-get" style="color: #fff!important;">
                        <asp:Button ID="btnGet" ToolTip="Get" runat="server" OnClick="btnget_Click" />
                    </div>

                    <div class="btn ico-cancel" id="btncanid" runat="server">
                        <asp:Button ID="btncancel" ToolTip="Cancel" runat="server" OnClick="btncancel_Click" />
                    </div>

                </div>
                <div class="divTues" id="div_tues" runat="server" visible="false">

                    <div class="ByDrop2">
                        <asp:Label ID="Label3" Text="From" runat="server" CssClass="hide"></asp:Label>
                        <asp:DropDownList ID="ddl_From" runat="server" CssClass="chzn-select" placeholder="From" ToolTip="From"></asp:DropDownList>
                    </div>
                    <div class="FromCal6">
                        <asp:TextBox ID="txt_From1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="ByDrop2">
                        <asp:Label ID="Label4" Text="To" runat="server" CssClass="hide"></asp:Label>
                        <asp:DropDownList ID="ddl_To" runat="server" CssClass="chzn-select" ToolTip="To" placeholder="To"></asp:DropDownList>
                    </div>
                    <div class="Tocal7">
                        <asp:TextBox ID="txt_To1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="ByDrop2">
                        <asp:Label ID="lbl_By" Text="By" runat="server" CssClass="hide"></asp:Label>
                        <asp:DropDownList ID="ddl_by1" runat="server" CssClass="chzn-select" ToolTip="By" data-placeholder="By">
                            <asp:ListItem Value="0" Text="">  </asp:ListItem>
                            <asp:ListItem Value="1">ETA</asp:ListItem>
                            <asp:ListItem Value="2">Job Close</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="right_btn">
                        <div class="btn ico-get" style="color: #fff!important;">
                            <asp:Button ID="btn_gettues" ToolTip="Get" runat="server" OnClick="btn_gettues_Click" />
                        </div>

                        <div class="btn ico-cancel" id="btn_clear1" runat="server">
                            <asp:Button ID="btn_clear" ToolTip="Clear" runat="server" OnClick="btn_clear_Click" />
                        </div>
                    </div>
                </div>

                <div id="event_track" runat="server" class="right_btn" visible="false">

                    <div class="btn ico-get" style="color: #fff!important;">
                        <asp:Button ID="btn_get_event" ToolTip="Get" runat="server" OnClick="btn_get_event_Click" />
                    </div>

                    <div class="btn ico-cancel" id="btn_cancel_event1" runat="server">
                        <asp:Button ID="btn_cancel_event" ToolTip="Cancel" runat="server" OnClick="btn_cancel_event_Click" UseSubmitBehavior="False" />
                    </div>

                </div>
                <div id="div_newcust" runat="server" visible="false">
                    <div class="LostCustomer">
                        <asp:RadioButton ID="rdLossCust" runat="server" Text="Lost Customer" OnCheckedChanged="rdLossCust_CheckedChanged" AutoPostBack="true" />
                    </div>
                    <div class="NewCustomer1">
                        <asp:RadioButton ID="rdNewCust" runat="server" Text="New Customer" OnCheckedChanged="rdNewCust_CheckedChanged" AutoPostBack="true" />
                    </div>
                    <div class="ByRight1">
                        <div class="ByLabel" style="display: none;">
                            <asp:Label ID="lbl_by1" Text="By" runat="server"></asp:Label>
                        </div>
                        <div class="ByDropN1">
                            <asp:DropDownList ID="ddlLossCusType" runat="server" data-placeholder="By" CssClass="chzn-select" ToolTip="LOSS CUSTOMER TYPE">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="1">ETA</asp:ListItem>
                                <asp:ListItem Value="2">Job Close</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="right_btn">
                        <div class="btn ico-view">
                            <asp:Button ID="btnView" runat="server" ToolTip="Print" OnClick="btnView_Click" />
                        </div>
                        <div class="btn ico-cancel" id="BtnBack1" runat="server">
                            <asp:Button ID="BtnBack" runat="server" ToolTip="Back" OnClick="BtnBack_Click" />
                        </div>
                    </div>

                </div>
                <div id="txtdiv_fivolume" runat="server" visible="false">
                    <div class="ByDrop2">
                        <asp:DropDownList ID="cmbformat" runat="server" TabIndex="4" CssClass="chzn-select" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="right_btn">
                        <div class="btn ico-cancel">
                            <asp:Button ID="btn_getvolume" runat="server" ToolTip="Get Data" TabIndex="6" OnClick="btn_getvolume_Click" />
                        </div>
                        <div class="btn ico-get" id="btnclear1" runat="server">
                            <asp:Button ID="btnclear" runat="server" ToolTip="Back" TabIndex="7" OnClick="btnclear_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="">
                <!-- Tabs row PaDtopCtrl -->
                <div class="borderremove">

                    <div class="widget-content">

                        <div class="PortCountryJobNew3">
                            <h3 id="h1" runat="server">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </h3>
                        </div>

                        <div class="TitleLeft1">

                            <div runat="server" id="div5" class="PendingRightnewChart">

                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                <div id="chart" runat="server" style="width: 2000px; height: 500px;">
                                </div>
                            </div>
                        </div>

                        <div class="PendingRightnew1" id="div_line" runat="server" style="display: none">
                            <asp:Literal ID="lt" runat="server"></asp:Literal>
                            <div id="Liner_chart_div"></div>

                        </div>

                        <div runat="server" id="div2_Bookchart" class="PendingRightnewLRightNew" style="display: none">
                            <div id="chartdiv1" style="width: 300px; height: 300px; margin-left: 12px;">
                            </div>
                        </div>

                        <div id="div_bar" runat="server" class="PendingRightnewLRightNew1" style="display: none">
                            <asp:Literal ID="lts" runat="server"></asp:Literal>
                            <div id="chart_divbar" style="margin: 0px 0px 0px 0px;"></div>

                        </div>

                        <%-- <div class="FormGroupContent4">
         <div class="TitleLeft1">
                        --%>

                        <%--</div>
            </div>--%>

                        <div class="PortCountryJob">
                            <h3 id="headlbl1" runat="server">
                                <asp:Label ID="lbl_cut" runat="server"></asp:Label>
                            </h3>
                        </div>

                        <div class="Clear"></div>
                        <div id="penBlRelase" runat="server" visible="false">
                            <asp:Panel ID="Panel3" runat="server" Visible="true" CssClass="gridpnl MT0 MB0">

                                <asp:GridView ID="GridView1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <div class="Clear"></div>
                        <div id="PanelAI" runat="server" visible="false">
                            <div style="float: right; margin-right: 13px; margin-top: 0px;">
                                <asp:LinkButton ID="excportexc" runat="server" OnClick="excportexc_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                            </div>
                            <asp:Panel ID="Panel2" runat="server" Visible="true" CssClass="gridpnl MT0 MB0">

                                <asp:GridView ID="GrdAI" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrdAI_RowDataBound" OnPreRender="GrdAI_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="S#" HeaderText="S#">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Branch" HeaderText="Branch">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Product" HeaderText="Product">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Job #" HeaderText="Job #">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>

                                        <asp:BoundField DataField="BPJ" HeaderText="BPJ">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Flight Details" HeaderText="Flight Details">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="ETA" HeaderText="ETA" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ETD" HeaderText="ETD" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Opend On" HeaderText="Opend On" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Closed On" HeaderText="Closed On" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>

                                        <asp:BoundField DataField="Income" HeaderText="Billing" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Expenses" HeaderText="Cost" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <div class="Clear"></div>
                        <div id="PanelOE" runat="server" visible="false">
                            <asp:Panel ID="Panel4" runat="server" Visible="true" CssClass="gridpnl MT0 MB0">

                                <asp:GridView ID="GrdOE" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrdOE_RowDataBound" OnPreRender="GrdOE_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="S#" HeaderText="S#">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Branch" HeaderText="Branch">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Product" HeaderText="Product">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Job #" HeaderText="Job #">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="BPJ" HeaderText="BPJ" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="VSL/Voy" HeaderText="VSL/Voy">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="ETA" HeaderText="ETA" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ETD" HeaderText="ETD" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="POD" HeaderText="POD">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="POL" HeaderText="POL" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Opend On" HeaderText="Opend On" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Closed On" HeaderText="Closed On" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>

                                        <asp:BoundField DataField="Income" HeaderText="Billing" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Expenses" HeaderText="Cost" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <div class="Clear"></div>
                        <div id="PanelOI" runat="server" visible="false">
                            <asp:Panel ID="Panel5" runat="server" Visible="true" CssClass="gridpnl MT0 MB0">

                                <asp:GridView ID="GrdOI" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrdOI_RowDataBound" OnPreRender="GrdOI_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="S#" HeaderText="S#">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Branch" HeaderText="Branch">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Product" HeaderText="Product">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Job #" HeaderText="Job #">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="BPJ" HeaderText="BPJ">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="VSL/Voy" HeaderText="VSL/Voy">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="POD" HeaderText="POD" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="POL" HeaderText="POL">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ETA" HeaderText="ETA" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ETD" HeaderText="ETD" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Opend On" HeaderText="Opend On" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Closed On" HeaderText="Closed On" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />

                                        </asp:BoundField>

                                        <asp:BoundField DataField="Income" HeaderText="Billing" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Expenses" HeaderText="Cost" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <div id="outstanding" runat="server" visible="false">
                            <asp:Panel ID="Panel1" runat="server" Visible="true" CssClass="gridpnl MT0 MB0">

                                <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView2_RowDataBound" GridLines="None" OnPreRender="GridView2_PreRender">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="shortname" HeaderText="Branch" />--%>
                                        <asp:TemplateField HeaderText="Branch">
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
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                    <asp:Label ID="trantype" runat="server" Text='<%# Bind("trantype") %>' ToolTip='<%# Bind("trantype") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="140px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VouType" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                    <asp:Label ID="voutype" runat="server" Text='<%# Bind("voutype") %>' ToolTip='<%# Bind("voutype") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Vou #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                    <asp:Label ID="vouno" runat="server" Text='<%# Bind("vouno") %>' ToolTip='<%# Bind("vouno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                    <asp:Label ID="voudate" runat="server" Text='<%# Bind("voudate") %>' ToolTip='<%# Bind("voudate") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
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
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                                    <asp:Label ID="salesname" runat="server" Text='<%# Bind("salesname") %>' ToolTip='<%# Bind("salesname") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="225px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                                    <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%# Bind("customer") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="250px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
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
                                        <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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

                                        <asp:BoundField DataField="appamt" HeaderText="AppAmt" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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

                                        <asp:BoundField DataField="overdue" HeaderText="OverDue" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />

                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <div runat="server" id="div_mis" class="PendingRightnewComapp" visible="false">

                            <div class="" runat="server" id="div_iframe">

                                <div class="widget-header" style="display: none;">
                                    <h4><i class="icon-umbrella hide"></i>
                                        <asp:Label ID="lbl_Header" runat="server" Text="MIS"></asp:Label>
                                    </h4>
                                </div>

                                <div class="Clear"></div>
                                <div class="FormGroupContent4">
                                    <div class="right_btn">

                                        <div class="btn ico-print">
                                            <asp:Button ID="btn_Print" runat="server" Text="Print" ToolTip="Print" OnClick="btn_Print_Click" />
                                        </div>
                                        <%--<div class="btn btn-export">
                            <asp:Button ID="btn_Export" runat="server" Text="ExportExcel" OnClick="btn_Export_Click" />
                        </div>--%>

                                        <div class="btn ico-cancel" id="bnt_cancel1" runat="server">
                                            <asp:Button ID="bnt_cancel" runat="server" Text="Back" ToolTip="Back" OnClick="bnt_cancel_Click" />
                                        </div>
                                    </div>

                                    <div class="left_btn" style="display: flex;">
                                        <div class=" btn-export1 MR4">
                                            <asp:LinkButton ID="btn_Export" runat="server" OnClick="btn_Export_Click">
                                                  <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                                            </asp:LinkButton>
                                        </div>

                                        <div class=" ico-excel">
                                            <asp:LinkButton ID="btn_Export_Details" runat="server" OnClick="btn_Export_Details_Click">
                                                  <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export To Excel With Details"/>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                                <div class="FormGroupContent4">
                                    <asp:Panel ID="Pnl_total_grid" CssClass="gridpnl MT0 MB0" runat="server" ScrollBars="Vertical">
                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Agent" runat="server" Width="100%" ForeColor="Black"
                                            AutoGenerateColumns="False" DataKeyNames="agentid"
                                            OnSelectedIndexChanged="grd_Agent_SelectedIndexChanged"
                                            OnRowDataBound="grd_Agent_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Agent">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                            <asp:Label ID="Agent" runat="server" Text='<%# Bind("Agent") %>' ToolTip='<%# Bind("Agent") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="GrWt" HeaderText="GR.WT(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Shipper" runat="server" Width="100%" ForeColor="Black"
                                            AutoGenerateColumns="False" DataKeyNames="ShipperId"
                                            OnSelectedIndexChanged="grd_Shipper_SelectedIndexChanged" OnRowDataBound="grd_Shipper_RowDataBound">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Shipper">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                            <asp:Label ID="Shipper" runat="server" Text='<%# Bind("Shipper") %>' ToolTip='<%# Bind("Shipper") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grwt" HeaderText="GR.WT(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                        <asp:ModalPopupExtender ID="popup" runat="server" PopupControlID="panelSerch"
                                            TargetControlID="Label2" DropShadow="false" CancelControlID="close" BehaviorID="Test">
                                        </asp:ModalPopupExtender>
                                        <asp:Panel ID="panelSerch" runat="server" CssClass="modalPopup" BorderStyle="Solid"
                                            BorderWidth="1px" Style="display: none;" ScrollBars="Both">
                                            <div class="divRoated">
                                                <div class="DivSecPanel">
                                                    <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                                </div>

                                                <div style="float: left; width: 99%; margin: 10px 5px 10px 5px; padding: 0px;">

                                                    <div style="float: left; width: 40%; margin: 0px 0.5% 0px 0px !important;" class="boxmodal">

                                                        <asp:Panel ID="Panel6" runat="server" CssClass="gridpnl MT0 MB0 MB0">
                                                            <asp:GridView CssClass="Grid FixedHeader" ID="grdshipteusdtls" runat="server" Width="100%"
                                                                AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Height="20px" />
                                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="m3" HeaderText="CBM" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="50px" Height="20px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="teus" HeaderText="Teus" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="50px" Height="20px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="weight" HeaderText="Weight (in kgs)" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="75px" Height="20px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="retention" HeaderText="Revenue" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="75px" Height="20px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                            </asp:GridView>
                                                        </asp:Panel>

                                                        <div class="Break"></div>

                                                    </div>
                                                    <div style="width: 59%; float: left; margin-top: 0px !important;" class="boxmodal">

                                                        <asp:Panel ID="Panel7" runat="server" CssClass="gridpnl MT0 MB0 MB0">
                                                            <asp:GridView CssClass="Grid FixedHeader" ID="grdyear" runat="server" Width="100%"
                                                                AutoGenerateColumns="False" ShowHeader="false" OnRowCreated="grdyear_RowCreated">
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="Month">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdmonth" runat="SERVER" Text='<%# Eval("month")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="branch" ControlStyle-Width="70">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdbranch" runat="SERVER" Text='<%# Eval("branch")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="vol1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdvol1" runat="SERVER" Text='<%# Eval("vol1")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="teus1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdteus1" runat="SERVER" Text='<%# Eval("teus1")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="chwt1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdchwt1" runat="SERVER" Text='<%# Eval("weight1")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Revenue1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdretention1" runat="SERVER" Text='<%# Eval("retention1")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="vol2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdvol2" runat="SERVER" Text='<%# Eval("vol2")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="teus2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdteus2" runat="SERVER" Text='<%# Eval("teus2")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="chwt2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdchwt2" runat="SERVER" Text='<%# Eval("weight2")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Revenue2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdretention2" runat="SERVER" Text='<%# Eval("retention2")  %>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" BorderColor="White" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </div>

                                                </div>

                                                <div class="Break"></div>
                                            </div>
                                        </asp:Panel>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Consignee" runat="server" AutoGenerateColumns="False"
                                            Width="100%" ForeColor="Black"
                                            DataKeyNames="Consigneeid"
                                            OnSelectedIndexChanged="grd_Consignee_SelectedIndexChanged"
                                            OnRowDataBound="grd_Consignee_RowDataBound">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Consignee">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                            <asp:Label ID="Consignee" runat="server" Text='<%# Bind("Consignee") %>' ToolTip='<%# Bind("Consignee") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grwt" HeaderText="Gr.wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Shipment" runat="server" AutoGenerateColumns="False"
                                            Width="100%" ForeColor="Black"
                                            OnRowDataBound="grd_Shipment_RowDataBound" DataKeyNames="trantype,branchid" OnSelectedIndexChanged="grd_Shipment_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nomination" HeaderText="Nomination">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TypeJob" HeaderText="JobType" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Volume" HeaderText="M3/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20'" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40'" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_JobwiseCosting" runat="server" Width="100%"
                                            ForeColor="Black" AutoGenerateColumns="False"
                                            OnRowDataBound="grd_JobwiseCosting_RowDataBound" OnSelectedIndexChanged="grd_JobwiseCosting_SelectedIndexChanged"
                                            DataKeyNames="branchid">
                                            <Columns>
                                                <asp:BoundField DataField="trantype" HeaderText="Product" />
                                                <asp:BoundField DataField="Branch" HeaderText="Branch" Visible="False" />
                                                <asp:BoundField DataField="JobNo" HeaderText="Job #" />
                                                <asp:BoundField DataField="jobopenon" HeaderText="Job Open On" />
                                                <asp:BoundField DataField="jobcloseddate" HeaderText="Job Closed On" />

                                                <asp:TemplateField HeaderText="Agent">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                            <asp:Label ID="agent1" runat="server" Text='<%# Bind("agent") %>' ToolTip='<%# Bind("agent") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>

                                            </Columns>

                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_lossjob" runat="server" AutoGenerateColumns="False"
                                            Width="100%" ForeColor="Black"
                                            OnRowDataBound="grd_lossjob_RowDataBound"
                                            OnSelectedIndexChanged="grd_lossjob_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="trantype" HeaderText="Product" />

                                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                                <asp:BoundField DataField="jobopenon" HeaderText="Job Open On" />
                                                <asp:BoundField DataField="jobcloseddate" HeaderText="Job Closed On" />
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_nomvafree" runat="server" AutoGenerateColumns="False"
                                            Width="100%" ForeColor="Black">
                                            <Columns>
                                                <asp:BoundField DataField="pyear" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pmonth" HeaderText="Unit">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pmonth" HeaderText="A Volume/Tues">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pmonth" HeaderText="A Revenue">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pfcl" HeaderText="A Per Unit">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="afcl" HeaderText="O Volume/Tues">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fcl" HeaderText="O Revenue">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_operProfit" runat="server" Width="100%" ForeColor="Black"
                                            OnRowDataBound="grd_operProfit_RowDataBound"
                                            OnRowCreated="grd_operProfit_RowCreated" OnSelectedIndexChanged="grd_operProfit_SelectedIndexChanged">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_operProfit_AC" runat="server" Width="100%" ForeColor="Black"
                                            OnRowDataBound="grd_operProfit_AC_RowDataBound" OnRowCommand="grd_operProfit_AC_RowCommand" AutoGenerateColumns="false"
                                            OnSelectedIndexChanged="grd_operProfit_AC_SelectedIndexChanged" OnRowCreated="grd_operProfit_AC_RowCreated">
                                            <Columns>
                                                <asp:ButtonField CommandName="ColumnClickNew" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                                <asp:BoundField DataField="Branch" HeaderText="Branch"></asp:BoundField>
                                                <asp:BoundField DataField="AE" HeaderText="AE" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" DataFormatString="{0:F2}">
                                                    <HeaderStyle Width="10%" Wrap="True" />
                                                    <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AI" HeaderText="AI" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" DataFormatString="{0:F2}">
                                                    <HeaderStyle Width="10%" Wrap="True" />
                                                    <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <%-- <asp:BoundField DataField="BT" HeaderText="BT" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                        <HeaderStyle Width="10%" Wrap="True" />
                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                    </asp:BoundField>--%>
                                                <%--  <asp:BoundField DataField="CH" HeaderText="CH" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle Width="10%" Wrap="True" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" />
                                            </asp:BoundField>--%>
                                                <%-- <asp:BoundField DataField="FC" HeaderText="FC" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                        <HeaderStyle Width="10%" Wrap="True" />
                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                    </asp:BoundField>--%>
                                                <asp:BoundField DataField="OE" HeaderText="OE" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" DataFormatString="{0:F2}">
                                                    <HeaderStyle Width="10%" Wrap="True" />
                                                    <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OI" HeaderText="OI" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" DataFormatString="{0:F2}">
                                                    <HeaderStyle Width="10%" Wrap="True" />
                                                    <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" DataFormatString="{0:F2}">
                                                    <HeaderStyle Width="10%" Wrap="True" />
                                                    <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                </asp:BoundField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_POL" runat="server" AutoGenerateColumns="False"
                                            Width="100%" ForeColor="Black" DataKeyNames="polid" OnRowDataBound="grd_POL_RowDataBound"
                                            OnSelectedIndexChanged="grd_POL_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="pol" HeaderText="PoL">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Grwt" HeaderText="Gr.wt(Kgs)" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="grd_POD" runat="server" AutoGenerateColumns="False" Width="100%"
                                            ForeColor="Black" DataKeyNames="podid"
                                            CssClass="Grid FixedHeader" OnRowDataBound="grd_POD_RowDataBound" OnSelectedIndexChanged="grd_POD_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="pod" HeaderText="PoD">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Grwt" HeaderText="Gr.wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="grd_salesperson" runat="server" AutoGenerateColumns="False" Width="100%"
                                            ForeColor="Black" DataKeyNames="salesid"
                                            CssClass="Grid FixedHeader" OnRowDataBound="grd_salesperson_RowDataBound" OnSelectedIndexChanged="grd_salesperson_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="person" HeaderText="Sales Person">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Grwt" HeaderText="Gr.Wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="Gridliner" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="false" Font-Bold="false"
                                            Width="100%" ForeColor="Black" DataKeyNames="trantype,branchid" OnRowDataBound="Gridliner_RowDataBound"
                                            Visible="false" OnSelectedIndexChanged="Gridliner_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="linername" HeaderText="Liner">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nomination" HeaderText="Nomination" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />

                                        </asp:GridView>

                                        <asp:GridView ID="GRD_CANREPORT" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                            Width="100%" ForeColor="Black" Visible="false">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="GRD_canreportAI" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                            Width="100%" ForeColor="Black" Visible="false">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="GRD_RegisterReport" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                            Width="100%" ForeColor="Black" Visible="false">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="GRD_DoRegister" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                            Width="100%" ForeColor="Black" Visible="false" OnRowDataBound="GRD_DoRegister_RowDataBound" OnSelectedIndexChanged="GRD_DoRegister_SelectedIndexChanged">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="GRD_Forward" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false" Width="100%" ForeColor="Black"
                                            Visible="false" OnRowDataBound="GRD_Forward_RowDataBound" OnSelectedIndexChanged="GRD_Forward_SelectedIndexChanged">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="GRD_Revenue" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false" Width="100%" ForeColor="Black"
                                            Visible="false" OnRowDataBound="GRD_Revenue_RowDataBound">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_freeVsnomi" runat="server" AutoGenerateColumns="False" Width="100%"
                                            ForeColor="Black" CssClass="Grid FixedHeader" OnRowDataBound="Grd_freeVsnomi_RowDataBound" OnSelectedIndexChanged="Grd_freeVsnomi_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="product" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="unit" HeaderText="Unit" DataFormatString="{0:#,##0.00}">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fvolume" HeaderText="A Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fretn" HeaderText="A Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FRtnPUnit" HeaderText="A Per Unit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nvolume" HeaderText="O Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nretn" HeaderText="O Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NRtnPUnit" HeaderText="O Per Unit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_nomination" runat="server" AutoGenerateColumns="False" Width="100%"
                                            ForeColor="Black" CssClass="Grid FixedHeader"
                                            OnRowDataBound="Grd_nomination_RowDataBound" OnSelectedIndexChanged="Grd_nomination_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nomination" HeaderText="Nomination">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_shiperconsignee" runat="server" Width="100%"
                                            ForeColor="Black" AutoGenerateColumns="false"
                                            OnRowDataBound="Grd_shiperconsignee_RowDataBound" OnSelectedIndexChanged="Grd_shiperconsignee_SelectedIndexChanged">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_shiperconsigneeProduct" runat="server" Width="100%"
                                            ForeColor="Black" AutoGenerateColumns="true"
                                            OnRowDataBound="Grd_shiperconsigneeProduct_RowDataBound" OnSelectedIndexChanged="Grd_shiperconsigneeProduct_SelectedIndexChanged">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_YearMIS" runat="server" Width="100%" ForeColor="Black"
                                            AutoGenerateColumns="true" OnRowDataBound="grd_YearMIS_RowDataBound">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_trendcustomer" runat="server" CssClass="Grid FixedHeader " Width="100%" OnRowDataBound="Grd_trendcustomer_RowDataBound"
                                            ForeColor="Black" AutoGenerateColumns="False">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_trendcustomervolume" runat="server" CssClass="Grid FixedHeader" Width="100%" OnRowDataBound="Grd_trendcustomervolume_RowDataBound"
                                            ForeColor="Black">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_Retention" runat="server" CssClass="Grid FixedHeader" Width="100%"
                                            ForeColor="Black" AutoGenerateColumns="true"
                                            ShowHeader="False" OnRowDataBound="Grd_Retention_RowDataBound">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_op" runat="server" AutoGenerateColumns="False"
                                            Width="100%" BackColor="White" Visible="false" OnRowDataBound="grd_op_RowDataBound"
                                            OnSelectedIndexChanged="grd_op_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="TranTypeFull" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nomination" HeaderText="Nomination">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Volume" HeaderText="Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="GRD_Common" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                            Width="100%" ForeColor="Black" DataKeyNames="TranType" OnRowCreated="GRD_Common_RowCreated" OnRowDataBound="GRD_Common_RowDataBound"
                                            Visible="false" OnSelectedIndexChanged="GRD_Common_SelectedIndexChanged">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />

                                        </asp:GridView>

                                        <asp:GridView ID="Gridtemp" runat="server" CssClass="Grid FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="true">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:Panel ID="Pln_MIS" runat="server" Visible="false">
                                            <asp:Label ID="lbl_MISA" runat="server" Text="Jobs Opened,Sailed / Arrived  & Closed during  the Given  Period - A"
                                                ForeColor="Red" CssClass="LabelValue"></asp:Label>

                                            <asp:Panel ID="pnl_MISA" runat="server">
                                                <asp:GridView ID="Grd_MISA" runat="server" CssClass="Grid FixedHeader" Width="100%" ForeColor="Black"
                                                    ShowHeaderWhenEmpty="true" ShowHeader="true" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                                        <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                                        <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                                        <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                                        <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                                        <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                        <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                        <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridviewScrollHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>

                                            <asp:Label ID="lbl_MISB" runat="server" Text="Jobs Opened,Sailed / Arrived  & Closed in Previous Months but voucher Generated during the given Period - B"
                                                ForeColor="Red" CssClass="LabelValue"></asp:Label>

                                            <asp:Panel ID="pnl_MISB" runat="server">
                                                <asp:GridView ID="Grd_MISB" runat="server" CssClass="Grid FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                                        <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                                        <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                                        <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                                        <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                                        <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                        <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                        <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridviewScrollHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>

                                            <asp:Label ID="lbl_MISC" runat="server" Text="Jobs Opened but not Sailed / Arrived  during the given Period &  Unclosed - C"
                                                ForeColor="Red" CssClass="LabelValue"></asp:Label>

                                            <asp:Panel ID="Panel_MISC" runat="server">
                                                <asp:GridView ID="Grd_MISC" runat="server" CssClass="Grid FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                                        <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                                        <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                                        <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                                        <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                                        <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                        <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                        <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridviewScrollHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>

                                            <div class="div_Break"></div>
                                            <asp:Label ID="lbl_MISD" runat="server" Text="Jobs Opened,Sailed / Arrived  During the given Period but Unclosed  - D"
                                                ForeColor="Red" CssClass="LabelValue"></asp:Label>

                                            <asp:Panel ID="Panel_MISD" runat="server">
                                                <asp:GridView ID="Grd_MISD" runat="server" CssClass="Grid FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                                        <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                                        <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                                        <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                                        <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                                        <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridviewScrollHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>

                                            <asp:Label ID="lbl_retention" runat="server" Text="" ForeColor="Red" CssClass="LabelValue"></asp:Label>
                                        </asp:Panel>

                                        <div class="div_Break"></div>

                                        <div runat="server" id="div_op_char" class="div_chat">
                                            <asp:Chart ID="chartoperProfit" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                <Series>
                                                    <asp:Series Name="Series1" Color="#0000ff">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                        </div>

                                        <div runat="server" id="div3" class="div_chat">
                                            <asp:Chart ID="chartoperProfit1" runat="server" Width="800px" EnableViewState="false" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="false" Palette="Bright" ViewStateMode="Disabled">
                                                <Series>
                                                    <asp:Series Name="Series1" Color="#0000ff">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                        </div>

                                        <div runat="server" id="div2" class="div_chat">
                                            <asp:Chart ID="piechart" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                <Series>
                                                    <asp:Series Name="Series1" Color="#ffcc00">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                        </div>

                                        <div runat="server" id="div1" class="div_chat">
                                            <asp:Chart ID="PODCHARTVIEW" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                <Series>
                                                    <asp:Series Name="Series1" Color="#cc6600">
                                                    </asp:Series>
                                                </Series>
                                                <Series>
                                                    <asp:Series Name="Series2" Color="#3333ff">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                        </div>

                                        <div id="DivAllCahrtnew" visible="false" class="DivAllChart" runat="server">

                                            <div class="DivAllChart2">
                                                <asp:Chart ID="Chart1" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart3">
                                                <asp:Chart ID="Chart2" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart4">
                                                <asp:Chart ID="Chart3" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChartFriest">
                                                <asp:Chart ID="Chart4" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="Break"></div>
                                            <div class="Break"></div>
                                            <div class="DivAllChart5">
                                                <asp:Chart ID="Chart5" runat="server" Height="150px" Width="200px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart6">
                                                <asp:Chart ID="Chart6" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart7">
                                                <asp:Chart ID="Chart7" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart8">
                                                <asp:Chart ID="Chart8" runat="server" EnableViewState="True" Visible="False" Height="150px" Width="200px" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="div_Break"></div>
                                        </div>
                                    </asp:Panel>
                                </div>

                                <div class="div_Break"></div>

                            </div>

                        </div>
                        <div id="operation_mis" runat="server" class="PendingRightnewComapp" visible="false">

                            <div class="FormGroupContent4">
                                <asp:Panel ID="grdpanal" runat="server" CssClass="panel_06" ScrollBars="Both" Visible="false">
                                    <asp:GridView ID="grd_Trend" Width="100%" runat="server" CssClass="Grid FixedHeader" BorderStyle="None" AllowPaging="false" EmptyDataText="No Record Found" OnRowDataBound="grd_Trend_RowDataBound" OnPageIndexChanging="grd_PageIndexChanging">
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerSettings Mode="NextPreviousFirstLast" PageButtonCount="10" />
                                        <%--<AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" />--%>
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                            <div class="left_btn MB10">
                                <div class="btn ico-excel">
                                    <asp:LinkButton ID="btn_e2e" runat="server" OnClick="btn_e2e_Click">
                                                  <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <%--   <div class="btn btn-export"> <asp:Button ID="btn_e2e" Text="Export 2 Excel" runat="server" OnClick="btn_e2e_Click" /></div>--%>
                        </div>
                        <div class="FormGroupContent4" id="Event_Tracking" runat="server" visible="false">
                            <asp:Panel ID="panel" runat="server" Visible="false" Width="100%" Height="250px">
                                <div class="panel_06">
                                    <asp:GridView ID="GrdFI" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="false"
                                        EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdFI_RowDataBound">
                                        <Columns>
                                            <asp:BoundField HeaderText="Job#" DataField="jobno">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="ETA" DataField="eta">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Vsl & Voy" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                        <asp:Label ID="vslvoy" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                        <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Liner" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                        <asp:Label ID="liner" runat="server" Text='<%# Bind("liner") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField HeaderText="POL" DataField="pol">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Container#" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                        <asp:Label ID="contnoandtype" runat="server" Text='<%# Bind("contnoandtype") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Doc.RecvOn" DataField="docrecon">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Inv.CreatedOn" DataField="invdate">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="CANSentOn" DataField="candate">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Pay.SubmitOn" DataField="padate">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="LineDoc.RecvOn" DataField="linedorecon">
                                                <%--<HeaderStyle Wrap="true" HorizontalAlign="Right" />--%>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="CFS" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                        <asp:Label ID="cfs" runat="server" Text='<%# Bind("cfs") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField HeaderText="D-StuffedOn" DataField="destuffdt">
                                                <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <%--  <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" />--%>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>

                            <div style="float: right; margin-right: 16px; margin-top: 3px;">
                                <asp:LinkButton ID="btn_E2E1" runat="server" OnClick="btn_E2E1_Click" UseSubmitBehavior="False"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                            </div>
                            <%-- <div class="btn btn-export"><asp:Button ID="btn_E2E1" Text="Export2Excel" runat="server" OnClick="btn_E2E1_Click" UseSubmitBehavior="False" /></div>--%>
                        </div>
                        <div class="FormGroupContent4" id="div_tuesgrd" runat="server" visible="false">
                            <asp:Panel ID="Panel9" runat="server" CssClass="gridpnl MT0 MB0" Visible="false">
                                <asp:GridView ID="grd" Width="100%" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ShowHeaderWhenEmpty="false"
                                    BorderStyle="None" OnRowDataBound="grd_RowDataBound">

                                    <%-- <AlternatingRowStyle CssClass="GrdRowStyle" /> --%>
                                    <%--<HeaderStyle CssClass="GridviewScrollHeader" />--%>
                                    <%--<RowStyle CssClass="GridviewScrollItem" /> 
                <PagerStyle CssClass="GridviewScrollPager" />--%>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                            <div style="float: right; margin-right: 16px; margin-top: 3px;">
                                <asp:LinkButton ID="btn_e2etues" runat="server" OnClick="btn_e2etues_Click" UseSubmitBehavior="False"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                            </div>
                            <%--      <div class="btn btn-export"><asp:Button ID="btn_e2etues" Text="Export 2 Excel" runat="server"  onclick="btn_e2etues_Click" /></div>--%>
                        </div>
                        <div id="div_fivolume" runat="server" visible="false">
                            <div class="VolumeGrid">
                                <asp:GridView ID="Grdvolume" runat="server" Width="150%" ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader"
                                    AutoGenerateColumns="False" OnRowDataBound="Grdvolume_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="SNo" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                                        <asp:BoundField DataField="jobno" HeaderText="Job #" ItemStyle-HorizontalAlign="Right">
                                            <HeaderStyle Wrap="false" Width="35px" />
                                            <ItemStyle Wrap="false" Width="35px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Jobtype" HeaderText="Job Type">
                                            <HeaderStyle Wrap="false" Width="55px" />
                                            <ItemStyle Wrap="false" Width="55px" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="VslVoy">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                                    <asp:Label ID="review" runat="server" Text='<%# Bind("VslVoy") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="95px" />
                                            <ItemStyle Wrap="false" Width="95px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="eta" HeaderText="E T A" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="pol" HeaderText="P O L" />

                                        <asp:TemplateField HeaderText="Agent">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                    <asp:Label ID="review1" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="120px" />
                                            <ItemStyle Wrap="false" Width="120px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="M L O">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                    <asp:Label ID="review2" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="80px" />
                                            <ItemStyle Wrap="false" Width="80px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="C F S">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                    <asp:Label ID="review3" runat="server" Text='<%# Bind("cfs") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="100px" />
                                            <ItemStyle Wrap="false" Width="100px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="contbyus" HeaderText="By Us" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="blnous" HeaderText="By Us" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="contbyagnt" HeaderText="By Agent" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="blnoagent" HeaderText="By Agent" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="byus" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="byus2" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="Tues" HeaderText="Tues" ItemStyle-HorizontalAlign="Right" />

                                    </Columns>
                                    <%--<AlternatingRowStyle CssClass="GrdRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <RowStyle CssClass="GridviewScrollItem" />
                                <PagerStyle CssClass="GridviewScrollPager" />--%>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>

                            <%--<div class="FormGroupContent">
                   <asp:Button ID="DivExport" runat="server" Text="Exports to Excel" OnClick="DivExport_Click"/>
                   </div>--%>
                        </div>
                        <div style="float: right; margin-right: 16px; margin-top: 3px;">
                            <asp:LinkButton ID="DivExport" runat="server" OnClick="DivExport_Click" UseSubmitBehavior="False" Visible="false"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                        </div>

                    </div>
                </div>
                <div class="FormGroupContent4">
                    <div class="piechart1" id="div4" runat="server">Region Geochart</div>

                </div>

                <%--  <div class="FormGroupContent4">
         <div class="TitleLeft1">
                        
       <div runat="server" id="div5" class="PendingRightnewChart" >

                     <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        <div id="chart" runat="server" style="width: 300px; height: 300px;">
                        </div>
                    </div>
    </div>
            </div>--%>
            </div>
        </div>
            </div>

        <%-- <asp:Button ID="btnexport" runat="server" Text="Export Excel" CssClass="Exportbtn"  OnClick="btnexport_Click"/>--%>

        <div class="Clear"></div>

        <div class=" custom-d-flex custom-mt-05 hide" runat="server" visible="true">
        </div>

        <asp:HiddenField ID="hid" runat="server" />

        <asp:Label ID="LblCncl" runat="server"></asp:Label>
        <asp:ModalPopupExtender ID="popuprate" runat="server" TargetControlID="LblCncl"
            BehaviorID="frgtydfdfdf"
            PopupControlID="pnlcncl" CancelControlID="imgcls" DropShadow="false">
        </asp:ModalPopupExtender>

        <asp:Panel ID="pnlcncl" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel8" runat="server" CssClass=" Gridpnl">
                    <iframe id="iframe_buyratequery" width="100%" height="100%" runat="server" src="../Accounts/RetentionPerunit.aspx" frameborder="0"></iframe>

                </asp:Panel>

            </div>

        </asp:Panel>

        <asp:Button ID="btn_show" runat="server" OnClick="btn_show_Click" Style="display: none;" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hid_vou" runat="server" />
        <asp:HiddenField ID="hidId" runat="server" Value="" />
        <asp:HiddenField ID="hid_text" runat="server" Value="Y" />
        <asp:HiddenField ID="hf_agent" runat="server" />
        <asp:HiddenField ID="hf_tran" runat="server" />
        <asp:HiddenField ID="hf_date" runat="server" />
        <asp:HiddenField ID="hd_op" runat="server" />
        <asp:GridView ID="grdexcel" runat="server"></asp:GridView>
            </div>
    </form>
</body>
</html>
<%--</asp:Content>--%>
