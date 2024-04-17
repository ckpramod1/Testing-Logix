
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceReportOthcntry.aspx.cs" Inherits="logix.Reportasp.InvoiceReportOthcntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/systemreport.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .div_cont_class {
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
        f
        .MINHeight {
            /*min-height: 150px;*/
        }

        .MINHeight1 {
            min-height: 250px;
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
        img#ImgLogo {
    width: 184px;
}
        tr td:last-child {
    border-right: 0!important;
}
        
        /*table td:nth-child(1) label {
    width: 282px!important;
}
        table td:nth-child(1) {
    width: 29.2% !important;
}
        table td:nth-child(2),
         table td:nth-child(3),
         table td:nth-child(4),
         table td:nth-child(5) {
    width: 5.27% !important;
}*/
        table tbody td:nth-child(2) {
    width: 10% !important;
}
        span#lbl_head {
    font-size: 18px;
}
        span#lbl_toaddress {
        display: inline-block;
    white-space: pre-line;
    line-height: 22px;
    padding: 0px 0px 0px 0px;
}
        div#div_cnops {
    display: none;
}
        table td:nth-child(5) {
    width: 98px !important;
}
   table tbody td:nth-child(3) {
    text-align: center !important;
    padding: 0px 41px 0px 0px !important;
}
   div#terms p {
    padding: 0px 0px 0px 4px;
}


   
    </style>
</head>
<body>
    <form id="form1" runat="server">




        <div style="margin: 0 auto;
