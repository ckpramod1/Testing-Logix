<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="PaymentFA_Receipt.aspx.cs"
    Inherits="logix.FAForm.PaymentFA_Receipt" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <link href="../CSS/Finance.css" rel="stylesheet" />

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/PaymentFA.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

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

        .wrap_150 {
            text-overflow: ellipsis;
            overflow: hidden;
            white-space: nowrap;
            width: 150px !important;
            display: inline-block;
            border-top: 0px solid #b1b1b1;
            border-right: 0px solid #b1b1b1;
            border-left: 0px solid #b1b1b1;
            border-bottom: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
        }

        .div_grid {
            float: left;
            /* height: 100%; */
            width: 100%;
            margin-left: 0%;
            border: 1px solid #b1b1b1;
            height: 174px;
            margin-bottom: 0.5%;
            overflow: auto;
            /* background-color: lightcyan; */
        }

        .fileUpload5 {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Customer2 {
            width: 73%;
            float: left;
            margin: 0px 1% 0px 0px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .Narration {
            width: 100%;
            float: left;
        }

        .btn.btn-add1 {
            float: right;
        }

        div#logix_CPH_panel3 {
            height: 87% !important;
        }

        .DepositBank {
           float: left;
    width: 34.5%;
        }

        .PaymentLeft {
            width: 50.5%;
            float: left;
            margin: 10px 0.5% 0px 0px;
        }

        .PaymentRight {
             width: 49%;
    float: left;
    border-left: 0px solid #e0e0e0;
    padding-left: 1px;
        margin-top: 4px !important;
        }

        .BankText {
            float: left;
            margin: 0 0.5% 0 0;
            width: 37%;
        }

        .panel_09.MB0 {
            margin: 10px 0 0 !important;
        }

        input#logix_CPH_fileupload1 {
            height: 32px;
            padding: 7px;
            background-color: #fff;
            border: 0px solid var(--inputborder) !important;
        }

        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .excess_amt {
            float: right !important;
            margin: 0 9px 0 0 !important;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .Break {
            clear: both;
        }

        .Hide {
            display: none;
        }

        .div_confirm {
            width: 100%;
            float: left;
            margin-left: 30%;
            margin-top: 0%;
        }

        .Pnl1 {
            background-color: #E0E0E0;
            border-color: #5D7B9D;
            border-style: solid;
            border-width: 1px;
            width: 250px;
            height: 100px;
            margin-right: 1%;
        }

        .divcenter {
            width: 100%;
            margin-bottom: 1%;
            font-family: Tahoma;
            font-size: 8pt;
            color: black;
        }

        .bordertopNew {
            border-top: 1px dotted #b1b1b1;
            margin: 5px 0px 0px 0px;
            width: 100%;
        }

        .lblbranch {
            margin-left: 1%;
            margin-top: 1.5%;
            width: 5%;
            float: left;
        }

        .txtbranch {
            margin-left: 1%;
            margin-top: 0.5%;
            width: 8%;
            float: left;
        }

            .txtbranch input, select {
                width: 100%;
            }

        .ChequeDD {
            width: 22%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .txtbranch2 {
            margin-top: 1%;
            width: 10%;
            float: right;
            margin-right: 0.5%;
        }

            .txtbranch2 input {
                width: 100%;
            }

        .txtrecdate {
            margin-top: 1%;
            float: right;
            width: 6%;
        }

            .txtrecdate input {
                width: 100%;
            }

        .txtdate {
            margin-right: 0.5%;
            margin-top: 1%;
            float: right;
            width: 10%;
        }

            .txtdate input {
                width: 100%;
            }

        .TextBox {
            font-family: Tahoma;
            font-size: 10pt;
            font-style: normal;
            border-color: #999997;
            border: 1px solid #999997;
            text-transform: uppercase;
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

        .visaka {
            width: 9.5%;
            float: left;
            margin: 5px 0% 0px 0px;
        }

            .visaka input {
                float: left;
                margin: 0px 0.5% 0px 0px;
            }

            .visaka label {
                margin: -5px 0px 0px 5px !important;
                display: inline-block !important;
            }

        .visaka1 {
            width: 8%;
            float: left;
            margin: 5px 0% 0px 0px;
        }

            .visaka1 input {
                float: left;
                margin: 0px 0.5% 0px 0px;
            }

            .visaka1 label {
                margin: -5px 0px 0px 5px !important;
                display: inline-block !important;
            }

       

        .PaymentInput {
            float: right;
            width: 8%;
            margin: 0px .5% 0px 0%;
        }

        span#logix_CPH_lbl_voucher {
            position: relative;
            top: 0px !important;
        }

        span.bluetext {
               font-size: 14px !important;
    font-weight: 500 !important;
        }

        .input_Grid {
            background-color: transparent;
            border: 0px solid;
            height: 20px;
            width: 160px;
        }

        .CorporateVouInput2 label {
            font-weight: normal !important;
        }

        .Pnl1 {
            padding: 10px;
            text-align: center;
        }

        .DateCal4 {
            width: 8%;
            float:right;
            margin: 0px 0% 0px 0px;
        }

        .BranchDD {
            width: 24.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .BranchCal {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BankDD {
            width: 34%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PaymentTo {
            width: 21.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

       .Amount12 {
    width: 14%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .PaymentNarration {
            width: 14%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        

        .Amount13 {
            width: 18.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .btn.btn-add-icon-blue {
            float: right !important;
        }

        .BankDeposit {
            width: 75%;
            float: left;
            margin: 0px 1% 0px 0px;
        }

        .LabelValue {
            color: #b1b1b1 !important;
            font-family: Tahoma;
            font-size: 12px;
            font-weight: normal;
            margin: 0 0 0 10px;
            text-align: right;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            /* width: 1062px; */
            width: 100%;
            Height: 515px;
            margin-left: 0%;
            margin-top: 3.1%;
        }

        .DivSecPanel img {
            float: right;
            width: 16px !important;
            height: 16px !important;
            margin-top: 5px;
        }

        .MR5 {
            margin-right: 17px !important;
            margin-top: -30px;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;*/
            width: 1062px;
            width: 98.4%;
            height: 536px;
            margin-left: 0%;
            margin-top: 3.1%;
        }

        #logix_CPH_POPUP1 {
            left: 10px !important;
            top: -13px !important;
        }

        .Grid_Account {
            width: 100%;
            float: left;
            margin-left: 0%;
            height: 98px;
            border: 1px solid #b1b1b1;
            /*background-color: lightcyan;*/
        }

        .CorporateVouInput {
            float: right;
            margin: 0px 0% 0px 0px;
            width: 16.3%;
        }

       .CorporateVouInput2 {
    float: right;
    margin: 15px 0.5% 0px 30px;
    width: 18%;
}

            .CorporateVouInput2 input {
                float: left;
                vertical-align: bottom;
            }

            .CorporateVouInput2 label {
                display: inline-block;
                margin: 0px 0px 0px 5px !important;
            }

span#logix_CPH_lbl_voucher {
    margin: 23px 0px 10px 0px !important;
    display: inline-block;
}

        .CorporateVouInput input {
            float: left;
            vertical-align: bottom;
        }

        .CorporateVouInput label {
            display: inline-block;
            margin: -2px 0px 0px 5px !important;
        }

        .CorporateVoucher {
            width: 14%;
            float: left;
            margin: 23px 0.5% 0px 3px;
        }

        .LabelValue {
            margin: 0px 0px 0px 2px !important;
        }

        .TotalTxt2 {
            width: 14%;
            margin: 0px 0px 0px 0px;
            float: left;
        }

        .div_grid {
            float: left;
            /* height: 100%; */
            width: 100%;
            margin-left: 0%;
            border: 1px solid #b1b1b1;
            height: 150px;
            margin-bottom: 0.5%;
            overflow: auto;
            /* background-color: lightcyan; */
        }

        .BranchDropN1 {
            width: 8.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BranchDropN2 {
            width: 11.5%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddl_mode_chzn {
            width: 100% !important;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 12px;
        }

        a {
            font-size: 12px;
        }

  

        span#logix_CPH_lbl_title {
            color: #000 !important;
        }

        .Addbtn {
            width: 4.5%;
            float: right;
            margin: 26px 0% 0px 0px;
        }

 .CorporateVouDrop {
    width: 16.5%;
    float: right;
    margin: 0px 6px 0px 0px;
}

        span#logix_CPH_Label3 {
            color: #000 !important;
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
                font-size: 12px;
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
            font-family: Tahoma;
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
                font-size: 12px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 12px;
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
                font-family: Tahoma;
                color: #4e4e4c;
            }

        .btn.btn-upload1.btnhctrlnew1 {
            float: left;
        }

        .CorporateVouInput2 label {
            margin: 0px 0 0 5px !important;
        }

        .PaymentLbl {
      float: left;
    text-align: center;
    margin: 4px 0.5% 0px 0px;
    position: relative;
    right: -1%;
    top: 6px;
    width:100%
        }

       .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}

        span#logix_CPH_lbl_title {
            color: var(--labelblack) !important;
            font-size: 11px;
        }

        .Year5 {
            float: right;
            width: 7%;
            margin: 0px 0.5% 0px 0%;
        }

        .btn.btn-upload1 {
            margin: 15px 0 0 0;
        }

        div#logix_CPH_ddl_crdr_chzn {
            opacity: 1 !important;
        }

        span#logix_CPH_lbl_voucher {
            color: #4d4d4d !important;
            float: left;
        }

        .Narration {
                float: left;
    margin: 0 0.5% 0px 0px;
    width: 65%;
        }

        div#logix_CPH_Chk_accountpayee {
            display: flex;
            flex-direction: column-reverse;
        }

            div#logix_CPH_Chk_accountpayee center + label {
                font-size: 9px !important;
                margin: 0 0 0 5px !important;
                display: block;
                color: var(--labelblue) !important;
            }
            .btn.ico-add {
    float: right;
    margin-top: 9px !important;
}
            div#UpdatePanel1 {
    height: 89vh;
    overflow-x: hidden;
    overflow-y: auto;
}
            .receivefrom{
                 float: left;
            width: 78%;
            margin: 0px 0.5% 0px 0%;
            }
            .gridpanel{
                    width: 100%;
    float: left;
 
   
            }
   .TotalTxt2.TextField {
    text-align: right;
}
            .Amount13.TextField span {
    text-align: right;
}
            .receivefrom {
    float: left;
    width: 36%;
    margin: 0px 0.5% 0px 0%;
}
        .bordertopNew {
            margin: 9px 0px 9px 0px !important;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {
                $("#<%=txt_recieve.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/PaymentFA_Receipt.aspx/GetCustomer",
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
                        $("#<%=txt_recieve.ClientID %>").val(i.item.label);
                        $("#<%=txt_recieve.ClientID %>").change();
                        $("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_recieve.ClientID %>").val(i.item.label);
                        $("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_recieve.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_recieve.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_cheque.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/PaymentFA_Receipt.aspx/GetCheque",
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
            });

            $(document).ready(function () {
                $("#<%=txt_bank.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/PaymentFA_Receipt.aspx/GetBank",
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
                            url: "../FAForms/PaymentFA_Receipt.aspx/GetDeduction",
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
                        $("#<%=txt_deduction.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=hid_deduction .ClientID %>").val(i.item.val);
                        $("#<%=txt_deduction.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_deduction.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=hid_deduction.ClientID %>").val(i.item.val);
                        $("#<%=txt_deduction.ClientID %>").val($.trim(result));
                      <%--  $("#<%=txt_deduction.ClientID %>").change();--%>
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_deduction.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_deduction.ClientID %>").val(i.item.val);
                            <%--$("#<%=txt_deduction.ClientID %>").change();--%>
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_deduction.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_deduction.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_cust.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../FAForms/PaymentFA_Receipt.aspx/GetCust",
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
                        $("#<%=txt_cust.ClientID %>").val(i.item.label);
                        $("#<%=txt_cust.ClientID %>").change();
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_cust.ClientID %>").val(i.item.label);
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_cust.ClientID %>").val(i.item.label);
                            //$("#<%=txt_cust.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_custid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        $("#<%=txt_cust.ClientID %>").val(i.item.label);
                        // var result = $("#<%=txt_cust.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_cust.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=Txt_pan.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../FAForms/PaymentFA_Receipt.aspx/GetCustomerPano",
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
                        $("#<%=Txt_pan.ClientID %>").val(i.item.label);
                        $("#<%=Txt_pan.ClientID %>").change();
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=Txt_pan.ClientID %>").val(i.item.label);
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=Txt_pan.ClientID %>").val(i.item.label);
                            //$("#<%=Txt_pan.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_custid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        $("#<%=Txt_pan.ClientID %>").val(i.item.label);
                        // var result = $("#<%=Txt_pan.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=Txt_pan.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txt_depositbank.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/PaymentFA_Receipt.aspx/GetBank",
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
                        $("#<%=txt_depositbank.ClientID %>").val(i.item.label);
                        $("#<%=txt_depositbank.ClientID %>").change();
                        $("#<%=hid_bankdepositid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_depositbank.ClientID %>").val(i.item.label);
                        $("#<%=hid_bankdepositid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_depositbank.ClientID %>").val(i.item.label);
                        $("#<%=hid_bankdepositid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

        function getConfirmationValue() {
            if (confirm('Are you sure you want to delete the details?')) {
                $('#<%=hfWasConfirmed.ClientID%>').val('true')
            }
            else {
                $('#<%=hfWasConfirmed.ClientID%>').val('false')
            }
            return true;
        }

        function Confirm() {
            var ChkValue = document.getElementById("<%=Chk_Account.ClientID%>");

            if ((document.getElementById('<%=ddl_branch.ClientID%>').value == "Branch")) {
                alertify.alert('Branch cannot be blank');
                return false;
            }
            else if ((document.getElementById('<%=ddl_mode.ClientID%>').value == "") || (document.getElementById('<%=ddl_mode.ClientID%>').value == -1)) {
                alertify.alert('Select Mode');
                return false;
            }
            else if ((document.getElementById('<%=ddl_mode.ClientID%>').value == "Cheque/DD")) {
                if (!(ChkValue.checked)) {
                    if (confirm('Confirm Account Payee')) {
                        $('#<%=Str_Value.ClientID%>').val('true')
                        alertify.alert('Select Account Payee');
                        return false;
                    }
                    else {
                        $('#<%=Str_Value.ClientID%>').val('false')
                        return true;
                    }
                }
            }
}

    </script>

    <%-- -------------------------For Gidview ColumnIndex ------------------------- --%>
    <script type="text/javascript">
        $(function () {
            $(".Grid_Account > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".Grid_Account td").removeClass("highlite");
                    var $cell = $(e.target).closest("td");
                    $cell.addClass('highlite');
                    var $currentCellText = $cell.text();
                    var $leftCellText = $cell.prev().text();
                    var $rightCellText = $cell.next().text();
                    var $colIndex = $cell.parent().children().index($cell);
                    var $colName = $cell.closest("table")
                        .find('th:eq(' + $colIndex + ')').text();
                    $("#para").empty()
                    .append("<b>Current Cell Text: </b>"
                        + $currentCellText + "<br/>")
                    .append("<b>Text to Left of Clicked Cell: </b>"
                        + $leftCellText + "<br/>")
                    .append("<b>Text to Right of Clicked Cell: </b>"
                        + $rightCellText + "<br/>")
                    .append("<b>Column Name of Clicked Cell: </b>"
                        + $colName)
                });
        });

    </script>
    <script type="text/javascript">
        function disableBtn(btnID, newText) {
            //initialize to avoid 'Page_IsValid is undefined' JavaScript error
            Page_IsValid = null;
            //check if the page request any validation
            // if yes, check if the page was valid
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                //you can pass in the validation group name also
            }
            //variables
            var btn = document.getElementById(btnID);
            var isValidationOk = Page_IsValid;
            /********NEW UPDATE************************************/
            //if not IE then enable the button on unload before redirecting/ rendering
            if (navigator.appName !== 'Microsoft Internet Explorer') {
                EnableOnUnload(btnID, btn.value);
            }
            /***********END UPDATE ****************************/
            // isValidationOk is not null
            if (isValidationOk !== null) {
                //page was valid
                if (isValidationOk) {
                    btn.disabled = true;
                    btn.value = newText;
                    btn.style.background = 'url(~/images/ajax-loader.gif)';
                }
                else {//page was not valid
                    btn.disabled = false;
                }
            }
            else {//the page don't have any validation request
                setTimeout("setImage('" + btnID + "')", 10);
                btn.disabled = true;
                btn.value = newText;
            }
        }

        //set the background image of the button
        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(images/Loading.gif)';
        }

        //enable the button and restore the original text value
        function EnableOnUnload(btnID, btnText) {
            window.onunload = function () {
                var btn = document.getElementById(btnID);
                btn.disabled = false;
                btn.value = btnText;
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="">
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Vouchers</a> </li>
                            <li>
                                <asp:Label ID="lbl_headertitile" runat="server"></asp:Label></li>

                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>

                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                    <div class="FixedButtons" >
     <div class="right_btn">
                <div class="btn ico-reverse-booking" id="revid" runat="server" visible="false" >
                    <asp:Button ID="Btn_rev" runat="server" Text="Reversal" ToolTip="Reversal" Visible="false" OnClick="Btn_rev_Click2" />
                </div>
                <div class="btn ico-save">
                    <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                </div>
                <div class="btn ico-view">
                    <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
                </div>
                <div class="btn ico-delete">
                    <asp:Button ID="btn_delete" runat="server" Text="Delete" ToolTip="Delete" OnClick="btn_delete_Click" />
                </div>
                <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                    <asp:Button ID="btn_back" runat="server" Text="Back" ToolTip="Back" OnClick="btn_back_Click" />
                </div>

                <div class="btn ico-on-account" id="onaccount" runat="server">
                    <asp:Button ID="btn_onaccount" runat="server" Text="OnAccount" ToolTip="OnAccount" OnClick="btn_onaccount_Click" />
                </div>

            </div>
</div>

                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">

                        <div class="Checkbox" id="Hydvis" runat="server" visible="false">
                            <div class="visaka">
                                <asp:CheckBox ID="chk_visak" runat="server" Text="VISAKHAPATNAM" AutoPostBack="true" OnCheckedChanged="chk_visak_CheckedChanged" />
                            </div>
                            <div class="visaka1">
                                <asp:CheckBox ID="chk_hyde" runat="server" Text="HYDERABAD" AutoPostBack="true" OnCheckedChanged="chk_hyde_CheckedChanged" />
                            </div>

                        </div>
                        <div class="PaymentLbl" style="display:none;">
                            <asp:Label ID="lbl_title" runat="server"></asp:Label>
                        </div>

                      
                        <div class="BranchDropN1">
                            <asp:Label ID="Label4" runat="server" Text="Branch" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddl_branch" runat="server" Width="100%" Height="23" CssClass="chzn-select" ToolTip="BRANCH" placeholder="Branch">
                            </asp:DropDownList>
                        </div>
                        <div class="DateLbl1" style="display: none;">
                            <asp:Label ID="lbl_date" runat="server" Text="Date"></asp:Label>
                        </div>

                    </div>

                    <div class="FormGroupContent4">

                        <div id="cheque" runat="server">
                            <asp:LinkButton ID="lnk_cheque" CssClass="anc ico-find-sm" Style="text-decoration: none; color: Red;" runat="server" OnClick="lnk_cheque_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnk_amount" CssClass="anc ico-find-sm" runat="server" Style="text-decoration: none; color: Red;" OnClick="lnk_amount_Click"> </asp:LinkButton>
                        </div>
                    </div>

                    <%--<div class="FormGroupContent4">
                    </div>--%>
                    <div class="FormGroupContent4">
                        <div class="PaymentChk">
                            <div id="divPayment" runat="server">
                                <asp:CheckBox ID="chkDirectPay" runat="server" Text="Direct Payment" AutoPostBack="true" CssClass="ChkLabelValue" Visible="false" />
                            </div>
                        </div>
                    </div>
                            <div class="FormGroupContent4">
                               
                                 <div class="receivefrom">
                                    <asp:Label ID="Label21" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txt_recieve" runat="server" CssClass="form-control" ToolTip="RECEIPT" OnTextChanged="txt_recieve_TextChanged"></asp:TextBox>
                                </div>


                                <div class="Amount12">
                                    <asp:Label ID="Label22" runat="server" Text="Amount"></asp:Label>
                                    <asp:TextBox ID="txt_amt" runat="server" CssClass="form-control" Style="text-align: right" placeholder="" ToolTip="AMOUNT"></asp:TextBox>
                                </div>

                                

          <div class="DateCal4 DateR">
    <asp:Label ID="Label7" runat="server" Text="Date"></asp:Label>
    <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" ToolTip="RECEIPT DATE" AutoPostBack="true" OnTextChanged="txt_date_TextChanged"> </asp:TextBox>
    <%----%>
    <asp:CalendarExtender ID="txt_date_calender" runat="server" TargetControlID="txt_date" Enabled="true" Format="dd/MM/yyyy" />
    <%--ondayrender="calder_render"--%>
</div>
<div class="PaymentInput">
    <asp:Label ID="Label8" runat="server" Text="Receipt #"></asp:Label>
    <asp:TextBox ID="txt_recp" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="" ToolTip="RECEIPT #" OnTextChanged="txt_recp_TextChanged"></asp:TextBox>
</div>

<div class="Year5">
    <asp:Label ID="Label6" runat="server" Text="Year"></asp:Label>
    <asp:TextBox ID="txt_recpdate" runat="server" CssClass="form-control" placeholder="" ToolTip="RECEIPT YEAR"></asp:TextBox>
</div>

<div class="BranchDropN2">
    <asp:Label ID="Label5" runat="server" Text="Mode"></asp:Label>
    <asp:DropDownList ID="ddl_mode" runat="server" Height="23" Width="100%" CssClass="chzn-select" AutoPostBack="true" placeholder="Mode" ToolTip="MODE" OnSelectedIndexChanged="ddl_mode_SelectedIndexChanged" OnTextChanged="ddl_mode_TextChanged">
        <asp:ListItem Value="0">Mode</asp:ListItem>
    </asp:DropDownList>
</div>


    </div>
                            <div class="bordertopNew"></div>


                           


                    <div class="FormGroupContent4">
                        <div class="PaymentLeft">
                  

                            <div class="FormGroupContent4">

                                <div class="ChequeDD">
                                    <asp:Label ID="Label9" runat="server" Text="Chq/DD/RTGS/NEFT"></asp:Label>
                                    <asp:TextBox ID="txt_cheque" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="CHEQUE/DD #" OnTextChanged="txt_cheque_TextChanged"></asp:TextBox>

                                </div>
                                <div class="BranchCal">
                                    <asp:Label ID="Label12" runat="server" Text=" Date"></asp:Label>
                                    <asp:TextBox ID="txt_cheqdate" runat="server" CssClass="form-control" ToolTip="Cheque Date"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_cheqdate_calender" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_cheqdate" TodaysDateFormat="dd/MM/yyyy" Enabled="true"></asp:CalendarExtender>
                                </div>

                               
                       

                                <div class="BankText">
                                    <asp:Label ID="Label10" runat="server" Text=" From Bank"></asp:Label>
                                    <asp:TextBox ID="txt_bank" runat="server" CssClass="form-control" placeholder="" ToolTip="BANK"></asp:TextBox>
                                </div>
                                <div class="BranchDD">
                                    <asp:Label ID="Label11" runat="server" Text="Branch"></asp:Label>
                                    <asp:TextBox ID="txt_branch1" runat="server" CssClass="form-control" placeholder="" ToolTip="BRANCH"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 ">
                                <div class="Narration ">

                                    <asp:Label ID="Label13" runat="server" Text="Narration"></asp:Label>
                                    <asp:TextBox ID="txt_narration" runat="server" CssClass="form-control" placeholder="" ToolTip="NARRATION" MaxLength="500"></asp:TextBox>
                                </div>
                                 <div class="DepositBank">
                                    <asp:Label ID="Label18" runat="server" Text="Deposit Bank"></asp:Label>
                                    <asp:TextBox ID="txt_depositbank" runat="server" placeholder="" ToolTip="Deposit Bank" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="bordertopNew"></div>
                            <div class="FormGroupContent4 boxmodal">


                                <div class="FormGroupContent4 Hide">
                                   <div class="Customer2" style="width:23%" >
                                        <asp:Label ID="lbl_pan" runat="server" Text="PAN #"></asp:Label>
                                        <asp:TextBox ID="Txt_pan" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="PAN #" OnTextChanged="Txt_pan_TextChanged"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="FormGroupContent4">
                                <div class="Customer2">
                                    <asp:Label ID="Label14" runat="server" Text="Ledger"></asp:Label>
                                    <asp:TextBox ID="txt_cust" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="CUSTOMER" OnTextChanged="txt_cust_TextChanged"></asp:TextBox>
                                </div>
    
                                <div class="Amount13">
                                    <asp:Label ID="Label15" runat="server" Text="Amount"></asp:Label>
                                    <asp:TextBox ID="txt_cust_amt" runat="server" CssClass="form-control" Style="text-align: right" placeholder="" ToolTip="AMOUNT"></asp:TextBox>
                                </div>
                                  
                                <div class="btn ico-add">
                                    <asp:Button ID="btn_cust_add" runat="server" Text="Add" CssClass="" OnClick="btn_cust_add_Click" />
                                </div>
                                      </div>

                                <div class="FormGroupContent4">
                                <div class="Customer2">
                                    <asp:Label ID="Label16" runat="server" Text="Tax/ledger"></asp:Label>
                                    <asp:TextBox ID="txt_deduction" runat="server" CssClass="form-control" placeholder="" ToolTip="DEDUCTION" AutoPostBack="true" OnTextChanged="txt_deduction_TextChanged"></asp:TextBox>

                                </div>
                                <div class="Amount13">
                                    <asp:Label ID="Label17" runat="server" Text="Amount"></asp:Label>
                                    <asp:TextBox ID="txt_dedu_amt" runat="server" CssClass="form-control" Style="text-align: right" placeholder="" ToolTip="DEDUCTION AMOUNT"></asp:TextBox>
                                </div>
                                <div class="btn ico-add">
                                    <asp:Button ID="btn_deduct_add" runat="server" Text="Add" CssClass="" OnClick="btn_deduct_add_Click" />
                                </div>
                                    </div>

                                <div class="FormGroupContent4">
                                <div class="BankDeposit">
                                    <div id="Chk_accountpayee" runat="server">
                                        <asp:CheckBox ID="Chk_Account" runat="server" Text="Account Payee" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="btn ico-add" style="margin: 4px 1px 0px 0px">
                                    <asp:Button ID="btn_short_add" runat="server" Text="Add" CssClass="" OnClick="btn_short_add_Click" />
                                </div>

                                <div class="Amount13 excess_amt">
                                    <asp:Label ID="Label23" runat="server" Text="Excess / Short"></asp:Label>
                                    <asp:TextBox ID="txt_excess_amt" placeholder="" ToolTip="EXCESS(+)/SHORT(-)" runat="server" CssClass="form-control" Width="100%" Style="text-align: right"></asp:TextBox>
                                </div>



                                </div>








                                <div style="display: none;">
                                    <asp:Label ID="lbl_excess_amt" runat="server" Text="Excess(+)/Short(-)"></asp:Label>
                                </div>

                            </div>
                            <div class="FormGroupContent4 boxmodal">
                            <div class="gridpanel" > 
                            <asp:Panel ID="panel_acc" CssClass="gridpnl" runat="server" Style="overflow: auto;">
                                <asp:GridView ID="Grid_Account" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeaderWhenEmpty="True" class="TblGrid FixedHeader"
                                    OnRowCommand="Grid_Account_RowCommand" DataKeyNames="cid" OnRowDataBound="Grid_Account_RowDataBound" OnSelectedIndexChanged="Grid_Account_SelectedIndexChanged1" OnPreRender="Grid_Account_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="Type" HeaderText="Type">
                                            <ItemStyle Width="150px" />
                                            <HeaderStyle Width="150px" />

                                        </asp:BoundField>
                                        <asp:BoundField DataField="Customerortax" HeaderText="Customer / Tax Charges">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" DataFormatString="{0:#;##0.00}" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cid" HeaderText="cid">
                                            <HeaderStyle CssClass="Hide" />
                                            <ItemStyle CssClass="Hide" />
                                        </asp:BoundField>
                                        <%-- <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgdelete" runat="server"  
                            ImageUrl="~/images/delete.jpg" OnClick="imgdelete_Click" Height="16px" OnClientClick="return getConfirmationValue();" />

                            </ItemTemplate>
                        <ItemStyle Width="15%" HorizontalAlign="Center"/>
                        </asp:TemplateField>    --%>
                                        <asp:ButtonField CommandName="Select" Visible="false" />
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle CssClass="GrdRow" />
                                </asp:GridView>
                            </asp:Panel>
                                 <div class="TotalTxt2" style="float: right">
                                <asp:Label ID="Label20" runat="server" Text="Total"></asp:Label>
                                <asp:TextBox ID="txt_total" runat="server" Style="text-align: right" CssClass="form-control" placeholder="" ToolTip="TOTAL"></asp:TextBox>
                            </div>

                                 </div>
                        </div>
                        </div>
                        <div class="PaymentRight boxmodal">
                              <div class="FormGroupContent4" style="margin-top: 7px; ">
                                <div class="CorporateVoucher" style="display: none">
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                </div>

                                <div class="CorporateVouInput">
                                    <asp:Label ID="Label19" runat="server" Text="Voucher #"></asp:Label>
                                    <asp:TextBox ID="txtsch" runat="server" placeHolder="Voucher #" AutoPostBack="true" ToolTip="Vouchar" CssClass="form-control" TabIndex="29" OnTextChanged="txtsch_TextChanged"></asp:TextBox>
                                </div>
                                <div class="CorporateVouDrop">
                                    <asp:Label ID="Label24" runat="server" Text="Filter By"></asp:Label>
                                    <asp:DropDownList ID="cmbvoutype" Height="23px" runat="server" CssClass="chzn-select" placeholder="" ToolTip="Type" TabIndex="30" AutoPostBack="true" OnSelectedIndexChanged="cmbvoutype_SelectedIndexChanged">
                                        <asp:ListItem>Vou Type</asp:ListItem>
                                        <asp:ListItem>CN</asp:ListItem>
                                        <asp:ListItem>DN</asp:ListItem>
                                        <%-- <asp:ListItem>OSCN</asp:ListItem>
                                <asp:ListItem>OSDN</asp:ListItem>--%>
                                        <asp:ListItem>INV</asp:ListItem>
                                        <asp:ListItem>CNOps</asp:ListItem>
                                        <%-- <asp:ListItem>OB OSDN</asp:ListItem>
                               <asp:ListItem>OB OSCN</asp:ListItem>
                                 <asp:ListItem>OB CN</asp:ListItem>--%>
                                        <asp:ListItem>ADN</asp:ListItem>
                                        <asp:ListItem>ACN</asp:ListItem>
                                        <%-- <asp:ListItem>OB OSCN</asp:ListItem>
                                <asp:ListItem>OB OSDN</asp:ListItem>
                                <asp:ListItem>OB INV</asp:ListItem>
                                <asp:ListItem>OB CNOps</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </div>
                                <div class="CorporateVouInput2">

                                    <span>Receipt Amout </span>

                                    <asp:CheckBox ID="chkrpt" runat="server" AutoPostBack="true" OnCheckedChanged="chkrpt_CheckedChanged" />

                                </div>

                            </div>
                          
                           <div class="FormGroupContent4">
                                <asp:Label ID="lbl_voucher" runat="server" Text="<span class='bluetext'>Vendor Invoice Amount are After detecting TDS</span>" CssClass="LabelValue"></asp:Label>


                           </div>
                            <div class="FormGroupContent4">
                                <div class="gridpnl">
                                    <asp:Panel ID="panel_details" runat="server">
                                        <%--ScrollBars="Auto"BorderColor="#999997"Width="100%"--%>
                                        <asp:GridView ID="Grid_detail" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" class="Grid FixedHeader" PageSize="5" DataKeyNames="Cust_Id"
                                            OnPageIndexChanging="Grid_detail_PageIndexChanging" OnRowCommand="Grid_detail_RowCommand" OnSelectedIndexChanged="Grid_detail_SelectedIndexChanged" OnPreRender="Grid_detail_PreRender">

                                            <Columns>
                                                <asp:BoundField DataField="branchHide" HeaderText="Branch">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branch" HeaderText="Branch">
                                                    <ItemStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                                                    <ItemStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="iamount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle Width="120px" />
                                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Recpt-Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_receiptamount" runat="server" Text='<%#Bind("ramount") %>' ToolTip='<%#Bind("ramount") %>' AutoPostBack="true" Style="text-align: right; border: none!important;" CssClass="form-control" OnTextChanged="txt_receiptamount_TextChanged" onkeypress="return isNumberKey(event,this.id)"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                                                    <HeaderStyle Width="120px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="voutype" HeaderText="VoyType">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vouno" HeaderText="vou #">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tds" HeaderText="tdsamt">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ravouyear" HeaderText="RAVouYear">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ltype" HeaderText="ltype">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cust_Id" HeaderText="Cust_Id">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false" />

                                                </asp:BoundField>
                                                <asp:BoundField DataField="vendorrefdate" HeaderText="Vendor Ref Date">
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>
                                                <asp:ButtonField CommandName="Select" Visible="false" />

                                                <asp:TemplateField HeaderText="Select" HeaderStyle-Font-Size="10pt">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chkrecpfc" runat="server" AutoPostBack="true" OnCheckedChanged="Chkrecpfc_CheckedChanged" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="jlid" HeaderText="jlid">
                                                    <ItemStyle />
                                                    <HeaderStyle CssClass="Hide" />
                                                    <ItemStyle CssClass="Hide" />
                                                </asp:BoundField>

                                            </Columns>

                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle CssClass="GrdRow" />

                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="FormGroupContent4 hide">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <Triggers>

                                        <asp:PostBackTrigger ControlID="btn_upload" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <div class=" fileUpload5">
                                            <asp:FileUpload ID="fileupload1" runat="server" Width="13" />
                                        </div>
                                        <div class="btn ico-upload">
                                            <asp:Button ID="btn_upload" runat="server" TabIndex="32" Text="Upload" OnClick="btn_upload_Click" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                       
                        <div class="FormGroupContent4">
                            <div class="RefTxtLbl">
                                <asp:Label ID="Label25" runat="server" Text="Ref.No"></asp:Label>
                                <asp:TextBox ID="txt_refno" runat="server" CssClass="form-control" placeholder="" ToolTip="Ref.No"></asp:TextBox>
                                <asp:Label ID="Label26" runat="server" Text="Favouring"></asp:Label>
                                <asp:TextBox ID="txt_fvr" runat="server" Width="100%" CssClass="form-control" placeholder="" ToolTip="FAVOURING"></asp:TextBox>
                                <asp:Label ID="lbl_amountinword" runat="server" ForeColor="Black" Visible="false"></asp:Label>
                            </div>

                           
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%------------------------------------ModelPOpup----------------------------------------%>

    <cc1:ModalPopupExtender ID="programmaticModalPopup" runat="server" BehaviorID="programmaticModalPopupBehaviordf1" TargetControlID="cancel_btn"
        CancelControlID="cancel_btn" PopupControlID="POPUP1" OkControlID="imgok" DropShadow="false">
    </cc1:ModalPopupExtender>

    <asp:Panel ID="POPUP1" runat="server" CssClass="modalPopup" Style="display: none;">

        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl" ScrollBars="Vertical">

                <asp:GridView ID="Grid_Cheque" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader"
                    OnRowDataBound="Grid_Cheque_RowDataBound" OnRowCommand="Grid_Cheque_RowCommand" OnSelectedIndexChanged="Grid_Cheque_SelectedIndexChanged"
                    EmptyDataText="No Records Found" OnPageIndexChanging="Grid_Cheque_PageIndexChanging" AllowPaging="true" PageSize="15">

                    <Columns>
                        <asp:BoundField DataField="grdChequeno" HeaderText="Cheque No" />
                        <asp:BoundField DataField="grdCustomer" HeaderText="Customer" />
                        <asp:BoundField DataField="grdBankName" HeaderText="Bank" />
                        <asp:BoundField DataField="grdAmount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                        <asp:BoundField DataField="nono" HeaderText="nono">
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="customerid" HeaderText="custid">
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
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

    <%-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>

    <asp:Label ID="lbltag" runat="server"> </asp:Label>

    <cc1:ModalPopupExtender ID="ModalPopup_amount" runat="server" BehaviorID="programmaticModalPopupBehaviordf2" TargetControlID="lbltag"
        CancelControlID="img_close" PopupControlID="Panel2" DropShadow="false">
    </cc1:ModalPopupExtender>

    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" Style="display: none;">

        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="img_close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="panel3" runat="server" ScrollBars="Vertical" CssClass="Gridpnl">
                <asp:GridView ID="Grid_Amount" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" OnRowDataBound="Grid_Amount_RowDataBound"
                    OnSelectedIndexChanged="Grid_Amount_SelectedIndexChanged">
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
                        <asp:BoundField DataField="cstamount" HeaderText="VouAmt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                        <asp:BoundField DataField="rptamt" HeaderText="Recpt-Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
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
                            <HeaderStyle CssClass="Hide" />
                            <ItemStyle CssClass="Hide" />
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
                        <asp:BoundField DataField="vendorrefno" HeaderText="vendor ref #"></asp:BoundField>
                        <asp:BoundField DataField="vendorrefdate" HeaderText="vendor ref date">
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

                <div class="Clear"></div>

            </asp:Panel>
            <div class="right_btn">
                <div class="btn btn-Ok1">
                    <asp:Button ID="btn_ok" runat="server" Text="Ok" OnClick="btn_ok_Click" />
                </div>

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
    <cc1:ModalPopupExtender ID="PopUpService" runat="server" PopupControlID="Panel_Service" TargetControlID="Label1"></cc1:ModalPopupExtender>
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
    <cc1:ModalPopupExtender ID="popup_ref" runat="server" PopupControlID="Panel_ref" TargetControlID="Label2"></cc1:ModalPopupExtender>
    <asp:Label ID="Label2" runat="server"></asp:Label>

    <asp:HiddenField ID="hid_deduction" runat="server" />
    <asp:HiddenField ID="hid_custid" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_customerid" runat="server" />
    <asp:HiddenField ID="hid_VouAmt" runat="server" />
    <asp:HiddenField ID="hid_cid" runat="server" />
    <asp:HiddenField ID="hid_chargeid" runat="server" />
    <asp:HiddenField ID="hid_bankid" runat="server" />
    <asp:HiddenField ID="hid_acpay" runat="server" />
    <asp:HiddenField ID="hid_cheque" runat="server" />
    <asp:HiddenField ID="hid_receiptid" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />
    <asp:HiddenField ID="Str_Value" runat="server" />
    <asp:HiddenField ID="Hid_Rid" runat="server" />
    <asp:HiddenField ID="hid_alertMsg" runat="server" />
    <asp:HiddenField ID="Hid_Receivedfrom" runat="server" />

    <asp:HiddenField ID="hid_bankdepositid" runat="server" />

    <asp:HiddenField ID="hid_depositslipino" runat="server" />
    <asp:HiddenField ID="NewaspxRpt" runat="server" Value="Y" />

    <asp:HiddenField ID="NewPayRpt" runat="server" Value="Y" />
    <asp:HiddenField ID="hid_invoiceno" runat="server" />
    <asp:HiddenField ID="hid_Lid" runat="server" />

    <script type="text/javascript">
        function closingamount() {
            alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Issue the Payment');
        }
    </script>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <%-- <label>Receipt/Payment #</label>--%>
                    <label id="lbl_no" runat="server"></label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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

    <asp:Label ID="Label27" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label27" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
