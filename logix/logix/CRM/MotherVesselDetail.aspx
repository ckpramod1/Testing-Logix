<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MotherVesselDetail.aspx.cs" Inherits="logix.CRM.MotherVesselDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css">
    <link href="../Styles/DropDownButton.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <!--=== JavaScript ===-->
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <!-- <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script> -->

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
    <link href="../Styles/AEJobInfo.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>


    <%--TEST--%>
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
 <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />












    <link href="../Styles/StuffingConfirmation.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function pageLoad(sender, args) {



            $(document).ready(function () {
                $("#<%=txt_book.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MotherVesselDetail.aspx/GETBookingtrans",
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
                        $("#<%=txt_book.ClientID %>").val(i.item.label);
                        $("#<%=txt_book.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_book.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        $("#<%=txt_book.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_agent.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $("#<%=hd_customer.ClientID %>").val(0);
                            $.ajax({
                                url: "MotherVesselDetail.aspx/GETCustomer",
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
                                    //alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    //alertify.alert(response.responseText);
                                }
                            });
                        },
                        change: function (e, i) {
                            $("#<%=hd_customer.ClientID %>").val(i.item.val);
                            $("#<%=txt_agent.ClientID %>").val(i.item.text);


                        },
                        close: function (e, i) {
                            var result = $("#<%=txt_agent.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txt_agent.ClientID %>").val($.trim(result));
                        },
                        minLength: 1
                    });
                });

            $(document).ready(function () {
                $("#<%=txt_sb.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "MotherVesselDetail.aspx/GETShipbill",
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
                            $("#<%=txt_sb.ClientID %>").val(i.item.label);
                            $("#<%=txt_sb.ClientID %>").change();
                            $("#<%=hd_shipbill.ClientID %>").val(i.item.val);
                        },
                        change: function (e, i) {
                            $("#<%=txt_sb.ClientID %>").val(i.item.val);
                            $("#<%=txt_sb.ClientID %>").val(i.item.text);


                        },
                        focus: function (event, i) {
                            $("#<%=txt_sb.ClientID %>").val(i.item.label);
                            $("#<%=hd_shipbill.ClientID %>").val(i.item.val);
                        },
                        close: function (event, i) {
                            $("#<%=txt_sb.ClientID %>").val(i.item.label);
                            $("#<%=hd_shipbill.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });

            $(document).ready(function () {
                $("#<%=txt_pkgtype.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $("#<%=hd_package.ClientID %>").val(0);
                            $.ajax({
                                url: "MotherVesselDetail.aspx/Getpackage",
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
                            $("#<%=txt_pkgtype.ClientID %>").val(i.item.label);
                            $("#<%=txt_pkgtype.ClientID %>").change();
                            $("#<%=hd_package.ClientID %>").val(i.item.val);

                        },
                        change: function (e, i) {
                            $("#<%=hd_package.ClientID %>").val(i.item.val);
                            $("#<%=txt_pkgtype.ClientID %>").val(i.item.text);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_pkgtype.ClientID %>").val(i.item.label);
                            $("#<%=hd_package.ClientID %>").val(i.item.val);
                        },
                        close: function (event, i) {
                            $("#<%=txt_pkgtype.ClientID %>").val(i.item.label);
                            $("#<%=hd_package.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });

            $(document).ready(function () {
                $("#<%=txt_exporter.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $("#<%=hd_exporter.ClientID %>").val(0);
                            $.ajax({
                                url: "MotherVesselDetail.aspx/Getexporter",
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
                            $("#<%=txt_exporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=txt_exporter.ClientID %>").change();
                             $("#<%=hd_exporter.ClientID %>").val(i.item.val);
                        },
                        change: function (e, i) {
                            $("#<%=txt_exporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hd_exporter.ClientID %>").val(i.item.val);

                        },
                        focus: function (event, i) {
                            $("#<%=txt_exporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hd_exporter.ClientID %>").val(i.item.val);
                        },
                        close: function (event, i) {

                            var result = $("#<%=txt_exporter.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txt_exporter.ClientID %>").val($.trim(result));
                        },
                        minLength: 1
                    });
                });


            $(document).ready(function () {
                $("#<%=txt_dest.ClientID %>").autocomplete({
                         source: function (request, response) {
                             $("#<%=hd_exporter.ClientID %>").val(0);
                             $.ajax({
                                 url: "MotherVesselDetail.aspx/Getportname",
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
                     <%--  select: function (event, i) {
                         $("#<%=txt_dest.ClientID %>").val(i.item.label);
                         $("#<%=txt_dest.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=txt_dest.ClientID %>").val(i.item.label);
                         $("#<%=hd_dest.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txt_dest.ClientID %>").val(i.item.label);
                         $("#<%=hd_dest.ClientID %>").val(i.item.val);
                     },--%>
                         select: function (event, i) {
                             $("#<%=txt_dest.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=txt_dest.ClientID %>").change();
                             $("#<%=hd_dest.ClientID %>").val(i.item.val);
                         },
                         focus: function (event, i) {
                             $("#<%=txt_dest.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hd_dest.ClientID %>").val(i.item.val);
                         },
                         change: function (event, i) {
                             if (i.item) {
                                 $("#<%=txt_dest.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                 $("#<%=hd_dest.ClientID %>").val(i.item.val);
                             }
                         },
                         close: function (event, i) {
                             var result = $("#<%=txt_dest.ClientID %>").val().toString().split(',')[0];
                             $("#<%=txt_dest.ClientID %>").val($.trim(result));
                         },
                         minLength: 1
                     });
                 });

            $(document).ready(function () {
                $("#<%=txt_mvessel.ClientID %>").autocomplete({
                         source: function (request, response) {
                             $("#<%=hd_mastervessel.ClientID %>").val(0);
                             $.ajax({
                                 url: "MotherVesselDetail.aspx/Getmastervessel",
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
                             $("#<%=txt_mvessel.ClientID %>").val(i.item.label);
                         $("#<%=txt_mvessel.ClientID %>").change();
                         $("#<%=hd_mastervessel.ClientID %>").val(i.item.val);
                         },
                         focus: function (event, i) {
                             $("#<%=txt_mvessel.ClientID %>").val(i.item.label);
                            $("#<%=hd_mastervessel.ClientID %>").val(i.item.val);
                         },
                         close: function (event, i) {
                             $("#<%=txt_mvessel.ClientID %>").val(i.item.label);
                            $("#<%=hd_mastervessel.ClientID %>").val(i.item.val);
                         },
                         minLength: 1
                     });
                 });

            $(document).ready(function () {
                $("#<%=txtpol.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $("#<%=hd_portname.ClientID %>").val(0);
                         $.ajax({
                             url: "MotherVesselDetail.aspx/Getportname",
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
                     <%-- select: function (event, i) {
                         $("#<%=txtpol.ClientID %>").val(i.item.label);
                         $("#<%=txtpol.ClientID %>").change();
                         $("#<%=hd_portname.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txtpol.ClientID %>").val(i.item.label);
                         $("#<%=hd_portname.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txtpol.ClientID %>").val(i.item.label);
                         $("#<%=hd_portname.ClientID %>").val(i.item.val);
                     },--%>
                     select: function (event, i) {
                         $("#<%=txtpol.ClientID %>").val(i.item.label);
                         $("#<%=txtpol.ClientID %>").change();
                         $("#<%=hd_portname.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txtpol.ClientID %>").val(i.item.label);
                         $("#<%=hd_portname.ClientID %>").val(i.item.val);
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtpol.ClientID %>").val(i.item.label);
                             $("#<%=hd_portname.ClientID %>").val(i.item.val);
                         }
                     },
                     close: function (event, i) {
                         var result = $("#<%=txtpol.ClientID %>").val(i.item.label);
                         $("#<%=txtpol.ClientID %>").val($.trim(result));
                     },
                     minLength: 1
                 });
             });

            $(document).ready(function () {
                $("#<%=txtpod.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $("#<%=hd_port.ClientID %>").val(0);
                         $.ajax({
                             url: "MotherVesselDetail.aspx/Getportname",
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
                     <%-- select: function (event, i) {
                         $("#<%=txtpod.ClientID %>").val(i.item.label);
                         $("#<%=txtpod.ClientID %>").change();
                         $("#<%=hd_port.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txtpod.ClientID %>").val(i.item.label);
                         $("#<%=hd_port.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txtpod.ClientID %>").val(i.item.label);
                         $("#<%=hd_port.ClientID %>").val(i.item.val);
                     },--%>
                     select: function (event, i) {
                         $("#<%=txtpod.ClientID %>").val(i.item.label);
                         $("#<%=txtpod.ClientID %>").change();
                         $("#<%=hd_port.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txtpod.ClientID %>").val(i.item.label);
                         $("#<%=hd_port.ClientID %>").val(i.item.val);
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtpod.ClientID %>").val(i.item.label);
                             $("#<%=hd_port.ClientID %>").val(i.item.val);
                         }
                     },
                     close: function (event, i) {
                         var result = $("#<%=txtpod.ClientID %>").val(i.item.label);
                         $("#<%=txtpod.ClientID %>").val($.trim(result));
                     },
                     minLength: 1
                 });
             });

            $(document).ready(function () {
                $("#<%=txt_customer.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "MotherVesselDetail.aspx/CMailID",
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
                         $("#<%=txt_customer.ClientID %>").val(i.item.label);
                         $("#<%=txt_customer.ClientID %>").change();

                     },
                     focus: function (event, i) {
                         $("#<%=txt_customer.ClientID %>").val(i.item.label);
                         $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txt_customer.ClientID %>").val(i.item.label);
                         $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });




            $(document).ready(function () {
                $("#<%=txt_intermail.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "MotherVesselDetail.aspx/Getintermail",
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
                         $("#<%=txt_intermail.ClientID %>").val(i.item.label);
                         $("#<%=txt_intermail.ClientID %>").change();

                     },
                     focus: function (event, i) {
                         $("#<%=txt_intermail.ClientID %>").val(i.item.label);
                         $("#<%=hd_intermail.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txt_intermail.ClientID %>").val(i.item.label);
                         $("#<%=hd_intermail.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });

            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'

            });
            //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>


    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you Want to delete this Details?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>


    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

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

        .GridHeader2 {
            background-color: Navy;
            color: White;
            font-family: sans-serif;
            font-size: 8pt;
            margin-left: 4px;
            margin-bottom: 0px;
            padding: 2px;
        }

        .Hide {
            display: none;
        }

        #programmaticModalPopupBehaviordf1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #programmaticModalPopupBehaviordf_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            /* width: 1062px; */
            width: 97.8%;
            Height: 525px;
            margin-left: 0%;
            margin-top: -1.9%;
        }











        .RemarksInput2 {
            width: 87.7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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

        .FVesselInput1 {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .POLInput1 {
            width: 23%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ETDInput {
            width: 10.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PODInput2 {
            width: 27.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ETAInput1 {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ConteinerLabel {
            margin: 0px 0px 0px 8px;
        }

        element.style {
            overflow-y: scroll;
        }

        .check {
            width: 100%;
            float: left;
            border: 0px solid var(--inputborder) !important;
            border-radius: 3px;
            margin: 10px 0 0;
            height: 128px;
            background: white;
            overflow: auto !important;
            padding: 0px 5px 0;
            border-bottom: 1px solid var(--inputborder) !important;
        }

        span#logix_CPH_lbl_container {
            font-size: 10px;
            color: rgb(6, 82, 156);
            font-weight: 500 !important;
        }

        .div_Grid {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 1%;
            margin-top: 0.6%;
            height: 127px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow: auto;
        }

        .InvoicePakaging {
            width: 33%;
            float: left;
            margin: 15px 0px 0px 0px;
            color: #000080;
        }

        .MT15 {
            margin: 5px 0px 0px 0px;
        }


        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .BookingNoNew {
            width: 84%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .FormGroup2 {
            width: 15.5%;
            float: left;
            margin: -46PX 0PX 0PX 0PX;
        }

        .BillType1 {
            width: 19.6%;
            float: left;
            margin: 0px 0% 0px 0.5%;
        }

        div#logix_CPH_ddl_Vessal_chzn {
            width: 100% !important;
        }

        .formleft {
            width: 84.5%;
            float: left;
            margin: 0px 3px 0px 0px;
            display: none;
        }

        .formright {
            width: 15.2%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .CalDisable {
            width: 15.5%;
            float: left;
            margin: 0px 0.5% 0px 13%;
            display: flex;
        }

        .Agent {
            float: left;
            width: 100%;
            /*margin-right: 0.5% !important;*/
        }

        .JboInput1 {
            width: 58%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FormGroup1 {
            width: 100%;
            float: left;
            border-right: 0px;
            padding: 0px 5px 0px 0px;
            margin: 0px 0.5% 0px 0px;
        }

        .FormBoxLeft {
            width: 61.3%;
            float: left;
            padding: 0px 0px 0px 0px;
            margin-right: 0.5% !important;
        }

        .MVesselInputN2 {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .POYInputN1 {
            width: 23.3%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .FormBoxRight {
            width: 38.2%;
            float: left;
            margin: 0px;
        }

        .SBInput {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SBCal {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PkgsInput {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PkgType1 {
            width: 18.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .WeightInput {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VolumeInput1 {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DestinationInput {
            width: 13.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .RemarksField {
            width: 54.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .ExporterInput {
            width: 45%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PoL {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ETD {
            width: 19.25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PoD {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ETA {
            float: left;
            margin: 0px 0px 0px 0px;
            width: 17%;
        }

        .btnwidth {
            float: left;
            width: 24px !important;
        }

        .MovementInput {
            width: 40.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FDInput {
            width: 43.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .CalNews {
            width: 15.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .NewsRemarks {
            width: 100%;
            float: left;
        }

        .MailInput {
            width: 51%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .NewsInput {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .bordertopNew1 {
            float: left;
            min-height: 1px;
            margin: 5px 0px 5px 0px;
            border-top: 1px dotted #807f7f;
            width: 100%;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }




        .GridLeft {
            width: 99.5%;
            float: left;
            margin-right: 0.5% !important;
        }

        .GridRight {
            width: 100%;
            float: left;
        }

        .Grid th {
            border-right: 1px solid #fff !important;
        }

        .d_o_date {
            float: left;
        }

        table#logix_CPH_Grd_sb {
            border: none;
        }


        .PanelMail {
            width: 51.5%;
            float: left;
            display: none;
        }

        .widget-content {
            width: 100%;
        }

        .div_right {
            width: 29.9% !important;
            float: left;
        }

        .div_left {
            width: 75%;
            float: left;
            margin: 0px 0.5% 0px 0px
        }

        table#logix_CPH_chklst {
            border: 0px;
        }

            table#logix_CPH_chklst tr {
                background: none !important;
            }


        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 0px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <%--   <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Customer Support</a> </li>
                                <li><a href="#" title="">Ocean Exports</a> </li>
                                <li class="current"><a href="#" title="" id="headerlabel" runat="server"></a></li>
                            </ul>
                        </div>--%>
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <%--row1--%>

                    <div class="FormGroupContent4">
                        <div class="right_btn">
                            <div class="btn ico-update">
                                <asp:Button ID="btnupdate" runat="server" Text="Update" ToolTip="Update" TabIndex="40" Visible="false" OnClick="btnupdate_Click" />


                            </div>
                            <div class="btn ico-send" id="btn_send1" runat="server">
                                <asp:Button ID="btn_send" runat="server" Text="Send" ToolTip="Send" TabIndex="41" Visible="false" OnClick="btn_send_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="left_btn">
                            <div class="JboInput1">
                                <span>Job #</span>
                                <asp:TextBox ID="txt_job" runat="server" CssClass="ui-accordion form-control" TabIndex="1" onkeypress="return isNumberKey(event,'JOBNO');" AutoPostBack="true" OnTextChanged="txt_job_TextChanged1" placeholder="" ToolTip="JOB Number" Style="font-family: sans-serif; font-size: 10pt;"></asp:TextBox>
                            </div>
                            <asp:LinkButton ID="lnk_job" runat="server" CssClass="anc ico-find-sm" OnClick="lnk_job_Click" Visible="false">J</asp:LinkButton>
                        </div>

                        <div class="right_btn">
                            <div class="BookingNoNew">
                                <%-- <span>Booking #</span>--%>

                                <asp:TextBox ID="txt_book" runat="server" TabIndex="7" CssClass="form-control" OnTextChanged="txt_book_TextChanged" AutoPostBack="true" placeholder="" ToolTip="Booking Number" Visible="false"></asp:TextBox>
                            </div>
                            <asp:LinkButton ID="lnkBooking" runat="server" CssClass="anc ico-find-sm" Style="text-decoration: none; color: Red;" OnClick="lnkBooking_Click" Visible="false"></asp:LinkButton>

                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">

                        <div class="FVesselInput1">
                            <asp:Label ID="Label5" runat="server" Text="F.Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" placeholder="" ToolTip="F.Vessel" TabIndex="2"></asp:TextBox>
                        </div>
                        <div class="POLInput1">
                            <asp:Label ID="Label6" runat="server" Text="PoL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" placeholder="" ToolTip="Port of Loading" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="ETDInput">
                            <asp:Label ID="Label7" runat="server" Text="ETD"> </asp:Label>
                            <asp:TextBox ID="txt_etd" runat="server" CssClass="form-control" placeholder="" ToolTip="ETD" TabIndex="4"></asp:TextBox>
                        </div>
                        <div class="PODInput2">
                            <asp:Label ID="Label8" runat="server" Text="PoD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" placeholder="" ToolTip="Port of Discharge" TabIndex="5"></asp:TextBox>
                        </div>
                        <div class="ETAInput1">
                            <asp:Label ID="Label9" runat="server" Text="ETA"> </asp:Label>
                            <asp:TextBox ID="txt_eta" runat="server" CssClass="form-control" placeholder="" ToolTip="ETA" TabIndex="6"></asp:TextBox>
                        </div>

                    </div>

                    <div class="FormGroupContent4">

                        <div class="Agent boxmodal">
                            <div class="FormGroupContent4">
                                <asp:Label ID="Label10" runat="server" Text="Agent" Visible="false"> </asp:Label>
                                <asp:TextBox ID="txt_agent" runat="server" TabIndex="8" CssClass="form-control" OnTextChanged="txt_agent_TextChanged" AutoPostBack="true" Visible="false" placeholder="" ToolTip="Agent" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="CalDisable boxmodal">
                            <div class="FormGroupContent4">
                                <div class="d_o_date DateR hide">
                                    <asp:Label ID="Label20" runat="server" Text="D.O DATE" Visible="false"> </asp:Label>
                                    <asp:TextBox ID="txt_dodate" TabIndex="9" runat="server" CssClass="form-control" ToolTip="D.O DATE" Visible="false"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txt_dodate_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_dodate" />
                                </div>
                            </div>
                            <div class="right_btn hide">
                                <div class="btnheight btn btn-update1  MT15">
                                    <asp:Button ID="btn_update" runat="server" ToolTip="Update" TabIndex="10" Enabled="false" OnClick="btn_update_Click" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="bordertopNew"></div>
                    <div>













                        <div class="MVesselInputN2">
                            <asp:Label ID="Label21" runat="server" Text="Mother Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_mvessel" runat="server" TabIndex="25" CssClass="form-control" OnTextChanged="txt_mvessel_TextChanged" AutoPostBack="True" placeholder="" ToolTip="Mother Vessel"></asp:TextBox>
                        </div>
                        <div class="POYInputN1">
                            <asp:Label ID="Label22" runat="server" Text="Voyage"> </asp:Label>
                            <asp:TextBox ID="txt_voy" runat="server" TabIndex="26" CssClass="form-control" placeholder="" ToolTip="Voyage"></asp:TextBox>
                        </div>
                        <div class="BillType1">
                            <span>Booking</span>
                            <asp:DropDownList ID="ddl_Vessal" ToolTip="" runat="server" placeholder="" CssClass="chzn-select" Width="100%" data-placeholder="ddl_Vessal" TabIndex="3" Height="21px">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>





                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="div_left">
                            <div class="FormGroupContent4">
                            </div>
                            <div class="FormGroupContent4">
                                <div class="PoL">
                                    <asp:Label ID="Label23" runat="server" Text="PoL"> </asp:Label>
                                    <asp:TextBox ID="txtpol" runat="server" TabIndex="27" CssClass="form-control" OnTextChanged="txtpol_TextChanged" AutoPostBack="true" placeholder="" ToolTip="Port of Loading"></asp:TextBox>
                                </div>
                                <div class="ETD">
                                    <asp:Label ID="Label24" runat="server" Text="ETD"> </asp:Label>
                                    <asp:TextBox ID="txtetd" runat="server" TabIndex="28" CssClass="form-control" placeholder="" ToolTip="ETD"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtetd_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtetd" />


                                </div>
                                <div class="PoD">
                                    <asp:Label ID="Label25" runat="server" Text="PoD"> </asp:Label>
                                    <asp:TextBox ID="txtpod" runat="server" TabIndex="29" CssClass="form-control" OnTextChanged="txtpod_TextChanged" placeholder="" AutoPostBack="true" ToolTip="Port of Discharge"></asp:TextBox>

                                </div>
                                <div class="ETA">
                                    <asp:Label ID="Label26" runat="server" Text="ETA"> </asp:Label>
                                    <asp:TextBox ID="txteta" runat="server" TabIndex="30" CssClass="form-control" placeholder="" ToolTip="ETA"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txteta_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txteta" />


                                </div>
                                <div class="btnwidth">
                                    <div class="right-btn btn ico-add MT15" id="btn_add1" runat="server">
                                        <asp:Button ID="btn_add" runat="server" Text="Add" ToolTip="Add" TabIndex="32" OnClick="btn_add_Click" />
                                    </div>
                                </div>

                            </div>
                            <div class="FormGroupContent4">
                                <div class="RemarksInput2">
                                    <asp:Label ID="Label27" runat="server" Text="Remarks" Visible="false"> </asp:Label>
                                    <asp:TextBox ID="txtremarks" runat="server" TabIndex="31" CssClass="form-control" Visible="false" placeholder="" ToolTip="Remarks"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="div_right">
                            <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="pnl_chkList" runat="server" Visible="false" ScrollBars="Vertical" CssClass="check" v>
                                    <asp:Label ID="lbl_container" runat="server" Text="Container #" Visible="false"></asp:Label>
                                    <asp:CheckBoxList ID="chklst" runat="server" Width="100%" TabIndex="33" OnSelectedIndexChanged="chklst_SelectedIndexChanged" Visible="false" BorderColor="#999997"></asp:CheckBoxList>
                                </asp:Panel>
                            </div>
                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <div class="formleft">

                            <div class="FormGroup1">

                                <div class="FormBoxLeft boxmodal">
                                    <div class="FormGroupContent4 hide">
                                        <div class="SBInput">
                                            <asp:Label ID="Label11" runat="server" Text="SB #"> </asp:Label>
                                            <asp:TextBox ID="txt_sb" runat="server" TabIndex="11" CssClass="form-control" OnTextChanged="txt_sb_TextChanged" AutoPostBack="True" placeholder="" ToolTip="SB NUMBER"></asp:TextBox>
                                        </div>
                                        <div class="SBCal">
                                            <asp:Label ID="Label12" runat="server" Text="SB Date"> </asp:Label>
                                            <asp:TextBox ID="txt_sbdate" runat="server" TabIndex="12" CssClass="form-control" ToolTip="SB Date"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txt_sbdate_CalendarExtender" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="txt_sbdate" />
                                        </div>
                                        <div class="PkgsInput">
                                            <asp:Label ID="Label13" runat="server" Text="No.of Packages"> </asp:Label>
                                            <asp:TextBox ID="txt_pkgs" runat="server" TabIndex="13" CssClass="form-control" onkeypress="return isNumberKey(event,'Packages');" placeholder="" ToolTip="Number of Packages"></asp:TextBox>
                                        </div>
                                        <div class="PkgType1">
                                            <asp:Label ID="Label14" runat="server" Text="Package Type"> </asp:Label>
                                            <asp:TextBox ID="txt_pkgtype" TabIndex="14" runat="server" CssClass="form-control" OnTextChanged="txt_pkgtype_TextChanged" AutoPostBack="true" placeholder="" ToolTip="Package Type"></asp:TextBox>
                                        </div>
                                        <div class="WeightInput">
                                            <asp:Label ID="Label15" runat="server" Text="Weight"> </asp:Label>
                                            <asp:TextBox ID="txt_weight" runat="server" TabIndex="15" CssClass="form-control" onkeypress="return isNumberKey(event,'Volume   ');" placeholder="" ToolTip="Weight"></asp:TextBox>
                                        </div>
                                        <div class="VolumeInput1">
                                            <asp:Label ID="Label16" runat="server" Text="Volume"> </asp:Label>
                                            <asp:TextBox ID="txt_volume" runat="server" TabIndex="16" CssClass="form-control" placeholder="" ToolTip="Volume"></asp:TextBox>
                                        </div>
                                        <div class="DestinationInput">
                                            <asp:Label ID="Label18" runat="server" Text="Destination"> </asp:Label>
                                            <asp:TextBox ID="txt_dest" runat="server" CssClass="form-control" TabIndex="17" OnTextChanged="txt_dest_TextChanged" AutoPostBack="true" placeholder="" ToolTip="Destination"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="FormGroupContent4 hide">

                                        <div class="ExporterInput">
                                            <asp:Label ID="Label17" runat="server" Text="Exporter"> </asp:Label>
                                            <asp:TextBox ID="txt_exporter" runat="server" TabIndex="18" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_exporter_TextChanged" placeholder="" ToolTip="Exporter"></asp:TextBox>
                                        </div>
                                        <div class="RemarksField">
                                            <asp:Label ID="Label19" runat="server" Text="Remarks"> </asp:Label>
                                            <asp:TextBox ID="txt_remarks" runat="server" TabIndex="19" CssClass="form-control" placeholder="" ToolTip="Remarks"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="InvoicePakaging hide">
                                            <span class="chktext">Invoice & Packing List</span>
                                            <center>
                                                <label class="switch">
                                                    <asp:CheckBox ID="chk_invoice" runat="server" TabIndex="20" />
                                                    <span class="slider round"></span>
                                                </label>
                                            </center>

                                        </div>


                                        <div class="DODateLabel">
                                            <asp:Label ID="Label1" runat="server" Visible="false" Text="D.O Date"></asp:Label>
                                        </div>
                                        <div class="DateInput">
                                            <asp:TextBox ID="txt_date" runat="server" TabIndex="21" CssClass="form-control" ToolTip="D.O DATE" Visible="false"></asp:TextBox>
                                        </div>
                                        <div class="GridLeft boxmodal">
                                            <asp:Panel ID="panel_save" CssClass="panel_04 MB0" runat="server">
                                                <asp:GridView ID="Grd_sb" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                                    OnSelectedIndexChanged="Grd_sb_SelectedIndexChanged" OnRowDataBound="Grd_sb_RowDataBound" runat="server" OnPreRender="Grd_sb_PreRender">

                                                    <Columns>

                                                        <asp:BoundField DataField="sbno" HeaderText="SB #">

                                                            <HeaderStyle />
                                                        </asp:BoundField>


                                                        <asp:BoundField DataField="sbdate" HeaderText="SBDate">
                                                            <HeaderStyle />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="exporter" HeaderText="Exporter">
                                                            <HeaderStyle Wrap="false" />
                                                            <ItemStyle Wrap="false" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="pld" HeaderText="POD">
                                                            <HeaderStyle />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="noofpkg" HeaderText="noofpkgs">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="descn" HeaderText="descn">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="grosswt" HeaderText="grosswt">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="volume" HeaderText="volume">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="agent" HeaderText="agent">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="remarks" HeaderText="remarks">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="invpl" HeaderText="invpl">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="shiprefno" HeaderText="sr">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="agentid" HeaderText="agentid">
                                                            <HeaderStyle CssClass="Hide" />
                                                            <ItemStyle CssClass="Hide" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="Imgsb" runat="server" CausesValidation="false" CommandName="Delete"
                                                                    ImageUrl="~/images/delete.jpg" Height="16px" OnClick="Imgsb_Click" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                    </Columns>

                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader2" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    <RowStyle CssClass="GrdRow" />

                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <div class="right_btn">
                                            <div class="btn btn-save1 hide" id="btn_save1" runat="server">
                                                <asp:Button ID="btn_save" runat="server" ToolTip="Save" TabIndex="22" OnClick="btn_save_Click" />
                                            </div>
                                            <div class="btn ico-view">
                                                <asp:Button ID="btn_view" runat="server" ToolTip="View" TabIndex="23" OnClick="btn_view_Click" />
                                            </div>
                                            <div class="btnheight btn btn-clear1  hide">
                                                <asp:Button ID="btn_clear" runat="server" ToolTip="Clear" OnClick="btn_clear_Click" />
                                            </div>

                                            <div class="btn ico-back hide" id="btn_back1" runat="server">
                                                <asp:Button ID="btn_back" runat="server" ToolTip="Back" TabIndex="24" OnClick="btn_back_Click" />
                                            </div>

                                        </div>


                                    </div>

                                </div>

                            </div>

                        </div>



                    </div>

                    <div class="FormGroupContent4">
                        <div class="PanelMail">
                            <asp:Panel ID="panel_mail" runat="server" ScrollBars="Vertical" CssClass="panel_04 MB0">
                                <asp:GridView ID="Grd_mail" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grd_mail_SelectedIndexChanged"
                                    OnRowDataBound="Grd_mail_RowDataBound" Width="100%" CssClass="Grid FixedHeader">
                                    <Columns>

                                        <asp:BoundField DataField="mailid" HeaderText="Customer's Mail-ID">
                                            <HeaderStyle Width="100%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" Width="15px" Height="16px" OnClick="ImageButton2_Click" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader2" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle CssClass="GrdRow" />

                                </asp:GridView>
                            </asp:Panel>
                        </div>


                        <div class="GridRight boxmodal">

                            <asp:Panel ID="panel_vessel" runat="server" CssClass="gridpnl">
                                <asp:GridView ID="Grd_vessel" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_vessel_RowDataBound"
                                    OnSelectedIndexChanged="Grd_vessel_SelectedIndexChanged" CssClass="Grid FixedHeader" OnPreRender="Grd_vessel_PreRender">
                                    <Columns>

                                        <asp:BoundField DataField="vessel" HeaderText="Vessel & voy">
                                            <HeaderStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pol" HeaderText="PoL">
                                            <HeaderStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="etd" HeaderText="ETD">
                                            <HeaderStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pod" HeaderText="PoD">
                                            <HeaderStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="eta" HeaderText="ETA">
                                            <HeaderStyle />
                                        </asp:BoundField>








                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle Width="20px" />
                                            <ItemTemplate>
                                                <div class="btn ico-delete" id="btn_delete" runat="server">
                                                    <asp:Button ID="btndelete" runat="server" Text="Send" ToolTip="Delete" TabIndex="41" OnClick="btndelete_Click" />
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>












                                        <asp:BoundField DataField="bookingno" HeaderText="bookingno">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="voyage" HeaderText="voyage">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vessalid" HeaderText="vessalid">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>


                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader2" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle CssClass="GrdRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="GridLeft boxmodal">
                            <div class="FormGroupContent4 hide">
                                <div class="TXTCustomerInput1">
                                    <asp:Label ID="Label28" runat="server" Text="Customer Mail-ID's"> </asp:Label>
                                    <asp:TextBox ID="txt_customer" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Customer Mail-ID's" OnTextChanged="txt_customer_TextChanged1"></asp:TextBox>
                                </div>
                                <asp:Button ID="btn_mail" runat="server" Text="+" CssClass="Button" OnClick="btn_mail_Click" Style="display: none;" />
                            </div>
                        </div>
                        <div class="GridRight boxmodal">
                            <div class="FormGroupContent4 hide">
                                <div class="InternalInput">
                                    <asp:Label ID="Label29" runat="server" Text="Internal Mail-ID's"> </asp:Label>
                                    <asp:TextBox ID="txt_intermail" runat="server" CssClass="form-control" OnTextChanged="txt_intermail_TextChanged" AutoPostBack="true" placeholder="" ToolTip="Internal Mail-ID's"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 hide">
                                <asp:Panel ID="panel_intermail" runat="server" ScrollBars="Vertical" CssClass="panel_03 MB0">
                                    <asp:GridView ID="Grd_intermail" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_intermail_RowDataBound"
                                        CssClass="Grid FixedHeader">
                                        <Columns>

                                            <asp:BoundField DataField="mailid" HeaderText="Internal's Mail-ID">
                                                <HeaderStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton" runat="server" CausesValidation="false" CommandName="Delete"
                                                        ImageUrl="~/images/delete.jpg" Width="15px" Height="16px" OnClick="ImageButton_Click" />
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader2" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle CssClass="GrdRow" />

                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="GridLeft boxmodal">
                            <div class="MovementInput" style="display: none;">
                                <asp:Label ID="Label30" runat="server" Text="PoR - PoL Movement"> </asp:Label>
                                <asp:TextBox ID="txt_pormove" runat="server" TabIndex="34" CssClass="form-control" placeholder="" ToolTip="PoR - PoL Movement" MaxLength="240"></asp:TextBox>

                            </div>
                            <div class="FDInput" style="display: none;">
                                <asp:Label ID="Label31" runat="server" Text="PoD - FD Movement"> </asp:Label>
                                <asp:TextBox ID="txt_podmove" runat="server" TabIndex="35" CssClass="form-control" placeholder="" ToolTip="PoD - FD Movement" MaxLength="50"></asp:TextBox>
                            </div>
                            <div class="CalNews DateB">
                                <asp:Label ID="Label33" runat="server" Text="Follow-up Date" Visible="false"> </asp:Label>
                                <asp:TextBox ID="txt_next" runat="server" TabIndex="36" CssClass="form-control" ToolTip="Follow-up Date" Visible="false"></asp:TextBox>
                                <cc1:CalendarExtender ID="txt_next_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_next" />
                            </div>
                        </div>

                    </div>
                    <div class="FormGroupContent4">
                        <div class="NewsRemarks">
                            <asp:Label ID="Label34" runat="server" Text="Remarks" Visible="false"> </asp:Label>
                            <asp:TextBox ID="txtremark" TabIndex="37" runat="server" CssClass="form-control" placeholder="" Visible="false" ToolTip="Remarks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="GridLeft hide boxmodal" style="margin: 0 !important; width: 100%;">

                            <div class="MailInput">
                                <asp:Label ID="Label35" runat="server" Text="Mail Subject"> </asp:Label>
                                <asp:TextBox ID="txt_msub" TabIndex="38" runat="server" CssClass="form-control" placeholder="" ToolTip="Mail Subject" MaxLength="160"></asp:TextBox>
                            </div>
                            <div class="GridRight boxmodal">

                                <div class="NewsInput">
                                    <asp:Label ID="Label32" runat="server" Text="News"> </asp:Label>
                                    <asp:TextBox ID="txt_news" runat="server" TabIndex="39" CssClass="form-control" placeholder="" ToolTip="News"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>









                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="Label2" runat="server" Text="Label" Style="display: none"></asp:Label>
    <cc1:ModalPopupExtender ID="programmaticModalPopup" runat="server" BehaviorID="programmaticModalPopupBehaviordf" TargetControlID="Label2"
        CancelControlID="Image1" PopupControlID="POPUP" DropShadow="false">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="POPUP" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GrdBooking" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" AllowPaging="false" OnPageIndexChanging="GrdBooking_PageIndexChanging"
                    PageSize="18" OnRowDataBound="GrdBooking_RowDataBound" OnSelectedIndexChanged="GrdBooking_SelectedIndexChanged" Width="100%">
                    <Columns>

                        <asp:TemplateField HeaderText="Booking">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                    <asp:Label ID="Booking" runat="server" Text='<%# Bind("bookingno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="130px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="Date" runat="server" Text='<%# Bind("bookingdate") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 290px">
                                    <asp:Label ID="Customer" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="290px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="POL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                    <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="POD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                    <asp:Label ID="POD" runat="server" Text='<%# Bind("POD") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle CssClass="GrdRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </asp:Panel>

    <asp:Label ID="Label3" runat="server" Style="display: none"></asp:Label>
    <cc1:ModalPopupExtender ID="programmaticModalPopup1" runat="server" BehaviorID="programmaticModalPopupBehaviordf1" TargetControlID="Label3"
        CancelControlID="imgggok" PopupControlID="POPUP1" DropShadow="false">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="POPUP1" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgggok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="Grdjob" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" AllowPaging="false" OnPageIndexChanging="Grdjob_PageIndexChanging"
                    PageSize="18" OnRowDataBound="Grdjob_RowDataBound" OnSelectedIndexChanged="Grdjob_SelectedIndexChanged" Width="100%">
                    <Columns>

                        <asp:TemplateField HeaderText="Job">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="66px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="VesselName">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                    <asp:Label ID="VesselName" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="166px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Voyage">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                    <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="64px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MBL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                    <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="166px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Destination">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                    <asp:Label ID="Destination" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="154px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETA">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MLO">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 160px">
                                    <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="205px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:BoundField DataField="agentid" HeaderText="agentid">
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
                        </asp:BoundField>

                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle CssClass="GrdRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </asp:Panel>

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
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
    <asp:Label ID="Label4" runat="server"></asp:Label>

    <cc1:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image2" BehaviorID="Test1">
    </cc1:ModalPopupExtender>

    <asp:HiddenField ID="hd_book" runat="server" />
    <asp:HiddenField ID="hd_bookstuff" runat="server" />
    <asp:HiddenField ID="hd_booksail" runat="server" />
    <asp:HiddenField ID="hd_booktrans" runat="server" />
    <asp:HiddenField ID="hd_customer" runat="server" />
    <asp:HiddenField ID="hd_shipbill" runat="server" />
    <asp:HiddenField ID="hd_package" runat="server" />
    <asp:HiddenField ID="hd_exporter" runat="server" />
    <asp:HiddenField ID="hd_portname" runat="server" />
    <asp:HiddenField ID="hd_mastervessel" runat="server" />
    <asp:HiddenField ID="hd_oldmvessel" runat="server" />
    <asp:HiddenField ID="hd_custmail" runat="server" />
    <asp:HiddenField ID="hd_intermail" runat="server" />
    <asp:HiddenField ID="hd_dest" runat="server" />
    <asp:HiddenField ID="hd_port" runat="server" />


    <asp:HiddenField ID="hf_cmailid" runat="server" />
    <asp:HiddenField ID="hf_imailid" runat="server" />
    <asp:HiddenField ID="hf_imailname" runat="server" />
    <asp:HiddenField ID="hf_cmailname" runat="server" />
    <asp:HiddenField ID="hf_stuffInland" runat="server" />
    <asp:HiddenField ID="hf_loadingInland" runat="server" />
    <asp:HiddenField ID="hf_TCInland" runat="server" />
    <asp:HiddenField ID="hf_shippermailadd" runat="server" />
    <asp:HiddenField ID="hf_agentid" runat="server" />
    <asp:HiddenField ID="hf_intcust" runat="server" />
    <asp:HiddenField ID="hid_jobtype" runat="server" />
    <asp:HiddenField ID="hid_Por" runat="server" />
    <asp:HiddenField ID="hid_fd" runat="server" />
    <asp:HiddenField ID="hid_pol" runat="server" />
    <asp:HiddenField ID="hid_pod" runat="server" />
    <asp:HiddenField ID="hid_dtDODdate" runat="server" />
    <asp:HiddenField ID="hid_jobno" runat="server" />
    <asp:HiddenField ID="hid_slectindex" runat="server" />


</asp:Content>









