<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="OPBalanceBreakUpNew.aspx.cs"
    EnableEventValidation="false" Inherits="logix.FAForms.OPBalanceBreakUpNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />

    <link href="../Theme/assets/css/FA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script src="../js/helper.js"></script>

    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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

    <link href="../Styles/Ledgers.css" rel="Stylesheet" type="text/css" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />


    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <%--<script type="text/javascript">
        function pageLoad(sender, args) {         
      


            $(document).ready(function () {

                $("#<%=txtLedgerName.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "../FAForms/OPBalanceBreakUp.aspx/GetLedgername",
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
                                  //alert(response.responseText);
                              },
                              failure: function (response) {
                                  //alert(response.responseText);
                              }
                          });
                      },

                      select: function (event, i) {
                          $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                          $("#<%=txtLedgerName.ClientID %>").change();
                          $("#<%=hid_Ledgername.ClientID %>").val(i.item.val);
                          $("#<%=hid_custid.ClientID %>").val(i.item.address);

                      },
                    focus: function (event, i) {
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                          $("#<%=hid_Ledgername.ClientID %>").val(i.item.val);
                          $("#<%=hid_custid.ClientID %>").val(i.item.address);
                      },

                    close: function (e, i) {
                        var result = $("#<%=txtLedgerName.ClientID %>").val().toString().split(' ,')[0];
                          $("#<%=txtLedgerName.ClientID %>").val($.trim(result));
                      },
                    minLength: 1
                });
              });



            $(document).ready(function () {
                $("#<%=txtFCurr.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/ProfomaInvoicenew.aspx/GetLikeCurrency",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtFCurr.ClientID %>").val(i.item.label);
                        $("#<%=txtFCurr.ClientID %>").change();
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txtFCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtFCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });

           $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

           
        }

    </script>--%>


    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {

                $("#<%=txtLedgerName.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $("#<%=hid_Ledgername.ClientID %>").val(0);
                         $.ajax({
                             url: "../FAForms/OPBalanceBreakUpNew.aspx/GetLedgername",
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
                                 //alert(response.responseText);
                             },
                             failure: function (response) {
                                 //alert(response.responseText);
                             }
                         });
                     },

                     select: function (event, i) {
                         $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=txtLedgerName.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtLedgerName.ClientID %>").change();
                        $("#<%=hid_Ledgername.ClientID %>").val(i.item.val);
                        $("#<%=hid_custid.ClientID %>").val(i.item.address);

                     },
                     focus: function (event, i) {
                         $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=txtLedgerName.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_Ledgername.ClientID %>").val(i.item.val);
                        $("#<%=hid_custid.ClientID %>").val(i.item.address);
                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtLedgerName.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=hid_Ledgername.ClientID %>").val(i.item.val);
                             $("#<%=hid_custid.ClientID %>").val(i.item.address);


                         }
                     },
                     close: function (e, i) {
                         var result = $("#<%=txtLedgerName.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtLedgerName.ClientID %>").val($.trim(result));
                     },
                     minLength: 1
                 });
             });

             $(document).ready(function () {
                 $("#<%=txtFCurr.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "../FAForms/ProfomaInvoicenew.aspx/GetLikeCurrency",
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
                                  //alert(response.responseText);
                              },
                              failure: function (response) {
                                  //alert(response.responseText);
                              }
                          });
                      },
                      select: function (event, i) {
                          $("#<%=txtFCurr.ClientID %>").val(i.item.label);
                        $("#<%=txtFCurr.ClientID %>").change();
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                      },
                      focus: function (event, i) {
                          $("#<%=txtFCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                      },
                      close: function (event, i) {
                          $("#<%=txtFCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                      },
                      minLength: 1
                  });
              });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


        }

    </script>


    <style type="text/css">
        .MinAmount1 {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MinAmount2 {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MinAmount3 {
            width: 15.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MinAmount4 {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
 
        }

        .MinAmount5 {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            text-align: right;
        }

            .MinAmount5 input {
                text-align: right;
            }

        .MinAmount6 {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }



        .MinAmountFC {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .MinAmountFC input {
                text-align: right;
            }

        .MinAmountFCexra {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .MinAmountFCexra input {
                text-align: right;
            }

        .LedgerName {
            width: 89%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OpBalance {
            width: 10.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

            .OpBalance input {
                text-align: right;
            }

        .TotalJInput {
            float: right;
            width: 48%;
            margin: 0px 24% 0px 0px;
        }

        .TotalALignment1 {
            float: left;
            margin: 0px 0px 0px 30.5%;
            width: 25%;
        }

        .TotalJLBL {
            float: left;
            width: 25.5%;
            margin: 0px 0.5% 0px 0px;
            text-align: right;
        }

        .fileUpload5 {
            width: 78%;
            float: left;
            margin: 0px -58.5% 0px 0px;
        }

        .floatright5 {
            float: left;
            width: 35%;
            margin: 0px 0px 0px 0px;
        }

        .fileUpload5 input[type="file"] {
            margin: 0px !important;
            width: 54% !important;
        }

        .btnhctrlnew1 {
            width: 69%;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
        .widget-header h3 {
    font-size: 14px;
    margin-left: 29px;
        font-weight: 500;
}
.widget-header h3 i {
    display: none;
}
div#logix_CPH_CalendarExtender1_container {
    left: -48px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="">
        <div class="col-md-12"  class="maindiv">
            <div class="widget box PB20" runat="server">
                <div class="widget-header">
                    <div>
                    <h3><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_head" runat="server"></asp:Label>
                    </h3>
                        </div>

                    <div class="FixedButtons">
    <div class="btn-ctrl1">
        <div class="btn ico-add" id="btnadd1" runat="server">
            <asp:Button ID="btnadd" runat="server" ToolTip="Add" OnClick="btnadd_Click" TabIndex="6" /></div>
        <div class="btn ico-delete" id="btndelete1" runat="server">
            <asp:Button ID="btndelete" runat="server" Visible="true" TabIndex="20" ToolTip="Delete" OnClick="btndelete_Click" /></div>
    </div>
</div>

                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4">
                        <div class="LedgerName">
                            <div style="display: none;">
                                <asp:Label ID="lbl_lednam" runat="server" Text="Ledger Name" CssClass="LabelValue"></asp:Label></div>
                            <asp:TextBox ID="txtLedgerName" runat="server" CssClass="form-control" ToolTip="Ledger Name" placeholder="Ledger Name" AutoPostBack="True" OnTextChanged="txtLedgerName_TextChanged"></asp:TextBox>
                            <%--OnTextChanged="txtLedgerName_TextChanged"--%>
                        </div>
                        <div class="OpBalance">
                            <div style="display: none;">
                                <asp:Label ID="lbl_op" runat="server" Text="Op. Balance" CssClass="LabelValue"></asp:Label></div>
                            <asp:TextBox ID="txtOpbal" runat="server" ToolTip="Op. Balance" placeholder="Op. Balance" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="MinAmount1">
                            <div style="display: none;">
                                <asp:Label ID="lbl_min" runat="server" Text="Min. Amt" CssClass="LabelValue"></asp:Label></div>
                            <asp:TextBox ID="txtvouno" runat="server" AutoPostBack="true" ToolTip="Vou #" placeholder="Vou #" CssClass="form-control" TabIndex="1" OnTextChanged="txtvouno_TextChanged"></asp:TextBox>
                        </div>
                        <div class="MinAmount2">
                            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" placeholder="Date"    AutoPostBack="True" TabIndex="2"></asp:TextBox>
                        </div>

                        <div class="MinAmount3">
                            <asp:DropDownList ID="cmbvoutype" runat="server" Height="23" placeholder="Vou Type" CssClass="chzn-select" Width="100%" TabIndex="3">
                                <asp:ListItem Text="Vou Type" Value="0"></asp:ListItem>
                                <asp:ListItem Value="OI" Text="Invoice"></asp:ListItem>
                                <asp:ListItem Value="OP" Text="Credit Note - Operations"></asp:ListItem>
                                <asp:ListItem Value="OD" Text="OSDN"></asp:ListItem>
                                <asp:ListItem Value="OC" Text="OSCN"></asp:ListItem>
                                <asp:ListItem Value="OV" Text="Debit Note - Others"></asp:ListItem>
                                <asp:ListItem Value="OE" Text="Credit Note - Others"></asp:ListItem>
                                <asp:ListItem Value="OS" Text="Credit Note - Admin"></asp:ListItem>
                                <asp:ListItem Value="OX" Text="Debit Note - Admin"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="MinAmount4">
                            <asp:TextBox ID="txtvouyear" runat="server" CssClass="form-control" TabIndex="4" ToolTip="VouYear" placeholder="VouYear" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="MinAmount5">
                            <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" TabIndex="5" ToolTip="Amount" placeholder="Amount"></asp:TextBox>
                        </div>
                        <div class="MinAmount6">
                            <asp:TextBox ID="txtFCurr" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="FCurr" placeholder="FCurr" OnTextChanged="txtFCurr_TextChanged"></asp:TextBox>
                        </div>

                        <div class="MinAmountFC">
                            <asp:TextBox ID="txtFCamt" runat="server" CssClass="form-control" ToolTip="FCAmt" placeholder="FCAmt"></asp:TextBox>
                        </div>
                        <div class="MinAmountFCexra">
                            <asp:TextBox ID="txt_exrate" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="Exrate" placeholder="Exrate" OnTextChanged="txt_exrate_TextChanged"></asp:TextBox>
                        </div>

                        <div class="MinAmount2" id="txtVendorRef" runat="server">
                            <asp:TextBox ID="txtVendorRefno" runat="server" ToolTip="Vendor Ref Number" placeholder="Vendor Ref #" CssClass="form-control" TabIndex="5" AutoPostBack="True"></asp:TextBox></div>
                        <div class="MinAmount2" id="txtVendorRefnodate1" runat="server">
                            <asp:TextBox ID="txtVendorRefnodate" runat="server" ToolTip="Vendor Ref Date" placeholder="Vendor Ref Date" CssClass="form-control" TabIndex="6"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtVendorRefnodate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                    </div>




                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel2" runat="server" CssClass="gridpnl" ScrollBars="Auto">
                            <asp:GridView ID="grdINVRec" runat="server" CssClass="TblGrid" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdINVRec_RowDataBound" OnSelectedIndexChanged="grdINVRec_SelectedIndexChanged"
                                ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                <Columns>
                                    <asp:BoundField DataField="vouno" HeaderText="Vou #" />
                                    <asp:BoundField DataField="voudate" HeaderText="Date" />
                                    <asp:BoundField DataField="voutype" HeaderText="Vou Type" />
                                    <asp:BoundField DataField="vouyear" HeaderText="Vou Year" />
                                    <asp:BoundField DataField="vouamount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fcurr" HeaderText="FCurr" />
                                    <asp:BoundField DataField="famount" HeaderText="FC AMT" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="bid" HeaderText="bid" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                    <asp:BoundField DataField="vid" HeaderText="vid" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                    <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vendorrefno" HeaderText="vendorrefno">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vendorrefdate" HeaderText="vendorrefdate">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>



                    <div class="FormGroupContent4">


                        <div class="floatright5">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <Triggers>

                                    <asp:PostBackTrigger ControlID="btn_upload" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="fileUpload5">
                                        <%--style="display:none"--%>
                                        <asp:FileUpload ID="fileuploadExcel" runat="server" Width="13" />
                                    </div>
                                    <div class="btn ico-upload btnhctrlnew1">
                                        <%--style="display:none"--%>
                                        <asp:Button ID="btn_upload" runat="server" TabIndex="32" Text="Upload" OnClick="btn_upload_Click" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>

                        <div class="TotalALignment1">
                            <div class="TotalJLBL hide">
                                <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
                            </div>
                            <div class="TotalJInput">
                                <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" TabIndex="8" Placeholder="Total Amount" ToolTip="Debit Amount" Style="text-align: right" Enabled="false"></asp:TextBox>
                            </div>


                        </div>
                        <div class="right_btn MT0">
                            <div class="btn ico-save" runat="server" id="btnsave1">
                                <asp:Button ID="btnsave" runat="server" ToolTip="Save" OnClick="btnsave_Click" Visible="false" /></div>
                            <div class="btn ico-cancel" id="btncancel1" runat="server">
                                <asp:Button ID="btncancel" runat="server" ToolTip="Cancel" OnClick="btncancel_Click" /></div>
                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>



    <%-- </div> --%>
    <asp:CalendarExtender ID="ce_voudate" runat="server" TargetControlID="txtdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:HiddenField ID="hid_Ledgername" runat="server" />
    <asp:HiddenField ID="hdncurrid" runat="server" />
    <asp:HiddenField ID="hid_custid" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />

</asp:Content>
