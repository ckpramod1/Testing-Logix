<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FIBL.aspx.cs" Inherits="logix.FI.FIBL" %>

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
    <%--<script type="text/javascript" src="../js/TextField.js"></script>--%>

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

    <link href="../Styles/FIBL.css" rel="stylesheet" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }

        .MarkLeft1 {
            float: left;
            width: 100%;
        }

        .div_containerlist td {
            margin: 5px 0px 0px 5px;
            display: inline-block;
        }

        .Mark_Numbers {
            float: left;
            width: 23.5%;
            margin-right: 0.5%;
        }



        .Description {
            float: left;
            width: 35%;
            margin: 0px 0.5% 0px 0px;
        }



        .MarkRight2 {
            width: 13%;
            float: left;
            margin: 0px 5px 0px 0px;
        }

        .div_containerlist table {
            padding: 25px 0px 0px 5px !important;
            display: inline-block;
        }

        .div_containerlist {
            background-color: white;
            border: 0px solid var(--inputborder) !important;
            width: 100%;
            border-radius: 0px;
            height: 162px;
            position: relative;
            overflow: auto;
            border-bottom: 1px solid var(--inputborder) !important;
        }

        table#logix_CPH_chkListCont tr,
        table#logix_CPH_chkListCont td {
            background: none !important;
            padding: 1px 2px !important;
            border: 0px !important;
        }

        .div_containerlist span {
            top: 6px !important;
            left: 0px !important;
            padding: 4px 0.3rem 0 !important;
            margin: 1px 4px 0px !important;
            width: 90% !important;
            pointer-events: none !important;
            position: absolute !important;
            color: #06529c !important;
            /* color: red !important; */
            font-size: 13px !important;
            font-weight: 500 !important;
        }

        .vsl {
            width: 26.9%;
            float: left;
        }

        .Job_type {
            float: left;
            width: 100%;
        }

        .MBLNum {
            float: left;
            width: 100%;
            margin: 0px 0% 0px 0px;
        }

        .MBLStatus {
            float: left;
            width: 100%;
            margin: 0px 0% 0px 0px;
        }

        .Versel {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .ETD {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .POD {
            float: left;
            width: 100%;
        }

        .ETA {
            float: left;
            width: 100%;
        }

        .MLO {
            float: left;
            width: 100%;
            margin: 0;
        }

        .Carrier {
            float: left;
            width: 100%;
        }

        input#logix_CPH_txt_job, input#logix_CPH_txt_jobtype,
        input#logix_CPH_mbl, input#logix_CPH_mblstatus,
        input#logix_CPH_vessel, input#logix_CPH_pol,
        input#logix_CPH_etd, input#logix_CPH_pod,
        input#logix_CPH_eta, input#logix_CPH_mlo,
        input#logix_CPH_carrier,
        input#logix_CPH_txtcontract, input#logix_CPH_txtjobno, input#logix_CPH_txtCaption {
            border: none !important;
        }

        .TextField .inputcolor, .TextField .inputcolor:focus {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            font-weight: normal !important;
        }

        .inputcolor {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }

        .FormGroupContent4 textarea {
            height: 71px !important;
        }

        div#logix_CPH_pnl_emp {
            position: fixed !important;
            background-color: rgba(0, 0, 0, 0.75) !important;
            width: 100% !important;
            height: 100% !important;
            margin-left: 0% !important;
            margin-top: 0% !important;
            border: 1px solid var(--lightgrey) !important;
            display: flex;
            justify-content: center;
            align-items: center;
            top: 0px !important;
            left: 0px !important;
        }

            div#logix_CPH_pnl_emp .divRoated {
                width: 47% !important;
                height: 30vh !important;
                overflow: hidden !important;
                background: var(--white);
                border-radius: 3px;
                margin: 0px !important;
                position: relative;
            }

            div#logix_CPH_pnl_emp .DivSecPanel {
                position: relative;
                right: 18px;
                top: -1px;
            }

        input#logix_CPH_Btnamendbl {
            width: 30px !important;
            scale: 0.7;
            background-position-x: 1px !important;
            background-position-y: 1px !important;
            margin-top: 10px;
        }

        div#logix_CPH_btn {
            margin: 0px;
            width: 32px !important;
        }
 
    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_blno.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hiddenid.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikebl",
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
                        $("#<%=txt_blno.ClientID %>").val(i.item.label);
                        $("#<%=txt_blno.ClientID %>").change();
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    <%--focus: function (event, i) {
                          $("#<%=txt_blno.ClientID %>").val(i.item.label);
                          $("#<%=hiddenid.ClientID %>").val(i.item.val);
                      },--%>
                    <%--change: function (event, i) {
                          $("#<%=txt_blno.ClientID %>").val(i.item.label);
                          $("#<%=hiddenid.ClientID %>").val(i.item.val);
                      },--%>
                      <%--close: function (event, i) {
                          $("#<%=txt_blno.ClientID %>").val(i.item.label);
                          $("#<%=hiddenid.ClientID %>").val(i.item.val);
                      },--%>
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_blissuseat.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hiddenid_issue.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikeport",
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
                        $("#<%=txt_blissuseat.ClientID %>").val(i.item.label);
                        $("#<%=txt_blissuseat.ClientID %>").change();
                        $("#<%=hiddenid_issue.ClientID %>").val(i.item.val);
                    },
                    <%--focus: function (event, i) {
                          $("#<%=txt_blissuseat.ClientID %>").val(i.item.label);
                         $("#<%=hiddenid_issue.ClientID %>").val(i.item.val);
                      },--%>
                    <%--change: function (event, i) {
                          $("#<%=txt_blissuseat.ClientID %>").val(i.item.label);
                          $("#<%=hiddenid_issue.ClientID %>").val(i.item.val);
                      },--%>
                      <%--close: function (event, i) {
                          $("#<%=txt_blissuseat.ClientID %>").val(i.item.label);
                          $("#<%=hiddenid_issue.ClientID %>").val(i.item.val);
                      },--%>
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtshipper.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddenshipper.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikeshipper",
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
                        $("#<%=txtshipper.ClientID %>").val(i.item.text);
                        $("#<%=txtshipper.ClientID %>").val($.trim(i.item.label));
                        $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                        $("#<%=txtshipper.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                            $("#<%=txtshipper.ClientID %>").val(i.item.text);
                            $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                            $("#<%=txtshipper.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);
                        $("#<%=txtshipper.ClientID %>").val(i.item.text);
                        $("#<%=txtsaddress.ClientID %>").val(i.item.address);

                        var result = $("#<%=txtshipper.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txtshipper.ClientID %>").val($.trim(out));
                        }
                        else {
                            $("#<%=txtshipper.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txtshipper.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txtshipper.ClientID %>").val($.trim(out));
                        }
                        else {
                            $("#<%=txtshipper.ClientID %>").val($.trim(res));
                        }
                        $("#<%=txtsaddress.ClientID %>").val(i.item.address);
                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtconsignee.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddenconsignee.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikeconsignee",
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
                              $("#<%=txtconsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                              $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      focus: function (event, i) {
                          if (i.item) {
                              $("#<%=txtconsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                              $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txtconsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                              $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      close: function (event, i) {
                          if (i.item) {
                              $("#<%=txtconsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                              $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                          }
                     },--%>

                    select: function (e, i) {
                        $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                          $("#<%=txtconsignee.ClientID %>").val(i.item.text);
                          $("#<%=txtconsignee.ClientID %>").val($.trim(i.item.label));
                          $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                          $("#<%=txtconsignee.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                              $("#<%=txtconsignee.ClientID %>").val(i.item.text);
                              $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                              $("#<%=txtconsignee.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=Hiddenconsignee.ClientID %>").val(i.item.val);
                          $("#<%=txtconsignee.ClientID %>").val(i.item.text);
                          $("#<%=txtcaddress.ClientID %>").val(i.item.address);

                          var result = $("#<%=txtconsignee.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txtconsignee.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txtconsignee.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txtconsignee.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txtconsignee.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txtconsignee.ClientID %>").val($.trim(res));
                          }
                          $("#<%=txtcaddress.ClientID %>").val(i.item.address);
                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtnotify.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddennotify.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikenotify",
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
                          $("#<%=txtnotify.ClientID %>").val(i.item.text);
                          $("#<%=txtnotify.ClientID %>").val($.trim(i.item.label));
                          $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                          $("#<%=txtnotify.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                              $("#<%=txtnotify.ClientID %>").val(i.item.text);
                              $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                              $("#<%=txtnotify.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=Hiddennotify.ClientID %>").val(i.item.val);
                          $("#<%=txtnotify.ClientID %>").val(i.item.text);
                          $("#<%=txtnaddress.ClientID %>").val(i.item.address);

                          var result = $("#<%=txtnotify.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txtnotify.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txtnotify.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txtnotify.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txtnotify.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txtnotify.ClientID %>").val($.trim(res));
                          }
                          $("#<%=txtnaddress.ClientID %>").val(i.item.address);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtagent.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddenagent.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikeagent",
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
                              $("#<%=txtagent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenagent.ClientID %>").val(i.item.val);
                              $("#<%=txtaaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      focus: function (event, i) {
                          if (i.item) {
                              $("#<%=txtagent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenagent.ClientID %>").val(i.item.val);
                              $("#<%=txtaaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txtagent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenagent.ClientID %>").val(i.item.val);
                              $("#<%=txtaaddress.ClientID %>").val(i.item.address);
                          }
                      },
                      close: function (event, i) {
                          if (i.item) {
                              $("#<%=txtagent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=Hiddenagent.ClientID %>").val(i.item.val);
                              $("#<%=txtaaddress.ClientID %>").val(i.item.address);
                          }
                     },--%>

                    select: function (e, i) {
                        $("#<%=Hiddenagent.ClientID %>").val(i.item.val);
                          $("#<%=txtagent.ClientID %>").val(i.item.text);
                          $("#<%=txtagent.ClientID %>").val($.trim(i.item.label));
                          $("#<%=txtaaddress.ClientID %>").val(i.item.address);
                          $("#<%=txtagent.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=Hiddenagent.ClientID %>").val(i.item.val);
                              $("#<%=txtagent.ClientID %>").val(i.item.text);
                              $("#<%=txtaaddress.ClientID %>").val(i.item.address);
                              $("#<%=txtagent.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=Hiddenagent.ClientID %>").val(i.item.val);
                          $("#<%=txtagent.ClientID %>").val(i.item.text);
                          $("#<%=txtaaddress.ClientID %>").val(i.item.address);

                          var result = $("#<%=txtagent.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txtagent.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txtagent.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txtagent.ClientID %>").val().toString();
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txtagent.ClientID %>").val($.trim(out));
                          }
                          else {
                              $("#<%=txtagent.ClientID %>").val($.trim(res));
                          }
                          $("#<%=txtaaddress.ClientID %>").val(i.item.address);
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $('#<%=txtreceipt.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddenrecipt.ClientID %>").val(0);

                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtreceipt.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtreceipt.ClientID%>').val(ui.item.portname);
                        $("#<%=Hiddenrecipt.ClientID %>").val(ui.item.portid);
                        $('#<%=txtreceipt.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtreceipt.ClientID%>').val(ui.item.portname);
                        $("#<%=Hiddenrecipt.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });



<%--              $(document).ready(function () {
                  $("#<%=txtreceipt.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $("#<%=Hiddenrecipt.ClientID %>").val(0);
                          $.ajax({
                              url: "FIBL.aspx/getlikereceipt",
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
                          $("#<%=txtreceipt.ClientID %>").val(i.item.label);
                          $("#<%=txtreceipt.ClientID %>").change();
                          $("#<%=Hiddenrecipt.ClientID %>").val(i.item.val);
                      },
                       
                      minLength: 1
                  });
              });--%>

            $(document).ready(function () {
                $('#<%=txtpol.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddenpol.ClientID %>").val(0);

                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtpol.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtpol.ClientID%>').val(ui.item.portname);
                        $("#<%=Hiddenpol.ClientID %>").val(ui.item.portid);
                        $('#<%=txtpol.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtpol.ClientID%>').val(ui.item.portname);
                        $("#<%=Hiddenpol.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });




<%--              $(document).ready(function () {
                  $("#<%=txtpol.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $("#<%=Hiddenpol.ClientID %>").val(0);
                          $.ajax({
                              url: "FIBL.aspx/getlikeloading",
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
                          $("#<%=txtpol.ClientID %>").val(i.item.label);
                          $("#<%=txtpol.ClientID %>").change();
                          $("#<%=Hiddenpol.ClientID %>").val(i.item.val);
                      },
                      
                      minLength: 1
                  });
              });--%>

            $(document).ready(function () {
                $('#<%=txtpodis.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=hiddencharge.ClientID %>").val(0);

                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtpodis.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtpodis.ClientID%>').val(ui.item.portname);
                        $("#<%=hiddencharge.ClientID %>").val(ui.item.portid);
                        $('#<%=txtpodis.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtpodis.ClientID%>').val(ui.item.portname);
                        $("#<%=hiddencharge.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });



<%--              $(document).ready(function () {
                  $("#<%=txtpodis.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $("#<%=hiddencharge.ClientID %>").val(0);
                          $.ajax({
                              url: "FIBL.aspx/getlikecharge",
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
                          $("#<%=txtpodis.ClientID %>").val(i.item.label);
                          $("#<%=txtpodis.ClientID %>").change();
                          $("#<%=hiddencharge.ClientID %>").val(i.item.val);
                      },
                      
                      minLength: 1
                  });
              });--%>


            $(document).ready(function () {
                $('#<%=txtfinaldes.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddentxtfinaldes.ClientID %>").val(0);

                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/SelPortName4typepadimg",
                            data: "{'prefix' :'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {

                                        portname: item.split('~')[0],
                                        portid: item.split('~')[1],
                                        portcode: item.split('~')[2],
                                        countryname: item.split('~')[3],
                                        countrycode: item.split('~')[4]
                                        //CountryName: item.portname,
                                        //Logo: item.portname,
                                        //portid:item.portid,
                                        //json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtfinaldes.ClientID%>').val(ui.item.portname);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtfinaldes.ClientID%>').val(ui.item.portname);
                        $("#<%=Hiddentxtfinaldes.ClientID %>").val(ui.item.portid);
                        $('#<%=txtfinaldes.ClientID%>').change();
                        return false;
                    },
                    change: function (event, ui) {
                        $('#<%=txtfinaldes.ClientID%>').val(ui.item.portname);
                        $("#<%=Hiddentxtfinaldes.ClientID %>").val(ui.item.portid);
                    }
                })


                    .data("ui-autocomplete")._renderItem = function (ul, item) {

                        return $("<li>")
                            //.append("<a style='padding-left:40px; background-image:url(../Branch/" + item.Logo + ");" +
                            //"background-repeat:no-repeat;background-position:left center;' >" + item.CountryName + "</a>").appendTo(ul);
                            .append("<a > <span> " + item.portname + "  (" + item.portcode + ")  ," + item.countryname + " </span><img src='../LOGO/" + item.countrycode + ".svg' width='24'/></a>")
                            .appendTo(ul);

                    };

            });




            $<%--(document).ready(function () {
                  $("#<%=txtfinaldes.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $("#<%=Hiddentxtfinaldes.ClientID %>").val(0);
                          $.ajax({
                              url: "FIBL.aspx/getlikefinal",
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
                          $("#<%=txtfinaldes.ClientID %>").val(i.item.label);
                          $("#<%=txtfinaldes.ClientID %>").change();
                          $("#<%=Hiddentxtfinaldes.ClientID %>").val(i.item.val);
                      },
                      
                      minLength: 1
                  });
              });--%>

            $(document).ready(function () {
                $("#<%=txtMVessel.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=Hiddenvessel.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikevessel",
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
                        $("#<%=txtMVessel.ClientID %>").val(i.item.label);
                          $("#<%=txtMVessel.ClientID %>").change();
                          $("#<%=Hiddenvessel.ClientID %>").val(i.item.val);
                    },
                      <%--focus: function (event, i) {
                          $("#<%=txtMVessel.ClientID %>").val(i.item.label);
                          $("#<%=Hiddenvessel.ClientID %>").val(i.item.val);
                      },
                      close: function (event, i) {
                          $("#<%=txtMVessel.ClientID %>").val(i.item.label);
                          $("#<%=Hiddenvessel.ClientID %>").val(i.item.val);
                      },--%>
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtTranshipped.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hiddenidtrans.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikeport",
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
                        $("#<%=txtTranshipped.ClientID %>").val(i.item.label);
                          $("#<%=txtTranshipped.ClientID %>").change();
                          $("#<%=hiddenidtrans.ClientID %>").val(i.item.val);
                    },
                      <%--focus: function (event, i) {
                          $("#<%=txtTranshipped.ClientID %>").val(i.item.label);
                          $("#<%=hiddenidtrans.ClientID %>").val(i.item.val);
                      },
                      close: function (event, i) {
                          $("#<%=txtTranshipped.ClientID %>").val(i.item.label);
                          $("#<%=hiddenidtrans.ClientID %>").val(i.item.val);
                      },--%>
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtcargo.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hiddencargo.ClientID %>").val(0);
                        $.ajax({
                            url: "FIBL.aspx/getlikecargo",
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
                        $("#<%=txtcargo.ClientID %>").val(i.item.label);
                          $("#<%=txtcargo.ClientID %>").change();
                          $("#<%=hiddencargo.ClientID %>").val(i.item.val);
                    },
                      <%--focus: function (event, i) {
                          $("#<%=txtcargo.ClientID %>").val(i.item.label);
                          $("#<%=hiddencargo.ClientID %>").val(i.item.val);
                      },
                      change: function (event, i) {
                          $("#<%=txtcargo.ClientID %>").val(i.item.label);
                          $("#<%=hiddencargo.ClientID %>").val(i.item.val);

                      },
                      close: function (event, i) {
                          $("#<%=txtcargo.ClientID %>").val(i.item.label);
                          $("#<%=hiddencargo.ClientID %>").val(i.item.val);
                      },--%>
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

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

        .DivSecPanel1 {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: 1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .Gridpnl1 {
            width: 1000px;
            Height: 560px;
        }
        /*.divRoated
        {
            width:950px; 
            Height:303px;
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/
        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
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
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
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



        .JobInput14 {
            width: 30.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FrieghtDetails {
            width: 2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobDetails2 {
            width: 73.9%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
            display: none;
        }

        .BookingInput8 {
            width: 18.6%;
            margin: 0px 0.5% 0 0;
            font-size: 11px;
            color: #000080;
        }

        .BillOf {
            width: 16.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IssuedAt {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IssueCal {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FreightDrop {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .CommInput {
            width: 29.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ShippInput {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Consignee1 {
            width: 49.9%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .PlaceInput {
            width: 23.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .PortInput1 {
            width: 25.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .DisInput {
            width: 25.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        div#UpdatePanel1 {
            height: 88vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .FinalInput {
            width: 24%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Mark {
            width: 100%;
            margin: 10px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
            position: relative;
        }

        .CubicInput3 {
            width: 51.7%;
            float: left;
            margin: 0px 1.9% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        a#logix_CPH_Label_2 {
            margin-right: 10px;
        }

        .CubicInput4 {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .GrossInput3 {
            width: 46.4%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .GrossInput4 {
            width: 13.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .NetInput1 {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .NetInput2 {
            width: 12.1%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        table#logix_CPH_chkListCont tbody tr td label {
            margin-left: 10px;
            margin-top: 1px;
        }

        .StatusDrop1 {
            width: 9.9%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Number1 {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Units1 {
            width: 16.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .UNOCode {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IMOCode {
            width: 6.9%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Remark1 {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BLSurender {
            width: 10%;
            float: left;
            margin: 17px 0.5% 0px 0px;
            color: #000080;
        }

        .BusinessChk {
            width: 13%;
            float: left;
            margin: 17px 0px 0px 0px;
            color: #000080;
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

        .ShippInput {
            margin-right: 0.5% !important;
        }

        img#logix_CPH_porflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: 13.8%;
            top: 351px;
            z-index: 10;
        }

        img#logix_CPH_flagimg {
            width: 24px !important;
            height: auto;
            position: relative;
            left: 30.7%;
            top: 351px;
            z-index: 10;
        }

        img#logix_CPH_podflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: 50.4%;
            top: 351px;
            z-index: 10;
        }

        img#logix_CPH_fdflag {
            width: 24px !important;
            height: auto;
            position: relative;
            left: 67.9%;
            top: 351px;
            z-index: 10;
        }

        /*New Design - Buttons*/


        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 65px !important;
        }

        .ldiv {
            width: 80%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .rdiv {
            width: 19.5%;
            float: left;
            margin: 0px 0px 0px 0px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            .rdiv .FormGroupContent4 {
                -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            }

        .TextField .inputcolor, .TextField .inputcolor:focus {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            font-weight: normal !important;
        }

        .Mark_Numbers textarea {
            height: 152px !important;
            width: 100%;
            float: left;
        }

        .Description textarea {
            height: 152px !important;
        }
        input#logix_CPH_btn_job {
    width: 33px !important;
    scale: 0.7;
    background-position-x: 0px !important;
    background-position-y: 1px !important;
    margin-top: 10px;
}
        .btn.ico-add.input.custom-mt-2 {
    margin-top: -1px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12"  class="maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_header" runat="server"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#"></a>Documentation</li>
                                <li><a href="#" title="">Ocean Imports</a> </li>

                                <li class="current"><a href="#" title="" id="headerlabel" runat="server">Direct BL</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>



                                       <div class="FixedButtons">
                       <div class="left_btn">
                           <div class="btn ico-proforma-sales-invoice">
                               <asp:Button ID="Proinvoic" runat="server" Text="Proforma Invoice" ToolTip="Proforma Invoice" TabIndex="36" OnClick="Proinvoic_Click" />
                           </div>
                           <div class="btn ico-proforma-purchase-invoice">
                               <asp:Button ID="procrednote" runat="server" Text="Proforma Purchase Operations" ToolTip="Proforma Purchase Operations" TabIndex="37" OnClick="procrednote_Click" />
                           </div>
                             <div class="btn ico-icd-cargo-declaration" id="Div1" runat="server">
     <asp:Button ID="btn_Customsdtl" runat="server" ToolTip="Customs Detail" TabIndex="33" OnClick="btn_Customsdtl_Click" />
 </div>
                          

                       </div>
                       <div class="right_btn">
                            <div class="btn ico-do">
    <asp:Button ID="btn_blrelease" runat="server" Text="BL Print" ToolTip="BL Print" TabIndex="45" OnClick="btn_blrelease_Click" />
</div>
                           <div class="btn ico-reuse">
                               <asp:Button ID="Btn_reuse" runat="server" Text="Reuse" ToolTip="Reuse" OnClick="Btn_reuse_Click" />
                           </div>
                           <div class="btn ico-save" id="btn_save1" runat="server">
                               <asp:Button ID="btn_save" runat="server" ToolTip="Save" TabIndex="33" OnClick="btn_save_Click" />
                           </div>
                           <div class="btn ico-view hide">
                               <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" TabIndex="34" OnClick="btn_view_Click" />
                           </div>
                           <div class="btn ico-delete">
                               <asp:Button ID="btn_delete" runat="server" Text="Delete" ToolTip="Delete" OnClientClick="javascript:return confirm('Do U want Delete ?');" OnClick="btn_delete_Click" />
                           </div>
                           <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                               <asp:Button ID="btn_cancel" runat="server" Text="Cancel" TabIndex="35" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                           </div>
                       </div>
                   </div>

                </div>
                <div class="widget-content">
                    




                    <div class="FormGroupContent4 boxmodal">
                        <div class="imgport">
                            <asp:Image ID="porflag" runat="server" Width="100%" />
                            <asp:Image ID="flagimg" runat="server" Width="100%" />

                            <asp:Image ID="podflag" runat="server" Width="100%" />
                            <asp:Image ID="fdflag" runat="server" Width="100%" />
                        </div>




                    </div>

                    <div class="FormGroupContent4">
                        <div class="ldiv">
                            <div class="FormGroupContent4 boxmodal">
                                <div class="BookingInput8">
                                    <span>Booking #</span>

                                    <asp:TextBox ID="txtbookno" TabIndex="3" runat="server" placeholder="" ToolTip="Booking Number" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="boxmodalLink_box">
                                    <asp:LinkButton ID="lbl_booking" runat="server" CssClass="anc ico-find-sm" Text="" ForeColor="Red" OnClick="lbl_booking_Click"></asp:LinkButton>
                                </div>


                                <div class="BusinessChk hide">
                                    <span class="chktext">Business Controlled By Us</span>
                                    <center>
                                        <label class="switch">
                                            <asp:CheckBox ID="chkNomination" TabIndex="32" runat="server" />
                                            <span class="slider round"></span>
                                        </label>
                                    </center>

                                </div>
                                <div class="BillOf">
                                    <asp:Label ID="Label2" runat="server" Text="Bill of Lading #"></asp:Label>
                                    <asp:TextBox ID="txt_blno" runat="server" CssClass="form-control" AutoPostBack="true" onkeyup="CheckTextLength(this,30);" TabIndex="4" OnTextChanged="txt_blno_TextChanged" placeholder="" ToolTip="Bill of Lading"></asp:TextBox>
                                </div>
                                <div class="btn ico-edit" id="btn" runat="server">
                                    <asp:Button ID="Btnamendbl" runat="server" ToolTip="Amend BL" TabIndex="41" OnClick="Btnamendbl_Click" />
                                </div>
                                <%--onkeypress="if (event.keyCode==39 ||event.keyCode==34) event.returnValue = false;"--%>
                                <div class="IssuedAt">
                                    <asp:Label ID="Label3" runat="server" Text="Issued At"></asp:Label>
                                    <asp:TextBox ID="txt_blissuseat" runat="server" CssClass="form-control" TabIndex="5" AutoPostBack="true" placeholder="" ToolTip="Issued At" OnTextChanged="txt_blissuseat_TextChanged"></asp:TextBox>
                                </div>
                                <div class="IssueCal">
                                    <asp:Label ID="Label5" runat="server" Text="Issued On"></asp:Label>
                                    <asp:TextBox ID="txt_issuedon" runat="server" CssClass="form-control" TabIndex="6" placeholder="" ToolTip="Issued On"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtdate" TargetControlID="txt_issuedon" runat="server" Format="dd/MM/yyyy" BehaviorID="txt_isddfdfsuedon" />
                                </div>
                                <div class="FreightDrop">
                                    <asp:Label ID="Label6" runat="server" Text="Freight"></asp:Label>
                                    <asp:DropDownList ID="ddlfreight" ToolTip="Freight" data-placeholder="Freight" runat="server" TabIndex="7" CssClass="chzn-select">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="BLSurender">
                                    <span class="chktext">BL Surrendered</span>
                                    <center>
                                        <label class="switch">
                                            <asp:CheckBox ID="chkBLSurr" TabIndex="31" runat="server" />

                                        </label>
                                    </center>
                                </div>
                                <div class="StatusDrop1">
                                    <asp:Label ID="Label20" runat="server" Text="Shipment"></asp:Label>
                                    <asp:DropDownList ID="ddlstatus" TabIndex="23" runat="server" ToolTip="Status" data-placeholder="Status" CssClass="chzn-select">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="FrieghtDetails hide">
                                    <asp:LinkButton ID="lnkfrght" runat="server" CssClass="anc ico-find-sm" Style="text-decoration: none;" ForeColor="Red" OnClick="lnkfrght_Click"></asp:LinkButton>
                                </div>

                            </div>

                            <div class="FormGroupContent4">

                                <div class="ShippInput boxmodal">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label8" runat="server" Text="Shipper"></asp:Label>
                                        <asp:TextBox ID="txtshipper" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="9" placeholder="" ToolTip="Shipper" OnTextChanged="txtshipper_TextChanged"></asp:TextBox>
                                    </div>

                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label30" runat="server" Text="Shipper Address"> </asp:Label>
                                        <asp:TextBox ID="txtsaddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Shipper Address"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="Consignee1 boxmodal">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label29" runat="server" Text="Consignee"></asp:Label>
                                        <asp:TextBox ID="txtconsignee" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="10" OnTextChanged="txtconsignee_TextChanged" placeholder="" ToolTip="Consignee"></asp:TextBox>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label31" runat="server" Text="Consignee Address"> </asp:Label>
                                        <asp:TextBox ID="txtcaddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Consignee Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4">

                                <div class="ShippInput boxmodal">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label9" runat="server" Text="Notify Party"></asp:Label>
                                        <asp:TextBox ID="txtnotify" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="11" OnTextChanged="txtnotify_TextChanged" placeholder=" " ToolTip="Notify Party"></asp:TextBox>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label32" runat="server" Text="Notify Address"> </asp:Label>
                                        <asp:TextBox ID="txtnaddress" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="" ToolTip="Notify Address"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="Consignee1 boxmodal">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label10" runat="server" Text="Agent"></asp:Label>
                                        <asp:TextBox ID="txtagent" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="12" OnTextChanged="txtagent_TextChanged" placeholder="" ToolTip="Agent"></asp:TextBox>
                                    </div>

                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label33" runat="server" Text="Agent Address"> </asp:Label>
                                        <asp:TextBox ID="txtaaddress" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="" ToolTip="Agent Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4 boxmodal">

                                <div class="PlaceInput">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label11" runat="server" Text="Place of Receipt"></asp:Label>
                                        <asp:TextBox ID="txtreceipt" TabIndex="13" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Place of Receipt" OnTextChanged="txtreceipt_TextChanged"></asp:TextBox>

                                    </div>



                                </div>
                                <div class="PortInput1">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label12" runat="server" Text="Port of Loading"></asp:Label>
                                        <asp:TextBox ID="txtpol" TabIndex="14" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Port of Loading" OnTextChanged="txtpol_TextChanged"></asp:TextBox>

                                    </div>


                                </div>
                                <div class="DisInput">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label13" runat="server" Text="Port of Discharge"></asp:Label>
                                        <asp:TextBox ID="txtpodis" TabIndex="15" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Port of Discharge" OnTextChanged="txtpodis_TextChanged"></asp:TextBox>

                                    </div>


                                </div>
                                <div class="FinalInput">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label14" runat="server" Text="Place of Delivery"></asp:Label>
                                        <asp:TextBox ID="txtfinaldes" TabIndex="16" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Place of Delivery" OnTextChanged="txtfinaldes_TextChanged"></asp:TextBox>

                                    </div>


                                </div>



                            </div>
                            <div class="FormGroupContent4">
                                <div class="CommInput">
                                    <asp:Label ID="Label7" runat="server" Text="Commodity"></asp:Label>
                                    <asp:TextBox ID="txtcargo" TabIndex="8" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="" ToolTip="Commodity" OnTextChanged="txtcargo_TextChanged"></asp:TextBox>
                                </div>
                                <div class="CubicInput4">
                                    <asp:Label ID="Label17" runat="server" Text="M3"></asp:Label>
                                    <asp:TextBox ID="txtcbm" runat="server" CssClass="form-control" TabIndex="20" placeholder="" ToolTip="M3"></asp:TextBox>
                                </div>
                                <div class="Number1">
                                    <asp:Label ID="Label21" runat="server" Text="Packages"></asp:Label>
                                    <asp:TextBox ID="txtpackage" runat="server" CssClass="form-control" TabIndex="24" onkeypress="return isNumberKey(event,'No of Pkg');" placeholder="" ToolTip="Number of Packages"></asp:TextBox>
                                </div>
                                <div class="Units1">
                                    <asp:Label ID="Label22" runat="server" Text="Units"></asp:Label>
                                    <asp:DropDownList ID="ddlunits" runat="server" TabIndex="25" CssClass="chzn-select" ToolTip="Units" data-placeholder="Units">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="GrossInput4">
                                    <asp:Label ID="Label18" runat="server" Text="Gr Wt(KGS)"></asp:Label>
                                    <asp:TextBox ID="txtgrossw" runat="server" CssClass="form-control" TabIndex="21" AutoPostBack="True" OnTextChanged="txtgrossw_TextChanged" placeholder="" ToolTip="Gross Weight Kgs"></asp:TextBox>
                                </div>
                                <div class="NetInput2">
                                    <asp:Label ID="Label19" runat="server" Text="Net Wt(KGS)"></asp:Label>
                                    <asp:TextBox ID="txtnetw" TabIndex="22" CssClass="form-control" runat="server" placeholder="" ToolTip="Net Weight Kgs"></asp:TextBox>
                                </div>

                                <div class="UNOCode">
                                    <asp:Label ID="Label26" runat="server" Text="Uno Code"></asp:Label>
                                    <asp:TextBox ID="txtUNOcode" runat="server" CssClass="form-control" TabIndex="29" placeholder="" ToolTip="Uno Code" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="IMOCode">
                                    <asp:Label ID="Label27" runat="server" Text="Imo Code"></asp:Label>
                                    <asp:TextBox ID="txtIMOCode" runat="server" CssClass="form-control" TabIndex="30" placeholder="" ToolTip="Imo Code" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MarkLeft1 boxmodal">
                                    <div class="Mark_Numbers">
                                        <asp:Label ID="Label15" runat="server" Text="Marks and Numbers"></asp:Label>
                                        <asp:TextBox ID="txtmarksnumbers" Style="resize: none;" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control" TabIndex="17" onkeyup="CheckTextLength(this,500);" placeholder="" ToolTip="Marks and Numbers"></asp:TextBox>
                                    </div>
                                    <div class="MarkRight2 boxmodal">
                                        <div class="">
                                            <div class="div_containerlist">
                                                <span>Container #</span>
                                                <asp:CheckBoxList ID="chkListCont" runat="server" TabIndex="19">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="Description">
                                        <asp:Label ID="Label16" runat="server" Text="Description"></asp:Label>
                                        <asp:TextBox ID="txtdescn" TextMode="MultiLine" Rows="2" runat="server" TabIndex="18" onkeyup="CheckTextLength(this,1500);" CssClass="form-control" placeholder="" ToolTip="Description"></asp:TextBox>
                                    </div>



                                    <div class="vsl">
                                        <div class="FormGroupContent4">
                                            <div class="CubicInput3">
                                                <asp:Label ID="Label23" runat="server" Text="Mother Vessel"></asp:Label>
                                                <asp:TextBox ID="txtMVessel" runat="server" CssClass="form-control" TabIndex="26" AutoPostBack="true" placeholder="" ToolTip="Mother Vessel" OnTextChanged="txtMVessel_TextChanged"></asp:TextBox>
                                            </div>
                                            <div class="GrossInput3">
                                                <asp:Label ID="Label24" runat="server" Text="Mother Voyage"></asp:Label>
                                                <asp:TextBox ID="txtMVoy" runat="server" CssClass="form-control" TabIndex="27" placeholder="" ToolTip="Mother Voyage"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <div class="NetInput1">
                                                <asp:Label ID="Label25" runat="server" Text="Transhipped At"></asp:Label>
                                                <asp:TextBox ID="txtTranshipped" runat="server" TabIndex="28" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Transhipped At" OnTextChanged="txtTranshipped_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <div class="Remark1">
                                                <asp:Label ID="Label28" runat="server" Text="Remarks"></asp:Label>
                                                <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" TabIndex="30" onkeyup="CheckTextLength(this,100);" placeholder="" ToolTip="Remarks"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>



                                </div>

                            </div>


                            <%--  <div class="FormGroupContent4">

                  </div>--%>
                            <div class="FormGroupContent4">

                                <div class="FWDBL">
                                    <asp:Label ID="lblFwdBL" runat="server" Style="text-decoration: none;" ForeColor="Red"></asp:Label>
                                </div>
                            </div>





                        </div>
                        <div class="rdiv">
                            <div class="FormGroupContent4">
                                <div class="JobInput14 inputborder">
                                    <span>Job #</span>

                                    <asp:TextBox ID="txtjobno" runat="server" TabIndex="1" AutoPostBack="true" placeholder="" ToolTip="Job Number" CssClass="form-control inputcolor" OnTextChanged="txtjobno_TextChanged"></asp:TextBox>
                                </div>
                                <div class="boxmodalLink_box">
                                    <asp:LinkButton ID="Label_2" CssClass="anc ico-find-sm" runat="server" ForeColor="Red" Style="text-decoration: none;" OnClick="Label_2_Click"></asp:LinkButton>
                                </div>
                                <div class="btn ico-add input custom-mt-2">
                                    <asp:Button ID="btn_job" runat="server" Text="Job" ToolTip="Job" TabIndex="45" OnClick="btn_job_Click" />
                                </div>


                                <div class="JobDetails2 inputborder">
                                    <asp:Label ID="Label_1" runat="server" Text="Job Details"></asp:Label>
                                    <asp:TextBox ID="txtCaption" runat="server" TabIndex="2" placeholder="" ToolTip="Job Details" CssClass="form-control inputcolor"></asp:TextBox>
                                </div>

                            </div>









                            <div class="FormGroupContent4">
                                <div class="Job_type inputborder">
                                    <span>Job Type</span>
                                    <asp:TextBox runat="server" ID="txt_jobtype" CssClass="form-control inputcolor" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MBLNum inputborder">
                                    <span>MBL #</span>
                                    <asp:TextBox runat="server" ID="mbl" CssClass="form-control inputcolor" TabIndex="32" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MBLStatus inputborder">
                                    <span>MBL Status</span>
                                    <asp:TextBox runat="server" ID="mblstatus" CssClass="form-control inputcolor" TabIndex="33" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="Versel inputborder">
                                    <span>Vessel</span>
                                    <asp:TextBox ID="vessel" runat="server" CssClass="form-control inputcolor" TabIndex="25" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="POL inputborder" style="float: left">
                                    <span>Vessel PoL</span>
                                    <asp:TextBox runat="server" ID="pol" CssClass="form-control inputcolor" TabIndex="26" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="ETD inputborder">
                                    <span>ETD</span>
                                    <asp:TextBox runat="server" ID="etd" CssClass="form-control inputcolor" TabIndex="27" ReadOnly="true" />
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="etd"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal">



                                <div class="POD inputborder">
                                    <span>Vessel PoD</span>
                                    <asp:TextBox runat="server" ID="pod" CssClass="form-control inputcolor" TabIndex="28" ReadOnly="true" />
                                </div>






                            </div>
                            <div class="FormGroupContent4 ">
                                <div class="ETA inputborder">
                                    <span>ETA</span>
                                    <asp:TextBox runat="server" ID="eta" CssClass="form-control inputcolor" TabIndex="29" ReadOnly="true" />
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="eta"></asp:CalendarExtender>
                                </div>
                            </div>



                            <div class="FormGroupContent4">
                                <div class="MLO inputborder">
                                    <span>MLO</span>
                                    <asp:TextBox runat="server" ID="mlo" CssClass="form-control inputcolor" TabIndex="30" ReadOnly="true" />
                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <div class="Carrier inputborder">
                                    <span>Carrier</span>
                                    <asp:TextBox runat="server" ID="carrier" CssClass="form-control inputcolor" TabIndex="31" ReadOnly="true" />
                                </div>
                            </div>
                        </div>
                    </div>



                    <div class="FormGroupContent4">
                        <%-- popup --%>
                        <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="bclose" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                                    <asp:GridView ID="Grd_Job" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_Job_RowDataBound" CssClass="Grid FixedHeader"
                                        ForeColor="Black" PageSize="22" AllowPaging="false" OnPageIndexChanging="Grd_Job_PageIndexChanging" OnSelectedIndexChanged="Grd_Job_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job#">
                                                <HeaderStyle Width="65px" />
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="JobType" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                        <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="55px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Vessel" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="POL" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                        <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="POD" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="pod" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MBL#" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MLO" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ETB" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="etb" runat="server" Text='<%# Bind("etb") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ETA" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                        <asp:Label ID="eta" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="60px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                      <HeaderStyle Width ="20px"/>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                    <div class="div_break"></div>
                                    <div class="Break"></div>
                                    <asp:Label ID="hidlabel" runat="server"></asp:Label>
                                    <asp:ModalPopupExtender runat="server" ID="popup_Grd" BehaviorID="programmaticModalPopupBehavior"
                                        PopupControlID="pln_popup" CancelControlID="bclose" TargetControlID="hidlabel"
                                        DropShadow="false" RepositionMode="RepositionOnWindowScroll">
                                    </asp:ModalPopupExtender>

                                    <asp:GridView ID="Grd_Booking" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_Booking_RowDataBound"
                                        ForeColor="Black" EmptyDataText="No Record Found" DataKeyNames="shipperid,bookno" PageSize="22" AllowPaging="false"
                                        OnPageIndexChanging="Grd_Booking_PageIndexChanging" BackColor="White" OnSelectedIndexChanged="Grd_Booking_SelectedIndexChanged">

                                        <Columns>
                                            <asp:BoundField DataField="BookingNo" HeaderText="Booking#" />
                                            <asp:BoundField DataField="bookingdate" HeaderText="Bookingdate" />
                                            <asp:BoundField DataField="CustomerName" HeaderText="Customer" />
                                            <asp:BoundField DataField="POL" HeaderText="POL" />
                                            <asp:BoundField DataField="POD" HeaderText="POD" />
                                            <asp:BoundField DataField="bookno" HeaderText="Book no" />
                                            <asp:BoundField DataField="fstatus" HeaderText="Status" Visible="false" />
                                            <asp:BoundField DataField="shipperid" HeaderText="ShipperID" Visible="false" />
                                            <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_Book" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                          
                        </ItemTemplate>
                        
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

                        <%-- popup grdMBLDetails --%>
                        <asp:Panel ID="PanelMBLDetails" runat="server" CssClass="modalPopup" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel1">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel3" runat="server" CssClass=" Gridpnl">

                                    <asp:GridView ID="grdMBLDetails" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" OnRowDataBound="grdMBLDetails_RowDataBound" OnSelectedIndexChanged="grdMBLDetails_SelectedIndexChanged"
                                        ForeColor="Black" PageSize="22" AllowPaging="false">

                                        <Columns>

                                            <asp:BoundField DataField="blno" HeaderText="BL #">
                                                <HeaderStyle Width="65px" />
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="BL Date" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                                        <asp:Label ID="bldate" runat="server" Text='<%# Bind("bldate") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="75px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="consignee" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="consignee" runat="server" Text='<%# Bind("consignee") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="103px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="freight" runat="server" Text='<%# Bind("freight") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="102px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="POD" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label ID="portname" runat="server" Text='<%# Bind("portname") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="162px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                    <div class="div_break"></div>
                                </asp:Panel>
                                <div class="Break"></div>
                            </div>
                        </asp:Panel>

                        <asp:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="programmaticModalPopupBehavior1"
                            PopupControlID="PanelMBLDetails" CancelControlID="Image1" TargetControlID="Label1"
                            DropShadow="false" RepositionMode="RepositionOnWindowScroll">
                        </asp:ModalPopupExtender>

                        <asp:Label ID="Label1" runat="server"></asp:Label>

                        <asp:TextBox ID="txt_vessel" runat="server" Visible="false" BorderColor="#999997"></asp:TextBox>
                        <asp:TextBox ID="txt_voyage" runat="server" Visible="false" BorderColor="#999997"></asp:TextBox>
                        <asp:TextBox ID="txt_container" runat="server" Visible="false" BorderColor="#999997"></asp:TextBox>

                    </div>









                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>BL # :</label>

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
                </div>

            </div>
        </div>
    </div>

    <asp:Label ID="Label4" runat="server"></asp:Label>
    <asp:Label ID="Label34" runat="server"></asp:Label>
      <asp:Label ID="Label35" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image2" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:Panel ID="pnl_emp" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <asp:Panel ID="pnl_emp1" runat="server" CssClass="">
                <iframe id="iframecost" runat="server" frameborder="0"></iframe>
            </asp:Panel>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="pop_up" runat="server" PopupControlID="pnl_emp" DropShadow="false"
        TargetControlID="Label34" CancelControlID="Close_voucher" BehaviorID="Test2">
    </asp:ModalPopupExtender>


     <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
     <div class="divRoated">
         <div class="DivSecPanel">
             <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
         </div>
         <asp:Panel ID="Panel5" runat="server" CssClass="">
             <iframe id="iframe1" runat="server" frameborder="0"></iframe>
         </asp:Panel>
     </div>
 </asp:Panel>
 <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel4" DropShadow="false"
     TargetControlID="Label35" CancelControlID="Close_voucher" BehaviorID="Test3">
 </asp:ModalPopupExtender>


    <asp:HiddenField ID="hiddenid" runat="server" />
    <asp:HiddenField ID="hiddenid_issue" runat="server" />
    <asp:HiddenField ID="Hiddenshipper" runat="server" />
    <asp:HiddenField ID="Hiddenconsignee" runat="server" />
    <asp:HiddenField ID="Hiddennotify" runat="server" />
    <asp:HiddenField ID="Hiddenagent" runat="server" />
    <asp:HiddenField ID="Hiddenrecipt" runat="server" />
    <asp:HiddenField ID="Hiddenpol" runat="server" />
    <asp:HiddenField ID="hiddencharge" runat="server" />
    <asp:HiddenField ID="Hiddentxtfinaldes" runat="server" />

    <asp:HiddenField ID="hiddenidtrans" runat="server" />
    <asp:HiddenField ID="hiddencargo" runat="server" />
    <asp:HiddenField ID="hid_jobtype" runat="server" />
    <asp:HiddenField ID="hidintCont40" runat="server" />
    <asp:HiddenField ID="Hiddensalespid" runat="server" />
    <asp:HiddenField ID="Hiddencargoid" runat="server" />
    <asp:HiddenField ID="hidintCont20" runat="server" />
    <asp:HiddenField ID="Hiddenvessel" runat="server" />
    <asp:HiddenField ID="hiddenjobagentid" runat="server" />
    <asp:HiddenField ID="hiddenjobpolid" runat="server" />
    <asp:HiddenField ID="hiddenjobpodid" runat="server" />
    <asp:HiddenField ID="hd_jobno" runat="server" />
    <asp:HiddenField ID="hidstrSBL" runat="server" />
    <asp:HiddenField ID="hid_reuse" runat="server" />
    <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    <asp:HiddenField ID="hid_intcustomerid" runat="server" />
    <asp:HiddenField ID="hid_quto" runat="server" />
    <asp:HiddenField ID="hid_intagent" runat="server" />
    <asp:HiddenField ID="HIDMAWBLNO" runat="server" />
    <asp:HiddenField ID="hid_douvolume" runat="server" />
    <asp:HiddenField ID="hid_fd" runat="server" />
    <asp:HiddenField ID="hid_buyingno" runat="server" />

    <asp:HiddenField ID="Hiddenconsignee1" runat="server" />

    <asp:HiddenField ID="hid_SupplyTo1" runat="server" />

</asp:Content>
