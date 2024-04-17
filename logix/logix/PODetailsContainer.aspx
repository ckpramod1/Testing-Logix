<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PODetailsContainer.aspx.cs" Inherits="logix.PODetailsContainer" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<%@ Register assembly="Typad" namespace="Typad" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>logix</title>
    <link href="Style/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:MultiView ID="MultiView1" runat="server">
                                    <asp:View ID="View1" runat="server">
                                       <table border="1" bordercolor="black" cellpadding="2" cellspacing="2">
                    <tr>
                        <td align="right">
                            <table id="TABLE1" cellspacing="0" >
                                <tr style="background-color: #0296f8">
                                    <td align="center" colspan="4">
                                        <asp:Label ID="LBLTitle" runat="server" CssClass="Title">PoContainerDetails</asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td nowrap="nowrap" style="text-align: right">
                                        <asp:LinkButton ID="lnkbook" runat="server" ForeColor="Red" 
                                            onclick="lnkbook_Click">Booking #</asp:LinkButton>
                                    </td>
                                    <td align="left">
                                        <cc1:TypeAhead ID="txtBookNo" runat="server" AutoPostBack="True" 
                                            Database="SLDB" Database1="SLDB" ontextchanged="txtBookNo_TextChanged" 
                                            TypadMode="PODtlsforContainer" TypadMode1="PODtlsforContainer" Width="150px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label3" runat="server" Text="PO #" Width="59px"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtpoNo" runat="server" Width="119px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label2" runat="server" Text="Container #"></asp:Label></td>
                                    <td align="left" colspan="3">
                                        <asp:TextBox ID="txtcontno" runat="server" Width="408px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label1" runat="server" Text="Customer"></asp:Label></td>
                                    <td colspan="3" align="left">
                                        <asp:TextBox ID="txtcustomer" runat="server" Width="408px"></asp:TextBox></td>
                                </tr>
                            </table>
                            <asp:Button ID="btnxml" runat="server" CssClass="button" Enabled="False" 
                                Text="Create XML " Width="77px" onclick="btnxml_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="button" 
                                Text="Cancel" onclick="btnCancel_Click" /></td>
                    </tr>
                </table>
                                        <br />
                                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="684px">
                                                   <asp:GridView ID="grdpo" runat="server" AutoGenerateColumns="False" 
                                                       BorderColor="White" BorderWidth="1px" CellPadding="2" CssClass="Others" 
                                                       ForeColor="#333333" onrowdatabound="grdpo_RowDataBound" 
                                                       onselectedindexchanged="grdpo_SelectedIndexChanged" Width="98%">
                                                       <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                       <Columns>
                                                           <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                                               <HeaderStyle Wrap="False" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="pono" HeaderText="PO #" />
                                                           <asp:BoundField DataField="containerno" HeaderText="Container #">
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="pol" HeaderText="PoL" />
                                                           <asp:BoundField DataField="pod" HeaderText="PoD" />
                                                       </Columns>
                                                       <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                       <EditRowStyle BackColor="#999999" />
                                                       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                       <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                       <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                   </asp:GridView>
                                        </asp:Panel>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <asp:Panel ID="Panel2" runat="server" Height="429px" ScrollBars="Auto" 
                                            Width="684px">
                                            <asp:GridView ID="grdBookno" runat="server" AutoGenerateColumns="False" BorderColor="White"
                                                BorderWidth="1px" CellPadding="2" CssClass="Others" ForeColor="#333333" 
                                                Width="97%" onrowdatabound="grdBookno_RowDataBound" 
                                                onselectedindexchanged="grdBookno_SelectedIndexChanged" 
                                                DataKeyNames="bokno">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                                        <HeaderStyle Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="bookingdate" HeaderText="BookingDate">
                                                        <ItemStyle Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="customername" HeaderText="Customer" />
                                                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                                                    <asp:BoundField DataField="pod" HeaderText="PoD" />
                                                    <asp:BoundField DataField="fd" HeaderText="FD" />
                                                    <asp:BoundField DataField="bokno" HeaderText="bookno" Visible="False" />
                                                </Columns>
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <EditRowStyle BackColor="#999999" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </asp:View>
                                </asp:MultiView>
             
            </ContentTemplate>
                           
        </asp:UpdatePanel>
                
    
    </div>
    </form>
</body>
</html>

