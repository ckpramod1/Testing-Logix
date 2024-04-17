<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="logix.Home.Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxasp" %>

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



    <link href="../Styles/LeaveApplication.css" rel="stylesheet" />

    <link href="../Styles/Profile.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script type="text/javascript" src="../Theme/assets/tab/js/tabs.js"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
   

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("tabs").tab();
        });
    </script>
    <style type="text/css">
        html, body {
            font-family: sans-serif;
        }

        .FormGroupContent4New {
            width: 100%;
            float: left;
            padding: 0px 0px 0px 0px;
            margin: 5px 0.5% 0px 0px;
        }

        .FormGroupContent4New1 {
            width: 25%;
            float: left;
            padding: 0px 0px 0px 0px;
            margin: 5px 0px 0px 0px;
            display: none;
        }

        .displaynone {
            display: block;
        }
    </style>

    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        /*.DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }*/

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .hide {
            display: none;
        }

        #logix_CPH_ddl_cmbSize_chzn {
            width: 100% !important;
        }

        #programmaticModalPopupBehaviordf1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #programmaticModalPopupBehaviordf2_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .modalPopupssN1 {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 243px;
            Height: 220px;
            margin-left: 0;
            margin-top: -1.5%;
            /*padding:1px;            
            display:none;*/
        }

        .modalPopupssN2 {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 157px;
            Height: 158px;
            margin-left: 0;
            margin-top: -1.5%;
            /*padding:1px;            
            display:none;*/
        }

        .modalPopupssCan {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 217px;
            Height: 260px;
            margin-left: 0;
            margin-top: -1.5%;
            /*padding:1px;            
            display:none;*/
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            /*width: 1062px;*/
            width: 70%;
            Height: 207px;
            margin-left: 10%;
            margin-top: -2.1%;
            /*padding:1px;            
            display:none;*/
        }

        .modalPopupssQ {
            background-color: #ffffff;
            border-color: #cccccc;
            border-style: solid;
            height: 368px;
            margin-left: 301px;
            margin-top: 6.1%;
            width: 52%;
        }

        .Gridpnl {
            /*width: 1058px;*/
            width: 100%;
            Height: 300px;
            margin-left: 10%;
        }

        .GridpnNl {
            width: 235px;
            Height: 210px;
            overflow: auto;
        }



        .modalPopupsskpi {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            /*width: 1062px;*/
            width: 60%;
            Height: 232px;
            margin-left: 20%;
            margin-top: 0%;
            margin-right: 0%;
            /*padding:1px;            
            display:none;*/
        }

        .DivSecPanelkpi {
            width: 20px;
            Height: 20px;
            border: 1px solid #b1b1b1;
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

        #logix_CPH_pln_KPI {
            left: 0px !important;
            top: 25px !important;
        }

        .PayslipGridnew {
            width: 95.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

     
    </style>
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }

        .ProEmpcode {
            float: left;
            width: 16%;
            margin: 0px 0% 0px 0px;
        }

        .Proname {
            float: left;
            width: 83.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .PhotoRightN1 {
            height: 79px;
            width: 83px;
            margin: 5px 0px 0px 0px;
            float: left;
        }

        .InvestIncomeNew {
            float: right;
            width: 60%;
            color: maroon;
        }

            .InvestIncomeNew span {
                color: maroon;
            }

        .PhotoRightN1 img {
            border: 1px solid #b1b1b1;
            height: 79px;
            padding: 2px;
            width: 83px;
        }

        .InvestIncomeN2 {
            float: left;
            margin: 0 0% 0 0;
            width: 100%;
        }

        /*.InvestActualN1 {
            float: right;
            margin: 0 0 0 0;
            width: 15%;
        }*/

        .InvestActualN2 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 15%;
        }



        .PhotoLeftN2 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 86.3%;
        }

        .JobName {
            float: left;
            margin: 3px 0.5% 0 0;
            width: 7%;
        }

        .InvestDetails {
            float: left;
            margin: 0 0.5% 0 0;
            width: 38.5%;
        }

        .InvestAmount {
            float: left;
            margin: 0 0 0 0;
            width: 15%;
        }

        .InvestPlan {
            float: left;
            margin: 0 0.5% 0 0;
            width: 25%;
        }

        .InvestIncomeNew {
            float: right;
            width: 64%;
        }

        .InvestGradenew {
            float: left;
            width: 8%;
            margin: 0px 0.5% 0px 0%;
        }

        .widget-LBL {
            margin-bottom: 0;
            padding: 0;
            float: left;
            margin-right:1.5%;
        }

            .widget-LBL span {
                font-weight: bold;
                color:#786209;
            }

            .widget-LBL h4 {
                font-size: 13px;
                padding: 0px;
                margin: 0px;
            }

        /*.ProDeptnew {
            float: left;
            width: 14.5%;
            margin: 0px 0% 0px 0px;
        }*/

        .ProDesi {
            float: left;
            margin: 0 0.5% 0px 0px;
            width: 36.5%;
        }

        .InvestGradenew {
            float: left;
            margin: 0 0 0 0;
            width: 13%;
        }

        .ProDeptNew {
            float: left;
            margin: 0 0.5% 0 0;
            width: 14.5%;
        }

        .ProDesiNew {
            float: left;
            margin: 0 0.5% 0 0;
            width: 14.5%;
        }

        .ProDeptNew1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 19.5%;
        }

        .ProDesiNew1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 25%;
        }

        .NoNeedLbl {
            float: left;
            margin: 10px 0.5% 0 0;
            width: 35%;
            color: maroon;
        }

        .div_Grid {
            border: 1px solid #b1b1b1;
            float: left;
            height: 104px;
            margin-bottom: 0%;
            margin-left: 0;
            margin-top: 0.1%;
            overflow: auto;
            width: 100%;
        }

        .div_GridNew1 {
    border: 1px solid #b1b1b1;
    float: left;
    height: 90px;
    margin-bottom: 0;
    margin-left: 0;
    margin-top: 0.1%;
    overflow: auto;
    width: 100%;
}

        .bordertopNew5 {
    border-top: 1px dotted #807f7f;
    float: left;
    margin: 0 0 10px !important;
    min-height: 1px;
    width: 100%;
}







        .InvestYou {
            float: left;
            margin: 0 0;
            width: 70%;
            color: maroon;
        }

        .MonthProDrop {
            float: left;
            margin: 0 0.5% 0 0%;
            width: 17%;
        }

        .ProYear {
            float: left;
            margin: 0 0.5% 0 0;
            width: 8.5%;
        }

        .Leavecal2 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 13%;
        }

        .LeaveBoth {
            float: left;
            margin: 0 0.5% 0 0;
            width: 18%;
        }

        .Rad3 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 20%;
        }

        .Leavecal {
            float: right;
            width: 13%;
        }

        .KPTKpi {
            float: left;
            width: 69.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .KPTWeightage {
            float: left;
            width: 6.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .Pnl1 {
            padding: 15px 15px 15px 15px;
            background-color: #dbdbdb;
            border: 1px solid #b1b1b1;
        }

        #logix_CPH_Panel_Service1 {
            left: 911px !important;
            top: 220px !important;
            text-align: center;
        }

        #logix_CPH_pnl_Buying {
            top: 250.5px !important;
        }

        .Div_Profile {
            float: left;
            height: 309px;
            margin: 10px 0 0;
            overflow: auto;
            width: 100%;
        }

        .Div_Profilenew {
            float: left;
            height:250px;
            margin: 10px 0 0;
            overflow: auto;
            width: 100%;
        }

        #logix_CPH_Panel6 {
            left: 87px !important;
            top: 25px !important;
            padding: 5px !important;
        }

        .LTAClaim {
            float: left;
            margin: 0 0.2% 0 0;
            width: 100%;
        }

        .modalPopupssLTA {
            background-color: #ffffff;
            border-color: #cccccc;
            border-style: solid;
            height: 207px;
            margin-left: 40%;
            margin-top: -2.1%;
            width: 21%;
        }

        .LeaveLbl {
            color: #4e4c4c !important;
            font-size: 14px;
            font-weight: 500;
            height: 20px;
            margin: 0 0 5px;
            padding: 5px 0;
            width: 100%;
        }
        .MT20 {
            margin-top:20px;
        }
        .KPTEmpdrop {float:right; width:19.5%;
        }

         .div_Menu {
    background-color: White;
    height: 580px;
    margin-left: auto;
    margin-right: auto;
    margin-top: 4%;
    width: 100% !important;
}
.ADDPad1 input {
    width: 61px !important;
}

