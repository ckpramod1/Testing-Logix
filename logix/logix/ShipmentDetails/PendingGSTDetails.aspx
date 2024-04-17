<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="PendingGSTDetails.aspx.cs" EnableEventValidation="false" Inherits="logix.ShipmentDetails.PendingGSTDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

    <style type="text/css">
        .DivGrid {
            width: 100%;
            float: left;
            height: 450px;
            border: 1px solid #b1b1b1;
            margin-bottom: 10px;
            overflow: auto;
        }

        .DivGridn1 {
            width: 100%;
            float: left;
            height: 450px;
            border: 0px solid #b1b1b1;
            margin-bottom: 10px;
            overflow: auto;
        }

        .FromLabel {
            width: 2.5%;
            float: left;
            margin: 3px 0.5% 0px 0%;
        }

        .ToLabel {
            width: 1.5%;
            float: left;
            margin: 3px 0.5% 0px 0px;
        }

        .Grid th {
            white-space: nowrap !important;
        }

        .Grid td {
            white-space: nowrap !important;
        }

        .EventsDrop {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BranchDropN1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 13%;
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

        .widget.box{
    position: relative;
    top: -8px;
}
table#logix_CPH_grdpifsdtls td:nth-child(6) {
    max-width: 175px !important;
    overflow: hidden;
    text-overflow: ellipsis;
}
table#logix_CPH_grdcifsdtls td:nth-child(7) {
    max-width: 175px !important;
    overflow: hidden;
    text-overflow: ellipsis;
}
        table#logix_CPH_grdcifsdtls td:nth-child(12), table#logix_CPH_grdcifsdtls td:nth-child(11), table#logix_CPH_grdcifsdtls td:nth-child(13), table#logix_CPH_grdcifsdtls td:nth-child(14) {
            max-width: 175px !important;
            overflow: hidden;
            text-overflow: ellipsis;
        }
