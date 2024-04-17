<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deliveryorder.aspx.cs" Inherits="logix.Reportasp.deliveryorder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .LogisticsTitle {
            width: 730px;
            float: left;
            margin: 0px 0px;
            text-align: center;
        }

        span#lbl_consignee {
            width:540px;
            display:inline-block;
        }



    </style>
</head>
<body>
    <form id="form1" runat="server">
        <body style="padding: 0px; margin: 0px; background-color: #fff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; color: #000;">
            <div style="width: 100%; margin: auto;">
                <div style="width: 1024px; margin: auto; border:1px solid #000;">
                    <%--<div style="background-color:#878788; float:left; width:100%;">
<div style="width:135px; float:left; margin:10px 0px 0px 20px;">
   <asp:Image ID="img_Logo" runat="server" Width="70" Height="50"/> </div>
<div style="float:left; width:869px; margin:5px 0px 0px 0px;">
<h3 style="font-family:Segoe UI; font-size:30px; font-weight:normal; color:#ffffff; text-align:center; padding:0px 0px 5px 0px; 
margin:0px 0px 0px -125px;">M+R LOGISTICS (INDIA) PVT.LTD.</h3>

<p style="text-align:center;  font-family:Segoe UI; font-size:14px; margin:0px 0px 10px -125px; padding:0px; font-weight:normal; line-height:18px; color:#ffffff;">56/57,III FLOOR, RAJAJI SALAI, CHENNAI 600001<br />
          Phone # : +91 44 39881515    Fax # :+91 44 30771410<br />Service Tax # AACCP2294GST001    PAN # : AACCP2294G</p>
</div>




</div>--%>
                    <%--<div style="background-color:#878788; float:left; width:100%;">
                    <div class="LogoReport">
                        <asp:Image ID="img_Logo" runat="server" Width="70" Height="50"/>
                        <%--<img src="#" id="lbl_img" runat="server" width="71" height="45" />
                    </div>

                    <div class="LogisticsTitle">
                        <h3 style="color:#ffffff; padding:0px 0px 0px 0px;">
                            <asp:Label ID="Label1" runat="server"></asp:Label></h3>
                        <p style="color:#ffffff;">
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />

                            Phone :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>; 
