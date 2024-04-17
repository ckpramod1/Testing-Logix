<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="profoma DN-Admin.aspx.cs" Inherits="logix.FAForm.profoma_DN_Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <%-- <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />--%>
    <!-- App -->
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('.selectpicker').selectpicker();

            "use strict";

            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins

            //$('select.styled').customSelect();

        });

    </script>

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/profoma DN-Admin.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {
                $("#<%=txt_to.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_customerid.ClientID %>").val(0);
                        var chk = "";
                        if ($("#<%=radio_customer.ClientID %>").is(':checked')) {
                            chk = 'C';
                        }
                        else if ($("#<%=radio_agent.ClientID %>").is(':checked')) {
                            chk = 'P';
                        }
                        else {
                            alertify.alert('Select Party type as Customer or Agent');
                            $("#<%=radio_customer.ClientID %>").focus();
                            return false;
                        }

                        $.ajax({
                            url: "../FAForms/profoma DN-Admin.aspx/GetCustomer_DNCN",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'" + chk + "'}",
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
                        $("#<%=txt_to.ClientID %>").val(i.item.label);
                        $("#<%=txt_to.ClientID %>").change();
                        $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_to.ClientID %>").val(i.item.label);
                        $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                    },

                    close: function (e, i) {

                        var result = $("#<%=txt_to.ClientID %>").val().toString();
                        $("#<%=txt_to.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_chrgdes.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_chargeid.ClientID %>").val(0);
                        var chk = "";
                        if ($("#<%=radio_customer.ClientID %>").is(':checked')) {
                            chk = 'C';
                        }
                        else if ($("#<%=radio_agent.ClientID %>").is(':checked')) {
                            chk = 'P';
                        }
                        else {
                            alertify.alert('Please Check Customer or Agent');
                            $("#<%=radio_customer.ClientID %>").focus();
                            return false;
                        }

                        $.ajax({
                            url: "../FAForms/profoma DN-Admin.aspx/GetCharge",
                            data: "{ 'prefix': '" + request.term + "','ChkBox':'" + chk + "'}",
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
                        $("#<%=txt_chrgdes.ClientID %>").val(i.item.label);
                        $("#<%=txt_chrgdes.ClientID %>").change();
                        $("#<%=hf_chargeid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_chrgdes.ClientID %>").val(i.item.label);
                        $("#<%=hf_chargeid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_chrgdes.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_chrgdes.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

          <%--  $(document).ready(function () {
                $("#<%=txtsupplyto.ClientID %>").autocomplete({

                      source: function (request, response) {
                          $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer_DNCN",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'T'}",
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
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtsupplyto.ClientID %>").change();
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            }); --%>

            $(document).ready(function () {
                $("#<%=txtsupplyto.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        var chk = "";
                        if ($("#<%=radio_customer.ClientID %>").is(':checked')) {
                            chk = 'C';
                        } else if ($("#<%=radio_agent.ClientID %>").is(':checked')) {
                            chk = 'P';
                        }
                        else {
                            alertify.alert('Select Party type as Customer or Agent');
                            $("#<%=radio_customer.ClientID %>").focus();
                            return false;
                        }
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer_DNCN",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'" + chk + "'}",
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
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtsupplyto.ClientID %>").change();
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_curr.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/profoma DN-Admin.aspx/GetCurrency",
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
                        $("#<%=hf_currid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var customer = $("#<%=txt_curr.ClientID %>").val().split(',')[0];
                        $("#<%=txt_curr.ClientID %>").val(customer);
                    },
                    minLength: 1
                });
            });
        }

        function Set_id() {
            document.getElementById('logix_CPH_hf_currid').value = 0;
        }

    </script>
    <link href="../Styles/ProDebitNote.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .HeightText {
            height: 51px;
        }

        .RemarksLeft {
            float: left;
            width: 78.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .RemarksRight {
            float: left;
            width: 21%;
            margin: 0px 0% 0px 0px;
        }

        .PDRemarks {
            width: 78%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PDCredit {
            width: 7%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .PDVendor {
            width: 100%;
            float: left;
            margin: 0px 0% 5px 0px;
        }

        .Grid2 {
            border: 1px solid #b1b1b1;
            height: 155px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .PDDate {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .PDYear {
    width: 8.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}
        .PDBillType {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PDToInput1 {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .txt_Sup {
            width: 50%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .Pnl {
            border: 2px solid #b1b1b1;
            width: 325px;
            text-align: center;
            height: 132px;
            font-size: 11px;
        }

        .Curr {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRefInput1 {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRefInput2 {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_pnldebit {
            position: fixed;
            z-index: 100001;
            left: 520.5px;
            top: 309px !important;
        }

        .ChargeDes {
            width: 45.1%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        div#logix_CPH_ddl_base_chzn {
    width: 100% !important;
}

        .AmountInput {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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
            white-space: nowrap;
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
                margin: 4px 0px 0px 61px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 180px !important;
        }

        .PreparedTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
        }

        .PrepareValue {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
        }

            .PrepareValue span {
                font-family: sans-serif;
            }

        .ApprovedByTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
        }

        .ApprovedValue {
            width: 15%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
        }

            .ApprovedValue span {
                font-size: 13px;
                font-family: sans-serif;
            }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        div#logix_CPH_btn_add1 {
            margin: 9px 0px 0px;
        }

        input#logix_CPH_radio_customer {
            float: left;
        }

        input#logix_CPH_radio_agent {
            float: left;
        }

        .ProDebitCustomer {
            width: 7%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

        .ProDebitAgent {
            width: 15%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

             .PDProRef {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
             .TotalInput {
    float: right;
    width: 10%;
    margin: 0px 7px 0px 0px;
}
.RateInput {
    width: 12.3%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.ExRateInput {
    width: 12.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.BaseDrop {
    width: 9%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.widget.box{
    position: relative;
    top: -8px;
}
.ProDebitCustomer label,.ProDebitAgent label {
    margin: 5px 0 0 4px;
}
.gridpnl {
    height: calc(100vh - 385px);
}
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}


    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text=""> </asp:Label>
                    </h4>
                      <!-- Breadcrumbs line -->
     <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Vouchers</a> </li>
            <li><a href="#" title="" id="lbl_head" runat="server">Proforma DN Admin </a></li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>

                <div class="widget-content">
                    <div class="FormGroupContent4 FixedButtons">
                         <div class="right_btn">
                       
                            <div class="btn ico-save" id="btn_save1" runat="server">

                                <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" />
                            </div>
                            <div class="btn ico-view">

                                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />

                            </div>
                            <div class="btn ico-delete">

                                <asp:Button ID="btn_delete" runat="server" Text="Delete" ToolTip="Delete" OnClick="btn_delete_Click" />

                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />

                            </div>

                        </div>
                    </div>
                     <div class="FormGroupContent4 boxmodal">
                         <div class=" FormGroupContent4">

                         <div class="PDRef">
                            <asp:Label ID="lbl_ref" runat="server" Text="Document / Ref #" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_blno" runat="server" ToolTip="Document / Ref #" placeholder="" CssClass="form-control" OnTextChanged="txt_blno_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                           <div class="PDBillType">
                            <asp:Label ID="lbl_bltype" runat="server" Text="Bill Type" CssClass="LabelValue"></asp:Label>

                            <asp:DropDownList ID="ddl_bltype" runat="server" Height="23" CssClass="chzn-select" ToolTip="Bill Type" placeholder="Bill Type">
                                <asp:ListItem Value="0">Bill Type</asp:ListItem>
                                <asp:ListItem Text="Cash/Cheque">Cash/Cheque</asp:ListItem>
                                <asp:ListItem Text="Credit">Credit</asp:ListItem>
                                <asp:ListItem Text="Internal">Internal</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                         <div class="ProDebitCustomer">
                            <asp:RadioButton ID="radio_customer" runat="server" Text="Customer" GroupName="A" AutoPostBack="true" />
                        </div>
                        <div class="ProDebitAgent">
                            <asp:RadioButton ID="radio_agent" runat="server" Text="Agent" GroupName="A" AutoPostBack="true" />
                        </div>   
                    <div style="display:flex;justify-content:flex-end">

                        <div class="PDProRef">
                                <asp:Label ID="lbl_proref" runat="server" Text="Pro Ref #" CssClass="LabelValue"></asp:Label>
                                <asp:TextBox ID="txt_invoice" runat="server" CssClass="form-control" ToolTip="Pro Ref #" placeholder="" OnTextChanged="txt_invoice_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>

                        <div class="PDDate DateR">
                            <asp:Label ID="Label1" runat="server" Text="Date " CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txt_date" runat="server" ToolTip="Date" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>                    

                            <div class="PDYear">
                                <asp:Label ID="Label2" runat="server" Text="Year" CssClass="LabelValue"></asp:Label>
                                <asp:TextBox ID="txt_vouyear" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>     

                    </div>
                   </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                         <div class=" FormGroupContent4">

                        <div class="PDToInput1">
                            <asp:Label ID="lbl_to" runat="server" Text="Bill From" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" ToolTip="Bill From" placeholder="" CssClass="form-control" OnTextChanged="txt_to_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div style="display: none;">
                            <asp:Label ID="lbl_date" runat="server" Text="Date" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="txt_Sup">
                            <asp:Label ID="lblsupplyto" runat="server" Text="SupplyTo" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtsupplyto" runat="server" ToolTip="SupplyTo" placeholder="" OnTextChanged="txtsupplyto_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                        </div>

                         <div class="PDRemarks">
                            <asp:Label ID="lbl_remarks" runat="server" Text="Remarks" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_remarks" ToolTip="Remarks" placeholder="" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="VendorRefInput1">
                            <asp:Label ID="lbl_vndrref" runat="server" Text="Vendor Ref #" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_vndrref" runat="server" ToolTip="Vendor Ref #" placeholder=" " CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="VendorRefInput2 DateR">
                            <asp:Label ID="Label4" runat="server" Text="Ref Date" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtVendorRefnodate" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Vendor Ref Date"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtVendorRefnodate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <div class="PDCredit">
                            <asp:Label ID="lbl_crdtdays" runat="server" Text="Credit Days" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txt_crdtdays" ToolTip="Credit Days" placeholder="" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                             </div>
                    </div>

                     

                    <div class="FormGroupContent4 boxmodal">
                         <div class=" FormGroupContent4">

                        <div class="ChargeDes">
                            <asp:Label ID="lbl_chrgdes" runat="server" Text="Charge Description" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_chrgdes" runat="server" ToolTip="Charge Description" placeholder=" " CssClass="form-control" OnTextChanged="txt_chrgdes_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>

                        <div class="Curr">
                            <asp:Label ID="lbl_curr" runat="server" Text="Curr" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_curr" runat="server" CssClass="form-control" ToolTip="Curr" placeholder="" OnTextChanged="txt_curr_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>

                        <div class="RateInput">
                            <asp:Label ID="lbl_rate" runat="server" Text="Rate" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_rate" runat="server" ToolTip="Rate" placeholder="" CssClass="form-control" OnTextChanged="txt_rate_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>

                        <div class="ExRateInput">
                            <asp:Label ID="lbl_exrate" runat="server" Text="Ex Rate" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_exrate" runat="server" ToolTip="Ex Rate" placeholder=" " CssClass="form-control" OnTextChanged="txt_exrate_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>

                        <div class="BaseDrop">
                            <asp:Label ID="lbl_base" runat="server" Text="Base" CssClass="LabelValue"></asp:Label>
                            <asp:DropDownList ID="ddl_base" runat="server" Height="23" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddl_base_SelectedIndexChanged1">
                                <asp:ListItem Value="0">BASE / Units</asp:ListItem>
                                <asp:ListItem Text="DOC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="AmountInput">
                            <asp:Label ID="lbl_amount" runat="server" Text="Amount" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_amount" runat="server" ToolTip="Amount" placeholder="" CssClass="form-control"> </asp:TextBox>
                        </div>
                        <div class=" ">
                            <div class="btn ico-add" id="btn_add1" runat="server">
                                <asp:Button ID="btn_add" runat="server" Text="Add" ToolTip="Add" OnClick="btn_add_Click" />
                            </div>
                        </div>
                             </div>
                    </div>

                    <%--                    <div class="FormGroupContent4">
                    <asp:Panel ID="grd_panel" runat="server" ScrollBars="Auto" CssClass="Grid2">
                    <asp:GridView ID="grd_profomaDN" runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                    OnRowDataBound="grd_profomaDN_RowDataBound" CssClass="Grid FixedHeader" DataKeyNames="chargeid,opstype" OnSelectedIndexChanged="grd_profomaDN_SelectedIndexChanged">
                    <Columns>
                    <asp:BoundField DataField="charge" HeaderText="Charges" />
                    <asp:BoundField DataField="curr" HeaderText="Curr" />
                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" />
                    <asp:BoundField DataField="exrate" HeaderText="ExRate" />
                    <asp:BoundField DataField="base" HeaderText="Base/Unit" />
                    <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" />                            
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>
                    </asp:Panel>
                    </div>--%>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="grd_panel" runat="server" ScrollBars="Auto" CssClass="gridpnl MB0">
                            <asp:GridView ID="grd_profomaDN" runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                OnRowDataBound="grd_profomaDN_RowDataBound" CssClass="Grid FixedHeader" DataKeyNames="chargeid,opstype" OnSelectedIndexChanged="grd_profomaDN_SelectedIndexChanged" OnPreRender="grd_profomaDN_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="charge" HeaderText="Charges" />
                                    <%-- 0 --%>
                                    <asp:BoundField DataField="curr" HeaderText="Curr"  HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                    <%-- 1 --%>
                                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="120px" ItemStyle-Width="120px" />
                                    <%-- 2 --%>
                                    <asp:BoundField DataField="exrate" HeaderText="ExRate" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="120px" ItemStyle-Width="120px" />
                                    <%-- 3 --%>
                                    <asp:BoundField DataField="base" HeaderText="Base/Unit" HeaderStyle-Width="120px" ItemStyle-Width="120px" />
                                    <%-- 4 --%>
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 5 --%>
                                        <HeaderStyle HorizontalAlign="Center" Width="150" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GST" HeaderText="GST" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 6 --%>
                                        <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle HorizontalAlign="Right" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total Amount" HeaderText="Total Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 7 --%>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right"  Width="150px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                        <div class="FormGroupContent4">
                            <div class="TotalInput">
                                <asp:Label ID="lbl_total" runat="server" Text="Total" CssClass="LabelValue" Style="display:none"></asp:Label>
                                <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" Style="text-align: right" ToolTip="Total" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="FormGroupContent4">

                        <div id="lbl_txt" runat="server" visible="false">
                            <div class="PreparedTxt">Prepared By:</div>
                            <div class="PrepareValue">
                                <asp:Label ID="lbl_prepare" runat="server" Text="Prepare Value"></asp:Label>
                            </div>
                            <div class="ApprovedByTxt">Approved By:</div>
                            <div class="ApprovedValue" runat="server" visible="false" id="lbl_appr">
                                <asp:Label ID="lbl_Approve" runat="server" Text="Approved Value"></asp:Label>
                            </div>
                        </div>

                    </div>

                </div>

    <asp:Panel runat="Server" ID="pnldebit" CssClass="Pnl" Style="display: none;">
        <br />
        Do U Want GST for this Charge?
        <br />
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="Button"
                OnClick="btnYes_Click" />
            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="Button"
                OnClick="btnNo_Click" />
        </div>
    </asp:Panel>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="Confirmdialog" runat="server" TargetControlID="hid_pln" PopupControlID="pnldebit" DropShadow="false" />

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

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
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

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:Label ID="hid_pln" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_base" runat="server" />
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_transfer" runat="server" />
    <asp:HiddenField ID="hid_ops" runat="server" />
    <asp:HiddenField ID="hid_cname" runat="server" />
    <asp:HiddenField ID="hf_chargeid" runat="server" />
    <asp:HiddenField ID="hf_currid" runat="server" />
    <asp:HiddenField ID="hid_customerid" runat="server" />
    <asp:HiddenField ID="Str_Value" runat="server" />
    <asp:HiddenField ID="hid_vouyear" runat="server" />
    <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    <asp:CalendarExtender ID="clr_date" runat="server" TargetControlID="txt_date" Format="dd/MM/yyyy"></asp:CalendarExtender>
    </div>
               </div>
       
</asp:Content>
