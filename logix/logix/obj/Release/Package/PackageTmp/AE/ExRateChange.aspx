<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ExRateChange.aspx.cs" Inherits="logix.AE.ExRateChange" %>

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

 <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>









    <link href="../Styles/ExRateChange.css" rel="stylesheet" />
     <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
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
        #logix_CPH_ddl_curr_chzn {width:100%!important;
        }
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}
    </style>

       <script type="text/javascript">


           function pageLoad(sender, args) {
               $(document).ready(function () {
                   $('input:text:first').focus();
               });
               $(document).ready(function () {
                   $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
               });
           }
       </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
     <div class="widget-header">
                  <h4 class="hide"><i class="icon-umbrella"></i><asp:Label ID="lbl_head" runat="server" Text="Amend Ex.Rate"></asp:Label></h4>
          <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>
              <li><a href="#" title="">Utility</a> </li>
              <li class="current"><a href="#" title="" >ExRate Change</a> </li>
            </ul>
      </div>
                </div>
          <div class="widget-content">
              <div class="FormGroupContent4 FixedButtons">
                  <div class="right_btn">                       
                       <div class="btn ico-update"><asp:Button ID="btn_update" Text="Update" runat="server"  TabIndex="6" ToolTip="Update" OnClick="btn_update_Click" /></div>
                       <div class="btn ico-back" id="btn_back1" runat="server"><asp:Button ID="btn_back" Text="Back" runat="server"  TabIndex="7" ToolTip="Back" OnClick="btn_back_Click" /></div>
                   </div>
              </div>
              <div class="FormGroupContent4 boxmodal">
                  <div class="JobInput9"><asp:TextBox ID="txt_jobno" runat="server" CssClass="form-control" TabIndex="1" onkeypress="return isNumberKey(event,'JobNo');" AutoPostBack="true" OnTextChanged="txt_jobno_TextChanged" placeholder="Job#" ToolTip="Job Number"></asp:TextBox></div>
                  <div class="INVNumber"><asp:DropDownList ID="ddl_inv" runat="server" CssClass="chzn-select" TabIndex="2" Width="100%" AutoPostBack="true"
            OnSelectedIndexChanged="ddl_inv_SelectedIndexChanged" ToolTip="INV Number" data-placeholder="Inv #"></asp:DropDownList></div>
                  <div class="BLNumber4"><asp:TextBox ID="txt_bl" runat="server" CssClass="form-control" TabIndex="3" placeholder="BL#" ToolTip="Bill of Lading Number"></asp:TextBox></div>



                  </div>
             
              <div class="FormGroupContent4 boxmodal">
                  <div class="Shipper1"><asp:DropDownList ID="ddl_curr" runat="server" CssClass="chzn-select" TabIndex="4" ToolTip="Currency" data-placeholder="Currency"></asp:DropDownList>
            <asp:TextBox ID="txt_curr" runat="server" CssClass="form-control" TabIndex="4" AutoPostBack="true" OnTextChanged="txt_curr_TextChanged"></asp:TextBox></div>
                  <div class="Consignee5"><asp:TextBox ID="txt_new" runat="server" CssClass="form-control" TabIndex="5" onkeypress="return validateFloatKeyPress(event,'New Rate');" placeholder="New Ex.Rate" ToolTip="New Ex.Rate"></asp:TextBox></div>



                  </div>
               

              </div>
         </div>
            </div>
           </div>


    <asp:HiddenField ID="hid_currex" runat="server" />
    <asp:HiddenField ID="hid_paex" runat="server" />
    <asp:HiddenField ID="hid_Updateon" runat="server" />
    <asp:HiddenField ID="hid_Vouyear" runat="server" />
    <asp:HiddenField ID="hid_Count" runat="server" />
</asp:Content>
