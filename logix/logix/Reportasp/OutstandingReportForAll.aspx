<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutstandingReportForAll.aspx.cs"
    Inherits="logix.Reportasp.OutstandingReportForAll" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title runat="server" id="id_title"></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0px auto; width: 1193px; font-family: sans-serif, Geneva, sans-serif;">
            <div style="float: left; min-height: 95px; width: 332px; padding: 5px; line-height:18px; border-left: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; border-right: 1px solid
#000;">
                <p style="font-size: 12px;">
                    <label runat="server" id="label_branchname"></label>
                    <br />
                    <label runat="server" id="label_address"></label>
                    <br />
                    <label runat="server" id="label_email"></label>
                </p>
            </div>
            <div style="float: left; width: 150px; min-height: 95px; border-top: 1px solid #000; border-bottom: 1px solid #000; border-right: 1px solid #000; padding: 5px;">
                <asp:Image ID="lbl_img" runat="server" Width="143" Height="89" />
            </div>
            <div style="float: left; width: 413px; min-height: 105px; border-top: 1px solid #000; border-bottom: 1px solid #000; border-right: 1px solid #000;">
                <p style="font-size: 11px; padding: 5px;">
                    <asp:Label runat="server" ID="label_ledgername"></asp:Label>
                    <%--    Locher Evers International<br />
456 Humber Place, Annacis<br />
Business Park, New Westminster<br />
BC V3M 6A5 Canada--%>
                </p>
            </div>
            <div style="float: left; width: 271px; border-top: 1px solid #000; border-bottom: 1px solid #000; border-right: 1px solid #000; min-height: 105px;">
                <div style="width: 257px; float: left; border-bottom: 1px solid #000;">
                    <div style="width: 149px; float: left; font-size: 12px; padding: 5px;">Contact Person:-</div>
                    <div style="float: left; width: 87px; font-size: 12px; text-align: right; padding: 5px;">
                        <label runat="server" id="label_contact_person"></label>
                    </div>
                    <div style="float: left; width: 237px; font-size: 12px; padding: 5px;">
                        <p style="padding: 0px; margin: 0px;" runat="server" id="p_contact_mail"></p>
                    </div>
                </div>
                <div style="width: 149px; float: left; font-size: 12px; padding: 5px;">Credit Days:-</div>
                <div style="float: left; width: 87px; font-size: 12px; padding: 5px; text-align: right;">
                    <label runat="server" id="label_creditdays"></label>
                </div>
                <div style="width: 150px; float: left; font-size: 12px; padding: 5px;">Credit Amount:-</div>
                <div style="float: left; width: 87px; padding: 5px; font-size: 12px; text-align: right;">
                    <label runat="server" id="label_creditamt"></label>
                </div>
            </div>
            <div style="float: left; text-align: center; width: 1189px; border-left: 1px solid #000; border-right: 1px solid #000; border-bottom: 1px solid #000;">
                <p style="font-weight: bold;">
                    Statement of Outstanding (Receivable and Payable) as of
                    <label runat="server" id="label_currentdate"></label>
                </p>

            </div>
            <div style="clear: both;"></div>
            <table width="1090" border="0" cellspacing="0" cellpadding="0" style="font-family: sans-serif, Geneva, sans-serif; border-bottom: 1px solid #000; font-size: 12px; padding: 10px 0px 0px 0px;">
                <tr>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-left: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="50px">S No</th>
                    
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="70px">Date</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="80px">Vouno</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="70px">Voucher Amount</th>
                     <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="70px">Received Amount</th>
                     <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="70px">Pending Amount</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="120px">Curr</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="70px">Product</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="70px">BPJ</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="86px">MBL</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="100px">BL #</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="120px">Shipper</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="110px">Consignee</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="120px">POL Country</th>
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="70px">POD Country</th>
                    
                    <th style="border-right: 1px solid #000; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 2px 5px 2px;" width="40px">No of Days</th>
                </tr>

                <asp:Label ID="tr_outdetails" runat="server"></asp:Label>

            </table>
            <div style="clear: both;"></div>
            <%--<table width="1090" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0px 0px 0px;">
  <tr>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000; padding:5px; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000;">Outstanding Ageing</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; padding:5px; border-top:1px solid #000; border-right:1px solid #000;">0-30Days</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; padding:5px; border-top:1px solid #000; border-right:1px solid #000;">&gt;30Days</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">&gt;60 Days</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">&gt; 90 Days</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">&gt; 120 Days</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">&gt; 180 Days</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">&gt; 365 Days</th>
    <th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">Total</th>
    <%--<th style="background-color:#c5c7c6; font-size:12px; font-family:sans-serif, Geneva, sans-serif;  border-bottom:1px solid #000; border-top:1px solid #000; border-right:1px solid #000;">Ledger Amount</th>
  </tr>

     <asp:Label ID="tr_Ledgerageing" runat="server"></asp:Label>
</table>--%>
            <div style="clear: both;"></div>
            <%--<table width="1090" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0px 0px 0px;">
  <tr style="background-color:#c5c7c6;">
    <td width="352" style="border-left:1px solid #000; border-right:1px solid #000; font-size:12px; border-bottom:1px solid #000; border-top:1px solid #000; padding:5px;"><div style="float:left; width:150px;">Payable to Beneficiary:-</div><div style="float:left; width:190px;"><label runat="server" id="label_Beneficiary"></label></div></td>
    <td width="321" style="border-right:1px solid #000; border-top:1px solid #000; border-bottom:1px solid #000; padding:5px;">
    <div style="float:left; width:100px; font-size:12px;">Beneficiary Bank:-</div><div style="float:left; font-size:12px; width:200px;"><label runat="server" id="label_Bene_bank"></label></div>
    </td>
    <td width="417" style="border-right:1px solid #000; border-top:1px solid #000; border-bottom:1px solid #000; padding:5px;">
    <div style="float:left; width:120px; font-size:12px;">Bank Account No:-</div><div style="float:left; font-size:12px; width:200px;"><label id="label_bankacno" runat="server"></label></div>
    </td>
  </tr>
  <tr style="background-color:#c5c7c6;">
    <td style="border-left:1px solid #000; border-bottom:1px solid #000; border-right:1px solid #000; padding:5px;">
    <div style="float:left; width:90px; font-size:12px;">Bank Address:-</div><div style="float:left; font-size:12px; width:250px;"><label runat="server" id="label_bank_add"></label></div>
    </td>
    <td style="border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;">
     <div style="float:left; width:110px; font-size:12px;">India Swift Code:-</div><div style="float:left; font-size:12px; width:200px;"><label runat="server" id="label_ind_swiftcode"></label></div>
    </td>
    <td style="border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;">
    <div style="float:left; width:150px; font-size:12px;">New York Swift Code:-</div><div style="float:left; font-size:12px; width:200px;"><label runat="server" id="label_USD_swiftcode"></label></div>
    </td>
  </tr>
</table>--%>
            <p style="font-size: 11px; color: #000;">Note: This is computer generated statement of account. If any discrepancies, revert us within 7working days, if not this statement will be considered as accepted.</p>
        </div>
    </form>
</body>
</html>
