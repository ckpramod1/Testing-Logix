<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AEBLOriginal.aspx.cs" Inherits="logix.Reportasp.AEBLOriginal" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>AWBL</title>


    <style>
        * {
            margin: 0;
            padding: 0;
            font-size: 14px;
            box-sizing: border-box;
            font-family: sans-serif;
        }

        .div_left1 {
            width: 45%;
            float: left;
            border-right: 2px solid black;
            min-height: 386px;
        }

        .div_right1 {
            width: 55%;
            float: left;
            min-height: 149px;
        }

        .div_left11 {
            float: left;
            width: 55.1%;
        }

        .div_left12 {
            width: 44.8%;
            float: left;
            min-height: 55px;
            border-left: 2px solid black;
            border-bottom: 2px solid black;
        }

        .div_left2 {
            float: left;
            width: 45%;
            border-right: 2px solid black;
            min-height: 30px;
        }

        .div_right2 {
            width: 55%;
            float: left;
        }

        .Heading {
            font-size: 14px;
            font-weight: bold;
        }

        img {
            width: 75px;
            height: 44px;
            float: left;
        }

        .divleft3 {
            width: 45%;
            float: left;
            border-right: 2px solid black;
        }

        .divright3 {
            width: 55%;
            float: left;
        }

        .center {
            text-align: center;
        }

        .divleft4 {
            width: 45%;
            float: left;
            border-right: 2px solid black;
        }

        .divright4 {
            width: 55%;
            float: left;
        }

        table {
            border-collapse: collapse;
        }

        tr {
            border-bottom: 2px solid black;
        }

        th {
            border-right: 2px solid black;
            padding: 1px;
        }

        table tbody td {
            text-align: center;
        }

        .label {
            margin-top: 26px;
        }

        thead tr {
            border-bottom: 0px !important;
        }




        tbody tr:nth-child(1) td {
            height: 220px !important;
        }

        tbody tr:nth-child(2) td {
            height: 50px !important;
        }

        thead {
            border-bottom: 2px solid black;
        }

        tbody tr:nth-child(2) {
            border-bottom: 2px solid black;
        }

        table tbody tr:nth-child(1) {
            border: 0px !important;
        }

        table tbody tr:nth-child(2) {
            border: 0px !important;
        }

        @media print {
            .border {
                border-bottom: 1px solid black !important;
            }
        }

        .span1 {
            font-weight: bold;
            position: relative;
            top: 846px;
            left: 220px;
        }

        .span2 {
            position: relative;
            top: 863px;
            left: 125px;
        }

        .span3 {
            position: relative;
            top: 865px;
            left: 219px;
            display: block;
            width: 30%;
        }

        .span4 {
            position: relative;
            top: 1046px;
            left: 241px;
            width: auto;
            display: block;
        }

        .span5 {
            font-size: 59px;
            color: #c0c0c0;
            position: absolute;
            top: 906px;
            left: 313px;
        }

        span#descn {
            white-space: pre-line;
        }
        span#sname,span#saddress,span#cname,span#caddress,span#n1name,span#n1address{
    display: block !important;
    font-size:12px
} 
        span#lbllength {
    white-space: nowrap;
}
    </style>
</head>


<body>
               
    <div style="width:1024px;margin: 0px auto;position:relative">

        <span id="hid_n2" runat="server">
                          <span  class="span1">II Notify Party</span>
<%--<span >AJS DIGITAL TECHNOLOGY LIMITED</span>--%>
        <asp:Label ID="lbl_n2name" class="span2" runat="server"></asp:Label>
        <asp:Label ID="lbl_n2add" class="span3" runat="server"></asp:Label></span>

