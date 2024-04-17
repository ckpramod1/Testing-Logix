<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="GSTRegisters.aspx.cs" Inherits="logix.FAForm.GSTRegisters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="KRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />

    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <%--<link href="../Styles/MasterGroup.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Scripts/gridviewScroll.min.js"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .columnwidth {
            width: 300px;
        }


        .FromService {
            width: 2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ToService {
            width: 1%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }


        .Grid1 {
            font-family: Tahoma;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
        }
        /*.div_Grid1
{
    font-family: Tahoma;
    font-size: 8;
    width: 90%;
    height:400px;
    float: left;
    margin-left: 1.0%; /*margin-top: 1%;
    
}*/

        .fromServiceInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ToServiceInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CurrGrid {
            float: left;
            width: 100%;
            height: 410px;
            overflow: auto;
            border: 1px solid #b1b1b1;
            margin-bottom: 0px;
        }

        .div_ddlselect {
            float: left;
            width: 8%;
            margin-top: 0%;
            margin-left: 0%;
            margin-right: 0.5%;
        }

        .ByDrop1 {
            width: 21%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TblGrid td {
            white-space: nowrap;
        }

        .TblGrid th {
            white-space: nowrap;
        }

        .row {
            height: 578px !important;
            /* margin: 0px 5px 0px -15px; */
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 100%;
        }

        .div_labelLedger {
            float: left;
            width: 7%;
            margin: 0px 0.5% 10px 0px;
            color: #ff0000;
        }

            .div_labelLedger span {
                color: #ff0000 !important;
            }

        .div_labelLedger1 {
            float: left;
            width: 15%;
            margin: 0px 0% 10px 0px;
            color: #ff0000;
        }

            .div_labelLedger1 span {
                color: #ff0000 !important;
            }

        .LabelHead {
            font-size: 13px;
            color: #4e4e4c;
            font-weight: normal;
            font-family: Tahoma;
            width: 20%;
            float: left;
            margin: -5px 0px 1px 0px;
        }

            .LabelHead span {
                font-size: 13px;
                color: #4e4e4c;
                font-weight: normal;
                font-family: Tahoma;
            }


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
                font-size: 12px;
            }

        /*CSS*/

        .modalPopupLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
        }

        .DivSecPanelLog img {
            float: right;
            width: 16px !important;
            height: 16px !important;
        }


        .GridNew {
            font-family: Tahoma;
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
                font-size: 12px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 12px;
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
                font-size: 12px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
            white-space: nowrap;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }


        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }




            .LogHeadJobInput label {
                font-size: 12px;
                font-family: Tahoma;
                color: #4e4e4c;
            }
    </style>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {

            });
        }
    </script>
    <%--<script type="text/javascript">
        function pageLoad(sender, args) {
            //$(document).ready(function () {
            //    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            //});
            $(document).ready(function () {
                $('#<%=grd_trial.ClientID%>').gridviewScroll({
                width: 1020,
                height: 850,
                freezesize: 1,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
    }
    </script>--%>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=grd_trial.ClientID%>').gridviewScroll({
                width: 855,
                height: 450,
                freezesize: 1,
                arrowsize: 30,
                
              varrowtopimg: "../images/arrowvt.png",
            varrowbottomimg: "../images/arrowvb.png",
            harrowleftimg: "../images/arrowhl.png",
            harrowrightimg: "../images/arrowhr.png"
        });
    }
</script>--%>
    <%-- function pageLoad(sender, args) {
            $(document).ready(function () {
                $('#<%=grd_trial.ClientID%>').gridviewScroll({
                    width: 1200,
                    height: 1200,
                    freezesize: 1

                  
                });
            });
        }--%>
    <%--function gridviewScroll() {
            $('#<%=grd_trial.ClientID%>').gridviewScroll({
                width: 660,
                height: 200,
                freezesize: 2
            });
        }--%>
    <%-- </script>--%>

    <style type="text/css">
        .MT15 {
            margin: 15px 0px 0px 0px;
        }



        .FormGroupContent4 label {
            color: #000080;
            font-size: 12px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .btn-ctrl1 {
            margin: 23px 0px 0px;
        }

        .widget.box .widget-content {
            top: 0px !important;
            padding-top: 65px !important;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="">
        <div class="col-md-12"  class="maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="GST  Registers"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Reports</a> </li>
                            <li><a href="#" title="">GST Registers  </a></li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="btn-logic1">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FixedButtons">
                        <div class="right_btn">
                            <div class="btn ico-get">
                                <asp:Button ID="btn_get" runat="server" Text="Get" OnClick="btnget_Click" />
                            </div>
                            <div class="btn ico-excel">
                                <asp:Button ID="btn_export" runat="server" Text="Export To Excel" OnClick="btn_export_Click" />
                            </div>
                            <%--  <div class="btn btn-print1"><asp:Button ID="btn_print" runat="server" Text="Print" OnClick="btnprint_Click" /></div>--%>
                            <div class="btn ico-cancel">
                                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4">

                        <div class="div_ddlselect">
                            <asp:Label ID="Label1" runat="server" Text="Branch"> </asp:Label>
                            <asp:DropDownList ID="ddl_branch" Height="23" runat="server" CssClass="chzn-select" placeholder="Branch" ToolTip="Branch" AppendDataBoundItems="true"></asp:DropDownList>

                        </div>
                        <div class="ByDrop1">
                            <asp:Label ID="Label2" runat="server" Text="Register"> </asp:Label>
                            <asp:DropDownList ID="ddl_By" runat="server" CssClass="chzn-select" ToolTip="Register" data-placeholder="Register">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="1">GSTR1 Local Taxable Sales</asp:ListItem>
                                <asp:ListItem Value="2">GSTR1 Local NillRate Sales</asp:ListItem>
                                <asp:ListItem Value="3">GSTR1 Overseas Sales</asp:ListItem>
                                <asp:ListItem Value="4">GSTR2 Local Taxable Purchase</asp:ListItem>
                                <asp:ListItem Value="5">GSTR2 NillRate Purchase</asp:ListItem>
                                <asp:ListItem Value="6">NILL Rate Exempted</asp:ListItem>
                                <asp:ListItem Value="7">RCM</asp:ListItem>
                                <asp:ListItem Value="8">GSTR-3B</asp:ListItem>
                                <asp:ListItem Value="9">GSTR1 Overseas Purchase</asp:ListItem>
                                <asp:ListItem Value="10">Local Sales Reversal</asp:ListItem>
                                <asp:ListItem Value="11">Local Purchase Reversal</asp:ListItem>
                                <asp:ListItem Value="12">Overseas  Sales Reversal</asp:ListItem>
                                <asp:ListItem Value="13">Overseas Purchase Reversal</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      

                    
                           <div class="FromTxtInputbox">
    <asp:Label ID="lbl_fromdate" runat="server" Text="From Date"></asp:Label>
    <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="1"></asp:TextBox>
    <cc1:CalendarExtender ID="dtfrom_cal" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="txt_from" />
</div>

<div class="ToLabelInputbox">
    <asp:Label ID="lbl_todate" runat="server" Text="To Date"></asp:Label>
    <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="2"></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="txt_to" />
</div>
  </div>


    
    <div class="FormGroupContent4">
                        <div id="div_Grdheader" runat="server">
                            <div class="div_labelLedger">
                                <asp:Label ID="lblledger" runat="server" Text=" " CssClass="LabelValue"></asp:Label>
                            </div>
                            <div class="div_break">
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="LabelHead">
                            <asp:Label ID="lbl_head" runat="server" CssClass="LabelValue" Visible="false"></asp:Label>
                        </div>
                        </div>
                    <div class="FormGroupContent4">
                        <asp:Panel class="gridpnl" ID="Panel1" runat="server">
                            <asp:GridView ID="grd_trial" runat="server" CssClass="TblGrid FixedHeader" AutoGenerateColumns="true" Width="350%" OnRowDataBound="grd_trial_RowDataBound"
                                GridLines="None" OnPreRender="grd_trial_PreRender">
                                <%-- <AlternatingRowStyle CssClass="GrdRowStyle" />                
                        <HeaderStyle CssClass="GridviewScrollHeader" />
                        <RowStyle CssClass="GridviewScrollItem" /> 
                        <PagerStyle CssClass="GridviewScrollPager" />--%>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="div_labelLedger">
                            <asp:Label ID="lbl_payreceivable" runat="server" CssClass="LabelValue" Visible="false"></asp:Label>
                        </div>
                        <div class="div_labelLedger1">
                            <asp:Label ID="lbl_payreceivableamt" runat="server" CssClass="LabelValue" Visible="false"></asp:Label>
                        </div>
                    </div>

              
            </div>
        </div>
    </div>
        </div>
    <KRI:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from" BehaviorID="caltxtdate" Format="dd/MM/yyyy"></KRI:CalendarExtender>
    <KRI:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to" BehaviorID="caltxtdate1" Format="dd/MM/yyyy"></KRI:CalendarExtender>



    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopupLog" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_no" runat="server">Master Group :</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanelLog">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/images/close2.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="GridpnlLog">

                <asp:GridView ID="GridViewlog" CssClass="GridNew FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
                    BackColor="White" OnPreRender="GridViewlog_PreRender">
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

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>




</asp:Content>
