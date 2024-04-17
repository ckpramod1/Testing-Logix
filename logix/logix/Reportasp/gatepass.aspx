<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gatepass.aspx.cs" Inherits="logix.Reportasp.gatepass" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .details thead th{
    font-size:14px;
    font-family:sans-serif;
}
.details tbody td{
    font-size:14px;
    font-family:sans-serif;
} 
.details thead th:nth-child(1){
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
    
    border-right: 1px solid #000;
}
.details thead th:nth-child(2) {
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(3) {
    padding:0 !important;
    width: 5%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(4) {
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(5) {
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(6) {
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(7) {
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(8) {
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(9) {
    padding:0 !important;
    width: 5%;
    height: 50px;
    border-bottom: 1px solid #000;
}


table {
    border-collapse: collapse;
}
.details tbody tr td:nth-child(1)  {
    padding:0px 0px 0px 10px !important;
    width: 10%;
    height: auto;
    border-bottom: 1px solid #000;
    
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(2) {
    padding:0px 0px 0px 10px !important;
    width: 10%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(3) {
    padding:0px 0px 0px 10px !important;
    width: 5%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(4) {
    padding:0px 0px 0px 10px !important;
    width: 15%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
    
    padding-right:5px !important;
}
.details tbody tr td:nth-child(5) {
    padding:0px 0px 0px 10px !important;
    width: 10%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
    
    padding-right:5px !important;
}
.details tbody tr td:nth-child(6) {
    padding:0px 0px 0px 10px !important;
    width: 15%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(7) {
    padding:0px 0px 0px 10px !important;
    width: 15%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
    
}
.details tbody tr td:nth-child(8) {
    padding:0px 0px 0px 10px !important;
    width: 10%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
    
}
.details tbody tr td:nth-child(9) {
    padding:0px 0px 0px 10px !important;
    width: 5%;
    height: auto;
    border-bottom: 1px solid #000;
    
}

div#div_cnopshead {
    text-align: center !important;
}

span#Label2 {
    display: inline-block;
    width: 323px;
}
    </style>
</head>
<body>
    <div style="width:1024px;margin: 0 auto;">
    <div style="width: 100%; margin: 0px auto;border:1px solid #000;float: left;">
        <div style="float: left;display:none;">
            <div style="float:left; width:150px; margin: 9px 10px 5px 15px; ">
           <asp:Image  ID="lbl_img" runat="server" Width="80" Height="89" />
                </div>
           <div style="float:left; width:735px; margin: 7px 0px 4px 9px;">
               <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: bold; color: #000; text-align: center; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 22px;">
                   <asp:Label ID="lbl_branch" runat="server">Branch Name</asp:Label></h3>
                       
               <div style="text-align: center; color: #000;">
                   <asp:Label ID="lbl_add" runat="server">Address</asp:Label><br />
                </div>
                <div style="text-align: center; color: #000;font-weight: bold;">
                   Phone :
                   <asp:Label ID="lbl_ph" runat="server" style="font-weight:normal !important;">phoneno</asp:Label>
                   Fax :<asp:Label ID="lbl_fax" runat="server" style="font-weight:normal !important;">faxno</asp:Label>
               </div>
               <div id="div_cnopshead" runat="server" style="font-weight: bold;">
                   Service Tax # :
                   <asp:Label ID="lbl_staxhead" runat="server" style="font-weight:normal !important;">servicetaxno</asp:Label>
                   PAN # :
                   <asp:Label ID="lbl_panno" runat="server" style="font-weight:normal !important;">panno</asp:Label>
               </div>

           </div>
</div>
<div style="float:left;width:100%;margin-top:120px;">
    <div style="width:4%;float:left;padding: 7px 0px 10px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
        <label id="label_date" style="color: #000000;" runat="server">Date :</label>
    </div>
    <div style="width:20%;float:left;padding: 7px 0px 10px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
       <asp:Label ID="lbl_printdate" runat="server"></asp:Label>
    </div>
    
</div>
<div style="float:left;width:100%;">
    <div style="width:100%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
        <label id="label_to" style="color: #000000;" runat="server">To,</label>
    </div>
    <div style="width:100%;float:left;padding: 7px 0px 0px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <asp:Label ID="lbl_towhom" runat="server">The Security Manager</asp:Label>
     </div>
     <div style="width:100%;float:left;padding: 7px 0px 0px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <asp:Label ID="lbl_toadd1" runat="server">Cargo Complex, IGI Airport</asp:Label>
     </div>
     <div style="width:100%;float:left;padding: 7px 0px 10px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <asp:Label ID="lbl_toadd2" runat="server">New Delhi</asp:Label>
     </div>
</div>
<div class="float:left;width:100%;">
    <div style="width:4%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
        <label id="label_forsub" style="color: #000000;" runat="server">SUB :</label>
    </div>
    <div style="width:50%;float:left;padding: 7px 0px 10px 2px;font-size: 14px; color: #000;font-family: sans-serif;">
       <P style="width:100%;float:left;font-size: 14px; color: #000;font-family: sans-serif;margin:0px !important;font-weight: bold;">Gate Pass to<asp:Label ID="lbl_passto" runat="server" style="padding-left:5px;">Mr.</asp:Label> </P>
     </div>
</div>
<div class="float:left;width:100%;">
    <p style="width:100%;float:left;padding: 7px 0px 10px 10px;font-size: 14px; color: #000;font-family: sans-serif;margin:0px !important;font-weight: bold;">Dear <asp:Label ID="Label1" runat="server" style="padding-left:5px;">Sir</asp:Label>,</p>
    <p style="width:100%;float:left;padding: 7px 0px 10px 10px;font-size: 14px; color: #000;font-family: sans-serif;margin:0px !important;font-weight: normal;">Kindly allow to Mr.<asp:Label ID="Label2" runat="server" style="padding-left:5px;padding-right: 5px;">                                                                    </asp:Label>to enter in the custom warehouse to collect the Delivery Order from Airlines and also to File the IGM with the customs.</p>
</div>
<div style="float:left;width:100%;">
    <div style="width:100%;float:left;padding: 7px 0px 3px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <p style="margin:0px;font-size: 14px; color: #000;font-family: sans-serif;">Kindly do the needful</p>
     </div>
     <div style="width:100%;float:left;padding: 7px 0px 3px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <p style="margin:0px;font-size: 14px; color: #000;font-family: sans-serif;">Thanking You</p>
     </div>
     <div style="width:100%;float:left;padding: 7px 0px 10px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <p style="margin:0px;font-size: 14px; color: #000;font-family: sans-serif;">Yours Sincerely</p>
     </div>
     
</div>
<div style="float:left;width:100%;">
    <div style="width:3.5%;float:left;padding: 7px 0px 10px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
        <label id="label3" style="color: #000000;" runat="server">FOR</label>
    </div>
    <div style="width:64%;float:left;padding: 7px 0px 10px 3px;font-size: 14px; color: #000;font-family: sans-serif;font-weight:bold;">
       <asp:Label ID="lbl_brnch" runat="server"></asp:Label>
    </div>
    
</div>
<div style="float:left;width:100%;text-align: right;">
    <div style="width:100%;padding: 7px 0px 10px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;height:30px !important;">
        <p style="width:96%">  
            Signature Attached
        </p>
    </div>
    <div style="width:100%;padding: 75px 0px 10px 3px;font-size: 14px; color: #000;font-family: sans-serif;font-weight:bold;text-align: right;">
        <p style="margin:0px;font-size: 14px; color: #000;font-family: sans-serif;padding: 7px 0px 10px 10px;margin-right: 25px !important;">Authorized Signatory</p>
    </div>
    
</div>
            
</div>
</div>
</body>
</html>
