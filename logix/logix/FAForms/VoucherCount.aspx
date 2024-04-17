<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="VoucherCount.aspx.cs" Inherits="logix.FAForm.VoucherCount" %>

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
    <link href="../Styles/vouchercount.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <%--<script src="../Scripts/ScrollableGridPlugin.js" type ="text/javascript" ></script>
    <link href="../Styles/chosen.css" rel="stylesheet" type ="text/css" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function pageLoad(sender, args) 
        {
            $(document).ready(function () 
            {
                $('#<%=grd.ClientID %>').Scrollable();
                $('#<%=grdvouchers.ClientID %>').Scrollable();
            });
        }

    </script>--%>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <%--<script type="text/javascript">
   function pageLoad(sender, args)
    {       
        $(document).ready(function () {
            $('#<%=grdvouchers.ClientID%>').gridviewScroll({               
                height: 360,
                arrowsize: 20,
                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
    }
    </script>--%>

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

    <style type="text/css">
        .TextAlign {
            text-align: left !important;
        }

        .VtoCal {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VfromCal {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VFromLBL {
            width: 3%;
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .VBranchDrop {
    width: 8%;
    float: left;
    margin: 0px 0% 0px 0px;
}

        .VtoLbl {
            width: 2%;
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VBranch {
            width: 4%;
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LabelValue {
            font-weight: bold;
            font-family: sans-serif;
        }

        .row {
            height: 566px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .divFAGrid {
            width: 100%;
            height: 231px;
            border: 1px solid #b1b1b1;
            overflow: auto;
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

        /* FixedHeader */
        .widget.box {
            position: relative;
            top: -8px;
        }

        .right_btn {
            margin: 6px 0px 0px 0px;
        }

        span#logix_CPH_lblvou {
            margin-top: 5px;
            display: inline-block;
        }
 
        .widget.box .widget-content {
    top: 0px !important;
    padding-top:65px !important;
}
        
 table#logix_CPH_grd th:nth-child(2),table#logix_CPH_grd th:nth-child(3),table#logix_CPH_grd th:nth-child(4) {
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
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="LblHead" runat="server" Text=""></asp:Label></h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Utility</a> </li>
                            <li><a href="#" title="">Voucher Count - Ops Vs FA   </a></li>
                            <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>
                    

                                        <div class="FixedButtons">
                        <div class="right_btn">
    <div class="btn ico-get">
        <asp:Button ID="btn_get" runat="server" Text="Get" ToolTip="Get" OnClick="btn_get_Click" />
    </div>
    <div class="btn ico-cancel" id="btn_back1" runat="server">
        <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" />
    </div>
</div>
                    </div>


                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">

                        <div class="VfromCal">
                            <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="Txtfrom" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="VtoCal">
                            <asp:Label ID="lblto" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="Txtto" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="VBranchDrop">
                            <asp:Label ID="lblbranch" runat="server" Text="Branch"></asp:Label>
                            <asp:DropDownList ID="ddlbranch" runat="server" Height="23px" CssClass="chzn-select" data-placeholder="Branch" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl MB0">
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grd_RowDataBound"
                                OnSelectedIndexChanged="grd_SelectedIndexChanged" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grd_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="voutype" HeaderText="Voucher Type">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="TextAlign" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="logix" HeaderText="OPS" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="logixfa" HeaderText="FA" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="diff" HeaderText="Diff" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                </Columns>
                                <AlternatingRowStyle CssClass="GrdRowStyle" />
                                <HeaderStyle CssClass="" />
                                <RowStyle CssClass="GridviewScrollItem" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>

                            <asp:GridView ID="grdvouchers" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grdvouchers_RowDataBound" CssClass="Grid FixedHeader">
                                <Columns>
                                    <asp:BoundField HeaderText="S.No" HeaderStyle-Width="50px" ItemStyle-Width="50px" />
                                    <asp:BoundField DataField="vouno" HeaderText="Voucher #" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="left" CssClass="TextAlign" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="voudate" HeaderText="Voucher Date" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="transferon" HeaderText="Transfered On" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vouamount" HeaderText="Amount" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cancelled" HeaderText="Status" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Transfer">
                                        <ItemTemplate>
                                            
                                            <asp:ImageButton ID="btn_Transfer" Visible='<%# Eval("cancelled").ToString().Equals("") %>' runat="server" ImageUrl="../images/transfer.png" Style="width: 20px; height: 20px; margin-left: 1%;" OnClick="btn_Transfer_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <AlternatingRowStyle CssClass="GrdRowStyle" />
                                <HeaderStyle CssClass="" />
                                <RowStyle CssClass="GridviewScrollItem" />
                                <PagerStyle CssClass="GridviewScrollPager" />

                            </asp:GridView>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="lblvou" runat="server" Text="" CssClass="LabelValue"></asp:Label>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Panel CssClass="" ID="pnlvouchers" runat="server" Visible="false">
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:CalendarExtender ID="from" runat="server" TargetControlID="Txtfrom" Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="to" runat="server" TargetControlID="Txtto" Format="dd/MM/yyyy"></asp:CalendarExtender>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>VoucherCount #</label>

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
