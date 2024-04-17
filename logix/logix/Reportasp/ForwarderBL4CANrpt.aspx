<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForwarderBL4CANrpt.aspx.cs" Inherits="logix.Reportasp.ForwarderBL4CANrpt" %>

<%--<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>

<title>FICAN FORWARDER</title>
<style type="text/css" media="print">
thead{display:table-header-group;}
  

</style>

    <style type="text/css" media="screen">
        thead{
            display: block;
        }

        tbody {
            height:1200px;
            
        }
     
    </style>
    <style type="text/css">
    @media print {
    thead { display: table-header-group; }
  }
  </style>
 
</head>--%>
<!doctype html>
<html>
<head>
<meta http-equiv="Content-Type" charset="utf-8"/>
<title>FICAN FORWARDER</title>

    <style type="text/css">
.TableHeader tfoot{text-align:left!important;}
        .TableHeader tbody  {display:normal!important;}
        .TableHeader thead  {display: table-header-group;}
    </style>
    <style type="text/css" media="print">
.TableHeader thead {display: table-header-group;}
.TableHeader tfoot{text-align:left!important;}
.TableHeader tbody  {display:normal!important;}
</style>
</head>


<body>
   
<table style="width:1024px; margin:0px auto; font-size:14px; font-family:Tahoma, Geneva, sans-serif; line-height:18px; color:#000;" cellpadding="0" cellspacing="0" class="TableHeader">
<thead>
  <tr>
    <th colspan="2">
        <div style="float:left; width:132px; margin:15px 5px 5px 5px;"> <asp:Image ID="img_Logo" runat="server" width="132" height="auto"  /></div>
<div style="width:845px; float:left;">
<h3 style="text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; "><asp:Label ID="lbl_branch" runat="server" ></asp:Label></h3>
<p style="font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_addre" runat="server" ></asp:Label>
</p>
<p  style="font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lblphfax" runat="server" ></asp:Label></p>

</div>

    </th>
  </tr>
     <tr>
    <th style="border-top:1px solid #000; border-bottom:1px solid #000; border-left:1px solid #000; border-right:1px solid #000;" colspan="2"><h1 style="text-align:center; padding:10px 0px 10px 0px; font-size:21px;">CARGO ARRIVAL NOTICE</h1></th>
  </tr>
   
    </thead>
    
 <tr>
       <th style="width:512px;" valign="top">
           <div style="width:512px; float:left; border-right:1px solid #000; min-height:150px; border-left:1px solid #000;">
    <p style="padding:5px 5px 5px 10px; margin:0px 0px 0px 0px; text-align:left;">To</p>
    <p style="white-space:pre-line; padding:5px 5px 5px 10px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_TO" runat="server" ></asp:Label></p>
    </div>
           <div style="width:512px; float:left; border-right:1px solid #000; border-left:1px solid #000; border-top:1px solid #000;">
     <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">Mother Vsl/Voy</div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:270px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_motvslvoy" runat="server" ></asp:Label></div>
    <div style="clear:both;"></div>
     <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">Feeder Vsl/Voy</div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:270px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_feedvslvoy" runat="server" ></asp:Label></div>
    <div style="clear:both;"></div>
     </div>
           </th>



               <th style="width:512px;" valign="top">

              
     <div style="width:511px; float:left; border-right:1px solid #000; height:150px;">
    
     <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">CAN Date</div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:270px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_candt" runat="server" ></asp:Label></div>
    <div style="clear:both;"></div>
       <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">Job #</div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:270px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_jobno" runat="server" ></asp:Label></div>
    <div style="clear:both;"></div>
    
    
     <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">IM # & Date</div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:270px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_IMandDT" runat="server" ></asp:Label></div>
    <div style="clear:both;"></div>
    
     <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">MBL #</div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:270px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_mblanddate" runat="server" ></asp:Label></div>   <%--MDCHE2001585 & <strong>DT :</strong> <span>11/12/2020</span>--%>
       
          <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">Your BL # </div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:270px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lblYourblno" runat="server" ></asp:Label></div>   <%--MDCHE2001585 & <strong>DT :</strong> <span>11/12/2020</span>--%>
               
    <div style="clear:both;"></div>
     </div>

      <div style="width:511px; float:left; border-right:1px solid #000; border-top:1px solid #000; height:57px;">
      <div style="float:left; width:155px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; text-align:left;">CFS</div>
     <div style="float:left; width:1px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px;">:</div>
     <div style="float:left; width:250px; padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; text-align:left; font-weight:normal;"><asp:Label ID="lbl_cfs" runat="server" ></asp:Label></div>
    <div style="clear:both;"></div>
      
      </div>


                 
       </th>
   </tr>
  

    
    <tbody>

  <tr>
     
      
    
        <td colspan="2">
            
           
            
        <div><asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label></div>    </td>
    </tr>

    </tbody>

    <tfoot>
     <tr>
         <th colspan="2">
               <div style="border-left:1px solid #000; border-right:1px solid #000; width:1024px; float:left;border-bottom:1px solid #000;   ">
     <p style="padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:bold; font-size:14px;">Container Details</p>
     <p style="padding:5px 5px 5px 15px; margin:0px 0px 0px 0px; font-weight:normal; font-size:14px;"><asp:Label ID="lbl_contdtls" runat="server" ></asp:Label></p>
     
    
    
     </div>
   
         <div id="set" runat ="server" visible="false" style="width:1024px; border-left:1px solid #000; border-right:1px solid #000; float:left; border-bottom:1px solid #000;">
