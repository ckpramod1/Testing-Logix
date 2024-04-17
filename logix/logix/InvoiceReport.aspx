<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceReport.aspx.cs" Inherits="logix.InvoiceReport" EnableEventValidation="false" %>

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
</head>
<body style="margin-left: 5px; margin-top: 5px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <!-- Breadcrumbs line -->
                <div class="crumbs">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Accounts</li>
                        <li class="current">Invoice Report</li>
                    </ul>
                </div>
                <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header">
                                <h4><i class="icon-umbrella"></i>
                                    <asp:Label ID="lblhead" runat="server" Text="Invoice"></asp:Label></h4>
                            </div>
                            <div class="widget-content">

                                <div class="FormGroupContent4">

                                    <div class="right_btn MT0">
                                        <div class="btn ico-view" style="display:none;">
                                            <asp:Button ID="btnView" runat="server" Text=" View " UseSubmitBehavior="False" TabIndex="1" OnClick="btnView_Click" /></div>
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" Visible="False" TabIndex="2" /></div>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <div class="BTNInvocie">
                                        <asp:Label ID="lblNO" runat="server" Text="Invoice #"></asp:Label></div>
                                    <div class="BTNInput">
                                        <asp:TextBox ID="txtInvno" runat="server" OnTextChanged="txtInvno_TextChanged" TabIndex="3" CssClass="form-control" ReadOnly="True" ToolTip="Invoice"></asp:TextBox></div>
                                    <div class="BTNInput1">
                                        <asp:TextBox ID="txtVouyear" runat="server" TabIndex="4" CssClass="form-control" ReadOnly="True" ToolTip="Invoice"></asp:TextBox></div>
                                    <div class="right_btn MT0">
                                        <div class="InvoiceTxt">
                                            <asp:Label ID="lblinvdate" runat="server" Text="Invoice Date" TabIndex="5"></asp:Label></div>
                                        <div class="InvocieTxtBox">
                                            <asp:TextBox ID="dtinvoice" runat="server" TabIndex="6" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                                    </div>
                                </div>
                                <div class="bordertopNew"></div>

                                <div class="FormGroupContent4">
                                    <div class="InvocieCustomerTxtBox">

                                        <asp:TextBox ID="txtCustomer" runat="server" Height="100px" TextMode="MultiLine" Width="100%" TabIndex="7" CssClass="form-control" ReadOnly="True" placeholder="Customer" ToolTip="Customer"></asp:TextBox>

                                    </div>
                                    <div class="InvocieShipment">
                                        <asp:TextBox ID="txtShipment" runat="server" Height="100px" TextMode="MultiLine" TabIndex="8" CssClass="form-control" ReadOnly="True" placeholder="Shipment Details" ToolTip="Shipment Details"></asp:TextBox></div>
                                </div>
                                <div class="bordertopNew"></div>
                                <div class="FormGroupContent4">

                                    <asp:Panel ID="PnlGrd" runat="server" Width="100%" ScrollBars="Auto" Visible="False">
                                        <asp:GridView ID="GrdInvRpt" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" >

                                            <Columns>
                                                <asp:BoundField ReadOnly="True" DataField="charge" HeaderText="Charges">
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Curr" HeaderText="Curr">
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rate" HeaderText="Rate">
                                                    <ControlStyle Width="10px"></ControlStyle>

                                                    <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="base" HeaderText="Base">
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField ReadOnly="True" DataField="exrate" HeaderText="ExRate">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField ReadOnly="True" DataField="amount" HeaderText="Amount">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />

                                        </asp:GridView>
                                    </asp:Panel>



                                </div>
                                <div class="FormGroupContent4">
                                    <div class="right_btn MT0">
                                        <div class="TotalTxtBox1">Total</div>
                                        <div class="TotalInputBox">
                                            <asp:TextBox ID="txttotal" Style="text-align: right" runat="server" TabIndex="9" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>

                                    </div>
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
