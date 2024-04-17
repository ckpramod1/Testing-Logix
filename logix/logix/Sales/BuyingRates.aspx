<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="BuyingRates.aspx.cs" EnableEventValidation="false" Inherits="logix.Sales.BuyingRates" %>

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

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <!-- Forms -->
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <!-- Styled select boxes -->

    <!-- Globalize -->

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
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

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />


    <link href="../Styles/BuyingRates.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Calendar.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>


    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />




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


        modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.5%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }


        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            width: 100%;
            top: 38px !important;
            position: absolute !important;
            z-index: 99999999 !important;
        }

        

        #logix_CPH_ddlFreight_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddlShipment_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddlBase_chzn {
            width: 100% !important;
        }

        .FormChargesInput {
            float: left;
            margin: 0 0.5% 0 0;
            width: 71.5%;
        }

        .Base {
            float: left;
            margin: 0 0.5% 0 0;
            width: 11%;
        }

        .FormInput5txtcharges {
            float: left;
            margin: 0;
            width: 62.8%;
        }

        .btn-update1 {
            /* background-color: #3c7ba7;
    color: #ffffff;*/
            z-index: 2;
            border-radius: 0px;
        }

            .btn-update1 input {
                /*background-color: #3c7ba7;
        background-image: none !important;*/
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 8px 28px;
                background: url(../Theme/assets/img/buttonIcon/update_ic.png) no-repeat left top;
            }


        .btn-UpdateAdd2 {
            /*background-color: #00bcd4;
    color: #ffffff;*/
            z-index: 2;
            border-radius: 0px;
        }

            .btn-UpdateAdd2 input {
                /*background-color: #00bcd4;
        background-image: none !important;*/
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
                background: url(../Theme/assets/img/buttonIcon/updateadd_ic.png ) no-repeat left top;
            }
        /*.blueheighlight {
            border:1px solid #4286f4!important;
        }*/


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
                white-space: nowrap;
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
                font-size: 12px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }


        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }




            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }


        
    

        .row {
            height: 560px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 99%;
        }

        .ShipmentDropdown {
            float: left;
            width: 9.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .ChkboxDisplay2 {
            float: left;
            width: 16.5%;
            margin: 3px 0px 0px 0px;
            color: #396594;
            font-size: 11px;
        }

        .FormCarrier {
            float: left;
            width: 50%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

       .BurateCal {
    float: left;
    width: 7%;
    margin: 0px 0.5% 0px 0px;
    font-size: 11px;
    color: #000080;
}

        .FormRateInput {
            float: right;
            width: 18.7%;
            margin: 0px 0px 0px 0.5%;
            text-align: right;
        }

        .FormInputLab1 {
            float: left;
            width: 24%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInputLab2 {
            float: left;
            width: 25.5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInputLab3 {
            float: left;
            width: 24%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInputLab4 {
            float: left;
            width: 25%;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FreightDropDown {
            float: left;
            width: 8%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
            height: 18px;
        }

        .ShipmentDropdown {
            float: left;
            width: 8%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Consignee5 {
            width: 33.5%;
            margin: 0px 0.5% 0px 0px;
            float: left;
            font-size: 11px;
            color: #000080;
        }

        .Shipper1 {
            width: 49.5%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

       

        .formdropdownbox {
            float: left;
            width: 11.5%;
            margin: 0px 0.5% 0px 0%;
            font-size: 11px;
            color: #000080;
        }

        .ChkboxDisplay {
            float: left;
            text-align: right;
            width: 7%;
            margin: 0px 0px 0px 0px;
            color: #396594;
            font-size: 11px;
        }

        .Formradbutton {
            color: #396594;
            float: left;
            width: 34%;
            margin: 0px 0px 0px 0.5%;
            font-size: 11px;
        }

        .FormCommodity {
            float: left;
            width: 33%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Formradbutton span {
            display: inline-block;
            margin: 2px 0px 0px 0px;
        }

        .MArCtrl {
            display: inline-block;
            margin: 0px 0px 0px 28px !important;
        }

        .ChkboxDisplay1 {
            float: left;
            width: 7%;
            margin: 17px 0px 0px 0px;
            color: #396594;
            font-size: 11px;
        }

        .ChkboxDisplay2 {
            float: left;
            width: 8%;
            margin: 17px 0px 0px 0px;
            color: #396594;
            font-size: 11px;
        }

        .RateObtainedBy {
            float: left;
            width: 78.5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormChargesInput {
            float: left;
            width: 50%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormCurrRateInput {
            float: left;
            width: 7%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormRateInputNew1 {
            float: left;
            width: 16.5%;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

            .FormRateInputNew1 input {
                text-align: right;
            }

        .FormRateInput {
            float: right;
            width: 8%;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Base {
            float: left;
            width: 20.5%;
            margin: 0px 0px 0px 0.5%;
            font-size: 11px;
            color: #000080;
        }

        .MT10 {
            margin: 13px 0px 0px 10px !important;
        }
        a#logix_CPH_LinkButton1 {
    float: right; 
    display: block;
    background: #dedcdc;
    padding: 5px 10px;
    border-radius: 3px;
    position: relative;
    right: 57px;
}
        div#logix_CPH_Panel1 {
    margin: 0px;
}
        div#logix_CPH_btn_add1 {
    margin: 15px 0 0 10px;
}
       
        iframe#logix_CPH_iframe_outstd {
    height: 91vh !important;
}
.modalPopupss iframe {
    width: 100% !important;
    height: 91vh !important;
}
        
        div#logix_CPH_Panel3 {
    height: 88% !important;
}
  
        .PageHeight {
            padding-top:4px !important;
        }

    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtCarrier.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnCarrier.ClientID %>").val(0);
                        $.ajax({
                            url: "BuyingRates.aspx/GetCustomer",
                            data: "{ 'prefix': '" + request.term + "','FType':'L'}",
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
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                            $("#<%=txtCarrier.ClientID %>").change();
                            $("#<%=txtCarrier.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                            $("#<%=txtCarrier.ClientID %>").val($.trim(result));
                            $("#<%=txtCarrier.ClientID %>").val(i.item.address);
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCarrier.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                          $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                          $("#<%=txtCarrier.ClientID %>").val(i.item.address);


                      }
                  },

                    close: function (event, i) {
                        var result = $("#<%=txtCarrier.ClientID %>").val().toString().split(' ,')[0];
                      $("#<%=txtCarrier.ClientID %>").val($.trim(result));
                  },
                    minLength: 1

                });
            });



          $(document).ready(function () {
              $("#<%=txtPor.ClientID %>").autocomplete({
                source: function (request, response) {
                    $("#<%=hdnPORid.ClientID %>").val(0);
                    $.ajax({
                        url: "BuyingRates.aspx/GetLikePort",
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
                    $("#<%=txtPor.ClientID %>").val(i.item.label);
                    $("#<%=txtPor.ClientID %>").change();
                    $("#<%=hdnPORid.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txtPor.ClientID %>").val(i.item.label);
                    $("#<%=hdnPORid.ClientID %>").val(i.item.val);
                },
                change: function (event, i) {
                    $("#<%=txtPor.ClientID %>").val(i.item.label);
                    $("#<%=hdnPORid.ClientID %>").val(i.item.val);
                },
                close: function (event, i) {
                    $("#<%=txtPor.ClientID %>").val(i.item.label);
                    $("#<%=hdnPORid.ClientID %>").val(i.item.val);
                },
               <%-- select: function (event, i) {
                    $("#<%=txtPor.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                     $("#<%=txtPor.ClientID %>").change();
                     $("#<%=hdnPORid.ClientID %>").val(i.item.val);
                 },
                focus: function (event, i) {
                    $("#<%=txtPor.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      $("#<%=hdnPORid.ClientID %>").val(i.item.val);
                  },
                change: function (event, i) {
                    if (i.item) {
                        $("#<%=txtPor.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=hdnPORid.ClientID %>").val(i.item.val);
                      }
                  },
                close: function (event, i) {
                    var result = $("#<%=txtPor.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtPor.ClientID %>").val($.trim(result));
                  },--%>
                minLength: 1
            });
        });



        $(document).ready(function () {
            $("#<%=txtPol.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $("#<%=hdnPOLid.ClientID %>").val(0);
                      $.ajax({
                          url: "BuyingRates.aspx/GetLikePort",
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

                  <%--   select: function (event, i) {
                      $("#<%=txtPol.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                       $("#<%=txtPol.ClientID %>").change();
                       $("#<%=hdnPOLid.ClientID %>").val(i.item.val);
                   },
                  focus: function (event, i) {
                      $("#<%=txtPol.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      $("#<%=hdnPOLid.ClientID %>").val(i.item.val);
                  },
                  change: function (event, i) {
                      if (i.item) {
                          $("#<%=txtPol.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=hdnPOLid.ClientID %>").val(i.item.val);
                      }
                  },
                  close: function (event, i) {
                      var result = $("#<%=txtPol.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtPol.ClientID %>").val($.trim(result));
                  },--%>
                  select: function (event, i) {
                      $("#<%=txtPol.ClientID %>").val(i.item.label);
                      $("#<%=txtPol.ClientID %>").change();
                      $("#<%=hdnPOLid.ClientID %>").val(i.item.val);
                  },
                  focus: function (event, i) {
                      $("#<%=txtPol.ClientID %>").val(i.item.label);
                      $("#<%=hdnPOLid.ClientID %>").val(i.item.val);
                  },
                  change: function (event, i) {
                      $("#<%=txtPol.ClientID %>").val(i.item.label);
                      $("#<%=hdnPOLid.ClientID %>").val(i.item.val);
                  },
                  close: function (event, i) {
                      $("#<%=txtPol.ClientID %>").val(i.item.label);
                      $("#<%=hdnPOLid.ClientID %>").val(i.item.val);
                  },
                  minLength: 1
              });
          });


          $(document).ready(function () {
              $("#<%=txtPod.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $("#<%=hdnPODid.ClientID %>").val(0);
                      $.ajax({
                          url: "BuyingRates.aspx/GetLikePort",
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
                      $("#<%=txtPod.ClientID %>").val($.trim(i.item.label.split(',')[0]));

                      $("#<%=txtPod.ClientID %>").change();
                      $("#<%=hdnPODid.ClientID %>").val(i.item.val);
                  },
                  focus: function (event, i) {
                      $("#<%=txtPod.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdnPODid.ClientID %>").val(i.item.val);

                    },
                  change: function (event, i) {
                      if (i.item) {
                          $("#<%=txtPod.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdnPODid.ClientID %>").val(i.item.val);
                        }
                    },

                  close: function (event, i) {
                      var result = $("#<%=txtPod.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtPod.ClientID %>").val($.trim(result));
                    },--%>
                  select: function (event, i) {
                      $("#<%=txtPod.ClientID %>").val(i.item.label);
                      $("#<%=txtPod.ClientID %>").change();
                      $("#<%=hdnPODid.ClientID %>").val(i.item.val);
                  },
                  focus: function (event, i) {
                      $("#<%=txtPod.ClientID %>").val(i.item.label);
                      $("#<%=hdnPODid.ClientID %>").val(i.item.val);
                  },
                  change: function (event, i) {
                      $("#<%=txtPod.ClientID %>").val(i.item.label);
                      $("#<%=hdnPODid.ClientID %>").val(i.item.val);
                  },
                  close: function (event, i) {
                      $("#<%=txtPod.ClientID %>").val(i.item.label);
                      $("#<%=hdnPODid.ClientID %>").val(i.item.val);
                  },
                  minLength: 1
              });
          });

          $(document).ready(function () {
              $("#<%=txtFd.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $("#<%=hdnFDid.ClientID %>").val(0);
                      $.ajax({
                          url: "BuyingRates.aspx/GetLikePort",
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

                  <%--select: function (event, i) {
                      $("#<%=txtFd.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      $("#<%=txtFd.ClientID %>").change();
                      $("#<%=hdnFDid.ClientID %>").val(i.item.val);
                  },
                  focus: function (event, i) {
                      $("#<%=txtFd.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      $("#<%=hdnFDid.ClientID %>").val(i.item.val);
                  },
                  change: function (event, i) {
                      if (i.item) {
                          $("#<%=txtFd.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=hdnFDid.ClientID %>").val(i.item.val);
                      }
                  },

                  close: function (event, i) {
                      var result = $("#<%=txtFd.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtFd.ClientID %>").val($.trim(result));
                  },--%>
                  select: function (event, i) {
                      $("#<%=txtFd.ClientID %>").val(i.item.label);
                      $("#<%=txtFd.ClientID %>").change();
                      $("#<%=hdnFDid.ClientID %>").val(i.item.val);
                  },
                  focus: function (event, i) {
                      $("#<%=txtFd.ClientID %>").val(i.item.label);
                      $("#<%=hdnFDid.ClientID %>").val(i.item.val);
                  },
                  change: function (event, i) {
                      $("#<%=txtFd.ClientID %>").val(i.item.label);
                      $("#<%=hdnFDid.ClientID %>").val(i.item.val);
                  },
                  close: function (event, i) {
                      $("#<%=txtFd.ClientID %>").val(i.item.label);
                      $("#<%=hdnFDid.ClientID %>").val(i.item.val);
                  },
                  minLength: 1
              });
          });



          $(document).ready(function () {
              $("#<%=txtCommodity.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $("#<%=hdnCommodity.ClientID %>").val(0);
                      $.ajax({
                          url: "BuyingRates.aspx/GetLikeCargo",
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
                      $("#<%=txtCommodity.ClientID %>").val(i.item.label);
                      $("#<%=txtCommodity.ClientID %>").change();
                      $("#<%=hdnCommodity.ClientID %>").val(i.item.val);
                  },
                  focus: function (event, i) {
                      $("#<%=txtCommodity.ClientID %>").val(i.item.label);
                      $("#<%=hdnCommodity.ClientID %>").val(i.item.val);
                  },
                  close: function (event, i) {
                      $("#<%=txtCommodity.ClientID %>").val(i.item.label);
                      $("#<%=hdnCommodity.ClientID %>").val(i.item.val);
                  },
                  minLength: 1
              });
          });


        <%--  $(document).ready(function () {
              $("#<%=txtRateby.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          url: "BuyingRates.aspx/GetLikeEmployee",
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
                      $("#<%=txtRateby.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      $("#<%=HdnPreparedBy.ClientID %>").val(i.item.val);
                      $("#<%=txtRateby.ClientID %>").change();
                  },
                  focus: function (event, i) {
                      $("#<%=txtRateby.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      $("#<%=HdnPreparedBy.ClientID %>").val(i.item.val);
                      $("#<%=txtRateby.ClientID %>").val($.trim(result));


                  },
                  change: function (event, i) {
                      if (i.item) {
                          $("#<%=txtRateby.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=HdnPreparedBy.ClientID %>").val(i.item.val);

                      }
                  },

                  close: function (event, i) {
                      var result = $("#<%=txtRateby.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtRateby.ClientID %>").val($.trim(result));
                  },
                  minLength: 1
              });
          });--%>

            $(document).ready(function () {
                $("#<%=txtRateby.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=HdnPreparedBy.ClientID %>").val(0);
                        $.ajax({
                            url: "BuyingRates.aspx/GetLikeEmployee",
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
                                // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtRateby.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                         $("#<%=HdnPreparedBy.ClientID %>").val(i.item.val);
                         $("#<%=txtRateby.ClientID %>").change();
                         $("#<%=txtRateby.ClientID %>").val(i.item.address);

                     },
                    focus: function (event, i) {
                        $("#<%=txtRateby.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=HdnPreparedBy.ClientID %>").val(i.item.val);
                        $("#<%=txtRateby.ClientID %>").val($.trim(result));
                        $("#<%=txtRateby.ClientID %>").val(i.item.address);


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtRateby.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=HdnPreparedBy.ClientID %>").val(i.item.val);
                            $("#<%=txtRateby.ClientID %>").val(i.item.address);


                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtRateby.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtRateby.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });
            $(document).ready(function () {
                $("#<%=txtCharges.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $("#<%=hdnChargeid.ClientID %>").val(0);
                      $.ajax({
                          url: "BuyingRates.aspx/GetCharges",
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
                      $("#<%=hdnChargeid.ClientID %>").val(i.item.val);
                  },
                  focus: function (event, i) {
                      $("#<%=txtCharges.ClientID %>").val(i.item.label);
                      $("#<%=hdnChargeid.ClientID %>").val(i.item.val);
                  },
                  close: function (event, i) {
                      $("#<%=txtCharges.ClientID %>").val(i.item.label);
                      $("#<%=hdnChargeid.ClientID %>").val(i.item.val);
                  },
                  minLength: 1
              });
          });

          $(document).ready(function () {
              $("#<%=txtCurr.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $("#<%=hdnCurrid.ClientID %>").val(0);
                      $.ajax({
                          url: "BuyingRates.aspx/GetLikeCurrency",
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
                      $("#<%=txtCurr.ClientID %>").val(i.item.label);
                      $("#<%=txtCurr.ClientID %>").change();
                      $("#<%=hdnCurrid.ClientID %>").val(i.item.val);

                  },
                  focus: function (event, i) {
                      $("#<%=txtCurr.ClientID %>").val(i.item.label);
                      $("#<%=hdnCurrid.ClientID %>").val(i.item.val);

                  },
                  close: function (event, i) {
                      $("#<%=txtCurr.ClientID %>").val(i.item.label);
                      $("#<%=hdnCurrid.ClientID %>").val(i.item.val);

                  },
                  minLength: 1
              });
          });



          $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


<%--          $(document).ready(function () {
              $('#<%=grd.ClientID%>').gridviewScroll({
                  width: 833,
                  height: 100,
                  arrowsize: 30,

                  varrowtopimg: "../images/arrowvt.png",
                  varrowbottomimg: "../images/arrowvb.png",
                  harrowleftimg: "../images/arrowhl.png",
                  harrowrightimg: "../images/arrowhr.png"
              });
          });--%>


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
div#logix_CPH_BuyingPanel {
    height: 275px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:HiddenField ID="hdnCarrier" runat="server" />
    <asp:HiddenField ID="hdnPORid" runat="server" />
    <asp:HiddenField ID="hdnPOLid" runat="server" />
    <asp:HiddenField ID="hdnPODid" runat="server" />
    <asp:HiddenField ID="hdnFDid" runat="server" />
    <asp:HiddenField ID="hdnCommodity" runat="server" />
    <asp:HiddenField ID="HdnPreparedBy" runat="server" />
    <asp:HiddenField ID="hdnWasConfirmed" runat="server" />
    <asp:HiddenField ID="hdnDelete" runat="server" />
    <asp:HiddenField ID="hdnChargeid" runat="server" />
    <asp:HiddenField ID="hdnCurrid" runat="server" />
    <asp:HiddenField ID="hf_grdcancel" runat="server" />
    <asp:HiddenField ID="hdnRateid" runat="server" />




    <!-- /Breadcrumbs line -->


    <div>
        <asp:Panel ID="Panel1" runat="server" class="panel_style">

            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server" id="div_iframe">

                    <div class="widget-header" style="display:none;">
                        <div>
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_plnmaster" runat="server" Text="Buy Rates"></asp:Label></h4>
                            <!-- Breadcrumbs line -->
                            <div class="crumbs">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li id="lb_head" runat="server" visible="false"><a href="#" title="" id="header1" runat="server">Ocean Exports</a> </li>
                                    <li><a href="#" title="">Sales</a> </li>
                                    <li class="current"><a href="#" title="">Buy Rates</a> </li>
                                </ul>
                            </div>
                        </div>

                        <div style="float: right; margin: 0px -0.5% 0px 0px; height: 9px;" class="log ico-log-sm" >
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
                            </div>




                    </div>
                    <div class="widget-content">
                        <div class="FormGroupContent4 custom-pt-1" style="display:none;">
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">RateID</asp:LinkButton>
                            </div>
                        <div class="FormGroupContent4">
                             <asp:Image runat="server" Width="100%" />
                             <asp:Image  runat="server" Width="100%" />
                             <asp:Image  runat="server" Width="100%" />
                             <asp:Image  runat="server" Width="100%" />
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                        
                            <div class="FormCarrier blueheighlight">
                                <asp:Label ID="Label2" runat="server" Text="Carrier"></asp:Label>
                                <asp:TextBox ID="txtCarrier" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" TabIndex="1" ToolTip="Carrier" OnTextChanged="txtCarrier_TextChanged"></asp:TextBox>
                            </div>
                            <%--<div class="ValidLabel" style="text-align:center;">
                        
                        </div>--%>
                            <div class="BurateCal">
                                <asp:Label ID="Label9" runat="server" Text="Valid Till"></asp:Label>
                                <asp:TextBox ID="dtpValidity" runat="server" CssClass="form-control"
                                    AutoPostBack="True" TabIndex="2"></asp:TextBox>

                                <ajaxtoolkit:CalendarExtender ID="dtdateval" runat="server" TargetControlID="dtpValidity" Format="dd/MM/yyyy" />
                            </div>
                            <div class="Consignee5 blueheighlight">
                                <asp:Label ID="Label15" runat="server" Text="Rate Obtained By"></asp:Label>
                                <asp:TextBox ID="txtRateby" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="15" placeholder="" ToolTip="Rate Obtained By" OnTextChanged="txtRateby_TextChanged"></asp:TextBox>
                            </div>
                            <div class="FormRateInput LinkButton">
                                <span>Rate Id</span>

                                <asp:TextBox ID="txtRateid" runat="server"
                                    CssClass="form-control" AutoPostBack="True"
                                    OnTextChanged="txtRateid_TextChanged" Style="text-align: right;" placeholder="" ToolTip="Rate Id" TabIndex="3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="FormInputLab1 blueheighlight">
                                <asp:Label ID="Label3" runat="server" Text="Place of Receipt"></asp:Label>
                                <asp:TextBox ID="txtPor" runat="server" CssClass="form-control"
                                    AutoPostBack="True" TabIndex="4" OnTextChanged="txtPor_TextChanged" placeholder="" ToolTip="Place of Receipt"></asp:TextBox>
                            </div>
                             

                            <div class="FormInputLab2 blueheighlight">
                                <asp:Label ID="Label5" runat="server" Text="Port of Loading"></asp:Label>
                                <asp:TextBox ID="txtPol" runat="server" CssClass="form-control"
                                    AutoPostBack="True" TabIndex="5" OnTextChanged="txtPol_TextChanged" placeholder="" ToolTip="Port of Loading"></asp:TextBox>
                            </div>
                            
                            <div class="FormInputLab3 blueheighlight">
                                <asp:Label ID="Label6" runat="server" Text="Port of Discharge"></asp:Label>
                                <asp:TextBox ID="txtPod" runat="server" CssClass="form-control"
                                    AutoPostBack="True" TabIndex="6" OnTextChanged="txtPod_TextChanged" placeholder="" ToolTip="Port of Discharge"></asp:TextBox>
                            </div>
                            
                            <div class="FormInputLab4 blueheighlight">
                                <asp:Label ID="Label7" runat="server" Text="Place of Delivery"></asp:Label>
                                <asp:TextBox ID="txtFd" runat="server" CssClass="form-control"
                                    AutoPostBack="True" TabIndex="7" OnTextChanged="txtFd_TextChanged" placeholder="" ToolTip="Place of Delivery"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="FreightDropDown blueheighlight">
                                <asp:Label ID="Label8" runat="server" Text="Freight"></asp:Label>
                                <asp:DropDownList ID="ddlFreight" runat="server" TabIndex="8" AutoPostBack="True" CssClass="chzn-select" data-placeholder="Freight" ToolTip="Freight">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="ShipmentDropdown blueheighlight">
                                <asp:Label ID="Label12" runat="server" Text="Shipment"></asp:Label>
                                <asp:DropDownList ID="ddlShipment" runat="server"
                                    TabIndex="9" AutoPostBack="True" CssClass="chzn-select" data-placeholder="Shipment" ToolTip="Shipment"
                                    OnSelectedIndexChanged="ddlShipment_SelectedIndexChanged">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="ChkboxDisplay1" style="display:none;">
                                <label class="radio-inline PL10">

                                    <asp:CheckBox ID="chkDGCargo" runat="server" CssClass="uniform" TabIndex="10" />
                                    <asp:Label ID="Label10" runat="server" Text="DGCargo" CssClass="LabelValue"></asp:Label>
                                </label>
                            </div>
                            <div class="ChkboxDisplay2" style="display:none;">
                                <label class="radio-inline PL10">
                                    <asp:CheckBox ID="chkBulk" runat="server" TabIndex="11" />
                                    <asp:Label ID="Label11" runat="server" Text="Bulk Volume" CssClass="LabelValue"></asp:Label>
                                </label>
                            </div>

                            <!-- <div class="Brokerage_textboxes">
                          <asp:TextBox ID="txtBrokerage" runat="server"
                    CssClass="form-control" TabIndex="12" AutoPostBack="True"
                     placeholder="BKG" ToolTip="Brokerage"></asp:TextBox>
                         </div> -->
                            <div class="FormCommodity blueheighlight">
                                <asp:Label ID="Label13" runat="server" Text="Commodity"></asp:Label>
                                <asp:TextBox ID="txtCommodity" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="13" placeholder="" ToolTip="Commodity" OnTextChanged="txtCommodity_TextChanged"></asp:TextBox>
                            </div>
                             <div class="Shipper1">
                                <asp:Label ID="Label14" runat="server" Text="Remarks"></asp:Label>
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="14" placeholder="" ToolTip="Remarks"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="right_btn">
                                <div class="btn btn-reuse1 hide" id="btn_reuse1">
                                    <asp:Button ID="Btn_reuse" runat="server" ToolTip="Reuse" OnClick="Btn_reuse_Click1" />
                                </div>

                                <div class="btn btn-save1 WidthcrtlN1" id="btn_save" runat="server">
                                    <asp:Button ID="btnsave" runat="server" ToolTip="Save" TabIndex="16" OnClick="btnsave_Click" /></div>
                                <div class="btn ico-view">
                                    <asp:Button ID="btnview" runat="server" ToolTip="View" TabIndex="17" OnClick="btnview_Click" />
                                </div>
                                <div class="btn ico-delete">
                                    <asp:Button ID="btndelete" runat="server" ToolTip="Delete" TabIndex="18" OnClick="btndelete_Click" /></div>
                                <div class="btn ico-cancel" id="btn_cancel" runat="server">
                                    <asp:Button ID="btncancel" runat="server" ToolTip="Cancel" TabIndex="19" OnClick="btncancel_Click" /></div>




                            </div>

                            <div class="FormGroupContent4 boxmodal">
                                <div class="FormChargesInput blueheighlight">
                                    <asp:Label ID="Label16" runat="server" Text="Charges"></asp:Label>
                                    <asp:TextBox ID="txtCharges" runat="server"
                                        CssClass="form-control" AutoPostBack="True" TabIndex="20" OnTextChanged="txtCharges_TextChanged" placeholder="" ToolTip="Charges"></asp:TextBox>


                                </div>
                                <div class="FormCurrRateInput blueheighlight">
                                    <asp:Label ID="Label17" runat="server" Text="Curr"></asp:Label>
                                    <asp:TextBox ID="txtCurr" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="21" MaxLength="3" placeholder="" ToolTip="Currency" OnTextChanged="txtCurr_TextChanged"></asp:TextBox>

                                </div>
                                <div class="FormRateInputNew1 blueheighlight">
                                    <asp:Label ID="Label18" runat="server" Text="Rate"></asp:Label>
                                    <asp:TextBox ID="txtRate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="22" placeholder="" ToolTip="Rate"></asp:TextBox>
                                </div>
                                <div class="Base blueheighlight">
                                    <asp:Label ID="Label19" runat="server" Text="Base / Unit"></asp:Label>
                                    <asp:DropDownList ID="ddlBase" runat="server" TabIndex="23" CssClass="chzn-select" ToolTip="Base / Unit"
                                        data-placeholder="Base / Unit" AutoPostBack="True">
                                        <asp:ListItem Text="Base / Unit" Value="0"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="btn ico-add" id="btn_add1" runat="server">
                                    <asp:Button ID="btnAdd" runat="server" ToolTip="Add"
                                        TabIndex="24" OnClick="btnAdd_Click" />
                                </div>
                            </div>

                            <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="BuyingPanel" runat="server" CssClass="panel_10 MB0">

                                    <asp:GridView ID="grd" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                        OnRowCommand="grd_RowCommand" CssClass="Grid FixedHeader" OnSelectedIndexChanged="grd_SelectedIndexChanged" OnRowDeleting="grd_RowDeleting"
                                        OnRowDataBound="grd_RowDataBound" OnPreRender="grd_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                <ControlStyle />
                                                <HeaderStyle />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="curr" HeaderText="Curr">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="base" HeaderText="Base/Unit">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <span>

                                                    <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" />
                                                    </span>

                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />

                                            </asp:TemplateField>


                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                    </asp:GridView>
                                </asp:Panel>


                            </div>



                        </div>
                    </div>

                </div>

                <%-----------------------------------------------Pop Up--------------------------------------------------------------%>

                <asp:Label ID="lblAI" runat="server"></asp:Label>


                <ajaxtoolkit:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
                    PopupControlID="pnlJobAE" DropShadow="false"
                    CancelControlID="imgfgok">
                </ajaxtoolkit:ModalPopupExtender>

                <asp:Panel ID="pnlJobAE" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                    <div class="divRoated">
                        <div class="DivSecPanel">
                            <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                        </div>

                        <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                            <asp:GridView ID="grdmain" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="20" OnPageIndexChanging="grdmain_PageIndexChanging"
                                CssClass="Grid FixedHeader" Visible="False" OnRowDataBound="grdmain_RowDataBound"
                                OnSelectedIndexChanged="grdmain_SelectedIndexChanged">
                                <Columns>



                                    <asp:BoundField DataField="rateid" HeaderText="Rate Id">



                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Carrier">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("liner") %>' ToolTip='<%#Bind("liner")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>





                                    <asp:TemplateField HeaderText="POL">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("POL") %>' ToolTip='<%#Bind("POL")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="POD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("POD") %>' ToolTip='<%#Bind("POD")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Cargo">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("Cargo") %>' ToolTip='<%#Bind("Cargo")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rate Obtained By">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("ObtainedBy") %>' ToolTip='<%#Bind("ObtainedBy")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>

                        </asp:Panel>




                        <asp:Panel ID="Panel4" runat="server" CssClass="Gridpnl">

                            <asp:GridView ID="GrdResue" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="true" PageSize="20" OnPageIndexChanging="GrdResue_PageIndexChanging"
                                CssClass="Grid FixedHeader" Visible="False" OnRowDataBound="GrdResue_RowDataBound"
                                OnSelectedIndexChanged="GrdResue_SelectedIndexChanged">
                                <Columns>



                                    <asp:BoundField DataField="rateid" HeaderText="Rate Id">



                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Carrier">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("liner") %>' ToolTip='<%#Bind("liner")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>





                                    <asp:TemplateField HeaderText="POL">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("POL") %>' ToolTip='<%#Bind("POL")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="POD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("POD") %>' ToolTip='<%#Bind("POD")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Cargo">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("Cargo") %>' ToolTip='<%#Bind("Cargo")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rate Obtained By">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("ObtainedBy") %>' ToolTip='<%#Bind("ObtainedBy")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>

                        </asp:Panel>
                        <div class="Break"></div>
                    </div>

                </asp:Panel>


                <div id="PanelLog1" runat="server">
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Rate Id :</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
                </div>
        </asp:Panel>
    </div>
    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Are you sure you want to delete the details?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>

    <ajaxtoolkit:ModalPopupExtender ID="PopUpService" runat="server"
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>

    </div>
     <asp:HiddenField ID="hf_date" runat="server" />
</asp:Content>








