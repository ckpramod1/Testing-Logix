<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Combinedquotrpt.aspx.cs" Inherits="logix.Reportasp.Combinedquotrpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title id="title" runat="server"></title>
<style type="text/css">
    .TableHeader1 thead {
        display: table-header-group;
    }

    .relative {
        position: relative;
        top: -13px;
    }
   span#lbl_grwt, span#lbl_noofcont, span#lbl_service, span#lbl_conttype, span#lbl_carrier, span#lbl_inco, td#lbl_cargo {
    position: relative;
    left: 115px;
}
   span#lbl_conttype {
    left: 10px;
}
   p.container span {
    position: relative;
    left: 63px;
}

   span.final_destination {
    position: relative;
    left: 31px;
}
   span.Volume_name {
    position: relative;
    left: 110px;
}
   .mainTable tr td {
    border-right: 3px solid #000;
}
   .volbarket {
    margin-left: 17px;
}
   span#lbl_terms {
    line-height: 25px;
}
   span#lbl_contact {
    line-height: 20px;
}
   span#lbl_carrier {
    left: 0px;
}
</style>
</head>

<body style="font-size:13px; font-family:Tahoma, Geneva, sans-serif; line-height:18px; color:#000;">

<div style="width: 1002px; margin: 0px auto; border-top: 0px solid #000; border: 1px solid #000; text-align: right;">


<div style="width:1024px; margin:0px; padding:0px;">
<div style="float:left;width:200px;border-bottom: 0px solid #000;border-top: 0px solid #000;border-left: 0px solid #000;height:75px;border-right: 0px solid #000; margin:0px 0px 0px 0px;"> <asp:Image ID="img_Logo" runat="server" width="75px" style="float:left;margin:10px 0px 0px 15px"  /></div>
<div style="width:800px;height:75px; margin: 0px 0px 0px 0px;float:left;border-bottom: 0px solid #000;border-top: 0px solid #000;border-left: 0px solid #000;border-right: 0px solid #000;">
<h3 style="text-align:right; padding:10px 10px 0px 0px; margin:0px 0px 0px 0px; font-size:16px; font-weight:bold;color: #56789d; "><asp:Label ID="lbl_company" runat="server"></asp:Label>
</h3>
<p style="font-weight:normal; padding:5px 10px 0px 0px; margin:0px 0px 0px 0px; text-align:right;width: 330px;float: right;font-size:13px;color: #56789d;"><asp:Label ID="lbl_comaddress" runat="server"></asp:Label></p>
<%--<p style="font-weight:normal; padding:0px 10px 5px 0px; margin:0px 0px 0px 0px; text-align:right;">Purasawalkam, Chennai – 600084, Tamil Nadu, India</p>--%>
   


</div>

</div>

  <div style="clear:both;"></div>
    <div style="width:1024px; margin:0px; padding:0px;display:none;">
<div style="float:left;width:498px;border-bottom: 0px solid #000;border-top: 1px solid #000;border-left: 1px solid #000;height:75px;border-right: 0px solid #000; margin:0px 0px 0px 0px;"> <h3 style="text-align:center; padding:28px 10px 0px 0px; margin:0px 0px 0px 0px; font-size:16px; font-weight:bold; ">
</h3></div>
<div style="width:502px;height:75px; margin: 0px 0px 0px 0px;float:left;border-bottom: 0px solid #000;border-top: 1px solid #000;border-left: 1px solid #000;border-right: 1px solid #000;">

  
<p style="font-weight:normal; padding:20px 10px 0px 12px; margin:0px 0px 0px 0px;width: 263px; text-align:center;font-size:13px;"></p>
<%--<p style="font-weight:normal; padding:0px 10px 5px 0px; margin:0px 0px 0px 0px; text-align:right;">Purasawalkam, Chennai – 600084, Tamil Nadu, India</p>--%>
   
  </div>

</div>


<div style="width:1024px; margin:0px; padding:0px;">


<div style="width:500px;border-bottom: 0px solid #000;border-right: 0px solid #000; margin: 18px 0px 0px 0px;float:left;border-top: 0px solid #000;">

<p style="text-align:center;float: left; width:488px; padding:0px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 0px solid #000;background: #d9e1f2;border-right: 0px solid #000; border-left: 0px solid #000;font-weight:bold;display:none; ">Customer Details</p>
  <div style="clear:both;"></div>
