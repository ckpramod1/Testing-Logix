<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MISBT.aspx.cs" Inherits="logix.MIS.MISBT" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
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



    <link href="../Styles/MISBT.css" rel="stylesheet" />
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {

                $("#<%=txt_name.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hd_cust.ClientID %>").val(0);
                        $.ajax({
                            url: "MIS.aspx/GetCustomers",
                            data: "{ 'prefix': '" + request.term + "','FType':'" + $("#<%=hd_cust.ClientID %>").val() + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

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
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=txt_name.ClientID %>").change();
                        $("#<%=hd_cust.ClientID %>").val(i.item.val);
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=txt_name.ClientID %>").val(i.item.label);
                            $("#<%=hd_cust.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_name.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_name.ClientID %>").val($.trim(result));
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
             <li><a href="#">Bonded Trucking</a></li>
              <li><a href="#" title="">MIS</a> </li>
              <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">MIS</a> </li>
            </ul>
      </div>
          <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
   
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_head" runat="server" Text="MIS"></asp:Label></h4>
                </div>
            <div class="widget-content" >
                <div class="FormGroupContent4">
                    <div class="JobWiseLBL"><asp:RadioButton ID="rd_jobwise" runat="server" Text="Jobwise Costing" GroupName="radio" /></div>
                    <div class="JobNomiLBL"><asp:RadioButton ID="rd_noVSF" runat="server" Text="Nomination Vs Freehand"  GroupName="radio" /></div>
                    <div class="JobShip"><asp:RadioButton ID="rd_shipment" runat="server" Text="Shipment Details" GroupName="radio" /></div>
                    <div class="JobShiper"><asp:RadioButton ID="rd_shipper" runat="server" Text="Shipperwise"  GroupName="radio" /></div>
                    <div class="JobConsignee"><asp:RadioButton ID="rd_consignee" runat="server" Text="Consigneewise" GroupName="radio" /></div>
                    </div>
                <div class="FormGroupContent4">
                    <div class="JobWiseLBL"><asp:RadioButton ID="rd_agent" runat="server" Text="Agentwise"  GroupName="radio" /></div>
                    <div class="JobNomiLBL"><asp:RadioButton ID="rd_oppprofit" runat="server" Text="OperatingProfit" GroupName="radio" /></div>
                    <div class="JobShip"><asp:RadioButton ID="rd_sales" runat="server" Text="SalesPerson"  GroupName="radio" /></div>
                    <div class="JobShiper"><asp:RadioButton ID="rd_nomination" runat="server" Text="Nomination"  GroupName="radio" /></div>
                    <div class="JobConsignee"><asp:RadioButton ID="rd_freehand" runat="server" Text="FreeHand"  GroupName="radio" /></div>
                    </div>
                <div class="FormGroupContent4">
                    <div class="JobWiseLBL"><asp:RadioButton ID="rd_pol" runat="server" Text="Port Of Loading"  GroupName="radio" /></div>
                    <div class="JobNomiLBL"><asp:RadioButton ID="rd_pod" runat="server" Text="Port Of Discharge" GroupName="radio" /></div>
                    <div class="JobShip"><asp:RadioButton ID="rd_lossJob" runat="server" Text="Loss Jobs"  GroupName="radio" /></div>
                    <div class="JobShiper"><asp:RadioButton ID="rd_top50ship" runat="server" Text="Top 50 Shipper/Consignee"  GroupName="radio" /></div>
                    <div class="JobConsignee"><asp:RadioButton ID="rd_retention" runat="server" Text="Retention for N/F"  GroupName="radio" /></div>
                    </div>
                <div class="FormGroupContent4">
                    <div class="JobWiseLBL"><asp:RadioButton ID="rd_frwdwise" runat="server" Text="ForwarderWise - Imports"  GroupName="radio" /></div>
                    <div class="JobNomiLBL"><asp:RadioButton ID="rd_doreg" runat="server" Text="DO Register"  GroupName="radio" /></div>
                    <div class="JobShip"><asp:RadioButton ID="rd_mis" AutoPostBack="true" runat="server" Text="M I S" GroupName="radio" OnCheckedChanged="rd_mis_CheckedChanged" /></div>
                    <div class="JobShiper"><asp:RadioButton ID="rd_yearmis" runat="server" Text="Year M I S"  GroupName="radio" /></div>
                    <div class="JobConsignee"><asp:RadioButton ID="rd_revenue" runat="server" Text="Revenue"  GroupName="radio" /></div>
                    </div>
                <div class="FormGroupContent4">
                    <div class="JobWiseLBL"><asp:RadioButton ID="rd_regaudit" runat="server" Text="DO Register Audit"  GroupName="radio" /></div>
                    <div class="JobNomiLBL"><asp:RadioButton ID="rd_canaudit" runat="server" Text="CAN Audit"  GroupName="radio" /></div>
                    <div class="JobShip"><asp:RadioButton ID="rd_canauditAI" runat="server" Text="CAN Audit AI"  GroupName="radio" /></div>
                   
                    </div>
                <div class="bordertopNew"></div>
                 <div class="FormGroupContent4">
                     <asp:TextBox ID="txt_name" runat="server" ToolTip="Name" placeholder="Name" CssClass="form-control"></asp:TextBox>
                     </div>
                  <div class="bordertopNew"></div>
                 <div class="FormGroupContent4">
                     <div class="MISFromLbl1"><asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label></div>
                     <div class="MISFromCal"><asp:TextBox ID="txt_from" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from"
            Format="dd/MM/yyyy">
        </asp:CalendarExtender></div>
                     <div class="MISToLabl"><asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label></div>
                     <div class="MISToCal2"><asp:TextBox ID="txt_to" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to"
            Format="dd/MM/yyyy">
        </asp:CalendarExtender></div>
                     <div class="right_btn MT0 MB05">
                         <div class="btn ico-excel"><asp:Button ID="btn_export" runat="server" ToolTip="Export To Excel"  OnClick="btn_export_Click"/></div>
                         <div class="btn ico-print"><asp:Button ID="btn_print" runat="server" ToolTip="Print"  OnClick="btn_print_Click"/></div>
                         <div class="btn ico-cancel" id="btn_back1" runat="server"><asp:Button ID="btn_back" runat="server" ToolTip="Back"  OnClick="btn_back_Click"/></div>

                     </div>
                     </div>
                </div>
         </div>
            </div>
        </div>


     <asp:GridView ID="Temp_Grid" runat="server" AutoGenerateColumns="true" CssClass="Grid FixedHeader"  Visible="false">
        <Columns></Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <AlternatingRowStyle CssClass="GrdAltRow" />
    </asp:GridView>
    <asp:Label ID="LblCncl" runat="server" ></asp:Label>
        <asp:ModalPopupExtender ID="popuprate" runat="server"  TargetControlID="LblCncl"  
        BehaviorID="frgtydfdfdf"
        PopupControlID="pnlcncl"  CancelControlID="imgcls" DropShadow="false">
        </asp:ModalPopupExtender>



    <asp:Panel ID="pnlcncl" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px"  style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
       <asp:Panel ID="Panel3" runat="server"  ScrollBars="Vertical"  CssClass="Gridpnl">
             <iframe id="iframe_buyratequery" width="100%" height="100%" runat="server" src="../Accounts/RetentionPerunit.aspx" frameborder="0" ></iframe>
          
           </asp:Panel>
              
            <div class="Break"> </div>
        <div class="Break"> </div>
        <div class="Break"> </div>
      </div>
              <div class="Break"> </div>
        <div class="Break"> </div>
        <div class="Break"> </div>
        
       </asp:Panel>
    
    <asp:HiddenField ID="hd_cust" runat="server" />


    
   
</asp:Content>
