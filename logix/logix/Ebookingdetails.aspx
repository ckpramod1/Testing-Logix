<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ebookingdetails.aspx.cs" Inherits="logix.Ebookingdetails"  EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%--<%@ Register Assembly="Typad" Namespace="Typad" TagPrefix="cc1" %>--%>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>
     <link rel="stylesheet" type="text/css" href="style.css" />
    <script language="javascript" type="text/javascript" src="niceforms.js"></script>
    <link rel="stylesheet" type="text/css" media="all" href="niceforms-default.css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>

     <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />
    <link href="Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.form-components.js"></script>
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
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
    <link href="Style/Booking.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <script type="text/javascript" src="Scripts/Validation.js"></script>




    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />


    
     <link href="Styles/chosen.css" rel="stylesheet" />
    <link href="Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
    
    <script type="text/javascript">

        


      <%--   function ShowpImagePreview(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        // $('#img_flag').attr('src', e.target.result);
                        $('#<%= txtDoc .ClientID %>').attr('src', e.target.result);
                 }
                 reader.readAsDataURL(input.files[0]);
                 }
         }--%>



        function pageLoad(sender, args) {




            $(document).ready(function () {

                $("#<%=txt_por.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_por.ClientID %>").val(0);
                        $.ajax({
                            url: "Ebookingdetails.aspx/GetPort",
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
                        $("#<%=hid_por.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_por.ClientID %>").val(i.item.label);
                        $("#<%=hid_por.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_por.ClientID %>").val(i.item.label);
                        $("#<%=hid_por.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });


                $("#<%=txt_pol.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_pol.ClientID %>").val(0);
                        $.ajax({
                            url: "Ebookingdetails.aspx/GetPort",
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
                        $("#<%=hid_pol.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_pol.ClientID %>").val(i.item.label);
                        $("#<%=hid_pol.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_pol.ClientID %>").val(i.item.label);
                        $("#<%=hid_pol.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });

                $("#<%=txt_pod.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_pod.ClientID %>").val(0);
                        $.ajax({
                            url: "Ebookingdetails.aspx/GetPort",
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

                        $("#<%=hid_pod.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_pod.ClientID %>").val(i.item.label);
                        $("#<%=hid_pod.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        $("#<%=txt_pod.ClientID %>").val(i.item.label);
                        $("#<%=hid_pod.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });

                $("#<%=txt_fd.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_fd.ClientID %>").val(0);
                        $.ajax({
                            url: "Ebookingdetails.aspx/GetPort",
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

                        $("#<%=hid_fd.ClientID %>").val(i.item.val);
                    },

                    focus: function (event, i) {
                        $("#<%=txt_fd.ClientID %>").val(i.item.label);
                        $("#<%=hid_fd.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_fd.ClientID %>").val(i.item.label);
                        $("#<%=hid_fd.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });

                $("#<%=txt_inco.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_inco.ClientID %>").val(0);
                        $.ajax({
                            url: "Ebookingdetails.aspx/GetInco",
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

                        $("#<%=hid_inco.ClientID %>").val(i.item.val);
                    },

                    focus: function (event, i) {
                        $("#<%=txt_inco.ClientID %>").val(i.item.label);
                        $("#<%=hid_inco.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_inco.ClientID %>").val(i.item.label);
                        $("#<%=hid_inco.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });



                $(document).ready(function () {
                    $("#<%=txt_shipper.ClientID %>").autocomplete({
                         source: function (request, response) {
                             $("#<%=Hiddenshipper.ClientID %>").val(0);
                          $.ajax({
                              url: "Ebookingdetails.aspx/getlikeshipper",
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
                                  //alertify.alert(response.responseText);
                              },
                              failure: function (response) {
                                  //alertify.alert(response.responseText);
                              }
                          });
                      },
                      <%-- select: function (event, i) {
                          if (i.item) {
                              $("#<%=txtshipper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                              $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                          }
                      },
                     focus: function (event, i) {
                         if (i.item) {
                             $("#<%=txtshipper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                             $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                         }
                      },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txtshipper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                              $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      close: function (event, i) {
                          if (i.item) {
                              $("#<%=txtshipper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                              $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                          }
                      },--%>

                      select: function (e, i) {
                          $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                          $("#<%=txt_shipper.ClientID %>").val(i.item.text);
                          $("#<%=txt_shipper.ClientID %>").val($.trim(i.item.label));
                          $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                          $("#<%=txt_shipper.ClientID %>").change();
                      },
                      change: function (e, i) {
                          if (i.item) {
                              $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                              $("#<%=txt_shipper.ClientID %>").val(i.item.text);
                              $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                              $("#<%=txt_shipper.ClientID %>").val($.trim(i.item.label));
                          }
                      },
                      focus: function (e, i) {
                          $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                          $("#<%=txt_shipper.ClientID %>").val(i.item.text);
                          $("#<%=txtsaddress.ClientID %>").val(i.item.address);

                          var result = $("#<%=txt_shipper.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txt_shipper.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_shipper.ClientID %>").val($.trim(res));
                         }
                      },
                      close: function (e, i) {
                          var result = $("#<%=txt_shipper.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txt_shipper.ClientID %>").val($.trim(out));
                         }
                         else {
                             $("#<%=txt_shipper.ClientID %>").val($.trim(res));
                         }
                          $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                      },


                      minLength: 1
                  });
                 });


                $(document).ready(function () {
                    $("#<%=txt_inco.ClientID %>").autocomplete({
                          source: function (request, response) {
                              $("#<%=hdn_Incoid.ClientID %>").val(0);
                        $.ajax({
                            url: "Ebookingdetails.aspx/GetLikeIncocode",
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
                        $("#<%=txt_inco.ClientID %>").val(i.item.label);
                      $("#<%=txt_inco.ClientID %>").change();
                      $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);


                  },
                    focus: function (event, i) {
                        $("#<%=txt_inco.ClientID %>").val(i.item.label);
                      $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);

                  },
                    close: function (event, i) {
                        $("#<%=txt_inco.ClientID %>").val(i.item.label);
                      $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);

                  },
                    minLength: 1
                });
                  
                });

                $(document).ready(function () {
                    $("#<%=txt_consignee.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $("#<%=Hiddenconsignee.ClientID %>").val(0);
                          $.ajax({
                              url: "Ebookingdetails.aspx/getlikeconsignee",
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
                                  //alertify.alert(response.responseText);
                              },
                              failure: function (response) {
                                  //alertify.alert(response.responseText);
                              }
                          });
                      },
                      

                      select: function (e, i) {
                          $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                          $("#<%=txt_consignee.ClientID %>").val(i.item.text);
                          $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label));
                          $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                          $("#<%=txt_consignee.ClientID %>").change();
                      },
                      change: function (e, i) {
                          if (i.item) {
                              $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                              $("#<%=txt_consignee.ClientID %>").val(i.item.text);
                              $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                              $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label));
                          }
                      },
                      focus: function (e, i) {
                          $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                          $("#<%=txt_consignee.ClientID %>").val(i.item.text);
                          $("#<%=txtcaddress.ClientID %>").val(i.item.address);

                          var result = $("#<%=txt_consignee.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txt_consignee.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txt_consignee.ClientID %>").val($.trim(res));
                          }
                      },
                      close: function (e, i) {
                          var result = $("#<%=txt_consignee.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txt_consignee.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txt_consignee.ClientID %>").val($.trim(res));
                          }
                          $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                      },

                      minLength: 1
                  });
                });

                $(document).ready(function () {
                    $("#<%=txt_notify.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $("#<%=Hiddennotify.ClientID %>").val(0);
                          $.ajax({
                              url: "Ebookingdetails.aspx/getlikenotify",
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
                                  //alertify.alert(response.responseText);
                              },
                              failure: function (response) {
                                  //alertify.alert(response.responseText);
                              }
                          });
                      },
                      <%--select: function (event, i) {
                          if (i.item) {
                              $("#<%=txtnotify.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                              $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                          }
                      },
                       focus: function (event, i) {
                           if (i.item) {
                               $("#<%=txtnotify.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                               $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                               $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                           }
                      },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txtnotify.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                              $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      close: function (event, i) {
                          if (i.item) {
                              $("#<%=txtnotify.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                              $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                          }
                     },--%>


                      select: function (e, i) {
                          $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                          $("#<%=txt_notify.ClientID %>").val(i.item.text);
                          $("#<%=txt_notify.ClientID %>").val($.trim(i.item.label));
                          $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                          $("#<%=txt_notify.ClientID %>").change();
                      },
                      change: function (e, i) {
                          if (i.item) {
                              $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                              $("#<%=txt_notify.ClientID %>").val(i.item.text);
                              $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                              $("#<%=txt_notify.ClientID %>").val($.trim(i.item.label));
                          }
                      },
                      focus: function (e, i) {
                          $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                          $("#<%=txt_notify.ClientID %>").val(i.item.text);
                          $("#<%=txtnaddress.ClientID %>").val(i.item.address);

                          var result = $("#<%=txt_notify.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txt_notify.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txt_notify.ClientID %>").val($.trim(res));
                          }
                      },
                      close: function (e, i) {
                          var result = $("#<%=txt_notify.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txt_notify.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txt_notify.ClientID %>").val($.trim(res));
                          }
                          $("#<%=txt_notify.ClientID %>").val(i.item.address);
                      },
                      minLength: 1
                  });
                });



                $(document).ready(function () {
                    $("#<%= txt_customer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_customerid.ClientID %>").val(0);
                        $.ajax({
                            url: "Ebookingdetails.aspx/GetCustomername",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_customer.ClientID %>").val(i.item.label);
                        $("#<%=txt_customer.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_customer.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

       <%--         $("#<%=ddl_out.ClientID %>").change(function () {
                    var str_value = $("#<%=ddl_out.ClientID %>").val();
                    if (str_value == "A") {
                        $("#<%=lbl_approx_volume.ClientID %>").text("Approx.Kgs");
                    }
                    else {
                        str_value = $("#<%=ddl_type.ClientID %>").val();
                        if (str_value == "F") {
                            $("#<%=lbl_approx_volume.ClientID %>").text("Approx.Tues");
                        }
                        else {
                            $("#<%=lbl_approx_volume.ClientID %>").text("Approx.CBM");
                        }
                    }
                });--%>


                <%--$("#<%=ddl_type.ClientID %>").change(function () {
                    if ($("#<%=ddl_out.ClientID %>").val() == "F") {
                        var str_value = $("#<%=ddl_type.ClientID %>").val();
                        if (str_value == "F") {
                            $("#<%=lbl_approx_volume.ClientID %>").text("Approx.Tues");
                        }
                        else {
                            $("#<%=lbl_approx_volume.ClientID %>").text("Approx.CBM");
                        }
                    }
                });--%>
            });



            $(document).ready(function () {
                $("#<%=txt_booking.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Ebookingdetails.aspx/Getlikebookfromtmp",
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
                        $("#<%=txt_booking.ClientID %>").val(i.item.label);
                        $("#<%=txt_booking.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_booking.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        $("#<%=txt_booking.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });




            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


        }


    </script>
    <style type="text/css">
        .row {
    background-color:transparent;
    clear: both;
    height: 388px!important;
    margin: 0px 5px 0px -15px!important;
    overflow-x: hidden!important;
    overflow-y: auto!important;
    width:81.5%;
}


        .widget.box {
            height:379px;
        }



        .BookingFCL {
    width: 20%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingCartoons {
    width: 98.8%;
    float: left;
    margin: 0px 0% 0px 0px;
}
        #txtbranchoff_chzn {
            width:100%!important;
        }
        .CustomerTxtBox {
    width: 79%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BranchOfficeTxtbox {
    float: left;
    width: 20%;
    margin: 0px 0.5% 0px 0px;
}
        .BranchAddress {
            width:79%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        #ddl_type_chzn {
            width:100%!important;
        }
        .BookingPOR {
    width: 18.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingPOL {
    width: 18.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingPOD {
    width: 18.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingFD {
    width: 22%;
    float: left;
    margin: 0px 0% 0px 0px;
}
        .BoolkingLeft {
            width:49.5%;
            float:left;
            border-right:1px dotted #b1b1b1;
            margin:5px 0.5% 0px 0px;
        }
        .BookingRight1{
            width:50%;
            float:left;           
            margin:5px 0% 0px 0px;
        }
        .BookingShipper {
            width:98.5%;
            margin:0px 0.5% 0px 0px;
            float:left;
        }
        .ShippInput {
    width: 98.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingNotify {
    width: 98.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .BookingMarks {
    width: 98.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .BookingConsignee {
    width: 99%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Consignee1 {
    width: 98.9%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .BookingPKG {
    width: 19%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingWeight {
    width: 20%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingApprox {
    width: 39.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BookingINCO {
    width: 18.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
          .BookingINCO1 {
    width: 19.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
          .BookingINCO2 {
    width: 19.8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
          
        .BookingINCO3 {
    width: 39.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .btn-booking input {
    border-style: none !important;
    border-color: inherit !important;
    border-width: medium !important;
    line-height: normal;
    color: #4e4e4c;
    padding: 8px 0px 5px 28px !important;
    background: url(Theme/buttonIcon/can.png) no-repeat left top;
    /* height: 27px; */
}
     .widget.box .widget-content {
            background-color:#fff;/*#92a0aa*/
            border:1px solid #b1b1b1;
            padding:5px;
        }

        body {
            background-color:transparent;
        } 

          .crumbs {
    background-color: transparent!important;
    border-top: 0px solid #d9d9d9;
    border-bottom: 0px solid #fff;
    height: 20px;
}
         .crumbs li {
    list-style: none;
    color:#000;
}
         ul {
             padding:0px 0px 0px 0px;
         }
         .crumbs
        {
          margin:5px -20px 0px 0px!important
        }


        .crumbs .breadcrumb {
            padding:0px 0px 0px 0px;
        }
        #ddlhya_chzn .chzn-drop {
    height: 122px !important;
    overflow: auto;
}

        #ddl_type_chzn .chzn-drop {
    height: 150px !important;
    overflow: auto;
}

        textarea#txt_cartons {
    height: 81px!important;
}
        span#mailcontent {
    top: 0%;
    position: absolute;
    left: 0%;
    background-color: #fff;
    border: 1px solid #b1b1b1;
    padding: 10px;
    width: 100%;
}

        .TBLFormat {
            border:1px solid #b1b1b1;
            border-collapse:collapse;
        }

        .TBLFormat td {
            border:1px solid #b1b1b1;
        }
    </style>
</head>
<body style="margin-left: 10px; margin-top: 10px;">
     
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading....
            Please wait...
        </ProgressTemplate>
    </asp:UpdateProgress>
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
      <%--  <ContentTemplate>--%>

            
    <!-- Breadcrumbs line -->
      <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
             
              <li class="current">e-Booking</li>
            </ul>
      </div>

       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box">
     
     <div class="widget-header" style="display:none;">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="lbl_head" runat="server" Text="e-Booking"></asp:Label></h4>
                </div>
          <div class="widget-content">
              <div class="FormGroupContent4">
                  <div class="BookingTxtBox"> 
                 
                      
                      <asp:TextBox ID="txt_booking" runat="server"  placeholder="e-Booking #" CssClass="form-control" ToolTip="e-Booking #" TabIndex="1" AutoPostBack="true" OnTextChanged="txt_booking_TextChanged"></asp:TextBox>


                  </div>
                                   <div class="CustomerTxtBox">                     
                      
                       <asp:TextBox ID="txt_customer" runat="server" CssClass="form-control" ToolTip="Customer" TabIndex="2" placeholder="Customer" OnTextChanged="txt_customer_TextChanged"></asp:TextBox>


                   </div>
                  </div>
              <div class="FormGroupContent4">
                     <div class="BranchOfficeTxtbox"><asp:DropDownList ID="txtbranchoff" runat="server" CssClass ="chzn-select" TabIndex="3" AutoPostBack="true"  MaxLength="50" OnSelectedIndexChanged="txtbranchoff_SelectedIndexChanged"></asp:DropDownList></div>
                   
                                   <div class="BranchAddress">                     
                      
                       <asp:TextBox ID="txt_branchaddress" runat="server" CssClass="form-control" ToolTip="Branch Address" TabIndex="4" placeholder="Branch Address"></asp:TextBox>


                   </div>
                  
                  <div class="Bookingdate" style="display:none;">
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" placeholder="Booking Date" ToolTip="Booking Date" TabIndex="2"></asp:TextBox>
                        </div>
                   <div class="BookingExport" style="display:none;"> 
                      <asp:DropDownList ID="ddl" runat="server"  TabIndex="3" AutoPostBack="True" Height="23px">
                            <asp:ListItem Value="E" Selected="True">Export from India</asp:ListItem>
                            <asp:ListItem Value="I">Import into India</asp:ListItem>
                        </asp:DropDownList></div>
                     <div class="BookingAir" style="display:none;"> <asp:DropDownList ID="ddl_out" runat="server" TabIndex="4" Height="23px">
                            <asp:ListItem Value="A" Selected="True">Air</asp:ListItem>
                            <asp:ListItem Value="F">Sea</asp:ListItem>
                        </asp:DropDownList>

                     </div>
                
                </div>
        
                
         
             


                   
   <div class="FormGroupContent4">
        <div class="BookingFCL"> 
                      <asp:DropDownList ID="ddl_type" runat="server" TabIndex="5" Height="23px" CssClass ="chzn-select" placeholder="Shipment">
                          <asp:ListItem Value="0">--Shipment-</asp:ListItem>
                            <asp:ListItem Value="F">FCL</asp:ListItem>
                            <asp:ListItem Value="L">LCL</asp:ListItem>
                          <asp:ListItem Value="A">Air</asp:ListItem>
                        </asp:DropDownList></div>
                 
                  <div class="BookingPOR">
                
                      <asp:TextBox ID="txt_por" runat="server" CssClass="form-control" ToolTip="PoR" TabIndex="6" placeholder="PoR" OnTextChanged="txt_por_TextChanged"></asp:TextBox>
                  </div>
                   <div class="BookingPOL">
                      
                       

                       <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" ToolTip="PoL" TabIndex="7" placeholder="PoL" OnTextChanged="txt_pol_TextChanged"></asp:TextBox>
                   </div>
                  <div class="BookingPOD">
                     
                      

                      <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" TabIndex="8" ToolTip="PoD" placeholder="PoD" OnTextChanged="txt_pod_TextChanged"></asp:TextBox>

                  </div>
                <div class="BookingFD">

                  
                     <asp:TextBox ID="txt_fd" runat="server" CssClass="form-control" ToolTip="FD" TabIndex="9" placeholder="FD" OnTextChanged="txt_fd_TextChanged"></asp:TextBox>

                </div>
                  </div>
              <div class="BoolkingLeft">

                       <div class="FormGroupContent4">
                            
                  <div class="BookingShipper"><asp:TextBox ID="txt_shipper" runat="server" CssClass="form-control" AutoPostBack="True"  TabIndex="10" placeholder="Shipper" ToolTip="Shipper" OnTextChanged="txt_shipper_TextChanged"></asp:TextBox></div>
                 
                  </div>
                   
                       <div class="FormGroupContent4">
                  <div class="ShippInput"><asp:TextBox ID="txtsaddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Shipper Address" ToolTip="Shipper Address"></asp:TextBox></div>
                
                  </div>
                   <div class="FormGroupContent4">
                         <div class="BookingNotify">

                    
                       <asp:TextBox ID="txt_notify" runat="server" CssClass="form-control" ToolTip="Notify" TabIndex="12" placeholder="Notify" OnTextChanged="txt_notify_TextChanged"></asp:TextBox>

                   </div>

                   </div>
                 
                   <div class="FormGroupContent4">
                  <div class="ShippInput"><asp:TextBox ID="txtnaddress" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Notify Address" ToolTip="Notify Address"></asp:TextBox></div>

                       </div>
                
             <div class="FormGroupContent4">
                    
                       <div class="BookingMarks">
                        

                           <asp:TextBox ID="txt_marks" runat="server" CssClass="form-control" ToolTip="Marks & Nos" TabIndex="13" placeholder="Marks & Nos" textmode="MultiLine"></asp:TextBox>


                       </div>

                       </div>
              
                  </div>
              <div class="BookingRight1">
              <div class="FormGroupContent4">
                  <div class="BookingConsignee"><asp:TextBox ID="txt_consignee" runat="server" CssClass="form-control" AutoPostBack="True"  TabIndex="11" OnTextChanged="txt_consignee_TextChanged" placeholder="Consignee" ToolTip="Consignee"></asp:TextBox></div>
               
               </div>
                   <div class="FormGroupContent4">
              <div class="Consignee1"><asp:TextBox ID="txtcaddress" runat="server" CssClass="form-control" TextMode="MultiLine"  placeholder="Consignee Address" ToolTip="Consignee Address"></asp:TextBox></div>
              </div>
                
                 
                   
                  
                  <div class="FormGroupContent4">

                           <div class="BookingPKG">
                          
                          
                           <asp:TextBox ID="txt_noofpkg" runat="server" CssClass="form-control" ToolTip="No of Pkgs" TabIndex="14" placeholder="No of Pkgs"></asp:TextBox>


                      </div>

                         <div class="BookingPKG">
                          
                          
                           <asp:TextBox ID="txt_pkg" runat="server" CssClass="form-control" ToolTip="Pkg Type" TabIndex="15" placeholder="Pkg Type"></asp:TextBox>


                      </div>
                  <div class="BookingWeight">
                        

                          <asp:TextBox ID="txt_wt" runat="server" CssClass="form-control" ToolTip="Weight" TabIndex="16" placeholder="Weight"></asp:TextBox>

                      </div>
           
                  <div class="BookingApprox">
                      
                      <asp:TextBox ID="txt_approx_volume" runat="server" ToolTip="Volume" CssClass="form-control" TabIndex="17" placeholder="Volume"></asp:TextBox>

                  </div>

                      



               

                

                  </div>
                  <div class="FormGroupContent4">
                          <div class="BookingINCO"> 
                      
                       <asp:TextBox ID="txt_inco" runat="server" CssClass="form-control" ToolTip="Inco" TabIndex="18" placeholder="Inco" OnTextChanged="txt_inco_TextChanged"></asp:TextBox>
                  </div>

                    <div class="BookingINCO1"> 
                      
                       <asp:TextBox ID="txt_uno" runat="server" CssClass="form-control" ToolTip="UNO #" TabIndex="19" placeholder="UNO #"></asp:TextBox>
                  </div>
                      <div class="BookingINCO2"> 
                      
                      <asp:DropDownList ID="ddlhya" runat="server" TabIndex="20" Height="23px" CssClass ="chzn-select" placeholder="Hazardous">
                           <asp:ListItem Value="0">--Hazardous-</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                  </div>

                     <div class="BookingINCO3"> 
                      
                       <asp:TextBox ID="txt_tues" runat="server" CssClass="form-control" ToolTip="Class" TabIndex="21" placeholder="Class"></asp:TextBox>
                  </div>
        
                  </div>
                  <div class="FormGroupContent4">
                       <div class="BookingCartoons">

                         
                          <asp:TextBox ID="txt_cartons" runat="server" CssClass="form-control" ToolTip="Cargo Description" TabIndex="22" TextMode="MultiLine" placeholder="Cargo Description"></asp:TextBox>


                      </div>
                  </div>     
                  
                             
              </div>



            <div class="bordertopNew"></div>
               <%--  <div class="FileUpload">
                         <asp:TextBox ID="txtDoc" runat="server"  CssClass="form-control" TabIndex="2"  ToolTip="Document Number" placeholder="Document Number" Enabled="false"></asp:TextBox>
                     </div>
                  <div class="FileUpload1">
                           <asp:FileUpload ID="upd_document" runat="server" ToolTip="Doc Path" onchange="ShowpImagePreview(this);"/>
                           </div>--%>

                         <div class="FileUpload">
                                <asp:FileUpload ID="upd_document" runat="server" TabIndex="3" Width="100%"></asp:FileUpload>
                            </div>

               <div class="div_Grid">
        <%--<asp:GridView ID="Grd_Doc" runat="server" AllowPaging="false" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" OnRowCommand="Grd_Doc_RowCommand" OnRowDataBound="Grd_Doc_RowDataBound" ForeColor="Black" PageSize="11" 
            BackColor="White">
            <Columns>
                <asp:BoundField DataField="docname" HeaderText="Doc Type">
                    <HeaderStyle Width="370px" />
                    <ItemStyle HorizontalAlign="Left" Width="35%" />
                </asp:BoundField>
                <asp:BoundField DataField="remarks" HeaderText="Remarks">
                     <HeaderStyle Width="460px" />
                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                </asp:BoundField>               
                 <asp:BoundField DataField="doctype" HeaderText="doctype" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                     <HeaderStyle Width="460px" />
                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                </asp:BoundField>
                 <asp:BoundField DataField="docid" HeaderText="docid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                     <HeaderStyle Width="460px" />
                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                </asp:BoundField>
                 <asp:BoundField DataField="fileloc" HeaderText="file" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                     <HeaderStyle Width="460px" />
                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                </asp:BoundField>
                 <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_Print" runat="server" CommandName="print" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                 </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>--%>


         <asp:GridView ID="grpupdload" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ForeColor="Black" OnRowDataBound="grpupdload_RowDataBound" OnSelectedIndexChanged="grpupdload_SelectedIndexChanged" ShowHeaderWhenEmpty="true" Width="100%" onrowcommand="grpupdload_RowCommand" onrowdeleting="grpupdload_RowDeleting">
                     <Columns>
                         <asp:BoundField DataField="docname" HeaderText="Doc Type">
                         <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="remarks" HeaderText="Remarks">
                         <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="370px" />
                         <ItemStyle HorizontalAlign="Left" Width="370px" />
                         </asp:BoundField>
                         <asp:BoundField ControlStyle-CssClass="hide" DataField="doctype" HeaderText="docid">
                         <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" />
                         <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="15%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="docid" HeaderText="dcmtid">
                         <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" Width="350px" />
                         <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="350px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="fileloc" HeaderText="FileNameLoc"> 
                         <HeaderStyle  HorizontalAlign="Left" Wrap="true" Width="350px" /> <%-- CssClass="hide"--%>
                         <ItemStyle  HorizontalAlign="Left" Width="350px" /> <%--  CssClass="hide"--%>
                         </asp:BoundField>
                            <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                        <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" 
                            ImageUrl="~/images/delete.jpg" />
                    </ItemTemplate>
                    <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px"  />
                     <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify"/>
                   
                </asp:TemplateField>
                     </Columns>
                     <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                     <HeaderStyle CssClass="" />
                     <AlternatingRowStyle CssClass="GrdAltRow" />
                 </asp:GridView>


         </div>
              <div class="FormGroupContent4">
               <div style="color:maroon; float:left;"><asp:Label ID="lbl_DispMsg" runat="server" Text="Upload status : "></asp:Label></div>
               <div class="btn ico-upload"> <asp:Button ID="btnSave" runat="server" ToolTip="Upload"  TabIndex="16" OnClick="btnSave_Click" /></div>
                   <div class="right_btn MT0">

                            <div class="btn btn-booking" id="btn_save1" runat="server"><asp:Button ID="btn_save" runat="server"  ToolTip="Save" placeholder="Save" TabIndex="23"  OnClick="btn_save_Click" /></div>
                           <div class="btn ico-cancel"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" placeholder="Cancel" TabIndex="24"  OnClick="btn_cancel_Click"   /></div> <%--OnClick="btn_cancel_Click"--%>

                      </div>
                  </div>
          <%--   <asp:Label ID="mailcontent" runat="server"></asp:Label>--%>
               
               
                <div style="clear:both;"></div>
            </div>
           </div>
           </div>
           














                    <asp:HiddenField ID="hid_shipper" runat="server" />
                    <asp:HiddenField ID="hid_consignee" runat="server" />
                    <asp:HiddenField ID="hid_notify" runat="server" />
                    <asp:HiddenField ID="hid_por" runat="server" />
                    <asp:HiddenField ID="hid_pol" runat="server" />
                    <asp:HiddenField ID="hid_pod" runat="server" />
                    <asp:HiddenField ID="hid_fd" runat="server" />
                    <asp:HiddenField ID="hid_inco" runat="server" />


             <asp:HiddenField ID="Hiddenshipper" runat="server" />
           
               <asp:HiddenField ID="Hiddenconsignee" runat="server" />

             <asp:HiddenField ID="Hiddennotify" runat="server" />
            <asp:HiddenField ID="hf_customerid" runat="server" />

                      <asp:HiddenField ID="hid_branchid" runat="server" />

              <asp:HiddenField ID="hdn_Incoid" runat="server" />

                <asp:HiddenField ID="hid_poddownload" runat="server" />
              

           
                              <%--  <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_dtfdate" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>--%>

<%--        </ContentTemplate>--%>
  <%--  </asp:UpdatePanel>--%>
    </form>
</body>
</html>

