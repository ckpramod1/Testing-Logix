<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="QuotationMultiport.aspx.cs" Inherits="logix.ForwardExports.QuotationMultiport" %>

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
        <%--<script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>--%>
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
    <link href="../Styles/Quotation-Multiport.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
     <script src="../Scripts/gridviewScroll.min.js"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%= txt_customer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_customerid.ClientID %>").val(0);
                        $.ajax({
                            url: "../ForwardExports/QuotationMultiport.aspx/Getcustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[2],
                                        val: item.split('~')[1],
                                        text: item.split('~')[0]
                                    }
                                }))

                            },

                            error: function (response) {
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (e, i) {
                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                        $("#<%=txt_customer.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                        $("#<%=txt_customer.ClientID %>").val(i.item.text);
                    },
                    focus: function (e, i) {
                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                        $("#<%=txt_customer.ClientID %>").val(i.item.text);
                    },
                    minLength: 1
                });
            });
            <%--$(document).ready(function () {
                $('#<%=grd_qtncustmr.ClientID%>').gridviewScroll({
                    width: 737,
                    height: 150,
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
        .widget.box {
    position: relative;
    top: -8px;
}
     .widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}
     div#logix_CPH_panel {
    height: calc(100vh - 170px);
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     
          <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
   
     <div class="widget-header">
         <div>
                  <h4 class="hide"><i class="icon-umbrella"></i><asp:Label ID="lbl_hdr" runat="server" Text="Quotation-Multiport"></asp:Label></h4>
         <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
                          <li><a href="#" title="">Sales</a> </li>         
              <li class="current"><a href="#" title="">Rate Sheet</a> </li>
            </ul>
      </div>
             </div>

            <div class="FixedButtons" >
       <div class="right_btn">
           <div class="btn ico-print"> <asp:Button ID="btn_print" runat="server" Text="Print" ToolTip="Print"  OnClick="btn_print_Click" /></div>
           <div class="btn ico-back" id="btn_back1" runat="server"> 
               <asp:Button ID="btn_back" Text="Cancel" runat="server"  ToolTip="Cancel" OnClick="btn_back_Click" />
   </div>
           
       
       </div>
   </div>
                </div>
            <div class="widget-content" >
             
                <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                    <span>Customer</span>
                    <asp:TextBox ID="txt_customer" runat="server" placeholder="Customer" ToolTip="Customer"
                AutoPostBack="True" OnTextChanged="txt_customer_TextChanged" CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>
                <div class="FormGroupContent4 boxmodal">
                    <asp:Panel ID="panel" runat="server" CssClass="gridpnl">
            <asp:GridView ID="grd_qtncustmr" runat="server" Width="100%" CssClass="Grid FixedHeader" 
                AutoGenerateColumns="False" OnRowCommand="grd_qtncustmr_RowCommand" ShowHeaderWhenEmpty="true"
                OnSelectedIndexChanged="grd_qtncustmr_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Print">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_select" runat="server" AutoPostBack="true" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="quotno" HeaderText="Quot #" />
                    <asp:BoundField DataField="quotdate" HeaderText="Date" />
                    <asp:BoundField DataField="por" HeaderText="PoR" />
                    <asp:BoundField DataField="pol" HeaderText="PoL" />
                    <asp:BoundField DataField="pod" HeaderText="PoD" />
                    <asp:BoundField DataField="fd" HeaderText="Place of Delivery" />
                    <asp:BoundField DataField="cargotype" HeaderText="CargoType" />
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
         <asp:HiddenField ID="hf_customerid" runat="server" />
    <asp:HiddenField ID="hf_grdqtncustmr_index" runat="server" />
        </div>



           
</asp:Content>
