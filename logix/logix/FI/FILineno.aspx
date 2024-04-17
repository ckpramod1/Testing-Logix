<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FILineno.aspx.cs" Inherits="logix.FI.FILineno" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
     <script type="text/javascript">
         function dropdownButton() {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }

    </script>
   <%-- <script>

        function pageLoad(sender, args) {

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            $(document).ready(function () {

                $('.selectpicker').selectpicker();

                "use strict";

                App.init(); // Init layout and core plugins
                Plugins.init(); // Init all plugins
                FormComponents.init(); // Init all form-specific plugins

                //$('select.styled').customSelect();

            });
        }

    </script>--%>

    <link href="../Styles/FILineno.css" rel="stylesheet" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        /*.divRoated
        {
           width:853px; 
            Height:303px;
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #logix_CPH_Grd_Job_popup_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

          .chzn-drop {
                   height: 180px!important;
                   }
        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
        .JobName1 {
    width: 6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
     /*   table#logix_CPH_grd_Line tbody td:nth-child(8) {
    width: 19%;
}

table#logix_CPH_grd_Line tbody td:nth-child(2) {
    width: 6%;
}
table#logix_CPH_grd_Line tbody td:nth-child(1) {
    width: 6%;
}
table#logix_CPH_grd_Line tbody td:nth-child(7) {
    width: 14%;
}
*/
/*New Design - Buttons*/

div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
.gridpnl {
    height: calc(100vh - 180px);
}
         table#logix_CPH_grd_Line td:nth-child(1) {
    width: 60px !important;
}
table#logix_CPH_grd_Line th:nth-child(1) {
    width: 60px !important;
}

table#logix_CPH_grd_Line td:nth-child(2) {
    width: 60px !important;
}
table#logix_CPH_grd_Line th:nth-child(2) {
    width: 60px !important;
}

table#logix_CPH_grd_Line td:nth-child(4) {
    width: 100px !important;
}
table#logix_CPH_grd_Line th:nth-child(4 ) {
    width: 100px !important;
}

table#logix_CPH_grd_Line td:nth-child(5) {
    width: 100px !important;
}
table#logix_CPH_grd_Line th:nth-child(5) {
    width: 100px !important;
}


table#logix_CPH_grd_Line td:nth-child(6) {
    width: 100px !important;
}
table#logix_CPH_grd_Line th:nth-child(6) {
    width: 100px !important;
}


table#logix_CPH_grd_Line td:nth-child(9) {
    width: 5% !important;
}
table#logix_CPH_grd_Line th:nth-child(9) {
    width: 5% !important;
}


table#logix_CPH_grd_Line td:nth-child(3) {
    width: 115px !important;
}
table#logix_CPH_grd_Line th:nth-child(3) {
    width: 115px !important;
}



table#logix_CPH_grd_Line td:nth-child(10) {
    width: 50px !important;
}
table#logix_CPH_grd_Line th:nth-child(10) {
    width: 50px !important;
}


table#logix_CPH_grd_Line td:nth-child(7) {
    width: 490px !important;
}
table#logix_CPH_grd_Line th:nth-child(7) {
    width: 490px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
   <%-- <div >--%>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" Text="Line Number Entry" runat="server"></asp:Label></h4>
                    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#"></a>Ops &amp; Docs</li>
            <li><a href="#" title="">Ocean Imports</a> </li>
            <li class="current"><a href="#" title="">Line No Entry</a> </li>
        </ul>
    </div>
                        </div>

                    <div class="FixedButtons">
      <div class="right_btn">
        <div class="btn ico-send">
            <asp:Button ID="btn_Send" Text="Send" ToolTip="Send" runat="server"
                OnClick="btn_Send_Click" UseSubmitBehavior="False" />
        </div>
        <div class="btn btn-liner1"  id="btn_Lineno1" runat="server">
            <asp:Button ID="btn_Lineno" Text="Update" ToolTip="Line#" runat="server"
                OnClick="btn_Lineno_Click" UseSubmitBehavior="False" />

        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" Text="Cancel" ToolTip="Cancel" runat="server"
                OnClick="btn_cancel_Click" UseSubmitBehavior="False" />
        </div>
    </div>
</div>

                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="JobName1">
                            <span>Job #</span>                           

                            <asp:TextBox ID="txt_Job" runat="server" CssClass="form-control" OnTextChanged="txt_Job_TextChanged" placeholder=" " ToolTip="Job #" AutoPostBack="true"></asp:TextBox>
                        </div>                       
                        
                    <asp:LinkButton ID="lnk_Job" CssClass="anc ico-find-sm" Text="" Style="text-decoration: none" runat="server" ForeColor="Red" OnClick="lnk_Job_Click"></asp:LinkButton>
                      

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl">

                        <asp:GridView ID="grd_Line" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="false" Width="100%" >
                            <Columns>
                                <asp:TemplateField HeaderText="Line #">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_line" runat="server" Text='<%#Bind("linenumber") %>' Width="100%"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubLine #">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_subline" runat="server" Text='<%#Bind("sublineno") %>' Width="100%"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HBL #">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_hbl" runat="server" Text='<%#Bind("blno") %>' Width="100%"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_date" runat="server" Text='<%#Bind("bldate") %>' Width="100%"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cargo Type">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_cargo" runat="server"  CssClass="chzn-select" Width="100px" AutoPostBack="true">
                                            <asp:ListItem Value="0">OT</asp:ListItem>
                                            <asp:ListItem Value="1">UB</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MM Type">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_mm" runat="server" CssClass="chzn-select" Width="100px" AutoPostBack="true">
                                            <asp:ListItem Value="0">LC</asp:ListItem>
                                            <asp:ListItem Value="1">TI</asp:ListItem>
                                            <asp:ListItem Value="2">GC</asp:ListItem>
                                            <asp:ListItem Value="3">TC</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Consignee">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_consignee" runat="server" Text='<%#Bind("Consignee") %>' Width="100%"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="E-Mail Id">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_email" runat="server" Text='<%#Bind("email") %>' Width="100%"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Loc Code">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Shippod" runat="server" Text='<%#Bind("Shippod") %>' Width="100%"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk_select" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <%--POPUP  --%>
                        <asp:Panel ID="pnl_Quota" runat="server" CssClass="modalPopup">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel2" runat="server"  CssClass="Gridpnl">

                                    <asp:GridView ID="grd_Job" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="False" Width="100%"
                                        OnRowDataBound="grd_Job_RowDataBound" ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                         OnSelectedIndexChanged="grd_Job_SelectedIndexChanged" BackColor="White">
                                        <Columns>
                                            <asp:BoundField HeaderText="Job #" DataField="jobno">
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Job Type" DataField="jobtype">
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Vessel & Voyage" DataField="vslvoy">
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="POL" DataField="portname">
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Agent" DataField="customername">
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Arrived On" DataField="eta">
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Select">
            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
            <asp:LinkButton ID="link_select1" runat="server" CommandName="Select" Font-Underline="false" CssClass="Arrow">⇛</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </asp:Panel>
                                <asp:modalpopupextender id="Grd_Job_popup" runat="server" popupcontrolid="pnl_Quota"
            dropshadow="false" targetcontrolid="hid" cancelcontrolid="Close_voucher" behaviorid="Test1">
</asp:modalpopupextender>
                         
                    </div>
                </div>
            </div>
        </div>
    
  
 
   
        <asp:HiddenField ID="hid_img4" runat="server" />
        <asp:HiddenField ID="hid_strbl" runat="server" />
        <asp:Label ID="hid" runat="server"></asp:Label>
    
</asp:Content>
