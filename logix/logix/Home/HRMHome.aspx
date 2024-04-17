<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRMHome.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.HRMHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
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

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

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
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(".dropdown img.flag").addClass("flag visibility");

            $(".dropdown dt a").click(function () {
                $(".dropdown dd ul").toggle();
            });

            $(".dropdown dd ul li a").click(function () {
                var text = $(this).html();
                $(".dropdown dt a span").html(text);
                $(".dropdown dd ul").hide();
                $("#result").html("Selected value is: " + getSelectedValue("sample"));
            });

            function getSelectedValue(id) {
                return $("#" + id).find("dt a span.value").html();
            }

            $(document).bind('click', function (e) {
                var $clicked = $(e.target);
                if (!$clicked.parents().hasClass("dropdown"))
                    $(".dropdown dd ul").hide();
            });


            $("#flag Switcher").click(function () {
                $(".dropdown img.flag").toggleClass("flag visibility");
            });


        }
    </script>

    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <style type="text/css">
        .dropdown dd ul li a {
            display: block;
            padding: 1px !important;
        }

        .PendingBooking1 ul li {
            padding: 0 0 0 10px !important;
        }

        .row {
            clear: both;
            height: 566px !important;
            margin: 0 5px 0 -15px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        #Paneljobcostingframe {
            height: 190px !important;
        }

        #panel {
            height: 225px;
            overflow: auto;
        }

        #ddl_product_chzn {
            width: 100% !important;
        }

        #ddl_division_chzn {
            width: 100% !important;
        }
    </style>
    <%--TEST--%>

    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <%--TEST--%>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
