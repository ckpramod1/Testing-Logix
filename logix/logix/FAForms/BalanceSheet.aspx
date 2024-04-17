<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BalanceSheet.aspx.cs" Inherits="logix.FAForm.BalanceSheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BalanceSheet.css" rel="Stylesheet" type="text/css" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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

    <script type="text/javascript">
        $(function () {
            $(".grd_blncsheet > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".grd_blncsheet td").removeClass("highlite");
                    var $cell = $(e.target).closest("td");
                    $cell.addClass('highlite');
                    var $currentCellText = $cell.text();
                    var $leftCellText = $cell.prev().text();
                    var $rightCellText = $cell.next().text();
                    var $colIndex = $cell.parent().children().index($cell);
                    var $colName = $cell.closest("table")
                        .find('th:eq(' + $colIndex + ')').text();
                    $("#para").empty()
                    .append("<b>Current Cell Text: </b>"
                        + $currentCellText + "<br/>")
                    .append("<b>Text to Left of Clicked Cell: </b>"
                        + $leftCellText + "<br/>")
                    .append("<b>Text to Right of Clicked Cell: </b>"
                        + $rightCellText + "<br/>")
                    .append("<b>Column Name of Clicked Cell: </b>"
                        + $colName)
                });

        });

    </script>
    <style type="text/css">
        .Hide {
            display: none;
        }

        .modalBackground {
            background-color: Gray; /*filter:alpha(opacity=70); 	opacity:0.7;*/
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=70)"; /* IE 5-7 */
            filter: alpha(opacity=70); /* Netscape */
            -moz-opacity: 0.7; /* Safari 1.x */
            -khtml-opacity: 0.7; /* Good browsers */
            opacity: 0.7;
        }

    
        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.5%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .widget-content {
            padding: 0 10px !important;
        }

        .div_frame {
            width: 1360px;
            Height: 582px;
            float: left;
            text-align: center;
            /* overflow-y: scroll; */
        }

        iframe#logix_CPH_iframecost {
            width: 1360px;
            height: 498px;
        }

        .GridS {
            width: 100%;
            height: 415px;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            border: 0px solid #b1b1b1;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
    </style>

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
                font-size: 11px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
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
            font-size: 11px;
        }

        .FormGroupContent4 label {
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .BalanceChk input {
            float: left;
            width: 8%;
            margin: 4px 0.5% 0px 0px;
        }

        .BalanceChk {
            display: flex;
            flex-direction: column-reverse;
        }

            .BalanceChk center + label {
                   font-size: 13px !important;
    margin: 0 0 0 5px !important;
    display: block;
    color: var(--labelblue) !important;
    font-weight: 500;
            }
        /* FixedHeader */
 
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}
        .FixedHeader td {
    height: 48px !important;
}
        table#logix_CPH_grd_blncsheet thead tr {
    border-bottom: 1px solid var(--inputborder) !important;
}
        table#logix_CPH_grd_blncsheet tr {
    background: white !important;
}
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            if (!args.get_isPartialLoad()) {

                $addHandler(document, "keydown", onKeyDown);
            }
        }
        function onKeyDown(e) {

            if (e.keyCode == 27) {

                $find('logix_CPH_ModalPopupExtender1').hide();

            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="BalanceSheet"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Reports</a> </li>
                            <li><a href="#" title="">Balance Sheet</a> </li>
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
                            <div class="btn ico-ledger-branchwise" id="branchwise_id" runat="server"  >
    <asp:Button ID="btn_branchwise" runat="server" Text="Branch Wise" ToolTip="Branch Wise" OnClick="btn_branchwise_Click" />
</div>
<div class="btn ico-ledger-groupwise">
    <asp:Button ID="btn_gwise" runat="server"  Text="Group Wise" ToolTip="Group Wise" OnClick="btngwise_Click" />
</div>
                            <div class="btn ico-ledger-groupwise">
    <asp:Button ID="btn_all" runat="server"  Text="BalanceSheet" ToolTip="BalanceSheet" OnClick="btn_all_Click" />
</div>
<div class="btn ico-ledger-ledgerwise">
    <asp:Button ID="btn_lwise" runat="server" Text="Ledger Wise" ToolTip="Ledger Wise" OnClick="btnlwise_Click" />
</div>
                            <div class="btn ico-view hide">
                                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
                            </div>
                            <div class="btn ico-excel">
                                <asp:Button ID="btn_exlxport" runat="server" Text="Export Excel" ToolTip="Export Excel" OnClick="btn_exlxport_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                            </div>

                        </div>
                    </div>


                </div>

                <div class="widget-content">
                       
                    <div class="FormGroupContent4 boxmodal">

                        <div class="BalanceFinput">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" Enabled="false" ReadOnly="true"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_from" runat="server" TargetControlID="txt_from" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <div class="BalanceToInput">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_to" runat="server" TargetControlID="txt_to" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                        <div class="BalanceChk custom-mt-2">

                            <asp:CheckBox ID="chk_consol" Text="All Branches" runat="server" />

                        </div>
                         
                            
                       
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel class="gridpnl" ID="panel_grid" runat="server" ScrollBars="Both">

                            <asp:GridView ID="grd_blncsheet" runat="server" Width="100%" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                                AutoGenerateColumns="False" CssClass="Grid FixedHeader" OnRowDataBound="grd_blncsheet_RowDataBound" Visible="false"
                                OnRowCreated="grd_blncsheet_RowCreated" OnSelectedIndexChanged="grd_blncsheet_SelectedIndexChanged" OnRowCommand="grd_blncsheet_RowCommand" OnPreRender="grd_blncsheet_PreRender">
                                <Columns>
                                    <asp:ButtonField CommandName="ColumnClickNew" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                    <asp:BoundField DataField="Liabilities" HeaderText="Particulars" />
                                    <asp:BoundField DataField="LiabilitiesAmt" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Asset" HeaderText="Particulars" />
                                    <asp:BoundField DataField="AssetAmt" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>



                            <asp:GridView ID="grd_all" runat="server" Width="100%" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
    AutoGenerateColumns="False" CssClass="Grid FixedHeader" OnRowDataBound="grd_all_RowDataBound" Visible="false"
    OnRowCreated="grd_all_RowCreated" OnSelectedIndexChanged="grd_all_SelectedIndexChanged" OnRowCommand="grd_all_RowCommand" OnPreRender="grd_all_PreRender">
    <Columns>
        <asp:ButtonField CommandName="ColumnClickNew" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
        <asp:BoundField DataField="Liabilities" HeaderText="Particulars" />

        <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
        <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
        <asp:BoundField DataField="Net" HeaderText="Net" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>

        <asp:BoundField DataField="LiabilitiesAmt" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        

    </Columns>
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <HeaderStyle CssClass="GridHeader" />
    <AlternatingRowStyle CssClass="GrdAltRow" />
</asp:GridView>


                            <asp:GridView ID="GridSubgroup" runat="server" Width="100%" OnRowDataBound="GridSubgroup_RowDataBound" Visible="false"
                                AutoGenerateColumns="False" CssClass="Grid FixedHeader" OnSelectedIndexChanged="GridSubgroup_SelectedIndexChanged" DataKeyNames="subgroupid" OnPreRender="GridSubgroup_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="subgroupname" HeaderText="Particulars" />
                                    <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
                                    <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
                                   
                                    <asp:BoundField DataField="subgroupid" HeaderText="subgroupid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                             <asp:GridView ID="grd_sb_all" runat="server" Width="100%" OnRowDataBound="grd_sb_all_RowDataBound" Visible="false"
     AutoGenerateColumns="False" CssClass="Grid FixedHeader" OnSelectedIndexChanged="grd_sb_all_SelectedIndexChanged" DataKeyNames="subgroupid" OnPreRender="grd_sb_all_PreRender">
     <Columns>
         <asp:BoundField DataField="subgroupname" HeaderText="Particulars" />
         <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
         <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
         <asp:BoundField DataField="Net" HeaderText="Net" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
         <asp:BoundField DataField="subgroupid" HeaderText="subgroupid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
     </Columns>
     <EmptyDataRowStyle CssClass="EmptyRowStyle" />
     <HeaderStyle CssClass="GridHeader" />
     <AlternatingRowStyle CssClass="GrdAltRow" />
 </asp:GridView>


                            <asp:GridView ID="GrdGledger" runat="server" Width="100%" OnRowDataBound="GrdGledger_RowDataBound" Visible="false"
                                AutoGenerateColumns="False" CssClass="Grid FixedHeader" OnSelectedIndexChanged="GrdGledger_SelectedIndexChanged" DataKeyNames="ledgerid" OnPreRender="GrdGledger_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="ledgername" HeaderText="Ledger Name" />
                                    <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                                    <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                                    <asp:BoundField DataField="ledgerid" HeaderText="ledgerid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                             <asp:GridView ID="grd_lg_all" runat="server" Width="100%" OnRowDataBound="grd_lg_all_RowDataBound" Visible="false"
     AutoGenerateColumns="False" CssClass="Grid FixedHeader" OnSelectedIndexChanged="grd_lg_all_SelectedIndexChanged" DataKeyNames="ledgerid" OnPreRender="grd_lg_all_PreRender">
     <Columns>
         <asp:BoundField DataField="ledgername" HeaderText="Ledger Name" />
         <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
         <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
         <asp:BoundField DataField="Net" HeaderText="Net" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
         <asp:BoundField DataField="ledgerid" HeaderText="ledgerid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
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
    <asp:HiddenField ID="hid" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance"
        TargetControlID="lbl_hid" CancelControlID="Close_Trialbalance">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pln_Trialbalance" runat="server" class="modalPopup">
        <div class="divRoated">

            <div class="DivSecPanel">
                <asp:Image ID="Close_Trialbalance" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <div class="">
                <iframe id="iframecost" runat="server" src="" frameborder="0" class=""></iframe>
            </div>
        </div>
    </asp:Panel>

    <asp:Label ID="lbl_hid" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>BalanceSheet#</label>

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