<p style="text-align:left;float: left; width:470px; padding:0px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000;font-weight: bold; "><asp:Label ID="lbl_name" runat="server"></asp:Label></p>

<p style="text-align:left;float: left;width:292px; padding:0px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px; border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; display:none;"> </p>
  <div style="clear:both;"></div>
  
  

<p style="text-align:left;float: left; width:190px;border-bottom: 1px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:82px;font-weight: bold;display:none; ">Address	</p>

<p style="text-align:left;float: left;width:292px;border-bottom: 1px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;height:82px; display:none; "><asp:Label ID="lbl_address" runat="server"></asp:Label></p>
  <div style="clear:both;"></div>
  
  

<p style="text-align:left;float: left; width:475px;    height: 36px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; 
font-weight: bold; "><asp:Label ID="lbl_contact" runat="server"></asp:Label></p>

<p style="text-align:left;float: left;width:0px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 0px;
 margin:0px 0px 0px 0px; font-size:13px; height:20px; "></p>
  <div style="clear:both;"></div>
  <p style="text-align:left;float: left; width:192px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;font-weight: bold;">Kind Attention<span style="margin:0px 0px 0px 87px">:</span>
</p>

<p style="text-align:left;float: left;width:275px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 4px; margin:0px 0px 0px 0px; font-size:13px;  "><asp:Label ID="lbl_contactname" runat="server"></asp:Label></p>
 
     <div style="clear:both;"></div>

<p style="text-align:left;float: left; width:192px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;font-weight: bold;  ">Ref # <span style="margin:0px 0px 0px 141px">:</span>
</p>

<p style="text-align:left;float: left;width:275px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 4px; margin:0px 0px 0px 0px; font-size:13px;  "><asp:Label ID="lbl_ref" runat="server"></asp:Label></p>
 
     <div style="clear:both;"></div>
    <p style=" width:1002px;padding:0px 0px 0px 0px; border-bottom: 1px solid #000;margin:0px 0px 0px 0px;"></p>
     <div style="clear:both;"></div>
    <p style="text-align:left;float: left; width:190px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 9px; margin:3px 0px 5px 0px; font-size:13px;font-weight: bold; display:none; ">Sales Person &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  :</p>

<p style="text-align:left;float: left;width:275px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 5px; margin:3px 0px 0px 0px; font-size:13px; display:none;"><asp:Label ID="lbl_salesperson" runat="server"></asp:Label></p>
 
  
  
</div>


<div style="width:465px; position: relative;left: 120px; margin: 47px 0px 0px -1px;float:left;border-top: 0px solid #000;">

<p style="text-align:center;float: left; width:492px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000;background: #d9e1f2; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; font-weight:bold; display:none;">Quote Details					
</p>
  <div style="clear:both;"></div>
<p style="text-align:right;float: left; width:185px;font-weight: bold;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 10px 0px 0px; font-size:13px;  ">
Quotation #&nbsp;&nbsp;&nbsp;&nbsp;: </p>

<p style="text-align:left;float: left;width:250px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;  "><asp:Label ID="lbl_quotno" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 
 
 
 <p style="text-align:left;float: left; width:185px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; font-weight: bold; display:none; "><asp:Label ID="lblservice" runat="server"></asp:Label></p> <%--Service (FCL/LCL)--%>

<p style="text-align:left;float: left;width:250px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 13px; margin:0px 0px 0px 0px; font-size:13px;   display:none; "></p>
 <div style="clear:both;"></div>
 
 
 
 <p style="text-align:right;float: left; width:185px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 10px 0px 0px; font-size:13px; font-weight: bold;  ">Date&nbsp;&nbsp;&nbsp;&nbsp; :</p>

<p style="text-align:left;float: left;width:250px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; "><asp:Label ID="lbl_issuedt" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 
 
 <p style="text-align:right;float: left; width:185px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 10px 0px 0px; font-size:13px; font-weight: bold;  ">Valid Till  &nbsp;&nbsp;&nbsp;&nbsp; :</p>