.Leaverequired {
    float: left;
    margin: 0 0.5% 0 0;
    width: 15%;
}

.LeaveRad {
    float: left;
    margin: 0 0.5% 0 0;
    width: 33%;
}

        .Rad1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 17%;
        }
        .Rad2 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 20%;
}
.Rad3 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 25%;
}  

.row {
    clear: both;
    height: 612px !important;
    margin: 0 5px 0 -15px;
    overflow: hidden !important;
}
.InvestPaid1 {
    float: left;
    width: 34.5%;
    margin: 0px 0.5% 0px 0%;
}
.ProfileRight {
    width: 50%;
    float: left;
    margin: -5px 0% 0px 0%;
    padding: 0px 0px 0px 0px;
}

        .MT6 {
            margin-top:-6px!important;
        }


.bordertopNewB1 {
    float: left;
    min-height: 1px;
    margin: 4px 0px 0px 0px;
    border-top: 1px dotted #807f7f;
    width: 100%;
}
.btn-log input {
    border: medium none;
    line-height: normal;
    color: #4e4e4c!important;
    padding: 5px 10px 6px 28px;
    
}

    .btn-access input {
        border-style: none !important;
        border-color: inherit !important;
        border-width: medium !important;
        
       
        line-height: normal;
        color: #4e4e4e!important;
        padding: 5px 10px 6px 28px!important;
       
        cursor:pointer;
    }


    .btn-itcomputation input {
    border-style: none !important;
    border-color: inherit !important;
    line-height: normal;
    color: #4e4e4c!important;   
    padding: 5px 10px 5px 28px !important;
    
}
.btn-appraisal input {
    border-style: none !important;
    border-color: inherit !important;
    border-width: medium !important;
    line-height: normal;
    color: #4e4e4c;
    padding: 5px 10px 6px 28px!important;
   
   
}
.btn-access input {
    border: medium none !important;
    line-height: normal;
    color: #4e4e4c;
    padding: 5px 10px 6px 28px;
    
}

.InvesrRent {
    float: left;
    width: 17.5%;
    margin: 0px 0% 0px 0%;
}

