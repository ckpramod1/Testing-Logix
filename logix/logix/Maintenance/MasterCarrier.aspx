<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCarrier.aspx.cs" Inherits="logix.Maintenance.MasterCarrier" %>

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

      <script type="text/javascript">

          function pageLoad(sender, args) {


              $(document).ready(function () {
                  $("#<%=txtCarrierName.ClientID %>").autocomplete({
                       source: function (request, response) {

                           $.ajax({
                               url: "MasterCarrier.aspx/GetCarriername",
                               data: "{ 'prefix': '" + request.term + "'}",
                               dataType: "json",
                               type: "POST",
                               contentType: "application/json; charset=utf-8",
                               success: function (data) {

                                   response($.map(data.d, function (item) {

                                       return {

                                           label: item.split('~')[0],
                                           val: item.split('~')[1]
                                       }
                                   }))

                               },

                               error: function (response) {
                                   //alertify.alert(response.responseText);
                               },
                               failure: function (response) {
                                   //alertify.alert(response.responseText);
                               }
                           });
                       },
                       select: function (event, i) {
                           $("#<%=txtCarrierName.ClientID %>").val(i.item.label);
                    $("#<%=txtCarrierName.ClientID %>").change();
                    $("#<%=hid_carrier .ClientID %>").val(i.item.val);


                },
                    focus: function (event, i) {
                        $("#<%=txtCarrierName.ClientID %>").val(i.item.label);
                    $("#<%=hid_carrier.ClientID %>").val(i.item.val);

                },
                    close: function (event, i) {
                        $("#<%=txtCarrierName.ClientID %>").val(i.item.label);
                    $("#<%=hid_carrier.ClientID %>").val(i.item.val);

                },
                    minLength: 1
                });
               });

          }

    </script>
    <style type="text/css">
        .DistrictForNew {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
            .DistrictForNew1 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
            .DistrictForNew2 {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
            .btn.btn-save1, .btn.btn-back, .btn.btn-update1 {
    margin: 12px 0px 0px 0px;
}
  
            div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top:65px !important;
}
            .FixedButtonsss {
    width: calc(100vw - 500px) !important;
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
                        <asp:Label ID="lbl_Header" runat="server" Text="Master Carrier"></asp:Label></h4>
                     <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Maintenance</a> </li>
            <li class="current"><a href="#" title="">Master Carrier</a> </li>
        </ul>
    </div>
                        </div>

                                        <div class="FixedButtons">
                          <div class="right_btn">
    <div class="btn ico-save">
        <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_Click" />
    </div>
    <div class="btn ico-back">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel"  OnClick="btnCancel_Click" />

    </div>
</div>
                    </div>

                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">
                        <div class="DistrictForNew" style="display:none">
                            <asp:TextBox ID="txtcarrierId" runat="server" placeholder="Carrier Id" TabIndex="1"  CssClass="form-control" ToolTip="Carrier Id"></asp:TextBox>

                        </div>
                           <div class="DistrictForNew2">
                            <asp:TextBox ID="txtCarrierName" runat="server" placeholder="Carrier Name" AutoPostBack="true" OnTextChanged="txtCarrierName_TextChanged" TabIndex="2" CssClass="form-control" ToolTip="Carrier Name"></asp:TextBox>

                        </div>
                         <div class="DistrictForNew1">
                            <asp:TextBox ID="txtCarrieerCode" runat="server" placeholder="Carrier Code" AutoPostBack="true" OnTextChanged="txtCarrieerCode_TextChanged" TabIndex="3" CssClass="form-control" ToolTip="Carrier Code"></asp:TextBox>

                        </div>
                         
                            <div class="DistrictForNew1">
                            <asp:TextBox ID="txtSCACcode" runat="server" placeholder="SCAC Code" TabIndex="4" CssClass="form-control" ToolTip="SCAC Code"></asp:TextBox>

                        </div>
                         


                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hid_carrier" runat="server" />
    <asp:HiddenField ID="hid_carrier_upd" runat="server" />
</asp:Content>
