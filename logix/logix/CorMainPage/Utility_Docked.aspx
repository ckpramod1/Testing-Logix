<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Utility_Docked.aspx.cs" EnableEventValidation="false"  Inherits="logix.CorMainPage.Utility_Docked" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
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


       <%-- <link href="../Theme/MenuToggle/drawer.min.css" rel="stylesheet" />--%>

     <link href="../Theme/Leftnav/font-awesome.css" rel="stylesheet" />
    <link href="../Theme/Leftnav/bootstrap.min.css" rel="stylesheet" />
    <link href="../Theme/Leftnav/mdb.min.css" rel="stylesheet" />

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
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
    <!-- <script type="text/javascript" src="../Scripts/jquery-1.2.6.min.js"></script>
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
            /* float: right;
            width: 200px;
            height: 600px;
            margin-right: 0.5%;
            margin-top: -0.5%;
            border:1px solid black
            background-color: #F5F5F2;
            -webkit-box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            -moz-box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            -webkit-border-radius: 5px 5px 5px 5px;
            -moz-border-radius: 5px 5px 5px 5px;
            border-radius: 5px 5px 5px 5px;*/
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
            float: left;
            width: 92%;
        }

        .div_txtPort1 {
            float: right;
            width: 90%;
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
            width: 25.3%;
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
            height: 125px;
            margin-left: 1%;
            margin-top: 1%;
            border: 1px solid Black;
        }

        .FrameTitle1 {
            font-family: sans-serif;
            float: left;
            margin-left: 10%;
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
            margin-left: 8%;
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


        .div_iframe {
            float: left;
            height: 645px;
            width: 100%;
        }
    </style>
    <script type="text/javascript">


        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }
    </script>

</head>
<body  class="drawer drawer--left">
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
                        <li><a href="javascript:void(0);"><i class="icon-share"></i> Utility</a></li>
                        <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-umbrella"></i> Utility<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="divUtility" runat="server"></div>
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
                        <li  class="brderright"><a href="javascript:void(0);" class="Fontbld"><i class="icon-share"></i> </a> </li>
                           

                                 <li id="Utility" runat="server" class="drawer-dropdown"><a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-group"></i>  <span class="drawer-caret"></span></a>
                                    <ul class="drawer-dropdown-menu">
                                        
                                    </ul>
                                 </li>

                          
                       
                    </ul>

                    <!-- Navigation Ends -->
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
                        <!-- Tabs-->
                        <iframe id="ifrmaster" runat="server" name="MainFrame" class="iframe" height="850px" frameborder="0" src="../Home/CORHome.aspx" scrolling="no"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>