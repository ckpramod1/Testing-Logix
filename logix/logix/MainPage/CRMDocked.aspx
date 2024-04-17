<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRMDocked.aspx.cs" Inherits="logix.MainPage.CRMDocked" %>

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
            font-weight: bold;
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
            margin-left: 0%;
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
            font-size: 10.6pt;
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
            padding-bottom: 40%;
            padding-right: 50%;
        }

        .icon-angle-right {
            margin: -3px 0px 0px 0px !important;
        }
    </style>
     <link href="../Theme/Leftnav/font-awesome.css" rel="stylesheet" />

    <link href="../Theme/Leftnav/bootstrap.min.css" rel="stylesheet" />
    <link href="../Theme/Leftnav/mdb.min.css" rel="stylesheet" />
    <%--<link href="../Theme/MenuToggle/drawer.min.css" rel="stylesheet" />--%>
    <!--<script type="text/javascript" src="../Scripts/jquery-1.2.6.min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script> -->
    <!--<script type="text/javascript">
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
                $("#dock li ul").height($(window).height());
            }, function () {
                $(this).find("ul.free").animate({ left: "-180px" }, 200);
            });
        });
    </script> -->


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
                        <li><a href="javascript:void(0);"><i class="icon-share"></i> CRM</a></li>
                        <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-chevron-right"></i> CRM<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                    <li class="liststylenone"><a href="../CRMNew/Customer.aspx" target="MainFrame" class="waves-effect">Prospect Customer</a></li>
                                        <li class="liststylenone"><a href="../CRMNew/AssignCalls.aspx" target="MainFrame" class="waves-effect">Assign Calls</a></li>
                                        <li class="liststylenone"><a href='../CRM/TeleSales.aspx?type=Initiate Contact&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">TeleCaller</a></li>
                                        <li class="liststylenone"><a href='../CRM/CRMSalesDetails.aspx?type=Schedule Visit&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Call Details</a></li>


                                    <%--    <li class="liststylenone"><a href="../CRM/CustomerBudgetNew.aspx" target="MainFrame" class="waves-effect">Budget</a></li>--%>
                                        
                                    
                                    <li class="liststylenone"><a href='../CRM/Quotation.aspx?type=Quotation&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Quotation</a></li>
                                        <li class="liststylenone"><a href="../CRM/Booking.aspx" target="MainFrame" class="waves-effect">Booking </a></li>

<%--                                    <li class="liststylenone"><a href='../Sales/Quotation.aspx?type=Quotation&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Quotation</a></li>
                                        <li class="liststylenone"><a href="../Sales/Booking.aspx" target="MainFrame" class="waves-effect">Booking </a></li>--%>



                                        <li class="liststylenone"><a href='../CRM/NewCallsAdvise.aspx?type=CRM&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">New Call Advise</a></li>
                                        <li class="liststylenone"><a href='../CRM/FollowupAdvise.aspx?type=CRM&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Followup Advise</a></li>
                                        <li class="liststylenone"><a href='../CRM/SalesVisitAdvise.aspx?type=crm&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Sales Visit Advise</a></li>
                                        <li class="liststylenone"><a href='../CRM/DSR .aspx?type=crm&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">DSR</a></li>
                                        <li class="liststylenone"><a href='../CRM/CallReport.aspx?type=CRM&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Call Reports</a></li>


                                        <li class="liststylenone"><a href='../CRM/CallsVsAppointments.aspx?type=CRM&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Calls Vs Appointments</a></li>
                                        <li class="liststylenone"><a href='../CRM/AppoinentVsQuotaion.aspx?type=CRM&" + this.Page.ClientQueryString + "' target="MainFrame" class="waves-effect">Quotes Vs Booking</a></li>
                                        <li class="liststylenone"><a href="../CRM/appdetailsmonth.aspx" target="MainFrame" class="waves-effect">Appointments</a></li>
                                        <li class="liststylenone"><a href="../CRM/CRMAppointmentCancel.aspx" target="MainFrame" class="waves-effect">Cancel Appointments</a></li>
                                        <li class="liststylenone"><a href="../CRM/BudgetSales.aspx" target="MainFrame" class="waves-effect">Budget vs Actual</a></li>
                                        <li class="liststylenone"><a href="../CRM/MasterNew.aspx" target="MainFrame" class="waves-effect">Agent Query</a></li>
                                </ul>
                            </div>
                        </li>
                        <li><a class="collapsible-header waves-effect arrow-r"><i class="fa fa-hand-pointer-o"></i> Reports<i class="fa fa-angle-down rotate-icon"></i></a>
                            <div class="collapsible-body">
                                <ul class="list-unstyled">
                                  <div id="divmenu" runat="server"></div>
                                  
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
                        <li class="brderright"><a href="javascript:void(0);"><i class="icon-share"></i> </a> </li>
                                <li class="drawer-dropdown">
                                    <a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-gear"></i>  <span class="drawer-caret"></span></a>
                                    <ul class="drawer-dropdown-menu">
                                       
                                    </ul>
                                </li>

                                <li id="links" runat="server" class="drawer-dropdown"><a class="drawer-menu-item" data-target="#" href="#" data-toggle="dropdown" role="button" aria-expanded="false"><i class="icon-user-md"></i>  <span class="drawer-caret"></span></a>

                                    <ul class="drawer-dropdown-menu">
                                        

                                </li>

                           
                       
                    </ul>
              
</nav>
  <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
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
                    <div class="div_iframe" runat="server">
                        <iframe id="ifrmaster" runat="server" name="MainFrame" class="iframe" frameborder="0" src="../CRM/MainFrameAppointments.aspx" scrolling="Yes"></iframe>
                    </div>
                </div>
            </div>



        </div>




    </form>
</body>
</html>
