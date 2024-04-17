<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FEBLPrint.aspx.cs" Inherits="logix.FEBLPrint" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
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
    <!-- Demo JS -->
 <style type="text/css">

.row {
    background-color: #ffffff;
    clear: both;
    height: 615px;
    margin: 0;
    overflow-x: hidden;
    overflow-y:auto;
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
                                   <asp:Label ID="Label8" runat="server" Text="Bill of Lading"></asp:Label></h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="right_btn MT0">
                                        <div class="btn btn-print"><asp:Button ID="BtnPrint" runat="server"  Text="Print" /></div>
                                        <div class="btn ico-cancel"><asp:Button ID="BtnCancel" runat="server" Text="Cancel"  EnableViewState="False"
                                                OnClick="BtnCancel_Click"  Visible="False" /></div>
                                    </div>

                                    </div>
                              
                                    
                                          <div class="FormGroupContent4">
                                              <div class="LadingInput"><asp:TextBox ID="lblBLNo" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                              <div class="LadingDate"><asp:TextBox ID="lblBLDate" runat="server" CssClass="form-control"></asp:TextBox></div>
                                              <div class="LadingIssued"><asp:TextBox ID="lblIssuedAt" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                              </div>
                                        <div class="bordertopNew"></div>
                                        <div class="FormGroupContent4">
                                             <asp:TextBox ID="lblShipper" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Shipper" ToolTip="Shipper"></asp:TextBox>

                                            </div>
                                        <div class="FormGroupContent4">

                                            <asp:TextBox ID="lblConsignee" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Consignee" ToolTip="Consignee"></asp:TextBox>
                                        </div>
                                        <div class="FormGroupContent4"><asp:TextBox ID="lblNP" runat="server" ReadOnly="True" CssClass="form-control" placeholder=" Notify Party" ToolTip=" Notify Party"></asp:TextBox></div>
                                        <div class="FormGroupContent4"><asp:TextBox ID="lblAgent" runat="server" ReadOnly="True"  CssClass="form-control" placeholder="Delivery Agent" ToolTip="Delivery Agent"></asp:TextBox></div>
                                   
                                          <div class="bordertopNew"></div>
                                        <div class="FormGroupContent4">
                                           
                                             <div class="PlaceOfReceipt"><asp:TextBox ID="lblPlaceOfReceipt" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Place of Reciept" ToolTip="Place of Recieptt"> </asp:TextBox></div>
                                         
                                            <div class="PortOfLoading"><asp:TextBox ID="lblPortOfLoading" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Place of Reciept" ToolTip="Place of Recieptt"></asp:TextBox></div>
                                            <div class="PortOfDischarge"> <asp:TextBox ID="lblPortOfDischarge" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Port Of Discharge" ToolTip="Port Of Discharge"></asp:TextBox></div>
                                               <div class="FinalDestination"><asp:TextBox ID="lblFinalDestination" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Final Destination" ToolTip="Final Destination"></asp:TextBox></div>
                                        
                                        </div>
                                         <div class="bordertopNew"></div>
                                        <div class="FormGroupContent4">
                                            <div class="LadingVolume"><asp:TextBox ID="lblVolume" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Volume" ToolTip="Volume"></asp:TextBox></div>
                                            <div class="LadingWeight"><asp:TextBox ID="lblWeight" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Weight" ToolTip="Weight"></asp:TextBox></div>
                                            <div class="Ladingfreight"><asp:TextBox ID="lblFreightStatus" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Freight Status" ToolTip="Freight Status"></asp:TextBox></div>
                                            <div class="LadingPackage"><asp:TextBox ID="lblPackage" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Packages" ToolTip="Packages"></asp:TextBox></div>
                                            </div>
                                        <div class="FormGroupContent4">
                                            <div class="LadingMarks"><asp:TextBox ID="lblMarksNo" runat="server" TextMode="MultiLine" OnTextChanged="lblMarksNo_TextChanged" CssClass="form-control" placeholder="Marks & Numbers" ToolTip="Marks & Numbers"></asp:TextBox></div>
                                            <div class="LadingCargoDes"><asp:TextBox ID="lblCargo" runat="server" Height="33px" TextMode="MultiLine" CssClass="form-control" placeholder="Cargo Description" ToolTip="Cargo Description"></asp:TextBox></div>
                                            </div>
                                        <div class="bordertopNew"></div>
                                        <div class="FormGroupContent4">
                                            <asp:TextBox ID="lblFVandVoyage" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Feeder Vessel" ToolTip="Feeder Vessel"></asp:TextBox>

                                            </div>
                                         <div class="FormGroupContent4">
                                             <div class="LoadingPol"><asp:TextBox ID="lblPOL" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Feeder Vessel" ToolTip="Feeder Vessel"></asp:TextBox></div>
                                            
                                             <div class="LoadingETD"><asp:TextBox ID="lblETD" runat="server" ReadOnly="True" CssClass="form-control" placeholder="ETD" ToolTip="ETD"></asp:TextBox></div>
                                             <div class="LoadingPOD"><asp:TextBox ID="lblPOD" runat="server" ReadOnly="True" CssClass="form-control" placeholder="POD" ToolTip="POD"></asp:TextBox></div>
                                            <div class="LoadingETB"><asp:TextBox ID="lblETA" runat="server" ReadOnly="True" CssClass="form-control" placeholder="ETB" ToolTip="ETB"></asp:TextBox></div>
                                             
                                               </div>

                                <div class="FormGroupContent4">

                                    <div class="MotherLBL">Mother Vessel</div>
                                    <div class="MotherGrid">
                                    <asp:GridView ID="grdMVesselDtl" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="False" CellPadding="2" Width="100%">
                                                <FooterStyle />
                                                <Columns>
                                                    <asp:BoundField DataField="mvessel" HeaderText="Vessel &amp; Voyage">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="pol" HeaderText="POL"></asp:BoundField>
                                                    <asp:BoundField DataField="etd" HeaderText="ETD"></asp:BoundField>
                                                    <asp:BoundField DataField="pod" HeaderText="POD"></asp:BoundField>
                                                    <asp:BoundField DataField="eta" HeaderText="ETA"></asp:BoundField>
                                                </Columns>
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <EditRowStyle BackColor="#999999" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </div>
                                </div>
                                  <div class="FormGroupContent4">
                                       <asp:TextBox ID="lblInlandDetail" runat="server" ReadOnly="True" CssClass="form-control" placeholder="Inland Movement details" ToolTip="Inland Movement details"></asp:TextBox>

                                      </div>
                                <div class="FormGroupContent4">
                                    <div class="MotherLBL">Shipping Bill Details</div>
                                    <div class="MotherGrid"><asp:GridView ID="grdSBDtl" runat="server" AutoGenerateColumns="False" CellPadding="2" Width="100%" CssClass="Grid FixedHeader" >
                                                            <FooterStyle Font-Bold="True"  />
                                                            <Columns>
                                                                <asp:BoundField DataField="sbno" HeaderText="SB No"></asp:BoundField>
                                                                <asp:BoundField DataField="sbdate" HeaderText="SB Date"></asp:BoundField>
                                                            </Columns>
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        </asp:GridView></div>
                                </div>
                                        
                                <div class="FormGroupContent4">
                                     <div class="MotherLBL">Container Details</div>
                                    <div class="MotherGrid">
                                         <asp:GridView ID="grdContainers" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" >
                                                            <FooterStyle />
                                                            <Columns>
                                                                <asp:BoundField DataField="container" HeaderText="Container#"></asp:BoundField>
                                                                <asp:BoundField DataField="size" HeaderText="Size"></asp:BoundField>
                                                            </Columns>
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        </asp:GridView>

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
