<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentFARpt.aspx.cs" Inherits="logix.Reportasp.PaymentFARpt" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title></title>



    <style type="text/css">
        .TableHeader thead {
            display: table-header-group;
        }

        .div_right {
            float: right;
            width: 19%;
        }

        .div_left {
            float: left;
            width: 79%;
        }

        div#CheckVisible {
            display: none;
        }

        img#lbl_wiz {
            width: 75px !important;
            height: auto !important;
        }

        div#tblVouDtls table {
            background: #d3d3d336 !important;
            padding: 0px 5px 0px 5px;
        }

        @media print {
            .borderright {
                border-right: 4px solid black !important;
            }
        }
    </style>
</head>

<body style="margin:0px; padding:0px; font-family:Tahoma, Geneva, sans-serif; font-size:14px; color:#000; line-height:18px;">
            <form id="form1" runat="server">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="width:1024px; margin:0px auto;">
      <div id="CheckVisible" runat="server" visible="true" style="margin:20px auto 360px auto;">
<div style="float:right; width:120px; padding:5px; margin:-25px 70px 0px 0px; text-align:right; font-weight:bold; font-size:16px; letter-spacing:10px;"><asp:Label ID="lbl_date" runat="server"></asp:Label></div>
    <div style="width:1024px;">
        <h1 style="font-size:18px; text-align:left; padding:50px 0px 20px 100px; margin:0px;"><asp:Label ID="lbl_cust" runat="server"></asp:Label></h1>

        <div style="width:1024px; float:left; text-align:left;"><p style="float:left; width:710px; text-align:left; padding:5px; margin:0px 0px 20px 130px; font-weight:bold;"><asp:Label ID="lbl_totword" runat="server"></asp:Label>‎</p>

             <div style="float:right; width:120px; padding:5px; margin:-5px 110px 15px 0px;text-align:right; font-weight:bold; font-size:16px;"><asp:Label ID="lbl_tot" runat="server"></asp:Label>
</div>
</div>
       
    </div>
    </div>
<div style="width:1024px; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000;" class="borderright" >
<div style="float:left; text-align:center; width:1024px; border-top:0px solid #000; border-bottom:1px solid #000;">
<div style="float:right; width:70px; padding:0px; margin:5px 5px 0px 0px; text-align:right; font-size:11px;"><asp:Label ID="lblToday" runat="server"></asp:Label></div>
<div style="clear:both;"></div>
<div style="float:left; width:1024px;">
    <div style="float:left; padding:5px 5px; margin:-15px 0px 10px 10px;"><asp:Image ID="img_Logo" runat="server" width="269" height="54"/><asp:Image  ID="lbl_wiz" runat="server" Width="90" Height="90" /></div>
<h3 style="text-transform:capitalize; font-family:'Segoe UI'; text-align:center; font-size:24px; font-weight:600; padding:5px 0px 5px 0px; margin:5px 0px 5px 146px;  float:left; width:535px;"><asp:Label ID="lblDivName" runat="server"></asp:Label></h3>
<div id="div_form" runat="server"  style="padding: 0px 0px 0px 0px;display:none">
                        <asp:Label ID="lblformaly" runat="server"  Text="(formerly known as M+R LOGISTICS (INDIA) PRIVATE LIMITED)"></asp:Label><br/>
                       </div>
<p style="font-size:14px; color:#000; line-height:18px; WIDTH:100%;  float:left; padding:0px 0px 5px 0px; margin:0px 0px 0px 146px; text-align:center; width:535px;">
<asp:Label ID="lblAddress" runat="server"></asp:Label><br>
<asp:Label ID="lblphonefax" runat="server"></asp:Label>
</p>
</div>

</div>
<div style="float:left; width:1024px; border-bottom:1px solid #000;">
<h4 style="font-family:'Segoe UI'; font-size:21px; padding:5px 0px 9px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
</div>
<div style="width:1024px; float:left;  padding-bottom:10px; ">

    <div class="div_right">
<div style="float: left;width: 82px;margin: 5px 7px 5px 10px;font-weight: bold;"><asp:Label ID="lblRecPayno" runat="server"></asp:Label></div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;display: none;">:</div>
<div style="float: left;width: 90px;margin: 5px 5px 5px 0px;"><asp:Label ID="lblRecno" runat="server"></asp:Label></div>
<div style="clear:both;"></div>
<div style="float: left;width: 39px;margin: 5px 7px 5px 52px;font-weight: bold;"><asp:Label ID="lblRecPayDate" runat="server"></asp:Label> </div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;display: none;">:</div>
<div style="float: left;width: 90px;margin: 5px 5px 5px 0px;"><asp:Label ID="lblRecDate" runat="server"></asp:Label></div>
<div style="clear:both;"></div>
    </div>

    <div class="div_left">
