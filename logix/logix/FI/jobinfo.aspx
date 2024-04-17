<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="jobinfo.aspx.cs" Inherits="logix.FI.jobinfo" %>

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
    <script type="text/javascript">
        function DisableButtons() {
            var inputs = document.getElementsByTagName("INPUT");
            for (var i in inputs) {
                if (inputs[i].type == "button" || inputs[i].type == "submit") {
                    inputs[i].disabled = true;
                }
            }
        }
        window.onbeforeunload = DisableButtons; //uncomment to use this script.
    </script>

    <link href="../Styles/JobInfoImpo.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
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

        .Shipment_Type {
            float: left;
            width: 18%;
            margin: 0 0.5% 0 0;
        }

        .ChkBox {
            width: 16%;
            float: left;
            margin: 4px 0px 0px 0.5%;
        }

            .ChkBox span {
                margin-top: 4px !important;
                display: inline-block;
                /*float: right;*/
            }
    </style>
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
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .hide {
            display: none;
        }

        #logix_CPH_ddl_cmbSize_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddl_DropFI_chzn {
            width: 100% !important;
        }

        #programmaticModalPopupBehaviordf1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        /*new job css*/
        .JobRight1 {
            width: 100%;
            float: right;
            margin: 0px;
        }

        .JobLeft1 {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobInput13 {
            width: 44%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IMCal4 {
            width: 14.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IMCal5 {
            width: 14.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IMCal6 {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IMInput {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .JobLabel {
            width: 3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .VoyageInput9 {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .VesselInput11 {
            width: 24%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .DivNew_gr2 {
            margin: 0px 0px 0px 0px;
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
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput1 label {
            font-size: 11px;
        }

        .LogHeadJobInput1 {
            width: auto;
            white-space: nowrap;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput1 span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

        .LogHeadJobInput label {
            font-size: 11px;
            font-family: sans-serif;
            color: #4e4e4c;
        }

        .JobInput12 {
            width: 44%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Load1 {
            width: 27%;
            float: left;
            font-size: 11px;
            color: #000080;
            margin: 0px 0.5% 0px 0px;
        }

        .Dis1new {
            width: 28.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MBL1new {
            width: 27%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MBLCal2 {
            width: 14.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MLO1 {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Agent1 {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .AgentCal3 {
            width: 14.5%;
            float: left;
            margin: 0px 0 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .CarrierNew {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }



        .IMO {
            width: 17.7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .CFSCode {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Bond {
            width: 14%;
            float: left;
            margin: 0px 5px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Truck {
            width: 15.3%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .VSL {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Line {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .AgentInput12 {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .CallSign {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .AprPort {
            width: 11.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .LastPort {
            width: 23.7%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MasterInput {
            width: 15.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .NationInput {
            width: 21.7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .RemarksInput6 {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .txtCont {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FRDrop {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .SealC2 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .PKGInput2 {
            width: 11.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .WTInput1 {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ISOCode {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .SOCFlag {
            width: 18.4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MT10 {
            margin: 13px 0px 0px 0px !important;
        }

        .OBLTxtBox {
            width: 28.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OBLTxtBox1 {
            width: 14.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .FRDrop .chzn-drop {
            top: -250px !important;
            border: 1px solid #b1b1b1;
            border-radius: 5px;
        }

        div#logix_CPH_btn_add1 {
            margin: 15px 0 0 0;
        }

        table#logix_CPH_grdBookJob th {
            border-right: 0.5px solid #fff;
        }

        .ShipmentLeft {
            position: relative;
            top: 5px;
            background: white;
        }

        table#logix_CPH_Grid_blno td:nth-child(3) {
            max-width: 175px;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        table#logix_CPH_Grid_blno td:nth-child(4) {
            max-width: 175px;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .LeftSide {
            width: 55%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .rightside {
            width: 44.5%;
            float: left;
            margin-top: -5px;
        }

        .vessel_text {
            width: 33.5%;
            float: left;
            margin: 0px 0.5% 0px 0px
        }


        .CFS_1 {
            width: 54.4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        div#UpdatePanel1 {
            height: 87vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        img#logix_CPH_flagimg {
            width: 24px !important;
            height: auto;
            position: relative;
            left: -87%;
            top: 174px;
            z-index: 10;
        }

        img#logix_CPH_podflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: 48%;
            top: 174px;
            z-index: 10;
        }

        /*New Design - Buttons*/


        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 65px !important;
        }

        .VSL.TextField input {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }

        .VSL span {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }

        .Line.TextField input {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }

        .Line span {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }



        .AgentInput12 span {
            background: #d3d3d300 !important;
        }

        .CallSign span {
            background: #d3d3d300 !important;
        }

        .AprPort span {
            background: #d3d3d300 !important;
        }

        .FormGroupContent4 .LastPort span {
            background: #d3d3d300 !important;
        }

        .AgentInput12 span {
            background: #d3d3d300 !important;
        }

        .CallSign span {
            background: #d3d3d300 !important;
        }

        .AprPort span {
            background: #d3d3d300 !important;
        }

        .LastPort span {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CPort1 {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CPort2 {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CVsltype {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CGRT {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CNRT {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CTotal {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CArrport {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CLastport {
            background: #d3d3d300 !important;
        }

        .MasterInput span {
            background: #d3d3d300 !important;
        }

        .NationInput span {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CMaster {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CNation {
            background: #d3d3d300 !important;
        }

        input#logix_CPH_txt_CArrport {
            width: 100% !important;
        }

        table#logix_CPH_grd_Jobno td:nth-child(1) {
            width: 1% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(1) {
            width: 1% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(9) {
            width: 5% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(10) {
            width: 5% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(5) {
            width: 5% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(3) {
            width: 16% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(6) {
            width: 5% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(7) {
            width: 5% !important;
        }

        table#logix_CPH_grd_Jobno th:nth-child(2) {
            width: 6% !important;
        }

        div#logix_CPH_Book2 {
            width: 100%;
            float: left;
            margin-top: 10px;
        }

        input#logix_CPH_Btnamendmbl {
            background-position: 1px 1px;
            width: 30px !important;
            scale: 0.7;
            margin-top: 10px;
        }

        div#logix_CPH_btn {
            width: 27px !important;
            margin: 0px;
        }
    </style>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

                $("#<%=txt_search.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FI/jobinfo.aspx/FE_GetBookingNo",
                            data: "{ 'prefix': '" + request.term + "','job':'" + $("#<%=txt_jobno.ClientID %>").val() + "'}",
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
                        $("#<%=txt_search.ClientID %>").val(i.item.label);
                        $("#<%=txt_search.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_search.ClientID %>").val(i.item.label);
                    },
                    change: function (event, i) {
                        $("#<%=txt_search.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        $("#<%=txt_search.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txtCarrier.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hdnCarrier.ClientID %>").val(0);

                        $.ajax({
                            url: "../FI/jobinfo.aspx/GetCarrierName",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                        }
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                        }
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_vessel.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_vesselid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/jobinfo.aspx/GetVessel",
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

                    select: function (e, i) {
                        $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $('#<%=txt_pol.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_porid.ClientID %>").val(0);

                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_pol.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_pol.ClientID%>').val(ui.item.portname);
                        $("#<%=hf_porid.ClientID %>").val(ui.item.portid);
                        $('#<%=txt_pol.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_pol.ClientID%>').val(ui.item.portname);
                        $("#<%=hf_porid.ClientID %>").val(ui.item.portid);
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

                        $("#<%=txt_pol.ClientID %>").autocomplete({

                            source: function (request, response) {
                                $("#<%=hf_porid.ClientID %>").val(0);

                            $.ajax({
                                url: "../FI/jobinfo.aspx/FEJobInfo_GetPort",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }

                            });
                        },

                        select: function (e, i) {
                            $("#<%=hf_porid.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                        });
                    });--%>

            $(document).ready(function () {
                $("#<%=txt_MLO.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_intMLOid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/jobinfo.aspx/GetCustomer",
                            data: "{ 'prefix': '" + request.term + "','FType':'C'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]

                                    }
                                }))

                            },

                            error: function (response) {
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_MLO.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_intMLOid.ClientID %>").val(i.item.val);
                        $("#<%=txt_MLO.ClientID %>").change();
                        $("#<%=txt_MLO.ClientID %>").val(i.item.address);

                    },
                    focus: function (event, i) {
                        $("#<%=txt_MLO.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_intMLOid.ClientID %>").val(i.item.val);
                        $("#<%=txt_MLO.ClientID %>").val($.trim(result));
                        $("#<%=txt_MLO.ClientID %>").val(i.item.address);

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_MLO.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intMLOid.ClientID %>").val(i.item.val);
                            $("#<%=txt_MLO.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_MLO.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_MLO.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });



            $(document).ready(function () {
                $('#<%=txt_pod.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_podid.ClientID %>").val(0);

                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_pod.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_pod.ClientID%>').val(ui.item.portname);
                        $("#<%=hf_podid.ClientID %>").val(ui.item.portid);
                        $('#<%=txt_pod.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_pod.ClientID%>').val(ui.item.portname);
                        $("#<%=hf_podid.ClientID %>").val(ui.item.portid);
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





<%--                    $(document).ready(function () {

                        $("#<%=txt_pod.ClientID %>").autocomplete({

                            source: function (request, response) {
                                $("#<%=hf_podid.ClientID %>").val(0);

                                $.ajax({
                                    url: "../FI/jobinfo.aspx/FEJobInfo_GetPort",

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
                                        alertify.alert(response.responseText);
                                    },
                                    failure: function (response) {
                                        alertify.alert(response.responseText);
                                    }

                                });
                            },

                      

                            select: function (event, i) {
                                if (i.item) {
                                    $("#<%=txt_pod.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                    $("#<%=hf_podid.ClientID %>").val(i.item.val);
                                }
                            },
                            focus: function (event, i) {
                                if (i.item) {
                                    $("#<%=txt_pod.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                    $("#<%=hf_podid.ClientID %>").val(i.item.val);
                                }
                            },
                            change: function (event, i) {
                                if (i.item) {
                                    $("#<%=txt_pod.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                    $("#<%=hf_podid.ClientID %>").val(i.item.val);
                                }
                            },
                            close: function (event, i) {
                                if (i.item) {
                                    $("#<%=txt_pod.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                    $("#<%=hf_podid.ClientID %>").val(i.item.val);
                                }
                            },
                            minLength: 1
                        });
                    });--%>

            <%-- $(document).ready(function () {

                    $("#<%=txt_Agent.ClientID %>").autocomplete({

                        source: function (request, response) {

                            $("#<%=hf_intAgentid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/jobinfo.aspx/Getcus",
                            //data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_MLO').value + "'}",
                            data: "{ 'prefix': '" + request.term + "','strcustype':'P'}",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }
                        });
                    },

                        <%-- select: function (e, i) {
                        $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);
                    },
                        select: function (event, i) {
                            if (i.item) {
                                $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);                               
                            }
                         },
                        focus: function (event, i) {
                            if (i.item) {
                                $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);
                            }
                        },
                        change: function (event, i) {                            
                                if (i.item) {
                                    $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                    $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);
                                }
                        },
                        close: function (event, i) {
                            if (i.item) {
                                $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);
                            }
                        },
                    minLength: 1
                    });
                });--%>

            <%-- $(document).ready(function () {

                    $("#<%=txt_cfs.ClientID %>").autocomplete({

                        source: function (request, response) {

                            $("#<%=hf_intCFSid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/jobinfo.aspx/GetCustomers",
                            //data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_MLO').value + "'}",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (e, i) {
                        $("#<%=hf_intCFSid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                    });
                });--%>

            $(document).ready(function () {
                $("#<%=txt_Agent.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_intAgentid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/jobinfo.aspx/Getcus",
                            data: "{ 'prefix': '" + request.term + "','strcustype':'P'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]

                                    }
                                }))

                            },

                            error: function (response) {
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);
                        $("#<%=txt_Agent.ClientID %>").change();
                        $("#<%=txt_Agent.ClientID %>").val(i.item.address);

                    },
                    focus: function (event, i) {
                        $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);
                        $("#<%=txt_Agent.ClientID %>").val($.trim(result));
                        $("#<%=txt_Agent.ClientID %>").val(i.item.address);

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intAgentid.ClientID %>").val(i.item.val);
                            $("#<%=txt_Agent.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_Agent.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_Agent.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });

            <%--     $(document).ready(function () {
                $("#<%=txt_cfs.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hf_intCFSid.ClientID %>").val(0);
                         $.ajax({
                             url: "../FI/jobinfo.aspx/FIJobInfo_GetCustomer",
                             data: "{ 'prefix': '" + request.term + "','FType':'L'}",
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
                            <%-- $("#<%=txt_mlo.ClientID %>").val(i.item.label);
                        $("#<%=txt_cfs.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_cfs.ClientID %>").change();
                        $("#<%=hf_intCFSid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_cfs.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intCFSid.ClientID %>").val(i.item.val);
                        },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cfs.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=hf_intCFSid.ClientID %>").val(i.item.val);
                            }

                        },
                    close: function (event, i) {
                        var result = $("#<%=txt_cfs.ClientID %>").val().toString().split(',')[0];
                            $("#<%=hf_intCFSid.ClientID %>").val($.trim(result));
                        },
                    minLength: 1
                });
             });--%>

            $(document).ready(function () {
                $("#<%=txt_cfs.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_intCFSid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/jobinfo.aspx/FIJobInfo_GetCustomer",
                            data: "{ 'prefix': '" + request.term + "','FType':'L'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]

                                    }
                                }))

                            },

                            error: function (response) {
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_cfs.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_intCFSid.ClientID %>").val(i.item.val);
                        $("#<%=txt_cfs.ClientID %>").change();
                        $("#<%=txt_cfs.ClientID %>").val(i.item.address);

                    },
                    focus: function (event, i) {
                        $("#<%=txt_cfs.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_intCFSid.ClientID %>").val(i.item.val);
                        $("#<%=txt_cfs.ClientID %>").val($.trim(result));
                        $("#<%=txt_cfs.ClientID %>").val(i.item.address);

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cfs.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intCFSid.ClientID %>").val(i.item.val);
                            $("#<%=txt_cfs.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_cfs.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_cfs.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });

            $(document).ready(function () {
                $('#<%=txt_CArrport.ClientID%>').autocomplete({
                    source: function (request, response) {


                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_CArrport.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_CArrport.ClientID%>').val(ui.item.portname);

                        $('#<%=txt_CArrport.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_CArrport.ClientID%>').val(ui.item.portname);

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
                $("#<%=txt_CArrport.ClientID %>").autocomplete({
                    source: function (request, response) {
                       
                        $.ajax({
                            url: "../FI/jobinfo.aspx/FEJobInfo_GetPort",

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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (e, i) {
                        $("#<%=txt_CArrport.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>


            $(document).ready(function () {
                $('#<%=txt_CLastport.ClientID%>').autocomplete({
                    source: function (request, response) {


                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_CLastport.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_CLastport.ClientID%>').val(ui.item.portname);

                        $('#<%=txt_CLastport.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_CLastport.ClientID%>').val(ui.item.portname);

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







              <%--  $(document).ready(function () {
                    $("#<%=txt_CLastport.ClientID %>").autocomplete({
                        source: function (request, response) {
                     
                            $.ajax({
                                url: "../FI/jobinfo.aspx/FEJobInfo_GetPort",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }

                            });
                        },

                        select: function (e, i) {
                            $("#<%=txt_CLastport.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });--%>



            $(document).ready(function () {
                $('#<%=txt_CPort1.ClientID%>').autocomplete({
                    source: function (request, response) {


                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_CPort1.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_CPort1.ClientID%>').val(ui.item.portname);

                        $('#<%=txt_CPort1.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_CPort1.ClientID%>').val(ui.item.portname);

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





            <%--                    $(document).ready(function () {
                        $("#<%=txt_CPort1.ClientID %>").autocomplete({
                            source: function (request, response) {
                     
                                $.ajax({
                                    url: "../FI/jobinfo.aspx/FEJobInfo_GetPort",

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
                                        alertify.alert(response.responseText);
                                    },
                                    failure: function (response) {
                                        alertify.alert(response.responseText);
                                    }

                                });
                            },

                            select: function (e, i) {
                                $("#<%=txt_CPort1.ClientID %>").val(i.item.val);
                            },
                            minLength: 1
                        });
                    });--%>


            $(document).ready(function () {
                $('#<%=txt_CPort2.ClientID%>').autocomplete({
                    source: function (request, response) {


                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_CPort2.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_CPort2.ClientID%>').val(ui.item.portname);

                        $('#<%=txt_CPort2.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_CPort2.ClientID%>').val(ui.item.portname);

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







                     <%--   $(document).ready(function () {
                            $("#<%=txt_CPort2.ClientID %>").autocomplete({
                                source: function (request, response) {
                      
                                        $.ajax({
                                            url: "../FI/jobinfo.aspx/FEJobInfo_GetPort",

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
                                                alertify.alert(response.responseText);
                                            },
                                            failure: function (response) {
                                                alertify.alert(response.responseText);
                                            }

                                        });
                                    },

                                select: function (e, i) {
                                    $("#<%=txt_CPort2.ClientID %>").val(i.item.val);
                                    },
                                    minLength: 1
                            });
                        });--%>

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you Want to delete this Details?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function disableBtn(btnID, newText) {
            //initialize to avoid 'Page_IsValid is undefined' JavaScript error
            Page_IsValid = null;
            //check if the page request any validation
            // if yes, check if the page was valid
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                //you can pass in the validation group name also
            }
            //variables
            var btn = document.getElementById(btnID);
            var isValidationOk = Page_IsValid;
            /********NEW UPDATE************************************/
            //if not IE then enable the button on unload before redirecting/ rendering
            if (navigator.appName !== 'Microsoft Internet Explorer') {
                EnableOnUnload(btnID, btn.value);
            }
            /***********END UPDATE ****************************/
            // isValidationOk is not null
            if (isValidationOk !== null) {
                //page was valid
                if (isValidationOk) {
                    btn.disabled = true;
                    btn.value = newText;
                    btn.style.background = 'url(~/images/ajax-loader.gif)';
                }
                else {//page was not valid
                    btn.disabled = false;
                }
            }
            else {//the page don't have any validation request
                setTimeout("setImage('" + btnID + "')", 10);
                btn.disabled = true;
                btn.value = newText;
            }
        }

        //set the background image of the button
        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(images/Loading.gif)';
        }

        //enable the button and restore the original text value
        function EnableOnUnload(btnID, btnText) {
            window.onunload = function () {
                var btn = document.getElementById(btnID);
                btn.disabled = false;
                btn.value = btnText;
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Job Info"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <%-- <li><a href="#"></a>Documentation</li>--%>
                                <li><a href="#" title="">Ocean Imports</a> </li>
                                <li class="current"><a href="#" title="">Job Info </a></li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">

                    <div class="LeftSide">
                        <div class="FormGroupContent4 FixedButtons">
                            <div class="left_btn">
                                <div class="btn ico-proforma-sales-invoice">
                                    <asp:Button ID="Proinvoic" runat="server" Text="Proforma Sales Invoice" ToolTip="Proforma Sales Invoice" TabIndex="53" OnClick="Proinvoic_Click" />
                                </div>
                                <div class="btn ico-proforma-purchase-invoice">
                                    <asp:Button ID="procrednote" runat="server" Text="Proforma Purchase Invoice" ToolTip="Proforma Purchase Invoice" TabIndex="54" OnClick="procrednote_Click" />
                                </div>
                                <div class="btn ico-proforma-oscndn">
                                    <asp:Button ID="Proosdncn" runat="server" Text="Proforma OSDN/CN" ToolTip="Proforma OSDN/CN" TabIndex="55" OnClick="Proosdncn_Click" />
                                </div>



                                <div class="btn ico-swap" id="Div1" runat="server">
                                    <asp:Button ID="Btnnamendjob" runat="server" ToolTip="Change Job" TabIndex="41" OnClick="Btnamendjob_Click" />
                                </div>

                            </div>
                            <div class="right_btn">

                                <div class="btn ico-upload" style="display: none;">
                                    <asp:Button ID="uploaddoc" runat="server" Text="Upload Document" ToolTip="Upload Document" OnClick="uploaddoc_Click" />
                                </div>
                                <div class="btn ico-reuse">
                                    <asp:Button ID="btnreuse" runat="server" Text="Reuse" ToolTip="Reuse" OnClick="btnreuse_Click" />
                                </div>
                                <div class="btn ico-save" id="btn_save1" runat="server">
                                    <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" TabIndex="45" />
                                </div>
                                <div class="btn ico-view" id="btn_view1" runat="server">
                                    <asp:Button ID="btn_view" runat="server" ToolTip="View" Text="View" OnClick="btn_view_Click" TabIndex="46" />
                                </div>
                                <div class="btn ico-cancel" id="btn_back1" runat="server">
                                    <asp:Button ID="btn_back" runat="server" ToolTip="Cancel" Text="Cancel" OnClick="btn_back_Click" TabIndex="47" />
                                </div>
                            </div>


                        </div>
                        <div class="FormGroupContent4 custom-d-flex">





                            <div class="Shipment_Type fit-content">
                                <span>Job Type</span>
                                <asp:DropDownList ID="ddl_jobtype" runat="server" TabIndex="21" data-placeholder="Shipment Type" CssClass="chzn-select" ToolTip="Shipment Type">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="1">Consol</asp:ListItem>
                                    <asp:ListItem Value="2">Co_Load</asp:ListItem>
                                    <asp:ListItem Value="3">FCL</asp:ListItem>
                                    <asp:ListItem Value="4">MCC</asp:ListItem>
                                    <asp:ListItem Value="5">Buyer Consol</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="AgentCal3 DateR">
                                <asp:Label ID="Label15" runat="server" Text="Doc Recd On"></asp:Label>
                                <asp:TextBox ID="txt_DocRecdon" runat="server" ToolTip="Doc Recd On" placeholder="" CssClass="form-control" TabIndex="16"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_DocRecdon"
                                    Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            <div class="ChkBox">
                                <span class="chktext">Profit Share Job</span>

                                <asp:CheckBox ID="CHk_DropFI" runat="server"
                                    AutoPostBack="True" OnCheckedChanged="CHk_DropFI_CheckedChanged" />

                            </div>
                            <div style="width: 30%; float: left">
                                <asp:Image ID="flagimg" runat="server" Width="100%" />
                                <asp:Image ID="podflag" runat="server" Width="100%" />


                            </div>


                        </div>

                        <div class="FormGroupContent4">
                            <div class="CarrierNew">
                                <asp:Label ID="Label16" runat="server" Text="Carrier"></asp:Label>
                                <asp:TextBox ID="txtCarrier" runat="server" placeholder="" ReadOnly="true" TabIndex="17" ToolTip="Carrier" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCarrier_TextChanged"></asp:TextBox>
                            </div>
                        </div>

                        <%--row1--%>
                        <div class="FormGroupContent4">
                            <div class="custom-mr-05 vessel_text">
                                <asp:Label ID="Label2" runat="server" Text="Vessel ( Feeder Vessel / Direct )"></asp:Label>
                                <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="Vessel ( Feeder Vessel / Direct )" placeholder="" TabIndex="3" OnTextChanged="txt_vessel_TextChanged"></asp:TextBox>
                            </div>
                            <div class="VoyageInput9">
                                <asp:Label ID="Label3" runat="server" Text="Voyage"></asp:Label>
                                <asp:TextBox ID="txt_voyage" runat="server" CssClass="form-control" ToolTip="Voyage" placeholder="" TabIndex="4"></asp:TextBox>
                            </div>
                            <div class="IMO">
                                <asp:Label ID="Label18" runat="server" Text="IMO Code"></asp:Label>
                                <asp:TextBox ID="txt_ImoCode" runat="server" ToolTip="Vessel IMO Code" placeholder="" CssClass="form-control" TabIndex="19"></asp:TextBox>
                            </div>
                            <div class="IMInput">
                                <asp:Label ID="Label5" runat="server" Text="IM #"></asp:Label>
                                <asp:TextBox ID="txt_imno" runat="server" ToolTip="IM #" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="5"></asp:TextBox>
                            </div>
                            <div class="IMCal4">
                                <asp:Label ID="Label6" runat="server" Text="IM Date"></asp:Label>
                                <asp:TextBox ID="dt_imdate" runat="server" CssClass="form-control" ToolTip="IM Date" TabIndex="6"></asp:TextBox>
                                <asp:CalendarExtender ID="dt_date2" runat="server" TargetControlID="dt_imdate"
                                    Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>


                        </div>



                        <%--row2--%>
                        <div class="FormGroupContent4">
                            <div class="Load1">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label9" runat="server" Text="Vessel - Port of Loading"></asp:Label>
                                    <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" ToolTip="Vessel - Port of Loading" placeholder="" AutoPostBack="true" TabIndex="9" OnTextChanged="txt_pol_TextChanged"></asp:TextBox>

                                </div>


                            </div>

                            <div class="IMCal5">
                                <asp:Label ID="Label46" runat="server" Text="ETD"></asp:Label>
                                <asp:TextBox ID="txt_etd" runat="server" CssClass="form-control" ToolTip="ETA" TabIndex="7"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_etd"
                                    Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>

                            <div class="Dis1new">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label10" runat="server" Text="Vessel - Port of Discharge"></asp:Label>
                                    <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" ToolTip="Vessel - Port of Discharge" placeholder="" OnTextChanged="txt_pod_TextChanged" TabIndex="10" AutoPostBack="true"></asp:TextBox>

                                </div>



                            </div>

                            <div class="IMCal5">
                                <asp:Label ID="Label7" runat="server" Text="ETA"></asp:Label>
                                <asp:TextBox ID="dt_ETA" runat="server" CssClass="form-control" ToolTip="ETA" TabIndex="7"></asp:TextBox>
                                <asp:CalendarExtender ID="dt_date3" runat="server" TargetControlID="dt_ETA"
                                    Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>
                            <div class="IMCal6 DateR">
                                <asp:Label ID="Label8" runat="server" Text="ETB"></asp:Label>
                                <asp:TextBox ID="dt_ETB" runat="server" CssClass="form-control" ToolTip="ETB" TabIndex="8"></asp:TextBox>
                                <asp:CalendarExtender ID="dt_date4" runat="server" TargetControlID="dt_ETB"
                                    Format="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>



                        </div>

                        <div class="FormGroupContent4 custom-d-flex">




                            <div class="JobDateLabel" style="display: none">
                                <asp:Label ID="lbl_jobda" runat="server" Text="Job Date"></asp:Label>
                            </div>







                        </div>

                        <div class="FormGroupContent4 boxmodal">

                            <div class="FormGroupContent4">





                                <div class="ContractDrop" style="display: none;">
                                    <asp:DropDownList ID="ddl_DropFI" runat="server" data-placeholder="JobProfitShare" CssClass="chzn-select" ToolTip="JobProfitShare" TabIndex="12" Width="100%">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Value="O">Our Job</asp:ListItem>
                                        <asp:ListItem Value="P">Profit Share</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MLO1">
                                    <asp:Label ID="Label13" runat="server" Text="MLO"></asp:Label>
                                    <asp:TextBox ID="txt_MLO" runat="server" ToolTip="MLO" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_MLO_TextChanged" TabIndex="14"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">


                                <div class="MBL1new">
                                    <asp:Label ID="Label11" runat="server" Text="MBL #"></asp:Label>
                                    <asp:TextBox ID="txt_mblno" runat="server" CssClass="form-control" ToolTip="MBL #" placeholder="" TabIndex="11" AutoPostBack="true" OnTextChanged="txt_mblno_TextChanged" onkeypress="if (event.keyCode==39 || event.keyCode==34) event.returnValue = false;"></asp:TextBox>
                                </div>
                                <div class="btn ico-edit" id="btn" runat="server">
                                    <asp:Button ID="Btnamendmbl" runat="server" ToolTip="Amend MBL" TabIndex="41" OnClick="Btnamendmbl_Click" />
                                </div>

                                <div class="MBLCal2 DateR">
                                    <asp:Label ID="Label12" runat="server" Text="MBL Date"></asp:Label>
                                    <asp:TextBox ID="dt_MBL" runat="server" CssClass="form-control" ToolTip="MBL Date" placeholder="" TabIndex="13"></asp:TextBox>
                                    <asp:CalendarExtender ID="dt_date5" runat="server" TargetControlID="dt_MBL"
                                        Format="dd/MM/yyyy"></asp:CalendarExtender>
                                </div>
                                <div class="OBLTxtBox">

                                    <asp:Label ID="Label44" runat="server" Text="OBL"></asp:Label>
                                    <asp:TextBox ID="txt_obl" runat="server" placeholder="" ToolTip="OBL" CssClass="form-control" TabIndex="43"></asp:TextBox>
                                </div>
                                <div class="OBLTxtBox1 DateR">

                                    <asp:Label ID="Label45" runat="server" Text="OBL Date"></asp:Label>
                                    <asp:TextBox ID="txt_obldate" runat="server" placeholder="" ToolTip="OBLDate" CssClass="form-control" TabIndex="44"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_obldate"
                                        Format="dd/MM/yyyy"></asp:CalendarExtender>

                                </div>


                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="Agent1">
                                <asp:Label ID="Label14" runat="server" Text="Agent"></asp:Label>
                                <asp:TextBox ID="txt_Agent" runat="server" CssClass="form-control" placeholder="" ToolTip="Agent" AutoPostBack="true" OnTextChanged="txt_Agent_TextChanged" TabIndex="15"></asp:TextBox>
                            </div>


                        </div>
                        <div class="FormGroupContent4">
                            <div class="CFS_1">
                                <asp:Label ID="Label17" runat="server" Text="CFS"></asp:Label>
                                <asp:TextBox ID="txt_cfs" runat="server" CssClass="form-control" placeholder="" ToolTip="CFS" OnTextChanged="txt_cfs_TextChanged" AutoPostBack="true" TabIndex="18"></asp:TextBox>
                            </div>

                            <div class="CFSCode">
                                <asp:Label ID="Label19" runat="server" Text="CFS Code"></asp:Label>
                                <asp:TextBox ID="txt_cfscode" runat="server" CssClass="form-control" ToolTip="CFS Code" placeholder="" TabIndex="20"></asp:TextBox>
                            </div>
                            <div class="Bond">
                                <asp:Label ID="Label20" runat="server" Text="Bond #"></asp:Label>
                                <asp:TextBox ID="txt_Bond" ToolTip="Bond #" placeholder="" runat="server" CssClass="form-control" TabIndex="21"></asp:TextBox>
                            </div>
                            <div class="Truck">
                                <asp:Label ID="Label21" runat="server" Text="Truck / Train #"></asp:Label>
                                <asp:TextBox ID="txt_MMT" ToolTip="Truck / Train #" placeholder="" runat="server" CssClass="form-control" TabIndex="22"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="RemarksInput6">
                                <asp:Label ID="Label36" runat="server" Text="Remarks"></asp:Label>
                                <asp:TextBox ID="txt_remarks" runat="server" placeholder="" ToolTip="Remarks" CssClass="form-control" TabIndex="42"></asp:TextBox>
                            </div>
                        </div>


                        <div class="bordertopNew"></div>

                        <div class="FormGroupContent4 boxmodal">
                            <div class="ShipmentLeft hide">
                                <asp:Panel ID="shipment" runat="server" GroupingText="Shipment Type" ForeColor="Black" CssClass="">
                                    <%--<div class="div_radioN1">
                                    <asp:RadioButton ID="rdoConsol" runat="server" Text="Consol" CssClass="LabelValue2N" TabIndex="23"
                                        GroupName="radio" />
                                    <asp:RadioButton ID="rdoCoload" runat="server" Text="Co_Load" CssClass="LabelValue2N" TabIndex="24"
                                        GroupName="radio" />
                                    <asp:RadioButton ID="rdoFCL" runat="server" Text="FCL" CssClass="LabelValue2N" GroupName="radio" TabIndex="25" />
                                    <asp:RadioButton ID="rdoMCC" runat="server" Text="MCC" CssClass="LabelValue2N" GroupName="radio" TabIndex="26" />
                                    <asp:RadioButton ID="rdoBuyerConsol" runat="server" Text="Buyer Consol" CssClass="LabelValue2N" TabIndex="27"
                                        GroupName="radio" />
                                </div>--%>
                                </asp:Panel>
                            </div>

                        </div>
                        <div class="FormGroupContent4 boxmodal">

                            <div class="FormGroupContent4" style="background: #d3d3d336">
                                <div class="VSL">
                                    <asp:Label ID="Label22" runat="server" Text="Vsl Code"></asp:Label>
                                    <asp:TextBox ID="txt_CVslCode" runat="server" ToolTip="Vsl Code" placeholder="" CssClass="form-control inputcolor" TabIndex="28"></asp:TextBox>
                                </div>
                                <div class="Line">
                                    <asp:Label ID="Label23" runat="server" Text="Line  Code"></asp:Label>
                                    <asp:TextBox ID="txt_CLineCode" runat="server" placeholder="" ToolTip="Line  Code" CssClass="form-control inputcolor" TabIndex="29"></asp:TextBox>
                                </div>
                                <div class="AgentInput12">
                                    <asp:Label ID="Label24" runat="server" Text="Agent"></asp:Label>
                                    <asp:TextBox ID="txt_CAgent" runat="server" placeholder="" ToolTip="Agent" CssClass="form-control inputcolor" TabIndex="30"></asp:TextBox>
                                </div>
                                <div class="CallSign">
                                    <asp:Label ID="Label25" runat="server" Text="Call Sign"></asp:Label>
                                    <asp:TextBox ID="txt_callsign" runat="server" CssClass="form-control inputcolor" placeholder="" ToolTip="Call Sign" TabIndex="31"></asp:TextBox>
                                </div>
                                <div class="AprPort" style="margin-right: 1% !important">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label26" runat="server" Text="Arr Port"></asp:Label>
                                        <asp:TextBox ID="txt_CArrport" runat="server" placeholder="" ToolTip="Arr Port" CssClass="form-controlinputcolor" TabIndex="32" OnTextChanged="txt_CArrport_TextChanged" AutoPostBack="true"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="arrportflag" runat="server" Width="100%" />

                                </div>

                                <%--   </div>--%>
                                <div class="LastPort" style="width: 11.7%; margin-right: 0.5%">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label27" runat="server" Text="Last Port"></asp:Label>
                                        <asp:TextBox ID="txt_CLastport" runat="server" placeholder="" ToolTip="Last Port" CssClass="form-control" TabIndex="33" OnTextChanged="txt_CLastport_TextChanged" AutoPostBack="true"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="lastportflag" runat="server" Width="100%" />

                                </div>
                                <div class="VSL" style="width: 11.5%;">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label28" runat="server" Text="Port 1"></asp:Label>
                                        <asp:TextBox ID="txt_CPort1" runat="server" ToolTip="Port 1" placeholder="" CssClass="form-control" TabIndex="34" OnTextChanged="txt_CPort1_TextChanged" AutoPostBack="true"></asp:TextBox>

                                    </div>


                                    <asp:Image ID="cport1flag" runat="server" Width="100%" />

                                </div>

                                <div class="Line" style="width: 11.6%; margin-right: 0px;">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label29" runat="server" Text="Port 2"></asp:Label>
                                        <asp:TextBox ID="txt_CPort2" runat="server" placeholder="" ToolTip="Port 2" CssClass="form-control" TabIndex="35" OnTextChanged="txt_CPort2_TextChanged" AutoPostBack="true"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="cport2flag" runat="server" Width="100%" />

                                </div>

                                <div class="FormGroupContent4">



                                    <div class="AgentInput12" style="width: 12.9%;">
                                        <asp:Label ID="Label30" runat="server" Text="Vsl.Type"></asp:Label>
                                        <asp:TextBox ID="txt_CVsltype" runat="server" placeholder="" ToolTip="Vsl.Type" CssClass="form-control" TabIndex="36"></asp:TextBox>
                                    </div>
                                    <div class="MasterInput">
                                        <asp:Label ID="Label34" runat="server" Text="Master"></asp:Label>
                                        <asp:TextBox ID="txt_CMaster" runat="server" placeholder="" ToolTip="Master" CssClass="form-control " TabIndex="40"></asp:TextBox>
                                    </div>
                                    <div class="NationInput">
                                        <asp:Label ID="Label35" runat="server" Text="Nation"></asp:Label>
                                        <asp:TextBox ID="txt_CNation" runat="server" placeholder="" ToolTip="Nation" CssClass="form-control" TabIndex="41"></asp:TextBox>
                                    </div>
                                    <div class="CallSign" style="width: 11.1%;">
                                        <asp:Label ID="Label31" runat="server" Text="GRT"></asp:Label>
                                        <asp:TextBox ID="txt_CGRT" runat="server" placeholder="" ToolTip="GRT" CssClass="form-control" TabIndex="37"></asp:TextBox>
                                    </div>
                                    <div class="AprPort" style="width: 12.2%;">
                                        <asp:Label ID="Label32" runat="server" Text="NRT"></asp:Label>
                                        <asp:TextBox ID="txt_CNRT" runat="server" placeholder="" ToolTip="NRT" CssClass="form-control" TabIndex="38"></asp:TextBox>
                                    </div>
                                    <div class="LastPort">
                                        <asp:Label ID="Label33" runat="server" Text="Total"></asp:Label>
                                        <asp:TextBox ID="txt_CTotal" runat="server" placeholder="" ToolTip="Total" CssClass="form-control" TabIndex="39"></asp:TextBox>
                                    </div>

                                </div>
                            </div>


                            <div class="FormGroupContent4">
                                <div class="GodOwn">
                                    <asp:Label ID="lblgodown" runat="server" Text="Godown #" CssClass="LabelValue"></asp:Label>
                                </div>
                                <div class="GodOwntext">
                                    <asp:TextBox ID="txt_Godown" runat="server" CssClass="form-control" TabIndex="45"></asp:TextBox>
                                </div>
                                <div class="Destuff">
                                    <asp:Label ID="lbldestuff" runat="server" Text="DeStuff" CssClass="LabelValue"></asp:Label>
                                </div>
                                <div class="DestuffCal">
                                    <asp:TextBox ID="dt_destuff" runat="server" CssClass="form-control" TabIndex="46"></asp:TextBox>
                                    <asp:CalendarExtender ID="dt_date6" runat="server" TargetControlID="dt_destuff"
                                        Format="dd/MM/yyyy"></asp:CalendarExtender>
                                </div>
                            </div>






                            <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" />


                            <div class="FormGroupContent4 boxmodal">
                                <div class="FormGroupContent4">
                                    <div class="txtCont">
                                        <asp:Label ID="Label37" runat="server" Text="Container #"></asp:Label>
                                        <asp:TextBox ID="txt_Container" runat="server" placeholder="" ToolTip="Container #" CssClass="form-control" TabIndex="45"></asp:TextBox>
                                    </div>
                                    <div class="FRDrop">
                                        <asp:Label ID="Label38" runat="server" Text="Base/Unit"></asp:Label>
                                        <asp:DropDownList ID="ddl_cmbSize" runat="server" ToolTip="Base/Unit" CssClass="chzn-select" data-placeholder="Base/Unit" TabIndex="46">
                                            <asp:ListItem Value="0" Text=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="SealC2">
                                        <asp:Label ID="Label39" runat="server" Text="Seal #"></asp:Label>
                                        <asp:TextBox ID="txt_Seal" runat="server" CssClass="form-control" placeholder="" ToolTip="Seal #" TabIndex="47"></asp:TextBox>
                                    </div>
                                    <div class="PKGInput2">
                                        <asp:Label ID="Label40" runat="server" Text="Pkgs"></asp:Label>
                                        <asp:TextBox ID="txt_Pkgs" runat="server" CssClass="form-control" placeholder="" ToolTip="Pkgs" TabIndex="48"></asp:TextBox>
                                    </div>
                                    <div class="WTInput1">
                                        <asp:Label ID="Label41" runat="server" Text="Wt(MT)"></asp:Label>
                                        <asp:TextBox ID="txt_Wt" runat="server" CssClass="form-control" placeholder="" ToolTip="Wt(MT)" TabIndex="49"></asp:TextBox>
                                    </div>
                                    <div class="ISOCode">
                                        <asp:Label ID="Label42" runat="server" Text="ISO Code"></asp:Label>
                                        <asp:TextBox ID="txt_isocode" runat="server" CssClass="form-control" placeholder="" ToolTip="ISO Code" TabIndex="50"></asp:TextBox>
                                    </div>
                                    <div class="SOCFlag">
                                        <asp:Label ID="Label43" runat="server" Text="Soc Flag"></asp:Label>
                                        <asp:TextBox ID="txt_SocFlag" runat="server" CssClass="form-control" placeholder="" ToolTip="Soc Flag" TabIndex="51"></asp:TextBox>
                                    </div>
                                    <div class="FloatLeftAdd btn ico-add" id="btn_add1" runat="server">
                                        <asp:Button ID="btn_add" runat="server" Text="Add" ToolTip="Add" OnClick="btn_add_Click" TabIndex="52" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                    </div>
                                </div>

                                <div class="FormGroupContent4">
                                    <div class="panel_05 MB0">
                                        <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grd_RowDataBound"
                                            BorderStyle="None" OnSelectedIndexChanged="grd_SelectedIndexChanged" OnRowCommand="grd_RowCommand" OnRowDeleting="grd_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="containerno" HeaderText="Container #" />
                                                <asp:BoundField DataField="sizetype" HeaderText="Size" ItemStyle-HorizontalAlign="Right">
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sealno" HeaderText="Seal #" DataFormatString="{0:#,##0.00}"
                                                    ItemStyle-HorizontalAlign="Right">
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="total" HeaderText="Packages" ItemStyle-HorizontalAlign="Right">
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="weight" HeaderText="Weight" />
                                                <asp:BoundField DataField="isocode" HeaderText="Iso Code" />
                                                <asp:BoundField DataField="socflag" HeaderText="Soc Flag" />

                                                <%--<asp:TemplateField ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                 
                                    <asp:ImageButton ID="img_click" runat="server" Height="12px" Width="12px" ImageAlign="Middle" ImageUrl="~/images/left_arrow.png" OnClick="img_click_Click" />
                              
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete"
                                                            ImageUrl="~/images/delete.jpg" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" Width="30px" />
                                                    <HeaderStyle Wrap="false" Width="30px" />
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="custom-mt-05">
                                    <div class="panel_05">
                                        <asp:GridView ID="Grid_blno" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Grid FixedHeader"
                                            OnRowDataBound="Grid_blno_RowDataBound"
                                            OnSelectedIndexChanged="Grid_blno_SelectedIndexChanged">
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="">
                                    <asp:Panel ID="pnl_grd1" runat="server" Width="100%" Height="100%">
                                    </asp:Panel>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <%-- popup --%>
                                <asp:Label ID="lbl" runat="server"></asp:Label>
                                <asp:ModalPopupExtender ID="Grd_buying_popup" runat="server" PopupControlID="pnl_Buying" BehaviorID="programmaticModalPopupBehaviordf1"
                                    TargetControlID="lbl" CancelControlID="imgok" DropShadow="false">
                                </asp:ModalPopupExtender>

                                <asp:Panel ID="pnl_Buying" runat="server" CssClass="modalPopup" Style="display: none;">
                                    <div class="divRoated">
                                        <div class="DivSecPanel">
                                            <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                        </div>

                                        <asp:Panel ID="Panel2" runat="server" Visible="false" CssClass="Gridpnl">

                                            <asp:GridView ID="grd_Jobno" runat="server" AutoGenerateColumns="False" AllowPaging="false" ForeColor="Black" Width="100%"
                                                CssClass="Grid FixedHeader" PageSize="16" OnPageIndexChanging="grd_Jobno_PageIndexChanging" Visible="true"
                                                OnSelectedIndexChanged="grd_Jobno_SelectedIndexChanged" OnRowDataBound="grd_Jobno_RowDataBound">
                                                <Columns>

                                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                        <HeaderStyle Width="65px" />
                                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Job Type" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                                <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="55px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Vessel" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 155px">
                                                                <asp:Label ID="vesselname" runat="server" Text='<%# Bind("vesselname") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Voyage" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                                <asp:Label ID="voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="MBL #" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                                                <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ETA" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                                <asp:Label ID="eta" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ETB" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                                <asp:Label ID="etd" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="POL" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 85px">
                                                                <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 420px">
                                                                <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MLO / FFR" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 270px">
                                                                <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                <PagerStyle CssClass="GridviewScrollPager" />
                                            </asp:GridView>

                                        </asp:Panel>

                                        <div class="query_break"></div>

                                        <asp:Panel ID="Panelreuse" runat="server" Visible="false" CssClass="Gridpnl ML4">

                                            <asp:GridView ID="Grd_reuse" runat="server" AutoGenerateColumns="False" AllowPaging="false" ForeColor="Black" Width="100%"
                                                CssClass="Grid FixedHeader" PageSize="10" OnPageIndexChanging="Grd_reuse_PageIndexChanging" Visible="true"
                                                OnSelectedIndexChanged="Grd_reuse_SelectedIndexChanged" OnRowDataBound="Grd_reuse_RowDataBound">
                                                <Columns>

                                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                        <HeaderStyle Width="65px" />
                                                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Job Type" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                                <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="55px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Vessel" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                                <asp:Label ID="vesselname" runat="server" Text='<%# Bind("vesselname") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Voyage" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                                <asp:Label ID="voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="MBL #" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                                <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ETA" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                                <asp:Label ID="eta" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ETB" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                                <asp:Label ID="etd" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="POL" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                                <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                                <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MLO / FFR" HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                                <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                <PagerStyle CssClass="GridviewScrollPager" />
                                            </asp:GridView>

                                        </asp:Panel>

                                        <div class="query_break"></div>
                                    </div>
                                </asp:Panel>

                            </div>

                            <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                <div class="divRoated">
                                    <div class="LogHeadLbl">
                                        <div class="LogHeadJob">
                                            <label>Job # :</label>

                                        </div>
                                        <div class="LogHeadJobInput1">

                                            <asp:Label ID="JobInput" runat="server"></asp:Label>

                                        </div>

                                    </div>
                                    <div class="DivSecPanel">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                    </div>

                                    <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                                        <asp:GridView ID="GridViewlog" CssClass="GridNew FixedHeader" runat="server" AutoGenerateColumns="true"
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
                    <div class="rightside">

                        <div class="FormGroupContent4">
                            <div class="right_btn" style="width: 40%">
                                <div class="JobInput12">
                                    <span>Job #</span>

                                    <asp:TextBox ID="txt_jobno" runat="server" CssClass="form-control" ToolTip="Job #" placeholder="" AutoPostBack="True" TabIndex="1" MaxLength="6"
                                        OnTextChanged="txt_jobno_TextChanged"></asp:TextBox>
                                </div>
                                <asp:LinkButton ID="lbl_lnkrate" runat="server" Text="" ForeColor="red" CssClass="anc ico-find-sm" Style="text-decoration: none;"
                                    OnClick="lbl_lnkrate_Click"></asp:LinkButton>
                                <div class="JobInput13">
                                    <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
                                    <asp:TextBox ID="dt_jobdate" runat="server" CssClass="form-control" ToolTip="Job Date" placeholder="" TabIndex="2"></asp:TextBox>
                                    <asp:CalendarExtender ID="dt_validity" runat="server" TargetControlID="dt_jobdate"
                                        Format="dd/MM/yyyy"></asp:CalendarExtender>
                                </div>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <span>Search</span>
                            <asp:TextBox ID="txt_search" placeholder="Search" runat="server" ToolTip="Search" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_search_TextChanged"></asp:TextBox>
                        </div>

                        <div class="FormGroupContent4">
                            <asp:Panel ID="Book2" runat="server" CssClass="gridpnl" Width="100%">
                                <asp:GridView ID="grdBookJob" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader" Height="100%"
                                    ShowHeaderWhenEmpty="true" OnPreRender="grdBookJob_PreRender">
                                    <Columns>
                                        <asp:BoundField ControlStyle-CssClass="hide" DataField="bookingno" HeaderText="Booking No">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField runat="server" DataField="shiprefno" HeaderText="Booking No">
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField runat="server" DataField="bookingdate" HeaderText="Date">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField runat="server" DataField="customername" HeaderText="CustomerName">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>

                                        <asp:BoundField runat="server" DataField="quotno" HeaderText="Quotation #">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" CssClass="hide" />
                                        </asp:BoundField>

                                        <asp:BoundField runat="server" DataField="POD" HeaderText="POD">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField runat="server" DataField="PLD" HeaderText="PLD">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkMail" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField runat="server" DataField="bl#" HeaderText="Customer Ref #">
                                            <HeaderStyle Width="100px" CssClass="hide" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="100px" CssClass="hide" />
                                        </asp:BoundField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="GrdRowStyle" />
                                    <HeaderStyle CssClass="GridviewScrollHeader" />
                                    <RowStyle CssClass="GridviewScrollItem" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                    </div>

                </div>

            </div>
        </div>
    </div>


    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>


    <%--mbl--%>

    <asp:Panel ID="pnl_emp" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <%--<asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />--%>
                                                     <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Close_voucher_Click">
    <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
</asp:LinkButton>
            </div>
            <asp:Panel ID="Panel3" runat="server" CssClass="">
                <iframe id="iframe1" runat="server" frameborder="0"></iframe>
            </asp:Panel>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="pop_up" runat="server" PopupControlID="pnl_emp" DropShadow="false"
        TargetControlID="Label47" CancelControlID="Close_voucher" BehaviorID="Test2">
    </asp:ModalPopupExtender>

    <asp:Label ID="Label47" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <%--job--%>

      <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
      <div class="divRoated">
          <div class="DivSecPanel">
              <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
          </div>
          <asp:Panel ID="Panel5" runat="server" CssClass="">
              <iframe id="iframe2" runat="server" frameborder="0"></iframe>
          </asp:Panel>
      </div>
  </asp:Panel>
  <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel4" DropShadow="false"
      TargetControlID="Label48" CancelControlID="Close_voucher" BehaviorID="Test3">
  </asp:ModalPopupExtender>

  <asp:Label ID="Label48" runat="server" Text="Label" Style="display: none;"></asp:Label>





    <asp:HiddenField ID="hf_msg1" runat="server" />

    <asp:HiddenField ID="hf_intJobno" runat="server" />
    <asp:HiddenField ID="hf_vesselid" runat="server" />
    <asp:HiddenField ID="hf_porid" runat="server" />
    <asp:HiddenField ID="hf_custid" runat="server" />
    <asp:HiddenField ID="hf_intAgentid" runat="server" />
    <asp:HiddenField ID="hf_intMLOid" runat="server" />
    <asp:HiddenField ID="hf_cfsid" runat="server" />
    <asp:HiddenField ID="hf_hidid1" runat="server" />

    <asp:HiddenField ID="hf_podid" runat="server" />

    <asp:HiddenField ID="hf_intCFSid" runat="server" />

    <asp:HiddenField ID="hf_intjob" runat="server" />
    <asp:HiddenField ID="hf_intjobtype" runat="server" />
    <asp:HiddenField ID="hf_oldcont" runat="server" />
    <asp:HiddenField ID="hdnCarrier" runat="server" />
    <asp:HiddenField ID="hidbooking" runat="server" />
    <asp:HiddenField ID="hid_splitbl" runat="server" />
</asp:Content>

