<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AEIBLPrintNew.aspx.cs" Inherits="logix.AEIBLPrintNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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



    <!-- Demo JS -->
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <style type="text/css">
        .row {
            width:81%;
        }
        .AwblQuotationTxt {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .AwblQuotationTxtBox {
    width: 28.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Breadcrumbs line -->
                <div class="crumbs" style="display:none;">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>
                        <li class="current" id="lbl" runat="server">Bill Of Lading</li>
                    </ul>
                </div>

            <div >
                    <div class="col-md-12">

                        <div class="widget box">

                            <div class="widget-header" id="div_BLDetails" runat="server">
                                <h4><i class="icon-umbrella"></i>
                                   <asp:Label ID="lbl_header" runat="server"  Text="Bill of Lading"></asp:Label></h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="AwblTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_bl" runat="server" Text="AWBL#"></asp:Label></div>

                                        <asp:TextBox ID="txt_bl" runat="server" AutoPostBack="True" placeholder="AWBL#" ToolTip="AWBL#" CssClass="form-control" TabIndex="1"></asp:TextBox>

                                    </div>
                                    <div class="AwblDateTxtBox">
                                        <div style="display:none;"> <asp:Label ID="lbl_jobtype" runat="server"  Width="100%"  Text="Date"></asp:Label></div>
                                        <asp:TextBox ID="txt_date" runat="server"  ReadOnly="True" CssClass="form-control" TabIndex="2" ToolTip="Date"></asp:TextBox>
                                        </div>
                                    <div class="AwblJobTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_date" runat="server" Width="100%" Text="Job"></asp:Label></div>
                                        <asp:TextBox ID="txt_jobtype" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="3" ToolTip="Job" placeholder="Job"></asp:TextBox>
                                        </div>
                                      <div class="AwblBookingLBL">

                                       <asp:LinkButton ID="lnk_book" runat="server" ForeColor="Black" Width="100%" style="text-decoration:none;" >Booking#</asp:LinkButton>

                                    </div>
                                    <div class="AwblBookingTxtBox"><asp:TextBox ID="txt_book" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="4" ToolTip="Booking" placeholder="Booking"></asp:TextBox></div>
                                    </div>
                                <div class="FormGroupContent4">
                                  <div class="AwblStatusTxtBox">

                                      <div style="display:none;"><asp:Label ID="lbl_hbl" runat="server" Text="Status"></asp:Label></div>
                                      <asp:TextBox ID="txt_hbl" runat="server" ReadOnly="True" ToolTip="Status" TabIndex="5" placeholder="Status" CssClass="form-control"></asp:TextBox>
                                  </div>
                                    <div class="AwblIssuedTxtBox">
                                        
                                        <div style="display:none;"><asp:Label ID="lbl_issued" runat="server" Width="100%" Text="Issued At"></asp:Label></div>
                                        
                                        <asp:TextBox ID="txt_issued" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="6" ToolTip="Issued At" placeholder="Issued At"></asp:TextBox>


                                    </div>
                                     <div class="AwblMBLTxtBox">
                                         
                                             <div style="display:none;"> <asp:Label ID="lbl_mbl" runat="server" Text="MBL#"></asp:Label></div>
                                         <asp:TextBox ID="txt_mbl" runat="server"   ReadOnly="True" CssClass="form-control" ToolTip="MBL#" TabIndex="7" placeholder="MBL#"></asp:TextBox>
                                         
                                         </div>
                                    <div class="AwblStatusTxtBox1">
                                        <div style="display:none;"><asp:Label ID="lbl_mblstatus" runat="server" Width="100%" Text="Status"></asp:Label></div>
                                        <asp:TextBox ID="txt_mblstatus" runat="server" ReadOnly="True" ToolTip="Status" TabIndex="8" CssClass="form-control" placeholder="Status"></asp:TextBox>

                                    </div>
                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="AwblQuotationTxt"><asp:LinkButton ID="lnk_Quotation" runat="server" ForeColor="Black"  style="text-decoration:none;" TabIndex="5">Quotation#</asp:LinkButton></div>
                                   <div class="AwblQuotationTxtBox"><asp:TextBox ID="txt_Quotation" runat="server"  ReadOnly="True" CssClass="form-control" TabIndex="6" ToolTip="Quotation#"></asp:TextBox></div>
                                    <div class="AwblFlightTxtBox">
                                       <div style="display:none;"><asp:Label ID="lbl_vessel" runat="server" Width="100%" Text="Flight"></asp:Label></div> 

                                        <asp:TextBox ID="txt_flight" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="7" ToolTip="Flight" placeholder="Flight"></asp:TextBox>

                                    </div>
                                    <div class="AwblMLOTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_mlo" runat="server" Width="100%"  Text="MLO/FFD"></asp:Label></div>
                                        
                                        <asp:TextBox ID="txt_mlo" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="8" ToolTip="MLO/FED" placeholder="MLO/FED"></asp:TextBox> 


                                    </div>
                                    
                                     </div>
                                
                              <div class="FormGroupContent4">
                                  <div class="AwBLPORTxtBox">
                                      <div style="display:none;"><asp:Label ID="lbl_POR" runat="server" Text="PoR"></asp:Label></div>
                                      
                                      <asp:TextBox ID="txt_POR" runat="server" ReadOnly="True" TabIndex="9" CssClass="form-control" ToolTip="PoR" placeholder="PoR"></asp:TextBox>


                                  </div>
                                  <div class="AwBLPOLTxtBox">
                                      <div style="display:none;"><asp:Label ID="lbl_POL" runat="server" Text="PoL"></asp:Label></div>
                                      <asp:TextBox ID="txt_POL" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="PoL" TabIndex="10" placeholder="PoL"> </asp:TextBox> 

                                  </div>
                                  <div class="AwBLPoDTxtBox">
                                      <div style="display:none;"><asp:Label ID="lbl_POD" runat="server"  Text="PoD"></asp:Label></div>
                                       

                                      <asp:TextBox ID="txt_POD" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="PoD" TabIndex="11" placeholder="PoD"> </asp:TextBox>

                                  </div>
                                  <div class="AwBLFDTxtBox">
                                      <div style="display:none;"><asp:Label ID="lbl_FD" runat="server" Width="100%" Text="FD"></asp:Label></div>


                                      <asp:TextBox ID="txt_FD" runat="server" ReadOnly="True"  CssClass="form-control" ToolTip="FD" TabIndex="12" placeholder="FD"></asp:TextBox>
                                  </div>
                                  </div>
                                 <div class="FormGroupContent4">
                                     <div class="AWBLShipperTxtBox">
                                         <div style="display:none;"><asp:Label ID="lbl_shipper" runat="server" Text="Shipper"></asp:Label></div>
                                         
                                         <asp:TextBox ID="txt_shipper" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="13" ToolTip="Shipper" placeholder="Shipper"></asp:TextBox>

                                     </div>
                                     <div class="AWBLConsigneeTxtBox">

                                         <div style="display:none;"><asp:Label ID="lbl_consignee" Width="100%" runat="server" Text="Consignee"></asp:Label></div>
                                         <asp:TextBox ID="txt_consignee"  runat="server" ReadOnly="True" CssClass="form-control" TabIndex="14" ToolTip="Consignee" placeholder="Consignee"></asp:TextBox>

                                     </div>

                                     </div>
                                <div class="FormGroupContent4">
                                    <div class="AWBLShipperAdd"><asp:TextBox ID="txtShipperaddr" runat="server" Height="35px" ToolTip="Shipper Address" TabIndex="15" CssClass="form-control" TextMode="MultiLine" Width="100%" style="resize:none;" ReadOnly="True" > </asp:TextBox></div>
                                    <div class="AWBLConsigneeAdd"><asp:TextBox ID="txtConsgaddr" runat="server" Height="35px" TextMode="MultiLine" TabIndex="16" ToolTip="Consignee" CssClass="form-control"  style="resize:none;" ReadOnly="True" > </asp:TextBox></div>
                                    </div>
                                  <div class="FormGroupContent4">
                                      <div class="AWBLNotifyTxtBox">
                                          <div style="display:none;"><asp:Label ID="lbl_notify" runat="server" Text="Notify"></asp:Label> </div>
                                           <asp:TextBox ID="txt_notify" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Notify" TabIndex="17" placeholder="Notify"></asp:TextBox>


                                      </div>
                                      <div class="AWBLAgentTxtBox">
                                          <div style="display:none;"><asp:Label ID="lbl_agent" runat="server" Width="100%" Text="Agent"></asp:Label></div>
                                           <asp:TextBox ID="txt_agent" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Agent" TabIndex="18" placeholder="Agent"></asp:TextBox>
                                          </div>
                                      </div>
                                <div class="FormGroupContent4">
                                    <div class="AWBLNotifyAddress"><asp:TextBox ID="txtNotifyaddr" runat="server" CssClass="form-control" TabIndex="19" Height="35px" TextMode="MultiLine" Width="100%" style="resize:none;" ReadOnly="True" > </asp:TextBox></div>
                                    <div class="AWBLAgentAddress"><asp:TextBox ID="txtAgentaddr" runat="server" Height="35px" TextMode="MultiLine" CssClass="form-control" TabIndex="20" style="resize:none;" ReadOnly="True" > </asp:TextBox> </div>
                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="AWBLFrieghtTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_freight" runat="server" Width="100%" Text="Freight"></asp:Label></div>
                                        <asp:TextBox ID="txt_freight" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" TabIndex="21" ToolTip="Freight" placeholder="Freight"></asp:TextBox>
                                    </div>
                                    <div class="AWBLPackagesTxtbox">
                                        <div style="display:none;"><asp:Label ID="lbl_packages" runat="server" Width="100%"  Text="Packages"></asp:Label></div>
                                        <asp:TextBox ID="txt_packages" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Packages" placeholder="Packages" TabIndex="22"></asp:TextBox> 

                                    </div>
                                    <div class="AWBLWeightTxtbox">
                                        <div style="display:none;"><asp:Label ID="lbl_kgs" runat="server" Text="Weight" Width="100%" ></asp:Label></div>
                                        <asp:TextBox ID="txt_kgs" Width="100%" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Weight" placeholder="Weight" TabIndex="23"></asp:TextBox>
                                        </div>
                                    <div class="AWBLCHTxtBox">

                                        <div style="display:none;"><asp:Label ID="lbl_volume" runat="server"  Width="100%" Text="CH.Weight"></asp:Label></div>
                                        <asp:TextBox ID="txt_volume" runat="server"  ReadOnly="True" CssClass="form-control" ToolTip="CH.Weight" TabIndex="24" placeholder="CH.Weight"></asp:TextBox>
                                    </div>
                                    </div>
                             <div class="FormGroupContent4">
                                 <div style="display:none;"> <asp:Label ID="lbl_cargo" runat="server" Width="100%" Text="Description"></asp:Label></div>
                                 <asp:TextBox ID="txt_cargo" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Description" placeholder="Description" TabIndex="25"></asp:TextBox>
                                 </div>
                                <div class="FormGroupContent4">
                                    <div style="display:none;"><asp:Label ID="lbl_mark" runat="server" Text="Marks&Nos"></asp:Label></div>
                                    <asp:TextBox ID="txt_mark" runat="server" ReadOnly="True" placeholder="Marks&Nos" CssClass="form-control" ToolTip="Marks&Nos" TabIndex="26"></asp:TextBox>
                                    </div>
                                <div class="FormGroupContent4">
                                    <div style="display:none;"><asp:Label ID="lbl_remark" runat="server" Width="100%" Text="Remarks"></asp:Label></div>
                                    <asp:TextBox ID="txt_remark" runat="server" ReadOnly="True" placeholder="Remarks" ToolTip="Remarks" CssClass="form-control" TabIndex="27"></asp:TextBox>
                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="right_btn MT0" id="div_Bltbn" runat="server">
                                        <div class="btn btn-print"><asp:Button ID="Btn_Print" runat="server"  Tooltip="Print" TabIndex="28" OnClick="Btn_Print_Click" Visible="false" /> </div>
                                        <div class="btn ico-cancel"><asp:Button ID="Btn_cancel" runat="server"  Tooltip="Cancel"  TabIndex="29"  Visible="false" />  </div>
                                                  
                 


                                    </div>
                                    </div>
                            </div>
                            </div>
                        </div>
                </div>






   




   
    </form>
</body>
</html>
