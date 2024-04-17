<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"  EnableEventValidation="false"  
    CodeBehind="Quotation.aspx.cs" Inherits="logix.FAForm.Quotation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
    <link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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












    <link href="../Styles/Quotationcrm.css" rel="Stylesheet" type="text/css" />
     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>


    <style type ="text/css" >
        .modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        } 
      
        .divRoated
        {
           /*width:853px; 
            Height:303px;
            width:100%; 
            Height:100%;
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;*/
        }

         .DivSecPanel
        {
          
           
            margin-left:98%;
            margin-top:-2.5%;
           
        }
        
       

         .Break
         {
             clear:both;
         }
         .grd-mt
         {
              display :none;
         }

             #table-container 
              {
              position: relative;
              width: 99%;
              height: 400px;
              overflow: auto;
              padding: 0 0.1% 0 0;
              margin-top:0.8%;
              margin-bottom:1%;
              /*----------------*/
              font-family:sans-serif;
              margin-left:0.3%;    
              }

              table.gvTheGrid td,
            table.gvTheGrid th {
              padding: 3px 7px;
            }

              
a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}

        #logix_CPH_popupsecond {left:0px!important; top:50px!important;
        }
        #logix_CPH_pnlJobAE {left:0px!important; top:50px!important;
        }
        #logix_CPH_popupthird{left:0px!important; top:50px!important;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtCustomer.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Quotation.aspx/GetCustomer",
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
                        $("#<%=txtCustomer.ClientID %>").val(i.item.label);
                        $("#<%=txtCustomer.ClientID %>").change();
                        $("#<%=hdf_customerid.ClientID %>").val(i.item.val);



                    },
                    focus: function (event, i) {
                        $("#<%=txtCustomer.ClientID %>").val(i.item.label);
                        $("#<%=hdf_customerid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtCustomer.ClientID %>").val(i.item.label);
                        $("#<%=hdf_customerid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtCargo.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Quotation.aspx/GetLikeCargo",
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
                        $("#<%=txtCargo.ClientID %>").val(i.item.label);
                        $("#<%=txtCargo.ClientID %>").change();
                        $("#<%=hdf_cargoid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtCargo.ClientID %>").val(i.item.label);
                        $("#<%=hdf_cargoid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtCargo.ClientID %>").val(i.item.label);
                        $("#<%=hdf_cargoid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtPOR.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Quotation.aspx/GetPOR",
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
                        $("#<%=txtPOR.ClientID %>").val(i.item.label);
                        $("#<%=txtPOR.ClientID %>").change();
                        $("#<%=hdf_POR.ClientID %>").val(i.item.val);



                    },
                    focus: function (event, i) {
                        $("#<%=txtPOR.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POR.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtPOR.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POR.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtPOL.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Quotation.aspx/GetPOL",
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
                        $("#<%=txtPOL.ClientID %>").val(i.item.label);
                        $("#<%=txtPOL.ClientID %>").change();
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);



                    },
                    focus: function (event, i) {
                        $("#<%=txtPOL.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtPOL.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POL.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtPOD.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Quotation.aspx/GetPOD",
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
                        $("#<%=txtPOD.ClientID %>").val(i.item.label);
                        $("#<%=txtPOD.ClientID %>").change();
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);



                    },
                    focus: function (event, i) {
                        $("#<%=txtPOD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtPOD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_POD.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtFD.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Quotation.aspx/GetFD",
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
                        $("#<%=txtFD.ClientID %>").val(i.item.label);
                        $("#<%=txtFD.ClientID %>").change();
                        $("#<%=hdf_FD.ClientID %>").val(i.item.val);



                    },
                    focus: function (event, i) {
                        $("#<%=txtFD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_FD.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtFD.ClientID %>").val(i.item.label);
                        $("#<%=hdf_FD.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtSalesPerson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Quotation.aspx/GetSales",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      
                        $("#<%=txtSalesPerson.ClientID %>").change();
                        $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      
                        $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);
                       

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);
                          
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtSalesPerson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtCharges.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Quotation.aspx/GetChargename",
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
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                        $("#<%=txtCharges.ClientID %>").change();
                        $("#<%=hdf_Charges.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                        $("#<%=hdf_Charges.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                        $("#<%=hdf_Charges.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtCurr.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Quotation.aspx/GetCurrencyname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        //val: item.split('~')[1]
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
                        $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=txtCurr.ClientID %>").change();
                       $("#<%=hdf_Curr.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdf_Curr.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtCurr.ClientID %>").val(i.item.label);
                      $("#<%=hdf_Curr.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
  }
        </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">CRM</a> </li>
              <li><a href="#" title="">CRM</a> </li>
              <li class="current"><a href="#" title="">Quotation</a> </li>
             <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lblHeader" runat="server" ></asp:Label></h4>
                </div>
          <div class="widget-content">
              <div class="FormGroupContent4">
                  <div class="ProductDrop1"><asp:DropDownList placeholder="Product" ID="ddlpdt" ToolTip="Select Product" runat="server" TabIndex="1"  AutoPostBack="True" OnSelectedIndexChanged="ddlpdt_SelectedIndexChanged">

                              </asp:DropDownList></div>
                  <div class="CRMLink"><asp:LinkButton ID="lnkcrm" runat="server" style="text-decoration:none; color:Red;" OnClick="lnkcrm_Click" >CRM#</asp:LinkButton></div>
                  <div class="CRMTxt"><asp:TextBox ID="txtcrm" runat="server" ToolTip="CRM ID" CssClass="form-control"  TabIndex="2"  AutoPostBack="True" OnTextChanged="txtcrm_TextChanged" ReadOnly="True"></asp:TextBox></div>
                  <div class="Quotationtxt1"><asp:LinkButton ID="linkQuotation" runat="server" style="text-decoration:none; color:Red;" onclick="linkQuotation_Click">Quotation#</asp:LinkButton></div>
                  <div class="QuotationInputN1Q"><asp:TextBox ID="txtQuotation" runat="server"
        ontextchanged="txtQuotation_TextChanged" CssClass="form-control" ToolTip="Quotation#" TabIndex="3"
        AutoPostBack="True"></asp:TextBox></div>
                  <div class="DateLabel"><asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label></div>
                  <div class="DateCal3"><asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox><ajaxtoolkit:calendarextender ID="Calendarextender2" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtDate">
</ajaxtoolkit:calendarextender>     </div>
                  <div class="ValidLabel"><asp:Label ID="lblValidTill" runat="server" Text="ValidTill"></asp:Label></div>
                  <div class="ValidCalendarN2"><asp:TextBox ID="txtValidTill" runat="server" TabIndex="3" AutoPostBack="True" CssClass="form-control"></asp:TextBox></div>
<ajaxtoolkit:calendarextender ID="Calendarextender1" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtValidTill">
</ajaxtoolkit:calendarextender>
                  </div>
              <div class="FormGroupContent4">
                  <div class="CustomerInput9"><asp:TextBox ID="txtCustomer" runat="server" CssClass="form-control" ToolTip="CUSTOMER" PlaceHolder=" CUSTOMER"  TabIndex="4" ontextchanged="txtCustomer_TextChanged" AutoPostBack="True"></asp:TextBox> </div>
                  <div class="Cargo2"><asp:TextBox ID="txtCargo" runat="server" CssClass="form-control" TabIndex="5" ToolTip="CARGO" PlaceHolder=" CARGO" AutoPostBack="True" ontextchanged="txtCargo_TextChanged"></asp:TextBox></div>
              <div class="HazaChk"><asp:CheckBox ID="chkHazard" runat ="server" TabIndex="6" AutoPostBack="True"   /> <asp:Label ID="Label2" runat="server" Text="Hazardous"></asp:Label></div>
              </div>
               <div class="FormGroupContent4">
                   <div class="Place1"><asp:TextBox ID="txtPOR" runat="server"  TabIndex="7" ToolTip="PLACE OF RECEIPT" PlaceHolder=" PLACE OF RECEIPT" CssClass="form-control" AutoPostBack="True" ontextchanged="txtPOR_TextChanged"></asp:TextBox></div>
                   <div class="Place1"><asp:TextBox ID="txtPOL" runat="server" TabIndex="8" ToolTip="PORT OF LOADING" PlaceHolder=" PORT OF LOADING" CssClass="form-control" AutoPostBack="True" ontextchanged="txtPOL_TextChanged"></asp:TextBox></div>
                   <div class="Place1"><asp:TextBox ID="txtPOD" runat="server" TabIndex="9" ToolTip="PORT OF DISCHARGE" PlaceHolder=" PORT OF DISCHARGE" CssClass="form-control" AutoPostBack="True" Width="100%" ontextchanged="txtPOD_TextChanged"></asp:TextBox></div>
                    <div class="Place2"><asp:TextBox ID="txtFD" runat="server" TabIndex="10" ToolTip="FINAL DESTINATION" PlaceHolder=" FINAL DESTINATION" CssClass="form-control" AutoPostBack="True" ontextchanged="txtFD_TextChanged"></asp:TextBox></div>
                    </div>
                 <div class="FormGroupContent4">
                     <div class="Place1"><asp:TextBox ID="txtSalesPerson" runat="server" TabIndex="11"  ToolTip="SALESPERSON" PlaceHolder=" SALESPERSON" CssClass="form-control" AutoPostBack="True" 
        ontextchanged="txtSalesPerson_TextChanged"></asp:TextBox></div>
                      <div class="Place1">
                          <asp:TextBox ID="txtPreparedBy" runat="server" CssClass="form-control" ToolTip="PreparedBy" TabIndex="12"  AutoPostBack="True"></asp:TextBox>
                          </div>
                     <div class="Place3"><asp:RadioButton ID="rdbagent" runat ="server" TabIndex="13" AutoPostBack="True" oncheckedchanged="rdbagent_CheckedChanged" /> <asp:Label ID="lblAgent" runat="server" Text="Agent Controlled"></asp:Label></div>
                     <div class="Place4"><asp:RadioButton ID="rdbBussiness" runat ="server" TabIndex="14" AutoPostBack="True" oncheckedchanged="rdbBussiness_CheckedChanged" /> <asp:Label ID="lblbus" runat="server" Text="Controlled by us"></asp:Label></div>
                     <div class="Place5"><asp:DropDownList placeholder="Shipment" ID="ddlShipment" runat="server" ToolTip="Select Shipment" TabIndex="15"    AutoPostBack="True"></asp:DropDownList></div>
                     <div class="Place6"><asp:DropDownList  placeholder="Freight" ID="ddlFreight" runat="server"  ToolTip="Select Freight" TabIndex="16"   AutoPostBack="True"></asp:DropDownList></div>
                     </div>
              <div class="FormGroupContent4">
                  <div class="Shipper1"><asp:TextBox ID="txtRemarks" runat="server"  style="resize :none ;" TextMode="MultiLine" TabIndex="17" ToolTip="REMARKS" PlaceHolder=" REMARKS"  CssClass="form-control"></asp:TextBox></div>
                  <div class="Consignee3"><asp:TextBox ID="txtDescription"  runat="server"  style="   resize :none ;" CssClass="form-control " TextMode="MultiLine" ToolTip="DESCRIPTION" TabIndex ="18"  PlaceHolder=" DESCRIPTION" ></asp:TextBox></div>
              </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="BuyRate1"><asp:LinkButton ID="linkBuying" runat="server" style="text-decoration:none; color:Red; font-family:Arial; font-size:9pt;" onclick="linkBuying_Click">Buy Rate #</asp:LinkButton></div>
                  <div class="BuyInput1"><asp:TextBox ID="txtBuying" runat="server"  TabIndex="19" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                  <div class="BuyInput2"><asp:TextBox ID="txtBuyingDetails" TabIndex="20" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                  </div>
               <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="right_btn MT0 MB10">
                        <div class="btn btn-save" id="btn_save1" runat="server"> <asp:Button ID="btnSave" runat="server" ToolTip="Save" TabIndex="21" onclick="btnSave_Click" /></div>
                        <div class="btn ico-view"> <asp:Button ID="btnView" runat="server" ToolTip="View" TabIndex="22" /></div>
                        <div class="btn ico-delete" id="btn_app1" runat="server">  <asp:Button ID="btnApp" runat="server"  ToolTip ="Approve"   TabIndex="23" onclick="btnApp_Click"/></div>
                        <div class="btn btn-back" id="btn_back1" runat="server"> <asp:Button ID="btnclose" runat="server" ToolTip="Back"    TabIndex="24" onclick="btnclose_Click"/></div>
                        
   
  
   
                    </div>
                    </div>
              <div class="bordertopNew"></div>
               <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
               <div class="FormGroupContent4">
                   <div class="QuotationLeft">
                       <div class="FormGroupContent4">
                           <div class="Charges1"><asp:TextBox ID="txtCharges" runat="server" TabIndex="25" ToolTip="QUOTATION CHARGES" PlaceHolder=" QUOTATION CHARGES" CssClass="form-control" ontextchanged="txtCharges_TextChanged" AutoPostBack="True"></asp:TextBox></div>
                           <div class="Curr1"><asp:TextBox ID="txtCurr" runat="server" TabIndex="26" ToolTip="CURRENCY" PlaceHolder=" CURR" CssClass="form-control" AutoPostBack="True" ontextchanged="txtCurr_TextChanged" ></asp:TextBox></div>
                           <div class="Rate1"><asp:TextBox ID="txtRate" runat="server" TabIndex="27" ToolTip="RATE" PlaceHolder=" RATE" CssClass="form-control" AutoPostBack="True"  onkeypress="return validateFloatKeyPress(this,event,'Rate')" ></asp:TextBox></div>
                           <div class="BaseDrop"> <asp:DropDownList placeholder="Base" ID="ddlBase" runat="server" TabIndex="28" BorderColor="#999997"  >

    </asp:DropDownList></div>
                           <div class="btn ico-add"><asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="29"   onclick="btnAdd_Click"/></div>
                       </div>
                       <div class="FormGroupContent4">
                           <asp:Panel id="pnlCharge" runat="server" CssClass="Grid FixedHeader"  ScrollBars="Auto">
   <asp:GridView ID="grdQuotation" runat="server" ShowHeaderWhenEmpty="True" height="100%" 
         AutoGenerateColumns="False" 
        Width="100%" onrowdatabound="grdQuotation_RowDataBound" 
        onselectedindexchanged="grdQuotation_SelectedIndexChanged">
                <Columns>
               
        <%--<asp:BoundField DataField="chargename" HeaderText="Charges" />--%>
          <asp:TemplateField HeaderText ="Charges">
          <ItemTemplate>
          <div  style="overflow:hidden;text-overflow:ellipsis;width:150px">
          <asp:Label ID="Charges" runat="server" Text='<%# Bind("chargename") %>'></asp:Label>  
          </div> 
          </ItemTemplate>
          </asp:TemplateField>

        <asp:BoundField DataField="curr" HeaderText="Curr" />
        <%--  <asp:BoundField DataField="rate" HeaderText="Rate" />--%>

                    <asp:TemplateField HeaderText ="Rate">
                            <ItemTemplate>
                            <asp:Label ID="rate" runat="server" Text='<%#Eval("rate","{0:n}" ) %>'></asp:Label>  
                              
                             </ItemTemplate>
                    </asp:TemplateField>
        <asp:BoundField DataField="base" HeaderText="Base " />
        </Columns>
       
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass=""/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
             <RowStyle CssClass="GrdRow" />
    </asp:GridView>
            </asp:Panel>
                       </div>
                       <div class="bordertopNew"></div>
                       <div class="FormGroupContent4">
                           <div class="BuyrateLabel1">Buy Rate Charge</div>
                           <div class="FormGroupContent4">
                                <%---------------------------------------Buying----------------------------------------%>
     <asp:Panel id="Panel1" runat="server" CssClass="Grid FixedHeader"  ScrollBars="Auto">
    <asp:GridView ID="grdBuying" runat="server" AutoGenerateColumns="False" Width="100%" height="100%" ShowHeaderWhenEmpty="True" 
        EnableTheming="False" PageSize="3" >
                <Columns>
                
     <%--   <asp:BoundField DataField="chargename" HeaderText="Charges" />--%>

          <asp:TemplateField HeaderText ="Charges">
          <ItemTemplate>
          <div  style="overflow:hidden;text-overflow:ellipsis;width:150px">
          <asp:Label ID="Charges" runat="server" Text='<%# Bind("chargename") %>'></asp:Label>  
          </div> 
          </ItemTemplate>
          </asp:TemplateField>
        <asp:BoundField DataField="curr" HeaderText="Curr" />
        <%--<asp:BoundField DataField="rate" HeaderText="Rate" />--%>

       <asp:TemplateField HeaderText ="Rate">
           <ItemTemplate>
                <%#Eval("rate","{0:n}")%>
           </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="base" HeaderText="Base " />
        </Columns>
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass=""/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
       
             <RowStyle CssClass="GrdRow" />
    </asp:GridView> 
     </asp:Panel> 
                           </div>
                       </div>

                   </div>
                   <div class="QuotationRight">
                       <div class="FormGroupContent4">
                            <%-----------------------------------Mail Send-----------------------------------%>
                           <asp:Panel id="Panel2" runat="server" cssClass="Grid Minheight" ScrollBars="Auto">
       <asp:GridView ID="grdmail" CssClass="gvTheGrid" runat="server" Width="100%" Font-Size="8.5pt" AutoGenerateColumns="False" AllowSorting="True" 
        ShowHeaderWhenEmpty="True"  >
           <Columns>
              <asp:TemplateField HeaderText ="Name">
              <ItemTemplate>
              <div  style="overflow:hidden;text-overflow:ellipsis;width:150px">
                   <asp:Label ID="new" runat="server" Text='<%# Bind("Cname") %>'></asp:Label>
              </div>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Center" Width="150" Wrap="false" />
              <ItemStyle HorizontalAlign="Left" Width="150" Wrap="false" />
              </asp:TemplateField> 
               <asp:TemplateField HeaderText ="Mail Id">
              <ItemTemplate>
              <div  style="overflow:hidden;text-overflow:ellipsis;width:150px">
                   <asp:Label ID="lblemailid" runat="server" Text='<%# Bind("email") %>'></asp:Label>
              </div>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Center"  Wrap="false" />
              <ItemStyle HorizontalAlign="Left"  Wrap="false" />
              </asp:TemplateField> 

               <asp:TemplateField  HeaderStyle-Width="6%">
                   <ItemTemplate>
                       <asp:CheckBox ID="chkselect" runat="server" CssClass="LabelValue" AutoPostBack="true"  />
                   </ItemTemplate>
               </asp:TemplateField>

           </Columns>

           <EmptyDataRowStyle CssClass="EmptyRowStyle" />
           <HeaderStyle CssClass=""/>
           <AlternatingRowStyle CssClass="GrdAltRow"/>
           <RowStyle CssClass="GrdRow" />
           <PagerSettings FirstPageText="First" LastPageText="Last"  Mode="NumericFirstLast" PageButtonCount="3" position="Bottom" />
           <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle"/>

       </asp:GridView>
 </asp:Panel>
                       </div>
                       <div class="FormGroupContent4">
                           <div class="right_btn MT0 MB10">
                              <div class="btn btn-send">  <asp:Button ID="btnsend" runat="server" Text="Send"  OnClick="btnsend_Click"   />
             <asp:Button ID="Button1" runat="server" Text="Button" Visible ="false" /></div>
                           </div>
                       </div>
                   </div>
                   </div>

              <div class="FormGroupContent4">
                   <%---------------------------------------Popup Buying----------------------------------------%>

    <asp:Label ID="lblAI" runat="server" ></asp:Label>
    <ajaxtoolkit:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="lblAI"  BehaviorID="programmaticModalPopupBehavior1"
                                PopupControlID="pnlJobAE"   
                               CancelControlID="imgfgok">
     </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel ID="pnlJobAE" runat="server"  CssClass="modalPopup"  style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel3" runat="server"  ScrollBars="Vertical"  CssClass="Gridpnl">
      <asp:GridView ID="grdBuyingDetails" CssClass="Grid FixedHeader"  runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found to Display!" AutoGenerateColumns="False" 
      Width="99%" onrowdatabound="grdBuyingDetails_RowDataBound" onselectedindexchanged="grdBuyingDetails_SelectedIndexChanged">
      <Columns>
        <asp:BoundField DataField="rateid" HeaderText="Buying #" />
        <asp:BoundField DataField="Customer" HeaderText="Customer" />
        <asp:BoundField DataField="POL" HeaderText="POL" />
        <asp:BoundField DataField="POD" HeaderText="POD" />
        <asp:BoundField DataField="preparedby" HeaderText="PreparedBy " />
         <asp:BoundField DataField="shipment" HeaderText="shipment" Visible="False" />
        </Columns>
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass=""/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
             <RowStyle CssClass="GrdRow" />
    </asp:GridView>
  </asp:Panel>

       
      </div>

       </asp:Panel>
              </div>

              <div class="FormGroupContent4">
                    <%---------------------------------------Popup Quot----------------------------------------%>

     <asp:Label ID="lblquot" runat="server" ></asp:Label>
        <ajaxtoolkit:ModalPopupExtender ID="popupQuot" runat="server" TargetControlID="lblquot"  BehaviorID="programmaticModalPopupBehavior2"
                                PopupControlID="popupsecond"   
                                CancelControlID="imgok">
     </ajaxtoolkit:ModalPopupExtender>
    <asp:Panel ID="popupsecond" runat="server"  CssClass="modalPopup"  style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel4" runat="server"  ScrollBars="Vertical"  CssClass="Gridpnl">
        <asp:GridView ID="grdQuotaionDetails" CssClass="Grid FixedHeader"  runat="server" ShowHeaderWhenEmpty="True" 
           EmptyDataText="No records Found to Display!" AutoGenerateColumns="False" 
           Width="100%"
           onselectedindexchanged="grdQuotaionDetails_SelectedIndexChanged" 
           onrowdatabound="grdQuotaionDetails_RowDataBound">
        <Columns>
        <asp:BoundField DataField="Quotno" HeaderText="Quotation #">
        <HeaderStyle   Width ="104px"/>
        <ItemStyle  Font-Bold="false"  Width ="100px"/>
        </asp:BoundField>  

              <asp:TemplateField HeaderText ="Customer">
              <ItemTemplate>
              <div  style="overflow:hidden;text-overflow:ellipsis;width:300px">
              <%--<asp:Label ID="Customerid" runat="server" Text='<%# Bind("Customer") %>' Tooltip='<%#Bind("Customer")%>'></asp:Label>--%> 
                   <asp:Label ID="new" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
              </div>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Center" Width="150" Wrap="false" />
              <ItemStyle HorizontalAlign="Left" Width="150" Wrap="false" />
              </asp:TemplateField> 



             <asp:TemplateField HeaderText ="POL">
              <ItemTemplate>
              <div style="overflow:hidden;text-overflow:ellipsis;white-space:nowrap;width:155px">
              <asp:Label ID="POLid" runat="server" Text='<%# Bind("POL") %>' Tooltip='<%#Bind("POL")%>'></asp:Label>  </div>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Center" Width="155px" />
              <ItemStyle HorizontalAlign="Left" Width="155px"/>
              </asp:TemplateField> 

  

             <asp:TemplateField HeaderText ="POD">
              <ItemTemplate>
              <div style="overflow:hidden;text-overflow:ellipsis;white-space:nowrap;width:155px">
              <asp:Label ID="PODid" runat="server" Text='<%# Bind("POD") %>' Tooltip='<%#Bind("POD")%>'></asp:Label>  </div>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Center" Width="155px" />
              <ItemStyle HorizontalAlign="Left" Width="155px"/>
              </asp:TemplateField>

        </Columns>
       
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <HeaderStyle CssClass=""/>
        <AlternatingRowStyle CssClass="GrdAltRow"/>
        <RowStyle CssClass="GrdRow" />
    </asp:GridView>
    </asp:Panel>

      </div>

       </asp:Panel>
                  </div>

               <div class="FormGroupContent4">
                      <%---------------------------------------Popup CRM----------------------------------------%>

      <asp:Label ID="lblcrm" runat="server" ></asp:Label>
      <ajaxtoolkit:ModalPopupExtender ID="popupcrm" runat="server" TargetControlID="lblcrm"  BehaviorID="programmaticModalPopupBehavior3"
                                PopupControlID="popupthird"   
                                CancelControlID="imgggok">
     </ajaxtoolkit:ModalPopupExtender>
        <asp:Panel ID="popupthird" runat="server"  CssClass="modalPopup"   style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="imgggok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel5" runat="server"  ScrollBars="Vertical"  CssClass="Gridpnl">

          <asp:GridView ID="grdcrmQuot" runat="server" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="True" 
           EmptyDataText="No records Found to Display!" AutoGenerateColumns="False" 
           Width="100%" OnRowDataBound="grdcrmQuot_RowDataBound" OnSelectedIndexChanged="grdcrmQuot_SelectedIndexChanged" >
           <Columns>
           <asp:BoundField DataField="crmid" HeaderText="CRM #" />
            <asp:BoundField DataField="customername" HeaderText="Customer" />
          <%--  <asp:BoundField DataField="pdt" HeaderText="Product" />--%>
            <asp:BoundField DataField="por" HeaderText="POR" />
            <asp:BoundField DataField="pol" HeaderText="POL" />
            <asp:BoundField DataField="pod" HeaderText="POD" />
            <asp:BoundField DataField="fd" HeaderText="FD" />
            <asp:BoundField DataField="porid" HeaderText="porid" HeaderStyle-CssClass ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="polid" HeaderText="polid" HeaderStyle-CssClass ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="podid" HeaderText="podid" HeaderStyle-CssClass ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="fdid" HeaderText="fdid"  HeaderStyle-CssClass  ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="salespersonid" HeaderText="salespersonid" HeaderStyle-CssClass ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="salesperson" HeaderText="salesperson" HeaderStyle-CssClass ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="commodityid" HeaderText="commodityid" HeaderStyle-CssClass ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="commodity" HeaderText="commodity"  HeaderStyle-CssClass  ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="freight" HeaderText="freight" HeaderStyle-CssClass ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="hazardous" HeaderText="hazardous"  HeaderStyle-CssClass  ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="customerid" HeaderText="customerid"  HeaderStyle-CssClass  ="grd-mt" ItemStyle-CssClass ="grd-mt"/>
            <asp:BoundField DataField="remarks" HeaderText="remarks"  HeaderStyle-CssClass  ="grd-mt" ItemStyle-CssClass ="grd-mt"/>

        </Columns>
       
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass=""/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
             <RowStyle CssClass="GrdRow" />
    </asp:GridView>


     </asp:Panel>
 
     </div>

     </asp:Panel>

                   </div>
              </div>
         </div>
            </div>
           </div>


 <asp:HiddenField ID="hdf_customerid" runat="server" />
 <asp:HiddenField ID="hdf_cargoid" runat="server" />
 <asp:HiddenField ID="hdf_POL" runat="server" />
 <asp:HiddenField ID="hdf_POR" runat="server" />
 <asp:HiddenField ID="hdf_POD" runat="server" />
 <asp:HiddenField ID="hdf_FD" runat="server" />
 <asp:HiddenField ID="hdf_salesperson" runat="server" />
 <asp:HiddenField ID="hdf_Hazard" runat="server" />
 <asp:HiddenField ID="hdf_Bussiness" runat="server" />
 <asp:HiddenField ID="hdf_Charges" runat="server" />
 <asp:HiddenField ID="hdf_Curr" runat="server" />
</asp:Content>
