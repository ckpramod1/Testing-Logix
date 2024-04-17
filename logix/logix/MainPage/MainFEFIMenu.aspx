<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainFEFIMenu.aspx.cs" Inherits="logix.MainPage.MainListText" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/MainListText.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
        .btnOval
        {
            border: solid 1px;
            border-color: Black;
            background-color: #858566;
            font-family: sans-serif;
            font-size: 20px;
            border-radius: 80px 80px 80px 80px;
            color: white;
           /* width: 150px;
            height: 145px;*/
            width:100%;
            height:100%;
        }
        .btnOval:hover
        {
            cursor: pointer;
            border: solid 1px;
            border-color: White;
            background-color: #9D9D85;
            font-family: sans-serif;
            font-size: 22px;
            color: White;
        }
        .div_topfirst
        {
        border: 1px solid black;
       width:12%;
       height:78%;
       float:left ;
       margin-left :26%;
       border-radius: 80px 80px 80px 80px; 
        }
        .div_bottomfirst
        {
       border: 1px solid black;
       width:12%;
       height:78%;
       float:left ;
       margin-left :26%;
       border-radius: 80px 80px 80px 80px;   
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div class="Maindiv">
        <div class="submenu">
            <div class="sidemenu_top ">
            <div class="div_topfirst"><asp:Button ID="btn_OE" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Sales" /></div>
            <div class="box1"><asp:Button ID="Button1" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="CRM" /></div>
            <div class="box1"><asp:Button ID="Button2" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Operations" /></div>
         <%--   <div class="box1"><asp:Button ID="Button3" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="HRM" /></div>--%>
         </div> 
    
            <div class="sidemenu_bottom">
            <div class="div_bottomfirst"><asp:Button ID="Button4" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Accounts" /></div>
            <div class="box1"><asp:Button ID="Button5" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Approval" /></div>
            <div class="box1"><asp:Button ID="Button6" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="MIS" /></div>
     <%--       <div class="box1"><asp:Button ID="Button7" runat="server" OnClick="btn_OE_Click" CssClass="btnOval" Text="Maintenance"/></div>--%>
            </div>


    </div>
    </div>
    </form>
</body>
</html>