<p style="text-align:left;float: left;width:250px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;  "><asp:Label ID="lbl_valid" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
     <p style=" width:503px;padding:0px 0px 0px 0px; margin:8px 0px 0px 0px;"></p>
     <div style="clear:both;"></div>
  <p style="text-align:right;float: left; width:185px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:3px 0px 0px 10px; margin:0px 20px 0px 0px; font-size:13px;  font-weight: bold; display:none;">Routing & Transit Time	&nbsp;&nbsp;&nbsp;&nbsp;:
</p>

<p style="text-align:left;float: left;width:250px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:3px 0px 0px 0px; margin:0px 0px 0px 0px; font-size:13px;   display:none;"><asp:Label ID="lbl_routing" runat="server"></asp:Label>  <asp:Label ID="lbl_transittime" runat="server"></asp:Label>
    </p>
    <p style="text-align:left;float: left;width:321px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;   display:none;  "><asp:Label ID="lbl_prepared" runat="server"></asp:Label></p>
    <p style="text-align:left;float: left;width:321px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:20px; display:none;  "><asp:Label ID="lbl_impexp" runat="server"></asp:Label></p>

    <p style="text-align:left;float: left;width:321px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:20px; display:none;  "><asp:Label ID="lbl_podcountry" runat="server"></asp:Label></p>

    <p style="text-align:left;float: left;width:321px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:20px; display:none;  "><asp:Label ID="lbl_porcountry" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 <%--<p style="text-align:left;float: left; width:165px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:20px; font-weight: bold; "></p>

<p style="text-align:left;float: left;width:321px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:20px; "></p>
 <div style="clear:both;"></div>--%>
 
<%-- <p style="text-align:left;float: left; width:165px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;  height:20px;font-weight: bold; display:none;  ">Prepared By	
</p>

<p style="text-align:left;float: left;width:321px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:20px; display:none;  "><asp:Label ID="lbl_prepared" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>--%>
</div>





</div>



 <div style="clear:both;"></div>



<div style="width:1024px; margin:0px; padding:0px;display:none;">


<div style="width:500px;border-bottom: 0px solid #000;border-right: 0px solid #000; margin: 0px 0px 0px 0px;float:left;border-top: 0px solid #000;">

<p style="text-align:center;float: left; width:488px; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px;font-weight:bold; font-size:13px;border-bottom: 1px solid #000;border-right: 0px solid #000; border-left:1px solid #000;background: #d9e1f2;height:20px; ">Shipper & Consignee</p>
  <div style="clear:both;"></div>
<p style="text-align:left;float: left; width:165px; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 1px solid #000;height:44px;font-weight: bold; ">Shipper	</p>

<p style="text-align:left;float: left;width:317px; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px; border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000;height:44px; "> <asp:Label ID="lbl_shipper" runat="server"></asp:Label></p>
  <div style="clear:both;"></div>
  
  

<p style="text-align:left;float: left; width:165px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 1px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:42px;font-weight: bold; ">Consignee</p>

<p style="text-align:left;float: left;width:317px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;height:42px;  "><asp:Label ID="lbl_consignee" runat="server"></asp:Label></p>
  <div style="clear:both;"></div>
  
  


  
</div>


<div style="width:504px;border-bottom: 0px solid #000;border-right: 0px solid #000; margin: 0px 0px 0px -1px;float:left;border-top: 0px solid #000;">

<p style="text-align:center;float: left; width:491px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 1px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; height:20px;font-size:13px;background: #d9e1f2; font-weight:bold; ">Goods Description	</p>
  <div style="clear:both;"></div>
<p style="text-align:left;float: left; width:165px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; height:25px;font-size:13px; font-weight: bold; ">Description	</p>

<p style="text-align:left;float: left;width:321px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px; height:25px;  "><asp:Label ID="lbl_descn" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 
 
 
 <p style="text-align:left;float: left; width:165px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:25px; font-weight: bold; ">VALUE</p>

<p style="text-align:left;float: left;width:321px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:25px; "><asp:Label ID="lbl_value" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 
 
 

 
 <p style="text-align:left;float: left; width:165px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:25px; font-weight: bold; ">Hazmat	</p>

<p style="text-align:left;float: left;width:321px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:25px; "><asp:Label ID="lbl_haz" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 

</div>





</div>






 <div style="clear:both;"></div>



