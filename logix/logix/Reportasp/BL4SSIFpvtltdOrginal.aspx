<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BL4SSIFpvtltdOrginal.aspx.cs" Inherits="logix.Reportasp.BL4SSIFpvtltdOrginal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BL Original</title>
    <link href="../css/ReportsNew.css" rel="stylesheet" />

    <style type="text/css">
        * {
            border-color: transparent !important;
        }

        .table th {
            visibility: hidden;
        }

        span#lbl_nooforigi {
            position: relative;
            top: -8px;
            left: 20px;
        }

        span#lbl_blno {
            position: relative;
            top: -8px;
        }
        span#lbl_VesVoy, 
        span#lbl_POD, 
        span#lbl_PODel, 
        span#lbl_freightpayat {
    position: relative;
    top: 15px;
}
        table th {
            white-space: nowrap;
        }

        table tr:nth-child(2) {
            display: none;
        }

        table th:first-child,
        table td:first-child {
            display: none;
        }

        table td:nth-child(3) {
            text-align: center;
        }

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

        p.text-bold {
            visibility: hidden;
        }

        .table {
            margin: 50px 0 0;
        }

        div.text-bold {
            visibility: hidden;
        }
    </style>
</head>

<body style="font-family: Tahoma, Geneva, sans-serif; font-size: 14px; color: #000;">

    <div class="container-border">
        <h1 style="visibility: hidden" class="text-bold text-center border-bottom">BILL OF LADING</h1>
        <div class="row">
            <div class="col border-right">
                <div class="h-150 border-bottom pt-1 px-2">
                    <p class="text-bold">Shipper</p>
                    <p class="pt-1">
                        <asp:Label ID="lbl_conshipaddress" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="h-150 border-bottom pt-1 px-2">
                    <p class="text-bold">Consignee</p>
                    <p class="pt-1">
                        <asp:Label ID="lbl_conaddress" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="h-150 border-bottom pt-1 px-2">
                    <p class="text-bold">Notify Party</p>
                    <p class="pt-1">
                        <asp:Label ID="lbl_notifyaddress" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="h-50 row border-bottom">
                    <div class="col border-right pt-1 px-2">
                        <p class="text-bold">Place Of Receipt *</p>
                        <p class="pt-1"></p>
                        <asp:Label ID="lbl_POAccept" runat="server"></asp:Label><%-- receipt--%>
                    </div>
                    <div class="col pt-1 px-2">
                        <p class="text-bold">Port Of Loading</p>
                        <p class="pt-1">
                            <asp:Label ID="lbl_POL" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="h-50 row border-bottom">
                    <div class="col border-right pt-1 px-2">
                        <p class="text-bold">Vessel & Voyage</p>
                        <p class="pt-1"></p>
                        <asp:Label ID="lbl_VesVoy" runat="server"></asp:Label>
                    </div>
                    <div class="col pt-1 px-2">
                        <p class="text-bold">Port Of Discharge</p>
                        <p class="pt-1">
                            <asp:Label ID="lbl_POD" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="h-300 border-bottom">
                    <div class="h-50 row border-bottom">
                        <div class="col border-right pt-1 px-2">
                            <p class="text-bold">B/L No .</p>
                            <p class="pt-1">
                                <asp:Label ID="lbl_blno" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col pt-1 px-2">
                            <p class="text-bold">Number of Originals</p>
                            <p class="pt-1">
                                <asp:Label ID="lbl_nooforigi" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>

                    <div class="mt-3">
                        <img style="display: none" src="../images/Shenzhen_Sealink_Logo.png" width="100%" alt="" />
                        <asp:Label ID="lbl_img" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="h-150 border-bottom pt-1 px-2">
                    <p class="text-bold">Agent At Destination</p>
                    <p class="pt-1"></p>
                    <asp:Label ID="lbl_delicontact" runat="server"></asp:Label>
                </div>
                <div class="h-50 row border-bottom">
                    <div class="pt-1 px-2">
                        <p class="text-bold">Precarriage *</p>
                        <p class="pt-1">
                            <asp:Label ID="lbl_Precarriage" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>

                <div class="h-50 row border-bottom">
                    <div class="col border-right pt-1 px-2">
                        <p class="text-bold">Place Of Delivery *</p>
                        <p class="pt-1">
                            <asp:Label ID="lbl_PODel" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="col pt-1 px-2">
                        <p class="text-bold">Freight Payable At</p>
                        <p class="pt-1">
                            <asp:Label ID="lbl_freightpayat" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="table">
            <table class="w-100">
                <tr>
                    <th style="font-weight: bold; padding: 5px; text-align: left" class="auto-style1">Container No(s).</th>
                    <th style="font-weight: bold; padding: 5px; text-align: left">Marks and Numbers</th>
                    <th style="font-weight: bold; padding: 5px">Number and Kind of Packages / Description of Goods</th>
                    <th style="font-weight: bold; padding: 5px">Gross Weight (KGS)</th>
                    <th style="font-weight: bold; padding: 5px">Measurement (CBM)</th>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold; padding: 5px; text-align: left; font-size: 11px">
                        <asp:Label ID="lblshiploadcount" runat="server" Visible="false"></asp:Label></td>
                    <td style="font-weight: bold; padding: 5px; text-align: center; padding-right: 25px; font-size: 11px"></td>
                    <td nowrap="nowrap" style="font-weight: bold; padding: 5px; text-align: center; font-size: 11px" colspan="2"></td>
                </tr>
                <tr style="height: 250px">
                    <td class="auto-style1" style="vertical-align: top">
                        <p style="font-weight: normal; padding: 5px; line-height: 18px; text-align: left; margin: 0px">
                            Container #/Size/Seal #
                <br />
                            <asp:Label ID="lbl_container" runat="server"></asp:Label>
                        </p>
                    </td>
                    <td style="width: 200px; vertical-align: top">
                        <p style="font-weight: normal; padding: 5px; text-align: left; line-height: 18px; margin: 0px 0px 0px 0px">
                            <asp:Label ID="lbl_marks" runat="server"></asp:Label>
                        </p>
                    </td>
                    <td style="vertical-align: top">
                        <div style="min-height: 445px; vertical-align: top">
                            <p style="font-weight: normal; margin: 0px; padding: 5px; line-height: 18px; vertical-align: top">
                                <asp:Label ID="lbl_pkg" runat="server"></asp:Label>
                            </p>
                            <br />
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </div>
                    </td>
                    <td rowspan="11" valign="top" style="font-weight: normal; padding: 0px; text-align: center; vertical-align: top">
                        <p style="font-weight: normal; line-height: 20px; padding: 5px 5px 5px 0px; margin: 0px; text-align: center; white-space: nowrap">
                            Gross Weight<br />
                            <asp:Label ID="lbl_grwt" runat="server"></asp:Label>
                        </p>

                        <p style="font-weight: normal; text-align: center; white-space: nowrap; line-height: 20px; padding: 5px 5px 5px 0px; margin: 0px">
                            Net Weight
                <br />
                            <asp:Label ID="lbl_netwt" runat="server">50</asp:Label>
                        </p>
                        <br />
                        <p style="font-weight: bold; padding: 5px; text-align: left; white-space: pre; margin-top: 45px">
                            <asp:Label ID="lbl_type" runat="server"></asp:Label><br />
                            <asp:Label ID="lbl_freitype" runat="server"> FCL/FCL</asp:Label><br />
                            <asp:Label ID="lbl_stype" runat="server"> FREIGHT PREPAID</asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: normal; padding: 5px; text-align: left; vertical-align: top">
                        <p style="font-weight: normal; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px; text-align: center; white-space: nowrap">
                            <asp:Label ID="lbl_cbm" runat="server">35</asp:Label>
                        </p>
                    </td>
                </tr>

                <tr>
                    <td style="font-weight: bold; padding: 5px 5px 10px 5px; text-align: left">
                        <p style="font-weight: bold; font-size: 14px; padding: 5px; text-align: left; margin: -150px 0px 0px 0px">
                            <asp:Label ID="lblAnnexcontainer" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: bold; padding: 5px; text-align: center">
                        <p style="font-weight: bold; padding: 5px; font-size: 14px; text-align: left; margin: -150px 0px 0px 0px">
                            <asp:Label ID="lblAnnexMarks" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: bold; padding: 5px; text-align: center">
                        <p style="font-weight: bold; padding: 5px; font-size: 14px; text-align: left; margin: -150px 0px 0px 0px">
                            <asp:Label ID="lblAnnexDesc" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>

                    <!-- <td style="font-weight: bold; padding: 5px; text-align: center">&nbsp;</td>
            <td style="font-weight: bold; padding: 5px; text-align: center">&nbsp;</td>
            -->
                </tr>
            </table>
        </div>
        <div class="w-100">
            <p style="font-size: 22px; font-weight: bold; padding: 5px; margin: 0px; text-align: center"></p>

            <p style="font-size: 13px; font-weight: bold; padding: 0px 2px 2px; margin: 0px; text-align: center; position: relative; top: -30px;">
                <span id="lblFpayableAtDest"></span>
                <br />
                Particulars above furnished by Shipper / Consignor
            </p>
        </div>
        <div class="row border-top">
            <div class="col border-right">
                <div class="row border-bottom">
                    <div class="col-5 text-bold text-center border-right py-1">Freight and Changes</div>
                    <div class="col text-bold text-center border-right py-1">Prepaid</div>
                    <div class="col text-bold text-center py-1">Collect</div>
                </div>
                <div class="row h-200 border-bottom">
                    <div class="col-5 text-bold text-center border-right"></div>
                    <div class="col  text-center border-right">
                        <asp:Label ID="lbl_prepaid" runat="server" />
                    </div>
                    <div class="col  text-center">
                        <asp:Label ID="lbl_Collect" runat="server" />
                    </div>
                </div>
                <p style="text-align: justify; font-size: 12px; padding: 8px; visibility: hidden">*APPLICABLE ONLY WHEN THIS DOCUMENT IS USED AS A COMBINED TRANSPORT BILL OF LADING</p>
            </div>
            <div class="col p-2">
                <p style="text-align: justify; font-size: 11px; visibility: hidden">
                    RECEIVED by the Carrier from the Shipper in apparent good order and condition (unless otherwise noted herein) the total number or quantity of Containers or other packages or units as indicated above for Carriage subject to all the terms and conditions hereof (INCLUDING THE TERMS AND CONDITIONS ON THE RESERVE HEREOF AND THE TERMS AND CONDITIONS OF THE CARRIER'S APPLICABLE TARIFF) from the Place of Receipt or the Port of Loading, whichever is applicable, to the Port of Discharge or the
            Place of Delivery, whichever is applicable.
                </p>
                <p style="text-align: justify; font-size: 11px; visibility: hidden">
                    If this is a negotiable (To Order / of) Bill of Lading, one original Bill of Lading, duly endorsed must be surrendered by the Merchant to the Carrier in exchange for the Goods or a Delivery Order, If this is a non-negotiable (straight) Bill of Lading, the Carrier shall deliver the Goods or issue a Delivery Order against the surrender of one original Bill of Lading. IN WITNESS WHEREOF the Carrier or their Agent has signed the number of Bills of Lading stated at the top, all of this
            tenor and date, and wherever one original Bill of Lading has been surrendered all other Bills of Lading shall be void.
                </p>
                <div class="pt-3 pr-3" style="font-size: 12px">
                    <div class="row mt-3 ml-2">
                        <p style="visibility: hidden">SHIPPED ON BOARD DATE</p>
                        <p class="col" style="border-bottom: 1px dashed #000"></p>
                    </div>
                    <div class="row mt-3 ml-2">
                        <p style="visibility: hidden">PLACE AND DATE OF ISSUE</p>
                        <p class="col" style="border-bottom: 1px dashed #000"></p>
                    </div>
                    <div class="row mt-3 ml-2">
                        <p style="visibility: hidden">AS AGENT FOR THE CARRIER:</p>
                        <p class="col"></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <form id="test" runat="server">
        <asp:HiddenField ID="hid_marks" runat="server" />
        <asp:HiddenField ID="hid_desc" runat="server" />
    </form>
</body>
</html>
