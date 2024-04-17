<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="DepositSlip.aspx.cs"
    Inherits="logix.FAForm.DepositSlip" EnableEventValidation="false" %>

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
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

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

    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/DepositSlip.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />

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
                font-size: 12px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
            white-space: nowrap;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }

            .DepSlip {
    width: 12.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }
            .FieldInput {
    float: left;
    width: 100%;
}
            div#logix_CPH_div_deposit {
    height: calc(100vh - 230px);
}


    </style>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            <%-- $(document).ready(function () {
                 $('#<%=Grd_DepositSlip.ClientID%>').gridviewScroll({
                     weight: 1024,
                     height: 480,
                     arrowsize: 30,
                     varrowtopimg: "../images/arrowvt.png",
                     varrowbottomimg: "../images/arrowvb.png",
                     harrowleftimg: "../images/arrowhl.png",
                     harrowrightimg: "../images/arrowhr.png"
                 });
             });--%>

            //--------------Get Slip No-----------------------

            $(document).ready(function () {
                $("#<%=txt_slip.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "../FAForms/DepositSlip.aspx/GetSlipNo",
                             data: "{ 'prefix': '" + request.term + "'}",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         label: item
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
                         $("#<%=txt_slip.ClientID %>").val(i.item.label);
                         $("#<%=txt_slip.ClientID %>").change();
                         $("#<%=hidslipId.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txt_slip.ClientID %>").val(i.item.label);
                         $("#<%=hidslipId.ClientID %>").val(i.item.val);
                     },
                     close: function (e, i) {
                         var result = $("#<%=txt_slip.ClientID %>").val().toString().split[','];
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_slip.ClientID %>").val($.trim(out));
                         } else {
                             $("#<%=txt_slip.ClientID %>").val($.trim(res));
                         }
                     },

                     minLength: 1
                 });
             });

            //--------------Get Bank-----------------------

             $(document).ready(function () {
                 $("#<%=txt_bank.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_bankid.ClientID %>").val(0);
                         $.ajax({
                             url: "../FAForms/DepositSlip.aspx/GetBank",
                             data: "{ 'prefix': '" + request.term + "',ChkType:'P'}",
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
                         $("#<%=txt_bank.ClientID %>").val(i.item.label);
                        $("#<%=txt_bank.ClientID %>").change();
                        $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_bank.ClientID %>").val(i.item.label);
                         $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                     },
                    close: function (e, i) {
                        var result = $("#<%=txt_bank.ClientID %>").val().toString().split[','];
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_bank.ClientID %>").val($.trim(out));
                         } else {
                             $("#<%=txt_bank.ClientID %>").val($.trim(res));
                         }
                     },

                    minLength: 1
                });
            });

            //--------------Get Cheque Slip-----------------------

             $(document).ready(function () {
                 $("#<%=txt_cheque.ClientID %>").autocomplete({
                     source: function (request, response) {
                         if ($("#<%=ddl_receipt.ClientID %>").val() == '') {
                             alertify.alert('Please Select Type');
                             return false;
                         }
                         $.ajax({
                             url: "../FAForms/DepositSlip.aspx/GetChequeSlip",
                             data: "{ 'prefix': '" + request.term + "',Type:'" + $("#<%=ddl_receipt.ClientID %>").val() + "'}",
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
                         $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                            $("#<%=txt_cheque.ClientID %>").change();
                            $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                        },
                     focus: function (event, i) {
                         $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                            $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                        },
                        <%-- close: function (e, i) {
                            var result = $("#<%=txt_cheque.ClientID %>").val().toString().split[','];
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_cheque.ClientID %>").val($.trim(out));
                         } else {
                             $("#<%=txt_cheque.ClientID %>").val($.trim(res));
                         }
                        },
                        minLength: 1--%>

                     close: function (event, i) {
                         var result = $("#<%=txt_cheque.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txt_cheque.ClientID %>").val($.trim(result));
                        },
                     minLength: 1
                 });
             });

            //------------------Get Cheque Slip No--------------------

                $(document).ready(function () {
                    $("#<%=txt_slip_cheque.ClientID %>").autocomplete({

                        source: function (request, response) {
                            if ($("#<%=ddl_receipt.ClientID %>").val() == '') {
                             alertify.alert('Please Select Type');
                             return false;
                         }
                         $.ajax({
                             url: "../FAForms/DepositSlip.aspx/GetSlipNo_Cheque",
                             data: "{ 'prefix': '" + request.term + "',Type:'" + $("#<%=ddl_receipt.ClientID %>").val() + "'}",
                              dataType: "json",
                              type: "POST",
                              contentType: "application/json; charset=utf-8",
                              success: function (data) {
                                  response($.map(data.d, function (item) {
                                      return {
                                          label: item
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
                            $("#<%=txt_slip_cheque.ClientID %>").val(i.item.label);
                         $("#<%=txt_slip_cheque.ClientID %>").change();
                         $("#<%=hid_Sipcheque.ClientID %>").val(i.item.val);
                     },
                        focus: function (event, i) {
                            $("#<%=txt_slip_cheque.ClientID %>").val(i.item.label);
                         $("#<%=hid_Sipcheque.ClientID %>").val(i.item.val);
                     },
                        close: function (e, i) {
                            var result = $("#<%=txt_slip_cheque.ClientID %>").val().toString().split[','];
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_slip_cheque.ClientID %>").val($.trim(out));
                         } else {
                             $("#<%=txt_slip_cheque.ClientID %>").val($.trim(res));
                         }
                     },
                        minLength: 1
                    });
                });
         }

    </script>
    <style type="text/css">
        .ChQCollectiondrop {
            width: 23%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LineHeight {
            line-height: 24px;
            font-size: 14px;
        }

        .CheBox {
            float: left;
            width: 4%;
            margin: 14px 0.5% 0px 0px;
        }

        .BankLeft {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BankRight {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_lblBank {
            width: 14%;
            height: 10%;
            float: left;
            margin-top: 0%;
            text-align: left;
            margin-bottom: 0px;
        }

        .BankCr {
            width: 2.5%;
            float: left;
            margin: 10px 0px 0px 0px;
        }

        .SlipInput_Bank {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_Grid {
            width: 100%;
            height: 274px;
            float: left;
            margin-top: .5%;
            margin-left: 0%;
            overflow-y: auto;
        }

        .ChkRemarks {
            width: 67.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

     .TotalTxt2 {
    width: 9%;
    margin: 0px 0.5% 0px 56.8%;
    float: left;
}

        .DepDate {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BankTextbox {
            width: 72%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BankCash {
            width: 7%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .CheBox span {
            display: inline-block;
            margin: 0px 0px 0px 5px;
        }

        .BankWise {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ClearInput {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CR {
            width: 2%;
            float: right;
            text-align: left;
            font-size: 11px;
            margin: 10px 0px 0px 8px;
        }

        .CRLBL1 {
            width: 2.5%;
            float: left;
            text-align: left;
            font-size: 11px;
            margin: 0px 0% 0px 0px;
        }

        .ChkTillDate span, label {
            width: auto !important;
        }

        .USDCHK input {
            margin: 5px 0px 0px 5px;
        }

       .USDCHK label {
    margin: 0px 0px 0px 4px;
}

        .BRSBalance2 {
            width: 16%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SlipInput_Bank1 {
            width: 12%;
            float: left;
            margin: 0px 0px 0px 0px;
            text-align: right;
        }

        .BRSBalancechk {
            width: 20.5%;
            float: left;
            text-align: left;
            font-size: 12px;
            margin: 0px 0.5% 0px 0px;
        }

        .BRSBalanceLBL {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BalanceInputBox {
            width: 21.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BRSBalanceLBL1 {
            width: 22%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BalanceInputBox1 {
            width: 21.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BRSBalanceLBL2 {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BalanceInputBox2 {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BRSBalanceLBL3 {
            width: 21.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BalanceInputBox3 {
            width: 22.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BRSBalanceLBL4 {
            width: 10.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BalanceInputBox4 {
            width: 12%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        .BRSBalance {
            width: 19.5%;
            float: left;
            text-align: right;
            font-size: 12px;
            margin: 0px .5% 0px 0px;
        }

        .ContraDetails1 {
            width: 8.5%;
            float: left;
            text-align: left;
            font-size: 11px;
            margin: 0px 0% 0px 0px;
        }

        #logix_CPH_pln_Deposit {
            left: 0px !important;
            top: 0px !important;
        }

        .div_frame {
            width: 99%;
            height: 526px;
            overflow: auto;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 5px;
        }

        .div_frameNew1 {
            width: 1360px;
            Height: 582px;
            float: left;
            text-align: center;
            /* overflow-y: scroll; */
        }

        .div_Trialbalance {
            float: right;
        }

        #logix_CPH_drp_Sorting_chzn {
            width: 100% !important;
        }

        .LabelValue {
            font-family: sans-serif;
            font-size: 11px;
            color: #000;
            font-weight: normal;
            text-align: right;
        }

        .CheQuetxt {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SlipInput {
            width: 17.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ContraDrop {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LabelWidth {
            font-size: 12px;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.5%;
            margin-top: 0.7%;
            border-radius: 90px 90px 90px 90px;
        }
    </style>

    <script type="text/javascript">

        function validate() {
            if (document.getElementById("<%=ddl_receipt.ClientID%>") == -1) {
                alertify.alert('Please Select Type');
                document.getElementById("<%=txt_cheque.ClientID%>").focus();
                 return false;
             }
             else {
                 return true;
             }
         }

         function validatecheque() {
             if (document.getElementById("<%=ddl_receipt.ClientID%>") == -1) {
                alertify.alert('Please Select Type');
                document.getElementById("<%=txt_slip_cheque.ClientID%>").focus();
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <style type="text/css">
        .USDCHK {
            width: 5%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

div#logix_CPH_div_chkusd,
.LabelWidth {
    display: flex;
    flex-direction: column-reverse;
}

div#logix_CPH_div_chkusd center+label, 
.LabelWidth center+label {
   
    font-size: 12px !important;
    margin: 0 0 0 5px !important;
    display: block;
    color: var(--labelblue) !important;
    font-weight: 500;
}
        .TblGrid input {
            margin: 0px 0px 0px 18px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server"></asp:Label></h4>
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Vouchers</a> </li>
            <%--<li><a href="#" title="" id="lbl_head" runat="server">Deposit Slip</a> </li>--%>
            <li class="current"><a href="#" title="" id="lbl_head" runat="server">Deposit Slip</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div id="div_deposite" runat="server">
                            <div class="FormGroupContent4">
                                <div class="DepSlip">
                                    <asp:Label  ID="lbl_slip" runat="server" Text="Slip #"></asp:Label>

                                    <asp:TextBox ID="txt_slip" runat="server" placeholder="" ToolTip="Slip #" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_slip_TextChanged"></asp:TextBox>
                                </div>
                                <div class="BankTextbox">
                                    <asp:Label  ID="lbl_bank" runat="server" Text="Bank"></asp:Label>
                                    <asp:TextBox ID="txt_bank" runat="server" placeholder="" ToolTip="Bank" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="DepDate">
                                    <asp:Label  ID="lbl_depositedate" runat="server" Text="Date"></asp:Label>

                                    <asp:TextBox ID="txt_depositedate" runat="server" placeholder="" ToolTip="Deposit Date" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_depositedate_calender" runat="server" TargetControlID="txt_depositedate" Enabled="true" Format="dd/MM/yyyy" />
                                </div>
                                <div class="BankCash">
                                    <asp:Label  ID="lbl_type" runat="server" Text="Dr / Cr "></asp:Label>

                                    <asp:DropDownList ID="ddl_type" runat="server" Height="23px" CssClass="chzn-select" AutoPostBack="True" ToolTip="Dr / Cr" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Dr / Cr</asp:ListItem>
                                        <asp:ListItem Value="C">Cash</asp:ListItem>
                                        <asp:ListItem Value="B">Bank</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="HeadingDeposit" runat="server">
                        <div class="FormGroupContent4">

                            <div class="ContraDrop">
                                <div class="LabelWidth hide">Receipt / Payment</div>
                                <div class="FieldInput">
                                    <asp:DropDownList ID="ddl_receipt" runat="server" Height="23px" CssClass="chzn-select" dataplaceholder="Receipt/Payment" AutoPostBack="true" ToolTip="Receipt/Payment" OnSelectedIndexChanged="ddl_receipt_SelectedIndexChanged">
                                        <%-- <asp:ListItem>Receipt/Payment</asp:ListItem>--%>
                                        <asp:ListItem Value="0">ALL</asp:ListItem>
                                        <asp:ListItem Value="R">Receipts</asp:ListItem>
                                        <asp:ListItem Value="P">Payments</asp:ListItem>
                                        <asp:ListItem Value="O">Contra</asp:ListItem>
                                        <asp:ListItem Value="X">Overseas Receipt</asp:ListItem>
                                        <asp:ListItem Value="Y">Overseas Payment</asp:ListItem>
                                        <asp:ListItem Value="Z">Manual Bank Receipt</asp:ListItem>
                                        <asp:ListItem Value="S">Manual Bank Payment</asp:ListItem>
                                        <asp:ListItem Value="BRR">Bank Receipt Reverse</asp:ListItem>
                                        <asp:ListItem Value="BPR">Bank Payment Reverse</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="CheQuetxt">
                                <div class="LabelWidth hide">Cheque #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_cheque" runat="server" CssClass="form-control" placeholder="Cheque #" ToolTip="Cheque #" AutoPostBack="true" OnTextChanged="txt_cheque_TextChanged"></asp:TextBox></div>

                            </div>
                            <div class="ClearInput">
                                <div class="LabelWidth hide">Cleared Date</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_chequedate" runat="server" CssClass="form-control" placeholder="Cleared Date" ToolTip="Cleared Date"></asp:TextBox></div>

                            </div>
                            <div class="SlipInput">
                                <div class="LabelWidth hide">Slip #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_slip_cheque" runat="server" CssClass="form-control" placeholder="Slip #" ToolTip="Slip #" Enabled="false" AutoPostBack="true"
                                        OnTextChanged="txt_slip_cheque_TextChanged" OnKeyPress="return validatecheque();"></asp:TextBox>
                                </div>

                            </div>
                            <div class="BankWise">
                                <div class="LabelWidth hide">Sort By</div>
                                <div class="FieldInput">
                                    <asp:DropDownList ID="drp_Sorting" runat="server" ToolTip="Sort By" CssClass="chzn-select" placeholder="Sorded By" AutoPostBack="true" OnSelectedIndexChanged="drp_Sorting_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Sort By</asp:ListItem>
                                        <asp:ListItem Value="Cheque #">Cheque #</asp:ListItem>
                                        <asp:ListItem Value="Cheque Date">Cheque Date</asp:ListItem>
                                        <asp:ListItem Value="Bank">Bank</asp:ListItem>
                                        <asp:ListItem Value="Slip #">Slip #</asp:ListItem>
                                        <asp:ListItem Value="Branch">Branch</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="ChQCollectiondrop">
                                <div class="LabelWidth hide">Bank</div>
                                <div class="FieldInput">
                                    <asp:DropDownList ID="ddl_bank" Height="23px" runat="server" CssClass="chzn-select" AppendDataBoundItems="true" AutoPostBack="true" ToolTip="Bank" OnSelectedIndexChanged="ddl_bank_SelectedIndexChanged"></asp:DropDownList></div>

                            </div>
                            <div class="USDCHK MTCtrl6" id="div_chkusd" runat="server" visible="false">
                                <asp:CheckBox ID="chkc" runat="server" Text="U S D"></asp:CheckBox>
                            </div>
                            <div class="CheBox MTCtrl6">
                                <div class="LabelWidth">
                                    <asp:CheckBox ID="Chk_Date" runat="server" AutoPostBack="true" Checked="true" Text="=" OnCheckedChanged="Chk_Date_CheckedChanged" />
                                    <asp:Label CssClass="LineHeight" ID="Equal" runat="server" Visible="false">=</asp:Label>
                                </div>

                            </div>
                            <div class=" right_btn custom-mt-3">
                            <div class="btn ico-get">
                                <asp:Button ID="btn_Get" runat="server" Text="Get" ToolTip="Get" OnClick="btn_Get_Click" />
                            </div>
                                </div>
                                
                        </div>
                        <div class="bordertopNew"></div>
                        <div class="FormGroupContent4">

                            <div class="SlipInput_Bank">
                                <div class="FieldInput">
                                    <asp:Label ID="lbl_Book" runat="server" Text="Balance as Per Our Book" CssClass="hide"></asp:Label>
                                    <div class="FormGroupContent4">
                                    <asp:TextBox ID="txt_Book" runat="server" placeholder="Balance as Per Our Book" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>
                                </div>
                            </div>
                            <div class="BankCr MTCtrl6">
                                <asp:Label ID="lblourbook" runat="server" Text="Cr" CssClass="LblValue"></asp:Label>
                            </div>
                            <div class="CR MTCtrl6">
                                <asp:Label ID="Label1" runat="server" Text="Cr" CssClass="LabelValue"></asp:Label>
                            </div>
                            <div class="BalanceInputBox4">
                                <div class="FieldInput">
                                    <asp:Label ID="Label8" runat="server" Text="Balance as Per Bank" CssClass="hide"></asp:Label>
                                    <div class="FormGroupContent4">
                                    <asp:TextBox ID="txtbank" runat="server" placeholder="Balance as Per Bank" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>
                                    </div>
                            </div>

                            <div style="display: none;">   
                                <div class="SlipInput_Bank" style="display: none;">
                                    <div class="LabelWidth">
                                        <asp:Label ID="lbl_Bank1" runat="server" Text="Balance as Per Our Bank" CssClass="LblValue"></asp:Label></div>
                                    <div class="FieldInput">
                                        <asp:TextBox ID="txt_BRSBank" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>

                                </div>
                                <div class="BankCr MTCtrl6" style="display: none;">
                                    <asp:Label ID="lblperbank" runat="server" Text="Cr" CssClass="LblValue"></asp:Label>
                                </div>

                                <div id="div_chequeclear" runat="server" visible="false">
                                    <div class="BRSBalance">
                                        <div class="LabelWidth">
                                            <asp:LinkButton ID="lnk_chqdeposit" runat="server" Text="(-) Cheque Deposited but not Cleared" OnClick="lnk_chqdeposit_Click"></asp:LinkButton></div>
                                        <div class="FieldInput">
                                            <asp:TextBox ID="txtreceipt_brs" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>
                                    </div>

                                    <div class="BRSBalance1">

                                        <asp:TextBox ID="txt_Receipt" runat="server" Visible="False" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                    </div>
                                    <div class="BRSBalance2">
                                        <div class="LabelWidth">
                                            <asp:Label ID="lbl_balance_chq" runat="server" Text="Balance"></asp:Label></div>
                                        <div class="FieldInput">
                                            <asp:TextBox ID="txttotal" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>
                                    </div>

                                    <div class="CR MTCtrl6">
                                        <asp:Label ID="lbltolcr" runat="server" Text="Cr"></asp:Label>
                                    </div>

                                    <div class="BRSBalancechk">
                                        <div class="LabelWidth">
                                            <asp:LinkButton ID="lnk_chqissue" runat="server" Text="(+) Cheque issued but not Cleared" OnClick="lnk_chqissue_Click"></asp:LinkButton></div>
                                        <div class="FieldInput">
                                            <asp:TextBox ID="txtpayment_brs" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>

                                    </div>
                                    <div class="BalanceInputBox">
                                        <div class="LabelWidth">
                                            <asp:Label ID="Label5" runat="server" Text="Balance" CssClass="LabelValue"></asp:Label></div>
                                        <div class="FieldInput">
                                            <asp:TextBox ID="txttotal_balance" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>
                                    </div>
                                    <div class="CR MTCtrl6">

                                        <asp:Label ID="Lbl3" runat="server" Text="Cr" CssClass="LabelValue"></asp:Label>
                                    </div>

                                    <div class="SlipInput_Bank">
                                        <asp:TextBox ID="txt_contraDB" runat="server" Visible="False" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="FormGroupContent4">

                                <div style="display: none;">
                                    <div id="creditbank" runat="server">

                                        <div class="BalanceInputBox1">
                                            <div class="LabelWidth">
                                                <asp:Label ID="Label6" runat="server" Text="(+) Credited by Bank but Not in Our Book"></asp:Label>
                                            </div>
                                            <div class="FieldInput">
                                                <asp:TextBox ID="txtCBNB_brs" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>
                                        </div>

                                        <div class="BalanceInputBox2">
                                            <div class="LabelWidth">
                                                <asp:Label ID="Label3" runat="server" Text="Balance" CssClass="LabelValue"></asp:Label></div>
                                            <div class="FieldInput">
                                                <asp:TextBox ID="txttotal2" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>

                                        </div>
                                        <div class="CRLBL1 MTCtrl6">

                                            <asp:Label ID="lbl5" runat="server" Text="Cr" CssClass="LabelValue"></asp:Label>
                                        </div>

                                        <div class="BalanceInputBox3">
                                            <div class="LabelWidth">
                                                <asp:Label ID="Label7" runat="server" Text="(-) Debited by Bank but Not in Our Book" CssClass="LabelValue"></asp:Label></div>
                                            <div class="FieldInput">
                                                <asp:TextBox ID="txtDBNB_brs" runat="server" CssClass="form-control" Style="text-align: right"></asp:TextBox></div>
                                        </div>

                                        <div class="ContraDetails1 MTCtrl6">
                                            <asp:LinkButton ID="lnk_contra" runat="server" Text="Contra Details" OnClick="lnk_contra_Click" CssClass="LabelValue" ForeColor="Red"></asp:LinkButton>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <div class="gridpnl" id="div_deposit" runat="server">
                            <asp:GridView ID="Grd_DepositSlip" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="TblGrid FixedHeader" ShowHeaderWhenEmpty="true"
                                EmptyDataText="No Records Founds" OnRowDataBound="Grd_DepositSlip_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="chequedate" HeaderText="Date">
                                        <ItemStyle Width="70px" />
                                        <HeaderStyle Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="chequeno" HeaderText="Cheque #">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="false" />
                                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Bank / Branch">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 190px">
                                                <asp:Label ID="bank" runat="server" Text='<%# Bind("bank") %>' ToolTip='<%#Bind("bank")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="200px" Wrap="false" />
                                        <ItemStyle Width="200px" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 280px">
                                                <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"  Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left"  Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="amount" HeaderText="Amount" Visible="True" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chk_Select" runat="server" OnCheckedChanged="Chk_Select_Click" AutoPostBack="true" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px" CssClass="align-center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Slip #" HeaderText="Slip #">
                                        <HeaderStyle HorizontalAlign="Center" Width="120px" Wrap="false" />
                                        <ItemStyle Width="120px" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClearedOn" HeaderText="Cleared On">
                                        <HeaderStyle HorizontalAlign="Center" Width="120px" Wrap="false" />
                                        <ItemStyle Width="120px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="shortname" HeaderText="Branch">
                                        <ItemStyle Width="150px" />
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundField>
                                </Columns>

                                <AlternatingRowStyle CssClass="GrdRowStyle" />
                                <HeaderStyle CssClass="" />
                                <RowStyle CssClass="GridviewScrollItem" />
                                <PagerStyle CssClass="GridviewScrollPager" />

                            </asp:GridView>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="ChkRemarks" style="display: none;">
                            <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control" placeholder="Remarks" ToolTip="Remarks"></asp:TextBox>
                        </div>

                        <div class="TotalTxt2">
                            <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" placeholder="Total" ToolTip="Total" Style="text-align: right"></asp:TextBox>
                        </div>
                        <div class="right_btn ">
                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                            </div>
                        </div>

                    </div>

                    <div class="FormGroupContent4">

                        <div class="div_lblDeposit">
                            <asp:Label ID="lbl_ChequeDeposit" runat="server" Text="(-) Cheque Deposited but not Cleared" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_txtDeposit">
                            <asp:TextBox ID="txtreceipt" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblreceipt" runat="server" Text="Cr"></asp:Label>
                        </div>

                        <div class="div_lblCredit">
                            <asp:Label ID="lbl_Balance" runat="server" Text="Balance" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_txtDeposit">
                            <asp:TextBox ID="txtbrstotal" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblbrstotal" runat="server" Text="Cr"></asp:Label>
                        </div>

                        <div class="div_lblDeposit">
                            <asp:Label ID="lbl_ChequeIssued" runat="server" Text="(+) Cheque issued but not Cleared" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_txtDeposit">
                            <asp:TextBox ID="txtpayment" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="div_lblCredit">
                            <asp:Label ID="lbl_IssuedBalance" runat="server" Text="Balance" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_txtDeposit">
                            <asp:TextBox ID="txttotal1" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lbl_total1" runat="server" Text="Cr"></asp:Label>
                        </div>

                        <div class="div_lblDeposit">
                            <asp:Label ID="lbl_CreditBank" runat="server" Text="(+) Credited by Bank but Not in Our Book" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_txtDeposit">
                            <asp:TextBox ID="txtCBNB" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="div_lblCredit">
                            <asp:Label ID="lbl_CreditBankBalance" runat="server" Text="Balance" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_txtDeposit">
                            <asp:TextBox ID="txtTotal2_chq" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lbl_Total2" runat="server" Text="Cr"></asp:Label>
                        </div>

                        <div class="div_lblDeposit">
                            <asp:Label ID="lbl_Debit" runat="server" Text="(-) Debited by Bank but Not in Our Book" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="div_txtDeposit">
                            <asp:TextBox ID="txtDBNB" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div style="clear: both;"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="FormGroupContent4">
        <asp:HiddenField ID="hid" runat="server" />
        <asp:Panel ID="pln_Deposit" runat="server" class="div_frameNew1" BackColor="White">

            <div class="DivSecPanel">
                <asp:Image ID="Close_Trialbalance" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <div class="div_frame">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" CssClass="GridContraN">
                    <asp:GridView ID="grdContra" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="false" OnRowDataBound="grdContra_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                        <Columns>
                            <asp:BoundField DataField="chequedate" HeaderText="Date" />
                            <%-- 0--%>
                            <asp:BoundField DataField="chequeno" HeaderText="Cheque #"><%-- 1--%>
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="bank" HeaderText="Bank / Branch" Visible="false"><%-- 2--%>
                                <ItemStyle Wrap="false" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Customer"><%-- 3 --%>
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 180px">
                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" Width="160px" Wrap="false" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="amount" HeaderText="Amount" Visible="True"><%-- 4--%>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="branch" HeaderText="Branch" />
                            <%-- 5--%>
                            <asp:BoundField DataField="Rid" HeaderText="Rid" Visible="False" />
                            <%--6--%>
                        </Columns>
                    </asp:GridView>
                    <div class="Clear"></div>
                    <asp:GridView ID="grdPayment" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdPayment_RowDataBound"
                        ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                        <Columns>
                            <asp:BoundField DataField="chequedate" HeaderText="IssuedDate" />
                            <%-- 0--%>
                            <asp:BoundField DataField="chequeno" HeaderText="Cheque #"><%-- 1 --%>
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="bank" HeaderText="Bank / Branch" Visible="false"><%-- 2 --%>
                                <ItemStyle Wrap="false" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Customer"><%-- 3 --%>
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 180px">
                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" Width="160px" Wrap="false" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="amount" HeaderText="Amount" Visible="True"><%-- 4 --%>                                      
                            </asp:BoundField>
                            <asp:BoundField DataField="branch" HeaderText="Branch" Visible="True" />
                            <%-- 5 --%>
                            <asp:BoundField DataField="Rid" HeaderText="Rid" Visible="False" />
                            <%-- 6 --%>
                        </Columns>
                    </asp:GridView>
                    <div class="Clear"></div>

                    <asp:GridView ID="GrdReceipt" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="false" OnRowDataBound="GrdReceipt_RowDataBound"
                        ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                        <Columns>
                            <asp:BoundField DataField="chequedate" HeaderText="Deposit Date" />
                            <%-- 0--%>
                            <asp:BoundField DataField="chequeno" HeaderText="Cheque #"><%-- 1 --%>
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="bank" HeaderText="Bank / Branch" Visible="false"><%-- 2 --%>
                                <ItemStyle Wrap="false" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Customer"><%-- 3 --%>
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 180px">
                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%#Bind("customername")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" Width="160px" Wrap="false" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="amount" HeaderText="Amount" Visible="True"><%-- 4 --%>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="branch" HeaderText="Branch" Visible="True" />
                            <%-- 5 --%>
                            <asp:BoundField DataField="Rid" HeaderText="Rid" Visible="False" />
                            <%-- 6 --%>
                        </Columns>
                    </asp:GridView>
                    <div class="Clear"></div>
                </asp:Panel>
            </div>
        </asp:Panel>
    </div>

    <asp:ModalPopupExtender ID="popup_Deposit" runat="server" PopupControlID="pln_Deposit"
        TargetControlID="lbl_hid" CancelControlID="Close_Trialbalance">
        <Animations>
        <OnShown>
            <FadeIn Duration="1.5" Fps="40" />                
        </OnShown>
        </Animations>
    </asp:ModalPopupExtender>

    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_chequedate" Format="dd/MM/yyyy" />
    <asp:HiddenField ID="hid_bankid" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_StrDate" runat="server" />
    <asp:HiddenField ID="hid_slipid" runat="server" />
    <asp:HiddenField ID="hid_RecDate" runat="server" />
    <asp:HiddenField ID="hid_VouYear" runat="server" />
    <asp:HiddenField ID="Hid_LoginBranchID" runat="server" />
    <asp:HiddenField ID="hidslipId" runat="server" />
    <asp:HiddenField ID="hid_cheque" runat="server" />
    <asp:HiddenField ID="hid_Sipcheque" runat="server" />
    <asp:HiddenField ID="hid_GridchequeDate" runat="server" />

    <asp:TextBox ID="txtbook" runat="server" Style="display: none;"></asp:TextBox>
    <asp:Label ID="lbl_hid" runat="server" />

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
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
