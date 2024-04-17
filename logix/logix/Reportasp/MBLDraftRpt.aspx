<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MBLDraftRpt.aspx.cs" Inherits="logix.Reportasp.MBLDraftRpt" %>

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
img#img_signature {
      scale: 1;
    height: auto;
    width: 286px;
    margin: 2px 0px 0px -75px;
}
img#img_Logo {
        width: auto;
        height: 44px;
        padding-left: 20px;
}
    span#lbl_pkg {
        display: none;
    }
        span#lbl_delicontact {
    white-space: pre-line;
}
    span#lbl_cbm {
    position: relative;
    top: 9px;
}
/*body{
    border:none !important;
}*/
span#lbl_contpkg {
    margin-left:38px !important;
}
</style>
</head>
   	
<body style="font-family:sans-serif, Geneva, sans-serif; font-size:14px; color:#000;">

<div style="width:1024px; margin:0px auto 0px auto;" class="blhide">


<p style="font-size:18px; font-weight:bold; margin:0px; padding:5px 0px 5px 5px;">Bill Of Lading</p></div>


<div style="width:1024px; margin:0px auto 0px auto;  border:1px solid #000;"class="borderhide">
  <div style="float:left; width:512px; border-right:1px solid #000;"class="borderhide">
    
    <div style="float:left; width:512px; border-bottom:1px solid #000; min-height:122px;" class="borderhide">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 0px 10px; margin:0px;" class="blhide">Consignor/Shipper</p>
      <p style="font-size:14px; font-weight:normal;  padding:5px 5px 0px 10px;white-space: pre-line; margin:0px; "><asp:Label ID="lbl_conshipaddress" runat="server"></asp:Label><br />
          </p>
    </div>
    
    <div style="float:left; width:512px; border-bottom:1px solid #000; min-height:122px;" class="borderhide">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 0px 10px; margin:0px;" class="blhide">Consignee (IF 'To Order' so indicate)</p>
      <p style="font-size:14px; font-weight:normal;  padding:5px 5px 0px 10px;white-space: pre-line; margin:0px; "><asp:Label ID="lbl_conaddress" runat="server"></asp:Label><br />
          </p>
    </div>
    <div style="float:left; width:512px;min-height:122px;">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 0px 10px; margin:0px;" class="blhide">Notify Party (No claim shall attach for failure to notify) </p>
        <p style="font-size:14px; font-weight:normal;  padding:5px 5px 0px 10px;white-space: pre-line; margin:0px; "><asp:Label ID="lbl_notifyaddress" runat="server"></asp:Label>
          </p>
    </div>
    <div style="float:left;height: 63px; width:255px; border-right:1px solid #000; border-bottom:1px solid #000; min-height:45px;border-top:1px solid #000" class="borderhide">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Place of Receipt</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_POR" runat="server"></asp:Label></p>
      </div>

        <div style="float:left; width:255px;height: 63px;border-top:1px solid #000;border-bottom:1px solid #000;"class="borderhide">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Port of Loading</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_POL" runat="server"></asp:Label></p>
      </div>
    <div style="float:left; width:255px;border-right:1px solid #000;height: 63px;"class="borderhide">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px; "class="blhide">Port of Discharge</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_POD" runat="server"></asp:Label>  </p>
      </div>
    <div style="float:left; width:255px;height: 63px;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Place of Delivery</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_PODel" runat="server" ></asp:Label> </p>
      </div>
    
  </div>
  <div style="float:left; width:511px;">
   
    <div style="float:left; width:511px;">
        <div style="float:left;width:333px;margin-left:190px;">
        <div style="float:left;width:105px;border:1px solid #000;margin-top:30px;"class="borderhide">
           <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 5px;margin:0px;"class="blhide">B/L. No.</p>
        </div>
        <div style="float:left;width:200px;margin-top:30px;border-top:1px solid #000;border-bottom:1px solid #000;border-right:1px solid #000;"class="borderhide">
        <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 5px; margin:0px;"> <asp:Label ID="lbl_blno" runat="server"></asp:Label>
            <br />
           
          </p>
      </div>
     <div style="float:left;width:105px;border-bottom:1px solid #000;border-left:1px solid #000;border-right:1px solid #000;"class="borderhide">
     <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 5px;margin:0px;"class="blhide">Reference No.</p>
  </div>
  <div style="float:left;width:200px;border-bottom:1px solid #000;border-right:1px solid #000;"class="borderhide">
  <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 5px; margin:0px;"> <asp:Label ID="lbl_jobno" runat="server"></asp:Label>
      <br />
     
    </p>
