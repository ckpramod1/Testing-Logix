<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FEBLdetails.aspx.cs" Inherits="logix.ShipmentDetails.FEBLdetails" %>

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

    <script src="../js/TextField.js"></script>
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <link href="../Styles/FEBLdetails.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
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

        .widget.box .widget-content {
            top: 0;
        }

        .Mark_Numbers textarea {
            height: 129px !important;
            width: 293px;
            float: left;
        }

        .Mark_Numbers {
            float: left;
            width: 23.5%;
            margin-right: 0.5%;
        }

            .Mark_Numbers span {
                float: left;
                width: 75% !important;
            }

        .Description {
            float: left;
            width: 100%;
            margin: 0px 0.5% 0px 0px;
        }

        .MarkLeft {
            margin-right: 0.5% !important;
            float: left;
            width: 100%;
        }

        .Description textarea {
            height: 152px !important;
        }

        .MarkRight1 {
            width: 12.5%;
            float: left;
            margin: 5px 0.5% 0px 0px !important;
        }

        table#logix_CPH_chk_containerlist {
            padding: 20px 0 0 5px !important;
            display: inline-block;
        }

        .Versel {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .POL {
            float: left;
            width: 100%;
            margin: 0px 0% 0px 0px;
        }

        .ETD {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .POD {
            float: left;
            width: 100%;
        }

        .ETN {
            float: left;
            width: 10%;
            margin-right: 0.5%;
        }

        .MLO {
            float: left;
            width: 100%;
            margin: 0;
        }

        .Details {
            float: left;
            width: 76%;
            margin-right: 0.5%;
        }

        .JobDetails {
            float: left;
            width: 34.9%;
        }

        .ETA {
            float: left;
            width: 100%;
        }

        .Carrier {
            float: left;
            width: 100%;
        }

        .Job_type {
            float: left;
            width: 100%;
        }

        .CarrierInput {
            float: left;
            width: 100%;
        }

        .MBLStatus {
            float: left;
            width: 100%;
            margin: 0px 0% 0px 0px;
        }

        .MBLNum {
            float: left;
            width: 100%;
            margin: 0px 0% 0px 0px;
        }

        .inputbox {
            width: 76%;
            float: left;
        }

        div#UpdatePanel1 span h2 {
            height: 88vh !important;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .FormGroupContent4 textarea {
            height: 152px !important;
        }

      img#logix_CPH_porflag {
    width: 24px !important;
    height: auto;
    position: relative;
    left: -146%;
    top: 437px;
    z-index: 10;
}

     img#logix_CPH_flagimg {
    width: 24px !important;
    height: auto;
    position: relative;
    left: -5%;
    top: 438px;
    z-index: 10;
}
     img#logix_CPH_podflag {
    width: 24px !important;
    height: auto;
    position: relative;
    left: 171%;
    top: 438px;
    z-index: 10;
}

     img#logix_CPH_fdflag {
    width: 24px !important;
    height: auto;
    position: relative;
    left: 339%;
    top: 438px;
    z-index: 10;
}

        .btn::before div {
            width: 36px;
            height: 34px;
            background: #f095562e;
            position: absolute;
            content: "";
            border-radius: 6px;
            border-right: 1px solid #b1b1b1;
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
            padding: 6px 6px 7px 42px !important;
            height: 34px !important;
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
            padding-top: 55px !important;
        }

        div#logix_CPH_CalendarExtender1_container {
            left: 0px !important;
        }

        div#logix_CPH_CalendarExtender2_container {
            left: 0px !important;
        }

        .BLSignatory {
            width: 23.2% !important;
            float: left;
            margin: 0px 0.5% 0px 0px !important;
        }

        .BLSignator2.DropTop.TextField {
            float: left;
            width: 100%;
        }

        .box1 {
            width: 36.5%;
            float: left;
            margin: 0px 0.5% 0px 0px
        }

        .box2 {
            width: 39.5%;
            float: left;
            margin: 0px 0.5% 0px 0px
        }

        .box3 {
            width: 23%;
            float: left;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            margin: 0px 0px 6px 0px;
        }

        .divleft1 {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px
        }

        .divleft2 {
            width: 49.9%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .slider.round {
            border-radius: 34px !important;
            width: 42px !important;
            height: 16px;
            margin: 0px 0 0;
        }

        .inputcolor {
            border-bottom: 1px solid var(--inputborder) !important;
        }

        .iputborder .FormGroupContent4 .TextField .form-control:disabled, .TextField .form-control[readonly] {
            background-color: #fff !important;
            opacity: 1;
            border-bottom: 1px solid #8080804f !important;
        }

        input#logix_CPH_txt_job, input#logix_CPH_txt_jobtype, input#logix_CPH_mbl, input#logix_CPH_mblstatus, input#logix_CPH_vessel, input#logix_CPH_pol, input#logix_CPH_etd, input#logix_CPH_pod, input#logix_CPH_eta, input#logix_CPH_mlo, input#logix_CPH_carrier, input#logix_CPH_txtcontract {
            border: none !important;
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
                width: 47% !important;
                height: 30vh !important;
                overflow: hidden !important;
                background: var(--white);
                border-radius: 3px;
                margin: 0px !important;
                position: relative;
            }

            div#logix_CPH_pnl_emp .DivSecPanel {
                position: relative;
                right: 18px;
                top: -1px;
            }

        input#logix_CPH_Btnamendbl {
            background-position: 1px 1px;
            width: 30px !important;
            scale: 0.7;
            margin-top: 10px;
        }

        div#logix_CPH_btn {
            width: 26px !important;
        }
        input#logix_CPH_btn_job {
        background-position: 0px 1px;
            width: 33px !important;
            scale: 0.7;
            margin-top: 10px;
}
        .btn.ico-add.input.custom-mt-2 {
    margin-top: -2px !important;
}
    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


            $(document).ready(function () {
                $('#<%=txt_receipt.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_receiptid.ClientID %>").val(0);

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
                        $('#<%=txt_receipt.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_receipt.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_receiptid.ClientID %>").val(ui.item.portid);
                        $('#<%=txt_receipt.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_receipt.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_receiptid.ClientID %>").val(ui.item.portid);
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
                $("#<%=txt_receipt.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_receiptid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetPort",
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
                        $("#<%=txt_receipt.ClientID %>").val(i.item.label);
                        $("#<%=txt_receipt.ClientID %>").change();
                        $("#<%=hid_receiptid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_receipt.ClientID %>").val(i.item.label);
                        $("#<%=hid_receiptid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_receipt.ClientID %>").val(i.item.label);
                        $("#<%=hid_receiptid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_receipt.ClientID %>").val(i.item.label);
                        $("#<%=hid_receiptid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>
            $(document).ready(function () {
                $('#<%=txt_loading.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_loadingid.ClientID %>").val(0);

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
                        $('#<%=txt_loading.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_loading.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_loadingid.ClientID %>").val(ui.item.portid);
                        $('#<%=txt_loading.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_loading.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_loadingid.ClientID %>").val(ui.item.portid);
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
                $("#<%=txt_loading.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_loadingid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetPort",
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
                        $("#<%=txt_loading.ClientID %>").val(i.item.label);
                        $("#<%=txt_loading.ClientID %>").change();
                        $("#<%=hid_loadingid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_loading.ClientID %>").val(i.item.label);
                        $("#<%=hid_loadingid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_loading.ClientID %>").val(i.item.label);
                        $("#<%=hid_loadingid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_loading.ClientID %>").val(i.item.label);
                        $("#<%=hid_loadingid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $('#<%=txt_discharge.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_dischargeid.ClientID %>").val(0);

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
                        $('#<%=txt_discharge.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_discharge.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_dischargeid.ClientID %>").val(ui.item.portid);
                        $('#<%=txt_discharge.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_discharge.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_dischargeid.ClientID %>").val(ui.item.portid);
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


<%--            $(document).ready(function () {
                $("#<%=txt_discharge.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_dischargeid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
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
                        $("#<%=txt_discharge.ClientID %>").val(i.item.label);
                        $("#<%=txt_discharge.ClientID %>").change();
                        $("#<%=hid_dischargeid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_discharge.ClientID %>").val(i.item.label);
                        $("#<%=hid_dischargeid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_discharge.ClientID %>").val(i.item.label);
                        $("#<%=hid_dischargeid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_discharge.ClientID %>").val(i.item.label);
                        $("#<%=hid_dischargeid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $('#<%=txt_destination.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_destinationid.ClientID %>").val(0);

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
                        $('#<%=txt_destination.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txt_destination.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_destinationid.ClientID %>").val(ui.item.portid);
                        $('#<%=txt_destination.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txt_destination.ClientID%>').val(ui.item.portname);
                        $("#<%=hid_destinationid.ClientID %>").val(ui.item.portid);
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
                $("#<%=txt_destination.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_destinationid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetPort",
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
                        $("#<%=txt_destination.ClientID %>").val(i.item.label);
                        $("#<%=txt_destination.ClientID %>").change();
                        $("#<%=hid_destinationid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_destination.ClientID %>").val(i.item.label);
                        $("#<%=hid_destinationid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_destination.ClientID %>").val(i.item.label);
                        $("#<%=hid_destinationid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_destination.ClientID %>").val(i.item.label);
                        $("#<%=hid_destinationid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $("#<%=txt_shipper.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_shipperid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                     <%-- select: function (event, i) {
                         $("#<%=hid_shipperid.ClientID %>").val(i.item.val);
                           $("#<%=txt_shipper.ClientID %>").change();
                           $("#<%=txt_shipperaddress.ClientID %>").val(i.item.address);
                       },
                     focus: function (e, i) {
                         $("#<%=hid_shipperid.ClientID %>").val(i.item.val);
                     },
                     close: function (e, i) {
                         var result = $("#<%=txt_shipper.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_shipper.ClientID %>").val($.trim(result));
                        $("#<%=txt_shipperaddress.ClientID %>").val(i.item.address);
                    },--%>

                    select: function (e, i) {
                        $("#<%=hid_shipperid.ClientID %>").val(i.item.val);
                        $("#<%=txt_shipper.ClientID %>").val(i.item.text);
                        $("#<%=txt_shipper.ClientID %>").val($.trim(i.item.label));
                        $("#<%=txt_shipperaddress.ClientID %>").val(i.item.address);
                        $("#<%=txt_shipper.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_shipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipper.ClientID %>").val(i.item.text);
                            $("#<%=txt_shipperaddress.ClientID %>").val(i.item.address);
                            $("#<%=txt_shipper.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hid_shipperid.ClientID %>").val(i.item.val);
                        $("#<%=txt_shipper.ClientID %>").val(i.item.text);
                        $("#<%=txt_shipperaddress.ClientID %>").val(i.item.address);

                        var result = $("#<%=txt_shipper.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_shipper.ClientID %>").val($.trim(out));
                        }
                        else {
                            $("#<%=txt_shipper.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_shipper.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_shipper.ClientID %>").val($.trim(out));
                        }
                        else {
                            $("#<%=txt_shipper.ClientID %>").val($.trim(res));
                        }
                        $("#<%=txt_shipperaddress.ClientID %>").val(i.item.address);
                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_consignee.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_consigneeid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                     <%-- select: function (event, i) {
                         $("#<%=hid_consigneeid.ClientID %>").val(i.item.val);
                         $("#<%=txt_consignee.ClientID %>").change();
                         $("#<%=txt_consigneeaddress.ClientID %>").val(i.item.address);
                     },
                     focus: function (e, i) {
                         $("#<%=hid_consigneeid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_consignee.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_consignee.ClientID %>").val($.trim(result));
                        $("#<%=txt_consigneeaddress.ClientID %>").val(i.item.address);
                    },--%>
                    select: function (e, i) {
                        $("#<%=hid_consigneeid.ClientID %>").val(i.item.val);
                         $("#<%=txt_consignee.ClientID %>").val(i.item.text);
                         $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label));
                         $("#<%=txt_consigneeaddress.ClientID %>").val(i.item.address);
                         $("#<%=txt_consignee.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_consigneeid.ClientID %>").val(i.item.val);
                             $("#<%=txt_consignee.ClientID %>").val(i.item.text);
                             $("#<%=txt_consigneeaddress.ClientID %>").val(i.item.address);
                             $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hid_consigneeid.ClientID %>").val(i.item.val);
                         $("#<%=txt_consignee.ClientID %>").val(i.item.text);
                         $("#<%=txt_consigneeaddress.ClientID %>").val(i.item.address);

                         var result = $("#<%=txt_consignee.ClientID %>").val().toString();
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_consignee.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_consignee.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_consignee.ClientID %>").val().toString();
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_consignee.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_consignee.ClientID %>").val($.trim(res));
                         }
                         $("#<%=txt_consigneeaddress.ClientID %>").val(i.item.address);
                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_notify.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_notifyid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                     <%-- select: function (event, i) {
                         $("#<%=hid_notifyid.ClientID %>").val(i.item.val);
                         $("#<%=txt_notify.ClientID %>").change();
                         $("#<%=txt_notifyaddress.ClientID %>").val(i.item.address);
                     },
                     focus: function (e, i) {
                         $("#<%=hid_notifyid.ClientID %>").val(i.item.val);
                     },
                     close: function (e, i) {
                         var result = $("#<%=txt_notify.ClientID %>").val().toString().split(',')[0];
                         $("#<%=txt_notify.ClientID %>").val($.trim(result));
                         $("#<%=txt_notifyaddress.ClientID %>").val(i.item.address);
                     },--%>

                    select: function (e, i) {
                        $("#<%=hid_notifyid.ClientID %>").val(i.item.val);
                         $("#<%=txt_notify.ClientID %>").val(i.item.text);
                         $("#<%=txt_notify.ClientID %>").val($.trim(i.item.label));
                         $("#<%=txt_notifyaddress.ClientID %>").val(i.item.address);
                         $("#<%=txt_notify.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_notifyid.ClientID %>").val(i.item.val);
                             $("#<%=txt_notify.ClientID %>").val(i.item.text);
                             $("#<%=txt_notifyaddress.ClientID %>").val(i.item.address);
                             $("#<%=txt_notify.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hid_notifyid.ClientID %>").val(i.item.val);
                         $("#<%=txt_notify.ClientID %>").val(i.item.text);
                         $("#<%=txt_notifyaddress.ClientID %>").val(i.item.address);

                         var result = $("#<%=txt_notify.ClientID %>").val().toString();
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_notify.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_notify.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_notify.ClientID %>").val().toString();
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_notify.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_notify.ClientID %>").val($.trim(res));
                         }
                         $("#<%=txt_notifyaddress.ClientID %>").val(i.item.address);
                    },

                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txt_agent.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hid_agentid.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'P'}",
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

                     <%-- select: function (event, i) {
                         $("#<%=hid_agentid.ClientID %>").val(i.item.val);
                          $("#<%=txt_agent.ClientID %>").change();
                          $("#<%=txt_agentaddress.ClientID %>").val(i.item.address);
                      },
                     focus: function (e, i) {
                         $("#<%=hid_agentid.ClientID %>").val(i.item.val);
                     },
                     close: function (e, i) {
                         var result = $("#<%=txt_agent.ClientID %>").val().toString().split(',')[0];
                         $("#<%=txt_agent.ClientID %>").val($.trim(result));
                         $("#<%=txt_agentaddress.ClientID %>").val(i.item.address);
                     },--%>

                     select: function (e, i) {
                         $("#<%=hid_agentid.ClientID %>").val(i.item.val);
                         $("#<%=txt_agent.ClientID %>").val(i.item.text);
                         $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label));
                         $("#<%=txt_agentaddress.ClientID %>").val(i.item.address);
                         $("#<%=txt_agent.ClientID %>").change();
                     },
                     change: function (e, i) {
                         if (i.item) {
                             $("#<%=hid_agentid.ClientID %>").val(i.item.val);
                             $("#<%=txt_agent.ClientID %>").val(i.item.text);
                             $("#<%=txt_agentaddress.ClientID %>").val(i.item.address);
                             $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label));
                         }
                     },
                     focus: function (e, i) {
                         $("#<%=hid_agentid.ClientID %>").val(i.item.val);
                         $("#<%=txt_agent.ClientID %>").val(i.item.text);
                         $("#<%=txt_agentaddress.ClientID %>").val(i.item.address);

                         var result = $("#<%=txt_agent.ClientID %>").val().toString();
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_agent.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_agent.ClientID %>").val($.trim(res));
                         }
                     },
                     close: function (e, i) {
                         var result = $("#<%=txt_agent.ClientID %>").val().toString();
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_agent.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_agent.ClientID %>").val($.trim(res));
                         }
                         $("#<%=txt_agentaddress.ClientID %>").val(i.item.address);
                     },
                     minLength: 1
                 });
             });
            $(document).ready(function () {

                $("#<%=txt_vessel.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hid_vesselid.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetVessel",
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
                         $("#<%=hid_vesselid.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                         $("#<%=hid_vesselid.ClientID %>").val(i.item.val);
                     },
                     change: function (event, i) {
                         $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                         $("#<%=hid_vesselid.ClientID %>").val(i.item.val);

                     },
                     close: function (event, i) {
                         $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                         $("#<%=hid_vesselid.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });

            $(document).ready(function () {

                $("#<%=txt_bl.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $.ajax({
                             url: "FEBLdetails.aspx/GetBLdetail",
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
                         $("#<%=txt_bl.ClientID %>").change();

                     },
                     change: function (event, i) {
                         $("#<%=txt_bl.ClientID %>").val(i.item.value);

                     },
                     focus: function (event, i) {
                         $("#<%=txt_bl.ClientID %>").val(i.item.value);

                     },
                     close: function (event, i) {
                         $("#<%=txt_bl.ClientID %>").val(i.item.value);

                     },
                     minLength: 1
                 });
             });



            $(document).ready(function () {
                $('#<%=txt_issued.ClientID%>').autocomplete({
                           source: function (request, response) {
                               $("#<%=hid_issued.ClientID %>").val(0);

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
                  $('#<%=txt_issued.ClientID%>').val(ui.item.portname);
                  return false;
              },
              select: function (event, ui) {
                  $('#<%=txt_issued.ClientID%>').val(ui.item.portname);
                  $("#<%=hid_issued.ClientID %>").val(ui.item.portid);
                  $('#<%=txt_issued.ClientID%>').change();
                  return false;
              },
              change: function (event, ui) {
                  $('#<%=txt_issued.ClientID%>').val(ui.item.portname);
                  $("#<%=hid_issued.ClientID %>").val(ui.item.portid);
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
                $("#<%=txt_commotity.ClientID %>").autocomplete({

                         source: function (request, response) {
                             $("#<%=hid_cargoid.ClientID %>").val(0);
                             $.ajax({
                                 url: "../Autocomplete/Autocomplete.aspx/GetCargo",
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
                             $("#<%=txt_commotity.ClientID %>").val(i.item.label);
                             $("#<%=txt_commotity.ClientID %>").change();
                             $("#<%=hid_cargoid.ClientID %>").val(i.item.val);
                         },
                         focus: function (event, i) {
                             $("#<%=txt_commotity.ClientID %>").val(i.item.label);
                             $("#<%=hid_cargoid.ClientID %>").val(i.item.val);
                         },
                         change: function (event, i) {
                             $("#<%=txt_commotity.ClientID %>").val(i.item.label);
                             $("#<%=hid_cargoid.ClientID %>").val(i.item.val);

                         },
                         close: function (event, i) {
                             $("#<%=txt_commotity.ClientID %>").val(i.item.label);
                             $("#<%=hid_cargoid.ClientID %>").val(i.item.val);
                         },
                         minLength: 1
                     });
                 });

            <%--             $(document).ready(function () {
                 $("#<%=txt_cha.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hid_chaid.ClientID %>").val(0);
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
                             $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=txt_cha.ClientID %>").change();
                             $("#<%=hid_chaid.ClientID %>").val(i.item.val);
                         }
                     },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_chaid.ClientID %>").val(i.item.val);
                         }
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_chaid.ClientID %>").val(i.item.val);
                         }
                     },
                     close: function (event, i) {
                         if (i.item) {
                             $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_chaid.ClientID %>").val(i.item.val);
                         }
                     },
                     minLength: 1
                 });
             });--%>
            $(document).ready(function () {
                $("#<%=txt_cha.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_chaid.ClientID %>").val(0);
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
                        $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_chaid.ClientID %>").val(i.item.val);
                        $("#<%=txt_cha.ClientID %>").change();
                        $("#<%=txt_cha.ClientID %>").val(i.item.address);

                    },
                    focus: function (event, i) {
                        $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_chaid.ClientID %>").val(i.item.val);
                        $("#<%=txt_cha.ClientID %>").val($.trim(result));
                        $("#<%=txt_cha.ClientID %>").val(i.item.address);

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cha.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_chaid.ClientID %>").val(i.item.val);
                            $("#<%=txt_cha.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_cha.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_cha.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });

        }

    </script>
    <style type="text/css">
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

        .div_Vessel {
            width: 100%;
        }

        .txt_Vessel1 {
            width: 33%;
            float: left;
            margin-left: 1%;
            margin-top: 0.5%;
        }

            .txt_Vessel1 input {
                width: 100%;
            }

        .txt_Vessel2 {
            width: 33%;
            float: left;
            margin-left: 0.55%;
            margin-top: 0.5%;
        }

            .txt_Vessel2 input {
                width: 100%;
            }

        .txt_Vessel3 {
            width: 30.75%;
            float: left;
            margin-left: 0.5%;
            margin-top: 0.5%;
        }

            .txt_Vessel3 input {
                width: 100%;
            }

        #logix_CPH_ddl_unit_chzn {
            width: 100% !important;
        }

        #logix_CPH_popup_Grd_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_popup_Grd1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }



        .OrignalInputourblnew {
            width: 27.8%;
            float: left;
            margin: 0px 1.5% 0px 0px;
        }

        #logix_CPH_BLTYPE_chzn {
            width: 100% !important;
        }

        .FrieghtDropBLnew {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IssuedInput {
            width: 25.9%;
            float: left;
            margin: 0px 1.5% 0px 0px;
            font-size: 11px;
            color: #000080;
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
            width: 11%;
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
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .btn-logic1 a {
            border: medium none;
            line-height: normal;
            color: #4e4e4c !important;
            padding: 5px 0px 10px 28px;
            background: url(../Theme/assets/img/buttonIcon/log_ic.png) no-repeat left 0px;
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
            z-index: 10;
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

        .JobInput6 {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .BookingInput4 {
            width: 16%;
            margin: 0px 0.5% 0 0%;
            float: left;
            font-size: 11px;
        }

        .JobDetails1 {
            width: 72.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BookingNo6 {
            width: 6.5%;
            text-align: right;
            float: right;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
            width: 98%;
            height: 555px;
            margin-left: 1%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }

        .LadingInput {
            width: 43.8%;
            float: left;
            margin: 0px 1.5% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .IssuedDate {
            width: 19.6%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .FrieghtDropBL {
            width: 24%;
            float: left;
            margin: 0px 1.5% 0px 0px;
            font-size: 12px;
            color: #000080;
        }


        .ShipperInput4 {
            width: 36.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .ConsigneeInput {
            width: 39.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .PlaceInput1 {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .PortInput2 {
            width: 50%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .DischargeInput {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .DestinationInputN {
            width: 50%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .MarksInput {
            width: 100%;
            margin: 0px 0px 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .RemarksInput {
            width: 100%;
            margin: 5px 0px 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .CommodityInput {
            width: 98.7%;
            float: left;
            margin: 0px 0px 0px 0px;
            border: 0px solid #b1b1b1;
            font-size: 12px;
            color: #000080;
        }

        .CubicInput {
            width: 13.9%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .GrossWeightInput {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .NetweigInput {
            width: 26.5%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .NoPkgsInput {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 12px;
            color: #000080;
        }

        .BagDrop {
            width: 23% !important;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ShipmentDrop {
            width: 21%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        div#logix_CPH_ddl_move_chzn {
            width: 100% !important;
        }

        .BLDrop {
            width: 22.7%;
            float: left;
            margin: 0px 1.5% 0px 0px;
            font-size: 11px;
        }

        .BLSignatory1 {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px !important;
        }

        .RemarksInput4 {
            width: 39.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BLSignatory

        .TextField .chzn-container-single .chzn-default {
            height: 41px !important;
        }

        .BLSignatory2 {
            float: left;
            width: 22.9%;
        }

        .CustomerInput7 {
            width: 36.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .DGCargo {
            width: 11%;
            float: left;
            text-align: left;
            margin: 15px 0% 0px 9px;
        }

        .AGB {
            width: 20%;
            float: left;
            margin: 15px 0px 0px 0px;
        }

        .BlankInput {
            background-color: white;
            border: 0px solid var(--inputborder) !important;
            width: 100%;
            border-radius: 0px;
            height: 163px;
            position: relative;
            border-bottom: 1px solid var(--inputborder) !important;
        }

            .BlankInput span {
                color: rgb(6, 82, 156);
                top: 0px !important;
                font-size: 13px !important;
                font-weight: 500 !important;
            }

        .ShipperInput4, .ConsigneeInput {
            margin-right: 0.5% !important;
        }

        .Commodity {
            float: left;
            width: 49.4%;
        }

        .AGB span {
            color: rgb(6, 82, 156);
            font-size: 9px;
            font-weight: normal !important;
        }


        textarea#logix_CPH_txt_shipperaddress, textarea#logix_CPH_txt_consigneeaddress, textarea#logix_CPH_txt_notifyaddress, textarea#logix_CPH_txt_agentaddress {
            height: 98px !important;
        }

        .Mark_Number {
            float: left;
            width: 100%;
            margin-right: 0.5%;
        }

        .TextField .inputcolor, .TextField .inputcolor:focus {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            font-weight: normal !important;
        }

        .box3 span {
            background: #80808000 !important;
        }

        .box3 .FormGroupContent4 {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }

        textarea#logix_CPH_txt_agentaddress {
            height: 89px !important;
        }

        textarea#logix_CPH_txt_notifyaddress {
            height: 89px !important;
        }

        textarea#logix_CPH_txt_description, textarea#logix_CPH_txt_mark {
            height: 158px !important;
        }

        textarea#logix_CPH_txt_shipperaddress, textarea#logix_CPH_txt_consigneeaddress {
            height: 104px !important;
        }
  img#logix_CPH_issuedflag {
    width: 24px !important;
    height: auto;
    position: relative;
    left: -102%;
    top: 62px;
    z-index: 1;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                         <div style="float: left; margin: 0px 0.5% 0px 0px;">
                           <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_header" runat="server"></asp:Label></h4>
     <!-- Breadcrumbs line -->
                   <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i><a href="#"></a>Home </li>
                        <li><a href="#" title="" id="menu" runat="server">Documentation</a></li>
                        <li><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Exports</a> </li>
                        <li class="current"><a href="#" title="" id="headerlable" runat="server"></a></li>
                        </ul>
                     </div>
                 </div>
                               <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                                <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                                 </div>
                   

                    </div>
                     <div class="FixedButtons">
                      <div class="left_btn">
                       <div class="btn ico-proforma-sales-invoice ">
                       <asp:Button ID="Proinvoic" runat="server" Text="Proforma Sales Invoice" ToolTip="Proforma Sales Invoice" TabIndex="45" OnClick="Proinvoic_Click" />
                    </div>
                      <div class="btn ico-proforma-purchase-invoice">
                     <asp:Button ID="procrednote" runat="server" Text="Proforma Purchase Invoice" ToolTip="Proforma Purchase Invoice" TabIndex="46" OnClick="procrednote_Click" />
                    </div>
      

                    </div>
                         <div class="left_btn custom-mt-0 hide">
    <asp:LinkButton ID="lnkfrght" CssClass="anc ico-find-sm" runat="server" Style="text-decoration: none;" ForeColor="Red" OnClick="lnkfrght_Click"></asp:LinkButton>
</div>
<div class="right_btn">
    <div class="btn ico-BL-release">
        <asp:Button ID="btn_blrelease" runat="server" Text="BL Release" ToolTip="BL Release" TabIndex="45" OnClick="btn_blrelease_Click" />
    </div>

    <div class="btn ico-reuse">
        <asp:Button ID="Btn_reuse" runat="server" Text="Reuse" ToolTip="Reuse" OnClick="Btn_reuse_Click" />
    </div>

    <div class="btn ico-view" id="btn_view1" runat="server" visible="false">
        <asp:Button ID="btn_view" runat="server" Text="View" Visible="false" ToolTip="View" OnClick="btn_view_Click" />
    </div>
    <div class="btn ico-save" id="Btn_save1" runat="server">
        <asp:Button ID="Btn_save" runat="server" ToolTip="Save" TabIndex="47" OnClick="Btn_save_Click" />

    </div>
    <div class="btn ico-delete">
        <asp:Button ID="Btn_delete" runat="server" TabIndex="48" Text="Delete" ToolTip="Delete" OnClick="Btn_delete_Click" />
    </div>
    <div class="btn ico-cancel" id="Btn_cancel1" runat="server">
        <asp:Button ID="Btn_cancel" runat="server" TabIndex="49" Text="Cancel" ToolTip="Cancel" OnClick="Btn_cancel_Click" />

    </div>
</div>
                         </div>
                   
                </div>

                   

                <div class="widget-content">
                   
                        
                    </div>
                    <div class="FormGroupContent4" id="div_vessel" visible="false" runat="server">
                        <div class="VesselInput5">
                            <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" placeholder="Vessel" ToolTip="Vessel" AutoPostBack="true" OnTextChanged="txt_vessel_TextChanged"></asp:TextBox>
                        </div>
                        <div class="VoyageInput5">
                            <asp:TextBox ID="txt_voyage" runat="server" CssClass="form-control" placeholder="Voyage" ToolTip="Voyage"></asp:TextBox>
                        </div>
                        <div class="ContainerInput5">
                            <asp:TextBox ID="txt_container" runat="server" CssClass="form-control" placeholder="Containers" ToolTip="Containers"></asp:TextBox>
                        </div>
                    </div>



                    <div class="FormGroupContent4 boxmodal">

                        <div class="JobDetails1 hide">
                            <asp:Label ID="Label3" runat="server" Text="Job Details"></asp:Label>
                            <asp:TextBox ID="txt_detail" runat="server" TabIndex="1" CssClass="form-control" placeholder="" ToolTip="Job Details"></asp:TextBox>
                            <asp:LinkButton ID="lnk_job" runat="server" Text="Job #" CssClass="boxmodalLink hide" ForeColor="#FF3300" Style="text-decoration: none" OnClick="lnk_job_Click"></asp:LinkButton>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">

                        <div class="BookingInput4">
                            <span>Booking #</span>
                            <asp:TextBox ID="txt_booking" TabIndex="2" runat="server" CssClass="form-control" placeholder="" ToolTip="Booking Number" ReadOnly="true"></asp:TextBox>
                        </div>
                        <asp:LinkButton ID="lnk_booking" runat="server" CssClass="anc ico-find-sm" OnClick="lnk_booking_Click" Style="text-decoration: none" ForeColor="#FF3300"></asp:LinkButton>


                        <div class="FrieghtDropBLnew">
                            <div class="FormGroupContent4">
                                <asp:Label ID="Label5" runat="server" Text="BL"></asp:Label>
                                <asp:DropDownList ID="BLTYPE" Width="100%" data-placeholder="BL TYPE" Height="25" runat="server" TabIndex="3" AutoPostBack="true" CssClass="chzn-select" ToolTip="BL TYPE" OnSelectedIndexChanged="BLTYPE_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Our BL"></asp:ListItem>
                                    <asp:ListItem Text="Liner BL"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        

                        </div>

                        <div style="float:left" >
                                <asp:Image ID="porflag" runat="server" Width="100%" />
    <asp:Image ID="flagimg" runat="server" Width="100%" />
    <asp:Image ID="podflag" runat="server" Width="100%" />
    <asp:Image ID="fdflag" runat="server" Width="100%" />

     <asp:Image ID="issuedflag" runat="server" Width="100%" />
                        </div>



                    </div>



                    <div class="box1">

                        <div class="FormGroupContent4">
                            <div class="LadingInput">
                                <asp:Label ID="Label6" runat="server" Text=" Bill Of Lading #"></asp:Label>
                                <asp:TextBox ID="txt_bl" runat="server" CssClass="form-control" AutoPostBack="true" onkeyup="CheckTextLength(this,30);" TabIndex="4" OnTextChanged="txt_bl_TextChanged" placeholder="" ToolTip="Our BL" onkeypress="if (event.keyCode==39 ||event.keyCode==34) event.returnValue = false;"></asp:TextBox>
                            </div>
                               <div class="btn ico-edit" id="btn" runat="server">
       <asp:Button ID="Btnamendbl" runat="server" ToolTip="Amend BL" TabIndex="41" OnClick="Btnamendbl_Click" />
   </div>
                            <div class="IssuedInput">
                                <asp:Label ID="Label7" runat="server" Text="Issued At"></asp:Label>
                                <asp:TextBox ID="txt_issued" runat="server" CssClass="form-control" TabIndex="5" AutoPostBack="true" OnTextChanged="txt_issued_TextChanged" placeholder="" ToolTip="Issued At"></asp:TextBox>
                            </div>
                            <div class="IssuedDate">
                                <asp:Label ID="Label8" runat="server" Text="Issued on"></asp:Label>
                                <asp:TextBox ID="txt_issuedon" runat="server" Enabled="true" TabIndex="6" placeholder="" ToolTip="Issued on" CssClass="form-control date"></asp:TextBox>
                                <asp:CalendarExtender ID="txtdatecalExd" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_issuedon"></asp:CalendarExtender>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label11" runat="server" Text="Shipper"></asp:Label>
                            <asp:TextBox ID="txt_shipper" runat="server" CssClass="form-control" TabIndex="9" placeholder="" ToolTip="Shipper" AutoPostBack="true" OnTextChanged="txt_shipper_TextChanged"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label32" runat="server" Text="Shipper Address"></asp:Label>
                            <asp:TextBox ID="txt_shipperaddress" runat="server" Rows="3" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Shipper Address"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4 ">
                            <asp:Label ID="Label13" runat="server" Text="Notify Party"></asp:Label>
                            <asp:TextBox ID="txt_notify" runat="server" CssClass="form-control" TabIndex="11" placeholder=" " ToolTip="Notify Party" AutoPostBack="true" OnTextChanged="txt_notify_TextChanged"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label34" runat="server" Text="Notify Address"> </asp:Label>
                            <asp:TextBox ID="txt_notifyaddress" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" placeholder="" ToolTip="Notify Address"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="PlaceInput1">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label14" runat="server" Text="Place of Receipt"></asp:Label>
                                    <asp:TextBox ID="txt_receipt" TabIndex="13" runat="server" CssClass="form-control" placeholder="" ToolTip="Place of Receipt" AutoPostBack="true" OnTextChanged="txt_receipt_TextChanged"></asp:TextBox>

                                </div>



                            </div>
                            <div class="PortInput2">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label15" runat="server" Text="Port of Loading"></asp:Label>

                                    <asp:TextBox ID="txt_loading" TabIndex="14" runat="server" CssClass="form-control" placeholder="" ToolTip="Port of Loading" AutoPostBack="true" OnTextChanged="txt_loading_TextChanged"></asp:TextBox>
                                </div>


                            </div>



                        </div>
                        <div class="FormGroupContent4">
                            <div class="Commodity">
                                <asp:Label ID="Label20" runat="server" Text="Commodity"></asp:Label>
                                <asp:TextBox ID="txt_commotity" TabIndex="17" runat="server" AutoPostBack="true" OnTextChanged="txt_commotity_TextChanged" CssClass="form-control" placeholder="" ToolTip="Commodity"></asp:TextBox>
                            </div>
                            <div class="DGCargo">
                                <span class=" chktext">Haz</span>
                                <center>
                                    <label class="switch">
                                        <asp:CheckBox ID="Chk_DG" TabIndex="18" runat="server" />

                                    </label>
                                </center>


                            </div>

                            <div class="BLSignatory">
                                <asp:Label ID="Label36" runat="server" Text="Terms"></asp:Label>
                                <asp:DropDownList ID="ddl_move" runat="server" data-placeholder="Move Type" ToolTip="Move Type" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem></asp:ListItem>
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
                            <div class="CubicInput">
                                <asp:Label ID="Label21" runat="server" Text="CBM"></asp:Label>
                                <asp:TextBox ID="txt_cbm" AutoPostBack="true" runat="server" TabIndex="36" CssClass="form-control" placeholder="" ToolTip="Cubic Meter" OnTextChanged="txt_cbm_TextChanged1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="divleft1">

                                <div class="Mark_Number">
                                    <asp:Label ID="Label18" runat="server" Text="Marks and Numbers"></asp:Label>
                                    <asp:TextBox ID="txt_mark" runat="server" TextMode="MultiLine" Rows="3" Style="resize: none;" TabIndex="19" onkeyup="CheckTextLength(this,500);" CssClass="form-control" placeholder="" ToolTip="Marks and Numbers"></asp:TextBox>

                                </div>


                            </div>
                            <div class="divleft2">


                                <div class="BlankInput TextArea">

                                    <span>Container #</span>
                                    <asp:CheckBoxList ID="chk_containerlist" runat="server" TabIndex="20" DataTextField="CONTAINER#" placeholder="Container #" ToolTip="Container Number">
                                    </asp:CheckBoxList>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="box2">
                        <div class="FormGroupContent4">
                            <div class="FrieghtDropBL">
                                <asp:Label ID="Label9" runat="server" Text="Freight"></asp:Label>
                                <asp:DropDownList ID="ddl_freight" data-placeholder="Freight Status" Height="25" runat="server" TabIndex="7" CssClass="chzn-select" ToolTip="Freight Status">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="P">Prepaid</asp:ListItem>
                                    <asp:ListItem Value="C">Collect</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="OrignalInputourblnew">
                                <asp:Label ID="Label10" runat="server" Text="No. of Originals"></asp:Label>
                                <asp:TextBox ID="txt_orignalbl" runat="server" TabIndex="8" CssClass="form-control" AutoPostBack="true" placeholder=" " ToolTip="No. of Original Bill of Lading" OnTextChanged="txt_orignalbl_TextChanged"></asp:TextBox>
                            </div>
                            <div class="BLDrop">
                                <asp:Label ID="Label27" runat="server" Text="BL Status"></asp:Label>
                                <asp:DropDownList ID="ddl_HTS" Height="25" TabIndex="35" runat="server" data-placeholder="BL Status" CssClass="chzn-select" ToolTip="BL Status">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="R">Release</asp:ListItem>
                                    <asp:ListItem Value="B">SeaWayBill</asp:ListItem>
                                    <asp:ListItem Value="S">Surrendered</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="ShipmentDrop">
                                <asp:Label ID="Label26" runat="server" Text="Shipment"></asp:Label>
                                <asp:DropDownList ID="ddl_shipment" Height="25" TabIndex="34" runat="server" data-placeholder="Shipment" CssClass="chzn-select" ToolTip="Shipment">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="1">FCL/FCL</asp:ListItem>
                                    <asp:ListItem Value="2">FCL/LCL</asp:ListItem>
                                    <asp:ListItem Value="3">LCL/LCL</asp:ListItem>
                                    <asp:ListItem Value="4">LCL/FCL</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="AGB hide ">
                                <span class="chktext">AGENT CONTROLLED BUSINESS</span>
                                <center>
                                    <label class="switch">
                                        <asp:CheckBox ID="chk_agent" TabIndex="9" CssClass="hide" runat="server" />

                                    </label>
                                </center>

                            </div>
                        </div>
                        <div class=" FormGroupContent4">
                            <asp:Label ID="Label12" runat="server" Text="Consignee"></asp:Label>
                            <asp:TextBox ID="txt_consignee" runat="server" CssClass="form-control" TabIndex="10" placeholder="" ToolTip="Consignee" AutoPostBack="true" OnTextChanged="txt_consignee_TextChanged"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label33" runat="server" Text="Consignee Address"></asp:Label>
                            <asp:TextBox ID="txt_consigneeaddress" runat="server" Rows="3" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Consignee Address"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label31" runat="server" Text="Agent"></asp:Label>
                            <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" TabIndex="12" placeholder="" ToolTip="Agent" AutoPostBack="true" OnTextChanged="txt_agent_TextChanged"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label35" runat="server" Text="Agent Address"> </asp:Label>
                            <asp:TextBox ID="txt_agentaddress" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" placeholder="" ToolTip="Agent Address"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="DischargeInput">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label16" runat="server" Text="Port of Discharge"></asp:Label>
                                    <asp:TextBox ID="txt_discharge" TabIndex="15" runat="server" CssClass="form-control" placeholder="" ToolTip="Port of Discharge" AutoPostBack="true" OnTextChanged="txt_discharge_TextChanged"></asp:TextBox>

                                </div>


                            </div>
                            <div class="DestinationInputN">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label17" runat="server" Text="Place of Delivery"></asp:Label>
                                    <asp:TextBox ID="txt_destination" TabIndex="16" runat="server" CssClass="form-control" placeholder="" ToolTip="Place of Delivery" AutoPostBack="true" OnTextChanged="txt_destination_TextChanged"></asp:TextBox>

                                </div>


                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="NoPkgsInput">
                                <asp:Label ID="Label24" runat="server" Text="Packages"></asp:Label>
                                <asp:TextBox ID="txt_pkgs" runat="server" TabIndex="37" AutoPostBack="true" onkeypress="return isNumberKey(event,'No of Pkg');" CssClass="form-control" placeholder="" ToolTip="Number of Packages"></asp:TextBox>
                            </div>
                            <div class="BagDrop">
                                <asp:Label ID="Label25" runat="server" Text="UoM"></asp:Label>
                                <asp:DropDownList ID="ddl_unit" runat="server" Height="25" TabIndex="38" data-placeholder="Units" CssClass="chzn-select" ToolTip="Units">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="GrossWeightInput">
                                <asp:Label ID="Label22" runat="server" Text="Grs Wt(KGS)"></asp:Label>
                                <asp:TextBox ID="txt_grwt" runat="server" AutoPostBack="true" TabIndex="39" CssClass="form-control" placeholder="" ToolTip="Gross Weight KGS" OnTextChanged="txt_grwt_TextChanged"></asp:TextBox>
                            </div>
                            <div class="NetweigInput">
                                <asp:Label ID="Label23" runat="server" Text="Net Wt(KGS)"></asp:Label>
                                <asp:TextBox ID="txt_ntwt" TabIndex="40" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="" ToolTip="Net Weight KGS"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Description">
                                <asp:Label ID="Label19" runat="server" Text="Description"></asp:Label>
                                <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" Rows="3" TabIndex="21" onkeyup="CheckTextLength(this,1500);" CssClass="form-control" placeholder="" Style="resize: none;" ToolTip="Description"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="box3">
                        <div class="FormGroupContent4 boxmodal">


                            <div class="JobDetails inputborder">

                                <span>Job #</span>

                                <asp:TextBox ID="txt_job" runat="server" TabIndex="24" CssClass="form-control inputcolor" OnTextChanged="txt_job_TextChanged" placeholder="" ToolTip="JOB Number" AutoPostBack="true" ReadOnly="true"></asp:TextBox>




                                <%--onkeypress="return isNumberKey(event,'Original BL');"--%>
                            </div>
                            <div class="btn ico-add input custom-mt-2">
                                <asp:Button ID="btn_job" runat="server" Text="Job" ToolTip="Job" TabIndex="45" OnClick="btn_job_Click" />
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="Job_type inputborder">
                                <span>Job Type</span>
                                <asp:TextBox runat="server" ID="txt_jobtype" CssClass="form-control inputcolor" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MBLNum inputborder">
                                <span>MBL #</span>
                                <asp:TextBox runat="server" ID="mbl" CssClass="form-control inputcolor" TabIndex="32" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MBLStatus inputborder">
                                <span>MBL Status</span>
                                <asp:TextBox runat="server" ID="mblstatus" CssClass="form-control inputcolor" TabIndex="33" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Versel inputborder">
                                <span>Vessel</span>
                                <asp:TextBox ID="vessel" runat="server" CssClass="form-control inputcolor" TabIndex="25" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="POL inputborder">
                                <span>Vessel PoL</span>
                                <asp:TextBox runat="server" ID="pol" CssClass="form-control inputcolor" TabIndex="26" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="ETD inputborder">
                                <span>ETD</span>
                                <asp:TextBox runat="server" ID="etd" CssClass="form-control inputcolor" TabIndex="27" ReadOnly="true" />
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="etd"></asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">



                            <div class="POD inputborder">
                                <span>Vessel PoD</span>
                                <asp:TextBox runat="server" ID="pod" CssClass="form-control inputcolor" TabIndex="28" ReadOnly="true" />
                            </div>






                        </div>
                        <div class="FormGroupContent4 ">
                            <div class="ETA inputborder">
                                <span>ETA</span>
                                <asp:TextBox runat="server" ID="eta" CssClass="form-control inputcolor" TabIndex="29" ReadOnly="true" />
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="eta"></asp:CalendarExtender>
                            </div>
                        </div>



                        <div class="FormGroupContent4">
                            <div class="MLO inputborder">
                                <span>MLO</span>
                                <asp:TextBox runat="server" ID="mlo" CssClass="form-control inputcolor" TabIndex="30" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="FormGroupContent4">

                            <div class="Carrier inputborder">
                                <span>Carrier</span>
                                <asp:TextBox runat="server" ID="carrier" CssClass="form-control inputcolor" TabIndex="31" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label37" runat="server" Text="Contract"></asp:Label>

                            <asp:TextBox runat="server" ID="txtcontract" CssClass="form-control inputcolor" TabIndex="31" ReadOnly="true" />

                        </div>




                    </div>



                    <div class=" FormGroupContent4">
                        <%-- div1 --%>
                        

                      
                      


                        <div class="FormGroupContent4">
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MarkLeft  boxmodal">

                                <div class="MarkRight1 boxmodal">
                                </div>






                            </div>

                            <%--CommodityInput--%>
                        </div>

                        <div class="FormGroupContent4 boxmodal">
                            <div class="CustomerInput7">
                                <asp:Label ID="Label30" runat="server" Text="Customs House Agent"></asp:Label>
                                <asp:TextBox ID="txt_cha" TabIndex="22" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_cha_TextChanged" placeholder="" ToolTip="Customs House Agent"></asp:TextBox>
                            </div>
                            <div class="RemarksInput4">
                                <asp:Label ID="Label28" runat="server" Text="Remarks"></asp:Label>
                                <asp:TextBox ID="txt_remark" AutoPostBack="true" runat="server" TabIndex="23" CssClass="form-control" onkeyup="CheckTextLength(this,100);" placeholder="" ToolTip="Remarks"></asp:TextBox>
                            </div>
                            <div class="BLSignatory2 DropTop">
                                <asp:Label ID="Label29" runat="server" Text="BL Signatory"></asp:Label>
                                <asp:DropDownList ID="ddl_BLsignatory" Height="25" TabIndex="41" runat="server" Width="100%" CssClass="chzn-select" data-placeholder="BL Signatory" ToolTip="BL Signatory">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem Value="1">Authorized Signatory</asp:ListItem>
                                    <asp:ListItem Value="2">As Agent</asp:ListItem>
                                    <%--  <asp:ListItem Value="4">As Agent for PAN Global Lines</asp:ListItem>--%>
                                    <asp:ListItem Value="3">As Carrier</asp:ListItem>
                                    <%--   <asp:ListItem Value="5">As Carrier for PAN Global Lines</asp:ListItem>    --%>
                                </asp:DropDownList>
                            </div>


                        </div>


                        <!--<div class="bordertopNew"></div>-->



                    </div>

                </div>
            </div>
        
    </div>


    <%-- PopUP --%>

    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="close1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="Grd_Job" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" OnRowDataBound="Grd_Job_RowDataBound"
                    AllowPaging="false" PageSize="20" OnPageIndexChanging="Grd_Job_PageIndexChanging"
                    ForeColor="Black" EmptyDataText="No Record Found" OnSelectedIndexChanged="Grd_Job_SelectedIndexChanged"
                    BackColor="White">
                    <Columns>

                        <asp:BoundField DataField="jobno" HeaderText="Job#">
                            <HeaderStyle Width="54px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="JobType" HeaderText="JobType">
                            <HeaderStyle Width="63px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="65px" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Vessel">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:BoundField DataField="voyage" HeaderText="Voyage">
                            <HeaderStyle Wrap="false" Width="85px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="95px" />
                        </asp:BoundField>

                        <%-- <asp:BoundField DataField="sd" HeaderText="POD">
                <HeaderStyle Width ="98px"/>
                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width ="75px"/>                 
                </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="POD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="sd" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="70px"></ItemStyle>
                        </asp:TemplateField>

                        <%-- <asp:BoundField DataField="mblno" HeaderText="MBL#" >
                  <HeaderStyle Width ="115px"/>
                  <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width ="50px"/>                    
                    </asp:BoundField>--%>

                        <asp:TemplateField HeaderText="MBL#">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="115px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="115px"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MLO">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="150px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="150px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="etd" HeaderText="ETD">
                            <HeaderStyle Width="75px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="75px" />

                        </asp:BoundField>
                        <asp:BoundField DataField="eta" HeaderText="ETA">
                            <HeaderStyle Width="75px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="75px" />

                        </asp:BoundField>

                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False" />
                </asp:GridView>

                <div class="div_Break"></div>

            </asp:Panel>
        </div>
    </asp:Panel>

    <%-- POPUP Booking--%>

    <asp:Panel ID="pln_popup1" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <%-- <div>--%>
        <div class="DivSecPanel">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>

        <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">
            <asp:GridView ID="Grd_Booking" runat="server" Width="100%" OnRowDataBound="Grd_Booking_RowDataBound"
                AllowPaging="false" PageSize="20" OnPageIndexChanging="Grd_Booking_PageIndexChanging"
                ForeColor="Black" EmptyDataText="No Record Found" CssClass="Grid FixedHeader"
                BackColor="White" OnSelectedIndexChanged="Grd_Booking_SelectedIndexChanged">
                <%--<Columns>--%>
                <%--<asp:BoundField DataField="BookingNo" HeaderText="Booking#">
                                    <HeaderStyle Width="133px" />
                                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="120px" />

                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                            <asp:Label ID="CustomerName" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false" Width="158px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="POL">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false" Width="170px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="POD">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="POD" runat="server" Text='<%# Bind("POD") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false" Width="170px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bookingdate">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="bookingdate" runat="server" Text='<%# Bind("bookingdate") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false" Width="162px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="fstatus" runat="server" Text='<%# Bind("fstatus") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false" Width="165px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>--%>

                <%--  </Columns>--%>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>

            <div class="div_Break"></div>

        </asp:Panel>

        <div class="div_Break"></div>

        <%--<asp:Panel ID="Panelreuse" runat="server"  Visible="false" CssClass="Gridpnl">  
   <asp:GridView ID="GrdReuse" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GrdReuse_RowDataBound"
       AllowPaging="false" PageSize="20" OnPageIndexChanging="GrdReuse_PageIndexChanging"
                ForeColor="Black" EmptyDataText="No Record Found"   DataKeyNames="shipperid,bookno" CssClass="Grid FixedHeader" 
                BackColor="White" OnSelectedIndexChanged="GrdReuse_SelectedIndexChanged">       
         <Columns>
                    <asp:BoundField DataField="BookingNo" HeaderText="Booking#">                    
                         <HeaderStyle Width ="133px"/>
                      <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width ="120px"/>
                      
                    </asp:BoundField>
                      <asp:TemplateField HeaderText ="Customer">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:150px">
                       <asp:Label ID="CustomerName" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="158px"  HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" Width="120px" ></ItemStyle>                      
                    </asp:TemplateField>                                      
                    <asp:TemplateField HeaderText ="POL">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="170px"  HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>                      
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText ="POD">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="POD" runat="server" Text='<%# Bind("POD") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="170px"  HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText ="Bookingdate">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="bookingdate" runat="server" Text='<%# Bind("bookingdate") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="162px"  HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText ="Status">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="fstatus" runat="server" Text='<%# Bind("fstatus") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="165px"  HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                    </asp:TemplateField>
                   
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>

       <div class="div_Break"></div>          

     </asp:Panel>--%>
        <%-- </div>--%>
    </asp:Panel>

    <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
        TargetControlID="hid" CancelControlID="close1" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:Label ID="hid" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="popup_Grd1" runat="server" PopupControlID="pln_popup1"
        TargetControlID="Label2" CancelControlID="Image1" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label2" runat="server"></asp:Label>

    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hid_shipperid" runat="server" />
    <asp:HiddenField ID="hid_consigneeid" runat="server" />
    <asp:HiddenField ID="hid_notifyid" runat="server" />
    <asp:HiddenField ID="hid_agentid" runat="server" />
    <asp:HiddenField ID="hid_receiptid" runat="server" />
    <asp:HiddenField ID="hid_loadingid" runat="server" />
    <asp:HiddenField ID="hid_dischargeid" runat="server" />
    <asp:HiddenField ID="hid_destinationid" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_quto" runat="server" />
    <asp:HiddenField ID="hid_intcustomerid" runat="server" />
    <asp:HiddenField ID="hid_vesselid" runat="server" />
    <asp:HiddenField ID="hid_issued" runat="server" />
    <asp:HiddenField ID="hid_cargoid" runat="server" />
    <asp:HiddenField ID="hid_chaid" runat="server" />
    <asp:HiddenField ID="hid_WojBLno" runat="server" />
    <asp:HiddenField ID="hid_cbm" runat="server" />
    <asp:HiddenField ID="hid_branchid" runat="server" />
    <asp:HiddenField ID="hid_job" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="hid_blprint" runat="server" />
    <asp:HiddenField ID="hid_jobtype" runat="server" Value="0" />
    <asp:HiddenField ID="hid_salesid" runat="server" Value="0" />

    <asp:Panel runat="server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Country of PoD/FD Agent doesnt match with Country of Agent Do you wish to Proceed ?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="PopUpService" runat="server"
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>BL # :</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
    <asp:Label ID="Label4" runat="server"></asp:Label>
    <div class="DesiCalN4new" style="display: none;">
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Stuffed On" ToolTip="Stuffed On" CssClass="form-control date"></asp:TextBox>
    </div>
    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image2" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:CalendarExtender ID="CalendarExtender8" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="TextBox1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:Panel ID="pnl_emp" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <asp:Panel ID="pnl_emp1" runat="server" CssClass="">
                <iframe id="iframecost" runat="server" frameborder="0"></iframe>
            </asp:Panel>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="pop_up" runat="server" PopupControlID="pnl_emp" DropShadow="false"
        TargetControlID="Label38" CancelControlID="Close_voucher" BehaviorID="Test2">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label38" runat="server"></asp:Label>
    <div class="div_Break"></div>
    <asp:HiddenField ID="hid_reuse" runat="server" />

    <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    <asp:HiddenField ID="hid_intagent" runat="server" />
    <asp:HiddenField ID="hid_douvolume" runat="server" />
    <asp:HiddenField ID="hid_fd" runat="server" />

    <asp:HiddenField ID="HIDMAWBLNO" runat="server" />
    <asp:HiddenField ID="hid_buyingno" runat="server" />
    <asp:HiddenField ID="hid_intcustomeropsid" runat="server" />
    <asp:HiddenField ID="hid_SupplyTo1" runat="server" />
</asp:Content>
