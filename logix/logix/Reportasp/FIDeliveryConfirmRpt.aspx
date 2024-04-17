<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FIDeliveryConfirmRpt.aspx.cs" Inherits="logix.Reportasp.FIDeliveryConfirmRpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="width:1024px;margin: 0 auto;">
    <div style="width: 100%; margin: 0px auto;border:1px solid #000;float: left;">
       <div style="float: left;">
            <div style="float:left; width:150px; margin: 9px 10px 5px 15px; ">
           <asp:image id="lbl_img" runat="server" width="80" height="89">
                </asp:image></div>
           <div style="float:left; width:735px; margin: 7px 0px 4px 9px;">
               <h3 style="font-family: Segoe UI; font-size: 21px; font-weight: bold; color: #000; text-align: center; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 22px;">
                   <asp:label id="lbl_branch" runat="server"></asp:label></h3>
                       
               <div style="text-align: center; color: #000;font-family: Segoe UI;font-size:14px;">
                   <asp:label id="lbl_add" runat="server"></asp:label><br />
                </div>
                <div style="text-align: center; color: #000;font-weight: bold;font-family: Segoe UI;font-size:14px;">
                   Phone :
                   <asp:label id="lbl_ph" runat="server" style="font-weight:normal !important;font-family: Segoe UI;font-size:14px;"></asp:label>
                     Fax :
                   <asp:label id="Label_fax" runat="server" style="font-weight:normal !important;font-family: Segoe UI;font-size:14px;"></asp:label>
                   Email :<asp:label id="lbl_mail" runat="server" style="font-weight:normal !important;font-size:14px;"></asp:label>
               </div>
               <div id="div_cnopshead" runat="server" style="font-weight: bold;font-family: Segoe UI;font-size:14px;text-align:center !important;">
                   Service Tax # :
                   <asp:label id="lbl_staxhead" runat="server" style="font-weight:normal !important;font-size:14px;"></asp:label>
                   PAN # :
                   <asp:label id="lbl_panno" runat="server" style="font-weight:normal !important;font-size:14px;"></asp:label>
               </div>

           </div>
</div>
      <div class="toleft" style="float:left;width:80%;min-height:36px !important;border-top:1px solid #000;">
        <div style="width:100%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
            <label id="lbl_to" runat="server">To :</label>
       </div>
       <div style="width:100%;float:left;padding: 8px 0px 5px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <asp:Label ID="lbl_tocusname" runat="server"></asp:Label><br />
           <asp:Label ID="lbl_toadd" runat="server"></asp:Label>
           </div>
      </div>
      <div class="daright" style="float:left;width:20%;min-height:36px !important;border-top:1px solid #000;">
          
          
    <div style="width:14%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
            <label id="lbl_date" runat="server">date:</label>
       </div>
       <div style="width:64%;float:left;padding: 7px 0px 5px 10px;font-size: 14px; color: #000;font-family: sans-serif;">
        <asp:Label ID="lbl_ourdate" runat="server"></asp:Label>
    </div>
       </div>

        <div class="dear" style="float:left;width:100%;border-top:1px solid #000;border-bottom: 1px solid #000;">
            <div style="width:4%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="lbl_dear1" runat="server">Dear </label>
           </div>
           <div style="width:80%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_ourdear" runat="server"></asp:Label>
               </div>
           </div>
        
        <div class="container" style="float:left;width:100%;min-height:150px;border-bottom: 1px solid #000;">
            <div class="mleft" style="float:left;width:100%;">
                <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="lbl_lod" runat="server">Loaded at :</label>
           </div>
           <div style="width:85%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_ourlod" runat="server"></asp:Label>
               </div>
               <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="lbl_discharge" runat="server">Discharged per :</label>
           </div>
           <div style="width:85%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_ourdischarge" runat="server"></asp:Label>
               </div>
               <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="lbl_arrived" runat="server">Arrived On :</label>
           </div>
           <div style="width:85%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_arriveddate" runat="server"></asp:Label>
               </div>
               <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="lbl_contain" runat="server">HBL # :</label>
           </div>
           <div style="width:85%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_ourcontain" runat="server"></asp:Label> / <asp:Label ID="lbl_bldate" runat="server"></asp:Label>
               </div>
               <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="Label1" runat="server">MBL # :</label>
           </div>
           <div style="width:85%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_mbl" runat="server"></asp:Label>
               </div>
               <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="Label3" runat="server">Shipper :</label>
           </div>
           <div style="width:85%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_shp" runat="server">shipper name</asp:Label>
               </div>
               <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="Label5" runat="server">Consignee :</label>
           </div>
           <div style="width:85%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
            <asp:Label ID="lbl_con" runat="server"></asp:Label>
               </div>
            </div>
            </div>
            <div class="footer" style="float:left; width:70%;">
                <p style="font-family:sans-serif;font-size:14px;padding: 8px 0px 5px 10px;">Please be informed that we have issued Deliver Order to the Consignee on<asp:Label ID="lbl_ourmbl" runat="server" style="margin-left:5px;margin-right:5px;"></asp:Label>after collecting the above ORIGINAL/COPY BL. </p>
                <p style="font-family:sans-serif;font-size:14px;padding: 8px 0px 5px 10px;">Thanks & Regards</p>
                <p style="font-family:sans-serif;font-size:14px;padding: 8px 0px 5px 10px;font-weight:bold;"><asp:Label ID="lbl_user" runat="server"></asp:Label></p>
            </div>
            
        </div>
    </div>
            
</div>

</body>
</html>
