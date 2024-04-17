<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AdminDCNNoNew.aspx.cs"
    Inherits="logix.FAForm.AdminDCNNoNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/CSFANEW.css" rel="stylesheet" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

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

    <link href="../Styles/AdminDCNNo.css" rel="stylesheet" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .ToInput6 {
            width: 49%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ToInputAdmin6 {
            width: 50.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .TotalTxtlbl {
            float: right;
            margin: 3px 0px 0px 0px;
            width: 18%;
        }

        .VendorRefInput1 {
            width: 50%;
            float: left;
            margin: 0px 1.5% 0px 0px;
        }

        .VendorRefInput2 {
            width: 48%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        span#logix_CPH_Label12 {
            display: none;
        }

        .TotalTxt2 {
            float: right;
            margin: 0px 0px 0px 0px;
            width: 72%;
        }
 
        .widget.box {
            position: relative;
            top: -8px;
        }

        table#logix_CPH_grd, table#logix_CPH_Grd_Charge {
            height: 0px;
        }

        .ToInput6 {
            margin-right: 0.5% !important;
        }

        select#logix_CPH_lst_container {
            height: 44px !important;
        }
        textarea#logix_CPH_txtbilladd, textarea#logix_CPH_txtsupplyadd {
    height: 94px!important;
}
        input#logix_CPH_txt_bl {
    height: 44px !important;
}
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {
                $("#<%=txt_to.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_customerid.ClientID %>").val(0);
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
                    select: function (e, i) {
                        $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var customer = $("#<%=txt_to.ClientID %>").val().split(',')[0];
                        $("#<%=txt_to.ClientID %>").val(customer);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
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
                    select: function (e, i) {
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var customer = $("#<%=txtsupplyto.ClientID %>").val().split(',')[0];
                        $("#<%=txtsupplyto.ClientID %>").val(customer);
                    },
                    minLength: 1
                });
            });

        }
    </script>

    <style type="text/css">
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
            width: auto;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
        }
        div#logix_CPH_lbl_txt {
    position: absolute;
    top: 32px;
    width: 75.5%;
    display: flex;
    justify-content: space-between;
}
        .div_Grid {
            width: 100%;
            float: left;
            margin-top: 0%;
            margin-left: 0%;
            height: 140px;
            overflow: hidden !important;
        }

        .chzn-drop {
            height: 182px !important;
            overflow: auto;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .ProDebitCustomer {
            width: 9%;
            float: left;
            margin: 22px 0.5% 0px 0px;
        }

        .ProDebitAgent {
            width: 15%;
            float: left;
            margin: 22px 0.5% 0px 0px;
        }

        .Year5 {
            float: left;
            width: 7.5%;
            margin: 0px 0.5% 0px 0%;
        }

        .RefNo2 {
            width: 33.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DateCal1C1 {
            width: 7%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .ProRef2 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobDetailsInput {
            width: 49%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobDetailsInputnew {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .vendordiv {
            width: 50.3%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .leftside {
            width: 77%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .color {
            color: red;
        }

        .rightside {
            width: 22.5%;
            float: left;
            margin: 0px 0px 0px 6px;
        }

        3 {
            position: relative;
            width: 100%;
            border: 1px solid #b1b1b1;
            overflow: hidden;
            border-collapse: collapse;
        }

            3 thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            3 tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 125px;
                overflow: auto;
            }

            3 th {
                min-width: 140px;
            }

            3 td {
                min-width: 140px;
            }

            3 th:nth-child(1) {
                min-width: 1000px;
            }

            3 td:nth-child(1) {
                min-width: 1000px;
            }

            3 th:nth-child(2) {
                min-width: 140px;
            }

            3 td:nth-child(2) {
                min-width: 140px;
            }

            3 th:nth-child(3) {
                min-width: 140px;
            }

            3 td:nth-child(3) {
                min-width: 140px;
            }

        2 {
            position: relative;
            width: 100%;
            border: 1px solid #b1b1b1;
            overflow: hidden;
            border-collapse: collapse;
        }

            2 thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            2 tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 136px;
                overflow: auto;
            }

            2 th {
                min-width: 140px;
            }

            2 td {
                min-width: 140px;
            }

            2 th:nth-child(1) {
                min-width: 440px;
            }

            2 td:nth-child(1) {
                min-width: 440px;
            }

            2 th:nth-child(2) {
                min-width: 120px;
            }

            2 td:nth-child(2) {
                min-width: 120px;
            }

            2 th:nth-child(3) {
                min-width: 100px;
            }

            2 td:nth-child(3) {
                min-width: 100px;
            }

            2 th:nth-child(4) {
                min-width: 100px;
            }

            2 td:nth-child(4) {
                min-width: 100px;
            }

            2 th:nth-child(5) {
                min-width: 100px;
            }

            2 td:nth-child(5) {
                min-width: 100px;
            }

            2 th:nth-child(6) {
                min-width: 140px;
            }

            2 td:nth-child(6) {
                min-width: 140px;
            }

            2 th:nth-child(7) {
                min-width: 140px;
            }

            2 td:nth-child(7) {
                min-width: 140px;
            }

            2 th:nth-child(8) {
                min-width: 140px;
            }

            2 td:nth-child(8) {
                min-width: 140px;
            }

        .Grid4 {
            border: 1px solid #b1b1b1;
            height: 159px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 100%;
        }

        .bordertopNew {
            border-top: 1px solid #b1b1b1;
            margin: 10px 0px 10px 0px;
            width: 100%;
        }
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 45px !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <%-- <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" id="HeaderID" runat="server"></a></li>
              <li><a href="#" title="">Voucher</a> </li>
              <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Profoma Admin Purchase Invoice</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->--%>
    <!-- Breadcrumbs line -->

    <div>

        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server"></asp:Label></h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#" title="" id="lblHead" runat="server"></a></li>
                            <li><a href="#">Vouchers</a> </li>
                            <%--<li><a href="#" title="" > Admin Sales Invoice</a> </li>--%>
                            <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Admin Sales Invoice</a> </li>
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
                            <div class="btn ico-save" id="btn_save1" runat="server" visible="false" >
                                <asp:Button ID="btn_save" runat="server" ToolTip="Save" Text="Save" Visible="false" OnClick="btn_save_Click" TabIndex="9" />

                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btn_view" runat="server" ToolTip="View" Text="View" OnClick="btn_view_Click" TabIndex="10" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" Text="Cancel" OnClick="btn_cancel_Click" TabIndex="11" />
                            </div>

                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal" style="display: flex; justify-content: flex-end">
                        <div class="Year5">
                            <asp:Label ID="Label3" runat="server" Text="Year"></asp:Label>
                            <asp:TextBox ID="txt_year" runat="server" ToolTip="Year" placeholder="" CssClass="form-control" TabIndex="1"></asp:TextBox>
                        </div>
                        <div class="ProRef2">
                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txt_Refno" runat="server" AutoPostBack="True" placeholder="" ToolTip="Ref No" OnTextChanged="txt_Refno_TextChanged" CssClass="form-control" TabIndex="2"></asp:TextBox>
                        </div>

                        <div class="DateCal1C1">
                            <asp:Label ID="Label5" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="3"></asp:TextBox>
                        </div>

                    </div>

                    <div class="leftside">

                        <div class="FormGroupContent4 custom-d-flex">

                            <div class="custom-col custom-mr-05 ">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label7" runat="server" Text="To"></asp:Label>
                                    <asp:TextBox ID="txt_to" runat="server" ToolTip="To" ReadOnly="true" placeholder="" CssClass="form-control" TabIndex="4"></asp:TextBox>
                                </div>

                                <div class="FormGroupContent4">
                                    <span>Bill From Address</span>
                                    <asp:TextBox ID="txtbilladd" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                            <div class="custom-col  ">
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label8" runat="server" Text="Supply To"></asp:Label>
                                    <asp:TextBox ID="txtsupplyto" runat="server" ToolTip="SupplyTo" ReadOnly="true" placeholder="" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                </div>

                                <div class="FormGroupContent4">
                                    <span>Supply From Address</span>
                                    <asp:TextBox ID="txtsupplyadd" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="FormGroupContent4">

                            <asp:Label ID="Label9" runat="server" Text="Remarks"></asp:Label>
                            <asp:TextBox ID="txt_remark" runat="server" Style="resize: none;" CssClass="form-control" ToolTip="Remarks" placeholder="" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>

                    <div class="rightside">
                        <div class="FormGroupContent4" style="color: red;">
                            <div class="TextArea">
                                <div class="FormGroupContent4 boxmodal">
                                    <div class="FormGroupContent4">

                                        <span>Against Ref #</span>
                                        <asp:ListBox ID="lst_container" runat="server" Width="100%" Height="100%" CssClass="color" BorderColor="#b1b1b1"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                            <%--<asp:TextBox ID="txtpayment" Style="resize: none;" Rows="10" runat="server" ToolTip="" placeholder="" CssClass="form-control" AutoPostBack="false" TextMode="MultiLine"></asp:TextBox>--%>
                        </div>

                        <div class="FormGroupContent4 boxmodal">
                            <div class="FormGroupContent4">
                                <asp:Label ID="Label1" runat="server" Text="Ref #"></asp:Label>
                                <asp:TextBox ID="txt_bl" runat="server" ReadOnly="true" ToolTip="Ref #" placeholder="" CssClass="form-control" TabIndex="7"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent4">
                                <asp:Label ID="Label2" runat="server" Text="Bill Type"></asp:Label>
                                <asp:DropDownList ID="ddl_bill" runat="server" Enabled="false" ToolTip="Bill Type" CssClass="chzn-select" data-placeholder="Bill Type" TabIndex="8">
                                    <%--    <asp:ListItem Text="" Value="0"></asp:ListItem>
            <asp:ListItem Value="Cash/Cheque">Cash/Cheque</asp:ListItem>
            <asp:ListItem Value="Credit">Credit</asp:ListItem>
            <asp:ListItem Value="Internal">Internal</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>

                            <div class="FormGroupContent4 custom-d-flex" id="vendorid" runat="server" visible="false">

                                <div class="custom-col custom-mr-1">
                                    <asp:Label ID="Label10" runat="server" Text="Vendor Ref#"></asp:Label>
                                    <asp:TextBox ID="txt_vendor" ReadOnly="true" runat="server" CssClass="form-control" ToolTip="Vendor Ref#" placeholder=""></asp:TextBox>
                                </div>

                                <div class="custom-col">
                                    <asp:Label ID="Label11" runat="server" Text="Vendor Ref Date"></asp:Label>
                                    <asp:TextBox ID="txtVendorRefnodate" ReadOnly="true" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Vendor Ref Date"></asp:TextBox>

                                </div>
                            </div>

                            <div class="ProDebitCustomer" style="display: none;">
                                <asp:RadioButton ID="radio_customer" Enabled="false" runat="server" Text="Customer" GroupName="A" AutoPostBack="true" />
                            </div>
                            <div class="ProDebitAgent" style="display: none;">
                                <asp:RadioButton ID="radio_agent" runat="server" Enabled="false" Text="Agent" GroupName="A" AutoPostBack="true" />
                            </div>

                            <div class="DateLBl2" style="display: none;">
                                <asp:Label ID="lbl_date" runat="server" Text="Date"></asp:Label>
                            </div>
                        </div>

                    </div>
                    <div class="FormGroupContent4">
                        <div style="float: left; margin: 1px 1px 1px 1px; color: red; display: none;">
                            <asp:Label ID="lbl_against" runat="server" Text=""></asp:Label>
                        </div>
                       
                    </div>
                

                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">

                            <div class="panel_04 MB0">
                                <asp:GridView ID="Grd_Charge" runat="server" AutoGenerateColumns="False" Width="100%"
                                    ShowHeaderWhenEmpty="True" class="TblGrid FixedHeader" OnPreRender="Grd_Charge_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="charge" HeaderText="Charges">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="curr" HeaderText="Curr">
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"
                                            ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exrate" HeaderText="ExRate" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                            <HeaderStyle Width="100px" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="base" HeaderText="Base/Unit">
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="TxtAlign1" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="TxtAlign1" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GST" HeaderText="GST" DataFormatString="{0:#,##0.00}">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="TxtAlign1" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="TxtAlign1" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total Amount" HeaderText="Total" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="opstype" HeaderText="Opstype">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div id="lbl_txt" runat="server" visible="false" >

                                <div class="ApprovedValue">
                                    <span class="bluetext">PREPARED BY</span>
                                    <asp:Label ID="lbl_prepare" runat="server" Text="Prepare Value"></asp:Label>

                                </div>

                                <div class="ApprovedValue align-right">
                                    <span class="bluetext">APPROVED BY </span>

                                    <asp:Label ID="lbl_Approve" runat="server" Text="Approved Value"></asp:Label>
                                </div>
                            </div>

                            <div class="right_btn MT0">

                                <div class="TotalTxt2">
                                    <span>Total</span>
                                    <asp:TextBox ID="txt_total" runat="server" Style="text-align: right" ToolTip="Total" placeholder="" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="TotalTxtlbl">
                                    <asp:Label ID="Label12" runat="server" Text="Total"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>

                    <%-- New Set --%>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="panel_04">
                            <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grd_RowDataBound" DataKeyNames="LedgerType" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grd_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="ledgername" HeaderText="Particulars">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TXTAlign1" HeaderStyle-CssClass="TXTAlign1">
                                        <HeaderStyle HorizontalAlign="right" Width="150px" />
                                        <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TXTAlign1" HeaderStyle-CssClass="TXTAlign1">
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
                </div>

            </div>
        </div>
    </div>
    <div class="div_Break"></div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_title" runat="server"></label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>
                </div>
            </div>
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="16px" Height="16px" />
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
    <asp:Label ID="Label4" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hid_chargeid" runat="server" />
    <asp:HiddenField ID="hid_customerid" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_base" runat="server" />
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_transfer" runat="server" />
    <asp:HiddenField ID="hid_SupplyTo" runat="server" />

    <asp:HiddenField ID="hid_refno" runat="server" />
    <asp:HiddenField ID="Hid_HeadTrantype" runat="server" />

</asp:Content>
