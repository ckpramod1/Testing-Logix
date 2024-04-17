<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportView.aspx.cs" Inherits="logix.ReportView" %>
 <%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
     </style>
</head>
<body>
    <form id="form1" runat="server">
         <CR:CrystalReportViewer ID="Crv" runat="server" 
            AutoDataBind="true" DisplayGroupTree="False" PrintMode="ActiveX" 
            ReuseParameterValuesOnRefresh="True" />
         <asp:Label ID="lblSF" runat="server" ForeColor="Black" Visible="False"></asp:Label>
        <asp:Label ID="lblPM" runat="server" ForeColor="Black" Visible="False"></asp:Label>
        <asp:Label ID="lblRpt" runat="server" ForeColor="Black" Visible="False"></asp:Label>
    </form>
</body>
</html>
