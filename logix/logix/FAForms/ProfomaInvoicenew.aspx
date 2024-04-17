<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProfomaInvoicenew.aspx.cs" Inherits="logix.FAForms.ProfomaInvoicenew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_stylenew.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <%-- <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">--%>
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->

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

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/ProfomaInvoiceafterjobclosenew.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script src="../Scripts/ScrollableGridPlugin.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txtblno.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnblno.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/ProfomaInvoicenew.aspx/GetBLno",
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
                                // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //   alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);
                        $("#<%=txtblno.ClientID %>").change();

                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=txtblno.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);

                    },
                    close: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);

                    },
                    minLength: 1
                   <%--select: function (e, i) {
                       $("#<%=hdnblno.ClientID %>").val(i.item.val);
                      $("#<%=txtblno.ClientID %>").change();
                  },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hdnblno.ClientID %>").val(i.item.val);
                       }
                   },
                    focus: function (e, i) {
                        $("#<%=hdnblno.ClientID %>").val(i.item.val);
                   },
                   close: function (e, i) {
                       if (i.item) {
                           $("#<%=hdnblno.ClientID %>").val(i.item.val);
                      }
                  },
                    minLength: 1--%>
                });
            });

            $(document).ready(function () {

                $("#<%=txtto.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdncustid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/ProfomaInvoicenew.aspx/GetToCust",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2],
                                        text: item.split('~')[3]

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
                        if (i.item) {
                            $("#<%=txtto.ClientID %>").val(i.item.label);
                            $("#<%=hdncustid.ClientID %>").val(i.item.val);
                            $("#<%=hdncityid.ClientID %>").val(i.item.text);
                            $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtaddress.ClientID %>").val(i.item.address);
                            $("#<%=txtto.ClientID %>").change();
                        }
                    },

                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txtto.ClientID %>").val(i.item.label);
                            $("#<%=hdncustid.ClientID %>").val(i.item.val);
                            $("#<%=hdncityid.ClientID %>").val(i.item.text);
                            $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtaddress.ClientID %>").val(i.item.address);
                        }

                    },
                    close: function (e, i) {
                        var result = $("#<%=txtto.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            <%-- $(document).ready(function () {

                $("#<%=txtshipto.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdncustid.ClientID %>").val(0);
                      $.ajax({
                          url: "../FAForms/ProfomaInvoicenew.aspx/GetToCust",
                          data: "{ 'prefix': '" + request.term + "'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {

                              response($.map(data.d, function (item) {

                                  return {
                                      label: item.split('~')[0],
                                      val: item.split('~')[1],
                                      address: item.split('~')[2],
                                      text: item.split('~')[3]

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
                      if (i.item) {
                          $("#<%=txtshipto.ClientID %>").val(i.item.label);
                        
                            $("#<%=txtshipto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          
                            $("#<%=txtshipto.ClientID %>").change();
                        }
                    },
           
                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txtshipto.ClientID %>").val(i.item.label);
                          
                            $("#<%=txtshipto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            
                        }

                    },
                    close: function (e, i) {
                        var result = $("#<%=txtshipto.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtshipto.ClientID %>").val($.trim(result));
                  },
                    minLength: 1
                });
            });--%>

            <%-- $(document).ready(function () {
                $("#<%=txtsupplyto.ClientID %>").autocomplete({

                       source: function (request, response) {
                           $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer_List",
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
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                         $("#<%=txtsupplyto.ClientID %>").change();
                         $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                     },
                    focus: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                    });
               });--%>

            $(document).ready(function () {

                $("#<%=txtsupplyto.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/ProfomaInvoicenew.aspx/GetToCust",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2],
                                        text: item.split('~')[3]

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
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                            $("#<%=hid_SupplyToadd.ClientID %>").val(i.item.text);
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtsupplytoAddress.ClientID %>").val(i.item.address);
                            $("#<%=txtsupplyto.ClientID %>").change();
                        }
                    },

                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                            $("#<%=hid_SupplyToadd.ClientID %>").val(i.item.text);
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtsupplytoAddress.ClientID %>").val(i.item.address);
                        }

                    },
                    close: function (e, i) {
                        var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            $(document).ready(function () {
                $("#<%=txtcharge.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnChargid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/ProfomaInvoicenew.aspx/GetCharges",
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
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                        $("#<%=txtcharge.ClientID %>").change();
                        $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                        $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                    },
                    Change: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                        $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                        $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtcurr.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/ProfomaInvoicenew.aspx/GetLikeCurrency",
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
                        $("#<%=txtcurr.ClientID %>").val(i.item.label);
                        $("#<%=txtcurr.ClientID %>").change();
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txtcurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtcurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });
        }
    </script>

    <script type="text/javascript">

        function getConfirmationValue() {
            var sector = document.getElementById('<%=txtcharge.ClientID %>').value;

            if (sector == "") {
                alertify.alert("Charge Name can't be Empty...");
                return false;
            }
            else {
                if (confirm('Are you sure you want to delete the details?')) {
                    $('#<%=hfWasConfirmed.ClientID%>').val('true')
                }
                else {
                    $('#<%=hfWasConfirmed.ClientID%>').val('false')
                }
            }
            return true;
        }

    </script>

    <style type="text/css">
        /*.ChargeInput {
    width: 35.6% !important;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

          .STGSTInput {
    width: 18%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}*/

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

        #logix_CPH_pnlConfirm {
            top: 340px !important;
        }

        .popupconfirmnew {
            display: block;
            position: fixed;
            z-index: 100001;
            left: 390.5px;
        }

        .Pnl {
            height: 15% !important;
            border: 1px solid #b1b1b1 !important;
        }

        .TotalInputosdn {
            float: right;
            margin: 0;
            width: 10%;
        }

        .BLNo2 {
            width: 27%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BillType {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRefN {
            width: 26%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRef {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditDays {
            width: 26.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        /*.VendorRef {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}*/

        /*.BLNo2 {
    width: 25%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

.CreditDays {
    width: 21.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}*/
        .VesselInput4New {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 20%;
        }

        .VoyageInputN4New {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddl_product_chzn {
            width: 100% !important;
        }

        .right_btn {
            float: right;
        }

        .MBLchk {
            width: 8%;
            float: left;
            margin: 17px 0.5% 0px 0px;
            max-width: 10%;
        }

            .MBLchk span {
                text-align: left !important;
                margin: 0px 0px 0px 0px;
            }

        .REFInputpro {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RefCal {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0%;
        }

        .DateCal1 {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Mtctrl5n {
            margin-top: 5px;
        }

        .ChkTillDate span, label {
            display: inline-block;
            float: left;
            font-size: 11px;
            width: auto !important;
        }

        .MBLchk input {
            float: left;
            margin: 5px 5px 0px 0px;
        }

        .div_Grid {
            margin: 0px 0px 0px 0px;
            height: 150px;
            overflow: auto;
        }

        .ChargeInput {
            width: 47.5% !important;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FormGroupContent4 textarea {
            height: 25px !important;
        }

        /*.VendorRefN {
    width: 41.5%;
    float: left;
    margin: 0px;
}*/

        .row {
            clear: both;
            width: 100%;
            height: 560px !important;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .PreparedTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
        }

        .PrepareValue {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
        }

            .PrepareValue span {
                font-family: sans-serif;
            }

        .ApprovedByTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
        }

        .ApprovedValue {
            width: 15%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
        }

            .ApprovedValue span {
                font-size: 13px;
                font-family: sans-serif;
            }

        /*CSS*/

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
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
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
            white-space: nowrap;
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

        /*CSS*/

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
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
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
            white-space: nowrap;
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

        .MBLchk {
            width: 8%;
            float: left;
            margin: 15px 0.5% 0px 0px;
            max-width: 10%;
        }

        .lst_vol {
            width: 100%;
            margin: 0px 0px 0px 0px;
            /*height: 110px;*/
            overflow: auto;
        }

        .lst_cont {
            width: 100%;
            margin: 0px 0px 0px 0px;
            overflow: auto;
        }

        .btn.btn-add1 {
            margin: 13px 0px 0px;
        }

        /* FixedHeader */
        .widget.box {
            position: relative;
            top: -8px;
        }

        textarea#logix_CPH_txtaddress, textarea#logix_CPH_txtsupplytoAddress, textarea#logix_CPH_txtremarks {
            height: 63px !important;
        }
   
      .BLRight {
    margin-top: 5px;
}
      div#logix_CPH_txtVendorRef {
    margin-right: 0.5%;
    width: 11.5%;
}
      .FormGroupContent4 span {
    font-weight: normal!important;
}
      .BLDropN2 {
    width: 11.1%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
      .btn.ico-add {
    margin-top: 6px;
}
      .gridpnl {
    height: calc(100vh - 554px);
}
      div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}

div#UpdatePanel1 {
    height: 91vh;
    overflow-x: hidden;
    overflow-y: auto;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <%--<li id="homelbl" runat="server" visible="false"><a href="#"></a>Documentation</li>
              <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>--%>
                            <li><a href="#" title="" id="menulabel" runat="server">Accounts</a> </li>
                            <li class="current"><a href="#" title="" id="headerlabel" runat="server">Proforma Invoices After Job closing</a> </li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 FixedButtons">
                           <div class="right_btn">
                                <div class="btn ico-save" id="btn_save1" runat="server">
                                    <asp:Button ID="btnsave" runat="server" Text="Save" ToolTip="Save" TabIndex="11" OnClick="btnsave_Click" />
                                </div>
                                <div class="btn ico-view">
                                    <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" Enabled="false" TabIndex="19" OnClick="btnview_Click" />
                                </div>
                                <div class="btn ico-delete">
                                    <asp:Button ID="btndelete" runat="server" Visible="true" Text="Delete" TabIndex="20" ToolTip="Delete" OnClick="btndelete_Click" />
                                </div>
                                <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" TabIndex="21" />
                                </div>
                            </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="FormGroupContent4 boxmodal">
                            <div class="VoyageInputN4New">
                                <asp:Label ID="Label2" runat="server" Text="Product"> </asp:Label>
                                <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="AE" Text="Air Exports"></asp:ListItem>
                                    <asp:ListItem Value="AI" Text="Air Imports"></asp:ListItem>
                                    <asp:ListItem Value="CH" Text="Custom House Agent"></asp:ListItem>
                                    <asp:ListItem Value="FE" Text="Ocean Exports"></asp:ListItem>
                                    <asp:ListItem Value="FI" Text="Ocean Imports"></asp:ListItem>

                                    <%-- <asp:ListItem Value="BT" Text="Bonded Trucking"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>

                            <div class="REFInputpro">
                                <asp:Label ID="Label3" runat="server" Text="Ref #"> </asp:Label>
                                <asp:TextBox ID="txtref" ToolTip="Ref Number" placeholder="" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtref_TextChanged" onkeypress="return isNumberKey(event,'Ref #');"></asp:TextBox>
                            </div>
                            <div class="DateCal1">
                                <asp:Label ID="Label6" runat="server" Text="Date"> </asp:Label>
                                <asp:TextBox ID="dtdate" ToolTip="Date" placeholder="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox><ajaxtoolkit:CalendarExtender Format="MM/dd/yyyy" ID="CalendarExtender2" TargetControlID="dtdate" runat="server" />
                            </div>

                            <div class="RefCal">
                                <asp:Label ID="Label4" runat="server" Text="Year"> </asp:Label>
                                <asp:TextBox ID="txtvouyear" runat="server" ToolTip="Year" placeholder="" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="BLLeft">

                            <div class="FormGroupContent4 boxmodal">
                                <div class="BLNo2">
                                    <asp:Label ID="lblblno" runat="server" Text="BL #"> </asp:Label>
                                    <asp:TextBox ID="txtblno" runat="server" ToolTip="Bill of Lading Number" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="1" OnTextChanged="txtblno_TextChanged"></asp:TextBox>
                                </div>
                                <div class="MBLchk">
                                    <span>MB/L</span>
                                    <asp:CheckBox ID="chkmbl" runat="server"  AutoPostBack="true"  OnCheckedChanged="chkmbl_CheckedChanged" TabIndex="2" />
                                </div>
                                <div class="BillType">
                                    <asp:Label ID="Label8" runat="server" Text="Bill Type"> </asp:Label>
                                    <asp:DropDownList ID="cmbbill" ToolTip="Bill Type" runat="server" AutoPostBack="True" CssClass="chzn-select" Width="100%" data-placeholder="Bill Type" TabIndex="3" OnSelectedIndexChanged="cmbbill_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="VendorRefN" id="txtcredit" runat="server">
                                    <asp:Label ID="lblcreditapp1" runat="server" Text="CreditApproval #"> </asp:Label>
                                    <asp:TextBox ID="txtcreditapp1" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" TabIndex="4" ToolTip="CreditApproval #"></asp:TextBox>
                                </div>
                                <div class="VendorRef" id="txtVendorRef" runat="server">
                                    <asp:Label ID="lblVendorRefno" runat="server" Text="Vendor Ref #"> </asp:Label>
                                    <asp:TextBox ID="txtVendorRefno" runat="server" ToolTip="Vendor Ref Number" placeholder="" CssClass="form-control" TabIndex="5" AutoPostBack="True"></asp:TextBox>
                                </div>
                                <div class="VendorRef" id="txtVendorRefnodate1" runat="server">
                                    <asp:Label ID="lblVendorRefnodate" runat="server" Text="V.Ref# Date"> </asp:Label>
                                    <asp:TextBox ID="txtVendorRefnodate" runat="server" ToolTip="Vendor Ref# Bill Date" placeholder="" CssClass="form-control" TabIndex="6" AutoPostBack="True"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtVendorRefnodate" TodaysDateFormat="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                </div>
                                <div class="CreditDays" id="txtCreditDays1" runat="server">
                                    <asp:Label ID="lblCreditDays" runat="server" Text="CreditDays"> </asp:Label>
                                    <asp:TextBox ID="txtCreditDays" runat="server" CssClass="form-control" ToolTip="CreditDays" placeholder="" AutoPostBack="True" TabIndex="7" onkeypress="return isNumberKey(event,'Credit Days');"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 boxmodal">
                                <div class="JobDetailsInput">
                            <div class="FormGroupContent4">
                                    <asp:Label ID="lblto" runat="server" Text="Bill From"> </asp:Label>
                                    <asp:TextBox ID="txtto" runat="server" ToolTip="Bill From" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="8" OnTextChanged="txtto_TextChanged"></asp:TextBox>
                                </div>
                                 <div class="FormGroupContent4">
                                    <asp:Label ID="Label15" runat="server" Text="Bill From Address"> </asp:Label>
                                    <asp:TextBox ID="txtaddress" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                </div>                                
                            </div>

                               <div class="DesiInput ">
                            <div class="FormGroupContent4">
                                    <asp:Label ID="lblsupplyto" runat="server" Text="Supply From"> </asp:Label>
                                    <asp:TextBox ID="txtsupplyto" runat="server" ToolTip="Supply From" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="9" OnTextChanged="txtsupplyto_TextChanged"></asp:TextBox>
                                </div>
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label16" runat="server" Text="Supply From Address"> </asp:Label>
                                    <asp:TextBox ID="txtsupplytoAddress" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                                </div>

                            <div class="FormGroupContent4 boxmodal">
                                <div class="JobDetailsInput">
                                    <asp:Label ID="lblvessel" runat="server" Text="Job Details"> </asp:Label>
                                    <asp:TextBox ID="txtvessel" runat="server" ToolTip="Job Details" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="DesiInput">
                                    <asp:Label ID="Label18" runat="server" Text="Destination"> </asp:Label>
                                    <asp:TextBox ID="txtdes" runat="server" ToolTip="Destination" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="JobDetailsInput">
                                    <asp:Label ID="lblshipper" runat="server" Text="Shipper"> </asp:Label>
                                    <asp:TextBox ID="txtshipper" runat="server" ToolTip="Shipper" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="DesiInput">
                                    <asp:Label ID="lblagent" runat="server" Text="Agent"> </asp:Label>
                                    <asp:TextBox ID="txtagent" runat="server" ToolTip="Agent" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="JobDetailsInput">
                                    <asp:Label ID="Label21" runat="server" Text="Consignee"> </asp:Label>
                                    <asp:TextBox ID="txtconsignee" runat="server" ToolTip="Consignee" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="DesiInput">
                                    <asp:Label ID="lblmlo" runat="server" Text="MLO"> </asp:Label>
                                    <asp:TextBox ID="txtmlo" runat="server" ToolTip="Main-Line Operator" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="JobDetailsInput">
                                    <asp:Label ID="Label23" runat="server" Text="Notify Party"> </asp:Label>
                                    <asp:TextBox ID="txtnotify" ToolTip="Notify Party" placeholder="" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="DesiInput">
                                    <asp:Label ID="lblcnf" runat="server" Text="CNF"> </asp:Label>
                                    <asp:TextBox ID="txtcnf" runat="server" ToolTip="CNF" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="BLRight">
                            <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="pnlContlist" runat="server" CssClass="lst_cont TextArea">
                                <span>Container Details</span>
                                    <asp:ListBox ID="lstcon" runat="server" Width="100%" Height="150px" ToolTip="Container Details"></asp:ListBox>
                                </asp:Panel>
                                </div>
                            <div class="FormGroupContent4 boxmodal">
                            <div class="FormGroupContent4">
                                <asp:Panel ID="pnlVolList" runat="server" CssClass="lst_vol TextArea">
                                <span>Volume List</span>
                                    <asp:ListBox ID="lstvol" runat="server" Width="100%" Height="173px" ToolTip="Volume List"></asp:ListBox>
                                </asp:Panel>
                                </div>
                            </div>
                        </div>

                        <div class="FormGroupContent4 boxmodal">
                            <div class="FormGroupContent4">
                                <asp:Label ID="Label25" runat="server" Text="Remarks"> </asp:Label>
                                <asp:TextBox ID="txtremarks" runat="server" Style="resize: none;" Rows="2" ToolTip="Remarks" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="9" TextMode="MultiLine" Width="100%" onKeyUp="CheckTextLength(this,150)"></asp:TextBox>
                                </div>
                            </div>

                         
                        <div class="FormGroupContent4 boxmodal">
                            <div class="ChargeInput">
                                <asp:Label ID="Label26" runat="server" Text="Charge Description"> </asp:Label>
                                <asp:TextBox ID="txtcharge" runat="server" ToolTip="Charge Description" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="12" OnTextChanged="txtcharge_TextChanged"></asp:TextBox>
                            </div>
                            <%--  <div class="STGSTInput"><asp:TextBox ID="txt_stgst" runat="server" ToolTip="ST/GST" placeholder="ST/GST" CssClass="form-control" AutoPostBack="True" TabIndex="11" ></asp:TextBox></div>--%>
                            <div class="CurrInput">
                                <asp:Label ID="Label27" runat="server" Text="Curr"> </asp:Label>
                                <asp:TextBox ID="txtcurr" runat="server" ToolTip="Curr" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="13" OnTextChanged="txtcurr_TextChanged"></asp:TextBox>
                            </div>
                            <div class="RateInput">
                                <asp:Label ID="Label28" runat="server" Text="Rate"> </asp:Label>
                                <asp:TextBox ID="txtrate" runat="server" ToolTip="Rate" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="14" OnTextChanged="txtrate_TextChanged"></asp:TextBox>
                            </div>
                            <div class="EXRate">
                                <asp:Label ID="Label29" runat="server" Text="Ex Rate"> </asp:Label>
                                <asp:TextBox ID="txtex" runat="server" ToolTip="Ex Rate" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="15" OnTextChanged="txtex_TextChanged"></asp:TextBox>
                            </div>
                            <div class="BLDropN2">
                                <asp:Label ID="Label30" runat="server" Text="Base / Units"> </asp:Label>
                                <asp:DropDownList ID="cmbbase" runat="server" ToolTip="Select Base" placeholder="" AutoPostBack="True" TabIndex="16" data-placeholder="Base / Units" CssClass="chzn-select" OnSelectedIndexChanged="cmbbase_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="AmoutnInputN2">
                                <asp:Label ID="Label31" runat="server" Text="Amount"> </asp:Label>
                                <asp:TextBox ID="txtamount" runat="server" ToolTip="Amount" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="17" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="right_btn">
                                <div class="btn ico-add">
                                    <asp:Button ID="btnadd" runat="server" Text="Add" TabIndex="18" OnClick="btnadd_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4">
                            <asp:Panel ID="pnlCharge" runat="server" CssClass="gridpnl MB0" ScrollBars="Auto">
                                <asp:GridView ID="grd" TabIndex="13" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" PageSize="3" Width="100%" ForeColor="Black" OnPageIndexChanging="grd_PageIndexChanged" AllowPaging="false" CssClass="TblGrid FixedHeader" OnRowDataBound="grd_RowDataBound" OnSelectedIndexChanged="grd_SelectedIndexChanged" OnPreRender="grd_PreRender">
                                    <Columns>

                                        <asp:BoundField DataField="CHARge" HeaderText="Charges">
                                            <HeaderStyle />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="curr" HeaderText="Curr">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bASe" HeaderText="Base / Units">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}">
                                            <HeaderStyle HorizontalAlign="Center" CssClass="TxtAlign1" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" CssClass="TxtAlign1" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}">
                                            <HeaderStyle HorizontalAlign="Center" CssClass="TxtAlign1" />
                                            <ItemStyle HorizontalAlign="Left" CssClass="TxtAlign1" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                            <ItemStyle HorizontalAlign="right" Width="150px" />
                                        </asp:BoundField>

                                        <%--<asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Delete"  Visible="false"  ImageUrl="~/images/delete.jpg" Width="15px" Height="15px" OnClick="ImageButton2_Click"/>
            </ItemTemplate> <ItemStyle Width="40px" HorizontalAlign="Center" /></asp:TemplateField>--%>

                                        <asp:BoundField DataField="chargeid" HeaderText="chargeid">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>
                                <div class="div_Break"></div>
                            </asp:Panel>
                        </div>

                        <div class="FormGroupContent4">

                            <div id="lbl_txt" runat="server" visible="false">
                                <div class="PreparedTxt">Prepared By:</div>
                                <div class="PrepareValue">
                                    <asp:Label ID="lbl_prepare" runat="server" Text="Prepare Value"></asp:Label>
                                </div>
                                <div class="ApprovedByTxt">Approved By:</div>
                                <div class="ApprovedValue" runat="server" visible="false" id="lbl_appr">
                                    <asp:Label ID="lbl_Approve" runat="server" Text="Approved Value"></asp:Label>
                                </div>
                            </div>

                            <%--<div class="Amouttotal">--%>
                            <div class="TotalInputosdn">
                                <asp:Label ID="Label32" runat="server" Text="Total" CssClass="hide"> </asp:Label>
                                <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ToolTip="Total" placeholder="" AutoPostBack="True"></asp:TextBox>
                            </div>
                        </div>
                            </div>
                 
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel runat="Server" ID="pnlConfirm" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want Add One more Invoice </b></div>
        <br />
        <div class="div_confirm">

            <asp:Button ID="btnok" runat="server" Text="Yes" CssClass="Button" OnClick="btnok_Click" />
            <asp:Button ID="btnno" runat="server" Text="No" CssClass="Button" OnClick="btnno_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>

    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="popupconfirmnew" runat="server" PopupControlID="pnlConfirm" TargetControlID="lbl">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="lbl" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <div class="div_Break"></div>

    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want GST For This Charge ?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="No" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="PopUpService" runat="server" PopupControlID="Panel_Service" TargetControlID="Label1">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <%--Hidden Fields--%>
    <asp:HiddenField ID="txtjobno" runat="server" />
    <asp:HiddenField ID="hdnblno" runat="server" />
    <asp:HiddenField ID="hdncustid" runat="server" />
    <asp:HiddenField ID="hdncityid" runat="server" />
    <asp:HiddenField ID="hdnChargid" runat="server" />
    <asp:HiddenField ID="hdncurrid" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnfatransfer" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />
    <asp:HiddenField ID="hid_cmbase" runat="server" />

    <asp:HiddenField ID="hf_custid" runat="server" />
    <asp:HiddenField ID="hf_strtype" runat="server" />
    <asp:HiddenField ID="cstid" runat="server" />
    <asp:HiddenField ID="hd_exrate" runat="server" />
    <asp:HiddenField ID="hid_gstdate" runat="server" />

    <asp:HiddenField ID="hid_getdate" runat="server" />

    <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    <asp:HiddenField ID="hid_SupplyToadd" runat="server" />
    <asp:HiddenField ID="hid_SupplyTonew" runat="server" />

    <asp:HiddenField ID="hid_cosigneeid" runat="server" />

    <asp:HiddenField ID="hid_mloid" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_no" runat="server">Profoma</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

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

    <asp:Label ID="Label5" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label5" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
