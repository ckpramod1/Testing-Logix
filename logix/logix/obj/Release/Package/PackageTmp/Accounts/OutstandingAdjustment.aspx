<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" 
    CodeBehind="OutstandingAdjustment.aspx.cs" EnableEventValidation="false" Inherits="logix.Accounts.OutstandingAdjustment" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
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

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
        <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <%--<script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>--%>

      <!-- App -->
      <%--<script type="text/javascript">
          $(document).ready(function () {
              $('.selectpicker').selectpicker();
              "use strict";
              App.init(); // Init layout and core plugins
              Plugins.init(); // Init all plugins
              FormComponents.init(); // Init all form-specific plugins
              //$('select.styled').customSelect();
          });
      </script>--%>
      <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
     <%--<script type="text/javascript">
         function pageLoad(sender, args) {
             $(document).ready(function () {
             });
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }
      </script>--%>
    <link href="../Styles/OustandingAdjustment.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    
    <script type="text/javascript" >
        ///AutoCompleteClass/AutoCompleteClass.aspx
        function pageLoad(sender, args) {
            //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {
                $("#<%=txt_customer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_custid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetLikeLedgerName",
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

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_customer.ClientID %>").val(i.item.label);
                        $("#<%=txt_customer.ClientID %>").change();
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_customer.ClientID %>").val(i.item.label);
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_customer.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
        }

    </script>
    
    <%--<script type="text/javascript">
         
        
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_customer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_custid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Accounts/OutstandingAdjustment/Getcustomer",
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
                                
                            },
                            failure: function (response) {
                                
                            }
                          });
                    },
                     select: function (e, i) {
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                        $("#<%=txt_customer.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (e, i) {
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_customer.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                     },
                    minLength: 1
                });
            });
        }
    </script>--%>

    <style type="text/css">
        .div_customertxt {
            width:40%;
            float:left;
            margin:0px 0px 0px 0px;
        }

        .div_Grid {
    width: 100%;
    float: left;
    border: 1px solid #b1b1b1;
    margin-top: 0%;
    margin-left: 0%;
    height: 350px;
    overflow: auto;
}

        .row {
    height: 584px!important;
    /* margin: 0px 5px 0px -15px; */
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}
        .div_detail {
    width: 88.5%;
    float: left;
    margin-top: 0%;
    margin-left: 0%;
    color: Red;
    text-align: left;
}

        .div_customertxt input, Text {
    width: 100%;
}
        .Grid {
            height: 0px !important;
        }
       

       .Sticky-top thead{
    position:sticky;
    top:-1px;
}

.Sticky-top td{
    border-bottom:1px solid #AAA;
    border-right:1px solid #AAA;
}
.TotalTxt2 {
    width: 11%;
    margin: 0px 0.5% 0px 0px;
    float: left;
}

.btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 12px;
            }

            .ChkTillDate span, label {
    display: inline-block;
    float: left;
    font-size: 12px;
    width: auto !important;
    color: maroon;
}
.gridpnl {
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
    height: 460px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


   
   

       <div>
        <div class="col-md-12">     
        <div class="widget box" runat ="server">
        <div class="widget-header">
        <h4><i class="icon-umbrella"></i>
            <asp:Label ID="lbl_Header" runat="server" Text=" Outstanding Adjustment"></asp:Label>
            </h4>
               <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
              <li><a href="#" title="">  Oustanding Adjustment </a> </li>
             </ul>
      </div>
             <div style="float: right; margin: 0px -0.5% 0px 0px;" class="btn-logic1">
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
            </div>
                  <div class="widget-content" >
     <div class="FormGroupContent4">

          <div class="div_customertxt">
        <asp:Label ID="Label1" runat="server" Text=" Customer "></asp:Label>

        <asp:TextBox ID="txt_customer" runat="server" AutoPostBack="True" placeholder="" ToolTip="Customer" CssClass="form-control" ontextchanged="txt_customer_TextChanged"></asp:TextBox>
    </div>
         </div>

<div class="FormGroupContent4">
 <div class="">
        <asp:HiddenField ID="dt1" runat="server" />
        <asp:HiddenField ID="dt2" runat="server" />
        <asp:HiddenField ID="hid_lt" runat="server" />
     <div class="gridpnl">
        <asp:GridView ID="Grd_Detail" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"
            Width="100%" ForeColor="Black" EmptyDataText="No Record Found" DataKeyNames="vouyear"
            ShowHeaderWhenEmpty="True" OnPreRender="Grd_Detail_PreRender">
            <Columns>
                
                <asp:BoundField DataField="trantype" HeaderText="Product" />
                <asp:BoundField DataField="voutype" HeaderText="Type" />
                <asp:BoundField DataField="vouno" HeaderText="Vou #" />
                <asp:BoundField DataField="voudate" HeaderText="Date" DataFormatString="{0:d}" />
                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                <asp:BoundField DataField="blno" HeaderText="BL #" />
                <asp:BoundField DataField="osamount" HeaderText="Amount" DataFormatString="{0:#,##0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="noofdays" HeaderText="Days" />
                <asp:BoundField DataField="cust" HeaderText="Quot. Customer" />
                 <asp:BoundField DataField="Vouyear" HeaderText="Vouyear">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                    <asp:BoundField DataField="Vouno1" HeaderText="Vouno1">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                 <asp:BoundField DataField="Jrefno" HeaderText="Jrefno">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                <asp:BoundField DataField="Bid" HeaderText="Bid">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>

                
                       <asp:BoundField DataField="Exrate" HeaderText="Exrate">  <%--NewOne--%>
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                
                       <asp:BoundField DataField="Fcurr" HeaderText="Fcurr">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>

                 <asp:BoundField DataField="ledgertype" HeaderText="ledgertype">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                <asp:TemplateField HeaderText="adjustment">
                    <ItemTemplate>
                        <asp:TextBox ID="adjustment"  runat="server" ontextchanged="txt_adjustment_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="Chk_Select" runat="server" OnCheckedChanged="chk_Select_CheckedChanged" AutoPostBack="true" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                   <asp:BoundField DataField="Refno" HeaderText="Refno" DataFormatString="{0:#,##0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>

            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>
    </div>
</div>

<div class="FormGroupContent4">
  <div class="div_detail">
        <asp:Label ID="lbl_detail" runat="server" Text="'I' -  Invoice    'P' - Purchase Invoice   'D' - OSDN   'C'-OSCN    'V' - Debit Note-Others    'E' - Credit Note-Others"></asp:Label>
    </div>
    <div class="TotalTxt2">
        <span>Total</span>
        <asp:TextBox ID="txt_total" runat="server" Style="text-align: right" CssClass="form-control" placeholder="Total" ToolTip="TOTAL" Enabled="false" ></asp:TextBox>
    </div>
     <div class="right_btn">

        <div class="btn ico-update"><asp:Button ID="btn_update" runat="server" ToolTip="Update"  Text="Update" onclick="btn_update_Click" /></div>

        <div class="btn ico-cancel"> <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" Text="Cancel" onclick="btn_cancel_Click" /></div>

    </div>
    </div>






                      </div>
            </div>
            </div>
           </div>

          <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label> Outstanding Adjustment#</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/images/close2.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                    BackColor="White">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="myGridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>

                            </asp:Panel>
                            <div class="Break"></div>
                        </div>


                    </asp:Panel>


    <asp:Label ID="Label10" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label10" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hid_custid" runat="server" />
    <asp:HiddenField ID="hid_SubGroup" runat="server" />    
    <asp:HiddenField ID="hid_Bid" runat="server" />
</asp:Content>
