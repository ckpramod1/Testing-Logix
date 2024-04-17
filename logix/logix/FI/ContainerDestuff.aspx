<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ContainerDestuff.aspx.cs" Inherits="logix.FI.ContainerDestuff" %>

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

    <link href="../Styles/ContainerDestuff.css" rel="stylesheet" />
    <%--<script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>--%>
    <%--    <script type="text/javascript">

        function pageLoad(sender, args) {
            (document).ready(function () {
                $('#<%=grd_dstuff.ClientID%>').gridviewScroll({
                    width:528,
                    height: 175,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });
        }
        </script>--%>

    <style type="text/css">
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

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        div#logix_CPH_div_iframe {
            height: 85vh;
        }
        .JobInput {
    float: left;
    width: 10%;
}
        .sizeInput {
    float: left;
    width: 15%;
    margin: 0px 0.5% 0px 0px;
}.SealCal2 {
    float: left;
    width: 14%;
    margin: 0px 0px 0px 0px;
}.ContainerInput4 {
    float: left;
    width: 38%;
    margin: 0px 0.5% 0px 0px;
}
 .SealInput1 {
    float: left;
    width: 31.5%;
    margin: 0px 0.5% 0px 0px;
}
        .txt_vvoy {
    float: left;
    width: 39%;
    margin: 0 0.5% 0 0;
}
        .JobCal1 {
    float: left;
    width: 14%;
    margin: 0 0.5% 0 0;
}
        .FormBoxLeft {
    width: 50%;
    float: left;
    margin: 3px 0.5% 0px 0px;
    padding: 0px 0px 0px 0px;
}
        .FormBoxRight {
    width: 50%;
    float: left;
    margin: 0px;
}
        
/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
.gridpnl {
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
    height: calc(100vh - 400px);
}
 
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    
    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_header" runat="server" Text="Container Destuff"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#"></a>Documentation</li>
            <li><a href="#" title="">Ocean Imports</a> </li>
            <li class="current"><a href="#" title="">Container DeStuff</a> </li>
        </ul>
    </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                        </div>

                    <div class="FixedButtons">
     <div class="right_btn ">
    <div class="btn ico-update">
        <asp:Button ID="btn_update" runat="server" Text="Update" ToolTip="Update" OnClick="btn_update_Click" />
    </div>
    <div class="btn ico-cancel" id="btn_cancel1" runat="server">
        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
    </div>
</div>
</div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                    <div class="FormBoxLeft">
                        
                    <div class="FormGroupContent4 ">
                        <div class="JobInput">
                            <asp:Label ID="Label1" runat="server" Text="Job #"> </asp:Label>
                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnTextChanged="txt_job_TextChanged" placeholder="" ToolTip="Job #"></asp:TextBox>
                        </div>
                      
                    </div>
                    <div class="FormGroupContent4 boxmodal">

                    <div class="txt_vvoy">
                        <asp:Label ID="Label3" runat="server" Text="Vessel Voyage"> </asp:Label>
                        <asp:TextBox ID="txt_vvoy" runat="server" CssClass="form-control" Enabled="False" placeholder="" ToolTip="Vessel Voyage"></asp:TextBox>
                    </div>
                          <div class="JobCal1 ">
                            <asp:Label ID="Label2" runat="server" Text="ETA"> </asp:Label>
                            <asp:TextBox ID="txt_eta" runat="server" CssClass="form-control" placeholder="" ToolTip="ETA"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender_eta" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_eta"></asp:CalendarExtender>
                        </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label4" runat="server" Text="Agent"> </asp:Label>
                        <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" Enabled="False" placeholder="" ToolTip="Agent"></asp:TextBox>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label5" runat="server" Text="MLO"> </asp:Label>
                        <asp:TextBox ID="txt_mlo" runat="server" CssClass="form-control" Enabled="False" placeholder="" ToolTip="MLO"></asp:TextBox>
                    </div>
                    <div class="FormGroupContent4 hide">
                        <div class="ContainerDetails">
                            <asp:Label ID="lbl_condet" runat="server" Text="Container Details"></asp:Label>
                        </div>
                    </div>
                        </div>
                   
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ContainerInput4">
                            <asp:Label ID="Label7" runat="server" Text="Container #"> </asp:Label>
                            <asp:TextBox ID="txt_con" runat="server" CssClass="form-control" ReadOnly="true" placeholder="" ToolTip="Container #"></asp:TextBox>
                        </div>
                        <div class="sizeInput">
                            <asp:Label ID="Label8" runat="server" Text="Size"> </asp:Label>
                            <asp:TextBox ID="txt_size" runat="server" CssClass="form-control" ReadOnly="true" placeholder="" ToolTip="Size"></asp:TextBox>
                        </div>
                        <div class="SealInput1">
                            <asp:Label ID="Label9" runat="server" Text="Seal #"> </asp:Label>
                            <asp:TextBox ID="txt_seal" runat="server" CssClass="form-control" ReadOnly="true" placeholder="" ToolTip="Seal #"></asp:TextBox>
                        </div>
                        <div class="SealCal2 DateR">
                            <asp:Label ID="Label10" runat="server" Text="Destuff"> </asp:Label>
                            <asp:TextBox ID="txt_dstuff" runat="server" CssClass="form-control" placeholder="" ToolTip="Destuff"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtenderdstuff" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txt_dstuff"></asp:CalendarExtender>
                        </div>
                    </div>
               
                        </div>
                    <div class="FormBoxRight">
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_dstuff" Visible="false" runat="server" CssClass="gridpnl">
                            <asp:GridView ID="grd_dstuff" runat="server" AutoGenerateColumns="False"
                                Width="100%" OnRowDataBound="grd_dstuff_RowDataBound" CssClass="Grid FixedHeader" 
                                OnSelectedIndexChanged="grd_dstuff_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="containerno" HeaderText="Container #" />
                                    <asp:BoundField DataField="sizetype" HeaderText="Size" />
                                    <asp:BoundField DataField="sealno" HeaderText="Seal #" />
                                    <asp:BoundField DataField="destuff" HeaderText="Destuff" DataFormatString="{0:dd/MM/yyyy}" />
                                    <%-- <asp:TemplateField HeaderText ="Destuff" HeaderStyle-ForeColor="White">
                            <ItemTemplate>   
                            <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                            <asp:Label ID="destuff" runat="server" Text='<%# Bind("destuff") %>' DataFormatString="{0:dd/MM/yyyy}" ></asp:Label>
                            </div>
                            </ItemTemplate>
                           <HeaderStyle Wrap="false" Width="60px"  HorizontalAlign="Center"  />
                           <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>                      
              </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                  
                    </div>
                        </div>
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server">JOB #:</label>

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
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
