<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="BTInvoice.aspx.cs" Inherits="logix.BT.BTInvoice" %>
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

    <%--<script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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









     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/BTInvoice.css" rel="stylesheet" />
    <style>

                .ToInputN11 {
  width: 50.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
                              .ToInputN11new {
  width: 49%;
    float: left;
    margin: 0px 0% 0px 0px;
}

.TotalRight {
    width: 10%;
    float: right;
    margin: 0px;
}

  /*LOG DETAILS CSS*/


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
                font-size: 11px;
            }


        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }


            .DivSecPanelLog img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }


        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

             .LogHeadLbl {
             width:65%;
             float:left;
             margin:2px 0px 3px 4px;

         }

         .LogHeadLbl label
         {
             color:#af2b1a;
             font-weight:bold;
             font-size:12px;
         }



         .LogHeadJob {
             width:auto;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LogHeadJobInput label {
             font-size:12px;
             
            
         }


           .LogHeadJobInput {
             width:15%;
             float:left;
             margin:1px 0.5% 0px 0px;
         }

             .LogHeadJobInput span {
                 color:#1a65af;
                 font-size:12px;
                 margin:4px 0px 0px 0px;
             }




             .LogHeadJobInput label {
                 font-size:12px;
                 font-family:sans-serif;
                 color:#4e4e4c;
             }

               logix_CPH_PanelLog
             {
                 top:155px!important;
             }

    </style>
     <script type="text/javascript">
         function pageLoad(sender, args) {

             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

             $(document).ready(function () {
                 $("#<%=txtTo.ClientID %>").autocomplete({

                      source: function (request, response) {
                          $("#<%=hid_to.ClientID %>").val(0);
                    $.ajax({
                        url: "../BT/BTInvoice.aspx/GrtTo",
                        data: "{ 'prefix': '" + request.term + "','Ftype':'C'}",
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
                    $("#<%=txtTo.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=txtTo.ClientID %>").change();
                    $("#<%=hid_to.ClientID %>").val(i.item.val);
                },
                    focus: function (event, i) {
                        $("#<%=txtTo.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=hid_to.ClientID %>").val(i.item.val);
                },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtTo.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_to.ClientID %>").val(i.item.val);

                    }

                },
                    close: function (event, i) {
                        var result = $("#<%=txtTo.ClientID %>").val().toString().split(',')[0];
                    $("#<%=txtTo.ClientID %>").val($.trim(result));

                },
                    minLength: 1
                });
             });


             $(document).ready(function () {
                 $("#<%=txtsupplyto.ClientID %>").autocomplete({

                      source: function (request, response) {
                          $("#<%=hid_SupplyTo.ClientID %>").val(0);
                          $.ajax({
                              url: "../BT/BTInvoice.aspx/GrtTo",
                              data: "{ 'prefix': '" + request.term + "','Ftype':'C'}",
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
                          $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=txtsupplyto.ClientID %>").change();
                    $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                },
                     focus: function (event, i) {
                         $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);

                        }

                    },
                     close: function (event, i) {
                         var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));

                    },
                     minLength: 1
                 });
              });



             $(document).ready(function () {
                 $("#<%=txtShippingBill.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hid_shippingBil.ClientID %>").val(0);
                          $.ajax({
                              url: "../BT/BTInvoice.aspx/GetShippingBil",
                              data: "{ 'prefix': '" + request.term + "','Ftype':'C'}",
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
                          $("#<%=txtShippingBill.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=txtShippingBill.ClientID %>").change();
                    $("#<%=hid_shippingBil.ClientID %>").val(i.item.val);
                },
                     focus: function (event, i) {
                         $("#<%=txtShippingBill.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_shippingBil.ClientID %>").val(i.item.val);
                    },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtShippingBill.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_shippingBil.ClientID %>").val(i.item.val);

                        }

                    },
                     close: function (event, i) {
                         var result = $("#<%=txtShippingBill.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtShippingBill.ClientID %>").val($.trim(result));

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
              <li><a href="#" title="">Bonded Trucking</a> </li>
              <li><a href="#" title="">Accounts</a> </li>
              <li class="current"><a href="#" title="" id="header" runat="server">Invoice</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <div style="float: left; margin: 0px 0.5% 0px 0px;"><h4><i class="icon-umbrella"></i> <asp:Label ID="lblBtInvoice" runat="server" Text=""></asp:Label></h4></div>
           <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="ShipBill1"><asp:TextBox ID="txtShippingBill" runat="server" ToolTip="Shipping Bill #" AutoPostBack="true" OnTextChanged="txtShippingBill_TextChanged"  placeholder="Shipping Bill #" CssClass="form-control"></asp:TextBox></div>
                 <div class="JobNo6"><asp:TextBox ID="txtJob" runat="server" ToolTip="Job #" placeholder="Job #" ReadOnly="true" CssClass="form-control" ></asp:TextBox></div>
                 <div class="CashDrop"> <asp:DropDownList ID="ddlBillType" runat="server" CssClass="chzn-select" data-placeholder="Bill Type" ToolTip="Bill Type">
                     <asp:ListItem Value=""></asp:ListItem>
                                        </asp:DropDownList></div>
                  <div class="RefNo6"><asp:TextBox ID="txtInvoice" runat="server" AutoPostBack="true" ToolTip="Invoice #" placeholder="Invoice#" CssClass="form-control" OnTextChanged="txtInvoice_TextChanged"></asp:TextBox></div>
                  <div class="DateCalNo1"> <asp:TextBox ID="txtDate" Enabled="false" runat="server" ToolTip="Date" placeholder="Date" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate"></asp:CalendarExtender>
                   </div>
                 <div class="Refyear"><asp:TextBox ID="txtVouyear" runat="server" ToolTip="VoueYear" placeholder="VoueYear" CssClass="form-control"></asp:TextBox></div>
                 </div>
               <div class="FormGroupContent4">
                    <div class="ToInputN11"><asp:TextBox ID="txtTo" runat="server" ToolTip="To" placeholder="To" CssClass="form-control"></asp:TextBox></div>
                   <div class="ToInputN11new"><asp:TextBox ID="txtsupplyto" runat="server" ToolTip="SupplyTo" placeholder="SupplyTo" CssClass="form-control" AutoPostBack="True" TabIndex="8" ></asp:TextBox></div>
                   </div>
              
              <div class="FormGroupContent4">
                  <div class="FromPort"><asp:TextBox ID="txtFromPort" runat="server" ToolTip="From Port" placeholder="From Port" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                  <div class="ToPort1"> <asp:TextBox ID="txtToport" runat="server" ToolTip="To Port" placeholder="To Port" CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                 <div class="CreditApproval"><asp:TextBox ID="txtCreditApproval" runat="server" ToolTip="Credit Approval" placeholder="Credit Approval" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>
                  </div>
            
                   <div class="ETDLeft">
                       <div class="FormGroupContent4">
                           <div class="ETDInput5"> <asp:TextBox ID="txtEtd" runat="server" ToolTip="ETD" placeholder="ETD" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>
                            <div class="ETAInput5"> <asp:TextBox ID="txtEta" runat="server" ToolTip="ETA" placeholder="ETA" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>

                           </div>
                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txtRemarks" runat="server" ToolTip="Remarks" placeholder="Remarks" CssClass="form-control"></asp:TextBox>
                            </div>
                       </div>
                    <div class="ETDRight">
                          <asp:Panel ID="pnlContlist" runat="server" CssClass="lst_contN2" ScrollBars="Auto">
                <asp:ListBox ID="lstcon" runat="server" Height="45px" Width="100%" ></asp:ListBox>
            </asp:Panel>
                        </div>

                  
               <div class="FormGroupContent4">
                   <div class="VendorRefNo"><asp:TextBox ID="txtVenderRef" runat="server" ToolTip="Vender Ref#" ReadOnly="true" placeholder="Vender Ref#" CssClass="form-control"></asp:TextBox></div>
                   <div class="right_btn  MB05">
                        
                       <div class="btn ico-view"><asp:Button ID="btnView" runat="server" ToolTip="View" OnClick="btnView_Click" /></div>
                       <div class="btn ico-back" id="btnCancel1" runat="server"><asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" /></div>
                       </div>
                   </div>
                <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                  <asp:GridView ID="grdViewInvoice" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true"
                    ShowHeader="true" EmptyDataSet="No Record Found" CssClass="Grid FixedHeader"  OnRowDataBound="grdViewInvoice_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="charge" HeaderText="Charges" />
                        <asp:BoundField DataField="curr" HeaderText="Curr" />
                        <asp:BoundField DataField="rate" HeaderText="Rate"  ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"/>
                        <asp:BoundField DataField="exrate" HeaderText="ExRate" />
                        <asp:BoundField DataField="base" HeaderText="Base" />
                       <%-- <asp:BoundField DataField="amount" HeaderText="Amount"  ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"/>--%>
                        <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                    <RowStyle Font-Italic="False" />
                </asp:GridView>
                   </div>
              <div class="FormGroupContent4 MB05">
                  <div class="TotalRight"><asp:TextBox ID="txtTotal" runat="server" ToolTip="Total" style="text-align:right;" placeholder="Total" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>
                  </div>
              </div>

           <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server"></label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
         </div>
            </div>
           </div>
     <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:modalpopupextender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:modalpopupextender>
      <asp:HiddenField ID="hid_date"  runat="server" />
         <asp:HiddenField ID="hid_to"  runat="server" />
        <asp:HiddenField ID="hid_shippingBil"  runat="server" />
      <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    </asp:Content>
