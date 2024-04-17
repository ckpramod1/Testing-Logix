<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemittanceReceiptFA.aspx.cs" EnableEventValidation="false" Inherits="logix.Reportasp.RemittanceReceiptFA" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <title></title>

    <style type="text/css">
        table#TblHead thead {
            display: table-header-group;
        }

        .div_right {
            float: right;
            width: 22%;
        }

        .div_left {
            float: left;
            width: 70%;
        }

        img#img_Logo {
            width: 74px !important;
            height: auto !important;
            margin-top: 7px;
        }

        div#tblVouDtls table {
            background: #d3d3d336;
            padding: 10px 10px 10px 10px;
        }

        @media print {
            .borderright {
                border-right: 4px solid black !important;
            }
        }
    </style>

</head>

<body style="margin: 0px; padding: 0px; font-family: Tahoma, Geneva, sans-serif; font-size: 14px; color: #000; line-height: 18px;">
    <form id="form1" runat="server">
        <div style="width: 1024px; margin: 0px auto;">
            <div style="width: 1024px; float: left; border-top: 1px solid #000; border-bottom: 1px solid #000; border-left: 1px solid #000; border-right: 1px solid #000;" class="borderright">

                <div style="float: left; text-align: center; width: 1024px; border-top: 0px solid #000; border-bottom: 1px solid #000;">

                    <div style="clear: both;"></div>
                    <div style="float: left; width: 1024px;">
                        <table width="1024px" cellpadding="0" cellspacing="0" id="TblHead">
                            <thead>
                                <th style="width: 20%;">
                                    <div style="float: left; padding: 0px 10px 10px 10px;">
                                        <asp:Image ID="img_Logo" runat="server" Width="128" Height="54" />

                                    </div>

                                </th>
                                <th>
                                    <h3 style="text-transform: capitalize; width: 74%; font-family: 'Segoe UI'; text-align: center; font-size: 24px; font-weight: 600; padding: 5px 0px 5px 0px; margin: -20px 0px 5px 0px; float: left;">
                                        <asp:Label ID="lblDivName" runat="server"></asp:Label></h3>
                                    <div style="clear: both;"></div>
                                    <p style="font-size: 14px; font-weight: normal; color: #000; line-height: 18px; width: 74%; float: left; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 0px; text-align: center;">
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label><br>
                                        <asp:Label ID="lblphonefax" runat="server"></asp:Label>
                                    </p>
                                </th>
                            </thead>

                        </table>

                    </div>

                </div>
                <div style="float: left; width: 1024px; border-bottom: 1px solid #000;">
                    <h4 style="font-family: 'Segoe UI'; font-size: 21px; padding: 5px 0px 8px 0px; margin: 0px 0px 0px 0px; text-align: center;">
                        <asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
                </div>
                <div style="width: 1024px; float: left; border-bottom: 1px solid #000; padding-bottom: 10px;">
                    <div class="div_right">

                        <div style="float: left; width: 78px; margin: 2px 5px 2px 23px; font-weight: bold;">
                            <asp:Label ID="lblrecPayno" runat="server"></asp:Label>
                        </div>
                        <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                        <div style="float: left; width: 94px; margin: 2px 5px 2px 10px;">
                            <asp:Label ID="lblRecno" runat="server"></asp:Label>
                        </div>

                        <div style="clear: both;"></div>

                        <div style="float: left; width: 46px; margin: 1px 5px 2px 55px; font-weight: bold;">
                            <asp:Label ID="lblrecPayDate" runat="server"></asp:Label>
                        </div>
                        <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                        <div style="float: left; width: 93px; margin: 2px 5px 2px 10px;">
                            <asp:Label ID="lblRecDate" runat="server"></asp:Label>
                        </div>

                        <div style="clear: both;"></div>

                        <div style="float: left; width: 65px;margin: 1px 5px 2px 33px; font-weight: bold;">
                            <asp:Label ID="Label1" runat="server">EX Rate</asp:Label>
                        </div>
                        <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                        <div style="float: left; width: 93px; margin: 2px 5px 2px 10px;">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>

                    </div>
                    <div class="div_left">

                        <div style="float: left; width: 110px; margin: 2px 5px 2px 10px; font-weight: bold;">
                            <asp:Label ID="lblrecPayfromto" runat="server"></asp:Label>
                        </div>
                        <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                        <div style="float: left; width: 440px; margin: 2px 5px 2px 10px;">
                            <asp:Label ID="lblReceivedfrom" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>



                        <%--cheque--%>

                        <div style="float: left; width: 110px; margin: 2px 5px 2px 10px; font-weight: bold;">Bank Ref #</div>
                        <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                        <div style="float: left; width: 440px; margin: 2px 5px 2px 10px">
                            <asp:Label ID="lblchequeno" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>

                        <%--        <div style="float: left; width: 160px; font-weight: bold; padding: 2px 5px 2px 0px; margin: 2px 0px 2px 0px;"></div>
                                <div style="float: left; width: 2px; padding: 2px 5px 2px 5px; margin: 2px 0px 2px 5px;">:</div>
                                <div style="float: left; width: 450px; padding: 2px 5px 2px 5px; margin: 2px 0px 2px 5px;">
                                    <asp:Label ID="lblchequeno" runat="server"></asp:Label></div>--%>

                        <%--bank--%>

                        <div style="float: left; width: 110px; margin: 2px 5px 2px 10px; font-weight: bold;">Bank / Branch </div>
                        <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                        <div style="float: left; width: 440px; margin: 2px 5px 2px 10px;">
                            <asp:Label ID="lblbank" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>





                        <div style="clear: both;"></div>

                        <div style="float: left; width: 110px; margin: 2px 5px 2px 10px; font-weight: bold;">Prepared By</div>
                        <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                        <div style="float: left; width: 440px; margin: 2px 5px 2px 10px;">
                            <asp:Label ID="lblpreparedby" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>





















                        <%--             <div style="float: left; width: 160px; font-weight: bold; padding: 2px 5px 2px 0px; margin: 2px 0px 2px 0px;"></div>
                                <div style="float: left; width: 2px; padding: 2px 5px 2px 5px; margin: 2px 0px 2px 5px;">:</div>
                                <div style="float: left; width: 450px; padding: 2px 5px 2px 5px; margin: 2px 0px 2px 5px;">
                                    <asp:Label ID="lblbank" runat="server"></asp:Label></div>--%>



                        <div style="float: right; width: 120px; display: none;">
                            <div style="float: left; width: auto; margin: 2px 5px 2px 5px; text-align: right; font-weight: bold;">
                                <label>ID</label>
                            </div>
                            <div style="float: left; width: 2px; margin: 2px 5px 2px 5px; text-align: right;">:</div>
                            <div style="float: left; width: auto; margin: 2px 5px 2px 5px; text-align: right; font-weight: bold;">
                                <asp:Label ID="lblRecId" runat="server"></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>

                <div style="width: 100%; float: left; border-bottom: 1px solid #000;">
                    <div style="float: left; width: 68px; margin: 2px 5px 2px 10px; font-weight: bold;">
                        Narration
                    </div>
                    <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                    <div style="float: left; width: 440px; margin: 2px 5px 2px 10px; white-space: nowrap">
                        <asp:Label ID="lblnarration" runat="server"></asp:Label>
                    </div>

                    <div style="clear: both;"></div>
                </div>
                <div style="width: 1024px; float: left;">
                    <table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding: 0px 0px 0px 0px;">
                        <tr>
                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Account Head</th>

                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 200px;">FC Amount</th>

                            <th style="padding: 2px 0px 2px 5px; margin: 0px 0px 0px 0px; text-align: center; border-bottom: 1px solid #000; width: 200px;">Rs.</th>
                        </tr>
                        <asp:Label ID="lblcustDtls" runat="server"></asp:Label>
                        <tr>
                            <td style="border-right: 1px solid #000; padding: 2px 5px 2px 5px; margin: 0px; text-align: left; border-right: 1px solid #000;">
                                <div id="tblVouDtls" runat="server">
                                    <table width="750" border="0" cellspacing="0" cellpadding="0" style="margin: 8px 20px 8px 20px; float: right;">
                                        <tr>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-bottom: 1px solid black;" colspan="7">Aganist Ref #</th>
                                        </tr>
                                        <tr>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-bottom: 1px solid black;">Branch</th>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-bottom: 1px solid black;">Voucher #</th>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; width: 70px; border-bottom: 1px solid black;">Date</th>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-bottom: 1px solid black;">Curr</th>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-bottom: 1px solid black; text-align: right">FCurr Amount</th>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-bottom: 1px solid black; text-align: right">Ex Rate</th>
                                            <th style="padding: 2px 5px 2px 5px; margin: 0px; text-align: center; border-bottom: 1px solid black; text-align: right">Rs.</th>
                                        </tr>


                                        <asp:Label ID="lblPaymentDtls" runat="server"></asp:Label>







                                        <tr style="display: none">
                                            <td style="padding: 2px 5px 2px 5px; margin: 0px; text-align: right;">&nbsp;</td>
                                            <td style="padding: 2px 5px 2px 5px; margin: 0px; text-align: right;">&nbsp;</td>
                                            <td style="padding: 2px 5px 2px 5px; margin: 0px; text-align: right;">&nbsp;</td>
                                            <td style="padding: 2px 5px 2px 5px; margin: 0px; text-align: right;">&nbsp;</td>
                                            <td style="padding: 2px 5px 2px 5px; margin: 0px; text-align: right;">
                                                <asp:Label ID="lblfctotamt" runat="server"></asp:Label></td>
                                            <td style="padding: 2px 5px 2px 5px; margin: 0px; text-align: right;">&nbsp;</td>
                                            <td style="padding: 2px 5px 2px 5px; margin: 5px; text-align: right;">
                                                <asp:Label ID="lblINRtotal" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divannexDtls" runat="server" style="font-size: 16px; font-weight: bold; padding: 50px 0px 50px 0px; font-weight: normal; text-align: center; width: 100%;" visible="false">
                                    <asp:Label ID="lblannex" runat="server"> </asp:Label>
                                </div>

                            </td>
                            <td style="border-right: 1px solid #000; padding: 5px 5px 5px 5px; margin: 5px; text-align: left; border-right: 1px solid #000;">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <asp:Label ID="lblChargeDtls" runat="server"></asp:Label>
                        <tr>
                            <td colspan="1" style="border-right: 1px solid #000; border-top: 1px solid #000; padding: 2px 5px 2px 5px; margin: 0px; text-align: left; border-right: 1px solid #000;">&nbsp;</td>
                            <td style="padding: 2px 5px 2px 5px; margin: 0px 0px 0px 0px; text-align: right; border-top: 1px solid #000; border-right: 1px solid #000; border-left: 0px solid #000;">
                                <asp:Label ID="lblFCAmttotal" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 2px 5px 2px 5px; margin: 0px 0px 0px 5px; text-align: right; border-top: 1px solid #000; border-left: 0px solid #000;">
                                <asp:Label ID="lblAmttotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding: 2px 5px 2px 5px; margin: 0px 0px 0px 5px; text-align: left; border-top: 1px solid #000; border-left: 0px solid #000;">

                                <div style="float: left; width: 60px; margin: 2px 5px 2px 10px; font-weight: bold;">
                                    Rupees
                                </div>
                                <div style="float: left; width: 1px; margin: 2px 5px 2px 0px; display: none">:</div>
                                <div style="float: left; width: 440px; margin: 2px 5px 2px 10px; white-space: nowrap">
                                    <asp:Label ID="lblRupeesinwords" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td colspan="4" style="padding: 2px 5px 2px 5px; margin: 0px 0px 0px 5px; text-align: left; border-top: 1px solid #000; border-left: 0px solid #000;">


                                <div style="clear: both;"></div>



                                <div style="clear: both;"></div>
                                <div style="float: left; width: 400px; font-size: 11px; padding: 2px 5px 2px 0px; margin: 2px 0px 2px 0px;" id="divChequesub" runat="server">Cheque Subject to realisation</div>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4" style="padding: 2px 5px 2px 5px; margin: 2px 0px 5px 5px; text-align: left; border-top: 1px solid #000; border-left: 0px solid #000;">

                                <div style="width: 100%; float: left">
                                    <div style="width: 50%; float: left; margin-top: 66px;">
                                        <div style="font-weight: bold; width: 80px; float: left; margin-top: 4px;">
                                            Print Date
                                        </div>
                                        <div style="float: left; width: 59px; padding: 0px; margin: 5px 5px 0px 0px; text-align: right; font-size: 11px;">
                                            <asp:Label ID="lblToday" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div style="float: right; width: 149px; font-weight: bold; margin-top: 70px;">Authorised Signatory</div>
                                </div>


                            </td>
                        </tr>
                    </table>

                </div>


                <div style="clear: both;"></div>
            </div>
            <div style="clear: both;"></div>
        </div>

        <asp:Button ID="btnreport" runat="server" Visible="false" />
        <%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>
    </form>

</body>
</html>
