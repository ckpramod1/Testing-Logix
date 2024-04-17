<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AEJobInforpt.aspx.cs" Inherits="logix.Reportasp.AEJobInforpt" %>

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
                        <asp:Image ID="img_Logo" runat="server" Width="63" Height="72"/>
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
        <div style="float:left; width:90px; color:#ffffff; margin:0px 0px 0px 10px;"><span><asp:Label ID="lbldate" runat="server"></asp:Label></span></div>
                    <%--<div style="float:left; width:70px; margin:10px 0px 0px 0px; color:black; font-size:10px;font-family:sans-serif;" class="Printbtn">
                    <asp:Label ID="Label1" Width="100%" runat="server" Text="" />
                        </div>--%>
        
                </div>
    <div style="width:100%; margin:auto;">
  <div style="width:1024px; margin:auto;">
   <%-- <div style="background-color:#878788; float:left; width:100%;">
    
      <div style="background-color:#878788; width:824px; min-height:40px; margin:0px auto; float:left;">
        <h3 style="text-align:center; color:#ffffff; margin:0px; padding:10px 0px 10px 0px; font-family:Segoe UI; font-size:30px; font-weight:normal; display:none; "><span><asp:Label ID="lblhead" runat="server"></asp:Label></span></h3>
        <p style="text-align:center;  font-family:Segoe UI; font-size:14px; margin:0px 0px 10px 0px; padding:0px 0px 10px 0px; font-weight:normal; line-height:18px; color:#ffffff;">&nbsp;</p>
      </div>
    
    </div>
    <div style="float:left; width:1024px; background-color:#d0d0d0; border-bottom:1px dashed #000000;">
      <div style="clear:both;"></div>
      <div style="clear:both;"></div>
    </div>--%>
    <div style="float:left; width:1024px; margin:0px 0px 10x 0px; padding:0px 0px 10px 0px;">
      
      <table width="100%" border="0" cellspacing="0" cellpadding="5" style=" width:100%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1;">
    <tr>
      <th width="6%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Job#</th>
      <th width="9%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">MAWBL#</th>
      <th width="6%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Date</th>
      <th width="6%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Flight#</th>
      <th width="6%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Date</th>
      <th width="7%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">From</th>
      <th width="14%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">To</th>
      <th width="10%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Status</th>
      </tr>
    <tr style="background-color:#d0d0d0;">
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;"><span><asp:Label ID="lbl_jobno" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;"><span><asp:Label ID="lbl_mawblno" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;"><span><asp:Label ID="lbl_mawbldate" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;"><span><asp:Label ID="lbl_flightno" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;"><span><asp:Label ID="lbl_flightdate" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;"><span><asp:Label ID="lbl_fromport" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;"><span><asp:Label ID="lbl_toport" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;"><span><asp:Label ID="lbl_status" runat="server"></asp:Label></span></td>
    </tr>
    <tr style="background-color:#d0d0d0;">
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;">&nbsp;</td>
    </tr>
    <tr style="background-color:#d0d0d0;">
      <td colspan="2" valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;"><strong>AirLine:</strong><span><asp:Label ID="lbl_customername" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;">&nbsp;</td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;">&nbsp;</td>
      <td colspan="2" valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1; text-align:left;"><strong>Agent:</strong> <span><asp:Label ID="lbl_customername1" runat="server"></asp:Label></span></td>
      <td valign="top" style="border-right:1px solid #b1b1b1;  border-bottom:1px solid #b1b1b1;">&nbsp;</td>
    </tr>
      </table>
    
  </div>
  </div>
</div>

<div style="clear:both;"></div>
<div style="border-bottom:2px solid #88324c; margin:10px 0px 10px 0px; width:100%;"></div>
    
<p>&nbsp;</p>
</div>
</div>
</body>
</html>
