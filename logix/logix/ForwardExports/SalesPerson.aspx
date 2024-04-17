<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="SalesPerson.aspx.cs" Inherits="logix.ForwardExports.SalesPerson" %>

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

    <link href="../Styles/SalesVisitAdvise.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
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

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
        .widget.box{
    position: relative;
    top: -8px;
}
    .gridpnl {
    height: calc(100vh - 170px);
}
    div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 50px !important;
}
    .FromCal {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    .ToCall {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:label id="lbl_header" runat="server" text="Sales Person"></asp:label>
                    </h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>

                            <%--  <li><a href="#" title="" runat="server">MIS And Analytics </a> </li>--%>
                            <%--  <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>--%>
                            <li class="current"><a href="#" title="" id="labelheader" runat="server">Sales Person</a> </li>
                        </ul>
                    </div>
                        </div>

                    <div class="FixedButtons">
     <div class="right_btn">
        <div class="btn ico-get">
            <asp:button id="btn_get" runat="server" Text="Get" tooltip="GET" onclick="btn_get_Click" />
        </div>
        <div class="btn ico-unclosed-job">
            <asp:button id="btn_Unclosed" runat="server" Text="Unclosed Job Booking Register" tooltip="Unclosed Job Booking Register" onclick="btn_Unclosed_Click" />
        </div>
        <div class="btn ico-print">
            <asp:button id="btn_print" runat="server" Text="Print" tooltip="Print" onclick="btn_print_Click" />
        </div>
        <div class="btn ico-excel">
            <asp:button id="btnexportexcel" runat="server" Text="Export Excel" tooltip="Export Excel" onclick="btnexportexcel_Click" />
        </div>
        <div class="btn ico-cancel" id="btnCancel1" runat="server">
            <asp:button id="btnCancel" runat="server" Text="Back" tooltip="Back" onclick="btnCancel_Click" />
        </div>

    </div>

                </div>
                <div class="widget-content">
                    
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="VoyageInputN4New fit-content">
                            <asp:label id="Label2" runat="server" text="Product"> </asp:label>
                            <asp:dropdownlist id="ddl_product" autopostback="true" runat="server" width="100%" onselectedindexchanged="ddl_product_SelectedIndexChanged" appenddatabounditems="True" cssclass="chzn-select" tooltip="Product" data-placeholder="Product">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:dropdownlist>
                        </div>

                        <div class="FromCal">
                            <asp:label id="frmdate" runat="server" text="From "></asp:label>
                            <asp:textbox id="txt_from" runat="server" tabindex="1" tooltip=" CHOOSE DATE" onkeypress="return false;" placeholder="Date" cssclass="form-control"></asp:textbox>
                            <ajaxtoolkit:calendarextender id="CalendarExtender_from" runat="server"
                                daysmodetitleformat="dd/MM/yyyy" format="dd/MM/yyyy" targetcontrolid="txt_from"
                                todaysdateformat="dd/MM/yyyy">
    </ajaxtoolkit:calendarextender>
                        </div>

                        <div class="ToCall">
                            <asp:label id="Label1" runat="server" text="To "></asp:label>
                            <asp:textbox id="txt_to" runat="server" tabindex="2" tooltip=" CHOOSE DATE" onkeypress="return false;" placeholder="Date" cssclass="form-control"></asp:textbox>
                            <ajaxtoolkit:calendarextender id="CalendarExtender_to" runat="server"
                                daysmodetitleformat="dd/MM/yyyy" format="dd/MM/yyyy" targetcontrolid="txt_to"
                                todaysdateformat="dd/MM/yyyy">
    </ajaxtoolkit:calendarextender>
                        </div>
                       

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:panel id="pnl" runat="server" cssclass="gridpnl MB0">
            <asp:GridView ID="grd_sales" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" 
        width="100%" OnRowDataBound="grd_sales_RowDataBound" OnPreRender="grd_sales_PreRender">
        <Columns>
            <asp:BoundField DataField="bookingno" HeaderText="Bookingno" />
            <asp:BoundField DataField="date" HeaderText="Date">
                <HeaderStyle Wrap="true"   HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
             <asp:TemplateField HeaderText ="Customer" HeaderStyle-ForeColor="White">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                 <HeaderStyle Wrap="true" Width="100px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
             </asp:TemplateField>
            <%--<asp:BoundField DataField="customer" HeaderText="Customer" />--%>
            <asp:TemplateField HeaderText ="SalesPerson" HeaderStyle-ForeColor="White">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="SalesPerson" runat="server" Text='<%# Bind("SalesPerson") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                 <HeaderStyle Wrap="true" Width="100px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
             </asp:TemplateField>
            <%--<asp:BoundField DataField="SalesPerson" HeaderText="SalesPerson" />--%>
            <asp:BoundField DataField="volume" HeaderText="Volume">
              <HeaderStyle Wrap="true"   HorizontalAlign="Center"  />
             <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText ="PoL" HeaderStyle-ForeColor="White">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                 <HeaderStyle Wrap="true" Width="80px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
             </asp:TemplateField>
            <%--<asp:BoundField DataField="pol" HeaderText="PoL" />--%>
            <asp:TemplateField HeaderText ="PoD" HeaderStyle-ForeColor="White">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="pod" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                 <HeaderStyle Wrap="false"   HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
             </asp:TemplateField>
            <%--<asp:BoundField DataField="pod" HeaderText="PoD" />--%>
            <asp:BoundField DataField="samt" HeaderText="Income" 
                DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bamt" HeaderText="Expenses" 
                DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="ret" HeaderText="Retention" 
                DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="business" HeaderText="Business">
                 <HeaderStyle Wrap="true"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
        </Columns>
   <%--     <EmptyDataRowStyle CssClass="EmptyRowStyle" />--%>
            <%-- <HeaderStyle CssClass="GridHeader" />--%>
            <%--<AlternatingRowStyle CssClass="GrdRowStyle" />--%>
               
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass=""/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
           <PagerStyle CssClass="GridviewScrollPager" />   
             <RowStyle CssClass="GrdRow" />
    </asp:GridView>
              </asp:panel>

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

