<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="Query.aspx.cs" Inherits="logix.FAForm.Query" EnableEventValidation="false" %>

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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%--   <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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

    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/Query.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_ledger.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_LedgerId.ClientID %>").val(0);
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetLikeLedgerName",
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
                        $("#<%=txt_ledger.ClientID %>").val(i.item.label);
                        $("#<%=txt_ledger.ClientID %>").change();
                        $("#<%=hid_LedgerId.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_ledger.ClientID %>").val(i.item.label);
                        $("#<%=hid_LedgerId.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_ledger.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_ledger.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_cheque.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_cheque.ClientID %>").val(0);
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetLikePRCchqno",
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
                        $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                        $("#<%=txt_cheque.ClientID %>").change();
                        $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                        $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                        $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <style type="text/css">
        .Grid2 {
            border: 0px solid #b1b1b1;
            height: 350px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

    
 

        .div_close {
            float: right;
        }

        .AmountQuery input {
            text-align: right;
        }

        .widget-content {
            padding: 0 10px !important;
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
            color: #000080;
            font-size: 11px;
        }

        .FormGroupContent4 label {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .btn-ctrl1 {
            float: right;
            margin: 20px 0px 0px 0px;
        }

        /* FixedHeader */

        .widget.box {
            position: relative;
            top: -8px;
        }

        .AmountQuery {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AmountEqual {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .NarationQuery {
            width: 67%;
            float: left;
            margin: 0px 0% 0px 0px;
        }
 
        div#logix_CPH_pnl_lg tbody tr td:nth-child(3) {
    text-align: left !important;
}
        .QueryFinput {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .QueryToUnput {
    width: 8%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .LedgerQuery {
    width: 42%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .right_btn {
    float: right;
    margin: 10px 0px 0px 0px;
}
        div#logix_CPH_tocal_container {
    left: -69px !important;
}
        div#logix_CPH_ddl_Voutype_chzn {
    width: 100% !important;
}
        .VouQuery {
    width: 17% !important;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        div#logix_CPH_ddl_amttype_chzn {
    width: 100% !important;
}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Query"></asp:Label></h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Query</a> </li>
                            <li><a href="#" title="">Query</a> </li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>

                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal" style="margin-top:25px !important;" >
                        <div class="AmountQuery">

                            <asp:Label ID="lbl_amt" runat="server" Text="Amount"></asp:Label>
                            <asp:TextBox ID="txt_amt" runat="server" ToolTip="Amount" placeholder="" OnTextChanged="txt_amt_TextChanged" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="AmountEqual">
                            <asp:Label ID="Label1" runat="server" Text="Amt Type"> </asp:Label>
                            <asp:DropDownList ID="ddl_amttype" runat="server" Height="23" ToolTip="Equal" CssClass="chzn-select" placeholder="Equal" OnSelectedIndexChanged="ddl_amttype_SelectedIndexChanged">
                                <asp:ListItem Value="Equal">Equal</asp:ListItem>
                                <asp:ListItem Value="Greater">Greater</asp:ListItem>
                                <asp:ListItem Value="Lesser">Less</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="NarationQuery">

                            <asp:Label ID="lbl_nrt" runat="server" Text="Narration" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_nrt" runat="server" CssClass="form-control" ToolTip="Narration" placeholder="" OnTextChanged="txt_nrt_TextChanged"></asp:TextBox>
                        </div>

                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div class="ChequeQuery">

                            <asp:Label ID="lbl_checque" Text="Cheque No." runat="server" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_cheque" runat="server" ToolTip="Cheque No." placeholder="" OnTextChanged="txt_cheque_TextChanged" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="VouQuery">

                            <asp:Label ID="lbl_Voutype" runat="server" Text="VouType" CssClass="LabelValue"></asp:Label>
                            <asp:DropDownList ID="ddl_Voutype" Height="23" runat="server" AppendDataBoundItems="True" ToolTip="VouType" placeholder="VouType" OnSelectedIndexChanged="ddl_Voutype_SelectedIndexChanged" AutoPostBack="True" CssClass="chzn-select">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LedgerQuery">

                            <asp:Label ID="lbl_ledger" runat="server" Text="Ledger Name" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_ledger" runat="server" ToolTip="Ledger Name" placeholder="" OnTextChanged="txt_ledger_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                        </div>

                        <div class="QueryFinput">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" ToolTip="From"></asp:TextBox>
                        </div>

                        <div class="QueryToUnput">
                            <asp:Label ID="lbl_to" runat="server" Text="To" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" ToolTip="To"></asp:TextBox>
                        </div>
                        <div class="right_btn">
                            <div class="btn ico-get">
                                <asp:Button ID="btn_get" runat="server" Text="Get" ToolTip="Get" OnClick="btn_get_Click" />
                            </div>
                            <div class="btn ico-back" id="btn_back1" runat="server">
                                <asp:Button ID="btn_back" runat="server" Text="Back" ToolTip="Back" OnClick="btn_back_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="pnl_lg" runat="server" CssClass="gridpnl MB0" ScrollBars="Vertical">
                            <asp:GridView ID="grd_query" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" OnRowDataBound="grd_query_RowDataBound"
                                Width="100%" OnSelectedIndexChanged="grd_query_SelectedIndexChanged" DataKeyNames="voutypeid" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grd_query_PreRender">
                                <Columns>
                                    <asp:BoundField HeaderText="VouType" DataField="voutypename">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Product" DataField="trantype">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Vou #" DataField="vouno">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Vou Date" DataField="voudate">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cheque #" DataField="chequeno">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Particular" DataField="ledgername">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount" DataField="ledgeramount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="FormGroupContent4">
        <asp:Panel ID="pln_Query" runat="server" Width="100%" Style="display: none;" CssClass="modalPopup" >
            <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Close" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
         
            <div class="">
                <iframe id="iframeQuery" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF"></iframe>
            </div>
                </div>
        </asp:Panel>
    </div>

    <asp:ModalPopupExtender ID="pln_Grd" runat="server" PopupControlID="pln_Query" TargetControlID="lbl_hid"
        BackgroundCssClass="modalBackground" CancelControlID="close">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hid_LedgerId" runat="server" Value="" />
    <asp:HiddenField ID="hid_cheque" runat="server" Value="" />
    <asp:HiddenField ID="hid" runat="server" />
    <asp:CalendarExtender ID="fromcal" runat="server" TargetControlID="txt_from" Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="tocal" runat="server" TargetControlID="txt_to" Format="dd/MM/yyyy"></asp:CalendarExtender>

    <asp:Label ID="lbl_hid" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Query #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
                    BackColor="White" OnPreRender="GridViewlog_PreRender">
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
