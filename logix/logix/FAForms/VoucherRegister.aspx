<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="VoucherRegister.aspx.cs"
    Inherits="logix.FAForm.VoucherRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->
    <link href="../CSS/Finance.css" rel="stylesheet" />
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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {
                $("#<%=txt_charge.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_chargeid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/VoucherRegister.aspx/GetCharge_FA",
                            data: "{ 'prefix': '" + request.term + "','ChkTypeAdminPA':'" + $("#<%=ddlSelect.ClientID%>").val() + "','ChkTypeAdminDN':'" + $("#<%=ddlSelect.ClientID%>").val() + "'}",
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
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=txt_charge.ClientID %>").change();
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txt_saccode.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/VoucherRegister.aspx/GetSACCode",
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
                    select: function (e, i) {
                        $("#<%=txt_saccode.ClientID %>").change();
                     },
                     change: function (e, i) {
                         $("#<%=txt_saccode.ClientID %>").val($.trim(result));
                     },
                     focus: function (e, i) {
                         $("#<%=txt_saccode.ClientID %>").val($.trim(result));
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_saccode.ClientID %>").val().toString();
                        $("#<%=txt_saccode.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
    

        .div_txtFrom {
            float: left;
            width: 7%;
            margin-top: 0.5%;
            margin-left: 1%;
            margin:0px 0.5% 0px 0px !important;
        }

        .div_txtTo {
            float: left;
            width: 7%;
            margin-top: 0.5%;
            margin-left: 1%;
            margin:0px 0px 0px 0px !important;

        }

        .TblGrid  FixedHeaderNew1 {
            width: 2050px;
            height: 250px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        .div_txt_saccode {
            float: left;
            width: 6%;
           
            margin: 0px 0.5% 0 0;
        }

            .div_txt_saccode input, Text {
                width: 100%;
            }

        .div_ddlselect {
            float: left;
            width: 8.5%;
          
            margin:0px 0.5% 0px 0px !important;
        }

        .div_ddlselectR {
            float: left;
            width: 19%;
            /*margin-top: 0.5%;
            margin-left: 1%;*/
            margin:0px 0.5% 0px 0px !important;

        }


        div_lblTo {
            float: left;
            width: 2%;
            margin-top: 0.5%;
            margin-left: 0.5%;
        }

        .div_lblfrom {
            float: left;
            width: 3%;
            margin-top: 0.5%;
            margin-left: 0.5%;
        }



        .div_ddlselectGst {
            float: left;
            width: 7%;
            margin-top: 0.5%;
            margin-left: 1%;
            margin:0px 0.5% 0px 0px !important;
        }

        #logix_CPH_ddl_GST_chzn {
            width: 100% !important;
        }

        .row {
            height: 585px !important;
            /* margin: 0px 5px 0px -15px; */
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .Consolidated {
            width: 7%;
            float: left;
            margin: 12px 0% 0px 0.5%;
        }

        .div_txtCharge {
            float: left;
            width: 24%;
            margin-top: 0.5%;
            margin-left: 1%;
            margin:0px 0.5% 0px 0px !important;
        }

        .TxtAlignLeft {
            text-align: left !important;
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

        
        .chzn-drop {
            height: 418px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .div_ddlselect {
            float: left;
            width: 20%;
              margin: 0.5% 0.5% 0 0;
        }
          .MT15{
            margin:15px 0px 0px 0px;
           }


         .FormGroupContent4 label {
            font-size: 11px;
        }

 
        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
    

.div_grd{
    border: 1px solid #b1b1b1 !important;
}

         .div_txtCharge.TextField {
    margin: 0.5% 0.5% 0 0;
}
.div_txtFrom.TextField {
    margin: 0.5% 0.5% 0 0;
}

.bordertopNew {
    margin: 0 0 5px 0 !important;
}
 

 .gridpnl {
    overflow: auto;
    margin: 8px 0;
}
 .widget.box .widget-content {
    top: 55px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <!-- Breadcrumbs line -->
    <div class="crumbs" style="display: none;">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="" id="lblHead" runat="server"></a></li>
            <li><a href="#" title="">Register</a> </li>
            <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Voucher Register</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
    <!-- /Breadcrumbs line -->
        
    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server" style="position: relative; top: -8px;">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Voucher Register"></asp:Label></h4>
                <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs1" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Reports</a> </li>
            <li><a href="#" title="">Registers</a> </li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                                     <div  class="FixedButtons" >
                        <div class="right_btn">
    <div class="btn ico-get">
        <asp:Button ID="btn_print" Text="Get" runat="server"    ToolTip="Get" OnClick="btn_print_Click" />
    </div>
    <div class="btn ico-excel">
        <asp:Button ID="btn_Export" runat="server" Text="Export To Excel" ToolTip="Export To Excel" OnClick="btn_Export_Click" />
    </div>
    <div class=" btn ico-cancel" id="btn_cancel1" runat="server">
        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
    </div>
</div>
                 </div>


                </div>
                <div class="widget-content">


                  


                    <div class="FormGroupContent4" style="display: none;">
                        <div class="VoucherLbl">
                            <asp:Label ID="lbl_branch" runat="server" Text="Branch"></asp:Label>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="div_ddlselect">
                            <asp:Label ID="Label1" runat="server" Text="Branch"> </asp:Label>
                            <asp:DropDownList ID="ddl_branch" Height="23" runat="server" CssClass="chzn-select" placeholder="Branch" ToolTip="Branch" AppendDataBoundItems="true">
                                <asp:ListItem Value="0" Text=""> All</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="div_ddlselectR">
                            <asp:Label ID="Label2" runat="server" Text="Register"> </asp:Label>
                            <asp:DropDownList ID="ddlSelect" runat="server" Height="23" Data-placeholder="Register" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlSelect_SelectedIndexChanged" ToolTip="Resister">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="div_ddlselectGst hide">
                            <asp:Label ID="Label3" runat="server" Text="GST"> </asp:Label>
                            <asp:DropDownList ID="ddl_GST" Height="23" runat="server" CssClass="chzn-select" placeholder="GST" ToolTip="GST" AppendDataBoundItems="true">
                                <asp:ListItem Value="0" Text=""> GST</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="div_txtCharge hide">
                            <asp:Label ID="Label4" runat="server" Text="Charge"> </asp:Label>
                            <asp:TextBox ID="txt_charge" runat="server" placeholder="" ToolTip="Charge" AutoPostBack="true" CssClass="form-control" OnTextChanged="txt_charge_TextChanged"></asp:TextBox>
                        </div>
                        <div class="div_txt_saccode hide">
                            <asp:Label ID="Label5" runat="server" Text="SAC Code"> </asp:Label>
                            <asp:TextBox ID="txt_saccode" runat="server" placeholder=" " ToolTip="SAC Code" AutoPostBack="true" CssClass="form-control" OnTextChanged="txt_saccode_TextChanged" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="div_txtFrom">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="ce_From" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_From" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <div class="div_txtTo">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="ce_To" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_To" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                     

                        <div class="Consolidated ">
                            <asp:CheckBox ID="chkConsolidate" runat="server" Text="Consolidate" CssClass="LabelValue" Visible="false" />
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                 
                    <div class="gridpnl MB0">
                        <asp:GridView CssClass="Grid  FixedHeader" ID="Grd_Invoice" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_Invoice_RowDataBound" OnPreRender="Grd_Invoice_PreRender">
                            <Columns>
                                <asp:BoundField DataField="invoiceno" HeaderText="Inv #"   HeaderStyle-Width="110px" ItemStyle-Width="110px" />
                                <asp:BoundField DataField="invoicedate" HeaderText="Date"  HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:TemplateField HeaderText="BL #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 145px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("blno") %>' ToolTip='<%# Bind("blno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="150px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                                <asp:BoundField DataField="approvedon" HeaderText="Approved By" HeaderStyle-Width="200px" ItemStyle-Width="200px" />
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                       
                        <asp:GridView CssClass="Grid FixedHeader" ID="GrdInterBranch" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found" OnRowDataBound="GrdInterBranch_RowDataBound" OnPreRender="GrdInterBranch_PreRender">

                            <Columns>
                                <asp:BoundField DataField="vouno" HeaderText="Vou #" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:BoundField DataField="voudate" HeaderText="Date"  HeaderStyle-Width="80px" ItemStyle-Width="80px"/>
                                <asp:BoundField DataField="voutype" HeaderText="Voutype" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("trantype") %>' ToolTip='<%# Bind("trantype") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Job #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 95px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("jobno") %>' ToolTip='<%# Bind("jobno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bl #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("blno") %>' ToolTip='<%# Bind("blno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                          

                        <asp:GridView CssClass="Grid  FixedHeader" ID="GrdDebitNote" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="GrdDebitNote_RowDataBound" OnPreRender="GrdDebitNote_PreRender">
                            <Columns>
                                <asp:BoundField DataField="dnno" HeaderText="Vou #" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("dndate") %>' ToolTip='<%# Bind("dndate") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ref #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("refno") %>' ToolTip='<%# Bind("refno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                                <asp:TemplateField HeaderText="Approved Date">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("approvedon") %>' ToolTip='<%# Bind("approvedon") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdCreditNote" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdCreditNote_RowDataBound" OnPreRender="grdCreditNote_PreRender">
                            <Columns>
                                <asp:BoundField DataField="cnno" HeaderText="Vou #" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:BoundField DataField="cndate" HeaderText="Date" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:TemplateField HeaderText="Ref #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("refno") %>' ToolTip='<%# Bind("refno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="120px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                                <asp:TemplateField HeaderText="Approved Date">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("approvedon") %>' ToolTip='<%# Bind("approvedon") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView CssClass="Grid   FixedHeader " ID="grdCreditNoteOp" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdCreditNoteOp_RowDataBound" OnPreRender="grdCreditNoteOp_PreRender" >
                            <Columns>
                                <asp:BoundField DataField="invoiceno" HeaderText="PI #" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:BoundField DataField="invoicedate" HeaderText="Date" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                <asp:TemplateField HeaderText="Job #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("jobno") %>' ToolTip='<%# Bind("jobno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="100px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BL #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("blno") %>' ToolTip='<%# Bind("blno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="180px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 250px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px"></asp:BoundField>
                                <asp:TemplateField HeaderText="Approved Date">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("approvedon") %>' ToolTip='<%# Bind("approvedon") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdtSTChargewise" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True"  OnPreRender="grdtSTChargewise_PreRender">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="Charges">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("chargename") %>' ToolTip='<%# Bind("chargename") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>   
                        <asp:BoundField DataField="chargetot" HeaderText="Charges Amount"  DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"   />
                    <asp:BoundField DataField="chargest" HeaderText="ST Amount"  DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"  />
                  <asp:BoundField DataField="Total" HeaderText="Total"  DataFormatString="{0:n}"  ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"  />
                                --%>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdDebiteNote" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdDebiteNote_RowDataBound" OnPreRender="grdDebiteNote_PreRender">
                            <Columns>
                                <asp:BoundField DataField="dnno" HeaderText="DN #" />
                                <asp:TemplateField HeaderText="DN Date">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("dndate") %>' ToolTip='<%# Bind("dndate") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 280px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="280px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="curr" HeaderText="Curr" />
                                <asp:BoundField DataField="amount" HeaderText=" Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="Grid_creditNote" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_creditNote_RowDataBound" OnPreRender="Grid_creditNote_PreRender">
                            <Columns>
                                <asp:BoundField DataField="cnno" HeaderText="CN #" />
                                <asp:BoundField DataField="cndate" HeaderText="CN Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="curr" HeaderText="Curr" />
                                <asp:BoundField DataField="amount" HeaderText=" Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdOtherDebitNote" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdOtherDebitNote_RowDataBound" OnPreRender="grdOtherDebitNote_PreRender">
                            <Columns>
                                <asp:BoundField DataField="dnno" HeaderText="Inv #" />
                                <asp:BoundField DataField="dndate" HeaderText="Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="blno" HeaderText="BL #"></asp:BoundField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                <asp:TemplateField HeaderText="Approved By">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("approvedon") %>' ToolTip='<%# Bind("approvedon") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="GrdOtherCrediteNoteOpEr" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="GrdOtherCrediteNoteOpEr_RowDataBound" OnPreRender="GrdOtherCrediteNoteOpEr_PreRender">
                            <Columns>
                                <asp:BoundField DataField="cnno" HeaderText="PA #" />
                                <asp:BoundField DataField="cndate" HeaderText="Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="blno" HeaderText="BL #"></asp:BoundField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                <asp:TemplateField HeaderText="Approved By">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("approvedon") %>' ToolTip='<%# Bind("approvedon") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="GrdServiceTaxInvoice" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="GrdServiceTaxInvoice_RowDataBound" OnPreRender="GrdServiceTaxInvoice_PreRender">
                            <Columns>
                                <asp:BoundField DataField="invoiceno" HeaderText="Inv #" />
                                <asp:BoundField DataField="invoicedate" HeaderText="Inv Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="billtype" HeaderText="Bill Type" />
                                <asp:BoundField DataField="nontaxamt" HeaderText="Non-Tax Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="taxamt" HeaderText="STaxable Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="stamt" HeaderText="Tax Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="amount" HeaderText="Total" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdServicesTacCnOps" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdServicesTacCnOps_RowDataBound" OnPreRender="grdServicesTacCnOps_PreRender">
                            <Columns>
                                <asp:BoundField DataField="pano" HeaderText="CN OPs #" />
                                <asp:BoundField DataField="padate" HeaderText="CN Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bill Type">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("billtype") %>' ToolTip='<%# Bind("billtype") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nontaxamt" HeaderText="Non-Tax Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="taxamt" HeaderText="STaxable Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="stamt" HeaderText="Tax Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="amount" HeaderText="Total" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdReceiptBankReg" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdReceiptBankReg_RowDataBound" OnPreRender="grdReceiptBankReg_PreRender">
                            <Columns>
                                <asp:BoundField DataField="receiptno" HeaderText="Receipt #" />
                                <asp:BoundField DataField="receiptdate" HeaderText="Date" />
                                <asp:TemplateField HeaderText="Received From">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cheque #/Date">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("chequedate") %>' ToolTip='<%# Bind("chequedate") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank/Branch">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("branch") %>' ToolTip='<%# Bind("branch") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="receiptamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdReceiptCashReg" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdReceiptCashReg_RowDataBound" OnPreRender="grdReceiptCashReg_PreRender">
                            <Columns>
                                <asp:BoundField DataField="receiptno" HeaderText="Receipt #" />
                                <asp:BoundField DataField="receiptdate" HeaderText="Date" />
                                <asp:TemplateField HeaderText="Received From">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="receiptamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdTds" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdTds_RowDataBound" OnPreRender="grdTds_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="Party Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="cstamount" HeaderText="PA Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="tdsamount" HeaderText="TDS Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="amount" HeaderText="NET Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdTdsType" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdTdsType_RowDataBound" OnPreRender="grdTdsType_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="TDS Type">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("tdsdesc") %>' ToolTip='<%# Bind("tdsdesc") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="cstamount" HeaderText="PA Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="tdsamount" HeaderText="TDS Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="amount" HeaderText="NET Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="GrdPayForBank" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="GrdPayForBank_RowDataBound" OnPreRender="GrdPayForBank_PreRender">
                            <Columns>
                                <asp:BoundField DataField="paymentno" HeaderText="Payment #" />
                                <asp:BoundField DataField="paymentdate" HeaderText="Payment date" />
                                <asp:TemplateField HeaderText="Payment To">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("fvrname") %>' ToolTip='<%# Bind("fvrname") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank/Branch">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("branch") %>' ToolTip='<%# Bind("branch") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="chequedate" HeaderText="Cheque Date" />
                                <asp:BoundField DataField="paymentamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdPaymentCashNew" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdPaymentCashNew_RowDataBound" OnPreRender="grdPaymentCashNew_PreRender">
                            <Columns>
                                <asp:BoundField DataField="paymentno" HeaderText="Payment #" />
                                <asp:BoundField DataField="paymentdate" HeaderText="Payment date" />
                                <asp:TemplateField HeaderText="Payment To">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="paymentamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="fatransfer" HeaderText="Tally Transfered" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender">
                            <Columns>
                                <asp:BoundField DataField="vouno" HeaderText="Voucher #" />
                                <asp:BoundField DataField="voudate" HeaderText="Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("branchname") %>' ToolTip='<%# Bind("branchname") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="stamt" HeaderText="St.Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdProformaInv" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdProformaInv_RowDataBound" OnPreRender="grdProformaInv_PreRender">
                            <Columns>
                                <asp:BoundField DataField="branch" HeaderText="Branch" Visible="false">
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle Width="120px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="refno" HeaderText="Proforma Inv #">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="invoicedate" HeaderText="Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="BL #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("blno") %>' ToolTip='<%# Bind("blno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <%-- <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">--%>
                                        <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        <%-- </div>--%>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="275px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" DataFormatString="{0:n}" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="invoiceno" HeaderText="ActualInv #">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="approvedon" HeaderText="Date" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdPerformaOsDN" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdPerformaOsDN_RowDataBound" OnPreRender="grdPerformaOsDN_PreRender">
                            <Columns>
                                <asp:BoundField DataField="branch" HeaderText="Branch" Visible="false">
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle Width="120px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="refno" HeaderText="Proforma OSSI #">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="invoicedate" HeaderText="Date" />
                                <asp:BoundField DataField="invoiceno" HeaderText="Tax Vou #">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="approvedon" HeaderText="Date" />

                                <asp:BoundField DataField="trantype" HeaderText="Product" />
                                <asp:TemplateField HeaderText="Job #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("jobno") %>' ToolTip='<%# Bind("jobno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" DataFormatString="{0:n}" HeaderText="FCAmount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="localamount" HeaderText="Local Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grdOsCNNew" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grdOsCNNew_RowDataBound" OnPreRender="grdOsCNNew_PreRender">
                            <Columns>
                                <asp:BoundField DataField="branch" HeaderText="Branch" Visible="false">
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle Width="120px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="refno" HeaderText="Proforma OSPI #">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="invoicedate" HeaderText="Date" />

                                <asp:BoundField DataField="invoiceno" HeaderText="Tax Vou #" />
                                <asp:BoundField DataField="approvedon" HeaderText="Date" />
                                <asp:TemplateField HeaderText="Job #">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("jobno") %>' ToolTip='<%# Bind("jobno") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="trantype" HeaderText="Product" />

                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                              <%--  <asp:BoundField DataField="curr" HeaderText="Curr" />--%>
                                <asp:BoundField DataField="amount" HeaderText="FCAmount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="localamount" HeaderText="Local Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <%-- Karthika_K --%>
                        <asp:GridView ID="Grd_ServiceTaxPA" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="Grd_ServiceTaxPA_PreRender">
                            <Columns>
                                <asp:BoundField DataField="pano" HeaderText="CN-Ops #" />
                                <asp:BoundField DataField="padate" HeaderText="CN Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                                <asp:BoundField DataField="nontaxamt" HeaderText="Non-Tax Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="taxamt" HeaderText="Taxable Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="stamt" HeaderText="Tax Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView ID="Grd_StCharge" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="Grd_StCharge_PreRender">
                            <Columns>
                                <asp:BoundField DataField="trantype" HeaderText="Product" />
                                <asp:BoundField DataField="customertype" HeaderText="Customer Type" />
                                <asp:BoundField DataField="chargename" HeaderText="Charges" />
                                <asp:BoundField DataField="Charge Amount" HeaderText="Charge Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="ST Amount" HeaderText="ST Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView ID="Grd_AdminPA" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="Grd_AdminPA_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Voucher #" HeaderText="Voucher #" />
                                <asp:BoundField DataField="voudate" HeaderText="Voucher Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="document" HeaderText="Document" />
                                <asp:BoundField DataField="billtype" HeaderText="Bill Type" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView ID="Grd_AdminDN" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="Grd_AdminDN_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Voucher #" HeaderText="Voucher #" />
                                <asp:BoundField DataField="voudate" HeaderText="Voucher Date" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="document" HeaderText="Document" />
                                <asp:BoundField DataField="billtype" HeaderText="Bill Type" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView ID="Grd_OnAccountReceipt" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="Grd_OnAccountReceipt_PreRender">
                            <Columns>
                                <asp:BoundField DataField="receiptno" HeaderText="Receipt #" />
                                <asp:BoundField DataField="receiptdate" HeaderText="Receipt Date" />
                                <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                                <asp:BoundField DataField="chequeno" HeaderText="Cheque #" />
                                <asp:BoundField DataField="chequedate" HeaderText="Cheque Date" />
                                <asp:BoundField DataField="bankname" HeaderText="Bank Name" />
                                <asp:BoundField DataField="tamount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView ID="Grd_OnAccountPayment" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="Grd_OnAccountPayment_PreRender">
                            <Columns>
                                <asp:BoundField DataField="paymentno" HeaderText="Payment #" />
                                <asp:BoundField DataField="paymentdate" HeaderText="Payment Date" />
                                <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                                <asp:BoundField DataField="chequeno" HeaderText="Cheque #" />
                                <asp:BoundField DataField="chequedate" HeaderText="Cheque Date" />
                                <asp:BoundField DataField="bankname" HeaderText="Bank Name" />
                                <asp:BoundField DataField="tamount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView ID="GrdReceivable" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="GrdReceivable_PreRender">
                            <Columns>
                                <asp:BoundField DataField="shortname" HeaderText="Location" />
                                <asp:BoundField DataField="section" HeaderText="Section" />
                                <asp:BoundField DataField="voutypename" HeaderText="Vou.Type" />
                                <asp:BoundField DataField="vouno" HeaderText="Vou. #" />
                                <asp:BoundField DataField="voudate" HeaderText="Date" />
                                <asp:BoundField DataField="customername" HeaderText="Customer" />


                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="tdsamt" HeaderText="TDS Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView ID="GrdPayable" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                            Visible="false" OnPreRender="GrdPayable_PreRender">
                            <Columns>
                                <asp:BoundField DataField="shortname" HeaderText="Location" />
                                <asp:BoundField DataField="voutypename" HeaderText="Vou.Type" />
                                <asp:BoundField DataField="vouno" HeaderText="Vou. #" />
                                <asp:BoundField DataField="section" HeaderText="Section" />

                                <asp:BoundField DataField="customername" HeaderText="Customer" />


                                <asp:BoundField DataField="panno" HeaderText="Pan #" />
                                <asp:BoundField DataField="voudate" HeaderText="Date" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="tdsamt" HeaderText="TDS Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <%-- Arun --%>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grd_SerViceTax" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grd_SerViceTax_RowDataBound" OnPreRender="grd_SerViceTax_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="SI#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="30px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="30px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="vouno" HeaderText="Vou #">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="voudate" HeaderText="Vou Date">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="225px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="stamt" HeaderText="STamt" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="voutype" HeaderText="Voutype">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="jobtype" HeaderText="Jobtype">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="trantype" HeaderText="Trantype">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="taxamt" HeaderText="Taxamt" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="vendorrefno" HeaderText="Vendorref #">
                                    <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="tds_VoucherWise" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="tds_VoucherWise_RowDataBound" OnPreRender="tds_VoucherWise_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="SI#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="20px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="20px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Branch" HeaderText="Branch">

                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="voutype" HeaderText="Voucher Type">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vouno" HeaderText="Voucher #">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="voudate" HeaderText="Voucher Date">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Party Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("partyname") %>' ToolTip='<%# Bind("partyname") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="225px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="vouamt" HeaderText="Voucher Amount (Before Gst)" DataFormatString="{0:n}">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="gstamt" HeaderText="Gst" DataFormatString="{0:n}">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="grossamt" HeaderText="Gross Amount on TDS Calculated" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="taxRate" HeaderText="Rate at which TDS Deducted">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tdsamount" HeaderText="TDS" DataFormatString="{0:n}">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="panno" HeaderText="Pan #">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tdssection" HeaderText="Section">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="curr" HeaderText="Source Curr" DataFormatString="{0:n}">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="amount" HeaderText="Source Amount" DataFormatString="{0:n}">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" CssClass="TxtAlign1" />
                                </asp:BoundField>

                                <%--<asp:BoundField DataField="surcharge" HeaderText="SurCharge" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="cess" HeaderText="CESS" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="deducteecode" HeaderText="Deductee Code" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />--%>

                                <%--<asp:BoundField DataField="tdstype" HeaderText="Deductee Code" > 
                                   <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>--%>
                            </Columns>


                            <%-- <Columns>
                                 <asp:TemplateField HeaderText="SI#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="20px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="20px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="shortname" HeaderText="Branch" />
                                 <asp:BoundField DataField="vouno" HeaderText="Vou #" />
                                 <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="tdssection" HeaderText="Section" />  
                                 <asp:TemplateField HeaderText="Party Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="225px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="panno" HeaderText="Pan #" />
                                     <asp:BoundField DataField="voudate" HeaderText="Date" /> 
                               
                                 <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />                  
                                 <asp:BoundField DataField="tdsamount" HeaderText="Income Tax"  DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"/>
                                 <asp:BoundField DataField="taxRate" HeaderText="Tax Rate" />
                                <%--<asp:BoundField DataField="tdstype" HeaderText="Deductee Code" > 
                                   <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>--%>








                            <%--</Columns>--%>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grd_TdsSummary" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnPreRender="grd_TdsSummary_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="SI#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="20px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="20px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="shortname" HeaderText="Branch" />
                                <asp:BoundField DataField="panno" HeaderText="Pan #" />
                                <asp:BoundField DataField="tdstype" HeaderText="Deductee Code" />
                                <asp:BoundField DataField="tdssection" HeaderText="Section" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />

                                <asp:BoundField DataField="voudate" HeaderText="Amount Paid" />
                                <asp:TemplateField HeaderText="Party Name">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="225px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="tdsamount" HeaderText="Income Tax" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="taxRate" HeaderText="Tax Rate" />

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grd_TdsVouchall" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grd_TdsVouchall_RowDataBound" OnPreRender="grd_TdsVouchall_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="SI#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="20px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="20px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="shortname" HeaderText="Branch" />
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <%--<div style="overflow: hidden; text-overflow: ellipsis; width: 225px">--%>
                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        <%-- </div>--%>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="325px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="325px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="panno" HeaderText="Pan #" />
                                <asp:BoundField DataField="tdstype" HeaderText="Deductee Code" />
                                <asp:BoundField DataField="tdssection" HeaderText="Section" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="voudate" HeaderText="Amount Paid" />
                                <asp:BoundField DataField="taxRate" HeaderText="Tax Rate">
                                    <HeaderStyle />
                                    <ItemStyle CssClass="TxtAlign1" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tdsamount" HeaderText="Income Tax" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="stamt" HeaderText="ST Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grd_internalBilling" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grd_internalBilling_RowDataBound" OnPreRender="grd_internalBilling_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="SI#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="20px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="20px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="vouno" HeaderText="Vou #" />
                                <asp:BoundField DataField="voudate" HeaderText="Date" />
                                <asp:BoundField DataField="voutype" HeaderText="Vou Type" />
                                <asp:BoundField DataField="trantype" HeaderText="Product" />
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="blno" HeaderText="BL #" />
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" Width="225px" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="stamount" HeaderText="Charge Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grd_DncnJobClosing" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grd_DncnJobClosing_RowDataBound" OnPreRender="grd_DncnJobClosing_PreRender">
                            <Columns>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:Panel ID="pnl_tdsAll" runat="server" CssClass="Grid  FixedHeaderNew1" Visible="false" Style="float: left; width: 100%; overflow-x: auto;">
                            <asp:GridView CssClass="TblGrid  FixedHeader" ID="grd_TdsAll" runat="server" AutoGenerateColumns="true" Width="100%" ForeColor="Black"
                                ShowHeader="false" OnRowDataBound="grd_TdsAll_RowDataBound" OnRowCreated="grd_TdsAll_RowCreated" OnPreRender="grd_TdsAll_PreRender">
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="Grid_Receipt" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_Receipt_RowDataBound" OnPreRender="Grid_Receipt_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="30px" />
                                    <HeaderStyle Wrap="false" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="chequeno" HeaderText="Chequeno #" />
                                <asp:BoundField DataField="chequedate" HeaderText="Date" />
                                <asp:BoundField DataField="clearedon" HeaderText="Cleared On" />
                                <asp:BoundField DataField="bankname" HeaderText="Bankname" />
                                <asp:BoundField DataField="customername" HeaderText="Customer" />
                                <asp:BoundField DataField="receiptamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="Grid_payment" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_payment_RowDataBound" OnPreRender="Grid_payment_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="30px" />
                                    <HeaderStyle Wrap="false" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="chequeno" HeaderText="Chequeno #" />
                                <asp:BoundField DataField="chequedate" HeaderText="Date" />
                                <asp:BoundField DataField="clearedon" HeaderText="Cleared On" />
                                <asp:BoundField DataField="bankname" HeaderText="Bankname" />
                                <asp:BoundField DataField="customername" HeaderText="Customer" />
                                <asp:BoundField DataField="paymentamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="Grid_Osreceipt" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_Osreceipt_RowDataBound" OnPreRender="Grid_Osreceipt_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="30px" />
                                    <HeaderStyle Wrap="false" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="chequeno" HeaderText="Chequeno #" />
                                <asp:BoundField DataField="chequedate" HeaderText="Date" />
                                <asp:BoundField DataField="clearedon" HeaderText="Cleared On" />
                                <asp:BoundField DataField="bankname" HeaderText="Bankname" />
                                <asp:BoundField DataField="customername" HeaderText="Customer" />
                                <asp:BoundField DataField="receiptamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="Grid_ospayment" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_ospayment_RowDataBound" OnPreRender="Grid_ospayment_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="30px" />
                                    <HeaderStyle Wrap="false" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="chequeno" HeaderText="Chequeno #" />
                                <asp:BoundField DataField="chequedate" HeaderText="Date" />
                                <asp:BoundField DataField="clearedon" HeaderText="Cleared On" />
                                <asp:BoundField DataField="bankname" HeaderText="Bankname" />
                                <asp:BoundField DataField="customername" HeaderText="Customer" />
                                <asp:BoundField DataField="paymentamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="Grid_chequebounce" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_chequebounce_RowDataBound" OnPreRender="Grid_chequebounce_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="30px" />
                                    <HeaderStyle Wrap="false" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="receiptno" HeaderText="Receipt#" />
                                <asp:BoundField DataField="receiptdate" HeaderText="Receiptdate" />
                                <asp:BoundField DataField="vouyear" HeaderText="Vouyear" />
                                <asp:BoundField DataField="customername" HeaderText="Customer" />
                                <asp:BoundField DataField="receiptamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="chequeno" HeaderText="cheque#" />
                                <asp:BoundField DataField="chequedate" HeaderText="Cleared On" />
                                <asp:BoundField DataField="naration" HeaderText="Remarks" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grid_paymentcancel" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grid_paymentcancel_RowDataBound" OnPreRender="grid_paymentcancel_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="30px" />
                                    <HeaderStyle Wrap="false" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="paymentno" HeaderText="Pay#" />
                                <asp:BoundField DataField="paymentdate" HeaderText="Paydate" />
                                <asp:BoundField DataField="vouyear" HeaderText="Vouyear" />
                                <asp:BoundField DataField="customername" HeaderText="Customer" />
                                <asp:BoundField DataField="paymentamount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="chequeno" HeaderText="cheque#" />
                                <asp:BoundField DataField="chequedate" HeaderText="Chequedate" />
                                <asp:BoundField DataField="naration" HeaderText="Remarks" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="grid_contra" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="grid_contra_RowDataBound" OnPreRender="grid_contra_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="S #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="30px" />
                                    <HeaderStyle Wrap="false" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Chequeno" HeaderText="Cheque#" />
                                <asp:BoundField DataField="voudate" HeaderText="Voudate" />
                                <asp:BoundField DataField="clearedon" HeaderText="clearedon" />
                                <asp:BoundField DataField="bankname" HeaderText="Bank" />
                                <asp:BoundField DataField="ptc" HeaderText="Customer" />
                                <asp:BoundField DataField="ledgeramount" HeaderText="Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>

                        <asp:GridView CssClass="Grid  FixedHeader" ID="GrdVouReceipt" runat="server" AutoGenerateColumns="True" Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnPreRender="GrdVouReceipt_PreRender">
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        <asp:GridView CssClass="Grid  FixedHeader" ID="GrdVouPayment" runat="server" AutoGenerateColumns="True" Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True">
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>



                        <div class="div_Break"></div>


                        <div class="STCHGrid">

                            <asp:GridView CssClass="Grid  FixedHeader" ID="grd_pending" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                ShowHeaderWhenEmpty="True" OnRowDataBound="grd_pending_RowDataBound" OnPreRender="grd_pending_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="branch" HeaderText="Branch" Visible="false">
                                        <HeaderStyle Width="120px" />
                                        <ItemStyle Width="120px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="refno" HeaderText="Proforma Inv #">
                                        <HeaderStyle Width="110px" />
                                        <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="trantype" HeaderText="Product">
                                        <HeaderStyle Width="190px" />
                                        <ItemStyle Width="190px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="invoicedate" HeaderText="Date">
                                        <HeaderStyle Width="110px" />
                                        <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle Width="110px" />
                                        <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="BL #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("blno") %>' ToolTip='<%# Bind("blno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer Name">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 335px">
                                                <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="amount" DataFormatString="{0:n}" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                    <%--<asp:BoundField DataField="invoiceno" HeaderText="ActualInv #" />    
                      <asp:BoundField DataField="approvedon" HeaderText="Date" /> --%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>

                        <div class="div_Break"></div>

                        <div class="STCHGrid">

                            <asp:GridView CssClass="Grid  FixedHeader" ID="grd_pend" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                ShowHeaderWhenEmpty="True" OnRowDataBound="grd_pending_RowDataBound" OnPreRender="grd_pend_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="branch" HeaderText="Branch" Visible="false">
                                        <HeaderStyle Width="180px" />
                                        <ItemStyle Width="180px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="refno" HeaderText="Proforma Inv #">
                                        <HeaderStyle Width="180px" />
                                        <ItemStyle Width="180px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="trantype" HeaderText="Product">
                                        <HeaderStyle Width="180px" />
                                        <ItemStyle Width="180px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="invoicedate" HeaderText="Date">
                                        <HeaderStyle Width="180px" />
                                        <ItemStyle Width="180px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle Width="260px" />
                                        <ItemStyle Width="260px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Customer Name">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 404px">
                                                <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="404px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="amount" DataFormatString="{0:n}" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />


                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>
                        <div class="div_Break"></div>
                        <div class="STCHGrid">
                            <asp:GridView CssClass="Grid  FixedHeader" ID="grdprofomaAdminDNCN" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                ShowHeaderWhenEmpty="True" OnRowDataBound="grdprofomaAdminDNCN_RowDataBound" OnPreRender="grdprofomaAdminDNCN_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="branch" HeaderText="Branch" Visible="false">
                                        <HeaderStyle Width="125px" />
                                        <ItemStyle Width="125px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="refno" HeaderText="Proforma DN #">
                                        <HeaderStyle Width="110px" />
                                        <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>

                                    <%-- <asp:BoundField DataField="trantype" HeaderText="Product"  >
                                <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>--%>

                                    <asp:BoundField DataField="invoicedate" HeaderText="Date">
                                        <HeaderStyle Width="110px" />
                                        <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>

                                    <%-- <asp:BoundField DataField="invoiceno" HeaderText="Tax Vou #">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                </asp:BoundField>--%>


                                    <%-- <asp:BoundField DataField="trantype" HeaderText="Product" />--%>
                                    <asp:TemplateField HeaderText="Job #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("jobno") %>' ToolTip='<%# Bind("jobno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer Name">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                                <asp:Label ID="tdsdesc" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="225px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="amount" DataFormatString="{0:n}" HeaderText="FCAmount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />
                                    <%-- <asp:BoundField DataField="localamount" HeaderText="Local Amount" DataFormatString="{0:n}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />--%>
                                    <asp:BoundField DataField="invoiceno" HeaderText="Proforma DN #">
                                        <HeaderStyle Width="110px" />
                                        <ItemStyle Width="110px" CssClass="TxtAlignLeft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="approvedon" HeaderText="Date" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>

                        <div class="div_Break"></div>













                        <asp:GridView ID="Grid_xl" Visible="false" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnRowDataBound="Grid_xl_RowDataBound" Width="100%" OnPreRender="Grid_xl_PreRender" >
                            <Columns>
                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                <asp:BoundField DataField="Voucher" HeaderText="Voucher" />
                                <asp:BoundField DataField="jobno" HeaderText="Job No" />

                                <asp:BoundField DataField="voucherno" HeaderText="Voucher Number" />
                                <asp:BoundField DataField="voucherdate" HeaderText="Voucher Date" />
                                <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                                <asp:BoundField DataField="vouchervalue" HeaderText="Voucher Value" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="TaxableValue" HeaderText="Taxable Value" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="TaxValue" HeaderText="Non Taxable" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="cgst" HeaderText="CGST" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="sgst" HeaderText="S/UGST" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="igst" HeaderText="IGST" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="taxtotal" HeaderText="Tax Total" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="total" HeaderText="Grand Total" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="Product" HeaderText="Product" />
                                <asp:BoundField DataField="placeofsupply" HeaderText="Place Of Supply" />
                                <asp:BoundField DataField="gstno" HeaderText="GST No" />
                                <asp:BoundField DataField="vouchertype" HeaderText="Voucher Type" />





                                <asp:BoundField DataField="chargename" HeaderText="Charge Head" />
                                <asp:BoundField DataField="saccode" HeaderText="SAC" />
                                <asp:BoundField DataField="rcm" HeaderText="RCM (Y/N)" />

                                <asp:BoundField DataField="reversal" HeaderText="Reversal" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #" />
                                <asp:BoundField DataField="vendorrefdate" HeaderText="Vendor Ref Date" />
                                <asp:BoundField DataField="blno" HeaderText="BL #" />

                                <asp:BoundField DataField="mblno" HeaderText="MBL #" />
                                <%-- <asp:BoundField DataField="curr" HeaderText="Curr" />

                                        <asp:BoundField DataField="famount" HeaderText="FCAmt" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1"   />
                                        <asp:BoundField DataField="exrate" HeaderText="Ex-Rate" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1"  />--%>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" Wrap="false" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle Wrap="false" />
                        </asp:GridView>
                        <asp:GridView ID="Grid_xl_head" Visible="false" runat="server" CssClass="Grid  FixedHeader" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnRowDataBound="Grid_xl_head_RowDataBound" Width="100%" OnPreRender="Grid_xl_head_PreRender">
                            <%-- PageSize="500" AllowPaging="false" OnPageIndexChanging="Grid_xl_head_PageIndexChanging"--%>
                            <Columns>
                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                <asp:BoundField DataField="Voucher" HeaderText="Voucher" />
                                <asp:BoundField DataField="jobno" HeaderText="Job No" />

                                <asp:BoundField DataField="voucherno" HeaderText="Voucher #" />
                                <asp:BoundField DataField="voucherdate" HeaderText="Voucher Date" />
                                <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                                <asp:BoundField DataField="vouchervalue" HeaderText="Voucher Value" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="TaxableValue" HeaderText="Taxable Value" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="NonTaxableValue" HeaderText="Non Taxable" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="cgst" HeaderText="CGST" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="sgst" HeaderText="S/UGST" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="igst" HeaderText="IGST" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="taxtotal" HeaderText="Tax Total" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="total" HeaderText="Grand Total" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="Product" HeaderText="Product" />



                                <asp:BoundField DataField="placeofsupply" HeaderText="Place Of Supply" />
                                <asp:BoundField DataField="gstno" HeaderText="GST No" />
                                <%--<asp:BoundField DataField="chargename" HeaderText="Charge Head" />--%>
                                <%--<asp:BoundField DataField="saccode" HeaderText="SAC" />--%>
                                <asp:BoundField DataField="vouchertype" HeaderText="Voucher Type" />
                                <asp:BoundField DataField="rcm" HeaderText="RCM (Y/N)" />

                                <asp:BoundField DataField="reversal" HeaderText="Reversal" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="vendorrefno" HeaderText="Vendor Ref #" />
                                <asp:BoundField DataField="vendorrefdate" HeaderText="Vendor Ref Date" />
                                <asp:BoundField DataField="curr" HeaderText="Curr" />

                                <asp:BoundField DataField="famount" HeaderText="FCAmt" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="exrate" HeaderText="Ex-Rate" DataFormatString="{0:###0.00}" ItemStyle-CssClass="TxtAlign1" />
                                <asp:BoundField DataField="blno" HeaderText="BL #" />

                                <asp:BoundField DataField="mblno" HeaderText="MBL #" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" Wrap="false" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <RowStyle Wrap="false" />
                        </asp:GridView>
                    </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_chargeid" runat="server" />



    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Register #</label>

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


    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
