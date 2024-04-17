<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="SalesPerson.aspx.cs" Inherits="logix.Sales.SalesPerson" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />

    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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

    <link href="../Styles/SalesVisitAdvise.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/TextField.js"></script>
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".dropdown img.flag").addClass("flag visibility");

            $(".dropdown dt a").click(function () {
                $(".dropdown dd ul").toggle();
            });

            $(".dropdown dd ul li a").click(function () {
                var text = $(this).html();
                $(".dropdown dt a span").html(text);
                $(".dropdown dd ul").hide();
                $("#result").html("Selected value is: " + getSelectedValue("sample"));
            });

            function getSelectedValue(id) {
                return $("#" + id).find("dt a span.value").html();
            }

            $(document).bind('click', function (e) {
                var $clicked = $(e.target);
                if (!$clicked.parents().hasClass("dropdown"))
                    $(".dropdown dd ul").hide();
            });

            $("#flagSwitcher").click(function () {
                $(".dropdown img.flag").toggleClass("flagvisibility");
            });

            <%-- $(document).ready(function () {
                $('#<%=grd_sales.ClientID%>').gridviewScroll({
                    width: 990,
                    height: 340,
                    arrowsize: 30,
                    
                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }

    </script>

    <style type="text/css">
        .FromLabel1 {
            float: left;
            font-size: 11px;
            margin: 3px 0.5% 0 0;
            width: 2%;
        }

        .ToLabel1 {
            float: left;
            font-size: 11px;
            margin: 3px 0.5% 0 0;
            width: 1%;
        }

        .VoyageInputN4New {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BranchDropN1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 13%;
        }

        .checkbox {
            float: right;
            margin-right: 10px;
            padding-top: 5px;
            vertical-align: text-bottom;
        }

        .div_gridn1 {
            width: 100%;
            max-height: 430px;
            float: left;
            margin-bottom: 0%;
            margin-left: 0%;
            margin-top: 1%;
            margin-right: 0%;
            overflow: auto;
        }

        .div_gridn2 {
            width: 100%;
            max-height: 432px;
            float: left;
            margin-bottom: 0%;
            margin-left: 0%;
            margin-top: 1%;
            margin-right: 0%;
            overflow: auto;
        }

    

        .radio input[type="radio"], .radio-inline input[type="radio"], .checkbox input[type="checkbox"], .checkbox-inline input[type="checkbox"] {
            float: right;
            margin-left: 7px;
            margin-top: 2px;
        }
    </style>

    <style type="text/css">
        .row {
            height: 570px !important;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .MT23 {
            margin: 23px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #4d4d4d;
            font-size: 11px;
        }

        .FormGroupContent4 label {
            color: #4d4d4d;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .checkbox {
            float: right;
            margin-right: 10px;
            padding-top: 18px;
            vertical-align: text-bottom;
        }
 
        .FromCal {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .ToCall {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 55px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Sales Person"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>

                            <%--  <li><a href="#" title="" runat="server">MIS And Analytics </a> </li>--%>
                            <%--  <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>--%>
                            <li class="current"><a href="#" title="" id="labelheader" runat="server">Sales Person</a> </li>
                        </ul>
                    </div>
                    <!-- /Breadcrumbs line -->

                        </div>


                                       <div class="FixedButtons">
                        <div class="right_btn">
    <div class="btn ico-get">
        <asp:Button ID="btn_get" runat="server" Text="Get" ToolTip="GET" OnClick="btn_get_Click" />
    </div>
    <div class="btn ico-unclosed-job" id="Divbtnunclose" runat="server" visible="true">
        <asp:Button ID="btn_Unclosed" runat="server" Text="Open Job Booking Register" ToolTip="Open Job Booking Register" OnClick="btn_Unclosed_Click" />
    </div>
    <div class="btn ico-print hide">
        <asp:Button ID="btn_print" runat="server" Text="Print" ToolTip="Print" OnClick="btn_print_Click" />
    </div>
    <div class="btn ico-excel">
        <asp:Button ID="btnexportexcel" runat="server" Text="Export To Excel" ToolTip="Export To Excel" OnClick="btnexportexcel_Click" />
    </div>
    <div class="btn ico-cancel" id="btnCancel1" runat="server">
        <asp:Button ID="btnCancel" runat="server" Text="Back" ToolTip="Back" OnClick="btnCancel_Click" />
    </div>

</div>
                   </div>


                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">

                        <div class="BranchDropN1">
                            <asp:Label ID="Label2" runat="server" Text="Branch"> </asp:Label>
                            <asp:DropDownList ID="ddl_branch" runat="server" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged"
                                data-placeholder="Branch" ToolTip="Branch">
                            </asp:DropDownList>
                        </div>

                        <div class="VoyageInputN4New">
                            <asp:Label ID="Label3" runat="server" Text="Product"> </asp:Label>
                            <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged"
                                AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                        </div>

                        <div class="FromCal">
                            <asp:TextBox ID="txt_from" runat="server" TabIndex="1" ToolTip=" CHOOSE DATE" onkeypress="return false;" PlaceHolder="Date" CssClass="form-control"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender_from" runat="server"
                                DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_from"
                                TodaysDateFormat="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                            <asp:Label ID="frmdate" runat="server" Text="From "></asp:Label>
                        </div>

                        <div class="ToCall">
                            <asp:TextBox ID="txt_to" runat="server" TabIndex="2" ToolTip=" CHOOSE DATE" onkeypress="return false;" PlaceHolder="Date" CssClass="form-control"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender_to" runat="server"
                                DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_to"
                                TodaysDateFormat="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                            <asp:Label ID="Label1" runat="server" Text="To "></asp:Label>
                        </div>
                       
                        <div class="checkbox" style="display: none">
                            <span class="chktext">With Cost</span>

                            <asp:CheckBox ID="chkwithamount" runat="server" AutoPostBack="true" OnCheckedChanged="chkwithamount_CheckedChanged" />

                        </div>

                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div id="panelWithamount" runat="server" class="" visible="false">
                            <asp:Panel ID="Pannel1" CssClass="gridpnl" runat="server">
                                <asp:GridView ID="grd_sales" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" Width="100%"
                                    OnRowDataBound="grd_sales_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="65px" Height="23px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="65px" Height="23px"></ItemStyle>
                                        </asp:TemplateField>
                                        <%--       <asp:BoundField DataField="BranchShort" HeaderText="Branch">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="quotno" HeaderText="Quotation #" />
                                        <asp:BoundField DataField="quotdate" HeaderText="Quotation Date">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bookingno" HeaderText="Booking #" />
                                        <asp:BoundField DataField="date" HeaderText="Booking Date">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Customer" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                                    <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cont20" HeaderText="20'">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cont40" HeaderText="40'">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cbm" HeaderText="M3">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="PoL" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                    <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="pol" HeaderText="PoL" />--%>
                                        <asp:TemplateField HeaderText="PoD" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                    <asp:Label ID="pod" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="1%" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="eta" HeaderText="ETA / Flight Date">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="etd" HeaderText="ETD / Flight Date">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vessel" HeaderText="Vessel">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="blno" HeaderText="BL #" />
                                        <asp:BoundField DataField="cuspono" HeaderText="Customer Ref #" />
                                        <%--<asp:BoundField DataField="customer" HeaderText="Customer" />--%>
                                        <asp:TemplateField HeaderText="SalesPerson" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 175px">
                                                    <asp:Label ID="SalesPerson" runat="server" Text='<%# Bind("SalesPerson") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="SalesPerson" HeaderText="SalesPerson" />--%>
                                        <%-- <asp:BoundField DataField="volume" HeaderText="Volume">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>--%>

                                        <%--<asp:BoundField DataField="pod" HeaderText="PoD" />--%>
                                        <asp:BoundField DataField="samt" HeaderText="Billing"
                                            DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bamt" HeaderText="Cost"
                                            DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ret" HeaderText="Revenue"
                                            DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="business" HeaderText="Controlled By">
                                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                    <RowStyle CssClass="GrdRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>

                        <div id="panelWithOutamount" runat="server" class="" visible="false">
                            <asp:Panel ID="Pannel2" runat="server" CssClass="gridpnl MB0"  >
                                <asp:GridView ID="GrdWithoutamount" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" Width="100%"
                                    OnRowDataBound="GrdWithoutamount_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="65px" Height="23px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="65px" Height="23px"></ItemStyle>
                                        </asp:TemplateField>
                                        <%-- 0 --%>
                                        <asp:BoundField DataField="BranchShort" HeaderText="Branch">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 1 --%>
                                        <asp:BoundField DataField="bookno" HeaderText="Booking #">
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundField>
                                        <%-- 2 --%>
                                        <asp:BoundField DataField="bookdate" HeaderText="Date">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 3 --%>
                                        <asp:BoundField DataField="Sissono" HeaderText="SO #"  ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 4 --%>
                                        <asp:BoundField DataField="Sisdate" HeaderText="Date" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 5 --%>
                                        <asp:BoundField DataField="Quotno" HeaderText="Quot #">
                                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 6 --%>
                                        <asp:BoundField DataField="quotdate" HeaderText="Date">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 7 --%>
                                        <asp:BoundField DataField="Customer" HeaderText="Customer">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 8 --%>
                                        <asp:BoundField DataField="volume" HeaderText="Volume">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 9 --%>
                                        <asp:BoundField DataField="POL" HeaderText="POL">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 10 --%>
                                        <asp:BoundField DataField="POD" HeaderText="POD">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 11 --%>
                                        <asp:BoundField DataField="Shipper" HeaderText="Shipper">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 12 --%>
                                        <asp:BoundField DataField="Consignee" HeaderText="Consignee">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 13 --%>
                                        <asp:BoundField DataField="agent" HeaderText="Agent">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 14 --%>
                                        <asp:BoundField DataField="Jobno" HeaderText="Job #">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 15 --%>
                                        <asp:BoundField DataField="JobDate" HeaderText="Date">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%--  yuvaraj --%>
                                        <asp:BoundField DataField="AMSDate" HeaderText="AMSDate" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" >
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>

                                        <%-- 16 --%>
                                        <asp:BoundField DataField="ETD" HeaderText="ETD" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 17 --%>
                                        <asp:BoundField DataField="ETA" HeaderText="ETA" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <%-- 18 --%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                    <RowStyle CssClass="GrdRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<%--  <div class="Header"><asp:Label ID="Label2" runat="server" Text="Daily Sales Report" CssClass="lbl_Header"></asp:Label></div>--%>

<%--<div class="div_buttonExport">--%>
<%--<div runat="server" id="signup" Visible="false" style="width:15%; margin-left:83%; margin-right:1%; ">
              <dl id="sample" class="dropdown" style=" margin-top :0%;">
        <dt><a href="#"><span>Export To </span></a></dt>
        <dd>
         <ul>
           <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="Excelfunforserver_Click">Excel</asp:LinkButton></li>
           <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="pdffunforserver_Click">PDF</asp:LinkButton></li>
                       </ul>
        </dd>
    </dl></div>--%>
<%--<div style="width:25%;border:1px solid green; float:left;">
             <asp:Button ID="btnprint" runat="server" Text="Print"  CssClass="Button"/></div>
            
        </div>--%>

