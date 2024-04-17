<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRMDocked.aspx.cs" EnableEventValidation="false" Inherits="logix.MainPage.HRMDocked" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <!-- Bootstrap -->
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

    <!--=== JavaScript ===-->


    <!-- Smartphone Touch Events -->

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

    <%--<link href="../Theme/MenuToggle/drawer.min.css" rel="stylesheet" />--%>
    <link href="../Theme/Leftnav/font-awesome.css" rel="stylesheet" />
    <link href="../Theme/Leftnav/bootstrap.min.css" rel="stylesheet" />
    <link href="../Theme/Leftnav/mdb.min.css" rel="stylesheet" />

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        #sidebar {
            background: none repeat scroll 0 0 #e5e4e4;
            border-top: 1px solid #D7DBDF;
            bottom: 0;
            height: 100%;
            /*left: 0;*/
            position: absolute;
            width: 250px;
            z-index: 700;
        }

        .Text {
            text-decoration: none;
            color: #2D3E5B;
            font-family: Arial;
            font-size: 9pt;
            width: 100%;
            height: 100%;
            display: block;
        }

        body {
            margin: 0px;
            font-family: Arial, Sans-Serif;
            font-size: 13px;
        }
        /* dock */
        #dock {
            margin: 0px;
            padding: 0px;
            list-style: none;
            position: fixed;
            top: 0px;
            height: 100%;
            z-index: 100;
            background-color: #f0f0f0;
            left: 0px;
        }

            #dock > li {
                width: 30px;
                height: 80px;
                margin: 0 0 1px 0;
                background-color: #dcdcdc;
                background-repeat: no-repeat;
                background-position: left center;
            }

            #dock #setup {
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                text-decoration: none;
            }

                #dock #setup:hover {
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }



            #dock #links {
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                text-decoration: none;
            }

                #dock #links:hover {
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #files {
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                color: #ffffff;
                text-decoration: none;
            }

                #dock #files:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }


            #dock #Accounts {
                height: 70px;
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                color: #ffffff;
                text-decoration: none;
            }

                #dock #Accounts:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            /*new */

            #dock #Approval {
                height: 70px;
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                color: #ffffff;
                text-decoration: none;
            }

                #dock #Approval:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #TrendAnalysis {
                height: 70px;
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                color: #ffffff;
                text-decoration: none;
            }

                #dock #TrendAnalysis:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #MIS {
                height: 50px;
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                color: #ffffff;
                text-decoration: none;
            }

                #dock #MIS:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #Utility {
                height: 65px;
                background: #a5a7a8;
                background-image: -webkit-linear-gradient(top, #a5a7a8, #929394);
                background-image: -moz-linear-gradient(top, #a5a7a8, #929394);
                background-image: -ms-linear-gradient(top, #a5a7a8, #929394);
                background-image: -o-linear-gradient(top, #a5a7a8, #929394);
                background-image: linear-gradient(to bottom, #a5a7a8, #929394);
                -webkit-border-radius: 28;
                -moz-border-radius: 28;
                font-family: tahoma;
                color: #ffffff;
                text-decoration: none;
            }

                #dock #Utility:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }
            /*new*/




            #dock > li:hover {
                background-position: -40px 0px;
            }

            /* panels */
            #dock ul li {
                padding: 5px;
                border: solid 1px #F1F1F1;
            }

                #dock ul li:hover {
                    background: #D3DAED url(item_bkg.png) repeat-x;
                    border: solid 1px #A8D8EB;
                }

                #dock ul li.header, #dock ul li .header:hover {
                    background: #D3DAED url(header_bkg.png) repeat-x;
                    border: solid 1px #F1F1F1;
                }

            #dock > li:hover ul {
                display: block;
            }

            #dock > li ul {
                position: absolute;
                top: 0px;
                left: -180px;
                z-index: -1;
                width: 180px;
                display: none;
                background-color: #F1F1F1;
                border: solid 1px #969696;
                padding: 0px;
                margin: 0px;
                list-style: none;
            }

                #dock > li ul.docked {
                    display: block;
                    z-index: -2;
                }

        .dock, .undock {
            float: right;
        }

        .undock {
            display: none;
        }
        /*#content {margin: 10px 0 0 60px;}*/
    </style>

    <style type="text/css">
        .EmptyRowStyle {
            text-align: center;
        }

        .GridHeader {
            background-color: Navy;
            color: White;
            font-family: sans-serif;
            font-size: 10pt;
            margin-left: 4px;
            margin-bottom: 0px;
            padding: 2px;
            text-align: center;
        }

        .GrdAltRow {
            background-color: #FFF8DC;
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-left: 4px;
            margin-bottom: 0px;
        }

        .div_iframe {
            float: left;
            height: 1150px;
            width: 100%;
            margin-left: 0%;
            margin-top: 0%;
        }

        .div_iframe1 {
            float: right;
            width: 197px;
            height: 600px;
            /*margin-right: 0.5%;*/
            margin-top: -1.5%;
        }

        .iframe {
            height: 100%;
            width: 100%;
        }

        .div_dock {
            margin-top: 10%;
        }

        .rotate_div {
            border-left: 3px solid transparent;
            display: block;
            text-align: left;
            border-top: 1px solid rgba(255,255,255,0.1);
            position: relative;
            font-size: 9pt;
            -webkit-transform: rotate(90deg);
            -moz-transform: rotate(90deg);
            -ms-transform: rotate(90deg);
            -o-transform: rotate((90deg));
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=1);
            behavior: url(PIE.htc);
            width: 58px;
            color: White;
            font-weight: bold;
            font-variant: normal;
            font-family: 'Times New Roman';
            cursor: pointer;
        }

        .rotate_text {
            position: absolute;
            -webkit-transform: rotate(180deg);
            -moz-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            -o-transform: rotate(180deg);
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            behavior: url(PIE.htc);
            width: 58px;
            color: White;
            font-weight: bold;
            /*padding-top:6%;
     padding-left:40%;*/
            padding-bottom: 40%;
            padding-right: 6%;
        }

        .rotate_text1 {
            position: absolute;
            -webkit-transform: rotate(180deg);
            -moz-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            -o-transform: rotate(180deg);
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            behavior: url(PIE.htc);
            width: 58px;
            color: White;
            font-weight: bold;
            /*padding-top:6%;
     padding-left:40%;*/
            padding-bottom: 50%;
            padding-right: 40%;
        }


        .rotate_textit {
            position: absolute;
            -webkit-transform: rotate(180deg);
            -moz-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            -o-transform: rotate(180deg);
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            behavior: url(PIE.htc);
            width: 58px;
            color: White;
            font-weight: bold;
            /*padding-top:6%;
     padding-left:40%;*/
            padding-bottom: 50%;
            padding-right: 40%;
        }

        .rotate_trend {
            position: absolute;
            -webkit-transform: rotate(180deg);
            -moz-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            -o-transform: rotate(180deg);
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            behavior: url(PIE.htc);
            width: 58px;
            color: White;
            font-weight: bold;
            padding-bottom: 50%;
            padding-right: 40%;
        }

        .rotate_acc {
            position: absolute;
            -webkit-transform: rotate(180deg);
            -moz-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            -o-transform: rotate(180deg);
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            behavior: url(PIE.htc);
            width: 58px;
            color: White;
            font-weight: bold;
            /*padding-top:6%;
     padding-left:40%;*/
            padding-bottom: 50%;
            padding-right: 20%;
        }
    </style>
    <!--<script type="text/javascript" src="../Scripts/jquery-1.2.6.min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script> -->
    <script type="text/javascript">
        $(document).ready(function () {
            var docked = 0;

            $("#dock li ul").height($(window).height());

            $("#dock .dock").click(function () {
                $(this).parent().parent().addClass("docked").removeClass("free");

                docked += 1;
                var dockH = ($(window).height()) / docked
                var dockT = 0;

                $("#dock li ul.docked").each(function () {
                    $(this).height(dockH).css("top", dockT + "px");
                    dockT += dockH;
                });
                $(this).parent().find(".undock").show();
                $(this).hide();

                if (docked > 0)
                    $("#content").css("margin-left", "250px");
                else
                    $("#content").css("margin-left", "60px");
            });

            $("#dock .undock").click(function () {
                $(this).parent().parent().addClass("free").removeClass("docked")
                    .animate({ left: "-180px" }, 200).height($(window).height()).css("top", "0px");

                docked = docked - 1;
                var dockH = ($(window).height()) / docked
                var dockT = 0;

                $("#dock li ul.docked").each(function () {
                    $(this).height(dockH).css("top", dockT + "px");
                    dockT += dockH;
                });
                $(this).parent().find(".dock").show();
                $(this).hide();

                if (docked > 0)
                    $("#content").css("margin-left", "250px");
                else
                    $("#content").css("margin-left", "60px");
            });

            $("#dock li").hover(function () {
                $(this).find("ul").animate({ left: "31px" }, 200);
            }, function () {
                $(this).find("ul.free").animate({ left: "-180px" }, 200);
            });
        });
    </script>

    <style type="text/css">
        .panel1 {
            float: right;
            width: 200px;
            height: 600px;
            margin-right: 0.5%;
            margin-top: -0.5%;
            /*border:1px solid black*/
            background-color: #F5F5F2;
            -webkit-box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            -moz-box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            -webkit-border-radius: 5px 5px 5px 5px;
            -moz-border-radius: 5px 5px 5px 5px;
            border-radius: 5px 5px 5px 5px;
        }


        .div_Grid {
            width: 80%;
            float: left;
            margin-top: 0.5%;
            margin-left: 2%;
            margin-bottom: 1%;
            height: 50%;
            overflow-y: scroll;
        }

        .div_total {
            float: left;
            margin-left: 1%;
        }

        .div_lnkbooking {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkhbl {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkmbl {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkappr {
            float: left;
            margin-left: 1%;
            margin-top: 1.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkevn {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnktool {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkprtcnty {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkport {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkunclosed {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .Gridpnl {
            /*width:849px; 
            Height:294px;*/
            float: left;
            width: 87%;
            height: 25%;
            margin-top: 1%;
            margin-left: 1%;
            overflow: auto;
            /*margin-top:-0.5%;*/
        }

        .Gridpnlex {
            /*width:849px; 
            Height:294px;*/
            float: right;
            width: 90%;
            height: 159px;
            margin-top: 1%;
            margin-left: 1%;
            overflow: auto;
            /*margin-top:-0.5%;*/
        }

        .Gridpnl1 {
            /*width:849px; 
            Height:294px;*/
            float: left;
            width: 92%;
            margin-top: 1%;
            margin-left: 1%;
            overflow: auto;
            /*margin-top:-0.5%;*/
        }

        .div_txtPort1 {
            float: left;
            /*margin-left: 8.95%;*/
            margin-top: 1%;
            margin-bottom: 0.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .Text1 {
            font-family: sans-serif;
            font-size: 10pt;
            font-style: normal;
            border-color: #999997;
            /*C9C9C9    CECFCA */
            border: 1px solid #999997;
            text-transform: uppercase;
        }

        .div_txtjob {
            width: 25%;
            float: left;
            margin-left: 10%;
            margin-top: 0.5%;
        }

        .div_Menu2 {
            float: left;
            margin-top: 3%;
            /*width :79%;*/
            /*width :99%;*/
            width: 70%;
            height: 450px;
            background-color: White;
            margin-left: 0.5%;
            /*margin-right :1%;*/
        }

        .div_jobcostingframe {
            float: left;
            width: 95%;
            margin-left: 1%;
            margin-top: 1%;
            /*overflow:auto;*/
        }

        .FrameTitle1 {
            font-family: sans-serif;
            float: left;
            margin-left: 1%;
            font-size: 11pt;
            color: navy;
        }

        .div_ddl {
            width: 71.5%;
            float: left;
            margin-left: 10%;
            margin-top: 1%;
        }

            .div_ddl select {
                width: 100%;
            }

        .div_btn {
            float: left;
            margin-left: 1.5%;
            margin-top: 0.5%;
            margin-bottom: 1%;
        }

        .div_Menu3 {
            float: left;
            margin-top: 1%;
            /*width :79%;*/
            /*width :99%;*/
            width: 50%;
            background-color: White;
            margin-left: 0.5%;
            /*margin-right :1%;*/
        }

        .lbl_con {
            font-size: 10pt;
            margin-left: 6%;
            color: brown;
            margin-top: 2%;
        }

        .lnk_common {
            float: left;
            margin-left: 1%;
            margin-top: 0.5%;
        }

        .pnl_tool {
            /*width:849px; 
            Height:294px;*/
            float: left;
            width: 87%;
            margin-top: 1%;
            margin-left: 1%;
            overflow: auto;
            /*margin-top:-0.5%;*/
        }

        .div_lnkemplist {
            float: left;
            /*margin-left:-47%;*/
            margin-left: 1%;
            margin-top: 2.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkcnfpro {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkbdaylist {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_confirm {
            float: right;
            margin-right: 0.6%;
            text-align: right;
        }

        .Pnl1 {
            height: 70px;
            float: left;
            width: 283px;
            border: 1px solid #999997;
            background-color: white;
        }
    </style>
    <script type="text/javascript">


        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });

        }
        function ConfirmMsg() {
            var ConfirmValue = confirm('Do You Want to Process IT Computation for all Employee?');
            if (ConfirmValue == true) {
                return true;
            }
            else {
                return false;
            }
        }


    </script>


</head>
<body class="drawer drawer--left">

    <form id="form1" runat="server">
        <script type="text/javascript">
            if (document.layers) {
                //Capture the MouseDown event.
                document.captureEvents(Event.MOUSEDOWN);

                //Disable the OnMouseDown event handler.
                document.onmousedown = function () {
                    return false;
                };
            }
            else {
                //Disable the OnMouseUp event handler.
                document.onmouseup = function (e) {
                    if (e != null && e.type == "mouseup") {
                        //Check the Mouse Button which is clicked.
                        if (e.which == 2 || e.which == 3) {
                            //If the Button is middle or right then disable.
                            return false;
                        }
                    }
                };
            }

            //Disable the Context Menu event.
            document.oncontextmenu = function () {
                return false;
            };
    </script>   




        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>



        <div id="container" class="fixed-header">
            <!-- Sidebar Toggler -->
            <a href="#" class="toggle-sidebar bs-tooltip" data-placement="bottom" data-original-title="Toggle navigation" style="display:none;"><i class="icon-reorder"></i></a>
            <!-- /Sidebar Toggler -->

             <button type="button" class="drawer-toggle drawer-hamburger" title="Toggle Navigation" style="display:none;">
     <span class="sr-only">toggle navigation</span>
      <span class="drawer-hamburger-icon"></span>
    </button>

                  <!-- SideNav slide-out button -->
            <div class="custom-my-2">
                <a href="#" data-activates="slide-out" class="button-collapse black-text"><i class="fa fa-bars"></i></a>
            </div>

             <!-- Sidebar navigation -->
        <div id="slide-out" class="side-nav sn-bg-4 fixed" style="transform: translateX(-100%);">
            <ul class="custom-scrollbar">
                              
                <!-- Side navigation links -->
                <li>
                    <ul class="collapsible collapsible-accordion">
                        <li><a href="javascript:void(0);"><i class="icon-share"></i> HRM</a></li>
                        <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-newspaper-o"></i> HRM<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="divsales" runat="server"></div>
                                </ul>
                            </div>
                        </li>
                        <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-desktop"></i> Payroll<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="divcustomer" runat="server"></div>
                                </ul>
                            </div>
                        </li>
                         <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-wpbeginner"></i> IT - Workings<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="div3" runat="server"></div>
                                </ul>
                            </div>
                        </li>
                         <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-dropbox"></i> Reports<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="DivAccounts" runat="server"></div>
                                </ul>
                            </div>
                        </li>
                         <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-wpforms"></i> MIS<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="DivMIS" runat="server"></div>
                                </ul>
                            </div>
                        </li>
                         <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-umbrella"></i> Utility<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="Divutility" runat="server"></div>
                                </ul>
                            </div>
                        </li>
                    </ul>
                </li>
                <!--/. Side navigation links -->
            </ul>
           <!-- <div class="sidenav-bg mask-strong"></div>-->
        </div>
        <!--/. Sidebar navigation -->
            <script src="../Theme/Leftnav/jquery-3.2.1.min.js"></script>

            <script src="../Theme/Leftnav/mdb.min.js"></script>

             <script>

                 // SideNav Initialization
                 $(".button-collapse").sideNav();

                 new WOW().init();

    </script>


















                 <nav class="drawer-nav" role="navigation" style="display:none;">
                        <!--=== Navigation Starts ===-->
                    <ul id="nav" class="drawer-menu">
                        <li class="brderright" ><a href="javascript:void(0);"><i class="icon-share"></i></a> </li>
                            
                                <li id="setup" runat="server" class="drawer-dropdown">
                                    <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-gear"></i>  <span class="drawer-caret"></span></a>

                                    <ul class="drawer-dropdown-menu">

                                        

                                        <%--<li><a class="Text" href="../HRM/HRMPersonalInformation.aspx" target="MainFrame">Employee</a></li>--%>
                                        <%--<li><a class="Text" href='../HRM/Packages.aspx?type=Packages&" + this.Page.ClientQueryString + "'  target="MainFrame">Package</a></li>--%>
                                        <%--<li><a class="Text" href="../HRM/Packages.aspx" target="MainFrame">Package</a></li>
                                            <li><a class="Text" href="../HRM/SalaryPackage.aspx" target="MainFrame">Salary Package</a></li>
                                            <li><a class="Text" href="../HRM/CTC.aspx" target="MainFrame">C T C</a></li>
                                            <li><a class="Text" href="../HRM/Confirmation.aspx" target="MainFrame">Confirmation</a></li>               
                                            <li><a class="Text" href="../HRM/Relieving.aspx" target="MainFrame">Relieving</a></li>
                                            <li><a class="Text" href="../HRM/Attendance.aspx" target="MainFrame">Attendance</a></li>
                                            <li><a class="Text" href="../HRM/LeaveBalance.aspx" target="MainFrame">Leave Balance</a></li>
                                            <li><a class="Text" href="../HRM/Permission.aspx" target="MainFrame">Permissions</a></li>
                                            <li><a class="Text" href="../HRM/ELEncashed.aspx" target="MainFrame">EL Encashed</a></li>
                                            <li><a class="Text" href="../HRM/ClaimDetail.aspx" target="MainFrame">Claim Details</a></li>
                                            <li><a class="Text" href="../HRM/LateAttendance.aspx" target="MainFrame">Late Attendance</a></li>
                                            <li><a class="Text" href="../HRM/Salary Revision.aspx" target="MainFrame">Salary Revision</a></li>--%>
                                        <%--<li><a class="Text" href="../UnderConstruction.aspx" target="MainFrame">Week Off</a></li>--%>
                                        <%--<li><a class="Text" href="../UnderConstruction.aspx" target="MainFrame">Leave Days</a></li>--%>
                                        <%--<li><a class="Text" href="../HRM/GradeDetails.aspx" target="MainFrame">Grade Details</a></li>
                                            <li><a class="Text" href="../HRM/Form1.aspx" target="MainFrame">Excel Reader</a></li>--%>
                                    </ul>

                                </li>
                                <li id="links" runat="server" class="drawer-dropdown">
                                    <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-user-md"></i>  <span class="drawer-caret"></span></a>
                                    <ul class="drawer-dropdown-menu">

                                        

                                        <%--<li><a class="Text" href="../HRM/LOPDays.aspx" target="MainFrame">LoP days</a></li>
                                        <li><a class="Text" href="../HRM/PayrollProcess.aspx" target="MainFrame">Payroll</a></li>
                                        <li><a class="Text" href='../HRM/PaySlip.aspx?type=PaySlip&" + this.Page.ClientQueryString + "' target="MainFrame">Payslip</a></li>
                                        <li><a class="Text" href="../HRM/IncentiveDetails.aspx" target="MainFrame">Incentives</a></li>
                                        <li><a class="Text" href="../HRM/TDSUpdate.aspx" target="MainFrame">TDS - Update</a></li>
                                        <li><a class="Text" href='../HRM/PaySlip.aspx?type=Bank Statement&" + this.Page.ClientQueryString + "' target="MainFrame">Letter to Bank</a></li>
                                        <li><a class="Text" href="../HRM/Quarter.aspx" target="MainFrame">Quarter</a></li>--%>
                                    </ul>

                                </li>
                                <li id="files" runat="server" class="drawer-dropdown">
                                    <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-list-alt"></i>  <span class="drawer-caret"></span></a>

                                    <ul class="drawer-dropdown-menu">

                                        
                                        <%--<li class="Text"><a href="../HRM/Exemption.aspx" target="MainFrame">Exemption</a></li>
                                        <li class="Text"><a href="../HRM/MasterSection.aspx" target="MainFrame">Section</a></li>
                                        <li class="Text"><a href="../HRM/TaxSlab.aspx" target="MainFrame">Tax Slab</a></li>
                                        <li class="Text"><a href="../HRM/ProfessionalTax.aspx" target="MainFrame">Prof Tax Slab</a></li>
                                        <li class="Text"><a href="../HRM/LWF.aspx" target="MainFrame">LWF</a></li>
                                        <li class="Text"><a href="../HRM/LWFGrade.aspx" target="MainFrame">LWF Grade</a></li>
                                        <li class="Text"><a href="../HRM/RentDetails.aspx" target="MainFrame">Rent Exemption</a></li>
                                        <li class="Text"><a href="../HRM/Incomefrmothrsuce.aspx" target="MainFrame">Other Income</a></li>
                                        <li class="Text"><a href="../HRM/InvestmentPlan.aspx" target="MainFrame">Investment Plan</a></li>
                                        <li class="Text"><a href="../HRM/InvestmentPlanProf.aspx" target="MainFrame">Investment Plan Prof Received</a></li>
                                        <li class="Text"><a href="../HRM/ProcessITComput.aspx" target="MainFrame">Process - IT Computation</a></li>
                                        <li class="Text"><a href="../HRM/ITComputation.aspx" target="MainFrame">IT Computation</a></li>
                                        <li class="Text"><a href="../HRM/BonusDetails.aspx" target="MainFrame">Bonus Details</a></li>--%>
                                        <%--<li><a class="Text" href="../UnderConstruction.aspx" target="MainFrame">EAClaim Details</a></li>--%>
                                    </ul>
                                </li>
                                <li id="Accounts" runat="server" class="drawer-dropdown">
                                    <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-group"></i>  <span class="drawer-caret"></span></a>

                                    <ul class="drawer-dropdown-menu">
                                        

                                        <%--<li><a class="Text" href="../HRM/StatutoryReport.aspx" target="MainFrame">Statutory</a></li>
                                        <li><a class="Text" href="../HRM/Accounts.aspx" target="MainFrame">Accounts</a></li>
                                        <li><a class="Text" href="../HRM/PlanProof.aspx" target="MainFrame">All Plan Proof</a></li>
                                        <li><a class="Text" href="../HRM/HRPaySlip.aspx" target="MainFrame">PaySlip</a></li>--%>
                                    </ul>
                                </li>
                                <li id="MIS" runat="server" class="drawer-dropdown">
                                    <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-tasks"></i>  <span class="drawer-caret"></span></a>

                                    <ul class="drawer-dropdown-menu">
                                        
                                        <%--<li><a class="Text" href="../UnderConstruction.aspx" target="MainFrame">MIS</a></li>--%>
                                    </ul>
                                </li>
                                <li id="Utility" runat="server" class="drawer-dropdown">

                                    <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-cog"></i>  <span class="drawer-caret"></span></a>

                                    <ul class="drawer-dropdown-menu">

                                        
                                        <%--<li><a class="Text" href="../ForwardExports/News.aspx" target="MainFrame">News</a></li>
                                        <li><a class="Text" href="../ForwardExports/News Status.aspx" target="MainFrame">News Status</a></li>
                                        <li><a class="Text" href="../HRM/MasterQuation.aspx" target="MainFrame">Master Question</a></li>
                                        <li><a class="Text" href="../HRM/CompanyProfile.aspx" target="MainFrame">Company Profile</a></li>
                                        <li><a class="Text" href="../HRM/EmployeeBenefits.aspx" target="MainFrame">Employee Benefits</a></li>
                                        <li><a class="Text" href="../HRM/WelfareMeasures.aspx" target="MainFrame">Welfare Measures</a></li>
                                        <li><a class="Text" href="../ForwardExports/EmpchangePass.aspx" target="MainFrame">ChangePassword</a></li>--%>
                                    </ul>
                                </li>
                           
                        
                    </ul>
                </nav>

           <%--  <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/iScroll/5.2.0/iscroll.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
         <!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-alpha/js/bootstrap.min.js"></script> -->   
            <script src="../Theme/MenuToggle/drawer.min.js" charset="utf-8"></script>
            <script>
                $(document).ready(function () {
                    $('.drawer').drawer();
                });
  </script>--%>


            <div id="content">
                <div class="container">
                    <div class="div_iframe">
                        <%--<iframe id="ifrmaster" runat="server"  name="MainFrame" class="iframe" frameborder="0" src="" scrolling="no"></iframe> --%>
                        <%--<iframe id="ifrmaster" runat="server" name="MainFrame" class="iframe" height="850px" frameborder="0" src="../Home/HRMHome.aspx" scrolling="no"></iframe>--%>
                        <iframe id="ifrmaster" runat="server" name="MainFrame" class="iframe" height="850px" frameborder="0" src="../Home/NewHroHome.aspx" scrolling="no"></iframe>
                    </div>
                    <%-- <div class="Widget-boxright" runat ="server" id="div1">
        <asp:Panel ID="Panel2" runat="server" CssClass="panel1" scrolling="no" frameborder="0" src="" >
          <ul>
          <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_PendingBooking" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_PendingBooking_Click1">Confirmation List</asp:LinkButton></li>                                          
     
         <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_emplist" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_emplist_Click">Employee List</asp:LinkButton></li>
       

          <div class="div_jobcostingframe">           
          <asp:Panel ID="Paneljobcostingframe" runat="server"  style="border:1px solid gray" Height="180px" Visible="false">
               <div class="FrameTitle1"><asp:Label ID="lbl1" runat="server" Text="Division"></asp:Label></div>
              
               <div class="div_ddl">
                      <asp:DropDownList ID="ddl_product" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true"
                data-placeholder="Product" ToolTip="Product" OnTextChanged="ddl_product_TextChanged" >              
               <asp:ListItem Value="0" Text=""></asp:ListItem>              
                
              </asp:DropDownList>

             </div>   
           
                <div class="Clear"></div> 
                <asp:Panel ID="Panelemplist" runat="server"  Height="125px" Visible="false" style="float:left;margin-left:8%;margin-top:1%; width:87%;height:125px;overflow:auto">             
                    <asp:GridView ID="Griddiv" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="Griddiv_RowDataBound" OnSelectedIndexChanged="Griddiv_SelectedIndexChanged" Visible="false">
                      <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                      <HeaderStyle CssClass="GridHeader" />
                      <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView> 
                </asp:Panel>  
              </asp:Panel>
           <div class="Clear"></div>            
          </div>
          

      <div class="Clear"></div>
            
            <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_cnfpro" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_cnfpro_Click">Confirmed/Probation</asp:LinkButton></li>

          <div class="div_jobcostingframe">           
          <asp:Panel ID="Panelcnfpro" runat="server"  style="border:1px solid gray" Height="180px" Visible="false">
               <div class="FrameTitle1"><asp:Label ID="Label1" runat="server" Text="Division"></asp:Label></div>
              
               <div class="div_ddl">
                      <asp:DropDownList ID="ddl_division" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true"
                data-placeholder="Product" ToolTip="Product" OnTextChanged="ddl_division_TextChanged">              
               <asp:ListItem Value="0" Text=""></asp:ListItem>              
                
              </asp:DropDownList>

             </div>   
           
                <div class="Clear"></div> 
                <asp:Panel ID="Panelcnfpro1" runat="server"  Height="125px" Visible="false" style="float:left;margin-left:8%;margin-top:1%; width:87%;height:125px;overflow:auto">             
                    <asp:GridView ID="Griddiv1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="Griddiv1_RowDataBound" OnSelectedIndexChanged="Griddiv1_SelectedIndexChanged"  Visible="false">
                      <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                      <HeaderStyle CssClass="GridHeader" />
                      <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView> 
                </asp:Panel>  
              </asp:Panel>
           <div class="Clear"></div>            
            </div>           

           <div class="Clear"></div>   
              
           <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_bdaylist" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_bdaylist_Click" >Birth Day List</asp:LinkButton></li>                
                <div class="Gridpnl1 MB10">
               <asp:Panel ID="Panelbdaylist" runat="server"  Height="125px" Visible="false">
                    <asp:GridView ID="grdbdaylist" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="grdbdaylist_RowDataBound" >                   
                       <Columns>
                      
                 <asp:TemplateField HeaderText ="BIRTHDAYLIST">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:120px">
                       <asp:Label ID="empname" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="60px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                       </Columns>
                        
                         <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>    
                </asp:Panel>  
                  </div>
              
            <%-- <div class="div_lnkbooking">
                    <asp:LinkButton ID="lnk_exrate" runat="server" ForeColor="Brown" style="text-decoration:none">Ex.Rate</asp:LinkButton>
                </div>    --%>


                    <%--  <asp:Panel ID="Paneldiv" runat="server"  CssClass="Gridpnlex" Visible="false">   
                    <asp:GridView ID="Griddivconpro" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
                        <Columns>
                    <%--       <asp:BoundField DataField="grddivi" HeaderText="Division" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="grdcon" HeaderText="Confirm" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="grdpro" HeaderText="Probation" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView> 
                </asp:Panel>--%>


                    <%--  <div class="Clear"></div>     
         <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <div style="font-size: 10pt"><b>Are you sure you want to Confirmed or not?</b></div>
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <div class="Clear"></div>
    </asp:Panel>
              </ul>--%>

                    <%--<asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label3" ></asp:ModalPopupExtender>
    <asp:Label ID="Label3" runat="server" Text="Label" Style="display: none;"></asp:Label>

        </asp:Panel>--%>

                    <%--<iframe id="Iframe1" runat="server"  name="MainFrame" class="iframe" frameborder="0" src="../ForwardExports/MDIParent1.aspx" scrolling="no"></iframe>
    </div>--%>
                </div>
            </div>

            </div>
    </form>
</body>
</html>
