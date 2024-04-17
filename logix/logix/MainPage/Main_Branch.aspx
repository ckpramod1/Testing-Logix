<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Branch.aspx.cs" EnableEventValidation="false" Inherits="logix.MainPage.Main_Branch" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
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
    <%--<script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>--%>

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

    <script type="text/javascript">

        function ConfirmMsg() {
            var ConfirmValue = confirm('The Outstanding Results will take more time through this option "Outstanding - Online". Instead of you may try "Outstanding - Schedle" Do You want to Continue ?');
            if (ConfirmValue == true) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>

    <%-- <link href="../Theme/MenuToggle/drawer.min.css" rel="stylesheet" />--%>
    <link href="../Theme/Leftnav/font-awesome.css" rel="stylesheet" />
    <link href="../Theme/Leftnav/bootstrap.min.css" rel="stylesheet" />
    <link href="../Theme/Leftnav/mdb.min.css" rel="stylesheet" />
    <link href="../Styles/Submenu.css" rel="stylesheet" />
    <%--   <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
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

        .div_lnkbooking {
            float: left;
            margin-left: 1%;
            margin-top: 5.5%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkpendfa {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkdep {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkincnotbook {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkinco {
            float: left;
            margin-left: -57%;
            margin-top: 14%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnkcrd {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
            font-family: sans-serif;
            font-size: 10pt;
        }

        .div_lnktds {
            float: left;
            margin-left: 1%;
            margin-top: 3%;
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

        .div_lnkunclosed {
            float: left;
            margin-left: 1%;
            margin-top: 3.5%;
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
            margin-left: 1%;
            margin-top: 1%;
            overflow: auto;
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

        .Text1 {
            font-family: sans-serif;
            font-size: 10pt;
            font-style: normal;
            border-color: #999997;
            /*C9C9C9    CECFCA */
            border: 1px solid #999997;
            text-transform: uppercase;
        }

        ul.collapsible.collapsible-accordion li:nth-child(2) ul,
        ul.collapsible.collapsible-accordion li:nth-child(3) ul {
            max-height: fit-content !important;
        }

        ul.collapsible.collapsible-accordion li:nth-child(4) ul {
            max-height: 244px !important;
        }

        ul.collapsible.collapsible-accordion li:nth-child(5) ul {
            max-height: 253px !important;
        }

        ul.collapsible.collapsible-accordion li:nth-child(6) ul {
            max-height: 217 !important;
        }

        ul.collapsible.collapsible-accordion li:nth-child(9) ul {
            max-height: 246px !important;
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

            #dock #voucher {
                height: 63px;
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

                #dock #voucher:hover {
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #Approval {
                height: 63px;
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

                #dock #Approval:hover {
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #Register {
                height: 63px;
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

                #dock #Register:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #Outstanding {
                height: 85px;
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

                #dock #Outstanding:hover {
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

            /*#dock #Approval {
                height:63px;
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
                }*/

            #dock #MIS {
                height: 45px;
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

            #dock #trend {
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

                #dock #trend:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

            #dock #XML {
                height: 45px;
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

                #dock #XML:hover {
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

            #dock #operationmis {
                height: 90px;
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

                #dock #operationmis:hover {
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

            #dock #budget {
                height: 90px;
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

                #dock #budget:hover {
                    color: Blue;
                    background: #6d8391;
                    background-image: -webkit-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -moz-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -ms-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: -o-linear-gradient(top, #6d8391, #a6a7a8);
                    background-image: linear-gradient(to bottom, #6d8391, #a6a7a8);
                    text-decoration: none;
                }

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
            width: 55px;
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
            width: 55px;
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
            width: 55px;
            color: White;
            font-weight: bold;
            /*padding-top:6%;
     padding-left:40%;*/
            padding-bottom: 50%;
            padding-right: 80%;
        }

        .rotate_txt2 {
            position: absolute;
            -webkit-transform: rotate(180deg);
            -moz-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            -o-transform: rotate(180deg);
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            behavior: url(PIE.htc);
            width: 50px;
            color: White;
            font-weight: bold;
            /*padding-top:6%;
     padding-left:40%;*/
            padding-bottom: 50%;
            padding-right: 40%;
        }

        .rotate_txt3 {
            position: absolute;
            -webkit-transform: rotate(180deg);
            -moz-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            -o-transform: rotate(180deg);
            font-family: sans-serif;
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            behavior: url(PIE.htc);
            width: 55px;
            color: White;
            font-weight: bold;
            /*padding-top:6%;
     padding-left:40%;*/
            padding-bottom: 50%;
            padding-right: 80%;
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
            padding-bottom: 50%;
            padding-right: 80%;
        }

        .navigation-3 li a {
            padding-left: 30px !important;
            display: block;
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

        <div id="container" class="fixed-header">
            <!-- Sidebar Toggler -->
            <a href="#" class="toggle-sidebar bs-tooltip" data-placement="bottom" data-original-title="Toggle navigation" style="display: none;"><i class="icon-reorder"></i></a>
            <!-- /Sidebar Toggler -->

            <button type="button" class="drawer-toggle drawer-hamburger" title="Toggle Navigation" style="display: none;">
                <span class="sr-only">toggle navigation</span>
                <span class="drawer-hamburger-icon"></span>
            </button>

            <!-- SideNav slide-out button -->
            <div class="custom-my-2">
                <a href="#" data-activates="slide-out" class="button-collapse black-text"><%--<i class="fa fa-bars"></i>--%><img src="../Theme/assets/img/buttonIcon/active/menu_bar.png" /></a>
            </div>
            
            <!-- Sidebar navigation -->
            <div class="maindiv">
            <div id="slide-out" class="side-nav sn-bg-4 fixed" style="transform: translateX(-100%);">
                <ul class="custom-scrollbar">

                    <!-- Side navigation links -->
                    <li>
                        <ul class="collapsible collapsible-accordion">
                            <li><a href="javascript:void(0);"><i class="icon-share"></i>Financial Accounts</a> <span style="display: inline-block; float: right; margin: -26px 9px 0px 0px; color: red;">
                                <asp:Label ID="lblLoginYear" runat="server" Visible="false"></asp:Label></span></li>
                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-shield hide"></i>Account Info <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="div_accountinfo" runat="server"></div>
                                    </ul>
                                </div>
                            </li>

                            <%--  <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-dedent"></i> Vouchers <i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="div_Vouchers" runat="server"></div>
                                </ul>
                            </div>
                        </li>--%>

                            <%-- newone kalai --%>
                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-dedent hide"></i>Proforma Vouchers <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="div_Vouchers" runat="server"></div>
                                    </ul>
                                </div>
                            </li>

                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-dedent hide"></i>Approved Vouchers <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="div_App" runat="server"></div>
                                    </ul>
                                </div>
                            </li>
                            <%-- end--%>

                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-code hide"></i>Approval <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="divApproval" runat="server"></div>
                                    </ul>
                                </div>
                            </li>
                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-file-text-o hide"></i>Reports <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="divReports" runat="server"></div>
                                    </ul>
                                </div>
                            </li>
                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-laptop hide"></i>Outstanding <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="divOutstanding" runat="server"></div>
                                    </ul>
                                </div>
                            </li>
                            <%--<li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-file-text-o"></i> M I S <i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-MISunstyled">
                                     <div id="divMIS" runat="server"></div>
                                </ul>
                            </div>
                        </li>--%>
                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-user-md hide"></i>Query <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="divQuery" runat="server"></div>
                                        <div style="display: none;">
                                            <li><a class="Text" target="MainFrame"><strong>AirExport</strong></a></></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=HAWBL&trantype=AE&" + this.Page.ClientQueryString + "' target="MainFrame">HAWBL #</a></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=Shipper / Consignee&trantype=AE&" + this.Page.ClientQueryString + "' target="MainFrame">Shipper / Consignee</a></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=Flight&trantype=AE&" + this.Page.ClientQueryString + "' target="MainFrame">Flight #</a></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=MAWBL&trantype=AE&" + this.Page.ClientQueryString + "' target="MainFrame">MAWBL #</a></li>
                                            <li><a class="Text" href='../ForwardExports/BLRegister.aspx?type=BL Register&&trantype=AE&" + this.Page.ClientQueryString + "' target="MainFrame">BL Register</a></li>
                                            <li><a class="Text" href='../ForwardExports/CustomerQuery.aspx?type=AE&" + this.Page.ClientQueryString + "' target="MainFrame">Inv_ CNOps CustomerWise</a></li>

                                            <li><b><a class="Text" target="MainFrame"><strong>AirImport</strong></a></b></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=HAWBL&&trantype=AI&" + this.Page.ClientQueryString + "' target="MainFrame">HAWBL #</a></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=Shipper / Consignee&&trantype=AI&" + this.Page.ClientQueryString + "' target="MainFrame">Shipper / Consignee</a></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=Flight&&trantype=AI&" + this.Page.ClientQueryString + "' target="MainFrame">Flight #</a></li>
                                            <li><a class="Text" href='../AE/AIEBIQuery.aspx?type=MAWBL&&trantype=AI&" + this.Page.ClientQueryString + "' target="MainFrame">MAWBL #</a></li>
                                            <li><a class="Text" href='../ForwardExports/BLRegister.aspx?type=BL Register&&trantype=AI&" + this.Page.ClientQueryString + "' target="MainFrame">BL Register</a></li>
                                            <li><a class="Text" href='../ForwardExports/CustomerQuery.aspx?type=AI&" + this.Page.ClientQueryString + "' target="MainFrame">Inv_ CNOps CustomerWise</a></li>

                                            <li><b><a class="Text" target="MainFrame"><strong>OceanExport</strong></a></b></li>
                                            <li><a class="Text" href='../ForwardExports/BL Print.aspx?type=DODetails&trantype=FE&" + this.Page.ClientQueryString + " ' target="MainFrame">BL Number</a></li>
                                            <li><a class="Text" href='../ForwardExports/BLRegister.aspx?type=BL Register&" + this.Page.ClientQueryString + "' target="MainFrame">BL Register</a></li>
                                            <li><a class="Text" href='../Accounts/ShipperConsigneeRPT.aspx?type=Shipper / consignee&trantype=FE&" + this.Page.ClientQueryString + "' target="MainFrame">Shipper/consignee</a></li>
                                            <li><a class="Text" href='../Accounts/ShipperConsigneeRPT.aspx?type=MBL&trantype=FE&" + this.Page.ClientQueryString + "' target="MainFrame">MBL #</a></li>
                                            <li><a class="Text" href='../Accounts/ShipperConsigneeRPT.aspx?type=Container&trantype=FE&" + this.Page.ClientQueryString + "' target="MainFrame">Container #</a></li>
                                            <li><a class="Text" href='../ForwardExports/Query.aspx?type=Queries&trantype=FE&" + this.Page.ClientQueryString + "' target="MainFrame">Queries</a></li>
                                            <li><a class="Text" href='../ForwardExports/CustomerQuery.aspx?type=Inv _ CNOps CustomerWise&trantype=FE&" + this.Page.ClientQueryString + "' target="MainFrame">Inv_ CNOps CustomerWise</a></li>

                                            <li><b><a class="Text" target="MainFrame"><strong>OceanImport</strong></a></b></li>
                                            <li><a class="Text" href='../ForwardExports/BL Print.aspx?type=DODetails&trantype=FI&" + this.Page.ClientQueryString + " ' target="MainFrame">BL Number</a></li>
                                            <li><a class="Text" href='../Accounts/ShipperConsigneeRPT.aspx?type=Shipper / Consignee&trantype=FI&" + this.Page.ClientQueryString + "' target="MainFrame">Shipper/consignee</a></li>
                                            <li><a class="Text" href='../Accounts/ShipperConsigneeRPT.aspx?type=MBL&trantype=FI&" + this.Page.ClientQueryString + "' target="MainFrame">MBL #</a></li>
                                            <li><a class="Text" href='../Accounts/ShipperConsigneeRPT.aspx?type=Container&trantype=FI&" + this.Page.ClientQueryString + "' target="MainFrame">Container #</a></li>
                                            <li><a class="Text" href='../ForwardExports/Query.aspx?type=Queries&trantype=FI&" + this.Page.ClientQueryString + "' target="MainFrame">Queries</a></li>
                                            <li><a class="Text" href='../ForwardExports/CustomerQuery.aspx?type=Inv _ CNOps CustomerWise&trantype=FI&" + this.Page.ClientQueryString + "' target="MainFrame">Inv_ CNOps CustomerWise</a></li>

                                        </div>
                                    </ul>
                                </div>
                            </li>
                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-paste hide" ></i>Utility <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="divUtility" runat="server"></div>
                                    </ul>
                                </div>
                            </li>
                            <%--<li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-dashboard"></i> Shipment Details <i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                     <div id="divShipmentDetails" runat="server"></div>
                                </ul>
                            </div>
                        </li>--%>
                            <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-table hide"></i>FA Edi <i class="fa fa-angle-down rotate-icon"></i></a>
                                <div class="collapsible-body">
                                    <ul class="list-unstyled">
                                        <div id="divFA" runat="server"></div>
                                    </ul>
                                </div>
                            </li>

                        </ul>
                    </li>
                    <!--/. Side navigation links -->
                </ul>
                <!-- <div class="sidenav-bg mask-strong"></div>-->
            </div>
                </div>
            <!--/. Sidebar navigation -->
            <script src="../Theme/Leftnav/jquery-3.2.1.min.js"></script>

            <script src="../Theme/Leftnav/mdb.min.js"></script>

            <script>

                // SideNav Initialization
                $(".button-collapse").sideNav();

                new WOW().init();

            </script>

            <nav class="drawer-nav" role="navigation" style="display: none;">

                <ul id="nav" class="drawer-menu">
                    <li class="brderright"><a href="javascript:void(0);"><i class="icon-share"></i></a></li>

                    <li id="AccountInfo" runat="server" class="drawer-dropdown"><a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-gear"></i><span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">
                        </ul>

                    </li>
                    <li id="Vouchers" runat="server" class="drawer-dropdown"><a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-check-sign"></i><span class="drawer-caret"></span></a>

                        <ul class="drawer-dropdown-menu">
                        </ul>

                    </li>
                    <li id="Approval" runat="server" class="drawer-dropdown">

                        <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-tasks"></i><span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">
                        </ul>
                    </li>
                    <li id="Reports" runat="server" class="drawer-dropdown"><a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-group"></i><span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">
                        </ul>
                    </li>
                    <li id="OutstandingNew" runat="server" class="drawer-dropdown">
                        <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-list-alt"></i><span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">
                        </ul>
                    </li>
                    <%--<li id="MIS" runat="server" class="drawer-dropdown">
                        <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-tasks"></i> <span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">

                        </ul>
                    </li>--%>
                    <li id="Query" runat="server" class="drawer-dropdown">

                        <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-cog"></i><span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">
                        </ul>
                    </li>
                    <li id="utility" runat="server" class="drawer-dropdown">

                        <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-list-alt"></i><span class="drawer-caret"></span></a>

                        <ul class="drawer-dropdown-menu">
                        </ul>
                    </li>

                    <%-- <li id="ShipmentDetails"  runat="server"   class="drawer-dropdown" style="display:none;">
                        <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-list-alt"></i><span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">
                        </ul>
                    </li>--%>

                    <li id="FAEdi" runat="server" class="drawer-dropdown">
                        <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-list-alt"></i><span class="drawer-caret"></span></a>
                        <ul class="drawer-dropdown-menu">
                        </ul>
                    </li>

                </ul>

            </nav>

            <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/iScroll/5.2.0/iscroll.js"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
            <!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-alpha/js/bootstrap.min.js"></script> -->
            <script src="../Theme/MenuToggle/drawer.min.js" charset="utf-8"></script>
            <script>
                $(document).ready(function () {
                    $('.drawer').drawer();
                });
            </script>

            <div id="content">
                <div class="container">

                    <div class="div_iframe" runat="server" id="div_iframe">
                        <iframe id="ifrmaster" runat="server" name="MainFrame" class="iframe" frameborder="0" src="../Home/Branch_home.aspx" scrolling="no"></iframe>
                    </div>

                </div>
            </div>

        </div>
    </form>
</body>

</html>
