<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="FIBookingBL.aspx.cs" EnableEventValidation="false" Inherits="logix.FI.FIBookingBL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
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
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>



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






    <link href="../Styles/FIBookingBL.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .div_confirm {
            /*Border:1px solid red;*/
            width: 100%;
            float: left;
            margin-left: 30%;
            margin-top: 0%;
        }

        .Pnl1 {
            background-color: #E0E0E0;
            border-color: #5D7B9D;
            border-style: solid;
            border-width: 1px;
            width: 250px;
            height: 100px;
            margin-right: 1%;
        }

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


        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        
        .remark{
            width:43.4%;
            float:left;

        }
        .StatusDrop {
    width: 14.9%;
    float: left;
    margin: 0px 0px 0px 0px;
}
   
        .BLno4 {
    width: 6.5%;
    margin: 0px 0.5% 0px 0px;
    float: left;
}
        .Consignee {
    width: 36.3%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>

    <%--EDIT--%>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>

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

        #logix_CPH_pnl_booking1 {
            left: 19px !important;
            top: 72px !important;
        }

        #logix_CPH_pnl_msg1 {
            top: 220px !important;
        }

      

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
            width: 97.8%;
            height: 525px;
            margin-left: 1%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
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

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

       

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .BookingInput7 {
            float: left;
            width: 10.5%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }
        .BKGDate {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .QuoteDate {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .QuotInput {
            width: 10.7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .VoyageInput7 {
    width: 6.8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .PolInput9 {
    width: 14%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .ConsigneeCal {
    width: 7.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .VesselInput8 {
    width: 13.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

.CBMInput3 {
    width: 6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.NetInput {
    width: 10.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.GrossInput2 {
    width: 10.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.GrossInput2 {
    width: 10.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PodInput7 {
    width: 21%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.FDInput2 {
    width: 22%;
    float: left;
    margin: 0px;
}
/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
   
    </style>

    <%--EDIT--%>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_vessel.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_vessel.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/FIBookingBL.aspx/Get_Vessel",
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

                    select: function (e, i) {
                        $("#<%=hf_vessel.ClientID %>").val(i.item.val);
                        $("#<%=hf_vessel.ClientID %>").change();
                        $("#<%=hf_vesselname.ClientID %>").val(i.item.label);
                        $("#<%=hf_vesselname.ClientID %>").change();

                    },
                    change: function (e, i) {
                        $("#<%=hf_vessel.ClientID %>").val(i.item.val);
                        $("#<%=hf_vesselname.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=hf_vessel.ClientID %>").val(i.item.val);
                        $("#<%=hf_vesselname.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=hf_vessel.ClientID %>").val(i.item.val);
                        $("#<%=hf_vesselname.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });




            $(document).ready(function () {
                $("#<%=txt_con.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_conid.ClientID %>").val(0);
                    $.ajax({
                        url: "../FI/FIBookingBL.aspx/Get_Consignee",
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
                    $("#<%=txt_con.ClientID %>").val(i.item.label);
                    $("#<%=txt_con.ClientID %>").change();
                    $("#<%=hf_conid.ClientID %>").val(i.item.val);
                },

                    focus: function (event, i) {
                        $("#<%=txt_con.ClientID %>").val(i.item.label);
                    $("#<%=hf_conid.ClientID %>").val(i.item.val);
                },
                <%-- close: function (event, i) {
                    $("#<%=txt_con.ClientID %>").val(i.item.label);
                    $("#<%=hf_conid.ClientID %>").val(i.item.val);
                },--%>
                    close: function (event, i) {
                        var result = $("#<%=txt_con.ClientID %>").val().toString().split(',')[0];
                    $("#<%=txt_con.ClientID %>").val($.trim(result));
                },
                    minLength: 1
                });
            });

        $(document).ready(function () {

            $("#<%=txt_book.ClientID %>").autocomplete({

                source: function (request, response) {

                    $.ajax({
                        url: "../FI/FIBookingBL.aspx/GetBookingdetails",
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
                     $("#<%=txt_book.ClientID %>").change();

                     },
                     change: function (event, i) {
                         $("#<%=txt_book.ClientID %>").val(i.item.value);
                     },
                     focus: function (event, i) {
                         $("#<%=txt_book.ClientID %>").val(i.item.value);
                     },
                     close: function (event, i) {
                         $("#<%=txt_book.ClientID %>").val(i.item.value);
                     },--%>

                select: function (event, i) {
                    $("#<%=txt_book.ClientID %>").val(i.item.label);
                    $("#<%=txt_book.ClientID %>").change();
                    $("#<%=txt_book.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txt_book.ClientID %>").val(i.item.label);
                    $("#<%=txt_book.ClientID %>").val(i.item.val);
                },
                change: function (event, i) {
                    $("#<%=txt_book.ClientID %>").val(i.item.label);
                    $("#<%=txt_book.ClientID %>").val(i.item.val);

                },
                close: function (event, i) {
                    $("#<%=txt_book.ClientID %>").val(i.item.label);
                    $("#<%=txt_book.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        });



        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_header" runat="server" Text="Update Booking Status"></asp:Label></h4>
                         <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Customer Support</a> </li>
            <li><a href="#" title="">Ocean Imports</a> </li>
            <li class="current"><a href="#" title="">UPDate Booking Status</a> </li>
        </ul>
    </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class= "FixedButtons" >
       <div class="right_btn">
        <div class="btn ico-reverse-booking">
            <asp:Button ID="btn_rbook" runat="server" Text="Reverse Booking" ToolTip="Reverse Booking" OnClick="btn_rbook_Click" />
        </div>
        <div class="btn ico-save" id="btn_save1" runat="server">
            <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
        </div>
    </div>
</div>
                </div>
                <div class="widget-content">
 

                    

                    <div class="FormGroupContent4">

                        <div class="BookingInput7">
                            <span>Booking #</span>                           

                            <asp:TextBox ID="txt_book" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_book_TextChanged" placeholder="" ToolTip="Booking Number"></asp:TextBox>
                        </div>
                    <asp:LinkButton ID="lnk_book" runat="server" ForeColor="Red" Style="text-decoration: none;" OnClick="lnk_book_Click" CssClass="anc ico-find-sm"></asp:LinkButton>

                        <div class="BKGDate">
                            <asp:Label ID="Label5" runat="server" Text="Date"> </asp:Label>
                            <asp:TextBox ID="txt_bdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Booking Date" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="QuotInput">
                            <asp:Label ID="Label6" runat="server" Text="Quot #"> </asp:Label>
                            <asp:TextBox ID="txt_quot" runat="server" CssClass="form-control" placeholder="" ToolTip="Quotation Number" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="QuoteDate DateR">
                            <asp:Label ID="Label7" runat="server" Text="Quot Date"> </asp:Label>
                            <asp:TextBox ID="txt_qdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Quotation Date" Enabled="false"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div class="FormGroupContent4">
                               <div class="BLno4">
                            <asp:Label ID="Label8" runat="server" Text="BL #"> </asp:Label>
                            <asp:TextBox ID="txt_bl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_bl_TextChanged" placeholder="" ToolTip="Bill of Lading Number"></asp:TextBox>
                        </div>

                        <div class="Consignee">
                            <asp:Label ID="Label11" runat="server" Text="Consignee"> </asp:Label>
                            <asp:TextBox ID="txt_con" runat="server" CssClass="form-control" placeholder="" ToolTip="Consignee" AutoPostBack="true" OnTextChanged="txt_con_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                        <div class="FormGroupContent4">
                            <div class="VesselInput8">
                            <asp:Label ID="Label9" runat="server" Text="Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" placeholder="" ToolTip="Vessel" AutoPostBack="true" OnTextChanged="txt_vessel_TextChanged"></asp:TextBox>
                        </div>
                        <div class="VoyageInput7">
                            <asp:Label ID="Label10" runat="server" Text="Voyage"> </asp:Label>
                            <asp:TextBox ID="txt_voyage" runat="server" CssClass="form-control" placeholder="" ToolTip="Voyage"></asp:TextBox>
                        </div>
                              <div class="PolInput9">
                            <asp:Label ID="Label13" runat="server" Text="POL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" placeholder="" ToolTip="Port of Loading" Enabled="false"></asp:TextBox>
                        </div>
                             <div class="ConsigneeCal">
                            <asp:Label ID="Label12" runat="server" Text="ETD"> </asp:Label>
                            <asp:TextBox ID="txt_etd" runat="server" CssClass="form-control" placeholder="" ToolTip="Estimated Time of Departure"></asp:TextBox>
                            <asp:CalendarExtender ID="dtdateval" runat="server" TargetControlID="txt_etd" Format="dd/MM/yyyy" />
                        </div>
                            
                        </div>
                    <div class="FormGroupContent4">
                         <div class="PodInput7">
                            <asp:Label ID="Label14" runat="server" Text="POD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" placeholder="" ToolTip="Port of Destination" Enabled="false"></asp:TextBox>
                        </div>
                              <div class="FDInput2">
                            <asp:Label ID="Label15" runat="server" Text="Place of Delivery"> </asp:Label>
                            <asp:TextBox ID="txt_fd" runat="server" CssClass="form-control" placeholder="" ToolTip="Place of Delivery" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                   
                        
                    <div class="FormGroupContent4 boxmodal">

                    <div class="FormGroupContent4">
                        
                       
                      
                       
                      
                    </div>
                    <div class="FormGroupContent4">
                        <div class="CBMInput3">
                            <asp:Label ID="Label16" runat="server" Text="CBM"> </asp:Label>
                            <asp:TextBox ID="txt_cbm" runat="server" CssClass="form-control" placeholder="" ToolTip="Cubic Meter"></asp:TextBox>
                        </div>
                        <div class="NetInput">
                            <asp:Label ID="Label17" runat="server" Text="Net.Wt"> </asp:Label>
                            <asp:TextBox ID="txt_netwt" runat="server" CssClass="form-control" placeholder="" ToolTip="Net Weight"></asp:TextBox>
                        </div>
                        <div class="GrossInput2">
                            <asp:Label ID="Label18" runat="server" Text="Gross.Wt"> </asp:Label>
                            <asp:TextBox ID="txt_grosswt" runat="server" CssClass="form-control" placeholder="" ToolTip="Gross Weight" OnTextChanged="txt_grosswt_TextChanged"></asp:TextBox>
                        </div>
                        <div class="StatusDrop">
                            <asp:Label ID="Label19" runat="server" Text="Status"> </asp:Label>
                            <asp:DropDownList ID="ddl_blstatus" runat="server" OnSelectedIndexChanged="ddl_blstatus_SelectedIndexChanged" CssClass="chzn-select" data-placeholder="Status" ToolTip="Bill of Loading Status">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem>Surrendered</asp:ListItem>
                                <asp:ListItem>Release</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                        </div>
                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <div class="remark">
                        <asp:Label ID="Label20" runat="server" Text="Remarks"> </asp:Label>
                        <asp:TextBox ID="txt_remarks" runat="server" CssClass="form-control" PLACEHOLDER="" ToolTip="Remarks" OnTextChanged="txt_remarks_TextChanged"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                    
                    <div class="FormGroupContent4">

                        <%-- PopUP --%>
                        <asp:Panel ID="pnl_booking" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                            <div class="DivSecPanel">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel2" runat="server"  CssClass="Gridpnl">
                                <%--<asp:Panel ID="pnl_booking" runat="server" Width="100%" CssClass="div_frame" Style="display:none;">
        <div class="div_close"><asp:Image ID="img_grd_book" runat="server" ImageAlign="Baseline" width="100%" Height="100%" ImageUrl="~/images/close2.png"/></div>
        <div class="div_Break"></div>
        
        <div class="div_Grd">--%>
                                <asp:GridView ID="grd_book" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                    BackColor="White" DataKeyNames="bookno" OnRowCommand="grd_book_RowCommand" AllowPaging="false" OnPageIndexChanging="grd_book_PageIndexChanging"
                                    OnRowDataBound="grd_book_RowDataBound" OnSelectedIndexChanged="grd_book_SelectedIndexChanged">
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
                                            <HeaderStyle Wrap="true" Width="89px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                                    <asp:Label ID="Customer" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="250px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="POL">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                                    <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="POD">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                    <asp:Label ID="POD" runat="server" Text='<%# Bind("POD") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Book">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                    <asp:Label ID="Book" runat="server" Text='<%# Bind("bookno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="true" Width="66px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="Select">
                  <ItemTemplate>
                     <asp:LinkButton ID="lnk_grdbook" runat="server" CssClass="Arrow" CommandName="select" Font-Underline="false">⇛</asp:LinkButton>
                  </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
              </asp:TemplateField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>
                            </asp:Panel>
                            <div class="div_Break"></div>
                             </div>
                        </asp:Panel>

                    </div>


                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_booking1" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel3" runat="server"  ScrollBars="Vertical" CssClass="Gridpnl">

                                    <%--<asp:Panel ID="pnl_booking1" runat="server" Width="100%" CssClass="div_frame" Style="display:none;">
        <div class="div_close"><asp:Image ID="img_grd_book1" runat="server" ImageAlign="Baseline" width="100%" Height="100%" ImageUrl="~/images/close2.png"/></div>
        <div class="div_Break"></div>
        
        <div class="div_Grd">--%>
                                    <asp:GridView ID="grd_rev" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="False" Width="100%" ForeColor="Black" PageSize="15" BackColor="White" DataKeyNames="bookno"
                                        OnRowCommand="grd_rev_RowCommand" OnRowDataBound="grd_rev_RowDataBound" AllowPaging="false" OnPageIndexChanging="grd_rev_PageIndexChanging"
                                        OnSelectedIndexChanged="grd_rev_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="bookingno" HeaderText="Booking#" />
                                            <asp:BoundField DataField="blno" HeaderText="BL #" />
                                            <asp:BoundField DataField="bookingdate" HeaderText="Date" />
                                            <asp:BoundField DataField="customername" HeaderText="Customer" />
                                            <asp:BoundField DataField="POL" HeaderText="POL" />
                                            <asp:BoundField DataField="POD" HeaderText="POD" />
                                            <asp:BoundField DataField="bookno" HeaderText="Book#" />
                                            <%--<asp:TemplateField HeaderText="Select">
                  <ItemTemplate>
                     <asp:LinkButton ID="lnk_grdrev" runat="server" CssClass="Arrow" CommandName="select" Font-Underline="false">⇛</asp:LinkButton>
                  </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
              </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                </asp:Panel>
                                <div class="div_Break"></div>
                            </div>
                        </asp:Panel>
                    </div>


                    <div class="FormGroupContent4">
                        <div>
                            <asp:Panel runat="Server" ID="pnl_msg1" CssClass="Pnl1" Style="display: none;">

                                <div class="">

                                    <table class="OuterTable" style="border: 2px; margin-top: 30px;" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_msg1" runat="server" Text="Do u want to delete the BL from Booking?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <caption></caption>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <caption></caption>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btn_yes1" runat="server" CssClass="btn" Text="Yes" Width="32%"
                                                    OnClick="btn_yes1_Click" />
                                                <asp:Button ID="btn_no1" runat="server" CssClass="btn" Text="No" Width="32%" OnClick="btn_no1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <div class="div_Break"></div>
                            </asp:Panel>

                        </div>

                    </div>


                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Booking # :</label>

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
                </div>
            </div>
        </div>
    </div>



    <div>
        <asp:ModalPopupExtender ID="Mdl_book" runat="server" DropShadow="false" CancelControlID="Image2"
            PopupControlID="pnl_booking" TargetControlID="Label1">
        </asp:ModalPopupExtender>

    </div>

    <div>
        <asp:ModalPopupExtender ID="Mdl_Rev" runat="server" BackgroundCssClass="modalBackground" CancelControlID="imgfgok"
            PopupControlID="pnl_booking1" TargetControlID="Label2">
        </asp:ModalPopupExtender>

    </div>

    <div>
        <asp:ModalPopupExtender ID="Mdl_Msg" runat="server" BackgroundCssClass="modalBackground" CancelControlID="Image1"
            PopupControlID="pnl_msg1" TargetControlID="Label3">
        </asp:ModalPopupExtender>

    </div>

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <div class="div_Break"></div>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:Label ID="Label3" runat="server"></asp:Label>
    <asp:HiddenField ID="hf_book" runat="server" />
    <asp:HiddenField ID="hf_bookno" runat="server" />
    <asp:HiddenField ID="hf_book1" runat="server" />
    <asp:HiddenField ID="hf_bookno1" runat="server" />
    <asp:HiddenField ID="hf_msg1" runat="server" />
    <asp:HiddenField ID="hf_vessel" runat="server" />
    <asp:HiddenField ID="hf_conid" runat="server" />
    <asp:HiddenField ID="hf_conname" runat="server" />
    <asp:HiddenField ID="hf_vesselname" runat="server" />

</asp:Content>
