<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="BRS.aspx.cs" Inherits="logix.FAForm.BRS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/MasterSubGroup.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" />
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

    <link href="../CSS/Finance.css" rel="stylesheet" />

    <link href="../Styles/Brs.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle.css" rel="stylesheet" />
    <style type="text/css">
        .GridContraN {
            width: 100%;
            height: 135px;
            margin: 0px 0px 0px 0px;
            overflow-x: auto !important;
            overflow-y: auto !important;
            border: 1px solid #b1b1b1;
        }

        .GridContra {
            width: 100%;
            height: 212px;
            margin: 0px 0px 0px 0px;
            overflow-x: auto !important;
            overflow-y: auto !important;
            border: 1px solid #b1b1b1;
        }

        .BrsRight {
            width: 520px;
            float: left;
            margin: 0px 0% 0px 0px;
            padding-top: 5px;
        }

        .CR {
            width: 2%;
            float: left;
            text-align: right;
            font-size: 11px;
            margin: 0px 0% 0px 5px;
        }

        .ChkIssued {
            width: 100%;
            float: left;
            text-align: left;
            font-size: 11px;
            margin: -5px 0% 0px 0px;
        }

        .BRSBalancetxt {
            width: 97%;
            float: left;
            text-align: left;
            font-size: 11px;
            margin: 0px 0% 0px 0px;
        }

        .BRSBalance {
            width: 47%;
            float: left;
            text-align: right;
            font-size: 11px;
            margin: 0px 1.5% 0px 0px;
        }

        .USDCHK {
            width: 8%;
            float: left;
            margin: 20px 0.5% 0px 1px;
        }

            .USDCHK input {
                float: left;
                margin: 3px 5px 0px 0px;
            }

            .USDCHK label {
                display: inline-block;
                margin: 2px 0px 0px 0px;
            }

        .BRSToDate {
            width: 6.5%;
            float: left;
            margin: 5px 0.5% 0px 0px;
        }

        .BRSTxtbox {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .chzn-drop {
            background: #fff;
            border: 1px solid #aaa;
            border-top: 0;
            position: absolute;
            top: 29px;
            left: 0;
            -webkit-box-shadow: 0 4px 5px rgba(0,0,0,.15);
            -moz-box-shadow: 0 4px 5px rgba(0,0,0,.15);
            box-shadow: 0 4px 5px rgba(0,0,0,.15);
            z-index: 1010;
            text-align: left;
            height: 300px;
            overflow: auto;
        }

        .BrsLEFT {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            padding-top: 5px;
        }

        .BrsRight {
            width: 49.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        #logix_CPH_ddlbank_chzn {
            width: 100% !important;
        }

        .BRSCheque {
            width: 52.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Brs_breakBank {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Pnl {
            height: 233px !important;
            border: 1px solid #b1b1b1 !important;
            width: 30%;
            padding: 10px;
            background-color: #fff;
            text-align: center;
        }

     #logix_CPH_pnlConfirm {
      top: 192px !important;
    left: 456px !important;
}

        .popupconfirmnew {
            display: block;
            position: fixed;
            z-index: 100001;
            left: 390.5px;
        }

        /*CSS*/

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
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
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
            white-space: nowrap;
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

        .panel_03 {
            height: 70px !important;
        }
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 60px !important;
}
        div#logix_CPH_Panel1 {
    height: calc(100vh - 400px);
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box " runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="LblHead" runat="server"></asp:Label>
                    </h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Vouchers</a> </li>
                            <li><a href="#" title="">BRS</a> </li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                     <div class="FixedButtons">
      <div class="right_btn">
                 <div class="btn ico-get">
                     <asp:Button ID="btn_get" runat="server" Text="Get" ToolTip="Get" OnClick="btn_get_Click" />
                 </div>
                 <div class="btn ico-view">
                     <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" />
                 </div>

                 <div class="btn ico-confirm-brs" id="btn_confirm1" runat="server">
                     <asp:Button ID="ConfrimBRS" runat="server"  Text="ConfrimBRS" ToolTip="ConfrimBRS" OnClick="ConfrimBRS_Click" />
                 </div>

             </div>
 </div>

                </div>

                <div class="widget-content">
                   
                    <div class="FormGroupContent4">

                        <div class="BrsLEFT">
                            <div class="FormGroupContent4">
                                <%--    <div class="Brs_breakBank" style="display: none;">
                            </div>--%>
                                <div class="BRSCheque">
                                    <asp:Label ID="lblBank" runat="server" Text="Bank" CssClass="LabelValue"></asp:Label>
                                    <asp:DropDownList ID="ddlbank" Data-placeholder="Bank" Height="23px" CssClass="chzn-select" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="USDCHK">
                                    <span class="chktext">US$</span>
                                    <asp:CheckBox ID="chkc" runat="server"></asp:CheckBox>
                                </div>
                                <div class="BRSTxtbox">
                                    <asp:Label ID="lblto" runat="server" Text="To Date"></asp:Label>
                                    <asp:TextBox ID="dtto" runat="server" OnTextChanged="dtto_TextChanged" CssClass="form-control"></asp:TextBox>
                                </div>
                               

                            </div>

                            <div class="FormGroupContent">
                                <div class="BRSBalance">
                                </div>
                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label1" runat="server" Text="Balance as Per Our Book"></asp:Label>
                                    <asp:TextBox ID="txtbook" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                                <div class="CR">
                                    <asp:Label ID="lblourbook" runat="server" Text="Cr" CssClass="LabelValue"></asp:Label>
                                </div>
                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label2" runat="server" Text="(-) Cheque Deposited but not Cleared"></asp:Label>
                                    <asp:TextBox ID="txtreceipt" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                                <div class="BRSBalance1">
                                    <asp:TextBox ID="txt_Receipt" runat="server" Visible="False" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label12" runat="server" Text="Balance"></asp:Label>
                                    <asp:TextBox ID="txttotal" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                                <div class="CR">
                                    <asp:Label ID="lbltolcr" runat="server" Text="Cr"></asp:Label>
                                </div>
                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label4" runat="server" Text="(+) Cheque issued but not Cleared"></asp:Label>
                                    <asp:TextBox ID="txtpayment" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                                <div class="BRSBalancetxt1">
                                    <asp:TextBox ID="txt_contraDB" runat="server" Visible="False" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label5" runat="server" Text="Balance" CssClass="LabelValue"></asp:Label>
                                    <asp:TextBox ID="txttotal1" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                                <div class="CR">
                                    <asp:Label ID="Lbl3" runat="server" Text="Cr" CssClass="LabelValue"></asp:Label>
                                </div>
                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label6" runat="server" Text="(+) Credited by Bank but Not in Our Book"></asp:Label>
                                    <asp:TextBox ID="txtCBNB" runat="server" CssClass="form-control" Style="text-align: right" OnTextChanged="txtCBNB_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label3" runat="server" Text="Balance" CssClass="LabelValue"></asp:Label>
                                    <asp:TextBox ID="txttotal2" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                                <div class="CR">
                                    <asp:Label ID="lbl5" runat="server" Text="Cr" CssClass="LabelValue"></asp:Label>
                                </div>
                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label7" runat="server" Text="(-) Debited by Bank but Not in Our Book" CssClass="LabelValue"></asp:Label>
                                    <asp:TextBox ID="txtDBNB" runat="server" CssClass="form-control" Style="text-align: right" OnTextChanged="txtDBNB_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent">

                                <div class="BRSBalancetxt">
                                    <asp:Label ID="Label8" runat="server" Text="Balance as Per Bank" CssClass="LabelValue"></asp:Label>
                                    <asp:TextBox ID="txtbank" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                </div>
                                <div class="CR">
                                    <asp:Label ID="lblperbank" runat="server" Text="Cr" CssClass="LabelValue"></asp:Label>
                                </div>
                            </div>

                            <div class="FormGroupContent">
                                <div class="ContraDetails1">
                                    <asp:Label ID="Label9" runat="server" Text="Contra Details" CssClass="LabelValue"></asp:Label>
                                </div>

                            </div>
                            <div class="FormGroupContent">
                                <asp:TextBox ID="txtManPay" runat="server" Visible="False"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent">
                                <asp:TextBox ID="txtManRec" runat="server" Visible="False"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent MB10">
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" CssClass="gridpnl">
                                    <asp:GridView ID="grdContra" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="false" OnRowDataBound="grdContra_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                        <Columns>
                                            <asp:BoundField DataField="chequedate" HeaderText="Date" />
                                            <%-- 0--%>
                                            <asp:BoundField DataField="chequeno" HeaderText="Cheque #"><%-- 1--%>
                                                <ItemStyle Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bank" HeaderText="Bank / Branch" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"><%-- 2--%>
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Customer"><%-- 3 --%>
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 180px">
                                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" Width="160px" Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="amount" HeaderText="Amount" Visible="True"><%-- 4--%>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="branch" HeaderText="Branch" />
                                            <%-- 5--%>
                                            <asp:BoundField DataField="Rid" HeaderText="Rid" Visible="False" />
                                            <%--6--%>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                        </div>
                        <div class="BrsRight">
                            <div class="FormGroupContent">
                                <div class="ChkIssued">
                                    <asp:Label ID="lbldeposit" runat="server" Text="Cheque Issued But Not Cleared" ></asp:Label>
                                </div>
                            </div>
                            <div class="FormGroupContent">
                                <asp:Panel ID="grd_panel" runat="server" ScrollBars="Auto" CssClass="panel_10">
                                    <asp:GridView ID="grdPayment" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdPayment_RowDataBound"
                                        ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                        <Columns>
                                            <asp:BoundField DataField="chequedate" HeaderText="IssuedDate" />
                                            <%-- 0--%>
                                            <asp:BoundField DataField="chequeno" HeaderText="Cheque #"><%-- 1 --%>
                                                <ItemStyle Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bank" HeaderText="Bank / Branch" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"><%-- 2 --%>
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Customer"><%-- 3 --%>
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 180px">
                                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" Width="160px" Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="amount" HeaderText="Amount" Visible="True"><%-- 4 --%>
                                                <ItemStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="branch" HeaderText="Branch" Visible="True" />
                                            <%-- 5 --%>
                                            <asp:BoundField DataField="Rid" HeaderText="Rid" Visible="False" />
                                            <%-- 6 --%>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                            <div class="FormGroupContent">
                                <asp:Label ID="Label14" runat="server" Text="Cheque Deposited But Not Cleared" CssClass="LabelValue"></asp:Label>
                            </div>
                            <div class="FormGroupContent">
                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" CssClass="panel_10 MB0">
                                    <asp:GridView ID="GrdReceipt" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="false" OnRowDataBound="GrdReceipt_RowDataBound"
                                        ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                        <Columns>
                                            <asp:BoundField DataField="chequedate" HeaderText="Deposit Date" />
                                            <%-- 0--%>
                                            <asp:BoundField DataField="chequeno" HeaderText="Cheque #"><%-- 1 --%>
                                                <ItemStyle Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bank" HeaderText="Bank / Branch" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"><%-- 2 --%>
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Customer"><%-- 3 --%>
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 180px">
                                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" Width="160px" Wrap="false" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="amount" HeaderText="Amount" Visible="True"><%-- 4 --%>
                                                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="branch" HeaderText="Branch" Visible="True" />
                                            <%-- 5 --%>
                                            <asp:BoundField DataField="Rid" HeaderText="Rid" Visible="False" />
                                            <%-- 6 --%>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>

                            </div>

                            <asp:CalendarExtender ID="to" runat="server" TargetControlID="dtto" Format="dd/MM/yyyy"></asp:CalendarExtender>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel runat="Server" ID="pnlConfirm" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt">
            <center><b>BRS Confirmed Details </b></center>
        </div>
        <br />
        <div class="panel_03 MB0">
            <asp:GridView ID="brsdetail" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="false"
                OnRowDataBound="GrdReceipt_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                <Columns>
                    <asp:BoundField DataField="bankid" HeaderText="BANK ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"><%-- 2 --%>
                        <ItemStyle Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bankname" HeaderText="BANK NAME" />
                    <asp:BoundField DataField="BRSDate" HeaderText="BRS CONFIRMED DATE" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnok" runat="server" Text="Ok" CssClass="Button" OnClick="btnok_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="popupconfirmnew" runat="server" PopupControlID="pnlConfirm" TargetControlID="lbl">
    </asp:ModalPopupExtender>
    <asp:Label ID="lbl" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <div class="div_Break"></div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>BRS #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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

    <asp:Label ID="Label10" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label10" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
