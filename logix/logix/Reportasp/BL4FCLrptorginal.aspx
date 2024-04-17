<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BL4FCLrptorginal.aspx.cs" Inherits="logix.Reportasp.BL4FCLrptorginal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BL Report</title>

    <style type="text/css">
        @font-face {
            font-family: 'Arialic Hollow';
            src: url('font/ArialicHollow.woff2') format('woff2'), url('font/ArialicHollow.woff') format('woff');
            font-weight: normal;
            font-style: normal;
            font-display: swap;
        }


        span#lblDescription {
            white-space: pre-line;
            text-align: left;
            float: left;
            display: inline-block;
            vertical-align: top;
        }
    </style>

</head>



<body style="font-family: sans-serif, Geneva, sans-serif; font-size: 14px; color: #000;">

    <div style="width: 1024px; margin: 0px auto 0px auto;">


        <p style="font-size: 18px; font-weight: bold; margin: 0px; padding: 5px 0px 5px 5px;"></p>
    </div>


    <div style="width: 1024px; margin: 0px auto 0px auto; border: 0px solid #000;">
        <div style="float: left; width: 512px; border-right: 0px solid #000;">

            <div style="float: left; width: 512px; border: 0px solid #000; min-height: 135px; height: 170px">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 0px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 0px 5px 0px 0px; white-space: pre-line; margin: 0px;">
                    <asp:Label ID="lbl_conshipaddress" runat="server"></asp:Label><br />
                </p>
            </div>

            <div style="float: left; width: 512px; border: 0px solid #000; border-top: 0px; border-bottom: 0px; min-height: 135px; height: 170px;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 0px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 0px 5px 0px 0px; white-space: pre-line; margin: 0px;">
                    <asp:Label ID="lbl_conaddress" runat="server"></asp:Label><br />
                </p>
            </div>
            <div style="float: left; width: 512px; border: 0px solid #000; min-height: 136px; height: 175px">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 0px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 0px 5px 25px 0px; white-space: pre-line; margin: 0px;">
                    <asp:Label ID="lbl_notifyaddress" runat="server"></asp:Label><br />
                </p>
            </div>


        </div>
        <div style="float: left; width: 511px;">

            <div style="float: left; width: 511px; border-bottom: 0px solid #000;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 0px 5px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 10px 5px 5px 160px; margin: 0px;">
                    <asp:Label ID="lbl_blno" runat="server"></asp:Label>
                    <br />

                </p>
            </div>
            <div style="float: left; width: 511px; min-height: 276px; border-bottom: 0px solid #000;">
                <div style="float: left; margin: 10px 5px 5px 175px;">
                </div>
                <div style="clear: both;"></div>
                <p style="font-size: 19px; font-weight: bold; text-align: center; padding: 5px 5px 0px 5px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; text-align: center; padding: 5px 5px 0px 5px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; text-align: center; padding: 5px 5px 0px 5px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; text-align: center; padding: 5px 5px 0px 5px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; text-align: center; padding: 5px 5px 0px 5px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; text-align: center; padding: 5px 5px 0px 5px; margin: 0px;"></p>
                <p style="font-size: 19px; font-weight: bold; text-align: center; padding: 5px 5px 5px 5px; margin: 0px;"></p>
            </div>
        </div>
        <div style="float: left; width: 511px; border-bottom: 0px solid #000; min-height: 67px;">
            <div style="float: left; width: 511px;">
                <p style="text-align: left; font-size: 10px; margin: 2px 2px 2px 2px; font-family: arial; font-weight: normal;"></p>
                <p style="font-size: 15px; font-weight: bold; padding: 5px; margin: 0px; display: none;">AGENT DETAILS</p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 10px; margin: 0px; line-height: 18px; display: none;">
                    <br />
                </p>
            </div>

        </div>

        <div style="float: left; width: 1024px; min-height: 45px;">
            <div style="float: left; height: 50px; width: 256px; border-right: 0px solid #000; border-bottom: 0px solid #000;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 45px; margin: 0px;">
                    <asp:Label ID="lbl_precarriage" runat="server"></asp:Label>
                </p>
            </div>

            <div style="float: left; height: 50px; width: 255px; border-right: 0px solid #000; border-bottom: 0px solid #000; min-height: 45px;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 35px; margin: 0px;">
                    <asp:Label ID="lbl_POR" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; height: 50px; width: 248px; border-right: 0px solid #000; border-bottom: 0px solid #000;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 45px; margin: 0px;">
                    <asp:Label ID="lbl_vessel" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; height: 50px; width: 213px; border-bottom: 0px solid #000;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 80px; margin: 0px;">
                    <asp:Label ID="lbl_voy" runat="server"></asp:Label>
                </p>
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 256px; border-right: 0px solid #000; height: 50px;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 0px; margin: 0px;">
                    <asp:Label ID="lbl_POL" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 255px; border-right: 0px solid #000; height: 50px;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 35px; margin: 0px;">
                    <asp:Label ID="lbl_POD" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 248px; border-right: 0px solid #000; height: 50px;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 45px; margin: 0px;">
                    <asp:Label ID="lbl_PODel" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 213px; border-right: 0px solid #000; height: 50px;">
                <p style="font-size: 15px; font-weight: bold; padding: 5px 5px 5px 10px; margin: 0px;"></p>
                <p style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 80px; margin: 0px;">
                    <asp:Label ID="lbl_freightpayat" runat="server"></asp:Label>
                </p>
            </div>

        </div>

        <div style="clear: both;"></div>

        <div style="width: 995px; height: 503px; margin: 45px 0px 0px 45px;">
            <table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding: 0px; font-size: 15px; border-top: 0px solid #000; border-bottom: 0px solid #000;">
                <tr>
                    <th style="font-weight: normal; padding: 5px 0px 5px 0px; font-size: 14px; text-align: center; width: 256px; border-right: 0px solid #000; border-top: 0px solid #000; border-bottom: 0px solid #000;"></th>

                    <th style="font-weight: normal; padding: 5px 0px 5px 0px; font-size: 14px; border-right: 0px solid #000; width: 498px; border-top: 0px solid #000; border-bottom: 0px solid #000;"></th>
                    <th style="font-weight: normal; padding: 5px 0px 5px 0px; font-size: 14px; text-align: center; border-right: 0px solid #000; border-top: 0px solid #000; border-bottom: 0px solid #000;"></th>
                    <th nowrap="nowrap" style="font-weight: normal; padding: 5px 0px 5px 0px; text-align: left; width: 130px; font-size: 14px; border-top: 0px solid #000; border-bottom: 0px solid #000;"></th>

                </tr>
                <tr>
                    <td style="font-weight: bold; padding: 5px; text-align: left; border-right: 0px solid #000;"></td>

                    <td colspan="1" nowrap="nowrap" style="padding: 5px; text-align: center; padding-right: 145px; border-right: 0px solid #000;">

                        <span style="font-weight: bold; width: 140px; float: right; padding: 0px 0px 0px 0px; display: inline-block; text-align: right;"></span>



                        <span style="font-weight: normal; display: inline-block; float: left; padding: 0px 5px 0px 5px; width: 60px; text-align: left;"></span>
                    </td>
                    <td nowrap="nowrap" style="font-weight: bold; padding: 5px 2px 5px 5px; text-align: right; border-right: 0px solid #000;"></td>
                    <td nowrap="nowrap" style="font-weight: bold; padding: 5px 0px 5px 2px; text-align: left; border-right: 0px solid #000;"></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 200px; border-right: 0px solid #000;">

                        <p style="font-weight: normal; padding: 0px 5px 5px 0px; text-align: left; white-space: normal; margin: -15px 0px 0px 0px!important; line-height: 18px;">
                            <asp:Label ID="lbl_marks" runat="server"></asp:Label>
                        </p>

                        <p style="font-weight: normal; padding: 135px 5px 5px 0px; white-space: pre-line; text-align: left; margin: 0px; line-height: 18px; width: 222px; word-break: break-word;">
                            <asp:Label ID="lbl_container" runat="server"></asp:Label>
                        </p>

                    </td>






                    <td style="vertical-align: top; border-right: 0px solid #000;">
                        <p style="font-weight: normal; margin: 0px; padding: 0px 5px 5px 5px; margin: -32px 0px 0px 0px; text-align: left; white-space: pre-line; vertical-align: top; line-height: 18px; height: 350px;">
                            <asp:Label ID="lbl_pkg" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </p>


                    </td>
                    <td valign="top" style="font-weight: normal; padding: 5px; text-align: left; border-right: 0px solid #000;">

                        <p style="font-weight: bold; padding: 15px 5px 5px; text-align: left; white-space: pre;">
                            <asp:Label ID="lbl_shiptype" runat="server"></asp:Label>
                            <br />
                        </p>
                        <p style="font-weight: normal; padding: 5px 0px 0px 40px; margin: -94px 0px 0px 0px; text-align: left; line-height: 18px;">
                            <span style="font-weight: bold; width: 105px; display: block;">Gross Weight</span>
                            <asp:Label ID="lbl_grwt" runat="server"></asp:Label>
                        </p>
                        <p style="font-weight: normal; padding: 5px 0px 0px 40px; text-align: left; line-height: 18px;">
                            <span style="font-weight: bold; width: 95px; display: block;">Net Weight</span>
                            <asp:Label ID="lbl_netwt" runat="server"></asp:Label>
                        </p>

                        <p style="font-weight: normal; padding: 5px 0px 0px 40px; text-align: left; line-height: 18px;">
                            <span style="font-weight: bold; width: 95px; display: block;">CBM </span>
                            <asp:Label ID="lbl_cbm" runat="server"></asp:Label>
                        </p>
                        


                    </td>
                    <td style="font-weight: normal; padding: 15px 5px 5px; text-align: left;display:none">
                      


                    </td>

                </tr>

                <tr>
                    <td style="padding: 5px; margin: 0px; font-weight: bold; font-size: 12px; white-space: nowrap;">
                        <asp:Label ID="lblAnnexcontainer" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
                    <td style="padding: 5px; margin: 0px; font-weight: bold; font-size: 12px;">
                        <asp:Label ID="lblAnnexMarks" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
                    <td style="padding: 5px; margin: 0px; font-weight: bold; font-size: 12px;">
                        <asp:Label ID="lblAnnexDesc" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label></td>
                    <td style="padding: 5px; margin: 0px;">&nbsp;</td>
                    <td style="padding: 5px; margin: 0px;">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <div id="background" style="margin: 0px auto; visibility: hidden; text-align: center; width: 1024px; font-size: 36px; color: rgba(0,0,0,0.2);">
                            <p>
                                <asp:Label ID="lbl_bltype" runat="server" Visible="false"></asp:Label>
                            </p>
                        </div>
                    </td>
                </tr>






            </table>
        </div>
        <div style="width: 1024px; margin: 0px auto; border-bottom: 0px solid #000; border-top: 0px solid #000; border-left: 0px solid #000; border-right: 0px solid #000;">
            <p style="margin: 0px 0px 0px 0px; padding: 5px 0px 5px 0px; text-align: center; font-weight: bold; vertical-align: middle; font-size: 14px;"></p>

        </div>
        <div style="width: 1024px; margin: 0px auto; border-bottom: 0px solid #000; border-top: 0px solid #000; border-left: 0px solid #000; border-right: 0px solid #000;">
            <p style="margin: 0px 0px 0px 0px; padding: 5px 0px 5px 0px; text-align: center; font-weight: bold; vertical-align: middle; font-size: 14px;"></p>

        </div>
        <div style="width: 1024px; float: left; border-top: 0px solid #000;">

            <div style="float: left; width: 512px;">
                <div style="font-size: 15px; font-weight: normal; padding: 1px 5px 1px 10px; margin: 0px; float: left; min-height: 40px; width: 497px; border-bottom: 0px solid #000; display: none;">
                    <br />
                    <p style="font-size: 15px; font-weight: normal; padding: 2px 5px 2px 10px; margin: 0px;">
                        <asp:Label ID="lbl_totcont" runat="server"></asp:Label>
                    </p>


                </div>

                <div style="clear: both;"></div>
                <div style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 10px; border-bottom: 1px solid #000; margin: 0px; float: left; min-height: 40px; width: 512px; display: none;">Cargo Shall not delivered unless freight and charges not paid</div>


                <div style="width: 512px; border-bottom: 0px solid #000; min-height: 50px; display: none;">
                    <div style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 10px; margin: 0px;"></div>
                    <div style="font-size: 15px; font-weight: normal; padding: 5px 5px 5px 10px; margin: 0px;">
                        <asp:Label ID="lbl_freight" runat="server"></asp:Label>
                    </div>
                </div>




                <div style="float: left; width: 512px; border-bottom: 0px solid #000; min-height: 248px;">
                    <div style="font-size: 10px; font-weight: normal; padding: 5px 5px 5px 10px; margin: 0px; float: left; width: 499px; text-align: center;">
                    </div>
                    <div style="font-size: 15px; font-weight: normal; padding: 90px 5px 5px 15px; margin: 0px; float: left; min-height: 60px; width: 400px;">
                        <asp:Label ID="lbl_delicontact" runat="server"></asp:Label>
                    </div>
                </div>


                <div style="font-size: 15px; font-weight: bold; padding: 15px 5px 15px 10px; margin: 0px; float: left; width: 150px; display: none;"></div>
                <div style="font-size: 15px; font-weight: normal; padding: 15px 5px 15px 10px; margin: 0px; float: left; width: 331px; display: none;">
                    <asp:Label ID="lbl_payat" runat="server"></asp:Label>
                </div>
                <div style="font-size: 15px; font-weight: bold; padding: 15px 5px 15px 10px; margin: 50px 0px 0px 0px; float: left; width: 150px; display: none;">Mode of Shipment</div>
                <div style="font-size: 15px; font-weight: bold; padding: 15px 5px 15px 10px; margin: 50px 0px 0px 0px; float: left; width: 331px; display: none;">Shipped on board :</div>
            </div>
            <div style="float: left; width: 510px; border-left: 0px solid #000; min-height: 250px;">
                <div style="width: 510px; float: left; border-bottom: 0px solid #000; min-height: 42px;">

                    <p style="padding: 5px 5px 5px 10px; margin: 0px; font-weight: bold; font-size: 12px; width: 495px; line-height: 18px; text-align: justify;">
                    </p>

                    <p style="font-size: 15px; font-weight: normal; height: 75px; padding: 5px 5px 5px 10px; margin: 0px;">
                        <asp:Label ID="lbl_sonboard" runat="server"></asp:Label>
                    </p>

                </div>




                <div style="width: 510px; float: left; border-bottom: 0px solid #000; min-height: 35px; padding: 15px 0px 0px 0px;">
                    <p style="font-size: 12px; font-weight: BOLD; padding: 1px 5px 1px 10px; margin: 0px; float: left;"></p>
                    <p style="font-size: 12px; font-weight: BOLD; padding: 1px 5px 1px 10px; margin: 0px; float: right;"></p>
                    <p style="font-size: 15px; font-weight: normal; padding: 100px 5px 0px 25px; margin: 0px; float: left; width: 264px;">
                        <asp:Label ID="lbl_placedtofisue" runat="server"></asp:Label>
                    </p>
                    <p style="font-size: 15px; font-weight: normal; padding: 100px 5px 0px 10px; margin: 0px; float: left; text-align: right; width: 180px;">
                        <asp:Label ID="lbl_nooforigi" runat="server"></asp:Label>
                    </p>
                </div>
                <div style="clear: both;"></div>

                <div style="font-size: 12px; font-weight: normal; padding: 0px 15px 5px 10px; text-align: right; margin: 0px; float: left;">
                </div>
                <div style="clear: both;"></div>
                <div style="font-size: 15px; font-weight: bold; width: 510px; padding: 0px 0px 0px 0px; text-align: right; margin: 50px 0px 0px 0px; float: left;">

                    <p style="float: left; font-weight: normal; width: 12px; margin: 10px 0px 0px 10px;"></p>
                    <p style="float: left; font-weight: normal; width: 236px; margin: 23px 0px 0px 6px; border-bottom: 0px solid #000;"></p>
                    <p style="float: left; font-weight: normal; width: 246px; margin: 10px 0px 0px 0px;">
                        <p>
                </div>

            </div>

        </div>

        <div style="clear: both;"></div>
    </div>





</body>
</html>

