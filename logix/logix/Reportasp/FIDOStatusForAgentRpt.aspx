<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FIDOStatusForAgentRpt.aspx.cs" Inherits="logix.Reportasp.FIDOStatusForAgentRpt" %>


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
    width: 6%;
    height: 50px;
    border-bottom: 1px solid #000;
    
    border-right: 1px solid #000;
}
.details thead th:nth-child(2) {
    padding:0 !important;
    width: 6%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(3) {
    padding:0 !important;
    width: 6%;
    height: 50px;
    border-bottom: 1px solid #000;
}

table {
    border-collapse: collapse;
}
.details tbody tr td:nth-child(1)  {
    padding:0px 0px 0px 10px !important;
    width: 6%;
    height: auto;
    border-bottom: 1px solid #000;
    
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(2) {
    padding:0px 0px 0px 10px !important;
    width: 6%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(3) {
    padding:0px 0px 0px 10px !important;
    width: 6%;
    height: auto;
    border-bottom: 1px solid #000;
}


div#div_cnopshead {
    text-align: center !important;
}


    </style>
</head>
<body>
    <div style="width:1024px;margin: 0 auto;">
    <div style="width: 100%; margin: 0px auto;border:1px solid #000;float: left;border-bottom: none;">
        <div style="float: left;">
           <div style="float:left; width:735px; margin: 7px 0px 4px 9px;">
               <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: bold; color: #000; text-align: center; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 22px;">
                   <asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
                       
               <div style="text-align: center; color: #000;">
                   <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                </div>
                <div style="text-align: center; color: #000;font-weight: bold;">
                   Phone :
                   <asp:Label ID="lbl_ph" runat="server" style="font-weight:normal !important;"></asp:Label>
                   Fax :
                    <asp:Label ID="lbl_fax" runat="server" style="font-weight:normal !important;"></asp:Label>
                    Email :
                    <asp:Label ID="lbl_mail" runat="server" style="font-weight:normal !important;"></asp:Label>
               </div>
               <div id="div_cnopshead" runat="server" style="font-weight: bold;">
                   Service Tax # :
                   <asp:Label ID="lbl_staxhead" runat="server" style="font-weight:normal !important;"></asp:Label>
                   PAN # :
                   <asp:Label ID="lbl_panno" runat="server" style="font-weight:normal !important;"></asp:Label>
               </div>

           </div>
</div>

<div style="float:left;width:100%;">
<div style="float:left;width:100%;">
    <%--<div style="width:9%;float:left;padding: 7px 0px 10px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
        <label id="label_1" style="color: #000000;" runat="server">Agent Name :</label>
    </div>--%>
    <div style="width:89%;float:left;padding: 7px 0px 10px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
       <asp:Label ID="lbl_agent" runat="server"></asp:Label>
    </div>
    
</div>

</div>
<div style="float:left; width:100%;border-top: 1px solid #000;display:none;">
    <h4 style="float:left;font-size:14px;font-family:sans-serif;color:#000;font-weight:bold;text-align: center;width:100%;margin:5px;">OutStanding Do Register</h4>

</div>
         <div class="table" style="width:100%;">
           
            <table class="details" style="width:100%;border-top: 1px solid #000;">
                <thead>
                    <tr>
                        <th>MBL #</th>
                        <th>BL #</th>
                        <th>Do Issued On</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Label ID="lbl_tr" runat="server"></asp:Label>
                    </tbody>
                    </table>
                </div>
            
</div>
</body>
</html>
