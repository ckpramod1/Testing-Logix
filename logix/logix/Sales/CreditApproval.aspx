<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CreditApproval.aspx.cs" Inherits="logix.Sales.CreditApproval" %>

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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../js/helper.js"></script>
    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->

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

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/CreditApproval.css" rel="stylesheet" type="text/css" />
    <script src="../Script_Date/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/Gridviewscroll.js"></script>
    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/gridviewScroll.min.js"></script>
    <link href="../Styles_Date/jquery1-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <%--<script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />--%>
    <script src="../Scripts/ScrollableGridPlugin.js"></script>

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

        .Gridpnl1 {
            Height: 460px;
        }

        #logix_CPH_pop_cancel {
            top: 45px !important;
        }

        .crumbs1 {
            display: none;
        }

        .CreditLink {
            width: 100%;
            float: left;
            font-size: 11px;
            margin: 0px;
            text-align: right;
        }

        .CreditRight {
            float: left;
            width: 34.5%;
            margin: 0px 0px 0px 0px;
        }

        .CreditLeft {
            float: left;
            width: 65%;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditLink {
            width: 100%;
            float: left;
            font-size: 11px;
            margin: 0px;
            text-align: left;
        }

        .panel_25 {
            height: 422px !important;
        }

        table#logix_CPH_test th:nth-child(1) {
            width: 30%;
        }

        table#logix_CPH_test td:nth-child(1) {
            width: 30%;
        }

        div#UpdatePanel1 {
            height: 100vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        span#logix_CPH_Label7 {
            margin: 10px 0 0 175px !important;
            display: inline-block;
            font-weight: normal !important;
            font-size: 14px !important;
        }
    </style>

    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: Tahoma;
            font-size: 12px;
            margin-left: -0.17%;
            margin-top: -1.7%;
            position: absolute;
            width: 860px;
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

        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_programmaticModalCancelCredit_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #programmaticModalPopupBehavior_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_Panel1 {
            top: 45px !important;
        }

        #logix_CPH_pnlUploader {
            top: 45px !important;
        }

        .CompanyDropCredit {
            width: 71.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CompanyDropCreditProduct {
            width: 21%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ChkBox {
            text-align: left;
            width: 10%;
            float: right;
            margin: 5px 0px 0px 0.5%;
        }
        span.chktext {
    margin: 0!important;
}
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 50px !important;
}
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_customer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var Chk = "";
                        var lblhead = "";
                        if ($("#<%=CheckPending.ClientID %>").is(':checked')) {
                            Chk = 'True';
                        }
                        else {
                            Chk = 'False';
                        }
                        $.ajax({
                            //url: "CreditApproval.aspx/GetCustomer",
                            url: "../Sales/CreditApproval.aspx/GetCustomer",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'" + Chk + "'}",
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
                                // alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_customer.ClientID %>").val(i.item.address);
                        $("#<%=hdf_cusid.ClientID %>").val(i.item.val);
                        $("#<%=txt_customer.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_customer.ClientID %>").val(i.item.address);
                        $("#<%=hdf_cusid.ClientID %>").val(i.item.val);
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                        $("#<%=txt_customer.ClientID %>").change();

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_customer.ClientID %>").val(i.item.address);
                            $("#<%=hdf_cusid.ClientID %>").val(i.item.val);
                            $("#<%=txt_customer.ClientID %>").change();
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_customer.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });

            //        -----------------------------------------------------------------------------------------

            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'

            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        <%--$(document).ready(function () {
            $("#<%=txt_branch.ClientID %>").autocomplete({

                source: function (request, response) {
                    $("#<%=hid_branchid.ClientID %>").val(0);
                    $.ajax({
                        url: "CreditApproval.aspx/GetBranch",
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
                    $("#<%=txt_branch.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=txt_branch.ClientID %>").change();
                    $("#<%=hid_branchid.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txt_branch.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=hid_branchid.ClientID %>").val(i.item.val);
                },
                change: function (event, i) {
                    if (i.item) {
                        $("#<%=txt_branch.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_branchid.ClientID %>").val(i.item.val);
                    }
                },
                close: function (event, i) {
                    var result = $("#<%=txt_branch.ClientID %>").val().toString().split(',')[0];
                    $("#<%=txt_branch.ClientID %>").val($.trim(result));
                },
                minLength: 1
            });
        });--%>
        }

    </script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you Want to Cancel this Credit?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <style type="text/css">
        .CompanyDropCreditnew {
            width: 72%;
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
                font-family: Tahoma;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .inputred {
            width: 54%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

            .inputred input {
                color: red !important;
            }

        td {
            height: fit-content !important;
        }
        #logix_CPH_Book2 {
    height: 499px;
    /* overflow-y: scroll !important; */
    overflow-x: hidden;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <asp:HiddenField ID="hdf_cusid" runat="server" />

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4><i class="icon-umbrella"></i>
                            <asp:Label ID="headerlbl" runat="server" Text="Credit Approval"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs" id="crumbsid" runat="server">
                            <ul id="breadcrumbs" class="breadcrumb" runat="server">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li id="lblHead1" runat="server"><a href="#" title="" runat="server" id="HeaderLabel1">Ocean Exports</a> </li>
                                <li id="lblHead2" runat="server"><a href="#" title="" id="headerlabel2" runat="server">Sales</a> </li>
                                <li class="current"><a href="#" title="">Credit Approval</a> </li>
                            </ul>
                        </div>
                        <!-- /Breadcrumbs line -->
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                     <div class="FixedButtons">
     
             <div class="right_btn">

                 <div class="btn ico-save" id="btn_save1" runat="server">
                     <asp:Button ID="btnSave" runat="server" ToolTip="Save" Text="Save" OnClick="btnSave_Click" TabIndex="11" />
                 </div>
                 <div class="btn ico-view">
                     <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" TabIndex="12" />
                 </div>
                 <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                     <asp:Button ID="btnCancel" runat="server" Text="Back" ToolTip="Back" OnClick="btnCancel_Click" TabIndex="13" />
                 </div>
             </div>
 </div>


                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4">

                        <div class="CreditLeft">
                            <div class="FormGroupContent4">
                                <div class="CompanyDropCredit" id="CompanyDropCreditnew" runat="server">
                                    <asp:DropDownList ID="ddlCompany" runat="server"
                                        CssClass="chzn-select" Placeholder="Company" ToolTip="Company" Width="100%"
                                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                        <asp:ListItem Text=""></asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                                <div class="CompanyDropCreditProduct hide">
                                    <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="CompanyBranch">
                                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="chzn-select" Data-placeholder="Branch" ToolTip="Branch" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:TextBox ID="txt_branch" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Branch" ToolTip="Branch" OnTextChanged="txt_branch_TextChanged"></asp:TextBox>--%>
                                </div>
                            </div>

                            <div class="FormGroupContent4 custom-d-flex">

                                <div class="custom-col custom-mr-05">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_dsodays" runat="server" CssClass="form-control align-right" placeholder="DSO Days" ToolTip="DSO Days" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="custom-col custom-mr-05" id="id_txt_actual_dsodays" runat="server">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_actual_dsodays" runat="server" CssClass="form-control align-right" placeholder="Actual DSO Days" ToolTip="Actual DSO Days" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="custom-col">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_invoiceAmt" runat="server" CssClass="form-control align-right" placeholder="Last 30 Days Invoice Amount" ToolTip="Last 30 Days Invoice Amount" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4 custom-d-flex">

                                <div class="custom-col custom-mr-05">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_Avg" runat="server" CssClass="form-control align-right" placeholder="Average" ToolTip="Average" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="custom-col custom-mr-05">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_AppCrdtAmt" runat="server" CssClass="form-control align-right" ReadOnly="true" placeholder="Approved Credit Amount" ToolTip="Approved Credit Amount"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="custom-col ">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_actOutstanding" runat="server" CssClass="form-control align-right" placeholder="Actual Outstanding" ToolTip="Actual Outstanding" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4" style="display: none">

                                <div class="CreditCal">Credit Caluclutaion Formula</div>
                                <div class="LessInput">
                                    <asp:TextBox ID="txt_less" runat="server" CssClass="form-control align-right" placeholder="Less" ToolTip="Less" ReadOnly="true" Enabled="False"></asp:TextBox>
                                </div>

                            </div>

                            <div class="FormGroupContent4">
                                <div class="CustomerLabel1">
                                    <asp:LinkButton ID="customerlink" CssClass="anc ico-find-sm" runat="server" Style="color: Red; font-size: 12px; text-decoration: none;"
                                        OnClick="customerlink_Click"></asp:LinkButton>
                                    <span style="display: inline-block;margin: 15px 0px 0px 4px;" >Customer</span>
                                </div>
                                <asp:Label ID="Label7" runat="server" Text="Invoice / Other DN only taken for the Outstanding Calculation." Style="font-size: 12px;"></asp:Label>
                                <div class="ChkBox">
                                    <span>Pending App.</span>
                                    <asp:CheckBox ID="CheckPending" runat="server"
                                        AutoPostBack="True"
                                        OnCheckedChanged="CheckPending_CheckedChanged" TabIndex="2" />

                                </div>
                            </div>
                            <div class="FormGroupContent4 custom-d-flex">
                                <div class="custom-col custom-mr-05">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_customer" runat="server"
                                            CssClass="form-control"
                                            OnTextChanged="txt_customer_TextChanged" AutoPostBack="true" placeholder="Customer" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="CRDInput">
                                    <div class="FormGroupContent4">

                                        <asp:TextBox ID="txt_cano" runat="server" Width="100%" CssClass="form-control" placeholder="Crd Approval#" ReadOnly="true" ToolTip="Credit Approval Number" TabIndex="3"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="FormGroupContent4 hide">

                                <div class="ApproveInputBox">
                                    <asp:DropDownList ID="ddlApptype" runat="server" CssClass="chzn-select" data-placeholder="App.Type" ToolTip="Approve Type" Width="100%" TabIndex="4">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="ApproveBYInput" style="display: none;">
                                    <asp:TextBox ID="txt_approvedBy" runat="server" CssClass="form-control" placeholder="App By" ToolTip="Approved By"></asp:TextBox>
                                </div>
                                <div class="ApproveAmountTxt">
                                    <asp:TextBox ID="txt_approvedAmt" runat="server" CssClass="form-control" Width="100%" onkeypress="return validateFloatKeyPress(this,event,'Approved Amt');" placeholder="Approved Amount" ToolTip="Approved Amount" TabIndex="5"></asp:TextBox>
                                </div>
                                <div class="ApproveDays">
                                    <asp:TextBox ID="txt_app_days" runat="server" CssClass="form-control" Width="100%" placeholder="App Days" ToolTip="Approved Days" TabIndex="6"></asp:TextBox>
                                </div>
                                <div class="DaysDisabel" style="display: none;">
                                    <asp:TextBox ID="txt_credit_reqon" runat="server" Enabled="false"
                                        Width="100%" AutoPostBack="True" CssClass="form-control date" placeholder="Credit Request On" ToolTip="Credit Request On" TabIndex="7"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent4" style="display: none">
                                <div class="NoofExemptions">No of Exemptions</div>
                                <div class="TxtExemptions">
                                    <asp:TextBox ID="txt_exemptions" runat="server" ToolTip="No. of Exemptions" AutoPostBack="true" Style="text-align: right;" placeholder="No. of Exemptions" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                </div>

                                <div class="DayPerAnnual">
                                    <asp:DropDownList ID="ddl_per" runat="server" ToolTip="Annual" data-placeholder="Per" Width="100%" CssClass="chzn-select" BorderColor="#999997" TabIndex="9">
                                        <%--<asp:ListItem Text=""></asp:ListItem>--%>
                                        <asp:ListItem Text="Annual"></asp:ListItem>
                                        <asp:ListItem Text="Month"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="OvedueInput">
                                    <asp:TextBox ID="txt_overdue" Width="100%" runat="server" Text="50" ToolTip="Allowed Overdue" Style="text-align: right;" placeholder="Allowed Overdue" CssClass="form-control" OnTextChanged="txt_overdue_TextChanged" TabIndex="10"></asp:TextBox>
                                </div>
                                <div class="CancelLink">
                                    <asp:LinkButton ID="chkCanelCerdit" runat="server"
                                        Style="color: Red; text-decoration: none; font-size: 12px;" OnClick="chkCanelCerdit_Click">Cancel Credit</asp:LinkButton>
                                </div>

                            </div>

                            <div class="FormGroupContent4">
                                <div class="CreditLink">

                                    <div class="panel_07 MB0" id="pnlcreditreq" runat="server">
                                        <asp:GridView ID="Gridcreditreq" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
                                            ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" ShowHeaderWhenEmpty="True"
                                            BackColor="White" OnSelectedIndexChanged="Gridcreditreq_SelectedIndexChanged" OnRowDataBound="Gridcreditreq_RowDataBound" OnRowCommand="Gridcreditreq_RowCommand">
                                            <Columns>
                                                <asp:ButtonField CommandName="ColumnClick" Visible="false" />
                                                <asp:BoundField DataField="Customer" HeaderText="Customer" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:BoundField DataField="Product" HeaderText="Product" />
                                                <asp:BoundField DataField="Volume" HeaderText="Volume" />
                                                <asp:BoundField DataField="VolumeType" HeaderText="Type" />
                                                <asp:BoundField DataField="Revenue" HeaderText="Revenue" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" />
                                                <asp:BoundField DataField="Creditdays" HeaderText="Credit Days" ItemStyle-CssClass="TxtAlign1" HeaderStyle-Width="95px" ItemStyle-Width="95px" />
                                                <asp:BoundField DataField="CreditAmount" HeaderText="Credit Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-Width="95px" ItemStyle-Width="95px" />

                                                <asp:TemplateField HeaderText="Approved Days">
                                                    <ItemTemplate>
                                                        <%--  Text='<%#Bind("pappdays") %>' --%>
                                                        <asp:TextBox ID="txt_AppDays" runat="server" BorderColor="White" Text='<%#Eval("pappdays")%>' Font-Size="8pt" AutoPostBack="true" OnTextChanged="txt_AppDays_TextChanged" ToolTip="seldays"
                                                            TabIndex="0" Style="text-align: right;" CssClass="grdcurrfield"></asp:TextBox>

                                                    </ItemTemplate>
                                                    <HeaderStyle Width="95px" />
                                                    <ItemStyle HorizontalAlign="Right" Width="95px" Wrap="false" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Approved Amount">
                                                    <ItemTemplate>
                                                        <%-- Text='<%#Bind("pappamt") %>' --%>
                                                        <asp:TextBox ID="txt_AppAmount" runat="server" BorderColor="White" Text='<%# String.Format("{0:0.00}",Convert.ToInt64(DataBinder.Eval
(Container.DataItem, "pappamt")))%>'
                                                            DataFormatString="{0:0.00}" Font-Size="8pt" AutoPostBack="true" OnTextChanged="txt_AppAmount_TextChanged" CommandName="selamt"
                                                            TabIndex="0" Style="text-align: right;" CssClass=" grdcurrfield "></asp:TextBox>

                                                    </ItemTemplate>
                                                    <HeaderStyle Width="95px" />
                                                    <ItemStyle HorizontalAlign="Right" Width="95px" Wrap="false" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Imgsb" runat="server" CausesValidation="false" CommandName="Delete"
                                                            ImageUrl="~/images/delete.jpg" Height="16px" OnClick="Imgsb_Click" />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:BoundField DataField="crid" HeaderText="crid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />

                                                <asp:TemplateField HeaderText="Exemptions">
                                                    <ItemTemplate>
                                                        <%--  Text='<%#Bind("pappdays") %>' --%>
                                                        <asp:TextBox ID="txt_Exemptions" runat="server" BorderColor="White" Text='<%#Eval("pEXLIMIT")%>' Font-Size="8pt" AutoPostBack="true" OnTextChanged="txt_Exemptions_TextChanged" ToolTip="seldays"
                                                            TabIndex="0" Style="text-align: right;" CssClass="grdcurrfield"></asp:TextBox>

                                                    </ItemTemplate>
                                                    <HeaderStyle Width="95px" />
                                                    <ItemStyle HorizontalAlign="Right" Width="95px" Wrap="false" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mode"><%--8--%>
                                                    <HeaderStyle Width="110px" Wrap="false" />

                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddl_exemption" runat="server" Width="100%" ToolTip="Exemption Mode" AutoPostBack="true">
                                                            <asp:ListItem Value="1">Month</asp:ListItem>
                                                            <asp:ListItem Value="2">Annual</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="110px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Over Due">
                                                    <ItemTemplate>
                                                        <%--  Text='<%#Bind("pappdays") %>' --%>
                                                        <asp:TextBox ID="txt_Overdue" runat="server" BorderColor="White" Text='<%#Eval("pOVERDUE")%>' Font-Size="8pt" AutoPostBack="true" OnTextChanged="txt_Overdue_TextChanged1" ToolTip="seldays"
                                                            TabIndex="0" Style="text-align: right;" CssClass="grdcurrfield"></asp:TextBox>

                                                    </ItemTemplate>
                                                    <HeaderStyle Width="95px" />
                                                    <ItemStyle HorizontalAlign="Right" Width="95px" Wrap="false" />
                                                </asp:TemplateField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="myGridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                        </asp:GridView>
                                    </div>

                                </div>

                                <div class="bordertopNew"></div>
                                <div class="left_btn">
                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                        Style="color: Red; text-decoration: none;" CssClass="anc ico-find-sm" OnClick="LinkButton1_Click"></asp:LinkButton>
                                    <span style="display: inline-block;margin: 18px 0px 0px 4px;">Approved Credit List</span>
                                </div>
                                <asp:Label ID="lbl_crmt" runat="server" Style="font-weight: bold!important; color: #b50000!important; text-decoration: none; display: none"></asp:Label>


                            </div>
                        </div>
                        <div class="CreditRight MB10">
                            <asp:Panel ID="Book2" runat="server" CssClass="" Visible="true" ScrollBars="Vertical">
                                <asp:GridView ID="test" runat="server" CssClass="Grid FixedHeader" OnRowDataBound="test_RowDataBound">
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>

                                <div class="div_Break"></div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="FootrDayText">
        <asp:TextBox ID="txtcfoappdays" runat="server" CssClass="Text" Width="100%" placeholder="Approved Days" ToolTip="Approved Days" BorderColor="#999997"></asp:TextBox>
    </div>
    <div class="FootrAmountText">
        <asp:TextBox ID="txtcfoappamt" runat="server" CssClass="Text" Width="100%" placeholder="Approved Days" ToolTip="Approved Days" BorderColor="#999997"></asp:TextBox>
    </div>
    <div class="FootrItemsText">
        <asp:TextBox ID="txtcfoexempted" runat="server" CssClass="Text" Width="100%" placeholder="Approved Days" ToolTip="Approved Days" BorderColor="#999997"></asp:TextBox>
    </div>

    <div class="FootrCFOText">
        <asp:DropDownList ID="ddlFootrCFO" runat="server" CssClass="chzn_select" Width="100%"></asp:DropDownList>
    </div>
    <div class="FootrApTypeText">
        <asp:DropDownList ID="cmbcfoapptype" runat="server" CssClass="chzn_select" Width="100%"></asp:DropDownList>
    </div>
    <div class="div_Break"></div>

    <div class="FootrDayText">
        <asp:TextBox ID="txtcooappdays" runat="server" CssClass="Text" Width="100%" placeholder="Days" ToolTip="Days" BorderColor="#999997"></asp:TextBox>
    </div>
    <div class="FootrAmountText">
        <asp:TextBox ID="txtcooappamt" runat="server" CssClass="Text" Width="100%" placeholder="Amount" ToolTip="Amount" BorderColor="#999997"></asp:TextBox>
    </div>

    <div class="FootrItemsText">
        <asp:TextBox ID="txtcooexempted" runat="server" CssClass="Text" Width="100%" placeholder="No.times credit exempted" ToolTip="Number Of times credit exempted" BorderColor="#999997"></asp:TextBox>
    </div>

    <div class="FootrCFOText">
        <asp:DropDownList ID="ddlFootrCoO" runat="server" CssClass="Text" Width="100%"></asp:DropDownList>
    </div>

    <div class="FootrApTypeText">
        <asp:DropDownList ID="cmbcooapptype" runat="server" CssClass="chzn_select" Width="100%"></asp:DropDownList>
    </div>
    <div class="div_Break"></div>

    <div class="FootrDayText">
        <asp:TextBox ID="txtmdappdays" runat="server" CssClass="Text" Width="100%" placeholder="Amount" ToolTip="Amount" BorderColor="#999997"></asp:TextBox>
    </div>

    <div class="FootrAmountText">
        <asp:TextBox ID="txtmdappamt" runat="server" CssClass="Text" Width="100%" placeholder="Amount" ToolTip="Amount" BorderColor="#999997"></asp:TextBox>
    </div>

    <div class="FootrItemsText">
        <asp:TextBox ID="txtmdexempted" runat="server" CssClass="Text" Width="100%" placeholder="No.times credit exempted" ToolTip="Number Of times credit exempted" BorderColor="#999997"></asp:TextBox>
    </div>
    <div class="FootrCFOText">
        <asp:DropDownList ID="ddlFootrMD" runat="server" CssClass="chzn_select" Width="100%"></asp:DropDownList>
    </div>
    <div class="FootrApTypeText">
        <asp:DropDownList ID="cmbmdapptype" runat="server" CssClass="chzn_select" Width="100%"></asp:DropDownList>
    </div>
    <div class="div_Break"></div>

    <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none;" />
    <ajaxtoolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" TargetControlID="Button4" BehaviorID="programmaticModalPopupBehavior"
        PopupControlID="pnlUploader" CancelControlID="Image2" DropShadow="false">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel ID="pnlUploader" runat="server" CssClass="modalPopup" BorderColor="ActiveBorder" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel4" runat="server" CssClass="Gridpnl" ScrollBars="Vertical">

                <asp:GridView ID="GrdCreditAmt" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False"
                    Width="100%" Style="background-color: White; color: Black;"
                    EmptyDataText="No Records Found"
                    OnRowDataBound="GrdCreditAmt_RowDataBound"
                    OnPageIndexChanging="GrdCreditAmt_PageIndexChanging" OnSelectedIndexChanged="GrdCreditAmt_SelectedIndexChanged"
                    PageSize="19" AllowPaging="false">
                    <Columns>

                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="33px" />
                            <ItemStyle HorizontalAlign="Right" Width="10px" Wrap="false" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <%--<asp:BoundField DataField="salesperson" HeaderText="Employee Name" 
                        ItemStyle-HorizontalAlign="Right" >
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 108px">
                                    <asp:Label ID="curr" runat="server" Text='<%# Bind("salesperson") %>' ToolTip='<%#Bind("salesperson")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="145px" />
                            <ItemStyle HorizontalAlign="Left" Width="108px" Wrap="false" />

                        </asp:TemplateField>

                        <%--<asp:BoundField DataField="branch" HeaderText="Branch" />--%>
                        <asp:TemplateField HeaderText="Branch">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 106px">
                                    <asp:Label ID="branch" runat="server" Text='<%# Bind("branch") %>' ToolTip='<%#Bind("branch")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="145px" />
                            <ItemStyle HorizontalAlign="Left" Width="110px" Wrap="false" />

                        </asp:TemplateField>

                        <%--<asp:BoundField DataField="customername" HeaderText="Customer Name" />--%>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 268px">
                                    <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="358px" />
                            <ItemStyle HorizontalAlign="Left" Width="145px" Wrap="false" />

                        </asp:TemplateField>

                        <%--<asp:BoundField DataField="appamt" HeaderText="Amount" DataFormatString="{0:f2}">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis;">
                                    <asp:Label ID="appamt" runat="server" Text='<%# Bind("appamt") %>' ToolTip='<%#Bind("appamt")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="150px" />
                            <ItemStyle HorizontalAlign="right" Width="150px" Wrap="false" />

                        </asp:TemplateField>

                        <%-- HeaderText="empid"
                    HeaderText="bid"
                    HeaderText="divid"--%>

                        <asp:BoundField DataField="empid" Visible="False" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                        <asp:BoundField DataField="bid" Visible="False" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                        <asp:BoundField DataField="divid" Visible="False" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />

                </asp:GridView>

                <link href="../Styles/chosen.css" type="text/css" />
                <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
                <%--<script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>--%>
            </asp:Panel>
        </div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <%--    -------------------------------------------------------------------------------%>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none;" />
    <ajaxtoolkit:ModalPopupExtender ID="programmaticModalCustomer" runat="server" TargetControlID="Button3" BehaviorID="programmaticModalPopupBehavior1"
        PopupControlID="Panel1" CancelControlID="Image1" DropShadow="false"
        RepositionMode="RepositionOnWindowScroll">
    </ajaxtoolkit:ModalPopupExtender>
    <%-- RepositionOnWindowScroll   RepositionOnWindowResize--%>
    <%--<asp:Panel ID="Panel1" runat="server" CssClass="pnlUploader" >

     <div style="background-color:White; color:Black;">
      <asp:Button ID="btn_cus" runat="server" Text="X" style ="float:right;" Height="29px" />--%>
    <asp:Panel ID="Panel1" runat="server" BorderColor="ActiveBorder" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" BorderColor="ActiveBorder" CssClass="Gridpnl" Style="overflow: auto;">
                <asp:GridView ID="Grdcustomer" runat="server" AutoGenerateColumns="False"
                    Width="100%" ForeColor="Black" CssClass="Grid FixedHeader" OnSelectedIndexChanged="Grdcustomer_SelectedIndexChanged"
                    EmptyDataText="No Records Found" ShowHeaderWhenEmpty="true" ShowHeader="true"
                    OnRowDataBound="Grdcustomer_RowDataBound">

                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="custype"
                            ItemStyle-HorizontalAlign="Right" Visible="False">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="groupname" HeaderText="Customer" />--%>
                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                    <asp:Label ID="groupname" runat="server" Text='<%# Bind("groupname") %>' ToolTip='<%# Bind("groupname") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="250px" />
                            <ItemStyle HorizontalAlign="Left" Wrap="false" />

                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Location" DataField="portname" />
                        <asp:BoundField HeaderText="ClientType" DataField="clienttype">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="SalesPerson" DataField="empname" />

                        <asp:BoundField HeaderText="CreditType" DataField="creditype" />

                        <asp:BoundField HeaderText="CreditAmount" DataField="creditamt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="groupid" DataField="groupid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </asp:Panel>

    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <%--    --------------------------------------PopupDragHandleControlID="Panel2"-----------------------------------OkControlID="Button1"------%>

    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />

    <ajaxtoolkit:ModalPopupExtender ID="programmaticModalCancelCredit" runat="server" TargetControlID="Button2" DropShadow="false"
        PopupControlID="pop_cancel" CancelControlID="imgggok"
        RepositionMode="RepositionOnWindowResize">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel ID="pop_cancel" runat="server" BorderColor="ActiveBorder" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgggok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel5" runat="server" BorderColor="ActiveBorder" CssClass="Gridpnl">
                <asp:GridView ID="GrdCancel" runat="server" AutoGenerateColumns="False"
                    Width="100%" ForeColor="Black" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Records Found" OnPageIndexChanging="GrdCancel_PageIndexChanging" PageSize="20" AllowPaging="false"
                    OnRowDataBound="GrdCancel_RowDataBound" OnSelectedIndexChanged="GrdCancel_SelectedIndexChanged">

                    <Columns>

                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="27px" />
                            <ItemStyle HorizontalAlign="Right" Width="10px" Wrap="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 296px">
                                    <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%#Bind("customer")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="296px" />
                            <ItemStyle HorizontalAlign="Left" Width="296px" Wrap="false" />

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Location">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 106px">
                                    <asp:Label ID="location" runat="server" Text='<%# Bind("location") %>' ToolTip='<%#Bind("location")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="SalesPerson">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 106px">
                                    <asp:Label ID="salesperson" runat="server" Text='<%# Bind("salesperson")%>' ToolTip='<%#Bind("salesperson")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />

                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Credit Days" DataField="creditdays" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" />

                        <%--<asp:TemplateField HeaderText ="Credit Days">
                      <ItemTemplate>
                     <div  style="overflow:hidden;text-overflow:ellipsis;width:106px">
                      <asp:Label ID="creditdays" runat="server" Text='<%# Bind("creditdays") %>' Tooltip='<%#Bind("creditdays")%>'></asp:Label>  
                          </div> 
                      </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="106px" />
                            <ItemStyle HorizontalAlign="Right" Width="106px" Wrap ="false"  />

                     </asp:TemplateField>--%>

                        <asp:BoundField HeaderText="CreditAmount" DataField="creditamt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                        <%--<asp:TemplateField HeaderText ="CreditAmount">
                      <ItemTemplate>
                     <div  style="overflow:hidden;text-overflow:ellipsis;width:106px">
                      <asp:Label ID="creditamt" runat="server" Text='<%# Bind("creditamt") %>' Tooltip='<%#Bind("creditamt")%>' ></asp:Label>  
                          </div> 
                      </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="106px" />
                            <ItemStyle HorizontalAlign="Right" Width="106px" Wrap ="false"  />

                     </asp:TemplateField> --%>

                        <asp:BoundField HeaderText="customerid" DataField="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">

                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" runat="server" />

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="25px" />
                        </asp:TemplateField>

                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="div_Break"></div>
            <div class="right_btn" style="margin-right: 10px; margin-top: -22px;">
                <div class="btn ico-cancel">
                    <asp:Button ID="Button1" runat="server" Text="Credit Cancel"
                        Width="80px" OnClick="btncrdtcncl_Click" />
                </div>
            </div>
        </div>

    </asp:Panel>

    <%--</div>--%>

    <div id="PanelLog1" runat="server">
        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="lbl" runat="server">Customer Name:</label>

                    </div>
                    <div class="LogHeadJobInput">

                        <asp:Label ID="JobInput" runat="server"></asp:Label>

                    </div>

                </div>
                <div class="DivSecPanel">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>

    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <asp:HiddenField ID="hid_branchid" runat="server" />
    <asp:HiddenField ID="hid_own" runat="server" />
    <asp:HiddenField ID="hid_sal" runat="server" />

    <asp:HiddenField ID="hid_crid" runat="server" />

    <asp:HiddenField ID="hid_availCrdtDay" runat="server" />
    <asp:HiddenField ID="hdn_cusid" runat="server" />

</asp:Content>
