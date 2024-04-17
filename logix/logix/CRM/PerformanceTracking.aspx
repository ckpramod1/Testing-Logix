<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="PerformanceTracking.aspx.cs" Inherits="logix.CRM.PerformanceTracking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />

    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

    <script type="text/javascript">
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
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>





    <link href="../Styles/PerformanceTracking.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles_Date/jquery1-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Script_Date/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>

    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });

          <%--  $(document).ready(function () {
                $('#<%=GrdFI.ClientID%>').gridviewScroll({
                    width: 1010,
                    height: 450,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });

            $(document).ready(function () {
                $('#<%=grdFE.ClientID%>').gridviewScroll({
                    width: 1010,
                    height: 450,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>
        }
    </script>

    <style type="text/css">
        .crumbslbl {
            display: none;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }


        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .grid_1 {
            width: 100%;
            float: left;
            Height: 421px;
            border: 1px solid Gray;
            margin-left: 0%;
            margin-bottom: 0px;
            overflow: auto;
        }

        .gridpnl {
            height: calc(100vh - 178px) !important;
        }
        /*New Design - Buttons*/
        .btn::before div {
            width: 36px;
            height: 34px;
            background: #f095562e;
            position: absolute;
            content: "";
            border-radius: 6px;
            border-right: 1px solid #b1b1b1;
        }

        .bt input[type="submit"], .bt input[type="button"], .bt button {
            overflow: hidden;
            text-indent: inherit;
            width: auto !important;
            background-position: 2px 2px !important;
            background-color: #f1f1f1;
            margin-right: 5px;
            border: 1px solid #b6b6b6 !important;
            border-radius: 6px;
            padding: 6px 6px 7px 42px !important;
            height: 34px !important;
        }

        .FixedButtonsss {
            position: fixed;
            top: 30px;
            left: 0;
            background: #fff;
            z-index: 10;
            box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
            width: calc(100vw - 5px);
            border-bottom: 0.5px solid #00000010;
            padding: 1px 0 5px 10px;
        }

        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 65px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div>

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblheader" runat="server" Text=" Performance Tracking"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs" id="crumbslbl" runat="server">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="">Customer Support</a> </li>
                            <li><a href="#" title="">Ocean Exports</a> </li>
                            <li class="current"><a href="#" title="">Performance Tracking</a> </li>
                        </ul>
                    </div>
                        </div>

                    <div class="FixedButtons">
    <div class="right_btn">
        <div class="btn ico-get">
            <asp:Button ID="btnGet" runat="server" Text="Get" ToolTip="Get" OnClick="btnGet_Click" TabIndex="3" />
        </div>
        <div class="btn ico-excel">
            <asp:Button ID="btnExporttoexcel" runat="server" Text="Export To Excel" ToolTip="Export 2 Excel" OnClick="btnExporttoexcel_Click" TabIndex="4" />
        </div>
        <div class="btn ico-back" id="btn_back1" runat="server">
            <asp:Button ID="btnBack" runat="server" ToolTip="Back" Text="Back" OnClick="btnBack_Click" TabIndex="5" />
        </div>
    </div>
</div>
                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4">

                        <div class="FromTxtInputbox">
                            <asp:Label ID="lbl_fromdate" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="dtFrom" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="1"></asp:TextBox>
                            <cc1:CalendarExtender ID="dtfrom_cal" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="dtFrom" />
                        </div>

                        <div class="ToLabelInputbox">
                            <asp:Label ID="lbl_todate" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="dtTo" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="2"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="dtTo" />
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">

                        <%--<div class="grid">--%>
                        <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl MB0" Visible="false">
                            <asp:GridView runat="server" ID="GrdFI" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" OnRowDataBound="GrdFI_RowDataBound"
                                OnPageIndexChanging="GrdFI_PageIndexChanging" ShowHeaderWhenEmpty="true" OnPreRender="GrdFI_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="BookingNo" runat="server" HeaderText="Booking #" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="bookingdate" runat="server" HeaderText="Booking Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="qno" runat="server" HeaderText="Quotation #" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="qdate" runat="server" HeaderText="Quotation Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="shipper" runat="server" HeaderText="Shipper" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="consignee" runat="server" HeaderText="Consignee" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="nomination" runat="server" HeaderText="	Controlled By" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="pod" runat="server" HeaderText="POD" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="jobno" runat="server" HeaderText="Job #" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="jobdate" runat="server" HeaderText="Job Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Booking" runat="server" HeaderText="Booking" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Document Collection from Customer" runat="server" HeaderText="Document Collection from Customer" HeaderStyle-Wrap="false" />
                                     <asp:BoundField DataField="Job Updation" runat="server" HeaderText="Job Updation" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Container Depot Out" runat="server" HeaderText="Container Depot Out" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Stuffing Confirmation " runat="server" HeaderText="Stuffing Confirmation " HeaderStyle-Wrap="false" />
                               
                                    <asp:BoundField DataField="SI Updation" runat="server" HeaderText="SI Updation" />
                                    <asp:BoundField DataField="ICD - PoL Movement" runat="server" HeaderText="ICD - PoL Movement" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="AMS / ISF Updation US/CANADA" runat="server" HeaderText="AMS / ISF Updation [US/CANADA]" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Port In" runat="server" HeaderText="Port In" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Draft Approval" runat="server" HeaderText="Draft Approval" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="EGM/IGM Filing Status" runat="server" HeaderText="EGM/IGM Filing Status " HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Sailing Confirmation / Flight Departure" runat="server" HeaderText="Sailing Confirmation / Flight Departure" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Sales Invoice" runat="server" HeaderText="Sales Invoice" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Sales Invoice OC" runat="server" HeaderText="Sales Invoice OC" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="OSSI" runat="server" HeaderText="OSSI" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Purchase Invoice" runat="server" HeaderText="Purchase Invoice" HeaderStyle-Wrap="false" />
                                     <asp:BoundField DataField="Purchase Invoice OC" runat="server" HeaderText="Purchase Invoice OC" HeaderStyle-Wrap="false" />
                                     <asp:BoundField DataField="OSPI" runat="server" HeaderText="OSPI" HeaderStyle-Wrap="false" />
                                   <%-- <asp:BoundField DataField="OSCN Generation" runat="server" HeaderText="OSCN Generation" HeaderStyle-Wrap="false" />--%>
                                    <asp:BoundField DataField="BL /AWB Release" runat="server" HeaderText="BL /AWB Release" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Pre Alert" runat="server" HeaderText="Pre Alert" />
                                    <asp:BoundField DataField="Open Jobs" runat="server" HeaderText="Open Jobs" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="T/S Confirmation " runat="server" HeaderText="T/S Confirmation " HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Dicharge Confirmation  " runat="server" HeaderText="Dicharge Confirmation  " HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="PoD - ICD Movement" runat="server" HeaderText="PoD - ICD Movement" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Customs Clearance" runat="server" HeaderText="Customs Clearance" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Proof of Delivery to Shipper " runat="server" HeaderText="Proof of Delivery to Shipper " HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Empty Return to Depot" runat="server" HeaderText="Empty Return to Depot" HeaderStyle-Wrap="false" />
                                   
                                     
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <%--<RowStyle CssClass="GridviewScrollItem" />--%>
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <%--<EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
        <PagerStyle CssClass="GridviewScrollPager" />--%>
                            </asp:GridView>
                            <asp:GridView runat="server" ID="GrdFI2" AutoGenerateColumns="true" Width="100%" CssClass="Grid FixedHeader" OnRowDataBound="GrdFI_RowDataBound"
                                OnPageIndexChanging="GrdFI_PageIndexChanging" ShowHeaderWhenEmpty="true" OnPreRender="GrdFI_PreRender">
                            </asp:GridView>
                            <div class="div_break"></div>
                        </asp:Panel>
                        <div class="div_break"></div>
                        <%--</div>--%>

                        <div class="div_break"></div>
                        <%--<div class="grid">--%>
                        <asp:Panel ID="Panel2" runat="server" CssClass="tblGridNew2 grid_1" ScrollBars="Horizontal" Visible="false">
                            <asp:GridView runat="server" ID="grdFE" AutoGenerateColumns="False" Width="100%" CssClass="GrdRow"
                                OnPageIndexChanging="grdFE_PageIndexChanging" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <%--                                    <asp:BoundField DataField="jobno" runat="server" HeaderText="Job #" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="jobdate" runat="server" HeaderText="Job Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="BookingNo" runat="server" HeaderText="Booking #" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="bookingdate" runat="server" HeaderText="Booking Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="stuffedon" runat="server" HeaderText="Stuffed On" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="eta" runat="server" HeaderText="Sailed On" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="bldate" runat="server" HeaderText="BL Released On" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="docsent" runat="server" HeaderText="Doc Sent to Agent" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="closedon" runat="server" HeaderText="Closing Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="noofdays" runat="server" HeaderText="No Of Days" HeaderStyle-Wrap="false" />--%>

                                    <asp:BoundField DataField="BookingNo" runat="server" HeaderText="Booking #" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="bookingdate" runat="server" HeaderText="Booking Date" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="qno" runat="server" HeaderText="Quotation #" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="qdate" runat="server" HeaderText="Quotation Date" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="shipper" runat="server" HeaderText="Shipper" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="consignee" runat="server" HeaderText="Consignee" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="nomination" runat="server" HeaderText="	Controlled By" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="pod" runat="server" HeaderText="POD" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="jobno" runat="server" HeaderText="Job #" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="jobdate" runat="server" HeaderText="Job Date" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Booking" runat="server" HeaderText="Booking" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Document Collection from Customer" runat="server" HeaderText="Document Collection from Customer" HeaderStyle-Wrap="false" />
  <asp:BoundField DataField="Job Updation" runat="server" HeaderText="Job Updation" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Container Depot Out" runat="server" HeaderText="Container Depot Out" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Stuffing Confirmation " runat="server" HeaderText="Stuffing Confirmation " HeaderStyle-Wrap="false" />
                               
 <asp:BoundField DataField="SI Updation" runat="server" HeaderText="SI Updation" />
 <asp:BoundField DataField="ICD - PoL Movement" runat="server" HeaderText="ICD - PoL Movement" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="AMS / ISF Updation US/CANADA" runat="server" HeaderText="AMS / ISF Updation [US/CANADA]" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Port In" runat="server" HeaderText="Port In" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Draft Approval" runat="server" HeaderText="Draft Approval" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="EGM/IGM Filing Status" runat="server" HeaderText="EGM/IGM Filing Status " HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Sailing Confirmation / Flight Departure" runat="server" HeaderText="Sailing Confirmation / Flight Departure" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Sales Invoice" runat="server" HeaderText="Sales Invoice" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Sales Invoice OC" runat="server" HeaderText="Sales Invoice OC" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="OSSI" runat="server" HeaderText="OSSI" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Purchase Invoice" runat="server" HeaderText="Purchase Invoice" HeaderStyle-Wrap="false" />
  <asp:BoundField DataField="Purchase Invoice OC" runat="server" HeaderText="Purchase Invoice OC" HeaderStyle-Wrap="false" />
  <asp:BoundField DataField="OSPI" runat="server" HeaderText="OSPI" HeaderStyle-Wrap="false" />
<%-- <asp:BoundField DataField="OSCN Generation" runat="server" HeaderText="OSCN Generation" HeaderStyle-Wrap="false" />--%>
 <asp:BoundField DataField="BL /AWB Release" runat="server" HeaderText="BL /AWB Release" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Pre Alert" runat="server" HeaderText="Pre Alert" />
 <asp:BoundField DataField="Open Jobs" runat="server" HeaderText="Open Jobs" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="T/S Confirmation " runat="server" HeaderText="T/S Confirmation " HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Dicharge Confirmation  " runat="server" HeaderText="Dicharge Confirmation  " HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="PoD - ICD Movement" runat="server" HeaderText="PoD - ICD Movement" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Customs Clearance" runat="server" HeaderText="Customs Clearance" HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Proof of Delivery to Shipper " runat="server" HeaderText="Proof of Delivery to Shipper " HeaderStyle-Wrap="false" />
 <asp:BoundField DataField="Empty Return to Depot" runat="server" HeaderText="Empty Return to Depot" HeaderStyle-Wrap="false" />
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <%--<RowStyle CssClass="GridviewScrollItem" />--%>
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <div class="div_break"></div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </div>

</asp:Content>
