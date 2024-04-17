<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDCNrptFA.aspx.cs" Inherits="logix.Reportasp.AdminDCNrptFA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="padding: 0px; margin: 0px; background-color: #fff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; color: #000;">
    <div style="width: 100%; margin: auto;">
          <div style="width: 1024px; margin: 3px auto 3px auto;">
               
                        <%--Width="116" Height="32"--%>
                    </div>
        <div style="width: 1024px; margin: auto; border:1px solid #000;">
            <div style="float: left; width: 100%;">
                <div style="float: left; width: 150px; color: #000; margin: 9px 10px 5px 15px;">
                 <asp:Image  ID="lbl_img" runat="server" Width="143" Height="89" />
                </div>
                <div style="width: 735px; float: left; margin: 7px 0px 4px 9px; text-align: center;">
                    <h3 style="font-family: Segoe UI; font-size: 30px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 10px;">
                        <asp:Label ID="lbl_branch" runat="server"></asp:Label>.</h3>
<%--                     <p style="margin:2px 0px 2px 0px; padding:0px 0px 0px 0px; font-size:14px; font-family: Segoe UI; text-align:center; ">(Formerly Known as Axelerom International Logistics Private Limited)</p>--%>

                    <div style="text-align: center; font-family: Segoe UI; font-size: 14px; margin: 0px 0px 0px 5px; padding: 0px; font-weight: normal; line-height: 18px; color: #000;">
                        <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                        Phone:<asp:Label ID="lbl_ph" runat="server"></asp:Label>
                        Fax:<asp:Label ID="lbl_fax" runat="server"></asp:Label><br />
                        <div id="div_invoicehead" runat="server" visible="true" style="padding: 0px 0px 0px 0px; color: #000;">
                            GST.# :
                            <asp:Label ID="lbl_st" runat="server"></asp:Label>
                            PAN # :
                            <asp:Label ID="lbl_pan" runat="server"></asp:Label>
                            CIN # :
                            <asp:Label ID="lbl_cin" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="float: left; width: 100px; color: #000; margin: 5px 0px 0px 0px; text-align:right;">
                    <asp:Label ID="lbl_page" Width="100%" runat="server" Text="" />
                </div>
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px; text-align: center; color:#000; padding: 5px 0px 5px 0px; font-weight: bold; border-top:1px solid #000; border-bottom:1px solid #000;">
                <h3 style="font-family:'Segoe UI'; float:left; font-size:24px;text-align:left; color:#000; text-transform:uppercase; width:60%; font-weight:normal; padding:0px; margin:0px 0px 0px 9px;">
                           <asp:Label ID="lbl_head" runat="server">Admin Sales Invoice</asp:Label></h3>
                <div style="float:right; width:28%; text-transform:uppercase; color:#000; font-size:15px; font-family:sans-serif; padding:7px 10px 5px 0px; font-weight:normal;"><span id="LBL_Original">Original for the Recipient</span></div>
                
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px;">
                <div style="float: left; width: 511px; border-right:1px solid #000;">
                    <div style="float: left; width: 112px; margin: 5px 0px 5px 10px; color: #000;">Customer Ref #</div>
                    <div style="float: left; width: 2px; margin: 5px 10px 5px 0px; color: #000;">:</div>
                    <div style="float: left; width: 300px; margin: 5px 0px 5px 0px; color: #000;">
                        <label id="label_refno" runat="server"></label>
                    </div>


                    <div id="div_vendorref" runat="server" visible="false">
                        <div style="width: 112px; float: left; display: inline-block; margin: 5px 0px 5px 10px; font-weight: normal; padding: 0px 0px 0px 0px; color: #000;">
                            <label id="label_vendor" runat="server">Vendor Ref #</label>
                        </div>
                        <div style="float: left; width: 2px; margin: 5px 10px 5px 0px; color: #000;">:</div>
                        <div style="width: 260px; float: left; display: inline-block; margin: 5px 0px 5px 0px; color: #000;">
                            <asp:Label ID="lbl_vendor" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="width: 112px; float: left; display: inline-block; margin: 5px 0px 5px 10px; font-weight: normal; padding: 0px 0px 0px 0px; color: #000;">
                            <label id="label1" runat="server">Date</label>
                        </div>
                        <div style="float: left; width: 2px; margin: 5px 10px 5px 0px; color: #000;">:</div>
                        <div style="width: 260px; float: left; display: inline-block; margin: 5px 0px 5px 0px; color: #000;">
                            <asp:Label ID="lbl_vendordate" runat="server"></asp:Label>
                        </div>
                    </div>


                </div>
                <div style="float: left; width: 512px; border-left:0px solid #000;">
                    <div style="float: left; width: 50px; margin: 5px 0px 5px 10px; color: #000; text-align: right;" id="labeldnc" runat="server">DN # :</div>
                    <div style="float: left; width: 150px; margin: 5px 0px 5px 10px; color: #000;">
                        <label id="label_DNCN" runat="server"></label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 50px; margin: 5px 0px 5px 10px; text-align: right; color: #000;">Date :</div>
                    <div style="float: left; width: 150px; margin: 5px 0px 5px 10px; text-align: left; color: #000;">
                        <label id="label_date" runat="server"></label>
                    </div>
                </div>
            </div>
            <div>
                <div style="float: left; width: 511px; min-height: 129px; border-right:1px solid #000; border-top:1px solid #000;">
                    <div style="font-size: 14px; color: #000; width: 90%; float: left; padding: 5px 0px 5px 9px; font-weight: bold;">
                        <label style="color: #000000;">To</label>
                    </div>
                    <div style="font-size: 14px; color: #000; width: 98%; float: left; min-height: 85px;">
                        <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                            <asp:Label ID="lbl_toaddress" runat="server"></asp:Label>


                        </p>
                    </div>
                    <div style="width: 512px; float: left; border-top: 1px solid #000; min-height: 79px;">
                        <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                        <div style="float: left; width: 130px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="div_gst" runat="server"></div>
                        <div style="float: left; width: 46px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                        <div style="float: left; width: 135px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="gst_state" runat="server"></div>
                        <div style="float: left; width: 40px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                        <div style="float: left; width: 40px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="gst_code" runat="server"></div>
                       <div style="float:left; width:100%; border-top:1px solid #000; height:1px; margin-top:6px;"></div>
                    </div>
                   

                </div>
                <div style="width: 512px; float: left; min-height: 117px; color: #000000; border-top:1px solid #000;">
                    <div style="float: left; width: 512px; min-height: 112px;">
                        <div style="font-size: 14px; color: #000; width: 90%; float: left; padding: 3px 0px 3px 10px; font-weight: bold;">
                            <label style="color: #000000;">Supply To</label>
                        </div>
                        <div style="font-size: 14px; color: #000; width: 98%; float: left;">
                            <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                                <asp:Label ID="lbl_tosupply" runat="server"></asp:Label>


                            </p>
                        </div>
                    </div>
                   
                    <div style="width: 512px; float: left; border-top: 1px solid #000; min-height: 27px;">
                        <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                        <div style="float: left; width: 130px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplygst" runat="server"></div>
                        <div style="float: left; width: 46px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                        <div style="float: left; width: 150px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplystate" runat="server"></div>
                        <div style="float: left; width: 40px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                        <div style="float: left; width: 30px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplycode" runat="server"></div>
                    </div>
                      
                     <div style="clear: both;"></div>
                        <div id="FALedger" runat="server" visible="false">
                        <div style="float:left; width:100%; border-bottom:1px solid #000; height:1px; margin:0px 0px 5px 0px;"></div>
                        <div style="float:left; width:165px; display:inline-block; margin:0px 0px 5px 0px; font-weight:bold; padding:0px 0px 0px 20px; color:#000;">FA Ledger Name</div>
                        <div style="clear:both;"></div>
                        <div style="width:433px; float:left; display:inline-block; margin:0px 0px 7px 0px; font-family:sans-serif; font-weight:normal; font-size:13px; color:#000; padding:0px 0px 0px 20px;"><asp:Label ID="lblLedgername" runat="server"></asp:Label></div>
                            </div>
                </div>

            </div>
            <div style="clear: both;"></div>
            <table border="0" cellspacing="0" cellpadding="5" style="width: 100%; border-collapse: collapse; border-right: 0px solid #000; border-left: 0px solid #000; border-bottom: 1px solid #000; margin: 0px 0px 0px 0px;">
                <tr style="">
                    <th style="width: 300px; color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;" rowspan="2">Charges</th>
                    <th style="width: 80px; color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;" rowspan="2">SAC</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;" rowspan="2">Curr</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000; width: 90px;" rowspan="2">Rate</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000; width: 40px;" rowspan="2">Base</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000; width: 100px;" rowspan="2">Taxable Amt<label id="td_tax_basecurr" runat="server">(INR)</label></th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;" colspan="2">CGST</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;" colspan="2">S/U GST</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;" colspan="2">IGST</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 0px solid #000; border-bottom: 1px solid #000; border-top:1px solid #000;">Amount</th>
                </tr>
                <tr style="">
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 16px;">%</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 65px;">Amt</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 16px;">%</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 65px;">Amt</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 16px;">%</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 65px;">Amt</th>
                    <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 0px solid #000; border-bottom: 1px solid #000;" id="th_basecurr" runat="server">(INR)</th>
                </tr>
                <asp:Label ID="tr_row" runat="server"></asp:Label>
                <tr>
                    <td style="border-top: 1px solid #000; border-right:1px solid #000;"><h3 style="color: #000; float: left; width: 150px; font-family: sans-serif, Geneva, sans-serif; font-size: 18px; padding: 0px 0px 0px 20px; margin: 0px;">E & O E</h3></td>
                    <td style="border-top: 1px solid #000; border-right:1px solid #000;">
                        <div style="float: right; width: 62px; padding: 0px 0px 0px 20px;">Total :</div>

                    </td>
                    <td style="border-top:1px solid #000; border-right:1px solid #000;"></td>
                    <td style="border-top:1px solid #000; border-right:1px solid #000;"></td>
                    <td style="border-top:1px solid #000; border-right:1px solid #000;"></td>
                    <td id="td_taxableamt" runat="server" style="border-top: 1px solid #000; border-right:1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000; border-right:1px solid #000;">&nbsp;</td>
                    <td id="td_cgsta" runat="server" style="border-top: 1px solid #000; border-right:1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000; border-right:1px solid #000;">&nbsp;</td>
                    <td id="td_sgsta" runat="server" style="border-top: 1px solid #000; border-right:1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000; border-right:1px solid #000;">&nbsp;</td>
                    <td id="td_igsta" runat="server" style="border-top: 1px solid #000; border-right:1px solid #000; text-align: right;">&nbsp;</td>
                    <td style="border-top: 1px solid #000; border-right:1px solid #000;">
                        <asp:Label ID="lbl_total" runat="server" Style="text-align: right; float: right;"></asp:Label></td>
                </tr>

            </table>
            <div style="float: left; width: 98.1%; padding: 5px 0px 5px 20px; margin: 0px 0px 0px 0px; font-size: 12px;">
                <h3 style="color: #000; float: left; width: 135px; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 1px 0px 1px 0px; margin: 0px;">Amount in words :</h3> <asp:Label ID="lbl_currword" runat="server" style="display:inline-block; padding:3px 0px 0px 0px;"></asp:Label>
            </div>
            <div style="clear: both;"></div>
            <div>
                <label id="label_customer" runat="server"></label>
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px; margin: 0px 0px 0px 0px; padding: 0px 0px 4px 0px; text-align: left; border-top:1px solid #000;">
                <label style="display: inline-block; margin: 0px 0px 0px 20px;">Remarks:</label>
                <asp:Label ID="lbl_remarks" runat="server" Style="display: inline-block; width: 900px;"></asp:Label>
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px;">
                <div id="div_bank" runat="server" visible="false" style="width: 1022px; float: left; margin: 0px 10px 0px 0px; padding:0px 0px 10px 0px;">
                   
                    <div style="clear: both;"></div>
                    <p style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 22px; color: #000;"><strong>Bank Details :-</strong></p>
                    <label style="float: left; width: 215px; margin: 0px 5px -5px 22px; color: #000; height: 17px;">Beneficiary name</label>
                    <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                    <span style="float: left;">
                        <asp:Label ID="lbl_favouring" runat="server" Style="color: #000;"></asp:Label></span>
                    <div style="clear: both;"></div>
                    <label style="float: left; width: 215px; margin: 0px 5px -5px 22px; color: #000;">Account No (USD)</label>
                    <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                    <span style="float: left; color: #000;">
                        <asp:Label ID="lbl_accno" runat="server"></asp:Label></span>
                    <div style="clear: both;"></div>

                    <label style="float: left; width: 215px; margin: 0px 5px -5px 22px; color: #000;">Swift Code of <asp:Label ID="lbl_bank_name" runat="server" Style="color: #000;"></asp:Label>(India) </label>
                    <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                    <span style="float: left;">
                        <asp:Label ID="lbl_ifsccode" runat="server" Style="color: #000;"></asp:Label></span>
                    <div style="clear: both;"></div>
                    <label style="float: left; width: 215px; margin: 0px 5px -5px 22px; color: #000;">Bank</label>
                    <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                    <span style="float: left;">
                        <asp:Label ID="lbl_bankname" runat="server" Style="color: #000;"></asp:Label></span>
                    <div style="clear: both;"></div>
                    <label style="float: left; width: 215px; margin: 0px 5px -5px 22px; color: #000;">Address</label>
                    <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                    <span style="float:left;">
                        <asp:Label ID="lbl_bankaddress" runat="server" Style="color: #000;"></asp:Label></span>


                </div>
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 0px; color: #000000; width: 1024px; height: 115px; border-top:1px solid #000; border-bottom:1px solid #000;" id="div_authorised" runat="server" visible="true">
                <p style="margin: 0px 10px 0px 19px; padding: 0px 0px 0px 0px; color: #000000; float: right">
                    for
                    <strong>
                        <label id="label_branch" runat="server"></label>
                    </strong>
                </p>
                 <div style="clear:both;"></div>
                 <div style="margin: 75px  0px 0px 18px; float: left; font-size:13px; font-weight:normal;">
                    <strong>
                        <label id="label_approved" runat="server" visible="false">Unapproved Debit Note</label></strong>
                </div>
                 <div style="clear:both;"></div>
               
               

                <div style="margin: -16px  9px 0px 20px; float: right;">
                    <strong>
                        <label>Authorised Signatory</label></strong>
                </div>
               
            </div>

             <div style="float:left; width:250px; font-family:sans-serif; font-size:13px; font-weight:bold; color:#000; margin:16px 0px 0px 17px;">
                    Prepared By:
                </div>
            <div style="clear:both;"></div>
                <div style="float:left; width:250px; font-family:sans-serif; font-size:13px; font-weight:normal; color:#000; margin:16px 0px 0px 17px;">
                    <asp:Label ID="lbl_preparevalue" runat="server" Text="Prepare Value"></asp:Label>

                </div>
            <div style="width:250px; float:right;">
                  <div style="float:left; width:250px; font-family:sans-serif; font-size:13px; font-weight:bold; color:#000; margin:-17px 0px 0px 20px;">
                    Approved By:
                </div>
            <div style="clear:both;"></div>
                <div style="float:left; width:250px; font-family:sans-serif; font-size:13px; font-weight:normal; color:#000; margin:16px 0px 0px 5px;">
                     <asp:Label ID="lbl_Approve" runat="server" Text="Approved Value"></asp:Label>

                </div>
                </div>
                
            <div style="clear: both;"></div>
        </div>
    </div>
</body>
</html>
