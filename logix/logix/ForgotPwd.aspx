<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPwd.aspx.cs" Inherits="logix.ForgotPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/forgotpwd.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <asp:Panel ID="Panel1" runat="server" CssClass="div_Pnl">
      <div class="lbl_Header">
        <asp:Label ID="lblheader" runat="server" Text="Forgot Password" ></asp:Label> </div>
      <div class="div_lbl">
          <asp:Label ID="Label1" runat="server" Text="Enter Ur MailID"></asp:Label></div>
          <div class="div_txtbox"> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
          <div class="div_break"></div>
                    <div class="div_break"></div>
                    <br />
          <div class="div_btn"> <asp:Button ID="Button1" runat="server" Text="SignIn" onclick="Button1_Click" /></div>

              <asp:HiddenField ID="hdn_pwd" runat="server" />
          </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
