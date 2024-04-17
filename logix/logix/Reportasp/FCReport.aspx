<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FCReport.aspx.cs" Inherits="logix.Reportasp.FCReport" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Report</title>
<style>
    *{
    box-sizing: border-box;
    margin:0;
    padding:0;
    
}
.report {
    width: 1024px;
    margin: 20px auto;
    
}
.fififc{
    width: 1024px;
    margin: 20px auto;
}
.header{
    border-bottom: 1px solid #000;
}
.header h2{
    text-align: center;
    line-height: 1.5;
    margin-top: 10px !important;
}
.header h3{
    text-align: center;
    line-height: 1.5;
    margin-bottom:5px !important ;
}
.rhead{
text-align: center;
    padding:10px 0 10px 0;
    font-weight: bold;
    border-bottom: 1px solid #000;
    
}
.div1content,.div2content,.div3content{
    float:left;
    width:100%;
    border-bottom: 1px solid #000;
}
.div4content{
    width:100%;
}
.details{
    width:100%;
}
table {
    border-collapse: collapse !important;
}
.left{
    float:left;
    width:65%;
    padding-top: 10px !important;

}
.left1{
    float:left;
    width:30%;
    padding-top: 10px !important;

}
.right{
    float:left;
    width:35%;
    padding-top: 10px !important;
}
.right1{
    float:right;
    width:20%;
    padding-top: 10px !important;
}
.left p, .right p {
    float: left;
    width: 35% !important;
    padding-bottom:20px !important;
}
.left1 p{
    float: left;
/*    width: 21% !important;
    padding-bottom:20px !important;*/
}
.right1 p {
    float: left;
 /*   width: 35% !important;
    padding-bottom:20px !important;*/
}
.left span, .right span{
    float: left;
    /*width: 65% !important;*/
    /*padding-bottom:20px !important;*/
}
.left1 span, .right1 span{
    float: left;
/*    width: 65% !important;
    padding-bottom:20px !important;*/
}
.details thead tr th:nth-child(1){
    padding:0 !important;
    width: 30%;
    height: 50px;
    border-bottom: 1px solid #000;
}
.details thead tr th:nth-child(2){
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
    text-align: right !important;
}
.details thead tr th:nth-child(3){
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
}
.details thead tr th:nth-child(4){
    padding:0 !important;
    width: 5%;
    height: 50px;
    border-bottom: 1px solid #000;
    text-align: left !important;
}
.details thead tr th:nth-child(5){
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
}
.details thead tr th:nth-child(6){
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    text-align: right !important;
}
.details thead tr th:nth-child(7){
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
}
.details tbody tr td:nth-child(1){
    padding:0 !important;
    width: 30%;
    height:auto;
    
}
.details tbody tr td:nth-child(2){
    padding:0 !important;
    width: 10%;
    height:auto;
    text-align: right;
    padding-right: 5px !important;
    
}
.details tbody tr td:nth-child(3){
    padding:0 !important;
    width: 10%;
    height: auto;
    text-align: right;
    padding-right: 5px !important;
    
}
.details tbody tr td:nth-child(4){
    padding:0 !important;
    width: 5%;
    height:auto;
    
}
.details tbody tr td:nth-child(5){
    padding:0 !important;
    width: 15%;
    height:auto;
    text-align: right;
    padding-right: 5px !important;
}
.details tbody tr td:nth-child(6){
    padding:0 !important;
    width: 15%;
    height: auto;
    text-align: right;
    padding-right: 5px !important;
}
.details tbody tr td:nth-child(7){
    padding:0 !important;
    width: 15%;
    height: auto;
    text-align: right;
    padding-right: 5px !important;
    
}
.details thead th{
    font-size:14px;
    font-family:sans-serif;
}
.details tbody td{
    font-size:14px;
    font-family:sans-serif;
}
.tfooter {
    float: left;
    width: 100%;
    margin-top: 10px !important;
    border-bottom: 1px solid #000;
}
.left-remarks{
    float:left;
    width:80%;
}
.right-total{
    float:left;
    width:20%;
    border-top: 1px solid #000;
    text-align: right;
}



