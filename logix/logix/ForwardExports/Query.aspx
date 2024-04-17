<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" EnableEventValidation="false" Inherits="logix.ForwardExports.Query" %>

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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
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

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/Query.css" rel="Stylesheet" type="text/css" />
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


    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_vessel.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_vesselid.ClientID %>").val(0);
                          $.ajax({
                              url: "../ForwardExports/Query.aspx/GetVesselname",
                              //data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_Carrier').value + "'}",
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
                                  alertify.alert(response.responseText);
                              },
                              failure: function (response) {
                                  alertify.alert(response.responseText);
                              }


                          });
                      },

                      select: function (event, i) {
                          $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                       $("#<%=txt_vessel.ClientID %>").change();
                       $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                   },
                    focus: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                          $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                      },
                    change: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                          $("#<%=hf_vesselid.ClientID %>").val(i.item.val);

                      },
                    close: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                          $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                      },
                    minLength: 1
                });
            });

              $(document).ready(function () {

                  $("#<%=txt_MBLno.ClientID %>").autocomplete({

                   source: function (request, response) {
                       $("#<%=hf_mblno.ClientID %>").val(0);

                        $.ajax({
                            url: "../ForwardExports/Query.aspx/Getmblname",

                            //data: "{ 'prefix': '" + request.term + "'}",
                            data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_MBLno').value + "'}",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }


                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_MBLno.ClientID %>").val(i.item.label);
                        $("#<%=txt_MBLno.ClientID %>").change();
                        $("#<%=hf_mblno.ClientID %>").val(i.item.val);
                    },
                   focus: function (event, i) {
                       $("#<%=txt_MBLno.ClientID %>").val(i.item.label);
                        $("#<%=hf_mblno.ClientID %>").val(i.item.val);
                    },
                   change: function (event, i) {
                       $("#<%=txt_MBLno.ClientID %>").val(i.item.label);
                        $("#<%=hf_mblno.ClientID %>").val(i.item.val);

                    },
                   close: function (event, i) {
                       $("#<%=txt_MBLno.ClientID %>").val(i.item.label);
                        $("#<%=hf_mblno.ClientID %>").val(i.item.val);
                    },
                   minLength: 1
               });
           });




            $(document).ready(function () {

                $("#<%=txt_Containerno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_containerno.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getcontainerno",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }


                            });
                        },

                        select: function (event, i) {
                            $("#<%=txt_Containerno.ClientID %>").val(i.item.label);
                            $("#<%=txt_Containerno.ClientID %>").change();
                            $("#<%=hf_containerno.ClientID %>").val(i.item.val);
                        },
                    focus: function (event, i) {
                        $("#<%=txt_Containerno.ClientID %>").val(i.item.label);
                            $("#<%=hf_containerno.ClientID %>").val(i.item.val);
                        },
                    change: function (event, i) {
                        $("#<%=txt_Containerno.ClientID %>").val(i.item.label);
                            $("#<%=hf_containerno.ClientID %>").val(i.item.val);

                        },
                    close: function (event, i) {
                        $("#<%=txt_Containerno.ClientID %>").val(i.item.label);
                            $("#<%=hf_containerno.ClientID %>").val(i.item.val);
                        },
                    minLength: 1
                });
            });

                $(document).ready(function () {

                    $("#<%=txt_Shipbill.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_sbno.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getsbno",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }


                            });
                        },

                        select: function (event, i) {
                            $("#<%=txt_Shipbill.ClientID %>").val(i.item.label);
                            $("#<%=txt_Shipbill.ClientID %>").change();
                            $("#<%=hf_sbno.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Shipbill.ClientID %>").val(i.item.label);
                            $("#<%=hf_sbno.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_Shipbill.ClientID %>").val(i.item.label);
                            $("#<%=hf_sbno.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_Shipbill.ClientID %>").val(i.item.label);
                            $("#<%=hf_sbno.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });

                $(document).ready(function () {

                    $("#<%=txt_Customer.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_custid.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getcustomer",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }


                            });
                        },

                        select: function (event, i) {
                            $("#<%=txt_Customer.ClientID %>").val(i.item.label);
                            $("#<%=txt_Customer.ClientID %>").change();
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Customer.ClientID %>").val(i.item.label);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_Customer.ClientID %>").val(i.item.label);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_Customer.ClientID %>").val(i.item.label);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });


                $(document).ready(function () {

                    $("#<%=txt_Sales.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_salesid.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/GetcustSales",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }


                            });
                        },

                        select: function (event, i) {
                            $("#<%=txt_Sales.ClientID %>").val(i.item.label);
                            $("#<%=txt_Sales.ClientID %>").change();
                            $("#<%=hf_salesid.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Sales.ClientID %>").val(i.item.label);
                            $("#<%=hf_salesid.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_Sales.ClientID %>").val(i.item.label);
                            $("#<%=hf_salesid.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_Sales.ClientID %>").val(i.item.label);
                            $("#<%=hf_salesid.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });


                $(document).ready(function () {

                    $("#<%=txt_Bookingno.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_shiprefno.ClientID %>").val(0);

                        $.ajax({
                            url: "../ForwardExports/Query.aspx/Getshipref",

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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }


                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_Bookingno.ClientID %>").val(i.item.label);
                            $("#<%=txt_Bookingno.ClientID %>").change();
                            $("#<%=hf_shiprefno.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Bookingno.ClientID %>").val(i.item.label);
                        $("#<%=hf_shiprefno.ClientID %>").val(i.item.val);
                    },
                        change: function (event, i) {
                            $("#<%=txt_Bookingno.ClientID %>").val(i.item.label);
                        $("#<%=hf_shiprefno.ClientID %>").val(i.item.val);

                    },
                        close: function (event, i) {
                            $("#<%=txt_Bookingno.ClientID %>").val(i.item.label);
                        $("#<%=hf_shiprefno.ClientID %>").val(i.item.val);
                    },
                        minLength: 1
                    });
                });

            $(document).ready(function () {

                $("#<%=txt_Port.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_portid.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getportname",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }


                            });
                        },

                        select: function (event, i) {
                            $("#<%=txt_Port.ClientID %>").val(i.item.label);
                            $("#<%=txt_Port.ClientID %>").change();
                            $("#<%=hf_portid.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Port.ClientID %>").val(i.item.label);
                            $("#<%=hf_portid.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_Port.ClientID %>").val(i.item.label);
                            $("#<%=hf_portid.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_Port.ClientID %>").val(i.item.label);
                            $("#<%=hf_portid.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });

                $(document).ready(function () {

                    $("#<%=txt_consignee.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_consigneeid.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getcustomer",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }


                            });
                        },

                        select: function (event, i) {
                            $("#<%=txt_consignee.ClientID %>").val(i.item.label);
                            $("#<%=txt_consignee.ClientID %>").change();
                            $("#<%=hf_consigneeid.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_consignee.ClientID %>").val(i.item.label);
                            $("#<%=hf_consigneeid.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_consignee.ClientID %>").val(i.item.label);
                            $("#<%=hf_consigneeid.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_consignee.ClientID %>").val(i.item.label);
                            $("#<%=hf_consigneeid.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });

                $(document).ready(function () {

                    $("#<%=txt_bl.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_blno.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getblno",

                                data: "{ 'prefix': '" + request.term + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {

                                    response($.map(data.d, function (item) {

                                        return {
                                            label: item

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

                        select: function (event, i) {
                            $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=txt_bl.ClientID %>").change();
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });
                $(document).ready(function () {

                    $("#<%=txt_Agent.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_custid.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getcustname",

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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }


                            });
                        },

                        select: function (event, i) {
                            $("#<%=txt_Agent.ClientID %>").val(i.item.label);
                            $("#<%=txt_Agent.ClientID %>").change();
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Agent.ClientID %>").val(i.item.label);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_Agent.ClientID %>").val(i.item.label);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_Agent.ClientID %>").val(i.item.label);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });

                <%--$(document).ready(function () {

                    $("#<%=txt_FBL.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_blno.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/Getbl",

                                data: "{ 'prefix': '" + request.term + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {

                                    response($.map(data.d, function (item) {

                                        return {
                                            label: item

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

                        select: function (event, i) {
                            $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=txt_FBL.ClientID %>").change();
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });--%>

            $(document).ready(function () {

                $("#<%=txt_FBL.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_fbl.ClientID %>").val(0);

                         $.ajax({
                             url: "../ForwardExports/Query.aspx/Getbl",

                             data: "{ 'prefix': '" + request.term + "'}",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             success: function (data) {

                                 response($.map(data.d, function (item) {

                                     return {
                                         label: item

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

                     select: function (event, i) {
                         $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=txt_FBL.ClientID %>").change();
                            $("#<%=hf_fbl.ClientID %>").val(i.item.val);
                        },
                    focus: function (event, i) {
                        $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=hf_fbl.ClientID %>").val(i.item.val);
                        },
                    change: function (event, i) {
                        $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=hf_fbl.ClientID %>").val(i.item.val);

                        },
                    close: function (event, i) {
                        $("#<%=txt_FBL.ClientID %>").val(i.item.label);
                            $("#<%=hf_fbl.ClientID %>").val(i.item.val);
                        },
                    minLength: 1
                });
            });

                $(document).ready(function () {

                    $("#<%=txt_Inv.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_Inv.ClientID %>").val(0);

                            $.ajax({
                                url: "../ForwardExports/Query.aspx/GetInvNo",

                                data: "{ 'prefix': '" + request.term + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {

                                    response($.map(data.d, function (item) {

                                        return {
                                            label: item

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

                        select: function (event, i) {
                            $("#<%=txt_Inv.ClientID %>").val(i.item.label);
                            $("#<%=txt_Inv.ClientID %>").change();
                            $("#<%=hf_Inv.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Inv.ClientID %>").val(i.item.label);
                            $("#<%=hf_Inv.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_Inv.ClientID %>").val(i.item.label);
                            $("#<%=hf_Inv.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_Inv.ClientID %>").val(i.item.label);
                            $("#<%=hf_Inv.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });
            }
    </script>




    <%--     <script type="text/javascript">

         function pageLoad(sender, args) {
            

             $(document).ready(function () {
                 $("#<%=txt_vessel.ClientID %>").autocomplete({
                         source: function (request, response) {
                             $("#<%=hf_vesselid.ClientID %>").val(0);
                    $.ajax({
                        url: "../ForwardExports/Query.aspx/GetVesselname",
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
                    $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                    $("#<%=txt_vessel.ClientID %>").change();
                    $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                    $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                },
                change: function (event, i) {
                    $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                    $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                },
                close: function (event, i) {
                    $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                    $("#<%=hf_vesselid.ClientID %>").val(i.item.val);
                },
               
                minLength: 1
            });
                 });
         }
        </script>--%>

    <style type="text/css">
    
        .BLTab1 {
    width: 100%;
}
    </style>

    <style type="text/css">
      

        .div_popupview {
            float: left;
            width: 99%;
            height: 100%;
            background-color: White;
        }

        iframe {
            overflow: hidden;
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

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
       
      ul#breadcrumbs {
    margin-bottom: 0px;
    padding: 5px 30px !important;
    background: none;
}
      .crumbslbl {
    display: block;
    position: relative;
    top: -10px;
}
      .widget.box .widget-content {
    top: -20px;
}
      a#logix_CPH_headerlableid1, a#logix_CPH_headerlable1 {
    color: #000;
}
      .MBLInput2 {
    width: 17.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
      .VesselInput2 {
    width: 28%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
      .VoyageInput2 {
    width: 17.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
  div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 50px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    

    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Query"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs" id="crumbslbl" runat="server">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="" id="headerlableid1" runat="server">Customer Support</a> </li>
            <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>
            <li class="current"><a href="#" title="">Query</a> </li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px; position: relative;top: -30px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons">
    <div class="right_btn">
        <div class="btn ico-find" id="btn_find1" runat="server">
            <asp:Button ID="btn_find" runat="server" Text="Find" ToolTip="Find" OnClick="btn_find_Click" />
        </div>
        <div class="btn ico-cancel"  id="idback" runat="server"  visible="false" >
            <asp:Button ID="Btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="Btn_back_Click" Visible="false" />
        </div>
    </div>
</div>

                </div>
                <div class="widget-content">
                          <%--row1--%>
                    
                    <div class="FormGroupContent4">
                          <div class="JboNoInput">
                            <asp:Label ID="Label1" runat="server" Text="Job #"> </asp:Label>
                            <asp:TextBox ID="txt_jobno" runat="server" CssClass="form-control" placeholder="" ToolTip="Job Number"></asp:TextBox>
                        </div>
                         <div class="MBLInput2">
                            <asp:Label ID="Label9" runat="server" Text="Booking #"> </asp:Label>
                            <asp:TextBox ID="txt_Bookingno" runat="server" CssClass="form-control" placeholder="" ToolTip="Booking NUMBER"></asp:TextBox>
                        </div>
                         <div class="MBLInput2">
                            <asp:Label ID="Label13" runat="server" Text="BL #"> </asp:Label>
                            <asp:TextBox ID="txt_bl" runat="server" CssClass="form-control" placeholder="" ToolTip="BL Number"></asp:TextBox>
                        </div>
                            <div class="MBLInput2">
                            <asp:Label ID="Label5" runat="server" Text="MBL #"> </asp:Label>
                            <asp:TextBox ID="txt_MBLno" runat="server" CssClass="form-control" placeholder="" ToolTip="MBL Number"></asp:TextBox>
                        </div>
                          <div class="MBLInput2">
                            <asp:Label ID="Label18" runat="server" Text="Forwarder BL #"> </asp:Label>
                            <asp:TextBox ID="txt_FBL" runat="server" CssClass="form-control" placeholder="" ToolTip="Forwarder BL Number"></asp:TextBox>
                        </div>
                          <div class="ShippingInput2" style="width: 17.5%;" >
                            <asp:Label ID="Label7" runat="server" Text="Shipping Bill #"> </asp:Label>
                            <asp:TextBox ID="txt_Shipbill" runat="server" CssClass="form-control" placeholder="" ToolTip="Shipping Bill Number"></asp:TextBox>
                        </div>
                    </div>
                    <%--row2--%>
                    <div class="FormGroupContent4">
                           <div class="VesselInput2">
                            <asp:Label ID="Label2" runat="server" Text="Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" placeholder="" ToolTip="Vessel"></asp:TextBox>
                        </div>
                        <div class="VoyageInput2">
                            <asp:Label ID="Label3" runat="server" Text="Voyage"> </asp:Label>
                            <asp:TextBox ID="txt_voyage" runat="server" CssClass="form-control" placeholder="" ToolTip="Voyage"></asp:TextBox>
                        </div>
                    
                        <div class="ContainerInput2" style="width: 17.5%;" >
                            <asp:Label ID="Label6" runat="server" Text="Container #"> </asp:Label>
                            <asp:TextBox ID="txt_Containerno" runat="server" CssClass="form-control" placeholder="" ToolTip="Container Number"></asp:TextBox>
                        </div>
                          <div class="ContainerInput2" style="width: 17.3%;" >
                            <asp:Label ID="Label19" runat="server" Text="Seal #"> </asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="" ToolTip="Seal Number"></asp:TextBox>
                        </div>
                         <div class="ShippingInput2" style="width: 17.6%;" >
                            <asp:Label ID="Label11" runat="server" Text="PoL"> </asp:Label>
                            <asp:TextBox ID="txt_Port" runat="server" CssClass="form-control" placeholder="" ToolTip="PoL"></asp:TextBox>
                        </div>
                    </div>
                     <%--row3--%>
              
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ContainerInput2" style="width: 46%;" >
                            <asp:Label ID="Label10" runat="server" Text="Sales person"> </asp:Label>
                            <asp:TextBox ID="txt_Sales" runat="server" CssClass="form-control" placeholder="" ToolTip="Sales person"></asp:TextBox>
                        </div>
                          <div class="CHAInput" style="width: 53.4%;margin-right: 0px;">
                            <asp:Label ID="Label8" runat="server" Text="Customer [CHA / Forwarder - Quotation Customer]"> </asp:Label>
                            <asp:TextBox ID="txt_Customer" runat="server" CssClass="form-control" placeholder="" ToolTip="Customer [CHA / Forwarder - Quotation Customer]"></asp:TextBox>
                        </div>
                     
                      

                    </div>
                      <%--row4--%>
                    <div class="FormGroupContent4 boxmodal">
                      
                         <div class="CHAInput" style="width: 46%;" >
                            <asp:Label ID="Label12" runat="server" Text="Consignee"> </asp:Label>
                            <asp:TextBox ID="txt_consignee" runat="server" CssClass="form-control" placeholder="" ToolTip="Consignee"></asp:TextBox>
                        </div>
                         <div class="CHAInput" style="width: 53.5%;margin-right: 0px;" >
                            <asp:Label ID="Label17" runat="server" Text="Delivery Agent"> </asp:Label>
                            <asp:TextBox ID="txt_Agent" runat="server" CssClass="form-control" placeholder="" ToolTip="Delivery Agent"></asp:TextBox>
                        </div>
                      
                      
                       
                    </div>

                     <%--row5--%>
                    
                    <div class="FormGroupContent4">
                        
                        <div class="CBMInput">
                            <asp:Label ID="Label14" runat="server" Text="CBM"> </asp:Label>
                            <asp:TextBox ID="txt_cbm" runat="server" CssClass="form-control" placeholder="" ToolTip="CBM"></asp:TextBox>
                        </div>
                         <div class="GrossWT">
                            <asp:Label ID="Label15" runat="server" Text="Gross Wt."> </asp:Label>
                            <asp:TextBox ID="txt_grwt" runat="server" CssClass="form-control" placeholder="" ToolTip="Gross Weight"></asp:TextBox>
                        </div>
                        <div class="ShippingInput2" style="margin-right: 0.5%;">
                            <asp:Label ID="Label16" runat="server" Text="No.of Pkgs"> </asp:Label>
                            <asp:TextBox ID="txt_noofpkg" runat="server" CssClass="form-control" placeholder="" ToolTip="No.of Packages"></asp:TextBox>
                        </div>
                            <div class="ShippingInput2" style="float: right;" >
                            <asp:Label ID="Label20" runat="server" Text="Vendor Ref #"> </asp:Label>
                            <asp:TextBox ID="txt_Inv" runat="server" CssClass="form-control" placeholder="" ToolTip="Vendor Ref Number"></asp:TextBox>
                        </div>
                    </div>
                  
                    </div>
                   
                    <div class="FormGroupContent4  boxmodal">
                        <asp:Panel ID="pnl_grd1" runat="server" Width="100%" Height="100%" CssClass="panel_08 MB0">
                            <asp:GridView ID="grd" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Grid FixedHeader" 
                                OnRowDataBound="grd_RowDataBound"
                                OnSelectedIndexChanged="grd_SelectedIndexChanged">
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_grd2" runat="server" CssClass="modalPopup" Width="100%" Height="100%" Style="display:none;">
                            <div class="divRoated">
                            <div class="DivSecPanel">
                                <asp:Image ID="Close_voucher" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>
                            <div class="">
                                <iframe id="iframe_BLPrint" runat="server" src="" frameborder="0" width="100%"
                                    height="100%" backgroundcssclass="modalBackground"></iframe>
                            </div>
                          </div>
                        </asp:Panel>
                    </div>

                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Job # :</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                                <asp:GridView ID="GridViewlog" CssClass="Gird FixedHeader" runat="server" AutoGenerateColumns="true"
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

                    <asp:ModalPopupExtender ID="modal_view" runat="server" PopupControlID="pnl_grd2"
                        TargetControlID="hid1" CancelControlID="Close_voucher">
                    </asp:ModalPopupExtender>

                    <asp:Label ID="Label4" runat="server"></asp:Label>

                    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
                        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
                    </asp:ModalPopupExtender>

                    <div>
                        <asp:Label ID="hid1" runat="server" />
                        <%--<asp:HiddenField ID="hf_hidid1" runat="server" />--%>
                        <asp:HiddenField ID="hf_vesselid" runat="server" />
                        <asp:HiddenField ID="hf_mblno" runat="server" />
                        <asp:HiddenField ID="hf_sbno" runat="server" />
                        <asp:HiddenField ID="hf_containerno" runat="server" />
                        <asp:HiddenField ID="hf_consigneeid" runat="server" />
                        <asp:HiddenField ID="hf_custid" runat="server" />
                        <asp:HiddenField ID="hf_shiprefno" runat="server" />
                        <asp:HiddenField ID="hf_portid" runat="server" />
                        <asp:HiddenField ID="hf_blno" runat="server" />
                        <asp:HiddenField ID="hf_salesid" runat="server" />
                        <asp:HiddenField ID="hf_Inv" runat="server" />
                        <asp:HiddenField ID="hf_fbl" runat="server" />
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
