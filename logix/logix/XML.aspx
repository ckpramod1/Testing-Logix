<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XML.aspx.cs" Inherits="logix.XML" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>logix</title>
    <link href="Style/Controls.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Calendar.js"></script> 
</head>
<body style="margin-left:10px;margin-top:10px;">
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
<table cellpadding="2" cellspacing="2" border="1" bordercolor="Black">
<tr>
    <td>
    <table cellspacing="0" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr style="background-color: #0296f8">
            <td colspan="2">
                <asp:Label ID="LBLTitle" runat="server" CssClass="Title">Ocean Exports</asp:Label></td>
            <td colspan="3" align="right"><asp:Button ID="BtnSelect" runat="server" Text="Find" OnClick="BtnSelect_Click" Width="50px" CssClass="button" />
                <asp:Button id="Save" runat="server" OnClick="Save_Click" Text="Create XML " Width="77px" Enabled="False" CssClass="button"></asp:Button>
                <asp:Button id="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="button" /></td>
        </tr>
        
        <tr>
            <td style="text-align: right"><asp:Label ID="Label4" runat="server"  Text="BL #"></asp:Label></td>
            <td><asp:TextBox ID="txtBLNo" runat="server"></asp:TextBox></td>
            <td style="text-align: right"><asp:Label ID="Label3" runat="server"  Text="Booking#" Width="59px"></asp:Label></td>
            <td><asp:TextBox ID="txtBkgNo" runat="server"></asp:TextBox></td>
        </tr>
        
        
        <tr>
            <td style="text-align: right"><asp:Label ID="Label1" runat="server"  Text="From"></asp:Label></td>
            <td><asp:TextBox ID="dtFrom" runat="server" Width="85px"></asp:TextBox><asp:Image ID="ImgFrm" runat="server" Height="19px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="18px" /></td>
            <td style="text-align: right"><asp:Label ID="Label2" runat="server"  Text="To"></asp:Label></td>
            <td><asp:TextBox ID="dtTo" runat="server" Width="85px"></asp:TextBox><asp:Image ID="ImgTo" runat="server" Height="19px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="18px" /></td>
        </tr>
    </table>
    </td>
</tr>    
</table>
   <asp:Label id="lblMsg" runat="server" CssClass="Error"></asp:Label><br />

    

<table>
    <tr>
    <td>
        
        <asp:Panel id="pnl1" runat="server" Height="300px" Width="820px" ScrollBars="Auto">
          <asp:GridView ID="GrdXML" runat="server" AutoGenerateColumns="False" CssClass="Others" OnSelectedIndexChanged="GrdXML_SelectedIndexChanged" Width="98%" BorderWidth="0px" CellPadding="2" ForeColor="#333333" DataKeyNames="branchid,jobno" >
       <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
   <Columns>
<asp:BoundField DataField="branch" HeaderText="Branch">
<ItemStyle Width="70px" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="blno" HeaderText="BL #">
<ItemStyle Width="110px" Wrap="True"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bldate" HeaderText="BL Date">
<ItemStyle Width="70px" Wrap="True"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="vessel" HeaderText="Vessel &amp; Voyage">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="pol" HeaderText="POL">
<ItemStyle Width="85px" Wrap="True"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="pod" HeaderText="POD">
<ItemStyle Width="85px" Wrap="True"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="shipmentstatus" HeaderText="Status">
<ItemStyle Width="173px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="XML">
<ItemStyle Width="40px"></ItemStyle>

<HeaderStyle Wrap="False"></HeaderStyle>
<ItemTemplate>
            <asp:CheckBox ID="XmlChk" runat="server"/>
            
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="branchid" Visible="False">
<ControlStyle BorderStyle="None"></ControlStyle>

<ItemStyle BackColor="AliceBlue" BorderStyle="None" Width="1px" ForeColor="AliceBlue" Wrap="True"></ItemStyle>

<HeaderStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue"></HeaderStyle>

<FooterStyle BorderStyle="None"></FooterStyle>
</asp:BoundField>
       <asp:BoundField DataField="jobno" Visible="False" />
</Columns>
       <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
       <editrowstyle backcolor="#999999" />
       <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
       <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
       <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
       <alternatingrowstyle backcolor="White" forecolor="#284775" />
  </asp:GridView>
        </asp:Panel>
  </td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>

