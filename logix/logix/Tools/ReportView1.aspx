<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportView1.aspx.cs" Inherits="logix.Tools.ReportView1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REPORTS VIEW</title>
    <link href="../Styles/Report_view.css" rel="stylesheet" />
    <style>
        .div_reports {
            align-content: flex-start;
        }

        .div_viewcry {
            align-content: flex-start;
            float: left;
            margin-left: 17%;
        }

      @font-face {
            font-family: 'Another barcode font';
            src: url('../Another barcode font/Another barcode font.eot');
            src: url('../Another barcode font/Another barcode font.eot?#iefix') format('eot'), url('../Another barcode font/Another barcode font.woff') format('woff'), url('../Another barcode font/Another barcode font.ttf') format('truetype'), url('../Another barcode font/Another barcode font.svg#Another barcode font.ttf')format('svg');
            font-weight: normal;
            font-style: normal;
        }
        
        /*#logix_CPH_Panel1
          {
               top:10px!important;
          }*/
    </style>

    <%--<script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
        Confirm();
    </script>--%>
</head>

<body>
    <form id="form1" runat="server">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif" /><span> <span>
                    <asp:Label ID="Label1" runat="server" CssClass="Error" Text="Please wait... Processing..."
                        Width="180px"></asp:Label><br />
                    <br />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
        </asp:ScriptManager>
        &nbsp;
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="2" width="100%" border="0">
                    <tr>
                        <td valign="middle">
                            <asp:Image ID="Image4" runat="server" ImageAlign="Left" Height="33px" Width="75px" />&nbsp;
                    <asp:Label ID="lblDivBranch"
                        runat="server" Font-Bold="False" Font-Names="sans-serif" Font-Size="Small"
                        Width="635px" CssClass="Label"></asp:Label>&nbsp;<br />
                            &nbsp;
                    <asp:Label ID="lblModule" Width="635px" runat="server" BackColor="Transparent" BorderColor="Transparent" Font-Names="sans-serif" Font-Size="Small" Font-Bold="False" CssClass="Label"></asp:Label></td>
                        <%-- <td align="right">--%>
                        <%-- <asp:ImageButton ID="ImgLogOut" runat="server" ImageUrl="~/Images/logout.gif" ToolTip="Close" />&nbsp;--%>
                        <%--   <asp:ImageButton ID="ImgLogOut" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" ToolTip="Close" Width="5%" Height="5%" />&nbsp;
                    </td>--%>
                    </tr>
                </table>
                <div class="div_viewcry">
                    <%--<CR:CrystalReportViewer ID="Crv" runat="server" AutoDataBind="True"  Cssclass="div_reports" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" Width="350px" Height="50px" OnUnload="Crv_Unload" PrintMode="ActiveX"  HasExportButton="False" HyperlinkTarget="" HasCrystalLogo="False" HasSearchButton="False" HasToggleGroupTreeButton="False" />--%>
                    <%--<CR:CrystalReportViewer ID="Crv" runat="server" AutoDataBind="true"  DisplayGroupTree="False" HasViewList="False"/>--%>
                    <CR:CrystalReportViewer ID="Crv" runat="server" HasPrintButton="True"
                        HasZoomFactorList="True" AutoDataBind="True" DisplayGroupTree="False" HasViewList="True" CssClass="div_reports"
                        EnableDatabaseLogonPrompt="true" EnableParameterPrompt="true" Width="800px" Height="50px" OnUnload="Crv_Unload"
                        PrintMode="ActiveX" HasExportButton="True" HyperlinkTarget="" HasCrystalLogo="False" HasSearchButton="True"
                        HasToggleGroupTreeButton="False" HasDrillUpButton="False" HasRefreshButton="False"></CR:CrystalReportViewer>

                    <asp:Label ID="lblSF" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblPM" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblRpt" runat="server" Visible="False"></asp:Label>
                    <br />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Panel runat="Server" ID="pnldebit" CssClass="Panelcss" Style="display: none;" Visible="false">
            <br />
            <div class="div_closes">
                <asp:Image ID="img_detail" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <div class="div_Break"></div>
            <br />
            <div style="font-size: 10pt"><b>Do You Want Export to PDF Format</b></div>
            <br />
            <div class="div_confirm">
                <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="Button" OnClick="btnYes_Click" />
                <asp:Button ID="btnNo" runat="server" Text="No" CssClass="Button" OnClick="btnNo_Click" />
            </div>
            <br />
            <div class="div_Break"></div>
        </asp:Panel>
        <div class="div_Break"></div>
        <asp:ModalPopupExtender ID="Confirmdialog" runat="server" TargetControlID="hid" PopupControlID="pnldebit" CancelControlID="img_detail"/>

        <asp:Label ID="hid" runat="server" />
    </form>
</body>
</html>


