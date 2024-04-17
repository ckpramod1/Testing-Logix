<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form2Rpt.aspx.cs" Inherits="logix.Reportasp.Form2Rpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>FORM -II</title>
</head>

<body style="font-family:sans-serif, Geneva, sans-serif; font-size:14px; line-height:18px;">

<div style="width:1024px;margin: 0px auto;"> 
<p style="text-align:center;font-weight:bold;">FORM -II</br>
Cargo Declaration</br>
(See Regulation 3)</p>
</div>

<div style="width:1024px;margin: 0px auto;"> 

<div style="width:230px;float: left;padding:5px;text-align: left;font-weight: bold;">Name of Shipping Line,Agent e</div>
<div style="width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;">:</div>
<div style="width:320px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_divname" runat="server" ></asp:Label></div>

<div style="clear:both"></div>

<div style="width:145px;float: left;padding:5px;text-align: left;font-weight: bold;">Name of Ship</div>
<div style="width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;">:</div>
<div style="width:180px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_vessel" runat="server" ></asp:Label> Voyage :<asp:Label ID="lbl_voy" runat="server" ></asp:Label></div>

<div style="clear:both"></div>

<div style="width:145px;float: left;padding:5px;text-align: left;font-weight: bold;">Nationality of Ship</div>
<div style="width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;">:</div>
<div style="width:310px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_cnation" runat="server" ></asp:Label></div>

<div style="width:120px;float: left;padding:5px;text-align: left;font-weight: bold;">Name of Master</div>
<div style="width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;">:</div>
<div style="width:150px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_cmaster" runat="server" ></asp:Label></div>


</div>

<div style="clear:both"></div>
<div style="width:1024px;margin: 0px auto;"> 
<table width="1024" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <th width="31" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; border-left:1px solid #000; padding:2px;">Line   No</th>
    <th width="91" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Bill of Lading  No  and Date</th>
    <th width="65" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Number and Kinds  of</th>
    <th width="93" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Marks and  Numbers</th>
    <th width="51" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Gross Weight</th>
    <th width="125" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Description of   Goods</th>
    <th width="198" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Name of Consignee/Importe  (if different to be specified)</th>
    <th width="70" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Date of   presentation of  Bill of  Entry</th>
    <th width="60" rowspan="2" style="border-top:1px solid #000;border-right:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Name of  Custom  House Agent</th>
    <th colspan="4" style="border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Rotation Year:2021 Page:1  Number</th>
  </tr>
  <tr>
    <th width="51" style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Cash /  Deposit  W.R.No</th>
    <th width="63" style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">No of  Packages on  which duty  collected</th>
    <th width="69" style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">To be filled by Port  Trust  Number of Packages  discharged</th>
    <th width="56" style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">Remarks</th>
  </tr>


     <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>


 <%-- <tr>
    <td colspan="13" style="border-bottom:1px solid #000; padding:2px; border-left:1px solid #000;border-right:1px solid #000;">CARGO LOADED FROM <asp:Label ID="lbl_port" runat="server" ></asp:Label> <asp:Label ID="vess" runat="server" ></asp:Label> / <asp:Label ID="lbl_voyy" runat="server" ></asp:Label> AND TRANSHIPPED AT <asp:Label ID="lbl_port2" runat="server" ></asp:Label> TO BE DISCHARGED AT <asp:Label ID="lbl_port3" runat="server" ></asp:Label> </td>
  </tr>
  <tr>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000; border-left:1px solid #000; padding:2px;">610</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;"><p>BKKA37935</p>
    <p>Dated</p>
    <p>2/2/2020</p></td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;"><p>0 x 2 0 Container</p>
    <p>1 x 4 0 Container</p>
    <p>S.T.C</p>
    <p>16 Cartons</p></td>
    <td valign="top" style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">SCHNEIDER  ELECTRIC AS  PER BL</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;"><p>272.00</p>
    <p>KGS</p></td>
    <td valign="top" style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;">PRINTED CIRCUIT  BOARDS AS PER  BL</td>
    <td valign="top" style="border-right:1px solid #000;border-bottom:1px solid #000; padding:2px;"><p>SCHNEIDER ELECTRIC IT  BUSINESS INDIA PRIVATE  LIMITED  187 3 &amp; 188 3 JIGANI VILLAGE  JIGANI HOBLI ANEKAL TALUK  BANGALORE 562106</p>
    <p>Notify Party</p>
    <p>SCHNEIDER ELECTRIC IT  BUSINESS INDIA PRIVATE  LIMITED</p>
    <p>187 3 &amp; 188 3 JIGANI VILLAGE  JIGANI HOBLI ANEKAL TALUK  BANGALORE 562106</p>--%>
     <%--<tr>
     <td >
    <div style="width:95%; float:left;">
    
    <p style="padding:1px; margin:0px; font-weight:bold;"> LCL CONTAINER DETAILS</p>
    <div style="float:left; width:49%; margin:0px 1% 0px 0px;">
    
    <div style="float:left; width:100%; margin:5px 0px 5px 0px; font-weight:bold;">Container #</div>
    <div style="clear:both;"></div>
    <p style="padding:1px; margin:0px;"><asp:Label ID="lbl_container" runat="server" ></asp:Label><br />
   
</p>
    
    </div>
    
     <div style="float:left; width:45%; margin:0px 0% 0px 0px;">
    
    <div style="float:left; width:50%; margin:5px 0px 5px 0px; font-weight:bold;">Seal #</div>
    <div style="clear:both;"></div>
     <p style="padding:1px; margin:0px;"><asp:Label ID="lbl_seal" runat="server" ></asp:Label><br />
   
</p>
    
    
    </div>
    </div>
    </td>
    </tr>--%>
   <%-- </td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">T/C</td>--%>
 <%-- </tr>--%>
  <%--<tr>
    <td colspan="13" style="border-bottom:1px solid #000; padding:2px; border-left:1px solid #000;border-right:1px solid #000;">CARGO LOADED FROM SINGAPORE ON COSCO IZMIR / 053W AND TRANSHIPPED ATSINGAPORE TO BE DISCHARGED AT CHENNAI </td>
  </tr>
   <tr>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;border-left:1px solid #000;">610</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;"><p>CMSSG2002249</p>
    <p>Dated</p>
    <p>15/2/2020</p></td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;"><p>0 x 2 0 Container</p>
    <p>1 x 4 0 Container</p>
    <p>S.T.C</p>
    <p>4 Pallets</p></td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">IGARASHI  MOTORS AS  PER BL</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;"><p>2,760.00</p>
    <p>KGS</p></td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">4PLT=16DRM  EXXONMOBIL  CLEANING FLUID  AS PER BL</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;"><p>IGARASHI MOTORS INDIA LTD  PLOT NO B12 B15 MEPZ SEZ  PHASE II TAMBARAM CHENNAI  600045</p>
    <p>Notify Party</p>
    <p>IGARASHI MOTORS INDIA LTD  PLOT NO B12 B15 MEPZ SEZ  PHASE II TAMBARAM CHENNAI  600045</p>
    <p>&nbsp;</p></td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000;border-bottom:1px solid #000;">L/C</td>
  </tr>--%>
</table>
</div>

</body>
</html>