<div style="width:1024px; margin:5px 0px 0px 0px; padding:0px;">
<table width="1003" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="4" style="padding: 10px 0px 0px 10px; border-left:0px solid #000;width:290px;border-top:0px solid #000;height: 0px;border-bottom:0px solid #000;border-right:1px solid #000;text-align:center;font-weight:bold;background: #d9e1f2;display:none;">Terms Of Delivery</td>
    </tr>
  <tr>
    <td style="padding: 0px 0px 0px 10px;width:200px;border-top:0px solid #000;height: 20px;border-bottom:0px solid #000;
    border-right:0px solid #000; border-left:0px solid #000;text-align:left;font-weight: bold;">Pick Up Location &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
    <td style="padding: 0px 0px 0px 0px;width:317px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"><asp:Label ID="lbl_pickup" runat="server"></asp:Label></td>
    <td style="padding: 0px 20px 0px 10px;width:165px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:right;font-weight: bold;position: relative;left: 127px;">Mode &nbsp;&nbsp;&nbsp;&nbsp;:</td>
    <td style="padding: 0px 0px 0px 0px;width:295px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"><asp:Label ID="lbl_service" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td style="padding: 5px 0px 0px 10px;width:200px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;font-weight: bold; border-left:0px solid #000;">Place of Receipt &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
    <td style="padding: 5px 0px 0px 0px;width:317px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"><asp:Label ID="lbl_por" runat="server"></asp:Label></td>
   <td style="text-align:left;float: left; border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; font-weight: bold;    position: relative;
    left: 130px; "> <span class="Volume_name">Volume</span><span style="margin:0px 0px 0px 132px">:</span</td>
       <td style="padding: 5px 0px 0px 0px;width:282px;border-top:0px solid #000;border-bottom:0px solid #000;position: relative;left: 105px;border-right:0px solid #000;text-align:left;margin:0px;"><asp:Label ID="lbl_conttype" runat="server"></asp:Label><span class="volbarket">(</span><asp:Label ID="lbl_volume" runat="server"></asp:Label><span> M3)</span></td>
<td style="text-align:left;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 13px; margin:0px 0px 0px 0px; font-size:13px; "></td>
  </tr>
  <tr>
    <td style="padding: 5px 0px 0px 10px;width:200px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;font-weight: bold; border-left:0px solid #000;"><asp:Label ID="lblloading" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
    <td style="padding: 5px 0px 0px 0px;width:317px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"><asp:Label ID="lbl_pol" runat="server"></asp:Label></td>
    <td style="padding: 5px 20px 0px 10px;width:190px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:right;font-weight: bold;position: relative;left: 127px;">Commodity &nbsp;&nbsp;&nbsp;&nbsp;:</td>
    <td style="padding: 5px 0px 0px 0px;width:295px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"<asp:Label ID="lbl_cargo" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td style="padding: 5px 0px 0px 10px;width:165px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;font-weight: bold; border-left:0px solid #000;"><asp:Label ID="lbldischarge" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
    <td style="padding: 5px 0px 0px 0px;width:317px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"><asp:Label ID="lbl_pod" runat="server"></asp:Label></td>
    <td style="padding: 5px 20px 0px 10px;width:165px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:right;font-weight: bold;position: relative;left: 127px;">No. of Pallets &nbsp;&nbsp;&nbsp;&nbsp;:</td>
    <td style="padding: 5px 0px 0px 0px;width:295px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"><asp:Label ID="lbl_noofunits" runat="server"></asp:Label></td>
  </tr>

      <tr>
    <td style="padding: 5px 0px 0px 10px;width:200px;border-top:0px solid #000;border-bottom:0px solid #000;
    border-right:0px solid #000; border-left:0px solid #000;text-align:left;font-weight: bold;">Final of Destination <span class="final_destination">&nbsp;&nbsp;&nbsp;&nbsp; :</span></td>
    <td style="padding: 5px 0px 0px 0px;width:317px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"<asp:Label ID="lbl_fd" runat="server"></asp:Label></td>
    <td style="padding: 5px 20px 0px 10px;width:165px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:right;font-weight: bold;position: relative;left: 127px;">INCO Terms &nbsp;&nbsp;&nbsp;&nbsp; :</td>
    <td style="padding: 5px 0px 0px 0px;width:308px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:left;"><asp:Label ID="lbl_inco" runat="server"></asp:Label></td>
  </tr>