width: 1024px;">
            <div style="width:100%;float:left;border:1px solid #000; margin-bottom: 16px;">
                <div style="float:left;width:150px;margin: 9px 10px 5px 15px;border-right:0px solid #000">
        <%--<img id="lbl_img" src="" style="width:100%;" alt="logo" >--%>
        <asp:Image ID="lbl_img" runat="server"  Width="100%"  />
    </div>
    <div style="float:left; width:735px; margin:5px 0px 4px 7px;">
        <h3 style="font-family: Segoe UI; font-size: 21px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 22px;">
            <span><asp:Label ID="lblcompanyname" runat="server"></asp:Label></span>
        </h3>
        <h3 style="font-family: Segoe UI; font-size: 17px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 22px;">
         <%--   <asp:Label id="lbl_add" runat="server" />--%>
            <asp:Label ID="lbl_add"  runat="server"></asp:Label>
        </h3>
        <h3 style="font-family: Segoe UI; font-size: 17px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 22px;">
           TEL NO : <asp:Label Text="Phone #:" ID="lbl_ph" runat="server" /><span> FAX :  <asp:Label ID="lbl_fax" runat="server"></asp:Label></span> UEN NO : <asp:Label Text="GST" ID="lbl_st" runat="server" /><asp:Label Text="PAN #" ID="lbl_pan" runat="server" />
            <asp:Label Text="" runat="server" /><span></span><br />
        www.SL.com</h3>
    
    </div>  

                <div style="width:100%;float:left;border-top: 1px solid black;border-bottom:1px solid #000">
                         <div style="float:left;width:100%;min-height: 30px;border-right: 1px solid #000;">
            <div style="font-size: 14px; color: #000;width:100%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;text-align:center"><asp:Label ID="lbl_head" runat="server">  TAX INVOICE</asp:Label></div>
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;">  
                <%--<asp:Label Text="lbl_taxinvoice" runat="server" />--%>
                <label id="label_invoice" runat="server"></label>
            </div>

        </div>
      
                </div>
                <div style="width:100%;float:left;">
                      <div style="float:left;width:7.5%;min-height: 30px;border-right: 0px solid #000;border-bottom:0px solid #000">
            <div id="divinvtype" runat="server" style="font-size: 14px; color: #000;width: 100%; float: left;padding: 7px 0px 7px 3px;font-weight: bold;">Invoice No.</div>
        </div>
        <div style="float:left;width:160px;min-height: 30px;border-bottom:0px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;width:84.6%"> <asp:Label ID="lbl_invoice" runat="server" /></div>
        </div>
                       <div style="float:left;width:64%;min-height: 30px;border-right: 0px solid #000;">
            <div style="font-size: 14px; color: #000;width: 25%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;"></div> <%--Original for Recipient--%>
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;width:70">
                <asp:Label  runat="server" /></div>
        </div>
        <div style="float:left;width:3.5%;min-height: 30px;border-right: 0px solid #000;">
            <div style="font-size: 14px; color: #000;width: 100%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Date</div>
        </div>
        <div style="float:left;width:92px;min-height: 30px;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;">
                <asp:Label id="lbl_date" runat="server" /></div>
        </div>
                </div>

                <div style="width:100%;float:left;border-top: 1px solid black;  " id="div_irn" runat="server" visible="false">
                      <div style="float:left;width:6%;border-right:1px solid #000;min-height:15px;">
                <div style="font-size: 14px; color: #000;width: 66%; float: left;padding: 7px 0px 6px 20px;font-weight: bold;">IRN #</div>
            </div>
            <div style="float:left;width:46.1%;border-right:1px solid #000;min-height:15px;">
                <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;width:97%">
                    <asp:Label id="LblIrnno" runat="server" /></div>

            </div>
            <div style="float:left;width:8%;border-right:1px solid #000;min-height:15px;">
                <div style="font-size: 14px; color: #000;width: 90%; float: left;padding: 7px 0px 6px 20px;font-weight: bold;">ACK #</div>
            </div>
            <div style="float:left;width:15.7%;border-right:1px solid #000;min-height:15px;">
                <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;width:90%">
                    <asp:Label id="LblAckno" runat="server" /></div>
            </div>
            <div style="float:left;width:80px;border-right:1px solid #000;min-height:15px;">
                <div style="font-size: 14px; color: #000;width: 70px; float: left;padding: 7px 0px 6px 7px;font-weight: bold;">ACK Date</div>
            </div>
             <div style="float:left;width:158px;min-height:15px;">
                <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 0px;width:95%">
                    <asp:Label id="LblAckdt" runat="server" /></div>
            </div>
                </div>
                <div style="width:100%;float:left;">
                        <div style="float:left;width:50%;min-height:140px;border-right:0px solid #000;border-top:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;" id="label_bill" runat="server" >Bill To</div>
            <div style="font-size: 14px;float: left; width: 91%; margin: 0px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 3px;"> <asp:Label ID="lbl_toaddress" runat="server" /></div>

        </div>
    <div style="float:left;width:50%;min-height:140px;border-top:1px solid #000">
        <div style="font-size: 14px; color: #000;width: 20%;padding: 7px 0px 5px 3px;font-weight: bold;"><label id="label_supply" style="visibility: hidden;" runat="server"> Supply To</label></div>
        <div style="font-size: 14px;float: left; width: 91%; margin: 0px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 3px;">
            <asp:Label ID="lbl_tosupply" style="visibility: hidden;" runat="server" /></div>
    </div>
                </div>
                

           

                <div style="width:100%;float:left;border-top:1px solid #000;display:none;">
                    <div style="font-size: 14px; color: #000;width: 4.5%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;border-right:1px solid #000">GST</div>
                    <div style="font-size: 14px; color: #000;width: 14%; float: left;padding: 7px 0px 5px 7px;border-right:1px solid #000"><asp:Label ID="div_gst" runat="server"></asp:Label> </div>
                    <div style="font-size: 14px; color: #000;width: 5%; float: left;padding: 7px 0px 5px 7px;font-weight: bold;border-right:1px solid #000">State</div>
                    <div style="font-size: 14px; color: #000;width: 13.9%; float: left;padding: 7px 0px 5px 7px;border-right:1px solid #000"> <asp:Label ID="gst_state" runat="server"></asp:Label> </div>
                    <div style="font-size: 14px; color: #000;width: 5%; float: left;padding: 7px 0px 5px 7px;font-weight: bold;border-right:1px solid #000">Code</div>
                    <div style="font-size: 14px; color: #000;width: 4%; float: left;padding: 7px 0px 5px 7px;border-right:1px solid #000"><asp:Label ID="gst_code" runat="server"></asp:Label> </div>
                    <div style="font-size: 14px; color: #000;width: 4.5%; float: left;padding: 7px 0px 5px 7px;font-weight: bold;border-right:1px solid #000">GST</div>
                    <div style="font-size: 14px; color: #000;width: 15%; float: left;padding: 7px 0px 5px 7px;border-right:1px solid #000;min-height:17px";><label id="div_supplygst" runat="server"></label></div>
                    <div style="font-size: 14px; color: #000;width: 5%; float: left;padding: 7px 0px 5px 7px;font-weight: bold;border-right:1px solid #000">State</div>
                    <div style="font-size: 14px; color: #000;width: 9%; float: left;padding: 7px 0px 5px 7px;border-right:1px solid #000"> <label id="div_supplystate" runat="server"></label></div>
                    <div style="font-size: 14px; color: #000;width: 5%; float: left;padding: 7px 0px 5px 7px;font-weight: bold;border-right:1px solid #000">Code</div>
                    <div style="font-size: 14px; color: #000;width: 4%; float: left;padding: 7px 0px 5px 7px;"><label id="div_supplycode" runat="server"></label></div>




                </div>

                <div style="width:100%;float:left;border-top:1px solid #000">
                    <div style="width:100%;float:left">
                        <div style="width:100%;float:left;border-bottom:1px solid #000">
                        <div style="width:9.2%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000">Shipper</div>
                        <div style="width:39.8%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;border-right:1px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000">
                            <asp:Label id="lbl_shipper" runat="server" /></div>
                        <div style="width:9.5%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000" id="div_consignee" runat="server" >Consignee</div>
                        <div style="width:34.4%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;border-right:0px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000" id="label_Consignee"  runat="server">
                            <asp:Label id="lbl_consignee" runat="server" /></div>
      
                        </div>
                         <div style="width:100%;float:left;border-bottom:1px solid #000">
                        <div style="width:9.2%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000"><label id="lbl_job" runat="server"> Job #</label></div>
                        <div style="width:39.8%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;border-right:1px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000">
                            <asp:Label ID="lbl_ourjob" runat="server" /></div>
                        <div style="width:9.5%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000"> <label ID="lbl_blname" runat="server">BL #</label></div>
                        <div style="width:34.4%;float:left;padding: 7px 0px 5px 7px;border-right:0px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000">
                            <asp:Label ID="lbl_bl" runat="server" /></div>
      
                        </div>
                         <div style="width:100%;float:left;border-bottom:1px solid #000">
                        <div style="width:9.2%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000"><label id="label_vessel" runat="server"> Vessel</label></div>
                        <div style="width:39.8%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;border-right:1px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000">
                            <asp:Label ID="lbl_vessel" runat="server" /></div>

                             <div style="width:9.5%;float:left;border-right:1px solid #000;min-height:17px;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000"><label id="Label1" runat="server">Cust Ref #</label> </div>
                        <div style="width:28%;float:left;padding: 7px 0px 5px 7px;border-right:0px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000">
                            <asp:Label ID="lbl_vendor" runat="server" /></div>


                              <div style="width:10%;float:left;border-right:0px solid #000;padding: 7px 0px 5px 7px;border-right:0px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000;min-height:17px;">
                            <asp:Label ID="lbl_vendordate" runat="server" /> </div>


                            <%-- mbl--%>

                            <div id="dimbl" runat="server"  style="display:none;" >  
                                                      <div style="width:9.5%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000"><label id="lbl_mblname" runat="server">MBL #</label> </div>
                        <div style="width:34.4%;float:left;padding: 7px 0px 5px 7px;border-right:0px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000">
                            <asp:Label ID="lbl_mbl" runat="server" /></div>
                                </div>

                               
      
                        </div>
                         <div style="width:100%;float:left;border-bottom:1px solid #000">
                      
 <div style="width:9.2%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;">POL / ETD </div><%--PoS--%>
                        <div style="width:39.8%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;font-size: 14px; color: #000;min-height:16px;">
                             <asp:Label ID="lbl_pos" Text="" runat="server"></asp:Label></div>

                        <div style="width:9.5%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000">POD / ETA</div>
                        <div style="width:34.4%;float:left;border-right:0px solid #000;padding: 7px 0px 5px 7px;font-size: 14px; color: #000;border-bottom:0px solid #000">
                                <asp:Label ID="lbl_pod" runat="server" ></asp:Label></div>
      
                        </div>
                       <%-- date--%>
                         <div style="width:100%;float:left;border-bottom:1px solid #000">

                             <div id="diex" runat="server" >

                                 <div id="div_exrate" runat="server" >
                                    <div   style="width:9.2%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000">      Ex rate
