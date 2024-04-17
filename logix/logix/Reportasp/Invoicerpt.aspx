<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoicerpt.aspx.cs" Inherits="logix.Reportasp.Invoicerpt" %>

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
            color: #000;
        }

        .MINHeight {
            /*min-height: 150px;*/
        }

        .MINHeight1 {
            min-height: 250px;
        }

        #div_bank {
            width: 665px;
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
            
            border: 1px solid #b1b1b1;
        }

        .div_cont_overide {
            float: left;
            width: 99.9%;
            height: 100%;
            margin: 0px 0px 0px 0px;
            padding: 10px 0px 10px 0px;
            
            border: 1px solid #b1b1b1;
        }

        .TblGridReport td:last-child {
            border-right: 0px solid #cdbcb1;
        }

        div#div_cnopshead {
            text-align: center;
            color: #000;
        }

        div#div_invoicehead {
            text-align: center;
            color: #000;
        }

        #div_e_oe h3 {
            padding: 10px 0px 10px 22px;
            margin: 0px 0px 0px 0px;
        }

        .UNAPPROVED {
            margin-top: 10px;
            text-align: center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Wrapper" style="width: 100%; margin: 0px auto; ">
         
            <div style="width: 1024px; margin: 0px auto; border:1px solid #000;">

                <div style="float: left;">
                   <div style="float:left; width:150px; margin:9px 10px 5px 15px;">
                         <asp:Image  ID="lbl_img" runat="server" Width="100%"  />
                   </div>
                    <div style="float:left; width:735px; margin:5px 0px 4px 7px;">
                        <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 22px;">
                            <asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<%--                        <p style="margin:2px 0px 2px 0px; padding:0px 0px 0px 0px; font-size:14px; font-family: Segoe UI; text-align:center; ">(Formerly Known as Axelerom International Logistics Private Limited)</p>--%>

                        <div style="text-align: center; color: #000;">
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                            Phone # :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>
                            Fax # :<asp:Label ID="lbl_fax" runat="server"></asp:Label>;
                        </div>
                        <div id="div_invoicehead" runat="server" visible="true" style="padding: 0px 0px 0px 0px;">
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

                    <div style="float: right; width: 50px; margin: 10px 10px 0px 0px; text-align: right; color: #000; font-size: 10px; font-family: sans-serif;" >
                        <asp:Label ID="lbl_page" Width="100%" runat="server" Text="" />
                    </div>
                    <div style="float:left; width:1024px; margin:0px 0px 0px 0px; border-top:1px solid #000;">
                        <h3 style="font-family:'Segoe UI'; float:left; font-size:24px;text-align:left; color:#000; text-transform:uppercase; width:72%; font-weight:normal; padding:0px; margin:0px 0px 0px 18px;">
                            <asp:Label ID="lbl_head" runat="server">PROFORMA INVOICE</asp:Label></h3>
                        <div style="float:right; width:22%; text-transform:uppercase; color:#000; font-size:15px; font-family:sans-serif; padding:7px 10px 5px 0px;"><asp:Label ID="LBL_Original" runat="server">Original for the Recipient</asp:Label></div>
                    </div>
                </div>

                <div id="div_irn" runat="server" style="float: left; width: 1024px; min-height: 15px; border-top: 1px solid #000;color: #000000;" visible="false">
                           <%-- <div style="font-size: 14px; color: #000; width: 6%; float: left; padding: 5px 0px 5px 20px; font-weight: bold;">
                               <label style="color: #000000;" id="label4" runat="server">IRN # :</label> 
                            </div>
                            <div style="font-size: 14px; color: #2c2b2b; width: 80%; float: left;">
                                <p style="float: left; width: 92%; margin: 5px 0px 0px 10px;">
                                    <asp:Label ID="LblIrnno" runat="server"></asp:Label>


                                </p>
                            </div>--%>
                     <div style="font-size: 14px; color: #000; width: 6%; float: left; padding: 5px 0px 5px 20px; font-weight: bold;">
                               <label style="color: #000000;" id="label4" runat="server">IRN # :</label> 
                            </div>
                            <div style="font-size: 14px; color: #2c2b2b; width: 48%; float: left;">
                                <p style="float: left; width: 92%; margin: 5px 0px 0px 0px;">
                                    <asp:Label ID="LblIrnno" runat="server"></asp:Label>


                                </p>
                            </div>
                          <div style="float: left; width: 44%;  min-height: 15px;">
                          <div style="font-size: 14px; color: #2c2b2b; width: 47%; float: left; padding: 5px 0px 5px 13px; ">
                                <p style="float: left; width: 29%; margin: 0px 0px 0px 0px;font-weight: bold;">
                           <label style="color: #000000;" id="label5" runat="server">ACK # :</label> </p>

                               <p style="float: left; width: 68%; margin: 0px 0px 0px 0px;">
                                    <asp:Label ID="LblAckno" runat="server"></asp:Label></p>

                              </div>
                         <div style="font-size: 14px; color: #2c2b2b; width: 47%; float: left; padding: 5px 0px 5px 13px; ">
                               <p style="float: left; width: 38%; margin: 0px 0px 0px 12px;font-weight: bold;">
                                     <label style="color: #000000;" id="label6" runat="server">ACK Date :</label> </p>
                              <p style="float: left; width: 53%; margin: 0px 0px 0px 0px;">
                                    <asp:Label ID="LblAckdt" runat="server"></asp:Label> </p>
                                  </div>
                    </div>
                        </div>
                <div style="float:left; width:1024px;">
                <div style="float: left; width: 450px; border-right: 1px solid #000; min-height:404px;">

                    <div style="width:450px; float: left; min-height: 140px; border-top: 1px solid #000; color: #000000;">
                        <div style="float: left; width: 400px; min-height: 161px;">
                            <div style="font-size: 14px; color: #000; width: 90%; float: left; padding: 5px 0px 5px 20px; font-weight: bold;">
                               <label style="color: #000000;" id="label_bill" runat="server">Bill To</label> 
                            </div>
                            <div style="font-size: 14px; color: #000; width: 98%; float: left;">
                                <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                                    <asp:Label ID="lbl_toaddress" runat="server"></asp:Label>


                                </p>
                            </div>
                        </div>
                        <div style="width: 450px; float: left; border-top: 1px solid #000;">
                            <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                            <div style="float: left; width: 130px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="div_gst" runat="server"></div>
                            <div style="float: left; width: 46px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                            <div style="float: left; width: 105px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="gst_state" runat="server"></div>
                            <div style="float: left; width: 40px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                            <div style="float: left; width: 30px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="gst_code" runat="server"></div>
                        </div>
                    </div>

                    <div style="width: 450px; float: left; min-height: 117px; border-top: 1px solid #000; color: #000000;">
                        <div style="float: left; width: 400px; min-height: 170px;">
                            <div style="font-size: 14px; color: #000; width: 90%; float: left; padding: 6px 0px 3px 20px; font-weight: bold;">
                               <label style="color: #000000;" id="label_supply" runat="server">Supply To</label> 
                            </div>
                            <div style="font-size: 14px; color: #000; width: 98%; float: left;">
                                <p style="float: left; width: 98%; margin: 0px 0px 0px 22px;">
                                    <asp:Label ID="lbl_tosupply" runat="server"></asp:Label>


                                </p>
                            </div>
                        </div>
                        <div style="width: 450px; float: left; border-top: 1px solid #000; min-height:45px;">
                            <div style="float: left; width: 45px; margin: 5px 0px 0px 20px; padding: 0px 0px 0px 0px; font-weight: bold;">GST #</div>
                            <div style="float: left; width: 130px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="div_supplygst" runat="server"></div>
                            <div style="float: left; width: 46px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">State</div>
                            <div style="float: left; width: 105px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="div_supplystate" runat="server"></div>
                            <div style="float: left; width: 40px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px; font-weight: bold;">Code</div>
                            <div style="float: left; width: 30px; margin: 5px 0px 0px 5px; padding: 0px 0px 0px 0px;" id="div_supplycode" runat="server"></div>
                        </div>
                    </div>




                </div>

                <div style="width: 573px; float: left;border-top: 1px solid #000;">

                    <div style="width: 373px; float: left; min-height: 345px; padding: 10px 0px 0px 0px; ">
                        <div style="float:left; width:100%; min-height:345px;">
                            <div style="min-height:250px;">
                        <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 2px 0px; padding: 0px 0px 0px 20px; font-weight: bold;">
                            <label id="label_invoice" style="color: #000000;" runat="server">Invoice</label>
                        </div>
                        <div style="width: 225px; float: left; color: #000000; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_invoice" runat="server"></asp:Label></span>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 2px 20px; color: #000000; padding: 0px 0px 0px 0px; font-weight: bold;">
                            <label>Date</label>
                        </div>


                        <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_date" runat="server"></asp:Label></span>
                        </div>

                               <div style="clear: both;"></div>
                           <div id="div_date1" runat="server" visible="true" style="float:left;">
                        <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 2px 20px; color: #000000; padding: 0px 0px 0px 0px; font-weight: bold;">
                            <label>Due Date</label>
                        </div>


                        <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_date1" runat="server"></asp:Label></span>
                        </div>
                               <div style="clear: both;"></div>
                           </div>

                        <div style="clear: both;"></div>
                        <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 2px 20px; color: #000000; font-weight: bold;">
                            <label id="lbl_job" runat="server">Our Job #</label>
                        </div>

                        <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_ourjob" runat="server"></asp:Label></span>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 2px 20px; color: #000000; font-weight: bold;">
                            <label id="label_vessel" runat="server">Vessel </label>
                        </div>
                        <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 2px 0px;">
                            <span>
                                <asp:Label ID="lbl_vessel" runat="server"></asp:Label></span>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_bl" runat="server" visible="true">
                            <label id="lbl_blname" runat="server" visible="true" style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">BL #</label>


                            <asp:Label ID="lbl_bl" runat="server" Visible="true" Style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>
                                 <div id="div3" runat="server" visible="false">
                            <label id="Label2" runat="server" visible="true" style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">Booking #</label>


                            <asp:Label ID="Label3" runat="server" Visible="true" Style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                        <div id="div_mbl" runat="server" visible="true">
                            <label id="lbl_mblname" runat="server" style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">MBL #</label>


                            <asp:Label ID="lbl_mbl" runat="server" Style="width: 238px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>

                         <div style="clear: both;"></div>
                        <div id="div_OBL" runat="server" visible="true">
                            <label id="lbl_oblname" runat="server" style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">OBL</label>


                            <asp:Label ID="lbl_obl" runat="server" Style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>

                        <div style="clear: both;"></div>
                        <div id="div_port" runat="server" visible="true">
                            <label id="lbl_port" runat="server" style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px;color: #000000; font-weight: bold; padding: 0px 0px 0px 20px;">P O R / P O D</label>


                            <asp:Label ID="lbl_pod" runat="server" Style="width: 225px; float: left; display: inline-block;white-space:nowrap; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>


                         <div style="clear: both;"></div>
                        <div id="div_port1" runat="server" visible="true">
                            <label id="lbl_port1" runat="server" style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px;color: #000000; font-weight: bold; padding: 0px 0px 0px 20px;">P O L / F D</label>


                            <asp:Label ID="lbl_pod1" runat="server" Style="width: 225px; float: left; display: inline-block;white-space:nowrap; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>



                        <div style="clear: both;"></div>



                        <div id="div_pack" runat="server" visible="false">
                            <label id="lbl_pack" runat="server" visible="true" style="width:115px; float: left;display:inline-block; font-weight: bold; margin: 0px 0px 5px 0px;color: #000000; padding: 0px 0px 0px 20px;">Packages</label>


                            <asp:Label ID="lbl_package" runat="server" Visible="true" Style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>

                        <div style="clear: both;"></div>
                        <div id="div_grw" runat="server" visible="true">
                            <label id="lbl_gw" runat="server" visible="true" style="width:115px; float: left;display: inline-block; font-weight: bold; margin: 0px 0px 5px 0px;color: #000000; padding: 0px 0px 0px 20px;">Gr Wght</label>


                            <asp:Label ID="lbl_grwt" runat="server" Visible="true" Style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                            <div style="clear: both;"></div>
                        </div>

                        <div id="div_volume" runat="server" visible="true">
                            <label id="lable_volume" runat="server" style="width:115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold;color: #000000; padding: 0px 0px 0px 20px;">Volume</label>


                            <asp:Label ID="lbl_volume" runat="server" Style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"></asp:Label>
                        </div>

                        <div style="clear: both;"></div>
                        <div id="div_ship4cn" runat="server" visible="false">
                            <div style="width:115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 0px 0px 0px 20px;color: #000000;">
                                <label id="label_shipment" runat="server">Shipment Destination</label>
                            </div>

                            <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_ship" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                         <div id="div_vendorref" runat="server" visible="false">
                            <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 0px 0px 0px 20px;color: #000000;">
                                <label id="label_vendor" runat="server">Vendor Ref #</label>
                            </div>

                            <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_vendor" runat="server"></asp:Label>
                            </div>
                        </div> 
                         <div style="clear: both;"></div>
                          <div id="div_vendorrefdate" runat="server" visible="false">
                            <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 0px 0px 0px 20px;color: #000000;">
                                <label id="label1" runat="server">Vendor Ref Date</label>
                            </div>

                            <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_vendordate" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                        <div  id="div_exrate" runat="server" visible="false">
                            <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 0px 0px 0px 20px;color: #000000;">Ex. Rate</div>
                        <div style="width: 225px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                            <asp:Label ID="lbl_exrate" runat="server"></asp:Label>
                        </div>
                        </div>
                        <div style="clear: both;"></div>
                      
                        </div>
                         <div style="clear: both;"></div>
                        <div id="FALedger" runat="server" visible="false" style="float:left; width:100%; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px; display:none; " > <%-- style="min-height:52px; display:none;"--%>
                        <div style="float:left; width:100%; border-bottom:1px solid #000; height:1px; margin:0px 0px 5px 0px;"></div>
                        <div style="float:left; width:165px; display:inline-block; margin:0px 0px 5px 0px; font-weight:bold; padding:0px 0px 0px 20px; color:#000;">FA Ledger Name</div>
                        <div style="clear:both;"></div>
                        <div style="width:433px; float:left; display:inline-block; margin:0px 0px 7px 0px; font-family:sans-serif; font-weight:normal; font-size:13px; color:#000; padding:0px 0px 0px 20px;"><asp:Label ID="lblLedgername" runat="server"></asp:Label></div>
                            </div>



                    </div>

                </div>


                            <div id="div_image1" runat="server"  style="float: left; width: 196px;  margin: 0px 0px 0px 0px; min-height:345px;" class="logoimg" visible="false" >
              <asp:Image ID="ImgLogo" runat="server"  ToolTip="IMAGE"  placeholder="IMAGE"   Height="221px" Width="200px"  />  
            </div>

                     <div  id="div2" runat="server" visible="true" style="border-top:1px solid #000;float:left;width:100.6%; margin:0px 0px 5px 0px;">
                            <div style="width: 115px; float: left; display: inline-block; margin: 0px 0px 5px 0px; font-weight: bold; padding: 5px 0px 0px 20px;color: #000000;">Place of Supply</div>
                        <div style="width: 225px; float: left; display: inline-block; margin: 5px 0px 5px 0px;">
                            <asp:Label ID="lbl_pos" runat="server"></asp:Label>
                        </div>
                        </div>
                    </div>
                <div  id="div_ship" runat="server" visible="true" style="width: 1024px; float: left; padding: 1px 0px 1px 0px; border-top:1px solid #000; line-height: 24px;">
                    <div style="float: left; width: 566px; border-right:1px solid #000; margin-top:-1px;">
                        <div id="div_shipper" runat="server" visible="true">
                            <label style="display: inline-block; float: left; width: 90px; margin: 0px 0px 0px 20px; color: #000; font-weight: bold;" id="label_shipper" runat="server">Shipper</label>

                            <div style="float: left; width: 420px;">
                                <asp:Label ID="lbl_shipper" runat="server" Style="display: inline-block; float: left; color: #000; margin: 0px 0px 0px 0px;"></asp:Label>
                            </div>
                        </div>

                        <div style="clear: both;"></div>
                        <div id="div_consignee" runat="server" visible="true" style="margin:0px 0px 0px 17px;">
                            <label style="display: inline-block; float: left; width: 90px; color: #000; font-weight: bold;" id="label_Consignee" runat="server">Consignee</label>

                            <div style="float: left; width: 457px;">
                                <asp:Label ID="lbl_consignee" runat="server" Style="color: #000;"></asp:Label>
                            </div>
                        </div>

                    </div>

                    <div style="float: left; width: 450px;" id="div_igm" runat="server" visible="false">
                        <label style="float: left; display: inline-block; width: 150px; font-weight: bold; color: #000;">IGM #</label>

                        <div style="float: left; width: 260px;">
                            <asp:Label ID="lbl_igm" Visible="false" Style="color: #000;" runat="server"></asp:Label>
                        </div>

                        <label style="float: left; display: inline-block; width: 150px; font-weight: bold; color: #000;">Line #</label>

                        <div style="float: left; width: 260px;">
                            <asp:Label ID="lbl_line" Visible="false" Style="color: #000;" runat="server"></asp:Label>
                        </div>
                    </div>


                    

                </div>
                <div style="clear: both;"></div>

                <div style="border: 0px solid #000;">
                    <div id="table_invoice" runat="server" visible="true">
                        <table width="1024" border="0" cellspacing="0" cellpadding="0"  style="border-collapse: collapse;">
                            <tr>
                                <th style="width:420px; color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;" rowspan="2">Charges</th>
                                <th style="width:55px; color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;" rowspan="2">SAC</th>
                                <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:234px; border-top: 1px solid #000;" rowspan="2">Qty </th>
                                <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:294px; border-top: 1px solid #000;" rowspan="2">Units</th>   
                                 <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:80px; border-top: 1px solid #000;" rowspan="2">Curr</th>   
                                                             <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:100px; border-top: 1px solid #000;" rowspan="2" >Rate</th>
                                <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 100px; border-top: 1px solid #000;" rowspan="2">Taxable Amt<label id="td_tax_basecurr" runat="server">(INR)</label></th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;" colspan="2">CGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;" colspan="2">SGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;" colspan="2">IGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 0px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;" colspan="0">Amount</th>
                            </tr>
                            <tr>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 16px;">%</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 65px;">Amt</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 16px;">%</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 65px;">Amt</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 16px;">%</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 65px;">Amt</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 0px solid Black;border-bottom: 1px solid #000;" id="th_basecurr" runat="server">(INR)</th>
                            </tr>

                            <asp:Label ID="tr_row" runat="server"></asp:Label>

                            <tr style="border-top:1px solid black;"">
                                <td id="tr_roundup" runat="server" visible="true" style="height: 17px; border-right: 1px solid Black;">
                                    <div style="padding: 0px 0px 0px 18px;" id="div_round" runat="server"></div>
                                </td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                 <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px;border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:0px solid black; text-align:right;">
                                    <asp:Label ID="lbl_roundup" runat="server" Style="text-align: right;" Visible="true"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 1px solid Black;">



                                    <h3 style="color: #000; float: left; width: 150px; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 1px 0px 1px 17px; margin: 0px;">E & O E</h3>



                                    <div style="float: right; width: 62px; padding: 0px 0px 0px 20px;">Total </div>

                                </td>
                                <td id="td3" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td id="td2" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td id="td1" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                              
                                <td style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 1px solid Black;">&nbsp;</td>

                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;">&nbsp;</td>
                                  
                              <td id="td_taxableamt" runat="server" style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 1px solid Black;text-align:right;">&nbsp;</td>
                                
                                
                                  <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;">&nbsp;</td>
                                <td id="td_cgsta" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                               
                               
                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;">&nbsp;</td>
                                 <td id="td_sgsta" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;">&nbsp;</td>
                                <td id="td_igsta" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black;" >
                                    <asp:Label ID="lbl_total" runat="server" Style="text-align: right;float:right;"></asp:Label></td>
                            </tr>

                        </table>
                    </div>

                    <div id="table_agent" runat="server" visible="false">
                        <table width="1024" border="0" cellspacing="0" cellpadding="0"  style="width: 100%; border-collapse: collapse;">
                           <tr>
                                <th style=" width:300px; color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;" rowspan="2">Charges</th>
                                <th style=" width:55px; color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;" rowspan="2">SAC</th>
                                <th style="  color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:105px;" rowspan="2">Qty - Units</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:100px;" rowspan="2">Rate</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 100px;" rowspan="2">Taxable Amt<label id="lbl_taxcurr" runat="server">(USD)</label></th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;" colspan="2">CGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;" colspan="2">SGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;" colspan="2">IGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;" colspan="2">Amount</th>
                            </tr>
                            <tr>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 16px;">%</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 65px;">Amt</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 16px;">%</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 65px;">Amt</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 16px;">%</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 65px;">Amt</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 0px solid Black;border-bottom: 1px solid #000;" id="TH_CURR" runat="server" colspan="2">(USD)</th>
                            
                     
                            
                            </tr>

                            <asp:Label ID="tr_rowagent" runat="server"></asp:Label>

                            <tr style="border-top:1px solid black;">
                                <td id="tr_roundup_agent" runat="server" visible="true" style="height: 17px; border-right:1px solid black;">
                                    <div style="padding: 0px 0px 0px 18px;" id="div1" runat="server"></div>
                                </td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:1px solid black;"></td>
                                <td style="height: 17px;border-right:1px solid black;"></td>
                                <td style="height: 17px; border-right:0px solid black;" colspan="0">
                                    <asp:Label ID="lbl_roundup_agent" runat="server" Style="text-align: right;" Visible="true"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="0" style="border-top:1px solid black; border-right: 1px solid Black;">
                                     <h3 style="color: #000; float: left; width: 150px; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 1px 0px 1px 17px; margin: 0px;">E & O E</h3>
                                    <div style="float: right; width: 62px; padding: 0px 0px 0px 20px;">Total </div>

                                </td>
                                <td id="td4" runat="server" style="border-top:1px solid Black; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td id="td5" runat="server" style="border-top:1px solid Black; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td id="td6" runat="server" style="border-top:1px solid Black; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td id="td_taxableamt_agent" runat="server" style="border-top:1px solid black; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid black; border-right: 1px solid Black;">&nbsp;</td>
                                <td id="td_cgsta_agent" runat="server" style="border-top:1px solid Black; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black; border-right: 1px solid Black;">&nbsp;</td>
                                <td id="td_sgsta_agent" runat="server" style="border-top:1px solid Black; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black; border-right: 1px solid Black;">&nbsp;</td>
                                <td id="td_igsta_agent" runat="server" style="border-top:1px solid Black; border-right: 1px solid Black; text-align:right;">&nbsp;</td>
                                <td style="border-top:1px solid Black; border-right: 0px solid Black;" colspan="0">
                                    <asp:Label ID="total_agent" runat="server" Style="text-align: right;float:right;"></asp:Label></td>
                            </tr> 

                        </table>
                    </div>
                </div>

                <div style="float: left; width: 98.1%; padding: 0px 0px 0px 20px; margin: 0px 0px 0px 0px; font-size: 12px; border-top: 0px solid black;border-bottom: 0px solid black;">
                  <h3 style="color: #000; float: left; width: 150px; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 0px 0px 0px 0px; margin: 0px;">Amount in words :</h3>  <asp:Label ID="lbl_currword" runat="server" style="display:inline-block; margin:3px 0px 0px 0px;"></asp:Label>
                </div>



                <div id="div_cont" visible="false" runat="server" style="float: left; width: 100%; height: 100%; margin: 0px 0px 0px 0px; padding:0px 0px 0px 0px; border-left: 0px solid #000; border-right: 0px solid #000; border-top: 1px solid #000;" >

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
                <div style="border-bottom:1px solid #000; float:left; width:100%;"></div>
                <div style="float: left; width: 1024px; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; text-align: left;">
                    <label style="display: inline-block; margin: 0px 0px 0px 20px;">Remarks:</label>
                    <asp:Label ID="lbl_remarks" runat="server" Style="display: inline-block; width: 900px;"></asp:Label>
                </div>
                <div style="clear: both;"></div>

                <div id="div_invoice" runat="server" visible="true">
                    <div style="width: 1024px; float: left; border-left: 0px solid #000; border-right: 0px solid #000;border-top: 0px solid #000; border-bottom: 1px solid #000;" id="div_banktot" runat="server" visible="true">
                        <div id="div_bank" runat="server" visible="true" style="width: 607px; float: left; margin: 0px 10px 0px 0px;">
                            
                            <div style="clear: both;"></div>
                                <p style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 22px; color: #000;"><strong>Bank Details :-</strong></p>

                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #000;">Account No.</label>
                                <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left; color: #000;">
                                    <asp:Label ID="lbl_accno" runat="server"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #000;">Favouring</label>
                                <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left;">
                                    <asp:Label ID="lbl_favouring" runat="server" Style="color: #000;"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #000;">IFSC Code</label>
                                <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left;">
                                    <asp:Label ID="lbl_ifsccode" runat="server" Style="color: #000;"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="float: left; width: 95px; margin: 0px 5px -5px 22px; color: #000;">Bank</label>
                                <div style="width: 4px; color: #000; float: left; margin: 0px 5px 0px 0px;">:</div>
                                <span style="float: left;">
                                    <asp:Label ID="lbl_bankname" runat="server" Style="color: #000;"></asp:Label></span>
                                <div style="clear: both;"></div>
                                <label style="display: block; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 131px; float: left; width: 68%">
                                    <asp:Label ID="lbl_bankaddress" runat="server" Style="color: #000;"></asp:Label></label>
                            
                            
                        </div>

                        <div id="div_between" runat="server" style="float: left; width: 1px; border-left: 1px solid #000; height: 130px; margin: 0px 5px 0px 5px;">&nbsp;</div>


                        <div id="div_fiinvoice" runat="server" visible="false" style="width: 370px; float: left; margin: 0px 0px 0px 0px; padding: 8px 0px 10px 0px; min-height: 104px; line-height: 24px;">
                            <p style="color: #000; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Upto15 days: No fine (starting from the devanning date).</p>
                            <p style="color: #000; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Between 15-30 days: Rs.1500/BL + GST as applicable</p>
                            <p style="color: #000; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Between 30-60 days: Rs.2500/BL + GST as applicable</p>
                            <p style="color: #000; margin: 0px 0px 0px 0px; padding: 1px 0px 1px 0px;">Above 60 days: Rs.5000/BL + GST as applicable</p>
                        </div>
                        <div style="clear: both;"></div>
                            <div style="float:left;padding: 0px 0px 5px 0px;margin:0px 0px 0px 0px; color: #000000;  width:1024px;height:85px; border-top:1px solid #000;" id="div_authorised" runat="server" visible="true">
                               <p style="margin: 0px 15px 0px 19px; padding: 0px 0px 0px 0px; color: #000000;float:right;"><strong>For </strong><strong><label id="for_comapny" runat="server"></label></strong></p>
                               
                                <div style="clear:both;"></div>
                                
                                <div style="margin: 55px 20px 0px 0px;float:right;"> <strong><label>Authorised Signatory</label></strong></div></div>
                        <div style="clear: both;"></div>

                        <div id="div_bottomsign" runat="server" visible="true">
                            <div style="border-bottom: 1px solid #000000; width: 1024px; margin: 3px 0px 2px 0px; height: 1px; float: left;"></div>
                            <div style="clear: both;"></div>

                            <%--<p style="font-weight: bold; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 20px;">THIS IS A COMPUTER GENERATED DOCUMENT AND HENCE REQUIRES NO SIGNATURE.</p>--%>


                            <p id="para_notBT" runat="server" visible="true" style="font-weight: normal; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 20px;">
                                ANY DISCREPANCY SHOULD BE NOTIFIED TO US IN WRITING WITHIN 7 DAYS FROM THE INVOICE DATE, OTHERWISE IT WILL BE PRESUMED THE AMOUNT REFLECTED ON THE BILL IS CORRECT AND HAVE BEEN VERIFIED AT YOUR END. PAYMENT MUST BE RECEIVED WITHIN THE AGREED CREDIT PERIOD,FAILING WHICH INTEREST @18% PER ANNUM WILL BE CHARGED ON OVERDUE INVOICES. ALL OBJECTIONS/CLAIMS ARE SUBJECT TO CHENNAI JURISDICTION.</p>
                            <%--<p style="text-align: right; color: #cdbcb1; margin: 5px 10px 5px 0px;">
                                <asp:Label ID="lbl_currentdate" runat="server"></asp:Label>
                            </p>--%>
                        </div>
                    </div>
                </div>
                <div style="clear: both;"></div>
                <div id="div_cnops" runat="server" visible="true" style="width: 100%; float: left;">
                    <div style="float: left; width: 250px; margin: 0px 0px 0px 20px;" id="div_prepare" runat="server" visible="true">
                        <div style="float: left; width: 250px;">
                            <b>
                                <asp:Label ID="lbl_preparedby" Style="font: bold; color: #000;" runat="server">Prepared By</asp:Label></b>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: left; width: 250px; margin: 5px 0px 0px 0px;">
                            <asp:Label ID="lbl_prepared" runat="server" Style="color: #000;"></asp:Label>
                        </div>
                    </div>
                    <div style="float: right; width: 250px; margin: 0px 0px 0px 0px;" id="div_approve" runat="server" visible="true">
                        <div style="float: left; width: 250px; text-align: left;">
                            <b>
                                <asp:Label ID="lbl_approvedby" Style="font: bold; color: #000; margin: 0px 5px 0px 0px;" runat="server">Approved By</asp:Label></b>
                        </div>
                        <div style="float: left; width: 250px; margin: 5px 0px 0px 0px; text-align: left;">
                            <asp:Label ID="lbl_approved" runat="server" Style="color: #000; margin: 0px 5px 0px 0px;"></asp:Label>
                        </div>
                    </div>
                    <div style="clear: both;"></div>
                    <div id="div_e_oe" runat="server" visible="false">
                        <div style="float: left; width: 9%;">
                            <h3>E & O E</h3>
                        </div>

                        <div style="float:right; width: 90%; font-weight: bold; margin: 12px 4px 0px 0px; text-align: right;">
                            <label id="label_branch" runat="server" title=""></label>
                        </div>
                    </div>
                    <div style="clear: both;"></div>
                    <div style="float: left; width: 650px; margin: -5px 0px 10px 0px; margin-left: 20px;" id="div_sign" runat="server" visible="false">
                        <p style="font-weight: bold;">THIS IS A COMPUTER GENERATED DOCUMENT AND HENCE REQUIRES NO SIGNATURE.</p>
                    </div>
                    <%--<p style="text-align:right; color:#000; margin:5px 10px 5px 0px;">
                        <asp:Label ID="lbl_cuurdate" runat="server"></asp:Label>
                    </p>--%>
                </div>
                <div style="clear: both;"></div>
                <div id="div_AEUN" runat="server" visible="false">
                    <div style="text-align:center; margin-top:10px;">
                        <label><b>UNAPPROVED  VOUCHER</b></label>
                    </div>

                    <div style="clear: both;"></div>
                    <div style="float: left;width:250px;margin:5px 0px 5px 20px;" visible="true">
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
                 <div style="clear: both;"></div>
        </div>
    </form>
</body>
</html>
