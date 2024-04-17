<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="FICAN.aspx.cs" EnableEventValidation="false" Inherits="logix.FI.FICAN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/FICAN.css" rel="Stylesheet" type="text/css" />

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

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        /*.divRoated
        {
           width:853px; 
            Height:303px;            
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }
        /*.Gridpnl   
         {
            width: 1042px;
            Height:285px;            
            margin-bottom :0.5%;
         
         }*/

        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.3%;
            margin-top: -1.7%;
            position: absolute;
            width: 1027px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .pnlcon {
            /*border-color:#999997;*/
            /*width:48%;*/
            /*margin-left :1%;*/
            /*margin-top:0.5%;*/
            Border: 1px solid #999997;
        }

        .pnlcon1 {
            width: 99%;
            height: 171px;
            Border: 1px solid white;
        }

        .widget.box .widget-content {
            padding: 5px 10px 0px 10px;
            position: relative;
            background-color: #fff;
            display: block;
            top: -1px;
            left: 0px;
        }

        #logix_CPH_Mdl_job_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        /*#logix_CPH_pnl_job {
            top: 45px !important;
        }*/

        .FormGroupContent4 span {
            font-size: 11px;
            /*color: #000080;*/
        }

        .MT20 {
            margin: 20px 0px 0px 0px !important;
        }

        .chzn-container .chzn-results {
            margin: 0 4px 4px 0;
            padding: 0 0 0 4px;
            color: #000000 !important;
            position: relative;
            overflow-x: hidden;
            overflow-y: auto;
            -webkit-overflow-scrolling: touch;
            clear: both;
        }

        .chzn-container-single .chzn-single span {
            color: #000000 !important;
        }

        .chzn-drop {
            overflow: auto;
            height: 150px !important;
        }

        .DirectRad {
            width: 23%;
            float: left;
            margin: 18px 0.5% 0px 0px;
        }

        .ForwardRad {
            width: 16%;
            float: left;
            margin: 18px 0.5% 0px 0px;
        }

        .NotifyRad {
            width: 17%;
            float: left;
            margin: 18px 0.5% 0px 0px;
        }

        .Consigneerad {
            width: 16%;
            float: left;
            margin: 18px 0.5% 10px 0px;
        }

        .row {
            height: 585px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            /* width: 100%; */
        }



        .VesselInput9 {
            width: 34.4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Load {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 50.2%;
        }

        .MLO {
            float: left;
            width: 52.4%;
            margin: 0px 0.5% 0px 0px;
        }
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 89vh;
    overflow-x: hidden;
    overflow-y: auto;
}
        .VesselMlo {
            float: left;
            width: 20.7%;
            margin: 0px 0.5% 0px 0px;
        }.CFS {
    float: left;
    width: 16.5%;
    margin: 0px 0% 0px 0px;
}

        .JobLabelR {
            float: left;
            margin: 0px;
            width: 34%;
            margin: 5px 0px 0px 0px;
        }

        span#logix_CPH_lbl_rbtncnsg, span#logix_CPH_lbl_rbtn_dirctcnsg, span#logix_CPH_lbl_rbtnntfyparty, span#logix_CPH_lbl_rbtnforwarder {
            position: relative;
            left: 0;
        }

        .JobTextfield {
            width: 22%;
            float: left;
            margin: 0px 0.5% 0 0;
        }

        .IM {
    width: 12.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .IMCal1 {
            width: 15.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .IMCal2 {
            width: 16.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .IMCal3 {
            width: 16.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Enter {
            margin-top: 5px;
            display:none;
        }

        .VoyageInput8 {
               width: 30.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CanTxtbox {
            width: 16.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MBLCal1 {
            float: left;
            margin: 0px;
            width: 16.6%;
        }
        .panel_06 {
    height: 188px !important;
}
        .MBL {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 38.9%;
        }
        .JobLabelL {
    float: left;
    margin: 0px 0.5% 0px 0px;
    width: 100%;
}
        .gridright {
    width: 47%;
}
        .Discharge {
    float: left;
    margin: 0px 0.5% 0px 0px;
    width: 48.6%;
}
        .fican {
    width: 65%;
    display: flex;
}

/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
.gridpnl {
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
    height: calc(100vh - 556px);
}
table#logix_CPH_grd_bLdtls tbody th:nth-child(5) {
    width: 59px !important;
}
 
table#logix_CPH_grd_bLdtls tbody th:nth-child(2) {
    width: 77px !important;
}
table#logix_CPH_grd_bLdtls tbody th:nth-child(3) {
    width: 267px !important;
}
table#logix_CPH_grd_bLdtls tbody th:nth-child(5) {
    width: 59px !important;
}
.custom-col {
    flex-basis: 0;
    flex-grow: 1;
    width: 100% !important;
    float: left;
}
.custom-mr-05 {
    margin-right: 0.5% !important;
    float: left;
}
table#logix_CPH_grd_job th:nth-child(1) {
    width: 3% !important;
}

table#logix_CPH_grd_job th:nth-child(2) {
    width: 3% !important;
}
table#logix_CPH_grd_job th:nth-child(3) {
    width: 14% !important;
}
table#logix_CPH_grd_job th:nth-child(4) {
    width: 4% !important;
}
table#logix_CPH_grd_job th:nth-child(5) {
    width: 5% !important;
}
table#logix_CPH_grd_bLdtls th:nth-child(2) {
    width: 60px !important;
}
table#logix_CPH_grd_bLdtls td:nth-child(4) input {
    width: 100% !important;
}
table#logix_CPH_grd_bLdtls th:nth-child(1) {
    width: 175px !important;
}
table#logix_CPH_grd_bLdtls td:nth-child(1) {
    width: 175px !important;
}
table#logix_CPH_grd_bLdtls td:nth-child(3) {
    width: 400px !important;
}
table#logix_CPH_grd_bLdtls th:nth-child(3) {
    width: 400px !important;
}
table#logix_CPH_grd_bLdtls td:nth-child(4) {
    width: 530px !important;
}
table#logix_CPH_grd_bLdtls th:nth-child(4) {
    width: 530px !important;
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
                        <asp:Label ID="lbl_hdr" runat="server" Text="Cargo Arrival Notice"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="">Ocean Imports</a> </li>
                            <li><a href="#" title="">Customer Service</a> </li>
                            <li class="current"><a href="#" title="">Cargo Arrival Notice</a> </li>
                        </ul>
                    </div>
                        </div>

                     <div class="FixedButtons">
      <div class="right_btn">
         <div class="btn ico-send">
             <asp:Button ID="btn_send"  runat="server" Text="Send" TabIndex="10" OnClick="btn_send_Click" />
         </div>
         <div class="btn ico-can-proforma">
             <asp:Button ID="btn_canprfrma" runat="server" Text="CAN Proforma" TabIndex="7" OnClick="btn_canprfrma_Click" />
         </div>
         <div class="btn ico-view">
             <asp:Button ID="btn_can" runat="server" Text="CAN" TabIndex="8" OnClick="btn_can_Click" />
         </div>
         <div class="btn ico-cancel">
             <asp:Button ID="btn_cancel" runat="server" Text="Cancel" TabIndex="9" OnClick="btn_cancel_Click" />
         </div>
     </div>
 </div>
                </div>
                <div class="widget-content">
                   

                    <div class="FormGroupContent4">
                        <div class="fican">
                        <div class="JobLabelL">

                            <div class="FormGroupContent4">
                                <div class="JobTextfield">
                                    <span>Job #</span>

                                    <asp:TextBox ID="txt_jobno" TabIndex="1" runat="server" OnTextChanged="txt_jobno_TextChanged" AutoPostBack="True" CssClass="form-control" placeholder="" ToolTip="Job #"></asp:TextBox>
                                </div>
                                <div class=" boxmodalLink_box">

                                    <asp:LinkButton ID="lbtn_jobno" runat="server" ForeColor="red" Style="text-decoration: none" OnClick="lbtn_jobno_Click" CssClass="anc ico-find-sm"></asp:LinkButton>
                                </div>

                                  <div class="MBL">
                                    <asp:Label ID="Label10" runat="server" Text="MBL #"></asp:Label>
                                    <asp:TextBox ID="txt_mblno" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Master of Bill of Lading Number"></asp:TextBox>
                                </div>
                                <div class="MBLCal1">
                                    <asp:Label ID="Label11" runat="server" Text="MBL Date"></asp:Label>
                                    <asp:TextBox ID="txt_mbldate" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="MBl Date"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="FormGroupContent4 boxmodal">
                                
                                <div class="VesselInput9">
                                    <asp:Label ID="Label5" runat="server" Text="Vessel"></asp:Label>
                                    <asp:TextBox ID="txt_vessel" runat="server" Enabled="false" CssClass="form-control" placeholder="" ToolTip="Vessel"></asp:TextBox>
                                </div>
                                <div class="VoyageInput8">
                                    <asp:Label ID="Label2" runat="server" Text="Voyage"></asp:Label>
                                    <asp:TextBox ID="txt_voyage" runat="server" Enabled="false" CssClass="form-control" placeholder="" ToolTip="Voyage"></asp:TextBox>
                                </div>
                                <div class="IMCal2">
                                    <asp:Label ID="Label6" runat="server" Text="ETA"></asp:Label>
                                    <asp:TextBox ID="txt_eta" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="ETA"></asp:TextBox>
                                </div>
                                    <div class="IMCal3">
                                    <asp:Label ID="Label7" runat="server" Text="ETB"></asp:Label>
                                    <asp:TextBox ID="txt_etb" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="ETB"></asp:TextBox>
                                </div>
                            
                            </div>
                            
                            <div class="FormGroupContent4">
                                  <div class="IM">
                                    <asp:Label ID="Label3" runat="server" Text="IM #"></asp:Label>
                                    <asp:TextBox ID="txt_imno" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="IM Number"></asp:TextBox>
                                </div>
                                    <div class="IMCal1">
                                    <asp:Label ID="Label4" runat="server" Text="IM Date"></asp:Label>
                                    <asp:TextBox ID="txt_imdate" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Im Date"></asp:TextBox>
                                </div>                            
                                    <div class="VesselMlo">
                                    <asp:Label ID="Label14" runat="server" Text="Vessel Imo Code"></asp:Label>
                                    <asp:TextBox ID="txt_vslimocode" runat="server" Enabled="false" CssClass="form-control" placeholder="" ToolTip="Vessel Imo Code"></asp:TextBox>
                                </div>
                                <div class="CanTxtbox">
                                    <asp:Label ID="lbl_candate" runat="server" Text="CAN Date"></asp:Label>
                                    <asp:TextBox ID="txt_candate" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
                                </div>
                               
                                <div class="CFS">
                                    <asp:Label ID="Label15" runat="server" Text="CFS Code"></asp:Label>
                                    <asp:TextBox ID="txt_cfscode" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Container Freight Station Code"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                     <div class="Load">
                                    <asp:Label ID="Label8" runat="server" Text="Vessel PoL"></asp:Label>
                                    <asp:TextBox ID="txt_loadprt" runat="server" Enabled="false" CssClass="form-control" placeholder="" ToolTip="Load Port"></asp:TextBox>
                                </div>
                                <div class="Discharge">
                                    <asp:Label ID="Label9" runat="server" Text="Vessel PoD"></asp:Label>
                                    <asp:TextBox ID="txt_dischrgprt" runat="server" Enabled="false" CssClass="form-control" placeholder="" ToolTip="Discharge Port"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="FormGroupContent4 boxmodal" style="width:99.2%" >                          
                                 <div class="custom-col custom-mr-05">
                                    <asp:Label ID="Label12" runat="server" Text="MLO"></asp:Label>
                                    <asp:TextBox ID="txt_MLO" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Main-Line Operator"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 custom-d-flex" style="width:99.2%" >
                               
                                <div class="custom-col custom-mr-05">
                                    <asp:Label ID="Label13" runat="server" Text="Agent"></asp:Label>
                                    <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Agent"></asp:TextBox>
                                </div>
                               
                            </div>
                            <div class="FormGroupContent4" style="width:99.2%" >
                                  <div class="custom-col ">
                                    <asp:Label ID="Label16" runat="server" Text="CFS"></asp:Label>
                                    <asp:TextBox ID="txt_cfs" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Container Freight Station"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal">
                                
                                <div class="Consigneerad">
                                    <asp:RadioButton ID="rbtn_cnsg" runat="server" Text="" AutoPostBack="True" OnCheckedChanged="rbtn_cnsg_CheckedChanged" TabIndex="3" GroupName="g" />
                                    <asp:Label ID="lbl_rbtncnsg" runat="server" Text="Consignee"></asp:Label>
                                </div>
                                <div class="NotifyRad">
                                    <asp:RadioButton ID="rbtn_ntfyparty" runat="server" Text="" AutoPostBack="True" GroupName="g" TabIndex="4" OnCheckedChanged="rbtn_ntfyparty_CheckedChanged" />
                                    <asp:Label ID="lbl_rbtnntfyparty" runat="server" Text="NotifyParty"></asp:Label>
                                </div>
                                <div class="ForwardRad">
                                    <asp:RadioButton ID="rbtn_forwarder" runat="server" Text="" AutoPostBack="True" GroupName="g" TabIndex="5" OnCheckedChanged="rbtn_forwarder_CheckedChanged" /><asp:Label ID="lbl_rbtnforwarder" runat="server" Text="Forwarder "></asp:Label>
                                </div>
                                <div class="DirectRad">
                                    <asp:RadioButton ID="rbtn_dirctcnsg" runat="server" Text="" AutoPostBack="True" GroupName="g" TabIndex="6" OnCheckedChanged="rbtn_dirctcnsg_CheckedChanged" />
                                    <asp:Label ID="lbl_rbtn_dirctcnsg" runat="server" Text="Direct Consignee"></asp:Label>
                                </div>
                            </div>
                          

                        </div>
                            <div class="gridright">
                              <div class=" FormGroupContent4">
                                <asp:Panel ID="pnl_grdcontnr" runat="server" CssClass="panel_06 MB0">
                                    <asp:GridView ID="grd_contnr" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" OnPreRender="grd_contnr_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="containerno" HeaderText="Container #" />
                                            <asp:BoundField DataField="sizetype" HeaderText="Size" />
                                            <asp:BoundField DataField="sealno" HeaderText="Seal #" />
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                            </div>
                        </div>
                        <div class="JobLabelR boxmodal">
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl" Width="65%" >
                            <asp:GridView ID="grd_bLdtls" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                OnRowCommand="grd_bLdtls_RowCommand" OnSelectedIndexChanged="grd_bLdtls_SelectedIndexChanged" ShowHeaderWhenEmpty="True" OnPreRender="grd_bLdtls_PreRender">
                                <%--DataKeyNames="sublineno,nomination,consigneeid,notifyparty,notifypartyid"--%>
                                <Columns>
                                    <asp:BoundField DataField="blno" HeaderText="BL #" />
                                    <asp:BoundField DataField="linenumber" HeaderText="Line #" />
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
                    <div class="FormGroupContent4">
                        <div class="Enter">
                            <asp:Label ID="lbl_entermailid" runat="server" CssClass="LabelValue" Text="Enter Mail ID(s) seperated by semicolon ( ; )"></asp:Label>
                        </div>
                       

                    </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_job" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="img_grd_book" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">
                                    <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" AllowPaging="false" Width="100%" ForeColor="Black" CssClass="Grid FixedHeader" EmptyDataText="No Record Found" PageSize="20"
                                        BackColor="White" OnSelectedIndexChanged="grd_job_SelectedIndexChanged" OnRowDataBound="grd_job_RowDataBound">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Job">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                        <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="52px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="JobType">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                        <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Vessel">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                                        <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vesselname") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Voyage">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                        <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Agent">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 430px">
                                                        <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MLO/FFR">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 350px">
                                                        <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ETA">
                                                <ItemTemplate>
                                                    <div >
                                                        <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="71px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ETB">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="ETB" runat="server" Text='<%# Bind("etb") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="POL">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                        <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MBL">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 92px">
                                                        <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="92px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Arrow" CommandName="select"
                                        Font-Underline="false">⇛</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                            <%--<div class="div_Break"></div>--%>
                        </asp:Panel>

                        <asp:ModalPopupExtender ID="Mdl_job" runat="server" TargetControlID="Label1" CancelControlID="img_grd_book" PopupControlID="pnl_job" DropShadow="false">
                        </asp:ModalPopupExtender>
                        <asp:HiddenField ID="hf_mdljob" runat="server" />

                        <div>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_candate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_imdate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_eta" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_etb" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_mbldate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            <asp:HiddenField ID="hf_gridradio" runat="server" />
                            <asp:HiddenField ID="hf_grdjob_index" runat="server" />
                            <asp:HiddenField ID="hf_empname" runat="server" />
                            <asp:HiddenField ID="hf_bookno" runat="server" />
                            <asp:HiddenField ID="hf_BL" runat="server" />
                            <asp:HiddenField ID="hf_nomination" runat="server" />
                            <asp:HiddenField ID="hf_candtbol" runat="server" />
                            <asp:HiddenField ID="hf_flag" runat="server" />
                            <asp:HiddenField ID="hid_canrpt" runat="server" Value="Y" />
                            <asp:HiddenField ID="hid_canprorpt" runat="server" Value="Y" />
                            <asp:HiddenField ID="hid_canFWrpt" runat="server" Value="Y" />
                            <asp:HiddenField ID="hid_canFWrptCR" runat="server" Value="Y" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
