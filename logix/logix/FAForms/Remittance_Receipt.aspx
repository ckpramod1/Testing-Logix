<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true"
    CodeBehind="Remittance_Receipt.aspx.cs" Inherits="logix.FAForms.Remittance_Receipt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    <%-- <link href="../CSS/CSFANEW.css" rel="stylesheet" />--%>

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/PaymentFA.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <!-- App -->
    <script type="text/javascript" src="../js/helper.js"></script>
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

    <link href="../Styles/RemittenceReceipt.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

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

        .widget-content {
            padding: 0 10px !important;
        }

        span#logix_CPH_lbl_voucher {
            font-weight: normal !important;
            font-size: 11px;
        }

        input[type=file] {
            height: 36px;
            padding: 8px;
            margin: 10px 0 5px !important;
        }

        .CorporateChk {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CorporateDrop {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CorporateLBL {
                width: 100%;
    right: 19%;
    margin: -22px 0.5% 0px 0px;
    position: absolute;
        }

        span#logix_CPH_lbl_title {
            font-size: 11px;
            font-weight: normal !important;
        }
 

        .Break {
            clear: both;
        }

        .Hide {
            display: none;
        }

        .div_confirm {
            /*Border:1px solid red;*/
            width: 100%;
            float: left;
            margin-left: 30%;
            margin-top: 0%;
        }

       .CorPorateTotal {
    float: right;
    margin: 0px 10px 0 0;
    width: 40%;
}

        input#logix_CPH_Chk_accountpay {
            margin: 16px 0 0;
        }

        .CorporateTotalRs {
    float: right;
    margin: 0px 3px 0 0;
    width: 37%;
}

        .Grid_Account {
            border: 0px solid #999997 !important;
            float: left;
            margin: 5px 0px 0px 0px !important;
            height: fit-content !important;
            width: 100%;
        }

        .divpnl {
            height: 338px;
            margin-top: 0.5%;
            width: 100%;
            border: 1px solid #b1b1b1;
            overflow-y: scroll !important;
            overflow-x: auto !important;
        }

        div#logix_CPH_btn_back2 {
            margin: 0px 3px 0px 0px;
        }

       .CorporateBranch {
    float: left;
    margin: 0 0 0 0;
    width: 24%;
}



       .CorporateDate {
    float: left;
    margin: 0 0.5% 0 0;
    width: 8.5%;
}

        .CorporateNar {
            float: left;
            margin: 0 0 0 0;
            width: 100%;
        }

        .CorporateCal {
            float: right;
            margin: 0 0px 0 0;
            width: 6%;
        }

       .CorporateYear {
    float: right;
    margin: 0 0.5% 0 0;
    width: 4%;
}

.CorporateUSD {
    float: left;
    margin: 0 0.5% 0 0;
    width: 5.5%;
}

  .CorporateAmount {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

  .CorporateRate {
    float: left;
    margin: 0 0.5% 0 0;
    width: 8%;
}

        .CorporateChkDD {
            width: 16%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

       .CorporatePay {
    float: left;
    margin: 0 0.5% 0 0;
    width: 65%;
}
       .CorporateAmountRs {
    float: left;
    margin: 0 0% 0 0;
    width: 11.5%;
}

       .CorporateReceipt {
    float: right;
    margin: 0 0.5% 0 0;
    width: 7%;
}

        .Addbtn {
            float: right;
            margin: 0 0.5% 0 0;
            width: 4.5%;
        }

       .CorporateCustmer {
    float: left;
    margin: 0 0.5% 0 0;
    width: 80%;
}

       .CorporDeau {
    float: left;
    margin: 0 0.5% 0 0;
    width: 13.6%;
}

 .CorporDeduction {
    float: left;
    margin: 0 0.5% 0 0;
    width: 65.8%;
}

        .CorporateBank {
            float: left;
            margin: 0 0.5% 0 0;
            width: 50%;
        }

         

       .CorExcess {
    float: right;
    margin: 0 0.5% 0 0;
    width: 14.6%;
}
.CorporateAmount1 {
    float: left;
    margin: 0 0px 0 0;
    width: 14.9%;
}

        .btn.btn-add-icon-blue {
            float: right;
        }
        .btn.ico-add.custom-mt-3 {
    float: right;
}.CorTDS {
    float: left;
    margin: 0 0.5% 0 0;
    width: 14.55%;
}

        .CorporateVoucher {
            width: 15%;
            float: left;
            margin: 20px 0.5% 0px 0.5px;
        }

        .LabelValue {
            margin: 0px 0px 0px 0.5px !important;
        }

.CorporateVouInput {
    float: right;
    margin: 16px 0.5% 0 0;
    width: 25%;
}


  
        .CorAccount {
            /* display: flex; */
            /* align-items: self-end; */
            margin: 8px 0 0 0;
        }

        .CorporateVouInput label {
            margin: 0px 5px 0px;
        }

.CorporateVouInputN1 {
    float: right;
    margin: 0 0px 5px 0;
    width: 30.5%;
}

        .CorporateVouInput input {
            float: left;
            margin: 5px 0px 0px 1%;
        }

        #logix_CPH_cmbvoutype {
            width: 100% !important;
        }

        #logix_CPH_ddlBranch_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddlmode_chzn {
            width: 100% !important;
        }

        .chzn-drop {
            width: 129px !important;
            height: 250px !important;
            overflow: auto !important;
        }

