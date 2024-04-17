<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BL4CANprofoma.aspx.cs" Inherits="logix.Reportasp.BL4CANprofoma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>CANprofoma</title>
    <style type="text/css">
        span#lbl_TO {
    white-space: pre-line;
    text-align: left;
    display: inline-block;
    float: left;
}
    </style>
</head>

<body style="font-size:14px; font-family:sans-serif, Geneva, sans-serif; line-height:18px; color:#000;">
     <div style="width:1024px; margin:5px auto 5px;">
        <div style="float:right;"> <asp:Image ID="img_Logo" runat="server" /></div>
       

        
    </div>
    <div style="clear:both;"></div>
<div style="width:1024px; margin:0px auto;  border-top:0px solid #000; border-bottom:1px solid #000; min-height:1150px;">

<div style="width:1024px; float:left;">
<h3 style="text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold;"><asp:Label ID="lbl_branch" runat="server" ></asp:Label></h3>
<p style="font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_addre" runat="server" ></asp:Label><br />
<asp:Label ID="lblphfax" runat="server" ></asp:Label></p>
<p style="font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbltaxpan" runat="server" ></asp:Label></p>

</div>
<div style="clear:both;"></div>
<div style="width:1024px; margin:0px auto;">
<div style="width:1024px; margin:0px auto; border-bottom:1px solid #000; border-top:1px solid #000;"> 
<div style="float:left; width:175px; padding:15px 0px 15px 0px; margin:0px 0px 0px 0px;">
<div style="float:left; width:45px; margin:0px 5px 0px 5px; font-weight:bold;">Job # </div>
<div style="float:left; width:1px; margin:0px 5px 0px 5px; font-weight:bold;">:</div>
<div style="float:left; width:85px; margin:0px 5px 0px 5px; font-weight:normal;"><asp:Label ID="lbl_jobno" runat="server" ></asp:Label> </div>
</div>
<div style="width:664px; float:left; text-align:center; padding:15px 0px 15px 0px; margin:0px 0px 0px 0px; font-size:18px; font-weight:bold;">
    CAN & PROFORMA INVOICE
</div>
<div style="float:right; width:185px; padding:15px 0px 15px 0px; margin:0px 0px 0px 0px;">

<div style="float:left; width:70px; margin:0px 5px 0px 5px; font-weight:bold;">CAN Date </div>
<div style="float:left; width:1px; margin:0px 5px 0px 5px; font-weight:bold;">:</div>
<div style="float:left; width:85px; margin:0px 0px 0px 5px; font-weight:normal;"><asp:Label ID="lbl_candt" runat="server" ></asp:Label></div>

</div>
<div style="clear:both;"></div>
</div>
<div style="float:left; width:1024px; border-bottom:1px solid #000;">
<div style="width:512px; float:left;">
<p style="padding:5px; margin:0px;"><asp:Label ID="lbl_TO" runat="server" ></asp:Label></p>
</div>
<div style="width:312px; float:right;">
<div style="float:left; width:120px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;">Feeder Vsl </div>
<div style="float:left; width:1px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:155px; padding:5px 0px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;">
<asp:Label ID="lbl_feedvslvoy" runat="server" ></asp:Label></div>
<div style="float:left; width:120px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;">E T A  </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:155px; padding:0px 0px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_eta" runat="server" ></asp:Label></div>
<div style="float:left; width:120px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;">IM #  </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:155px; padding:0px 0px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_IMandDT" runat="server" ></asp:Label></div>
<div style="float:left; width:120px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;">Mother Vsl  </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:155px; padding:0px 0px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_motvslvoy" runat="server" ></asp:Label></div>
</div>
</div>
<div style="float:left; width:1024px; border-bottom:1px solid #000;">
<div style="width:512px; float:left;">
<div style="float:left; width:70px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:left; font-weight:bold;">BL #  </div>
<div style="float:left; width:1px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:120px; padding:5px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;">
<asp:Label ID="lbl_blno" runat="server" ></asp:Label> / </div>
<div style="float:left; width:35px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:left; font-weight:bold;">Date  </div>
<div style="float:left; width:1px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:5px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_bldt" runat="server" ></asp:Label></div>
<div style="clear:both;"></div>
<div style="float:left; width:70px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:left; font-weight:bold;">Line #  </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:0px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_line" runat="server" ></asp:Label></div>
<div style="clear:both;"></div>
<div style="float:left; width:70px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:left; font-weight:bold;">Status  </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:0px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_status" runat="server" ></asp:Label></div>
<div style="clear:both;"></div>
<div style="float:left; width:70px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:left; font-weight:bold;">Freight </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:0px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_freight" runat="server" ></asp:Label></div>
</div>
<div style="width:312px; float:right;">
<div style="float:left; width:120px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;"> P o L </div>
<div style="float:left; width:1px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:5px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;">
<asp:Label ID="lbl_pol" runat="server" ></asp:Label></div>
<div style="float:left; width:120px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;">P o D</div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:0px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_pod" runat="server" ></asp:Label></div>
<div style="float:left; width:120px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;">Packages </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:0px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_pkgs" runat="server" ></asp:Label></div>
<div style="float:left; width:120px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:right; font-weight:bold;">Gr.Weight </div>
<div style="float:left; width:1px; padding:0px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:140px; padding:0px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_grwt" runat="server" ></asp:Label></div>
</div>
</div>
<div style="float:left; width:1024px; border-bottom:1px solid #000;">
<div style="float:left; width:70px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:left; font-weight:bold;">Description </div>
<div style="float:left; width:1px; padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:center; font-weight:bold;">:</div>
<div style="float:left; width:900px; padding:5px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;">
<asp:Label ID="lbl_descn" runat="server" ></asp:Label> </div>
</div>
<div style="float:left; width:1024px; border-bottom:1px solid #000;">
<p style="padding:5px 5px 5px 5px; margin:0px 5px 0px 0px; text-align:left; font-weight:bold;">Container Details </p>

