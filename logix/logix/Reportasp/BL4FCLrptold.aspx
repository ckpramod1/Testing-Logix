<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BL4FCLrptold.aspx.cs" Inherits="logix.Reportasp.BL4FCLrptold" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>BL Report</title>

<style type="text/css">

@font-face {
    font-family: 'Arialic Hollow';
    src: url('font/ArialicHollow.woff2') format('woff2'),
        url('font/ArialicHollow.woff') format('woff');
    font-weight: normal;
    font-style: normal;
    font-display: swap;
}


span#lblDescription {
    white-space: pre-line;
    text-align: left;
    float: left;
    display: inline-block;
    vertical-align: top;
}


</style>

</head>
   

	
    <%--<asp:Label ID="lbl_nonneg" runat="server" Visible="false" ></asp:Label></p>   <asp:Label ID="lbl_draft" runat="server" Visible="false" ></asp:Label></p>--%>
<body style="font-size:14px; font-family:sans-serif, Geneva, sans-serif; line-height:18px; color:#000;">
   
<div style="margin:0px auto 10px; font-size:21px; text-align:center; font-weight:bold;">MULTI-MODAL TRANSPORT DOCUMENT</div>
<div style="margin:0px auto 0px auto; width:1024px; border:1px solid #000;">
<div style="width:512px; float:left; border-right:1px solid #000;">
<div style="float:left; width:502px; border-bottom:1px solid #000; height:135px; padding:5px;">
<p style="margin:0px; font-weight:bold;">Consignor</p>
<p style="margin:0px; white-space:pre-wrap; padding:5px 0px 0px 15px;"><asp:Label ID="lbl_conshipaddress" runat="server"></asp:Label></p>



</div>
<div style="float:left; width:502px; border-bottom:1px solid #000; height:135px; padding:5px;">
<p style="margin:0px; font-weight:bold;">Consignee (or Order)</p>
<p style="margin:0px;white-space:pre-wrap; padding:5px 0px 0px 15px;"><asp:Label ID="lbl_conaddress" runat="server"></asp:Label></p>



</div>
<div style="float:left; width:502px; border-bottom:1px solid #000; height:135px; padding:5px;">
<p style="margin:0px; font-weight:bold;">Notify Address</p>
<p style="margin:0px;white-space:pre-wrap; padding:5px 0px 0px 15px;"><asp:Label ID="lbl_notifyaddress" runat="server"></asp:Label></p>



</div>
<div style="float:left; width:512px; border-bottom:1px solid #000; min-height:40px; padding:0px;">
<div style="float:left; width:270px; margin:0px 0px 0px 0px; border-right:1px solid #000; min-height:43px;">
<p style="margin:0px; padding:2px 2px 2px 5px; font-weight:bold;">Pre-Carriage by</p>
<p style="margin:0px; padding:2px 2px 2px 5px;"><asp:Label ID="lbl_precarriage" runat="server"></asp:Label></p>

</div>
<div style="float:left; margin:0px 0px 0px 0px; width:220px;"><p style="padding:2px; margin:0px 0px 0px 5px; font-weight:bold;">Place of Receipt</p>

<p style="padding:2px 2px 2px 17px; margin:0px 0px 0px 0px;"><asp:Label ID="lbl_POR" runat="server"></asp:Label></p>
</div>


</div>
<div style="float:left; width:512px;  min-height:40px; padding:0px;">
<div style="float:left; width:160px; margin:0px 0px 0px 0px; min-height:40px;">
<p style="margin:0px; padding:2px 2px 2px 5px; font-weight:bold;">Ocean Vessel</p>
<p style="margin:0px; padding:2px 2px 2px 17px;"><asp:Label ID="lbl_vessel" runat="server"></asp:Label></p>

</div>
<div style="float:left; margin:0px 0px 0px 0px; width:110px; border-right:1px solid #000; min-height:40px;"><p style="margin:0px; padding:2px 2px 2px 5px; font-weight:bold;">Voy No.</p>

