<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuickViewInfo.aspx.cs" Inherits="logix.QuickViewInfo" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>logix</title>
    <link href="Style/Controls.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />
    
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <link href="Style/GrdHead.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <style type="text/css">
        body {
            font-size: 13px;
            font-family: 'Segoe UI';
        }

        .ContainerPopupdiv {
            /*height: 241px;
            border-collapse: collapse;
            overflow: auto;*/
            border: 1px solid #b1b1b1;
            margin: 187px 0px 0px 337px;
            width: 633px;
            background-color: #fff;
            height: 233px;
            padding: 0px 5px 5px;
        }

            .ContainerPopupdiv h4 {
                color: brown;
                font-size: 13px;
                font-family: 'Segoe UI';
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                width: 20%;
                float: left;
            }

            .ContainerPopupdiv label {
                color: brown;
                display: inline-block;
                font-size: 13px;
                font-family: 'Segoe UI';
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                width: 31%;
                float: left;
            }

                .ContainerPopupdiv label.lblDate {
                    color: brown;
                    display: inline-block;
                    font-size: 13px;
                    font-family: 'Segoe UI';
                    padding: 3px 3px 3px 3px;
                    margin: 0px 0px 0px 0px;
                    width: auto;
                    float: left;
                }


            .ContainerPopupdiv span#SpanBookingNo {
                display: inline-block;
                float: left;
                width: 23%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }

            .ContainerPopupdiv span#SpanDate {
                display: inline-block;
                float: left;
                width: 18%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }

            .ContainerPopupdiv span {
                display: inline-block;
                float: left;
                width: 32%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }

        .XLIcon {
            float: right;
            margin: 0px -3px 4px 0px;
        }

        .XLIcon1 {
            float: right;
            margin: 0px -3px 1px 0px;
            width: 4%;
        }

        .breadcrumb {
            padding: 0px 15px 0px 0px;
        }

        .crumbs {
            background-color: transparent !important;
            /*border-top: 1px solid #d9d9d9;*/
            border-bottom: 0px solid #fff;
            height: 20px;
        }

        .row {
            background-color: transparent !important;
            height: 429px !important;
            overflow: hidden !important;
        }

        .breadcrumb > li + li::before {
            color: #fff;
        }

        .crumbs .breadcrumb li i {
            color: #fff;
        }

        .widget.box .widget-content {
            background-color: transparent;
        }


        body {
            background-color: transparent !important;
            color: #fff !important;
        }

        .GridViewTbln1 {
            width: 28%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GridViewTbl1 {
            width: 71.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .widget.box {
            height: 383px;
        }

        .LblHead {
            font-size: 13px;
            color: #000;
            padding: 2px 0px 2px 0px;
            float: left;
            font-weight: bold;
            margin: 0px 0px 0px 5px;
            font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
            width: 50%;
        }

        .DivGrid {
            float: left;
            height: 323px;
            overflow: auto;
            border: 1px solid #fff;
        }

        div#DivGrdInfo {
            float: left;
            height: 360px;
            overflow: auto;
            margin: 3px 0px 0px 0px;
            width: 100%;
        }

        .Hiden1 {
            display: none !important;
        }

        #Div_NoOf_Container {
            left: 337px !important;
            top: 96px !important;
        }

        .modalPopupss1 {
            background-color: rgba(0,0,0,0.5);
            width: 1062px;
            width: 100%;
            height: 570px;
            margin-left: 0%;
            margin-top: -0.9%;
            border-left:0px solid #000;
        }




        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;*/
            width: 1062px;
            width: 99%;
            height: 570px;
            margin-left: 0%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }

