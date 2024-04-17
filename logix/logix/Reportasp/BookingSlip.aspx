<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingSlip.aspx.cs" Inherits="logix.Reportasp.BookingSlip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .LogisticsTitle {
    width: 730px;
    float: left;
    margin: 0px 0px;
    text-align: center;
}
        </style>
</head>
<body style="padding:0px; margin:0px; background-color:#fff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; color:#2c2b2b;">
    <form id="form1" runat="server">
 <%--<body style="padding:0px; margin:0px; background-color:#fff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; color:#2c2b2b;">--%>
<div style="width:100%; margin:auto;">
<div style="width:1024px; margin:auto;">
<div style="background-color:#878788; float:left; width:100%;">
<div style="width:135px; float:left; margin:10px 0px 0px 20px;">
 <asp:Image ID="img_Logo" runat="server" Width="63" Height="72"/> </div>
<%--<div style="float:left; width:869px; margin:5px 0px 0px 0px;">
<h3 style="font-family:Segoe UI; font-size:30px; font-weight:normal; color:#ffffff; text-align:center; padding:0px 0px 5px 0px; 
margin:0px 0px 0px -125px;">M+R LOGISTICS (INDIA) PVT.LTD.</h3>

<p style="text-align:center;  font-family:Segoe UI; font-size:14px; margin:0px 0px 10px -125px; padding:0px; font-weight:normal; line-height:18px; color:#ffffff;">56/57,III FLOOR, RAJAJI SALAI, CHENNAI 600001<br />
          Phone :+91 44 39881515 ; Fax : +91 44 30771410 ; eMail :ASOKAN.KM.MAA@IN.MRSPEDAG.COM</p>
</div>--%>
     <div class="LogisticsTitle">
                        <h3 style="color:#ffffff; padding:0px 0px 0px 0px; margin:5px 0px 0px 0px; font-size:24px; font-weight:normal;">
                            <asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
                        <p style="color:#ffffff; font-size:12px;">
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />

                            Phone :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>; 
FAX :
                            <asp:Label ID="lbl_fax" runat="server"></asp:Label>;
                            <br />
                            EMail:<asp:Label ID="lbl_email" runat="server"></asp:Label>
                        </p>
                    </div>
   <%-- <div style="float:left; width:137px; color:#ffffff; margin:0px 0px 0px 10px; font-size:12px;"><span><label>Print Date: </label><asp:Label ID="lbldate" runat="server"></asp:Label></span></div>--%>
</div>
     
<div  style=" background-color:#878788; width:1024px; float:left; min-height:110px; border-top:1px solid #ffffff;">
  <div style="font-size:14px; color:#2c2b2b; width:80%; float:left; padding:10px 0px 10px 20px; color:#ffffff;">
Customer :
</div>
<div style="float:right; margin:15px 10px 0px 0px; color:#ffffff;"><strong>Print Date:</strong> <asp:Label ID="lbl_Date" runat="server"></asp:Label> </div>
<div style="font-size:14px; color:#2c2b2b; width:80%; float:left;">
<p style="padding:0px 0px 10px 20px; margin:0px; color:#ffffff;">
    <asp:Label ID="lbl_customer" runat="server"></asp:Label>
    <div style="clear:both;"></div>
    <asp:Label ID="lbl_address" runat="server" style="color:#ffffff; display:block; margin:0px 0px 0px 20px;"></asp:Label>
</p>
</div>

</div>





<div style="background-color:#d0d0d0; width:1024px; float:left; padding:10px 0px 10px 0px; line-height:24px;">
<div style="margin:0px auto 15px; width:100%; text-align:center;"><strong>Booking Slip</strong></div>
<div style="float:left; width:100%; font-size:14px; margin:0px 0px 25px 10px;">Booking # <span style="color:#9e2e38; font-weight:bold; font-size:14px;"><asp:Label ID="lbl_book"  runat="server"></asp:Label></span> Dt. <strong><span style="color:#9e2e38; font-weight:bold; font-size:14px;"><asp:Label ID="lbl_bookingdate"  runat="server"></asp:Label></span></strong> has generated for the below quotation.</div>
<div style="float:left; width:510px;">
<div style="float:left; width:245px; font-weight:bold; margin:0px 0px 0px 10px;">Quotation # & Date</div>

<div style="float:left; width:240px;"><asp:Label ID="lbl_quotation" runat="server"></asp:Label></div>
<div style="float:left; width:245px; font-weight:bold;  margin:0px 0px 0px 10px;">Cargo Type</div>

<div style="float:left; width:240px;"><asp:Label ID="lbl_types" runat="server"></asp:Label></div>
<div style="float:left; width:245px; font-weight:bold;  margin:0px 0px 0px 10px;">Cargo Description</div>

<div style="float:left; width:240px;"><asp:Label ID="lbl_cargodescription" runat="server"></asp:Label></div>
<div style="float:left; width:245px; font-weight:bold;  margin:0px 0px 0px 10px;">Shipment</div>

<div style="float:left; width:240px;"><asp:Label ID="lbl_shipment" runat="server" ></asp:Label></div>
<div style="float:left; width:245px; font-weight:bold;  margin:0px 0px 0px 10px;">Freight</div>

<div style="float:left; width:240px;"><asp:Label ID="lbl_Prepaid" runat="server" ></asp:Label></div>
<div style="float:left; width:245px; font-weight:bold;  margin:0px 0px 0px 10px;">Place of Receipt</div>

