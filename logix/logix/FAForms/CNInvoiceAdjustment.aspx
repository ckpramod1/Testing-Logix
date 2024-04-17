<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="CNInvoiceAdjustment.aspx.cs" EnableEventValidation="false" Inherits="logix.FAForm.CNInvoiceAdjustment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> 
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

    <link href="../Styles/CNInvoiceAdjustment.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".Text").blur(function () {
                    $("Text").change();
                });
            });
        }

    </script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <%--  <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>   --%>

    <style type="text/css">
        .Grid2 {
            border: 0px solid #b1b1b1;
            height: 300px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .row {
            clear: both;
            width: 100%;
            height: 580px !important;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .VoucherDrop {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherCN {
            width: 6.5%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherCustomer {
            width: 87.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherAmount {
            width: 12%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .VocherTypeIV {
            width: 6%;
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
       .GridTxtbox {
    width: 12%;
    float: right;
    margin: 0px 0% 0px 0px;
}
       .widget.box{
    position: relative;
    top: -8px;
}
.VoucherDate {
    width: 5%;
    float: right;
    margin: 0px 0% 0px 0px;
}
 

.widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
.VoucherAmount.TextField span {
    text-align: right;
}
.GridTxtbox.TextField span {
    text-align: right;
}
    </style>

    <script type="text/javascript">
        function disableBtn(btnID, newText) {
            //initialize to avoid 'Page_IsValid is undefined' JavaScript error
            Page_IsValid = null;
            //check if the page request any validation
            // if yes, check if the page was valid
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                //you can pass in the validation group name also
            }
            //variables
            var btn = document.getElementById(btnID);
            var isValidationOk = Page_IsValid;
            /********NEW UPDATE************************************/
            //if not IE then enable the button on unload before redirecting/ rendering
            if (navigator.appName !== 'Microsoft Internet Explorer') {
                EnableOnUnload(btnID, btn.value);
            }
            /***********END UPDATE ****************************/
            // isValidationOk is not null
            if (isValidationOk !== null) {
                //page was valid
                if (isValidationOk) {
                    btn.disabled = true;
                    btn.value = newText;
                    btn.style.background = 'url(~/images/ajax-loader.gif)';
                }
                else {//page was not valid
                    btn.disabled = false;
                }
            }
            else {//the page don't have any validation request
                setTimeout("setImage('" + btnID + "')", 10);
                btn.disabled = true;
                btn.value = newText;
            }
        }

        //set the background image of the button
        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(images/Loading.gif)';
        }

        //enable the button and restore the original text value
        function EnableOnUnload(btnID, btnText) {
            window.onunload = function () {
                var btn = document.getElementById(btnID);
                btn.disabled = false;
                btn.value = btnText;
                
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Invoice/CN Operation - CN/DN Adjustment"></asp:Label>
                    </h4>
                      <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
            <li><a href="#" title="">Invoice/CN Operation - CN/DN Adjustment </a></li>
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
                            <div class="btn ico-save">
                                <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="VoucherDrop">
                            <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Type"></asp:Label>
                            <asp:DropDownList ID="ddl_voucher" CssClass="chzn-select" data-placeholder="Voucher Type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_voucher_SelectedIndexChanged">
                                <asp:ListItem Text=""></asp:ListItem>
                                <asp:ListItem Value="E">Credit Note</asp:ListItem>
                                <asp:ListItem Value="S">Admin Purchase Invoice</asp:ListItem>
                                <asp:ListItem Value="P">Purchase Invoice</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="VoucherDate">
                            <asp:Label ID="Label1" runat="server" Text="Year"> </asp:Label>
                            <asp:TextBox ID="txt_year" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="VoucherCN">
                            <asp:Label ID="lbl_receipt" runat="server" Text="Vou #"></asp:Label>
                            <asp:TextBox ID="txt_receipt" runat="server" CssClass="form-control" ToolTip="Vou #" placeholder="" AutoPostBack="True"
                                OnTextChanged="txt_receipt_TextChanged"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="VoucherCustomer">
                            <asp:Label ID="lbl_receivedfrom" runat="server" Text="Customer"></asp:Label>
                            <asp:TextBox ID="txt_received" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Customer" placeholder=""></asp:TextBox>

                        </div>
                        <div class="VoucherAmount">
                            <asp:Label ID="lbl_amount" runat="server" Text="Amount"></asp:Label>
                            <asp:TextBox ID="txt_amount" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Amount" placeholder="" Style="text-align: right"></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent boxmodal">
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_lg" runat="server" CssClass="gridpnl MB0" ScrollBars="Vertical">
                            <asp:GridView ID="Grd_detail" runat="server" AutoGenerateColumns="False" Width="100%"
                                ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" CssClass="Grid FixedHeader" DataKeyNames="branch,voutype,vouno,ravouyear,tds" OnPreRender="Grd_detail_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="port" HeaderText="Branch">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                                        <ItemStyle Width="150px"/>
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="iamount" HeaderText="Voucher-Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Adjustment-Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_receiptamount" runat="server" Text='<%# Eval("ramount") %>'
                                                Style="text-align: right; width: 100px;" onkeyup="IsDoubleCheck_Grid(this);" AutoPostBack="true" OnTextChanged="txt_receiptamount_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                        <HeaderStyle Width="150px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="GridTxtbox">
                            <asp:Label ID="Label2" runat="server" Text="Amount" CssClass="hide"> </asp:Label>
                            <asp:TextBox ID="txt_tdsamount" runat="server" Style="text-align: right" ToolTip="Amount" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                        </div>
                   

                </div>
            </div>

            <asp:HiddenField ID="hid_receiptid" runat="server" />
            <asp:HiddenField ID="hid_customerid" runat="server" />
            <asp:HiddenField ID="hid_amount" runat="server" />
            <asp:HiddenField ID="hid_Vouamount" runat="server" />

            <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                <div class="divRoated">
                    <div class="LogHeadLbl">
                        <div class="LogHeadJob">
                            <label>Ledger #</label>

                        </div>
                        <div class="LogHeadJobInput">

                            <asp:Label ID="JobInput" runat="server"></asp:Label>

                        </div>

                    </div>
                    <div class="DivSecPanel">
                        <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                    </div>

                    <asp:Panel ID="Panel4" runat="server" CssClass="Gridpnl">

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

        <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