<p style="margin:0px; padding:2px 2px 2px 17px;"><asp:Label ID="lbl_voy" runat="server"></asp:Label></p>
</div>
<div style="float:left; margin:0px 0px 0px 0px; width:220px;"><p style="padding:2px; margin:0px 0px 0px 5px; font-weight:bold;">Port of Loading</p>

<p style="padding:2px 2px 2px 17px; margin:0px 0px 0px 0px;"><asp:Label ID="lbl_POL" runat="server"></asp:Label></p>
</div>

</div>

<div style="float:left; width:512px; border-top:1px solid #000; border-bottom:1px solid #000; min-height:40px; padding:0px;">
<div style="float:left; width:270px; margin:0px 0px 0px 0px; border-right:1px solid #000; min-height:40px;">
<p style="margin:0px; padding:2px 2px 2px 5px; font-weight:bold;">Port of Discharge</p>
<p style="margin:0px;padding:2px 2px 2px 17px"><asp:Label ID="lbl_POD" runat="server"></asp:Label></p>

</div>
<div style="float:left; margin:0px 0px 0px 0px; width:220px;"><p style="padding:2px; margin:0px 0px 0px 5px; font-weight:bold;">Place of Delivery</p>

<p style="padding:2px 2px 2px 17px; margin:0px 0px 0px 0px;"><asp:Label ID="lbl_PODel" runat="server" ></asp:Label></p>
</div>


</div>
</div>

<div style="width:511px; float:left;">
<div style="width:255px; float:left; text-align:right;  margin:13px 0px 0px 0px;"><p style="padding:5px; margin:0px; font-weight:bold;">MTD Number</p></div>
<div style="float:left; width:245px; margin:10px 0px 0px 0px; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:1px solid #000; min-height:35px; "><p style="padding:5px; margin:0px; text-align:center;"><asp:Label ID="lbl_blno" runat="server"></asp:Label></p></div>
<div style="width:255px; float:left; text-align:right;  margin:5px 0px 0px 0px;"><p style="padding:5px; margin:0px; font-weight:bold;">Shipment Reference No.</p></div>
<div style="float:left; width:245px; margin:0px 0px 0px 0px; border-left:1px solid #000; border-right:1px solid #000; border-top:0px solid #000; border-bottom:1px solid #000; min-height:35px; "><p style="padding:5px; margin:0px;  text-align:center;"><asp:Label ID="lbl_shiprefno" runat="server"></asp:Label></p></div>
<div style="float:left; width:511px;">
<p style="padding:10px 0px 0px 0px; margin:15px 0px 5px 0px; font-size:24px; font-weight:bold; text-align:center;"><img src="../images/MRnewrpt1.png" width="90" height="90" /></p>
<p style="padding:0px 0px 0px 0px; margin:10px 0px 0px 15px; font-size:19px; font-weight:normal; line-height:32px;">FORWARDING PRIVATE LIMITED</p>
<p style="padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-size:18px; font-weight:normal; line-height:32px; text-align:center;">Registration No. MTO / DGS /2181 / MAY / 2023</p>
</div>
<div style="float:left; width:511px; border-top:1px solid #000; border-bottom:1px solid #000; margin-top:25px;">
<p style="font-size:10px; line-height:14px; padding:2px 5px; margin:0px;">Taken incharge in apparently good condition herein at the place of receipt for transport and delivery as mentioned above, unless otherwise stated. The MTO in accordance with the provisions contained in the MTD undertakes to perform or to procure the performance of the multimodal transport from the place at which the goods are taken in charge, to the place designated for delivery and assumes responsibility for such transport</p>

</div>
<div style="float:left; width:511px; border-bottom:1px solid #000;">
<p style="font-size:10px; line-height:14px; padding:2px 5px; margin:0px;">One of the MTD(s) must be surrendered, duly endorsed in exchange for the goods. In witness where of the original MTD all of this tenure and date have been signed in the number indicated below one of which being accomplished the other(s) to be void.</p>

</div>
<div style="float:left; width:511px; border-bottom:1px solid #000; min-height:121px; padding:0px;">

<p style="margin:0px; padding:2px 2px 2px 5px; font-weight:bold;">Delivery Agent</p>
<p style="margin:0px; padding:2px 2px 2px 17px;"><asp:Label ID="lbl_delicontact" runat="server"></asp:Label></p>





