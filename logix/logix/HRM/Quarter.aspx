<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Quarter.aspx.cs" Inherits="logix.HRM.Quarter" %>

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

   <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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










    <link href="../Styles/Quarter.css" rel="stylesheet" />
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

     <script type="text/javascript" language="javascript">

         function pageLoad(sender, args) {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

         }
         </script>

    <style type="text/css">
        .QuarterLbl {
    float: left;
    margin: 3px 0.5% 0 0;
    width: 16%;
}
        .QuarterYrDrop {
    float: left;
    margin: 0 0 0 0;
    width: 8%;
}
        .QuarterRad {
    float: left;
    margin: 0 0.5% 0 0;
    width: 7%;
}

.QuarterEmp {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

.QuarterComp {
    width: 18%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.QuararterInput {
    width: 10.3%;
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
              <li><a href="#" title="">Payroll</a> </li>
              <li class="current"><a href="#" title="" id="HeaderLabel" runat="server"> Quarter Details </a> </li>
            </ul>
      </div>
          <!-- /Breadcrumbs line -->
    <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/quarterdetails_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Quarter Details"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
                <div class="FormGroupContent4">
                    <div class="QuarterLbl MTCtrl6"><asp:Label ID="lbl_Empcode" runat="server" Text="Quarter Details for the Financial Year"></asp:Label></div>
                    <div class="QuarterYrDrop">
                        <div class="LabelWidth">Year</div>
                        <div class="FieldInput"><asp:DropDownList ID="ddlmonth" runat="server" Data-placeHolder="Year" CssClass ="chzn-select" AutoPostBack="true" ToolTip="Quarter Details for the Financial Year" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" >
            <asp:ListItem Value="0" Text=""></asp:ListItem>
             <%--<asp:ListItem></asp:ListItem>
            <asp:ListItem Value="1">2008-2009</asp:ListItem>
            <asp:ListItem Value="2">2009-2010</asp:ListItem>
            <asp:ListItem Value="3">2010-2011</asp:ListItem>
            <asp:ListItem Value="4">2011-2012</asp:ListItem>
            <asp:ListItem Value="5">2012-2013</asp:ListItem>
            <asp:ListItem Value="6">2013-2014</asp:ListItem>
            <asp:ListItem Value="7">2014-2015</asp:ListItem>
            <asp:ListItem Value="8">2015-2016</asp:ListItem>  --%>          
        </asp:DropDownList></div>
                        </div>

                    </div>
                <div class="bordertopNew"></div>
                 <div class="FormGroupContent4">
                     <div class="QuarterLbl1 MTCtrl6"> 
                         <asp:LinkButton ID="lnk_empcode" runat="server" style="text-decoration:none;" ForeColor="Red"
            onclick="lnk_empcode_Click">EmpCode</asp:LinkButton></div>
                     <div class="QuarterEmp">
                         <div class="LabelWidth">Emp Code</div>
                         <div class="FieldInput"> <asp:TextBox ID="txt_Empcode" runat="server" placeholder="" ToolTip="Empcode" CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_Empcode_TextChanged"></asp:TextBox></div>
                        </div>
                     <div class="QuarterEmpN"> 
                         
                         <div class="LabelWidth">Emp Name</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_EmpName" runat="server" placeholder="" ToolTip="EmpName" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                         </div>
                     <div class="QuarterDepart">
                         <div class="LabelWidth">Department</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_dept" runat="server" placeholder="" ToolTip="Department" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                         </div>
                     <div class="QuarterComp">
                         <div class="LabelWidth">Company</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_division" runat="server" placeholder="" ToolTip="Company" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                         </div>
                     <div class="QuarterGrade">
                         <div class="LabelWidth">Grade</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Grade" runat="server" placeholder="" ToolTip="Grade" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                         </div>
                     <div class="QuarterDesi">
                         <div class="LabelWidth">Designation</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_designation" runat="server" placeholder="" ToolTip="Designation" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                         </div>
                     </div>
                <div class="bordertopNew"></div>
                 <div class="FormGroupContent4">
                     <div class="QuarterRad">  <asp:RadioButton ID="rdbExpired" runat="server"  TabIndex="3"  GroupName="radio"
        AutoPostBack="True" OnCheckedChanged="rdbExpired_CheckedChanged" /><asp:Label ID="Quarter1" runat="server" Text="Quarter1"></asp:Label></div>
                     <div class="QuarterRad"><asp:RadioButton ID="rdbLive" runat="server"  TabIndex="4"  GroupName="radio"
        AutoPostBack="True" OnCheckedChanged="rdbLive_CheckedChanged" /><asp:Label ID="Quarter2" runat="server" Text="Quarter2"></asp:Label></div>
                     <div class="QuarterRad"><asp:RadioButton ID="rdbBoth" runat="server" TabIndex="5"  GroupName="radio"
        AutoPostBack="True" OnCheckedChanged="rdbBoth_CheckedChanged" /><asp:Label ID="Quarter3" runat="server" Text="Quarter3"></asp:Label></div>
                     <div class="QuarterRad"><asp:RadioButton ID="rdb4" runat="server" TabIndex="5"  GroupName="radio"
        AutoPostBack="True" OnCheckedChanged="rdb4_CheckedChanged" /><asp:Label ID="Quarter4" runat="server" Text="Quarter4"></asp:Label></div>
                     </div>
                <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="QuararterInput">
                        <div class="LabelWidth">Quarter Marks</div>
                        <div class="FieldInput"><asp:TextBox ID="txtQuarter" runat="server" placeholder="" ToolTip="Quarter Marks" CssClass="form-control"></asp:TextBox></div>
                        </div>
                    <div class="QuarterAmount">
                        <div class="LabelWidth">Amount</div>
                        <div class="FieldInput"><asp:TextBox ID="txtamt" runat="server" style="text-align:right;" placeholder="" ToolTip="Amount" CssClass="form-control" ></asp:TextBox></div>
                        </div>
                    </div>
                 <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="right_btn MT0">
                        <div class="btn ico-update" id="btn_save1" runat="server"><asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" /></div>
                        <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel"  OnClick="btn_cancel_Click" /></div>
                    </div>
                    </div>
                 <div class="bordertopNew"></div>
                 <div class="FormGroupContent4">

                     <div class="div_Grid">
        <asp:GridView ID="grdInvest" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
            Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="grdInvest_RowDataBound">
            <Columns>
                <asp:BoundField DataField="empcode" HeaderText="empcode" >
                      <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
               <asp:BoundField DataField="empname" HeaderText="empname" >
                <ItemStyle HorizontalAlign="left" />
                </asp:BoundField>
               <asp:BoundField DataField="quartermark" HeaderText="quartermark">
                <ItemStyle HorizontalAlign="left" />
                </asp:BoundField>
               <asp:BoundField DataField="quarteramt" HeaderText="quarteramt" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1"  > 
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                  <asp:BoundField DataField="quarterid" HeaderText="quarterid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" > 
                <ItemStyle />
                </asp:BoundField>

                 <asp:BoundField DataField="Fyear" HeaderText="fy" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide"  > 
                <ItemStyle />
                </asp:BoundField>

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
                  <h4><i class="icon-umbrella"></i></h4>
                </div>
            <div class="widget-content" >
            
                </div>
         </div>
            </div>
        </div>











    <div class="divTotal">
        <div class="div_Main">
            
        </div>
        <div class="div_break">
        </div>
            <div class="div_label">
        
    </div>   

          <div class="div_ddlmonth">
        
              </div>
         <div class="div_break">
        </div>    
         <hr />
       <div class="div_break">
        </div>
             <div class="div_labelcode">
       
    </div>
        <div class="div_txtcode">
            
        </div>
        <%--    <div class="div_label">
        <asp:Label ID="lbl_name" runat="server" Text="EmpName"></asp:Label>
    </div>--%>
        <div class="div_Nametxt">
           
        </div>
        <div class="div_break">
        </div>
        <%--   <div class="div_label">
        <asp:Label ID="lbl_location" runat="server" Text="Location"></asp:Label>
    </div>--%>
        <div class="div_txt">
            
        </div>
        <%--    <div class="div_label">
        <asp:Label ID="lbl_division" runat="server" Text="Division"></asp:Label>
    </div>--%>
        <div class="div_Nametxt">
            
        </div>
        <div class="div_break">
        </div>
        <%--    <div class="div_label">
        <asp:Label ID="lbl_dept" runat="server" Text="Department"></asp:Label>
    </div>--%>
        <div class="div_txt">
            
        </div>
        <%--    <div class="div_label">
        <asp:Label ID="lbl_designation" runat="server" Text="Designation"></asp:Label>
    </div>--%>
        <div class="div_Nametxt">
            
        </div>
          <div class="div_break">
        </div>    
         <hr />
       <div class="div_break">
        </div>
        <div class="div_rdb">
  </div>
<div class="div_Label_rdb"></div>
      
<div class="div_rdb">
    </div>
<div class="div_Label_rdb"></div>
<div class="div_rdb">
    </div>
<div class="div_Label_rdb"></div>
    <div class="div_rdb">
    </div>
<div class="div_Label_rdb"></div>      
      
         <div class="div_break">
        </div>    
         <hr />
       <div class="div_break">
        </div>
         <div class="div_Nametxt">
            
        </div>
        <div class="div_txt">
            
        </div>
         <div class="div_break">
        </div>    
         <hr />
       <div class="div_break">
        </div>

        <div class="div_btn">
                  
            
           
        </div>
        <div class="div_break">
        </div>
        <hr />
        <div class="div_break">
        </div>

        
        

    </div>

     <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Quarter #</label>

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


    <asp:HiddenField ID="Hid_Empid" runat="server" />
    <asp:HiddenField ID="intQtrId" runat="server" />
    <asp:HiddenField ID="Hid_Fyear" runat="server" />
     <asp:HiddenField ID="hid_quaot" runat="server" />
      <%--<asp:HiddenField ID="Qid" runat="server" />--%>
  
</asp:Content>
