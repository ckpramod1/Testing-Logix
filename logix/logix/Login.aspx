<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="logix.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>logix+ </title>
    <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <!-- Theme -->
    <link href="Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/systemtouchlogin.css" rel="stylesheet" type="text/css" />
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <!-- Login -->


    <script type="text/javascript">
        /// <reference path="helper.js" />
        function GenerateLabelAfter() {

            $("input[type='text'],textarea").each(function () {
                btnSignin
                if ($(".chzn-search input")) {
                    $(".chzn-search input").attr("placeholder", "");
                }
            });

            $("input[type='text'],input[type='password'],textarea").each(function () {

                if ($(this).attr("placeholder")) {
                    var placeholder = $(this).attr("placeholder");
                    $(this).after("<span>" + placeholder + "</span>");
                    $(this).removeAttr("placeholder");
                }
                //new 22_Dec_2022 Start
                else if ($(this).attr("title")) {
                    var tooltip = $(this).attr("title");
                    $(this).after("<span>" + tooltip + "</span>");
                }
                //new 22_Dec_2022 End
            });

            $(".chzn-select").each(function () {
                if ($(this).attr("placeholder")) {
                    var placeholder = $(this).attr("placeholder");
                    $(this).before("<span>" + placeholder + "</span>");
                    $(this).removeAttr("placeholder");
                } else if ($(this).attr("data-placeholder")) {
                    var dataplaceholder = $(this).attr("data-placeholder");
                    $(this).before("<span>" + dataplaceholder + "</span>");
                    //newLine
                    $(this).attr("data-placeholder", " ");
                    //newLine
                } else if ($(this).attr("title")) {
                    var tooltip = $(this).attr("title");
                    $(this).before("<span>" + tooltip + "</span>");
                }
            });

            $("input[type = 'submit'],input[type = 'button']").each(function () {
                if ($(this).attr("value")) {
                    var value = $(this).attr("value");
                    $(this).attr("title", value);
                }
                if ($(this).attr("title") === "Save") {
                    $(this).parent().attr("class", "btn ico-save");
                }
                if ($(this).attr("title") === "Update") {
                    $(this).parent().attr("class", "btn btn-update1");
                }
            });

            //$(".chzn-select").chosen();
            //$(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            $("input[type='text'],textarea,select").attr("title", " ");

            $("select").each(function () {

                $(this).parent().addClass("TextField");

                $(this).parent().css({ position: "relative" });
                $(this).parent().children("span").css({
                    position: "absolute",
                    top: "14px",
                    zIndex: 1,
                    left: "5px",
                    fontSize: "9px",
                    background: "white",
                    padding: "0px 5px",
                    marginLeft: 0,
                    color: "#06529c",
                });
            });

            $("input[type='text'],input[type='password'],textarea").each(function () {

                $(this).parent().addClass("TextField");

                if ($(this).val()) {
                    $(this).parent().children("span:last-child").css({

                        top: "10px",
                        left: "0px",
                        fontSize: "9px",

                        fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                        position: "absolute",
                        backgroundColor: "white",
                        padding: " 4px 0.3rem 0",
                        //margin: "4.4px 0.5rem 0px",
                        margin: "1px 4px 0px",
                        width: "90%",
                        transformOrigin: "left top",
                        pointerEvents: "none",
                        color: "#06529c",
                    });
                }
                else if ($(this).val() == "") {
                    $(this).parent().children("span:last-child").css({
                        color: "#06529c",
                        top: "10px",
                        left: "0px",
                        fontSize: "9px",

                        fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                        position: "absolute",
                        backgroundColor: "white",
                        padding: " 4px 0.3rem 0",
                        //margin: "4.4px 0.5rem 0px",
                        margin: "1px 4px 0px",
                        width: "90%",

                        pointerEvents: "none",
                    });
                }

                $(this).focusin(function () {

                    $(this).parent().children("span:last-child").css({
                        color: "#06529c",
                        top: "10px",
                        left: "0px",
                        fontSize: "9px",

                        fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                        position: "absolute",
                        backgroundColor: "white",
                        padding: " 4px 0.3rem 0",
                        //margin: "4.4px 0.5rem 0px",
                        margin: "1px 4px 0px",

                        width: "90%",

                        transformOrigin: "left top",
                        pointerEvents: "none",
                    });

                });

                $(this).focusout(function () {

                    if ($(this).val()) {
                        $(this).parent().children("span:last-child").css({

                            top: "10px",
                            left: "0px",
                            fontSize: "9px",

                            fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                            position: "absolute",
                            backgroundColor: "white",
                            padding: " 4px 0.3rem 0",
                            //margin: "4.4px 0.5rem 0px",
                            margin: "1px 4px 0px",

                            width: "90%",

                            transformOrigin: "left top",
                            pointerEvents: "none",
                            color: "#06529c",

                        });
                    } else if ($(this).val() == "") {
                        $(this).parent().children("span:last-child").css({

                            top: "10px",
                            left: "0px",
                            fontSize: "9px",

                            fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                            position: "absolute",
                            backgroundColor: "white",
                            padding: " 4px 0.3rem 0",
                            //margin: "4.4px 0.5rem 0px",
                            margin: "1px 4px 0px",
                            width: "90%",
                            transformOrigin: "left top",
                            pointerEvents: "none",
                            color: "#06529c",
                        });
                    }

                });
            });

            $("input[type = 'submit'],input[type = 'button']").each(function () {
                if ($(this).attr("value")) {
                    var value = $(this).attr("value");
                    $(this).attr("title", value);
                }
                if ($(this).attr("title") === "Save") {
                    $(this).parent().attr("class", "btn ico-save");
                }
                if ($(this).attr("title") === "Update") {
                    $(this).parent().attr("class", "btn btn-update1");
                }
            });

            //new`

            //.css({ color: "#5e67e4" });
            $(".chzn-select").each(function () {
                $(this).attr("data-placeholder", " ")
            });

            //New 21_Nov_2022
            let crumbs = $(".crumbs").html();
            $(".widget-header h4").after("<div class=crumbs>" + crumbs + "</div>");
            $(".crumbs").hide();
            $(".widget-header .crumbs").show();

            //New 23_Dec_2022
            $("table").attr("class", "Grid FixedHeader");
            $("table table").attr("class", " ");
            $("fieldset table").attr("class", " ");

            //New 27_Dec_2022
            $(".modalPopupss").each(function () {
                if ($(this).children().hasClass("divRoated")) {
                    console.log($(this).children().attr("class"));
                } else {
                    $(this).children().wrapAll("<div class='divRoated'>");
                }
            });

            //New 30_Dec_2022

            //New 10 Jan 2022
            $("tr").each(function () {
                // right align any numeric columns
                $(this)
                    .children("td:gt(0)")
                    .filter(function () {
                        return this.innerHTML.match(/^[0-9\s\.,]+$/);
                    })
                    .css("text-align", "right");

                // right align any date columns in ddmmmyyyy format

                // $(this)
                //   .children("td:gt(0)")
                //   .filter(function () {
                //     return this.innerHTML.match(/\d{1,2}\w{3}\d{2,4}/);
                //   })
                //   .css("text-align", "right");

            });
        }

    </script>


    <%-- Alertify --%>


    <!-- JavaScript -->
    <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js"></script>

    <!-- CSS -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.min.css" />
    <!-- Default theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.min.css" />
    <!-- Semantic UI theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/semantic.min.css" />
    <!-- Bootstrap theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/bootstrap.min.css" />

    <!-- 
    RTL version