</div>
<%--                 <div style="float:left;width:54px;border-bottom:1px solid #000;border-left:1px solid #000;"class="borderhide">
     <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 5px;margin:0px;"class="blhide">Job #</p>
  </div>
              <div style="float:left;width:42px;border-bottom:1px solid #000;border-right:1px solid #000;"class="borderhide">
  <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 5px; margin:0px;"> <asp:Label ID="lbl_jobno" runat="server"></asp:Label>
      <br />
     
    </p>
</div>--%>
            </div>
       <div style="float:left; width:511px; border-bottom:1px solid #000; min-height:67px;display:none;">
 
 </div>
  </div>
<div style="margin:22px 0 0;text-align: center;display:none;">
    <%--<img src="../Theme/assets/img/buttonIcon/report_logo.png" alt="" Visible="false" />--%>
</div>
<div style="clear:both;"></div>
     

   <%--PK--%>
<div style="float:left;width:511px;margin-top:10px;"class="blhide">
    <div style="float:left;width:158px;height:90px;text-align:center;">
      <asp:Image id="img_Logo" runat="server" ImageUrl=""/>

    </div>
    <div style="float:left;width:351px;">
     <p style="font-size:19px; font-weight:bold;padding:5px 5px 0px 5px; margin:0px;text-align:center;">Marin<span style="color:red !important;">air</span> Cargo India Pvt Ltd.,</p>
     <p style="font-size:14px; font-weight:normal; padding:5px 5px 0px 5px; margin:0px;text-align:center;">#4, 2nd Street, Ponni Nagar, Pammal,</p>
     <p style="font-size:14px; font-weight:normal;padding:5px 5px 0px 5px; margin:0px;text-align:center;">Chennai - 600 075. India</p>
     
    </div>
</div>
<div id="comlogo"  runat="server" visible="false" style="float:left; width:511px; min-height:276px;display:none; ">
<div style="float:left;width:511px;">
<div style="float:left;width:150px;">
  <%--<asp:Image id="Image1" runat="server"  width="75"/>--%>

     <%--<asp:Image id="img_Logo" runat="server"  width="75"  Visible="false" ImageUrl="../images/MarinAir.png"  />--%>

</div>
<div style="clear:both;"></div>
      <div style="display:none" >
     <p style="font-size:19px; font-weight:bold;text-align: center;  padding:5px 5px 0px 5px; margin:0px;">SWENLOG SUPPLY CHAIN SOLUTIONS PVT LTD</p>
<p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"><b> Regd Office</b>: No 45, 1st Floor, 1st Main Road, West Shenoy Nagar,  </p>
 <p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"> <b>Chennai- 600 030. India. Email: info@swenlog.com Website: www.swenlog.com</b> </p>
 <%--<p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"> <b> Chennai India. </p>--%>
 <p style="font-size:14px; font-weight:bold; text-align: center; padding:5px 5px 0px 5px; margin:0px;">  Registration No. MTO / DGS / 2569 / JAN / 2025</p>
  <p style="font-size:14px; font-weight:bold; text-align: center; padding:5px 5px 0px 5px; margin:0px;">  FMC Reg. No.: 031710</p>
   <%--<p style="font-size:19px; font-weight:bold;text-align: center;  padding:5px 5px 5px 5px; margin:0px;">Registration No. MTO/DGS/2015/APR/2022</p>--%>
        
      </div>

