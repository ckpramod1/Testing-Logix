<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buying.aspx.cs" Inherits="logix.Reportasp.Buying" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <link href="../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .LogisticsTitle {
    width: 777px;
    float: left;
    margin: 0px 0px;
    text-align: center;
}


.ReportBG1 label {
    width: 150px;
    float: left;
    margin: 5px 5px 5px 5px;
    color: black;
    font-size: 14px;
}

.ReportBG1 span {
    width: 315px;
    font-size: 14px;
    float: left;
    margin: 5px 5px 5px 5px;
    color: #000000;
}

        .ReportLeft {
            width:49.5%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }

        .ReportRight {
            width:50%;
            float:left;
            margin:0px 0px 0px 0px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Wrapper">
<div class="RContainer">
    
<div class="Header" style="background-color:#878788;">
<div class="LogoReport">
    <asp:Image ID="img_Logo" runat="server" Width="63" Height="72"/>
  <%--<img src="#" id="lbl_img" runat="server" width="71" height="45" />--%> </div>

    <div class="LogisticsTitle">
                        <h3 style="color:#ffffff; padding:10px 0px 10px 0px;">
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
     <div style="float:left; width:137px; color:#ffffff; margin:0px 0px 0px 10px; font-size:12px;"><span><label>Print Date: </label><asp:Label ID="lbldate" runat="server"></asp:Label></span></div>
</div>
    <div class="ReportBG1" style="background-color:#d0d0d0;">
        <div class="ReportLeft">
    <label>Carrier</label><asp:Label ID="lbl_carrier" runat="server"></asp:Label>
        <div style="clear:both;"></div>

    <label>Valid Till</label><asp:Label ID="lbl_vt" runat="server" Height="24px"></asp:Label>
        <div style="clear:both;"></div>

    <label>Commodity</label><asp:Label ID="lbl_commodity" runat="server"></asp:Label>
         <div style="clear:both;"></div>
          
         
            </div>
        <div class="ReportRight">
            <label>PoR </label><asp:Label ID="lbl_PoR" runat="server"></asp:Label>
          <label>PoL  </label><asp:Label ID="lbl_PoL" runat="server"></asp:Label>
         <div style="clear:both;"></div>
           <label>PoD </label><asp:Label ID="lbl_PoD" runat="server"></asp:Label>
          <div style="clear:both;"></div>
        <label>Final Destination </label><asp:Label ID="lbl_FD" runat="server"></asp:Label>
        <div style="clear:both;"></div>
            </div>
        
</div>

    <table width="100%" border="0" cellspacing="0" cellpadding="5" style=" width:100%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1; margin:0px auto;">
  <tr>
    <th width="73%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Charge Name</th>
    <th width="6%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff; text-align:center;">Curr</th>
    <th width="15%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff; text-align:center;">Rate</th>
    <th width="6%" style="background-color:#184684; color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:3px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff; text-align:center;">Base</th>
    </tr>
        <asp:Label ID="tr_row" runat="server"></asp:Label>
  <%--<tr style="background-color:#f5f5f5; border-bottom:1px solid #cdbcb1;">
    <td style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">OCEAN FREIGHT CHARGES</td>
    <td style="color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">USD</td>
    <td style="color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">825.00</td>
    <td style="color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;">40HC</td>
  </tr>--%>
  </table>
   <div class="ReportBGname" style="background-color:#878788; padding:10px;">

      <label style="display:block; float:left; width:150px; padding-bottom:25px; color:#ffffff; font-size:14px;">Rate Obtainedby</label>
       <div style="clear:both;"></div>
      
       <asp:Label ID="lbl_empname" runat="server" style="color:#ffffff; font-size:14px;"></asp:Label>
       </div>
    </div>
        </div>
    </form>
</body>
</html>
