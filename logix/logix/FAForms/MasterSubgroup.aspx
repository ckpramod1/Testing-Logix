<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="MasterSubgroup.aspx.cs" Inherits="logix.FAForm.MasterSubgroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Styles/MasterSubGroup.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
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

    <link href="../Styles/MasterSubGroup.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    </script>
    <style type="text/css">
        .Grid1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            height: 427px;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        .SubGroupname {
            float: left;
            width: 28.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .Groupname1 {
            float: left;
            width: 24%;
            margin: 0px 0.5% 0px 0px;
        }

        .Category1 {
            float: left;
            width: 16%;
            margin: 0px 0.5% 0px 0px;
        }

        .GroupType1 {
            float: left;
            width: 13.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .widget.box {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
            margin-top: 0px;
            height: 550px;
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

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

      

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
        .widget.box {
    width: 60%;
}
        .widget-content {
            padding: 0 10px !important;
        }
        .gridpnl {
    height: calc(100vh - 310px);
    overflow: auto !important;
}
        .widget-content {
    padding-top: 55px !important;
}
        .FixedButtonsss {
    position: fixed;
    top: 35px !important;
    left: 0;
    background: #fff;
    z-index: 10;
    box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
    width: calc(100vw - 525px) !important;
    border-bottom: 0.5px solid #00000010;
    padding: 1px 0 5px 10px;
}
    </style>
    <script type="text/javascript">

        //function pageLoad(sender, args) {

        //}
    </script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txtsubgroupname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MasterSubgroup.aspx/GetSubgroupname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]
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
                        $("#<%=txtsubgroupname.ClientID %>").change();
                        $("#<%=hid_SubGroupname.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtsubgroupname.ClientID %>").val(i.item.label);
                        $("#<%=hid_SubGroupname.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {

                $("#<%=txtGroupname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MasterSubgroup.aspx/Getgroupname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]
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
                        $("#<%=txtGroupname.ClientID %>").change();
                        $("#<%=hid_Groupname.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtGroupname.ClientID %>").val(i.item.label);
                        $("#<%=hid_Groupname.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="Server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Sub Groups"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Account Info</a> </li>
                            <li><a href="#" title="">Sub Groups</a> </li>
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
        <asp:Button ID="btnsave" runat="server" Text="Save" ToolTip="Save" OnClick="btnsave_Click" />
    </div>

    <div class="btn ico-delete" id="delid"  runat="server"  visible="false" >
        <asp:Button ID="btndelete" runat="server" Text="Delete" ToolTip="Delete" OnClick="btndelete_Click" Visible="false" />
    </div>
    <div class="btn ico-cancel" id="btncancel1" runat="server">
        <asp:Button ID="btncancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
    </div>
                            <div class="btn ico-view">
    <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" />
</div>
</div>
                   </div>

                </div>

                <div class="widget-content">
                                      
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">

                            <asp:Label ID="lbl_sgroupname" runat="server" Text="Sub Group Name"></asp:Label>
                            <asp:TextBox ID="txtsubgroupname" runat="server" AutoPostBack="True" OnTextChanged="txtsubgroupname_TextChanged" CssClass="form-control" ToolTip="Sub Group Name" placeholder=" "></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">

                            <asp:Label ID="Label2" runat="server" Text="Group Name"></asp:Label>
                            <asp:TextBox ID="txtGroupname" runat="server" AutoPostBack="True" CssClass="form-control" ToolTip="Group Name" placeholder=" " OnTextChanged="txtGroupname_TextChanged"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                            <asp:TextBox ID="txtCategory" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Category" placeholder=""></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4 custom-d-flex">

                            <div class="custom-col">

                                <asp:Label ID="Label4" runat="server" Text="Group Type"></asp:Label>
                                <asp:TextBox ID="txtgroupetype" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Group Type" placeholder=" "></asp:TextBox>
                            </div>

                           
                        </div>
                    </div>
                   
                    <div class="FormGroupContent4 boxmodal">

                        <asp:Panel ID="grd_panel" runat="server"   ScrollBars="Auto">
                            <asp:GridView ID="grd" runat="server" Width="100%" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="SubGroupName">

                                        <ItemTemplate>
                                            <div class="wrap250">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("subgroupname") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GroupName">

                                        <ItemTemplate>
                                            <div class="wrap200">

                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("groupname") %>'></asp:Label>

                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="groupcategory" HeaderStyle-Width="25%" HeaderText="Category" ItemStyle-Width="25%">
                                        <HeaderStyle Width="25%" />
                                        <ItemStyle Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="grouptype" HeaderStyle-Width="25%" HeaderText="GroupType" ItemStyle-Width="25%">
                                        <HeaderStyle Width="25%" />
                                        <ItemStyle Width="25%" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                   
                </div>

            </div>
        </div>
    </div>

    <asp:TextBox ID="txtgreplace" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
    <asp:TextBox ID="txtsgreplace" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
    <%-- <div class="Msh_Button"><asp:Button ID="Button5" runat="server" Text="Button" /></div>--%>
    <asp:HiddenField ID="hid_SubGroupname" runat="server" />
    <asp:HiddenField ID="hid_Groupname" runat="server" />

    <asp:HiddenField ID="hid_groupid" runat="server" />
    <asp:HiddenField ID="hid_subgroupid" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Subgroup #</label>

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

    <asp:Label ID="Label1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label1" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
