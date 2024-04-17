<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eBL.aspx.cs" Inherits="logix.eBL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtool" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
        <script type="text/javascript" src="Scripts/Calendar.js"></script> 
    <script type="text/javascript" src="Scripts/Validation.js"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Style/jquery-ui.css" rel="Stylesheet" type="text/css" />
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
       .row {
    height: 560px !important;
    margin: 0px 0px 0px 0px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    background-color: #ffffff;
    /* width: 100%; */
}
   </style>

    <!-- Demo JS -->
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
</head>
<body>
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
            <asp:MultiView ID="MvwMain" runat="server" ActiveViewIndex="0">
                <asp:View ID="vwHead" runat="server">

                              <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i>Home </li>
           
              <li>e-BL</li>
              <li class="current">e-BL</li>
            </ul>
      </div>

<div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box">
     
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="LBLTitle" runat="server" CssClass="Title"></asp:Label></h4>
                </div>
          <div class="widget-content">
             
              <div class="FormGroupContent4">
                  <div class="FromTxt"> <asp:Label ID="Label1" runat="server" Text="From"></asp:Label></div>
                  <div class="FromTxtbox"><asp:TextBox ID="dtFrom" runat="server" CssClass="form-control" placeholder="From" ToolTip="From"></asp:TextBox>

                       <ajaxtool:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtFrom"
                                Format="dd/MM/yyyy"></ajaxtool:CalendarExtender>
                  </div>
              <%--    <div class="CalImg"><asp:Image ID="ImgFrm" runat="server" Height="16px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="16px" /></div>--%>
                  <div class="ToTxt"> <asp:Label ID="Label2" runat="server" Text="To"></asp:Label></div>
                  <div class="ToTxtBox"><asp:TextBox ID="dtTo" runat="server" CssClass="form-control" placeholder="To" ToolTip="To"></asp:TextBox>
                         <ajaxtool:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtTo"
                                Format="dd/MM/yyyy"></ajaxtool:CalendarExtender>
                  </div>
                <%--  <div class="CalImg"><asp:Image ID="ImgTo" runat="server" Height="16px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="16px" /></div>--%>
                  </div>

              <div class="FormGroupContent4">

                  <div class="right_btn MT0">

                      <div class="btn btn-find"> <asp:Button ID="BtnSelect" runat="server" OnClick="BtnSelect_Click" Text="Find" /></div>
                      <div class="btn ico-cancel"><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></div>

                  </div>



              </div>

                   <asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label><br />
                    <asp:Panel ID="pnlOIE" runat="server" Height="350px" ScrollBars="Auto" Width="100%">
                        <asp:GridView ID="GrdFEIBL" runat="server" AutoGenerateColumns="False" DataKeyNames="branchid,divisionid"
                            CellPadding="2" CellSpacing="1" Width="100%" CssClass="Grid FixedHeader" >
                            <Columns>
                                <asp:CommandField SelectImageUrl="~/Images/select.gif" ButtonType="Image" ShowSelectButton="True"><ItemStyle Width="10px" Height="10px" HorizontalAlign="Center"></ItemStyle></asp:CommandField>
                                <asp:BoundField DataField="branch" HeaderText="Branch"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="blno" HeaderText="BL #"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="bldate" HeaderText="BL Date"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="vessel" HeaderText="Feeder Vessel "><ItemStyle Wrap="False"></ItemStyle><HeaderStyle Wrap="False"></HeaderStyle></asp:BoundField>
                                <asp:BoundField DataField="pol" HeaderText="POL"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="etd" HeaderText="ETD"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="pod" HeaderText="POD"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="eta" HeaderText="ETA"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="shipmentstatus" HeaderText="Status" Visible="False"><ItemStyle Wrap="False"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="branchid" Visible="False"><ControlStyle BorderStyle="None"></ControlStyle><ItemStyle Width="0px" Wrap="True"></ItemStyle><HeaderStyle BorderStyle="None" ForeColor="AliceBlue"></HeaderStyle><FooterStyle BorderStyle="None"></FooterStyle></asp:BoundField>
                                <asp:BoundField DataField="divisionid" Visible="False"><ItemStyle Width="0px" /></asp:BoundField>
                            </Columns>
                            <RowStyle CssClass="GrdRow" />
                            <HeaderStyle CssClass="GrdHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>
              </div>
         </div>
            </div>
    </div>






                    
               
                </asp:View>
                <asp:View ID="vwBl" runat="server">
                    <table class="OuterTable" cellpadding="2" cellspacing="0">
                        <tr>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="2" width="400px">
                                    <tr class="Header">
                                        <td>
                                            <asp:Label ID="BillDetails" CssClass="Label" runat="server" Text="Bill of Lading Details"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 208px">
                                            <%--<marquee width="150">--%>
                                            &nbsp;
                                        </td>
                                        <td align="right" colspan="2">
                                            &nbsp; &nbsp;<asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click"
                                                TabIndex="35" CssClass="button" />
                                            <asp:Button ID="btnView" runat="server" Text=" View " TabIndex="36" CssClass="button"
                                                OnClick="btnView_Click" />
                                            <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="37"
                                                CssClass="button" />
                                        </td>
                                    </tr>
                                    <%--  <tr>
                <td colspan="4" align="right">
                    <asp:LinkButton ID="lnkJobNo" runat="server" OnClick="lnkJobNo_Click" CssClass="Link" >Job #</asp:LinkButton>&nbsp;<asp:TextBox ID="txtJobNo" runat="server" Width="41px" AutoPostBack="True" OnTextChanged="txtJobNo_TextChanged" TabIndex="1"></asp:TextBox>
                    <asp:TextBox ID="txtJobDetails" runat="server"   ReadOnly="True" Width="447px" Font-Bold="True" BackColor="AliceBlue" ForeColor="Blue"></asp:TextBox>&nbsp;<asp:LinkButton ID="lnkBooking" runat="server" OnClick="lnkBooking_Click" CssClass="Link" >Booking #</asp:LinkButton>&nbsp;
                    <asp:TextBox ID="txtBookingNo" runat="server"></asp:TextBox></td>
            </tr>--%>
                                    <tr>
                                        <td class="Label">
                                            BL #
                                        </td>
                                        <td class="Label">
                                            Issued At
                                        </td>
                                        <td class="Label">
                                            Issued On&nbsp;
                                        </td>
                                        <td class="Label">
                                            Freight
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtBLNo" runat="server" Width="162px"></asp:TextBox>
                                        </td>
                                        <td style="width: 208px">
                                            <asp:TextBox ID="txtIssuedAt" runat="server" Width="198px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssuedOn" runat="server" Width="87px" TabIndex="5" MaxLength="10"></asp:TextBox><asp:Image
                                                ID="ImgIssu" runat="server" Height="19px" ImageAlign="Middle" ImageUrl="~/Images/Calender.jpg" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFreight" runat="server" Width="168px" TabIndex="6" CssClass="Text">
                                                <asp:ListItem>PrePaid</asp:ListItem>
                                                <asp:ListItem>To Collect</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="Label">
                                            Shipper
                                        </td>
                                        <td colspan="2" class="Label">
                                            Consignee
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtShipperName" runat="server" Width="371px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtConsigneeName" runat="server" Width="375px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtShipperAddr" runat="server" TextMode="MultiLine" Width="371px"
                                                TabIndex="8" MaxLength="250" CssClass="Text"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtConsigneeAdr" runat="server" TextMode="MultiLine" Width="375px"
                                                TabIndex="10" MaxLength="250" CssClass="Text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="Label">
                                            Notify Party
                                        </td>
                                        <td colspan="2" class="Label">
                                            Agent
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtNPName" runat="server" Width="371px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAgentName" runat="server" Width="375px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtNPAddr" runat="server" TextMode="MultiLine" Width="371px" TabIndex="12"
                                                MaxLength="250" CssClass="Text"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAgentAddr" runat="server" TextMode="MultiLine" Width="375px"
                                                TabIndex="14" MaxLength="250" CssClass="Text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" class="Label">
                                            Place of Receipt
                                        </td>
                                        <td valign="bottom" class="Label">
                                            Port of Loading
                                        </td>
                                        <td valign="bottom" class="Label">
                                            Port of Discharge
                                        </td>
                                        <td valign="bottom" align="left" class="Label">
                                            Final Destination
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            <asp:TextBox ID="txtPOR" runat="server" Width="162px"></asp:TextBox>
                                        </td>
                                        <td valign="bottom" style="width: 208px">
                                            <asp:TextBox ID="txtPOL" runat="server" Width="198px"></asp:TextBox>
                                        </td>
                                        <td valign="bottom">
                                            <asp:TextBox ID="txtPOD" runat="server" Width="202px"></asp:TextBox>
                                        </td>
                                        <td valign="bottom">
                                            <asp:TextBox ID="txtFD" runat="server" Width="163px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" class="Label">
                                            Marks And Numbers
                                        </td>
                                        <td class="Label">
                                            Commodity
                                        </td>
                                        <td class="Label">
                                            Original BL
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtMksNum" runat="server" Width="371px" TabIndex="19" MaxLength="250"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCommudity" runat="server" Width="202px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOriginalBL" runat="server" Width="162px" TabIndex="20" MaxLength="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" class="Label">
                                            Description
                                        </td>
                                        <td align="left" colspan="2" class="Label">
                                            CHA
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtDesc" runat="server" Width="371px" TabIndex="21" MaxLength="250"
                                                Font-Overline="False"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtCHA" runat="server" Width="376px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table cellpadding="1" cellspacing="0">
                                                <tr>
                                                    <td class="Label">
                                                        CBM
                                                    </td>
                                                    <td class="Label">
                                                        G.Wt.Kgs
                                                    </td>
                                                    <td class="Label">
                                                        N.Wt.Kgs
                                                    </td>
                                                    <td class="Label">
                                                        No of Pkg
                                                    </td>
                                                    <td align="left" style="width: 100px">
                                                        Units
                                                    </td>
                                                    <td class="Label">
                                                        Shipment
                                                    </td>
                                                    <td class="Label">
                                                        Surrendered
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCBM" runat="server" TabIndex="23" Width="60px" MaxLength="3"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtGrWt" runat="server" TabIndex="24" Width="60px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNtWt" runat="server" TabIndex="25" Width="60px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPackages" runat="server" Width="60px" TabIndex="31" Height="16px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px">
                                                        <asp:DropDownList ID="ddlUnits" runat="server" Width="98px" AutoPostBack="True" TabIndex="26"
                                                            CssClass="Text">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSpmtType" runat="server" Width="92px" TabIndex="27" CssClass="Text">
                                                            <asp:ListItem>FCL/FCL</asp:ListItem>
                                                            <asp:ListItem>FCL/LCL</asp:ListItem>
                                                            <asp:ListItem>LCL/LCL</asp:ListItem>
                                                            <asp:ListItem>LCL/FCL</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSurrendered" runat="server" Width="74px" TabIndex="28" CssClass="Text">
                                                            <asp:ListItem>NO</asp:ListItem>
                                                            <asp:ListItem>YES</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td colspan="1" rowspan="3" valign="top" align="left" class="Label">
                                            Containers<asp:Panel ID="Panel1" runat="server" Width="168px" ScrollBars="Vertical"
                                                Height="75px" CssClass="Pnl">
                                                &nbsp;<asp:ListBox ID="ListBox1" runat="server" Width="143px"></asp:ListBox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" class="Label">
                                            Remarks
                                        </td>
                                        <td align="left" class="Label">
                                            BL Signatory
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtRemarks" runat="server" Width="371px" MaxLength="100" TabIndex="31"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSignatory" runat="server" TabIndex="32" Width="203px" CssClass="Text">
                                                <asp:ListItem>Authorized Signatory</asp:ListItem>
                                                <asp:ListItem>As Agent</asp:ListItem>
                                                <asp:ListItem>As Carrier</asp:ListItem>
                                                <asp:ListItem>As Agent for PAN Global Lines</asp:ListItem>
                                                <asp:ListItem>As Carrier for PAN Global Lines</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="Label">
                                            BL&nbsp;Format
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;<asp:DropDownList ID="ddlBLFormat" runat="server" Width="375px" CssClass="Text"
                                                TabIndex="34">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:CheckBox Text="Agent Controlled Business" ID="chkNormination" runat="server"
                                                TabIndex="33" Width="203px" />
                                        </td>
                                        <td>
                                            <asp:CheckBox Text="DGCargo" ID="chkDGCargo" runat="server" TabIndex="25" CssClass="Error"
                                                Enabled="False" Width="168px" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="txtIssuedAtId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtMsgRes" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtOldCbm" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtShipperId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtConsId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtNotifyPartyId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtAgentId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtPorId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtPolId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtPodId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtFdId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="txtChaId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hidCommudityID" runat="server" />
                                <asp:HiddenField ID="hidSalesID" runat="server" />
                                <asp:HiddenField ID="hidBLFormat" runat="server"></asp:HiddenField>
                                <%--  <asp:View id="vwJob" runat="server">
        <table cellspacing="0">
                                <tr class="Header">
                                    <td align="left"><asp:Label ID="Label2" runat="server" Text="Job Information"></asp:Label></td>
                                    <td align="right"><asp:Button ID="btnBackJob" runat="server" Text="Back" OnClick="btnBackJob_Click" CssClass="Button" Width="50px" /></td>
                                </tr>
                                        
                                        <tr>
                           <td colspan="2"><asp:Panel ID="pnlJobScroll" runat="server" ScrollBars="Both" Height="430px" Width="750px">
                                        <asp:GridView ID="gdJobNo" runat="server" Width="726px" AutoGenerateColumns="False" OnSelectedIndexChanged="gdJobNo_SelectedIndexChanged" CellPadding="1" OnRowDataBound="gdJobNo_RowDataBound">
                                                        <Columns>