<%--<span class="span3">UNIT E,29F CHINA ENERGY STORAGE TOWER,NO.3099, KEYUAN </span>
<span class="span4">ROAD, NANSHAN DISTRICT, SHENZHEN,CHINA,SHENZHEN</span>--%>

        <span id="lbl_draft" runat="server" class="span5">DRAFT</span>
        <div style="width:100%;float:left;">
        <div style="float: left;margin-right: 32%;"><p class="Heading"><asp:Label ID="hawblno2" runat="server"> </asp:Label></p></div>
        <div style="float: left;"><p  class="Heading">HOUSE AIR WAYBILL</p></div>
        <div style="float: right;"><p  class="Heading"><asp:Label ID="hawblno3" runat="server"></asp:Label>
        </p></div>
        </div>
    <div style="border:2px solid black;float: left;width:100%;margin-bottom: 10px;">
    
        <div style="width:100%;float: left;">
           
        <div class="div_left1">
            <div style="width: 100%;border-bottom: 2px solid black;float: left;min-height:120px;"> 
            <div class="div_left11">
                <p class="Heading" style="padding: 12px 0px 0px 10px;">Shipper's Name & Address  </p>
               <div style="padding: 10px 0px 0px 10px;">
                <span>
                    <asp:Label ID="sname" runat="server" Text="Label"></asp:Label> <asp:Label ID="saddress" runat="server" Text="Label"></asp:Label></span>
               </div>
            </div>
            <div class="div_left12">
                <div class="div_left_13">
                    <p class="Heading" style="padding: 12px 0px 0px 4px;">Shipper's Account Number</p>
                    <div style="padding: 10px 0px 0px 10px;">
                        <asp:Label id="label1" runat="server" />
                    </div>
                </div>
            </div>
            </div>
            <div style="width: 100%;float: left;;border-bottom: 2px solid black;min-height:120px;">
                <div class="div_left11">
                    <p class="Heading" style="padding: 12px 0px 0px 10px;">Consignee's Name & Address</p>
                    <div style="padding: 10px 0px 0px 10px;">
                       
                        <asp:Label ID="cname" runat="server" > </asp:Label>
                        <asp:Label ID="caddress" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="div_left12">
                    <div class="div_left_13">
                        <p class="Heading" style="padding: 12px 0px 0px 4px;">Consignee's Account Number</p>
                        <div style="padding: 10px 0px 0px 10px;">
                            <asp:Label ID="Label3" runat="server"> </asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 100%;float: left;min-height: 120px;;">
                <div id="hd_n1" runat="server" class="div_left11" style="width: 100%;">
                    <p class="Heading" style="padding: 12px 0px 0px 10px;">Notify Party</p>
                    <div style="padding: 10px 0px 0px 10px;">
                      
                            <asp:Label ID="n1name" runat="server">
                            </asp:Label>
                        <asp:Label ID="n1address" runat="server" ></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        
        
        
        <div class="div_right1">
            <div style="width: 100%;float: left;min-height: 137px;border-bottom: 2px solid black;">
            <p class="Heading" style="padding: 5px 0px 0px 10px;">Not Negotiable AIR WAYBILL issued by :</p>
            <div style="width: 100%;float: left;margin: 27px 0px 0px 75px;">
                <asp:Image ID="img_Logo" runat="server"/>
                <p class="Heading" style="margin-left: 10px !important;float: left;font-size: 18px;margin-top: 10px;">
                    <asp:Label ID="branchname" runat="server"></asp:Label></p>

            </div>
            <div style="margin: 12px 0px 0px 60px;float: left;"> <asp:Label ID="address" runat="server"></asp:Label></div>
            </div>
            <div style="width:100%;float: left;border-bottom: 2px solid black;">
            <p style="padding: 19px 0px 21px 10px;font-size: 13px;">Copies:1,2 and 3 of htis Air Waybill are originals and have the same validity</p>
            </div>

            <div style="width:100%;float: left;">
                <p style="padding: 2px 0px 0px 10px;;
                font-size: 11px;">It is agreed that the goods descriped herein are accepted in apparent good order and conditions.(EXCEPT as noted) for
                carriage SUBJECT TO ThE CONDITONS OF CONTRACT ON THE REVERSE HEREOF. ALL GOODS MAY BE ANY OTHER MEANS INCLUDING ROAD OR
                ANY OTHER CARRIERUNLESS SPECIFIC CONTRARY INSTRUCTIONS ARE GIVEN HEREON BY THE SHIPPER.THE SHIPPER'S ATTENTION IS DRAWN
                TO THE NOTICE CONCERNING CARRIER'S LIMITATION OFLIABILITY.SHIPPER may increase of limitation of liability by declaring a
                higher value for carriage and paying a supplemental charge if requeried</p>
            </div>
            <p class="Heading" style="margin: 10px 0px 0px 10px !important;float: left;">Accounting Information</p>
            <p style="width: 100%;float: left;margin: 10px 0px 0px 10px"><asp:Label ID="freight" runat="server"></asp:Label></p>

           
                <p class="Heading" style="width: 100%;float: left;padding: 6px 0px 0px 11px;border-top: 2px solid black;">
