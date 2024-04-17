<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Outstanding_online_rpt.aspx.cs" Inherits="logix.Reportasp.Outstanding_online_rpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title runat="server" id="id_title"></title>
     <style type="text/css">
        .TblBold tr:last-child{ font-weight:bold; color:Maroon;}
        @media print {
            thead {
                display: table-header-group;
            }
            tfoot {
                display:table-footer-group;
            }

            tfoot tr th {
                border-bottom:1px solid #000;
            }
        }
    @media screen {
    thead { display: table-header-group; }

    }
    tbody {
    display:table-row-group;
}
      tfoot {
                display:table-footer-group;
            }

            tfoot tr th {
                border-bottom:1px solid #000;
            }

    </style>


  
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0px auto; width: 1090px; font-family: sans-serif, Geneva, sans-serif;">
             <div style="float: left; width: 150px; min-height: 95px; border-top: 1px solid #000; border-bottom: 1px solid #000; border-right: 0px solid #000; border-left:1px solid #000; padding: 5px;">
                <asp:Image ID="lbl_img" runat="server" Width="143" Height="89" /></div>
            <div style="float: left; min-height: 95px; width: 438px; padding: 5px 0px 1px 0px; line-height:18px; border-left: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; border-right: 1px solid
#000;">
                <p style="font-size: 12px; padding:0px 5px 0px 5px; margin:0px; border-bottom:1px solid #000;">
                    <label runat="server" id="label_branchname"></label>
                    <br />
                    <label runat="server" id="label_address"></label>
                    <br />
                    <label runat="server" id="label_email"></label>
                </p>
                <div style="float:left; width:60px; font-size: 12px; padding:2px 1px 2px 1px; margin:0px;">Web Site:-</div>
                <div style="float:left; width:360px; font-size:12px; padding:2px 1px 2px 1px; margin:0px;"></div>
                 <div style="float:left; width:45px; font-size: 12px; padding:2px 1px 2px 1px; margin:0px;">Ph No:-</div>
                <div style="float:left; width:147px; font-size:12px; padding:2px 1px 2px 1px; margin:0px;"><label id="lbl_no" runat="server"></label></div>
                <div style="float:left; width:30px; font-size: 12px; padding:2px 1px 2px 1px; margin:0px;">Email</div>

                <div style="float:left; width:199px; font-size:12px; padding:2px 5px 2px 5px; margin:0px;"> </div>
            </div>
           
            <div style="float: left; width: 487px; min-height: 105px; border-top: 1px solid #000; border-bottom: 1px solid #000; border-right: 1px solid #000; padding:0px;">
                <p style="font-size: 12px; padding: 5px 0px 12px 5px; margin:0px; border-bottom:1px solid #000; min-height:42px;" >
                    <asp:Label runat="server" ID="label_ledgername"></asp:Label>
                    <%--    Locher Evers International<br />
