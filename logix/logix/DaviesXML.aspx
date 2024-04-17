<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DaviesXML.aspx.cs" Inherits="logix.DaviesXML" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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


</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif" />Loading....
                Please wait...
            </ProgressTemplate>
        </asp:UpdateProgress>
    
    <%--<table cellspacing="0" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr style="background-color: #0296f8">
            <td colspan="2">
                <asp:Label ID="LBLTitle" runat="server" CssClass="Title">Ocean Exports</asp:Label></td>
            <td colspan="3" align="right"><asp:Button ID="BtnSelect" runat="server" Text="Find" OnClick="BtnSelect_Click" Width="50px" CssClass="button" />
                <asp:Button id="btnXML" runat="server" OnClick="Save_Click" Text="Create XML " Width="77px" Enabled="False" CssClass="button"></asp:Button>
                <asp:Button id="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="button" /></td>
        </tr>
        
        
        <tr>
            <td style="text-align: right"><asp:Label ID="Label1" runat="server"  Text="From"></asp:Label></td>
            <td><asp:TextBox ID="dtFrom" runat="server" Width="85px"></asp:TextBox><asp:Image ID="ImgFrm" runat="server" Height="19px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="18px" /></td>
            <td style="text-align: right"><asp:Label ID="Label2" runat="server"  Text="To"></asp:Label></td>
            <td><asp:TextBox ID="dtTo" runat="server" Width="85px"></asp:TextBox><asp:Image ID="ImgTo" runat="server" Height="19px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="18px" /></td>
        </tr>
    </table>--%>

         <!-- Breadcrumbs line -->
                <div class="crumbs">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>
                        <li class="current" id="lbl" runat="server"><asp:Label ID="LBLTitle" runat="server">Ocean Exports</asp:Label></li>
                    </ul>
                </div>

            <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header">
                                <h4><i class="icon-umbrella"></i>
                                   <asp:Label ID="Label1" runat="server" Text="Ocean Exports"></asp:Label></h4>
                            </div>
                            <div class="widget-content" id="TABLE1">
                                <div class="FormGroupContent4">
                                    <div class="right_btn MT0">
                                        <div class="btn btn-create"><asp:Button id="btnXML" runat="server" OnClick="Save_Click" Text="Create XML " Enabled="False"></asp:Button></div>
                                        <div class="btn ico-cancel"><asp:Button id="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"  /></div>

                                    </div>

                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="Containerfrom"><asp:TextBox ID="txtconno" runat="server" CssClass="form-control"></asp:TextBox></div>

                                    </div>
                                <div class="FormGroupContent4">
                                    <div class="ContfromLbl">From</div>
                                    <div class="Contfrom"><asp:TextBox ID="dtFrom" runat="server" CssClass="form-control"></asp:TextBox></div>
                                    <div class="CalImgAlign"><asp:Image ID="ImgFrm" runat="server"  ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg"  /></div>

                                    <div class="ContToLBl">To</div>
                                    <div class="ContToTxtBox"><asp:TextBox ID="dtTo" runat="server" CssClass="form-control"></asp:TextBox></div>
                                    <div class="CalImgAlign"><asp:Image ID="ImgTo" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" /></div>
                                </div>
                                <div class="FormGroupContent4">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label>

                                </div>
                                <div class="FormGroupContent4">

                                    <asp:Panel ID="Panel1" runat="server" Height="300px" Width="100%" ScrollBars="Auto">
            <asp:GridView ID="grdDavis" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"   Width="100%"  DataKeyNames="bid,cid,jobno" BorderColor="White" OnSelectedIndexChanged="grdDavis_SelectedIndexChanged" >
      <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
      <Columns>
          <asp:BoundField DataField="branch" HeaderText="Branch">
              <ItemStyle Width="70px" Wrap="False" />
          </asp:BoundField>
          <asp:BoundField DataField="jobtype" HeaderText="Our Ref #" >
              <HeaderStyle Wrap="False" />
              <ItemStyle Wrap="False" />
          </asp:BoundField>
          <asp:BoundField DataField="vessel" HeaderText="Vessel &amp; Voyage">
              <ItemStyle Wrap="False" />
              <HeaderStyle Wrap="False" />
          </asp:BoundField>
          <asp:BoundField DataField="pol" HeaderText="PoL">
              <ItemStyle Width="85px" Wrap="True" />
          </asp:BoundField>
          <asp:BoundField DataField="pod" HeaderText="PoD">
              <ItemStyle Width="85px" Wrap="True" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Sailed On" DataField="sailed">
              <HeaderStyle Wrap="False" />
              <ItemStyle Wrap="False" />
          </asp:BoundField>
          <asp:CommandField ShowSelectButton="True" />
          <asp:BoundField DataField="bid" Visible="False">
              <ControlStyle BorderStyle="None" />
              <ItemStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue" Width="1px"
                  Wrap="True" />
              <HeaderStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue" />
              <FooterStyle BorderStyle="None" />
          </asp:BoundField>
          <asp:BoundField DataField="cid" Visible="False" />
          <asp:BoundField DataField="jobno" Visible="False" />
      </Columns>
      <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
      <editrowstyle backcolor="#999999" />
      <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
      <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
      <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
      <alternatingrowstyle backcolor="White" forecolor="#284775" />
  </asp:GridView>
        </asp:Panel>

                                </div>
                                 <div class="FormGroupContent4">
                                     <asp:Panel ID="Panel2" runat="server" Height="300px" Width="350px" ScrollBars="Auto">
                <asp:GridView ID="grdBL" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="98%" BorderWidth="1px" CellPadding="2" ForeColor="#333333" BorderColor="White" >
                    <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="BL #" DataField="blno">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="consignee" HeaderText="Consignee">
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
                    <editrowstyle backcolor="#999999" />
                    <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                    <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
                    <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                    <alternatingrowstyle backcolor="White" forecolor="#284775" />
                </asp:GridView>
            </asp:Panel>

                                     </div>
                                </div>
                            </div>
                        </div>
                </div>





    <table cellspacing="0"  cellpadding ="3">
        <tr style="background-color: #0296f8">
            <td colspan="2">
                </td>
            <td align="right" colspan="3">
           <%-- <asp:Button ID="BtnSelect" runat="server" Text="Find" OnClick="BtnSelect_Click" Width="50px" CssClass="button" />--%>&nbsp;
                
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                </td>
            <td colspan="3">
                </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                </td>
            <td>
                &nbsp;</td>
            <td colspan="2">
                
                </td>
        </tr>
        
        </table>
        &nbsp;
        
    <table>
            <tr><td>
                
                </td><td valign="top">
            
        </td></tr>
        </table>
        <asp:HiddenField ID="hidBranchID" runat="server" />
        <asp:HiddenField ID="hidJobNo" runat="server" />
        <asp:HiddenField ID="hidDivID" runat="server" />
    </form>
</body>
</html>
