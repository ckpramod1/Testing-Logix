<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AICSHome.aspx.cs" Inherits="logix.Home.AICSHome" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">

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

    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <style type="text/css">
        #Test_foregroundElement {
            left: 55px !important;
            top: 285px !important;
        }

        #Test1_foregroundElement {
            left: 147px !important;
            top: 3285px !important;
        }

        #Test2_foregroundElement {
            left: 211px !important;
            top: 285px !important;
        }

        #Test3_foregroundElement {
            left: 282px !important;
            top: 285px !important;
        }

        #Test4_foregroundElement {
            left: 525px !important;
            top: 285px !important;
        }

        .row {
            clear: both;
            height: 566px !important;
            margin: 0 5px 0 -15px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        .divbtn1 {
            width: 185px;
            background-color: #ca332d;
            float: left;
            text-align: center;
            margin: 10px 0.5% 0px 0px;
        }

            .divbtn1 a {
                display: inline-block;
                padding: 5px;
                font-size: 11px;
                text-align: center;
                color: #fff !important;
                margin: 0px;
            }

        .divbtn2 {
            width: 185px;
            background-color: #f39129;
            float: left;
            text-align: center;
            margin: 5px 0.5% 0px 0px;
        }

            .divbtn2 a {
                display: inline-block;
                color: #fff !important;
                font-size: 11px;
                text-align: center;
                padding: 5px;
                margin: 0px;
            }

        .divbtn3 {
            width: 185px;
            background-color: #883028;
            text-align: center;
            float: right;
            margin: 15px 0.5% 0px 0px;
        }

            .divbtn3 a {
                display: inline-block;
                color: #ffffff;
                font-size: 11px;
                padding: 5px;
                margin: 0px;
            }

        .divbtn4 {
            width: 185px;
            background-color: #e1e1e1;
            text-align: center;
            float: left;
            margin: 15px 0% 0px 0px;
        }

            .divbtn4 a {
                display: inline-block;
                color: #353535;
                font-size: 11px;
                padding: 5px;
                margin: 0px;
            }

        .BrderVisible {
            height: 429px;
            border: 1px solid #b1b1b1;
        }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 32px;
            padding: 2px 2px 2px 5px;
            width: 100%;
        }

            .BandTop img {
                padding: 2px 4px 0px 5px;
            }

            .BandTop h3 {
                color: #ffffff;
                padding: 2px 5px 2px 5px;
                margin: 0px 0px 0px 0px;
            }

                .BandTop h3 a {
                    color: #ffffff;
                    font-size: 11px;
                    font-family: sans-serif;
                    padding: 2px 5px 2px 0px;
                    margin: 0px 0px 0px 0px;
                }

        .BandLeft {
            float: left;
            width: 35%;
        }

        .BandRight {
            float: right;
            margin: 0px 0px 0px 0px;
        }
                      .BandMiddle {
    background-color: #98AFC7;
    float: left;
    min-height: 25px;
    padding: 2px 2px 2px 5px;
    margin: 0px 0px 0px 0px;
    width: 100%;
}
                .BreadLabel {
    width: 15%;
    color: #ffffff;
    float: left;
    margin: 1px 0.5% 0px 21px;
    font-weight: normal;
    font-size: 11px;
}
                
div#UpdatePanel1 {
    height: 92vh !important;
    overflow-x: hidden;
    overflow-y: auto;
}
.widget.box .widget-content {
    position: relative;
    top: -8px;
}
.widget-content {
    padding: 0 10px!important;
}
    </style>
    <%--TEST--%>

    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
    <noscript>
