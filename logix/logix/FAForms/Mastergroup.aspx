<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="Mastergroup.aspx.cs" Inherits="logix.FAForm.Mastergroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="Stylesheet" href="../Styles/MasterGroup.css" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css">
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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

    <style type="text/css">
        .chzn_drop input {
            width: 150px;
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
            .widget.box{
    position: relative;
    top: -8px;
}
         
            .left_btn {
    margin: 0;
}
            .gridpnl {
    height: calc(100vh - 260px);
    overflow: auto !important;
}
            div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}
    </style>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txtname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Mastergroup.aspx/Get_Groupname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item
                                    }
                                }))
                            },
                            error: function (response) {
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtname.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=txtname.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });

              <%--  $(document).ready(function () {

                    var GridId = "<%=grdimage.ClientID %>";
                    var ScrollHeight = 351;

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
                });--%>

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            }
    </script>
    <style type="text/css">
        /*.Grid {
            width: 99%;
            border: 1px solid #b1b1b1;
            height: 384px;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }*/

        .GroupName {
            width: 43%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CategoryDrop1 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SubCategory {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .row {
            height: 580px !important;
            /* margin: 0px 5px 0px -15px; */
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
           .widget.box {
   width: 50%;
}
        .widget-content {
    
    padding: 0 10px!important;
}
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}
        .FixedButtonsss {
    width: calc(100vw - 650px) !important;
 
}
    </style>

    <%--    <script src="Scripts/jquery-1.7.1.js"></script>
            <script language="javascript" >
                $(document).ready(function () {
                    var gridHeader = $('#<%=grdimage.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=grdimage.ClientID%> tr th').each(function (i) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHead").append(gridHeader);
                    $('#GHead').css('position', 'absolute');
                    $('#GHead').css('top', $('#<%=grdimage.ClientID%>').offset().top);

                });
            </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblmastergroup" runat="server" Text="Master Group"></asp:Label>
                    </h4>
                     <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Account Info</a> </li>
            <li><a href="#" title="">Master Group</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                                                           <div class="FixedButtons">
                        <div class="right_btn">
        <div class="btn ico-save" id="btnsave1" runat="server">
            <asp:Button ID="btnsave" runat="server" Text="Save" ToolTip="Save" TabIndex="14" OnClick="btnsave_Click" />
        </div>
      
        <div class="btn ico-delete" id="delid"  runat="server"  visible="false" >
            <asp:Button ID="btndel" runat="server" Text="Delete" ToolTip="Delete" TabIndex="16" OnClick="btndel_Click" Visible="false" />
        </div>
        <div class="btn ico-cancel" id="btncan1" runat="server">
            <asp:Button ID="btncan" runat="server" Text="Cancel" ToolTip="Cancel" TabIndex="17" OnClick="btncan_Click1" />
        </div>
                             <div class="btn ico-view">
           <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" TabIndex="15"
               OnClick="btnview_Click" />
       </div>
</div>
                   </div>


                </div>

                <div class="widget-content">
                                       
                    <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4">
                            <asp:Label ID="lblgroupname" runat="server" Text="Group Name" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txtname" runat="server" ToolTip="Group Name" placeholder="" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtname_TextChanged"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label1" runat="server" Text="Category"> </asp:Label>
                            <asp:DropDownList ID="ddl_Category" ToolTip="Category" Height="23px" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged">
                                <asp:ListItem Value="0">Category</asp:ListItem>
                                <asp:ListItem Value="B">Balance Sheet</asp:ListItem>
                                <asp:ListItem Value="P">Profit &amp; Loss Account</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="FormGroupContent4 custom-d-flex">

                        <div class="custom-col">
                            <asp:Label ID="Label2" runat="server" Text="Group Type"> </asp:Label>
                            <asp:DropDownList ID="ddl_GroupType" ToolTip="Group Type" Height="23px" runat="server" CssClass="chzn-select">
                                <asp:ListItem Value="0">Group Type</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                       
                            </div>
                    </div>
                    
                    <div class="FormGroupContent4">
                        <div style="display: none;">
                            <asp:Label ID="lblcat" runat="server" Text="Category" CssClass="LabelValue"></asp:Label>
                        </div>

                    </div>
                    <div class="FormGroupContent4">
                        <div style="display: none;">
                            <asp:Label ID="lbltype" runat="server" Text="Group Type" CssClass="LabelValue"></asp:Label>
                        </div>

                    </div>

                    <div class="FormGroupContent4 boxmodal">
                       
                        <asp:Panel ID="Panel2" runat="server"    ScrollBars="Auto">
                            <asp:GridView ID="grdimage" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" DataKeyNames="groupid"
                                Width="100%" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:BoundField HeaderText="Group Name" DataField="groupname">
                                        <ItemStyle  />

                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Category" DataField="groupcategory">
                                        <ItemStyle Width="25%" />
                                        <HeaderStyle Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Group Type" DataField="grouptype">
                                        <ItemStyle  Width="25%" />
                                        <HeaderStyle Width="25%" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div class="FormGroupContent4">

                  
                        </div>
                </div>

            </div>
        </div>
    </div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Groups #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hid_Groupid" runat="server" />

</asp:Content>
