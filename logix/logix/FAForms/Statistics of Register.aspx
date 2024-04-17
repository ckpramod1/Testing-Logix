<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Statistics of Register.aspx.cs" Inherits="logix.FAForm.Statistics_of_Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <!--=== JavaScript ===-->

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    <link href="../CSS/Finance.css" rel="stylesheet" />

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
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <link href="../Styles/statisticsofregister.css" rel="stylesheet" />

    <style type="text/css">
        .VouTypeDrop {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VouFrom {
            width: 3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VouFromTxtbox {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VouTo {
            width: 2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VouToInput {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_lbl3 {
            width: 23%;
            float: left;
            margin-left: 0%;
            margin-top: 1%;
        }

        .div_lbl4 {
            width: 14%;
            float: left;
            margin-left: 0%;
            margin-top: 1%;
        }

        .row {
            height: 560px !important;
            margin: 5px 5px 0px -10px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .StaticGridS {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
            height: 350px;
            border: 0px solid #b1b1b1;
            overflow: auto;
        }
        .widget.box {
            position: relative;
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

        .chzn-drop {
            height: 500px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .btn.btn-view1 {
            margin: 16px 0px 0px;
        }
 
      .widget-content {
    padding-top: 55px !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_title" runat="server" Text="Statistics of Register"></asp:Label></h4>
                     <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs1" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Reports</a> </li>
            <li><a href="#" title="">Statistics Register </a></li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>
                <div class="widget-content">
                    <div class="FixedButtons">
                         <div class="right_btn">
 <div class="btn ico-get">
     <asp:Button ID="btn_get" runat="server" Text="Get" ToolTip="Get" OnClick="btn_view_Click" />
 </div>
 <div class="btn ico-print" id="print_id" runat="server" Visible="false" >
     <asp:Button ID="btn_print" runat="server" Text="Print" ToolTip="Print" OnClick="btn_print_Click" Visible="false" />
 </div>
 <div class="btn ico-excel">
     <asp:Button ID="btn_export" runat="server" Text="Export Excel" ToolTip="Export Excel" OnClick="btn_export_Click" />
 </div>
 <div class="btn ico-cancel" id="btn_back1" runat="server">
     <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" />
 </div>

     </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="div_lbl" style="display: none;">
                            <asp:Label ID="lbl_voutype" runat="server" Text="VoucherType" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="VouTypeDrop">
                            <asp:Label ID="Label1" runat="server" Text="Voucher Type"> </asp:Label>
                            <asp:DropDownList ID="ddl_voucher" CssClass="chzn-select" Height="23" runat="server" dataPlaceholder="Voucher Type" AutoPostBack="true" OnSelectedIndexChanged="ddl_voucher_SelectedIndexChanged">
                                <asp:ListItem Value="">Voucher Type</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="VouFromTxtbox">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_from_TextChanged" ToolTip="From"></asp:TextBox>
                        </div>

                        <div class="VouToInput">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_to_TextChanged" ToolTip="To"></asp:TextBox>
                        </div>
                       

                    </div>

                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4 hide">
                        <div class="div_lbl3">
                            <asp:Label ID="lbl_titl" runat="server"></asp:Label>
                        </div>
                        <div class="div_lbl4">
                            <asp:Label ID="lbl_titl1" runat="server"></asp:Label>
                        </div>
                        <div class="div_lbl3">
                            <asp:Label ID="lbl_titl2" runat="server"></asp:Label>
                        </div>

                    </div>
                    <div class="FormGroupContent4 ">
                        <div class="gridpnl">
                            <asp:GridView ID="grdGroup" runat="server" AutoGenerateColumns="false" Width="100%" Height="70%" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found"
                                CssClass="Grid FixedHeader" OnRowDataBound="grdGroup_RowDataBound" OnPreRender="grdGroup_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="voudate" HeaderText="vou date" HeaderStyle-Width="100px" ItemStyle-Width="100px"></asp:BoundField>
                                    <asp:BoundField DataField="vouno" HeaderText="Vou # " HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                                    <asp:BoundField DataField="customername" HeaderText="Customer"></asp:BoundField>
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                                    <%-- <asp:TemplateField>
                    <ItemTemplate>                        
                        <asp:LinkButton ID="link_Contra" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                    </ItemTemplate>                    
                      <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>--%>
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
    </div>

    <div class="div_Break"></div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Statistics ofRegister#</label>

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hf_Date" runat="server" />
    <asp:HiddenField ID="vouchertype" runat="server" />
    <asp:CalendarExtender ID="ce_voudate" runat="server" TargetControlID="txt_from" Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="ce_voudate1" runat="server" TargetControlID="txt_to" Format="dd/MM/yyyy"></asp:CalendarExtender>
    <div class="div_Break"></div>

    <asp:HiddenField ID="Voutype_ID" runat="server" />
</asp:Content>
