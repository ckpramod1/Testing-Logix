<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AIEBLPrint.aspx.cs" Inherits="logix.AIEBLPrint" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>

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

    <!-- Smartphone Touch Events -->

    <!-- General -->












   
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
    </style>
</head>
<body style="margin-left: 10px; margin-top: 10px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading....
            Please wait...
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

             <!-- Breadcrumbs line -->
                <div class="crumbs">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>
                        <li class="current" id="lbl" runat="server">Bill Of Lading</li>
                    </ul>
                </div>

             <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header" id="div_BLDetails" runat="server">
                                <h4><i class="icon-umbrella"></i>
                                   <asp:Label ID="Label4" runat="server" CssClass="Title" Text="Bill of Lading"></asp:Label></h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">

                                    <div class="btnCancel">  <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" Visible="False" /></div>


                                </div>
                                <div class="FormGroupContent4">
                                    <div class="AWBLInput"><asp:TextBox ID="txtAWBL" runat="server" CssClass="form-control" TabIndex="1" ToolTip="AWBL#" placeholder="AWBL#"></asp:TextBox></div>
                                    <div class="AWBLIssued"><asp:TextBox ID="txtIssuedon" runat="server" CssClass="form-control" TabIndex="2" ToolTip="IssuedOn" placeholder="IssuedOn"></asp:TextBox></div>
                                    <div class="AWBLIssueat"><asp:TextBox ID="txtIssuedat" runat="server" CssClass="form-control" TabIndex="3" ToolTip="Issued At" placeholder="Issued At"></asp:TextBox></div>
                                
                                
                                </div>
                                 <div class="FormGroupContent4">

                                      <asp:TextBox ID="txtShipr" runat="server" CssClass="form-control" TabIndex="4" ToolTip="Shipper" placeholder="Shipper"></asp:TextBox>
                                     </div>

                                <div class="FormGroupContent4">

                                    <asp:TextBox ID="txtCons" runat="server" CssClass="form-control" TabIndex="5" ToolTip="Consignee" placeholder="Consignee"></asp:TextBox>


                                </div>
                                <div class="FormGroupContent4">
                                    <asp:TextBox ID="txtNP1" runat="server" CssClass="form-control" TabIndex="6" ToolTip="NotifyParty I" placeholder="NotifyParty I"></asp:TextBox>
                                    </div>
                                <div class="FormGroupContent4">
                                    <asp:TextBox ID="txtNP2" runat="server" CssClass="form-control" TabIndex="7" ToolTip="NotifyParty I" placeholder="NotifyParty I"></asp:TextBox>
                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="AWBLFromPort"><asp:TextBox ID="txtFrmPort" runat="server" TabIndex="8" CssClass="form-control" placeholder="From Port" ToolTip="From Port"></asp:TextBox></div>
                                    <div class="AWBLTOPort"> <asp:TextBox ID="txtToPort" runat="server" TabIndex="9" CssClass="form-control" placeholder="To Port" ToolTip="To Port"></asp:TextBox></div>

                                </div>
                                <div class="FormGroupContent4">
                                    <asp:TextBox ID="txtCNF" runat="server" CssClass="form-control" TabIndex="10" placeholder="CNF" ToolTip="CNF"></asp:TextBox>

                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="AWBLTo"><asp:TextBox ID="txtPOD1" runat="server" TabIndex="11" CssClass="form-control" placeholder="To" ToolTip="To"></asp:TextBox></div>
                                    <div class="AWBLBy"><asp:TextBox ID="txtCarrier1" runat="server" TabIndex="12" CssClass="form-control" placeholder="By" ToolTip="By"></asp:TextBox></div>
                                    </div>
                                 <div class="FormGroupContent4">
                                     <div class="AWBLTo"><asp:TextBox ID="txtPOD2" runat="server" TabIndex="13"  CssClass="form-control" placeholder="To" ToolTip="To"></asp:TextBox></div>
                                     <div class="AWBLBy"><asp:TextBox ID="txtCarrier2" runat="server" TabIndex="14"  CssClass="form-control" placeholder="By" ToolTip="by"></asp:TextBox></div>
                                     </div>
                                 <div class="FormGroupContent4">
                                     <div class="AWBLTo"> <asp:TextBox ID="txtPOD3" runat="server" TabIndex="15" CssClass="form-control" placeholder="To" ToolTip="To"></asp:TextBox></div>
                                    <div class="AWBLBy"><asp:TextBox ID="txtCarrier3" runat="server" TabIndex="16" CssClass="form-control" placeholder="By" ToolTip="By"></asp:TextBox></div>
                                      </div>
                                 <div class="FormGroupContent4">
                                     <asp:TextBox ID="txtHndlInfo" runat="server" CssClass="form-control" TabIndex="17" placeholder="Handling Information" ToolTip="Handling Information"></asp:TextBox>

                                     </div>
                                <div class="FormGroupContent4">
                                    <div class="PackagesTxtBox"><asp:TextBox ID="txtPkgs" runat="server" TabIndex="18" CssClass="form-control" placeholder="Packages" ToolTip="Packages"></asp:TextBox></div>
                                    <div class="GrossWtTxtBox"><asp:TextBox ID="txtGrossWt" runat="server" TabIndex="19" CssClass="form-control" placeholder="Packages" ToolTip="Packages"></asp:TextBox></div>
                                    <div class="ChargeTxtBox"> <asp:TextBox ID="txtChrgWt" runat="server" TabIndex="20" CssClass="form-control" placeholder="ChargeWt" ToolTip="ChargeWt"></asp:TextBox></div>
                              <div class="QuantityTxtBox"><asp:TextBox ID="txtQty" runat="server" TabIndex="21" CssClass="form-control" placeholder="Quantity" ToolTip="Quantity"></asp:TextBox></div>
                                      </div>
                                <div class="FormGroupContent4">
                                    Dimension


                                </div>
                                <div class="FormGroupContent4">

                                    <asp:GridView ID="grdBLDim" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                        ForeColor="#333333" Width="100%" CssClass="Grid FixedHeader" >
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="length" HeaderText="Length"></asp:BoundField>
                                            <asp:BoundField DataField="width" HeaderText="Width"></asp:BoundField>
                                            <asp:BoundField DataField="breadth" HeaderText="Breadth"></asp:BoundField>
                                            <asp:BoundField DataField="pieces" HeaderText="Pieces"></asp:BoundField>
                                        </Columns>
                                        <RowStyle BackColor="#EFF3FB" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>

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
