<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="IncentiveDetails.aspx.cs" Inherits="logix.HRM.IncentiveDetails" %>

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
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
     <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />

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








    <link href="../Styles/IncentiveDetails.css" rel="stylesheet" type="text/css" />
      <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
        <link href="../Styles/GridviewScroll.css" rel="stylesheet" />   
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />  
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script> 
       <link href="../Styles/GridviewScroll.css" rel="stylesheet" /> 
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" /> 

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
         .IncEmpcode {
    float: left;
    margin: 0 0.5% 0 0;
    width: 4.5%;
}
         .INcEmpInput {
    float: left;
    margin: 0 0.5% 0 0;
    width: 7.5%;
}
         .IncEmpName {
    float: left;
    margin: 0 0.5% 0 0;
    width: 25%;
}
         .Inccomp {
    float: left;
    margin: 0 0.5% 0 0;
    width: 24%;
}
         .InGrade {
    float: left;
    margin: 0 0.5% 0 0;
    width: 5%;
}
         .InDate {
    float: left;
    width: 13%;
    margin: 3px 0.5% 0px 0px;
}
         .InDatecal {
    float: right;
    width: 45%;
    margin: 0px 0.5% 0px 0px;
}
         .InDesi {
    float: left;
    width: 31.5%;
    margin: 0px 0% 0px 0px;
}
         .InTDS {
    float: left;
    width: 9%;
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
    
     <script type="text/javascript" language="javascript">

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
              <li><a href="#" title="">Payroll</a> </li>
              <li class="current"> Incentive Details </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/incentivedetails_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Incentive Details"></asp:Label>
        
           <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
            <div class="FormGroupContent4">
                  <div class="right_btn MT0">
                      
                     
                      <div class="btn ico-get" style="float:right; margin:17px 0px 0px 5px;"><asp:Button ID="btn_Get" runat="server" ToolTip="Get" onclick="btn_Get_Click" /></div>
                       <div class="InDatecal">
                           <div class="LabelWidth"><div class="InDate"><asp:Label ID="lbl_Date" runat="server" Text="Date"></asp:Label></div>
                               <div class="FieldInput"><asp:TextBox ID="txt_date" runat="server" CssClass="form-control"></asp:TextBox></div>
                           </div>
                      </div>
                      
                  </div>
                  </div>
                
             <div class="FormGroupContent4">
                 <div class="IncEmpcode MTCtrl6">  <asp:LinkButton ID="lnk_empcode" runat="server" TabIndex="1" Style="text-decoration: none;" ForeColor="Red" onclick="lnk_empcode_Click">EmpCode</asp:LinkButton></div>
                 <div class="INcEmpInput"> 
                     <div class="LabelWidth">Employee Code</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" TabIndex="2"  AutoPostBack="True" CssClass="form-control" PlaceHolder="" ToolTip="Employeecode" BorderColor="#999997"
            ontextchanged="txt_Empcode_TextChanged"></asp:TextBox></div>
                     </div>
                 <div class="IncEmpName">
                     <div class="LabelWidth">Employee Name</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" TabIndex="3" PlaceHolder="" ToolTip="EmployeeName" ReadOnly="True"></asp:TextBox></div>
                     </div>
                 <div class="Inccomp">
                     <div class="LabelWidth">Company Name</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_company" runat="server" CssClass="form-control" TabIndex="4" PlaceHolder="" ToolTip="CompanyName"  ReadOnly="True"></asp:TextBox></div>
                     </div>
                 <div class="InGrade">
                     <div class="LabelWidth">Grade</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Grade" runat="server" CssClass="form-control" TabIndex="5" PlaceHolder="" ToolTip="Grade" ReadOnly="True"></asp:TextBox></div>
                     </div>
                 <div class="InDesi">
                      <div class="LabelWidth">Designation</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_designation" runat="server" CssClass="form-control" TabIndex="6" PlaceHolder="" ToolTip="Designation"  ReadOnly="True"></asp:TextBox></div>
                      </div>

                 </div>
              <div class="FormGroupContent4">
                  
                  <div class="InDep">
                      <div class="LabelWidth">Department</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_department" runat="server" CssClass="form-control" TabIndex="7" PlaceHolder="" ToolTip="Department" BorderColor="#999997" ReadOnly="True"></asp:TextBox></div>
                      </div>
                  <div class="InAmount">
                      <div class="LabelWidth">Amount</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_Amount" runat="server" CssClass="form-control" TabIndex="8" PlaceHolder="" ToolTip="Amount"  style="text-align:right;"></asp:TextBox></div>
                      </div>
                  <div class="InTDS">
                      <div class="LabelWidth">TDS</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_tds" runat="server" CssClass="form-control" TabIndex="9" PlaceHolder="" ToolTip="TDS"  style="text-align:right;" 
            AutoPostBack="True" ontextchanged="txt_tds_TextChanged"></asp:TextBox></div>
                      </div>
                  <div class="InTdsAmount">
                      <div class="LabelWidth">TDS Amount</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_tdsAmount" runat="server" TabIndex="10"  CssClass="form-control" PlaceHolder="" ToolTip="TDS Amount" style="text-align:right;"></asp:TextBox></div>
                      </div>
                  <div class="InNet"> 
                      
                      <div class="LabelWidth">Net Amount</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_NetAmount" runat="server" TabIndex="11"  CssClass="form-control" PlaceHolder="" ToolTip="NetAmount"  style="text-align:right;"></asp:TextBox></div>
                      </div>
                   <div class="right_btn MTCtrl6 MB05">
                      <div class="btn ico-save" id="btn_save1" runat="server"><asp:Button ID="btn_save" runat="server" TabIndex="12" ToolTip="Save" onclick="btn_save_Click" /></div>
                      <div class="btn ico-delete"><asp:Button ID="btn_Delete" runat="server" ToolTip="Delete" onclick="btn_Delete_Click" 
            onclientclick="javascript:return confirm('Do u want to delete the data');" 
            Enabled="False" /></div>
                      <div class="btn ico-view"> <asp:Button ID="btn_View" runat="server" ToolTip="View" onclick="btn_View_Click" /></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" onclick="btn_cancel_Click" /></div>
                  </div>
                  </div>
              <div class="bordertopNew"></div>
           
              <div class="FormGroupContent4">
                   
        <div class="div_Grid">
        <asp:GridView ID="Grd_Incentive" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
            Width="100%" ForeColor="Black" 
            ShowHeaderWhenEmpty="True" DataKeyNames="incid" AllowPaging="false" PageSize="16" OnPageIndexChanging="Grd_Incentive_PageIndexChanging"
            onselectedindexchanged="Grd_Incentive_SelectedIndexChanged" OnRowDataBound="Grd_Incentive_RowDataBound">
            <Columns>
                <asp:BoundField DataField="empcode" HeaderText="Code" />
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField DataField="empname" HeaderText="Name" />
                <asp:BoundField DataField="grade" HeaderText="Grade" />
                <asp:BoundField DataField="deptname" HeaderText="Dept" />
                <asp:BoundField DataField="designame" HeaderText="Desig" />
                <asp:BoundField DataField="incentive" HeaderText="Incentive" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"  >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="tdsp" HeaderText="TDS%" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"  >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="tdsa" HeaderText="TDS AMT" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"  >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="netamount" HeaderText="NET AMT" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"  >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
               <%-- <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Select" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
                       <PagerStyle CssClass="GridviewScrollPager" />
        </asp:GridView>
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
    <div class="div_break">
    </div>
        
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date"
        Format="dd/MM/yyyy">
    </asp:CalendarExtender>
    <asp:ModalPopupExtender ID="Popup_Emp" runat="server" PopupControlID="pln_Emp" BackgroundCssClass="modalBackgroundjob"
        CancelControlID="Close_Emp" TargetControlID="hid1">
    </asp:ModalPopupExtender>

          <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Incentive Details #</label>

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

 
    <asp:Label ID="hid1" runat="server"></asp:Label>
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_Empid" runat="server" />
    <asp:HiddenField ID="hid_Incentiveid" runat="server" />
</asp:Content>