</head>
<body>

    <script type="text/javascript">

        window.onload = function () {
            var l1 = $("#<%=hidConfirm.ClientID %>").html();
            var l2 = $("#<%=hidProbation.ClientID %>").html();

            var l3 = $("#<%=hidConfirm1.ClientID %>").html();
            var l4 = $("#<%=hidProbation1.ClientID %>").html();

            var l5 = $("#<%=hidConfirm2.ClientID %>").html();
            var l6 = $("#<%=hidProbation2.ClientID %>").html();

            var chart = new CanvasJS.Chart("chart1",
            {
                title: {
                    text: "M+R"
                },
                data: [
                {
                    type: "pie",
                    dataPoints: [
                        { y: l1 - 0, indexLabel: "Confirm" },
                        { y: l2 - 0, indexLabel: "Probation" },
                    ]
                }
                ]
            });
            chart.render();

            var chart = new CanvasJS.Chart("chart2",
            {
                title: {
                    text: "LT"
                },
                data: [
                {
                    type: "pie",
                    dataPoints: [
                        { y: l3 - 0, indexLabel: "Confirm" },
                        { y: l4 - 0, indexLabel: "Probation" },
                    ]
                }
                ]
            });
            chart.render();

            var chart = new CanvasJS.Chart("chart3",
            {
                title: {
                    text: "OLS"
                },
                data: [
                {
                    type: "pie",
                    dataPoints: [
                        { y: l5 - 0, indexLabel: "Confirm" },
                        { y: l6 - 0, indexLabel: "Probation" },
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
        <div class="row PaDtopCtrl">
            <div class="col-md-12  maindiv">
                <asp:Panel ID="Panel2" runat="server" CssClass="panel1" scrolling="no" frameborder="0" src="">
                    <!-- Tabs-->
                    <div class="widget box borderremove">
                        <%--  <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                        <div class="widget-content">

                            <div style="float: left; width: 752px; margin:0px 10px 0px 0px;">
                                <div class="PendingEventE3">

                                    <div class="HrmConfirmation">

                                        <div class="PendingConfirm">
                                            <h3>
                                                <img src="../Theme/assets/img/confirmation_list.png" />
                                                Confirmation List</h3>
                                            <div class="FrameTitle1"><span id="lbl2">Pending Confirmation</span></div>
                                            <asp:Panel ID="panel" runat="server">
                                                <%--<asp:GridView ID="grd" runat="server" CssClass="PendingTblGrid" width="100%" AutoGenerateColumns="true">
                <Columns>
                   

                </Columns>
              <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>--%>
                                                <asp:GridView ID="grd" runat="server" CssClass="PendingTblGrid" Width="100%" AutoGenerateColumns="false" OnRowDataBound="grd_RowDataBound">
                                                    <Columns>
                                                        <%-- <asp:BoundField DataField="EMPNAME" HeaderText="EMPNAME">
                                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Width="50px" Wrap="false" HorizontalAlign="Justify" />
                   </asp:BoundField>
                     <asp:BoundField DataField="Company" HeaderText="Company">
                                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Width="50px" Wrap="false" HorizontalAlign="Justify" />
                   </asp:BoundField>
                     <asp:BoundField DataField="Branch" HeaderText="Branch">
                                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Width="50px"  Wrap="false" HorizontalAlign="Justify" />
                   </asp:BoundField>
                     <asp:BoundField DataField="(Confirm)" HeaderText="Confirm">
                                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                        <ItemStyle Font-Bold="false" Width="50px"  Wrap="false" HorizontalAlign="Justify" />
                   </asp:BoundField>--%>
                                                        <asp:TemplateField HeaderText="EMPNAME">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 125px">
                                                                    <asp:Label ID="EMPNAME" runat="server" Text='<%# Bind("EMPNAME") %>' ToolTip='<%#Bind("EMPNAME")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Company">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 125px">
                                                                    <asp:Label ID="Company" runat="server" Text='<%# Bind("Company") %>' ToolTip='<%#Bind("Company")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Branch">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 50px">
                                                                    <asp:Label ID="Branch" runat="server" Text='<%# Bind("Branch") %>' ToolTip='<%#Bind("Branch")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />

                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="(Confirm)" HeaderText="Confirm">
                                                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                            <ItemStyle Font-Bold="false" Width="50px" Wrap="false" HorizontalAlign="Justify" />
                                                        </asp:BoundField>
                                                        <%-- <asp:TemplateField HeaderText="Confirm">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 300px">
                                        <asp:Label ID="(Confirm)" runat="server" Text='<%# Bind("(Confirm)") %>' ToolTip='<%#Bind("(Confirm)")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="413px" />
                                <ItemStyle HorizontalAlign="Left" Width="300px" />

                   </asp:TemplateField>--%>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>


                                        <div class="PendingEmployee">
                                            <h3>
                                                <img src="../Theme/assets/img/birthdaylist.png" />
                                                Birth Day List</h3>

                                            <%--<asp:LinkButton ID="lnk_bdaylist" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_bdaylist_Click" >Birth Day List</asp:LinkButton>--%></li>           
                                     
                 <div class="Gridpnl1 MB10">
                     <asp:Panel ID="Panelbdaylist" runat="server"  Height="223px" Visible="false">
                         <asp:GridView ID="grdbdaylist" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="grdbdaylist_RowDataBound">
                             <Columns>

                                 <asp:BoundField DataField="branch" HeaderText="Branch">
                                     <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                     <ItemStyle Font-Bold="false" Width="50px" Wrap="false" HorizontalAlign="Justify" />
                                 </asp:BoundField>



                                 <asp:TemplateField HeaderText="EmployeeName">
                                     <ItemTemplate>
                                         <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 125px">
                                             <asp:Label ID="lblempname1" runat="server" Text='<%# Bind("ename") %>' ToolTip='<%#Bind("ename")%>'></asp:Label>
                                         </div>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                     <ItemStyle HorizontalAlign="Left" Width="50px" />

                                 </asp:TemplateField>



                                 <asp:BoundField DataField="bdate" HeaderText="BirthDate">
                                     <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                     <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                 </asp:BoundField>


                             </Columns>

                             <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                             <HeaderStyle CssClass="" />
                             <AlternatingRowStyle CssClass="GrdAltRow" />
                         </asp:GridView>
                     </asp:Panel>
                 </div>
                                        </div>

                                    </div>












                                </div>

                                <div class="Clear"></div>
                                <div class="float:left; width:295px;">
                                <div class="PortCountryChart">

                                    <div id="chart1" style="height: 240px; width: 240px; float:left;"></div>
                                    <div id="chart2" style="height: 240px; width: 240px; float:left;"></div>
                                    <div id="chart3" style="height: 240px; width: 240px; float:left;"></div>

                                 
                                </div>
                            </div>

                            </div>

                            <div class="float:left; width:275px;">
                               <div class="EmployeeDetails">

                                        <h3>
                                            <img src="../Theme/assets/img/probation_ic.png" />
                                            <span>Employee Details</span></h3>
                                        <div class="PendingHRM">

                                            <asp:Panel ID="Paneldiv" runat="server"  CssClass="Gridpnlex" Visible="false">
                                                <asp:GridView ID="Griddivconpro" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
                                                    <Columns>
                                                        <%--       <asp:BoundField DataField="grddivi" HeaderText="Division" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="grdcon" HeaderText="Confirm" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="grdpro" HeaderText="Probation" >
                           <HeaderStyle Wrap="false" HorizontalAlign="Center"  />
                          <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify"/>
                          </asp:BoundField>--%>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>


                                            <div class="Clear"></div>
                                            <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
                                                <div style="font-size: 10pt"><b>Are you sure you want to Confirmed or not?</b></div>
                                                <div class="div_confirm">
                                                    <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
                                                    <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
                                                </div>
                                                <div class="Clear"></div>
                                            </asp:Panel>

                                        </div>

                                        <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
                                            PopupControlID="Panel_Service" TargetControlID="Label3">
                                        </asp:ModalPopupExtender>
                                        <asp:Label ID="Label3" runat="server" Text="Label" Style="display: none;"></asp:Label>

                                    </div>

                                    <div class="EmployeeList">

                                        <h3>
                                            <img src="../Theme/assets/img/employeeList.png" />
                                            Employee List</h3>
                                        <%-- <asp:LinkButton ID="lnk_emplist" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_emplist_Click">Employee List</asp:LinkButton>--%>

                                        <div class="PendingEmployee">
                                            <asp:Panel ID="Paneljobcostingframe" runat="server" Style="border: 1px solid #b1b1b1" Visible="false">
                                                <div class="FrameTitle1">
                                                    <asp:Label ID="lbl1" runat="server" Text="Company"></asp:Label>
                                                </div>

                                                <div class="div_ddl">
                                                    <asp:DropDownList ID="ddl_product" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true"
                                                        data-placeholder="Company" ToolTip="Company" OnTextChanged="ddl_product_TextChanged">
                                                        <asp:ListItem Value="0" Text=""></asp:ListItem>

                                                    </asp:DropDownList>

                                                </div>

                                                <div class="Clear"></div>
                                                <asp:Panel ID="Panelemplist" runat="server"  Visible="false" Style="float: left; margin-left: 4%; margin-top: 1%; width: 94%; height: 112px; overflow: auto">
                                                    <asp:GridView ID="Griddiv" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="Griddiv_RowDataBound" OnSelectedIndexChanged="Griddiv_SelectedIndexChanged" Visible="false">
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="GridHeader" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </asp:Panel>
                                        </div>

                                       
                                    </div>


                                    <div class="EmployeeDetails">
                                        <h3>
                                            <img src="../Theme/assets/img/employee_list.png" />
                                            Confirmed/Probation <%--<asp:LinkButton ID="lnk_cnfpro" runat="server" ForeColor="Navy" style="text-decoration:none" OnClick="lnk_cnfpro_Click">Confirmed/Probation</asp:LinkButton>--%></h3>
                                        <asp:Panel ID="Panelcnfpro" runat="server"  Style="border: 1px solid #b1b1b1" Height="190px" Visible="false">
                                            <div class="FrameTitle1">
                                                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                                            </div>

                                            <div class="div_ddl">
                                                <asp:DropDownList ID="ddl_division" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true"
                                                    data-placeholder="Company" ToolTip="Company" OnTextChanged="ddl_division_TextChanged">
                                                    <asp:ListItem Value="0" Text=""></asp:ListItem>

                                                </asp:DropDownList>

                                            </div>

                                            <div class="Clear"></div>
                                            <asp:Panel ID="Panelcnfpro1" runat="server"  Height="155px" Visible="false" Style="float: left; margin-left: 3%; margin-top: 1%; width: 95%; height: 112px; overflow: auto">
                                                <asp:GridView ID="Griddiv1" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true" Width="100%" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="Griddiv1_RowDataBound" OnSelectedIndexChanged="Griddiv1_SelectedIndexChanged" Visible="false">
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </asp:Panel>
                                    </div>

                                </div>


                             
                           
                        </div>

                    </div>
                </asp:Panel>
                <!--END TABS-->

            </div>
        </div>
        <div style="display: none;">
            <asp:Label ID="hidConfirm" runat="server" />
            <asp:Label ID="hidProbation" runat="server" />
            <asp:Label ID="hidConfirm1" runat="server" />
            <asp:Label ID="hidProbation1" runat="server" />
            <asp:Label ID="hidConfirm2" runat="server" />
            <asp:Label ID="hidProbation2" runat="server" />
        </div>
    </form>
</body>
</html>
