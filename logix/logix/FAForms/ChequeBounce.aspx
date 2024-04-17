<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ChequeBounce.aspx.cs"
    Inherits="logix.FAForm.ChequeBounce" EnableEventValidation="false" %>

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

    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/ChequeBounce.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <%--<script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <style type="text/css">
        .CBReceipt {
            width: 25%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .RightGridView {
            width: 100%;
            height: 300px;
            overflow: auto;
        }

        .CBreceive {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CBBank {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .FormGroupContent4 label {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .CBRight {
            width: 50%;
            float: left;
            margin: 15px 0% 0px 0px;
        }

        .CBCustomer1 {
            width: 69.5%;
            float: left;
            margin: 15px 0.5% 0px 0px;
            text-align: right;
        }

        .CBLeft {
            margin-right: 0.5% !important;
        }

        span#logix_CPH_lbl_voucer {
            padding: 5px 0 0 5px !important;
            display: inline-block;
        }
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
        
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server"></asp:Label></h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Utility</a> </li>
                            <li><a href="#" title="">Cheque Bounce</a> </li>
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
        <div class="btn ico-confirm" id="btn_confirm1" runat="server">
            <asp:Button ID="btn_confirm" runat="server" Text="Confirm Cheque Return" ToolTip="Confirm Cheque Return" OnClick="btn_confirm_Click" Enabled="false" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
        </div>
    </div>
</div>

                </div>
                <div class="widget-content">
                     
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CBChequeNo">

                            <asp:Label ID="lbl_chec" runat="server" Text="Cheque #"></asp:Label>

                            <asp:TextBox ID="txt_Check" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="Cheque #" placeholder="" OnTextChanged="txt_Check_TextChanged"></asp:TextBox>

                        </div>
                        <div class="CBRec">

                            <asp:Label ID="lbl_rec" runat="server" Text="Rec #"></asp:Label>
                            <asp:TextBox ID="txt_rec" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Rec #" placeholder="" OnTextChanged="txt_rec_TextChanged"></asp:TextBox>

                        </div>
                        <div class="CBVou">

                            <asp:Label ID="lbl_vou" runat="server" Text="Vouyear"></asp:Label>

                            <asp:TextBox ID="txt_vou" runat="server" CssClass="form-control" ToolTip="Vouyear" placeholder="" AutoPostBack="true" OnTextChanged="txt_vou_TextChanged"></asp:TextBox>

                        </div>
                        <div class="CBReceipt">

                            <asp:Label ID="lbl_Recei" runat="server" Text="Receipt #"></asp:Label>
                            <asp:TextBox ID="txt_receip" ReadOnly="true" runat="server" ToolTip="Receipt #" CssClass="form-control" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CBreceive">

                            <asp:Label ID="lbl_receive" runat="server" Text="Received From"></asp:Label>
                            <asp:TextBox ID="txt_receiv" runat="server" CssClass="form-control" ReadOnly="true" placeholder=" " ToolTip="Received From"></asp:TextBox>
                        </div>
                        <div class="CBBank">
                            <asp:Label ID="Label2" runat="server" Text="Bank Name"> </asp:Label>
                            <asp:TextBox ID="txt_bank" runat="server" CssClass="form-control" ReadOnly="true" placeholder="" ToolTip="Bank Name"></asp:TextBox>
                        </div>
                        <div class="CBAmountN1">

                            <asp:Label ID="lbl_amount" runat="server" Text="Amount"></asp:Label>
                            <asp:TextBox ID="txt_amount" runat="server" CssClass="form-control" ToolTip="Amount" placeholder="" Style="text-align: right;" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>

                    <div class="CBLeft boxmodal">
                        <div class="FormGroupContent4">
                            <div class="CBCustomer">

                                <asp:Label ID="lbl_customer" runat="server" Text="Customer"></asp:Label>
                                <asp:TextBox ID="txt_customer" ReadOnly="true" runat="server" CssClass="form-control" ToolTip="Customer" placeholder=""></asp:TextBox>
                            </div>
                            <div class="CBAmount">

                                <asp:Label ID="lbl_amoun" runat="server" Text="Customer"></asp:Label>

                                <asp:TextBox ID="txt_amoun" runat="server" CssClass="form-control" ToolTip="Customer" placeholder="" Style="text-align: right;" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="CBCustomer">

                                <asp:Label ID="lbl_dection" runat="server" Text="Deduction"></asp:Label>

                                <asp:TextBox ID="txt_dection" runat="server" ReadOnly="true" CssClass="form-control" ToolTip="Deduction" placeholder=""></asp:TextBox>
                            </div>
                            <div class="CBAmount">

                                <asp:Label ID="lbl_amou" runat="server" Text="Amount"></asp:Label>

                                <asp:TextBox ID="txt_amou" runat="server" ReadOnly="true" CssClass="form-control" ToolTip="Amount" placeholder="" Style="text-align: right;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="CBCustomer1">

                                <div style="display: none;">
                                    <asp:Label ID="txtamoun" runat="server" Text="Amount"></asp:Label>
                                </div>

                            </div>
                            <div class="CBAmount1">
                                <asp:Label ID="lbl_exp" runat="server" Text="Excess(+)/Short(-)"></asp:Label>

                                <asp:TextBox ID="txt_amo" ReadOnly="true" runat="server" CssClass="form-control" ToolTip="Amount" placeholder="" Style="text-align: right;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="CBAmount1">
                                <asp:Label ID="lbl_total" runat="server" Text="Total"></asp:Label>
                                <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" ToolTip="Amount" placeholder="" Style="text-align: right;" ReadOnly="True"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="CBRight boxmodal">
                        <div class="FormGroupContent4">
                            <asp:Label ID="lbl_voucer" runat="server" Text="Voucher Details"></asp:Label>

                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="panel_05 MB0">
                                <asp:GridView ID="div_grid" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="false" EmptyDataText="No Record Found"
                                    class="Grid FixedHeader" OnRowDataBound="div_grid_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="port" HeaderText="Branch">
                                            <ItemStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vouno" HeaderText="Vou #">
                                            <ItemStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vamount" HeaderText="InvAmt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="tamount" HeaderText="Recpt-Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle Width="25%" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="voutype" HeaderText="">
                            <ItemStyle Width="25%" HorizontalAlign="Right" />
                        </asp:BoundField>
                         <asp:BoundField DataField="vouyear" HeaderText="Recpt-Amt">
                            <ItemStyle Width="25%" HorizontalAlign="Right" />
                        </asp:BoundField>
                         <asp:BoundField DataField="ravouyear" HeaderText="Recpt-Amt">
                            <ItemStyle Width="25%" HorizontalAlign="Right" />
                        </asp:BoundField>
                          <asp:BoundField DataField="jrefno" HeaderText="Recpt-Amt">
                            <ItemStyle Width="25%" HorizontalAlign="Right" />
                        </asp:BoundField>
                         <asp:BoundField DataField="jltype" HeaderText="Recpt-Amt">
                            <ItemStyle Width="25%" HorizontalAlign="Right" />
                        </asp:BoundField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CBRemarks">

                            <asp:Label ID="Label1" runat="server" Text="Remarks"></asp:Label>
                            <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control" ToolTip="Remarks" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                   
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_AlertMsg" runat="server" />
    <asp:HiddenField ID="hid_year" runat="server" />
    <asp:HiddenField ID="Rptype" runat="server" />
    <asp:HiddenField ID="hid_receiptid" runat="server" />
    <asp:HiddenField ID="hid_receiptno" runat="server" />
    <asp:HiddenField ID="hid_recdate" runat="server" />
    <asp:HiddenField ID="hid_custid" runat="server" />
    <asp:HiddenField ID="hid_Amt" runat="server" />
    <asp:HiddenField ID="hid_bankid" runat="server" />
    <asp:HiddenField ID="hid_bbranch" runat="server" />
    <asp:HiddenField ID="hid_chqdt" runat="server" />
    <asp:HiddenField ID="hid_dtCuschrgBranch" runat="server" />
    <asp:HiddenField ID="hid_dtCuschrgAmt" runat="server" />
    <asp:HiddenField ID="hid_strvouno" runat="server" />
    <script type="text/javascript">
        function closingamount() {
            alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Issue the Payment');
        }
    </script>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>ChequeBounce #</label>

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

    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
