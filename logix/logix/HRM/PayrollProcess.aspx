<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="PayrollProcess.aspx.cs" Inherits="logix.HRM.PayrollProcess" %>

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

<%--    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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




    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
<script src="../Scripts/Validation.js" type="text/javascript"></script>
<link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>    
<link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  
     <%--<link href="../Styles/GridviewScroll.css" rel="stylesheet" />--%>
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

  

   

<script type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        });
        $(document).ready(function () {
            $('#<%=Grd_Pay.ClientID%>').gridviewScroll({
                width: 1060,
                height: 550,
                freezesize: 3,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });



        function Chk_update() {
            var count = $.trim($("#<%=hid.ClientID %>").val());
              if (count.length > 0) {
                  return confirm('Do You Want to Process Without Update ?');
              }
          }
          function TxtFocus() {
              var el = $("#<%=txt_EmpName.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }
        function TxtLocationFocus() {
            var el = $("#<%=txt_location.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }
        function GetDetail_Empname() {
            $.ajax({
                type: "POST",
                url: "../HRM/PayrollProcess.aspx/GetEmpName",
                data: "{ 'Prefix': '" + $("#<%=txt_EmpName.ClientID %>").val() + "','location':'" + $("#<%=txt_location.ClientID %>").val() + "'}",
                <%--data: '{Prefix: "' + $("#<%=txt_EmpName.ClientID %>").val() + ',"'FType':'C'"}",--%>
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#<%=btn_Emp.ClientID %>").click();
                },
                failure: function (response) {
                }
            });
            }
            function GetDetail_Location() {
                $.ajax({
                    type: "POST",
                    url: "../HRM/PayrollProcess.aspx/GetLocationName",
                    data: "{ 'Prefix': '" + $("#<%=txt_location.ClientID %>").val() + "','empname':'" + $("#<%=txt_EmpName.ClientID %>").val() + "'}",
                <%--data: '{Prefix: "' + $("#<%=txt_location.ClientID %>").val() + "','empname':'" + $("#<%=txt_EmpName.ClientID %>").val() + "'}",--%>
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#<%=btn_Location.ClientID %>").click();
                },
                failure: function (response) {
                }
            });
            }
    }
</script>

        
    <script type="text/javascript" >

       
      
    </script>
    <style type="text/css">
        .hide{
            display:none;
        }
        #logix_CPH_ddl_Company_chzn {width:100%!important;
        }
        .div_GridN1 {width:1056px; overflow-x:hidden; overflow-y:hidden;
        }
        .Pnl {
    background-color: #fff;
    border-color: #5D7B9D;
    border-style: solid;
    border-width: 1px;
    width: 300px;
    text-align: center;
    font-size: 11px;
    padding: 5px;
}
        #logix_CPH_PnlPay {
                position: fixed;
    z-index: 100001!important;
    left: 427px!important;
    top: 195.5px!important;
        }
        #logix_CPH_pnlUpdate {
             position: fixed;
    z-index: 100001!important;
    left: 427px!important;
    top: 195.5px!important;
        }

        .div_GridN1 {
    width: 99.3%;
    overflow-x: hidden;
    overflow-y: hidden;
    height: 250px;
    border: 1px solid #b1b1b1;
    overflow: auto;
}
.PayEmp {
    width: 13%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PayLocation {
    width: 9%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PayEmpCode {
    width: 4.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}
.PayMonth {
    width: 8%;
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
              <li class="current">Payroll Process</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/payrollprocess_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Payroll Process"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
            <div class="FormGroupContent4">
                 <div class="PayProDrop">
                     
                     <div class="LabelWidth">Company Name</div>
                     <div class="FieldInput"><asp:DropDownList ID="ddl_Company" runat="server" CssClass="chzn-select" ToolTip="Company Name"  BorderColor="#999997" Data-placeHolder="Company Name"   AppendDataBoundItems="True">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList></div>
                     </div>
                 <div class="PayMonth"> 
                     <div class="LabelWidth">Month</div>
                     <div class="FieldInput"> <asp:DropDownList ID="ddl_Monrh" runat="server" CssClass="chzn-select" ToolTip="Month" Data-placeHolder="Month"  BorderColor="#999997"  >
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
                     <div class="FieldInput"> <asp:TextBox ID="txt_year" runat="server" CssClass="form-control" ToolTip="Year" placeHolder=""  MaxLength="4"></asp:TextBox></div>
                    </div>
                 <div class="btn btn-process1" style="float:left; margin:17px 0.5% 0px 0px;"> 
                     
                     <asp:Button ID="btn_Process" runat="server" ToolTip="Process" OnClick="btn_Process_Click" />

                 </div>
                 <div class="PayEmp">
                     <div class="LabelWidth">Employee Name</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_EmpName" runat="server" CssClass="form-control" ToolTip="Employeename" placeHolder="" AutoPostBack="true"   onkeyup="GetDetail_Empname();"></asp:TextBox></div>
                     </div>
                 <div class="PayLocation">
                     <div class="LabelWidth">Location</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_location" runat="server" CssClass="form-control" ToolTip="Location" placeHolder=""  AutoPostBack="true" onkeyup="GetDetail_Location();"></asp:TextBox></div>
                     </div>
                 <div class="PayEmpCode">
                     <div class="LabelWidth">Emp Code</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" CssClass="form-control" ToolTip="EmployeeCode" placeHolder=""  MaxLength="4"></asp:TextBox></div>
                     </div>
                 </div>
              <div class="FormGroupContent4">
                  <asp:Panel ID="payroll" runat="server" CssClass="div_GridN1" >
                
        <asp:GridView ID="Grd_Pay" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl" OnPageIndexChanging="Grd_Pay_PageIndexChanging"           
             Width="250%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_Pay_RowDataBound">
            <Columns>
                <asp:BoundField DataField="EMPCODE" HeaderText="EmpCode" />
                <asp:TemplateField HeaderText="EmpName">
                    <ItemTemplate>
                        <div class="div_EmpColumn">
                            <asp:Label ID="lbl" runat="server" Text='<%# Bind("EMPNAME")%>' ToolTip='<%# Bind("EMPNAME")%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="LOCATION" HeaderText="Location" />
                <asp:TemplateField HeaderText="Basic"  ItemStyle-CssClass="TxtAlign1" >
                    <ItemTemplate>
                        <asp:TextBox ID="txt_basic" runat="server" Text='<%# Bind("BASIC")%>' ToolTip='<%# Bind("BASIC")%>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hra"  ItemStyle-CssClass="TxtAlign1" >
                    <ItemTemplate>
                        <asp:TextBox ID="txt_HRA" runat="server" Text='<%# Bind("HRA")%>' ToolTip='<%# Bind("HRA")%>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Conveyance" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_conveyance" runat="server" Text='<%# Bind("CONVEYANCE")%>' ToolTip='<%# Bind("CONVEYANCE")%>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Spl allowance" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_splAllowance" runat="server" Text='<%# Bind("SPECIALALLOWANCE")%>' ToolTip='<%# Bind("SPECIALALLOWANCE")%>'
                            CssClass="GrdText" onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherEarn" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_ohterearning" runat="server" Text='<%# Bind("OTHEREARNING")%>' ToolTip='<%# Bind("OTHEREARNING")%>'
                            CssClass="GrdText" onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BasicArr" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_basicarr" runat="server" Text='<%# Bind("BASICARR")%>' ToolTip='<%# Bind("BASICARR")%>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherArr" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_otherarr" runat="server" Text='<%# Bind("OTHERARR")%>' ToolTip='<%# Bind("OTHERARR")%>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Loyality" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_loyality" runat="server" Text='<%# Bind("LOYALITY")%>' ToolTip='<%# Bind("LOYALITY")%>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PF" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_pf" runat="server" Text='<%# Bind("PF") %>' ToolTip='<%# Bind("PF") %>'  CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ESI" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Esi" runat="server" Text='<%# Bind("ESI") %>' ToolTip='<%# Bind("ESI") %>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LWF" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_lwf" runat="server" Text='<%# Bind("LWF") %>' ToolTip='<%# Bind("LWF") %>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LoanAdvance" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_loan" runat="server" Text='<%# Bind("LOANADVANCE") %>' ToolTip='<%# Bind("LOANADVANCE") %>'  CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherDED" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_otherded" runat="server" Text='<%# Bind("OTHERDED") %>' ToolTip='<%# Bind("OTHERDED") %>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IT" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_it" runat="server" Text='<%# Bind("IT") %>' ToolTip='<%# Bind("IT") %>'  CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProfTax" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Proftax" runat="server" Text='<%# Bind("PROFTAX") %>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medical" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_medical" runat="server" Text='<%# Bind("MEDICAL") %>' ToolTip='<%# Bind("MEDICAL") %>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="GR" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Gr" runat="server" Text='<%# Bind("GR") %>' ToolTip='<%# Bind("GR") %>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="GRPF" ItemStyle-CssClass="TxtAlign1">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Grpf" runat="server" Text='<%# Bind("GRPF") %>' ToolTip='<%# Bind("GRPF") %>' CssClass="GrdText"
                            onkeyup="IsDoubleCheck_Grid(this);"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
            </Columns>
          <%--  <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />--%>
             <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" />
        </asp:GridView>
                     
   </asp:Panel>

                  </div>

              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-update"><asp:Button ID="btn_Update" runat="server" ToolTip="Update" OnClick="btn_Update_Click" /></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" /></div>
                        
        
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
           </div>.









    <div class="Header">
        
    </div>
    <div class="div_break">
    </div>
   <%-- <div class="div_label">
        <asp:Label ID="lbl_company" runat="server" CssClass="Text" ToolTip="" placeHolder="" Text="Company Name"></asp:Label>
    </div>--%>
    <div class="div_ddlcompany">
        
    </div>
    <%--<div class="div_label">
        <asp:Label ID="lbl_month" runat="server"  Text="Month & Year"></asp:Label>
    </div>--%>
    <div class="div_ddlmonth">
       
    </div>
    <div class="div_yeartxt">
        
    </div>
    <div class="div_Getbtn">
       
    </div>
   <%-- <div class="div_break">
    </div>--%>
   <%-- <div class="div_label">
        <asp:Label ID="lbl_empname" runat="server" Text="Employee Name"></asp:Label>
    </div>--%>
    <div class="div_Emptxt">
        
    </div>
  <%--  <div class="div_label">
        <asp:Label ID="lbl_location" runat="server" Text="Location"></asp:Label>
    </div>--%>
    <div class="div_txt">
        
    </div>
   <%-- <div class="div_lbl">
        <asp:Label ID="lbl_Empcode" runat="server" Text="EmpCode"></asp:Label>
    </div>--%>
    <div class="div_yeartxt">
        
    </div>
    <div class="div_break">
    </div>
    
    <div class="div_break">
    </div>
    <div class="div_btn">
      
    </div>
    <div class="div_break">
    </div>
    <asp:Panel runat="Server" ID="PnlPay" CssClass="Pnl" Style="display: none;">
        <div class="div_Msg">
            
        </div>
        <br />
        <br />
        Payroll Process already Done for this month do you want do Re - Generate
        <br />
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="btn" OnClick="btnYes_Click" />
            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="btn" OnClick="btnNo_Click" />
        </div>
    </asp:Panel>
    <div class="div_Break">
    </div>
      <asp:Panel runat="Server" ID="pnlUpdate" CssClass="Pnl" Style="display: none;">
        <div class="div_Msg">
            
        </div>
        <br />
        <br />
       Do You Want to Clear Without Update
        <br />
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnYes1" runat="server" Text="Yes" CssClass="btn" OnClick="btnYes1_Click" />
            <asp:Button ID="btnNo1" runat="server" Text="No" CssClass="btn" OnClick="btnNo1_Click"  />
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ConUpdate" runat="server" TargetControlID="Label1" PopupControlID="pnlUpdate"
        BackgroundCssClass="modalBackground" />

      <div class="div_Break">
    </div>
    <asp:Button ID="btn_Emp" runat="server" Text="" Style="display: none;" OnClick="btn_Emp_Click" />
    <asp:Button ID="btn_Location" runat="server" Text="" Style="display: none;" OnClick="btn_Location_Click" />
   
    <asp:ModalPopupExtender ID="Confirm" runat="server" TargetControlID="hid_pln" PopupControlID="PnlPay"
        BackgroundCssClass="modalBackground" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Payroll Process #</label>

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
     <asp:Label ID="hid_pln" runat="server"></asp:Label>
     <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:HiddenField ID="hid_pln1" runat="server" />
    <asp:HiddenField ID="hid" runat="server" />
     <asp:HiddenField ID="pnlUp" runat="server" />
</asp:Content>
