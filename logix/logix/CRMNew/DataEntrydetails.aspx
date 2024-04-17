<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="DataEntrydetails.aspx.cs" Inherits="logix.CRMNew.DataEntrydetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemcrmnewcs.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Styles/DataEnterDetails.css" rel="stylesheet" />
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
        .Hide {
            display: none;
        }


        .div_Grd1 {
            width: 100%;
            float: left;
            /*height:312px;*/
            /*border:1px solid #b1b1b1;*/
            overflow: auto;
        }

        .div_Grd {
            margin-bottom: 10px;
        }




        .Grid {
            width: 100% !important;
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

   table#logix_CPH_grdEmp th {
    background-color: var(--navbarcolor) !important;
    color: var(--white) !important;
}
   div#logix_CPH_btnGet1, div#logix_CPH_btncancel1 {
    margin: 15px 0 0 0;
}
   .widget.box {
    position: relative;
    top: -8px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">


                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="Label2" runat="server" Text="Data Entry Details"></asp:Label></h4>
                    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">CRM</a></li>
            <li><a href="#" title="">CRM</a> </li>
            <li class="current">Data Entry Details</li>
        </ul>
    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CTCDate2">
                            <asp:Label ID="Label1" runat="server" Text="From"> </asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" placeholder="From Date" ToolTip="From Date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                            Format="dd/MM/yyyy" TargetControlID="txt_date" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        <div class="CTCDate2">
                            <asp:Label ID="Label3" runat="server" Text="To"> </asp:Label>
                            <asp:TextBox ID="txtTo" runat="server" placeholder="To Date" ToolTip="To Date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                            Format="dd/MM/yyyy" TargetControlID="txtTo" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>

                        <div class="right_btn">

                            <div class="btn ico-get" id="btnGet1" runat="server">
                                <asp:Button ID="btnGet" runat="server" ToolTip="Get" OnClick="btnGet_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btncancel1" runat="server">
                                <asp:Button ID="btncancel" runat="server" ToolTip="Cancel" OnClick="btncancel_Click" />
                            </div>

                        </div>


                    </div>
                    <div class="FormGroupContent4 boxmodal" >
                        <div class=" panel_22 MB0">
                            <asp:GridView ID="grdEmp" runat="server" CssClass="Grid FixedHeader" Width="100%" DataKeyNames="empid" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true" OnRowDataBound="grdEmp_RowDataBound" OnSelectedIndexChanged="grdEmp_SelectedIndexChanged" OnPreRender="grdEmp_PreRender" >
                                <Columns>
                                    <asp:BoundField DataField="updatedby" HeaderText="Updated By" />
                                    <asp:BoundField DataField="totalentries" HeaderText="Total Entries " ItemStyle-Width="150px" HeaderStyle-Width="150px"/>
                                    
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <asp:GridView ID="grdjob" runat="server" CssClass="Grid FixedHeader"  Width="100%" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnRowDataBound="grdjob_RowDataBound" AllowPaging="false" PageSize="10" OnPageIndexChanging="grdjob_PageIndexChanging">
                                <%--ShowFooter="true"--%>
                                <Columns>
                                    <asp:BoundField HeaderText="S-No" ItemStyle-HorizontalAlign="Right">
                                        <HeaderStyle Wrap="false" Width="30px" />
                                        <ItemStyle Wrap="false" Width="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="customername" HeaderText="Customer">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="320px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="city" HeaderText="City">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="320px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pincode" HeaderText="Pincode">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="location" HeaderText="Location">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="350px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="createdby" HeaderText="UpdatedBy">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="createdon" HeaderText="createdon" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                </Columns>
                                <%-- <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />--%>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </div>
                       

                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_Temp" runat="server" />

</asp:Content>
