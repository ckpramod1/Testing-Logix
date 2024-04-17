<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form3rpt.aspx.cs" Inherits="logix.Reportasp.Form3rpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>FORM III</title>
    <style type="text/css">
.TableHeader thead {display: table-header-group;}
        @media print {


            table tr.page-break {
                page-break-after: always;
            }
        }
/*@media print {
    .pagebreak {
        clear: both;
        page-break-after: always;
    }*/
/*}*/
</style>
    <%--<style type="text/css">
   table { page-break-inside:auto }
   .page-break { page-break-inside:avoid; page-break-after:always }
</style>--%>
</head>
    <body style="font-family:sans-serif, Geneva, sans-serif; font-size:14px; line-height:18px;">
     <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>
        </body>
<%--<body style="font-family:sans-serif, Geneva, sans-serif; font-size:12px; line-height:18px;">
<div style="width:1024px;margin: 0px auto;"> 
<p style="text-align:center;font-weight:bold;">FORM III</br>
Cargo Declaration </br>
(See Regulation 3 and 4)</p>
</div>

<div style="width:1050px;margin: 0px auto;"> 

<div style="width:205px;float: left;padding:5px;text-align: left;font-weight: bold;">Name of Shipping Line,Agent etc</div>
<div style="width:315px;float: left;text-align:left;margin: 5px 0px 0px 0px;"><asp:Label ID="lbl_divname" runat="server" ></asp:Label>,</div>
<div style="width:300px;float: left;text-align:left;margin: 5px 0px 0px 0px;"><asp:Label ID="lb_Agent" runat="server" ></asp:Label></div>
</div>
<div style="clear:both;"></div>
<div style="width:1050px;margin: 0px auto;border-top: 1px solid #000;"> 

<div style="width:100px;float: left;padding:5px;text-align: left;font-weight: bold;">1.Name of Ship</div>
<div style="width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;">:</div>
<div style="width:270px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_vessel" runat="server" ></asp:Label></div>


<div style="width:65px;float: left;padding:5px;text-align: left;font-weight: bold;">Voyage</div>
<div style="width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;">:</div>
<div style="width:150px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_voy" runat="server" ></asp:Label></div>



<div style="width:170px;float: left;padding:5px;text-align: left;font-weight: bold;">2.Port where report made</div>
<div style="width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;">:</div>
<div style="width:100px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_pod" runat="server" ></asp:Label></div>


<div style="clear:both;"></div>


<div style="width:135px;float: left;padding:5px;text-align: left;font-weight: bold;">3.Nationality of Ship</div>
<div style="width:2px;float: left;text-align: center;margin: 5px 0px 0px 0px;">:</div>
<div style="width:175px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_cnation" runat="server" ></asp:Label></div>


<div style="width:126px;float: left;padding:5px;text-align: left;font-weight: bold;">4.Name of Master</div>
<div style="width:2px;float: left;text-align: center;margin: 5px 0px 0px 0px;">:</div>
<div style="width:150px;float: left;text-align:left;margin: 5px 0px 0px 20px;"></div>



<div style="width:170px;float: left;padding:5px;text-align: left;font-weight: bold;">5.Port of Loading</div>
<div style="width:2px;float: left;text-align: center;margin: 5px 0px 0px 0px;">:</div>
<div style="width:100px;float: left;text-align:left;margin: 5px 0px 0px 20px;"><asp:Label ID="lbl_pol" runat="server" ></asp:Label></div>



</div>
<div style="clear:both;"></div>
<div style="width:1050px;margin: 0px auto;"> 
<table width="1050" border="0" cellspacing="0" cellpadding="0">
    <thead>
  <tr style="text-align: left;">
      
    <th width="55" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">6.Line No. </br>Sub-Line No.Type</th>
    <th width="1102" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">7.Bill of Lading No.</th>
    <th width="60" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">8.No. &amp; Kindsof Packages</th>
    <th width="87" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">9.Marks &amp; Numbers</th>
    <th width="60" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">10.Gross Weight</th>
    <th width="95" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">11.Goods Description</th>
    <th width="177" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">12.Name of Consignee/Importer if different</th>
    <th width="86" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">13.Date of Presentation of B/E</th>
    <th width="92" rowspan="2" style="padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;">14.Name of Custom House</th>
    <th colspan="3" style="border-bottom:1px solid #000; text-align:left; padding:2px; margin:0px; border-top:1px solid #000; ">15.Rotation No</th>
  </tr>
  <tr>
    <th width="90" valign="top"  style="padding:2px; margin:0px; border-bottom:1px solid #000; ">Cash/Deposit W.R.No</th>
    <th width="77" valign="top"  style="padding:2px; margin:0px; border-bottom:1px solid #000;">No of Pkgs onwhich duty Type collected of</th>
    <th width="69" valign="top" style="padding:2px; margin:0px; border-bottom:1px solid #000;">Year(To be Filled Remark by port trust)No of Pkgs</th>
  </tr>
 
</thead>
  <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>
</table>
</div>
   
<div  style="width:1050px;margin: 0px auto;"> 
<div style="width:315px;float:right;padding:10px;" >We hereby certify that item No. to against IGM NO. is for
account of ourprincipals.We,as agents are responsible for the full
outtern of cargo manifested under the above items and will be
liable to the Customs for any penalty or other dues in case of
any shortlandings/survey shortages.We hereby hold Mumbai
Agents of the vessel fully indemnified from any short
landings/survey shortages under the above items.We certify
that all items indicated in this Hard copy of IGM have been </div>

<div style="clear:both;"></div>

<div style="width:315px;float:right;text-align:right;margin-top:35px;">Date & signature of Master,authorised ag</div>

</div>

</body>--%>
</html>

