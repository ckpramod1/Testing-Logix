<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CNInvAdjustmentOSDN.aspx.cs" Inherits="logix.FAForm.CNInvAdjustmentOSDN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- Theme -->
  
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
    <link href="../Styles/CNInvAdjustmentOSDN.css" rel="stylesheet" />
    <style type="text/css">
        .Hide {
            display: none;
        }

        .VocherTypeIV {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherDrop {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherCN {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherDate {
            width: 5%;
            float: left;
            margin: 0px 0% 0px 0px;
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

        .Grid2 {
            border: 0px solid #b1b1b1;
            height: 280px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
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
        
/* FixedHeader */

 .widget.box{
    position: relative;
    top: -8px;
}
  div#UpdatePanel1 {
    height: fit-content;
    overflow-x: hidden;
    overflow-y: auto;
}
   
  .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
  .VoucherAmount.TextField span,.GridTxtbox.TextField span {
    text-align: right;
}
 </style>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

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

    <%--script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });

        }

    </script>--%>
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
            <li><a href="#" title="">Invoice/CN Operation - CN/DN Adjustment  </a></li>
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
                                <asp:Button ID="btn_save" Text="Save" runat="server" ToolTip="Save" OnClick="btn_save_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />

                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" Text="Cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">                       
                        <div class="VoucherDrop">
                            <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Type"></asp:Label>
                            <asp:DropDownList ID="ddl_voucher" runat="server" CssClass="chzn-select" data-placeholder="Voucher Type" AutoPostBack="True" OnSelectedIndexChanged="ddl_voucher_SelectedIndexChanged">
                                <asp:ListItem Value="A" Text=""></asp:ListItem>
                                <asp:ListItem Value="E">CN</asp:ListItem>
                                <asp:ListItem Value="C">OSCN</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="VoucherCN">
                          
                                <asp:Label ID="lbl_receipt" runat="server" Text="Vou #"></asp:Label>

                            <asp:TextBox ID="txt_receipt" runat="server" CssClass="form-control" ToolTip="Vou #" placeholder="" AutoPostBack="True"
                                OnTextChanged="txt_receipt_TextChanged"></asp:TextBox>

                        </div>
                        <div class="VoucherDate">
                                <asp:Label ID="Label1" runat="server" Text="Year"></asp:Label>

                            <asp:TextBox ID="txt_year" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="VoucherCustomer">
                           
                                <asp:Label ID="lbl_receivedfrom" runat="server" Text="Customer"></asp:Label>
                            <asp:TextBox ID="txt_received" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Customer" placeholder=""></asp:TextBox>
                        </div>
                        <div class="VoucherAmount">
                          
                                <asp:Label ID="lbl_amount" runat="server" Text="Amount"></asp:Label>
                            <asp:TextBox ID="txt_amount" runat="server" ReadOnly="True" Style="text-align: right" CssClass="form-control" ToolTip="Amount" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <asp:Panel ID="panel_details" runat="server" ScrollBars="Vertical" CssClass="gridpnl MB0">
                            <asp:GridView ID="Grd_detail" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="Grd_detail_RowCommand"
                                ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" DataKeyNames="tamount" OnRowDataBound="Grd_detail_RowDataBound" OnSelectedIndexChanged="Grd_detail_SelectedIndexChanged"  OnPreRender="Grd_detail_PreRender">

                                <Columns>
                                    <asp:BoundField DataField="branchid" HeaderText="Branch" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"></asp:BoundField>
                                    <asp:BoundField DataField="branch" HeaderText="Branch">
                                        <HeaderStyle  Wrap="true"  />
                                        <ItemStyle  Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                                        <HeaderStyle  Wrap="true" Width="150px" />
                                        <ItemStyle  Wrap="true" Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="curr" HeaderText="Curr">
                                        <HeaderStyle  Wrap="true" Width="150px"/>
                                        <ItemStyle Wrap="true" Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fcamt" HeaderText="FCAmt" DataFormatString="{0:#,##0.00}" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1">

                                        <HeaderStyle  Wrap="true" Width="150px"/>
                                        <ItemStyle  Wrap="true" CssClass="TxtAlign1" Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="exrate" HeaderText="ExRate" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle  Wrap="false" CssClass="TxtAlign1" Width="150px"/>
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="vamount" HeaderText="VouAmt(Rs)" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right"  Wrap="false" CssClass="TxtAlign1" Width="150px"/>
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Adj-Fc">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_receiptamount" runat="server" Text='<%#Bind("recptfcamt") %>' AutoPostBack="true"
                                                Style="text-align: right;" CssClass="form-control" OnTextChanged="txt_receiptamount_TextChanged"></asp:TextBox>

                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Right"  Wrap="false" Width="150px"/>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="tamount" HeaderText="Adj INR-Amt(RS)" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle Width="150px" Wrap="false" CssClass="TxtAlign1" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="voutype" HeaderText="VoyType" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vouno" HeaderText="vouno" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tds" HeaderText="tdsamt" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ravouyear" HeaderText="RAVouYear" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ltype" HeaderText="ledtype" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="customerid" HeaderText="Customer Id" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <%--  <HeaderStyle CssClass="Hide" />
                          <ItemStyle CssClass="Hide" Wrap="false"  />--%>
                                    </asp:BoundField>
                                    <%-- <asp:BoundField DataField="voudate" HeaderText="Vou Date">
                            <HeaderStyle Width="9%" Wrap="true" />
                            <ItemStyle Width="9%"  Wrap="true" />
                        </asp:BoundField>--%>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />

                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div class="FormGroupContent4">

                        <div class="GridTxtbox">
                            <asp:Label ID="Label2" runat="server" Text="Amount" CssClass="Hide"> </asp:Label>
                            <asp:TextBox ID="txt_AdjAmt" runat="server" Style="text-align: right" CssClass="form-control" placeholder="" ToolTip="Amount"></asp:TextBox></div>
                    </div>
                    </div>

                  
                </div>

            </div>
        </div>
    </div>

    <div class="div_Break">
        <asp:HiddenField ID="hid_gridname" runat="server" />
    </div>
    <asp:HiddenField ID="hid_DNamt" runat="server" />
    <asp:HiddenField ID="hid_grdfamt" runat="server" />
    <asp:HiddenField ID="hid_grdexr" runat="server" />
    <asp:HiddenField ID="hid_grdcur" runat="server" />

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

    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
