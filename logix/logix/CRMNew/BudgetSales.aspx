<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation ="false"    AutoEventWireup="true" CodeBehind="BudgetSales.aspx.cs" Inherits="logix.CRMNew.BudgetSales" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
       <link href="../Theme/assets/css/systemcrmnewcs.css" rel="stylesheet" type="text/css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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

 <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>
    <link href="../Styles/BudgetSalesCrm.css" rel="stylesheet" />   
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
    <%--<script type="text/javascript"> </script>--%>
  <script type="text/javascript">
      function pageLoad(sender, args) {
          $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
      }
      </script>

    <style type ="text/css" >
        .modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        } 
        .modalPopupss { 
            background-color:#F5F5F2; 
            border-width:1px; 
            border-style:solid; 
            border-color:#CCCCCC; 
            margin-left:-4%;
            padding:1px; 
            width:700px; 
            Height:290px; 
           
           
        } 
     .div_Menu
    {
     
        float:left; 
       
        width :99.9%; 
        /*width :99%;*/ 
       
        /*margin-right :1%;*/
        height:100%;
     
        
    }
        .divRoated
        {
            width:700px; 
         Height:290px; 
            /*width:100%; 
            Height:100%;*/ 
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }

         .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98%;
            margin-top:-2.5%;
            border-radius: 90px 90px 90px 90px;
        }
        
         .Gridpnl   
         {
         Height:280px; 
     
         
         
            margin-left:0.2%;
            /*margin-top:-0.5%;*/
         }

         .Break
         {
             clear:both;
         }
         .grd-mt
         {
              display :none;
         }
      
		a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}

    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     <asp:Panel ID="PnlTotal" runat="server" class="PnlTotal">

           <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">CRM</a> </li>
              <li class="current"><a href="#" title="">Budget</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lblheader" runat="server" Text="Budget vs Actual"></asp:Label></h4>
                </div>
          <div class="widget-content">
              <div class="FormGroupContent4">
                  <div class="CompanyTxt"><asp:TextBox id ="txtcompany" runat="server" placeholder=" Company Name" CssClass="form-control"  AutoPostBack="true" TabIndex="0" ToolTip="CompanyName" ></asp:TextBox></div>
                  <div class="BranchDrop3"> <asp:DropDownList data-placeholder="Select Branch" ID="ddllocation" runat="server" AutoPostBack="true"  Height ="24px" BorderColor="#999997" CssClass="chzn-select"  ToolTip="Select Branch" Width ="100%" Enabled="False" >
            <asp:ListItem Text="" Value="0"></asp:ListItem>
        </asp:DropDownList></div>
                  <div class="MonthDrop1"> <asp:DropDownList data-placeholder="Month" ID="ddlmonth" runat="server"  CssClass="chzn-select"  Height ="24px" BorderColor="#999997"  ToolTip="Butget for The Month Of" Width ="100%" >
             <asp:ListItem Text="" Value="0">Month</asp:ListItem>          
            <asp:ListItem Value="1">January</asp:ListItem>
            <asp:ListItem Value="2">Febraury</asp:ListItem>
            <asp:ListItem Value="3">March</asp:ListItem>
            <asp:ListItem Value="4">April</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">June</asp:ListItem>
            <asp:ListItem Value="7">July</asp:ListItem>
            <asp:ListItem Value="8">August</asp:ListItem>
            <asp:ListItem Value="9">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList></div>
                  <div class="YearDrop">
                       <asp:DropDownList  data-placeholder="Year" ID="ddlyear" runat="server" CssClass="chzn-select"  BorderColor="#999997"  Height ="24px" ToolTip="Butget for The Year Of" Width ="100%">
        </asp:DropDownList>
                  </div>

                  </div>
              <div class="FormGroupContent4">
                  <div class="right_btn MB10 MT0">
                      <div class="btn ico-view">
                          <asp:Button ID="btn_view" runat="server" ToolTip="Get" OnClick ="btn_view_Click"  />
                      </div>
                  </div>
                  </div>
               <div class="FormGroupContent4">
                   <asp:Panel ID="grdcmailpanel" runat="server" CssClass="Grid FixedHeader" >
  <div style ="background-color :navy; height :5%; width:100% ;font-family :sans-serif ; color:white ;font-size :9pt;  font-weight :bold;  " > 
   <div style ="margin-top :0%; text-align :center ;"><asp:Label ID="lblBudget" runat="server" style ="margin-top :5%; font-size :9pt; font-family :Arial ;"  Text="Budget For The Month of"></asp:Label></div></div>
  <asp:GridView ID="grdsales" runat="server"  Width="100%" 
  GridLines="None"
  HeaderStyle-CssClass="gvHeader"
  CssClass="gvRow" 
  AlternatingRowStyle-CssClass="gvAltRow" ShowHeaderWhenEmpty ="true" 
  AutoGenerateColumns="false" OnRowDataBound="grdsales_RowDataBound" OnSelectedIndexChanged="grdsales_SelectedIndexChanged1">
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
        <th colspan="7"></th>
        <tr class="gvHeader">
           <th style="width:0px"></th>
           <th colspan="2">Product </th>
           <th colspan="2">Budgeted</th>                        
           <th colspan="3"><asp:Label ID="lblyear" runat="server" Text=""></asp:Label> -Actuals</th>
        </tr>
      

      </HeaderTemplate> 
    
    </asp:TemplateField>

                    <asp:BoundField DataField="Product" HeaderText="Product" >
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="GridHeader" />
                    <ItemStyle HorizontalAlign="Left" Width="150px"  />
                    </asp:BoundField>

                     <asp:BoundField DataField="unittype" HeaderText="UnitType" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="GridHeader"   />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="unit" HeaderText="Unit" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="GridHeader" />
                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                    </asp:BoundField>
      
                    <asp:BoundField DataField="vactual" HeaderText="Retention" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="GridHeader"  />
                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                    </asp:BoundField>

             
                    <asp:BoundField DataField="volume" HeaderText="Unit" HtmlEncode="false" DataFormatString="{0:N0}" >
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="GridHeader"  />
                    <ItemStyle HorizontalAlign="Right" Width="10%"  />
                    </asp:BoundField>
               
                    <asp:BoundField DataField="rbudget" HeaderText="Retention">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true"   CssClass="GridHeader"/>
                    <ItemStyle HorizontalAlign="Right" Width="10%"   />
                   </asp:BoundField>
              
                <asp:BoundField DataField="trantype" HeaderText="Trantype" >
                <HeaderStyle CssClass="hide" />
                <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="jobtype" HeaderText="jobtype" >
                <HeaderStyle CssClass="hide" />
                <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField HeaderText="bid" DataField="bid">
                <HeaderStyle CssClass="hide" />
                <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="subprod" HeaderText="subproduct" >
              
                <HeaderStyle CssClass="hide" />
                <ItemStyle CssClass="hide" />
                </asp:BoundField>

                <asp:TemplateField  HeaderStyle-CssClass="GridHeader">
                   <ItemTemplate>
                  <asp:ImageButton ID="imgbutton" runat="server" ImageUrl="~/images/left_arrow.png" Width="10px" Height="10px" OnClick="imgbutton_Click" />
                   </ItemTemplate>
                   <ItemStyle Width="15px" />
               </asp:TemplateField>


  </Columns>

 <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass=""/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
       
             <RowStyle CssClass="GrdRow" />
