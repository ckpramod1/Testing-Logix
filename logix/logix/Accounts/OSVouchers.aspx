<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="OSVouchers.aspx.cs" Inherits="logix.Accounts.OSVouchers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/Invoice.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <style type="text/css">
        div#logix_CPH_Panel1 {
            height: 100%;
        }

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

        .TotalInputosdn {
            float: right;
            margin: 0px 0px 0px 0px;
            width: 100px;
        }

        .VendorRefInput1 {
            width: 18.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        select#logix_CPH_lstagnst {
            height: 44px !important;
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }

        .TextField .inputcolor, .TextField .inputcolor:focus {
            /* -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important; */
            -webkit-box-shadow: 0 0 0 30px #f4f4f4cc inset !important;
        }

        .VendorRefInput2 {
            width: 16.2%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .REFInputN12 {
            width: 5.9%;
            float: left;
            margin: 0px 0.5% 0px 0%;
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

        .Grid4.MB05 {
            height: 132px !important;
            overflow: auto;
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

        logix_CPH_PanelLog {
            top: 170px !important;
        }

        .PrepareValue span {
            font-family: sans-serif;
        }

        .ApprovedValue span {
            font-size: 11px;
            font-family: sans-serif;
        }

        . span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 268px !important;
            overflow: auto;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .RefCal {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0%;
        }
.lst_cont {
    width: 100%;
    margin: 0px 4px 0px 0px;
    float: left;
    height: 44px !important;
}

        .lst_vol select {
            height: 288px !important;
        }

        .lst_vol {
            width: 49%;
            float: left;
            height: 100%;
        }

        .lst_vol2 {
            width: 100%;
            float: left;
            height: 100%;
            margin-top: 3px;
        }

        .color {
            color: red;
        }

        /*.lst_vol select {
    height: 172px!important;
}*/
        .BillType {
            width: 14.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRefN {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BLNo2 {
            width: 14.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .InvoiceProduct {
            width: 12.8%;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }

        .MBLchk {
            width: 6.5%;
            float: left;
            margin: 17px 0.5% 0px 0px;
            max-width: 10%;
        }

        span#logix_CPH_Label23 {
            float: right;
            width: 3%;
            margin: 3px 0px 0px 0px;
        }

        .bordertopNew {
            float: left;
            min-height: 1px;
            margin: 5px 0px 0px 0px;
            border-top: 1px solid #807f7f;
            width: 100%;
        }

        span#logix_CPH_lbl_against {
            color: red !important;
        }

        .Grid {
            width: 100%;
            border: 0px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        select#logix_CPH_lstvol {
            padding-top: 21px !important;
            margin-top: 8px !important;
            height: 154px !important;
                background: #f4f4f4cc;
        }

        .widget-content {
            padding: 0 10px !important;
        }

        .DateCal1 {
            width: 7%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .JobDetailsInput {
            margin-right: 0.5% !important;
        }

        .PreparedTxt {
            width: 45%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
        }

        .ApprovedByTxt {
            width: 45%;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
            float: left;
        }

        .PrepareValue {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
        }

        .ApprovedValue {
            width: 25%;
            float: left;
            margin: -9px 0px 0px 4px;
            font-size: 13px;
            font-family: sans-serif;
            white-space: nowrap;
        }


        .JobDetails {
            width: 33%;
        }

        .pol_pod {
            width: 24%;
        }

        .Shipper {
            width: 34%;
        }

        .Consignee {
            width: 34.5%;
        }

        .Notify_Party {
            width: 30.5%;
            margin: 0 !important;
        }

        .Agent {
            width: 34%;
        }

        .Air_Line {
            width: 34.5%;
            margin-right: 0.5%;
        }

        .CHA {
            width: 30.5%;
            margin: 0 !important;
        }

        .BLLeft {
            width: 72%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BLRight {
            width: 27.5%;
            float: left;
        }



        textarea#logix_CPH_txtaddress,
        textarea#logix_CPH_txtsupplytoAddress {
            height: 98px !important;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            height: 87vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .BillType1 {
            width: 8%;
            float: right;
            margin: 0px 0.5% 0px 0.5%;
        }

        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 65px !important;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            height: 87vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        table#logix_CPH_grd tbody th:nth-child(1) {
            width: 75px !important;
        }

        select#logix_CPH_lstcon {
                background: #f4f4f4cc !important;
              padding-top: 16px !important;
    height: 44px !important;
        }

        .modalPopupss iframe {
            height: 90vh !important;
        }

        div#logix_CPH_ddl_voutype_chzn {
            width: 100% !important;
        }

        table#logix_CPH_grd th:nth-child(1) {
            width: 20px !important;
        }

        table#logix_CPH_grd td:nth-child(3) {
            width: 14px !important;
        }

        table#logix_CPH_grd th:nth-child(3) {
            width: 14px !important;
        }

        table#logix_CPH_grd th:nth-child(9) {
            width: 150px !important;
        }

        table#logix_CPH_grd th:nth-child(7) {
            width: 150px !important;
        }

        .BLRight .FormGroupContent4 {
            -webkit-box-shadow: 0 0 0 30px #f4f4f4cc inset !important;
        }

        .spancolor span {
            -webkit-box-shadow: 0 0 0 30px #f4f4f4cc inset !important;
        }

        div#logix_CPH_cmbbill_chzn a {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }
    </style>
    <%--<link href="../Styles/ProfomaInvoice.css" rel="stylesheet"  type="text/css" />--%>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtblno.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Invoice.aspx/GetBlNo",
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
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=txtblno.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);

                    },
                    close: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);

                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            //------------To Customer----------------------------------
            $(document).ready(function () {
                $("#<%=txtto.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Invoice.aspx/GetToCust",
                            data: "{ 'prefix': '" + request.term + "'}",
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
                        $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtto.ClientID %>").val(i.item.address);
                        $("#<%=HdnCustid.ClientID %>").val(i.item.val);
                        $("#<%=txtto.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtto.ClientID %>").val(i.item.address);
                        $("#<%=HdnCustid.ClientID %>").val(i.item.val);
                        $("#<%=txtto.ClientID %>").val($.trim(result));
                        $("#<%=txtto.ClientID %>").change();

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txtto.ClientID %>").val(i.item.address);
                            $("#<%=HdnCustid.ClientID %>").val(i.item.val);
                            $("#<%=txtto.ClientID %>").change();
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });

        }

        function getConfirmationValue() {

            if (confirm(' Are you sure you want to delete the details?')) {
                $('#<%=HdnConfim.ClientID%>').val('true')
            }
            else {
                $('#<%=HdnConfim.ClientID%>').val('false')
            }

            return true;
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:Panel ID="Panel1" runat="server">

        <!-- /Breadcrumbs line -->
        <div>
            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server" id="div_iframe">

                    <div class="widget-header">
                        <div>
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_InvHeader" runat="server" Text=""></asp:Label></h4>
                            <!-- Breadcrumbs line -->
                            <div class="crumbs">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li id="homelbl" runat="server" visible="false"><a href="#"></a>Documentation</li>
                                    <li><a href="#" title="" id="lblHead" runat="server"></a></li>
                                    <li><a href="#" title="" id="lblAcc" runat="server">Accounts </a></li>
                                    <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Invoice</a> </li>
                                    <li>
                                        <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                                </ul>
                            </div>
                        </div>

                        <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
                            </div>
                        <div class="FixedButtons">
    <div class="right_btn">
        <div class="btn ico-upload">
            <asp:Button ID="btn_uploadpopup" runat="server" AutoPostBack="true" ToolTip="Upload" TabIndex="16" OnClick="btn_uploadpopup_Click" />
        </div>
        <div class="btn ico-view">
            <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" />
        </div>
        <div class="btn ico-cancel" id="btncancel1" runat="server">
            <asp:Button ID="btncancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
        </div>

    </div>
</div>

                    </div>
                    <div class="widget-content">
                        
                        <div class="FormGroupContent4" style="display: flex; justify-content: flex-end;">
                            <div class="BillType1 blueheighlight">
                                <asp:Label ID="Labell" runat="server" Text="Voucher Type"></asp:Label>
                                <asp:DropDownList ID="ddl_voutype" ToolTip="Voucher Type" runat="server" AutoPostBack="True" CssClass="chzn-select" Width="100%" data-placeholder="Voucher Type" TabIndex="3" OnSelectedIndexChanged="ddl_voutype_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="5" Text="OSSI"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="OSPI"></asp:ListItem>



                                </asp:DropDownList>
                            </div>
                            <div class="RefCal">
                                <asp:Label ID="Label2" runat="server" Text="Year"></asp:Label>
                                <asp:TextBox ID="txtvouyear" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtvouyear_TextChanged" placeholder="VOU YEAR" ToolTip="VOU YEAR"></asp:TextBox>
                            </div>
                            <div class="REFInputN12">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtinv" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumberKey(event,'Inv#');" OnTextChanged="txtinv_TextChanged"></asp:TextBox>
                            </div>

                            <div class="DateCal1 DateR">
                                <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" ToolTip="Date"></asp:TextBox><ajaxtoolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" TargetControlID="txtdate" runat="server" />
                            </div>

                        </div>
                        <div class="bordertopNew" style="float: right; min-height: 1px; width: 27.5%; box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;"></div>
                        <div class="BLLeft">
                            <div class="FormGroupContent4 custom-d-flex">

                                <div class="custom-col custom-mr-05 ">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label8" runat="server" Text="Bill To"></asp:Label>
                                        <asp:TextBox ID="txtto" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtto_TextChanged" placeholder="" ToolTip="Bill To" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label10" runat="server" Text="Bill To Address"></asp:Label>
                                        <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" AutoPostBack="True" Rows="2" Columns="20" Style="resize: none;" TextMode="MultiLine" placeholder="" ToolTip="Address" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="custom-col ">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label9" runat="server" Text="Supply To"></asp:Label>
                                        <asp:TextBox ID="txtsupplyto" runat="server" ToolTip="Supply To" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="7" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label11" runat="server" Text="Supply To Address"></asp:Label>
                                        <asp:TextBox ID="txtsupplytoAddress" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>





                            <div class="FormGroupContent4">
                                <asp:Label ID="Label20" runat="server" Text="Remarks"></asp:Label>
                                <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="5" Width="100%" onKeyUp="CheckTextLength(this,150)" placeholder="" ToolTip="Remarks"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="pnlCharge" runat="server" CssClass="gridpnl" ScrollBars="Auto">
                                    <asp:GridView ID="grd" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                        CssClass="Grid FixedHeader" OnPreRender="grd_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="blno" HeaderText="BL/MBL #">
                                                <HeaderStyle Width="380" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="charge" HeaderText="Charges">
                                                <ControlStyle />
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="curr" HeaderText="Curr">
                                                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bASe" HeaderText="UoM">
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                <ItemStyle HorizontalAlign="right" Width="100px" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="chargeid" HeaderText="chargeid">
            <HeaderStyle CssClass="hide" Width="55px"/>
            <ItemStyle CssClass="hide" />
            </asp:BoundField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                    </asp:GridView>
                                    <div class="div_Break"></div>
                                </asp:Panel>

                                <div class="FormGroupContent4" style="display: flex; justify-content: space-between;">


                                    <asp:Label ID="Label23" runat="server" Text="" CssClass="hide"></asp:Label>
                                    <div class="FormGroupContent4">

                                        <div class="TotalInputosdn">
                                            <span>Total</span>
                                            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="1" placeholder="" ToolTip="Total"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="BLRight">
                            <div class="FormGroupContent4">
                                <div class="spancolor">
                                    <asp:Panel ID="Panel3" runat="server" CssClass="TextArea">
                                        <span>Against Ref #</span>
                                        <asp:ListBox ID="lstagnst" runat="server" Width="99.7%" Height="63px"></asp:ListBox>
                                    </asp:Panel>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div id="lbl_txt" runat="server" visible="false">
                                    <div class="FormGroupContent4">

                                        <div class="ApprovedValue" style="margin: 6px 0px 0px 7px;">
                                            <span style="color: #06529c!important">PREPARED BY</span>
                                            <asp:Label ID="lbl_prepare" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="ApprovedValue" runat="server" visible="false" id="lbl_appr" style="margin: 6px 0px 0px 7px;">
                                            <span style="color: #06529c!important">APPROVED BY</span>
                                            <asp:Label ID="lbl_Approve" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>




                                    <div style="float: left; margin: 1px 1px 1px 1px; color: red; font-size: 12px;">
                                        <asp:Label ID="lbl_against" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>


                            <div class="FormGroupContent4 spancolor">
                                <asp:Label ID="Label6" runat="server" Text="Bill Type"></asp:Label>
                                <asp:DropDownList ID="cmbbill" runat="server" AutoPostBack="True" Enabled="false" Width="100%" CssClass="chzn-select inputcolor" OnSelectedIndexChanged="cmbbill_SelectedIndexChanged" ToolTip="Bill Type" data-placeholder="Bill Type" ReadOnly="true">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="FormGroupContent4  custom-d-flex spancolor">
                                <div class="custom-col custom-mr-1" style="float: left">
                                    <asp:Label ID="Label24" runat="server" Text="Product"></asp:Label>
                                    <asp:TextBox ID="txt_trantype" runat="server" ReadOnly="True" placeholder="" CssClass="form-control inputcolor" ToolTip="Product"></asp:TextBox>
                                </div>
                                <div class="custom-col custom-mr-05 spancolor" style="float: left">
                                    <asp:Label ID="Label12" runat="server" Text="Job #"></asp:Label>
                                    <asp:TextBox ID="txtvessel" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Job Details"></asp:TextBox>
                                </div>
                            </div>

                            <div class=" FormGroupContent4 custom-d-flex  spancolor">
                                <div class="custom-col custom-mr-10" style="float: left">
                                    <asp:Label ID="Label25" runat="server" Text="Vessel"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" OnTextChanged="txtblno_TextChanged" placeholder="" ToolTip="Vessel" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="custom-col custom-mr-10 spancolor" style="float: left">
                                    <asp:Label ID="Label5" runat="server" Text="BL #"></asp:Label>
                                    <asp:TextBox ID="txtblno" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" OnTextChanged="txtblno_TextChanged" placeholder="" ToolTip="Bill of Lading Number" ReadOnly="true"></asp:TextBox>
                                </div>


                                <div class="custom-w-20 custom-mt-2 hide" style="margin-top: 15px !important;">
                                    <span class="chktext">MB/L </span>
                                    <center>
                                        <label class="switch">
                                            <asp:CheckBox ID="chkmbl" runat="server" AutoPostBack="true" OnCheckedChanged="chkmbl_CheckedChanged" />
                                            <%-- <span class="slider round"></span>--%>
                                        </label>
                                    </center>

                                </div>
                            </div>

                            <div class="FormGroupContent4 custom-d-flex ">
                                <div class="custom-col custom-mr-05 spancolor" style="float: left">
                                    <asp:Label ID="Label14" runat="server" Text="Shipper"></asp:Label>
                                    <asp:TextBox ID="txtshipper" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Shipper"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 custom-d-flex">

                                <div class=" custom-col custom-mr-05 spancolor" style="float: left">
                                    <asp:Label ID="Label16" runat="server" Text="Consignee"></asp:Label>
                                    <asp:TextBox ID="txtconsignee" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Consignee"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 custom-d-flex">

                                <div class="custom-col custom-mr-05 spancolor" style="float: left">
                                    <asp:Label ID="Label18" runat="server" Text="Notify Party"></asp:Label>
                                    <asp:TextBox ID="txtnotify" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Notify Party"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 custom-d-flex">

                                <div class="custom-col spancolor" style="float: left">
                                    <asp:Label ID="Label15" runat="server" Text="Agent"></asp:Label>
                                    <asp:TextBox ID="txtagent" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Agent"></asp:TextBox>
                                </div>
                            </div>

                            <div class="FormGroupContent4 custom-d-flex">


                                <div class="custom-col spancolor">
                                    <asp:Label ID="Label17" runat="server" Text="MLO / Air Line"></asp:Label>
                                    <asp:TextBox ID="txtmlo" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Main Line Operator"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent4 custom-d-flex">


                                <div class="custom-col spancolor ">
                                    <asp:Label ID="Label19" runat="server" Text="CHA"></asp:Label>
                                    <asp:TextBox ID="txtcnf" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Customs House Agent"></asp:TextBox>
                                </div>
                            </div>




                            <div class="FormGroupContent4 custom-d-flex hide">

                                <div class="custom-col spancolor" id="txtcreditapp1" runat="server" style="float: left">
                                    <asp:Label ID="Label7" runat="server" Text="CreditApproval #"></asp:Label>
                                    <asp:TextBox ID="txtcreditapp" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" placeholder="" ToolTip="CreditApproval #" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 custom-d-flex">
                                <div class="custom-col custom-mr-1 spancolor" style="float: left">
                                    <asp:Label ID="Label21" runat="server" Text="Vendor Ref #"></asp:Label>
                                    <asp:TextBox ID="txtVendorref" runat="server" CssClass="form-control inputcolor" Visible="false" AutoPostBack="True" onkeypress="return isNumberKey(event,'Vendor Ref#');" placeholder="" ToolTip="Vender Ref Number"></asp:TextBox>
                                </div>

                                <div class="custom-col spancolor">
                                    <asp:Label ID="Label22" runat="server" Text="Date"></asp:Label>
                                    <asp:TextBox ID="txtVendorRefnodate" runat="server" CssClass="form-control inputcolor" Visible="false" AutoPostBack="True" placeholder="" ToolTip="Vendor Ref Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <div class="Datelabel1" style="display: none;">
                                    <asp:Label ID="Label4" runat="server" Text="Date" CssClass="LabelValue"></asp:Label>
                                </div>

                            </div>
                            <div class="FormGroupContent4 custom-d-flex">

                                <div class="custom-col spancolor" style="float:left" >
                                    <asp:Label ID="Label13" runat="server" Text="PoL / PoD"></asp:Label>
                                    <asp:TextBox ID="txtdes" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="POL /POD"></asp:TextBox>
                                </div>
                                <div class="custom-col spancolor"  style="float:left">
                                  
                                    <asp:Panel ID="pnlContlist" runat="server" CssClass="lst_cont TextArea">
                                          <span>CBM</span>
    <asp:ListBox ID="lstcon" runat="server" Width="100%" Height="100%"></asp:ListBox>
</asp:Panel>
                                </div>
                            </div>
                            <div class="FormGroupContent4" style="background: #f4f4f4cc;">

                                
                           

                               
                                <asp:Panel ID="pnlVolList" runat="server" CssClass="lst_vol TextArea spancolor">
                                    <span>Container Details</span>


                                    <asp:ListBox ID="lstvol" runat="server" Width="100%" Height="66px"></asp:ListBox>
                                </asp:Panel>

                            </div> 
                        </div>





                        <div class="FormGroupContent4 hide">
                            <span class="orangetext">Financial Entry</span>
                        </div>
                        <div class="FormGroupContent4 boxmodal hide">
                            <div class="panel_04">
                                <asp:GridView ID="GrdFA" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GrdFA_RowDataBound" DataKeyNames="LedgerType" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="GrdFA_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="ledgername" HeaderText="Particulars " HeaderStyle-CssClass="text-center">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ledgeramount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="right" Width="150px" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ledgeramount" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="right" Width="150px" />
                                            <ItemStyle Width="150px" />

                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                        </div>

                        <div class="FormGroupContent4">

                            <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                <div class="divRoated">
                                    <div class="LogHeadLbl">
                                        <div class="LogHeadJob">
                                            <label id="lbl_no" runat="server"></label>

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
        </div>

    </asp:Panel>

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test3">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel runat="Server" ID="popup_upload" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image2" runat="server" ImageUrl="../Theme/assets/img/buttonIcon/active/close-sm.png" Width="20px" />
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
        CancelControlID="Image2">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="lbl1" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:HiddenField ID="hf_updoc" runat="server" />
    <asp:HiddenField ID="hdnblno" runat="server" />
    <asp:HiddenField ID="HdnJobNo" runat="server" />
    <asp:HiddenField ID="Hdnteta" runat="server" />
    <asp:HiddenField ID="HdnCreditAmt" runat="server" />
    <asp:HiddenField ID="HdnOSAmt" runat="server" />
    <asp:HiddenField ID="HdnCustid" runat="server" />
    <asp:HiddenField ID="HdnConfim" runat="server" />
    <asp:HiddenField ID="hid_approvedby" runat="server" />
    <asp:HiddenField ID="Hid_HeadTrantype" runat="server" />
    <asp:HiddenField ID="hid_Trantype" runat="server" />
    <asp:HiddenField ID="hf_LogBr_ID" runat="server" />
</asp:Content>