</style>
</head>
 <body>
<div style="width:100%;">
    <div class="fififc">
<div class="report">
    <div class="header">
        <h2 style="font-family: Segoe UI;
        font-size: 21px;
        font-weight: bold;
        color: #000;"><asp:label runat="server" ID="lblbranchname"></asp:label></h2>
        <h3 style="font-family: Segoe UI;
        font-size: 17px;
        font-weight:normal;
        color: #000;"><asp:label runat="server" ID="lbladdress"></asp:label></h3><h3 style="font-family: Segoe UI;
    font-size: 17px;
    font-weight: bold;
    color: #000;">Phone # :<span style="font-weight: normal !important;"><asp:label runat="server" ID="lblphone" style="margin-left:5px;"></asp:label><span style="display: inline;padding-left: 13px; font-weight: bold !important;">Fax # :</span><asp:label runat="server" ID="lblfax" style="margin-left:5px; font-weight:normal !important;"></asp:label></span></h3>
    <h3 style="font-family: segoe UI; font-size:17px; font-weight:bold; color:#000;">Service Tax # :<span style="font-weight: normal !important;"><asp:label runat="server" ID="lblservicetax" style="margin-left:5px;"></asp:label><span style="display:inline-block;padding-left:13px;font-weight:bold;">PAN # :</span><asp:label runat="server" ID="lblPan" style="margin-left:5px;font-weight: normal !important;"></asp:label></span></h3>
    </div>
    <div class="rhead">
        <h4 style="font-size:14px;font-family:sans-serif;color:#000;">F R E I G H T C E R T I F I C A T E</h4>
    </div>
    <div class="div1content">
        <div class="left1">
            <div style="width: 100%;float: left;">
            <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 64px;">Job #</p>
            <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">: </p>
                <asp:label runat="server" id="lbljob" style="margin-left: 20px;"></asp:label>
            </div>
            <div style="width: 100%;float: left;">
            <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 64px;">
                <asp:Label ID="lbl_tran" runat="server"></asp:Label></p>
            <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">
                :</p>
                <asp:label runat="server" id="lblVessel" style="margin-left: 20px;"></asp:label> V. <asp:Label ID="lblvoyage" runat="server"></asp:Label>
