<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="profitandLoss.aspx.cs" Inherits="logix.FAForm.profitandLoss" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="KRI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
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
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <link href="../Styles/ProfitandLoss.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <%-- <script language="javascript" type="text/javascript">

        function popWin() {

            var datefrval = document.getElementById('<%=txt_From.ClientID%>').value;
            var datetoval = document.getElementById('<%=txt_To.ClientID%>').value;
            //alertify.alert(datefrval);
            //alertify.alert(datetoval);
            popUpWindow = window.open("ProfitLoss4allbranch.aspx?dtfrom=" + datefrval + "&dtto=" + datetoval + "", 'popUpWindow', 'height=610,width=1000,left=30,top=30,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
        //?dtfrom='" + txt_From.Text + "'&dtto='"+txt_To.Text+"'
        function popWind() {
            popUpWindow = window.open("NigalchiniralNew.htm", 'popUpWindow1', 'height=610,width=600,left=650,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }

        function popupphoto() {
            popupWindow = window.open("Photos.htm", 'popUpWindow', 'height=610,width=800,left=300,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
    </script>--%>

    <%-- -------------------------For Modal Popup ------------------------- --%>

    <%-- <script type="text/javascript">
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

        </script>--%>

    <%-- -------------------------For Gidview ColumnIndex ------------------------- --%>

    <script type="text/javascript">
        $(function () {
            $(".grd_profit > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".grd_profit td").removeClass("highlite");
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
        .Grid1 {
            width: 100%;
            border: 0px solid #b1b1b1;
            height: 395px;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        .FAFromInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .widget-content {
            padding: 0 10px !important;
        }

        .FAToinput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ProfitTxt1 {
            font-size: 11px;
            text-align: left;
            width: 17.5%;
            float: left;
            margin: 18px 0 0 0;
        }

        .TxtAlign1 {
            text-align: right !important;
        }

        .Consolidated input {
            float: left;
            margin: -4px 0.5% 0px 0px;
        }

        .Consolidated {
            width: 12%;
            float: left;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .ChkTillDate span, label {
            color: var(--grey);
        }

        div#logix_CPH_Panel3 {
            height: 88% !important;
        }
    </style>

    <%--  <script type="text/javascript">

        $(document).keydown(function (e)
        {
            if (e.keyCode == 27)
            {
                $("#<%=btnEsc.ClientID%>").click();
            }
         });

    </script>--%>

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

        .modalPopupssLog1 {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 90%;
            height: 447px;
            margin-left: 1%;
            margin-top: -20.9%;
            overflow: hidden;
        }

        .modalPopupssLog2 {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 75%;
            height: 461px;
            margin-left: 1%;
            margin-top: -20.9%;
            overflow: hidden;
        }

        .modalPopupssLogP10 {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 77.1%;
            height: 424px;
            margin-left: 1%;
            margin-top: -20.9%;
            overflow: hidden;
        }

        .modalPopupssLogP8 {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 77.4%;
            height: 424px;
            margin-left: 1%;
            margin-top: -20.9%;
            overflow: hidden;
        }

        .modalPopupssLogP2 {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 77.4%;
            height: 424px;
            margin-left: 1%;
            margin-top: -20.9%;
            overflow: hidden;
        }

        .modalPopupssLogn2 {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 75.4%;
            height: 424px;
            margin-left: 1%;
            margin-top: -20.9%;
            overflow: hidden;
        }

        .GridpnlLogn1 {
            width: 100%;
            height: 377px;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
            height: 408px;
            overflow: auto;
        }

        .GridpnlLogP11 {
            width: 100%;
            height: 375px;
            overflow: auto;
        }

        .GridpnlLogP1 {
            width: 100%;
            height: 378px;
            overflow: auto;
        }

        .GridpnlLogP8 {
            width: 100%;
            height: 378px;
            overflow: auto;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: -3%;
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

        .DivSecPanelLogN3 {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: -5%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

            .DivSecPanelLogN3 img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }

        .DivSecPanelLogN2 {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: -5%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

            .DivSecPanelLogN2 img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }

        .DivSecPanelLogN1 {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: -5%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

            .DivSecPanelLogN1 img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }

        .DivSecPanelLogN {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: -5%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

            .DivSecPanelLogN img {
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

        .LogHeadLblR {
            width: 97%;
            float: left;
            margin: 2px 0px 3px 0px;
        }

            .LogHeadLblR label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }

        .LogHeadLblRN {
            width: 100%;
            float: left;
            margin: 2px 0px 3px 0px;
        }

            .LogHeadLblRN label {
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

        .LogHeadJobR {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 10px;
            white-space: nowrap;
        }

        .LogHeadJobInputR label {
            font-size: 11px;
        }

        .LogHeadJobInputR {
            width: 19%;
            float: right;
            margin: 1px 0.5% 0px 0px;
            text-align: right;
        }

            .LogHeadJobInputR span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInputR label {
                font-size: 11px;
            }

        .LogHeadJobInputR1 {
            width: 27%;
            float: right;
            margin: 1px 0.5% 0px 0px;
            text-align: right;
        }

            .LogHeadJobInputR1 span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInputR1 label {
                font-size: 11px;
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
    </style>
    <style type="text/css">
        body {
            margin: 0;
            font-family: Arial, Helvetica, sans-serif;
        }

        .top-container {
            background-color: #f1f1f1;
            padding: 30px;
            text-align: center;
        }

        .header {
            padding: 2px 0px;
            color: #f1f1f1;
        }

        .content {
            padding: 0px;
        }

        .sticky {
            position: fixed;
            top: 0;
            width: 100%;
        }

            .sticky + .content {
                padding-top: 102px;
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

      

        |
        .Consolidated {
            display: flex;
            flex-direction: column-reverse;
        }

        .Consolidated center + label {
            font-weight: 500;
            font-size: 13px !important;
            margin: -20px 0 0 -10px !important;
            display: block;
            color: var(--labelblue) !important;
        }

        center {
            margin: 3px 0 0 !important;
            text-align: left;
        }
        /*          .gridpnl {
    height: calc(100vh - 168px);
}*/
        .widget.box .widget-content {
            top: 0px !important;
            padding-top: 55px !important;
        }

        .Consolidated {
            width: 15%;
            float: left;
            margin: 27px 0% 0px 0px;
        }

        table#logix_CPH_grd_trial tr {
            background: white !important;
        }
        table#logix_CPH_Grd_Ledger th:nth-child(2) {
    text-align: right;
}
                table#logix_CPH_Grd_Ledger th:nth-child(3) {
    text-align: right;
}
 
    </style>
    <script>
        window.onscroll = function () { myFunction() };

        var header = document.getElementById("myHeader");
        var sticky = header.offsetTop;

        function myFunction() {
            if (window.pageYOffset > sticky) {
                header.classList.add("sticky");
            } else {
                header.classList.remove("sticky");
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
                        <asp:Label ID="lbl_MainHeader" runat="server" Text="Profit & Loss"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Reports</a> </li>
                            <li><a href="#" title="">Profit and Loss Account</a> </li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                       <div class="FixedButtons">
        <div class="right_btn">
            <%--OnClientClick="popWin()"--%>
            <div class="btn ico-ledger-groupwise">
                <asp:Button ID="btn_group" runat="server" Text="Group Wise" ToolTip="Group Wise" OnClick="btn_group_Click" />
            </div>
            <div class="btn ico-ledger-groupwise">
                <asp:Button ID="btn_all" runat="server" Text="P & L" ToolTip="P & L" OnClick="btn_all_Click" />
            </div>
            <div class="btn ico-ledger-ledgerwise">
                <asp:Button ID="btn_ledger" runat="server" Text="Ledger Wise" ToolTip="Ledger Wise" OnClick="btn_ledger_Click" />
            </div>

            <div class="btn ico-view hide">
                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
            </div>
            <div class="btn ico-branch" id="ddl_branch" runat="server">
                <asp:Button ID="btn_branch" runat="server" Text="Branch Wise" ToolTip="Branch Wise" OnClick="btn_branch_Click" />
            </div>
            <div class="btn ico-excel">
                <asp:Button ID="btn_Export" runat="server" Text="Export" ToolTip="Export" OnClick="btn_Export_Click" />
            </div>
            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
            </div>
        </div>
    </div>
</div>


                

                <div class="widget-content">
                    
                <div class="FormGroupContent4 boxmodal">
                    <div class="ProfitTxt1 hide">
                        <asp:Label ID="lbl_header" runat="server" Text=" Profit and Loss  Account for the Period"></asp:Label>
                    </div>

                    <div class="FAFromInput">
                        <asp:Label ID="lbl_From" runat="server" Text="From"></asp:Label>
                        <asp:TextBox ID="txt_From" runat="server" CssClass="form-control" ToolTip="From"></asp:TextBox>
                    </div>

                    <div class="FAToinput">
                        <asp:Label ID="lbl_To" runat="server" Text="To"></asp:Label>
                        <asp:TextBox ID="txt_To" runat="server" CssClass="form-control" ToolTip="To"></asp:TextBox>
                    </div>
                    <div class="Consolidated">

                        <asp:CheckBox ID="chk_consolidate" Text="All Branches" runat="server" AutoPostBack="True" />

                    </div>
                    <div class="right_btn">


                        <div class="btn ico-get hide">
                            <asp:Button ID="btn_group_mm" runat="server" Text="Month Wise Group" ToolTip="MONTH Wise Group" OnClick="btn_group_mm_Click" />
                        </div>
                    </div>
                </div>

                <div class="FormGroupContent4 boxmodal">
                    <asp:Panel ID="grd_panel" runat="server" ScrollBars="Auto" CssClass="gridpnl">
                        <asp:GridView ID="grd_profit" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No Records Found" OnRowDataBound="grd_profit_RowDataBound" OnRowCommand="grd_profit_RowCommand" DataKeyNames="LEGroupType,LIGroupType,LELedgerid,LILedgerid" OnSelectedIndexChanged="grd_profit_SelectedIndexChanged" OnPreRender="grd_profit_PreRender">
                            <Columns>
                                <asp:BoundField DataField="part1" HeaderText="Particular" />
                                <asp:BoundField DataField="amount1" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                                    <HeaderStyle CssClass="TxtAlign1" Width="150px" />
                                    <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="part2" HeaderText="Particular" />
                                <asp:BoundField DataField="amount2" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                                    <HeaderStyle CssClass="TxtAlign1" Width="150px" />
                                    <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" Width="150px" />
                                </asp:BoundField>
                                <asp:ButtonField CommandName="Select" Visible="false" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView ID="GridSubgroup" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No Records Found" DataKeyNames="subgroupid" OnRowDataBound="GridSubgroup_RowDataBound" OnSelectedIndexChanged="GridSubgroup_SelectedIndexChanged" OnPreRender="GridSubgroup_PreRender">

                            <Columns>
                                <asp:BoundField DataField="subgroupname" HeaderText="Sub Group Name" />
                                <asp:BoundField DataField="Debit" HeaderText="Debit" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}">
                                    <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    <HeaderStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Credit" HeaderText="Credit" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}" ItemStyle-Width="150px" HeaderStyle-Width="150px" />

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView ID="Grd_Ledger" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No Records Found" DataKeyNames="ledgerid" OnSelectedIndexChanged="Grd_Ledger_SelectedIndexChanged" OnRowDataBound="Grd_Ledger_RowDataBound" OnPreRender="Grd_Ledger_PreRender">
                            <Columns>
                                <asp:BoundField DataField="ledgername" HeaderText="Ledger Name" />
                                <asp:BoundField DataField="debit" HeaderText="Debit" ItemStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}">
                                    <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    <HeaderStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="credit" HeaderText="Credit" ItemStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}" ItemStyle-Width="150px" HeaderStyle-Width="150px" />

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView ID="Grd_Ledger_new" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No Records Found" DataKeyNames="ledgerid"
                            OnSelectedIndexChanged="Grd_Ledger_new_SelectedIndexChanged" OnRowDataBound="Grd_Ledger_new_RowDataBound" OnPreRender="Grd_Ledger_new_PreRender">
                            <Columns>
                                <asp:BoundField DataField="ledgername" HeaderText="Ledger Name" />
                                <asp:BoundField DataField="debit" HeaderText="Debit" ItemStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}">
                                    <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    <HeaderStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="credit" HeaderText="Credit" ItemStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                                <asp:BoundField DataField="Net" HeaderText="Net" ItemStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}" ItemStyle-Width="150px" HeaderStyle-Width="150px" />

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView ID="GridView11" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                            ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" OnRowDataBound="GridView11_RowDataBound"
                            BackColor="White">
                            <Columns>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                            <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                            <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>

                        <asp:GridView ID="grd_all" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No Records Found" OnRowDataBound="grd_all_RowDataBound"
                            DataKeyNames="LEGroupType,LIGroupType,LELedgerid,LILedgerid,subgroupid"
                            OnSelectedIndexChanged="grd_all_SelectedIndexChanged" OnPreRender="grd_all_PreRender"> <%-- --%>
                            <Columns>

                                <%--<asp:TemplateField>
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
    
</asp:TemplateField>--%>
                                <asp:BoundField DataField="part1" HeaderText="Particular" />
                                <asp:BoundField DataField="debit" HeaderText="Dr" DataFormatString="{0:#,##0.00}">
                                    <HeaderStyle CssClass="TxtAlign1" Width="150px" />
                                    <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="credit" HeaderText="Cr" DataFormatString="{0:#,##0.00}">
                                    <HeaderStyle CssClass="TxtAlign1" Width="150px" />
                                    <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Net" HeaderText="Net" DataFormatString="{0:#,##0.00}">
                                    <HeaderStyle CssClass="TxtAlign1" Width="150px" />
                                    <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="amount1" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                                    <HeaderStyle CssClass="TxtAlign1" Width="150px" />
                                    <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" Width="150px" />
                                </asp:BoundField>
                                <asp:ButtonField CommandName="Select" Visible="false" />
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
    

    <asp:HiddenField ID="hidId" runat="server" />

    
    <%--Vino New for GP [01-03-2024]--%>
    
    <asp:Label ID="lbl_GP" runat="server"></asp:Label>
   
        <asp:Panel ID="PanelGP" runat="server" class="modalPopup" BackColor="White" Style="display: none;" >
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="Close_GP" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <div class="">
                    <iframe id="iframe_GP" runat="server" src="" frameborder="0"></iframe>
                </div>
            </div>
        </asp:Panel>
    
    <%--Vino New for GP End--%>


    <div class="FormGroupContent4">
        <asp:HiddenField ID="hid" runat="server" />
        <asp:Panel ID="pln_Trialbalance" runat="server" Style="display: none;" CssClass="modalPopup" BackColor="White">
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

    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance"
        TargetControlID="lbl_hid" BackgroundCssClass="modalBackground" CancelControlID="Close_Trialbalance">
        <Animations>
        <OnShown>
            <FadeIn Duration="1.5" Fps="40" />                
        </OnShown>
        </Animations>
    </asp:ModalPopupExtender>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>ProfitandLossAccount#</label>

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

    <div class="div_Break"></div>
    <%--<div class="GridShow" id="PanelGrid1" runat="server">--%>
    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none">
        <div class="divRoated">
            <div class=" header" id="myHeader">

                <div class="LogHeadJobR">
                    <label>GP Vs Operating Profit</label>

                </div>

                <div class="DivSecPanel">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <div class="LogHeadJobInputR" style="display: none;">

                    <asp:Label ID="Label1" runat="server"></asp:Label>

                </div>
                <div class="LogHeadJobInputR1" style="display: none;">

                    <asp:Label ID="Label5" runat="server"></asp:Label>

                </div>

            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridView1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" OnRowDataBound="GridView1_RowDataBound"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White">
                    <Columns>
                        <asp:BoundField DataField="Branch" HeaderText="Branch">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AE" HeaderText="AE">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AI" HeaderText="AI">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="BT" HeaderText="BT">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>--%>
                       <%-- <asp:BoundField DataField="CH" HeaderText="CH">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>--%>
                        <%--  <asp:BoundField DataField="FC" HeaderText="FC">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="OE" HeaderText="OE">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="OI" HeaderText="OI">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" HeaderText="Total">
                            <HeaderStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                    <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                    <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>

            <div class="btn ico-excel" style="float: right;">
                <asp:Button ID="btn_gpprofit" runat="server" ToolTip="Export" OnClick="btn_gpprofit_Click" />
            </div>
        </div>

        <div class="Break"></div>

    </asp:Panel>
    <%--</div>--%>

    <%--<div class="GridShow" id="PanelGrid2" runat="server">--%>
    <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none">
        <div class="divRoated">
            <div class=" header" id="myHeader1">

                <div class="LogHeadJobR">
                    <label>Job closed in previous / Subsequent Month(s) & Voucher raised during the given period (+)</label>

                </div>

                <div class="btn ico-excel" style="margin: 0px 8px 0px 0px; float: right;">
                    <asp:Button ID="btn_jobclose1" runat="server" ToolTip="Export" OnClick="btn_jobclose1_Click" />
                </div>

                <div class="DivSecPanel">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <div class="LogHeadJobInputR">

                    <asp:Label ID="Label3" runat="server"></asp:Label>

                </div>

            </div>

            <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" OnRowDataBound="GridView2_RowDataBound"
                    BackColor="White">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                    <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                    <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>
        <div class="Break"></div>

    </asp:Panel>
    <%--</div>--%>

    <asp:Panel ID="Panel6" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none">
        <div class="divRoated">
            <div class="LogHeadLblRN header" id="myHeader2">

                <div class="LogHeadJobR">
                    <label>Voucher raised during the given period & Jobs Unclosed (+)</label>

                </div>

                <div class="btn ico-excel" style="margin: -2px 27px 0px 0px; float: right;">
                    <asp:Button ID="btn_jobclose2" runat="server" ToolTip="Export" OnClick="btn_jobclose2_Click" />
                </div>

                <div class="DivSecPanel">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <div class="LogHeadJobInputR">

                    <asp:Label ID="Label6" runat="server"></asp:Label>

                </div>

            </div>

            <asp:Panel ID="Panel7" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridView3" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" OnRowDataBound="GridView2_RowDataBound"
                    BackColor="White">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                    <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                    <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>

    </asp:Panel>

    <asp:Panel ID="Panel8" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none">
        <div class="divRoated">
            <div class=" header" id="myHeader3">

                <div class="LogHeadJobR">
                    <label>JobClosed during the given period but voucher raised previous / Subsequent Month(s) </label>

                </div>

                <div class="btn ico-excel" style="margin: 0px -6px 0px 0px; float: right;">
                    <asp:Button ID="btn_close3" runat="server" ToolTip="Export" OnClick="btn_close3_Click" />
                </div>

                <div class="DivSecPanel">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <div class="LogHeadJobInputR">

                    <asp:Label ID="Label7" runat="server"></asp:Label>

                </div>

            </div>

            <asp:Panel ID="Panel9" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridView4" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" OnRowDataBound="GridView2_RowDataBound"
                    BackColor="White">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                    <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                    <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>

    </asp:Panel>

    <asp:Panel ID="Panel10" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none">
        <div class="divRoated">
            <div class=" header" id="myHeader4">

                <div class="LogHeadJobR">
                    <label>Voucher Account in FA (+)</label>

                </div>

                <div class="btn ico-excel" style="margin: 0px 8px 0px 0px; float: right;">
                    <asp:Button ID="btn_close4" runat="server" ToolTip="Export" OnClick="btn_close4_Click" />
                </div>

                <div class="DivSecPanel">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <div class="LogHeadJobInputR">

                    <asp:Label ID="Label8" runat="server"></asp:Label>

                </div>

            </div>

            <asp:Panel ID="Panel11" runat="server" CssClass=" Gridpnl">

                <asp:GridView ID="GridView5" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" OnRowDataBound="GridView2_RowDataBound"
                    BackColor="White">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                    <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                    <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>

    </asp:Panel>

    <asp:Label ID="Label4" runat="server"></asp:Label>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <KRI:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from" Format="dd/MM/yyyy"></KRI:CalendarExtender>
    <KRI:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to" Format="dd/MM/yyyy"></KRI:CalendarExtender>
    <asp:HiddenField ID="hid_aclsamount" runat="server" />
    <asp:HiddenField ID="hid_UCLamount" runat="server" />
    <asp:HiddenField ID="hid_CCLSamount" runat="server" />
    <asp:HiddenField ID="hid_JNLSamount" runat="server" />
    <asp:HiddenField ID="hid_Gp" runat="server" />
    <asp:HiddenField ID="hid_Gl" runat="server" />
    <asp:HiddenField ID="hid_diifer" runat="server" />
    <asp:Button ID="btnEsc" runat="server" Style="display: none;" OnClick="btnEsc_Click" />

    <asp:Label ID="lbl_hid" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel2"
        DropShadow="false" TargetControlID="Label1" CancelControlID="Image1" BehaviorID="Test2">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel4"
        DropShadow="false" TargetControlID="Label3" CancelControlID="Image2" BehaviorID="Test3">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="Panel6"
        DropShadow="false" TargetControlID="Label6" CancelControlID="Image3" BehaviorID="Test4">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalPopupExtender5" runat="server" PopupControlID="Panel8"
        DropShadow="false" TargetControlID="Label7" CancelControlID="Image4" BehaviorID="Test5">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalPopupExtender6" runat="server" PopupControlID="Panel10"
        DropShadow="false" TargetControlID="Label8" CancelControlID="Image5" BehaviorID="Test6">
    </asp:ModalPopupExtender>

    
    <%--Vino New for GP [01-03-2024]--%>
    
    <asp:ModalPopupExtender ID="ModalPopupGP" runat="server" PopupControlID="PanelGP" TargetControlID="lbl_GP" CancelControlID="Close_GP">
    <Animations>
    <OnShown>
        <FadeIn Duration="1.5" Fps="40" />                
    </OnShown>
    </Animations>
    </asp:ModalPopupExtender>
    <%--End--%>



</asp:Content>
