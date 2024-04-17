<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shippingbillrpt.aspx.cs" Inherits="logix.Reportasp.Shippingbillrpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .LogoReport {
            float:left; 
            width:100px;
            margin:10px 0px 0px 10px;
        }


        .LogisticsTitle {
            float:left; 
            width:800px;
            margin:0px 0px 0px 10px;
            text-align:center;
        }

    </style>
</head>
<body style="padding:0px; margin:0px; background-color:#fff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; color:#2c2b2b;">

<div style="width:100%; margin:auto;">
<div style="width:1024px; margin:auto;">
    <div class="Header" style="background-color:#878788; float:left; width:1024px;">
                    <div class="LogoReport">
                        <asp:Image ID="img_Logo" runat="server" Width="70" Height="50"/>
                        <%--<img src="#" id="lbl_img" runat="server" width="71" height="45" />--%>
                    </div>

                    <div class="LogisticsTitle">
                        <h3 style="color:#ffffff; padding:0px 0px 0px 0px;">
                            <asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
                        <p style="color:#ffffff;">
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />

                            Phone :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>; 
FAX :
                            <asp:Label ID="lbl_fax" runat="server"></asp:Label>;
                            <br />
                            EMail:<asp:Label ID="lbl_email" runat="server"></asp:Label>
                        </p>
                    </div>
        <div style="float:left; width:70px; margin:10px 0px 0px 0px; color:#ffffff; font-size:12px;font-family:sans-serif;" class="Printbtn">
                    <asp:Label ID="lbl_page" Width="100%" runat="server" Text="" />
                       
                        </div>
         <div style="float:left; width:90px; color:#ffffff; margin:0px 0px 0px -6px;"><span><asp:Label ID="lbldate" runat="server"></asp:Label></span></div>
                    <%--<div style="float:left; width:70px; margin:10px 0px 0px 0px; color:black; font-size:10px;font-family:sans-serif;" class="Printbtn">
                    <asp:Label ID="Label1" Width="100%" runat="server" Text="" />
                        </div>--%>
        
                </div>
<div style="width:100%; margin:auto;">
<div style="width:1024px; margin:auto;">


<div style="clear:both;"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="5" style="  width:100%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1; border-top:1px solid #cdbcc1; border-bottom:1px solid #cdbcc1; margin:0px 0px 0px 0px;">
  <tr style="background-color:#184684;">
   
    <td style="color:#2c2b2b; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; color:#ffffff;"><strong>MATE RECEIPT</strong></td>
  </tr>
  <tr style="background-color:#d0d0d0;">
    <td style=" border-right:1px solid #cdbcb1;">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr style="background-color:#d0d0d0;">
    <td width="50%" style="border-bottom:1px solid #b1b1b1;"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding:5px 5px 5px 5px;">
        <tr>
          <td width="49.5%"  style="padding:5px 5px 5px 5px;">Mate Receipt #</td>
          
          <td width="49.5%"  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="mate" runat="server"></asp:Label></span></td>
          </tr>
        <tr>
          <td width="49.5%"  style="padding:5px 5px 5px 5px;">Shipping Bill #</td>
          
          <td width="49.5%"  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="sbno" runat="server"></asp:Label></span></td>
          </tr>
        <tr>
          <td  style="padding:5px 5px 5px 5px;">G.R. #</td>
         
          <td  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="grno" runat="server"></asp:Label></span></td>
        </tr>
        <tr>
          <td  style="padding:5px 5px 5px 5px;">Rotation #</td>
          
          <td  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="emno" runat="server"></asp:Label></span></td>
        </tr>
        <tr>
          <td  style="padding:5px 5px 5px 5px;">Shipping Bill Type</td>
         
          <td  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="billname" runat="server"></asp:Label></span></td>
        </tr>
       
    </table></td>
    <td width="50%" valign="top" style="border-bottom:1px solid #b1b1b1;"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding:5px 5px 5px 5px;">
        <tr>
          <td width="49.5%"  style="padding:5px 5px 5px 5px;">M.R. Date</td>
          
          <td width="49.5%"  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="mrdate" runat="server"></asp:Label></span></td>
          </tr>
        <tr>
          <td width="49.5%"  style="padding:5px 5px 5px 5px;">S.B. Date</td>
          
          <td width="49.5%"  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="sbdate" runat="server"></asp:Label></span></td>
          </tr>
        <tr>
          <td  style="padding:5px 5px 5px 5px;">G.R. Date</td>
          
          <td  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="grdate" runat="server"></asp:Label></span></td>
        </tr>
        <tr>
          <td  style="padding:5px 5px 5px 5px;">Rt. Date</td>
          
          <td  style="padding:5px 5px 5px 5px;"><span><asp:Label ID="emdate" runat="server"></asp:Label></span></td>
        </tr>
    </table></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  
  <tr style="background-color:#d0d0d0;">
    <td style="padding:10px 0px 10px 10px;">Received and stuffed into container for shipment by the vessel</td>
  </tr>
  <tr style="background-color:#d0d0d0;">
    <td style="padding:10px 0px 10px 10px;"><span><asp:Label ID="txt1" runat="server"></asp:Label></span></td>
  </tr>
  <tr style="background-color:#d0d0d0;">
    <td style="padding:10px 0px 10px 10px;"><span><asp:Label ID="txt2" runat="server"></asp:Label></span></td>
  </tr>
  <tr style="background-color:#d0d0d0;">
    <td style="padding:10px 0px 10px 10px;">Subject to All Conditions of the Company ' s Bill of Lading</td>
  </tr>
  
  <tr style="background-color:#d0d0d0;">
    <td style="padding:10px 0px 10px 10px;">Particulars Declared by the Shipper</td>
  </tr>
