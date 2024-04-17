<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostingRPT.aspx.cs" Inherits="logix.Reportasp.CostingRPT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/systemreportscost.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        span#lstcon {text-align:left!important; float:left!important;
        }
        .ALTLeft1 {
    background-color: #f9dded;
    width: 566px;
    float: left;
    padding: 15px 0px 0px 0px;
    min-height: 179px;
}

        .ALTRight2 {
    background-color: #f5f5f5;
    width: 457px;
    float: left;
    padding: 10px 0px 0px 0px;
    border-top: 0px solid black;
}

.ALTRight1 {
    background-color: #f9dded;
    width: 438px;
    float: left;
    padding: 15px 0px 0px 20px;
    min-height: 179px;
}




.ALTRight1 label {
    width: 145px;
    float: left;
    display: inline-block;
    margin: 0px 18px 10px 0px;
    padding: 0px 0px 0px 0px;
    text-align: right;
}

.ALTRight1 span {
    width: 260px;
    float: left;
    display: inline-block;
    margin: 0px 0px 5px 0px;
}
.ALTLeft1 span {
    width: 380px;
    float: left;
    display: inline-block;
    margin: 0px 0px 5px 0px;
}

.AddressRight {
    width: 427px;
    float: left;
}

.ALTRight1 span {
    width: 205px;
    float: left;
    display: inline-block;
    margin: 0px 0px 5px 0px;
}
.ALTRight1 label {
    width: 159px;
    float: left;
    display: inline-block;
    margin: 0px 18px 0px 0px;
    padding: 0px 0px 0px 0px;
    text-align: right;
}

.AddressLeft {
    width: 566px;
    border-right: 0px solid #fff;
    float: left;
}



        .auto-style1 {
            height: 24px;
        }

        span{
            color:black !important;
        }
        .CompanyName p {
    text-align: center;
    font-family: "Segoe UI";
    font-size: 14px;
    margin: 0px 0px 10px 165px;
    padding: 0px;
    font-weight: normal;
    line-height: 18px;
    color: black;
}
         label{
     color:black !important;
 }
         *{
             background:white !important;
         }
         .Container {
    width: 1024px;
    margin: auto;
    border-left: 1px solid black;
    border-right: 2px solid black;
}
    </style>
