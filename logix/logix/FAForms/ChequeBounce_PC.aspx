<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ChequeBounce_PC.aspx.cs"
    Inherits="logix.FAForm.ChequeBounce_PC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->
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
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

    <link href="../Styles/ChequeBounce.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .FloatRigth4 span {
            font-size: 11px;
            margin: -6px 0px 0px 0px;
            display: inline-block;
        }

        .Grid5 {
            border: 1px solid #b1b1b1;
            height: 138px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .ReceiptNumber1 {
            float: left;
            width: 7%;
            margin: 0px 0.5% 0px 0px;
        }

        .Vouyear {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 4.5%;
        }

        .ReceivedFrom {
            width: 54%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BranchDrop7 {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 11%;
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
            .FloatRigth4 {
    float: left;
    width: 50%;
    margin: 10px 0% 0px 0px;
}
.widget.box .widget-content {
    top: 55px !important;
}
.Excess {
    float: right;
    width: 23%;
    margin: 0px 0% 0px 0px;
}
.Amount10 {
    float: right;
    width: 23%;
    margin: 0px 0% 0px 0px;
}
.Customer1 {
    float: left;
    width: 76.5%;
    margin: 0px 0.5% 0px 0px;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

  


    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="ChequeBounce"></asp:Label></h4>
                      <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Vouchers</a> </li>
            <li><a href="#" title="">Payment Cancel</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                                        <div class="FixedButtons" >
    <div class="right_btn">

        <div class="btn ico-delete" id="btn_confirm1" runat="server">
            <asp:Button ID="btn_confirm" runat="server" Text="Delete" ToolTip="Confirm Cheque Return" Enabled="false" OnClick="btn_confirm_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
        </div>
    </div>
</div>

                </div>
                <div class="widget-content">
                     
                    <div class="FormGroupContent4">
                        <div class="BranchDrop7">
                            <asp:DropDownList ID="ddl_branch" Height="23px" runat="server" AutoPostBack="true" CssClass="chzn-select" ToolTip="Branch" Placeholder="Branch" AppendDataBoundItems="true"></asp:DropDownList>
                        </div>
                        <div class="CheQueNumber">
                            <asp:TextBox ID="txt_cheque" runat="server" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_cheque_TextChanged" placeholder="Cheque Number" ToolTip="Cheque Number" TabIndex="1"></asp:TextBox>
                        </div>
                        <div class="ReceiptNumber1">
                            <asp:TextBox ID="txt_receipt" runat="server" CssClass="form-control" placeholder="Receipt #" ToolTip="Receipt Number" AutoPostBack="true" TabIndex="2" OnTextChanged="txt_receipt_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Vouyear">   
                            <asp:TextBox ID="txt_Vouyear" runat="server" CssClass="form-control" placeholder="Vouyear" ToolTip="Vouyear" TabIndex="4" AutoPostBack="true" OnTextChanged="txt_Vouyear_TextChanged"></asp:TextBox>
                        </div>

                        <div class="ReceivedFrom">
                            <asp:TextBox ID="txt_received" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Received From" ToolTip="Received From" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="Amount9">
                            <asp:TextBox ID="txt_amount" runat="server" Style="text-align: right" ReadOnly="True" CssClass="form-control" placeholder="Amount" ToolTip="Amount" TabIndex="4"></asp:TextBox>
                        </div>
                    </div>

                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">
                        <div class="FloatLeft2">
                            <div class="Customer1">
                                <asp:TextBox ID="txt_customer" runat="server" CssClass="form-control" ReadOnly="True" placeholder="Customer" ToolTip="Customer" TabIndex="5"></asp:TextBox>
                            </div>
                            <div class="Amount10">
                                <asp:TextBox ID="txt_customeramount" runat="server" Style="text-align: right;" CssClass="form-control" ReadOnly="True" placeholder="Amount" ToolTip="Amount" TabIndex="6"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="Customer1">
                                    <asp:TextBox ID="txt_deduction" runat="server" CssClass="form-control" ReadOnly="True" placeholder="Deduction" ToolTip="Deduction" TabIndex="7"></asp:TextBox>
                                </div>
                                <div class="Amount10">
                                    <asp:TextBox ID="txt_deductionamount" runat="server" Style="text-align: right;" CssClass="form-control" ReadOnly="True" placeholder="Amount" ToolTip="Amount" TabIndex="8"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="Excess">
                                    <asp:TextBox ID="txt_shortamount" runat="server" CssClass="form-control" Style="text-align: right;" ReadOnly="True" placeholder="Excess (+) / Short (-)" ToolTip="Excess (+) / Short (-)" TabIndex="9"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="Amount10">
                                    <asp:TextBox ID="txt_total" runat="server" Style="text-align: right;" ReadOnly="True" CssClass="form-control" placeholder="Total" ToolTip="Total" TabIndex="10"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="FloatRigth4">

                            <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Detail"  CssClass="LabelValue"></asp:Label>

                            <asp:Panel ID="branch" runat="server" CssClass="panel_05 MB0">

                                <asp:GridView ID="Grd_detail" runat="server" AutoGenerateColumns="False" Width="100%"
                                    ShowHeaderWhenEmpty="True" class="Grid FixedHeader" DataKeyNames="branch" OnRowDataBound="Grd_detail_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="port" HeaderText="Branch">
                                            <ItemStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                                            <ItemStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="iamount" HeaderText="VouAmt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ramount" HeaderText="Recpt-Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" Width="25%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>
                    </div>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">
                        <asp:TextBox ID="txt_refno" runat="server" CssClass="form-control" placeholder="Remarks" ToolTip="Remarks" TabIndex="11"></asp:TextBox>
                    </div>
                 
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_receiptid" runat="server" />
    <asp:HiddenField ID="hid_receiptno" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_year" runat="server" />
    <asp:HiddenField ID="hid_customerid" runat="server" />
    <asp:HiddenField ID="hid_amount" runat="server" Value="0" />
    <asp:HiddenField ID="hid_Chkbranchid" runat="server" />
    <asp:HiddenField ID="hid_Branch" runat="server" />
    <asp:HiddenField ID="hid_bankid" runat="server" />
    <asp:HiddenField ID="hid_chequedate" runat="server" />
    <asp:HiddenField ID="hid_CAmount" runat="server" Value="0" />
    <asp:HiddenField ID="hid_DAmount" runat="server" Value="0" />
    <asp:HiddenField ID="hid_SAmount" runat="server" Value="0" />
    <asp:HiddenField ID="hid_Total" runat="server" Value="0" />
    <asp:HiddenField ID="hid_RAmount" runat="server" Value="0" />
    <asp:HiddenField ID="hid_AlertMsg" runat="server" />


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Payment Cancel #</label>

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


    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hid_Groupid" runat="server" />
</asp:Content>
