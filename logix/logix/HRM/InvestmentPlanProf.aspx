<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="InvestmentPlanProf.aspx.cs" Inherits="logix.HRM.InvestmentPlanProf" %>
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




    <link href="../Styles/InvestmentPlanProf.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        .PlanDrop1 {
    float: right;
    margin: 0 0;
    width: 7%;
}
        .PlanLbl {
    float: right;
    margin: 0 0.5%;
    width: 28.5%;
}
        .PlanEmp {
    float: left;
    margin: 0 0.5% 0 0;
    width: 5%;
}
        .PlanName {
    float: left;
    margin: 0 0.5% 0 0;
    width: 41%;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">IT Workings</a> </li>
              <li class="current">Investment Plan Prof Received</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/investplanproofreceived_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Investment Plan Prof Received"></asp:Label>
       
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
              <div class="FormGroupContent4">
                     <div class="PlanDrop1"> 
                         <div class="LabelWidth">Year</div>
                         <div class="FieldInput"><asp:DropDownList ID="ddl_Year" runat="server"  AppendDataBoundItems="True" CssClass="chzn-select">
        </asp:DropDownList></div>
                         </div>
                  <div class="PlanLbl MTCtrl6"> 
                      
                      <asp:Label ID="lbl_Tax" runat="server" Text="Income Tax  Exemptions ( Tax Planing ) details for the Financial Year"></asp:Label></div>
               
                  </div>
               <div class="FormGroupContent4">
                   <div class="PlanEmp MTCtrl6">
                      
                      <asp:LinkButton ID="Empcode" runat="server" ForeColor="Red" style="text-decoration:none"  PostBackUrl="~/HRM/EmployeeFind.aspx">Emp Code</asp:LinkButton>
                       </div>
                   <div class="PlanEmpInput">
                       <div class="LabelWidth">Emp Code</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" AutoPostBack="True"  ToolTip="Empcode" placeholder="" CssClass="form-control" ontextchanged="txt_Empcode_TextChanged" MaxLength="4"></asp:TextBox></div>
                       </div>
                   <div class="PlanName">

                       <div class="LabelWidth">Name</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Name" runat="server" ReadOnly="True" ToolTip="Name" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="Plandrop"> 
                       <div class="LabelWidth">Company</div>
                       <div class="FieldInput"><asp:DropDownList ID="ddl_company" runat="server" data-placeholder="Company" ToolTip="Company"  CssClass="chzn-select">
                    <asp:ListItem></asp:ListItem>
        </asp:DropDownList></div>
                       </div>
                   </div>
              <div class="FormGroupContent4">
                  <div class="PlanDept">
                      <div class="LabelWidth">Dept</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_Dept" runat="server" ToolTip="Dept" placeholder="" CssClass="form-control"></asp:TextBox></div>
                      
                      </div>
                  <div class="PlanDesi">
                      <div class="LabelWidth">Desg</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_Desg" runat="server" ReadOnly="True" ToolTip="Desg" placeholder="" CssClass="form-control"></asp:TextBox></div>
                      </div>
                  <div class="PlanGrade">
                      <div class="LabelWidth">Grade</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_Grade" runat="server" ToolTip="Grade" placeholder="" CssClass="form-control"></asp:TextBox></div>
                      
                      </div>
                  <div class="PlanDoJ">
                      <div class="LabelWidth">DOJ</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_DOJ" runat="server" ToolTip="DOJ" placeholder="" CssClass="form-control"></asp:TextBox></div>
                      </div>
                  </div>
               <div class="FormGroupContent4">
                   <div class="HouseLbl">  <asp:Label ID="lbl_HouseRent" runat="server" Text="House Rent"></asp:Label></div>
                   </div>
             <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="InvestProof">
                       <div class="LabelWidth">Proof Received</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_HouseProofReceived" runat="server" AutoPostBack="True" style="text-align:right"  ToolTip="Proof Received" placeholder="" CssClass="form-control" ontextchanged="txt_HouseProofReceived_TextChanged"></asp:TextBox></div>
                       
                      </div>
                   <div class="InvestActual">
                       <div class="LabelWidth">Actual Rent</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_ActualRent" runat="server" style="text-align:right" ReadOnly="true" ToolTip="Actual Rent" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestRent">
                       <div class="LabelWidth">Rent Exemption</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_RentExp" runat="server" ReadOnly="True" style="text-align:right" ToolTip="Rent Exemption" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestHRA1">
                       <div class="LabelWidth">HRA</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_HRA" runat="server" ReadOnly="True" ToolTip="HRA" style="text-align:right" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestPerc">
                       
                       <div class="LabelWidth">50% / 40% of Basic</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Basic50" style="text-align:right" runat="server" ReadOnly="True" ToolTip="50% / 40% of Basic" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestPaid">
                       <div class="LabelWidth">Rent Paid - 10 % Of Basic</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_RentPaid" style="text-align:right" runat="server" ReadOnly="True" ToolTip="Rent Paid - 10 % Of Basic" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   </div>
                <div class="FormGroupContent4">
                   <div class="HouseLbl"><asp:Label ID="lbl_income" runat="server" Text="Income From Other Source"></asp:Label></div>
                   </div>
             <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="InvestReceive">
                       <div class="LabelWidth">Proof Received</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_IncomeProofReceived" runat="server" ToolTip="Proof Received" placeholder="" AutoPostBack="true" OnTextChanged="txt_IncomeProofReceived_TextChanged" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestHouse">
                       <div class="LabelWidth">House Rent</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_IncomeHouseRent" runat="server" style="text-align:right"  ReadOnly="True" ToolTip="House Rent" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   </div>
               <div class="FormGroupContent4">
                   <div class="HouseLbl"><asp:Label ID="lbl_Medical" runat="server" Text="Medical"></asp:Label></div>
                   </div>
            <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="InvestReceive"> 
                       <div class="LabelWidth">Proof Received</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_MedicalProofReceived" runat="server" CssClass="form-control" AutoPostBack="True"  ToolTip="Proof Received" placeholder="" ontextchanged="txt_MedicalProofReceived_TextChanged" ></asp:TextBox></div>
                       </div>
                   <div class="InvestHouse">
                       <div class="LabelWidth">Medical</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Medical" runat="server" ReadOnly="True" ToolTip="Medical" placeholder=""  CssClass="form-control"></asp:TextBox></div>
                       </div>
                   </div>
               <div class="FormGroupContent4">
                   <div class="InvestSection1"> 
                       <div class="LabelWidth">Section</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_Section" runat="server"  ReadOnly="True" ToolTip="Section" placeholder="" CssClass="form-control"></asp:TextBox></div>
                      </div>
                   <div class="InvestDetail">
                       <div class="LabelWidth">Detail</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Detail" runat="server" ReadOnly="True" ToolTip="Detail" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestPlan1">
                       
                       <div class="LabelWidth">Plan</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_PlanDetail" runat="server" ReadOnly="True" ToolTip="Plan" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       



                   </div>
                   <div class="InvestAmount1"> 
                       <div class="LabelWidth">Amount</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Amount" runat="server" style="text-align:right" ToolTip="Amount" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestDate">
                       <div class="LabelWidth">Received On</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_ReceivedOn" runat="server" style="text-align:right" ToolTip="Received On" placeholder="" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="InvestOn">
                       <div class="LabelWidth">Received On</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_ReceivedAnmt" runat="server" style="text-align:right" ToolTip="Received On" placeholder="" CssClass="form-control" ></asp:TextBox></div>
                       

                   </div>
                   <div class="btn btn-save1 MTCtrl6" id="btn_save1" runat="server">  <asp:Button ID="btn_Save" runat="server" ToolTip="Save" onclick="btn_Save_Click"  /></div>
                   </div>
               <div class="FormGroupContent4">
                   <div class="div_Grid">
        <asp:GridView ID="Grd" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
            Width="100%" ForeColor="Black"  ShowHeaderWhenEmpty="True"
            DataKeyNames="sectionid,cancel" 
            onselectedindexchanged="Grd_SelectedIndexChanged" OnRowDataBound="Grd_RowDataBound">
            <Columns>
                <asp:BoundField DataField="seccode" HeaderText="Section" />
                <asp:BoundField DataField="secname" HeaderText="Detail" />
                <asp:BoundField DataField="investplan" HeaderText="Plan" />
                <asp:BoundField DataField="investamt" HeaderText="Amount" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Cancel">
                    <ItemTemplate>
                        <asp:CheckBox ID="Chk_Cancel" runat="server" OnCheckedChanged="ChkCancel_Click" AutoPostBack="true" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:BoundField DataField="proofreceivedon" HeaderText="Received On" DataFormatString="{0:dd/MM/yyyy}"/>
                 <asp:BoundField DataField="recvamt" HeaderText="Received Amt" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                 <asp:TemplateField>
                    <ItemTemplate>
                       <asp:LinkButton ID="Lnk_Select" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
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
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"> <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" onclick="btn_cancel_Click"  /></div>
                      <div class="btn ico-view"> <asp:Button ID="btn_View" runat="server" ToolTip="View" Visible="false" /></div>
                  </div>
                   </div>

            </div>
         </div>


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Investment Plan Prof Received #</label>

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





    
    <asp:HiddenField ID="hid_Empid" runat="server" />
    <asp:HiddenField ID="hid_Amount" runat="server" />
    <asp:HiddenField ID="hid_Secid" runat="server"  />
    <asp:HiddenField ID="hid_Cancel" runat="server"  />
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_ReceivedOn">
    </asp:CalendarExtender>
</asp:Content>
