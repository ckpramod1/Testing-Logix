
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormMain.aspx.cs" EnableEventValidation="false" Inherits="logix.FormMain" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css" />
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png" />
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="Theme/assets/css/system.css" rel="stylesheet" type="text/css" />

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.form-components.js"></script>
    <script type="text/javascript" src="js/helper.js"></script>

    <script>
        $(document).ready(function () {

            //company name First word capital

            let company = document.querySelector("#lblcompany");
            console.log(company.innerHTML);
            let text = company.innerHTML;
            const myArray = text.split(" ");
            console.log(myArray);

            let firstvalue = myArray[0].toUpperCase();

            myArray.shift();
            myArray.unshift(firstvalue);
            console.log(firstvalue);

            let capitalizelabel = myArray.join(" ");
            console.log(capitalizelabel);
            company.innerHTML = capitalizelabel;

            //company name First word capital

            $('.selectpicker').selectpicker();

            "use strict";

            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins

            //$('select.styled').customSelect();

        });

    </script>

                            <%-- Alertify --%>


    <!-- JavaScript -->
<script src="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js"></script>

<!-- CSS -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.min.css"/>
<!-- Default theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.min.css"/>
<!-- Semantic UI theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/semantic.min.css"/>
<!-- Bootstrap theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/bootstrap.min.css"/>

<!-- 
    RTL version