FOR DELIVERY
                </p>
                <div style="width:100%;float: left;">
                    <p  class="Heading" style="float: left;margin: 8px 2px 0px 10px;">MAWB</p>
                    <p class="Heading"  style="float: left;float: left;margin: 8px 2px 0px 10px;">:</p>
                    <p  class="Heading"  style="float: left;float: left;margin: 8px 7px 0px 10px;"><asp:Label ID="mawblno" runat="server"></asp:Label></p>
                </div>
                <div style="width:100%;float: left;">
                    <p class="Heading" style="float: left;margin: 5px 2px 0px 10px;">HAWB</p>
                    <p class="Heading" style="float: left;float: left;margin: 5px 2px 0px 10px;">:</p>
                    <p class="Heading" style="float: left;float: left;margin: 5px 7px 0px 13px;"><asp:Label ID="hawblno4" runat="server"></asp:Label></p>
                </div>
            
        </div>


       <div style="width:100%;float: left;border-top: 2px solid black;">
        <div class="div_left2">
        <p class="Heading" style="padding: 4px 0px 0px 10px;">Airport of Departure(Addr.of First Carrier) and Requested Routing</p>
        <p style="padding: 4px 0px 0px 10px;"><asp:Label ID="poldetails" runat="server"> </asp:Label></p>
        </div>
        <div class="div_right2">
            <div style="float: left;width: 30%;border-right: 2px solid black;min-height: 41px;">
            <p style="padding: 4px 0px 0px 10px;">Reference Number</p>
            <p style="padding: 4px 0px 0px 10px;"><asp:Label ID="Label9" runat="server"> </asp:Label></p>
        </div>
            <div style="float: left;width:46%;border-right: 2px solid black;min-height: 41px;">
                <p class="Heading" style="padding: 0px 0px 1px 28px;border-bottom: 2px solid black;">Optional Shipping Information</p>
                <p><asp:Label ID="Label10" runat="server"> </asp:Label></p>
            </div>
            <div style="float: left;width:30%"></div>
        </div>
        </div>

        <div  style="width:100%;float: left;border-top: 2px solid black;min-height: 46px">
        <div class="divleft3">
            <div style="width: 9.5%;float: left; border-right: 2px solid black; min-height: 56px; background: #c0c0c0;"> 
            <p class="Heading" style="margin: 4px 0px 0px 10px;">To</p>
            <p class="Heading" style="margin: 5px 0px 0px 6px;"><asp:Label ID="airportcode1" runat="server"> </asp:Label></p>
        </div>
        <div style="width: 57%;float: left; border-right: 2px solid black; min-height: 56px;">
        
            <div style="width:44%;float: left;">
            <p class="Heading" style="margin: 4px 0px 0px 10px;">By First Carrier</p>
            <p style="margin: 4px 0px 0px 10px;"><asp:Label ID="customername" runat="server"></asp:Label></p>
            </div>
            <div style="width:56%;float: left;min-height: 33px; border-left: 2px solid black;border-bottom: 2px solid black;">
            <p class="" style="margin: 4px 0px 0px 6px;">Routing & Destination</p>
            <p><asp:Label ID="Label13" runat="server"> </asp:Label></p>
            </div>
        
        </div>
        <div style="width: 8.5%;float: left; border-right: 2px solid black; min-height: 56px; background: #c0c0c0;">
            <p class="Heading" style="margin: 4px 0px 0px 10px;">To</p>
            <p class="Heading" style="margin: 5px 0px 0px 5px;"><asp:Label ID="airportcode2" runat="server"> </asp:Label></p>
        </div>
        <div style="width: 8.5%;float: left; border-right: 2px solid black; min-height: 56px; background: #c0c0c0;">
            <p class="Heading" style="margin: 4px 0px 0px 10px;">By</p>
            <p class="Heading" style="margin: 5px 0px 0px 5px;"><asp:Label ID="lbl_short2" runat="server"> </asp:Label></p>
        </div>
        <div style="width: 8.5%;float: left; border-right: 2px solid black; min-height: 56px; background: #c0c0c0;">
            <p class="Heading" style="margin: 4px 0px 0px 10px;">To</p>
            <p class="Heading" style="margin: 5px 0px 0px 5px;"><asp:Label ID="airportcode3" runat="server"> </asp:Label></p>
        </div>
        <div style="width: 7.9%;float: left; min-height: 56px; background: #c0c0c0;">
            <p class="Heading" style="margin: 4px 0px 0px 10px;">By</p>
            <p class="Heading" style="margin: 5px 0px 0px 5px;"><asp:Label ID="lbl_short3" runat="server"> </asp:Label></p>
        </div>
        </div>
        <div class="divright3">
            <div style="width:11%;float: left;border-right: 2px solid black;min-height: 56px;">
            <p class="Heading" style="text-align: center;">Currency</p>
            <p><asp:Label ID="curr" runat="server"> </asp:Label></p>
            </div>
        <div style="width:8%;float: left;border-right: 2px solid black;min-height: 56px">
            <p class="Heading"  style="text-align: center;">CHGS Code</p>
            <p style="text-align: center;margin-top: 4px;"><asp:Label ID="chgcode" runat="server"> </asp:Label></p>
        </div>


        <div style="width:17%;float: left;border-right: 2px solid black;min-height: 56px">
        <p  class="Heading" style="border-bottom: 2px solid black;text-align: center;">WT/VAL</p>


        <div style="width:100%;float:left">


            <div style="width:50%;float:left;    min-height: 39px;border-right:2px solid black;">
              <p style="float: left;width:100%;text-align: center;">PPD</p>
            <p class="center"><asp:Label ID="wtvalp" runat="server"> </asp:Label></p>
                </div>
            <%--<div style="clear:both"></div>--%>

            <div style="width:50%;float:left">
              <p style="float: left;width:100%;text-align: center;">COLL</p>
              <p style="text-align:center"><asp:Label ID="wtvalc" runat="server"> </asp:Label></p>
                </div>
            <div style="clear:both"></div>

        </div>



        </div>
        <div style="width:17%;float: left;border-right: 2px solid black;min-height: 56px">
            <p class="Heading" style="border-bottom: 2px solid black;text-align: center;">Other</p>
            <div style="width:100%">
                 <div style="width:50%;float:left;    min-height: 39px;border-right:2px solid black;">

                <p style="float: left;width:100%;text-align: center;">PPD</p>
                <p class="center"><asp:Label ID="othervalp" runat="server"> </asp:Label></p>
