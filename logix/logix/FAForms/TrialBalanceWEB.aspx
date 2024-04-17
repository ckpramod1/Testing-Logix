<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="TrialBalanceWEB.aspx.cs" Inherits="logix.FAForm.TrialBalanceWEB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="KRI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">

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

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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

    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <link href="../Styles/MasterGroup.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">

        $("[src*=download]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../NewImages/imagesminus.jpg");
        });
        $("[src*=imagesminus]").live("click", function () {
            $(this).attr("src", "../NewImages/download.jpg");
            $(this).closest("tr").next().remove();
        });
    </script>
       <style type="text/css">
        .LedgerLbl {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_Grid {
            margin: 0px 20px 0px 0px;
            height: 383px !important;
            overflow: auto;
            border: 0px solid #b1b1b1;
        }

        .row {
            height: 566px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .FromTriInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TotrialInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GrdAltRow {
            background-color: #f8f3e1;
            font-family: sans-serif;
            font-size: 10px;
            color: Black;
        }

        .ClickLeft {
            float: left;
              margin: -12px 0.5% 0px 0px;
        }

        .RepostTxt {
            float: left;
            width: 350px;
        }

        .FormGroupContent4 label {
            display: inline-block !important;
            float: none !important;
            margin: 0 0 0 5px;
            width: auto !important;
        }

        iframe#logix_CPH_iframecost {
            width: 1360px;
            logix_CPH_ height: 97%;
            border: 1px solid #b1b1b1;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.5%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .modalBackground {
            background-color: transparent !important;
        }

        .div_frame {
            width: 1360px;
            Height: 582px;
            float: left;
            text-align: center;
            /* overflow-y: scroll; */
        }

        .row {
            height: 603px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
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

        logix_CPH_PanelLog {
            border-width: 2px;
            border-style: solid;
            position: fixed;
            z-index: 100001;
            left: 352px;
            top: 187px !important;
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

        /*new*/

        .FromTrial {
            width: 2%;
            float: left;
            margin: 4px 0.5% 0px 0px;
        }

        .ToTrial {
            width: 1%;
            float: left;
            margin: 5px 0.5% 0px 0px;
        }

        input[type="checkbox"] + label {
            position: relative;
            bottom: 2px;
        }

        .div_Grdladel_ledger span,
        .div_Grdladel_balance span,
        .div_Grdladel span,
        .div_Grdladel_closingbalance span {
            color: var(--labelorange) !important
        }

        .div_Grdladel_ledger {
            padding: 3px 5px;
            background: white !important;
            color: var(--white) !important;
            font-family: sans-serif;
            font-style: inherit;
            font-size: 8pt;
            width: 31.25%;
            float: left;
            margin-top: 0.5%;
            text-align: Center;
            border: 1px solid;
            border-right: 0.5px solid #fff !important;
        }

        .div_Grdladel_balance {
            padding: 2px 5px;
                       background: white !important;

            color: var(--white) !important;
            font-family: sans-serif;
            font-style: inherit;
            font-size: 8pt;
            width: 300px;
            float: left;
            margin-top: 0.5%;
            text-align: Center;
            border: 1px solid;
                margin-left: 4%;
        }

        .div_Grdladel {
            padding: 2px 5px;
                        background: white !important;

            color: var(--white) !important;
            font-family: sans-serif;
            font-style: inherit;
            font-size: 8pt;
            width: 300px;
            float: left;
            margin-top: 0.5%;
            text-align: Center;
            border: 1px solid;
            width:224px !important;
                margin-left: 37px;
        }

        .div_Grdladel_closingbalance {
            padding: 2px 5px;
                        background: white !important;

            color: var(--white) !important;
            font-family: sans-serif;
            font-style: inherit;
            font-size: 8pt;
            width: 308px;
            float: left;
            margin-top: 0.5%;
            text-align: Center;
            border: 1px solid;
                  margin-left: 107px !important;
                width: 165px !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .div_Grdladel_ledger {
            width: 350px !important;
        }

        .LedgerTrial {
            width: 6%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

        .AmountTrial {
            width: 6%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

        .AliasTrial {
            width: 6%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

 

      

        .ConsolTrial {
            width: 7%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

        .ConsolTrial {
            display: flex;
            flex-direction: column-reverse;
        }

            .ConsolTrial center + label {
                    font-weight: 500;
    font-size: 13px !important;
    margin: -8px 0 0 5px !important;
    display: block;
    color: var(--labelblue) !important;
            }
        
  
            .widget.box .widget-content {
    top: 55px !important;
}
            .FixedHeader td {
    border-right: 0px solid var(--inputborder) !important;
    border-bottom: 0px solid #aaa !important;
    font-size: 14px !important;
    white-space: nowrap;
    height: 48px !important;
    padding: 5px !important;
}
            .link-rotate{
                    rotate: 90deg !important;
            }
            table#logix_CPH_grd_trial th {
    text-align: right;
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
                        <asp:Label ID="lbl_header" runat="server" Text="Trial Balance"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Reports</a> </li>
                            <li><a href="#" title="">Trial Balance </a></li>
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
          
  <div class="right_btn">
       <div class="btn ico-get">
    <asp:Button ID="btn_get" Text="Get" runat="server" ToolTip="Get" OnClick="btnget_Click" />
</div>
  <div class="btn ico-get">
      <asp:Button ID="btn_lgdall" Text="TrialBalance" runat="server" ToolTip="TrialBalance" OnClick="btn_lgdall_Click" />
  </div>
           <div class="btn ico-excel">
               <asp:Button ID="btn_export" Text="Export To Excel" runat="server" ToolTip="Export To Excel" OnClick="btn_export_Click" />
           </div>

           <div class="btn ico-branch" id="branch_id" runat="server"  Visible="false" >
               <asp:Button ID="btn_branchwise" runat="server" Visible="false" Text="Branch Wise" ToolTip="Branch Wise" OnClick="btn_branchwise_Click" />
           </div>

           <div class="btn ico-print hide">
               <asp:Button ID="btn_print" runat="server"  Text="Print" ToolTip="Print" OnClick="btnprint_Click" />
           </div>
           <div class="btn ico-cancel" id="btn_cancel1" runat="server">
               <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
           </div>

       </div>
                   </div>
                        </div>


                </div>

                <div class="widget-content">
                    

                    <div class="FormGroupContent4 boxmodal">

                        <div class="FromTriInput">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="TotrialInput">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="LedgerTrial">
                            <span>Ledger</span>

                            <asp:CheckBox ID="chk_Ledger" runat="server" />

                        </div>
                        <div class="AmountTrial hide">
                            <span>Amount</span>

                            <asp:CheckBox ID="chk_Amount" runat="server" />

                        </div>
                        <div class="AliasTrial hide">
                            <span>Alias Name</span>

                            <asp:CheckBox ID="chk_alias" runat="server" />

                        </div>
                        <div class="ConsolTrial">

                            <asp:CheckBox ID="chk_Consolidate" Text="All Branches" runat="server" />

                        </div>
                

                    </div>
                    <div class="FormGroupContent4 hide" id="div_Grdheader" runat="server">
                        <div class="LedgerLbl">
                            <asp:Label ID="lblledger" runat="server" Text="Trial Balance" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="right_btn">
                        </div>
                    </div>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4 custom-d-flex" runat="server" id="head">
                        <div class="div_Grdladel_ledger">
                            <asp:Label ID="lbl_ledname" runat="server" Text="Ledger Name" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_Grdladel_balance">
                            <asp:Label ID="lbl_ob" runat="server" Text="Opening Balance" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_Grdladel">
                            <asp:Label ID="lbl_tb" runat="server" Text="Transaction Balance" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_Grdladel_closingbalance">
                            <asp:Label ID="lbl_cb" runat="server" Text="Closing Balance" CssClass="LabelValue"></asp:Label>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl MB0 MT0">
                            <asp:GridView ID="grd_trial" runat="server" AutoGenerateColumns="False" DataKeyNames="groupid,LedgerType,Ledgerid" Width="100%"
                                OnRowDataBound="grd_trial_RowDataBound" OnSelectedIndexChanged="grd_trial_SelectedIndexChanged" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found" OnPreRender="grd_trial_PreRender">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            
                                            <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                                                CssClass="arrow">
                                                <img src="../Theme/assets/img/buttonIcon/active/link-rotate.png" class="link-rotate"    width="18px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="link_ledgerselect" runat="server" CommandName="select" Font-Underline="false"
                                                CssClass="arrow">
                                                <img src="../Theme/assets/img/buttonIcon/active/link.png" width="18px" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="35px" />
                                        <ItemStyle Width="35px" />
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField>

                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ledgername") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Debit" DataField="NewObDebit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit" DataField="NewObCredit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit" DataField="NewTransDebit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit" DataField="NewTransCredit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit" DataField="Debit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit" DataField="Credit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <%-- <RowStyle CssClass="GrdAltRow" />
            <AlternatingRowStyle CssClass="GrdAltRow" />--%>
                            </asp:GridView>

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Visible="False" DataKeyNames="groupid,LedgerType,Ledgerid"
                                Width="100%" OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender">
                                <Columns>
                                    <asp:TemplateField>

                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ledgername") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Debit" DataField="NewObDebit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle Width="150px"></HeaderStyle>

                                        <ItemStyle Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit" DataField="NewObCredit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle Width="150px"></HeaderStyle>

                                        <ItemStyle Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit" DataField="NewTransDebit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle Width="150px"></HeaderStyle>

                                        <ItemStyle Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit" DataField="NewTransCredit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle Width="150px"></HeaderStyle>

                                        <ItemStyle Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit" DataField="Debit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle Width="150px"></HeaderStyle>

                                        <ItemStyle Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit" DataField="Credit" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                        <HeaderStyle Width="150px"></HeaderStyle>

                                        <ItemStyle Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <%--<asp:BoundField HeaderText="groupid" DataField="groupid" HeaderStyle-CssClass="hide1" ItemStyle-CssClass="hide1">
                </asp:BoundField>
                <asp:BoundField HeaderText="LedgerType" DataField="LedgerType" HeaderStyle-CssClass="hide1" ItemStyle-CssClass="hide1">
                </asp:BoundField>
                <asp:BoundField HeaderText="Ledgerid" DataField="Ledgerid" HeaderStyle-CssClass="hide1" ItemStyle-CssClass="hide1">
                </asp:BoundField>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" Wrap="false" />
                                <RowStyle Wrap="false" />
                            </asp:GridView>
                            <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                                 ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
                                 BackColor="White" Visible="false" OnRowDataBound="GridView2_RowDataBound">
                                 <Columns>
                                 </Columns>
                                 <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                 <HeaderStyle CssClass="myGridHeader" />
                                 <AlternatingRowStyle CssClass="GrdAltRow" />
                                 <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </div>
                    </div>

                    <div id="lnk_mis" runat="server" visible="false">
                        <div class="ClickLeft">
                            <asp:LinkButton ID="lnkMisMatch" CssClass="anc ico-find-sm" runat="server" Style="text-decoration: none;" OnClick="lnkMisMatch_Click"></asp:LinkButton>
                        </div>
                        <div class="RepostTxt custom-mt-2">

                            <asp:Label ID="lbl_MisMatch" runat="server">Click here to Repost the Vouchers to remove the difference</asp:Label>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:HiddenField ID="hid" runat="server" />
                        <asp:Panel ID="pln_Trialbalance" runat="server" CssClass="modalPopup">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="Close_Trialbalance" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <div class="">
                                    <iframe id="iframecost" runat="server" src="" frameborder="0" class=""></iframe>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
               
            </div>
        </div>
    </div>

    <%--<div class="TB_break"></div>                      

  <div class="TB_lab">
  <asp:Label ID="lbl_diff" runat="server" Text="Diff" CssClass="LabelValue"></asp:Label></div> 
  <div class="TB_sublab">
  <asp:Label ID="lbl_deb1" runat="server" Text="Debit" CssClass="LabelValue"></asp:Label></div>
  <div class="TB_sublab">
  <asp:Label ID="lbl_cdt1" runat="server" Text="Credit" CssClass="LabelValue"></asp:Label></div>
  <div class="TB_sublab">
  <asp:Label ID="lbl_deb2" runat="server" Text="Debit" CssClass="LabelValue"></asp:Label></div>
  <div class="TB_sublab">
  <asp:Label ID="cdt2" runat="server" Text="Credit" CssClass="LabelValue"></asp:Label></div>
  <div class="TB_sublab">
  <asp:Label ID="lbl_deb3" runat="server" Text="Debit" CssClass="LabelValue"></asp:Label></div>
  <div class="TB_sublab">
  <asp:Label ID="lbl_cdt3" runat="server" Text="Credit" CssClass="LabelValue"></asp:Label></div>--%>

    <KRI:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance"
        TargetControlID="lbl_hid" BackgroundCssClass="modalBackground" CancelControlID="Close_Trialbalance">
    </KRI:ModalPopupExtender>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>TrialBalance#</label>

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

    <KRI:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </KRI:ModalPopupExtender>

    <KRI:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from" Format="dd/MM/yyyy"></KRI:CalendarExtender>
    <KRI:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to" Format="dd/MM/yyyy"></KRI:CalendarExtender>
    <asp:HiddenField ID="hid_tot" runat="server" />
    <asp:HiddenField ID="hid_dramt" runat="server" />
    <asp:HiddenField ID="hid_cramt" runat="server" />
    <asp:Label ID="lbl_hid" runat="server" />
</asp:Content>
