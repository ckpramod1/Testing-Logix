<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterTask.aspx.cs" EnableEventValidation="false" Inherits="logix.Maintenance.MasterTask" %>

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
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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


    <link href="../Styles/AEJobInfo.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

      <script type="text/javascript">
          function dropdownButton() {
              $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
          }
      </script>


  <%--TEST--%>
  <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
  <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
  <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
  <link href="../Styles/ControlStyle2.css" rel="stylesheet" />

 <style type="text/css">f
     table#logix_CPH_grd th:nth-child(3) {
    width: 150px !important;
}
     .BillType1 {
    width: 12.6%;
    float: left;
    margin: 0px 0% 0px 0.5%;
}
.CustomerName12 {
    margin-left: 5px;
    float: left;
    width: 50%;
    margin-top: 0px !important;
}
table#logix_CPH_grd th:nth-child(3) {
    width: 248px !important;
}
div#logix_CPH_btnsave1 {
    float: right;
}
div#UpdatePanel1 {
    /* height: 100vh; */
   
    overflow-x: hidden;
    overflow-y: auto;
}
div#logix_CPH_Panel31 {
    height: 823px !important;
}

.chzn-container .chzn-results {
    margin: 0 4px 4px 0;
    min-height: auto;
    padding: 0 0 0 4px;
    position: relative;
    
}
.TextField .chzn-container .chzn-drop {
    top: 54px !important;
    width: 100% !important;
    height:193px !important;
}
div#logix_CPH_Panel31 {
    height: 823px !important;
}
.PageHeight {
    padding-top: 6px;
    height: 100vh;
    padding-bottom: 8px;
}
.BillOfInput {
    width: 14%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
     table#logix_CPH_Grd_Customer td:nth-child(3) {
         text-overflow: ellipsis !important;
         width: 162px !important;
         overflow: hidden !important;
         display: inline-block;
     }
     div#logix_CPH_Div1 {
    float: right;
}
table input[type="text"], table input[type="checkbox"] {
    margin: 0px !important;
    font-size: 14px !important;
    background: transparent;
    margin-left: 12px !important;
}
     /*.TextField .chzn-container-single .chzn-single {
    background: white !important;
    box-shadow: none !important;
    height: 48px !important;
    line-height: 8px !important;
    margin: 6px 0px 0px 0px !important;
}
     .TextField .chzn-container-single .chzn-single {
    background: white !important;
    box-shadow: none !important;
    height: 12px !important;
    line-height: 8px !important;
    margin: 6px 0px 0px 0px !important;
}*/
 /*    table .chzn-container-single .chzn-single {
    margin: 0px !important;
    height: 20px !important;
}*/
 


table#logix_CPH_grd .TextField .chzn-container-single .chzn-single {
    background: white !important;
    box-shadow: none !important;
    height: 26px !important;
    line-height: 10px !important;
    /* margin: 10px 0px 0px 0px !important; */
    margin: -4px 0px 0px 0px !important;
}
 table#logix_CPH_grd .chzn-container {
    font-size: 11px;
    position: relative;
    display: inline-block;
    zoom: 1;
    height: 33px;
    display: inline;
}
 table#logix_CPH_grd .TextField .chzn-container .chzn-drop {
    top: 24px !important;
    width: 100% !important;
}
  table#logix_CPH_grd select {
    padding: 1px 0 !important;
    border: none !important;
    background: none !important;
}
  table#logix_CPH_Grd_Customer tbody tr td:nth-child(3) {
    width: 496px !important;
}
  table#logix_CPH_Grd_Customer tbody td:nth-child(6) {
    text-align: right;
    width: 37px !important;
}
  table#logix_CPH_grd th:nth-child(1) {
    width: 20px !important;
}

