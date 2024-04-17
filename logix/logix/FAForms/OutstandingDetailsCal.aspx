<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="OutstandingDetailsCal.aspx.cs" Inherits="logix.FAForms.OutstandingDetailsCal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <!-- App -->
    <style type="text/css" >
     
   .gridpnl {
    height: calc(100vh - 183px);
    }

   .BacktoPrevious {
    width: 33%;
    text-align: left;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

td.TxtAlign1 {
    text-align: left !important;
}
 
.widget-content {
    padding-top: 57px !important;
}
td.TxtAlign2 {
    text-align: right;
}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <div class="widget-content">
    <div class="FixedButtons" >
        <div class="right_btn" >
    <div class="btn ico-back" id="btn_cancel1" runat="server">
    <asp:Button ID="btnCancel" runat="server" Text="Back" ToolTip="Back" OnClick="btnCancel_Click" />
    </div>
</div>
    </div>
    <div class="FormGroupContent4 boxmodal">

        <asp:Panel ID="PanelCal" runat="server" CssClass="gridpnl MB0" ScrollBars="Both" >
            <asp:GridView ID="GrdCal" runat="server" AutoGenerateColumns="false" Width="100%" Height="100%" EmptyDataText="No Records Found" 
                ShowHeaderWhenEmpty="True" EnableTheming="False" CssClass="Grid FixedHeader" PageSize="500" AllowPaging="false" OnRowDataBound="GrdCal_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="branch" HeaderText="Branch" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Left" /> <%-- 0 --%>
                    <asp:BoundField DataField="trantype" HeaderText="Product" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Left" /><%-- 1 --%>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1" />
                    <%-- 2 --%>
                    <asp:BoundField DataField="vouno" HeaderText="Vou #"><%-- 3 --%>
                        <HeaderStyle Width="50px" Wrap="false" />
                        <ItemStyle Font-Bold="false" Width="50px" Wrap="false" />
                    </asp:BoundField>      
                    <asp:BoundField DataField="voudate" HeaderText="Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Left" /><%-- 4 --%>
                    <%--<asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 160px">
                                <asp:Label ID="voudate" runat="server" Text='<%# Bind("voudate") %>' ToolTip='<%#Bind("voudate")%>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="75px" />
                        <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />
                    </asp:TemplateField>           --%>         
                    
                    <asp:TemplateField HeaderText="Customer"><%-- 5 --%>
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 250px">
                                <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%#Bind("customer")%>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                        <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="amount" HeaderText="Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign2" ItemStyle-HorizontalAlign="Center" /><%-- 6 --%>
                    <asp:BoundField DataField="curr" HeaderText="Curr" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign2" ItemStyle-HorizontalAlign="Left" />
                    <%-- 7 --%>
                    <asp:BoundField DataField="blno" HeaderText="BL #" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1" />
                    <%-- 8 --%>
                    <asp:BoundField DataField="preparedby" HeaderText="Prepared By" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Left" />
                    <%-- 9 --%>
                    <asp:BoundField DataField="approvedby" HeaderText="Approved By" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Left" />
                    <%-- 10 --%>
                
                </Columns>
            </asp:GridView>
        </asp:Panel>

    <asp:Panel ID="panel1" runat="server" CssClass="gridpnl MB0" ScrollBars="Both" Visible="false">
        <asp:GridView ID="GrdLW" runat="server" AutoGenerateColumns="false" Width="100%" Height="100%" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EnableTheming="False"
            CssClass="Grid FixedHeader" OnRowDataBound="GrdLW_RowDataBound" DataKeyNames="bid" PageSize="500" AllowPaging="false"
            OnPageIndexChanging="GrdLW_PageIndexChanging">
            <%-- --%>
            <Columns>
                <asp:TemplateField HeaderText="Date"><%-- 0 --%>
                    <ItemTemplate>
                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 75px">
                            <asp:Label ID="voudate" runat="server" Text='<%# Bind("voudate") %>' ToolTip='<%#Bind("voudate")%>'></asp:Label>
                        </div>

                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" Width="75px" />
                    <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />

                </asp:TemplateField>
                <asp:BoundField DataField="vouno" HeaderText="Vou #"><%-- 1 --%>
                    <HeaderStyle Width="50px" Wrap="false" />
                    <ItemStyle Font-Bold="false" Width="50px" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="BPJ" HeaderText="BPJ"><%-- 2 --%>
                    <HeaderStyle Width="100px" Wrap="false" />
                    <ItemStyle Font-Bold="false" Width="100px" Wrap="false" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ledger"><%-- 21 --%>
                    <ItemTemplate>
                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 250px">
                            <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%#Bind("customer")%>'></asp:Label>
                        </div>

                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                    <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />

                </asp:TemplateField>
                <asp:BoundField DataField="curr" HeaderText="Curr" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <%-- 3 --%>
                <asp:BoundField DataField="fcurr" HeaderText="FCurr" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                <%-- 4 --%>
                <asp:BoundField DataField="vamount" HeaderText="Voucher Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                <%-- 5 --%>
                <asp:BoundField DataField="Receivedamount" HeaderText="Received Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                <%-- 6 --%>
                <asp:BoundField DataField="amount" HeaderText="Pending Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                <%-- 7 --%>
                <asp:BoundField DataField="famount" HeaderText="Voucher Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 8 --%>
                    <HeaderStyle Width="100px" Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="100px" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="recefamount" HeaderText="Received Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                <%-- 9 --%>
                <asp:BoundField DataField="foverdue" HeaderText="Pending Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 10 --%>
                    <HeaderStyle Width="100px" Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="100px" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="trantype" HeaderText="Product#" />
                <%-- 10 --%>
                <asp:BoundField DataField="mblno" HeaderText="MBL #" />
                <%-- 11 --%>
                <asp:BoundField DataField="refno" HeaderText="BL #"><%-- 12 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="true" />
                </asp:BoundField>
                <asp:BoundField DataField="Shipper" HeaderText="Shipper"><%-- 13 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="70px" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="Consignee" HeaderText="Consignee"><%-- 14 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="70px" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="POLCountry" HeaderText="POL Country"><%-- 15 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="PODCountry" HeaderText="POD Country"><%-- 16 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="nodays" HeaderText="No of Days" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <%-- 17 --%>
                <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <%-- 18 --%>

                <asp:BoundField DataField="shortname" HeaderText="Branch"><%-- 19 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" Wrap="false" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Sales Person"><%-- 20 --%>
                    <ItemTemplate>
                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 160px">
                            <asp:Label ID="salesname" runat="server" Text='<%# Bind("salesname") %>' ToolTip='<%#Bind("salesname")%>'></asp:Label>
                        </div>

                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                    <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="quotno" HeaderText="Quotation #"><%-- 23 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="quotcustomer" HeaderText="Quot # Customer"><%-- 24 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                <%-- 25 --%>
                <asp:BoundField DataField="reversal" HeaderText="Reversal" />
                <%-- 26 --%>
                <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #"><%-- 22 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="70px" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="vendordate" HeaderText="VendorDate"><%-- 27 --%>
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="70px" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="GrossAmt" HeaderText="GrossAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="TaxAmt" HeaderText="TaxAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="TDSAmt" HeaderText="TDSAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            </Columns>

            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
            <RowStyle Font-Italic="False" Wrap="false" />
            <FooterStyle CssClass="Footer" />

        </asp:GridView>
        <div class="DivBreak"></div>
                      
        </asp:Panel>
    </div>
        </div>

    
    <asp:HiddenField ID="hid_todate" runat="server" />
    <asp:HiddenField ID="hid_title" runat="server" />


</asp:Content>
