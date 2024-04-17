<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="PaySlip.aspx.cs" Inherits="logix.HRM.PaySlip" %>
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









    <link href="../Styles/PaySlip.css" rel="stylesheet" type="text/css" />
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
        .PayMonth {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .PayYear {
    width: 4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .PayTotalEmp {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .PayJoined {
    width: 4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .PayRelied {
    width: 4%;
    float: left;
    margin: 0px 0% 0px 0px;
}
        .div_Grid {
    width: 54.5%;
    height: 320px;
    float: left;
    margin-left: 0%;
    margin-top: 0%;
    margin-bottom: 0%;
    overflow: auto;
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
              <li class="current">Pay Slip</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->


         <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/payslip_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Pay Slip"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
                       <div class="FormGroupContent4">
                 <div class="PayMonth"> 
                     
                     <div class="LabelWidth">Month</div>
                     <div class="FieldInput"> <asp:DropDownList ID="ddl_Monrh" runat="server" Data-placeHolder="Month" ToolTip="Month" CssClass ="chzn-select" OnSelectedIndexChanged="ddl_Monrh_SelectedIndexChanged" AutoPostBack="true"  >
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
                 <div class="PayYear">
                     <div class="LabelWidth">Year</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_year" runat="server" placeholder="" ToolTip="Year" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 <div class="PayProDrop">  
                     <div class="LabelWidth">Company</div>
                     <div class="FieldInput"><asp:DropDownList ID="ddl_Company" runat="server" Data-placeHolder="Company" ToolTip="Company" CssClass ="chzn-select" OnSelectedIndexChanged="ddl_Company_SelectedIndexChanged1" AutoPostBack="True"  >
            <asp:ListItem></asp:ListItem>
          <%--  <asp:ListItem Value="0">ALL</asp:ListItem>--%>
                 </asp:DropDownList></div>
                     </div>
                 <div class="PayTotalEmp">
                     <div class="LabelWidth">Total Employee</div>
                     <div class="FieldInput"> <asp:TextBox ID="txt_TotalEmp" runat="server" ReadOnly="true" placeholder="" ToolTip="TotalEmployee" CssClass="form-control"></asp:TextBox></div>
                    </div>
                 <div class="PayJoined">
                     <div class="LabelWidth">Joined</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_joined" runat="server" ReadOnly="true" placeholder="" ToolTip="Joined" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 <div class="PayRelied"> 
                     <div class="LabelWidth">Relived</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Relieved" runat="server" ReadOnly="true" placeholder="" ToolTip="Relieved" CssClass="form-control"></asp:TextBox></div>
                     </div>

                 </div>
                <div class="FormGroupContent4">
                    <div class="PayWorkedays"><asp:Label ID="lbl_workday" runat="server" Text="Worked Days"></asp:Label></div>
                    </div>
               <div class="FormGroupContent4">
                   <div class="div_Grid">
        <asp:GridView ID="Grd_Pay" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
            Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_Pay_RowDataBound">
            <Columns>
                <asp:BoundField DataField="portname" HeaderText="Branch"> 
                    <HeaderStyle Width="100px" Wrap="false"  />
                    <ItemStyle Width="100px" Wrap="false" />
                    </asp:BoundField>
               <asp:BoundField DataField="netamt" HeaderText="Salary" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1" >
                    <HeaderStyle Width="150px" Wrap="false"  />
                <ItemStyle HorizontalAlign="Right" Width="150px" Wrap="false" />
                </asp:BoundField>
               <asp:BoundField DataField="pf" HeaderText="PF" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1">
                    <HeaderStyle Width="350px" Wrap="false"  />
                <ItemStyle HorizontalAlign="Right" Width="350px" Wrap="false" />
                </asp:BoundField>
               <asp:BoundField DataField="esi" HeaderText="ESI" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1"> 
                    <HeaderStyle Width="150px" Wrap="false"  />
                <ItemStyle HorizontalAlign="Right" Width="150px" Wrap="false" />
                </asp:BoundField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>
                   </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-view"><asp:Button ID="btn_View" runat="server" ToolTip="View" OnClick="btn_View_Click"  />
             
            </div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" /> </div>
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
                                    <label>PaySlip #</label>

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

</asp:Content>
