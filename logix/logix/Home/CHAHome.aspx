﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CHAHome.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.CHAHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <link href="../Styles/LengthConversion.css" rel="stylesheet" />
    <link href="../Styles/WeightConversion.css" rel="stylesheet" />
    <link href="../Styles/VolumeConversion.css" rel="stylesheet" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>


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
    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #Test_foregroundElement {
            left: 55px !important;
            top: 312px !important;
        }

        #Test1_foregroundElement {
            left: 147px !important;
            top: 312px !important;
        }

        #Test2_foregroundElement {
            left: 211px !important;
            top: 312px !important;
        }

        #Test3_foregroundElement {
            left: 60px !important;
            top: 285px !important;
        }

        #Test4_foregroundElement {
            left: 525px !important;
            top: 283px !important;
        }

        .row {
            clear: both;
            height: 535px !important;
            margin: 0 5px 0 -15px;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
        }

        #logix_CPH_pln_KPI {
            left: 25px !important;
            top: 25px !important;
        }


        #Panel3 {
            top: 340px !important;
            left: 358px !important;
        }

        #Panel5 {
            top: 340px !important;
            left: 358px !important;
        }

        #pln_KPI {
            top: 200px !important;
            left: 358px !important;
        }

        #Panel1 {
            top: 340px !important;
            left: 323px !important;
        }


        .modalPopupssQ {
            background-color: #ffffff;
            border: 1px solid #b1b1b1;
            height: 300px;
            margin-left: 25px;
            margin-top: 0px;
            width: 52%;
            /*left: 25px; top: 0px;*/
        }

        .modalPopupssQnew {
            background-color: #ffffff;
            border: 1px solid #b1b1b1;
            height: 150px;
            margin-left: 25px;
            margin-top: 0px;
            width: 40%;
            /*left: 25px; top: 0px;*/
        }

        .DivSecPanelkpi {
            width: 20px;
            Height: 20px;
            border: 0px solid #b1b1b1;
            margin-left: 98.3%;
            margin-top: -1.5%;
            border-radius: 90px 90px 90px 90px;
        }

        .Gridpnkpi {
            width: 100%;
            Height: 220px;
        }

        .frameskpi {
            height: 100%;
            width: 100%;
        }

        .widget-LBL {
            margin-bottom: 0;
            padding: 0;
            /*float: left;*/
            margin-right: 1.5%;
        }

        .LeaveLbl {
            color: #4e4c4c !important;
            font-size: 14px;
            font-weight: 500;
            height: 20px;
            margin: 0 0 5px;
            padding: 5px 0;
            width: 100%;
            font-weight: bold;
        }

        .Div_Profile {
            float: left;
            height: 309px;
            margin: 10px 0 0;
            overflow: auto;
            width: 100%;
        }

        .panel {
            box-shadow: none !important;
        }

        .BandRight {
            float: right;
            margin: 0px 0px 0px 0px;
        }


        .BandMiddle {
            background-color: #98AFC7;
            float: left;
            min-height: 25px;
            padding: 2px 2px 2px 5px;
            margin: 0px 0px 0px 0px;
            width: 1366px;
        }

        .PendingRightn1 h3 {
            font-family: tahoma;
            color: #184684;
            font-size: 14px;
            padding: 5px 0px 10px 5px;
            margin: 0px 0px 0px 0px;
        }

        .PendingRightn1 {
            float: right;
            width: 110px;
            margin: 0px 0px 0px 5px;
        }

            .PendingRightn1 a {
                display: inline-block;
                margin: 0px 0px 0px 5px;
            }

        .BandTop {
            background-color: #656464;
            float: left;
            min-height: 32px;
            padding: 2px 2px 2px 5px;
            width: 100%;
        }

            .BandTop h3 {
                color: #ffffff;
                padding: 2px 0px 2px 0px;
                margin: 0px 0px 0px 0px;
            }

                .BandTop h3 a {
                    color: #ffffff;
                    font-size: 11px;
                    font-family: sans-serif;
                    padding: 2px 0px 2px 0px;
                    margin: 0px 0px 0px 5px;
                }

        .BreadLabel {
            width: 15%;
            color: #ffffff;
            float: left;
            margin: 1px 0.5% 0px 21px;
            font-weight: normal;
            font-size: 11px;
        }

        .TitleLeft2 {
            width: 10%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

            .TitleLeft2 a {
                display: inline-block;
                margin: 0px 0px 0px 5px !important;
            }

        .TitleLeft1 {
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .BandLeft {
            float: left;
            width: 77.5%;
        }
         thead{
            position:sticky;
            top:0;
        }

        .PendingTblGrid th {
    text-align: center;
    color: #fff;
    font-size: 11px;
    font-family: sans-serif, Geneva, sans-serif;
    background-color: #4a9cce;
    padding: 5px !important;
    margin: 0px;
}
       
        .PendingTbl4 {
    width: 195px;
    float: left;
    margin: 0px 0px 0px 10px;
    height: 158px;
    overflow: auto;
}.PendingEvent1 {
    float: left;
    width: 670px;
    background-color: var(--white);
    margin: 10px 0px 15px 0px;
}

        .BarChart {
    float: left;
    width: 447px;
    margin: 0px 10px 0px 0px;
    background-color: var(--white);
    border: 1px solid var(--inputborder);
}
        .Grid th,.PendingTblGrid th,th span {
    background: var(--navbarcolor)!important;
    color: var(--white)!important;
}
        .PendingTblGrid th span{
    color: var(--white)!important;

        }
        a#LinkButton2:hover {
    color: black;
}
        .PendingLeft {
    margin: 0px 0.5% 0px 10px;
}
    </style>

    <%--TEST--%>

    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("[id*=lnk_unclosedjobs]").click(function () {
                ShowPopup1();
                return false;
            });

            $("[id*=lnk_PendingApproval]").click(function () {
                ShowPopup2();
                return false;
            });
        });

        function ShowPopup1() {
            $("#dialog1").dialog({
                title: "Unclosed Jobs",
                width: 200,
                height: 270,
                modal: true
            });
        }

        function ShowPopup2() {
            $("#dialog2").dialog({
                title: "Pending Approval",
                width: 200,
                height: 270,
                modal: true
            });
        }
    </script>

    <%--TEST--%>
