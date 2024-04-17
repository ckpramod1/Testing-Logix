<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewHroHome.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.NewHroHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />

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

        .hide {
            display: none;
        }
        .PendingEventNew{float:left; width:100%; margin:0px 0px 5px 0px; border:0px solid #f00;
    height: 200px;
}
        .HrmConfirmationNew {width:100%; float:left; margin:0px 10px 0px 0px;
    
}
             .HrmConfirmationNew1 {width:100%; float:left; margin:10px 10px 0px 0px;
    
}
        .PendingHRMNew1{width:100%; float:left; margin:0px 0px 0px 0px; max-height:201px;  min-height:201px; overflow:auto; }
        .EmployeeDetailsNew{float:left; width:29%; margin:15px 0px 0px 0px;}
            .EmployeeDetailsNew h3 {padding:0px 0px 0px 0px; margin:10px 0px 10px 0px; font-size:14px;
            }
        .EmployeeDetailsKpi{float:left; width:46%; margin:15px 0px 0px 0px;}
            .EmployeeDetailsKpi h3 {padding:0px 0px 0px 5px; float:left; width:19%; margin:10px 0px 10px 6px; font-size:14px;
            }
        .PendingHRM4New{width:100%; border:1px solid #b1b1b1; float:left; margin:1px 0px 0px 10px; max-height:199px;  min-height:199px; overflow:auto; }
        .EmployeeDetailsforNew{float:left; width:46.5%; margin:51px 0px 0px 0px; color:maroon;}
            .EmployeeDetailsforNew span {font-size:12px; font-weight:normal; display:inline-block; margin:0px 0px 0px 0px;
            }
        .PendingHRMnew{width:100%; border:1px solid #b1b1b1; float:left; margin:5px 0px 0px 10px; max-height:157px;  min-height:157px; overflow:auto; }
        
        .EmployeeDetails1 {margin:51px 0px 0px 10px; width:25%; float:left; color:maroon;
        }
        .EmployeeDetails1 span{font-size:12px; font-weight:normal; display:inline-block; margin:0px 0px 0px 0px;
        }

        .KPTEmpdrop {margin:14px 0px 0px 0px; float:left; width:15%;
        }

        #cmbYearkbi_chzn {
            width:100%!important;
        }


        .PendingHRM {
    width: 100%;
    float: left;
    margin: 5px 0px 0px 0px;
    min-height: 157px;
    overflow: auto;
    border:1px solid #b1b1b1;
}

        .Grid {width:100%;border:1px solid #b1b1b1;  margin:0px 0px 0px 0px; overflow-x:hidden!important; overflow-y:auto!important;
}
    .Grid th { background-color:#4a9cce!important; border-right:1px solid #fff; font-family:tahoma; padding:2px 5px 2px 5px; font-size:12px; color:#fff!important;
    }
    .Grid td {border-right:1px solid #dddddd; font-size:12px; text-align:left; font-family:tahoma; padding:2px 5px 2px 5px; margin:0px; color:#4e4c4c; border-bottom:1px solid #dddddd;
    }
        .Grid tr:last-child {color:#ab1e1e!important;
        }
        .EmployeeDetails {
    float: left;
    width: 26%;
    margin: 0px 0px 0px 0px;
}

.Gridpnl1 > div {
    height: 160px;
    overflow-x: hidden;
    overflow-y: scroll;
    margin-top: 10px;
    margin-left: 10px;
}
.PendingEmployee {
    width: 24%;
    float: left;
    margin: 0px 0px 0px 10px;
    max-height: 200px;
    min-height: 200px;
}

        .PendingEmployee h3 {
            margin:25px 0px 0px 0px;
            font-size:14px;
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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div class="row PaDtopCtrl">
            <div class="col-md-12  maindiv">
                <asp:Panel ID="Panel2" runat="server" CssClass="panel1" scrolling="no" frameborder="0" src="">
                    <!-- Tabs-->
                    <div class="widget box borderremove">
                        <%--  <div class="widget-header">
                        <h4><i class="icon-umbrella"></i>Pending</h4>
                    </div>--%>
                        <div class="widget-content">

                            <div style="float: left; width: 100%; margin: 0px 10px 0px 0px;">
                                <div class="PendingEventNew">

                                    <div class="HrmConfirmationNew">

                                        <div class="EmployeeDetails">

                                            <h3>
                                                <img src="../Theme/assets/img/probation_ic.png" />
                                                <span>Employee Details</span></h3>
                                            <div class="PendingHRM">

                                                <asp:Panel ID="Paneldiv" runat="server"  CssClass="Gridpnlex" Visible="true">
                                                    <asp:GridView ID="Griddivconpro" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="Griddivconpro_RowDataBound" OnSelectedIndexChanged="Griddivconpro_SelectedIndexChanged">
                                                        <Columns>
                                                              <asp:TemplateField HeaderText="Company">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px">
                                                                    <asp:Label ID="Division" runat="server" Text='<%# Bind("Division") %>' ToolTip='<%#Bind("Division")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="65px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />

                                                        </asp:TemplateField>
                                                          
                                                            <asp:BoundField DataField="divisionid" HeaderText="divisionid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                            </asp:BoundField>

                                                            <asp:TemplateField HeaderText="Confirm" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px" >
                                                                    <asp:Label ID="Confirm" runat="server" Text='<%# Bind("Confirm") %>' ToolTip='<%#Bind("Confirm")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="65px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />

                                                        </asp:TemplateField>
                                                              <asp:TemplateField HeaderText="Probation" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px">
                                                                    <asp:Label ID="Probation" runat="server" Text='<%# Bind("Probation") %>' ToolTip='<%#Bind("Probation")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="65px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />

                                                        </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>


                                                <div class="Clear"></div>
                                               

                                            </div>

                                        </div>


                                        <div class="EmployeeDetails1" id="detailEmp" runat="server">
                                                <div class="PendingHRM" id="divBranch" runat="server">

                                                <asp:Panel ID="pnlBranchwise" runat="server"  CssClass="Gridpnlex" >
                                                    <asp:GridView ID="grdBranchEmpDetails" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" OnRowDataBound="grdBranchEmpDetails_RowDataBound" OnSelectedIndexChanged="grdBranchEmpDetails_SelectedIndexChanged">
                                                        <Columns>
                                                             <asp:TemplateField HeaderText="Branch">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px">
                                                                    <asp:Label ID="branch" runat="server" Text='<%# Bind("branch") %>' ToolTip='<%#Bind("branch")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="65px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />

                                                        </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Confirm" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px">
                                                                    <asp:Label ID="confirm" runat="server" Text='<%# Bind("confirm") %>' ToolTip='<%#Bind("confirm")%>' ></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="65px"   />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px"  />

                                                        </asp:TemplateField>
                                                      
                                                               <asp:TemplateField HeaderText="Probation" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width:65px">
                                                                    <asp:Label ID="Probation" runat="server" Text='<%# Bind("Probation") %>' ToolTip='<%#Bind("Probation")%>' ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="65px"  />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px"  />

                                                        </asp:TemplateField>
                                                           
                                                            <asp:BoundField DataField="branchid" HeaderText="branchid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>


                                                <div class="Clear"></div>
                                                

                                            </div>

                                           

                                        </div>

                                        <div class="EmployeeDetailsforNew" id="Empdeatis" runat="server">
                                               
                                            <div class="PendingHRMnew" id="divNew" runat="server">

                                                <asp:Panel ID="pnlcustomerWisw" runat="server"  CssClass="Gridpnlex" >
                                                    <asp:GridView ID="GrdCustomerWise" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL #">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" Width="15px" />
                                                        <HeaderStyle Wrap="false" Width="15px" />
                                                    </asp:TemplateField>
                                                            <asp:BoundField DataField="Empid" HeaderText="Empid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                            </asp:BoundField>

                                                               <asp:TemplateField HeaderText="Empname">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px">
                                                                    <asp:Label ID="Empname" runat="server" Text='<%# Bind("Empname") %>' ToolTip='<%#Bind("Empname")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />

                                                        </asp:TemplateField>

                                                              <asp:TemplateField HeaderText="Department">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px">
                                                                    <asp:Label ID="Department" runat="server" Text='<%# Bind("Department") %>' ToolTip='<%#Bind("Department")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="65px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />

                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Designation">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px">
                                                                    <asp:Label ID="designation" runat="server" Text='<%# Bind("designation") %>' ToolTip='<%#Bind("designation")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="65px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />

                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 55px">
                                                                    <asp:Label ID="Status" runat="server" Text='<%# Bind("Status") %>' ToolTip='<%#Bind("Status")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="55px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="55px" />

                                                        </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>


                                                <div class="Clear"></div>
                                             

                                            </div>

                                           

                                        </div>

                                    </div>












                                </div>

                                <div class="Clear"></div>
                              <div class="HrmConfirmationNew1">

                                        <div class="EmployeeDetailsNew" id="PendingEmp" runat="server">

                                            <h3>
                                                <img src="../Theme/assets/img/confirmation_list.png" />
                                                Pending Confirmation</h3>
                                            
                                            <div class="PendingHRMNew1">

                                                <asp:Panel ID="pnlPendingCon" runat="server"  CssClass="Gridpnlex" Visible="false">
                                                    <asp:GridView ID="GridView1PendingConfirmation" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false" >
                                                        <Columns>

                                                              <asp:BoundField DataField="Company" HeaderText="Company" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                            </asp:BoundField>
                                                             <asp:TemplateField HeaderText="Branch">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 55px">
                                                                    <asp:Label ID="Branch" runat="server" Text='<%# Bind("Branch") %>' ToolTip='<%#Bind("Branch")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="55px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="55px" />

                                                        </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="EMPNAME">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 170px">
                                                                    <asp:Label ID="EMPNAME" runat="server" Text='<%# Bind("EMPNAME") %>' ToolTip='<%#Bind("EMPNAME")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="170px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="170px" />

                                                        </asp:TemplateField>
                                                       

                                                       
                                                        <asp:BoundField DataField="(Confirm)" HeaderText="Confirm">
                                                            <HeaderStyle Wrap="false" Width="20px" HorizontalAlign="Center" />
                                                            <ItemStyle Font-Bold="false" Width="20px" Wrap="false" HorizontalAlign="Justify" />
                                                        </asp:BoundField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>


                                                <div class="Clear"></div>
                                              

                                            </div>
                                        </div>


                                        <div class="EmployeeDetailsKpi">

                                            <h3>
                                                <img src="../Theme/assets/img/probation_ic.png" />
                                                <span> Appraisal</span></h3>
                                                               <div class="KPTEmpdrop"> <asp:DropDownList ID="cmbYearkbi" runat="server" ToolTip ="Year" data-placeholder ="Year" CssClass ="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="cmbYearkbi_SelectedIndexChanged">
        <asp:ListItem></asp:ListItem>     
        </asp:DropDownList></div>
                                            <div class="PendingHRM4New" >

                                                <asp:Panel ID="PnalelKpi" runat="server"  CssClass="Gridpnlex" Visible="true">
                                                    <asp:GridView ID="grdKpiDetails" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="grdKpiDetails_RowDataBound" OnSelectedIndexChanged="grdKpiDetails_SelectedIndexChanged">
                                                        <Columns>

                                                               <asp:TemplateField HeaderText="Company">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 275px">
                                                                    <asp:Label ID="divisionname" runat="server" Text='<%# Bind("divisionname") %>' ToolTip='<%#Bind("divisionname")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="right" Width="275px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="275px" />

                                                        </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 25px">
                                                                    <asp:Label ID="totemployee" runat="server" Text='<%# Bind("totemployee") %>' ToolTip='<%#Bind("totemployee")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle  Width="25px" />
                                                            <ItemStyle  Width="25px" />

                                                        </asp:TemplateField>

                                                              <asp:TemplateField HeaderText="Self" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 30px">
                                                                    <asp:Label ID="Self" runat="server" Text='<%# Bind("Self") %>' ToolTip='<%#Bind("Self")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle  Width="30px" />
                                                            <ItemStyle  Width="30px" />

                                                        </asp:TemplateField>

                                                             <asp:TemplateField HeaderText="Appraised" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 65px">
                                                                    <asp:Label ID="Appraiser" runat="server" Text='<%# Bind("Appraiser") %>' ToolTip='<%#Bind("Appraiser")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle  Width="65px" />
                                                            <ItemStyle  Width="65px" />

                                                        </asp:TemplateField>
                                                          
                                                            <asp:TemplateField HeaderText="Reviewed" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 50px">
                                                                    <asp:Label ID="Reviewer" runat="server" Text='<%# Bind("Reviewer") %>' ToolTip='<%#Bind("Reviewer")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />

                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Approved" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 50px">
                                                                    <asp:Label ID="COO" runat="server" Text='<%# Bind("COO") %>' ToolTip='<%#Bind("COO")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle  Width="50px" />
                                                            <ItemStyle  Width="50px" />

                                                        </asp:TemplateField>
                                                               <asp:BoundField DataField="divisionid" HeaderText="Divisionid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                            </asp:BoundField>

                                                           <asp:BoundField DataField="year" HeaderText="year" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    </asp:GridView>
                                                </asp:Panel>


                                                <div class="Clear"></div>
                                              

                                            </div>

                                            
                                        </div>

                                        <div class="PendingEmployee">
                                            <h3>
                                                <img src="../Theme/assets/img/birthdaylist.png" />
                                                Birth Day List</h3>
                 <div class="Gridpnl1 MB10" >
                     <asp:Panel ID="Panelbdaylist" runat="server"  Height="200px" Visible="false">
                         <asp:GridView ID="grdbdaylist" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="false">
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

                            <div class="float:left; width:275px;">


                                


                                

                            </div>




                        </div>

                    </div>
                </asp:Panel>
                <!--END TABS-->

            </div>
        </div>
        <asp:HiddenField ID="hidfyear" runat="server" />
    </form>
</body>
</html>
