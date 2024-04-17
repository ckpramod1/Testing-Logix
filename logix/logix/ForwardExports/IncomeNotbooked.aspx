<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="IncomeNotbooked.aspx.cs" Inherits="logix.ForwardExports.IncomeNotbooked" %>
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

    <%--    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>


    <script src="../js/MoveLabelAfter.js"></script>

    <script src="../js/TextField.js"></script>
    <%--    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>--%>
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>

    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>


    <style type="text/css">
        .row {
            height: 566px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
        }

        .widget.box {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
            margin-top: 0px;
            height: 565px;
        }

        .GridIncome1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            overflow-y: auto !important;
            height: 264px;
        }

        .LblHead {
            color: #4e4e4c;
            font-weight: bold;
            font-size: 12px;
            font-family: Tahoma;
            width:12% !important;
            float:left;
        }








        .Grid1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            overflow-y: auto !important;
        }

            .Grid1 th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 12px;
                color: #4e4c4c !important;
            }

            .Grid1 td {
                border-right: 1px solid #dddddd;
                font-size: 12px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

            .Grid1 tr:last-child {
                color: #ab1e1e !important;
            }

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
                font-size: 12px;
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
            font-family: Tahoma;
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
                font-size: 12px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 12px;
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
                font-family: Tahoma;
                color: #4e4e4c;
            }

        .dropdownproduct {
            width: 13.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .hide {
            display: none;
        }


        .GridS1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 10px 0px 0px 0px;
            overflow-y: auto !important;
        }

            .GridS1 th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 12px;
                color: #4e4c4c !important;
            }

            .GridS1 td {
                border-right: 1px solid #dddddd;
                font-size: 12px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

            .GridS1 tr:last-child {
                color: #ab1e1e !important;
            }


        .lbl_Header {
            /*font-size: 10pt;
    font-family: Tahoma;*/
            text-align: left;
            color: #4e4e4c;
           
            font-size: 15px;
            background-color: #F8F8F8;
            /*text-shadow: rgb(150, 150, 150) 1px 3px 0px, rgb(171, 168, 168) 1px 13px 5px;*/
            float:left;
           
        }

        .dvScrollTest {
        }
    </style>


        <script type="text/javascript">
        $(function () {
            $(".grd_incomenot > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".GrdAgeing td").removeClass("highlite");
                    var $cell = $(e.target).closest("td");
                    $cell.addClass('highlite');
                    var $currentCellText = $cell.text();
                    var $leftCellText = $cell.prev().text();
                    var $rightCellText = $cell.next().text();
                    var $colIndex = $cell.parent().children().index($cell);
                    var $colName = $cell.closest("table")
                        .find('th:eq(' + $colIndex + ')').text();
                    $("#para").empty()
                        .append("<b>Current Cell Text: </b>"
                            + $currentCellText + "<br/>")
                        .append("<b>Text to Left of Clicked Cell: </b>"
                            + $leftCellText + "<br/>")
                        .append("<b>Text to Right of Clicked Cell: </b>"
                            + $rightCellText + "<br/>")
                        .append("<b>Column Name of Clicked Cell: </b>"
                            + $colName)
                });

        });
    </script>





    <script type="text/javascript">
        function pageLoad() {


            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            <%--  $(document).ready(function () {
                $('#<%=grd_incomenot.ClientID%>').gridviewScroll({
                     width: 780,
                     height: 270,
                     arrowsize: 30,
                    freezesize: 5,
                     varrowtopimg: "../images/arrowvt.png",
                     varrowbottomimg: "../images/arrowvb.png",
                     harrowleftimg: "../images/arrowhl.png",
                     harrowrightimg: "../images/arrowhr.png"
                 });
       });--%>

            <%-- $(document).ready(function () {
                 $('#<%=grd_incomenot.ClientID%>').gridviewScroll({
                     width: 1500,
                     height: 300,
                     freezesize: 2,
                     arrowsize: 3,

                     varrowtopimg: "../images/arrowvt.png",
                     varrowbottomimg: "../images/arrowvb.png",
                     harrowleftimg: "../images/arrowhl.png",
                     harrowrightimg: "../images/arrowhr.png"
                 });
             });--%>

        }
        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../Sales/IncomeNotbooked.aspx/GetShipername",
                 <%-- data: '{Prefix: "' + $("#<%=txt_Search.ClientID %>").val() + '" }',--%>

                data: "{ 'Prefix': '" + $("#<%=txt_Search.ClientID %>").val() + "','pend':'" + $("#<%=ddl_PendAll.ClientID %>").val() + "','prod':'" + $("#<%=ddl_PendAllProd.ClientID %>").val() + "'}",


                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    //alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            $("#<%=btn_search.ClientID %>").click();
        }

    </script>


    <style type="text/css">
        .ChkAlign {
            padding-left: 37px !important;
        }

        a.aspNetDisabled {
            color: #4e4e4c !important;
        }

       

        .FixedHeader td {
            border-right: 1px solid #AAA;
            border-bottom: 1px solid #AAA;
        }

        .FixedHeader th:nth-child(29) {
            min-width: 450px;
        }

        .FixedHeader td:nth-child(29) {
            min-width: 450px;
        }

        .FixedHeader th:nth-child(31) {
            min-width: 450px;
        }

        .FixedHeader td:nth-child(31) {
            min-width: 450px;
        }

        .row {
            height: 570px !important;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .MT23 {
            margin: 23px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 12px;
        }

        .FormGroupContent4 label {
            color: #000080;
            font-size: 12px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }


        .Grid tr.frozen-row {
            background-color: #FDCB0A; /* Maintains hover color */
        }

        .gridcolor {
            background: red !important;
        }
        table#logix_CPH_grd_incomenot thead tr th:nth-child(1) {
    position: sticky !important;
    width: 80px !important;
    min-width: 80px !important;
    max-width: 80px !important;
    left: 0px !important;
    background-color:#eae7e7 !important;
    z-index:10;
  
}
        table#logix_CPH_grd_incomenot tbody tr td:nth-child(1){
            position: sticky !important;
