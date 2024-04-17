<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="logix.Receipt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>
    <script type="text/javascript" src="Scripts/Calendar.js"></script>

    <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />

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
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />

    <style type="text/css">
        .GridTbl {
            width: 1003px;
            overflow-x:hidden;
            overflow-y: hidden;
            height: 323px;
            border: 1px solid #b1b1b1;
            background-color:#fff;

        }



        .table-fixed thead {
            float: left;
            display: block;
        }

        .table-fixed tbody {
            height: 192px;
            overflow-y: auto;
            width: 100%;
        }

        .table-fixed thead, .table-fixed tbody, .table-fixed tr, .table-fixed td, .table-fixed th {
            display: inline-block;
        }

            .table-fixed tbody td {
                float: left;
                /*border-bottom-width: 0;*/
                display: block;
                border-left: 0px solid;
                border-top: 0px solid #fff;
                border-right: 1px solid #002f61;
            }

            .table-fixed thead > tr > th {
                float: left;
                /*border-bottom-width: 0;*/
                display: block;
            }

                .table-fixed thead > tr > th:last-child {
                    float: left;
                }

            .table-fixed tbody td:last-child {
                float: left;
            }

            .table-fixed tbody td:last-child {
                float: left;
            }

                .table-fixed tbody td:last-child::after {
                    clear: both;
                }



                .table-fixedR thead {
            float: left;
            display: block;
             width: 997px;
        }

        .table-fixedR tbody {
            height: 295px;
            overflow-y: auto;
            width: 997px;
        }

        .table-fixedR thead, .table-fixedR tbody, .table-fixedR tr, .table-fixedR td, .table-fixedR th {
            display: inline-block;
        }

            .table-fixedR tbody td {
                float: left;
                /*border-bottom-width: 0;*/
                display: block;
                border-left: 0px solid;
                border-top: 0px solid #fff;
                border-right: 1px solid #002f61;
            }

            .table-fixedR thead > tr > th {
                float: left;
                /*border-bottom-width: 0;*/
                display: block;
            }

                .table-fixedR thead > tr > th:last-child {
                    float: left;
                }

            .table-fixedR tbody td:last-child {
                float: left;
            }

            .table-fixedR tbody td:last-child {
                float: left;
            }

                .table-fixedR tbody td:last-child::after {
                    clear: both;
                }








        body {
            background-color: transparent !important;
            color: #000 !important;
        }

        .breadcrumb {
            padding: 0px 15px 0px 0px;
        }

        .crumbs {
            background-color: transparent !important;
            border-top: 0px solid #d9d9d9;
            border-bottom: 0px solid #fff;
            height: 20px;
        }

            .crumbs li {
                list-style:none;
            }

        .row {
            background-color: transparent !important;
              height:429px!important;
            overflow:hidden!important;
        }

        .breadcrumb > li + li::before {
            color: #000;
        }

        .crumbs .breadcrumb li i {
            color: #000;
        }

        .widget.box .widget-content {
            background-color: transparent;
        }








        .widget.box {
            height: 384px;
        }
    </style>


</head>
<body style="margin-left: 10px; margin-top: 10px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                

                <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header" style="display: none;">
                                <h4 class="hide"><i class="icon-umbrella"></i>
                                    <asp:Label ID="LBLTitle" runat="server" Text="Receipts"></asp:Label></h4>
                                <!-- Breadcrumbs line -->
                <div class="crumbs">
         <%--           <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Accounts</li>--%>
                        <li class="current">Receipts</li>
                    </ul>
                </div>
                            </div>
                            <div class="widget-content">

                                <div class="FormGroupContent4">
                                    <div class="FromTxt">
                                        <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
                                    </div>
                                    <div class="FromTxtbox">
                                        <asp:TextBox ID="dtFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtFrom"
                                            Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                    </div>
                                    <%-- <div class="CalImg"><asp:Image ID="ImgFrom" runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px"  /></div>--%>
                                    <div class="ToTxt">
                                        <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                                    </div>
                                    <div class="ToTxtBox">
                                        <asp:TextBox ID="dtTo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtTo"
                                            Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                    </div>
                                    <%--  <div class="CalImg"><asp:Image ID="imgTo" runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px" ImageAlign="AbsMiddle" /></div>--%>
                                    <div class="right_btn">

                                        <div class="btn btn-find">
                                            <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" ToolTip="Find" />
                                        </div>
                                        <div class="btn btn-excel1">
                                            <asp:Button ID="btnToExcel" runat="server" OnClick="btnToExcel_Click" ToolTip="Export To Excel" Enabled="False" />
                                        </div>
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" ToolTip="Cancel" Visible="false" />
                                        </div>
                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <asp:Label ID="lblError" runat="server" CssClass="Error"></asp:Label>
                                    <asp:Panel ID="PnlGrd" runat="server" CssClass="panel_10">
                                        <asp:GridView ID="Grd" runat="server" AutoGenerateColumns="False" ShowHeader="true" OnSelectedIndexChanged="Grd_SelectedIndexChanged" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" OnPreRender="Grd_PreRender">
                                            <%-- --%>
                                            <Columns>
                                                <asp:CommandField SelectImageUrl="~/Images/select.gif" Visible="False" ButtonType="Image" ShowSelectButton="True">
                                                    <ItemStyle Width="5px"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:BoundField DataField="receiptno" HeaderText="Receipt #">

                                                    <ItemStyle Width="100px" Height="24px" Wrap="false"></ItemStyle>

                                                    <HeaderStyle Wrap="false" Width="100px" Height="24px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="receiptdate" HeaderText="Receipt Date">
                                                    <ItemStyle Width="100px" Wrap="false" Height="24px"></ItemStyle>

                                                    <HeaderStyle Wrap="false" Width="100px" Height="24px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="receiptmode" HeaderText="Mode">
                                                    <ItemStyle Width="60px" Wrap="false" Height="24px"></ItemStyle>

                                                    <HeaderStyle Wrap="false" Width="60px" Height="24px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="portname" HeaderText="Branch">
                                                    <ItemStyle Width="90px" Wrap="false" Height="24px"></ItemStyle>

                                                    <HeaderStyle Wrap="false" Width="90px" Height="24px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="receiptamount" HeaderText="Amount">
                                                    <ItemStyle Width="140px" Height="24px" Wrap="false" HorizontalAlign="Right" CssClass="TxtAlign1"></ItemStyle>

                                                    <HeaderStyle Wrap="false" Width="140px" Height="24px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="bankname" HeaderText="Bank">
                                                    <ItemStyle Width="485px" Wrap="false" Height="24px"></ItemStyle>

                                                    <HeaderStyle Wrap="false" Width="485px" Height="24px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="receiptid" Visible="False">
                                                    <ControlStyle BorderStyle="None"></ControlStyle>

                                                    <ItemStyle BackColor="AliceBlue" BorderStyle="None" Width="1px" ForeColor="AliceBlue" Wrap="False"></ItemStyle>

                                                    <HeaderStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue" Wrap="False"></HeaderStyle>
                                                </asp:BoundField>
                                            </Columns>

                                            <RowStyle CssClass="GrdRow" />
                                            <EditRowStyle />
                                            <SelectedRowStyle />
                                            <PagerStyle />
                                            <HeaderStyle CssClass="GrdHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />

                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>



            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