-->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.rtl.min.css"/>
<!-- Default theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.rtl.min.css"/>
<!-- Semantic UI theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/semantic.rtl.min.css"/>
<!-- Bootstrap theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/bootstrap.rtl.min.css"/>

    

    <script src="../alertifyjs/alertify.min.js"></script>
    <link href="../alertifyjs/css/themes/default.min.css" rel="stylesheet" />
    <link href="../alertifyjs/css/alertify.min.css" rel="stylesheet" />

    <!-- Demo JS -->
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>

    <style type="text/css">
        .header {
            z-index: 10030;
            /*div style restored to maintain 1366px screen size    Dhayanithi & Praveen 2023-05-18*/
            /*width: 100%;*/
            width: 1280px;
            /*margin: 0px auto;*/
                height: 64px;
        }

        form#form1 {
            width: 100% !important;
        }

        table#grd_branch {
            top: 0px;
            left: 0;
            border: 1px solid #fff !important;
        }

        .top_logo {
            /*border:1px solid RED;*/
            margin-top: 0.35%;
            /*height: 100%;*/
            height: 30px;
            width: 2.5%;
            margin-left: 2.5%;
            float: left;
            margin-right: 1%;
        }

        .navbar .navbar-nav li:last-child span {
            border: none;
        }

        .top_logo_Text {
            /*border:1px solid black;*/
            margin-top: 0%;
            height: 70px;
            /*height: 99%;*/
            width: 88.5%;
            margin-left: 0.5%;
            float: right;
        }

        .div_img {
            width: 16px;
            height: 16px;
        }

        .div_Menu {
             height: 100% !important;
               width:100%!important;;
margin-left:auto;
margin-right :auto;
        }

        .modalPopupss2 {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            /*width: 1062px;*/
            width: 100%;
            Height: 564px;
            margin-left: 0%;
            margin-top: -0.9%;
            /*padding:1px;            
            display:none;*/
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 1px solid #b1b1b1;
            margin-left: 98.3%;
            margin-top: -1.5%;
            border-radius: 90px 90px 90px 90px;
        }

        .GridpnChk {
            width: 100%;
            Height: 556px;
        }

        .frames {
            height: 100%;
            width: 100%;
        }

        .div_Menunew {
            /*background-color: White;*/
            height: 611px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 3.5%;
            width: 100% !important;
            /*display:none!important;*/
        }

        .div_Menunew1 {
            background-color: White;
            height: 580px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 4%;
            width: 100% !important;
        }

        .lnkbtncooli {
            display: block;
        }

        /*Profile Image CSS Styles Start */

        .profile_div {
            float: left;
            padding: 15px;
        }

            .profile_div img {
                -webkit-transform: scale(1);
                -webkit-transition-timing-function: ease-out;
                -webkit-transition-duration: 400ms;
                -moz-transform: scale(1);
                -moz-transition-timing-function: ease-out;
                -moz-transition-duration: 400ms;
            }

                .profile_div img:hover {
                    -webkit-transform: scale(1.1);
                    -webkit-transition-timing-function: ease-in;
                    -webkit-transition-duration: 400ms;
                    -moz-transform: scale(1.1);
                    -moz-transition-timing-function: ease-in;
                    -moz-transition-duration: 400ms; /*	transform:rotateY(180deg);*/
                }

        .user_profile_pic {
            float: left;
            margin-right: 15px;
            width: 82px;
            height: 82px;
            border-radius: 100px;
        }

        .user_profile_name {
            color: #1B5B66;
            float: left;
            font-size: 13px;
            line-height: 30px;
            margin: 0 !important;
            overflow: hidden;
            padding: 0 !important;
            text-overflow: ellipsis;
            white-space: nowrap;
            width: 245px;
        }

        .user_profile_email {
            color: #E25856;
            float: left;
            font-size: 13px;
            line-height: 22px;
            margin: 0 !important;
            overflow: hidden;
            padding: 0 !important;
            text-overflow: ellipsis;
            white-space: nowrap;
            width: 166px;
        }

        .user_profile_btn {
            padding: 5px 15px 7px;
        }

        .widget_btn_div {
            float: right;
            line-height: 33px;
            margin: 0 30px 0 0;
        }

        .group-left {
            float: left;
            margin-right: 8px;
            width: 89%;
        }

        .group-leftComp {
            float: left;
            margin-right: 8px;
            width: 100%;
        }

        .popwindow_header_txt i.icon-gear {
            margin: 3px 4px 0px 3px;
        }

        .wh_width {
            border: 1px #658db3 solid;
            width: 98%;
            margin: 0 auto;
        }

        .Chkboxaccord {
            float: right;
            line-height: normal;
            margin: 0px -7px 0 0 !important;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .MT10G {
            margin-top: 0px !important;
        }

        .MT10 {
            margin-top: 10px;
        }

        .spacewidth {
            margin: 5px 0px 5px 5px;
            width: 270px;
        }

        .colwidth {
            width: 17.5% !important;
        }

        .panel-defaultA {
            clear: both;
            border-left: 0px solid;
            border-bottom: 0px solid;
            border-top: 0px solid;
            border-right: 0px solid;
        }

        .panel-headingA {
            padding: 5px 5px 5px 10px;
            border: 1px solid #f1d375 !important;
        }

        .panel-defaultA > .panel-headingA {
            color: #333;
            background-color: #f3dd9a;
            border-color: #ddd;
        }

        .dept_icon_a {
            color: #E25856;
            font-size: 12px !important;
            font-weight: normal !important;
            margin-left: 5px;
        }

        .dept_icon_a1 {
            color: #E25856;
            font-size: 13px !important;
            font-weight: normal !important;
            margin-left: 6px;
        }

        .iconbg {
            background-color: #fff;
            border-radius: 30px;
            width: 25px;
            border: 1px solid #ec6a54;
            float: left;
            margin-right: 10px;
            height: 25px;
            padding-top: 4px;
        }

        .hide {
            display: none;
        }

        .navbar .nav > li > a {
            color: #FFFFFF;
            font-size: 13px;
            padding: 4px 12px;
            /*text-transform: uppercase;*/
            font-family: 'OpenSansSemibold';
            text-align: center;
            font-size: 14px !important;
            vertical-align: top;
            background: none;
            padding-left: 0 !important;
        }

        .LoginCompanyName {
            font-size: 11px;
            color: #ffffff;
            float: left;
            padding: 8px 0px 0px 0px !important;
            margin: 0px 0px -1px 0px;
        }

        .dropdown-menu.extended li.footer a {
            border: 1px solid #1b5b66;
            color: #1b5b66;
        }

        .btn {
            height: 27px;
            line-height: 27px;
        }

        li.profile_div span {
            color: var(--labelblack);
        }

        span#lblcname {
            color: #1b5b66 !important;
        }

        .user_profile_email {
            width: 100 %;
        }

        a#Sales {
            display: none;
        }
        i.fa.fa-power-off {
    font-size: 20px !important;
    color: #f67e09;
}
        div#branches ul.dropdown-menu.extended.notification {
    position: absolute;
    top: 28px;
}
        a#lnkbtn {
    font-weight: normal !important;
}
        a#Linkcorpor {
    font-weight: normal !important;
}
    .total {
    width: 100%;
    height: 100vh;
    margin: 0 auto;
    padding-top: 64px;
}
  input#Booking {
    border: 0px solid #8080803b !important;
    margin: 6px !important;
    padding: 0px !important;
    width: 80%;
}
    </style>

    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/FormMain.css" rel="stylesheet" />

    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <!--  <script src="ScriptsAuto/bootstrap.jquery.min.js" type ="text/javascript"></script>
    <script src="ScriptsAuto/bootstrap.min.js" type ="text/javascript"  ></script>
    <script src="ScriptsAuto/jquery-ui.min.js" type ="text/javascript"></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" /> -->

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        //function setPageHeight() {
        //    var y = screen.availHeight;
        //    var x = y - 135;
        //    var a = document.getElementById('total').style.height = x + 'px';
        //}
        //document.oncontextmenu = function () { return false };
        //window.ondragstart = function () { return false; }

        //function getiframeURL() {

        //    var source = document.getElementById('ifrmaster').contentWindow.location.href;
        //    var hdnfldVariable = document.getElementById('hdn_source');
        //    hdnfldVariable.value = source;

        //}

        $(function () {
            $(".dropdown").hover(
                function () {
                    $('.dropdown-menu', this).stop(true, true).fadeIn("fast");
                    $(this).toggleClass('open');
                    $('b', this).toggleClass("caret caret-up");
                },
                function () {
                    $('.dropdown-menu', this).stop(true, true).fadeOut("fast");
                    $(this).toggleClass('open');
                    $('b', this).toggleClass("caret caret-up");
                });
        });

    </script>
    <%--<script language="javascript" type="text/javascript">

