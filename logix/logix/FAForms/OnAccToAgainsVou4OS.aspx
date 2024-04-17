<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="OnAccToAgainsVou4OS.aspx.cs" Inherits="logix.FAForm.OnAccToAgainsVou4OS" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/OnAccToAgainsVou4OS.css" rel="stylesheet" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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






    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />

    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>



    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>

    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/PaymentFA.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {


            $(document).ready(function () {

                $("#<%=txt_Cust.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Custid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/OnAccToAgainsVou4OS.aspx/GetCustomer",
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
                        $("#<%=txt_Cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_Cust.ClientID %>").change();
                        $("#<%=hid_Custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_Custid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_Cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Custid.ClientID %>").val(i.item.val);
                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_Cust.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_Cust.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                  <%--select: function (event, i) {
                 
                        
                          $("#<%=txt_Cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Custid.ClientID %>").val(i.item.val);
                            $("#<%=txt_Cust.ClientID %>").change();
                        
                  },
                  focus: function (event, i) {
                     
                          
                          $("#<%=txt_Cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Custid.ClientID %>").val(i.item.val);
                        
                    },
                  change: function (event, i) {
                    
                         
                          $("#<%=txt_Cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Custid.ClientID %>").val(i.item.val);
                        
                    },
                  close: function (event, i) {
            
                         
                          $("#<%=txt_Cust.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Custid.ClientID %>").val(i.item.val);
                        
                    },
                  minLength: 1--%>
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }


    </script>
    <style type="text/css">
        .Grid2 {
            border: 1px solid #b1b1b1;
            height: 318px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .Modetxt {
            float: left;
            width: 3.5%;
            margin: 0px 0.5% 0px 0px;
        }


        #logix_CPH_ddl_mode_chzn {
            width: 100% !important;
        }

        .TxtAlign1 {
            text-align: right !important;
        }

        .ModeAcc {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AccDate {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AccRecepit {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AccYear {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherNo {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VouType {
            width: 8%;
            float: left;
            margin: 0px 0% 0px 0px;
        }


        .AccRecpt1 {
            width: 31%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Receipt {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }





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

        /*CSS*/

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

        .AccYear {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
 

        .row {
            height: 570px !important;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 12px;
        }

        .FormGroupContent4 label {
            color: #000080;
            font-size: 12px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }



        
/* FixedHeader1 */

.FixedHeader1 {
  position: relative;
  width: 100%;
  overflow: hidden;
  border-collapse: collapse;
}
.FixedHeader1 thead {
  position: relative;
  display: block;
  width: 100%;
  overflow: visible;
}

.FixedHeader1 tbody {
  position: relative;
  display: block; 
  width: 100%;
  height: 314px;
  overflow: auto;
}

.FixedHeader1 th:nth-child(2) {
  min-width: 275px;
}
.FixedHeader1 td:nth-child(2) { 
  min-width: 275px;
}

.FixedHeader1 th:nth-child(3) {
  min-width: 250px;
}
.FixedHeader1 td:nth-child(3) { 
  min-width: 250px;
}

.FixedHeader1 th:nth-child(4) {
  min-width: 280px;
}
.FixedHeader1 td:nth-child(4) { 
  min-width: 280px;
}

.FixedHeader1 th:nth-child(5) {
  min-width: 150px;
}
.FixedHeader1 td:nth-child(5) { 
  min-width: 150px;
}

.FixedHeader1 th:nth-child(6) {
  min-width: 150px;
}
.FixedHeader1 td:nth-child(6) { 
  min-width: 150px;
}
.widget-content {
    padding-top: 55px !important;
}
.FixedHeader1 th:nth-child(10) {
  min-width: 190px;
}
.FixedHeader1 td:nth-child(10) { 
  min-width: 190px;
}
.gridpnl {
    height: calc(100vh - 235px);
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     
    <div class="">
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="OnAccount To Against Overseas Voucher"></asp:Label>
                    </h4>
                   <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs1" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Utility</a> </li>
            <li><a href="#" title="">OnAccount To Against Overseas Voucher  </a></li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                        </div>


                                        <div class="FixedButtons" >
    <div class="btn-ctrl1">
        <div class="btn ico-update">
            <asp:Button ID="btn_Update" runat="server" ToolTip="Update" OnClick="btn_save_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" />
        </div>


    </div>
</div>


                </div>


                <div class="widget-content">
                     
                    <div class="FormGroupContent4">
                        <div class="Modetxt" style="display: none;">
                            <asp:Label ID="lbl_voucher" runat="server" Text="Mode"></asp:Label>
                        </div>
                        <div class="Receipt">
                            <asp:Label ID="Label1" runat="server" Text="Voucher"> </asp:Label>
                            <asp:DropDownList ID="ddl_receipt" runat="server" CssClass="chzn-select" data-placeholder="Voucher" AutoPostBack="true" OnSelectedIndexChanged="ddl_receipt_SelectedIndexChanged">
                                <asp:ListItem Value="">Voucher</asp:ListItem>
                                <asp:ListItem>OSReceipt</asp:ListItem>
                                <asp:ListItem>OSPayment</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="ModeAcc">

                            <asp:Label ID="Label2" runat="server" Text="Mode"> </asp:Label>
                            <asp:DropDownList ID="ddl_mode" CssClass="chzn-select" data-placeholder="Mode" runat="server" Height="23px" AutoPostBack="True">
                                <%--onselectedindexchanged="ddl_mode_SelectedIndexChanged">--%>
                                <asp:ListItem Value="B">Cheque/DD</asp:ListItem>

                            </asp:DropDownList>

                        </div>
                        <div class="AccYear">
                            <asp:Label ID="Label12" runat="server" Text="Vou Year"></asp:Label>

                            <asp:TextBox ID="txt_VouYear" runat="server" CssClass="form-control" placeholder=" " ToolTip="Vou Year"></asp:TextBox>
                        </div>
                            <div style="display: none;">
                                <asp:Label ID="lbl_receipt" runat="server" Text="Receipt #"></asp:Label>
                            </div>
                        <div class="AccRecepit">
                            <asp:Label ID="Label3" runat="server" Text="Receipt #"> </asp:Label>
                            <asp:TextBox ID="txt_Recno" CssClass="form-control" placeholder="" ToolTip="Receipt #" runat="server" AutoPostBack="True"
                                OnTextChanged="txt_Recno_TextChanged"></asp:TextBox>
                        </div>
                        <div class="AccDate1" style="display: none;">
                            <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>
                        </div>
                        <div class="AccDate">
                            <asp:Label ID="Label4" runat="server" Text="Rec Date"> </asp:Label>
                            <asp:TextBox ID="txt_RecDate" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>


                        <div class="AccCustomer" style="display: none;">
                            <asp:Label ID="lbl_receivedfrom" runat="server" Text="Customer"></asp:Label>
                        </div>
                        <div class="AccRecpt DISNone">
                            <asp:Label ID="lbl_amount" runat="server" Text="Recpt.Amount($)"></asp:Label>
                        </div>
                        <div class="AccRecpt1">
                            <asp:Label ID="Label5" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txt_Cust" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="" ToolTip="Customer" OnTextChanged="txt_Cust_TextChanged"></asp:TextBox>
                        </div>
                        <div class="AccRecpt2">
                            <asp:Label ID="Label6" runat="server" Text="Recpt.Amount($)"> </asp:Label>
                            <asp:TextBox ID="txt_amount" runat="server" ReadOnly="True" Style="text-align: right" placeholder="" ToolTip="Recpt.Amount($)" CssClass="form-control"></asp:TextBox>
                        </div>
                            <div class="hide">
                                <asp:Label ID="lbl_SVouno" runat="server" Text="Vou #"></asp:Label>
                            </div>
                        <div class="VoucherNo">
                            <asp:Label ID="Label7" runat="server" Text="Vou #"> </asp:Label>
                            <asp:TextBox ID="txtsch" runat="server" placeHolder="" AutoPostBack="true" ToolTip="Voucher" CssClass="form-control" TabIndex="29" OnTextChanged="txtsch_TextChanged"></asp:TextBox>

                        </div>
                            <div class="DISNone hide">
                                <asp:Label ID="lbl_SvouType" runat="server" Text="Vou Type"></asp:Label>
                            </div>
                        <div class="VouType">
                            <asp:Label ID="Label8" runat="server" Text="Type"> </asp:Label>
                            <asp:DropDownList ID="cmbvoutype" runat="server" Height="23px" CssClass="chzn-select" data-placeholder="Type" ToolTip="Type" TabIndex="30" AutoPostBack="true" OnSelectedIndexChanged="cmbvoutype_SelectedIndexChanged">
                                <asp:ListItem>Vou Type</asp:ListItem>
                                <asp:ListItem>CN</asp:ListItem>
                                <asp:ListItem>DN</asp:ListItem>
                                <asp:ListItem>OSCN</asp:ListItem>
                                <asp:ListItem>OSDN</asp:ListItem>

                            </asp:DropDownList>

                        </div>
                    </div>
                 
                    <div class="FormGroupContent4" style="display: none;">
                        <asp:Label ID="lbl_VouDtls" runat="server" Text="VoucherDetails"></asp:Label>

                    </div>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="panel_details" runat="server" ScrollBars="auto" CssClass="gridpnl">
                            <asp:GridView ID="Grd_INVRec" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_INVRec_RowDataBound"
                                ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader"  OnRowCommand="Grd_INVRec_RowCommand" OnPreRender="Grd_INVRec_PreRender" >

                                <Columns>
                                    <asp:BoundField DataField="branchid" HeaderText="Branch" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"></asp:BoundField>
                                    <%--0--%>
                                    <asp:BoundField DataField="branch" HeaderText="Branch"><%--1--%>
                                        <ItemStyle Wrap="false" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="invoiceno" HeaderText="Vou #"><%--2--%>
                                        <ItemStyle Wrap="false" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="exrate" HeaderText="ExRate" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1"><%--3--%>
                                        <ItemStyle Wrap="false" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="iamount" HeaderText="Vou-Amount($)" DataFormatString="{0:#,##0.00}" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1"><%--4--%>
                                        <ItemStyle Wrap="false" Width="150px" />
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Recpt-Amount($)"><%--5--%>
                                        <ItemTemplate>

                                            <asp:TextBox ID="txt_receiptamount" runat="server" Text='<%#Bind("ramount") %>' ToolTip='<%#Bind("ramount") %>' Font-Size="10pt" AutoPostBack="true"
                                                Style="text-align: right;" CssClass="form-control" OnTextChanged="txt_receiptamount_TextChanged"></asp:TextBox>

                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="150px" Wrap="false" />
                                        <HeaderStyle Wrap="false" Width="150px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="voutype" HeaderText="VoyType" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--6--%>
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vouno" HeaderText="vouno" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--7--%>
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ravouyear" HeaderText="RAVouYear" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--8--%>
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="curr" HeaderText="Curr"><%--9--%>
                                        <ItemStyle Wrap="false" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="customer" HeaderText="Customer Id" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--10--%>
                                        <%--  <HeaderStyle CssClass="Hide" />
                          <ItemStyle CssClass="Hide" Wrap="false"  />--%>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgrid" HeaderText="ledgrid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--11--%>
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ltype" HeaderText="ledtype" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"><%--12--%>
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" Wrap="false" />
                                    </asp:BoundField>

                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />

                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div class="bordertopNew"></div>
                            <div class="DISNone hide">
                                <asp:Label ID="lbl_CustAmt" runat="server" Text="CustomerAmount($)"></asp:Label>
                            </div>
                    <div class="FormGroupContent4">
                        <div class="CustomerAmountACC">
                            <asp:Label ID="Label11" runat="server" Text="CustomerAmount($)"> </asp:Label>
                            <asp:TextBox ID="txt_CustAmt" runat="server" ReadOnly="True" CssClass="form-control" placeholder="" ToolTip="CustomerAmount($)"></asp:TextBox>

                        </div>
                        <div class="CustomerAmountACC1">
                            <asp:Label ID="Label10" runat="server" CssClass="invisible" Text="GrdVouTotAmt"> </asp:Label>
                            <asp:TextBox ID="txt_GrdVouTotAmt" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                        </div>
                            <div class="DISNone hide">
                                <asp:Label ID="lbl_BankCharges" runat="server" Text="BankCharges"></asp:Label>
                            </div>
                        <div class="BankACC">
                            <asp:Label ID="Label9" runat="server" Text="Bank Charges"> </asp:Label>
                            <asp:TextBox ID="txt_TDSAmt" runat="server" Style="text-align: right" CssClass="form-control" placeholder="" ToolTip="Bank Charges"></asp:TextBox>
                        </div>
                    </div>
              
                  


                </div>
            </div>
        </div>
    </div>





    <asp:HiddenField ID="hid_bln" runat="server" />
    <asp:HiddenField ID="hid_Custid" runat="server" />
    <asp:HiddenField ID="hid_RCustid" runat="server" />
    <asp:HiddenField ID="hid_RCurr" runat="server" />
    <asp:HiddenField ID="hid_oexrate" runat="server" />
    <asp:HiddenField ID="hid_ocurr" runat="server" />
    <asp:HiddenField ID="hid_ovyear" runat="server" />
    <asp:HiddenField ID="hid_ActualAmt" runat="server" />
    <asp:HiddenField ID="hid_gridname" runat="server" />
    <asp:HiddenField ID="hid_custbol" runat="server" />
    <asp:HiddenField ID="hid_custexist" runat="server" />
    <asp:HiddenField ID="hid_int_rid" runat="server" />
    <asp:HiddenField ID="hid_dbl_Amt" runat="server" />
    <asp:HiddenField ID="hid_rptype" runat="server" />
    <asp:HiddenField ID="hid_ledgerid" runat="server" />
    <asp:HiddenField ID="hid_custAmt" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_exrate" runat="server" />
    <asp:HiddenField ID="hid_rpamt" runat="server" />

    <div class="hide">

    <asp:TextBox ID="txtTotalAmt" runat="server" Style="display: none;"></asp:TextBox>
    </div>


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_no" runat="server">Master Group :</label>

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

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>






</asp:Content>
