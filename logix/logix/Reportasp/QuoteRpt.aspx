<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuoteRpt.aspx.cs" Inherits="logix.Reportasp.QuoteRpt" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <title></title>

    <style type="text/css">
        table#TblHead thead {
            display: table-header-group;
        }

        
        span#lblshipaddress {
    float: left;
    /* text-align: left; */
    display: block;
    margin-top: -35px;
}
    </style>

</head>

<body style="margin: 0px; padding: 0px; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; color: #000; line-height: 18px;">
    <div style="width: 1024px; margin: 0px auto;">
        <div style="float: right; padding: 5px 5px;">
            <asp:Image ID="img_Logo" runat="server" Width="269" Height="54" />
        </div>

        <div style="width: 1024px; float: left; border-top: 0px solid #000; border-bottom: 0px solid #000; border-left: 0px solid #000; border-right: 0px solid #000;">
            <div style="float: left; text-align: center; width: 1024px; border-top: 0px solid #000; border-bottom: 1px solid #000;">
                <div style="float: right; width: 70px; padding: 0px; margin: 5px 5px 0px 0px; text-align: right; font-size: 11px;">
                    <asp:Label ID="lblToday" runat="server"></asp:Label>
                </div>
                <div style="clear: both;"></div>
                <div style="float: left; width: 1024px;">
                    <table width="1024px" cellpadding="0" cellspacing="0" id="TblHead">
                        <thead>
                            <th>
                                <h3 style="text-transform: capitalize; width: 100%; font-family: 'Segoe UI'; text-align: center; font-size: 24px; font-weight: 600; padding: 5px 0px 5px 0px; margin: -20px 0px 5px 0px; float: left;">
                                    <asp:Label ID="lblDivName" runat="server"></asp:Label></h3>
                                <div style="clear: both;"></div>
                                <p style="font-size: 14px; font-weight: normal; color: #000; line-height: 18px; width: 100%; float: left; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 0px; text-align: center;">
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label><br>
                                    <asp:Label ID="lblphonefax" runat="server"></asp:Label>
                                </p>
                            </th>
                        </thead>
                    </table>
                </div>
            </div>

            <div style="float: left; width: 1024px; border-bottom: 0px solid #000;">
                <div style="float: left; width: 600px; margin: 5px 0px 5px 10px; padding: 0px 0px 0px 0px;">
                    <div style="float: left; width: 150px; font-weight: bold;">
                        <label>To</label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 550px; margin: 5px 5px 5px 0px; padding: 0px 0px 0px 0px;">
                        <p style="margin: 0px 5px 20px 0px; padding: 2px 2px 2px 0px;">
                            <asp:Label ID="lblshipper" runat="server"></asp:Label>
                        </p>
                        <p style="margin: 5px 5px 5px 0px; padding: 2px 2px 2px 0px;  white-space:pre; text-align:left;">
                            <asp:Label ID="lblshipaddress" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div style="float: right; width: 200px; margin: 5px 5px 5px 0px; padding: 0px 0px 0px 0px;">
                    <div style="float: left; width: 89px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: left; font-weight: bold;">Quotation # </div>
                    <div style="float: left; width: 2px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: right;">:</div>
                    <div style="float: left; width: 85px; margin: 2px 2px 2px 0px; text-align: left; padding: 2px 2px 2px 6px;">
                        <asp:Label ID="lblQuoteno" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 89px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: left; font-weight: bold;">Date </div>
                    <div style="float: left; width: 2px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: right;">:</div>
                    <div style="float: left; width: 85px; margin: 2px 2px 2px 0px; text-align: left; padding: 2px 2px 2px 6px;">
                        <asp:Label ID="lblQuoteDate" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 89px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: left; font-weight: bold;">Valid Till </div>
                    <div style="float: left; width: 2px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: right;">:</div>
                    <div style="float: left; width: 85px; margin: 2px 2px 2px 0px; text-align: left; padding: 2px 2px 2px 6px;">
                        <asp:Label ID="lblValidTill" runat="server"></asp:Label>
                    </div>
                </div>
                <div style="float: left; width: 1000px; margin: 5px 0px 5px 10px; padding: 0px 0px 0px 0px;">
                    <p style="padding: 0px; margin: 0px;">
                        Thank you very much for your inquiry and we are pleased to offer our rates & service as per your requirement from <span style="font-weight: bold;">
                            <asp:Label ID="lblPOL" runat="server"></asp:Label></span> to <span style="font-weight: bold;">
                                <asp:Label ID="lblFD" runat="server"></asp:Label></span>
                    </p>
                </div>
            </div>

            <div style="width: 1024px; float: left; border-bottom: 0px solid #000; padding-bottom: 10px;">
                <div style="width: 900px; float: left;">
                    <div style="float: left; width: 129px; margin: 5px 5px 5px 10px; font-weight: bold;">Commodity</div>
                    <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                    <div style="float: left; width: 440px; margin: 5px 5px 5px 10px;">
                        <asp:Label ID="lblCargo" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 129px; margin: 5px 5px 5px 10px; font-weight: bold;">Cargo Descriptoin</div>
                    <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                    <div style="float: left; width: 440px; margin: 5px 5px 5px 10px;">
                        <asp:Label ID="lblCargoDesc" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 129px; margin: 5px 5px 5px 10px; font-weight: bold;">Shipment</div>
                    <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                    <div style="float: left; width: 440px; margin: 5px 5px 5px 10px; font-weight: normal;">
                        <asp:Label ID="lblShipment" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 129px; margin: 5px 5px 5px 10px; font-weight: bold;">Freight</div>
                    <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                    <div style="float: left; width: 440px; margin: 5px 5px 5px 10px; font-weight: normal;">
                        <asp:Label ID="lblfreight" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 129px; margin: 5px 5px 5px 10px; font-weight: bold;">Remarks</div>
                    <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                    <div style="float: left; width: 440px; margin: 5px 5px 5px 10px; font-weight: normal;">
                        <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div style="width: 1024px; float: left; border-bottom: 0px solid #000; border-left: 0px solid #000; border-right: 0px solid #000;">
            <div style="float: left; width: 150px; margin: 5px 10px 5px 0px; padding: 0px 0px 0px 0px; font-weight: bold;">Sell Rate Details</div>
            <div style="float: left; width: 800px; margin: 5px 0px 5px 10px; padding: 0px 0px 0px 0px;"></div>
        </div>


        <div style="width: 1024px; float: left; border-bottom: 0px solid #000; border-right: 0px solid #000; border-left: 0px solid #000">
            <table width="1024" border="0" cellspacing="0" cellpadding="0" style="margin: 0px 0px 10px 0px; border-top:1px solid #000; border-bottom: 1px solid #000; float: left;">
                <tr>
                    <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Charge Name</th>
                    <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Curr</th>
                    <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Rate</th>
                    <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 0px solid #000; border-bottom: 1px solid #000;">Base</th>

                </tr>
                <asp:Label ID="tdRow_QuotDtls" runat="server"></asp:Label>
            </table>

            <div style="float: left; width: 1024px; margin: 10px 0px 30px 5px;">Taxes As Applicable</div>
            <div style="float: left; width: 1024px; margin: 10px 0px 20px 5px;">I am sure that you will  find our  offer  attractive and  await your Confirmation</div>
            <div style="float: left; width: 1024px; margin: 0px 0px 70px 5px; font-weight:bold;">Best Regards</div>
            <div style="float: left; width: 1024px; margin: 0px 0px 10px 5px;">
                <asp:Label ID="lblMarketedBy" runat="server"></asp:Label>
            </div>
        </div>
        <div style="clear: both;"></div>
    </div>
    <div style="clear: both;"></div>

</body>
</html>
