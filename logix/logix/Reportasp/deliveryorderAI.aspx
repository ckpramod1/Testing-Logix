<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deliveryorderAI.aspx.cs" Inherits="logix.Reportasp.deliveryorderAI" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Custom Annexure 1</title>
    <style type="text/css">
        .auto-style1 {
            width: 65%;
        }
    </style>
</head>

<body style="padding: 0px; margin: 0px;  font-family: sans-serif, Geneva, sans-serif; font-size: 14px; color: #000;">
    <div style="width: 100%; margin: auto;">
        <div style="width: 1024px; margin: auto; border:1px solid #000;">
            
            <div style="float:left; width:1024px; ">
                <div style="float: left; width:150px; margin: 9px 10px 5px 15px; text-align:left; color:#000;">
                <asp:Image ID="img_Logo" runat="server" Width="143" Height="89" /></div>
            <div style="width:680px; float:left; margin: 7px 0px 4px 9px; padding:0px 0px 0px 0px;">
            <div style="float: left; width: 100%; margin: 0px 0px 0px 0px;">
                <div><h3 style="font-family: Segoe UI; font-size: 24px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px;">
                    <asp:Label ID="lbl_branchnew" runat="server"></asp:Label></h3></div>
<%--                  <p style="margin:2px 0px 2px 0px; padding:0px 0px 0px 0px; font-size:14px; font-family: Segoe UI; text-align:center; ">(Formerly Known as Axelerom International Logistics Private Limited)</p>--%>
                <div style="text-align: center; color: #000; margin:0px 0px 0px 18px;">
                    <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                    Phone # :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>
                    Fax # :<asp:Label ID="lbl_fax1" runat="server"></asp:Label>;
                </div>
                <div id="div_invoicehead" runat="server" visible="false" style="padding: 0px 0px 0px 0px; text-align: center; color: #000;">
                    GST.# :
                            <asp:Label ID="lbl_st" runat="server"></asp:Label>
                    PAN # :
                            <asp:Label ID="lbl_pan" runat="server"></asp:Label>
                    CIN # :
                            <asp:Label ID="lbl_cin" runat="server"></asp:Label>
                </div>
                <div id="div_cnopshead" runat="server" style="text-align: center; color: #000; margin:0px 0px 0px 145px; display:none;">
                    Service Tax # :
                            <asp:Label ID="lbl_staxhead" runat="server"></asp:Label>
                    PAN # :
                            <asp:Label ID="lbl_panno" runat="server"></asp:Label>
                </div>

            </div>
            </div>
            <div style="float:right; margin:0px 0px 0px 0px;">

                <div style="float: right; width: 143px; margin: 10px 10px 10px 0px;">
                                Print Date:
                                <asp:Label ID="lbl_currdate" runat="server"></asp:Label>
                            </div>
            </div>

            </div>

            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px; text-align: center;  padding: 5px 0px 5px 0px; color:#000; font-weight: bold; border-top:1px solid #000; border-bottom:1px solid #000;">
                DELIVERY ORDER
            </div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 1024px; ">
                <div style="float: left; width: 800px;">
                    <div style="float: left; width: 60px; margin: 5px 0px 5px 10px; color:#000;">D.O #</div>
                    <div style="float: left; width: 3px; margin: 5px 5px 5px 0px; color:#000;">:</div>
                    <div style="float: left; width: 150px; margin: 5px 0px 5px 0px; color:#000;">
                        <asp:Label ID="lbl_DONum" runat="server"></asp:Label></div>
                </div>
                <div style="float: right; width: 126px; margin:0px 0px 0px 21px;">
                    <div style="float: left; width: 34px; margin: 5px 0px 5px 0px; color: #000; text-align: left;">Date</div>
                    <div style="float: left; width: 3px; margin: 5px 5px 5px 0px; color: #000;">:</div>
                    <div style="float: left; width: 83px; margin: 5px 0px 5px 0px; color: #000;">
                        <asp:Label ID="Lbl_Date" runat="server"></asp:Label></div>
                    <div style="clear: both;"></div>
                </div>
            </div>
            <div style="float: left; width: 1024px;">
                <p style="margin: 10px 0px 10px 10px;">To</p>
                <p style="margin: 5px 0px 40px 10px;">The Commissioner of Customs,</p>
                <p style="margin: 5px 0px 5px 10px;">Please deliver to <strong><asp:Label ID="lbl_Customername" runat="server"></asp:Label></strong> or order the following arrived.<%--the following arrived<strong> ex Aircraft No--%>
                  <%--  <asp:Label ID="lbl_flightno" runat="server"></asp:Label>
                    & <strong> Date </strong>--%>
                   <%-- <asp:Label ID="lbl_flightdate" runat="server"></asp:Label></strong>--%></p>

            </div>
            <div style="clear: both;"></div>

            <div style="float: left; width: 1024px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding: 10px 5px 0px 5px; margin: 10px 0px 0px 0px;">
                    <tr>
                        <td style="border-top: 1px solid #000; border-right:1px solid #000; margin:0px 0px 0px 0px;">
                            <div style="font-weight: bold; font-size: 14px; color: #000; width: 100px; float: left; padding: 5px 0px 5px 0px; margin: 0px 5px 0px 5px;">MAWB #</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_MAWBLNUMB" runat="server"></asp:Label></div>

                        </td>
                        <td style="border-top: 1px solid #000; border-right:1px solid #000; margin:0px 0px 0px 0px;">
                            <div style="font-weight: bold; font-size: 14px; color: #000; width: 100px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 10px;">Date</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_MAWBLDate" runat="server"></asp:Label></div>
                           
                        </td>
                        <td style="border-top: 1px solid #000;">
                            <div style="font-weight: bold; padding: 5px 0px 5px 0px; font-size: 14px; color: #000; width: 100px; float: left; margin: 0px 5px 0px 10px;">IGM # & Date</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_IGMNum" runat="server"></asp:Label>& <asp:Label ID="lbl_IGMDate" runat="server"></asp:Label></div>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-top: 1px solid #000; border-right:1px solid #000; margin:0px 0px 0px 0px;">
                            <div style="font-weight: bold; font-size: 14px; color: #000; width: 100px; float: left; padding: 5px 0px 5px 0px; margin: 0px 5px 0px 5px;">HAWB #</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_HAWBLNum" runat="server"></asp:Label>
                            </div></td>
                        <td style="border-top: 1px solid #000; border-right:1px solid #000; margin:0px 0px 0px 0px;">
                            <div style="font-weight: bold; padding: 5px 0px 5px 0px; font-size: 14px; color: #000; width: 100px; float: left; margin: 0px 5px 0px 10px;">Date</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_HAWBLDate" runat="server"></asp:Label></div>

                        </td>
                        <td style="border-top: 1px solid #000;">
                            <div style="font-weight: bold; padding: 5px 0px 5px 0px; font-size: 14px; color: #000; width: 100px; float: left; margin: 0px 5px 0px 10px;">From Port</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_portname" runat="server"></asp:Label></div>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-top: 1px solid #000; border-right:1px solid #000; margin:0px 0px 0px 0px;">
                            <div style="font-weight: bold; font-size: 14px; color: #000; width: 100px; float: left; padding: 5px 0px 5px 0px; margin: 0px 5px 0px 5px;">Packages</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_Noofpkg" runat="server"></asp:Label>
                                <asp:Label ID="Lbl_desc" runat="server"></asp:Label></div>
                        </td>
                        <td style="border-top: 1px solid #000; border-right:1px solid #000; margin:0px 0px 0px 0px;">
                            <div style="font-weight: bold; padding: 5px 0px 5px 0px; font-size: 14px; color: #000; width: 100px; float: left; margin: 0px 5px 0px 10px;">Gr.Wt</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_Grwg" runat="server"></asp:Label> KGS</div>

                        </td>
                        <td style="border-top: 1px solid #000;">
                            <div style="font-weight: bold; padding: 5px 0px 5px 0px; font-size: 14px; color: #000; width: 100px; float: left; margin: 0px 5px 0px 10px;">Charge Wt</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 150px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_chrgwt" runat="server"></asp:Label></div>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-top: 1px solid #000;" colspan="3">
                            <div style="font-weight: bold; font-size: 14px; color: #000; width: 100px; float: left; padding: 5px 0px 5px 0px; margin: 0px 5px 0px 5px;">Contents</div>
                            <div style="float: left; width: 4px; padding: 5px 0px 5px 0px;">:</div>
                            <div style="font-weight: normal; font-size: 14px; color: #000; width: 560px; padding: 5px 0px 5px 0px; float: left; margin: 0px 5px 0px 5px;">
                                <asp:Label ID="lbl_contentdesc" runat="server"></asp:Label></div>
                        </td>
                       
                    </tr>
                    <tr>
                         <td colspan="3">

                            <div style="border-top:1px solid #000; width:100%; float:left; height:1px;"></div>

                        </td>


                    </tr>
                </table>
            </div>
            <div style="float: left; width: 1024px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="auto-style1">
                            <div style="float: left; width: 100%; margin: 5px 0px 0px 10px;">

                                <strong>Received DO</strong><br />
                                <br />
                                <asp:Label ID="lbl_toaddress" runat="server"></asp:Label>
                            </div>


                        </td>
                         <td width="50%" valign="top">
                            <div style="float: left; width: 100%; margin: 5px 0px 0px 10px;">

                                <strong>Shipper</strong><br />
                                <br />
                                <asp:Label ID="lbl_consaddress" runat="server"></asp:Label>
                            </div>


                        </td>
                       
                    </tr>
                    <tr>
                        <td colspan="2"><div style="float:left; width:100%; height:1px; border-bottom:1px solid #000;"></div></td>
                    </tr>
                  
                  

                    <tr>
                        <td valign="top" colspan="3">


                          
                            <table>
                              
                                <tr>
                                    <td class="auto-style1" width="40%">
                                        <div style="width: 338px; float: left; border-right: 1px solid #000; margin: 0px 10px 0px 0px;">
                                <ol>
                                    <li style="padding: 10px 0px 10px 0px; margin: 0px 0px 0px 0px;">Original HAW Bill DO</li>
                                    <li style="padding: 10px 0px 10px 0px; margin: 0px 0px 0px 0px;">Original HAW Bill</li>
                                    <li style="padding: 10px 0px 10px 0px; margin: 0px 0px 0px 0px;">Copy MAW Bill DO</li>
                                    <li style="padding: 10px 0px 10px 0px; margin: 0px 0px 0px 0px;">Copy MAW Bill</li>
                                    <li style="padding: 10px 0px 10px 0px; margin: 0px 0px 0px 0px;">Original Invoice & Packing List</li>
                                </ol>
                            </div>
                            <div style="width: 100px; float: left;">

                                <input name="" type="checkbox" value="" style="width: 25px; height: 25px; margin: 25px 0px 5px 0px;" /><br />
                                <input name="" type="checkbox" value="" style="width: 25px; height: 25px; margin: 8px 0px 5px 0px;" /><br />
                                <input name="" type="checkbox" value="" style="width: 25px; height: 25px; margin: 8px 0px 5px 0px;" /><br />
                                <input name="" type="checkbox" value="" style="width: 25px; height: 25px; margin: 8px 0px 5px 0px;" /><br />
                                <input name="" type="checkbox" value="" style="width: 25px; height: 25px; margin: 8px 0px 5px 0px;" /><br />
                            </div>
                                    </td>
                                    <td width="60%" valign="top">
                                        <div style="float: right; width: 100%; margin: 22px -28px 152px 0px; width:550px;">
                                <span style="font-weight:bold">
                                For
                                <asp:Label ID="lbl_branch" runat="server"></asp:Label>
                                </span>

                            </div>
                            <div style="float: right; width: 220px; margin-left: 0px; margin-right: -30px; margin-bottom: 0px; font-weight:bold;">Authorised Signatory</div>

                                    </td>

                                </tr>
                            </table>

                            

                        </td>
                       
                    </tr>
                </table>


            </div>



            <div style="clear: both;"></div>
            <div style="clear: both;"></div>
        </div>
    </div>
</body>
</html>
