<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="BLRelease.aspx.cs" Inherits="logix.ShipmentDetails.BLRelease" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/BLRelease.css" rel="stylesheet" />
    <script type="text/javascript">
        function pageLoad(sender, args) {
             <%-- $(document).ready(function () {
                 $("#<%=txtblno.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "BLRelease.aspx/getlikebl",
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
                         $("#<%=txtblno.ClientID %>").val(i.item.label);
                         $("#<%=txtblno.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=txtblno.ClientID %>").val(i.item.label);
                         $("#<%=hiddenid.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txtblno.ClientID %>").val(i.item.label);
                         $("#<%=hiddenid.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });--%>

            $(document).ready(function () {

                $("#<%=txtblno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "BLRelease.aspx/getlikebl",
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
                        $("#<%=txtblno.ClientID %>").val(i.item.label);
                        $("#<%=txtblno.ClientID %>").change();
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.value);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.value);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.value);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
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
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }

        .chzn-drop {
            top: -134px !important;
            height: 130px !important;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }



        .BillDate {
            width: 18%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
    </style>

    <style type="text/css">
        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -0.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 87%;
            Height: 469px;
            margin-left: 0.5%;
            margin-top: 1.1%;
            overflow: hidden;
        }

        .BackView {
            float: right;
            margin: 3px 9.8% 0px 0px;
            width: 8.5%;
            font-size: small;
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

            .OutStandingLbl2 span {
                font-size: 11px;
                color: brown;
                font-family: sans-serif;
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





        span#logix_CPH_Label3 {
            color: maroon;
            font-weight: bold;
        }

        span#logix_CPH_Label4 {
            color: maroon;
            font-weight: bold;
        }

        span#logix_CPH_Label5 {
            color: maroon;
            font-weight: bold;
        }

        span#logix_CPH_Label6 {
            color: maroon;
            font-weight: bold;
        }

        .chzn-search span {
            display: none;
        }

        .BillOfInput {
            width: 28.4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }



        .ShipperInput5 {
            float: left;
            width: 44.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipperInput5 {
            margin-right: 0.5% !important;
        }

            .ShipperInput5.TextField {
                width: 100%;
            }

        .Consignee5 {
            width: 44%;
            margin: 0px 0px 0px 0px;
            float: left;
        }

        .ConsigneeInput {
            width: 44%;
            float: left;
            margin: 0px;
        }

        .PackagesInputV1 {
            width: 49.5%;
            float: left;
        }

        .GrossWeigh {
            width: 22.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GrossWeigh1 {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GrossWeigh2 {
            width: 49.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .GrossWeigh3 {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Containers_Details {
            /*height: 91px;*/
            width: 83%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

            .Containers_Details textarea {
                height: 82.2px !important;
            }

        .GWKgs {
            float: left;
            width: 22%;
            margin: 0px 0.5% 0px 0px;
        }

        .Nwt {
            float: left;
            width: 22%;
            margin: 0px 0.5% 0px 0px;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            height: 92vh;
            overflow-x: hidden;
            overflow-y: hidden;
        }

        .CBM {
            float: left;
            width: 21%;
            margin: 0px 0.5% 0px 0px;
        }

        .Packages {
            float: left;
            width: 16.5%;
            margin: 0px 0 0px 0px;
        }

        .BillDrop {
            width: 83%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MTD {
            width: 22.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .divleft {
            width: 44.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .divright {
            width: 52.9%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        img#logix_CPH_porflag {
            width: 25px !important;
            height: auto;
            position: relative;
            left: -124%;
            top: 65px;
            z-index: 9999;
        }

        img#logix_CPH_flagimg {
            z-index: 9999;
            width: 25px !important;
            height: auto;
            position: relative;
            left: 9%;
            top: 65px;
        }

        img#logix_CPH_podflag {
            width: 25px !important;
            height: auto;
            position: relative;
            left: -150%;
            top: 116px;
            z-index: 9999;
        }

        img#logix_CPH_fdflag {
            width: 25px !important;
            height: auto;
            position: relative;
            left: -17%;
            top: 115px;
            z-index: 9999;
        }


        /*New Design - Buttons*/

        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 45px !important;
        }

        textarea#logix_CPH_txtContainer {
            height: 98px !important;
        }

        .FixedButtonsss {
            position: fixed;
            top: 35px !important;
            left: 0;
            background: #fff;
            z-index: 10;
            box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
            width: calc(100vw - 710px) !important;
            border-bottom: 0.5px solid #00000010;
            padding: 1px 0 5px 10px;
        }

        .widget.box .widget-header {
            position: fixed;
            width: 100%;
            background: #fff;
            border-bottom-color: var(--inputborder);
            height: 36px !important;
            /* line-height: 11px !important; */
            /* padding: 13px 5px 0 0 !important; */
            /* margin-bottom: 0; */
            position: fixed;
            /* margin: -2px 0px 0px 0px; */
            top: -1px;
            width: 44.5%;
            z-index: 10;
            border-bottom: 1px solid #ececec;
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
                            <asp:Label ID="lbl_Header" runat="server" Text="BL Release"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Documentation</a> </li>
                                <li><a href="#" title="">Ocean Exports</a> </li>
                                <li class="current"><a href="#" title="">BL Release</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons">
    <div class="right_btn">
        <div id="btnseavis" runat="server" class="btn ico-BL-release">
            <asp:Button ID="btnsea" runat="server" Text="SeaWayBill" ToolTip="SeaWayBill" TabIndex="25" OnClick="btnsea_Click" />
        </div>
        <div class="btn ico-BL-nn">
            <asp:Button ID="btnnon" runat="server" Text="Non Negotiable" ToolTip="Non Negotiable" TabIndex="20" OnClick="btnnon_Click" />
        </div>
        <div class="btn ico-BL-draft">
            <asp:Button ID="btnDraft" runat="server" Text="Draft" ToolTip="Draft" TabIndex="21" OnClick="btnDraft_Click" />
        </div>
        <div id="btnorgl" runat="server" class="btn ico-BL-release">
            <asp:Button ID="btnOriginal" runat="server" Text="Original" ToolTip="Original" TabIndex="22" OnClick="btnOriginal_Click" />
        </div>
        <div id="btnsur" runat="server" class="btn ico-BL-release">
            <asp:Button ID="btnsurrenderbl" runat="server" Text="Surrender BL" ToolTip="Original" TabIndex="22" OnClick="btnsurrenderbl_Click" />
        </div>
        <div class="btn ico-cancel" id="btnCancel1" runat="server">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" TabIndex="23" OnClick="btnCancel_Click" />
        </div>
    </div>
</div>

                </div>
                <div class="widget-content">
                    


                    <div class="FormGroupContent4 boxmodal">
                        <div class="divleft">


                            <div class="FormGroupContent4">
                                <div class="FormGroupContent4 boxmodal">
                                    <div class="BillOfInput">
                                        <asp:Label ID="Label2" runat="server" Text="BL #"></asp:Label>
                                        <asp:TextBox ID="txtblno" runat="server" placeholder="" ToolTip="Bill of Lading Number" TabIndex="1" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtblno_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="BillDate">
                                        <asp:Label ID="Label1" runat="server" Text="BL Date"></asp:Label>
                                        <asp:TextBox ID="txtbldate" TabIndex="2" ReadOnly="true" placeholder="" ToolTip="BL Date" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="BillDate">
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label23" runat="server" Text="SOB Date"></asp:Label>

                                            <asp:TextBox ID="txtsob" TabIndex="2" placeholder="" ToolTip="Shipper On Board Date" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" TargetControlID="txtsob" runat="server" />
                                        </div>




                                    </div>

                                    <div class="img custom-d-flex">
                                        <asp:Image ID="porflag" runat="server" Width="100%" />
                                        <asp:Image ID="flagimg" runat="server" Width="100%" />
                                        <asp:Image ID="podflag" runat="server" Width="100%" />
                                        <asp:Image ID="fdflag" runat="server" Width="100%" />




                                    </div>


                                    <div class="BackView">
                                        <asp:LinkButton ID="lnk_Creditdet" runat="server" OnClick="lnk_Creditdet_Click" Visible="false">OutStanding</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="FormGroupContent4" id="divs" runat="server">

                                    <div class="ShipperInput5">
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label3" runat="server" Text="Shipper"></asp:Label>
                                            <asp:TextBox ID="txtshipper" TabIndex="3" ReadOnly="true" placeholder="" ToolTip="Shipper" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label18" runat="server" Text="Shipper Address"></asp:Label>
                                            <asp:TextBox ID="txtsaddress" runat="server" ReadOnly="true" placeholder="" ToolTip="Shipper Address" Width="100%" CssClass="form-control" Style="resize: none;" Rows="3" TextMode="MultiLine" OnTextChanged="txtsaddress_TextChanged"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="Consignee5 Hide">

                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label4" runat="server" Text="Consignee"></asp:Label>
                                            <asp:TextBox ID="txtconsignee" TabIndex="4" ReadOnly="true" placeholder="" ToolTip="Consignee" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label19" runat="server" Text="Consignee Address"></asp:Label>
                                            <asp:TextBox ID="txtcaddress" runat="server" ReadOnly="true" placeholder="" ToolTip="Consignee Address " Width="100%" CssClass="form-control" Style="resize: none;" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="FormGroupContent4 boxmodal hide">
                                    <div class="ShipperInput5">
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label5" runat="server" Text="Notify Party"></asp:Label>
                                            <asp:TextBox ID="txtnotify" TabIndex="5" ReadOnly="true" placeholder=" " ToolTip="Notify Party" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label20" runat="server" Text="Notify Party Address"></asp:Label>
                                            <asp:TextBox ID="txtnaddress" runat="server" ReadOnly="true" placeholder="" ToolTip="Notify Party Address" CssClass="form-control" Width="100%" Style="resize: none;" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="ConsigneeInput">
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label6" runat="server" Text="Agent"></asp:Label>
                                            <asp:TextBox ID="txtagent" TabIndex="6" ReadOnly="true" placeholder="" ToolTip="Agent" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label21" runat="server" Text="Agent Address"></asp:Label>
                                            <asp:TextBox ID="txtaaddress" runat="server" ReadOnly="true" placeholder="" ToolTip="Agent Address" CssClass="form-control" Width="100%" Style="resize: none;" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="FormGroupContent4 boxmodal">
                                        <div class="GrossWeigh1">
                                            <div class="FormGroupContent4">
                                                <asp:Label ID="Label7" runat="server" Text="Place of Receipt"></asp:Label>
                                                <asp:TextBox ID="txtreceipt" runat="server" TabIndex="7" placeholder="" ToolTip="Place of Receipt" CssClass="form-control" Width="100%"></asp:TextBox>

                                            </div>


                                        </div>
                                        <div class="GrossWeigh2">
                                            <div class="FormGroupContent4">
                                                <asp:Label ID="Label8" runat="server" Text="Port of Loading"></asp:Label>
                                                <asp:TextBox ID="txtpol" runat="server" TabIndex="8" placeholder="" ToolTip="Port of Loading" CssClass="form-control" Width="100%"></asp:TextBox>

                                            </div>


                                        </div>

                                    </div>

                                </div>

                                <div class="FormGroupContent4">
                                    <div class="GrossWeigh3">
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label9" runat="server" Text="Port of Discharge"></asp:Label>
                                            <asp:TextBox ID="txtpodis" runat="server" TabIndex="9" placeholder="" ToolTip="Port of Discharge" CssClass="form-control"></asp:TextBox>

                                        </div>


                                    </div>
                                    <div class="PackagesInputV1">
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label10" runat="server" Text="Place of Delivery"></asp:Label>
                                            <asp:TextBox ID="txtfinaldes" TabIndex="10" runat="server" placeholder="" ToolTip="Place of Delivery" CssClass="form-control"></asp:TextBox>

                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal">

                                <div class="GWKgs">
                                    <asp:Label ID="Label12" runat="server" Text="G.Wt Kgs"></asp:Label>
                                    <asp:TextBox ID="txtgrossw" runat="server" CssClass="form-control" placeholder="" ToolTip="Gross Weight" TabIndex="11"></asp:TextBox>
                                </div>
                                <div class="Nwt">
                                    <asp:Label ID="Label13" runat="server" Text="N.Wt Kgs"></asp:Label>
                                    <asp:TextBox ID="txtnetw" runat="server" TabIndex="12" placeholder="" ToolTip="Net Weight" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="CBM">
                                    <asp:Label ID="Label14" runat="server" Text="CBM"></asp:Label>
                                    <asp:TextBox ID="txtcbm" TabIndex="13" runat="server" placeholder="" ToolTip="CBM" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="Packages">
                                    <asp:Label ID="Label15" runat="server" Text="Packages"></asp:Label>
                                    <asp:TextBox ID="txtpackage" runat="server" TabIndex="14" placeholder="" ToolTip="Packages" CssClass="form-control"></asp:TextBox>
                                </div>



                            </div>
                            <div class="FormGroupContent4">
                                <div class="Containers_Details">
                                    <asp:Label ID="Label24" runat="server" Text="Description/Annexure"></asp:Label>
                                    <asp:TextBox ID="txt_descannex" runat="server" placeholder="" ToolTip="Description/Annexure" TabIndex="15" Style="resize: none;" Rows="3" CssClass="form-control" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="Containers_Details ">
                                    <asp:Label ID="Label11" runat="server" Text="Containers Details"></asp:Label>
                                    <asp:TextBox ID="txtContainer" runat="server" placeholder="" ToolTip="Containers Details" TabIndex="15" Style="resize: none;" Rows="3" CssClass="form-control" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="BillDrop ">
                                    <asp:Label ID="Label16" runat="server" Text="Stationery"></asp:Label>
                                    <asp:DropDownList ID="cmbblformat" Height="30" TabIndex="16" AutoPostBack="true" data-placeholder="BL Format" ToolTip="Bill of Lading Format" runat="server" CssClass="chzn-select" OnSelectedIndexChanged="cmbblformat_SelectedIndexChanged" Width="100%">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class=" MTD  TextField hide">
                                    <asp:Label ID="Label17" runat="server" Text="Document"></asp:Label>
                                    <asp:DropDownList ID="cmbDoc" Height="30" TabIndex="16" data-placeholder="Document" ToolTip="Document" runat="server" CssClass="chzn-select" Width="100%">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>


                        <div class="divright">
                        </div>


                    </div>

                    <div class="FormGroupContent4">
                        <%--  <div class="withAgent"><asp:CheckBox ID="ChkwithAgt" TabIndex="18" runat="server" Text="With Agent" CssClass="LabelValue" /></div>
                       <div class="WithoutAgent"> <asp:CheckBox ID="ChkwithoutAgt" runat="server" TabIndex="19" Text="Without Agent" CssClass="LabelValue" /></div>--%>
                        <div class="withAgent hide">
                            <asp:RadioButton ID="ChkwithAgt" runat="server" Text="With Agent" CssClass="LabelValue" AutoPostBack="true" OnCheckedChanged="ChkwithAgt_CheckedChanged" />
                        </div>
                        <div class="WithoutAgent hide">
                            <asp:RadioButton ID="ChkwithoutAgt" runat="server" Text="Without Agent" CssClass="LabelValue" AutoPostBack="true" OnCheckedChanged="ChkwithoutAgt_CheckedChanged" />
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
        <asp:Label ID="lbllog1" runat="server"></asp:Label>

        <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
            DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
        </ajaxtoolkit:ModalPopupExtender>

        <%-- Elengo --%>
        <asp:Label ID="LblCncl" runat="server"></asp:Label>
        <asp:ModalPopupExtender ID="PopCreditdet" runat="server" TargetControlID="LblCncl"
            BehaviorID="frgtydfdfdf" PopupControlID="pnlCreditdet" CancelControlID="imgcls" DropShadow="false">
        </asp:ModalPopupExtender>

        <asp:Panel ID="pnlCreditdet" runat="server" CssClass="modalPopup" Style="display: none;">

            <div class="divRoated">
                <div class="OutStandingLbl1">
                    <h3>Out Standing</h3>
                </div>
                <div class="OutStandingLbl2">Credit Customerwise OutStanding - <span id="CustomerLbl1" runat="server"></span></div>
                <div class="DivSecPanel">
                    <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <div class=" Gridpnl">
                    <asp:GridView ID="grdCridtDet" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False"
                        OnRowDataBound="grdCridtDet_RowDataBound" OnPreRender="grdCridtDet_PreRender">
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

        <asp:Label ID="Label22" runat="server" Visible="false"></asp:Label>
        <asp:HiddenField ID="hiddenid" runat="server" />
        <asp:HiddenField ID="hid_marks" runat="server" />
        <asp:HiddenField ID="hid_desc" runat="server" />
        <asp:HiddenField ID="hid_intPODCountryId" runat="server" />
        <asp:HiddenField ID="hid_formatname" runat="server" />
        <asp:HiddenField ID="hid_CustomerId" runat="server" />
        <asp:HiddenField ID="hid_CustomerName" runat="server" />
        <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </div>
</asp:Content>
