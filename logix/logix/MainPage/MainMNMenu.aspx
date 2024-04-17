<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMNMenu.aspx.cs" Inherits="logix.MainPage.MainListMaintenanace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/MainMNMenu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="Maindiv">
            <div class="submenu">
            <%--<div class="sidemenu_top ">--%>
            <div class="boxmasters"><asp:Button ID="btnmaster" runat="server" CssClass="btnOval" Text="Masters" onclick="btnmaster_Click" /></div>
            <div class="boxsystems"><asp:Button ID="btnsystems" runat="server" CssClass="btnOval" Text="Systems" /></div>
            <%--<div class="box1"><asp:Button ID="Button2" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Operations" /></div>--%>
            <%--</div>--%>

          <%--  <div class="sidemenu_bottom">
            <div class="div_bottomfirst"><asp:Button ID="Button4" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Accounts" /></div>
            <div class="box1"><asp:Button ID="Button5" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Approval" /></div>
            <div class="box1"><asp:Button ID="Button6" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="MIS" /></div>
            </div>--%>
    </div>
   </div>
    </form>
</body>
</html>