width: 80px !important;
min-width: 80px !important;
max-width: 80px !important;
left: 0px !important;
background-color:#eae7e7 !important;

        }
                table#logix_CPH_grd_incomenot thead tr th:nth-child(2) {
    position: sticky !important;
    width: 50px !important;
    min-width: 50px !important;
    max-width: 50px !important;
    left: 80px !important;
     background-color:#eae7e7 !important;
      z-index:10;
}
                table#logix_CPH_grd_incomenot tbody tr td:nth-child(2){
                    position: sticky !important;
width: 50px !important;
min-width: 50px !important;
max-width: 50px !important;
left: 80px !important;
 background-color:#eae7e7 !important;

                }
table#logix_CPH_grd_incomenot thead tr th:nth-child(3) {
    position: sticky !important;
    width: 110px !important;
    min-width: 110px !important;
    max-width: 110px !important;
    left: 130px !important;
    background-color: #eae7e7 !important;
    z-index: 10;
}
        table#logix_CPH_grd_incomenot tbody tr td:nth-child(3){
            position: sticky !important;
width: 110px !important;
min-width: 110px !important;
max-width: 110px !important;
left: 130px !important;
background-color:#eae7e7 !important;

        }
                                table#logix_CPH_grd_incomenot thead tr th:nth-child(4) {
    position: sticky !important;
    width: 94px !important;
    min-width: 94px !important;
    max-width: 94px !important;
    left: 240px !important;
    background-color:#eae7e7 !important;
    z-index:10;
  
}
        table#logix_CPH_grd_incomenot tbody tr td:nth-child(4){
            position: sticky !important;
width: 90px !important;
min-width: 90px !important;
max-width: 90px !important;
left: 240px !important;
background-color:#eae7e7 !important;

        }

