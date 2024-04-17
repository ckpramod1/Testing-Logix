<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDCNrpt.aspx.cs" Inherits="logix.Reportasp.AdminDCNrpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="padding: 0px; margin: 0px; background-color: #fff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; color: #2c2b2b;">
    <div style="width: 100%; margin: auto;">
        <div style="width: 1024px; margin: 3px auto 3px auto;">
             <div style="float:right;">
            <asp:Image ID="lbl_img" runat="server" Width="63" Height="72" />
                 </div>
            </div>
        <div style="width: 1024px; margin: auto;">
            <div style="background-color: #878788; float: left; width: 100%;">
              
                <div style="width: 804px; float: left; margin: 5px 0px 0px 110px; text-align: center;">
                    <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: normal; color: #ffffff; text-align: center; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 53px;">
                        <asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>

                    <div style="text-align: center; font-family: Segoe UI; font-size: 14px; margin: 0px 0px 0px 118px; padding: 0px; font-weight: normal; line-height: 18px; color: #ffffff;">
                        <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                        Phone:<asp:Label ID="lbl_ph" runat="server"></asp:Label>
                        Fax:<asp:Label ID="lbl_fax" runat="server"></asp:Label><br />
                        <div id="div_invoicehead" runat="server" visible="true" style="padding: 0px 0px 0px 0px; color: #ffffff;">
                            GST.# :
                            <asp:Label ID="lbl_st" runat="server"></asp:Label>
                            PAN # :
                            <asp:Label ID="lbl_pan" runat="server"></asp:Label>
                            CIN # :
                            <asp:Label ID="lbl_cin" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="float: left; width: 100px; color: #ffffff; margin: 5px 0px 0px 0px;">
                    <asp:Label ID="lbl_page" Width="100%" runat="server" Text="" />
                </div>
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px; text-align: center; background-color:#184684; color:#ffffff; padding: 5px 0px 5px 0px; font-weight: bold;">
                <h3 style="font-family:'Segoe UI'; float:left; font-size:24px;text-align:left; color:#ffffff; text-transform:uppercase; width:60%; font-weight:normal; padding:0px; margin:0px 0px 0px 9px;"><asp:Label ID="lbl_head" runat="server">Admin Sales Invoice</asp:Label></h3>
                <div style="float:right; width:28%; text-transform:uppercase; color:#fff; font-size:15px; font-family:sans-serif; padding:7px 10px 5px 0px; font-weight:normal;"><span id="LBL_Original">Original for the Recipient</span></div>
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px; background-color: #878788;">
                <div style="float: left; width: 512px;">
                    <div style="float: left; width: 112px; margin: 5px 0px 5px 10px; color: #ffffff;">Customer Ref #</div>
                    <div style="float:left; width:2px; margin:5px 10px 5px 0px; color:#fff;">:</div>
                    <div style="float: left; width: 300px; margin: 5px 0px 5px 0px; color: #ffffff;">
                        <label id="label_refno" runat="server"></label>
                    </div>
                    <div id="div_vendorref" runat="server" visible="false">
                            <div style="width: 112px; float: left; display: inline-block; margin: 5px 0px 5px 10px; font-weight: normal; padding: 0px 0px 0px 0px;color: #ffffff;">
                                <label id="label_vendor" runat="server">Vendor Ref #</label>
                            </div>
                         <div style="float:left; width:2px; margin:5px 10px 5px 0px; color:#fff;">:</div>
                            <div style="width: 260px; float: left; display: inline-block; margin: 5px 0px 5px 0px; color: #ffffff;">
                                <asp:Label ID="lbl_vendor" runat="server"></asp:Label>
                            </div>
             <div style="clear:both;"></div>
                            <div style="width: 112px; float: left; display: inline-block; margin: 5px 0px 5px 10px; font-weight: normal; padding: 0px 0px 0px 0px;color: #ffffff;">
                                <label id="label1" runat="server">Date</label>
                            </div>
                         <div style="float:left; width:2px; margin:5px 10px 5px 0px; color:#fff;">:</div>
                            <div style="width: 260px; float: left; display: inline-block; margin: 5px 0px 5px 0px; color: #ffffff;">
                                <asp:Label ID="lbl_vendordate" runat="server"></asp:Label>
                            </div>
                        </div>
                </div>
                 
                  
                <div style="float: left; width: 512px;">
                    <div style="float: left; width: 200px; margin: 5px 0px 5px 10px; color: #ffffff; text-align: right;" id="labeldnc" runat="server">DN # :</div>
                    <div style="float: left; width: 150px; margin: 5px 0px 5px 10px; color: #ffffff;">
                        <label id="label_DNCN" runat="server"></label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 200px; margin: 5px 0px 5px 10px; text-align: right; color: #ffffff;">Date :</div>
                    <div style="float: left; width: 150px; margin: 5px 0px 5px 10px; text-align: left; color: #ffffff;">
                        <label id="label_date" runat="server"></label>
                    </div>
                </div>

                


            </div>
            <div>
                <div style="float: left; width: 512px; min-height: 129px; background-color:#d0d0d0;">
                    <div style="font-size: 14px; color: #2c2b2b; width: 90%; float: left; padding: 0px 0px 0px 20px; font-weight: bold;">
                        <label style="color: #000000;">To</label>
                    </div>
                    <div style="font-size: 14px; color: #2c2b2b; width: 98%; float: left; min-height:91px;">
                        <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                            <asp:Label ID="lbl_toaddress" runat="server"></asp:Label>


                        </p>
                    </div>
                    <div style="width: 512px; float: left; border-top: 1px solid #b1b1b1;min-height: 79px;">
                        <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                        <div style="float: left; width: 130px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="div_gst" runat="server"></div>
                        <div style="float: left; width: 46px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                        <div style="float: left; width: 135px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="gst_state" runat="server"></div>
                        <div style="float: left; width: 40px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                        <div style="float: left; width: 40px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="gst_code" runat="server"></div>
                        <div style="float:left; width:100%; height:1px; border-bottom:1px solid #b1b1b1; margin-top:5px;"></div>
                    </div>
                </div>
                <div style="background-color: #d0d0d0; width: 512px; float: left; min-height: 117px; color: #000000;">
                    <div style="float: left; width: 512px; min-height: 108px;">
                        <div style="font-size: 14px; color: #2c2b2b; width: 90%; float: left; padding: 3px 0px 3px 20px; font-weight: bold;">
                            <label style="color: #000000;">Supply To</label>
                        </div>
                        <div style="font-size: 14px; color: #2c2b2b; width: 98%; float: left;">
                            <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                                <asp:Label ID="lbl_tosupply" runat="server"></asp:Label>


                            </p>
                        </div>
                    </div>
                    <div style="width: 512px; float: left; border-top: 1px solid #b1b1b1; min-height: 27px;">
                        <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                        <div style="float: left; width: 130px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplygst" runat="server"></div>
                        <div style="float: left; width: 46px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                        <div style="float: left; width: 150px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplystate" runat="server"></div>
                        <div style="float: left; width: 40px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                        <div style="float: left; width: 30px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplycode" runat="server"></div>
                    </div>
                      
                     <div style="clear: both;"></div>
                        <div id="FALedger" runat="server" visible="false">
                        <div style="float:left; width:100%; border-bottom:1px solid #b1b1b1; height:1px; margin:0px 0px 5px 0px;"></div>
                        <div style="float:left; width:165px; display:inline-block; margin:0px 0px 5px 0px; font-weight:bold; padding:0px 0px 0px 20px; color:#000;">FA Ledger Name</div>
                        <div style="clear:both;"></div>
                        <div style="width:433px; float:left; display:inline-block; margin:0px 0px 7px 0px; font-family:sans-serif; font-weight:normal; font-size:13px; color:#000; padding:0px 0px 0px 20px;"><asp:Label ID="lblLedgername" runat="server"></asp:Label></div>
                            </div>
                </div>

            </div>
            <div style="clear: both;"></div>
            <table border="0" cellspacing="0" cellpadding="5" style="width: 100%; border-collapse: collapse; border-right: 1px solid #b1b1b1; border-left: 1px solid #b1b1b1; border-bottom: 1px solid #b1b1b1; margin: 0px 0px 0px 0px; background-color:#d0d0d0;">
                <tr style="background-color: #d0d0d0;">
                    <th style="background-color: #184684; width: 300px; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;" rowspan="2">Charges</th>
                    <th style="background-color: #184684; width: 80px; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;" rowspan="2">SAC</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;" rowspan="2">Curr</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 90px;" rowspan="2">Rate</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;width:40px;" rowspan="2">Base</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 100px;" rowspan="2">Taxable Amt<label id="td_tax_basecurr" runat="server">(INR)</label></th>                    
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;" colspan="2">CGST</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;" colspan="2">S/U GST</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;" colspan="2">IGST</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;">Amount</th>
                </tr>
                <tr style="background-color: #d0d0d0;">
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 16px;">%</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 65px;">Amt</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 16px;">%</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 65px;">Amt</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 16px;">%</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff; width: 65px;">Amt</th>
                    <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #ffffff;" id="th_basecurr" runat="server">(INR)</th>
                </tr>
                <asp:Label ID="tr_row" runat="server"></asp:Label>
                <tr style="background-color: #d0d0d0;">
                    <td colspan="1" style="border-top: 1px solid #000; border-right:1px solid #000;">
                        <p style="float: left; margin: 0px 0px 0px 14px; font-weight:bold;">E & O E</p>
                        <div style="float: right; width: 62px; padding: 0px 0px 0px 20px;">Total </div>

                    </td>
                    <td id="td1" runat="server" style="border-top:1px solid #000; border-right: 1px solid #000; text-align:right;">&nbsp;</td>
                     <td id="td4" runat="server" style="border-top:1px solid #000; border-right: 1px solid #000; text-align:right;">&nbsp;</td>
                                <td id="td5" runat="server" style="border-top:1px solid #000; border-right: 1px solid #000; text-align:right;">&nbsp;</td>
                                <td id="td6" runat="server" style="border-top:1px solid #000; border-right: 1px solid #000; text-align:right;">&nbsp;</td>
                    <td id="td_taxableamt" runat="server" style="border-top: 1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000; border-left:1px solid #000;  border-right: 1px solid #000;">&nbsp;</td>
                    <td id="td_cgsta" runat="server" style="border-top: 1px solid #000; border-left: 1px solid #000; border-right: 1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000;  border-right: 1px solid #000;">&nbsp;</td>
                    <td id="td_sgsta" runat="server" style="border-top: 1px solid #000; border-right: 1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000;  border-right: 1px solid #000;">&nbsp;</td>
                    <td id="td_igsta" runat="server" style="border-top: 1px solid #000; border-right: 1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000; border-right: 1px solid #000;">
                        <asp:Label ID="lbl_total" runat="server" Style="text-align: right;  float: right;"></asp:Label></td>
                </tr>

            </table>
            <div style="float: left; width: 98.1%; background-color: #d0d0d0; border-bottom:1px solid #000000; border-top:1px solid #000000; padding: 5px 0px 5px 20px; margin: 0px 0px 0px 0px; font-size: 12px;">
                <asp:Label ID="lbl_currword" runat="server"></asp:Label>
            </div>
            <div style="clear: both;"></div>
            <div><label id="label_customer" runat="server"></label></div>
            <div style="clear:both;"></div>
            <div style="border-bottom:1px solid #b1b1b1; width:100%; float:left;"></div>
            <div style="float: left; width: 1024px; margin: 0px 0px 0px 0px; padding: 5px 0px 5px 0px; text-align: left; background-color: #d0d0d0;">
                    <label style="display: inline-block; margin: 0px 0px 0px 20px;">Remarks:</label>
                    <asp:Label ID="lbl_remarks" runat="server" Style="display: inline-block; width: 900px;"></asp:Label>
                </div>
            <div style="border-bottom:1px solid #b1b1b1; width:100%; float:left;"></div>
            <div style="clear:both;"></div>
            <div style="float: left; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 0px; background-color: #d0d0d0; color: #000000; width: 1024px; height: 88px;" id="div_authorised" runat="server" visible="true">
                
                <p style="margin: 0px 10px 0px 19px; padding: 0px 0px 0px 0px; color: #000000; float: right">
                    <strong>
                        For
                        <label id="label_branch" runat="server"></label>
                    </strong>
                </p>
                
                <div style="margin: 98px  0px 0px -47px;float:left;"  >
                    <strong>
                        <label id="label_approved" runat="server" visible="false">Unapproved Debit Note</label></strong>
                </div>
                <div style="margin: 75px  -355px 0px 19px;float:right;">
                    <strong>
                        <label>Authorised Signatory</label></strong>
                </div>
            </div>
            <div style="clear: both;"></div>
            <div style="clear: both;"></div>
        </div>
    </div>
</body>
</html>
