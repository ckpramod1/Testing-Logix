<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="Outstanding_Online_New.aspx.cs" Inherits="logix.FAForms.Outstanding_Online_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="KRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />

    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

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

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
    <link href="../Styles/OutstandingNew.css" rel="stylesheet" />

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

                $("#<%=txtSubGroupName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_name.ClientID %>").val(0);

                        $.ajax({
                            url: "../FAForms/Outstanding_Online_New.aspx/Getcustomer",
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
                        $("#<%=txtSubGroupName.ClientID %>").val(i.item.label);
                        $("#<%=txtSubGroupName.ClientID %>").change();
                        $("#<%=hdf_id.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtSubGroupName.ClientID %>").val(i.item.label);
                        $("#<%=hdf_id.ClientID %>").val(i.item.val);
                    },

                    close: function (e, i) {
                        var result = $("#<%=txtSubGroupName.ClientID %>").val().toString().split[','];
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txtSubGroupName.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txtSubGroupName.ClientID %>").val($.trim(res));
                        }
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txtLedger.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_custname.ClientID %>").val(0);

                        $.ajax({
                            url: "../FAForms/Outstanding_Online_New.aspx/Gettxtcustomer",
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
                        $("#<%=txtLedger.ClientID %>").val(i.item.label);
                        $("#<%=txtLedger.ClientID %>").change();
                        $("#<%=hf_custname.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtLedger.ClientID %>").val(i.item.label);
                        $("#<%=hf_custname.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        // var result = $("#<%=txtLedger.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtLedger.ClientID %>").val(i.item.label);
                        $("#<%=txtLedger.ClientID %>").val($.trim(result));
                    },

                        <%--select: function (event, i) {
                          $("#<%=txtLedger.ClientID %>").val(i.item.label);
                         $("#<%=txtLedger.ClientID %>").change();
                         $("#<%=hf_custname.ClientID %>").val(i.item.val);
                         $("#<%=hf_custid.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txtLedger.ClientID %>").val(i.item.label);
                         $("#<%=hf_custname.ClientID %>").val(i.item.val);
                     },
                     change: function (event, i) {
                         $("#<%=txtLedger.ClientID %>").val(i.item.label);
                         $("#<%=hf_custname.ClientID %>").val(i.item.val);

                     },
                     close: function (event, i) {
                         $("#<%=txtLedger.ClientID %>").val(i.item.label);
                         $("#<%=hf_custname.ClientID %>").val(i.item.val);
                         $("#<%=hf_custid.ClientID %>").val(i.item.val);
                     },--%>

                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txtSalesPerson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_salename.ClientID %>").val(0);

                        $.ajax({
                            url: "../FAForms/Outstanding_Online_New.aspx/Gettxtsales",
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
                        $("#<%=txtSalesPerson.ClientID %>").val(i.item.label);
                        $("#<%=txtSalesPerson.ClientID %>").change();
                        $("#<%=hdf_salename.ClientID %>").val(i.item.val);
                        $("#<%=hdf_idsales.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val(i.item.label);
                        $("#<%=hdf_salename.ClientID %>").val(i.item.val);
                        $("#<%=hdf_idsales.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val(i.item.label);
                        $("#<%=hdf_salename.ClientID %>").val(i.item.val);
                        $("#<%=hdf_idsales.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val(i.item.label);
                        $("#<%=hdf_salename.ClientID %>").val(i.item.val);
                        $("#<%=hdf_idsales.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });

            function DoAction(Text) {
                $("#<%=hdf_grdvou.ClientID %>").val('');
                $("#<%=hdf_grdvou.ClientID %>").val(Text);
            }
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <script type="text/javascript">
        $(function () {
            $(".GrdAgeing > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".GrdAgeing td").removeClass("highlite");
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
    <style type="text/css">
        .BranchDrop7 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 15%;
        }

        .LedgerInputO {
            float: left;
            margin: 0 0.5% 0 0;
            width: 46.5%;
        }

        .FormGroupContent4 label {
            display: inline-block !important;
            float: left !important;
            margin: 0 0 0 5px;
            width: auto !important;
        }

        .TblGridS1 {
            width: 100%;
            border: 1px solid #b1b1b1;
            height: 420px;
            margin: 0px 0px 10px 0px;
            overflow-x: auto !important;
            overflow-y: auto !important;
        }

        #logix_CPH_ddlbranch {
            width: 100% !important;
        }

        #logix_CPH_ddlProduct {
            width: 100% !important;
        }

        #logix_CPH_ddlcurency {
            width: 100% !important;
        }

        .ChkDatecal {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LedgerChk label {
            display: inline-block;
            margin: -1px 0px 0px 0px;
        }

        .SalesAeging {
            width: 18%;
            float: left;
            margin: 5px 0.5% 0px 0px;
        }

            .SalesAeging label {
                display: inline-block;
                margin: -4px 0px 0px 0px !important;
            }

        .div_frame {
            width: 100%;
            height: 570px;
            float: left;
            text-align: center;
            overflow-y: hidden;
            overflow-x: hidden;
        }

        .LedgerInput {
            width: 79%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_pln_Trialbalance {
            left: -3px !important;
            top: 30px !important;
        }

        .div_frame {
            border-right: 0px solid #000;
            border-left: 0px solid #000;
        }

        .BacktoPrevious {
            width: 33%;
            text-align: left;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_iframecost {
            width: 1354px;
            height: 698px;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.5%;
            margin-top: -0.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .right_btn {
            margin: 9px 0px 0px 0px;
        }

        .SalesPerson1 {
            width: 41.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .widget-content {
            padding: 0 10px !important;
        }
 
        .SubGroupContent1O {
    float: left;
    margin: 0 0.5% 0 0;
    width: 23.5%;
}
 .widget.box .widget-content {
    top: 0px !important;
    padding-top: 67px !important;
}
        .TextField .chzn-container-single .chzn-default {
    height: 48px !important;
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    /*font-weight: normal !important;*/
}
        span#logix_CPH_Label4 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    /*font-weight: normal !important;*/
}
        span#logix_CPH_Label7 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    /*font-weight: normal !important;*/
}
        span#logix_CPH_Label5 {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    /*font-weight: normal !important;*/
}
        input#logix_CPH_txtSalesPerson {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    /*font-weight: normal !important;*/
}
        span#Label6{
-webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
/*font-weight: normal !important;*/
        }
        .TextField .chzn-container-single .chzn-single {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
/*font-weight: normal !important;*/
        }
        .SalesPerson1 span {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
}


    </style>
    <script type="text/javascript">
        $(function () {
            $(".GrdLW > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".GrdLW td").removeClass("highlite");
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

    <style type="text/css">
        .ChkTillDate {
            font-size: 11px;
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 2%;
        }

        .BranchDrop7 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 15%;
        }

        .ProductDrop {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CurrencyDrop1 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
 

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .FormGroupContent4 label {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .LedgerChk {
            width: 9%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

        .chktext {
            font-size: 9px !important;
            margin: 0 0 0 0px !important;
            display: block;
            color: var(--labelblue) !important;
        }

        .slider.round {
            border-radius: 34px !important;
            width: 42px !important;
            height: 16px;
            margin: 0px 0 0;
        }

        .btn-ctrl1 {
            float: right;
            margin: 17px 0px 0px 0px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .LedgerChk label {
            margin: 5px 0 0 0;
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
                        <asp:Label ID="lblOutstanding" runat="server" Text="OutStanding"></asp:Label></h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#">Home</a> </li>
                            <li><a href="#">Outstanding</a> </li>
                            <li><a href="#" title="">OutStanding</a></li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>

                        </div>

                                      <div class="FixedButtons">
                        <div class="right_btn">
    <div class="btn ico-get">
        <asp:Button ID="btnGet" runat="server" Text="Get" ToolTip="Get" OnClick="btnGet_Click" />
    </div>
    <div class="btn ico-print" id="btn_print1" runat="server">
        <asp:Button ID="btnprint" runat="server"  Text="Print" ToolTip="Print" OnClick="btnprint_Click" />
    </div>
    <div class="btn ico-cancel MRRight" id="btn_cancel1" runat="server">
        <asp:Button ID="btnClear" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnClear_Click" />
    </div>
    <div class="btn ico-excel">
        <asp:Button ID="btnExpertExcel" runat="server" Text="Export Excel" ToolTip="Export Excel" OnClick="btnExpertExcel_Click" />
    </div>
</div>
                  </div>

                </div>
                <div class="widget-content">
                    

                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4" >
                        <div class="SubGroupContent1O">
                            <asp:Label ID="custname" runat="server" Text="" CssClass="hide"></asp:Label>
                            <asp:TextBox ID="txtSubGroupName" runat="server" placeholder="" ToolTip="Sub Group Name" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtSubGroupName_TextChanged"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="Sub Group Name"> </asp:Label>
                        </div>
                        <div class="LedgerInputO">
                            <asp:Label ID="Label1" runat="server" Text="Ledger"> </asp:Label>
                            <asp:TextBox ID="txtLedger" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Ledger" OnTextChanged="txtLedger_TextChanged"></asp:TextBox>

                            <asp:ListBox ID="lst" runat="server" Height="26px" Width="192px" Visible="false"></asp:ListBox>
                        </div>

                        <div class="ChkTillDate">
                            <asp:CheckBox ID="ChkTill" runat="server" Text="Till Date" OnCheckedChanged="ChkTill_CheckedChanged" AutoPostBack="true" Visible="false" />
                            <asp:Label Text="Till" ID="Till1" runat="server" Visible="false"></asp:Label>

                        </div>
                        <div class="ChkDatecal">
                            <asp:Label ID="Label3" runat="server" Text="Date"> </asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" TabIndex="4" CssClass="form-control" placeholder="" ToolTip="DATE"></asp:TextBox>
                        </div>

                        <div class="LedgerChk" style="margin-top: 16px;" >

                            <span>Zero Balance </span>

                            <asp:CheckBox ID="cbocheck" runat="server" AutoPostBack="true" />

                        </div>
                        <div class="BacktoPrevious">
                            <asp:LinkButton ID="lnk_back" Style="text-decoration: none; font-weight: bold" ForeColor="Red" runat="server" OnClick="lnk_back_Click">Back to Previous</asp:LinkButton>
                          

                        </div>
                            </div>
                        <div class="bordertopNew"></div>
                        <div class="FormGroupContent4" style="-webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    font-weight: normal !important;">

                            <div class="BranchDrop7">
                                <asp:Label ID="Label4" runat="server" Text="Branch"> </asp:Label>
                                <asp:DropDownList ID="ddlbranch" runat="server" CssClass="chzn-select" AppendDataBoundItems="True" ToolTip="Branch" AutoPostBack="true" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged">
                                    <%--<asp:ListItem Value="0" Text="Branch"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="ProductDrop">
                                <asp:Label ID="Label5" runat="server" Text="Product"> </asp:Label>
                                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="chzn-select" AppendDataBoundItems="True" ToolTip="Product" AutoPostBack="true" placeholder="Product" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="SalesPerson1">
                                <asp:Label ID="Label6" runat="server" Text="Sales Person" > </asp:Label>
                                <asp:TextBox ID="txtSalesPerson" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Sales Person" OnTextChanged="txtSalesPerson_TextChanged"></asp:TextBox>
                            </div>

                            <div class="CurrencyDrop1">
                                <asp:Label ID="Label7" runat="server" Text="Curr"> </asp:Label>

                                <asp:DropDownList ID="ddlcurency" CssClass="chzn-select" runat="server" AutoPostBack="true" AppendDataBoundItems="True" ToolTip="Currency" data-placeholder="Curr" OnSelectedIndexChanged="ddlcurency_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="LedgerChk">

                                <span> Ledger Ageing</span>
                                <center>
                                    <label class="switch" >
                                <asp:CheckBox ID="cboxLedgerAgeing" runat="server" AutoPostBack="true" OnCheckedChanged="cboxLedgerAgeing_CheckedChanged" />

                                    </label>
                                </center>
                            </div>
                            <div class="SalesAeging" style="display: none;">
                                <asp:CheckBox ID="cboxSalesAgeing" runat="server" Text="SalesAgeing" AutoPostBack="true" OnCheckedChanged="cboxSalesAgeing_CheckedChanged" />
                            </div>
                        </div>
                        
                        <div class="FormGroupContent4 boxmodal">

                            <asp:Panel ID="panel1" runat="server" CssClass="gridpnl MB0" ScrollBars="Both">

                                <asp:GridView ID="GrdLW_sl" runat="server" AutoGenerateColumns="false" Width="100%" Height="100%" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EnableTheming="False"
    CssClass="Grid FixedHeader" OnRowDataBound="GrdLW_sl_RowDataBound" DataKeyNames="bid" PageSize="500" AllowPaging="false"
    OnPageIndexChanging="GrdLW_sl_PageIndexChanging" Visible="false">
    <%-- --%>
    <Columns>
        <asp:TemplateField HeaderText="Date"><%-- 0 --%>
            <ItemTemplate>
                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 75px">
                    <asp:Label ID="voudate" runat="server" Text='<%# Bind("voudate") %>' ToolTip='<%#Bind("voudate")%>'></asp:Label>
                </div>

            </ItemTemplate>

            <HeaderStyle HorizontalAlign="Center" Width="75px" />
            <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />

        </asp:TemplateField>
        <asp:BoundField DataField="vouno" HeaderText="Vou #"><%-- 1 --%>
            <HeaderStyle Width="50px" Wrap="false" />
            <ItemStyle Font-Bold="false" Width="50px" Wrap="false" />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="Ledger"><%-- 2 --%>
            <ItemTemplate>
                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 250px">
                    <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%#Bind("customer")%>'></asp:Label>
                </div>

            </ItemTemplate>

            <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
            <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />

        </asp:TemplateField>
        <asp:BoundField DataField="curr" HeaderText="Curr" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <%-- 3 --%>
        <asp:BoundField DataField="fcurr" HeaderText="FCurr" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
        <%-- 4 --%>
        <asp:BoundField DataField="vamount" HeaderText="Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
        <%-- 5 --%>
        <asp:BoundField DataField="Receivedamount" HeaderText="Received Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
        <%-- 6 --%>
        <asp:BoundField DataField="amount" HeaderText="Balance Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
        <%-- 7 --%>
        <asp:BoundField DataField="famount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 8 --%>
            <HeaderStyle Width="100px" Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="100px" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="recefamount" HeaderText="Received Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
        <%-- 8 --%>
        <asp:BoundField DataField="foverdue" HeaderText="Balance Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 10 --%>
            <HeaderStyle Width="100px" Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="100px" Wrap="false" />
        </asp:BoundField>
        <%-- 9 --%>
         <asp:BoundField DataField="shortname" HeaderText="Branch">
     <HeaderStyle Wrap="false" />
     <ItemStyle Font-Bold="false" HorizontalAlign="Right" Wrap="false" />
 </asp:BoundField>
        <%-- 11 --%>
        <asp:BoundField DataField="trantype" HeaderText="Product#" />
        <%-- 10 --%>
        <asp:BoundField DataField="jobno" HeaderText="Job #" />
        <%-- 11 --%>
        <asp:BoundField DataField="mblno" HeaderText="MBL #" />
        <%-- 12 --%>
        <asp:BoundField DataField="refno" HeaderText="BL #"><%-- 13 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="true" />
        </asp:BoundField>
        <asp:BoundField DataField="Shipper" HeaderText="Shipper"><%-- 14 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="70px" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="Consignee" HeaderText="Consignee"><%-- 15 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="70px" Wrap="false" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Sales Person"><%-- 16 --%>
    <ItemTemplate>
        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 160px">
            <asp:Label ID="salesname" runat="server" Text='<%# Bind("salesname") %>' ToolTip='<%#Bind("salesname")%>'></asp:Label>
        </div>

    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
    <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />
</asp:TemplateField>
        <asp:BoundField DataField="POLCountry" HeaderText="POL Country"><%-- 17 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="PODCountry" HeaderText="POD Country"><%-- 18 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="nodays" HeaderText="No of Days" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <%-- 19 --%>
        <asp:BoundField DataField="quotno" HeaderText="quot #"><%-- 20 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="quotcustomer" HeaderText="Quot # Customer"><%-- 21 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" Wrap="false" />
        </asp:BoundField>
        <%-- 22 --%>
        <asp:BoundField DataField="reversal" HeaderText="Reversal" />
        <%-- 23 --%>
        <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #"><%-- 24 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="70px" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="vendordate" HeaderText="VendorDate"><%-- 25 --%>
            <HeaderStyle Wrap="false" />
            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="70px" Wrap="false" />
        </asp:BoundField>

        <asp:BoundField DataField="GrossAmt" HeaderText="GrossAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <%-- 26 --%>
        <asp:BoundField DataField="TaxAmt" HeaderText="TaxAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <%-- 27 --%>
        <asp:BoundField DataField="TDSAmt" HeaderText="TDSAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
   <%-- 28 --%>
        </Columns>

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <AlternatingRowStyle CssClass="GrdAltRow" />
    <RowStyle Font-Italic="False" Wrap="false" />
    <FooterStyle CssClass="Footer" />

</asp:GridView>


                                <asp:GridView ID="GrdLW" runat="server" AutoGenerateColumns="false" Width="100%" Height="100%" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EnableTheming="False"
                                    CssClass="Grid FixedHeader" OnRowDataBound="GrdLW_RowDataBound" DataKeyNames="bid" PageSize="500" AllowPaging="false"
                                    OnPageIndexChanging="GrdLW_PageIndexChanging">
                                    <%-- --%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Date"><%-- 0 --%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 75px">
                                                    <asp:Label ID="voudate" runat="server" Text='<%# Bind("voudate") %>' ToolTip='<%#Bind("voudate")%>'></asp:Label>
                                                </div>

                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />

                                        </asp:TemplateField>
                                        <asp:BoundField DataField="vouno" HeaderText="Vou #"><%-- 1 --%>
                                            <HeaderStyle Width="50px" Wrap="false" />
                                            <ItemStyle Font-Bold="false" Width="50px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BPJ" HeaderText="BPJ"><%-- 2 --%>
                                            <HeaderStyle Width="100px" Wrap="false" />
                                            <ItemStyle Font-Bold="false" Width="100px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Ledger"><%-- 3 --%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 250px">
                                                    <asp:Label ID="customer" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%#Bind("customer")%>'></asp:Label>
                                                </div>

                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />

                                        </asp:TemplateField>
                                        <asp:BoundField DataField="curr" HeaderText="Curr" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 4 --%>
                                        <asp:BoundField DataField="fcurr" HeaderText="FCurr" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                        <%-- 5 --%>
                                        <asp:BoundField DataField="vamount" HeaderText="Voucher Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 6 --%>
                                        <asp:BoundField DataField="Receivedamount" HeaderText="Received Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 7 --%>
                                        <asp:BoundField DataField="amount" HeaderText="Pending Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 8 --%>
                                        <asp:BoundField DataField="famount" HeaderText="Voucher Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 8 --%>
                                            <HeaderStyle Width="100px" Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="100px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="recefamount" HeaderText="Received Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TxtAlign1" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 9 --%>
                                        <asp:BoundField DataField="foverdue" HeaderText="Pending Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 10 --%>
                                            <HeaderStyle Width="100px" Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="100px" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="trantype" HeaderText="Product#" />
                                        <%-- 10 --%>
                                        <asp:BoundField DataField="mblno" HeaderText="MBL #" />
                                        <%-- 11 --%>
                                        <asp:BoundField DataField="refno" HeaderText="BL #"><%-- 12 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="true" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Shipper" HeaderText="Shipper"><%-- 13 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="70px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Consignee" HeaderText="Consignee"><%-- 14 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="70px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="POLCountry" HeaderText="POL Country"><%-- 15 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PODCountry" HeaderText="POD Country"><%-- 16 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Left" Width="150px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nodays" HeaderText="No of Days" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 17 --%>
                                        <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 18 --%>

                                        <asp:BoundField DataField="shortname" HeaderText="Branch"><%-- 19 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Sales Person"><%-- 20 --%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 160px">
                                                    <asp:Label ID="salesname" runat="server" Text='<%# Bind("salesname") %>' ToolTip='<%#Bind("salesname")%>'></asp:Label>
                                                </div>

                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="160px" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" Wrap="false" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="quotno" HeaderText="Quotation #"><%-- 21 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="quotcustomer" HeaderText="Quot # Customer"><%-- 22 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                        <%-- 23 --%>
                                        <asp:BoundField DataField="reversal" HeaderText="Reversal" />
                                        <%-- 24 --%>
                                        <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #"><%-- 25 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="70px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vendordate" HeaderText="VendorDate"><%-- 26 --%>
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Right" Width="70px" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="GrossAmt" HeaderText="GrossAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <%-- 27 --%>
                                        <asp:BoundField DataField="TaxAmt" HeaderText="TaxAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                       <%-- 28 --%> 
                                        <asp:BoundField DataField="TDSAmt" HeaderText="TDSAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                    <%-- 29 --%>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" Wrap="false" />
                                    <FooterStyle CssClass="Footer" />

                                </asp:GridView>
                                <div class="DivBreak"></div>
                                <asp:GridView ID="grdvou" runat="server" AutoGenerateColumns="true" Width="100%" Height="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found"
                                    EnableTheming="False" class="GridOutStandingN" OnRowDataBound="grdvou_RowDataBound">
                                    <Columns>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" Wrap="false" />
                                    <FooterStyle CssClass="Footer" />

                                </asp:GridView>
                                <div class="DivBreak"></div>
                                <asp:GridView ID="GrdAgeing" runat="server" AutoGenerateColumns="False" DataKeyNames="ledgerid" Width="100%" Height="100%" ShowHeaderWhenEmpty="True"
                                    EnableTheming="False" class="GridOutStandingN" OnRowDataBound="GrdAgeing_RowDataBound" OnRowCommand="GrdAgeing_RowCommand" EmptyDataText="No Records Found">
                                    <Columns>
                                        <asp:ButtonField CommandName="ColumnClick" Visible="false" />
                                        <asp:BoundField DataField="customer" HeaderText="Ledger">

                                            <HeaderStyle HorizontalAlign="left" Width="300px" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Width="300px" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="grt15" HeaderText="<=15" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt1630" HeaderText="16~30" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt3145" HeaderText="31~45" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt4660" HeaderText="46~60" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt6190" HeaderText="61~90" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt91120" HeaderText="91~120" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt121180" HeaderText="121~180" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt181365" HeaderText="181~365" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt366" HeaderText=">=366" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grttot" HeaderText="Total O/S" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="Ledger Balance" HeaderText="Ledger Balance" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Width="150px" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px" Wrap="false" />
                                        </asp:BoundField>

                                        <%--<asp:BoundField DataField="Ledger Op.Bal" HeaderText="Ledger Op.Bal" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Width="250px" Wrap="false" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Rcptcutlastyear" HeaderText="Rcptcutlastyear" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Width="250px" Wrap="false" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="Ledgeropbal-Rcptcutlastyear" HeaderText="Ledgeropbal-Rcptcutlastyear" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Width="250px" Wrap="false" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="outstd. Op.Bal" HeaderText="Outstd.Op.Bal" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Width="250px" Wrap="false" />
                                    </asp:BoundField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                    <FooterStyle CssClass="Footer" />
                                </asp:GridView>
                                <div class="DivBreak"></div>
                                <asp:GridView ID="GrdAgeingsales" runat="server" AutoGenerateColumns="false" Width="100%" Height="100%" ShowHeaderWhenEmpty="True" EnableTheming="False"
                                    class="GridOutStandingN" OnRowDataBound="GrdAgeingsales_RowDataBound" OnRowCommand="GrdAgeingsales_RowCommand" DataKeyNames="ledgerid">
                                    <Columns>
                                        <asp:ButtonField CommandName="ColumnClick" Visible="false" />
                                        <asp:BoundField DataField="customer" HeaderText="SalesPerson" />
                                        <asp:BoundField DataField="grt15" HeaderText="<=15" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt1630" HeaderText="16~30" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt3145" HeaderText="31~45" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt4660" HeaderText="46~60" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt6190" HeaderText="61~90" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt91120" HeaderText="91~120" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt121180" HeaderText="121~180" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt181365" HeaderText="181~365" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grt366" HeaderText=">=366" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="grttot" HeaderText="Total O/S" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="ledgerid" HeaderText="Ledgerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                    <FooterStyle CssClass="Footer" />
                                </asp:GridView>
                                <div class="DivBreak"></div>

                            </asp:Panel>

                        </div>

                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hf_custid" runat="server" />
        <asp:HiddenField ID="hf_custname" runat="server" />

        <asp:HiddenField ID="hdf_id" runat="server" />
        <asp:HiddenField ID="hdf_name" runat="server" />

        <asp:HiddenField ID="hdf_idsales" runat="server" />
        <asp:HiddenField ID="hdf_salename" runat="server" />

        <asp:HiddenField ID="hid_date" runat="server" />
        <asp:HiddenField ID="hdf_grdvou" runat="server" />

        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_date" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>

        <div class="FormGroupContent4">
            <asp:HiddenField ID="hid" runat="server" />
            <asp:Panel ID="pln_Trialbalance" runat="server" class=" modalPopup" Style="display: none;">
                <div class="divRoated">
                    <div class="DivSecPanel">
                        <asp:Image ID="Close_Trialbalance" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                    </div>

                    <div class="">
                        <iframe id="iframecost" runat="server" src="" frameborder="0" class=""></iframe>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <KRI:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance"
            TargetControlID="lbl_hid" BackgroundCssClass="modalBackground" CancelControlID="Close_Trialbalance">
            <Animations>
        <OnShown>
        <FadeIn Duration="1.5" Fps="40" />                
        </OnShown>
            </Animations>
        </KRI:ModalPopupExtender>
        <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />

        <asp:Label ID="lbl_hid" runat="server" />
        <asp:HiddenField ID="hid_groupid" runat="server" />
</asp:Content>
