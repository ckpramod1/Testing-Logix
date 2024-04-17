<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quotation.aspx.cs" Inherits="logix.Reportasp.quotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quotation</title>
    <link href="../css/report.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Wrapper">
<div class="RContainer">
<div class="Header" style="background-color:#0a447f;">
<div class="LogoReport">
    <asp:Image   ID="lbl_img" runat="server" width="71" height="45" />
  <%--<img src="#" id="lbl_img" runat="server" width="71" height="45" />--%> </div>

<div class="LogisticsTitle"><h3><asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<p> <asp:Label ID="lbl_add" runat="server"></asp:Label><br />

Phone : <asp:Label ID="lbl_ph" runat="server"></asp:Label>; 
FAX : <asp:Label ID="lbl_fax" runat="server"></asp:Label>; <br />
EMail:<asp:Label ID="lbl_email" runat="server"></asp:Label></p>
</div>
</div>

<div class="ToLeft">
<div class="ToLabel">To</div>
<div class="ToAddress">
<p>
<%--NIPHA EXPORTS (P) LIMITED<br />

28/1 SHAKESPEAR SARANI<br />

KOLKATA - 700017<br />

PTC : MR.S.P.KUNDU<br />

PH : 913340214300<br />

Email : SP.KUNDU@YAHOO.COM--%>
    <asp:Label ID="lbl_to_add" runat="server"></asp:Label>
</p>


</div>

</div>
<div class="ToRight">
<p>
<label>Quotation #</label><span>:<asp:Label ID="lbl_quotno" runat="server"></asp:Label></span>
<label>Date</label><span>: <asp:Label ID="lbl_date" runat="server"></asp:Label></span>
<label>Valid Till</label><span>: <asp:Label ID="lbl_validtill" runat="server"></asp:Label></span></p>


</div>
<div class="ClrB"></div>
<div class="ThankYou">
<p>Thank You very much for your inquiry and we are pleased to offer our rates & service as per your requirement from 
<asp:Label ID="lbl_fromport" runat="server"></asp:Label> to <asp:Label ID="lbl_toport" runat="server"></asp:Label></p>



</div>
<div class="ClrB"></div>
<div class="ReportBG" style="background-color:#c1d5db;">
<label>Commodity</label>                        <span>: <asp:Label ID="lbl_commodity" runat="server"></asp:Label></span>
<label>Cargo Description</label>                <span>: <asp:Label ID="lbl_desc" runat="server"></asp:Label></span>
<label>Shipment</label>                           <span>: <asp:Label ID="lbl_shipment" runat="server"></asp:Label></span>
<label>Frieght</label>                             <span> : <asp:Label ID="lbl_frieght" runat="server"></asp:Label></span>
<label>Remarks</label>                           <span>:</span>

</div>


<div class="SellRate">
<h3>Sell Rate Details</h3>
<%--<table class="TabelGrid" style="border:1px solid #b1b1b1;">
<tr>
<th style="background-color:#0a447f;">Charge Name</th>
<th style="background-color:#0a447f;">Curr</th>
<th style="background-color:#0a447f;">Rate</th>
<th style="background-color:#0a447f;">Units</th>
</tr>
<tr>
<td><asp:Label ID="lbl_charge" runat="server"></asp:Label></td>
<td><asp:Label ID="lbl_curr" runat="server"></asp:Label></td>
<td><asp:Label ID="lbl_rate" runat="server"></asp:Label></td>
<td><asp:Label ID="lbl_units" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Taxes As Applicable</td>
<td></td>
<td></td>
<td></td>
</tr>
</table>--%>
    <asp:GridView ID="grdQuotation" CssClass="Grid FixedHeader"  runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"  >
                <Columns>
               
        <asp:BoundField DataField="chargename" HeaderText="Charges">
            <HeaderStyle Width="500px" />    
            </asp:BoundField>    
        <asp:BoundField DataField="curr" HeaderText="Curr">
            <HeaderStyle Width="80px" />    
            </asp:BoundField>    
        <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">  
            <HeaderStyle HorizontalAlign="Center" Width="80px" />
            <ItemStyle HorizontalAlign="Right" />
         </asp:BoundField >                 
        <asp:BoundField DataField="base" HeaderText="Base/Unit ">
            <HeaderStyle Width="150px" />
            </asp:BoundField>
                 
        </Columns>
       
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass=""/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
         
             <RowStyle CssClass="GrdRow" />
    </asp:GridView>
</div>

<div class="LblTxt123">
<p>I am sure that you will find our offer is attractive and await  your Confirmation</p>


</div>


<div class="BestRegards">
<p>Best Regards</p>

<p><asp:Label ID="lbl_emp" runat="server"></asp:Label></p>

</div>


</div>
</div>
    </form>
</body>
</html>