.CorporateVouDrop {
    float: right;
    margin: 0 1% 0 0;
    width: 39.5%;
}

       div#UpdatePanel1 {
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}

        .row {
            height: 574px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
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

            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .CorporateLeft {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CorporateRight {
            width: 66%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .fileUpload5 {
    width: 17%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .btn.btn-add1 {
            float: right;
        }
        .btn.ico-add-icon-blue {
    float: right;
}
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 45px !important;
}
        table#logix_CPH_Grid_Account tbody th:nth-child(3),table#logix_CPH_Grid_Account tbody th:nth-child(4) {
    text-align: right !important;
}
        .gridpanel{
            width:66%;
            float:left;
        }
.DateCal4 {
    width: 8%;
    float: right;
    margin: 0px 0px 0px 0px;
}
        table#logix_CPH_Grid_Account tbody td:nth-child(4) {
    width: 12% !important;
}
          .CorporateAmount1 span {
    text-align: right !important;
     
}
    .CorTDS span {
    text-align: right !important;
   

}
    .CorExcess span {
    text-align: right !important;
   

}
     .CorporateAmount.TextField span {
    text-align: right !important;
   

}
          .CorporateRate span {
    text-align: right !important;
 

}
           .CorporateAmountRs span {
    text-align: right !important;
    

}
           .gridpanel {
    width: 100%;
    float: left;
}
.TextField .inputcolor, .TextField .inputcolor:focus {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
input#logix_CPH_txtsch {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
       .TextField .chzn-container-single .chzn-single {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            font-weight: normal !important;
        }
 /*      table#logix_CPH_Grid_detail td {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
       table#logix_CPH_Grid_detail th {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}*/
       table#logix_CPH_Grid_Account th {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
       table#logix_CPH_Grid_Account td {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
       input#logix_CPH_txt_total1 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
       input#logix_CPH_txt_total {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;
}
       .btn.ico-add {
    float: right;
}
       table#logix_CPH_Grid_detail th:nth-child(4) {
    text-align: right;
}
       table#logix_CPH_Grid_detail th:nth-child(5) {
    text-align: right;
}
       table#logix_CPH_Grid_detail th:nth-child(6) {
    text-align: right;
}
       table#logix_CPH_Grid_detail th:nth-child(7) {
    text-align: right;
}
       table#logix_CPH_Grid_detail th:nth-child(8) {
    text-align: right;
}
     table#logix_CPH_Grid_detail th:nth-child(9) {
    text-align: right;
}
    </style>

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_recieve.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/Remittance_Receipt.aspx/GetCustomer",
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
                        <%--   $("#<%=txt_cust.ClientID %>").val(i.item.label);--%>
                        $("#<%=txt_recieve.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_recieve.ClientID %>").val(i.item.address);
                        $("#<%=hid_favour.ClientID %>").val(i.item.val);
                        $("#<%=txt_recieve.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_recieve.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_recieve.ClientID %>").val(i.item.address);
                        $("#<%=hid_favour.ClientID %>").val(i.item.val);
                        $("#<%=txt_recieve.ClientID %>").val($.trim(result));

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_recieve.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_recieve.ClientID %>").val(i.item.address);
                            $("#<%=hid_favour.ClientID %>").val(i.item.val);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_recieve.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_recieve.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            <%--$(document).ready(function () {
                $("#<%=txt_cheque.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Remittance_Receipt.aspx/GetCheque",
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
                        $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                    $("#<%=txt_cheque.ClientID %>").change();
                    $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                },
                    focus: function (event, i) {
                        $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                    $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                },
                    close: function (event, i) {
                        $("#<%=txt_cheque.ClientID %>").val(i.item.label);
                    $("#<%=hid_cheque.ClientID %>").val(i.item.val);
                },
                    minLength: 1
                });
            });--%>

            $(document).ready(function () {
                $("#<%=txt_bank.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/Remittance_Receipt.aspx/GetBank",
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
                        $("#<%=txt_bank.ClientID %>").val(i.item.label);
                        $("#<%=txt_bank.ClientID %>").change();
                        $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_bank.ClientID %>").val(i.item.label);
                        $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_bank.ClientID %>").val(i.item.label);
                        $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_deduction.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/Remittance_Receipt.aspx/GetDeduction",
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
                        $("#<%=txt_deduction.ClientID %>").val(i.item.label);
                        $("#<%=txt_deduction.ClientID %>").change();
                        $("#<%=hid_deduction.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_deduction.ClientID %>").val(i.item.label);
                        $("#<%=hid_deduction.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_deduction.ClientID %>").val(i.item.label);
                        $("#<%=hid_deduction.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_curr.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/Remittance_Receipt.aspx/GetCurrency",
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
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);
                        $("#<%=txt_curr.ClientID %>").change();

                    },
                    focus: function (event, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);

                    },
                    close: function (event, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.label);

                    },
                    minLength: 1
                });
            });

                $(document).ready(function () {
                    $("#<%=txt_cust.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "../FAForms/Remittance_Receipt.aspx/Getledger",
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
                        <%--   $("#<%=txt_cust.ClientID %>").val(i.item.label);--%>
                            $("#<%=txt_cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_cust.ClientID %>").val(i.item.address);
                            $("#<%=hid_favour.ClientID %>").val(i.item.val);
                            $("#<%=txt_cust.ClientID %>").change();
                        },
                        focus: function (event, i) {
                            $("#<%=txt_cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_cust.ClientID %>").val(i.item.address);
                            $("#<%=hid_favour.ClientID %>").val(i.item.val);
                            $("#<%=txt_cust.ClientID %>").val($.trim(result));

                        },
                        change: function (event, i) {
                            if (i.item) {
                                $("#<%=txt_cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=txt_cust.ClientID %>").val(i.item.address);
                                $("#<%=hid_favour.ClientID %>").val(i.item.val);

                            }
                        },

                        close: function (event, i) {
                            var result = $("#<%=txt_cust.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txt_cust.ClientID %>").val($.trim(result));
                        },
                        minLength: 1

                    });
                });

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            }

            function getConfirmationValue() {

                if (confirm(' Are you sure you want to delete the details?')) {
                    $('#<%=hfWasConfirmed.ClientID%>').val('true')
                }
                else {
                    $('#<%=hfWasConfirmed.ClientID%>').val('false')
                }

                return true;

            }

            function HideShow() {

                $("#Grid_detail").find("input:text").each(function () {

                    if (this.value == 0.00) {

                        var chkId;

                        chkId = $(this).attr("id");

                        var tblId;
                        alertify.alert(chkId);

                        $(this).val('');
                    }
                });
            }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home">l</i><a href="#">Home</a> </li>
                            <li><a href="#">Vouchers</a> </li>
                            <li>
                                <asp:Label ID="lbl_headr" runat="server"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons">
         <div class="right_btn" >
            <div class="btn ico-save" id="btn_save1" runat="server" >
                <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" TabIndex="25" />
            </div>
            <div class="btn ico-view">
                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" TabIndex="26" />
            </div>
            <div class="btn ico-cancel" id="btn_back1" runat="server">
                <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" TabIndex="28" />
            </div>
            <div class="btn ico-payment-cancel" id="btn_back2" runat="server">
                <asp:Button ID="btnpaymentcancel" runat="server"  Text="Payment Cancel" ToolTip="Payment Cancel" OnClick="btnpaymentcancel_Click" TabIndex="29" />
            </div>

        </div>