456 Humber Place, Annacis<br />
Business Park, New Westminster<br />
BC V3M 6A5 Canada--%>
                </p>
                 <div style="width: 112px; float: left; font-size: 12px; padding: 5px; ">Contact Person:-</div>
                  <div style="float: left; width: 120px; font-size: 12px; text-align: left; padding: 5px;">
                        <label runat="server" id="label_contact_person"></label>
                    </div>

                    <div style="float: left; width: 224px; font-size: 12px; padding: 5px;">
                        <p style="padding: 0px; margin: 0px;" runat="server" id="p_contact_mail"></p>
                    </div>
                <div style="clear:both;"></div>
                <div style="float:left; width:190px;">
                  <div style="width: 90px; float: left; font-size: 12px; padding: 0px 5px 0px 5px; margin:0px;">Credit Days:-</div>
                <div style="float: left; width: 35px; font-size: 12px; padding: 0px 0px 0px 5px; text-align: right;">
                    <label runat="server" id="label_creditdays"></label>
                </div>
                </div>
                <div style="float:left; width:295px;">
                <div style="width: 145px; float: left; font-size: 12px; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px; text-align:right; ">Credit Amount:-</div>
                <div style="float: left; width: 87px; padding: 0px 0px 0px 5px; font-size: 12px; text-align: right;">
                    <label runat="server" id="label_creditamt"></label>

                </div>
                    </div>
            </div>
         
              
            
            <div style="float: left; text-align: center; width: 1087px; border-left: 1px solid #000; border-right: 1px solid #000; border-bottom: 1px solid #000;">
                <p style="font-weight: bold;">Statement of Outstanding as of
                    <label runat="server" id="label_currentdate"></label>
                </p>

            </div>
            <div style="clear: both;"></div>
            <table width="1090" border="0" cellspacing="0" cellpadding="0" style="font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; font-size: 12px; padding: 10px 0px 0px 0px;" class="TblBold">
            <thead>
                 <tr>
                     
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-left: 1px solid #000; border-bottom: 1px solid #000; padding: 5px; white-space:nowrap;">S No</th>
                    <%--<th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Branch</th>--%>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Date</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Vouno #</th>
                       <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;" runat="server" id="th_fcurr">Curr</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Voucher Amount</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Settled Amount</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Pending Amount</th>
                    <%--<th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Cumulative Balance</th>--%>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Product</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">MBL</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">BL #</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Shipper</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">Consignee</th>                  
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;" runat="server" id="th2">POL Country</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;" runat="server" id="th1">POD Country</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">No of Days</th>
                </tr>
                   </thead>
                <div style="clear:both;"></div>
               <tbody>
                <asp:Label ID="tr_outdetails" runat="server"></asp:Label>
                   </tbody>
                <tfoot>
                   <tr>
                       <th colspan="14"></th>
                   </tr>
               </tfoot>
            </table>
            <div style="clear: both;"></div>
            <table width="1090" border="0" cellspacing="0" cellpadding="0" style="margin: 10px 0px 0px 0px;" >
                <tr>
                   <%-- <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; padding: 5px; border-top: 1px solid #000; border-left: 1px solid #000; border-right: 1px solid #000;">Outstanding Ageing</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; padding: 5px; border-top: 1px solid #000; border-right: 1px solid #000;">0-30Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; padding: 5px; border-top: 1px solid #000; border-right: 1px solid #000;">&gt;30Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt;60 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 90 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 120 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 180 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 365 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">Total</th>--%>


                     <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; padding: 5px; border-top: 1px solid #000; border-left: 1px solid #000; border-right: 1px solid #000;">Outstanding Ageing</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; padding: 5px; border-top: 1px solid #000; border-right: 1px solid #000;">0-30Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; padding: 5px; border-top: 1px solid #000; border-right: 1px solid #000;">&gt;30Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt;45 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 60 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 75 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 90 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">&gt; 120 Days</th>
                    <th style="background-color: #c5c7c6; font-size: 12px; font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000;">Total</th>


                    <%--<th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">Ledger Amount</th>--%>
                </tr>

                <asp:Label ID="tr_Ledgerageing" runat="server"></asp:Label>
            </table>
            <div style="clear: both;"></div>
            <table width="1090" border="0" cellspacing="0" cellpadding="0" style="margin: 10px 0px 0px 0px;">
                <tr style="background-color: #c5c7c6;">
                    <td width="352" style="border-left: 1px solid #000; border-right: 1px solid #000; font-size: 12px; border-bottom: 1px solid #000; border-top: 1px solid #000; padding: 5px;">
                        <div style="float: left; width: 150px;">Payable to Beneficiary:-</div>
                        <div style="float: left; width: 190px;">
                            <label runat="server" id="label_Beneficiary"></label>
                        </div>
                    </td>
                    <td width="321" style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">
                        <div style="float: left; width: 100px; font-size: 12px;">Beneficiary Bank:-</div>
                        <div style="float: left; font-size: 12px; width: 200px;">
                            <label runat="server" id="label_Bene_bank"></label>
                        </div>
                    </td>
                    <td width="417" style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">
                        <div style="float: left; width: 120px; font-size: 12px;">Bank Account No:-</div>
                        <div style="float: left; font-size: 12px; width: 200px;">
                            <label id="label_bankacno" runat="server"></label>
                        </div>
                    </td>
                </tr>
                <tr style="background-color: #c5c7c6;">
                    <td style="border-left: 1px solid #000; border-bottom: 1px solid #000; border-right: 1px solid #000; padding: 5px;">
                        <div style="float: left; width: 90px; font-size: 12px;">Bank Address:-</div>
                        <div style="float: left; font-size: 12px; width: 250px;">
                            <label runat="server" id="label_bank_add"></label>
                        </div>
                    </td>
                    <td style="border-right: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">
                        <div style="float: left; width: 110px; font-size: 12px;">IFSC Code:-</div>
                        <div style="float: left; font-size: 12px; width: 200px;">
                            <label runat="server" id="label_ind_swiftcode"></label>
                        </div>
                    </td>
                    <td style="border-right: 1px solid #000; border-bottom: 1px solid #000; padding: 5px;">
                        <div style="float: left; width: 150px; font-size: 12px;">Swift Code:-</div>
                        <div style="float: left; font-size: 12px; width: 200px;">
                            <label runat="server" id="label_USD_swiftcode"></label>
                        </div>
                    </td>
                </tr>
            </table>
           <%-- <p style="font-size: 11px; color: #000;">Note: This is computer generated statement of account. If any discrepancies, revert us within 7working days, if not this statement will be considered as accepted.</p>--%>
       
             <p style="font-size: 11px; color: #000;">Note: This is computer generated statement of account. Any discrepancy should be notified to us in writing within 7 days from the invoice date, otherwise it will be presumed the amount reflected on the bill is correct and have been verified at your end. Payment must be received within the agreed credit period,failing which interest @18% per annum will be charged on overdue invoices. All objections/claims are subject to chennai jurisdiction.</p>
             </div>
    </form>
</body>
</html>
