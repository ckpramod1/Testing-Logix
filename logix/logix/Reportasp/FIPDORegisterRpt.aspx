<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FIPDORegisterRpt.aspx.cs" Inherits="logix.Reportasp.FIPDORegisterRpt" %>


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
    
    
}
.details thead th:nth-child(2) {
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
    
}
.details thead th:nth-child(3) {
    padding:0 !important;
    width: 5%;
    height: 50px;
    border-bottom: 1px solid #000;
   
}
.details thead th:nth-child(4) {
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    
}
.details thead th:nth-child(5) {
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
   
}
.details thead th:nth-child(6) {
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    
}
.details thead th:nth-child(7) {
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    
}
.details thead th:nth-child(8) {
    padding:0 !important;
    width: 10%;
    height: 50px;
    border-bottom: 1px solid #000;
   
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
    
}
.details tbody tr td:nth-child(2) {
    padding:0px 0px 0px 10px !important;
    width: 10%;
    height: auto;
    
}
.details tbody tr td:nth-child(3) {
    padding:0px 0px 0px 10px !important;
    width: 5%;
    height: auto;
    
}
.details tbody tr td:nth-child(4) {
    padding:0px 0px 0px 10px !important;
    width: 15%;
    height: auto;
   
    
    padding-right:5px !important;
}
.details tbody tr td:nth-child(5) {
    padding:0px 0px 0px 10px !important;
    width: 10%;
    height: auto;
    
    
    padding-right:5px !important;
}
.details tbody tr td:nth-child(6) {
    padding:0px 0px 0px 10px !important;
    width: 15%;
    height: auto;
   
}
.details tbody tr td:nth-child(7) {
    padding:0px 0px 0px 10px !important;
    width: 15%;
    height: auto;
    
    
}
.details tbody tr td:nth-child(8) {
    padding:0px 0px 0px 10px !important;
    width: 10%;
    height: auto;
    
    
}
.details tbody tr td:nth-child(9) {
    padding:0px 0px 0px 10px !important;
    width: 5%;
    height: auto;
    
    
}

div#div_cnopshead {
    text-align: center !important;
}


    </style>
</head>
<body>
    <div style="width:1024px;margin: 0 auto;">
    <div style="width: 100%; margin: 0px auto;border:1px solid #000;float: left;border-bottom: 1px solid #000;">
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
<div style="float:left; width:100%;border-bottom: 1px solid #000;display:none;">
    <h4 style="float:left;font-size:14px;font-family:sans-serif;color:#000;font-weight:bold;text-align: center;width:100%;margin:5px;">Header</h4>

</div>
<div style="float:left;width:100%;">
<div style="float:left;width:50%;">
<%--    <div style="width:15%;float:left;padding: 7px 0px 10px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
        <label id="label_lastport3" style="color: #000000;" runat="server">Print Date :</label>
    </div>--%>
    <div style="width:75%;float:left;padding: 7px 0px 10px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
       <asp:Label ID="lbl_ourlastport3" runat="server">12|03|2024</asp:Label>
    </div>
    
</div>
<%--<div style="float:left;width:48%;">
    <p style="float:right;padding: 7px 0px 10px 3px;font-size: 14px; color: #000;font-family: sans-serif;margin:0 !important;">page 
       <asp:Label ID="lbl_n" runat="server" style="padding-left:5px;padding-right:5px;">N</asp:Label>of<asp:Label ID="lbl_m" runat="server" style="padding-left:5px;">M</asp:Label>
    </p>
</div>--%>
</div>
<div style="float:left; width:100%;border-top: 1px solid #000;">
    <h4 style="float:left;font-size:14px;font-family:sans-serif;color:#000;font-weight:bold;text-align: center;width:100%;margin:5px;">OutStanding Do Register</h4>

</div>
         <div class="table" style="width:100%;">
           
            <table class="details" style="width:100%;border-top: 1px solid #000;">
                <thead>
                    <tr>
                        <th>Inv #</th>
                        <th>BL #</th>
                        <th>JOb #</th>
                        <th>Vessel Name & Voy</th>
                        <th>ForwarderBL #</th>
                        <th>Forwarder Name</th>
                        <th>Consignee</th>
                        <th>InvAmt</th>
                        <th>Days</th>
                    </tr>
                </thead>
                
                <tbody>
                <asp:Label ID="lbl_tdrow" runat="server"></asp:Label>

                </tbody>

                </table>          
    </div>
            

</body>
</html>
