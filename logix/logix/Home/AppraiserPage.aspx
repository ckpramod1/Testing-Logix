<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AppraiserPage.aspx.cs" Inherits="logix.Home.AppraiserPage" %>

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
        .div_grd {
            width: 100%;
            margin:0px 5px 0px 5px;         
            height: 515px;
            
            border: 1px solid gray;

        }

            .div_grd input {
                width: 98%;
            }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopupss {
            background-color: #B3E5FC;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }

        .FormGroupContent4 textarea {
            height: 48px !important;
        }
        .LabelValue {
    font-family: sans-serif;
    font-size: 11px;
    color: #335fa4;
    font-weight: bold;
    text-align: right;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="FormGroupContent4">
        <div style="color:#335fa4; margin:0px 0px 0px 5px;">
        <asp:Label ID="lblapp2" runat="server" Text="To be Appraised" CssClass="LabelValue"></asp:Label>
            </div>
    </div>
    <div class="FormGroupContent4">
        <asp:Panel ID="Panel1" runat="server" Width="99%" CssClass="div_grd"
            ScrollBars="Vertical">
            <asp:GridView ID="gvcomp" runat="server" AutoGenerateColumns="False" Height="100%" Width="100%" CssClass="Grid FixedHeader" 
                DataKeyNames="employeeid" ShowHeaderWhenEmpty="true"  OnSelectedIndexChanged="gvcomp_SelectedIndexChanged" OnRowDataBound="gvcomp_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <ItemTemplate>
                            <asp:Label ID="lblsno" runat="server" Text='<% #Container.DataItemIndex + 1%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="10%" Font-Size="small" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emp Code">
                        <ItemTemplate>
                            <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("empcode")  %>' ToolTip='<%# Eval("empcode")  %>'></asp:Label>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                        <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("empname")  %>' ToolTip='<%# Eval("empname")  %>'></asp:Label>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                        <ItemStyle Wrap="true" Font-Size="Small" Width="20%" />

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="City/ Branch" >
                        <ItemTemplate>
                            <asp:Label ID="lbldetails1" runat="server" Text='<%# Eval("branch")  %>'></asp:Label>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                        <ItemStyle Wrap="false" Font-Size="Small" Width="10%" />

                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="lbldept" runat="server" Text='<%# Eval("deptname")  %>' ToolTip='<%# Eval("deptname")  %>'></asp:Label>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                        <ItemStyle Wrap="true" Font-Size="Small" Width="20%" />

                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("designame")  %>' ToolTip='<%# Eval("designame")  %>'></asp:Label>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                        <ItemStyle Wrap="true" Font-Size="Small" Width="15%" />

                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Submitted On">
                        <ItemTemplate>
                            <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("empsubon")  %>' ToolTip='<%# Eval("empsubon")  %>'></asp:Label>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                        <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>

