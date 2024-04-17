<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="CHQuery.aspx.cs" Inherits="logix.CHA.CHQuery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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










    <link href="../Styles/CHQuery.css" rel="stylesheet" />

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtjobno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_jobid.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/CHQuery.aspx/Getjobno",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (event, i) {
                        $("#<%=txtjobno.ClientID %>").val(i.item.label);
                        $("#<%=txtjobno.ClientID %>").change();
                        <%-- $("#<%=hid_jobid.ClientID %>").val(i.item.val);--%>
                    },
                    focus: function (event, i) {
                        $("#<%=txtjobno.ClientID %>").val(i.item.label);
                         <%-- $("#<%=hid_jobid.ClientID %>").val(i.item.val);--%>
                    },
                    change: function (event, i) {
                        $("#<%=txtjobno.ClientID %>").val(i.item.label);
                         <%-- $("#<%=hid_jobid.ClientID %>").val(i.item.val);--%>
                    },
                    close: function (event, i) {
                        $("#<%=txtjobno.ClientID %>").val(i.item.label);
                         <%-- $("#<%=hid_jobid.ClientID %>").val(i.item.val);--%>
                    },
                    minLength: 1
                });
            });
        }
    </script>

    <style type="text/css">
        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .FormGroupContent4 label {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        
/* FixedHeader */


    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="" id="headerlabel1" runat="server">Custom Home Agent</a> </li>
            <li><a href="#" title="">Shipment Details</a> </li>
            <li class="current"><a href="#" title="" id="header" runat="server"></a></li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label></h4>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="lbljobno" runat="server" Text="Job #"> </asp:Label>
                            <asp:TextBox ID="txtjobno" runat="server" placeholder="" ToolTip="Job #" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtjobno_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label2" runat="server" Text="Job Type"> </asp:Label>
                            <asp:TextBox ID="txtJobtype" runat="server" placeholder="" ToolTip="Job Type" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>

                    </div>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="lblDocno" runat="server" Text="Doc #"> </asp:Label>
                            <asp:TextBox ID="txtDocno" runat="server" placeholder="" ToolTip="Doc #" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label5" runat="server" Text="MDoc #"> </asp:Label>
                            <asp:TextBox ID="txtMdocno" runat="server" placeholder="" ToolTip="MDoc #" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label4" runat="server" Text="Shipper"> </asp:Label>
                            <asp:TextBox ID="txtShipper" runat="server" placeholder="" ToolTip="Shipper" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label6" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txtCustomer" runat="server" placeholder="" ToolTip="Customer" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label7" runat="server" Text="Consignee"> </asp:Label>
                            <asp:TextBox ID="txtConsignee" runat="server" placeholder="" ToolTip="Consignee" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label8" runat="server" Text="Notify Party"> </asp:Label>
                            <asp:TextBox ID="txtNotify" runat="server" placeholder="" ToolTip="Notify Party" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label9" runat="server" Text="Principal"> </asp:Label>
                            <asp:TextBox ID="txtPrincipal" runat="server" placeholder="" ToolTip="Principal" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label10" runat="server" Text="User"> </asp:Label>
                            <asp:TextBox ID="txtUser" runat="server" placeholder="" ToolTip="User" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label11" runat="server" Text="Mode"> </asp:Label>
                            <asp:TextBox ID="txtMode" runat="server" placeholder="" ToolTip="Mode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label12" runat="server" Text="Documents"> </asp:Label>
                            <asp:TextBox ID="txtDocuments" runat="server" placeholder="" ToolTip="Documents" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label13" runat="server" Text="Cargo"> </asp:Label>
                            <asp:TextBox ID="txtCargo" runat="server" placeholder="" ToolTip="Cargo" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label14" runat="server" Text="Volume"> </asp:Label>
                            <asp:TextBox ID="txtVolume" runat="server" placeholder="" ToolTip="Volume" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label15" runat="server" Text="Port of Destination"> </asp:Label>
                            <asp:TextBox ID="txtPod" runat="server" placeholder="" ToolTip="Port of Destination" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label16" runat="server" Text="Port of Loading"> </asp:Label>
                            <asp:TextBox ID="txtPol" runat="server" placeholder="" ToolTip="Port of Loading" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label17" runat="server" Text="Place of Delivery"> </asp:Label>
                            <asp:TextBox ID="txtfd" runat="server" placeholder="" ToolTip="Place of Delivery" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label18" runat="server" Text="Packages"> </asp:Label>
                            <asp:TextBox ID="txtPkg" runat="server" placeholder="" ToolTip="Packages" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="NetWeight1">
                            <asp:Label ID="Label19" runat="server" Text="Net Weight"> </asp:Label>
                            <asp:TextBox ID="txtNet" runat="server" placeholder="" ToolTip="Net Weight" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="NetWeight1">
                            <asp:Label ID="Label20" runat="server" Text="Gross Weight"> </asp:Label>
                            <asp:TextBox ID="txtGross" runat="server" placeholder="" ToolTip="Gross Weight" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="DutyPaid">
                            <asp:Label ID="Label21" runat="server" Text="Duty PaidBy"> </asp:Label>
                            <asp:TextBox ID="txtDuty" runat="server" placeholder="" ToolTip="Duty PaidBy" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="DutyCal">
                            <asp:Label ID="Label22" runat="server" Text="Doc Date"> </asp:Label>
                            <asp:TextBox ID="dtdocdte" runat="server" placeholder="" ToolTip="Doc Date" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="dtfrom_cal" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="dtdocdte" />
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="panel_10">
                            <asp:GridView ID="grdEvent" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%"
                                AllowPaging="false" OnPageIndexChanging="Grd_Job_PageIndexChanging"
                                ForeColor="Black" ShowHeaderWhenEmpty="true" PageSize="10" BackColor="White" OnPreRender="grdEvent_PreRender">
                                <Columns>

                                    <asp:TemplateField HeaderText="EventDetails">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="EventDetails" runat="server" Text='<%# Bind("EventDetails") %>' ToolTip='<%# Bind("EventDetails") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Occured On">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="OccuredOn" runat="server" Text='<%# Bind("Occuredon") %>' ToolTip='<%# Bind("Occuredon") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                <asp:Label ID="Remarks" runat="server" Text='<%# Bind("Remarks") %>' ToolTip='<%# Bind("Remarks") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="151px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn MT0 MB05">
                            <div class="btn ico-back" id="btnBack1" runat="server">
                                <asp:Button ID="btnBack" runat="server" ToolTip="Cancel/Back" OnClick="btnBack_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_jobid" runat="server" />
</asp:Content>