</table>

</div>





 <div style="clear:both;"></div>
     <div style="width:1024px; margin:0px; padding:0px;">
 <p style="text-align:left;float: left; width:992px;height:13px; margin:8px 0px 0px 0px; display: none;font-size:13px;font-weight:bold;">	</p>

 </div>
     <div style="clear:both;"></div>
 <div style="width:1024px; margin:0px; padding:0px;">
<p style="text-align:center;float: left; width:991px; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 0px solid #000;border-right: 1px solid #000;font-weight:bold; border-left: 1px solid #000;background: #d9e1f2;height:20px; display:none;">Cargo Specifications	</p>
  <div style="clear:both;"></div>

<div style="width:500px;border-bottom: 0px solid #000;border-right: 0px solid #000; margin: 0px 0px 5px 0px;float:left;border-top: 0px solid #000;">


<p style="text-align:left;float: left; width:186px; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000;font-weight: bold; ">Carrier Name <span style="margin:0px 0px 0px 90px">:</span></p>

<p style="text-align:left;float: left;width:282px; padding:5px 0px 0px 6px; margin:0px 0px 0px 0px; font-size:13px; border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; "><asp:Label ID="lbl_carrier" runat="server"></asp:Label></p>
  <div style="clear:both;"></div>
  
  
     <p style="padding: 5px 20px 0px 10px;width:123px;border-top:0px solid #000;border-bottom:0px solid #000;border-right:0px solid #000;text-align:right;font-weight: bold; margin:0px; float:left; display:none;" class="container">Container Type <span> &nbsp;&nbsp;&nbsp;&nbsp;:</span></p>
   

  <div style="clear:both;"></div>
  
  


  
</div>


<div style="width:503px;border-bottom: 0px solid #000;border-right: 0px solid #000; margin: 0px 0px 5px -1px;float:left;border-top: 0px solid #000;">


<p style="text-align:right;float: left; width:186px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px;position: relative;left: 120px; font-size:13px;font-weight: bold;  ">Gross Weight (KGS)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</p>

<p style="text-align:left;float: left;width:260px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 27px; margin:0px 0px 0px 0px; font-size:13px;  "><asp:Label ID="lbl_grwt" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 
 
 
 <p style="text-align:right;float: left; width:196px;border-bottom: 0px solid #000;display:none;   position: relative;
    left: 112px;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 0px; margin:5px 0px 0px 0px; font-size:13px; font-weight: bold;  "><asp:Label ID="lblcontwt" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</p>
 <p style="text-align:left;float: left;width:260px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 27px; margin:5px 0px 0px 0px; font-size:13px;display:none; "><asp:Label ID="lbl_noofcont" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 
 
 


</div>





</div>

<div style="width:1024px; margin:0px; padding:0px; display:none;">
<table width="1003" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="6" style="padding: 5px 0px 0px 5px; border-left:0px solid #000;width:290px;border-top:0px solid #000;height: 0px;border-bottom:0px solid #000;border-right:0px solid #000;font-weight: bold;text-align:center;background: #d9e1f2;">Cargo Specifications</th>
    </tr>
  <tr>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;width:200px;border-top:1px solid #000;height: 0px;border-bottom:0px solid #000;border-right:0px solid #000;text-align:center;font-weight: bold;">Pieces	</td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;width:286px;border-top:1px solid #000;height: 0px;border-bottom:0px solid #000;border-right:0px solid #000;text-align:center;font-weight: bold;">No. of Cartons/Pallets/Boxes</td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;width:240px;border-top:1px solid #000;height: 0px;border-bottom:0px solid #000;border-right:0px solid #000;text-align:center;font-weight: bold;">Volume (CBM)</td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;width:290px;border-top:1px solid #000;height: 0px;border-bottom:0px solid #000;border-right:0px solid #000;text-align:center;font-weight: bold;">Gross Weight (KGS)</td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;width:290px;border-top:1px solid #000;height: 0px;border-bottom:0px solid #000;border-right:0px solid #000;text-align:center;font-weight: bold; display:none;"> </td>  <%--Type & No of containers--%>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;width:200px;border-top:1px solid #000;height: 0px;border-bottom:0px solid #000;border-right:1px solid #000;text-align:center;font-weight: bold;">Dimensions	</td>
  </tr>
  <tr>
    <td style="padding: 5px 0px 0px 5px; border-left:0px solid #000;border-top:0px solid #000;height: 50px;border-bottom:0px solid #000;border-right:0px solid #000;text-align:center;"><asp:Label ID="lbl_pieces" runat="server"></asp:Label></td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;border-top:1px solid #000;height: 50px;border-bottom:1px solid #000;border-right:0px solid #000;text-align:center;"></td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;border-top:1px solid #000;height: 50px;border-bottom:1px solid #000;border-right:0px solid #000;text-align:center;"></td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;border-top:1px solid #000;height: 50px;border-bottom:1px solid #000;border-right:0px solid #000;text-align:center;"></td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;border-top:1px solid #000;height: 50px;border-bottom:1px solid #000;border-right:0px solid #000;text-align:center;"></td>
    <td style="padding: 5px 0px 0px 5px; border-left:1px solid #000;border-top:1px solid #000;height: 50px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:center;"><asp:Label ID="lbl_dim" runat="server"></asp:Label></td>
  </tr>