</div>


  </div>
   <div style="float:left; width:511px;"class="blhide">
     <p style="font-size:14px; font-weight:bold;  padding:5px; margin:0px;text-align:center;">BILL OF LADING</p>

         <p style="text-align:justify; font-size:11px; margin:2px 2px 2px 2px; font-family:arial; font-weight:normal;padding:0px 10px 0px 10px;">Received in apparent good carrier and conditions (Unless otherwise stated herein) the goods of containers of other packages said to contain goods herein mentioned
             to be delivered.subject to the exceptions, conditions, provisions and liberties herein contained (and whether written, printed or stamped on the front of reverse hereof) in the like good order condition,upto the above consignee or to his or their assigns which persons are herein included in the term consignee.
             Freight for the said goods with primage, if any shall be due and payable by the merchant of shipment at place of receipt in cash without deduction, vessel or cargo lost or not lost, If freight is not so paid on shipment at place of receipt. It shall be due from and payable on demand by the consignee at place at destination.
             Vessel or cargo lost or not lost,in which case freight to be calculated and paid at any additional rate applicable when freight is payable on delivery together with the cost of telegraph advices of non payment.


          </p>
        <p style="text-align:justify; font-size:11px; margin:2px 2px 2px 2px; font-family:arial; font-weight:normal;padding:10px 10px 0px 10px;">In Witness Where if the Master or duly authorised agent to the said vessel hath affirmed to the below number of original Bills of lading all of this tenor & date one which being accomplished the other to stand void.</p>
        <p style="text-align:justify; font-size:11px; margin:2px 2px 2px 2px; font-family:arial; font-weight:normal;padding:10px 10px 0px 10px;">The term apparent good order and conditions when used on the Bill of lading with reference to iron.steel or metal product does not mean that the goods when received were free or visible rust or moisture.if the shipper so requests, a substitude Bill of lading
            will be issued omitting the above definition and setting forth any notation as tourist or moisture which may appear on the Male's or Tally clerk's receipts.
        </p>

     <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; line-height:18px; display:none;">   
         <br />
         </p>
   </div>



  </div>
 
 
  <div style="float:left; width:1024px; min-height:45px;">
    <div style="float:left;height: 63px; width:256px; border-right:1px solid #000; border-bottom:1px solid #000;border-top:1px solid #000;display:none;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Pre Carriage by</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"> <asp:Label ID="lbl_precarriage" runat="server"></asp:Label> </p>
      </div>
     
    <div style="float:left; height: 63px;width:290px; border-right:1px solid #000;border-top:1px solid #000;"class="borderhide">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Vessel / Voy No</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_vessel" runat="server"></asp:Label>/<asp:Label ID="lbl_voy" runat="server"></asp:Label></p>
      </div>
      

     <div style="float:left; width:284px; border-right:1px solid #000;border-top:1px solid #000; height: 63px;"class="borderhide">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Freight Payable at</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_freightpayat" runat="server"></asp:Label></p>
      </div>

    <div style="float:left;height: 63px; width:235px; border-right:1px solid #000;border-top:1px solid #000;"class="borderhide">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Terms</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="label_terms" runat="server"></asp:Label></p>
      </div>
      <div style="float:left;height: 63px; width:212px; border-top:1px solid #000;"class="borderhide">
    <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">No.Of Original Bill of Ladings</p>
    <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_nooforigi" runat="server"></asp:Label></p>
  </div>

   
  </div>
 
 <div style="clear:both;"></div>
      
  <div style="width:1024px;">
    <table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding:0px; font-size:14px; border-top:0px solid #000; border-bottom:0px solid #000;"class="borderhide">
      <tr class="bltableheadhide">
        <th  style="font-weight:normal; padding:5px 0px 5px 0px; font-size:14px; text-align:center; width:256px; border-right:0px solid #000; border-top:1px solid #000; border-bottom:0px solid #000;font-weight:bold;"class="borderhide"> Marks & Nos.<br /> Container & Seals</th>
       
        <th  style="font-weight:normal; padding:5px 0px 5px 0px; font-size:14px; border-right:0px solid #000; width:498px; border-top:1px solid #000; border-bottom:0px solid #000;font-weight:bold;"class="borderhide">Kind of Packages Description of Goods, Marks & Nos</th>
        <th  style="font-weight:normal; padding:5px 0px 5px 0px; font-size:14px; text-align:right; border-right:0px solid #000; border-top:1px solid #000; border-bottom:0px solid #000;font-weight:bold;padding-right:28px;"class="borderhide">Gross Weight</th>
        <th  nowrap="nowrap" style="font-weight:normal; padding:5px 0px 5px 0px; text-align:left; width:130px;font-size:14px; border-top:1px solid #000; border-bottom:0px solid #000;font-weight:bold;"class="borderhide">Measurement</th>
        <th  nowrap="nowrap" style="font-weight:normal; padding:5px 0px 5px 0px; font-size:14px; border-top:1px solid #000; border-bottom:0px solid #000;"class="borderhide"></th>
       
      </tr>
      <tr>
        <td style="font-weight:bold; padding:5px; text-align:left; border-right:0px solid #000;"></td>
      
        <td  colspan="1" nowrap="nowrap" style=" padding:5px; text-align:center; padding-right:35px; border-right:0px solid #000;" class="borderhide" >
       
        <span style="font-weight:bold;  width:140px;  padding:0px 0px 0px 0px; display:inline-block; text-align:center;">SAID TO CONTAIN</span>

          
          
             <span style="font-weight:normal; display:inline-block; float:left; padding:0px 5px 0px 5px; width:60px; text-align:left;"> </span>
        </td>
        <td nowrap="nowrap"  style="font-weight:bold; padding:5px 2px 5px 5px; text-align:right; border-right:0px solid #000;"class="borderhide">SAID TO WEIGHT </td>
         <td nowrap="nowrap"  style="font-weight:bold; padding:5px 0px 5px 2px; text-align:left; border-right:0px solid #000;"class="borderhide">/ MEASURE</td>
      </tr>
      <tr>
        <td  style="vertical-align:top; width:200px; border-right:0px solid #000; "class="borderhide" >
            
            <p style="font-weight:normal; padding:5px 5px 5px 10px; text-align:left; white-space:pre-wrap; margin:0px; line-height:18px;display:flex;margin-top:14px;">
 <asp:Label ID="lbl_marks" runat="server"></asp:Label>
                <asp:Label ID="lbl_contpkg" runat="server"></asp:Label>
