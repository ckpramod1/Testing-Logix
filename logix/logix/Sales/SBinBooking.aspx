
 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SBinBooking.aspx.cs" Inherits="logix.Sales.SBinBooking" %>

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
            width: 22.5%;
            margin: 5px 0px 0px 5px;
            /* padding: 2px; */
            /* border-left: 1px dotted; */
        }

        .BoolkingLeft {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
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
            width: 49.5%;
            float: left;
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
            width: 80%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }
                  div#logix_CPH_panel_save {
    margin: 5px 0px;
    overflow: auto;
    height: calc(100vh - 433px);
}
        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 13%;
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

        .modalPopup {
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
            width: 9%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BookingInput {
            float: left;
            width: 8.2%;
            margin:0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BookingCalendar {
            float: left;
            width: 9%;
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

        .FormBoxForm1 {
            width: 16%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FormMedium {
            float: left;
            width: 32.2%;
            margin: 0px 0.5% 0px 0px;
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
}table#logix_CPH_grdBooking td:nth-child(3) {
    max-width: 175px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
}
 .BRemarks{
     float:left;
     margin:0 0% 0 0;
     width:50.8%;
 }
 .left_btn {
    float: left;
    margin: 5px 0px 0px 34%;
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
            width: 4%;
            float: left;
            font-size: 11px;
            text-align: center;
            margin: 22px 0.3% 0px 0px;
        }

        .popup img {
            height: 533px !important;
        }

        .box {
            margin-top: 16px;
        }
        .FormInputbox1 {
    float: left;
    width: 50%;
    margin: 0px 0% 0px 0px;
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
    right: 5px;
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
      
        .BookingRight.boxmodal {
    margin: 0px 0 0 5px !important;
}
        .panel_08 {
    background-color: white;
        height: 252px !important;
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
                $("#<%=txt_pkgtype.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hd_package.ClientID %>").val(0);
                        $.ajax({
                            url: "SBinBooking.aspx/Getpackage",
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
                        $("#<%=txt_pkgtype.ClientID %>").val(i.item.label);
                            $("#<%=txt_pkgtype.ClientID %>").change();
                            $("#<%=hd_package.ClientID %>").val(i.item.val);

                        },
                    change: function (e, i) {
                        $("#<%=hd_package.ClientID %>").val(i.item.val);
                            $("#<%=txt_pkgtype.ClientID %>").val(i.item.text);
                        },
                    focus: function (event, i) {
                        $("#<%=txt_pkgtype.ClientID %>").val(i.item.label);
                            $("#<%=hd_package.ClientID %>").val(i.item.val);
                        },
                    close: function (event, i) {
                        $("#<%=txt_pkgtype.ClientID %>").val(i.item.label);
                            $("#<%=hd_package.ClientID %>").val(i.item.val);
                        },
                    minLength: 1
                });
            });

                 
             
            $(document).ready(function () {
                $("#<%=txt_dest.ClientID %>").autocomplete({
          source: function (request, response) {
              $("#<%=hd_exporter.ClientID %>").val(0);
                            $.ajax({
                                url: "SBinBooking.aspx/Getportname",
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
                     <%--  select: function (event, i) {
                         $("#<%=txt_dest.ClientID %>").val(i.item.label);
                         $("#<%=txt_dest.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=txt_dest.ClientID %>").val(i.item.label);
                         $("#<%=hd_dest.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txt_dest.ClientID %>").val(i.item.label);
                         $("#<%=hd_dest.ClientID %>").val(i.item.val);
                     },--%>
                        select: function (event, i) {
                            $("#<%=txt_dest.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_dest.ClientID %>").change();
                            $("#<%=hd_dest.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_dest.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hd_dest.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            if (i.item) {
                                $("#<%=txt_dest.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=hd_dest.ClientID %>").val(i.item.val);
                            }
                        },
                        close: function (event, i) {
                            var result = $("#<%=txt_dest.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txt_dest.ClientID %>").val($.trim(result));
                        },
                        minLength: 1
                    });
  });

            
            $(document).ready(function () {
                $("#<%=txt_sb.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          url: "SBinBooking.aspx/GETShipbill",
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
                      $("#<%=txt_sb.ClientID %>").val(i.item.label);
                            $("#<%=txt_sb.ClientID %>").change();
                            $("#<%=hd_shipbill.ClientID %>").val(i.item.val);
                        },
                        change: function (e, i) {
                            $("#<%=txt_sb.ClientID %>").val(i.item.val);
                            $("#<%=txt_sb.ClientID %>").val(i.item.text);

                        },
                        focus: function (event, i) {
                            $("#<%=txt_sb.ClientID %>").val(i.item.label);
                            $("#<%=hd_shipbill.ClientID %>").val(i.item.val);
                        },
                        close: function (event, i) {
                            $("#<%=txt_sb.ClientID %>").val(i.item.label);
                            $("#<%=hd_shipbill.ClientID %>").val(i.item.val);
                        },
                        minLength: 1
                    });
          })
             

          $(document).ready(function () {
              $("#<%=txt_exporter.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hd_exporter.ClientID %>").val(0);
                         $.ajax({
                             url: "SBinBooking.aspx/Getexporter",
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
                         $("#<%=txt_exporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_exporter.ClientID %>").change();
                            $("#<%=hd_exporter.ClientID %>").val(i.item.val);
                        },
                    change: function (e, i) {
                        $("#<%=txt_exporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hd_exporter.ClientID %>").val(i.item.val);

                        },
                    focus: function (event, i) {
                        $("#<%=txt_exporter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hd_exporter.ClientID %>").val(i.item.val);
                        },
                    close: function (event, i) {

                        var result = $("#<%=txt_exporter.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txt_exporter.ClientID %>").val($.trim(result));
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
            width: 16% !important;
            float: left;
            margin: 0px 0.5% 0px 0px!important;
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
            width: 10%;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ValidCalendar {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 9%;
            font-size: 11px;
            color: #000080;
        }

        .VoyageInputN4 {
            width: 13.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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
            width: 9%;
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
   .ShippInputbox {
    width: 49.15%;
    float: left;
    margin: 0px 5px 0px 0px!important;
    font-size: 11px;
    color: #000080;
}
     
        .widget-content {
    padding: 0px 10px!important;
}
        div#UpdatePanel1 {
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
     
        img#logix_CPH_porflag {
    width: 24px !important;
    height: auto;
    position: relative;
    left: 21%;
    top: -38px;
}
        img#logix_CPH_flagimg{
 width: 24px !important;
    height: auto;
    position: relative;
    left: 20%;
    top: -38px;
        }
        img#logix_CPH_podflag
        {
width: 24px !important;
    height: auto;
    position: relative;
    left: 21%;
    top: -38px;
        }

        img#logix_CPH_fdflag{
width: 24px !important;
    height: auto;
    position: relative;
    left: 45%;
    top: -38px;
        }
        .SBInput {
    width: 11.2%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.SBCal {
    width: 9%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PkgsInput {
    width: 11.4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PkgType1 {
    width: 8.7%;
    float: left;
    margin: 0px;
}
.WeightInput {
    width: 11.4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.VolumeInput1 {
    width: 8.7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.DestinationInput {
    width: 20.6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.RemarksField {
    width: 44%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.GridLeft {
    width: 44.1%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.ExporterInput {
    width: 44%;
    float: left;
}

 
.popupform {
    width: 1000px;
    margin: 0 auto;
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
        <div class="col-md-12">

            <div class="widget box">
                <asp:Panel ID="PnlBooking" runat="server">
                    <div class="widget-header">
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4>
                                <asp:Label ID="lblheader" runat="server" Text=" Shipping Bill"></asp:Label></h4>
                            <!-- Breadcrumbs line -->
                            <div class="crumbs hide">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li id="li_head" runat="server" visible="false"><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Exports</a> </li>
                                    <li><a href="#" title="">Sales</a> </li>
                                    <li class="current"><a href="#" title="">Booking</a> </li>
                                </ul>
                            </div>
                        </div>

                        
                    </div>
                    <div class="widget-content">

                        <div class="popupform">
                          <div class="FormGroupContent2">
                                    <div class="SBInput">
                                        <asp:Label Text="SB #" ID="Label35" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_sb" runat="server" TabIndex="1" CssClass="form-control" OnTextChanged="txt_sb_TextChanged" AutoPostBack="True" placeholder="" ToolTip="SB NUMBER"></asp:TextBox>
                                    </div>
                                    <div class="SBCal">
                                        <asp:Label Text="SB Date" ID="Label36" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_sbdate" runat="server" TabIndex="2" CssClass="form-control" ToolTip="SB Date"  AutoPostBack="True"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="txt_sbdate_CalendarExtender" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="txt_sbdate" />
                                    </div>
                               </div>

                        <div class="FormGroupContent2">
                                    <div class="PkgsInput">
                                        <asp:Label Text="No. of Packages" ID="Label37" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_pkgs" runat="server" TabIndex="3" CssClass="form-control" onkeypress="return isNumberKey(event,'Packages');" placeholder="" ToolTip="Number of Packages"  AutoPostBack="True"></asp:TextBox>
                                    </div>
                                    <div class="PkgType1">
                                        <asp:Label Text="Package Type" ID="Label38" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_pkgtype" TabIndex="4" runat="server" CssClass="form-control"  AutoPostBack="True" OnTextChanged="txt_pkgtype_TextChanged"   placeholder="" ToolTip="Package Type"></asp:TextBox>
                                    </div>
                            </div>


                        <div class="FormGroupContent2">

                                    <div class="WeightInput">
                                        <asp:Label Text="Weight" ID="Label39" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_weight" runat="server" TabIndex="5" CssClass="form-control" onkeypress="return isNumberKey(event,'Volume   ');" placeholder=""  AutoPostBack="True" ToolTip="Weight"></asp:TextBox>
                                    </div>
                                    <div class="VolumeInput1">
                                        <asp:Label Text="Volume" ID="Label40" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_volume" runat="server" TabIndex="6" CssClass="form-control" placeholder="" ToolTip="Volume"></asp:TextBox>
                                    </div>
                            </div>

                        <div class="FormGroupContent2">

                                    <div class="DestinationInput">
                                        <asp:Label Text="Destination" ID="Label41" runat="server"></asp:Label>
                                        <asp:TextBox ID="txt_dest" runat="server" CssClass="form-control" TabIndex="7" OnTextChanged="txt_dest_TextChanged" AutoPostBack="true" placeholder="" ToolTip="Destination"></asp:TextBox>
                                    </div>
                            </div>


                                    <div class="FormGroupContent2">
                                      
                                        <div class="ExporterInput">
                                            <asp:Label Text="Exporter" ID="Label43" runat="server"></asp:Label>
                                            <asp:TextBox ID="txt_exporter" runat="server" TabIndex="8" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_exporter_TextChanged" placeholder="" ToolTip="Exporter"></asp:TextBox>
                                        </div>
                                          </div>
                                    <div class="FormGroupContent2">

                                        <div class="RemarksField">
                                            <asp:Label Text="Remarks" ID="Label44" runat="server"></asp:Label>
                                            <asp:TextBox ID="txt_remarks" runat="server" TabIndex="9" CssClass="form-control" placeholder="" ToolTip="Remarks"></asp:TextBox>
                                        </div>
                                        </div>

                                    
                                    <div class="FormGroupContent2">
                                        
                                        <div class="left_btn custom-mt-3">
                                            <div class="btn ico-save" id="btn_save1" runat="server">
                                                <asp:Button ID="btn_save" runat="server" ToolTip="Save" TabIndex="10" OnClick="btn_save_Click" />
                                            </div>
                                             
                                             <div class="btn ico-delete" id="btn_app1" runat="server">
                            <asp:Button ID="btndelete" runat="server" ToolTip="Delete" TabIndex="36" OnClick="btndelete_Click" />
                        </div>

                                            <div class="btn btn ico-clear">
                                                <asp:Button ID="btn_clear" runat="server" ToolTip="Clear" OnClick="btn_clear_Click" />
                                            </div>

                                            

                                        </div>
                                    </div>
              
                       
                        <div class="FormGroupContent2">
                        <div class="GridLeft boxmodal">
                            <asp:Panel ID="panel_save" CssClass="" runat="server">
                                <asp:GridView ID="Grd_sb" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                    OnSelectedIndexChanged="Grd_sb_SelectedIndexChanged" OnRowDataBound="Grd_sb_RowDataBound" runat="server">

                                    <Columns>

                                        <asp:BoundField DataField="sbno" HeaderText="SB #">

                                            <HeaderStyle Width="25%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="sbdate" HeaderText="SBDate">
                                            <HeaderStyle Width="35%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exporter" HeaderText="Exporter">
                                            <HeaderStyle Width="35%" Wrap="false" />
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pld" HeaderText="POD">
                                            <HeaderStyle Width="35%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="noofpkg" HeaderText="noofpkgs">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="descn" HeaderText="descn">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="grosswt" HeaderText="grosswt">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="volume" HeaderText="volume">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="agent" HeaderText="agent">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="remarks" HeaderText="remarks">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="invpl" HeaderText="invpl">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="shiprefno" HeaderText="sr">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="agentid" HeaderText="agentid">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                      <%--  <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Imgsb" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" Height="16px" OnClick="Imgsb_Click" />
                                            </ItemTemplate>

                                        </asp:TemplateField>--%>

                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader2" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle CssClass="GrdRow" />

                                </asp:GridView>
                            </asp:Panel>
                        </div>
                     
                    </div>
                    </div>
                        </div>
                </asp:Panel>

            </div>
        </div>
    </div>

    




    <asp:Panel runat="Server" ID="Panel6" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                     

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="Label42" runat="server"></asp:Label>

                </div>

            </div>
            
         
                               
        
       
      
         </div>
    </asp:Panel>

 
    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel6"
        DropShadow="false" TargetControlID="Label41" CancelControlID="Image3" BehaviorID="Testshipp">
    </ajaxtoolkit:ModalPopupExtender>
    
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
    <asp:HiddenField ID="hd_shipbill" runat="server" />
    <asp:HiddenField ID="NewBookRpt" runat="server" Value="Y" />
    
    <asp:HiddenField ID="hd_exporter" runat="server" />
     <asp:HiddenField ID="hd_package" runat="server" />
      <asp:HiddenField ID="hd_dest" runat="server" />
    
    <%--   <asp:HiddenField ID="hid_PoRportcode" runat="server" />--%>
</asp:Content>