</div>
            <div style="width:50%;float:left">

                <p style="float: left;width:100%;text-align: center;">COLL</p>
                <p class="center"><asp:Label ID="othervalc" runat="server"> </asp:Label></p>
                </div>
                
            </div>
        </div>
        <div style="width:23%;float: left;border-right: 2px solid black;min-height: 56px">
             <p class="Heading" style="text-align: center;">Declared Value for Carriage</p>
    

    <p class="center" ><asp:Label ID="lbl_nvd" runat="server"></asp:Label></p>
        </div>
        <div style="width:24%;float: left;min-height: 54px">
        <p class="Heading center">Declared Value for Customs</p>
        <p class="center"><asp:Label ID="lbl_nvc" runat="server"></asp:Label></p>
        </div>



        </div>
        </div>

        <div style="width:100%;float: left;border-top: 2px solid black;min-height: 50px;">
        <div class="divleft4">
            <div style="width:35%;float: left;border-right: 2px solid black;min-height: 81px;">
            <p class="Heading center" style="margin-top: 15px;" >Airport of Destination</p>
            <p class="center" style="padding: 11px 0px 15px 14px;"><asp:Label ID="poddetails" runat="server"> </asp:Label></p>
        </div>



       
            <div style="width:65%;float: left;min-height:71px;">
            <div style="min-height:20px">
                <div style="width:30px;float: left;"></div>
                <div style="    float: left; margin-left: 78px; border-left: 2px solid black;border-bottom: 2px solid black;width: 149px;text-align: center;border-right: 2px solid black;padding: 4px;">
                    <p class="Heading">For Carrier Use only</p>
                </div>
                <div style="float: left;width:100%">
                <div style="width:50%;float: left;border-right: 2px solid black;min-height: 56px;">
                    <p class="Heading" style="padding: 0px 0px 0px 5px;">Flight/Date</p>
                    <p style="padding: 8px 0px 0px 5px;display:flex">
                        <asp:Label ID="lbl_flno" runat="server"></asp:Label>  <asp:Label ID="flightdate" runat="server"> </asp:Label></p>
                </div>
                <div style="width:25%;float: left;margin-left: 69px;min-height: 47px;" >
                <p class="Heading" >Flight/Date</p>
                <p style="    padding: 8px 0px 0px 5px;
    display: flex;
    margin-left: -59px;">
                    <asp:Label ID="Label25" runat="server"> </asp:Label>  <asp:Label ID="Label2" runat="server"> </asp:Label></p>
                </div>
            </div>
        
        </div>
        </div>
      
    </div>
              <div class="divright4">

      <div style="width:27.5%;float: left;border-right: 2px solid black;min-height: 81px;">
      
          <p class="Heading center">Amount of Insurance</p>
          <p class="center"  style="margin-top: 21px;" ><asp:Label ID="insamt" runat="server"> </asp:Label></p>
      </div>
      <div style="width:71%;float: left;font-size:11px !important;">
      <p style="margin: 11px 0px 0px 5px;font-size:11px !important;">INSURANCE : it careers offers insurance and such insurance ie requested in accordance with conditions on reverse hereof.
      Indicate amount to be insured in figures in box marked "Amount of Insurance"</p></div>
  </div>
    <div style="width:100%;float: left;border-top: 2px solid black;padding: 15px 0px 15px 13px;border-bottom: 2px solid black;">
    
        <p style="float: left;padding-right:5px;"  class="Heading">Handling Information  </p>
        <p style="float: left;" ><asp:Label ID="lbl_handinfo" runat="server"> </asp:Label></p>
        
    </div>
       </div>
    


       <div style="width:100%;float: left;">
