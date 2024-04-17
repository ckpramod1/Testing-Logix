<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PODetailsBooking.aspx.cs" Inherits="logix.PODetailsBooking" %>


<%@ Register assembly="Typad" namespace="Typad" tagprefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
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
        &nbsp;
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:MultiView ID="MultiView1" runat="server">
                                    <asp:View ID="View1" runat="server">
                                                   <table border="1" bordercolor="#000000" cellpadding="2" cellspacing="2">
                                                       <tr >
                                                       <td>
                                                       <table id="TABLE1" cellspacing="0" >
                                <tr style="background-color: #0296f8">
                                                       
                                                       
                                                      
                                                       
                                                           <td align="left" colspan="5">
                                        <asp:Label ID="Label2" runat="server" CssClass="Title">PO Details - Booking</asp:Label>&nbsp;
                                                           </td>
                                </tr>
                                                       <tr>
                                                           <td   nowrap="noWrap" align="right">
                                                               <asp:LinkButton ID="lnkBook" runat="server" ForeColor="Red" 
                                                                   OnClick="lnkBook_Click">Booking #</asp:LinkButton>
                                                           </td>
                                                           <td  >
                                                               <cc1:TypeAhead ID="txtBookingNo" runat="server" AutoPostBack="True" 
                                                                   CaptureField="" Database="SLDB" Database1="SLDB" 
                                                                   ontextchanged="txtBookingNo_TextChanged" TypadMode="PODtls" 
                                                                   TypadMode1="PODtls" CaptureFieldTarget="" CheckFieldValue="BookingNo" />
                                                           </td>
                                                           <td  >
                                        <asp:Label ID="Label3" runat="server" Text="PO #" Width="36px"></asp:Label></td>
                                                           <td align="right"  >
                                        <asp:TextBox ID="txtPONo" runat="server" Width="180px"></asp:TextBox></td>
                                                       </tr>
                                                       <tr>
                                                           <td align="right"  >
                                        <asp:Label ID="Label1" runat="server" Text="Customer" Width="62px"></asp:Label></td>
                                                           <td colspan="3">
                                        <asp:TextBox ID="txtCust" runat="server" Width="408px"></asp:TextBox></td>
                                                       </tr>
                                                        
                                                       <tr>
                                                           <td colspan="4" align="right"  >
                            <asp:Button ID="btnGenXML" runat="server" CssClass="button" Enabled="False" 
                                Text="Create XML " Width="109px" OnClick="btnGenXML_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="button" 
                                Text="Cancel" onclick="btnCancel_Click" /></td>
                                                       </tr>
                                                   </table>
                                                   </td>
                                                        </tr>
                                                        </table>
                                                   <br />
                                                           <asp:Panel ID="Panel1" runat="server" Height="181px" ScrollBars="Auto" Width="686px">
                                                   <asp:GridView ID="grdBoohDtls" runat="server" AutoGenerateColumns="False" BorderColor="White"
                                                BorderWidth="1px" CellPadding="2" CssClass="Others" ForeColor="#333333" Width="98%" OnRowDataBound="grdBoohDtls_RowDataBound" OnSelectedIndexChanged="grdBoohDtls_SelectedIndexChanged">
                                                       <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                       <Columns>
                                                           <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                                               <HeaderStyle Wrap="False" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="pono" HeaderText="PO #">
                                                               <ItemStyle Wrap="False" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="customername" HeaderText="Customer Name" Visible="False" />
                                                           <asp:BoundField DataField="pol" HeaderText="P O L" />
                                                           <asp:BoundField DataField="pod" HeaderText="P O D" />
                                                           <asp:BoundField DataField="fd" HeaderText="F D" />
                                                       </Columns>
                                                       <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                       <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                       <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                       <EditRowStyle BackColor="#999999" />
                                                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                   </asp:GridView>
                                               </asp:Panel>
                                        <br />
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <asp:Panel ID="Panel2" runat="server" Height="429px" ScrollBars="Auto" Width="684px">
                                            <asp:GridView ID="grdBooking" runat="server" AutoGenerateColumns="False" BorderColor="White"
                                                BorderWidth="1px" CellPadding="2" CssClass="Others" ForeColor="#333333" Width="98%" OnRowDataBound="grdBooking_RowDataBound" OnSelectedIndexChanged="grdBooking_SelectedIndexChanged" DataKeyNames="bokno">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" /><RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                                        <HeaderStyle Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="bookingdate" HeaderText="Date">
                                                        <ItemStyle Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                                                    <asp:BoundField DataField="pol" HeaderText="P O L" />
                                                    <asp:BoundField DataField="pod" HeaderText="P O D" />
                                                    <asp:BoundField DataField="fd" HeaderText="F D" Visible="False" />
                                                    <asp:BoundField DataField="bokno" HeaderText="bokno" />
                                                </Columns>
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#999999" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </asp:View>
                                </asp:MultiView>
             
            </ContentTemplate>
                           
        </asp:UpdatePanel>
    
    </div>
    <asp:HiddenField ID="BookingNo" runat="server" />
    </form>
</body>
</html>
