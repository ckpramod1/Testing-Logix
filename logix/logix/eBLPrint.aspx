<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eBLPrint.aspx.cs" Inherits="logix.eBLPrint" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>logix</title>
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.form-components.js"></script>
    <script>
        $(document).ready(function () {



            $('.selectpicker').selectpicker();

            "use strict";

            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins

            //$('select.styled').customSelect();

        });




    </script>
    <style type="text/css">
        select[multiple], select[size]{
    height: 40px;
}
    </style>


    <!-- Demo JS -->
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="border-left:0">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
  <asp:UpdateProgress id="UpdateProgress1" runat="server">
        <progresstemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
</progresstemplate>
    </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

             <!-- Breadcrumbs line -->
                <div class="crumbs">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>
                        <li class="current" id="lbl" runat="server">eBL Print </li>
                    </ul>
                </div>

            <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header">
                                <h4><i class="icon-umbrella"></i>
                                   <asp:Label ID="Label1" runat="server" Text="e-Bill of Lading"></asp:Label></h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="right_btn MT0">
                                        <div class="btn btn-NonNegotiable"><asp:Button ID="btnnego" runat="server" Text="NonNegotiable" /></div>
                                        <div class="btn btn-FristOriginal"><asp:Button ID="btnoriginal1" runat="server" Enabled="False" OnClick="btnoriginal_Click" Text="First Original"/></div>
                                        <div class="btn btn-SecondOriginal"><asp:Button ID="btnoriginal2" runat="server" Enabled="False" OnClick="btnoriginal_Click" Text="Second Original"  /></div>
                                        <div class="btn btn-ThirdOrginal"><asp:Button ID="btnoriginal3" runat="server" Enabled="False"  OnClick="btnoriginal_Click" Text="Third Original" /></div>
                                        <div class="btn btn-Original"> <asp:Button ID="btnoriginal" runat="server" OnClick="btnoriginal_Click" Text="Original" Visible="False" /></div>
                                    </div>
                                    </div>
                                 <div class="FormGroupContent4">
                                     <div class="JobNumber1"><asp:TextBox ID="txtJobNo" runat="server" CssClass="form-control" ToolTip="Job #" placeholder="Job #"  AutoPostBack="True" TabIndex="1"
                                    ReadOnly="True"></asp:TextBox></div>
                                     <div class="BillJobInput"><asp:TextBox ID="txtJobDetails" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Job Detail" placeholder="Job Detail" TabIndex="2"></asp:TextBox></div>
                                     <div class="BookingNo"><asp:TextBox ID="txtBookingNo" runat="server" ReadOnly="True" ToolTip="Booking#" CssClass="form-control" placeholder="Booking#" TabIndex="3"></asp:TextBox></div>
                                 </div>
                                <div class="FormGroupContent4">
                                <div class="BillBL"><asp:TextBox ID="txtBLNo" runat="server" OnTextChanged="txtBLNo_TextChanged" TabIndex="4" ReadOnly="True" CssClass="form-control" ToolTip="BL #" placeholder="BL #"></asp:TextBox></div>
                                    <div class="IssuedAtTxtbox"><asp:TextBox ID="txtIssuedAt" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Issued At" placeholder="Issued At" TabIndex="5"></asp:TextBox></div>
                                
                                <div class="IssuedOntxtbox"><asp:TextBox ID="txtIssuedOn" runat="server"  TabIndex="6" MaxLength="10" CssClass="form-control" ToolTip="Issued On" placeholder="Issued On" ReadOnly="True"></asp:TextBox></div>
                                <div class="FreightTxtbox"><asp:TextBox ID="ddlFreight" runat="server" CssClass="form-control" ToolTip="Freight" placeholder="Freight" TabIndex="7" ReadOnly="True"></asp:TextBox></div>
                                </div>
                                
                            <div class="FormGroupContent4">
                                <div class="ShipperTxtbox"><asp:TextBox CssClass="form-control" ID="txtShipperName" runat="server"  ReadOnly="True" TabIndex="8" ToolTip="Shipper" placeholder="Shipper"></asp:TextBox></div>
                                <div class="ConsigneeTxtbox"><asp:TextBox CssClass="form-control" ID="txtConsigneeName" runat="server"  ReadOnly="True" TabIndex="9" ToolTip="Consignee" placeholder="Consignee"></asp:TextBox></div>
                            
                            </div>
                            <div class="FormGroupContent4">
                                <div class="ShipperAddressBill"> <asp:TextBox CssClass="form-control" ID="txtShipperAddr" runat="server"  TabIndex="10" MaxLength="250" ReadOnly="True" Height="55px" TextMode="MultiLine"></asp:TextBox></div>
                                <div class="ConsigneeAddress1"><asp:TextBox CssClass="form-control" ID="txtConsigneeAdr" runat="server" TabIndex="11" MaxLength="250" ReadOnly="True" Height="55px" TextMode="MultiLine"></asp:TextBox></div>
                                </div>
                            <div class="FormGroupContent4">
                                <div class="NotifyTxtBox"><asp:TextBox CssClass="form-control" ID="txtNPName" runat="server"  ReadOnly="True" ToolTip="Notify Party" TabIndex="12" placeholder="Notify Party"></asp:TextBox></div>
                               <div class="AgentTxtBox"><asp:TextBox CssClass="form-control" ID="txtAgentName" runat="server"  ReadOnly="True" TabIndex="13" ToolTip="Agent" placeholder="Agent"></asp:TextBox></div>
                                
                                 </div>
                              <div class="FormGroupContent4">
                                  <div class="NotifyAddress"><asp:TextBox CssClass="form-control" ID="txtNPAddr" runat="server"  TabIndex="14" MaxLength="250" ReadOnly="True" Height="55px" TextMode="MultiLine"></asp:TextBox></div>
                                  <div class="AgentAddress"><asp:TextBox CssClass="form-control" ID="txtAgentAddr" runat="server" TabIndex="15" MaxLength="250" ReadOnly="True" Height="55px" TextMode="MultiLine"></asp:TextBox></div>
                                  </div>
                            <div class="FormGroupContent4">
                                <div class="ReceiptTxtbox"> <asp:TextBox ID="txtPOR" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="16" ToolTip="Place of Receipt" placeholder="Place Of Receipt"></asp:TextBox></div>
                               <div class="PortTxtbox"><asp:TextBox ID="txtPOL" runat="server"  ReadOnly="True" CssClass="form-control" TabIndex="17" ToolTip="Port Of Loading" placeholder="Port Of Loading"></asp:TextBox></div>
                                <div class="PortDischargeTxtBox"><asp:TextBox ID="txtPOD" runat="server"  ReadOnly="True" CssClass="form-control" TabIndex="18" ToolTip="Port Of Discharge" placeholder="Port Of Discharge"></asp:TextBox></div>
                                 <div class="FinalTxtbox"><asp:TextBox ID="txtFD" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="19" ToolTip="Final Destination" placeholder="Final Destination"></asp:TextBox></div>
                            
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MarksTxtBox"><asp:TextBox ID="txtMksNum" runat="server"  TabIndex="20" MaxLength="250"
                                    ReadOnly="True" CssClass="form-control" ToolTip="Marks And Numbers" placeholder="Marks And Numbers"></asp:TextBox></div>
                                <div class="CommodityTxtBox"><asp:TextBox ID="txtCommudity" runat="server"  ReadOnly="True" CssClass="form-control" TabIndex="21" ToolTip="Commodity" placeholder="Commodity"></asp:TextBox></div>
                               
                                <div class="Orignaltxtbox"><asp:TextBox ID="txtOriginalBL" runat="server" TabIndex="21" MaxLength="1"
                                    ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                 </div>
                            <div class="FormGroupContent4">
                                <div class="DescrTxtBox"> <asp:TextBox ID="txtDesc" runat="server" TabIndex="22" MaxLength="250"
                                    Font-Overline="False" ReadOnly="True" CssClass="form-control" ToolTip="Description" placeholder="Description"></asp:TextBox></div>
                                <div class="ChaTxtBox"><asp:TextBox ID="txtCHA" runat="server"  ReadOnly="True" CssClass="form-control" ToolTip="CHA" TabIndex="23" placeholder="CHA"></asp:TextBox></div>
                                </div>
                             <div class="FormGroupContent4">
                                 <div class="CBMLeft"> 
                                 <div class="CBMTxtBox"><asp:TextBox ID="txtCBM" runat="server" TabIndex="24"  MaxLength="3"
                                                ReadOnly="True" CssClass="form-control" ToolTip="CBM" placeholder="CBM"></asp:TextBox></div>
                                     <div class="WTKgsTxtBox"><asp:TextBox ID="txtGrWt" runat="server" TabIndex="25"  ReadOnly="True" CssClass="form-control" ToolTip="G.Wt.Kgs" placeholder="G.Wt.Kgs"></asp:TextBox></div>
                                    <div class="NWtKGS">

                                         <asp:TextBox ID="txtNtWt" runat="server" TabIndex="26" ReadOnly="True" CssClass="form-control" ToolTip="N.Wt.Kgs" placeholder="N.Wt.Kgs"></asp:TextBox>
                                    </div>
                                     <div class="NoOfpkgTxtBox"><asp:TextBox ID="txtPackages" runat="server" TabIndex="27" ReadOnly="True" CssClass="form-control" ToolTip="No of Pkg" placeholder="No of Pkg"></asp:TextBox></div>
                                    <div class="UnitsTxtBox"><asp:TextBox ID="ddlUnits" runat="server" ReadOnly="True" TabIndex="28" CssClass="form-control" ToolTip="Units" placeholder="Units"></asp:TextBox></div>
                                       <div class="ShipmentTxtBox"><asp:TextBox ID="ddlSpmtType" runat="server" ReadOnly="True" TabIndex="29" CssClass="form-control" ToolTip="Shipment" placeholder="Shipment"></asp:TextBox></div>
                                 <div class="SurrendertxtBox"><asp:TextBox ID="ddlSurrendered" runat="server" ReadOnly="True" TabIndex="30"  CssClass="form-control" ToolTip="Surrendered" placeholder="Surrendered"></asp:TextBox></div>
                                   <div class="FormGroupContent4">
                                       <div class="RemarksTxtBox"><asp:TextBox ID="txtRemarks" runat="server"  MaxLength="100" TabIndex="31" ReadOnly="True"  CssClass="form-control"></asp:TextBox></div>
                                 <div class="DGCargoChkBox"><asp:CheckBox Text="DGCargo" ID="chkDGCargo" runat="server" TabIndex="32" 
                                    Enabled="False" /></div>
                                       </div>
                                 </div>
                                 <div class="CBMRight">
                                     <div class="FormGroupContent4">
                                     <div class="ContLbl">Container(s)</div>
                                     <div class="ContLBL1"><asp:Panel ID="Panel1" runat="server" 
                                    Height="50px" CssClass="Pnl" style="margin:-14px 0px 0px 0px;">
                                    &nbsp;<asp:ListBox ID="LstContainer" runat="server" CssClass="form-control"></asp:ListBox></asp:Panel></div>
                                         </div>
                                 </div>
                                 <div style="float:left; width:50%; margin:10px 0px 10px 10px;">  <asp:Label ID="lbl_BLTakenDet1" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lbl_BLTakenDet2" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lbl_BLTakenDet3" runat="server"></asp:Label></div>
                                 </div>
                           
                            </div>
                        </div>
                </div>
               
   <asp:HiddenField ID="txtIssuedAtId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtMsgRes" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtOldCbm" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtShipperId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtConsId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtNotifyPartyId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtAgentId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtPorId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtPolId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtPodId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtFdId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="txtChaId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hidCommudityID" runat="server" />
                    <asp:HiddenField ID="hidSalesID" runat="server" />
                    <asp:HiddenField ID="hidBLFormat" runat="server"></asp:HiddenField>
     </ContentTemplate>
</asp:UpdatePanel>
        
    </form>
</body>
</html>
