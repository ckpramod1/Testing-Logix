<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="HRPaySlip.aspx.cs" Inherits="logix.HRM.HRPaySlip" %>

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









    <link href="../Styles/HRPaySlip.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <style type ="text/css" >
      .modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        } 
          .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }     
     .modalPopupss { 
            background-color:#FFFFFF; 
            /*border-width:1px;*/ 
            border-style:solid; 
            border-color:#CCCCCC;             
            width: 1042px;
            Height:555px; 
            margin-left:-2%;
            margin-top:-1.5%;
          /*padding:1px;            
            display:none;*/
        }
     .Gridpnl   
         {            
            width: 1024px;
            Height:560px;      
         }
         .Break
         {
             clear:both;
         }
         .grd-mt
         {
              display :none;
         }
         .hide
         {
             display:none;
         }
         .SlipDrop {
    float: left;
    margin: 0 0.5% 0 0;
    width: 10%;
}
         .SlipYear1 {
    float: left;
    margin: 0 0;
    width: 4%;
}
         .SlipYear {
    float: left;
    margin: 0 0.5% 0px 0px;
    width: 8%;
}
         .SlipEmp {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        
}
         .SlipEmpcode {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
         .SlipDepart {
    width: 14%;
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

     <script type="text/javascript">
         function pageLoad(sender, args) {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }
         </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">PayRoll</a> </li>
              <li class="current">Pay Slip</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
        <div style="margin: 0px 0.5% 0px 0px; width:100%;">
      <h3><img src="../Theme/newTheme/img/payslip_ic1.png" /> <asp:Label ID="lbl_Header" runat="server" Text="PaySlip"></asp:Label></h3>
            </div>
        <div style="float: right; margin: 0px -0.5% 0px 0px; position:absolute; right:1.5%; top:47px; height: 17px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
    </div>
        <div class="Form-ControlBg">

             <div class="FormGroupContent4">
                  <div class="SlipEmp MTCtrl6"><asp:LinkButton ID="LnkEmpname" runat="server" ForeColor="#FF3300" style="text-decoration:none"  OnClick="LnkEmpname_Click">Emp Code</asp:LinkButton></div>
                  <div class="SlipEmpcode">
                      <div class="LabelWidth">Emp Code</div>
                      <div class="FieldInput"><asp:TextBox ID="txtEmpCode" runat="server" placeholder="" ToolTip="EmpCode" CssClass="form-control"  AutoPostBack="True" OnTextChanged="txtEmpCode_TextChanged"></asp:TextBox></div>
                      
                      </div>
                 <div class="SlipEmpName">
                     <div class="LabelWidth">Employee Name</div>
                     <div class="FieldInput"><asp:TextBox ID="txtEmpName" runat="server" placeholder="" ToolTip="EmpName" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                     </div>
                   <div class="SlipComp">
                       
                       <div class="LabelWidth">Company</div>
                       <div class="FieldInput"><asp:TextBox ID="txtCompany" runat="server" placeholder="" ToolTip="Company" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                       </div>
                  <div class="SlipLocation"> 
                      <div class="LabelWidth">Location</div>
                      <div class="FieldInput"><asp:TextBox ID="txtLocation" runat="server" placeholder="" ToolTip="Location" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                      
        </div>
                  <div class="SlipDesi">
                      <div class="LabelWidth">Designation</div>
                      <div class="FieldInput"><asp:TextBox ID="txtDesg" runat="server" placeholder="" ToolTip="Designation" CssClass="form-control" ReadOnly="True"></asp:TextBox> </div>
                       </div>
                  <div class="SlipDepart">
                      <div class="LabelWidth">Department</div>
                      <div class="FieldInput"><asp:TextBox ID="txtDept" runat="server" placeholder="" ToolTip="Department" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                      </div>
                  <div class="SlipGrade">
                      <div class="LabelWidth">Grade</div>
                      <div class="FieldInput"> <asp:TextBox ID="txtGrade" runat="server" placeholder="" ToolTip="Grade" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                     </div>
                  <div class="SlipDOJ">
                      <div class="LabelWidth">D.O.J</div>
                      <div class="FieldInput"> <asp:TextBox ID="txtDoj" runat="server" placeholder="" ToolTip="D.O.J" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                      
                     </div>
                  </div>
              <div class="bordertopNew MT05"></div>
              <div class="FormGroupContent4">
                  <div class="SlipDrop">
                      <div class="LabelWidth">From Month</div>
                      <div class="FieldInput"><asp:DropDownList ID="ddl_frommonth" runat="server" CssClass="chzn-select" Data-placeholder="From Month" ToolTip="From Month">       
            </asp:DropDownList></div>
                      </div>
                  <div class="SlipYear">
                      <div class="LabelWidth">From Year</div>
                      <div class="FieldInput"><asp:TextBox ID="txtfrmYear" runat="server" placeholder="" ToolTip="From Year" CssClass="form-control"></asp:TextBox></div>
                      </div>
                   <div class="SlipDrop"> 
                       <div class="LabelWidth">To Month</div>
                       <div class="FieldInput"><asp:DropDownList ID="ddl_tomonth" runat="server" CssClass="chzn-select" Data-placeholder="To Month" ToolTip="To Month">           
        </asp:DropDownList></div>
                       </div>
                   
                  <div class="SlipYear1">
                      <div class="LabelWidth">To Year</div>
                      <div class="FieldInput"><asp:TextBox ID="txtToYear" runat="server" placeholder="" ToolTip="To Year" CssClass="form-control"></asp:TextBox></div>
                      </div>
                   <div class="right_btn MTCtrl6 MB05">
                      <div class="btn ico-view"><asp:Button ID="btnView" runat="server" ToolTip="View" OnClick="btnView_Click" /></div>
                      <div class="btn ico-cancel" id="btn_back1" runat="server"> <asp:Button ID="btnBack" runat="server" ToolTip="Cancel"  OnClick="btnBack_Click" /></div>
                  </div>
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

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:ModalPopupExtender>


   
    <%--<asp:Panel ID="pln_empcode" runat="server" CssClass="div_frame" Style="display: none;">
        <div class="div_close">
            <asp:Image ID="Close_Cheque" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif" />
        </div>
        <div class="div_Break">
        </div>
        <div class="div_frame">
            <iframe id="iframeemp" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF">
            </iframe>
        </div>
    </asp:Panel>

    <asp:ModalPopupExtender runat="server" ID="popup_empcode" BehaviorID="programmaticModalPopupBehavior3"
               PopupControlID="pln_empcode" CancelControlID="Close_Cheque" TargetControlID="hid_empcode"
                BackgroundCssClass="modalBackground" DropShadow="false" RepositionMode="RepositionOnWindowScroll">
    </asp:ModalPopupExtender>
    
    <asp:Label ID="hid_empcode" runat="server" ></asp:Label>--%>

    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDoj"></asp:CalendarExtender>
    <asp:HiddenField ID="hid_eid" runat="server" />
    <asp:HiddenField ID="hid_divsid" runat="server" />
</asp:Content>
