<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consolletterrpt.aspx.cs" Inherits="logix.Reportasp.Consolletterrpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>FICAN FORWARDER</title>
<style type="text/css">
.TableHeader1 thead { display:table-header-group;}

</style>
</head>

<body style="font-size:14px; font-family:sans-serif, Geneva, sans-serif; line-height:18px; color:#000;">
 <div style="width:1024px; margin:0px auto; padding:0px; border-bottom:1px solid #000; ">
<div style="float:left; width:100px; margin:5px auto;"> <asp:Image ID="img_Logo" runat="server" width="150px"  /></div>
<div style="width:877px; float:left;">
<h3 style="text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; "><asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<p style="font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_address" runat="server"></asp:Label></p>
<p  style="font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><strong>Tel</strong> : <asp:Label ID="lbl_ph" runat="server"></asp:Label> - <strong>Fax</strong> :<asp:Label ID="lbl_fax" runat="server"></asp:Label></p>

</div>
<div style="clear:both;"></div>
</div>
<div style="clear:both;"></div>
<div style="width:1024px; margin:0px auto; padding:0px 0px 0px 0px;">
<div style="float:left; width:60px; margin:10px 0px 5px 15px; padding:0px 0px 0px 0px; font-weight:bold;">DATE:</div>

<div style="float:left; width:110px; margin:10px 0px 5px 5px; padding:0px 0px 0px 0px;"><asp:Label ID="lbl_date" runat="server"></asp:Label></div>



<div style="float:right; width:110px; margin:10px 0px 5px 5px; padding:0px 0px 0px 0px;"><asp:Label ID="lbl_eta" runat="server"></asp:Label></div>
      <div style="float:right; width:10px; margin:10px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
<div style="float:right; width:50px; margin:10px 0px 5px 15px; padding:0px 0px 0px 0px; font-weight:bold;">ETA</div>

<div style="clear:both;"></div>
<div style="float:left; width:60px; margin:10px 0px 5px 15px; padding:0px 0px 0px 0px; font-weight:bold;">TO</div>
<div style="clear:both;"></div>
<div style="float:left; width:900px; margin:5px 0px 5px 15px; padding:0px 0px 0px 0px; font-weight:bold;">THE Assistant Commissioner of Customs,<br />
 Nhava Sheva.</div>
 <div style="clear:both;"></div>
 <div style="width:1024px; margin:20px 0px 0px 15px; padding:0px 0px 0px 0px; float:left;">
 <div style="float:left; width:450px;">
 <div style="float:left; width:150px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">ARRIVED VSL MV</div>
      <div style="float:left; width:10px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:230px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="lbl_vessel" runat="server"></asp:Label> / <asp:Label ID="lbl_voy" runat="server"></asp:Label></div>
 <div style="clear:both;"></div>
  <div style="float:left; width:150px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">IGM NO / IGM DATE </div>
     <div style="float:left; width:10px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:230px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="lbl_igmno" runat="server"></asp:Label> / <asp:Label ID="lbl_igmdt" runat="server"></asp:Label></div>
  <div style="clear:both;"></div>
   <div style="float:left; width:150px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">MBL NO</div>
     <div style="float:left; width:10px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:230px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="lbl_mbl" runat="server"></asp:Label></div>
   <div style="clear:both;"></div>
   <div style="float:left; width:150px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">ITEM NO</div>
     <div style="float:left; width:10px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:230px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="lbl_itemno" runat="server"></asp:Label></div>
 </div>
 <div style="float:left; width:560px;">
 
  <div style="float:left; width:110px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">ETD</div>
     <div style="float:left; width:15px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:125px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="lbl_etd" runat="server"></asp:Label></div>
  <div style="clear:both;"></div>
  <div style="float:left; width:110px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">VESSEL CODE</div>
     <div style="float:left; width:15px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:125px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="lbl_vesselcode" runat="server"></asp:Label></div>
   <div style="clear:both;"></div>
  <div style="float:left; width:110px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">MBL DT</div>
     <div style="float:left; width:15px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:125px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="mbldt" runat="server"></asp:Label></div>
    <div style="clear:both;"></div>
  <div style="float:left; width:110px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">CARNO</div>
     <div style="float:left; width:15px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:190px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="lbl_carno" runat="server"></asp:Label></div>
     <%--<div style="clear:both;"></div>--%>
  <div style="float:left; width:82px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">IMO CODE</div>
     <div style="float:left; width:18px; margin:5px 10px 5px 0px; font-weight:bold; text-align:left;">:</div>
 <div style="float:left; width:95px; margin:5px 0px 5px 0px; font-weight:normal; text-align:left;"><asp:Label ID="imocode" runat="server"></asp:Label></div>
 
 </div>
 <div style="clear:both;"></div>
 
 </div>
  <div style="width:1024px; margin:20px 0px 0px 0px; padding:0px 0px 0px 0px; float:left;">