-->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.rtl.min.css" />
    <!-- Default theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.rtl.min.css" />
    <!-- Semantic UI theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/semantic.rtl.min.css" />
    <!-- Bootstrap theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/bootstrap.rtl.min.css" />



    <script src="../alertifyjs/alertify.min.js"></script>
    <link href="../alertifyjs/css/themes/default.min.css" rel="stylesheet" />
    <link href="../alertifyjs/css/alertify.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <!--[if IE 7]>
		<link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome-ie7.min.css">
	<![endif]-->
    <!--[if IE 8]>
		<link href="Theme/assets/css/ie8.css" rel="stylesheet" type="text/css" />
	<![endif]-->
    <!--<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700' rel='stylesheet' type='text/css'>-->
    <!--=== JavaScript ===-->
    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/lodash.compat.min.js"></script>
    <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
		<script src="Theme/Content/assets/js/libs/html5shiv.js"></script>
	<![endif]-->
    <!-- App -->
    <script type="text/javascript" src="Theme/Content/assets/js/login.js"></script>
    <script src="ScriptsAuto/Focus.js" type="text/javascript"></script>
    <script src="Scripts/validationfortextbox.js" type="text/javascript"></script>
    <%--<link href="Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />--%>
    <script src="ScriptsAuto/jquery.min.js" type="text/javascript"></script>
    <script src="ScriptsAuto/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <%--<link href="Theme/Content/assets/css/login.css" rel="stylesheet" type="text/css" />--%>
    <script src="Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <script language="javascript" type="text/javascript">
        function popWin() {
            popupWindow = window.open("ForgotPwd.aspx", 'popUpWindow', 'height=100px,width=100px,left=0,top=0,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
    </script>

    <script type="text/javascript">
        javascript: window.history.forward(0);
    </script>
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/MainForm.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function setPageHeight() {
            var y = screen.availHeight;
            var x = y - 95;
            var a = document.getElementById('total').style.height = x + 'px';
        }
        document.oncontextmenu = function () { return false };
        window.ondragstart = function () { return false; }
        function getiframeURL() {
            var source = document.getElementById('ifrmaster').contentWindow.location.href;
            var hdnfldVariable = document.getElementById('hdn_source');
            hdnfldVariable.value = source;
        }
        //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
    </script>
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
                if (va1 == -1) {
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
        };
    </script>
    <%--<script type="text/javascript">
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
    <style type="text/css">
        .LoginContainerBG {
            background-repeat: no-repeat;
        }

        .FooterCont p {
            padding: 0 0 10px !important;
        }

        .chzn-drop {
            height: auto !important;
        }

        .TextField span {
            font-size: 13px !important;
            font-weight: 500;
        }
        /* Change the white to any color */ input:-webkit-autofill,
        input:-webkit-autofill:hover,
        input:-webkit-autofill:focus,
        input:-webkit-autofill:active {
            -webkit-box-shadow: 0 0 0 30px white inset !important;
        }

   input#CName {
    height: 58px !important;
    padding-left: 37px !important;
    /* margin-top: 11px !important; */
    padding-top: 26px !important;
}
    </style>
    <style type="text/css">
        .top_logo {
            /*border:1px solid black;
      margin-top :0.35%;
      height: 100%;
      height:90px;
      width:10%;
      margin-left :0%;
      float:left;*/
            border: 1px solid black;
            margin-top: 0.35%;
            height: 28px;
            width: 3%;
            margin-left: 1%;
            float: left;
            margin-right: 1%;
        }

        .top_logo_Text {
            float: left;
            /*border:1px solid black;*/
            margin-top: 0.5%;
            height: 25px;
            /*height: 99%;*/
            width: 6%;
            margin-left: 5.5%;
            /*Border :1px solid red;*/
        }

        .div_img {
            width: 16px;
            height: 16px;
        }

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

        .alertify .ajs-footer .ajs-buttons.ajs-primary .ajs-button {
            background: #f67e09 !important;
            color: white !important;
            border-radius: 10px !important;
            margin-top: 8px !important;
        }

        .alertify .ajs-dimmer {
            background-color: rgb(0 0 0 / 56%) !important;
        }


        .ajs-dialog {
            POSITION: relative;
            /*left: 378px;*/
        }

        .ajs-header {
            display: none;
        }

        .alertify .ajs-body {
            min-height: 55px;
            /* background: gainsboro; */
            width: 200% !important;
            display: flex;
            /*justify-content: center;*/
            align-items: center;
        }

        .alertify .ajs-commands {
            position: absolute;
            right: 4px;
            margin: -14px 24px 0 0;
            z-index: 2;
        }

        .ajs-dialog {
            padding: 0px !important;
        }

        .alertify .ajs-footer {
            padding: 0px !important;
            /*margin-left: 42% !important;*/
            margin-right: 0px !important;
            min-height: auto !important;
            background: none !important;
        }

        .ajs-dialog {
            height: 10px !IMPORTANT;
            min-height: 0px !important;
            max-height: 141px;
        }



        .ajs-dialog {
            height: 54px !important;
        }


        .alertify .ajs-dialog {
            width: 100% !important;
            min-height: 122px;
            background-color: #fff;
            border: 1px solid rgba(0, 0, 0, .2);
            -webkit-box-shadow: 0 5px 15px rgba(0,0,0,.5);
            box-shadow: 0 5px 15px rgba(0,0,0,.5);
            border-radius: 6px;
            height: auto !important;
        }

        .alertify .ajs-dialog {
            background: gainsboro !important;
            float: right;
            margin-right: 8px !important;
        }

        .alertify .ajs-reset {
            display: none !important;
        }

        .ajs-body {
            width: 75%;
        }

        .alertify .ajs-body .ajs-content {
            padding: 16px 16px 16px 24px;
            font-size: 15px;
        }

        .alertify .ajs-body .ajs-content {
            padding: 16px 16px 16px 24px;
            font-size: 15px;
        }

        .ajs-dialog {
            display: flex;
        }

        .ajs-footer {
            width: 30%;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .alertify .ajs-footer .ajs-buttons.ajs-primary {
            text-align: right !important;
        }

        .ajs-dialog {
            margin: 0px !important;
            position: sticky !important;
            top: 29px;
        }

        .alertify .ajs-modal {
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            padding: 0;
            overflow-y: auto;
            z-index: 9999999999999999999999999999999999999;
        }
    </style>
    <script src="ScriptsAuto/Focus.js" type="text/javascript"></script>
    <script src="Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
    <script src="ScriptsAuto/jquery.min.js" type="text/javascript"></script>
    <script src="ScriptsAuto/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/login.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <script language="javascript" type="text/javascript">
        function popWin() {
            popupWindow = window.open("ForgotPwd.aspx", 'popUpWindow', 'height=100px,width=100px,left=0,top=0,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
    </script>
    <script type="text/javascript">
        javascript: window.history.forward(0);
    </script>
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/MainForm.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function setPageHeight() {
            var y = screen.availHeight;
            var x = y - 95;
            var a = document.getElementById('total').style.height = x + 'px';
        }
        document.oncontextmenu = function () { return false };
        window.ondragstart = function () { return false; }
        function getiframeURL() {
            var source = document.getElementById('ifrmaster').contentWindow.location.href;
            var hdnfldVariable = document.getElementById('hdn_source');
            hdnfldVariable.value = source;
        }
        //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }
    </script>
    <style type="text/css">
        .Loginimg {
            width: 1366px;
            margin: 65px auto 0px auto;
            min-height: 400px;
            background: url(Theme/assets/img/loginbg.png) repeat-x left top;
        }

        .modalBackground1 {
            /*background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7;*/
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .frames {
            width: 100%;
            height: 462px;
        }



        .Passwordtext {
            width: 77%;
            float: left;
            margin: 10px 0px 0px 0px;
        }
        /* Generated by Font Squirrel (https://www.fontsquirrel.com) on March 1, 2017 */
        @font-face {
            font-family: 'petit_formal_scriptregular';
            src: url('font/petitformalscript-regular-webfont.woff2') format('woff2'), url('font/petitformalscript-regular-webfont.woff') format('woff');
            font-weight: normal;
            font-style: normal;
        }



        @media only screen and (max-width: 1280px) {
            .Loginimg {
                width: 100%;
                margin: 65px auto 0px auto;
                min-height: 400px;
            }

            .FooterCont {
                width: 100%;
            }

            .header {
                z-index: 10030;
                width: 100%;
                margin: 0px auto;
            }
        }

        .FooterText {
            font-family: Tahoma;
            color: #026ba2;
            font-size: 12px;
            padding: 85px 0px 0px 0px;
            margin: 0px 0px 0px 0px;
            text-align: center;
        }

        .ForGotPass {
            color: #CCCCCC;
            margin: -2px 0px 0px 4px;
            width: 70%;
            text-align: center;
        }

            .ForGotPass a {
                color: #000;
                font-weight: normal;
                /*text-shadow:1px 1px #000000;*/
                font-family: 'Segoe UI';
                font-size: 12px;
            }

        .NewUser {
            color: #ffffff;
            margin: -23px 7px 0 49px;
            text-align: left;
            width: 54%;
            float: left;
        }

            .NewUser a {
                color: #ffffff;
                font-weight: normal;
                /*text-shadow:1px 1px #000000;*/
                font-family: 'Segoe UI';
                font-size: 12px;
            }

        label {
            color: #000;
            font-size: 12px;
            font-weight: normal;
        }

            label.lbl_Link {
                color: #ee3926;
                line-height: 34px;
                text-decoration: none;
                /*vertical-align: middle;*/
                cursor: pointer;
            }
    </style>
    <style type="text/css">
        input#txtpassword {
            outline: none;
            border: 0px solid #e0e0e0 !important;
            border-bottom: 1px solid var(--inputborder) !important;
            border-radius: 0 !important;
        }

        .pwd {
            margin: 12px 0px 0px 0px;
        }

        input#btnSignin {
            padding: 9px 85px 14px 85px;
            border-radius: 3px;
            background: #06529c;
            border: none;
            color: white;
            font-family: arial;
            font-size: 14px;
        }

        .forgot {
            margin: 10px 0px 0px;
            font-size: 11px;
            font-weight: bold;
        }

        .LoginContainerBG {
            zoom: 90%;
        }

        .login-input {
            width: 100%;
            height: 27px;
            padding: 0px 5px;
            border-radius: 3px !important;
            background-color: white !important;
            margin: 5px 0px 0px 0px;
        }

        input#txtpassword:focus {
            border-bottom: 1px solid #06529c !important;
        }

        .LoginUserName span {
            color: black;
            font-size: 11px;
        }

        a:hover {
            color: #06529c;
        }

        .New_User label {
            font-size: 11px;
        }

        .side_content {
            width: 27.5%;
            text-align: justify;
            position: absolute;
            top: 5px;
            left: 20px;
        }

        form {
            height: auto !important;
            overflow: hidden;
            width: auto !important;
            margin: 0px auto;
        }

        .side_content h2 {
            color: #fff;
            font-size: 20px;
        }

        .side_content p {
            color: #fff;
        }

        .company_bottom {
            display: flex;
            width: 23.5%;
            font-size: 10px;
            justify-content: space-between;
            position: absolute;
            bottom: 38px;
            right: 107px;
        }

        span#txtGlossary {
            display: block;
        }

        .company_bottom p {
            color: #000;
        }

        body.login {
            width: 100% !important;
            height: 100vh !important;
            margin: 0 auto !important;
            background: #fff;
            overflow: hidden !important;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        input[type=text] {
            font-size: 12px;
        }

        .modalPopupss {
            position: fixed !important;
            background-color: rgba(0, 0, 0, 0.75) !important;
            width: 100% !important;
            height: 100% !important;
            margin-left: 0% !important;
            margin-top: 0% !important;
            border: 1px solid var(--lightgrey) !important;
            display: flex;
            justify-content: center;
            align-items: center;
            top: 0px !important;
            left: 0px !important;
        }

        .divRoated {
            width: 32% !important;
            height: 65vh !important;
            overflow: hidden !important;
            background: var(--white);
            border-radius: 3px;
            margin: 0px !important;
            position: relative;
        }

        .DivSecPanel {
            position: absolute;
            right: 11px;
            top: 10px;
        }

        marquee {
            width: 68.5%;
            float: right;
            display: none;
        }

        .pwd.TextField span {
            top: 3px !important;
        }

        .uname.TextField span {
            top: 0px !important;
        }
        /*body.login{
    position: relative;
        background: url(Theme/assets/img/biometricbackground.png);
      width: 100% !important;
    background-size: contain;
}*/
        input#txtusername {
            height: 56px !important;
        }

        input#txtpassword {
            height: 56px !important;
        }

        .LoginUserName {
            width: 16.5%;
            padding: 0px;
            position: absolute;
            left: 61.2%;
            top: 38%;
        }

        .signinbutton {
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 36px 0px 0px 0px;
        }

        .form {
            padding: 52px;
        }

        .heading {
            font-size: 33px;
            box-shadow: 0px 0px 20px rgb(233 12 12 / 13%);
            padding: 25px;
            color: #06529c;
            font-weight: bold;
        }

        .login_container {
            width: 320px;
            background-color: #fff;
            border-radius: 12px;
            /* padding: 52px; */
            box-shadow: 0px 0px 20px rgb(0 0 0 / 15%);
            overflow: hidden;
            height: 536px;
        }

        body {
            width: 100%;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            /* background-color: #acc0ff; */
        }

        input#txtusername {
            padding-left: 37px !important;
        }

        input#txtpassword {
            padding-left: 38px !important;
        }

        .userico {
            position: relative;
            bottom: 235px;
            width: 8.5%;
            left: 55px;
            /*border-right: 1px solid #06529c;*/
            height: 19px;
        }
        .companyico {
    position: relative;
    bottom: 334px;
    width: 8.5%;
    left: 55px;
    height: 19px;
}
        .passico {
            position: relative;
            bottom: 177px;
            width: 8.5%;
            left: 55px;
            /*border-right: 1px solid #06529c;*/
            height: 19px;
        }
        /*      .screen {
    background: linear-gradient(100deg, #06529c, #06529c);
    position: relative;
    height: 531px;
    width: 360px;
    box-shadow: 0px 0px 24px #a19ad6;
}

.screen__content {
	z-index: 1;
	position: relative;	
	height: 100%;
}

.screen__background {		
	position: absolute;
	top: 0;
	left: 0;
	right: 0;
	bottom: 0;
	z-index: 0;
	-webkit-clip-path: inset(0 0 0 0);
	clip-path: inset(0 0 0 0);	
}

.screen__background__shape {
	transform: rotate(45deg);
	position: absolute;
}

.screen__background__shape1 {
	height: 520px;
	width: 520px;
	background: #FFF;	
	top: -50px;
	right: 120px;	
	border-radius: 0 72px 0 0;
}

.screen__background__shape2 {
    height: 220px;
    width: 220px;
    background: #f8a350;
    top: -172px;
    right: 0;
    border-radius: 32px;
}

.screen__background__shape3 {
    height: 540px;
    width: 190px;
    background: linear-gradient(1000deg, #f8a350, #fff);
    top: -24px;
    right: 0;
    border-radius: 32px;
}

.screen__background__shape4 {
    height: 400px;
    width: 200px;
    background: #f8a350;
    top: 420px;
    right: 50px;
    border-radius: 60px;
}



.login {
	width: 320px;
	padding: 30px;
	padding-top: 156px;
}

.login__field {
	padding: 20px 0px;	
	position: relative;	
}

.login__field i {
	position: absolute;
	top: 30px;
	color: #3a2ab5;
}

.login__input {
	border: none;
	border-bottom: 2px solid #D1D1D4;
	background: none;
	padding: 10px;
	padding-left: 24px;
	font-weight: 700;
	width: 75%;
	transition: .2s;
}

.login__input:active,
.login__input:focus,
.login__input:hover {
	outline: none !important;
	border-bottom-color: #fafafc !important;
}

.login__submit {
	background: #fff;
	font-size: 14px;
	margin-top: 30px;
	padding: 16px 64px;
	border-radius: 26px;
	border: 1px solid #D4D3E8;
	text-transform: uppercase;
	font-weight: 700;
	display: flex;
	align-items: center;
	width: 100%;
	color: #3a2ab5;
	box-shadow: 0px 2px 2px #fafafc;
	cursor: pointer;
	transition: .2s;
}

.login__submit:active,
.login__submit:focus,
.login__submit:hover {
	border-color: #3a2ba5;
	outline: none;
}

.button i {
	font-size: 24px;
	margin-left: auto;
	color: #3a2ba5;
}

.social-login {	
	position: absolute;
	height: 140px;
	width: 160px;
	text-align: center;
	bottom: 0px;
	right: 0px;
	color: #fff;
}

*/
    </style>
