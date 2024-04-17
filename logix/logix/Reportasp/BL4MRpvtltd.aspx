<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BL4MRpvtltd.aspx.cs" Inherits="logix.Reportasp.BL4MRpvtltd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BL Original</title>
    <style type="text/css">
        .Sign img {
            float: right;
            border: 1px solid #000;
            padding: 3px;
            margin: 0px 172px 0px 0px;
        }

        .auto-style1 {
            width: 188px;
        }

        span#lbl_conshipaddress {
            font-size: 14px;
            font-weight: normal;
            white-space: pre-line;
            padding: 0px;
            margin: 0px;
            float: left;
            text-align: left;
            display: inline-block;
        }


        span#lbl_conaddress {
            font-size: 14px;
            font-weight: normal;
            white-space: pre-line;
            padding: 0px;
            margin: 0px;
            float: left;
            text-align: left;
            display: inline-block;
        }

        span#lbl_notifyaddress {
            font-size: 14px;
            font-weight: normal;
            white-space: pre-line;
            padding: 0px;
            margin: 0px;
            float: left;
            text-align: left;
            display: inline-block;
        }

        span#lbl_marks {
            white-space: pre-line;
        }

        span#lbl_container {
            white-space: pre-line;
            display: inline-block;
            float: left;
            text-align: left;
        }

        span#lblDescription {
            white-space: pre-line;
        }

        span#lbl_type {
            margin-left: -82px;
        }

        span#lbl_freitype {
            margin-left: -82px;
        }

        span#lbl_delicontact {
        }

        img#imgsign {
            border: 0px solid #000;
        }

        #imgalign img {
            margin: -5px 0px 3px 0px;
            width: 200px;
            height: 25px;
        }

        span#lbl_stype {
    margin: -16px 0px 0px 31px;
    float: left;
    /* text-align: left; */
}
    </style>
</head>