</table>

</div>





 <div style="clear:both;"></div>


 
 <div style="width:1024px; margin:0px; padding:0px;display:none;">
<p style="text-align:center;float: left; width:991px; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 0px solid #000;border-right: 1px solid #000;font-weight:bold; border-left: 1px solid #000;background: #d9e1f2;height:20px; ">Service Description	</p>
  <div style="clear:both;"></div>

<div style="width:500px;border-bottom: 0px solid #000;border-right: 0px solid #000; margin: 0px 0px 0px 0px;float:left;border-top: 0px solid #000;">


<p style="text-align:left;float: left; width:165px; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000;height:20px;font-weight: bold; ">Shipper	</p>

<p style="text-align:left;float: left;width:317px; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px; border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000;height:20px; "><asp:Label ID="lbl_ship" runat="server"></asp:Label></p>
  <div style="clear:both;"></div>
  
  

<p style="text-align:left;float: left; width:165px;border-bottom: 1px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:20px;font-weight: bold; ">Transit Time</p>

<p style="text-align:left;float: left;width:317px;border-bottom: 1px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;height:20px;  "></p>
  <div style="clear:both;"></div>
  
  


  
</div>


<div style="width:504px;border-bottom: 0px solid #000;height:103px; border-right: 1px solid #000; margin: 0px 0px 0px -1px;float:left;border-top: 1px solid #000;">


<p style="text-align:left;float: left; width:165px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; height:20px;font-size:13px;font-weight: bold;  ">Routing	</p>

<p style="text-align:left;float: left;width:322px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px; height:20px;  "></p>
 <div style="clear:both;"></div>
 
 
 
 <p style="text-align:left;float: left; width:165px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:20px;font-weight: bold;  ">Ex-Change Rate	</p>
 <p style="text-align:left;float: left; width:65px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:20px; font-weight: bold; ">EUR</p>
<p style="text-align:left;float: left;width:85px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 0px; margin:0px 0px 0px 0px; font-size:13px;  height:20px; "><asp:Label ID="lbl_eur" runat="server"></asp:Label></p>

 <p style="text-align:left;float: left; width:65px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; height:20px;font-weight: bold;  ">USD</p>
<p style="text-align:left;float: left;width:84px;border-bottom: 0px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:10px 0px 0px 5px; margin:0px 0px 0px 0px; font-size:13px;  height:20px; "><asp:Label ID="lbl_usd" runat="server"></asp:Label></p>
 <div style="clear:both;"></div>
 
 
 


</div>





</div>



 <div style="clear:both;"></div>
 
 <div style="width:1024px; margin:0px; padding:0px;">
<p style="text-align:center;float: left; width:991px; padding:0px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;border-bottom: 0px solid #000;border-right: 0px solid #000;font-weight:bold; border-left: 0px solid #000;height:0px; "></p>
  <div style="clear:both;"></div>
 
 <div style="width:1024px; margin:0px; padding:0px;">