</div>
                                     </div>
                        <div style="width:39.8%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;border-right:1px solid #000;font-size: 14px;min-height: 16.4px; color: #000;border-bottom:0px solid #000">
                            <asp:Label  ID="lbl_exrate" runat="server"  /></div>
                                 </div>


                       
                             <div id="divp" runat="server">
                        <div id="div_pack" runat="server"  style="width:9.5%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000">
                            <div id="lbl_pack" runat="server" style="width:100%;float:left;font-weight: bold;font-size: 14px; color: #000;"></div>
                              Packages

                        </div>
                        <div style="width:30.4%;float:left;border-right:0px solid #000;padding: 7px 0px 5px 7px;font-size: 14px; color: #000;border-bottom:0px solid #000">
                          <asp:Label ID="lbl_package" runat="server" /></div>
                                 </div>
      
                        </div>
                       <%-- exrate--%>
                         <div style="width:100%;float:left;border-right:0px solid #000;border-bottom:0px solid #000">


                             <div id="div_volume" runat="server" style="width:50%;float:left;border-right:1px solid #000;" >
                              <div style="width:18.4%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;border-bottom:0px solid #000"><label id="lable_volume" runat="server"> Volume</label></div>
                        <div style="width:39.8%;float:left;border-right:0px solid #000;padding: 7px 0px 5px 7px;border-right:0px solid #000;font-size: 14px; color: #000;border-bottom:0px solid #000;min-height:17px;">
                            <asp:Label ID="lbl_volume" runat="server" /></div>
                                 </div>


       
 

                             <div id="div_grw" runat="server" style="width:48.9%;float:left;display :none">
                        <div style="width:19.6%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;min-height: 17px;">
                            <div  id="lbl_gw" runat="server" style="width:100%;float:left;font-size: 14px; color: #000;">  Gross Wt</div> 
                           </div>
                        <div style="width:69.7%;float:left;padding: 7px 0px 5px 7px;font-size: 14px; color: #000;">
                            <asp:Label ID="lbl_grwt" runat="server" /></div>

                            </div>
      
                        </div>
                         

                 <%--       approved--%>

                             <div id="div_cnops" runat="server" style="width:100%;float:left;border-top:1px solid #000" visible="false">

                        <div id="div_prepare" runat="server" style="width:9.1%;float:left;border-right:1px solid #000;border-top: 0px solid #000;padding: 7px 0px 5px 4px;font-weight: bold;font-size: 14px; color: #000;">Prepared By </div>
                        <div style="width:39.8%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;border-right:1px solid #000;border-top: 0px solid #000;font-size: 14px; color: #000;">
                             <asp:Label ID="lbl_prepared" runat="server"></asp:Label></div>


                             <div style="width:45.1%;float:left;" id="div1" runat="server">
                        <div  id="div_approve" runat="server" style="width:21.1%;float:left;border-right:1px solid #000;border-top: 0px solid #000;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;">
                            <div style="width:100%;float:left;font-weight: bold;font-size: 14px; color: #000;"><label id="Label2" runat="server"> Approved By</label></div>
                        

                        </div>
                        <div style="width:74%;float:left;border-right:1px solid #000;padding: 7px 0px 5px 7px;border-right:0px solid #000;border-top: 0px solid #000;font-size: 14px; color: #000;">
                         <asp:Label ID="lbl_approved" runat="server" /></div>
                                 </div>
      
                        </div>



        






                    </div>

                </div>

               <%-- newtable--%>

                <div style="width:100%;float:left;">
                      <table width="1024" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
                        <thead>
                                <tr>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 19px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;" rowspan="0">Charges</th>
                                <th style="width:55px; color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;display: none" rowspan="0" >SAC</th>
                                <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:78px; border-top: 1px solid #000;" rowspan="0">Qty </th>
                                             <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:78px; border-top: 1px solid #000;" rowspan="0">Units </th>
                                      <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:78px; border-top: 1px solid #000;" rowspan="0">Currency </th>
                                <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:58px; border-top: 1px solid #000;" rowspan="0">Rate</th>   
                                 <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:130px; border-top: 1px solid #000; display: none" rowspan="0">Taxable 
                                     <label id="td_tax_basecurr" runat="server">(USD)</label>
                                 </th>   
                                 <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width:100px; border-top: 1px solid #000;display:none" rowspan="0">CGST (%)</th>
                                <th style="color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000;width: 100px; border-top: 1px solid #000;width:100px;display:none" rowspan="0">CGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;width:79px;display:none" >SGST (%)</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;width:83px;display:none" >SGST</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;width:95px ;display: none" >GST/VAT (%)</th>
                                <th style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;width:74px;display: none"  >GST/VAT</th>
                                <th id="th_basecurr" runat="server" style=" color: #000; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 0px solid Black;border-bottom: 1px solid #000; border-top: 1px solid #000;width:121px" >Amount Rs</th>

                            </tr>
                            </thead>
     


              <tbody>
                    <asp:Label ID="tr_row" runat="server"></asp:Label>
                            <tr style="border-top:0px solid black;">


                                <td id="tr_roundup" runat="server" style="height: 17px; border-right: 1px solid Black;visibility: hidden;">
                                     <div ></div>
                                </td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                    <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                              <td    style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td   style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td  style="height: 17px; border-right: 1px solid Black;display:none"></td>
                               <td  style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td  style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px;border-right:1px solid black;display:none">
                                <td style="height: 17px;border-right:1px solid black;">

                                   
                                </td>
                        
                              
                            </tr>

                                    <tr style="border-top:0px solid black;">


                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                         <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                         <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td  style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px;border-right:1px solid black;">
                                     
                                </td>
                        
                              
                            </tr>


                                                      <tr style="border-top:0px solid black;">


                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
  <td style="height: 17px; border-right: 1px solid Black;"></td>
                                                            <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px;border-right:1px solid black;"></td>
                        
                              
                            </tr>

                                                      <tr style="border-top:0px solid black;">


                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                                          <td style="height: 17px; border-right: 1px solid Black;"></td>
                                                          <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px;border-right:1px solid black;"></td>
                        
                              
                            </tr>

                                                      <tr style="border-top:0px solid black;">

   <asp:Label ID="tr_rowagent" runat="server"></asp:Label>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                                          <td style="height: 17px; border-right: 1px solid Black;"></td>
                                                          <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td id="td_taxableamt_agent" runat="server" style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;"></td>
                                <td   style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td id="td_sgsta_agent" runat="server" style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td id="td_cgsta_agent" runat="server" style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td id="td_igsta_agent" runat="server" style="height: 17px; border-right: 1px solid Black;display:none"></td>
                                <td style="height: 17px;border-right:1px solid black;">
                                     <asp:Label ID="total_agent" runat="server" Style="text-align: right;float:right;"></asp:Label>
                                </td>
                        
                              
                            </tr>

                         <tr style="display:none">
                                <td colspan="1" style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 1px solid Black;">



                                  <%--  <h3 style="color: #000; float: left; width: 150px; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 1px 0px 1px 17px; margin: 0px;">E &amp; O E</h3>--%>



                                    <div id="div_round" runat="server" style="float: right; width: 97px; padding: 5px 0px 5px 20px;font-weight:bold;"></div>

                                </td>
                                <td id="" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;display:none">&nbsp;</td>

                                <td id="" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;">&nbsp;</td>

                                <td id="" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;">&nbsp;</td>

                              
                                <td style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 0px solid Black;">&nbsp;</td>

                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black;">&nbsp;</td>
                              <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black;display:none">&nbsp;</td>
                              <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black;display:none">&nbsp;</td>
                                  
                              <td id="" style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 0px solid Black;text-align:right;display:none"></td>

                                
                                
                                  <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black;display:none">&nbsp;</td>
                                <td id="" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;display:none"></td>

                               
                               
                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black;display:none">&nbsp;</td>
                                 <td id="" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;display:none"></td>

                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;text-align: right;"> <asp:Label ID="lbl_roundup" runat="server" Style="text-align: right;" Visible="true"></asp:Label></td>
                           
                            </tr>

                            <tr>
                                <td colspan="1" style="border-top:1px solid black; border-bottom:1px solid #000; border-right:0px solid Black;">



                                  <%--  <h3 style="color: #000; float: left; width: 150px; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 1px 0px 1px 17px; margin: 0px;">E &amp; O E</h3>--%>



                                    <div style="float: right; width: 62px; padding: 5px 0px 5px 20px;font-weight:bold;"> </div>

                                </td>
                                <td id="" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right:0px solid Black; text-align:right;display:none">&nbsp;</td>

                                <td id="" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;">&nbsp;</td>

                                <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;">&nbsp;</td>
                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 0px solid Black; text-align:right;">&nbsp;</td>
                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;font-size: 17px;padding-right: 6px;font-weight: bold;">Total</td>

                              
                                <td   id="td_taxableamt" runat="server" style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 1px solid Black;text-align:right;display:none">&nbsp;</td>

                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;display:none">&nbsp;</td>
                                  
                              <td id="td_cgsta" runat="server" style="border-top:1px solid black; border-bottom:1px solid #000; border-right: 1px solid Black;text-align:right;display:none"></td>

                                
                                
                                  <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;display:none">&nbsp;</td>
                                <td id="td_sgsta" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;display:none"></td>

                               
                               
                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;display:none">&nbsp;</td>
                                 <td id="td_igsta" runat="server" style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black; text-align:right;display:none"></td>

                                 <td style="border-top:1px solid Black; border-bottom:1px solid #000; border-right: 1px solid Black;">

                                     
