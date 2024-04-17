<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="ProfomaJournal.aspx.cs" Inherits="logix.FAForm.ProfomaJournal" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="Stylesheet" href="../Styles/MasterGroup.css" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
     <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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

    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/profomaJournal.css" rel="stylesheet" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {

                $("#<%=txtldgrname.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_ldgrid.ClientID %>").val(0);
                          $.ajax({
                              //url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetLikeLedgerName",

                              url: "../FAForms/ProfomaJournal.aspx/GetLedgerName_Journal",

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
                          $("#<%=txtldgrname.ClientID %>").val(i.item.label);//
                          $("#<%=txtldgrname.ClientID %>").change();
                          $("#<%=hf_ldgrid.ClientID %>").val(i.item.val);
                      },
                    focus: function (event, i) {
                        $("#<%=txtldgrname.ClientID %>").val(i.item.label);
                          $("#<%=hf_ldgrid.ClientID %>").val(i.item.val);
                      },
                    close: function (event, i) {
                        var result = $("#<%=txtldgrname.ClientID %>").val().toString().split(',')[0];
                          $("#<%=txtldgrname.ClientID %>").val($.trim(result));
                      },
                    minLength: 1

                });
            })
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
          }

    </script>

    <style type="text/css">

        .ContraExrate, 
        .ContraAmount, 
        .JournalAmount {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        /*.JournalDate {
    float: right;
    width: 7%;
    margin: 0px 0.5% 0px 0px;
}*/
        .JournalDate {
            float: left;
            width: 7%;
            margin: 0px 0.5% 0px 0px;
        }
        /*.Grid2 {
    border: 1px solid #b1b1b1;
    height: 266px;
    margin: 0;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}*/
        .Grid2 {
            border: 1px solid #b1b1b1;
            height: 317px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .JournalTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JournalCR {
            float: left;
            width: 7%;
            margin: 0px 0.5% 0px 0px;
        }

        .JournalType {
            float: left;
            width: 6.5%;
            margin: 0px 0.5% 0px 0px;
        }
        div#logix_CPH_btn_add1 {
       float: left;
    margin: 7px 0px 0px 0px;
}

        .ContraCurency {
    width: 4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
       

        .row {
            clear: both;
            width: 100%;
            height: 580px !important;
            overflow-x: hidden;
            overflow-y: auto;
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
  
.TotalJInput {
    float: right;
    width: 118px;
    margin: 0px 0.5% 0px 0px;
}
.TotalJInput1 {
    float: right;
    width: 118px;
    margin: 0px 8px 0px 0px;
}
.TotalJLBL {
    float: right;
    width: 2%;
    margin: 5px 0.5% 0px 0px;
}
.widget.box{
    position: relative;
    top: -8px;
}
div#logix_CPH_ce_voudate_container {
    right: 0px;
}
.JouJobNo {
    float: left;
    width: 8%;
    margin: 0px 0.5% 0px 0px;

}
.JouReference {
    float: left;
    width: 12%;
    margin: 0px 0% 0px 0px;
}
.JournalType {
    float: left;
    width: 10.5%;
    margin: 0px 0.5% 0px 0px;
}
.JournalLedger {
    float: left;
    width: 47.9%;
    margin: 0px 0.5% 0px 0px;
}
.gridpnl {
    height: calc(100vh - 339px);
}
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 50px !important;
}
div#UpdatePanel1 {
    height: 87vh;
    overflow-x: hidden;
    overflow-y: auto;
}
.btn {
    padding: 0;
    overflow: hidden !important;
    height: auto;
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
                        <asp:Label ID="lblheader" runat="server" Text=" Profoma Journal"></asp:Label>
                    </h4>
                   <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Vouchers</a> </li>
            <li><a href="#" title="">Proforma Journal</a> </li>
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
         <div class="btn ico-save" id="btn_save1" runat="server">
             <asp:Button ID="btnsave" runat="server"  ToolTip="Save" OnClick="btnsave_Click" />
         </div>
         <div class="btn ico-view">
             <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" />
         </div>
         <div class="btn ico-delete">
             <asp:Button ID="btndel" runat="server" Text="Delete" ToolTip="Delete" OnClick="btndel_Click" />
         </div>
         <div class="btn ico-cancel" id="btn_cancel1" runat="server">
             <asp:Button ID="btncancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
         </div>
     </div>
 </div>

                </div>

                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">
                           <div class="JournalTxt">

                            <asp:Label ID="lbljnlno" runat="server" Text="Journal #"></asp:Label>

                            <asp:TextBox ID="txtjnlno" runat="server" ToolTip="Journal #" placeholder="" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtjnlno_TextChanged" TabIndex="1"> </asp:TextBox>
                        </div>
                      
                        <div class="JournalDate">
                            <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtdate_TextChanged" TabIndex="2"></asp:TextBox>

                        </div>
                        <div class="JouJobNo">
                            <asp:Label ID="Label2" runat="server" Text="Job #"></asp:Label>
                            <asp:TextBox ID="txtjobno" runat="server" TabIndex="3" ToolTip="Job.No" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="JouReference">
                            <asp:Label ID="lblref" runat="server" Text="Reference #"></asp:Label>
                            <asp:TextBox ID="txtref" runat="server" TabIndex="4" ToolTip="Reference No" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                       <div class="JournalCR">
                            <asp:Label ID="lbl_CrrDb" runat="server" Text="Dr / Cr"></asp:Label>
                            <asp:DropDownList ID="ddl_CrrDb" Height="23"  runat="server" CssClass="chzn-select form-control" TabIndex="5" Placeholder="" ToolTip="Cr/Db">
                                <asp:ListItem Value="0">Dr / Cr</asp:ListItem>
                                <asp:ListItem Value="1">Dr</asp:ListItem>
                                <asp:ListItem Value="2">Cr</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="JournalLedger">
                            <asp:Label ID="lblldgrname" runat="server" Text="Ledger Name"></asp:Label>

                            <asp:TextBox ID="txtldgrname" runat="server" TabIndex="6" CssClass="form-control" ToolTip="Ledger Name" placeholder="" AutoPostBack="true" OnTextChanged="txtldgrname_TextChanged"></asp:TextBox>

                        </div>

                        <div class="JournalType">
                            <asp:Label ID="lbltype" runat="server" Text="Dr / Cr"></asp:Label>

                            <asp:DropDownList ID="ddl_type" runat="server" CssClass="chzn-select" Height="23" Placeholder="Dr / Cr" ToolTip="Dr / Cr" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="7" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged">
                                <asp:ListItem Value="0">Dr / Cr</asp:ListItem>
                                <asp:ListItem Value="1">Debit</asp:ListItem>
                                <asp:ListItem Value="2">Credit</asp:ListItem>
                            </asp:DropDownList>

                        </div>

                        <%--NewOne--%>
                          <div style="display: none;">
                                <asp:Label ID="lbl_currency" runat="server" Text="Curr"></asp:Label>
                            </div>
                        <div class="ContraCurency">                        
                              <asp:Label ID="Label7" runat="server" Text="Curr"></asp:Label>  
                            
                            <asp:TextBox ID="txt_currency" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Currency" placeholder="" OnTextChanged="txt_currency_TextChanged" TabIndex="8"></asp:TextBox>
                        </div>
                        <div style="display: none;">
                                <asp:Label ID="lbl_amt" runat="server" Text="Amount($)"></asp:Label>
                            </div>
                        <div class="ContraAmount">
                            
                            <asp:Label ID="Label8" runat="server" Text="Amount($)"></asp:Label>  
                            <asp:TextBox ID="txt_amt" runat="server" AutoPostBack="True" CssClass="form-control" ToolTip="Amount($)" placeholder="" OnTextChanged="txt_amt_TextChanged" TabIndex="9"></asp:TextBox>
                        </div>
                          <div style="display: none;">
                                <asp:Label ID="lbl_exrate" runat="server" Text="Ex.Rate"></asp:Label>
                            </div>
                        <div class="ContraExrate">                          
                              <asp:Label ID="Label9" runat="server" Text="Ex.Rate"></asp:Label>  
                            <asp:TextBox ID="txt_exrate" runat="server" CssClass="form-control" ToolTip="Ex.Rate" placeholder="" AutoPostBack="True" TabIndex="10"
                                OnTextChanged="txt_exrate_TextChanged"></asp:TextBox>

                        </div>

                        <div class="JournalAmount">
                            <asp:Label ID="lblamount" runat="server" Text="Amount"></asp:Label>
                            <asp:TextBox ID="txtamount" runat="server" ToolTip="Amount" placeholder="" CssClass="form-control" TabIndex="11" Style="text-align: right"></asp:TextBox>
                        </div>

                            <div class="btn ico-add" id="btn_add1" runat="server">
                                <asp:Button ID="btnadd" runat="server" Text="Add" ToolTip="Add" OnClick="btnadd_Click" />
                            </div>

                    </div>

                    <div class="FormGroupContent4">
                        <%--  <div class="JournalCR">
              <div style="display:none;"> <asp:Label ID="lbl_CrrDb"  runat="server" Text="Cr/Db"></asp:Label></div>
            <asp:DropDownList ID="ddl_CrrDb" Height="23" width="74px" runat="server" CssClass="chzn-select" TabIndex="2" Placeholder="Cr/Db" ToolTip="Cr/Db">
            <asp:ListItem Value="0">Cr/Db</asp:ListItem>
            <asp:ListItem Value="1">Dr</asp:ListItem>
             <asp:ListItem Value="2">Cr</asp:ListItem>
        </asp:DropDownList>

           </div>
           <div class="JournalLedger">
               <div style="display:none;"><asp:Label ID="lblldgrname" runat="server" Text="Ledger Name"></asp:Label></div>

                <asp:TextBox ID="txtldgrname" runat="server" TabIndex="3"  CssClass="form-control" ToolTip="Ledger Name" placeholder="Ledger Name" AutoPostBack="true"  OnTextChanged="txtldgrname_TextChanged"></asp:TextBox>

           </div>
           <div class="JournalType">
               <div style="display:none;"><asp:Label ID="lbltype" runat="server" Text="Type"></asp:Label></div>

                <asp:DropDownList ID="ddl_type" runat="server" CssClass="chzn-select" Height="23" Placeholder="Type" ToolTip="Type"  AutoPostBack="true" AppendDataBoundItems="true" TabIndex="4" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged">
            <asp:ListItem Value="0">Type</asp:ListItem>
            <asp:ListItem Value="1">Debit</asp:ListItem>
            <asp:ListItem Value="2">Credit</asp:ListItem>
        </asp:DropDownList>

           </div>
           <div class="JournalAmount">
               <div style="display:none;"><asp:Label ID="lblamount" runat="server" Text="Amount"></asp:Label></div>
                <asp:TextBox ID="txtamount" runat="server"  ToolTip="Amount" placeholder="Amount" CssClass="form-control" TabIndex="5" Style="text-align:right"></asp:TextBox>--%>

                        <%--</div>--%>
                    </div>
                    <div class="FormGroupContent4 boxmodal">

                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel2" runat="server"  ScrollBars="Auto">
                            <asp:GridView ID="grd_journal" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanged="grd_journal_SelectedIndexChanged"
                                DataKeyNames="vousubid,opstype,ledgerid" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                                OnRowDataBound="grd_journal_RowDataBound" OnPreRender="grd_journal_PreRender" >
                                <Columns>
                                    <asp:BoundField DataField="ledgertype" HeaderText="Type">
                                        <HeaderStyle Width="100px"  />
                                        <ItemStyle Width="100px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgername" HeaderText="Ledger">
                                        <HeaderStyle   CssClass="LedgerWidth" />
                                        <ItemStyle   CssClass="LedgerWidth" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fcur" HeaderText="FCurr">
                                         <HeaderStyle Width="120px"  />
                                        <ItemStyle Width="120px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="famt" HeaderText="FCAmount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                          <HeaderStyle Width="150px"  />
                                        <ItemStyle HorizontalAlign="Right" Width="150px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="exrate" HeaderText="Ex.Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                       <HeaderStyle Width="120px"  />
                                         <ItemStyle HorizontalAlign="Right" Width="120px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="120px"  />
                                        <ItemStyle HorizontalAlign="Right" Width="120px"  />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ledgeramount" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                         <HeaderStyle Width="120px"  />
                                        <ItemStyle HorizontalAlign="Right"  Width="120px"  />
                                    </asp:BoundField>

                                    <%--  <asp:BoundField DataField="vousubid" HeaderText="Vousubid" />
                <asp:BoundField DataField="opstype" HeaderText="Opstype" />
                <asp:BoundField DataField="ledgerid" HeaderText="Ledgerid" />
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
                        <div class="TotalJInput1">
                            <asp:Label ID="Label3" runat="server" CssClass="hide" Text="Credit Amount"> </asp:Label>
                            <asp:TextBox ID="txtCrAmnt" runat="server" CssClass="form-control" TabIndex="12" Placeholder="" ToolTip="Credit Amount" Style="text-align: right"></asp:TextBox>
                        </div>

                        <div class="TotalJInput">
                            <asp:Label ID="Label5" runat="server" CssClass="hide" Text="Debit Amount"> </asp:Label>
                            <asp:TextBox ID="txtDbtAmnt" runat="server" CssClass="form-control" TabIndex="13" Placeholder="" ToolTip="Debit Amount" Style="text-align: right"></asp:TextBox>

                        </div>

                        <div class="TotalJLBL hide">
                            <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>

                        </div>

                    </div>
                   </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="TotalNarr">

                            <asp:Label ID="lblnarration" runat="server" Text="Narration"></asp:Label>
                            <asp:TextBox ID="txtnarration" runat="server" ToolTip="Narration" placeholder="" CssClass="form-control" TabIndex="14"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="lbl_name" runat="server" Text="Name" CssClass="hide"></asp:Label>

                      
                    </div>

                    <div class="FormGroupContent4">
                        <div class="MonthTxt1">
                            <asp:TextBox ID="txtmonth" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="YearTxt1">
                            <asp:TextBox ID="txtvouyear" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="Datetxt1">
                            <asp:TextBox ID="ttdate" runat="server" Visible="False"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hf_Date" runat="server" />
    <asp:HiddenField ID="hf_ldgrid" runat="server" />
    <asp:HiddenField ID="txtmont" runat="server" />
    <asp:HiddenField ID="hidId" runat="server" Value="" />
    <asp:CalendarExtender ID="ce_voudate" runat="server" TargetControlID="txtdate" Format="dd/MM/yyyy"></asp:CalendarExtender>

    <asp:HiddenField ID="hid_Vouid" runat="server" />
    <asp:HiddenField ID="hid_Vouyear" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_BaseCurr" runat="server" />        <%--NewOne--%>
    <asp:HiddenField ID="hid_curr" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Profoma Journal #</label>

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
