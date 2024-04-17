<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BL Print.aspx.cs" Inherits="logix.ForwardExports.BL_Print" %>

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
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
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

    <script type="text/javascript">
        function generateLableAutomatically() {

            $("input[type = 'submit'],input[type = 'button']").each(function () {
                if ($(this).attr("value")) {
                    var value = $(this).attr("value");
                    $(this).attr("title", value);
                    $(this).attr("value", "");
                }
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

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

    <link href="../Styles/BLprinting.css" rel="stylesheet" type="text/css" />
    <%-- <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>--%>
    <%--    <link href="../StylesAuto/Jquery.css" rel="Stylesheet" type="text/css" />
    <link href="../StylesAuto/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_bl.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetBLNo_Blprint",
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
                        $("#<%=txt_bl.ClientID %>").val(i.item.val);
                        $("#<%=txt_bl.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.val);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.label);
                        $("#<%=txt_bl.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {

                $("#<%=txt_book.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetBLNo_BlNo",
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
                        $("#<%=txt_book.ClientID %>").change();

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_book.ClientID %>").val(i.item.value);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txt_book.ClientID %>").val(i.item.value);
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_book.ClientID %>").val(i.item.value);
                        }
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_cha.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_cha.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer",
                            data: "{ 'prefix': '" + request.term + "','FType':'F'}",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },
                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_cha.ClientID %>").val(i.item.val);
                            $("#<%=txt_cha.ClientID %>").change();
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_cha.ClientID %>").val(i.item.val);
                        }
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_cha.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_cha.ClientID %>").val(i.item.val);
                        }
                    },
                    minLength: 1
                });
            });
        }
    </script>
    <style>
        .hide {
            display: none;
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
                font-size: 12px;
            }

        .modalPopupssLog {
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
                font-size: 12px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 12px;
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

        .Widthctrl2 {
            width: 97% !important;
        }


        .Quotationtxt11 {
            width: 61%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -0.3%;
            border-radius: 90px 90px 90px 90px;
        }

        modalPopup {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 87%;
            Height: 469px;
            margin-left: 0.5%;
            margin-top: 1.1%;
            overflow: hidden;
        }

        .BackView a {
            color: #034aa6;
        }

        .OutStandingLbl1 {
            float: left;
            width: 10%;
        }

            .OutStandingLbl1 h3 {
                font-size: 14px;
                color: #034aa6;
                padding: 5px 0px 5px 3px;
                margin: 0px 0px 0px 0px;
                font-family: 'OpenSansRegular';
                font-weight: normal;
            }

        .OutStandingLbl2 {
            float: left;
            width: 65%;
            padding: 3px 0px 5px 0px;
            margin: 0px 0px 0px 0px;
            font-weight: bold;
            color: #4e4e4c;
        }

        .Quotationtxt {
            width: 39.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OutStandingLbl2 span {
            font-size: 12px;
            color: brown;
            font-family: Tahoma;
            display: inline-block;
            color: Brown;
            font-weight: normal;
            padding: 3px 0px 5px 0px;
            margin: 0px 0px 0px 0px;
        }

        .BLPrint table {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

        .BLPrint thead {
            position: relative;
            display: block;
            width: 100%;
            overflow: visible;
        }

            .BLPrint thead th {
                min-width: 182px;
            }

        .BLPrint tbody td {
            min-width: 182px;
        }

        .BLPrint tbody {
            position: relative;
            display: block; /*seperates the tbody from the header*/
            width: 100%;
            height: 410px;
            overflow: auto;
        }

        a {
            font-size: 12px;
        }

        .BookingInput9 {
            width: 44%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PORLeft.boxmodal {
            margin-right: 0.5% !important;
        }


        .pod {
            width: 49.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .BLTab1 {
            float: left;
            width: 100%;
            margin: 0px 0.5% 0px 0px;
            border-bottom: 1px solid var(--cementgrey);
        }

        .MarksNo {
            float: left;
            width: 100%;
        }

        .div_cha_visible {
            float: left;
            width: 100%;
        }

        .POL1 {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .pol {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FDN11 {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DODate {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_cha {
            margin: 0px;
            width: 64.5%;
            float: left;
        }

        .BLNo5 {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DateInput3 {
            float: left;
            width: 11%;
            margin: 0 0.5% 0 0;
        }

        .MBLNo {
            width: 49%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MBLStatus {
            width: 50.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .LineNo {
            width: 9%;
            float: left;
            margin: 0 0.5% 0 0;
        }

        .JobIm {
            float: left;
            width: 49%;
            margin: 0px 1% 0 0;
        }

        .IssueAtI {
            width: 12.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobType {
            width: 49.5%;
            float: left;
            margin: 0px 0px 0 0;
        }

        .HBLStatus {
            width: 18%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Marketed_By {
            width: 100%;
            float: left;
            margin: 0 0px 0 0;
        }

        .MLO_FFD {
            width: 100%;
            float: left;
            margin: 0 0 0 0;
        }

        .Cargo {
            float: left;
            margin: 0 0% 0 0;
            width: 100%;
            height: 162px !important;
            border-bottom: 1px solid var(--inputborder);
        }

        .MarkAndNum {
            float: left;
            margin: 0 0.5% 0 0;
            width: 100%;
            height: 162px !important;
            border-bottom: 1px solid var(--inputborder);
        }

        .Marketed {
            width: 35%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MLOFed {
            width: 39%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Container1 {
            float: left;
            width: 20%;
            margin: 0;
        }



        .VoyageInput10 {
            width: 24.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FVessel {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MVessel {
            width: 48%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BackView {
            float: right;
            margin: 0px 0% 0px 0px;
            width: auto;
            position: absolute;
            top: 5px;
            right: 10px;
        }

        input#logix_CPH_btn_FBL {
            text-indent: -26px !important;
        }

        .Remarks {
            width: 100%;
            float: left;
            margin: 0 0.5% 0 0;
        }

        .DEStuff {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .txt_dodate {
            float: right;
            width: 10%;
            margin: 0px 0px 5px 0px;
        }

        .Container1 select {
            width: 100%;
            height: 128px !important;
            padding-top: 20px !important;
        }

        div#logix_CPH_div_BLvoucherdetail {
            width: 50%;
        }

        div#logix_CPH_div_BLfreigthdetail {
            width: 50%;
        }

        .shipper {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .consignee {
            width: 100% !important;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .agent {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .notify {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }


        .divleft {
            width: 27%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .divright {
            width: 20%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .div_chanew {
            width: 20%;
            float: left;
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0.5%;
        }

        input#logix_CPH_txt_cargo {
            border-bottom: none !important;
        }

        input#logix_CPH_txt_mark {
            border-bottom: none !important;
        }



        div#logix_CPH_div_cha {
            width: 20%;
            float: left;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            height: 88vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        img#logix_CPH_fpolflag {
            width: 24px !important;
            height: auto;
            position: relative;
            right: 307%;
            top: 278px;
            z-index: 10;
        }

        img#logix_CPH_fpodflag {
            width: 24px !important;
            height: auto;
            position: relative;
            right: 115%;
            top: 278px;
            z-index: 10;
        }

        img#logix_CPH_porflag {
            width: 24px !important;
            height: auto;
            position: relative;
            right: 500%;
            top: 278px;
            z-index: 10;
        }

        img#logix_CPH_flagimg {
            width: 24px !important;
            height: auto;
            position: relative;
            right: -811%;
            top: 442px;
            z-index: 10;
        }

        img#logix_CPH_podflag {
            width: 24px !important;
            height: auto;
            position: relative;
    right: -1100%;
            top: 442px;
            z-index: 10;
        }

        img#logix_CPH_fdflag {
            width: 24px !important;
            height: auto;
            position: relative;
            right: -77%;
            top: 278px;
            z-index: 10;
        }
        /*New Design - Buttons*/


        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 65px !important;
        }

        .inputbox {
            width: 100%;
            float: left;
        }

        .TextArea select, .TextArea textarea {
            margin: 10px 0px 0px !important;
            padding: 23px 5px 0px 7px !important;
            overflow: auto !important;
            border: 0px solid var(--inputborder) !important;
            border-bottom: 1px solid var(--inputborder) !important;
            border-radius: 0px;
        }

        input#logix_CPH_txt_cha {
            width: 100% !important;
        }

        div#logix_CPH_div_cha {
            width: 100%;
            float: left;
        }



        .divl {
            width: 73%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .divr {
            width: 26.5%;
            float: left;
            margin: 0px 0px 0px 0px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            .divr .FormGroupContent4 {
                -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            }

                .divr .FormGroupContent4 div span {
                    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
                }

        select#logix_CPH_chk_container {
            height: 152px !important;
        }

        .TextField .inputcolor, .TextField .inputcolor:focus {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            font-weight: normal !important;
        }

        .img {
            float: left;
        }

        input#logix_CPH_txt_job, input#logix_CPH_txt_jobtype, input#logix_CPH_txt_book, input#logix_CPH_txt_Quotation,
        input#logix_CPH_txt_creditgroupcus, input#logix_CPH_txt_marketed, input#logix_CPH_txt_mlo, input#logix_CPH_txt_mbl,
        input#logix_CPH_txt_mblstatus, input#logix_CPH_txt_vessel, input#logix_CPH_txt_fetd, input#logix_CPH_txt_feta,
        input#logix_CPH_txt_mpol, input#logix_CPH_txt_mpod, input#logix_CPH_txt_mvessel, input#logix_CPH_txt_metd,
        input#logix_CPH_txt_POL, input#logix_CPH_txt_POD, input#logix_CPH_txt_cfs, input#logix_CPH_txt_cfs, input#logix_CPH_txt_meta, input#logix_CPH_txt_destuff {
            border: none !important;
        }

        .TextField .inputcolor, .TextField .inputcolor:focus {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }
 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_header" runat="server" Text="BL Print"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li style="display: none"><a href="#" title="" id="headerlable1" runat="server"></a></li>
                                <li style="display: none"><a href="#" title="" id="headerlable2" runat="server"></a></li>
                                <li class="current"><a href="#" title="" id="Headerlable" runat="server">DO Details</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px 0px 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>



                    <div class="FixedButtons">
    <div class="FormGroupContent4" id="div_Bltbn" runat="server">
        <div class="left_btn">
            <div class="btn ico-cfs-profoma">
                <asp:Button ID="btncfs" runat="server" Text="CFS PROFORMA" TabIndex="40" CssClass="btn_print" OnClick="btncfs_Click" />
            </div>

            <div class="btn ico-pending-do-sales" id="dosale_id" runat="server">
                <asp:Button ID="btn_DOsale" runat="server" Text="Pending DO Sales" ToolTip="Pending DO Sales" OnClick="btn_DOsale_Click" />
            </div>
            <div class="btn ico-pending-do" id="btn_DO_id" runat="server">
                <asp:Button ID="btn_DO" runat="server" Text="Pending DO" ToolTip="Pending DO" OnClick="btn_DO_Click" />
            </div>
        </div>
        <div class="right_btn">

            <div class="btn ico-pending-do-unreversed hide" id="btn_new_pending_id" runat="server">
                <asp:Button ID="btn_new_pending" runat="server" Text="Pending DO-Unreversed" ToolTip="Pending DO-Unreversed" OnClick="btn_new_pending_Click" />
            </div>
            <div class="btn ico-print" id="Btn_Print_id" runat="server">
                <asp:Button ID="Btn_Print" runat="server" Text="Print" ToolTip="Print" OnClick="Btn_Print_Click" />
            </div>
            <div class="btn ico-send">
                <asp:Button ID="btn_send" runat="server" Text="Send" OnClick="btn_send_Click" />
            </div>
            <div class="btn ico-excel">
                <asp:Button ID="btn_excel" runat="server" Text="PendingDOExportExcel" ToolTip="PendingDOExportExcel" OnClick="btn_excel_Click" />
            </div>

            <div class="btn ico-cancel">
                <asp:Button ID="Btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="Btn_cancel_Click" />
            </div>

        </div>

    </div>
</div>


                </div>
                <div class="widget-content">

                    
                    <div class="FormGroupContent4">
                        <div class="BLTab1 hide">

                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk_bl" runat="server" OnClick="lnk_bl_Click">BL Details</asp:LinkButton></li>
                                <li id="div_lnk_blvoucher" runat="server">
                                    <asp:LinkButton ID="lnk_blvoucher" runat="server" OnClick="lnk_blvoucher_Click">BL Voucher Details</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk_blfreight" runat="server" OnClick="lnk_blfreight_Click">BL freight Details</asp:LinkButton></li>

                            </ul>

                        </div>

                        <div class="BLBackRight">
                            <div class="BackView">
                                <asp:LinkButton ID="lnk_Creditdet" runat="server" OnClick="lnk_Creditdet_Click" Visible="false">View OutStanding</asp:LinkButton>
                            </div>
                            <asp:LinkButton ID="lnk_back" CssClass="hide" Style="text-decoration: none; font-weight: bold" ForeColor="Red" runat="server" OnClick="lnk_back_Click">Back to Previous</asp:LinkButton>
                        </div>
                    </div>


                    <div class="FormGroupContent4">
                        <div class="txt_dodate">
                            <asp:Label Text="DO Date" ID="Label26" runat="server"></asp:Label>
                            <asp:TextBox ID="txt_dodate" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Delivery Order Date" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="divl">
                            <div class="FormGroupContent4">
                                <div class="BLNo5">
                                    <asp:Label Text="BL #" ID="Label21" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_bl" runat="server" AutoPostBack="True" CssClass="form-control" PlaceHolder="" ToolTip="Bill of Lading Number" OnTextChanged="txt_bl_TextChanged"></asp:TextBox>
                                </div>
                                <div class="DateInput3 DateR">
                                    <asp:Label Text="Date" ID="Label2" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Date" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="HBLStatus">
                                    <asp:Label Text="HBL Status" ID="Label3" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_hbl" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="HBL Status" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="IssueAtI">
                                    <asp:Label Text="Issued At" ID="Label4" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_issued" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Issued At" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="LineNo">
                                    <asp:Label Text="Line #" ID="Label7" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_line" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Line Number" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div class="img">
                                    <asp:Image ID="flagimg" runat="server" Width="100%" />

                                    <asp:Image ID="podflag" runat="server" Width="100%" />
                                </div>

                                <div class="img1" style="float: left">
                                    <asp:Image ID="porflag" runat="server" Width="100%" />

                                    <asp:Image ID="fpolflag" runat="server" Width="100%" />
                                    <asp:Image ID="fpodflag" runat="server" Width="100%" />
                                    <asp:Image ID="fdflag" runat="server" Width="100%" />
                                </div>
                            </div>



                            <div class="FormGroupContent4">
                                <div class="shipper">
                                    <asp:Label Text="Shipper" ID="Label15" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_shipper" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Shipper" ReadOnly="True"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent4">
                                <div class="Consignee" style="width: 100% !important">
                                    <asp:Label Text="Consignee" ID="Label17" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_consignee" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Consignee" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="notify">
                                    <asp:Label Text="Notify" ID="Label16" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_notify" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Notify" ReadOnly="True"></asp:TextBox>
                                </div>


                            </div>
                            <div class="FormGroupContent4">
                                <div class="agent">
                                    <asp:Label Text="Agent" ID="Label18" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Agent" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div style="width: 25%; float: left; margin: 0px 0.5% 0px 0px;">
                                    <div class="FormGroupContent4">
                                        <asp:Label Text="Port of Receipt" ID="Label19" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_POR" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Port of Receipt" ReadOnly="True"></asp:TextBox>

                                    </div>


                                </div>
                                <div class="FVessel" style="width: 25%;">
                                    <div class="FormGroupContent4">
                                        <asp:Label Text="PoL" ID="Label32" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_fpol" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Port Of Loading" ReadOnly="True"></asp:TextBox>

                                    </div>


                                </div>
                                <div class="FVessel" style="width: 24%;">
                                    <div class="FormGroupContent4">
                                        <asp:Label Text="PoD" ID="Label36" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_fpod" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Port Of Destination" ReadOnly="True"></asp:TextBox>

                                    </div>



                                </div>

                                <div style="width: 24.5%; float: left; margin: 0px 0px 0px 0px;">
                                    <div class="FormGroupContent4">
                                        <asp:Label Text="Place of Delivery" ID="Label25" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_FD" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Place of Delivery" ReadOnly="True"></asp:TextBox>

                                    </div>

                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <div style="width: 85%; float: left; margin: 0px 0.5% 0px 0px;">
                                    <div class="FormGroupContent4">
                                        <div class="FormGroupContent4">

                                            <div id="div_cha" runat="server">
                                                <asp:Label Text="CHA / CNF" ID="Label42" runat="server"></asp:Label>
                                                <asp:TextBox ID="txt_cha" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="CHA / CNF" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="FormGroupContent4">

                                        <div class="divleft">
                                            <div class="FormGroupContent4 TextArea TextField">
                                                <asp:Label ID="lbl_container" runat="server" Text="Container #"></asp:Label>
                                                <asp:ListBox ID="chk_container" runat="server" Width="100%" Height="128px"
                                                    Font-Names="Tahoma" Font-Size="12pt"></asp:ListBox>
                                            </div>
                                        </div>

                                        <div class="divright">


                                            <div class="FormGroupContent4">

                                                <div class="MarkAndNum ">
                                                    <asp:Label Text="Marks and Numbers" ID="Label27" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txt_mark" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Marks and Numbers" ReadOnly="True"></asp:TextBox>
                                                </div>



                                            </div>

                                        </div>

                                        <div style="width: 51.9%; float: left; margin-left: 4px;">
                                            <div class="Cargo">
                                                <asp:Label Text="Cargo" ID="Label12" runat="server"></asp:Label>
                                                <asp:TextBox ID="txt_cargo" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Cargo" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="width: 14.5%; float: left; margin: 0px 0% 0px 0px;">
                                    <div class="custom-col custom-mr-05" style="width: 100%; float: left">
                                        <asp:Label Text="Freight" ID="Label13" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_freight" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Freight" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="custom-col custom-mr-05" style="width: 100%; float: left">
                                        <asp:Label Text="Volume" ID="Label22" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_volume" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Volume" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="custom-col custom-mr-05" style="float: left; width: 100%">
                                        <asp:Label Text="Kgs" ID="Label23" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_kgs" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="kilograms" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="custom-col" style="float: left; width: 100%">
                                        <asp:Label Text="Packages" ID="Label14" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_packages" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Packages" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4 custom-d-flex " id="div_cfstxt" runat="server">


                                <div class="Remarks">
                                    <asp:Label Text="Remarks" ID="Label40" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Remarks" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div class="right_btn custom-mt-3">
                                    <asp:Button ID="btn_FBL" runat="server" Text="---" CssClass="btn_FBL"
                                        Visible="False" Width="5%" OnClick="btn_FBL_Click" />
                                </div>

                            </div>
                        </div>
                        <div class="divr">
                            <div class="FormGroupContent4">
                                <div class="JobIm">
                                    <asp:Label Text="Job/IM" ID="Label9" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_job" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Job/IM" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="JobType">
                                    <asp:Label Text="Job Type" ID="Label1" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_jobtype" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Job Type" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="BookingInput9">
                                    <span>Booking #</span>
                                    <asp:TextBox ID="txt_book" runat="server" ReadOnly="True" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Booking Number" AutoPostBack="True" OnTextChanged="txt_book_TextChanged"></asp:TextBox>
                                </div>

                                <div class=" boxmodalLink_box">
                                    <asp:LinkButton ID="lnk_book" runat="server" CssClass="anc ico-find-sm" Style="text-decoration: none;" OnClick="lnk_book_Click"></asp:LinkButton>
                                </div>

                                <div class="Quotationtxt">
                                    <span>Quotation #</span>
                                    <asp:TextBox ID="txt_Quotation" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Quotation Number" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class=" boxmodalLink_box">
                                    <asp:LinkButton ID="lnk_Quotation" runat="server" CssClass="anc ico-find-sm" Style="text-decoration: none;" OnClick="lnk_Quotation_Click"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <div class="Quotationtxt11 hide">
                                    <asp:Label Text="Credit Group Customer/Credit Day/Credit Amt" ID="Label8" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_creditgroupcus" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Credit groupcustomer/Creditday/creditamt" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="Marketed_By">
                                    <asp:Label Text="Sales person" ID="Label10" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_marketed" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Marketed By" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="MLO_FFD">
                                    <asp:Label Text="MLO/FFD" ID="Label11" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_mlo" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Master Line Operator/Fit For Duty" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MBLNo">
                                    <asp:Label Text="MBL #" ID="Label6" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_mbl" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="MBL Number" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="MBLStatus">
                                    <asp:Label Text="MBL Status" ID="Label5" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_mblstatus" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="MBL Status" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="FVessel" style="width: 45.5%; margin: 0px 0.5% 0px 0px;">
                                    <div class="inputbox">
                                        <asp:Label Text="F.Vessel" ID="Label28" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Father vessel" ReadOnly="True"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="VoyageInput10" style="width: 27%;">
                                    <asp:Label Text="ETD" ID="Label33" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_fetd" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Estimated Time Of Departure" ReadOnly="True"></asp:TextBox>
                                </div>

                                <div class="VoyageInput10 custom-mr-0" style="width: 26.4%;">
                                    <asp:Label Text="ETA" ID="Label37" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_feta" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Expected Time Arrival" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="">
                                    <div class="FVessel">
                                        <asp:Label Text="PoL" ID="Label34" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_mpol" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Port Of Loading" ReadOnly="True"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="mpolflag" runat="server" Width="100%" />

                                </div>

                                <div class="" style="margin-right: 0px !important;">
                                    <div class="FVessel">
                                        <asp:Label Text="PoD" ID="Label38" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_mpod" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Port Of Destination" ReadOnly="True"></asp:TextBox>

                                    </div>

                                    <asp:Image ID="mpodflag" runat="server" Width="100%" />

                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="custom-col">
                                    <div class="MVessel">
                                        <asp:Label Text="M.Vessel" ID="Label30" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_mvessel" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Mother Vessel" ReadOnly="True"></asp:TextBox>
                                    </div>


                                    <div class="VoyageInput10">
                                        <asp:Label Text="ETD" ID="Label35" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_metd" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Estimated Time Of Departure" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="VoyageInput10 custom-mr-0" style="margin-right: 0px !important; width: 26.2% !important;">
                                        <asp:Label Text="ETA" ID="Label39" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_meta" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Expected Time Arrival" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="FormGroupContent4">


                                <div class="">
                                    <div class="pol">
                                        <asp:Label Text="Port Of Loading" ID="Label24" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_POL" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Port Of Loading" ReadOnly="True"></asp:TextBox>

                                    </div>


                                </div>
                                <div class="">
                                    <div class="pod">
                                        <asp:Label Text="Port of Destination" ID="Label20" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_POD" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Port of Destination" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>



                            <div class="FormGroupContent4">
                                <div class="custom-col" style="float: left; width: 100%;">
                                    <asp:Label Text="CFS" ID="lblCFS" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_cfs" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="Container Fright Station" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="DEStuff">
                                    <asp:Label Text="DeStuff" ID="Label31" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_destuff" runat="server" CssClass="form-control inputcolor" PlaceHolder="" ToolTip="DeStuff" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div id="div_BLDetails" runat="server">

                            <div class="FormGroupContent4 custom-d-flex hide">
                                <div class="custom-col custom-mr-05">
                                    <div class="VoyageInput10" style="width: 10%;">
                                        <asp:Label Text="Voyage" ID="Label29" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_voyage" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Voyage" ReadOnly="True"></asp:TextBox>
                                    </div>

                                </div>

                            </div>
                            <div class="FormGroupContent4 boxmodal">
                                <div class="DODate" id="dodaytxt" runat="server">
                                    <div class="FormGroupContent4">
                                        <asp:Label Text="DO Pending Days" ID="Label41" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_doday" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Delivery Order Pending Days" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>





                            </div>


                        </div>

                        <div class="div_view" id="div_BLvoucherdetail" runat="server" visible="false">
                            <div class="panel_04">
                                <asp:GridView CssClass="Grid FixedHeader" ID="Grd_Invoice" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found" PageSize="15"
                                    DataKeyNames="billtype,vouyear"
                                    OnSelectedIndexChanged="Grd_Invoice_SelectedIndexChanged"
                                    ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="invoiceno" HeaderText="Inv #" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                                        <asp:BoundField DataField="customername" HeaderText="Customer" />
                                        <asp:BoundField DataField="amount" HeaderText="Amount">
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                        </asp:BoundField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Lnk_Invoice" runat="server" CommandName="select" Font-Underline="false"
                                                    CssClass="Arrow">⇛</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="invoicedate" HeaderText="invoicedate">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                            <div class="div_Break">
                            </div>
                            <div class="panel_04">
                                <asp:GridView CssClass="Grid FixedHeader" ID="Grd_DN" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found" PageSize="15"
                                    DataKeyNames="vouyear" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="dnno" HeaderText="DN #" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                                        <asp:BoundField DataField="customername" HeaderText="Customer" />
                                        <asp:BoundField DataField="amount" HeaderText="Amount">
                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                            <div class="div_Break">
                            </div>
                            <div class="panel_04">
                                <asp:GridView CssClass="Grid FixedHeader" ID="Grd_receipt" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                                    PageSize="15" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="receipt" HeaderText="Receipt #" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                                        <asp:BoundField DataField="receiptdate" HeaderText="Date" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                                        <asp:BoundField DataField="receiptamount" HeaderText="Amount">
                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="chequeno" HeaderText="Cheque #" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                                        <asp:BoundField DataField="bank" HeaderText="Bank" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                                <div class="div_break"></div>
                            </div>
                            <div class="div_break"></div>
                        </div>

                        <div class="div_view" id="div_BLfreigthdetail" runat="server" visible="false">
                            <div class="panel_07">
                                <asp:GridView CssClass="Grid FixedHeader" ID="Grd_freightdetail" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                                    PageSize="15" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="charge" HeaderText="Charge" />
                                        <asp:BoundField DataField="curr" HeaderText="Curr" />
                                        <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" HeaderStyle-CssClass="right">
                                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                                            <HeaderStyle CssClass="align-right" Width="120px" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="exrate" HeaderText="Ex.Rate" DataFormatString="{0:#,##0.00}">
                                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                                            <HeaderStyle CssClass="align-right" Width="120px" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="base" HeaderText="Base" />
                                        <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                                            <HeaderStyle CssClass="align-right" Width="120px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                            <div class="panel_06">
                                <asp:GridView ID="Grid_BPRpt" runat="server" AutoGenerateColumns="true" CssClass="Grid FixedHeader" Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <%--<asp:BoundField DataField="paymentno" HeaderText="Payment#" />
                <asp:BoundField DataField="paymentdate" HeaderText="Payment Date"/>
                <asp:BoundField DataField="customername" HeaderText="Customer" />
                <asp:BoundField DataField="chequeno" HeaderText="Cheque #" />
                <asp:BoundField DataField="bankname" HeaderText="Bank" />
                <asp:BoundField DataField="paymentamount" HeaderText="PaymentAmount" DataFormatString="{0:#,##0.00}">
                <ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                <asp:BoundField DataField="Vouno" HeaderText="Against Vou#" />
                <asp:BoundField DataField="voudate" HeaderText="Against RefDate" />
                 <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                 <ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                <asp:BoundField DataField="clearedon" HeaderText="Cleared On" />--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                            <div class="div_break"></div>
                        </div>

                    </div>
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server">Bill Of Lading #:</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

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
                </div>
            </div>
        </div>
    </div>

    <%-- Elengo --%>
    <asp:Label ID="lbllog1" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:Label ID="LblCncl" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="PopCreditdet" runat="server" TargetControlID="LblCncl"
        BehaviorID="frgtydfdfdf" PopupControlID="pnlCreditdet" CancelControlID="imgcls" DropShadow="false">
    </asp:ModalPopupExtender>

    <asp:Panel ID="pnlCreditdet" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="OutStandingLbl1">
            <h3>Out Standing</h3>
        </div>
        <div class="OutStandingLbl2">Credit Customerwise OutStanding - <span id="CustomerLbl1" runat="server"></span></div>
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <div class="panel_18">
                <asp:GridView ID="grdCridtDet" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" OnRowDataBound="grdCridtDet_RowDataBound" OnPreRender="grdCridtDet_PreRender">
                    <Columns>
                        <asp:BoundField DataField="shortname" HeaderText="Branch">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 0 --%>
                        <asp:BoundField DataField="customername" HeaderText="Individual Customer  Names">
                            <HeaderStyle Width="250px" />
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <%-- 1 --%>
                        <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 2 --%>
                        <asp:BoundField DataField="invdate" HeaderText="Date">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 3 --%>
                        <asp:BoundField DataField="days" HeaderText="O/S Days">
                            <HeaderStyle />
                        </asp:BoundField>
                        <%-- 4 --%>
                        <asp:BoundField DataField="osamount" HeaderText="O/S Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <%-- 5 --%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False" />
                </asp:GridView>
            </div>
            <div class="Break"></div>
        </div>
        <div class="Break"></div>

    </asp:Panel>

    <asp:HiddenField ID="hid_BL" runat="server" Value="false" />
    <asp:HiddenField ID="hid_job" runat="server" />
    <asp:HiddenField ID="hid_contno" runat="server" />
    <asp:HiddenField ID="hid_customer" runat="server" />
    <asp:HiddenField ID="hid_BookingNo" runat="server" />
    <asp:HiddenField ID="hid_head" runat="server" />
    <asp:HiddenField ID="hid_cha" runat="server" />
    <asp:HiddenField ID="hid_split" runat="server" />
    <asp:HiddenField ID="hid_nomination" runat="server" />
    <asp:HiddenField ID="hid_CustomerId" runat="server" />
    <asp:HiddenField ID="Hf_ServerUsername" runat="server" Value="ifrtAdmin" />
    <asp:HiddenField ID="Hf_ServerPwd" runat="server" Value="05Jun!(&%" />
    <asp:HiddenField ID="hid_consign" runat="server" />
</asp:Content>
