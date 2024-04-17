<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="BLRegister.aspx.cs" Inherits="logix.ForwardExports.BLRegister" %>

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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>









    <link href="../Styles/BLRegister.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .modalBackground1 {
            /*background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7;*/
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 99.5%;
            Height: 532px;
            margin-left: 0%;
            margin-top: 0%;
            /*padding:1px;            
            display:none;*/
        }

        .divRoated {
            /*width:853px; 
            Height:303px;*/
            width: 990px;
            height: 450px;
            /*width:100%; 
            Height:100%;*/
            /*border:1px solid black;*/
            margin-left: 1%;
            margin-top: -14%;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.5%;
            border-radius: 90px 90px 90px 90px;
        }

        .Gridpnl {
            width: 100%;
            Height: 560px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #logix_CPH_pnl_Quota {
            left: 0px !important;
            top: 30.5px !important;
        }

        .RadRadio {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TrendRadio {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .gridpnl {
    height: calc(100vh - 226px);
}
  .FromInput {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
  .ToCalInput {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>

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


        logix_CPH_PanelLog {
            border-width: 2px;
            border-style: solid;
            position: fixed;
            z-index: 100001;
            left: 352px;
            top: 187px !important;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .RadRadio {
            width: 6%;
            float: left;
            margin: 17px 0.5% 0px 0px;
            color: #000080;
        }

        .TrendRadio {
            width: 10%;
            float: left;
            margin: 17px 0.5% 0px 0px;
            color: #000080;
        }
   
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 60px !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <!-- /Breadcrumbs line -->

    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" Text="BL Register" runat="server"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="" id="headerlabel2" runat="server"></a></li>
            <li><a href="#" title="" id="headerlable1" runat="server"></a></li>
            <li class="current"><a href="#" title="" id="headerlabel" runat="server">Performance Revenue</a> </li>
        </ul>
    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons">
     <div class="right_btn">

        <div class="btn ico-view">
            <asp:Button ID="btn_view" ToolTip="View" Text="View" runat="server" OnClick="btn_view_Click" TabIndex="3" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" ToolTip="Cancel" Text="Cancel" runat="server" OnClick="btn_cancel_Click" TabIndex="4" />
        </div>

    </div>
</div>

                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="RadRadio">
                            <asp:RadioButton ID="radio_revenue" Text="Revenue" runat="server" GroupName="rbt" />
                        </div>

                        <div class="TrendRadio">
                            <asp:RadioButton ID="radio_trend" Text="Trend Analysis" runat="server" GroupName="rbt" />
                        </div>
                        <div class="TrendRadio">
                            <asp:RadioButton ID="radio_incentive" Text="Incentive Report" runat="server" Visible="false" GroupName="rbt" />
                        </div>

                        <div class="FromInput">
                            <asp:Label ID="lbl_From" Text="From" runat="server"></asp:Label>
                            <asp:TextBox ID="txt_From" runat="server" CssClass="form-control" placeholder="" ToolTip="From" TabIndex="1"></asp:TextBox>
                        </div>

                        <div class="ToCalInput">
                            <asp:Label ID="lbl_To" Text="To" runat="server"></asp:Label>
                            <asp:TextBox ID="txt_To" runat="server" CssClass="form-control" placeholder="" ToolTip="To" TabIndex="2"></asp:TextBox>
                        </div>
                       
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                      <div class="gridpnl">
                            <asp:GridView ID="GrdFI" runat="server" AutoGenerateColumns="true" ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader"  Width="100%">
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" Wrap="false" />
                            <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                            <RowStyle Wrap="false" />
                        </asp:GridView></div>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_Quota" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                            <div class="DivSecPanel">
                                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="pnl_grd1" runat="server"  CssClass="Gridpnl">

                                <iframe id="iframecost" runat="server" src="TrendAnalysis.aspx" frameborder="0" class="frames"></iframe>
                            </asp:Panel>

                            <div class="div_Break"></div>
                           </div>
                        </asp:Panel>



                    </div>

                 

                            <asp:ModalPopupExtender ID="pop_trend" runat="server" PopupControlID="pnl_Quota" DropShadow="false"
                                TargetControlID="Label1" CancelControlID="Close_voucher">
                            </asp:ModalPopupExtender>
                            <asp:HiddenField ID="hid" runat="server"></asp:HiddenField>
                            <asp:Label ID="Label1" runat="server" />
                        </div>
                        <div>
                            <asp:CalendarExtender ID="cal_from" runat="server" TargetControlID="txt_From" Format="dd/MM/yyyy"></asp:CalendarExtender>
                            <asp:CalendarExtender ID="cal_to" runat="server" TargetControlID="txt_To" Format="dd/MM/yyyy"></asp:CalendarExtender>

                        </div>

                        <div>
                            <asp:HiddenField ID="hid_jobno" runat="server" />
                            <asp:HiddenField ID="hid_Closeddate" runat="server" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>BL Register #</label>

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


    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
