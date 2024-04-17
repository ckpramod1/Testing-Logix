<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AmendMBL.aspx.cs" Inherits="logix.Maintenance.AmendMBL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
                 <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

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

   <style type="text/css">
    
 
     .AmendSbl {
    width: 28%;
    float: left;
    margin: 0px 1.5% 0px 0px;
}
     .btn.btn-annex1, .btn.btn-cancel1 {
    margin-top: 12px;
}

 
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 15px !important;
}
.Txtjob {
    width: 16%;
    float: left;
    margin: 0px 1.5% 0px 0px;
}
 .FixedButtonsss {
   width: calc(100vw - 980px) !important;
}
 .widget-header .breadcrumb {
    padding: 0px !important;
}
 .alertify .ajs-dialog {
    max-width: 74% !important;
    min-height: 137px;
    background-color: #f4f4f4;
    border: 1px solid #ddd;
    -webkit-box-shadow: none;
    box-shadow: none;
    border-radius: 5px;
}
 .alertify .ajs-modal {
    position: fixed;
    top: 5px !important;
    left: 0;
    right: 0;
    bottom: 0;
    padding: 0;
    overflow-y: auto;
    z-index: 9999999999999999999999999999999999999;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   
     
          <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
   
     <div class="widget-header">
                  <h4 class="hide"><i class="icon-umbrella"></i> <asp:Label ID="lblheader" runat="server" Text=" Amend MBL"></asp:Label> </h4>
         <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li style="display:none"><i class="icon-home"></i><a href="#"></a>Home </li>            
              <li  style="display:none"><a href="#" title="">Documentation</a> </li>
             <li  style="display:none"><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>
              <li class="current"><a href="#" title="">Amend MBL#</a> </li>      </ul>
      </div>
                </div>
            <div class="widget-content" >
             
     <div class="FormGroupContent4 boxmodal">
        <div class="Txtjob">
            <asp:TextBox ID="txt_Job" runat="server" CssClass="form-control" OnTextChanged="txt_Job_TextChanged" AutoPostBack="true" placeholder="Job #" ToolTip="Job Number"></asp:TextBox>

        </div>
        <div class="AmendSbl">
            <asp:TextBox ID="txt_Mbl" runat="server" CssClass="form-control" placeholder="MBL #" ToolTip="MBL Number" Enabled="false" ></asp:TextBox>
        </div>

        <div class="AmendSbl" style="width:51% !important" >
            <asp:TextBox ID="txt_AmedBl" runat="server" CssClass="form-control" placeholder="Amend MBL #" ToolTip="Amend BL Number"></asp:TextBox>
        </div>
      
     
         </div>
                        <div class="FormGroupContent4">
               <div class="right_btn ">
    <div class="btn ico-Amend-MBL" id="btn_Amendbl_id" runat="server" >
        <asp:Button ID="btn_Amendbl" runat="server" Text="Amend MBL #" OnClick="btn_Amendbl_Click" />
    </div>
    <div class="btn ico-cancel">
        <asp:Button ID="btn_back" runat="server" Text="Cancel" OnClick="btn_back_Click" />
    </div>
</div>
        </div>
               
         </div>
      </div>
            </div>
     
    </div>

    <asp:HiddenField ID="Hid_amendbl" runat="server" />
    <asp:HiddenField ID="Hid_amendmbl" runat="server" />
</asp:Content>


