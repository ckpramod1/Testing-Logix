<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProformaLV.aspx.cs" Inherits="logix.Accounts.ProformaLV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

    <script type="text/javascript" src="../js/helper.js"></script>
  <%--  <script type="text/javascript" src="../js/TextField.js"></script>--%>
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
    <link href="../Styles/ProformaLV.css" rel="stylesheet" type="text/css" />
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
                            url: "../Accounts/ProformaLV.aspx/GetBLno",
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
                                // alert(response.responseText);
                            },
                            failure: function (response) {
                                //   alert(response.responseText);
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
                            url: "../Accounts/ProformaLV.aspx/GetToCust",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
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
                          url: "../Accounts/ProformaLV.aspx/GetToCust",
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
                              //alert(response.responseText);
                          },
                          failure: function (response) {
                              // alert(response.responseText);
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
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
                            url: "../Accounts/ProformaLV.aspx/GetToCust",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
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
                            url: "../Accounts/ProformaLV.aspx/GetCharges",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
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
                            url: "../Accounts/ProformaLV.aspx/GetLikeCurrency",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
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
                alert("Charge Name can't be Empty...");
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




        .VendorRef {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }


        .VendorRef2 {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        textarea#logix_CPH_txtremarks {
    height: 70px !important;
}
        .BLNo2 {
            width: 15.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditDays {
            width: 9.4%;
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


        .modalPopupLog {
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

        table#logix_CPH_grd th:nth-child(1) {
    width: 20px !important;
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

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .btn-upd1 {
            z-index: 2;
        }

            .btn-upd1 input {
                background: url(../Theme/assets/img/buttonIcon/update_ic.png ) no-repeat left top;
                border: medium none !important;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
            }


        .VendorRefN2 {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRef1 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRefN {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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
            span.normalsize {
    background: white !important;
}
        .BillType {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .BillType1 {
            width: 11.7%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }
        select#logix_CPH_lstvol {
    padding-top: 21px !important;
}
        .VendorRefN1 {
            width: 21%;
            float: left;
            margin: 0px 0.5% 0px 4px;
        }

        /*.blueheighlight {
            border:1px solid #4286f4!important;
        }*/

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 12px;
        }

        a {
            font-size: 12px;
        }

        .MBLchk {
            width: 5%;
            float: left;
            margin: 17px 0.5% 0px 0px;
            max-width: 10%;
        }

        .MT10 {
            margin: 13px 0px 0px 0px !important;
        }

        
        .TotalInputosdn {
            float: right;
            margin: 0px 0px 0px 0px;
            width: 10%;
        }



        .totaltxtbox {
            width: 2.5%;
            float: right;
            margin: 4px 0.5% 0px 0px;
        }


        .lst_cont {
            width: 100%;
            /*height: 42px;*/
            /*margin-left: 2%;*/
            margin-top: 0%;
        }

        .lst_vol {
            width: 100%;
            /*height: 80px;*/
            margin-left: 0%;
            margin-top: 0%;
        }


        .JobDetailsInputn1 {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

     .DesiInputn1 {
    width: 15.6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .JobDetailsInputn2 {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DesiInputn2 {
            width: 25%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .RemarksTxtBox {
            width: 50%;
            float: left;
        }




        .BLLeft {
            width: 74.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BLRight {
            width: 25%;
            float: left;
            margin: 0px 0 0 0;
        }

        .ShipperLeft {
            float: left;
            width: 74.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipperTextarea {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }



        .ShipperRight1 {
            float: left;
            width: 25%;
            margin: 0px 0% 0px 0px;
        }





        .REFInputpro {
            width: 3.4%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        .RefCal {
            width: 3.4%;
            float: right;
            margin: 0px 0.5% 0px 0%;
        }

        .DateCal1 {
            width: 4.5%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        .BLDropN2 .chzn-container-single .chzn-drop {
            height: 150px !important;
            top: 45px !important;
        }

        .div_Grid {
            width: 100%;
            float: left;
            margin-left: 0%;
            margin-bottom: 1%;
            height: 120px;
            /* border: 1px solid gray; */
        }

        select#logix_CPH_lstcon {
            height: 66px;
            border: none !important;
            border-bottom: 1px solid var(--inputborder) !important;
            font-size:14px !important;
        }

        div#logix_CPH_pnlContlist {
            height: 72px;
        }

        div#logix_CPH_pnlVolList {
            height: 100px;
        }

        textarea#logix_CPH_txtAllDetails {
    height: 73px !important;
}

        .RateInput {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .EXRate {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .BLDropN2 {
    width: 7.1%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .JobDetailsInput.blueheighlight {
            margin-right: 0.5% !important;
        }

        .JobDetailsInput {
            margin-right: 0.5% !important;
        }

        div#logix_CPH_lbl_txt {
            margin: 5px 0 0 0;
            width: 50%;
            float: left;
        }
        div#logix_CPH_pnlVolList span {
    top: 4px !important;
    left: 0px;
    font-size: 14px !important;
    font-family: "Gill Sans", "Gill Sans MT", Calibri, "Trebuchet MS", sans-serif;
    position: absolute !important;
    background-color: white;
    padding: 4px 0.3rem 0px !important;
    margin: 1px 4px 0px;
    width: 90%;
    transform-origin: left top;
    pointer-events: none;
    color: rgb(6, 82, 156) !important;
}
        input[type=text], input[type=file], textarea {
            border: none !important;
        }

        select#logix_CPH_lstvol {
            border: none !important;
            border-bottom: 1px solid var(--inputborder) !important;
            font-size:14px !important;
        }
        .ChargeInput {
    width: 65%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        div#logix_CPH_ddl_voutype_chzn {
    width: 100% !important;
}
        .AmoutnInputN2 {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
table#logix_CPH_grd th:nth-child(3) {
    width: 94px !important;
}
        table#logix_CPH_grd th:nth-child(2) {
    width: 63.7% !important;
}
        table#logix_CPH_grd th:nth-child(4) {
    width: 54px !important;
}
        table#logix_CPH_grd th:nth-child(5) {
    width: 128px !important;
}
      table#logix_CPH_grd th:nth-child(7) {
    text-align: right;
}
      table#logix_CPH_grd th:nth-child(6) {
    width: 62px !important;
}
      table#logix_CPH_grd th:nth-child(8) {
    text-align: right;
}
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
        .divleft{
            width:75%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .divright{
            width:25%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
        iframe#logix_CPH_iframe_outstd {
    height: 89vh !important;
}
        div#logix_CPH_ddl_voutype_chzn .chzn-drop {
    height: 167px !important;
}
        .Pnl {
    width: 30% !important;
    height: 15% !important;
    text-align: center;
    background-color: White;
    border: solid 3px black !important;
    float: left;
    padding-top: 10px;
    padding-left: 10px;
    margin-left: 1%;
}
        #logix_CPH_Panel_Service {
    top: 280px !important;
}
        .div_confirm {
    width: 100%;
    float: left;
    margin-left: 1%;
    margin-top: 0%;
}
        .RateInput span {
    text-align: right;
}
        .EXRate span{
          text-align:right;
        }
        .AmoutnInputN2 span {
    text-align: right;
}
        table#logix_CPH_grd th:nth-child(9) {
    width: 137px !important;
}

table#logix_CPH_grd th:nth-child(8) {
    width: 50px !important;
}
.CurrInput {
    width: 2.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:label id="lbl_Header" runat="server" text=""></asp:label>
                        </h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li id="homelbl" runat="server" visible="false"><a href="#"></a>Ops & Docs</li>
                                <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>
                                <li><a href="#" title="" id="menulabel" runat="server">Accounts</a> </li>
                                <li class="current"><a href="#" title="" id="headerlabel" runat="server">Proforma Vouchers</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:linkbutton id="logdetails" runat="server" tooltip="Log" style="text-decoration: none" onclick="logdetails_Click"></asp:linkbutton>
                    </div>
                </div>
                <div class="widget-content">

                    <div class="FixedButtons">
                        <div class="right_btn">
                            <div class="btn ico-upload">
                                <asp:Button ID="btn_uploadpopup" runat="server" AutoPostBack="true" ToolTip="Upload" TabIndex="16" OnClick="btn_uploadpopup_Click" />
                            </div>
                            <div class="btn ico-save" id="btnsave1" runat="server">
                                <asp:Button ID="btnsave" runat="server" ToolTip="Save" Text="Save" TabIndex="11" OnClick="btnsave_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:button id="btnview" runat="server" tooltip="View" text="View" enabled="false" tabindex="19" onclick="btnview_Click" />
                            </div>
                            <div class="btn ico-delete">
                                <asp:button id="btndelete" runat="server" visible="true" text="Delete" tabindex="20" tooltip="Delete" onclick="btndelete_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btncancel1" runat="server">
                                <asp:button id="btncancel" runat="server" tooltip="Cancel"  text="Cancel"  onclick="btncancel_Click" tabindex="21" />
                            </div>
                        </div>
                    </div>
                  <%--  <div class="FormGroupContent4">
                        <div class="divleft">
                  
                            </div>
                      
                        </div>--%>
                    <div class="FormGroupContent4">

                        <div class="left_btn" style="width: 30%;margin-top: 18px;">
                             <div id="lbl_txt" runat="server" visible="false">
     <div class="FormGroupContent4">
         <span>Prepared By:</span>
         <asp:label id="lbl_prepare" runat="server" text=""></asp:label>
     </div>
     <div class="FormGroupContent4" runat="server" visible="false" id="lbl_appr">
         <span>Approved By:</span>
         <asp:label id="lbl_Approve" runat="server" text=""></asp:label>
     </div>
 
 </div>
                        </div>
  <div class="DateCal1 DateR">
    <asp:label id="Label41" runat="server" text="Date"></asp:label>
    <asp:textbox id="dtdate" tooltip="Date" placeholder="" runat="server" cssclass="form-control" enabled="false"></asp:textbox>
    <ajaxtoolkit:calendarextender format="MM/dd/yyyy" id="CalendarExtender2" targetcontrolid="dtdate" runat="server" />
</div>
 <div class="REFInputpro">
    <asp:label id="Label2" runat="server" text="Ref #"></asp:label>
    <asp:textbox id="txtref" tooltip="Ref Number" placeholder="" runat="server" cssclass="form-control" autopostback="True" ontextchanged="txtref_TextChanged" onkeypress="return isNumberKey(event,'Ref #');"></asp:textbox>
</div>

                                                  <div class="RefCal">
    <asp:label id="Label3" runat="server" text="Year"></asp:label>
    <asp:textbox id="txtvouyear" runat="server" tooltip="Year" placeholder="" cssclass="form-control" autopostback="True"></asp:textbox>
</div> 
                         <div class="BillType1 blueheighlight">
    <asp:label id="Labell" runat="server" text="Voucher Type"></asp:label>
    <asp:dropdownlist id="ddl_voutype" tooltip="Voucher Type" runat="server" autopostback="True" cssclass="chzn-select" width="100%" data-placeholder="Voucher Type" tabindex="3" onselectedindexchanged="Dropdownlist1_SelectedIndexChanged">
       <asp:ListItem Value="0" Text=""></asp:ListItem>
            <asp:ListItem Value="1" Text="Proforma Sales Invoice"></asp:ListItem>
        <asp:ListItem Value="2" Text="Proforma Purchase Invoice"></asp:ListItem>
        <asp:ListItem Value="22" Text="Proforma Sales Invoice OC"></asp:ListItem>
        <asp:ListItem Value="23" Text="Proforma Purchase Invoice OC"></asp:ListItem>


    </asp:dropdownlist>
</div>
                    </div>
                    <div class="bordertopNew" style=" float: right;min-height: 1px;width: 25%;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;" ></div>

                    <div class="FormGroupContent4">
                    <div class="BLLeft">
                          <div class="FormGroupContent4 boxmodal">
                        <!--<div class="Datelabel1"> <asp:Label ID="Label4" runat="server" Text="Date" CssClass="LabelValue"></asp:Label></div>-->
                        

                        
                      
                      


                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="BLNo2 blueheighlight">
                            <asp:label id="Label5" runat="server" text="BL #"></asp:label>
                            <asp:textbox id="txtblno" runat="server" tooltip="Bill of Lading Number" placeholder="" cssclass="form-control" autopostback="True" tabindex="1" ontextchanged="txtblno_TextChanged"></asp:textbox>
                        </div>
                        <div class="MBLchk">
                            <span class="chktext">MB/L</span>
                            <center>
                            <label class="switch">
                            <asp:checkbox id="chkmbl" runat="server" autopostback="true" oncheckedchanged="chkmbl_CheckedChanged" tabindex="2" />

                            </label>
                                </center>

                        </div>
                        <div class="BillType blueheighlight">
                            <asp:label id="Label6" runat="server" text="Bill Type"></asp:label>
                            <asp:dropdownlist id="cmbbill" tooltip="Bill Type" runat="server" autopostback="True" cssclass="chzn-select" width="100%" data-placeholder="Bill Type" tabindex="3" onselectedindexchanged="cmbbill_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                        
                         <div class="DesiInputn1">
     <asp:label id="Label16" runat="server" text="Shipment Destination"></asp:label>
     <asp:textbox id="txtdes" runat="server" tooltip="Destination" placeholder="" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
 </div>
                   <div class="VendorRef1" id="txtVendorRef" runat="server">
    <asp:label id="Label8" runat="server" text="Customer Ref #"></asp:label>
    <asp:textbox id="txtVendorRefno" runat="server" tooltip="Customer Ref Number" placeholder="" cssclass="form-control" tabindex="5" autopostback="True" OnTextChanged="txtVendorRefno_TextChanged"></asp:textbox>
</div>

<div class="VendorRef" id="txtVendorRefnodate1" runat="server">
    <asp:label id="Label9" runat="server" text="Date"></asp:label>
    <asp:textbox id="txtVendorRefnodate" runat="server" tooltip="Customer Ref Date" placeholder="" cssclass="form-control" tabindex="6" autopostback="True"></asp:textbox>
    <ajaxtoolkit:calendarextender id="CalendarExtender1" runat="server" daysmodetitleformat="dd/MM/yyyy" format="dd/MM/yyyy" targetcontrolid="txtVendorRefnodate" todaysdateformat="dd/MM/yyyy"></ajaxtoolkit:calendarextender>
</div>
  <div class="VendorRefN blueheighlight hide" id="txtcredit" runat="server">
    <asp:label id="Label7" runat="server" text="CreditApproval #"></asp:label>
    <asp:textbox id="txtcreditapp1" runat="server" cssclass="form-control" autopostback="True" placeholder="" tabindex="4" tooltip="CreditApproval #"></asp:textbox>
</div>
                      

<div class="CreditDays" id="txtCreditDays1" runat="server">
    <asp:label id="Label33" runat="server" text="CreditDays"></asp:label>
    <asp:textbox id="txtCreditDays" runat="server" cssclass="form-control" tooltip="CreditDays" placeholder="" autopostback="True" tabindex="7" onkeypress="return isNumberKey(event,'Credit Days');"></asp:textbox>
</div>       

                    </div>
                     
                        <div class="FormGroupContent4">

                            <div class="JobDetailsInput blueheighlight boxmodal">
                                <div class="FormGroupContent4">
                                    <asp:label id="Label11" runat="server" text="Bill From"></asp:label>
                                    <asp:textbox id="txtto" runat="server" tooltip="Bill From" placeholder="" cssclass="form-control" autopostback="True" tabindex="8" ontextchanged="txtto_TextChanged"></asp:textbox>
                                </div>

                                <div class="FormGroupContent4">
                                    <asp:label id="Label13" runat="server" text="Bill To Address"></asp:label>
                                    <asp:textbox id="txtaddress" style="resize: none;" rows="2" runat="server" tooltip="Address" placeholder="" cssclass="form-control" autopostback="True" textmode="MultiLine"></asp:textbox>
                                </div>
                            </div>

                            <div class="DesiInput blueheighlight boxmodal">
                                <div class="FormGroupContent4">
                                    <asp:label id="Label12" runat="server" text="Supply From"></asp:label>
                                    <asp:textbox id="txtsupplyto" runat="server" tooltip="Supply From" placeholder="" cssclass="form-control" autopostback="True" tabindex="9" ontextchanged="txtsupplyto_TextChanged"></asp:textbox>
                                </div>

                                <div class="FormGroupContent4">
                                    <asp:label id="Label14" runat="server" text="Supply To Address"></asp:label>
                                    <asp:textbox id="txtsupplytoAddress" style="resize: none;" rows="2" runat="server" tooltip="Address" placeholder="" cssclass="form-control" autopostback="True" textmode="MultiLine"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="FormGroupContent4">

                           
                          
                       
                                    <asp:label id="Label23" runat="server" text="Remarks"></asp:label>
                                    <asp:textbox id="txtremarks" runat="server" style="resize: none;" rows="2" tooltip="Remarks" placeholder="" cssclass="form-control" autopostback="True" tabindex="9" textmode="MultiLine" width="100%" onkeyup="CheckTextLength(this,150)"></asp:textbox>
                                </div>
                        
 
                    </div>
                    <div class="BLRight boxmodal">
                                              
                             <div class="FormGroupContent4">
                            <asp:panel id="pnlContlist" runat="server" cssclass="lst_cont TextArea">
                                <asp:Label Text=" Job Details" ID="lblWeight" runat="server"></asp:Label>

                                <%--<asp:ListBox ID="lstJobDtls" runat="server" Width="100%" Height="50%"></asp:ListBox>--%>
                                <asp:Label ID="lbljobDtls" runat="server" Visible="false"></asp:Label>
                                <asp:ListBox ID="lstcon" runat="server" Width="100%"></asp:ListBox>
                            </asp:panel>
                         
                        
                        </div>
                          <div class="FormGroupContent4">
                            <asp:panel id="pnlVolList" runat="server" cssclass="lst_vol TextArea">
                                <span>Container/Volume Details</span>
                                <asp:ListBox ID="lstvol" runat="server" Width="100%" Height="100%"></asp:ListBox>
                            </asp:panel>
                        </div>
                        <div class="FormGroupContent4" style="margin-top: 7px !important;" >
                           
                                <div class="FormGroupContent4">
                                    <asp:label id="lblText" runat="server" text="Customer Details"></asp:label>
                                    <asp:textbox id="txtAllDetails" runat="server" style="resize: none;" rows="2" tooltip="" placeholder="" cssclass="form-control" enabled="false" tabindex="9" textmode="MultiLine" width="100%"></asp:textbox>
                                </div>

                            
                        </div>
                    </div>
                        </div>

                 

                    <div class="FormGroupContent4" style="display: none;">
                        <div class="JobDetailsInputn1">
                            <asp:label id="lblvessel" runat="server" text="Job Details"></asp:label>
                            <asp:textbox id="txtvessel" runat="server" tooltip="Job Details" placeholder="" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
                        </div>
                        <div class="JobDetailsInputn2">
                            <asp:label id="Label17" runat="server" text="Shipper"></asp:label>
                            <asp:textbox id="txtshipper" runat="server" tooltip="Shipper" placeholder="" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
                        </div>
                        <div class="DesiInputn2">
                            <asp:label id="lblAgent" runat="server" text="Agent"></asp:label>
                            <asp:textbox id="txtagent" runat="server" tooltip="Agent" placeholder="" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
                        </div>
                    </div>

                    <div class="FormGroupContent4" style="display: none;">
                        <div class="JobDetailsInputn1">
                            <asp:label id="Label19" runat="server" text="Consignee"></asp:label>
                            <asp:textbox id="txtconsignee" runat="server" tooltip="Consignee" placeholder="" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
                        </div>
                        <div class="DesiInputn1">
                            <asp:label id="lblmlo" runat="server" text="MLO"></asp:label>
                            <asp:textbox id="txtmlo" runat="server" tooltip="Main-Line Operator" placeholder="" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
                        </div>
                        <div class="JobDetailsInputn2">
                            <asp:label id="Label21" runat="server" text="Notify Party"></asp:label>
                            <asp:textbox id="txtnotify" tooltip="Notify Party" placeholder="" runat="server" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
                        </div>
                        <div class="DesiInputn2">
                            <asp:label id="lblcnf1" runat="server" text="CNF"></asp:label>
                            <asp:textbox id="txtcnf" runat="server" tooltip="CNF" placeholder="" cssclass="form-control" autopostback="True" readonly="True"></asp:textbox>
                        </div>
                    </div>


                    <div class="FormGroupContent4 boxmodal">
                        <div class="ChargeInput blueheighlight">
                            <asp:label id="Label24" runat="server" text="Charge Description"></asp:label>
                            <asp:textbox id="txtcharge" runat="server" tooltip="Charge Description" placeholder="" cssclass="form-control" autopostback="True" tabindex="12" ontextchanged="txtcharge_TextChanged"></asp:textbox>
                        </div>
                        <%--  <div class="STGSTInput"><asp:TextBox ID="txt_stgst" runat="server" ToolTip="ST/GST" placeholder="ST/GST" CssClass="form-control" AutoPostBack="True" TabIndex="11" ></asp:TextBox></div>--%>
                        <div class="CurrInput blueheighlight">
                            <asp:label id="Label25" runat="server" text="Curr"></asp:label>
                            <asp:textbox id="txtcurr" runat="server" tooltip="Curr" placeholder="" cssclass="form-control" autopostback="True" tabindex="13" ontextchanged="txtcurr_TextChanged"></asp:textbox>
                        </div>
                        <div class="RateInput blueheighlight">
                            <asp:label id="Label26" runat="server" text="Rate"></asp:label>
                            <asp:textbox id="txtrate" runat="server" tooltip="Rate" placeholder="" cssclass="form-control" autopostback="True" tabindex="14" ontextchanged="txtrate_TextChanged"></asp:textbox>
                        </div>
                        <div class="EXRate blueheighlight">
                            <asp:label id="Label27" runat="server" text="Ex Rate"></asp:label>
                            <asp:textbox id="txtex" runat="server" tooltip="Ex Rate" placeholder="" cssclass="form-control" autopostback="True" tabindex="15" ontextchanged="txtex_TextChanged"></asp:textbox>
                        </div>
                        <div class="BLDropN2 blueheighlight">
                            <asp:label id="Label28" runat="server" text="UoM"></asp:label>
                            <asp:dropdownlist id="cmbbase" runat="server" tooltip="Select Base" placeholder="Base / Units" autopostback="True" tabindex="16" data-placeholder="Base / Units" cssclass="chzn-select" onselectedindexchanged="cmbbase_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                        <div class="AmoutnInputN2 blueheighlight">
                            <asp:label id="Label29" runat="server" text="Amount"></asp:label>
                            <asp:textbox id="txtamount" runat="server" tooltip="Amount" placeholder="" cssclass="form-control" autopostback="True" tabindex="17" readonly="true"></asp:textbox>
                        </div>
                        <div class="btn ico-add " id="btnadd1" runat="server" style="margin-top: 11px; margin-left:3px;">
                            <asp:button id="btnadd" runat="server" Text="Add" tooltip="Add" tabindex="18" onclick="btnadd_Click" />
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:panel id="pnlCharge" runat="server" cssclass="gridpnl MB0" scrollbars="Auto">
                            <asp:GridView ID="grd" TabIndex="13" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" PageSize="3" Width="100%" ForeColor="Black" OnPageIndexChanging="grd_PageIndexChanged" AllowPaging="false" CssClass="Grid FixedHeader" OnRowDataBound="grd_RowDataBound" OnSelectedIndexChanged="grd_SelectedIndexChanged" OnPreRender="grd_PreRender">
                                <Columns>
                                      <asp:TemplateField HeaderText="Sl #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>

                                    <asp:BoundField DataField="CHARge" HeaderText="Charges">
                                        <HeaderStyle Width="380" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="curr" HeaderText="Curr">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="110" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="110" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="110" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="bASe" HeaderText="UoM">
                                        <HeaderStyle HorizontalAlign="Center" Width="110" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}">
                                        <HeaderStyle HorizontalAlign="Center" Width="110" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}">
                                        <HeaderStyle HorizontalAlign="Center" Width="110" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="110" />
                                        <ItemStyle HorizontalAlign="right" />
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
                        </asp:panel>


                        <div class="FormGroupContent4">
                           



                            <div class="TotalInputosdn">
                              
                                <asp:Label Text="Total" runat="server" />
                                <asp:textbox id="txtTotal" runat="server" cssclass="form-control" tooltip=" " placeholder=" " autopostback="True"></asp:textbox>
                            </div>


                        </div>




                        <asp:panel id="PanelLog" runat="server" cssclass="modalPopup" borderstyle="Solid" borderwidth="2px" style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server"></label>

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


                    </asp:panel>



                    </div>
                </div>
            </div>
            </div>
        </div>


            <asp:panel runat="Server" id="pnlConfirm" cssclass="Pnl" style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want Add One more Invoice </b></div>
        <br />
        <div class="div_confirm">

            <asp:Button ID="btnok" runat="server" Text="Yes" CssClass="Button" OnClick="btnok_Click" />
            <asp:Button ID="btnno" runat="server" Text="No" CssClass="Button" OnClick="btnno_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:panel>

            <div class="div_Break"></div>
            <div class="div_Break"></div>
            <ajaxtoolkit:modalpopupextender id="popupconfirmnew" runat="server" popupcontrolid="pnlConfirm" targetcontrolid="lbl">
    </ajaxtoolkit:modalpopupextender>
            <asp:label id="lbl" runat="server" text="Label" style="display: none;"></asp:label>

            <div class="div_Break"></div>



            <asp:panel runat="Server" id="Panel_Service" cssclass="Pnl" style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>GST Applicable For This Charge..Do You Want to add?? </b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="No" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:panel>
            <div class="div_Break"></div>
            <div class="div_Break"></div>
            <ajaxtoolkit:modalpopupextender id="PopUpService" runat="server" popupcontrolid="Panel_Service" targetcontrolid="Label1">
    </ajaxtoolkit:modalpopupextender>
            <asp:label id="Label1" runat="server" text="Label" style="display: none;"></asp:label>


            <asp:label id="lbllog1" runat="server"></asp:label>

            <ajaxtoolkit:modalpopupextender id="ModalPopupExtenderlog" runat="server" popupcontrolid="PanelLog"
                dropshadow="false" targetcontrolid="lbllog1" cancelcontrolid="Image1" behaviorid="Test1">
    </ajaxtoolkit:modalpopupextender>

            <asp:Panel runat="Server" ID="popup_upload" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image2" runat="server" ImageUrl="../Theme/assets/img/buttonIcon/active/close-sm.png" Width="20px" />
            </div>
            <asp:Panel ID="pnl_emp1" runat="server" Width="100%" Height="100%" CssClass="\">
                <div class="">
                  <iframe id="iframe_outstd" runat="server" src="" frameborder="0"></iframe>
                </div>
            </asp:Panel>
        </div>
    </asp:Panel>

    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="popup_uploaddoc" runat="server" PopupControlID="popup_upload" TargetControlID="lbl1"
        CancelControlID="Image2">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="lbl1" runat="server" Text="Label" Style="display: none;"></asp:Label>

            <%--Hidden Fields--%>
    <asp:HiddenField ID="hf_updoc" runat="server" />
            <asp:hiddenfield id="txtjobno" runat="server" />
            <asp:hiddenfield id="hdnblno" runat="server" />
            <asp:hiddenfield id="hdncustid" runat="server" />
            <asp:hiddenfield id="hdncityid" runat="server" />
            <asp:hiddenfield id="hdnChargid" runat="server" />
            <asp:hiddenfield id="hdncurrid" runat="server" />
            <asp:hiddenfield id="hdnUnit" runat="server" />
            <asp:hiddenfield id="hdnfatransfer" runat="server" />
            <asp:hiddenfield id="hfWasConfirmed" runat="server" />
            <asp:hiddenfield id="hid_cmbase" runat="server" />

            <asp:hiddenfield id="hf_custid" runat="server" />
            <asp:hiddenfield id="hf_strtype" runat="server" />
            <asp:hiddenfield id="cstid" runat="server" />
            <asp:hiddenfield id="hd_exrate" runat="server" />
            <asp:hiddenfield id="hid_gstdate" runat="server" />

            <asp:hiddenfield id="hid_getdate" runat="server" />

            <asp:hiddenfield id="hid_SupplyTo" runat="server" />
            <asp:hiddenfield id="hid_SupplyToadd" runat="server" />
            <asp:hiddenfield id="hid_SupplyTonew" runat="server" />

            <asp:hiddenfield id="hid_cosigneeid" runat="server" />

            <asp:hiddenfield id="hid_mloid" runat="server" />
</asp:Content>
