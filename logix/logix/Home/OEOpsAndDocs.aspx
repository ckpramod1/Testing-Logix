<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="OEOpsAndDocs.aspx.cs" Inherits="logix.Home.OEOpsAndDocs" %>

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
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script
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
   
    <script src="../js/script.js"></script>
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

        .modalPopup {
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

        .Gridpnl {
            width: 862px;
            Height: 498px;
            margin-bottom: 0.5%;
            margin-left: 0.2%;
            /*margin-left:0.2%;
            overflow-y :scroll;*/
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
            width: 666px;
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
    margin: 47px 5px 0px 49px;
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
            font-size: 14px;
            margin: 10px 0 8px;
            padding: 2px 5px 0 0;
            width: 370px;
        }
        div#logix_CPH_pnlGrdCuswise {
    height: calc(100vh - 130px);
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

     div#logix_CPH_panel {
    height: calc(100vh - 161px) !important;
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
      /*Moved to  By Praveen 14Jun2023*/
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
    width: 100%;
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
    background-size: 86% !important;
}
.ico-download input {
    background-size: 83% !important;

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
 
.gridl{
    width:40%;
    float:left;
    margin:8px 0.5% 0px 0px;
    display:none;
}
.gridr{
    width:59.5%;
    float:left;
    margin:47px 0px 0px 0px;
    display:none;
}
.BillType1 {
    width: 19%;
    float: right;
    margin: 0px 0% 0px 0.5%;
}
div#logix_CPH_ddl_voutype_chzn {
    width: 100% !IMPORTANT;
}
.PageHeight {
    padding-top: 0px;
    height: 100vh;
    padding-bottom: 8px;
}
  
  .card:hover > .span3 {
     color: #f67e09 !important;
}
    .card:hover > .span1 {
     color: #f67e09 !important;
}
        .card:hover > .cardborder {
        border: 1px solid #f67e09 !important;
}
        table#logix_CPH_Grd_Approval th:nth-child(1) {
    width: 4% !important;
}

table#logix_CPH_Grd_Approval th:nth-child(17) {
       width: 4% !important;

}
table#logix_CPH_Grd_Approval th:nth-child(16) {
    width: 4% !important;

}
table#logix_CPH_Grd_Approval th:nth-child(15) {
        width: 4% !important;

}
table#logix_CPH_Grd_Approval th:nth-child(14) {
       width: 4% !important;

}

table#logix_CPH_Grd_Approval th {
    position: sticky;
    z-index: 10;
}





        table#logix_CPH_Grd_Approval td:nth-child(1) {
   text-align:center;
}

table#logix_CPH_Grd_Approval td:nth-child(17) {
     text-align:center;

}
table#logix_CPH_Grd_Approval td:nth-child(16) {
      text-align:center;

}
table#logix_CPH_Grd_Approval td:nth-child(15) {
       text-align:center;

}
table#logix_CPH_Grd_Approval td:nth-child(14) {
      text-align:center;

}

/*Grid column freeze*/
div#logix_CPH_panel thead tr th:nth-child(1) {
    position: sticky !important;
    width: 80px !important;
    min-width: 80px !important;
    max-width: 80px !important;
    left: 0px !important;
    background-color: #eae7e7 !important;
    z-index: 100;
}
div#logix_CPH_panel thead tr th:nth-child(2) {
    position: sticky !important;
    width: 159px !important;
    min-width: 146px !important;
    max-width: 140px !important;
    left: 78px !important;
    background-color: #eae7e7 !important;
    z-index: 100;
}
      
div#logix_CPH_panel thead tr th:nth-child(3) {
    position: sticky !important;
    width: 65px !important;
    min-width: 65px !important;
    max-width: 65px !important;
    left: 225px !important;
    background-color: #eae7e7 !important;
    z-index: 100;
}
div#logix_CPH_panel thead tr th:nth-child(4) {
    position: sticky !important;
    width: 81px !important;
    min-width: 90px !important;
    max-width: 81px !important;
    left: 290px !important;
    background-color: #eae7e7 !important;
    z-index: 100;
}
div#logix_CPH_panel thead tr th:nth-child(5) {
    position: sticky !important;
    width: 94px !important;
    min-width: 176px !important;
    max-width: 94px !important;
    left: 380px !important;
    background-color: #eae7e7 !important;
    z-index: 100;
}
div#logix_CPH_panel thead tr th:nth-child(6) {
    position: sticky !important;
    width: 190px !important;
    min-width: 304px !important;
    max-width: 190px !important;
    left: 556px !important;
    background-color: #eae7e7 !important;
    z-index: 100;
    border-right: 1px solid #eae7e7;
}


div#logix_CPH_panel tbody tr td:nth-child(1) {
    position: sticky !important;
    width: 80px !important;
    min-width: 80px !important;
    max-width: 80px !important;
    left: 0px !important;
    background-color: #eae7e7 !important;
}
div#logix_CPH_panel tbody tr td:nth-child(2) {
    position: sticky !important;
    width: 200px !important;
    min-width: 140px !important;
    max-width: 200px !important;
    left: 80px !important;
    background-color: #eae7e7 !important;
    z-index: 10;
}

div#logix_CPH_panel tbody tr td:nth-child(3) {
    position: sticky !important;
    width: 65px !important;
    min-width: 65px !important;
    max-width: 65px !important;
    left: 225px !important;
    background-color: #eae7e7 !important;
}
div#logix_CPH_panel tbody tr td:nth-child(4) {
    position: sticky !important;
    width: 81px !important;
    min-width: 90px !important;
    max-width: 81px !important;
    left: 290px !important;
    background-color: #eae7e7 !important;
    z-index:10;

}
div#logix_CPH_panel tbody tr td:nth-child(5) {
    position: sticky !important;
    width: 90px !important;
    min-width: 176px !important;
    max-width: 90px !important;
    left: 380px !important;
    background-color: #eae7e7 !important;
    z-index:10;
    text-align:left !important;

}

div#logix_CPH_panel tbody tr td:nth-child(6) {
    position: sticky !important;
    width: 190px !important;
    min-width: 304px !important;
    max-width: 190px !important;
    left: 556px !important;
    background-color: #eae7e7 !important;
    z-index:10;
}