.widget.box .widget-content {
    top: 0px !important;
    padding-top:15px !important;
}
.FromInput {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.ToCalInput {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box">
                <div class="widget-header">
                    <div>
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblheader" runat="server" Text="Pending GST IRN Details"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li id="li_head" runat="server" visible="false"><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Exports</a> </li>
            <li><a href="#" title="">Ops and Docs</a> </li>
            <li class="current"><a href="#" title="">Pending GST IRN Details</a> </li>
        </ul>
    </div>
                    </div>




                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="BranchDropN1">
                            <asp:Label ID="Label1" runat="server" Text="Branch"> </asp:Label>
                            <asp:DropDownList ID="ddl_branch" runat="server" CssClass="chzn-select"
                                AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" data-placeholder="Branch" ToolTip="Branch">
                            </asp:DropDownList>
                        </div>

                        <div class="EventsDrop">
                            <asp:Label ID="Label2" runat="server" Text="Events"> </asp:Label>
                            <asp:DropDownList ID="ddlEvents" runat="server" AutoPostBack="true" data-placeholder="Events" CssClass="chzn-select" ToolTip="Events" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged">
                                <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="FromInput">
                            <asp:Label ID="lbl_From" Text="From" runat="server" Visible="false"></asp:Label>
                            <asp:TextBox ID="txt_From" runat="server" CssClass="form-control" placeholder="" ToolTip="From" TabIndex="1" Visible="false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_From" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <div class="ToCalInput">
                            <asp:Label ID="lbl_To" Text="To" runat="server" Visible="false"></asp:Label>
                            <asp:TextBox ID="txt_To" runat="server" CssClass="form-control" placeholder="" ToolTip="To" TabIndex="2" Visible="false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_To" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <div class="right_btn custom-mt-1">
                        <div class="btn ico-get" id="get_id" runat="server"  Visible="false" >
                            <asp:Button ID="btn_get" ToolTip="get" Text="Get" runat="server" OnClick="btn_get_Click" TabIndex="3" Visible="false" />
                        </div>

                        <div class="btn ico-cancel" id="btn_cancel1" runat="server" Visible="false" >
                            <asp:Button ID="btn_cancel" ToolTip="Cancel" Text="Cancel"  runat="server" OnClick="btn_cancel_Click" TabIndex="4" Visible="false" />
                        </div>
                        <div class="btn ico-excel">
                            <asp:Button ID="btn_Export" runat="server"  Text="Export Excel" ToolTip="DownLoad" OnClick="btn_Export_Click" />
                        </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl MB0" id="DivPend" runat="server">
                            <asp:GridView ID="grdpifsdtls" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true"
                                EmptyDataText="No Record Found" OnRowDataBound="grdpifsdtls_RowDataBound">
                                <%--OnRowDataBound="grdpifsdtls_RowDataBound"--%>

                                <Columns>
                                    <asp:TemplateField HeaderText="SL #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="65px" Height="23px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="65px" Height="23px"></ItemStyle>
                                    </asp:TemplateField>
                                    <%-- 0 --%>
                                    <asp:BoundField DataField="BranchShort" HeaderText="BranchShort"></asp:BoundField>
                                    <%-- 1 --%>
                                    <asp:BoundField DataField="vouno" HeaderText="Vou #"></asp:BoundField>
                                    <%-- 2 --%>
                                    <asp:BoundField DataField="vouyear" HeaderText="Vou Year"></asp:BoundField>
                                    <%-- 3 --%>
                                    <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                                    <%-- 4 --%>
                                    <asp:BoundField DataField="message" HeaderText="Status Msg"></asp:BoundField>
                                    <%-- 5 --%>
                                    <asp:BoundField DataField="Irn" HeaderText="IRN #"></asp:BoundField>
                                    <%-- 6 --%>

                                    <%-- 7 --%>
                                    <asp:BoundField DataField="AckDt" HeaderText="Ack Date"></asp:BoundField>
                                    <%-- 8 --%>
                                    <asp:BoundField DataField="AckNo" HeaderText="Ack #"></asp:BoundField>
                                    <%-- 9 --%>
                                    <asp:BoundField DataField="Status1" HeaderText="Status"></asp:BoundField>
                                    <%-- 10 --%>
                                    <%--  <asp:BoundField DataField="SignedQRCode" HeaderText="SignedQRCode"></asp:BoundField>--%>
                                    <%-- 11 --%>
                                    <%--    <asp:BoundField DataField="SignedInvoice" HeaderText="SignedInvoice"></asp:BoundField>--%>
                                    <%-- 12 --%>

                                    <%-- 13 --%>
                                    <asp:BoundField DataField="uuid" HeaderText="uuid"></asp:BoundField>
                                    <%-- 14 --%>

                                    <%--       <asp:BoundField DataField="SignedQrCodeImgUrl" HeaderText="SignedQrCodeImgUrl"></asp:BoundField>--%>

                                    <asp:BoundField DataField="IrnStatus" HeaderText="IrnStatus"></asp:BoundField>

                                    <asp:BoundField DataField="EwbStatus" HeaderText="EwbStatus"></asp:BoundField>
                                    <asp:BoundField DataField="Irp" HeaderText="Irp"></asp:BoundField>
                                    <asp:BoundField DataField="bid" HeaderText="Bid"></asp:BoundField>

                                    <asp:BoundField DataField="voutype" HeaderText="voutype"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Transfer">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_Transfer" runat="server" ImageUrl="../images/Transfer.jpg" Style="width: 60px; height: 20px; margin-left: 1%;" OnClick="btn_Transfer_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="gridpnl" id="DivComt" runat="server">
                            <asp:GridView ID="grdcifsdtls" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" OnRowDataBound="grdcifsdtls_RowDataBound"
                                EmptyDataText="No Record Found">

                                <Columns>
                                    <asp:TemplateField HeaderText="SL #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="65px" Height="23px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="65px" Height="23px"></ItemStyle>
                                    </asp:TemplateField>
                                    <%-- 0 --%>
                                    <asp:BoundField DataField="BranchShort" HeaderText="BranchShort"></asp:BoundField>
                                    <%-- 1 --%>
                                    <asp:BoundField DataField="vouno" HeaderText="Vou #"></asp:BoundField>
                                    <%-- 2 --%>
                                    <asp:BoundField DataField="vouyear" HeaderText="Vou Year"></asp:BoundField>
                                    <%-- 3 --%>
                                    <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                                    <%-- 4 --%>
                                    <asp:BoundField DataField="message" HeaderText="Status Msg"></asp:BoundField>
                                    <%-- 5 --%>
                                    <asp:BoundField DataField="Irn" HeaderText="IRN #"></asp:BoundField>
                                    <%-- 6 --%>

                                    <%-- 7 --%>
                                    <asp:BoundField DataField="AckDt" HeaderText="Ack Date"></asp:BoundField>
                                    <%-- 8 --%>
                                    <asp:BoundField DataField="AckNo" HeaderText="Ack #"></asp:BoundField>
                                    <%-- 9 --%>
                                    <asp:BoundField DataField="Status1" HeaderText="Status"></asp:BoundField>
                                    <%-- 10 --%>
                                    <%-- <asp:BoundField DataField="SignedQRCode" HeaderText="SignedQRCode"></asp:BoundField>--%>
                                    <%-- 11 --%>
                                    <%--     <asp:BoundField DataField="SignedInvoice" HeaderText="SignedInvoice"></asp:BoundField>--%>
                                    <%-- 12 --%>

                                    <%-- 13 --%>
                                    <asp:BoundField DataField="uuid" HeaderText="uuid"></asp:BoundField>
                                    <%-- 14 --%>

                                    <%--  <asp:BoundField DataField="SignedQrCodeImgUrl" HeaderText="SignedQrCodeImgUrl"></asp:BoundField>--%>

                                    <asp:BoundField DataField="IrnStatus" HeaderText="IrnStatus"></asp:BoundField>

                                    <asp:BoundField DataField="EwbStatus" HeaderText="EwbStatus"></asp:BoundField>
                                    <asp:BoundField DataField="Irp" HeaderText="Irp"></asp:BoundField>
                                    <asp:BoundField DataField="voutype" HeaderText="VouType"></asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
