<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AEAWBDetails.aspx.cs" Inherits="logix.AE.AEAWBDetails" %>

<%@ Register TagPrefix="asp" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
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

    <link href="../Styles/AEAWBDetails.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
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
            .AgentChk1, div#logix_CPH_switchblid {
    display: flex;
    flex-direction: column-reverse;
}
            .AgentChk1 center+label,
            div#logix_CPH_switchblid center+label {
       font-size: 13px !important;
    margin: 0 0 0 0px !important;
    display: block;
    color: #06529c !important;
        font-weight: 500;
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

       .AgentChk1 {
    width: 13%;
    float: left;
    margin: 8px 0px 0px 15px;
}
        div#UpdatePanel1 {
    height: 87vh;
    overflow-x: hidden;
    overflow-y: hidden;
}
.TypeInput5 {
    float: left;
    width: 18.5%;
    margin: 0px 0px 0px 0px;
}

        .By {
            /* margin-left: 0.5%; */
            width: 51%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .tbl_400 {
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
    height: 115px !important;
}
 
    </style>
    <style type="text/css">
        .DivSecPanel {
            width: 20px;
            height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: 0%;
            border-radius: 90px 90px 90px 90px;
        }

        .divRoated {
            width: 90%;
            height: 75vh;
            overflow: hidden;
            background: #fff;
            border-radius: 3px;
        }

        #logix_CPH_ddl_cmbpkgdesc_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddl_cmbwttype_chzn {
            width: 100% !important;
        }

        #logix_CPH_Grd_book_popup_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_grd_view_popup_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_Pnl_grd {
            top: 50px !important;
        }

        .Gridpnlnew {
            height: 90%;
            width: 99%;
            overflow-y: scroll;
            overflow-x: auto;
            margin: 0 auto;
            border: 1px solid #b1b1b1;
        }

        .Gridpnlnew1 {
            overflow: auto;
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
    
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
    
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

        .grdshipperfield {
            width: 20%;
            float: left;
        }

        .minWt {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            height: 25px;


        }

        .RateClass {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .Amount1 {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .Citem1 {
            width: 26%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

       .DVCharge {
    width: 24.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}

        .DVCustoms {
           width: 18.5%;
    float: left;
    margin: 0px 0px 0px 0px;
    font-size: 11px;
    color: #000080;
        }

.JboInput1 {
    width: 32%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .BookingInput10 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .Hawbl {
    width: 47%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .IssueCal {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .FrieghtDrop {
            width: 29%;
            float: left;
            margin: 0px 0% 0px 0px;


        }

        .Shipper1 {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;


                margin-right: 0.5% !important;
        }

        .Consignee4 {
            width: 49.5%;
            margin: 0px 0px 0px 0px;
            float: left;


        }

        .Shipper1 {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .Consignee4 {
            width: 49.5%;
            margin: 0px 0px 0px 0px;
            float: left;


        }

        .FromInput2 {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .ToPort {
    width: 49.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        input#logix_CPH_txt_charge {
            width: 100%;
        }
       
.grdcustomer {
    height: 181px !important;
}
.BookingInput {
    float: left;
    width: 17%;
    margin: 0px 0.2% 0px 0.2%;
}
.Hawbl {
    width: 47%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.box1 {
    width: 36.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.box2 {
    width: 39.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.box3 {
    width: 23%;
    float: left;
    box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
    margin: 0px 0px 6px 0px;
    height:769px;
}
.box3 .FormGroupContent4 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
}
        input#logix_CPH_txt_jobno {
    border: none !important;
}
        .TextField .inputcolor, .TextField .inputcolor:focus {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
        textarea#logix_CPH_txt_saddress {
    height: 104px !important;
}
        textarea#logix_CPH_txt_caddress {
    height: 104px !important;
}
        textarea#logix_CPH_txt_naddress1 {
    height: 104px !important;
}
        textarea#logix_CPH_txt_naddress2 {
    height: 104px !important;
}
        textarea#logix_CPH_txt_desc {
    height: 104px !important;
}
        .AgentChk1 center+label, div#logix_CPH_switchblid center+label {
    font-size: 13px !important;
    margin: 0px 0px 5px 0px !important;
    display: block;
    color: #06529c !important;
    font-weight: 500;
}
        
    </style>
    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
            $(document).ready(function () {
                $('input:text:first').focus();
            });

            <%--  $(document).ready(function () {

                $("#<%=txt_shipper.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intshipperid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getcusname",
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
                        if (i.item) {
                            $("#<%=txt_shipper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intshipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipper.ClientID %>").change();
                            $("#<%=txt_shipper.ClientID %>").val(i.item.address);
                        }
                     },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shipper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intshipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipper.ClientID %>").val($.trim(result));
                            $("#<%=txt_shipper.ClientID %>").val(i.item.address);
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shipper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intshipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipper.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_shipper.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_shipper.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });--%>

            <%--  $(document).ready(function () {
                $("#<%=txt_shipper.ClientID %>").autocomplete({

                      source: function (request, response) {
                          $("#<%=hf_intshipperid.ClientID %>").val(0);
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
                                 //alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alert(response.responseText);
                             }

                         });
                     },

                     select: function (event, i) {
                         $("#<%=hf_intshipperid.ClientID %>").val(i.item.val);
                         $("#<%=txt_shipper.ClientID %>").change();
                         $("#<%=txt_saddress.ClientID %>").val(i.item.address);
                     },
                     focus: function (e, i) {
                         $("#<%=hf_intshipperid.ClientID %>").val(i.item.val);
                     },
                     close: function (e, i) {
                         var result = $("#<%=txt_shipper.ClientID %>").val().toString().split(',')[0];
                         $("#<%=txt_shipper.ClientID %>").val($.trim(result));
                         $("#<%=txt_saddress.ClientID %>").val(i.item.address);
                     },
                     minLength: 1
                 });
              });--%>

            $(document).ready(function () {
                $("#<%=txt_shipper.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intshipperid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddressnew",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=hf_intshipperid.ClientID %>").val(i.item.val);
                        $("#<%=txt_shipper.ClientID %>").change();
                        $("#<%=txt_saddress.ClientID %>").val(i.item.address);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_shipper.ClientID %>").val(i.item.label);
                        $("#<%=hf_intshipperid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_shipper.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_shipper.ClientID %>").val($.trim(result));
                        $("#<%=txt_saddress.ClientID %>").val(i.item.address);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_consignee.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intconsid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddressnew",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=hf_intconsid.ClientID %>").val(i.item.val);
                        $("#<%=txt_consignee.ClientID %>").change();
                        $("#<%=txt_caddress.ClientID %>").val(i.item.address);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_consignee.ClientID %>").val(i.item.label);
                        $("#<%=hf_intconsid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_consignee.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_consignee.ClientID %>").val($.trim(result));
                        $("#<%=txt_caddress.ClientID %>").val(i.item.address);
                    },
                    minLength: 1
                });
            });

            <%-- $(document).ready(function () {

                $("#<%=txt_consignee.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intconsid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getcuname",
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
                        if (i.item) {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intconsid.ClientID %>").val(i.item.val);
                            $("#<%=txt_consignee.ClientID %>").change();
                            $("#<%=txt_consignee.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intconsid.ClientID %>").val(i.item.val);
                            $("#<%=txt_consignee.ClientID %>").val($.trim(result));
                            $("#<%=txt_consignee.ClientID %>").val(i.item.address);
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intconsid.ClientID %>").val(i.item.val);
                            $("#<%=txt_consignee.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_consignee.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_consignee.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });--%>
            <%-- $(document).ready(function () {
                $("#<%=txt_consignee.ClientID %>").autocomplete({

                      source: function (request, response) {
                          $("#<%=hf_intconsid.ClientID %>").val(0);
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
                                  //alert(response.responseText);
                              },
                              failure: function (response) {
                                  //alert(response.responseText);
                              }

                          });
                      },

                      select: function (event, i) {
                          $("#<%=hf_intconsid.ClientID %>").val(i.item.val);
                         $("#<%=txt_consignee.ClientID %>").change();
                         $("#<%=txt_caddress.ClientID %>").val(i.item.address);
                     },
                    focus: function (e, i) {
                        $("#<%=hf_intconsid.ClientID %>").val(i.item.val);
                     },
                     close: function (e, i) {
                         var result = $("#<%=txt_consignee.ClientID %>").val().toString().split(',')[0];
                         $("#<%=txt_consignee.ClientID %>").val($.trim(result));
                         $("#<%=txt_caddress.ClientID %>").val(i.item.address);
                     },
                    minLength: 1
                });
              });--%>

            <%--  $(document).ready(function () {

                $("#<%=txt_notifyparty1.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intnotifyid1.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getnotifyname",
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
                        if (i.item) {
                            $("#<%=txt_notifyparty1.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intnotifyid1.ClientID %>").val(i.item.val);
                            $("#<%=txt_notifyparty1.ClientID %>").change();
                            $("#<%=txt_notifyparty1.ClientID %>").val(i.item.address);
                        }
                      },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_notifyparty1.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intnotifyid1.ClientID %>").val(i.item.val);
                            $("#<%=txt_notifyparty1.ClientID %>").val($.trim(result));
                            $("#<%=txt_notifyparty1.ClientID %>").val(i.item.address);
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_notifyparty1.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intnotifyid1.ClientID %>").val(i.item.val);
                            $("#<%=txt_notifyparty1.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_notifyparty1.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_notifyparty1.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $("#<%=txt_notifyparty1.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intnotifyid1.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddressnew",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=hf_intnotifyid1.ClientID %>").val(i.item.val);
                        $("#<%=txt_notifyparty1.ClientID %>").change();
                        $("#<%=txt_naddress1.ClientID %>").val(i.item.address);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_notifyparty1.ClientID %>").val(i.item.label);
                        $("#<%=hf_intnotifyid1.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_notifyparty1.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_notifyparty1.ClientID %>").val($.trim(result));
                        $("#<%=txt_naddress1.ClientID %>").val(i.item.address);
                    },
                    minLength: 1
                });
            });

            <%--  $(document).ready(function () {

                $("#<%=txt_notifyparty2.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intnotifyid2.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getnotifyname1",
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
                        if (i.item) {
                            $("#<%=txt_notifyparty2.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intnotifyid2.ClientID %>").val(i.item.val);
                            $("#<%=txt_notifyparty2.ClientID %>").change();
                            $("#<%=txt_notifyparty2.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_notifyparty2.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intnotifyid2.ClientID %>").val(i.item.val);
                            $("#<%=txt_notifyparty2.ClientID %>").val($.trim(result));
                            $("#<%=txt_notifyparty2.ClientID %>").val(i.item.address);
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_notifyparty2.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intnotifyid2.ClientID %>").val(i.item.val);
                            $("#<%=txt_notifyparty2.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_notifyparty2.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_notifyparty2.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $("#<%=txt_notifyparty2.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intnotifyid2.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomerAddressnew",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=hf_intnotifyid2.ClientID %>").val(i.item.val);
                        $("#<%=txt_notifyparty2.ClientID %>").change();
                        $("#<%=txt_naddress2.ClientID %>").val(i.item.address);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_notifyparty2.ClientID %>").val(i.item.label);
                        $("#<%=hf_intnotifyid2.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_notifyparty2.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_notifyparty2.ClientID %>").val($.trim(result));
                        $("#<%=txt_naddress2.ClientID %>").val(i.item.address);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_fromport.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intfromid.ClientID %>").val(0);

                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getportname",

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
                                alert(response.responseText);
                            },
                            failure: function (response) {
                                alert(response.responseText);
                            }

                        });
                    },

                    <%--select: function (e, i) {
                        $("#<%=txt_fromport.ClientID %>").change();
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    change: function (e, i) {
                        $("#<%=txt_fromport.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_fromport.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=txt_fromport.ClientID %>").val(i.item.label);
                    },--%>
                    select: function (event, i) {
                        $("#<%=txt_fromport.ClientID %>").val(i.item.label);
                        $("#<%=txt_fromport.ClientID %>").change();
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_fromport.ClientID %>").val(i.item.label);
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_fromport.ClientID %>").val(i.item.label);
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_fromport.ClientID %>").val(i.item.label);
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_toport.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_inttoid.ClientID %>").val(0);

                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getponame",

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
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_toport.ClientID %>").val(i.item.label);
                        $("#<%=txt_toport.ClientID %>").change();
                        $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_toport.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_toport.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_toport.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                    },
                    <%--select: function (e, i) {
                            $("#<%=txt_toport.ClientID %>").change();
                            $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                        },
                        change: function (e, i) {
                            $("#<%=txt_toport.ClientID %>").val(i.item.label);
                        },
                        focus: function (e, i) {
                            $("#<%=txt_toport.ClientID %>").val(i.item.label);
                        },
                        close: function (e, i) {
                            $("#<%=txt_toport.ClientID %>").val(i.item.label);
                        },--%>
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_cnf.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intchaid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getnotify2",
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
                    <%-- select: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cnf.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intchaid.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txt_cnf.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                           $("#<%=hf_intchaid.ClientID %>").val(i.item.val);
                       }
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=txt_cnf.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intchaid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (e, i) {
                        if (i.item) {
                            $("#<%=txt_cnf.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intchaid.ClientID %>").val(i.item.val);
                        }
                    },--%>

                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cnf.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intchaid.ClientID %>").val(i.item.val);
                            $("#<%=txt_cnf.ClientID %>").change();
                            $("#<%=txt_cnf.ClientID %>").val(i.item.address);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cnf.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intchaid.ClientID %>").val(i.item.val);
                            $("#<%=txt_cnf.ClientID %>").val($.trim(result));
                            $("#<%=txt_cnf.ClientID %>").val(i.item.address);
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cnf.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_intchaid.ClientID %>").val(i.item.val);
                            $("#<%=txt_cnf.ClientID %>").val(i.item.address);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_cnf.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_cnf.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_curr.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_curid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/GetCurr",
                            data: "{ 'prefix': '" + request.term + "'}",
                            //data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_curr').value + "'}",
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
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
                            }

                        });
                    },

                    <%-- select: function (e, i) {
                            $("#<%=txt_curr.ClientID %>").change();
                            $("#<%=hf_curid.ClientID %>").val(i.item.val);
                        },
                    change: function (e, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        },
                        focus: function (e, i) {
                            $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        },
                        close: function (e, i) {
                            $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        },--%>
                    select: function (event, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        $("#<%=txt_curr.ClientID %>").change();
                        $("#<%=hf_curid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        $("#<%=hf_curid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        $("#<%=hf_curid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        $("#<%=hf_curid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_to1.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_inttoid1.ClientID %>").val(0);

                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getportname",

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
                                // alert(response.responseText);
                            }

                        });
                    },

                    <%--  select: function (e, i) {
                            $("#<%=txt_to1.ClientID %>").change();
                            $("#<%=hf_inttoid1.ClientID %>").val(i.item.val);
                        },
                        change: function (e, i) {
                            $("#<%=txt_to1.ClientID %>").val(i.item.label);
                        },
                        focus: function (e, i) {
                            $("#<%=txt_to1.ClientID %>").val(i.item.label);
                        },
                        close: function (e, i) {
                            $("#<%=txt_to1.ClientID %>").val(i.item.label);
                        },--%>
                    select: function (event, i) {
                        $("#<%=txt_to1.ClientID %>").val(i.item.label);
                        $("#<%=txt_to1.ClientID %>").change();
                        $("#<%=hf_inttoid1.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_to1.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid1.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_to1.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid1.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_to1.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid1.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_by1.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intbyid1.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getnotify3",
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
                        $("#<%=hf_intbyid1.ClientID %>").val(i.item.val);
                        $("#<%=txt_by1.ClientID %>").change();

                    },
                    focus: function (e, i) {
                        $("#<%=hf_intbyid1.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_by1.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_by1.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_to2.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_inttoid2.ClientID %>").val(0);

                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getponame1",

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
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alert(response.responseText);
                            }

                        });
                    },

                    <%-- select: function (e, i) {
                            $("#<%=txt_to2.ClientID %>").change();
                            $("#<%=hf_inttoid2.ClientID %>").val(i.item.val);
                        },
                        change: function (e, i) {
                            $("#<%=txt_to2.ClientID %>").val(i.item.label);
                        },
                        focus: function (e, i) {
                            $("#<%=txt_to2.ClientID %>").val(i.item.label);
                        },
                        close: function (e, i) {
                            $("#<%=txt_to2.ClientID %>").val(i.item.label);
                        },--%>
                    select: function (event, i) {
                        $("#<%=txt_to2.ClientID %>").val(i.item.label);
                        $("#<%=txt_to2.ClientID %>").change();
                        $("#<%=hf_inttoid2.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_to2.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid2.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_to2.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid2.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_to2.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid2.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_by2.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intbyid2.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getnotify4",
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
                        $("#<%=hf_intbyid2.ClientID %>").val(i.item.val);
                        $("#<%=txt_by2.ClientID %>").change();

                    },
                    focus: function (e, i) {
                        $("#<%=hf_intbyid2.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_by2.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_by2.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_to3.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_inttoid3.ClientID %>").val(0);

                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getponame2",

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
                                //alert(response.responseText);
                            }

                        });
                    },

                    <%--  select: function (e, i) {
                            $("#<%=txt_to3.ClientID %>").change();
                            $("#<%=hf_inttoid3.ClientID %>").val(i.item.val);
                        },
                        change: function (e, i) {
                            $("#<%=txt_to3.ClientID %>").val(i.item.label);
                        },
                        focus: function (e, i) {
                            $("#<%=txt_to3.ClientID %>").val(i.item.label);
                        },
                        close: function (e, i) {
                            $("#<%=txt_to3.ClientID %>").val(i.item.label);
                        },--%>
                    select: function (event, i) {
                        $("#<%=txt_to3.ClientID %>").val(i.item.label);
                        $("#<%=txt_to3.ClientID %>").change();
                        $("#<%=hf_inttoid3.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_to3.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid3.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_to3.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid3.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_to3.ClientID %>").val(i.item.label);
                        $("#<%=hf_inttoid3.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_by3.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intbyid3.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getnotify5",
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
                        $("#<%=hf_intbyid3.ClientID %>").val(i.item.val);
                        $("#<%=txt_by3.ClientID %>").change();

                    },
                    focus: function (e, i) {
                        $("#<%=hf_intbyid3.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_by3.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_by3.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_cargo.ClientID %>").autocomplete({

                    source: function (request, response) {

                        $("#<%=hf_IntCOMMODITY.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getcargo",
                            /*  data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_cargo').value + "'}",*/
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
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
                            }

                        });
                    },

                    select: function (e, i) {
                        $("#<%=txt_cargo.ClientID %>").change();
                        $("#<%=hf_IntCOMMODITY.ClientID %>").val(i.item.val);
                    },
                    change: function (e, i) {
                        $("#<%=txt_cargo.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_cargo.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=txt_cargo.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_inscurr.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_curid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/GetCurr",
                            /*  data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_inscurr').value + "'}",*/
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
                                // alert(response.responseText);
                            }

                        });
                    },

                    select: function (e, i) {
                        $("#<%=txt_inscurr.ClientID %>").change();
                        $("#<%=hf_curid.ClientID %>").val(i.item.val);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_inscurr.ClientID %>").val(i.item.val);
                    },
                    <%--change: function (e, i) {
                            $("#<%=txt_inscurr.ClientID %>").val(i.item.label);
                        },                        
                        close: function (e, i) {
                            $("#<%=txt_inscurr.ClientID %>").val(i.item.label);
                        },--%>
                    minLength: 1
                });
            });
            $(document).ready(function () {

                $("#<%=txt_issueat.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intissuedid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getportname",
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
                    <%-- select: function (event, i) {
                            $("#<%=hf_intissuedid.ClientID %>").val(i.item.val);
                            $("#<%=txt_issueat.ClientID %>").change();

                        },
                        focus: function (e, i) {
                            $("#<%=hf_intissuedid.ClientID %>").val(i.item.val);
                        },
                        close: function (e, i) {
                            var result = $("#<%=txt_issueat.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txt_issueat.ClientID %>").val($.trim(result));

                        },--%>

                    select: function (event, i) {
                        $("#<%=txt_issueat.ClientID %>").val(i.item.label);
                        $("#<%=txt_issueat.ClientID %>").change();
                        $("#<%=hf_intissuedid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_issueat.ClientID %>").val(i.item.label);
                        $("#<%=hf_intissuedid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_issueat.ClientID %>").val(i.item.label);
                        $("#<%=hf_intissuedid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_issueat.ClientID %>").val(i.item.label);
                        $("#<%=hf_intissuedid.ClientID %>").val(i.item.val);
                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_ablno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "../AE/AEAWBDetails.aspx/Getname",
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
                        $("#<%=hf_porid.ClientID %>").val(i.item.val);
                        $("#<%=txt_ablno.ClientID %>").change();

                    },

                    focus: function (event, i) {
                        $("#<%=txt_ablno.ClientID %>").val(i.item.value);
                    },

                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            function getConfirmationValue() {

                if (confirm(' Are you sure you want to delete the details?')) {
                    $('#<%=hfWasConfirmed.ClientID%>').val('true')
                }
                else {
                    $('#<%=hfWasConfirmed.ClientID%>').val('false')
                }

                return true;
            }
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
        /*.blueheighlight {
            border:1px solid #4286f4!important;
        }*/
        .FromInput2 {
    width: 50%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        /*.CNFInput {
    width: 37%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}*/
        .CNFInput {
            width: 97.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

       .CurrInput4 {
    width: 10.4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .ToInput1 {
            width: 24%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }
 .ToInput2 {
    width: 24%;
    float: left;
    margin: 0px 0px 0px 0px;
}

        .ByInput {
            width: 35%;
            float: left;
            margin: 0px 0% 0px 0px;


        }

        .ByInput {
    width: 35%;
    float: left;
    margin: 0px 0px 0px 0px;
}

        .IssuedAt {
            width: 52.5%;
            float: left;
            margin: 0px 0px 0px 0px;


        }
.ChkBox {
    width: 7.5%;
    float: left;
    margin: 8px 0px 0px 15px;
}
.ToInput2 {
    width: 24%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .PPDrop {
    width:17.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}

  .PKGDrop {
    width: 46%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .PkgsInput1 {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;


           
        }

        .netwt {
    width: 28%;
    float: left;
    margin: 0px 0.5% 0px 0px;
    white-space: nowrap;
}

       .Gross2 {
    width: 28%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

       .ChargeWt {
    width: 28%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .GridAlign {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .ShipperN1 {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px !important;


        }

        .FormGroupContent4 textarea {
            height: 60px !important;
        }

        .FormGroupContent4 .ConsigneeN4 textarea {
    height: 44px !important;
}

        .FormGroupContent4 .ShipperN1 textarea {
            height: 60px !important;
        }

        .ConsigneeN4 {
            width: 100%;
            float: left;
            margin: 0px;


        }

        .GridHeight {
            width: 100%;
            margin: 0px;
            padding: 0px;
            height: 188px;
            border: 1px solid #b1b1b1;
        }

        .GridHeight1 {
            width: 100%;
            margin: 0px;
            padding: 0px;
            /*height: 105px;*/
            /*border: 1px solid #b1b1b1;*/
        }

            .GridHeight1 th {
                background-color: #dbdbdb;
    
                padding: 2px;
            }

        .DVRight {
            width: 39%;
            float: left;
            margin: 5px 0px 0px 0px;
        }

        .CHG {
            width: 15.5%;
            float: left;
            margin: 0px 7px 0px 0px;


        }

       .OtherDrop {
    width: 40.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}

       .Insurance1 {
    width: 23.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .DVLeft {
            width:37.4%;
            float: left;
            margin: 0px 0.1% 0px 0px;
        }

        .WTDrop {
            width: 23.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        .Commodity1 {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;


        }

        .Insurance {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;


        }

        input.grdchargefield1 {
            border: 1px solid #b1b1b1 !important;
            width: 265px;
            height: 21px;
        }

        .modalPopup {
            background-color: rgba(0, 0, 0, 0.75);
            width: 100%;
            height: 90%;
            margin-left: 0%;
            margin-top: -1%;
            border: 1px solid #b1b1b1;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        span.chktext {
    font-weight: normal !important;
    margin: 0!important;
    font-weight: 500 !important;

}
        .Pallet {
    width: 16.5%;
    margin: 0px 0.5% 0px 0px;
    float: left;
}
 div#logix_CPH_switchblid {
    margin-top: 9px;
    float: left;
    margin-left: 9px;
}
        .divleft{
                width: 36.3%;
    float: left;
    margin: 0px 0.1% 0px 0px;
        }
        .ChargesDrop {
    width: 54.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    div#logix_CPH_btn_addn1 {
    margin-top: 8px;
}
    div#logix_CPH_Div1 {
    margin: 7px 0px 0px 0px;
}     
 div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 50px !important;
}
.Amount5 {
    width: 27%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.bordertopNew {
    float: left;
    border-top: 1px solid #b7b3b3 !important;
    width: 100%;
}
         div#logix_CPH_ddl_charge_chzn {
    width: 100% !important;
}
         input#logix_CPH_grd_grddimension_txt_item_length_0 {
    width: 80px !important;
}
         select#logix_CPH_grd_grddimension_cminch_0 {
    width: 102% !important;
}
         div#logix_CPH_ddl_pc_chzn {
    width: 100% !important;
}
         input#logix_CPH_grd_grddimension_txt_item_breadth_0 {
    width: 80px !important;
}
         input#logix_CPH_grd_grddimension_txt_item_width_0 {
    width: 80px !important;
}
input#logix_CPH_grd_grddimension_txt_item_piece_0 {
    width: 122px !important;
}
         .box3 span {
    background: #80808000 !important;
}
         .iputborder .FormGroupContent4 .TextField .form-control:disabled, .TextField .form-control[readonly]{
             background-color: #fff !important;
    opacity: 1;
         }
.ByInput1 {
    width: 40%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
  .AccInfo {
    float: left;
    width: 100%;
    margin: 0px 0px 0px 0px;
}
         textarea#logix_CPH_txt_acc {
    height: 104px !important;
}
.ToInput4{
    float:left;
    width:24%;
    margin:0px 0px 0px 0px;
}
.ToInput6 {
    width: 55% !important;
    float: left !important;
    margin: 0px 0px 0px 0px !important;
}
.IataInputnew {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_iatacarrier {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.AirlineName {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_airline {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.MawblFNo {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_flightno {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.MawblCala {
    float: left;
    width: 100%;
}
input#logix_CPH_txt_dtfdate {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.Mawbl {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_mawbno {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.StatusDrop2 {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
span#logix_CPH_Label54 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.JobAgent {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_agent {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
input#logix_CPH_cmbstatus {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
input#logix_CPH_txt_manifestno {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.Mawbl {
    width: 100% !important;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_to {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.ToPortInput {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_from {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.FromInput1 {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
input#logix_CPH_txt_dtfdate2 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.MawblCal2 {
    float: left;
    width: 100%;
}
input#logix_CPH_txt_flightno2 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
    border:none !important;
}
.MawblFNo {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblheader" Text="AWB Details" runat="server"></asp:Label></h4>
                          <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Ops & Docs</a> </li>
            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>

            <li class="current"><a href="#" title="">AWB Details</a> </li>
        </ul>
    </div>
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm"> 
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 FixedButtons">
                        <div class="left_btn">
                        <div class="btn ico-proforma-sales-invoice">
                            <asp:Button ID="Proinvoic" runat="server"  Text="Proforma Sales Invoice" ToolTip="Proforma Sales Invoice" TabIndex="45" OnClick="Proinvoic_Click" />
                        </div>
                        <div class="btn ico-proforma-purchase-invoice ">
                            <asp:Button ID="procrednote" runat="server" Text="Proforma Purchase Invoice" ToolTip="Proforma Purchase Invoice" TabIndex="46" OnClick="procrednote_Click" />
                        </div>
                            </div>
                        <div class="right_btn">

                            <div class="btn ico-reuse">
                                <asp:Button ID="btn_reuse" runat="server" Text="Reuse" ToolTip="Reuse"
                                    OnClick="btn_reuse_Click" />
                            </div>

                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btn_save" runat="server"  ToolTip="Save" TabIndex="40"
                                    OnClick="btn_save_Click" />
                            </div>
                            <div class="btn ico-view" style="display: none;">
                                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" TabIndex="41"
                                    OnClick="btn_view_Click" />
                            </div>
                            <div class="btn ico-delete">
                                <asp:Button ID="Btn_delete" runat="server" Text="Delete" ToolTip="Delete" OnClientClick="return ConfirmationBox();"
                                    OnClick="Btn_delete_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_back1" runat="server">
                                <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" TabIndex="42"
                                    OnClick="btn_back_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">                    
                        
                       <div class="FormGroupContent4">
                        <div class="BookingInput LinkButton">
                            <span>Booking #</span>
                            
                            <asp:TextBox ID="txt_bookno" runat="server" CssClass="form-control" placeholder="" ToolTip="Booking Number" ReadOnly="true" TabIndex="2" MaxLength="30"></asp:TextBox>
                        </div>
                         <asp:LinkButton ID="lbl_book" runat="server" CssClass="anc ico-find-sm" Text="" Style="text-decoration: none;"
                                ForeColor="Red" OnClick="lbl_book_Click"></asp:LinkButton>
                       
                        <div class="ChkBox" id="directbl" runat="server">
                            <span>Direct HAWB</span>
                            <asp:CheckBox ID="chk_directbl" runat="server"   />
                        </div>
                                           
                        <div class="AgentChk1">

                            <asp:CheckBox ID="chk_nomin" runat="server" Text="Nomination" TabIndex="43" />
                        </div>
                         <div class="" id="switchblid" runat="server">
                            <asp:CheckBox ID="chk_switchbl" runat="server" Text="Switch BL" TabIndex="44" />
                        </div>

                        </div>



                
                    <%--  --%>
                    <div class="box1">
                            <div class="FormGroupContent4">
                                 <div class="Hawbl">
     <asp:Label ID="Label1" runat="server" Text="HAWB #"></asp:Label>
     <asp:TextBox ID="txt_ablno" runat="server" CssClass="form-control" AutoPostBack="True"
         OnTextChanged="txt_ablno_TextChanged" placeholder="" ToolTip="HAWB Number" TabIndex="3" onkeypress="if (event.keyCode==39 ||event.keyCode==34) event.returnValue = false;"></asp:TextBox>
 </div>

                        <div class="IssuedAt blueheighlight">
                            <asp:Label ID="Label2" runat="server" Text="Issued At"></asp:Label>
                            <asp:TextBox ID="txt_issueat" runat="server" CssClass="form-control"
                                AutoPostBack="True" placeholder="" ToolTip="Issued At" TabIndex="4" OnTextChanged="txt_issueat_TextChanged"></asp:TextBox>
                        </div>
                                </div>

                         <div class="FormGroupContent4">
                        
                    
                            <asp:Label ID="Label6" runat="server" Text="Shipper"></asp:Label>
                            <asp:TextBox ID="txt_shipper" runat="server" CssClass="form-control"
                                OnTextChanged="txt_shipper_TextChanged" AutoPostBack="True" placeholder="" ToolTip="Shipper" TabIndex="7"></asp:TextBox>
                        
                             </div>
                        <div class="FormGroupContent4">
                            
                            <asp:Label ID="Label8" runat="server" Style="display: none" Text="Shipper Address"></asp:Label>
                            <asp:TextBox ID="txt_saddress" runat="server" TextMode="MultiLine" Rows="2" Columns="20" Style="resize: none;" CssClass="form-control"
                                placeholder="" ToolTip="Shipper Address"></asp:TextBox>
                                </div>
                            
                        <div class="FormGroupContent4">
                   
                            <asp:Label ID="Label10" runat="server" Text="Notify Party I"></asp:Label>
                            <asp:TextBox ID="txt_notifyparty1" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnTextChanged="txt_notifyparty1_TextChanged" placeholder="" ToolTip="Notify Party I" TabIndex="9"></asp:TextBox>
                        </div>
                            <div class="FormGroupContent4">
                        
                            <asp:Label ID="Label12" runat="server" Style="display: none" Text="Notify Party I Address"></asp:Label>
                            <asp:TextBox ID="txt_naddress1" runat="server" CssClass="form-control" Rows="2" Columns="20" Style="resize: none;"
                                TextMode="MultiLine" placeholder="" ToolTip="Notify Party I Address"></asp:TextBox>
                       
                                </div>
                        <div class="Commodity1 blueheighlight">
                            <asp:Label ID="Label41" runat="server" Text="Commodity"></asp:Label>
                            <asp:TextBox ID="txt_cargo" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Commodity" TabIndex="38" OnTextChanged="txt_cargo_TextChanged"></asp:TextBox>
                        </div>

                        <div class="FormGroupContent4">
                        <div class="ToInput1 blueheighlight">
                            <asp:Label ID="Label18" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to1" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="To" TabIndex="15" OnTextChanged="txt_to1_TextChanged"></asp:TextBox>
                        </div>
                        <div class="By ">
                            <asp:Label ID="Label19" runat="server" Text="By"></asp:Label>
                            <asp:TextBox ID="txt_by1" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="By" TabIndex="16" OnTextChanged="txt_by1_TextChanged"></asp:TextBox>
                        </div>
                        <div class="ToInput2 blueheighlight">
                            <asp:Label ID="Label20" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to2" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="To" TabIndex="17" OnTextChanged="txt_to2_TextChanged"></asp:TextBox>
                        </div>
                            </div>

                    <div class="FormGroupContent4 boxmodal">

                        <div class="PkgsInput1 blueheighlight">
                            <asp:Label ID="Label25" runat="server" Text="No.Of.Units" CssClass="hide"></asp:Label>
                            <asp:TextBox ID="txt_packages" runat="server" CssClass="form-control" placeholder="" ToolTip="Number of Packages" TabIndex="22" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="PKGDrop blueheighlight">
                            <asp:Label ID="Label27" runat="server" Text="Unit Type"></asp:Label>
                            <asp:DropDownList data-placeholder="Pkg Type" ID="ddl_cmbpkgdesc" runat="server" ToolTip="PACKAGE TYPE" CssClass="chzn-select" TabIndex="24">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="Pallet">
                            <asp:Label ID="Label26" runat="server" Text="Pallet"></asp:Label>
                            <asp:TextBox ID="txt_pallet" runat="server" CssClass="form-control" placeholder="" ToolTip="Number of Pallet" TabIndex="23" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="TypeInput5 blueheighlight">
                            <asp:Label ID="Label29" runat="server" Text="Wt Type"></asp:Label>
                            <asp:DropDownList data-placeholder="Wt Type" ID="ddl_cmbwttype" runat="server" ToolTip="TYPE" CssClass="chzn-select" TabIndex="26">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Value="K">KGS</asp:ListItem>
                                <asp:ListItem Value="L">LBS</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        </div>
                        <div class="FormGroupContent4">
                        <div class="CurrInput4">
                            <asp:Label ID="Label17" runat="server" Text="Curr"></asp:Label>
                            <asp:TextBox ID="txt_curr" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Currency" TabIndex="14" OnTextChanged="txt_curr_TextChanged"></asp:TextBox>
                        </div>

                        <div class="RateClass blueheighlight">
                            <asp:Label ID="Label33" runat="server" Text="Rate Class"></asp:Label>
                            <asp:TextBox ID="txt_rate" runat="server" CssClass="form-control"
                                OnTextChanged="txt_rate_TextChanged" AutoPostBack="True" placeholder="" ToolTip="Rate Class" TabIndex="30"></asp:TextBox>
                        </div>
                        <div class="Amount1">
                            <asp:Label ID="Label34" runat="server" Text="Amount"></asp:Label>
                            <asp:TextBox ID="txt_rcamt" runat="server" CssClass="form-control" placeholder="" ToolTip="Amount" TabIndex="31"></asp:TextBox>
                        </div>
                        <div class="Citem1">
                            <asp:Label ID="Label35" runat="server" Text="CItem No"></asp:Label>
                            <asp:TextBox ID="txt_citemno" runat="server" CssClass="form-control" MaxLength="3" placeholder="" ToolTip="Citem Number" TabIndex="32"></asp:TextBox>
                        </div>
                        <div class="DVCharge">
                            <asp:Label ID="Label36" runat="server" Text="D.V Carriage"></asp:Label>
                            <asp:TextBox ID="txt_dvca" runat="server" CssClass="form-control" placeholder="" ToolTip="D.v Carriage" TabIndex="33"></asp:TextBox>
                        </div>
                            </div>
                            <div class="ShipperN1 blueheighlight boxmodal">
                    <div class="FormGroupContent4">
                                <asp:Label ID="Label44" runat="server" Text="Description"></asp:Label>
                                <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control" Style="resize: none;" Rows="2" TabIndex="38" MaxLength="100" TextMode="MultiLine"
                                    placeholder="" ToolTip="Description"></asp:TextBox>
                        </div>
                                </div>
                            <div class="FormGroupContent4">
                        <div class="Insurance">
                            <asp:Label ID="Label42" runat="server" Text="Ins. Curr"></asp:Label>
                            <asp:TextBox ID="txt_inscurr" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Insurance" TabIndex="39" OnTextChanged="txt_inscurr_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Insurance1">
                            <asp:Label ID="Label43" runat="server" Text="Insurance Amt"></asp:Label>
                            <asp:TextBox ID="txt_insamt" runat="server" CssClass="form-control" placeholder="" ToolTip="Insurance Amount" TabIndex="340"></asp:TextBox>
                        </div>
                        <div class="ToInput6">
                            <asp:Label ID="Label24" runat="server" Text="Handling Info"></asp:Label>
                            <asp:TextBox ID="txt_handling" runat="server" CssClass="form-control" placeholder="" ToolTip="Handling Info" TabIndex="21"></asp:TextBox>
                        </div>
                                </div>

                            

                        </div>
                        

                        <div class="box2">
                        <div class="FormGroupContent4">
                        <div class="IssueCal blueheighlight">
                            <asp:Label ID="Label3" runat="server" Text="Issued On"></asp:Label>
                            <asp:TextBox ID="txt_dtissueon" runat="server" CssClass="form-control" placeholder="" ToolTip="Issued On" TabIndex="5"></asp:TextBox>
                            <asp:CalendarExtender ID="dtvalidity" runat="server" TargetControlID="txt_dtissueon"
                                Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                        <div class="FrieghtDrop blueheighlight">
                            <asp:Label ID="Label5" runat="server" Text="Freight"></asp:Label>
                            <asp:DropDownList data-placeholder="Freight" ID="ddl_cmbfreight" runat="server" CssClass="chzn-select" Width="100%" ToolTip="Freight" AutoPostBack="true" TabIndex="6" OnTextChanged="ddl_cmbfreight_TextChanged">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                            </div>

                             <div class="FormGroupContent4">
                       
                   
                            <asp:Label ID="Label7" runat="server" Text="Consignee"></asp:Label>
                            <asp:TextBox ID="txt_consignee" runat="server" CssClass="form-control"
                                OnTextChanged="txt_consignee_TextChanged" AutoPostBack="True" placeholder="" ToolTip="Consignee" TabIndex="8"></asp:TextBox>
                        
                        </div>
                            <div class="FormGroupContent4">
                        
                            <asp:Label ID="Label9" runat="server" Style="display: none" Text="Consignee Address"></asp:Label>
                            <asp:TextBox ID="txt_caddress" runat="server" TextMode="MultiLine" Rows="2" Columns="20" Style="resize: none;" CssClass="form-control"
                                placeholder="" ToolTip="Consignee Address"></asp:TextBox>
                        
                                </div>
                            <div class="FormGroupContent4">
                    
                            <asp:Label ID="Label11" runat="server" Text="Notify Party II"></asp:Label>
                            <asp:TextBox ID="txt_notifyparty2" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnTextChanged="txt_notifyparty2_TextChanged" placeholder="" ToolTip="Notify Party II" TabIndex="10"></asp:TextBox>
                        
                                </div>

                        <div class="FormGroupContent4">
                        
                            <asp:Label ID="Label13" runat="server" Style="display: none" Text="Notify Party II Address"></asp:Label>
                            <asp:TextBox ID="txt_naddress2" runat="server" CssClass="form-control" Rows="2" Columns="20" Style="resize: none;"
                                TextMode="MultiLine" placeholder="" ToolTip="Notify Party II Address"></asp:TextBox>
                        
                        </div>
                    <div class="FormGroupContent4 boxmodal">

                        <div class="FromInput2 blueheighlight">
                            <asp:Label ID="Label14" runat="server" Text="From Port"></asp:Label>
                            <asp:TextBox ID="txt_fromport" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="From Port" TabIndex="11" OnTextChanged="txt_fromport_TextChanged"></asp:TextBox>
                        </div>
                        <div class="ToPort blueheighlight">
                            <asp:Label ID="Label15" runat="server" Text="To Port"></asp:Label>
                            <asp:TextBox ID="txt_toport" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="To Port" TabIndex="12" OnTextChanged="txt_toport_TextChanged"></asp:TextBox>
                        </div>
                        </div>
                        <div class="FormGroupContent4">
                        <div class="ByInput1 blueheighlight">
                            <asp:Label ID="Label21" runat="server" Text="By"></asp:Label>
                            <asp:TextBox ID="txt_by2" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="By" TabIndex="18" OnTextChanged="txt_by2_TextChanged"></asp:TextBox>
                        </div>
                        <div class="ToInput4 blueheighlight">
                            <asp:Label ID="Label22" runat="server" Text="Final Destination "></asp:Label>
                            <asp:TextBox ID="txt_to3" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="FINAL DESTINATION" TabIndex="19" OnTextChanged="txt_to3_TextChanged"></asp:TextBox>
                        </div>
                        <div class="ByInput blueheighlight">
                            <asp:Label ID="Label23" runat="server" Text="By"></asp:Label>
                            <asp:TextBox ID="txt_by3" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="By" TabIndex="20" OnTextChanged="txt_by3_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                        <div class="FormGroupContent4">
                        <div class="Gross2 blueheighlight">
                            <asp:Label ID="Label28" runat="server" Text="Gross Wt"></asp:Label>
                            <asp:TextBox ID="txt_gross" runat="server" CssClass="form-control" placeholder="" ToolTip="Gross Weight" TabIndex="25"></asp:TextBox>
                        </div>

                        <div class="netwt blueheighlight">
                            <asp:Label ID="Label30" runat="server" Text="Volume Wt"></asp:Label>
                            <asp:TextBox ID="txt_volwt" runat="server" CssClass="form-control" placeholder="" ToolTip="Volume Weight" TabIndex="27"></asp:TextBox>
                        </div>
                        <div class="ChargeWt blueheighlight">
                            <asp:Label ID="Label31" runat="server" Text="Charge Wt"></asp:Label>
                            <asp:TextBox ID="txt_charge" runat="server" CssClass="form-control" placeholder="" ToolTip="Charge Weight" AutoPostBack="true" TabIndex="28" OnTextChanged="txt_charge_TextChanged"></asp:TextBox>
                        </div>
                        <div class="minWt blueheighlight">
                            <asp:Label ID="Label32" runat="server" Text="Min Wt"></asp:Label>
                            <asp:TextBox ID="txt_min" runat="server" CssClass="form-control" placeholder="" ToolTip="Minimun Weight" TabIndex="29"></asp:TextBox>
                        </div>
                        </div>
                        <div class="FormGroupContent4">
                        <div class="DVCustoms">
                            <asp:Label ID="Label37" runat="server" Text="D.V Customs"></asp:Label>
                            <asp:TextBox ID="txt_dvcus" runat="server" CssClass="form-control" placeholder="" ToolTip="D.V Customs" TabIndex="34"></asp:TextBox>
                        </div>
                        <div class="CHG">
                            <asp:Label ID="Label38" runat="server" Text="Chg code"></asp:Label>
                            <asp:TextBox ID="txt_chgcode" runat="server" CssClass="form-control" placeholder="" ToolTip="Chg Code" TabIndex="35"></asp:TextBox>
                        </div>

                         <div class="WTDrop">
                            <asp:Label ID="Label39" runat="server" Text="WT/VAL"></asp:Label>
                            <asp:DropDownList data-placeholder="WT/VAL" ID="ddl_cmbwt" runat="server" ToolTip="Weight/Value" CssClass="chzn-select" TabIndex="36">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="OtherDrop">
                            <asp:Label ID="Label40" runat="server" Text="Other"></asp:Label>
                            <asp:DropDownList data-placeholder="Other" ID="ddl_cmboth" runat="server" ToolTip="Other" CssClass="chzn-select" TabIndex="37">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                            </div>
   <div class="AccInfo">

       <asp:Label ID="Label45" runat="server" Text="Accounting Information"> </asp:Label>
       <asp:TextBox ID="txt_acc" runat="server" TextMode="MultiLine" Rows="2" Columns="20" Style="resize: none;" CssClass="form-control"
           placeholder="" ToolTip="Accounting Information"></asp:TextBox>
       </div>
                        
    <div class="ConsigneeN4 boxmodal">
  

               <asp:Label runat="server" Text="Other Charges" CssClass="hide"></asp:Label>
               <asp:TextBox ID="txt_othchg" runat="server" CssClass="form-control" Style="resize: none;" Rows="2" TabIndex="39" MaxLength="100" TextMode="MultiLine"
                   placeholder="Other Charges" ToolTip="Other Charges"></asp:TextBox>
       
           </div>
                        



                    
                         </div>
                        
                    <div class="box3">
                        <div class="FormGroupContent4">
                        <div class="JboInput1 LinkButton">
    <span>Job #</span>                            
    <asp:TextBox ID="txt_jobno" runat="server" CssClass="form-control inputcolor" AutoPostBack="True" placeholder="" ToolTip="Job Number" TabIndex="1" MaxLength="5"
        OnTextChanged="txt_jobno_TextChanged"></asp:TextBox>
                            
                            </div>
                          <asp:LinkButton ID="lbl_lnkrate" runat="server" CssClass="anc ico-find-sm" Style="text-decoration: none;" Text="" ForeColor="Red"
OnClick="lbl_lnkrate_Click"></asp:LinkButton>
                         </div> 
                        <div class="FormGroupContent4">
                        <div class="IataInputnew">
        <asp:Label ID="Label49" runat="server" Text="IATA Carrier"></asp:Label>
        <asp:TextBox ID="txt_iatacarrier" runat="server" CssClass="form-control" placeholder="" ToolTip="IATA Carrier" TabIndex="12" ReadOnly="true"></asp:TextBox>
    </div>
                            </div>
                        <div class="FormGroupContent4">
 <div class="AirlineName blueheighlight">
        <asp:Label ID="Label50" runat="server" Text="Air Line Name"></asp:Label>
        <asp:TextBox ID="txt_airline" runat="server" CssClass="form-control" placeholder="" ToolTip="Air Line Name" TabIndex="5"   ReadOnly="true" ></asp:TextBox>
    </div>
                            </div>
                        <div class="FormGroupContent4">
  <div class="MawblFNo blueheighlight">
        <asp:Label ID="Label51" runat="server" Text="Flight #"></asp:Label>
        <asp:TextBox ID="txt_flightno" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight Number" TabIndex="6"  ReadOnly="true"></asp:TextBox>
    </div>
                            </div>
                        <div class="FormGroupContent4">
    <div class="MawblCala">
        <asp:Label ID="Label52" runat="server" Text="Date"></asp:Label>
        <asp:TextBox ID="txt_dtfdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight Date" TabIndex="7"  ReadOnly="true"></asp:TextBox>
    </div>
                            </div>
                         <div class="FormGroupContent4">
                          <div class="MawblFNo blueheighlight">
      <asp:Label ID="Label56" runat="server" Text="Flight # 2"></asp:Label>
      <asp:TextBox ID="txt_flightno2" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight # 2" TabIndex="8"  ReadOnly="true"></asp:TextBox>
  </div>
                              </div>
                              <div class="FormGroupContent4">
  <div class="MawblCal2">
      <asp:Label ID="Label57" runat="server" Text="Date"></asp:Label>
      <asp:TextBox ID="txt_dtfdate2" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight Date 2" TabIndex="9"  ReadOnly="true"></asp:TextBox>
  </div>
                                   </div>
                          <div class="FormGroupContent4">
       <div class="FromInput1 blueheighlight">
              <asp:Label ID="Label58" runat="server" Text="From"></asp:Label>
              <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" placeholder="" ToolTip="From Port" TabIndex="12"  ReadOnly="true" ></asp:TextBox>
          </div>
                               </div>
                           <div class="FormGroupContent4">
          <div class="ToPortInput blueheighlight">
              <asp:Label ID="Label59" runat="server" Text="To"></asp:Label>
              <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" placeholder="" ToolTip="To Port" TabIndex="13"  ReadOnly="true" ></asp:TextBox>
          </div>
                         </div>
                           <div class="FormGroupContent4">
       <div class="Mawbl" style="width:21%" >
              <asp:Label ID="Label60" runat="server" Text="ManiFest #"></asp:Label>
              <asp:TextBox ID="txt_manifestno" runat="server" CssClass="form-control" placeholder="" ToolTip="ManiFest Number" TabIndex="14"  ReadOnly="true"></asp:TextBox>
          </div>
                         </div>



                        <div class="FormGroupContent4">
                          <div class="Mawbl blueheighlight">
        <asp:Label ID="Label53" runat="server" Text="MAWB #"></asp:Label>
        <asp:TextBox ID="txt_mawbno" runat="server" CssClass="form-control" placeholder="" ToolTip="MAWB Number" TabIndex="3"   ReadOnly="true"></asp:TextBox>
    </div>
                            </div>
                        <div class="FormGroupContent4">
<div class="StatusDrop2 blueheighlight">
        <asp:Label ID="Label54" runat="server" Text="Status"></asp:Label>
     <asp:TextBox ID="cmbstatus" runat="server" CssClass="form-control" placeholder="" ToolTip="MAWB Number" TabIndex="3"   ReadOnly="true"></asp:TextBox>
       <%-- <asp:DropDownList data-placeholder="Status" ID="ddl_cmbstatus" runat="server" AppendDataBoundItems="True"  CssClass="chzn-select" ToolTip="Status" placeholder="Status" TabIndex="10"  ReadOnly="true">
            <asp:ListItem Text="" Value="0"></asp:ListItem>
            <asp:ListItem Value="P">Prepaid</asp:ListItem>
            <asp:ListItem Value="T">Collect</asp:ListItem>
        </asp:DropDownList>--%>
    </div>
                            </div>
                        <div class="FormGroupContent4">
                             <div class="JobAgent blueheighlight">
        <asp:Label ID="Label55" runat="server" Text="Agent"></asp:Label>
        <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" placeholder="" ToolTip="Agent" TabIndex="8"  ReadOnly="true"></asp:TextBox>
    </div>
                        
                       </div>
                  </div>


                </div>

                    <div class="FormGroupContent4">


                            
                        </div>
                        <div class="DVLeft">

                            <div class="CNFInput blueheighlight boxmodal">
                    <div class="FormGroupContent4">
                                <asp:Label ID="Label16" runat="server" Text="CNF"></asp:Label>
                                <asp:TextBox ID="txt_cnf" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Cost And Freight" TabIndex="13" OnTextChanged="txt_cnf_TextChanged"></asp:TextBox>
                        </div>
                            </div>
                            </div>

                        <div class="DVRight boxmodal">
                        <div class="gridpnl">
                            <asp:Panel ID="pnl_grdcustomer" runat="server" CssClass="Grid FixedHeader" ScrollBars="Vertical">
                                <asp:GridView ID="grd_grddimension" runat="server" CssClass="FixedHeader" ShowHeaderWhenEmpty="true" Width="100%" AutoGenerateColumns="False"
                                    OnRowDataBound="grd_grddimension_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Length">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_item_length" runat="server" Text='<%#Bind("length") %>' CssClass="grdchargefield" onkeypress="return isNumberKey(event,'Length');"></asp:TextBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Breadth">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_item_breadth" runat="server" Text='<%#Bind("breadth") %>' CssClass="grdcurrfield" onkeypress="return isNumberKey(event,'Breadth');"></asp:TextBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Width">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_item_width" runat="server" Text='<%#Bind("width") %>' CssClass="grdcurrfield" onkeypress="return isNumberKey(event,'Width');"></asp:TextBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pieces">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_item_piece" runat="server" Text='<%#Bind("pieces") %>' CssClass="grdcurrfield" onkeypress="return isNumberKey(event,'Pieces');"></asp:TextBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <%-- <asp:TemplateField HeaderText="cminch" Visible="false">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_item_cminch" runat="server" Text='<%#Bind("cminch") %>' CssClass="grdcurrfield" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Cm & Inch">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="cminch" runat="server" data-placeholder="CM&Inch" ToolTip="CM&Inch" Width="98%">
                                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="C">CM</asp:ListItem>
                                                    <asp:ListItem Value="I">Inch</asp:ListItem>
                                                </asp:DropDownList>
                                                <%--  <asp:LinkButton ID="LinkButton5" runat="server" CssClass="Arrow" CommandName="Select" Font-Underline="false">⇛</asp:LinkButton>--%>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" Width="40%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Button ID="btnOk" runat="server" Text="+" OnClick="btnOk_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" Wrap="false" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Wrap="false" />

                                </asp:GridView>

                            </asp:Panel>

                        </div>
                            </div>



   <div class="FormGroupContent4">
       <div class="divleft">
   <div id="chargedetails" runat="server" visible="false">
    <div class="FormGroupContent4 boxmodal">
  
          </div>
   <div class="FormGroupContent4 boxmodal">
       <div class="ChargesDrop">
           <asp:Label ID="Label46" runat="server" Text="Charges Head"> </asp:Label>
           <asp:DropDownList ID="ddl_charge" runat="server" CssClass="chzn-select" Width="100%" data-placeholder="Charges Head" ToolTip="Charges Head">
               <asp:ListItem Text="" Value="0"></asp:ListItem>
           </asp:DropDownList>
       </div>
       <div class="Amount5">
           <asp:Label ID="Label47" runat="server" Text="Amount"> </asp:Label>
           <asp:TextBox ID="txt_amt" runat="server" placeholder="" ToolTip="Amount" CssClass="form-control" Style="text-align: right"></asp:TextBox>
       </div>
       <div class="PPDrop">
           <asp:Label ID="Label48" runat="server" Text="PP/CC"> </asp:Label>
           <asp:DropDownList ID="ddl_pc" runat="server" CssClass="chzn-select" Width="100%" data-placeholder="PP/CC" ToolTip="PP/CC">
               <asp:ListItem Text="" Value="0"></asp:ListItem>
           </asp:DropDownList>
       </div>
       </div>
       <div class="right_btn">
       <div class="btn ico-add" id="btn_addn1" runat="server">
           <asp:Button ID="btn_add" runat="server" Text="Add" ToolTip="Add" OnClick="btn_add_Click" />
       </div>
         <div class="btn ico-save" id="Div1" runat="server">
               <asp:Button ID="btnsave" runat="server"  Text="Save" ToolTip="Save" OnClick="btnsave_Click" />
           </div>
           
   </div>
   <div class="FormGroupContent4 boxmodal">
       <asp:Panel ID="panel_grd" runat="server" CssClass="gridpnl MB0">
           <asp:GridView ID="Grd_Charge" AutoGenerateColumns="False" runat="server" CssClass="Grid FixedHeader"  Width="100%" DataKeyNames="chargeid"
               OnRowDataBound="Grd_Charge_RowDataBound">
               <Columns>
                   <asp:BoundField DataField="charges" HeaderText="Charges" />
                   <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                       <HeaderStyle HorizontalAlign="Center" />
                       <ItemStyle HorizontalAlign="Right" />
                   </asp:BoundField>
                   <asp:BoundField DataField="ppcc" HeaderText="PP/CC" />
                   <asp:BoundField DataField="chargeid" HeaderText="Chargeid">
                       <HeaderStyle CssClass="Hide" />
                       <ItemStyle CssClass="Hide" />
                   </asp:BoundField>
                   <asp:TemplateField>
                       <ItemStyle HorizontalAlign="Center" />
                       <ItemTemplate>
                           <asp:ImageButton ID="imgdelete" runat="server"
                               ImageUrl="~/images/delete.jpg" OnClick="imgdelete_Click" Height="16px" OnClientClick="getConfirmationValue()" />
                           <%-- <cc1:ConfirmButtonExtender ID="confirmBtExt" runat="server" TargetControlID="imgdelete" 
                       ConfirmText="Are you sure about deleting this record?" />--%>
                       </ItemTemplate>

                   </asp:TemplateField>
               </Columns>

               <EmptyDataRowStyle CssClass="EmptyRowStyle" />
               <HeaderStyle CssClass="" />
               <AlternatingRowStyle CssClass="GrdAltRow" />
               <RowStyle CssClass="GrdRow" />
           </asp:GridView>
           <div class="div_Break"></div>
       </asp:Panel>
   </div>
  

   </div>

       </div>
   </div>
                           

                        </div>
                    </div>


                 


                    <div class="FormGroupContent4 boxmodal hide">

                        <div class="panel_05 MB0">
                            <asp:Panel ID="Panel3" runat="server" CssClass="Grid FixedHeader" ScrollBars="Vertical">
                                <asp:GridView ID="Grid_shipperinvoice" runat="server" CssClass="FixedHeader" ShowHeaderWhenEmpty="true" Width="100%" AutoGenerateColumns="False" OnRowCommand="Grid_shipperinvoice_RowCommand" OnRowDataBound="Grid_shipperinvoice_RowDataBound1" OnRowDeleted="Grid_shipperinvoice_RowDeleted">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Shipper">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_shipperinvoice" runat="server" Text='<%#Bind("Shipperinvoice") %>' Visible="true" CssClass="grdchargefield1"></asp:TextBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Button ID="btnyes" runat="server" Text="+" OnClick="btnyes_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <ItemTemplate>
                                                <asp:Button ID="btndelete" CommandName="Delete" runat="server" Text="-" CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" Wrap="false" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Wrap="false" />

                                </asp:GridView>

                            </asp:Panel>
                        </div>

                    </div>








                  
                    <div class="FormGroupContent4">
                        <%-- POPUP --%>

                        <asp:Panel ID="pnl_Buying" runat="server" CssClass="modalPopup" Style="display: none;">
                            <div class="divRoated">

                                <div class="DivSecPanel">
                                    <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>
                                <asp:Panel ID="pnl_grd1" runat="server" CssClass="Gridpnl">

                                    <asp:GridView ID="grd_book" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="false" PageSize="19"
                                        HorizontalAlign="Left" CssClass="Grid FixedHeader" OnRowDataBound="grd_book_RowDataBound" BackColor="White" ForeColor="Black"
                                        OnSelectedIndexChanged="grd_book_SelectedIndexChanged" OnPageIndexChanging="grd_book_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundField>
                                            <%--  <asp:BoundField DataField="Airline" HeaderText="Airline" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Airline" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label ID="Airline" runat="server" Text='<%# Bind("Airline") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="mawblno" HeaderText="MAWBL #">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="flightdate" HeaderText="Flight Date" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Flight Date" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label ID="flightdate" runat="server" Text='<%# Bind("flightdate") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="agentname" HeaderText="Agent" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Status" HeaderText="status" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="fromport" HeaderText="From Port" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                              <asp:BoundField DataField="toport" HeaderText="To Port" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label ID="agentname" runat="server" Text='<%# Bind("agentname") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="status" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label ID="Status" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="From Port" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="fromport" runat="server" Text='<%# Bind("fromport") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To Port" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="toport" runat="server" Text='<%# Bind("toport") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
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
                                <div class="div_break"></div>
                            </div>

                        </asp:Panel>
                        <asp:ModalPopupExtender ID="Grd_book_popup" runat="server" PopupControlID="pnl_Buying"
                            TargetControlID="hidlabel1" CancelControlID="Close_voucher" DropShadow="false"  BehaviorID="programmaticModalPopupBehavior2" >
                        </asp:ModalPopupExtender>

                    </div>
                    <div class="FormGroupContent4">
                        <%-- POPUP GRD --%>

                        <asp:Panel ID="Pnl_grd" runat="server" CssClass="modalPopup" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="close_grd" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                                    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%"
                                        HorizontalAlign="Left" CssClass="Grid FixedHeader" AllowPaging="false" PageSize="20" BackColor="White" ForeColor="Black"
                                        OnSelectedIndexChanged="grd_SelectedIndexChanged" OnRowDataBound="grd_RowDataBound" OnPageIndexChanging="grd_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                                <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="bookingdate" HeaderText="Date" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="customername" HeaderText="Customer" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pol" HeaderText="POL" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pod" HeaderText="POD" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="fstatus" HeaderText="Status" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="shipperid" HeaderText="Shipperid" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                              <asp:BoundField DataField="bookno" HeaderText="Bookno" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="salesid" HeaderText="Salesid" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Booking Date" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="bookingdate" runat="server" Text='<%# Bind("bookingdate") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Customer Name" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="POL" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
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
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="fstatus" runat="server" Text='<%# Bind("fstatus") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="shipperid" HeaderText="Shipperid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bookno" HeaderText="Book #" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="salesid" HeaderText="Sales ID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="50px" />
                                            </asp:BoundField>
                                            <%--  <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
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

                                <div class="div_break"></div>
                            </div>
                        </asp:Panel>
                        <asp:ModalPopupExtender ID="grd_view_popup" runat="server" PopupControlID="Pnl_grd"
                            TargetControlID="hidlabel2" CancelControlID="close_grd" DropShadow="false">
                        </asp:ModalPopupExtender>
                    </div>

                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>HAWBL # :</label>

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
            <%--</div>
            </d--%>iv>
        
    

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>
    <asp:Label ID="hidlabel1" runat="server" />
    <asp:Label ID="hidlabel2" runat="server" />
    <asp:HiddenField ID="hf_hidid1" runat="server" />
    <asp:HiddenField ID="hf_hidid2" runat="server" />
    <asp:HiddenField ID="hf_salesPID" runat="server" />
    <asp:HiddenField ID="hf_jobno" runat="server" />
    <asp:HiddenField ID="hf_hawblno" runat="server" />
    <asp:HiddenField ID="hf_intissuedid" runat="server" />
    <asp:HiddenField ID="hf_intshipperid" runat="server" />
    <asp:HiddenField ID="hf_intconsid" runat="server" />
    <asp:HiddenField ID="hf_intchaid" runat="server" />
    <asp:HiddenField ID="hf_intfromid" runat="server" />

    <asp:HiddenField ID="hf_inttoid" runat="server" />
    <asp:HiddenField ID="hf_intbyid1" runat="server" />
    <asp:HiddenField ID="hf_inttoid1" runat="server" />
    <asp:HiddenField ID="hf_intbyid2" runat="server" />
    <asp:HiddenField ID="hf_inttoid2" runat="server" />
    <asp:HiddenField ID="hf_intbyid3" runat="server" />

    <asp:HiddenField ID="hf_inttoid3" runat="server" />
    <asp:HiddenField ID="hf_IntCOMMODITY" runat="server" />
    <asp:HiddenField ID="hf_bookingno" runat="server" />
    <asp:HiddenField ID="hf_custid" runat="server" />
    <asp:HiddenField ID="hf_porid" runat="server" />
    <asp:HiddenField ID="hf_curid" runat="server" />
    <asp:HiddenField ID="hf_cargoid" runat="server" />
    <asp:HiddenField ID="hf_intnotifyid1" runat="server" />
    <asp:HiddenField ID="hf_intnotifyid2" runat="server" />
    <asp:HiddenField ID="hid_reuse" runat="server" />
    <asp:HiddenField ID="hid_quto" runat="server" />
    <asp:HiddenField ID="hid_intcustomerid" runat="server" />
    <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hid_intagent" runat="server" />
    <asp:HiddenField ID="HIDMAWBLNO" runat="server" />
    <asp:HiddenField ID="hid_douvolume" runat="server" />
    <asp:HiddenField ID="hid_fd" runat="server" />

    <asp:HiddenField ID="hid_buyingno" runat="server" />
    <asp:HiddenField ID="hid_total1" runat="server" />
    
    <asp:HiddenField ID="hid_intcustomerid1" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />

</asp:Content>