<div style="width:1024px; margin:0px auto;">
<p style="font-weight:bold; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">Dear Sir/ Madam</p>
<p style="font-weight:normal; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">Please be advised that the above mentioned vessel is scheduled to arrive <span style="font-weight:bold;"><asp:Label ID="lblpod" runat="server" ></asp:Label></span> on <span style="font-weight:bold;"><asp:Label ID="lbleta" runat="server" ></asp:Label></span></p> 
<p style="font-weight:normal; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">Kindly arrange to present the original Bill of Lading & Freight Certificate (if it is Collect Shipment) and obtain a delivery order against payment of necessary charges by DEMAND DRAFT. </p>

<p style="font-weight:normal; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">Please note we will not hold the FCL Container(s)  in the Terminal beyond 3 days or as specified by the Terminal and or  Carrier from the day of vessel arrival.  We will move the container to off-Dock CFS after completion of free-days under your cost and risk.</p>
    <p style="font-weight:normal; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">If you are not cleared within the stipulated time same will be abandoned and we will not be responsible for any consequences.</p>

<p style="font-weight:normal; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">Looking forward to your speedy clearance of cargo.</p>
<p style="font-weight:normal; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">We can accept cash upto Rs. 5000 only, if it exceeds please pay through Demand Draft</p>
<p style="font-weight:normal; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px;">PENALTY SLABS FOR LATE COLLECTION OF DELIVERY ORDER</p>
<div style="clear:both;"></div>
</div>
<div style="width:1024px; margin:0px auto;">
<div style="float:left; width:170px; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px; font-weight:bold;">Upto15 days</div>
<div style="float:left; width:1px; margin:0px 15px 5px 0px; padding:5px;">:</div>
<div style="float:left; width:400px; margin:0px 0px 5px 0px; padding:5px 5px 5px 5px; font-weight:normal;">    No fine (starting from the devanning date).</div>
<div style="clear:both;"></div>
<div style="float:left; width:170px; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px; font-weight:bold;">Between 15-30 days</div>
<div style="float:left; width:1px; margin:0px 15px 5px 0px; padding:5px;">:</div>
<div style="float:left; width:400px; margin:0px 0px 5px 0px; padding:5px; font-weight:normal;"> Rs.1000/BL</div>
<div style="clear:both;"></div>

<div style="float:left; width:170px; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px; font-weight:bold;">Between 30-60 days</div>
<div style="float:left; width:1px; margin:0px 15px 5px 0px; padding:5px;">:</div>
<div style="float:left; width:400px; margin:0px 0px 5px 0px; padding:5px; font-weight:normal;">  Rs.1500/BL</div>
<div style="clear:both;"></div>
<div style="float:left; width:170px; margin:0px 0px 5px 0px; padding:5px 5px 5px 15px; font-weight:bold;">Above 60 days</div>
<div style="float:left; width:1px; margin:0px 15px 5px 0px; padding:5px;">:</div>
<div style="float:left; width:400px; margin:0px 0px 5px 0px; padding:5px; font-weight:normal;">     Rs.5000/BL</div>
<div style="clear:both;"></div>
</div>


<div style="width:1024px; margin:0px auto;">
<p style="padding:5px 5px 5px 15px; margin:0px 0px 40px; 0px;">Thanking You</p>
<p style="padding:5px 5px 5px 15px; margin:0px 0px 10px; 0px; font-weight:bold;">
THIS IS A COMPUTER GENERATED DOCUMENT AND HENCE REQUIRES NO SIGNATURE
</p>
</div>
<div style="clear:both;"></div>
</div>
         </th></tr>
      </tfoot>
   
</table>
</body>
</html>