<body style="font-family: Tahoma, Geneva, sans-serif; font-size: 14px; color: #000;">

    <div style="width: 1024px; margin: 0px auto;">
        <p style="font-size: 19px; font-weight: bold; color: #000000; font-family: Tahoma; float: left; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px;">
            <asp:Label ID="lbl_nonneg" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lbl_draft" runat="server" Visible="false"></asp:Label>

        </p>


        <p style="float: right; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;" id="imgalign" runat="server">
            <img src="../images/barcode.jpg" width="209" height="32" style="display:none"/>
        </p>

    </div>
    <div style="clear: both;"></div>
    <div style="width: 1024px; margin: 0px auto; border-left: 1px solid #000; border-right: 1px solid #000; border-bottom: 1px solid #000; border-top: 1px solid #000;">
        <div style="float: left; width: 512px; border-right: 1px solid #000;">
            <div style="width: 512px; border-bottom: 1px solid #000; min-height: 40px;">
                <p style="font-size: 18px; font-weight: bold; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_MTD" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 512px; border-bottom: 1px solid #000; min-height: 154px;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Consignor / Shipper</p>
                <p style="font-size: 14px; font-weight: normal; white-space: pre-wrap; padding: 0px 5px 0px 5px; margin: 0px;">
                    <asp:Label ID="lbl_conshipaddress" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 512px; border-bottom: 1px solid #000; min-height: 154px;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Consignee (or Order)</p>
                <p style="font-size: 14px; font-weight: normal; white-space: pre-wrap; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_conaddress" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 512px; border-bottom: 1px solid #000; min-height: 154px;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Notify address</p>
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_notifyaddress" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 512px; border-bottom: 1px solid #000; min-height: 52px;">
                <div style="float: left; width: 170px;">
                    <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Place of Acceptance</p>
                    <p style="font-size: 11px; font-weight: normal; padding: 5px; margin: 0px;">
                        <asp:Label ID="lbl_POAccept" runat="server"></asp:Label>
                    </p>
                </div>
                <div style="float: left; width: 170px;">
                    <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Port of Loading</p>
                    <p style="font-size: 11px; font-weight: normal; padding: 5px; margin: 0px;">
                        <asp:Label ID="lbl_POL" runat="server"></asp:Label>
                    </p>
                </div>
                <div style="float: left; width: 170px;">
                    <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Date of Acceptance</p>
                    <p style="font-size: 11px; font-weight: normal; padding: 5px; margin: 0px;">
                        <asp:Label ID="lbl_dtAccept" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
            <div style="float: left; width: 512px; border-bottom: 1px solid #000; min-height: 51px;">
                <div style="float: left; width: 170px;">
                    <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Port of Discharge</p>
                    <p style="font-size: 11px; font-weight: normal; padding: 5px; margin: 0px;">
                        <asp:Label ID="lbl_POD" runat="server"></asp:Label>
                    </p>
                </div>
                <div style="float: left; width: 170px;">
                    <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Place of Delivery</p>
                    <p style="font-size: 11px; font-weight: normal; padding: 5px; margin: 0px;">
                        <asp:Label ID="lbl_PODel" runat="server"></asp:Label>
                    </p>
                </div>
                <div style="float: left; width: 170px;">
                    <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Date of Period of delivery</p>
                    <p style="font-size: 11px; font-weight: normal; padding: 5px; margin: 0px;">
                        <asp:Label ID="lbl_dtdelivery" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
        <div  style="float: left;  width: 511px;" id="div_mtd" runat="server">
            <div style="float: left; width: 511px; border-bottom: 1px solid #000; min-height: 40px;">
                  <p style="font-size: 11px; font-weight: bold; padding: 9px 5px 5px 5px; margin: 0px 0px 0px 10px; text-align: left;float: left;width:295px">
                <asp:Label ID="lblmtd" runat="server" Text="MTD Number"></asp:Label> 
                </p>
                <p style="font-size: 18px; font-weight: normal; padding: 9px 5px 5px 5px; margin: 0px 0px 0px 0px; text-align: left;float: left;">
                    <asp:Label ID="lbl_blno" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 511px; border-bottom: 1px solid #000;" id="div_shipment" runat="server">
                <p style="font-size: 11px; font-weight: bold; padding: 9px 5px 5px 5px; margin: 0px 0px 0px 10px; text-align: left;float: left;width:295px">
                  <asp:Label ID="lblshpmnt" runat="server" Text="Shipment Reference No"></asp:Label>
                </p>
                <p style="font-size: 18px; font-weight: normal; padding: 5px; margin: 0px 0px 0px 0px; text-align: left; min-height: 32px;float: left;">
                    <asp:Label ID="lblshprefno" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 511px; border-bottom: 1px solid #000; min-height: 475px;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 15px 0px 0px 10px; text-align: left;">Agent Ref #:</p>
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_agentrefno" runat="server"></asp:Label>
                </p>

               <%-- <p style="font-size: 36px; font-weight: bold; color: #000000; font-family: Tahoma; margin-left: 180px; margin-top: 159px;">
                </p>--%>
                <div id="divimg" runat="server" width="430px" style="margin:20px auto;display:block">
                    <%--<img src="../images/MR_Logo_details.png" width="430px" style="margin:20px auto;display:block" />--%>
                     <asp:Image  ID="lbl_img" runat="server" width="430px" style="margin:20px auto;display:block;display:none !important"/>
                </div>
            </div>
        </div>
        <div style="float: left; width: 511px; border-bottom: 1px solid #000; min-height: 50px;">
            <div style="float: left; width: 255px;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Modes / means of transport</p>
                <p style="font-size: 11px; font-weight: normal; padding: 2px 5px 2px 5px; margin: 0px;">
                    <asp:Label ID="lbl_transmode" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 255px;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Route / Place of Transhipment (if any)</p>
                <p style="font-size: 11px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_transhipplace" runat="server"></asp:Label>
                </p>
            </div>
        </div>
        <div style="clear: both;"></div>
        <div style="width: 1024px;">
            <table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding: 0px; font-size: 14px; border-top: 0px solid #000; border-bottom: 0px solid #000;">
                <tr>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px; text-align: left;" class="auto-style1">Container No(s).</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">Marks and Numbers</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">Number of packages, kinds of Packages, general description of goods</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">Gross Weight</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">Measurement</th>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold; padding: 5px; text-align: left; font-size: 11px;"><asp:Label ID="lblshiploadcount" runat="server" Visible="false">SHIPPER'S LOAD STOW & COUNT</asp:Label> </td>
                    <td style="font-weight: bold; padding: 5px; text-align: center; padding-right: 25px; font-size: 11px;">SAID TO CONTAIN</td>
                    <td nowrap="nowrap" style="font-weight: bold; padding: 5px; text-align: center; font-size: 11px;" colspan="2">SAID TO WEIGHT / MEASURE</td>
                </tr>
                <tr style="height: 250px;">
                    <td class="auto-style1" style="vertical-align: top;">
                        <p style="font-weight: normal; padding: 5px; line-height: 18px; text-align: left; margin: 0px;">
                            Container #/Size/Seal # 
                            <br />
                            <asp:Label ID="lbl_container" runat="server"></asp:Label>
                        </p>


                    </td>
                    <td style="width: 200px; vertical-align: top;">
                        <p style="font-weight: normal; padding: 5px; text-align: left; line-height: 18px; margin: 0px 0px 0px 25px;">
                            <asp:Label ID="lbl_marks" runat="server"></asp:Label>
                        </p>


                    </td>
                    <td style="vertical-align: top;">
                        <div style="min-height: 445px; vertical-align: top;">
                            <p style="font-weight: normal; margin: 0px; padding: 5px; text-align: left; line-height: 18px; vertical-align: top;">
                                <asp:Label ID="lbl_pkg" runat="server"></asp:Label>
                            </p>
                            <br />
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </div>

                    </td>
                    <td rowspan="11" valign="top" style="font-weight: normal; padding: 0px; text-align: center; vertical-align: top;">
                        <p style="font-weight: normal; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px; text-align: center; white-space: nowrap;">
                            Gross Weight<br />
                            <asp:Label ID="lbl_grwt" runat="server"></asp:Label>
                        </p>



                        <p style="font-weight: normal; text-align: center; white-space: nowrap; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px;">
                            Net Weight
               <br />
                            <asp:Label ID="lbl_netwt" runat="server"></asp:Label>
                        </p>
                        <br />
                        <p style="font-weight: bold; padding: 5px; text-align: left; white-space: pre; margin-top: 45px;">
                            <asp:Label ID="lbl_type" runat="server"></asp:Label><br />
                            <asp:Label ID="lbl_freitype" runat="server"></asp:Label><br />
                            <asp:Label ID="lbl_stype" runat="server"></asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: normal; padding: 5px; text-align: left; vertical-align: top;">

                        <p style="font-weight: normal; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px; text-align: center; white-space: nowrap;">

                            <asp:Label ID="lbl_cbm" runat="server"></asp:Label>
                        </p>

                    </td>
                </tr>
              
                <tr>
                    <td style="font-weight: bold; padding: 5px 5px 10px 5px; text-align: left;">
                        <p style="font-weight: bold; font-size: 14px; padding: 5px; text-align: left; margin: -150px 0px 0px 0px;">
                            <asp:Label ID="lblAnnexcontainer" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: bold; padding: 5px; text-align: center;">
                        <p style="font-weight: bold; padding: 5px; font-size: 14px; text-align: left; margin: -150px 0px 0px 0px;">
                            <asp:Label ID="lblAnnexMarks" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: bold; padding: 5px; text-align: center;">
                        <p style="font-weight: bold; padding: 5px; font-size: 14px; text-align: left; margin: -150px 0px 0px 0px;">
                            <asp:Label ID="lblAnnexDesc" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <%--<td style="font-weight: bold; padding: 5px; text-align: center;">&nbsp;</td>
                    <td style="font-weight: bold; padding: 5px; text-align: center;">&nbsp;</td>--%>

                </tr>

              
            </table>
        </div>
        <div style="width: 1024px; float: left;">
            <p style="font-size: 22px; font-weight: bold; padding: 5px; margin: 0px; text-align: center;">
                 <asp:Label ID="lbl_nonnegEXpress" runat="server" Visible="false"></asp:Label>
            </p>

            <p style="font-size: 11px; font-weight: bold; padding: 0px 2px 2px; margin: 0px; text-align: center;">
                <asp:Label ID="lblFpayableAtDest" runat="server"></asp:Label><br />
                Particulars above furnished by Shipper / Consignor
            </p>
        </div>
        <div style="width: 1024px; float: left;">
            <div style="float: left; width: 170px; border-right: 1px solid #000; border-top: 1px solid #000;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Freight Amount</p>
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_freight" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 341px; border-right: 1px solid #000; border-top: 1px solid #000;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Freight Payable at</p>
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_freightpayat" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 210px; border-right: 1px solid #000; border-top: 1px solid #000;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Number of Original MTD(s)</p>
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_nooforigi" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 300px; border-top: 1px solid #000;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">Place and date of Issue</p>
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_placedtofisue" runat="server"></asp:Label>
                </p>
            </div>
        </div>
        <div style="width: 1024px; float: left;">
            <div style="float: left; width: 512px; border-top: 1px solid #000;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px;">for Delivery Contact :</p>
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;">
                    <asp:Label ID="lbl_delicontact" runat="server"></asp:Label>
                </p>
            </div>
            <div style="float: left; width: 511px; border-top: 1px solid #000; border-left: 1px solid #000;">
                <p style="font-size: 11px; font-weight: bold; padding: 5px; margin: 0px; text-align: left;">
                    for
                    <asp:Label ID="lblBranchname" runat="server"></asp:Label>
                </p>
                
                <p style="font-size: 14px; font-weight: normal; padding: 5px; margin: 0px;height:73px;width:147px;" class="Sign">
                   <%-- <asp:Image ID="imgsign" runat="server" Width="147" Height="73"style="display:none"/>--%>
                </p>
                <div style="clear: both;"></div>
                <p style="font-size: 14px; font-weight: bold; padding: 5px; margin: 0px; text-align: center;">
                    <asp:Label ID="lblSigntype" runat="server"></asp:Label>
                </p>
            </div>
        </div>
        <div style="clear: both;"></div>
    </div>
    <div style="width: 1024px; margin: 0px auto; padding: 3px; text-align: center; font-size: 10px;">TERMS CONTINUED ON BACK HEREOF </div>
    <form id="test" runat="server">
            <asp:HiddenField ID="hid_marks" runat="server" />
        <asp:HiddenField ID="hid_desc" runat="server" />
        </form>
</body>
</html>
