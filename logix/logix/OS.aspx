<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OS.aspx.cs" Inherits="logix.OS" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <script type="text/javascript" src="Scripts/Validation.js"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Style/jquery-ui.css" rel="Stylesheet" type="text/css" />
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
    <style type="text/css">
       
       

        #PnlGrd {
            width: 1280px;
            overflow-x: auto;
            overflow-y: auto;
            max-height: 285px;
        }


         body {
            background-color:transparent!important;
            color:#fff!important;
        }
        .breadcrumb {
            padding:0px 15px 0px 0px;
        }
        .crumbs{
            background-color:transparent!important;
            border-top:1px solid #d9d9d9;
            border-bottom:0px solid #fff;
            height:20px;
        }
        .row {
            background-color:transparent!important;
        }
        .breadcrumb > li + li::before {
            color:#fff;
        }
        .crumbs .breadcrumb li i {
            color:#fff;
        }
        .widget.box .widget-content {
            background-color:transparent;
        }








        .widget.box {
            height:350px;
        }



    </style>


    <!-- Demo JS -->
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
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
                <table cellpadding="2" cellspacing="2" border="0">
                    <%-- <tr>
        <td>
        <table cellspacing="0" cellpadding="2" style="background:url(Images/menu_bg_a1.jpg) repeat center top;">
                           <tr  style="background-color: #0296f8;">
                               <td colspan="5">
                                    <asp:Label ID="LBLTitle" runat="server" Text="Oustanding" Font-Bold="True" Font-Names="Arial" Font-Size="Small" CssClass="Title"></asp:Label>&nbsp;
                               </td>
                           </tr>
      
                           <tr>
                                <td align="right">
                                    <asp:Label id="Label1" runat="server"  Text="From"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="dtFrom" runat="server" Width="75px"></asp:TextBox><asp:Image ID="ImgFrom"
                                        runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px" ImageAlign="AbsMiddle" />
                                </td>
                                <td align="right">
                                    <asp:Label id="Label2" runat="server"  Text="To"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="dtTo" runat="server" Width="75px"></asp:TextBox><asp:Image ID="imgTo"
                                        runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px" ImageAlign="AbsMiddle" /></td>
                               <td align="right">
                                   &nbsp;<asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="Find" Width="50px" CssClass="button" />
                                   <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel"
                                       Width="50px" CssClass="button" />
                                   <asp:Button id="btnToExcel" runat="server" OnClick="btnToExcel_Click" Text="To Excel" Enabled="False" CssClass="button" /></td>
                           </tr>   
                    </table>
        </td>
    </tr>--%>
                </table>
                <!-- Breadcrumbs line -->
                <div class="crumbs">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Accounts</li>
                        <li class="current">OutStanding</li>
                    </ul>
                </div>
                <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header" style="display:none;">
                                <h4><i class="icon-umbrella"></i>
                                    <asp:Label ID="LBLTitle" runat="server" Text="Outstanding"></asp:Label></h4>
                            </div>
                            <div class="widget-content">

                                <div class="FormGroupContent4">
                                    <asp:Label ID="lblError" runat="server" CssClass="Error"></asp:Label>
                                    <asp:Panel ID="PnlGrd" runat="server">
                                        <asp:GridView ID="grd" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="False" ForeColor="Black"
                                            DataKeyNames="vouno" Width="100%">
                                            <%--OnRowDataBound="grd_RowDataBound"--%>
                                            <Columns>
                                                <%--                                                <asp:BoundField DataField="vouno" HeaderText="Particulars">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="5%" HorizontalAlign="Right" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle Width="8%" Wrap="True" />
                                                    <ItemStyle Width="3%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="voudate" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="refno" HeaderText="Ref #" ItemStyle-Wrap="False">
                                                    <ItemStyle />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}"></asp:BoundField>--%>

                                                <asp:BoundField DataField="SNo" HeaderText="SNo #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="voutype" HeaderText="Vou Type">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vouno" HeaderText="Vou #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="refno" HeaderText="Ref #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="refno" HeaderText="Vessel & Voy / Flight">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="customer" HeaderText="Customer Name">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="P O L" HeaderText="PoL">
                                                    <ItemStyle Wrap="true"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="P O D" HeaderText="PoD">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vamount" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false" CssClass="TxtAlign1"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader " />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>


                                    <div class="right_btn">
                                        <div class="btn btn-excel1">
                                            <asp:Button ID="btnExcel" runat="server" ToolTip="ToExcel" OnClick="btnExcel_Click" />
                                        </div>
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" ToolTip="Cancel" Visible="false"/>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>





                &nbsp;
        <%-- <asp:BoundField DataField="vendorrefno" HeaderText="Vender Ref #">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="5%" />
                </asp:BoundField>
                <asp:BoundField DataField="jobno" HeaderText="Job #">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="2.5%" />
                </asp:BoundField>
                <asp:BoundField DataField="refno" HeaderText="Ref #">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="4%" Wrap="true"  />
                </asp:BoundField>
                <asp:BoundField DataField="fcur" HeaderText="Cur">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="2%" />
                </asp:BoundField>
                <asp:BoundField DataField="famt" HeaderText="Debit" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle  HorizontalAlign="Right" width="4%" />
                </asp:BoundField>
                <asp:BoundField DataField="famt" HeaderText="Credit" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Right" width="4%"  />
                </asp:BoundField>
                <asp:BoundField DataField="fexrate" HeaderText="Ex-Rate"  DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="4%" HorizontalAlign="Right" />
                </asp:BoundField>--%>
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hid_bid" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
