<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Afterjobcloseapproval_finance.aspx.cs" Inherits="logix.FAForm.Afterjobcloseapproval_finance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />

    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />

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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>


     <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
      <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />


 
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
            margin: 0 5px 0 8px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
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
            left: 21.5px !important;
        }

        .div_chat {
            width: 85%;
            float: left;
            margin-top: 2%;
        }

        .btn.btn-service1 {
            display: none;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 1042px;
            Height: 555px;
            margin-left: 0%;
            margin-top: -1.5%;
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
            margin-left: 98.3%;
            margin-top: -2%;
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
            top: 73px !important;
        }

        .PendingTbl2 {
            float: left;
            margin: 30px 0 0 10px;
            overflow: hidden;
            width: 100%;
        }

        .Unclosed {
            float: left;
            margin: 0;
            width: 19%;
        }

        #panelservice {
            float: left;
        }

        .PendingBooking {
            float: left;
            margin: -19px 0 0 5px;
            width: 218px;
        }

        .PortCountryC {
            float: left;
            width: 195px;
            margin: -19px 0px 0px 20px;
        }

        .Chart2 {
            width: 400px;
            height: 300px;
            margin-left: 20px;
        }

        .PendingBooking h3 {
            color: var(--grey);
            font-family: "OpenSansSemibold";
            font-size: 14px;
            margin: 0;
            padding: 5px 0 10px 0px;
        }

        .PendingRightnew {
            float: left;
            width: 218px;
            margin: 0px 0px 0px 65px;
        }

        .hide {
            display: none;
        }

        .Div_GridHome {
            width: 100%;
            float: left;
            height: 185px;
            overflow: auto;
        }

        .PendingTbl3 {
            width: 677px;
            float: left;
            margin: 5px 0px 0px 0px;
            min-height: 364px;
            overflow: auto;
        }

        .PendingRightnew {
            float: left;
            width: 218px;
            margin: 0px 0px 0px 10px;
        }

        .PendingRightnewLRightNew {
            float: left;
            width: 730px;
            margin: -48px 0px 0px 0px;
        }

        .PendingRightnew1 {
            float: right;
            width: 218px;
            margin: 23px -35px 0px 0px;
        }

        .PendingRightnewComapp {
            float: left;
            width: 100%;
            margin: 0px;
        }

        .div_GridNew {
            height: 300px;
            width: 100%;
            overflow: auto !important;
        }

        .PendingRightnew h3 {
            color: #4e4c4c;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: -3px 0 5px;
            padding: 2px 5px 0 0;
            width: 928px;
        }

        .PortCountry {
            float: left;
            width: 100%;
            margin: 0px 0px 10px 0px;
        }

        .PendingLeft {
            float: left;
            width: 358px;
            margin: 11px 5px 0px 0px;
        }

        .PendingLeftNew {
            float: left;
            width: 215px;
            margin: 0px 0.5% 0px 0px;
        }

        .PendingRightnewJobinfo {
            float: left;
            margin: 2px 0 0 0px;
            width: 71.5%;
        }

        .PendingTblGrid {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
        }

        .PendingTblN3 {
            height: 384px;
            border-collapse: collapse;
            overflow: auto;
            border: 1px solid #b1b1b1;
            margin: 10px 0px 0px 0px;
        }

        .PendingTblNGrid {
            border-collapse: collapse;
        }

            .PendingTblNGrid th {
                text-align: center;
                color: #fff;
                font-size: 11px;
                font-family: sans-serif, Geneva, sans-serif;
                background-color: #003a65;
                padding: 2px 0px 2px 3px;
                margin: 0px;
            }

            .PendingTblNGrid td {
                font-family: sans-serif, Geneva, sans-serif;
                font-size: 11px;
                color: #515151;
                border: 1px solid #b1b1b1;
                padding: 5px;
            }

        .PendingLeft3 {
            float: left;
            width: 210px;
            margin: 0px 0.5% 0px 0.5%;
        }

        #PieChart1__ParentDiv {
            border: 0px solid #f00 !important;
        }

        .GridHeightN1 {
            border: 1px solid #b1b1b1;
        }

        .TBLHeightN1 {
            height: 193px;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 32px;
            padding: 2px 2px 2px 5px;
            width: 100%;
        }

            .BandTop img {
                padding: 0px 1px 0px 1px;
            }

            .BandTop h3 {
                color: #ffffff;
                padding: 2px 0px 2px 0px;
                margin: 0px 0px 0px 0px;
            }

                .BandTop h3 a {
                    color: #ffffff;
                    font-size: 11px;
                    font-family: sans-serif;
                    padding: 2px 0px 2px 0px;
                    margin: 0px 0px 0px 0px;
                    /*font-size: 63.5%;*/
                }

        .BandLeft {
            float: left;
            width: 76%;
        }

        .BandRight {
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .PendingTblUC3 {
            float: left;
            margin: 5px 0 0 0px;
            height: 365px;
            overflow: auto;
            width: 929px;
        }

        .PendingRightJob {
            float: left;
            margin: 0 0 0 5px;
            width: 100%;
        }

        .PendingTblJob3 {
            float: left;
            margin: 5px 0 0 0px;
            height: 390px;
            overflow: auto;
            width: 99%;
        }

        .PendingLeft h3 {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 10px 0 8px;
            padding: 2px 5px 0 0;
            width: 370px;
        }

        .Unclosed h3 {
            color: #184684;
            font-family: "OpenSansSemibold";
            font-size: 14px;
            margin: 5px 0 0;
            padding: 5px 0 10px;
        }

        .Hide {
            display: none;
        }

        .TitleLeft2 {
            float: left;
            margin: 0px 0% 0px 0px;
        }

        #table#logix_CPH_Grd_Approval th:nth-child(3) {
            width: 150px;
            min-width: 150px;
        }

        #table#logix_CPH_Grd_Approval td:nth-child(3) {
            width: 150px;
            min-width: 150px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
            display: block;
        }

        div#logix_CPH_Panel4 {
            margin: 0px 0px 0px -7px;
        }

        div#logix_CPH_div_iframe {
            position: relative;
            top: 8px;
        }

        .BlueOuterDiv {
            margin: 5px 8px 0px 3px;
        }

        .widget.box .widget-header {
            border-bottom-color: #d9d9d9;
            /* line-height: 35px; */
            padding: 7px 12px;
            margin-bottom: 0;
        }

        .RedOuterDiv {
            width: 13.7%;
        }

        .widget-header h4 {
            display: block !important;
        }

        .widget.box .widget-header h4 {
            margin-bottom: 0;
            padding-left: 12px !important;
        }

        .BandMiddle {
            width: 100%;
        }

        .widget-content {
            padding: 0 5px !important;
        }

        table#logix_CPH_Gridexrate td:not(:first-child) {
            text-align: right;
        }

        table#logix_CPH_Grd_Approval td:last-child {
            max-width: 100px;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .HomeMenuContent {
            margin: -30px 0 0;
        }

        table#logix_CPH_Gridexrate {
            position: relative;
            top: 0;
            left: 0;
            border: 1px solid var(--inputborder);
        }

        .widget-content h3 {
            font-weight: 600;
        }

        table#logix_CPH_Grd_Approval th:nth-child(6) {
            width: 150px;
        }

        table#logix_CPH_Grd_Approval td:nth-child(6) {
          width: 252px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
        }

        .panel_18 {
    max-height: 80vh!important;
    min-height: 81vh!important;
}
        .panel_19{
            max-height: 84vh!important;
    min-height: 81vh!important;
        }
        div#logix_CPH_divexrate {
    width: 100%;
}
     
        /*.HomeMenuBox {
    width: 18% !important;
    float: left !important;
    margin: 0px 0px 0px 0px !important;
    display: flex !important;
    flex-direction: column !important;
    justify-content: space-around !important;
    height: 80vh !important;
}*/
        .HomeMenuContent {
    width: 82%;
    float: left;
}
        table#logix_CPH_Grd_Approval tbody td:nth-child(14) {
    text-align: center;
}
table#logix_CPH_Grd_Approval tbody td:nth-child(16) {
    text-align: center;
}
table#logix_CPH_Grd_Approval tbody td:nth-child(15) {
    text-align: center;
}
 