</p>
            
           <p style="font-weight:normal; padding:135px 5px 5px 10px; white-space:pre-line; text-align:left;  margin:0px; line-height:18px; width:222px; word-break:break-word;"><asp:Label ID="lbl_container" runat="server"></asp:Label></p>  
            
           </td>
       
        
      
        
        
     
        <td  style="vertical-align:top; border-right:0px solid #000;"class="borderhide"><p style="font-weight:normal; margin:0px; padding:5px 5px 5px 5px; text-align:left; white-space:pre-line; vertical-align:top; line-height:15px; height:350px;"><asp:Label ID="lbl_pkg" runat="server" Text=""></asp:Label><br /> <asp:Label ID="lblDescription" runat="server"></asp:Label></p>

         
        </td>
        <td  valign="top" style="font-weight:normal; padding:5px; text-align:right; border-right:0px solid #000;"class="borderhide">
      
      <p style="font-weight:bold; padding:15px 5px 5px; text-align:left; white-space:pre; "><asp:Label ID="lbl_shiptype" runat="server"></asp:Label> <br />
</p>
<p style="font-weight:normal; padding:5px; text-align:right;  line-height:18px;position:relative;top:-72px;"> 
         <span style="font-weight:bold;"></span>
    <asp:label text="Gross Weight" id="Labelgrss" runat="server"></asp:label>
      <br />
           <asp:Label ID="lbl_grwt" runat="server"></asp:Label></p>
          <p style="font-weight:normal; padding:5px; text-align:right; line-height:18px;position:relative;top:-83px;left:-17px;"> 
              
              
         <span style="font-weight:bold;"></span>
              <asp:label text="Net Weight" id="Labelnet" runat="server"></asp:label><br />
           <asp:Label ID="lbl_netwt" runat="server"></asp:Label> </p>
         
        <br />
                        <p style="font-weight: bold; padding: 5px; text-align: right; white-space: pre; margin-top: 10px;">
                            <asp:Label ID="lbl_type" runat="server"></asp:Label><br />
                            <asp:Label ID="lbl_mtype" runat="server"></asp:Label><br />
                            
                        </p>


