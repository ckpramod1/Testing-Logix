<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PATDS.aspx.cs" Inherits="logix.FAForm.PATDS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/FA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> 
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <%-- <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>--%>

    <!-- App -->
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

 <script type="text/javascript">
     function dropdownButton() {
         $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
     }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.selectpicker').selectpicker();

            "use strict";

            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins

            //$('select.styled').customSelect();

        });

    </script>

    <link href="../CSS/Finance.css" rel="stylesheet" />

    <link href="../Styles/PATDS.css" rel="stylesheet" />

    <%--EDIT--%>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }
        .widget.box{
    position: relative;
    top: -8px;
}
         
 
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
    </style>

    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <%--EDIT--%>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        .div_Grid {
            width: 100%;
            height: 418px;
            float: left;
            margin-top: 0%;
            margin-left: 0%;
            margin-bottom: 0%;
            overflow: auto;
        }

        .ModeDropCN3 {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        /*CSS*/

        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }

        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
        }

        .DivSecPanelLog img {
            float: right;
            width: 16px !important;
            height: 16px !important;
        }

        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

        .LogHeadLbl {
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
            white-space: nowrap;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="PI TDS"></asp:Label></h4>
                    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
            <li><a href="#" title="">PI TDS</a> </li>

        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                      <div class="FixedButtons">
    <div class="right_btn">
        <div class="btn ico-update">
            <asp:Button ID="btn_update" runat="server"  Text="Update"  ToolTip="Update" OnClick="btn_update_Click" /></div>
        <div class="btn ico-cancel">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" /></div>
    </div>
</div>

                </div>
                <div class="widget-content">
                      
                    <div class="FormGroupContent4">
                        <div class="ModeDropCN3" id="div_branch" runat="server" style="display: none;">
                            <asp:Label ID="lbl_branch" runat="server" Text="Branch"></asp:Label></div>
                        <div class="ModeDropCN3">
                            <asp:DropDownList ID="ddl_branch" Height="23px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged"
                                CssClass="chzn-select" data-placeholder="Branch" ToolTip="Branch" Visible="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl MB0 ">
                            <%--AllowPaging="false" PageSize="16"--%>
                            <asp:GridView ID="Grd_TDS" runat="server" AutoGenerateColumns="False" Width="100%"
                                ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" DataKeyNames="vouyear,amount,customerid" OnPageIndexChanging="Grd_TDS_PageIndexChanging" OnRowDataBound="Grd_TDS_RowDataBound" OnPreRender="Grd_TDS_PreRender">
                                <%-- AllowPaging="false" PageSize="16" --%>
                                <Columns>
                                    <asp:BoundField DataField="vouno" HeaderText="Vou #">
                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="voudate" HeaderText="Date">
                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="customer" HeaderText="Customer">
                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tdssection" HeaderText="TDS Section">
                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tdstype" HeaderText="TDS Type">
                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tdsdesc" HeaderText="TDS Desc">
                                        <HeaderStyle Wrap="false" HorizontalAlign="center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="TDS %">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_TDS" runat="server" CssClass="form-control" Enabled="false" Text='<%#Eval("tdsper")%>' ToolTip='<%#Eval("tdsper")%>' Font-Size="10pt" Style="width: 100px; text-align: right; height: 15px; border: 0px solid #ffffff!important;"
                                                onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                                        </ItemTemplate>

                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TDS Section"><%--8--%>
                                        <HeaderStyle Wrap="false" />

                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_section" runat="server" data-placeholder="--Section--" ToolTip="Section" AutoPostBack="true" CssClass="" OnSelectedIndexChanged="ddl_section_SelectedIndexChanged" OnCellContentClick="Grd_TDS_CellContentClick">
                                                <%-- CssClass="chzn-select"--%>
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <%--<asp:ListItem Value="194C">194C</asp:ListItem>
                                    <asp:ListItem Value="194H">194H</asp:ListItem>
                                    <asp:ListItem Value="194I">194I</asp:ListItem>
                                    <asp:ListItem Value="194J">194J</asp:ListItem>
                                    <asp:ListItem Value="OTH">OTH</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="TDS Desc" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TDSdescnew" runat="server" Enabled="false" CssClass="form-control" Font-Size="10pt" Style="text-align: right; width: 100px; height: 15px; border: 0px solid #ffffff!important;"></asp:TextBox>
                                        </ItemTemplate>

                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="TDS Section"><%--8--%>
                                        <HeaderStyle Wrap="false" />

                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_section1" runat="server" data-placeholder="--Section--" ToolTip="Section" AutoPostBack="true" CssClass="" OnSelectedIndexChanged="ddl_section_SelectedIndexChanged1" OnCellContentClick="Grd_TDS_CellContentClick">
                                                <%-- CssClass="chzn-select"--%>
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <%--<asp:ListItem Value="194C">194C</asp:ListItem>
                                    <asp:ListItem Value="194H">194H</asp:ListItem>
                                    <asp:ListItem Value="194I">194I</asp:ListItem>
                                    <asp:ListItem Value="194J">194J</asp:ListItem>
                                    <asp:ListItem Value="OTH">OTH</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="TDS%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtpercentage" CssClass="form-control" runat="server" Enabled="false" Font-Size="10pt" Style="text-align: right; width: 100px; height: 15px; border: 0px solid #ffffff!important;"
                                                onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                                        </ItemTemplate>

                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chk_Select" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </div>
                    </div>
                  
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_branchid" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Ledger #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                    BackColor="White">
                    <Columns>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="myGridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
            <div class="Break"></div>
        </div>

    </asp:Panel>

    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
