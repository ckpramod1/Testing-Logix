<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProfitLoss4allbranch.aspx.cs" Inherits="logix.FAForm.ProfitLoss4allbranch" %>

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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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

    <style type="text/css">
        body {
            overflow: hidden;
        }

        .PopGrid {
            width: 1317px;
            height: 404px;
            overflow-x: auto;
            overflow-y: auto;
        }
        .LedgerFromInput {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .LedgerToInput {
    width: 8%;
}
        .widget-header h4 {
    display: block !important;
}
        .crumbs {
    display: none !important;
}
    </style>


    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/ProfitLoss4allBranch.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella hide"></i>
                        <asp:Label ID="lbl_MainHeader" runat="server" Text="Profit & Loss"></asp:Label>


                    </h4>

                </div>




                <div class="widget-content">
                    <div class="FormGroupContent">

                        
                        <div class="LedgerFromInput">
                            <asp:Label ID="lbl_From" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_From" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                      
                        <div class="LedgerToInput">
                            <asp:Label ID="lbl_To" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_To" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="LedgerChk custom-mt-3">
                            <asp:CheckBox ID="chk_ledger" runat="server" Text="Ledger"
                                AutoPostBack="True" />
                        </div>
                        <div class="right_btn custom-mt-3">
                            <div class="btn ico-get">
                                <asp:Button ID="btn_get" runat="server" ToolTip="Get"
                                    OnClick="btn_get_Click" />
                            </div>
                            <div class="btn ico-excel">
                                <asp:Button ID="btn_export" runat="server" ToolTip="Export To Excel"
                                    OnClick="btn_Export_Click" />
                            </div>


                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="panel_10">
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="true" Width="100%" CssClass="Grid FixedHeader" OnRowDataBound="grd_RowDataBound">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:CalendarExtender ID="ce_From" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_From" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="ce_To" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_To" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
</asp:Content>
