<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EmployeeFind.aspx.cs" Inherits="logix.HRM.EmployeeFind" %>


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
    <link href="../Styles/EmployeeFind.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function TxtFocus() {
            //$("#<%=txt_empname.ClientID %>").blur().focus().val($("#<%=txt_empname.ClientID %>").val());
            var el = $("#<%=txt_empname.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }

        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../HRM/EmployeeFind.aspx/GetEmpName",
                data: '{Prefix: "' + $("#<%=txt_empname.ClientID %>").val() + '" }',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: OnSuccess,
                 failure: function (response) {
                     //alertify.alert(response.d);
                 }
             });
         }

         function OnSuccess(response) {
             $("#<%=btn_search.ClientID %>").click();
        }

    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">HRM</a> </li>
              <li class="current"> Find Employee </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="lbl_header" runat="server" Text=" Find Employee"></asp:Label></h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <asp:TextBox ID="txt_empname" runat="server" placeholder="Emp Name" ToolTip="Emp Name" CssClass="form-control"  onkeyup="GetDetail();"></asp:TextBox>

                 </div>
               <div class="FormGroupContent4">
                    <div class="div_Grd">
            <asp:GridView ID="Grd_Emp" runat="server" AutoGenerateColumns="False" Width="100%"
                ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" class="Grid" PageIndex="0" PageSize="10" AllowPaging="false" 
                OnRowDataBound="Grd_Emp_RowDataBound" OnSelectedIndexChanged="Grd_Emp_SelectedIndexChanged" OnPageIndexChanging="Grd_Emp_PageIndexChanging">
                <Columns>
                    <%--<asp:BoundField DataField="empcode" HeaderText="EmpCode" />--%>
                    <%-- <asp:BoundField DataField="unit" HeaderText="Emp Name" />--%>
                    <%--<asp:LinkButton ID="Lnk_Emp" runat="server" Text='<%#Eval("empcode")%>' Style="text-decoration: none;" OnClientClick='return Get_EmpCode($("#logix_CPH_hid").val(),$(this).text())'></asp:LinkButton>--%>
                    <asp:TemplateField HeaderText="EmpCode">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_Emp" runat="server" Text='<%#Eval("empcode")%>' Style="text-decoration: none;"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emp Name">
                        <ItemTemplate>
                            <div class="div_EmpColumn">
                                <asp:Label ID="lbl_emp" runat="server" Text='<%#Eval("unit")%>' ToolTip='<%#Eval("unit")%>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="35%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="branch" HeaderText="Branch">
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <div class="div_Column">
                                <asp:Label ID="lbl_Desg" runat="server" Text='<%#Eval("designation")%>' ToolTip='<%#Eval("designation")%>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="35%" />
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="designation" HeaderText="Designation">
                    <ItemStyle Width="35%" />
                </asp:BoundField>--%>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>
                   </div>

              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">

                      <div class="btn ico-back"><asp:Button ID="btnBack" runat="server" ToolTip="Back" OnClick="btnBack_Click" /></div>
                      <div class="btn ico-send"><asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" /></div>
                  </div>
              </div>


              </div>
         </div>
            </div>
           </div>



    
    <asp:HiddenField ID="hid" runat="server"></asp:HiddenField>


</asp:Content>