<p style="padding:5px 5px 5px 5px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;">
<asp:Label ID="lbl_contdtls" runat="server" ></asp:Label> </p>
</div>
<div style="float:left; width:1024px; border-bottom:0px solid #000;">
<p style="font-weight:bold; padding:5px; margin:0px 0px 5px 0px;">Dear Sir ( s )</p>
<p style="font-weight:normal; padding:5px; margin:0px 0px 5px 0px;">Please be advised that the above mentioned vessel is scheduled to arrive <span style="font-weight:bold;"><asp:Label ID="lblpod" runat="server" ></asp:Label></span> on <span style="font-weight:bold;"><asp:Label ID="lbleta" runat="server" ></asp:Label></span></p>
<p style="font-weight:normal; padding:5px; margin:0px 0px 5px 0px;">kindly arrange to present the original Bill of Lading & Freight Certificate ( if terms are FOB & Freight Collect) and obtain a delivery order against payment of necessary charges by <span style="font-weight:bold;">DEMAND DRAFT</span> only</p>
<p style="font-weight:normal; padding:5px; margin:0px 0px 5px 0px;">Please note we will not hold the FCL Container(s)  in the Terminal beyond 3 days or as specified by the Terminal and or  Carrier from the day of vessel arrival.  We will move the container to off-Dock CFS after completion of free-days under your cost and risk.</p>
<p style="font-weight:normal; padding:5px; margin:0px 0px 5px 0px;">Looking forward to your speedy clearance of cargo and find below your proforma invoice</p>
<ul style="padding:5px 5px 5px 5px; margin:60px 0px 0px 0px;">
<li style="list-style:none; padding:5px 5px 10px 5px; margin:0px; font-size:18px; font-weight:bold; vertical-align:top;"><img src="../images/tick.jpg" width="16" height="22" /> Service Tax as Applicable</li>
<li style="list-style:none; padding:5px 5px 10px 5px; margin:0px; font-size:18px; font-weight:bold; vertical-align:top;"><img src="../images/tick.jpg" width="16" height="22" /> Please Contact Our Customer Service for Ex.Rate & Final Invoice</li>
<li style="list-style:none; padding:5px 5px 10px 5px; margin:0px; font-size:18px; font-weight:bold; vertical-align:top;"><img src="../images/tick.jpg" width="16" height="22" /> Final Invoice will be Generated at the time of Vessel Arrival</li>
</ul>


<table width="100%%" border="0" cellspacing="0" cellpadding="0" style="border-top:1px solid #000; border-bottom:1px solid #000;">
  <tr>
    <td style="padding:5px; margin:0px; font-weight:bold; text-align:center; border-bottom:1px solid #000; width:500px;">Charges</td>
    <td style="padding:5px; margin:0px; font-weight:bold; text-align:center; border-bottom:1px solid #000; width:200px">Rate </td>
    <td style="padding:5px; margin:0px; font-weight:bold; text-align:center; border-bottom:1px solid #000;">Base</td>
    <td style="padding:5px; margin:0px; font-weight:bold; text-align:center; border-bottom:1px solid #000; width:200px;">Amount</td>
  </tr>
  <tr>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left;  width:500px;"><asp:Label ID="lbl_chargename" runat="server" ></asp:Label></td>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left; width:200px"><div style="float:left; text-align:left; width:25px;"><asp:Label ID="lbl_curr" runat="server" ></asp:Label></div><div style="float:left; text-align:right; width:140px;"><asp:Label ID="lbl_rate" runat="server" ></asp:Label> </div></td>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left; "><asp:Label ID="lbl_base" runat="server" ></asp:Label></td>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left; width:200px;"><div style="float:left; text-align:left; width:25px;"><asp:Label ID="lblcurr" runat="server" ></asp:Label></div><div style="float:left; text-align:right; width:140px;"><asp:Label ID="lbl_amt" runat="server" ></asp:Label></div></td>
  </tr>
  <%-- <tr>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left;  width:500px;">DELIVERY ORDER CHARGES</td>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left; width:200px"><div style="float:left; text-align:left; width:25px;">INR</div><div style="float:left; text-align:right; width:140px;">4,500.00 </div></td>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left; ">BL</td>
    <td style="padding:5px; margin:0px; font-weight:normal; text-align:left; width:200px;"><div style="float:left; text-align:left; width:25px;">INR</div><div style="float:left; text-align:right; width:140px;">5,310.00</div></td>
  </tr>--%>

  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>

<p style="font-weight:normal; padding:5px; margin:170px 0px 5px 0px;">Thanking You </p>

<p style="font-weight:bold; padding:5px; margin:0px 0px 5px 0px;">THIS IS A COMPUTER GENERATED DOCUMENT AND HENCE REQUIRES NO SIGNATURE.</p>

</div>

<div style="clear:both;"></div>
    </div>
</div>
</body>
</html>
