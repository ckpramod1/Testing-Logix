<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="JMIS2.aspx.cs" Inherits="logix.MIS.JMIS2" %>
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




    <link href="../Styles/JMIS2.css" rel="stylesheet" />
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

                    <div class="MISForm"><asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label></div>
                    <div class="MISFormCal"><asp:TextBox ID="txt_from" runat="server"  CssClass="form-control" ToolTip="From" placeholder="From"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from"
            Format="dd/MM/yyyy">
        </asp:CalendarExtender></div>
                    <div class="MISTo11"><asp:Label ID="Label1" runat="server" Text="To"></asp:Label></div>
                    <div class="MISToCal"><asp:TextBox ID="txt_to" runat="server"  CssClass="form-control" ToolTip="To" placeholder="To"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to"
            Format="dd/MM/yyyy">
        </asp:CalendarExtender></div>
                    <div class="right_btn MT0">
                        <div class="btn ico-get"><asp:Button ID="btn_get" runat="server" ToolTip="Get"  OnClick="btn_get_Click" /></div>
                        <div class="btn ico-print"><asp:Button ID="btn_print" runat="server" ToolTip="Print" OnClick="btn_print_Click" /></div>
                        <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Back"  OnClick="btn_cancel_Click" /></div>
                        <div class="btn btn-job1"><asp:Button ID="btn_Jobdetails" runat="server" ToolTip="JobDetails"  OnClick="btn_Jobdetails_Click" /></div>

                    </div>
                    </div>


                <div class="FormGroupContent4">
                    <asp:Panel ID="Pln_MIS" runat="server" >
            <asp:Label ID="lbl_MISA" runat="server" Text="Jobs Opened,Sailed / Arrived  & Closed during  the Given  Period - A"
                ForeColor="Red" CssClass="LabelValue"></asp:Label>
            <br />
            <asp:Panel ID="pnl_MISA" runat="server" Height="120px" ScrollBars="Vertical">
                 <asp:GridView ID="Grd_MISA" runat="server" CssClass="Grid FixedHeader"  Width="100%" ForeColor="Black"
                     ShowHeaderWhenEmpty="true" ShowHeader="true"  AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                    <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                    <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                    <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
            </asp:Panel>
           
            <br />
            <asp:Label ID="lbl_MISB" runat="server" Text="Jobs Opened,Sailed / Arrived  & Closed in Previous Months but voucher Generated during the given Period - B"
                ForeColor="Red" CssClass="LabelValue"></asp:Label>
            <br />
            <asp:Panel ID="pnl_MISB" runat="server" ScrollBars="Vertical" Height="120px">
            <asp:GridView ID="Grd_MISB" runat="server" CssClass="Grid GrdRow" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                    <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                    <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                    <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
                </asp:Panel>
            <br />
            <asp:Label ID="lbl_MISC" runat="server" Text="Jobs Opened but not Sailed / Arrived  during the given Period &  Unclosed - C"
                ForeColor="Red" CssClass="LabelValue" ></asp:Label>
            <br />
            <asp:Panel ID="Panel_MISC" runat="server" ScrollBars="Vertical" Height="120px">
                <asp:GridView ID="Grd_MISC" runat="server" CssClass="Grid GrdRow" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                    <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                    <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                    <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
            </asp:Panel>
            
            <%--<br />--%>
            <div class="div_Break"></div>
            <asp:Label ID="lbl_MISD" runat="server" Text="Jobs Opened,Sailed / Arrived  During the given Period but Unclosed  - D"
                ForeColor="Red" CssClass="LabelValue"></asp:Label>
            <br />
            <asp:Panel ID="Panel_MISD" runat="server" ScrollBars="Vertical" Height="120px">
                <asp:GridView ID="Grd_MISD" runat="server" CssClass="Grid GrdRow" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                    <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                    <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                    <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
            </asp:Panel>
            
            <br />
            <asp:Label ID="lbl_retention" runat="server" Text=""  ForeColor="Red" CssClass="LabelValue"></asp:Label>
        </asp:Panel>


                    </div>

                

                </div>
         </div>
            </div>
        </div>












    <div class="div_total">
        <div class="Header"></div>
        <div class="div_Break"></div>
        <div class="div_from"> </div>
        <div class="txt_from"> 
        </div>
        <div class="div_from"> </div>
        <div class="txt_from"> 
        </div>
        <div class="div_button"></div>
        <div class="div_button"></div>
        <div class="div_button"></div>
        <div class="div_button"></div>
        <div class="div_Break"></div>
        
        <div class="div_Break"></div>
    </div>
</asp:Content>