div#Divbooking {
    width: 100%;
    height: 326px;
    overflow: auto;
    padding-top: 3px;
}
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="crumbs">
            <ul id="breadcrumbs" class="breadcrumb">
                <%--   <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>--%>
                <li class="current" id="lbl" runat="server">Quick View Info </li>
            </ul>
        </div>
        <div >
            <div class="col-md-12  maindiv">

                <div class="widget box">

                    <div class="widget-header" style="display: none;">
                        <h4><i class="icon-umbrella"></i>
                            <asp:Label ID="LBLTitle" runat="server"></asp:Label></h4>
                    </div>
                    <div class="widget-content">
                        <div class="FormGroupContent4">

                            <div class="GridViewTbln1">
                                <div class="FormGroupcontent4">
                                    <div class="LblHead" id="lblHead" runat="server"></div>
                                    <div class="XLIcon" id="divbtnExcel1" runat="server">
                                        <div class="btn btn-excel1">
                                            <asp:Button ID="btnExcel1" runat="server" ToolTip="ExecelDownload" OnClick="btnExcel1_Click" />
                                        </div>

                                    </div>
                                    <div id="DivCount" runat="server" class="DivGrid">
                                        <asp:GridView ID="Grd" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="100%" ShowHeaderWhenEmpty="true"
                                            OnRowDataBound="Grd_RowDataBound" OnSelectedIndexChanged="Grd_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Details" HeaderText="Details ">
                                                    <HeaderStyle Width="420px" />
                                                    <ItemStyle Width="420px" Wrap="True"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status" HeaderText="Count">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle Wrap="True" Width="100px"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader " />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>

                            <!-- Grid View Source 2 Start -->
                            <div class="GridViewTbl1">
                                <div class="FormGroupcontent4">
                                    <div class="LblHead" id="Heading" runat="server"></div>
                                    <div class="XLIcon1" id="divbtnExcel2" runat="server">

                                        <div class="btn btn-excel1">
                                            <asp:Button ID="btnExcel2" runat="server" ToolTip="ExecelDownload" OnClick="btnExcel2_Click" />
                                        </div>
                                    </div>
                                    <div id="DivGrdInfo" runat="server">
                                        <asp:GridView ID="GrdInfo" runat="server" AutoGenerateColumns="false" CssClass="Grid table-fixed" Width="100%" ShowHeaderWhenEmpty="true"
                                            OnRowDataBound="GrdInfo_RowDataBound" OnSelectedIndexChanged="GrdInfo_SelectedIndexChanged" OnPreRender="GrdInfo_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" Height="18px" Wrap="false" />
                                                    <ItemStyle Width="30px" Height="18px" Wrap="false" />
                                                </asp:TemplateField>
                                                <%-- 0 --%>
                                                <asp:BoundField DataField="Bookingno" HeaderText="Booking #">
                                                    <HeaderStyle Width="102px" Height="18px" Wrap="false" />
                                                    <ItemStyle Width="102px" Height="18px" Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 1 --%>
                                                <asp:BoundField DataField="Bookingdate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" Width="70px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="70px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 2 --%>
                                                <asp:BoundField DataField="Tues" HeaderText="Tues ">
                                                    <HeaderStyle Width="27px" Height="18px" />
                                                    <ItemStyle Width="27px" Height="18px" Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 3 --%>
                                                <asp:BoundField DataField="C20" HeaderText="20'">
                                                    <HeaderStyle Width="17px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="17px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 4 --%>
                                                <asp:BoundField DataField="C40" HeaderText="40'">
                                                    <HeaderStyle Width="17px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="17px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 5 --%>
                                                <asp:BoundField DataField="blno" HeaderText="BL #" HeaderStyle-CssClass="Hiden1" ItemStyle-CssClass="Hiden1">
                                                    <HeaderStyle Width="109px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="109px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 6 --%>
                                                <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-CssClass="Hiden1" ItemStyle-CssClass="Hiden1">
                                                    <HeaderStyle Width="40px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="40px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 7 --%>
                                                <asp:BoundField DataField="bookingno1" HeaderText="Booking #" HeaderStyle-CssClass="Hiden1" ItemStyle-CssClass="Hiden1">
                                                    <HeaderStyle CssClass="Hiden1" />
                                                    <ItemStyle Wrap="True" Width="7%" CssClass="Hiden1"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 8 --%>
                                                <asp:BoundField DataField="bid" HeaderText="Branchid" HeaderStyle-CssClass="Hiden1" ItemStyle-CssClass="Hiden1">
                                                    <HeaderStyle CssClass="Hiden1" />
                                                    <ItemStyle Wrap="True" Width="7%"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 9 --%>
                                                <asp:BoundField DataField="cbm" HeaderText="M3">
                                                    <HeaderStyle Width="40px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="40px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 10 --%>
                                                <asp:BoundField DataField="pol" HeaderText="POL">
                                                    <HeaderStyle Width="70px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="70px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 11 --%>
                                                <asp:BoundField DataField="pod" HeaderText="POD">
                                                    <HeaderStyle Width="80px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="80px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 12 --%>
                                                <asp:BoundField DataField="VesselVoy" HeaderText="VesselVoyage" HeaderStyle-CssClass="Hiden1" ItemStyle-CssClass="Hiden1">
                                                    <HeaderStyle CssClass="Hiden1" />
                                                    <ItemStyle Wrap="True" Width="7%"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 13 --%>
                                                <asp:BoundField DataField="eventdate" HeaderText="EvenDate" HeaderStyle-CssClass="Hiden1" ItemStyle-CssClass="Hiden1">
                                                    <HeaderStyle CssClass="Hiden1" />
                                                    <ItemStyle Wrap="True" Width="7%"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 14 --%>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader " />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                    </div>
                                    <div id="Divbooking" runat="server">

                                        <asp:GridView ID="Grdbooking" runat="server" AutoGenerateColumns="false" CssClass="Grid table-fixed" Width="100%" ShowHeaderWhenEmpty="true"
                                            OnPreRender="Grdbooking_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="30px" Height="18px" />
                                                    <ItemStyle Width="30px" Height="18px" />
                                                </asp:TemplateField>
                                                <%-- 0 --%>
                                                <asp:BoundField DataField="Bookingno" HeaderText="Booking #">
                                                    <HeaderStyle Width="122px" Height="18px" />
                                                    <ItemStyle Width="122px" Height="18px" Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 1 --%>
                                                <asp:BoundField DataField="Bookingdate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" Width="80px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="80px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 2 --%>
                                                <asp:BoundField DataField="Tues" HeaderText="Teus ">
                                                    <HeaderStyle Width="27px" Height="18px" />
                                                    <ItemStyle Width="27px" Height="18px" Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 3 --%>
                                                <asp:BoundField DataField="pol" HeaderText="POL">
                                                    <HeaderStyle Width="97px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="97px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 4 --%>
                                                <asp:BoundField DataField="pod" HeaderText="POD">
                                                    <HeaderStyle Width="97px" Height="18px" />
                                                    <ItemStyle Wrap="false" Width="97px" Height="18px"></ItemStyle>
                                                </asp:BoundField>
                                                <%-- 5 --%>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader " />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>






        <%-- POPUP --%>

        <asp:Label ID="lblcrm" runat="server"></asp:Label>
        <ajaxtoolkit:ModalPopupExtender ID="NoOfContainer" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior1"
            PopupControlID="ConPannel" Drag="true"
            BackgroundCssClass="modalBackground" CancelControlID="imgfgok">
        </ajaxtoolkit:ModalPopupExtender>
        <asp:Panel ID="ConPannel" runat="server"  CssClass="modalPopup1" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div id="Div_NoOf_Container" runat="server" class="ContainerPopupdiv">
                <div class="DivSecPanel">
                    <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="150%" />
                </div>
                <div class="FormGroupContent4">
                    <label>Booking No: </label>
                    <span id="SpanBookingNo" runat="server"></span>
                    <label class="lblDate" id="lblDate1" runat="server">: </label>
                    <span id="SpanDate" runat="server"></span>
                </div>
                <div class="FormGroupContent4">
                    <label>F.Vessel Voyage: </label>
                    <span id="SpanVesselvou" runat="server"></span>

                </div>
                <asp:Panel ID="panel_ConDet" runat="server"  CssClass="modalPopup" ScrollBars="Auto" Height="133px">
                    <div class="GridMt1">
                        <asp:GridView ID="grd_Noof_Container" runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found"
                            class="Grid">
                            <Columns>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="containerno" HeaderText="Container #">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                    <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sizetype" HeaderText="Size">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                    <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sealno" HeaderText="Seal #">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="270px" />
                                    <ItemStyle Font-Bold="false" Width="270px" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pkgs" HeaderText="pkgs">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                    <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="wt" HeaderText="Wt(MT)">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="90px" />
                                    <ItemStyle Font-Bold="false" Width="90px" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CRODate" HeaderText="CRO Date" HeaderStyle-CssClass="Hiden1" ItemStyle-CssClass="Hiden1">
                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="120px" />
                                    <ItemStyle Font-Bold="false" Width="120px" HorizontalAlign="Justify" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </div>
                    <div class="GridMt2">
                        <asp:GridView ID="Grd_vessel" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" >
                            <Columns>
                                <asp:BoundField DataField="vessel" HeaderText="M.Vessel & voy">
                                    <HeaderStyle Width="35%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pol" HeaderText="PoL">
                                    <HeaderStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="etd" HeaderText="ETD">
                                    <HeaderStyle Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pod" HeaderText="PoD">
                                    <HeaderStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="eta" HeaderText="ETA">
                                    <HeaderStyle Width="35%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="remarks" HeaderText="remarks">
                                    <HeaderStyle CssClass="Hiden1" />
                                    <ItemStyle CssClass="Hiden1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vsl" HeaderText="vessel">
                                    <HeaderStyle CssClass="Hiden1" />
                                    <ItemStyle CssClass="Hiden1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="voy" HeaderText="voy">
                                    <HeaderStyle CssClass="Hiden1" />
                                    <ItemStyle CssClass="Hiden1" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader2" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle CssClass="GrdRow" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </asp:Panel>

    </form>
</body>
</html>
