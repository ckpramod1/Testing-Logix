<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="HRMMis.aspx.cs" Inherits="logix.HRM.HRMMis" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <style type="text/css">
        .MISCal3 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6%;
}
        .MISCal4 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6%;
}

        .MISEmployeelist {
    float: left;
    margin: 0 0.5% 0 0;
    width: 8%;
}
        .MISEmployeeLeft {
    float: left;
    margin: 0 0.5% 0 0;
    width: 11%;
}
        .MISCTC {
    float: left;
    margin: 0 0.5% 0 0;
    width: 4%;
}
        .MISPending {
    float: left;
    margin: 0 0.5% 0 0;
    width: 11%;
}
        .MISPackages {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6%;
}
        .MISSalary {
    float: left;
    margin: 0 0.5% 0 0;
    width: 4.5%;
}
        .MISCompansation {
    float: left;
    margin: 0 0.5% 0 0;
    width: 8%;
}
        .MISContribution {
    float: left;
    margin: 0 0.5% 0 0;
    width: 7%;
}
        .MISAllow {
    float: left;
    margin: 0 0.5% 0 0;
    width: 7%;
}
    </style>



    <link href="../Styles/HRMMis.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
             <li><i class="icon-home"></i><a href="#"></a>Home </li>
             <li><a href="#">Corporate</a></li>
              <li><a href="#" title="">MIS</a> </li>
              <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">MIS</a> </li>
            </ul>
      </div>
          <!-- /Breadcrumbs line -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/mis-ic.png" /> <asp:Label ID="lblhrmMis" runat="server" Text="MIS"></asp:Label>
        
      </h3>
    </div>
        <div class="Form-ControlBg">
                       <div class="FormGroupContent4 MARginCtrlW">
                    <div class="MISEmployeelist"><asp:RadioButton ID="rbtnEList" runat="server" Text="Employee List" GroupName="rbtnEList" AutoPostBack="true" OnCheckedChanged="rbtnEList_CheckedChanged" /></div>
                     <div class="MISEmployeeLeft"><asp:RadioButton ID="rbtnEmp" runat="server" Text="Employee[New/Left]" AutoPostBack="true" GroupName="rbtnEList" OnCheckedChanged="rbtnEmp_CheckedChanged" /> </div>
                   <div class="MISCTC"><asp:RadioButton ID="rbtnCtc" runat="server" Text="CTC" GroupName="rbtnEList" AutoPostBack="true" OnCheckedChanged="rbtnCtc_CheckedChanged" /></div>
                    <div class="MISPending"><asp:RadioButton ID="rbtnPendingCon" runat="server" Text="Pending confirmation" GroupName="rbtnEList" AutoPostBack="true" OnCheckedChanged="rbtnPendingCon_CheckedChanged" /></div>
                    <div class="MISLoyality"><asp:RadioButton ID="rbtnLoyality" runat="server" Text="Loyalty" GroupName="rbtnEList" AutoPostBack="true" OnCheckedChanged="rbtnLoyality_CheckedChanged" /></div>
                     </div>
                 <div class="FormGroupContent4 MARginCtrlW">
                     <div class="MISPackages"><asp:CheckBox ID="chboxPackages" runat="server" Text="Packages" AutoPostBack="true" OnCheckedChanged="chboxPackages_CheckedChanged"/></div>
                     <div class="MISSalary"><asp:RadioButton ID="rbtnSalary" Enabled="false" runat="server" Text="Salary" GroupName="rbtnSalary" AutoPostBack="true" OnCheckedChanged="rbtnSalary_CheckedChanged" /></div>
                     <div class="MISCompansation"><asp:RadioButton ID="rbtnCompensation" Enabled="false" runat="server" Text="Compensation" GroupName="rbtnSalary" AutoPostBack="true" OnCheckedChanged="rbtnCompensation_CheckedChanged" /></div>
                     <div class="MISContribution"><asp:RadioButton ID="rbtnContribution" Enabled="false" runat="server" Text="Contribution" GroupName="rbtnSalary" AutoPostBack="true" OnCheckedChanged="rbtnContribution_CheckedChanged" /></div>
                     <div class="MISAllow"><asp:RadioButton ID="rbtnAllowences" Enabled="false" runat="server" Text="Allowences" AutoPostBack="true" OnCheckedChanged="rbtnAllowences_CheckedChanged" GroupName="rbtnSalary" /></div>
                     <div class="MISCal3"><asp:TextBox ID="txtFromdate" Enabled="false" runat="server" CssClass="form-control" ToolTip="From Date"></asp:TextBox><ajaxtoolkit:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender2" TargetControlID="txtFromdate" runat="server" /></div>
                     <div class="MISCal4"><asp:TextBox ID="div_Totxt" Enabled="false" runat="server" CssClass="form-control" ToolTip="ToDate"></asp:TextBox><ajaxtoolkit:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender1" TargetControlID="div_Totxt" runat="server" /></div>
                     <div class="right_btn MT0 MB05">
                         <div class="btn ico-print"><asp:Button ID="btnprint" runat="server" ToolTip="Print" OnClick="btnprint_Click" /></div>
                         <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btncancel" runat="server" ToolTip="Cancel" OnClick="btncancel_Click" /></div>
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
            <div class="widget-content" >
     
                </div>
         </div>
            </div>
        </div>


</asp:Content>
