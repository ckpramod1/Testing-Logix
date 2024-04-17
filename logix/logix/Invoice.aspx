<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="logix.Invoice" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>
    <link href="Style/GrdHead.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />


    <style type="text/css">
        .GridTbl {
            width: 1003px;
            overflow-x: auto;
            overflow-y: auto;
            height: 326px;
            margin-bottom: 5px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <form id="form1" runat="server">


        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- Breadcrumbs line -->
                <div class="crumbs">
<%--                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>
                        <li>Accounts</li>--%>
                        <li class="current">Invoice / Debit Note </li>
                    </ul>
                </div>
                <div >
                    <div class="col-md-12  maindiv">
                        <div class="widget box">
                            <div class="widget-header" style="display: none;">
                                <h4><i class="icon-umbrella"></i>
                                    <asp:Label ID="LBLTitle" runat="server" Text="Accounts"></asp:Label></h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="FromTxt">From</div>
                                    <div class="FromTxtbox">
                                        <asp:TextBox ID="dtFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtFrom"
                                            Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                    </div>
                                    <%-- <div class="CalImg"><asp:Image ID="ImgFrom" runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px" ImageAlign="AbsMiddle" /></div>--%>
                                    <div class="ToTxt">To</div>
                                    <div class="ToTxtBox">
                                        <asp:TextBox ID="dtTo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtTo"
                                            Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                    </div>
                                    <%-- <div class="CalImg"><asp:Image ID="imgTo" runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px" ImageAlign="AbsMiddle" /></div>--%>
                                    <div class="right_btn MT0">
                                        <div class="btn btn-find">
                                            <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" ToolTip="Find" />
                                        </div>
                                        <div class="btn btn-excel1">
                                            <asp:Button ID="btnExcel" runat="server" Enabled="False" OnClick="btnExcel_Click" ToolTip="Export To Excel" />
                                        </div>
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" ToolTip="Cancel" Visible="false" />
                                        </div>
                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <asp:Label ID="lblError" runat="server" CssClass="Error"></asp:Label>
                                    <asp:Panel ID="pnlScroll" runat="server" CssClass="GridTbl">
                                        <asp:GridView ID="grdInvoice" runat="server" AutoGenerateColumns="False" CellPadding="1"
                                            OnSelectedIndexChanged="grdInvoice_SelectedIndexChanged" DataKeyNames="branchid,vouyear" Width="100%" CssClass="Grid FixedHeader" >
                                            <FooterStyle Font-Bold="True" />
                                            <Columns>

                                                <asp:CommandField SelectImageUrl="~/Images/select.gif" ButtonType="Image" ShowSelectButton="True">
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                    <ItemStyle Width="1px" Wrap="True" HorizontalAlign="Left"></ItemStyle>
                                                </asp:CommandField>

                                                <asp:BoundField DataField="type" HeaderText="Vou Type">
                                                    <ItemStyle Width="64px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="vouno" HeaderText="Vou #">
                                                    <ItemStyle Width="40px" Wrap="True"></ItemStyle>
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="vdate" HeaderText="Date">
                                                    <ItemStyle Width="40px" Wrap="True"></ItemStyle>
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="branch" HeaderText="Branch">
                                                    <ItemStyle Width="64px" Wrap="True"></ItemStyle>
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="trantype" HeaderText="Product">
                                                    <ItemStyle Width="104px" Wrap="False"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="blno" HeaderText="BL # / AWBL #">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="custname" HeaderText="Customer">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="curr" HeaderText="Curr">
                                                    <ItemStyle Width="5px"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="amount" HeaderText="Amount">
                                                    <ItemStyle Width="30px" Wrap="True" HorizontalAlign="Right" CssClass="TxtAlign1"></ItemStyle>
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="branchid" Visible="False">
                                                    <ControlStyle BorderStyle="None"></ControlStyle>
                                                    <ItemStyle BackColor="AliceBlue" BorderStyle="None" Width="1px" ForeColor="AliceBlue"></ItemStyle>
                                                    <HeaderStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue" Wrap="False"></HeaderStyle>
                                                    <FooterStyle BorderStyle="None"></FooterStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="vouyear" Visible="False">
                                                    <ItemStyle BackColor="AliceBlue" BorderStyle="None" Width="1px" ForeColor="AliceBlue"></ItemStyle>
                                                    <HeaderStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue"></HeaderStyle>
                                                </asp:BoundField>

                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle />
                                            <PagerStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="GrdHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <%--<table>
         <tr style="background-color:#507CD1;">
             <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
         <td><asp:Label runat="server" Text="Vou #" id="l1" Width="50px" CssClass="Title"></asp:Label></td>
         <td align="center"><asp:Label runat="server" Text="Vou Type" id="l2" Width="80px" CssClass="Title"></asp:Label></td>
         <td align="center"><asp:Label runat="server" Text="Branch" id="l3" Width="80px" CssClass="Title"></asp:Label></td>
         <td align="center"><asp:Label runat="server" Text="Product" id="l4" Width="130px" CssClass="Title"></asp:Label></td>
         <td align="center"><asp:Label runat="server" Text="Date" id="l5" Width="79px" CssClass="Title"></asp:Label></td>
         <td align="center"><asp:Label runat="server" Text="Doc #" id="l6" Width="160px" CssClass="Title"></asp:Label></td>
         <td align="center"><asp:Label runat="server" Text="Curr" id="l7" Width="30px" CssClass="Title"></asp:Label></td>
         <td align="center"><asp:Label runat="server" Text="Amount" id="l8" Width="91px" CssClass="Title"></asp:Label></td>       
         </tr>
         </table>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

