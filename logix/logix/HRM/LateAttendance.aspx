<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="LateAttendance.aspx.cs" Inherits="logix.HRM.LateAttendance" %>

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







    <link href="../Styles/LateAttendance.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
     <style type="text/css">
     

        modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
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
            margin-top:-2.5%;
          /*padding:1px;            
            display:none;*/
        }

       .Gridpnl   
         {            
            width: 1024px;
            Height:560px;      
         }
       .size
       {
            text-transform: uppercase;
       }
       .LateYear {
    float: left;
    margin: 0 0.5% 0 0;
    width: 14%;
}
       .LateNO {
    float: left;
    margin: 0 0 0 0;
    width: 54%;
}
       .LateEmp {
    float: left;
    margin: 0 0.5% 0 0;
    width: 4.5%;
}
       .LateEmpCode {
    float: left;
    margin: 0 0.5% 0 0;
    width: 5%;
}

       .LateName {
    width: 22.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
       .LateDOJ {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
       .LateLocation {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
       .LateDept {
    width: 15%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
       .Latedesi {
    width: 28%;
    float: left;
    margin: 0px 0% 0px 0px;
}
       .LateEL {
    width: 22%;
    float: left;
    margin: 0px 0.5% 0% 0px;
}

         .LateELM {
             width:31%;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LateCL {
    width: 22%;
    float: left;
    margin: 0px 0.5% 0% 0px;
}
         .LateSL {
    width: 22%;
    float: left;
    margin: 0px 0% 0% 0px;
}
        
         .Lateleft {
    width: 24.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.LateRight {
    width: 24.5%;
    float: left;
    margin: 0px 0.5% 0% 0px;
}
         .LateRemarks {
             float:left; 
             width:50%;
             margin:0px 0px 0px 0px;
         }


         .MTCtrl29 {
             margin-top: 29px !important;
         }
.div_Grid {
    width: 49.5%;
    float: left;
    margin-left: 0%;
    margin-top: 0%;
    height: 150px;
    border: 1px solid #b1b1b1;
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
              <li><a href="#" title="">HRM</a> </li>
              <li class="current">Late Attendance</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

    <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/lateattendance_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Late Attendance"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">  
             <div class="FormGroupContent4">
               <div class="LateEmp"> 
                   <div class="LabelWidth MTCtrl6">
                       <asp:LinkButton ID="lnk_empcode" runat="server" Style="text-decoration: none;" OnClick="lnk_empcode_Click">EmpCode</asp:LinkButton>
                   
                   </div>
                   
                   </div>

               <div class="LateEmpCode"> 
                   <div class="LabelWidth">Emp Code</div>
                   <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" placeholder="" ToolTip="EmpCode" CssClass="form-control" AutoPostBack="True"
                OnTextChanged="txt_Empcode_TextChanged" TabIndex="1" MaxLength="4"></asp:TextBox></div>

                   </div>
               <div class="LateName">
                   <div class="LabelWidth">Name</div>
                   <div class="FieldInput">  <asp:TextBox ID="txt_EmpName" runat="server" placeholder="" ToolTip="Name" CssClass="form-control"  ReadOnly="True" TabIndex="2"></asp:TextBox></div>
                  </div>
               <div class="LateDOJ"> 
                   <div class="LabelWidth">DOJ</div>
                   <div class="FieldInput"> <asp:TextBox ID="txt_doj" runat="server" placeholder="" ToolTip="DOJ" CssClass="form-control" ReadOnly="True" TabIndex="3"></asp:TextBox></div>
                  </div>
                  <div class="LateLocation">
                       <div class="LabelWidth">Location</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_locatiom" runat="server" placeholder="" ToolTip="Location" CssClass="form-control" ReadOnly="True" TabIndex="4"></asp:TextBox></div>
                       </div>
                   <div class="LateDept">
                       <div class="LabelWidth">Dept</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_dept" runat="server" placeholder="" ToolTip="Dept" CssClass="form-control" ReadOnly="True" TabIndex="5"></asp:TextBox></div>
                       </div>
                   <div class="Latedesi">
                       <div class="LabelWidth">Desg</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_desg" runat="server" placeholder="" ToolTip="Desg" CssClass="form-control"  ReadOnly="True" TabIndex="6"></asp:TextBox></div>
                       
                      </div>
           </div>
               <div class="FormGroupContent4">
                  
                   </div>
              <div class="Lateleft">
                  <div class="FormGroupContent4">
                      <div class="LeaveLBL1"> <asp:Label ID="lbl_leavebalance" runat="server" Text="Leave Balance"></asp:Label></div>
                      

                  </div>
                  <div class="FormGroupContent4">
                      <div class="LateEL">
                          <div class="LabelWidth">EL</div>
                          <div class="FieldInput"><asp:TextBox ID="txt_EL" runat="server" placeholder="" ToolTip="EL" CssClass="form-control"  ReadOnly="True" TabIndex="7"></asp:TextBox></div>
                          </div>
                      <div class="LateCL">
                          <div class="LabelWidth">CL</div>
                          <div class="FieldInput"><asp:TextBox ID="txt_CL" runat="server" placeholder="" ToolTip="CL" CssClass="form-control" ReadOnly="True" TabIndex="8"></asp:TextBox></div>
                          </div>
                      <div class="LateSL"> 
                          <div class="LabelWidth">SL</div>
                          <div class="FieldInput"> <asp:TextBox ID="txt_SL" runat="server" placeholder="" ToolTip="SL" CssClass="form-control" ReadOnly="True" TabIndex="9"></asp:TextBox></div>
                         </div>

                  </div>

              </div>
              <div class="LateRight">
                  <div class="FormGroupContent4">
                      <div class="LeaveLBL1"> <asp:Label ID="lbl_lateattendance" runat="server" Text="Late Attendance"></asp:Label></div>
                     
                     

                  </div>

                  <div class="FormGroupContent4">
                       <div class="LateELM">
                           <div class="LabelWidth">Month</div>
                           <div class="FieldInput"><asp:DropDownList ID="ddl_Monrh" runat="server" CssClass="chzn-select" data-placeholder="Month" ToolTip="Month" TabIndex="10" >
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="1">JANUARY</asp:ListItem>
                <asp:ListItem Value="2">FEBRUARY</asp:ListItem>
                <asp:ListItem Value="3">MARCH</asp:ListItem>
                <asp:ListItem Value="4">APRIL</asp:ListItem>
                <asp:ListItem Value="5">MAY</asp:ListItem>
                <asp:ListItem Value="6">JUNE</asp:ListItem>
                <asp:ListItem Value="7">JULY</asp:ListItem>
                <asp:ListItem Value="8">AUGUST</asp:ListItem>
                <asp:ListItem Value="9">SEPTEMBER</asp:ListItem>
                <asp:ListItem Value="10">OCTOBER</asp:ListItem>
                <asp:ListItem Value="11">NOVEMBER</asp:ListItem>
                <asp:ListItem Value="12">DECEMBER</asp:ListItem>
            </asp:DropDownList></div>
                           </div>
                       <div class="LateYear"> 
                           <div class="LabelWidth">Year</div>
                           <div class="FieldInput"><asp:TextBox ID="txt_year" runat="server" placeholder="" ToolTip="Year" CssClass="form-control" MaxLength="4" TabIndex="11"></asp:TextBox></div>
                           </div>
                      <div class="LateNO">
                          <div class="LabelWidth">No of Days to be Deducted</div>
                          <div class="FieldInput"><asp:TextBox ID="txt_day" runat="server" placeholder="" ToolTip="No of Days to be Deducted" CssClass="form-control" TabIndex="12"></asp:TextBox></div>
                          </div>
                       

                  </div>
              </div>
            <div class="LateRemarks MTCtrl29">
                 <div class="LabelWidth">Remarks</div>
                   <div class="FieldInput"><asp:TextBox ID="txt_remark" runat="server" placeholder="" ToolTip="Remarks" CssClass="form-control" TabIndex="13"></asp:TextBox></div>
            </div>
              
              <div class="FormGroupContent4">
                  <div class="right_btn MT0">
                      <div class="btn ico-save" id="btn_save1" runat="server">  <asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" TabIndex="14" /></div>
                      <div class="btn ico-view"><asp:Button ID="btn_view" runat="server" ToolTip="View"  OnClick="btn_view_Click" TabIndex="15" /></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"> <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="16" /></div>
                  </div>
                   </div>
               <div class="FormGroupContent4">
                   <div class="div_Grid">
            <asp:GridView ID="Grd_Late" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                DataKeyNames="empcode,lateattn" Width="100%" ForeColor="Black" 
                ShowHeaderWhenEmpty="True"
                OnSelectedIndexChanged="Grd_Late_SelectedIndexChanged" OnRowDataBound="Grd_Late_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="month" HeaderText="Month" />
                    <asp:BoundField DataField="year" HeaderText="Year" />
                    <asp:BoundField DataField="noofdeduct" HeaderText="No of Deduction" />
                    <asp:BoundField DataField="remarks" HeaderText="Remarks" ItemStyle-CssClass="size" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do You Want Delete','hid_confirm');" />
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

            </div>
        </div>









       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> </h4>
                </div>
          <div class="widget-content">
          
              </div>
         </div>
            </div>
           </div>









   
        <asp:Panel ID="pln_Emp" runat="server" class="div_frame" CssClass="modalPopup" Style="display: none;">
            <div class="div_close">
                <asp:Image ID="Close_Emp" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif" />
            </div>
            <div class="div_Break">
            </div>
            <div class="div_frame">
                <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF"></iframe>
            </div>
        </asp:Panel>
  
   <%-- <asp:ModalPopupExtender ID="Popup_Emp" runat="server" PopupControlID="pln_Emp" BackgroundCssClass="modalBackgroundjob"
        CancelControlID="Close_Emp" TargetControlID="Label1">
    </asp:ModalPopupExtender>
     <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>--%>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Late Attendance #</label>

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

    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hid_id" runat="server" />
    <asp:HiddenField ID="hid" runat="server" />
</asp:Content>
