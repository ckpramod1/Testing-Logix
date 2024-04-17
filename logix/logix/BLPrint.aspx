<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLPrint.aspx.cs" Inherits="logix.BLPrint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="elaa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

       <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Theme/bootstrap/css/bootstrap.css" rel="stylesheet" />
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






    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_bl.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "BLPrint.aspx/GetBLNo_Blprint",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").change();

                    },
                    change: function (event, i) {

                        $("#<%=txt_bl.ClientID %>").val(i.item.value);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.value);
                    },
                    close: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.value);
                    },
                    minLength: 1
                });
            });
                $(document).ready(function () {

                    $("#<%=txt_book.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "BLPrint.aspx/GetBLNo_BlNo",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_book.ClientID %>").change();

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_book.ClientID %>").val(i.item.value);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txt_book.ClientID %>").val(i.item.value);
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_book.ClientID %>").val(i.item.value);
                        }
                    },
                    minLength: 1
                });
            });

        }
    </script>

    <style type="text/css" >
    .div_total
{
     width :100%;
  height:100%;



}

     .row {
            height:358px!important;
            overflow:auto;
            margin: 0px 0px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            background-color: #ffffff;
            width: 80.5%; 
        }

        .widget.box {
            height:575px;
        }

        .BillBooking {
    width: 6.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

            .BillBooking a {
                color:navy!important;
            }
        .BillBookingTxtbox {
    width: 21.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .BillQuotTxt {
    width: 7.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .BillQuotTxt a {
                color:navy!important;
            }



        .BillQuotTxtbox {
    width: 41.5%;
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
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header" id="div1" runat="server">
                                <h4><i class="icon-umbrella"></i>
                                   <asp:Label ID="lbl_header" runat="server"  Text="Bill of Lading"></asp:Label></h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4" id="div_BLDetails" runat="server">
                                    <div class="BillBLTxtBox1">
                                        <div style="display:none;"><asp:Label ID="lbl_bl" runat="server" Text="BL#"></asp:Label></div>
                                        <asp:TextBox ID="txt_bl" runat="server" AutoPostBack="True" CssClass="form-control" ToolTip="BL#" placeholder="BL#" TabIndex="1"></asp:TextBox>
                                    </div>
                                    <div class="BillDate1">
                                        <div style="display:none;"><asp:Label ID="lbl_jobtype" runat="server"  Text="Date"></asp:Label></div>

                                        <asp:TextBox ID="txt_date" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Date" TabIndex="2"></asp:TextBox>

                                    </div>
                                    <div class="BillJobTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_date" runat="server" Text="Job/Type"></asp:Label></div>
                                        <asp:TextBox ID="txt_jobtype" runat="server"  ReadOnly="True" CssClass="form-control" TabIndex="3" placeholder="Job/Type" ToolTip="Job/Type"></asp:TextBox>

                                    </div>
                                    <div class="BillBooking">
                                        <asp:LinkButton ID="lnk_book" runat="server" style="text-decoration:none;" TabIndex="4">Booking#</asp:LinkButton>
                                    </div>
                                    <div class="BillBookingTxtbox"><asp:TextBox ID="txt_book" runat="server" ReadOnly="True" ToolTip="Booking" CssClass="form-control" TabIndex="5"></asp:TextBox></div>
                                    </div>
                                <div class="FormGroupContent4">

                                    <div class="BillStatusTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_hbl" runat="server" Text="Status"></asp:Label></div>

                                        <asp:TextBox ID="txt_hbl" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Status" placeholder="Status" TabIndex="6"></asp:TextBox>


                                    </div>
                                    <div class="BillIssuedTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_issued" runat="server"  Text="Issued At"></asp:Label></div>
                                        
                                        <asp:TextBox ID="txt_issued" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Issued At" placeholder="Issued At" TabIndex="7"></asp:TextBox>

                                    </div>
                                    <div class="BillMBLTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_mbl" runat="server" Text="MBL#"></asp:Label></div>

                                        <asp:TextBox ID="txt_mbl" runat="server" ReadOnly="True" TabIndex="8" ToolTip="MBL #" placeholder="MBL #" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="BillStatusTxtbox1">

                                        <div style="display:none;"><asp:Label ID="lbl_mblstatus" runat="server"  Text="Status"></asp:Label> </div>
                                         <asp:TextBox ID="txt_mblstatus" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" TabIndex="9" ToolTip="Status" placeholder="Status"></asp:TextBox> 
                                    </div>
                                    </div>
                                <div class="FormGroupContent4">

                                    <div class="BillQuotTxt"><asp:LinkButton ID="lnk_Quotation" runat="server"  style="text-decoration:none;" TabIndex="10" >Quotation#</asp:LinkButton></div>
                                    <div class="BillQuotTxtbox"><asp:TextBox ID="txt_Quotation" runat="server" ReadOnly="True" ToolTip="Quotation" TabIndex="11" CssClass="form-control"></asp:TextBox></div>
                                    
                                <div class="BillCFSTxtBox">
                                    <div style="display:none;"><asp:Label ID="lbl_mlo" runat="server" Text="CFS"></asp:Label></div>
                                    <asp:TextBox ID="txt_mlo" runat="server" ReadOnly="True" ToolTip="CFS" placeholder="CFS" TabIndex="12" CssClass="form-control"></asp:TextBox>
                                  </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="BillVesTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_vessel" runat="server" Text="F.Ves/Voy"></asp:Label></div>
                                        <asp:TextBox ID="txt_vessel" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="F.Ves/Voy" TabIndex="13" placeholder="F.Ves/Voy"></asp:TextBox> 
                                    </div>
                                    <div class="MVessselTxtbox">
                                        <div style="display:none;"> <asp:Label ID="lbl_mvessel" runat="server" Width="100%" Text="M.Vessel"></asp:Label></div>
                                       
                                        <asp:TextBox ID="txt_mvessel" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="M.Vessel" placeholder="M.Vessel" TabIndex="14"></asp:TextBox>
                                    </div>


                                    </div>
                                <div class="FormGroupContent4">

                                    <div class="BillPoLTxtBox">
                                        <div style="display:none;"><asp:Label ID="lbl_fpol" runat="server" Width="100%"  Text="PoL"></asp:Label></div>
                                        
                                        <asp:TextBox ID="txt_fpol" runat="server" ReadOnly="True" CssClass="form-control" placeholder="PoL" ToolTip="PoL" TabIndex="15"> </asp:TextBox>
                                    </div>
                                    <div class="BillEtdTxtBox">

                                        <div style="display:none;"><asp:Label ID="lbl_fetd" runat="server" Text="ETD"></asp:Label></div>

                                         <asp:TextBox ID="txt_fetd" runat="server"  ReadOnly="True" CssClass="form-control" placeholder="ETD" ToolTip="ETD" TabIndex="16"></asp:TextBox>
                                    </div>
                                    <div class="BillPolTxtBox1">
                                        <div style="display:none;"> <asp:Label ID="lbl_mpol" runat="server" Width="100%"  Text="PoL"></asp:Label></div>
                                        <asp:TextBox ID="txt_mpol" runat="server" Width="100%"  ReadOnly="True" CssClass="form-control" placeholder="PoL" ToolTip="PoL" TabIndex="17"></asp:TextBox>
                                    </div>
                                    <div class="BillEtdTxtBox1">

                                        <div style="display:none;"><asp:Label ID="lbl_metd" runat="server" Width="100%" Text="ETD"></asp:Label></div>
                                        <asp:TextBox ID="txt_metd" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" placeholder="ETD" ToolTip="ETD" TabIndex="18"></asp:TextBox>

                                    </div>

                                </div>

                                <div class="FormGroupContent4">

                                    <div class="BillPodTxtBox1">
                                        <div style="display:none;"><asp:Label ID="lbl_fpod" runat="server" Width="100%" Text="PoD"></asp:Label> </div>
                                        
                                        <asp:TextBox ID="txt_fpod" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="PoD" placeholder="PoD" TabIndex="19"></asp:TextBox>

                                    </div>
                                    <div class="BillEtaTxtBox1">
                                        <div style="display:none;"><asp:Label ID="lbl_feta" runat="server" Width="100%" Text="ETA"></asp:Label></div>
                                        <asp:TextBox ID="txt_feta" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="ETA" placeholder="ETA" TabIndex="20"></asp:TextBox>


                                    </div>
                                    <div class="BillPodTxtBox2">

                                        <div style="display:none;"><asp:Label ID="lbl_mpod" runat="server" Width="100%" Text="PoD"></asp:Label></div>

                                        <asp:TextBox ID="txt_mpod" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="PoD" placeholder="PoD" TabIndex="21"></asp:TextBox>
                                    </div>
                                    <div class="BillEtaTxtbox2">
                                        <div style="display:none;"><asp:Label ID="lbl_meta" runat="server" Width="100%" Text="ETA"></asp:Label></div>

                                        <asp:TextBox ID="txt_meta" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="ETA" placehodlder="ETA" TabIndex="22"></asp:TextBox>

                                    </div>

                                </div>
                                 <div class="FormGroupContent4">
                                     <div class="ShipperTxtBox1">
                                         <div style="display:none;"><asp:Label ID="lbl_shipper" runat="server" Text="Shipper"></asp:Label></div>
                                         <asp:TextBox ID="txt_shipper" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Shipper" placeholder="Shipper" TabIndex="23"></asp:TextBox>

                                     </div>
                                     <div class="BillConsigneeTxtBox">

                                         <div style="display:none;"><asp:Label ID="lbl_consignee" Width="100%" runat="server" Text="Consignee"></asp:Label></div>

                                         <asp:TextBox ID="txt_consignee" Width="100%" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Consignee" placeholder="Consignee" TabIndex="24"></asp:TextBox>
                                     </div>
                                     
                                     </div>
                                <div class="FormGroupContent4">
                                    <div class="ShipperAddTxtBox"><asp:TextBox ID="txtShipperaddr" runat="server" ToolTip="Shipper Address" CssClass="form-control" Height="35px" TabIndex="25" TextMode="MultiLine" Width="100%" style="resize:none;" ReadOnly="True" > </asp:TextBox></div>
                                    <div class="ConsignAddTxtBox"><asp:TextBox ID="txtConsgaddr" runat="server"  ToolTip="Consignee Address" CssClass="form-control" Height="35px" TabIndex="26" TextMode="MultiLine" Width="100%" style="resize:none;" ReadOnly="True" > </asp:TextBox></div>
                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="NotifyTxtbox1">
                                        <div style="display:none;"> <asp:Label ID="lbl_notify" runat="server" Text="Notify"></asp:Label></div>
                                         <asp:TextBox ID="txt_notify" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Notify" placeholder="Notify" TabIndex="27"></asp:TextBox>

                                    </div>
                                    <div class="AgentTxtBox1">
                                        <div style="display:none;"><asp:Label ID="lbl_agent" runat="server" Width="100%" Text="Agent"></asp:Label></div>
                                         <asp:TextBox ID="txt_agent" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="28" placeholder="Agent" ToolTip="Agent"></asp:TextBox>
                                    </div>

                                    </div>
                                <div class="FormGroupContent4">

                                    <div class="NotifyAddTxtbox"><asp:TextBox ID="txtNotifyaddr" runat="server" ToolTip="Notify Address" Height="35px" TextMode="MultiLine" TabIndex="29" CssClass="form-control" style="resize:none;" ReadOnly="True" > </asp:TextBox></div>

                                    <div class="AgentAddTxtBox"><asp:TextBox ID="txtAgentaddr" runat="server" ToolTip="Agent Address" CssClass="form-control" TabIndex="30"  Height="35px" TextMode="MultiLine" Width="100%" style="resize:none;" ReadOnly="True" > </asp:TextBox></div>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="BillPoRTxtbox">

                                        <div style="display:none;"><asp:Label ID="lbl_POR" runat="server" Width="100%" Text="PoR"></asp:Label></div>
                                        <asp:TextBox ID="txt_POR" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" TabIndex="31" ToolTip="PoR" placeholder="PoR"></asp:TextBox>
                                    </div>
                                    <div class="BillPolTxtBox2">

                                        <div style="display:none;"><asp:Label ID="lbl_POL" runat="server" Width="100%" Text="PoL"></asp:Label></div>

                                        <asp:TextBox ID="txt_POL" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="32" ToolTip="PoL" placeholder="PoL"> </asp:TextBox>


                                    </div>
                                    <div class="BillPodTxtBox3">
                                        <div style="display:none;"><asp:Label ID="lbl_POD" runat="server"  Width="100%" Text="PoD"></asp:Label></div>
                                        
                                        <asp:TextBox ID="txt_POD" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="33" ToolTip="PoD" placeholder="PoD"> </asp:TextBox>


                                    </div>
                                     <div class="BillFDTxtBox">
                                         <div style="display:none;"><asp:Label ID="lbl_FD" runat="server" Width="100%" Text="FD"></asp:Label></div>
                                          <asp:TextBox ID="txt_FD" Width="100%" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="34" ToolTip="FD" placeholder="FD"></asp:TextBox>

                                         </div>

                                    </div>
                                <div class="FormGroupContent4">

                                    <div class="BillFreight"><asp:TextBox ID="txt_freight" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" TabIndex="35" ToolTip="Freight" placeholder="Frieght"></asp:TextBox></div>

                                    <div class="BillPackages">
                                        <div style="display:none;"> <asp:Label ID="lbl_packages" runat="server" Width="100%"  Text="Packages" CssClass="form-contorl"></asp:Label></div>
                                       

                                        <asp:TextBox ID="txt_packages" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="36" ToolTip="Packages" placeholder="Packages"></asp:TextBox>


                                    </div>
                                    <div class="BillVolume">

                                         <div style="display:none;"><asp:Label ID="lbl_volume" runat="server" Text="Volume"></asp:Label></div>

                                    <asp:TextBox ID="txt_volume" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="37" ToolTip="Volume" placeholder="Volume"></asp:TextBox>

                                    </div>
                                <div class="BillKgs">
                                    <div style="display:none;"><asp:Label ID="lbl_kgs" runat="server" Text="Kgs" Width="100%" ></asp:Label></div>
                                   <asp:TextBox ID="txt_kgs" Width="100%" runat="server" ReadOnly="True" CssClass="form-control" TabIndex="38" placeholder="Kgs" ToolTip="Packages"></asp:TextBox>
                                </div>
                                
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="BillLeft">

                                        <div class="FormGroupContent4">
                                            <div style="display:none;"><asp:Label ID="lbl_cargo" runat="server" Width="100%" Text="Description"></asp:Label></div>
                                            
                                            <asp:TextBox ID="txt_cargo" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" TabIndex="39" placeholder="Description" ToolTip="Description"></asp:TextBox>
                                        </div>
                                        <div class="FormGroupContent4">

                                            <div style="display:none;"><asp:Label ID="lbl_mark" runat="server" Text="Marks&Nos"></asp:Label></div>
                                            <asp:TextBox ID="txt_mark" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" TabIndex="40" placeholder="Marks & Nos" ToolTip="Marks & Nos"></asp:TextBox>
                                        </div>
                                        <div class="FormGroupContent4">

                                            <div style="display:none;"><asp:Label ID="lbl_remark" runat="server" Width="100%" Text="Remarks"></asp:Label></div>

                                            <asp:TextBox ID="txt_remark" runat="server" Width="100%" ReadOnly="True" CssClass="form-control" TabIndex="41" placeholder="Remarks" ToolTip="Remarks"></asp:TextBox>


                                            </div>
                                        <div class="FormGroupContent4"><asp:TextBox ID="txtLineDesuff" runat="server" Width="100%" ReadOnly="True" TabIndex="42" CssClass="form-control"> </asp:TextBox></div>

                                    </div>

                                    <div class="BillRight">
                                        <div class="ContLbl"><asp:Label ID="lbl_container" runat="server" Text="Container #/Size/Seal #"></asp:Label></div>
                                        <div style="clear:both;"></div>
                                        <div class="ContList" id="divcontno" runat="server"><asp:ListBox ID="chk_container" runat="server"  Height="78px" Width="100%" TabIndex="39" Font-Names="sans-serif" Font-Size="10pt" CssClass="form-control"> </asp:ListBox></div>
                                    </div>
                                    </div>
                                <div class="FormGroupContent4">

                                    <div class="right_btn MT0" id="div_Bltbn" runat="server">
                                        <div class="btn btn-print"><asp:Button ID="Btn_Print" runat="server" Text="Print" TabIndex="40" CssClass="btn_print"  Visible="false" onclick="Btn_Print_Click"  /></div>
                                        <div class="btn ico-cancel"> <asp:Button ID="Btn_cancel" runat="server" Text="Cancel" TabIndex="41" Visible="false" onclick="Btn_cancel_Click1" /></div>
                                                    
               

                                    </div>
                                    <div class="FormGroupContent4">


                                        <div class="LineTxtbox"> 
                                            
                                            <div style="display:none;"><asp:Label ID="lbl_line" runat="server" Text="Line #" TabIndex="42"  Visible="false" ></asp:Label></div>

                                            <asp:TextBox ID="txt_line" runat="server" ReadOnly="True" Visible="false" TabIndex="43"  CssClass="form-control" ></asp:TextBox>

                                        </div>


                                        <div class="JobIM1">
                                            <div style="display:none;"><asp:Label ID="lbl_job" runat="server" Text="Job/IM #" Visible="false" ></asp:Label></div>
                                            

                                            <asp:TextBox ID="txt_job" runat="server" ReadOnly="True" Visible="false" TabIndex="44" CssClass="form-control"></asp:TextBox>

                                        </div>

                                    </div>

                                </div>

                                </div>
                            </div>
                        </div>
                </div>









   
        
        
        
        


     
    <asp:HiddenField ID="hid_BL" runat="server" Value="false" />
    <asp:HiddenField ID="hid_job" runat="server" />
    <asp:HiddenField ID="hid_contno" runat="server" />
    <asp:HiddenField ID="hid_customer" runat="server" />
    <asp:HiddenField ID="hid_BookingNo" runat="server" />
    <asp:HiddenField ID="hid_head" runat="server" />
    <asp:HiddenField ID="hid_cha" runat="server" />
    <asp:HiddenField ID="hid_split" runat="server" />
  
    </form>
</body>
</html>
