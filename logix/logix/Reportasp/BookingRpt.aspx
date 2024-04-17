<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingRpt.aspx.cs" Inherits="logix.Reportasp.BookingRpt" %>

<!doctype html>
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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="width: 1024px; margin: 0px auto;">
            <div style="float: left; padding: 5px 5px;">
                <asp:Image ID="img_Logo" runat="server" Width="54" Height="54" />
            </div>
            <div style="width: 1024px; float: left; border-top: 0px solid #000; border-bottom: 0px solid #000; border-left: 0px solid #000; border-right: 0px solid #000;">
                <div style="float: left; text-align: center; width: 1024px; border-top: 0px solid #000; border-bottom: 1px solid #000;">
                    <div style="float: right; width: 70px; padding: 0px; margin: 5px 5px 0px 0px; text-align: right; font-size: 11px; display: none;">
                        <asp:Label ID="lblBookingDate" runat="server"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 1024px;">
                        <table width="1024px" cellpadding="0" cellspacing="0" id="TblHead">
                            <thead>
                                <th>
                                    <h3 style="text-transform: capitalize; width: 100%; font-family: 'Segoe UI'; text-align: center; font-size: 24px; font-weight: 600; padding: 5px 0px 5px 0px; margin: 0px 0px 5px 0px; float: left;">
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
                <div style="float: left; width: 1024px;">
                    <div style="float: left; width: 600px; margin: 5px 0px 5px 0px; padding: 0px 0px 0px 0px;">
                        <div style="float: left; width: 150px; font-weight: bold;">
                            <label>Customer </label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 550px; margin: 5px 5px 5px 0px; padding: 0px 0px 0px 0px;">
                            <p style="margin: 0px 5px 20px 0px; padding: 2px 2px 2px 0px;">
                                <asp:Label ID="lblshipper" runat="server"></asp:Label>
                            </p>
                            <p style="margin: 5px 5px 5px 0px; padding: 2px 2px 2px 0px; white-space: pre; text-align: left;">
                                <asp:Label ID="lblshipaddress" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <div style="float: right; width: 160px; margin: 5px 5px 5px 0px; padding: 0px 0px 0px 0px;">

                        <div style="float: left; width: 40px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: left; font-weight: bold;">Date </div>
                        <div style="float: left; width: 2px; margin: 2px 2px 2px 0px; padding: 2px 2px 2px 2px; text-align: right;">:</div>
                        <div style="float: left; width: 90px; margin: 2px 2px 2px 0px; text-align: left; padding: 2px 2px 2px 8px;">
                            <asp:Label ID="lblToday" runat="server"></asp:Label>
                        </div>

                    </div>
                    <div style="float: left; width: 1024px; margin: 5px 0px 5px 0px; padding: 5px 0px 5px 0px; border-top:0px solid #000; border-bottom: 0px solid #000;">
                        <p style="padding: 0px; margin: 0px; text-align: center;"><span style="font-weight: bold;">Booking Confirmation</p>
                    </div>
                </div>

                <div style="width: 1024px; float: left; border-bottom: 0px solid #000; padding-bottom: 10px;">
                    <div style="width: 1024px; float: left;">
                        <p style="font-size: 14px; text-align: left; margin: 5px 0px 5px 0px; padding: 0px;">
                            Booking #  <span style="color: brown; font-weight: bold;">
                                <asp:Label ID="lblShiprefno" runat="server"></asp:Label></span> Dt. <span style="font-weight: bold;">
                                    <asp:Label ID="lblBookDate" runat="server"></asp:Label></span> has been generated for the below quotation.                        
                        </p>
                    </div>
                    <div style="width: 900px; float: left;">
                        <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Quotation #  &  Date</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 9px;">
                            <asp:Label ID="lblQuotenoDate" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Cargo Type </div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 9px;">
                            <asp:Label ID="lblCargo" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Cargo Description</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 9px; font-weight: normal;">
                            <asp:Label ID="lblCargoDesc" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Shipment</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 9px; font-weight: normal;">
                            <asp:Label ID="lblShipment" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Freight</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 9px; font-weight: normal;">
                            <asp:Label ID="lblfreight" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                    <div style="float: left; width: 512px;">
                        <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Place of Receipt</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 9px; font-weight: normal;">
                            <asp:Label ID="lblPOR" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 150px; margin: 5px 5px 5px 0px; font-weight: bold;">Place of Discharge</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 9px; font-weight: normal;">
                            <asp:Label ID="lblPOD" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left; width: 512px;">
                        <div style="float: left; width: 125px; margin: 5px 5px 5px 10px; font-weight: bold;">Port of Loading</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 10px; font-weight: normal;">
                            <asp:Label ID="lblPOL" runat="server"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 125px; margin: 5px 5px 5px 10px; font-weight: bold;">Final Destination</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 10px; font-weight: normal;">
                            <asp:Label ID="lblFD" runat="server"></asp:Label>
                        </div>
                        <div style="float: left; width: 125px; margin: 5px 5px 5px 10px; font-weight: bold;">Free Days</div>
                        <div style="float: left; width: 1px; margin: 5px 5px 5px 0px;">:</div>
                        <div style="float: left; width: 200px; margin: 5px 5px 5px 10px; font-weight: normal;">
                            <asp:Label ID="lbl_freedays" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 1024px; float: left; border-bottom: 0px solid #000; border-left: 0px solid #000; border-right: 0px solid #000;">
                <div style="float: left; width: 150px; margin: 5px 10px 5px 0px; padding: 0px 0px 0px 0px; font-weight: bold;">Sell Rate Details</div>
                <div style="float: left; width: 800px; margin: 5px 0px 5px 10px; padding: 0px 0px 0px 0px;"></div>
            </div>


            <div style="width: 1024px; float: left; border-bottom: 0px solid #000; border-right: 0px solid #000; border-left: 0px solid #000">
                <table width="1024" border="0" cellspacing="0" cellpadding="0" style="margin: 0px 0px 10px 0px; border-top: 1px solid #000; border-bottom: 1px solid #000; border-left:1px solid #000; border-right:1px solid #000; float: left;">
                    <tr>
                        <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 600px;">Charges</th>
                        <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Curr</th>
                        <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Rate</th>
                        
    <th style="padding: 5px 5px 5px 5px; border-left:0px solid #000;width:150px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Ex Rate</th>
    <th style="padding: 5px 5px 5px 5px; border-left:0px solid #000;width:220px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Base</th>
    <th style="padding:5px 5px 5px 5px; border-left:0px solid #000;width:150px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Units</th>
    <th style="padding: 5px 5px 5px 5px; border-left:0px solid #000;width:250px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Amount in FC</th>
    <th style="padding:5px 5px 5px 5px; border-left:0px solid #000;width:250px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Amount in  <asp:Label ID="lblbascurr" runat="server">INR</asp:Label></th>
                        <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 0px solid #000; border-bottom: 1px solid #000;">Status</th>
                    </tr>
                    <asp:Label ID="tdRow_QuotDtls" runat="server"></asp:Label>

                </table>
            </div>


            <div style="width: 1024px; float: left; border-bottom: 0px solid #000; border-left: 0px solid #000; border-right: 0px solid #000;" id="DivBuyRate" runat="server" visible="false">
                <div style="float: left; width: 150px; margin: 5px 10px 5px 0px; padding: 0px 0px 0px 0px; font-weight: bold;">Buying Rate Details</div>
                <div style="float: left; width: 800px; margin: 5px 0px 5px 10px; padding: 0px 0px 0px 0px;"></div>
                <div style="clear: both;"></div>
                <div style="width: 72px; float: left; margin: 15px 5px 5px 0px; font-weight: bold;">Buying ID </div>
                <div style="float: left; width: 1px; font-weight: bold; margin: 15px 10px 5px 5px;">:</div>
                <div style="float: left; width: 402px; margin: 15px 5px 5px 5px;">
                    <asp:Label ID="lblBuyId" runat="server"></asp:Label>
                </div>
                <div style="width: 50px; float: left; margin: 15px 5px 5px 82px; font-weight: bold;">Carrier </div>
                <div style="float: left; width: 1px; font-weight: bold; margin: 15px 10px 5px 10px;">:</div>
                <div style="float: left; width: 325px; margin: 15px 5px 5px 5px;">
                    <asp:Label ID="lblCarrier" runat="server"></asp:Label>
                </div>

                <div style="width: 1024px; float: left; border-bottom: 0px solid #000; border-right: 0px solid #000; border-left: 0px solid #000">
                    <table width="1024" border="0" cellspacing="0" cellpadding="0" style="margin: 0px 0px 10px 0px; border-top: 1px solid #000; border-bottom: 1px solid #000; border-left:1px solid #000; border-right:1px solid #000; float: left;">
                        <tr>
                            <th style="padding: 5px 5px 5px 10px; margin: 5px 5px 5px 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000; width: 600px;">Charges</th>
                            <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Curr</th>
                            <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 1px solid #000; border-bottom: 1px solid #000;">Rate</th>
