<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BL4FCLrptorginal.aspx.cs" Inherits="logix.newrptorg.BL4FCLrptorginal" %>

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
   

	
<body style="font-family:sans-serif, Geneva, sans-serif; font-size:14px; color:#000;">

<div style="width:1024px; margin:0px auto 0px auto;  ">


<p style="font-size:18px; font-weight:bold; margin:0px; padding:5px 0px 5px 5px;">Bill Of Lading</p></div>


<div style="width:1024px; margin:0px auto 0px auto;  border:1px solid #000;">
  <div style="float:left; width:512px; border-right:1px solid #000;">
    
    <div style="float:left; width:512px; border-bottom:1px solid #000; min-height:132px;">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 0px 10px; margin:0px;">Consignor/Shipper</p>
      <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px;white-space: pre-line; margin:0px; line-height:18px;">
           <asp:Label ID="lbl_conshipaddress" runat="server"></asp:Label><br />
          </p>
    </div>
    
    <div style="float:left; width:512px; border-bottom:1px solid #000; min-height:132px;">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 0px 10px; margin:0px;">Consignee (IF 'To Order' so indicate)</p>
      <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px;white-space: pre-line; margin:0px; line-height:18px;">   
           <asp:Label ID="lbl_conaddress" runat="server"></asp:Label><br />
          </p>
    </div>
    <div style="float:left; width:512px; border-bottom:1px solid #000; min-height:142px;">
      <p style="font-size:14px; font-weight:bold;  padding:5px 5px 0px 10px; margin:0px;">Notify Party (No claim shall attach for failure to notify) </p>
      <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px;white-space: pre-line; margin:0px; line-height:18px;">   
           <asp:Label ID="lbl_notifyaddress" runat="server"></asp:Label><br />
          </p>
    </div>
    
    
  </div>
  <div style="float:left; width:511px;">
   
    <div style="float:left; width:511px;  border-bottom:1px solid #000;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 0px 5px; margin:0px;">Bill of Lading No.</p>
        <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 5px; margin:0px;">   
              <asp:Label ID="lbl_blno" runat="server"></asp:Label>
            <br />
           
          </p>
      </div>
  <div style="float:left; width:511px; min-height:270px; border-bottom:1px solid #000;">
<div style="float:left;  margin:10px 5px 5px 175px;">
     <img src="../images/AxeRpt.jpg" width="160" />