<div style="float:left; width:103px; margin:5px 7px 5px 10px; font-weight:bold;"><asp:Label ID="lblRecFromPaidTo" runat="server"></asp:Label> </div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;display: none;">:</div>
<div style="float:left; width:600px; margin:5px 5px 5px 0px;"><asp:Label ID="lblReceivedfrom" runat="server"></asp:Label></div>
<div style="clear:both;"></div>

   <%-- cheque--%>
        <div id="Chequelb" runat="server" visible="true">
    <div style="float:left; width:103px; margin:5px 7px 5px 10px; font-weight:bold;">Bank Ref #</div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;display: none;">:</div>
<div style="float:left; width:600px; margin:5px 5px 5px 0px;"><asp:Label ID="lblchequeno" runat="server"></asp:Label></div>
            </div>
<div style="clear:both;"></div>

    <div style="float:left; width:103px; margin:5px 7px 5px 10px; font-weight:bold;">Bank / Branch  </div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;display: none;">:</div>
<div style="float:left; width:600px; margin:5px 5px 5px 0px;"><asp:Label ID="lblbank" runat="server"></asp:Label></div>
<div style="clear:both;"></div>

    <div style="float:left; width:94px; margin:5px 7px 5px 10px; font-weight:bold; display:none">Prepared By </div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;display: none;">:</div>
<div style="float:left; width:600px; margin:5px 5px 5px 0px;; display:none"><asp:Label ID="lblpreparedby" runat="server"></asp:Label></div>
<div style="clear:both;"></div>



    </div>
 
<div style="float:right; width:120px;display:none">
<div style="float:left; width:auto; margin:5px 5px 5px 5px; text-align:right; font-weight:bold;"><label>ID</label></div>
<div style="float:left; width:2px; margin:5px 5px 5px 5px; text-align:right;">:</div>
<div style="float:left; width:auto; margin:5px 5px 5px 5px; text-align:right; font-weight:bold;"> <asp:Label ID="lblRecId" runat="server"></asp:Label></div>

</div>
</div>


 



    <div style="width:100%;float:left;border-top:1px solid #000">

         <div style="float:left; width:70px; margin:5px 7px 5px 10px; font-weight:bold;">Narration</div>
<div style="float:left; width:1px; margin:5px 11px 5px 0px;display:none;">:</div>
<div style="float:left; width:645px; margin:5px 5px 5px 0px;"><asp:Label ID="lblnarration" runat="server"></asp:Label></div>
<div style="clear:both;"></div>
    </div>


