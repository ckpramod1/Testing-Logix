<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="JobInfoCha.aspx.cs" Inherits="logix.CHA.JobInfoCha" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->
    <script src="../js/helper.js"></script>
    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

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










    <link href="../Styles/JobInfoCha.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/Calendar.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtShiper.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_shipper.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetCustomer",
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

                    <%--  select: function (event, i) {
                        $("#<%=txtShiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtShiper.ClientID %>").change();
                        $("#<%=hid_shipper.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtShiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_shipper.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtShiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_shipper.ClientID %>").val(i.item.val);

                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txtShiper.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtShiper.ClientID %>").val($.trim(result));

                    },--%>

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtShiper.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_shipper.ClientID %>").val(i.item.val);
                            $("#<%=txtShiper.ClientID %>").change();
                            $("#<%=txtShiper.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtShiper.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_shipper.ClientID %>").val(i.item.val);
                            $("#<%=txtShiper.ClientID %>").val($.trim(result));
                            $("#<%=txtShiper.ClientID %>").val(i.item.address);
                        }

                    },
                   <%-- change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtShiper.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_shipper.ClientID %>").val(i.item.val);
                            $("#<%=txtShiper.ClientID %>").val(i.item.address);


                        }
                    },--%>

                    close: function (event, i) {
                        <%-- var result = $("#<%=txtShiper.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtShiper.ClientID %>").val($.trim(result));--%>
                        var result = $("#<%=txtShiper.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtShiper.ClientID %>").val($.trim(result));
                        } else if (out == "") {
                            $("#<%=txtShiper.ClientID %>").val($.trim(res));
                        } else {
                            $("#<%=txtShiper.ClientID %>").val($.trim(out));
                        }

                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtConsignee.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_consignee.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetCustomer",
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

                    <%--  select: function (event, i) {
                        $("#<%=txtConsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                         $("#<%=txtConsignee.ClientID %>").change();
                         $("#<%=hid_consignee.ClientID %>").val(i.item.val);
                     },
                    focus: function (event, i) {
                        $("#<%=txtConsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_consignee.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtConsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_consignee.ClientID %>").val(i.item.val);

                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txtConsignee.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtConsignee.ClientID %>").val($.trim(result));

                    },--%>
                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtConsignee.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_consignee.ClientID %>").val(i.item.val);
                            $("#<%=txtConsignee.ClientID %>").change();
                            $("#<%=txtConsignee.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtConsignee.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_consignee.ClientID %>").val(i.item.val);
                            $("#<%=txtConsignee.ClientID %>").val($.trim(result));
                            $("#<%=txtConsignee.ClientID %>").val(i.item.address);
                        }

                    },
                  <%--  change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtConsignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_consignee.ClientID %>").val(i.item.val);
                            $("#<%=txtConsignee.ClientID %>").val(i.item.address);


                        }
                    },--%>

                    close: function (event, i) {
                        <%-- var result = $("#<%=txtConsignee.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtConsignee.ClientID %>").val($.trim(result));--%>
                        var result = $("#<%=txtConsignee.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtConsignee.ClientID %>").val($.trim(result));
                    } else if (out == "") {
                        $("#<%=txtConsignee.ClientID %>").val($.trim(res));
                    } else {
                        $("#<%=txtConsignee.ClientID %>").val($.trim(out));
                        }
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtNotifyParty.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Notify.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetCustomer",
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

                    <%--  select: function (event, i) {
                        $("#<%=txtNotifyParty.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtNotifyParty.ClientID %>").change();
                        $("#<%=hid_Notify.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtNotifyParty.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_Notify.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtNotifyParty.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Notify.ClientID %>").val(i.item.val);

                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txtNotifyParty.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtNotifyParty.ClientID %>").val($.trim(result));

                    },--%>
                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtNotifyParty.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_Notify.ClientID %>").val(i.item.val);
                            $("#<%=txtNotifyParty.ClientID %>").change();
                            $("#<%=txtNotifyParty.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtNotifyParty.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_Notify.ClientID %>").val(i.item.val);
                            $("#<%=txtNotifyParty.ClientID %>").val($.trim(result));
                            $("#<%=txtNotifyParty.ClientID %>").val(i.item.address);
                        }

                    },
                   <%-- change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtNotifyParty.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Notify.ClientID %>").val(i.item.val);
                            $("#<%=txtNotifyParty.ClientID %>").val(i.item.address);


                        }
                    },--%>

                    close: function (event, i) {
                        <%--  var result = $("#<%=txtNotifyParty.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtNotifyParty.ClientID %>").val($.trim(result));--%>
                        var result = $("#<%=txtNotifyParty.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtNotifyParty.ClientID %>").val($.trim(result));
                } else if (out == "") {
                    $("#<%=txtNotifyParty.ClientID %>").val($.trim(res));
                } else {
                    $("#<%=txtNotifyParty.ClientID %>").val($.trim(out));
                        }
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtPrincipal.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Principal.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetCustomer",
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

                    <%-- select: function (event, i) {
                        $("#<%=txtPrincipal.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                         $("#<%=txtPrincipal.ClientID %>").change();
                         $("#<%=hid_Principal.ClientID %>").val(i.item.val);
                     },
                    focus: function (event, i) {
                        $("#<%=txtPrincipal.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_Principal.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPrincipal.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Principal.ClientID %>").val(i.item.val);

                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txtPrincipal.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPrincipal.ClientID %>").val($.trim(result));

                    },--%>
                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPrincipal.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_Principal.ClientID %>").val(i.item.val);
                            $("#<%=txtPrincipal.ClientID %>").change();
                            $("#<%=txtPrincipal.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPrincipal.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_Principal.ClientID %>").val(i.item.val);
                            $("#<%=txtPrincipal.ClientID %>").val($.trim(result));
                            $("#<%=txtPrincipal.ClientID %>").val(i.item.address);
                        }

                    },
                   <%-- change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPrincipal.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Principal.ClientID %>").val(i.item.val);
                            $("#<%=txtPrincipal.ClientID %>").val(i.item.address);


                        }
                    },--%>

                    close: function (event, i) {
                        <%-- var result = $("#<%=txtPrincipal.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPrincipal.ClientID %>").val($.trim(result));--%>
                        var result = $("#<%=txtPrincipal.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtPrincipal.ClientID %>").val($.trim(result));
                } else if (out == "") {
                    $("#<%=txtPrincipal.ClientID %>").val($.trim(res));
                } else {
                    $("#<%=txtPrincipal.ClientID %>").val($.trim(out));
                        }
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtPic.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_pic.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetPic",
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
                        $("#<%=txtPic.ClientID %>").val($.trim(i.item.label));
                        $("#<%=txtPic.ClientID %>").change();
                        $("#<%=hid_pic.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPic.ClientID %>").val($.trim(i.item.label));
                        $("#<%=hid_pic.ClientID %>").val(i.item.val);
                    },
                    <%--change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPic.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_pic.ClientID %>").val(i.item.val);

                        }

                    },--%>
                    close: function (event, i) {
                        <%-- var result = $("#<%=txtPic.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPic.ClientID %>").val($.trim(result));--%>

                        var result = $("#<%=txtPic.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtPic.ClientID %>").val($.trim(result));
                } else if (out == "") {
                    $("#<%=txtPic.ClientID %>").val($.trim(res));
                } else {
                    $("#<%=txtPic.ClientID %>").val($.trim(out));
                        }

                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtPol.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_pol.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetPol",
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
                        $("#<%=txtPol.ClientID %>").val($.trim(i.item.label));
                        $("#<%=txtPol.ClientID %>").change();
                        $("#<%=hid_pol.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPol.ClientID %>").val($.trim(i.item.label));
                        $("#<%=hid_pol.ClientID %>").val(i.item.val);
                    },
                   <%-- change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPol.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_pol.ClientID %>").val(i.item.val);

                        }

                    },--%>
                    close: function (event, i) {
                        <%-- var result = $("#<%=txtPol.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPol.ClientID %>").val($.trim(result));--%>

                        var result = $("#<%=txtPol.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtPol.ClientID %>").val($.trim(result));
                } else if (out == "") {
                    $("#<%=txtPol.ClientID %>").val($.trim(res));
                } else {
                    $("#<%=txtPol.ClientID %>").val($.trim(out));
                        }

                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtPod.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_pod.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetPod",
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
                        $("#<%=txtPod.ClientID %>").val($.trim(i.item.label));
                        $("#<%=txtPod.ClientID %>").change();
                        $("#<%=hid_pod.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtPod.ClientID %>").val($.trim(i.item.label));
                        $("#<%=hid_pod.ClientID %>").val(i.item.val);
                    },
                    <%--change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPod.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_pod.ClientID %>").val(i.item.val);

                        }

                    },--%>
                    close: function (event, i) {
                       <%-- var result = $("#<%=txtPod.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPod.ClientID %>").val($.trim(result));--%>
                        var result = $("#<%=txtPod.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtPod.ClientID %>").val($.trim(result));
                } else if (out == "") {
                    $("#<%=txtPod.ClientID %>").val($.trim(res));
                } else {
                    $("#<%=txtPod.ClientID %>").val($.trim(out));
                        }
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtFd.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Fd.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetFd",
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
                        $("#<%=txtFd.ClientID %>").val($.trim(i.item.label));
                        $("#<%=txtFd.ClientID %>").change();
                        $("#<%=hid_Fd.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtFd.ClientID %>").val($.trim(i.item.label));
                        $("#<%=hid_Fd.ClientID %>").val(i.item.val);
                    },
                    <%--change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtFd.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Fd.ClientID %>").val(i.item.val);

                        }

                    },--%>
                    close: function (event, i) {
                        <%--var result = $("#<%=txtFd.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtFd.ClientID %>").val($.trim(result));--%>

                        var result = $("#<%=txtFd.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtFd.ClientID %>").val($.trim(result));
                } else if (out == "") {
                    $("#<%=txtFd.ClientID %>").val($.trim(res));
                } else {
                    $("#<%=txtFd.ClientID %>").val($.trim(out));
                        }

                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtCustomer.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_customer.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/JobInfoCha.aspx/GetCustomer",
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

                    <%-- select: function (event, i) {
                        $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtCustomer.ClientID %>").change();
                        $("#<%=hid_customer.ClientID %>").val(i.item.val);
                        $("#<%=txtCustomer.ClientID %>").val(i.item.address);
                    },
                    focus: function (event, i) {
                        $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_customer.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_customer.ClientID %>").val(i.item.val);

                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txtCustomer.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtCustomer.ClientID %>").val($.trim(result));

                    },--%>
                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_customer.ClientID %>").val(i.item.val);
                            $("#<%=txtCustomer.ClientID %>").change();
                            $("#<%=txtCustomer.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label));
                            $("#<%=hid_customer.ClientID %>").val(i.item.val);
                            $("#<%=txtCustomer.ClientID %>").val($.trim(result));
                            $("#<%=txtCustomer.ClientID %>").val(i.item.address);
                        }

                    },
                   <%-- change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=hid_customer.ClientID %>").val(i.item.val);
                          $("#<%=txtCustomer.ClientID %>").val(i.item.address);


                      }
                  },--%>

                    close: function (event, i) {
                        <%-- var result = $("#<%=txtCustomer.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtCustomer.ClientID %>").val($.trim(result));--%>
                        var result = $("#<%=txtCustomer.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (res == "" && out == "") {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(result));
                } else if (out == "") {
                    $("#<%=txtCustomer.ClientID %>").val($.trim(res));
                } else {
                    $("#<%=txtCustomer.ClientID %>").val($.trim(out));
                        }

                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

    <script type="text/javascript">

        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alertify.alert(err.Description);
            }
        }

    </script>

    <style type="text/css">
        .ChkBox {
            width: 15%;
            float: right;
            margin: 0px 0px 0px 0.5%;
        }

        modalBackground {
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

        /*.modalPopupss {
             background-color:#FFFFFF; 
            /*border-width:1px;
            border-style:solid; 
            border-color:#CCCCCC;             
            width: 885px;
            Height:475px; 
            margin-left:0%;
            margin-top:-1.5%;
          /*padding:1px;            
            display:none;
        }

        .Gridpnl {
            width: 880px;
            Height:560px;*/


        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_pnlJobAE {
            top: 41px !important;
            left: 11px !important;
        }

        /*LOG DETAILS CSS*/
        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
            width: 97.7%;
            height: 500px;
            margin-left: 1%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }

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
            width: 11%;
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

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .FormGroupContent4 label {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .JobInput20 {
            width: 5.5%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        .DocInput2 {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 50%;
        }

        .ChkBox {
            width: 15%;
            float: right;
            margin: 18px 0px 0px 0.5%;
        }

        .widget.box .widget-content {
            top: 0px !important;
            padding-top: 65px;
        }

        a#logix_CPH_lnkJob {
            float: right;
        }

        .ToDateCal {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AirDrop {
            float: right;
            margin: 0px;
            width: 9.5%;
        }
        div#logix_CPH_ddlPackages_chzn {
    width: 100% !important;
}
        .BagDrop2 {
    width: 19%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblJobinfo" runat="server" Text="Job Info"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Custom Home Agent</a> </li>
                                <li><a href="#" title="">Shipment Details</a> </li>
                                <li class="current"><a href="#" title="">Job Info</a> </li>
                            </ul>
                        </div>
                        <!-- Breadcrumbs line End -->
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails1" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails1_Click"></asp:LinkButton>
                    </div>
                    <div class="FixedButtons">
                        <div class="right_btn">
                            <div class="btn ico-reuse">
                                <asp:Button ID="Btn_reuse" runat="server" ToolTip="Reuse" OnClick="Btn_reuse_Click" TabIndex="26" />
                            </div>
                            <div class="btn ico-save" id="btnSave1" runat="server">
                                <asp:Button ID="btnSave" runat="server" ToolTip="Save" OnClick="btnSave_Click" TabIndex="26" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btnView" runat="server" ToolTip="View" OnClick="btnView_Click" TabIndex="27" />
                            </div>
                            <div class="btn ico-back" id="btnCancel1" runat="server">
                                <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" TabIndex="28" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="ToDateCal" style="float: right">
                            <asp:Label ID="Label2" runat="server" Text="Job Date"> </asp:Label>
                            <asp:TextBox ID="txtJobDate" runat="server" ToolTip="Job Date" placeholder="" CssClass="form-control" ReadOnly="true" TabIndex="2"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtJobDate"></asp:CalendarExtender>
                        </div>
                        <div class="AirDrop">
                            <asp:Label ID="Label6" runat="server" Text="Job Type"> </asp:Label>
                            <asp:DropDownList ID="ddlJobType" runat="server" CssClass="chzn-select" data-placeholder="Job Type" ToolTip="Job Type" TabIndex="5">
                                <asp:ListItem Text="" Value="0" />
                            </asp:DropDownList>
                        </div>
                        <asp:LinkButton ID="lnkJob" runat="server" OnClick="lnkJob_Click" CssClass="anc ico-find-sm"></asp:LinkButton>

                        <div class="JobInput20">
                            <asp:Label ID="Label27" runat="server" Text="Job #"> </asp:Label>

                            <asp:TextBox ID="txtJob" runat="server" ToolTip="Job #" placeholder=" " AutoPostBack="true" CssClass="form-control" OnTextChanged="txtJob_TextChanged" TabIndex="1"></asp:TextBox>
                        </div>


                        <div class="DocInput2">
                            <asp:Label ID="Label3" runat="server" Text="Doc #"> </asp:Label>
                            <asp:TextBox ID="txtDoc" runat="server" ToolTip="Doc #" placeholder="" CssClass="form-control" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="ToDateCal">
                            <asp:Label ID="Label5" runat="server" Text="Doc Date"> </asp:Label>
                            <asp:TextBox ID="txtDocDate" runat="server" ToolTip="Doc Date" placeholder="" CssClass="form-control" TabIndex="4"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDocDate"></asp:CalendarExtender>
                        </div>

                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label7" runat="server" Text="MDoc#"> </asp:Label>
                            <asp:TextBox ID="txtMDoc" runat="server" ToolTip="MDoc#" placeholder="" CssClass="form-control" TabIndex="6" AutoPostBack="true" OnTextChanged="txtMDoc_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label9" runat="server" Text="Vessel / Flight / Truck"> </asp:Label>
                            <asp:TextBox ID="txtVesselFlightTruck" runat="server" ToolTip="Vessel / Flight / Truck" placeholder="" CssClass="form-control" TabIndex="7"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label8" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txtCustomer" runat="server" ToolTip="Customer" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCustomer_TextChanged" TabIndex="8"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label26" runat="server" Text="Shipper"> </asp:Label>

                            <asp:TextBox ID="txtShiper" runat="server" ToolTip="Shipper" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtShiper_TextChanged" TabIndex="9"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label10" runat="server" Text="Consignee"> </asp:Label>
                            <asp:TextBox ID="txtConsignee" runat="server" ToolTip="Consignee" placeholder="" CssClass="form-control" OnTextChanged="txtConsignee_TextChanged" AutoPostBack="true" TabIndex="10"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label11" runat="server" Text="Notify Party"> </asp:Label>
                            <asp:TextBox ID="txtNotifyParty" runat="server" ToolTip="Notify Party" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNotifyParty_TextChanged" TabIndex="11"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label12" runat="server" Text="Principal"> </asp:Label>
                            <asp:TextBox ID="txtPrincipal" runat="server" ToolTip="Principal" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPrincipal_TextChanged" TabIndex="12"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label13" runat="server" Text="Sales Person"> </asp:Label>
                            <asp:TextBox ID="txtPic" runat="server" ToolTip="PIC" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPic_TextChanged" TabIndex="13"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="PolInput10">
                            <asp:Label ID="Label14" runat="server" Text="PoL"> </asp:Label>
                            <asp:TextBox ID="txtPol" runat="server" ToolTip="PoL" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPol_TextChanged" TabIndex="14"></asp:TextBox>
                        </div>
                        <div class="PolInput11">
                            <asp:Label ID="Label15" runat="server" Text="PoD"> </asp:Label>
                            <asp:TextBox ID="txtPod" runat="server" ToolTip="PoD" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPod_TextChanged" TabIndex="15"></asp:TextBox>
                        </div>
                        <div class="PolInput12">
                            <asp:Label ID="Label16" runat="server" Text="FD"> </asp:Label>
                            <asp:TextBox ID="txtFd" runat="server" ToolTip="FD" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFd_TextChanged" TabIndex="16"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label17" runat="server" Text="Cargo"> </asp:Label>
                        <asp:TextBox ID="txtCargo" runat="server" ToolTip="Cargo" placeholder="" CssClass="form-control" TabIndex="17"></asp:TextBox>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label18" runat="server" Text="Documents"> </asp:Label>
                        <asp:TextBox ID="txtDocuments" runat="server" ToolTip="Documents" placeholder="" CssClass="form-control" TabIndex="18"></asp:TextBox>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Packages1">
                            <asp:Label ID="Label19" runat="server" Text="Units"> </asp:Label>
                            <asp:TextBox ID="txtPackages" runat="server" ToolTip="Packages" placeholder="" CssClass="form-control" TabIndex="19"></asp:TextBox>
                        </div>
                        <div class="BagDrop2">
                            <asp:Label ID="Label20" runat="server" Text="UoM"> </asp:Label>
                            <asp:DropDownList ID="ddlPackages" runat="server" CssClass="chzn-select" data-placeholder="Packages" ToolTip="Packages" TabIndex="20">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="ContractDrop" style="display: none;">
                            <asp:Label ID="Label21" runat="server" Text="ProfitShareJob"> </asp:Label>
                            <asp:DropDownList ID="ddl_DropCHA" runat="server" data-placeholder="ProfitShareJob" CssClass="chzn-select" ToolTip="ProfitShareJob" TabIndex="21">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Value="O">Our Job</asp:ListItem>
                                <asp:ListItem Value="P">Profit Share</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="Volume1new">
                            <asp:Label ID="Label22" runat="server" Text="Volume"> </asp:Label>
                            <asp:TextBox ID="txtVolume" runat="server" ToolTip="Volume" placeholder="" CssClass="form-control" TabIndex="22"></asp:TextBox>
                        </div>
                        <div class="Volume2new">
                            <asp:Label ID="Label23" runat="server" Text="Volume Type"> </asp:Label>
                            <asp:TextBox ID="txtVolume1" runat="server" ToolTip="Volume Type" placeholder="" onkeypress="return onlyAlphabets(event,this);" CssClass="form-control" TabIndex="23"></asp:TextBox>
                        </div>
                        <div class="Gross1new">
                            <asp:Label ID="Label24" runat="server" Text="Gross Weight"> </asp:Label>
                            <asp:TextBox ID="txtGrossWeight" runat="server" ToolTip="Gross Weight" placeholder="" CssClass="form-control" TabIndex="24"></asp:TextBox>
                        </div>
                        <div class="NetWeightnew">
                            <asp:Label ID="Label25" runat="server" Text="Net Weight"> </asp:Label>
                            <asp:TextBox ID="txtNetWeight" runat="server" ToolTip="Net Weight" placeholder="" CssClass="form-control" TabIndex="25"></asp:TextBox>
                        </div>

                        <div class="ChkBox hide">
                            <asp:CheckBox ID="CHk_DropAIR" runat="server" Width="100%"
                                Text="Profit Share Job" AutoPostBack="True" />
                        </div>
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
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog" DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hid_shipper" runat="server" />
    <asp:HiddenField ID="hid_consignee" runat="server" />
    <asp:HiddenField ID="hid_Notify" runat="server" />
    <asp:HiddenField ID="hid_Principal" runat="server" />
    <asp:HiddenField ID="hid_pic" runat="server" />
    <asp:HiddenField ID="hid_pol" runat="server" />
    <asp:HiddenField ID="hid_pod" runat="server" />
    <asp:HiddenField ID="hid_Fd" runat="server" />

    <asp:HiddenField ID="hid_customer" runat="server" />

    <asp:HiddenField ID="hid_Date" runat="server" />

    <asp:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="Label1" BehaviorID="programmaticModalPopupBehavior1"
        PopupControlID="pnlJobAE" DropShadow="false"
        CancelControlID="imgfgok">
    </asp:ModalPopupExtender>

    <asp:Panel ID="pnlJobAE" runat="server" CssClass="modalPopup" Style="display: none;">

        <div class="DivSecPanel">
            <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>

        <asp:Panel ID="Panel3" runat="server" Visible="false" CssClass="Gridpnl">

            <asp:GridView ID="grdJob" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="false"
                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="18" CssClass="Grid FixedHeader" OnPageIndexChanging="grdJob_PageIndexChanging" OnSelectedIndexChanged="grdJob_SelectedIndexChanged" OnRowDataBound="grdJob_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Job#" HeaderText="Job#">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JobType" HeaderText="JobType">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Doc#" HeaderText="Doc#">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DocDate" HeaderText="DocDate">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Mode" HeaderText="Mode">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />

                <RowStyle Font-Italic="False" />
            </asp:GridView>
        </asp:Panel>


        <div class="div_Break"></div>




        <asp:Panel ID="Panel4" runat="server" Visible="false" CssClass="Gridpnl">

            <asp:GridView ID="Grd_reuse" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="false"
                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="18" CssClass="Grid FixedHeader" OnPageIndexChanging="Grd_reuse_PageIndexChanging" OnSelectedIndexChanged="Grd_reuse_SelectedIndexChanged" OnRowDataBound="Grd_reuse_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Job#" HeaderText="Job#">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JobType" HeaderText="JobType">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Doc#" HeaderText="Doc#">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DocDate" HeaderText="DocDate">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Mode" HeaderText="Mode">
                        <HeaderStyle Width="83px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />

                <RowStyle Font-Italic="False" />
            </asp:GridView>
        </asp:Panel>
    </asp:Panel>
    <div class="div_Break"></div>

    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:HiddenField ID="hd_pack" runat="server" />


</asp:Content>