.widget.box {
    border: 1px solid #D9D9D9;
    float: left;
    width: 100%;
    margin-left: 0px;
    margin-top: 0px;
    height: 598px;
}

        .ProPanno {
            width:24.4%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .ProAdharNo {
            width:24.5%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .ProUINo {
            width:24.5%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .EmailNo {
            width:49.9%;
            float:left;
            margin:0px 0px 0px 0px;
        }
    </style>
    
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <%-- <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>       
              <li>Profile</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->--%>
    <div  >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Profile"></asp:Label></h4>
                </div>
                <div class="widget-content">

                    <div class="ProfileLeft">
                        <div class="FormGroupContent4">
                            <div class="Proname">
                                <asp:TextBox ID="txt_name" runat="server" ToolTip="Name" placeholder="Name" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="ProEmpcode">
                                <asp:TextBox ID="txt_Empcode" runat="server" ToolTip="Name" placeholder="Name" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txt_company" runat="server" ToolTip="Company" placeholder="Company" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">

                            <asp:TextBox ID="txt_Address" runat="server" ToolTip="Address" placeholder="Address" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="PhotoLeftN2">
                            <div class="FormGroupContent4">
                                <div class="ProDept">
                                    <asp:TextBox ID="txt_dept" runat="server" ToolTip="Dept" placeholder="Dept" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="ProDesi">
                                    <asp:TextBox ID="txt_desg" runat="server" ToolTip="Desg" placeholder="Desg" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="InvestGradenew">
                                    <asp:TextBox ID="txt_Grade" runat="server" ToolTip="Grade" placeholder="Grade" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="ProDeptNew">
                                    <asp:TextBox ID="txt_doj" runat="server" ToolTip="DOJ" placeholder="DOJ" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="ProDesiNew">
                                    <asp:TextBox ID="txt_doc" runat="server" ToolTip="DOC" placeholder="DOC" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="ProDeptNew1">
                                    <asp:TextBox ID="txt_mobile" runat="server" ToolTip="Mobile" placeholder="Mobile" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="ProDesiNew1">
                                    <asp:TextBox ID="txt_ph" runat="server" ToolTip="Ph" placeholder="Ph" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="ProPanno">
                                    <asp:TextBox ID="txt_panno" runat="server" ToolTip="PAN #" placeholder="PAN #" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="FormGroupContent4New">
                                 <div class="ProAdharNo"><asp:TextBox ID="txt_addorno" runat="server" ToolTip="Aadhaar #" placeholder="Aadhaar #" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                                <div class="ProUINo"><asp:TextBox ID="txt_uanno" runat="server" ToolTip="UAN #" placeholder="UAN #" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                                <div class="EmailNo"><asp:TextBox ID="txt_email" runat="server" ToolTip="Email" placeholder="Email" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                               
                            </div>

                        </div>
                        <div class="PhotoRightN1">
                            <asp:Image ID="Img_Emp" runat="server" ImageUrl="~/images/UT.jpg" />

                        </div>

                        <%--   <div class="FormGroupContent4New1">
                            <asp:LinkButton ID="lbl_lnkrate" runat="server" Text=" Leave Application Form" ForeColor="red" CssClass="LabelValue" Style="text-decoration: none;" OnClick="lbl_lnkrate_Click"></asp:LinkButton>
                        </div>--%>
                        <div class="FormGroupContent4" style="display: none;">


                            <div class="DataGrid1">
                                <div class="LeaveLbl">Leave Register</div>

                                <asp:Panel ID="Panel2" runat="server" class="grd">
                                    <asp:GridView ID="GridAttende" runat="server" CssClass="Grid1" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="AttendenceDate" HeaderText="Data" />

                                            <asp:BoundField DataField="ForeNoon" HeaderText="FN" />

                                            <asp:BoundField DataField="AfterNoon" HeaderText="AN">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                            <div class="DataGrid2">
                                <div class="LeaveLbl">Leave Balance</div>
                                <asp:Panel ID="Panel3" runat="server" class="grd1">
                                    <asp:GridView ID="Grdlve" runat="server" AutoGenerateColumns="true" CssClass="Grid1" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <%--  <asp:BoundField DataField="acfrom" HeaderText="Leave" /> 
                        <asp:BoundField DataField="lta" HeaderText="Remaining">--%>
                                            <asp:BoundField DataField="attyear" HeaderText="Leave" />
                                            <asp:BoundField DataField="empid" HeaderText="Remaining"></asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>

                            </div>
                        </div>

                        <div class="Clear"></div>
                        <div class="bordertopNew1 MB05"></div>
                        <div class="Clear"></div>
                        <div>
                            <div class="widget-LBL">
                                <asp:Label ID="Label4" runat="server" Text="Investment Plan"></asp:Label>
                            </div>
                          

                                <div class="Investyear">
                                    <asp:DropDownList ID="ddl_Year" runat="server" AutoPostBack="true"  data-placeholder="Year" OnSelectedIndexChanged="ddl_Year_SelectedIndexChanged" CssClass="chzn-select">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="InvestIncomeNew">
                                    <asp:Label ID="lbl_Tax" runat="server" Text="Income Tax  Exemptions ( Tax Planing ) details for the Financial Year"></asp:Label>
                                </div>
                              <div class="displaynone">
                                <div class="FormGroupContent4">
                                    <div class="InvestActualN2">
                                    <asp:TextBox ID="txt_ActualRent"  runat="server" AutoPostBack="True" OnTextChanged="txt_ActualRent_TextChanged" Style="text-align: right;" ToolTip="Actual Rent" placeholder="Actual Rent" CssClass="form-control"></asp:TextBox>
                                </div>

                                   
                                    <div class="InvestHRA">
                                        <asp:TextBox ID="txt_HRA" runat="server" ToolTip="HRA" placeholder="HRA" AutoPostBack="True" Style="text-align: right;" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="InvestBasic">
                                        <asp:TextBox ID="txt_Basic50" runat="server" ToolTip="50%/40% of Basic" AutoPostBack="True" placeholder="50%/40% of Basic" Style="text-align: right;" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                     
                                    <div class="InvestPaid1">
                                        <asp:TextBox ID="txt_RentPaid" runat="server" ToolTip="RentPaid - 10 % OfBasic" AutoPostBack="True" Style="text-align: right;" placeholder="RentPaid - 10% OfBasic" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="InvesrRent">
                                        <asp:TextBox ID="txt_RentExp" runat="server" ToolTip="Rent Exemption" AutoPostBack="True" placeholder="RentExemption" Style="text-align: right; color: red" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="InvestIncomeN2">
                                    <asp:TextBox ID="txt_Income" runat="server" Style="text-align: right;" ToolTip="Income From Other Source - RentReceived Rs. (Per Annum) " placeholder="Income From Other Source - RentReceived Rs.(Per Annum)" CssClass="form-control"></asp:TextBox>
                                </div>
                                
                            </div>
                          
                          
                            <div class="FormGroupContent4">
                                <div class="JobName" style="display:none;">
                                    <asp:LinkButton ID="lnk_section"  runat="server" ForeColor="#FF3300" Style="text-decoration: none" OnClick="lnk_section_Click">Section</asp:LinkButton>
                                </div>
                                <div class="InvestSection">
                                    <asp:DropDownList ID="ddl_Section" runat="server" AppendDataBoundItems="True" ToolTip="Section" data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddl_Section_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="InvestDetails">
                                    <asp:TextBox ID="txt_Detail" runat="server" ToolTip="Details" placeholder="Details" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                </div>
                                <div class="InvestPlan">
                                    <asp:DropDownList ID="ddl_plan" runat="server" AppendDataBoundItems="True" ToolTip="Plan Details" data-placeholder="Plan Details" CssClass="chzn-select" AutoPostBack="true">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                 <%--   <asp:TextBox ID="txt_PlanDetail" runat="server" ToolTip="Plan Details" placeholder="Plan Details" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                                <div class="InvestAmount">
                                    <asp:TextBox ID="txt_Amount" runat="server" Style="text-align: right" ToolTip="Amount" placeholder="Amount" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="NoNeedLbl">
                                    <asp:Label ID="lbl_PF" runat="server" Text="No Need to Enter PF in Plan Details"></asp:Label>
                                </div>
                                <div class="right_btn MB05">
                                    <div class="btn ico-save">
                                        <asp:Button ID="btn_SaveInv" runat="server" Text="Save" OnClick="btn_SaveInv_Click" />
                                    </div>
                                    <div class="btn ico-cancel">
                                        <asp:Button ID="btn_cancelinv" runat="server" Text="Cancel" OnClick="btn_cancelinv_Click" Visible="false" />
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4">

                                <div class="div_Grid">
                                    <asp:GridView ID="Grd" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" 
                                        Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True"
                                        DataKeyNames="sectionid" OnSelectedIndexChanged="Grd_SelectedIndexChanged" OnRowDataBound="Grd_RowDataBound">
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="SL #" ItemStyle-Width="55px">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="seccode" HeaderText="Section" />
                                            <asp:BoundField DataField="secname" HeaderText="Detail" />
                                            <asp:BoundField DataField="investplan" HeaderText="Plan" />
                                            <asp:BoundField DataField="investamt" HeaderText="Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="Img_delete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                                        ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do U Want Delete','hid_confirm');" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="InvestYou">
                                    <asp:Label ID="Label5" runat="server" Text="You Cannot Update Investment Plan From 19'th to 1'st of The Next Month Due To Salary Process."></asp:Label>
                                </div>
                                <div class="InvestLbl1">
                                    <asp:Label ID="lbl_AvailableLimit" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="InvestLbl1">
                                    <asp:Label ID="lbl_MaxLimit" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="right_btn MT0 MB05">



                                    <div class="btn ico-view">
                                        <asp:Button ID="btn_Viewinv" runat="server" Text="View" OnClick="btn_Viewinv_Click" />
                                    </div>
                                    <div class="btn ico-send">
                                        <asp:Button ID="btn_Confirm" runat="server" Text="Confirm / Send" OnClick="btn_Confirm_Click" />
                                    </div>


                                </div>
                            </div>
                        </div>
                        <div class="Clear"></div>
                        <div class="bordertopNew1 MB05"></div>
                        <div class="Clear"></div>
                        
                    </div>
                    <div class="ProfileRight">
                        <div class="FormGroupContent4">
                        <div class="right_btn MT0 MT6">
                                <div class="btn btn-appraisal1">
                                <asp:Button ID="btnappraisal" runat="server" Text="Appraisal"  OnClick="btnappraisal_Click"/>
                            </div>
                            <div class="btn btn-itcomputation1">
                                <asp:Button ID="Button1" runat="server" Text="IT Computation" OnClick="Button1_Click" />
                            </div>
                            <div class="btn btn-claim1">
                                <asp:Button ID="btnlta" runat="server" Text="LTA Claim Details" OnClick="btnlta_Click" />
                            </div>
                            <div class="btn btn-access1">
                                <asp:Button ID="btnacc" runat="server" Text="Access Rights" OnClick="btnacc_Click" />
                            </div>
                            <div class="btn btn-log1">
                                <asp:Button ID="btnlog" runat="server" Text="Log" OnClick="btnlog_Click" />
                            </div>

                              <div class="btn btn-changepass1">
                                <asp:Button ID="btnpwd" runat="server" Text="Change password" OnClick="btnpwd_Click" />
                            </div>
                        </div>
                        </div>

                        <div class="bordertopNew1 MB05"></div>

                        <div class="widget-LBL">
                            <asp:Label ID="header" runat="server" Text="KPI DETAILS"></asp:Label>
                        </div>

                      
                            <div class="KPTEmpdrop"> <asp:DropDownList ID="cmbYearkbi" runat="server" ToolTip ="Year" data-placeholder ="Year" CssClass ="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="cmbYearkbi_SelectedIndexChanged">
        <asp:ListItem></asp:ListItem>     
        </asp:DropDownList></div>

                            <%--<div class="MonthProDrop">
                                <asp:DropDownList ID="cmb_month1" runat="server" ToolTip="Month" data-placeholder="Month" CssClass="chzn-select">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="ProYear">
                                <asp:TextBox ID="txt_fromyear1" runat="server" ToolTip="Year" placeholder="Year" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="MonthProDrop">
                                <asp:DropDownList ID="cmd_tomonth1" runat="server" ToolTip="Month" data-placeholder="Month" CssClass="chzn-select">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="ProYear">
                                <asp:TextBox ID="txt_toyear1" runat="server" ToolTip="Year" placeholder="Year" CssClass="form-control"></asp:TextBox>
                            </div>--%>
                       


                        <div class="FormGroupContent4">

                            <div class="KPTKpi">
                                <asp:TextBox ID="txt_KPI" runat="server" ToolTip="KPI" placeholder="KPI"  CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="KPTWeightage">
                                <asp:TextBox ID="txt_Weightage" runat="server" Style="text-align: right;" ToolTip="Weightage" placeholder="Weightage" CssClass="form-control" OnTextChanged="txt_Weightage_TextChanged"></asp:TextBox>
                            </div>
                            <div class="right_btn MT0 MB10">
                                <div class="btn ico-save">
                                    <asp:Button ID="btnsavekpi" runat="server" Text="Save" OnClick="btnsavekpi_Click" />
                                </div>
                                <div class="btn ico-view">
                                    <asp:Button ID="btnViewkpi" runat="server" Text="View" OnClick="btnViewkpi_Click" />
                                </div>
                                <%-- <div class="btn btn-back"> <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" Visible="false" /></div>--%>
                            </div>

                        </div>
                      
                        <div class="FormGroupContent4 MB10">

                            <div class="div_GridNew1">
                                <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader"  Width="100%" OnRowDataBound="gridview_RowDataBound1" ForeColor="Black" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
                                    <Columns>
                                       <%-- <asp:TemplateField HeaderText="SL #" ItemStyle-Width="55px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                         
                                        <asp:BoundField DataField="empid" HeaderText="Empid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                        <asp:BoundField DataField="kpiyear" HeaderText="Kpiyear" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                        <asp:BoundField DataField="kpi" HeaderText="KPI" />
                                        <asp:BoundField DataField="weightage" HeaderText="Weightage" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="kpiid" HeaderText="kpiid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="Clear"></div>
                        <div class="bordertopNew5 MB05"></div>
                        <div class="PayslipGridnew">
                            <%--<div class="LeaveLbl">Payslip</div>--%>
                            <div class="widget-LBL"><asp:Label ID="Label7" runat="server" Text="Payslip"></asp:Label></div>


                           
                                <div class="MonthProDrop">
                                    <asp:DropDownList ID="cmb_month" runat="server" ToolTip="Month" data-placeholder="Month" CssClass="chzn-select">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="ProYear">
                                    <asp:TextBox ID="txt_fromyear" runat="server" ToolTip="Year" placeholder="Year" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="MonthProDrop">
                                    <asp:DropDownList ID="cmd_tomonth" runat="server" ToolTip="Month" data-placeholder="Month" CssClass="chzn-select">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="ProYear">
                                    <asp:TextBox ID="txt_toyear" runat="server" ToolTip="Year" placeholder="Year" CssClass="form-control"></asp:TextBox>
                                </div>
                               
                                    <div class="btn ico-view">
                                        <asp:Button ID="btn_view" runat="server" Text="View" OnClick="btn_view_Click" />
                                    </div>

                        




                        </div>
                        <div class="bordertopNew1 MB05"></div>
                        <div class="Clear"></div>
                        <asp:Panel ID="Panel7" runat="server" >

                            <%--      <div class="div_total">--%>
                          

                                <div class="widget-LBL">
                                    <asp:Label ID="lblLeaveApp" runat="server" Text="Leave Application"></asp:Label>
                                </div>

                            

                            <div class="div_Break"></div>

                            <div class="FormGroupContent4">
                                <div class="displaynone">
                                    <div class="Leavecorporation">
                                        <asp:TextBox ID="txtLocation" ReadOnly="true" runat="server" placeholder="Location" ToolTip="Location" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="Leavecal" style="display: none;">
                                    <asp:TextBox ID="txtDate" runat="server" placeholder="Date" ToolTip="Date" CssClass="form-control"></asp:TextBox>
                                    <ajaxasp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate"></ajaxasp:CalendarExtender>
                                </div>

                            </div>
                            <div class="FormGroupContent4">
                                <div class="displaynone">
                                    <div class="LeaveDemo">
                                        <asp:TextBox ID="txtName" runat="server" placeholder="Name" ToolTip="Name" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="LeaveSystem">
                                        <asp:TextBox ID="txtDesgination" ReadOnly="true" runat="server" placeholder="Designation" ToolTip="Designation" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="LeaveM1">
                                        <asp:TextBox ID="txtGrade" ReadOnly="true" runat="server" placeholder="Grade" ToolTip="Grade" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="LeaveIT">
                                        <asp:TextBox ID="txtDepartment" ReadOnly="true" runat="server" placeholder="Department" ToolTip="Department" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4">
                                <div class="Leaverequired">
                                    <asp:TextBox ID="txtLeaveRequired" runat="server" placeholder="Leave Required" ToolTip="Leave Required" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtLeaveRequired_TextChanged"></asp:TextBox>
                                </div>
                                <div class="LeaveDays">
                                    <asp:DropDownList ID="ddlStatus" runat="server" Visible="false" CssClass="chzn-select">
                                        <asp:ListItem Value="">Session</asp:ListItem>
                                        <asp:ListItem Value="F">Forenoon</asp:ListItem>
                                        <asp:ListItem Value="A">Afternoon</asp:ListItem>
                                    </asp:DropDownList>


                                </div>
                                 <div class="LeaveDaysLbl">
                                    <asp:Label ID="lblDays" runat="server" Text="Days"></asp:Label>
                                </div>
                                <div class="Leavecal2">
                                    <asp:TextBox ID="txtFrom" runat="server" placeholder="From Date" ToolTip="From Date" CssClass="form-control"></asp:TextBox>
                                    <ajaxasp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFrom"></ajaxasp:CalendarExtender>
                                </div>
                                <div class="Leavecal2">
                                    <asp:TextBox ID="txtTo" runat="server" placeholder="To Date" ToolTip="To Date" CssClass="form-control"></asp:TextBox>
                                    <ajaxasp:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTo"></ajaxasp:CalendarExtender>
                                </div>
                                <div class="LeaveBoth">
                                    <asp:Label ID="lblBoth" runat="server" Text="Both Days Inclusive"></asp:Label>
                                </div>
                                  <div class="LeaveRad">
                                    <div class="Rad1">
                                        <asp:RadioButton ID="rbtEl" runat="server" Text="EL" GroupName="rbtEl" />
                                    </div>
                                    <div class="Rad2">
                                        <asp:RadioButton ID="rbtSick" runat="server" Text="SL" GroupName="rbtEl" />
                                    </div>
                                    <div class="Rad3">
                                        <asp:RadioButton ID="rbtCasual" runat="server" Text="CL" GroupName="rbtEl" />
                                    </div>


                                </div>

                            </div>


                           
                            <div class="FormGroupContent4">
                                <asp:TextBox ID="txtPurpose" runat="server" placeholder="Purpose" ToolTip="Purpose" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent4">
                                <asp:TextBox ID="txtLeaveAdd" runat="server" placeholder="Leave Address" ToolTip="Leave Address" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent4">
                                <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone" ToolTip="Phone" CssClass="form-control"></asp:TextBox>
                            </div>





                            <div class="FormGroupContent4">

                                <div class="Leaveaprove">
                                    <asp:Label ID="lblApprovedBy" runat="server" Text="Approved By"></asp:Label>
                                </div>
                                <div class="LeaveBy">
                                    <asp:TextBox ID="txtApprovedBy" runat="server" placeholder="Approved By" ToolTip="Approved By" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="LeavePrepare">
                                    <asp:TextBox ID="txtPreperedBy" runat="server" placeholder="PreperedBy" Visible="false" ToolTip="PreperedBy" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                                <div class="right_btn  MT0 MT6">
                                    <div class="btn btn-approve1">
                                        <asp:Button ID="btnApproved" runat="server" Text="Approved" OnClick="btnApproved_Click" />
                                    </div>
                                    <div class="btn btn-acd1">
                                        <asp:Button ID="btnDeclaine" runat="server" Text="Declaine" OnClick="btnDeclaine_Click" />
                                    </div>
                                    <div class="btn btn-apply1">
                                        <asp:Button ID="btnsave" runat="server" Text="Apply" OnClick="btnsave_Click" />
                                    </div>
                                    <div class="btn ico-cancel">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>




                                </div>

                           
                            <div class="bordertopNewB1"></div>
                            

                            <%--   </div>--%>
                        </asp:Panel>
                        <%--                         <div class="FormGroupContent4">
                     
                        <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do you want to Delete?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
                       
                  
         </div>
            <asp:modalpopupextender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label2">
    </asp:modalpopupextender>
    <asp:Label ID="Label6" runat="server" Text="Label" Style="display: none;"></asp:Label>--%>

                        <div class="displaynone" style="display:none;">
                            <div class="FormGroupContent4">
                                <div class="TabNormal" id="div_right" runat="server">
                                    <asp:LinkButton ID="link_right" runat="server" OnClick="link_right_Click">Rights</asp:LinkButton>
                                </div>
                                <div class="TabNormal" id="div_work" runat="server">
                                    <asp:LinkButton ID="link_work" runat="server" OnClick="link_work_Click">Works</asp:LinkButton>
                                </div>



                            </div>
                        </div>
                    </div>


                    <div class="FormGroupContent4">

                        <div class="MediClaim" style="display:none;">
                            <div class="LeaveLbl">Medical Claim Details</div>
                            <asp:Panel ID="Panel1" runat="server" class="grd">
                                <asp:GridView ID="GrdM" runat="server" AutoGenerateColumns="false" CssClass="Grid1" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="cdate" HeaderText="Data" />
                                        <asp:BoundField DataField="claimamt" HeaderText="Amount">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <div class="Permission" style="display:none;">
                            <div class="LeaveLbl">Permissions</div>
                            <asp:Panel ID="Panel5" runat="server" class="grd3">
                                <asp:GridView ID="GridPermission" runat="server" AutoGenerateColumns="true" CssClass="Grid1" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="permissiondate" HeaderText="Data" />
                                        <asp:BoundField DataField="minutes" HeaderText="minutes">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fnan" HeaderText="FN/AN">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="acfrom" HeaderText="Data" />
                        <asp:BoundField DataField="lta" HeaderText="minutes">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="lta" HeaderText="FN/AN">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>


                    </div>
                    <asp:Label ID="lbl" runat="server"></asp:Label>
                    <ajaxasp:ModalPopupExtender ID="Grd_buying_popup" runat="server" PopupControlID="pnl_Buying" BehaviorID="programmaticModalPopupBehaviordf1"
                        TargetControlID="lbl" CancelControlID="imgok" DropShadow="false">
                    </ajaxasp:ModalPopupExtender>

                    <asp:Panel ID="pnl_Buying" runat="server"  CssClass="modalPopupLTA" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="DivSecPanel">
                                <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                <div class="LTAClaim">
                                    <div class="widget-LBL">
                                    <div class="LeaveLbl" style="margin-bottom:10px;"><span>L T A Claim Details</span></div>
                                        </div>
                                    <asp:Panel ID="Panel4" runat="server" class="grd2">
                                        <asp:GridView ID="GrdL" runat="server" AutoGenerateColumns="false" CssClass="Grid1" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
                                            <Columns>
                                                <asp:BoundField DataField="cdate" HeaderText="Data" />
                                                <asp:BoundField DataField="claimamt" HeaderText="Amount">
                                                    <ItemStyle HorizontalAlign="Right" />
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
                    </asp:Panel>


                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <ajaxasp:ModalPopupExtender ID="PopNew" runat="server" PopupControlID="PPanPopUp" BehaviorID="programmaticModalPopupBehaviordf2"
                        TargetControlID="Label1" CancelControlID="Image1" DropShadow="false">
                    </ajaxasp:ModalPopupExtender>

                    <asp:Panel ID="PPanPopUp" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="DivSecPanel">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel9" runat="server" >
                                <div class="lbl_Header1">
                                    <asp:Label ID="Label2" runat="server" Text="Leave Approve Form"></asp:Label>
                                </div>
                                <div class="Break"></div>
                                <div class="div_txtApprovedOn">
                                    <asp:TextBox ID="txtApprovedon" runat="server" placeholder="Approved On" Visible="false" ToolTip="Approved On" CssClass="Text"></asp:TextBox>
                                </div>
                                <div class="Break"></div>
                                <asp:GridView ID="grd_Jobno" runat="server" AutoGenerateColumns="False" AllowPaging="false" ForeColor="Black" Width="100%"
                                    CssClass="Grid FixedHeader"  PageSize="16" Visible="true">
                                    <Columns>
                                        <asp:BoundField DataField="Empid" HeaderText="EmpId">
                                            <HeaderStyle Wrap="false" Width="65px" />
                                            <ItemStyle Wrap="false" Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fromdate" HeaderText="FromDate">
                                            <HeaderStyle Wrap="false" Width="65px" />
                                            <ItemStyle Wrap="false" Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="todate" HeaderText="ToDate" DataFormatString="{0:d}">
                                            <HeaderStyle Wrap="false" Width="65px" />
                                            <ItemStyle Wrap="false" Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="leaverequired" HeaderText="Leave Required">
                                            <HeaderStyle Wrap="false" Width="65px" />
                                            <ItemStyle Wrap="false" Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="purpose" HeaderText="Purpose">
                                            <HeaderStyle Wrap="false" Width="65px" />
                                            <ItemStyle Wrap="false" Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="session" HeaderText="Seesions" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" Width="65px" />
                                            <ItemStyle Wrap="false" Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FillDate" HeaderText="FillDate" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" Width="65px" />
                                            <ItemStyle Wrap="false" Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:DropDownList ID="ddlHead" runat="server" AutoPostBack="true" CssClass="chzn-select" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Status</asp:ListItem>
                                                    <asp:ListItem Value="1">Approved</asp:ListItem>
                                                    <asp:ListItem Value="2">Declaine</asp:ListItem>
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlFunction" runat="server" AutoPostBack="true" CssClass="chzn-select" OnSelectedIndexChanged="ddlFunction_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Options</asp:ListItem>
                                                    <asp:ListItem Value="1">Approved</asp:ListItem>
                                                    <asp:ListItem Value="2">Declaine</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Width="10%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>

                                <div class="div_btnNewLeave">
                                    <asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click" />
                                </div>
                            </asp:Panel>


                        </div>
                    </asp:Panel>




                    <div class="FormGroupContent4" style="display:none">
                        <div class="Imgdiv">
                            <asp:Image ID="img" runat="server" CssClass="div_img" />
                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_KPI" runat="server"  CssClass="modalPopupQ" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="DivSecPanelkpi">
                                <asp:Image ID="Close_KPI" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="div_Break"></div>
                            
                                <div class="widget-LBL" style="margin-bottom:10px;">
                                 <div class="LeaveLbl"><span>Access Rights</span></div>
                                    </div>
                            <asp:Panel ID="panel_right" runat="server" CssClass="Div_Profile">
                                <asp:GridView ID="GrdRights" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader"  Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="pro" HeaderText="Product" />
                                        <asp:BoundField DataField="menu" HeaderText="Menu" />
                                        <asp:BoundField DataField="screen" HeaderText="Screen">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="btnsave" HeaderText="S">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="btnview" HeaderText="V">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="btndel" HeaderText="D">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="btnupd" HeaderText="U">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                            </asp:Panel>
                        </asp:Panel>
                    </div>
                    <ajaxasp:ModalPopupExtender runat="server" ID="popup_KPI"
                        PopupControlID="pln_KPI" CancelControlID="Close_KPI" TargetControlID="Label3" DropShadow="false">
                    </ajaxasp:ModalPopupExtender>
                    <asp:Label ID="Label3" runat="server"></asp:Label>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel6" runat="server"  CssClass="modalPopupQ" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="DivSecPanelkpi">
                                <asp:Image ID="Image2" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="div_Break"></div>


                           
                                <div class="widget-LBL" style="margin-bottom:10px;">
                                 <div class="LeaveLbl"><span>LOG Details</span></div>
                                    </div>
                            <div class="bordertopNew"></div>
                                <div class="FormGroupContent4 MB10">
                                    <div class="WorkMonth">
                                        <asp:DropDownList ID="cmbyear" runat="server" ToolTip="Month" data-placeholder="Month" AutoPostBack="true" CssClass="chzn-select" OnSelectedIndexChanged="cmbyear_SelectedIndexChanged">
                                            <asp:ListItem></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="WorkYear">
                                        <asp:TextBox ID="txt_year" runat="server" ToolTip="Year" placeholder="Year" CssClass="form-control" OnTextChanged="txt_year_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="btn ico-get">
                                        <asp:Button ID="btn_get" runat="server" Text="Get" AutoPostBack="true" OnClick="btn_get_Click" />
                                    </div>

                                </div>
                             <div class="bordertopNew"></div>
                                <asp:Panel ID="panel_work" runat="server" CssClass="Div_Profilenew">
                                <asp:GridView ID="grdwork" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdwork_RowDataBound" CssClass="Grid FixedHeader"  Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="grdwork_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="SNo" HeaderText="S#" />
                                        <asp:BoundField DataField="wdetails" HeaderText="Product"></asp:BoundField>
                                        <asp:BoundField DataField="wcount" HeaderText="Count">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                                <asp:GridView ID="grddtls" runat="server" AutoGenerateColumns="true" CssClass="Grid FixedHeader"  Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                       
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                            </asp:Panel>
                        </asp:Panel>
                    </div>
                    <ajaxasp:ModalPopupExtender runat="server" ID="ModalPopupExtender1"
                        PopupControlID="Panel6" CancelControlID="Image2" TargetControlID="Label6" DropShadow="false">
                    </ajaxasp:ModalPopupExtender>
                    <asp:Label ID="Label6" runat="server"></asp:Label>


                    <asp:HiddenField ID="txtCL" runat="server" />
                    <asp:HiddenField ID="txtSL" runat="server" />
                    <asp:HiddenField ID="txtEL" runat="server" />
                    <asp:HiddenField ID="hid_Date" runat="server" />
                    <asp:HiddenField ID="hid_index" runat="server" />
                    <asp:HiddenField ID="hid_Empid" runat="server" />
                    <asp:HiddenField ID="hiddbranch" runat="server" />
                </div>

            </div>
        </div>
    </div>
    <div class="FormGroupContent4">

        <asp:Panel runat="Server" ID="Panel_Service1" CssClass="Pnl1" Style="display: none;">
            <br />
            <div style="font-size: 10pt"><b>Do you want to Delete?</b></div>
            <br />
            <div class="div_confirm">
                <asp:Button ID="btnkpiyes" runat="server" Text="Yes" CssClass="Button" OnClick="btnkpiyes_Click" />
                <asp:Button ID="btnkpino" runat="server" Text="No" CssClass="Button" OnClick="btnkpino_Click" />
            </div>
            <br />
            <div class="div_Break"></div>
        </asp:Panel>


    </div>
    <ajaxasp:ModalPopupExtender ID="PopUpService1" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service1" TargetControlID="Label2">
    </ajaxasp:ModalPopupExtender>
    <asp:Label ID="Label8" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <asp:Label ID="hid" runat="server"></asp:Label>
    <asp:HiddenField ID="hid_confirm" runat="server" />

    <asp:HiddenField ID="hid_Amount" runat="server" />
    <asp:HiddenField ID="hid_Plan" runat="server" />
    <asp:HiddenField ID="h_date" runat="server" />
    <asp:HiddenField ID="H_fromDate" runat="server" />
    <asp:HiddenField ID="H_ToDate" runat="server" />


    <asp:HiddenField ID="heid" runat="server" />
    <asp:HiddenField ID="hiddelkpi" runat="server" />

    <asp:HiddenField ID="hidfyear" runat="server" />
    <asp:HiddenField ID="hidoldcname" runat="server" />
     <asp:HiddenField ID="hidoldtage" runat="server" />
    
     <asp:HiddenField ID="hidkpiid" runat="server" />
        <asp:HiddenField ID="hid_basicamt" runat="server" />
    



</asp:Content>
