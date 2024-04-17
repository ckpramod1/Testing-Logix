<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FIDeliveryStatus.aspx.cs" Inherits="logix.FI.FIDeliveryStatus" %>
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

      <link href="../Styles/FIDeliveryStatus.css" rel="Stylesheet" type="text/css" />
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
    <style type="text/css">
       
        .GridJob {
            float:left; width:100%; height:475px; overflow:auto; border:1px solid #b1b1b1;
        }
        select#logix_CPH_ddl_hblno {
    height: 36px;
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
        div#logix_CPH_div_iframe .widget-content {
    top: 0px !important;
    padding-top:15px !important;
}
        table#logix_CPH_grd_job th:nth-child(1) {
    width: 20px;
}

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
     
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
     <div class="widget-header">
         <div>
                  <h4 class="hide"><i class="icon-umbrella"></i> <asp:Label ID="lbl_hdr1" runat="server" Text="Delivery Status" ></asp:Label> </h4>
         <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Customer Support</a> </li>
               <li><a href="#" title="">Ocean Imports</a> </li>
              <li class="current"><a href="#" title="">Delivery Status</a> </li>
            </ul>
      </div>
             </div>
                </div>
          <div class="widget-content">
              <div class="FormGroupContent4">
                  <div class="gridpnl">
                  <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" CssClass="Grid FixedHeader" 
            PageSize="15" BackColor="White" OnPageIndexChanging="grd_job_PageIndexChanging" OnRowDataBound="grd_job_RowDataBound"
             onselectedindexchanged="grd_job_SelectedIndexChanged" >
            <Columns>

                <asp:TemplateField HeaderText ="Job">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:40px">
                       <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <%--<HeaderStyle Wrap="true" width="52px"  HorizontalAlign="Center"  />--%>
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                                      
               <asp:TemplateField HeaderText ="Vessel">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:350px">
                       <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                                       
               <asp:TemplateField HeaderText ="Agent">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:450px">
                       <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <%--<HeaderStyle Wrap="true" width="132px"  HorizontalAlign="Center"  />--%>
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                                       
               <asp:TemplateField HeaderText ="MLO">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:350px">
                       <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText ="ETA">
                <ItemTemplate>   
                    <div>
                       <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

            <asp:TemplateField HeaderText ="ETB">
                <ItemTemplate>   
                    <div>
                       <asp:Label ID="ETB" runat="server" Text='<%# Bind("etb") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <%--<HeaderStyle Wrap="true" width="71px"  HorizontalAlign="Center"  />--%>
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

            <asp:TemplateField HeaderText ="POL">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <%--<HeaderStyle Wrap="true" width="132px" HorizontalAlign="Center"  />--%>
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText ="candate">
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
              </div>
         </div>
            </div>
           </div>

 <%--   <div class="div_total">
         <div class="Header2">   </div>      
         <div class="div_Break"></div>
     <div class="div_Grd"> 
        
    </div>
    <div class="div_Break">
    </div>
   </div>--%>
    <div class="">
        <asp:HiddenField ID="hf_grdjob_index" runat="server" />
        <asp:HiddenField ID="hf_jobno" runat="server" />
        <asp:HiddenField ID="hf_fiagentid" runat="server" />
        <asp:HiddenField ID="hf_sendqry" runat="server" />
        <asp:HiddenField ID="hf_shipper" runat="server" />
        <asp:HiddenField ID="hf_consignee" runat="server" />
        <asp:HiddenField ID="hf_pod" runat="server" />
        <asp:HiddenField ID="hf_pol" runat="server" />
        <asp:HiddenField ID="hf_mbl" runat="server" />
        <asp:HiddenField ID="hf_sCity" runat="server" />
        <asp:HiddenField ID="hf_ptc" runat="server" />
        <asp:HiddenField ID="hf_shipperadd" runat="server" />
       
    </div>

   <%--   <div class="div_popup_RNotice">
        <asp:Panel ID="pnl_rnotice" runat="server" BackColor="White" Width="100%" Height="80%">
            <asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif"
                CssClass="div_closevoucher_Rnotice" />
            <div class="div_Break">
            </div>
            <div class="Header">  <asp:Label ID="lbl_hdr" runat="server" Text="Delivery Status" CssClass="lbl_Header"></asp:Label> </div>      
            
            <div class="div_Break">
            </div>
            <div class="div_lbl_vslvoy">
                <asp:Label ID="lbl_vslvoy" runat="server" Text="Vessel&Voy" CssClass="LabelValue"></asp:Label></div>
            <div class="div_txt_vslvoy">
                <asp:TextBox ID="txt_vslvoy" runat="server" CssClass="Text"></asp:TextBox></div>
            <div class="div_Break">
            </div>
            <div class="div_lbl_eta">
                <asp:Label ID="lbl_eta" runat="server" Text="ETA" CssClass="LabelValue"></asp:Label></div>
            <div class="div_txt_eta">
                <asp:TextBox ID="txt_eta" runat="server" CssClass="Text"></asp:TextBox></div>
            <div class="div_lbl_etb">
                <asp:Label ID="lbl_etb" runat="server" Text="ETB" CssClass="LabelValue"></asp:Label></div>
            <div class="div_txt_etb">
                <asp:TextBox ID="txt_etb" runat="server" CssClass="Text"></asp:TextBox></div>
            <div class="div_Break">
            </div>
            <div class="div_lbl_agent">
                <asp:Label ID="lbl_agent" runat="server" Text="Agent" CssClass="LabelValue"></asp:Label></div>
            <div class="div_txt_agent">
                <asp:TextBox ID="txt_agent" runat="server" CssClass="Text"></asp:TextBox></div>
            <div class="div_Break">
            </div>
            <div class="div_lbl_line">
                <asp:Label ID="lbl_line" runat="server" Text="Line" CssClass="LabelValue"></asp:Label></div>
            <div class="div_txt_line">
                <asp:TextBox ID="txt_line" runat="server" CssClass="Text"></asp:TextBox></div>
            <div class="div_Break">
            </div>
            <div class="div_lbl_hblno">
                <asp:Label ID="lbl_hblno" runat="server" Text="HBL#" CssClass="LabelValue"></asp:Label></div>
            <div class="div_ddl_hblno">
                <asp:DropDownList ID="ddl_hblno" runat="server">
                </asp:DropDownList>
            </div>
            <div class="div_Break">
            </div>
            <div class="div_btn_send">
                <asp:Button ID="btn_send" runat="server" CssClass="btn" Text="Send" Width="100%"
                    OnClick="btn_send_Click" />
            </div>
            <div class="div_btn_print">
                <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn" Width="100%"
                    OnClick="btn_print_Click" />
            </div>
            <div class="div_btn_cancel">
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn" Width="100%"
                    OnClick="btn_cancel_Click" />
            </div>
            <div class="div_Break">
            </div>
            
        </asp:Panel>
    </div>--%>

      <%-- POPUP --%>
          <asp:Panel ID="pnl_rnotice" runat="server" Width="100%" style="display:none" CssClass="modalPopup">
          <%--<div class="div_close"><asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" width="100%" Height="100%" style="float:left; margin-top:-3%;" ImageUrl="~/images/close2.png"/></div>--%>
          <div class="div_Break"></div>
        
          <div class="divRoated">
                <div class="DivSecPanel">
                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
          <div class=" ">
          <div class="Header1">  <asp:Label ID="lbl_hdr" runat="server" Text="Delivery Status" CssClass="lbl_Header"></asp:Label> </div> 
             <div class="div_Break"></div>
             <div class="div_Break">
            </div>
            <%--<div class="div_lbl_vslvoy"><asp:Label ID="lbl_vslvoy" runat="server" Text="Vessel&Voy" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="div_txt_vslvoy">
                <span>Vessel & Voy</span>
                <asp:TextBox ID="txt_vslvoy" runat="server" ToolTip="Vessel&Voy" placeholder="Vessel&Voy" CssClass="Text"></asp:TextBox></div>
            <div class="div_Break"></div>
            <%--<div class="div_lbl_eta"><asp:Label ID="lbl_eta" runat="server" Text="ETA" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="div_txt_eta">
                <span>ETA</span>
                
                <asp:TextBox ID="txt_eta" runat="server" CssClass="Text" ToolTip="ETA" placeholder="ETA"></asp:TextBox></div>
            <%--<div class="div_lbl_etb"><asp:Label ID="lbl_etb" runat="server" Text="ETB" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="div_txt_etb">
                <span>ETB</span>
                
                <asp:TextBox ID="txt_etb" runat="server" CssClass="Text" ToolTip="ETB" placeholder="ETB"></asp:TextBox></div>
            <div class="div_ddl_hblno TextArea">
                <span>HBL #</span>
                  <asp:DropDownList ID="ddl_hblno" runat="server" CssClass="chzn-select" placeholder="HBL #" ToolTip="HBL #">
                </asp:DropDownList>
            </div>
            <div class="div_Break"></div>
            <%--<div class="div_lbl_agent"><asp:Label ID="lbl_agent" runat="server" Text="Agent" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="div_txt_agent">
                <span>Agent</span>
                
                <asp:TextBox ID="txt_agent" runat="server" CssClass="Text" ToolTip="Agent" placeholder="Agent"></asp:TextBox></div>
            <div class="div_Break"></div>
            <%--<div class="div_lbl_line"><asp:Label ID="lbl_line" runat="server" Text="Line" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="div_txt_line">
                <span>Line</span>
                
                <asp:TextBox ID="txt_line" runat="server" CssClass="Text" ToolTip="Line" placeholder="Line"></asp:TextBox></div>
            <div class="div_Break"></div>
            <%--<div class="div_lbl_hblno"><asp:Label ID="lbl_hblno" runat="server" Text="HBL#" CssClass="LabelValue"></asp:Label></div>--%>
            
            <div class="div_Break"></div>
              <div class="right_btn">
            <div class="btn ico-cancel"><asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="Button" Width="100%" OnClick="btn_cancel_Click" /></div>
            <div class="btn ico-send"><asp:Button ID="btn_send" runat="server" CssClass="Button" Text="Send" Width="100%" OnClick="btn_send_Click" /></div>
            <div class="btn ico-print"><asp:Button ID="btn_print" runat="server" Text="Print" CssClass="Button" Width="100%" OnClick="btn_print_Click" /></div>     
                  </div>       
            
            
           </div>
         </div>

        </asp:Panel>

    <div>
     <asp:ModalPopupExtender ID="Mdl_dstaus" runat="server" CancelControlID="btn_cancel" TargetControlID="Label1" BackgroundCssClass="" PopupControlID="pnl_rnotice">
     </asp:ModalPopupExtender>
     <asp:HiddenField ID="hf_mdl" runat="server" />
         <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    <div class="div_Break">
    </div>
      <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
</asp:Content>