</script> --%>

    <script type="text/javascript">

        var OSName = "Unknown OS";
        if (navigator.appVersion.indexOf("Win") != -1) OSName = "Windows";
        if (navigator.appVersion.indexOf("Mac") != -1) OSName = "MacOS";
        if (navigator.appVersion.indexOf("X11") != -1) OSName = "UNIX";
        if (navigator.appVersion.indexOf("Linux") != -1) OSName = "Linux";

        //alertify.alert("OS:"+OSName);
        window.onload = function () {
            if (OSName == "Windows") {
                if (document.cookie.indexOf("New_tab=true") == -1) {
                    document.cookie = "New_tab=true";
                    // Set the onunload function
                    window.onunload = function () {
                        document.cookie = "New_tab=true;expires=Sun, 01-Nov-1992 00:00:01 GMT";
                    };
                    // Load the application
                }

                else {
                    alertify.alert(" Security Alerts.You Are Opening Multiple Window for same Login User. This window will now close.");
                    var win = window.open("about:blank", "_self"); win.close();
                    // Notify the user
                }
            }
            else if (OSName == "MacOS") {
                var va1 = document.cookie.indexOf("New_tab=true");
                //alertify.alert("OS Index1:"+va1);
                if (va1 == -1 || va1 == 0) {
                    document.cookie = "New_tab=true";
                    // Set the onunload function
                    window.onunload = function () {
                        document.cookie = "New_tab=true;expires=Sun, 01-Nov-1992 00:00:01 GMT";
                    };
                    // Load the application
                }

                else {
                    alertify.alert(" Security Alerts.You Are Opening Multiple Window for same Login User. This window will now close.");
                    var win = window.open("about:blank", "_self"); win.close();
                    // Notify the user
                }

            }

            //function IsPopupBlocker() {
            //    var strNewURL = ""
            //    var Strfeature = "";
            //    var WindowOpen = window.open
            //    (strNewURL, "MainWindow", Strfeature);
            //    try {
            //        var obj = WindowOpen.name;
            //        WindowOpen.close();
            //    }
            //    catch (e) {
            //        alertify.alert("POPUP is blocked for this Site. Kindly allow POPUP.");
            //    }
            //}
            //IsPopupBlocker();

        };

    </script>

    <%--<script type="text/javascript">
        //applet.onload = function () {
        //    if (document.cookie.indexOf("New_tab=true") === -1) {
        //        document.cookie = "New_tab=true";
        //        // Set the onunload function
        //        applet.onunload = function () {
        //            document.cookie = "New_tab=true;expires=Sun, 01-Nov-1992 00:00:01 GMT";
        //        };
        //        // Load the application
        //    }
        //    else {
        //        alertify.alert(" Security Alerts.You Are Opening Multiple Window for same Login User. This window will now close.");
        //        var win = window.open("about:blank", "_self"); win.close();
        //        // Notify the user
        //    }
        //};
        window.onload = function () {
            if (document.cookie.indexOf("New_tab=true") === -1) {
                document.cookie = "New_tab=true";
                // Set the onunload function
                window.onunload = function () {
                    document.cookie = "New_tab=true;expires=Sun, 01-Nov-1992 00:00:01 GMT";
                };
                // Load the application
            }
            else {
                alertify.alert(" Security Alerts.You Are Opening Multiple Window for same Login User. This window will now close.");
                var win = window.open("about:blank", "_self"); win.close();
                // Notify the user
            }
        };
    </script>--%>

    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
        //javascript: window.history.forward(1);
    </script>

    <style type="text/css">
        /*body {
            background: url(Theme/assets/img/pic1.jpg) no-repeat left 50px;
        }*/
    </style>

    <style type="text/css">
        @media only screen and (max-width: 1280px) {

            body {
                background: url(Theme/assets/img/pic1.jpg) no-repeat left top;
                width: 100%;
                height: 654px;
            }

            .div_Menunew {
                height: 646px;
            }
        }



        .GridAlign td {
               border-bottom: 1px solid #e6e6e6;
    color: #2f3c4d;
    padding-left: 10px;
    /* text-transform: lowercase; */
    font-size: 14px;
    padding-top: 4px;
    padding-bottom: 0px;
        }

        .GridAlign td {
            text-transform: capitalize;
        }

            .GridAlign td:hover {
                color: #fff !important;
                background: var(--navbarcolor) !important;
            }

        /*.GridAlign td:hover {
                color: #fff;
                background: #2b4e86;
            }*/

        .navbar > .container .navbar-brand {
            min-height: 56px !important;
        }

        i.icon-sitemap {
            font-size: 15px;
            width: 24px;
            height: 24px;
            line-height: 25px;
            background: white;
            display: inline-block;
            color: var(--navbarcolor);
            border-radius: 50%;
        }

        i.icon-home {
            font-size: 24px;
            width: 24px;
            height: 24px;
            line-height: 25px;
            background: white;
            display: inline-block;
    color: #f67e09;
            border-radius: 50%;
        }

        a#lnkbtn img {
            margin: 0;
        }

        a#Linkcorpor img {
            margin: 0;
        }

        a.dropdown-toggle.user_img_top img {
            margin: 2px 0px 0px;
        }

        header.header.navbar.navbar-fixed-top {
            min-height: 50px;
            height: 50px;
        }


        img#img_Logo {
            width: auto;
            height: 44px;
            position: relative;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .companyLogo {
            width: auto;
            height: 50px;
            position: relative;
            left: 0;
            float: left;
        }

        li.dropdown.user span {
            top: 8px !important;
        }

        .navbar-nav > li > a {
            line-height: 24px;
        }

        .ico-find-sm {
    background: url("../Theme/assets/img/buttonIcon/active/find-sm.png") no-repeat center !important;
}
.booking {
    width: 127%;
    float: left;
    margin-top: 11px;
    border: 1px solid #8080803b !important;
    height: 30px !important;
    border-radius: 30px !important;
}
a#linkBooking {
    margin-right: 20px;
    position: relative;
    left: 16px;
    top: -4px;
    border: none;
}
.nav.navbar-nav.navbar-right {
    padding-top: 7px;
}

