<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CORHome.aspx.cs" Inherits="logix.Home.CORHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

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
        .CorTabC {
            border-bottom: 1px solid #60b3dd;
            float: left;
            width: 96.3%;
            margin-bottom: 5px;
            margin-left: 25px;
        }
        .PendingTblGrid th {
    position:sticky;
    top:-1px;
    background: var(--navbarcolor)!important;
    color: var(--white)!important;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="float: left; width: 1115px;">
                <div class="CorTabC">
                    <div class="CorTab">
                        <asp:LinkButton ID="lnk_dosdays" runat="server" Style="text-decoration: none" OnClick="lnk_dosdays_Click">DSO Days</asp:LinkButton></div>
                    <div class="CorTab">
                        <asp:LinkButton ID="lnk_customerprofile" runat="server" Style="text-decoration: none" OnClick="lnk_customerprofile_Click">Customer Profile</asp:LinkButton></div>
                    <%--<div style="float: left;margin-left:2%;"><asp:LinkButton ID="lnk_PendingDep" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_PendingDep_Click" >Deposits Details</asp:LinkButton></div>--%>
                    <div class="CorTab">
                        <asp:LinkButton ID="lnk_mis" runat="server" Style="text-decoration: none" OnClick="lnk_mis_Click">MIS</asp:LinkButton></div>
                </div>

                <div>
                    <iframe id="ifrmaster" runat="server" name="MainFrame" style="float: left; width:1106px; height: 565px" frameborder="0" src="../Accounts/ActualPerformance.aspx" scrolling="no"></iframe>

                    <%-- <a href="../Accounts/ActualPerformance.aspx"></a>--%>
                </div>
            </div>
            <div style="width: 215px; float: left; margin: 0px 0px 0px 10px;">
                <div class="CorporateEx ">
                    <h3>
                        <img src="../Theme/assets/img/exrate_ic.png" />
                        <span>Ex Rate</span></h3>
                    <%--  <asp:LinkButton ID="lnk_exrate" runat="server" ForeColor="Brown" style="text-decoration:none" >Ex.Rate</asp:LinkButton>--%>

                    <asp:Panel ID="Panelexrate" runat="server"   CssClass="panel_15 " Visible="false">
                        <asp:GridView ID="Gridexrate" CssClass="PendingTblGrid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
                            <Columns>
                                <asp:BoundField DataField="excurr" HeaderText="Curr">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="localexrate" HeaderText="Local">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="osexrate" HeaderText="OS">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                    <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div class="CorPending">
                    <ul>
                        <li>
                            <img src="../images/1472042570_4.png" />
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_PendingApprovalCorp_Click">Pending Approval</asp:LinkButton></li>

                        <div class="pnl_tool">
                            <asp:Panel ID="PanelPendingApprovalCorp" runat="server" Height="75px" Visible="true">


                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lbl_Credit" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Customer-Credit" OnClick="lbl_Credit_Click"></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lbl_Web" CssClass="LabelValue" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Customer - Web" OnClick="lbl_Web_Click"></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lbl_Exception" CssClass="LabelValue" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Exception List" OnClick="lbl_Exception_Click"></asp:LinkButton></li>
                                </ul>




                                <div class="div_Break"></div>
                            </asp:Panel>
                        </div>
                    </ul>
                </div>

            </div>
            <div style="clear: both"></div>
        </div>

        <%--  <asp:Panel ID="pln_popup" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
            <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>

                <asp:Panel ID="Panel3" runat="server"   CssClass="Gridpnl"> 

                    </asp:Panel>
                </div>
        </asp:Panel>
        
        <asp:Label ID="Label2" runat="server"></asp:Label>
    <ajax:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup" 
       DropShadow="false" TargetControlID="Label2" CancelControlID="close" BehaviorID="Test">
    </ajax:ModalPopupExtender>--%>
    </form>
</body>
</html>