</div>
<div style="clear:both;"></div>
     <p style="font-size:19px; font-weight:bold;text-align: center;  padding:5px 5px 0px 5px; margin:0px;">FORWARDING PRIVATE LIMITED</p>
 <p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"><b> Regd Office</b>: No. 72/57A ,Periyar Nagar,Thiruvottiyur,Chennai-600019,india,  </p>
  <p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"> <b>Corp. Off</b>:New 20,Old No.247 Angappa Naicken Street, </p>
 <p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"> 2nd Floor,Chennai-600001. India. </p>
 <p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"> Tel/Fax: +91 44 4851 4035,</p>
  <p style="font-size:14px; font-weight:normal; text-align: center; padding:5px 5px 0px 5px; margin:0px;"></p>
   <p style="font-size:19px; font-weight:bold;text-align: center;  padding:5px 5px 5px 5px; margin:0px;">Registration No. MTO/DGS/2015/APR/2022</p>
  </div>
  </div>
  <div style="float:left; width:511px; border-bottom:1px solid #000; min-height:67px;">
    <div style="float:left; width:511px;">
          <p style="text-align:left; font-size:10px; margin:2px 2px 2px 2px; font-family:arial; font-weight:normal;">Taken incharge in apparently good condition herein at the place of receipt for transport & delivery as mentioned above, unless otherwise stated. The MTO in accordance with the provisions contained in the MTD undertakes to perform or to procure the performance of the multimodal transport from the place at which the goods are taken in charge, to the place designated for delivery and assumes responsibility for such transport.<br />
          One of the MTD (s) must be surrendered, duly endorsed in exchange for the goods. In witness where of the original MTD all of this tenure and date have been signed in the number indicated below one of which being accomplished the other(s) to be void.
           </p>
      <p style="font-size:14px; font-weight:bold;  padding:5px; margin:0px; display:none; ">AGENT DETAILS</p>
      <p style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; line-height:18px; display:none;">   
          <br />
          </p>
    </div>
  
  </div>
 
  <div style="float:left; width:1024px; min-height:45px;">
    <div style="float:left;height: 50px; width:256px; border-right:1px solid #000; border-bottom:1px solid #000;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Pre Carriage by</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"> <asp:Label ID="lbl_precarriage" runat="server"></asp:Label> </p>
      </div>
     
    <div style="float:left;height: 50px; width:255px; border-right:1px solid #000; border-bottom:1px solid #000; min-height:45px;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Place of Receipt</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_POR" runat="server"></asp:Label></p>
      </div>
    <div style="float:left; height: 50px;width:297px; border-right:1px solid #000; border-bottom:1px solid #000;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Vessel</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_vessel" runat="server"></asp:Label></p>
      </div>
    <div style="float:left;height: 50px; width:213px; border-bottom:1px solid #000;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Voyage No.</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_voy" runat="server"></asp:Label></p>
      </div>
      <div style="clear:both;"></div>
    <div style="float:left; width:256px; border-right:1px solid #000; height: 50px;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Port of Loading</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_POL" runat="server"></asp:Label></p>
      </div>
    <div style="float:left; width:255px; border-right:1px solid #000; height: 50px;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px; ">Port of Discharge</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_POD" runat="server"></asp:Label>  </p>
      </div>
    <div style="float:left; width:297px; border-right:1px solid #000;height: 50px;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Place of Delivery</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_PODel" runat="server" ></asp:Label> </p>
      </div>
    <div style="float:left; width:213px; border-right:0px solid #000; height: 50px;">
        <p style="font-size:14px; font-weight:bold;  padding:5px 5px 5px 10px; margin:0px;">Freight Payable at</p>
        <p style="font-size:14px; font-weight:normal;  padding:0px 5px 5px 10px; margin:0px;"><asp:Label ID="lbl_freightpayat" runat="server"></asp:Label></p>
      </div>
   
  </div>
 
 <div style="clear:both;"></div>
      
  <div style="width:1024px;">
    <table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding:0px; font-size:14px; border-top:0px solid #000; border-bottom:0px solid #000;">
      <tr>
        <th  style="font-weight:normal; padding:5px 0px 5px 0px; font-size:14px; text-align:center; width:256px; border-right:0px solid #000; border-top:1px solid #000; border-bottom:0px solid #000;"> Marks & Nos.<br /> Container & Seals</th>
       
        <th  style="font-weight:normal; padding:5px 0px 5px 0px; font-size:14px; border-right:0px solid #000; width:498px; border-top:1px solid #000; border-bottom:0px solid #000;"> Number and Kind of Packages,Description of Goods in which quality unknown</th>
        <th  style="font-weight:normal; padding:5px 0px 5px 0px; font-size:14px; text-align:center; border-right:0px solid #000; border-top:1px solid #000; border-bottom:0px solid #000;">Gross Weight</th>
        <th  nowrap="nowrap" style="font-weight:normal; padding:5px 0px 5px 0px; text-align:left; width:130px;font-size:14px; border-top:1px solid #000; border-bottom:0px solid #000;">Measurement</th>
       
      </tr>
      <tr>
        <td style="font-weight:bold; padding:5px; text-align:left; border-right:0px solid #000;"></td>
      
        <td  colspan="1" nowrap="nowrap" style=" padding:5px; text-align:center; padding-right:145px; border-right:0px solid #000;"  >
       
        <span style="font-weight:bold;  width:140px; float:right; padding:0px 0px 0px 0px; display:inline-block; text-align:right;">SAID TO CONTAIN</span>

          
          
             <span style="font-weight:normal; display:inline-block; float:left; padding:0px 5px 0px 5px; width:60px; text-align:left;"> </span>
        </td>
        <td nowrap="nowrap"  style="font-weight:bold; padding:5px 2px 5px 5px; text-align:right; border-right:0px solid #000;">SAID TO WEIGHT </td>
         <td nowrap="nowrap"  style="font-weight:bold; padding:5px 0px 5px 2px; text-align:left; border-right:0px solid #000;">/ MEASURE</td>
      </tr>
      <tr>
        <td  style="vertical-align:top; width:200px; border-right:0px solid #000; " >
            
            <p style="font-weight:normal; padding:5px 5px 5px 10px; text-align:left; white-space:normal; margin:0px; line-height:18px;">
 <asp:Label ID="lbl_marks" runat="server"></asp:Label>