</table>

      
      
    </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="5" style="  width:100%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1; border-top:1px solid #cdbcc1; border-bottom:1px solid #cdbcc1; margin:0px 0px 0px 0px;">
  <tr style="background-color:#184684;">
    <td width="15%" style="color:#2c2b2b; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; color:#ffffff;">MARKS &amp; NO.</td>
    <td width="22%" style="color:#2c2b2b; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; color:#ffffff;">No. of Pkgs</td>
    <td width="31%" style="color:#2c2b2b; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; color:#ffffff;">Cargo Description</td>
    <td width="32%" style="color:#2c2b2b; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; color:#ffffff;">Gross Weight</td>
  </tr>
  <tr style="background-color:#d0d0d0;">
    <td style=" border-right:1px solid #cdbcb1;"><span><asp:Label ID="marks" runat="server"></asp:Label></span></td>
    <td style=" border-right:1px solid #cdbcb1;"><span><asp:Label ID="noofpkg" runat="server"></asp:Label></span><span><asp:Label ID="descn" runat="server"></asp:Label></span></td>
    <td style=" border-right:1px solid #cdbcb1;"><span><asp:Label ID="descndetails" runat="server"></asp:Label></span></td>
    <td style=" border-right:1px solid #cdbcb1;"><span><asp:Label ID="wts" runat="server"></asp:Label></span></td>
  </tr>
  <tr style="background-color:#d0d0d0;">
    <td style=" border-right:1px solid #cdbcb1;">&nbsp;</td>
    <td style=" border-right:1px solid #cdbcb1;">&nbsp;</td>
    <td style=" border-right:1px solid #cdbcb1;">&nbsp;</td>
    <td style=" border-right:1px solid #cdbcb1;">&nbsp;</td>
  </tr>
</table>
<table width="50%" border="0" cellspacing="0" cellpadding="5" style="  width:50%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1; border-top:1px solid #cdbcc1; border-bottom:1px solid #cdbcc1; margin:0px 0px 0px 0px;">
  <tr style="background-color:#184684;">
    <td width="15%" style="color:#ffffff; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">Container #</td>
    <td width="22%" style="color:#ffffff; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">Sizetype</td>
    <td width="31%" style="color:#ffffff; font-size:14px; text-align:center; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">Seal #</td>
    </tr>
 <%-- <tr style="background-color:#d0d0d0;">
    <td style=" border-right:1px solid #cdbcb1;"><span><asp:Label ID="containerno" runat="server"></asp:Label></span></td>
    <td style=" border-right:1px solid #cdbcb1;"><span><asp:Label ID="sizetype" runat="server"></asp:Label></span></td>
    <td style=" border-right:1px solid #cdbcb1;"><span><asp:Label ID="sealno" runat="server"></asp:Label></span></td>
    </tr>
  <tr style="background-color:#d0d0d0;">
    <td style=" border-right:1px solid #cdbcb1;">&nbsp;</td>
    <td style=" border-right:1px solid #cdbcb1;">&nbsp;</td>
    <td style=" border-right:1px solid #cdbcb1;">&nbsp;</td>
    </tr>--%>
      <asp:Label ID="tr_row" runat="server"></asp:Label>
</table>
<p style="padding:25px 0px 0px 0px;">For <span><asp:Label ID="lblcmpy" runat="server"></asp:Label></span><br />
  <br />
  <br />
  <br />
   <br />
   <br />
  AS AGENTS</p>
<div style="clear:both;"></div>
</div>
</div>

<div style="clear:both;"></div>
<div style="border-bottom:2px solid #88324c; margin:10px 0px 10px 0px; width:100%;"></div>
    
<p>&nbsp;</p>
</div>
</div>
</body>
</html>