</div>
                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4"  style="margin-top: 31px !important;width: 100%;" >
                        <div class="CorporateDrop" style="display:none;">
                            <asp:DropDownList ID="ddl_branch" runat="server" Visible="false" Width="100%" CssClass="chzn-select" Enabled="false" ToolTip="BRANCH" TabIndex="1"></asp:DropDownList>
                        </div>
                        <div class="CorporateChk">
                            <asp:DropDownList ID="ddl_mode" Height="23px" CssClass="chzn-select" runat="server" Width="100%" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_mode_SelectedIndexChanged" OnTextChanged="ddl_mode_TextChanged" ToolTip="Mode" TabIndex="2" Enabled="false" Visible="false">
                            </asp:DropDownList>
                        </div>

                        <%--<div class="CorporateCal DateR">
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" ToolTip="Receipt Date" placeholder="Receipt Date" Enabled="false" TabIndex="5"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                Format="dd/MM/yyyy" TargetControlID="txt_date" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>--%>

                         <div class="DateCal4 DateR">
               
                  <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" placeholder="Date" ToolTip="RECEIPT DATE" AutoPostBack="true"  OnTextChanged="txt_date_TextChanged" TabIndex="5"> </asp:TextBox> <%----%>
                   <asp:CalendarExtender ID="txt_date_calender" runat="server"  TargetControlID="txt_date" Enabled="true" Format="dd/MM/yyyy" />  <%--ondayrender="calder_render"--%>
            </div>

                        <div class="CorporateReceipt">
                            <asp:TextBox ID="txt_recp" runat="server" CssClass="form-control" OnTextChanged="txt_recp_TextChanged" placeholder="Receipt #" ToolTip="Receipt #" AutoPostBack="True" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="CorporateYear">
                            <asp:TextBox ID="txt_recpdate" runat="server" CssClass="form-control" placeholder="Year" ToolTip="Receipt Year" TabIndex="4"></asp:TextBox>
                        </div>

                        <div class="CorporateLBL" style="display:none;">
                            <asp:Label ID="lbl_title" runat="server" CssClass="LabelValue"></asp:Label>
                        </div>
                        <div class="lbl_date" style="display: none;">
                            <asp:Label ID="lbl_date" runat="server" Text="Date" CssClass="LabelValue"></asp:Label>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                    <div class="CorporateLeft">
                    

                        <div class="FormGroupContent4">
                            <div class="CorporatePay">
                                <asp:TextBox ID="txt_recieve" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="Received From" placeholder="Received From" OnTextChanged="txt_recieve_TextChanged" TabIndex="6"></asp:TextBox>
                            </div>
                            <div class="CorporateUSD">
                                <asp:TextBox ID="txt_curr" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Curr" ToolTip="Currency" OnTextChanged="txt_curr_TextChanged" TabIndex="7"></asp:TextBox>
                            </div>
                            <div class="CorporateAmount">
                                <asp:TextBox ID="txt_rcvamt" runat="server" CssClass="form-control" placeholder="Amount" ToolTip="FCurrency Amount" AutoPostBack="true" OnTextChanged="txt_rcvamt_TextChanged" TabIndex="8"></asp:TextBox>
                            </div>
                            <div class="CorporateRate">
                                <asp:TextBox ID="txt_exrate" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="ExRate" ToolTip="ExRate" OnTextChanged="txt_exrate_TextChanged" TabIndex="9"></asp:TextBox>
                            </div>
                            <div class="CorporateAmountRs">
                                <asp:TextBox ID="txt_amtrs" runat="server" CssClass="form-control" placeholder="Amount Loc. Cur" ToolTip="Amount Loc. Cur" TabIndex="10"></asp:TextBox>
                            </div>
                        </div>

                        <div class="FormGroupContent4">
                            <div class="CorporateChkDD">
                                <asp:TextBox ID="txt_cheque" runat="server" CssClass="form-control" placeholder="Ref #" ToolTip="Chque/DD Number" TabIndex="11"></asp:TextBox>
                            </div>
                            <div class="CorporateDate">
                                <asp:TextBox ID="txt_cheqdate" runat="server" CssClass="form-control" ToolTip="Date" placeholder="TT Ref Date" TabIndex="14" OnTextChanged="txt_cheqdate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
                                    Format="dd/MM/yyyy" TargetControlID="txt_cheqdate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>

                            <div class="CorporateBank">
                                <asp:TextBox ID="txt_bank" runat="server" CssClass="form-control" placeholder="Bank" ToolTip="Bank" TabIndex="12" OnTextChanged="txt_bank_TextChanged"></asp:TextBox>
                            </div>
                            <div class="CorporateBranch">
                                <asp:TextBox ID="txt_branch1" runat="server" CssClass="form-control" placeholder="Branch" ToolTip="Branch" TabIndex="13"></asp:TextBox>
                            </div>
                            <div class="CorporateNar">
                                <asp:TextBox ID="txt_narration" runat="server" CssClass="form-control" placeholder="Narration" ToolTip="Narration" TabIndex="15"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 hide">
                            <div class="AmountLBL">
                                <asp:Label ID="lbl_cust" runat="server" Text="Amount"></asp:Label>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="CorporateCustmer">
                                <asp:TextBox ID="txt_cust" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_cust_TextChanged" placeholder="Customer" ToolTip="Customer" TabIndex="16"></asp:TextBox>
                            </div>

                            <div class="btn ico-add custom-mt-2">
                                <asp:Button ID="btn_cust_add" runat="server" Text="Add" CssClass="Button" OnClick="btn_cust_add_Click" />
                            </div>
                            <div class="CorporateAmount1">
                                <asp:TextBox ID="txt_cust_amt" runat="server" CssClass="form-control" Style="text-align: right" placeholder="Amount" ToolTip="Amount" TabIndex="17" AutoPostBack="true" OnTextChanged="txt_cust_amt_TextChanged"></asp:TextBox>
                            </div>
                            
                        <div class="FormGroupContent4" style="-webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;font-weight: normal !important;border-radius: 15px 15px 0px 0px;margin-top: 5px !important;width: 33%;float: right;">
                            <div class="CorporateVoucher hide">
                                <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Details"></asp:Label>
                            </div>

                            <div class="CorporateVouInputN1">
                                <asp:TextBox ID="txtsch" runat="server" placeHolder="Voucher #" AutoPostBack="true" ToolTip="Vouchar" CssClass="form-control" TabIndex="29" OnTextChanged="txtsch_TextChanged"></asp:TextBox>
                            </div>
                            <div class="CorporateVouDrop">
                                <asp:DropDownList ID="cmbvoutype" runat="server" ToolTip="Type" Height="24" CssClass="chzn-select" TabIndex="30" AutoPostBack="true" OnSelectedIndexChanged="cmbvoutype_SelectedIndexChanged">
                                    <%--placeholder="Type"  Height="23px"  CssClass ="chzn-select"   --%>
                                    <asp:ListItem>Vou Type</asp:ListItem>
                                    <%--  <asp:ListItem>CN</asp:ListItem>--%>
                                    <asp:ListItem>CN</asp:ListItem>
                                    <asp:ListItem>DN</asp:ListItem>
                                    <asp:ListItem>OSCN</asp:ListItem>
                                    <asp:ListItem>OSDN</asp:ListItem>

                                </asp:DropDownList>
                            </div>

                            <div class="CorporateVouInput">
                                <span>Receipt Amount </span>
                                <asp:CheckBox ID="chkrpt" runat="server" AutoPostBack="true" OnCheckedChanged="chkrpt_CheckedChanged" />
                            </div>

                        </div>
                                </div>

                        <div class="FormGroupContent4">
                            <asp:Panel ID="panel_details" runat="server" CssClass="gridpnl">
                                <asp:GridView ID="Grid_detail" runat="server" AutoGenerateColumns="False" Width="100%" AutoPostBack="true"
                                    ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" DataKeyNames="tamount" OnRowDataBound="Grid_detail_RowDataBound" OnRowCommand="Grid_detail_RowCommand" OnPreRender="Grid_detail_PreRender">

                                    <Columns>
                                        <asp:BoundField DataField="branchid" HeaderText="Branch"><%-- 0 --%>
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="branch" HeaderText="Branch"><%-- 1 --%>
                                            <HeaderStyle Wrap="false" Width="250px" />
                                            <ItemStyle Wrap="false" Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="invoiceno" HeaderText="Vou #"><%-- 2 --%>
                                            <HeaderStyle Wrap="false" Width="250px" />
