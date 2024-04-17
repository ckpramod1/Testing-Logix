<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="OnAccount.aspx.cs" Inherits="logix.FAForm.OnAccToAgainsVou" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/OnAccount.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

            });
            $(document).ready(function () {
                $("#<%=txt_received.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../FAForms/OnAccount.aspx/GetCust",
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

                            },
                            failure: function (response) {

                            }
                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_received.ClientID %>").val(i.item.label);
                        $("#<%=txt_received.ClientID %>").change();
                        $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_received.ClientID %>").val(i.item.label);
                        $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_received.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_received.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_received.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
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

    <style type="text/css">
        .ReceiptACInput {
            width: 10.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .btn-ctrl1 {
            float: right;
            margin: 0px 0px 0px 0px;
            width: 60%;
        }

        .ReceiptAmount {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ReceivedFrom {
               width: 48.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        }

        .YearAc {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TDSAC {
            width: 57.5%;
            float: right;
            margin: -5px 0% 0px 0px;
        }

        .TDSAmount {
            width: 33%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        .Branch-btn {
            margin: 0px 5px 5px 0px;
            float: right;
        }

        .Cancel-btn {
            margin: 0px 0px 0px 0px;
            float: right;
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
            margin: 2px 0.5% 0px 10px;
            white-space: nowrap;
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

        .Receipt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .CustomerAC {
            width: 11%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        .AdjAmount {
            float: right;
            margin: 0px 0px 0px 0.5%;
            width: 10%;
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

        .DateInput1 {
                width: 7%;
    float: right !important;
    margin: 0px 0% 0px 0px;
        }
        span#logix_CPH_lbl_voucher {
    display: inline-block;
    margin: 11px 0px 0px 0px;
}
        .TDSAC {
            width: 96.5%;
            float: right;
            /*margin: 0px 0% 0px 0px;*/
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
 
  
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
        .CustomerAC span,.AdjAmount span,.AdjAmount span,.TDSAC span{
            text-align:right;
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
                        <asp:Label ID="lbl_Header" runat="server" Text="OnAccount To Against Voucher"></asp:Label>
                    </h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Utility</a> </li>
                            <li><a href="#" title="">OnAccount To Against Voucher </a></li>
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
        <div class="btn ico-update">
            <asp:Button ID="btn_update" Text="Update" runat="server" ToolTip="Update" OnClick="btn_update_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="false" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
        </div>

    </div>
</div>

                </div>

                <div class="widget-content">
                      
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ModeAc">
                            <asp:Label ID="lbl_mode" runat="server" Text="Mode" Visible="false"></asp:Label>

                        </div>
                        <div class="Receipt">
                            <asp:Label ID="Label1" runat="server" Text="Voucher"> </asp:Label>
                            <asp:DropDownList ID="ddl_receipt" runat="server" CssClass="chzn-select" data-placeholder="Voucher" AutoPostBack="true" OnSelectedIndexChanged="ddl_receipt_SelectedIndexChanged">
                                <asp:ListItem Value="">Voucher</asp:ListItem>
                                <asp:ListItem>Receipt</asp:ListItem>
                                <asp:ListItem>Payment</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="ModeAcDrop">
                            <asp:Label ID="Label2" runat="server" Text="Mode"> </asp:Label>
                            <asp:DropDownList ID="ddl_module" Height="23" runat="server" ToolTip="Mode" CssClass="chzn-select" data-placeholder="Mode" AutoPostBack="true" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged" OnTextChanged="ddl_module_TextChanged">
                                <asp:ListItem Value="">Mode</asp:ListItem>
                                <asp:ListItem Value="C">Cash</asp:ListItem>
                                <asp:ListItem Value="B">Cheque/DD</asp:ListItem>
                            </asp:DropDownList>

                        </div>

                        <div class="ReceiptACInput">

                            <asp:Label ID="lbl_receipt" runat="server" Text="Receipt#"></asp:Label>

                            <asp:TextBox ID="txt_receipt" CssClass="form-control" runat="server" AutoPostBack="True"
                                OnTextChanged="txt_receipt_TextChanged"></asp:TextBox>
                        </div>
                        <div class="YearAc">
                            <asp:Label ID="Label3" runat="server" Text="Year"> </asp:Label>
                            <asp:TextBox ID="txt_year" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="ReceiptAmount">

                            <asp:Label ID="lbl_amount" runat="server" CssClass="" Text="Recepit Amount"></asp:Label>

                            <asp:TextBox ID="txt_amount" CssClass="form-control" runat="server" Style="text-align: right"
                                ReadOnly="True"></asp:TextBox>

                        </div>
                        <div class="ReceivedFrom">

                            <asp:Label ID="lbl_receivedfrom" runat="server" Text="Received From"></asp:Label>

                            <asp:TextBox ID="txt_received" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_received_TextChanged"></asp:TextBox>
                        </div>

                        <div class="DateInput1 DateR">
                            <asp:Label ID="lbl_date" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">
                            <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Details"></asp:Label>

                        </div>
                        <div class="FormGroupContent4">
                            <asp:Panel ID="pnl_lg" runat="server" CssClass="gridpnl MB0" ScrollBars="Vertical">
                                <asp:GridView ID="Grd_detail" runat="server" AutoGenerateColumns="False" Width="100%"
                                    ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" class="Grid FixedHeader"
                                    DataKeyNames="branch,voutype,vouno,ravouyear" OnCellContentClick="Grd_detail_CellContentClick"
                                    OnRowDataBound="Grd_detail_RowDataBound" OnPreRender="Grd_detail_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="port" HeaderText="Branch">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="invoiceno" HeaderText="Vou #" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="iamount" HeaderText="VouAmt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Recpt-Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_receiptamount" runat="server" Text='<%# Eval("ramount") %>' Style="text-align: right; width: 100px;"
                                                    OnTextChanged="txt_receiptamount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RecpFc" HeaderStyle-Font-Size="10pt">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chkrecpfc" runat="server" AutoPostBack="true" OnCheckedChanged="Chkrecpfc_CheckedChanged" />
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="10px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="vouyear" HeaderText="Vouyear" HeaderStyle-Width="100px" ItemStyle-Width="100px"><%--HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"--%>
                                            <ItemStyle />
                                            <%--CssClass="hidden"--%>
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="right_btn">
                            <div class="TDSAC">
                                <asp:Label ID="lbl_tdsamount" runat="server" Text="TDS Amount"></asp:Label>
                                <asp:TextBox ID="txt_tdsamount" runat="server" CssClass="form-control" Style="text-align: right" AutoPostBack="true" OnTextChanged="txt_tdsamount_TextChanged1"></asp:TextBox>

                            </div>

                        </div>

                        <div class="AdjAmount">
                            <asp:Label ID="Label5" runat="server" Text="Excess Amount"> </asp:Label>
                            <asp:TextBox ID="txt_excess" runat="server" Enabled="false" CssClass="form-control" Style="text-align: right" placeholder="" ToolTip="Excess Amount"></asp:TextBox>

                        </div>
                        <div class="AdjAmount" style="width:12%;" > 
                            <asp:Label ID="Label4" runat="server" Text="Adjustable Amount"> </asp:Label>
                            <asp:TextBox ID="txt_adj_amount" CssClass="form-control" ToolTip="Adjustable Amount" placeholder="" runat="server" Style="text-align: right"
                                ReadOnly="True"></asp:TextBox>

                        </div>
                        <div class="AdjAmount">
                            <asp:Label ID="Label7" runat="server" Text="Adj.On Account"> </asp:Label>
                            <asp:TextBox ID="txt_adjonaccount" runat="server" Enabled="false" CssClass="form-control" Style="text-align: right" placeholder="" ToolTip="Adj.On Account"></asp:TextBox>

                        </div>
                        <div class="AdjAmount">
                            <asp:Label ID="Label6" runat="server" Text="On Account"> </asp:Label>
                            <asp:TextBox ID="txt_onaccount" runat="server" Enabled="false" CssClass="form-control" Style="text-align: right" placeholder="" ToolTip="On Account"></asp:TextBox>

                        </div>
                        <div class="CustomerAC">

                            <asp:Label ID="lbl_custometamount" runat="server" Text="Customer Amount"></asp:Label>

                            <asp:TextBox ID="txt_custamount" CssClass="form-control" ToolTip="Customer Amount" placeholder=" " runat="server" Style="text-align: right"
                                ReadOnly="True"></asp:TextBox>

                        </div>

                    </div>

                  
                </div>

            </div>
        </div>
    </div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_no" runat="server">OnAccount</label>

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

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_receiptid" runat="server" />
    <asp:HiddenField ID="hid_customerid" runat="server" />
    <asp:HiddenField ID="hid_amount" runat="server" />
    <asp:HiddenField ID="hid_rptid" runat="server" />

    <asp:HiddenField ID="hid_panno" runat="server" />


    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" Format="dd/MM/yyyy"></asp:CalendarExtender>
</asp:Content>
