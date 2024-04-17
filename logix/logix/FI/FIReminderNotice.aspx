<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FIReminderNotice.aspx.cs" Inherits="logix.FI.FIReminderNotice" %>

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

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    <script type="text/javascript">

        function dropdown(sender, args) {
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

    <link href="../Styles/FIReminderNotice.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });

            <%--$(document).ready(function () {
                $('#<%=grd_job.ClientID%>').gridviewScroll({
                    width: 1020,
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
    <style>
        .div_ddl_hblno select {
    width: 100%;
    height: 35px;
}
        .div_Grd1 {
    margin-top: 10%;
}
        span#logix_CPH_lbl_hdr {
    font-size: 12px;
    color: maroon;
    background: none;
}
        .gridpnl {
    height: calc(100vh - 72px);
}
        
element.style {
    width: 100px;
}
div#logix_CPH_ddl_hblno_chzn {
    width: 100% !important;
}


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 15px !important;
}
table#logix_CPH_grd_job th:nth-child(1) {
    width: 3%;
}
table#logix_CPH_grd_job th:nth-child(5) {
    width: 5%;
}

table#logix_CPH_grd_job th:nth-child(6) {
    width: 5%;
}
table#logix_CPH_grd_job th:nth-child(8) {
    width: 6%;

}
table#logix_CPH_grd_job th:nth-child(2) {
    width: 6%;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_hdr1" runat="server" Text="Reminder Notice"></asp:Label>
                    </h4>
                         <!-- Breadcrumbs line -->   
                     <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Customer Support</a> </li>
            <li><a href="#" title="">Ocean Imports</a> </li>
            <li class="current"><a href="#" title="">Reminder Notice</a> </li>
        </ul>
    </div>
                        </div>


                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="gridpnl">
                        <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" CssClass="Grid FixedHeader" 
                            PageSize="16" BackColor="White" AllowPaging="false" OnSelectedIndexChanged="grd_job_SelectedIndexChanged" OnPageIndexChanging="grd_job_PageIndexChanging" OnRowDataBound="grd_job_RowDataBound">
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
                                        <div >
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
                                        <div>
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
                            <%--  <EmptyDataRowStyle CssClass="EmptyRowStyle" />
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
                        <%-- POPUP --%>
                        <asp:Panel ID="pnl_rnotice" runat="server" Width="100%" Style="display: none" CssClass="modalPopup">
                            <%--<div class="div_close"><asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" width="100%" Height="100%" ImageUrl="~/images/close2.png"/></div>--%>
                          

                            <div class="divRoated">
                                 <div class="DivSecPanel">
                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
                                <div class="">
                                    <div class="Header1">
                                        <asp:Label ID="lbl_hdr" runat="server" Text="Reminder Notice" CssClass="lbl_Header"></asp:Label>
                                    </div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_vslvoy"><asp:Label ID="lbl_vslvoy" runat="server" Text="Vessel&Voy" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_vslvoy">
                                        <span>Vessel & Voy</span>
                                        <asp:TextBox ID="txt_vslvoy" runat="server" placeholder="Vessel&Voy" ToolTip="Vessel&Voy" CssClass="Text"></asp:TextBox></div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_eta"><asp:Label ID="lbl_eta" runat="server" Text="ETA" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_eta">
                                        <span>ETA</span>
                                        <asp:TextBox ID="txt_eta" runat="server" placeholder="ETA" ToolTip="ETA" CssClass="Text"></asp:TextBox></div>
                                    <%--<div class="div_lbl_etb"><asp:Label ID="lbl_etb" runat="server" Text="ETB" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_etb">
                                        <span>ETB</span>
                                        <asp:TextBox ID="txt_etb" runat="server" ToolTip="ETB" placeholder="ETB" CssClass="Text"></asp:TextBox></div>
                                    <div class="div_ddl_hblno TextArea" >
                                        <span>HBL #</span>
                                        <asp:DropDownList ID="ddl_hblno" runat="server" ToolTip="HBL#" Data-placeholder="HBL NUMBER" CssClass="chzn-select">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_agent"><asp:Label ID="lbl_agent" runat="server" Text="Agent" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_agent">
                                        <span>Agent</span>
                                        <asp:TextBox ID="txt_agent" runat="server" ToolTip="Agent" placeholder="Agent" CssClass="Text"></asp:TextBox></div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_line"><asp:Label ID="lbl_line" runat="server" Text="Line" CssClass="LabelValue"></asp:Label></div>--%>
                                    <div class="div_txt_line">
                                        <span>Line</span>
                                        <asp:TextBox ID="txt_line" runat="server" ToolTip="Line" placeholder="Line" CssClass="Text"></asp:TextBox></div>
                                    <div class="div_Break"></div>
                                    <%--<div class="div_lbl_hblno"><asp:Label ID="lbl_hblno" runat="server" Text="HBL#" CssClass="LabelValue"></asp:Label></div>--%>

                                    <div class="div_Break"></div>
                                    <div class="right_btn">
                                        <div class="btn ico-to-forwarder">
                                            <asp:Button ID="btn_forwarder" runat="server" Text="Forwarder" ToolTip="Forwarder" OnClick="btn_forwarder_Click" /></div>
                                        <div class="btn ico-view">
                                            <asp:Button ID="btn_cnsg" runat="server" Text="Consignee" ToolTip="Consignee" OnClick="btn_cnsg_Click" />
                                        </div>
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                                        </div>
                                    </div>
                             
                                </div>
                            </div>

                        </asp:Panel>

                        <asp:ModalPopupExtender ID="Mdl_rnotice" runat="server" CancelControlID="btn_cancel" TargetControlID="Label1" BackgroundCssClass=""
                            PopupControlID="pnl_rnotice">
                        </asp:ModalPopupExtender>

                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <asp:HiddenField ID="hf_mdl" runat="server" />
                        <asp:HiddenField ID="hf_grdjob_index" runat="server" />
                        <asp:HiddenField ID="hf_jobno" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- <div class="div_total">       
     
      <div class="Header1">  <asp:Label ID="lbl_hdr" runat="server" Text="Reminder Notice" CssClass="lbl_Header"></asp:Label> </div> 
      <div class="div_Break"></div>
      <div class="div_lbl_vslvoy"><asp:Label ID="lbl_vslvoy" runat="server" Text="Vessel&Voy" CssClass="LabelValue"></asp:Label></div>
      <div class="div_txt_vslvoy"><asp:TextBox ID="txt_vslvoy" runat="server" CssClass="Text"></asp:TextBox></div>
      <div class="div_Break"></div>
      <div class="div_lbl_eta"><asp:Label ID="lbl_eta" runat="server" Text="ETA" CssClass="LabelValue"></asp:Label></div>
      <div class="div_txt_eta"><asp:TextBox ID="txt_eta" runat="server" CssClass="Text"></asp:TextBox></div>
      <div class="div_lbl_etb"><asp:Label ID="lbl_etb" runat="server" Text="ETB" CssClass="LabelValue"></asp:Label></div>
      <div class="div_txt_etb"><asp:TextBox ID="txt_etb" runat="server" CssClass="Text"></asp:TextBox></div>
      <div class="div_Break"></div>
      <div class="div_lbl_agent"><asp:Label ID="lbl_agent" runat="server" Text="Agent" CssClass="LabelValue"></asp:Label></div>
      <div class="div_txt_agent"><asp:TextBox ID="txt_agent" runat="server" CssClass="Text"></asp:TextBox></div>
      <div class="div_Break"></div>
      <div class="div_lbl_line"><asp:Label ID="lbl_line" runat="server" Text="Line" CssClass="LabelValue"></asp:Label></div>
      <div class="div_txt_line"><asp:TextBox ID="txt_line" runat="server" CssClass="Text"></asp:TextBox></div>
      <div class="div_Break"></div>
      <div class="div_lbl_hblno"><asp:Label ID="lbl_hblno" runat="server" Text="HBL#" CssClass="LabelValue"></asp:Label></div>
      <div class="div_ddl_hblno"><asp:DropDownList ID="ddl_hblno" runat="server" CssClass="Text"></asp:DropDownList></div>
      <div class="div_Break"></div>
       <div class="div_btn">
       <asp:Button ID="btn_forwarder" runat="server" Text="Forwarder" CssClass="btn" OnClick="btn_forwarder_Click" />
       <asp:Button ID="btn_cnsg" runat="server" Text="Consignee" CssClass="btn" OnClick="btn_cnsg_Click" />
       <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btn_cancel_Click" />
      </div>
           <div class="div_Break"></div>
     </div>
    <div class="div_popup_RNotice">
        <asp:Panel ID="pnl_rnotice" runat="server" BackColor="White" Width="100%" Height="80%"
            Style="display: none;">
            <asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif"
                CssClass="div_closevoucher_Rnotice" />
            <div class="div_Break">
            </div>
            <div class="div_grd_job">
                <asp:GridView ID="grd_job" runat="server" CssClass="Grid FixedHeader"  Width="100%" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grd_job_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job#" />
                        <asp:BoundField DataField="vslvoy" HeaderText="Vessel" />
                        <asp:BoundField DataField="agent" HeaderText="Agent" />
                        <asp:BoundField DataField="mlo" HeaderText="MLO" />
                        <asp:BoundField DataField="eta" HeaderText="ETA" />
                        <asp:BoundField DataField="etb" HeaderText="ETB" />
                        <asp:BoundField DataField="pol" HeaderText="POL" />
                        <asp:BoundField DataField="candate" HeaderText="candate" />
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Arrow" CommandName="select"
                                    Font-Underline="false">⇛</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                </asp:GridView>
            </div>
            <div class="div_Break">
            </div>
        </asp:Panel>
    </div>
    <div class="div_Break">
    </div>
    <asp:ModalPopupExtender ID="Mdl_rnotice" runat="server" TargetControlID="Label1"
        BackgroundCssClass="modalBackground_job" PopupControlID="pnl_rnotice">
    </asp:ModalPopupExtender>
     <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:HiddenField ID="hf_mdl" runat="server" />
    <asp:HiddenField ID="hf_grdjob_index" runat="server" />
    <asp:HiddenField ID="hf_jobno" runat="server" />--%>
    <div class="div_total hide">
        <div class="Header2"></div>
        <div class="div_Break"></div>
        <div class="div_Grd">

            <div class="div_Break"></div>
        </div>
        <div class="div_Break"></div>
        <br />
        <div class="div_Break"></div>
    </div>

    <div class="div_Break"></div>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
</asp:Content>
