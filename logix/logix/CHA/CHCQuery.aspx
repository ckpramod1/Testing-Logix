<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="CHCQuery.aspx.cs" Inherits="logix.CHA.CHCQuery" %>
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









    <link href="../Styles/CHCQuery.css" rel="stylesheet" />

    <style type ="text/css" >
      .modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        } 
          .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }     
    
         .Break
         {
             clear:both;
         }
         .grd-mt
         {
              display :none;
         }
         .hide
         {
             display:none;
         }
         #programmaticModalPopupBehavior1_foregroundElement {left:0px!important; top:50px!important;
        }
        #logix_CPH_pnlJobAE {top:50px!important; left:0px!important;
        }
    </style>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtconandprinc.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $.ajax({
                             url: "../CHA/CHCQuery.aspx/Getjobno",
                             data: "{ 'prefix': '" + request.term + "'}",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             success: function (data) {

                                 response($.map(data.d, function (item) {

                                     return {
                                         label: item.split('~')[0]

                                     }
                                 }))

                             },

                             error: function (response) {
                                 //alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alertify.alert(response.responseText);
                             }
                         });
                     },

                     select: function (event, i) {
                         $("#<%=txtconandprinc.ClientID %>").val(i.item.label);
                         $("#<%=txtconandprinc.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=txtconandprinc.ClientID %>").val(i.item.label);
                     },
                     change: function (event, i) {
                         $("#<%=txtconandprinc.ClientID %>").val(i.item.label);
                     },
                     close: function (event, i) {
                         $("#<%=txtconandprinc.ClientID %>").val(i.item.label);
                     },
                     minLength: 1
                 });
             });
         }
          </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

       <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="" id="headerlabel1" runat="server">Custom Home Agent</a> </li>
              <li><a href="#" title="">Shipment Details</a> </li>
              <li class="current"><a href="#" title="" id="header" runat="server">Consignee </a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label> </h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <asp:TextBox ID="txtconandprinc" runat="server" placeholder="Consignee" ToolTip="Consignee" AutoPostBack="true" CssClass="form-control"  OnTextChanged="txtconandprinc_TextChanged"></asp:TextBox>

                 </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="Shipper1"><asp:TextBox ID="txtjobno" runat="server" placeholder="Job #" ToolTip="Job #" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>
                   <div class="Consignee5"><asp:TextBox ID="txtJobtype" runat="server" placeholder="Job Type" ToolTip="Job Type" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                   <div class="Shipper1"><asp:TextBox ID="txtDocno" runat="server" placeholder="Doc #" ToolTip="Doc #" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  <div class="Consignee5"><asp:TextBox ID="txtMdocno" runat="server" placeholder="MDoc #" ToolTip="MDoc #" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                   <div class="Shipper1"><asp:TextBox ID="txtShipper" runat="server" placeholder="Shipper" ToolTip="Shipper" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  <div class="Consignee5"><asp:TextBox ID="txtCustomer" runat="server" placeholder="Customer" ToolTip="Customer" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                   <div class="Shipper1"><asp:TextBox ID="txtConsignee" runat="server" placeholder="Consignee" ToolTip="Consignee" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                   <div class="Consignee5">
                       <asp:TextBox ID="txtNotify" runat="server" placeholder="Notify Party" ToolTip="Notify Party" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                       </div>
                   </div>
              <div class="FormGroupContent4">
                  <div class="Shipper1"><asp:TextBox ID="txtPrincipal" runat="server" placeholder="Principal" ToolTip="Principal" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  <div class="Consignee5"><asp:TextBox ID="txtUser" runat="server" placeholder="User" ToolTip="User" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>

                  </div>
                <div class="FormGroupContent4">

                    <div class="Shipper1"><asp:TextBox ID="txtMode" runat="server" placeholder="Mode" ToolTip="Mode" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                     <div class="Consignee5"><asp:TextBox ID="txtDocuments" runat="server" placeholder="Documents" ToolTip="Documents" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                    </div>
               <div class="FormGroupContent4">

                   <div class="Shipper1"><asp:TextBox ID="txtCargo" runat="server" placeholder="Cargo" ToolTip="Cargo" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                   <div class="Consignee5"><asp:TextBox ID="txtVolume" runat="server" placeholder="Volume" ToolTip="Volume" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                   </div>
              <div class="FormGroupContent4">
                  <div class="Shipper1"><asp:TextBox ID="txtPod" runat="server" placeholder="Port of Destination" ToolTip="Port of Destination" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  <div class="Consignee5"><asp:TextBox ID="txtPol" runat="server" placeholder="Port of Loading" ToolTip="Port of Loading" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="Shipper1"> <asp:TextBox ID="txtfd" runat="server" placeholder="Place of Delivery" ToolTip="Place of Delivery" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                   <div class="Consignee5"><asp:TextBox ID="txtPkg" runat="server" placeholder="Packages" ToolTip="Packages" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                   </div>
              <div class="FormGroupContent4">
                  <div class="ConsigneeNet"><asp:TextBox ID="txtNet" runat="server" placeholder="Net Weight" ToolTip="Net Weight" CssClass="form-control" ReadOnly="true"></asp:TextBox> </div>
                  <div class="ConsigneeGross"><asp:TextBox ID="txtGross" runat="server" placeholder="Gross Weight" ToolTip="Gross Weight" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  <div class="ConsigneeDuty"><asp:TextBox ID="txtDuty" runat="server" placeholder="Duty PaidBy" ToolTip="Duty PaidBy" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  <div class="ConsigneeDate"><asp:TextBox ID="dtdocdte" runat="server" placeholder="Doc Date" ToolTip="Doc Date" CssClass="form-control"></asp:TextBox></div>

                  </div>
              <div class="FormGroupContent4">
                  <div class="div_Grid">
      
            <asp:GridView ID="grdEvent" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="False" Width="100%" 
                AllowPaging="false"  OnPageIndexChanging="Grd_Job_PageIndexChanging" 
                ForeColor="Black" ShowHeaderWhenEmpty="true"  PageSize="26" BackColor="White" OnSelectedIndexChanged="grdEvent_SelectedIndexChanged" >
                <Columns>
                    
                    <asp:TemplateField HeaderText ="EventDetails">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:225px">
                       <asp:Label ID="EventDetails" runat="server" Text='<%# Bind("EventDetails") %>' ToolTip='<%# Bind("EventDetails") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" width="225px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="Occured On">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="OccuredOn" runat="server" Text='<%# Bind("Occuredon") %>' ToolTip='<%# Bind("Occuredon") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" width="100px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText ="Remarks">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:150px">
                       <asp:Label ID="Remarks" runat="server" Text='<%# Bind("Remarks") %>' ToolTip='<%# Bind("Remarks") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" width="151px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                                                         
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>

            </div>

                  </div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-back" id="btnBack1" runat="server">
                           <asp:Button ID="btnBack" runat="server" ToolTip="Back" OnClick="btnBack_Click" />         
                      </div>
                  </div>
                  </div>

              </div>
         </div>
            </div>
           </div>

    
    <asp:Panel ID="pln_popup" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">
   
            <asp:GridView ID="Grd_Job" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="False" Width="100%" 
                AllowPaging="false"  OnPageIndexChanging="Grd_Job_PageIndexChanging" OnRowDataBound="Grd_Job_RowDataBound"
                ForeColor="Black" EmptyDataText="No Record Found" PageSize="26" BackColor="White"
                OnSelectedIndexChanged="Grd_Job_SelectedIndexChanged">
                <Columns>
                    
                    <asp:TemplateField HeaderText ="Job#">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="Job" runat="server" Text='<%# Bind("JobNo") %>' ToolTip='<%# Bind("JobNo") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="61px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="JobType">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>' ToolTip='<%# Bind("JobType") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="60px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText ="DocNo">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="DocNo" runat="server" Text='<%# Bind("DocNo") %>' ToolTip='<%# Bind("DocNo") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="60px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                  
                    <asp:TemplateField HeaderText ="MdocNo">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:75px">
                       <asp:Label ID="MdocNo" runat="server" Text='<%# Bind("MdocNo") %>' ToolTip='<%# Bind("MdocNo") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="75px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
         
                    <asp:TemplateField HeaderText ="Customer">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:145px">
                       <asp:Label ID="Customer" runat="server" Text='<%# Bind("Customer") %>' ToolTip='<%# Bind("Customer") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="146px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="Shipper">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="Shipper" runat="server" Text='<%# Bind("Shipper") %>' ToolTip='<%# Bind("Shipper") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="80px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="Consignee">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:120px">
                       <asp:Label ID="Consignee" runat="server" Text='<%# Bind("Consignee") %>' ToolTip='<%# Bind("Consignee") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="121px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="POL">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>' ToolTip='<%# Bind("POL") %>' ></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="60px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                   <asp:TemplateField HeaderText ="POD">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="POD" runat="server" Text='<%# Bind("POD") %>' ToolTip='<%# Bind("POD") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="60px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="FD">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="FD" runat="server" Text='<%# Bind("FD") %>' ToolTip='<%# Bind("FD") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="60px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                    
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>

              <div class="div_Break"></div>
                     
         </asp:Panel>
        </div>     

    </asp:Panel>

    <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup" BehaviorID="programmaticModalPopupBehavior1"
         TargetControlID="Label3" CancelControlID="imgfgok">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label3" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:calendarextender ID="dtfrom_cal" Format="dd/MM/yyyy" runat="server" Enabled="True" TargetControlID="dtdocdte"  />                     
    
    <asp:HiddenField ID="hid_jobid" runat="server" />

</asp:Content>
