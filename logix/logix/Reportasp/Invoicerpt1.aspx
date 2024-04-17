<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoicerpt1.aspx.cs" Inherits="logix.Reportasp.Invoicerpt1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/systemreport.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .div_cont_class{
            
        }
        span#lstcon {
            text-align: left !important;
            float: left !important;
        }

        .TblGridReport td {
            padding: 2px 2px 2px 2px;
        }


        #tr_cont h3 {
            padding: 0px 0px 0px 0px;
            margin: 0px;
            color: #184684;
        }

        .MINHeight {
            /*min-height: 150px;*/
        }

        .MINHeight1 {
            min-height: 250px;
        }

        #div_bank {
            width: 554.04px;
            float: left;
            margin: 0px 10px 0px 0px;
        }

        #div_fiinvoice {
            /*width: 455.96px;
            float: left;
            margin: 0px 0px 0px 0px;
            padding: 40px 0px 10px 0px;*/
            /*background-color:#a8a8a8;*/
            /*min-height: 104px;
            line-height: 24px;*/
        }

        .div_cont1 {
            float: left;
            width: 99.9%;
            height: 175px;
            margin: 0px 0px 0px 0px;
            padding: 10px 0px 10px 0px;
            background-color: #d0d0d0;
            border: 1px solid #b1b1b1;
        }

        .div_cont_overide {
            float: left;
            width: 99.9%;
            height: 100%;
            margin: 0px 0px 0px 0px;
            padding: 10px 0px 10px 0px;
            background-color: #d0d0d0;
            border: 1px solid #b1b1b1;
        }

        .TblGridReport td:last-child {
            border-right: 0px solid #cdbcb1;
        }

        div#div_cnopshead {
            text-align: center;
            color: #ffffff;
        }

        div#div_invoicehead {
            text-align: center;
            color: #ffffff;
        }

        #div_e_oe h3 {
            padding: 10px 0px 10px 22px;
            margin: 0px 0px 0px 0px;
        }

        .UNAPPROVED {
            margin-top: 10px;
            text-align: center;
        }
        .auto-style1 {
            height: 17px;
        }
        .auto-style2 {
            float: right;
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Wrapper" style="width: 100%; margin: 0px auto;">
            <div style="width: 1024px; margin: 0px auto;">

                <div style="float: left; background-color: #878788">
                    <div style="width: 135px; float: left; margin: 16px 0px 0px 20px;">
                        <asp:Image  ID="lbl_img" runat="server" Width="63" Height="72" />
                        <%--Width="116" Height="32"--%>
                    </div>
                    <div style="float:left; width:735px; margin:5px 0px 0px 0px;">
                        <h3 style="font-family: Segoe UI; font-size: 30px; font-weight: normal; color: #ffffff; text-align: center; padding: 0px 0px 5px 0px; margin: 0px 0px 0px -75px;">
                            <asp:Label ID="lbl_branch" runat="server"></asp:Label>.</h3>

                        <div style="text-align: center; color: #fff;">
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                            Phone # :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>
                            Fax # :<asp:Label ID="lbl_fax" runat="server"></asp:Label>;
                        </div>
                        <div id="div_invoicehead" runat="server" visible="true" style="padding: 0px 0px 10px 0px;">
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
                    <div style="float: right; width: 50px; margin: 10px 10px 0px 0px; text-align: right; color: #ffffff; font-size: 10px; font-family: sans-serif;" >
                        <asp:Label ID="lbl_page" Width="100%" runat="server" Text="" />
                    </div>
                    <div style="float:left; width:1024px; background-color:#184684; margin:0px 0px 0px 0px; border-bottom:1px solid #c2bebe;">
                        <h3 style="font-family:'Segoe UI'; float:left; font-size:24px;text-align:left; color:#ffffff; text-transform:uppercase; width:72%; font-weight:normal; padding:0px; margin:0px 0px 0px 18px;">
                            <asp:Label ID="lbl_head" runat="server">PROFORMA INVOICE</asp:Label></h3>
                        <div style="float:right; width:22%; text-transform:uppercase; color:#fff; font-size:15px; font-family:sans-serif; padding:7px 10px 5px 0px;"><asp:Label ID="LBL_Original" runat="server">Original for the Recipient</asp:Label></div>
                    </div>
                </div>
                <div style="float:left; width:1024px;">
                <div style="float: left; width: 566px; border-right: 1px solid #ffffff; min-height:283px;">

                    <div style="background-color: #d0d0d0; width: 566px; float: left; min-height: 140px; border-top: 1px solid #ffffff; color: #000000;">
                        <div style="float: left; width: 566px; min-height: 115px;">
                            <div style="font-size: 14px; color: #2c2b2b; width: 90%; float: left; padding: 5px 0px 5px 20px; font-weight: bold;">
                               <label style="color: #000000;" id="label_bill" runat="server">Bill To</label> 
                            </div>
                            <div style="font-size: 14px; color: #2c2b2b; width: 98%; float: left;">
                                <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                                    <asp:Label ID="lbl_toaddress" runat="server"></asp:Label>


                                </p>
                            </div>
                        </div>
                        <div style="width: 566px; float: left; border-top: 1px solid #b1b1b1;">
                            <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                            <div style="float: left; width: 149px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_gst" runat="server"></div>
                            <div style="float: left; width: 46px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                            <div style="float: left; width: 175px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="gst_state" runat="server"></div>
                            <div style="float: left; width: 40px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                            <div style="float: left; width: 36px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="gst_code" runat="server"></div>
                        </div>
                    </div>

                    <div style="background-color: #d0d0d0; width: 566px; float: left; min-height: 117px; border-top: 1px solid #ffffff; color: #000000;">
                        <div style="float: left; width: 566px; min-height: 117px;">
                            <div style="font-size: 14px; color: #2c2b2b; width: 90%; float: left; padding: 6px 0px 3px 20px; font-weight: bold;">
                               <label style="color: #000000;" id="label_supply" runat="server">Supply To</label> 
                            </div>
                            <div style="font-size: 14px; color: #2c2b2b; width: 98%; float: left;">
                                <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                                    <asp:Label ID="lbl_tosupply" runat="server"></asp:Label>


                                </p>
                            </div>
                        </div>
                        <div style="width: 566px; float: left; border-top: 1px solid #b1b1b1; min-height:23px;">
                            <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                            <div style="float: left; width: 149px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplygst" runat="server"></div>
                            <div style="float: left; width: 46px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                            <div style="float: left; width: 175px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplystate" runat="server"></div>
                            <div style="float: left; width: 40px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                            <div style="float: left; width: 36px; margin: 5px 0px 0px 10px; padding: 0px 0px 0px 0px;" id="div_supplycode" runat="server"></div>
                        </div>
                    </div>




                </div>

                <div style="width: 456px; float: left;">

                    <div style="background-color: #d0d0d0; width: 457px; float: left; min-height: 272px; padding: 10px 0px 0px 0px; border-top: 1px solid #ffffff;">
                        <div style="float:left; width:100%; min-height:222px;">
                        <div style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px; padding: 0px 0px 0px 20px; font-weight: bold;">
                            <label id="label_invoice" style="color: #000000;" runat="server">Invoice</label>
                        </div>
                        <div style="width: 260px; float: left; color: #000000; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_invoice" runat="server"></asp:Label></span>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="width: 165px; float: left; display: inline-block; margin: 0px 0px 2px 20px; color: #000000; padding: 0px 0px 0px 0px; font-weight: bold;">
                            <label>Date</label>
                        </div>
                        <div style="width: 260px; float: left; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_date" runat="server"></asp:Label></span>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_job" runat="server">
                        <div style="width: 165px; float: left; display: inline-block; margin: 0px 0px 2px 20px; color: #000000; font-weight: bold;">
                            <label id="lbl_job" runat="server">Our Job #</label>
                        </div>

                        <div style="width: 260px; float: left; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_ourjob" runat="server"></asp:Label></span>
                        </div></div>
                        <div style="clear: both;"></div>
                        <div style="width: 165px; float: left; display: inline-block; margin: 0px 0px 2px 20px; color: #000000; font-weight: bold;" id="div_vessel" runat="server">
                            <label id="label_vessel" runat="server">Vessel </label>
                        </div>
                        <div style="width: 260px; float: left; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_vessel" runat="server"></asp:Label></span>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_bl" runat="server" visible="true">
                            <label id="lbl_blname" runat="server" visible="true" style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">BL #</label>


                            <asp:Label ID="lbl_bl" runat="server" Visible="true" Style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_mbl" runat="server" visible="true">
                            <label id="lbl_mblname" runat="server" style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">MBL #</label>


                            <asp:Label ID="lbl_mbl" runat="server" Style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_port" runat="server" visible="true">
                            <label id="lbl_port" runat="server" style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px;color: #000000; font-weight: bold; padding: 0px 0px 0px 20px;">P o D</label>


                            <asp:Label ID="lbl_pod" runat="server" Style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_pack" runat="server" visible="false">
                            <label id="lbl_pack" runat="server" visible="true" style="width: 165px; float: left; display: inline-block; font-weight: bold; margin: 0px 0px 5px 0px;color: #000000; padding: 0px 0px 0px 20px;">Packages</label>


                            <asp:Label ID="lbl_package" runat="server" Visible="true" Style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>

                        <div style="clear: both;"></div>
                        <div id="div_grw" runat="server" visible="true">
                            <label id="lbl_gw" runat="server" visible="true" style="width: 165px; float: left; display: inline-block; font-weight: bold; margin: 0px 0px 5px 0px;color: #000000; padding: 0px 0px 0px 20px;">Gr Wght</label>


                            <asp:Label ID="lbl_grwt" runat="server" Visible="true" Style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                            <div style="clear: both;"></div>
                        </div>

                        <div id="div_volume" runat="server" visible="true">
                            <label id="lable_volume" runat="server" style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">Volume</label>


                            <asp:Label ID="lbl_volume" runat="server" Style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>

                        <div style="clear: both;"></div>
                        <div id="div_ship4cn" runat="server" visible="false">
                            <div style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 0px 0px 0px 20px;color: #000000;">
                                <label id="label_shipment" runat="server">Shipment Destination</label>
                            </div>

                            <div style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_ship" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_vendorref" runat="server" visible="false">
                            <div style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 0px 0px 0px 20px;color: #000000;">
                                <label id="label_vendor" runat="server">Vendor Ref #</label>
                            </div>

                            <div style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_vendor" runat="server"></asp:Label>
                            </div>
                        </div> 
                        <div style="clear: both;"></div>
                        <div id="div_exrate" runat="server" visible="true">
                            <div style="width: 165px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 0px 0px 0px 20px;color: #000000;" >Ex. Rate</div>
                        <div style="width: 260px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                            <asp:Label ID="lbl_exrate" runat="server"></asp:Label>
                        </div>
                        </div>
                        </div>

                         <div style="clear: both;"></div>
                        <div id="FALedger" runat="server" visible="false">
                        <div style="float:left; width:100%; border-bottom:1px solid #fff; height:1px; margin:0px 0px 5px 0px;"></div>
                        <div style="float:left; width:165px; display:inline-block; margin:0px 0px 5px 0px; font-weight:bold; padding:0px 0px 0px 20px; color:#000;">FA Ledger Name</div>
                        <div style="clear:both;"></div>
                        <div style="width:433px; float:left; display:inline-block; margin:0px 0px 7px 0px; font-family:sans-serif; font-weight:normal; font-size:13px; color:#000; padding:0px 0px 0px 20px;"><asp:Label ID="lblLedgername" runat="server"></asp:Label></div>
                            </div>


                    </div>

                </div>
                    </div>
                <div  id="div_ship" runat="server" visible="true" style="background-color: #878788; width: 1024px; float: left; padding: 1px 0px 1px 0px; line-height: 24px;">
                    <div style="float: left; width: 100%">
                        <div id="div_shipper" runat="server" visible="true">
                            <label style="display: inline-block; float: left; width: 90px; margin: 0px 0px 0px 20px; color: #ffffff; font-weight: bold;" id="label_shipper" runat="server">Shipper</label>

                            <div style="float: left; width: 457px;">
                                <asp:Label ID="lbl_shipper" runat="server" Style="display: inline-block; float: left; color: #ffffff; margin: 0px 0px 0px 0px;"></asp:Label>
                            </div>
                        </div>

                        <div style="clear: both;"></div>
                        <div id="div_consignee" runat="server" visible="true" style="margin:0px 0px 0px 17px;">
                            <label style="display: inline-block; float: left; width: 90px; color: #ffffff; font-weight: bold;" id="label_Consignee" runat="server">Consignee</label>

                            <div style="float: left; width: 100%">
                                <asp:Label ID="lbl_consignee" runat="server" Style="color: #ffffff;"></asp:Label>
                            </div>
                        </div>

                    </div>

                    <div style="float: left; width: 450px;" id="div_igm" runat="server" visible="false">
                        <label style="float: left; display: inline-block; width: 150px; font-weight: bold; color: #ffffff;">IGM #</label>

                        <div style="float: left; width: 260px;">
                            <asp:Label ID="lbl_igm" Visible="false" Style="color: #ffffff;" runat="server"></asp:Label>
                        </div>

                        <label style="float: left; display: inline-block; width: 150px; font-weight: bold; color: #ffffff;">Line #</label>

                        <div style="float: left; width: 260px;">
                            <asp:Label ID="lbl_line" Visible="false" Style="color: #ffffff;" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="clear: both;"></div>

                <div style="border: 1px solid #b1b1b1; background-color: #d0d0d0;">
                    <div id="table_invoice" runat="server" visible="true">
                        <table width="1024" border="0" cellspacing="0" cellpadding="0"  style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <th style="background-color: #184684; width: 300px; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" rowspan="2">Charges</th>
                                <th style="background-color: #184684; width: 55px; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" rowspan="2">SAC</th>
                                <th style="background-color: #184684;  color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width:35px;" rowspan="2">Qty</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width:145px;" rowspan="2">Rate</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 100px;" rowspan="2">Taxable Amt<label id="td_tax_basecurr" runat="server">(INR)</label></th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">CGST</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">SGST</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">IGST</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">Amount</th>
                            </tr>
                            <tr>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 16px;">%</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 65px;">Amt</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 16px;">%</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 65px;">Amt</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 16px;">%</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 65px;">Amt</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" id="th_basecurr" runat="server">(INR)</th>
                            </tr>

                            <asp:Label ID="tr_row" runat="server"></asp:Label>

                            <tr style="background-color: #d0d0d0;border-top:1px solid black;"">
                                <td id="tr_roundup" runat="server" visible="true" style="height: 17px;">
                                    <div style="padding: 0px 0px 0px 18px;" id="div_round" runat="server"></div>
                                </td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;border-right:1px solid black;"></td>
                                <td style="float: right;height: 17px;">
                                    <asp:Label ID="lbl_roundup" runat="server" Style="text-align: right;" Visible="true"></asp:Label></td>
                            </tr>
                            <tr style="background-color: #d0d0d0;">
                                <td colspan="4" style="border-top:1px solid black;">
                                    <div style="float: right; width: 62px; padding: 0px 0px 0px 20px;">Total :</div>

                                </td>
                                <td id="td_taxableamt" runat="server" style="border-top:1px solid black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid black;">&nbsp;</td>
                                <td id="td_cgsta" runat="server" style="border-top:1px solid Black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black;">&nbsp;</td>
                                <td id="td_sgsta" runat="server" style="border-top:1px solid Black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black;">&nbsp;</td>
                                <td id="td_igsta" runat="server" style="border-top:1px solid Black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black;" >
                                    <asp:Label ID="lbl_total" runat="server" Style="text-align: right;float:right;"></asp:Label></td>
                            </tr>

                        </table>
                    </div>

                    <div id="table_agent" runat="server" visible="false">
                        <table width="1024" border="0" cellspacing="0" cellpadding="0"  style="width: 100%; border-collapse: collapse;">
                   

                            <tr>
                                <th style="background-color: #184684; width: 300px; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" rowspan="2">Charges</th>
                                <th style="background-color: #184684; width: 55px; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" rowspan="2">SAC</th>
                                <th style="background-color: #184684;  color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width:38px;" rowspan="2">Qty</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width:125px;" rowspan="2">Rate</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 100px;" rowspan="2">Taxable Amt<label id="lbl_taxcurr" runat="server">(USD)</label></th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">CGST</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">SGST</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">IGST</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" colspan="2">Amount</th>
                            </tr>
                            <tr>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 16px;">%</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 65px;">Amt</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 16px;">%</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 65px;">Amt</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 16px;">%</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;width: 65px;">Amt</th>
                                <th style="background-color: #184684; color: #ffffff; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #ffffff;" id="th_curr" runat="server">(USD)</th>
                            </tr>

                            <asp:Label ID="tr_rowagent" runat="server"></asp:Label>

                            <tr style="background-color: #d0d0d0;border-top:1px solid black;"">
                                <td id="tr_roundup_agent" runat="server" visible="true" style="height: 17px;">
                                    <div style="padding: 0px 0px 0px 18px;" id="div1" runat="server"></div>
                                </td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;"></td>
                                <td style="height: 17px;border-right:1px solid black;"></td>
                                <td style="float: right;height: 17px;">
                                    <asp:Label ID="lbl_roundup_agent" runat="server" Style="text-align: right;" Visible="true"></asp:Label></td>
                            </tr>
                            <tr style="background-color: #d0d0d0;">
                                <td colspan="4" style="border-top:1px solid black;">
                                    <div style="float: right; width: 62px; padding: 0px 0px 0px 20px;">Total :</div>

                                </td>
                                <td id="td_taxableamt_agent" runat="server" style="border-top:1px solid black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid black;">&nbsp;</td>
                                <td id="td_cgsta_agent" runat="server" style="border-top:1px solid Black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black;">&nbsp;</td>
                                <td id="td_sgsta_agent" runat="server" style="border-top:1px solid Black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black;">&nbsp;</td>
                                <td id="td_igsta_agent" runat="server" style="border-top:1px solid Black;text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black;" >
                                    <asp:Label ID="total_agent" runat="server" Style="text-align: right;float:right;"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div style="float: left; width: 98.1%; background-color: #d0d0d0; padding: 5px 0px 5px 20px; margin: 0px 0px 0px 0px; font-size: 12px; border-top: 1px solid black;border-bottom: 1px solid black;">
                    <asp:Label ID="lbl_currword" runat="server"></asp:Label>
                </div>



                <div id="div_cont" visible="false" runat="server" style="float: left; width: 99.9%; height: 100%; margin: 0px 0px 0px 0px; padding: 10px 0px 10px 0px; background-color: #d0d0d0; border-left: 1px solid #b1b1b1; border-right: 1px solid #b1b1b1; border-top: 1px solid #b1b1b1;" >

                    <div>
                        <div style="float: left; width: 99%; margin-left: 20px;color: #000000; " id="tr_cont" runat="server" visible="true">

                            <h3>Container Details</h3>

                        </div>

                        <div style="clear: both;"></div>
                        <div style="float: left; width: 99%; margin-left: 1%;" id="tr_contdetail" runat="server" visible="true">


                            <span style="text-align: left; display: inline-block; float: left; padding: 0px 0px 0px 11px;font-family:'Courier New';color: #000000;">
                                <asp:Label ID="lstcon" runat="server"></asp:Label>

                            </span>
                        </div>
                        <div style="clear: both;"></div>
                    </div>

                </div>
                <div style="clear: both;"></div>
                <div id="div_remarks" runat="server" style="float: left; width: 1024px; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; text-align: left; background-color: #d0d0d0;">
                    <label style="display: inline-block; margin: 0px 0px 0px 20px;">Remarks:</label>
                    <asp:Label ID="lbl_remarks" runat="server" Style="display: inline-block; width: 900px;"></asp:Label>
                </div>
                <div style="clear: both;"></div>

                <div id="div_invoice" runat="server" visible="true">
                    <div style="width: 1022px; float: left; background-color: #878788; border-left: 1px solid #cdbcb1; border-right: 1px solid Black;border-top: 1px solid #cdbcb1; border-bottom: 1px solid #cdbcb1;" id="div_banktot" runat="server" visible="true">
                        <div id="div_bank" runat="server" visible="true" style="width: 554px; float: left; margin: 0px 10px 0px 0px;">
                            <h3 style="color: #ffffff; float: left; width: 150px; font-family: sans-serif, Geneva, sans-serif; font-size: 18px; padding: 10px 0px 10px 23px; margin: 0px;">E & O E</h3>
                            <div style="clear: both;"></div>
                                <p style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 22px; color: #ffffff;"><strong>Bank Details :-</strong></p>

                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #ffffff;">Account No.</label>
                                <div style="width: 4px; color: #ffffff; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left; color: #ffffff;">
                                    <asp:Label ID="lbl_accno" runat="server"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #ffffff;">Favouring</label>
                                <div style="width: 4px; color: #ffffff; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left;">
                                    <asp:Label ID="lbl_favouring" runat="server" Style="color: #ffffff;"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #ffffff;">IFSC Code</label>
                                <div style="width: 4px; color: #ffffff; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left;">
                                    <asp:Label ID="lbl_ifsccode" runat="server" Style="color: #ffffff;"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #ffffff;">Bank</label>
                                <div style="width: 4px; color: #ffffff; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left;">
                                    <asp:Label ID="lbl_bankname" runat="server" Style="color: #ffffff;"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="display: block; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 131px; float: left; width: 68%">
                                    <asp:Label ID="lbl_bankaddress" runat="server" Style="color: #ffffff;"></asp:Label></label>
                            
                            
                        </div>

                        <div id="div_between" runat="server" style="float: left; width: 1px; border-left: 1px solid #b1b1b1; height: 188px; margin: 0px 5px 0px 5px;">&nbsp;</div>


                        <div id="div_fiinvoice" runat="server" visible="false" style="width: 443px; float: left; margin: 0px 0px 0px 0px; padding: 54px 0px 10px 0px; min-height: 104px; line-height: 24px;">
                            <p style="color: #ffffff; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Upto15 days: No fine (starting from the devanning date).</p>
                            <p style="color: #ffffff; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Between 15-30 days: Rs.1500/BL + GST as applicable</p>
                            <p style="color: #ffffff; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Between 30-60 days: Rs.2500/BL + GST as applicable</p>
                            <p style="color: #ffffff; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Above 60 days: Rs.5000/BL + GST as applicable</p>
                        </div>
                        <div style="clear: both;"></div>
                            <div style="float:left;padding: 0px 0px 10px 0px;margin:0px 0px 0px 0px; background-color: #d0d0d0;color: #000000;  width:1022px;height:100px;" id="div_authorised" runat="server" visible="true">
                               <p style="margin: 0px 15px 0px 19px; padding: 0px 0px 0px 0px; color: #000000;float:right;"><strong>For </strong><strong><label id="for_comapny" runat="server"></label></strong></p>
                               
                                <div style="clear:both;"></div>
                                
                                <div style="margin: 70px 20px 0px 0px;float:right;"> <strong><label>Authorised Signatory</label></strong></div></div>
                        <div style="clear: both;"></div>

                        <div id="div_bottomsign" runat="server" visible="true">
                            <div style="border-bottom: 1px solid #000000; width: 1022px; margin: 0px 0px 10px 0px; height: 1px; float: left;"></div>
                            <div style="clear: both;"></div>

                            <%--<p style="font-weight: bold; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 20px;">THIS IS A COMPUTER GENERATED DOCUMENT AND HENCE REQUIRES NO SIGNATURE.</p>--%>


                            <p id="para_notBT" runat="server" visible="true" style="font-weight: bold; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 20px;">
                               ANY DISCREPANCY SHOULD BE NOTIFIED TO US IN WRITING WITHIN 7 DAYS FROM THE INVOICE DATE, OTHERWISE IT WILL BE PRESUMED THE AMOUNT REFLECTED ON THE BILL IS CORRECT AND HAVE BEEN VERIFIED AT YOUR END. PAYMENT MUST BE RECEIVED WITHIN THE AGREED CREDIT PERIOD,FAILING WHICH INTEREST @18% PER ANNUM WILL BE CHARGED ON OVERDUE INVOICES. ALL OBJECTIONS/CLAIMS ARE SUBJECT TO CHENNAI JURISDICTION.
                            </p>
                              <p id="p1" runat="server" visible="false" style="font-weight: bold; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 20px;">
                               
                            </p>
                              <p id="p2" runat="server" visible="false" style="font-weight: bold; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 20px;">
                               
                            </p>
                            <%--<p style="text-align: right; color: #cdbcb1; margin: 5px 10px 5px 0px;">
                                <asp:Label ID="lbl_currentdate" runat="server"></asp:Label>
                            </p>--%>
                        </div>
                    </div>
                </div>
                <div style="clear: both;"></div>
                <div id="div_cnops" runat="server" visible="false" style="background-color: #878788; width: 100%; float: left;">
                    <div style="float: left; width: 250px; margin: 20px 0px 0px 20px;" id="div_prepare" runat="server" visible="true">
                        <div style="float: left; width: 250px;">
                            <b>
                                <asp:Label ID="lbl_preparedby" Style="font: bold; color: #ffffff;" runat="server">Prepared By</asp:Label></b>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 250px; margin: 10px 0px 0px 0px;">
                            <asp:Label ID="lbl_prepared" runat="server" Style="color: #ffffff;"></asp:Label>
                        </div>
                    </div>
                    <div style="float: right; width: 250px; margin: 20px 0px 0px 0px;" id="div_approve" runat="server" visible="true">
                        <div style="float: left; width: 250px; text-align: left;">
                            <b>
                                <asp:Label ID="lbl_approvedby" Style="font: bold; color: #ffffff; margin: 0px 5px 0px 0px;" runat="server">Approved By</asp:Label></b>
                        </div>
                        <div style="float: left; width: 250px; margin: 10px 0px 0px 0px; text-align: left;">
                            <asp:Label ID="lbl_approved" runat="server" Style="color: #ffffff; margin: 0px 5px 0px 0px;"></asp:Label>
                        </div>
                    </div>
                    <div style="clear: both;"></div>
                    <div id="div_e_oe" runat="server" visible="false">
                        <div style="float: left; width: 9%;">
                            <h3>E & O E</h3>
                        </div>

                        <div style="float: right; width: 90%; font-weight: bold; margin: 12px 4px 0px 0px; text-align: right;">
                            <label id="label_branch" runat="server" title=""></label>
                        </div>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 650px; margin: -5px 0px 10px 0px; margin-left: 20px;" id="div_sign" runat="server" visible="false">
                        <p style="font-weight: bold;">THIS IS A COMPUTER GENERATED DOCUMENT AND HENCE REQUIRES NO SIGNATURE.</p>
                    </div>
                    <%--<p style="text-align:right; color:#cdbcb1; margin:5px 10px 5px 0px;">
                        <asp:Label ID="lbl_cuurdate" runat="server"></asp:Label>
                    </p>--%>
                </div>
                <div style="clear: both;"></div>
                <div id="div_AEUN" runat="server" visible="false">
                    <div style="text-align:center; margin-top:10px;">
                        <label><b>UNAPPROVED  VOUCHER</b></label>
                    </div>

                    <div style="clear: both;"></div>
                    <div style="float: left; width: 250px; margin: 20px 0px 20px 20px;" visible="true">
                        <div style="float: left; width: 250px;">
                            <b>
                                <asp:Label ID="label_preparedAE" Style="font: bold;" runat="server">Prepared By</asp:Label></b>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 250px; margin: 10px 0px 0px 0px;">
                            <asp:Label ID="lbl_preparedAE" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="clear: both;"></div>
            </div>
        </div>
    </form>
</body>
</html>
