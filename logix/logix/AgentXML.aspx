<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentXML.aspx.cs" Inherits="logix.AgentXML" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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




    <!-- Forms -->










</head>
<body style="margin-left:10px;margin-top:10px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdateProgress id="UpdateProgress1" runat="server">
        <progresstemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
</progresstemplate>
    </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

              <!-- Breadcrumbs line -->
                <div class="crumbs">
                    <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>
                        <li class="current" id="lbl" runat="server">Ocean Exports</li>
                    </ul>
                </div>

            <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header" id="div_BLDetails" runat="server">
                                <h4><i class="icon-umbrella"></i>
                                   <asp:Label ID="lbl_header" runat="server"  Text="Ocean Exports"></asp:Label></h4>
                            </div>
                            <div class="widget-content"  id="TABLE1" onclick="return TABLE1_onclick()">
                                <div class="FormGroupContent4">
                                    <div class="OceanExpLBL"><asp:Label ID="LBLTitle" runat="server" CssClass="Title">Ocean Exports</asp:Label></div>
                                    <div class="right_btn MT0">
                                        <div class="btn btn-find"><asp:Button ID="BtnSelect" runat="server" Text="Find" OnClick="BtnSelect_Click" /></div>
                                        <div class="btn btn-create"><asp:Button id="Save" runat="server" OnClick="Save_Click" Text="Create XML " Enabled="False"></asp:Button></div>
                                        <div class="btn ico-cancel"><asp:Button id="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></div>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="OceanFromLbl"><asp:Label ID="Label1" runat="server"  Text="From"></asp:Label></div>
                                        <div class="OceanFromTxt"><asp:TextBox ID="dtFrom" runat="server" CssClass="form-control"></asp:TextBox></div>
                                        <div class="OceancalImg"><asp:Image ID="ImgFrm" runat="server" Height="19px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="18px" /></div>
                                       
                                        <div class="OceanToLbl"><asp:Label ID="Label2" runat="server"  Text="To"></asp:Label></div>
                                        <div class="OceanToTxtbox"><asp:TextBox ID="dtTo" runat="server" CssClass="form-control"></asp:TextBox></div>
                                        <div class="OceancalImg1"><asp:Image ID="ImgTo" runat="server" Height="19px" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" Width="18px" /></div>
                                         </div>
                                    <div class="FormGroupContent4">
                                        <asp:Panel id="pnl1" runat="server" Height="300px" Width="100%" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1px" Visible="False">
          <asp:GridView ID="GrdXML" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="100%" BorderWidth="0px" CellPadding="2" ForeColor="#333333" DataKeyNames="branchid" >
       <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
   <Columns>
<asp:BoundField DataField="branch" HeaderText="Branch">
<ItemStyle Wrap="False"></ItemStyle>
    <HeaderStyle Width="75px" />
</asp:BoundField>
<asp:BoundField DataField="jobno" HeaderText="Job #">
<ItemStyle Wrap="True"></ItemStyle>
    <HeaderStyle Width="55px" Wrap="False" />
</asp:BoundField>
       <asp:BoundField DataField="jobtype" HeaderText="JobType" />
<asp:BoundField DataField="jobdate" HeaderText="Job Date">
<ItemStyle Wrap="True"></ItemStyle>
    <HeaderStyle Width="70px" Wrap="False" />
</asp:BoundField>
<asp:BoundField DataField="vessel" HeaderText="Vessel &amp; Voyage">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Wrap="False" Width="200px"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="pol" HeaderText="POL">
<ItemStyle Wrap="True"></ItemStyle>
    <HeaderStyle Width="175px" />
</asp:BoundField>
<asp:BoundField DataField="pod" HeaderText="POD">
<ItemStyle Wrap="True"></ItemStyle>
    <HeaderStyle Width="175px" />
</asp:BoundField>
<asp:TemplateField HeaderText="XML">
<ItemStyle Width="40px"></ItemStyle>

<HeaderStyle Wrap="False"></HeaderStyle>
<ItemTemplate>
            <asp:CheckBox ID="XmlChk" runat="server"/>
            
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="branchid" Visible="False">
<ControlStyle BorderStyle="None"></ControlStyle>

<ItemStyle BackColor="AliceBlue" BorderStyle="None" Width="1px" ForeColor="AliceBlue" Wrap="True"></ItemStyle>

<HeaderStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue"></HeaderStyle>

<FooterStyle BorderStyle="None"></FooterStyle>
</asp:BoundField>
</Columns>
       <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
       <editrowstyle backcolor="#999999" />
       <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
       <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
       <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" BorderColor="WhiteSmoke" BorderStyle="Solid" BorderWidth="1px" CssClass="FixedHeader" />
       <alternatingrowstyle backcolor="White" forecolor="#284775" />
  </asp:GridView>
        </asp:Panel>
                                    </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                </div>












    

<table>
    <tr>
    <td>
        
  </td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
