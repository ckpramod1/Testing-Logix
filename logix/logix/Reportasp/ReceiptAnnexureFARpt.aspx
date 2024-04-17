<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptAnnexureFARpt.aspx.cs" Inherits="logix.Reportasp.ReceiptAnnexureFARpt" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title></title>

    <style type="text/css">
        .Div1 {
            width:1012px!important;
        }
        thead {
            display:table-header-group;
        }
    </style>
</head>

<body style="margin:0px; padding:0px; font-family:sans-serif, Geneva, sans-serif; font-size:14px; color:#000; line-height:18px;">
<div style="width:1024px; margin:0px auto;">
<div style="float:right; padding:5px 5px;"><asp:Image ID="img_Logo" runat="server" Width="269" Height="54"/></div>
<div style="width:1024px; float:left; border-top:1px solid #000; border-bottom:1px solid #000; border-left:1px solid #000; border-right:1px solid #000;">
<div style="float:left; text-align:center; width:1024px; border-top:0px solid #000; border-bottom:1px solid #000;">
<div style="float:right; width:70px; padding:0px; margin:5px 5px 0px 0px; text-align:right; font-size:11px;"><asp:Label ID="lblToday" runat="server"></asp:Label></div>
<div style="clear:both;"></div>
<div style="float:left; width:1024px;">
<h3 style="text-transform:capitalize; width:100%; font-family:'Segoe UI'; text-align:center; font-size:24px; font-weight:600; padding:5px 0px 5px 0px; margin:-20px 0px 5px 0px;  float:left;"><asp:Label ID="lblDivName" runat="server"></asp:Label></h3>
<div style="clear:both;"></div>
<p style="font-size:14px; color:#000; line-height:18px; WIDTH:100%;  float:left; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;">
<asp:Label ID="lblAddress" runat="server"></asp:Label><br>
<asp:Label ID="lblphonefax" runat="server"></asp:Label>
</p>
</div>

</div>
<div style="float:left; width:1024px; border-bottom:1px solid #000;">
<h4 style="font-family:'Segoe UI'; font-size:21px; padding:5px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_head" runat="server"></asp:Label></h4>

    
<div style="clear:both;"></div>
    <div style="float:left; width:160px; margin:5px 7px 5px 10px; font-weight:bold;">Receipt # & Date</div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;">:</div>
<div style="float:left; width:440px; margin:5px 5px 5px 0px;"><asp:Label ID="lblRecno" runat="server"></asp:Label></div>

    <div style="float:right; width:120px;">
<div style="float:left; width:auto; margin:5px 5px 5px 5px; text-align:right; font-weight:bold;"><label>ID</label></div>
<div style="float:left; width:2px; margin:5px 5px 5px 5px; text-align:right;">:</div>
<div style="float:left; width:auto; margin:5px 5px 5px 5px; text-align:right; font-weight:bold;"> <asp:Label ID="lblRecId" runat="server"></asp:Label></div>

</div>


</div>

<div style="width:1024px; float:left; border-bottom:1px solid #000;">
    <div style="float:left; width:490px; margin:10px 6px 0px 6px; padding:0px 0px 0px 0px;" id="Div1" runat="server">

    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #000; margin:0px 0px 10px 0px;">
        <thead>
        <tr><th colspan="4" style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-left:1px solid #000; border-top:0px solid #000; border-right:0px solid #000; border-bottom:1px solid #000;">Voucher Details</th></tr>
  <tr>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:80px;">Branch</th>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:120px;">Voucher #</th>
           <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:120px;">Vendor Ref #</th>
     <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:80px;">Date</th>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:1px solid #000; width:150px;">Amount Rs.</th>
  </tr>
  </thead>
                            <asp:Label ID="tr_row" runat="server"></asp:Label>

  <tr>
    <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
     <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp; </td>
      <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp; </td>
    <td style="border-right:0px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-top:1px solid #000; " id="tdRowtotal1" runat="server" visible="false"><asp:Label ID="lbrecpayltotal" runat="server"></asp:Label></td>
  </tr>
    </table>
    </div>
    
   <div style="float:left; width:505px; margin:10px 6px 0px 6px; padding:0px 0px 0px 0px;" id="Div2" runat="server"  >
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #000; margin:0px 0px 10px 0px;">
        <thead>
        <tr><th colspan="4" style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-left:1px solid #000; border-top:0px solid #000; border-right:0px solid #000; border-bottom:1px solid #000;">Voucher Details</th></tr>
  <tr>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:80px;">Branch</th>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:120px;">Voucher #</th>
      <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:120px;">Vendor Ref #</th>
     <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:80px;">Date</th>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:1px solid #000; width:150px;">Amount Rs.</th>
  </tr>
  </thead>
                            <asp:Label ID="tr_row1" runat="server"></asp:Label>

  <tr>
    <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
     <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp; </td>
      <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;">&nbsp; </td>
    <td style="border-right:0px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-top:1px solid #000; "><asp:Label ID="lbrecpayltotal1" runat="server"></asp:Label></td>
  </tr>
    </table>
    </div>
 
  
 
  


</div>


<div style="clear:both;"></div>
</div>
<div style="clear:both;"></div>
</div>
</body>
</html>