.anc {
    display: inline-block;
    text-align: center;
    left: 0px;
    float: left;
    padding: 1px;
    height: 22px;
    width: 22px;
    border-radius: 4px !important;
    border: 0.5px solid #ebd3c1;
    margin-top: 16px;
}
a#CHA {
    display: none;
}
    </style>
</head>

<body>

    <form id="form1" runat="server">
        <%--div style restored to maintain 1366px screen size    Dhayanithi & Praveen 2023-05-18--%>
        
        <div>

            <!-- Header -->
            <header class=" navbar navbar-fixed-top" role="banner">
                <div class="header">
                <!-- Top Navigation Bar -->

                <div class="container">
                    <!-- Only visible on smartphones, menu toggle -->
                    <!-- Logo -->
                    <!-- /Logo -->

                    <!-- Sidebar Toggler -->
                    <!-- <a href="#" class="toggle-sidebar bs-tooltip" data-placement="bottom" data-original-title="Toggle navigation"><i class="icon-reorder"></i></a> -->
                    <!-- /Sidebar Toggler -->

                    <!-- Top Left Menu -->
                    <div class="LoginCompanyName">
                        <a class="navbar-brand" href="#">
                            <div class="companyLogo">
                                <asp:Image ID="img_Logo" runat="server" ImageUrl="~/images/companylogo.png" />
                            </div>
                            <asp:Label ID="lblcompany" runat="server" Style="text-transform: capitalize;"></asp:Label>
                            
                        </a>
                    </div>
                    <!-- /Top Left Menu -->

                    <ul class="nav navbar-nav navbar-left custom-ml-3">
                        <li>
                            <asp:LinkButton ID="lnkhome" runat="server" OnClick="lnkhome_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none;" ToolTip="Home">
                            <%--<img src="Theme/assets/icon/home_ic.png" />--%>
                            <i class="icon-home"></i>
                            </asp:LinkButton>
                        </li>
                    </ul>

                    <!-- Top Right Menu -->
                    <ul class="nav navbar-nav navbar-left">
                        <!-- Temp Manoj for Appraisal -->

                        <li>
                            <asp:LinkButton ID="lnkcomrev" runat="server" OnClick="lnkcomrev_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; padding: 13px 10px 10px 10px!important;"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkreviewer" runat="server" OnClick="lnkreviewer_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; padding: 13px 10px 10px 10px!important;"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkbtnapp" runat="server" OnClick="lnkbtnapp_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; padding: 13px 10px 10px 10px!important;"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkbtnpendemp" runat="server" OnClick="lnkbtnpendemp_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; padding: 13px 10px 10px 10px!important;"></asp:LinkButton></li>
                        <li id="lbl" runat="server">
                            <asp:LinkButton ID="lnkbtncoo" runat="server" OnClick="lnkbtncoo_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; padding: 13px 10px 10px 10px!important;"></asp:LinkButton></li>

                        <%--BRANCH DROPDOWN--%>
                        <li class="dropdown user">
                            <asp:LinkButton ID="lnkbranch" runat="server" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; " Enabled="false">
                                <%--OnClick="lnkbranch_Click"--%>
                                <%--<i class="icon-sitemap"></i>--%>
                                <span>
                                    <asp:Label ID="brname" runat="server"></asp:Label>
                                </span>
                                <%--<img src="Theme/assets/icon/branch_ic.png" />--%>
                            </asp:LinkButton>
                            <div id="branches" runat="server">
                                <ul class="dropdown-menu extended notification">
                                    <asp:GridView ID="grd_branch" runat="server" Width="100%" CssClass="GridAlign" AutoGenerateColumns="false"
                                        OnRowDataBound="grd_branch_RowDataBound" OnSelectedIndexChanged="grd_branch_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="branchName" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField DataField="branchID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                        </Columns>
                                    </asp:GridView>

                                    <%-- <li style="text-transform:capitalize!important;"><a id="B1" runat="server" href="#"><asp:LinkButton ID="AHB1" runat="server"  OnClick="AHB1_Click" ></asp:LinkButton></a></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="BAB1" runat="server" OnClick="BAB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;" ><asp:LinkButton ID="CALB1" runat="server" OnClick="CALB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="CHEB1" runat="server" OnClick="CHEB1_Click"></asp:LinkButton></li>--%>
                                    <%--  <li style="text-transform:capitalize!important;"><asp:LinkButton ID="COCB1" runat="server" OnClick="COCB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="COIB1" runat="server" OnClick="COIB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="CORB1" runat="server" OnClick="CORB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="HYDB1" runat="server" OnClick="HYDB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="LUDB1" runat="server" OnClick="LUDB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="MUMB1" runat="server" OnClick="MUMB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="NEWB1" runat="server" OnClick="NEWB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="TUTB1" runat="server" OnClick="TUTB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="TIRB1" runat="server" OnClick="TIRB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="TUTB1" runat="server" OnClick="TUTB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="VISB1" runat="server" OnClick="VISB1_Click"></asp:LinkButton></li>--%>
                                    <%-- <li style="text-transform:capitalize!important;"><asp:LinkButton ID="WARB1" runat="server" OnClick="WARB1_Click"></asp:LinkButton></li>--%>
                                </ul>
                            </div>
                        </li>

                        <%--PROCESS DROPDOWN - [FOR BRANCHES] --%>
                        <li class="dropdown user">
                            <asp:LinkButton ID="lnkbtn" runat="server"  Enabled="false"  OnClick="lnkbtn_Click1" Style="text-transform: capitalize; border-right: 1.5px solid #f8a350; color: #06529c; text-decoration: none; padding: 0px 8px 0px 0px !important;">
								<%--<img src="Theme/assets/icon/Process.png" />--%>
							    <%-- <span> <asp:Label ID="productname" runat="server"></asp:Label></span>--%>
                            
                            </asp:LinkButton>
                            <div id="ProcessBranch" runat="server">
                                <ul class="dropdown-menu extended notification">
                                    <li>
                                        <asp:LinkButton ID="AEOpsDocsHome" runat="server" OnClick="AEOpsDocsHome_Click">Air Exports</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="AIOpsDocsHome" runat="server" OnClick="AIOpsDocsHome_Click">Air Imports</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="FAHome" runat="server" OnClick="FAHome_Click">
                                            Financial Accounts 
                                        <asp:DropDownList ID="ddl_FAYear" runat="server" Width="67px" Style="margin-left: 5px" dataplaceholder="Financial Year" TabIndex="2"
                                             AutoPostBack="true" OnSelectedIndexChanged="ddl_FAYear_SelectedIndexChanged" CssClass="chzn-select">
                                            <asp:ListItem Value="0">Financial Year</asp:ListItem>
                                        </asp:DropDownList>
                                        </asp:LinkButton>
                                        <span style="display: inline-block; float: right; margin: 0px 10px 0px 10px; width: 100px; position: absolute; right: 5px; top: 183px;"></span></li>
                                    <li>
                                        <asp:LinkButton ID="br_Mainten" runat="server" OnClick="br_Mainten_Click" style="display:none">Maintenance</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="MISHome" runat="server" OnClick="MISHome_Click">MIS & Analytics</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="OEOpsDocsHome" runat="server" OnClick="OEOpsDocsHome_Click">Ocean Exports</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="OIOpsDocsHome" runat="server" OnClick="OIOpsDocsHome_Click">Ocean Imports</asp:LinkButton></li>
                                    <li><a id="Sales" runat="server" href="#">
                                        <asp:LinkButton ID="SalesHome" runat="server" OnClick="SalesHome_Click">Sales</asp:LinkButton></a></li>


                                    <%--Vino Newly added for CHA St [14-04-2024]--%>
                                    <li><a id="CHA" runat="server" href="#">
                                         <asp:LinkButton ID="CHAHome" runat="server" OnClick="CHAHome_Click">CHA</asp:LinkButton></a></li>
                                    <%--Vino Newly added for CHA End [14-04-2024]--%>



                                    <%-- <li><asp:LinkButton ID="AECSHome" runat="server" OnClick="AECSHome_Click">Air Export - Customer Support</asp:LinkButton></li>
	                                     <li><asp:LinkButton ID="AICSHome" runat="server"  OnClick="AICSHome_Click">Air Import - Customer Support</asp:LinkButton></li>--%>

                                    <%-- <li><asp:LinkButton ID="BondedTruckingHome" runat="server" OnClick="BondedTruckingHome_Click">Bonded Trucking</asp:LinkButton></li>--%>
                                    <%-- <li><asp:LinkButton ID="CHAHome" runat="server"  OnClick="CHAHome_Click">CHA</asp:LinkButton></li>--%>
                                    <%-- <li><asp:LinkButton ID="CRM" runat="server" OnClick="CRM_Click">CRM</asp:LinkButton></li> Yuv--%>
                                    <%-- yuvaraj 30/09/2022--%>

                                    <%--End--%>

                                    <%-- <li><asp:LinkButton ID="OECSHome" runat="server" OnClick="OECSHome_Click">Ocean Export - Customer Support</asp:LinkButton></li>--%>
                                    <%-- <li><asp:LinkButton ID="OICSHome" runat="server" OnClick="OICSHome_Click">Ocean Import - Customer Support</asp:LinkButton></li>   --%>
                                    <%-- <li><asp:LinkButton ID="OAHome" runat="server"  OnClick="OAHome_Click">Operating Accounts</asp:LinkButton></li> yu--%>
                                </ul>

                            </div>
                        </li>

                        <%--PROCESS DROPDOWN - [FOR CORPORATE] --%>
                        <li class="dropdown user">
                            <asp:LinkButton ID="Linkcorpor" runat="server"  Enabled="false" OnClick="Linkcorpor_Click" Style="text-transform: capitalize; border-right: 1.5px solid #f8a350; color: #06529c; text-decoration: none;" ToolTip="Process">
								<%-- <img src="Theme/assets/icon/Process.png"/> --%>
							    <%-- <span> <asp:Label ID="corpproductname" runat="server"></asp:Label> </span>--%>
                            </asp:LinkButton>
                            <div id="ProcessCorporate" runat="server">
                                <ul class="dropdown-menu extended notification">

                                    <%--  <li><a id="A1" runat="server" href="#">
	                                <asp:LinkButton ID="AccountsFinance" runat="server"  OnClick="AccountsFinance_Click" >Accounts and Finance</asp:LinkButton></a></li>--%>
                                    <li style="display: none">
                                        <asp:LinkButton ID="Budget" runat="server" OnClick="Budget_Click">Budget</asp:LinkButton></li>
                                    <li style="display: none">
                                        <asp:LinkButton ID="CreditControl" runat="server" OnClick="CreditControl_Click">Credit Control</asp:LinkButton></li>
                                    <li style="display: none">
                                        <asp:LinkButton ID="CRMCO" runat="server" OnClick="CRMCO_Click">CRM</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="FCAC" runat="server" OnClick="FCAC_Click">Financial Accounts</asp:LinkButton>
                                        <span style="display: inline-block; float: right; margin: -3px 10px 0px 0px; width: 67px; position: absolute; right: -2px; top: 118px;">
                                            <asp:DropDownList ID="ddl_FCYear" runat="server" Width="100%" dataplaceholder="Financial Year" TabIndex="2" CssClass="chzn-select">
                                                <asp:ListItem Value="0">Financial Year</asp:ListItem>
                                            </asp:DropDownList></span>
                                    </li>
                                    <%--<li><asp:LinkButton ID="HRM" runat="server" OnClick="HRM_Click" >Human Resources</asp:LinkButton></li>--%>
                                    <li>
                                        <asp:LinkButton ID="Maintenance" runat="server" OnClick="Maintenance_Click">Maintenance</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="MISandAnalysis" runat="server" OnClick="MISandAnalysis_Click">MIS and Analysis</asp:LinkButton></li>
                                    <li style="display: none">
                                        <asp:LinkButton ID="Utility" runat="server" OnClick="Utility_Click">Utility</asp:LinkButton></li>
                                                                    <li>