</td>
           <td style="font-weight: normal; padding: 5px; text-align: left; vertical-align: top;">

                        <p style="font-weight: normal; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px; text-align: center; white-space: nowrap;">

                            <asp:Label ID="lbl_cbm" runat="server"></asp:Label>
                        </p>

                    </td>
       <%-- <td style="font-weight:normal; padding:15px 5px 5px; text-align:left;"><p style="font-weight:normal; padding:5px 0px 5px 0px; text-align:left; font-weight:bold; margin:-35px 0px 0px 0px; line-height:18px; ">
                 <asp:label text="CBM" id="lblcbm" runat="server"></asp:label>
                 </p>

            <p style="padding:5px; margin:0px;"> <asp:label  id="lbl_cbm" runat="server"></asp:label></p>


        </td>--%>
        
      </tr>
      
     <tr>
    <td style="padding:5px; margin:0px; font-weight:bold; font-size:12px; white-space:nowrap;"><asp:Label ID="lblAnnexcontainer" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
    <td style="padding:5px; margin:0px; font-weight:bold; font-size:12px;"><asp:Label ID="lblAnnexMarks" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
    <td style="padding:5px; margin:0px; font-weight:bold; font-size:12px;"> <asp:Label ID="lblAnnexDesc" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
    <td style="padding:5px; margin:0px;">&nbsp;</td>
    <td style="padding:5px; margin:0px;">&nbsp;</td>
  </tr>
      <tr><td colspan="5"> <div id="background" style="margin:0px auto; text-align:center; width:1024px; font-size: 36px;  color: rgba(0,0,0,0.2);">
  <p style="margin:0;" ><asp:Label ID="lbl_bltype" runat="server" Visible="false" ></asp:Label></p>
	</div></td></tr>
 
    
     
    
    
    
    </table>
  </div>

    <div style="width:1024px; margin:0px auto; border-bottom:1px solid #000; border-top:1px solid #000; border-left:0px solid #000;
     border-right:0px solid #000;display:none; ">
  <p style="margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; text-align:center; font-weight:bold; vertical-align:middle; font-size:14px;">(1) SHIPPER'S LOAD STOW,COUNT & SEAL (2) ALL DESTINATION CHARGES ON CONSIGNEE'S ACCOUNT</p>
  
  </div>
    <div style="width:1024px; margin:0px auto; border-bottom:0px solid #000; border-top:0px solid #000; border-left:0px solid #000; border-right:1px solid #000;display:none; ">
  <p style="margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; text-align:center; font-weight:bold; vertical-align:middle; font-size:14px;">ABOVE PARTICULARS DECLARED BY SHIPPER,CARRIER NOT RESPONSIBLE</p>
  
  </div>
  <div style="width:1024px; float:left; border-top:1px solid #000;display:none;">

    <div style="float:left; width:512px;">
      <div style="font-size:14px; font-weight:normal;  padding:1px 5px 1px 10px; margin:0px; float:left; min-height:40px;  width:497px; border-bottom:1px solid #000;display:none;"> For Delivery Please Apply To
<br/>
          <p style="font-size:14px; font-weight:normal;  padding:2px 5px 2px 10px; margin:0px;  "><asp:Label ID="lbl_totcont" runat="server"></asp:Label></p>
      </div>
       
        <div style="clear:both;"></div>
      <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; border-bottom:1px solid #000; margin:0px; float:left; min-height:40px; width:512px; display:none;">Cargo Shall not delivered unless freight and charges not paid</div>    
      <div style="width:512px; border-bottom:1px solid #000; min-height:50px;">
       <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; ">Freight Details, Charges etc</div>
      <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px;  "> <asp:Label ID="lbl_freight" runat="server"></asp:Label></div>
        </div>     
        <div style="float:left; width:512px; border-bottom:0px solid #000; min-height:210px;">
        <div style="font-size:12px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; float:left;  width:499px; text-align:center; ">
        For Delivery Please Apply To
