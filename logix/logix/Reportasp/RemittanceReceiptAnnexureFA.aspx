<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemittanceReceiptAnnexureFA.aspx.cs" EnableEventValidation="false" Inherits="logix.Reportasp.RemittanceReceiptAnnexureFA" %>

<!DOCTYPE html>

<html>
<head>
<meta charset="utf-8">
<title></title>

<style type="text/css">
table#TblHead thead
	
	{display: table-header-group;}
	
	  .Div1 {
            width:1044px!important;
        }
	
    .auto-style1 {
        height: 21px;
    }
    .auto-style2 {
        width: 70px;
        height: 21px;
    }

    thead {
        display:table-header-group;
    }




</style>
    
   
</head>

<body style="margin:0px; padding:0px; font-family:sans-serif, Geneva, sans-serif; font-size:11px; color:#000; line-height:18px;">
        <form id="form1" runat="server">
<div style="width:1050px; margin:0px auto;">
<div style="float:right; padding:2px 5px;"><asp:Image ID="img_Logo" runat="server" Width="269" Height="54"/></div>
<div style="width:1050px; float:left; border-top:1px solid #000; border-bottom:1px solid #000; border-left:1px solid #000; border-right:1px solid #000;">
<div style="float:left; text-align:center; width:1050px; border-top:0px solid #000; border-bottom:1px solid #000;">
<div style="float:right; width:70px; padding:0px; margin:2px 5px 0px 0px; text-align:right; font-size:11px;"><asp:Label ID="lblToday" runat="server"></asp:Label></div>
<div style="clear:both;"></div>
<div style="float:left; width:1050px;">
<table width="1050px" cellpadding="0" cellspacing="0" id="TblHead">
<thead>
<th>
<h3 style="text-transform:capitalize; width:100%; font-family:'Segoe UI'; text-align:center; font-size:24px; font-weight:600; padding:2px 0px 2px 0px; margin:-20px 0px 2px 0px;  float:left;"><asp:Label ID="lblDivName" runat="server"></asp:Label></h3>
<div style="clear:both;"></div>
<p style="font-size:14px; font-weight:normal; color:#000; line-height:18px; WIDTH:100%;  float:left; padding:0px 0px 2px 0px; margin:0px 0px 0px 0px; text-align:center;">
<asp:Label ID="lblAddress" runat="server"></asp:Label><br>
<asp:Label ID="lblphonefax" runat="server"></asp:Label>
</p>
</th>
</thead>

</table>

</div>

</div>
<div style="float:left; width:1050px; border-bottom:1px solid #000;">
<h4 style="font-family:'Segoe UI'; font-size:18px; padding:2px 0px 2px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
    <div style="float:left; width:110px; margin:2px 2px 2px 10px; font-weight:bold;"><asp:Label ID="lblrecPayno" runat="server"></asp:Label></div>
<div style="float:left; width:1px; margin:2px 2px 2px 0px;">:</div>
<div style="float:left; width:440px; margin:2px 2px 2px 10px;"><asp:Label ID="lblRecno" runat="server"></asp:Label></div>

    <div style="float:right; width:120px;">
<div style="float:left; width:auto; margin:2px 2px 2px 2px; text-align:right; font-weight:bold;"><label>ID</label></div>
<div style="float:left; width:2px; margin:2px 2px 2px 2px; text-align:right;">:</div>
<div style="float:left; width:auto; margin:2px 2px 2px 2px; text-align:right; font-weight:bold;"> <asp:Label ID="lblRecId" runat="server"></asp:Label></div>

</div>
</div>


<div style="width:1050px; float:left; border-bottom:1px solid #000;">
    <div style="float:left; width:522px; margin:5px 3px 0px 3px; padding:0px 0px 0px 0px;" id="Div1" runat="server">
    <table width="100%"   style="margin:0px 0px 2px 0px; float:left; border:1px solid #000; border-spacing:0px;">
        <thead>
        <tr><th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center;  border-bottom:1px solid #000;" colspan="8">Voucher Details</th></tr>
  <tr>
    <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;" class="auto-style1">Branch</th>
    <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;" class="auto-style1">Voucher #</th>
      <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;" class="auto-style1">Vendor Ref #</th>
      <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; " class="auto-style2">Date</th>
        <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;" class="auto-style1">Curr</th>
      <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;" class="auto-style1">FCurr Value</th>
       <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;" class="auto-style1">Ex Rate</th>  
    <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:0px solid #000; border-bottom:1px solid #000;" class="auto-style1">INR Value</th>
  </tr>
 
  </thead>
  <asp:Label ID="lblPaymentDtls" runat="server"></asp:Label>
 

  <tr>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
       <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
       <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;"><asp:Label ID="lblfctotamt" runat="server"></asp:Label></td>
    <td style="border-right:1px solid #000; border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:0px solid #000; padding:0px 2px 0px 2px; border-top:1px solid #000; margin:0px 2px 0px 2px; text-align:right; "><asp:Label ID="lblINRtotal" runat="server"></asp:Label></td>
  </tr>
    </table>
        </div>
    <div style="float:left; width:519px; margin:5px 0px 0px 0px; padding:0px 0px 0px 0px;" id="Div2" runat="server" >
        <table width="100%"   style="margin:0px 0px 2px 0px; float:left; border:1px solid #000; border-spacing:0px;">
            <thead>
        <tr><th style="padding:0px 2px 0px 2px; margin:5px; text-align:center; border-bottom:1px solid #000;" colspan="8">Voucher Details</th></tr>
  <tr>
    <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;">Branch</th>
    <th style="padding:0px 2px 0px 2px;; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;">Voucher #</th>
       <th style="padding:0px 2px 0px 2px;; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;">Vendor Ref #</th>
      <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000; width:70px;">Date</th>
        <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;">Curr</th>
      <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;">FCurr Value</th>
       <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:1px solid #000; border-bottom:1px solid #000;">Ex Rate</th>  
    <th style="padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:center; border-right:0px solid #000; border-bottom:1px solid #000;">INR Value</th>
  </tr>
 </thead>
  
  <asp:Label ID="lblPaymentDtls1" runat="server"></asp:Label>
 

  <tr>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
       <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
          <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;  border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;"><asp:Label ID="lblfctotamt1" runat="server"></asp:Label></td>
    <td style="border-right:1px solid #000; border-top:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;">&nbsp;</td>
    <td style="border-right:0px solid #000; padding:0px 2px 0px 2px; border-top:1px solid #000; margin:0px 2px 0px 2px; text-align:right; "><asp:Label ID="lblINRtotal1" runat="server"></asp:Label></td>
  </tr>
    </table>
        </div>
</div>


<div style="clear:both;"></div>
</div>
<div style="clear:both;"></div>
</div>

        <%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>
    </form>

</body>
</html>