<asp:Label ID="lbl_total" runat="server" Style="text-align: right;float:right;font-weight: bold"></asp:Label>
                                 </td>
                           
                            </tr>
                  

                        </tbody>

                        </table>
                </div>
                      <div style="width:100%;min-height:15px;float:left;">
            <div style="font-size: 14px; color: #000;width: 14%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;display:none"></div>
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 5px;width:70% ;font-weight: bold">
                <asp:Label ID="lbl_currword" runat="server" /></div>
        </div>

                <div id="div_cont" runat="server" style="width:100%;float:left;min-height: 15px;border-top: 1px solid #000;border-bottom: 1px solid #000;">
    <div style="font-size: 14px; color: #000;width: 12%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;" id="tr_cont" runat="server">Container Details
    </div>
    <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 9px;width:81%">
        <asp:Label id="tr_contdetail" runat="server" />
         <asp:Label ID="lstcon" runat="server"></asp:Label>
    </div>
</div>
              
 

            <%--    bankdetails--%>
                <div style="width:100%;float:left;min-height:75px;">
    <div id="div_bank" runat="server" style="width:57.5%;float:left;min-height:75px;border-right: 1px solid #000;">
     <div style="width:100%;float:left;min-height:29px;border-bottom: 1px solid #000;">
    <div style="width:22%;float:left;min-height:29px;border-right:1px solid #000">
    <div style="font-size: 14px; color: #000; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Bank Details</div>
    </div>
    
    <div style="width:77%;float:left;min-height:15px">
        <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;">
            <asp:Label ID="lbl_bankname" runat="server" /></div>
    </div>

    </div>
    <div style="width:100%;float:left;min-height:29px;border-bottom: 1px solid #000;">
        <div style="width:22%;float:left;min-height:29px;border-right:1px solid #000">
        <div style="font-size: 14px; color: #000; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Account #</div>
        </div>
        
        <div style="width:77%;float:left;min-height:15px">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;">
                <asp:Label ID="lbl_accno" runat="server" /></div>
        </div>
    
        </div>
        <div style="width:100%;float:left;min-height:29px;border-bottom: 1px solid #000;">
            <div style="width:22%;float:left;min-height:29px;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Beneficiary</div>
            </div>
            
            <div style="width:77%;float:left;min-height:29px">
                <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;">
                    <asp:Label ID="lbl_favouring" runat="server" /></div> 
            </div>
        
            </div>
            <div style="width:100%;float:left;min-height:29px;border-bottom: 1px solid #000;">
                <div style="width:22%;float:left;min-height:29px;border-right:1px solid #000">
                <div style="font-size: 14px; color: #000; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Swift Code</div>
                </div>
                
                <div style="width:77%;float:left;min-height:15px">
                    <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;">
                        <asp:Label ID="lbl_ifsccode" runat="server" /></div>
                </div>
            
                </div>
                <div style="width:100%;float:left;min-height:29px;">
                    <div style="width:22%;float:left;min-height:47px;border-right:1px solid #000">
                    <div style="font-size: 14px; color: #000; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Bank Address</div>
                    </div>
                    
                    <div style="width:77%;float:left;min-height:15px">
                        <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;">
                            <asp:Label ID="lbl_bankaddress" runat="server" /></div>
                    </div>
                
                    </div>
      
    
  
    </div>
    <div style="width:41%;float:right;min-height:75px;padding-right:5px">
        <div style="border-bottom: 0px solid #000;float:left;width:100%">
        <div style="width:100%;float:left;min-height:18px;padding: 6px 0px 5px 0px;font-size: 14px;text-align:right;">
          for <label id="lbl4comname" runat="server"></label>
         </div>
        </div>

        <div style="float:left;width:100%;border-top: 0px solid #000;margin-top: 89px;">
            <div style="width:100%;float:left;min-height:15px;padding: 6px 0px 2px 0;font-size: 14px;text-align:right">
                Authorised Signatory
             </div>
            </div>


    </div>

 
   
