<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FIcustomsreport.aspx.cs" Inherits="logix.FI.FIcustomsreport" %>
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

    <link href="../Styles/FIcustomsreport.css" rel="Stylesheet" type="text/css" />
      <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
 <style type ="text/css" >
        .modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        } 

        /*.divRoated
        {
           width:949px; 
            Height:303px;           
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/

         .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }
        .GridHeader1 
        {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.3%;
            margin-top: -1.7%;
            position: absolute;
            width: 1027px;
        }
        .JobInput16 {
    font-size: 11px;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
         .Break
         {
             clear:both;
         }
         .grd-mt
         {
              display :none;
         }
     #logix_CPH_Mdl_job_foregroundElement {left:0px!important; top:50px!important;
     }
    
     .btn.btn-save1 {
    margin: 12px 0 0 0;
}
     .JobInput16 {
         width:6.5%;
     }
     .ETA {
    float: right;
    margin: 0px 0px;
    width: 8.2%;
}
     .MBLInput6 {
    float: left;
    margin: 0px 0px 0px 0px;
    width: 21.5%;
}
     .btn.ico-save {
    margin-top: 6px;
}
    </style>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
<script src="../Scripts/Validation.js" type="text/javascript"></script>
<link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>    
<link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  
    <style type="text/css" > 
        a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}

        .challan {
            float:left; 
            margin:0px 0.5% 0px 0px; 
            width:5%;
}

        .CompanyNameDrop {
            width:25%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
           .mlo {
            width:30.2%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
              .agent {
            width:30.2%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }

       .lblCRS {
    float: left;
    font-size: 11px;
    left: 77.5%;
    margin: 3px 0 0;
    position: absolute;
    width: 8%;
    color:#4cd849;
}
        #logix_CPH_ddl_report_chzn {
            width:100%!important;
        }

                .challan1 {
            float:left; 
            margin:0px 0.5% 0px 0px; 
            width:10.7%;
}

  .MT20
        {
                margin: 20px 0px 0px 0px!important;
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


/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
      padding-top: 65px !important;
}

    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12"  class="maindiv"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
     <div class="widget-header">
                  <h4 class="hide"><i class="icon-umbrella"></i><asp:Label ID="lbl_hdr" runat="server" Text="Customs Report"></asp:Label></h4>
             <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
                         <li><a href="#" title="">Ocean Imports</a> </li>
              <li><a href="#" title="">Customer Service</a> </li>
              <li class="current"><a href="#" title="">Customs Report</a> </li>
            </ul>
      </div>
                </div>
          <div class="widget-content">
              <div class="FixedButtons">
                  
      
     <div class="left_btn" >
         <div class="btn ico-igm-1-5">
             <asp:Button ID="btn_igm" runat="server" Text="IGM 1.5" ToolTip="IGM 1.5" OnClick="btn_igm_Click" TabIndex="2" />

         </div>
         <div class="btn ico-liner-igm">
             <asp:Button ID="btn_ligm" runat="server" Text="Liner IGM" ToolTip="Liner IGM" OnClick="btn_ligm_Click" TabIndex="3" />
         </div>
         <div class="btn ico-customs-edi">
             <asp:Button ID="btn_cedi" runat="server" Text="Customs EDI" ToolTip="Customs EDI" OnClick="btn_cedi_Click" TabIndex="4" />
         </div>

         <div class="btn ico-igm-1-5-view">
             <asp:Button ID="btn_igmrpt" runat="server" Text="View IGM 1.5" ToolTip="View IGM 1.5" OnClick="btn_igmrpt_Click" TabIndex="2" />
         </div>
         <div class="btn ico-liner-view">
             <asp:Button ID="btn_ligmrpt" runat="server"  Text="View Liner IGM"  ToolTip="View Liner IGM" OnClick="btn_igmrpt_Click" TabIndex="3" />
         </div>
         <div class="btn ico-custom-view">
             <asp:Button ID="btn_cedirpt" runat="server" Text="View Customs EDI" ToolTip="View Customs EDI" OnClick="btn_igmrpt_Click" TabIndex="4" />
         </div>
         </div>
                  <div class="right_btn">
                       <div class="btn ico-annexure-i"><asp:Button ID="btn_annex1" runat="server" Text="Annexure1"  onclick="btn_annex1_Click" TabIndex="16"/></div>
                       <div class="btn ico-annexure-ii"><asp:Button ID="btn_annex2" runat="server" Text="Annexure2"  onclick="btn_annex2_Click" TabIndex="17"/></div>
                       <div class="btn ico-annexure-b"><asp:Button ID="btn_annexB" runat="server" Text="AnnexureB" onclick="btn_annexB_Click" TabIndex="18"/></div>
                       <div class="btn ico-form-ii"><asp:Button ID="btn_form2" runat="server" Text="Form II"  onclick="btn_form2_Click" TabIndex="19"/></div>
                       <div class="btn ico-form-iii"><asp:Button ID="btn_form3" runat="server" Text="Form III" onclick="btn_form3_Click" TabIndex="20"/></div>
                       
                      
                      
                   
                      <div class="btn ico-clp"><asp:Button ID="btn_cntnrldplan" runat="server" Text="Container Load Plan"  onclick="btn_cntnrldplan_Click" TabIndex="21"/></div>
                       <div class="btn ico-igm-final"><asp:Button ID="btn_finaligm" runat="server" Text="Final IGM"  onclick="btn_finaligm_Click" TabIndex="22"/></div>
                      <div class="btn ico-consol-letter"><asp:Button ID="btn_consolletter" runat="server" Text="Consol Letter" onclick="btn_consolletter_Click" TabIndex="23"/></div>
                        <div class="btn ico-icd-cfs"><asp:Button ID="btn_icdcfs" runat="server" Text="ICD CFS" onclick="btn_icdcfs_Click" TabIndex="24"/></div>
                  
                    
                        <div class="btn ico-icd-movement-note"><asp:Button ID="btn_icdmovement" runat="server" Text="ICD Movement Note"  onclick="btn_icdmovement_Click" TabIndex="26"/></div>
                        <div class="btn ico-icd-cargo-declaration"><asp:Button ID="btn_icdcargo" runat="server" Text="ICD Cargo Declaration"  onclick="btn_icdcargo_Click" TabIndex="27"/></div>
                        <div class="btn ico-cancel"><asp:Button ID="btn_cancel" runat="server" Text="Cancel" onclick="btn_cancel_Click" TabIndex="28"/></div>
                        <div class="btn ico-icd-tsa"><asp:Button ID="btn_icdtsa" runat="server" Text="ICD TSA" onclick="btn_icdtsa_Click" TabIndex="25"/></div>

                     
                 </div>
              </div>
              <div class="FormGroupContent4">
                   <div class="JobInput16 custom-mr-05">
                       <span>Job #</span>
                          
                       <asp:TextBox ID="txt_job" runat="server" AutoPostBack="True" cssclass="form-control" ontextchanged="txt_job_TextChanged" placeholder="" ToolTip="Job Number" TabIndex="1"></asp:TextBox>
                       </div>
                       <asp:LinkButton ID="lbtn_job" runat="server" ForeColor="red" style="text-decoration:none" onclick="lbtn_job_Click" TabIndex="2" CssClass="anc ico-find-sm"></asp:LinkButton>
                   <div class="MBLInput6 custom-col custom-mr-05">
                       <asp:Label ID="Label4" runat="server" Text="MBL"></asp:Label>
                       <asp:TextBox ID="txt_mbl" cssclass="form-control" runat="server"  ReadOnly="true" placeholder="" ToolTip="Master of Bill of Lading"  TabIndex="4"></asp:TextBox>
                       </div>

              </div>
               <div class="FormGroupContent4 boxmodal custom-d-flex">
                  
                   <div class="VesselInput10  custom-mr-05" style="width:21.5%" >
                       <asp:Label ID="Label3" runat="server" Text="Vessel"></asp:Label>
                   <asp:TextBox ID="txt_vsl" cssclass="form-control" runat="server"  ReadOnly="true" placeholder="" ToolTip="Vessel" TabIndex="3"></asp:TextBox>
                       </div>
                      <div class="ETA">
                      <asp:Label ID="Label5" runat="server" Text="ETA"></asp:Label>
                      <asp:TextBox ID="txt_eta" cssclass="form-control" runat="server" placeholder="" ToolTip="Estimated Time of Arrival Date" ReadOnly="true"  TabIndex="5"></asp:TextBox></div>
                   </div>

            <div class="FormGroupContent4 boxmodal">
                  <div class="VesselInput10" style="width:14.8%" >
                      <asp:Label ID="Label8" runat="server" Text="POL"></asp:Label>
                      <asp:TextBox ID="txt_pol" cssclass="form-control" runat="server" placeholder=""  ReadOnly="true" ToolTip="Port of Loading"  TabIndex="8"></asp:TextBox>
                      </div>
                  <div class="MBLInput6" style="width:14.9%" >
                      <asp:Label ID="Label9" runat="server" Text="POD"></asp:Label>
                      <asp:TextBox ID="txt_pod" cssclass="form-control" runat="server" placeholder=""  ReadOnly="true" ToolTip="Port of Destination" TabIndex="9"></asp:TextBox>
                      </div>

                  </div>
               <div class="FormGroupContent4 boxmodal custom-d-flex">
                   
               <div class="mlo">
                   <asp:Label ID="Label7" runat="server" Text="MLO"></asp:Label>
                   <asp:TextBox ID="txt_mlo" cssclass="form-control" runat="server" placeholder=""  ReadOnly="true" ToolTip="Main Line Operator" TabIndex="7"></asp:TextBox>
                   </div>
                   </div>
              <div class="FormGroupContent4">
                  <div class="agent">
                   <asp:Label ID="Label6" runat="server" Text="Agent"></asp:Label>
                   <asp:TextBox ID="txt_agent" cssclass="form-control" runat="server"  ReadOnly="true" placeholder="" ToolTip="Agent" TabIndex="6"></asp:TextBox>
                       </div>
              </div>

              <hr />
              <div class="FormGroupContent4 boxmodal">
              <div class="CompanyNameDrop hide">
                  <asp:Label ID="Label10" runat="server" Text="Report"></asp:Label>
                  <asp:DropDownList ID="ddl_report" CssClass ="chzn-select"  runat="server" ToolTip="Report" TabIndex="10" ></asp:DropDownList></div>
                        <div class="challan" style="width: 6%;" >
                            <asp:Label ID="Label11" runat="server" Text="Challan #"></asp:Label>
                            <asp:TextBox ID="txtchallan" cssclass="form-control" runat="server" placeholder="" ToolTip="Challan Number" TabIndex="11" ></asp:TextBox></div >                           
                        <div class="challan">
                            <asp:Label ID="Label12" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txtchallanDate" cssclass="form-control" runat="server" placeholder="" ToolTip="Challan Date" TabIndex="12" ></asp:TextBox></div>
                        <div class="challan"  style="width:7%">
                            <asp:Label ID="Label13" runat="server" Text="Value+Duty"></asp:Label>
                            <asp:TextBox ID="txtvalueduty" cssclass="form-control" runat="server" placeholder="" ToolTip="Value+Duty" TabIndex="13" ></asp:TextBox></div>
                        <div class="challan1">
                            <asp:Label ID="Label14" runat="server" Text="BondAmount"></asp:Label>
                            <asp:TextBox ID="txtbondamt" cssclass="form-control" runat="server" placeholder="" ToolTip="BondAmount" TabIndex="14"></asp:TextBox></div>
                        <div class="lblCRS custom-pt-3 hide"> <asp:Label ID="lblcrs" runat="server"  Text="(InCRS)"></asp:Label></div>
              
                <div class="left_btn">
                            <div class="btn ico-save">
                                <asp:Button ID="btn_save" runat="server" Text="Save"  OnClick="btn_save_Click" TabIndex="15" />
                            </div>
                     
                        </div>      </div>          
             
              <div class="bordertopNew"></div>
              
            
              <div class="FormGroupContent4">
                  <%-- popup --%>
                   <asp:Panel ID="pnl_job" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
      <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel2" runat="server"  CssClass="Gridpnl">

       <%-- <asp:Panel ID="pnl_job" runat="server" Width="100%" CssClass="div_frame" Style="display:none;">
        <div class="div_close"><asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" width="100%" Height="100%" ImageUrl="~/images/close2.png"/></div>
        <div class="div_Break"></div>        
                   
          <div class="div_Grd">--%>
               
                 <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" OnRowDataBound="grd_job_RowDataBound" AllowPaging="false"
                     EmptyDataText="No Record Found" CssClass="Grid FixedHeader"  PageSize="20" BackColor="White" onselectedindexchanged="grd_job_SelectedIndexChanged" OnPageIndexChanging="grd_job_PageIndexChanging">

                <Columns>
                            
                <asp:TemplateField HeaderText ="Job">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:40px">
                       <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="40px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
        
                <asp:TemplateField HeaderText ="VesselName">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:130px">
                       <asp:Label ID="VesselName" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="130px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="ETA">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:70px">
                       <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="86px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="MBL">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:130px">
                       <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="160px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="Agent">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="100px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="MLO">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:150px">
                       <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="150px" HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="PoL">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="PoL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="80px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="POD">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="POD" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="80px"  HorizontalAlign="Center"  />
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
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <PagerStyle CssClass="GridviewScrollPager" />
                    </asp:GridView>
         
         </asp:Panel>
                   </div>
        </asp:Panel>
         <asp:ModalPopupExtender ID="Mdl_job" runat="server" TargetControlID="Label1" CancelControlID="Close_voucher" PopupControlID="pnl_job" DropShadow="false">
         </asp:ModalPopupExtender>
         <asp:HiddenField ID="hf_mdl" runat="server" />
     <div class="div_Break"></div>
      <asp:Panel ID="pnl_aie" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="img_aiecancel" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel1" runat="server"  CssClass="Gridpnl">

              <%--<asp:Panel ID="pnl_aie" runat="server" Width="100%" CssClass="div_frame" Style="display:none;">
              <div class="div_close"><asp:Image ID="img_aiecancel" runat="server" ImageAlign="Baseline" width="100%" Height="100%" ImageUrl="~/images/close2.png"/></div>
              <div class="div_Break"></div>        
              <div class="div_Grd">--%>
                 
                 <asp:GridView ID="grd_aie" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" AllowPaging="false"
                     OnRowDataBound="grd_aie_RowDataBound" CssClass="Grid FixedHeader"  EmptyDataText="No Record Found" PageSize="20" BackColor="White" onselectedindexchanged="grd_aie_SelectedIndexChanged" OnPageIndexChanging="grd_aie_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Job #" DataField="jobno">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Flight#/ Date" DataField="flight#">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="MAWBL" DataField="mawblno">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mawbldate" HeaderText="BL Date">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="agent" HeaderText="Agent" />
                            <asp:BoundField HeaderText=" Air Liner" DataField="airline">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pol" HeaderText="POL" />
                            <asp:BoundField DataField="pod" HeaderText="POD" />
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Arrow" CommandName="select"
                                        Font-Underline="false">⇛</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView> </asp:Panel>   
            </div>               
                  </asp:Panel> 

              </div>
              </div>
         </div>
            </div>
           </div>

       <div class="div_Break"></div>
    <div>
    <asp:ModalPopupExtender ID="MDL_AIE" runat="server" TargetControlID="Label2" CancelControlID="img_aiecancel" PopupControlID="pnl_aie" DropShadow="false">
    </asp:ModalPopupExtender>

        <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txtchallanDate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:HiddenField ID="hf_mdlaie" runat="server" />
    </div>
    <div class="">
        <asp:HiddenField ID="hf_vouyear" runat="server" />
        <asp:HiddenField ID="hf_grdjob_index" runat="server" />
        <asp:HiddenField ID="hf_grdaie_index" runat="server" />
        <asp:HiddenField ID="hf_etd" runat="server" />
        <asp:HiddenField ID="HiddenField5" runat="server" />
        <asp:HiddenField ID="HiddenField6" runat="server" />
          <asp:HiddenField ID="hf_customeid" runat="server" />

      <asp:HiddenField ID="hid_icdcfs" runat="server"  Value="Y" />
        <asp:HiddenField ID="hid_cancmnote" runat="server"  Value="Y" />
        <asp:HiddenField ID="hid_rptannx1" runat="server" Value="Y" />
          <asp:HiddenField ID="hid_annexure" runat="server"  Value="Y" />
          <asp:HiddenField ID="hid_form3" runat="server"  Value="Y" /> 
          <asp:HiddenField ID="hid_consolletterCR" runat="server"  Value="N" />    
          <asp:HiddenField ID="hid_form2CR" runat="server"  Value="N" />
         <asp:HiddenField ID="hid_annex3CR" runat="server"  Value="N" />

        <asp:HiddenField ID="hid_icdcfsCR" runat="server"  Value="N" />
        <asp:HiddenField ID="hid_cancmnoteCR" runat="server"  Value="N" />
        <asp:HiddenField ID="hid_rptannx1CR" runat="server"  Value="N" />
          <asp:HiddenField ID="hid_annexureCR" runat="server"  Value="N" />       
         <asp:HiddenField ID="hid_form3CR" runat="server"  Value="N" />
          <asp:HiddenField ID="hid_consolletter" runat="server"  Value="Y" />
          <asp:HiddenField ID="hid_form2" runat="server"  Value="Y" />
       
         <asp:HiddenField ID="hid_annex3" runat="server"  Value="Y" />

      <asp:HiddenField ID="hid_icdTSA" runat="server"  Value="Y" />
        <asp:HiddenField ID="hid_icdTSACR" runat="server"  Value="N" />
           <asp:HiddenField ID="hf_jobno" runat="server" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </div>
   <div class=""></div>

</asp:Content>
