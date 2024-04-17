<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainFormNew.aspx.cs" Inherits="logix.MainFormNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html lang="en-US" prefix="og: http://ogp.me/ns#">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>

    <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">

    <!-- Theme -->
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="Theme/assets/product/css/systemtproduct.css" rel="stylesheet" />
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

    <!-- Demo JS -->
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>

    <style type="text/css">
        .header {
            z-index: 10030;
            width: 100%;
            margin: 0px auto;
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
        .navbar .dropdown-menu {
    right: 0;
    left: auto;
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
            background-color: White;
            border: 0px solid #f00;
            /*float: left;*/
            /*height: 592px !important;*/
            height: 613px !important;
            margin-left: auto;
            margin-top: auto;
            width: 1350px;
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

        @media only screen and (max-width: 360px) {

        .navbar .container .navbar-brand {
            width: 70%;
            height: 50px;
            display: flex;
            align-items: center;
            overflow: visible;
        }

        #lblcompany {
            width: 100%;
            font-size: 30px;
            margin-left: 10px;
        }

        span#lblcompany {
            margin: 7px 0px 0px 50px !important;
        }
    }

        @media only screen and (max-width: 1280px) {

            .header {
                z-index: 10030;
                width: 100%;
                margin: 0px auto;
            }
        }

        body {
            margin: 0px auto !important;
            width: 1366px;
            height: 585px;
        }

        .DataList1 input {
            cursor: pointer !important;
        }

        .DataList1 td {
            margin: 0px 0px 0px 0px;
            padding: 25px 35px 25px 20px;
        }

        .datatablealign table input {
            cursor:pointer;
        }
 
         .datatablealign table td {
            margin: 0px 0px 0px 0px;
            padding: 110px 0px 25px 470px;
        }

    </style>

        <link rel="stylesheet" href="Theme/marquee/css/marquee.css" />
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/FormMain.css" rel="stylesheet" />

    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <!--  <script src="ScriptsAuto/bootstrap.jquery.min.js" type ="text/javascript"></script>
    <script src="ScriptsAuto/bootstrap.min.js" type ="text/javascript"  ></script>
    <script src="ScriptsAuto/jquery-ui.min.js" type ="text/javascript"></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" /> -->

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
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
        //javascript: window.history.forward(1);
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

        };

    </script>

  <%--  <script type="text/javascript">

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

</head>

<style type="text/css">
    /*body {
        background: url(Theme/assets/img/pic1.jpg) no-repeat left top;
        width: 1366px;
        height: 642px;
    }*/
</style>

<style type="text/css">

    @media only screen and (max-width: 1280px) {
        body {
            background: url(Theme/assets/img/pic1280.jpg) no-repeat left top;
            width: 1280px;
            /*height: 768px;*/
             
        }
    }
    marquee {
    margin-top: 10px;
    color:#fff;
}
    .NewsMarquee {
        color:#fff;
        border:0px solid #f00;
    }
   
     img#img_Logo {
    margin-top: 4px;
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
    color: #1b5b66!important;
}
.user_profile_email {
    width: 100%;
}

i.icon-home {
    font-size: 15px;
    width: 24px;
    height: 24px;
    line-height: 25px;
    background: white;
    display: inline-block;
    color: var(--navbarcolor);
    border-radius: 50%;
}

a#lnkbtn img {
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
    margin-top: 2px!important;
    width: 95px !important;
}
.navbar {
    min-height: 50px !important;
}
</style>