<div style="width:1024px; float:left; border-bottom:1px solid #000;">
<table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding:0px 0px 0px 0px; " class="TableHeader">
    <thead>
  <tr>
    <th style="padding:5px 5px 5px 80px; width:550px; margin:5px; text-align:left; border-right:1px solid #000; border-bottom:1px solid #000;border-top: 1px solid #000;text-align: center;" colspan="2">Account Head </th>
    
    <th style="padding:5px 0px 5px 5px; margin:5px 0px 5px 0px; text-align:center; border-bottom:1px solid #000;border-top: 1px solid #000; width:175px;">Amount Rs.</th>
  </tr>
        </thead>
 <asp:label ID="tr_Lblcustamount" runat="server"></asp:label>
  <tr>
    <td colspan="2" style=" padding:5px 5px 5px 5px; margin:5px; text-align:left; border-right:1px solid #000;border-bottom:0px solid #000">



        <div id="tblVouDtls" runat="server">

    <table width="850" border="0" cellspacing="0" cellpadding="0" style="border:0px solid #000; margin:20px 5px 10px 5px; float:right;" class="TblGrid ">

        <tr><th colspan="7" style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-left:0px solid #000; border-bottom:1px solid #000;">Aganist Ref #</th></tr>
  <tr>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:0px solid #000; width:80px;border-bottom: 1px solid #000;">Branch</th>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:0px solid #000; width:120px;border-bottom: 1px solid #000;">Our Ref No.</th>
       <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:0px solid #000; width:110px;border-bottom: 1px solid #000;">Vendor Ref #</th>
     <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:0px solid #000; width:80px;border-bottom: 1px solid #000;">Date</th>
       <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:0px solid #000; width:105px;border-bottom: 1px solid #000;text-align:right">Gross Rs.</th>
       <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:0px solid #000; width:120px;border-bottom: 1px solid #000;text-align:right">TDS  Rs.</th>
    <th style="padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:0px solid #000; border-bottom:0px solid #000; width:150px;border-bottom: 1px solid #000;text-align:right">Net  Rs.</th>
  </tr>
  
                            <asp:Label ID="tr_row" runat="server"></asp:Label>

  <tr>
    <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:0px solid #000;">&nbsp;</td>
    <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:0px solid #000;">&nbsp;</td>
      <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:0px solid #000;">&nbsp;</td>
     <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:0px solid #000;">&nbsp; </td>
       <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:0px solid #000; border-top:0px solid #000;"><asp:Label ID="lblGrossTotAmt" runat="server"></asp:Label> </td>
       <td style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:0px solid #000; border-top:0px solid #000;"><asp:Label ID="lblTDSTotAmt" runat="server"></asp:Label></td>
    <td style="border-right:0px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-top:0px solid #000; "><asp:Label ID="lbrecpayltotal" runat="server"></asp:Label></td>
  </tr>
    </table>

    </div>
    <div id="divannexDtls" runat="server" style="font-size:16px; font-weight:bold; padding:50px 0px 50px 0px; font-weight:normal; text-align:center; width:100%;" visible="false"><asp:Label ID="lblannex" runat="server"> </asp:Label></div>
    </td>
   <td>&nbsp;</td>
  </tr>
  <asp:Label ID="tr_LblChargedtls" runat="server"></asp:Label>
  <tr>
    <td colspan="2"  style="border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:left; border-right:1px solid #000;">&nbsp;</td>
   
    <td style="padding:5px 10px 5px 5px; margin:5px 0px 5px 5px; text-align:right; border-top:1px solid #000; border-left:0px solid #000; "><asp:Label ID="lbltotal" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td colspan="3" style="padding:5px 5px 5px 5px; margin:5px 0px 5px 5px; text-align:left; border-top:1px solid #000; border-left:0px solid #000; "><div style="float:left; width:70px; font-weight:bold">Rupees</div>  
         <div style="float:left; width:900px;"><asp:Label ID="lblRupeesinwords" runat="server"></asp:Label></div></td>
    </tr>
  <tr id="trcheque" runat="server" visible="false" style="display:none" >
    <td colspan="3" style="padding:5px 5px 5px 5px; margin:5px 0px 5px 5px; text-align:left; border-top:0px solid #000; border-left:0px solid #000; ">
    
  
    
   <%-- <div style="float:left; width:400px; font-size:11px ;padding:2px 5px 2px 0px; margin:2px 0px 2px 0px;">Cheque Subject to realisation</div>--%>
    </td>
  </tr>
 
  <tr>
    <td colspan="3" style="padding:5px 5px 5px 5px; margin:5px 0px 5px 5px; text-align:left; border-top:1px solid #000; border-left:0px solid #000; ">
        <div style="width:100%;float:left;">
            <div style="width:50%;float:left">
                 <div style="float:left; width:106px; font-weight:bold">Prepared By</div>
 <div style="width:86px;margin-top: 49px; "><asp:Label ID="Preparedlndo" style=" float:left;width: 92px" runat="server"></asp:Label></div>
            </div>
            <div style="width:50%;float:left">

    <div style="float:right;width: 135px;font-weight: bold;margin-top: 50px;">Receiver Signature‎</div>
            </div>
       
        <div style="float:left; width:250px; font-weight:bold;display:none">Approved By</div>
        <div style="float:left; width:600px;"><asp:Label ID="Approvedlbdo" runat="server">MURALI</asp:Label></div>
         </div>

    <div style="clear:both;"></div>
    <%--<div style="float:left; width:250px;  margin-top:70px;"></div>--%>
    <%--<div style="float:right; width:220px; font-weight:bold; margin-top:70px;">Authorised Signatory</div>--%>
    
    </td>
  </tr>
</table>
    <asp:Button id="btnreport" runat="server" Visible="false"/>
</div>


<div style="clear:both;"></div>
</div>
<div style="clear:both;"></div>
</div>
                </form>
</body>
</html>

