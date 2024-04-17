<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MailingList.aspx.cs" Inherits="logix.Maintenance.MailingList" %>
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
   
    <link href="../Styles/MailingList.css" rel="stylesheet" type="text/css"/>
    <link href="../Scripts/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
     <link href="../Styles/chosen.css" rel="stylesheet" />
     <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

        <script type="text/javascript">
            function pageLoad(sender, args) {
                $(document).ready(function () {
                    $("#<%=txt_emp.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MailingList.aspx/GetEmployeename",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_emp.ClientID %>").val(i.item.label);
                        $("#<%=txt_emp.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_emp.ClientID %>").val(i.item.label);
                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_emp.ClientID %>").val(i.item.label);
                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
        
               <%-- $(document).ready(function () {
                    $('#<%=grd.ClientID%>').gridviewScroll({
                         width: 1000,
                         height: 350,
                         arrowsize: 30,
                         varrowtopimg: "../images/arrowvt.png",
                         varrowbottomimg: "../images/arrowvb.png",
                         harrowleftimg: "../images/arrowhl.png",
                         harrowrightimg: "../images/arrowhr.png"
                     });
                });--%>

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

        </script>     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Systems</a> </li>
              <li class="current"><a href="#" title="">Mailing List</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lblheader" runat="server" Text="MailingList"></asp:Label> </h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="Division1"> <asp:DropDownList data-placeholder="Division" ID="ddl_cmbDivision" runat="server" CssClass ="chzn-select" AutoPostBack="True"
            OnSelectedIndexChanged="ddl_cmbDivision_SelectedIndexChanged" Width="100%" TabIndex="1"  >
        </asp:DropDownList></div>
                 <div class="BranchCode1"> <asp:DropDownList data-placeholder="Branch" ID="ddl_cmbbranch" runat="server" CssClass ="chzn-select" AutoPostBack="True"
            OnSelectedIndexChanged="ddl_cmbbranch_SelectedIndexChanged" Width="100%" TabIndex="2"   >
        </asp:DropDownList></div>
                 </div>
                <div class="FormGroupContent4">
                    <div class="ServiceTax1"> <asp:DropDownList data-placeholder="Product" ID="ddl_cmbTrantype" runat="server" CssClass ="chzn-select" AutoPostBack="True"
            OnSelectedIndexChanged="ddl_cmbTrantype_SelectedIndexChanged" Width="100%" TabIndex="3"   >
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList></div>
                    <div class="ServiceTax2"> <asp:DropDownList data-placeholder="Menu" ID="ddl_cmbmenu" runat="server" CssClass ="chzn-select" AutoPostBack="True"
            OnSelectedIndexChanged="ddl_cmbmenu_SelectedIndexChanged"  Width="100%"  
            AppendDataBoundItems="True" TabIndex="4">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList></div>
                    <div class="ServiceTax4"> <asp:DropDownList data-placeholder="Screen" ID="ddl_cmbscreen" runat="server" CssClass ="chzn-select" AutoPostBack="True"
            OnSelectedIndexChanged="ddl_cmbscreen_SelectedIndexChanged" Width="100%"  
            AppendDataBoundItems="True" TabIndex="5">
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList></div>

                    </div>
              <div class="FormGroupContent4">
                  <asp:TextBox ID="txt_emp" runat="server" CssClass="form-control" Width="100%" ToolTip="Name" placeholder=" Name" MaxLength="100"  ontextchanged="txt_emp_TextChanged" TabIndex="6"></asp:TextBox>
              </div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-save" id="btn_save1" runat="server"><asp:Button ID="btn_save" runat="server" ToolTip="Save"  OnClick="btn_save_Click" TabIndex="7" /></div>
                      <div class="btn ico-cancel" id="btn_back1" runat="server"><asp:Button ID="btn_back" runat="server" ToolTip="Cancel"  onclick="btn_back_Click" TabIndex="8" /></div>
                  </div>
                  </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="div_border">
                   <asp:Panel ID="Panel1" runat="server" >
            <asp:GridView ID="grd"  runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true"
                OnSelectedIndexChanged="grd_SelectedIndexChanged" DataKeyNames="uiid,empid,bid" PageSize="10" OnRowDataBound="grd_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="shortname" HeaderText="Branch" />
                    <asp:BoundField DataField="module" HeaderText="Module" />
                    <asp:BoundField DataField="menuname" HeaderText="Menu" ItemStyle-HorizontalAlign="Left">
                    </asp:BoundField>
                    <asp:BoundField DataField="submenuname" HeaderText="Screen" />
                    <asp:BoundField DataField="empname" HeaderText="Emp Name" />
                     <asp:BoundField DataField="uiid" HeaderText="uiid" Visible="false"/>
                      <asp:BoundField DataField="empid" HeaderText="empid" Visible="false"/>
                       <asp:BoundField DataField="bid" HeaderText="bid" Visible="false" />
                  <%--  <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
               <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            </asp:GridView>

       </asp:Panel>
                       </div>
                   </div>
               <div class="FormGroupContent4">
                    <div>
        <asp:HiddenField ID="hf_employeeid" runat="server" />
        <asp:HiddenField ID="hf_divisionid" runat="server" />
        <asp:HiddenField ID="hf_branchid" runat="server" />
        <asp:HiddenField ID="hf_tran" runat="server" />
        <asp:HiddenField ID="hf_uiid" runat="server" />
        <asp:HiddenField ID="hf_oldid" runat="server" />
        <asp:HiddenField ID="hf_empid" runat="server" />
        
    </div>
                   </div>
                 <div class="FormGroupContent4">
                      <asp:Panel ID="pnl_msg1" runat="server" CssClass="Pnl1"  Style="display: none;">           
            <br />
        <div style="font-size: 10pt;margin-left:2%;"><b>Do you want to Delete ?</b></div>
        <br />
         <div class="div_confirm">
              <asp:Button ID="btn_yes1" runat="server" CssClass="Button" Text="Yes" Width="32%" OnClick="btn_yes1_Click" />
                        <asp:Button ID="btn_no1" runat="server" CssClass="Button" Text="No" Width="32%" 
                            onclick="btn_no1_Click" />
        </div>
             <br />
        <div class="div_Break"></div>
        </asp:Panel>
                     </div>
              <div class="FormGroupContent4">
                    <div>
        <asp:ModalPopupExtender ID="mdl_msg1" runat="server" CancelControlID="" PopupControlID="pnl_msg1" TargetControlID="hid">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hf_msg1" runat="server" />
        <asp:Label ID="hid" runat="server" Style="display: none;"></asp:Label>
    </div>
                  </div>
              </div>
         </div>
            </div>
           </div>

</asp:Content>