</div>
<div style="float:left; width:511px; border-bottom:1px solid #000; min-height:40px; padding:0px;">
<div style="float:left; width:240px; margin:0px 0px 0px 0px; border-right:1px solid #000; min-height:44px;">
<p style="margin:0px; padding:2px 2px 2px 5px; font-weight:bold;">Mode / Means of Transport</p>
<p style="margin:0px; padding:2px 2px 2px 17px; display:none;" ><asp:Label ID="lbl_transmode" runat="server"></asp:Label></p>

</div>
<div style="float:left; margin:0px 0px 0px 0px; width:266px;"><p style="padding:2px; margin:0px 0px 0px 5px; font-weight:bold;">Route / Place of Transshipment</p>

<p style="padding:2px 2px 2px 5px; margin:0px 0px 0px 0px;"> <asp:Label ID="lbl_transhipplace" runat="server"></asp:Label></p>
</div>


</div>
  </div>
   

<div style="clear:both;"></div>
<table width="1024" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="147" style="padding:5px; margin:0px; text-align:left; font-weight:bold;">Container No.(s)</td>
    <td width="281" style="padding:5px; margin:0px; text-align:center; font-weight:bold;">Marks and Numbers</td>
    <td width="187" style="padding:5px; margin:0px; text-align:center; width:400px; font-weight:bold;">Number of packages, kinds of packages, general description of goods. (said to contain)</td>
    <td width="202" style="padding:5px; margin:0px; text-align:center; width:180px; font-weight:bold;">Gross Weight<br />
Kgs.</td>
    <td width="207" style="padding:5px; margin:0px; text-align:center; font-weight:bold;">Measurement<br />
M3</td>
  </tr>
     <tr>
        <td colspan="2" style="font-weight:bold; padding:5px; text-align:left;">SHIPPER'S LOAD STOW & COUNT</td>
        <td   style="font-weight:bold; padding:5px; text-align:center; padding-right:25px;" >SAID TO CONTAIN</td>
        <td nowrap="nowrap" style="font-weight:bold; padding:5px; text-align:center;" colspan="2">SAID TO WEIGHT / MEASURE</td>
      </tr>
  <tr>
    <td style="padding:5px; margin:0px; white-space:pre-wrap; vertical-align:top;"><p style="padding:5px; margin:0px; white-space:nowrap;">Container #/Size/Seal #  </p> <p style="padding:5px; margin:0px;"><asp:Label ID="lbl_container" runat="server"></asp:Label></p></td>
    <td style="padding:5px; margin:0px; white-space:pre-wrap; vertical-align:top;"><p style="padding:5px; margin:0px 0px 0px 32px;"><asp:Label ID="lbl_marks" runat="server"></asp:Label></p></td>
    <td style="padding:5px; margin:0px; white-space:pre-wrap; vertical-align:top;"><p style="font-weight:normal; margin:0px; padding:5px; text-align:left; white-space:pre-wrap; vertical-align:top;"> <asp:Label ID="lbl_pkg" runat="server"></asp:Label></p>
        <asp:Label ID="lblDescription" runat="server"></asp:Label></td>
    <td style="padding:5px; margin:0px; vertical-align:top;">
       <p style="padding:5px; margin:0px 0px 0px 33px;"> Gross Weight<br />
               <asp:Label ID="lbl_grwt" runat="server" ></asp:Label></p>
        <p style="font-weight:normal;  text-align:left; white-space:nowrap; line-height:20px; padding:5px 5px 5px 5px; margin:0px 0px 0px 33px;">
           Net Weight
               <br />
               <asp:Label ID="lbl_netwt" runat="server"></asp:Label></p>
      <p style="font-weight:bold; padding:5px; text-align:left; white-space:nowrap; margin-top:45px; line-height:28px;">
          <asp:Label ID="lbl_type" runat="server"></asp:Label><br />