table#logix_CPH_grd th:nth-child(2) {
    width: 139px !important;
}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="FormGroupContent4 ">

        <div class="FormGroupContent4">
        <div class="CustomerName12">
            <span class="headingName">CUSTOMER :</span>
            <asp:Label ID="lblcustomername" runat="server"> </asp:Label>
        </div>
            </div>
        <div class="bordertopNew" style=" float: right;min-height: 1px;width: 100%;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;" ></div>

        <div class="FormGroupContent4">
                                          <div class="fields">
  <div class="BillOfInput">
      <asp:Label ID="Label2" runat="server" ></asp:Label>
      <asp:TextBox ID="txtcustomer" runat="server" placeholder="" ToolTip="" TabIndex="1" OnTextChanged="txtcustomer_TextChanged" AutoPostBack="true" CssClass="form-control" Enabled="false" ></asp:TextBox>
  </div>
                                              <div class="BillOfInput">
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    <asp:TextBox ID="txtcity" runat="server" placeholder="" ToolTip="" TabIndex="1" CssClass="form-control" Enabled="false" ></asp:TextBox>
</div>


        <div class="BillType1">
            
            <asp:DropDownList ID="ddl_voutype" ToolTip="Product" runat="server" placeholder="Product" OnSelectedIndexChanged="ddl_voutype_SelectedIndexChanged" AutoPostBack="true" CssClass="chzn-select" Width="100%" data-placeholder="Product" TabIndex="3" Height="193px">
                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                <asp:ListItem Value="OE" Text="Ocean Export"></asp:ListItem>
                <asp:ListItem Value="OI" Text="Ocean Import"></asp:ListItem>
                <asp:ListItem Value="AE" Text="Air Export"></asp:ListItem>
                <asp:ListItem Value="AI" Text="Air Import"></asp:ListItem>



            </asp:DropDownList>
        </div>
    <div class="right_btn">
        <div class="btn ico-cancel" id="Div1" runat="server">
    <asp:Button runat="server" ID="btncancel" ToolTip="cancel" OnClick="btncancel_Click" />
</div>

    <div class="btn ico-save" id="btnsave1" runat="server">
        <asp:Button runat="server" ID="btnsave" ToolTip="Save" OnClick="btnsave_Click" />
    </div>
        </div>

    </div>
            </div>

    </div>
               <div class="rightdiv">
                <div class="FormGroupContent4 ">
           <div class="gridpnl" style="float:left;width:50%;margin-right:10px !important">

               <asp:GridView ID="Grd_Customer" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" OnSelectedIndexChanged="Grd_Customer_SelectedIndexChanged" OnRowDataBound="Grd_Customer_RowDataBound" ShowHeaderWhenEmpty="True"
                   EmptyDataText="No Record Found" EnableTheming="False" >
                   <Columns>
                                <asp:TemplateField HeaderText="No">
    <ItemTemplate>
       <%# Container.DataItemIndex + 1 %>
    </ItemTemplate>
</asp:TemplateField>
                       <asp:BoundField DataField="gstin" HeaderText="GSTIN" />
                       <asp:BoundField DataField="address" HeaderText="Customer Address" />
                       <asp:BoundField DataField="city" HeaderText="City" />
                       <asp:BoundField DataField="customerid" HeaderText="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />


