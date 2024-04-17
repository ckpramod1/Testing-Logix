<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="UserPermissions.aspx.cs" Inherits="logix.Maintenance.UserPermissions" %>
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




    
    <link href="../Styles/UserPermission.css" rel="stylesheet" type="text/css"/>
    <link href="../Scripts/jquery-ui.css" rel="Stylesheet" type="text/css" />
   <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
   <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_user.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_employeeid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Maintenance/UserPermissions.aspx/GetEmployeename",
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


    
<style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }
        .headergrid
        {
            margin-top:2%;
            float:right;
        }
    </style>
   <script type="text/javascript">
       var TotalChkBx;
       var Counter;

       window.onload = function () {
           //Get total no. of CheckBoxes in side the GridView.
           TotalChkBx = parseInt('<%= this.grd_user.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

       function chk_access(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grd_user.ClientID %>');
            var TargetChildControl = "chk_access";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

       function chk_save(CheckBox) {
           //Get target base & child control.
           var TargetBaseControl =
               document.getElementById('<%= this.grd_user.ClientID %>');
           var TargetChildControl = "chk_save";

           //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

           //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }
       function chk_view(CheckBox) {
           //Get target base & child control.
           var TargetBaseControl =
               document.getElementById('<%= this.grd_user.ClientID %>');
           var TargetChildControl = "chk_view";

           //Get all the control of the type INPUT in the base control.
           var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
           for (var n = 0; n < Inputs.length; ++n)
               if (Inputs[n].type == 'checkbox' &&
                         Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                   Inputs[n].checked = CheckBox.checked;

           //Reset Counter
           Counter = CheckBox.checked ? TotalChkBx : 0;
       }
       function chk_delete(CheckBox) {
           //Get target base & child control.
           var TargetBaseControl =
               document.getElementById('<%= this.grd_user.ClientID %>');
           var TargetChildControl = "chk_delete";

           //Get all the control of the type INPUT in the base control.
           var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
           for (var n = 0; n < Inputs.length; ++n)
               if (Inputs[n].type == 'checkbox' &&
                         Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                   Inputs[n].checked = CheckBox.checked;

           //Reset Counter
           Counter = CheckBox.checked ? TotalChkBx : 0;
       }
       function chk_upd(CheckBox) {
           //Get target base & child control.
           var TargetBaseControl =
               document.getElementById('<%= this.grd_user.ClientID %>');
           var TargetChildControl = "chk_upd";

           //Get all the control of the type INPUT in the base control.
           var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
           for (var n = 0; n < Inputs.length; ++n)
               if (Inputs[n].type == 'checkbox' &&
                         Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                   Inputs[n].checked = CheckBox.checked;

           //Reset Counter
           Counter = CheckBox.checked ? TotalChkBx : 0;
       }

        function ChildClick(CheckBox, HCheckBox) {
            //get target control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter; 
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = false;
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
               <li><a href="#" title="" id="lblHead" runat="server"> </a> </li>
              <li><a href="#" title="" id="lblHead1" runat="server"></a> </li>
              <li class="current"><a href="#" title="" id="lblHead2" runat="server"></a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lblheader" runat="server" Text=""></asp:Label> </h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="DivisionUser">  <asp:DropDownList  data-placeholder="Division" ToolTip="Division"  ID="ddl_cmbDivision" runat="server"  AutoPostBack="True"  CssClass="chzn-select">
        </asp:DropDownList></div>
                 <div class="BranchUser">  <asp:DropDownList data-placeholder="Branch" ID="ddl_cmbLocation" runat="server" ToolTip="Branch"  AutoPostBack="True"  CssClass="chzn-select" 
            OnSelectedIndexChanged="ddl_cmbLocation_SelectedIndexChanged">
        </asp:DropDownList></div>

                 </div>
              <link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
               <div class="FormGroupContent4">
                  <div class="UserPerInput"><asp:TextBox ID="txt_user" runat="server" CssClass="form-control" MaxLength="100"  placeholder=" User Name" ToolTip="User Name"  OnTextChanged="txt_user_TextChanged"></asp:TextBox></div>
                   <div class="UserProduct"> <asp:DropDownList ID="ddl_cmbModule" data-placeholder="Product" runat="server" ToolTip="Product"  AutoPostBack="True"  CssClass="chzn-select"
            OnSelectedIndexChanged="ddl_cmbModule_SelectedIndexChanged">
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList></div>
                   <div class="UserMenu"> <asp:DropDownList data-placeholder="Menu" ID="ddl_chk" runat="server" ToolTip="Menu"  AutoPostBack="True"  CssClass="chzn-select"
            OnSelectedIndexChanged="ddl_chk_SelectedIndexChanged">
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList></div>
                   </div>
              
             
              <link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
             
              <link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="right_btn MT0 MB10">
                       <div class="btn ico-save" id="btn_save1" runat="server"> <asp:Button ID="btn_save" runat="server" ToolTip="Save"  OnClick="btn_save_Click" />
       </div>
                       <div class="btn ico-view"> <asp:Button ID="btn_view" runat="server" ToolTip="View"  OnClick="btn_view_Click" />
       </div>
                       <div class="btn ico-cancel" id="btn_back1" runat="server"> <asp:Button ID="btn_back" runat="server" ToolTip="Cancel"  OnClick="btn_back_Click" /></div>
                   </div>
                   </div>
              <div class="FormGroupContent4">
                      <asp:Panel ID="Panel1" runat="server" Width="100%" Height="360px"  CssClass="div_grd"
            ScrollBars="Vertical">
        <asp:GridView ID="grd_user" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
            ShowHeaderWhenEmpty="true" OnRowDataBound="grd_user_RowDataBound" OnRowCreated="grd_user_RowCreated">
            <Columns>
                <asp:BoundField DataField="uicaption" HeaderText="Screen" />
                <asp:TemplateField >
                   
                        <HeaderTemplate >
                            <asp:CheckBox ID="chk_accessAll"  Text="Access" TextAlign="Left" runat="server"  ToolTip="Access" onclick="javascript:chk_access(this);"/>
                        </HeaderTemplate>
                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_access" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_saveAll" Text="Save" TextAlign="Left" runat="server" ToolTip="Save" onclick="javascript:chk_save(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_save" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_viewAll" Text="View" TextAlign="Left" runat="server" ToolTip="View" onclick="javascript:chk_view(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_view" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_deleteAll" Text="Delete" TextAlign="Left" ToolTip="Delete" runat="server" onclick="javascript:chk_delete(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_delete" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_updAll" Text="Update" TextAlign="Left" ToolTip="Update" runat="server" onclick="javascript:chk_upd(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_upd" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="" />
            <AlternatingRowStyle CssClass="GrdAltRow" />

             <%--<AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> --%>
        </asp:GridView>
         </asp:Panel>
                  </div>
               <div>
        <asp:HiddenField ID="hf_employeeid" runat="server" />
        <asp:HiddenField ID="hf_modulename" runat="server" />
        <asp:HiddenField ID="hf_empcode" runat="server" />
        <asp:HiddenField ID="hf_branchid" runat="server" />
        <asp:HiddenField ID="hf_divisionid" runat="server" />
        <asp:HiddenField ID="hf_uiid" runat="server" />
        <asp:HiddenField ID="hf_trantype" runat="server" />
        <asp:HiddenField ID="hf_menuname" runat="server" />
    </div>

              </div>
         </div>
            </div>
           </div>





   
</asp:Content>
