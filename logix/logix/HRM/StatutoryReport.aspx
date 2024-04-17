<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="StatutoryReport.aspx.cs" Inherits="logix.HRM.StatutoryReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css"/>
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
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
        .StautRad {
            width: 14.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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
                margin: 30px 0px 2px 10px;
                font-size: 11px;
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
            font-family: sans-serif;
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
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

             .LogHeadLbl {
             width:65%;
             float:left;
             margin:2px 0px 3px 4px;

         }

         .LogHeadLbl label
         {
             color:#af2b1a;
             font-weight:bold;
             font-size:12px;
         }



         .LogHeadJob {
             width:auto;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LogHeadJobInput label {
             font-size:12px;
             
            
         }


           .LogHeadJobInput {
             width:auto;
             white-space:nowrap;
             float:left;
             margin:1px 0.5% 0px 0px;
         }

             .LogHeadJobInput span {
                 color:#1a65af;
                 font-size:12px;
                 margin:4px 0px 0px 0px;
             }




             .LogHeadJobInput label {
                 font-size:12px;
                 font-family:sans-serif;
                 color:#4e4e4c;
             }

               logix_CPH_PanelLog
             {
                 top:155px!important;
             }

    </style>




    <link href="../Styles/StatutoryReport.css" rel="stylesheet" type="text/css" />
     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
     <script type="text/javascript">
         function pageLoad(sender, args) {
             $(document).ready(function () {
                 $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
             });

                 
             }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">



     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">Report</a> </li>
              <li class="current">Statutory Report</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div class="FormBg">
    <div class="FormHead">
        <div style="margin: 0px 0.5% 0px 0px; width:100%;">
      <h3><img src="../Theme/newTheme/img/statutoryreport_ic.png" /><asp:Label ID="lbl_Header" runat="server" Text="Statutory Report"></asp:Label></asp:Label></h3>
       </div>
             <div style="float: right; margin: 0px -0.5% 0px 0px; position:absolute; right:1.5%; top:47px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
    </div>
        <div class="Form-ControlBg">
                     <div class="FormGroupContent4">
                  <div class="StatCompany">
                      
                      <div class="LabelWidth">Company Name</div>
                      <div class="FieldInput"></div>
                      
                      <asp:DropDownList ID="ddl_company" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" data-placeholder="Company Name" ToolTip="Company Name">
        <asp:ListItem Value="0" Text=""></asp:ListItem>
         </asp:DropDownList></div>
                  <div class="StautFrom"> 
                      <div class="LabelWidth">From Month</div>
                      <div class="FieldInput"><asp:DropDownList ID="ddl_From" runat="server" CssClass="chzn-select" AppendDataBoundItems="True" Data-placeholder="" ToolTip="From Month">
         <asp:ListItem Value="0" Text=""></asp:ListItem>
            
        </asp:DropDownList></div>
                      </div>
                  <div class="StautYear">
                      <div class="LabelWidth">From Year</div>

                       <div class="FieldInput"><asp:TextBox ID="txt_From" runat="server" MaxLength="4" CssClass="form-control" placeholder="" ToolTip="From Year"></asp:TextBox></div>
                                      
                      
                      </div>
                          <div class="StautTo">
                              <div class="LabelWidth">To Month</div>
                              <div class="FieldInput"><asp:DropDownList ID="ddl_To" runat="server" CssClass="chzn-select" AppendDataBoundItems="True" Data-placeholder="To Month" ToolTip="To Month">
         <asp:ListItem Value="0" Text=""></asp:ListItem>             
        </asp:DropDownList></div>
                              </div> 
                  <div class="StautToYr"> 
                      <div class="LabelWidth">To Year</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_To" runat="server" MaxLength="4" CssClass="form-control" placeholder="" ToolTip="To Year"></asp:TextBox></div>
                      </div>
                  </div>
              <div class="bordertopNew MT05"></div>
               <div class="FormGroupContent4 MARginCtrlW">
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_Attendance" runat="server" Text="Attendance" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Attendance_CheckedChanged" /></div>
                   <div class="StautRad">
                        <asp:RadioButton ID="Rbt_CTC" runat="server" Text="CTC" GroupName="Rpt" 
            AutoPostBack="True" oncheckedchanged="Rbt_CTC_CheckedChanged" />
                       </div>
                   <div class="StautRad1"><asp:RadioButton ID="Rbt_SalarySummary" runat="server" Text="Salary Summary" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_SalarySummary_CheckedChanged" /></div>
                  
                  
                    <div class="StautRad">  <asp:RadioButton ID="Rbt_SalarySheet" runat="server" Text="Salary Sheet" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_SalarySheet_CheckedChanged" /></div>
                    <div class="StautRad1"> <asp:RadioButton ID="Rbt_LoPDays" runat="server" Text="LoP Days" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_LoPDays_CheckedChanged" /></div>
                   </div>
               <div class="bordertopNew MT05"></div>
               <div class="FormGroupContent4 MARginCtrlW">
                   <div class="StatusLBL"> <asp:Label ID="lbl_Esi" runat="server" Text="ESI"></asp:Label></div>
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_Monthly" runat="server" Text="Monthly" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Monthly_CheckedChanged" /></div>
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_ESIC" runat="server" Text="ESIC" GroupName="Rpt" 
            AutoPostBack="True" oncheckedchanged="Rbt_ESIC_CheckedChanged" /></div>
                   <div class="StautRad1"> <asp:RadioButton ID="Rbt_Form3" runat="server" Text="Form 3" GroupName="Rpt" 
            AutoPostBack="True" oncheckedchanged="Rbt_Form3_CheckedChanged" /></div>
                  
                    <div class="StautRad"> <asp:RadioButton ID="Rbt_Form5" runat="server" Text="Form 5" GroupName="Rpt" 
            AutoPostBack="True" oncheckedchanged="Rbt_Form5_CheckedChanged" /></div>
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_Form7" runat="server" Text="Form 7" GroupName="Rpt" 
            AutoPostBack="True" oncheckedchanged="Rbt_Form7_CheckedChanged" /></div>
                    <div class="StautRad1"> <asp:RadioButton ID="Rbt_Challan12" runat="server" Text="Challan-12" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Challan12_CheckedChanged" /></div>

                   </div>
               <div class="bordertopNew MT05"></div>
              <div class="FormGroupContent4 MARginCtrlW">
                  <div class="StatusLBL"><asp:Label ID="lbl_PF" runat="server" Text="PF"></asp:Label></div>
                  <div class="StautRad"> <asp:RadioButton ID="Rbt_Monthly_PF" runat="server" Text="Monthly" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Monthly_PF_CheckedChanged" /></div>
                    <div class="StautRad"> <asp:RadioButton ID="Rbt_NewMonthly" runat="server" Text="New Monthly" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_NewMonthly_CheckedChanged" /></div>
                   <div class="StautRad1"> <asp:RadioButton ID="Rbt_Form3A" runat="server" Text="Form 3A" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Form3A_CheckedChanged" /></div>
                  
                  <div class="StautRad"> <asp:RadioButton ID="Rbt_Form5_PF" runat="server" Text="Form 5" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Form5_PF_CheckedChanged" /></div>
                  <div class="StautRad">
                      <asp:RadioButton ID="Rbt_Form6A" runat="server" Text="Form 6A" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Form6A_CheckedChanged" />
                      </div>
                  <div class="StautRad1">
                      <asp:RadioButton ID="Rbt_Form9" runat="server" Text="Form 9" GroupName="Rpt"
                          AutoPostBack="True" OnCheckedChanged="Rbt_Form9_CheckedChanged" />
                  </div>
                 
                    <div class="StautRad">
                         <asp:RadioButton ID="Rbt_Form10" runat="server" Text="Form 10" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Form10_CheckedChanged" />
                        </div>
                    <div class="StautRad">
                        <asp:RadioButton ID="Rbt_Form12A" runat="server" Text="Form 12A" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Form12A_CheckedChanged" />
                        </div>
                    <div class="StautRad">
                         <asp:RadioButton ID="Rbt_EPF" runat="server" Text="EPF" GroupName="Rpt" 
            AutoPostBack="True" oncheckedchanged="Rbt_EPF_CheckedChanged" />
                        </div>
                 
                  <div class="StautRad">
                       <asp:RadioButton ID="Rbt_Deduction" runat="server" Text="Deduction Statement" 
            GroupName="Rpt" AutoPostBack="True" 
            oncheckedchanged="Rbt_Deduction_CheckedChanged" />
                  </div>
                   </div>
               <div class="bordertopNew MT05"></div>
              <div class="FormGroupContent4 MARginCtrlW">
                  <div class="StatusLBL"> <asp:Label ID="lbl_Tax" runat="server" Text="Tax"></asp:Label></div>
                  <div class="StautRad">
                      <asp:RadioButton ID="Rbt_PT" runat="server" Text="PT" GroupName="Rpt" AutoPostBack="True" oncheckedchanged="Rbt_PT_CheckedChanged" />
                      </div>
                    <div class="StautRad">
                          <asp:RadioButton ID="Rbt_Form16" runat="server" Text="Form16" GroupName="Rpt" AutoPostBack="True" OnCheckedChanged="Rbt_Form16_CheckedChanged" />
                      </div>
                    <div class="StautRad">
                        <asp:RadioButton ID="Rbt_Form16nonit" runat="server" Text="Form16 Non-IT" GroupName="Rpt" AutoPostBack="True" OnCheckedChanged="Rbt_Form16nonit_CheckedChanged" 
            />
                      </div>
                    <div class="StautRad1">
                         <asp:RadioButton ID="Rbt_24Q" runat="server" Text="24Q" GroupName="Rpt" AutoPostBack="True" OnCheckedChanged="Rbt_24Q_CheckedChanged" 
            />
                      </div>
                   </div>
               <div class="bordertopNew MT05"></div>
              <div class="FormGroupContent4 MARginCtrlW">
                  <div class="StatusLBL"><asp:Label ID="lbl_bonus" runat="server" Text="Bonus"></asp:Label></div>
                  <div class="StautRad"> <asp:RadioButton ID="Rbt_Bonus" runat="server" Text="Bonus" AutoPostBack="True" 
            GroupName="Rpt" oncheckedchanged="Rbt_Bonus_CheckedChanged" /></div>
                  <div class="StautFinance"> <asp:Label ID="lbl_FYyear" runat="server" Text="Financial Year"></asp:Label></div>
                  <div class="FinanceDrop">  <asp:DropDownList ID="ddl_FYyear" runat="server" CssClass="chzn-select" data-placeholder="Financial Year" ToolTip="Financial Year" >
            <asp:ListItem Value="0" Text=""></asp:ListItem>
        </asp:DropDownList></div>
                  <div class="right_btn MT0 MB05"> 
                      <div class="btn ico-view"> <asp:Button ID="btn_View" runat="server" ToolTip="View" onclick="btn_View_Click" /></div>
                     <div class="btn ico-cancel" id="btn_Clear1" runat="server" ><asp:Button ID="btn_Clear" runat="server" ToolTip="Cancel" OnClick="btn_Clear_Click"  /></div>
        </div>
                   </div>
            </div>
          





    <div id="PanelLog1" runat="server">
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl" runat="server">Customer Name:</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
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
                </div>


     <asp:Label ID="Label4" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>






</asp:Content>
