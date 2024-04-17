<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Costing.aspx.cs" Inherits="logix.ForwardExports.Costing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

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

    <!-- Page specific plugins -->

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

    <script type="text/javascript" src="../js/helper.js"></script>

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

    <link href="../Styles/Costing.css" rel="stylesheet" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
             <%-- $('#<%=Grdcost.ClientID%>').gridviewScroll({
                    width: 860,
                    height: 100,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });--%>
            })
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <style type="text/css">
        .modalBackground {
            background-color: #FFFFFF;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .Hide {
            display: none;
        }

        #logix_CPH_popup_Grd_foregroundElement {
            left: 0px !important;
            top: 50px !important;
            z-index: 999999 !important;
        }

        .GrdRow th {
            white-space: inherit !important;
        }

        .GrdRow td {
            white-space: inherit !important;
        }

     

        .VesselInput4New {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 20%;
        }

        .VoyageInputN4New {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .modalPopupss {
            width: 98.5%;
        }

        .MBLInput3 {
            float: left;
            margin: 0;
            width: 18%;
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

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        body {
            overflow-y: hidden;
            overflow-x: hidden;
        }

        .row {
            height: 560px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 99%;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 14px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .JobNoInput {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
        .gridpnl {
    height: calc(100vh - 232px);
}
   .AgentInputcosting {
    float: left;
    margin: 0px 0.5% 0px 0px;
    width: 46.3%;
}     
   .MLOTxtInputcosting {
    width: 53.2%;
    float: left;
    margin: 0px 0% 0px 0px;
}

/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Costing"></asp:Label>
                        </h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs" id="lblcrum" runat="server">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li id="lblHead2" runat="server"><a href="#" title="" id="headerlabel2" runat="server">Customer Support</a> </li>
                                <li id="lblHead1" runat="server"><a href="#" title="" id="headerlable1" runat="server"></a></li>
                                <li class="current"><a href="#" title="" id="headerlabel" runat="server">Pre Alert</a> </li>
                            </ul>
                        </div>
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                         <div class="FixedButtons">
        <div class="right_btn">
         <div class="btn ico-excel">
             <asp:Button ID="btn_Export" Text="Export To Excel" runat="server" TabIndex="11" ToolTip="Export To Excel"
                 OnClick="btn_Export_Click" Visible="False" />
         </div>
         <div class="btn ico-send" id="send_id" runat="server" >
             <asp:Button ID="btn_send" runat="server" Text="Send" TabIndex="12" ToolTip="Send"
                 OnClick="btn_send_Click" />
         </div>
         <div class="btn ico-print">
             <asp:Button ID="btn_print" runat="server" Text="Print" TabIndex="13" ToolTip="Print"
                 OnClick="btn_print_Click" />
         </div>
         <div class="btn ico-cancel" id="btn_cancel1" runat="server">
             <asp:Button ID="btn_cancel" runat="server" Text="Cancel" TabIndex="14" ToolTip="Cancel" OnClick="btn_cancel_Click" />
         </div>
     </div>
 </div>
                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">
                        <div class="VoyageInputN4New fit-content">
                            <asp:Label ID="Label2" runat="server" Text="Product"> </asp:Label>
                            <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="JobNoInput">
                            <span>Job #</span>

                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_job_TextChanged" placeholder="Job #" ToolTip="Job NUMBER" TabIndex="2"></asp:TextBox>
                        </div>

                        <asp:LinkButton ID="lnk_job" CssClass="anc ico-find-sm" runat="server" OnClick="lnk_job_Click" TabIndex="1"></asp:LinkButton>

                        <div class="VesselInput4New">
                            <asp:Label ID="lbl_vsl" runat="server" Text="Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_vsl" runat="server" CssClass="form-control" ReadOnly="True" TabIndex="4"></asp:TextBox>
                        </div>
                        <div class="POLInput3">
                            <asp:Label ID="lbl_pol" runat="server" Text="POL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" ReadOnly="True" TabIndex="6"></asp:TextBox>
                        </div>
                        <div class="DateRightInput" style="display: none;">
                            <asp:Label ID="lbl_date" runat="server" Text="Date"> </asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="PODInput4">
                            <asp:Label ID="lbl_pod" runat="server" Text="POD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" ReadOnly="True" TabIndex="8"></asp:TextBox>
                        </div>
                        <div class="MBLInput3">
                            <asp:Label ID="lbl_mbl" runat="server" Text="MBL"> </asp:Label>
                            <asp:TextBox ID="txt_mbl" runat="server" CssClass="form-control" ReadOnly="True" OnTextChanged="txt_mbl_TextChanged" TabIndex="5"></asp:TextBox>
                        </div>

                    </div>
                <div class="FormGroupContent4 boxmodal">
                    <div class="AgentInputcosting">
                        <asp:Label ID="lbl_agent" runat="server" Text="Agent"> </asp:Label>
                        <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" ReadOnly="True" TabIndex="7"></asp:TextBox>
                    </div>
                    <div class="MLOTxtInputcosting">
                        <asp:Label ID="lbl_mlo" runat="server" Text="MLO"> </asp:Label>
                        <asp:TextBox ID="txt_mlo" runat="server" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="MLO" TabIndex="9"></asp:TextBox>
                    </div>
                </div>

                <div class="FormGroupContent4 hide" id="divtxtremark" runat="server">
                    <asp:Label Text="Remarks" runat="server" />
                    <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control" placeholder="Remarks" ToolTip="Remarks" TabIndex="10"></asp:TextBox>
                </div>

                <div class="FormGroupContent4 boxmodal">
                    <div id="div_prealert" runat="server">
                        <asp:Panel ID="pnlCharge" runat="server" CssClass="gridpnl MB0">
                            <asp:GridView CssClass="Grid FixedHeader" ID="Grdcost" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" DataKeyNames="vyear"
                                OnSelectedIndexChanged="Grdcost_SelectedIndexChanged"
                                OnRowDataBound="Grdcost_RowDataBound" OnPreRender="Grdcost_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="vtype" HeaderText="Voucher #">
                                        <HeaderStyle Width="90px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vno" HeaderText="Vou #">
                                        <HeaderStyle Width="80px" />

                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vdate" HeaderText="Date">
                                        <HeaderStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Status">
                                        <HeaderStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="blno" HeaderText="BL #">
                                        <HeaderStyle Width="160px" />
                                    </asp:BoundField>
                                    <%--<asp:TemplateField HeaderText="Customer Name">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 190px">
                                                    <asp:Label ID="cname" runat="server" Text='<%# Bind("cname") %>' ToolTip='<%# Bind("cname") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="390px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="390px"></ItemStyle>
                                        </asp:TemplateField>--%>

                                    <asp:BoundField DataField="cname" HeaderText="Customer Name">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="390px" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="390px"></ItemStyle>
                                    </asp:BoundField>

                                    <%--<asp:BoundField DataField="cname" HeaderText="Customer Name">
                     <HeaderStyle Width="170px" />
                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="vyear" HeaderText="Vouyear" Visible="false"/>--%>
                                    <%-- <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Custid" HeaderText="Custid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </asp:Panel>
                        <div class="div_Break">
                        </div>

                        <div class="div_rbt">
                            <asp:RadioButtonList ID="rbtcosting" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>With BL</asp:ListItem>
                                <asp:ListItem>Without BL</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <%--  <div class="div_btn" id="divExport" runat="server">
            
        </div>--%>

                     

                    </div>

                </div>
                    <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                <div class="FormGroupContent4">

                    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="DivSecPanel">
                                <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                                <asp:GridView ID="Grd_FE" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_FE_RowDataBound"
                                    ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" AllowPaging="false" PageSize="18"
                                    BackColor="White" OnSelectedIndexChanged="Grd_FE_SelectedIndexChanged" CssClass="Grid FixedHeader" OnPageIndexChanging="Grd_FE_PageIndexChanging">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Job #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 50px">
                                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="50px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="50px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Vessel">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 180px">
                                                    <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="80px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ETA">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px">
                                                    <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MBL">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px">
                                                    <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="90px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Agent">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px">
                                                    <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MLO">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 300px">
                                                    <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="80px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="POL">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 120px">
                                                    <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="80px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="POD">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 80px">
                                                    <asp:Label ID="POD" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="80px"></ItemStyle>
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_FE" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>
                                <div class="div_Break">
                                </div>
                                <asp:GridView ID="Grd_AE" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_AE_RowDataBound"
                                    ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="18" CssClass="Grid FixedHeader"
                                    BackColor="White" OnSelectedIndexChanged="Grd_AE_SelectedIndexChanged" OnPageIndexChanging="Grd_AE_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Job #">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 40px">
                                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="flight#" HeaderText="Flight # / Date">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="mawblno" HeaderText="MAWBL">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mawbldate" HeaderText="BL Date">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Agent">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 40px">
                                                    <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Air Liner">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 40px">
                                                    <asp:Label ID="airline" runat="server" Text='<%# Bind("airline") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="pol" HeaderText="POL">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pod" HeaderText="POD">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_AE" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>
                                <asp:GridView ID="Grd_BT" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_BT_RowDataBound"
                                    ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="18" CssClass="Grid FixedHeader"
                                    BackColor="White" OnSelectedIndexChanged="Grd_BT_SelectedIndexChanged" OnPageIndexChanging="Grd_BT_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Truck#" DataField="truckno">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="From" DataField="fromport">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="To" DataField="toport">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="etd" DataField="etd">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="eta" DataField="eta">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_BT" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
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
                    <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
                        TargetControlID="Label1" DropShadow="false" CancelControlID="close">
                    </asp:ModalPopupExtender>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:HiddenField ID="hid" runat="server" />
                    <asp:HiddenField ID="hid_etd" runat="server" />
                    <asp:HiddenField ID="hid_customerid" runat="server" />
                    <asp:HiddenField ID="hid_int_bid" runat="server" />
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

                        <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

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
            </div>

        </div>

    </div>
    </div>
    </div>

</asp:Content>