<table class="w3-table w3-border w3-bordered">
        <!-- Table Headings -->
        <thead>
        <tr style="border-bottom: none;">
            <th style="width:80px;">No. of Pieces RCP</th>
            <th style="width:74px;">Gross Weight</th>
            <th style="width:45px;">Kg LB</th>
            <th style="padding: 2px;background: #c0c0c0;width: 10px;"></th>
            <th style="border-right: none;"></th>
            <th style="border-bottom: 2px solid black;vertical-align:text-bottom;padding-top:7px;">Rate Class</th>
            <th style="padding: 0px;background: #c0c0c0;width: 10px;"></th>
            <th style="width: 30px;">Chargeable
            Weight</th>
            <th style="padding: 0px;background: #c0c0c0;width: 10px;"></th>
            <th style="width: 30px;padding: 0px 0px 0px 0px;">Rate /
            Charge</th>
            <th style="padding: 0px;background: #c0c0c0;width: 10px;"></th>
            <th style="padding: 0px 0px 0px 0px;width:62px;">Total</th>
            <th style="padding: 0px;background: #c0c0c0;width: 10px;"></th>
            <th style="width: 525px; border-right: 0px">Nature and Quantity of goods <br>
            (Incl.Dimensind or volume)</th>
      
           
        </tr>
        <tr>
            <th style="border-right:2px solid black;padding:0px;"></th>
            <th style="border-right:2px solid black;padding: 0px;"></th>
            <th style="border-right:2px solid black;padding: 0px;"></th>
            <th style="border-right:2px solid black;padding: 0px;background-color: #c0c0c0; border-left: 2px solid black;"></th>
            <th></th>
            <th style="border-right:none;padding: 0px 0px 0px 0px;" colspan="1">
             
            Commodity
            Item No.
        </th>
        <th style="padding: 0px;background: #c0c0c0;width: 10px; border-left: 2px solid black;"></th>
        <th></th>
        <th style="padding: 0px;background: #c0c0c0;width: 10px;"></th>
        <th></th>
        <th style="padding: 0px;background: #c0c0c0;width: 10px;"></th>
        <th></th>
        <th style="padding: 0px;background: #c0c0c0;width: 10px;"></th>
        <th style="width: 390px; border-right: 0px"></th>
    </tr>
    </thead>
       
        <tbody>
        <tr>
          <td style="border-right: 2px solid black;vertical-align:text-top;">            <asp:Label ID="pkgs" runat="server"></asp:Label></td>

          <td style="border-right: 2px solid black;vertical-align:text-top;">            <asp:Label ID="grosswt" runat="server" ></asp:Label></td>

          <td style="border-right: 2px solid black;vertical-align:text-top;">            <asp:Label ID="wttype" runat="server" ></asp:Label></td>

          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;"></td>
          <td style="border-right: 2px solid black;"></td>
          <td style="border-right: 2px solid black;vertical-align:text-top;">            <asp:Label ID="citemno" runat="server" ></asp:Label></td>

          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;"></td>
          <td style="border-right: 2px solid black;vertical-align:text-top;">            <asp:Label ID="chargewt" runat="server"></asp:Label></td>

          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;"></td>
          <td style="border-right: 2px solid black;vertical-align:text-top;">            <asp:Label ID="rateclass" runat="server"></asp:Label></td>

          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;"></td>
          <td style="border-right: 2px solid black;vertical-align:text-top;">            <asp:Label ID="total" runat="server"></asp:Label></td>

          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;">            </td>
                      <td style="vertical-align: text-top;
    text-align: left;
    padding-left: 7px;">            <asp:Label ID="descn" runat="server"></asp:Label></td>
          <td></td>
        </tr>

        <tr>
          <td style="border-right: 2px solid black;border-top:2px solid black;border-bottom:2px solid black;">            <asp:Label ID="pkgs2" runat="server" ></asp:Label></td>

          <td style="border-right: 2px solid black;border-top:2px solid black;border-bottom:2px solid black;"></td>
          <td style="border-right: 2px solid black;border-bottom:1px solid black;"></td>
          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;border-bottom:2px solid black;"></td>
          <td style="border-right: 2px solid black;border-bottom:2px solid black;"></td>
          <td style="border-right: 2px solid black;border-bottom:2px solid black;">
    
          </td>
          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;border-bottom:2px solid black;">
            
          </td>
          <td style="border-right: 2px solid black;border-bottom:2px solid black;"></td>
          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;border-bottom:2px solid black;"></td>
          <td style="border-right: 2px solid black;border-bottom:2px solid black;"></td>
          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;border-bottom:2px solid black;"></td>
          <td style="border-right: 2px solid black;border-top:2px solid black;border-bottom:2px solid black;">            <asp:Label ID="total2" runat="server" Text="Label"></asp:Label></td>

          <td style="padding: 2px;background: #c0c0c0;width: 10px;border-right: 2px solid black;border-bottom:2px solid black;"></td>
          <td >
              <p style="font-weight:bold;text-align:left;margin:0px 0px 0px 15px;">Dimension in cms <br /> Length / Breadth / Width / Pieces</p>
          </td>
        </tr>
        </tbody>
    </table>

       </div>



    <div style="width:100%;float: left;">
    <div style="width:51.7%;float:left;border-right: 2px solid black;min-height: 30px;">
    <div style="width:79%;float: left;border-right: 2px solid black;min-height: 30px;">

    <div style="width:100%;float: left;">
    <div style="float: left;width:114px;border-bottom: 2px solid black;border-right: 2px solid black;text-align: center;padding: 5px;"><p>Prepaid</p></div>
   
    <div style="float: left;width:114px;border-bottom: 2px solid black;border-right: 2px solid black;text-align: center;padding: 5px; border-left: 2px solid black;margin-left: 24px;"><p>Weight Charge</p></div>
 
    <div style="float: left;width:137px;border-bottom: 2px solid black; border-left: 2px solid black;text-align: center;padding: 5px;margin-left: 24px"><p>Collect</p></div>
    </div>
    <div style="width:100%;float: left;">
        <div style="width:50%;float:left;border-right:2px solid black ;min-height: 23px;text-align: center">
            <p style="margin-top: 0px;"><asp:Label ID="ratep" runat="server"> </asp:Label></p>
        </div>
        <div style="width:50%;float:left;min-height: 23px;text-align: center;">
        <p>
            <asp:Label ID="ratec" runat="server"> </asp:Label>
        </p>
        </div>
    </div>
    <div style="width:100%;float: left;border-top: 2px solid black;">
        <div style="float: left;width:114px;text-align: center;padding: 5px;">
            <p></p>
        </div>
    
        <div
            style="float: left;width:159px;border-bottom: 2px solid black;border-right: 2px solid black;text-align: center;padding: 5px; border-left: 2px solid black;margin-left: 50px;">
            <p>Valuation Charge</p>
        </div>
    
        <div style="float: left;width:112px;text-align: center;padding: 5px;margin-left: 53px">
            <p></p>
        </div>
    </div>
    <div style="width:100%;float: left;">
        <div style="width:50%;float:left;border-right:2px solid black ;min-height: 23px;text-align: center">
            <p style="margin-top: 0px;">
                <asp:Label ID="wcp" runat="server"> </asp:Label>
            </p>
        </div>
        <div style="width:50%;float:left;min-height: 23px;text-align: center;">
            <p style="margin-top: 0px;">
                <asp:Label ID="wcc" runat="server"> </asp:Label>
            </p>
        </div>
    </div>
    <div style="width:100%;float: left;border-top: 2px solid black;">
        <div style="float: left;width:114px;text-align: center;padding: 5px;">
            <p></p>
        </div>
    
        <div
            style="float: left;width:114px;border-bottom: 2px solid black;border-right: 2px solid black;text-align: center;padding: 5px; border-left: 2px solid black;margin-left: 70px;">
            <p>Tax</p>
        </div>
    
        <div style="float: left;width:112px;text-align: center;margin-left: 75px">
            <p></p>
        </div>
    </div>
    <div style="width:100%;float: left;">
        <div style="width:50%;float:left;border-right:2px solid black ;min-height: 22px;text-align: center">
            <p style="margin-top: 0px;">
                <asp:Label ID="Label32" runat="server"> </asp:Label>
            </p>
        </div>
        <div style="width:50%;float:left;min-height: 23px;text-align: center;">
            <p style="margin-top: 0px;">
                <asp:Label ID="Label33" runat="server"> </asp:Label>
            </p>
        </div>
    </div>
    </div>

