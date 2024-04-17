<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OSDN.aspx.cs" Inherits="logix.OSDN" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>logix</title>
    <script type="text/javascript" src="Scripts/Calendar.js"></script> 

            <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>


</head>
<body style="margin-left:5px;margin-top:5px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdateProgress id="UpdateProgress1" runat="server">
        <progresstemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
</progresstemplate>
    </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<%--<table cellpadding="2" cellspacing="0" border="1" bordercolor="black"><tr><td>--%>
     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i>Home </li>
           
              <li>Accounts</li>
              <li class="current">OSDN</li>
            </ul>
      </div>

        <!-- Breadcrumbs line -->

             <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header">
                                <h4><i class="icon-umbrella"></i>
                                     OSDN</h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="right_btn MT0">
                                        <div class="btn ico-view"><asp:Button id="btnView" runat="server"  Text="View" OnClick="btnView_Click" /></div>
                                        <div class="btn ico-cancel"><asp:Button id="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="False" /></div>
                                    </div>

                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="OSDNJob"> Job # :</div>

                                    <div class="OSDNJobInput"><asp:TextBox id="txtJobNo" runat="server" AutoPostBack="True" OnTextChanged="txtJobNo_TextChanged" ReadOnly="True" CssClass="form-control" TabIndex="1" placeholder="Job #" ToolTip="Job #"></asp:TextBox></div>
                                    <div class="right_btn MT0">

                                        <div class="OSDNDNNumber">DN #</div>
                                        <div class="OSDNTxtBox"><asp:TextBox id="txtVouNo" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="2" ToolTip="DN #"></asp:TextBox></div>
                                        <div class="OSDNTxtBox1"><asp:TextBox id="txtVouYear" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="3" ToolTip="DN #"></asp:TextBox></div>
                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="CustomerTxtBox"><asp:TextBox ID="txtCustomer" runat="server" TextMode="MultiLine"  TabIndex="4" Height="60px" CssClass="form-control" ReadOnly="True" ToolTip="Customer" placeholder="Customer"></asp:TextBox></div>
                                    <div class="ShipmentDetail"><asp:TextBox ID="txtShipment" runat="server" TextMode="MultiLine"  TabIndex="5" Height="60px" CssClass="form-control" ReadOnly="True" ToolTip="Shipment Details" placeholder="Shipment Details"></asp:TextBox></div>
                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="DebitLbl"> Debit Advise</div>
                                    <div class="DebitTbl">

                                        <asp:Panel id="PnlDA" runat="server" Height="110px" ScrollBars="Vertical"  CssClass="CSTbl">
             <asp:GridView ID="GridDNRpt" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeader="False"  >
             <Columns>
<asp:BoundField ReadOnly="True" DataField="chargename" HeaderText="Charges">
<ItemStyle Width="245px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Curr" HeaderText="Curr">
<ItemStyle Width="65px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="rate" HeaderText="Rate">
<ControlStyle Width="10px"></ControlStyle>

<ItemStyle Width="99px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="exrate" HeaderText="ExRate">
<ItemStyle Width="70px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="base" HeaderText="Base">
<ItemStyle Width="70px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="amount" HeaderText="Amount">
<ItemStyle Width="103px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>
                 <rowstyle cssclass="GrdRow" />
             <PagerStyle HorizontalAlign="Center" />   
             <HeaderStyle CssClass="GrdHeader" HorizontalAlign="Left" Font-Bold="True" />
             <AlternatingRowStyle BackColor="#ECF5FF" CssClass="GrdAltRow" />
             </asp:GridView>
                </asp:Panel>


                                    </div>
                                    </div>

                                <div class="FormGroupContent4">

                                    <div class="DebitLbl">Credit Advise</div>

                                    <div class="DebitTbl">
                                    <asp:Panel id="PnlCA" runat="server" Height="110px" ScrollBars="Vertical" CssClass="CSTbl">
              <asp:GridView ID="GrdCNRpt" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeader="False"  >
              <Columns>
<asp:BoundField ReadOnly="True" DataField="chargename" HeaderText="Charges">
<ItemStyle Width="245px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Curr" HeaderText="Curr">
<ItemStyle Width="65px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="rate" HeaderText="Rate">
<ControlStyle Width="10px"></ControlStyle>

<ItemStyle Width="99px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="exrate" HeaderText="ExRate">
<ItemStyle Width="70px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="base" HeaderText="Base">
<ItemStyle Width="70px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="amount" HeaderText="Amount">
<ItemStyle Width="103px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>
                  <rowstyle cssclass="GrdRow" />
              <PagerStyle BackColor="#63769B" ForeColor="White" HorizontalAlign="Center" />   
              <HeaderStyle BackColor="#63769B" CssClass="GrdHeader" Font-Bold="True" />
              <AlternatingRowStyle BackColor="#ECF5FF" CssClass="GrdAltRow" />
              </asp:GridView>
                </asp:Panel>
</div>

                                </div>
                                <div class="FormGroupContent4">

                                    <div class="right_btn MT0">

                                        <div class="TotlaLBL">Total</div>
                                        <div class="TotalTxtBox"><asp:TextBox id="txtTotal" style="Text-Align:Right" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                    </div>



                                </div>
                                </div>
                            </div>
                        </div>
                         </div>


     
               
         </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
   
