<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="CTC.aspx.cs" Inherits="logix.HRM.CTC" %>
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
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
        .div_Grd {
    float: left;
    width: 100%;
    overflow: auto;
    margin-left: 0%;
    margin-bottom: 0%;
    margin-top: 0.5%;
    height: 178px!important;
    border: 1px solid #b1b1b1;
}
        .CTCDrop {
    width: 16.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .CTCDate {
    width: 13%;
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

    <link href="../Styles/CTC.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
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
              <li><a href="#" title="">HRM</a> </li>
              <li class="current">CTC</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/ctc_ic.png" />  <asp:Label ID="lbl_Header" runat="server" Text="CTC"></asp:Label>
        
        <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">             
               <div class="FormGroupContent4">
                     <div class="CTCLeft">
<div class="FormGroupContent4">
    <div class="CTCDate">
        <div class="LabelWidth">From</div>
        <div class="FieldInput"><asp:TextBox ID="txtFromdate" runat="server" placeholder="From" ToolTip="From" CssClass="form-control" TabIndex="1"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromdate"></asp:CalendarExtender></div>
        
        
        
        </div>
    <div class="CTCDate">
        
        <div class="LabelWidth">To</div>
        <div class="FieldInput"><asp:TextBox ID="txtToDate" runat="server" placeholder="" ToolTip="To" CssClass="form-control" TabIndex="2"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate"></asp:CalendarExtender></div>
        
        </div>

    <div class="CTCDrop">
        <div class="LabelWidth">Month/Earn</div>
        <div class="FieldInput"><asp:DropDownList ID="ddlMonthYarn" data-placeholder="Month Yarn" runat="server" CssClass="chzn-select" TabIndex="3">
                <asp:ListItem ></asp:ListItem>
                <asp:ListItem >Month</asp:ListItem>
                <asp:ListItem >Earned</asp:ListItem>
            </asp:DropDownList></div>
        
         </div>
    <div class="btn ico-get MTCtrl6"><asp:Button ID="btnGet" runat="server" ToolTip="Get" OnClick="btnGet_Click" TabIndex="4" /></div>
</div>
                     <div class="FormGroupContent4">
                         <div class="CtcCompanyLbl"><asp:Label ID="lbl_company" runat="server" Text="Company Wise"></asp:Label></div>
                         <div class="div_Grd">
            <asp:GridView ID="Grd_Company" runat="server" AutoGenerateColumns="False" Width="100%"
                ShowHeaderWhenEmpty="True"  class="Grid"
                DataKeyNames="divisionid,divisionname"
                OnSelectedIndexChanged="Grd_Company_SelectedIndexChanged" OnRowDataBound="Grd_Company_RowDataBound">
                <Columns>
                   <%-- <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <div class="div_Grd_Column">
                                <asp:LinkButton ID="Lnk_Emp" runat="server" Text='<%#Eval("divisionname")%>' ToolTip='<%#Eval("divisionname")%>'
                                    Style="text-decoration: none;" CommandName="Select"></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="33%" />
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="divisionname" HeaderText="Company Name" >
                        <HeaderStyle Wrap="false" /> 
                        <ItemStyle Width="33%" Wrap="false"  />
                    </asp:BoundField>
                    <asp:BoundField DataField="noofemp" HeaderText="No of Emps" ItemStyle-CssClass="TxtAlign1" >
                        <HeaderStyle Wrap="false" /> 
                        <ItemStyle Width="22%" HorizontalAlign="Right" Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcmonth" HeaderText="Per Month" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                         <HeaderStyle Wrap="false" /> 
                        <ItemStyle HorizontalAlign="Right" Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcannum" HeaderText="Per Annum" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                         <HeaderStyle Wrap="false" /> 
                        <ItemStyle HorizontalAlign="Right" Width="20%" /> 
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>
                         </div>
                     <div class="FormGroupContent4 MB05">
                         <div class="CtcBranchLbl"> <asp:Label ID="lbl_branch" runat="server" Text="Branch Wise"></asp:Label></div>
                         <div class="div_Grd">
            <asp:GridView ID="Grd_branch" runat="server" AutoGenerateColumns="False" Width="100%"
                ShowHeaderWhenEmpty="True"  class="Grid"
                DataKeyNames="branchid,portname"
                OnSelectedIndexChanged="Grd_branch_SelectedIndexChanged" OnRowDataBound="Grd_branch_RowDataBound">
                <Columns>
                   <%-- <asp:TemplateField HeaderText="Branch Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_Branch" runat="server" Text='<%#Eval("portname")%>' ToolTip='<%#Eval("portname")%>'
                                Style="text-decoration: none;" CommandName="Select"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="33%" />
                    </asp:TemplateField>--%>
                     <asp:BoundField DataField="portname" HeaderText="Branch Name"  >
                         <ItemStyle Wrap="false" />
                        <ItemStyle Width="33%" HorizontalAlign="Right" Wrap="false" />
                    </asp:BoundField>
                  
                    <asp:BoundField DataField="noofemp" HeaderText="No of Emps" ItemStyle-CssClass="TxtAlign1" >
                         <ItemStyle Wrap="false" />
                        <ItemStyle Width="22%" HorizontalAlign="Right" />
                    </asp:BoundField>
                     
                    <asp:BoundField DataField="ctcmonth" HeaderText="Per Month" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                        <ItemStyle Wrap="false" />
                        <ItemStyle HorizontalAlign="Right" Width="20%" Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcannum" HeaderText="Per Annum" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                         <ItemStyle Wrap="false" />
                        <ItemStyle HorizontalAlign="Right" Width="20%" Wrap="false" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>

                     </div>
                     
                 </div> 
                 <div class="CTCRight">
                     <div class="FormGroupContent4">
                         <div class="CtcMonthWDrop">
                             <div class="LabelWidth">Month</div>
                             <div class="FieldInput"> <asp:DropDownList ID="ddl_Monrh" runat="server" data-placeholder="Month" ToolTip="Month" CssClass="chzn-select" TabIndex="5">
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
                         <div class="Ctcyear"> 
                             
                             <div class="LabelWidth">Year</div>
                             <div class="FieldInput"><asp:TextBox ID="txt_year" runat="server" placeholder="" ToolTip="Year" MaxLength="4" CssClass="form-control" TabIndex="6"></asp:TextBox></div>
</div>
                             
                         <div class="right_btn MTCtrl6">
                             <div class="btn btn-month1"><asp:Button ID="btn_Month" runat="server" ToolTip="Month" OnClick="btn_Month_Click" TabIndex="7" /></div>
                             <div class="btn btn-earn1"><asp:Button ID="btn_Earned" runat="server" ToolTip="Earned"  OnClick="btn_Earned_Click" TabIndex="8" /></div>
                             <div class="btn ico-cancel" id="btn_cancel2" runat="server"> <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="9" /></div>
                         </div>
                     </div>

                     <div class="FormGroupContent4">
                         <div class="CtcCompanyLbl"> <asp:Label ID="lbl_department" runat="server" Text="Department Wise"></asp:Label></div>
                         <div class="div_Grd">
            <asp:GridView ID="Grd_Department" runat="server" AutoGenerateColumns="False" Width="100%"
                ShowHeaderWhenEmpty="True"  class="Grid"   DataKeyNames="deptid,deptname"
                 OnSelectedIndexChanged="Grd_Department_SelectedIndexChanged" OnRowDataBound="Grd_Department_RowDataBound">
                <Columns>
                    <%--<asp:TemplateField HeaderText="Department Name">
                        <ItemTemplate>
                            <div class="div_Grd_Column">
                                <asp:LinkButton ID="Lnk_Emp" runat="server" Text='<%#Eval("deptname")%>' ToolTip='<%#Eval("deptname")%>'
                                    Style="text-decoration: none;" CommandName="Select"></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="33%" />
                    </asp:TemplateField>--%>
                      <asp:BoundField DataField="deptname" HeaderText="Department Name"  >
                          <HeaderStyle Wrap="false" />
                        <ItemStyle Width="23%" HorizontalAlign="Right" Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="noofemp" HeaderText="No of Emps" ItemStyle-CssClass="TxtAlign1" >
                        <HeaderStyle Wrap="false" />
                        <ItemStyle Width="22%" HorizontalAlign="Right" Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcmonth" HeaderText="Per Month" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                        <HeaderStyle Wrap="false" />
                        <ItemStyle HorizontalAlign="Right" Width="20%" Wrap="false"  />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcannum" HeaderText="Per Annum" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                        <HeaderStyle Wrap="false" />
                        <ItemStyle HorizontalAlign="Right" Width="20%" Wrap="false" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>
                     </div>
                      <div class="FormGroupContent4 MB05">
                          <div class="CtcCompanyLbl"><asp:Label ID="lbl_employee" runat="server" Text="Employee Wise"></asp:Label></div>
                          <div class="div_Grd">
            <asp:GridView ID="Grd_Employee" runat="server" AutoGenerateColumns="False" Width="100%"
                ShowHeaderWhenEmpty="True"  class="Grid" OnRowDataBound="Grd_Employee_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="empname" HeaderText="Employee Name">
                        <HeaderStyle Wrap="false" />
                        <ItemStyle Width="35%" Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcmonth" HeaderText="Per Month" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                        <HeaderStyle Wrap="false" />
                        <ItemStyle HorizontalAlign="Right" Width="20%" Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcannum" HeaderText="Per Annum" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                        <HeaderStyle Wrap="false" />
                        <ItemStyle HorizontalAlign="Right" Width="20%" Wrap="false" />
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
            </div>
         </div>




    
                  <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>CTC #</label>

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

    <asp:modalpopupextender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label3" CancelControlID="imglog" BehaviorID="Test1">
    </asp:modalpopupextender>






     

   
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_divid" runat="server" />
    <asp:HiddenField ID="hid_bid" runat="server" />
    <asp:HiddenField ID="hid_deptid" runat="server" />
    <asp:HiddenField ID="hid_empid" runat="server" />
       <asp:HiddenField ID="hid_strdiv" runat="server" />
     <asp:HiddenField ID="hid_branch" runat="server" />
     <asp:HiddenField ID="hid_strGet" runat="server" />
      <asp:HiddenField ID="hid_from" runat="server" />
      <asp:HiddenField ID="hid_to" runat="server" />
     <asp:HiddenField ID="hid_date" runat="server" />
</asp:Content>
