<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Customer.aspx.cs" Inherits="logix.CRMNew.Customer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
       <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
 
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
    <link href="../Theme/assets/css/systemcrmnewcs.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

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

    <!-- Demo JS -->
    <%--<script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>--%>
    <link href="../Styles/TeleCallDetails.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Customercrm.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/MasterCustomer.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/MasterCustomerProspective.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
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
    </style>
    <style type="text/css">
        .EmailInputNew {
            width: 29.4%;
            float: left;
            margin: 5px 0.5% 0px 0px;
        }

        .EmailInputNew1 {
            width: 29.4%;
            float: left;
            margin: 5px 0px 0px 0px;
        }

        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        .div_txtGrade {
            float: left;
            width: 10%;
            margin-left: 0%;
            margin-top: 0.5px;
        }

        .ddlResources {
            float: left;
            width: 14%;
            margin-left: 0%;
            margin-top: 0.5px;
        }


        .div_txtGrade input, Text {
            width: 100%;
        }

        .div_txtRemarks {
            float: left;
            width: 75%;
            margin-left: 0.5%;
            margin-top: 0.5px;
            margin-right: 0.5%;
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

        .FormGroupContentNew {
            width: 40%;
            float: left;
            padding: 0px 0px 0px 0px;
            margin: 5px 0.5% 0px 0px;
        }

        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .divRoated {
        }

        .DivSecPanel {
            margin-left: 98%;
            margin-top: -1.7%;
        }


        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .HeaderStyle {
            border: solid 1px White;
            background-color: #81BEF7;
            font-weight: bold;
            text-align: center;
        }

        .Hide {
            display: none;
        }

        .popupdiv {
            margin-top: 1%;
        }

        .ddl {
            width: 30%;
            float: left;
        }

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

        .PnlDesign {
            border: solid 1px #999997;
            height: 150px;
            width: 50%;
            overflow-y: scroll;
            background-color: #F5F5F2;
            font-size: 11px;
            font-family: tahoma;
            margin-top: 0.04%;
        }

        .txtbox {
            background-position: right top;
            background-repeat: no-repeat;
            cursor: pointer;
            cursor: hand;
            font-size: 12.5px;
            font-family: tahoma;
            background-color: #F5F5F2;
            border: 1px solid #F5F5F2;
            -webkit-border-radius: 4px 4px 4px 4px;
            -moz-border-radius: 4px 4px 4px 4px;
            border-radius: 4px 4px 4px 4px;
        }

        #logix_CPH_Panel5 {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_pnlJobAE {
            left: 8px !important;
            top: 46px !important;
        }

        #logix_CPH_Panel1 {
            left: 0px !important;
            top: 50px !important;
        }

        .modalPopupss {
            height: 495px;
        }
        .btn.btn-add1 {
            margin:15px 0px 0px 0px;
        }
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtlocation .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Customer.aspx/GetLocation",
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
                        $("#<%=txtlocation .ClientID %>").val(i.item.value);
                        $("#<%=txtlocation.ClientID %>").change();
                        $("#<%=hf_locationid .ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        $("#<%=txtlocation.ClientID %>").val(i.item.value);
                        $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtlocation.ClientID %>").val(i.item.value);
                        $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtlocation .ClientID %>").val(i.item.value);
                        $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                    },--%>



                    select: function (event, i) {
                        $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        // $("#<%=txtcity.ClientID %>").val(i.item.address);
                        $("#<%=txtlocation.ClientID %>").change();
                        $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        // $("#<%=txtcity.ClientID %>").val(i.item.address);
                        $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                        // $("#<%=txtlocation.ClientID %>").val($.trim(result));

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            //  $("#<%=txtcity.ClientID %>").val(i.item.address);
                            $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                            // $("#<%=txtlocation.ClientID %>").change();
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtlocation.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtlocation.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtpincode .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Customer.aspx/GetPincode",
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
                        $("#<%=txtpincode .ClientID %>").val(i.item.value);
                        $("#<%=txtpincode.ClientID %>").change();

                    },
                    change: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                    },
                    focus: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                    },
                    close: function (event, i) {
                        $("#<%=txtpincode .ClientID %>").val(i.item.value);
                },
                minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtcustomer .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Customer.aspx/GetCustomer",
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
                                //alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=txtcustomer.ClientID %>").change();
                        $("#<%=hf_customerid .ClientID %>").val(i.item.val);


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtcity .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "Customer.aspx/GetPortName",
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
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                        $("#<%=txtcity.ClientID %>").change();
                        $("#<%=hf_portid .ClientID %>").val(i.item.val);


                    },
                    focus: function (event, i) {
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                        $("#<%=hf_portid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                        $("#<%=hf_portid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });
       <%--   
        $(document).ready(function () {
            $("#<%=txtSalePerson.ClientID %>").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "Customer.aspx/GetSalesPerson",
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
                             alertify.alert(response.responseText);
                         },
                         failure: function (response) {
                             alertify.alert(response.responseText);
                         }
                     });
                 },
                 select: function (event, i) {
                     $("#<%=txtSalePerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtSalePerson.ClientID %>").val(i.item.address);
                        $("#<%=hdnSalesid.ClientID %>").val(i.item.val);
                        $("#<%=txtSalePerson.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txtSalePerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtSalePerson.ClientID %>").val(i.item.address);
                        $("#<%=hdnSalesid.ClientID %>").val(i.item.val);
                        $("#<%=txtSalePerson.ClientID %>").val($.trim(result));
                        $("#<%=txtSalePerson.ClientID %>").change();

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtSalePerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txtSalePerson.ClientID %>").val(i.item.address);
                            $("#<%=hdnSalesid.ClientID %>").val(i.item.val);
                            $("#<%=txtSalePerson.ClientID %>").change();
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtSalePerson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtSalePerson.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
         });--%>

            $(document).ready(function () {
                $("#<%=txtComm.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            <%-- url: '<%=ResolveUrl("~/Service.asmx/GetCustomers") %>',--%>
                            url: "Customer.aspx/Getcargo",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('-')[0],
                                        val: item.split('-')[1]
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
                    select: function (e, i) {
                        var text = this.value.split(/,\s*/);
                        text.pop();
                        text.push(i.item.value);
                        text.push("");
                        this.value = text.join(", ");
                        var value = $("[id*=hfComm]").val().split(/,\s*/);
                        value.pop();
                        value.push(i.item.val);
                        value.push("");
                        $("#[id*=hfComm]")[0].value = value.join(", ");
                        return false;
                    },
                    minLength: 1
                });

            });

            $(document).ready(function () {
                $("#<%=txtCntry.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                        <%--url: '<%=ResolveUrl("~/Service.asmx/GetCountry") %>',--%>
                            url: "Customer.aspx/Getponame1",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('-')[0],
                                        val: item.split('-')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (e, i) {
                        var text = this.value.split(/,\s*/);
                        text.pop();
                        text.push(i.item.value);
                        text.push("");
                        this.value = text.join(", ");
                        var value = $("[id*=hfCountry]").val().split(/,\s*/);
                        value.pop();
                        value.push(i.item.val);
                        value.push("");
                        $("#[id*=hfCountry]")[0].value = value.join(", ");
                        return false;
                    },
                    minLength: 1
                });

            });

            $(document).ready(function () {
                $("#<%=txtEmpname.ClientID %>").autocomplete({
                source: function (request, response) {
                    $("#<%=hid_Empname.ClientID %>").val(0);
                        $.ajax({
                            url: "Customer.aspx/GetEmpname",
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
                        $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=txtEmpname.ClientID %>").change();
                        $("#<%=hid_Empname.ClientID %>").val(i.item.val);
                    },
                focus: function (event, i) {
                    $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=hid_Empname.ClientID %>").val(i.item.val);
                    },
                    <%--change: function (event, i) {
                        $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=hid_Empname.ClientID %>").val(i.item.val);

                    },--%>
                close: function (event, i) {
                    $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=hid_Empname.ClientID %>").val(i.item.val);
                    },
                minLength: 1
            });
        });


            $(document).ready(function () {
                $("#<%=txt_salescordin.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_salesCordin.ClientID %>").val(0);
                        $.ajax({
                            url: "Customer.aspx/GetEmpnameCorn",
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
                        $("#<%=txt_salescordin.ClientID %>").val(i.item.label);
                        $("#<%=txt_salescordin.ClientID %>").change();
                        $("#<%=hid_salesCordin.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_salescordin.ClientID %>").val(i.item.label);
                        $("#<%=hid_salesCordin.ClientID %>").val(i.item.val);
                    },
                    <%--change: function (event, i) {
                        $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=hid_Empname.ClientID %>").val(i.item.val);

                    },--%>
                    close: function (event, i) {
                        $("#<%=txt_salescordin.ClientID %>").val(i.item.label);
                        $("#<%=hid_salesCordin.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });



<%--            $(document).ready(function () {
                $("#<%=txtEmpname .ClientID %>").autocomplete({
                      source: function (request, response) {
                          $("#<%=hid_Empname.ClientID %>").val(0);
                          $.ajax({
                              url: "../CRMNew/Customer.aspx/GetEmpname",
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
                          $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=txtEmpname.ClientID %>").change();
                        $("#<%=hid_Empname .ClientID %>").val(i.item.val);


                    },
                    focus: function (event, i) {
                        $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=hid_Empname.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtEmpname.ClientID %>").val(i.item.label);
                        $("#<%=hid_Empname.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
              });--%>
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        .modalPopupss {
            width: 97.4%;
            margin-left: 1%;
        }

        .chzn-drop {
            height: 110px !important;
            overflow: auto;
        }

        .row {
            height: 560px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 99%;
        }

        .PopupHead {
            float: left;
            padding: 2px 0px 0px 3px;
            width: 100%;
        }

            .PopupHead h3 {
                color: #4e4e4c;
                font-size: 11px;
                font-weight: bold;
                padding: 5px 0px 5px 0px;
                margin: 0px 0px 0px 0px;
            }

        .div_total {
            width: 100%;
            height: 100%;
            background-color: #fff;
        }

        .ML4 {
            margin-left: 4px !important;
            margin-top: 19px;
            width: 99%;
        }

        #logix_CPH_pnl_Buying {
            left: 11px !important;
            top: 50px !important;
        }

        .Gridpnl {
            height: 180px;
            overflow: auto;
        }


        body {
            overflow: hidden;
        }
    </style>

     <style type="text/css">
         #logix_CPH_pln_cust {
             left: 10px !important;
             top: 29px !important;
         }

         iframe#logix_CPH_iframecost {
             width: 1316px;
             height: 556px;
         }

         .chzn-drop {
             height: 210px !important;
             overflow: auto;
         }

         .div_txtEmpName {
             float: left;
             width: 50%;
             margin: 0px 0.5% 0px 0px;
         }

         .div_txtsalescor {
             float: left;
             width: 49.5%;
             margin: 0px 0px 0px 0px;
         }

         .Emailtxt1 {
             width: 46.5%;
             float: left;
             margin: 0px 0.5% 0px 0px;
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

         .MRDrop {
             width: 6%;
             float: left;
             margin: 0px 0.5% 0px 0px;
         }
     </style>
    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="Label2" runat="server" Text="Prospect Customer"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Sales</a> </li>           
            <li class="current"><a href="#" title="">Prospect Customer</a> </li>
        </ul>
    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CustomerIDN">
                            <asp:Label ID="Label1" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txtcustomer" runat="server" placeholder="" CssClass="form-control" OnTextChanged="txtcustomer_TextChanged" AutoPostBack="true" TabIndex="1" ToolTip="CUSTOMER"></asp:TextBox>

                        </div>
                        <div class="StreetInput">
                            <asp:Label ID="Label3" runat="server" Text=" Customer Type"> </asp:Label>
                            <asp:DropDownList data-placeholder=" Customer Type" ID="ddlCType" CssClass="chzn-select" runat="server" ToolTip="CUSTOMER TYPE" TabIndex="2">
                                 <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="1" Text="Register Office">Register Office</asp:ListItem>
                                <asp:ListItem Value="2" Text="Head Office">Head Office</asp:ListItem>
                                <asp:ListItem Value="3" Text="Corporate Office">Corporate Office</asp:ListItem>
                                <asp:ListItem Value="4" Text="Regional Office">Regional Office</asp:ListItem>
                                 <asp:ListItem Value="5" Text="Branch Office">Branch Office</asp:ListItem>
                                <asp:ListItem Value="6" Text="Factory">Factory</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>


                    <%--  <div class="FormGroupContent4">
                  <div class="MrDrop1"> <asp:DropDownList data-placeholder="Title"  ID="ddl_ceo" runat="server" ToolTip="Select Title"  CssClass="chzn-select"  Width="100%" Height="24px" TabIndex="25">
                <asp:ListItem>Mr</asp:ListItem>
                <asp:ListItem>Ms</asp:ListItem>
            </asp:DropDownList></div>
                  <div class="MDInput"><asp:TextBox ID="txtmanagptc" runat ="server" placeholder=" MD\CEO" ToolTip="MANAGING DIRECTOR\CEO" CssClass="form-control" TabIndex="26"></asp:TextBox></div>
                  <div class="MDMailInput"><asp:TextBox ID="txtmailmanag" runat ="server" placeholder=" MD\CEO MAIL ID" tooltip ="MANAGEMENT HEAD MAIL ID" CssClass="form-control"  TabIndex="27" OnTextChanged="txtmailmanag_TextChanged"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="MrDrop1"> <asp:DropDownList data-placeholder="Title" ID="ddl_ch" runat="server" ToolTip="Select Title" CssClass="chzn-select"  Width="100%" Height="24px" TabIndex="28" >
                <asp:ListItem>Mr</asp:ListItem>
                <asp:ListItem>Ms</asp:ListItem>
            </asp:DropDownList></div>
                  <div class="MDInput"><asp:TextBox ID="txtcomptc" runat ="server" placeholder=" COMMERCIAL HEAD" ToolTip="COMMERCIAL HEAD" CssClass="form-control"  TabIndex="29"></asp:TextBox></div>
                  <div class="MDMailInput"><asp:TextBox ID="txtmailcom" runat ="server" placeholder=" COMMERCIAL HEAD MAIL ID"  ToolTip="COMMERCIAL HEAD MAIL ID" CssClass="form-control"  TabIndex="30" OnTextChanged="txtmailcom_TextChanged"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="MrDrop1"><asp:DropDownList data-placeholder="Title" ID="ddl_eh" runat="server" ToolTip="Select Title"  CssClass="chzn-select"  Width="100%" Height="24px" TabIndex="31" >
                <asp:ListItem>Mr</asp:ListItem>
                <asp:ListItem>Ms</asp:ListItem>
            </asp:DropDownList></div>
                  <div class="MDInput"><asp:TextBox ID="txtexpptc" runat ="server"  placeholder=" EXPORT HEAD"  ToolTip="EXPORT HEAD" CssClass="form-control"  TabIndex="32"></asp:TextBox></div>
                  <div class="MDMailInput"><asp:TextBox ID="txtmailexport" runat ="server"  placeholder=" EXPORT HEAD MAIL ID" ToolTip="EXPORT HEAD MAIL ID" CssClass="form-control"  TabIndex="33" OnTextChanged="txtmailexport_TextChanged"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="MrDrop1"> <asp:DropDownList data-placeholder="Title" ID="ddl_ih" runat="server" ToolTip="Select Title" CssClass="chzn-select"   Width="100%" Height="24px" TabIndex="34" >
                <asp:ListItem>Mr</asp:ListItem>
                <asp:ListItem>Ms</asp:ListItem>
            </asp:DropDownList></div>
                  <div class="MDInput"><asp:TextBox ID="txtimpptc" runat ="server"  placeholder=" IMPORT HEAD" ToolTip="IMPORT HEAD"  CssClass="form-control"  TabIndex="35"></asp:TextBox></div>
                  <div class="MDMailInput"><asp:TextBox ID="txtmailimp" runat ="server" placeholder=" IMPORT HEAD MAIL ID"   ToolTip ="IMPORT HEAD MAIL ID" CssClass="form-control"  TabIndex="36" OnTextChanged="txtmailimp_TextChanged"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="MrDrop1"> <asp:DropDownList data-placeholder="Title" ID="ddl_fh" runat="server" ToolTip="Select Title" CssClass="chzn-select"   Width="100%" Height="24px" TabIndex="37" >
                <asp:ListItem>Mr</asp:ListItem>
                <asp:ListItem>Ms</asp:ListItem>
            </asp:DropDownList></div>
                  <div class="MDInput"><asp:TextBox ID="txtfinptc" runat ="server"  placeholder=" FINANCIAL HEAD"  ToolTip="FINANCIAL HEAD" CssClass="form-control"  TabIndex="38"></asp:TextBox></div>
                  <div class="MDMailInput"><asp:TextBox ID="txtmailfin" runat ="server"  placeholder=" FINANCIAL HEAD MAIL ID" ToolTip="FINANCIAL HEAD MAIL ID" CssClass="form-control"  TabIndex="39" OnTextChanged="txtmailfin_TextChanged" ></asp:TextBox></div>
                  </div>--%>
                    <%--              <div class="FormGroupContent4">
                  <asp:TextBox ID ="txtSalePerson" runat="server"  placeholder=" Sales Preson"  CssClass="form-control" AutoPostBack="true" TabIndex="3" ToolTip="  Sales Preson" ></asp:TextBox>
                  </div>--%>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="UnitInput2">
                            <asp:Label ID="Label5" runat="server" Text="UNIT #"> </asp:Label>
                            <asp:TextBox ID="txtunit" runat="server" placeholder=" " ToolTip="UNIT #" CssClass="form-control" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="BuildInput">
                            <asp:Label ID="Label6" runat="server" Text="BUILDING"> </asp:Label>
                            <asp:TextBox ID="txtBuilding" runat="server" placeholder=" " ToolTip="BUILDING" CssClass="form-control " TabIndex="4"></asp:TextBox>
                        </div>
                        <div class="DoorInput">
                            <asp:Label ID="Label7" runat="server" Text="DOOR #"> </asp:Label>
                            <asp:TextBox ID="txtdoor" runat="server" placeholder=" " ToolTip="DOOR #" CssClass="form-control " TabIndex="5"></asp:TextBox>
                        </div>
                        <div class="StreetInputN1">
                            <asp:Label ID="Label8" runat="server" Text="STREET"> </asp:Label>
                            <asp:TextBox ID="txtstreet" CssClass="form-control" runat="server" placeholder=" " ToolTip="STREET" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="City1">
                            <asp:Label ID="Label9" runat="server" Text="CITY"> </asp:Label>
                            <asp:TextBox ID="txtcity" runat="server" placeholder=" " ToolTip="CITY" CssClass="form-control " OnTextChanged="txtcity_TextChanged" AutoPostBack="true" TabIndex="7"></asp:TextBox>
                        </div>
                        <div class="Country1">
                            <asp:Label ID="Label10" runat="server" Text=" ZIP/PINCODE"> </asp:Label>
                            <asp:TextBox ID="txtpincode" runat="server" placeholder="" ToolTip="ZIP/PINCODE" CssClass="form-control" AutoPostBack="true" onkeypress="return isNumberKey (event)" TabIndex="8" OnTextChanged="txtpincode_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Location1">
                            <asp:Label ID="Label11" runat="server" Text="LOCATION"> </asp:Label>
                            <asp:TextBox ID="txtlocation" runat="server" placeholder=" " ToolTip="LOCATION" CssClass="form-control " OnTextChanged="txtlocation_TextChanged" AutoPostBack="true" TabIndex="9"></asp:TextBox>
                            <asp:DropDownList data-placeholder="Choose a Location..." ID="ddllocation" runat="server" AutoPostBack="true" CssClass="chzn-select" Visible="false" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged" TabIndex="9"></asp:DropDownList>
                        </div>
                        <div class="District">
                            <asp:Label ID="Label12" runat="server" Text="DISTRICT"> </asp:Label>
                            <asp:TextBox ID="txtdistrict" runat="server" placeholder=" " ToolTip="DISTRICT" CssClass="form-control" AutoPostBack="true" TabIndex="10"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="City1">
                            <asp:Label ID="Label13" runat="server" Text="STATE"> </asp:Label>
                            <asp:TextBox ID="txtstate" runat="server" placeholder=" " ToolTip="STATE" CssClass="form-control " AutoPostBack="true" TabIndex="11"></asp:TextBox>
                        </div>
                        <div class="Country1">
                            <asp:Label ID="Label14" runat="server" Text="COUNTRY"> </asp:Label>
                            <asp:TextBox ID="txtcountry" runat="server" placeholder=" " ToolTip="COUNTRY" CssClass="form-control " AutoPostBack="true" TabIndex="12"></asp:TextBox>
                        </div>
                        <div class="Location1">
                            <asp:Label ID="Label15" runat="server" Text=" PAN #"> </asp:Label>
                            <asp:TextBox ID="txtpanno" runat="server" placeholder="" ToolTip="PAN #" CssClass="form-control" TabIndex="13" onkeyup="CheckTextLength(this,25);"></asp:TextBox>
                        </div>
                        <div class="District">
                            <asp:Label ID="Label16" runat="server" Text="GST #"> </asp:Label>
                            <asp:TextBox ID="txtstno" runat="server" placeholder="" ToolTip="GST #" CssClass="form-control " MaxLength="15" TabIndex="14" ></asp:TextBox>   <%--OnTextChanged="txtstno_TextChanged"--%>
                        </div>


                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ISDInput1">
                            <asp:Label ID="Label17" runat="server" Text="ISD"> </asp:Label>
                            <asp:TextBox ID="txtllisd" runat="server" placeholder=" " ToolTip="ISD" CssClass="form-control" onkeypress="return isNumberKey (event)" TabIndex="15" OnTextChanged="txtllisd_TextChanged"></asp:TextBox>
                        </div>
                        <div class="StdInput">
                            <asp:Label ID="Label18" runat="server" Text="STD"> </asp:Label>
                            <asp:TextBox ID="txtllstd" runat="server" placeholder=" " ToolTip="STD" CssClass="form-control" onkeypress="return isNumberKey (event)" MaxLength="6" TabIndex="16" OnTextChanged="txtllstd_TextChanged"></asp:TextBox>
                        </div>
                        <div class="LandLine">
                            <asp:Label ID="Label19" runat="server" Text="LANDLINE"> </asp:Label>
                            <asp:TextBox ID="txtlandline" runat="server" placeholder=" " ToolTip="LANDLINE" CssClass="form-control" onkeypress="return isNumberKey (event)" MaxLength="15" TabIndex="17"></asp:TextBox>
                        </div>
                        <div class="ISDInput1" style="display: none;">
                            <asp:Label ID="Label20" runat="server" Text="ISD"> </asp:Label>
                            <asp:TextBox ID="txtfaxisd" runat="server" placeholder="  " ToolTip="ISD" CssClass="form-control" onkeypress="return isNumberKey (event)" TabIndex="18"></asp:TextBox>
                        </div>
                        <div class="StdInput" style="display: none;">
                            <asp:Label ID="Label21" runat="server" Text="STD"> </asp:Label>
                            <asp:TextBox ID="txtfaxstd" runat="server" placeholder=" " ToolTip="STD" BorderColor="#999997" CssClass="form-control" onkeypress="return isNumberKey (event)" MaxLength="6" TabIndex="19"></asp:TextBox>
                        </div>
                        <div class="FaxTxtbox">
                            <asp:Label ID="Label22" runat="server" Text="FAX"> </asp:Label>
                            <asp:TextBox ID="txtfax" runat="server" placeholder=" " ToolTip="FAX" CssClass="form-control " onkeypress="return isNumberKey (event)" MaxLength="8" TabIndex="20"></asp:TextBox>
                        </div>
                        <div class="ISDInput1">
                            <asp:Label ID="Label23" runat="server" Text="ISD"> </asp:Label>
                            <asp:TextBox ID="txtmblisd" runat="server" placeholder=" " ToolTip="ISD" CssClass="form-control" onkeypress="return isNumberKey (event)" TabIndex="21"></asp:TextBox>
                        </div>
                        <div class="MobileI">
                            <asp:Label ID="Label24" runat="server" Text="MOBILE"> </asp:Label>
                            <asp:TextBox ID="txtmobile" runat="server" placeholder=" " ToolTip="MOBILE" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtmobile_TextChanged" onkeypress="return isNumberKey (event)" MaxLength="10" TabIndex="22"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="emailTxtInputN2">
                            <asp:Label ID="Label25" runat="server" Text="WEBSITE"> </asp:Label>
                            <asp:TextBox ID="txtwebsite" runat="server" placeholder=" " ToolTip="WEBSITE" CssClass="form-control" TabIndex="23"></asp:TextBox>
                        </div>

                        <div class="EmailInput1">
                            <asp:Label ID="Label26" runat="server" Text="EMAIL"> </asp:Label>
                            <asp:TextBox ID="txtemail" runat="server" placeholder=" " ToolTip="EMAIL" CssClass="form-control" OnTextChanged="txtemail_TextChanged" TabIndex="24"></asp:TextBox>
                        </div>

                    </div>
                      <div class="FormGroupContent4 boxmodal">
                        <div class="div_txtEmpName">
                            <asp:Label ID="Label27" runat="server" Text=" Sales Person Name"> </asp:Label>
                            <asp:TextBox ID="txtEmpname" runat="server" TabIndex="24" CssClass="form-control" Width="100%" PlaceHolder="" ToolTip="Sales Person Name" AutoPostBack="True" OnTextChanged="txtEmpname_TextChanged" ></asp:TextBox>
                        </div>

                             <div class="div_txtsalescor">
                                 <asp:Label ID="Label28" runat="server" Text=" Sales Coordinator"> </asp:Label>
                            <asp:TextBox ID="txt_salescordin" runat="server" TabIndex="25" CssClass="form-control" Width="100%" PlaceHolder="" ToolTip="Sales Coordinator" AutoPostBack="true" OnTextChanged="txt_salescordin_TextChanged" ></asp:TextBox>
                        </div>
                    </div>
                   
                   <div class="FormGroupContent4">
                        <div class="right_btn">
                            <div class="btn btn-branch1">
                                <asp:Button ID="btnanother" runat="server" ToolTip="Add Another Branch Office" TabIndex="39" OnClick="btnanother_Click" />
                            </div>

                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btnSave" runat="server" ToolTip="Save" TabIndex="36" OnClick="btnSave_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btnView" runat="server" ToolTip="View" TabIndex="37" />
                            </div>
                            <div class="btn ico-back" id="btn_back1" runat="server">
                                <asp:Button ID="btnCancel" runat="server" ToolTip="Back" TabIndex="38" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                     <div class="FormGroupContent4">
                        <div class="KeyPerson">
                            <%--<asp:LinkButton ID="lnkKeyPerson" runat="server" OnClick="lnkKeyPerson_Click">KeyPerson Details</asp:LinkButton>--%>
                            <asp:Label ID="lblKeyDet" runat="server" Text="KeyPerson Details"></asp:Label>
                        </div>

                         </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="MRDrop">
                            <span>Title</span>
                            <asp:DropDownList ID="ddlTitle" runat="server" Width="100%" CssClass="chzn-select" ToolTip="SELECT TITLE" TabIndex="25"></asp:DropDownList>
                        </div>
                        <div class="Nametxt1">
                            <asp:Label ID="Label30" runat="server" Text="Name"> </asp:Label>
                            <asp:TextBox ID="txtName" runat="server" ToolTip="Name" PlaceHolder=" " OnTextChanged="txtName_TextChanged1" AutoPostBack="true" CssClass="form-control" TabIndex="26"></asp:TextBox>
                        </div>
                        <div class="Desitxt1">
                            <asp:Label ID="Label31" runat="server" Text="Designation"> </asp:Label>
                            <asp:TextBox ID="txtDesingnation" runat="server" Width="100%" CssClass="form-control" ToolTip="Designation" PlaceHolder=" " TabIndex="27"></asp:TextBox>
                        </div>
                        <div class="Department1">
                            <asp:Label ID="Label32" runat="server" Text="Department"> </asp:Label>
                            <asp:TextBox ID="txtDepartment" runat="server" Width="100%" CssClass="form-control" ToolTip="Department" PlaceHolder="" TabIndex="28"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="Mobiletxt1">
                            <asp:Label ID="Label33" runat="server" Text="Mobile"> </asp:Label>
                            <asp:TextBox ID="txt_Mobile" runat="server" Width="100%" CssClass="form-control" ToolTip="MOBILE NUMBER" PlaceHolder="" OnTextChanged="txt_Mobile_TextChanged" AutoPostBack="true" onKeyUp="CheckTextLength(this,10)" onkeypress="return isNumberKey(event,'Mobile');" TabIndex="29"></asp:TextBox>
                        </div>
                        <div class="Landline1">
                            <asp:Label ID="Label34" runat="server" Text="LandLine"> </asp:Label>
                            <asp:TextBox ID="txt_Landline" runat="server" Width="100%" CssClass="form-control" ToolTip="LandLine" PlaceHolder=" " TabIndex="30" onKeyUp="CheckTextLength(this,14)" onkeypress="return isNumberKey(event,'LandLine');"></asp:TextBox>
                        </div>
                        <div class="Emailtxt1">
                            <asp:Label ID="Label35" runat="server" Text="EMAIL"> </asp:Label>
                            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" ToolTip="EMAIL ID" PlaceHolder=" " TabIndex="31" AutoPostBack="true" OnTextChanged="txt_email_TextChanged" ></asp:TextBox>
                        </div>

                        <div class="btn btn-add1 " style="top: 0px!important;" id="btn_add1" runat="server">
                            <asp:Button ID="btnKSave" runat="server" ToolTip="Add"  OnClick="btnKSave_Click" TabIndex="32" Width="100%" />
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="Panel3" runat="server" CssClass="panel_05 MB0">
                <asp:GridView ID="grdKey" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" OnRowDataBound="grdKey_RowDataBound" OnRowDeleted="grdKey_RowDeleted" OnRowDeleting="grdKey_RowDeleting" OnSelectedIndexChanged="grdKey_SelectedIndexChanged" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ptcc" HeaderText="Key Person" />     <%--0--%>
                        <asp:BoundField DataField="desig" HeaderText="Designation" />   <%--1--%>
                        <asp:BoundField DataField="dept" HeaderText="Department" />     <%--2--%>
                        <asp:BoundField DataField="mobile" HeaderText="Mobile" />       <%--3--%>
                        <asp:BoundField DataField="phone" HeaderText="Landline" />      <%--4--%>
                        <asp:BoundField DataField="email" HeaderText="E-Mail" />        <%--5--%>
                        <asp:BoundField DataField="title" HeaderText="title">           <%--6--%>
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ptc" HeaderText="ptc">               <%--7--%>
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="crmkeyid" HeaderText="crmkeyid">     <%--8--%>
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="crmid" HeaderText="crmid">           <%--9--%>
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Delete">                         <%--10--%>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                    ImageUrl="~/images/delete.jpg" Width="15px" Height="15px" OnClientClick="return confirm('Do You Want To Delete This Record');" />
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle CssClass="GrdRow" />
                </asp:GridView>
            </asp:Panel>
                    </div>
                    <%-- <div class="FormGroupContent4A">
                   <asp:TextBox ID ="txtComm" runat="server"  placeholder=" COMMODITY"  CssClass="form-control" TabIndex="3" ToolTip="  COMMODITY"></asp:TextBox>
                </div>--%>
                   
                    <%--               <div class="FormGroupContent4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <asp:TextBox ID="txtProducts" Text="Product Details" runat="server" ReadOnly="true" CssClass="form-control"  Width="100%" TabIndex="6"></asp:TextBox>
                <asp:Panel ID="PnlCust" runat="server" CssClass="PnlDesign">
                    <asp:CheckBoxList ID="chkproducts" runat="server" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="chkproducts_SelectedIndexChanged"  >
                        <asp:ListItem>Select All</asp:ListItem>
                        <asp:ListItem>Ocean Exports FCL</asp:ListItem>
                        <asp:ListItem>Ocean Exports LCL</asp:ListItem>
                        <asp:ListItem>Ocean Imports FCL</asp:ListItem>
                        <asp:ListItem>Ocean Imports LCL</asp:ListItem>
                        <asp:ListItem>Air  Exports</asp:ListItem>
                        <asp:ListItem>Air  Imports</asp:ListItem>
                        <asp:ListItem>Projects</asp:ListItem>
                        <asp:ListItem>CHA [Ony CHA]</asp:ListItem>
                    </asp:CheckBoxList>
                </asp:Panel>
                <br />

               
                <ajaxtoolkit:PopupControlExtender ID="PceSelectCustomer" runat="server" TargetControlID="txtProducts"
                    PopupControlID="PnlCust" Position="Bottom"></ajaxtoolkit:PopupControlExtender>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel>


              </div>--%>
                    <%--<ajaxtoolkit:modalpopupextender ID="modelpopupkey" runat="server" TargetControlID="lblAI"  BehaviorID="programmaticModalPopupBehavior1"
                                PopupControlID="pnlJobAE"   
                                 CancelControlID="imgfgok">
     </ajaxtoolkit:modalpopupextender>--%>
                    <div class="FormGroupContent4" style="display:none">


                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtProducts" Text="Product Details" runat="server" ReadOnly="true" CssClass="form-control" Width="100%" TabIndex="33"></asp:TextBox>
                                <asp:Panel ID="PnlCust" runat="server" CssClass="PnlDesign">
                                    <asp:CheckBoxList ID="chkproducts" runat="server" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="chkproducts_SelectedIndexChanged">
                                        <asp:ListItem>Select All</asp:ListItem>
                                        <asp:ListItem>Ocean Exports FCL</asp:ListItem>
                                        <asp:ListItem>Ocean Exports LCL</asp:ListItem>
                                        <asp:ListItem>Ocean Imports FCL</asp:ListItem>
                                        <asp:ListItem>Ocean Imports LCL</asp:ListItem>
                                        <asp:ListItem>Air  Exports</asp:ListItem>
                                        <asp:ListItem>Air  Imports</asp:ListItem>
                                        <asp:ListItem>Projects</asp:ListItem>
                                        <asp:ListItem>CHA [Ony CHA]</asp:ListItem>
                                    </asp:CheckBoxList>
                                </asp:Panel>

                                <ajaxtoolkit:PopupControlExtender ID="PceSelectCustomer" runat="server" TargetControlID="txtProducts"
                                    PopupControlID="PnlCust" Position="Bottom">
                                </ajaxtoolkit:PopupControlExtender>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>


                    </div>

                    <div class="FormGroupContent4" style="display:none">

                        <div class="CustoemrAssign">
                            <asp:TextBox ID="txtComm" runat="server" placeholder=" COMMODITY" Width="100%" CssClass="form-control" ToolTip="COMMODITY" TabIndex="34"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4" style="display:none">
                        <div class="CustoemrAssign">
                            <asp:TextBox ID="txtCntry" runat="server" placeholder="COUNTRY" Width="100%" CssClass="form-control" ToolTip="COUNTRY" TabIndex="35"></asp:TextBox>
                        </div>


                    </div>
                    <div class="FormGroupContent4" style="display:none">
                        <div class="div_txtGrade">
                            <asp:TextBox ID="txtGrade" runat="server" placeholder=" Grade" Width="100%" CssClass="form-control" ToolTip="Grade" TabIndex="36"></asp:TextBox>
                        </div>
                        <div class="div_txtRemarks" style="display:none">
                            <asp:TextBox ID="txtRemarks" runat="server" placeholder=" Remarks" Width="100%" CssClass="form-control" ToolTip="Remarks" TabIndex="37"></asp:TextBox>
                        </div>
                        <div class="ddlResources" style="display:none">
                            <asp:DropDownList data-placeholder="Resourcename" ID="ddResourceName" Width="100%" runat="server" ToolTip="Resourcename" CssClass="chzn-select" TabIndex="38">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="1" Text="">Air Imports</asp:ListItem>
                                <asp:ListItem Value="2" Text="">Africa</asp:ListItem>
                                <asp:ListItem Value="3" Text="">German</asp:ListItem>
                                <asp:ListItem Value="4" Text="">General</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>


                    <div class="FormGroupContent4">
                        <div class="LBLTeleCalls"" style="display:none">
                            <asp:LinkButton ID="lnkButton"  runat="server" OnClick="lnkButton_Click">Details of Calls</asp:LinkButton>
                        </div>
                        
                    </div>

                </div>
            </div>
        </div>
    </div>


    <asp:Label ID="lblAI" runat="server"></asp:Label>
    <%-- <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>--%>
    <ajaxtoolkit:ModalPopupExtender ID="modelpopupkey" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
        PopupControlID="pnlJobAE"
        CancelControlID="imgfgok">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Panel ID="pnlJobAE" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <%--Edit--%>

            <div class="Break"></div>
            <div class="Break"></div>
            <div class="Break"></div>
        </div>

    </asp:Panel>

    


    <div class="FormGroupContent4">
        <%-- popup --%>
        <asp:Label ID="lbl" runat="server"></asp:Label>
        <ajaxtoolkit:ModalPopupExtender ID="Grd_buying_popup" runat="server" PopupControlID="pnl_Buying" TargetControlID="lbl" CancelControlID="imgok" >
        </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel ID="pnl_Buying" runat="server"  CssClass="modalPopup"  Style="display: none;">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel2" runat="server"  CssClass="Gridpnl ML4">
                     <div class="PopupHead">
                   <h3><asp:Label ID="lblTeleCalls" runat="server" Text="TeleCall Details"></asp:Label></h3>
                        
                </div>
                    <div class="div_total">
                      
                        <div class="div_Break"></div>
                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txtCustName" runat="server" placeholder="CustomerName" ToolTip="CustomerName" ReadOnly="true" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="div_Break"></div>
                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txtPretext" runat="server" placeholder="Pretext" ToolTip="Pretext" CssClass="form-control" TextMode="MultiLine" Height="600px"></asp:TextBox>
                        </div>
                        <div class="div_Break"></div>
                        <div class="div_btn">
                            <div class="right_btn">
                                <div class="btn ico-save">
                                    <asp:Button ID="btnsave1" runat="server" ToolTip="Save" OnClick="btnsave1_Click1" />
                                </div>
                                <div class="btn ico-cancel">
                                    <asp:Button ID="btnCancel1" runat="server" ToolTip="Cancel" Visible="false" />
                                </div>
                            </div>


                        </div>
                       

                    </div>
                </asp:Panel>


            </div>
        </asp:Panel>

    </div>



    <%--  <div class="div_total">
        <div class="Header"></div>

        <div class="div_Break "></div>
        <div style="width: 99.9%; float: left;">
            <div class="txtcustomer"></div>
            <div class="div_Break "></div>

            <div class="ddltype">
            </div>

            <div class="txtcustomer"></div>

            <div class="div_Break "></div>
            <div class="txtunit"></div>
            <div class="txtbuilding"></div>
            <div class="txtdoor"></div>
            <div class="txtstreet"></div>
            <div class="div_Break "></div>
            <div class="txtcity"></div>
            <div class="txtZIP"></div>
            <div class="txtcity1"></div>
            <div class="txtdistrict"></div>


            <div class="div_Break "></div>

            <div class="txtcity"></div>
            <div class="txtZIP"></div>
            <div class="txtcity1"></div>
            <div class="txtdistrict"></div>
            <div class="div_Break "></div>

            <div class="txtisd"></div>
            <div class="txtstd"></div>
            <div class="txtlandline"></div>
            <div class="txtfaxisd"></div>
            <div class="txtstd"></div>
            <div class="txtlandlinefax"></div>
            <div class="div_Break "></div>
            <div class="txtisd"></div>
            <div class="txtmobile"></div>
            <div class="txtemail"></div>
            <div class="div_Break "></div>

        </div>
        <div class="div_Break "></div>
        <hr />
        <div class="div_Break "></div>

        <div>
            <div class="ddl_mr">
            </div>
            <div class="txt_name"></div>
            <div class="txtpanno"></div>
            <div class="div_Break "></div>
            <div class="ddl_mr">
            </div>
            <div class="txt_name"></div>
            <div class="txtpanno"></div>
            <div class="div_Break "></div>
            <div class="ddl_mr">
            </div>
            <div class="txt_name"></div>
            <div class="txtpanno"></div>
            <div class="div_Break "></div>
            <div class="ddl_mr">
            </div>
            <div class="txt_name"></div>
            <div class="txtpanno"></div>
            <div class="div_Break "></div>
            <div class="ddl_mr">
            </div>
            <div class="txt_name"></div>
            <div class="txtpanno"></div>

            <%--<script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>--%>    <%--<div class="txtisd"><asp:TextBox ID="txttds" runat ="server" placeholder="TDS" CssClass="Text "  TabIndex="28" onkeypress="return isNumberKey (event)" AutoPostBack="true"></asp:TextBox></div>
            --%>


    <div class="div_Break "></div>
    <%--        <div class="div_Break "></div>--%>
        
        <%--<div style ="width :29%; height:100%; float:left; margin-top:3%;">
<div style="width:30%; float:left; margin-left:2%; margin-top:2%;" >
    <asp:RadioButton ID="rdbNewCustomer" runat="server" Text="New Customer"  TabIndex="29"
        AutoPostBack="True" OnCheckedChanged="rdbNewCustomer_CheckedChanged"  /></div>
<div style="width:30%; margin-left:2%; margin-top:2%;">
    <asp:RadioButton ID="rdbFollowUp" runat="server" Text="Follow Up" 
        AutoPostBack="True" OnCheckedChanged="rdbFollowUp_CheckedChanged"   TabIndex="30" /></div>
<div style="width:30%; margin-left:2%; float:left; margin-top:2%;">
    <asp:RadioButton ID="rdbExisting" runat="server" Text="Existing Customer" 
        AutoPostBack="True" OnCheckedChanged="rdbExisting_CheckedChanged"  TabIndex="31" /></div>
</div>--%>            <%--    <div style="margin-top:2%">
            <div class="chk_list" >
    <asp:RadioButton ID="rdbNewCustomer" runat="server" Text="New"  TabIndex="29"
        AutoPostBack="True" OnCheckedChanged="rdbNewCustomer_CheckedChanged"  /></div>
            <div class="chk_list">
    <asp:RadioButton ID="rdbFollowUp" runat="server" Text="Follow Up" 
        AutoPostBack="True" OnCheckedChanged="rdbFollowUp_CheckedChanged"   TabIndex="30" /></div>
            <div class="chk_list">
    <asp:RadioButton ID="rdbExisting" runat="server" Text="Existing" 
        AutoPostBack="True" OnCheckedChanged="rdbExisting_CheckedChanged"  TabIndex="31" /></div>

        </div>--%>    <%--      <div class="Divhelpelaa"> <asp:ImageButton ID="imapccolse" Width="100%" Height="100%" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" OnClick="imapccolse_Click" Visible="false" TabIndex="42" /> </div>
   <div style="width:500px;height:250px;position:absolute;top:20%;left:15%;background-color:#ffffff;" id="divhelp" runat="server" visible="false" > 
        <div class="Divhelpmsg"> <asp:TextBox ID="txthelpmsg" runat="server" Width="100%" BorderColor="#999997" ForeColor="#000099"  Height="240px"  TextMode="MultiLine" >  </asp:TextBox> </div>     
    </div>

        <div class="div_Break "></div>
        <hr />
        <div class="div_Break "></div>



        <div class="div_Button">
        </div>



        <div class="div_Break "></div>

    </div>--%>









    <%--<asp:HiddenField ID="hdf_Customer" runat="server" />--%>

    <asp:HiddenField ID="hdf_pinlocation" runat="server" />
    <asp:HiddenField ID="hf_locationid" runat="server" />
    <asp:HiddenField ID="hf_portid" runat="server" />
    <asp:HiddenField ID="hf_districtid" runat="server" />
    <asp:HiddenField ID="hf_stateid" runat="server" />
    <asp:HiddenField ID="hf_countryid" runat="server" />
    <asp:HiddenField ID="hf_customerid" runat="server" />
    <asp:HiddenField ID="hf_email" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />
    <asp:HiddenField ID="hfComm" runat="server" />
    <asp:HiddenField ID="hfCountry" runat="server" />
    <asp:HiddenField ID="hdnSalesid" runat="server" />
    <asp:HiddenField ID="hf_indexid" runat="server" />

    <%-- <asp:HiddenField ID="hdf_CRM" runat="server" />--%>
    <%-- <asp:HiddenField ID="hdf_CRM" runat="server" />--%>
    <asp:HiddenField ID="hdf_crmkeyid" runat="server" />
    <asp:HiddenField ID="hdf_ptc" runat="server" />
    <br />

    <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hid_Empname" runat="server" />

    <asp:HiddenField ID="hid_salesCordin" runat="server" />
</asp:Content>