</div>

     <div id="terms" runat="server" style="width:100%;float:left;border-top:1px solid #000" visible="false">
         
         <p> 1. The company is not responsible for any cash settlement without any official receipt.<br />
             2. Any discrepancy should be notified to us in writing within 7 days from the invoice date after which NONE will be accepted.</p>
         </div>

              <%--  borderend--%>

            </div>
          

        </div>

              





     <%--   new report--%>
        <%--start--%>
     <div style="margin: 0 auto;
width: 1024px;display:none">
    <div style="width:100%;float:left;border:1px solid #000; margin-bottom: 16px;">
        <!-- header -->
<div style="width:100%;float:left;border-bottom:1px solid #000;min-height: 30px;">
  
</div>

   

     

        <div style="width:100%;float:left;border-top:1px solid #000;min-height:15px;">
          
            <div style="width:100%;float:left;">
                <div style="width:50%;float:left;border-right: 1px solid ;"></div>
                <div style="width:50%;float:left;"></div>
            </div>
        
        </div>
    
       
         
    <div style="width:100%;float:left;min-height:15px;border-top:1px solid #000" >

      
        </div>
        
 
    <div style="width:100%;float:left;min-height:190px;">
        <div style="float:left;width:80%;min-height:190px;border-right: 1px solid #000;border-top:1px solid #000;">
        <div style="float:left;width:100%">
            <div id="div_ship" runat="server">
            <div style="width:12.5%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;"><label id="label_shipper" runat="server"> Shipper</label></div>
            </div>
         <%--   <div style="width:36%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
                <asp:Label ID="lbl_shipper" runat="server" /></div>
            </div>
                </div>
            <div style="width:14.2%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000" id="div_consignee" runat="server">
            <div id="label_Consignee" runat="server" style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Consignee</div>
            </div>
            <div style="width:302px;float:left;min-height:15px;border-bottom: 1px solid #000;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
                <asp:Label ID="lbl_consignee" runat="server" /></div>
            </div>--%>
        </div>
        <div style="float:left;width:100%">
            <div style="width:12.5%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 77%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;"></div>
            </div>
            <div style="width:36%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
                </div>
            </div>
            <div id="div_bl" runat="server">
            <div style="width:14.2%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 70%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">
                </div>
            </div>
            <div style="width:302px;float:left;min-height:15px;border-bottom: 1px solid #000;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
               </div>
            </div>
                </div>
        </div>
        <div style="float:left;width:100%">
            <div style="width:12.5%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;"></div>
            </div>
            <div style="width:36%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
               </div>
            </div>
            <div ID="div_mbl" runat="server" style="width:14.2%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000"></div>
            <div style="font-size: 14px; color: #000;width: 70%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;"></div>
            
            <div style="width:302px;float:left;min-height:15px;border-bottom: 1px solid #000;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
               </div>
            </div>
                </div>
        </div>
        <div style="float:left;width:100%">
            <div  id="div_vendorref" runat="server"  style="width:12.5%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 70%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Cust Ref #</div>
            </div>
            <div style="width:36%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
                </div>
            </div>
            <div id="div_port" runat="server" style="width:14.2%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
                <div id="div_port1" runat="server">
            <div id="lbl_port" runat="server" style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">P O R / P O D
             
            </div>
            </div>
            <div style="width:302px;float:left;min-height:15px;border-bottom: 1px solid #000;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
               
        
            </div>
        </div>
                </div>
        <div style="float:left;width:100%">
            <div style="width:12.5%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Due Date</div>
            </div>
            <div style="width:36%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
               </div>
            </div>
            <div style="width:14.2%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div  style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Packages</div>
           
            <div style="width:302px;float:left;min-height:15px;border-bottom: 1px solid #000;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
                </div>
            </div>
                 </div>
        </div>
        <div style="float:left;width:100%">
            <div style="width:12.5%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Ex.Rate</div>
           
            <div style="width:36%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
               </div>
            </div>
                 </div>
            <div  >
            <div style="width:14.2%;float:left;min-height:15px;border-bottom: 1px solid #000;border-right:1px solid #000">
            <div  style="font-size: 14px; color: #000;width: 70%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Gr Wt</div>
            </div>
            <div style="width:302px;float:left;min-height:15px;border-bottom: 1px solid #000;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
               </div>
            </div>
                </div>
        </div>
        <div style="float:left;width:100%">
            <div style="width:12.5%;float:left;min-height:15px;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">  </div><%--PoS--%>
            </div>
            <div style="width:36%;float:left;min-height:15px;border-right:1px solid #000">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
              </div>
            </div>
            <div style="width:14.2%;float:left;min-height:15px;border-right:1px solid #000">
            <div style="font-size: 14px; color: #000;width: 20%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;"></div>
            
            <div style="width:302px;float:left;min-height:15px;">
            <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 4px 14px;">
                </div>
            </div>
                </div>
        </div>
        </div>

    </div>
    <div style="width:100%;float:left;border-top:1px solid #000;min-height: 15px;border-bottom: 1px solid #000;">
    <div style="font-size: 14px; color: #000;width: 8%; float: left;padding: 7px 0px 5px 3px;font-weight: bold;">Remarks</div>
    <div style="float: left;font-size: 14px;margin: 5px 0px 0px 0px;color: #2c2b2b;padding: 3px 0px 5px 14px;width:85%">
        <asp:Label ID="lbl_remarks" runat="server" /></div>
    </div>

    <div style="width:100%;float:left;min-height: 15px;padding: 7px 0px 5px 3px;">
       
        </div>

 
      
  




    </div>
 
         <br />
         <br />
         <br />
         <p>Please come back to us if there is any discrepancy in invoice within 3 days of Receipt of this invoice,delay in our payment will attract interest 18% PA</p>
         
   
         </div>
  

       
 


       <%-- <br/>
       <br />
           <br/>
       <br />
           <br/>
       <br />
           <br/>
       <br />--%>

<%--        end--%>
             
    </form>
</body>
</html>
