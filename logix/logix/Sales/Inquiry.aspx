<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Inquiry.aspx.cs" Inherits="logix.Sales.Inquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->
    <%--  <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>--%>


    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" language="javascript">
       <!--
    function validateQty(el, evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode != 45 && charCode != 8 && (charCode != 46) && (charCode < 48 || charCode > 57)) {
            alertify.alert("Enter the Number and Decimal point");
            return false;
        }
        if (charCode == 46) {
            if ((el.value) && (el.value.indexOf('.') >= 0)) {
                return false;
            }
            else
                return true;
        }
        return true;
        var charCode = (evt.which) ? evt.which : event.keyCode;
        var number = evt.value.split('.');
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            alertify.alert("Enter the Number and Decimal point");
            return false;
        }
    };
    function nospaces(t) {
        if (t.value.match(/\s/g)) {
            t.value = t.value.replace(/\s/g, '');
            alertify.alert("Space Not Allow");
        }
    }

    //-->  onkeypress="return isNumberKey(event,this.id)"
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
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/Quotation.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles_Date/jquery1-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Script_Date/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/x.js" type="text/javascript"></script>
    <script src="../Scripts/xtableheaderfixed.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />





    <style type="text/css">
        span#logix_CPH_Label33, span#logix_CPH_Label32 {
            margin-right: 5px;
        }



        table {
            position: relative;
            top: -1px;
            left: -1px;
        }

        .StickHeader th {
            position: sticky;
            top: -1px;
        }

        .StickHeader td {
            border-right: 1px solid #AAA !important;
            border-bottom: 1px solid #AAA !important;
        }

        .StickHeader input {
            margin: 0px !important;
        }
        /*.FormGroupContent4{
            padding:5px 0px 0px 0px!important;
        }*/
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

        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: 0%;
            border-radius: 90px 90px 90px 90px;
        }

        .divRoated {
            width: 90%;
            height: 75vh;
            overflow: hidden;
            background: #fff;
            border-radius: 3px;
        }

        /*.DivSecPanel img {
  transition: transform 0.5s ease;
}
.DivSecPanel img:hover {
  transform: rotate(180deg);
}*/

        .div_iframe {
            float: left;
            height: 750px;
            width: 85%;
        }

        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            top: -15px !important;
        }

        #programmaticModalPopupBehavior2_foregroundElement {
            left: 0px !important;
            top: -18px !important;
            position: absolute !important;
        }

        #logix_CPH_pnlJobAE {
            left: 14px !important;
            top: 17px !important;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #table-container {
            position: relative;
            width: 99%;
            height: 400px;
            overflow: auto;
            padding: 0 0.1% 0 0;
            margin-top: 0.8%;
            margin-bottom: 1%;
            /*----------------*/
            font-family: Tahoma;
            margin-left: 0.3%;
        }

        table.gvTheGrid td,
        table.gvTheGrid th {
            padding: 3px 7px;
        }

        .Pnl1 {
            margin-left: 10%;
            height: 25%;
            text-align: center;
            background-color: White;
            border: solid 3px black;
            float: left;
        }

        .div_confirm {
            float: right;
            margin-right: 1%;
            margin-top: 0.5%;
        }

        .Pnl2 {
            margin-left: 0%;
            height: 15%;
            text-align: center;
            background-color: White;
            border: solid 1px #b1b1b1;
            float: left;
            padding: 10px;
        }

        .Pnl3 {
            width: 100%;
            left: 25px !important;
            top: 110px !important;
            margin-left: 0%;
            overflow: auto;
            height: 38.5%;
            text-align: center;
            background-color: White;
            border: solid 1px #b1b1b1;
            float: left;
            padding: 0px 5px 0px 5px;
        }

        .div_confirm1 {
            margin-right: 1%;
            margin-top: 5.5%;
        }

        .hide {
            display: none;
        }

        .FooterCont {
            background-color: #647682;
            bottom: 0;
            height: 55px;
            margin: 20px 0 0;
            position: absolute;
            top: 1000px;
            width: 100%;
            z-index: 999;
        }

        .div_Menu {
            background-color: White;
            border: 0 solid #f00;
            float: left;
            height: 1210px !important;
            margin-left: 0.5%;
            margin-top: 3%;
            width: 1350px;
        }

        .crumbslbl {
            display: none;
        }

        .btn-UpdateAdd2 {
            /*background-color: #00bcd4;
    color: #ffffff;*/
            z-index: 2;
            border-radius: 0px;
        }

            .btn-UpdateAdd2 input {
                /*background-color: #00bcd4;
        background-image: none !important;*/
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
                background: url(../Theme/assets/img/buttonIcon/updateadd_ic.png ) no-repeat left top;
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

        modalPopupLog {
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
            font-family: Tahoma;
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
                font-size: 12px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 12px;
                font-family: Tahoma;
                color: #4e4e4c;
            }

        .row {
            height: 576px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 99%;
        }

        .widget.box .widget-content {
            padding: 10px 10px 0px 10px;
            position: relative;
            background-color: transparent;
            display: block;
            top: -1px;
            left: 0px;
        }

        modalPopup {
            background-color: rgba(0, 0, 0, 0.75);
            width: 100%;
            height: 90%;
            margin-left: 0%;
            margin-top: -1%;
            border: 1px solid #b1b1b1;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .JobDetailsInput {
            width: 62.3%;
            float: left;
            margin: 5px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

            .JobDetailsInput input {
                background-color: #ffffff !important;
            }

        .DesiInput {
            width: 37.2%;
            float: left;
            margin: 5px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

            .DesiInput input {
                background-color: #ffffff !important;
            }

        .DesiInput1 {
            width: 37.2%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInput3new {
            float: left;
            width: 62.3%;
            margin: 0px 0.5% 0px 0.5px;
            font-size: 11px;
            color: #000080;
        }

        .widget.box {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
            margin-top: 0px;
        }

        .ChkboxDisplay {
            float: left;
            text-align: right;
            width: 4%;
            margin: 18px 14px 0px 0px;
            color: #396594;
            font-size: 11px;
        }

        .FormInput3 {
            float: left;
            width: 18.7%;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInputbox1 {
            float: left;
            width: 100%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInputbox3 {
            float: left;
            width: 12%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInputbox2 {
            float: left;
            width: 14.9%;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .formdropdownbox {
            float: left;
            width: 16%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        input#logix_CPH_txtterms {
            height: 53px !important;
        }

        .formdropdownboxbase {
            float: left;
            width: 6%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .DateandYr span {
            color: #000080;
        }

        .formdropdownboxF {
            float: left;
            width: 12%;
            margin: 0px 0.5% 0px 0%;
            font-size: 11px;
            color: #000080;
        }

        .Freight {
            float: left;
            width: 13%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .QuotationGrid1 {
            float: left;
            width: 49.5%;
            margin: 0px 0px 0px 0px;
        }

        .BuyingGrid {
            float: left;
            width: 50%;
            margin: 0px 0.5% 0px 0px;
        }

        .panel_one {
            height: 105px !important;
            overflow: auto !important;
            border: 1px solid #b1b1b1;
            margin: 7px 0px 0px;
        }

        .CalendarBG input {
            background-color: #fff !important;
            /*border: 1px solid #b1b1b1 !important;*/
        }

        .CalendarBG {
            background-color: transparent;
            font-size: 11px;
            color: #000080;
            float: left;
            width: 14.2%;
            margin: 0px 0.5% 0px 0px;
        }

        .FormInput1 {
            float: left;
            width: 16%;
            overflow: hidden;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .DateandYr {
            background-color: transparent;
            color: #000080;
            font-size: 11px;
            width: 50%;
            min-height: 24px;
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .FormtxtLabel {
            float: left;
            width: 4.8%;
            text-align: right;
            overflow: hidden;
            font-size: 11px;
            color: #396594;
            margin: 0px 5px 0px 0px !important;
            vertical-align: middle;
            padding: 5px 0px 0px 0px;
        }

        .PrepareTxt {
            font-size: 12px;
            color: #4e4e4c;
            width: 11.8%;
            float: left;
            margin: 3px 0.5% 0px 0px;
            text-align: right;
            font-weight: bold;
        }

        .chzn-drop {
            height: 156px !important;
            overflow: auto;
        }

        .TxtRemarks {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .TxtRemarks3 {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInput6 {
            float: left;
            width: 5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        span.required {
            margin: 0px 0px 0px -5px !important;
        }

        .TermsTxtBox textarea {
            height: 69px !important;
        }

        .FormInput4 {
            float: left;
            width: 83.5%;
            margin: 0px 0px 0px 0px;
        }

        .QuoteLeft {
            width: 78%;
            float: left;
            margin: 10px 1% 0px 0px;
        }

        .QuoteRight {
            width: 19.6%;
            float: left;
            margin: 20px 0px 0px 5px;
        }

        textarea#logix_CPH_txtgroupAddress {
            margin: 0px 0px 0px !important;
        }

        .FormInput2 {
            float: left;
            width: 100%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInput_2 {
            float: left;
            width: 40.5%;
            margin: 0px 0.5% 0px 97px;
            font-size: 11px;
            color: #000080;
        }

        .FormInput5txtcharges {
            float: left;
            width: 15.5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormCarrier {
            float: left;
            width: 49%;
            margin: 0px 0px 0px 0px;
        }

        .FormCarrier2 {
            float: left;
            width: 49%;
            margin: 0px 0px 0px 0px;
        }

        .FormInput7 {
            float: left;
            width: 6%;
            margin: 0px 0.5% 0px 0.5%;
            font-size: 11px;
            color: #000080;
        }

        .Formdisplay {
            float: left;
            width: 100%;
            color: #313131;
            padding: 0px 0px;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .bordertopNew_2 {
            float: left;
            min-height: 1px;
            margin: 0px 0px 0px 0px;
            border-top: 1px solid #807f7f;
            width: 100%;
        }

        .bordertopNew {
            float: left;
            min-height: 1px;
            margin: 5px 0px 5px 0px;
            border-top: 1px solid #807f7f;
            width: 100%;
        }

        .GrossTxt {
            float: left;
            width: 8%;
            color: #000080;
            margin: 18px 0px 0px 0px;
        }

            .GrossTxt input {
                vertical-align: top;
                margin: 3px 5px 0px 0px;
            }

        .Cargotxt {
            float: left;
            width: 38.7%;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormLabel {
            float: left;
            width: 6.5%;
            overflow: hidden;
            color: #396594;
            margin: 0px 0px 0px 0px;
            font-size: 12px !important;
            vertical-align: middle;
            text-align: left;
            padding: 4px 0px 0px 0px;
        }

        .QDate {
            width: 3%;
            float: left;
            margin: 5px 0% 0px 0.5%;
            text-align: right;
            font-size: 11px;
        }

        .div_GridBying1 {
            Border: 1px solid #999997;
            height: 170px;
            float: left;
            width: 100%;
            margin-top: .2%;
            margin-bottom: .5%;
            overflow-y: scroll !important;
            overflow-x: auto !important;
        }

        modalPopupQ {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
            width: 99%;
            Height: 550px;
            margin-left: 0%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }

        .FormGroupContent4 textarea {
            overflow: hidden !important;
            height: 36px !important;
        }

        .cusAddrss textarea:focus,
        .ConAdd textarea:focus,
        .FormCarrier2 textarea:focus,
        .cusAddrss textarea:focus,
        textarea#logix_CPH_txtgroupAddress:focus {
            height: 65px !important;
        }

        .chzn-container-single .chzn-single span {
            width: 100%;
        }

        .cusAddrss {
            float: left;
            width: 50.5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Formradbutton {
            color: #396594;
            float: left;
            width: 25%;
            margin: 0px 0px 0px 0.5%;
            font-size: 11px;
        }

        .RemarksLeft {
            width: 48.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MArCtrl {
            display: inline-block;
            margin: 0px 0px 0px 10px !important;
        }

        .RemarksTxtBox {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .FormGroupContent4 .RemarksTxtBox textarea {
            height: 128px !important;
        }
        /*. {
            border:1px solid #4286f4!important;
        }*/
        .SeaLeft {
            width: 70%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SeaRightNew {
            width: 14.5%;
            float: left;
            margin: 17px 0.5% 0px 0px;
        }

        .SeaRight {
            float: left;
            width: 105%;
            margin: -5px 0px 0px 0px;
        }

        div#logix_CPH_Panel7 {
            width: 100%;
        }

        .DivSecPanelNew {
            width: 2%;
            float: right;
            margin: 0px 0px 0px 0px;
        }

        div#logix_CPH_Panel8 {
            width: 79%;
            height: 640px;
        }

        a#logix_CPH_lnk_terms {
            color: maroon;
        }

        .btn-update1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-update1 input {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
                background: url(../Theme/assets/img/buttonIcon/update_ic.png) no-repeat left top;
            }

        .TotalInputosdn {
            width: 50%;
            display: flex;
            align-items: center;
            float: right;
            margin: 0px 0px 0px 0px;
        }

        /*span#logix_CPH_Label32 {
    margin: 0px 0px 0px 439px;
}*/

        Gridpnl {
            width: 99%;
            margin: 0 auto;
            Height: 91%;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        input#logix_CPH_TextBox2 {
            width: 251px;
        }

        input#logix_CPH_TextBox2 {
            width: 126px;
        }

        span#logix_CPH_Label49 {
            margin-right: 10px !important;
        }

        .Expected2.MB5 {
            margin: 0px 0px 0px 703px;
        }

        .Expecten1.MB10 {
            margin: 1px 0px 0px 0px;
            padding: 0.5px;
            width: 67px;
        }

        .Expected2.MB10 {
            margin: 0px 0.5px 0px 730px;
            width: 8%;
        }

        div#logix_CPH_btn_add {
            margin: 9px 0 0 0;
        }

        textarea#logix_CPH_txtaddress,
        textarea#logix_CPH_TextBox1,
        textarea#logix_CPH_txt_shipermulti,
        textarea#logix_CPH_txt_consigneemulti {
            height: 73px !important;
            margin: 10px 0 0 0 !important;
        }

        .approvedby {
            float: left;
        }

        table#logix_CPH_GrdBuysellcharge {
            border-top: 1px solid var(--inputborder) !important;
            top: 0;
            margin: 5px 0 0 !important;
        }

        .Expecten1 {
            float: right;
            margin: 0 0.5% 0 0;
            width: 87px;
            text-align: right;
        }

        .Retention1 {
            float: right;
            margin: 0 0.5% 0 0;
            width: 82px;
            text-align: right;
        }

        .Expected2 {
            float: right;
            margin: 0 0.5% 0 0;
            width: 90px;
            text-align: right;
        }

        textarea#logix_CPH_txtgroupAddress {
            margin: 10px 0 0 0 !important;
        }

        table#logix_CPH_test {
            background-color: #fff;
        }

        input#logix_CPH_txtapprovedby {
            width: 250px;
        }

        /*div#logix_CPH_Gridcont {
            margin: 10px 0 0;
        }*/

        div#logix_CPH_Panel7 {
            margin: 10px 0px 0px !important;
        }

        td.TxtAlign2, td.TxtAlign3 {
            text-align: right;
        }

        input#logix_CPH_txtprofitamount {
            text-align: right;
        }

        input#logix_CPH_txtselling {
            text-align: right;
        }

        input#logix_CPH_txtbuyings {
            text-align: right;
        }

        table#logix_CPH_grdQuotaionDetails td:nth-child(4) {
            width: 13%;
        }

        .divleft {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }


        img {
            width: auto\9;
            height: 24px;
            vertical-align: middle;
            border: 0;
            -ms-interpolation-mode: bicubic;
            float: right;
        }


        /*table#logix_CPH_GrdBuysellcharge tbody td:nth-child(1) {
            width: 17.4%;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(2) {
            width: 1%;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(3) {
            width: 2% !important;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(4) {
            width: 3% !important;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(5) {
            width: 0% !important;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(6) {
            width: 3% !important;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(7) {
            width: 3% !important;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(8) {
            width: 2% !important;
        }

        table#logix_CPH_GrdBuysellcharge tbody td:nth-child(9) {
            width: 2% !important;
        }*/

        div#UpdatePanel1 {
            height: 88vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        img#logix_CPH_porflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: -34%;
            top: -44px;
        }

        img#logix_CPH_flagimg {
            width: 24px !important;
            height: auto;
            position: relative;
            left: -44%;
            top: -44px;
        }

        img#logix_CPH_podflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: -29%;
            top: -44px;
        }

        img#logix_CPH_fdflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: -51%;
            top: -44px;
        }

        .commodity {
            width: 75%;
            float: left;
            margin: 0 0.5% 0 0;
        }

        .Shipment_value {
            width: 23.5%;
            float: left;
            margin: 0 0 0 0;
        }

        .Address {
            width: 100%;
            float: left;
        }

        .txt_pieces {
            width: 5%;
            float: left;
            margin: 0 0.5% 0 0;
        }

        table#logix_CPH_grdQuotaionDetails th:nth-child(2) {
            width: 3% !important;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {


            $(document).ready(function () {
                $("#<%=txtCustomer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_customerid.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetLikeCustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2],
                                        text: item.split('~')[3]

                                    }
                                }))

                            },

                            error: function (response) {
                                //  alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_customerid.ClientID %>").val(i.item.val);
                            $("#<%=txtaddress.ClientID %>").val(i.item.text);
                            $("#<%=txtCustomer.ClientID %>").change();
                           <%-- $("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_customerid.ClientID %>").val(i.item.val);
                            $("#<%=txtaddress.ClientID %>").val(i.item.text);
                            $("#<%=txtCustomer.ClientID %>").val($.trim(result));
                            <%--$("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_customerid.ClientID %>").val(i.item.val);
                            $("#<%=txtaddress.ClientID %>").val(i.item.text);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtCustomer.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(res));
                        }
                    },

                    minLength: 1

                });
            });




           <%-- $(document).ready(function () {
                $("#<%=txtCustomer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_customerid.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetCustomer",
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
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hdf_customerid.ClientID %>").val(i.item.val);
                            $("#<%=txtCustomer.ClientID %>").change();
                            $("#<%=txtCustomer.ClientID %>").val(i.item.address);

                        }
                    },

                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hdf_customerid.ClientID %>").val(i.item.val);
                            $("#<%=txtCustomer.ClientID %>").val($.trim(result));
                            $("#<%=txtCustomer.ClientID %>").val(i.item.address);

                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hdf_customerid.ClientID %>").val(i.item.val);
                            $("#<%=txtCustomer.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtCustomer.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtCustomer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });--%>
            $(document).ready(function () {
                $("#<%=txtCargo.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_cargoid.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetLikeCargo",
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
                        $("#<%=txtCargo.ClientID %>").val(i.item.label);
                        $("#<%=txtCargo.ClientID %>").change();
                        $("#<%=hdf_cargoid.ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txtCargo.ClientID %>").val(i.item.label);
                        $("#<%=hdf_cargoid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtCargo.ClientID %>").val(i.item.label);
                        $("#<%=hdf_cargoid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1

                });
            });
            $(document).ready(function () {
                $('#<%=txtPOR.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_POR.ClientID %>").val(0);

                        $.ajax({
                            url: "Inquiry.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtPOR.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtPOR.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_POR.ClientID %>").val(ui.item.portid);
                        $('#<%=txtPOR.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtPOR.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_POR.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });


            <%--$(document).ready(function () {
                $("#<%=txtPOR.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_POR.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetPOR",
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
                        $("#<%=txtPOR.ClientID %>").val(i.item.label);
                        $("#<%=txtPOR.ClientID %>").change();
                        $("#<%=hdf_POR.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPOR.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POR.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtPOR.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POR.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtPOR.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POR.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $('#<%=txtPOL.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_POL.ClientID %>").val(0);

                        $.ajax({
                            url: "Inquiry.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtPOL.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtPOL.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_POL.ClientID %>").val(ui.item.portid);
                        $('#<%=txtPOL.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtPOL.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_POL.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });



            <%-- $(document).ready(function () {
                $("#<%=txtPOL.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_POL.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetPOL",
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
                        $("#<%=txtPOL.ClientID %>").val(i.item.label);
                        $("#<%=txtPOL.ClientID %>").change();
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPOL.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtPOL.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtPOL.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>
            $(document).ready(function () {
                $('#<%=txtPOD.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_POD.ClientID %>").val(0);

                        $.ajax({
                            url: "Inquiry.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtPOD.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtPOD.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_POD.ClientID %>").val(ui.item.portid);
                        $('#<%=txtPOD.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtPOD.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_POD.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });

            <%-- $(document).ready(function () {
                $("#<%=txtPOD.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_POD.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetPOD",
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
                        $("#<%=txtPOD.ClientID %>").val(i.item.label);
                        $("#<%=txtPOD.ClientID %>").change();
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPOD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtPOD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtPOD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>
            $(document).ready(function () {
                $('#<%=txtFD.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_FD.ClientID %>").val(0);

                        $.ajax({
                            url: "Inquiry.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtFD.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtFD.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_FD.ClientID %>").val(ui.item.portid);
                        $('#<%=txtFD.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtFD.ClientID%>').val(ui.item.portname);
                        $("#<%=hdf_FD.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });

           <%-- $(document).ready(function () {
                $("#<%=txtFD.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_FD.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetFD",
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
                        $("#<%=txtFD.ClientID %>").val(i.item.label);
                        $("#<%=txtFD.ClientID %>").change();
                        $("#<%=hdf_FD.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtFD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_FD.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtFD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_FD.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtFD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_FD.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $("#<%=txtSalesPerson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_salesperson.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetSales",
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

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtSalesPerson.ClientID %>").change();
                        $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));

                        $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtSalesPerson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtCharges.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_Charges.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetChargename",
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
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                        $("#<%=txtCharges.ClientID %>").change();
                        $("#<%=hdf_Charges.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                        $("#<%=hdf_Charges.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                        $("#<%=hdf_Charges.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtCurr.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_Curr.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetCurrencyname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        //val: item.split('~')[1]
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
                        $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=txtCurr.ClientID %>").change();
                        $("#<%=hdf_Curr.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdf_Curr.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdf_Curr.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtInco.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_Incoid.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetLikeIncocode",
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
                        $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=txtInco.ClientID %>").change();
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtCarrier.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnCarrier.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetLikeCustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2],
                                        text: item.split('~')[3]

                                    }
                                }))

                            },

                            error: function (response) {
                                //  alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                            $("#<%=TextBox1.ClientID %>").val(i.item.text);
                            $("#<%=txtCarrier.ClientID %>").change();
                           <%-- $("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                            $("#<%=TextBox1.ClientID %>").val(i.item.text);
                            $("#<%=txtCarrier.ClientID %>").val($.trim(result));
                            <%--$("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                            $("#<%=TextBox1.ClientID %>").val(i.item.text);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtCarrier.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(res));
                        }
                    },

                    minLength: 1

                });
            });

            $(document).ready(function () {
                $("#<%=txt_shiper.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_shipperid.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetLikeCustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2],
                                        text: item.split('~')[3]

                                    }
                                }))

                            },

                            error: function (response) {
                                //  alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdn_shipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipermulti.ClientID %>").val(i.item.text);
                            $("#<%=txt_shiper.ClientID %>").change();
                           <%-- $("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdn_shipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipermulti.ClientID %>").val(i.item.text);
                            $("#<%=txt_shiper.ClientID %>").val($.trim(result));
                            <%--$("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdn_shipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipermulti.ClientID %>").val(i.item.text);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_shiper.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(res));
                        }
                    },

                    minLength: 1

                });
            });

            $(document).ready(function () {
                $("#<%=txt_consignee.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_Consigneeid.ClientID %>").val(0);
                        $.ajax({
                            url: "Inquiry.aspx/GetLikeCustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2],
                                        text: item.split('~')[3]
                                    }
                                }))

                            },

                            error: function (response) {
                                // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_consigneemulti.ClientID %>").val(i.item.text);
                        $("#<%=hdn_Consigneeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_consignee.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_consigneemulti.ClientID %>").val(i.item.text);
                        $("#<%=hdn_Consigneeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_consignee.ClientID %>").val($.trim(result));

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_consigneemulti.ClientID %>").val(i.item.text);
                            $("#<%=hdn_Consigneeid.ClientID %>").val(i.item.val);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_consignee.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(res));
                        }
                    },
                    minLength: 1

                });
            });

           <%-- $("#<%= txtDate.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val;
            $("#<%= txtValidTill.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val;--%>
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }

    </script>
    <%--<div class="div_Label"><asp:Label ID="Label1" runat="server" Text="Product " CssClass="LabelValue"></asp:Label></div>--%>

    <style type="text/css">
        .TermsTxtBox {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .ShippInputbox {
            width: 50.5%;
            float: left;
            margin: 0px .5% 0px 0px;
        }

        .ShippInputbox_2 {
            width: 40.5%;
            float: left;
            margin: 0px .5% 0px 0px;
        }

        .ShippInputbox1 {
            width: 50%;
            float: left;
            margin: 0px .5% 0px 0px;
        }

        .ShippInputbox2 {
            width: 50%;
            float: left;
            margin: 0px .5% 0px 0px;
        }

        .ConAdd {
            float: left;
            width: 49%;
            margin: 0px 0px 0px 0px;
        }

        a#logix_CPH_LinkButton1 {
            color: maroon;
            font-weight: bold;
            /* text-decoration: line-through; */
        }

        .Remarks {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .Cargo {
            width: 21.5%;
            float: left;
            margin: 0px .5% 0px 0px;
        }

        .ControlledBy {
            width: 40%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .chzn-container {
            width: 100% !important;
        }

        .Volumetxt {
            width: 13.5%;
            float: left;
            margin: 0px .5% 0px 0px;
        }

        .Value {
            width: 17.3%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .M35 {
            margin: -39px 0px 0px 0px !important;
        }

        .Routing {
            width: 11.3%;
            float: left;
            margin: 0px .3% 0px 0px;
        }

        .Datelbl {
            width: 4%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Transit {
            width: 11%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .ConsignInput {
            width: 40.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .ConsignInput1 {
            width: 49%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .ConsignInput2 {
            width: 49%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .Terms {
            width: 100%;
            text-align: left;
            white-space: pre-line;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        textarea#logix_CPH_txtterms {
            height: 68px !important;
            color: #4e4c4c;
            overflow: auto !important;
        }

        .formdropdownboxFs {
            float: left;
            width: 10%;
            margin: 0px 0.5% 0px 0%;
            font-size: 11px;
            color: #000080;
        }

        .IncoInput {
            width: 22%;
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .IncoInput2 {
            width: 8.2%;
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Cartonstxt {
            width: 8.3%;
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DimensionstxtNew {
            width: 6.5%;
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Dimensionstxt {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        span.chktext {
            font-weight: 500 !important;
            margin: -9px 0 0 0px !important;
            padding: 0px 0px 0px 0px;
            font-size: 13px !important;
        }

        .TxtRemarks2 {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Volume {
            width: 9.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        div#logix_CPH_ddl_moveTypes_chzn {
            width: 100% !important;
        }

        .grdQuotationheader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .grdQuotationheader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .grdQuotationheader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 73px;
                overflow-x: hidden;
                overflow-y: auto;
            }

            .grdQuotationheader th {
                min-width: 140px;
            }

            .grdQuotationheader td {
                min-width: 140px;
            }

            .grdQuotationheader th:nth-child(1) {
                min-width: 250px;
            }

            .grdQuotationheader td:nth-child(1) {
                min-width: 250px;
            }

            .grdQuotationheader th:nth-child(2) {
                min-width: 50px;
            }

            .grdQuotationheader td:nth-child(2) {
                min-width: 50px;
            }

            .grdQuotationheader th:nth-child(3) {
                min-width: 60px;
            }

            .grdQuotationheader td:nth-child(3) {
                min-width: 60px;
            }

            .grdQuotationheader th:nth-child(4) {
                min-width: 60px;
            }

            .grdQuotationheader td:nth-child(4) {
                min-width: 60px;
            }

            .grdQuotationheader th:nth-child(5) {
                min-width: 60px;
            }

            .grdQuotationheader td:nth-child(5) {
                min-width: 60px;
            }

            .grdQuotationheader th:nth-child(6) {
                min-width: 60px;
            }

            .grdQuotationheader td:nth-child(6) {
                min-width: 60px;
            }

            .grdQuotationheader th:nth-child(7) {
                min-width: 84px;
            }

            .grdQuotationheader td:nth-child(7) {
                min-width: 84px;
            }

        .Sticky-top thead {
            position: sticky;
            top: -1px;
        }

        .testfixed {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            .testfixed thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .testfixed tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 68px;
                overflow-x: hidden;
                overflow-y: auto;
            }

            .testfixed th {
                min-width: 140px;
            }

            .testfixed td {
                min-width: 140px;
            }

            .testfixed th:nth-child(1) {
                min-width: 155px;
            }

            .testfixed td:nth-child(1) {
                min-width: 155px;
            }

            .testfixed th:nth-child(2) {
                min-width: 80px;
            }

            .testfixed td:nth-child(2) {
                min-width: 80px;
            }

        .Quotation {
            float: right;
            width: 37.6%;
            overflow: hidden;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Quotationdt {
            float: left;
            width: 19%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .leftdiv {
            float: left;
            width: 50%;
            margin: 0px 0px 0px 0px;
        }

        .rightdiv {
            float: left;
            width: 20%;
            margin: 0px 0px 0px 0px;
        }

        .ProductLbl {
            width: 6%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Retention {
            width: 4.5%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Quotationsellgrid.boxmodal {
            width: 65%;
        }

        .EXRatelbl {
            width: 4%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .EXRate {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .baselbl {
            width: 5%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Chargeslbl {
            width: 7.6%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Currlbl {
            width: 3%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Salespersontxt {
            width: 41%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .containers {
            width: 13.5%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Scope {
            width: 4%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Receipt {
            width: 9.5%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Receipt2 {
            width: 6.5%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .PortDischarge {
            width: 10.3%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Gross {
            width: 10.4%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Dimensions {
            width: 7%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Consignee {
            width: 7%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Enqdate {
            width: 10.2%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Quotationlbl {
            width: 4%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Termslnk {
            width: 2.8%;
            text-align: left;
            float: left;
            color: #000080;
            margin: -11px 5px 0px 5px;
        }

        .PreparedBy {
            width: 30%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Versionlbl {
            width: 5%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Versiondrop {
            float: left;
            width: 19.5%;
            margin: 0px 0.5% 0px 0px;
        }

        div#logix_CPH_ddl_version_chzn {
            width: 100% !important;
        }

        .DatelblShippInputbox2 {
            width: 4%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .M99 {
            margin: 0px 7.5% 0px 99px !important;
        }

        .Dischargetxt {
            float: left;
            width: 14.4%;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Dischargetxt2 {
            float: left;
            width: 25%;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }


        .Routingtxt {
            float: left;
            width: 19.5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .Transittxt {
            float: left;
            width: 9.5%;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
        }

        .Totaldaystxt {
            width: 6.4%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 3px 0px 0px 0px;
        }

        .Dischargetxt3 {
            float: left;
            width: 23.3%;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        div#logix_CPH_ddl_feasi_chzn {
            width: 100% !important;
        }

        .Receipt3 {
            width: 10.1%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 0px 0px 0px 0px;
        }

        .ReceiptFes {
            width: 5%;
            text-align: left;
            float: left;
            color: #000080;
            margin: 0px 0.5% 0px 0px;
        }

        .pnlChargeCss {
            height: 170px;
            border: 1px solid #999997;
            float: left;
            width: 100%;
            margin-top: .2%;
            overflow-y: scroll !important;
            overflow-x: auto !important;
            margin-bottom: .5%;
        }



        /*.approvedby {
            display: flex;
            align-items: center;
            justify-content: flex-start;
        }*/

        .CargoNew {
            width: 24.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Cartons {
            width: 9.2%;
            text-align: left;
            float: left;
            margin: 3px 0px 0px 0px;
        }



        .FixedButtonsss {
            position: fixed;
            top: 30px;
            left: 0;
            background: #fff;
            z-index: 10;
            box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
            width: calc(100vw - 5px);
            border-bottom: 0.5px solid #00000010;
            padding: 1px 0 5px 10px;
        }

        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 45px !important;
        }

        .widget.box .widget-content {
            padding: 43px 5px 0 !important;
        }




        .btn {
            padding: 0;
            overflow: hidden !important;
            height: auto;
        }

        .ico-terms button {
            background: url(../Theme/assets/img/buttonIcon/active/terms-popup.png) no-repeat left top !important;
        }

        .ico-terms-popup {
            background: none !important;
        }

        a#logix_CPH_lnk_terms {
            width: 100%;
            color: #4e4e4e !important;
            font-weight: normal !important;
        }

        div#QuotLabel {
            float: left;
            width: 22%;
            margin-top: 16px;
        }

        div#GenQuotId {
            float: left;
            width: 9%;
            margin: 17px 0px 0px 0px;
        }

        div#BuyRateID {
            float: left;
            width: 42%;
            margin: 16px 0px 0px 0px;
        }

        div#RateLabel {
            float: left;
            width: 26%;
            margin: 17px 0px 0px 0px;
        }



        .salesper {
            float: left;
            width: 30%;
            margin: 0px 0.5% 0px 0px;
        }

        .custref {
            float: left;
            width: 16.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .txt_plod {
            float: left;
            width: 30%;
            margin: 0px 0px 0px 0px;
        }

        .txt_pod {
            float: left;
            width: 21.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .txt_pol {
            float: left;
            width: 25%;
            margin: 0px 0.5% 0px 0px;
        }

        .txt_por {
            float: left;
            width: 22%;
            margin: 0px 0.5% 0px 0px;
        }

        input#logix_CPH_RateLabel1 {
            color: var(--labelorange) !important;
        }

        input#logix_CPH_GenQuotBtn {
            color: var(--labelorange) !important;
        }

        .modalPopupss iframe {
            width: 100% !important;
            height: 91vh !important;
        }

        .preparedby.TextField {
            width: 28%;
            float: left;
        }

        a#logix_CPH_linkQuotation {
            float: right;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <div>
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblHeader" runat="server"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs" id="crumbs" runat="server">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li id="lbl_tran" runat="server" visible="false"><a href="#" title="" runat="server" id="HeaderLabel1">Ocean Exports</a> </li>
                                <li><a href="#" title="" id="HeaderLabel2" runat="server">Sales</a> </li>
                                <li class="current"><a href="#" title="" id="headerlabel" runat="server">Quotations</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>



                    <div class="FixedButtons">
    <div class="left_btn">
        <div class="btn ico-inquiry">
            <asp:Button ID="BuyRateBtn" runat="server" ToolTip="Buy Rate" Text="Buy Rate" Visible="false" OnClick="BuyRateBtn_Click" />

        </div>
        <div id="GenBtnId" class="btn ico-Amend-MBL ">
            <asp:Button ID="GenBtn" runat="server" ToolTip="Gen Quot" Text="Gen Quot" Visible="true" OnClick="GenBtn_Click" />
        </div>

    </div>



    <div class="right_btn">
        <div class="btn ico-reuse">
            <asp:Button ID="Btn_reuse" runat="server" ToolTip="Reuse" Text="Reuse" OnClick="Btn_reuse_Click" />
        </div>
        <div class="btn ico-save" id="btn_save" runat="server">
            <asp:Button ID="btnSave" runat="server" ToolTip="Save" Text="Save" Enabled="false" TabIndex="34" OnClick="btnSave_Click" />
        </div>

        <div class="btn ico-view  hide">
            <asp:Button ID="btnView" runat="server" ToolTip="View" Text="View" TabIndex="35" OnClick="btnView_Click" />
        </div>
        <div class="btn ico-delete " id="btn_app1" runat="server" visible="false">
            <asp:Button ID="btnApp" runat="server" ToolTip="Delete" Text="Delete" TabIndex="36" OnClick="btnApp_Click" Visible="false" />
        </div>

        <div class="btn ico-approve hide" runat="server">
            <asp:Button ID="btn_approve" runat="server" Enabled="false" Text="Approve" ToolTip="Approve" TabIndex="37" OnClick="btn_approve_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_back1" runat="server">
            <asp:Button ID="btnclose" runat="server" ToolTip="Cancel" Text="Cancel" TabIndex="38" OnClick="btnclose_Click" />
        </div>

    </div>
</div>


                    </div>
                <div class="widget-content">

                    <div class="FormGroupContent4">


                        
                        <div class="">
                            <div class="FormGroupContent4">
                                <div class="right_btn" style="width: 21.6%;">


                                    <div class="DateandYr">
                                        <span>Date</span>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate"></ajaxtoolkit:CalendarExtender>
                                    </div>
                                    <asp:LinkButton ID="linkQuotation" CssClass="anc ico-find-sm" runat="server" OnClick="linkQuotation_Click"></asp:LinkButton>

                                    <div class="Quotation">
                                        <span>Inquiry #</span>

                                        <asp:TextBox ID="txtQuotation" runat="server" OnTextChanged="txtQuotation_TextChanged" CssClass="form-control" TabIndex="2"
                                            AutoPostBack="True"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <div class="bordertopNew" style="float: right; min-height: 1px; width: 20.8%; box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;"></div>

                                </div>
                            </div>
                        </div>
                        <div class="QuoteLeft">
                            <div class="FormGroupContent4">



                                <div class="formdropdownbox  fit-content">
                                    <asp:Label ID="Label3" runat="server" Text="Product"></asp:Label>
                                    <asp:DropDownList ID="ddl_product" runat="server" Width="100%" CssClass="chzn-select" data-placeholder="Product" TabIndex="1" ToolTip="Product" AutoPostBack="True" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="GrossTxt">
                                    <span class="chktext">Cross Trade</span>

                                    <asp:CheckBox ID="Gross_country" runat="server" OnCheckedChanged="Gross_country_CheckedChanged"></asp:CheckBox>

                                </div>
                                <div class="custref">
                                    <asp:Label ID="Label34" runat="server" Text="Customer Ref #"></asp:Label>

                                    <asp:TextBox ID="txt_custpono" runat="server" CssClass="form-control" TabIndex="14" ToolTip="Customer Ref #" PlaceHolder=" " AutoPostBack="True" OnTextChanged="txt_custpono_TextChanged" onkeyup="nospaces(this)"></asp:TextBox>
                                </div>

                                <div class="salesper">
                                    <span>Salesperson</span>
                                    <asp:TextBox ID="txtSalesPerson" runat="server" ToolTip="SALESPERSON" PlaceHolder="Salesperson " CssClass="form-control" AutoPostBack="True" OnTextChanged="txtSalesPerson_TextChanged"></asp:TextBox>
                                </div>
                                <div class="preparedby">
                                    <asp:Label Text="Updated By " ID="preBy" runat="server"></asp:Label>

                                    <asp:TextBox ID="txtPreparedBy" runat="server" CssClass="form-control" BorderWidth="1" Width="100%" Enabled="false" ToolTip="Updated By" PlaceHolder=""></asp:TextBox>
                                </div>






                            </div>
                            <div class="FormGroupContent4">
                                <div class="FormGroupContent4">
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="CalendarBG" style="display: none;">
                                        <span>Valid Till</span>
                                        <asp:TextBox ID="txtValidTill" runat="server" CssClass="form-control" ToolTip="Valid Till"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtValidTill"></ajaxtoolkit:CalendarExtender>
                                    </div>




                                </div>
                                <div class="Quotationlbl" style="display: none;">
                                    <asp:Label ID="Label16" runat="server" Text="Salesperson"></asp:Label>
                                </div>

                                <div class="FormGroupContent4 hide">

                                    <div class="ControlledBy  ">
                                        <span>Controlled By</span>
                                        <asp:DropDownList ID="ddl_controlledby" Height="25" TabIndex="31" runat="server" data-placeholder="Controlled By" CssClass="chzn-select" ToolTip="Controlled By">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                            <asp:ListItem Value="A">Agent Controlled </asp:ListItem>
                                            <asp:ListItem Value="O">Controlled By Us </asp:ListItem>

                                        </asp:DropDownList>
                                    </div>


                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal hide">

                                <div class="Quotationdt">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label20" runat="server" Text="Enquiry Date"></asp:Label>
                                        <asp:TextBox ID="txt_enquiry" runat="server" ToolTip="Enquiry Date" CssClass="form-control" TabIndex="3" PlaceHolder=""
                                            AutoPostBack="True"></asp:TextBox>
                                        <%-- <cc1:CalendarExtender ID="calender" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_enquiry"></cc1:CalendarExtender>--%>
                                        <ajaxtoolkit:CalendarExtender ID="Calendarextender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_enquiry"></ajaxtoolkit:CalendarExtender>

                                    </div>
                                </div>
                                <%--   <div class="PrepareTxt"></div>--%>
                            </div>

                            <div class="FormGroupContent4">
                                <%-- commented by praveen 2023-May-12 to insert find icon --%>
                                <%--<asp:LinkButton ID="linkQuotation" CssClass="boxmodalLink" runat="server" OnClick="linkQuotation_Click">Quot #</asp:LinkButton>--%>

                                <div class="Versiondrop hide">
                                    <span>Version</span>
                                    <asp:DropDownList ID="ddl_version" runat="server" TabIndex="4" Width="100%" AutoPostBack="True" CssClass="chzn-select" data-placeholder="Version" ToolTip="Version" OnSelectedIndexChanged="ddl_version_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <%--<div class="QDate"></div>--%>

                                <%--  <div class="FormtxtLabel ML5">
     
     </div>--%>
                                <div class="Valid" style="display: none;">
                                    <asp:Label ID="lblValidTill" runat="server" Text="Valid Till"></asp:Label>
                                </div>
                            </div>

                            <div class="FormGroupContent4 boxmodal">

                                <div class="FormGroupContent4">
                                    <div class=" Address">
                                        <div class="FormGroupContent4">
                                            <div class="FormInput2 ">
                                                <asp:Label ID="Label6" runat="server" Text="Customer"></asp:Label>
                                                <asp:TextBox ID="txtCustomer" runat="server"
                                                    CssClass="form-control" ToolTip="CUSTOMER" PlaceHolder=" " TabIndex="6" OnTextChanged="txtCustomer_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                            <%--<asp:LinkButton ID="lnk_credit" CssClass="anc ico-info-sm" runat="server" OnClick="lnk_credit_Click"></asp:LinkButton>--%>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <span>Address</span>
                                            <asp:TextBox ID="txtaddress" runat="server" ToolTip="Address" placeholder="" TextMode="MultiLine" Rows="1" Style="resize: none;" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="FormGroupContent4 hide">
                                    <div class="Address">
                                        <div class="FormGroupContent4">

                                            <div class="FormGroupContent4 ">
                                                <asp:Label ID="Label29" runat="server" Text="Carrier"></asp:Label>

                                                <asp:TextBox ID="txtCarrier" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" TabIndex="7" ToolTip="Carrier" OnTextChanged="txtCarrier_TextChanged1"></asp:TextBox>
                                                <%--OnTextChanged="txtCarrier_TextChanged"--%>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent4">

                                            <span>Address</span>

                                            <asp:TextBox ID="TextBox1" runat="server" ToolTip="Address" placeholder="" TextMode="MultiLine" Rows="1" Style="resize: none;" ReadOnly="true" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>

                                <div class="FormGroupContent4 hide">
                                    <div class="Address">

                                        <div class=" FormGroupContent4">
                                            <asp:Label ID="Label30" runat="server" Text="Shipper"></asp:Label>

                                            <asp:TextBox ID="txt_shiper" runat="server" ToolTip="Shipper" AutoPostBack="true" PlaceHolder=" " OnTextChanged="txt_shiper_TextChanged" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                        </div>
                                        <div class=" FormGroupContent4">
                                            <span>Shipper Address</span>
                                            <asp:TextBox ID="txt_shipermulti" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1" Style="resize: none;" ToolTip="Shipper Address" placeholder="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <%-- OnTextChanged="txt_shiper_TextChanged"--%>
                                    </div>
                                    <%-- OnTextChanged="txt_consignee_TextChanged"--%>
                                </div>

                                <div class="FormGroupContent4">
                                    <div class="Address">
                                        <div class=" FormGroupContent4 hide">
                                            <asp:Label ID="Label31" runat="server" Text="Consignee"></asp:Label>

                                            <asp:TextBox ID="txt_consignee" runat="server" ToolTip="Consignee" AutoPostBack="true" PlaceHolder=" " TabIndex="9" CssClass="form-control" OnTextChanged="txt_consignee_TextChanged"></asp:TextBox>
                                        </div>

                                        <div class="FormGroupContent4 hide">

                                            <span>Consignee Address</span>

                                            <asp:TextBox ID="txt_consigneemulti" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1" Style="resize: none;" ToolTip="Consignee Address" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=" FormGroupContent4">
                                <div class="txt_por">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label12" runat="server" CssClass="normalsize" Text="Place of Receipt "></asp:Label>
                                        <asp:TextBox ID="txtPOR" runat="server" TabIndex="10" ToolTip="PLACE OF RECEIPT" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" OnTextChanged="txtPOR_TextChanged"></asp:TextBox>
                                    </div>
                                    <asp:Image ID="porflag" runat="server" Width="100%" />
                                </div>
                                <div class="txt_pol">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label13" runat="server" Text="Port of Loading"></asp:Label>
                                        <asp:TextBox ID="txtPOL" runat="server" TabIndex="11" ToolTip="PORT OF LOADING" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" OnTextChanged="txtPOL_TextChanged"></asp:TextBox>
                                    </div>
                                    <asp:Image ID="flagimg" runat="server" Width="100%" />
                                </div>
                                <div class="txt_pod">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label14" runat="server" Text="Port of Discharge"></asp:Label>
                                        <asp:TextBox ID="txtPOD" runat="server" TabIndex="12" ToolTip="PORT OF DISCHARGE" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" Width="100%" OnTextChanged="txtPOD_TextChanged"></asp:TextBox>
                                    </div>
                                    <asp:Image ID="podflag" runat="server" Width="100%" />
                                </div>
                                <div class="txt_plod">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label15" runat="server" Text="Place of Delivery"></asp:Label>
                                        <asp:TextBox ID="txtFD" runat="server" TabIndex="13" ToolTip="Place of Delivery" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" OnTextChanged="txtFD_TextChanged"></asp:TextBox>
                                    </div>
                                    <asp:Image ID="fdflag" runat="server" Width="100%" />
                                </div>



                            </div>


                            <div class="FormGroupContent4">
                            </div>

                            <div class="FormGroupContent4">
                            </div>

                            <div class="FormGroupContent4">
                            </div>
                            <div class="FormGroupContent4">
                            </div>
                            <div class="FormGroupContent4">
                                <div class="commodity" style="width: 22%;">
                                    <asp:Label ID="Label11" runat="server" Text="Commodity "></asp:Label>

                                    <asp:TextBox ID="txtCargo" runat="server" CssClass="form-control" TabIndex="15" ToolTip="CARGO" PlaceHolder=" " AutoPostBack="True" OnTextChanged="txtCargo_TextChanged"></asp:TextBox>
                                </div>
                                <div class="commodity" style="width: 47%;">
                                    <asp:Label ID="Label10" runat="server" Text="Cargo Description"></asp:Label>

                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" ToolTip="CARGO DESCRIPTION" AutoPostBack="True" TabIndex="16" Width="100%" PlaceHolder=" "></asp:TextBox>
                                </div>
                                <div class="Shipment_value">
                                    <asp:Label ID="Label36" runat="server" Text="Shipment Value"></asp:Label>
                                    <asp:TextBox ID="txt_value" runat="server" CssClass="form-control" ToolTip="Shipment Value" AutoPostBack="True" TabIndex="17" Width="100%" PlaceHolder=" "></asp:TextBox>
                                </div>


                                <div class="ChkboxDisplay">
                                    <asp:Label ID="Label2" CssClass="chktext" runat="server" Text="Hazardous"></asp:Label>
                                    <center>
                                        <label class="switch">
                                            <asp:CheckBox ID="chkHazard" runat="server" />


                                        </label>
                                    </center>

                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal">
                            </div>

                            <div class="FormGroupContent4">
                                <div class="IncoInput  ">
                                    <asp:Label ID="Label28" runat="server" Text="Inco"></asp:Label>
                                    <asp:TextBox ID="txtInco" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="INCO" PlaceHolder=" " TabIndex="18"></asp:TextBox>
                                    <%-- OnTextChanged="txtInco_TextChanged"--%>
                                </div>

                                <div class="IncoImg">
                                    <div class="box">
                                        <a class="btnInco button" href="#popup1" title="INCO Terms 2016 Rules"></a><%-- --%>
                                    </div>
                                </div>


                                <div class="Freight ">
                                    <span>Freight</span>
                                    <asp:DropDownList ID="ddlFreight" runat="server" Width="100%" TabIndex="19" CssClass="chzn-select" data-placeholder="Freight" ToolTip="Freight" AutoPostBack="True">
                                        <asp:ListItem Text=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="Cargo   ">
                                    <span>Shipment</span>
                                    <asp:DropDownList ID="ddlShipment" runat="server" TabIndex="20" CssClass="chzn-select" Width="100%" data-placeholder="Shipment" AutoPostBack="true" ToolTip="Shipment" OnSelectedIndexChanged="ddlShipment_SelectedIndexChanged">
                                        <asp:ListItem Text=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="CargoNew  ">
                                    <span>Scope</span>

                                    <asp:DropDownList ID="ddl_moveTypes" Height="25" TabIndex="21" runat="server" data-placeholder="Scope" CssClass="chzn-select" ToolTip="Scope">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="CFS/CFS" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="CFS/CY" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="CY/CRS" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="CY/CY" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="CY/DOOR" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="DOOR/CY" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="DOOR/DOOR" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="CY/CFS" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="CY/HK" Value="9"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="Value ">
                                    <asp:Label ID="Label5" runat="server" Text="Free Days"></asp:Label>

                                    <asp:TextBox ID="txt_totdays" runat="server" CssClass="form-control" ToolTip="Free Days" AutoPostBack="True" TabIndex="24" Width="100%" PlaceHolder="" OnTextChanged="txt_totdays_TextChanged"></asp:TextBox>
                                </div>


                            </div>
                            <div class="FormGroupContent4">

                                <div class="Routingtxt hide">
                                    <asp:Label ID="Label37" runat="server" Text="Routing"></asp:Label>

                                    <asp:TextBox ID="txt_routing" runat="server" CssClass="form-control" ToolTip="Routing" AutoPostBack="True" TabIndex="22" Width="100%" PlaceHolder=""></asp:TextBox>
                                </div>




                                <div class="FormInputbox3" style="display: none">
                                    <asp:Label ID="Label18" runat="server" Text="Brokrage"></asp:Label>
                                    <asp:TextBox ID="txtBrokerage" runat="server" ToolTip="BROKRAGE" PlaceHolder="" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                </div>




                                <div class="Transittxt hide ">
                                    <asp:Label ID="Label38" runat="server" Text="Transit Time"></asp:Label>

                                    <asp:TextBox ID="txt_transittime" runat="server" CssClass="form-control" ToolTip="Transit Time" AutoPostBack="True" TabIndex="23" Width="100%" PlaceHolder="" OnTextChanged="txt_transittime_TextChanged"></asp:TextBox>
                                </div>

                                <div class="Remarks ">
                                    <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>

                                    <asp:TextBox ID="txtRemarks" runat="server" Style="resize: none;" Width="100%" TabIndex="33" ToolTip="REMARKS" PlaceHolder=" " CssClass="form-control"></asp:TextBox>
                                </div>


                            </div>
                            <div class="FormGroupContent4">




                                <div class="FormGroupContent4" style="display: none;">

                                    <div class="Terms ">
                                        <asp:Label ID="Terms" runat="server" Text="Terms"></asp:Label>
                                        <asp:TextBox ID="txtterms" runat="server" Width="100%" ToolTip="Terms" PlaceHolder=" " TextMode="MultiLine" Rows="1" Style="resize: none;" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="FormGroupContent4 hide">

                                    <div class="txt_pieces ">
                                        <asp:Label ID="Label40" runat="server" Text="Pieces"></asp:Label>

                                        <asp:TextBox ID="txt_pieces" runat="server" Style="resize: none;" Width="100%" TabIndex="25" ToolTip="Pieces" PlaceHolder="" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="Cartonstxt">
                                        <asp:Label ID="Label39" runat="server" Text="No. of Cartons"></asp:Label>

                                        <asp:TextBox ID="txt_units" runat="server" Style="resize: none;" Width="100%" TabIndex="26" ToolTip="No. of Cartons" PlaceHolder="" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="DimensionstxtNew">
                                        <asp:Label ID="Label41" runat="server" Text="CBM (M3)"></asp:Label>

                                        <asp:TextBox ID="txt_volume" runat="server" Style="resize: none;" Width="100%" TabIndex="27" ToolTip="CBM (M3)" PlaceHolder="" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="IncoInput2">
                                        <asp:Label ID="Label42" runat="server" Text="Gr. Wt. (KGS)"></asp:Label>
                                        <asp:TextBox ID="txt_grwt" runat="server" Style="resize: none;" Width="100%" TabIndex="28" ToolTip="Gross Weight (KGS)" PlaceHolder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="containers" style="display: none;">
                                        <asp:Label ID="Label43" runat="server" Text="Type & No of containers"></asp:Label>
                                    </div>
                                    <div class="TxtRemarks3" style="display: none;">

                                        <asp:TextBox ID="txt_noofcont" runat="server" Style="resize: none;" Width="100%" TabIndex="29" ToolTip="Type & No of containers" PlaceHolder="" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="Dimensionstxt">
                                        <asp:Label ID="Label44" runat="server" Text="Dimensions"></asp:Label>

                                        <asp:TextBox ID="txt_dim" runat="server" Style="resize: none;" Width="100%" TabIndex="30" ToolTip="Dimensions" PlaceHolder="" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <%-- <div class="Formradbutton">
                           <label class="radio-inline ">
                          <asp:RadioButton ID="rdbagent" runat ="server" TabIndex="17"  CssClass="uniform" AutoPostBack="True" oncheckedchanged="rdbagent_CheckedChanged" />
                          <asp:Label ID="lblAgent" runat="server" Text="Agent Controlled" CssClass="LabelValue"></asp:Label></label>
                            <label class="radio-inline MArCtrl ">
                                <asp:RadioButton ID="rdbBussiness" CssClass="uniform"  runat ="server" 
        TabIndex="18" AutoPostBack="True" 
        oncheckedchanged="rdbBussiness_CheckedChanged" />
                                <asp:Label ID="lblbus" runat="server" Text="Controlled By Us"></asp:Label>
                                </label>
                          </div>--%>
                                </div>


                                <div class="FormGroupContent4">
                                    <div class="ReceiptFes hide">
                                        <span>Feasibility</span>

                                        <asp:DropDownList ID="ddl_feasi" runat="server" TabIndex="32" Width="100%" AutoPostBack="True" CssClass="chzn-select" data-placeholder="Feasibility" ToolTip="Feasibility">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="N"></asp:ListItem>

                                        </asp:DropDownList>
                                    </div>





                                </div>
                            </div>



                            <%--  --%>

                            <div class="FormGroupContent4" style="display: none">
                                <div class="Receipt">
                                    <label>
                                        <span class="required">
                                            <asp:LinkButton ID="linkBuying" runat="server" OnClick="linkBuying_Click">Buy Rate #</asp:LinkButton></span></label>

                                </div>
                                <div class="IncoInput ">

                                    <asp:TextBox ID="txtBuying" runat="server" ReadOnly="true" CssClass="form-control" AutoPostBack="True" Width="100%"></asp:TextBox>
                                </div>

                                <div class="FormInput4 ">
                                    <asp:TextBox ID="txtBuyingDetails" runat="server" Width="100%" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="QuoteRight">




                            <div class="FormGroupContent4">
                                <div id="BuyRateID">
                                    <asp:Label Text="Buy Rate Ref # " ID="BRId" runat="server"></asp:Label>
                                </div>
                                <div id="RateLabel">
                                    <asp:Button ID="RateLabel1" runat="server" ToolTip="" Text="" TabIndex="38" OnClick="RateId_TextChanged" />
                                    <%--<asp:Label ID="RateLabel1" runat="server" Text="" OnClick="RateId_TextChanged"></asp:Label>--%>
                                </div>

                                <div id="QuotLabel">
                                    <asp:Label Text="Quot # " ID="GQId" runat="server"></asp:Label>
                                </div>
                                <div id="GenQuotId">
                                    <asp:Button ID="GenQuotBtn" runat="server" ToolTip="" Text="" TabIndex="38" OnClick="GenQuotBtn_Click" />
                                    <%--<asp:Label ID="RateLabel1" runat="server" Text="" OnClick="RateId_TextChanged"></asp:Label>--%>
                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal">

                                <div class="FormGroupContent4 hide">
                                    <asp:Label ID="Label7" runat="server" Text="Credit Group Customer" Visible="true"></asp:Label>
                                    <asp:TextBox ID="txtgroupcustomer" runat="server" ToolTip="Credit Group Customer" placeholder="Credit Group Customer" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="FormGroupContent4 TextArea hide">
                                    <span>Credit Group Customer Address</span>
                                    <asp:TextBox ID="txtgroupAddress" runat="server" ToolTip="Credit Group Customer Address" TextMode="MultiLine" Rows="1" Style="resize: none;" placeholder=" " Enabled="false" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--<div class="FormGroupContent4">

                                    <asp:Panel ID="Gridcont" runat="server" Visible="true" CssClass="relative">
                                        <asp:GridView ID="test" runat="server" CssClass="Grid FixedHeader" OnPreRender="test_PreRender">
                                           
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>--%>
                            </div>

                            <div class="FormGroupContent4 boxmodal">

                                <div class="SeaRight" id="SearightNew" runat="server">
                                    <div class="FormGroupContent4">
                                        <asp:Panel ID="Panel7" runat="server" CssClass="gridpnl">
                                            <asp:GridView ID="grd_Sizetype" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                                ShowHeaderWhenEmpty="True" EnableTheming="true" OnPreRender="grd_Sizetype_PreRender">
                                                <Columns>

                                                    <asp:TemplateField HeaderStyle-ForeColor="White" HeaderText="Select">
                                                        <ItemTemplate>
                                                            <span>
                                                                <asp:CheckBox ID="checksbno" runat="server" Enabled="true" />
                                                            </span>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="conttype" HeaderText="Size">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_Sizecount" runat="server" BorderColor="White" Text='<%#Bind("txt_Sizecount") %>' Font-Size="10pt" MaxLength="10" AutoPostBack="true" OnTextChanged="txt_Sizecount_TextChanged"
                                                                Style="text-align: right; width: 55px; height: 17px;"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle />
                                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                <RowStyle CssClass="GrdRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- <div class="FormInput1 ">
                        <div class="RemarksLeft">
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label27" runat="server" Text="Terms"></asp:Label>
                      <div class="RemarksTxtBox"><asp:TextBox ID="txtterms" runat="server" TextMode="MultiLine" Rows="3"  Width="100%" TabIndex="19" ToolTip="Terms" PlaceHolder=" "  CssClass="form-control"></asp:TextBox></div>
                      </div>

                                         </div>

                </div>--%>
                    <div class="divleft">





                        <div class="FormGroupContent4 boxmodal hide">

                            <div class="FormInput5txtcharges ">
                                <asp:Label ID="Label22" runat="server" Text="Charges"></asp:Label>

                                <asp:TextBox ID="txtCharges" runat="server" Width="100%" TabIndex="39" ToolTip="QUOTATION CHARGES" PlaceHolder=" " CssClass="form-control" OnTextChanged="txtCharges_TextChanged" AutoPostBack="false"></asp:TextBox>
                            </div>

                            <div class="FormInput6 " style="width: 4%">
                                <asp:Label ID="Label23" runat="server" Text="Curr "></asp:Label>

                                <asp:TextBox ID="txtCurr" runat="server" TabIndex="40" Width="100%" ToolTip="CURRENCY" PlaceHolder=" " MaxLength="3" CssClass="form-control" AutoPostBack="false" OnTextChanged="txtCurr_TextChanged"></asp:TextBox>
                            </div>

                            <div class="FormInput6 " style="display: none">
                                <asp:Label ID="Label47" runat="server" Text="Curr "></asp:Label>
                                <asp:TextBox ID="txtRate" runat="server" TabIndex="41" Width="100%" ToolTip="CURRENCY" PlaceHolder=" " MaxLength="3" CssClass="form-control" AutoPostBack="false"></asp:TextBox>
                            </div>



                            <div class="formdropdownboxbase ">
                                <asp:Label ID="Label25" runat="server" Text="UoM "></asp:Label>

                                <asp:DropDownList ID="ddlBase" runat="server" TabIndex="42" Width="100%" AutoPostBack="True" CssClass="chzn-select" data-placeholder="Base/Unit" ToolTip="Base/Unit" OnSelectedIndexChanged="ddlBase_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="FormInput6 " style="width: 4%;">
                                <asp:Label ID="Label48" runat="server" Text="Qty"></asp:Label>
                                <asp:TextBox ID="txtqty" runat="server" TabIndex="43" Width="100%" ToolTip="Qty" PlaceHolder=" " MaxLength="3" CssClass="form-control" AutoPostBack="false"></asp:TextBox>
                            </div>
                            <div class="EXRate">
                                <asp:Label ID="Rate" runat="server" Text="Ex Rate"></asp:Label>

                                <asp:TextBox ID="txtex" runat="server" ToolTip="Ex Rate" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="44" OnTextChanged="txtex_TextChanged" onkeypress='return validateQty(this,event);'></asp:TextBox>
                            </div>

                            <div class="FormInput6 " style="text-align: right">
                                <asp:Label ID="Label26" runat="server" Text="Buy"></asp:Label>

                                <asp:TextBox ID="txt_buyrate" Style="text-align: right;" runat="server" TabIndex="45" Width="100%" ToolTip="Buy Rate" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_buyrate_TextChanged" onkeypress='return validateQty(this,event);'></asp:TextBox>
                            </div>

                            <div class="FormInput6 " style="text-align: right; width: 6%">
                                <asp:Label ID="Label24" runat="server" Text="Margin %"></asp:Label>
                                <asp:TextBox ID="txt_margin" Style="text-align: right;" runat="server" TabIndex="46" Width="100%" ToolTip="Margin %" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_margin_TextChanged" onkeypress='return validateQty(this,event);'></asp:TextBox>
                            </div>

                            <div class="FormInput6 " style="text-align: right">
                                <asp:Label ID="Label45" runat="server" Text="Sell"></asp:Label>
                                <asp:TextBox ID="txt_sellrate" Style="text-align: right;" runat="server" TabIndex="47" Width="100%" ToolTip="Sell Rate" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_sellrate_TextChanged" onkeypress='return validateQty(this,event);'></asp:TextBox>
                            </div>

                            <div class="FormInput6 " style="text-align: right; width: 7%">
                                <asp:Label ID="Label46" runat="server" Text="Profit"></asp:Label>
                                <asp:TextBox ID="txt_retention" Style="text-align: right;" runat="server" TabIndex="48" Width="100%" ToolTip="Retention" PlaceHolder=" " CssClass="form-control" AutoPostBack="True" onkeypress='return validateQty(this,event);' Enabled="false"></asp:TextBox>
                            </div>

                            <div class="AmoutnInputN2" style="display: none">
                                <asp:Label ID="Label8" runat="server" Text="Amount"></asp:Label>
                                <asp:TextBox ID="txtamount" runat="server" ToolTip="Amount" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="49" ReadOnly="true"></asp:TextBox>
                            </div>

                            <div class="btn ico-add" id="btn_add" runat="server">
                                <asp:Button ID="btnAdd" runat="server" ToolTip="Add" Text="Add" TabIndex="50" Height="24px" Width="100%" OnClick="btnAdd_Click" />
                            </div>
                        </div>

                        <div class="FormGroupContent4">
                            <div style="display: none">
                                <div class="QuotationGrid1">

                                    <asp:Label ID="Label9" runat="server" Text="Quotation Charges" CssClass="LabelValue "></asp:Label>

                                    <asp:Panel ID="Panel9" runat="server" CssClass="div_GridBying1" ScrollBars="Auto">
                                        <asp:GridView ID="grd_combinedcharges" CssClass="Grid FixedHeader" runat="server" ShowHeaderWhenEmpty="True"
                                            AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="grd_combinedcharges_RowDataBound1"
                                            OnSelectedIndexChanged="grd_combinedcharges_SelectedIndexChanged1">
                                            <Columns>

                                                <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                    <HeaderStyle Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="base" HeaderText="Base/Unit ">
                                                    <HeaderStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="curr" HeaderText="Curr">
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="buyrate" HeaderText="Buy Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="sellrate" HeaderText="Sell Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="reten" HeaderText="Retention" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />

                                            <RowStyle CssClass="GrdRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>

                            </div>

                            <div class="FormGroupContent4">
                                <div class="BuyingGrid hide">
                                    <asp:Label ID="Label17" runat="server" Text="Buy Rate Charges" CssClass="LabelValue "></asp:Label>
                                    <asp:Panel ID="Panel1" runat="server" CssClass="panel_10 MB0" ScrollBars="Auto">
                                        <asp:GridView ID="grdBuying" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%" ShowHeaderWhenEmpty="True" EnableTheming="False" OnPreRender="grdBuying_PreRender">
                                            <Columns>

                                                <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                    <HeaderStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="curr" HeaderText="Curr">
                                                    <HeaderStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1"><%-- HeaderStyle-CssClass="TxtAlign1"--%>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expqty" HeaderText="Quantity" ItemStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="base" HeaderText="Base/Unit ">
                                                    <HeaderStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="right" />
                                                </asp:BoundField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />

                                            <RowStyle CssClass="GrdRow" />
                                        </asp:GridView>

                                    </asp:Panel>
                                    <div class="TotalInputosdn" style="display: none">
                                        <asp:TextBox ID="txtbuygrid" runat="server" CssClass="form-control" ToolTip="Total" placeholder="Total" ReadOnly="true"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="QuotationGrid1 hide">
                                    <%--yuvaraj--%>

                                    <asp:Label ID="Label1" runat="server" Text="Sell Rate Charges" CssClass="LabelValue "></asp:Label>

                                    <asp:Panel ID="pnlCharge" runat="server" CssClass="panel_10" ScrollBars="Auto">
                                        <asp:GridView ID="grdQuotation" CssClass="Grid FixedHeader" runat="server" ShowHeaderWhenEmpty="True"
                                            AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="grdQuotation_RowDataBound"
                                            OnSelectedIndexChanged="grdQuotation_SelectedIndexChanged" OnPreRender="grdQuotation_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                    <HeaderStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="curr" HeaderText="Curr">
                                                    <HeaderStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1"><%-- HeaderStyle-CssClass="TxtAlign1"--%>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="expqty" HeaderText="Quantity" ItemStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="base" HeaderText="Base/Unit ">
                                                    <HeaderStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="right" />
                                                </asp:BoundField>

                                            </Columns>

                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />

                                            <RowStyle CssClass="GrdRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                    <div style="clear: both"></div>
                                    <div class="Expected_Retention" style="display: none">
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ToolTip="Total" placeholder="Total" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="Retention1">
                                        <asp:Label ID="Label32" runat="server" Text="Expected Retention (Sell Rate - Buy Rate)" CssClass="LabelValue "></asp:Label>

                                        <asp:TextBox ID="txtprofitamounts" runat="server" CssClass="form-control" ToolTip="Expected Retention" placeholder="" ReadOnly="true"></asp:TextBox>
                                    </div>

                                </div>

                                <%--yuvaraj 06/09/2022 Grid--%>
                                <div class="FormGroupContent4 boxmodal hide">
                                    <div class="Quotationsellgrid boxmodal">
                                        <asp:Label ID="Label35" runat="server" Style="display: none" Text="Buy/Sell Charges" CssClass="LabelValue "></asp:Label>
                                        <%-- <asp:Label ID="BuySellCharge" runat="server" Text="BuySellCharges" CssClass="LabelValue "></asp:Label>--%>
                                        <asp:Panel ID="Panel" runat="server" CssClass="" ScrollBars="Auto">
                                            <asp:GridView ID="GrdBuysellcharge" runat="server" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="GrdBuysellcharge_SelectedIndexChanged" OnPreRender="GrdBuysellcharge_PreRender" OnRowDataBound="GrdBuysellcharge_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                        <HeaderStyle Width="245px" />
                                                        <ItemStyle Width="245px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="curr" HeaderText="Curr">
                                                        <HeaderStyle Width="50px" />
                                                        <HeaderStyle Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="align-right"><%-- HeaderStyle-CssClass="TxtAlign1"--%>
                                                        <HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="hide" />
                                                        <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="expqty" HeaderText="Qty" ItemStyle-CssClass="TxtAlign1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="base" HeaderText="UoM">
                                                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle HorizontalAlign="Right" Width="90px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:#,##0.00}">
                                                        <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="align-right" />
                                                        <ItemStyle HorizontalAlign="Right" Width="90px" CssClass="align-right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="amount" HeaderText="Buy" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign2">
                                                        <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="align-right" />
                                                        <ItemStyle HorizontalAlign="right" Width="90px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="sell" HeaderText="sell" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign3">
                                                        <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="align-right" />
                                                        <ItemStyle HorizontalAlign="right" Width="90px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="retention" HeaderText="Profit" DataFormatString="{0:#,##0.00}">
                                                        <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="align-right" />
                                                        <ItemStyle HorizontalAlign="right" Width="90px" CssClass="align-right" />
                                                    </asp:BoundField>

                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />

                                                <RowStyle CssClass="GrdRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                        <div class="Expected_Retention" style="display: none">
                                            <asp:TextBox ID="txttot2" runat="server" CssClass="form-control" ToolTip="Total" placeholder="Total" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class=" FormGroupContent4 boxmodal hide" style="width: 65%">
                                    <div class="approvedby custom-mb-1">
                                        <asp:Label ID="Label33" runat="server" Text="Approved By" CssClass="form-control align-left "></asp:Label>
                                        <asp:TextBox ID="txtapprovedby" runat="server" CssClass="" ToolTip="Approved By" placeholder="Approved By" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="Retention1 custom-mb-1">
                                        <asp:Label ID="Label49" runat="server" Text="Profit" CssClass=""></asp:Label>
                                        <asp:TextBox ID="txtprofitamount" runat="server" CssClass="form-control" ToolTip="Expected Retention" placeholder="" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="Expecten1 custom-mb-1">
                                        <span>Sell</span>
                                        <asp:TextBox ID="txtselling" runat="server" CssClass="form-control" ToolTip="Sell" placeholder="Sell" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="Expected2">
                                        <span>Buy</span>
                                        <asp:TextBox ID="txtbuyings" runat="server" CssClass="form-control" ToolTip="Buy" placeholder="Buy" ReadOnly="true"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div class="FormGroupContent4 hide">
                                <div class="left_btn">
                                    <div class="btn ico-terms">
                                        <button>
                                            <asp:LinkButton ID="lnk_terms" CssClass="anc_lrg ico-terms-popup" ToolTip="Terms and Conditions" runat="server" OnClick="lnk_terms_Click"></asp:LinkButton>
                                        </button>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="FormGroupContent4">
                        <%---------------------------------------Buying----------------------------------------%>

                        <div class="FormGroupContent4">
                            <%---------------------------------------Popup Buying----------------------------------------%>

                            <asp:Label ID="lblAI" runat="server"></asp:Label>
                            <ajaxtoolkit:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
                                DropShadow="false" PopupControlID="pnlJobAE" PopupDragHandleControlID="grdBuyingDetails" CancelControlID="imgfgok">
                            </ajaxtoolkit:ModalPopupExtender>

                            <asp:Panel ID="pnlJobAE" runat="server" BorderColor="" CssClass="modalPopupQ" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                <%--<div class="divRoated">--%>
                                <div class="DivSecPanel">
                                    <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">
                                    <asp:GridView ID="grdBuyingDetails" CssClass="Grid FixedHeader" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found to Display!"
                                        AutoGenerateColumns="False" AllowPaging="false" OnPageIndexChanging="grdBuyingDetails_PageIndexChanging" PageSize="10"
                                        Width="100%" OnRowDataBound="grdBuyingDetails_RowDataBound" OnSelectedIndexChanged="grdBuyingDetails_SelectedIndexChanged">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Buying">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                        <asp:Label ID="Buying" runat="server" Text='<%# Bind("rateid") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Customer">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 160px">
                                                        <asp:Label ID="Customer" runat="server" Text='<%# Bind("Customer") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="160px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="POL">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                                        <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="POD">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                                        <asp:Label ID="POD" runat="server" Text='<%# Bind("POD") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PreparedBy">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                                        <asp:Label ID="PreparedBy" runat="server" Text='<%# Bind("preparedby") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="shipment" Visible="False">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                                        <asp:Label ID="shipment" runat="server" Text='<%# Bind("shipment") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                        <RowStyle CssClass="GrdRow" />
                                    </asp:GridView>
                                </asp:Panel>

                                <div class="Break"></div>
                                <div class="Break"></div>
                                <div class="Break"></div>

                            </asp:Panel>

                        </div>

                        <div class="FormGroupContent4">
                            <%---------------------------------------Popup Quot----------------------------------------%>

                            <asp:Label ID="lblquot" runat="server"></asp:Label>
                            <ajaxtoolkit:ModalPopupExtender ID="popupQuot" runat="server" TargetControlID="lblquot"
                                BehaviorID="programmaticModalPopupBehavior2"
                                PopupControlID="popupsecond" CancelControlID="imgok">
                            </ajaxtoolkit:ModalPopupExtender>
                            <asp:Panel ID="popupsecond" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                <%--<div class="divRoated">--%>
                                <div class="divRoated">
                                    <div class="DivSecPanel">
                                        <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                    </div>

                                    <asp:Panel ID="Panel4" runat="server" CssClass="Gridpnl">
                                        <asp:GridView ID="grdQuotaionDetails" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found to Display!"
                                            AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="grdQuotaionDetails_SelectedIndexChanged"
                                            OnRowDataBound="grdQuotaionDetails_RowDataBound" OnPageIndexChanging="grdQuotaionDetails_PageIndexChanging"
                                            PageSize="20" AllowPaging="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Inquiry #">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                            <asp:Label ID="InquiryId" runat="server" Text='<%# Bind("inquiryid") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="InquiryDate">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                            <asp:Label ID="InquiryDate" runat="server" Text='<%# Bind("inquirydate") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Product">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 108px">
                                                            <asp:Label ID="Product" runat="server" Text='<%# Bind("Product") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Customer">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 495px">
                                                            <asp:Label ID="Customer" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="280px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POL">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POD">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="POD" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Prepared By">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="preparedby" runat="server" Text='<%# Bind("preparedby") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sales Person">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="Salesperson" runat="server" Text='<%# Bind("Salesperson") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Customer Ref #">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="CustomerRef" runat="server" Text='<%# Bind("cuspono") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>

                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                            <RowStyle CssClass="GrdRow" />
                                        </asp:GridView>
                                    </asp:Panel>

                                    <asp:Panel ID="Panel6" runat="server" CssClass="Gridpnl">
                                        <asp:GridView ID="GrdReuse" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found to Display!"
                                            AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="GrdReuse_SelectedIndexChanged"
                                            OnRowDataBound="GrdReuse_RowDataBound" OnPageIndexChanging="GrdReuse_PageIndexChanging"
                                            PageSize="20" AllowPaging="false">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Quotation">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                            <asp:Label ID="Quotation" runat="server" Text='<%# Bind("Quotno") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Customer">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 280px">
                                                            <asp:Label ID="Customer" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="280px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POL">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POD">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="POD" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>

                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                            <RowStyle CssClass="GrdRow" />
                                        </asp:GridView>
                                    </asp:Panel>

                                    <div class="Break"></div>

                                    <%--</div>--%>
                                </div>
                            </asp:Panel>

                        </div>

                        <div class="FormGroupContent4">
                            <%---------------------------------------Popup CRM----------------------------------------%>

                            <asp:Label ID="lblcrm" runat="server"></asp:Label>
                            <ajaxtoolkit:ModalPopupExtender ID="popupcrm" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior3"
                                PopupControlID="popupthird" PopupDragHandleControlID="grdcrm"
                                CancelControlID="imgggok">
                            </ajaxtoolkit:ModalPopupExtender>
                            <asp:Panel ID="popupthird" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                <div class="divRoated">
                                    <div class="DivSecPanel">
                                        <asp:Image ID="imgggok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                    </div>

                                    <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                                        <asp:GridView ID="grdcrmQuot" runat="server" ShowHeaderWhenEmpty="True" AllowPaging="false" PageSize="10" OnPageIndexChanging="grdcrmQuot_PageIndexChanging"
                                            EmptyDataText="No records Found to Display!" AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="grdcrmQuot_RowDataBound" CssClass="Grid FixedHeader" OnSelectedIndexChanged="grdcrmQuot_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="crmid" HeaderText="CRM #" />
                                                <asp:BoundField DataField="customername" HeaderText="Customer" />
                                                <%--  <asp:BoundField DataField="pdt" HeaderText="Product" />--%>
                                                <asp:BoundField DataField="por" HeaderText="POR" />
                                                <asp:BoundField DataField="pol" HeaderText="POL" />
                                                <asp:BoundField DataField="pod" HeaderText="POD" />
                                                <asp:BoundField DataField="fd" HeaderText="FD" />
                                                <asp:BoundField DataField="porid" HeaderText="porid" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="polid" HeaderText="polid" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="podid" HeaderText="podid" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="fdid" HeaderText="fdid" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="salespersonid" HeaderText="salespersonid" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="salesperson" HeaderText="salesperson" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="commodityid" HeaderText="commodityid" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="commodity" HeaderText="commodity" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="freight" HeaderText="freight" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="hazardous" HeaderText="hazardous" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />
                                                <asp:BoundField DataField="customerid" HeaderText="customerid" HeaderStyle-CssClass="grd-mt" ItemStyle-CssClass="grd-mt" />

                                            </Columns>

                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle CssClass="GrdRow" />
                                        </asp:GridView>

                                    </asp:Panel>

                                    <div class="Break"></div>
                                    <div class="Break"></div>
                                    <div class="Break"></div>
                                </div>

                            </asp:Panel>

                            <asp:Panel runat="Server" ID="pnl" CssClass="Pnl1" Style="display: none;">
                                <br />
                                This Quotation has been Approved.   
                                    <br />
                                You can't amend this, Logix is creating New Quotation with same information            
        <div class="div_confirm">
            <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="Button" OnClick="btnYes_Click" />
            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="Button" OnClick="btnNo_Click" />
        </div>
                            </asp:Panel>
                            <div class="div_Break"></div>

                            <ajaxtoolkit:ModalPopupExtender ID="Confirmdialog" runat="server" TargetControlID="hid_pln"
                                PopupControlID="pnl" />
                            <asp:Label ID="hid_pln" runat="server" />

                        </div>

                        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="LogHeadLbl">
                                    <div class="LogHeadJob">
                                        <label>Quotation # :</label>

                                    </div>
                                    <div class="LogHeadJobInput">

                                        <asp:Label ID="JobInput" runat="server"></asp:Label>

                                    </div>

                                </div>
                                <div class="DivSecPanel">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                                    <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                                        ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
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
        </div>
    </div>
    <asp:Label ID="Label4" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel runat="Server" ID="Panel_FE" CssClass="Pnl2" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do you want add Buying Details ?</b></div>
        <br />
        <div class="div_confirm1">
            <asp:Button ID="btn_Yes1" runat="server" Text="Yes" CssClass="Button" OnClick="btn_Yes1_Click" />
            <asp:Button ID="btn_No1" runat="server" Text="No" CssClass="Button" OnClick="btn_No1_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>

    <asp:Label ID="Label19" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel8"
        DropShadow="false" TargetControlID="Label19" CancelControlID="Image2" BehaviorID="Test2">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel runat="Server" ID="Panel8" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <asp:Panel runat="Server" ID="Panel10" CssClass="Gridpnl">
                <div class="FormGroupContent4">
                    <div class="Receipt">
                        <asp:Label ID="Label27" runat="server" Text="Terms"></asp:Label>
                    </div>
                    <div class="div_Break"></div>
                    <div class="Terms ">

                        <asp:Label ID="txt_terms" runat="server"></asp:Label>
                        <%--                     <asp:TextBox ID="txtterms" runat="server"  Width="100%"  ToolTip="Terms" PlaceHolder=" " TextMode="MultiLine" Rows="1" Style="resize: none;" CssClass="form-control"  ReadOnly="true" ></asp:TextBox>--%>
                    </div>
                </div>
            </asp:Panel>
            <div class="div_Break"></div>
        </div>
    </asp:Panel>

    <asp:Label ID="LabelNew" runat="server" Text="LabelNew" Style="display: none;"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="PopUp_FIAI" runat="server" PopupControlID="Panel_FE" TargetControlID="LabelNew">
    </ajaxtoolkit:ModalPopupExtender>

    <div class="FormGroupContent4">
        <asp:Panel ID="Panel11" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                    </div>
                    <div class="LogHeadJobInput">

                        <asp:Label ID="Label50" runat="server"></asp:Label>

                    </div>

                </div>
                <div class="DivSecPanel">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel12" runat="server" CssClass="Gridpnl">



                    <asp:Panel ID="Gridcont" runat="server" Visible="true" CssClass="relative">
                        <asp:GridView ID="test" runat="server" CssClass="Grid FixedHeader" OnPreRender="test_PreRender">

                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle Font-Italic="False" />
                        </asp:GridView>
                    </asp:Panel>


                </asp:Panel>
                <div class="Break"></div>
            </div>

        </asp:Panel>
        <asp:Label ID="Label51" runat="server" Text="LabelNew" Style="display: none;"></asp:Label>

        <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel11" TargetControlID="Label51" CancelControlID="Image3" BehaviorID="Test3">
        </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel runat="Server" ID="popup_upload" CssClass="modalPopup" Style="display: none;">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:LinkButton ID="btnpopcls" runat="server"  OnClick="btnpopcls_Click" >
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="20px" />
                    </asp:LinkButton>
                </div>
                <asp:Panel ID="pnl_emp1" runat="server">
                    <div class="">
                        <iframe id="iframe_outstd" runat="server" src="" frameborder="0"></iframe>
                    </div>
                </asp:Panel>
            </div>
        </asp:Panel>


        <div class="div_Break"></div>
        <ajaxtoolkit:ModalPopupExtender ID="popup_uploaddoc" runat="server" PopupControlID="popup_upload" TargetControlID="lbl1"
            CancelControlID="Image4">
        </ajaxtoolkit:ModalPopupExtender>
        <asp:Label ID="lbl1" runat="server" Text="Label" Style="display: none;"></asp:Label>

        <%---------------------------------------------------------%>

        <%--            <asp:Label ID="Label52" runat="server" Text="LabelNew" Style="display: none;"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel11" TargetControlID="Label51" CancelControlID="Image3" BehaviorID="Test3">
    </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel runat="Server" ID="popup_upload2"  CssClass="modalPopup" Style="display: none;">
    <div class="divRoated">
    <div class="DivSecPanel">
        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/close2.png" Width="20px" />
    </div>
        <div class="">
            <iframe id="iframe_outstd2" runat="server" src="" frameborder="0"></iframe>
        </div>
    </asp:Panel>
        </div>
</asp:Panel>


<div class="div_Break"></div>
<ajaxtoolkit:ModalPopupExtender ID="popup_uploaddoc2" runat="server" PopupControlID="popup_upload" TargetControlID="lbl2"
    CancelControlID="Image4">
</ajaxtoolkit:ModalPopupExtender>
<asp:Label ID="lbl2" runat="server" Text="Label" Style="display: none;"></asp:Label>--%>
    </div>




























    <asp:HiddenField ID="hdf_customerid" runat="server" />
    <asp:HiddenField ID="hdf_cargoid" runat="server" />
    <asp:HiddenField ID="hdf_POL" runat="server" />
    <asp:HiddenField ID="hdf_POR" runat="server" />
    <asp:HiddenField ID="hdf_POD" runat="server" />
    <asp:HiddenField ID="hdf_FD" runat="server" />
    <asp:HiddenField ID="hdf_salesperson" runat="server" />
    <asp:HiddenField ID="hdf_Hazard" runat="server" />
    <asp:HiddenField ID="hdf_Bussiness" runat="server" />
    <asp:HiddenField ID="hdf_Charges" runat="server" />
    <asp:HiddenField ID="hdf_Curr" runat="server" />
    <asp:HiddenField ID="hdf_app" runat="server" />
    <asp:HiddenField ID="hdf_OldQuotNo" runat="server" />
    <asp:HiddenField ID="hid_oldData" runat="server" />
    <asp:HiddenField ID="hid_charge" runat="server" />
    <asp:HiddenField ID="hidgroupid" runat="server" />
    <asp:HiddenField ID="hidreuse" runat="server" />
    <asp:HiddenField ID="NewQuoteRpt" runat="server" Value="Y" />
    <asp:HiddenField ID="hid_exrate" runat="server" />
    <asp:HiddenField ID="hid_amount" runat="server" />
    <asp:HiddenField ID="hid_expqty" runat="server" />
    <asp:HiddenField ID="hid_rate" runat="server" />
    <asp:HiddenField ID="hid_quotno" runat="server" />
    <asp:HiddenField ID="hid_total10" runat="server" />

    <asp:HiddenField ID="Hidtotal" Value="0.00" runat="server" />

    <asp:HiddenField ID="hdn_Incoid" runat="server" />
    <asp:HiddenField ID="hdn_Business" runat="server" />
    <asp:HiddenField ID="hdnCarrier" runat="server" />
    <asp:HiddenField ID="hdn_shipperid" runat="server" />
    <asp:HiddenField ID="hdn_Consigneeid" runat="server" />
    <asp:HiddenField ID="hid_sellrate" runat="server" />
    <asp:HiddenField ID="hid_buyrate" runat="server" />
    <asp:HiddenField ID="hid_rateid" runat="server" />
    <asp:HiddenField ID="hid_totb" Value="0.00" runat="server" />
    <asp:HiddenField ID="hid_tot" runat="server" />
    <asp:HiddenField ID="hf_countryid" runat="server" />
    <asp:HiddenField ID="hf_Buyrate" runat="server" />
</asp:Content>