<asp:LinkButton ID="Tasks" runat="server" OnClick="Tasks_Click">Task Managment</asp:LinkButton></li>

                                </ul>
                            </div>
                        </li>

                        <%--  <li><a href="#" >HOME</a></li>--%>
                        <!-- Project Switcher Button -->
                        <!--<li class="dropdown"><a href="#" class="project-switcher-btn dropdown-toggle"><i class="icon-arrow-down"></i></a></li>-->
                        <!-- User Login Dropdown -->


                        <%-- USER PROFILE DISPLAY POP-UP --%>
                        <li class="dropdown user">
                            <a href="#" data-toggle="dropdown" style="margin-left: 4px;pointer-events:none;">  <%-- "pointer-events" style added to remove the cursor pointer praveen 5june2023--%>
                                <span>
                                    <asp:Label ID="empname" runat="server"></asp:Label></span>
                                <asp:Image ID="img_emp" CssClass="hide" runat="server" Width="32" Height="32" data-toggle="dropdown" ImageUrl="~/images/CImage.png" />
                            </a>

                            <ul class="dropdown-menu extended notification hide"> <%--hide - class added to remove the hover element praveen 5june2023--%>
                                <li class="profile_div">
                                    <asp:Image ID="img_emp1" runat="server" CssClass="user_profile_pic" data-toggle="dropdown" ImageUrl="~/images/CImage.png" />
                                    <div class="user_profile_name">
                                        <asp:Label ID="lblcname" runat="server" Style="text-transform: capitalize;"></asp:Label>
                                    </div>
                                    <div class="user_profile_name">
                                        <asp:Label ID="lbldesg" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label>
                                    </div>
                                    <div class="user_profile_name">
                                        <asp:Label ID="lbldept" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label>
                                    </div>
                                    <div class="user_profile_name">
                                        <asp:Label ID="lblport" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label>
                                    </div>
                                    <div class="user_profile_email">
                                        <asp:Label ID="Label1" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label>
                                    </div>
                                </li>
                                <li class="footer">
                                    <div class="floatl user_profile_btn">
                                        <%-- <button class="btn btn-xs btn-primary" onclick="window.location='EmployeeBenefits.aspx'">View Profile</button>--%>
                                        <%-- <button class="btn btn-xs btn-primary" id="btnview" runat="server" onclick="window.location='EmployeeBenefits.aspx'">View Profile</button>--%>
                                        <%-- <asp:LinkButton role="menuitem"  ID="viewlinkbutton"  CssClass="btn btn-xs btn-primary" OnClick="viewlinkbutton_Click" runat="server" Visible="false"  >View Profile</asp:LinkButton>--%>
                                        <asp:LinkButton role="menuitem" ID="viewlinkbutton" CssClass="btn btn-xs btn-primary" OnClick="viewlinkbutton_Click" runat="server">Change Password</asp:LinkButton>
                                    </div>
                                    <div class="floatr user_profile_btn">
                                        <%--<asp:LinkButton role="menuitem" ID="LinkButton2" CssClass="btn btn-xs btn-default" OnClick="LinkButton1_Click" runat="server">Sign Out</asp:LinkButton>--%>
                                    </div>
                                </li>
                            </ul> 
                        </li>
                        <%-- /USER PROFILE DISPLAY POP-UP --%>


                        <li class="dropdown user">
                            <asp:LinkButton role="menuitem" ID="LinkButton2" CssClass="btn btn-xs btn-default"  OnClick="LinkButton1_Click" runat="server"><i class="fa fa-power-off"  ></i></asp:LinkButton>
                        </li>

                      <%--   
                       <div>
                            <asp:TextBox ID="Booking" runat="server" ToolTip="" PlaceHolder="" CssClass="form-control"  Visible="false"></asp:TextBox>
                       </div>

                        <div>
                            <asp:LinkButton ID="linkBooking" CssClass="anc ico-find-sm" runat="server" Visible="false" OnClick="linkBooking_Click" OnClientClick="redirectToFEBL();"></asp:LinkButton>
                        </div>--%>

                        <!-- /user login dropdown -->
                    </ul>
                    <!-- /Top Right Menu -->
                     <div class="nav navbar-nav navbar-right">
     <li>
         <div class="booking"  id="Booking_div" runat="server" Visible="false" >
         <asp:TextBox ID="Booking" runat="server" ToolTip="" AutoPostBack="false" PlaceHolder="HBL # / HAWB #  " CssClass="" Visible="false"></asp:TextBox>

         </div>
         <div class="hide">
         <asp:Label ID="BL_Booking" runat="server" Text="" Visible="false"></asp:Label>

         </div>
         <li>
             <li>
         <asp:LinkButton ID="linkBooking" CssClass="anc ico-find-sm" runat="server" Visible="false" OnClick="linkBooking_Click" OnClientClick="redirectToFEBL();"></asp:LinkButton>

             </li>
 </div>
                </div>
                <!-- /top navigation bar -->

                <!--=== Project Switcher ===-->
                <div id="project-switcher" class="container project-switcher">
                    <div id="scrollbar">
                        <div class="handle"></div>
                    </div>
                    <div id="frame">
                        <ul class="project-list">
                            <li class="current"><a href="javascript:void(0);"><span class="image"><i class="icon-envelope"></i></span><span class="title">Email</span> </a></li>
                            <li><a href="javascript:void(0);"><span class="image"><i class="icon-comments-alt"></i></span><span class="title">Message</span> </a></li>
                        </ul>
                    </div>
                    <!-- /#frame -->
                </div>
                <!-- /#project-switcher -->
                    </div>
            </header>
            <!-- /header -->
















































































            <div class="total" id="total">

                <!--  <div class ="top_align" id="top_div">
                        <div class="top_align_Main">
                      
                        <div class="top_Home"> </div>
                        <div class="top_ClogoNew"> <asp:ImageButton ID="imgRequest" runat="server" Height="70%" Width="70%" style ="background-size:cover;"  ImageUrl="~/images/fbnxet.png"   onmouseover="this.src='images/fbfist.png'" OnMouseOut="this.src='images/fbnxet.png'" OnClick="imgRequest_Click" ToolTip="Company Profile"/>
                        <%--<div class="top_ClogoNew"> <asp:ImageButton ID="img_profile" runat="server" Height="70%" Width="70%" style ="background-size:cover;" ToolTip="Company Profile" OnClick="img_profile_Click"  ImageUrl="~/images/companyProfileMain.jpg" onmouseover="this.src='images/companyProfileMain.jpg'" OnMouseOut="this.src='images/companyProfileMain.jpg'" /></div>--%>       
                        </div>
                        <div class="top_ClogoMsg"> <asp:ImageButton ID="imgmsg" runat="server" Height="70%" Width="70%" style ="background-size:cover;" onmouseover="this.src='images/msgw.png'" OnMouseOut="this.src='images/msg12.png'" ImageUrl="~/images/msg12.png" /></div>
                        <%-- <div  id="divNew" runat="server" visible="false">   
                        <asp:ImageButton ID="imgreqNext" runat="server" Height="75%" Width="75%" style ="background-size:cover;"  ImageUrl="~/images/FbNext.jpg" Visible="false" OnClick="imgreqNext_Click"  />          
                        </div> --%> 
                        <div class ="top_arrow">
                        <div class="dropdown" style ="margin-top :-1.3%; float :left; background-color :#3b5998;border : #3b5998;">
                        <button class="btn btn-default dropdown-toggle" type="button" id="menu1" data-toggle="dropdown" style ="background-color :#3b5998; border :#3b5998; font-size :55px; margin-right :-20%; ">
                        <span class="caret"></span></button>

                        <ul class="dropdown-menu dropdown-menu-right" role="menu" aria-labelledby="menu1">
                        <li role="presentation" class="dropdown-header"><asp:Label ID="lblname" runat="server" CssClass ="LabelValue"  style =" text-transform: capitalize;" ></asp:Label></li>
          
                        <li role="presentation"><asp:LinkButton role="menuitem"  ID="LinkButton1"  style="text-align :left; color :darkblue; font-size:9pt;  font-family:Arial; text-decoration :none; "  OnClick ="LinkButton1_Click" runat="server" >Sign Out</asp:LinkButton></li>
                        </ul>
                        </div>

                        </div>        
       
                        <%--     <div> <br class="ClearFloat"/></div>--%>
                        </div>
                        </div> -->

                <iframe id="ifrmaster" name="centerfrm" class="div_Menu" frameborder="0" src="" scrolling="no" runat="server"></iframe>

                

                <div class="FormGroupContent">
                    <asp:Panel ID="pln_cheque" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="DivSecPanel">
                            <asp:Image ID="Close_Cheque" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                        </div>
                        <div class="div_Break">
                        </div>
                        <div class="GridpnChk">
                            <iframe id="iframeprofile" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF"></iframe>
                        </div>
                    </asp:Panel>
                </div>
                <asp:ModalPopupExtender runat="server" ID="popup_cheque"
                    PopupControlID="pln_cheque" CancelControlID="Close_Cheque" TargetControlID="Label2" DropShadow="false">
                </asp:ModalPopupExtender>

                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:HiddenField ID="hdn_pwd" runat="server" />
                <asp:HiddenField ID="hf_division" runat="server" />
                <asp:HiddenField ID="hf_branch" runat="server" />
                <asp:HiddenField ID="hdnframeid" runat="server" />
                <asp:HiddenField ID="hid_AHB1" runat="server" />
                <asp:HiddenField ID="hid_BAB1" runat="server" />
                <asp:HiddenField ID="hid_CALB1" runat="server" />
                <asp:HiddenField ID="hid_CHEB1" runat="server" />
                <asp:HiddenField ID="hid_COCB1" runat="server" />
                <asp:HiddenField ID="hid_COIB1" runat="server" />
                <asp:HiddenField ID="hid_CORB1" runat="server" />
                <asp:HiddenField ID="hid_LUDB1" runat="server" />
                <asp:HiddenField ID="hid_HYDB1" runat="server" />
                <asp:HiddenField ID="hid_MUMB1" runat="server" />
                <asp:HiddenField ID="hid_NEWB1" runat="server" />
                <asp:HiddenField ID="hid_TIRB1" runat="server" />
                <asp:HiddenField ID="hid_TUTB1" runat="server" />
                <asp:HiddenField ID="hid_VISB1" runat="server" />
                <asp:HiddenField ID="hid_WARB1" runat="server" />
            </div>
        </div>
            

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    </form>

    
</body>
</html>
