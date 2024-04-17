
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenuList.aspx.cs" Inherits="logix.MainPage.MainMenuList"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="../Styles/MainMenuList.css" rel="stylesheet" type="text/css" />
    


   <style type ="text/css" >
   .div_iframe
{
   
    border:1px solid black;
    float :left;
    height :440px;
    width:99%;
    margin-left :1.2%;
    margin-top :-3%;
   
}
.iframe
{
    height :100%;
    width :100%;
}

   
   </style>
  


</head>
<body>
    <form id="form1" runat="server">
    <div class="div_main">
        <asp:Button ID="button1" runat="server" Text="Click Me" class="btn" 
            onclick="button1_Click1" />
    </div>
   <%--<br/>--%>
  <%-- <div class="Div_Clear"></div>--%>
 <%--   <div class="mar">--%>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
    </asp:UpdatePanel>


        <div class="div_prop" id="mydiv" runat="server" visible="false" >
            <asp:ImageButton ID="img" Style="float: right" runat="server" ImageUrl="~/images/imagesnew.jpg"
                Height="16px" OnClick="img_Click" Width="16px" />
                 <div class="div_menulist" id="div_mlist" runat="server">
                </div>

        </div>

        <div class="div_iframe" runat ="server" id="div_iframe">
        <iframe id="ifrmaster" runat="server"  name="MainFrame" class="iframe" frameborder="1" src="../Maintenance/MasterCargo.aspx" scrolling="no"></iframe>
      
        </div>
    <%--</div>--%>
    <asp:HiddenField ID="hf_menuname" runat="server" />
    </form>
</body>
</html>
 