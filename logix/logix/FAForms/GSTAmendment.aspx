<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="GSTAmendment.aspx.cs" EnableEventValidation="false" Inherits="logix.FAForms.GSTAmendment" %>

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

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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

    <link href="../Styles/Voucher.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

            });
            <%-- $(document).ready(function () {
                 $('#<%=Grd_detail.ClientID%>').gridviewScroll({
                    width: 640,
                    height: 200,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        .div_Grid {
            float: left;
            height: 322px;
            margin-left: 0;
            margin-top: 0;
            overflow: auto;
            width: 100%;
        }

        .TotalInput1 {
            float: right;
            margin: 0px 0 0;
            width: 115px;
        }
        table input[type="text"], table input[type="checkbox"] {
    margin: 0px !important;
    border: 1px solid var(--inputborder)!important;
}
        .Grid {
            border: 1px solid #b1b1b1;
            height: auto;
            margin: 0;
            overflow-x: hidden;
            overflow-y: auto;
            width: 100%;
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
     .ModeDropCN3 {
    width: 15%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
     .VoucherTax {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 
     .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
     div#UpdatePanel1 {
    /* height: 100vh; */
    height: 89vh;
    overflow-x: hidden;
    overflow-y: auto;
}
     .TotalInput1.TextField span {
    text-align: right;
}
     .vendor{
         width:41%;
         float:left;
         margin:0px 0.5% 0px 0px;

     }

     .detail{
    width:30%;
    float:left;
    margin:0px 0px 0px 0px;

}
     .YearTax {
    width: 4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <!-- Breadcrumbs line -->
    <div class="crumbs" style="display: none;">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Utility</a> </li>
            <li class="current"><a href="#" title="">GST Amendment</a> </li>
        </ul>
    </div>
   
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="GST Amendment"></asp:Label></h4>
                     <!-- /Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
            <li><a href="#" title="">GST Amendment</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                     <div class=" FixedButtons">
      <div class="right_btn">
         <div class="btn ico-update">
             <asp:Button ID="btn_update" runat="server" Text="Update" ToolTip="Update" OnClick="btn_update_Click" />
         </div>
         <div class="btn ico-view">
             <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
         </div>
         <div class="btn ico-cancel" id="btn_cancel1" runat="server">
             <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
         </div>
     </div>
 </div>


                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ModeDropCN3">
                            <asp:Label ID="Label1" runat="server" Text="Voucher Type"> </asp:Label>
                            <asp:DropDownList ID="ddl_voucher" Height="23px" runat="server" CssClass="chzn-select" data-placeholder="Voucher Type" ToolTip="Voucher Type">
                                <asp:ListItem Value="P">Purchase Invoice</asp:ListItem>
                                <asp:ListItem Value="S">Admin Purchase Invoice</asp:ListItem>
                                <asp:ListItem Value="E">Other Credit Note</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="VoucherTax">
                            <asp:Label ID="Label2" runat="server" Text="Voucher #"> </asp:Label>
                            <asp:TextBox ID="txt_receipt" runat="server" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_receipt_TextChanged" placeholder="" ToolTip="Voucher #"></asp:TextBox>
                        </div>
                        <div class="YearTax">
                            <asp:Label ID="Label3" runat="server" Text="Year"> </asp:Label>
                            <asp:TextBox ID="txt_year" runat="server" Data-placeholder="" ToolTip="Year" CssClass="form-control"></asp:TextBox>
                        </div>
                       
                   

               
                    <div class="vendor">
                        <asp:Label ID="Label4" runat="server" Text="Vendor Name"> </asp:Label>
                        <asp:TextBox ID="txt_received" runat="server" ReadOnly="True" CssClass="form-control" placeholder="" ToolTip="Customer Name"></asp:TextBox>
                   </div>
                    <div class="detail">
             
                        <asp:Label ID="Label5" runat="server" Text="Details"> </asp:Label>
                        <asp:TextBox ID="txt_detail" runat="server" ReadOnly="True"  Style="resize: none;" Rows="3" placeholder="" ToolTip="Details"
                            Width="100%" CssClass="form-control" EnableTheming="True"></asp:TextBox>
                  
                      
                  </div>
                         </div>
                    <div class="FormGroupContent4 boxmodal ">
                          <div class="FormGroupContent4 hide">
                        <asp:Label ID="lbl_charge" runat="server" Text="Charges"></asp:Label>
                    </div>
                    <div class="FormGroupContent4">

                        <div class="gridpnl MB0">
                            <%--   <asp:GridView ID="Grd_Charge" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" CssClass="Grid FixedHeader" DataKeyNames="charges,groupid">
            <Columns>
                <asp:BoundField DataField="charge" HeaderText="Charges" />
                <asp:BoundField DataField="curr" HeaderText="Curr" />
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="exrate" HeaderText="ExRate" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="base" HeaderText="Base/Unit" />
                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" 
                    ItemStyle-HorizontalAlign="Right">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>--%>
                            <asp:GridView ID="Grd_Charge" runat="server" AutoGenerateColumns="False" Width="100%"
                                ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader"
                                OnSelectedIndexChanged="Grd_Charge_SelectedIndexChanged" OnPreRender="Grd_Charge_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="charge" HeaderText="Charges" ItemStyle-HorizontalAlign="Left" />

                                    <%--<asp:TemplateField HeaderText ="Charges" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:180px">
                       <asp:Label ID="charge" runat="server" Text='<%# Bind("charge") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="10px"  HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>                      
             </asp:TemplateField>--%>

                                    <asp:BoundField DataField="curr" HeaderText="Curr" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px" ItemStyle-Width="80px" />

                                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="100px" ItemStyle-Width="100px">

                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="exrate" HeaderText="ExRate" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <ItemStyle HorizontalAlign="Left"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="base" HeaderText="Base/Unit" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="CGST" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemTemplate>
                                            <asp:TextBox ID="cgsta" runat="server" Text='<%# Eval("txtcgsta") %>' Style="text-align: right; width: 100%;"
                                                onkeyup="return IsDoubleCheck_Grid(this);" AutoPostBack="true" OnTextChanged="cgsta_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="SGST" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemTemplate>
                                            <asp:TextBox ID="sgata" runat="server" Text='<%# Eval("txtsgata") %>' Style="text-align: right; width: 100%;"
                                                onkeyup="return IsDoubleCheck_Grid(this);" AutoPostBack="true" OnTextChanged="sgata_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        <HeaderStyle Width="100px" />

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IGST" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemTemplate>
                                            <asp:TextBox ID="igsta" runat="server" Text='<%# Eval("txtigsta") %>' Style="text-align: right; width: 100%;"
                                                onkeyup="return IsDoubleCheck_Grid(this);" AutoPostBack="true" OnTextChanged="igsta_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        <HeaderStyle Width="100px" />

                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Total Amount" HeaderText="Total" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"  HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="false" />
                                        <ItemStyle HorizontalAlign="right" Width="100px" Wrap="false" />
                                    </asp:BoundField>

                                    <%-- <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">          
                </asp:BoundField>--%>
                                    <asp:BoundField DataField="groupid" HeaderText="groupid">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="chargeid" HeaderText="chargeid">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <%--<asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="select" ImageUrl="~/images/edit.gif" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>
                        </div>

                    </div>
                                      
                    <%-- <div class="FormGroupContent4">

                      <div class="div_GridTax">
        <asp:GridView ID="Grd_Tax" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" CssClass="Grid FixedHeader" DataKeyNames="charges,groupid">
            <Columns>
                <asp:BoundField DataField="charge" HeaderText="Charges" />
                <asp:BoundField DataField="curr" HeaderText="Curr" />
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="exrate" HeaderText="ExRate" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="base" HeaderText="Base/Unit" />
                <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_amount" runat="server" Text='<%# Eval("amount") %>' Style="text-align: right;
                            width: 150px;" onkeyup="return IsDoubleCheck_Grid(this);" AutoPostBack="true" OnTextChanged="TxtTotal_Click"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>

                </div>--%>
                    <div class="FormGroupContent4">
                        <div class="TotalInput1 ">
                            <asp:Label ID="Label7" runat="server" CssClass="hide" Text="Amount"> </asp:Label>
                            <asp:TextBox ID="txt_total" ToolTip="Amount" Placeholder="" runat="server" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                        </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_trantype" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_horm" runat="server" />
    <asp:HiddenField ID="hid_Custtype" runat="server" />
    <asp:HiddenField ID="hid_ind" runat="server" />
    <asp:HiddenField ID="hid_supplyto" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Ledger #</label>

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