<div style="width: 21%;float: left;text-align: center;min-height: 156px;" >

    <p class="Heading" style="margin-top: 10px;">Other Charges</p>
    <p style="margin-top: 20px;"><asp:Label ID="otherchg" runat="server" > </asp:Label></p>
</div>
</div>
<div style="width:25%;float: left;">
    <p style="display: inline-block;margin: 0px 0px 0px 17px;">
                    <asp:Label ID="lbllength" runat="server" ></asp:Label> 
        </p>
</div>
    
    </div>



    <div style="width:100%;float: left;">
    <div style="width:51.7%;float: left;border-right:2px solid black;">
   
    <div style="width:100%;float: left;border-top: 2px solid black;">
        <div style="float: left;width:114px;text-align: center;padding: 5px;">
            <p></p>
        </div>
    
        <div
            style="float: left;width:230px;border-bottom: 2px solid black;border-right: 2px solid black;text-align: center;padding: 5px; border-left: 2px solid black;margin-left: 26px;">
            <p>Total Other Charges Due Agent</p>
        </div>
    
        <div style="float: left;width:0px;text-align: center;padding: 5px;margin-left: 82px">
            <p></p>
        </div>
    </div>
    <div style="width:100%;float: left;">
        <div style="width:50%;float:left;border-right:2px solid black ;min-height: 23px;text-align: center">
            <p style="margin-top: 0px;">
                <asp:Label ID="ocdap" runat="server"> </asp:Label>
            </p>
        </div>
        <div style="width:50%;float:left;min-height: 23px;text-align: center;">
            <p style="margin-top: 0px;">
                <asp:Label ID="ocdac" runat="server"> </asp:Label>
            </p>
        </div>
    </div>
    <div style="width:100%;float: left;border-top: 2px solid black;">
        <div style="float: left;width:114px;text-align: center;padding: 5px;">
            <p></p>
        </div>
    
        <div
            style="float: left;width:231px;border-bottom: 2px solid black;border-right: 2px solid black;text-align: center;padding: 5px; border-left: 2px solid black;margin-left: 26px;">
            <p>Total Other Charges Due Carrier</p>
        </div>
    
        <div style="float: left;width:0px;text-align: center;padding: 5px;margin-left: 82px">
            <p></p>
        </div>
    </div>
    <div style="width:100%;float: left;">
        <div style="width:50%;float:left;border-right:2px solid black ;min-height: 23px;text-align: center">
            <p style="margin-top: 0px;">
                <asp:Label ID="ocdcp" runat="server"> </asp:Label>
            </p>
        </div>
        <div style="width:50%;float:left;min-height: 23px;text-align: center;">
            <p style="margin-top: 0px;">
                <asp:Label ID="ocdcc" runat="server"> </asp:Label>
            </p>
        </div>
    </div>

    <div style="width:100%;float: left;min-height: 62px;background-color: #c0c0c0;border-top: 2px solid black;"></div>
    <div style="width: 100%;float: left;min-height: 49px;border-top: 2px solid black;">
    <div style="width:50%;float: left;border-right: 2px solid black;min-height: 49px; text-align: center;">
    
        <p class="Heading"  style="margin-top: 6px;">Total Prepaid</p>

        <p style="margin-top: 4px;">
            <asp:Label ID="totalp" runat="server"> </asp:Label>
        </p>
    </div>
    <div style="width:50%;float: left;text-align: center">
    <p class="Heading"  style="margin-top: 6px;">Total Collect</p>
    
    <p style="margin-top: 6px;">
        <asp:Label ID="totalc" runat="server"></asp:Label>
    </p></div>
    </div>
    <div style="width: 100%;float: left;min-height: 49px;border-top: 2px solid black;background-color: #c0c0c0;">
        <div style="width:50%;float: left;border-right: 2px solid black;min-height: 49px; text-align: center;">
    
            <p class="Heading"  style="margin-top: 6px;">CurrencyConverstion Rates</p>
    
            <p style="margin-top: 4px;">
                <asp:Label ID="Label41" runat="server"></asp:Label>
            </p>
        </div>
        <div style="width:50%;float: left;text-align: center;">
            <p class="Heading" style="margin-top: 7px;">CC Charges in Dest Currency</p>
    
            <p style="margin-top: 4px;">
                <asp:Label ID="Label42" runat="server"></asp:Label>
            </p>
        </div>
    </div>

    <div style="width: 100%;float: left;min-height: 60px;border-top: 2px solid black;background-color: #c0c0c0;" class="border" >
        <div style="width:50%;float: left;border-right: 2px solid black;min-height: 58px; text-align: center;">
    
            <p class="Heading" style="margin-top: 7px;">For Carrier Use only at Destination</p>
    
            <p style="margin-top: 4px;">
                <asp:Label ID="Label43" runat="server"> </asp:Label>
            </p>
        </div>
        <div style="width:50%;float: left;text-align: center">
            <p class="Heading" style="margin-top: 7px;">Charges at Destination</p>
    
            <p style="margin-top: 4px;">
                <asp:Label ID="Label44" runat="server"></asp:Label>
            </p>
        </div>
    </div>
