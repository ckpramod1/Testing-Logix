<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="JobInfo.aspx.cs" Inherits="logix.ForwardExports.JobInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
          function dropdownButton() {
              $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
          }
      </script>

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>


    <link href="../Styles/JobInfo.css" rel="stylesheet" />

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../Scripts/xtableheaderfixed.js" type="text/javascript"></script>
    <!--<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
     <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>-->
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
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

        input#logix_CPH_btn_Vessel {
            background-position-y: 6px !important;
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

        #Test_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }



        .JobLeftN1 {
            float: left;
            width: 100%;
            margin: 0px 0.5% 0px 0px;
        }

        .JobGridRight {
            float: left;
            width: 100%;
        }


        .JobGridRightnew {
            float: right;
            width: 100%;
        }

        .TextField .chzn-container-single .chzn-single span {
            font-size: 14px !important;
            padding: 16px 0 0;
            font-weight: 400 !important;
            color: #000;
        }

        .DateInputnew {
            width: 8.5%;
            float: right;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
        }

        .VesselNameInputnew {
            width: 39.4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .VoyageInputnew {
            width: 11.5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            float: left;
        }

        .EMNo1new {
            width: 11.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .JobLeftN1new {
            width: 100%;
            margin: 0px 0.5% 0px 0px;
        }

        .DesiCalN3new {
            width: 17%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
        }

        .DesiCalN4new {
            width: 7%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
        }

        .JobInput4 {
            width: 8%;
            float: right;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .LoadPortnew {
            width: 30.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .DesiPortnew {
            width: 33.7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }



        .DesiCal1new {
            width: 16.1%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .DesiCal2new {
            width: 17.9%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
        }



        .DesiCal3new {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .MT10 {
            margin: 13px 0px 0px 0px !important;
        }

        .ShipmentDesinew {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
        }



        .chzn-drop {
            height: 150px !important;
            overflow: auto;
            top: -150px !important;
        }

        .MBLNo1new {
            width: 33%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            float: left;
        }

        .MLONamenew {
            width: 35.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .MLOAgentnew {
            width: 99.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .CarrierNew1 {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
        }

        .RemarksInput3new {
            width: 99.8%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
        }

        .JobName {
            width: 3%;
            float: left;
            margin: 3px 0.5% 0px 0px;
            font-size: 11px;
        }

        .ChkBox {
            width: 19%;
            float: left;
            margin: 7px 0px 0px 1.2%;
        }

        span.chktext {
            font-weight: 500 !important;
            margin: -9px 0 0 5px !important;
            padding: 0px 0px 0px 0px;
            font-size: 13px !important;
        }

        span.chktext {
            margin: 0 !important;
        }

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
                font-size: 12px;
            }



        .GridpnlLog {
            width: 100%;
        }

        .MBLDrop {
            width: 21.2%;
            float: left;
            margin: 0px 5px 0px 0px;
            font-size: 11px;
        }

        .ContractDrop {
            width: 9.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .ContainerInput3 {
            width: 14.9%;
            float: left;
            margin: 0px 0.5% 3px 0px;
            font-size: 11px;
        }

        .GPAdd {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .AtDTxtBox {
            width: 6%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        .Coloader {
            width: 15%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
        }


        .SealInput {
            width: 8.7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .NoPkgs {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }


        .WTMT {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .WTCal {
            width: 16.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .WTCal1 {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .WTCal2 {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        div#logix_CPH_btn_add1 {
            margin: 11px 0 0 0;
        }

        .Point2 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddl_NwType_chzn {
            width: 100% !important;
        }

        .widget.box .widget-content {
            top: 0px;
        }


        div#logix_CPH_Book2 {
            overflow: auto !important;
            height: auto;
            margin: 0 !important;
        }

        table#logix_CPH_grd td:nth-child(3),
        table#logix_CPH_grd td:nth-child(4) {
            max-width: 100px;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .TextField .chzn-container-single .chzn-single {
            background: white !important;
            box-shadow: none !important;
            /*height: 40px !important;*/
            line-height: 30px !important;
            /* margin: 10px 0px 0px 0px !important; */
            margin: 6px 0px 0px 0px !important;
        }

        /*   .TextField .chzn-container-single .chzn-single span {
                padding: 17px 0px 0px 0px;
            }*/

        .widget-header {
            width: 100%;
        }

        div#UpdatePanel1 span h2 {
            height: 87vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        table#logix_CPH_grd th:last-child, table#logix_CPH_grd td:last-child {
            display: none !important;
        }

        /* table#logix_CPH_grdBookJob,table#logix_CPH_Grd_container,table#logix_CPH_grd{
            position:relative;
            top:3px!important;
            border:1px solid var(--inputborder)!important;
        }
*/
        .heading_lbl {
            margin: 5px 0 !important;
            display: block !important;
            float: left;
        }

        div#logix_CPH_ddl_size_chzn .chzn-drop {
            height: 400px !important;
        }

        table#logix_CPH_Grd_Job tbody td:nth-child(9) {
            max-width: 217px !important;
        }

        .divleft {
            width: 45%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .divright {
            width: 54.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        div#logix_CPH_ddl_GwType_chzn {
            width: 100% !important;
        }

        div#logix_CPH_popup_upload {
            width: 58% !important;
            margin-left: 19% !important;
            height: 600px !important;
            margin-top: 35px !important;
            left: 0px !important;
        }

        table#logix_CPH_Grd_Job td:nth-child(6) {
            width: 5% !important;
        }

        table#logix_CPH_Grd_Job td:nth-child(8) {
            width: 5% !important;
        }

        table#logix_CPH_Grd_Job td:nth-child(5) {
            width: 5% !important;
        }

        div#logix_CPH_pnl_emp {
            position: fixed !important;
            background-color: rgb(0 0 0 / 30%) !important;
            width: 100% !important;
            height: 100% !important;
            margin-left: 0% !important;
            margin-top: 0% !important;
            border: 1px solid var(--lightgrey) !important;
            display: flex;
            justify-content: center;
            align-items: center;
            top: 0px !important;
            left: 0px !important;
        }

            div#logix_CPH_pnl_emp .divRoated {
                width: 40% !important;
                height: 34vh !important;
                overflow: hidden !important;
                background: var(--white);
                border-radius: 3px;
                margin: 0px !important;
                position: relative;
            }

            div#logix_CPH_pnl_emp .DivSecPanel {
                position: relative;
                right: 12px;
                top: 17px;
            }

        div#logix_CPH_btn input#logix_CPH_Btnamendmbl {
            background-position: 1px 1px;
            width: 30px !important;
            scale: 0.7;
            margin-top: 10px;
        }



        input#logix_CPH_btn_Vessel {
            background-position: 2px !important;
        }

        div#logix_CPH_btn {
            width: 28px !important;
        }

        table#logix_CPH_grdBookJob td:nth-child(4) {
            width: 200px !important;
            overflow: hidden;
            text-overflow: ellipsis;
            display: block;
        }

        table#logix_CPH_grdBookJob td:nth-child(7) {
            max-width: 100px !important;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        table#logix_CPH_grdBookJob td:nth-child(6) {
            max-width: 100px !important;
            overflow: hidden;
            text-overflow: ellipsis;
        }
    </style>



    <%--EDIT--%>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
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

        

        .btn-UpdateAdd2 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-UpdateAdd2 input {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
                background: url(../Theme/assets/img/buttonIcon/updateadd_ic.png) no-repeat left top;
            }


        .GrdHoriz {
            width: 1500px;
            overflow: auto;
            height: auto;
            margin: 10px 0px 0px 0px;
        }

        .GridPannel {
            width: 1300px;
            height: auto;
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

        .JobLeftN1 {
            float: left;
            width: 100%;
            margin: 0px 0% 0px 0px;
        }


        .Div_Grid3 {
            float: left;
            width: 100%;
            height: 90px;
            border: 1px solid #b1b1b1;
            overflow: auto;
        }
    </style>

    <!-- <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script> -->
    <%--EDIT--%>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

                $("#<%=txtCarrier.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hdnCarrier.ClientID %>").val(0);

                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/GetCarrierName",
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
                                // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                            $("#<%=txtCarrier.ClientID %>").change();
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
                        $("#<%=hid_Vesselid.ClientID %>").val(0);
                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/FEJobInfo_GetVessel",
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
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                        $("#<%=txt_vessel.ClientID %>").change();
                        $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                        $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                        $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                        $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $('#<%=txt_loadport.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_Loadportid.ClientID %>").val(0);

                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_loadport.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_loadport.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_Loadportid.ClientID %>").val(ui.item.portid);

                        $('#<%=txt_loadport.ClientID%>').change();

                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_loadport.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_Loadportid.ClientID %>").val(ui.item.portid);
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
                $("#<%=txt_loadport.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Loadportid.ClientID %>").val(0);
                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/FEJobInfo_GetPort",
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
                        $("#<%=txt_loadport.ClientID %>").val(i.item.label);
                        $("#<%=txt_loadport.ClientID %>").change();
                        $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_loadport.ClientID %>").val(i.item.label);
                        $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_loadport.ClientID %>").val(i.item.label);
                        $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_loadport.ClientID %>").val(i.item.label);
                        $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>





            $(document).ready(function () {
                $('#<%=txt_destport.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_Destportid.ClientID %>").val(0);

                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_destport.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_destport.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_Destportid.ClientID %>").val(ui.item.portid);

                        $('#<%=txt_destport.ClientID%>').change();

                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_destport.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_Destportid.ClientID %>").val(ui.item.portid);
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



            $(document).ready(function () {
                $('#<%=txt_shptdest.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_Shipdesportid.ClientID %>").val(0);

                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/SelPortName4typepadimg",
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
                        $('#<%=txt_shptdest.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_shptdest.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_Shipdesportid.ClientID %>").val(ui.item.portid);

                        $('#<%=txt_shptdest.ClientID%>').change();

                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_shptdest.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_Shipdesportid.ClientID %>").val(ui.item.portid);
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





            $(document).ready(function () {
                $("#<%=txt_agent.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Agentid.ClientID %>").val(0);
                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/FEJobInfo_GetCustomer",
                            data: "{ 'prefix': '" + request.term + "','FType':'P'}",
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
                        $("#<%=hid_Agentid.ClientID %>").val(i.item.val);
                        $("#<%=txt_agent.ClientID %>").change();
                    },
                    focus: function (e, i) {
                        $("#<%=hid_Agentid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_agent.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_agent.ClientID %>").val($.trim(result));
                    },

                    minLength: 1

                    <%--select: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Agentid.ClientID %>").val(i.item.val);

                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Agentid.ClientID %>").val(i.item.val);

                        }
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Agentid.ClientID %>").val(i.item.val);

                        }
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Agentid.ClientID %>").val(i.item.val);

                        }
                    },
                    minLength: 1--%>

                });
            });




            $(document).ready(function () {
                $("#<%=txt_mlo.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Mloid.ClientID %>").val(0);
                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/GetCustomer",



                            data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                        $("#<%=hid_Mloid.ClientID %>").val(i.item.val);
                        $("#<%=txt_mlo.ClientID %>").change();
                    },
                    focus: function (e, i) {
                        $("#<%=hid_Mloid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_mlo.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_mlo.ClientID %>").val($.trim(result));
                    },

                    minLength: 1



                });
            });




            $(document).ready(function () {

                $("#<%=txt_search.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../ForwardExports/JobInfo.aspx/FE_GetBookingNo",
                            data: "{ 'prefix': '" + request.term + "','job':'" + $("#<%=txt_job.ClientID %>").val() + "'}",
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

    <style type="text/css">
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
            width: 11%;
            float: left;
            margin: 8px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }


        .LogHeadJobInput {
            width: auto;
            white-space: nowrap;
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
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .TypePointKg5 {
            float: left;
            width: 13%;
            margin: 0 0.5% 0 0;
        }

        .DivSecPanelLog {
            float: right;
            margin: 5px 0px 5px 0px;
        }

        .ddljobtype {
            float: left;
            margin: 0 0.5% 0 0;
            width: 23%;
        }

        div#logix_CPH_ddl_mblstatus_chzn .chzn-drop {
            height: 167px !important;
        }

        .search_box1 {
            width: 18.6%;
            float: left;
            margin: 0 0.5% 5px 0;
        }

        .Point9 {
            width: 11.5%;
            float: left;
            margin: 0 0.5% 0 0;
        }

        .Margin_top {
            margin-top: 0.5% !important;
        }

        .LeftSide {
            width: 95%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .fixheader_1 th:nth-child(5) {
            min-width: 50px;
            width: 50px;
        }

        .fixheader_1 th:nth-child(4) {
            min-width: 150px;
            width: 150px;
        }

        .fixheader_1 th:nth-child(8) {
            min-width: 30px;
            width: 30px;
        }

        .fixheader_1 th:nth-child(9) {
            min-width: 130px;
            width: 130px;
        }

        img#logix_CPH_flagimg {
            width: 24px !important;
            height: auto;
            position: relative;
            left: 88%;
            top: -44px;
        }

        img#logix_CPH_podflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: 87%;
            top: -44px;
        }

        img#logix_CPH_fdflag {
            width: 25px !important;
            height: auto;
            position: relative;
            left: 44%;
            top: -44px;
        }
    </style>

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
    <style type="text/css">
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
            padding-top: 55px !important;
        }

        .widget.box .widget-content {
            padding: 43px 5px 0 !important;
        }

        .bt input[type="submit"], .bt input[type="button"], .bt button {
            overflow: hidden;
            text-indent: inherit;
            width: auto !important;
            background-position: 2px 2px !important;
            background-color: #f1f1f1;
            margin-right: 5px;
            border: 1px solid #b6b6b6 !important;
            border-radius: 6px;
            padding: 6px 2px 7px 42px !important;
            height: 34px !important;
        }

        /*New Design 2*/
        .btn::before div {
            width: 36px;
            height: 34px;
            background: #f095562e;
            position: absolute;
            content: "";
            border-radius: 6px;
            border-right: 1px solid #b1b1b1;
        }

        .btn {
            padding: 0;
            overflow: hidden !important;
            height: auto;
        }

        a#logix_CPH_lnk_job {
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
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="Label1" runat="server" Text="Job Info"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <%--  <li><a href="#"></a>Documentation</li>--%>
                                <li><a href="#" title="">Ocean Exports</a> </li>
                                <li class="current"><a href="#" title="">Job Info</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>

                <div class="widget-content">


                    <div class="FormGroupContent4 FixedButtons">
                        <div class="left_btn">
                            <div class="btn ico-mbl-annexure">
                                <asp:Button ID="btn_mbl" runat="server" ToolTip="MBL Annexure" Text="MBL Annexure" TabIndex="24" OnClick="btn_mbl_Click" />
                            </div>
                            <div class="btn ico-proforma-sales-invoice">
                                <asp:Button ID="Proinvoic" runat="server" ToolTip="Proforma Sales Invoice" Text="Proforma Sales Invoice" TabIndex="25" OnClick="Proinvoic_Click" />
                            </div>
                            <div class="btn ico-proforma-purchase-invoice">
                                <asp:Button ID="procrednote" runat="server" ToolTip="Proforma Purchase Invoice" Text="Proforma Purchase Invoice" TabIndex="26" OnClick="procrednote_Click" />
                            </div>
                            <div class="btn ico-proforma-oscndn">
                                <asp:Button ID="Proosdncn" runat="server" ToolTip="Proforma OSSI/PI" Text="Proforma OSSI/PI" TabIndex="27" OnClick="Proosdncn_Click" />
                            </div>


                            <div class="btn ico-swap" id="Div1" runat="server">
                                <asp:Button ID="Btnnamendjob" runat="server" ToolTip="Change Job" TabIndex="41" OnClick="Btnamendjob_Click" />
                            </div>


                            <div class="btn ico-upload" style="display: none;">
                                <asp:Button ID="uploaddoc" runat="server" ToolTip="UPLoad Document" Text="UPLoad Document" OnClick="uploaddoc_Click" />
                            </div>


                            <div class="btn ico-mbl-annexure hide">
                                <asp:Button ID="btn_mothervessupd" runat="server" ToolTip="Vessel updates" Text="Vessel updates" TabIndex="24" OnClick="btn_mothervessupd_Click" />
                            </div>
                            <div class="btn ico-sailing">
                                <asp:Button ID="btn_Vessel" runat="server" ToolTip="Mother Vessel" Text="Mother Vessel" TabIndex="24" OnClick="btn_Vessel_Click" />
                            </div>
                            <div class="btn ico-reuse">
                                <asp:Button ID="btnbl" runat="server" ToolTip="Reuse" Text="Back to BL" TabIndex="28" OnClick="btnbl_Click" Visible="false" />
                            </div>
                            <div class="btn ico-mbl-draft">
                                <asp:Button ID="btn_draftmbl" runat="server" ToolTip="Mother Vessel" Text="Draft MBL" TabIndex="29" OnClick="btn_draftmbl_Click" />
                            </div>
                        </div>





                        <div class="right_btn">
                            <div class="btn ico-reuse">
                                <asp:Button ID="Btn_reuse" runat="server" ToolTip="Reuse" Text="Reuse" TabIndex="28" OnClick="Btn_reuse_Click" />
                            </div>
                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" TabIndex="29" />
                            </div>


                            <div class="btn ico-view">
                                <asp:Button ID="btn_view" runat="server" ToolTip="View" Text="View" TabIndex="30" OnClick="btn_view_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" Text="Cancel" TabIndex="31" OnClick="btn_cancel_Click" />
                            </div>
                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <div class="DateInputnew">
                            <asp:Label ID="Label6" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" placeholder="" ToolTip="Date" Enabled="False" TabIndex="2"></asp:TextBox>
                        </div>
                        <asp:LinkButton ID="lnk_job" runat="server" CssClass="anc ico-find-sm" ForeColor="#FF3300" Style="text-decoration: none" OnClick="lnk_job_Click"></asp:LinkButton>

                        <div class="JobInput4">
                            <span>Job #</span>

                            <asp:TextBox ID="txt_job" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="" ToolTip="Job Number" OnTextChanged="txt_job_TextChanged" TabIndex="1"></asp:TextBox>
                        </div>

                    </div>
                    <div class="bordertopNew" style="float: right; min-height: 1px; width: 18.7%; box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;"></div>
                    <div claass="FormGroupContent4">
                        <div class="divleft">

                            <div class="FormGroupContent4 boxmodal">

                                <div class="DateInputnew hide">
                                    <asp:Label ID="Label10" runat="server" Text="Stuffed On"></asp:Label>
                                    <asp:TextBox ID="txt_Stuffedon" runat="server" placeholder="" TabIndex="7" ToolTip="Stuffed On" CssClass="form-control date"></asp:TextBox>
                                </div>
                                <div class="ddljobtype fit-content">
                                    <span>Job Type</span>
                                    <asp:DropDownList ID="ddl_jobtype" runat="server" TabIndex="23" data-placeholder="Shipment Type" CssClass="chzn-select" ToolTip="Shipment Type" OnSelectedIndexChanged="ddl_jobtype_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Value="1">Consol</asp:ListItem>
                                        <asp:ListItem Value="2">LCL</asp:ListItem>
                                        <asp:ListItem Value="3">FCL</asp:ListItem>
                                        <%--         <asp:ListItem Value="4">MCC</asp:ListItem>
         <asp:ListItem Value="5">Buyer Consol</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </div>


                                <div class="ShipmentDesinew" style="width: 22.5%">
                                    <asp:Label ID="Label22" runat="server" Text="Contract"></asp:Label>
                                    <asp:DropDownList ID="ddl_Contract" runat="server" data-placeholder="Contract" TabIndex="13" CssClass="chzn-select" ToolTip="RATE CONTRACT">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Value="A">Agent Contract</asp:ListItem>
                                        <asp:ListItem Value="O">Our Contract</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="ChkBox">
                                    <span>Profit Share Job</span>
                                    <asp:CheckBox ID="CHk_DropFE" runat="server"
                                        AutoPostBack="True" OnCheckedChanged="CHk_DropFE_CheckedChanged" />
                                </div>

                            </div>
                            <div class="FormGroupContent4 ">


                                <div class="FormGroupContent4">
                                    <div class="CarrierNew1">
                                        <asp:Label ID="Label21" runat="server" Text="Carrier"></asp:Label>
                                        <asp:TextBox ID="txtCarrier" runat="server" placeholder="" TabIndex="19" ToolTip="Carrier" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCarrier_TextChanged"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="FormGroupContent4 ">
                                    <div class="VesselNameInputnew">
                                        <asp:Label ID="Label5" runat="server" Text="Vessel"></asp:Label>
                                        <asp:TextBox ID="txt_vessel" runat="server" TabIndex="3" AutoPostBack="true" placeholder="" ToolTip="Vessel" CssClass="form-control" OnTextChanged="txt_vessel_TextChanged1"></asp:TextBox>
                                    </div>
                                    <div class="VoyageInputnew">
                                        <asp:Label ID="Label7" runat="server" Text="Voyage"></asp:Label>
                                        <asp:TextBox ID="txt_voyage" runat="server" placeholder="" TabIndex="4" ToolTip="Voyage" CssClass="form-control" OnTextChanged="txt_voyage_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="EMNo1new">
                                        <asp:Label ID="Label8" runat="server" Text="EM#"></asp:Label>
                                        <asp:TextBox ID="txt_em" runat="server" placeholder="" TabIndex="5" ToolTip="EM Number" CssClass="form-control"></asp:TextBox>
                                    </div>


                                    <div class="DesiCalN3new">
                                        <asp:Label ID="Label9" runat="server" Text="EM Date"></asp:Label>
                                        <asp:TextBox ID="txt_emdate" runat="server" placeholder="" TabIndex="6" ToolTip="EM Date" CssClass="form-control date"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                            <div class="FormGroupContent4">
                                <div class="LoadPortnew">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label11" runat="server" Text="Vessel - Port of Loading"></asp:Label>
                                        <asp:TextBox ID="txt_loadport" runat="server" TabIndex="8" placeholder="" ToolTip="Vessel - Port of Loading" AutoPostBack="true" CssClass="form-control" OnTextChanged="txt_loadport_TextChanged"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="flagimg" runat="server" Width="100%" />


                                </div>
                                <div class="DesiCal1new">
                                    <asp:Label ID="Label13" runat="server" Text="ETD"></asp:Label>
                                    <asp:TextBox ID="txt_etd" runat="server" TabIndex="9" placeholder="" ToolTip="Excepted Time of Departure" CssClass="form-control date"></asp:TextBox>
                                </div>


                                <div class="DesiPortnew">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label12" runat="server" Text="Vessel - Port of Discharge"></asp:Label>
                                        <asp:TextBox ID="txt_destport" runat="server" TabIndex="10" placeholder="" ToolTip="Vessel - Port of Discharge" AutoPostBack="true" CssClass="form-control" OnTextChanged="txt_destport_TextChanged"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="podflag" runat="server" Width="100%" />


                                </div>

                                <div class="DesiCal2new">
                                    <asp:Label ID="Label14" runat="server" Text="ETA"></asp:Label>
                                    <asp:TextBox ID="txt_eta" runat="server" TabIndex="11" placeholder="" ToolTip="Excepted Time of Arrival" CssClass="form-control date"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent4 boxmodal">

                                <div class="ShipmentDesinew" style="width: 63.8%">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label15" runat="server" Text="Shipment Destination"></asp:Label>
                                        <asp:TextBox ID="txt_shptdest" runat="server" TabIndex="12" placeholder="" ToolTip="Shipment Destination" AutoPostBack="true" CssClass="form-control" OnTextChanged="txt_shptdest_TextChanged1"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="fdflag" runat="server" Width="100%" />


                                </div>




                            </div>


                            <div class="FormGroupContent4">
                                <div class="ShipmentDesinew">
                                    <asp:Label ID="Label16" runat="server" Text="MLO / Forwarder"></asp:Label>
                                    <asp:TextBox ID="txt_mlo" runat="server" placeholder="" TabIndex="14" ToolTip="MLO / Forwarder" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_mlo_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal">
                                <div class=" FormGroupContent4">

                                    <div class="MBLNo1new">
                                        <asp:Label ID="Label18" runat="server" Text="MBL#"></asp:Label>
                                        <asp:TextBox ID="txt_mbl" runat="server" placeholder="" TabIndex="15" ToolTip="MBL Number" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_mbl_TextChanged" onkeypress="if (event.keyCode==39 ||event.keyCode==34) event.returnValue = false;"></asp:TextBox>
                                    </div>

                                    <div class="btn ico-edit" id="btn" runat="server">
                                        <asp:Button ID="Btnamendmbl" runat="server" ToolTip="Amend MBL" TabIndex="41" OnClick="Btnamendmbl_Click" />
                                    </div>
                                    <div class="DesiCal3new">
                                        <asp:Label ID="Label17" runat="server" Text="Booking Date"></asp:Label>
                                        <asp:TextBox ID="txtlbdate" runat="server" placeholder="" ToolTip="LINE BOOKING DATE" CssClass="form-control date" TabIndex="16"></asp:TextBox>
                                    </div>

                                    <div class="MBLDrop">
                                        <asp:Label ID="Label19" runat="server" Text="MBL STATUS"></asp:Label>
                                        <asp:DropDownList ID="ddl_mblstatus" runat="server" Width="100%" TabIndex="17" CssClass="chzn-select" ToolTip="MBL STATUS">
                                            <asp:ListItem>MBL STATUS</asp:ListItem>
                                            <asp:ListItem Value="R">Release</asp:ListItem>
                                            <asp:ListItem Value="B">SeaWayBill</asp:ListItem>
                                            <asp:ListItem Value="S">Surrendered</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="WTCal">
                                        <asp:Label ID="Label29" runat="server" Text="CRO Date"></asp:Label>
                                        <asp:TextBox ID="txt_date1" CssClass="form-control date" runat="server" placeholder="" ToolTip="CRO Date" TabIndex="37"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="FormGroupContent4">
                                    <div class="MLOAgentnew">
                                        <asp:Label ID="Label20" runat="server" Text="Agent"></asp:Label>
                                        <asp:TextBox ID="txt_agent" runat="server" placeholder="" TabIndex="18" ToolTip="Agent" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_agent_TextChanged"></asp:TextBox>
                                    </div>
                                </div>



                            </div>

                            <div class="FormGroupContent4 boxmodal">




                                <div class="ContractDrop" style="display: none;">
                                    <asp:DropDownList ID="ddl_DropFE" runat="server" TabIndex="20" data-placeholder="ProfitShareJob" CssClass="chzn-select" ToolTip="ProfitShareJob">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Value="O">Our Job</asp:ListItem>
                                        <asp:ListItem Value="P">Profit Share</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="RemarksInput3new">
                                    <asp:Label ID="Label23" runat="server" Text="Remarks"></asp:Label>
                                    <asp:TextBox ID="txt_remark" TabIndex="21" runat="server" placeholder="" ToolTip="REMARKS" CssClass="form-control"></asp:TextBox>
                                </div>



                            </div>
                            <div class="FormGroupContent4 hide">

                                <asp:Panel ID="Panel4" runat="server" GroupingText="Shipment Type" CssClass="panel" TabIndex="22">
                                </asp:Panel>
                            </div>


                            <div class="FormGroupContent4">
                                <div class="ContainerInput3">
                                    <asp:Label ID="Label24" runat="server" Text="Container #"></asp:Label>
                                    <asp:TextBox ID="txt_container" runat="server" TabIndex="32" placeholder="" onkeypress="return this.value.length<=15" ToolTip="Container Number" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="GPAdd">
                                    <asp:Label ID="Label25" runat="server" Text="Type / Size"></asp:Label>
                                    <asp:DropDownList ID="ddl_size" runat="server" AppendDataBoundItems="True" TabIndex="33" CssClass="chzn-select" ToolTip="Units" data-placeholder="Units">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="SealInput">
                                    <asp:Label ID="Label26" runat="server" Text="Seal"></asp:Label>
                                    <asp:TextBox ID="txt_seal" runat="server" placeholder="" MaxLength="18" ToolTip="Seal" TabIndex="34" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="NoPkgs">
                                    <asp:Label ID="Label27" runat="server" Text="Pkgs"></asp:Label>
                                    <asp:TextBox ID="txt_pkgs" runat="server" placeholder="" ToolTip="No of Pkgs" TabIndex="35" CssClass="form-control" onkeypress="return isNumberKey(event,'pkgs');"></asp:TextBox>
                                </div>
                                <div class="WTMT">
                                    <asp:Label ID="Label28" runat="server" Text="Gr.Wt"></asp:Label>
                                    <asp:TextBox ID="txt_wt" runat="server" placeholder="" ToolTip="Gr.Wt" TabIndex="36" CssClass="form-control" onkeypress="return isNumberKey(event,'wt/(MT)');"></asp:TextBox>
                                </div>
                                <div class="TypePointKg5">
                                    <asp:Label ID="Label32" runat="server" Text="Type"></asp:Label>
                                    <asp:DropDownList ID="ddl_GwType" AutoPostBack="true" runat="server" data-placeholder="Type" Width="100%" TabIndex="22" ToolTip="Type" CssClass="chzn-select" OnSelectedIndexChanged="ddl_GwType_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        <asp:ListItem Value="1">Kgs</asp:ListItem>
                                        <asp:ListItem Value="2">Ton</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="Point2">
                                    <asp:Label ID="Label33" runat="server" Text="Nt.Wt"></asp:Label>
                                    <asp:TextBox ID="txt_netweight" AutoPostBack="true" runat="server" CssClass="form-control" Width="100%" TabIndex="23" placeholder="" ToolTip="Nt.Wt"></asp:TextBox>
                                </div>
                                <div class="Point9">
                                    <asp:Label ID="Label34" runat="server" Text="Type"></asp:Label>
                                    <asp:DropDownList ID="ddl_NwType" AutoPostBack="true" runat="server" Width="100%" data-placeholder="Type" ToolTip="Type" TabIndex="24" CssClass="chzn-select">
                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        <asp:ListItem Value="1">Kgs</asp:ListItem>
                                        <asp:ListItem Value="2">Ton</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="btn ico-add" id="btn_add1" runat="server">
                                    <asp:Button ID="btn_add" runat="server" ToolTip="Add" Text="Add" TabIndex="38" OnClick="btn_add_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                </div>
                                <%-- onclientclick="disableBtn(this.id, 'Loading...')" usesubmitbehavior="False"--%>
                            </div>

                            <div class="FormGroupContent4 boxmodal">
                                <div class="FormGroupContent4 ">
                                    <span class="hide">Container Details</span>
                                    <div class="FormGroupContent4">
                                        <div class=" custom-mb-5 gridpnl">
                                            <asp:GridView CssClass="Grid FixedHeader" ID="Grd_container" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" PageSize="5" AllowPaging="false" OnRowCommand="Grd_container_RowCommand" ShowHeaderWhenEmpty="true"
                                                OnRowDataBound="Grd_container_RowDataBound" OnRowDeleting="Grd_container_RowDeleting" OnSelectedIndexChanged="Grd_container_SelectedIndexChanged" OnPageIndexChanging="Grd_container_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="containerno" HeaderText="Container#">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="sizetype" HeaderText="Size">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="sealno" HeaderText="Seal#">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="270px" />
                                                        <ItemStyle Font-Bold="false" Width="270px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="pkgs" HeaderText="pkgs">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="wt" HeaderText="Gross Wt(MT)">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="grwttype" HeaderText="UoM">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ntweight" HeaderText="Net Wt(MT)">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ntwttype" HeaderText="UoM">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="netval" HeaderText="Net Wt(Val)" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="grwtval" HeaderText="Net Wt(Val)" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                                        <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CRODate" HeaderText="CRO Date" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="120px" />
                                                        <ItemStyle Font-Bold="false" Width="120px" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <%--<asp:TemplateField HeaderText="Edit" Visible="False">
    <ItemTemplate>
        <asp:ImageButton ID="Img_Edit" runat="server" CommandName="Select" 
            ImageUrl="~/images/edit.gif" />
    </ItemTemplate>
     <HeaderStyle Width ="49px"/>
    <ItemStyle HorizontalAlign="Center" Width ="49px"/>
</asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete"
                                                                ImageUrl="~/images/delete.jpg" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px" />
                                                        <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify" />

                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>

                                        </div>

                                    </div>
                                </div>



                            </div>
                        </div>


                        <div class="divright">
                            <div class="FormGroupContent4">
                                <div class="search_box1">
                                    <span>Search Booking</span>

                                    <asp:TextBox ID="txt_search" placeholder="Search" runat="server" ToolTip="Search" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_search_TextChanged"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent4">
                                <asp:Panel ID="Book2" runat="server" CssClass="hide" Height="">
                                </asp:Panel>
                                <div class="custom-mb-5 gridpnl">
                                    <asp:GridView ID="grdBookJob" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader fixheader_1" DataKeyNames="shiprefno" OnPreRender="grdBookJob_PreRender"
                                        Height="100%" ShowHeaderWhenEmpty="true" Width="100%" OnRowDataBound="grdBookJob_RowDataBound">
                                        <Columns>


                                            <asp:BoundField ControlStyle-CssClass="hide" DataField="bookingno" HeaderText="booking #">
                                                <HeaderStyle CssClass="hide" />
                                                <ItemStyle CssClass="hide" />
                                            </asp:BoundField>



                                            <asp:BoundField runat="server" DataField="shiprefno" HeaderText="Booking #">
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                            </asp:BoundField>



                                            <asp:BoundField runat="server" DataField="bookingdate" HeaderText="Date">
                                                <HeaderStyle />
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField runat="server" DataField="customername" HeaderText="Customer Name">
                                                <HeaderStyle />
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField runat="server" DataField="quotno" HeaderText="quot #">
                                                <HeaderStyle CssClass="hide" />
                                                <ItemStyle CssClass="hide" Font-Bold="false" HorizontalAlign="Left" />
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
                                                    <asp:CheckBox ID="ChkMail" runat="server" AutoPostBack="true" OnCheckedChanged="ChkMail_CheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField runat="server" DataField="bl#" HeaderText="BL #">
                                                <HeaderStyle CssClass="hide" />
                                                <ItemStyle CssClass="hide" Font-Bold="false" HorizontalAlign="Left" />
                                            </asp:BoundField>

                                        </Columns>
                                        <AlternatingRowStyle CssClass="GrdRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <RowStyle CssClass="GridviewScrollItem" />
                                    </asp:GridView>

                                </div>
                                <div class="bordertopNew"></div>

                            </div>

                        </div>
                    </div>

                    <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />









                    <div class="FormGroupContent4">

                        <span class="heading_lbl">BL Details</span>
                        <div class="FormGroupContent4 boxmodal">
                            <asp:Panel ID="pnl_grd1" runat="server" CssClass="gridpnl">

                                <asp:GridView ID="grd" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                                    OnRowDataBound="grd_RowDataBound"
                                    OnSelectedIndexChanged="grd_SelectedIndexChanged">
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>

                    <div class="Clear"></div>


                </div>
            </div>
        </div>
       
    </div>
    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Are you sure you want to delete the details?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>

    <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label3">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label3" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <%-- POPUP JOB --%>

    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">
                <asp:GridView ID="Grd_Job" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="false" OnPageIndexChanging="Grd_Job_PageIndexChanging" OnRowDataBound="Grd_Job_RowDataBound"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" BackColor="White"
                    OnSelectedIndexChanged="Grd_Job_SelectedIndexChanged">
                    <Columns>

                        <asp:TemplateField HeaderText="Job #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="41px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Type">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                    <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="40px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vessel">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                    <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Voyage">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 65px">
                                    <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="65px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MBL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 125px">
                                    <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="126px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 88px">
                                    <asp:Label ID="ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Destination">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="Destination" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETA">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                    <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MLO">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 266px">
                                    <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>


                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

                <div class="div_Break"></div>

                <asp:GridView ID="GrdReuse" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="GrdReuse_PageIndexChanging"
                    OnRowDataBound="GrdReuse_RowDataBound" OnSelectedIndexChanged="GrdReuse_SelectedIndexChanged" AllowPaging="false" ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" BackColor="White">

                    <Columns>

                        <asp:TemplateField HeaderText="Job #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="41px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="JobType">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                    <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="40px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vessel">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                    <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Voyage">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 65px">
                                    <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="65px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MBL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 125px">
                                    <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="126px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Destination">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="Destination" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETA">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MLO">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 195px">
                                    <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="195px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>


                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>




                <div class="div_Break"></div>



                <asp:GridView ID="Grd_Vessel" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_Vessel_RowDataBound"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" DataKeyNames="vesselid,polid,podid"
                    BackColor="White" OnSelectedIndexChanged="Grd_Vessel_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="vesselname" HeaderText="Vessel">
                            <HeaderStyle Width="155px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="100px" />

                        </asp:BoundField>
                        <asp:BoundField DataField="voyage" HeaderText="Voyage">
                            <HeaderStyle Width="48px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="35px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pol" HeaderText="POL">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                        </asp:BoundField>
                        <asp:BoundField DataField="pod" HeaderText="POD">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                        </asp:BoundField>
                        <asp:BoundField DataField="etd" HeaderText="ETD">
                            <HeaderStyle Width="83px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                        </asp:BoundField>
                        <asp:BoundField DataField="eta" HeaderText="ETA">
                            <HeaderStyle Width="98px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                        </asp:BoundField>
                        <%-- <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_Vessel" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                      <HeaderStyle Width ="30px"/>
                      <ItemStyle Font-Bold="false" HorizontalAlign="Center" Width ="20px"/>
                    
                    </asp:TemplateField>--%>
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


    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
        DropShadow="false" TargetControlID="Label2" CancelControlID="close" BehaviorID="Test">
    </asp:ModalPopupExtender>
    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Job # :</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="16px" Height="16px" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
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


    <asp:Panel ID="pln_cheque" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="LogHeadJob">
            <label>Vessel Details </label>

        </div>
        <div class="DivSecPanel">
            <asp:Image ID="Close_Cheque" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>


        <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames"></iframe>

        <div class="div_Break"></div>

    </asp:Panel>
    <asp:ModalPopupExtender ID="popup_cheque" runat="server" PopupControlID="pln_cheque" TargetControlID="Label30" CancelControlID="Close_Cheque">
    </asp:ModalPopupExtender>

    <asp:Label ID="Label30" runat="server"></asp:Label>

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>



    <asp:Panel runat="Server" ID="popup_upload" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="20px" />
            </div>

            <asp:Panel ID="pnl_emp1" runat="server">
                <div class="">
                    <iframe id="iframe_outstd" runat="server" src="" frameborder="0"></iframe>
                </div>
            </asp:Panel>
        </div>
    </asp:Panel>

    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="popup_uploaddoc" runat="server" PopupControlID="popup_upload" TargetControlID="lbl1"
        CancelControlID="Image4">
    </asp:ModalPopupExtender>
    <asp:Label ID="lbl1" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:Panel ID="pnl_emp" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <%--<asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />--%>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Close_voucher_Click">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </asp:LinkButton>
            </div>
            <asp:Panel ID="Panel1" runat="server" CssClass="">
                <iframe id="iframe1" runat="server" frameborder="0"></iframe>
            </asp:Panel>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="pop_up" runat="server" PopupControlID="pnl_emp" DropShadow="false"
        TargetControlID="Label31" CancelControlID="Close_voucher" BehaviorID="Test2">
    </asp:ModalPopupExtender>

    <asp:Label ID="Label31" runat="server" Text="Label" Style="display: none;"></asp:Label>


    <asp:Panel runat="Server" ID="Panel5" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="20px" />

            </div>

            <asp:Panel ID="Panel6" runat="server">
                <div class="">
                    <iframe id="iframe2" runat="server" src="" frameborder="0"></iframe>
                </div>
            </asp:Panel>
        </div>
    </asp:Panel>

    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel5" TargetControlID="Label35"
        CancelControlID="Image5">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label35" runat="server" Style="display: none;"></asp:Label>



    <asp:Panel ID="Panel7" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <asp:Panel ID="Panel8" runat="server" CssClass="">
                <iframe id="iframe3" runat="server" frameborder="0"></iframe>
            </asp:Panel>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel7" DropShadow="false"
        TargetControlID="Label48" CancelControlID="Close_voucher" BehaviorID="Test3">
    </asp:ModalPopupExtender>

    <asp:Label ID="Label48" runat="server" Text="Label" Style="display: none;"></asp:Label>







    <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_etd" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_eta" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender3" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_emdate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender4" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_Stuffedon" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender5" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_date" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender6" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_date1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender7" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txtlbdate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <div class="div_Break"></div>
    <asp:HiddenField ID="hid_Agentid" runat="server" />
    <asp:HiddenField ID="hid_Mloid" runat="server" />
    <asp:HiddenField ID="hid_Vesselid" runat="server" />
    <asp:HiddenField ID="hid_Loadportid" runat="server" />
    <asp:HiddenField ID="hid_Destportid" runat="server" />
    <asp:HiddenField ID="hid_Shipdesportid" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_Contra" runat="server" />
    <asp:HiddenField ID="hid_jobtype" runat="server" />
    <asp:HiddenField ID="hid_ContainerName" runat="server" />
    <asp:HiddenField ID="hdnCarrier" runat="server" />
    <asp:HiddenField ID="hidbooking" runat="server" />
    <asp:HiddenField ID="hid_jobid" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
</asp:Content>
