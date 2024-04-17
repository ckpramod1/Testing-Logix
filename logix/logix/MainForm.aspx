<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="logix.MainPage.MainForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title ></title>
  <meta name="viewport" content="width=device-width, initial-scale=1">


    <style type="text/css" >
    .top_logo
    {
      /*border:1px solid RED;*/
      margin-top :0.35%;
      /*height: 100%;*/
      height:70%;
      width:2.5%;
      margin-left :2.5%;
      float:left;
      margin-right :1%;
    }

    .top_logo_Text
    {
      /*border:1px solid black;*/
      margin-top :0%;
      height:70px;
      /*height: 99%;*/
      width:88.5%;
      margin-left :0.5%;
      float:right;
   
    }
    .div_img
    {
        width: 16px;
        height: 16px;
         }
  
    </style>


    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />    
    <link href="Styles/FormMain.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <script src="ScriptsAuto/bootstrap.jquery.min.js" type ="text/javascript"></script>
    <script src="ScriptsAuto/bootstrap.min.js" type ="text/javascript"  ></script>
    <script src="ScriptsAuto/jquery-ui.min.js" type ="text/javascript"></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1"> 
     <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">


        <script type="text/javascript" language="javascript">
            function setPageHeight() {
                var y = screen.availHeight;
                var x = y - 35;
                var a = document.getElementById('total').style.height = x + 'px';
            }
            document.oncontextmenu = function () { return false };
            window.ondragstart = function () { return false; }

            function getiframeURL() {

                var source = document.getElementById('ifrmaster').contentWindow.location.href;
                var hdnfldVariable = document.getElementById('hdn_source');
                hdnfldVariable.value = source;

            }


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

       <%-- <script type="text/javascript">
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


    </head> 
    <body onload="setPageHeight()" bgcolor="#FCFCFC">
    <form id="form1" runat="server">



    <div class="total" id="total"  >
        <div class ="top_align" id="top_div">
            <div class="top_align_Main">
             <div class="top_logo">
             <asp:Image ID="img_Logo" runat="server" Height="100%" Width="100%" ImageUrl="~/images/FAWater.jpg" />
            </div>
            <div class="div_cname"><asp:Label ID="lblcompany" runat="server" style =" text-transform: capitalize;"></asp:Label></div>
            <div class ="top_Cname " ><asp:Label ID="lblcname"  runat="server" style =" text-transform: capitalize;" ></asp:Label></div>

            <div class="top_Clogo">  <asp:Image ID="img_emp" runat="server" Height="100%" Width="100%" style ="background-size:cover;" CssClass="round-box" data-toggle="dropdown" ImageUrl="~/images/CImage.png"  /> </div>
            <div class="top_Home"> <asp:LinkButton ID="lnkbtn" runat="server" OnClick="lnkbtn_Click1" style ="text-transform: capitalize;color:#ffffff;text-decoration:none;">HOME</asp:LinkButton></div>
            <div class="top_ClogoNew"> <asp:ImageButton ID="imgRequest" runat="server" Height="70%" Width="70%" style ="background-size:cover;"  ImageUrl="~/images/fbnxet.png" onmouseover="this.src='images/fbfist.png'" OnMouseOut="this.src='images/fbnxet.png'" />
            </div>
           <div class="top_ClogoMsg"> <asp:ImageButton ID="imgmsg" runat="server" Height="100%" Width="100%" style ="background-size:cover;" onmouseover="this.src='images/msgw.png'" OnMouseOut="this.src='images/msg12.png'" ImageUrl="~/images/msg12.png" /></div>
  <%-- <div  id="divNew" runat="server" visible="false">   
   <asp:ImageButton ID="imgreqNext" runat="server" Height="75%" Width="75%" style ="background-size:cover;"  ImageUrl="~/images/FbNext.jpg" Visible="false" OnClick="imgreqNext_Click"  />          
  </div> --%> 
   <div class ="top_arrow">
   <div class="dropdown" style ="margin-top :-1.3%; float :left; background-color :#3b5998;border : #3b5998;">
   <button class="btn btn-default dropdown-toggle" type="button" id="menu1" data-toggle="dropdown" style ="background-color :#3b5998; border :#3b5998; font-size :55px; margin-right :-20%; ">
        <span class="caret"></span></button>

            <ul class="dropdown-menu dropdown-menu-right" role="menu" aria-labelledby="menu1">
            <li role="presentation" class="dropdown-header"><asp:Label ID="lblname" runat="server" CssClass ="LabelValue"  style =" text-transform: capitalize;" ></asp:Label></li>
            <li role="presentation" class="dropdown-header"><asp:Label ID="lbldesg" runat="server" CssClass ="LabelValue"  style =" text-transform: capitalize;" ></asp:Label></li>
            <li role="presentation" class="dropdown-header"><asp:Label ID="lbldept" runat="server"  CssClass ="LabelValue" style =" text-transform: capitalize;"  ></asp:Label></li>
            <li role="presentation" class="dropdown-header"><asp:Label ID="lblport" runat="server" CssClass ="LabelValue" style =" text-transform: capitalize;" ></asp:Label></li>
            <li role="presentation" class="divider"></li><li role="presentation"><asp:LinkButton role="menuitem"  ID="LinkButton1"  style="text-align :left; color :darkblue; font-size:9pt;  font-family:Arial; text-decoration :none; "  OnClick ="LinkButton1_Click" runat="server" >Sign Out</asp:LinkButton></li>
            </ul>
  </div>
            <%--<li role="presentation"><asp:LinkButton role="menuitem"  ID="LinkButton2"  style="text-align :left; color :darkblue; font-size:9pt;  font-family:Arial; text-decoration :none; "  OnClick ="LinkButton2_Click" runat="server" >Budget</asp:LinkButton></li>
            <li role="presentation" class="divider"></li>
            <li role="presentation"> <asp:LinkButton role="menuitem"  ID="LinkButton3"  style="text-align :left; color :darkblue; font-size:9pt;  font-family:Arial; text-decoration :none; "  runat="server" OnClick="LinkButton3_Click" >Appointments</asp:LinkButton> </li>
            <li role="presentation" class="divider"></li>
            <li role="presentation"> <asp:LinkButton role="menuitem"  ID="LinkButton4"  style="text-align :left; color :darkblue; font-size:9pt;  font-family:Arial; text-decoration :none; "  runat="server" OnClick="LinkButton4_Click"  >Generate Schedule</asp:LinkButton> </li>
            <li role="presentation" class="divider"></li>
            <li role="presentation"> <asp:LinkButton role="menuitem"  ID="lnkSalesFollowup"  style="text-align :left; color :darkblue; font-size:9pt;  font-family:Arial; text-decoration :none; "  runat="server" OnClick="lnkSalesFollowup_Click"  >Sales Followup</asp:LinkButton> </li>
            <li role="presentation" class="divider"></li>--%>

            </div>            
     
       
       
                <%--     <div> <br class="ClearFloat"/></div>--%>
      </div>
      </div>




      <%--  class="div_Menu"--%>
        <div class="div_Break "></div>
        <iframe id="ifrmaster" name="centerfrm" frameborder="0" class="div_Menu2" src="Mainpage/CorpDocked.aspx"  scrolling="no" runat="server"></iframe>
         <%--<iframe id="Iframe1" name="centerfrm" class="div_Menu1" frameborder="1"  src="Budget.aspx"  scrolling="no" runat="server"></iframe>--%>
        <div class="div_Break "></div>
      

  <div class="div_log" id="div_bottom"> 
  <div class="div_img_bottom_logo"><asp:Image ID="Image1" runat="server" width="45px" Height ="20px" ImageUrl="~/images/FAWater.jpg"/> </div><div class="div_span_logo"><span class="span_logo">&nbsp;&nbsp;&nbsp;Designed and Developed by LeadTech Solutions Private Limited</span>
      <span style="float:right;margin-top:0.3%;font-size:8pt;font-family:sans-serif">&nbsp;&nbsp;&nbsp;Best Viewed With 1366 X 768 in Google Chrome</span>
   </div>
  <asp:HiddenField ID="hdn_pwd" runat="server" />
  <asp:HiddenField ID="hf_division" runat="server" />
  <asp:HiddenField ID="hf_branch" runat="server" />
   <asp:HiddenField ID="hdnframeid" runat="server" />
  </div>

            </div>
         

</form> 
        </body> 
    </html> 