</div>
    <div style="width: 48.2%;float: left;border-top: 2px solid black;min-height: 169px;">

        <div style="min-height: 152px;border-bottom: 2px solid black">
    <p style="margin: 16px 40px 0px 11px;font-size:11px;">Shipper certifies that the particulars on the face hereof are correct and that insofar as any part of the consignment
    contains dangerous goods, such part is properly described by name and is in proper conditionfor carriage by air
    according to the applicable Dangerous Goods Regulations.</p>

<div style="width: 100%;text-align: center;float: left;margin-top: 68px;">
    <div style="width:73%;margin: 0 auto;">
    <p><asp:Label ID="branchname1" runat="server"></asp:Label></p>
    <p style="width:100%;float:left;border: 1px solid black;"></p>
    <p>Signature of Shipper or his Agent</p>
    </div>
    </div>
    </div>

    <div style="width:100%;float: left;">
    <div style="width:30%;float:left;min-height: 60px;padding-left: 17px;">
    <p><asp:Label ID="issuedon" runat="server"></asp:Label></p>

    <p class="label">Executed On(Date)</p>
    </div>
    <div style="width:19%;float:left;min-height: 60px;">
    <p>
        <asp:Label ID="portname" runat="server"></asp:Label>
    </p>
    
    <p class="label">at(Place)</p></div>
    <div style="width:50%;float:left;min-height: 60px;">
    <p>
        <asp:Label ID="Label48" runat="server"></asp:Label>
    </p>
    
    <p class="label" style="padding-top: 14px;">Signature of issuing Carrier otr its agent</p>
    </div>
</div>


<div style="width: 100%;float: left;margin-top: 0px;border-top: 2px solid black;">
<div style="width:36%;float: left;min-height: 82px;border-right: 2px solid black;text-align: center;">
<p class="Heading" style="padding: 5px 0px 0px 0px;">Total Collect Charges</p>
<p><asp:Label ID="Label49" runat="server"> </asp:Label></p>
</div>
<div style="width:64%;float: left;min-height: 38px;display: flex;">
<span style="display: block;padding: 7px 0px 0px 27px;"><p class="Heading" style="float: left;    margin-right: 10px;" >HAWB No</p><p style="float: left;">:</p><p style="float: left;"><asp:Label ID="hawblno1" runat="server"> </asp:Label></p></span>
</div>
</div>
    </div>


    </div>
    </div>




    </div>
   <asp:Label ID="stationery" runat="server"></asp:Label>
</body>
</html>
