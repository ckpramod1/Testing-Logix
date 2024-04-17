<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainModule.aspx.cs" Inherits="logix.MainPage.MainList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../Styles/MainModule.css" rel="Stylesheet" type="text/css" />
      <style type="text/css">
       .Text_button
       {
     /*  border: 1px solid black;*/
       width:12%;
       height:78%;
       float:left ;
       margin-left :11%;
       border-radius: 80px 80px 80px 80px; 
       } 
       .div_text
       {
       margin-top :-35%;
       width:100%;
       opacity:0%;
       /*border:1px solid red;*/
       height :100%;
       font-size: 22px;
       }
      </style>
</head>
<body>
    <form id="form1" runat="server">
   <div class="Maindiv">
        <div class="submenu">
            <div class="sidemenu_top ">
            
            <div class="box1"><asp:ImageButton ID="btn_OceanExport" runat="server" ImageUrl="~/images/Ocean_exports.jpg"  CssClass="div_img " onclick="btn_OceanExport_Click"/>
     <%-- <div class="div_text"><span class="div_text">Ocean Exports</span></div>--%>
            </div>
            <div class="box1"><asp:ImageButton ID="btn_OceanImport" runat="server"   ImageUrl="~/images/imagess.jpg"  CssClass="div_img " onclick="btn_OceanImport_Click"/></div>
            <div class="box1"><asp:ImageButton ID="btn_AirExport" runat="server"  ImageUrl="~/images/Air Export.jpg" CssClass="div_img " onclick="btn_AirExport_Click"/></div>
            <div class="box1"><asp:ImageButton ID="btn_AirImport" runat="server"   ImageUrl="~/images/Airimport.jpg"  CssClass="div_img" onclick="btn_AirImport_Click"/></div>
            <div class="box1"><asp:ImageButton ID="btn_Cha" runat="server" ImageUrl="~/images/CHA.jpg" CssClass="div_img "/></div>
            <div class="box1"><asp:ImageButton ID="btn_FinacialAccounts" runat="server" ImageUrl="~/images/Finacial accounts.jpg"  CssClass="div_img"/></div>
            </div>
            <div class="sidemenu_bottom">
            <div class="box1"><asp:ImageButton ID="btn_BondedTrucking" runat="server" ImageUrl="~/images/Bonded trucking.jpg"  CssClass="div_img "/></div>
            <div class="box1"><asp:ImageButton ID="btn_OperationAcc" runat="server" ImageUrl="~/images/Operatingaccounts.gif" CssClass="div_img "/></div>
            <div class="box1"><asp:ImageButton ID="btn_hr" runat="server" ImageUrl="~/images/Hr.jpg"  CssClass="div_img"/></div>
            <div class="box1"><asp:ImageButton ID="btn_Maintenance" runat="server"  ImageUrl="~/images/Maintenance.jpg" CssClass="div_img"  onclick="btn_Maintenance_Click"/></div>
            <div class="box1"><asp:ImageButton ID="btn_AgencyExport" runat="server"  ImageUrl="~/images/Agencyexports.jpg"  CssClass="div_img " onclick="btn_AgencyExport_Click"/></div>
            <div class="box1"><asp:ImageButton ID="btn_AgencyImport" runat="server"  ImageUrl="~/images/agencyImports.jpg"  CssClass="div_img "   onclick="btn_AgencyImport_Click"/></div>
            </div>
    </div>
    </div>
    </form>
</body>
</html>
