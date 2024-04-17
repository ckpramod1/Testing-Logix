<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CustomEDI.aspx.cs" Inherits="logix.FI.CustomEDI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

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

    <link href="../Styles/CustomEDI.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        /*.divRoated
        {
           width:953px; 
            Height:303px;            
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.3%;
            margin-top: -1.7%;
            position: absolute;
            width: 1027px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #logix_CPH_mdl_cust_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .left_btn {
            float: left;
            margin: 5px 0px 0px 0px;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
            width: 97.8%;
            height: 540px;
            margin-left: 1%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }

        /*LOG DETAILS CSS*/

        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }

        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

            .DivSecPanelLog img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }

        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

        .LogHeadLbl {
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
        .JobInput16 {
    width: 6.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .VesselInput10 {
    float: left;
    margin: 0px 0.5% 0px 0px;
    width: 16.9%;
}
        .MBLInput6 {
    float: left;
    margin: 0px 0px 0px 0px;
    width: 16.1%;
}
        .ETA {
    float: left;
    margin: 0px 0px; 
    width: 8.2%;
}
        .MBL{
             width: 24.8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        }
        .Vessel{
            width: 25%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        }
          .mlo{
            width: 33.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        }
            .agent{
            width: 33.3%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        }
            

/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
 

    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="logix_CPH">
    
    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>  
                        <asp:Label ID="lbl_header" runat="server" Text="Custom EDI"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Ocean Imports</a> </li>
            <li><a href="#" title="">Customer Service</a> </li>
            <li class="current"><a href="#" title="">Custom EDI</a> </li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons">
     
    <div class="left_btn" >
        <div class="btn ico-igm-1-5">
            <asp:Button ID="btn_igm" runat="server" Text="IGM 1.5" ToolTip="IGM 1.5" OnClick="btn_igm_Click" TabIndex="2" />

        </div>
        <div class="btn ico-liner-igm">
            <asp:Button ID="btn_ligm" runat="server" Text="Liner IGM" ToolTip="Liner IGM" OnClick="btn_ligm_Click" TabIndex="3" />
        </div>
        <div class="btn ico-customs-edi">
            <asp:Button ID="btn_cedi" runat="server" Text="Customs EDI" ToolTip="Customs EDI" OnClick="btn_cedi_Click" TabIndex="4" />
        </div>

        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="6" />
        </div>
    </div>
    <div class="right_btn">
        <div class="btn ico-igm-1-5-view">
            <asp:Button ID="btn_igmrpt" runat="server" Text="View IGM 1.5" ToolTip="View IGM 1.5" OnClick="btn_igmrpt_Click" TabIndex="2" />
        </div>
        <div class="btn ico-liner-view">
            <asp:Button ID="btn_ligmrpt" runat="server"  Text="View Liner IGM"  ToolTip="View Liner IGM" OnClick="btn_igmrpt_Click" TabIndex="3" />
        </div>
        <div class="btn ico-custom-view">
            <asp:Button ID="btn_cedirpt" runat="server" Text="View Customs EDI" ToolTip="View Customs EDI" OnClick="btn_igmrpt_Click" TabIndex="4" />
        </div>
    </div>
</div>


                </div>
                <div class="widget-content">

                    
                    <div class="FormGroupContent4">
                         <div class="JobInput16">
                            <span>Job #</span>                         
                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_job_TextChanged" placeholder="" ToolTip="Job Number" TabIndex="1"></asp:TextBox>
                        </div>
                         <asp:LinkButton ID="lnk_job" runat="server" CssClass="anc ico-find-sm" Style="text-decoration: none" ForeColor="Red" OnClick="lnk_job_Click"></asp:LinkButton>
                        <div class="MBL">
                            <asp:Label ID="Label5" runat="server" Text="MBL"> </asp:Label>
                            <asp:TextBox ID="txt_mbl" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Master of Bill of Lading"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                         
                        <div class="Vessel">
                            <asp:Label ID="Label3" runat="server" Text="Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Vessel"></asp:TextBox>
                        </div>
                        <div class="ETA DateR">
                            <asp:Label ID="Label2" runat="server" Text="ETA Date"> </asp:Label>
                            <asp:TextBox ID="txt_eta" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Estimated Time of Arrival Date"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="VesselInput10">
                            <asp:Label ID="Label8" runat="server" Text="POL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Port of Loading"></asp:TextBox>
                        </div>
                        <div class="MBLInput6">
                            <asp:Label ID="Label9" runat="server" Text="POD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Port of Destination"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal custom-d-flex">
                    
                    <div class="mlo">
                        <asp:Label ID="Label7" runat="server" Text="MLO"> </asp:Label>
                        <asp:TextBox ID="txt_mlo" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="MLO"></asp:TextBox>
                    </div>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="agent">

                        <asp:Label ID="Label6" runat="server" Text="Agent"> </asp:Label>
                        <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Agent"></asp:TextBox>
                        </div>
                    </div>
               

                    <div class="FormGroupContent4">
                        <%-- PopUP --%>
                        <asp:Panel ID="pnl_cust" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="img_grd_cust" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel2" runat="server"  CssClass="Gridpnl">
                                    <%--<asp:Panel ID="pnl_cust" runat="server" Width="100%" CssClass="div_frame" Style="display:none;">
                             <div class="div_close"><asp:Image ID="img_grd_cust" runat="server" ImageAlign="Baseline" width="100%" Height="100%" ImageUrl="~/images/close2.png"/></div>
                             <div class="div_Break"></div> 
 
                            <div class="div_Grd">--%>

                                    <asp:GridView ID="grd_cust" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" CssClass="Grid FixedHeader"  OnRowDataBound="grd_cust_RowDataBound" AllowPaging="false"
                                        EmptyDataText="No Record Found" PageSize="20" BackColor="White" OnSelectedIndexChanged="grd_cust_SelectedIndexChanged" OnPageIndexChanging="grd_cust_PageIndexChanging">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Job">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                                        <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="51px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="VesselName">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                        <asp:Label ID="VesselName" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MBL">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                        <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PoL">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="PoL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ETA">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                        <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Agent">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                        <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MLO">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 160px">
                                                        <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="160px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="POD">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="POD" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Select">
                  <ItemTemplate>
                     <asp:LinkButton ID="lnk_grdcust" runat="server" CssClass="Arrow" CommandName="select" Font-Underline="false">⇛</asp:LinkButton>
                  </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
              </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Job # :</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                    BackColor="White">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="myGridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>

    </asp:Panel>

    <div class="div_Break"></div>
    <asp:HiddenField ID="hf_jobno" runat="server" />
    <div>
        <asp:ModalPopupExtender ID="mdl_cust" runat="server" CancelControlID="img_grd_cust"
            PopupControlID="pnl_cust" TargetControlID="Label1" DropShadow="false">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hf_cust" runat="server" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>

