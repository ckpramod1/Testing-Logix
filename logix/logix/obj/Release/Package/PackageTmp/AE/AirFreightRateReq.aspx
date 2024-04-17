<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AirFreightRateReq.aspx.cs" Inherits="logix.AE.AirFreightRateReq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

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
    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });

            $(document).ready(function () {
                $("#<%=txtInco.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_Incoid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AirFreightRateReq.aspx/GetLikeIncocode",
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
                    <%--select: function (event, i) {
                         $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=txtInco.ClientID %>").change();
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);


                    },
                     focus: function (event, i) {
                         $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);

                    },
                     close: function (event, i) {
                         $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);

                    },--%>
                    select: function (event, i) {
                        $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=txtInco.ClientID %>").change();
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtInco.ClientID %>").val(i.item.label);
                        $("#<%=hdn_Incoid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {

                $("#<%=txt_Orgin_Airport.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_intfromid.ClientID %>").val(0);

                        $.ajax({
                            url: "../AE/AirFreightRateReq.aspx/Getportname",

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
                          $("#<%=txt_Orgin_Airport.ClientID %>").change();
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                     change: function (e, i) {
                         $("#<%=txt_Orgin_Airport.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_Orgin_Airport.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=txt_Orgin_Airport.ClientID %>").val(i.item.label);
                    },--%>

                    select: function (event, i) {
                        $("#<%=txt_Orgin_Airport.ClientID %>").val(i.item.label);
                        $("#<%=txt_Orgin_Airport.ClientID %>").change();
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Orgin_Airport.ClientID %>").val(i.item.label);
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_Orgin_Airport.ClientID %>").val(i.item.label);
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_Orgin_Airport.ClientID %>").val(i.item.label);
                        $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {

                $("#<%=txt_Destination_Airport.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_inttoid.ClientID %>").val(0);

                            $.ajax({
                                url: "../AE/AirFreightRateReq.aspx/Getponame",

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

                        <%--  select: function (e, i) {
                          $("#<%=txt_Destination_Airport.ClientID %>").change();
                            $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                        },
                     change: function (e, i) {
                         $("#<%=txt_Destination_Airport.ClientID %>").val(i.item.label);
                        },
                        focus: function (e, i) {
                            $("#<%=txt_Destination_Airport.ClientID %>").val(i.item.label);
                        },
                        close: function (e, i) {
                            $("#<%=txt_Destination_Airport.ClientID %>").val(i.item.label);
                        },--%>
                    select: function (event, i) {
                        $("#<%=txt_Destination_Airport.ClientID %>").val(i.item.label);
                            $("#<%=txt_Destination_Airport.ClientID %>").change();
                            $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                        },
                    focus: function (event, i) {
                        $("#<%=txt_Destination_Airport.ClientID %>").val(i.item.label);
                            $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                        },
                    change: function (event, i) {
                        $("#<%=txt_Destination_Airport.ClientID %>").val(i.item.label);
                            $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                        },
                    close: function (event, i) {
                        $("#<%=txt_Destination_Airport.ClientID %>").val(i.item.label);
                            $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                        },
                    minLength: 1
                });
            });

                $(document).ready(function () {

                    $("#<%=txt_Commodity.ClientID %>").autocomplete({

                        source: function (request, response) {

                            $("#<%=hf_IntCOMMODITY.ClientID %>").val(0);
                                $.ajax({
                                    url: "../AE/AirFreightRateReq.aspx/Getcargo",
                                    //data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_cargo').value + "'}",
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

                            <%--  select: function (e, i) {
                          $("#<%=txt_Commodity.ClientID %>").change();
                            $("#<%=hf_IntCOMMODITY.ClientID %>").val(i.item.val);
                        },
                     change: function (e, i) {
                         $("#<%=txt_Commodity.ClientID %>").val(i.item.label);
                        },
                        focus: function (e, i) {
                            $("#<%=txt_Commodity.ClientID %>").val(i.item.label);
                        },
                        close: function (e, i) {
                            $("#<%=txt_Commodity.ClientID %>").val(i.item.label);
                        },--%>

                        select: function (event, i) {
                            $("#<%=txt_Commodity.ClientID %>").val(i.item.label);
                                $("#<%=txt_Commodity.ClientID %>").change();
                                $("#<%=hf_IntCOMMODITY.ClientID %>").val(i.item.val);
                            },
                        focus: function (event, i) {
                            $("#<%=txt_Commodity.ClientID %>").val(i.item.label);
                                $("#<%=hf_IntCOMMODITY.ClientID %>").val(i.item.val);
                            },
                        change: function (event, i) {
                            $("#<%=txt_Commodity.ClientID %>").val(i.item.label);
                                $("#<%=hf_IntCOMMODITY.ClientID %>").val(i.item.val);
                            },
                        close: function (event, i) {
                            $("#<%=txt_Commodity.ClientID %>").val(i.item.label);
                                $("#<%=hf_IntCOMMODITY.ClientID %>").val(i.item.val);
                            },
                        minLength: 1
                    });
                });


                    $(document).ready(function () {

                        $("#<%=txt_cmailid.ClientID %>").autocomplete({
                            source: function (request, response) {
                                $("#<%=hf_cmailid.ClientID %>").val(0);

                        $.ajax({
                            url: "../AE/AirFreightRateReq.aspx/CMailID",
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
                    select: function (e, i) {
                        $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                          $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                          $("#<%=txt_cmailid.ClientID %>").change();
                      },
                            change: function (e, i) {
                                $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                    },
                            focus: function (e, i) {
                                $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                    },
                            close: function (e, i) {
                                $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                    },


                            minLength: 1
                        });
                    });
        }


    </script>

    <style type="text/css">
        .Incoterms {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OrginAirport {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DestinationAirport {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Commodity {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .FormGroupContent4 textarea {
    height: 70px !important;
}
        .NoofPackages {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GrWt {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Dimensions {
            width: 6.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VolWt {
            width: 6.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Stackable {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .NonDG {
            width: 5.4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TempControl {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipperAddress {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .ConsigneeAddress {
            width: 100%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        #logix_CPH_ddl_Stackornonstack_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddl_DGNonDG_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddl_normalTempControl_chzn {
            width: 100% !important;
        }

        .CUSMailID1 {
            float: left;
            width: 91.9%;
            margin: 0px 0.5% 0px 0px;
        }

        .IssuedDate {
            width: 8.1%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .AddbuttonNew1 {
            float: left;
            margin-left: 0%;
        }

        .CustomerMailID {
            float: left;
            width: 100%;
            margin: 0px 0% 0px 0%;
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

        .AddbuttonNew1 {
            float: left;
            margin-left: 0%;
            margin-top: 19px;
        }
 
.leftside {
    width: 50%;
    margin-right:0.5%;
}
.rightside {
    width: 49.5%;
}
.div_Grid {
    width: 100%;
    margin-left: 0%;
    margin-bottom: 1%;
    margin-top: 0.1%;
    height: 132px;
    Border: 1px solid #b1b1b1;
    float: left;
    overflow: auto;
}

/*.btn.btn-add1 {
    width: 3%;
}
.btn.ico-add.custom-mt-3 {
    width: 3%;
}*/
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 55px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    
    <div class="col-md-12">

        <div class="widget box" runat="server" id="div_iframe">

            <div class="widget-header">
                <h4 class="hide"><i class="icon-umbrella"></i>
                    <asp:Label ID="Label1" runat="server" Text="Air Freight Rate Request"></asp:Label></h4>
                <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#"></a>Ops & Docs</li>
            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>
            <li class="current"><a href="#" title="">Air Freight Rate Request</a> </li>
        </ul>
    </div>

                <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                    <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                </div>

            </div>
            <div class="widget-content">
                <div class="FormGroupContent4 FixedButtons">
                     <div class="right_btn">
                                <div class="btn ico-save">
                                    <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" TabIndex="17" OnClick="btn_save_Click" />
                                </div>


                                <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                    <asp:Button ID="Btn_cancel" runat="server" Text="Cancel" TabIndex="18" ToolTip="Cancel" OnClick="Btn_cancel_Click" />
                                </div>
                            </div>
                </div>
                <div class="JobLeftN1new">
                    <div class="FormGroupContent4 boxmodal">

                        <div class="Incoterms">
                            <asp:Label ID="Label2" runat="server" Text="INCO Terms"> </asp:Label>
                            <asp:TextBox ID="txtInco" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="" ToolTip="INCO Terms" TabIndex="1" OnTextChanged="txtInco_TextChanged"></asp:TextBox>
                        </div>
                        <div class="OrginAirport">
                            <asp:Label ID="Label3" runat="server" Text="Orgin Airport"> </asp:Label>
                            <asp:TextBox ID="txt_Orgin_Airport" runat="server" CssClass="form-control" placeholder="" ToolTip="Orgin Airport" TabIndex="2" OnTextChanged="txt_Orgin_Airport_TextChanged"></asp:TextBox>
                        </div>
                        <div class="DestinationAirport">
                            <asp:Label ID="Label4" runat="server" Text="Destination Airport"> </asp:Label>
                            <asp:TextBox ID="txt_Destination_Airport" runat="server" TabIndex="3" AutoPostBack="true" placeholder="" ToolTip="Destination Airport" CssClass="form-control" OnTextChanged="txt_Destination_Airport_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Commodity">
                            <asp:Label ID="Label5" runat="server" Text="Commodity"> </asp:Label>
                            <asp:TextBox ID="txt_Commodity" runat="server" placeholder="" AutoPostBack="true" TabIndex="4" ToolTip="Commodity" CssClass="form-control" OnTextChanged="txt_Commodity_TextChanged"></asp:TextBox>
                        </div>
                    
                    
                        <div class="NoofPackages">
                            <asp:Label ID="Label6" runat="server" Text="No of Packages"> </asp:Label>
                            <asp:TextBox ID="txt_noofpgs" runat="server" placeholder="" TabIndex="5" ToolTip="No of Packages" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="GrWt">
                            <asp:Label ID="Label7" runat="server" Text="Gr.Wt"> </asp:Label>
                            <asp:TextBox ID="txt_GrWt" runat="server" placeholder="" TabIndex="6" ToolTip="Gr.Wt" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="Dimensions">
                            <asp:Label ID="Label8" runat="server" Text="Dimensions"> </asp:Label>
                            <asp:TextBox ID="txt_Dimensions" runat="server" placeholder="" TabIndex="7" ToolTip="Dimensions" CssClass="form-control date"></asp:TextBox>
                        </div>
                        <div class="VolWt">
                            <asp:Label ID="Label9" runat="server" Text="Vol.Wt"> </asp:Label>
                            <asp:TextBox ID="txt_VolWt" runat="server" placeholder="" TabIndex="8" ToolTip="Vol.Wt" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="Stackable">
                            <asp:Label ID="Label10" runat="server" Text="Stackable"> </asp:Label>
                            <asp:DropDownList ID="ddl_Stackornonstack" runat="server" CssClass="chzn-select" data-placeholder="Yes/No " ToolTip="Stackable " TabIndex="9">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="NonDG">
                            <asp:Label ID="Label11" runat="server" Text="DG "> </asp:Label>
                            <asp:DropDownList ID="ddl_DGNonDG" runat="server" CssClass="chzn-select" data-placeholder="DG " ToolTip="DG " TabIndex="10">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <div class="TempControl">
                            <asp:Label ID="Label12" runat="server" Text="Normal / Temp Control"> </asp:Label>
                            <asp:DropDownList ID="ddl_normalTempControl" runat="server" CssClass="chzn-select" data-placeholder="Yes / No" ToolTip="Yes / No " TabIndex="11">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="IssuedDate DateR">
                            <asp:Label ID="Label13" runat="server" Text="Required Time"> </asp:Label>
                            <asp:TextBox ID="txt_RatrequiredbyTime" runat="server" Enabled="true" TabIndex="12" placeholder="" ToolTip="Rate required by / Time" CssClass="form-control date"></asp:TextBox>
                            <asp:CalendarExtender ID="txtdatecalExd" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_RatrequiredbyTime"></asp:CalendarExtender>
                        </div>
                        </div>
                 
                    <div class="FormGroupContent4">
                       <div class="box"  style="display:flex">
                            <div class="leftside">
                            <div class="ShipperAddress boxmodal">
                    <div class="FormGroupContent4">

                            <asp:Label ID="Label14" runat="server" Text="Shipper Address"> </asp:Label>
                            <asp:TextBox ID="txt_ShipperAddress" runat="server" Rows="3" CssClass="form-control" TabIndex="13" TextMode="MultiLine" placeholder="" ToolTip="Shipper Address"></asp:TextBox>
                        </div>
                        </div>
                         <div class="ConsigneeAddress boxmodal">
                    <div class="FormGroupContent4">

                            <asp:Label ID="Label16" runat="server" Text="Consignee Address"> </asp:Label>
                            <asp:TextBox ID="txt_ConsigneeAddress" runat="server" Rows="3" CssClass="form-control" TabIndex="14" TextMode="MultiLine" placeholder="" ToolTip="Consignee Address"></asp:TextBox>
                        </div>
                        </div>

                        </div>
                        <div class="rightside boxmodal">
                              <div class="CUSMailID1">
                            <asp:Label ID="Label15" runat="server" Text="Mail-ID's"> </asp:Label>
                            <asp:TextBox ID="txt_cmailid" runat="server" AutoPostBack="true" CssClass="form-control" TabIndex="15" placeholder="" ToolTip="Mail-ID's"></asp:TextBox>

                        </div>
                        
                            
                                  <div class="btn ico-add custom-mt-2">
                            <asp:Button ID="btn_plus" runat="server" Text="Add" ToolTip="Add" CssClass="Button" OnClick="btn_plus_Click" TabIndex="16" />
                        </div>

                        <div class="CustomerMailID">
                            <%-- <asp:Panel ID="pnl_cmail" runat="server" Height="100px" ScrollBars="Vertical">--%>
                            <asp:Panel ID="pnl_cmail" runat="server"  CssClass="panel_03 MB0">
                                <asp:GridView ID="grd_cmail" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_cmail_RowDataBound" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Width="100%" CssClass="Grid FixedHeader" BorderColor="#999997" OnPreRender="grd_cmail_PreRender">
                                    <Columns>

                                        <asp:BoundField DataField="mailid" HeaderText="Customer's Mail-ID" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg"  Height="16px" OnClick="ImageButton2_Click" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />

                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                       </div>
                        </div>
                     
                       
                    

                    <div class="FormGroupContent4">

                        

                    </div>
                </div>
            </div>
        </div>
        </div>

        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="lbl_no" runat="server">AirFreightRateReq</label>

                    </div>
                    <div class="LogHeadJobInput">

                        <asp:Label ID="JobInput" runat="server"></asp:Label>

                    </div>

                </div>
                <div class="DivSecPanel">
                    <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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

        <asp:Label ID="lbllog1" runat="server"></asp:Label>

        <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
            DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
        </asp:ModalPopupExtender>

        <asp:HiddenField ID="hdn_Incoid" runat="server" />
        <asp:HiddenField ID="hf_intfromid" runat="server" />
        <asp:HiddenField ID="hf_inttoid" runat="server" />
        <asp:HiddenField ID="hf_IntCOMMODITY" runat="server" />
        <asp:HiddenField ID="hf_cmailid" runat="server" />
        <asp:HiddenField ID="hf_cmailname" runat="server" />
</asp:Content>
