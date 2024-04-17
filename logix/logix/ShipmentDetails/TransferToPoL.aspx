<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="TransferToPoL.aspx.cs" Inherits="logix.ShipmentDetails.TransferToPoL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

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

    <%--<script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <style type="text/css">
        .GridPalICD {
            height: 100% !important;
        }

        /*LOG DETAILS CSS*/

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
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
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
                font-size: 12px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

      
/*        .gridpnl {
    height: calc(100vh - 132px);
}*/
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}

table#logix_CPH_GrdToPol tbody td:nth-child(2) {
    max-width: 211px !important;
}
table#logix_CPH_GrdToPol tbody td:nth-child(3) {
    max-width: 187px !important;
}
    </style>

    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/TransferToPoL.css" rel="stylesheet" />
    <%--   <link href="../Styles/GridviewScroll.css" rel="stylesheet" />--%>

    <%--    <script type="text/javascript" >
        function pageLoad(sender, args) {          
            $(document).ready(function () {              
                var GridId = "<%=GrdToPol.ClientID %>";
                var ScrollHeight = 470;

                //window.onload = function () {
                var grid = document.getElementById(GridId);
                var gridWidth = grid.offsetWidth;
                var gridHeight = grid.offsetHeight;
                var headerCellWidths = new Array();
                for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                    headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
                }
                grid.parentNode.appendChild(document.createElement("div"));
                var parentDiv = grid.parentNode;

                var table = document.createElement("table");
                for (i = 0; i < grid.attributes.length; i++) {
                    if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                        table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                    }
                }
                table.style.cssText = grid.style.cssText;
                table.style.width = gridWidth + "px";
                table.appendChild(document.createElement("tbody"));
                table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
                var cells = table.getElementsByTagName("TH");

                var gridRow = grid.getElementsByTagName("TR")[0];
                for (var i = 0; i < cells.length; i++) {
                    var width;
                    if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                        width = headerCellWidths[i];
                    }
                    else {
                        width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                    }
                    cells[i].style.width = parseInt(width - 3) + "px";
                    gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
                }
                parentDiv.removeChild(grid);

                var dummyHeader = document.createElement("div");
                dummyHeader.appendChild(table);
                parentDiv.appendChild(dummyHeader);
                var scrollableDiv = document.createElement("div");
                if (parseInt(gridHeight) > ScrollHeight) {
                    gridWidth = parseInt(gridWidth) + 17;
                }
                scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
                scrollableDiv.appendChild(grid);
                parentDiv.appendChild(scrollableDiv);
            });
        }
    </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblMeText" runat="server" Text=""></asp:Label></h4>
                         <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Documentation</a> </li>      
                <li><a href="#" id="HeaderLabel1" runat="server"></a></li>              
             <li class="current"><a href="#" title="" id="menu" runat="server">Copy TO Other Office</a> </li>
            </ul>
      </div>
                    </div>
                  </div>

                    <div class="FixedButtons">
      <div class="right_btn">
        <div class="btn ico-transfer-to-pol" id="btntranfer1" runat="server">
            <asp:Button ID="btntranfer" runat="server" Text="Copy To " ToolTip="Transfer To Pol" OnClick="btntranfer_Click" /></div>
        <div class="btn ico-cancel" id="btnback1" runat="server">
            <asp:Button ID="btnback" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnback_Click" />
        </div>
    </div>
    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="panel" runat="server" CssClass="gridpnl MB0" ScrollBars="Auto">

                            <asp:GridView ID="GrdToPol" runat="server" CssClass="Grid FixedHeader " Width="100%" AutoGenerateColumns="False" OnRowDataBound="grd_RowDataBound"
                                PageSize="15" AllowPaging="false" OnPageIndexChanging="GrdToPol_PageIndexChanging" ShowHeaderWhenEmpty="true" OnPreRender="GrdToPol_PreRender">
                                <%----%>
                                <Columns>
                                    <asp:BoundField HeaderText="BL #" DataField="blno">
                                        <ControlStyle Width="700px" />
                                        <HeaderStyle Width="122px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="120px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Shipper">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 270px">
                                                <asp:Label ID="shipper" runat="server" Text='<%# Bind("shipper") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="123px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Consignee">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 203px">
                                                <asp:Label ID="Consignee" runat="server" Text='<%# Bind("consignee") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="154px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="POL">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="122px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="POD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                <asp:Label ID="pod" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="123px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Place of Delivery">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                <asp:Label ID="fd" runat="server" Text='<%# Bind("fd") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="124px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>

                                            <asp:CheckBox ID="ChkStatus" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="55px" />
                                        <ItemStyle HorizontalAlign="Center" Width="55px" />
                                    </asp:TemplateField>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                                <%-- <PagerStyle CssClass="GridviewScrollPager" />--%>
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                    <br />
                    <br />
                    
                </div>

            </div>
        </div>
    </div>
     <asp:HiddenField ID="hid_date" runat="server" />

</asp:Content>