<body>

    <!-- Header -->
    <form id="form1" runat="server">
        <header class="header navbar navbar-fixed-top" role="banner">
            <!-- Top Navigation Bar -->

            <div class="container">

                <!-- Only visible on smartphones, menu toggle -->

                <!-- Logo -->
                <a class="navbar-brand" href="#">
                    <asp:Image ID="img_Logo" runat="server"  />
                    <asp:Label ID="lblcompany" runat="server" Style="text-transform: capitalize;"></asp:Label>
                    
                </a>
                <!-- /logo -->

                <!-- Sidebar Toggler -->
                <!-- <a href="#" class="toggle-sidebar bs-tooltip" data-placement="bottom" data-original-title="Toggle navigation"><i class="icon-reorder"></i></a> -->
                <!-- /Sidebar Toggler -->

                <!-- Top Left Menu -->
                <div class="LoginCompanyName"></div>

                <!-- /Top Left Menu -->

                <!-- Top Right Menu -->
                <ul class="nav navbar-nav navbar-right">
                    <!-- Temp Manoj for Appraisal -->

                    <li style="display: none;">
                        <asp:LinkButton ID="lnkreviewer" runat="server" OnClick="lnkreviewer_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; display: none"></asp:LinkButton></li>

                    <li style="display: none;">
                        <asp:LinkButton ID="lnkbtnapp" runat="server" OnClick="lnkbtnapp_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; display: none"></asp:LinkButton></li>

                    <li style="display: none;">
                        <asp:LinkButton ID="lnkbtnpendemp" runat="server" OnClick="lnkbtnpendemp_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; display: none"></asp:LinkButton></li>

                    <li id="lnkbtncooli" runat="server" style="display: none;">
                        <asp:LinkButton ID="lnkbtncoo" runat="server" OnClick="lnkbtncoo_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; display: none"></asp:LinkButton></li>

                    <li>
                        <asp:LinkButton ID="lnkbtn" runat="server" OnClick="lnkbtn_Click1" Style="text-transform: capitalize; color: #ffffff; text-decoration: none; display: none;"></asp:LinkButton></li>
                    <%--  <li><a href="#" >HOME</a></li>--%>
                    <li>
                        <asp:LinkButton ID="lnkhome" runat="server" OnClick="lnkhome_Click" Style="text-transform: capitalize; color: #ffffff; text-decoration: none;" ToolTip="Home"> <%--<img src="Theme/assets/icon/home_ic.png" />--%>
                            <i class="icon-home"></i>
                        </asp:LinkButton></li>
                    <!-- Project Switcher Button -->
                    <!--<li class="dropdown"><a href="#" class="project-switcher-btn dropdown-toggle"><i class="icon-arrow-down"></i></a></li>-->
                    <!-- User Login Dropdown -->
                    <li class="dropdown user"><a href="#" class="dropdown-toggle user_img_top" data-toggle="dropdown">
                        <asp:Image ID="img_emp" runat="server" Width="32" Height="32" data-toggle="dropdown" ImageUrl="~/images/CImage.png" />
                    </a>
                        <ul class="dropdown-menu extended notification">
                            <li class="profile_div">
                                <asp:Image ID="img_emp1" runat="server" CssClass="user_profile_pic" data-toggle="dropdown" ImageUrl="~/images/CImage.png" />
                                <div class="user_profile_name">
                                    <asp:Label ID="lblcname" runat="server" Style="text-transform: capitalize;"></asp:Label></div>
                                <div class="user_profile_name">
                                    <asp:Label ID="lbldesg" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label></div>
                                <div class="user_profile_name">
                                    <asp:Label ID="lbldept" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label></div>
                                <div class="user_profile_name">
                                    <asp:Label ID="lblport" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label></div>
                                <div class="user_profile_email">
                                    <asp:Label ID="Label1" runat="server" CssClass="LabelValue" Style="text-transform: capitalize;"></asp:Label>
                                </div>
                            </li>
                            <li class="footer">
                                <div class="floatl user_profile_btn">
                                    <%-- <button class="btn btn-xs btn-primary" onclick="window.location='EmployeeBenefits.aspx'">View Profile</button>--%>
                                    <%-- <button class="btn btn-xs btn-primary" id="btnview" runat="server" onclick="window.location='EmployeeBenefits.aspx'">View Profile</button>--%>
                                    <asp:LinkButton role="menuitem" ID="viewlinkbutton" CssClass="btn btn-xs btn-primary" OnClick="viewlinkbutton_Click" runat="server" Visible="false">View Profile</asp:LinkButton>
                                </div>
                                <div class="floatr user_profile_btn">
                                    <asp:LinkButton role="menuitem" ID="LinkButton2" CssClass="btn btn-xs btn-default" OnClick="LinkButton1_Click" runat="server">Sign Out</asp:LinkButton>
                                </div>
                            </li>
                        </ul>
                    </li>

                    <!-- /user login dropdown -->
                </ul>
                <!-- /Top Right Menu -->
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
        </header>
        <!-- /.header -->
         <div class="ProductBG">

               <script type="text/javascript" src="Theme/marquee/js/marquee.js"></script>
                <script>
                    $(function () {

                        $('.simple-marquee-container').SimpleMarquee();

                    });

                </script>
        <div style="align-content: center; margin: 73px 0px 0px 110px;">
             <div class="NewsMarquee">

                    <marquee><li id="news" runat="server" style="list-style:none;"></li></marquee>

                    <div class="simple-marquee-container">

                        <div class="marquee">

                            <ul class="marquee-content-items">
                                <%--  <li>
						At vero eos et accusamus et iusto odio dignissimos,  
					</li>
            <li>At vero eos et accusamus et iusto odio dignissimos,</li>
            <li>At vero eos et accusamus et iusto odio dignissimos</li>--%>
                                
                            </ul>
                        </div>
                    </div>
                </div>
            <div style="margin:-70px 0px 0px 0px; float:left;" id="dlst1" runat="server">
            <asp:DataList ID="DataList1" CssClass="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" AutoPostBack="true" OnItemCommand="DataList1_ItemCommand" Width="90%">
               
                <%-- BorderColor="#336699" BorderStyle="Solid" BorderWidth="2px"--%>
                <ItemTemplate>

                    <br />
                    <%--<asp:Image ID="Image1" runat="server" 
         ImageUrl='<%# "GetImage.aspx?id=" + Eval("branchID") %>' Width="150px"  />--%>

                    <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%# "GetImage.aspx?id=" + Eval("branchID") %>' Width="180px" CommandName="ImageButtonClick" Height="123px" ToolTip='<%# Eval("branchName")%>' />
                    <%-- ToolTip='<%# Eval("branchName")%>'--%>

                    <%-- <asp:ImageButton ID="Image1" runat="server" 
         ImageUrl='<%# Eval(Portimages(bid))%>' Width="200px"  CommandName="ImageButtonClick" Height="100px" />
               <asp:Label ID="Label1" runat="server" Text='<%# Eval("branchName") %>' Font-Bold="True"
         Font-Size="10pt" ForeColor="#336699" Width="100%" />--%>

                    <%--<asp:RadioButton ID="RDBox" Text='<%# Eval("branchName") %>' runat="server" AutoPostBack="true" />--%>
                    <asp:HiddenField ID="hid_bid" runat="server" Value='<%# Eval("branchID") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
            </asp:DataList>
                 </div>
        </div>
             </div>
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

            <%--       <iframe id="ifrmaster" name="centerfrm" class="div_Menu" frameborder="0" src="" scrolling="no" runat="server"></iframe>--%>
            <%--<iframe id="Iframe1" name="centerfrm" class="div_Menu1" frameborder="1"  src="Budget.aspx"  scrolling="no" runat="server"></iframe>--%>

            <!-- <div class="div_log" > 
  
  
  </div> -->

            <div class="FormGroupContent">
                <asp:Panel ID="pln_cheque" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
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

        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
    <div class="FooterCont" style="display: none;">
        <p>Design and Developed by LeadTech Solutions Private Limited. Copy Right @ 2016. All Rights Reserved</p>

    </div>
</body>
</html>
