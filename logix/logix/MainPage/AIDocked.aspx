<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AIDocked.aspx.cs" EnableEventValidation="false" Inherits="logix.MainPage.AIDocked" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--   <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
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

        .hide {
            display: none;
        }

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

        .panel1 {
            float: right;
            width: 180px;
            height: 600px;
            margin-right: 0%;
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

        .div_lnkbooking {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkapproval {
            float: left;
            margin-left: 1.5%;
            margin-top: 2.8%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnktool {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkuserlog {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkappr {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
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
            margin-left: 9%;
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

        .div_txtPort1 {
            width: 77.3%;
            float: left;
            margin-left: 8.95%;
            margin-top: 1%;
            margin-bottom: 0.5%;
            font-family: sans-serif;
            font-size: 10pt;
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

        .div_lnkprtcnty {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
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
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkexrate {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }
    </style>
    <script type="text/javascript">


        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }
    </script>
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
                height: 75px;
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
                height: 75px;
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

            #dock #TrendAnalysis {
                height: 80px;
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

            #dock #Utility {
                height: 80px;
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
        .div_iframe {
            float: left;
            height: 1150px;
            width: 100%;
            /*margin-left :-1%;
    margin-top:-1%;*/
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

        .rotate_text2 {
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
            padding-right: 40%;
        }

        .rotate_textuli {
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

</head>
<body>
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
            <a href="#" class="toggle-sidebar bs-tooltip" data-placement="bottom" data-original-title="Toggle navigation"><i class="icon-reorder"></i></a>
            <!-- /Sidebar Toggler -->
            <div id="sidebar" class="sidebar-fixed">
                <div id="sidebar-content">

                    <!--=== Navigation Starts ===-->


                    <ul id="nav">
                        <li class="current"><a href="javascript:void(0);"><i class="icon-share"></i>Air Imports</a>
                            <ul class="sub-menu">
                                <li id="setup" runat="server" visible="false">
                                    <a href="javascript:void(0);" class="Fontbld"><i class="icon-gear"></i>Sales</a>
                                    <ul class="sub-menu">
                                        <div id="divsales" runat="server"></div>
                                    </ul>

                                </li>

                                <li id="links" runat="server" visible="false"><a href="javascript:void(0);" class="Fontbld"><i class="icon-user-md"></i>Customer Service</a>

                                    <ul class="sub-menu">

                                        <div id="divcustomer2" runat="server"></div>

                                    </ul>
                                </li>

                                <li id="files" runat="server" visible="false">

                                    <a href="javascript:void(0);" class="Fontbld"><i class="icon-list-alt"></i>Shipment Details</a>

                                    <ul class="sub-menu">
                                        <div id="divShipp" runat="server"></div>
                                    </ul>
                                </li>

                                <li id="Accounts" runat="server" visible="false">
                                    <a href="javascript:void(0);" class="Fontbld"><i class="icon-group"></i>Accounts</a>

                                    <ul class="sub-menu">
                                        <div id="divAccounts" runat="server"></div>
                                    </ul>
                                </li>

                                <li id="Approval" runat="server" visible="false">
                                    <a href="javascript:void(0);" class="Fontbld"><i class="icon-check-sign"></i>Approval</a>

                                    <ul class="sub-menu">


                                        <div id="divApproval" runat="server"></div>

                                    </ul>
                                </li>


                                <li id="MIS" runat="server" visible="false">
                                    <a href="javascript:void(0);" class="Fontbld"><i class="icon-tasks"></i>MIS</a>

                                    <ul class="sub-menu">


                                        <div id="divMIS" runat="server"></div>

                                    </ul>
                                </li>



                                <li id="Utility" runat="server" visible="false">

                                    <a href="javascript:void(0);" class="Fontbld"><i class="icon-cog"></i>Utility</a>
                                    <ul class="sub-menu">

                                        <div id="divUtility" runat="server"></div>


                                    </ul>
                                </li>





                            </ul>
                        </li>
                    </ul>

                    <!-- Navigation Ends -->

                </div>
                <div id="divider" class="resizeable"></div>
            </div>

            <div id="content">
                <div class="container">
                    <div class="div_iframe" runat="server" id="div_iframe">
                        <iframe id="ifrmaster" runat="server" name="MainFrame" class="iframe" frameborder="0" src="../Home/AIHome.aspx" scrolling="Yes"></iframe>

                    </div>
                    <%-- <div class="Widget-boxright" runat ="server" id="div1">

            <asp:Panel ID="Panel2" runat="server" CssClass="panel1" scrolling="no" frameborder="0" src="" >

                <ul>
                  <li><i class="icon-angle-right PR10"></i>

                <asp:LinkButton ID="lnk_PendingBooking" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_PendingBooking_Click">Pending Booking</asp:LinkButton></li>                
                <div class="Gridpnl1">
               <asp:Panel ID="Panelbooking" runat="server"  Height="125px" Visible="false">
                    <asp:GridView ID="grdpendingbook1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdpendingbook1_RowDataBound" OnSelectedIndexChanged="grdpendingbook1_SelectedIndexChanged" Visible="false" >                   
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>    
                     <div><br /></div>                 
                  </asp:Panel>  
                  </div>
                <div class="Clear"></div>                      
               
              
             
                <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_PendingApproval" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_PendingApproval_Click">Pending Approval</asp:LinkButton></li>           
               <div class="Gridpnl1"> 
               <asp:Panel ID="PanelApproval" runat="server"  Height="125px" Visible="false">      
                    &nbsp;<asp:GridView ID="GrdPending1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPending1_RowDataBound" OnSelectedIndexChanged="GrdPending1_SelectedIndexChanged"  Visible="false">
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView> 
              </asp:Panel>
               </div>
                             <div class="Clear"></div>                      


        <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_Tools" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_Tools_Click">Tools</asp:LinkButton></li>           
           <div class="pnl_tool">
             <asp:Panel ID="panel_tool" runat="server" style="border:1px solid grey;"  Height="125px" Visible="false">    
                <div class="lbl_con"><asp:Label ID="lbl_conversion" runat="server" ForeColor="Brown" Text="CONVERSION TOOLS" CssClass="LabelValue"></asp:Label> </div>     
                    <div class="lnk_common"><asp:LinkButton ID="lnk_curr" CssClass="LabelValue" runat="server" ForeColor="Navy" style="text-decoration:none" Text="Country and Currency" OnClick="lnk_curr_Click"></asp:LinkButton></div> 
                    <div class="div_Break"></div>
                    <div class="lnk_common"><asp:LinkButton ID="lnl_inco" CssClass="LabelValue" runat="server" ForeColor="Navy" style="text-decoration:none" Text="Inco Terms" OnClick="lnl_inco_Click"></asp:LinkButton></div> 
                    <div class="div_Break"></div>
                    <div class="lnk_common"><asp:LinkButton ID="lnk_length" CssClass="LabelValue" runat="server" ForeColor="Navy" style="text-decoration:none" Text="Length Conversation" OnClick="lnk_length_Click"></asp:LinkButton></div> 
                    <div class="div_Break"></div>
                    <div class="lnk_common"><asp:LinkButton ID="lnk_weight" CssClass="LabelValue" runat="server" ForeColor="Navy" style="text-decoration:none" Text="Weigth Conversation" OnClick="lnk_weight_Click"></asp:LinkButton></div> 
                    <div class="div_Break"></div>
                    <div class="lnk_common"><asp:LinkButton ID="lnk_volume" CssClass="LabelValue" runat="server" ForeColor="Navy" style="text-decoration:none" Text="Volume Conversation" OnClick="lnk_volume_Click"></asp:LinkButton></div>              
                </asp:Panel>
               </div>                
                             <div class="Clear"></div>                      


                <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_PendingCountry" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_PendingCountry_Click">Port Country</asp:LinkButton></li>
         
                <div class="div_lnkport">
                <asp:TextBox ID="txtPort1" runat="server" CssClass="Text1" OnTextChanged="txtPort1_TextChanged" AutoPostBack="true"/>
                </div>   
          <div class="Gridpnl1">
                <asp:Panel ID="pnlPortCountry1" runat="server"  Height="125px" Visible="false">                 
                    <asp:GridView ID="GrdPort1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
                      <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                      <HeaderStyle CssClass="GridHeader" />
                      <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView> 
                </asp:Panel>  
               </div>
                        <div class="Clear"></div>                      

          
                 

                
            <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_userlogged" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_userlogged_Click" >User Logged in</asp:LinkButton></li>                                                       
             <div class="Gridpnl1"> 
                  <asp:Panel ID="Paneluserlogged" runat="server"  Height="125px" Visible="false">           
                    <asp:GridView ID="grduserlogged" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grduserlogged_RowDataBound" OnSelectedIndexChanged="grduserlogged_SelectedIndexChanged" Visible="false">
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView> 
                 </asp:Panel>
                </div>
           
                  <div class="Clear"></div>                      


           
                <li><i class="icon-angle-right PR10"></i><asp:LinkButton ID="lnk_unclosedjobs" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_unclosedjobs_Click">Unclosed Jobs</asp:LinkButton></li>    
            <div class="Gridpnl1">
                <asp:Panel ID="PanelUnclosedjob" runat="server"  Height="100px" Visible="false">        
                    <asp:GridView ID="grdunclosejobs" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdunclosejobs_RowDataBound" OnSelectedIndexChanged="grdunclosejobs_SelectedIndexChanged" Visible="false">
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView> 
                </asp:Panel>
               </div>                                               
                                <div class="Clear"></div>                      

                                
                <asp:Panel ID="PanelApproved11" runat="server"  ScrollBars="Vertical"  CssClass="Gridpnl">           
                    <asp:GridView ID="GrdApproved11" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" >
                      <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                      <HeaderStyle CssClass="GridHeader" />
                      <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView> 
                </asp:Panel> 
            
           
             <li><i class="icon-angle-right PR10"></i>
                    <asp:LinkButton ID="lnk_exrate" runat="server" ForeColor="Brown" style="text-decoration:none" OnClick="lnk_exrate_Click">Ex.Rate</asp:LinkButton>
                </li>    
                                                         
                <asp:Panel ID="Panelexrate" runat="server"  CssClass="Gridpnlex" Visible="false">   
                    <asp:GridView ID="Gridexrate" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
                        <Columns>
                           <asp:BoundField DataField="excurr" HeaderText="Curr" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="localexrate" HeaderText="Local" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="osexrate" HeaderText="OS" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView> 
                </asp:Panel>
                               <div class="Clear"></div>                      


        </asp:Panel>

                 <%--  <iframe id="Iframe1" runat="server"  name="MainFrame" class="iframe" frameborder="0" src="../ForwardExports/MDIParent1.aspx" scrolling="no"></iframe>--%>
                </div>
                --%>
    
            </div>
        </div>
        </div>


    </form>
</body>
</html>
