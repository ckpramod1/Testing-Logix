<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="PlanProof.aspx.cs" Inherits="logix.HRM.PlanProof" %>
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




    <link href="../Styles/PlanProof.css" rel="stylesheet" type="text/css" />
       <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
     <script type="text/javascript">
         function pageLoad(sender, args) {
             $(document).ready(function () {
                 $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
             });


         }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">Reports</a> </li>
              <li class="current">All Plan Proof</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="All Plan Proof"></asp:Label></h4>
                </div>
          <div class="widget-content">
              <div class="FormGroupContent4">
                  <div class="PlanCompany"><asp:DropDownList ID="ddl_company" runat="server" CssClass="chzn-select" Data-placeholder="Company Name" ToolTip="Company Name"
            AppendDataBoundItems="True" AutoPostBack="True" 
            onselectedindexchanged="ddl_company_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="0">ALL</asp:ListItem>
        </asp:DropDownList></div>
                  <div class="PlanBranch"><asp:DropDownList ID="ddl_branch" runat="server" CssClass="chzn-select" data-placeholder="Branch Name" ToolTip="Branch Name"
            AppendDataBoundItems="True" AutoPostBack="True" 
            onselectedindexchanged="ddl_branch_SelectedIndexChanged" >
            <asp:ListItem Value="0" Text=""></asp:ListItem>
        </asp:DropDownList></div>
                  <div class="PlanYr"> <asp:DropDownList ID="ddl_Year" runat="server" CssClass="chzn-select" data-placeholder="Financial Year" ToolTip="Financial Year">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
        </asp:DropDownList></div>
                  <div class="PlanGross"> <asp:TextBox ID="txt_Gross" style="text-align:right;" runat="server" CssClass="form-control" placeholder="Gross" ToolTip="Gross"></asp:TextBox></div>
                  </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                    <div class="StatusLBL">  <asp:Label ID="lbl_House" runat="server" Text="House Rent"></asp:Label></div>
                   <div class="StautRad"><asp:RadioButton ID="Rbt_House_Proof" runat="server" Text="Proof  Received" 
            GroupName="Rbt" /></div>
                   <div class="StautRad">  <asp:RadioButton ID="Rbt_House_Unproof" runat="server" Text="Un-Proof  Received" 
            GroupName="Rbt" /></div>
                   <div class="StautRad1"> <asp:RadioButton ID="Rbt_House_NotDeclared" runat="server" Text="Not Declared" 
            GroupName="Rbt" /></div>
                   </div>
               <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                    <div class="StatusLBL">  <asp:Label ID="lbl_medical" runat="server" Text="Medical"></asp:Label></div>
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_Medical_Proof" runat="server" Text="Proof  Received" 
            GroupName="Rbt" /></div>
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_Medical_Unproof" runat="server" 
            Text="Un-Proof  Received" GroupName="Rbt" /></div>
                   <div class="StautRad1"><asp:RadioButton ID="Rbt_Medical_NotDeclared" runat="server" Text="Not Declared" 
            GroupName="Rbt" /></div>
                   </div>
               <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                    <div class="StatusLBL"><asp:Label ID="lbl_invest" runat="server" Text="Invest App"></asp:Label> </div>
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_Invest_Proof" runat="server" Text="Proof  Received" 
            GroupName="Rbt" /></div>
                   <div class="StautRad"><asp:RadioButton ID="Rbt_Invest_Unproof" runat="server" 
            Text="Un-Proof  Received" GroupName="Rbt" /></div>
                   <div class="StautRad1"> <asp:RadioButton ID="Rbt_Invest_NotDeclared" runat="server" Text="Not Declared" 
            GroupName="Rbt" /></div>
                   </div>
               <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                    <div class="StatusLBL"><asp:Label ID="lbl_Plan" runat="server" Text="All Plan"></asp:Label> </div>
                   <div class="StautRad"> <asp:RadioButton ID="Rbt_Plan_Proof" runat="server" Text="Proof  Received" 
            GroupName="Rbt" /></div>
                   <div class="StautRad">  <asp:RadioButton ID="Rbt_Plan_Unproof" runat="server" Text="Un-Proof  Received" 
            GroupName="Rbt" /></div>
                   <div class="StautRad1"> <asp:RadioButton ID="Rbt_Plan_NotDeclared" runat="server" Text="Not Declared" 
            GroupName="Rbt" /></div>
                   </div>
              <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="right_btn MT0 MB05">
                        <div class="btn ico-view"> <asp:Button ID="btn_View" runat="server" ToolTip="View" onclick="btn_View_Click" /></div>
                    </div>
                    </div>
              </div>
         </div>
            </div>
           </div>











 <div class="divTotal">
<div class="Header"></div>
    <div class="div_break">
    </div>
   <%-- <div class="div_label">
        <asp:Label ID="lbl_company" runat="server" Text="Company Name"></asp:Label>
    </div>--%>
    <div class="div_ddlcompany">
        
    </div>
    <div class="div_break">
    </div>
    <%--<div class="div_label">
        <asp:Label ID="lbl_branch" runat="server" Text="Branch Name"></asp:Label>
    </div>--%>
    <div class="div_ddlbranch">
        
    </div>
   <%-- <div class="div_Yearlbl">
        <asp:Label ID="lbl_Month" runat="server" Text="Financial Year"></asp:Label>
    </div>--%>
    <div class="div_ddlmonth">
       
    </div>
   <%-- <div class="div_lbl">
        <asp:Label ID="lbl_Year" runat="server" Text="Gross"></asp:Label>
    </div>--%>
    <div class="div_txt">
       
    </div>
    <div class="div_break">
    </div>
    <div class="div_Title">
       
    </div>
     <div class="div_break">
    </div>
    <div class="div_Radio">
       
    </div>
    <div class="div_Radio">
     
    </div>
    <div class="div_Radio">
      
    </div>
    <div class="div_break"></div>
     <div><hr /></div>
     
    <div class="div_Title">
       
    </div>
     <div class="div_break">
    </div>
    <div class="div_Radio">
      
    </div>
    <div class="div_Radio">
      
    </div>
    <div class="div_Radio">
       
    </div>
    <div class="div_break"></div>
      <div><hr /></div>
     
    <div class="div_Title">
        
    </div>
     <div class="div_break">
    </div>
    <div class="div_Radio">
      
    </div>
    <div class="div_Radio">
       
    </div>
    <div class="div_Radio">
      
    </div>
    <div class="div_break"></div>
      <div><hr /></div>
     
    <div class="div_Title">
        
    </div>
     <div class="div_break">
    </div>
    <div class="div_Radio">
      
    </div>
    <div class="div_Radio">
     
    </div>
    <div class="div_Radio">
      
    </div>
    <div class="div_break"> </div>
      <div><hr /></div>
     
    <div class="div_btn">
       
    </div>
    <div class="div_break"> </div>
   </div>
</asp:Content>
