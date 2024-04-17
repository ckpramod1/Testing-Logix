<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ISFDetails.aspx.cs" EnableEventValidation="false" Inherits="logix.ShipmentDetails.ISFDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>


    <link href="../Styles/ISFDetails.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {



            $(document).ready(function () {
                $("#<%=txtBlNo.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "ISFDetails.aspx/GetBLNO",
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
                        $("#<%=txtBlNo.ClientID %>").val(i.item.label);
                        $("#<%=txtBlNo.ClientID %>").change();
                        $("#<%=hdf_blno.ClientID %>").val(i.item.val);



                    },
                    focus: function (event, i) {
                        $("#<%=txtBlNo.ClientID %>").val(i.item.label);
                        $("#<%=hdf_blno.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtBlNo.ClientID %>").val(i.item.label);
                        $("#<%=hdf_blno.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });




            $(document).ready(function () {
                $("#<%=txtImporter.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hdf_Importer.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                            data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }


                        });
                    },

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtImporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_Importer.ClientID %>").val(i.item.val);
                            $("#<%=txtImporterAdd.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtImporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_Importer.ClientID %>").val(i.item.val);
                            $("#<%=txtImporterAdd.ClientID %>").val(i.item.address);
                        }
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtImporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_Importer.ClientID %>").val(i.item.val);
                            $("#<%=txtImporterAdd.ClientID %>").val(i.item.address);
                        }
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txtImporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_Importer.ClientID %>").val(i.item.val);
                            $("#<%=txtImporterAdd.ClientID %>").val(i.item.address);
                        }
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtBuyer.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hdf_buyer.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }


                         });
                     },

                     select: function (event, i) {
                         if (i.item) {
                             $("#<%=txtBuyer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_buyer.ClientID %>").val(i.item.val);
                             $("#<%=txtBuyerAdd.ClientID %>").val(i.item.address);
                         }
                     },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtBuyer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_buyer.ClientID %>").val(i.item.val);
                             $("#<%=txtBuyerAdd.ClientID %>").val(i.item.address);
                         }
                     },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtBuyer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_buyer.ClientID %>").val(i.item.val);
                             $("#<%=txtBuyerAdd.ClientID %>").val(i.item.address);
                         }
                     },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txtBuyer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_buyer.ClientID %>").val(i.item.val);
                             $("#<%=txtBuyerAdd.ClientID %>").val(i.item.address);
                         }
                     },
                    minLength: 1
                });
            });

             $(document).ready(function () {
                 $("#<%=txtSupplier.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hdf_Supplier.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }


                         });
                     },

                     select: function (event, i) {
                         if (i.item) {
                             $("#<%=txtSupplier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Supplier.ClientID %>").val(i.item.val);
                             $("#<%=txtSupplierAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txtSupplier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Supplier.ClientID %>").val(i.item.val);
                             $("#<%=txtSupplierAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtSupplier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Supplier.ClientID %>").val(i.item.val);
                             $("#<%=txtSupplierAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     close: function (event, i) {
                         if (i.item) {
                             $("#<%=txtSupplier.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Supplier.ClientID %>").val(i.item.val);
                             $("#<%=txtSupplierAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     minLength: 1
                 });
             });

             $(document).ready(function () {
                 $("#<%=txtImpFor.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hdf_ImpFor.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'P'}",
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
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }


                         });
                     },

                     select: function (event, i) {
                         if (i.item) {
                             $("#<%=txtImpFor.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_ImpFor.ClientID %>").val(i.item.val);
                             $("#<%=txtImpForAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txtImpFor.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_ImpFor.ClientID %>").val(i.item.val);
                             $("#<%=txtImpForAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtImpFor.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_ImpFor.ClientID %>").val(i.item.val);
                             $("#<%=txtImpForAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     close: function (event, i) {
                         if (i.item) {
                             $("#<%=txtImpFor.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_ImpFor.ClientID %>").val(i.item.val);
                             $("#<%=txtImpForAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     minLength: 1
                 });
             });


            //txtStuff  hdf_Stuff  txtStuffAdd
             $(document).ready(function () {
                 $("#<%=txtStuff.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hdf_Stuff.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }


                         });
                     },

                     select: function (event, i) {
                         if (i.item) {
                             $("#<%=txtStuff.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Stuff.ClientID %>").val(i.item.val);
                             $("#<%=txtStuffAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txtStuff.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Stuff.ClientID %>").val(i.item.val);
                             $("#<%=txtStuffAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtStuff.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Stuff.ClientID %>").val(i.item.val);
                             $("#<%=txtStuffAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     close: function (event, i) {
                         if (i.item) {
                             $("#<%=txtStuff.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Stuff.ClientID %>").val(i.item.val);
                             $("#<%=txtStuffAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     minLength: 1
                 });
             });

             $(document).ready(function () {
                 $("#<%=txtConsolid.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hdf_consolid.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }


                         });
                     },

                     select: function (event, i) {
                         if (i.item) {
                             $("#<%=txtConsolid.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_consolid.ClientID %>").val(i.item.val);
                             $("#<%=txtConsolidAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txtConsolid.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_consolid.ClientID %>").val(i.item.val);
                             $("#<%=txtConsolidAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtConsolid.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_consolid.ClientID %>").val(i.item.val);
                             $("#<%=txtConsolidAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     close: function (event, i) {
                         if (i.item) {
                             $("#<%=txtConsolid.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_consolid.ClientID %>").val(i.item.val);
                             $("#<%=txtConsolidAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     minLength: 1
                 });
             });

            //txtShipTo txtShipToAdd  hdf_Shipto
             $(document).ready(function () {
                 $("#<%=txtShipTo.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hdf_Shipto.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }


                         });
                     },

                     select: function (event, i) {
                         if (i.item) {
                             $("#<%=txtShipTo.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Shipto.ClientID %>").val(i.item.val);
                             $("#<%=txtShipToAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txtShipTo.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Shipto.ClientID %>").val(i.item.val);
                             $("#<%=txtShipToAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtShipTo.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Shipto.ClientID %>").val(i.item.val);
                             $("#<%=txtShipToAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     close: function (event, i) {
                         if (i.item) {
                             $("#<%=txtShipTo.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hdf_Shipto.ClientID %>").val(i.item.val);
                             $("#<%=txtShipToAdd.ClientID %>").val(i.item.address);
                         }
                     },
                     minLength: 1
                 });
             });




             $(document).ready(function () {
                 $("#<%=txtmulti.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hid_multimanufacturer.ClientID %>").val(0);
                         $.ajax({
                             url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                             data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }


                         });
                     },

                     select: function (event, i) {
                         if (i.item) {
                             $("#<%=txtmulti.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                             $("#<%=txtmanufacturer.ClientID %>").val(i.item.address);
                         }
                     },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txtmulti.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                             $("#<%=txtmanufacturer.ClientID %>").val(i.item.address);
                         }
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtmulti.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                             $("#<%=txtmanufacturer.ClientID %>").val(i.item.address);
                         }
                     },
                     close: function (event, i) {
                         if (i.item) {
                             $("#<%=txtmulti.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                             $("#<%=txtmanufacturer.ClientID %>").val(i.item.address);
                         }
                     },
                     minLength: 1
                 });
             });









           <%-- $(document).ready(function () {
                $("#<%=TextBox1.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_multimanufacturer.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddress",
                            data: "{ 'prefix': '" + request.term + "','FType':'C'}",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }


                        });
                    },

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=TextBox1.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                            $("#<%=TextBox2.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=TextBox1.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                            $("#<%=TextBox2.ClientID %>").val(i.item.address);
                        }
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=TextBox1.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                            $("#<%=TextBox2.ClientID %>").val(i.item.address);
                        }
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=TextBox1.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_multimanufacturer.ClientID %>").val(i.item.val);
                            $("#<%=TextBox2.ClientID %>").val(i.item.address);
                        }
                    },
                    minLength: 1
                });
            });--%>


        }
    </script>
    <style type="text/css">
      

        #logix_CPH_pnlform {
            left: -9px !important;
            top: 0px !important;
        }

        .Padpop {
            padding: 5px 5px 5px 5px;
        }

     /*   .modalPopupss {
            background-color: #FFFFFF;
            border-style: solid;
            border-color: #CCCCCC;
            width: 64% !important;
            Height: 328px !important;
            margin-left: 0%;
            margin-top: -2.9%;
            overflow-y: hidden;
            overflow-x: hidden;
        }*/
        /*.row {
    height: 600px!important;txtmultitxtmanufacturer
    overflow: auto!important;hid_multimanufacturer
    width:100%;
}*/
        #logix_CPH_pnl_grd2 {
            left: 157px !important;
            top: 173px !important;
        }

        .DivSecPanel {
            padding: 2px 2px 2px 2px;
            margin: -2px 0px 5px 0px;
        }

        .div_popupview {
            height: 300px;
        }
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
        .Addbtn1 {
            float: left;
            width: 2%;
            margin: 0px;
        }

        /*LOG DETAILS CSS*/


        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }


        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }


            .DivSecPanelLog img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }


        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

        .LogHeadLbl {
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }


        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }




            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }


        .BLNo1 {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobNo3 {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MBLNo3 {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BookingNo2 {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CarrierIput {
            width: 23.4%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .VOYInput2 {
            width: 9%;
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

        .SameChkbox {
                width: 7%;
    float: left;
    color: #000080;
    margin: 15px 0px 0px 0px;
        }
        .btn.btn-add-icon-blue {
    margin: 18px 0 0 0;
}
 .CargoRight {
    margin: 5px 0 0 0px !important;
    width:100%;
}     
 
 .CargoLeft {
    margin-right: 0.5% !important;
}
 div#logix_CPH_grdPanal {
       height: 136px !important;
    border-bottom: 1px solid var(--inputborder) !important;
}
 .CargoLeft {
    width: 49.5%;
    float: left;
}
 
 .Importernew {
    width: 92%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 .VesselInput2 {
    width: 13.6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 .divright{
   width:33%;
   float:left;
   margin:0px 0px 0px 0px;
 }

 .divleft{
   width:33%;
   float:left;
   margin:0px 0.5% 0px 0px;
 }
  .divmiddle{
   width:33%;
   float:left;
   margin:0px 0.5% 0px 0px;
 }
 
  .CargoInput1 textarea {
    height: 136px !important;
}
  .MarksInput1 {
    width: 100%;
    float: left;
    border-bottom: 1px solid var(--inputborder);
    height: 146px;
}
  .MarksInput1:focus {
     border-bottom: #06529c !important;
}
  .MarksInput1.TextField input#logix_CPH_txtMarks {
    border: none !important;
}
  .AMSInput {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
  table#logix_CPH_grd thead th:nth-child(3) {
    width: 0% !important;
}
table#logix_CPH_grd thead th:nth-child(2) {
    width: 0% !important;
}
.HTS{
           width: 32.9%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .POInput1 {
            width: 32.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
    .SCAC {
    width: 33.2%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

    .Importer {
    width: 33%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
      .Importeradd {
    width: 33%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Buyer {
    width: 33.3% !important;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
  .Buyeradd {
    width: 33.1%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    .Consignee {
       width: 32.7%;
    float: left;
    margin: 0px 0px 0px 0px;
}
  .Consigneeadd {
       width: 32.9%;
    float: left;
    margin: 0px 0px 0px 0px;
}
    .Supplier {
    width: 33.3%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
      .Supplieradd {
    width: 33.1%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Shipper {
    width: 32.9%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
             .Shipperadd {
    width: 33%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
                  .ExpForwarder {
   width: 50.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
                 .ExpForwarderadd {
        width: 50.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
     .cha {
    width: 32.7%;
    float: left;
    margin: 0px 0% 0px 0px;
}

       .chaadd {
       width: 32.9%;
    float: left;
    margin: 0px 0 0px 0px;
}
       .ImpForwarder{
              width: 49%;
    float: left;
    margin: 0px 0.5% 0px 0px;
       }

       .ImpForwarderadd{
              width: 49%;
    float: left;
    margin: 0px 0.5% 0px 0px;
       }
/*New design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
span.chktext {
    font-weight: 500 !important;
    margin: -6px 0 0 5px !important;
    padding: 0px 0px 4px 0px;
    font-size: 13px !important;
}
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

   
    <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblHeader" runat="server" Text="ISF Details"></asp:Label>
                        </h4>
                         <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#"></a>Documentation</li>
            <li><a href="#" title="">Ocean Exports</a> </li>
            <li class="current"><a href="#" title="">ISF Details</a> </li>
        </ul>
    </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                    </div>
                   <div class="FixedButtons">
     <div class="right_btn">

        <div class="btn ico-save" id="btnSave1" runat="server">
            <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" TabIndex="28" OnClick="btnSave_Click" />
        </div>
        <div class="btn ico-delete">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" TabIndex="29" OnClick="btnDelete_Click" />
        </div>
        <div class="btn ico-view">
            <asp:Button ID="btnView" runat="server" Text="View" ToolTip="View" TabIndex="30" OnClick="btnView_Click" />
        </div>
        <div class="btn ico-cancel" id="btnclose1" runat="server">
            <asp:Button ID="btnclose" runat="server" Text="Cancel" ToolTip="Cancel" TabIndex="31" OnClick="btnclose_Click" />
        </div>
    </div>
</div>
                </div>




                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="BLNo1">
                            <asp:Label ID="Label1" runat="server" Text="BL #"> </asp:Label>
                            <asp:TextBox ID="txtBlNo" runat="server" CssClass="form-control" OnTextChanged="txtBlNo_TextChanged" AutoPostBack="True" placeholder="" TabIndex="1" ToolTip="BL Number"></asp:TextBox>
                        </div>
                        <div class="AMSInput">
                                    <asp:Label ID="Label10" runat="server" Text="AMS HBL #"> </asp:Label>
                                    <asp:TextBox ID="txtAmsHBL" runat="server" CssClass="form-control " placeholder="" ToolTip="AMS HBL Number" TabIndex="10"></asp:TextBox>
                                </div>
                                <div class="SameChkbox">
                                    <span>Same as HBL</span>
                                    <asp:CheckBox ID="chkHBL" runat="server" OnCheckedChanged="chkHBL_CheckedChanged" AutoPostBack="true" />
                                </div>
                        <div class="JobNo3">
                            <asp:Label ID="Label2" runat="server" Text="Job #"> </asp:Label>
                            <asp:TextBox ID="txtJobNo" runat="server" CssClass="form-control " Enabled="false" placeholder="" ToolTip="Job Number" TabIndex="2"></asp:TextBox>
                        </div>
                        <div class="MBLNo3">
                            <asp:Label ID="Label3" runat="server" Text="MBL #"> </asp:Label>
                            <asp:TextBox ID="txtMblNo" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="MBL Number" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="BookingNo2">
                            <asp:Label ID="Label4" runat="server" Text="Booking #"> </asp:Label>
                            <asp:TextBox ID="txtBookingNo" runat="server" CssClass="form-control " Enabled="false" placeholder="" ToolTip="Booking Number" TabIndex="4"> </asp:TextBox>
                        </div>
                        <div class="VesselInput2">
                            <asp:Label ID="Label5" runat="server" Text="Vessel"> </asp:Label>
                            <asp:TextBox ID="txtVessel" runat="server" CssClass="form-control " Enabled="false" placeholder="" ToolTip="Vessel" TabIndex="5"></asp:TextBox>
                        </div>
                        <div class="VOYInput2">
                            <asp:Label ID="Label6" runat="server" Text="Voy"> </asp:Label>
                            <asp:TextBox ID="txtVoy" runat="server" CssClass="form-control " Enabled="false" placeholder="" ToolTip="Voy" TabIndex="6"></asp:TextBox>
                        </div>
                        <div class="CarrierIput">
                            <asp:Label ID="Label7" runat="server" Text="Carrier"> </asp:Label>
                            <asp:TextBox ID="txtCarrier" runat="server" CssClass="form-control " Enabled="false" placeholder="" ToolTip="Carrier" TabIndex="7"></asp:TextBox>
                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <div class="divleft">
                          <div class="MarksInput1">
                            <asp:Label ID="Label8" runat="server" Text="Marks"> </asp:Label>
                            <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control " Enabled="false" placeholder="" ToolTip="Marks" TabIndex="8"></asp:TextBox>
                        </div>

                        </div>
                        <div class="divmiddle">
                               

                              <div class="CargoRight boxmodal">
                            <asp:Panel ID="grdPanal" runat="server" CssClass="panel_04 MB0">

                                <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" PageSize="5" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_RowDataBound" OnPreRender="grd_PreRender">
                                    <Columns>


                                        <asp:TemplateField HeaderText="Container #">

                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 93px">
                                                    <asp:Label ID="containerno" runat="server" Text='<%# Bind("containerno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="180" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Seal #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                    <asp:Label ID="sealno" runat="server" Text='<%# Bind("sealno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="120" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SizeType">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                    <asp:Label ID="sizetype" runat="server" Text='<%# Bind("sizetype") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="120" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>


                                    <AlternatingRowStyle CssClass="GrdRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <RowStyle CssClass="GridviewScrollItem" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                          

                        </div>
                        <div class="divright">



                                     <div class="CargoInput1">
                            <asp:Label ID="Label9" runat="server" Text="Cargo Desc"> </asp:Label>
                            <asp:TextBox ID="txtCargo" runat="server" CssClass="form-control" TextMode="MultiLine" Style="resize: none;" TabIndex="9" Rows="2" Enabled="false" placeholder="" ToolTip="Cargo Desc"></asp:TextBox>
                        </div>

                        </div>

                    
                    </div>
                    <div class="FormGroupContent4">

                            <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                       
                    </div>
                    <div class="FormGroupContent4">
                       
                    </div>
                                </div>

                    <div class="FormGroupContent4">
                       
                            
                          
                                <div class="POInput1">
                                    <asp:Label ID="Label12" runat="server" Text="PO #"> </asp:Label>
                                    <asp:TextBox ID="txtPoNo" runat="server" CssClass="form-control " placeholder="" ToolTip="PO Number" TabIndex="11"></asp:TextBox>
                                </div>
                                <div class="SCAC">
                                    <asp:Label ID="Label13" runat="server" Text="SCAC"> </asp:Label>
                                    <asp:TextBox ID="txtSCAc" runat="server" CssClass="form-control  " placeholder="" ToolTip="SCAC" TabIndex="12"></asp:TextBox>
                                </div>
                       

                            <div class="HTS">
                                <asp:Label ID="Label14" runat="server" Text="HTS # (If have multiple HTS # seperated by Comma ( , ))"> </asp:Label>
                                <asp:TextBox ID="txtHTS" runat="server" CssClass="form-control " placeholder="" TabIndex="13" ToolTip="HTS Number (If have multiple HTS # seperated by Comma ( , ) and each HTS # maximum 10 character )"></asp:TextBox>
                            </div>

                        
                       
                        
                    </div>
                        </div>


                    <div class="FormGroupContent4">
                        <div class="Importer">
                            <asp:Label ID="Label15" runat="server" Text="Importer"> </asp:Label>
                            <asp:TextBox ID="txtImporter" runat="server" CssClass="form-control " AutoPostBack="True" placeholder="" ToolTip="Importer" OnTextChanged="txtImporter_TextChanged" TabIndex="14"></asp:TextBox>
                        </div>
                          <div class="Buyer">
                            <asp:Label ID="Label16" runat="server" Text="Buyer"> </asp:Label>
                            <asp:TextBox ID="txtBuyer" runat="server" CssClass="form-control " AutoPostBack="True" placeholder="" ToolTip="Buyer" OnTextChanged="txtBuyer_TextChanged" TabIndex="15" ></asp:TextBox>
                        </div>

                         <div class="Consignee">

                            <asp:Label ID="Label19" runat="server" Text="Consignee"> </asp:Label>
                            <asp:TextBox ID="txtConsignee" runat="server" CssClass="form-control " Enabled="false" AutoPostBack="True" placeholder="" ToolTip="Consignee" TabIndex="16"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        
                            <div class="Importeradd">
                            <asp:Label ID="Label17" runat="server" Text="Importer Address"> </asp:Label>
                            <asp:TextBox ID="txtImporterAdd" runat="server" CssClass="form-control " TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Importer Address" ></asp:TextBox>
                        </div>
                           <div class="Buyeradd">

                            <asp:Label ID="Label18" runat="server" Text="Buyer Address"> </asp:Label>
                            <asp:TextBox ID="txtBuyerAdd" runat="server" CssClass="form-control " TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Buyer Address"></asp:TextBox>
                        </div>
                                                <div class="Consigneeadd">

                            <asp:Label ID="Label21" runat="server" Text="Consignee Address"> </asp:Label>
                            <asp:TextBox ID="txtConsigneeAdd" runat="server" CssClass="form-control " Enabled="false" TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Consignee Address"></asp:TextBox>
                        </div>
                         
                       
                    </div>

                    <div class="FormGroupContent4">
                         <div class="Shipper">

                            <asp:Label ID="Label23" runat="server" Text="Shipper"> </asp:Label>
                            <asp:TextBox ID="txtShipper" runat="server" CssClass="form-control " Enabled="false" placeholder="" ToolTip="Shipper" TabIndex="18"></asp:TextBox>
                        </div>

                         <div class="Supplier">

                            <asp:Label ID="Label20" runat="server" Text="Supplier"> </asp:Label>
                            <asp:TextBox ID="txtSupplier" runat="server" CssClass="form-control " AutoPostBack="True" placeholder="" ToolTip="Supplier" OnTextChanged="txtSupplier_TextChanged" TabIndex="17"></asp:TextBox>
                        </div>

                          <div class="cha">

                            <asp:Label ID="Label27" runat="server" Text="C H A"> </asp:Label>
                            <asp:TextBox ID="txtCha" runat="server" CssClass="form-control " Enabled="false" AutoPostBack="True" placeholder="" ToolTip="C H A" TabIndex="20"></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent4">
                          <div class="Shipperadd">

                            <asp:Label ID="Label25" runat="server" Text="Shipper Address"> </asp:Label>
                            <asp:TextBox ID="txtShipperAdd" runat="server" CssClass="form-control " Enabled="false" TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Shipper Address"></asp:TextBox>
                        </div>
                         <div class="Supplieradd">

                            <asp:Label ID="Label22" runat="server" Text="Supplier Address"> </asp:Label>
                            <asp:TextBox ID="txtSupplierAdd" runat="server" CssClass="form-control " TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Supplier Address"></asp:TextBox>
                        </div>
                              <div class="chaadd">

                            <asp:Label ID="Label29" runat="server" Text="C H A Address"> </asp:Label>
                            <asp:TextBox ID="txtChaAdd" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="C H A Address"></asp:TextBox>
                        </div>
                    </div>

                 

                   
 

                     
                   

                        <div class="FormGroupContent4">
                             <div class="ImpForwarder">
                            <asp:Label ID="Label28" runat="server" Text="ImpForwarder"> </asp:Label>
                            <asp:TextBox ID="txtImpFor" runat="server" CssClass="form-control " AutoPostBack="True" placeholder="" ToolTip="ImpForwarder" OnTextChanged="txtImpFor_TextChanged" TabIndex="21"></asp:TextBox>
                       </div>
                                <div class="ExpForwarder">

                            <asp:Label ID="Label24" runat="server" Text="ExpForwarder"> </asp:Label>
                            <asp:TextBox ID="txtExpFor" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="True" OnTextChanged="txtExpFor_TextChanged" placeholder="" ToolTip="ExpForwarder" TabIndex="19"></asp:TextBox>
                        </div>
                                  
                          

                    </div>

                        <div class="FormGroupContent4">
                            <div class="ImpForwarderadd">
                           
                            <asp:Label ID="Label30" runat="server" Text="ImpForwarder Address"> </asp:Label>
                            <asp:TextBox ID="txtImpForAdd" runat="server" CssClass="form-control " TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="ImpForwarder Address"></asp:TextBox>
                        </div>
                                                    <div class="ExpForwarderadd">

                            <asp:Label ID="Label26" runat="server" Text="ExpForwarder Address"> </asp:Label>
                            <asp:TextBox ID="txtExpForAdd" runat="server" CssClass="form-control " Enabled="false" TextMode="MultiLine" ReadOnly="true" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="ExpForwarder Address"></asp:TextBox>
                        </div>
                        
                           
                            
                    </div>
                     
                    <div class="FormGroupContent4">

                        <div class="Importer boxmodal" style="width: 49%;
    float: left;
    margin-right: 0.5% !important;" >
                    <div class="FormGroupContent4">
                            <asp:Label ID="Label31" runat="server" Text="Stuff Loc"> </asp:Label>
                            <asp:TextBox ID="txtStuff" runat="server" CssClass="form-control " AutoPostBack="True" placeholder="" ToolTip="Stuff Loc" TabIndex="22" OnTextChanged="txtStuff_TextChanged"></asp:TextBox>
                        </div>

                        <div class="FormGroupContent4">
                            <asp:Label ID="Label33" runat="server" Text="Stuff Loc Address"> </asp:Label>
                            <asp:TextBox ID="txtStuffAdd" runat="server" CssClass="form-control " TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Stuff Loc Address"></asp:TextBox>
                        </div>

                    </div>

                        <div class="Buyer boxmodal" style="width: 50% !important;
    float: left;" >
                    <div class="FormGroupContent4">
                            <asp:Label ID="Label32" runat="server" Text="Consolidator"> </asp:Label>
                            <asp:TextBox ID="txtConsolid" runat="server" CssClass="form-control " AutoPostBack="True" placeholder="" ToolTip="Consolidator" OnTextChanged="txtConsolid_TextChanged" TabIndex="23"></asp:TextBox>
                        </div>

                        <div class="FormGroupContent4">
                            <asp:Label ID="Label34" runat="server" Text="Consolidator Address"> </asp:Label>
                            <asp:TextBox ID="txtConsolidAdd" runat="server" CssClass="form-control " TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Consolidator Address"></asp:TextBox>
                        </div>
                    </div>
                        </div>

                    <div class="FormGroupContent4">
                        <div class="Importer boxmodal" style="    width: 49%;
    float: left;
    margin-right: 0.5% !important;" >
                    <div class="FormGroupContent4">
                            <asp:Label ID="Label35" runat="server" Text="Ship To"> </asp:Label>
                            <asp:TextBox ID="txtShipTo" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Ship To" OnTextChanged="txtShipTo_TextChanged" TabIndex="24"></asp:TextBox>
                        </div>

                        <div class="FormGroupContent4">
                            <asp:Label ID="Label38" runat="server" Text="Ship To Address"> </asp:Label>
                            <asp:TextBox ID="txtShipToAdd" runat="server" CssClass="form-control" TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Ship To Address"></asp:TextBox>
                        </div>

                    </div>

                        <div class="Buyer boxmodal" style="width: 50% !important;
    float: left;">
                    <div class="FormGroupContent4">
                        <div class="Importernew">
                            <asp:Label ID="Label36" runat="server" Text="Multiple manufacturer"> </asp:Label>
                            <asp:TextBox ID="txtmulti" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Multiple Manufacturer" OnTextChanged="txtmulti_TextChanged" TabIndex="25"></asp:TextBox>
                        </div>
                        <div class="btn ico-add-icon-blue custom-mt-2">
                            <asp:Button ID="txtaddmultiple" runat="server" Text="Add" CssClass="Button"    placeholder="Multiple manufacturer" OnClick="txtaddmultiple_Click" />
                        </div>
                        </div>

                        <div class="FormGroupContent4">
                            <asp:Label ID="Label39" runat="server" Text="Multiple Manufacturer Address"> </asp:Label>
                            <asp:TextBox ID="txtmanufacturer" runat="server" CssClass="form-control" TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder="" ToolTip="Multiple Manufacturer Address"></asp:TextBox>
                        </div>
                            </div>
                        </div>

                    <div class="MB10" style="float: right; margin-right: 10px;">
                        <asp:Button ID="Button1" runat="server" ToolTip="Excel" CssClass="Button" TabIndex="26" Visible="false" />
                        <asp:Button ID="btnXML" runat="server" ToolTip="X M L" CssClass="Button" TabIndex="27" Visible="false" OnClick="btnXML_Click" />

                    </div>
                  

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_grd2" runat="server" CssClass="modalPopup" Width="100%" Height="100%">
                            <div class="DivSecPanel">
                                <asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>
                            <div class="div_popupview">


                                <iframe id="ifrmaster" runat="server" src="" frameborder="0" width="100%"
                                    height="100%" backgroundcssclass="modalBackground"></iframe>
                            </div>
                            -
                        </asp:Panel>
                    </div>
                    <ajaxtoolkit:ModalPopupExtender ID="modal_view" runat="server" PopupControlID="pnl_grd2"
                        TargetControlID="hid1" CancelControlID="Close_voucher">
                    </ajaxtoolkit:ModalPopupExtender>







                    <%------------------------------------------------------- multimanfaturer -------------------------------------------%>




                    <%--<asp:Label ID="Lblmultimanu" runat="server"></asp:Label>--%>


                    <%-- <ajaxtoolkit:ModalPopupExtender ID="popcancel" runat="server" TargetControlID="Lblmultimanu"
            BehaviorID="programmaticModalPopupBehavior3" DropShadow="false"
            PopupControlID="pnlform" PopupDragHandleControlID="Panel3"
            CancelControlID="Image1">
        </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel ID="pnlform" runat="server"  CssClass="modalPopup Padpop"  BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                    
                    <div style="font-weight:bold; font-size:14px; padding:15px 0px 0px 5px; color:#076acc;">
                        <asp:Label ID="Label1" runat="server" Text="Add Muliti Manufaturer"></asp:Label>
                   
                </div>


                     <div class="FormGroupContent4">
                        
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="Multiple manufacturer" ToolTip="Add Multiple Manufaturer" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                       
                       
                           
                          </div>
                     <div class="FormGroupContent4">
                          <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="MultiLine" AutoPostBack="True" Style="resize: none;" Rows="2" placeholder=" Multiple Manufaturer Address" ToolTip="Multiple Manufaturer Address"></asp:TextBox>
                       

                         </div>
                         <div class="bordertopNew"></div>

                         <div class="FormGroupContent4">
                        <div class="right_btn MB05 MT0">

                            <div class="btn btn-save">
                                <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" />
                            </div>
                           
                            <div class="btn ico-cancel">
                                <asp:Button ID="btnback" runat="server" Text="Back" />
                            </div>
                        </div>
                            


                              <asp:GridView ID="grdadd"  runat="server" AutoGenerateColumns="False"   CssClass="Grid FixedHeader"  ForeColor="Black" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdadd_SelectedIndexChanged" > 
                      
                  
                        <Columns>
                            <asp:BoundField DataField="manuname" HeaderText="Name">
                                <ControlStyle />
                                <HeaderStyle Width="117px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="manudtls" HeaderText="Address">
                                <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="75px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                         
                      
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <RowStyle Font-Italic="False" />
                        <PagerStyle CssClass="GridviewScrollPager" />
                    </asp:GridView>
                    </div>




                        
    
                </asp:Panel>

                <div class="Break"></div>
                <div class="Break"></div>
                <div class="Break"></div>
            </div>
            <div class="Break"></div>
            <div class="Break"></div>
            <div class="Break"></div>
        </asp:Panel>--%>





                    <div class="div_Break"></div>

                    <!-- Modal -->
                    <%--<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>
        <div class="modal-body">
          <p>Some text in the modal.</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>--%>
                </div>
                <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                    <div class="divRoated">
                        <div class="LogHeadLbl">
                            <div class="LogHeadJob">
                                <label id="lbl_no" runat="server">Bill Of Lading #:</label>

                            </div>
                            <div class="LogHeadJobInput">

                                <asp:Label ID="JobInput" runat="server"></asp:Label>

                            </div>

                        </div>
                        <div class="DivSecPanel">
                            <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                        </div>

                        <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                            <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                                ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                BackColor="White">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="myGridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>

                        </asp:Panel>
                        <div class="Break"></div>
                    </div>


                </asp:Panel>



            </div>
        </div>
    </div>
    
    <asp:Label ID="hid1" runat="server" />

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:HiddenField ID="hdf_blno" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_buyer" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_ImpFor" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_Supplier" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_Stuff" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_consolid" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_Shipto" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_Importer" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_consignee" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_shipper" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_cha" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_Carrier" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdf_eforwarder" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hid_multimanufacturer" runat="server"></asp:HiddenField>

</asp:Content>
