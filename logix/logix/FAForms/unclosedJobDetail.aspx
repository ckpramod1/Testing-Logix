<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="unclosedJobDetail.aspx.cs"
    Inherits="logix.FAForm.unclosedJobDetail" %>

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
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
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
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/UnclosedJobDetails.css" />

    <style type="text/css">
        .hide {
            display: none;
        }

        .Payinput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PaytoInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Grid2 {
            border: 1px solid #b1b1b1;
            height: 454px;
            margin: 0;
            overflow-x: auto !important;
            overflow-y: auto !important;
            width: 100%;
            margin-bottom: 10px;
        }

        .PaymentsFrom {
            width: 2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Payto {
            width: 1%;
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

        thead {
            position: sticky;
            top: -1px;
        }

        td {
            border-right: 1px solid #AAA !important;
            border-bottom: 1px solid #AAA !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .right_btn {
            margin: 5px 0px 0px 0px;
        }

        table#logix_CPH_CalendarExtender1_daysTable td, table#logix_CPH_CalendarExtender2_daysTable td {
            border: 0px !important;
        }
        table#logix_CPH_grduncjob td:nth-child(6), table#logix_CPH_grduncjob td:nth-child(13), table#logix_CPH_grduncjob td:nth-child(14) {
    max-width: 175px;
    overflow: hidden;
    text-overflow: ellipsis;
}
 
  
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
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
                        <asp:Label ID="lbl_Header" runat="server">Unclosed Job Detail</asp:Label></h4>
                   <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Utility</a> </li>
                            <li><a href="#" title="">Unclosed Job Detail</a> </li>
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
        <div class="btn ico-get">
            <asp:Button ID="btn_Get" Text="Get" runat="server" ToolTip="Get" OnClick="btn_Get_Click" />
        </div>
        <div class="btn ico-excel">
            <asp:Button ID="btnexportexcel" Text="Export Excel" runat="server" ToolTip="Export Excel" OnClick="btnexportexcel_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_Cancel1" runat="server">
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_Cancel_Click" />
        </div>

    </div>
</div>


                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">

                        <div class="Payinput">
                            <asp:Label ID="lbl_From" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_From" runat="server" CssClass="form-control" ToolTip="From"></asp:TextBox>
                        </div>

                        <div class="PaytoInput">
                            <asp:Label ID="lbl_To" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_To" runat="server" CssClass="form-control" ToolTip="To"></asp:TextBox>
                        </div>
                       

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="grd_panel" runat="server" CssClass="gridpnl MB0" ScrollBars="Auto">
                            <asp:GridView ID="grduncjob" runat="server" AutoGenerateColumns="False" Width="100%"
                                ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found" CssClass="Grid FixedHeader" OnRowDataBound="grduncjob_RowDataBound" OnPreRender="grduncjob_PreRender">
                                <Columns>

                                    <asp:BoundField DataField="shortname" HeaderText="Branch" />
                                    <asp:BoundField DataField="Product" HeaderText="Product" />
                                    <asp:BoundField DataField="jobno" HeaderText="BPJ/Job #" />
                                    <asp:BoundField DataField="etd" HeaderText="Job Open Date" />
                                    <asp:BoundField DataField="Salesperson" HeaderText="Sales person" />
                                    <asp:BoundField DataField="customername" HeaderText="Customer Name" />

                                    <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Branchid" HeaderText="Branchid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    <asp:BoundField DataField="MBL" HeaderText="MBL" />
                                    <asp:BoundField DataField="BL" HeaderText="BL" />
                                    <asp:BoundField DataField="Shipper" HeaderText="Shipper" />
                                    <asp:BoundField DataField="Consignee" HeaderText="Consignee" />
                                    <asp:BoundField DataField="POL" HeaderText="POL" />
                                    <asp:BoundField DataField="POD" HeaderText="POD" />
                                    <asp:BoundField DataField="vessel" HeaderText="Vessel/Flight/DOC #" />
                                    <asp:BoundField DataField="ETA" HeaderText="ETA/FLIGHT" />
                                    <asp:BoundField DataField="ETD1" HeaderText="ETD/FLIGHT" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" Wrap="false" />
                                <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_From"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_to"></asp:CalendarExtender>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>unclosedJobDetail #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

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
