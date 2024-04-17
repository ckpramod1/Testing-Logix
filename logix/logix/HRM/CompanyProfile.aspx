<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="CompanyProfile.aspx.cs" Inherits="logix.HRM.CompanyProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
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

 <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <style type="text/css">


            .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_tab {background-image:none!important; border-top:2px solid #0077c9;
    }


    .Tab_Text_Multiline1 p {
    padding: 5px 5px 0 15px;
}


    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_inner{background-image:none!important; padding-bottom:1px; border-left:1px solid #b1b1b1;
    }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {padding-left:0px!important;
    }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {padding:0px!important;
    }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {background-image:none!important; border-right:1px solid #b1b1b1;
    }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {padding-right:0px!important;
    }
    .ajax__tab_active {padding:0px 0px 0px 0px!important;
    }
    #Tab_header > span {
    margin: 0 3px 0 0;
}
    #TabContainer1_header > span {
    margin: 0 6px 0 0;
}
    #__tab_Tab_TabPanel1 > span {
    color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
}

    #__tab_Tab_TabPanel8 > span {
         color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
    }
    .ajax__tab_tab {
         color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px!important;
    margin:0px 0px 0px 0px;
    font-weight:normal;
    }
    #__tab_Tab_TabPanel2 > span {
            color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
    }
    #__tab_Tab_TabPanel3 > span {
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
    }
    #__tab_Tab_TabPanel7 > span{
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
    }
    #__tab_Tab_TabPanel4 > span {
            color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
    }
    #__tab_Tab_TabPanel5 > span {
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
    }
    #__tab_Tab_TabPanel6 > span
    {
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 5px;
    margin:0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel9 > span {
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #__tab_TabContainer1_TabPanel10 > span{
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #__tab_TabContainer1_TabPanel11 > span{
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #__tab_TabContainer1_TabPanel12 > span{
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #__tab_TabContainer1_TabPanel13 > span{
        color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel14 > span {
         color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #__tab_TabContainer2_TabPanel15 > span{
         color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #__tab_TabContainer2_TabPanel16 > span{
         color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #__tab_TabContainer2_TabPanel17 > span{
         color: #4c4c4c;
    font-size: 11px;
    padding: 2px 2px;
    margin:0px 0px 0px 0px;
    }
    #TabContainer2_header > span {
    margin: 0 5px 0 0;
}
        .ajax__tab_xp .ajax__tab_header {font-family:sans-serif!important;
        }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {background-image:none!important;
    }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner{background-image:none!important;
    }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer{background-image:none!important;
    }

        .logix_CPH_Tab_TabPanel8_tab {margin:0px 2px 0px 2px;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {padding:0px 0px 0px 0px;
        }



        #__tab_logix_CPH_Tab_TabPanel8 > span {padding:2px 5px;
        }

        #__tab_logix_CPH_Tab_TabPanel1 > span{padding:2px 5px;
        }
        #logix_CPH_Tab_header > span {padding:0px 5px 0px 5px;
        }
        #__tab_logix_CPH_Tab_TabPanel2 > span{padding:0px 5px 0px 5px;
        }
       #__tab_logix_CPH_Tab_TabPanel3 > span{padding:0px 5px 0px 5px;
        }
       #__tab_logix_CPH_Tab_TabPanel4 > span{padding:0px 5px 0px 5px;
        }
      #__tab_logix_CPH_Tab_TabPanel5 > span{padding:0px 5px 0px 5px;
        }
      #__tab_logix_CPH_Tab_TabPanel6 > span{padding:0px 5px 0px 5px;
        }
      #__tab_logix_CPH_Tab_TabPanel7 > span{padding:0px 5px 0px 5px;
        }
        .div_Head {font-weight:normal;
        }
         .ajax__tab_xp .ajax__tab_body {border-left:1px solid #b1b1b1!important;border-right:1px solid #b1b1b1!important;border-bottom:1px solid #b1b1b1!important;
        }


         input[type="text"], input[type="file"], textarea {
    border: 0px solid #b1b1b1!important;
}



    </style>
    <link href="../Styles/CompanyProfile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">Utility</a> </li>
              <li class="current">Company Profile</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
      <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/companyprofile_ic.png" />  <asp:Label ID="lbl_Header" runat="server" Text="Company Profile"></asp:Label></h3>
    </div>
        <div class="Form-ControlBg">
            <div class="div_Head MB05">
        <div class="FormGroupContentComp">
        <asp:TabContainer ID="Tab" runat="server" Width="100%" ActiveTabIndex="7">
            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Our Profile" TabIndex="0">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_Profile" runat="server" Text="Corporate Profile"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt">
                        <asp:TextBox ID="txt_Profile" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Our Mission">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_Mission" runat="server" Text="Our Mission"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt_Mission">
                        <asp:TextBox ID="txt_Mission" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_label">
                        <asp:Label ID="lbl_Achieve" runat="server" Text="How do we plan to achieve our mission ?"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt_Mission">
                        <asp:TextBox ID="txt_Achieve" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Our Philosophy & Beleifs">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_Philosophy" runat="server" Text="Our Philosophy"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt_Mission">
                        <asp:TextBox ID="txt_Philosophy" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_label">
                        <asp:Label ID="lbl_Beleifs" runat="server" Text="Our Beleifs"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt_Mission">
                        <asp:TextBox ID="txt_Beleifs" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Working Hours">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_Hours" runat="server" Text="WORKING HOURS"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt">
                        <asp:TextBox ID="txt_Hours" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Dress Code">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_DressCode" runat="server" Text="DRESS CODE"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt">
                        <asp:TextBox ID="txt_DressCode" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Salary Structure">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_Salary" runat="server" Text="SALARY STRUCTURE"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt">
                        <asp:TextBox ID="txt_Salary" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="Leave">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_Leave" runat="server" Text="LEAVE"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt">
                        <asp:TextBox ID="txt_Leave" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="Probationers">
                <ContentTemplate>
                    <div class="div_label">
                        <asp:Label ID="lbl_Probation" runat="server" Text="PROBATIONERS"></asp:Label>
                    </div>
                    <div class="div_break">
                    </div>
                    <div class="div_txt">
                        <asp:TextBox ID="txt_Probation" runat="server" CssClass="Tab_Text_Multiline" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
            </div>
        <div class="FormGroupContent4">
            <div class="right_btn MT0 MB05">
                <div class="btn ico-save" id="btn_save1" runat="server">
                      <asp:Button ID="btn_Save" runat="server" ToolTip="Save" onclick="btn_Save_Click"  />
                </div>
            </div>
        </div>
    </div>

            </div>
          </div>
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i></h4>
                </div>
          <div class="widget-content">
           

    

    </div>
              </div>
         </div>
            </div>
       


</asp:Content>
