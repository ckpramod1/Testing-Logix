<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="EventTrackingOper.aspx.cs" Inherits="logix.CRM.EventTrackingOper" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <link href="../Styles/EventTrackingOper.css" rel="stylesheet" type="text/css" />
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

           <%-- $(document).ready(function () {
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

        /*LOG DETAILS CSS*/

        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }

        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

            .DivSecPanelLog img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }

        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

        .LogHeadLbl {
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 12px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .FromDateCal {
            width: 7%;
            float: left;
            margin: 0px 0.5% 10px 0px;
        }

        .ToDateCal {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Grid1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            overflow-x: auto !important;
            overflow-y: auto !important;
            height: 390px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

 
 

        .Grid1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            /* overflow-x: auto !important; */
            overflow-y: auto !important;
            overflow: hidden;
            height: 400px;
        }

 
        table#logix_CPH_GrdFI td:nth-child(3) {
    max-width: 115px;
    overflow: hidden;
    text-overflow: ellipsis;
}
   
/*New design - Buttons*/


    
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
table#logix_CPH_grdFE td:nth-child(3) {
    width: 300px !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblheader" runat="server" Text="Event Tracking - Operations"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs" id="crumbslbl" runat="server">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="">Customer Support</a> </li>
                            <li><a href="#" title="" id="tran" runat="server">Ocean Exports</a> </li>
                            <li class="current"><a href="#" title="">Event Tracking - Operations</a> </li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>
                <div class="widget-content">
                    <div class="FixedButtons">
                        <div class="right_btn">
                            <div class="btn ico-get">
                                <asp:Button ID="btnGet" runat="server" Text="Get" ToolTip="Get" OnClick="btnGet_Click" /></div>
                            <div class="btn ico-excel">
                                <asp:Button ID="btnExporttoexcel" runat="server" Text="Export To Excel" ToolTip="Export To Excel" OnClick="btnExporttoexcel_Click" /></div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnBack_Click" /></div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FromDateCal">
                            <asp:Label ID="lbl_fromdate" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="dtFrom" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="1"></asp:TextBox>
                            <cc1:CalendarExtender ID="dtfrom_cal" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="dtFrom" />
                        </div>
                        <div class="ToDateCal">
                            <asp:Label ID="lbl_todate" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="dtTo" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="2"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="dtTo" />
                        </div>
                        
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl" Visible="false">
                            <asp:GridView runat="server" ID="grdFE" AutoGenerateColumns="False" Width="100%" BorderStyle="None" CssClass="Grid FixedHeader"
                                OnPageIndexChanging="grdFE_PageIndexChanging" OnPreRender="grdFE_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="jobno" runat="server" HeaderText="Job #" />
                                    <asp:BoundField DataField="jobdate" runat="server" HeaderText="Job Date" />
                                    <asp:BoundField DataField="BookingNo" runat="server" HeaderText="Booking #" />
                                    <asp:BoundField DataField="bookingdate" runat="server" HeaderText="Booking Date" />
                                    <asp:BoundField DataField="stuffedon" runat="server" HeaderText="Stuffed On" />
                                    <asp:BoundField DataField="eta" runat="server" HeaderText="Sailed On" />
                                    <asp:BoundField DataField="bldate" runat="server" HeaderText="BL Released On" />
                                    <asp:BoundField DataField="docsent" runat="server" HeaderText="Doc Sent to Agent" />
                                    <asp:BoundField DataField="closedon" runat="server" HeaderText="Closed On" />
                                    <asp:BoundField DataField="noofdays" runat="server" HeaderText="No Of Days" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <%--<RowStyle CssClass="GridviewScrollItem" />--%>
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />

                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4 boxmodal">

                    <div class="panel_17 MB0 hide">
                        <asp:Panel ID="Panel2" runat="server" CssClass="FormGroupContent4" Visible="false">
                            <asp:GridView runat="server" ID="GrdFI" AutoGenerateColumns="False" Width="100%" BorderStyle="None" CssClass=" Grid FixedHeader"
                                OnPageIndexChanging="GrdFI_PageIndexChanging" OnPreRender="GrdFI_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="jobno" runat="server" HeaderText="Job #" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="jobdate" runat="server" HeaderText="Job Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="blno" runat="server" HeaderText="BL #" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="" runat="server" HeaderText="Doc.Recd From-Agent" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="s2carr" runat="server" HeaderText="Doc.Sent to Carrier" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="d1" runat="server" HeaderText="Days" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="eta" runat="server" HeaderText="Arrived on" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="candate" runat="server" HeaderText="CAN & FI Sent on" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="d2" runat="server" HeaderText="Days" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="doissuedon" runat="server" HeaderText="DO-Issuedon" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="" runat="server" HeaderText="DO Sent to Agent" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="invdate" runat="server" HeaderText="Inv.Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="PAdate" runat="server" HeaderText="PA.Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="jobclosedate" runat="server" HeaderText="Job Close Date" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="d3" runat="server" HeaderText="Days" HeaderStyle-Wrap="false" />
                                </Columns>
                                <%--<EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <HeaderStyle CssClass="GridviewScrollHeader" /> 
        <RowStyle CssClass="GridviewScrollItem" /> 
        <PagerStyle CssClass="GridviewScrollPager" />--%>
                                <%--<AlternatingRowStyle CssClass="GrdAltRow"/>--%>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <%--<RowStyle CssClass="GridviewScrollItem" />--%>
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                        </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Event Tracking - Operations #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                    BackColor="White">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="myGridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>

    </asp:Panel>

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <cc1:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </cc1:ModalPopupExtender>

</asp:Content>