</div>
        </div>
        <div class="right1">
            <%--<p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;">Invoice #</p>
            <span style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">:<asp:label runat="server" id="lbltrantype" style="margin-left: 20px;"></asp:label></span>--%>
            <div style="width: 100%;float: left;">
            <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 64px;">Inv Date</p>
            <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">
                :  </p>
                <asp:label runat="server" id="lblinvdate" style="margin-left: 20px;"></asp:label>

          
                </div>
            
        </div>
    </div>
    <div class="div2content">
      <div class="left">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:100% !important; padding-bottom: 10px !important;">To</p>
        <asp:label runat="server" id="lblcompanyname" style="width:80% !important;"></asp:label><br>
        <asp:label runat="server" id="lbladd"  style="width:80% !important;"></asp:label>  <asp:Label ID="lblzip" runat="server" style="width:80% !important;"></asp:Label>                 

      </div>
      <div class="right">
          <div style="width: 100%;float: left;">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 70px !important;text-align: right;">BL #</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;margin-left: 8px;width: auto !important;">
            :</p>
            <asp:label runat="server" id="lblbl" style="margin-left: 20px;"></asp:label>
              </div>


          <div style="width: 100%;float: left;">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 70px !important;text-align: right;">P o L</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;margin-left: 8px;width: auto !important;">:</p>
            <asp:label runat="server" id="lblpol" style="margin-left: 20px;"></asp:label>
              </div>

          <div style="width: 100%;float: left;">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 70px !important;text-align: right;">Packages</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;margin-left: 8px;width: auto !important;">: </p>
            <asp:label runat="server" id="lblpackage" style="margin-left: 20px;"></asp:label> <asp:Label ID="lbldesc" runat="server"></asp:Label>
              </div>
       
          <div style="width: 100%;float: left;"><span id="lbl_vol" runat="server">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 70px !important;text-align: right;">Volume</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;margin-left: 8px;width: auto !important;">: </p>
            <asp:label runat="server" id="lblvolume" style="margin-left: 20px;"></asp:label></span> 
              </div>
       

          <div style="width: 100%;float: left;"> 
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 70px !important;text-align: right;">Gr Wght</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;margin-left: 8px;width: auto !important;">:</p>
            <asp:label runat="server" id="lblgrweight" style="margin-left: 20px;"></asp:label>kgs

        </div>

          <div style="width: 100%;float: left;"><span id="lbl_line" runat="server">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 70px !important;text-align: right;">Line #</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;margin-left: 8px;width: auto !important;">:</p>
            <asp:label runat="server" id="lblline" style="margin-left: 20px;"></asp:label></span> 

        </div>
           <div style="width: 100%;float: left;"><span id="lbl_im" runat="server">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width: 70px !important;text-align: right;">IM #</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;margin-left: 8px;width: auto !important;">:</p>
            <asp:label runat="server" id="lblim" style="margin-left: 20px;"></asp:label></span> 

               </div>
      </div>
    </div>
    <div class="div3content">
        
            <div class="left" style="width:100% !important;">
            <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:85px !important;">Shipper</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b; margin-left: 8px;width: auto !important;">:</p>
            <asp:label runat="server" id="lblshipper" style="margin-left: 20px;"></asp:label>

        </div>

        <div class="left" style="width:100% !important;">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:85px !important;">Consignee</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;  margin-left: 8px;width: auto !important;">: </p>
            <asp:label runat="server" id="lblConsignee" style="margin-left: 20px;"></asp:label>

       </div>
        
    </div>
    <div class="div4content">
        <div class="table">
            <table class="details">
                <thead>
                    <tr>
                        <th>Charges</th>
                        <th>Curr</th>
                        <th>Rate</th>
                        <th>Base</th>
                        <th>Ex.Rate</th>
                        <th>$</th>
                        <th>INR</th>
                       
    
                    
                    </tr>
                </thead>
                <tbody>
                    <asp:Label ID="lblcharge" runat="server"></asp:Label>
                </tbody>
            </table>

        </div>
    <div class="tfooter">
     <div class="left-remarks">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:99% !important;margin: 10px 0px 10px 0px !important;">Remarks:
        <span style="font-size:14px; font-weight:normal !important;font-family:sans-serif; color: #2c2b2b; margin-top:10px !important;"></span></p>
     </div>
     <div class="right-total">
      <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000; margin: 10px 0px 10px 0px !important;"><asp:label runat="server" id="lblTotal"></asp:label></p>
     </div>
    </div>
    </div>
    <div class="div5content" style="border-bottom: 1px solid #000;">
        <p style="font-size:14px;font-weight:normal;font-family: sans-serif;color:#000;margin:60px 0px 10px 0px;"><asp:label runat="server" ID="lbl_rsword"></asp:label></p>
    </div>
    <div class="div6content" style="text-align: right; margin:10px 0px 10px 0px !important;">
        <div class="companyname">
        <p style="font-size:15px;font-weight:bold;font-family: sans-serif;color:#000;"><asp:label runat="server" Id="lblcomname"></asp:label></p>

        </div>
        <div class="signimag" style="min-height:100px;">
            <asp:image id="signatureimg" runat="server" />
        </div>
        <div class="sign">
            <p style="font-size:15px;font-weight:bold;font-family: sans-serif;color:#000;">Authorised Signatory</p>
        </div>
    </div>
    </div>
    </div>
    </div>
    </body>
    </html>