</head>
<body class="login" onload="setPageHeight()" style="overflow: hidden;">
    <!-- Header -->
    <!-- /.header -->
    <!-- Login Box -->
    <div class="login_container">
        <form id="myform" runat="server" class="form-vertical login-form">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="hide">
                <asp:Label runat="server" Text="User Name"></asp:Label>
                <asp:Label runat="server" Text="Password"></asp:Label>

            </div>
            <marquee width="100%" direction="left" height="100px">
                We have improved UI Design, Hence please clear the browser history for better experience.
            </marquee>


            <%-- Login page new design --%>


            <p class="heading">
                Hello! 
                <br />
                Welcome Back
            </p>
            <div class="form">
                <div class="Branchdrp">
                    <asp:DropDownList ID="ddl_country" runat="server" Height="23" CssClass="chzn-select form-control" Visible="false" ToolTip="Country" placeholder="Country" AutoPostBack="true" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                        <asp:ListItem Value="0">Country</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="LoginCompanyBranch">
                    <asp:DropDownList data-placeholder="Branch" ID="ddlbranch" runat="server" TabIndex="2" ForeColor="Black" Visible="false" CssClass="chzn-select form-control">
                        <asp:ListItem Value="0">Branch</asp:ListItem>
                    </asp:DropDownList>
                </div>



                <div>
                    <asp:TextBox ID="CName" runat="server" Style="font-size: 14px" PlaceHolder="Company" OnTextChanged="CName_TextChanged"></asp:TextBox>
                    <asp:Button ID="CBtn" runat="server" Text=" " TabIndex="3" OnClick="CBtn_Click" Visible="false" />
                </div>



                <div class="uname ">
                    <asp:TextBox ID="txtusername" runat="server" class="login-input" Style="font-size: 14px" PlaceHolder="Username"></asp:TextBox>
                </div>
                <div class="pwd ">

                    <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" Style="font-size: 20px;" PlaceHolder="Password" MaxLength="20" class="login-input"></asp:TextBox>

                </div>
                <div class="signinbutton">
                    <asp:Button ID="btnSignin" runat="server" Text="Sign  In" TabIndex="3" CssClass="Login_button"
                        OnClick="btnSignin_Click" />
                </div>





                <div class="forgot hide">
                    <asp:LinkButton ID="lnkforgetpwd" runat="server" CssClass="linknew"
                        Style="text-decoration: none;" TabIndex="4" OnClick="lnkforgetpwd_Click">Forgot Password?</asp:LinkButton>
                </div>
                <div class="New_User" style="display: none">
                    <label for="password">
                        New User
                    </label>

                    <a href="CustomerRegistration.aspx?div=M" style="text-decoration: none;">
                        <label class="lbl_Link">Sign Up</label></a>
                    <label for="password" style="display: inline-block; margin: 6px 0px 0px 0px; padding: 4px;">
                        Here</label>

                </div>



            </div>




            <div class="userico">
                <div class="usericon">
                    <img src="Theme/assets/img/buttonIcon/active/Username_Full.png" width="17px" />
                </div>
            </div>
            <div class="passico">
                <div class="passicon">
                    <img src="Theme/assets/img/buttonIcon/active/password.png" width="17px" />
                </div>
            </div>
            <div class="companyico">
                <div class="companyicon">
                    <img src="Theme/assets/img/buttonIcon/active/company_name.png" width="17px" />
                </div>
            </div>
            <div class="side_content">

                <h2>
                    <asp:Label runat="server" ID="txtGlossary"></asp:Label>
                    <asp:Label ID="Glossary" runat="server"></asp:Label>

                </h2>
                <p>
                    <asp:Label runat="server" ID="txtdecr"></asp:Label>

                </p>
            </div>

            <asp:HiddenField ID="hmailserver" runat="server" />
            <asp:HiddenField ID="hmailpwd" runat="server" />
            <asp:HiddenField ID="hmailport" runat="server" />
            <asp:HiddenField ID="hidCity" runat="server" />
            <asp:HiddenField ID="hidCustID" runat="server" />
            <asp:HiddenField ID="hidPwd" runat="server" />
            <asp:HiddenField ID="hid_Blrrr" runat="server" />
            <asp:HiddenField ID="hdn_pwd" runat="server" />
            <asp:HiddenField ID="hf_division" runat="server" />
            <asp:HiddenField ID="hf_branch" runat="server" />
            <asp:HiddenField ID="hf_wrong" runat="server" />
            <asp:Panel ID="pnl_emp" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                <div class="divRoated">
                    <div class="DivSecPanel">
                        <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                    </div>
                    <asp:Panel ID="pnl_emp1" runat="server" CssClass="">
                        <iframe id="iframecost" runat="server" src="ForwardExports/EmpchangePass.aspx" frameborder="0"></iframe>
                    </asp:Panel>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="pop_passemp" runat="server" PopupControlID="pnl_emp" DropShadow="false"
                TargetControlID="Label2" CancelControlID="Close_voucher">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="hdnAppServerName" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hid" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="Hid_ccode" runat="server"></asp:HiddenField>
            <asp:Label ID="Label2" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </form>
    </div>

    <!-- /Login Box -->
    <%--<div class="FooterCont"></div>--%>
</body>
</html>