</head>
<body>

 <%--   <p>
        Sales_Person_Click</p>--%>

    <script type="text/javascript">

        window.onload = function () {
            var l1 = $("#<%=hidbooking.ClientID %>").html();
            var l2 = $("#<%=hidhbl.ClientID %>").html();
            var l3 = $("#<%=hidmbl.ClientID %>").html();
            var l4 = $("#<%=hidunclosed.ClientID %>").html();


            var l5 = $("#<%=hidapprovalquo.ClientID %>").html();
            var l6 = $("#<%=hidapprovalInvoices.ClientID %>").html();
            var l7 = $("#<%=hidapprovalCNOp.ClientID %>").html();
            var l8 = $("#<%=hidapprovalOSDebit.ClientID %>").html();
            var l9 = $("#<%=hidapprovalOSCredit.ClientID %>").html();
            var l10 = $("#<%=hidapprovalOtherDebitNotes.ClientID %>").html();
            var l11 = $("#<%=hidapprovalOtherCreditNotes.ClientID %>").html();
            var chart = new CanvasJS.Chart("chartContainer", {
                title: {
                    text: ""
                },
                axisX: {
                    interval: 10
                },
                dataPointWidth: 50,
                data: [{
                    type: "column",
                    indexLabelLineThickness: 2,
                    dataPoints: [

                          //{ x: 10, y: l1 - 0, indexLabel: "Booking" },

                          { x: 10, y: l4 - 0, indexLabel: "UnClosed Jobs" }

                    ]
                }]
            });
            chart.render();

            var chart = new CanvasJS.Chart("chartContainer2",
             {
                 theme: "theme2",
                 title: {
                     text: ""
                 },
                 data: [
                 {
                     type: "pie",
                     //showInLegend: true,
                     //toolTipContent: "{y} - #percent %",
                     //yValueFormatString: "#0.#,,. Million",
                     //legendText: "{indexLabel}",
                     dataPoints: [
                         //{ y: 4181563, indexLabel: "Invoice" },
                         //{ y: 2175498, indexLabel: "CN Oper" },
                         //{ y: 3125844, indexLabel: "DN" },
                         //{ y: 1176121, indexLabel: "CN" }

                     { y: l5 - 0, indexLabel: "Quotation" },
                         { y: l6 - 0, indexLabel: "Pro Inv" },
                         { y: l7 - 0, indexLabel: "Pro CN Opr" },
                         { y: l8 - 0, indexLabel: "Pro O/S DN" },
                         { y: l9 - 0, indexLabel: "Pro O/S CN" },
                         { y: l10 - 0, indexLabel: "Pro Other DN" },
                         { y: l11, indexLabel: "Pro Other CN" }
                     ]
                 }
                 ]
             });
            chart.render();
        }

    </script>
    <noscript>
