<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProcessITComput.aspx.cs" Inherits="logix.HRM.ProcessITComput" %>

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






    
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>    
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

    <style type="text/css" > 
        a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}

    </style>
       
    <style type="text/css" > 

        .GridView
        {           
            font-family:sans-serif;
            font-size:10pt;
            color:Black;
            margin-top: 0px;
            
        }

         .div_GridNew3
        {
        width:100%;
        margin-left :0%;        
        margin-bottom :1%;   
        margin-top:0.1%;     
        height:500px;
        Border :1px solid #b1b1b1;
        float :left;
        overflow:auto;
        }

    </style>


    <link href="../Styles/ITComputation.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>  

   </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH"  runat="server">


     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">IT Workings</a> </li>
              <li class="current"> Process IT Computation</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="Process IT Computation"></asp:Label></h4>
                </div>
          <div class="widget-content">
              <div class="FormGroupContent4">
                  <asp:TextBox ID="lblMsg" runat="server" visible="false"></asp:TextBox>
                  <asp:Panel runat="server" CssClass="TblReport">
            <asp:GridView ID="GV_ProcessIT" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="true" AllowPaging="false" PageSize="16" OnPageIndexChanging="GV_ProcessIT_PageIndexChanging" OnRowDataBound="GV_ProcessIT_RowDataBound" >
                <PagerStyle CssClass="GridviewScrollPager" />                            
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>  
                      </asp:Panel> 
                  </div>
              <div class="FormGroupContent4">
                  <div class="FloatLeft">
                        <asp:Label ID="lblMsg1" runat="server" Width="200px"></asp:Label>
            <asp:Label ID="lblMsg2" runat="server" Width="180px"></asp:Label>
                      <div class="btn ico-excel">  <asp:Button ID="Btn_Excel" runat="server" ToolTip="Export To Excel"  OnClick="Btn_Excel_Click"  />
          
            </div>
                     
                      
                  </div>
                   <div class="right_btn MT0 MB05"><div class="btn ico-back"><asp:Button ID="Btn_Back" runat="server" ToolTip="Back"  OnClick="Btn_Back_Click"  /></div></div>

                  </div>
              </div>
         </div>
            </div>
           </div>






    
       
</asp:Content>
