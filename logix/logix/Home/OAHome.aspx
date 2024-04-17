<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OAHome.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.OAHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="en-US" prefix="og: http://ogp.me/ns#">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>

    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">

    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">



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



    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".dropdown img.flag").addClass("flag visibility");

            $(".dropdown dt a").click(function () {
                $(".dropdown dd ul").toggle();
            });

            $(".dropdown dd ul li a").click(function () {
                var text = $(this).html();
                $(".dropdown dt a span").html(text);
                $(".dropdown dd ul").hide();
                $("#result").html("Selected value is: " + getSelectedValue("sample"));
            });

            function getSelectedValue(id) {
                return $("#" + id).find("dt a span.value").html();
            }

            $(document).bind('click', function (e) {
                var $clicked = $(e.target);
                if (!$clicked.parents().hasClass("dropdown"))
                    $(".dropdown dd ul").hide();
            });


            $("#flag Switcher").click(function () {
                $(".dropdown img.flag").toggleClass("flag visibility");
            });


        }
    </script>


    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>



    <style type="text/css">
        #Test_foregroundElement {
            left: 55px !important;
            top: 281px !important;
        }

        #Test1_foregroundElement {
            left: 124px !important;
            top: 281px !important;
        }

        #Test2_foregroundElement {
            left: 211px !important;
            top: 281px !important;
        }

        #Test3_foregroundElement {
            left: 328px !important;
            top: 281px !important;
        }

        #Test4_foregroundElement {
            left: 523px !important;
            top: 281px !important;
        }

        #Test5_foregroundElement {
            left: 287px !important;
            top: 281px !important;
        }

        /*#PanelFA {
            height: 250px !important;
        }*/

        .dropdown dd ul li a {
            display: block;
            padding: 1px !important;
        }

        .PendingBooking1 ul li {
            padding: 0 0 0 10px !important;
        }

        .row {
            clear: both;
            height: 365px !important;
            margin: 0 5px 0 -15px;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
        }



        .PendingEventPie {
            float: left;
            margin: 5px 0 0;
            width: 340px;
        }

        .BandLeft {
            float: left;
            width: 35%;
        }

        .BandRight {
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .PendingTblCredit {
            width: 214px;
            float: left;
            margin: 0px 0px 0px 10px;
            height: 90px;
            overflow: auto;
        }

        .PendingTblT {
            width: 210px;
            float: left;
            margin: 0px 0px 0px 10px;
            overflow: auto;
            height: 140px;
        }

        .PendingBookingOA {
            float: left;
            width: 900px;
            margin: 5px 0px 0px 0px;
        }

        .alignright {
            text-align: right;
        }

        .PendingBookingOA ul {
            padding: 0px 0px 0px 0px;
        }

            .PendingBookingOA ul li {
                padding: 2px 0px 2px 10px;
                margin: 0px;
                list-style: none;
                float: left;
            }

                .PendingBookingOA ul li img {
                    padding: 0px 5px 0px 0px;
                }

                .PendingBookingOA ul li a {
                    font-size: 11px;
                    font-family: sans-serif, Geneva, sans-serif;
                    display: inline-block;
                }

        .tblGrid4 {
            width: 100%;
            font-size: 11px;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            border-collapse: collapse;
        }

            .tblGrid4 th {
                background-color: #dbdbdb;
                border-right: 1px solid #51789d;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c;
                text-align: center;
            }

            .tblGrid4 td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                font-weight: bold;
                width: 100%;
                text-align: left;
                padding: 2px 1px 2px 2px;
                margin: 0px;
                color: #184684;
                border-bottom: 1px solid #dddddd;
            }

        .Approved {
            color: #ffffff;
            width: 65px;
            float: left;
            display: block;
            padding: 1px 0px 0px 0px;
            text-align: left;
            margin: 0px 0px 0px 10px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .AppCount {
            color: #e4dfec;
            display: block;
            margin: 6px 0px 0px 15px;
            text-align: left;
            width: 35px;
            float: left;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .UnAppCount {
            color: #e4dfec;
            display: block;
            margin: 6px 12px 0px 0px;
            text-align: right;
            width: 35px;
            float: right;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }



        .UnclosedJobs1 {
            width: 14.2%;
            background-color: #7b8d8e;
            float: left;
            min-height: 113px;
        }


        .AppCountAdmin {
            color: #e4dfec;
            display: block;
            margin: 23px 0px 0px 5px;
            text-align: left;
            width: 35px;
            float: left;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .UnAppCountAdmin {
            color: #e4dfec;
            display: block;
            margin: 22px 12px 0px 0px;
            text-align: right;
            width: 35px;
            float: right;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }






        .AppOtherDN {
            color: #e4dfec;
            display: block;
            margin: 25px 0px 0px 15px;
            text-align: left;
            width: 35px;
            float: left;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

        .UnAppOtherCN {
            color: #e4dfec;
            display: block;
            margin: 25px 12px 0px 0px;
            text-align: right;
            width: 35px;
            float: right;
            padding: 0px 0px 5px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }






        .Unapproved {
            color: #ffffff;
            display: block;
            width: 35px;
            float: right;
            padding: 1px 0px 0px 0px;
            text-align: left;
            margin: 0px 0px 0px 5px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

        .PendingRightnewLRightNew1 {
    float: left;
    width: 737px;
    margin: 0px 0px 0px 20px;
    border: 1px solid var(--inputborder);
    background-color: var(--white);
}
        .OPAccts {
            float: left;
            width: 100%;
            height: 84px;
            margin: -5px 0px 10px 0px;
        }
.PendingRightnewLRightNew {
    float: right;
    width: 593px;
    margin: 0px 0px 0px 0px;
    border: 1px solid var(--inputborder);
    background-color: var(--white);
}

        .PendingRightnewLRightNew_Un {
            float: left;
            width: 86%;
            margin: 0px 0px 0px 10px;
        }
        div#penBlRelase {
    margin: 0px 0px 0px 15px;
}s
    </style>
    <%--TEST--%>

    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />



    <style type="text/css">
        .modalPopupss {
            background-color: #FFFFFF;
            border: 1px solid #4297d7 !important;
            width: 18.5%;
            height: 250px;
            margin-left: 1%;
            margin-top: -0.9%;
            border-radius: 6px;
        }

        .DivSecPanelkpi {
            width: 20px;
            Height: 20px;
            border: 0px solid #b1b1b1;
            margin-left: 87.3%;
            margin-top: -13%;
            border-radius: 90px 90px 90px 90px;
            margin-bottom: 10px;
        }

        .pop_head {
            background-color: #4297d7;
            padding: 3px;
            font-size: 14px;
            color: #fff;
            font-weight: bold;
            border-radius: 4px;
            margin: 3px;
        }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 28px;
            padding: 1px 2px 1px 5px;
            width: 1366px;
        }

        .GridN1 {
            width: 100%;
            border: 0px solid #b1b1b1;
            height: 281px !important;
            margin: 3px 3px 3px 3px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        .GridNb2 {
            width: 100%;
            border: 0px solid #b1b1b1;
            margin: 3px 3px 3px 3px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }









        .GridD1 {
            width: 100%;
            border: 0px solid #b1b1b1;
            height: 292px !important;
            margin: 3px 3px 3px 8px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }






        .GridNC1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            height: 283px !important;
            margin: 3px 3px 3px 16px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        #Panel10 {
            top: 107px !important;
        }

        .GridN2 {
            width: 98%;
            border: 1px solid #b1b1b1;
            height: 225px !important;
            margin: 3px 3px 3px 3px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }


        #dialog {
            top: 139px !important;
        }

        #Panel6 {
            top: 165px !important;
            left: 299px !important;
        }

        #Panel7 {
            left: 380px !important;
            top: 106px !important;
        }

        .GridpnlD1 {
            margin: 0px 0px 0px 0px;
        }

        .modalPopupssD {
            background-color: #FFFFFF;
            border: 1px solid #4297d7 !important;
            width: 42.5%;
            height: 234px;
            margin-left: 1%;
            margin-top: -0.9%;
            border-radius: 6px;
        }

        .DivSecPanelkpiD {
            width: 20px;
            Height: 20px;
            border: 0px solid #b1b1b1;
            margin-left: 93.3%;
            margin-top: -5.5%;
            border-radius: 90px 90px 90px 90px;
            margin-bottom: 10px;
        }



        .PendingTbl1 {
            width: 98%;
        }

        #Panel8 {
            top: 114px !important;
            left: 455px !important;
        }

        .DivSecPanelkpiE {
            width: 20px;
            Height: 20px;
            border: 0px solid #b1b1b1;
            margin-left: 87.3%;
            margin-top: -9%;
            border-radius: 90px 90px 90px 90px;
            margin-bottom: 10px;
        }

        #Panel9 {
            top: 120px !important;
        }

        .PendingTbl6 {
            max-height: 185px;
            min-height: 185px;
        }

        .modalPopupssE {
            background-color: #FFFFFF;
            border: 1px solid #4297d7 !important;
            width: 26.5%;
            height: 234px;
            margin-left: 1%;
            margin-top: -0.9%;
            border-radius: 6px;
        }

        #Panel12 {
            top: 109px !important;
        }

        .modalPopupssEx {
            background-color: #FFFFFF;
            border: 1px solid #4297d7 !important;
            width: 18.5%;
            height: 395px;
            margin-left: 1%;
            margin-top: -0.9%;
            border-radius: 6px;
        }

        .PendingRight {
            float: left;
            width: 571px;
            margin: 0px 0px 0px -12px;
        }

        .PendingRightChequApp {
            float: left;
            width: 700px;
            margin: 0px 0px 0px 10px;
        }

        .PendingRightChequAppNew {
            float: left;
            width: 1343px;
            margin: 0px 0px 0px 0px;
        }

        .PendingRightChequApUnclosed {
            float: left;
            width: 176px;
            margin: 0px 0px 0px -10px;
        }

        .PendingTbl2 {
            max-height: 350px;
            min-height: 350px;
        }

        .PortCountryC {
            float: left;
            width: 195px;
            margin: 0px 0px 0px 0px;
        }

        #Panel11 {
            top: 110px !important;
        }

        .DivSecPanelkpiF {
            width: 20px;
            Height: 20px;
            border: 0px solid #b1b1b1;
            margin-left: 91.3%;
            margin-top: -7%;
            border-radius: 90px 90px 90px 90px;
            margin-bottom: 10px;
        }

        .modalPopupssF {
            background-color: #FFFFFF;
            border: 1px solid #4297d7 !important;
            width: 33.5%;
            height: 234px;
            margin-left: 1%;
            margin-top: -0.9%;
            border-radius: 6px;
        }

        .DivSecPanelkpiDep {
            width: 20px;
            Height: 20px;
            border: 0px solid #b1b1b1;
            margin-left: 91.3%;
            margin-top: -7.5%;
            border-radius: 90px 90px 90px 90px;
            margin-bottom: 10px;
        }

        .modalPopupssDep {
            background-color: #FFFFFF;
            border: 1px solid #4297d7 !important;
            width: 32.5%;
            height: 250px;
            margin-left: 1%;
            margin-top: -0.9%;
            border-radius: 6px;
        }

        .div_Grid {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 0%;
            margin-top: 0%;
            height: 262px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow: auto;
        }

        .div_GridDN {
            width: 100%;
            margin-left: 0%;
            margin-bottom: 0%;
            margin-top: 0.1%;
            height: 210px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow: auto;
        }






        .widget {
            margin-bottom: 0px;
        }

   
        .GrdAltRow {
            background-color: #cee9fd;
            color: Black;
            font-family: sans-serif;
            font-size: 8pt;
            margin-bottom: 0;
            margin-left: 4px;
        }

        .SalesTitlePerN1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: -7px 0px 0px -8px;
            padding: 2px 5px 2px 0px;
            color: #963634;
            width: 188px;
            float: left;
        }

        .SalesTitlePerD1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: -7px 0px 0px 8px;
            padding: 2px 5px 2px 0px;
            color: #963634;
            width: 188px;
            float: left;
        }






        .SalesTitlePerC1 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 1px;
            padding: 2px 5px 2px 14px;
            color: #60497a;
            width: 188px;
            float: left;
        }


        .UnclosedJobhead {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 26px;
            padding: 2px 5px 8px 0px;
            color: #7b8d8e;
            width: 188px;
            float: left;
        }

        .PendingTblA3 {
            width: 1344px;
            float: left;
            margin: 5px 0px 0px 12px;
            /* max-height: 135px; */
            overflow: auto;
            height: 269px;
            border: 1px solid #b1b1b1;
        }

        .AirExportsLBL {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: -7px 0px 0px 17px;
            padding: 2px 5px 5px 0px;
            /*color: #16365c;*/
            width: 188px;
            float: left;
        }

        .PendingTblGrid th {
            text-align: left;
            color: #ffffff;
            font-size: 11px;
            font-family: sans-serif, Geneva, sans-serif;
            background-color: #003a65;
            padding: 5px 2px 5px 3px;
            margin: 0px;
            border-right: 1px solid #edf8ff;
            border-top: 1px solid #003a65;
        }

            .PendingTblGrid th:last-child {
                border-right: 1px solid #003a65;
            }




        .GridHead {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            margin: 0px 0px 0px 4px;
            padding: 2px 5px 5px 0px;
            color: #7b8d8e;
            width: 188px;
            float: left;
        }

        .ExcelContainer {
            width: 45px;
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .DepositeContainer {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 11px;
        }

        .ExcelContainer1 {
    margin: 0px 0px 0px 5px;
}
        .TdsHeading {
            width: 80px;
            float: left;
        }

            .TdsHeading h3 {
                color: #16365c;
                font-family: sans-serif;
                font-size: 11px;
                font-weight: bold;
                margin: -3px 0 0;
                padding: 2px 5px 2px 3px;
                width: 350px;
            }

        .widget.box .widget-content {
            background-color: #f8f9fc !important;
            display: block;
            float: left;
            left: 0;
            padding: 1px;
            position: relative;
            top: -2px;
            width: 100%;
        }

        .OAGrid th {
            background-color: #003a65;
            border-right: 1px solid #51789d;
            color: #ffffff;
            font-family: tahoma;
            font-size: 11px;
            padding: 2px 5px;
        }

        .OAGrid td {
            font-size: 11px;
            color: #4e4c4c;
        }

        .TransferCommercial h3 {
            color: #16365c;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: -3px 0 0;
            padding: 2px 5px 2px 3px;
            width: 350px;
        }

        .AdminHead h3 {
            color: #16365c;
            font-family: sans-serif;
            font-size: 11px;
            font-weight: bold;
            margin: -3px 0 0;
            padding: 2px 5px 2px 3px;
            width: 350px;
        }




        .ModeDropCNM3 {
            float: left;
            margin: 7px 0.5% 0 0;
            width: 20%;
        }

        .TitleLeft2 {
            width: 31%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .TitleLeft2 a {
                color: #fff;
                font-size: 11px;
            }

            .TitleLeft2 h3 {
                padding: 0px 0px 0px 0px;
                margin: 0px 0px 0px;
            }

        td {
            font-size: 11px;
        }



        .BlueOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 12px;
        }

            .BlueOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }


        .BlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 30px 15px;
            float: left;
            color: #4e73df !important;
        }

        .BlueRightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 5px 10px 0px 0px;
            float: right;
            text-align: right;
            width: 75%;
            font-size: 22px;
        }


        .GreenOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }


            .GreenOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .GreenText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 30px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .GreenRightSideDown {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .LiteBlueOuter {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }


            .LiteBlueOuter:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .LiteBlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #36b9cc !important;
        }

        .LtBlueRightSideDown {
            color: #36b9cc !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
        }

        .YellowOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #f6c23e !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .YellowOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .YellowText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 30px 15px;
            float: left;
            color: #f6c23e !important;
        }



        .YellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
            /*transform: rotate(-179deg);*/
        }

        .GreenOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .GreenOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .GreenText2 {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #1cc88a !important;
        }


        .GreenRightSideDown2 {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            float: right;
            font-family: 'OpenSansSemibold';
            font-size: 22px;
            width: 75%;
            text-align: right;
        }


        .BlueOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }


            .BlueOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }


        .Blue2Text {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #4e73df !important;
        }


        .Blue2RightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 0px 10px 0px 0px;
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
        }

        .RedOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #e74a3b !important;
            float: left;
            background-color: #fff;
            height: 110px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .RedOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }



        .RedText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 35px 15px;
            float: left;
            color: #e74a3b !important;
        }



        .RedRightSideDown {
            color: #e74a3b !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 22px;
            width: 75%;
            text-align: right;
        }


        .PageHeight {
            background-color: #f8f9fc !important;
        }


        .LeftSideValue {
            float: left;
            width: 60px;
            font-family: 'OpenSansRegular';
            margin: 5px 0px 0px 15px;
            font-size: 11px;
            font-weight: bold;
            color: #4e73df !important;
        }

        .RightSideValue {
            float: right;
            width: 30px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 3px 0px 0px;
            color: #4e73df !important;
        }


        .LeftNumValue {
            color: #4e73df !important;
            margin: 15px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 21px!important;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue {
            color: #4e73df !important;
            margin: 15px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 21px!important;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }


        .LeftSideValue1 {
            float: left;
            width: 60px;
            font-family: 'OpenSansRegular';
            margin: 5px 0px 0px 15px;
            font-size: 11px;
            font-weight: bold;
            color: #36b9cc !important;
        }

        .RightSideValue1 {
            float: right;
            width: 30px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 3px 0px 0px;
            color: #36b9cc !important;
        }


        .LeftNumValue1 {
            color: #36b9cc !important;
            margin: 15px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 21px!important;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue1 {
            color: #36b9cc !important;
            margin: 15px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 21px!important;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }



        .LeftSideValue2 {
            float: left;
            width: 60px;
            font-family: 'OpenSansRegular';
            margin: 5px 0px 0px 15px;
            font-size: 11px;
            font-weight: bold;
            color: #1cc88a !important;
        }

        .RightSideValue2 {
            float: right;
            width: 30px;
            font-family: 'OpenSansRegular';
            font-size: 11px;
            font-weight: bold;
            margin: 5px 3px 0px 0px;
            color: #1cc88a !important;
        }


        .LeftNumValue2 {
            color: #1cc88a !important;
            margin: 15px 0px 0px 14px;
            float: left;
            width: 30%;
            font-size: 21px!important;
            font-family: 'OpenSansSemibold';
            text-align: left;
        }

        .RightNumValue2 {
            color: #1cc88a !important;
            margin: 15px 15px 0px 0px;
            float: right;
            width: 30%;
            font-size: 21px!important;
            font-family: 'OpenSansSemibold';
            text-align: right;
        }

        form {
            /* margin: 0 5px; */
            height: 652px !important;
            overflow: hidden;
            width: 1366px;
            background-color: #f8f9fc !important;
            margin: 0px auto;
        }

        .Divimg {
            width: 13%;
            float: right;
            margin: 0px 0px 0px 0px;
        }



        .NewBlueOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 12px;
        }

            .NewBlueOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }


        .NewBlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #4e73df !important;
        }

        .NewBlueRightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 0px 10px 0px 0px;
            float: right;
            text-align: right;
            width: 75%;
            font-size: 21px;
        }


        .NewGreenOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }


            .NewGreenOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewGreenText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #1cc88a !important;
        }

        .NewGreenRightSideDown {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .NewLiteBlueOuter {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #36b9cc !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }


            .NewLiteBlueOuter:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewLiteBlueText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #36b9cc !important;
        }

        .NewLtBlueRightSideDown {
            color: #36b9cc !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .NewYellowOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #f6c23e !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewYellowOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewYellowText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #f6c23e !important;
        }



        .NewYellowRightSideDown {
            color: #f6c23e !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
            /*transform: rotate(-179deg);*/
        }

        .NewGreenOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #1cc88a !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewGreenOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }

        .NewGreenText2 {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #1cc88a !important;
        }


        .NewGreenRightSideDown2 {
            color: #1cc88a !important;
            margin: 0px 10px 0px 0px;
            float: right;
            font-family: 'OpenSansSemibold';
            font-size: 21px;
            width: 75%;
            text-align: right;
        }


        .NewBlueOuterDiv2 {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #4e73df !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }


            .NewBlueOuterDiv2:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }


        .NewBlue2Text {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #4e73df !important;
        }


        .NewBlue2RightSideDown {
            color: #4e73df !important;
            font-family: 'OpenSansSemibold';
            margin: 0px 10px 0px 0px;
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .NewRedOuterDiv {
            color: #fff;
            border-radius: 5px;
            border: 1px solid #e3e6f0;
            border-left: .25rem solid #e74a3b !important;
            float: left;
            background-color: #fff;
            height: 75px;
            padding: 15px 0px 5px 0px;
            width: 185px;
            margin: 5px 8px 0px 0px;
        }

            .NewRedOuterDiv:hover {
                box-shadow: 1px 4px 20px grey;
                -webkit-transition: box-shadow .3s ease-in;
            }



        .NewRedText {
            width: 90%;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
            margin: 0px 0px 0px 15px;
            float: left;
            color: #e74a3b !important;
        }



        .NewRedRightSideDown {
            color: #e74a3b !important;
            margin: 0px 10px 0px 0px;
            font-family: 'OpenSansSemibold';
            float: right;
            font-size: 21px;
            width: 75%;
            text-align: right;
        }

        .OPAccts h3 {
            font-weight: bold;
            font-size: 11px;
            font-family: sans-serif;
            padding: 2px 5px 5px 10px;
            color: #16365c;
            width: 350px;
            margin: -32px 0px 0px 0px;
        }

        

      
    </style>

    <script type="text/javascript">
        // Global variable to hold data
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>

    <%--TEST--%>
</head>
<body>

    <%--  <p>
        Grd_TDS</p>--%>

    <%--<script type="text/javascript">

        window.onload = function () {
            var l1 = $("#<%=hidTDS.ClientID %>").html();       
            var l2 = $("#<%=hidDeposits.ClientID %>").html();
            var l3 = $("#<%=hidunclosed.ClientID %>").html();



            var l5 = $("#<%=hidapprovalquo.ClientID %>").html();
            var l6 = $("#<%=hidapprovalInvoices.ClientID %>").html();
            var l7 = $("#<%=hidapprovalCNOp.ClientID %>").html();
            var l8 = $("#<%=hidapprovalOSDebit.ClientID %>").html();
            var l9 = $("#<%=hidapprovalOSCredit.ClientID %>").html();
            var l10 = $("#<%=hidapprovalOtherDebitNotes.ClientID %>").html();
            var l11 = $("#<%=hidapprovalOtherCreditNotes.ClientID %>").html();


            var chart = new CanvasJS.Chart("chartContainer", {
                title: {
                    text: ""
                },
                axisX: {
                    // interval: 15
                },
                dataPointWidth: 55,
                data: [{
                    type: "column",
                    indexLabelLineThickness: 2,
                    dataPoints: [

                          { x: 10, y: l1 - 0, indexLabel: "TDS" },                       
                          { x: 20, y: l2 - 0, indexLabel: "Deposits" },
                          { x: 30, y: l3 - 0, indexLabel: "UnClosed Jobs" }

                    ]
                }]
            });
            chart.render();

            var chart = new CanvasJS.Chart("chartContainer2",
            {
                title: {
                    text: ""
                },
                data: [
                {
                    type: "pie",
                    dataPoints: [
                         { y: l5 - 0, indexLabel: "Quotation" },
                      { y: l6 - 0, indexLabel: "Pro Inv" },
                        { y: l7 - 0, indexLabel: "Pro CN Opr" },
                         { y: l8 - 0, indexLabel: "Pro O/S DN" },
                         { y: l9 - 0, indexLabel: "Pro O/S CN" },
                         { y: l10 - 0, indexLabel: "Pro Other DN" },
                         { y: l11, indexLabel: "Pro Other CN" }
                    ]

                }
                ]
            });
            chart.render();
        }

    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: '../Home/OAHome.aspx/GetChartDataBooking',
                    data: '{}',
                    success:
                    function (response) {
                        drawchart(response.d);
                    },

                    error: function () {
                        alertify.alert("Error loading data! Please try again.");
                    }
                });
            })
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        })

        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            if (dataValues.length != 0) {
                for (var i = 0; i < dataValues.length; i++) {
                    data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
                }

                new google.visualization.PieChart(document.getElementById('chartdiv1')).
                draw(data, {
                    title: "Operating Profits", colors: ['#4ebcd5', '#bce3c8', '#5765b2'],});
            }
        }




    </script>





    <noscript>
        Your browser does not support JavaScript!

    </noscript>







    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <%-- <script type="text/javascript">

            function pageLoad(sender, args) {
                $(document).ready(function () {
                    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
                });
            }
            </script>--%>



        <div class="Clear"></div>
        <div class="BandMiddle">

            <div class="BreadLabel" id="OptionDoc" runat="server">Operating Accounts</div>
        </div>

        <div class="BandTop">
            <div class="BandLeft">
                <%-- <h3>
                    <img src="../Theme/assets/img/newcustomer_ic.png"/>
                    <asp:LinkButton ID="lnkNewCustomerRequest" runat="server" Style="text-decoration: none">New Customer Request</asp:LinkButton></h3>--%>
                <div class="TitleLeft2">
                    <h3>
                        <img src="../Theme/assets/img/income_ic.png">
                        <asp:LinkButton ID="lnk_changeJob" runat="server" Text="Income Not Booked" OnClick="lnk_changeJob_Click"></asp:LinkButton>
                    </h3>
                </div>
                <div class="TitleLeft2">
                    <h3>
                        <img src="../Theme/assets/img/expense_ic.png">
                        <asp:LinkButton ID="lnk_expense" runat="server" Text="Expense Not Booked" OnClick="lnk_expense_Click"></asp:LinkButton>
                    </h3>
                </div>
            </div>

            <div class="BandRight">

                <div style="float: left; margin-right: 20px;">
                    <%--<h3>
                        <img src="../Theme/assets/img/stationary.png"/><asp:LinkButton ID="lnkauo" runat="server" Text="Quotation Multiport"></asp:LinkButton></h3>--%>
                </div>
            </div>
        </div>
        <div class="HomeMenuBox">
            <asp:LinkButton ID="lnk_Tds" runat="server" OnClick="lnk_Tds_Click">
                <div class="BlueOuterDiv">
                    <div class="BlueText">
                        TDS
                    </div>

                    <span id="tds" runat="server" class="BlueRightSideDown"></span>
                </div>
            </asp:LinkButton>


            <a href="#">
                <asp:LinkButton ID="Lnk_deposit" runat="server" OnClick="Lnk_deposit_Click">
                    <div class="GreenOuterDiv">
                        <div class="GreenText">
                            Deposits
                              <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #1cc88a;"></i></div>
                        </div>
                        <div style="clear: both;"></div>
                        <span id="deposite" runat="server" class="GreenRightSideDown"></span>
                    </div>
                </asp:LinkButton>
            </a>
            <a href="#">
                <asp:LinkButton ID="lnk_cheqeRequest" runat="server">
                    <div class="LiteBlueOuter">
                        <div class="LiteBlueText">
                            Cheque Request
                        </div>
                        <label class="LeftSideValue1">CN Ops</label>
                        <label class="RightSideValue1">CN</label>
                        <div class="Clear"></div>
                        <asp:LinkButton ID="lnl_CkCnopsRq" runat="server" class="LeftNumValue1" OnClick="lnl_CkCnopsRq_Click">Cnops</asp:LinkButton>
                        <%--OnClick="lnl_CkCnopsRq_Click"--%>
                        <asp:LinkButton ID="lnk_ChCnRq" runat="server" class="RightNumValue1" OnClick="lnk_ChCnRq_Click">Cn</asp:LinkButton>
                        <%-- OnClick="lnk_ChCnRq_Click"--%>
                    </div>
                </asp:LinkButton>
            </a>


            <a href="#">
                <asp:LinkButton ID="Lnk_coll" runat="server" CssClass="AppLink" OnClick="Lnk_coll_Click">
                    <div class="YellowOuterDiv">
                        <div class="YellowText">
                            Collections 
                              <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #f6c23e;"></i></div>
                        </div>

                        <span id="spanCH" runat="server" class="YellowRightSideDown"></span>



                    </div>

                </asp:LinkButton>
            </a>

            <a href="#">
                <asp:LinkButton ID="lnk_other" runat="server">
                    <div class="GreenOuterDiv2">

                        <div class="GreenText2">Other</div>

                        <div class="Clear"></div>
                        <label class="LeftSideValue2">DN</label>
                        <label class="RightSideValue2">CN</label>
                        <div class="Clear"></div>
                        <asp:LinkButton ID="lnk_other_Dn" runat="server" class="LeftNumValue2"></asp:LinkButton>
                        <%--  OnClick="lnk_other_Dn_Click"--%>
                        <asp:LinkButton ID="lnk_other_Cn" runat="server" class="RightNumValue2"></asp:LinkButton>
                        <%--OnClick="lnk_other_Cn_Click"--%>
                    </div>
                </asp:LinkButton>
            </a>

            <asp:LinkButton ID="lnk_admine" runat="server">
                <div class="BlueOuterDiv2">
                    <div class="Blue2Text">Admin</div>
                    <div class="Clear"></div>
                    <label class="LeftSideValue">DN</label>
                    <label class="RightSideValue">CN</label>
                    <div class="Clear"></div>

                    <asp:LinkButton ID="lnk_adminDN" runat="server" CssClass="LeftNumValue aspNetDisabled"></asp:LinkButton>
                    <%-- OnClick="lnk_adminDN_Click"--%>
                    <asp:LinkButton ID="lnk_AdminCn" runat="server" CssClass="RightNumValue aspNetDisabled"></asp:LinkButton>
                    <%--OnClick="lnk_AdminCn_Click"--%>
                </div>
            </asp:LinkButton>


            <asp:LinkButton ID="Lnk_unclosed" runat="server" OnClick="Lnk_unclosed_Click">
                <div class="RedOuterDiv">
                    <div class="RedText">
                        Unclosed Jobs
                      
                    </div>
                    <div class="Clear"></div>
                    <span id="unclosed" runat="server" class="RedRightSideDown"></span>
                </div>
            </asp:LinkButton>

        </div>



        <div class="row PaDtopCtrl">
            <div class="col-md-12  maindiv">
                <!-- Tabs-->
                <div class="widget box borderremove">

                    <div class="widget-content">


                        <div id="div_bar" runat="server" class="PendingRightnewLRightNew1" visible="false">
                            <asp:Literal ID="lts" runat="server"></asp:Literal>
                            <div id="chart_divbar"></div>

                        </div>

                        <div runat="server" id="div2_Bookchart" class="PendingRightnewLRightNew" visible="false">
                            <div id="chartdiv1" style="width: 500px; height: 300px; margin-left: 20px;">
                            </div>
                        </div>

                        <div class="PendingRightChequApUnclosed" id="div_UnClos" runat="server" visible="false">
                            <div class="UnclosedJobhead">Unclosed Jobs</div>
                            <asp:Panel ID="Panel13" runat="server" Visible="false" CssClass=" panel_06" Style="margin:0px 0px 0px 25px">
                                <asp:GridView ID="grdunclosejobs" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdunclosejobs_RowDataBound" OnSelectedIndexChanged="grdunclosejobs_SelectedIndexChanged" Visible="true" OnPreRender="grdunclosejobs_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="Product" HeaderText="Product">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnClosed Jobs" HeaderText="UnClosed Jobs">
                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" Width="50px" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" Width="50px" />

                                        </asp:BoundField>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>


                        </div>

                        <div class="PendingRightnewLRightNew_Un" id="_Pend_UN" runat="server" visible="false">
                            <div style="float: right; margin-right: -2px; margin-top: 0px; margin-bottom: 3px;">
                                <asp:LinkButton ID="exp2excgrdunc" runat="server" OnClick="exp2excgrdunc_Click"> <img src="../Theme/assets/img/exportexcel_ic.png" title="Export to Excel"/></asp:LinkButton>
                            </div>

                            <div class="GridHead" id="div_unClos_new" runat="server"></div>
                            <asp:Panel ID="Panel_unc" runat="server" Visible="false" CssClass="GridN1">
                                <asp:GridView ID="grd_UNC" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" OnRowDataBound="grd_UNC_RowDataBound" ShowHeaderWhenEmpty="true" Visible="true" OnPreRender="grd_UNC_PreRender">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>



                        </div>
                        <div class="ExcelContainer1">
                            <div class="SalesTitlePerD1" id="Deposits" runat="server" visible="false">Deposits</div>
                            <div style="float: right; margin-right: 13px; margin-top: -7px; margin-bottom: -12px;">
                                <asp:LinkButton ID="exp2excGrd_Deposite" runat="server" OnClick="exp2excGrd_Deposite_Click" Visible="false"> <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" /></asp:LinkButton>
                            </div>
                        </div>
                        <div class="Clear"></div>
                        <div class="DepositeContainer" id="div_Deposite" runat="server" visible="false">

                            <div class="Clear"></div>
                            <asp:Panel ID="pnl_penDepo" runat="server" CssClass="panel_12" Visible="false">
                                <asp:GridView ID="Grd_Deposite" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%"  EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="Grd_Deposite_RowDataBound" OnPreRender="Grd_Deposite_PreRender">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Cheque#" HeaderText="Cheque #" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:BoundField DataField="Bank" HeaderText="Bank" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" />

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>




















                        <div class="PendingRightChequAppNew" id="div_CollRecpt" runat="server" visible="false">
                            <div class="SalesTitlePerC1">Collections</div>
                            <div class="Clear"></div>
                            <div style="float: right; margin-right: -1px; margin-top: -21px;">
                                <asp:LinkButton ID="exp2excgrdrecoll" runat="server" OnClick="exp2excgrdrecoll_Click"> <img src="../Theme/assets/img/exportexcel_ic.png" title="Export to Excel"/></asp:LinkButton>
                            </div>
                            <div class="Clear"></div>
                            <asp:Panel ID="pnl_RecCol" runat="server" Visible="false" CssClass="GridNC1">
                                <asp:GridView ID="grd_RecOll" CssClass="PendingTblGrid FixedHeader2" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grd_RecOll_RowDataBound" Visible="true" OnPreRender="grd_RecOll_PreRender">

                                    <Columns>
                                        <asp:BoundField DataField="Si" HeaderText="S#" />
                                        <asp:BoundField DataField="recptno" HeaderText="Recipt #" />
                                        <asp:BoundField DataField="mode" HeaderText="Mode" />
                                        <asp:BoundField DataField="customer" HeaderText="Customer" />
                                        <asp:BoundField DataField="chequeno" HeaderText="Cheque #" />
                                        <asp:BoundField DataField="amount" HeaderText="Amount" />

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>

                        <div class="PendingRightChequAppNew" id="grd_AirImports" runat="server" style="display: none;">
                        </div>


                        <div class="AirExportsLBL" id="headlbl1" runat="server" visible="false">

                            <asp:Label ID="lbl_cut" runat="server"></asp:Label>

                        </div>
                        <div id="penBlRelase" runat="server" visible="false">
                            <asp:Panel ID="Panel14" runat="server" Visible="true" CssClass="panel_12">

                                <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridView2_RowDataBound" OnPreRender="GridView2_PreRender">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>







                        <div runat="server" id="div_DnCnApp" visible="false">

                            <div class="AdminHead">
                                <h3>
                                    <asp:Label ID="lblHead" runat="server" Text=""></asp:Label></h3>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4"></div>
                                <div class="FormGroupContent4">
                                    <div class="div_Grid">
                                        <asp:GridView ID="Grd_Admin" runat="server" AutoGenerateColumns="False" CssClass="GridAdmin"
                                            Width="100%" ForeColor="Black" OnRowDataBound="Grd_Admin_RowDataBound"
                                            DataKeyNames="vouyear,vouno" ShowHeaderWhenEmpty="True" OnPreRender="Grd_Admin_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vouno" HeaderText="ProRef #" />
                                                <asp:BoundField DataField="refno" HeaderText="Ref #" />
                                                <asp:BoundField DataField="customer" HeaderText="Customer" />
                                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="preparedby" HeaderText="Prepared by" />
                                                <asp:TemplateField HeaderText="Approve">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chk_Approval" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="stamt" HeaderText="stamt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:BoundField DataField="SupplyTo" HeaderText="SupplyTo" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="Lnk_Approval" runat="server" CommandName="select" Font-Underline="false"
                        CssClass="Arrow">⇛</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <div class="right_btn">
                                        <div class="btn btn-approve1">
                                            <asp:Button ID="btn_Approve" runat="server" ToolTip="Approve" OnClick="btn_Approve_Click" />
                                        </div>
                                        <div class="btn ico-cancel" id="btn_cancel11" runat="server">
                                            <asp:Button ID="btn_cancel1" runat="server" ToolTip="Cancel" OnClick="btn_cancel1_Click" />
                                        </div>
                                    </div>


                                </div>
                            </div>

                        </div>



                        <div id="div_ChRquApp" runat="server" visible="false">
                            <div class="TransferCommercial">

                                <h3>
                                    <asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label></h3>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="ModeDropCNM3">
                                        <asp:DropDownList ID="ddl_module" runat="server" CssClass="chzn-select" Data-placeholder="Product" ToolTip="Product"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                            <asp:ListItem Value="AE">Air Exports</asp:ListItem>
                                            <asp:ListItem Value="AI">Air Imports</asp:ListItem>
                                            <asp:ListItem Value="CH">Custom House Agent</asp:ListItem>
                                            <asp:ListItem Value="FE">Ocean Exports</asp:ListItem>
                                            <asp:ListItem Value="FI">Ocean Imports</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <div class="div_GridDN">
                                        <asp:GridView ID="Grd_Approval" runat="server" AutoGenerateColumns="False" CssClass="GridDrop" Width="100%" Visible="false"
                                            ForeColor="Black" DataKeyNames="vouyear" OnSelectedIndexChanged="Grd_Approval_SelectedIndexChanged" OnRowDataBound="Grd_Approval_RowDataBound"
                                            ShowHeaderWhenEmpty="True" OnPreRender="Grd_Approval_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vouno" HeaderText="Vou #" />
                                                <asp:BoundField DataField="bjno" HeaderText="BL # / Job #" />
                                                <asp:BoundField DataField="customer" HeaderText="Customer" />
                                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="preparedby" HeaderText="Prepared by" />
                                                <asp:TemplateField HeaderText="Approve">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chk_Approval" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="billtype" HeaderText="billtype" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Lnk_Approval1" runat="server" CommandName="select" Font-Underline="false"
                                                            CssClass="Arrow">⇛</asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="stamt" HeaderText="stamt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:BoundField DataField="SupplyTo" HeaderText="SupplyTo" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:BoundField DataField="customertype" HeaderText="customertype" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:BoundField DataField="DateApp" HeaderText="DateApp" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                        <asp:GridView ID="Grid_DNCN" runat="server" AutoGenerateColumns="False" CssClass="GridDrop" Width="100%" Visible="false"
                                            ForeColor="Black" DataKeyNames="vouyear" OnSelectedIndexChanged="Grid_DNCN_SelectedIndexChanged" OnRowDataBound="Grid_DNCN_RowDataBound"
                                            ShowHeaderWhenEmpty="True" OnPreRender="Grid_DNCN_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vouno" HeaderText="Vou #" />
                                                <asp:BoundField DataField="bjno" HeaderText="BL # / Job #" />
                                                <asp:BoundField DataField="customer" HeaderText="Customer" />
                                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="preparedby" HeaderText="Prepared by" />
                                                <asp:TemplateField HeaderText="Approve">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chk_DNCN" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Lnk_Approval" runat="server" CommandName="select" Font-Underline="false"
                                                            CssClass="Arrow">⇛</asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="stamt" HeaderText="stamt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:BoundField DataField="SupplyTo" HeaderText="SupplyTo" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:BoundField DataField="customertype" HeaderText="customertype" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="right_btn MT05 MB05">
                                    <div class="btn btn-transfer1">
                                        <asp:Button ID="btn_transfer" runat="server" ToolTip="Transfer" OnClick="btn_transfer_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="btn ico-cancel" id="btn_cancelid1" runat="server">
                                        <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div runat="server" id="div_Tds" visible="false">

                            <div class="TdsHeading">
                                <h3>
                                    <asp:Label ID="Label10" runat="server" Text="TDS"></asp:Label></h3>
                            </div>

                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="ModeDropCN3" id="div_branch" runat="server" style="display: none;">
                                        <asp:Label ID="lbl_branch" runat="server" Text="Branch"></asp:Label>
                                    </div>
                                    <div class="ModeDropCN3">
                                        <asp:DropDownList ID="ddl_branch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged"
                                            CssClass="chzn-select" Data-placeholder="Branch" ToolTip="Branch" Visible="false">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="div_Grid">
                                        <asp:GridView ID="Grd_TDS" runat="server" AutoGenerateColumns="False" Width="100%"
                                            ShowHeaderWhenEmpty="True" class="OAGrid" DataKeyNames="vouyear,amount,customerid" OnRowDataBound="Grd_TDS_RowDataBound" OnPreRender="Grd_TDS_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" Width="20px" />
                                                    <HeaderStyle Wrap="false" Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vtype" HeaderText="Voucher Type">
                                                    <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Right" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vouno" HeaderText="Vou #">
                                                    <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Right" Width="80px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="voudate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="customer" HeaderText="Customer">
                                                    <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Right" Width="250px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tdstype" HeaderText="TDS Type">
                                                    <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tdsdesc" HeaderText="TDS Desc">
                                                    <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="voutype" HeaderText="voutype" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                <asp:TemplateField HeaderText="TDS %">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_TDS" runat="server" Text='<%#Eval("tdsper")%>' ToolTip='<%#Eval("tdsper")%>' Font-Size="10pt" Style="text-align: right; width: 100%; height: 15px;"
                                                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                                                    </ItemTemplate>

                                                    <ItemStyle Wrap="false" HorizontalAlign="Right" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chk_Select" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="right_btn">
                                    <div class="btn ico-update">
                                        <asp:Button ID="btn_update" runat="server" ToolTip="Update" OnClick="btn_update_Click" />
                                    </div>
                                    <div class="btn ico-cancel">
                                        <asp:Button ID="btn_Can_Cancel" runat="server" ToolTip="Cancel" OnClick="btn_Can_Cancel_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div style="float: left; width: 885px; display: none">

                            <div class="PendingBookingOA" id="div_OAold" runat="server">
                                <ul>
                                    <li>
                                        <img src="../Theme/assets/img/pending_book_ic.png" /><asp:LinkButton ID="lnk_PendingTDS" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_PendingTDS_Click">TDS</asp:LinkButton></li>

                                    <asp:Panel ID="dialog" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">TDS</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpi">
                                            <asp:Image ID="Image1" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>
                                        <asp:Panel ID="PanelTDS" runat="server"  CssClass="GridN1" Visible="false">
                                            <asp:GridView ID="GrdPendingTDS" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnPreRender="GrdPendingTDS_PreRender">
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                        <%--  </div>--%>
                                    </asp:Panel>

                                    <li style="display: none;">
                                        <img src="../Theme/assets/img/vessel_ic.png" /><asp:LinkButton ID="lnk_PendingFA" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_PendingFA_Click">FA Transfer</asp:LinkButton></li>
                                    <asp:Panel ID="Panel5" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">FA Transfer</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpi">
                                            <asp:Image ID="Image2" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>
                                        <%-- <div id="dialog1" style="display: none;">--%>
                                        <asp:Panel ID="PanelFA" runat="server"  CssClass="GridN1" Visible="false">
                                            <asp:GridView ID="GrdPendingFA" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPendingFA_RowDataBound" OnSelectedIndexChanged="GrdPendingFA_SelectedIndexChanged" Visible="false" OnPreRender="GrdPendingFA_PreRender">
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                        <%-- </div>--%>
                                    </asp:Panel>

                                    <li>
                                        <img src="../Theme/assets/img/line_ic.png" /><asp:LinkButton ID="lnk_PendingDep" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_PendingDep_Click">Deposits</asp:LinkButton></li>
                                    <asp:Panel ID="Panel6" runat="server"  CssClass="modalPopupD" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">Deposits</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpiD">
                                            <asp:Image ID="Image3" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>
                                        <%-- <div id="dialog2" style="display: none;">--%>
                                        <div class="GridpnlD1">
                                            <asp:Panel ID="PanelDep" runat="server"  CssClass="GridN1" Visible="false">
                                                <asp:GridView ID="GrdPendingDep" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPendingDep_RowDataBound" Visible="false" OnPreRender="GrdPendingDep_PreRender">

                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <%-- </div>--%>
                                    </asp:Panel>
                                    <li>
                                        <img src="../Theme/assets/img/unclosed_ic.png" />
                                        <asp:LinkButton ID="lnk_unclosedjobs" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_unclosedjobs_Click">Unclosed Jobs</asp:LinkButton>
                                    </li>
                                    <asp:Panel ID="Panel7" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">Unclosed Jobs</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpi">
                                            <asp:Image ID="Image4" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>
                                        <%-- <div id="dialog3" style="display: none;">--%>
                                        <div class="PendingTbl1">
                                            <asp:Panel ID="PanelUnclosedjob" runat="server" Visible="false" CssClass="GridN1">
                                                <asp:GridView ID="grdunclosejobs1" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdunclosejobs_RowDataBound" OnSelectedIndexChanged="grdunclosejobs_SelectedIndexChanged" Visible="false" OnPreRender="grdunclosejobs1_PreRender">
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <%--  </div>--%>
                                    </asp:Panel>
                                    <li style="list-style: none;">
                                        <img src="../images/1472042570_4.png" /><asp:LinkButton ID="lnk_PendingApproval" runat="server" ForeColor="Navy" Style="text-decoration: none; font-size: 12px;" OnClick="lnk_PendingApproval_Click" Height="17px">Pending Approval</asp:LinkButton></li>
                                    <asp:Panel ID="Panel8" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">Pending Approval</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpi">
                                            <asp:Image ID="Image5" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>
                                        <%-- <div id="dialog4" style="display: none;">--%>
                                        <div class="Gridpnl1">
                                            <asp:Panel ID="PanelApproval" runat="server"  Visible="false" CssClass="GridN2">
                                                &nbsp;<asp:GridView ID="GrdPending1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPending1_RowDataBound" OnSelectedIndexChanged="GrdPending1_SelectedIndexChanged" Visible="false" OnPreRender="GrdPending1_PreRender">
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <%--  </div>--%>
                                    </asp:Panel>
                                    <li>
                                        <img src="..//Theme/assets/img/expense-ic.png" /><asp:LinkButton ID="Linkexpense" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="Linkexpense_Click">Expense Not Booked</asp:LinkButton></li>
                                    <asp:Panel ID="Panel9" runat="server"  CssClass="modalPopupE" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">Expense Not Booked</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpiE">
                                            <asp:Image ID="Image6" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>
                                        <%--<div id="dialog6" style="display: none;">--%>
                                        <div class="PendingTbl6">
                                            <asp:Panel ID="Panel2" runat="server"  CssClass="Gridpnlex" Visible="false">
                                                <asp:GridView ID="GrdExpense" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnPreRender="GrdExpense_PreRender">
                                                    <Columns>
                                                        <asp:BoundField DataField="product" HeaderText="Product">
                                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="jobdate" HeaderText="Opened On" DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                                        </asp:BoundField>

                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <%--    </div>--%>
                                    </asp:Panel>
                                    <li>
                                        <img src="../Theme/assets/img/deposit_ic.png" />
                                        <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="LinkButton3_Click">Deposits - Bankwise</asp:LinkButton></li>
                                    <asp:Panel ID="Panel10" runat="server"  CssClass="modalPopupDep" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">Deposits - Bankwise</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpiDep">
                                            <asp:Image ID="Image7" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>

                                        <%--<div id="dialog7" style="display: none;">--%>
                                        <div class="">
                                            <asp:Panel ID="Panel3" runat="server"  CssClass="GridN1" Visible="false">
                                                <asp:GridView ID="GridDepwise" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnPreRender="GridDepwise_PreRender">

                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <%--</div>--%>
                                    </asp:Panel>
                                    <li style="list-style: none; font-size: 12px;">
                                        <img src="../Theme/assets/img/fund_ic.png" />
                                        <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="LinkButton4_Click">FundsFlow-Branch</asp:LinkButton>
                                    </li>

                                    <asp:Panel ID="Panel11" runat="server"  CssClass="modalPopupF" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="pop_head">FundsFlow-Branch</div>
                                        <%--  <div id="dialog" style="display: none;">--%>
                                        <div class="DivSecPanelkpiF">
                                            <asp:Image ID="Image8" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                        </div>
                                        <%-- <div id="dialog8" style="display: none;">--%>
                                        <div class="">
                                            <asp:Panel ID="Panel4" runat="server"  CssClass="GridN1" Visible="false">
                                                <asp:GridView ID="grd" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" CssClass="Grid FixedHeader"  OnPreRender="grd_PreRender">

                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <%--   </div>--%>
                                    </asp:Panel>
                                </ul>
                            </div>
                            <div class="Clear"></div>
                            <div class="PendingEventN3" style="display: none;">

                                <div class="PendingLeftN1">
                                    <h3>
                                        <img src="../Theme/assets/img/penidng_events_ic.png" />
                                        Job Costing</h3>
                                    <div class="PendingTbl5">
                                        <asp:Panel ID="Paneljobcostingframe" runat="server"  Style="border: 1px solid #b1b1b1;" Visible="false">
                                            <div class="FrameTitle1">
                                                <asp:Label ID="lbl1" runat="server" Text="Module"></asp:Label>
                                            </div>
                                            <div class="div_ddlOAHome">
                                                <asp:DropDownList ID="ddl_product" runat="server" AppendDataBoundItems="True" CssClass="chzn-select"
                                                    data-placeholder="Product" ToolTip="Product">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Text="Air Exports"></asp:ListItem>
                                                    <asp:ListItem Text="Air Imports"></asp:ListItem>
                                                    <asp:ListItem Text="Custom House Agent"></asp:ListItem>
                                                    <asp:ListItem Text="Ocean Exports"></asp:ListItem>
                                                    <asp:ListItem Text="Ocean Imports"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>

                                            <div class="div_txtjob">
                                                <asp:TextBox ID="txt_job" runat="server" Width="100%" CssClass="form-control" placeholder="JOB#" ToolTip="JOB NUMBER" BorderColor="#999997" />
                                            </div>

                                            <div class="right_btn MT10 MR5">
                                                <div class="btn ico-get">
                                                    <asp:Button ID="btn_Get" runat="server" ToolTip="Get" OnClick="btn_Get_Click" />
                                                </div>
                                            </div>
                                            <div class="Clear"></div>
                                            <asp:Panel ID="Paneljobcost" runat="server"  Height="125px" Visible="false">
                                                <asp:GridView ID="Gridjobcost" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="Gridjobcost_RowDataBound" OnPreRender="Gridjobcost_PreRender">
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="PendingRight">

                                    <h3>
                                        <img src="../Theme/assets/img/tols_ic.png" />


                                        <asp:LinkButton ID="LinkButton6" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="LinkButton6_Click"> Credit Approval Status</asp:LinkButton>
                                    </h3>
                                    <div class="PendingTblCredit">
                                        <asp:Panel ID="Panelcrdappr" runat="server"  Height="74px" Visible="false">
                                            <asp:GridView ID="GrdPendingcrdapp" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPendingcrdapp_RowDataBound" OnSelectedIndexChanged="GrdPendingcrdapp_SelectedIndexChanged" Visible="false" OnPreRender="GrdPendingcrdapp_PreRender">
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>




                                    <div class="PendingTblT">

                                        <h3>
                                            <img src="../Theme/assets/img/line_ic.png" />
                                            DSO Outstanding Details</h3>
                                        <table class="tblGrid4" style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbldso1" Text="Branch DSO" runat="server"></asp:Label>:</td>
                                                <td style="width: 50%; color: #ff0000; white-space: inherit;">
                                                    <asp:Label ID="lbldso" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbltotalos1" Text="Total O/S" runat="server"></asp:Label>:</td>
                                                <td style="width: 50%; color: #ff0000; white-space: inherit;">
                                                    <asp:Label ID="lbltotalos" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbloverdue1" Text="Over Due O/S" runat="server"></asp:Label>:</td>
                                                <td style="width: 50%; color: #ff0000; white-space: inherit;">
                                                    <asp:Label ID="lbloverdue" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>


                                    </div>



                                    <%--<div class="PendingTblT">

                                        <table class="tblGrid4" style="width: 100%;">
                                            <tr>
                                                <th>
                                                    <asp:Label ID="lbldso1" Text="Branch DSO" runat="server"></asp:Label>:</th>
                                                <th style="width: 50%;">
                                                    <asp:Label ID="lbltotalos1" Text="Total O/S" runat="server"></asp:Label>
                                                    </th>
                                                <th><asp:Label ID="lbloverdue1" Text="Over Due O/S" runat="server"></asp:Label></th>
                                            </tr>
                                            <tr>
                                                <td style="color: #ff0000; white-space:inherit;"><asp:Label ID="lbldso" runat="server"></asp:Label>
                                                    </td>
                                                <td style="color: #ff0000; white-space:inherit;">
                                                    <asp:Label ID="lbltotalos" runat="server"></asp:Label></td>
                                                <td style="color: #ff0000; white-space:inherit;"><asp:Label ID="lbloverdue" runat="server"></asp:Label></td>
                                            </tr>
                                          
                                        </table>


                                    </div>--%>
                                </div>



                                <div class="PendingRight">
                                    <h3>
                                        <img src="../Theme/assets/img/refresh.png" />


                                        <asp:LinkButton ID="LinkButton5" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="LinkButton5_Click"> Income Not Booked</asp:LinkButton>
                                        <%-- <asp:LinkButton ID="lnk_IncomeNotBooked" runat="server" ForeColor="Navy" Style="text-decoration: none"></asp:LinkButton>--%>
                                    </h3>
                                    <div class="PendingTbl6">
                                        <asp:Panel ID="Panel1" runat="server"  CssClass="Gridpnlex" Visible="false">
                                            <asp:GridView ID="GridView1" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnPreRender="GridView1_PreRender">
                                                <Columns>

                                                    <asp:BoundField DataField="product" HeaderText="Product">

                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" DataFormatString="{0:dd/MM/yyyy}">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                                    </asp:BoundField>

                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>



                                    <div class="Clear"></div>

                                    <div class="FormGroupContet">

                                        <div runat="server" id="signup" visible="true" style="width: 50%; margin-left: 88.3%; margin-right: 0%; margin-top: 4.2%;">
                                            <dl id="sample" class="dropdown">
                                                <dt><a href="#"><span>Export To </span></a></dt>
                                                <dd>
                                                    <ul>
                                                        <li>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="Excelfunforserver_Click">Excel</asp:LinkButton></li>
                                                        <li>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="pdffunforserver_Click">PDF</asp:LinkButton></li>
                                                    </ul>
                                                </dd>
                                            </dl>
                                        </div>


                                    </div>
                                </div>

                                <%-- <div class="bordertopNew1"></div>--%>

                                <div class="Clear"></div>


                            </div>

                            <%--<div class="BarChart">
                                <div id="chartContainer" style="height: 240px; width: 100%;"></div>
                                <div class="Clear"></div>


                            </div>--%>

                            <%--<div class="PendingEventPie">
                                <div id="chartContainer2" style="height: 240px; width: 100%;"></div>

                                <div class="Clear"></div>

                            </div>--%>
                            <div class="Clear"></div>
                            <%--   <hr />
                            chartContainer2--%>
                        </div>

                        <div class="float:right; width:195px;" style="display: none">
                            <div class="PortCountryC">



                                <div class="Unclosed">
                                    <div class="Unclosed">
                                        <h3>
                                            <img src="../Theme/assets/img/exrate_ic.png" />
                                            <%-- <span>Ex Rate</span>--%>
                                            <asp:LinkButton ID="LinkButton7" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="LinkButton7_Click">Ex Rate</asp:LinkButton>
                                        </h3>

                                        <asp:Panel ID="Panel12" runat="server"  CssClass="modalPopupEx" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                            <div class="pop_head">Ex Rate</div>
                                            <%--  <div id="dialog" style="display: none;">--%>
                                            <div class="DivSecPanelkpi">
                                                <asp:Image ID="Image9" runat="server" Width="100%" Height="100%" ImageUrl="../Theme/assets/img/close_imgic.png" />
                                            </div>
                                            <div class="PendingTbl2">
                                                <asp:Panel ID="Panelexrate" runat="server"  CssClass="Gridpnlex" Visible="false">
                                                    <asp:GridView ID="Gridexrate" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnPreRender="Gridexrate_PreRender">
                                                        <Columns>
                                                            <asp:BoundField DataField="excurr" HeaderText="Curr">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="localexrate" HeaderText="Local">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="osexrate" HeaderText="OS">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="GridHeader" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>

                                            </div>

                                        </asp:Panel>

                                    </div>




                                </div>
                                <div class="Clear"></div>



                            </div>
                        </div>

                    </div>

                </div>

            </div>
            <!--END TABS-->
        </div>
        <div class="OPAccts">
            <h3>Operating Profits</h3>
            <div style="float: right; margin-right: 9px; margin-top: -31px;">
                <asp:LinkButton ID="excportexc" runat="server" OnClick="excportexc_Click" Visible="false"> <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" /></asp:LinkButton>
            </div>
            <div class="Clear"></div>
            <a href="#">
                <asp:LinkButton ID="lnkoutstAE" runat="server" OnClick="lnkoutstAE_Click">

                    <div class="NewBlueOuterDiv">
                        <div class="NewBlueText">
                            Air Exports

                             <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #4e73df;"></i></div>
                        </div>

                        <div class="Clear"></div>
                        <span id="SPoutstAE" runat="server" class="NewBlueRightSideDown"></span>
                    </div>
                </asp:LinkButton>
            </a>


            <%--  <div class="OutStandingBox2">
                <span>9,99,99,999</span>

            </div>--%>
            <a href="#">
                <asp:LinkButton ID="lnkoutstAI" runat="server" OnClick="lnkoutstAI_Click">

                    <div class="NewGreenOuterDiv">
                        <div class="NewGreenText">
                            Air Imports

                            <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #1cc88a;"></i></div>
                        </div>

                        <div class="Clear"></div>
                        <span id="SPoutstAI" runat="server" class="NewGreenRightSideDown"></span>
                    </div>
                </asp:LinkButton>
            </a>
            <a href="#">
                <asp:LinkButton ID="lnkoutstBT" runat="server" OnClick="lnkoutstBT_Click">

                    <div class="NewLiteBlueOuter">
                        <div class="NewLiteBlueText">
                            Bonded Trucking

                             <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #36b9cc;"></i></div>
                        </div>

                        <div class="Clear"></div>
                        <span id="SPoutstBT" runat="server" class="LtBlueRightSideDown"></span>
                    </div>
                </asp:LinkButton>
            </a>
            <a href="#">
                <asp:LinkButton ID="lnkoutstCH" runat="server" OnClick="lnkoutstCH_Click">

                    <div class="NewYellowOuterDiv">
                        <div class="NewYellowText">
                            CHA
                            
                             <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #f6c23e;"></i></div>
                        </div>

                        <div class="Clear"></div>
                        <span id="SPoutstCH" runat="server" class="NewYellowRightSideDown"></span>
                    </div>
                </asp:LinkButton>
            </a>
            <a href="#">
                <asp:LinkButton ID="lnkoutstOE" runat="server" OnClick="lnkoutstOE_Click">

                    <div class="NewGreenOuterDiv2">
                        <div class="NewGreenText2">
                            Ocean Exports
                             <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #1cc88a;"></i></div>
                        </div>

                        <span id="SPoutstOE" runat="server" class="NewGreenRightSideDown2"></span>
                    </div>
                </asp:LinkButton>
            </a>
            <a href="#">
                <asp:LinkButton ID="lnkoutstOI" runat="server" OnClick="lnkoutstOI_Click">

                    <div class="NewBlueOuterDiv2">
                        <div class="NewBlue2Text">
                            Ocean Imports

                            <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #4e73df;"></i></div>
                        </div>

                        <span id="SPoutstOI" runat="server" class="NewBlue2RightSideDown"></span>
                    </div>
                </asp:LinkButton>
            </a>
            <a href="#">
                <asp:LinkButton ID="lnk_tot" runat="server" OnClick="lnk_tot_Click">

                    <div class="NewRedOuterDiv">
                        <div class="NewRedText">
                            Total
                             <div class="Divimg"><i class="fa fa-inr" style="font-size: 25px; color: #e74a3b;"></i></div>
                        </div>
                        <span id="SPoutsttot" runat="server" class="NewRedRightSideDown"></span>
                    </div>

                </asp:LinkButton>
            </a>
            <%--<div class="OutStandingBox3">
                <span>9,99,99,999</span>

            </div>
            <div class="OutStandingBox4">
                <span>9,99,99,999</span>

            </div>
            <div class="OutStandingBox5">
                <span>9,99,99,999</span>

            </div>
             <div class="OutStandingBox6">

                 <span>9,99,99,999</span>
             </div>
              <div class="OutStandingBox7">

                  <span>9,99,99,999</span>
              </div>--%>
        </div>

        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender1"
            PopupControlID="dialog" CancelControlID="Image1" TargetControlID="Label1" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label1" runat="server"></asp:Label>

        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender2"
            PopupControlID="Panel5" CancelControlID="Image2" TargetControlID="Label2" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label2" runat="server"></asp:Label>


        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender3"
            PopupControlID="Panel6" CancelControlID="Image3" TargetControlID="Label3" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label3" runat="server"></asp:Label>


        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender4"
            PopupControlID="Panel7" CancelControlID="Image4" TargetControlID="Label4" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label4" runat="server"></asp:Label>

        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender5"
            PopupControlID="Panel8" CancelControlID="Image5" TargetControlID="Label5" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label5" runat="server"></asp:Label>

        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender6"
            PopupControlID="Panel9" CancelControlID="Image6" TargetControlID="Label6" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label6" runat="server"></asp:Label>

        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender7"
            PopupControlID="Panel10" CancelControlID="Image7" TargetControlID="Label7" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label7" runat="server"></asp:Label>

        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender8"
            PopupControlID="Panel11" CancelControlID="Image8" TargetControlID="Label8" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label8" runat="server"></asp:Label>

        <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender9"
            PopupControlID="Panel12" CancelControlID="Image9" TargetControlID="Label8" DropShadow="false">
        </ajax:ModalPopupExtender>
        <asp:Label ID="Label9" runat="server"></asp:Label>



        <div style="display: none;">
            <asp:Label ID="hidTDS" runat="server" />
            <asp:Label ID="hidfa" runat="server" />
            <asp:Label ID="hidDeposits" runat="server" />
            <asp:Label ID="hiddestuff" runat="server" />
            <asp:Label ID="hidunclosed" runat="server" />
            <asp:Label ID="hidapprovalproinvoice" runat="server" />
            <asp:Label ID="hidapprovalCNOp" runat="server" />
            <asp:Label ID="hidapprovalquo" runat="server" />
            <asp:Label ID="hidapprovalInvoices" runat="server" />
            <asp:Label ID="hidapprovalProCNOp" runat="server" />
            <asp:Label ID="hidapprovalProOSdn" runat="server" />
            <asp:Label ID="hidapprovalOSDebit" runat="server" />
            <asp:Label ID="hidapprovalOScrdit" runat="server" />
            <asp:Label ID="hidapprovalProOtherDN" runat="server" />
            <asp:Label ID="hidapprovalProOtherCN" runat="server" />
            <asp:Label ID="hidapprovalOSCredit" runat="server" />
            <asp:Label ID="hidapprovalOtherDebitNotes" runat="server" />
            <asp:Label ID="hidapprovalOtherCreditNotes" runat="server" />
            <asp:Label ID="hidexpencenotbooked" runat="server" />
            <asp:Label ID="hid_Depositwise" runat="server" />
            <asp:HiddenField ID="hid_date" runat="server" />
            <asp:HiddenField ID="hid_type" runat="server" />


            <asp:HiddenField ID="hid_stamt" runat="server" />
            <asp:HiddenField ID="hid_supplyto" runat="server" />
            <asp:HiddenField ID="hid_custtype" runat="server" />



        </div>
    </form>
</body>
</html>
