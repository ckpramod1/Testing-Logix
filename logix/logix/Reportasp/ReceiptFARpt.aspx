<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptFARpt.aspx.cs" Inherits="logix.Reportasp.ReceiptFARpt" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">

    <title></title>
    <style>
        img#lbl_wiz {
            width: 75px !important;
            height: auto !important;
        }

        div#tblVouDtls table {
            width: 98% !important;
            background: #d3d3d336;
            margin: 0px !important;
            float: right;
        }

        div#tblVouDtls {
            margin-right: 14px;
            margin-top: 16px;
        }
    </style>
</head>

<body style="margin: 0px; padding: 0px; font-family: Tahoma, Geneva, sans-serif; font-size: 14px; color: #000; line-height: 18px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="width: 1024px; margin: 0px auto;">

            <div style="float: right; padding: 5px 5px; display: none;">
                <asp:Image ID="img_Logo" runat="server" Width="269" Height="54" />
            </div>
            <div style="width: 1024px; float: left; border-top: 1px solid #000; border-bottom: 1px solid #000; border-left: 1px solid #000; border-right: 1px solid #000;">
                <div style="float: left; text-align: center; width: 1024px; border-top: 0px solid #000; border-bottom: 1px solid #000;">



                    <div style="clear: both;"></div>
                    <div style="float: left; width: 1024px;">
                        <div style="float: left; padding: 5px 5px;">
                            <asp:Image ID="lbl_wiz" runat="server" Width="128" Height="54" />
                        </div>
                        <div style="float: left; width: 80%; margin-top: 23px !important;">
                            <h3 style="text-transform: capitalize; width: 91%; font-family: 'Segoe UI'; text-align: center; font-size: 24px; font-weight: 600; padding: 5px 0px 5px 0px; margin: 0px 0px 5px 54px; float: left;">
                                <asp:Label ID="lblDivName" runat="server"></asp:Label></h3>
                            <div style="clear: both;"></div>
                            <div id="div_form" runat="server" style="padding: 0px 0px 0px 0px; display: none">
                                <asp:Label ID="lblformaly" runat="server" Text=""></asp:Label><br />
                            </div>
                            <p style="font-size: 14px; color: #000; line-height: 18px; width: 91%; float: left; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 54px; text-align: center;">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label><br>
                                <asp:Label ID="lblphonefax" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div style="float: left; width: 1024px; border-bottom: 1px solid #000;">
                    <h4 style="font-family: 'Segoe UI'; font-size: 21px; padding: 5px 0px 9px 0px; margin: 0px 0px 0px 0px; text-align: center;">
                        <asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
                </div>
                <div style="width: 1024px; float: left; border-bottom: 1px solid #000; padding-bottom: 4px;">

                    <div style="width: 100%; float: left;">
                        <div style="float: right; width: 18.9%;">
                            <div style="float: left; width: 72px; margin: 5px 7px 5px 10px; font-weight: bold;">Receipt #</div>
                            <div style="float: left; width: 1px; margin: 5px 11px 5px 0px; display: none">:</div>
                            <div style="float: left; width: 87px; margin: 5px 5px 5px 0px;">
                                <asp:Label ID="lblRecno" runat="server"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>
                            <div style="float: left; width: 36px; margin: 5px 7px 5px 47px; font-weight: bold;">Date </div>
                            <div style="float: left; width: 1px; margin: 5px 11px 5px 0px; display: none">:</div>
                            <div style="float: left; width: 77px; margin: 5px 5px 5px 0px;">
                                <asp:Label ID="lblRecDate" runat="server"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>







                        </div>
                        <div style="float: left;">
                            <div style="float: left; width: 165px; margin: 5px 7px 5px 10px; font-weight: bold;">Received From</div>
                            <div style="float: left; width: 1px; margin: 5px 11px 5px 0px; display: none">:</div>
                            <div style="float: left; width: 500px; margin: 5px 5px 5px 0px;">
                                <asp:Label ID="lblReceivedfrom" runat="server"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>




                            <div style="float: left; width: 165px; margin: 5px 7px 5px 10px; font-weight: bold;">Cheque / DD #  & Date </div>
                            <div style="float: left; width: 1px; margin: 5px 11px 5px 0px; display: none">:</div>
                            <div style="float: left; width: 440px; margin: 5px 5px 5px 0px;">
                                <asp:Label ID="lblchequeno" runat="server">   </asp:Label>
                                <asp:Label Text="(Cheque Subject to realisation)" runat="server" />
                            </div>

                            <div style="clear: both;"></div>




                            <div style="float: left; width: 165px; margin: 5px 7px 5px 10px; font-weight: bold;">Bank / Branch </div>
                            <div style="float: left; width: 1px; margin: 5px 11px 5px 0px; display: none">:</div>
                            <div style="float: left; width: 440px; margin: 5px 5px 5px 0px;">
                                <asp:Label ID="lblbank" runat="server"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>

                            <div style="float: left; width: 165px; margin: 5px 7px 5px 10px; font-weight: bold;">Prepared By </div>
                            <div style="float: left; width: 1px; margin: 5px 11px 5px 0px; display: none">:</div>
                            <div style="float: left; width: 500px; margin: 5px 5px 5px 0px;">
                                <asp:Label ID="lblpreparedby" runat="server"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>





                        </div>
                        <div style="border-top: 1px solid #000; float: left; width: 100%">
                            <div style="float: left; width: 76px; margin: 5px 7px 5px 10px; font-weight: bold;">Narration</div>
                            <div style="float: left; width: 1px; margin: 5px 11px 5px 0px; display: none">:</div>
                            <div style="float: left; width: 440px; margin: 5px 5px 5px 0px; white-space: nowrap;">
                                <asp:Label ID="lblnarration" runat="server"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                    </div>
                    <div style="float: right; width: 120px; display: none;">
                        <div style="float: left; width: auto; margin: 5px 5px 5px 5px; text-align: right; font-weight: bold;">
                            <label>ID</label>
                        </div>
                        <div style="float: left; width: 2px; margin: 5px 5px 5px 5px; text-align: right; display: none">:</div>
                        <div style="float: left; width: auto; margin: 5px 5px 5px 5px; text-align: right; font-weight: bold;">
                            <asp:Label ID="lblRecId" runat="server"></asp:Label>
                        </div>

                    </div>
                </div>

                <div style="width: 1024px; float: left; border-bottom: 0px solid #000;">
                    <table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding: 0px 0px 0px 0px;">
                        <tr>
                            <th style="padding: 5px 5px 5px 80px; width: 550px; margin: 5px; text-align: left; border-right: 1px solid #000; border-bottom: 1px solid #000; text-align: center" colspan="2">Account  Head </th>

                            <th style="padding: 5px 0px 5px 5px; margin: 5px 0px 5px 0px; text-align: right; border-bottom: 1px solid #000; width: 175px;">Amount Rs.</th>
                        </tr>
                        <asp:Label ID="tr_Lblcustamount" runat="server"></asp:Label>
                        <tr style="border-bottom: 1px solid #000">
                            <td colspan="2" style="border-right: 1px solid #000; padding: 5px 5px 5px 5px; margin: 5px; text-align: left; border-right: 1px solid #000;">



                                <div id="tblVouDtls" runat="server">

                                    <table width="500" border="0" cellspacing="0" cellpadding="0" style="border: 0px solid #000; margin: 20px 20px 10px 50px; float: right;">
                                        <tr>
                                            <th colspan="4" style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-left: 0px solid #000; border-top: 0px solid #000; border-right: 0px solid #000; border-bottom: 1px solid #000;">Against Ref Details</th>
                                        </tr>
                                        <tr>
                                            <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 0px solid #000; border-bottom: 1px solid #000; width: 80px;">Branch</th>
                                            <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 0px solid #000; border-bottom: 1px solid #000; width: 120px;">Voucher #</th>
                                            <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 0px solid #000; border-bottom: 1px solid #000; width: 80px;">Date</th>
                                            <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 0px solid #000; border-bottom: 1px solid #000; width: 150px; text-align: right">Amount Rs.</th>
                                        </tr>

                                        <asp:Label ID="tr_row" runat="server"></asp:Label>

                                        <tr>
                                            <td style="border-right: 1px solid #000; padding: 5px 5px 5px 5px; margin: 5px; text-align: right; border-right: 0px solid #000;">&nbsp;</td>
                                            <td style="border-right: 1px solid #000; padding: 5px 5px 5px 5px; margin: 5px; text-align: right; border-right: 0px solid #000;">&nbsp;</td>
                                            <td style="border-right: 1px solid #000; padding: 5px 5px 5px 5px; margin: 5px; text-align: right; border-right: 0px solid #000;">&nbsp; </td>
                                            <td style="border-right: 0px solid #000; padding: 5px 5px 5px 5px; margin: 5px; text-align: right; border-top: 0px solid #000;">
                                                <asp:Label ID="lbrecpayltotal" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>

                                </div>
                                <div id="divannexDtls" runat="server" style="font-size: 16px; font-weight: bold; padding: 50px 0px 50px 0px; font-weight: normal; text-align: center; width: 100%;" visible="false">
                                    <asp:Label ID="lblannex" runat="server"> </asp:Label>
                                </div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <asp:Label ID="tr_LblChargedtls" runat="server"></asp:Label>

                        <tr>
                            <td colspan="3" style="padding: 5px 5px 5px 5px; margin: 5px 0px 5px 5px; text-align: left; border-top: 1px solid #000; border-left: 0px solid #000;">
                                <div style="float: left; width: 70px; font-weight: bold">Rupees</div>
                                <div style="float: left; width: 859px;">
                                    <asp:Label ID="lblRupeesinwords" runat="server"></asp:Label>
                                </div>
                                <div style="float: left; margin: 0px 0px 0px 0px">
                                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr id="trcheque" runat="server" visible="false">
                            <td colspan="3" style="padding: 5px 5px 5px 5px; margin: 5px 0px 5px 5px; text-align: left; border-top: 0px solid #000; border-left: 0px solid #000;"></td>
                        </tr>

                        <tr>
                            <td colspan="3" style="padding: 5px 5px 5px 5px; margin: 5px 0px 5px 5px; text-align: left; border-top: 1px solid #000; border-left: 0px solid #000;">
                                <div style="width: 100%; float: left;">
                                    <div style="width: 50%; float: left;margin-top: 66px;">
                                        <div style="width:auto;float:left;font-weight:bold;margin-top: 5px;">Print Date</div>
                                        <div style="float: left; width: 70px; padding: 0px; margin: 5px 5px 0px 0px; text-align: right; font-size: 11px;">
                                            <asp:Label ID="lblToday" runat="server"></asp:Label>
                                        </div>
                                            
                                    </div>

                                    <div style="width: 50%; float: left">
                                        <div style="float: right; width: 220px; font-weight: bold; margin-top: 70px; margin-right: -65px;">Authorised Signatory</div>

                                    </div>
                                </div>


                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnreport" runat="server" Visible="false" />
                </div>


                <div style="clear: both;"></div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </form>
</body>
</html>

