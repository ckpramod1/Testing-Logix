<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Booking.aspx.cs" Inherits="logix.Sales.Booking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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

    <%--<script src="../Theme/assets/product/js/jquery.js"></script>
    <script src="../Theme/assets/product/js/jquery_002.js"></script>--%>

    <link href="../Styles/Booking.css" rel="stylesheet" />
    <script src="../Scripts/x.js" type="text/javascript"></script>
    <script src="../Scripts/xtableheaderfixed.js" type="text/javascript"></script>
    <script src="../Scripts/ScrollableGridPlugin.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
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
            margin-top: -0.85%;
            border-radius: 90px 90px 90px 90px;
        }


        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.17%;
            margin-top: -1.7%;
            position: absolute;
            width: 1026px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .hide {
            display: none;
        }

        .VoyageInputN4 .chzn-drop {
            top: -150px !important;
        }

        .BookingRight {
            float: left;
            width: 25.5%;
            margin: 0px 0px 0px 5px;
            /* padding: 2px; */
            /* border-left: 1px dotted; */
        }

        .BoolkingLeft {
            float: left;
            width: 74%;
            margin: 0px 0px 0px 0px;
        }

        .BookingRight {
            float: left;
            width: 25.5%;
            margin: 0px 0px 0px 5px;
            /* padding: 2px; */
            /* border-left: 1px dotted; */
        }

        .lbtnSop1 {
            width: 6%;
            float: right;
            text-align: left;
            margin: 10px -26px 0px 196px;
        }

            .lbtnSop1 a {
                font-size: 11px;
                margin: 5px 0px 0px 0px;
                display: inline-block;
                color: var(--blue);
            }

        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #programmaticModalPopupBehavior2_foregroundElement {
            left: 0px !important;
            top: 50px !important;
            height: 580px !important;
            position: absolute !important;
            z-index: 99999999 !important;
        }

        #programmaticModalPopupBehavior3_foregroundElement {
            left: 0px !important;
            top: 50px !important;
            height: 580px !important;
            position: absolute !important;
            z-index: 99999999 !important;
        }

        #logix_CPH_Panel4 {
            padding-right: 10px !important;
        }

        #logix_CPH_pnlJobAE {
            top: 51px !important;
        }

        #logix_CPH_popupsecond {
            top: 41px !important;
            left: -9px !important;
        }

        #logix_CPH_pnlcncl {
            top: 51px !important;
        }

        #table-container {
            position: relative;
            width: 100%;
            height: 300px;
            overflow: auto;
            padding: 0 0.1% 0 0;
            margin-top: 0%;
            /*margin-bottom:1%;
              /*----------------
              font-family:sans-serif;
              /*margin-left:0.3%;*/
        }

        table.gvTheGrid td,
        table.gvTheGrid th {
            padding: 3px 7px;
        }

        #logix_CPH_Panel1 {
            height: 112px;
        }

        #logix_CPH_Panel2 {
            height: 112px;
        }

        .chzn-drop {
            height: 150px !important;
            overflow: auto !important;
        }

        .CalNew1 {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PodCal {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PolCal {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PolInput {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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

        .QuoteLeft {
            width: 49%;
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
            width: 80%;
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
            width: 80%;
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


        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;*/
            width: 1062px;
            width: 99.5%;
            height: 572px;
            margin-left: 1%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }

        .BuyRateDisable {
            float: left;
            width: 18%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BookingInput {
            float: left;
            width: 18%;
            margin:0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BookingCalendar {
            float: right;
            width: 7%;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BuyrateLabel {
            float: left;
            margin: 0.2% 0.3% 0px 0px;
            text-align: right;
            padding: 0px 0px 0px 0px;
            width: 4.8%;
            font-size: 11px;
            color: #000080;
        }

        textarea#logix_CPH_txt_shipermulti {
            height: 54px !important;
        }

        textarea#logix_CPH_txt_consigneemulti {
            height: 54px !important;
        }

        textarea#logix_CPH_txt_agent_multi {
            height: 54px !important;
        }

        input#logix_CPH_btn_shipmail, input#logix_CPH_btn_cons, input#logix_CPH_btn_othermail {
            margin: 18px 0px 0px 5px;
        }

        .FormBoxForm1 {
            width: 16%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FormMedium {
            float: left;
            width: 67.2%;
            margin: 0px 0px 0px 0px;
        }

        input#logix_CPH_btn_add {
            margin-left: 16px;
        }
        .POL_Box {
    width: 66%;
    float: left;
    display: flex;
    flex-wrap: wrap;
    padding-right: 5px;
}
        .Agent2 {
    width: 34%;
    float: left;
    margin: 0px 0px 0px 0px!important;
}
        .PORLeftN1 {
    width: 24.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Freight {
    width: 15.8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .PodADD {
    width: 0;
    margin: 15px 0px 0px 0px;
}
    </style>
    <style type="text/css">
        /* Popup CSS Styles Start */
        /*.popup {
    width:100%;
    height:100%;
    display:none;
    position:fixed;
    top:0px;
    left:0px;
    background:rgba(0,0,0,0.75);
    z-index:9999999;

}*/

        /* Inner */
        .popup-inner {
            max-width: 899px;
            width: 90%;
            padding: 20px;
            position: absolute;
            top: 47.5%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            box-shadow: 0px 2px 6px rgba(0,0,0,1);
            border-radius: 3px;
            background: #fff;
            height: 580px;
            z-index: 99999999;
        }

        .ajax__tab_body.ajax__scroll_none {
            height: 400px !important;
        }


        /* Close Button */
        .popup-close {
            width: 30px;
            height: 30px;
            padding-top: 4px;
            display: inline-block;
            position: absolute;
            top: 0px;
            right: 0px;
            transition: ease 0.25s all;
            -webkit-transform: translate(50%, -50%);
            transform: translate(50%, -50%);
            border-radius: 1000px;
            background: rgba(0,0,0,0.8);
            font-family: Arial, Sans-Serif;
            font-size: 20px;
            text-align: center;
            line-height: 100%;
            color: #fff;
        }

            .popup-close:hover {
                -webkit-transform: translate(50%, -50%) rotate(180deg);
                transform: translate(50%, -50%) rotate(180deg);
                background: rgba(0,0,0,1);
                text-decoration: none;
            }
        /* Popup CSS Styles End */

        a.btnInco {
            background: url(../Theme/assets/img/inco_ic.png) no-repeat left top;
            width: 24px;
            height: 24px;
            display: inline-block;
            margin-left: 10px;
        }

        .IncoImg {
            float: left;
            width: 45px;
            margin: 0px 0.5% 0px 0px;
        }

        .AppLabel {
            width: 22.9%;
            float: left;
            font-size: 11px;
            text-align: right;
            margin: 22px 0.3% 0px 0px;
        }

        .popup img {
            height: 533px !important;
        }

        .box {
            margin-top: 16px;
        }
    </style>

    <style type="text/css">
        .box {
            /*width: 40%;
  margin: 0 auto;
  background: rgba(255,255,255,0.2);
  padding: 35px;
  border: 2px solid #fff;
  border-radius: 20px/50px;
  background-clip: padding-box;
  text-align: center;*/
        }

        .button {
            font-size: 1em;
            padding: 10px;
            color: #fff;
            /*border: 2px solid #06D85F;*/
            border-radius: 20px/50px;
            text-decoration: none;
            cursor: pointer;
            transition: all 0.3s ease-out;
        }
        /*.button:hover {
  background: #06D85F;
}*/

        .overlay {
            position: fixed;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            background: rgba(0, 0, 0, 0.7);
            transition: opacity 500ms;
            visibility: hidden;
            opacity: 0;
        }

            .overlay:target {
                visibility: visible;
                opacity: 1;
                z-index: 3;
            }

        .popup {
            margin: 3px auto;
            padding: 20px;
            background: #fff;
            border-radius: 5px;
            width: 66%;
            position: relative;
            transition: all 5s ease-in-out;
        }

            .popup h2 {
                margin-top: 0;
                color: #333;
                font-family: sans-serif, Arial, sans-serif;
            }

            .popup .close {
    position: absolute;
    top: 30px;
    right: 30px;
    background-color: black;
    transition: all 200ms;
    font-size: 20px !important;
    font-weight: bold;
    text-decoration: none;
    color: #333;
}

                .popup .close:hover {
                    color: #06D85F;
                }

            .popup .content {
                max-height: 30%;
                overflow: auto;
            }


        .Gridpnl {
            /* width: 1058px; */
            width: 100%;
            Height: 507px;
            overflow: auto;
        }


        /*.blueheighlight {
            border:1px solid #4286f4!important;
        }*/
        /*table#logix_CPH_grd th {
            background-color: var(--navbarcolor) !important;
            padding: 2px 5px !important;
        }*/
        a#logix_CPH_lblQuot, a#logix_CPH_LinkButton3, a#logix_CPH_lblBooking {
    /* display: block; */
    /* width: 6%; */
    background: #dedcdc;
    padding: 5px 10px;
    border-radius: 3px;
}
        .BookingRight.boxmodal {
    margin: 0px 0 0 5px !important;
}
        .panel_08 {
    background-color: white;
        height: 252px !important;
}
        a#logix_CPH_lblBooking {
    float: right;
    position: relative;
    right: 275px;
}
        a#logix_CPH_LinkButton3 {
    position: absolute;
    left: 510px;
}
        a#logix_CPH_lblQuot {
    position: absolute;
}
        .FormInner2 span {
    height: 0px !important;
}
        .TableLeft.boxmodal {
    margin-right: 0.5% !important;
    width: 49%;
}
        .widget.box {
    position: relative;
    top: -8px;
}
    </style>

  

    <script type="text/javascript">
        $(function () {
            //----- OPEN
            $('[data-popup-open]').on('click', function (e) {
                var targeted_popup_class = jQuery(this).attr('data-popup-open');
                $('[data-popup="' + targeted_popup_class + '"]').fadeIn(350);

                e.preventDefault();
            });

            //----- CLOSE
            $('[data-popup-close]').on('click', function (e) {
                var targeted_popup_class = jQuery(this).attr('data-popup-close');
                $('[data-popup="' + targeted_popup_class + '"]').fadeOut(350);

                e.preventDefault();
            });
        });


        jQuery(document).ready(function () {
            jQuery('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('href');

                // Show/Hide Tabs
                jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });
    </script>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('input:text:first').focus();
            });
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
            $(document).ready(function () {
                $("#<%=txt_shiper.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_shipperid.ClientID %>").val(0);
                        $.ajax({
                            url: "Booking.aspx/GetLikeCustomer",
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
                                //  alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },


                    select: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdn_shipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipermulti.ClientID %>").val(i.item.text);
                            $("#<%=txt_shiper.ClientID %>").change();
                           <%-- $("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdn_shipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipermulti.ClientID %>").val(i.item.text);
                            $("#<%=txt_shiper.ClientID %>").val($.trim(result));
                            <%--$("#<%=txt_shiper.ClientID %>").val(i.item.address);--%>
                        }

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdn_shipperid.ClientID %>").val(i.item.val);
                            $("#<%=txt_shipermulti.ClientID %>").val(i.item.text);


                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_shiper.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_shiper.ClientID %>").val($.trim(res));
                        }
                    },

                    minLength: 1

                });
            });


            $(document).ready(function () {
                $("#<%=txt_consignee.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_Consigneeid.ClientID %>").val(0);
                        $.ajax({
                            url: "Booking.aspx/GetLikeCustomer",
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
                                // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_consigneemulti.ClientID %>").val(i.item.text);
                        $("#<%=hdn_Consigneeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_consignee.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_consigneemulti.ClientID %>").val(i.item.text);
                        $("#<%=hdn_Consigneeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_consignee.ClientID %>").val($.trim(result));


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_consigneemulti.ClientID %>").val(i.item.text);
                            $("#<%=hdn_Consigneeid.ClientID %>").val(i.item.val);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_consignee.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_consignee.ClientID %>").val($.trim(res));
                        }
                    },
                    minLength: 1

                });
            });


            $(document).ready(function () {
                $("#<%=txt_agent.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_agentid.ClientID %>").val(0);
                        $.ajax({
                            url: "Booking.aspx/GetLikeAgent",
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
                                        text: item.split('~')[3],
                                        location: item.split('~')[4]
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
                        $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_agent_multi.ClientID %>").val(i.item.text);
                        $("#<%=txt_mailid.ClientID %>").val(i.item.location);
                        $("#<%=hdn_agentid.ClientID %>").val(i.item.val);
                        $("#<%=txt_consignee.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_agent_multi.ClientID %>").val(i.item.text);
                        $("#<%=txt_mailid.ClientID %>").val(i.item.location);
                        $("#<%=hdn_agentid.ClientID %>").val(i.item.val);
                        $("#<%=txt_consignee.ClientID %>").val($.trim(result));


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_agent_multi.ClientID %>").val(i.item.text);
                            $("#<%=txt_mailid.ClientID %>").val(i.item.location);
                            $("#<%=hdn_agentid.ClientID %>").val(i.item.val);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_agent.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_agent.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_agent.ClientID %>").val($.trim(res));
                        }
                    },
                    minLength: 1

                });
            });

            $(document).ready(function () {
                $("#<%=txt_booking.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_bookno.ClientID %>").val(0);
                        $.ajax({
                            url: "Booking.aspx/GetBookingPending",
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
                        $("#<%=hdn_bookno.ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txt_booking.ClientID %>").val(i.item.label);
                        $("#<%=hdn_bookno.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_booking.ClientID %>").val(i.item.label);
                        $("#<%=hdn_bookno.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtInco.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdn_Incoid.ClientID %>").val(0);
                        $.ajax({
                            url: "Booking.aspx/GetLikeIncocode",
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

                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {

                $("#<%=txt_vessel.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Vesselid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Sales/Booking.aspx/FE_Bookking",
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
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                      $("#<%=txt_vessel.ClientID %>").change();
                      $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);
                  },
                    focus: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                        $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                        $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_vessel.ClientID %>").val(i.item.label);
                        $("#<%=hid_Vesselid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_vsl_pol.ClientID %>").autocomplete({

                  source: function (request, response) {
                      $("#<%=hid_Loadportid.ClientID %>").val(0);
                      $.ajax({
                          url: "../Autocomplete/Autocomplete.aspx/GetPort",
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
                      $("#<%=txt_vsl_pol.ClientID %>").val(i.item.label);
                        $("#<%=txt_vsl_pol.ClientID %>").change();
                        $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);
                    },
                  focus: function (event, i) {
                      $("#<%=txt_vsl_pol.ClientID %>").val(i.item.label);
                      $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);
                  },
                  change: function (event, i) {
                      $("#<%=txt_vsl_pol.ClientID %>").val(i.item.label);
                      $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);

                  },
                  close: function (event, i) {
                      $("#<%=txt_vsl_pol.ClientID %>").val(i.item.label);
                      $("#<%=hid_Loadportid.ClientID %>").val(i.item.val);
                  },
                  minLength: 1
              });
          });


          $(document).ready(function () {
              $("#<%=txtFactory.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_factory.ClientID %>").val(0);
                        $.ajax({
                            url: "../Sales/Booking.aspx/Get_Factory",
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
                        $("#<%=txtFactory.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtFactory.ClientID %>").change();
                        $("#<%=hid_factory.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtFactory.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_factory.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtFactory.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_factory.ClientID %>").val(i.item.val);
                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txtFactory.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(','));
                        $("#<%=txtFactory.ClientID %>").val($.trim(res));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_vsl_pod.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hid_Destportid.ClientID %>").val(0);
                            $.ajax({
                                url: "../Autocomplete/Autocomplete.aspx/GetPort",
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
                            $("#<%=txt_vsl_pod.ClientID %>").val(i.item.label);
                            $("#<%=txt_vsl_pod.ClientID %>").change();
                            $("#<%=hid_Destportid.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_vsl_pod.ClientID %>").val(i.item.label);
                            $("#<%=hid_Destportid.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            $("#<%=txt_vsl_pod.ClientID %>").val(i.item.label);
                            $("#<%=hid_Destportid.ClientID %>").val(i.item.val);

                        },
                        close: function (event, i) {
                            $("#<%=txt_vsl_pod.ClientID %>").val(i.item.label);
                            $("#<%=hid_Destportid.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
                });
                $(document).ready(function () {

                    $("#<%=Search.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $.ajax({
                                url: "../ForwardExports/ShippingBill.aspx/FEShippingbill_GetShipNo",
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
                            $("#<%=Search.ClientID %>").val(i.item.label);
                        $("#<%=Search.ClientID %>").change();
                    },
                        focus: function (event, i) {
                            $("#<%=Search.ClientID %>").val(i.item.label);
                    },
                    change: function (event, i) {
                        $("#<%=Search.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        $("#<%=Search.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                    });
                });

                $(document).ready(function () {
                    $("#<%=txt_shipmail.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $.ajax({
                                //url: "../Sales/Booking.aspx/GetLikeCustMailID",
                                url: "../Sales/Booking.aspx/GetLikeCustomerShip",
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
                            $("#<%=txt_shipmail.ClientID %>").val(i.item.label);
                            $("#<%=txt_shipmail.ClientID %>").change();
                        },
                        focus: function (event, i) {
                            $("#<%=txt_shipmail.ClientID %>").val(i.item.label);
                        },
                        change: function (event, i) {
                            $("#<%=txt_shipmail.ClientID %>").val(i.item.label);

                        },
                        close: function (event, i) {
                            $("#<%=txt_shipmail.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                    });
                });

                $(document).ready(function () {
                    $("#<%=txt_consmail.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $.ajax({
                                //url: "../Sales/Booking.aspx/GetLikeCustMailID",
                                url: "../Sales/Booking.aspx/GetLikeCustomerCons",
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
                            $("#<%=txt_consmail.ClientID %>").val(i.item.label);
                            $("#<%=txt_consmail.ClientID %>").change();
                        },
                        focus: function (event, i) {
                            $("#<%=txt_consmail.ClientID %>").val(i.item.label);
                        },
                        change: function (event, i) {
                            $("#<%=txt_consmail.ClientID %>").val(i.item.label);

                        },
                        close: function (event, i) {
                            $("#<%=txt_consmail.ClientID %>").val(i.item.label);
                        },
                        minLength: 1
                    });
                });
                    $(document).ready(function () {
                        $("#<%=txt_othermail.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hid_Destportid.ClientID %>").val(0);
                            $.ajax({
                                url: "../Sales/Booking.aspx/GetLikeCustMailID",
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
                            $("#<%=txt_othermail.ClientID %>").val(i.item.label);
                            $("#<%=txt_othermail.ClientID %>").change();
                        },
                        focus: function (event, i) {
                            $("#<%=txt_othermail.ClientID %>").val(i.item.label);
                        },
                        change: function (event, i) {
                            $("#<%=txt_othermail.ClientID %>").val(i.item.label);

                        },
                        close: function (event, i) {
                            $("#<%=txt_othermail.ClientID %>").val(i.item.label);
                        },
                        minLength: 1
                    });
                });

                    $(".date").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        dateFormat: 'dd/mm/yy'
                    });
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



        function hide() {
            document.getElementById('popup1').style.display = 'none';
        }
    </script>

    <style type="text/css">
        .FormGroupContent4 textarea {
            height: 54px !important;
        }

        .FormGroupContent4 .Form2 textarea {
            height: 55px !important;
        }

        .VolumeInput {
            width: 6% !important;
            float: left;
            margin: 0px 0.5% 0px 0%;
            font-size: 11px;
            color: #000080;
        }


        .Srcbox1 {
            width: 29%;
            float: left;
            margin: 5px 0px 0px 5px;
        }

        .tblHeight2 {
            border: 1px solid var(--lightgrey);
            float: right;
            height: 50px;
            margin: 10px 0px 0 4px;
            overflow: auto;
            width: 29%;
            display: none;
        }
        .panel_07.MB0 {
    height: 185px!important;
}
        .chkbox1 {
            width: 47%;
            float: left;
            margin: 10px 0px 0px 0px;
        }

        .BookingLabel {
            float: left;
            width: 4.5%;
            text-align: right;
            font-size: 11px;
            margin: 0.2% .2% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .QuotationInput {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 8.2%;
            font-size: 11px;
            font-size: 11px;
            color: #000080;
        }

        .EBooking {
            width: 4.8%;
            float: left;
            margin: 3px 0.5% 0px 0px;
        }

            .EBooking span {
                color: navy;
                font-size: 11px;
                margin: 3px 0px 0px 0px;
            }


        .EbookingTxtBox {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .widget.box {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            /*height: 637px;*/
            margin-left: 0px;
            margin-top: 0px;
        }

        .BuyRateInput {
            float: left;
            width: 18%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ValidCalendar {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 7%;
            font-size: 11px;
            color: #000080;
        }

        .VoyageInputN4 {
            width: 13.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ShippInputbox {
            width: 49.5%;
            float: left;
            margin: 0px .3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ConsignInputN {
            width: 33%;
            float: left;
            margin: 0px .3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .QuotationBox {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0%;
            font-size: 11px;
            color: #000080;
        }

        .FormInner1 {
            width: 33%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormInner2 {
            width: 32.9%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
            /*height:27px;*/
        }

        .IncoInput {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FormBox1 {
            width: 66.5%;
            float: left;
            margin: 0px 0.3% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Formbox2 {
            width: 33%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Form1 {
            width: 32.8%;
            ;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Form2 {
            width: 32.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Form3 {
            width: 32.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .QuotationRem {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        td {
            font-size: 11px;
        }

        .ShippInput {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ConsignInput {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ShipperInput {
            float: left;
            width: 90%;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .QuotationValue {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 6.5%;
            font-size: 11px;
            color: #000080;
        }

        .Addbutton {
            float: right;
            width: 8.6%;
            margin: 23px 0px 0px 0px;
        }

        .tblHeight1 {
            border: 1px solid #b1b1b1;
            height: 192px;
            overflow: auto;
        }



        .LogHeader {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
            border: 1px solid #b1b1b1;
        }

            .LogHeader thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .LogHeader tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 180px;
                overflow: auto;
            }


            .LogHeader thead th {
                min-width: 140px;
            }


            .LogHeader tbody td {
                min-width: 140px;
            }

            .LogHeader thead th:nth-child(1) {
                min-width: 50px;
            }


            .LogHeader tbody td:nth-child(1) {
                min-width: 50px;
            }

            .LogHeader thead th:nth-child(2) {
                min-width: 100px;
            }


            .LogHeader tbody td:nth-child(2) {
                min-width: 100px;
            }


            .LogHeader thead th:nth-child(3) {
                min-width: 110px;
            }


            .LogHeader tbody td:nth-child(3) {
                min-width: 110px;
            }


            .LogHeader thead th:nth-child(4) {
                min-width: 237px;
            }


            .LogHeader tbody td:nth-child(4) {
                min-width: 237px;
            }

            .LogHeader thead th:nth-child(5) {
                min-width: 140px;
            }


            .LogHeader tbody td:nth-child(5) {
                min-width: 140px;
            }



        #logix_CPH_Panel1 {
            height: 112px;
            width: 100%;
        }

        .Grid {
            border: 0px solid #b1b1b1 !important;
        }

        .FormBoxForm2 {
            width: 24%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .ShippInputbox.blueheighlight {
    margin-right: 0.5% !important;
}
    </style>


    <script type="text/javascript">
        function disableBtn(btnID, newText) {
            //initialize to avoid 'Page_IsValid is undefined' JavaScript error
            Page_IsValid = null;
            //check if the page request any validation
            // if yes, check if the page was valid
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                //you can pass in the validation group name also
            }
            //variables
            var btn = document.getElementById(btnID);
            var isValidationOk = Page_IsValid;
            /********NEW UPDATE************************************/
            //if not IE then enable the button on unload before redirecting/ rendering
            if (navigator.appName !== 'Microsoft Internet Explorer') {
                EnableOnUnload(btnID, btn.value);
            }
            /***********END UPDATE ****************************/
            // isValidationOk is not null
            if (isValidationOk !== null) {
                //page was valid
                if (isValidationOk) {
                    btn.disabled = true;
                    btn.value = newText;
                    btn.style.background = 'url(~/images/ajax-loader.gif)';
                }
                else {//page was not valid
                    btn.disabled = false;
                }
            }
            else {//the page don't have any validation request
                setTimeout("setImage('" + btnID + "')", 10);
                btn.disabled = true;
                btn.value = newText;
            }
        }

        //set the background image of the button
        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(images/Loading.gif)';
        }

        //enable the button and restore the original text value
        function EnableOnUnload(btnID, btnText) {
            window.onunload = function () {
                var btn = document.getElementById(btnID);
                btn.disabled = false;
                btn.value = btnText;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">



    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box">
                <asp:Panel ID="PnlBooking" runat="server">
                    <div class="widget-header">
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lblheader" runat="server" Text=" Booking"></asp:Label></h4>
                            <!-- Breadcrumbs line -->
                            <div class="crumbs">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li id="li_head" runat="server" visible="false"><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Exports</a> </li>
                                    <li><a href="#" title="">Sales</a> </li>
                                    <li class="current"><a href="#" title="">Booking</a> </li>
                                </ul>
                            </div>
                        </div>

                        <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="widget-content">
                        <div class="FormGroupContent4 custom-pt-1">
                         <asp:LinkButton ID="lblQuot" runat="server" CausesValidation="False"
                                    EnableViewState="false" OnClick="lblQuot_Click">Quotation #</asp:LinkButton>

                             <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration: none;" TabIndex="23" OnClick="LinkButton3_Click">Buy Rate #</asp:LinkButton>

                                <asp:LinkButton ID="lblBooking" runat="server" OnClick="lblBooking_Click">Booking #</asp:LinkButton>

                            </div>
                        <div class="FormGroupContent4">
                        <div class="FormGroupContent4 boxmodal">

                            <div class="QuotationInput blueheighlight">
                                <span>Quotation #</span>
                               
                                <asp:TextBox ID="txt_quatation" runat="server" CssClass="form-control" ToolTip="Quotation #" TabIndex="1" OnTextChanged="txt_quatation_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </div>

                            <div class="QuotationValue">
                                <asp:Label ID="Label32" runat="server" Text="Date"></asp:Label>

                                <asp:TextBox ID="dtquotdate" runat="server" ToolTip="Date" CssClass="form-control" TabIndex="2" Enabled="False"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="txtdatecalExd" runat="server" Format="dd-MMM-yyyy" TargetControlID="dtquotdate"></ajaxtoolkit:CalendarExtender>
                            </div>

                            <%--  <div class="ValidLabel1">                    


                  </div>--%>
                            <div class="ValidCalendar">
                                <asp:Label ID="lbl_qexpiry" runat="server" Text="Valid Till"></asp:Label>
                                <asp:TextBox ID="dtExpiredOn" runat="server" ToolTip="ValidTill" CssClass="form-control" TabIndex="3"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" Format="dd-MMM-yyyy" TargetControlID="dtExpiredOn"></ajaxtoolkit:CalendarExtender>

                            </div>

                            <div class="VoyageInputN4">
                                <asp:Label ID="Label8" runat="server" Text="Product"></asp:Label>
                                <asp:TextBox ID="ddl_product" runat="server" CssClass="form-control" ToolTip="Product" placeholder=""></asp:TextBox>
                            </div>


                            <%--   <div class="EBooking">--%>



                            <div class="EbookingTxtBox hide">
                                <asp:Label ID="LblEbooking" runat="server" Text="E-Booking#"></asp:Label><asp:TextBox ID="Ebooking" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>


                            <%-- <div class="BuyrateLabel">
                     
                  </div>--%>
                            <div class="BuyRateInput">
                                <span>Buy Rate #</span>                              

                                <asp:TextBox ID="txtBuying" runat="server" CssClass="form-control" ToolTip="Buying number" TabIndex="24"></asp:TextBox>
                            </div>
                            <div class="BuyRateDisable">
                                <span>Valid Till</span>
                                <asp:TextBox ID="txt_validtill" runat="server" ToolTip="Valid Till" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <!-- <div class="MarketLabel">Marketed By:</div>
                      <div class="MarketInput"><asp:TextBox ID="txtMarketby" Width="82.75%" Enabled="false" runat="server" ToolTip="Marketed by" CssClass="form-control" TabIndex="4" BorderStyle="None"></asp:TextBox></div> -->
                            <%--<div class="BookingLabel"</div>--%>


                            <div class="BookingCalendar DateR">
                                <asp:Label ID="Label31" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="dtDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                <ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" Format="dd-MMM-yyyy" TargetControlID="dtDate"></ajaxtoolkit:CalendarExtender>
                            </div>

                            <div class="BookingInput">
                                <span>Booking #</span>
                                <asp:TextBox ID="txt_booking" runat="server" CssClass="form-control" ToolTip="Booking number" AutoPostBack="True" OnTextChanged="txt_booking_TextChanged"></asp:TextBox>
                            </div>
                            </div>

                            <div class="BoolkingLeft">
                                <div class="FormGroupContent4 boxmodal">

                                    <div class="QuotationBox">
                                        <asp:Label ID="Label11" runat="server" Text="Quotation customer"></asp:Label>
                                        <asp:TextBox ID="txt_qcustomer" runat="server" CssClass="form-control" Enabled="False" ToolTip="Quotation customer" PlaceHolder=" " TabIndex="12"></asp:TextBox>
                                    </div>
                                    <div class="QuoteLeft">
                                        <span> </span>
                                        <asp:TextBox ID="test" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                <div class="POL_Box">
                                    <div class="ShippInputbox blueheighlight boxmodal">
                                <div class="FormGroupContent4">
                                        <asp:Label ID="Label9" runat="server" Text="Shipper"></asp:Label>
                                        <asp:TextBox ID="txt_shiper" runat="server" ToolTip="Shipper" AutoPostBack="true" PlaceHolder=" " CssClass="form-control" TabIndex="5" OnTextChanged="txt_shiper_TextChanged"></asp:TextBox>
                                    </div> 
                                        <div class=" FormGroupContent4">
                                            <asp:Label ID="Label12" runat="server" Text="Shipper Address"></asp:Label>
                                            <asp:TextBox ID="txt_shipermulti" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1" ToolTip="Shipper Address" placeholder="" Style="resize: none;" TabIndex="7"></asp:TextBox>
                                        </div>
                                </div>

                                    <div class="ConsignInput boxmodal">
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label10" runat="server" Text="Consignee"></asp:Label>
                                        <asp:TextBox ID="txt_consignee" runat="server" ToolTip="Consignee" AutoPostBack="true" PlaceHolder=" " TabIndex="6" CssClass="form-control" OnTextChanged="txt_consignee_TextChanged"></asp:TextBox>
                                    </div> 

                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label13" runat="server" Text="Consignee Address"></asp:Label>
                                            <asp:TextBox ID="txt_consigneemulti" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1" ToolTip="Consignee Address" placeholder="" Style="resize: none;" TabIndex="8"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="FormGroupContent4 boxmodal custom-d-flex">
                                        <div class="PORLeftN1">
                                            <asp:Label ID="Label20" runat="server" Text="P o R"></asp:Label>
                                            <asp:TextBox ID="txt_por" runat="server" CssClass="form-control" Enabled="False" ToolTip="PLACE OF RECEIPT" PlaceHolder=" " ReadOnly="true" TabIndex="13"></asp:TextBox>
                                        </div>
                                        <div class="FormBoxForm2">
                                            <asp:Label ID="Label21" runat="server" Text="P o L"></asp:Label>
                                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" ToolTip="PORT OF LOADING" PlaceHolder=" " Enabled="False" ReadOnly="true" TabIndex="14"></asp:TextBox>
                                        </div>
                                        <div class="PORLeftN1">
                                            <asp:Label ID="Label22" runat="server" Text="P o D"></asp:Label>
                                            <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" ToolTip="PORT OF DISCHARGE" PlaceHolder=" " Enabled="False" ReadOnly="true" TabIndex="15"></asp:TextBox>
                                        </div>
                                        <div class=" custom-col">
                                            <asp:Label ID="Label23" runat="server" Text="Place of Delivery"></asp:Label>
                                            <asp:TextBox ID="txt_fd" runat="server" CssClass="form-control" ToolTip="Place of Delivery" PlaceHolder="" ReadOnly="true" Enabled="False" TabIndex="16"></asp:TextBox>
                                        </div>
                                    </div>
                                    </div>
                                    <%--  --%>
                                    <div class="Agent2 boxmodal">
                                    <div class=" FormGroupContent4">
                                        <asp:Label ID="Label14" runat="server" Text="Agent"></asp:Label>
                                        <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" ToolTip="Agent" placeholder=" " AutoPostBack="true" OnTextChanged="txt_agent_TextChanged" TabIndex="9"></asp:TextBox>
                                    </div>

                                        <div class="FormGroupContent4 ">
                                            <asp:Label ID="Label16" runat="server" Text="Agent Address"></asp:Label>
                                            <asp:TextBox ID="txt_agent_multi" runat="server" CssClass="form-control" ToolTip="Agent Address" placeholder=" " TextMode="MultiLine" Rows="2" Style="resize: none;" TabIndex="10"></asp:TextBox>
                                        </div>

                                            <div class="FormGroupContent4">
                                                <asp:Label ID="Label15" runat="server" Text="Mail ID "></asp:Label>
                                                <asp:TextBox ID="txt_mailid" runat="server" CssClass="form-control" ToolTip="Mail ID" TabIndex="11" PlaceHolder=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%--  --%>
                                    <div class="FormGroupContent4 boxmodal">
                                        <div class="FormBoxForm1 ">
                                            <asp:Label ID="Label24" runat="server" Text="Shipment"></asp:Label>
                                            <asp:TextBox ID="txtshipment" runat="server" CssClass="form-control" Enabled="False" ToolTip="SHIPMENT" PlaceHolder=" " ReadOnly="true" TabIndex="17"></asp:TextBox>
                                        </div>
                                        <div class="Freight">
                                            <asp:Label ID="Label25" runat="server" Text="Freight"></asp:Label>
                                            <asp:TextBox ID="txtfreight" runat="server" CssClass="form-control" Enabled="False" ToolTip="FREIGHT" PlaceHolder=" " ReadOnly="true" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div class="FormMedium">
                                            <asp:Label ID="Label26" runat="server" Text="Cargo"></asp:Label>
                                            <asp:TextBox ID="txt_cargo" runat="server" CssClass="form-control" Enabled="False" ToolTip="CARGO" ReadOnly="true" PlaceHolder=" " TabIndex="19"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="FormGroupContent4 boxmodal custom-d-flex">

                                        <div class="IncoInput blueheighlight">
                                            <asp:Label ID="Label17" runat="server" Text="Inco"></asp:Label>
                                            <asp:TextBox ID="txtInco" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="INCO" PlaceHolder=" " TabIndex="20" OnTextChanged="txtInco_TextChanged"></asp:TextBox>
                                        </div>

                                        <div class="IncoImg">
                                            <div class="box">
                                                <a class="btnInco button" href="#popup1" title="INCO Terms 2016 Rules"></a><%-- --%>
                                            </div>
                                        </div>
                                        <!-- Modal -->




                                        <div id="popup1" class="overlay">
                                            <div class="popup">
                                                <a class="close" onclick="hide()">&times;</a>  <%--  --%>
                                                <div class="content">
                                                    <img src="../Theme/assets/img/INCOTERMS_2016.png" width="835" height="533" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="AppLabel">
                                            <asp:Label ID="Label1" CssClass="LabelValue" runat="server" Style="font-weight: bold;" Text="Approximate Volume for the above Quotation"></asp:Label>
                                        </div>
                                        <div class="VolumeInput blueheighlight">
                                            <%--<asp:Label ID="lbl_voll" runat="server" Text="Volume"></asp:Label>--%>
                                              <asp:Label ID="lbl_voll" runat="server" Text="Volume"></asp:Label>
                                            <asp:TextBox ID="txt_vol" runat="server" CssClass="form-control" ToolTip="VOLUME" PlaceHolder=" " TabIndex="21"></asp:TextBox>
                                        </div>
                                        <div class="Srcbox1" style="display: none">
                                            <asp:Label ID="Label27" runat="server" Text="Search ShippingBill #"></asp:Label>
                                            <asp:TextBox ID="Search" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="Search ShippingBill#" PlaceHolder=""></asp:TextBox>
                                        </div>
                                        <div class="QuotationRem hide">
                                            <asp:Label ID="Label19" runat="server" Text="Factory Name"></asp:Label>
                                            <asp:TextBox ID="txtFactory" runat="server" CssClass="form-control" ToolTip="Factory Name" AutoPostBack="true" PlaceHolder=" " TabIndex="22" OnTextChanged="txtFactory_TextChanged"></asp:TextBox>
                                        </div>
                            <div class="FormInputbox1  blueheighlight">
                                            <asp:Label ID="Label34" runat="server" Text="Customer Ref #"></asp:Label>

                                            <asp:TextBox ID="txt_custpono" runat="server" CssClass="form-control" TabIndex="14" ToolTip="Customer Ref #" PlaceHolder=" " AutoPostBack="True" OnTextChanged="txt_custpono_TextChanged" onkeyup="nospaces(this)"></asp:TextBox>
                                        </div>
                                        <div class="custom-col">
                                <span>Remarks</span>
                                <asp:TextBox ID="txtBRemarks" runat="server" CssClass="form-control"  TabIndex="25" ToolTip="Remarks" PlaceHolder=" Remarks"></asp:TextBox></div>
                                        <!--
                       <div class="VolumeLabel">
                           CssClass="LabelValue"></asp:Label>
                           </div> -->

                                    </div>

                                      <div class="FormGroupContent4">
              <div class="FactoryInput1">
                  
                   <asp:TextBox ID="txtQRemarks" runat="server" visible="false" CssClass="form-control" ToolTip="Quotation Remarks" PlaceHolder=" Quotation Remarks" TabIndex="22"></asp:TextBox>
                  </div>
                              </div> 
                                    <div class="FormGroupContent4 boxmodal">

                                        <div class="tblHeight2" >
                                            <asp:GridView runat="server" ID="checkview" AutoGenerateColumns="false" Width="100%" Height="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true">

                                                <Columns>
                                                    <asp:BoundField DataField="sbno" HeaderText="ShippingBill #">
                                                        <HeaderStyle />
                                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-ForeColor="White">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis;">
                                                                <asp:CheckBox ID="checksbno" runat="server" />
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="job" HeaderText="job #">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="bookingno" HeaderText="bookingno">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>

                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                <RowStyle Font-Italic="False" />
                                            </asp:GridView>
                                        </div>

                                        <div class="chkbox1">
                                            <asp:CheckBox ID="chkBox" runat="server" Text="I read SOP for this Customer" />
                                        </div>
                                        <div class="SOP" id="lbtnSop1" runat="server">
                                            <asp:LinkButton ID="lbtnSop" runat="server" CausesValidation="False" OnClick="lbtnSop_Click">SOP</asp:LinkButton>
                                        </div>

                                    </div>






                            </div>

                            <div class="BookingRight boxmodal">
                                <div class="ShipperInput">

                                    <asp:Label ID="Label28" runat="server" Text="Shipper Mail ID"></asp:Label>
                                    <asp:TextBox ID="txt_shipmail" runat="server" CssClass="form-control" TabIndex="40" placeholder="" ToolTip="Shipper Mail ID"></asp:TextBox>
                                </div>

                                <div class="btn btn-add-icon-blue">
                                    <asp:Button ID="btn_shipmail" runat="server" CssClass="" TabIndex="41" Text="" OnClick="btn_shipmail_Click" />
                                </div>
                                <div class="ShipperInput">
                                    <asp:Label ID="Label29" runat="server" Text="Consignee Mail ID"></asp:Label>
                                    <asp:TextBox ID="txt_consmail" runat="server" CssClass="form-control" TabIndex="42" placeholder="" ToolTip="Consignee Mail ID"></asp:TextBox>
                                </div>
                                <div class="btn btn-add-icon-blue">
                                    <asp:Button ID="btn_cons" runat="server" CssClass="" Text="" TabIndex="43" OnClick="btn_cons_Click" />
                                </div>
                                <div class="ShipperInput">
                                    <asp:Label ID="Label30" runat="server" Text="Others Mail ID"></asp:Label>
                                    <asp:TextBox ID="txt_othermail" runat="server" CssClass="form-control" TabIndex="44" placeholder="" ToolTip="Others Mail ID"></asp:TextBox>
                                </div>
                                <div class="btn btn-add-icon-blue">
                                    <asp:Button ID="btn_othermail" runat="server" CssClass="" TabIndex="45" Text="" OnClick="btn_othermail_Click" />
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="panel_07 MB0">
                                        <asp:GridView runat="server" ID="grdCMail" AutoGenerateColumns="false" Width="100%" Height="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                                            OnRowDataBound="grdCMail_RowDataBound" OnSelectedIndexChanged="grdCMail_SelectedIndexChanged" OnPreRender="grdCMail_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="Cname" runat="server" HeaderText="Type">
                                                    <HeaderStyle />
                                                    <ItemStyle Font-Bold="false" Width="20%" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Mail-ID" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 95%">
                                                            <asp:Label ID="email" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="false" Width="80%" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80%" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <%--<asp:BoundField DataField="email" runat="server" HeaderText="Mail-ID" >
                        <HeaderStyle Width ="100px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Left"  Width ="100px" />
                        </asp:BoundField> --%>

                                                <%--<asp:TemplateField HeaderText="">
                         <HeaderStyle Width ="30px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Center"  Width ="30px" />
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkMail" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" />
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>
                            <div class="bordertopNew"></div>
                            <div class="FormGroupContent4">
                                <div class="TableLeft boxmodal">
                                    <h3>
                                        <asp:Label ID="Label4" runat="server" Text="Quotation Charges" CssClass="LabelValue"></asp:Label></h3>
                                    <asp:Panel ID="Panel2" runat="server" CssClass="panel_09" ScrollBars="Auto">
                                        <asp:GridView runat="server" ID="grd" AutoGenerateColumns="False" PageSize="3" ShowHeaderWhenEmpty="true"
                                            Width="100%" Height="100%" CssClass="Grid FixedHeader" OnPreRender="grd_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="chargename" runat="server" HeaderText="Charges">
                                                    <HeaderStyle />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="curr" runat="server" HeaderText="Curr">
                                                    <HeaderStyle />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="rate" HeaderText="Rate" runat="server"
                                                    DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="base" HeaderText="Base/Unit" runat="server">
                                                    <HeaderStyle />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="PP/TC">
                                                    <HeaderStyle Width="120px" />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" />
                                                    <ItemTemplate runat="server">
                                                        <asp:DropDownList ID="ddl_item_prepaid_grd" runat="server" Width="100%" AutoPostBack="true">
                                                            <asp:ListItem Value="0">Prepaid</asp:ListItem>
                                                            <asp:ListItem Value="1">Collect</asp:ListItem>
                                                           <%-- <asp:ListItem Value="2">Collect</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" />

                                        </asp:GridView>

                                    </asp:Panel>
                                </div>

                                <div class="TableRight boxmodal">
                                    <h3>
                                        <asp:Label ID="Label7" runat="server" Text="Buy Rate Charges" CssClass="LabelValue"></asp:Label></h3>
                                    <asp:Panel ID="Panel1" runat="server" CssClass="panel_09" ScrollBars="Auto">
                                        <asp:GridView runat="server" ID="GrdBuying" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                            PageSize="3" Width="100%" Height="100%" CssClass="Grid FixedHeader" OnPreRender="GrdBuying_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                    <HeaderStyle />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="curr" HeaderText="Curr">
                                                    <HeaderStyle />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="base" HeaderText="Base/Unit">
                                                    <HeaderStyle />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="PP/TC">
                                                    <HeaderStyle Width="120px" />
                                                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" />
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddl_item_prepaid" runat="server" Width="100%" AutoPostBack="true">
                                                            <asp:ListItem Value="0">Prepaid</asp:ListItem>
                                                            <asp:ListItem Value="1">Collect</asp:ListItem>
                                                          <%--  <asp:ListItem Value="2">Collect</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>

                            </div>

                            <%--<div class="QuoteLeft">--%>
                            <%--<asp:Panel ID="Gridcont" runat="server" Visible="true"  CssClass="Grid FixedHeader"  ScrollBars="Vertical" Height="80px">--%>
                            <%--</asp:Panel>--%>
                            <%--</div>--%>

                            <div class="FormGroupContent4">
                                <div style="float: left; margin: 2px 0px 2px 0px;">

                                    <div class="CancelBooking">



                                        <%--<asp:LinkButton ID="LinkButton1" Style="color: Red; text-decoration: none; margin-right: 1%;" runat="server" OnClick="lnkCancel_Click">Cancel Booking</asp:LinkButton>--%>
                                    </div>
                                    <div class="Previous">
                                        <asp:LinkButton ID="lnk_back" Style="text-decoration: none;" ForeColor="Red" runat="server" OnClick="lnk_back_Click">Back to Previous</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="right_btn">
                                    <div class="btn btn-save1">
                                        <asp:Button ID="approvedbooking" runat="server" Text="ApprovedBooking" Visible="false" OnClick="approvedbooking_Click" />
                                    </div>
                                    <div class="btn btn-send1">
                                        <asp:Button ID="Button1" runat="server" ToolTip="Send" OnClick="btnSend_Click" TabIndex="29" />
                                    </div>
                                    <div class="btn btn-save1" id="btn_save1" runat="server">
                                        <asp:Button ID="btnSave" runat="server" ToolTip="Save" TabIndex="26" OnClick="btnSave_Click1" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="btn btn-delete1"></div>
                                    <div class="btn btn-view1">
                                        <asp:Button ID="btn_view" runat="server" Enabled="true" ToolTip="View" TabIndex="27" OnClick="btn_view_Click" />
                                    </div>
                                    <%--<div class="btn btn-delete"><asp:Button ID="btn_delete" runat="server" Enabled="false" Text="Delete" TabIndex="28"/></div>--%>
                                    <div class="btn btn-delete1">
                                        <asp:Button ID="btn_LinkButton1" runat="server" Enabled="true" ToolTip="Cancel Booking" TabIndex="28" OnClick="lnkCancel_Click" />
                                    </div>

                                    <div class="btn btn-cancel1" id="btn_cancel1" runat="server">
                                        <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" TabIndex="29" />
                                    </div>





                                </div>

                            </div>

                            <div class="FormGroupContent4 boxmodal" id="div_vessel_add" runat="server" visible="false">
                                <div class="VoyageInputN4">
                                    <span>Type</span>
                                    <asp:DropDownList ID="vsltype" runat="server" AppendDataBoundItems="True" TabIndex="31" CssClass="chzn-select" ToolTip="Type" data-placeholder="Type">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Feeder" Value="F"></asp:ListItem>
                                        <asp:ListItem Text="Mother" Value="M"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="VesselInput">
                                    <span>Vessel</span>
                                    <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="30" ToolTip="VESSEL" PlaceHolder="Vessel" OnTextChanged="txt_vessel_TextChanged"></asp:TextBox>
                                </div>

                                <div class="PolInput">
                                    <span>Voyage</span>
                                    <asp:TextBox ID="txt_voyage" runat="server" CssClass="form-control" ToolTip="VOYAGE" TabIndex="32" PlaceHolder="Voyage"></asp:TextBox>
                                </div>
                                <div class="PolCal">
                                    <span>Cut off</span>
                                    <asp:TextBox ID="txt_cutoff" runat="server" CssClass="form-control" ToolTip="Cut off" TabIndex="33" PlaceHolder="Cut off"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_cutoff"></ajaxtoolkit:CalendarExtender>
                                </div>
                                <div class="PodInput">
                                    <span>Port Of Loading</span>
                                    <asp:TextBox ID="txt_vsl_pol" runat="server" CssClass="form-control" ToolTip="PORT OF LOADING" AutoPostBack="true" PlaceHolder=" Port of Loading" TabIndex="34" OnTextChanged="txt_vsl_pol_TextChanged"></asp:TextBox>
                                </div>
                                <div class="PodCal">
                                    <span>ETD</span>
                                    <asp:TextBox ID="txt_etd" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="ETD" TabIndex="35" PlaceHolder="ETD"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_etd"></ajaxtoolkit:CalendarExtender>
                                </div>
                                <div class="Pol">
                                    <span>ETD</span>
                                    <asp:TextBox ID="txt_vsl_pod" runat="server" CssClass="form-control" ToolTip="PORT OF DISCHARGE" AutoPostBack="true" PlaceHolder=" Port of Discharge" TabIndex="36" OnTextChanged="txt_vsl_pod_TextChanged"></asp:TextBox>
                                </div>
                                <div class="CalNew1">
                                    <span>ETA</span>
                                    <asp:TextBox ID="txt_eta" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="ETA" PlaceHolder="ETA" TabIndex="37"></asp:TextBox>
                                </div>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_eta"></ajaxtoolkit:CalendarExtender>
                                <div class="PodADD">
                                    <div class="btn btn-add1" runat="server" id="btn_add1">
                                        <asp:Button ID="btn_add" runat="server" ToolTip="Add" OnClick="btn_add_Click" Height="24" TabIndex="38" />
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4 boxmodal" id="div_vessel_grid" runat="server" visible="false">
                                <asp:Panel ID="panel_vessel" runat="server" CssClass="panel_10" ScrollBars="Vertical" Visible="false">
                                    <asp:GridView ID="grd_vessel" runat="server" CssClass="Grid FixedHeader" Width="100%" Height="100%" OnRowDataBound="grd_vessel_RowDataBound" ShowHeaderWhenEmpty="true"
                                        AutoGenerateColumns="False" OnSelectedIndexChanged="grd_vessel_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="vsltype" HeaderText="Type" />
                                            <asp:BoundField DataField="vesselname" HeaderText="Vessel" />
                                            <asp:BoundField DataField="voyage" HeaderText="Voyage" />
                                            <asp:BoundField DataField="pol" HeaderText="POL" />
                                            <asp:BoundField DataField="etd" HeaderText="ETD" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="pod" HeaderText="POD" />
                                            <asp:BoundField DataField="eta" HeaderText="ETA" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="cutoffdt" HeaderText="Cut OFF" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="vesselid" HeaderText="vslid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField DataField="polid" HeaderText="polid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField DataField="podid" HeaderText="podid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" OnClick="Img_Delete_Click"
                                                        ImageUrl="~/images/delete.jpg" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="10px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>

                            </div>
                            <div class="FormGroupContent4">

                                <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
                                    <br />
                                    <div style="font-size: 10pt"><b>Do you want to Delete?</b></div>
                                    <br />
                                    <div class="div_confirm">
                                        <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
                                        <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
                                    </div>
                                    <br />
                                    <div class="div_Break"></div>
                                </asp:Panel>
                            </div>

                        </div>
                    </div>
                </asp:Panel>

            </div>
        </div>
    </div>



    <%------------------------------------------------ Quotation -------------------------------------------%>
    <asp:Label ID="lblAI" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
        PopupControlID="pnlJobAE" PopupDragHandleControlID="grdBuyingDetails" DropShadow="false"
        CancelControlID="imgfgok">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel ID="pnlJobAE" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel8" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="grdQuotation" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False"
                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="20"
                    CssClass="Grid FixedHeader" Visible="False" OnRowDataBound="grdQuotation_RowDataBound" OnPageIndexChanging="grdQuotation_PageIndexChanging"
                    OnSelectedIndexChanged="grdQuotation_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Quotno" HeaderText="Quot. #">
                            <ControlStyle Width="900px" />
                            <HeaderStyle Width="120px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="95px" />

                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 300px">
                                    <asp:Label ID="review" runat="server" Text='<%# Bind("Customer") %>' ToolTip='<%#Bind("Customer")%>'></asp:Label>
                                </div>

                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="408px" />
                            <ItemStyle HorizontalAlign="Left" Width="335px" Wrap="true" />

                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="POL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 95px">
                                    <asp:Label ID="review" runat="server" Text='<%# Bind("pol") %>' ToolTip='<%#Bind("pol")%>'></asp:Label>
                                </div>

                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" Width="113px" />
                            <ItemStyle HorizontalAlign="Left" Width="90px" />

                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="POD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 95px">
                                    <asp:Label ID="review" runat="server" Text='<%# Bind("pod") %>' ToolTip='<%#Bind("pod")%>'></asp:Label>
                                </div>

                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" Width="123px" />
                            <ItemStyle HorizontalAlign="Left" Width="100" />

                        </asp:TemplateField>





                        <asp:TemplateField HeaderText="Approved By">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                                    <asp:Label ID="review" runat="server" Text='<%# Bind("approvedby") %>' ToolTip='<%#Bind("approvedby")%>'></asp:Label>
                                </div>

                            </ItemTemplate>
                            <HeaderStyle Width="248px" />
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Product" HeaderText="Product" />
                       <asp:TemplateField HeaderText="CustomerRef">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="CustomerRef" runat="server" Text='<%# Bind("cuspono") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="Remarks" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>

            <div class="Break"></div>
            <div class="Break"></div>
            <div class="Break"></div>
        </div>

    </asp:Panel>


    <%------------------------------------------------------- Booking -------------------------------------------%>
    <asp:Label ID="lblbkng" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="popupBooking" runat="server" TargetControlID="lblbkng" BehaviorID="programmaticModalPopupBehavior2"
        PopupControlID="popupsecond" DropShadow="false"
        CancelControlID="imgok">
    </ajaxtoolkit:ModalPopupExtender>


    <asp:Panel ID="popupsecond" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="booking" runat="server" CssClass="Gridpnl">
                <%--<div id='table-container'>--%>
                <asp:GridView ID="grdBooking" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False"
                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="20" OnPageIndexChanging="grdBooking_PageIndexChanging"
                    Visible="False" OnRowDataBound="grdBooking_RowDataBound" OnSelectedIndexChanged="grdBooking_SelectedIndexChanged" OnPreRender="grdBooking_PreRender">
                    <Columns>
                        <asp:BoundField DataField="bookingno" HeaderText="Book #">
                            <ControlStyle Width="700px" />
                            <HeaderStyle Width="179px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bookingdate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="90px" />
                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                        </asp:BoundField>
                        <%-- <asp:BoundField DataField="customername" HeaderText="Customer">
                            <HeaderStyle HorizontalAlign="Center" Width="250px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>

                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 450px">
                                    <asp:Label ID="Customerid" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="450px" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />

                        </asp:TemplateField>

                        <asp:BoundField DataField="POL" HeaderText="POL">
                            <HeaderStyle HorizontalAlign="Center" Width="165px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField DataField="POD" HeaderText="POD">
                            <HeaderStyle HorizontalAlign="Center" Width="133px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" Wrap="false" />
                        </asp:BoundField>

                        <asp:BoundField DataField="bookno" HeaderText="bookno" Visible="false">
                            <HeaderStyle Width="450px" />
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="trantype" HeaderText="Product">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="BL #">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="CustomerRef" runat="server" Text='<%# Bind("cuspono") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                            <asp:Label ID="Remarks" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>


            </asp:Panel>
        </div>
        <div class="Break"></div>
        <div class="Break"></div>
        <div class="Break"></div>


    </asp:Panel>

    <%------------------------------------------------------- Cancel -------------------------------------------%>
    <asp:Label ID="LblCncl" runat="server"></asp:Label>


    <ajaxtoolkit:ModalPopupExtender ID="popcancel" runat="server" TargetControlID="LblCncl"
        BehaviorID="programmaticModalPopupBehavior3" DropShadow="false"
        PopupControlID="pnlcncl" PopupDragHandleControlID="grdCancel"
        CancelControlID="Image1">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel ID="pnlcncl" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="grdCancel" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" OnRowCommand="grdCancel_RowCommand" OnRowDeleting="grdCancel_RowDeleting"
                    Width="100%" CssClass="Grid FixedHeader" ForeColor="Black" EmptyDataText="No Record Found" OnRowDataBound="grdCancel_RowDataBound" OnSelectedIndexChanged="grdCancel_SelectedIndexChanged" Visible="False">
                    <%--OnSelectedIndexChanged="grdCancel_SelectedIndexChanged"  AllowPaging="false"  PageSize="20" OnPageIndexChanging="grdCancel_PageIndexChanging"--%>
                    <Columns>
                        <asp:BoundField DataField="bookingno" HeaderText="Book #">
                            <ControlStyle />
                            <HeaderStyle Width="250px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bookingdate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="75px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="customername" HeaderText="Customer">
                            <HeaderStyle HorizontalAlign="Center" Width="365px" />
                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                        </asp:BoundField>

                        <asp:BoundField DataField="POL" HeaderText="POL">
                            <HeaderStyle HorizontalAlign="Center" Width="110px" />
                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField DataField="POD" HeaderText="POD">
                            <HeaderStyle HorizontalAlign="Center" Width="110px" />
                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                        </asp:BoundField>

                        <asp:BoundField DataField="bookno" HeaderText="bookno" Visible="false">
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>


                        <asp:TemplateField HeaderText="">
                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                            <ItemTemplate>

                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" Width="15px" Height="15px" />
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="trantype" HeaderText="Product" />
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>

            <div class="Break"></div>
            <div class="Break"></div>
            <div class="Break"></div>
        </div>
        <div class="Break"></div>
        <div class="Break"></div>
        <div class="Break"></div>
    </asp:Panel>


    <%--  
    CausesValidation="false" --%>

    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label2">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label2" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <div class="div_Break"></div>
    <asp:Panel runat="Server" ID="plnsop" CssClass="Pnl2" Style="display: none;">
        <br />
        <div class="txt_sop">
            <asp:TextBox ID="txtsop" runat="server" CssClass="Text" ToolTip="SOP" BorderColor="#999997"></asp:TextBox>
        </div>
        <br />
        <asp:Panel ID="Panel4" runat="server" CssClass="panel_10">
            <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"
                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" Visible="False">
                <Columns>

                    <asp:BoundField DataField="sop" HeaderText="SOP">
                        <ControlStyle />
                        <HeaderStyle Width="117px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="status" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="75px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>

            <div class="right_btn">
                <div class="btn btn-back1">
                    <asp:Button ID="backsop" runat="server" ToolTip="Back" OnClick="backsop_Click" />
                </div>
            </div>
        </asp:Panel>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupsop" runat="server" BackgroundCssClass=""
        PopupControlID="plnsop" TargetControlID="Label5">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label5" runat="server" Text="Label" Style="display: none;"></asp:Label>


    <div class="div_Break"></div>
    <asp:Panel runat="Server" ID="Panel_Cbox" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Are you read the SOP of this Customer.. </b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnyes" runat="server" Text="OK" CssClass="Button" OnClick="btnyes_Click" />
            <asp:Button ID="btnno" runat="server" Text="Cancel" CssClass="Button" OnClick="btnno_Click" />
        </div>
        <br />

    </asp:Panel>


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" Style="display: none;">
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
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader " runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                    BackColor="White" OnPreRender="GridViewlog_PreRender">
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
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="PopUpCBox" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Cbox" TargetControlID="Label3">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label6" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="Image2" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Label ID="Label3" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <div class="div_Break"></div>
    <asp:HiddenField ID="hdf_customerid" runat="server" />
    <asp:HiddenField ID="hid_cargo" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hdn_shipperid" runat="server" />
    <asp:HiddenField ID="hdn_Consigneeid" runat="server" />
    <asp:HiddenField ID="hdn_agentid" runat="server" />
    <asp:HiddenField ID="hdn_bookno" runat="server" />
    <asp:HiddenField ID="hdn_shipermailid" runat="server" />
    <asp:HiddenField ID="hdn_consigneemailid" runat="server" />
    <asp:HiddenField ID="hdn_Othersemailid" runat="server" />
    <asp:HiddenField ID="hdn_QuotCustomer" runat="server" />
    <asp:HiddenField ID="hdn_Incoid" runat="server" />
    <asp:HiddenField ID="hdn_Business" runat="server" />
    <asp:HiddenField ID="hdn_quotid" runat="server" />
    <asp:HiddenField ID="hid_Loadportid" runat="server" />
    <asp:HiddenField ID="hid_Destportid" runat="server" />
    <asp:HiddenField ID="hd_book" runat="server" />
    <asp:HiddenField ID="hid_Vesselid" runat="server" />
    <asp:HiddenField ID="hid_factory" runat="server" />
    <asp:HiddenField ID="hid_search" runat="server" />


    <asp:HiddenField ID="hid_bookingstatus" runat="server" />

    <asp:HiddenField ID="hidbookingno" runat="server" />
    <asp:HiddenField ID="hidbookno" runat="server" />
    <asp:HiddenField ID="NewBookRpt" runat="server" Value="Y" />
    <%--   <asp:HiddenField ID="hid_PoRportcode" runat="server" />--%>
</asp:Content>