</div>
        <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; float:left; min-height:60px; width:490px;white-space: pre-line"> <asp:Label ID="lbl_delicontact" runat="server"></asp:Label></div>
        </div>       
       <div style="font-size:14px; font-weight:bold;  padding:15px 5px 15px 10px; margin:0px; float:left;  width:150px; display:none; ">Freight Payable at :</div>
      <div style="font-size:14px; font-weight:normal;  padding:15px 5px 15px 10px; margin:0px; float:left;  width:331px; display:none;"> </div>
      <div style="font-size:14px; font-weight:bold;  padding:15px 5px 15px 10px; margin:50px 0px 0px 0px; float:left;  width:150px; display:none; ">Mode of Shipment</div>
      <div style="font-size:14px; font-weight:bold;  padding:15px 5px 15px 10px; margin:50px 0px 0px 0px; float:left;  width:331px; display:none;">Shipped on board :</div>
    </div>
    <div style="float:left; width:510px; border-left:1px solid #000; min-height:265px;">
        <div style="width:510px; float:left; border-bottom:1px solid #000; min-height:42px;">          
            <p style="padding:5px 5px 5px 10px; margin:0px;font-weight:bold; font-size:12px; width:495px; line-height:18px; text-align:justify;">
            FREIGHT PARTICULARS</p>
              
        </div>
                
        <div style="width:510px; float:left; border-bottom:1px solid #000; min-height:35px;">
            <p style="font-size:12px; font-weight:BOLD;  padding:1px 5px 1px 10px; margin:0px; float:left; ">Place and date of issue :</p> 
             <p style="font-size:12px; font-weight:BOLD;  padding:1px 5px 1px 10px; margin:0px;float:right;  "> Number of ORGINAL B/Ls</p>
            <p style="font-size:14px; font-weight:normal;  padding:5px 5px 0px 10px; margin:0px; float:left;  width:264px;"><asp:Label ID="lbl_placedtofisue" runat="server"></asp:Label></p>
             <p style="font-size:14px; font-weight:normal;  padding:5px 5px 0px 10px; margin:0px; float:left; text-align:right; width:180px;"></p>
            </div>
         <div style="clear:both;"></div>
     
          <%-- DEMO COMPANY--%>
       <div style="clear:both;"></div>
        



      

       <div style="font-size:14px; font-weight:bold;width:510px; padding:0px 0px 0px 0px; text-align:right; margin:53px 0px 0px 0px; float:left;  ">
       
       <p style=" float:left;font-weight:normal;width:12px;margin:10px 0px 0px 10px;" >by</p>
        <p style=" float:left;font-weight:normal;width:236px;margin:23px 0px 0px 6px;border-bottom:1px solid #000;"></p>
       </div>      
    </div>   
  </div>
    <div style="width:1024px;display:none;">
        <table style="border-top:1px solid #000;width:100%;border-collapse:collapse;height:200px;">
            <thead>
                <tr>
                    <th style="border-bottom:1px solid #000;border-right:1px solid #000;">Container No.</th>
                    <th style="border-bottom:1px solid #000;border-right:1px solid #000;">Seal No.</th>
                    <th style="border-bottom:1px solid #000;border-right:1px solid #000;">No. of Containers of pkgs</th>
                    <th style="border-bottom:1px solid #000;border-right:1px solid #000;">Kind of Packages Description of Goods, Marks & Nos<br />PARTICULARS OF GOODS AS DECLARED BY SHIPPER</th>
                    <th style="border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;padding-right:29px !important;">Gross weight</th>
                    <th style="border-bottom:1px solid #000;">Measurement</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </tbody>
        </table>
    </div>
     <div style="float:left;width:1024px;">
         <div style="float:left;width:90%;">
             <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 11px; margin:0px;float:left;width:47%;"class="blhide">TOTAL NUMBER OF CONTAINERS OR PACKAGES OR UNITS</p>
             <p style="font-size:14px; font-weight:bold;  padding:5px; margin:0px;float:left;width:50%;"><asp:Label ID="lbl_totpkg" runat="server"></asp:Label></p>

         </div>
         <div style="float:left;width:10%;">
             <p style="font-size:16px; font-weight:bold;  padding:5px; margin:0px;float:left;width:90%;text-align:right;"class="blhide"></p>
         </div>
     </div>
    <div style="float:left;width:1024px;border-top:1px solid #000;"class="borderhide">
        <div style="float:left;width:200px;border-right:1px solid #000;"class="borderhide">
            <p style="font-size:14px; font-weight:bold;  padding:5px; margin:0px;text-align:center;width:95%;float:left;"class="blhide">OTHER CHARGES</p>
            <div style="float:left;width:100%">
            <p style="font-size:14px; font-weight:normal;  padding:0px 0px 5px 10px; margin:0px;width:8%;float:left;" class="blhide">1.</p>  <p style="float:left;width:82%; padding:0px 0px 5px 10px; margin:0px;"><asp:Label ID="lbl1" runat="server"></asp:Label></p>
            </div>
            <div style="float:left;width:100%">
            <p style="font-size:14px; font-weight:normal; padding:0px 0px 5px 10px; margin:0px;width:8%;float:left;"class="blhide">2.</p> <p style="float:left;width:82%; padding:0px 0px 5px 10px; margin:0px;"><asp:Label ID="Label3" runat="server"></asp:Label></p>
            </div>
                <div style="float:left;width:100%">
                <p style="font-size:14px; font-weight:normal;  padding:0px 0px 5px 10px; margin:0px;width:8%;float:left;"class="blhide">3.</p> <p style="float:left;width:82%; padding:0px 0px 5px 10px; margin:0px;"><asp:Label ID="Label4" runat="server"></asp:Label></p>
            </div>
    <div style="float:left;width:100%">
                    <p style="font-size:14px; font-weight:normal;  padding:0px 0px 5px 10px; margin:0px;width:8%;float:left;"class="blhide">4.</p> <p style="float:left;width:82%; padding:0px 0px 5px 10px; margin:0px;"><asp:Label ID="Label5" runat="server"></asp:Label></p>
            </div>
    <div style="float:left;width:100%">
        <p style="font-size:14px; font-weight:normal; padding:0px 0px 5px 10px;margin:0px;width:8%;float:left;"class="blhide">5.</p> <p style="float:left;width:82%; padding:0px 0px 5px 10px; margin:0px;"><asp:Label ID="Label6" runat="server"></asp:Label></p>
        </div>
        </div>
        <div style="float:left;width:823px;">
            <table style="width:100%;border-collapse:collapse;font-size:14px;">
                <thead>
                    <tr class="bltableheadhide">
                    <th style="border-bottom:1px solid #000;border-right:1px solid #000;padding:0!important;width:450px;"class="borderhide">For delivery : Please Apply to</th>
                    <th style="border-bottom:1px solid #000;border-right:1px solid #000;width:142px;"class="borderhide">Prepaid</th>
                    <th style="border-bottom:1px solid #000;"class="borderhide">Collect</th>
                     </tr>
                </thead>
                <tbody>
                    <tr style="height:66px;">
                        <td style="padding:0px 0px 0px 10px;border-right:1px solid #000;"class="borderhide">
                            </td>
                        <td style="padding:0px 0px 0px 10px;border-right:1px solid #000;"class="borderhide">
                            <asp:Label ID="lbl_preorcol" runat="server"></asp:Label></td>
                        <td style="padding:0px 0px 0px 10px;"><asp:Label ID="lbl_colorper" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border-right:1px solid #000;border-top:1px solid #000;border-left:1px solid #000;float:right;padding:0px 10px 0px 10px;margin-top:-1px;margin-right:-1px;"class="borderhide"><p style="font-weight:bold;font-size:14px;width:60px;"class="blhide">TOTAL</p></td>
                        <td style="border-right:1px solid #000;border-top:1px solid #000;padding:0px 10px 0px 10px;"class="borderhide"><p style="font-weight:normal;font-size:14px;text-align:right;"><asp:label ID="lbl_prepaid" runat="server"></asp:label></p></td>
                        <td style="border-top:1px solid #000;padding:0px 10px 0px 10px;"class="borderhide"><p style="font-weight:normal;font-size:14px;text-align:right;"><asp:label ID="Label7" runat="server"></asp:label></p></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div style="float:left; width:1024px; min-height:45px;border-bottom:1px solid #000;"class="borderhide">
  <div style="float:left;height: 51px; width:110px; border-right:1px solid #000; border-top:1px solid #000;"class="borderhide">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Ex.Rate</p>
      <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"> <asp:Label ID="Label8" runat="server"></asp:Label> </p>
    </div>
   
  <div style="float:left; height: 51px;width:200px; border-right:1px solid #000;border-top:1px solid #000;"class="borderhide">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Prepaid</p>
      <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="Label9" runat="server"></asp:Label></p>
    </div>
    

   <div style="float:left; width:259px; border-right:1px solid #000;border-top:1px solid #000; height: 51px;"class="borderhide">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Payable at</p>
      <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_payat" runat="server"></asp:Label></p>
    </div>

  <div style="float:left;height: 51px; width:260px; border-top:1px solid #000;"class="borderhide">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;"class="blhide">Place B/L Issued</p>
      <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_portname" runat="server"></asp:Label></p>
    </div>
    <div style="float:left;height: 51px; width:192px; border-top:1px solid #000;"class="borderhide">
  <p style="float:left;font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;width:39px;"class="blhide">Date :</p>
  <p style="float:left;font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px;width:123px;"><asp:Label ID="lbl_etd" runat="server"></asp:Label></p>