div#logix_CPH_panel tbody tr:hover {
    background: var(--labelorange) !important;
    cursor: pointer;
    border-top: 2px solid var(--labelorange) !important;
    border-left: 2px solid blue var(--labelorange) !important;
    border-bottom: 2px solid var(--labelorange) !important;
}
        table input[type="checkbox"] {
            margin: 0px !important;
            font-size: 14px !important;
            background: transparent;
            width: 27px;
            height: 20px;
        }
    </style>
    <%--TEST--%>

    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("[id*=lnk_PendingBooking]").click(function () {
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
                title: "Booking",
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

    <%--Edit--%>

    <%--Edit--%>
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
            margin: 47px 0 0 0px;
            width: 27.7%;
        }

        .PendingRightPR {
            float: left;
            margin: 47px 0 0 5px;
            width: 71.5%;
        }

        .PendingRightU {
            float: left;
            margin: 47px 0 0 0px;
            width: 100%;
        }

            .PendingRightU h3 {
                color: var(--grey);
                float: left;
                font-family: sans-serif;
                font-size: 14px;
                padding: 2px 5px 0 0px;
                width: 100px;
            }
            div#logix_CPH_Panel4 {
    height: calc(100vh - 64px) !important;
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
            div#logix_CPH_pnlPortCountry1 {
    height: calc(100vh - 64px);
}
            div#logix_CPH_Panel8 {
    height: calc(100vh - 100px);
}
            div#logix_CPH_Panel9 {
    height: calc(100vh - 74px);
}
      .PendingRight h3 {
    color: var(--grey);
    float: left;
    font-family: sans-serif;
    font-size: 14px !important;
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
            width: 450px;
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
   height: calc(100vh - 164px);
    overflow: auto;
}
        .BillType1.blueheighlight.TextField {
    float: left;
    margin: 37px 0px 9px 0px;
}
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 54px !important;
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
    width: 37px !important;
    height: 34px !important;
    text-indent: -99em;
}
        .HomeMenuBox {
    height: 108vh !important;
    display:none !important;
}
        div#logix_CPH_Panel7 {
    height: calc(100vh - 64px) !important;
}
         .span1 {
    color: #06529c !important;
}
/* .span2 {
color: #f8a350 !important;
    display: inline-block;
    width: 100%;
    margin-top: 12px !important;
}*/
 .span3 {
    color: #06529c !important;
    display: inline-block;
    width: 100%;
    transition:transform 0.5s ease;
}
.img {
     width: 30px !important;
    position: relative;
    top: -104px;
    left: 19px;
    
}
.cardborder {
    border: 1px solid #9f9b9b69;
    position: relative;
    top: 102px;
}
    .dynamic {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 140px;
    padding: 0px 50px 10px 50px;
    margin-top: 60px;
}
.card {
    padding: 0px;
    width: 200px;
    /* box-shadow: rgb(239 239 246 / 96%) 0px 0px 0px 0px, rgb(200 211 242) 5px 5px 9px 0px; */
    height: 130px !important;
    flex-direction: column;
    display: flex;
    /* border: 1px solid black; */
}
.card:hover{
     /*box-shadow: rgb(239 239 246 / 96%) 0px 0px 0px 0px, rgb(200 211 242) 5px 5px 9px 0px;*/
 /*    -webkit-box-shadow: 0 20px 40px rgba(72,78,85,.6) !important;
    box-shadow: 0 20px 40px rgba(72,78,85,.6) !important;
    -webkit-transform: translateY(-15px) !important;
    -moz-transform: translateY(-15px) !important;
    -ms-transform: translateY(-15px) !important ;
    -o-transform: translateY(-15px) !important;*/
 /*   transform: translateY(-6px) !important;
   box-shadow: 0px 12px 30px 0px rgba(0, 0, 0, 0.2);
  transition: all 800ms cubic-bezier(0.19, 1, 0.22, 1);
  cursor:pointer;*/

   box-shadow: 1px 8px 20px grey;
   transform: translateY(-4px) !important;
    -webkit-transition:  box-shadow .6s ease-in;
    cursor:pointer;
}

.box-shadow {
/*    -webkit-box-shadow: 0 1px 1px rgba(72,78,85,.6) ;
    box-shadow: 0 1px 1px rgba(72,78,85,.6) ;*/
    -webkit-transition: all .2s ease-out ;
    -moz-transition: all .2s ease-out ;
    -ms-transition: all .2s ease-out ;
    -o-transition: all .2s ease-out ;
    transition: all .2s ease-out !important;
}

.card h2 {
    font-size: 20px;
    margin: 0;
    color: black;
}

.card p {
    margin: 10px 0;
}



.card .span1 {
    color: #06529c !important;
    font-size: 16px !important;
    font-weight: 400 !important;
    cursor: pointer;
    min-height: 66px !important;
    position: relative;
    top: 72px;
    left: 0px;
    text-align: center;
}
.card .span2 {
  
     cursor: pointer;
     font-size:14px !important;
}
.card .span3 {
    font-size: 24px !important;
    font-weight: 500;
    position: relative;
    left: 100px;
    top: -56px;
    text-align: left;
}
.card img {
    scale: 1;
    margin-top: 15px;
    margin-left: 15px;
}
.span2 {
    display: none;
}



 

div#logix_CPH_btn_cancel1 {
    margin-right: 28px;
}

