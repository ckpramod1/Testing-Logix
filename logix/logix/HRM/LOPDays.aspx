<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true"
    CodeBehind="LOPDays.aspx.cs" Inherits="logix.HRM.LOPDays" %>

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










    <link href="../Styles/LOPDays.css" rel="stylesheet" type="text/css" />
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
        function TxtFocus() {
            //$("#<%=txt_Empname.ClientID %>").blur().focus().val($("#<%=txt_Empname.ClientID %>").val());
            var el = $("#<%=txt_Empname.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }
        function TxtDivFocus() {
            var el = $("#<%=txt_company.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }
        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../HRM/LOPDays.aspx/GetEmpName",
                data: '{Prefix: "' + $("#<%=txt_Empname.ClientID %>").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#<%=btn.ClientID %>").click();
                },
                failure: function (response) {
                    //alertify.alert(response.d);
                }
            });

        }
        function GetDetail_Division() {
            $.ajax({
                type: "POST",
                url: "../HRM/LOPDays.aspx/GetDivName",
                data: '{Prefix: "' + $("#<%=txt_company.ClientID %>").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#<%=btn_division.ClientID %>").click();
                },
                failure: function (response) {
                    //alertify.alert(response.d);
                }
            });
           
        }
       
    </script>
    <style type="text/css">
        .LOPCom {
    width: 22%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .LOPdepart {
    width: 20%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .LOPMonth {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .LOPYear {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .LOPMonth1 {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .LOPWorking {
    width: 5%;
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
              <li class="current">LOP Days</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

    <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/lopdays_ic.png" /> <asp:Label ID="lbl_Header" runat="server"  Text="LOP Days"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
             <div class="FormGroupContent4">
                 <div class="LOPCom">
                     <div class="LabelWidth">Company</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_company" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Company" onkeyup="GetDetail_Division();"></asp:TextBox></div>
                     </div>
                 <div class="LOPdepart">
                     
                     <div class="LabelWidth">Department</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_dept" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Department" ReadOnly="True"></asp:TextBox></div>
                     </div>
                 <div class="LOPMonth"> 
                     <div class="LabelWidth">Month</div>
                     <div class="FieldInput"><asp:DropDownList ID="ddl_Monrh" runat="server" Data-placeHolder="Month" CssClass ="chzn-select" ToolTip="Month" AutoPostBack="true" OnSelectedIndexChanged="ddl_Monrh_SelectedIndexChanged" >
            <%--<asp:ListItem></asp:ListItem>--%>
            <asp:ListItem Value="0">JANUARY</asp:ListItem>
            <asp:ListItem Value="1">FEBRUARY</asp:ListItem>
            <asp:ListItem Value="2">MARCH</asp:ListItem>
            <asp:ListItem Value="3">APRIL</asp:ListItem>
            <asp:ListItem Value="4">MAY</asp:ListItem>
            <asp:ListItem Value="5">JUNE</asp:ListItem>
            <asp:ListItem Value="6">JULY</asp:ListItem>
            <asp:ListItem Value="7">AUGUST</asp:ListItem>
            <asp:ListItem Value="8">SEPTEMBER</asp:ListItem>
            <asp:ListItem Value="9">OCTOBER</asp:ListItem>
            <asp:ListItem Value="10">NOVEMBER</asp:ListItem>
            <asp:ListItem Value="11">DECEMBER</asp:ListItem>
        </asp:DropDownList></div>
                     
                      </div>
                 <div class="LOPYear">
                     <div class="LabelWidth">Year</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_year" runat="server" MaxLength="4" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_year_TextChanged" ToolTip="Year"></asp:TextBox></div>
                     </div>
                 <div class="right_btn MT0">
                     <div class="btn ico-get MTCtrl6">
                         <asp:Button ID="btn_Get" runat="server" ToolTip="Get"  OnClick="btn_Get_Click"  />
                     </div>
                 </div>
                 </div>
              <div class="FormGroupContent4">
                  <div class="LOPCom">
                      <div class="LabelWidth">Designation</div>
<div class="FieldInput"><asp:TextBox ID="txt_desg" runat="server" PlaceHolder="" ToolTip="Designation" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                      </div>
                  <div class="LOPdepart">
                      <div class="LabelWidth">Employee Name</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_Empname" runat="server" placeHolder="" ToolTip="EmployeeName" CssClass="form-control"  onkeyup="GetDetail();"></asp:TextBox></div>
                      </div>
                  <div class="LOPMonth1">
                      <div class="LabelWidth">Lop(Days)</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_lop" runat="server" PlaceHolder=""  style="text-align:right" CssClass="form-control" ToolTip="Lop(Days)"   ></asp:TextBox></div>
                      </div>
                  <div class="LOPWorking">
                      
                      <div class="LabelWidth">Work Days</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_day" runat="server" PlaceHolder="" CssClass="form-control" ToolTip="Working Days" style="text-align:right;"></asp:TextBox></div>
                      </div>
                  <div class="right_btn MTCtrl6">
                      <div class="btn btn-upd1"> <asp:Button ID="btn_update" runat="server" ToolTip="Upd" Enabled="False" onclick="btn_update_Click"  /></div>

                  </div>
                  </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="div_Grid">   
        <asp:GridView ID="Grd_LOP" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl" Width="100%" ShowHeaderWhenEmpty="True"
            DataKeyNames="Employeeid,EmpName,designame" AllowPaging="false" PageSize="18" OnPageIndexChanging="Grd_LOP_PageIndexChanging"
            OnSelectedIndexChanged="Grd_LOP_SelectedIndexChanged" BorderColor="#999997" OnRowDataBound="Grd_LOP_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <%#Container.DataItemIndex + 1%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="divsname" HeaderText="Company" />
                <asp:BoundField DataField="portname" HeaderText="Location" />
                <asp:BoundField DataField="empcode" HeaderText="Code" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <div class="div_Emp">
                            <asp:Label ID="lbl_Emp" runat="server" Text='<%#Eval("EmpName")%>' ToolTip='<%#Eval("EmpName")%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="doj" HeaderText="D O J" />
                <asp:BoundField DataField="lopdays" HeaderText="LoP Days" DataFormatString="{0:0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="workdays" HeaderText="Worked Days" DataFormatString="{0:0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="deptname" HeaderText="Department" />
                <asp:TemplateField HeaderText="Designation">
                    <ItemTemplate>
                        <div class="div_Desg">
                            <asp:Label ID="lbl_Desig" runat="server" Text='<%#Eval("designame")%>' ToolTip='<%#Eval("designame")%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <%--<asp:TemplateField>
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

              <div class="FormGroupContent4">
                  <div class="right_btn MT1 MB06 ">                     
                      <div class="btn btn-generate1"> <asp:Button ID="btn_regenrate" runat="server" ToolTip="Regenrate" OnClick="btn_regenrate_Click" /></div>
                      <div class="btn ico-delete">   <asp:Button ID="btn_delete" runat="server" ToolTip="Delete" OnClick="btn_delete_Click"/></div>
                      <div class="btn ico-view"><asp:Button ID="btn_view" runat="server" ToolTip="View" onclick="btn_view_Click" /></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" onclick="btn_cancel_Click" /></div>
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

   
    <asp:Button ID="btn" runat="server" Text="" style="display:none;" 
        onclick="btn_Click" />
            <asp:Button ID="btn_division" runat="server" Text="" 
        style="display:none;" onclick="btn_division_Click"  />


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>LOP Days #</label>

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


    <asp:HiddenField ID="hid_index" runat="server" />
    <asp:HiddenField ID="hid_Empid" runat="server" />
    <asp:HiddenField ID="hid_empcode" runat="server" />
</asp:Content>
