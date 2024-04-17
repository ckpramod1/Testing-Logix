<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="logix.HRM.Form1" %>

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
        .Form-ControlBg .ExcelSalary label{margin:0px 0px 0px 5px;
        }
        .Form-ControlBg .ExcelEA label {margin:0px 0px 0px 5px;
        }
        .Form-ControlBg .ExcelEL label{margin:0px 0px 0px 5px;
        }
        .Form-ControlBg .ExcelLTA label{margin:0px 0px 0px 5px;
        }
        .Form-ControlBg .ExcelIncen label{margin:0px 0px 0px 5px;
        }
        .ExcelFile {
    width: 40%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
    </style>

    <link href="../Styles/Form1.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

        <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">HRM</a> </li>
              <li class="current">Excel Reader</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

    
      <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/excelreader_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Excel Reader"></asp:Label>
        
      </h3>
    </div>
        <div class="Form-ControlBg">

            <div class="FormGroupContent4 MB05">
                 <div class="ExcelFile"><asp:FileUpload ID="Txt_Path" runat="server" width="100%" CssClass="form-control"></asp:FileUpload></div>
                  
               
                     <div class="btn btn-import1"><asp:Button ID="Btn_Import" runat="server" ToolTip="Import" OnClick="Btn_Import_Click" /></div>
                
                 </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4 MB05">
                   <div class="ExcelSalary"> <asp:RadioButton ID="rdsalryupld" runat="server" Text="Salary Details" GroupName="rbt" /></div>
                   <div class="ExcelEA"> <asp:RadioButton ID="rdEAupld" runat="server" Text="EA Details" GroupName="rbt" /></div>
                   <div class="ExcelEL"> <asp:RadioButton ID="rdELupld" runat="server" Text="EL Details" GroupName="rbt" /></div>
                   <div class="ExcelLTA"><asp:RadioButton ID="rdLTAupld" runat="server" Text="LTA Details" GroupName="rbt" /></div>
                   <div class="ExcelIncen"><asp:RadioButton ID="rdIncentiveupld" runat="server" Text="Incentive  Details" GroupName="rbt" /></div>
                   </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="div_Grid">
           <asp:GridView ID="grdview" runat="server" CssClass="NewThemeTbl" Width="100%" OnRowDataBound="grdview_RowDataBound" >

            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>
              </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="right_btn MT0 MB05">
                        <div class="btn ico-upload"><asp:Button ID="BtnUpload" runat="server" ToolTip="Upload" OnClick="BtnUpload_Click" /></div>
                   <div class="btn ico-back" id="btn_back1" runat="server"><asp:Button ID="btnback" runat="server" ToolTip="Back" /></div>


                   </div>
                  
                   </div>
            </div>
          </div>






    

</asp:Content>
