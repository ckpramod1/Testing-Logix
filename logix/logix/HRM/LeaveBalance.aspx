<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="LeaveBalance.aspx.cs" Inherits="logix.HRM.LeaveBalance" %>

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
     <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
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

    <style type="text/css">
        .AttendanceEmp {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .AttendanceEmpBr {
         width: 15%;
         float: left;
         margin: 0px 0.5% 0px 0px;
}
        
        .AttendanceEmpDes {
             width: 15%;
         float: left;
         margin: 0px 0.5% 0px 0px;

        }

        .AttendanceEmpDivN {
             width: 15%;
         float: left;
         margin: 0px 0.5% 0px 0px;
        }



        .AttendanceEmpN {
            width:22%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }

        .AttendanceEmpDN {
             width:25.5%;
            float:left;
            margin:0px 0% 0px 0px;
        }

        .AttendanceCl {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .AttendanceSL {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .AttendanceEL {
    width: 5%;
    float: left;
    margin: 0px 0% 0px 0px;
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


    <link href="../Styles/LeaveBalance.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">HRM</a> </li>
              <li class="current">Leave Balance</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/leavebalance_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Leave Balance"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">  

            <div class="FormGroupContent4">

                  <div class="LeaveBalancetxt"><asp:Label ID="lbl_Title" runat="server" Text=""></asp:Label></div>



                  </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="AttendanceEmp"> 
                       
                       <div class="LabelWidth">Emp Code</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_Empcode" runat="server" placeholder="" ToolTip="EmpCode" CssClass="form-control"  AutoPostBack="True"
                OnTextChanged="txt_Empcode_TextChanged" TabIndex="1" MaxLength="4"></asp:TextBox></div>
                      </div>
                   <div class="AttendanceEmpN"> 
                       <div class="LabelWidth">Emp Name</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_EmpName" runat="server" placeholder="" ToolTip="EmpName" CssClass="form-control" ReadOnly="True" TabIndex="2"></asp:TextBox></div>
                      </div>
                         <div class="AttendanceEmpBr">
                         <div class="LabelWidth">Branch</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_location" runat="server" placeholder="" ToolTip="Branch" CssClass="form-control"  ReadOnly="True" TabIndex="3"></asp:TextBox></div>
                         </div>
                   <div class="AttendanceEmpDivN">
                       
                       <div class="LabelWidth">Division</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_division" runat="server" placeholder="" ToolTip="Division" CssClass="form-control"  ReadOnly="True" TabIndex="4"></asp:TextBox></div>
                       </div>
                        <div class="AttendanceEmpDes"> 
                         <div class="LabelWidth">Designation</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_designation" runat="server" placeholder="" ToolTip="Designation" CssClass="form-control" ReadOnly="True" TabIndex="5"></asp:TextBox></div>
                         
                         </div>
                   <div class="AttendanceEmpDN">
                       
                       <div class="LabelWidth">Department</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_dept" runat="server"  placeholder="" ToolTip="Department" CssClass="form-control" ReadOnly="True" TabIndex="6"></asp:TextBox></div>

                       </div>
                   </div>
             
              
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="AttendanceCl">
                       <div class="LabelWidth">CL</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_CL" runat="server" placeholder="" ToolTip="CL" CssClass="form-control" TabIndex="7"></asp:TextBox></div>
                       </div>
                   <div class="AttendanceSL">
                       <div class="LabelWidth">SL</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_SL" runat="server" placeholder="" ToolTip="SL" CssClass="form-control" TabIndex="8"></asp:TextBox></div>
                       </div>
                   <div class="AttendanceEL"> 
                       <div class="LabelWidth">EL</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_EL" runat="server" placeholder="" ToolTip="EL" CssClass="form-control" TabIndex="9"></asp:TextBox></div>
                       
                       
                       </div>
                   <div class="right_btn MB05 MTCtrl6">
                       <div class="btn ico-save" id="btn_save1" runat="server"><asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" /></div>

                       <div class="btn ico-cancel" id="btn_cancel1" runat="server"> <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" /></div>

                   </div>
                   </div>

            </div>
         </div>









       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i></h4>
                </div>
          <div class="widget-content">
              
              </div>
         </div>
            </div>
           </div>


     <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Leave Balance #</label>

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
</asp:Content>
