<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="OPBalanceBreakUp.aspx.cs" EnableEventValidation="false" Inherits="logix.FAForms.OPBalance_BreakUp" %>

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
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->

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
                                  //alertify.alert(response.responseText);
                              },
                              failure: function (response) {
                                  //alertify.alert(response.responseText);
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
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
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MinAmount2 {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MinAmount3 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MinAmount4 {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            text-align: right;
        }

        .MinAmount5 {
            width: 9.5%;
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
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .MinAmountFC input {
                text-align: right;
            }

        .MinAmountFCexra {
            width: 4.5%;
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
            margin: 0px 28% 0px 0px;
        }

        .TotalALignment1 {
            float: left;
            margin: 0px 0px 0px 0px;
            width: 25%;
        }

        .TotalJLBL {
            float: left;
            width: 25.5%;
            margin: 0px 0.5% 0px 0px;
            text-align: right;
            display:none;
        }

        .fileUpload5 {
            width: 46%;
            float: left;
            margin: 10px 0.5% 0px 0px;
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
    margin: 5px 0.5% 0px 0.5%;
    float: left;
}

        /*CSS*/

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
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
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
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
            white-space: nowrap;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .btn-ctrl1 {
            float: right;
            margin: 8px 0px 0px 0px;
        }

        .MinAmount4 {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            text-align: left;
        }

        .TotalJLBL {
            float: left;
            width: 25.5%;
            margin: 23px 0.5% 0px 0px;
            text-align: right;
        }

/* FixedHeader */

.right_btn {
    float: right;
    margin: 0px 0px 0px 0px;
}

.widget.box{
    position: relative;
    top: -8px;
}
div#logix_CPH_btncancel1 {
    margin: 6px 0 0 0;
}
.widget-header h4 {
    display: inline-block !important;
}
input#logix_CPH_fileuploadExcel {
    height: 36px;
    padding: 8px;
    width: 100% !important;
    border: 0px solid #b0aeae !important;
    background-color: #fff;
}
.widget.box .widget-header h4 {
    margin-bottom: 0;
    padding-left: 38px !important;
    margin-top: -5px;
}

div#UpdatePanel1 {
    /* height: 100vh; */
    height: 90vh;
    overflow-x: hidden;
    overflow-y: auto;
}
 
    span#logix_CPH_lbl_head {
    display: block;
    margin: 14px 0px 0px 0px;
}
    .TotalJInput.TextField span {
    text-align: right;
}
    .widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}
    .left_btn {
    float: left;
    margin: 11px 0px 0px 0px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4>
                        <asp:Label ID="lbl_head" runat="server" Text="OPBalance Breakup"></asp:Label>
                    </h4>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                                       <div class="FixedButtons">
                       <div class="right_btn"> 
                        <div class="btn ico-cancel" id="btncancel1" runat="server">
    <asp:Button ID="btncancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
</div>
                           </div> 
                   </div>


                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="LedgerName">
                            <asp:Label ID="lbl_lednam" runat="server" Text="Ledger Name" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txtLedgerName" runat="server" CssClass="form-control" ToolTip="Ledger Name" placeholder="" AutoPostBack="True" OnTextChanged="txtLedgerName_TextChanged"></asp:TextBox>
                            <%--OnTextChanged="txtLedgerName_TextChanged"--%>
                        </div>
                        <div class="OpBalance">
                            <asp:Label ID="lbl_op" runat="server" Text="Op. Balance" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txtOpbal" runat="server" ToolTip="Op. Balance" placeholder="" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="MinAmount1">

                            <asp:Label ID="lbl_min" runat="server" Text="Vou #" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txtvouno" runat="server" AutoPostBack="true" ToolTip="Vou #" placeholder="" CssClass="form-control" TabIndex="1" OnTextChanged="txtvouno_TextChanged"></asp:TextBox>
                        </div>
                        <div class="MinAmount2">
                            <asp:Label ID="Label2" runat="server" Text="Date"> </asp:Label>
                            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2"></asp:TextBox>
                        </div>

                        <div class="MinAmount3">
                            <asp:Label ID="Label3" runat="server" Text="Vou Type"> </asp:Label>
                            <asp:DropDownList ID="cmbvoutype" runat="server" Height="23" CssClass="chzn-select" Width="100%" TabIndex="3">
                                <asp:ListItem Text="Vou Type" Value="0"></asp:ListItem>
                                <asp:ListItem Value="OI" Text="Invoice"></asp:ListItem>
                                <asp:ListItem Value="OP" Text="Credit Note - Operations"></asp:ListItem>
                                <asp:ListItem Value="OD" Text="OSSI"></asp:ListItem>
                                <asp:ListItem Value="OC" Text="OSPI"></asp:ListItem>
                                <asp:ListItem Value="OV" Text="Debit Note - Others"></asp:ListItem>
                                <asp:ListItem Value="OE" Text="Credit Note - Others"></asp:ListItem>
                                <asp:ListItem Value="OS" Text="Admin Purchase Invoice"></asp:ListItem>
                                <asp:ListItem Value="OX" Text="Admin Sales Invoice"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="MinAmount4">
                            <asp:Label ID="Label5" runat="server" Text="VouYear"> </asp:Label>
                            <asp:TextBox ID="txtvouyear" runat="server" CssClass="form-control" TabIndex="4" ToolTip="VouYear" placeholder=""></asp:TextBox>
                        </div>
                        <div class="MinAmount5">
                            <asp:Label ID="Label6" runat="server" Text="Amount"> </asp:Label>
                            <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" TabIndex="5" ToolTip="Amount" placeholder=""></asp:TextBox>
                        </div>
                        <div class="MinAmount6">
                            <asp:Label ID="Label7" runat="server" Text="FCurr"> </asp:Label>
                            <asp:TextBox ID="txtFCurr" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="FCurr" placeholder="" OnTextChanged="txtFCurr_TextChanged"></asp:TextBox>
                        </div>

                        <div class="MinAmountFC">
                            <asp:Label ID="Label8" runat="server" Text="FCAmt"> </asp:Label>
                            <asp:TextBox ID="txtFCamt" runat="server" CssClass="form-control" ToolTip="FCAmt" placeholder=""></asp:TextBox>
                        </div>
                        <div class="MinAmountFCexra">
                            <asp:Label ID="Label9" runat="server" Text="Exrate"> </asp:Label>
                            <asp:TextBox ID="txt_exrate" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="Exrate" placeholder="" OnTextChanged="txt_exrate_TextChanged"></asp:TextBox>
                        </div>

                        <div class="MinAmount2" id="txtVendorRef" runat="server">
                            <asp:Label ID="Label10" runat="server" Text="Vendor Ref #"> </asp:Label>
                            <asp:TextBox ID="txtVendorRefno" runat="server" ToolTip="Vendor Ref Number" placeholder="" CssClass="form-control" TabIndex="5" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="MinAmount2 DateR" id="txtVendorRefnodate1" runat="server" style="width: 9%;" >
                            <asp:Label ID="Label11" runat="server" Text="Vendor Ref Date"> </asp:Label>
                            <asp:TextBox ID="txtVendorRefnodate" runat="server" ToolTip="Vendor Ref Date" placeholder="" CssClass="form-control" TabIndex="6"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtVendorRefnodate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                        <div class="left_btn">
                            <div class="btn ico-add" id="btnadd1" runat="server">
                                <asp:Button ID="btnadd" runat="server" ToolTip="Add" Text="Add" OnClick="btnadd_Click" TabIndex="6" />
                            </div>
                            <div class="btn ico-delete" id="btndelete1" runat="server">
                                <asp:Button ID="btndelete" runat="server" Text="Delete" Visible="true" TabIndex="20" ToolTip="Delete" OnClick="btndelete_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel2" runat="server" CssClass="gridpnl" ScrollBars="Auto">
                            <asp:GridView ID="grdINVRec" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdINVRec_RowDataBound" OnSelectedIndexChanged="grdINVRec_SelectedIndexChanged"
                                ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grdINVRec_PreRender"  >
                                <Columns>
                                    <asp:BoundField DataField="vouno" HeaderText="Vou #" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
                                    <asp:BoundField DataField="voudate" HeaderText="Date" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                    <asp:BoundField DataField="voutype" HeaderText="Vou Type" />
                                    <asp:BoundField DataField="vouyear" HeaderText="Vou Year" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                    <asp:BoundField DataField="vouamount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fcurr" HeaderText="FCurr" HeaderStyle-Width="120px" ItemStyle-Width="120px" />
                                    <asp:BoundField DataField="famount" HeaderText="FC Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Width="120px" />
                                        <HeaderStyle Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="bid" HeaderText="bid" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                    <asp:BoundField DataField="vid" HeaderText="vid" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                    <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Width="120px" />
                                        <HeaderStyle Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vendorrefno" HeaderText="vendor ref #">
                                        <HeaderStyle CssClass="Hide" Width="120px" />
                                        <ItemStyle CssClass="Hide" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vendorrefdate" HeaderText="vendor ref date" >
                                        <HeaderStyle CssClass="Hide"  Width="120px"/>
                                        <ItemStyle CssClass="Hide" Width="120px" />
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
                                        <asp:Button ID="btn_upload" runat="server" Text="Upload" TabIndex="32" ToolTip="Upload" OnClick="btn_upload_Click" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                        <div class="TotalALignment1">
                            <div class="TotalJLBL">
                                <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
                            </div>
                            <div class="TotalJInput">
                                <asp:Label ID="Label12" runat="server" CssClass="hide" Text="Total Amount"> </asp:Label>
                                <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" TabIndex="8" Placeholder="" ToolTip="Debit Amount" Style="text-align: right" Enabled="false"></asp:TextBox>
                            </div>

                        </div>
                        <div class="right_btn">
                            <div class="btn ico-save" runat="server" id="btnsave1" visible="false"  style="margin-top:6px;" >
                                <asp:Button ID="btnsave" runat="server" Text="Save" ToolTip="Save" OnClick="btnsave_Click" Visible="false" />
                            </div>
                           
                        </div>
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

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>OPBalance BreakUp #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
