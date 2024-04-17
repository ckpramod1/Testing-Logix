<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Annexurereport.aspx.cs" Inherits="logix.Reportasp.Annexurereport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Annexure</title>
<style type="text/css">
.TableHeader thead {display: table-header-group;}

</style>
</head>

<body>
    <div style="width:1024px; margin:0px auto; padding:0px; border-bottom:1px solid #000; ">
<div style="float:left; width:100px; margin:5px auto;"> <asp:Image   ID="lbl_img" runat="server"   width="150px"  /></div>
<div style="width:877px; float:left;">
<h3 style="text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; "><asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<p style="font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_address" runat="server"></asp:Label></p>
<p  style="font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><strong>Tel</strong> : <asp:Label ID="lbl_ph" runat="server"></asp:Label> - <strong>Fax</strong> :<asp:Label ID="lbl_fax" runat="server"></asp:Label></p>

</div>
<div style="clear:both;"></div>
</div>
    <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>
</body>
</html>