</head>
<body style="padding:0px; margin:0px;">
     <form id="form1" runat="server">
        <div id="Wrapper">
            <div class="Container">
                 <div style="float:right; width:150px; margin:5px 5px 0px 5px; display:none"><asp:Image  ID="img_Logo" runat="server" Width="143" Height="89" /></div>
                <div class="Header">
                  
                   <div class="CompanyName">
                        <h3><asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<%--                         <p style="margin:-2px 0px 2px 200px; padding:0px 0px 0px 0px; font-size:14px; font-family: Segoe UI; text-align:center;">(Formerly Known as Axelerom International Logistics Private Limited)</p>--%>
                        <p>
                            <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                            Phone # :
                            <asp:Label ID="lbl_ph" runat="server"></asp:Label>
                            Fax # :<asp:Label ID="lbl_fax" runat="server"></asp:Label>;<br />
                            ST.# :
                            <asp:Label ID="lbl_st" runat="server"></asp:Label>
                            PAN # :
                            <asp:Label ID="lbl_pan" runat="server"></asp:Label>
                            CIN # :
                            <asp:Label ID="lbl_cin" runat="server"></asp:Label>
                        </p>
                    </div>
                     <div style="float:left; width:137px; color:black; margin:0px 0px 0px 10px; font-size:12px;"><span><label>Print Date: </label><asp:Label ID="lbldate" runat="server"></asp:Label></span></div>
                    </div>
                <div style="clear:both;"></div>

 <div style="background-color:#184684; width:1025px; text-align:center; border-bottom:1px solid #000000; border-top:1px solid #000000;">
                        <h3 style="margin:0px; padding:5px; color:black;"> 
                            <asp:Label ID="lbl_head" runat="server" style="font-weight:normal;">JOB P & L</asp:Label></h3>
                    </div>
                <div style="clear:both;"></div>

                    <div style="background-color:#878788; width:99.1%; padding:5px; font-size:16px; font-weight:normal; text-align:center; height:18px">
                        <label id="lbl_job" runat="server" style="color:black;"></label>
                           
                            <asp:Label ID="txt_job" runat="server" style="color:black; font-weight:normal;"></asp:Label>
                    </div>

      <div style="float:left; width:100%;border-top: 1px solid black;border-left: 1px solid black;border-right: 1px solid black;">
      <div style="padding:0px 0px -1px 0px;">


          <div style="width:692px; float:left; border-right:0px solid #fff;">
                        <div style="background-color:#d0d0d0; width:692px; float:left; padding:15px 0px 0px 0px; min-height:141px;">
                            <label id="lbl_vsv" runat="server" style="font-weight:bold; width: 145px; float: left; display: inline-block; margin: 0px 0px 10px 20px; font-weight: bold;">Vessel</label>
                            
                            <span style="width: 380px; float: left; display: inline-block; margin: 0px 0px 5px 0px;"><asp:Label ID="lbl_vslvoy" runat="server"></asp:Label></span>
                           <div style="clear:both;"></div>
                             <label id="label_mlo" runat="server" style="font-weight:bold; width: 145px; float: left; display: inline-block; margin: 0px 0px 10px 20px; font-weight: bold;">MLO </label>
                        
                            <span style="width: 380px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="label_mlo1" runat="server"></asp:Label></span>
                            <div style="clear:both;"></div>
                             <label id="lbl_agent" runat="server" style="font-weight:bold; width: 145px; float: left; display: inline-block; margin: 0px 0px 10px 20px; font-weight: bold;">Agent </label>
                          
                              <span style="width: 380px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_agent1" runat="server"></asp:Label></span>
                            <div style="clear:both;"></div>
                             <label id="lbl_jobcreate" runat="server" style="font-weight:bold; width: 145px; float: left; display: inline-block; margin: 0px 0px 10px 20px; font-weight: bold;">Job Opened on </label>
                            <span style="width: 70px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_jobcreate1" runat="server"></asp:Label></span>

                              <label id="lbl_jobclosed" runat="server" style="font-weight:bold; width: 105px; float: left; display: inline-block; margin: 0px 0px 10px 20px; font-weight: bold;">Job Closed on </label>
                            <span style="width: 147px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_jobclosed1" runat="server"></asp:Label></span>

                            <div style="clear:both;"></div>
                            <label id="lbl_closere" runat="server" style="font-weight:bold; width: 145px; float: left; display: inline-block; margin: 0px 0px 10px 20px; font-weight: bold;">Job Close Remarks </label>
                            <span style="width: 380px; float: left; display: inline-block; margin: 0px 0px 5px 0px;">
                                <asp:Label ID="lbl_closere1" runat="server"></asp:Label></span>
                        </div>
               <%--         <div class="ALTLeft2">
                            <div class="ToLbl">
                                To
                            </div>
                            <div class="ToAddress">
                                <p>
                                    <asp:Label ID="lbl_toaddress" runat="server"></asp:Label><br />
             </p>
                            </div>

                        </div>--%>
             
                    </div>
            
          <div style="background-color:#f5f5f5; width:312px; float:left; display:none;">
                        <div style="background-color:#d0d0d0; width:312px; float:left; padding:15px 0px 0px 20px; min-height:179px;">
                            <label style="width:80px; float:left; display:inline-block; margin:0px 0px 10px 0px; font-weight:bold;">CBM</label>
                            <span>
                                <asp:Label ID="lbl_Cbm" runat="server"></asp:Label></span>
                            <div style="clear:both;"></div>
                              <label id="lbl_contai20" runat="server" style="width:80px; float:left; display:inline-block; margin:0px 0px 10px 0px; font-weight:bold;">Cont20</label>
                            
                            <span>
                                <asp:Label ID="lbl_con20" runat="server"></asp:Label></span>
                            <div style="clear:both;"></div>
                                <div id="lbl_con" runat="server" visible="true">
                            <label id="lbl_con40" runat="server" style="width:80px; float:left; display:inline-block; margin:0px 0px 10px 0px; font-weight:bold;">Cont40</label>
                         
                          <asp:Label ID="lbl_con4" runat="server"></asp:Label></div>
                            <div style="clear:both;"></div>
                            <div id="div_mbl" runat="server" visible="true">
                            <label id="lbl_Agentbl" runat="server" style="width:80px; float:left; display:inline-block; margin:0px 0px 10px 0px; font-weight:bold;">Agent BL</label>
                            
                                <asp:Label ID="lbl_Agentbl1" runat="server"></asp:Label></div>
                             <div style="clear:both;"></div>
                            <div id="div_port" runat="server" visible="true">
                            <label id="lbl_obl" runat="server" style="width:80px; float:left; display:inline-block; margin:0px 0px 10px 0px; font-weight:bold;">Our BL</label>
                         
                                <asp:Label ID="lbl_obl1" runat="server" Width="205px"></asp:Label></div>
                             <div style="clear:both;"></div>

                        </div>
                        
                        
                          <%--  <label>Packages</label>
                            <div class="Dotted">:</div>
                         
                                <asp:Label ID="lbl_package" runat="server"></asp:Label>
                             <div style="clear:both;"></div>
                            <label>Gr Wght</label>
                            <div class="Dotted">:</div>
                           
                                <asp:Label ID="lbl_grwt" runat="server"></asp:Label>
                             <div style="clear:both;"></div>
                            <div id="div_volume" runat="server" visible="true">
                            <label id="lable_volume" runat="server">Volume</label>
                            <div class="Dotted">:</div>
                           
                                <asp:Label ID="lbl_volume" runat="server"></asp:Label></div>
                             <div style="clear:both;"></div>
--%>



                      

                    </div>
       
       <table width="100px" border="0" cellspacing="0" cellpadding="0" class="TblGridReport" style="border-top:1px solid #b1b1b1; width:100%; border-collapse:collapse; border-right:1px solid #cdbcb1; border-left:1px solid #cdbcc1;">
                        <tr>
                            <th style="background-color: #184684; color: black; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #cdbcb1; border-bottom: 1px solid black;" class="auto-style1">Charges</th>
                            <th style="background-color: #184684; color: black; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #cdbcb1; border-bottom: 1px solid black;" class="auto-style1">Billing</th>
                            <th style="background-color: #184684; color: black; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #cdbcb1; border-bottom: 1px solid black;" class="auto-style1">Cost</th>
                            <th style="background-color: #184684; color: black; font-family: sans-serif, Geneva, sans-serif; font-size: 14px; padding: 3px; margin: 0px; border-right: 1px solid #cdbcb1; border-bottom: 1px solid black;" class="auto-style1">Revenue</th>                            
                        </tr>

           

                       <asp:Label ID="tr_row" runat="server"></asp:Label>

    
                         
                    
                
                     
                    
                    </table>
          
      </div>
    </div>

            </div>
            </div>        

    
    </form>
</body>
</html>