FAX :
                            <asp:Label ID="Label2" runat="server"></asp:Label>;
                            <br />
                            EMail:<asp:Label ID="Label3" runat="server"></asp:Label>
                        </p>
                    </div>
        <div style="float:left; width:90px; color:#ffffff; margin:0px 0px 0px 10px;"><span><asp:Label ID="lbldate" runat="server"></asp:Label></span></div>
                    <%--<div style="float:left; width:70px; margin:10px 0px 0px 0px; color:black; font-size:10px;font-family:sans-serif;" class="Printbtn">
                    <asp:Label ID="Label1" Width="100%" runat="server" Text="" />
                        </div>
        
                </div>--%>

                    <div style="width: 1024px; margin: 3px auto 3px auto;">
                        
                        <%--Width="116" Height="32"--%>
                    </div>
                    <div style="float: left; width:150px; margin: 9px 10px 5px 15px;">
                            <asp:Image ID="img_Logo" runat="server" Width="143" Height="89" />
                        </div>

                    <div style="float: left; width: 735px; margin: 7px 0px 4px 9px;">
                        <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 3px 0px; margin: 0px 0px 0px 2px;">
                            <asp:Label ID="lbl_branchnew" runat="server"></asp:Label></h3>
                          <p style="margin:2px 0px 2px 0px; padding:0px 0px 0px 0px; font-size:14px; font-family: Segoe UI; text-align:center; "></p>

                        <div style="text-align: center; color: #000;">
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                            Phone # :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>
                            Fax # :<asp:Label ID="lbl_fax1" runat="server"></asp:Label>;
                        </div>
                        <div id="div_invoicehead" runat="server" visible="false" style="padding: 0px 0px 0px 0px; text-align: center; color: #000;">
                            GST.# :
                            <asp:Label ID="lbl_st" runat="server"></asp:Label>
                            PAN # :
                            <asp:Label ID="lbl_pan" runat="server"></asp:Label>
                            CIN # :
                            <asp:Label ID="lbl_cin" runat="server"></asp:Label>
                        </div>
                        <div id="div_cnopshead" runat="server" visible="false">
                            Service Tax # :
                            <asp:Label ID="lbl_staxhead" runat="server"></asp:Label>
                            PAN # :
                            <asp:Label ID="lbl_panno" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div style="float: left; width: 1024px; margin: 0px 0px 0px 0px; border-bottom: 1px solid #000000; border-top:1px solid #000;">
                        <h3 style="font-family: Segoe UI; font-size: 21px; text-align: center; color: #000; font-weight: normal; padding: 0px; margin: 0px;">Delivery Order</h3>
                    </div>
                    <div style="float: left; width: 1024px;">
                        <div style="width: 566px; border-right: 1px solid #000; float: left;">
                            <div style="min-height: 168px; width: 566px; border-right: 0px solid #000; float: left; padding: 15px 0px 0px 0px;">

                                <p style="padding: 5px 0px 5px 20px; margin: 0px 0px 0px 0px; font-weight: bold;">To</p>
                                <p style="padding: 5px 0px 5px 20px; margin: 0px 0px 0px 0px;">
                                    THE MANAGER<br />
                                   <%-- <asp:Label ID="lbl_customername" runat="server"></asp:Label><br />--%>
                                    <asp:Label ID="lbl_address" runat="server"></asp:Label><br />
                                   <%-- Ph:<asp:Label ID="lbl_phone" runat="server"></asp:Label>
                                    Fax:<asp:Label ID="lbl_fax" runat="server"></asp:Label><br />--%>
                                    <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                </p>
                            </div>

                        </div>
                        <div style="width: 456px; float: left; border-left:0px solid #000;">
                            <div style="min-height: 168px; width: 437px; float: left; padding: 15px 0px 0px 20px;">

                                <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">D.O # & Date</div>
                                <div style="float: left; width: 4px; margin: 5px 5px 5px 0px;">:</div>
                                <div style="float: left; width: 200px; margin: 5px 0px 5px 0px;">
                                    <asp:Label ID="lbl_do" runat="server"></asp:Label></div>
                                <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">IM # & Date</div>
                                <div style="float: left; width: 4px; margin: 5px 5px 5px 0px;">:</div>
                                <div style="float: left; width: 200px; margin: 5px 0px 5px 0px; font-weight: normal;">
                                    <asp:Label ID="lbl_IM" runat="server"></asp:Label></div>
                                <div style="clear: both;"></div>
                                <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Shipment</div>
                                <div style="float: left; width: 4px; margin: 5px 5px 5px 0px;">:</div>
                                <div style="float: left; width: 200px; margin: 5px 0px 5px 0px;">
                                    <asp:Label ID="lbl_shipment" runat="server"></asp:Label></div>
                                <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">De-Stuffed On</div>
                                <div style="float: left; width: 4px; margin: 5px 5px 5px 0px;">:</div>
                                <div style="float: left; width: 200px; margin: 5px 0px 5px 0px;">
                                    <asp:Label ID="lbl_desuffed" runat="server"></asp:Label></div>




                            </div>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="padding: 5px 5px 5px 20px; margin: 0px; border-top: 1px solid #000;">
                            <p style="font-weight: bold;">Dear Sir,</p>
                            <p>We shall be glad if you will deliver the following goods to M/s. <asp:Label ID="lbl_customername" runat="server"></asp:Label> </p>
                        </div>
                    </div>

                    <div style="clear: both;"></div>
                    <table width="1024" border="0" cellspacing="0" cellpadding="5" style="width: 100%; border-collapse: collapse; border-right: 1px solid #000; border-top:1px solid #000; border-left:0px solid #000;">
                        <tr>
                            <%--<th width="34%" style="color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:5px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Charges</th>
    <th width="33%" style="color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:5px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;"> Units</th>
    <th width="33%" style="color:#ffffff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; padding:5px; margin:0px; border-right:1px solid #cdbcb1; border-bottom:1px solid #ffffff;">Total (INR)</th>--%>
                        </tr>
                        <%-- <asp:Label ID="tr_row" runat="server"></asp:Label>--%>
                        <tr style="">
                            <td style="color: #000; font-size: 14px; padding: 5px 2px 5px 2px; width:33%; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top: 1px solid #000;">
                                <div style="float: left; margin: 0px 10px 0px 15px; font-weight: bold;">M B/L # : </div>
                                <asp:Label ID="lbl_mbl" runat="server"></asp:Label>
                            </td>
                            <td style="width:33%;color: #000; font-size: 14px; padding: 5px 2px 5px 2px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;">
                                <div style="float: left; margin: 0px 10px 0px 15px; font-weight: bold;">H B/L # : </div>
                                <asp:Label ID="lbl_blno" runat="server"></asp:Label></td>
                            <td style="color: #000; text-align: left; font-size: 14px; padding: 5px 2px 5px 2px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top: 1px solid #000;"><span style="display: inline-block; font-weight: bold; color: #000; margin: 0px 10px 0px 15px; width: 80px; float: left;">POL / POD</span>
                                <div style="float: left; width: 150px;"></div>
                                <asp:Label ID="lbl_from" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="">
                            <td style="border-right: 1px solid #000; border-bottom: 1px solid #000; width: 365px;"><span style="display: inline-block; float: left; margin: 0px 5px 0px 12px; font-weight: bold;">O/C of M.V : </span><asp:Label ID="lbl_vessel" runat="server"></asp:Label></td>
                            <td style="border-right: 1px solid #000; border-bottom: 1px solid #000;"><span style="display: inline-block; float: left; width: 65px; font-weight: bold; margin: 0px 0px 0px 12px;">Per M.V : </span><asp:Label ID="lbl_vessel1" runat="server"></asp:Label></td>
                            <td style="border-right: 1px solid #000; border-bottom: 1px solid #000;"><span style="font-weight: bold; display: inline-block; width: 62px; margin: 0px 0px 0px 12px; float: left;">Line # : </span><asp:Label ID="lbl_subline" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="">
                            <td style="border-right: 1px solid #000; border-bottom: 1px solid #000;"><span style="display: inline-block; float: left; width: 110px; font-weight: bold; margin: 0px 5px 0px 12px;">Arrived on : </span>
                                <asp:Label ID="lbl_arrived" runat="server"></asp:Label></td>
                            <td style="border-right: 1px solid #000; border-bottom: 1px solid #000;"><span style="display: inline-block; float: left; width: 110px; font-weight: bold; margin: 0px 5px 0px 12px;">Gross Weight : </span><asp:Label ID="lbl_grossweight" runat="server"></asp:Label></td>
                            <td style="border-right: 1px solid #000; border-bottom: 1px solid #000;"><span style="font-weight: bold; display: inline-block; width: 120px; margin: 0px 5px 0px 12px;">No of Packages : </span>
                                <asp:Label ID="lbl_packages" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="">
                            <td valign="top" style="border-right: 1px solid #000; border-bottom: 1px solid #000;"><span style="display: block; float: left; font-weight: bold; margin: 0px 5px 0px 12px;">Marks & Numbers</span><br />

                                <span style="margin: 0px 0px 0px 12px;">

                                    <asp:Label ID="lbl_marks" runat="server"></asp:Label></span><br />
                            </td>
                            <td valign="top" colspan="2" style="border-right: 1px solid #000; border-bottom: 1px solid #000;"><span style="display: block; float: left; font-weight: bold; margin: 0px 0px 0px 12px;">Description</span><br />
                                <span style="margin: 0px 0px 0px 12px;">
                                    <asp:Label ID="lbl_desc" runat="server"></asp:Label></span><br />
                            </td>

                        </tr>
                    </table>
                    <div style="float: left; width: 1024px; ">
                        <div style="float: left; width: 37%; margin: 0px 10px 0px 0px;">
                            <table border="0" cellspacing="0" cellpadding="0" style="border-top: 1px solid #000; margin: 5px 10px 0px 0px; width: 100%;">
                                <tr style="">
                                    <td style="border-right: 1px solid #000; border-bottom: 1px solid #000; color: #000; padding: 5px;"><strong>Container(s)</strong></td>
                                    <td style="border-right: 1px solid #000; border-bottom: 1px solid #000; color: #000; padding: 5px;"><strong>Seal #</strong></td>
                                    <td style="border-right: 1px solid #000; border-bottom: 1px solid #000; color: #000; padding: 5px;"><strong><asp:Label ID="lbl20" runat="server"></asp:Label> X 20'</strong></td>
                                    <td style="border-right: 1px solid #000; border-bottom: 1px solid #000; color: #000; padding: 5px;"><strong><asp:Label ID="lbl40" runat="server"></asp:Label> X 40'</strong></td>
                                </tr>

                                <asp:Label ID="tr_row1" runat="server"></asp:Label>
                                <%--<tr>
        <td style="border-right:1px solid #b1b1b1;"><asp:Label ID="lbl_container"  runat="server"></asp:Label></td>
        <td style="border-right:1px solid #b1b1b1; "><asp:Label ID="lbl_seal" runat="server"></asp:Label></td>
        <td style="border-right:1px solid #b1b1b1; "><asp:Label ID="lbl_20" runat="server"></asp:Label></td>
        <td style="border-right:1px solid #b1b1b1;"><asp:Label ID="lbl_40" runat="server"></asp:Label></td>
      </tr>--%>
                            </table>
                        </div>
                        <div style="float: left; width: 61%; margin: 10px 0px 0px 0px;">
                            <div style="float:left; width:85px; font-weight:bold;">Consignee :</div>
                            <div style="float:left; width:350px;"><asp:Label ID="lbl_consignee" runat="server"></asp:Label></div>
                           </div>
                    </div>

                    <div style="width: 100%; float: left; border-bottom: 1px solid #000;"></div>
                    <div style="width: 100%; float: left;">
                        <tr style="">
                            <td valign="top">&nbsp;</td>
                            <td colspan="2" valign="top">&nbsp;</td>
                        </tr>
                        <tr style="">
                            <td colspan="3" valign="top" style="color: #000;">
                                <span style="font-weight:bold">
                                <p style="float: left; margin: 10px 0px 0px 10px;">For 
                                    <asp:Label ID="lbl_branch" runat="server"></asp:Label></p></span>
                          <%--     <span style="font-weight:bold"> <p style="margin: 200px 0px 0px 10px; padding: 5px 5px 5px 5px;">Authorised Signatory</p>--%>
                                     <span style="font-weight:bold"> <p style="margin: 200px 0px 0px 10px; padding: 5px 5px 5px 5px;">This is E-Delivery Order, no signature is required</p>
                                   <br />
                                   

                               </span>

                            </td>
                        </tr>
                    </div>
                    <div style="clear:both;"></div>
                </div>
            </div>
        </body>
    </form>
</body>
</html>