</p>
            
           <p style="font-weight:normal; padding:135px 5px 5px 10px; white-space:pre-line; text-align:left;  margin:0px; line-height:18px; width:222px; word-break:break-word;"><asp:Label ID="lbl_container" runat="server"></asp:Label></p>  
            
           </td>
       
        
      
        
        
     
        <td  style="vertical-align:top; border-right:0px solid #000;"><p style="font-weight:normal; margin:0px; padding:5px 5px 5px 5px; text-align:left; white-space:pre-line; vertical-align:top; line-height:15px; height:385px;"><asp:Label ID="lbl_pkg" runat="server" Text=""></asp:Label><br /> <asp:Label ID="lblDescription" runat="server"></asp:Label></p>

         
        </td>
        <td  valign="top" style="font-weight:normal; padding:5px; text-align:left; border-right:0px solid #000;">
      
      <p style="font-weight:bold; padding:15px 5px 5px; text-align:left; white-space:pre; "><asp:Label ID="lbl_shiptype" runat="server"></asp:Label> <br />
</p>
<p style="font-weight:normal; padding:5px; text-align:left;  line-height:18px;"> 
         <span style="font-weight:bold;"></span>
           <asp:Label ID="lbl_grwt" runat="server"></asp:Label></p>
          <p style="font-weight:normal; padding:5px; text-align:left; line-height:18px;"> 
         <span style="font-weight:bold;"></span>
           <asp:Label ID="lbl_netwt" runat="server"></asp:Label> </p>
         
        


</td>
        <td style="font-weight:normal; padding:15px 5px 5px; text-align:left;"><p style="font-weight:normal; padding:5px 0px 5px 0px; text-align:left; font-weight:bold; margin:-35px 0px 0px 0px; line-height:18px; ">
                 <asp:label text="CBM" id="lblcbm" runat="server"></asp:label>
                 </p>

            <p style="padding:5px; margin:0px;"> <asp:label  id="lbl_cbm" runat="server"></asp:label></p>


        </td>
        
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
 
    
     
    
    
    
    </table>
  </div>
    <div style="width:1024px; margin:0px auto; border-bottom:1px solid #000; border-top:1px solid #000; border-left:0px solid #000;
     border-right:0px solid #000; ">
  <p style="margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; text-align:center; font-weight:bold; vertical-align:middle; font-size:14px;">(1) SHIPPER'S LOAD STOW,COUNT & SEAL (2) ALL DESTINATION CHARGES ON CONSIGNEE'S ACCOUNT</p>
  
  </div>
    <div style="width:1024px; margin:0px auto; border-bottom:0px solid #000; border-top:0px solid #000; border-left:0px solid #000; border-right:1px solid #000; ">
  <p style="margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; text-align:center; font-weight:bold; vertical-align:middle; font-size:14px;">ABOVE PARTICULARS DECLARED BY SHIPPER,CARRIER NOT RESPONSIBLE</p>
  
  </div>
  <div style="width:1024px; float:left; border-top:1px solid #000;">

    <div style="float:left; width:512px;">
      <div style="font-size:14px; font-weight:normal;  padding:1px 5px 1px 10px; margin:0px; float:left; min-height:40px;  width:497px; border-bottom:1px solid #000;display:none;"> For Delivery Please Apply To
