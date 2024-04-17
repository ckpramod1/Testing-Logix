<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomerBank.aspx.cs" Inherits="logix.Maintenance.MasterCustomerBank" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Styles/slotRateMaster.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
    <link href="../Styles/MRG.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
    <!--=== JavaScript ===-->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>
    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>
    <!-- General -->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>
    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>
    <!-- Globalize -->
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>
    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/ContainerTracking.css" rel="stylesheet" />
    <script src="../js/helper.js" type="text/javascript"></script>
    <script src="../js/TextField.js" type="text/javascript"></script>
    <%--TEST--%>
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />


    <script type="text/javascript" src="../js/helper.js"></script>

    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>


    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {

            $("#<%=txtbankid.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "MasterCustomernew.aspx/GetBankNameDetails",
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
                    $("#<%=txtbankid.ClientID %>").val(i.item.label);
                    $("#<%=txtbankid.ClientID %>").change();
                },
                focus: function (event, i) {
                    $("#<%=txtbankid.ClientID %>").val(i.item.label);
                    $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                },
                close: function (event, i) {
                    $("#<%=txtbankid.ClientID %>").val(i.item.label);
                    $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>



    <%--   <script type="text/javascript">
         $(function () {
             $("Grd_MAsterCredit. > tbody > tr:not(:has(table, th))")
                 .css("cursor", "pointer")
                 .click(function (e) {
                     $(".Grd_MAsterCredit td").removeClass("highlite");
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


    </script>--%>
    <style>
        .Bank_name_input, .IFSC_code_input, .Account_number_input {
            float: left;
            width: 100%;
        }

        .Account_type_input {
            width: 98%;
        }

        .panel_19 {
            width: 99%;
            margin-left: 7px !important;
        }

        .right_btn {
            display: flex;
        }

        .CardLbl {
            padding: 6px 0px 0px 10px;
            margin: 0px 0.5% 0px 0px;
        }

        div#logix_CPH_plblan {
            margin: 6px 0px 0px 11px;
        }
        span#logix_CPH_Label59, span.headingName {
    font-weight: bold !important;
}
        .CardLbl.customerName {
    float: left;
}
        .PageHeight{
            padding-top:0px !important;
        }
        span#logix_CPH_Label59 {
    font-size: 20px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">



    <div class="FormGroupContent4">
        <div class="CardLbl">
            <asp:Label ID="Label59" runat="server">Bank Details </asp:Label>

        </div>
        <div class="CardLbl customerName">
            <span class="headingName">CUSTOMER NAME</span>
            <asp:Label ID="lblcustomername" runat="server"> </asp:Label>
        </div>
        <div class="panno12" id="plblan" runat="server">
            <span class="headingName">PAN#   :</span>
            <asp:Label ID="lblpanno" runat="server"></asp:Label>
        </div>
        <div class="bordertopNew" style=" float: right;min-height: 1px;width: 100%;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;" ></div>



        <div class="FormGroupContent4 custom-d-flex">
            <div class="custom-col custom-mr-05  custom-ml-05">
                <asp:Label ID="lblbankname" runat="server" CssClass="hide" Text="Bank"> </asp:Label>
                <div class="Bank_name_input">
                    <asp:TextBox ID="txtbankid" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="Bank" ToolTip="Bank Name" TabIndex="42" onkeypress="return disableSpace()"></asp:TextBox>

                </div>
            </div>

            <div class="custom-col custom-mr-05 ">
                <asp:Label ID="lblifsc" runat="server" CssClass="hide" Text="IFSC Code"> </asp:Label>
                <div class="IFSC_code_input">
                    <asp:TextBox ID="txtifsc" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="IFSC Code" ToolTip="IFSC Code" TabIndex="43" onkeypress="return disableSpace()"></asp:TextBox>

                </div>
            </div>

            <div class="custom-col custom-mr-05 ">
                <asp:Label ID="lblaccountno" runat="server" CssClass="hide" Text="Account #"> </asp:Label>
                <div class="Account_number_input">
                    <asp:TextBox ID="txtaccountno" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="Account #" ToolTip="Account Number" TabIndex="44" OnTextChanged="txtaccountno_TextChanged" onkeypress="return disableSpace()"></asp:TextBox>

                </div>

            </div>

            <div class="custom-col custom-mr-05">
                <asp:Label ID="lblaccount" runat="server" CssClass="hide" Text="Type"> </asp:Label>
                <%-- <asp:TextBox ID="txtaccount" runat="server" CssClass="form-control" AutoPostBack="True" Visible="false" placeholder="" ToolTip="Branch " Text='<%#Bind("txtaccount")%>'></asp:TextBox>--%>

                <div class="Account_type_input">
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="23" CssClass="chzn-select"
                        ToolTip="Account Type" data-placeholder="Account Type" Width="100%" AutoPostBack="true" TabIndex="45" AppendDataBoundItems="False">

                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                        <asp:ListItem Text="CURRENT" Value="1"></asp:ListItem>
                        <asp:ListItem Text="SAVINGS" Value="2"></asp:ListItem>

                    </asp:DropDownList>
                </div>
            </div>

            <%-- <div class="btn-add add_button">
                                        <asp:Button runat="server" ToolTip="Add" />
                                    </div>--%>
            <div class=" right_btn custom-mt-3">
                <div class="btn-add">
                    <asp:Button ID="btn_Save" runat="server" ToolTip="Save" OnClick="btn_Save_Click" TabIndex="46" />
                </div>
                <div class="btn-cancel">
                    <asp:Button ID="btnbankcancel" runat="server" OnClick="btnbankcancel_Click" ToolTip="Cancel" TabIndex="47" />
                </div>
            </div>
        </div>
        <div class="FormGroupContent4">
            <asp:Panel runat="server" class="panel_19 MB0">

                <asp:GridView ID="GridView1" CssClass="Grid FixedHeader" runat="server" Visible="true" AutoGenerateColumns="false" EmptyDataText="No Record Found"
                    ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender">
                    <Columns>

                        <asp:BoundField DataField="Customerid" HeaderText="CUSTOMERID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                        <asp:BoundField DataField="Bankid" HeaderText="BANKID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                        <%--  <asp:BoundField DataField="Portid" HeaderText="PORTID"  ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"  />--%>
                        <asp:BoundField DataField="CustomerName" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" HeaderText="CUSTOMER NAME" Visible="false" />
                        <asp:BoundField DataField="LedgerName" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" HeaderText="LEDGER NAME" Visible="false" />
                        <asp:BoundField DataField="Address" HeaderText="Address" Visible="false" />
                        <asp:BoundField DataField="BankName" HeaderText="BANK NAME" />
                        <%-- <asp:BoundField DataField="Branch" HeaderText="BRANCH" />--%>
                        <asp:BoundField DataField="AccountNumber" HeaderText="ACCOUNT NUMBER" />
                        <asp:BoundField DataField="Account" HeaderText="ACCOUNT TYPE" />

                        <asp:BoundField DataField="IFSCCode" HeaderText="IFSC CODE" />
                        <asp:BoundField DataField="gstin" HeaderText="GST #" />
                        <%-- <asp:BoundField DataField="SWIFTCode" HeaderText="SWIFTCODE" />--%>
                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle CssClass="GrdRow" />

                </asp:GridView>
            </asp:Panel>


        </div>
    </div>
    <asp:HiddenField ID="hid_bankid" runat="server" />
    <asp:HiddenField ID="hidpaninput" runat="server" />

</asp:Content>