Your browser does not support JavaScript!
</noscript>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="Clear"></div>
        <div class="BandMiddle">
            <div class="BreadLabel" id="OptionDoc" runat="server">Customer Support - Air Imports</div>

        </div>
        <div class="Clear"></div>
        <div class="BandTop">
            <div style="float:left; width:176px; margin:0px 0.5% 0px 0px;padding: 0 0px 0 10px;">
                <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png"><asp:LinkButton ID="link_button1" runat="server" Text="New CustomerRequest" OnClick="link_button1_Click"></asp:LinkButton></h3>
            </div>
            <div style="float:left; width:100px;">
                <h3>
                    <img src="../Theme/assets/img/costing.png"><asp:LinkButton ID="LinkButton8" runat="server" Text="Costing" OnClick="LinkButton8_Click"></asp:LinkButton>
                    </h3>
                    </div>
            <div class="BandRight">
                <div style="float: left;">
                    <h3>
                        <img src="../Theme/assets/img/job_ic.png">
                        <asp:LinkButton ID="lbl_jobclosing" runat="server" Text="Job Closing" OnClick="lbl_jobclosing_Click"></asp:LinkButton>
                </div>
                <div style="float: left;">
                    <h3>
                        <img src="../Theme/assets/img/customerprofile_ic.png"><asp:LinkButton ID="lbl_customerprofile" runat="server" Text="Customer Profile" OnClick="lbl_customerprofile_Click"></asp:LinkButton></h3>
                </div>
            </div>

        </div>
        <div class="">
            <div class="col-md-12  maindiv">
                <!-- Tabs-->
                <div class="widget box">
                    <%-- <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                    <div class="widget-content">
                        <div style="float: left; width: 84%;">
                            <div class="widget-header">
                                <span>Pending Status</span></div>
                            <%-- <div class="LoginCompanyDrop">
                                <asp:DropDownList data-placeholder="Events" ID="ddlEvents" runat="server" TabIndex="1" CssClass="chzn-select form-control"
                                    AutoPostBack="True" ForeColor="Black" >

                                    <asp:ListItem Text="Stuffing Confirmation" Value="SC"></asp:ListItem>
                                    <asp:ListItem Text="Sailing Confirmation" Value="LC"></asp:ListItem>
                                    <asp:ListItem Text="DO Confirmation" Value="DO"></asp:ListItem>
                                    <asp:ListItem Text="Transhipment Confirmation" Value="TS"></asp:ListItem>
                                    <asp:ListItem Text="DO Confirmation Request" Value="DR"></asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                            <div class="div_Break"></div>

                            <asp:Panel ID="Panel1" runat="server" CssClass="panel_18 MB0" Visible="true">
                                <asp:GridView ID="Grd_Status" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                    EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true"
                                    AllowPaging="false" PageSize="13" OnPageIndexChanging="Grd_Status_PageIndexChanging">
                                    <Columns>

                                        <asp:TemplateField HeaderText="S #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis;width:25px">
                                                    <asp:Label ID="lbl_Slno" runat="server" Text='<%# Bind("Slno") %>' ToolTip='<%# Bind("Slno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="25px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="25px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Booking #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                                    <asp:Label ID="lbl_Booking" runat="server" Text='<%# Bind("Booking") %>' ToolTip='<%# Bind("Booking") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="95px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="95px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                                    <asp:Label ID="lbl_bookingdate" runat="server" Text='<%# Bind("bookingdate") %>' ToolTip='<%# Bind("bookingdate") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="90px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="90px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Job #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                <asp:Label ID="lbl_Job" runat="server" Text='<%# Bind("Job") %>' ToolTip='<%# Bind("Job") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="40px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="40px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="BL #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                    <asp:Label ID="lbl_BL" runat="server" Text='<%# Bind("BL") %>' ToolTip='<%# Bind("BL") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                                    <asp:Label ID="lbl_bldate" runat="server" Text='<%# Bind("bldate") %>' ToolTip='<%# Bind("bldate") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="90px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="90px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis;">
                                                    <asp:Label ID="lbl_Customer" runat="server" Text='<%# Bind("Customer") %>' ToolTip='<%# Bind("Customer") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false"   HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PoR">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                                    <asp:Label ID="lbl_POR" runat="server" Text='<%# Bind("POR") %>' ToolTip='<%# Bind("POR") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PoL">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                                    <asp:Label ID="lbl_POL" runat="server" Text='<%# Bind("POL") %>' ToolTip='<%# Bind("POL") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PoD">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                                    <asp:Label ID="lbl_POD" runat="server" Text='<%# Bind("POD") %>' ToolTip='<%# Bind("POD") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PlD">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                                    <asp:Label ID="lbl_PlD" runat="server" Text='<%# Bind("PlD") %>' ToolTip='<%# Bind("PlD") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                            </asp:Panel>

                        </div>

                        <div class="Unclosed2">
                            <%--<h3><span>Events</span></h3>--%>
                            <asp:Panel ID="PanelPendingEvent" runat="server"  CssClass="Gridpnlex" Visible="true">

                                <asp:GridView ID="Grd_Events" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="true" Width="100%"
                                    ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                            </asp:Panel>
                            <div style="margin-top: 12.7%;">
                                <div class="divbtn1">
                                    <asp:LinkButton ID="Inv_CnOPSCustomerwise" runat="server" OnClick="Inv_CnOPSCustomerwise_Click">Inv_Cn OPS Customerwise</asp:LinkButton>
                                </div>
                                <%-- <div class="divbtn2">
                                <asp:LinkButton ID="lnk_event_track" runat="server" OnClick="lnk_event_track_Click">Event Tracking Job-wise</asp:LinkButton>
                            </div>--%>
                                <div class="divbtn2">
                                    <asp:LinkButton ID="lnk_ship_query" runat="server" OnClick="lnk_ship_query_Click">Shipment Query </asp:LinkButton>
                                </div>
                                <%-- <div class="divbtn4">
                                <asp:LinkButton ID="lnk_vessel_sch" runat="server" OnClick="lnk_vessel_sch_Click">Vessel Schedule</asp:LinkButton>
                            </div>--%>
                            </div>
                        </div>
                        <div class="div_Break"></div>

                    </div>
                </div>

            </div>
            <!--END TABS-->

        </div>
        <div style="display: none;">
            <asp:Label ID="hidbooking" runat="server" />
            <asp:Label ID="hidhbl" runat="server" />
            <asp:Label ID="hidmbl" runat="server" />
            <asp:Label ID="hidunclosed" runat="server" />
            <asp:Label ID="hidapprovalproinvoice" runat="server" />
            <asp:Label ID="hidapprovalCNOp" runat="server" />
            <asp:Label ID="hidapprovalquo" runat="server" />
            <asp:Label ID="hidapprovalInvoices" runat="server" />
            <asp:Label ID="hidapprovalProCNOp" runat="server" />
            <asp:Label ID="hidapprovalProOSdn" runat="server" />
            <asp:Label ID="hidapprovalOSDebit" runat="server" />
            <asp:Label ID="hidapprovalOScrdit" runat="server" />
            <asp:Label ID="hidapprovalProOtherDN" runat="server" />
            <asp:Label ID="hidapprovalProOtherCN" runat="server" />
            <asp:Label ID="hidapprovalOSCredit" runat="server" />
            <asp:Label ID="hidapprovalOtherDebitNotes" runat="server" />
            <asp:Label ID="hidapprovalOtherCreditNotes" runat="server" />
        </div>
    
</asp:Content>