div#logix_CPH_panel {
    height: 675px !important;
}
table#logix_CPH_grd_incomenot tbody tr:hover {
    background: var(--labelorange) !important;
    cursor: pointer;
    border-top: 2px solid var(--labelorange) !important;
    border-left: 2px solid blue var(--labelorange) !important;
    border-bottom: 2px solid var(--labelorange) !important;
}
.lbl_Header{
    margin-left:0px !important;
}


    </style>


    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/TransferToPoL.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="">
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblMeText" runat="server" Text="IncomeNotBooked"></asp:Label></h4>

                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li id="homelbl" runat="server"><a href="#"></a>MIS</li>
                                <li id="lbl1" runat="server"><a href="#" title="" id="headerlable1" runat="server"></a></li>
                                <li class="current"><a href="#" title="">BL Register</a> </li>
                            </ul>
                        </div>
                        <!-- /Breadcrumbs line -->
                    </div>
                        </div>

                </div>


                <div class="widget-content">
                    <div class="FormGroupContent4 MB10">

                        <div class="dropdownproduct">
                            <asp:Label ID="Label1" runat="server" Text="Product"> </asp:Label>
                            <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged1">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="dropdownproduct">
                            <asp:Label ID="Label2" runat="server" Text="Type"> </asp:Label>
                            <asp:DropDownList ID="ddl_PendAll" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Type" data-placeholder="Type" OnSelectedIndexChanged="ddl_PendAll_SelectedIndexChanged1">
                                <asp:ListItem Value="S">Select</asp:ListItem>
                                <asp:ListItem Value="A">ALL</asp:ListItem>
                                <asp:ListItem Value="P">Pending</asp:ListItem>
                                <%--<asp:ListItem Value="T">Till (2021 March)</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>

                        <div class="dropdownproduct">
                            <asp:Label ID="Label3" runat="server" Text="Search"> </asp:Label>
                            <asp:DropDownList ID="ddl_PendAllProd" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Search" data-placeholder="Search" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Value="B">Booking #</asp:ListItem>
                                <asp:ListItem Value="M">MBL #/Mawbl #</asp:ListItem>
                                <asp:ListItem Value="BL">BL #/Hawbl #</asp:ListItem>
                                <asp:ListItem Value="S">Shipper</asp:ListItem>
                                <asp:ListItem Value="C">	Consignee</asp:ListItem>
                                <asp:ListItem Value="A">OSDN Agent</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="dropdownproduct">
                            <asp:Label ID="Label4" runat="server" Text="Search"> </asp:Label>
                            <asp:TextBox ID="txt_Search" runat="server" CssClass="form-control" MaxLength="20" AutoPostBack="true" onkeyup="GetDetail();"></asp:TextBox>

                        </div>
                        <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />

                        <div class="right_btn MB13 MBC2 MT15">
                            <div class="btn ico-excel">
                                <asp:Button ID="btn_export" runat="server" ToolTip="ExportExcel" OnClick="btn_export_Click" />
                            </div>
                        </div>

                    </div>
                    <div style="float:left;width:100%;">
                    <div style="float:left;width:100%;">
                    <div class="FormGroupContent2">

                        <asp:Panel ID="panel" runat="server" CssClass="gridpnl">
                            <%-- CssClass="GridIncome1"--%>
                            <asp:GridView ID="grd_incomenot" runat="server" CssClass="Grid1 FixedHeader" Width="100%" AutoGenerateColumns="false" OnRowDataBound="grd_incomenot_RowDataBound" 
                                ShowHeaderWhenEmpty="true"
                                  OnPreRender="grd_incomenot_PreRender"  OnSelectedIndexChanged="grd_incomenot_SelectedIndexChanged">
                                <%-- OnRowCommand="grd_incomenot_RowCommand" --%>
                                <Columns>

                                    <asp:BoundField DataField="shortname" HeaderText="Branch"><%--  1--%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" Wrap="false" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="120px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="product" HeaderText="Job#"><%--  2 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="bookingno" HeaderText="Booking #"><%--  3 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" Wrap="false" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="120px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="bookdate" HeaderText="Date"><%--  4 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="120px" Wrap="false" />
                                    </asp:BoundField>
                                    <%-- Quotationcustomer--%>

                                    <%-- <asp:BoundField DataField="quotcust"  HeaderText="Quotationcustomer">                             
                        <ControlStyle Width="50px" />
                          <HeaderStyle Width ="50px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Left"  Width ="120px" Wrap="false"/>                      
                      </asp:BoundField>--%>

                                    <asp:BoundField DataField="jobno" HeaderText="Job #"><%--  5 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="jobdate" HeaderText="Opened on"><%--  6 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="vessel" HeaderText="Vessel/Flight"><%--  7 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <%--  <asp:BoundField  DataField="Agentname" HeaderText="OSDN Agent">                              
                        <ControlStyle Width="50px" />
                          <HeaderStyle Width ="50px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Left"  Width ="50px"  />                      
                      </asp:BoundField>--%>


                                    <asp:BoundField DataField="mblno" HeaderText="MBL #/Mawbl #"><%--  8 --%>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" Wrap="false" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="100px" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="blno" HeaderText="BL #/Hawbl #"><%--  9 --%>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" Wrap="false" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="100px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Customer"><%--  10 --%>
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="quotcust" runat="server" Text='<%# Bind("quotcust") %>' ToolTip='<%#Bind("quotcust")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Left"  />

                                    </asp:TemplateField>

                                    <%-- <asp:BoundField  DataField="shipper" HeaderText="Shipper">                              
                        <ControlStyle Width="25px" />
                          <HeaderStyle Width ="25px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Left"  Width ="25px"  Wrap="false"/>                      
                      </asp:BoundField>--%>

                                    <asp:TemplateField HeaderText="Shipper"><%--  11 --%>
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="shipper" runat="server" Text='<%# Bind("shipper") %>' ToolTip='<%#Bind("shipper")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Left"  />

                                    </asp:TemplateField>

                                    <%-- <asp:BoundField  DataField="consignee" HeaderText="Consignee">                              
                        <ControlStyle Width="25px" />
                          <HeaderStyle Width ="25px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Left"  Width ="25px"  Wrap="false"/>                      
                      </asp:BoundField>--%>


                                    <asp:TemplateField HeaderText="Consignee"><%--  12 --%>
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;" >
                                                <asp:Label ID="consignee" runat="server" Text='<%# Bind("consignee") %>' ToolTip='<%#Bind("consignee")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Left"  />

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Agent"><%--  13 --%>
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="Agentname" runat="server" Text='<%# Bind("Agentname") %>' ToolTip='<%#Bind("Agentname")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Left"  />

                                    </asp:TemplateField>

                                    <asp:BoundField DataField="mlo" HeaderText="Lines"><%--  14 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>



                                    <asp:BoundField DataField="pol" HeaderText="Pol"><%--  15 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="pod" HeaderText="Pod"><%--  16 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="grwt" HeaderText="20/Gr.Wt"><%--  17 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="chwt" HeaderText="40/CH.Wt"><%--  18 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <%--  <asp:BoundField DataField="quotcust"  HeaderText="Quotationcustomer">                             
                        <ControlStyle Width="50px" />
                          <HeaderStyle Width ="50px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Left"  Width ="120px" Wrap="false"/>                      
                      </asp:BoundField>--%>


                                    <%--                                    <asp:BoundField DataField="airpol" HeaderText="AirPol">
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="airpod" HeaderText="AirPod">
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>--%>


                                    <asp:BoundField DataField="cbm" HeaderText="M3"><%--  19 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="shipperinvoice" HeaderText="Shipper Ref #"><%--  20 --%>
                                        <ControlStyle />
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                    </asp:BoundField>


                                    <%--                                    <asp:BoundField DataField="etd" HeaderText="Etd">
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="days" HeaderText="Days">
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>--%>

                                    <asp:BoundField DataField="proinvdate" HeaderText="Pro SI Date"><%--  21 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Inv#"><%--  22 --%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="invno" runat="server" ForeColor="Red" Text='<%#Eval("invno")%>' ToolTip='<%#Eval("invno")%>' OnClick="invno_Click"></asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="invdate" HeaderText="InvDate"><%--  23 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="prusInv#"><%--  24 --%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="prusinvno" runat="server" ForeColor="Red" Text='<%#Eval("prusinvno")%>' ToolTip='<%#Eval("prusinvno")%>' OnClick="invno_Click"></asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="prusinvdate" HeaderText="Prusinvdate"><%--  25 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="proOSDNdate" HeaderText="ProOSSI"><%--  26 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="OSDN#"><%--  27 --%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="osdnno" runat="server" ForeColor="Red" Text='<%#Eval("osdnno")%>' ToolTip='<%#Eval("osdnno")%>' OnClick="osdnno_Click"></asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OSDNdate" HeaderText="OSDNdate"><%--  28 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="OSCN#"><%--  29 --%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="oscnno" runat="server" ForeColor="Red" Text='<%#Eval("oscnno")%>' ToolTip='<%#Eval("oscnno")%>' OnClick="osdnno_Click"></asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OSCNdate" HeaderText="OSCN Date"><%--  30 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" Wrap="false" />
                                    </asp:BoundField>



                                    <%--                                   <asp:TemplateField HeaderText="Sel">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false" CssClass="Arrow" Text="ProInv" OnClick="Lnk_job_Click"></asp:LinkButton>
                                            <br />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sel">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Lnk_OSDN" runat="server" CommandName="select" Font-Underline="false" CssClass="Arrow" Text="ProOSSI" OnClick="Lnk_OSDN_Click"></asp:LinkButton>
                                            <br />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                    <%-- <asp:BoundField  DataField="incomeconf" HeaderText="IncomeBooked">                                      
                        <ControlStyle Width="50px" />
                          <HeaderStyle Width ="50px"/>
                        <ItemStyle  Font-Bold="false" HorizontalAlign="Left"  Width ="50px" />                      
                      </asp:BoundField> --%>
                                    <%--<asp:TemplateField HeaderText="IncomeBooked">

                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ChkAlign" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="incomeconf" runat="server" Enabled="false"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--  Exensesed booked--%>

                                    <%--<asp:TemplateField HeaderText="ExpenseBooked">

                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ChkAlign" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="expenseconf" runat="server" Enabled="false"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="JobStatus" HeaderText="JobStatus"><%--  31 --%>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>


                                    <asp:ButtonField CommandName="ColumnClick"  />
                                    <%--<asp:BoundField DataField="invoicecustomername" HeaderText="invoice customer">
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle Width="50px"  CssClass="hide"/>
                                        <ItemStyle Font-Bold="false" CssClass="hide" HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>--%>
                                </Columns>


                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />

                                <%-- <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                  <HeaderStyle CssClass="" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <AlternatingRowStyle CssClass="GrdAltRow" />--%>
                            </asp:GridView>

                        </asp:Panel>


                    </div>
                    <div style="float:left;width:100%;">
                    <div class="LblHead">Closed & Unclosed Jobs -</div>
                    <div class="lbl_Header">
                        <asp:Label ID="lbl_count" runat="server"></asp:Label>
                    </div>
                    </div>
                        </div>
                    <div style="float:left;width:100%;">
                    <div class="FormGroupContent4" style="margin: 10px 0px 0px 0px; width: 100%; float: left;">

                        <%--  <div style="margin:10px 0px 0px 0px; width:100%; float:left;">--%>
                        
                        <div class="gridpnl">
                            <asp:GridView ID="grd_jobcount" runat="server" CssClass="GridS1 FixedHeader" Width="28%" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnPreRender="grd_jobcount_PreRender">
                                <Columns>

                                    <asp:BoundField DataField="trantype" HeaderText="Product"><%--  1--%>
                                        <ControlStyle Width="30px" />
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="30px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="closedjob" HeaderText="Closed Job #"><%--  2--%>
                                        <ControlStyle Width="10px" />
                                        <HeaderStyle Width="10px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="10px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="unclosedjob" HeaderText="Unclosed Job #"><%--  2--%>
                                        <ControlStyle Width="10px" />
                                        <HeaderStyle Width="10px" />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="10px" Wrap="false" />
                                    </asp:BoundField>





                                </Columns>
                            </asp:GridView>


                        </div>
                    </div>
                    </div>
                    <br />
                    <br />

                </div>
                    </div>

                <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames"></iframe>



            </div>
        </div>
    </div>


    <asp:HiddenField ID="Hid_trantype" runat="server" />
    <asp:HiddenField ID="hid_count" runat="server" />
</asp:Content>