<table width="1003" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:710px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:center;">Charges</th>
    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:100px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:center;">Curr</th>
    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:150px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Rate</th>

    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:150px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Ex Rate</th>
    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:220px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Base</th>
    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:150px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Units</th>
    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:250px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Amount in FC</th>
    <th style="padding: 3px 5px 3px 5px; border-left:0px solid #000;width:250px;border-top:1px solid #000;height: 0px;border-bottom:1px solid #000;border-right:0px solid #000;text-align:right;">Amount in  <asp:Label ID="lblbascurr" runat="server"></asp:Label></th>
  </tr>
    <tr>
  <asp:Label ID="tdRow_QuotDtls" runat="server"></asp:Label>
        </tr>
     <tr>
          <td colspan="6" style="font-weight:bold;padding: 5px 5px 0px 5px; border-left:0px solid #000;width:250px;border-top:0px solid #000;border-left:0px solid #000;height: 0px;border-bottom:2px solid #000;border-right:0px solid #000;text-align:right;background: #d9e1f2;">Total</td>

 <td style="padding: 5px 5px 0px 5px; border-left:0px solid #000;width:250px;border-top:0px solid #000;border-left:0px solid #000;height: 0px;border-bottom:2px solid #000;border-right:0px solid #000;text-align:right;background: #d9e1f2;"><asp:Label ID="lblFCtotal" runat="server"></asp:Label></td>
          <td style="padding: 5px 5px 0px 5px; border-left:0px solid #000;width:250px;border-top:0px solid #000;height: 0px;border-bottom:2px solid #000;border-right:1px solid #000;text-align:right;background: #d9e1f2;"><asp:Label ID="lbltotal" runat="server"></asp:Label></td>
        </tr>
    </table>

</div>





 <div style="clear:both;"></div>
 
 <div style="width:1024px; margin:0px; padding:0px;">
 <p style="text-align:left;float: left; width:991px;border-bottom: 1px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;font-weight:bold;background: #d9e1f2;  ">Remarks</p>
 <p style="text-align:left;float: left; width:991px;border-bottom: 1px solid #000;border-right: 0px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; height:35px;font-size:13px;  "><asp:Label ID="lbl_remarks" runat="server"></asp:Label></p>
 </div>


 <div style="clear:both;"></div>
 
 <div style="width:1024px; margin:0px; padding:0px;">
 <p style="text-align:left;float: left; width:992px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 0px solid #000; padding:5px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:13px;font-weight:bold;background: #d9e1f2;  ">Terms And Conditions	</p>
 <p style="text-align:left;float: left; width:991px;border-bottom: 0px solid #000;    white-space: pre-wrap;border-right: 0px solid #000; border-left: 0px solid #000; padding:0px 0px 0px 10px; margin:0px 0px 0px 0px; font-size:14px;  ">
<asp:Label ID="lbl_terms" runat="server" CssClass="relative"></asp:Label>     </p>
 </div>



 <div style="clear:both;"></div>
 
 <div style="width:1024px; margin:0px 0px 0px -1px; padding:0px;">
 <p style="text-align:right;float: left; width:987px;border-bottom: 0px solid #000;border-right: 1px solid #000; border-left: 1px solid #000; padding:5px 5px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; font-weight: bold; ">For <asp:Label ID="lbl_for" runat="server"></asp:Label></p>
 
 <p style="text-align:right;float: left; width:987px;border-bottom: 1px solid #000;border-right: 1px solid #000; border-left: 1px solid #000; padding:38px 5px 0px 10px; margin:0px 0px 0px 0px; font-size:13px; font-weight: bold; "><asp:Label ID="lblsales" runat="server"></asp:Label></p>
 </div>


     <div style="clear:both;"></div>
 
 <div style="width: 1000px;height: 25px;
    box-sizing: border-box;padding:0px 10px; display:flex;display: none;justify-content:space-between">
 <p style=" font-size:13px; font-weight: bold; ">Prepared By</p>
 <p style=" font-size:13px; font-weight: bold; ">Approved By</p>
 
 </div>


     <div style="clear:both;"></div>
 
 <div style="width: 1000px;
    box-sizing: border-box;padding:0px 10px; display:flex;display: none;justify-content:space-between">
 <p style=" font-size:13px; font-weight: bold; "><asp:Label ID="lbl_preparedby" runat="server"></asp:Label></p>
 
 <p style=" font-weight: bold; "><asp:Label ID="lbl_appro" runat="server"></asp:Label></p>
 </div>







 







</div>


</body>
</html>