</div>

 
</div>
    <div style="float:left;width:1024px;">
        <div style="float:left;width:571px;border-right:1px solid #000;min-height:173px;"class="borderhide">
              <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;text-align:center;display:none;"class="blhide">SHIPPED ON BOARD</p>
<p style="font-size:19px; font-weight:normal;height:27px;  padding:5px 5px 5px 11px; margin:0px;text-align:center;"><asp:Label ID="lbl_sonboard" runat="server"></asp:Label></p>
        </div>
        <div style="float:left;width:427px;"class="blhide">
            <div style="font-size:14px; font-weight:normal;  padding:4px 15px 5px 10px; text-align:right;margin:0px; float:left; width:434px;  ">
For <B><asp:Label ID="lbl_div" runat="server"></asp:Label></B></div>
        <div style="font-size: 14px;
    font-weight: bold;
    padding: 0px 0px 0px 0px;
    margin: 0px 0px 0px 85px;
    float: left;
    height: 90px !important;width:338px;">

            <%--<img id="img_signature"  src="../Theme/assets/img/buttonIcon/signature.png" alt="Alternate Text" />--%>
             <asp:Image id="img_signature" runat="server"/>
</div>
            <div style="float:left;width:450px;">
<p style=" float:left;font-weight:normal;margin:10px 0px 0px 10px;width:451px;">by_____________________Signed on behalf of the Carrier / Agent</p>
            </div>
         <div style="float:left;width:427px;text-align:right;">
         <p style=" float:left;font-weight:normal;margin:10px 0px 0px 0px;width:444px;">Authorised Signatory</p>
         </div>

        </div>

    </div>
    
  <div style="clear:both;"></div>
</div>
    <asp:Literal ID="litScript" runat="server"></asp:Literal>
    <asp:Literal ID="litScript2" runat="server"></asp:Literal>
    <asp:Literal ID="litScript3" runat="server"></asp:Literal>
</body>
</html>