Your browser does not support JavaScript!
</noscript>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <!-- Breadcrumbs line -->
        <!-- <div class="crumbs">
          <div class="DashboardLeft">
      <h3>Dashboard</h3>
      <span>Good Morning Rajkumar!</span>
      </div>
      <div class="DashCal">
        <img src="assets/img/cal_icon.png"> 
        <span> August, 19, 2016</span>
        </div>
      
      </div> -->
        <!-- /Breadcrumbs line -->
        <div class="Clear"></div>
        <div class="BandMiddle">
            <div class="BreadLabel" id="OptionDoc" runat="server">CHA</div>
        </div>
        <div class="BandTop">
             <div class="BandLeft">
            <div class="TitleLeft2">
                <h3>
                    <img src="../Theme/assets/img/query.png"><asp:LinkButton ID="LinkButton10" runat="server" Text="Query" OnClick="LinkButton10_Click"></asp:LinkButton>
                </h3>
            </div>
             <div class="TitleLeft1">
                    <h3>
                        <img src="../Theme/assets/img/salesperson_ic.png"><asp:LinkButton ID="Sales_Person" runat="server" Text="AmendSalesPerson" OnClick="Sales_Person_Click"></asp:LinkButton>
                    </h3>
                </div>
           
               
            </div>

            <div class="PendingRightn1">



                <img src="../Theme/assets/img/job_ic.png">
                <asp:LinkButton ID="LinkButton2" runat="server" Text="Job Closing" OnClick="LinkButton2_Click"></asp:LinkButton>

            </div>
        </div>





        <div class="row PaDtopCtrl">
            <div class="col-md-12  maindiv">
                <!-- Tabs-->
                <div class="widget box borderremove">
                    <%--  <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                    <div class="widget-content">
                        <div style="float: left; width: 1074px;">
                            <div class="BarChart">
                                <div id="chartContainer" style="height: 240px; width: 100%;"></div>
                                <div class="Clear"></div>
                                <div class="PendingBooking">
                                    <ul>
                                        <%--<li>
                                        <img src="../Theme/assets/img/pending_book_ic.png" /><asp:LinkButton ID="lnk_PendingBooking" runat="server" ForeColor="Navy"
                                            Style="text-decoration: none" OnClick="lnk_PendingBooking_Click">Booking</asp:LinkButton></li>
                                    <asp:Panel ID="pln_popup" runat="server"  CssClass="modalPopupN1" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="DivSecPanel">
                                            <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                                        </div>
                                        <asp:Panel ID="Panelbooking" runat="server"  CssClass="GridN1" Visible="false">
                                            <asp:GridView ID="grdpendingbook1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%"
                                                ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false"
                                                OnRowDataBound="grdpendingbook1_RowDataBound" OnSelectedIndexChanged="grdpendingbook1_SelectedIndexChanged">
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </asp:Panel>

                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                    <ajax:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
                                        DropShadow="false" TargetControlID="Label2" CancelControlID="close" BehaviorID="Test">
                                    </ajax:ModalPopupExtender>--%>


                                        <%--   <li>
                                        <img src="../Theme/assets/img/pending_hbl_ic.png" /><asp:LinkButton ID="lnk_PendingHBL" runat="server" ForeColor="Navy"
                                            Style="text-decoration: none" OnClick="lnk_PendingHBL_Click">HBL</asp:LinkButton></li>
                                    <asp:Panel ID="Panelhbl1" runat="server"  CssClass="modalPopupN2" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="DivSecPanel">
                                            <asp:Image ID="close1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                                        </div>
                                        <asp:Panel ID="Panelhbl" runat="server"  CssClass="GridN2" Visible="false">
                                            <asp:GridView ID="grdpendinghbl" CssClass="tblGrid" runat="server" AutoGenerateColumns="false" Width="100%"
                                                ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true"
                                                OnRowDataBound="grdpendinghbl_RowDataBound" Visible="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Pending HBL#">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                                <asp:Label ID="cnt" runat="server" Text='<%# Bind("cnt") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </asp:Panel>

                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                    <ajax:ModalPopupExtender ID="pop_hblgrd" runat="server" PopupControlID="Panelhbl1"
                                        DropShadow="false" TargetControlID="Label5" CancelControlID="close1" BehaviorID="Test1">
                                    </ajax:ModalPopupExtender>--%>


                                        <%-- <li>
                                        <img src="../Theme/assets/img/pending_mbl_ic.png" /><asp:LinkButton ID="lnk_PendingMBL" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_PendingMBL_Click">MBL</asp:LinkButton></li>
                                 <asp:Panel ID="Panelmbl1" runat="server"  CssClass="modalPopupN2" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
                                 <div class="divRoated">
                                <div class="DivSecPanel"> <asp:Image ID="close2" runat="server" ImageUrl="~/images/close2.png"/>  </div>  
                                    <div class="Gridpnl1">
                                        <asp:Panel ID="Panelmbl" runat="server"  Visible="false" CssClass="GridN2">
                                            <asp:GridView ID="grdpendingmbl" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdpendingmbl_RowDataBound" OnSelectedIndexChanged="grdpendingmbl_SelectedIndexChanged" Visible="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Pending MBL#">
                                                        <ItemTemplate>
                                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                                <asp:Label ID="cnt" runat="server" Text='<%# Bind("cnt") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                    </div>
     

                      </asp:Panel>


                     <asp:Label ID="Label6" runat="server"></asp:Label>
                    <ajax:ModalPopupExtender ID="pop_mblGrd" runat="server" PopupControlID="Panelmbl1"
                                        DropShadow="false" TargetControlID="Label6" CancelControlID="close2" BehaviorID="Test2">
                                    </ajax:ModalPopupExtender>--%>

                                        <li>
                                            <img src="../Theme/assets/img/unclosed_ic.png" />
                                            <asp:LinkButton ID="lnk_unclosedjobs" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_unclosedjobs_Click">Unclosed Jobs</asp:LinkButton>
                                        </li>
                                        <%--<asp:Panel ID="panelunclosed" runat="server"  CssClass="modalPopupN2" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
                                 <div class="divRoated">
                                <div class="DivSecPanel"> <asp:Image ID="close3" runat="server" ImageUrl="~/images/close2.png"/>  </div>  --%>
                                        <div id="dialog1" style="display: none;">
                                            <div class="PendingTbl1">
                                                <asp:Panel ID="PanelUnclosedjob" runat="server" Visible="false">
                                                    <asp:GridView ID="grdunclosejobs" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdunclosejobs_RowDataBound" OnSelectedIndexChanged="grdunclosejobs_SelectedIndexChanged" Visible="false">
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="GridHeader" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </div>
                                        </div>

                                        <%--</asp:Panel>
                     <asp:Label ID="Label7" runat="server"></asp:Label>
                    <ajax:ModalPopupExtender ID="pop_Grdunclosed" runat="server" PopupControlID="panelunclosed"
                                        DropShadow="false" TargetControlID="Label7" CancelControlID="close3" BehaviorID="Test3">
                                    </ajax:ModalPopupExtender>--%>
                                    </ul>
                                </div>

                            </div>
                            <div class="PendingEvent">
                                <div id="chartContainer2" style="height: 240px; width: 100%;"></div>

                                <div class="Clear"></div>
                                <ul>
                                    <li>
                                        <img src="../images/1472042570_4.png" /><asp:LinkButton ID="lnk_PendingApproval" runat="server" ForeColor="Navy" Style="text-decoration: none" OnClick="lnk_PendingApproval_Click" Height="17px">Pending Approval</asp:LinkButton></li>
                                    <%-- <asp:Panel ID="panelApproval1" runat="server"  CssClass="modalPopupN2" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
                                 <div class="divRoated">
                                <div class="DivSecPanel"> <asp:Image ID="close4" runat="server" ImageUrl="~/images/close2.png"/>  </div>--%>
                                    <div id="dialog2" style="display: none;">
                                        <div class="Gridpnl1">
                                            <asp:Panel ID="PanelApproval" runat="server"  Visible="false" CssClass="GridN2">
                                                &nbsp;<asp:GridView ID="GrdPending1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdPending1_RowDataBound" OnSelectedIndexChanged="GrdPending1_SelectedIndexChanged" Visible="false">
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </div>

                                    <%-- </asp:Panel>
                     <asp:Label ID="Label8" runat="server"></asp:Label>
                    <ajax:ModalPopupExtender ID="Pop_GrdApproval" runat="server" PopupControlID="panelApproval1"
                                        DropShadow="false" TargetControlID="Label8" CancelControlID="close4" BehaviorID="Test4">
                                    </ajax:ModalPopupExtender>--%>
                                </ul>

                            </div>



                            <div class="PendingEvent1">

                                <div class="PendingLeft">
                                    <h3>
                                        <img src="../Theme/assets/img/user_login.png" />
                                        User Logged in</h3>
                                    <div class="panel_07">
                                        <%--<asp:Panel ID="PanelPendingEvent" runat="server"  Visible="true">
                                        <asp:GridView ID="GrdOceanExp1" CssClass="PendingTblGrid" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="GrdOceanExp1_RowDataBound" OnSelectedIndexChanged="GrdOceanExp1_SelectedIndexChanged" Visible="false">
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>--%>
                                        <asp:Panel ID="Paneluserlogged" runat="server"  Height="125px" Visible="false">
                                            <asp:GridView ID="grduserlogged" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grduserlogged_RowDataBound" OnSelectedIndexChanged="grduserlogged_SelectedIndexChanged" Visible="false" OnPreRender="grduserlogged_PreRender">
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>

                                    </div>
                                </div>
                                <div class="PendingRight">

                                    <h3>
                                        <img src="../Theme/assets/img/tols_ic.png" />
                                        Tools</h3>
                                    <div class="panel_07">
                                        <asp:Panel ID="panel_tool" runat="server" Visible="true">


                                            <%--                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="PendingTblGrid">
                                                <tr>
                                                    <th>
                                                        <asp:Label ID="lbl_conversion" runat="server" ForeColor="white" Text="CONVERSION TOOLS"></asp:Label></th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_curr" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Country and Currency"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnl_inco" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Inco Terms"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_length" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Length Conversation"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_weight" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Weigth Conversation"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_volume" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Volume Conversation"></asp:LinkButton></td>
                                                </tr>
                                            </table>--%>

                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="Grid FixedHeader">
                                                <tr>
                                                    <th>
                                                        <asp:Label ID="lbl_conversion" runat="server" ForeColor="white" Text="CONVERSION TOOLS"></asp:Label></th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_curr" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Country and Currency" OnClick="lnk_curr_Click"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnl_inco" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Inco Terms" OnClick="lnl_inco_Click"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_length" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Length Conversation" OnClick="lnk_length_Click"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_weight" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Weigth Conversation" OnClick="lnk_weight_Click"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnk_volume" runat="server" ForeColor="Navy" Style="text-decoration: none" Text="Volume Conversation" OnClick="lnk_volume_Click"></asp:LinkButton></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </div>

                                </div>
                                <div class="PendingRight">
                                    <div class="PortCountry">
                                        <h3>
                                            <img src="../Theme/assets/img/port_country.png" />
                                            Port / Country</h3>
                                        <div class="Porttxt">
                                            <%--<input name="" type="text" class="form-control">--%>
                                            <asp:TextBox ID="txtPort1" runat="server" CssClass="form-control" OnTextChanged="txtPort1_TextChanged" AutoPostBack="true" />
                                        </div>
                                        <div class="Clear"></div>
                                        <asp:Panel ID="pnlPortCountry1" runat="server"  Visible="true" CssClass="PendingTbl3">
                                            <asp:GridView ID="GrdPort1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true">
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>

                                    </div>

                                </div>

                            </div>
                        </div>
                        <div class="float:left; width:295px;">
                            <div class="PortCountryC">




                                <div class="Unclosed">
                                    <h3>
                                        <img src="../Theme/assets/img/exrate_ic.png" />
                                        <span>Ex Rate</span></h3>
                                    <div class="PendingTbl2">
                                        <asp:Panel ID="Panelexrate" runat="server"  CssClass="panel_20" Visible="true">
                                            <asp:GridView ID="Gridexrate" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnPreRender="Gridexrate_PreRender" >
                                                <Columns>
                                                    <asp:BoundField DataField="excurr" HeaderText="Curr">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="localexrate" HeaderText="Local">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="osexrate" HeaderText="OS">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
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
                        <div style="clear: both;"></div>
                    </div>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_KPI" runat="server" CssClass="modalPopupQ" Style="display: none;">
                            <div class="DivSecPanelkpi">
                                <asp:Image ID="Close_KPI" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="div_Break"></div>

                            <div class="widget-LBL" style="margin-bottom: 10px;">
                                <div class="LeaveLbl"><span>Country Currency</span></div>
                            </div>
                            <asp:Panel ID="panel" runat="server" CssClass="panel_10" Style="overflow: auto; height: 300px;">
                                <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="true">
                                    <Columns></Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                    </div>
                    <ajax:ModalPopupExtender runat="server" ID="popup_KPI"
                        PopupControlID="pln_KPI" CancelControlID="Close_KPI" TargetControlID="Label3" DropShadow="false">
                    </ajax:ModalPopupExtender>
                    <asp:Label ID="Label3" runat="server"></asp:Label>



                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopupQnew" Style="display: none;">
                            <div class="DivSecPanelkpi">
                                <asp:Image ID="Image1" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="div_Break"></div>

                            <%--<div class="widget-LBL" style="margin-bottom:10px;">
                                 <div class="LeaveLbl"><span>Length Conversion</span></div>
                                    </div>--%>
                            <asp:Panel ID="panel2" runat="server" CssClass="panel" Style="overflow: auto; height: 107px;">
                                <div class="div_total">
                                    <div class="widget-LBL" style="margin-bottom: 10px;">
                                        <div class="LeaveLbl"><span>Length Conversion</span></div>
                                    </div>

                                    <div class="div_Break"></div>
                                    <div class="div_inchestxt">
                                        <asp:TextBox ID="txtInches" runat="server" placeholder="Inches" AutoPostBack="true" ToolTip="Inches" CssClass="Text" BorderColor="#999997" OnTextChanged="txtInches_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_MilliMetertxt">
                                        <asp:TextBox ID="txtMilliMeter" runat="server" placeholder="MilliMeter" AutoPostBack="true" ToolTip="MilliMeter" CssClass="Text" BorderColor="#999997" OnTextChanged="txtMilliMeter_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                    <div class="div_Yardstxt">
                                        <asp:TextBox ID="txtYards" runat="server" placeholder="Yards" ToolTip="Yards" AutoPostBack="true" CssClass="Text" BorderColor="#999997" OnTextChanged="txtYards_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_CentiMetertxt">
                                        <asp:TextBox ID="txtCentimeter" runat="server" AutoPostBack="true" placeholder="CentiMeter" ToolTip="CentiMeter" CssClass="Text" BorderColor="#999997" OnTextChanged="txtCentimeter_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>

                                    <div class="div_Feettxt">
                                        <asp:TextBox ID="txtFeet" runat="server" placeholder="Feet" AutoPostBack="true" ToolTip="Feet" CssClass="Text" BorderColor="#999997" OnTextChanged="txtFeet_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Metertxt">
                                        <asp:TextBox ID="txtMeter" runat="server" placeholder="Meter" AutoPostBack="true" ToolTip="Meter" CssClass="Text" BorderColor="#999997" OnTextChanged="txtMeter_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>



                                </div>
                            </asp:Panel>
                        </asp:Panel>
                    </div>
                    <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender1"
                        PopupControlID="Panel1" CancelControlID="Image1" TargetControlID="Label1">
                    </ajax:ModalPopupExtender>
                    <asp:Label ID="Label1" runat="server"></asp:Label>





                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel3" runat="server" CssClass="modalPopupQnew" Style="display: none;">
                            <div class="DivSecPanelkpi">
                                <asp:Image ID="Image2" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="div_Break"></div>

                            <%--<div class="widget-LBL" style="margin-bottom:10px;">
                                 <div class="LeaveLbl"><span>Weigth Conversation</span></div>
                                    </div>--%>
                            <asp:Panel ID="panel4" runat="server" CssClass="panel" Style="overflow: auto; height: 107px;">
                                <div class="div_total">
                                    <div class="widget-LBL" style="margin-bottom: 10px;">
                                        <div class="LeaveLbl"><span>Weight Conversion</span></div>
                                    </div>
                                    <div class="div_Break"></div>
                                    <div class="div_Ouncetxt">
                                        <asp:TextBox ID="txtOunce" runat="server" placeholder="Ounce" AutoPostBack="true" ToolTip="Ounce" CssClass="Text" BorderColor="#999997" OnTextChanged="txtOunce_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Gramtxt">
                                        <asp:TextBox ID="txtGram" runat="server" placeholder="Gram" AutoPostBack="true" ToolTip="Gram" CssClass="Text" BorderColor="#999997" OnTextChanged="txtGram_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                    <div class="div_Poundtxt">
                                        <asp:TextBox ID="txtPound" runat="server" AutoPostBack="true" placeholder="Pound" ToolTip="Pound" CssClass="Text" BorderColor="#999997" OnTextChanged="txtPound_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Kilogramtxt">
                                        <asp:TextBox ID="txtKilometer" runat="server" AutoPostBack="true" placeholder="KiloMeter" ToolTip="KiloMeter" CssClass="Text" BorderColor="#999997" OnTextChanged="txtKilometer_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>

                                    <div class="div_Tontxt">
                                        <asp:TextBox ID="txtTon" runat="server" AutoPostBack="true" placeholder="Ton" ToolTip="Ton" CssClass="Text" BorderColor="#999997" OnTextChanged="txtTon_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Tonnestxt">
                                        <asp:TextBox ID="txtMeterwe" runat="server" AutoPostBack="true" placeholder="Tonnes" ToolTip="Tonnes" CssClass="Text" BorderColor="#999997" OnTextChanged="txtMeterwe_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                </div>
                            </asp:Panel>
                        </asp:Panel>
                    </div>
                    <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender2"
                        PopupControlID="Panel3" CancelControlID="Image2" TargetControlID="Label4" DropShadow="false">
                    </ajax:ModalPopupExtender>
                    <asp:Label ID="Label4" runat="server"></asp:Label>








                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel5" runat="server" CssClass="modalPopupQnew" Style="display: none;">
                            <div class="DivSecPanelkpi">
                                <asp:Image ID="Image3" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="div_Break"></div>

                            <%--<div class="widget-LBL" style="margin-bottom:10px;">
                                 <div class="LeaveLbl"><span>Volume Conversion</span></div>
                                    </div>--%>
                            <asp:Panel ID="panel6" runat="server" CssClass="panel" Style="overflow: auto; height: 107px;">

                                <div class="div_total">
                                    <div class="widget-LBL" style="margin-bottom: 10px;">
                                        <div class="LeaveLbl"><span>Volume Conversion</span></div>
                                    </div>

                                    <div class="div_Break"></div>
                                    <div class="div_Ouncetxt">
                                        <asp:TextBox ID="txtOuncevoul" runat="server" AutoPostBack="true" placeholder="Ounce" ToolTip="Ounce" CssClass="Text" BorderColor="#999997" OnTextChanged="txtOuncevoul_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_MiliLitertxt">
                                        <asp:TextBox ID="txtMiliLiter" runat="server" AutoPostBack="true" placeholder="MilliLiter" ToolTip="GrMilliLiteram" CssClass="Text" BorderColor="#999997" OnTextChanged="txtMiliLiter_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                    <div class="div_Quarttxt">
                                        <asp:TextBox ID="txtQuart" runat="server" AutoPostBack="true" placeholder="Quart" ToolTip="Quart" CssClass="Text" BorderColor="#999997" OnTextChanged="txtQuart_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Litertxt">
                                        <asp:TextBox ID="txtLiter" runat="server" AutoPostBack="true" placeholder="Liter" ToolTip="Liter" CssClass="Text" BorderColor="#999997" OnTextChanged="txtLiter_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>

                                    <div class="div_Gallontxt">
                                        <asp:TextBox ID="txtGallon" runat="server" AutoPostBack="true" placeholder="Gallon" ToolTip="Gallon" CssClass="Text" BorderColor="#999997" OnTextChanged="txtGallon_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_KiloLitertxt">
                                        <asp:TextBox ID="txtKiloLiter" runat="server" AutoPostBack="true" placeholder="KiloLiter" ToolTip="KiloLiter" CssClass="Text" BorderColor="#999997" OnTextChanged="txtKiloLiter_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="div_Break"></div>
                                </div>



                            </asp:Panel>
                        </asp:Panel>
                    </div>
                    <ajax:ModalPopupExtender runat="server" ID="ModalPopupExtender3"
                        PopupControlID="Panel5" CancelControlID="Image3" TargetControlID="Label5" DropShadow="false">
                    </ajax:ModalPopupExtender>
                    <asp:Label ID="Label5" runat="server"></asp:Label>


                </div>

            </div>
            <!--END TABS-->
        </div>
        <div style="display: none;">
            <asp:Label ID="hidbooking" runat="server" />
            <asp:Label ID="hidhbl" runat="server" />
            <asp:Label ID="hidmbl" runat="server" />
            <asp:Label ID="hidunclosed" runat="server" />
            <asp:Label ID="hidapprovalproinvoice" runat="server" />
            <asp:Label ID="hidapprovalCNOp" runat="server" />
            <asp:Label ID="hidapprovalquo" runat="server" />
            <asp:Label ID="hidapprovalInvoices" runat="server" />
            <asp:Label ID="hidapprovalProCNOp" runat="server" />
            <asp:Label ID="hidapprovalProOSdn" runat="server" />
            <asp:Label ID="hidapprovalOSDebit" runat="server" />
            <asp:Label ID="hidapprovalOScrdit" runat="server" />
            <asp:Label ID="hidapprovalProOtherDN" runat="server" />
            <asp:Label ID="hidapprovalProOtherCN" runat="server" />
            <asp:Label ID="hidapprovalOSCredit" runat="server" />
            <asp:Label ID="hidapprovalOtherDebitNotes" runat="server" />
            <asp:Label ID="hidapprovalOtherCreditNotes" runat="server" />
        </div>
    </form>
</body>
</html>