</asp:GridView>

</asp:Panel>
                   </div>
              <div class="FormGroupContent4">
                    <div class="txtSalesPer"><asp:TextBox id ="txtSales" runat="server" placeholder="Sales Person Name"  CssClass="form-control "  AutoPostBack="true" TabIndex="0" ToolTip="Sales Person Name" Enabled="False" ></asp:TextBox></div>
                  </div>

              <div class="FormGroupContent">
                    <asp:Label ID="lblAI" runat="server" ></asp:Label>


     <ajaxtoolkit:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="lblAI"  BehaviorID="programmaticModalPopupBehavior1"
                                PopupControlID="pnlJobAE"   
                                BackgroundCssClass="modalBackground" CancelControlID="imgfgok">
     </ajaxtoolkit:ModalPopupExtender>

     <asp:Panel ID="pnlJobAE" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display :none ;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel3" runat="server"  ScrollBars="None"  CssClass="Gridpnl" >
         
   <iframe id="ifrmaster" name="centerfrm" width ="100%" height ="100%" class="div_Menu" frameborder="0"  scrolling="no" runat="server"></iframe>

   -  </asp:Panel>

    
      <div class="Break"> </div>
      </div>

       </asp:Panel>
              </div>
              </div>
         </div>
            </div>
           </div>




     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>

</asp:Panel> 
</asp:Content>