<asp:Label ID="lbl_freitype" runat="server"></asp:Label><br />
<asp:Label ID="lbl_surr" runat="server"></asp:Label>
      </p>

    </td>
    <td style="padding:5px 34px; margin:0px; vertical-align:top;"><asp:Label ID="lbl_cbm" runat="server"></asp:Label></td>
  </tr>
  
 
  <tr>
    <td style="padding:5px; margin:0px; font-weight:bold; font-size:12px; white-space:nowrap;"><asp:Label ID="lblAnnexcontainer" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
    <td style="padding:5px; margin:0px; font-weight:bold; font-size:12px;"><asp:Label ID="lblAnnexMarks" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
    <td style="padding:5px; margin:0px; font-weight:bold; font-size:12px;"> <asp:Label ID="lblAnnexDesc" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
    <td style="padding:5px; margin:0px;">&nbsp;</td>
    <td style="padding:5px; margin:0px;">&nbsp;</td>
  </tr>
 
 
  <tr><td colspan="5"> <div id="background" style="margin:0px auto; text-align:center; width:1024px; font-size: 36px;  color: rgba(0,0,0,0.2);">
  <p ><asp:Label ID="lbl_bltype" runat="server" Visible="false" ></asp:Label></p>
	</div></td></tr>
 
  <tr>
    <td style="padding:5px; margin:0px;">&nbsp;</td>
    <td colspan="3" style="padding:5px; margin:0px; text-align:center;  font-weight:bold;">Particulars above furnished by shipper/consignor</td>
    <td style="padding:5px; margin:0px;"></td>
  </tr>
</table>
    
<div style="clear:both;"></div>
<div style="width:1024px; margin:0px auto; border-bottom:1px solid #000; border-top:1px solid #000; min-height:60px;">
<div style="float:left; width:255px; border-right:1px solid #000; min-height:60px;">
<p style="padding:5px; margin:0px; font-weight:bold; ">Freight & ChargesAmount</p>
<p style="padding:2px 2px 2px 17px; margin:0px;"><asp:Label ID="lbl_freight" runat="server"></asp:Label></p>
</div>
<div style="float:left; width:255px; border-right:1px solid #000; min-height:60px;">
<p style="padding:5px; margin:0px; font-weight:bold; ">Freight Payable at</p>
<p style="padding:2px 2px 2px 17px; margin:0px;"><asp:Label ID="lbl_freightpayat" runat="server"></asp:Label></p>
</div>
<div style="float:left; width:255px;min-height:60px; border-right:1px solid #000;">
<p style="padding:5px; margin:0px; font-weight:bold; ">Number of Original MTD(s)</p>
<p style="padding:2px 2px 2px 17px; margin:0px;"><asp:Label ID="lbl_nooforigi" runat="server"></asp:Label></p>

</div>
<div style="float:left; width:255px;min-height:60px; border-right:0px solid #000;">
<p style="padding:5px; margin:0px; font-weight:bold; ">Place and Date of issue</p>
<p style="padding:2px 2px 2px 17px; margin:0px;"><asp:Label ID="lbl_placedtofisue" runat="server"></asp:Label></p>

</div>
</div>

<div style="width:1024px; margin:0px auto 20px auto;">
<div style="float:left; width:676px; border-right:1px solid #000; ">
<div style="float:left; width:676px;">
<p style="padding:5px 5px 0px 5px; margin:0px;">Other Particulars (if any)</p>
<p style="padding:68px 55px 10px 95px; margin:0px; text-align:left;">Weight and measurement of container not to be included<br />
(TERMS CONTINUED ON BACK HEREOF)</p>
</div>

</div>
<div style="float:left; width:340px;">
<p style="padding:15px 5px 5px 5px; margin:0px; font-size:12px;">For <asp:Label ID="lbl_branch" runat="server"></asp:Label></p>
     <p  style="padding:5px 18px 5px 5px; margin:0px; text-align:right; display:none;" class="Sign"> <asp:Image  ID="lbl_img" runat="server" width="147" height="60" /> </p>     
<p style="padding:0px 18px 10px 0px; margin:70px 0px 0px 0px; text-align:right; font-weight:bold;">Authorised Signatory</p>
   
</div>
</div>
<div style="clear:both;"></div>
</div>
</body>
</html>

