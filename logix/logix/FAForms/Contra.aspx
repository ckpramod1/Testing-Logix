<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="Contra.aspx.cs" Inherits="logix.FAForm.Contra" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="Stylesheet" href="../Styles/MasterGroup.css" type="text/css" />
<link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
   <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> 
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

    <link href="../CSS/Finance.css" rel="stylesheet" />

    <link href="../Styles/Contra.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).keyup(function (e) {

            if (e.keyCode == 27) {

                $("#<%=btn_cancel.ClientID%>").click();
            }
        });

    </script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            $(document).ready(function () {

                $("#<%=txt_lgrname.ClientID %>").autocomplete({

                    source: function (request, response) {

                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/Getledgername4Contra",
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

                    <%--select: function (e, i) {
                        $("#<%=hf_ldgrid.ClientID %>").val(i.item.val);
                    },--%>
                    select: function (event, i) {
                        $("#<%=txt_lgrname.ClientID %>").val(i.item.label);
                        $("#<%=txt_lgrname.ClientID %>").change();
                        $("#<%=hf_ldgrid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_lgrname.ClientID %>").val(i.item.label);
                        $("#<%=hf_ldgrid.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        <%-- var result = $("#<%=txt_lgrname.ClientID %>").val().toString();
                       var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_lgrname.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_lgrname.ClientID %>").val($.trim(res));
                        }
                        $("#<%=txt_lgrname.ClientID %>").val($.trim(result));--%>

                        var result = $("#<%=txt_lgrname.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_lgrname.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });

            //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            $(document).ready(function () {

                $("#<%= txt_currency.ClientID %>").autocomplete({

                    source: function (request, response) {

                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/Getcurrentyname",
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

                    <%--select: function (e, i) {
                        $("#<%=hf_ldgrid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1--%>

                    select: function (event, i) {
                        $("#<%=txt_currency.ClientID %>").val(i.item.label);
                        $("#<%=txt_currency.ClientID %>").change();
                        $("#<%=hid_curr.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_currency.ClientID %>").val(i.item.label);
                        $("#<%=hid_curr.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        <%--var result = $("#<%=txt_currency.ClientID %>").val().toString();
                       var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_currency.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_currency.ClientID %>").val($.trim(res));
                        }
                        $("#<%=txt_currency.ClientID %>").val($.trim(result));--%>

                        var result = $("#<%=txt_currency.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_currency.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });

            //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .ContraTxt {
            width: 8%;
            float: left;
            margin: 0px;
        }

        .ContraCurency {
            width: 5.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ContraAmount {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .ContraAmount input {
                text-align: right;
            }

        .ContraExrate {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .ContraExrate input {
                text-align: right;
            }

        .ContraType {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CRSelect {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ContraAmount1 {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LedgerNameC {
            width: 49.1%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ContraDate {
            width: 8%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        .Grid2 {
            border: 1px solid #b1b1b1;
            height: 305px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .ChequeNoContra {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ContraFavour {
            width: 89.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        #logix_CPH_ddl_crdr_chzn {
            width: 100% !important;
        }

        #logix_CPH_dd_ltype_chzn {
            width: 100% !important;
        }

        .TotalCinput {
            width: 120px !important;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ContratTotal {
            width: 120px !important;
            float: left;
            margin: 0px 0% 0px 0px;
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
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 87vh;
    overflow-x: hidden;
    overflow-y: auto;
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
        div#logix_CPH_btn_add1 {
      margin: 2px 0px 0px 0px;
}
        .TotalCLbl {
    width: 2%;
    float: left;
    margin: 6px 0.5% 0px 0px;
}

 .btn-ctrl1Tot {
    float: left;
    margin: 0px 0px 0px 625px;
    width: 100%;
}

 .widget.box{
    position: relative;
    top: -8px;
}
 .btn .btn-add1{
     margin:17px 0 0 0;
 }
 div#logix_CPH_ddl_crdr_chzn {
    opacity: 1 !important;
}
 form {  
    width: 100%;   
}
 
 .widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
 .TotalCinput.TextField span,.ContratTotal.TextField {
    text-align: right;
}
 table#logix_CPH_grd_Contra th:nth-child(3) {
    text-align: right;
}
 table#logix_CPH_grd_Contra th:nth-child(4) {
    text-align: right;
}
 table#logix_CPH_grd_Contra th:nth-child(5) {
    text-align: right;
}
 table#logix_CPH_grd_Contra th:nth-child(6) {
    text-align: right;
}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="Server">
       
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box " runat="server">
                <div class="widget-header">
                    <div>
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Contra"></asp:Label>
                    </h4>
                 <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Vouchers</a> </li>
            <li><a href="#" title="">Contra</a> </li>
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
        <div class="btn ico-cheque-print"  id="idprint" runat="server"  >
            <asp:Button ID="btn_chqprint" runat="server" Text="Cheque Print" ToolTip="Cheque Print" OnClick="btn_chqprint_Click" />
        </div>
        <div class="btn ico-save" id="btn_save1" runat="server">
            <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" />
        </div>
        <div class="btn ico-view">
            <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
        </div>
    </div>
</div>

                </div>

                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ContraTxt">

                            <asp:Label ID="lbl_contra" runat="server" Text="Contra #"></asp:Label>
                            <asp:TextBox ID="txt_contra" runat="server" CssClass="form-control" ToolTip="Contra #" placeholder="" AutoPostBack="True" OnTextChanged="txt_contra_TextChanged"></asp:TextBox>
                        </div>
                        <div class="ContraDate DateR">
                            <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CRSelect">

                            <asp:Label ID="lbl_crdr" runat="server" Text="Dr / Cr"></asp:Label>
                            <asp:DropDownList ID="ddl_crdr" runat="server" Height="23" ToolTip="Cr / Dr" placeholder="Dr / Cr" CssClass="chzn-select">
                                <asp:ListItem Value="0">Dr / Crr</asp:ListItem>
                                <asp:ListItem Value="1">Dr</asp:ListItem>
                                <asp:ListItem Value="2">Cr</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LedgerNameC">
                            <asp:Label ID="lbl_lgrname" runat="server" Text="Ledger Name"></asp:Label>
                            <asp:TextBox ID="txt_lgrname" runat="server" CssClass="form-control" ToolTip="Ledger Name" placeholder=""></asp:TextBox>
                        </div>
                        <div class="ContraType">

                            <asp:Label ID="lbl_type" runat="server" Text="Dr/Cr"></asp:Label>
                            <asp:DropDownList ID="dd_ltype" runat="server" Height="23" CssClass="chzn-select" OnSelectedIndexChanged="dd_ltype_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" ToolTip="Type" data-placeholder="Type">
                                <asp:ListItem Value="0">Type</asp:ListItem>
                                <asp:ListItem Value="1">Debit</asp:ListItem>
                                <asp:ListItem Value="2">Credit</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="ContraCurency">

                            <asp:Label ID="lbl_currency" runat="server" Text="Currency"></asp:Label>
                            <asp:TextBox ID="txt_currency" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Currency" placeholder="" OnTextChanged="txt_currency_TextChanged"></asp:TextBox>
                        </div>

                        <div class="ContraAmount">

                            <asp:Label ID="lbl_amt" runat="server" Text="Amount($)"></asp:Label>
                            <asp:TextBox ID="txt_amt" runat="server" AutoPostBack="True" CssClass="form-control" ToolTip="Amount($)" placeholder="" OnTextChanged="txt_amt_TextChanged"></asp:TextBox>
                        </div>
                          <div class="ContraExrate">

                            <asp:Label ID="lbl_exrate" runat="server" Text="Ex.Rate"></asp:Label>
                            <asp:TextBox ID="txt_exrate" runat="server" CssClass="form-control" ToolTip="Ex.Rate" placeholder="" AutoPostBack="True"
                                OnTextChanged="txt_exrate_TextChanged"></asp:TextBox>

                        </div>
                        <div class="ContraAmount1">

                            <asp:Label ID="lbl_amount" runat="server" Text="Amount"></asp:Label>

                            <asp:TextBox ID="txt_amount" runat="server" CssClass="form-control" ToolTip="Amount" placeholder="" Style="text-align: right"></asp:TextBox>

                        </div>

                        <div class="right_btn custom-mt-2">
                            <div class="btn ico-add" id="btn_add1" runat="server">
                                <asp:Button ID="btn_add" runat="server" Text="Add" ToolTip="Add" OnClick="btn_add_Click" />
                            </div>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">

                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel2" runat="server" CssClass="gridpnl" ScrollBars="Auto">
                            <asp:GridView ID="grd_Contra" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid FixedHeader" DataKeyNames="vousubid,opstype,ledgerid"
                                OnRowDataBound="grd_Contra_RowDataBound" OnSelectedIndexChanged="grd_Contra_SelectedIndexChanged" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grd_Contra_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="LedgerType" HeaderText="Type">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px"  />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgername" HeaderText="Ledger Name">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LedgerAmount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right"  Width="120px" />
                                        <HeaderStyle Width="120px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LedgerAmount" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right"  Width="120px" />
                                        <HeaderStyle Width="120px"  />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="fcur" HeaderText="FCurr">
                                        <HeaderStyle Width="120px"  />
                                        <ItemStyle width="120px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="famt" HeaderText="F Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right"  width="150px"  />
                                        <HeaderStyle width="150px"  />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="exrate" HeaderText="Ex.Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Width="120px"  />
                                        <HeaderStyle Width="120px"  />

                                    </asp:BoundField>
                                    <%-- <asp:BoundField DataField="ledgerid" HeaderText="Ledgerid"  ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">                    
                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                </asp:BoundField>
               <asp:TemplateField>
                    <ItemTemplate>                        
                        <asp:LinkButton ID="link_Contra" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                    </ItemTemplate>                    
                    <ItemStyle Width="2%" />
                </asp:TemplateField>--%>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>
                    <div class="FormGroupContent4">
                        <div class="btn-ctrl1Tot">
                            <div class="TotalCLbl hide">
                                <asp:Label ID="lbl_total" runat="server" Text="Total"></asp:Label>
                            </div>
                            <div class="TotalCinput">
                                <asp:Label ID="Label2" runat="server" ToolTip="Dr Amount" Text="Dr Amount"></asp:Label>

                                <asp:TextBox ID="txt_total1" runat="server" CssClass="form-control" Style="text-align: right" ToolTip="Debit Amount" Placeholder=""></asp:TextBox>
                            </div>
                            <div class="ContratTotal">
                                <asp:Label ID="Label3" runat="server" ToolTip="Cr Amount" Text="Cr Amount"></asp:Label>

                                <asp:TextBox ID="txt_total2" runat="server" CssClass="form-control" Style="text-align: right" ToolTip="Credit Amount" Placeholder=""></asp:TextBox>
                            </div>
                        </div>

                    </div>
                        </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="NarrationI">

                            <asp:Label ID="lbl_naration" runat="server" Text="Narration"></asp:Label>
                            <asp:TextBox ID="txt_naration" runat="server" ToolTip="Narration" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ChequeNoContra">

                            <asp:Label ID="lbl_chqno" runat="server" Text="Cheque No"></asp:Label>
                            <asp:TextBox ID="txt_chqno" runat="server" ToolTip="Cheque No" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="ContraFavour">

                            <asp:Label ID="lbl_favour" runat="server" Text="Favour"></asp:Label>
                            <asp:TextBox ID="txt_favour" runat="server" ToolTip="Favour" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                 

                </div>
            </div>
        </div>
    </div>

    <div>
        <asp:HiddenField ID="hf_ldgrid" runat="server" />
        <asp:HiddenField ID="hf_vou_subid" runat="server" />
        <asp:HiddenField ID="hid_curr" runat="server" />
        <br />
        <asp:HiddenField ID="hf_RowId" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" />
        <asp:HiddenField ID="hf_vid" runat="server" />
        <asp:HiddenField ID="hidfdate" runat="server" />
        <asp:HiddenField ID="hf_Date" runat="server" />

        <asp:HiddenField ID="hidvoutype" runat="server" />
        <asp:HiddenField ID="hidtdate" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="Hid_VouID" runat="server" />
        <asp:HiddenField ID="hid_BaseCurr" runat="server" />
    </div>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date"
        Format="dd/MM/yyyy"></asp:CalendarExtender>

    <asp:HiddenField ID="hidId" runat="server" />
    <asp:HiddenField ID="hid_BranchID" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Contra #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
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
