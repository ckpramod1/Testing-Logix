<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CustomerBudgetNew.aspx.cs" Inherits="logix.CRM.CustomerBudgetNew" %>

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
    <%--<link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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
       <%-- <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>--%>
    <script type="text/javascript" src="../js/helper.js"></script>
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

    <link href="../Styles/CustomerBudget.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("#<%=txtport .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "CustomerBudgetNew.aspx/GetPortName",
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
                        $("#<%=txtport.ClientID %>").val(i.item.label);
                        $("#<%=txtport.ClientID %>").change();
                        $("#<%=hf_portid .ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txtport.ClientID %>").val(i.item.label);
                        $("#<%=hf_portid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtport.ClientID %>").val(i.item.label);
                        $("#<%=hf_portid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1

                });
            });

            $(document).ready(function () {
                $("#<%=txtcustomer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "CustomerBudgetNew.aspx/GetCustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]
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
                    select: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_city.ClientID %>").val(i.item.address);
                        $("#<%=HdnCusId.ClientID %>").val(i.item.val);
                        $("#<%=txtcustomer.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_city.ClientID %>").val(i.item.address);
                        $("#<%=HdnCusId.ClientID %>").val(i.item.val);
                        $("#<%=txtcustomer.ClientID %>").val($.trim(result));
                        $("#<%=txtcustomer.ClientID %>").change();

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_city.ClientID %>").val(i.item.address);
                            $("#<%=HdnCusId.ClientID %>").val(i.item.val);
                            $("#<%=txtcustomer.ClientID %>").change();
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtcustomer.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtcustomer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }

        function getConfirmationValue() {

            if (confirm(' Are you sure you want to delete the details?')) {
                $('#<%=hdnDelete.ClientID%>').val('true')
          }
          else {
              $('#<%=hdnDelete.ClientID%>').val('false')
          }

          return true;
      }

    </script>
    <style type="text/css">
        .lbl_head {
            /*display:none;*/
            visibility: hidden;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .FloatRight3 {
            width: 81.5%;
            float: right;
        }

        .RententionInput2B {
                float: left;
    width: 89px;
    margin: 0px 0px 0px 48%;
        }
        .FixedButtonsss {
    position: fixed;
    top: 30px;
    left: 0;
    background: #fff;
    z-index: 10;
    box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
    width: calc(100vw - 5px);
    border-bottom: 0.5px solid #00000010;
    padding: 1px 0 5px 10px;
}
        .UnitInputN2B {
            float: left;
    width: 91px;
    margin: 0px 0px 0px 0.5%;
        }
       
        table#logix_CPH_grdcustomer th {
    width: 100%;
}
        div#logix_CPH_btn_save1 {
    margin: 9px 0 0 3px;
}
        div#logix_CPH_cmbbranch_chzn {
    opacity: 1 !important;
}
        .UnitsInput1 {
    width:12.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .TypeInput {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .RetentionInput {
    width: 19%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .CustomerInputN3 {
    width: 75.2%;
    margin: 0px 0.5% 0px 0px;
    float: left;
}
        .PortInput {
    width: 45.4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Unitinput1 {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .RententionInput1 {
    width: 19%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
       
        .BudgetBranch {
    width:27.4%;
    float: left;
    margin: 0px;
}
        th:nth-child(2) {
    min-width: 104px;
}
        th:nth-child(4) {
    min-width: 92px;
}
        .BudgetName {
    width: 40.7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .ProductInput {
     width: 32%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .YearInput {
    width: 11%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .MonthInput {
    width: 20.3%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        div#logix_CPH_cmbmonth_chzn .chzn-drop {
    height: 318px !important;
}
        div#logix_CPH_btn_add1 {
    margin: 6px 0px 0px 0px;
}
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 55px !important;
        width: 50% !important;
}
        .gridpnl {
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
}
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 87vh;
    overflow-x: hidden;
    overflow-y: auto;
}
        div#logix_CPH_cmbproduct_chzn .chzn-drop {
    height: 514px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblheader" runat="server" Text="Budget"></asp:Label></h4>
                    
    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li id="li_head" runat="server" visible="false"><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Exports</a> </li>
            <li><a href="#" title="" id="label1id" runat="server">Sales</a> </li>
            <li class="current"><a href="#" title="">Budget</a> </li>
        </ul>
    </div>
                        </div>


                     <div class="FixedButtons">
     <div class="right_btn">
         <div class="btn ico-view">
             <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" TabIndex="17" OnClick="btnview_Click" />

         </div>
         <div class="btn ico-cancel" id="btn_cancel1" runat="server">
             <asp:Button ID="btncancel" runat="server" Text="Cancel"  ToolTip="Cancel" TabIndex="18" OnClick="btncancel_Click" />
         </div>
     </div>
 </div>


                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">
                        <div class="BudgetName">
                            <asp:Label ID="Label1" runat="server" Text="Sales Person"> </asp:Label>
                            <asp:TextBox ID="txtsalperson" runat="server" BorderColor="#999997" placeholder=" " CssClass="form-control " TabIndex="1" ToolTip="Sales Person" Enabled="False"></asp:TextBox>
                        </div>
                        <div class="BudgetBranch">
                            <asp:Label ID="Label2" runat="server" Text="Branch"> </asp:Label>
                            <asp:DropDownList data-placeholder="Branch" ID="cmbbranch" runat="server" CssClass="chzn-select" ToolTip="Branch" Width="100%" Enabled="False" TabIndex="2"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="MonthInput">
                            <asp:Label ID="Label3" runat="server" Text="Month"> </asp:Label>
                            <asp:DropDownList data-placeholder="Month" ID="cmbmonth" runat="server" CssClass="chzn-select" ToolTip="Month" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cmbmonth_SelectedIndexChanged" TabIndex="3">
                            </asp:DropDownList>
                        </div>
                        <div class="YearInput">
                            <asp:Label ID="Label4" runat="server" Text="Year"> </asp:Label>
                            <asp:DropDownList data-placeholder="Year" ID="cmbyear" runat="server" CssClass="chzn-select" ToolTip="Year" Width="100%" TabIndex="4">
                            </asp:DropDownList>
                        </div>
                        

                    </div>
                    <div class="FormGroupContent4" >
                        <div class="ProductInput">
                            <asp:Label ID="Label5" runat="server" Text="Product"> </asp:Label>
                            <asp:DropDownList data-placeholder="Product" ID="cmbproduct" runat="server" CssClass="chzn-select" ToolTip="Product" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cmbproduct_SelectedIndexChanged" TabIndex="5">
                            </asp:DropDownList>
                        </div>
                        <div class="UnitsInput1">
                            <asp:Label ID="Label6" runat="server" Text="Units"> </asp:Label>
                            <asp:TextBox ID="txtbudunits" runat="server" placeholder="  " CssClass="form-control " Style="text-align: right;" TabIndex="6" Width="100%" ToolTip="No. of Units" onkeypress="return validateFloatKeyPress(this,event,'Unit')"></asp:TextBox>
                        </div>
                        <div class="TypeInput">
                            <asp:Label ID="Label7" runat="server" Text="UoM"> </asp:Label>
                            <asp:TextBox ID="txttype" runat="server" placeholder=" " CssClass="form-control " TabIndex="7" ToolTip="Type" Enabled="False"></asp:TextBox>
                        </div>
                        <div class="RetentionInput">
                            <asp:Label ID="Label8" runat="server" Text="Retention"> </asp:Label>
                            <asp:TextBox ID="txtbudret" runat="server" placeholder="  " CssClass="form-control" Style="text-align: right;" Width="100%" TabIndex="8" ToolTip="Retention" AutoPostBack="True" OnTextChanged="txtbudret_TextChanged" onkeypress="return validateFloatKeyPress(this,event,'Rentention')"></asp:TextBox>
                        </div>                       

                        <div class="btn btn-save1 MT15" id="btn_save1" runat="server">
                            <asp:Button ID="btnsave" runat="server" ToolTip="Save" Text="Save" TabIndex="9" OnClick="btnsave_Click" Width="100%" />
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CustomerInputN3">
                            <asp:Label ID="Label9" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txtcustomer" runat="server" placeholder=" " CssClass="form-control " TabIndex="10" ToolTip="Customer" AutoPostBack="true" OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                        </div>
                        </div>
                    <div class="FormGroupContent4">
                        <div class="PortInput">
                            <asp:Label ID="Label10" runat="server" Text="Port"> </asp:Label>
                            <asp:TextBox ID="txtport" runat="server" placeholder=" " CssClass="form-control " TabIndex="11" ToolTip="Port" AutoPostBack="true" OnTextChanged="txtport_TextChanged"></asp:TextBox>
                        </div>
                      
          
                        <div class="Unitinput1">
                            <asp:Label ID="Label11" runat="server" Text="Unit"> </asp:Label>
                            <asp:TextBox ID="txtunits" Style="text-align: right;" runat="server" placeholder="  " CssClass="form-control " TabIndex="12" ToolTip="Unit" onkeypress="return validateFloatKeyPress(this,event,'Unit')"></asp:TextBox>
                        </div>
                         
              

                        <div class="RententionInput1">
                            <asp:Label ID="Label12" runat="server" Text="Retention"> </asp:Label>
                            <asp:TextBox ID="txtrentention" Style="text-align: right;" runat="server" placeholder="  " CssClass="form-control " TabIndex="13" ToolTip="Retention" onkeypress="return validateFloatKeyPress(this,event,'Rentention')"></asp:TextBox>
                        </div>

                        <div class="btn ico-add MT15" id="btn_add1" runat="server">
                            <asp:Button ID="btnadd" runat="server" ToolTip="Add" Text="Add" Width="100%" Height="24px" OnClick="btnadd_Click" TabIndex="14" />
                        </div>
                          </div>
                         
                    
                    <div class="FormGroupContent4 boxmodal" style="width:76%">
                        <asp:Panel ID="Panel1" runat="server"  Width="100%" Style="margin-left: 0%;" CssClass="gridpnl" >
                            <asp:GridView ID="grdcustomer" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowDeleting="grdcustomer_RowDeleting" OnRowDataBound="grdcustomer_RowDataBound" OnSelectedIndexChanged="grdcustomer_SelectedIndexChanged" OnPreRender="grdcustomer_PreRender">
                                <Columns>
                                    <asp:BoundField HeaderText="Customer" DataField="customername">
                                        <ItemStyle />
                                        <HeaderStyle  />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Port" DataField="portname">
                                        <ItemStyle />
                                        <HeaderStyle  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vtype" HeaderText="Units" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle  HorizontalAlign="Right" />
                                        <HeaderStyle  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="billamt" HeaderText="Retention" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="customerid" HeaderText="customerid">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="portid" HeaderText="portid">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mccid" HeaderText="mccid">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="volume" HeaderText="Unit" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle  HorizontalAlign="Right" CssClass="hide" />
                                        <HeaderStyle  CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server"  ImageUrl="~/images/delete.jpg" OnClick="ImageButton2_Click" OnClientClick="getConfirmationValue()"  />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"  />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Unit T" DataField="vtype" Visible="False"></asp:BoundField>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>
                            <div class="div_break"></div>
                            <div class="div_break"></div>
                        </asp:Panel>
                    </div>
                    <div class="FormGroupContent4 boxmodal" style="width:80%" >
                        <div class="FloatRight3">

                            <%--  <div class="TotalLabel"><asp:Label ID="Label1" runat="server" Text="Total" CssClass="LabelValue "></asp:Label></div>--%>

                            <div class="RententionInput2B">
                                <asp:Label ID="Label13" runat="server" Text="Units"> </asp:Label>
                                <asp:TextBox ID="txttotunit" runat="server" Style="text-align: right;" placeholder=" " CssClass="form-control TextRight" Width="100%" TabIndex="15" ToolTip="Unit" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="UnitInputN2B">
                                <asp:Label ID="Label14" runat="server" Text="Retention"> </asp:Label>
                                <asp:TextBox ID="txttotrent" runat="server" Style="text-align: right;" placeholder=" " CssClass="form-control TextRight" TabIndex="16" ToolTip="Retention" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     

                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="HdnCusId" runat="server" />
    <asp:HiddenField ID="hf_portid" runat="server" />
    <asp:HiddenField ID="hdnDelete" runat="server" />

    <asp:HiddenField ID="hfunit" runat="server" />
    <asp:HiddenField ID="hfret" runat="server" />
    <div class="hide">
    <asp:TextBox ID="txt_city" runat="server" Style="display: none;"></asp:TextBox>
    </div>
    <%--style="display:none;"--%>
</asp:Content>

