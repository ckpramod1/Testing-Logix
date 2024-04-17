<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AICAN.aspx.cs" Inherits="logix.AI.AICAN" %>

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

    <link href="../Styles/AICAN.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .divRoated {
            width: 90%;
            height: 75vh;
            overflow: hidden;
            background: #fff;
            border-radius: 3px;
        }

        .DivSecPanel {
            width: 20px;
            height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: 0%;
            border-radius: 90px 90px 90px 90px;
        }

        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.17%;
            margin-top: -1.7%;
            position: absolute;
            width: 1026px;
        }

        #programmaticModalPopupBehaviordf1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .POLNew2 {
            width: 45.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ChkBox {
            width: 3%;
            float: right;
            margin: 17px 0px 0px 0.5%;
        }

        .Flight5 {
            width: 88%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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

        .JobInputN {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }
        /*thead {
  position: relative;
  display: block;
  width: 100%;
  overflow: visible;
}

 tbody {
  position: relative;
  display: block; 
  width: 100%;
  height: 205px;
  overflow: auto;
}*/

        /*th:nth-child(1) {
  min-width: 350px;
}
 td:nth-child(1) { 
  min-width: 350px;
}

 th:nth-child(3) {
  min-width: 415px;
}
 td:nth-child(3) { 
  min-width: 415px;
}

 th:nth-child(4) {
  min-width: 260px;
}
 td:nth-child(4) { 
  min-width: 260px;
}

 th:nth-child(5) {
  min-width: 260px;
}
 td:nth-child(5) { 
  min-width: 260px;
}*/
        .modalPopupss {
            background-color: rgba(0, 0, 0, 0.75);
            width: 100%;
            height: 90%;
            margin-left: 0%;
            margin-top: -1%;
            border: 1px solid #b1b1b1;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .Gridpnl {
            width: 99% !important;
            height: 91%;
            border: 1px solid #b1b1b1;
            margin: 0 auto !important;
            overflow-y: scroll;
            overflow-x: auto;
        }

        .TextField input ~ span, .TextField textarea ~ span {
            position: relative;
            left: 0;
        }
        .Consigneerad {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
   
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}
        .FlightCal {
    width: 7%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.POLNewCal {
    width: 7%;
    float: left;
    margin: 0px 0px 0px 0px;
}
div#UpdatePanel1 {
    /* height: 100vh; */
    height: 87vh;
    overflow-x: hidden;
    overflow-y: auto;
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
                        <asp:Label ID="lblheader" runat="server" Text="AICAN"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="">Customer Support</a> </li>
                            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>
                            <li class="current"><a href="#" title="" id="Headerlable" runat="server">AICAN</a> </li>
                        </ul>
                    </div>
                        </div>


                     <div class="FixedButtons" >
       <div class="right_btn">

         <div class="btn ico-send">
             <asp:Button ID="btn_send" runat="server" Text="Send" ToolTip="Send" Enabled="false" TabIndex="10" OnClick="btn_send_Click" />
         </div>
         <div class="btn ico-print">
             <asp:Button ID="btn_print" runat="server" Text="Print" ToolTip="Print" OnClick="btn_print_Click" TabIndex="2" />
         </div>

         <div class="btn ico-can-proforma">
             <asp:Button ID="btn_canprfrma" runat="server" Text="CAN Proforma" ToolTip="CAN Proforma" TabIndex="3" OnClick="btn_canprfrma_Click" />
         </div>
         <div class="btn ico-cancel" id="btn_back2" runat="server">
             <asp:Button ID="btn_back" runat="server" ToolTip="Cancel" Text="Cancel" OnClick="btn_back_Click" TabIndex="4" />
         </div>
     </div>
 </div>

                </div>
                <div class="widget-content">
                   

                    <div class="FormGroupContent4 custom-d-flex">

                        <div class="JobInputN">
                            <span>Job #</span>

                            <asp:TextBox ID="txt_Jobno" runat="server" CssClass="form-control" placeholder="" ToolTip="JOB Number" TabIndex="1"></asp:TextBox>
                        </div>
                        <asp:LinkButton ID="lbl_lnkrate" CssClass="anc ico-find-sm" runat="server" Text="" ForeColor="#FF3300" OnClick="lbl_lnkrate_Click"></asp:LinkButton>
                        <div class="custom-col custom-mr-05">
                            <asp:Label ID="Label1" runat="server" Text="Flight"> </asp:Label>
                            <asp:TextBox ID="txt_Flight" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="FlightCal DateR">
                            <asp:Label ID="Label2" runat="server" Text="Flight Date"> </asp:Label>
                            <asp:TextBox ID="txt_dtFDate" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight Date" BorderColor="#999997"></asp:TextBox>
                            <asp:CalendarExtender ID="dt_validity" runat="server" TargetControlID="txt_dtFDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label3" runat="server" Text="Agent"> </asp:Label>
                            <asp:TextBox ID="txt_Agent" runat="server" CssClass="form-control" placeholder="" ToolTip="Agent" ReadOnly="true"></asp:TextBox>

                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label4" runat="server" Text="Air Line"> </asp:Label>
                            <asp:TextBox ID="txt_AirLine" runat="server" CssClass="form-control" placeholder="" ToolTip="Air Line" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="POLNew1">
                            <asp:Label ID="Label5" runat="server" Text="POL"> </asp:Label>
                            <asp:TextBox ID="txt_PoL" runat="server" CssClass="form-control" placeholder="" ToolTip="POL" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="POLNew2">
                            <asp:Label ID="Label6" runat="server" Text="POD"> </asp:Label>
                            <asp:TextBox ID="txt_PoD" runat="server" CssClass="form-control" placeholder="" ToolTip="POD" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="POLNewCal DateR">
                            <asp:Label ID="Label7" runat="server" Text="CAN Date"> </asp:Label>
                            <asp:TextBox ID="txt_dtCANDate" runat="server" CssClass="form-control" placeholder="" ToolTip="CAN Date"></asp:TextBox>
                            <asp:CalendarExtender ID="dtcandate" runat="server" TargetControlID="txt_dtCANDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                        <div class="ChkBox">
                            <span class="chktext">IGM</span>
                            <asp:CheckBox ID="chk_directbl" runat="server" />

                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <%--   <div class="CanDatelabel">
                                    <asp:Label ID="lbl_candate" runat="server" Text="CAN Date"></asp:Label>
                                </div>
                                <div class="CanTxtbox">
                                    <asp:TextBox ID="txt_candate" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
                                </div>--%>
                        <div class="Consigneerad">
                            <asp:RadioButton ID="rbtn_cnsg" runat="server" Text="" AutoPostBack="True" OnCheckedChanged="rbtn_cnsg_CheckedChanged" TabIndex="3" GroupName="g" />
                            <asp:Label ID="lbl_rbtncnsg" runat="server" Text="Consignee"></asp:Label>
                        </div>
                        <div class="NotifyRad">
                            <asp:RadioButton ID="rbtn_ntfyparty" runat="server" Text="" AutoPostBack="True" OnCheckedChanged="rbtn_ntfyparty_CheckedChanged" GroupName="g" TabIndex="4" />
                            <asp:Label ID="lbl_rbtnntfyparty" runat="server" Text="NotifyParty"></asp:Label>
                        </div>
                        <div class="ForwardRad" style="display: none;">
                            <asp:RadioButton ID="rbtn_forwarder" runat="server" Text="" AutoPostBack="True" GroupName="g" TabIndex="5" /><asp:Label ID="lbl_rbtnforwarder" runat="server" Text="Forwarder "></asp:Label>
                        </div>
                        <div class="DirectRad" style="display: none">
                            <asp:RadioButton ID="rbtn_dirctcnsg" runat="server" Text="" AutoPostBack="True" GroupName="g" TabIndex="6" />
                            <asp:Label ID="lbl_rbtn_dirctcnsg" runat="server" Text="Direct Consignee"></asp:Label>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl">
                            <asp:GridView ID="grd_bLdtls" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                ShowHeaderWhenEmpty="True" OnPreRender="grd_bLdtls_PreRender">
                                <%--DataKeyNames="sublineno,nomination,consigneeid,notifyparty,notifypartyid"--%>
                                <Columns>
                                    <asp:BoundField DataField="blno" HeaderText="HAWB #" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                                    <asp:BoundField DataField="linenumber" HeaderText="Line/Subline" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                                    <%--<asp:BoundField DataField="consigneeid" HeaderText="MailId" />--%>
                                    <asp:TemplateField HeaderText="MailId">
                                        <ItemTemplate>
                                            <asp:TextBox ID="MailId" runat="server" Text='<%#Eval("consigneeid")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_select" runat="server" Checked="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                   

                </div>
            </div>
        </div>
    </div>

    <div class="div_break"></div>
    <%-- popup --%>
    <asp:Label ID="lbl" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="Grd_buying_popup" runat="server" PopupControlID="pnl_Buying" BehaviorID="programmaticModalPopupBehaviordf1"
        TargetControlID="lbl" CancelControlID="imgok" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnl_Buying" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" CssClass="Gridpnl">

                <asp:GridView ID="grd_CAN" runat="server" AutoGenerateColumns="False" Width="100%"
                    HorizontalAlign="Left" CssClass="Grid FixedHeader"
                    OnSelectedIndexChanged="grd_CAN_SelectedIndexChanged" OnRowDataBound="grd_CAN_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job #" />
                        <asp:BoundField DataField="flightno" HeaderText="Flight #" />
                        <asp:BoundField DataField="flightdate" HeaderText="Flight Date" />
                        <asp:BoundField DataField="agent" HeaderText="Agent" />
                        <asp:BoundField DataField="airline" HeaderText="AirLine" />
                        <asp:BoundField DataField="pol" HeaderText="PoL" />
                        <asp:BoundField DataField="pod" HeaderText="PoD" />
                        <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                                        CssClass="Arrow">⇛</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
                <div class="div_break"></div>
            </asp:Panel>
        </div>

    </asp:Panel>
    <%--<div class="div_popup1">
        <asp:Panel ID="pnl_Buying" runat="server" Width="100%" Height="90%" BackColor="White"
            ScrollBars="Vertical">
            <asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="2%" Height="2%"
                CssClass="div_close_voucher" />
            <div class="byrat_break">
            </div>
            <div class="div_grdrat">
                <asp:Panel ID="pnl_grd1" runat="server" Width="90%" Height="100%" ScrollBars="Vertical">
                    <asp:GridView ID="grd_CAN" runat="server" AutoGenerateColumns="False" Width="100%"
                        HorizontalAlign="Left" CssClass="Grid FixedHeader"  
                        onselectedindexchanged="grd_CAN_SelectedIndexChanged">
                        <Columns>
                 <asp:BoundField DataField="jobno" HeaderText="Job #" />
                <asp:BoundField DataField="flightno" HeaderText="Flight #" />
                <asp:BoundField DataField="flightdate" HeaderText="Flight Date" />
                <asp:BoundField DataField="agent" HeaderText="Agent" />
                <asp:BoundField DataField="airline" HeaderText="AirLine" />
                <asp:BoundField DataField="pol" HeaderText="PoL" />
                <asp:BoundField DataField="pod" HeaderText="PoD" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                                        CssClass="Arrow">⇛</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>
                </asp:Panel>
            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="Grd_buying_popup" runat="server" PopupControlID="pnl_Buying"
            TargetControlID="label1" CancelControlID="Close_voucher" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
           <asp:Label ID="label1" runat="server" ></asp:Label>
        </div>
    --%>
    <div>
        <%--<asp:HiddenField ID="hf_hidid1" runat="server" />--%>
        <div class="div_break"></div>
        <asp:HiddenField ID="hf_BL" runat="server" />
        <asp:HiddenField ID="hf_nomination" runat="server" />
        <asp:HiddenField ID="hf_candtbol" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" />
        <asp:HiddenField ID="hf_bookno" runat="server" />
        <asp:HiddenField ID="hf_empname" runat="server" />
    </div>
</asp:Content>