<%--                       <asp:TemplateField HeaderStyle-ForeColor="White" HeaderText="Select">
     <ItemTemplate>
         <span>
             <asp:CheckBox ID="checksbno" runat="server" Enabled="true" />
         </span>
     </ItemTemplate>
     <HeaderStyle Wrap="false" HorizontalAlign="Center" />
     <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
 </asp:TemplateField>--%>




                       <asp:TemplateField >
        <HeaderTemplate>
              <label for="chkSelectAll" style="color:var(--labelorange);"></label>

            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
        </HeaderTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="checksbno" runat="server"/>
        </ItemTemplate>
                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
 <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
    </asp:TemplateField>
                        <asp:BoundField DataField="Assigned" HeaderText="Assigned" />


                       <%--<asp:BoundField DataField="sno" HeaderText="S.No" />
               <asp:BoundField DataField="customername" HeaderText="Customer Name" />
               <asp:BoundField DataField="unit#" HeaderText="Unit#" />
               <asp:BoundField DataField="buildingname" HeaderText="Building Name " />

               <asp:BoundField DataField="street" HeaderText="Street " />
               <asp:BoundField DataField="locationname" HeaderText="Location" />
               <asp:BoundField DataField="portname" HeaderText="City" />
               <asp:BoundField DataField="districtname" HeaderText="District" />
               <asp:BoundField DataField="statename" HeaderText="State" />
               <asp:BoundField DataField="countryname" HeaderText="Country" />
               <asp:BoundField DataField="pincode" HeaderText="Pincode" />
               <asp:BoundField DataField="mobile" HeaderText="Mobile" />
               <asp:BoundField DataField="email" HeaderText="E Mail" />
               <asp:BoundField DataField="custtype" HeaderText="Customer Type" />--%>
                   </Columns>
                   <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                   <HeaderStyle CssClass="" />
                   <AlternatingRowStyle CssClass="GrdAltRow" />
                   <RowStyle CssClass="GrdRow" />
               </asp:GridView>
           </div>
       
        

    
                                          <div class="rightbl">
    
    
    <div class="gridpnl"  style="height:688px !important; width:49%;" >
    <asp:GridView ID="grd" runat="server"  AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True"
        EmptyDataText="No Record Found" EnableTheming="False" >
        <Columns>
           <asp:TemplateField HeaderText="No">
      <ItemTemplate>
         <%# Container.DataItemIndex + 1 %>
      </ItemTemplate>
  </asp:TemplateField>
            <asp:BoundField DataField="Events" HeaderText="Tasks" />
           
            <asp:TemplateField HeaderText="Assignee">
                
                <ItemTemplate>
                    <span class="FormGroupContent4">
                    <asp:DropDownList ID="DropDownList1"  placeholder="" ToolTip="" OnSelectedIndexChanged="Emp_SelectedIndexChanged" AutoPostBack="true"  CssClass="chzn-select"  runat="server">
                        
                    </asp:DropDownList>
                    
                       </span>
                </ItemTemplate>
                       
            </asp:TemplateField>
           
               <asp:BoundField DataField="Sno" HeaderText="Sno" >
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" CssClass="hide" />
                                <ItemStyle HorizontalAlign="Left" CssClass="align-left hide" Width="" Wrap="false"   />
                            </asp:BoundField>

            <%--<asp:BoundField DataField="sno" HeaderText="S.No" />
                                                <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                                                <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                                                <asp:BoundField DataField="unit#" HeaderText="Unit#" />
                                                <asp:BoundField DataField="buildingname" HeaderText="Building Name " />

                                                <asp:BoundField DataField="street" HeaderText="Street " />
                                                <asp:BoundField DataField="locationname" HeaderText="Location" />
                                                <asp:BoundField DataField="portname" HeaderText="City" />
                                                <asp:BoundField DataField="districtname" HeaderText="District" />
                                                <asp:BoundField DataField="statename" HeaderText="State" />
                                                <asp:BoundField DataField="countryname" HeaderText="Country" />
                                                <asp:BoundField DataField="pincode" HeaderText="Pincode" />
                                                <asp:BoundField DataField="mobile" HeaderText="Mobile" />
                                                <asp:BoundField DataField="email" HeaderText="E Mail" />
                                                <asp:BoundField DataField="custtype" HeaderText="Customer Type" />--%>
        </Columns>
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <HeaderStyle CssClass="" />
        <AlternatingRowStyle CssClass="GrdAltRow" />
        <RowStyle CssClass="GrdRow" />
    </asp:GridView>
        </div>
        
                   </div>
                   </div>
    </div>

     <script type="text/javascript">
         function dropdownButton() {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }

     </script>
         <asp:HiddenField ID="hf_customerid" runat="server" />

</asp:Content>
