<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CORHomeMIS.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.CORHomeMIS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />

    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>


    <link href="../Styles/CustomerRetention.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>

    <script src="http://www.google.com/jsapi" type="text/javascript"></script>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>


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
    <link rel="Stylesheet" href="../Styles/Jobdetail.css" />
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <link rel="Stylesheet" href="../Styles/Inbound.css" />
    <link rel="Stylesheet" href="../Styles/Shipmentdetails.css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>

    <link rel="Stylesheet" href="../Styles/Tradelane.css" />

    <link href="../Styles/statistics.css" rel="stylesheet" type="text/css" />
    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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

        .OutstandingBox h3 {
            font-weight: normal;
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 0px 10px;
            color: var(--grey);
            width: 350px;
            margin: 0px;
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

        .Mright5 {
            margin-right: 5px;
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


        .div_Gridjob {
           width: 34%;
    float: left;
    margin-left: 10px !important;
        }

        .div_grdmain {
            margin: 0px 0px 0px -8px;
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

        .PendingStatisticsNew1 {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
            height: 307px;
            overflow: auto;
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

        .div_grdviewExemption {
            width: 100%;
            height: 223px;
            overflow: auto;
            margin-bottom: 5px;
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




        .div_GridCus {
            width: 100%;
            margin-left: 0px;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 230px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow-y: auto;
            overflow-x: hidden;
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

        .div_gridCor {
            width: 24%;
            float: left;
            margin-top: 0%;
            margin-left: 0%;
            margin-right: 0.5%;
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
            background-color: transparent;
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
            width: 100.5%;
            height: 537px;
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





        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 28px;
            padding: 0px 2px 2px 5px;
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


        .widget.box .widget-content1 {
            padding: 0px 10px 0px 8px;
            position: relative;
            background-color: #fff;
            display: block;
            margin: 5px 0px 0px 0px;
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
            width: 69.9%;
            margin: -3px 0px 0px 10px;
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
            width: 291px;
            margin: 0px 0px 0px 0px;
            display: none;
        }


        .PendingRightnewLRightNew1 {
            float: right;
            width: 460px;
            margin: 33% 0px 0px 0px;
        }



        form#form1 {
    overflow-y: auto;
    margin-top:30px;
        height: 98vh !important;
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
            width: 99.7%;
            margin: 0px 0px 10px 0px;
            height: 240px;
            border: 1px solid #b1b1b1;
            overflow: auto;
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

        .InBoundReport {
            font-size: 11px;
        }

        .BoundMonth {
            font-size: 11px;
        }

        .BoundYear {
            font-size: 11px;
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
            width: 450px;
            margin: 33% 0px 0px 10px;
        }

        .PendingRightnew2 {
            float: left;
            width: 376px;
            margin: 0px 0px 0px 10px;
        }


        .PendingTbl3 {
            width: 1340px;
            float: left;
            margin: 7px 0px 0px 0px;
            height: 275px;
            max-height: 275px;
            overflow: auto;
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
            margin: 4px 0px -2px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }

        .PortCountryJobCus h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 4px 0px -2px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }


        .PortCountryJobBL h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 4px 0px -2px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }






        .PortCountryJobShip h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 4px 0px -2px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }


        .PortCountryJobCut h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 0px 0px -2px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }







        .PortCountryJobIn h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 0px 0px 10px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }







        .PortCountryJobRen h3 {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 0px 0px 5px 10px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }




        .AgentJobN1 h3 {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 0px 0px 5px 10px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }



        .Customs h3 {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 0px 0px 0px 0px;
            padding: 2px 5px 0 0;
            /*width: 700px;*/
        }









        .PendingRightnew3 {
            float: left;
            width: 218px;
            margin: 0px 0px 0px 10px;
        }

        .lbl_cutlnkAE {
            color: #16365c;
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

        .lbl_cutlnkTotRen {
            color: #7b8d8e;
        }


        .PendingRightnewComapp {
            float: left;
            width: 99.5%;
            margin: 0px 0px 0px 6px;
        }

        .PendingRightnewComappnew {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .ToLabel4 span {
            font-size: 11px;
            color: #ffffff;
        }


        .MISFrom span {
            color: #ffffff !important;
        }

        .MISTO span {
            color: #ffffff !important;
        }


        .GridMIS th {
            background-color: #003a65 !important;
            color: #ffffff !important;
        }



        .PendingStatisticsN1 {
            float: left;
            width: 99%;
            margin: 0px 0px 0px 10px;
        }


        .RententionLbl {
            color: #fff;
            font-size: 11px;
            margin: 0px 0px 0px 0px;
        }


        .GridScrollView {
            width: 100%;
            overflow: auto;
            height: 240px;
            margin: 5px 0px 0px 0px;
        }

        .Left_btn1 {
            float: left;
            margin: 10px 0px 0px 0px;
        }



        .VoyageInputN4New {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ForwardingDrop {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }


        div#UpdatePanel1 {
            height: 92vh;
            overflow-x: hidden;
            overflow-y: hidden;
            background: var(--white);
        }
        .homecontent {
    width: 86%;
    float: left;
}
        th {
            position: sticky;
            top: -1px;
            white-space: nowrap;
        }

        .MISFrom {
            width: 2%;
            margin: 4px 0.5% 0px 0px;
            float: left;
        }
        .ByDrop {
    width: 15%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .MISTO {
            width: 1%;
            margin: 4px 0.5% 0px 0px;
            float: left;
            display:none;
        }
        span.normalsize, span.emphasis {
    position: absolute !important;
    color: #06529c !important;
    /* color: red !important; */
    font-size: 14px !important;
    font-weight: 500 !important;
}
        .BandMiddle {
            width: 100%;
        }

        .OutstandingBox {
            position: relative;
            bottom: 52px;
        }

        .chzn-drop {
            height: 185px !important;
        }

        .widget.box .widget-content {
            top: 5px !important;
            padding-right: 0;
        }
        div#logix_CPH_signup {
    display: flex;
    justify-content: space-evenly;
    width: 9% !important;
}
        .MISBranch {
    width: 10%;
    margin: 0px 0.5% 0px 0px;
    float: left;
}
        div#chart div:nth-child(1) {
    position: relative !important;
    top: 15%;
}
        .position{
            position:relative;
            top:350px;
        }
        div#panelSerch {
    Height: 696px !important;
}
    </style>


    <style>
        .Gridcut {
            width: 100%;
            border: 0px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            /*overflow-x: hidden !important;
    overflow-y: auto !important;*/
        }

            .Gridcut th {
                background-color: #003a65 !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #ffffff !important;
            }

            .Gridcut td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

            .Gridcut tr:last-child {
                color: #ab1e1e !important;
            }

        .GridcutNew2 {
            width: 100%;
            border: 0px solid #b1b1b1;
            height: 272px;
            overflow: auto;
        }

        .GridcutNewMt2 {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 10px 0px;
            /*height: 230px;*/
            /*overflow: auto;*/
        }



        .GridcutNew2 th {
            background-color: #003a65 !important;
            border-right: 1px solid #51789d;
            font-family: tahoma;
            padding: 2px 5px 2px 5px;
            font-size: 11px;
            color: #ffffff !important;
        }

        .GridcutNew2 td {
            border-right: 1px solid #003a65;
            font-size: 11px;
            text-align: left;
            font-family: tahoma;
            padding: 2px 5px 2px 5px;
            margin: 0px;
            color: #4e4c4c;
            border-bottom: 1px solid #dddddd;
        }

        .GridcutNew2 tr:last-child {
            color: #ab1e1e !important;
        }
    </style>
    <link href="../Styles/Cutoffdetails.css" rel="stylesheet" />

    <link href="../Styles/Miscorporate.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="stylesheet" />
    <link href="../Styles/button1.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />



    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        /*.modalPopupss {
            background-color: #FFFFFF;
            border-width: 1px;
            border-style: solid;
            border-color: #CCCCCC;
            margin-left: -4%;
            padding: 1px;
            width: 850px;
            Height: 350px;
            display:none;
        }*/

        .divRoated {
            width: 100%;
            Height: 352px;
            /*width:100%; 
            Height:100%;*/
            margin-left: -0.5%;
            margin-top: -0.5%;
        }

        #logix_CPH_pnlcncl {
            left: -0.5px !important;
            top: 24px !important;
        }




        .divpop {
            width: 97%;
            Height: 352px;
            /*width:100%; 
            Height:100%;*/
            border: 3px solid black;
            margin-left: 0.5%;
            margin-top: 2%;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-left: 98%;
            margin-top: .5%;
            border-radius: 90px 90px 90px 90px;
        }

        /*.Gridpnl {
            width: 849px;
            Height: 344px;
            margin-left: 0.2%;
            margin-top:-0.5%;
        }*/

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #table-container {
            position: relative;
            width: 100%;
            height: 300px;
            overflow: auto;
            padding: 0 0.1% 0 0;
            margin-top: 0%;
            /*margin-bottom:1%;*/
            /*----------------*/
            font-family: sans-serif;
            /*margin-left:0.3%;*/
        }

        table.gvTheGrid td,
        table.gvTheGrid th {
            padding: 3px 7px;
        }

        .Hide {
            display: none;
        }

        .div_panel {
            width: 100%;
            /*margin-left: 1%;*/
            /*border:1px solid black;*/
            height: 390px;
            /*margin-top:1%;*/
        }

        .div_panel2 {
            overflow-x: auto !important;
            width: 1320px;
        }

        .crumbs1 {
            display: none;
        }
        /*.widget.box {
    border: 1px solid #D9D9D9;
    float: left;
    width: 100%;
    margin-left: 0px;
    height: 555px;
}*/


        .AgentGrid {
            width: 100%;
        }





        .row {
            height: 315px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 99.5%;
        }

        .div_panel2 {
            width: 99%;
            margin-left: 1%;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 223px;
            border: 1px solid #b1b1b1;
            float: left;
            overflow: auto;
        }

        .MISCustomer {
               width: 24%;
    margin: 0px 0% 0px 0px;
    float: left;
        }


        .MISOI span {
            color: #daeef3;
            display: block;
            margin: 16px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .Droptbl {
            float: left;
            width: 10%;
            margin: 0px 0.5% 0px 0px;
        }

        .RententionLblN1 {
                width: 14%;
    float: left;
    margin: 0px 0% 0px 0px;
        }

        .RententionLblnew {
            font-size: 11px;
            color: #ffffff;
        }

        .MISCal1 {
            width: 7%;
            margin: 0px 0.5% 0px 11.9%;
            float: left;
        }

        .MISCal2 {
            width: 7%;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }

        .col-md-12 {
            padding-left: 9px;
        }

        .CustomsBrokingN1 {
            width: 1345px;
            overflow: auto;
            margin: 7px 0px 0px 0px;
            float: left;
            height: 276px;
        }

        .MR20 {
            margin-right: 20px;
        }

        .btn-view1 input {
            color: #ffffff !important;
        }

        .TradeLane1 h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 4px 0px 10px -1px;
            padding: 2px 5px 0 0;
            /* width: 700px; */
        }

        .TradeComLbl {
            font-size: 12px;
        }

        .TradeSector {
            font-size: 12px;
        }



        .Grid {
            margin: 0px 0px 0px 0px;
        }
    </style>

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

        .PendingStatistics {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
            height: 325px;
            overflow: auto;
        }



        .PendingStatistics1 {
            float: left;
            width: 100%;
            margin: -313px 0px 0px 0px;
            height: 325px;
            overflow: auto;
        }



        #logix_CPH_pln_voucher {
            left: 3px !important;
            top: -7px !important;
        }

        .div_frame {
            width: 1360px !important;
        }



        .MISReport {
            width: 20%;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }

        .MISCustomer {
            width: 24%;
            margin: 0px 0% 0px 0px;
            float: left;
        }
    </style>


    <style>
        .widget.box {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
        }

        .widget1.box1 {
            /*border: 1px solid #D9D9D9;*/
            float: left;
            width: 100%;
            margin-left: 0px;
            height: 304px;
        }


        .widget2.box2 {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
            height: 363px;
            overflow: auto;
        }

        .widget3.box3 {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
            height: 363px;
            overflow: hidden;
        }

        .widget4.box4 {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
            height: 363px;
            /*overflow:auto;*/
        }

        .widget {
            margin-top: 0px;
            margin-bottom: 5px;
            padding: 0px;
        }

        .div_panel {
            width: 100%;
            height: 400px;
        }

        .div_Grid {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 250px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow-y: auto;
            overflow-x: hidden;
        }

        .div_GridTree {
            width: 64%;
            margin-left: 0.6%;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 265px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow-y: auto;
            overflow-x: hidden;
        }

        #logix_CPH_pln_popup {
            left: 7px !important;
            top: 44px !important;
            width: 1365px;
            height: 550px;
            background-color: #fff;
        }





        .div_GridRen {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 1%;
            margin-top: 0.1%;
            height: 266px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow-y: auto;
            overflow-x: hidden;
        }

        .btn-get1 input {
            color: #ffffff !important;
            margin-left: 5px;
        }

        .btn-cancel1 input {
            color: #ffffff !important;
            margin-left: 5px;
        }

        .MR10 {
            margin-right: 10px !important;
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


        .PageHeight {
            background-color: #f8f9fc !important;
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
            margin: 5px 8px 0px 12px;
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
            width: 90%;
            font-size: 20px;
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
            font-size: 20px;
            width: 90%;
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
            font-size: 20px;
            width: 90%;
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
            font-size: 20px;
            width: 90%;
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
            font-size: 20px;
            width: 90%;
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
            font-size: 20px;
            width: 90%;
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
            font-size: 20px;
            width: 90%;
            text-align: right;
        }

        .Divimg2 {
            width: 13%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
        /*.OutstandingBox {
    height: 113px;
}*/
        div#logix_CPH_btnview_id {
    margin-top: 12px;
}
        div#logix_CPH_Panel11 {
    width: 100%;
    float: left;
}
        .TitleLeft1 {
    float: left;
    margin: 0px 0px 0px 0px !important;
}
    </style>

    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
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
                    url: '../Home/CORHOMEMIS.aspx/GetChartPIE',
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
            draw(data, { height: "300", title: "Outstanding", colors: ['#4ebcd5', '#bce3c8', '#408fdc', '#5765b2'], });
        }
    </script>


    <%-- BL VoucherWise --%>

    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "../images/plus.gif";
            }

        }
        function divbranch(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "../images/plus.gif";
            }
        }
        function pageLoad(sender, args) {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });

        }

    </script>

    <%-- bl voucherwise end --%>

    <%--   MISCORPSTART--%>



    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {

                $("#<%=txt_agent.ClientID %>").autocomplete({

                    source: function (request, response) {

                        $("#<%=hf_agent1.ClientID %>").val(0);
                        $.ajax({
                            url: "../Home/CORHomeMIS.aspx/Getcus",
                            data: "{ 'prefix': '" + request.term + "','FType':'" + $("#<%=hf_agent1.ClientID %>").val() + "'}",
                            //data: "{ 'prefix': '" + request.term + "','strcustype':'P'}",
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
                        $("#<%=txt_agent.ClientID %>").val(i.item.label);
                        $("#<%=txt_agent.ClientID %>").change();
                        $("#<%=hf_agent1.ClientID %>").val(i.item.val);
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val(i.item.label);
                            $("#<%=hf_agent1.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_agent.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_agent.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });

            });
            //$(".date").datepicker({
            //    changeMonth: true,
            //    changeYear: true,
            //    dateFormat: 'dd/mm/yy'
            //});




            $(".dropdown img.flag").addClass("flag visibility");

            $(".dropdown dt a").click(function () {
                $(".dropdown dd ul").toggle();
            });

            $(".dropdown dd ul li a").click(function () {
                var text = $(this).html();
                $(".dropdown dt a span").html(text);
                $(".dropdown dd ul").hide();
                $("#result").html("Selected value is: " + getSelectedValue("sample"));
            });

            function getSelectedValue(id) {
                return $("#" + id).find("dt a span.value").html();
            }

            $(document).bind('click', function (e) {
                var $clicked = $(e.target);
                if (!$clicked.parents().hasClass("dropdown"))
                    $(".dropdown dd ul").hide();
            });


            $("#flagSwitcher").click(function () {
                $(".dropdown img.flag").toggleClass("flagvisibility");
            });






        }
    </script>

    <script type="text/javascript">
        $(function () {
            $(".Grd_shiperconsignee > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".Grd_shiperconsignee td").removeClass("highlite");
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
    </script>

    <script type="text/javascript">
        $(function () {
            $(".grd_operProfit > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".grd_operProfit td").removeClass("highlite");
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




    </script>

    <style type="text/css">
        @media only screen and (max-width: 1280px) {





            .PendingTbl3 {
                width: 100%;
                float: left;
                margin: 7px 0px 0px 0px;
                height: 285px;
                max-height: 285px;
                overflow: auto;
                border: 1px solid #b1b1b1;
            }
        }
        
.BandTop {
    background-color: #fff !important;
    border-bottom: 0px solid #e0e0e0;
    display: block !important;
}
.HomeMenuBox {
    width: 13.5% !important;
    float: left !important;
    /* margin: 0px 0px 0px 0px !important; */
    display: flex !important;
    flex-direction: column !important;
    justify-content: space-around !important;
    /* height: 89vh !important; */
    height: 100vh !important;
    padding-top: 103px;
    position: relative;
    top: -116px;
}
.homebox{
    width:100%;
    float:left;
    margin:0px 0px 0px 0px;
}
/*.gridpnl {
    height: calc(100vh - 202px);
}*/
table#logix_CPH_grdyearcor tr {
    font-size: 14px !important;
    font-weight: normal !important;
}
div#signup {
    display: flex;
}
a#bnt_details {
    margin-left: 15px;
}
div#PanelAI {
    position: relative;
    top: 360px;
}
div#PanelOE{
position: relative;
top: 360px;
}
div#PanelOI{
position: relative;
top: 360px;
}
div#penBlRelase{
position: relative;
top: 360px;
}
    </style>
    <%--   MISCORPEND--%>
<%--</asp:Content>--%> 
<%--<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server"> --%>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
            <div class="maindiv">
    <div class="Clear"></div>
    <div class="BandMiddle hide">

        <div class="BreadLabel" id="OptionDoc" runat="server">MIS and Analytics</div>
    </div>

    <div class="BandTop">
        <div class="FormGroupContent4">

            <div class="MISFrom">
                <asp:Label ID="lbl_from" Text="From" runat="server"></asp:Label>
            </div>
            <div class="MISCal1">
                <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" placeholder="From" TabIndex="4"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from"
                    Format="dd/MM/yyyy"></asp:CalendarExtender>
            </div>
            <div class="MISTO">
                <asp:Label ID="Label1" Text="To" runat="server"></asp:Label>
            </div>
            <div class="MISCal2">
                <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" placeholder="To" TabIndex="4"></asp:TextBox>
                <asp:CalendarExtender ID="dt_validity" runat="server" TargetControlID="txt_to"
                    Format="dd/MM/yyyy"></asp:CalendarExtender>
            </div>

            <%--   <div class="Droptbl">
                <asp:DropDownList ID="ddlfroms" runat="server" CssClass="chzn-select" AutoPostBack="true" data-placeholder="Menus" ToolTip="Menus" OnSelectedIndexChanged="ddlfroms_SelectedIndexChanged">
                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>--%>


            <div class="MISBranch" id="ddl_branch_id" runat="server" >
                <asp:DropDownList ID="ddl_branch" runat="server" ToolTip="Branch" TabIndex="1" data-placeholder="Branch" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged">
                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="MISReport" id="ddl_Report_id" runat="server" >
                <asp:DropDownList ID="ddl_Report" runat="server" ToolTip="Report" TabIndex="3" data-placeholder="Report" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddl_Report_SelectedIndexChanged">
                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="ForwardingDrop hide">
                <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <div class="hide">
                    <asp:Label ID="lbl_ret" runat="server" Text="Revenue >" Visible="false"></asp:Label>

                </div>
                <div class="RententionLblN1" id="RententionLb" runat="server">
                    <asp:TextBox ID="txt_retention" runat="server" Width="100%" placeholder="Revenue >" CssClass="form-control" Visible="false">1</asp:TextBox>
                </div>
                <div class="right_btn MT0 MB05 MR20">  
                    <div class="btn ico-view" id="btnview_id" runat="server" Visible="false" >
                        <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" Visible="false" OnClick="btnview_Click" />
                    </div>
                </div>
            </div>


            <div class="ByDrop" id="divby" runat="server">
                <asp:DropDownList ID="ddl_by" runat="server" AppendDataBoundItems="True" CssClass="chzn-select"
                    AutoPostBack="True" OnSelectedIndexChanged="ddl_by_SelectedIndexChanged" data-placeholder="By" ToolTip="By" Visible="false">
                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="right_btn custom-mt-3" id="divstatistics" runat="server">
                <div class="btn ico-get Mright5">
                    <asp:Button ID="btnget" runat="server"  Text="Get" ToolTip="Get" OnClick="btnget_Click" />
                </div>
                <div class="btn ico-cancel" id="btncancel1" runat="server">
                    <asp:Button ID="btncancel" runat="server"   Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
                </div>
            </div>


            <div class="MISCustomer" id="txt_agent_id" runat="server"  visible="false" >
                <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" placeholder="Customer" ToolTip="Customer" TabIndex="2" Visible="false"></asp:TextBox>
            </div>
            <asp:TextBox ID="txt_Filter" runat="server" CssClass="Hide"></asp:TextBox>



            <%-- <div class="FormGroupContent4">--%>

            <div class="MISData1" style="display: none;">
                <asp:DropDownList ID="ddl_graph1" runat="server" CssClass="chzn-select" ToolTip="Data Or Graph" AutoPostBack="True" data-placeholder="Data Or Graph" Width="100%" OnSelectedIndexChanged="ddl_graph1_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                    <asp:ListItem Value="1">Data</asp:ListItem>
                    <asp:ListItem Value="2">Graph</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="MISData1" style="display: none;">
                <asp:DropDownList ID="ddl_graph2" runat="server" CssClass="chzn-select" data-placeholder="Graph" ToolTip="Graph" AutoPostBack="True" Visible="false" Width="100%" OnSelectedIndexChanged="ddl_graph2_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                    <asp:ListItem Value="1">Line</asp:ListItem>
                    <asp:ListItem Value="2">Bar</asp:ListItem>
                    <asp:ListItem Value="3">Pie</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="btn ico-get custom-mt-2" id="btn_get_id" runat="server" >
                <asp:Button ID="btn_get" runat="server"  Text="Get" ToolTip="Get" OnClick="btn_get_Click" Visible="false" />

            </div>

            <%-- </div>--%>
        </div>
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

    <div class="homebox">
    <div class="HomeMenuBox custom-d-flex">
        

            <asp:LinkButton ID="lnkAE" runat="server" OnClick="lnkAE_Click">
                <div class="menubox">
                     <div class="menuboximage">
                   
                    <img src="../Theme/assets/img/dashboard/airexport.png" />
                </div>
                    <div class="menuboxcontent">
                 
                       <span class="title">Air Exports </span>

                     
                    <span id="SPANAE" runat="server" class=" Amount"></span>
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

                   

                    <span id="SPANAI" runat="server" class=" Amount"></span>
                         </div>
                </div>
            </asp:LinkButton>
      
       

            <asp:LinkButton ID="lnkBT" runat="server" OnClick="lnkBT_Click" CssClass="hide" >
                <div class="menubox">
                    <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/bondedtrucking.png" />
                </div>
                    <div class=" menuboxcontent">
                        <span class="title">Bonded Trucking </span>

                   
                    <span id="SPANBT" runat="server" class=" Amount"></span>
                         </div>
                </div>
            </asp:LinkButton>
     

            <asp:LinkButton ID="lnkCH" runat="server" CssClass="AppLink hide" OnClick="lnkCH_Click">
                <div class=" menubox">
                    <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/customsbroking.png" />
                </div>
                    <div class=" menuboxcontent">
                         <span class="title">Customs Broking</span>

                    
                    <%--  <label class="Approved">Approved</label>
                           
                        
                         <label class="Unapproved">UnApproved</label>--%>
                    <%--<asp:LinkButton ID="lnkUnapp" runat="server" OnClick="lnkUnapp_Click" CssClass="UnAppLink">
                             </asp:LinkButton>--%>
                    <span id="spanCH" runat="server" class=" Amount"></span>
                        </div>
                </div>
            </asp:LinkButton>
       
       

            <asp:LinkButton ID="lnkOE" runat="server" OnClick="lnkOE_Click">
                <div class=" menubox">
                    <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/exports.png" />
                </div>
                    <div class="menuboxcontent">
                         <span class="title">Ocean Exports  </span>

                   
                    <span id="SpanOE" runat="server" class=" Amount"></span>
                     </div>
                </div>
            </asp:LinkButton>
   
   

            <asp:LinkButton ID="lnkOI" runat="server" OnClick="lnkOI_Click">
                <div class=" menubox">
                       <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/imports.png" />
                </div>
                    <div class="menuboxcontent">
                        <span class="title">Ocean Imports  </span>

                   
                    <span id="SpanOI" runat="server" class=" Amount"></span>
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

                    
                    <span id="SpanTOTAL" runat="server" class=" Amount"></span>
            </div>
                </div>
            </asp:LinkButton>
        
    </div>



    <div class="homecontent">
        <div class="col-md-12  maindiv">
            <!-- Tabs-->
            <div class="widget box borderremove">

                <div class="widget-content">


                    <div class="FormGroupContent4" >
                    <div class="TitleLeft1">
                        
       <div runat="server" id="div5" class="PendingRightnewChart" >

                     <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        <div id="chart" runat="server" style="width: 2000px; height: 100px;">
                        </div>
                    </div>
    </div>
                        </div>



                    <div class="FormGroupContent4 hide">

                    <div class="PendingRightnew1" id="div_line" runat="server">
                        <asp:Literal ID="lt" runat="server"></asp:Literal>
                        <div id="Liner_chart_div"></div>

                    </div>


                    <div runat="server" id="div2_Bookchart" class="PendingRightnewLRightNew">
                        <div id="chartdiv1" style="width: 390px; margin-left: 20px;">
                        </div>
                    </div>

                    <div id="div_bar" runat="server" class="PendingRightnewLRightNew1">
                        <asp:Literal ID="lts" runat="server"></asp:Literal>
                        <div id="chart_divbar" style="margin: 0px 0px 0px 0px;"></div>

                    </div>
                        </div>




                

                    <div class="Customs">
                        <h3 id="headlbl1" runat="server">
                            <asp:Label ID="lbl_cut" runat="server"></asp:Label>
                        </h3>
                    </div>

                    <div class="Clear"></div>
                    <div id="penBlRelase" runat="server" visible="false">
                        <asp:Panel ID="Panel3" runat="server" Visible="true" CssClass="gridpnl" Width="100%" >

                            <asp:GridView ID="GridView1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView1_RowDataBound">
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
                        <asp:Panel ID="Panel2" runat="server" Visible="true" CssClass="gridpnl" width="100%" >

                            <asp:GridView ID="GrdAI" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrdAI_RowDataBound">
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
                        <asp:Panel ID="Panel4" runat="server" Visible="true" CssClass="gridpnl" Width="100%" >

                            <asp:GridView ID="GrdOE" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrdOE_RowDataBound">
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
                        <asp:Panel ID="Panel5" runat="server" Visible="true" CssClass="gridpnl" Width="100%">

                            <asp:GridView ID="GrdOI" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrdOI_RowDataBound">
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
                        <asp:Panel ID="Panel1" runat="server" Visible="true" CssClass="gridpnl" Width="100%" >

                            <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView2_RowDataBound" GridLines="None">
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
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                                <asp:Label ID="trantype" runat="server" Text='<%# Bind("trantype") %>' ToolTip='<%# Bind("trantype") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="130px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VouType">
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
                                <%-- <HeaderStyle CssClass="GridviewScrollHeader" /> 
    <RowStyle CssClass="GridviewScrollItem" /> 
    <PagerStyle CssClass="GridviewScrollPager" /> --%>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                       
                      

                    <div runat="server" id="div_mis" class="PendingRightnewComapp position" visible="false">


                        <div class="" runat="server">

                            <div class="widget-header" style="display: none;">
                                <h4><i class="icon-umbrella"></i>
                                    <asp:Label ID="lbl_Header" runat="server" Text=" MIS"></asp:Label></h4>
                            </div>
                            <div class="AgentJobN1">
                                <h3 id="h1" runat="server">
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                </h3>
                            </div>
                            <div class="Clear"></div>



                            <div class="FormGroupContent4">

                                <div runat="server" id="signup" style="width: 20%; float: left; margin-top: 10px" visible="false">

                                  

                                    <div class="">
                                        <asp:LinkButton ID="bnt" runat="server" OnClick="bnt_Click">
                                             <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Summary">

                                        </asp:LinkButton>
                                        <%-- <asp:Button ID="bnt" runat="server" Text="Export To Excel" OnClick="bnt_Click" />--%>
                                    </div>

                                    <div class="" id="bnt_detailsex2exce" runat="server">
                                        <asp:LinkButton ID="bnt_details" runat="server" OnClick="bnt_details_Click"> 
                                           <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Detailed">

                                        </asp:LinkButton>
                                        <%-- <asp:Button ID="bnt" runat="server" Text="Export To Excel" OnClick="bnt_Click" />--%>
                                    </div>
                                        
                                </div>

                                <div class="right_btn MT0 MB05">

                                    <div class="btn ico-print hide">
                                        <asp:Button ID="btn_print" runat="server" Text="Print" ToolTip="Print" OnClick="btn_print_Click" />
                                    </div>
                                    <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" Style="color: #4e4e4c!important;" />
                                    </div>


                                </div>

                            </div>
                            <div class="FormGroupContent4">
                                <div class="AgentGrid">
                                    <asp:Panel ID="panel_Agent" runat="server" CssClass="gridpnl" Width="100%" >



                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Agent" runat="server" Width="100%" ForeColor="Black"
                                            AutoGenerateColumns="False" Font-Bold="false"
                                            OnSelectedIndexChanged="grd_Agent_SelectedIndexChanged"
                                            OnRowDataBound="grd_Agent_RowDataBound">
                                            <Columns>
                                                <%--<asp:BoundField DataField="branch" HeaderText="Branch" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                                                <asp:BoundField DataField="agent" HeaderText="Agent">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Grwt" HeaderText="Gr.Wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="agentid" HeaderText="agentid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>

                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Agent" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
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
                                        <asp:GridView ID="Grd_Retention" runat="server" CssClass="Grid FixedHeader" Width="100%" Font-Bold="false"
                                            ForeColor="Black" AutoGenerateColumns="true"
                                            ShowHeader="False" OnRowDataBound="Grd_Retention_RowDataBound">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>


                                        <asp:GridView ID="grd_JobwiseCosting" runat="server" CssClass="Grid FixedHeader" Width="100%" ForeColor="Black" AutoGenerateColumns="False" Font-Bold="false"
                                            OnRowDataBound="grd_JobwiseCosting_RowDataBound" OnSelectedIndexChanged="grd_JobwiseCosting_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="rownumber" HeaderText="S#">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branch" HeaderText="Branch">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="trantype" HeaderText="trantype" >
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                    <ItemStyle HorizontalAlign="Right" />
                     <HeaderStyle CssClass="Hide" />
                    <ItemStyle CssClass="Hide" />
                </asp:BoundField>--%>
                                                <asp:BoundField DataField="TranTypeFull" HeaderText="Product">
                                                    <%--<HeaderStyle HorizontalAlign="Center"  Wrap="true" />
                    <ItemStyle HorizontalAlign="Right" />--%>
                    
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job#">
                                                    <%--<HeaderStyle HorizontalAlign="Center"  Wrap="true" />
                    <ItemStyle HorizontalAlign="Right" />--%>
                            
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobopenon" HeaderText="Job Open On">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobcloseddate" HeaderText="Job Closed On">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>

                                                <%-- <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>




                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Consignee" runat="server" AutoGenerateColumns="False" Font-Bold="false"
                                            Width="100%" ForeColor="Black"
                                            DataKeyNames="Consigneeid"
                                            OnSelectedIndexChanged="grd_Consignee_SelectedIndexChanged"
                                            OnRowDataBound="grd_Consignee_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Consignee" HeaderText="Consignee">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Grwt" HeaderText="Gr.Wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="consigneeid" HeaderText="Cid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%-- <asp:BoundField DataField="jobtype" HeaderText="jobtype" >
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle CssClass="Hide" />
                              <ItemStyle CssClass="Hide" />
                </asp:BoundField>--%>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_consignee" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_LogDetails" runat="server" Width="100%"
                                            ForeColor="Black" Font-Bold="false" AllowPaging="false" PageSize="17" OnPageIndexChanging="Grd_LogDetails_PageIndexChanging"
                                            AutoGenerateColumns="False"
                                            OnRowDataBound="Grd_LogDetails_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eventdate" HeaderText="Event Date">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Details" HeaderText="Event Details">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Menu" HeaderText="Menu">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Form" HeaderText="Form">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branch" HeaderText="Branch">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_nomination" runat="server" AutoGenerateColumns="False" Width="100%" Font-Bold="false"
                                            ForeColor="Black" CssClass="Grid FixedHeader"
                                            OnRowDataBound="Grd_nomination_RowDataBound"
                                            OnSelectedIndexChanged="Grd_nomination_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Branch" HeaderText="Branch"></asp:BoundField>
                                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nomination" HeaderText="Nomination" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Nomination" runat="server" CommandName="select" Font-Underline="false" 
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_jobloss" runat="server" AutoGenerateColumns="False" Font-Bold="false"
                                            Width="100%" ForeColor="Black"
                                            OnRowDataBound="grd_lossjob_RowDataBound"
                                            OnSelectedIndexChanged="grd_lossjob_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="branch" HeaderText="Branch" />
                                                <asp:BoundField DataField="TranTypeFull" HeaderText="Product" />
                                                <asp:BoundField DataField="jobno" HeaderText="Job#" />
                                                <asp:BoundField DataField="jobopenon" HeaderText="Job Open On">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobcloseddate" HeaderText="Job Closed On">
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
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Lossjob" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_freeVsnomi" runat="server" AutoGenerateColumns="False" Width="100%" Font-Bold="false"
                                            ForeColor="Black" CssClass="Grid FixedHeader" OnRowDataBound="Grd_freeVsnomi_RowDataBound" OnSelectedIndexChanged="Grd_freeVsnomi_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="product" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="unit" HeaderText="Unit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fvolume" HeaderText="A Volume" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fretn" HeaderText="A Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FRtnPUnit" HeaderText="A Per Unit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nvolume" HeaderText="O Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nretn" HeaderText="O Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NRtnPUnit" HeaderText="O Per Unit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_freeVSnomi" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                       
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_operProfit" runat="server" Width="100%" ForeColor="Black" DataKeyNames="branchid"
                                            Font-Bold="false" AutoGenerateColumns="false"
                                            OnRowDataBound="grd_operProfit_RowDataBound" OnRowCommand="grd_operProfit_RowCommand"
                                            OnSelectedIndexChanged="grd_operProfit_SelectedIndexChanged"
                                            OnRowCreated="grd_operProfit_RowCreated">
                                            <Columns>
                                                <asp:ButtonField CommandName="ColumnClickNew" Visible="false" />
                                                <asp:BoundField DataField="Branch" HeaderText="Branch"></asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <ItemStyle CssClass="Hide" />
                                                    <HeaderStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AE" HeaderText="AE" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                <asp:BoundField DataField="AI" HeaderText="AI" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                <%--  <asp:BoundField DataField="BT" HeaderText="BT" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>--%>
                                              <%--  <asp:BoundField DataField="CH" HeaderText="CH" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>--%>
                                                <%-- <asp:BoundField DataField="FC" HeaderText="FC" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>--%>
                                                <asp:BoundField DataField="OE" HeaderText="OE" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                <asp:BoundField DataField="OI" HeaderText="OI" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_profit" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                       
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                        <asp:GridView ID="grd_POD" runat="server" AutoGenerateColumns="False" Width="100%" Font-Bold="false"
                                            ForeColor="Black" DataKeyNames="podid"
                                            CssClass="Grid FixedHeader" OnRowDataBound="grd_POD_RowDataBound"
                                            OnSelectedIndexChanged="grd_POD_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Branch" HeaderText="Branch"></asp:BoundField>
                                                <asp:BoundField DataField="pod" HeaderText="PoD">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="podid" HeaderText="podid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>

                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_PoD" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_POL" runat="server" AutoGenerateColumns="False" Font-Bold="false"
                                            Width="100%" ForeColor="Black" DataKeyNames="polid"
                                            OnRowDataBound="grd_POL_RowDataBound"
                                            OnSelectedIndexChanged="grd_POL_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Branch" HeaderText="Branch"></asp:BoundField>
                                                <asp:BoundField DataField="pol" HeaderText="PoL">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="polid" HeaderText="polid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Pol" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_quotation" runat="server" AutoGenerateColumns="False" Font-Bold="false"
                                            Width="100%" ForeColor="Black"
                                            OnRowDataBound="Grd_quotation_RowDataBound"
                                            OnSelectedIndexChanged="Grd_quotation_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Branch" HeaderText="Branch"></asp:BoundField>
                                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="jobno" HeaderText="Job#" />
                                                <asp:BoundField DataField="nomination" HeaderText="Nomination"></asp:BoundField>
                                                <asp:BoundField DataField="quotcustomer" HeaderText="Quotation Customer">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Quo" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="grd_salesperson" runat="server" AutoGenerateColumns="False" Width="100%" Font-Bold="false"
                                            ForeColor="Black" DataKeyNames="salesid"
                                            CssClass="Grid FixedHeader" OnRowDataBound="grd_salesperson_RowDataBound" OnSelectedIndexChanged="grd_salesperson_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="branch" HeaderText="Branch"></asp:BoundField>
                                                <asp:BoundField DataField="person" HeaderText="Sales Person">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="salesid" HeaderText="salesid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_sales" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grd_sectorwise" runat="server" AutoGenerateColumns="False" Width="100%" Font-Bold="false"
                                            ForeColor="Black" CssClass="Grid FixedHeader" OnRowDataBound="Grd_sectorwise_RowDataBound" OnSelectedIndexChanged="Grd_sectorwise_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="sectorname" HeaderText="Sector">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PoL" HeaderText="Port">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Shipment" runat="server" AutoGenerateColumns="False" Font-Bold="false"
                                            Width="100%" ForeColor="Black" OnRowDataBound="grd_Shipment_RowDataBound"
                                            OnSelectedIndexChanged="grd_Shipment_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="RowNumber" HeaderText="S#">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                <asp:BoundField DataField="TrantypeFull" HeaderText="Product">
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
                                                <asp:BoundField DataField="TypeJob" HeaderText="JobType">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_shipment" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_shiperconsignee" runat="server" Width="100%" Font-Bold="false"
                                            ForeColor="Black" DataKeyNames="" autopostback="true" OnRowCommand="Grd_shiperconsignee_RowCommand"
                                            AutoGenerateColumns="False" OnRowDataBound="Grd_shiperconsignee_RowDataBound"
                                            OnSelectedIndexChanged="Grd_shiperconsignee_SelectedIndexChanged">
                                            <Columns>
                                                <asp:ButtonField CommandName="ColumnClick" Visible="false" />

                                                <asp:BoundField DataField="Shipper" HeaderText="Shipper" />
                                                <asp:BoundField DataField="Retention4Shipper" HeaderText="Revenue4Shipper" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                                <asp:BoundField DataField="Consignee" HeaderText="Consignee" />
                                                <asp:BoundField DataField="Retention4Consignee" HeaderText="Revenue4Consignee" />
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_Shipper" runat="server" Width="100%" ForeColor="Black" Font-Bold="false"
                                            AutoGenerateColumns="False"
                                            OnSelectedIndexChanged="grd_Shipper_SelectedIndexChanged" OnRowDataBound="grd_Shipper_RowDataBound">
                                            <Columns>

                                                <asp:BoundField DataField="branch" HeaderText="Branch">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="shipper" HeaderText="Shipper">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Grwt" HeaderText="Gr.Wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branchid" HeaderText="branchid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="shipperid" HeaderText="shipperid">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_shipper" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                                <asp:ButtonField CommandName="ColumnClick" Visible="false" />
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                        <asp:ModalPopupExtender ID="popup1" runat="server" PopupControlID="panelSerch"
                                            TargetControlID="Label2" DropShadow="false" CancelControlID="close" BehaviorID="Test">
                                        </asp:ModalPopupExtender>

                                        <asp:Panel ID="panelSerch" runat="server" CssClass="modalPopup" BorderStyle="Solid"
                                            BorderWidth="1px" Style="display: none;" ScrollBars="Both">
                                            <div class=" divRoated">
                                                <div class="DivSecPanel">
                                                    <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                                </div>


                                                <div style="float: left; width: 99%; margin: 10px 5px 10px 5px; padding: 0px;">

                                                    <div style="float: left; width: 40%; margin: 0px 12px 0px 0px;">

                                                        <asp:Panel ID="Panel6" runat="server" CssClass=" Gridpnl">
                                                            <asp:GridView CssClass="Grid FixedHeader" ID="grdshipteusdtlscor" runat="server" Width="100%"
                                                                AutoGenerateColumns="False" Visible="true">
                                                                <Columns>
                                                                    <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Height="20px" />
                                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="trantype" HeaderText="Product">
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
                                                                <HeaderStyle CssClass="GridHeader" />
                                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                            </asp:GridView>
                                                        </asp:Panel>

                                                        <div class="Break"></div>


                                                        <%-- <div class="chart">
            <ul class="bar-chart" data-bars="[4,2],[4,5],[8,3],[4,2],[4,2]" data-max="10" data-unit="k" data-width="24"></ul>
        </div>--%>
                                                    </div>
                                                    <div style="width: 59%; float: left;">

                                                        <asp:Panel ID="Panel7" runat="server" Width="100%" CssClass="Gridpnl" ScrollBars="Both">
                                                            <asp:GridView CssClass="Grid FixedHeader" ID="grdyearcor" runat="server" Width="99%"
                                                                AutoGenerateColumns="False" ShowHeader="false" OnRowCreated="grdyear_RowCreated" Visible="true">
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="Month">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdmonth" runat="SERVER" Text='<%# Eval("month")  %>'>
                                                                          
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="branch" ControlStyle-Width="70">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdbranch" runat="SERVER" Text='<%# Eval("branch")  %>'>
                                                                           
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="trantype" ControlStyle-Width="70">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdtran" runat="SERVER" Text='<%# Eval("trantype")  %>'>
                                                                           
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="vol1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdvol1" runat="SERVER" Text='<%# Eval("vol1")  %>'>
                                                                           
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="teus1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdteus1" runat="SERVER" Text='<%# Eval("teus1")  %>'>
                                                                            
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="chwt1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdchwt1" runat="SERVER" Text='<%# Eval("weight1")  %>'>
                                                                        
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Revenue1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdretention1" runat="SERVER" Text='<%# Eval("retention1")  %>'>
                                                                           
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="vol2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdvol2" runat="SERVER" Text='<%# Eval("vol2")  %>'>
                                                                          
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="teus2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdteus2" runat="SERVER" Text='<%# Eval("teus2")  %>'>
                                                                           
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="chwt2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdchwt2" runat="SERVER" Text='<%# Eval("weight2")  %>'>
                                                                            
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Revenue2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblgrdretention2" runat="SERVER" Text='<%# Eval("retention2")  %>'>
                                                                          
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                                <HeaderStyle CssClass="GridHeader" />
                                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </div>

                                                </div>


                                                <div class="Break"></div>
                                            </div>
                                        </asp:Panel>

                                        <asp:GridView ID="grd_trendanalysis" runat="server" Width="100%" ForeColor="Black" Font-Bold="false"
                                            AutoGenerateColumns="true" CssClass="Grid FixedHeader"
                                            OnSelectedIndexChanged="grd_trendanalysis_SelectedIndexChanged" OnRowDataBound="grd_trendanalysis_RowDataBound">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <asp:GridView CssClass="Grid FixedHeader" ID="grd_YearMIS" runat="server" Width="100%" Font-Bold="false"
                                            ForeColor="Black"
                                            AutoGenerateColumns="true" OnRowDataBound="grd_YearMIS_RowDataBound">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                        <asp:GridView ID="GRD_Common" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                            Width="100%" ForeColor="Black" AllowPaging="False" OnRowDataBound="GRD_Common_RowDataBound" OnRowCreated="GRD_Common_RowCreated"
                                            OnSelectedIndexChanged="GRD_Common_SelectedIndexChanged">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:GridView>

                                        <div class="div_Break"></div>

                                        <asp:GridView ID="Gridtemp" runat="server" CssClass="Grid FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="true">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridviewScrollHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <div runat="server" id="div_op_char" class="div_chat hide">
                                            <asp:Chart ID="chartoperProfit" runat="server" Width="800px" EnableViewState="True"  BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
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

                                        <div runat="server" id="div3" class="div_chat hide">
                                            <asp:Chart ID="chartoperProfit1" runat="server" Width="800px" EnableViewState="false"  BorderlineWidth="0" IsMapAreaAttributesEncoded="false" Palette="Bright" ViewStateMode="Disabled">
                                                <Series>
                                                    <asp:Series Name="Series1">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                        </div>


                                        <div runat="server" id="div2" class="div_chat hide">
                                            <asp:Chart ID="piechart" runat="server" Width="800px" EnableViewState="True"  BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
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

                                        <div runat="server" id="div1" class="div_chat hide">
                                            <asp:Chart ID="PODCHARTVIEW" runat="server" Width="800px" EnableViewState="True"  BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
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


                                            <div class="DivAllChart2 hide">
                                                <asp:Chart ID="Chart1" runat="server" EnableViewState="True" Height="150px" Width="200px"   BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>
                                             
                                            <div class="DivAllChart3 hide">
                                                <asp:Chart ID="Chart2" runat="server" EnableViewState="True" Height="150px" Width="200px"   BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart4 hide">
                                                <asp:Chart ID="Chart3" runat="server" EnableViewState="True" Height="150px" Width="200px"   BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChartFriest hide">
                                                <asp:Chart ID="Chart4" runat="server" EnableViewState="True" Height="150px" Width="200px"  BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="Break"></div>
                                            <div class="DivAllChart5 hide">
                                                <asp:Chart ID="Chart5" runat="server" Height="150px" Width="200px" EnableViewState="True"   BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart6 hide">
                                                <asp:Chart ID="Chart6" runat="server" EnableViewState="True" Height="150px" Width="200px"   BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart7 hide">
                                                <asp:Chart ID="Chart7" runat="server" EnableViewState="True" Height="150px" Width="200px"  BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                                    <Series>
                                                        <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </div>

                                            <div class="DivAllChart8 hide">
                                                <asp:Chart ID="Chart8" runat="server" EnableViewState="True"   Height="150px" Width="200px" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
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
                            </div>



                        </div>


                    </div>

                    <div runat="server" id="div_retention" class="PendingRightnewComappnew position" visible="false">
                        <%-- <div >
                            <div class="col-md-12  maindiv">--%>

                        <div class="" runat="server">
                            <%-- <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="Label4" runat="server" Text="Customer Retention"></asp:Label></h4>
                </div>--%>
                            <div class="widget-content">
                                <div class="PortCountryJobRen">
                                    <h3 id="h2" runat="server">
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                    </h3>
                                </div>
                                <div class="bordertopNew"></div>
                                <div class="FormGroupContent4">
                                    <div class="gridpnl">
                                        <asp:GridView CssClass="Grid FixedHeader" ID="grdcustomer" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" PageSize="15">
                                            <Columns>
                                                <asp:BoundField DataField="divsname" HeaderText="Division">
                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                    <ItemStyle Wrap="true" HorizontalAlign="left" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="portname" HeaderText="Branch">
                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="customername" HeaderText="Customer">
                                                    <HeaderStyle HorizontalAlign="Center" Width="437px" />
                                                    <ItemStyle Wrap="true" HorizontalAlign="left" Width="60%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="retention" HeaderText="Revenue" HtmlEncode="false" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle Wrap="true" HorizontalAlign="Center" Width="160px" />
                                                    <ItemStyle Wrap="true" HorizontalAlign="Right" Width="20%" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="FormGroupContent4 MB05">

                                    <asp:Label ID="lblMsg" runat="server" Width="200px"></asp:Label>
                                    <asp:Label ID="lblMsg1" runat="server" Width="200px"></asp:Label>
                                    <asp:Label ID="lblMsg2" runat="server" Width="200px"></asp:Label>
                                    <div class="right_btn MT0 MB05">
                                        <%-- <div class="btn btn-export"><asp:Button ID="btnExport" runat="server" Text="Export To Excel" onclick="btnExport_Click" Enabled="false" /></div>--%>
                                        <asp:LinkButton ID="btnExport" runat="server" OnClick="btnExport_Click" Enabled="false"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <%--   </div>
                        </div>--%>
                    </div>

                    <div runat="server" id="div_Statistics" class="PendingStatisticsNew1 position" visible="false">



                        <div class="" runat="server">

                            <%-- <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="Label5" runat="server" Text="Shipment Details"></asp:Label></h4>
                </div>--%>
                            <div class="widget-content">
                                <div class="PortCountryJobShip">
                                    <h3 id="h3" runat="server">
                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                    </h3>
                                </div>
                                <div class="FormGroupContent4">
                                </div>
                                <div class="FormGroupContent4">
                                </div>
                                <div class="bordertopNew2"></div>
                                <div class="FormGroupContent">
                                    <div class="JobLeft">
                                        <div class="FormGroupContent">
                                            <div class="Joblink">
                                                <label>
                                                    <asp:LinkButton ID="link_job" runat="server" ForeColor="Red" OnClick="link_job_Click">No.of Jobs</asp:LinkButton></label>
                                                <span>
                                                    <asp:TextBox ID="txt_linkjob" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink">
                                                <label>
                                                    <asp:LinkButton ID="link_hbl" runat="server" ForeColor="Red" OnClick="link_hbl_Click">No.of HBL</asp:LinkButton></label>
                                                <span>
                                                    <asp:TextBox ID="txt_linkhbl" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink1">
                                                <asp:Label ID="lbl_spiltbl" runat="server" Text="Spilt BL"></asp:Label>
                                                <span>
                                                    <asp:TextBox ID="txt_splitbl" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent">
                                            <div class="Joblink">
                                                <label>
                                                    <asp:Label ID="lbl_fcl" runat="server" Text="FCL" ForeColor="Red"></asp:Label></label>
                                                <label>
                                                    <asp:Label ID="lbl_fcl20" runat="server" Text="No. of 20'"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_fcl20" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink MTopC">
                                                <label>
                                                    <asp:Label ID="lbl_fcl40" runat="server" Text="No. of 40'"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_fcl40" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink1 MTopC">
                                                <label>
                                                    <asp:Label ID="lbl_fcltues" runat="server" Text="No. of Teus"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_fcltues" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent">
                                            <div class="Joblink">
                                                <label>
                                                    <asp:Label ID="lbl_console" runat="server" Text="Consol" ForeColor="Red"></asp:Label></label>
                                                <label>
                                                    <asp:Label ID="lbl_concol20" runat="server" Text="No. of 20'"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_consol20" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink MTopC">
                                                <label>
                                                    <asp:Label ID="lbl_concol40" runat="server" Text="No. of 40'"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_consol40" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink1 MTopC">
                                                <label>
                                                    <asp:Label ID="lbl_consolcbm" runat="server" Text="No. of CBM"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_consolcbm" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent">
                                            <div class="Joblink">
                                                <label>
                                                    <asp:Label ID="lbl_lcl" runat="server" Text="LCL" ForeColor="Red"></asp:Label></label>
                                                <label>
                                                    <asp:Label ID="lbl_cmb" runat="server" Text="CBM"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_cbm" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink">
                                                <label>
                                                    <asp:Label ID="lbl_AE" runat="server" Text="Air Exports" ForeColor="Red"></asp:Label></label>
                                                <label>
                                                    <asp:Label ID="lbl_GW" runat="server" Text="Gross Wt."></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_GW" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                            <div class="Joblink1">
                                                <label>
                                                    <asp:Label ID="lbl_CHA" runat="server" Text="CHA" ForeColor="Red"></asp:Label></label>
                                                <label>
                                                    <asp:Label ID="lbl_Shpts" runat="server" Text="Shpts"></asp:Label></label>
                                                <span>
                                                    <asp:TextBox ID="txt_Shpts" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></span>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent">
                                            <asp:Panel ID="Panel9" runat="server" CssClass="gridpnl">
                                                <asp:GridView CssClass="Grid FixedHeader" ID="grdbudget" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdbudget_RowDataBound"
                                                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true">
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
                                    <div class="JobRight">
                                        <div class="FormGroupContent">
                                            <asp:Panel ID="Panel10" runat="server" CssClass=" gridpnl">
                                                <%--<div class="div_Grid">--%>
                                                <asp:GridView CssClass="Grid FixedHeader" ID="GrdJob" runat="server" AutoGenerateColumns="False" PageSize="15" AllowPaging="false"
                                                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdJob_RowDataBound" OnPageIndexChanging="GrdJob_PageIndexChanging"
                                                    DataKeyNames="bid,cid" OnSelectedIndexChanged="GrdJob_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.L #">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Wrap="false" Width="1%" HorizontalAlign="Center" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="10%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" Wrap="false" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="7%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="7%" Wrap="false" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="jobdate" HeaderText="OpenedOn">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="9%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="9%" Wrap="false" />
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="vslvoy" HeaderText="VslVoy">
                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundField>--%>
                                                        <asp:TemplateField HeaderText="VslVoy">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                                    <asp:Label ID="lbl_vessel" runat="server" Text='<%# Eval("vslvoy")%>' ToolTip='<%# Eval("vslvoy")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle Wrap="true" Width="1%" HorizontalAlign="Center" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="eta" HeaderText="ETA/ETD">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="9%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="9%" Wrap="false" />
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="agent" HeaderText="Agent">
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>--%>
                                                        <asp:TemplateField HeaderText="Agent">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                                    <asp:Label ID="lbl_Agent" runat="server" Text=' <%# Eval("agent")%>' ToolTip=' <%# Eval("agent")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle Wrap="true" Width="1%" HorizontalAlign="Center" />
                                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="preparedby" HeaderText="OpenedBy">
                                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="false" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="bid" HeaderText="bid" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="cid" HeaderText="cid" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <%--<asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_consignee" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">&#8667;</asp:LinkButton>
                            <br />
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
                                                        Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" PageSize="15" AllowPaging="false" OnPageIndexChanging="GrdBL_PageIndexChanging"
                                                        OnSelectedIndexChanged="GrdBL_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.L #">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                            </asp:BoundField>
                                                            <%-- <asp:BoundField DataField="blno" HeaderText="BL#">
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="2%" Wrap="false" />
                    </asp:BoundField>--%>
                                                            <asp:TemplateField HeaderText="BL#">
                                                                <ItemTemplate>
                                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                                        <asp:Label ID="blno" runat="server" Text='<%# Bind("blno") %>'></asp:Label>
                                                                    </div>

                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
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
                                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                                        <asp:Label ID="shipper" runat="server" Text='<%# Bind("shipper") %>'></asp:Label>
                                                                    </div>

                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PoL">
                                                                <ItemTemplate>
                                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 30px">
                                                                        <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                                    </div>

                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
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
                                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 30px">
                                                                        <asp:Label ID="fd" runat="server" Text='<%# Bind("fd") %>'></asp:Label>

                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
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
                                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                                        <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>

                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <%--   <asp:BoundField DataField="preparedby" HeaderText="Preparedby">
                        <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="true" />
                        <ItemStyle HorizontalAlign="Left" Width="1%" Wrap="false" />
                    </asp:BoundField>--%>

                                                            <asp:TemplateField HeaderText="Preparedby">
                                                                <ItemTemplate>
                                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                                        <asp:Label ID="preparedby" runat="server" Text='<%# Bind("preparedby") %>'></asp:Label>

                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
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
                            </div>
                        </div>


                    </div>

                    <div runat="server" id="div_inbound" class="PendingStatisticsN1 position" visible="false">

                        <div class="widget1 box1">
                            <div class="widget-content1">
                                <div class="FormGroupContent4" runat="server">

                                    <div class="PortCountryJobIn">
                                        <h3 id="h4" runat="server">
                                            <asp:Label ID="Label6" runat="server" Text="Inbound MIS Details"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="Clear"></div>


                                    <div class="FormGroupContent4">
                                        <div class="InBoundReport">
                                            <asp:Label ID="lbl_frm" runat="server" Text="Report Name"></asp:Label>
                                        </div>
                                        <div class="InboundBranch">
                                            <asp:DropDownList ID="ddl_reportname" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Report Name">
                                                <asp:ListItem Value="0">Branch wise Revenue</asp:ListItem>
                                                <asp:ListItem Value="1">Branch wise Volume</asp:ListItem>
                                                <asp:ListItem Value="2">Revenue - Product wise</asp:ListItem>
                                                <asp:ListItem Value="3">Revenue - Branch wise</asp:ListItem>
                                                <asp:ListItem Value="4">Volume - Product wise</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="BoundDrop">
                                            <asp:Label ID="lblmonth" runat="server" Text="Month"></asp:Label>
                                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="BoundYrDrop">
                                            <asp:Label ID="lblyear" runat="server" Text="Year"></asp:Label>
                                            <asp:DropDownList ID="ddlyear" runat="server" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="BoundDrop">
                                            <asp:Label ID="lbltomonth" runat="server" Text="Month"></asp:Label>
                                            <asp:DropDownList ID="ddltomonth" runat="server" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="BoundDrop">
                                            <asp:Label ID="lbltoyear" runat="server" Text="Year"></asp:Label>
                                            <asp:DropDownList ID="ddltoyear" runat="server" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="right_btn custom-mt-3">

                                            <div class="btn ico-excel">
                                                <asp:Button ID="btn_exportinb" Text="Export" runat="server"  ToolTip="Export" OnClick="btn_exportinb_Click" />
                                            </div>
                                            <div class="btn ico-cancel">
                                                <asp:Button ID="btn_cancelinb" Text="Cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancelinb_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div runat="server" id="div_BLVoucherwise" class="PendingStatisticsN1 position" visible="false">
                        <div class="PortCountryJobBL">
                            <h3 id="h5" runat="server">
                                <asp:Label ID="Label8" runat="server" Text="BL / Voucher-wise"></asp:Label>
                            </h3>
                        </div>
                        <div class="Clear"></div>
                        <div class="FormGroupContent4">
                            <div class="div_grdmain">
                                <asp:Panel ID="Panel11" runat="server"   >
                                    <div class="gridpnl"  style="width: 100%;float: left;"  >
                                        <asp:GridView ID="grdvoucher" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"
                                            ForeColor="Black" PageSize="15" DataKeyNames="divisionid"
                                            OnRowDataBound="grdvoucher_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <a href="JavaScript:divexpandcollapse('div<%# Eval("divisionid") %>');">
                                                            <img id="imgdiv<%# Eval("divisionid") %>" width="9px" border="0" src="../images/plus.gif" />
                                                        </a>
                                                    </ItemTemplate>
                                                    <%--<ItemStyle Width="20px"></ItemStyle>--%>
                                                    <ItemStyle Width="20px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="divisionname" HeaderText="Division">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="profit" HeaderText="Profit" ItemStyle-CssClass="Grd_RightTemplate"
                                                    HeaderStyle-CssClass="Grd_RightTemplate">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderStyle-CssClass="Grd_LeftTemplate" ItemStyle-CssClass="Grd_LeftTemplate">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td colspan="100%">
                                                                <div id="div<%# Eval("divisionid") %>" style="display: none; position: relative; left: 25px; overflow: auto">
                                                                    <asp:GridView ID="gvChildGrid" runat="server" Width="90%" AutoGenerateColumns="False"
                                                                        ShowHeader="false" DataKeyNames="branchid" OnRowDataBound="gvChildGrid_RowDataBound"
                                                                        BorderStyle="None">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="20px">
                                                                                <ItemTemplate>
                                                                                    <a href="JavaScript:divbranch('divbranch<%# Eval("branchid") %>');">
                                                                                        <img id="imgdivbranch<%# Eval("branchid") %>" width="9px" border="0" src="../images/plus.gif" />
                                                                                    </a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="branchname" HeaderText="branchname">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="profit" HeaderText="profit" ItemStyle-CssClass="Grd_RightTemplate"
                                                                                HeaderStyle-CssClass="Grd_RightTemplate">
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderStyle-CssClass="Grd_LeftTemplate" ItemStyle-CssClass="Grd_LeftTemplate">
                                                                                <ItemTemplate>
                                                                                    <tr>
                                                                                        <td colspan="100%">
                                                                                            <div id="divbranch<%# Eval("branchid") %>" style="display: none; position: relative; left: 35px; overflow: auto;">
                                                                                                <asp:GridView ID="Grdbranch" runat="server" AutoGenerateColumns="false" Width="80%"
                                                                                                    DataKeyNames="branchid,trant,division" ShowHeader="false" OnSelectedIndexChanged="Grdbranch_SelectedIndexChanged">
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="trantype" HeaderText="trantype">
                                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:BoundField DataField="profit" HeaderText="profit">
                                                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                                                                                                                    CssClass="Arrow">⇛</asp:LinkButton>
                                                                                                                <br />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="Grd_LeftTemplate"></HeaderStyle>
                                                    <ItemStyle Wrap="True" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>
                                    <div class="div_Gridjob gridpnl">
                                        <asp:GridView ID="Grdjob_BL" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"
                                            ForeColor="Black" PageSize="15" Visible="true"
                                            OnRowCommand="Grdjob_BL_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                                <asp:BoundField DataField="profit" HeaderText="Profit">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="link_btn" runat="server" CommandName="BL" CommandArgument='<%# Eval("jobno") %>'>BL Details</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="link_voucher" runat="server" CommandName="Select" CommandArgument='<%# Eval("jobno") %>'>Voucher Details</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>


                    <div runat="server" id="div_JobDetails" class="PendingStatisticsN1" visible="false">
                        <div class="PortCountryJobCus">
                            <h3 id="h6" runat="server">
                                <asp:Label ID="Label9" runat="server" Text="Job Details"></asp:Label>
                            </h3>
                        </div>
                        <div class="Clear"></div>

                        <div class="FormGroupContent4">
                            <div class="gridpnl" style="width:100%" >
                                <asp:Panel ID="Panel12" runat="server" ScrollBars="Vertical" CssClass="Grid FixedHeader">
                                    <asp:GridView CssClass="Grid FixedHeader" ID="Grdjobdetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                        ForeColor="Black" ShowHeaderWhenEmpty="true">
                                        <Columns>

                                            <asp:BoundField DataField="title" HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FE" HeaderText="OCEAN EXPORTS"
                                                HtmlEncode="false" DataFormatString="{0:#,##0}">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FI" HeaderText="OCEAN IMPORTS"
                                                HtmlEncode="false" DataFormatString="{0:#,##0}">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AE" HeaderText="AIR EXPORTS" HtmlEncode="false" DataFormatString="{0:#,##0}">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="13%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AI" HeaderText="AIR IMPORTS" HtmlEncode="false" DataFormatString="{0:#,##0}">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="13%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="total" HeaderText="Total" HtmlEncode="false" DataFormatString="{0:#,##0}">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                            </asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                        </div>
                        <div class="right_btn MT0 MB05">
                            <div class="btn ico-print">
                                <asp:Button ID="btnprint" runat="server" Text="Print"  ToolTip="Print" OnClick="btnprint_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btncanceljobdetails1" runat="server">
                                <asp:Button ID="btncanceljobdetails" Text="Print" runat="server" ToolTip="Cancel" OnClick="btncanceljobdetails_Click" />
                            </div>
                        </div>
                    </div>

                    <div runat="server" id="div_ExemptionList" class="PendingStatisticsN1 position" visible="false">

                        <div class="PortCountryJobCus">
                            <h3 id="h7" runat="server">
                                <asp:Label ID="Label10" runat="server" Text="Exemption List"></asp:Label>
                            </h3>
                        </div>
                        <div class="Clear"></div>
                        <div class="FormGroupContent4">
                            <div class="ExemCompDrop">
                                <asp:DropDownList ID="ddldivision" runat="server" CssClass="chzn-select" data-placeholder="Division" ToolTip="Division" AutoPostBack="true"></asp:DropDownList>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="Left_btn">
    <div class="btn ico-excel">
        <asp:LinkButton ID="btnExporttoexcel" runat="server" OnClick="btnExporttoexcel_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
    </div>
    <%--  <asp:Button ID="btnExporttoexcel" runat="server" Text="Export 2 Excel" OnClick="btnExporttoexcel_Click" /></div>--%>
</div>
<div class="right_btn MT0 MB05">

    <div class="btn ico-cancel" id="btnBack1" runat="server">
        <asp:Button ID="btnBack" runat="server" ToolTip="Cancel" Text="Cancel"  OnClick="btnBack_Click" Style="color: #4e4e4c!important;" />
    </div>
</div>
                            </div>
                            <div class="FormGroupContent4">


                                <div class="div_grdviewExemption">
                                    <asp:GridView ID="grdExcmption" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" PageSize="20" AllowPaging="false" OnPageIndexChanging="grdExcmption_PageIndexChanging" OnRowDataBound="grdExcmption_RowDataBound">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Branch">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="branch" runat="server" Text='<%# Bind("branch") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--  <asp:BoundField DataField="trantype" HeaderText="Product" >
                      <HeaderStyle Width ="50px"/>
                      <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width ="50px"/>                    
                      </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                        <asp:Label ID="trantype" runat="server" Text='<%# Bind("trantype") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Exemption By">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                        <asp:Label ID="empname" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%-- <asp:BoundField DataField="reqon" HeaderText="Emempted On" >
                      <HeaderStyle Width ="100px"/>
                      <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width ="100px"/>                    
                      </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Exemption On">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="reqon" runat="server" Text='<%# Bind("reqon") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="docno" HeaderText="BL#/DOC #" >
                      <HeaderStyle Width ="100px"/>
                      <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width ="100px"/>                    
                      </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="BL#/DOC #">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="docno" runat="server" Text='<%# Bind("docno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="reqremarks" runat="server" Text='<%# Bind("reqremarks") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle CssClass="GrdRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                    <div class="div_Break"></div>
                                </div>
                            </div>
                        </div>
                        


                    </div>

                    <div runat="server" id="div_BillingReport" class="PendingStatisticsN1 position" visible="false">
                        <div class="PortCountryJobCus">
                            <h3 id="h8" runat="server">
                                <asp:Label ID="Label11" runat="server" Text="Income Statement"></asp:Label>
                            </h3>
                        </div>
                        <div class="FormGroupContent4'" >
                              <div class="Left_btn1 MT0 MB05">
      <div class="btn ico-excel">
          <asp:LinkButton ID="btn_export_billrpt" runat="server" OnClick="btn_export_billrpt_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
      </div>
  </div>
  <%--    <div class="btn btn-export"><asp:Button ID="btn_export_billrpt" runat="server" Text="Export To Excel"  OnClick="btn_export_billrpt_Click" /></div>--%>
  <div class="right_btn MT0 MB05">
      <div class="btn ico-back">
          <asp:Button ID="btncancel_billrpt" runat="server"  Text="Back" ToolTip="Back" OnClick="btncancel_billrpt_Click" />
      </div>
  </div>
                        </div>
                        <div class="Clear"></div>

                        <div class="FormGroupContent4">
                            <div class="gridpnl" style="width:100%" >
                                <%--<asp:Panel id="Panel1" runat="server" cssClass="grid_1" Visible="false">--%>
                                <asp:GridView runat="server" ID="grdJobDtls" AutoGenerateColumns="False" PageSize="21" Width="100%" CssClass="Grid FixedHeader" AllowPaging="false"
                                    OnPageIndexChanging="grdJobDtls_PageIndexChanging" ShowHeaderWhenEmpty="true" OnRowDataBound="grdJobDtls_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                    <asp:Label ID="Branch" runat="server" Text='<%# Bind("shortname") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="55px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Job #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ETA/ETD">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                    <asp:Label ID="ETA_ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="BL #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                    <asp:Label ID="BL" runat="server" Text='<%# Bind("blno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Vou #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                    <asp:Label ID="Vou" runat="server" Text='<%# Bind("vouno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Vou Date">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                                    <asp:Label ID="VouDate" runat="server" Text='<%# Bind("voudate") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 195px">
                                                    <asp:Label ID="Customer" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="amount" HeaderText="Amount">
                                            <HeaderStyle Wrap="true" Width="91px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                        <%--<asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" >  
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                    <asp:Label ID="Amount" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="91px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Right" ></ItemStyle>
                                        </asp:TemplateField>--%>

                                        <%-- <asp:TemplateField HeaderText ="Column1" ItemStyle-CssClass="hide">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="Column1" runat="server" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="91px"  HorizontalAlign="Center" CssClass="hide" />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText ="customerid" ItemStyle-CssClass="hide">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="customerid" runat="server" Text='<%# Bind("customerid") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="91px"  HorizontalAlign="Center" CssClass="hide" />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>  --%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                                <div class="div_break"></div>
                            </div>
                        </div>
                      
                    </div>

                    <div runat="server" id="div_CutOffBreakUp" class="PendingStatisticsN1 position" visible="false">
                        <div class="PortCountryJobCut">
                            <h3 id="h9" runat="server">
                                <asp:Label ID="Label12" runat="server" Text="CutOff BreakUp"></asp:Label>
                            </h3>
                        </div>
                        <div class="Clear"></div>

                        <div class="FormGroupContent4">
                            <div class="" id="inboundgrd" runat="server">
                                <asp:Panel ID="Panel13" runat="server" CssClass="" Width="100%">
                                    <asp:GridView ID="GridView3" runat="server" Width="100%" CssClass="Grid FixedHeader" OnRowDataBound="GridView3_RowDataBound">
                                        <Columns>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader  " Wrap="false" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Wrap="false" />
                                    </asp:GridView>
                                </asp:Panel>

                            </div>

                            <asp:Panel ID="Panel14" runat="server" CssClass="gridpnl" ScrollBars="Vertical" Width="100%">
                                <asp:GridView ID="GridView4" runat="server" Width="100%" CssClass="Grid FixedHeader" OnRowDataBound="GridView4_RowDataBound">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" Wrap="false" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Wrap="false" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <div class="FormGroupContent4">

                            <div class="left_btn">
                                <div class="btn ico-excel">
                                    <asp:LinkButton ID="btn_exp_cutoff" runat="server" OnClick="btn_exp_cutoff_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
                                    <%--    <asp:Button ID="btn_exp_cutoff" runat="server" Text="Export to Excel"  OnClick="btn_exp_cutoff_Click" />--%>
                                </div>
                            </div>
                            <div class="right_btn">
                                <div class="btn ico-back">
                                    <asp:Button ID="btn_canc_ctoff" runat="server" Text="Back" ToolTip="Back" OnClick="btn_canc_ctoff_Click" />
                                </div>
                            </div>


                        </div>

                    </div>

                    <div runat="server" id="div_Tradelane" class="PendingStatisticsN1 position" visible="false">
                        <div>
                            <div class="col-md-12  maindiv">

                                <div class="widget4 box4 borderremove">

                                    <div class="widget-content">

                                        <div class="TradeLane1">
                                            <h3>
                                                <asp:Label ID="Label13" runat="server" Text="Tradelane"></asp:Label></h3>
                                        </div>
                                        <div class="widget-content">
                                            <div class="FormGroupContent4">

                                                <div class="TradeComLbl">
                                                    <asp:Label ID="lbl_division" runat="server" Text="Company"></asp:Label></div>
                                                <div class="TradeCompany">
                                                    <asp:DropDownList ID="ddl_division" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" Data-placeholder="Company" ToolTip="Company">
                                                        <asp:ListItem Value="0">ALL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <%--<div class="TradeBranch"><asp:Label ID="lbl_branch" runat="server" Text="Branch"></asp:Label></div>--%>
                                                <%--           <div class="TradeBrDrop">  <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"  CssClass="chzn-select" Data-placeholder="Branch" ToolTip="Branch"
            AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged">
            <asp:ListItem Value="0">ALL</asp:ListItem>
        </asp:DropDownList></div>--%>
                                                <div class="TradeSector">
                                                    <asp:Label ID="lbl_sector" runat="server" Text="Sector"></asp:Label></div>
                                                <div class="TradeSecDrop">
                                                    <asp:DropDownList ID="ddl_sector" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" Data-placeholder="Sector" ToolTip="Sector"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_sector_SelectedIndexChanged">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Value="0">ALL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="bordertopNew"></div>
                                            <div class="FormGroupContent4">
                                                <div class="ComLbl">Comparison</div>

                                                <div class="PeriodLeftC">
                                                    <div class="Period1">
                                                        <asp:Label ID="lbl_period1" runat="server" Text="Period 1"></asp:Label></div>
                                                    <div class="Periodleft">

                                                        <div class="TradeFromLbl">
                                                            <asp:Label ID="Label14" runat="server" Text="From"></asp:Label></div>
                                                        <div class="TradeMonthLbl">
                                                            <asp:Label ID="lbl_frmmonth" runat="server" Text="Month"></asp:Label></div>
                                                        <div class="TradeDrop">
                                                            <asp:DropDownList ID="ddlfrmmonth" runat="server" AppendDataBoundItems="True" CssClass="chzn-select">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="TradeYear">
                                                            <asp:Label ID="lbl_frmyear" runat="server" Text="Year"></asp:Label></div>
                                                        <div class="TradeYrInput">
                                                            <asp:TextBox ID="txt_frmyear" runat="server" CssClass="form-control"></asp:TextBox></div>

                                                    </div>
                                                    <div class="Periodleft1">
                                                        <div class="TradeFromLbl">
                                                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label></div>
                                                        <div class="TradeMonthLbl">
                                                            <asp:Label ID="lbl_tomonth" runat="server" Text="Month"></asp:Label></div>
                                                        <div class="TradeDrop">
                                                            <asp:DropDownList ID="ddltomonthtrad" runat="server" AppendDataBoundItems="True" CssClass="chzn-select">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="TradeYear">
                                                            <asp:Label ID="lbl_toyear" runat="server" Text="Year"></asp:Label></div>
                                                        <div class="TradeYrInput">
                                                            <asp:TextBox ID="txt_toyear" runat="server" CssClass="form-control"></asp:TextBox></div>

                                                    </div>
                                                </div>
                                                <div class="PeriodLeftC1">
                                                    <div class="Period2">
                                                        <asp:Label ID="lbl_period2" runat="server" Text="Period 2"></asp:Label></div>
                                                    <div class="Periodleft">
                                                        <div class="TradeFromLbl">
                                                            <asp:Label ID="lbl_from_p2" runat="server" Text="From"></asp:Label></div>
                                                        <div class="TradeMonthLbl">
                                                            <asp:Label ID="lbl_frmmonth_p2" runat="server" Text="Month"></asp:Label></div>
                                                        <div class="TradeDrop">
                                                            <asp:DropDownList ID="ddlfrmmonth1" runat="server" AppendDataBoundItems="True" CssClass="chzn-select">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="TradeYear">
                                                            <asp:Label ID="lbl_frmyear_p2" runat="server" Text="Year"></asp:Label></div>
                                                        <div class="TradeYrInput">
                                                            <asp:TextBox ID="txt_frmyear1" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                    </div>
                                                    <div class="Periodleft1">
                                                        <div class="TradeFromLbl">
                                                            <asp:Label ID="lbl_to_p2" runat="server" Text="To"></asp:Label></div>
                                                        <div class="TradeMonthLbl">
                                                            <asp:Label ID="lbl_tomonth_p2" runat="server" Text="Month"></asp:Label></div>
                                                        <div class="TradeDrop">
                                                            <asp:DropDownList ID="ddltomonth1" runat="server" AppendDataBoundItems="True" CssClass="chzn-select">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="TradeYear">
                                                            <asp:Label ID="lbl_toyear_p2" runat="server" Text="Year"></asp:Label></div>
                                                        <div class="TradeYrInput">
                                                            <asp:TextBox ID="txt_toyear1" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                    </div>
                                                </div>
                                                <div class="right_btn MT30 MB05">
                                                    <div class="btn ico-get">
                                                        <asp:Button ID="btn_get_trade" runat="server" Text="Get" ToolTip="Get" OnClick="btn_get_trade_Click" visisble="false" Style="color: #4e4e4c!important;" /></div>
                                                    <div class="btn ico-cancel">
                                                        <asp:Button ID="btn_cancel_trade" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_trade_Click" Visible="false" Style="color: #4e4e4c!important;" /></div>
                                                </div>
                                            </div>
                                            <div class="bordertopNew"></div>
                                            <div class="FormGroupContent4">
                                                <asp:Panel ID="Panel15" runat="server" ScrollBars="Vertical" CssClass="gridpnl" Width="100%" >
                                                    <div class="div_gridCor">
                                                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_Country" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            DataKeyNames="countryid" EmptyDataText="No Record Found">
                                                            <Columns>
                                                                <asp:BoundField DataField="countryname" HeaderText="Country">
                                                                    <ItemStyle Width="70%" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <%--<asp:CheckBox ID="CheckBox1" Text="" runat="server" 
                                onclick="javascript:checkAll(this);" AutoPostBack="True" 
                                OnCheckedChanged="Chk_show_CheckedChanged" />--%>
                                                                        <asp:CheckBox ID="Chk_show" Text="" runat="server"
                                                                            AutoPostBack="True"
                                                                            OnCheckedChanged="Chk_show_CheckedChanged" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%-- <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:Check(this);" AutoPostBack="True"
                                OnCheckedChanged="Loaddetail"  />--%>
                                                                        <asp:CheckBox ID="Chk_country" runat="server" AutoPostBack="True"
                                                                            OnCheckedChanged="Loaddetail" />
                                                                        <asp:HiddenField ID="hidchk" runat="server" Value='<%# Eval("countryid") %>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                            <HeaderStyle CssClass="GridHeader" />
                                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                                        </asp:GridView>
                                                    </div>

                                                    <div class="div_gridRight">
                                                        <div class="div_title">
                                                            <asp:Label ID="lbl_grd_period1" runat="server" Text="Period1"></asp:Label>
                                                        </div>
                                                        <div class="div_title1">
                                                            <asp:Label ID="lbl_grd_period2" runat="server" Text="Period2"></asp:Label>
                                                        </div>
                                                        <div class="div_break"></div>
                                                        <div class="div_gridproduct">
                                                            <asp:GridView CssClass="Grid FixedHeader" ID="Grd_product" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="No Record Found">
                                                                <Columns>
                                                                    <asp:BoundField DataField="product" HeaderText="Product">
                                                                        <ItemStyle Width="20%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="unit" HeaderText="Units">
                                                                        <ItemStyle Width="20%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="volume" HeaderText="Volume"
                                                                        DataFormatString="{0:#,##0.00}">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="retention" HeaderText="Revenue"
                                                                        DataFormatString="{0:#,##0.00}">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                    <%--<asp:BoundField DataField="unit" HeaderText="Units" />--%>
                                                                    <asp:BoundField DataField="volume1" HeaderText="Volume"
                                                                        DataFormatString="{0:#,##0.00}">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="retention1" HeaderText="Revenue"
                                                                        DataFormatString="{0:#,##0.00}">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                                <HeaderStyle CssClass="GridHeader" />
                                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


        </div>
        <%--rowend--%>
    </div>
        </div>


    <div class="OutstandingBox hide ">
        <div class="left_btn">

            <h3>Outstanding</h3>

            <%-- <asp:Button ID="btnexport" runat="server" Text="Export Excel" CssClass="Exportbtn"  OnClick="btnexport_Click"/>--%>
        </div>
        <div style="float: right; margin-right: 16px; margin-top: 1px;">
            <asp:LinkButton ID="excportexc" runat="server" OnClick="excportexc_Click"> <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"/></asp:LinkButton>
        </div>
        <div class="Clear"></div>
        <div class="HomeMenuBox custom-d-flex custom-mt-05 hide">
            <div class="custom-col custom-mr-05 custom-ml-05">

                <asp:LinkButton ID="lnkoutstAE" runat="server" OnClick="lnkoutstAE_Click">
                    <div class=" shadow_box1 Blue">
                        <div class="Divimg2"><i class="fa fa-inr  title" style="font-size: 25px; color: #4e73df;"></i></div>
                        <span id="SPoutstAE" runat="server" class=" Amount"></span>
                    </div>
                </asp:LinkButton>
            </div>

            <%--  <div class="OutStandingBox2">
                <span>9,99,99,999</span>

            </div>--%>
            <div class="custom-col custom-mr-05 custom-ml-05">

                <asp:LinkButton ID="lnkoutstAI" runat="server" OnClick="lnkoutstAI_Click">
                    <div class=" shadow_box1 Green">
                        <div class="Divimg2"><i class="fa fa-inr title" style="font-size: 25px; color: #1cc88a;"></i></div>


                        <span id="SPoutstAI" runat="server" class=" Amount"></span>
                    </div>
                </asp:LinkButton>
            </div>

            <div class="custom-col custom-mr-05">

                <asp:LinkButton ID="lnkoutstBT" runat="server" OnClick="lnkoutstBT_Click">
                    <div class=" shadow_box1 SkyBlue">
                        <div class="Divimg2"><i class="fa fa-inr title" style="font-size: 25px; color: #36b9cc;"></i></div>

                        <span id="SPoutstBT" runat="server" class=" Amount"></span>
                    </div>
                </asp:LinkButton>
            </div>

            <div class="custom-col custom-mr-05">

                <asp:LinkButton ID="lnkoutstCH" runat="server" OnClick="lnkoutstCH_Click">
                    <div class=" shadow_box1 Yellow">
                        <div class="Divimg2"><i class="fa fa-inr title" style="font-size: 25px; color: #f6c23e;"></i></div>

                        <span id="SPoutstCH" runat="server" class=" Amount"></span>
                    </div>
                </asp:LinkButton>
            </div>

            <div class="custom-col custom-mr-05">

                <asp:LinkButton ID="lnkoutstOE" runat="server" OnClick="lnkoutstOE_Click">
                    <div class=" shadow_box1 Green">
                        <div class="Divimg2"><i class="fa fa-inr title" style="font-size: 25px; color: #1cc88a;"></i></div>

                        <span id="SPoutstOE" runat="server" class=" Amount"></span>
                    </div>
                </asp:LinkButton>
            </div>

            <div class="custom-col custom-mr-05">

                <asp:LinkButton ID="lnkoutstOI" runat="server" OnClick="lnkoutstOI_Click">
                    <div class=" shadow_box1 Blue">
                        <div class="Divimg2"><i class="fa fa-inr title" style="font-size: 25px; color: #4e73df;"></i></div>

                        <span id="SPoutstOI" runat="server" class=" Amount"></span>
                    </div>
                </asp:LinkButton>
            </div>

            <div class="custom-col custom-mr-05">

                <asp:LinkButton ID="lnkoutsttot" runat="server" OnClick="lnkoutsttot_Click">
                    <div class=" shadow_box1 Red">
                        <div class="Divimg2"><i class="fa fa-inr title" style="font-size: 25px; color: #e74a3b;"></i></div>

                        <span id="SPoutsttot" runat="server" class=" Amount"></span>
                    </div>
                </asp:LinkButton>
            </div>
        </div>
    </div>


    <%------------------------------------------------------- PopUp -------------------------------------------%>
    <asp:ModalPopupExtender ID="popup" runat="server" TargetControlID="lblbkng" BehaviorID="programmaticModalPopupBehavior"
        PopupControlID="popupsecond"
        BackgroundCssClass="modalBackground" CancelControlID="imgok">
    </asp:ModalPopupExtender>


    <asp:Panel ID="popupsecond" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="booking" runat="server" ScrollBars="Both" CssClass="Gridpnl">

                <%--<asp:GridView ID="GRD_Common" CssClass="GrdRow" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true"
                    Width="100%" ForeColor="Black" AllowPaging="False"  OnRowDataBound="GRD_Common_RowDataBound" OnSelectedIndexChanged="GRD_Common_SelectedIndexChanged" 
                     >
                    <Columns>
                        

                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False"  Wrap="false" />
                    <HeaderStyle  Wrap="false" />
                </asp:GridView>--%>
            </asp:Panel>

            <div class="Break"></div>
            <div class="Break"></div>
            <div class="Break"></div>
        </div>

    </asp:Panel>
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

            <asp:Panel ID="Panel8" runat="server" CssClass="Gridpnl">
                <iframe id="iframe_buyratequery" width="100%" height="100%" runat="server" src="../Accounts/RetentionPerunit.aspx" frameborder="0"></iframe>

            </asp:Panel>

            <div class="Break"></div>
            <div class="Break"></div>
            <div class="Break"></div>
        </div>
        <div class="Break"></div>
        <div class="Break"></div>
        <div class="Break"></div>
    </asp:Panel>




    <%-- BLVOUCHERWISE --%>


    <asp:HiddenField ID="hid_branch" runat="server" />
    <asp:HiddenField ID="hid_division" runat="server" />
    <asp:HiddenField ID="hid_trantype" runat="server" />
    <asp:Label ID="Label7" runat="server" />
    <asp:Label ID="hid_vou" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="pln_popup" TargetControlID="Label7"
        BackgroundCssClass="modalBackground" runat="server" CancelControlID="Image1" />
    <asp:ModalPopupExtender ID="ModalPopupExtender2" PopupControlID="pln_voucher" TargetControlID="hid_vou"
        BackgroundCssClass="modalBackground" runat="server" CancelControlID="Close_voucher" />
    <div class="div_popup" style="margin: 0px 0px 0px 10px; display:none">
        <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup">


            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>


            <%--            <div class="div_BL">
                <table>
                    <tr>
                        <td>

                            <asp:Image ID="" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif"
                                CssClass="div_close" />
                        </td>
                    </tr>
                </table>
            </div>--%>
            <asp:GridView ID="Grd_BL" runat="server" AutoGenerateColumns="False" Width="99%"
                ForeColor="Black" EmptyDataText="No Record Found" PageSize="15" BackColor="White" CssClass="Grid FixedHeader">
                <Columns>
                    <asp:BoundField DataField="blno" HeaderText="BL #">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="shipper" HeaderText="Shipper" />
                    <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                    <asp:BoundField DataField="agent" HeaderText="Agent" />
                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                    <asp:BoundField DataField="pod" HeaderText="PoD" />
                    <asp:BoundField DataField="volume" HeaderText="Vol/Tues">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="salesperson" HeaderText="Salesperson" />
                    <asp:BoundField DataField="retention" HeaderText="Revenue">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </asp:Panel>
    </div>
    <div class="div_Break"></div>
    <asp:Panel ID="pln_voucher" runat="server" CssClass="panel_17">
        <div class=" divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <%--<table>
                <tr>
                    <td></td>
                    <td>--%>
            <%--<asp:Image ID="" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif"
                            CssClass="div_close_voucher" />--%>
            <%--   </td>
                </tr>
            </table>--%>
        </div>
        <div class="div_frame">
            <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF"></iframe>
        </div>

    </asp:Panel>
    <div class="div_Break"></div>


    <%-- BLVOUCHERWISE END--%>

    <asp:HiddenField ID="hd_branchID" runat="server" />
    <asp:HiddenField ID="hd_product" runat="server" />
    <asp:HiddenField ID="hid" runat="server" />

    <asp:HiddenField ID="hid_trantypeid" runat="server" />



    <asp:Label ID="lblbkng" runat="server"></asp:Label>
    <asp:HiddenField ID="hf_agent1" runat="server" />
    <asp:HiddenField ID="hf_date" runat="server" />
    <asp:HiddenField ID="hf_tran" runat="server" />
    <asp:GridView ID="grdexcel" runat="server"></asp:GridView>
<%--</asp:Content>--%>
                </div>
            </form>
   </body>
    </html>
