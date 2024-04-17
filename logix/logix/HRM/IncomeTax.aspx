<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="IncomeTax.aspx.cs" Inherits="logix.HRM.IncomeTax" %>
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
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />

        <script type="text/javascript" src="../Theme/assets/tab/js/jquery.js"></script>

        <script type="text/javascript" src="../Theme/assets/tab/js/tabs.js"></script>
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

  <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->

     <script type="text/javascript">
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


            .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_tab {background-image:none!important; border-top:2px solid #0077c9; padding:0px 5px 0px 5px!important;
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
    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {background-image:none!important; margin:0px 5px 0px 0px; border-right:1px solid #b1b1b1;
    }
    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {padding-right:0px!important; margin-right:5px;
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


        .tab-links li.active a {
    background-color: #0077c9;
    border-left: 1px solid #a6b5bf;
    border-right: 1px solid #a6b5bf;
    border-top: 1px solid #a6b5bf;
    color: #ffffff;
}



.tab-content {
    padding: 10px 15px;
    border-radius: 0px;
    box-shadow: 0px 0px 0px rgba(0,0,0,0.15);
    background: #fff;
    border: 0px solid #b1b1b1;
    min-height: 419px;
    margin: -5px 0px 0px -14px;
}

.tab-content a {
    color: #4e4e4c;
    font-size: 11px;
    font-family: sans-serif, Geneva, sans-serif;
    line-height: 18px;
    display: inline-block;
    padding: 0px 0px 0px 4px;
}
        ul.tab-links {padding:0px 0px 0px 0px; margin:0px 0px 0px 0px;
        }


        .Tab_Text_Multiline2 {width:100%; height:250px; overflow:auto;
        }

        .FormGroupContentmainmodule textarea {
    height: 335px !important;
}

.btn-save1 {
    /* background-color: #558024;
    color: #ffffff;*/
    z-index: 2;
    border-radius: 0px;
}

    .btn-save1 input {
        border-style: none !important;
        border-color: inherit !important;
        border-width: medium !important;
        background-image:url(../Theme/assets/img/buttonIcon/save_ic.png);
        background-repeat:no-repeat;
        background-position:left top;
        background-color:transparent!important;
        /*background-image: none !important;*/
        line-height: normal;
        color: #4e4e4e!important;
        padding: 5px 13px 6px 28px!important;
        /*height: 27px;*/
        cursor:pointer;
    }










    </style>




    <link href="../Styles/EmployeeBenefits.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">Utility</a> </li>
              <li class="current">Income Tax/Appraisal/Other Policy</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/otherIncome_ic.png" />  <asp:Label ID="lbl_Header" runat="server" Text="Income Tax/Appraisal/Other Policy"></asp:Label></h3>
    </div>
        <div class="Form-ControlBg">
            <div class="div_Head MB05">
        <div class="FormGroupContentComp">

              <div class="tabs animated-fade">
            <ul class="tab-links">
                                <li class="active"><a href="#tab11">Income Tax</a></li>
                                <li><a href="#tab22">Appraisal</a></li>
                                <li><a href="#tab33">Other Policy</a></li>
                              
                            </ul>

            <div class="tab-content">

            <div id="tab11" class="tab active">

                                    <div class="FormGroupContentmainmodule">
                                        <asp:TabContainer ID="TabContainer2" runat="server" Width="100%" ActiveTabIndex="1">
                                            <asp:TabPanel ID="TabPanel23" runat="server" HeaderText="Income Tax">
                                                <ContentTemplate>
                                                    <div class="div_label" style="color: #df2b2b;">
                                                        <asp:Label ID="Label9" runat="server" Text="Income Tax"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="Txt_IncomeTax" runat="server"  CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </div>
                                </div>
            
                           <div id="tab22" class="tab">

                                    <div class="FormGroupContentmainmodule">
                                        <asp:TabContainer ID="TabContainer3" runat="server" Width="100%" ActiveTabIndex="1">
                                            <asp:TabPanel ID="TabPanel18" runat="server" HeaderText="Probation Apprasial">
                                                <ContentTemplate>
                                                    <div class="div_label" style="color: #df2b2b;">
                                                        <asp:Label ID="Label4" runat="server" Text="Probation Apprasial"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="Txt_ProAppr" runat="server"  CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel19" runat="server" HeaderText="Annual Performance Appraisal">
                                                <ContentTemplate>
                                                    <div class="div_label" style="color: #df2b2b;">
                                                        <asp:Label ID="Label5" runat="server" Text="Annual Performance Appraisal"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="Txt_Annu" runat="server"  CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </div>
                                </div>           
         
            <div id="tab33" class="tab">

                                    <div class="FormGroupContentmainmodule">
                                        <asp:TabContainer ID="TabContainer4" runat="server" Width="100%" ActiveTabIndex="1">
                                            <asp:TabPanel ID="TabPanel20" runat="server" HeaderText="Suggestion  Policy">
                                                <ContentTemplate>
                                                    <div class="div_label" style="color: #df2b2b;">
                                                        <asp:Label ID="Label6" runat="server" Text="Suggestion Policy"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="Txt_Sug" runat="server"  CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel21" runat="server" HeaderText="Incentive Policy">
                                                <ContentTemplate>
                                                    <div class="div_label" style="color: #df2b2b;">
                                                        <asp:Label ID="Label7" runat="server" Text="Incentive Policy"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="Txt_IncPoli" runat="server"  CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel22" runat="server" HeaderText="Grievance Policy">
                                                <ContentTemplate>
                                                    <div class="div_label" style="color: #df2b2b;">
                                                        <asp:Label ID="Label8" runat="server" Text="Grievance Policy"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="Txt_GrivPoli" runat="server"  CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </div>
                                </div>

            </div>
                   
                        </div>                
            </div>
                   <div class="FormGroupContent4">
                       
                       <div class="right_btn MT0 MB05">
                           <div class="btn ico-save" id="btn_save2" runat="server"> <asp:Button ID="btn_Save" runat="server" ToolTip="Save" onclick="btn_Save_Click"  /></div>

                       </div>
                      </div>
                   </div>

            </div>
         </div>


</asp:Content>
