<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="feexportsrpt.aspx.cs" Inherits="logix.Reportasp.feexportsrpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .LogoReport {
            float:left; 
            width:100px;
            margin:10px 0px 0px 10px;
            height: 50px;
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
                    <%--<div style="float:left; width:70px; margin:10px 0px 0px 0px; color:black; font-size:10px;font-family:sans-serif;" class="Printbtn">
                    <asp:Label ID="Label1" Width="100%" runat="server" Text="" />
                        </div>--%>
        <div style="float:left; width:70px; margin:10px 0px 0px 0px; color:black; font-size:10px;font-family:sans-serif; color:#ffffff;" class="Printbtn">
                    <asp:Label ID="lbl_page" Width="100%" runat="server" Text="" />
                        </div>
                </div>

  <table width="100%" border="0" cellspacing="0" cellpadding="5" style=" width:100%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1; border-top:1px solid #cdbcc1; border-bottom:1px solid #cdbcc1; margin:10px 0px 0px 0px;">
    <tr style="background-color:#d0d0d0;">
      <td width="30%" valign="top" style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 10px;  border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1;">
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Job #</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="jobno" runat="server"></asp:Label></span></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Feeder Vsl & Voy</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="feedervslvoy" runat="server"></asp:Label></span></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Mother Vsl & Voy</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="mothervslvoy" runat="server"></asp:Label></span></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>MBL #</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="mblno" runat="server"></asp:Label></span></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Stuffed On</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"><span><asp:Label ID="stuffonvalue" runat="server"></asp:Label></span></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Liner</label></div>
        <div style="float:left; width:165px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"><span><asp:Label ID="linervalue" runat="server"></asp:Label></span></div>
        </td>
      <td width="25%" valign="top" style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 10px;  border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1;">
       <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Job Date</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;">03/03/2017</div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>POL</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="POLValue" runat="server"></asp:Label></span></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>MBL Status</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="mblstatusvalue" runat="server"></asp:Label></span></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>DraftSentOn</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="draftsendonvalue" runat="server"></asp:Label></span></div>   
       
      </td>
      <td width="25%" valign="top"  style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 10px;  border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1;">
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Job Type</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"><span><asp:Label ID="jobtypenew" runat="server"></asp:Label></span></div>
      <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>ETD</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"><span><asp:Label ID="ETDVALUE" runat="server"></asp:Label></span></div>
         <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>ReleasedOn</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"><span><asp:Label ID="releaseonvalue" runat="server"></asp:Label></span></div>
         <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"><label>Agent</label></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"><span><asp:Label ID="agentvalue" runat="server"></asp:Label></span></div>
      
      </td>
      <td width="20%" valign="top" style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 10px;  border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1;">
      
       <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"></div>
        <div style="float:left; width:3px; margin:5px 5px 5px 0px; color:#000000;"></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"></div>
      <div style="float:left; width:90px; margin:5px 5px 5px 0px; color:#000000;"><label>POD</label></div>
        <div style="float:left; width:67px; margin:5px 5px 5px 0px; min-height:21px; color:#000000;"><span><asp:Label ID="PODVALUE" runat="server"></asp:Label></span></div>
         <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"></div>
        <div style="float:left; width:3px; margin:5px 5px 5px 0px; color:#000000;"></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"></div>
         <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000;"></div>
        <div style="float:left; width:3px; margin:5px 5px 5px 0px; color:#000000;"></div>
        <div style="float:left; width:110px; margin:5px 5px 5px 0px; color:#000000; min-height:21px;"></div>
      
      
      </td>
     
    </tr>
      <tr style="background-color:#878788;"><td colspan="4" style="border-bottom:1px solid #b1b1b1;">
          <div style="float:left; width:150px; margin:5px 5px 5px 0px; color:#ffffff; font-weight:bold; "><label>Container Details</label></div>
        <div style="float:left; width:82%; margin:5px 5px 5px 0px; min-height:21px; text-align:justify; color:#ffffff;"><span><asp:Label ID="containerdetails" runat="server"></asp:Label></span></div>

          </td></tr>
    <tr style="background-color:#d0d0d0;">
      <td colspan="4" style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;"><div style="float:left; width:205px; margin:5px 5px 5px 0px; color:#000000; font-weight:bold;">House BL Details</div>
          <div style="clear:both;"></div>
        <div style="float:left; width:100%; margin:5px 5px 5px 0px;">
          <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #b1b1b1; ">
            <tr>
              <td style="border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color:#ffffff; background-color:#184684; padding:5px 5px 5px 5px;">HBL</td>
              <td style="border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color:#ffffff; background-color:#184684; padding:5px 5px 5px 5px;">Shipper</td>
              <td style="border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color:#ffffff; background-color:#184684; padding:5px 5px 5px 5px;">CBM</td>
              <td style="border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color:#ffffff; background-color:#184684; padding:5px 5px 5px 5px;">POR</td>
              <td style="border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color:#ffffff; background-color:#184684; padding:5px 5px 5px 5px;">POL</td>
              <td style="border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color:#ffffff; background-color:#184684; padding:5px 5px 5px 5px;">FD</td>
              </tr>
           <%-- <tr>
              <td style="border-right:1px solid #b1b1b1;">&nbsp;</td>
              <td style="border-right:1px solid #b1b1b1;">&nbsp;</td>
              <td style="border-right:1px solid #b1b1b1;">&nbsp;</td>
              <td style="border-right:1px solid #b1b1b1;">&nbsp;</td>
              <td style="border-right:1px solid #b1b1b1;">&nbsp;</td>
              <td style="border-right:1px solid #b1b1b1;">&nbsp;</td>
              </tr>--%>
                <asp:Label ID="tr_row" runat="server"></asp:Label>
              
            </table>
        </div></td>
      </tr>
  </table>
<div style="clear:both;"></div>
<div style="border-bottom:2px solid #88324c; margin:10px 0px 10px 0px; width:100%;"></div>
    
<p>&nbsp;</p>
</div>
</div>
</body>
</html>