table#logix_CPH_Grd_Approval tbody td:nth-child(17) {
    text-align: center;
}
table#logix_CPH_Grd_Approval tbody td:nth-child(23) {
    text-align: center;
}
table#logix_CPH_Grd_Approval tbody td:nth-child(25) {
    text-align: center;
}

.ico-view input {
   
    height: 30px !important;
    width: 30px !important;
}
.ico-edit input {

    height: 30px !important;
    width: 30px !important;
}
.ico-approve input {

    height: 30px !important;
    width: 30px !important;
}
.ico-download input {
    height: 30px !important;
    width: 30px !important;
}
.ico-edit input {
    background-size: 44% !important;
}
.ico-download input {
    background-size: 30% !important;

}
table input[type="submit"], table input[type="button"] {
    padding: 0px 5px !important;
    border: 0px solid #b1b1b1 !important;
    font-weight: bold !important;
    border-radius: 3px !important;
}
table input[type="submit"], table input[type="button"] {
    padding: 0px 5px !important;
    border: 0px solid #b1b1b1 !important;
    font-weight: 400 !important;
    border-radius: 3px !important;
    font-size: 11px !important;
}
/*table#logix_CPH_GrdPort1 tbody td:nth-child(3) {
    background: gray;
    display: inline-block;
    border-radius: 138px;
    text-align: center !important;
    color: white !important;
    height: 36px !important;
    width: 40px !important;
    padding: 9px !important;
}*/
.gridl{
    width:39%;
    float:left;
    margin:8px 0.5% 0px 0px;
}
.gridr{
    width:60.5%;
    float:left;
    margin:44px 0px 0px 0px;
}
.chzn-drop {
    width: 100% !important;
    min-height: 150px !important;
    max-height: fit-content !important;
    height: 217px !important;
    overflow: auto;
}
    </style>
    <%--TEST--%>

    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
     <style type="text/css">
        .TitleLeft1 {
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .TitleLeft2 {
            float: left;
            margin: 0px 0% 0px 0px;
        }

        #div_floatleft {
            margin-bottom: 0px;
        }

        .PendingTblGrid th {
            background-color: #003a65;
            color: #fff;
            font-family: sans-serif,Geneva,sans-serif;
            font-size: 11px;
            margin: 0;
            text-align: center;
        }

        .GrdAltRow {
            background-color: #cee9fd;
            color: Black;
            font-family: sans-serif;
            font-size: 8pt;
            margin-bottom: 0;
            margin-left: 4px;
        }

        .PendingRightnewChart {
            float: left;
            width: 30%;
            margin: 0px 5px 0 5px;
            background-color: var(--white);
            position: relative;
            left: -20px;
        }

        .PendingRightnew1Chart {
            float: left;
            margin: 0px 0 0 0px;
            background-color: var(--white);
            position: relative;
            left: -30px;
            width: 49%;
        }

        .widget.box1 {
            float: left;
            height: 399px;
            margin-left: 13px;
            width: 99%;
        }

        .PendingRight {
            float: left;
            margin: 11px 0 0 0px;
            width: 27.7%;
        }

        .PendingRightPR {
            float: left;
            margin: 11px 0 0 5px;
            width: 71.5%;
        }

        .PendingRightU {
            float: left;
            margin: 11px 0 0 0px;
            width: 100%;
        }

            .PendingRightU h3 {
                color: var(--grey);
                float: left;
                font-family: sans-serif;
                font-size: 11px;
                padding: 2px 5px 0 0px;
                width: 100px;
            }

        .PendingTblU3 {
            float: left;
            margin: 5px 0 0 -11px;
            height: 362px;
            border: 1px solid #b1b1b1;
            overflow: auto;
            width: 99%;
        }

        .PortCountryJob {
            float: left;
            margin: 0px 0px 10px;
            width: 100%;
        }

            .PortCountryJob h3 {
                color: #005b9a;
                float: left;
                font-family: sans-serif;
                font-size: 11px;
                font-weight: bold;
                margin: 4px 0px -2px;
                padding: 2px 5px 0 0;
                width: 700px;
            }

        .PendingRight h3 {
            color: var(--grey);
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            margin: 10px 0 8px;
            padding: 2px 5px 0 0;
            width: 70%;
        }

        .MarginCtrl1 {
            margin: 0px 15px 0px 0px !important;
        }

        .CustomerWiseHead {
            width: 200px;
            float: left;
        }

        .MB4 {
            margin-bottom: 4px;
        }

        .PendingRightPR h3 {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 10px 0 8px;
            padding: 2px 5px 0 0;
            width: 312px;
        }

        /*.MR13 {
            margin-right: 24px;
        }*/

        .Grid {
            width: 100% !important;
        }

        .Unclosed1Job {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 0px 0 8px;
            padding: 7px 5px 0 0;
            width: 312px;
        }

        .unclosedlbl {
            color: #005b9a;
            float: left;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: 10px 0 0px;
            padding: 0px 2px 0px 0px;
            width: 370px;
        }

        .PendingTblGrid td {
            white-space: nowrap !important;
        }

        .PendingTblGrid th {
            white-space: nowrap !important;
        }

        .BlueOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 90px;
            padding: 15px 0px 5px 0px;
            width: 13.7%;
            margin: 5px 8px 0px 8px;
        }

        div#UpdatePanel1 {
            height: fit-content;
            overflow-x: hidden;
            overflow-y: auto;
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
            height: 90px;
            padding: 15px 0px 5px 0px;
            width: 13.7%;
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
            height: 90px;
            padding: 15px 0px 5px 0px;
            width: 13.7%;
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
            height: 90px;
            padding: 15px 0px 5px 0px;
            width: 13.7%;
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
            height: 90px;
            padding: 15px 0px 5px 0px;
            width: 13.7%;
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
            height: 90px;
            padding: 15px 0px 5px 0px;
            width: 13.7%;
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
            border-left: 0.25rem solid #e74a3b !important;
            float: left;
            background-color: #fff;
            height: 90px;
            padding: 15px 0px 5px 0px;
            width: 194px;
            margin: 5px 4px 0px 0px;
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
            background-color: #fff !important;
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
            width: 30px;
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

        a#logix_CPH_lbl_blrelease, a#logix_CPH_link_pending {
            margin-bottom: 5px !important;
            display: inline-block;
        }

        div#logix_CPH_rightbookingno {
            width: 64.6%;
        }

        div#logix_CPH_div_iframe {
            top: 5px !important;
        }

        .widget-header span {
            padding-left: 5px;
        }
    </style>

    <style type="text/css">
        @media only screen and (max-width: 1280px) {

            .PortCountry {
                float: left;
                width: 100%;
                margin: 0px 0px 10px 0px;
            }

            .PendingTblUC3 {
                float: left;
                margin: 5px 0 0 0px;
                height: 365px;
                overflow: auto;
                width: 100%;
            }
        }

        .PendingRightnew1Chart,
        .PendingRightnewChart {
            display: none;
        }
        span#logix_CPH_Label3 {
    position: relative;
    top: 22px;
}
        .gridpnl {
   /*height: calc(100vh - 130px);*/
    overflow: auto;
}
        .BillType1.blueheighlight.TextField {
    float: left;
    margin: 0px 0px 9px 0px;
}
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 0px !important;
}
        .tblbtn {
    display: inline-block;
    text-align: center;
    top: 0px;
    left: 0px;
    float: left;
    padding: 1px;
    margin: 0px 2px 0px 2px;
}
        .tblbtn {
    position: relative !important;
    z-index: 1 !important;
}
        .tblbtn input[type="submit"], .btn input[type="button"] {
    overflow: hidden;
    width: 28px !important;
    height: 28px !important;
    text-indent: -99em;
}
        .VoyageInputN4New {
    float: left;
    width: 15%;
    margin: 0px 0.5% 0px 0px;
}
    </style>
      <script type="text/javascript">

          function dropdown(sender, args) {
              $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
          }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
         <div runat="server" id="div_ComApproval" class="PendingRightnewComapp" >
                       

                            <div class="widget box" runat="server" id="div_iframe">

                                <div class="widget-header">
                                    <div>
                                    <p>
                                        <i class="icon-umbrella hide"></i>
                                        <asp:Label ID="lbl_Header" runat="server" Text="Invoice Proforma To Commercial"  Visible="false" ></asp:Label>
                                       
                                    </p>
                                        </div>
                                </div>

                               
                                <div class="widget-content">
                                    <div class="FormGroupContent4">
                                         <div class="VoyageInputN4New">
                                <asp:Label ID="Label2" runat="server" Text="Product"> </asp:Label>
                                <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="AE" Text="Air Exports"></asp:ListItem>
                                    <asp:ListItem Value="AI" Text="Air Imports"></asp:ListItem>
                                    <asp:ListItem Value="CH" Text="Custom House Agent"></asp:ListItem>
                                    <asp:ListItem Value="FE" Text="Ocean Exports"></asp:ListItem>
                                    <asp:ListItem Value="FI" Text="Ocean Imports"></asp:ListItem>

                                    <%-- <asp:ListItem Value="BT" Text="Bonded Trucking"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                                         <div class="BillType1 blueheighlight">
                            <asp:label id="Labell" runat="server" text="Voucher Type"></asp:label>
                            <asp:dropdownlist id="ddl_voutype" tooltip="Voucher Type" runat="server"   autopostback="True" CssClass="chzn-select" width="100%" data-placeholder="Voucher Type" tabindex="3" onselectedindexchanged="ddl_voutype_SelectedIndexChanged">
                               <asp:ListItem Value="0" Text=""></asp:ListItem>
                                 
                                <asp:ListItem Value="2" Text="PURCHASE INVOICE"></asp:ListItem>
                                  <asp:ListItem Value="23" Text="PURCHASE INVOICE OC"></asp:ListItem>
                                   <asp:ListItem Value="1" Text="SALES INVOICE"></asp:ListItem>
                                <asp:ListItem Value="22" Text="SALES INVOICE OC"></asp:ListItem>
                                   <asp:ListItem Value="5" Text="OSSI"></asp:ListItem>
                                   <asp:ListItem Value="6" Text="OSPI"></asp:ListItem>
                               
                               
                              

                            </asp:dropdownlist>
                        </div>
                                        </div>
                                    <div class="FormGroupContent4">
                                        <%--Grd_Approval--%>
                                        <asp:Panel ID="panel" runat="server" CssClass="gridpnl MB0" Width="100%">

                                            <asp:GridView CssClass="Grid FixedHeader" ID="Grd_Approval" runat="server" AutoGenerateColumns="False" OnRowDataBound="Grd_Approval_RowDataBound"
                                                ForeColor="Black" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="Grd_Approval_SelectedIndexChanged" DataKeyNames="vouyear,customerid,voutypeid" OnPreRender="Grd_Approval_PreRender">
                                                <Columns>
                                                     <asp:TemplateField HeaderText="Sl #"><%--0--%>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                                    
                                                     <asp:BoundField DataField="voutype" HeaderText="Vou Type"><%--1--%>
                                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="vouno" HeaderText="Ref #"><%--2--%>
                                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="voudate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"><%--3--%>
                                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="bjno" HeaderText="BL #" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--4--%>
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" Width="100px" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                                    </asp:BoundField>

                                                   
                                                    <asp:TemplateField HeaderText="Customer / Vendor"><%--5--%>

                                                        <ItemTemplate>
                                                            <div class="wrap325">  <%-- changed from 150px to 400px.  Praveen 2023May30   --%> 
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" Width="420px"  /> <%-- Added width  420px.  Praveen 2023May30   --%> 
                                                        <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="curr" HeaderText="Currency" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"><%--6--%>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Right" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--7--%>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Right" Width="120px" /> <%-- Added width 120px.  Praveen 2023May30   --%> 
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="preparedby" HeaderText="Prepared by"><%--8--%>
                                                        <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" Width="170px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="tdstype" HeaderText="TDS Type" ><%--9--%>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="tdsdesc" HeaderText="TDS Desc" ><%--10--%>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                                    </asp:BoundField>

                                                    <%--NewOne--%>
                                                    <asp:BoundField DataField="tdssection" HeaderText="TDS Section" ><%--11--%>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="TDS %"  ><%--12--%>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TDSPERS" runat="server" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" Text='<%#Eval("tdsper")%>' ToolTip='<%#Eval("tdsper")%>' Style="width: 50px; text-align: right; border: 1px solid #e0e0e0" Enabled="false"></asp:TextBox>
                                                            <%--onkeyup="IsDoubleCheck_Grid(this);"  OnTextChanged="TDSPERS_TextChanged" AutoPostBack="true" --%>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="50px" />
                                                    </asp:TemplateField>

                                                    <%--NewOne--%>
                                                    <asp:TemplateField HeaderText="TDS Section" ><%--13--%> 
                                                        <HeaderStyle Wrap="false" />

                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddl_section" Width="100%" runat="server" data-placeholder="--Section--" ToolTip="Section" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" AutoPostBack="true" OnSelectedIndexChanged="ddl_section_SelectedIndexChanged" OnCellContentClick="Grd_TDS_CellContentClick">
                                                                <%-- CssClass="chzn-select"--%>
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="80px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="TDS Section" ><%--14--%>
                                                        <HeaderStyle Wrap="false" />

                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddl_section1" runat="server" Width="100%" data-placeholder="--Section--" ToolTip="Section" AutoPostBack="true" OnSelectedIndexChanged="ddl_section_SelectedIndexChanged1" OnCellContentClick="Grd_TDS_CellContentClick">
                                                                <%-- CssClass="chzn-select"--%>
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>

                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="80px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="TDS%" > <%--15--%>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtpercentage" runat="server" Enabled="false"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" Style="text-align: right; width: 50px; border: 1px solid #e0e0e0!important;"
                                                                onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                                                        </ItemTemplate>

                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="50px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount" ><%--16--%>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TDSAmount" runat="server" Text='<%#Eval("tdsamount","{0:n}")%>' ToolTip='<%#Eval("tdsamount")%>' Enabled="false" Style="text-align: right; width: 50px; border: 1px solid #e0e0e0!important;" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"></asp:TextBox>
                                                          
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="50px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Approve" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--17--%> <%--    Header Text changed from [Transfer] to [Approve]. Praveen 2023May30 --%>
                                                        <HeaderStyle Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Chk_transfer" runat="server" AutoPostBack="true" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View" Visible="false"><%--18--%>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lnk_job1" runat="server" CommandName="select" Font-Underline="false"
                                                                CssClass="Arrow">⇛</asp:LinkButton>
                                                            <br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="stamt" HeaderText="stamt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"> <%--19--%>
                                                        <HeaderStyle CssClass="Hide" />
                                                        <ItemStyle CssClass="Hide" />
                                                    </asp:BoundField>
                                                    <%--20--%>  
                                                    <asp:BoundField DataField="SupplyTo" HeaderText="SupplyTo" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                                        <HeaderStyle CssClass="Hide" />
                                                        <ItemStyle CssClass="Hide" />
                                                    </asp:BoundField>
                                                    <%--21--%>
                                                    <asp:BoundField DataField="DateApp" HeaderText="DateApp" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                                        <HeaderStyle CssClass="Hide" />
                                                        <ItemStyle CssClass="Hide" />
                                                    </asp:BoundField>
                                                    <%--22--%>
                                                    
                                                    <asp:BoundField DataField="tdstypename" Visible="false" HeaderText="tdstypename" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <%--23--%>
                                                    <asp:BoundField DataField="jobno" HeaderText="Job #/Vendor Ref#/Vendor Date" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"> <%--16--%>
                                                        <HeaderStyle Width="150px" />
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                     <asp:TemplateField HeaderText="Edit">  <%--24--%>
                                        <ItemTemplate>
                                            <div class="btn ico-edit" id="btn" runat="server">
                                <asp:Button ID="lnkedit" runat="server" Text="Edit" ToolTip="Edit" TabIndex="41" OnClick="lnkedit_Click" />
                            </div>
                                             
                                        </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Download">  <%--24--%>
                                        <ItemTemplate>
                                             <div class="btn ico-download">
                                <asp:Button ID="lnkdownload" runat="server" Text="Download" ToolTip="Download" TabIndex="41"  OnClick="lnkdownload_Click" />

                                                            </div>
                                            
                                        </ItemTemplate>
                                                                 <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="View"><%--25--%>
                                                        <ItemTemplate>
                                                          
                                                           
                                                            <div class="btn ico-view">
                                <asp:Button ID="Lnk_job" runat="server" ToolTip="View"  Text="View" CommandName="select" Font-Underline="false" />

                                                            </div>
                                                          
                                                            <br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Approve">  <%--26--%>
                                        <ItemTemplate>
                                             <div class="btn ico-approve">
                                <asp:Button ID="btn_Transfer" runat="server" Text="Approve" ToolTip="Approve" TabIndex="41" OnClick="btn_transfer_Click" />

                                                            </div>
                                          
                                        </ItemTemplate>
                                                                 <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                                     
                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>

                                        </asp:Panel>
                                        </div>

                                    

                                    <div class="FormGroupContent4">
                                         
                                            <div class="btn ico-cancel hide" id="btn_cancel1" runat="server">
                                                <asp:Button ID="btn_cancel" Text="Cancel" runat="server" ToolTip="Cancel"  OnClick="btn_cancel_Click" />
                                            </div>
                                        </div>
                                    

                                </div>
                           
                            </div>
                        </div>
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
        <asp:HiddenField ID="hid_type" runat="server" />
        <asp:HiddenField ID="hid_container" runat="server" />
        <asp:HiddenField ID="hid_debit" runat="server" />
        <asp:HiddenField ID="hid_credit" runat="server" />

        <asp:Label ID="Label1" runat="server" />

        <asp:HiddenField ID="hidlbl" runat="server" />

        <asp:HiddenField ID="hid_custid" runat="server" />
        <asp:HiddenField ID="hid_lngPQuot" runat="server" />
        <asp:Label ID="hid_Proinv" runat="server" />
        <asp:Label ID="hid_Cn" runat="server" />
        <asp:Label ID="hid_OsdN" runat="server" />
        <asp:Label ID="hid_oscn" runat="server" />

        <asp:HiddenField ID="hid_supplyto" runat="server" />
        <asp:HiddenField ID="hid_stamt" runat="server" />

        <asp:HiddenField ID="hid_refno" runat="server" />
        <asp:HiddenField ID="hid_vouyear" runat="server" />
        <asp:HiddenField ID="hid_invbkdated" Value="N" runat="server" />
        <asp:HiddenField ID="hid_cnopsbkdated" Value="Y" runat="server" />

        <asp:HiddenField ID="hid_invfc" runat="server" />
         <asp:Label ID="hid_ProinvFC" runat="server"/>
          <asp:Label ID="hid_CnFC" runat="server"></asp:Label>
        <asp:HiddenField ID="hid_paFC" runat="server" />
          <asp:HiddenField ID="hid_inv" runat="server" />
          <asp:HiddenField ID="hid_pa" runat="server" />
        <asp:HiddenField ID="hf_refno" runat="server" />
           <asp:HiddenField ID="hid_voutype" runat="server" />
         <asp:HiddenField ID="hid_voutypeid" runat="server" />
     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    </asp:Content>
