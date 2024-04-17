<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FIFinalNotice.aspx.cs" Inherits="logix.FI.FIFinalNotice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <%--  <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>--%>
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    <script type="text/javascript">

        function download(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

   

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

    <link href="../Styles/FIFinalNotice.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });

            <%--  $(document).ready(function () {
                $('#<%=grd_job.ClientID%>').gridviewScroll({
                    width: 845,
                    height: 550,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }
    </script>
    <style type="text/css">
      
        select#logix_CPH_ddl_hblno {
    height: 36px;
}
        .div_Grd1 {
    margin-top: 12%;
}
        span#logix_CPH_lbl_hdr {
    font-size: 12px;
    color: maroon;
    background: none;
}
              .gridpnl {
    height: calc(100vh - 72px);
}
              div#logix_CPH_ddl_hblno_chzn {
    width: 100% !important;
}
              div#logix_CPH_div_iframe .widget-content {
    top: 0px !important;
    padding-top:15px !important;
}
              table#logix_CPH_grd_job th:nth-child(1) {
    width: 50px;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_hdr1" runat="server" Text="Final Notice"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="">Customer Support</a> </li>
                            <li><a href="#" title="">Ocean Imports</a> </li>
                            <li class="current"><a href="#" title="">Final Notice</a> </li>
                        </ul>
                    </div>
                        </div>


                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="gridpnl">
                            <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" AllowPaging="false" EmptyDataText="No Record Found"
                                PageSize="16" BackColor="White" OnPageIndexChanging="grd_job_PageIndexChanging" OnRowDataBound="grd_job_RowDataBound"
                                OnSelectedIndexChanged="grd_job_SelectedIndexChanged" CssClass="Grid FixedHeader">
                                <Columns>

                                    <asp:TemplateField HeaderText="Job">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="52px"  HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Vessel">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 350px">
                                                <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Agent">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 450px">
                                                <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="MLO">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 350px">
                                                <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ETA">
                                        <ItemTemplate>
                                            <div>
                                                <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ETB">
                                        <ItemTemplate>
                                            <div>
                                                <asp:Label ID="ETB" runat="server" Text='<%# Bind("etb") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="POL">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="candate">
                                        <ItemTemplate>
                                            <div >
                                                <asp:Label ID="candate" runat="server" Text='<%# Bind("candate") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <%--<HeaderStyle Wrap="true" width="71px" HorizontalAlign="Center"  />--%>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Arrow" CommandName="select"
                                        Font-Underline="false">⇛</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>--%>
                                </Columns>
                                <%-- <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
                <RowStyle CssClass="GridviewScrollItem" /> 
                <PagerStyle CssClass="GridviewScrollPager" />
                <AlternatingRowStyle CssClass="GrdAltRow"/>--%>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>

                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <div class="">
                            <asp:HiddenField ID="hf_grdjob_index" runat="server" />
                            <asp:HiddenField ID="hf_jobno" runat="server" />
                        </div>
                        <%-- POPUP --%>
                        <asp:Panel ID="pnl_rnotice" runat="server" Width="100%" Style="display: none" CssClass="modalPopup">
                       

                            <div class="divRoated">
                                 <div class="DivSecPanel">
                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
                                <div class="">
                                    <div class="Header1">
                                        <asp:Label ID="lbl_hdr" runat="server" Text="Final Notice" CssClass="lbl_Header"></asp:Label>
                                    </div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_vslvoy"><asp:Label ID="lbl_vslvoy" runat="server" Text="Vessel&Voy"  CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_vslvoy">
                                        <span>Vessel & Voy</span>
                                        <asp:TextBox ID="txt_vslvoy" runat="server" ToolTip="Vessel&Voy" placeholder="Vessel&Voy" CssClass="Text"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_eta"><asp:Label ID="lbl_eta" runat="server" Text="ETA" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_eta">
                                        <span>ETA</span>
                                        <asp:TextBox ID="txt_eta" runat="server" CssClass="Text" ToolTip="ETA" placeholder="ETA"></asp:TextBox>
                                    </div>
                                    <%--<div class="div_lbl_etb"><asp:Label ID="lbl_etb" runat="server" Text="ETB" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_etb">
                                        <span>ETB</span>

                                        <asp:TextBox ID="txt_etb" runat="server" CssClass="Text" ToolTip="ETB" placeholder="ETB"></asp:TextBox>
                                    </div>
                                    <div class="div_ddl_hblno TextArea">
                                        <span>HBL #</span>
                                        <asp:DropDownList ID="ddl_hblno" ToolTip="HBL Number" runat="server" data-placeholder="HBL#" CssClass="chzn-select">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_agent"><asp:Label ID="lbl_agent" runat="server" Text="Agent" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_agent">
                                        <span>Agent</span>
                                        <asp:TextBox ID="txt_agent" runat="server" CssClass="Text" ToolTip="Agent" placeholder="Agent"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_line"><asp:Label ID="lbl_line" runat="server" Text="Line" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_line">
                                        <span>Line</span>
                                        <asp:TextBox ID="txt_line" runat="server" CssClass="Text" ToolTip="Line" placeholder="Line"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_hblno"><asp:Label ID="lbl_hblno" runat="server" Text="HBL#" CssClass="LabelValue"></asp:Label></div>--%>

                                    <div class="div_Break"></div>
                                    <div class="right_btn">
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" Width="100%" OnClick="btn_cancel_Click" />
                                        </div>
                                        <div class="btn ico-print">
                                            <asp:Button ID="btn_print" runat="server" Text="Print" ToolTip="Print" Width="100%" OnClick="btn_print_Click" />
                                        </div>
                                    </div>

                                    <div class="div_Break"></div>
                                </div>
                            </div>

                        </asp:Panel>

                        <asp:ModalPopupExtender ID="Mdl_rnotice" runat="server" CancelControlID="btn_cancel" TargetControlID="Label1" BackgroundCssClass="" PopupControlID="pnl_rnotice">
                        </asp:ModalPopupExtender>
                        <asp:HiddenField ID="hf_mdl" runat="server" />
                        <%-- </div>  --%>
                        <asp:Label ID="Label1" runat="server"></asp:Label>

                        <div class="div_Break"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--   <div class="div_total">
        <div class="Header2"></div>
        <div class="div_Break"></div>
        <div class="div_Grd1">
        </div>
        <div class="div_Break"></div>
    </div>--%>
     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
</asp:Content>