table#logix_CPH_Grd_Approval th:nth-child(25) {
    width: 4% !important;
}
table#logix_CPH_Grd_Approval th:nth-child(24) {
    width: 4% !important;
}
table#logix_CPH_Grd_Approval th:nth-child(23) {
    width: 4%;
}
table#logix_CPH_Grd_Approval th:nth-child(22) {
    width: 4% !important;
}
    </style>

    <script type="text/javascript">
        function DisableButton() {
            document.getElementById("<%=btn_transfer.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;
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
                    url: '../Home/OEOpsAndDocs.aspx/GetChartData',
                    data: '{}',
                    success:
                        function (response) {
                            drawchart1(response.d);
                        },

                    error: function () {
                        alertify.alert("Error loading data! Please try again.");
                    }
                });
            })
        })

        function drawchart1(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
            }
            new google.visualization.PieChart(document.getElementById('chartdiv')).
                draw(data, { width: "400", height: "330", title: "", colors: ['#4ebcd5', '#bce3c8', '#408fdc', '#5765b2'] });
        }
    </script>

    <noscript>
        Your browser does not support JavaScript!

    </noscript>

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
                    url: '../Home/OEOpsAndDocs.aspx/GetChartDataBooking',
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
                                       draw(data, { title: "" });

        }

    </script>
     <script type="text/javascript">
         function dropdownButton() {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }
     </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="maindiv">
    <%-- <div style="position: absolute; z-index: 999999999;">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <%--  <asp:Panel ID="Panel1" runat="server" Width="450" HorizontalAlign="Center">
                    <div id="IMGDIV" align="center" valign="middle" runat="server" style="left: 45%; top: 300px; visibility: visible; vertical-align: middle; z-index: 99999; position: absolute; height: 31px;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Loading.gif" />
                    </div>
                    <%-- </asp:Panel>
                </ProgressTemplate>
            </asp:UpdateProgress>

        </div>--%>
    <!-- Breadcrumbs line -->
    <!-- <div class="crumbs">
          <div class="DashboardLeft">
      <h3>Dashboard</h3>
      <span>Good Morning Rajkumar!</span>
      </div>
      <div class="DashCal">
        <img src="assets/img/cal_icon.png"> 
        <span> August, 19, 2016</span>
        </div>
      
      </div> -->
    <!-- /Breadcrumbs line -->
    <div class="Clear"></div>
    <div class="BandMiddle">
        <div class="BreadLabel" id="OptionDoc" runat="server"></div>
    </div>
    <div class="BandTop">
        <div class="BandLeft">
            <div class="TitleLeft1" style="display: none">
                <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png"><asp:LinkButton ID="link_button1" runat="server" Text="RequestNew Customer" OnClick="link_button1_Click"></asp:LinkButton></h3>
            </div>
            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/change_Job.png"><asp:LinkButton ID="LinkButton3" runat="server" Text="ChangeJob" OnClick="LinkButton3_Click"></asp:LinkButton>
                </h3>
            </div>
            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/amend_sb.png" alt="" /><asp:LinkButton ID="LinkButton13" runat="server" Text="AmendMBL#" OnClick="LinkButton13_Click"></asp:LinkButton>
                </h3>
            </div>

            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/amend_bl.png"><asp:LinkButton ID="LinkButton4" runat="server" Text="AmendBL#" OnClick="LinkButton4_Click"></asp:LinkButton>
                </h3>
            </div>

            <div class="TitleLeft2" id="LinkButtonfbl" runat="server">
                <h3>
                    <img src="../Theme/assets/img/amend_forward_bl.png"><asp:LinkButton ID="LinkButton7" runat="server" Text="AmendForwarderBL#" OnClick="LinkButton7_Click"></asp:LinkButton>
                </h3>
            </div>
            <div class="TitleLeft2" id="LinkButtonsb" runat="server">
                <h3>
                    <img src="../Theme/assets/img/amend_sb.png"><asp:LinkButton ID="LinkButton5" runat="server" Text="AmendSB" OnClick="LinkButton5_Click"></asp:LinkButton>
                </h3>
            </div>
            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/ex_rate.png"><asp:LinkButton ID="LinkButton6" runat="server" Text="ChangeExRate" OnClick="LinkButton6_Click"></asp:LinkButton>
                </h3>
            </div>
            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/costing.png"><asp:LinkButton ID="LinkButton8" runat="server" Text="Costing" OnClick="LinkButton8_Click"></asp:LinkButton>
                </h3>
            </div>
            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/uploaddocument.png"><asp:LinkButton ID="LinkButton9" runat="server" Text="UploadDoc" OnClick="LinkButton9_Click"></asp:LinkButton>
                </h3>
            </div>

            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/downlaodic_1.png"><asp:LinkButton ID="LinkButton14" runat="server" Text="DownloadDoc" OnClick="LinkButton14_Click"></asp:LinkButton>
                </h3>
            </div>

            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/query.png"><asp:LinkButton ID="LinkButton10" runat="server" Text="Query" OnClick="LinkButton10_Click"></asp:LinkButton>
                </h3>
            </div>
            <div style="float: left; margin: 0px 0% 0px 0px;" id="Lnk_eventslbl" runat="server">
                <h3>
                    <img src="../Theme/assets/img/events_ic.png" /><asp:LinkButton ID="Lnk_events" runat="server" Text="Events" OnClick="Lnk_events_Click"></asp:LinkButton></h3>
            </div>

            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/salesperson_ic.png"><asp:LinkButton ID="Sales_Person" runat="server" Text="AmendSalesPerson" OnClick="Sales_Person_Click"></asp:LinkButton>
                </h3>
            </div>

            <div class="TitleLeft2" style="display: none;">
                <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png" />
                    <asp:LinkButton ID="lnkNewCustomerRequest" runat="server" Text="InerBranchEDI" OnClick="lnkNewCustomerRequest_Click"></asp:LinkButton></h3>
            </div>

        </div>

        <div class="BandRight">
            <div class="TitleLeft2" style="display: none;">
                <h3>
                    <img src="../Theme/assets/img/salesperson_ic.png"><asp:LinkButton ID="lnk_Incomenotbook" runat="server" Text="Income Not Booked" OnClick="lnk_Incomenotbook_Click"></asp:LinkButton>
                </h3>
            </div>
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/BLRegister.png">
                    <asp:LinkButton ID="LinkButton11" runat="server" Text="BL Register" OnClick="LinkButton11_Click"></asp:LinkButton>
            </div>
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/job_ic.png">
                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Job Closing" OnClick="LinkButton2_Click"></asp:LinkButton>
            </div>
            <div style="float: left;">
                <h3>
                    <img src="../Theme/assets/img/customerprofile_ic.png"><asp:LinkButton ID="LinkButton1" runat="server" Text="Customer Profile" OnClick="LinkButton1_Click"></asp:LinkButton></h3>
            </div>
        </div>

    </div>

    <div class="HomeMenuBox ">
        <asp:LinkButton ID="lnk_blnum" runat="server" OnClick="lnk_blnum_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/booking.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Bookings </span>
                    <label id="spn_jobs" runat="server" class=" Amount1"></label>
                    <span id="spn_bl" runat="server" class=" Amount"></span>
                </div>
            </div>
            <div class="hide" id="BL1name" runat="server">BL</div>
        </asp:LinkButton>

        <asp:LinkButton ID="lnk_proInvoice" runat="server" OnClick="lnk_proInvoice_Click">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/proformainvoice.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Proforma Sales</span>
                    <span id="ProforInv" runat="server" class=" Amount"></span>
                </div>
            </div>
        </asp:LinkButton>

          <asp:LinkButton ID="lnk_proinfc" runat="server" OnClick="lnk_proinfc_Click"  Visible="false">
            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/proformainvoice.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Proforma Sales Invoice OC</span>
                    <span id="ProforInvfc" runat="server" class=" Amount" ></span>
                </div>
            </div>
        </asp:LinkButton>

        <asp:LinkButton ID="lnk_Prooncps" runat="server" OnClick="lnk_Prooncps_Click">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/proformacnops.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Proforma Purchase</span>
                    <span id="ProCNOps" runat="server" class="Amount"></span>

                </div>
            </div>
        </asp:LinkButton>
           <asp:LinkButton ID="lnk_procnopsfc" runat="server" OnClick="lnk_procnopsfc_Click" Visible="false">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/proformacnops.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Proforma Purchase Invoice OC</span>
                    <span id="ProCNOpsfc" runat="server" class="Amount"></span>

                </div>
            </div>
        </asp:LinkButton>
        <asp:LinkButton ID="lnk_ProOsdn" runat="server" OnClick="lnk_ProOsdn_Click" Visible="false">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/proformaosdn.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Proforma OSDN</span>
                    <span id="ProfOsDN" runat="server" class="Amount"></span>
                </div>
            </div>

        </asp:LinkButton>
        <asp:LinkButton ID="lnk_ProOscn" runat="server" OnClick="lnk_ProOscn_Click" Visible="false">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/proformaoscn.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Proforma OSCN</span>
                    <span id="ProfOscn" runat="server" class="Amount"></span>
                </div>
            </div>
        </asp:LinkButton>
        <asp:LinkButton ID="lnk_Blrelase" runat="server" OnClick="lnk_Blrelase_Click">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/do.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">
                        <span id="bl_Rel" runat="server"></span>
                    </span>
                    <span id="bl_relase" runat="server" class="Amount"></span>
                </div>
            </div>
        </asp:LinkButton>
        <asp:LinkButton ID="lnk_Unclosed" runat="server" OnClick="lnk_Unclosed_Click">

            <div class="menubox">
                <div class="menuboximage">
                    <img src="../Theme/assets/img/dashboard/openjobs.png" />
                </div>
                <div class="menuboxcontent">
                    <span class="title">Open Jobs</span>
                    <span id="Unclose_Job" runat="server" class="Amount"></span>
                </div>
            </div>
        </asp:LinkButton>
    </div>
    <%--     <div class="PendingRightnew1" id="div_line" runat="server">
            <asp:Literal ID="lt" runat="server"></asp:Literal>
            <div id="Liner_chart_div"></div>

        </div>--%>

    <div class=" HomeMenuContent">

        <div class="">
                                     <div class="dynamic" id="card_parent" runat="server">

                         <!-- Data will be rendered here -->