<asp:CommandField SelectImageUrl="~/Images/NonSelect.JPG" ButtonType="Image" ShowSelectButton="True">
<ItemStyle Width="5px" Wrap="False"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="jobno" HeaderText="Job#">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="vessel" HeaderText="Vessel">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="voyage" HeaderText="Voyage">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mblno" HeaderText="MBL #">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="etd" HeaderText="ETD">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="sd" HeaderText="Destination">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="eta" HeaderText="ETA">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
</columns>
  <headerstyle cssclass="GrdHeader" /><alternatingrowstyle cssclass="GrdAltRow" />
 </asp:GridView>
 </asp:Panel>
 </td>
 </tr>
 </table>
        </asp:View>
        <asp:View id="vwBooking" runat="server">
            <table cellspacing="0">
                                <tr class="Header">
                                    <td><asp:Label ID="Label3" runat="server" Text="Booking Information"></asp:Label></td>
                                    <td align="right"><asp:Button ID="btnBackBooking" runat="server" Text="Back" OnClick="btnBackBooking_Click" CssClass="Button" Width="50px" /></td>
                                </tr>
                           <tr>
              <td colspan="2">
                  <asp:Panel ID="pnlBkgScroll" runat="server" ScrollBars="Both" width="750px" Height="430px">
                           <asp:GridView ID="grdBooking" runat="server"  AutoGenerateColumns="False" OnSelectedIndexChanged="grdBooking_SelectedIndexChanged" Width="729px" OnRowDataBound="grdBooking_RowDataBound">
                                <Columns>
<asp:CommandField SelectImageUrl="~/Images/NonSelect.JPG" ButtonType="Image" ShowSelectButton="True">
<ItemStyle Width="5px"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="bookingno" HeaderText="Booking #">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bookingdate" HeaderText="Booking Date">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="customername" HeaderText="Customer">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="POL" HeaderText="POL">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="POD" HeaderText="POD">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fstatus" HeaderText="Status">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
</Columns>               

<headerstyle cssclass="GrdHeader" />
<alternatingrowstyle cssclass="GrdAltRow" />
</asp:GridView>
</asp:Panel>
</td>
</tr>
</table>
        </asp:View>--%>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