<ItemStyle Wrap="false" Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="curr" HeaderText="Curr"><%-- 3 --%>
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fcamt" HeaderText="FCAmt" DataFormatString="{0:#,##0.00}"><%-- 4 --%>
                                            <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exrate" HeaderText="ExRate"><%-- 5 --%>
                                            <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="vamount" HeaderText="VouAmt(Rs)"><%-- 6 --%>
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" CssClass="TxtAlign1" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText=""><%-- 7 --%>
                                            <ItemTemplate>

                                                <asp:TextBox ID="txt_receiptamount" runat="server" BorderColor="White" Text='<%#Bind("recptfcamt") %>' Font-Size="10pt" AutoPostBack="true"
                                                    TabIndex="0" Style="text-align: right;" CssClass="form-control" OnTextChanged="txt_receiptamount_TextChanged"></asp:TextBox>

                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="tamount" HeaderText=""><%-- 8 --%>
                                            <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="voutype" HeaderText="VoyType"><%-- 9 --%>
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vouno" HeaderText="vouno"><%-- 10 --%>
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="tds" HeaderText="tdsamt"><%-- 11 --%>
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ravouyear" HeaderText="VouYear"><%-- 12 --%>
                                            <%--<HeaderStyle CssClass="Hide" />
                          <ItemStyle CssClass="Hide" Wrap="false"  />--%>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ltype" HeaderText="ledtype"><%-- 13 --%>
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="customerid" HeaderText="Customer Id" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%-- 14 --%>
                                            <%--<HeaderStyle CssClass="Hide" />
                          <ItemStyle CssClass="Hide" Wrap="false"  />--%>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #"><%-- 15 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Wrap="false" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="vendorrefdate" HeaderText="Vendor Ref Date"><%-- 16 --%>
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="10pt"><%-- 17 --%>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chkrecpfc" runat="server" AutoPostBack="true" OnCheckedChanged="Chkrecpfc_CheckedChanged" />
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle CssClass="GrdRow" />

                                </asp:GridView>
                            </asp:Panel>

                        </div>
                        <div class="FormGroupContent4" style=" -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
 font-weight: normal !important;border-radius: 0px 0px 15px 15px;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <Triggers>

                                    <asp:PostBackTrigger ControlID="btn_upload1" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="fileUpload5">
                                        <asp:FileUpload ID="fileexcel" runat="server" Width="13" />
                                    </div>
                                    <div class="btn ico-upload custom-mt-2">
                                        <asp:Button ID="btn_upload1" runat="server"  Text="Upload" TabIndex="32" ToolTip="Upload" OnClick="btn_upload1_Click" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="right_btn custom-mt-2">
                                <div class="btn ico-excel">
                                    <asp:Button ID="btnexcel" runat="server" Text="Export Excel" ToolTip="Export Excel" OnClick="btnexcel_Click" />
                                </div>
                            </div>
                        </div>
                        
                        </div>
                        <div class="FormGroupContent4">
                            <div class="CorporDeduction">
                                <asp:TextBox ID="txt_deduction" runat="server" CssClass="form-control" placeholder="Deduction" ToolTip="Deduction" TabIndex="18" OnTextChanged="txt_deduction_TextChanged"></asp:TextBox>
                            </div>
                            <div class="CorporDeau">
                                <asp:TextBox ID="txt_dedu_amt" runat="server" CssClass="form-control" Style="text-align: right" placeholder="Amount" ToolTip="Amount" AutoPostBack="true" OnTextChanged="txt_dedu_amt_TextChanged" TabIndex="19"></asp:TextBox>
                            </div>
                            <div class="btn ico-add custom-mt-2">
                                <asp:Button ID="btn_deduct_add" runat="server" Text="Add" CssClass="Button" OnClick="btn_deduct_add_Click" TabIndex="21" />
                            </div>
                            <div class="CorTDS">
                                <asp:TextBox ID="txttdsAmt" runat="server" CssClass="form-control" Style="text-align: right" placeholder="TDS Amount" AutoPostBack="true" ToolTip="TDS Amount " OnTextChanged="txttdsAmt_TextChanged" TabIndex="20"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="CorAccount" style="display:none;">

                                <span>Account Pay </span>
                                <asp:CheckBox ID="Chk_accountpay" runat="server" AutoPostBack="true" TabIndex="22" />

                            </div>
                            <div class="btn ico-add custom-mt-2" style="float: right">
                                <asp:Button ID="btn_short_add" runat="server" Text="Add" CssClass="Button" OnClick="btn_short_add_Click" TabIndex="24" />
                            </div>
                            <div class="CorExcess">

                                <asp:TextBox ID="txt_excess_amt" placeholder="Excess / Short" ToolTip="Excess(+)/Short(-)" runat="server" CssClass="form-control" Width="100%" Style="text-align: right" TabIndex="23"></asp:TextBox>
                            </div>

                        </div>
                       
                  

                    </div>
                        </div>
                    <div class="FormGroupContent4" >
                    <div class="CorporateRight">
                        <div class="FormGroupContent4 hide">
                            <div class="left_btn MT0 MB05" style="margin-left: 38%;" >

                                <div class="CorPorateTotal">
                                    <asp:TextBox ID="txt_fvr" runat="server" CssClass="form-control" Visible="false" TabIndex="33"></asp:TextBox>
                                    <asp:Label ID="lbl_amountinword" runat="server" ForeColor="Black" Visible="false"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>

                    </div>
                <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">
                    <div class="gridpanel">

                              <div class="FormGroupContent4">
                            <div class="gridpnl" style="border-radius:15px 15px 15px 15px;">
                                <asp:Panel ID="panel_acc" runat="server">

                                    <asp:GridView ID="Grid_Account" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grid_Account_RowDataBound"
                                        OnSelectedIndexChanged="Grid_Account_SelectedIndexChanged" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" OnRowDeleting="Grid_Account_RowDeleting" OnRowCommand="Grid_Account_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="Type" HeaderText="Type">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Customerortax" HeaderText="Customer / Tax Charges">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Width="220px" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fc" HeaderText="FC Amt" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1">
                                                <HeaderStyle Wrap="false" Width="527px" />
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1">
                                                <HeaderStyle Wrap="false" Width="150px" />
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="cid" HeaderText="Custid">
                                                <HeaderStyle CssClass="Hide" />
                                                <ItemStyle CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete"
                                                        ImageUrl="~/images/delete.jpg" Height="16px" OnClientClick="getConfirmationValue()" OnClick="imgdelete_Click" />
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Width="40px" />
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgdelete" runat="server"  
                        ImageUrl="~/images/delete.jpg" OnClick="imgdelete_Click" Height="16px" OnClientClick="getConfirmationValue()" />

                    </ItemTemplate>
                    <ItemStyle Width="15%" HorizontalAlign="Center"/>
                </asp:TemplateField>--%>
                                        </Columns>

                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle CssClass="GrdRow" />

                                    </asp:GridView>

                                </asp:Panel>
                                  <div class="FormGroupContent4" style="-webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;font-weight: normal !important;">
                            <div class="right_btn MT0" >
                                <div class="CorPorateTotal">
                                    <asp:TextBox ID="txt_total1" runat="server" Style="text-align: right" CssClass="form-control" placeholder="TOTAL(RS)" ToolTip="TOTAL(RS)" TabIndex="32"></asp:TextBox>
                                </div>

                                <div class="CorporateTotalRs">
                                    <asp:TextBox ID="txt_total" runat="server" Style="text-align: right" CssClass="form-control" placeholder="TOTAL$" ToolTip="TOTAL$" TabIndex="31"></asp:TextBox>
                                </div>

                                <div class="CorPorateRefNo">
                                    <asp:TextBox ID="txt_refno" runat="server" Visible="false" CssClass="form-control" placeholder="Ref.No" ToolTip="Ref.No" TabIndex="34"></asp:TextBox>
                                </div>

                            </div>
                                      </div>
                                  </div>
                        </div>
                    </div>
                        </div>
                </div>
            </div>

        <div class="Clear"></div>

        <%------------------------------------ModelPOpup----------------------------------------%>

        <cc1:ModalPopupExtender ID="programmaticModalPopup" runat="server" BehaviorID="programmaticModalPopupBehaviordf1" TargetControlID="cancel_btn"
            CancelControlID="cancel_btn" PopupControlID="POPUP1" OkControlID="imgok" DropShadow="false">
        </cc1:ModalPopupExtender>

        <asp:Panel ID="POPUP1" runat="server" CssClass="modalPopup" Style="display: none;">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl" Visible="true">

                    <asp:GridView ID="Grid_Cheque" CssClass="Grid FixedHeader" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="Grid_Cheque_RowDataBound"
                        AllowPaging="false" OnPageIndexChanging="Grid_Cheque_PageIndexChanging" PageSize="26" OnSelectedIndexChanged="Grid_Cheque_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="grdChequeno" HeaderText="Cheque No" />
                            <asp:BoundField DataField="grdCustomer" HeaderText="Customer" />
                            <asp:BoundField DataField="grdBankName" HeaderText="Bank" />
                            <asp:BoundField DataField="grdAmount" HeaderText="Amount" ItemStyle-Width="150px" HeaderStyle-Width="150px" />
                            <asp:BoundField DataField="nono" HeaderText="nono">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="customerid" HeaderText="custid">
                                <%-- <HeaderStyle CssClass="Hide" />
                    <ItemStyle CssClass="Hide" />--%>
                            </asp:BoundField>
                            <asp:ButtonField CommandName="Select" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <RowStyle CssClass="GrdRow" />
                        <PagerStyle CssClass="GridviewScrollPager" />
                    </asp:GridView>

                </asp:Panel>
            </div>
            <div class="div_break"></div>
            <div class="div_Button1">
                <asp:Button ID="cancel_btn" runat="server" Text="Cancel" Style="display: none;" />
                <div class="div_break"></div>
            </div>
        </asp:Panel>

        <asp:Label ID="lbltag" runat="server"> </asp:Label>

        <cc1:ModalPopupExtender ID="ModalPopup_amount" runat="server" BehaviorID="programmaticModalPopupBehaviordf2" TargetControlID="lbltag"
            CancelControlID="img_close" PopupControlID="Panel2" OkControlID="img_close" DropShadow="false">
        </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" Style="display: none;">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="img_close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl" Visible="true">

                    <asp:GridView ID="Grid_Amount" runat="server" Width="100%" AutoGenerateColumns="False"
                        OnRowDataBound="Grid_Amount_RowDataBound" AllowPaging="false" PageSize="26"
                        OnSelectedIndexChanged="Grid_Amount_SelectedIndexChanged" OnPageIndexChanging="Grid_Amount_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="branchid" HeaderText="Branch">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="portname" HeaderText="Branch">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="voutype" HeaderText="VouType" />
                            <asp:BoundField DataField="vouno" HeaderText="Vou#" />
                            <asp:BoundField DataField="date" HeaderText="Vou.Date" />
                            <asp:BoundField DataField="customername" HeaderText="Customer" />
                            <asp:BoundField DataField="fvr" HeaderText="Favouring" />
                            <asp:BoundField DataField="cstamount" HeaderText="VouAmt" />
                            <asp:BoundField DataField="rptamt" HeaderText="Recpt-Amt">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>

                            <asp:BoundField DataField="vno" HeaderText="vouno">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tdsamount" HeaderText="TDSAmt" />
                            <asp:BoundField DataField="vouyear" HeaderText="RAVouYear">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="customerid" HeaderText="Customerid">
                                <%--<HeaderStyle CssClass="Hide" />
                    <ItemStyle CssClass="Hide" />--%>
                            </asp:BoundField>
                            <asp:BoundField DataField="vtype" HeaderText="Vtype">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mode" HeaderText="Mode"></asp:BoundField>
                            <asp:BoundField DataField="remarks" HeaderText="remarks">
                                <HeaderStyle CssClass="Hide" />
                                <ItemStyle CssClass="Hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk_select" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <RowStyle CssClass="GrdRow" />
                        <PagerStyle CssClass="GridviewScrollPager" />
                    </asp:GridView>

                </asp:Panel>

                <div class="div_Break"></div>
                <div class="btn_ok">
                    <asp:Button ID="btn_ok" runat="server" Text="Ok" Width="100%"
                        CssClass="Button" OnClick="btn_ok_Click" />
                </div>
            </div>
            <div class="div_break"></div>
            <div class="div_Button1">

                <div class="div_break"></div>
            </div>
        </asp:Panel>

        <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
            <br />
            <div style="font-size: 10pt"><b>Do You Want to Select Account Payee?</b></div>
            <br />
            <div class="div_confirm">
                <asp:Button ID="btn_Alert_Yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_Alert_Yes_Click" />
                <asp:Button ID="btn_Alert_No" runat="server" Text="No" CssClass="Button" OnClick="btn_Alert_No_Click" />
            </div>
            <br />
            <div class="div_Break"></div>
        </asp:Panel>
        <div class="div_Break"></div>
        <div class="div_Break"></div>
        <cc1:ModalPopupExtender ID="PopUpService" runat="server"
            PopupControlID="Panel_Service" TargetControlID="Label1">
        </cc1:ModalPopupExtender>
        <asp:Label ID="Label1" runat="server"></asp:Label>

        <asp:Panel runat="Server" ID="Panel_ref" CssClass="Pnl1" Style="display: none;">
            <br />
            <div style="font-size: 10pt"><b>Please Confirm Cash Referance No..!</b></div>
            <br />
            <div class="div_confirm">
                <asp:Button ID="btn_ref_yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_ref_yes_Click" />
                <asp:Button ID="btn_ref_no" runat="server" Text="No" CssClass="Button" OnClick="btn_ref_no_Click" />
            </div>
            <br />
            <div class="div_Break"></div>
        </asp:Panel>
        <div class="div_Break"></div>
        <div class="div_Break"></div>
        <cc1:ModalPopupExtender ID="popup_ref" runat="server"
            PopupControlID="Panel_ref" TargetControlID="Label2">
        </cc1:ModalPopupExtender>
        <asp:Label ID="Label2" runat="server"></asp:Label>

        <asp:HiddenField ID="hid_deduction" runat="server" />
        <asp:HiddenField ID="hid_custid" runat="server" />
        <asp:HiddenField ID="hid_type" runat="server" />
        <asp:HiddenField ID="hid_date" runat="server" />
        <asp:HiddenField ID="hid_customerid" runat="server" />
        <asp:HiddenField ID="hid_favour" runat="server" />
        <asp:HiddenField ID="hid_cid" runat="server" />
        <asp:HiddenField ID="hid_chargeid" runat="server" />
        <asp:HiddenField ID="hid_bankid" runat="server" />
        <asp:HiddenField ID="hid_acpay" runat="server" />
        <asp:HiddenField ID="hid_cheque" runat="server" />
        <asp:HiddenField ID="hid_receiptid" runat="server" />
        <asp:HiddenField ID="hfWasConfirmed" runat="server" />
        <asp:HiddenField ID="hid_total" runat="server" />
        <asp:HiddenField ID="hid" runat="server" />
        <asp:HiddenField ID="hid_bank" runat="server" />
        <asp:HiddenField ID="hid_year" runat="server" />
        <asp:HiddenField ID="hid_rid" runat="server" />
        <asp:HiddenField ID="hid_cust" runat="server" />
        <asp:HiddenField ID="hid_ledger" runat="server" />
        <asp:HiddenField ID="hid_grid" runat="server" />
        <asp:HiddenField ID="hid_gridname" runat="server" />
        <asp:HiddenField ID="hid_glaft" runat="server" />
        <asp:HiddenField ID="hid_tot" runat="server" />
        <asp:HiddenField ID="hid_tot1" runat="server" />
        <asp:HiddenField ID="hid_tot2" runat="server" />
        <asp:HiddenField ID="hid_customeridNew" runat="server" />
        <asp:HiddenField ID="NewPaymentRpt" runat="server" Value="Y" />
        <asp:HiddenField ID="NewReceiptRpt" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_recpayid" runat="server" />
        <asp:HiddenField ID="hid_invoiceno" runat="server" />
        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="Label3" runat="server"></label>

                    </div>
                    <div class="LogHeadJobInput">

                        <asp:Label ID="JobInput" runat="server"></asp:Label>

                    </div>

                </div>
                <div class="DivSecPanel">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="16px" Height="16px" />
                </div>

                <asp:Panel ID="Panel4" runat="server" CssClass="Gridpnl">

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
            DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
        </asp:ModalPopupExtender>
</asp:Content>
