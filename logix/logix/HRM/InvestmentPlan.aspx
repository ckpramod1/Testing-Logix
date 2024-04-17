<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="InvestmentPlan.aspx.cs" Inherits="logix.HRM.InvestmentPlan" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
        .upper
        {
               text-transform: uppercase;
        }
        .Investyear {
    float: right;
    width: 8.1%;
}
        .InvestIncomeN {
    float: right;
    width: 29%;
}
        .InvestEmp {
    float: left;
    margin: 0 0.5% 0 0;
    width: 4%;
}
        .InvestDoj {
    float: left;
    margin: 0 0;
    width: 10%;
}

        .InvestActual1 {
    float: left;
    width: 12.5%;
    margin: 0px 0.5% 0px 0%;
}
        .InvestIncome {
    float: left;
    width: 20.5%;
    margin: 0px 0% 0px 0%;
}
        .InvestHRA {
    float: left;
    width: 16%;
    margin: 0px 0.5% 0px 0%;
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
             width:15%;
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

             logix_CPH_PanelLog {
             border-width: 2px;
             border-style: solid;
             position: fixed;
             z-index: 100001;
             left: 352px;
             top: 187px !important;
         }

    </style>


    <link href="../Styles/InvestmentPlan.css" rel="stylesheet" type="text/css" />
    
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>    
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  

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
          <div class="crumbs" id="crumbslabel" runat="server">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">IT Workings</a> </li>
              <li class="current">Investment Plan</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/investmentplan_ic.png" /> <asp:Label ID="lbl_Header"  runat="server" Text="Investment Plan"></asp:Label>
       
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
                <div class="FormGroupContent4">
                  
                  <div class="Investyear"> 
                      <div class="LabelWidth">Year</div>
                      <div class="FieldInput"><asp:DropDownList ID="ddl_Year" runat="server" AppendDataBoundItems="True" data-placeholder="Year" OnSelectedIndexChanged="ddl_Year_SelectedIndexChanged" CssClass="chzn-select">
             <asp:ListItem></asp:ListItem>
        </asp:DropDownList></div>
                      </div>
                  <div class="InvestIncomeN MTCtrl6"> <asp:Label ID="lbl_Tax" runat="server" Text="Income Tax  Exemptions ( Tax Planing ) details for the Financial Year"></asp:Label></div>
              </div>
               <div class="FormGroupContent4">
                   <div class="InvestEmp MTCtrl6" style="display:none;">
                       <asp:LinkButton ID="lnk_empcode" CssClass="LabelValue" runat="server" Style="text-decoration: none;" ForeColor="Black" OnClick="lnk_empcode_Click">EmpCode</asp:LinkButton></div>

                   <div class="InvestEmpcode">
                       <div class="LabelWidth">Employee Code</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Empcode" TabIndex="1" runat="server" ToolTip="Employeecode" placeholder="" CssClass="form-control" OnTextChanged="txt_Empcode_TextChanged" AutoPostBack="true" MaxLength="4"></asp:TextBox></div>
                       </div>
                   <div class="InvestEmpName">
                       <div class="LabelWidth">Employee Name</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Name" runat="server" TabIndex="2" ToolTip="EmployeeName" AutoPostBack="true" ReadOnly="true" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestCompany"> 
                       <div class="LabelWidth">Company</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Company" TabIndex="3" runat="server" ToolTip="Company" placeholder="" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestDept">
                       <div class="LabelWidth">Dept</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Dept" runat="server" TabIndex="4" ToolTip="Dept"  placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestDesi">
                       <div class="LabelWidth">Desg</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Desg" runat="server" TabIndex="5" ReadOnly="True" ToolTip="Desg" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestGrade">
                       <div class="LabelWidth">Grade</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_Grade" TabIndex="6" runat="server" ToolTip="Grade" placeholder="" CssClass="form-control"></asp:TextBox></div>
                      </div>
                   <div class="InvestDoj">
                       <div class="LabelWidth">DOJ</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_DOJ" runat="server" TabIndex="7" ToolTip="DOJ" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   </div>
               <div class="FormGroupContent4">
                   <div class="InvestActual1"> 
                       <div class="LabelWidth">Actual Rent</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_ActualRent" TabIndex="8"  runat="server" AutoPostBack="True" ontextchanged="txt_ActualRent_TextChanged" style="text-align:right;" ToolTip="Actual Rent" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       
                      </div>
                   <div class="InvesrRent">
                       
                       <div class="LabelWidth">Rent Exemption</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_RentExp" TabIndex="9" runat="server"  ToolTip="Rent Exemption" placeholder="" style="text-align:right; color:red" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestHRA"> 
                       <div class="LabelWidth">HRA</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_HRA" runat="server" TabIndex="10" ToolTip="HRA" placeholder="" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                       
                       </div>
                   <div class="InvestBasic">
                       <div class="LabelWidth">50%/40% of Basic</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Basic50" runat="server" TabIndex="11" ToolTip="50%/40% of Basic" placeholder="" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestPaid1"> 
                       <div class="LabelWidth">RentPaid - 10% OfBasic</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_RentPaid" runat="server" TabIndex="12" ToolTip="RentPaid - 10 % OfBasic" style="text-align:right;" placeholder=""  CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestIncome">
                       <div class="LabelWidth">Income From Other Source - RentReceived Rs.</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Income" runat="server" TabIndex="13"  style="text-align:right;" ToolTip="Income From Other Source - RentReceived Rs." placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   </div>
              <div><hr /></div>
               <div class="FormGroupContent4">
                   <div class="JobName"><asp:LinkButton ID="lnk_section" TabIndex="14" runat="server" ForeColor="#FF3300" style="text-decoration:none" OnClick="lnk_section_Click">Section</asp:LinkButton></div>
                   <div class="InvestSection"> 
                       <div class="LabelWidth">Section</div>
                       <div class="FieldInput"> <asp:DropDownList ID="ddl_Section" TabIndex="15" runat="server"  AppendDataBoundItems="True" ToolTip="Section"  data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true"
             OnSelectedIndexChanged="ddl_Section_SelectedIndexChanged">
            <asp:ListItem Text="" Value="0"></asp:ListItem>
        </asp:DropDownList></div>
                       
                      </div>
                   <div class="InvestDetails"> 
                       <div class="LabelWidth">Details</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Detail" runat="server" TabIndex="16" ToolTip="Details" placeholder="" CssClass="form-control" AutoPostBack="true"></asp:TextBox></div>
                       </div>
                   <div class="InvestPlan"><%--<asp:TextBox ID="txt_PlanDetail" runat="server" TabIndex="17" ToolTip="Plan Details" placeholder="Plan Details" CssClass="form-control"></asp:TextBox>--%>
                         
                       <div class="LabelWidth">Plan Details</div>
                       <div class="FieldInput"><asp:DropDownList ID="ddl_plan" runat="server" AppendDataBoundItems="True" ToolTip="Plan Details" data-placeholder="Plan Details" CssClass="chzn-select" AutoPostBack="true">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList></div>
                       

                   </div>
                   <div class="InvestAmount">
                       <div class="LabelWidth">Amount</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Amount" runat="server" TabIndex="18" style="text-align:right" ToolTip="Amount"  placeholder="" CssClass="form-control"></asp:TextBox></div>
                        
                       </div>
                   <div class="right_btn MTCtrl6 MB05">
                       <div class="btn ico-add" id="btn_add2" runat="server"> <asp:Button ID="btn_Save" TabIndex="19" runat="server" ToolTip="Add" onclick="btn_Save_Click" /></div>
                   </div>
                   </div>
                <div class="FormGroupContent4">
                    <div class="NoNeedLbl"><asp:Label ID="lbl_PF" TabIndex="20" runat="server" Text="No Need to Enter PF in Plan Details"></asp:Label></div>
                    <div class="div_Grid">
        <asp:GridView ID="Grd" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
            Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True"
            DataKeyNames="sectionid" onselectedindexchanged="Grd_SelectedIndexChanged" OnRowDataBound="Grd_RowDataBound">
            <Columns>
                <asp:BoundField DataField="seccode" HeaderText="Section" />
                <asp:BoundField DataField="secname" HeaderText="Detail" />
                <asp:BoundField DataField="investplan" HeaderText="Plan" ItemStyle-CssClass="upper"/>
                <asp:BoundField DataField="investamt" HeaderText="Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"  >
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
                  <div class="InvestYou"><asp:Label ID="lbl" runat="server" Text="You Cannot Update Investment Plan From 19'th to 1'st of The Next Month Due To Salary Process."></asp:Label></div>
                  <div class="InvestLbl1">
                       <asp:Label ID="lbl_AvailableLimit" runat="server" Text=""></asp:Label>
                  </div>
                   <div class="InvestLbl1">
                        <asp:Label ID="lbl_MaxLimit" runat="server" Text=""></asp:Label>
                       </div>
                  <div class="right_btn MT0 MB05">
                       
       
        
                      <div class="btn ico-view"><asp:Button ID="btn_View" runat="server" ToolTip="View" onclick="btn_View_Click" /></div>
                      <div class="btn ico-send"> <asp:Button ID="btn_Confirm" runat="server" ToolTip="Confirm" onclick="btn_Confirm_Click" /></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" onclick="btn_cancel_Click" /></div>

                  </div>
              </div>
            </div>




  


       

    <asp:Panel ID="pln_Emp" runat="server" class="div_frame" Style="display: none;">
        <div class="div_close">
            <asp:Image ID="Close_Emp" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif" />
        </div>
        <div class="div_Break">
        </div>
        <div class="div_frame">
            <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF">
            </iframe>
        </div>
    </asp:Panel>


    <asp:ModalPopupExtender ID="Popup_Emp" runat="server" PopupControlID="pln_Emp" BackgroundCssClass="modalBackgroundjob"
        CancelControlID="Close_Emp" TargetControlID="hid">
    </asp:ModalPopupExtender>

         <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Investment Plan #</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

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
                   


     <asp:Label ID="Label3" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label3" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:Label ID="hid" runat="server"></asp:Label>
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hid_Empid" runat="server" />
    <asp:HiddenField ID="hid_Amount" runat="server" />
    <asp:HiddenField ID="hid_Plan" runat="server" />
    <asp:HiddenField ID="h_date" runat="server" />
    <asp:HiddenField ID="H_fromDate" runat="server" />
    <asp:HiddenField ID="H_ToDate" runat="server" />
       <asp:HiddenField ID="hid_year" runat="server" />
        <div class="div_Break"></div>

</asp:Content>