<th style="padding: 5px 5px 5px 5px; border-left:0px solid #000;width:150px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Ex Rate</th>
    <th style="padding: 5px 5px 5px 5px; border-left:0px solid #000;width:220px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Base</th>
    <th style="padding:5px 5px 5px 5px; border-left:0px solid #000;width:150px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Units</th>
    <th style="padding: 5px 5px 5px 5px; border-left:0px solid #000;width:250px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Amount in FC</th>
    <th style="padding:5px 5px 5px 5px; border-left:0px solid #000;width:250px;border-top:0px solid #000;height: 0px;border-bottom:1px solid #000;border-right:1px solid #000;text-align:right;">Amount in  <asp:Label ID="Label1" runat="server">INR</asp:Label></th>
                        <th style="padding: 5px 5px 5px 5px; margin: 5px; text-align: center; border-right: 0px solid #000; border-bottom: 1px solid #000;">Status</th>                        </tr>
                        <asp:Label ID="tdRow_BuyDtls" runat="server"></asp:Label>
                    </table>

                </div>

            </div>
             <div style="width: 1024px; float: left; border-bottom: 0px solid #000; border-right: 0px solid #000; border-left: 0px solid #000">
            <div style="float: left; width: 1024px; margin: 10px 0px 30px 0px;">
                <div style="float: left; width: 65px; font-weight: bold; margin: 0px 5px 0px 0px;">Remarks</div>
                <div style="float: left; width: 1px; font-weight: bold; margin: 0px 5px 0px 5px;">:</div>
                <div style="float: left; width: 900px; margin: 0px 0px 0px 5px;">
                    <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                </div>

            </div>
                  
        <div style="float:left;width:99%">
        <div style="width:100%;float:left;min-height:18px;padding: 6px 3px 5px 0;font-weight: bold;font-size: 15px;">
          for <label id="lbl4comname" runat="server"></label>
         </div>
        </div>

        


    </div>


            <div style="float: left; width: 1024px; margin: 80px 0px 10px 10px;">
                <asp:Label ID="lblMarketedBy" runat="server"></asp:Label>
            </div>

                 </div>





            <div style="clear: both;"></div>
        </div>
        <div style="clear: both;"></div>
    </form>
</body>
</html>

