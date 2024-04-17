<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SalesHome.aspx.cs" Inherits="logix.Home.SalesHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" type="text/css" media="all" />

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

    <script src="../js/helper.js"></script>
    <script src="../js/TextField.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <%--<script src="http://code.jquery.com/jquery-1.8.2.js"></script>

    <script src="http://www.google.com/jsapi" type="text/javascript"></script>--%>

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

    <%--<script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: '../Home/SalesHome.aspx/GetChartData',
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
            new google.visualization.PieChart(document.getElementById('chartdiv')).
            draw(data, { title: "Show Google Chart in Asp.net" });
        }
    </script>--%>

    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
           .panel_09,
           .panel_10,
           .panel_18 {
    max-height: 80vh!important;
    min-height: 80vh!important;
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
            height: 566px !important;
            margin: 0 5px 0 -15px;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
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
            width: 62.8%;
            float: left;
            height: 372px;
            margin-top: 0%;
            margin-left: 10px;
        }

        .Div_GridHomeC {
            width: 100%;
            float: left;
            height: 370px;
            margin-top: 0px;
            margin-right: 1%;
        }

        div#logix_CPH_panelservice {
            margin: 0px 0px 0px 8px;
        }

        .MB28 {
            margin-top: 0px !important;
            margin-right: 11px;
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

        .FormGroupContent1 {
            width: 100%;
            float: left;
            padding: 0px 0px 0px 0px;
            margin: -20px 0px 0px 0px;
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
            width: 452px !important;
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
                font-size: 12px;
                color: #4e4e4c;
            }

        #Panel1 {
            margin: 5px 0px 0px 0px;
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
            margin: -1px 0px 0px 0px;
            width: 30%;
        }

        .PorttxtNew1 {
            float: left;
            margin: -1px 1.4% 0px 0px;
            width: 30%;
        }

        .PendingEventSales {
            float: left;
            width: 100%;
            margin: 10px 0px 15px 0px;
        }

        .PendingLeftNew {
            float: left;
            width: 27%;
            margin: -50px 5px 0px 5px;
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
            margin: 3px 0.5% 0px 0px;
        }

        .divSales {
            float: right;
            width: 175px;
            margin: 7px 0.5% 0px 0px;
        }

        .divSales1 {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .PendingTbl4SalesNew {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
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
            margin: 0px 0px 0px 0px;
            float: left;
        }

        .PendingRightSalesCreditEx {
            float: left;
            width: 99%;
            margin: -33px 5px 0px 5px;
        }

        div#logix_CPH_pnl_credit {
            height: 530px !important;
        }

        .PendingTblSalOut {
            width: 455px;
            float: left;
            margin: 2px 0px 0px 4px;
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
            margin: 0px 0px 0px 10px;
            height: auto;
            border: 0px solid #b1b1b1;
            width: 99%;
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
            width: 25.5%;
            margin: -37px 5px 0px 5px;
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

        .PendingTbl2 {
            width: 191px;
            float: left;
            margin: 5px 0px 0px 10px;
            max-height: 136px;
            min-height: 449px;
            overflow: auto;
        }

        .TblScroll {
            height: 276px;
            /*border:1px solid #003a65;*/
            overflow: auto;
        }

        .MB31 {
            margin-bottom: 5px !important;
            margin-right: -7px;
            margin-top: 10px;
        }

        #Panel5 {
            float: left;
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
            font-size: 11px;
            font-family: sans-serif;
            margin: -10px 0px 0px 2px;
            padding: 0px 5px 0px 0px;
            color: var(--grey) !important;
        }

        .PortCountryC {
            float: left;
            width: 37%;
            margin: 0px 0px 0px 0px;
        }

        span#logix_CPH_lblBooking {
            font-weight: bold !important;
        }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 28px;
            padding: 5px 2px 3px 5px;
            width: 100%;
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
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 0px;
            padding: 0px 5px 2px 0px;
            color: var(--grey) !important;
        }

        .SalesTitleB {
               font-weight: bold;
    font-size: 14px;
    font-family: sans-serif;
    margin: 8px 0px 0px 4px;
    padding: 0px 5px 0px 0px;
    color: var(--grey) !important;
    width: 180px;
    float: left;
        }

        .SalesTitleB1 {
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 9px;
            padding: 0px 5px 2px 0px;
            color: var(--grey) !important;
        }

        .widget.box .widget-content {
            padding: 0px 10px 10px 10px;
            position: relative;
            background-color: #fff !important;
            display: block;
            overflow: hidden;
        }

        .TblHeight4 {
            border: 0px solid #b1b1b1;
            margin: 9px 3px 0px 8px;
        }

        #Panel7 {
            float: left;
            width: 69%;
            /*margin: 0px 0px 0px 10px;*/
            margin: 2px 0px 0px 0px;
            height: 74px;
            min-height: 380px;
            /*border:1px solid #003a65;*/
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

        .modalPopupss {
            background-color: #FFFFFF !important;
            border-width: 0px;
            border-style: solid;
            border-color: #CCCCCC;
            width: 100%;
            /*Height: 264px;*/
            margin-left: 0%;
            margin-top: 0.5%;
            background-color: #ffffff;
        }

        #pnlcncl {
            left: 10px !important;
            top: 102px !important;
        }

        .SalesTitleNew {
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 2px 0px;
            margin: 10px 0px 0px 8px;
            color: var(--grey) !important;
            float: left;
            width: 80px;
        }

        .SalesTitleNew1 {
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 2px 0px;
            color: var(--grey) !important;
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
            font-size: 11px;
            font-family: sans-serif;
            margin: 20px 0px -5px 0px;
            padding: 2px 5px 0px 0px;
            color: var(--grey) !important;
            width: 188px;
            float: left;
        }

        .SalesTitleOut {
            font-size: 11px;
            font-family: sans-serif;
            margin: 2px 0px 0px 0px;
            padding: 2px 5px 0px 0px;
            color: var(--grey) !important;
            width: 188px;
            float: left;
        }

        .SalesTitlePerP {
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 0px;
            padding: 5px 5px 0px 0px;
            color: var(--grey) !important;
            width: 650px;
            float: left;
            text-transform: capitalize;
        }

        .MB18 {
            margin-bottom: 4px;
            margin-top: 0px;
            margin-right: 1px;
        }

        #Div2 {
            width: 470px;
            float: left;
        }

        #logix_CPH_classDiv {
            float: left;
            width: 31%;
            margin: -40px 5px 0px 0px;
        }

        .SalesTitlePer1 {
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 2px 0px;
            padding: 2px 5px 2px 0px;
            color: var(--grey) !important;
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
            background-color: #50a7a0;
            background-image: none !important;
            border: medium none;
            color: #ffffff;
            line-height: normal;
            padding: 5px 8px 5px 10px;
            margin: 1px 0px 0px 3px;
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
            min-height: 349px;
            /*border:1px solid #003a65 !important;*/
        }

        .CollectionGrid {
            float: left;
            margin: 2px 0 10px -8px;
            width: 100%;
            min-height: 349px;
            overflow: auto;
            /*border:1px solid #003a65 !important;*/
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
            margin: -41px 0 0 -4px;
            width: 100%;
        }

        .MB2 {
            margin-bottom: 4px;
            margin-top: -4px;
            margin-right: 1px;
        }

        .MB01 {
            margin-bottom: 4px;
            margin-top: 0px;
            margin-right: 1px;
        }
        table#logix_CPH_grdQuatotion td:nth-child(11) {
    width: 76px !important;
}
        .SalesTitleB2 {
              font-size: 14px;
    font-family: sans-serif;
    margin: 0px 0px 0px 0px;
    padding: 5px 5px 12px 0px;
    color: var(--labelblack) !important;
    width: 300px;
    float: left;
    font-weight: 500;
        }

        .SalesTitleB3 {
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px -12px 0px;
            padding: 2px 5px 2px 0px;
            color: var(--grey) !important;
            width: 220px;
            float: left;
        }

        .SalesTitleBCE {
    margin: 0px 0px 0px 8px;
    padding: 0px 5px 7px 0px;
    color: var(--grey) !important;
    width: 90%;
    font-size: 14px !important;
    float: left;
    font-weight: 500;
        }

        .SalesTitleB4 {
               font-size: 14px;
    font-family: sans-serif;
    margin: 12px 0px 0px 0px;
    padding: 2px 5px 1px 0px;
    color: var(--grey) !important;
    width: 380px;
    float: left;
    font-weight: 500;
        }

        #logix_CPH_Div2 {
            width: 37%;
            float: left;
            margin: 10px 5px 0px 0px;
        }

        .SalesTitleBCE {
            position: relative;
            top: 2px;
            left: -7px;
        }

        .PendingRightSalesN12 {
            margin: -45px 0px 0px 5px;
        }

        div#logix_CPH_panel8 {
            float: left;
            width: 62%;
            height: 530px !important;
        }

        .Hide {
            display: block;
        }

        div#logix_CPH_panelservice {
            height: 530px !important;
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
            margin-top: 2px !important;
            margin-right: 10px;
        }

        .SalesTitleNewWip {
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 0px 0px;
            margin: 10px 0px 0px 8px;
            color: var(--grey) !important;
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

        .PieChart {
            float: left;
            width: 50%;
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
            width: 500px;
            border: 0px solid var(--inputborder);
            background-color: var(--white);
            float: left;
            margin: 10px 0px 0px 0px;
        }

        .Chart2 {
            overflow: hidden;
            width: 500px;
            float: left;
            margin: 10px 10px 0px 0px;
            border: 0px solid var(--inputborder);
            background-color: var(--white);
        }

        }

        .SalesTitlePerN1 {
            font-size: 11px;
            font-family: sans-serif;
            margin: 7px 0px 0px 8px;
            padding: 2px 5px 0px 0px;
            color: var(--grey) !important;
            width: 150px;
            float: left;
        }

        .SalesTitleBooking {
            font-size: 11px;
            font-family: sans-serif;
            margin: -15px 0px 5px 0px;
            padding: 0px 5px 2px 0px;
            color: var(--grey) !important;
        }

        span#logix_CPH_cust_name {
            font-weight: bold !important;
        }

        .MB21 {
            margin-bottom: 4px;
            margin-top: -1px;
            margin-right: 1px;
        }

        div#UpdatePanel1 {
            height: fit-content;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .grid_P3 {
            float: left;
    margin: -5px 0 0px 0px;
    width: 70.5%;
        }

        div#logix_CPH_Panel6 {
     width: 72%;
    float: left;
    margin: 4px 0 0 0 !important;
    height: 530px !important;
        }

        .SalesTitlePerN1 {
            float: left;
            margin: 10px 0px 0px;
        }

        span#logix_CPH_lblQuation {
            position: relative;
            top: 5px;
        }

        div#logix_CPH_Panel9 {
            margin: 0.5% 0px 0.5% 6px !important;
            width: 99%;
        }

        .SalesTitleB2 {
            position: relative;
            top: 10px;
        }

        div#logix_CPH_CallPannel {
            width: 99%;
            margin: 0px 0px 0px 5px;
        }

        a#logix_CPH_workingprogess {
            margin: 0px 5px 0 0;
        }

      

        a#logix_CPH_lnk_lblPerformance {
            position: relative;
            top: 5px;
            right: 0px;
        }

        .SalesTitlePer1 {
            margin: 7px 0 0 5px;
        }

        a#logix_CPH_lnk_div_book {
            margin: 0 0 5px 0;
            display: inline-block;
        }

        .SalesTitleNew {
            margin: 0px 0px 0px 10px;
        }

        table#logix_CPH_grdQuatotion td:last-child {
            width: 175px !important;
            text-overflow: ellipsis !important;
            overflow: hidden;
            display: inline-block;
        }

        table#logix_CPH_grdQuatotion td:nth-child(10) {
            max-width: 150px !important;
            text-overflow: ellipsis !important;
            overflow: hidden !important;
        }

        /*table#logix_CPH_grdQuatotion td:nth-child(8) {
            max-width: 83px !important;
        }*/

        table#logix_CPH_grdQuatotion td:nth-child(6) {
            max-width: 175px;
            text-overflow: ellipsis;
            overflow: hidden;
        }

        table#logix_CPH_grdQuatotion td:nth-child(1) {
            width: 50px !important;
            display: inline-block;
        }

        div#logix_CPH_Panel9 {
            margin: 0.5% 0px 0.5% 6px !important;
            width: 99%;
            height: 530px !important;
        }

        .SalesTitleBooking1 {
            font-size: 11px;
            font-family: sans-serif;
            color: var(--grey) !important;
            float: left;
            width: 40%;
            margin: -3px 0px 0px 2px;
            padding: 0px 5px 0px 0px;
        }
    </style>
    <style type="text/css">
        @media only screen and (max-width: 1280px) {

            .PendingTblSalOut {
                width: 100%;
                float: left;
                margin: 0px 0px 0px 4px;
                overflow: auto;
                height: 410px;
                /*border: 1px solid #b1b1b1;*/
            }

            #Panel7 {
                float: left;
                width: 67%;
                margin: 0px 0px 0px 20px !important;
                margin: 2px 0px 0px 0px;
                height: 74px;
                min-height: 380px;
                /* border: 1px solid #003a65; */
            }

            .PendingLeft4 {
                float: left;
                width: 100%;
                margin: 0px 0px 0px 0px;
            }

            .Div_GridHome {
                width: 58.8%;
                float: left;
                height: 372px;
                margin-top: 0%;
                margin-left: 10px;
            }

            /*#Div2 {
    width: 40%;
    float: left;
}*/

        }

        .Hide1 {
            display: none;
        }

        /* FixedHeader */
        .BandMiddle {
            width: 100%;
        }
    </style>

    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
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
    <style type="text/css">
        .left_btn {
            float: left;
            margin: 0px 0px 6px 0px;
        }

        .btn-get1 input {
            margin: 0px 0px 0px 2px;
            padding: 5px 0px 6px 28px;
        }

        a {
            color: #4e4e4c;
        }

        .CreditExemptions {
            width: 14.2% !important;
            min-height: 114px;
            float: left;
            background-color: #7b8d8e;
            margin: 0px 0px 0px 0px;
        }

            .CreditExemptions h3 {
                color: #ecf7f8;
                padding: 6px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

        .CollectionAdvise {
            width: 14.2% !important;
            min-height: 114px;
            float: left;
            background-color: #a30b10;
            margin: 0px 0px 0px 0px;
        }

            .CollectionAdvise h3 {
                color: #ecf7f8;
                padding: 6px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

        .PerformBox {
            width: 12.5%;
            min-height: 91px;
            background-color: #16365c;
            margin: 0px 0px 0px 0px;
            float: left;
        }

        .OutStandingBox {
            width: 12.5% !important;
            min-height: 114px;
            background-color: #963634;
            margin: 0px 0px 0px 0px;
            float: left;
        }

        .OceanTxt {
            width: 115px;
            float: left;
            margin: 5px 0px 0px 0px;
        }

        .BookingBox {
            width: 12.5% !important;
            min-height: 114px;
            float: left;
            background-color: #8a933c;
            margin: 0px 0px 0px 0px;
        }

        .QuotationBox {
            width: 12.5% !important;
            min-height: 103px;
            float: left;
            background-color: #60497a;
            margin: 0px 0px 0px 0px;
        }

        .QuotationBox1 {
            width: 12.5% !important;
            min-height: 114px;
            float: left;
            background-color: #974706;
            margin: 0px 0px 0px 0px;
        }

        .CreditRequest {
            width: 12.5% !important;
            min-height: 114px;
            float: left;
            background-color: #215967;
            margin: 0px 0px 0px 0px;
        }

        .CreditExemptions {
            width: 12.5% !important;
            min-height: 114px;
            float: left;
            background-color: #7b8d8e;
            margin: 0px 0px 0px 0px;
        }

        .CollectionAdvise {
            width: 12.5% !important;
            min-height: 114px;
            float: left;
            background-color: #a30b10;
            margin: 0px 0px 0px 0px;
        }

            .CollectionAdvise span {
                color: #f2dcdb;
                display: block;
                margin: 6px 5px -9px 0px;
                float: right;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

            .CollectionAdvise img {
                text-align: center;
                margin: 0px 10px 0px 85px;
                float: right;
            }

        .OutStandingBox span {
            color: #f2dcdb;
            display: block;
            margin: 18px 10px -10px 0px;
            float: right;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .PerformBox span {
            color: #c5d9f1;
            display: block;
            margin: 16px 10px -8px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .CollectionAdHead {
            font-size: 11px;
            font-family: sans-serif;
            margin: 7px 0px 0px 0px;
            padding: 2px 5px 0px 0px;
            color: var(--grey);
            width: 150px;
            float: left;
        }

        .Collectionleft {
            float: left;
            width: 99%;
            margin: 0px 0px 0px 5px;
        }
        .gridpnl {
    height: calc(100vh - 68px);
}
        div#UpdatePanel1 {;
    overflow-y: hidden !important;
}
    </style>

    <%--TEST--%>

    <script type="text/javascript">

        window.onload = function () {

            //function PieChart() {
            var l1 = $("#<%= hidfe.ClientID %>").html();
            var l2 = $("#<%=hidfi.ClientID %>").html();
            var l3 = $("#<%=hidae.ClientID %>").html();
            var l4 = $("#<%=hidai.ClientID %>").html();

            var chart = new CanvasJS.Chart("chartContainer2",
            {
                title: {
                    text: ""
                },
                data: [
                {
                    type: "pie",
                    dataPoints: [
                        { y: l1 - 0, indexLabel: "Ocean Exports" },
                        { y: l2 - 0, indexLabel: "Ocean Imports" },
                        { y: l3 - 0, indexLabel: "Air Exports" },
                        { y: l4 - 0, indexLabel: "Air Imports" },
                    ]
                }
                ]
            });

            chart.render();
        }

        //<a href="somepage.htm" id="smartLink" onclick="return smartLink_click();"></a>

        function lnk_booking_Click() {

            //do some stuff here
            return false;
        }

    </script>

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("#<%=txtPOL.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../Home/SalesHome.aspx/GetPOL",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (event, i) {
                        $("#<%=txtPOL.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtPOL.ClientID %>").change();
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPOL.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPOL.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_POL.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtPOL.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPOL.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtPOD.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../Home/SalesHome.aspx/GetPOD",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (event, i) {
                        $("#<%=txtPOD.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtPOD.ClientID %>").change();
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPOD.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPOD.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_POD.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtPOD.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPOD.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

        }

    </script>
    <%-- <script type="text/javascript">
        // Global variable to hold data
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
        <script type="text/javascript">
            $(function ()
            {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: '../Home/SalesHome.aspx/GetChartData',
                    data: '{}',
                    success:
                    function (response) {
                        drawchart(response.d);
                    },

                    error: function () {
                        // alertify.alert("Error loading data! Please try again.");
                    }
                });
            })
            function drawchart(dataValues) {
                var l1 = $("#<%=Label1.ClientID %>").html();
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Column Name');
                data.addColumn('number', 'Column Value');
                for (var i = 0; i < dataValues.length; i++) {
                    data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
                }
                new google.visualization.PieChart(document.getElementById('chartdiv')).
                draw(data, { title: l1 });
            }
        </script>--%>
    <style type="text/css">
        div#logix_CPH_Panel7 {
            width: 65%;
            float: left;
            margin: 0px 0px 0px 10px;
        }

        /* Bottom Box Design Style Start */
        .Called {
            width: 33.33% !important;
            min-height: 85px;
            background-color: #16365c;
            margin: 19px 0px 0px 0px;
            float: left;
        }

            .Called h3 {
                color: #ffffff;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .Called span {
                color: #c5d9f1;
                display: block;
                margin: 20px 10px -8px 0px;
                text-align: right;
                padding: 0px 0px 15px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .ApprovedBox1 {
            width: 33.33% !important;
            min-height: 85px;
            background-color: #963634;
            margin: 19px 0px 0px 0px;
            float: left;
        }

            .ApprovedBox1 h3 {
                color: #ffffff;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

        .PendingBooking {
            width: 33.33% !important;
            min-height: 85px;
            float: left;
            background-color: #8a933c;
            margin: 19px 0px 0px 0px;
        }

            .PendingBooking h3 {
                color: #ffffff;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .PendingBooking span {
                color: #fde9d9;
                display: block;
                margin: 20px 10px 0px 0px;
                text-align: right;
                padding: 0px 0px 5px 0px;
                font-family: "Segoe UI";
                font-size: 24px;
                font-weight: bold;
            }

        .ApprovedBox1 span {
            color: #c5d9f1;
            display: block;
            margin: 20px 10px -8px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .BookingBox span {
            margin: 10px 10px 0px 0px;
        }

            .BookingBox span.LeftFloat {
                float: left;
                padding: 0px 0px 0px 10px;
                text-align: left;
            }

            .BookingBox span.RightFloat {
                float: right;
                padding: 0px 10px 0px 0px;
                text-align: left;
            }

        .BookingBox label.Approved {
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

        .BookingBox label.Unapproved {
            color: #ffffff;
            display: block;
            width: 85px;
            float: right;
            padding: 1px 5px 0px 0px;
            text-align: right;
            margin: 0px 0px 0px 5px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }
        /* Bottom Box Style End*/

        .BlueOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 5px 0px 5px;
        }

            .BlueOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .BlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 20px 15px;
            float: left;
            color: #4e73df !important;
        }

        .BlueRightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 5px 10px 0px 0px;
            float: right;
            text-align: right;
            width: 63%;
            font-size: 22px;
        }

        .GreenOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 5px 0px 0px;
        }

            .GreenOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .GreenText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 20px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDown {
            color: #1cc88a !important;
            margin: 5px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 63%;
            text-align: right;
        }

        .LiteBlueOuter {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 5px 0px 0px;
        }

            .LiteBlueOuter:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .LiteBlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 20px 15px;
            float: left;
            color: #36b9cc !important;
        }

        .LtBlueRightSideDown {
            color: #36b9cc !important;
            margin: 5px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 63%;
            text-align: right;
        }

        .YellowOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #f6c23e !important;
            float: left;
            background-color: #fff;
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 5px 0px 0px;
        }

            .YellowOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .YellowText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #f6c23e !important;
        }

        .YellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 63%;
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
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 5px 0px 0px;
        }

            .GreenOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .GreenText2 {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 25px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDown2 {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            float: right;
            font-family: 'OpenSansSemibold';
            font-size: 22px;
            width: 63%;
            text-align: right;
        }

        .BlueOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 5px 0px 0px;
        }

            .BlueOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .Blue2Text {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 25px 15px;
            float: left;
            color: #4e73df !important;
        }

        .Blue2RightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 0px 10px 0px 0px;
            float: right;
            font-size: 22px;
            width: 63%;
            text-align: right;
        }

        .RedOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #e74a3b !important;
            float: left;
            background-color: #fff;
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 5px 0px 0px;
        }

            .RedOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .RedText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 25px 15px;
            float: left;
            color: #e74a3b !important;
        }

        .RedRightSideDown {
            color: #e74a3b !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 63%;
            text-align: right;
        }

        .LiteBlueOuter2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 100px;
            padding: 15px 0px 5px 0px;
            width: 165px;
            margin: 5px 0px 0px 0px;
        }

            .LiteBlueOuter2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .LiteBlueText2 {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 20px 15px;
            float: left;
            color: #36b9cc !important;
        }

        .LtBlueRightSideDown2 {
            color: #36b9cc !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 63%;
            text-align: right;
        }

        .PageHeight {
            background-color: #fff !important;
        }

        label.LeftSideValue1,
        label.RightSideValue1,
        span#logix_CPH_span_ebook {
            display: none;
        }

        .Divimg {
            width: 20%;
            float: left;
            margin: 8px 0px 0px 15px;
        }

        .LeftSideValue {
            float: left;
            width: 60px;
            font-family: 'OpenSansRegular';
            margin: 5px 0px 0px 15px;
            font-size: 11px;
            font-weight: bold;
            color: #f6c23e !important;
        }

        .RightSideValue {
            float: right;
            width: 75px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 3px 0px 0px;
            color: #f6c23e !important;
        }

        .LeftNumValue {
            color: #f6c23e !important;
            margin: 5px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 22px;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue {
            color: #f6c23e !important;
            margin: 5px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 22px;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }

        .BlueOuterDivNew {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 95px;
            padding: 15px 0px 5px 0px;
            width: 447px;
            margin: 5px 8px 0px 5px;
        }

            .BlueOuterDivNew:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .BlueTextNew {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 15px 15px;
            float: left;
            color: #4e73df !important;
        }

        .BlueRightSideDownNew {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 5px 10px 0px 0px;
            float: right;
            text-align: right;
            width: 75%;
            font-size: 25px;
        }

        .GreenOuterDivNew {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 95px;
            padding: 15px 0px 5px 0px;
            width: 442px;
            margin: 5px 5px 0px 0px;
        }

            .GreenOuterDivNew:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .GreenTextNew {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 15px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDownNew {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 27px;
            width: 75%;
            text-align: right;
        }

        .LiteBlueOuterNew {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 95px;
            padding: 15px 0px 5px 0px;
            width: 443px;
            margin: 5px 8px 0px 0px;
        }

            .LiteBlueOuterNew:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .LiteBlueTextNew {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 15px 15px;
            float: left;
            color: #36b9cc !important;
        }

        .LtBlueRightSideDownNew {
            color: #36b9cc !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 27px;
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
            height: 95px;
            padding: 15px 0px 5px 0px;
            width: 325px;
            margin: 5px 8px 0px 0px;
        }

            .NewYellowOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewYellowText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 15px 15px;
            float: left;
            color: #f6c23e !important;
        }

        .NewYellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 27px;
            width: 75%;
            text-align: right;
            /*transform: rotate(-179deg);*/
        }

        .LeftSideValue1 {
            float: left;
            width: 60px;
            font-family: 'OpenSansRegular';
            margin: 5px 0px 0px 15px;
            font-size: 11px;
            font-weight: bold;
            color: #36b9cc !important;
        }

        .RightSideValue1 {
            float: right;
            width: 60px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 3px 0px 0px;
            color: #36b9cc !important;
        }

        .LeftNumValue1 {
            color: #36b9cc !important;
            margin: 5px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 22px;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue1 {
            color: #36b9cc !important;
            margin: 5px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 22px;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <%--<script type="text/javascript">
     google.load("visualization", "1", { packages: ["corechart"] });
     google.setOnLoadCallback(drawChart);
     function drawChart() {
         var options = {
             title: 'USA City Distribution',
             is3D: true
         };
         $.ajax({
             type: "POST",
             url: "../Home/SalesHome.aspx/GetChartData",
             data: '{}',
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (r) {
                 var data = google.visualization.arrayToDataTable(r.d);
                 var chart = new google.visualization.PieChart($("#chartdiv")[0]);
                 chart.draw(data, options);
             },
             failure: function (r) {
                 alertify.alert(r.d);
             },
             error: function (r) {
                 alertify.alert(r.d);
             }
         });
     }
</script>--%>

    <%--<script type="text/javascript">
         // Global variable to hold data
         google.load('visualization', '1', { packages: ['corechart'] });
    </script>--%>
    <%--<script type="text/javascript">
             $(function () {
                 $.ajax({
                     type: 'POST',
                     dataType: 'json',
                     contentType: 'application/json',
                     url: '../Home/SalesHome.aspx/GetChartPerformance',
                     data: '{}',
                     success:
                     function (response) {
                         drawchart(response.d);
                     },

                     error: function () {
                         // alertify.alert("Error loading data! Please try again.");
                     }
                 });
             })
             function drawchart(dataValues) {
                 var l1 = $("#<%=lblPerformance.ClientID %>").html();
                 var data = new google.visualization.DataTable();
                 data.addColumn('string', 'Column Name');
                 data.addColumn('number', 'Column Value');
                 for (var i = 0; i < dataValues.length; i++) {
                     data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
                 }
                 new google.visualization.PieChart(document.getElementById('chartdivper')).
            draw(data, { title: l1 });

             }
    </script>--%>

    <%--<script type="text/javascript">
         google.load("visualization", "1", { packages: ["corechart"] });
         google.setOnLoadCallback(drawChart1);
         function drawChart1() {
             var options = {
                 title: ''
             };
             $.ajax({
                 type: "POST",
                 url: "../Home/SalesHome.aspx/GetChartPerformance",
                 data: '{}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (r) {
                     var data = google.visualization.arrayToDataTable(r.d);
                     var chart = new google.visualization.PieChart($("#chartdivper")[0]);
                     chart.draw(data, options);
                 },
                 failure: function (r) {
                     alertify.alert(r.d);
                 },
                 error: function (r) {
                     alertify.alert(r.d);
                 }
             });
         }
</script>--%>
    <%--<script type="text/javascript">
            $(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: '../Home/SalesHome.aspx/GetChartDataBook',
                    data: '{}',
                    success:
                    function (response) {
                        drawchart(response.d);
                    },

                    error: function () {
                        // alertify.alert("Error loading data! Please try again.");
                    }
                });
            })
            function drawchart(dataValues) {
                var l1 = $("#<%=Label1.ClientID %>").html();
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Column Name');
                data.addColumn('number', 'Column Value');
                for (var i = 0; i < dataValues.length; i++) {
                    data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
                }
                new google.visualization.PieChart(document.getElementById('chartdivBook')).
            draw(data, { title: l1 });

            }
    </script>--%>
    <%--<script type="text/javascript">
            $(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: '../Home/SalesHome.aspx/GetChartDataExemption',
                    data: '{}',
                    success:
                    function (response) {
                        drawchart(response.d);
                    },

                    error: function () {
                        // alertify.alert("Error loading data! Please try again.");
                    }
                });
            })
            function drawchart(dataValues) {
                var l1 = $("#<%=Label1.ClientID %>").html();
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Column Name');
                data.addColumn('number', 'Column Value');
                for (var i = 0; i < dataValues.length; i++) {
                    data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
                }
                new google.visualization.PieChart(document.getElementById('chartdivexcp')).
            draw(data, { title: l1 });

            }
    </script>--%>

    <noscript>
        Your browser does not support JavaScript!

    </noscript>
    <style>
        .HomeMenuBox {
            width: 18% !important;
            height: 108vh !important;
        }

        .HomeMenuContent {
            width: 82%;
            float: left;
            margin:20px 0 0;
        }

        .HomeMenuBox a:hover {
            color: var(--lableblack);
        }

        .menubox {
            display: flex;
        }

        .menuboximage {
            width: 50px;
        }

        .menuboxcontent {
            flex-basis: 0;
            flex-grow: 1;
            max-width: 100%;
        }

        .menubox .title {
            font-size: 14px !important;
            width: 100%;
            display: inline-block;
        }

            .menubox .title::first-letter {
                font-size: 20px;
                color: #06529c !important;
            }

        .menubox .Amount {
            color: #f8a350;
            font-size: 18px;
        }

        .widget-content {
            padding: 0 0px !important;
        }

      
        .PageHeight {
    padding-top: 0px;
    height: 100vh;
    padding-bottom: 8px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="maindiv">
    <div class="Clear"></div>
    <div class="BandMiddle">
        <div class="BreadLabel" id="OptionDoc" runat="server">Sales</div>

    </div>

    <div class="BandTop">
        <div class="BandLeft">
            <div style="float: left; width: 185px;">
                <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png" />
                    <asp:LinkButton ID="lnkNewCustomerRequest" runat="server" Style="text-decoration: none" OnClick="lnkNewCustomerRequest_Click">New Customer Request</asp:LinkButton></h3>
            </div>
            <div style="float: left; width: 100px;">
                <h3>
                    <img src="../Theme/assets/img/costing.png"><asp:LinkButton ID="LinkButton8" runat="server" Text="Costing" OnClick="LinkButton8_Click"></asp:LinkButton>
                </h3>
            </div>

            <%--  <div style="float:left; width:100px;">
                <h3>
                    <img src="../Theme/assets/img/costing.png"><asp:LinkButton ID="LinkButton1" runat="server" Text="ProcessImageUpload" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </h3>
                    </div>--%>
        </div>

        <div class="BandRight">

            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/stationary.png" /><asp:LinkButton ID="lnkauo" runat="server" Text="Quotation Multiport" OnClick="lnkauo_Click"></asp:LinkButton></h3>
            </div>
        </div>
    </div>

    <div class=" FormGroupContent4 ">
        <div class="HomeMenuBox ">

            <asp:LinkButton ID="lnkApproved" runat="server" OnClick="lnkApproved_Click" CssClass="AppLink">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/approvedquotation.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Approved Quotations</span>
                        <span id="span_quotapp" runat="server" class=" Amount"></span>
                    </div>
                </div>

                <%--<asp:LinkButton ID="lnkUnapp" runat="server" OnClick="lnkUnapp_Click" CssClass="UnAppLink">
                             </asp:LinkButton>--%>
            </asp:LinkButton>

            <asp:LinkButton ID="lnkunapproved"  runat="server" OnClick="lnkunapproved_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/unapprovedquotation.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Unapproved Quotations</span>
                        <span id="span_quotunapp" runat="server" class=" Amount"></span>

                    </div>
                </div>
            </asp:LinkButton>

            <asp:LinkButton ID="link_booking" runat="server" OnClick="link_booking_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/booking.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Booking</span>
                        <span id="span_book" runat="server" class=" Amount"></span>
                    </div>
                </div>
            </asp:LinkButton>

            <asp:LinkButton ID="linkworkprogess" runat="server" OnClick="linkworkprogess_Click">

                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/openjobs.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Open Jobs</span>
                        <span id="span_wokingprogess" runat="server" class=" Amount"></span>
                    </div>
                </div>

            </asp:LinkButton>

            <asp:LinkButton ID="lnkPerfo" runat="server" OnClick="lnkPerfo_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/performance.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Performance</span>
                        <span id="spPerformance" runat="server" class="Amount"></span>
                    </div>
                </div>
            </asp:LinkButton>

            <asp:LinkButton ID="linkoust" runat="server" OnClick="linkoust_Click">
                <div class="menubox">

                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/outstanding.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Outstanding</span>
                        <span id="lbl_outstanding" runat="server" class="Amount"></span>
                    </div>
                </div>
            </asp:LinkButton>

            <asp:LinkButton ID="link_ebooking" runat="server" CssClass="hide" OnClick="link_ebooking_Click">
                <span id="span_ebook" runat="server" class=" Amount1"></span>
            </asp:LinkButton>

            <asp:LinkButton ID="lnkcreditRequest" runat="server" OnClick="lnkcreditRequest_Click" Visible="false">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/creditrequest.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Credit Requests</span>
                        <span id="span_creditreq" runat="server" class=" Amount"></span>

                    </div>
                </div>

            </asp:LinkButton>

            <asp:LinkButton ID="lnkCreditEx" runat="server" OnClick="lnkCreditEx_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/exemptions.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Exemptions</span>
                        <span id="spCredEx" runat="server" class=" Amount"></span>

                    </div>
                </div>

            </asp:LinkButton>

            <asp:LinkButton ID="lnk_collectionAdvise" runat="server" CssClass="hide" OnClick="lnk_collectionAdvise_Click">
                <div class="menubox">
                    <div class="menuboximage">
                        <img src="../Theme/assets/img/dashboard/testimage48.png" />
                    </div>
                    <div class="menuboxcontent">
                        <span class="title">Collection Advise</span>
                        <span id="spn_collectionadvise" runat="server" class=" Amount"></span>

                    </div>
                </div>

            </asp:LinkButton>

        </div>
        <div class="HomeMenuContent">

            <div class="widget-content">
        <div class="FormGroupContent4">
        <div class="Chart2">
            <asp:Literal ID="lt" runat="server"></asp:Literal>
            <div id="chart_div"></div>
        </div>
        <div class="Chart1">
            <%-- <asp:Chart ID="chartoperProfit" runat="server" Width="500px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                    <Series>
                                        <asp:Series Name="Series1" Color="#0000ff">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>--%>
            <asp:Literal ID="lts" runat="server"></asp:Literal>
            <div id="chart_divbar"></div>

        </div>
        </div>

                <div id="Divout" runat="server" style="float: left; width: 33.5%; margin: 0px 0px 0px 2px;">
                    <div>
                        <div class="PendingRightSalesSub">
                            <div class="SalesTitleNew1" style="display: none;">
                                <asp:Label ID="lbloutStanding" runat="server" Text="OutStanding"></asp:Label>
                            </div>
                            <div class="divSalesNew" style="display: none;">
                                <asp:Button ID="btnoutExcel" runat="server" Text="Export To Excel" OnClick="btnoutExcel_Click" />
                            </div>
                            <div class="btn ico-get" style="display: none">
                                <asp:Button ID="btnGetNew" runat="server" Text="Get" OnClick="btnGetNew_Click" />
                            </div>
                        </div>

                        <div id="div_out" runat="server">
                            <div class="PendingTblSalOut">

                                <div class="SalesTitleOut">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                                <div class="right_btn ">
                                    <asp:LinkButton ID="lnk_Perfor_det" runat="server" OnClick="lnk_Perfor_det_Click" Visible="false">
                                             <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                                    </asp:LinkButton>
                                </div>

                                <asp:Panel ID="Panel2" runat="server" Visible="true">
                                    <asp:GridView ID="grdOutStanding" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdOutStanding_RowDataBound" OnSelectedIndexChanged="grdOutStanding_SelectedIndexChanged">
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" Width="30px" />
                                                    <HeaderStyle Wrap="false" Width="30px" />
                                                </asp:TemplateField>--%>
                                            <asp:BoundField DataField="SI" HeaderText="S#">
                                                <HeaderStyle Wrap="true" Width="30px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="true" Width="30px" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Customer" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                        <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%# Bind("customer") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="custid" HeaderText="Custid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="true" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>

                                            <%--  <asp:BoundField DataField="amount" HeaderText="Amount">
                                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="true" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                                </asp:BoundField>--%>

                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis;">
                                                        <asp:LinkButton ID="amount" runat="server" Text='<%# Bind("amount") %>' ToolTip='<%# Bind("amount") %>' OnClick="amount_Click"></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="OverDue Amt" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis;">
                                                        <asp:LinkButton ID="overdueamt" runat="server" Text='<%# Bind("overdueamt") %>' ToolTip='<%# Bind("overdueamt") %>' OnClick="overdueamt_Click"></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Amt" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis;">
                                                        <asp:LinkButton ID="totalamt" runat="server" Text='<%# Bind("totalamt") %>' ToolTip='<%# Bind("totalamt") %>' OnClick="totalamt_Click"></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>

                            </div>
                            <%--    <div runat="server" id="div5" class="PendingRightnew">
                                    <div id="chartdiv" style="width: 450px; height: 290px; margin-left:450px;">
                                    </div>
                                </div>--%>
                        </div>

                    </div>

                </div>

                <div class="PieChart" id="PieChart2" runat="server">
                    <asp:Chart ID="Chart1" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                        <%--<Legends>        
                                    <asp:Legend Alignment="Center" Docking="Left" IsTextAutoFit="true" Name="StateName" LegendStyle="Table"/>
                                    </Legends>--%>

                        <Series>
                            <asp:Series Name="Series1" Color="#ffcc00" ChartType="Pie" CustomProperties="PieLineColor=Black,PieLabelStyle=Outside">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" />
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>

                </div>

                <asp:Panel ID="Panel7" runat="server" Visible="false" ScrollBars="Auto">
                    <div class="SalesTitlePerP">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </div>
                    <div class="right_btn ">
                        <asp:LinkButton ID="excportexc" runat="server" OnClick="excportexc_Click">
                                                  <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                        </asp:LinkButton>
                        <%-- <asp:Button ID="btnexport" runat="server" Text="Export Excel" CssClass="Exportbtn"  OnClick="btnexport_Click"/>--%>
                    </div>

                    <div class="gridpnl">
                        <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" Visible="false" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black"
                            EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GridView2_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="15px" />
                                    <HeaderStyle Wrap="false" Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="shortname" HeaderText="Branch">
                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="120px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="voutype" HeaderText="voutype">
                                    <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="vouno" HeaderText="vou#">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="voudate" HeaderText="Date">
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="120px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="jobno" HeaderText="Job#">
                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="refno" HeaderText="BL#">
                                    <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="200px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="amount" HeaderText="Amount">
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="100px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nodays" HeaderText="Days">
                                    <HeaderStyle Wrap="true" Width="40px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="40px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="overdue" HeaderText="Overdue">
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="100px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="overduedays" HeaderText="Days">
                                    <HeaderStyle Wrap="true" Width="40px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="40px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle Font-Italic="False" />
                        </asp:GridView>
                    </div>

                </asp:Panel>

                <div style="float: left; width: 74%; margin: 0px 0px 0px 0px;">

                    <%-- <div class="PendingBookingSalesHome">
                    <ul>
                    <li>
                    <img src="../Theme/assets/img/booking_ic2.png" /><asp:LinkButton ID="lnk_booking" runat="server"  Style="text-decoration: none; margin-bottom: 0px;" OnClick="lnk_booking_Click"></asp:LinkButton></li>
                    <li>
                    <img src="../Theme/assets/img/workinprogress_ic.png" /><asp:LinkButton ID="lblWorking" runat="server"  Style="text-decoration: none" OnClick="lblWorking_Click" ></asp:LinkButton></li>
                    <li><img src="../Theme/assets/img/quotation_img.png" />
                    <asp:LinkButton ID="lnk_quotion" runat="server"  Style="text-decoration: none" OnClick="lnk_quotion_Click" ></asp:LinkButton></li>
                    <div class="Clear"></div>
                    <li><img src="../Theme/assets/img/outstanding_ic.png" /><asp:LinkButton ID="lnk_outStanding" runat="server" Style="text-decoration: none;" OnClick="lnk_outStanding_Click"></asp:LinkButton></li>
                    <li><img src="..//Theme/assets/img/performance_ic.png" /><asp:LinkButton ID="linkPerfomance" runat="server" Style="text-decoration: none" OnClick="linkPerfomance_Click" ></asp:LinkButton></li>--%>
                    <%--  <li> <img src="../Theme/assets/img/deposit_ic.png" />
                    <asp:LinkButton ID="lnkExReate" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnkExReate_Click" >Ex Rate</asp:LinkButton></li>--%>
                    <%-- </ul>
                </div>--%>
                    <div id="div_quotdetails" runat="server" visible="false"></div>

                </div>
                <div id="Div4" runat="server">
                    <div class="PendingRightSalesCreditEx">

                        <div class="SalesTitleB2" style="border: 0px solid #f00;">Credit Requests</div>
                        <div class="right_btn">

                            <asp:LinkButton ID="credit_excel" runat="server" OnClick="credit_excel_Click">
                                     <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>
                            <%--<asp:Button ID="btn_creditrequest" runat="server" Text="Export Excel" CssClass="Exportbtn" OnClick="btn_creditrequest_Click" />--%>
                        </div>
                        <div style="clear: both;"></div>
                        <asp:Panel ID="pnl_credit" runat="server" CssClass="gridpnl">
                            <asp:GridView ID="grid_credit"
                                CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
                                Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found"
                                BackColor="White" ShowHeaderWhenEmpty="true"
                                OnRowDataBound="grid_credit_RowDataBound" OnPreRender="grid_credit_PreRender">
                                <Columns>
                                    <asp:BoundField
                                        DataField="sno" HeaderText="S #">
                                        <ItemStyle Width="40px" />
                                        <HeaderStyle Width="40px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <div
                                                style="overflow: hidden; text-overflow: ellipsis; width: 420px">
                                                <asp:Label
                                                    ID="customername" runat="server" Text='<%#Bind("customername") %>'
                                                    ToolTip='<%#Bind("customername") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle
                                            Wrap="false" Width="220px" HorizontalAlign="Center" />
                                        <ItemStyle
                                            Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField HeaderText="Requested Days">
                                                <ItemTemplate>
                                                    <div
                                                        style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label
                                                            ID="creditdays" runat="server" Text='<%#Bind("creditdays") %>'
                                                            ToolTip='<%#Bind("creditdays") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle
                                                    Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle
                                                    Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

                                    <asp:BoundField DataField="creditdays" HeaderText="Requested Days">
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                    </asp:BoundField>
                                    <%-- <asp:TemplateField HeaderText="Requested Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemTemplate >
                                                    <div
                                                        style="overflow: hidden; text-overflow: ellipsis;  text-align:right;">
                                                        <asp:Label
                                                            ID="lbl_custname" runat="server" Text='<%#Bind("creditamt") %>'
                                                            ToolTip='<%#Bind("creditamt") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle
                                                    Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle
                                                    Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
                                    <asp:BoundField DataField="creditamt" HeaderText="Requested Amount">
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="creditreqon" HeaderText="Requested On">
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                    </asp:BoundField>
                                    <%--    <asp:TemplateField HeaderText="Requested On">
                                                <ItemTemplate>
                                                    <div
                                                        style="overflow: hidden; text-overflow: ellipsis;">
                                                        <asp:Label
                                                            ID="creditreqon" runat="server" Text='<%#Bind("creditreqon") %>'
                                                            ToolTip='<%#Bind("creditreqon") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle
                                                    Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle
                                                    Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
                                    <%--  <asp:TemplateField HeaderText="Approved days">
                                                <ItemTemplate>
                                                    <div
                                                        style="overflow: hidden; text-overflow: ellipsis;">
                                                        <asp:Label
                                                            ID="bappdays" runat="server" Text='<%#Bind("bappdays") %>'
                                                            ToolTip='<%#Bind("bappdays") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle
                                                    Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle
                                                    Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
                                    <asp:BoundField DataField="bappdays" HeaderText="Approved days">
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                    </asp:BoundField>
                                    <%-- <asp:TemplateField HeaderText="Approved Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemTemplate>
                                                    <div
                                                        style="overflow: hidden; text-overflow: ellipsis; text-align:right;">
                                                        <asp:Label
                                                            ID="lbl_custname" runat="server" Text='<%#Bind("bappamount") %>'
                                                            ToolTip='<%#Bind("bappamount") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle
                                                    Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle
                                                    Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
                                    <asp:BoundField DataField="bappamount" HeaderText="Approved Amount">
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="appon" HeaderText="Approved On">
                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                    </asp:BoundField>
                                    <%-- <asp:TemplateField HeaderText="Approved On">
                                                <ItemTemplate>
                                                    <div
                                                        style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label
                                                            ID="appon" runat="server" Text='<%#Bind("appon") %>'
                                                            ToolTip='<%#Bind("appon") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle
                                                    Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle
                                                    Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle
                                    CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                </div>
                <div class="PendingRightSalesNewQ" id="divQuot" runat="server">
                    <div class="SalesTitleNew">
                        <asp:Label ID="lblQuation" runat="server" Text="Quotation"></asp:Label>
                    </div>
                    <div class="divSalesN2">
                        <div class="right_btn">

                            <asp:LinkButton ID="quatatio_exce" runat="server" OnClick="quatatio_exce_Click">
                                 
                                             <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                               
                            </asp:LinkButton>
                            <%--    <asp:Button ID="btnQuatotion" runat="server" CssClass="Exportbtn" Text="Export To Excel" OnClick="btnQuatotion_Click" />--%>

                            <div class="btn ico-get" style="display: none">
                                <asp:Button ID="btnGetQuot" runat="server" Text="Get" OnClick="btnGetQuot_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="PendingTblSalOutGrd" id="quot" runat="server">
                        <asp:Panel ID="Panel3" runat="server" Visible="true" CssClass="gridpnl">
                            <asp:GridView ID="grdQuatotion" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="grdQuatotion_SelectedIndexChanged"
                                OnRowDataBound="grdQuatotion_RowDataBound" OnPreRender="grdQuatotion_PreRender">
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
                    </div>

                </div>

                <div class="PendingRightSalesNewQ" id="divebooking" runat="server">
                    <div class="SalesTitleNew">
                        <asp:Label ID="Label6" runat="server" Text="e-Booking"></asp:Label>
                    </div>
                    <div class="divSalesN2">
                        <div class="right_btn ">

                            <asp:LinkButton ID="LinkButton2" runat="server">
                                             <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                            </asp:LinkButton>
                            <%--    <asp:Button ID="btnQuatotion" runat="server" CssClass="Exportbtn" Text="Export To Excel" OnClick="btnQuatotion_Click" />--%>

                            <%--<div class="btn ico-get" style="display: none">
                                            <asp:Button ID="Button1" runat="server" Text="Get" OnClick="btnGetQuot_Click" />
                                        </div>--%>
                        </div>
                    </div>
                    <div class="PendingTblSalOutGrd" id="EbookingDiv6" runat="server">
                        <asp:Panel ID="EbookingPanel11" runat="server" Visible="true" CssClass="TblScroll">
                            <asp:GridView ID="grdebooking" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black"
                                EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="grdebooking_SelectedIndexChanged"
                                OnRowDataBound="grdebooking_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" Width="30px" />
                                        <HeaderStyle Wrap="true" Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Bookingno" HeaderText="e-Booking #">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Branch" HeaderText="Branch">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="POL" HeaderText="POL">
                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="POR" HeaderText="POR">
                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="POD" HeaderText="POD">
                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FD" HeaderText="FD">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Shipper" HeaderText="Shipper">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Consignee" HeaderText="Consignee">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="NotifyParty" HeaderText="NotifyParty">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cargodet" HeaderText="Cargo Details">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="confirmed" HeaderText="confirmed">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" CssClass="Hide1" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left" CssClass="Hide1"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Bookno" HeaderText="Bookno">
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" CssClass="Hide1" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left" CssClass="Hide1"></ItemStyle>
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>

                <div id="Div3" runat="server">
                    <div class="PendingRightSalesN12">
                        <div id="Div2" runat="server" visible="true">

                            <div class="SalesTitleBCE" style="border: 0px solid #f00;">Credit Exemption</div>
                            <%-- <div style="clear:both;"></div>--%>

                            <div class="left_btn MB18">
                                <asp:LinkButton ID="crdexp" runat="server" OnClick="crdexp_Click">
                                                  <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                                </asp:LinkButton>
                                <%-- <asp:Button ID="btnexport" runat="server" Text="Export Excel" CssClass="Exportbtn"  OnClick="btnexport_Click"/>--%>
                            </div>

                            <asp:Panel ID="panelservice" runat="server" CssClass="gridpnl" Style="overflow: auto;" Width="100%" >

                                <asp:GridView ID="divgrid" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" ForeColor="Black" EmptyDataText="No Record Found" BackColor="white" ShowHeaderWhenEmpty="true" OnRowDataBound="divgrid_RowDataBound" OnSelectedIndexChanged="divgrid_SelectedIndexChanged" OnPreRender="divgrid_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="SI" HeaderText="S #">
                                            <ItemStyle HorizontalAlign="Left" Wrap="true" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                                    <asp:Label ID="lbl_custname" runat="server" Text='<%#Bind("customer") %>'
                                                        ToolTip='<%#Bind("customer") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle
                                                Wrap="false" Width="250px" HorizontalAlign="Center" />
                                            <ItemStyle
                                                Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="exception" HeaderText="Exemption">
                                            <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="true" Width="100px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="customerid" HeaderText="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <%--   <ItemStyle HorizontalAlign="Left" Wrap="true" Width="40px"/>
                    <HeaderStyle Wrap="true" />--%>
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                            <%--   <div runat="server" id="div8" class="PendingRightnew">
                                    <div id="chartdivexcp" style="width: 360px; height: 250px;">
                                    </div>
                                </div>--%>
                        </div>

                        <div class="SalesTitleB4" style="border: 0px solid #f00;" id="CRequests" runat="server"></div>
                        <div class="right_btn">
                            <asp:LinkButton ID="exempexcel" runat="server" OnClick="exempexcel_Click">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <%--     <asp:Button ID="btn_exempt" runat="server" Text="Export Excel" CssClass="Exportbtn" OnClick="btn_exempt_Click" />--%>
                            <div style="clear: both;"></div>
                        </div>

                        <asp:Panel ID="panel8" runat="server" CssClass="gridpnl" Style="overflow: auto;">

                            <div>
                                <asp:GridView ID="griddata" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" ForeColor="Black" EmptyDataText="No Record Found" BackColor="white" ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" Width="30px" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Branch" HeaderText="Branch">
                                            <%--  <ItemStyle HorizontalAlign="Left" Wrap="true" Width="80px" />
                    <HeaderStyle Wrap="false" />--%>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Product" HeaderText="Product">
                                            <%--<ItemStyle HorizontalAlign="Left" Wrap="true" Width="60px" />
                    <HeaderStyle Wrap="false" />--%>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BL #" HeaderText="BL #">
                                            <%--<ItemStyle HorizontalAlign="Left" Wrap="true" Width="60px" />
                    <HeaderStyle Wrap="false" />--%>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Pol" HeaderText="POL">
                                            <%--   <ItemStyle HorizontalAlign="Left" Wrap="true" Width="60px" />
                    <HeaderStyle Wrap="false" />--%>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Pod" HeaderText="POD">
                                            <%--   <ItemStyle HorizontalAlign="Left" Wrap="true" Width="60px" />
                    <HeaderStyle Wrap="false" />--%>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exceptionon" HeaderText="Exemption ON">
                                            <ItemStyle HorizontalAlign="Left" Wrap="true" Width="100px" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>

                    </div>
                </div>

                <div id="divPerson" runat="server">
                    <div class="PendingLeftNew">
                        <div class="SalesTitlePerN1">
                            <asp:Label ID="lblPerformance" runat="server" Text="Performance"></asp:Label>
                        </div>
                        <div class="divSales1">
                            <div class="PorttxtNew1">
                                <span>From</span>
                                <asp:TextBox ID="txtFromdate" runat="server" CssClass="form-control" />
                                <ajax:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromdate"></ajax:CalendarExtender>
                            </div>

                            <div class="PorttxtNew">
                                <span>To</span>
                                <asp:TextBox ID="txtTodate" runat="server" CssClass="form-control" />
                                <ajax:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTodate"></ajax:CalendarExtender>
                            </div>
                            <div class="left_btn custom-mt-1">
                            <div class="btn ico-get">
                                <asp:Button ID="btnGet" runat="server" Text="Get" ToolTip="Get" OnClick="btnGet_Click" />
                            </div>
                                </div>
                        </div>
                        <div class=" FormGroupContent4">
                            <asp:Panel ID="PanelPendingEvent" runat="server" CssClass="relative custom-mt-1" Visible="true">
                                <asp:GridView ID="GrdSalesPerformance" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdSalesPerformance_RowDataBound" OnSelectedIndexChanged="GrdSalesPerformance_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" Width="30px" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Product" HeaderText="Product">
                                            <ItemStyle Wrap="true" Width="40px" />
                                            <HeaderStyle Wrap="true" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount">
                                            <ItemStyle Wrap="false"  CssClass="TxtAlign1" />
                                            <HeaderStyle Wrap="false" CssClass="align-right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>
                        <div class="right_btn MT0">
                            <asp:LinkButton ID="lnk_lblPerformance" runat="server" OnClick="lnk_lblPerformance_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <%--<asp:Button ID="btn_exempt" runat="server" Text="Export Excel" CssClass="Exportbtn" OnClick="btn_exempt_Click" />--%>
                            <div style="clear: both;"></div>
                        </div>

                        <%-- <div runat="server" id="div6" class="PendingRightnew">
                                    <div id="chartdivper" style="width: 800px; height: 300px; margin-left:320px;">
                                    </div>
                                </div>--%>
                    </div>
                </div>
                <div class="PendingRightnew">
                    <asp:Chart ID="chartper" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                        <%--<Legends>        
                                    <asp:Legend Alignment="Center" Docking="Left" IsTextAutoFit="true" Name="StateName" LegendStyle="Table"/>
                                    </Legends>--%>

                        <Series>
                            <asp:Series Name="Series1" Color="#ffcc00" ChartType="Pie" CustomProperties="PieLineColor=Black,PieLabelStyle=Outside">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" />
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <div id="logix_CPH_Pertitle" class="grid_P3 hide">

                        <div class="SalesTitlePer1">
                            <span id="logix_CPH_lbl_Perfor_det">Air Exports</span>

                        </div>
                        <div class="right_btn MB2">
                            <a id="logix_CPH_excl_export" href="javascript:__doPostBack('ctl00$logix_CPH$excl_export','')">
                                <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel">
                            </a>

                        </div>
                    </div>
                </div>

                <div class="grid_P3" id="Pertitle" runat="server">

                    <div class="SalesTitlePer1">
                        <asp:Label ID="lbl_Perfor_det" runat="server"></asp:Label>

                    </div>
                    <div class="right_btn ">
                        <asp:LinkButton ID="excl_export" runat="server" OnClick="excl_export_Click">
                                                 <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/>
                        </asp:LinkButton>
                        <asp:Button ID="btn_export" runat="server" Text="Export Excel" CssClass="Exportbtn hide" OnClick="btn_export_Click" />

                    </div>
                </div>

                <asp:Panel ID="Panel6" runat="server" CssClass="gridpnl" Visible="true" ScrollBars="Auto">

                    <asp:GridView ID="GridView3" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" OnRowDataBound="GridView3_RowDataBound">
                        <Columns>
                            <%--<%-- <asp:BoundField DataField="Product" HeaderText="Product">
                                                    <ItemStyle Wrap="false" Width="160px" />
                                                    <HeaderStyle Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <ItemStyle Wrap="false" Width="60px" />
                                                    <HeaderStyle Wrap="false" />
                                                </asp:BoundField>
                                              <%-- <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <ItemStyle Wrap="false" Width="60px" />
                                                    <HeaderStyle Wrap="false" />
                                                </asp:BoundField>--%>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <RowStyle Font-Italic="False" />
                    </asp:GridView>
                </asp:Panel>
                <div id="CallPannel" runat="server">
                    <div id="CalledTitle" runat="server" class="CalledHead">
                        <asp:Label ID="lblcallfoll" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="right_btn " style="display: none;">
                        <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel">
                    </div>
                    <asp:Panel ID="Panel10" runat="server" CssClass="gridpnl" Visible="true" ScrollBars="Auto">

                        <asp:GridView ID="GrdCustomer" runat="server" Width="100%" CellPadding="3" OnRowDataBound="GrdCustomer_RowDataBound" OnSelectedIndexChanged="GrdCustomer_SelectedIndexChanged"
                            AutoGenerateColumns="False" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" OnPreRender="GrdCustomer_PreRender">
                            <Columns>
                                <asp:BoundField DataField="customerid" HeaderText="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="customername" HeaderText="Company">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="location" HeaderText="Location">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="city" HeaderText="City">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pincode" HeaderText="Pincode">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="officetype" HeaderText="Office">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="website" HeaderText="Website">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="landline" HeaderText="Landline">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cityid" HeaderText="cityid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="countryid" HeaderText="LocationId" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="remarks" HeaderText="remarks" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle CssClass="GrdRow" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div class="Collectionleft" id="div_coll" runat="server">
                    <div class="CollectionAdHead">Collection Advise</div>
                    <div class="right_btn">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">
                                <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                        </asp:LinkButton>
                    </div>
                    <div class="Clear"></div>
                    <asp:Panel ID="PanelCollection" runat="server" CssClass="gridpnl" Visible="true" ScrollBars="Auto">

                        <asp:GridView ID="Grd_collection" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" OnRowDataBound="Grd_collection_RowDataBound" OnPreRender="Grd_collection_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="35px" />
                                    <HeaderStyle Wrap="false" Width="35px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="shortname" HeaderText="Branch">
                                    <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="200px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="120px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="voutype" HeaderText="voutype">
                                    <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="120px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="vouno" HeaderText="vou#">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="voudate" HeaderText="Date">
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="jobno" HeaderText="Job#">
                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="refno" HeaderText="BL#">
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="amount" HeaderText="Amount">
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="100px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nodays" HeaderText="Days">
                                    <HeaderStyle Wrap="true" Width="40px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="40px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="overdue" HeaderText="Overdue">
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="100px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="overduedays" HeaderText="Days">
                                    <HeaderStyle Wrap="true" Width="40px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="true" Width="40px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle Font-Italic="False" />
                        </asp:GridView>
                    </asp:Panel>
                </div>

                <div id="cutnew" runat="server">
                </div>

                <div class="PendingLeft2">
                    <div id="div_book" runat="server" class="SalesTitleB" style="border: 0px solid #f00;">Booking Details</div>

                    <div class="right_btn">
                        <asp:LinkButton ID="lnk_div_book" runat="server" OnClick="lnk_div_book_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                        </asp:LinkButton>

                        <div style="clear: both;"></div>
                    </div>
                    <div class="FormGroupContent4">
                    <asp:Panel ID="pnlGrdCuswise" runat="server" CssClass="gridpnl" Style="width: 100%;" Visible="false">
                        <asp:GridView ID="GrdCuswise" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black"
                            EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdCuswise_RowDataBound"
                            OnSelectedIndexChanged="GrdCuswise_SelectedIndexChanged" DataKeyNames="cusid">

                            <Columns>

                                <%--<asp:BoundField DataField="customername" HeaderText="Customer Name" />
                               <asp:BoundField DataField="Counts" HeaderText="Number" />
                                <asp:BoundField DataField="Slno" HeaderText="Sl #" />--%>
                                <%--<asp:TemplateField HeaderText="S #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>--%>
                                <asp:BoundField DataField="SI" HeaderText="S#" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                    <ControlStyle />
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <div class="wrap175">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <%--<HeaderStyle HorizontalAlign="Center" Wrap="false" Width="120px" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="false" Width="120px" />--%>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BKS" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 35px">
                                            <asp:Label ID="Counts" runat="server" Text='<%# Bind("Counts") %>' ToolTip='<%#Bind("Counts")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="35px" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="false" Width="35px" />
                                </asp:TemplateField>

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle Font-Italic="False" />
                        </asp:GridView>
                    </asp:Panel>
                        </div>
                </div>

                <%--  <div runat="server" id="div7" class="PendingRightnew">
                                    <div id="chartdivBook" style="width: 360px; height: 250px;">
                                    </div>
                                </div>--%>
                <div class="PieChart" id="PieChart1" runat="server">
                    <asp:Chart ID="piechartbook" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                        <%--<Legends>        
                                    <asp:Legend Alignment="Center" Docking="Left" IsTextAutoFit="true" Name="StateName" LegendStyle="Table"/>
                                    </Legends>--%>

                        <Series>
                            <asp:Series Name="Series1" Color="#ffcc00" ChartType="Pie" CustomProperties="PieLineColor=Black,PieLabelStyle=Outside">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" />
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>

                <div id="divBooknew" runat="server">
                    <div class="PendingLeft1">
                        <div class="SalesTitle">Booking</div>
                        <asp:Panel ID="pnlTran" runat="server" Visible="true" Style="height: 136px; overflow: auto; width: 180px;">
                            <asp:GridView ID="grdTranNew" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="grdTranNew_RowDataBound" OnSelectedIndexChanged="grdTranNew_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="trantype" HeaderText="Trantype">
                                        <ControlStyle />
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" Width="50" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Counts" HeaderText="Number" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ControlStyle />
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" Width="25" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>

                <%--  <asp:Label ID="lblAI" runat="server"></asp:Label>
                        <ajax:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
                            DropShadow="false" PopupControlID="pnlJobAE" PopupDragHandleControlID="GrdBooking" CancelControlID="imgfgok">
                        </ajax:ModalPopupExtender>--%>

                <div id="classDiv" runat="server" visible="true">
                    <div class="SalesTitleBooking1">
                        <asp:Label ID="cust_name" runat="server"></asp:Label>
                    </div>

                    <div class="right_btn" style="margin-top: -5px!important">
                        <asp:LinkButton ID="lbl_cust_name" runat="server" OnClick="lbl_cust_name_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                        </asp:LinkButton>

                        <div style="clear: both;"></div>
                    </div>
                    <div style="clear: both;"></div>
                    <div class="FormGroupContent4">
                    <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl" Visible="false" Style="height: 353px; overflow: auto">

                        <div class="">
                            <asp:GridView ID="GridView1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Records Found"
                                BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="S #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" Width="30px" />
                                        <HeaderStyle Wrap="false" Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Booking No" HeaderText="Booking #">
                                        <ControlStyle />
                                        <HeaderStyle Width="110px" />
                                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:BoundField>
                                    <%--  <asp:BoundField DataField="bookingdate" HeaderText="Date" />
                                        <asp:BoundField DataField="pod" HeaderText="POD" />
                                        <asp:BoundField DataField="pol" HeaderText="POL" />
                                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                                            <ControlStyle />
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Vessel" HeaderText="Vessel/Voyage">
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" />--%>
                                    <asp:BoundField DataField="product" HeaderText="Product" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                        </div>
                </div>

                <asp:Panel ID="pnlJobAE" runat="server" Visible="false">
                    <%--<div class="divRoated">--%>
                    <%--<div class="DivSecPanel">
                                <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>--%>

                    <div class="PortCountryC">

                        <div runat="server" id="div1" class="PendingLeft4">
                            <div class="SalesTitleBN1">
                                <asp:Label ID="lblBooking" runat="server"></asp:Label>
                            </div>

                            <asp:Panel ID="Panel4" runat="server" Visible="false" class="gridpnl">
                                <asp:GridView ID="GrdBooking" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White"
                                    ShowHeaderWhenEmpty="true">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                </asp:Panel>
               
                <div class="FormGroupContent4" style="margin-top:-40px!important;"" >
                    <div style="display: none;">
                        <div class="SalesTitle">
                            <asp:Label ID="lblQuery" runat="server" Text="Buy Rate Query"></asp:Label>
                        </div>
                        <div class="POLForm">
                            <asp:TextBox ID="txtPOL" runat="server" CssClass="form-control" placeholder="Port of Loading" ToolTip="PORT OF LOADING" TabIndex="1" AutoPostBack="true" OnTextChanged="txtPOL_TextChanged"></asp:TextBox>
                        </div>
                        <div class="PODForm">
                            <asp:TextBox ID="txtPOD" runat="server" CssClass="form-control" placeholder="Port of Discharge" ToolTip="PORT OF DISCHARGE" TabIndex="2" AutoPostBack="true" OnTextChanged="txtPOD_TextChanged"></asp:TextBox>
                        </div>
                        <div class="BaseDrop">
                            <asp:DropDownList ID="ddlBase" runat="server" CssClass="chzn-select" data-placeholder="Base/Unit" ToolTip="Base/Unit" TabIndex="3" Width="75%">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="Expireradio">
                            <asp:RadioButton ID="rdbExpired" runat="server" TabIndex="4" AutoPostBack="True" />
                        </div>
                        <div class="LabelExpire">
                            <asp:Label ID="Label13" runat="server" Text="Expired"></asp:Label>
                        </div>
                        <div class="Liverad">
                            <asp:RadioButton ID="rdbLive" runat="server" TabIndex="5" AutoPostBack="True" />
                        </div>
                        <div class="LiveLabel">
                            <asp:Label ID="Label3" runat="server" Text="Live"></asp:Label>
                        </div>
                        <div class="BothForm">
                            <asp:RadioButton ID="rdbBoth" runat="server" TabIndex="6" AutoPostBack="True" />
                        </div>
                        <div class="Bothlabel">
                            <asp:Label ID="Label4" runat="server" Text="Both"></asp:Label>
                        </div>
                        <div class="btn ico-get">
                            <asp:Button ID="btnBuyQuery" runat="server" ToolTip="Get" OnClick="btnBuyQuery_Click" />
                        </div>
                        <div class="btn ico-cancel">
                            <asp:Button ID="btnCancel" runat="server" ToolTip="Clear" OnClick="btnCancel_Click" />
                        </div>
                    </div>

                    <div class="Unclosed" id="exRate" runat="server" style="display: none;">
                        <div class="PendingTbl2">
                            <asp:Panel ID="Panelexrate" runat="server" CssClass="gridpnl" Visible="true">
                                <asp:GridView ID="Gridexrate" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true">
                                    <Columns>
                                        <asp:BoundField DataField="excurr" HeaderText="Curr">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="localexrate" HeaderText="Local">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="osexrate" HeaderText="OS">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="SalesTitleNewWip">
                        <asp:Label ID="WIP" runat="server" Text="Open Jobs"></asp:Label>
                    </div>
                    <div class="right_btn">
                        <asp:LinkButton ID="workingprogess" runat="server" OnClick="workingprogess_Click">
                                 <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                        </asp:LinkButton>
                    </div>
                    <div style="clear: both;"></div>
                    <asp:Panel ID="Panel9" runat="server" CssClass="gridpnl" Visible="true">

                        <asp:GridView ID="Grid_workprogress" CssClass="Grid FixedHeader " runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="Grid_workprogress_RowDataBound" OnPreRender="Grid_workprogress_PreRender">
                            <Columns>
                                <asp:BoundField DataField="SI" HeaderText="SI">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Booking#" HeaderText="Booking#">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Date" HeaderText="Date">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Customer" HeaderText="Customer">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Origin" HeaderText="Origin">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Destination" HeaderText="Destination">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Sell" HeaderText="Sell">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Buy" HeaderText="Buy">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AMOUNT" HeaderText="Revenue">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                </div>
                <%-- <div runat="server" id="div_pie" class="div_chat">
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

                            </div>--%>
            </div>

            <div style="position: absolute; /*top: 500px; */bottom: 60px; width: 100%; left: 0px; display: none">

                <asp:LinkButton ID="LnkTB" runat="server" OnClick="LnkTB_Click">
                    <div class="BlueOuterDivNew">
                        <div class="BlueTextNew">To Be Called</div>
                        <span id="SpanTB" runat="server" class="BlueRightSideDownNew"></span>
                    </div>
                </asp:LinkButton>

                <asp:LinkButton ID="LnkApp" runat="server" OnClick="LnkApp_Click">
                    <div class="LiteBlueOuterNew">
                        <div class="LiteBlueTextNew">Appointment</div>
                        <span id="SpanApp" runat="server" class="LtBlueRightSideDownNew"></span>
                    </div>
                </asp:LinkButton>

                <asp:LinkButton ID="LnkPR" runat="server" OnClick="LnkPR_Click">
                    <div class="GreenOuterDivNew">
                        <div class="GreenTextNew">
                            To Be Followed
                        </div>

                        <span id="SpanPR" runat="server" class="GreenRightSideDownNew"></span>
                    </div>
                </asp:LinkButton>

                <div class="Clear"></div>
            </div>
        </div>

    </div>
    <!--END TABS-->

    <asp:Label ID="lblIdNew1" runat="server"></asp:Label>
    <ajax:ModalPopupExtender ID="aePopUpshow" runat="server" PopupControlID="AePopUpNewDate" BehaviorID="programmaticModalPopupBehaviordf4"
        TargetControlID="lblIdNew1" CancelControlID="imgNewAl" DropShadow="false">
    </ajax:ModalPopupExtender>

    <asp:Panel ID="AePopUpNewDate" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <%--<asp:Image ID="imgNewAl" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />--%>
                <asp:Image ID="imgNewAl" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <iframe id="iframecost" runat="server" frameborder="0" src="" visible="true" class="frames" style="background-color: #FFFFFF"></iframe>

        </div>
    </asp:Panel>

    <%------------------------------------ModelPOpup----------------------------------------%>

    <div class="FormGroupContent">
        <asp:Button ID="btn_show" runat="server" Text="test" Style="display: none;" />
        <asp:Label ID="LblCncl" runat="server"></asp:Label>
        <ajaxtoolkit:ModalPopupExtender ID="popuprate" runat="server" TargetControlID="LblCncl" BehaviorID="frgtydfdfdf" PopupControlID="pnlcncl"
            CancelControlID="imgcls" DropShadow="false">
        </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel ID="pnlcncl" runat="server" CssClass="modalPopup" Style="display: none;">

            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                    <asp:GridView ID="Grd_Buying" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader"
                        EmptyDataText="No Records Found" OnRowDataBound="Grd_Buying_RowDataBound">
                        <Columns>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" Wrap="false" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>

                    <div class="div_break"></div>
                </asp:Panel>
                <div class="Break"></div>
            </div>
            <div class="Break"></div>
        </asp:Panel>

        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="hid_rateid" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="hid_cusid" runat="server" />
    </div>

    <div style="display: none;">
        <asp:Label ID="hidbooking" runat="server" />
        <asp:Label ID="hidhbl" runat="server" />
        <asp:Label ID="hidmbl" runat="server" />
        <asp:Label ID="hidunclosed" runat="server" />
        <asp:Label ID="hidapprovalproinvoice" runat="server" />
        <asp:Label ID="hidapprovalCNOp" runat="server" />
        <asp:Label ID="hidapprovalquo" runat="server" />
        <asp:Label ID="hidapprovalInvoices" runat="server" />
        <asp:Label ID="hidapprovalProCNOp" runat="server" />
        <asp:Label ID="hidapprovalProOSdn" runat="server" />
        <asp:Label ID="hidapprovalOSDebit" runat="server" />
        <asp:Label ID="hidapprovalOScrdit" runat="server" />
        <asp:Label ID="hidapprovalProOtherDN" runat="server" />
        <asp:Label ID="hidapprovalProOtherCN" runat="server" />
        <asp:Label ID="hidapprovalOSCredit" runat="server" />
        <asp:Label ID="hidapprovalOtherDebitNotes" runat="server" />
        <asp:Label ID="hidapprovalOtherCreditNotes" runat="server" />

        <asp:Label ID="hidfe" runat="server" />
        <asp:Label ID="hidfi" runat="server" />
        <asp:Label ID="hidae" runat="server" />
        <asp:Label ID="hidai" runat="server" />

        <asp:HiddenField ID="hdf_POL" runat="server" />
        <asp:HiddenField ID="hdf_POD" runat="server" />
        <asp:Label ID="Label5" runat="server" />
    </div>
        </div>
</asp:Content>