<div style="float:left; width:240px; margin:0px 0px 0px 0px;"><asp:Label ID="lbl_place" runat="server"></asp:Label></div>
<div style="float:left; width:245px; font-weight:bold;  margin:0px 0px 0px 10px;">Port of Discharge</div>

<div style="float:left; width:240px;"><asp:Label ID="lbl_discharge" runat="server"></asp:Label></div>
     <div style="float:left; width:240px; margin:0px 0px 0px 10px; font-weight:bold;">Booking Remarks</div>

<div style="float:left; width:245px; margin:0px 0px 0px 0px;"><asp:Label ID="lbl_bkremarks" runat="server"></asp:Label></div>
</div>
<div style="float:left; width:510px;">
<div style="float:left; width:245px; margin:125px 0px 0px 0px; font-weight:bold;">Port of Loading</div>

<div style="float:left; width:250px; margin:125px 0px 0px 0px;"><asp:Label  ID="lbl_portload"  runat="server"></asp:Label></div>
<div style="float:left; width:245px; margin:0px 0px 0px 0px; font-weight:bold;">Final Destination</div>

<div style="float:left; width:250px; margin:0px 0px 0px 0px;"><asp:Label ID="lbl_finaldestion" runat="server"></asp:Label></div>

   
</div>


</div>
<div style="clear:both;"></div>
<div style="float:left; width:1024px; background-color:#878788;"><p style="padding:5px 0px 5px 0px; margin:0px 0px 0px 10px; color:#ffffff;">Sell Rate Details</p>
</div>
<div style="clear:both;"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="5" style=" width:100%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1; margin:0px auto;">
  <tr>
    <th width="50%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Charges</th>
    <th width="5%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Curr</th>
    <th width="24%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Rate</th>
    <th width="24%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Status</th>
    </tr>
     <asp:Label ID="tr_row" runat="server"></asp:Label>
  <%--<tr style="background-color:#f5f5f5;">
    <td style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">BL CHARGES</td>
    <td style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">INR</td>
    <td style="color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">3,500.00 BL      
     </td>
    <td style="color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">Prepaid</td>
    </tr>
  <tr style="background-color:#fff; border-bottom:1px solid #cdbcb1;">
    <td style="border-right:1px solid #cdbcb1;">TERMINAL HANDLING CHARGES ORIGIN</td>
    <td style="border-right:1px solid #cdbcb1;">INR</td>
    <td style="text-align:right; border-right:1px solid #cdbcb1;">7,100.00 40HC </td>
    <td style="text-align:left; border-right:1px solid #cdbcb1;">Prepaid</td>
  </tr>--%>
  </table>
<div style="clear:both;"></div>
<div style="width:1022px; margin:0px 0px 0px 0px;">
  <div style="clear:both;"></div>
  <div style="float:left; width:1024px; background-color:#878788;">
  <div style="float:left; width:235px; background-color:#878788;">
    <p style="padding:5px 0px 5px 0px; margin:10px 0px 5px 10px; color:#ffffff;"><strong>Buying Rate Details</strong></p>
    <p style="padding:5px 0px 5px 0px; margin:10px 0px 5px 10px; color:#ffffff;"><strong>Buying ID</strong> <asp:Label ID="lbl_buying" runat="server"></asp:Label></p>
    </div>
    
    <div style="float:right; width:730px;">
    <p style="padding:5px 0px 5px 0px; margin:30px 10px 5px 0px; text-align:right; color:#ffffff;"><strong>Carrier :</strong> <asp:Label ID="lbl_carrier" runat="server"></asp:Label></p>
    
    </div>
  </div>


<div style="clear:both;"></div>
<table width="100.3%" border="0" cellspacing="0" cellpadding="5" style=" width:100.3%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1; border-bottom:1px solid #cdbcc1; margin:0px auto;">
  <tr>
    <th width="50%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Charges</th>
    <th width="5%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Curr</th>
    <th width="24%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Rate</th>
    <th width="24%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Status</th>
    </tr>
   <asp:Label ID="tr_row1" runat="server"></asp:Label>
  <%--<tr style="background-color:#f5f5f5;">
    <td style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">BL CHARGES</td>
    <td style="color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">INR      
     </td>
    <td style="color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">3,500.00 BL</td>
    <td style="color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">PrePaid</td>
    </tr>
  <tr style="background-color:#fff;">
    <td style="border-right:1px solid #cdbcb1;">TERMINAL HANDLING CHARGES ORIGIN</td>
    <td style="text-align:right; border-right:1px solid #cdbcb1;">INR </td>
    <td style="text-align:right; border-right:1px solid #cdbcb1;">7,100.00 40HC</td>
    <td style="color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">PrePaid</td>
  </tr>--%>
  </table>
    <div style="float:left; width:1024px; background-color:#878788;">
  <div style="float:left; width:95px;">
<p style="margin:10px 0px 10px 0px; color:#ffffff; margin:10px 0px 0px 10px;">Remarks
</p>
</div>
<div style="float:left; width:855px; margin:10px 0px 0px 0px; color:#ffffff;"><asp:Label ID="lbl_remark"  runat="server"></asp:Label></div>
<div style="clear:both;"></div>

<div style="float:left; width:1024px; margin:40px 0px 0px 0px;">
  <div style="clear:both;"></div>
<p style="padding:5px; margin:100px 0px 40px 0px; color:#ffffff; color:#ffffff; margin:0px 0px 0px 10px;"><asp:Label ID="lbl_name"  runat="server"></asp:Label></p>
</div>
</div>
</div>
</div>
</div>
</body>
    </form>
</body>
</html>
