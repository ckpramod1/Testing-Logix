<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Changejobclosedate.aspx.cs" Inherits="logix.Maintenance.Changejobclosedate" %>
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

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

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
    <style type="text/css">
        .CloseDate{ width:52.5%; float:right; margin:0px 0px 0px 0px;}
        .DivisionDrop {
            width:25%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .Shipper1 {
            width:15%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .Consignee3 {
            width:15%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .RequestedBy {
            width:43.5%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .Year1 {
    width: 4%;
    float: left;
}
        #logix_CPH_ddl_cmbMonth_chzn {
            width:100%!important;
        }
        .Month1 {
    width: 10%;
    float: right;
}
    </style>








    <%--<link href="../Styles/MIChange Jobclosedate.css" rel="Stylesheet" type="text/css" />--%>
    <link href="../Styles/Changejobclosedate.css" rel="stylesheet" type="text/css"/>
    <link href="../Scripts/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
     <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

 <link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {
                $('#<%=grd_change.ClientID%>').gridviewScroll({
                    width: 493,
                    height: 200,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });

            $(document).ready(function () {

                $("#<%=txt_user.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_employeeid.ClientID %>").val(0);
                        $.ajax({
                            url: "Changejobclosedate.aspx/GetEmployeename",
                            data: "{ 'prefix': '" + request.term + "'}",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (e, i) {
                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_user.ClientID %>").change();
                    },

                    focus: function (event, i) {
                        $("#<%=txt_user.ClientID %>").val(i.item.value);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_user.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_user.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }
    </script>
    <%-- <script type="text/javascript">


         function pageLoad(sender, args) {
             $(document).ready(function () {
                 $('input:text:first').focus();
             });
             $(document).ready(function () {
                 $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
             });
         }
       </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
     
     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title="">Change Job Close Date</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="lblheader" runat="server" Text="Change Job Close Date"></asp:Label></h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="right_btn MT0">
                     <div class="CloseDate">
                      <asp:TextBox ID="txt_dtNewClose" runat="server" CssClass="form-control" placeholder="New ClosedDate" Tooltip="New ClosedDate" TabIndex="1" ></asp:TextBox>
        <asp:CalendarExtender ID="dtvalidity" runat="server" TargetControlID="txt_dtNewClose" 
            Format="dd/MM/yyyy">
        </asp:CalendarExtender>
                     </div>
                    
                 </div>

                 </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="DivisionDrop">
                      <asp:DropDownList ID="ddl_cmbDivision" runat="server" CssClass ="chzn-select" data-placeholder="Division" ToolTip="Division"
            AutoPostBack="True" 
            onselectedindexchanged="ddl_cmbDivision_SelectedIndexChanged" TabIndex="2">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
        </asp:DropDownList>


                  </div>
                   <div class="Shipper1">  <asp:DropDownList ID="ddl_cmbBranch" runat="server" CssClass ="chzn-select" data-placeholder="Branch" ToolTip="Branch" Width="100%"
            AutoPostBack="True" onselectedindexchanged="ddl_cmbBranch_SelectedIndexChanged" TabIndex="3">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
        </asp:DropDownList></div>
                  <div class="Consignee3"> <asp:DropDownList ID="ddl_cmbModule" runat="server" CssClass ="chzn-select" data-placeholder="Module" ToolTip="Module" Width="100%"
            AutoPostBack="True" onselectedindexchanged="ddl_cmbModule_SelectedIndexChanged" TabIndex="4">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
        </asp:DropDownList></div>
                  <div class="RequestedBy">
                      <asp:TextBox ID="txt_user" runat="server" CssClass="form-control" placeholder="Requested by" ToolTip="Requested by" ontextchanged="txt_user_TextChanged" MaxLength="100" TabIndex="5" ></asp:TextBox>
                  </div>
                   
                  </div>
             
               
               <div class="FormGroupContent4">
                   <div class="Year1"><asp:TextBox ID="txt_dtpYear" runat="server" CssClass="form-control" placeholder="Closed Year" ToolTip="Closed Year" TabIndex="6" ></asp:TextBox>    </div>
                   <div class="Month1">   <asp:DropDownList ID="ddl_cmbMonth" runat="server" CssClass ="chzn-select"  Width="100%"  ToolTip="Closed Month"
            AutoPostBack="True" onselectedindexchanged="ddl_cmbMonth_SelectedIndexChanged" TabIndex="7">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
        </asp:DropDownList></div>
                   </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <asp:GridView ID="grd_change" runat="server" AutoGenerateColumns="False" Width="100%"
                DataKeyNames="jobno" ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader" >
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Column1" HeaderText="Vsl & Voy">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="jobclosedate" HeaderText="Date">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="grdblselect" runat="server" Width="60px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
               
              <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 

            </asp:GridView>
                   </div>
              <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="right_btn MT0 MB05">
                        <div class="btn btn-unclosed1"> <asp:Button ID="btn_Unclsjob" runat="server" ToolTip="Unclose Job"  onclick="btn_Unclsjob_Click" TabIndex="8" /></div>
                        <div class="btn ico-update"> <asp:Button ID="btn_update" runat="server" ToolTip="Update" onclick="btn_update_Click" TabIndex="9" /></div>
                        <div class="btn ico-cancel" id="btn_back1" runat="server"> <asp:Button ID="btn_back" runat="server" ToolTip="Cancel"  onclick="btn_back_Click" TabIndex="10" /></div>
                    </div>
                    </div>
              </div>
         </div>
            </div>
           </div>


    <asp:HiddenField ID="hf_divisionid" runat="server" />
     <asp:HiddenField ID="hf_intbranchid" runat="server" />
     <asp:HiddenField ID="hf_inti" runat="server" />
     <asp:HiddenField ID="hf_employeeid" runat="server" />
      <asp:HiddenField ID="hf_str_name" runat="server" />
        <asp:HiddenField ID="hf_intmonth" runat="server" />   
  
</asp:Content>