</div>
            <!-- Tabs-->
            <div class="">
                <%-- <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                <div class="widget-content">

                    <div id="div_floatleft" runat="server">
                        <div id="custid" class="PendingLeft" runat="server" visible="true">
                            <div class="CustomerWiseHead">
                                <h3 id="headlbl" runat="server">Customer Wise</h3>
                            </div>
                            <div class="right_btn ">
                                <asp:LinkButton ID="link_cust" runat="server" OnClick="link_cust_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                                </asp:LinkButton>

                                <div style="clear: both;"></div>
                            </div>

                            <asp:Panel ID="pnlGrdCuswise" runat="server" CssClass="gridpnl MB0" Visible="true" Width="100%" >
                                <asp:GridView ID="GrdCuswise" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="GrdCuswise_RowDataBound" OnSelectedIndexChanged="GrdCuswise_SelectedIndexChanged" OnPreRender="GrdCuswise_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="S#" HeaderText="S#">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="20px" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="true" Width="20px" />
                                        </asp:BoundField>

                                        <%-- <asp:BoundField DataField="Customer" HeaderText="">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="200px" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="200px"  />
                                            </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                    <asp:Label ID="CustomerName1" runat="server" Text='<%# Bind("Customer") %>' ToolTip='<%#Bind("Customer")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="180px" />
                                            <ItemStyle HorizontalAlign="Left" Width="180px" Wrap="false" />

                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Numbers" HeaderText="Bookings">
                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" Width="50px" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cusid" HeaderText="cusid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>

                        <%--  <div runat="server" id="div2" class="PendingRightnew">

                                    <ajax:PieChart ID="PieChart1" runat="server" ChartHeight="200" ChartWidth="350" ChartTitleColor="#0E426C" > 
                                     
                                    </ajax:PieChart>

                                     </div>--%>

                        <div id="rightbookingno" class="PendingRight" runat="server">

                            <div class="PortCountryJob">
                                <h3 id="headlbl1" runat="server">
                                    <asp:Label ID="lbl_cut" runat="server"></asp:Label>
                                </h3>
                                <div class="right_btn">
                                    <asp:LinkButton ID="lnk_cut1" runat="server" OnClick="lnk_cut1_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                                    </asp:LinkButton>

                                    <div style="clear: both;"></div>
                                </div>

                                <asp:Panel ID="Panel2" runat="server" Visible="false" CssClass="gridpnl MB0" Width="100%">
                                    <asp:GridView ID="GridView1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                        <%-- <Columns>
                        <asp:BoundField DataField="shiprefno" HeaderText="Booking#">
                            <ControlStyle  />
                            <HeaderStyle Width="600px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                                               <asp:BoundField DataField="job" HeaderText="Job#">
                            <ControlStyle  />
                            <HeaderStyle Width="600px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                                               </Columns>--%>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                    </asp:GridView>
                                </asp:Panel>

                            </div>
                        </div>

                        <%--<asp:Panel ID="panelservice" runat="server"  Visible="false" CssClass="Div_GridHome">
                                    <asp:GridView ID="pent_view" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader"  ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" AllowPaging="false" OnPageIndexChanging="pent_view_PageIndexChanging" PageSize="6" OnRowDataBound="pent_view_RowDataBound">
                                        <Columns>

                                            <asp:BoundField DataField="SI" HeaderText="S #">
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="15px" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="shiprefno" HeaderText="Booking #">
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="80px" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bookingdate" HeaderText="Date">
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="60px" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="quotno" HeaderText="Quot #">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="30px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="quotdate" HeaderText="Date">
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="60px" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="empname" HeaderText="Sales">
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="180px" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="MLO">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 105px">
                                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="105px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="job" HeaderText="Job #">
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="30" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>--%>
                    </div>

                    <div runat="server" id="div2_Bookchart" class="PendingRightnewLRightNew" visible="false">
                        <div id="chartdiv1" style="width: 800px; height: 330px; margin-left: 20px;">
                        </div>
                    </div>

                    <div class="Clear"></div>
                    <div runat="server" id="div_ComApproval" class="PendingRightnewComapp" visible="false">
                        <div class="">

                            <div class="widget box" runat="server" id="div_iframe">

                                <div class="widget-header">
                                    <p>
                                        <i class="icon-umbrella hide"></i>
                                        <asp:Label ID="lbl_Header" runat="server" Text="Invoice Proforma To Commercial"  Visible="false" ></asp:Label>
                                       
                                    </p>
                                </div>

                                <%-- <asp:ContentPlaceHolder ID="logix_CPH" runat="server"> --%>
                                <div class="widget-content">
                                    <div class="FormGroupContent4">
                                         <div class="BillType1 blueheighlight" style="display:none;">
                            <asp:label id="Labell" runat="server" text="Voucher Type"></asp:label>
                            <asp:dropdownlist id="ddl_voutype" tooltip="Voucher Type" runat="server"   autopostback="True" CssClass="chzn-select" width="100%" data-placeholder="Voucher Type" tabindex="3" onselectedindexchanged="ddl_voutype_SelectedIndexChanged" Visible="false">
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
                                                    <asp:BoundField DataField="bjno" HeaderText="BL #" ><%--4--%>
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
                                                                onkeyup="IsDoubleCheck_Grid(this);"  Text='<%#Eval("tdsper")%>' ToolTip='<%#Eval("tdsper")%>'  ></asp:TextBox>
                                                        </ItemTemplate>

                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="50px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount" ><%--16--%>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TDSAmount" runat="server" Text='<%#Eval("tdsamount","{0:n}")%>' ToolTip='<%#Eval("tdsamount")%>' Enabled="false" Style="text-align: right; width: 50px; border: 1px solid #e0e0e0!important;" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"></asp:TextBox>
                                                            <%--onkeyup="IsDoubleCheck_Grid(this);"  OnTextChanged="TDSPERS_TextChanged" AutoPostBack="true" --%>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="50px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Approve" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--17--%> <%--    Header Text changed from [Transfer] to [Approve]. Praveen 2023May30 --%>
                                                        <HeaderStyle Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Chk_transfer1" runat="server" AutoPostBack="true" />
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
                                                    <%--20--%> <%-- ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"--%>
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
                                                    <%--<asp:ButtonField CommandName="ColumnClickNew" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                    <asp:BoundField DataField="tdstypename" Visible="false" HeaderText="tdstypename" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <%--23--%>
                                                    <asp:BoundField DataField="jobno" HeaderText="Job #/Vendor Ref#/Vendor Date" > <%--16--%>
                                                        <HeaderStyle Width="150px" />
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                     <asp:TemplateField HeaderText="Edit">  <%--24--%>
                                        <ItemTemplate>
                                            <div class="btn ico-edit" id="btn" runat="server">
                                <asp:Button ID="lnkedit" runat="server" Text="Edit" ToolTip="Edit" TabIndex="41" OnClick="lnkedit_Click" />
                            </div>
                                             <%--<span class="btn ico-edit">
                                <asp:Button ID="btn_send" runat="server" ToolTip="view" TabIndex="41" />

                                                            </span>--%>
                                            <%--<asp:LinkButton ID="lnkedit" runat="server" Text="Edit"  Style="width: 60px; height: 20px; margin-left: 1%;" OnClick="lnkedit_Click" />--%>
                                                 <%--<asp:ImageButton ID="lnkedit" runat="server" ImageUrl="../Theme/assets/img/buttonIcon/active/edit.svg" Style="width: 24px; height: 24px; margin-left: 1%;" OnClick="lnkedit_Click" />--%>
                                        </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Download">  <%--24--%>
                                        <ItemTemplate>
                                             <div class="btn ico-download">
                                <asp:Button ID="lnkdownload" runat="server" Text="Download" ToolTip="Download" TabIndex="41"  OnClick="lnkdownload_Click" />

                                                            </div>
                                            <%--<asp:LinkButton ID="lnkdownload" runat="server" Text="Edit"  Style="width: 60px; height: 20px; margin-left: 1%;" OnClick="lnkdownload_Click" />--%>
                                                 <%--<asp:ImageButton ID="lnkdownload" runat="server" ImageUrl="../Theme/assets/img/buttonIcon/active/download.svg" Style="width: 24px; height: 24px;" OnClick="lnkdownload_Click" />--%>

                                        </ItemTemplate>
                                                                 <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="View"><%--25--%>
                                                        <ItemTemplate>
                                                          
                                                           
                                                            <div class="btn ico-view">
                                <asp:Button ID="Lnk_job" runat="server" ToolTip="View"  Text="View" CommandName="select" Font-Underline="false" />

                                                            </div>
                                                            <%--<asp:LinkButton ID="Lnk_job" runat="server" CommandName="select"  CssClass="viewicon"  Font-Underline="false" ><img src="../Theme/assets/img/buttonIcon/active/view.png" alt="" style="width: 24px; height: 24px;"/></asp:LinkButton>--%>
                                                     <%--<asp:ImageButton ID="Lnk_job" runat="server"  ImageUrl="../Theme/assets/img/buttonIcon/active/view.png" Style="width: 24px; height: 24px;"  />--%>
                                                           
                                                            <br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Approve">  <%--26--%>
                                        <ItemTemplate>
                                             <div class="btn ico-approve">
                                <asp:Button ID="btn_Transfer" runat="server" Text="Approve" ToolTip="Approve" TabIndex="41" OnClick="btn_transfer_Click" />

                                                            </div>
                                            <%--<asp:ImageButton ID="btn_Transfer" runat="server" ImageUrl="../images/Transfer.jpg" Style="width: 60px; height: 20px; margin-left: 1%;" OnClick="btn_transfer_Click" />--%>
                                                     <%--<asp:ImageButton ID="btn_Transfer" runat="server" ImageUrl="../Theme/assets/img/buttonIcon/active/approve.png" Style="width: 24px; height: 24px;"  OnClick="btn_transfer_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />--%>

                                        </ItemTemplate>
                                                                 <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Select"  ><%--17--%> <%--    Header Text changed from [Transfer] to [Approve]. Praveen 2023May30 --%>
     <HeaderStyle Width="20px" />
     <ItemTemplate>
         <asp:CheckBox ID="Chk_transfer" runat="server" />
     </ItemTemplate>
     <ItemStyle HorizontalAlign="Center" />
 </asp:TemplateField>
                                                    <%--14 ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"--%>
                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>

                                        </asp:Panel>
                                        </div>

                                    

                                    <div class="FormGroupContent4">
                                        <div class="left_btn">
                                            <div class="btn btn-service1"  id="btn_backdated_id" runat="server" visible="false">
                                                <asp:Button ID="btn_backdated" runat="server" Text="Service Tax" ToolTip="Service Tax" Visible="false" Enabled="false" />
                                                <%--OnClick="btn_backdated_Click"--%>
                                            </div>
                                        </div>
                                        <div class="right_btn">
                                            <div class="btn ico-delete" id="btn_delete_id" runat="server" Visible="false" >
                                                <asp:Button ID="btn_delete" Text="Delete" runat="server" ToolTip="Delete" Visible="false" />
                                            </div>
                                            <div class="btn ico-view" id="view_id"  runat="server" Visible="false"  >
                                                <asp:Button ID="btn_view" Text="View" runat="server"  ToolTip="View" Visible="false" />
                                            </div>

                                            <div class="btn ico-approve">
                                                <asp:Button ID="btn_transfer" Text="Approve" runat="server" ToolTip="Approve" OnClick="btn_transfer_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                            </div>
                                            <div class="btn ico-cancel hide" id="btn_cancel1" runat="server">
                                                <asp:Button ID="btn_cancel" Text="Cancel" runat="server" ToolTip="Cancel"  OnClick="btn_cancel_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <%--  </asp:ContentPlaceHolder> --%>
                            </div>
                        </div>

                    </div>
                    <div class="Clear"></div>

                    <div class="PendingRightnew1Chart" id="div_line" runat="server">
                        <asp:Literal ID="lt" runat="server"></asp:Literal>
                        <div id="Liner_chart_div" style="height: 345px!important"></div>

                    </div>
                    <div runat="server" id="div6" class="PendingRightnewChart">
                        <div id="chartdiv" style="width: 100%; height: 345px; margin-left: 20px;">
                        </div>
                    </div>

                 <%--   <div class="Unclosed" id="Exrate" runat="server">
                        <div style="display: none;">
                            <h3>
                                <img src="../Theme/assets/img/exrate_ic.png" />
                                <span>Ex Rate</span></h3>
                        </div>
                        <div class="PendingTbl2">
                            <asp:Panel ID="Panelexrate" runat="server" CssClass="" Visible="true">
                                <asp:GridView ID="Gridexrate" CssClass="Grid FixedHeader " runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnPreRender="Gridexrate_PreRender">
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
                    </div>--%>

                         <div id="divexrate" runat="server">

                        
                             <div class="FormGroupContent4">
                            
                                 <div class="gridl">
                                          <div class="LabelHead">
                            <asp:Label Text="ExRate" ID="Label3" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn MT0 MT5">
                            <asp:LinkButton ID="lnkexpexrate" runat="server" OnClick="lnkexpexrate_Click">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel"  />
                            </asp:LinkButton>

                          
                        </div>
                        <div class=" FormGroupContent4 custom-d-flex tablebox">
                            <div class="custom-col"></div>
                            <div class="custom-w-30">Cost</div>
                            <div class="custom-w-30">Revenue</div>
                        </div>
                        <asp:Panel ID="Panel8" runat="server" CssClass="gridpnl MB0 " Visible="true" Width="100%">

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

                                    <%-- <asp:TemplateField HeaderText="LocalExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="typecr" runat="server" Visible="false" Text='<%# Bind("extype") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%-- <asp:BoundField DataField="extype" HeaderText="ExType" Visible="false" />--%>

                                    <asp:BoundField DataField="extype1" HeaderText="Type" Visible="false" />

                                    <asp:BoundField DataField="ExDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />

                                    <asp:BoundField DataField="excurr" HeaderText="Curr"></asp:BoundField>

                                    <asp:TemplateField HeaderText="Local">
                                        <ItemTemplate>
                                            <%--<asp:Textbox id="Txt_LocalExRate" runat="server" CssClass="form-control"   Text='<%# Bind("LoExRate") %>'  />--%>
                                            <asp:Label ID="Txt_LocalExRate" runat="server" Text='<%# Bind("localexrate_cost") %>' />

                                        </ItemTemplate>
                                          <ItemStyle CssClass="custom-w-15 align-right"  />
                                        <HeaderStyle CssClass="custom-w-15 align-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="OS">
                                        <ItemTemplate>
                                            <%--   <asp:Textbox id="Txt_OSExRate" runat="server"  CssClass="form-control"   Text='<%# Bind("OsExRate") %>'/>--%>
                                            <asp:Label ID="Txt_OSExRate" runat="server" Text='<%# Bind("osexrate_cost") %>' />

                                        </ItemTemplate>
                                           <ItemStyle CssClass="custom-w-15 align-right"  />
                                        <HeaderStyle CssClass="custom-w-15 align-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Local">
                                        <ItemTemplate>
                                            <%--<asp:Textbox id="Txt_LocalExRate" runat="server" CssClass="form-control"   Text='<%# Bind("LoExRate") %>'  />--%>
                                            <asp:Label ID="Txt_LocalExRate" runat="server" Text='<%# Bind("localexrate_revenue") %>' />

                                        </ItemTemplate>
                                          <ItemStyle CssClass="custom-w-15 align-right"  />
                                        <HeaderStyle CssClass="custom-w-15 align-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="OS">
                                        <ItemTemplate>
                                            <%--   <asp:Textbox id="Txt_OSExRate" runat="server"  CssClass="form-control"   Text='<%# Bind("OsExRate") %>'/>--%>
                                            <asp:Label ID="Txt_OSExRate" runat="server" Text='<%# Bind("osexrate_revenue") %>' />

                                        </ItemTemplate>
                                        <ItemStyle CssClass="custom-w-15 align-right"  />
                                        <HeaderStyle CssClass="custom-w-15 align-center" />
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="Old_LocalExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="old_LocalExRate" runat="server" CssClass="form-control" Visible="false" Text='<%# Bind("localexrate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Old_OSExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="old_OSExRate" runat="server" CssClass="form-control" Visible="false" Text='<%# Bind("osexRate1") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>

                        </asp:Panel>
                                     </div>
                                 <div class="gridr">
                      
                     <asp:Panel ID="Panel9" runat="server" CssClass="gridpnl MB0 " Visible="true" Width="100%">

                            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" Height="100%" Width="100%"
                                 ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader"   OnSelectedIndexChanged="GridView6_SelectedIndexChanged"
                                 OnRowDataBound="GridView6_RowDataBound">
                              

                                <Columns>

                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Event" HeaderText="Event" />

                                    <asp:BoundField DataField="pending" HeaderText="Pending"   />
                                    </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>

                        </asp:Panel>
                                     </div>
                                 </div>
                    </div>



















                    <%--<asp:Panel ID="panelApproval1" runat="server"  CssClass="modalPopupN2" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
                                 <div class="divRoated">
                                <div class="DivSecPanel"> <asp:Image ID="close4" runat="server" ImageUrl="~/images/close2.png"/>  </div>--%>

                    <%-- </asp:Panel>
                     <asp:Label ID="Label8" runat="server"></asp:Label>
                    <ajax:ModalPopupExtender ID="Pop_GrdApproval" runat="server" PopupControlID="panelApproval1"
                                        DropShadow="false" TargetControlID="Label8" CancelControlID="close4" BehaviorID="Test4">
                                    </ajax:ModalPopupExtender>--%>

                    <%--   <div class="PendingLeftNew">
                                    <h3 style="display:none;">
                                        <img src="../Theme/assets/img/penidng_events_ic.png" />
                                        Approval</h3>
                                    <asp:Panel ID="PanelPendingEvent" runat="server"  Visible="true" CssClass="TBLHeightN1">
                                        <asp:GridView ID="GrdPending" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPending_RowDataBound" OnSelectedIndexChanged="GrdPending_SelectedIndexChanged" Visible="false">
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>

                                </div>--%>

                    <div class="PendingRight" id="hid_pending" runat="server" style="display: none;">
                        <h3>
                            <img src="../Theme/assets/img/tols_ic.png" />
                            Pending Event</h3>
                        <div class="right_btn">
                            <asp:LinkButton ID="linkunclose" runat="server" OnClick="linkunclose_Click" Visible="false">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server" Visible="true" class="gridpnl MB0" Width="100%">
                            <asp:GridView ID="GrdOceanExp1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="GrdOceanExp1_SelectedIndexChanged" OnRowDataBound="GrdOceanExp1_RowDataBound" Visible="false">
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                    <div class="PendingRight" id="div_blrelase" runat="server">
                        <div class="PortCountry">
                            <h3 id="lbl_blPen" runat="server"></h3>
                            <div class="right_btn">
                                <asp:LinkButton ID="lbl_blrelease" runat="server" OnClick="lbl_blrelease_Click" Visible="false">
                                       <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                                </asp:LinkButton>

                                <div style="clear: both;"></div>
                            </div>
                            <asp:Panel ID="pnlPortCountry1" runat="server" Visible="true" CssClass="gridpnl MB0"  Width="100%">
                                <asp:GridView ID="GrdPort1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPort1_RowDataBound" OnSelectedIndexChanged="GrdPort1_SelectedIndexChanged" Visible="true" OnPreRender="GrdPort1_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="SI" HeaderText="S#">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="20px" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="true" Width="20px" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="blno" HeaderText="BL #" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />--%>
                                        <%-- <asp:BoundField DataField="shipper" HeaderText="Customer" />--%>
                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                    <asp:Label ID="shipperName" runat="server" Text='<%# Bind("shipper") %>' ToolTip='<%#Bind("shipper")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="180px" />
                                            <ItemStyle HorizontalAlign="Left" Width="180px" Wrap="false" />

                                        </asp:TemplateField>
                                       
                                     
                                        <asp:BoundField DataField="counts" HeaderText="">
                                        
                                            <HeaderStyle HorizontalAlign="right" Wrap="true" Width="50px" />                                          
                                            <ItemStyle HorizontalAlign="right" Wrap="true" Width="50px" >
                                                   
                                                   </ItemStyle>
                                           
                                         
   
                                        </asp:BoundField>
                                             
                                            
                                        <asp:BoundField DataField="shipperid" HeaderText="shipperid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>

                    </div>
                    <div class="PendingRightPR" id="penBlRelase" runat="server" visible="false">
                        <h3 id="h1" runat="server">
                            <asp:Label ID="lbl_Bl" runat="server"></asp:Label>
                        </h3>
                        <div class="right_btn">
                            <asp:LinkButton ID="link_pending" runat="server" OnClick="link_pending_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>
                        <asp:Panel ID="Panel3" runat="server" Visible="true" CssClass="gridpnl MB0" Width="100%">

                            <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="SI" HeaderText="S#" />
                                    <asp:BoundField DataField="blno" HeaderText="BL #" />
                                    <asp:BoundField DataField="bldate" HeaderText="BL Date" />
                                    <asp:BoundField DataField="por" HeaderText="PoR" />
                                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                                    <asp:BoundField DataField="pod" HeaderText="PoD" />
                                    <asp:BoundField DataField="fd" HeaderText="PlD" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                        <asp:Panel ID="Panel7" runat="server" Visible="true" CssClass="gridpnl MB0" Width="100%">

                            <asp:GridView ID="GridView5" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView5_RowDataBound" OnSelectedIndexChanged="GridView5_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="SI" HeaderText="S#" />
                                    <asp:BoundField DataField="blno" HeaderText="BL #" />
                                    <asp:BoundField DataField="bldate" HeaderText="BL Date" />
                                    <asp:BoundField DataField="por" HeaderText="PoR" />
                                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="PendingRightU" id="Div_Unclosed" runat="server" visible="false">

                        <h3>Open Jobs</h3>
                        <div class="unclosedlbl">
                            <asp:Label ID="lbl_unclose" runat="server"></asp:Label>
                        </div>
                        <div class="right_btn ">
                            <asp:LinkButton ID="link_unclosed" runat="server" OnClick="link_unclosed_Click">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                        </div>

                        <%--GridView3--%>
                        <asp:Panel ID="Panel4" runat="server" Visible="true" CssClass="gridpnl MB0" Width="100%">
                            <asp:GridView ID="GridView3" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="True" OnRowDataBound="GridView3_RowDataBound" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnPreRender="GridView3_PreRender">
                                <Columns>
                                    <%-- <asp:BoundField DataField="SI" HeaderText="S#" />
                                    <asp:BoundField DataField="JobNo" HeaderText="Job No" />
                                    <asp:BoundField DataField="jobDate" HeaderText="Opended On" />
                                    <asp:BoundField DataField="Agent" HeaderText="Agent" />
                                    <asp:BoundField DataField="Voyage" HeaderText="Vsl&Voy" />
                                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                                    <asp:BoundField DataField="etd" HeaderText="ETD" />
                                    <asp:BoundField DataField="pod" HeaderText="PoD" />
                                    <asp:BoundField DataField="eta" HeaderText="ETA" />
                                    <asp:BoundField DataField="custid" HeaderText="custid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />--%>
                                    <%-- <asp:BoundField DataField="Product" HeaderText="Product" />--%><%--    <asp:BoundField DataField="Branchid" HeaderText="Branchid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>--%>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="S#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="shortname" HeaderText="Branch">
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">   <%-- Changed Header Text from BPJ/Job# to Job#. Praveen 2023May30--%> 
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="etd" HeaderText="Job Open Date">
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Sales person">

                                        <ItemTemplate>
                                            <div class="wrap100">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Salesperson") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer Name">

                                        <ItemTemplate>
                                            <div class="wrap125">

                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PreparedBy">

                                        <ItemTemplate>
                                            <div class="wrap125">

                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("PreparedBy") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="income" DataFormatString="{0:#,##0.00}" HeaderStyle-CssClass="TxtAlign1" HeaderText="Sell" ItemStyle-CssClass="TxtAlign1">
                                        <HeaderStyle CssClass="TxtAlign1" />
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" DataFormatString="{0:#,##0.00}" HeaderStyle-CssClass="TxtAlign1" HeaderText="Buy" ItemStyle-CssClass="TxtAlign1">
                                        <HeaderStyle CssClass="TxtAlign1" />
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" DataFormatString="{0:#,##0.00}" HeaderStyle-CssClass="TxtAlign1" HeaderText="Revenue" ItemStyle-CssClass="TxtAlign1">
                                        <HeaderStyle CssClass="TxtAlign1" />
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MBL" HeaderText="MBL" />
                                    <asp:BoundField DataField="BL" HeaderText="BL" />
                                    <asp:TemplateField HeaderText="Shipper">

                                        <ItemTemplate>
                                            <div class="wrap125">

                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Shipper") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Consignee">

                                        <ItemTemplate>
                                            <div class="wrap125">

                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Consignee") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="POL">

                                        <ItemTemplate>
                                            <div class="wrap100">

                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="POD">

                                        <ItemTemplate>
                                            <div class="wrap100">

                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("POD") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vessel/Flight/DOC #">

                                        <ItemTemplate>
                                            <div class="wrap100">

                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ETA" HeaderText="ETA/FLIGHT" />
                                    <asp:BoundField DataField="ETD1" HeaderText="ETD/FLIGHT" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="PendingRightJob" id="Div1" runat="server" visible="false">
                        <div class="Unclosed1Job">Unclosed Jobs</div>
                        <div class="right_btn ">
                            <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel-sm.png" title="Export to Excel" />
                            </asp:LinkButton>

                            <div style="clear: both;"></div>
                        </div>
                        <asp:Panel ID="Panel6" runat="server" Visible="true" CssClass="gridpnl MB0" Width="100%">

                            <asp:GridView ID="GridView4" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView4_RowDataBound" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="SI" HeaderText="S#" />
                                    <asp:BoundField DataField="JobNo" HeaderText="Job No" />
                                    <asp:BoundField DataField="jobDate" HeaderText="Opended On" />
                                    <asp:BoundField DataField="Agent" HeaderText="Agent" />
                                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                                    <asp:BoundField DataField="pod" HeaderText="PoD" />
                                    <asp:BoundField DataField="flightdate" HeaderText="Flightdate" />

                                    <asp:BoundField DataField="custid" HeaderText="custid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="float:left; width:295px;">
                        <div class="PortCountryC">
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <!--END TABS-->
    </div>
       <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <asp:Label ID="lblIdNew1" runat="server"></asp:Label>
    <ajax:ModalPopupExtender ID="aePopUpshow" runat="server" PopupControlID="AePopUpNewDate" BehaviorID="programmaticModalPopupBehaviordf4"
        TargetControlID="lblIdNew1" CancelControlID="imgNewAl" DropShadow="false">
    </ajax:ModalPopupExtender>

    <asp:Panel ID="AePopUpNewDate" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">

        <div class="DivSecPanel">
            <asp:Image ID="imgNewAl" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>

        <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">
        </asp:Panel>
        <%--  <iframe id="iframecost" runat="server" frameborder="0" src="" visible="true" class="frames" style="background-color: #FFFFFF"></iframe>--%>

        <%--</div>--%>
    </asp:Panel>
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
         <asp:HiddenField ID="Hdn_taskid" runat="server" />
         <asp:HiddenField ID="hid_date" runat="server" />
             <asp:HiddenField ID="hid_TaskValue" runat="server" />
     <asp:HiddenField ID="hid_TaskId" runat="server" />
        
    </div>
        </div>
</asp:Content>
