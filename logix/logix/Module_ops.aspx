<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Module_ops.aspx.cs" Inherits="logix.Module_ops" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/MainModuleNew.css" rel="stylesheet" type="text/css" />
    <link href="Styles/CompanyProfile.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    <link rel="stylesheet" href="Theme/assets/tab/js/main.css">
    <script type="text/javascript" src="Theme/assets/tab/js/jquery.js"></script>
    <script type="text/javascript" src="Theme/assets/tab/js/tabs.js"></script>
    <title></title>
</head>
    <style type="text/css">
     .modalPopupsskpi {
            background-color: #FFFFFF;
     
            border:1px solid #b1b1b1;
            /*width: 1062px;*/
            width: 39%;
            Height: 250px;
            margin-left: 20%;
            margin-top: 0%;
            margin-right: 0%;
            /*padding:1px;            
            display:none;*/
        }
    .div_txt textarea {height:150px!important; width:90%!important; margin:0px 0px 0px 20px;
    }

        .DivSecPanelkpi {
            width: 20px;
            Height: 20px;
            border: 1px solid #b1b1b1;
            margin-left: 98.3%;
            margin-top: -1.5%;
            border-radius: 90px 90px 90px 90px;
        }

        .Gridpnkpi {
            width: 100%;
            Height: 220px;
        }

        .frameskpi {
            height: 100%;
            width: 100%;
        }

        #logix_CPH_pln_KPI {
            left: 0px !important;
            top: 25px !important;
        }

    .Hide
    {
        display:none;
    }
    .Tab_Text_Multiline1 {
        font-family: sans-serif;
        font-style: normal;
        margin-left: 0px;
        width: 100%;
        height: 400px;
        /*resize:none;*/ overflow: auto;
    }

    .Tab_Text_Multiline2 {
        font-family: sans-serif, Geneva, sans-serif !important;
        font-size: 11px;
        font-style: normal;
        margin-left: 0.5px;
        width: 100%;
        height: 150px;
        overflow: auto;
        color: #4c4c4c !important;
    }

        .Tab_Text_MultilineN {
        font-family: sans-serif, Geneva, sans-serif !important;
        font-size: 11px;
        font-style: normal;
        margin-left: 0.5px;
        width: 100%!important;
        height: 350px!important;
        overflow: auto!important;
        color: #4c4c4c !important;
    }

    .Tab_Text_Multiline4 {
        font-family: sans-serif;
        font-size: 8pt;
        font-style: normal;
        border-style: solid;
        border-width: 1px;
        margin-left: 0.5px;
        border-color: Black;
        width: 100%;
        overflow: auto;
    }

    .FormGroupContentmainmodule textarea {
        height: 302px !important;
        cursor: default !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_tab {
        background-image: none !important;
        border-top: 2px solid #0077c9;
    }


    .Tab_Text_Multiline1 p {
        padding: 5px 5px 0 15px;
    }


    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_inner {
        background-image: none !important;
        border-left: 1px solid #b1b1b1;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
        padding-left: 0px !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
        padding: 0px !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {
        background-image: none !important;
        border-right: 1px solid #b1b1b1;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
        padding-right: 0px !important;
    }

    .ajax__tab_active {
        padding: 0px 0px 0px 0px !important;
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
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel8 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    .ajax__tab_tab {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel2 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel3 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel7 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel4 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel5 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel6 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel9 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel10 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel11 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel12 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel13 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel14 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel15 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel16 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel17 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #TabContainer2_header > span {
        margin: 0 5px 0 0;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
        background-image: none !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
        background-image: none !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
        background-image: none !important;
    }

    .Tab_Text_Multiline1 ul {
        margin: 0;
        padding: 0 5px 5px 29px;
    }

    .disabledbutton {
        pointer-events: none;
        opacity: 0.4;
    }
    #pln_KPI {left:413px!important; top:140px!important;
    }
    .div_GridNN1 {
    border: 1px solid #b1b1b1;
    height: 390px;
    overflow:auto;
}
</style>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div id="container">


            <!-- /Sidebar -->

            <div class="Padtop">
                <div class="Homecontainer">
                    <!-- Breadcrumbs line -->
                    <%--<div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li class="current"><i class="icon-home"></i><a href="#"></a>Home </li>
             
            </ul>
      </div>--%>
                    <!-- /Breadcrumbs line -->

                    <div class="HomeGroup">
                        <a id="Ocean_export" runat="server" href="#">
                            <div class="MenuOE">
                                <img src="Theme/assets/img/ocean_exports.png" width="106" height="63">
                                <h3>Ocean Exports</h3>
                            </div>
                        </a>
                        <a id="FEFIMenu" runat="server" href="#">
                            <div class="MenuOI">
                                <img src="Theme/assets/img/ocean_imports.png" width="148" height="70">
                                <h3>Ocean Imports</h3>

                            </div>
                        </a>
                        <a id="AirExport" runat="server" href="#">
                            <div class="MenuAE">
                                <img src="Theme/assets/img/air_ic1.png" width="71" height="65">
                                <h3>Air Exports</h3>
                            </div>
                        </a>
                        <a id="AirAgencyimport" runat="server" href="#">
                            <div class="MenuAI">
                                <img src="Theme/assets/img/air_ic2.png" width="67" height="67">
                                <h3>Air Imports</h3>
                            </div>
                        </a>

                    </div>
                         <div class="TabMenu">

                        <div class="tabs animated-fade">
                            <ul class="tab-links">
                                <li class="active"><a href="#tab11">News</a></li>
                                <li><a href="#tab22">Company Profile</a></li>
                                <li><a href="#tab33">IT Policy</a></li>
                                <li><a href="#tab34">Employee Benefits</a></li>
                                <li><a href="#tab35">Welfare Measures</a></li>
                            </ul>

                            <div class="tab-content">
                                <div id="tab11" class="tab active">

                                    <div class="FormGroupContent">
                                        <asp:Panel ID="panel" runat="server" CssClass="div_GridNN1">
                                            <asp:GridView ID="grd" runat="server" CssClass="GridTD" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" DataKeyNames="news" Width="100%" OnSelectedIndexChanged="grd_SelectedIndexChanged" OnRowDataBound="grd_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="News #" DataField="newsid">
                                                        <HeaderStyle Wrap="false" Width="40px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                                    </asp:BoundField>
                                                   
                                                    <asp:TemplateField HeaderText="Title">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 350px">
                                                                <asp:Label ID="title" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="350px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>
                                                      <asp:BoundField HeaderText="empname" DataField="empname" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                                       
                                                    </asp:BoundField>
                                                      <asp:BoundField HeaderText="news" DataField="news" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">                                                       
                                                    </asp:BoundField>
                              
                                                </Columns>
                                               
                                                <AlternatingRowStyle CssClass="GrdRowStyle" />
                                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                                <RowStyle CssClass="GridviewScrollItem" />
                                                <PagerStyle CssClass="GridviewScrollPager" />
                                            </asp:GridView>
                                            <div class="div_Break"></div>
                                          
                                        </asp:Panel>
                                    </div>
                                </div>

                                <div id="tab22" class="tab">

                                   
                                    <div class="FormGroupContentmainmodule">
                                        <asp:TabContainer ID="Tab" runat="server" Width="100%" ActiveTabIndex="8">
                                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Our Profile" TabIndex="0">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Profile" runat="server" Text="Corporate Profile"></asp:Label></div>
                                                    <div class="div_break"></div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Profile" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" TextMode="MultiLine" CssClass="Tab_Text_Multiline2"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Our Mission">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Mission" runat="server" Text="Our Mission"></asp:Label></div>
                                                    <div class="div_break"></div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Mission" runat="server" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox></div>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Achieve" runat="server" Text="How do we plan to achieve our mission ?"></asp:Label></div>
                                                    <div class="div_break"></div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Achieve" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox></div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Our Philosophy & Beliefs">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Philosophy" runat="server" Text="Our Philosophy"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Philosophy" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Beleifs" runat="server" Text="Our Beleifs"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Beleifs" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Working Hours">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Hours" runat="server" Text="WORKING HOURS"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Hours" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Dress Code">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_DressCode" runat="server" Text="DRESS CODE"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_DressCode" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Salary Structure">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Salary" runat="server" Text="SALARY STRUCTURE"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Salary" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="Leave">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Leave" runat="server" Text="LEAVE"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Leave" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="Probationers">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Probation" runat="server" Text="PROBATIONERS"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Probation" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TabContainer>
                                    </div>

                                </div>

                                <div id="tab33" class="tab">
                                    <div class="Tab_Text_Multiline1">


                                        <h3>Objectives</h3>
                                        <p>The purpose of this policy is to ensure the proper use of  M+R’s IT & eMail system and make users aware of what M+R’s acceptable and unacceptable use of its IT & eMail system. The M+R reserves the right to amend this policy at its discretion. In case of amendments, users will be informed appropriately.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>IT</h3>
                                        <p>File Store / Desktop / Screensaver All documents to be saved in d:\Mydocs folder i.e. documents should not be stored where the OS is residing. User are allowed our ISO quality policy  as Desktop theme to display.  Users are not allowed to set screen savers in their system.</p>
                                        <p>Users have no rights to delete the mails from their system while relieving the organization.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>eMail </h3>
                                        <p>Please refer eMail policy.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>Internet & Games </h3>
                                        <p>Users are allowed to browse Shipping / Banking related sites.   Employees are allowed to browse few public portals / sites related to our industry prior approval by their supervisor (BM / RM / COO).  Playing online games & Surfing pornography, sports, entertainment and job portals are strictly prohibited.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>Accessing Others System</h3>
                                        <p>Users are not allowed to access others system without their permission, however RM / BM / COO can access.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>Hardware & Peripherals</h3>
                                        <p>Systems, Printers, Other peripherals and UPS to be relocated by AMC service provider only.</p>
                                        <p>Systems should be shut down properly and the power to be switched off one leaves the office (even one leaves the office on duty for few hours) Dept. Head / Accounts Head would be responsible for misuse of Laser printer by their team members.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>Hardware & Software purchase</h3>
                                        <p>All Hardware & Software to be purchased as per Capex. System Department will suggest the configuration and price.</p>
                                        <p>If you receive any calls from Software Vendors like Microsoft, Please redirect to Systems Dept / COO</p>
                                        <div class="bordertopHome"></div>
                                        <h3>Backup [Individual Systems]</h3>
                                        <p>Backup (Mails & My Documents) to be done on monthly basis without fail.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>eMail</h3>
                                        <h3>LEGAL RISK</h3>
                                        <p>Email is a business communication tool and users are obliged to use this tool in a responsible, effective and lawful manner. Although by its nature email seems to be less formal than other written communication, the same laws apply. Therefore, it is important that users are aware of the legal risks of email:</p>
                                        <h3>GUIDELINES</h3>
                                        <p>The following rules are to be strictly adhered to. It is prohibited to:</p>
                                        <p>
                                            <ul style="font-size: 10pt">
                                                <li>Send or forward emails containing libelous, defamatory, offensive, racist or obscene remarks. If you receive an email of this nature, you must promptly notify your supervisor. </li>
                                                <li>Forward a message without acquiring permission from the sender first. </li>
                                                <li>Send unsolicited email messages. </li>
                                                <li>Forge or attempt to forge email messages. </li>
                                                <li>Disguise or attempt to disguise your identity when sending mail. </li>
                                                <li>Send email messages using another person’s email account. </li>
                                                <li>Copy a message or attachment belonging to another user without permission of the originator. </li>
                                                <li>Send an attachment that contains a virus </li>
                                            </ul>
                                        </p>
                                        <h3>BEST PRACTICES</h3>
                                        <p>
                                            M+R considers email as an important means of communication and recognizes the importance of proper email content and speedy replies in conveying a professional image and delivering good customer service. Users should take the same care in drafting an email as they would for any other communication.  Therefore M+R wishes users to adhere to the following guidelines:
                                        </p>
                                        <div class="bordertopHome"></div>
                                        <h3>*     Writing emails: </h3>
                                        <p>
                                            <ul style="font-size: 10pt">
                                                <li>Write well-structured emails and use short, descriptive subjects.</li>
                                                <li>M+R’s email style is informal. This means that sentences can be short and to the point. You can start your email with ‘Hi’, or ‘Dear’, and the name of the person. Messages can be ended with ‘Best Regards’. The use of 	       Internet abbreviations and characters such as smileys however, is 	       not encouraged.</li>
                                                <li>Signatures must include your name, job title and company name. A disclaimer will be added underneath your signature (see Disclaimer) </li>
                                                <li>Users must spell check all mails prior to transmission. </li>
                                                <li>Do not send unnecessary attachments. Compress attachments larger than 2048K before sending them. </li>
                                                <li>Do not write emails in capitals.  </li>
                                                <li>Do not use cc: or bcc: fields unless the cc: or bcc: recipient is aware that you will be copying a mail to him/her and knows what action, if any, to take. </li>
                                                <li>If you forward mails, state clearly what action you expect the recipient to take. </li>
                                                <li>Only send emails of which the content could be displayed on a public notice board. If they cannot be displayed publicly in their current state,consider rephrasing the email, using other means of communication, or protecting information by using a password (see confidential). </li>
                                                <li>Only mark emails as important if they really are important. </li>
                                            </ul>

                                        </p>
                                        <h3>*      Replying to emails: </h3>
                                        <p>
                                            <ul style="font-size: 10pt">
                                                <li>Emails should be answered within at least 8 working hours, but users must endeavor to answer priority emails within 4 hours.</li>
                                                <li>Priority emails are emails from existing customers and business partners.</li>

                                            </ul>


                                        </p>
                                        <h3>*      Newsgroups: </h3>
                                        <p>
                                            <ul style="font-size: 10pt">
                                                <li>Users need to request permission from their supervisor before subscribing to a newsletter or news group.</li>


                                            </ul>

                                        </p>
                                        <div class="bordertopHome"></div>
                                        <h3>PERSONAL USE</h3>
                                        <p>It is strictly forbidden to use M+R’s email system for anything other than legitimate business purposes. Therefore, the sending of personal emails, chain letters, junk mail, jokes and executables is prohibited. All messages distributed via the company’s email system are M+R’s property.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>CONFIDENTIAL INFORMATION</h3>
                                        <p>
                                            Never send any confidential information via email. If you are in doubt as to whether to send certain information via email, check this with your supervisor first. 
                                        </p>
                                        <div class="bordertopHome"></div>
                                        <h3>PASSWORDS</h3>
                                        <p>
                                            All passwords must be made known to the company. The use of passwords to gain access to the computer system or to secure specific files does not provide users with an expectation of privacy in the respective system or document.
                                        </p>
                                        <div class="bordertopHome"></div>
                                        <h3>ENCRYPTION</h3>
                                        <p>Users may not encrypt any emails without obtaining written permission from their supervisor. If approved, the encryption key(s) must be made known to the company.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>EMAIL RETENTION</h3>
                                        <p>Inbox should have last 60 days mails only. User has to move the incoming mails to appropriate folder for archiving once the job is over. </p>
                                        <div class="bordertopHome"></div>
                                        <h3>EMAIL ACCOUNTS</h3>
                                        <p>All email accounts maintained on our email systems are property of M+R. Passwords should not be given to other people.</p>
                                        <div class="bordertopHome"></div>
                                        <h3>SYSTEM MONITORING</h3>
                                        <p>
                                            Documents could be created, stored, sent & received on the company’s computers by the users.  If there is evidence that users have not adhering to the guidelines set out in this policy,  M+R reserves the right to take disciplinary action, 
including termination and/or legal action.
                                        </p>
                                        <div class="bordertopHome"></div>
                                        <h3>DISCLAIMER</h3>
                                        <p>
                                            The following disclaimer will be added to each outgoing email:
‘This email and any files transmitted with it are confidential and intended solely for the use of the individual or entity to 
whom they are addressed. If you have received this email in error please notify the system manager. Please note that 
any views or opinions presented in this email are solely those of the author and do not necessarily represent those of
 the company. Finally, the recipient should check this email and any attachments for the presence of viruses. The 
company accepts no liability for any damage caused by any virus transmitted by this email.’
                                        </p>
                                        <div class="bordertopHome"></div>
                                        <h3>EMAIL CLIENT</h3>
                                        <p>
                                            Users should use Mozilla Thunderbird as mail client to send and receive mails in their system.  System Department will 
inform Regional Heads / Branch Heads / System Personnel if there any change in the version or software.  Users should not use Outlook & Outlook express for emails
                                        </p>
                                        <div class="bordertopHome"></div>
                                        <div style="float: left; margin-left: 1%;">Prepared by : IT Dept   </div>
                                        <div style="float: right; margin-right: 1%;">Approved by : Chief Operating Officer</div>
                                    </div>
                                </div>


                                <div id="tab34" class="tab">
                                    <%--<h3>Ten Years Service Awards</h3>
						<p>Happy To Inform That This Year We have 12 0f Our Employees Who have Completed or Will be Completing 10 Years of Service With us. Wish to Congratulate each one of you for a Decade of Meritorious Service With Us.<a href="#">more...</a></p>
                         <div class="bordertopHome"></div>--%>
                                    <%--   <div class="div_Head">--%>
                                    <div class="FormGroupContentmainmodule">
                                        <asp:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0">
                                            <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="Insurance And Gratuity" TabIndex="0">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <br />
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Employee" runat="server" Text="EMPLOYEE'S STATE INSURANCE"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Employee" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Gratutity" runat="server" Text="GRATUITY"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Gratutity" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="Leave And Medical">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <br />
                                                    <div class="div_label">
                                                        <asp:Label ID="Label1" runat="server" Text="LEAVE TRAVEL ALLOWANCE"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Leaveemployee" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Medical" runat="server" Text="MEDICAL REIMBURSEMENT"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Medical" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel11" runat="server" HeaderText="Lunch And Entertainment">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <br />
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Lunch" runat="server" Text="LUNCH ALLOWANCE"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Lunch" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Entertain" runat="server" Text="ENTERTAINMENT ALLOWANCE"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Entertain" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel12" runat="server" HeaderText="Driver Allowance And Employee PF">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <br />
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Driver" runat="server" Text="Driver Allowance And Employee PF"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Driver" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_PF" runat="server" Text="EMPLOYEES PRIVIDENT FUND"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_PF" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel13" runat="server" HeaderText="Bonus And Travel">
                                                <ContentTemplate>
                                                    <div class="div_break"></div>
                                                    <br />
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Bonus" runat="server" Text="Bonus"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Bonus" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Travel" runat="server" Text="TRAVEL - PER DIEM"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt_Mission">
                                                        <asp:TextBox ID="txt_Travel" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </div>

                                </div>

                                <div id="tab35" class="tab">
                                    <%--<h3>Ten Years Service Awards</h3>
						<p>Happy To Inform That This Year We have 12 0f Our Employees Who have Completed or Will be Completing 10 Years of Service With us. Wish to Congratulate each one of you for a Decade of Meritorious Service With Us.<a href="#">more...</a></p> <div class="bordertopHome"></div>--%>
                                    <%-- <div class="div_Head">--%>
                                    <div class="FormGroupContentmainmodule">
                                        <asp:TabContainer ID="TabContainer2" runat="server" Width="100%" ActiveTabIndex="1">
                                            <asp:TabPanel ID="TabPanel14" runat="server" HeaderText="Accident Insurance" TabIndex="0">
                                                <ContentTemplate>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Group" runat="server" Text="GROUP PERSONAL ACCIDENT INSURANCE COVER"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Group" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel15" runat="server" HeaderText="Earn Leave Encashment">
                                                <ContentTemplate>
                                                    <div class="div_label">
                                                        <asp:Label ID="Label2" runat="server" Text="EARN LEAVE ENCASHMENT"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Leavewelfare" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel16" runat="server" HeaderText="Employee Wedding">
                                                <ContentTemplate>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Wedding" runat="server" Text="EMPLOYEE WEDDING"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Wedding" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel17" runat="server" HeaderText="Employee Referral">
                                                <ContentTemplate>
                                                    <div class="div_label">
                                                        <asp:Label ID="lbl_Referral" runat="server" Text="EMPLOYEE REFERRAL"></asp:Label>
                                                    </div>
                                                    <div class="div_break">
                                                    </div>
                                                    <div class="div_txt">
                                                        <asp:TextBox ID="txt_Referral" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </div>
                                </div>


                            </div>

                        </div>









                    </div>


                    




                </div>
            </div>

        </div>

        <div class="FormGroupContent4">
            <asp:Panel ID="pln_KPI" runat="server" CssClass="modalPopupkpi"  Style="display: none;">
                <div class="DivSecPanelkpi">
                    <asp:Image ID="Close_KPI" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                </div>
                <div class="div_Break">
                </div>
                <div class="Gridpnkpi">
                    <div class="FormGroupContent">
                        <div style="width:90%; margin:0px 0px 0px 20px; float:left;">
                        <asp:TextBox ID="txttitle" runat="server" CssClass="form-control" style="width:100%; color:#0077c9;" AutoPostBack="True" placeholder="Title" ToolTip="Title"></asp:TextBox>

                            </div>
                        </div>
                    <div class="div_txt"> <asp:TextBox ID="txtNews" runat="server" ReadOnly="true" placeholder="News" ToolTip="News" CssClass="Tab_Text_MultilineN" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="FormGroupContent Hide">
                        <div style="position:absolute; z-index:999999999; top:95%; margin:-30px 0px 0px 20px;">
                        <asp:TextBox ID="txtpost" runat="server" CssClass="form-control" AutoPostBack="True" style="width:100%; color:brown;" placeholder="Posted By" ToolTip="Posted By"></asp:TextBox></div>
                    </div>
                    <%--<iframe id="iframeKPI" runat="server" src="" frameborder="0" class="frameskpi" style="background-color: #FFFFFF"></iframe>--%>
                </div>
            </asp:Panel>
        </div>
        <asp:ModalPopupExtender runat="server" ID="popup_KPI"
            PopupControlID="pln_KPI" CancelControlID="Close_KPI" TargetControlID="Label3" DropShadow="false">
        </asp:ModalPopupExtender>
        <asp:Label ID="Label3" runat="server"></asp:Label>


        <div class="box" style="display: none;">
            <a id="Agencyexports" runat="server" data-tooltip="Agency Exports" href="#" class="tooltip-bottom">
                <asp:Image ID="Image11" runat="server" Width="100%" Height="100%" CssClass="round-box" ImageUrl="~/images/Agencyexports.jpg" />
            </a>
        </div>
        <div class="box" style="display: none;">
            <a id="AgencyImports" runat="server" data-tooltip="Agency Imports" href="#" class="tooltip-bottom">
                <asp:Image ID="Image12" runat="server" Width="100%" Height="100%" CssClass="round-box" ImageUrl="~/images/agencyImports.jpg" /></a>
        </div>


    </form>
</body>
</html>
