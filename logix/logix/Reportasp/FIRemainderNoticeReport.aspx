<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FIRemainderNoticeReport.aspx.cs" Inherits="logix.Reportasp.FIRemainderNoticeReport" %>

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
.rhead{
    text-align: center;
        padding:10px 0 10px 0;
        font-weight: bold;
        border-bottom: 1px solid #000;
        
    }
.fifinal{
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
.div1content,.div2content,.div4content{
    float:left;
    width:100%;
}
.left1{
    float:left;
    width:80%;
    padding-top: 10px !important;

}
.right1{
    float:left;
    width:20%;
    padding-top: 10px !important;
}
.left1 p{
    float: left;
    width: 21% !important;
    padding-bottom:20px !important;
}
.right1 p {
    float: left;
    /*width: 35% !important;*/
    padding-bottom:20px !important;
}
.left1 span, .right1 span{
    float: left;
/*    width: 65% !important;
    padding-bottom:20px !important;*/
}
.leftc{
    float:left;
    width:40%;
    padding-top: 10px !important;

}
.centerc{
    float:left;
    width:30%;
    padding-top: 10px !important;

}
.rightc{
    float:left;
    width:30%;
    padding-top: 10px !important;

}
.leftc p{
    float: left;
  /*  width: 18% !important;
    padding-bottom:20px !important;*/
}
.centerc p,.rightc p{
    float: left;
    /*width: 21% !important;*/
    padding-bottom:20px !important;
}
.leftc span, .rightc span,.centerc span{
    float: left;
    /*width: 65% !important;*/
    padding-bottom:20px !important;
}
.leftc span{
    float: left;
 /*   width: 80% !important;
    padding-bottom:20px !important;*/
}
.details tbody tr td:nth-child(1){
    padding:2 !important;
    height: auto;
}
.details tbody tr td:nth-child(2){
    padding:2 !important;
    height: auto;
}
.details thead th{
    font-size:14px;
    font-family:sans-serif;
}
.details tbody td{
    font-size:14px;
    font-family:sans-serif;
}
</style>
</head>
 <body>
<div style="width:100%;">
    <div class="fifinal">
<div class="report">
    <div class="header">
        <h2 style="font-family: Segoe UI;
        font-size: 21px;
        font-weight: bold;
        color: #000;"><asp:label runat="server" ID="lblcompanyname"></asp:label></h2>
        <h3 style="font-family: Segoe UI;
        font-size: 17px;
        font-weight:normal;
        color: #000;"><asp:label runat="server" ID="lbladdress"></asp:label></h3><h3 style="font-family: Segoe UI;
    font-size: 17px;
    font-weight: bold;
    color: #000;">Phone # :<span style="font-weight: normal !important;"><asp:label runat="server" ID="lblphone" style="margin-left:5px;"></asp:label><span style="display: inline;padding-left: 13px; font-weight: bold !important;">Fax # :</span><asp:label runat="server" ID="lblfax" style="margin-left:5px; font-weight:normal !important;"></asp:label></span><span style="display: inline;padding-left: 13px; font-weight: bold !important;">eMail:</span><span><asp:label runat="server" ID="lblemail" style="margin-left:5px; font-weight:normal !important;"></asp:label></span></h3>
    <h3 style="font-family: segoe UI; font-size:17px; font-weight:bold; color:#000;">PAN # :<span style="font-weight: normal !important;"><asp:label runat="server" ID="lblpan" style="margin-left:5px;"></asp:label><span style="display:inline-block;padding-left:13px;font-weight:bold;">Service Tax # :</span><asp:label runat="server" ID="lblservicetax" style="margin-left:5px;font-weight: normal !important;"></asp:label></span></h3>
    </div>
    <div class="rhead">
        <h4 style="font-size:14px;font-family:sans-serif;color:#000;">R E M I N D E R N O T I C E </h4>
    </div>
    <div class="div1content">
        <div class="left1">
            
                <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:100% !important; padding-bottom: 10px !important;">To</p>
               <p style="font-size:14px;font-weight:normal;font-family: sans-serif;color:#000; width:80% !important; margin-top:5px;"><asp:label runat="server" id="lblcompanyadd" style="width:80% !important;"></asp:label></p>
        </div>
        <div class="right1">
            <div style="width:100%;float:left;">
            <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:50px">Date</p>
            <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">: </p>
                <asp:label runat="server" id="lbldate" style="margin-left: 20px;"></asp:label>

           
                </div>

             <div style="width:100%;float:left;">
            <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;">Job #</p>
            <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">:</p><asp:label runat="server" id="lbljobno" style="margin-left: 20px;"></asp:label>
                 </div>
        </div>
        </div>
        <div class="div2content">
            <div class="towhom">
                <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;">Dear Sir / Madam</p>
            </div>
            <div class="leftc">

                <div style="width:100%;float:left;">
                <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:60px !important">SUB</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">:</p><asp:label runat="server" id="lblvessel" style="margin-left: 20px;"> </asp:label>
            <asp:Label ID="lblvoyage" runat="server" ></asp:Label>
                    </div>

                 <div style="width:100%;float:left;">
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:60px !important">B \ L</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">:</p><asp:label runat="server" id="lblbl" style="margin-left: 20px;"> </asp:label>
                     </div>
            </div>
            <div class="centerc">

                <div style="width:100%;float:left;"> 
                <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:60px !important">ETA</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">:</p><asp:label runat="server" id="lbleta" style="margin-left: 20px;"></asp:label>
                    </div>

                <div style="width:100%;float:left;"> 
        <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:60px !important">Line #</p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">:</p><asp:label runat="server" id="lbllineno" style="margin-left: 20px;"></asp:label></div>
            </div>
            <div class="rightc">
                <div style="width:100%;float:left;"> 

                <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000;width:60px !important">IM # </p>
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;">:</p><asp:label runat="server" id="lblimno" style="margin-left: 20px;"></asp:label></div>
            </div>
        </div>
        <div class="div3content">
            <p style="font-size:14px;font-weight:bold;font-family: sans-serif;color:#000; margin-left:0px !important;">Container #(s)</p>
            <div class="table" style="width:100%;">
                <table class="details" style="margin-left: 0px !important; width:25%;">
                    <thead>
                        <tr>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Label ID="lblcondetails" runat="server"></asp:Label>
                    </tbody>
                </table>
    
            </div>
    </div>
    <div class="div4content">
        <p style="font-size:14px;font-family:sans-serif; color: #2c2b2b;text-align: justify; margin:20px 0px 40px 0px;line-height: 1.5;">Despite of our Arrival Notice informing you about the ETA of the vessel,you have not collected the Delivery order from us for
            effecting clearance of goods.The goods are lying at CFS under your own risk exposed to various risks.You are requested to collect the
            Delivery.</p>
    </div>
    <div class="div5content" style="text-align: left;">
        <p style="font-size:17px;font-weight:bold;font-family: sans-serif;color:#000;margin-bottom:10px;">for
        <span style="font-size:17px;font-weight:bold;font-family: sans-serif;color:#000; margin-bottom: 5px;margin-left:5px;"><asp:label runat="server" Id="lblcomp"></asp:label></span></p>
        <p style="font-size:14px;font-weight:normal;font-family: sans-serif;color:#000;margin-bottom: 86px;">(formerly known as PL Shipping & Logistics Private Limited)</p>
        <p style="font-size:17px;font-weight:bold;font-family: sans-serif;color:#000;">Authorised Signatory</p>
    </div>
    </div>
    </div>
    </div>
    </body>
    </html>