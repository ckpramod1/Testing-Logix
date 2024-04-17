<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="Ledgers.aspx.cs" Inherits="logix.FAForm.Ledgers" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
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

    <link href="../Styles/Ledgers.css" rel="Stylesheet" type="text/css" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {

                $("#<%=txtLedgerName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/Ledgers.aspx/GetLedgername",
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
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=txtLedgerName.ClientID %>").change();
                        $("#<%=hid_Ledgername.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=hid_Ledgername.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txtLedgerName.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtLedgerName.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txtsubgroupname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/Ledgers.aspx/GetSubgroupname",
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
                      <%--select: function (event, i) {
                          $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                      },
                      focus: function (event, i) {
                          $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                      },
                      minLength: 1--%>

                    select: function (event, i) {
                        $("#<%=txtsubgroupname.ClientID %>").val(i.item.label);
                        $("#<%=txtsubgroupname.ClientID %>").change();
                        $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtsubgroupname.ClientID %>").val(i.item.label);
                        $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txtsubgroupname.ClientID %>").val().toString().split[','];
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txtsubgroupname.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txtsubgroupname.ClientID %>").val($.trim(res));
                        }
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_Curr.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetCurrency",
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
                        $("#<%=txt_Curr.ClientID %>").val(i.item.label);
                          $("#<%=txt_Curr.ClientID %>").change();
                          $("#<%=hid_cur.ClientID %>").val(i.item.val);
                      },
                    focus: function (event, i) {
                        $("#<%=txt_Curr.ClientID %>").val(i.item.label);
                          $("#<%=hid_cur.ClientID %>").val(i.item.val);
                      },
                    close: function (e, i) {
                        var result = $("#<%=txt_Curr.ClientID %>").val().toString().split[','];
                          var res = result.substring(0, result.lastIndexOf(' ,'));
                          var out = res.substring(0, res.lastIndexOf(' ,'));
                          if (out != "") {
                              $("#<%=txt_Curr.ClientID %>").val($.trim(out));
                          } else {
                              $("#<%=txt_Curr.ClientID %>").val($.trim(res));
                          }
                      },
                    minLength: 1
                });
            });

          }

    </script>

    <script type="text/javascript">
        function TxtFocus() {

            var el = $("#<%=txtSearch.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }

        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../FAForms/Ledgers.aspx/GetLedgerNameNew",
                data: '{Prefix: "' + $("#<%=txtSearch.ClientID %>").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    //alertify.alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            $("#<%=btn_search.ClientID %>").click();
        }

    </script>
    <script type="text/javascript">
        //Function to disable Cntrl key/right click
        function DisableControlKey(e) {
            // Message to display
            var message = "Copy Paste not  allowed";
            // Condition to check mouse right click / Ctrl key press
            if (e.which == 17 || e.button == 2) {
                alertify.alert(message);
                return false;
            }
        }
    </script>

    <%--<link href="../Styles/Chosenlogin.css" rel="stylesheet" />
   <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>--%>

    <style type="text/css">
        .Grid2 {
            border: 0px solid #b1b1b1;
            height: 220px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .SubGroup {
            width: 16.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Groupname {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Type {
            width: 9%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

             .MinAmount {
    width: 32%;
    float: left;
    margin: 0px 1% 0px 0px;
}

            .MinAmount input {
                text-align: right;
            }

        .MaxAmount input {
            text-align: right;
        }

        #logix_CPH_cmbCostApp {
            width: 100% !important;
        }

        .MaxAmount {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .OpBalance input {
                text-align: right;
            }

        .Drop_minmax {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditCtrl {
            width: 6.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .Balance input {
                text-align: right;
            }

        .LedgerName {
            width: 26.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MasterLedger {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AliasName {
            width: 25.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TDStxt {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_CmbType {
            font-size: 11px;
        }

        #logix_CPH_CmbType_chzn {
            width: 100% !important;
        }

        #logix_CPH_cmbopbal_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddl_Curr_chzn {
            width: 100% !important;
        }

        .row {
            height: 572px !important;
            /*margin: 0px 5px 0px -15px;*/
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        #logix_CPH_cmbLedgerType_chzn {
            width: 100% !important;
        }

        #logix_CPH_cmbCostApp_chzn {
            width: 100% !important;
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

/* FixedHeader */

.widget.box{
    position: relative;
    top: -8px;
}
.box1 {
    float: left;
    width: 27%;
}
.MaxAmount {
    width: 32%;
    float: left;
    margin: 0px 1% 0px 0px;
}
.Drop_minmax {
    width: 32%;
    float: left;
    margin: 0px 0% 0px 0px;
}
.box2 {
    float: left;
    width: 34%;
}
.OpBalance {
    width: 22%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Curr {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

.CreditCtrl {
    width: 22.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}
.box3 {
    float: left;
    width: 39%;
}
.Balance {
    width: 30%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Credit {
    width: 22.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.CostYes {
    width: 25%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Stax {
    width: 33.5%;
    float: left;
    margin: 0px 1% 0px 0px;
}
.PAN {
    width: 22.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.TDStxt {
    width: 17.8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.widget.box {
    width: 50%;
}
.widget-content {
    padding: 0 10px!important;
}
.Cost_center{
   width: 18%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
div#UpdatePanel1 {
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
 
.TDS{
   width: 17.8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.txtOpbal {
    float: left;
    width: 39.5%;
    margin: 0 0.5% 0 0;
}
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}

.widget.box .widget-content {
    top: 0px !important;
    padding-top: 50px !important;
}
.FixedButtonsss {
    position: fixed;
    top: 30px;
    left: 0;
    background: #fff;
    z-index: 10;
    box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
    width: calc(100vw - 649px) !important;
    border-bottom: 0.5px solid #00000010;
    padding: 1px 0 5px 10px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_head" runat="server"></asp:Label>
                    </h4>
                      <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Account Info</a> </li>
            <li><a href="#" title="">Ledgers</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                        </div>

                    <div class="FixedButtons">
     <div class="right_btn">
        <div class="btn ico-save" id="btnsave1" runat="server">
            <asp:Button ID="btnsave" runat="server" Text="Save" ToolTip="Save" OnClick="btnsave_Click" />
        </div>
        <div class="btn ico-view">
            <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" />

        </div>
        <div class="btn ico-delete" id="delid" runat="server"  Visible="false">
            <asp:Button ID="btndelete" runat="server" Text="Delete" ToolTip="Delete" OnClick="btndelete_Click" Visible="false" />

        </div>
        <div class="btn ico-cancel" id="btncancel1" runat="server">
            <asp:Button ID="btncancel" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
        </div>
    </div>
</div>

                </div>

                <div class="widget-content">
                    
                    <div class="FormGroupContent4 custom-d-flex">
                        <div class="custom-col custom-mr-05">

                            <asp:Label ID="lbl_lednam" runat="server" Text="Ledger Name" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txtLedgerName" runat="server" CssClass="form-control" ToolTip="Ledger Name" placeholder=" " OnTextChanged="txtLedgerName_TextChanged"
                                AutoPostBack="True" onKeyDown="return DisableControlKey(event)" onMouseDown="return DisableControlKey(event)"></asp:TextBox>

                        </div>
                        <div class="custom-w-20">

                            <asp:Label ID="lbl_msled" runat="server" Text=" Ledger Type" CssClass="LabelValue"></asp:Label>

                            <asp:DropDownList ID="cmbLedgerType" runat="server" Height="23" ToolTip="Ledger Type" placeholder=" " Width="100%"
                                OnSelectedIndexChanged="cmbLedgerType_SelectedIndexChanged" CssClass="chzn-select" AppendDataBoundItems="True" AutoPostBack="True">
                                <asp:ListItem Value="G">GL - NF</asp:ListItem>
                                <asp:ListItem Value="B">BANK</asp:ListItem>
                                <asp:ListItem Value="C">CASH</asp:ListItem>
                                <asp:ListItem Value="F">GL - F</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                       <div class="FormGroupContent4">

                            <asp:Label ID="lbl_AliasName" runat="server" Text="Alias Name"></asp:Label>

                            <asp:TextBox ID="txt_AliasName" runat="server" ToolTip="Alias Name" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="FormGroupContent4">
                            <asp:Label ID="lbl_sub" runat="server" Text="Sub Group Name" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txtsubgroupname" runat="server" ToolTip="Sub Group Name" AutoPostBack="true" placeholder="  " CssClass="form-control" OnTextChanged="txtsubgroupname_TextChanged"></asp:TextBox>
                        </div>
                    <div class="FormGroupContent4 custom-d-flex">
                        <div class="custom-col custom-mr-05">

                            <asp:Label ID="lbl_grpnam" runat="server" Text="Group Name" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtGroupname" runat="server" Enabled="false" ToolTip="Group Name" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="custom-w-20">

                            <asp:Label ID="lbl_type" runat="server" Text="Type" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtgroupetype" runat="server" Enabled="false" ToolTip="Type" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 custom-d-flex">

                        <div class="custom-col custom-mr-05">

                            <asp:Label ID="lbl_min" runat="server" Text="Min. Amt" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtMinAmt" runat="server" ToolTip="Min. Amt" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="custom-col custom-mr-05">

                            <asp:Label ID="Label1" runat="server" Text="Max. Amt" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtMaxAmt" runat="server" ToolTip="Max. Amt" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="custom-w-20">
                            <asp:Label ID="Label5" runat="server" Text="Dr / Cr" CssClass="LabelValue"></asp:Label>
                            <asp:DropDownList ID="cmbminmaxamt" runat="server" Height="23" CssClass="chzn-select" Width="100%">
                                <asp:ListItem Value="0">Dr / Cr</asp:ListItem>
                                <asp:ListItem Value="C">Credit</asp:ListItem>
                                <asp:ListItem Value="D">Debit</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        </div>

                    <div class="FormGroupContent4">

                    <div class="FormGroupContent4 custom-d-flex">

                        <div class="txtOpbal">

                            <asp:Label ID="lbl_op" runat="server" Text="Op. Balance" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtOpbal" runat="server" ToolTip="Op. Balance" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                          <div class="Curr">

                            <asp:Label ID="lbl_Curr" runat="server" Text="Curr" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txt_Curr" runat="server" ToolTip="Curr" placeholder="" CssClass="form-control" OnTextChanged="txt_Curr_TextChanged"></asp:TextBox>
                        </div>
                        <div class="custom-col custom-mr-05">

                            <asp:Label ID="lbl_OpBalance" runat="server" Text=" Op.Balance" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txt_OpBalUSD" runat="server" ToolTip="Op.Balance FCurr" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="custom-w-20">
                            <asp:Label ID="Label3" runat="server" Text=" Dr / Cr" CssClass="LabelValue"></asp:Label>
                            <asp:DropDownList ID="cmbopbal" runat="server" Height="23" CssClass="chzn-select" Width="100%" OnSelectedIndexChanged="cmbopbal_SelectedIndexChanged1" AutoPostBack="True">
                                <asp:ListItem Value="0">Dr / Cr</asp:ListItem>
                                <asp:ListItem Value="C">Credit</asp:ListItem>
                                <asp:ListItem Value="D">Debit</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="Credit hide">
                            <asp:Label ID="Label2" runat="server" Text=" Dr / Cr" CssClass="LabelValue"></asp:Label>
                            <asp:DropDownList ID="ddl_Curr" runat="server" Height="23" Width="100%" CssClass="chzn-select" AutoPostBack="True" ToolTip="Currency" OnSelectedIndexChanged="ddl_Curr_SelectedIndexChanged">
                                <asp:ListItem Value="0">Dr / Cr</asp:ListItem>
                                <asp:ListItem Value="C">Credit</asp:ListItem>
                                <asp:ListItem Value="D">Debit</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        </div>

                    <div class="FormGroupContent4 custom-d-flex">

                        <div class="Cost_center">

                            <asp:Label ID="lbl_cost" runat="server" Text="Cost Center App." CssClass="LabelValue"></asp:Label>

                            <asp:DropDownList ID="cmbCostApp" runat="server" Height="23" CssClass="chzn-select" ToolTip="Cost Center App." placeholder="Cost Center App." AutoPostBack="true" Width="100px" OnSelectedIndexChanged="cmbCostApp_SelectedIndexChanged">
                                <asp:ListItem Value=" "> </asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="TDS">

                            <asp:Label ID="lbl_tds" runat="server" Text="TDS Type" CssClass="LabelValue"></asp:Label>

                            <asp:DropDownList ID="CmbType" Height="23" runat="server" ToolTip="TDS Type" CssClass="chzn-select">
                                <asp:ListItem Value=" "> </asp:ListItem>
                                <asp:ListItem Value="C">Company</asp:ListItem>
                                <asp:ListItem Value="I">Individual</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                         <div class="custom-col custom-mr-05 ">
                            <asp:Label ID="lbl_pan" runat="server" Text="PAN #" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txtPanno" runat="server" ToolTip="PAN #" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="custom-col">

                            <asp:Label ID="lbl_stxt" runat="server" Text="GST #" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txtSerTaxno" runat="server" ToolTip="GST Number" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                         

                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label8" runat="server" Text="Search" CssClass="LabelValue"></asp:Label>
                        <asp:TextBox ID="txtSearch" runat="server" ToolTip="Search" AutoPostBack="true" onkeyup="GetDetail()" placeholder="" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />

                    <div class="FormGroupContent4">
                        <div>

                            <asp:Panel ID="pnl_lg" runat="server"  CssClass="gridpnl" >
                                <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" ForeColor="Black" DataKeyNames="cid" Width="100%" ViewStateMode="Enabled" CssClass="Grid FixedHeader"
                                    ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grd_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="cname" HeaderText="Ledger Name">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cid" HeaderText="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="type" HeaderText="Type" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chk_Grd" runat="server" /><%--Checked="True"--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>
                    </div>
                        </div>
                <%--    <div class="FormGroupContent4">
                        <asp:CheckBox ID="CheckBox1" Text="From" runat="server" Visible="false" />
                        <asp:DropDownList ID="DropDownList1" runat="server" Visible="false" OnSelectedIndexChanged="cmbpvybal_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Value="0">Type</asp:ListItem>
                            <asp:ListItem Value="A">Credit</asp:ListItem>
                            <asp:ListItem Value="B">Debit</asp:ListItem>
                        </asp:DropDownList>

                    </div>--%>

                    <div>
                        <asp:CheckBox ID="chkfrom" Text="From" runat="server" Visible="false" />
                    </div>
                    <div>
                        <asp:DropDownList ID="cmbpvybal" runat="server" Visible="false" OnSelectedIndexChanged="cmbpvybal_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Value="0">Type</asp:ListItem>
                            <asp:ListItem Value="A">Credit</asp:ListItem>
                            <asp:ListItem Value="B">Debit</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div>
                        <asp:HiddenField ID="txtpybl" runat="server" />
                        <asp:HiddenField ID="hid_SubGroupid" runat="server" />
                        <asp:HiddenField ID="hid_Ledgername" runat="server" />
                        <asp:HiddenField ID="hid_cur" runat="server" />
                        <asp:HiddenField ID="hid_GroupID" runat="server" />
                    </div>
                </div>

            </div>

        </div>

    </div>
        </div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: block;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Ledger #</label>

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

    <%--</div>--%>
</asp:Content>