<br/>
          <p style="font-size:14px; font-weight:normal;  padding:2px 5px 2px 10px; margin:0px;  "><asp:Label ID="lbl_totcont" runat="server"></asp:Label></p>


      </div>
        
        <div style="clear:both;"></div>
      <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; border-bottom:1px solid #000; margin:0px; float:left; min-height:40px; width:512px; display:none;">Cargo Shall not delivered unless freight and charges not paid</div>
      
      
      <div style="width:512px; border-bottom:1px solid #000; min-height:50px;display:none;">
       <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; ">Freight Details, Charges etc</div>
      <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px;  "> <asp:Label ID="lbl_freight" runat="server"></asp:Label></div>
        </div>



      
        <div style="float:left; width:512px; border-bottom:0px solid #000; min-height:248px;">
        <div style="font-size:10px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; float:left;  width:499px; text-align:center; ">
        For Delivery Please Apply To

</div>
        <div style="font-size:14px; font-weight:normal;  padding:5px 5px 5px 10px; margin:0px; float:left; min-height:60px; width:490px;"> <asp:Label ID="lbl_delicontact" runat="server"></asp:Label></div>
        </div>
        

       <div style="font-size:14px; font-weight:bold;  padding:15px 5px 15px 10px; margin:0px; float:left;  width:150px; display:none; ">Freight Payable at :</div>
      <div style="font-size:14px; font-weight:normal;  padding:15px 5px 15px 10px; margin:0px; float:left;  width:331px; display:none;"> <asp:Label ID="lbl_payat" runat="server"></asp:Label></div>
      <div style="font-size:14px; font-weight:bold;  padding:15px 5px 15px 10px; margin:50px 0px 0px 0px; float:left;  width:150px; display:none; ">Mode of Shipment</div>
      <div style="font-size:14px; font-weight:bold;  padding:15px 5px 15px 10px; margin:50px 0px 0px 0px; float:left;  width:331px; display:none;">Shipped on board :</div>
    </div>
    <div style="float:left; width:510px; border-left:1px solid #000; min-height:250px;">
        <div style="width:510px; float:left; border-bottom:1px solid #000; min-height:42px;">
            
            <p style="padding:5px 5px 5px 10px; margin:0px;font-weight:bold; font-size:12px; width:495px; line-height:18px; text-align:justify;">
            FREIGHT PARTICULARS</p>

            <p style="font-size:14px; font-weight:normal;height:75px;  padding:5px 5px 5px 10px; margin:0px;  "><asp:Label ID="lbl_sonboard" runat="server"></asp:Label></p>

        </div>
        

     
       
        <div style="width:510px; float:left; border-bottom:1px solid #000; min-height:35px;">
            <p style="font-size:12px; font-weight:BOLD;  padding:1px 5px 1px 10px; margin:0px; float:left; ">Place and date of issue :</p> 
             <p style="font-size:12px; font-weight:BOLD;  padding:1px 5px 1px 10px; margin:0px;float:right;  "> Number of ORGINAL B/Ls</p>
            <p style="font-size:14px; font-weight:normal;  padding:5px 5px 0px 10px; margin:0px; float:left;  width:264px;"><asp:Label ID="lbl_placedtofisue" runat="server"></asp:Label></p>
             <p style="font-size:14px; font-weight:normal;  padding:5px 5px 0px 10px; margin:0px; float:left; text-align:right; width:180px;"><asp:Label ID="lbl_nooforigi" runat="server"></asp:Label></p>
            </div>
         <div style="clear:both;"></div>
     
       <div style="font-size:12px; font-weight:normal;  padding:0px 15px 5px 10px; text-align:right;margin:0px; float:left;   ">
       For <B>FORWARDING PRIVATE LIMITED</B></div>
       <div style="clear:both;"></div>
       <div style="font-size:14px; font-weight:bold;width:510px; padding:0px 0px 0px 0px; text-align:right; margin:50px 0px 0px 0px; float:left;  ">
       
       <p style=" float:left;font-weight:normal;width:12px;margin:10px 0px 0px 10px;" >by</p>
        <p style=" float:left;font-weight:normal;width:236px;margin:23px 0px 0px 6px;border-bottom:1px solid #000;"></p>
         <p style=" float:left;font-weight:normal;width:246px;margin:10px 0px 0px 0px;">Signed on behalf of the Carrier / Agent<p>
       </div>
       
    </div>
    
  </div>
 
  <div style="clear:both;"></div>
</div>
 




</body>
</html>

