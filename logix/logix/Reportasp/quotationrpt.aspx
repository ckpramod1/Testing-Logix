<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="quotationrpt.aspx.cs" Inherits="logix.Reportasp.quotationrpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/report.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
      .LogisticsTitle {
    width: 786px;
    float: left;
    margin: 0px 0px;
    text-align: center;
}
  </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="Wrapper">
            <div class="RContainer">
                <div class="Header" style="background-color: #878788;">
                    <div class="LogoReport">
                        <asp:Image ID="img_Logo" runat="server" Width="70" Height="50"/>
                        <%--<img src="#" id="lbl_img" runat="server" width="71" height="45" />--%>
                    </div>

                    <div class="LogisticsTitle">
                        <h3 style="color:#ffffff;">
                            <asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
                        <p>
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />

                            Phone :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>; 
FAX :
                            <asp:Label ID="lbl_fax" runat="server"></asp:Label>;
                            <br />
                            EMail:<asp:Label ID="lbl_email" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div style="float:left; width:140px; margin:10px 0px 0px 0px; color:#ffffff; font-size:12px;font-family:sans-serif;" class="Printbtn">
                    <div style="text-align:right; margin-right:11px;"><asp:Label ID="lbl_page" Width="100%" runat="server" Text="" /></div>
                        <span><label>Print Date: </label><asp:Label ID="lbldate" runat="server" style="color:#ffffff;"></asp:Label></span>
                        </div>
                </div>


                <div style="float:left; width:1024px; background-color:#878788;">


                <div class="ToLeft">
                    <div class="ToLabel">To</div>
                    <div class="ToAddress">
                        <p>
                            <asp:Label ID="lbl_to_add" Visible="false" runat="server"></asp:Label><%--<br />--%>

                            <asp:Label ID="lbl_street" Visible="false" runat="server"></asp:Label><%--<br />--%>

                            <asp:Label ID="lbl_location" Visible="false" runat="server"></asp:Label><%--<br />--%>

                            <asp:Label ID="lbl_ptc" Visible="false" runat="server"></asp:Label><%--<br />--%>

                            <asp:Label ID="lbl_toph" Visible="false" runat="server"></asp:Label><%--<br />--%>

                            <asp:Label ID="lbl_toemail" Visible="false" runat="server"></asp:Label>
                        </p>


                    </div>

                </div>
                <div class="ToRight">

                    <label style="float: left; display: inline-block; width: 100px;font-weight:normal; font-size:12px; color:#ffffff; ">Quotation #</label><div style="float: left; width: 4px; margin: 0px 5px 0px 0px;">:</div>
                    <div style="float: left; width: 100px; color:#ffffff; font-size:12px;">
                        <asp:Label ID="lbl_quotno" runat="server"></asp:Label></div>
                    <label style="float: left; display: inline-block; width: 100px;font-weight:normal; color:#ffffff; font-size:12px;">Date</label><div style="float: left; width: 4px; margin: 0px 5px 0px 0px;">:</div>
                    <div style="float: left; width: 100px; color:#ffffff; font-size:12px;">
                        <asp:Label ID="lbl_date" runat="server"></asp:Label></div>
                    <label style="float: left; display: inline-block; width: 100px;font-weight:normal; color:#ffffff; font-size:12px;">Valid Till</label><div style="float: left; width: 4px; margin: 0px 5px 0px 0px;">:</div>
                    <div style="float: left; width: 100px; color:#ffffff; font-size:12px;">
                        <asp:Label ID="lbl_validtill" runat="server"></asp:Label></div>


                </div>
                <div class="ClrB"></div>
                    </div>
                <div class="ThankYou">
                    <p>
                        Thank You very much for your inquiry and we are pleased to offer our rates & service as per your requirement from 
                         <asp:Label ID="lbl_fromport" runat="server" style="font-weight:bold;"></asp:Label>
                        to
                        <asp:Label ID="lbl_toport" runat="server" style="font-weight:bold;"></asp:Label>
                    </p>



                </div>
                <div class="ClrB"></div>
                <div class="ReportBG" style="background-color: #878788;">
                    <label style="float: left; width: 150px; display: inline-block;font-size:14px;font-family:Arial;font-weight:normal;color:#ffffff; margin:5px 0px 0px 19px;">Commodity</label>
                    <div style="float: left; width: 290px;font-size:14px;font-family:sans-serif;color:black;">
                        <asp:Label ID="lbl_commodity" runat="server"></asp:Label></div>
                    <div style="clear:both;"></div>
                    <label style="float: left; width: 150px; display: inline-block;font-size:14px;font-family:Arial;font-weight:normal;color:#ffffff; margin:5px 0px 0px 19px;">Cargo Description</label>
                    
                    
                    <div style="float: left; width: 290px;font-size:14px;font-family:sans-serif;color:black;">
                        <asp:Label ID="lbl_desc" runat="server"></asp:Label></div>
                     <div style="clear:both;"></div>
                    <label style="display: inline-block; float: left; width: 150px;font-size:14px;font-family:Arial;font-weight:normal;color:#ffffff; margin:5px 0px 0px 19px;">Shipment</label>
                    
                    <div style="width: 290px; float: left;font-size:14px;font-family:sans-serif;color:black;">
                        <asp:Label ID="lbl_shipment" runat="server"></asp:Label></div>
                     <div style="clear:both;"></div>
                    <label style="display: inline-block; float: left; width: 150px;font-size:14px;font-family:Arial;font-weight:normal;color:#ffffff; margin:5px 0px 0px 19px;">Frieght</label>
                    
                    <div style="float: left; width: 290px;font-size:14px;font-family:sans-serif;color:black;">
                        <asp:Label ID="lbl_frieght" runat="server"></asp:Label></div>
                     <div style="clear:both;"></div>
                    <label style="display: inline-block; float: left; width: 150px;font-size:14px;font-family:Arial;font-weight:normal;color:#ffffff; margin:5px 0px 0px 19px;">Remarks</label>
                    
                    <div style="float: left; width: 290px;font-size:14px;font-family:sans-serif;color:black;">
                        <asp:Label ID="lblRemarks" runat="server"></asp:Label>

                    </div>
                     <div style="clear:both;"></div>

                </div>


            <div class="SellRate">
                <h3>Sell Rate Details</h3>
                </div>
                <table class="TabelGrid1">
                    <tr>
                        <th>Charge Name</th>
                        <th>Curr</th>
                        <th>Rate</th>
                        <th>Units</th>
                    </tr>
                    <asp:Label ID="tr_row" runat="server"></asp:Label>
                    <%--<tr>
                        <td>Taxes As Applicable</td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>--%>
                </table>
                
            <div style="background-color:#878788; width:1024px;">
            <div class="LblTxtN1">
                Taxes As Applicable
            </div>
            <div class="LblTxtN2">
                I am sure that you will find our offer is attractive and await  your Confirmation
            </div>

                <div class="ClrB"></div> 
            <div class="BestRegards">
               <div style="margin-left:20px;margin-top:25px;font-weight:bold; font-size:12px; color:#ffffff;">Best Regards</div>
                <div class="ClrB"></div> 
                <div style="margin-left:20px;margin-top:50px; padding-bottom:15px; font-size:12px; color:#ffffff;"><asp:Label ID="lbl_emp" runat="server"></asp:Label></div>
                    

            </div>
                </div>
                <%--<div class="ClrB"></div>
                <div><asp:Button ID="btn_print" runat="server" OnClick="btn_print_Click" /></div>--%>

        </div>
        </div>
    </form>
</body>
</html>