<p style="padding:5px 5px 5px 5px; margin:0px 0px 0px 0px;">Enclosed herewith please find a copy of MB/L and HB/L for ready reference
</p>
<div style="width:792px; float:left;">
<div style="width:175px; float:left;margin:0px 0px 0px 15px;">
<p style="font-weight:bold; margin:5px 5px 5px 5px; padding:0px 0px 0px 0px;">CONTAINER NO</p>
<p style="font-weight:normal; margin:5px 5px 5px 5px; padding:0px 0px 0px 0px;"><asp:Label ID="lbl_containerno" runat="server"></asp:Label></p>
</div>
<div style="width:256px; float:left;">
<p style="font-weight:bold; margin:5px 5px 5px 5px; padding:0px 0px 0px 0px;">CONT SIZE</p>
<p style="font-weight:normal; margin:5px 5px 5px 5px; padding:0px 0px 0px 0px;"><asp:Label ID="lbl_contsize" runat="server"></asp:Label></p>
</div>

</div>
</div>


  <div style="width:1024px; margin:10px 0px 0px 0px; padding:0px 0px 0px 0px; float:left;">
  
  <table width="1024" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <th style="padding:5px; margin:0px; width: 45px;border-left:1px solid #000; border-top:1px solid #000; border-bottom:1px solid #000; text-align:center;">SRNO</th>
    <th style="padding:5px; margin:0px;width: 735px;  border-top:1px solid #000; border-bottom:1px solid #000; text-align:left;">Consignee</th>
    <th style="padding:5px; margin:0px;width: 145px;   border-top:1px solid #000; border-bottom:1px solid #000; text-align:left;">B/L#</th>
    <th style="padding:5px; margin:0px; width: 95px;  border-top:1px solid #000; border-bottom:1px solid #000; text-align:left;">B/LDate</th>
    <th style="padding:5px; margin:0px;width: 85px;   border-top:1px solid #000; border-bottom:1px solid #000; text-align:right;">QTY</th>
    <th style="padding:5px; margin:0px;width: 80px;   border-top:1px solid #000; border-bottom:1px solid #000; text-align:right;">GWT [Kgs]</th>
    <th style="padding:5px; margin:0px;width: 50px;   border-top:1px solid #000; border-bottom:1px solid #000; text-align:right;">CBM</th>
    <th style="padding:5px; margin:0px;width: 42px;   border-top:1px solid #000; border-bottom:1px solid #000; border-right:1px solid #000; text-align:center;">TYPE</th>
  </tr>
  <tr>
    <asp:Label ID="lbl_rows" runat="server"></asp:Label>
  </tr>  
  <tr>
  <td style="padding:5px; margin:0px; text-align:left; border-top:1px solid #000; border-bottom:1px solid #000; font-weight:bold;">TOTAL</td>
    <td style="padding:5px; margin:0px; text-align:left;  border-top:1px solid #000; border-bottom:1px solid #000;"></td>
    <td style="padding:5px; margin:0px; text-align:left;  border-top:1px solid #000; border-bottom:1px solid #000;"></td>
    <td style="padding:5px; margin:0px; text-align:left;  border-top:1px solid #000; border-bottom:1px solid #000;"></td>
    <td style="padding:5px; margin:0px; text-align:right;  border-top:1px solid #000; border-bottom:1px solid #000; font-weight:bold;"> <asp:Label ID="lbl_totqty" runat="server"></asp:Label></td>
    <td style="padding:5px; margin:0px; text-align:right;  border-top:1px solid #000; border-bottom:1px solid #000; font-weight:bold;">  <asp:Label ID="lbl_totwt" runat="server"></asp:Label></td>
    <td style="padding:5px; margin:0px; text-align:right;  border-top:1px solid #000; border-bottom:1px solid #000;font-weight:bold;"> <asp:Label ID="lbl_totcbm" runat="server"></asp:Label></td>
    <td style="padding:5px; margin:0px; text-align:left;  border-top:1px solid #000; border-bottom:1px solid #000;"></td>
  
  </tr>
</table>

  </div>
<div style="width:1024px; margin:10px 0px 0px 0px; padding:0px 0px 0px 0px; float:left;">
<p style="padding:5px; margin:0px;">Kindly file the manifest as per above HBLs with separate Consignee's Name,Marks &Nos, and Commodity.</p>

<p style="padding:5px; margin:0px;">Kindly issue the Examination order/ delevery orders against surrendering of the original/ Express Master B/L dully endorsed by us.</p>

<p style="padding:5px; margin:0px;">We hereby indemnify you and your principals from all liablities of customs/port penalties arising our spliting this shipment .</p>
<p style="padding:5px; margin:0px;">Thanking you for your kind cooperation</p>
<p style="padding:15px 5px 5px 5px; margin:0px;">Yours Sincerely,<br />
For <strong><asp:Label ID="lbl_branchname" runat="server"></asp:Label></strong></p>
<p style="padding:30px 5px 5px 5px; margin:0px;"><strong>As Agent</strong></p>
</div>
</div>
</div>

</div>



 

</body>
</html>
