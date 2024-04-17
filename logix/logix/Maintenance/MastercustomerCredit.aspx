<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MastercustomerCredit.aspx.cs" Inherits="logix.Maintenance.MastercustomerCredit" EnableEventValidation="false" %>

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

    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

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
        .creditAmt {
            float: left;
        }

        

        .CreditAmountInput {
            width: 12.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .ClientType {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        div#logix_CPH_ddlProductType_chzn {
            width: 100% !important;
        }

        .VolumeTypeInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VolumeTypeDrop {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RevenueInput {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .creadit {
            float: left;
            width: 7%;
        }

        .CreditAmountInput {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .hide {
            display: none;
        }

        input#logix_CPH_txt_creditdays {
            text-align: right;
        }

        input#logix_CPH_txtCreditAboveamt {
            text-align: right;
        }

        input#logix_CPH_txt_vol {
            text-align: right;
        }
        .Gridpnl {
    width: 99% !important;
    height: auto;
    border: 1px solid var(--lightgrey) !important;
    margin: 0 auto !important;
    /* overflow-y: scroll !important; */
    overflow-x: auto !important;
}
        .Gridpnl {
    width: 99% !important;
    height: auto !important;
    border: 1px solid var(--lightgrey) !important;
    margin: 0 auto !important;
    /* overflow-y: scroll !important; */
    overflow-x: auto !important;
}
        .right_btn {
    float: right !important;
    margin: 5px 0 0 0;
    display: flex;
    /* margin: 0px 0px 0px 759% !important; */
}
          .customername {
            float: left;
    margin: 0px 0.5% 6px 5px
        }

        span.headingName {
            font-weight: bold !important;
        }
        .CardLbl {
    /*float: left;*/
    margin: -6px 0.5% 7px 4px;
        display: none;
}
span#logix_CPH_Label56 {
     font-weight: 400 !important;
    font-size: 24px !important;
    color: var(--labelblue);
}
.PageHeight {
    padding-top: 0px;
    height: 100vh;
    padding-bottom: 8px;
}
.chzn-drop {
    width: 100% !important;
    min-height: 150px !important;
    max-height: fit-content !important;
    height: 217px !important;
    overflow: auto;
}
    </style>
    <script type="text/javascript">

        function validateNumber(e) {
            const pattern = /^[0-9]$/;

            return pattern.test(e.key)
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="col-md-12  maindiv">

        <div class="widget box">
            <asp:Panel ID="Panel2" runat="server" Width="100%" Height="100%" CssClass="">
                <div class="widget-content">

                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">
                        <div class="CardLbl">
                            <asp:Label ID="Label56" runat="server">Credit Details</asp:Label>
                        </div>
                         <div class="customername">
                             <span  class="headingName">CUSTOMER NAME</span>
                            <asp:Label ID="lblcustomername" runat="server"> </asp:Label>
                        </div>
                         <div  class="panno12" id="plblan" runat="server">
                             <span   class="headingName">PAN#   :</span>
                            <asp:Label ID="lblpanno" runat="server"></asp:Label>
                        </div>
                            </div>

                             <div class="bordertopNew" style=" float: right;min-height: 1px;width: 100%;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;" ></div>
                        <div class="FormGroupContent4">
                            <div class="ClientType">

                                <asp:Label ID="Label20" runat="server" Text="Product"></asp:Label>
                                <asp:DropDownList ID="ddlProductType" runat="server" data-PlaceHolder="Product" ToolTip="Product" Width="100%" CssClass="chzn-select form-control" TabIndex="41">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <%--<asp:ListItem Text="All" Value="1"></asp:ListItem>--%>
                                    <asp:ListItem Text="Ocean Export-FCL" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Ocean Export-LCL" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Ocean Import-FCL" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Ocean Import-LCL" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Air Export" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Air Import" Value="7"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="VolumeTypeInput">
                                <asp:Label ID="Label48" runat="server" Text="Exp Volume"></asp:Label>
                                <asp:TextBox ID="txt_vol" runat="server" PlaceHolder="" ToolTip="Expected Volume" CssClass="form-control" Width="100%" TabIndex="42" onkeypress="return validateFloatKeyPress(this,event,'Volume');"></asp:TextBox>
                            </div>
                            <div class="VolumeTypeDrop">
                                <asp:Label ID="Label50" runat="server" Text="Type"></asp:Label>
                                <asp:DropDownList ID="ddlvolumetype" data-PlaceHolder="" ToolTip="Type" runat="server" Width="100%" CssClass="chzn-select" TabIndex="43">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="RevenueInput">
                                <asp:Label ID="Label51" runat="server" Text="Exp Revenue"></asp:Label>
                                <asp:TextBox ID="txt_revenue" runat="server" PlaceHolder="" ToolTip="Expected Revenue" CssClass="form-control" Width="100%" TabIndex="44" onkeypress="return validateFloatKeyPress(this,event,'Revenue');"></asp:TextBox>
                            </div>

                            <div class="creadit custom-mr-05">
                                <asp:Label ID="Label52" runat="server" Text="Credit Days"></asp:Label>
                                <asp:TextBox ID="txt_creditdays" runat="server" PlaceHolder="" ToolTip="Required Credit Days" CssClass="form-control" Width="100%" onkeypress="return validateNumber(event)" TabIndex="45"></asp:TextBox>
                            </div>

                             <div class="creditAmt custom-mr-05">

                                <asp:Label ID="Label53" runat="server" Text="Credit Amount"></asp:Label>
                                <asp:TextBox ID="txtCreditAboveamt" runat="server" PlaceHolder="Credit Amount" ToolTip="Required Credit Amount" CssClass="form-control" Width="100%" onkeypress="return validateFloatKeyPress(this,event,'Currency');" TabIndex="46"></asp:TextBox>
                            </div>
                            <div class="custom-d-flex">
                                <div class="Exemption custom-mr-05">
                                    <span>No. of Exemptions</span>
                                    <asp:TextBox ID="txt_exemptions" runat="server" ToolTip="No. of Exemptions" Style="text-align: right;" placeholder="" CssClass="form-control"></asp:TextBox>

                                </div>

                                <div class="custom-col custom-mr-05 ">
                                    <span>Per</span>
                                    <asp:DropDownList ID="ddl_per" runat="server" ToolTip="Per" data-placeholder="Per" Width="100%" CssClass="chzn-select" BorderColor="#999997">
                                        <asp:ListItem Text=""></asp:ListItem>
                                        <asp:ListItem Text="Annual" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Month" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="custom-col-5 custom-mr-05">
                                    <span>Allowed Overdue %</span>
                                    <asp:TextBox ID="txt_overdue" Width="100%" runat="server" ToolTip="Allowed Overdue" Style="text-align: right;" placeholder="" CssClass="form-control" OnTextChanged="txt_overdue_TextChanged"></asp:TextBox>
                                </div>
                                <div class="right_btn custom-mt-3">
                                <div class="btn ico-add" id="Div1" runat="server">
                                    <asp:Button ID="btnCreditRequestAdd" runat="server" ToolTip="ADD" TabIndex="47" OnClick="btnCreditRequestAdd_Click" />
                                </div>
                                 <div class="btn-cancel" id="Div2" runat="server">
                                    <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click"/>
                                </div>
                                    </div>
                            </div>

                            <div class="CreditDaysInput hide ">
                                <span>Creditdays</span>
                                <asp:TextBox ID="txt_creditday" runat="server" placeholder="" ToolTip="CreditDays" CssClass="form-control"></asp:TextBox>
                            </div>
                            <%--<div class="CreditAmountInput ">
                                <span>CreditAmount</span>
                                <asp:TextBox ID="txt_creditamount" runat="server" placeholder="" ToolTip="CreditAmount" CssClass="form-control"></asp:TextBox>
                            </div>--%>


                            <%--<asp:Panel ID="pnlcreditreq" runat="server" CssClass="panel_13" Visible="true" >--%>
                            <%--</asp:Panel>--%>
                            <asp:Label ID="lbl_crmt" runat="server" Style="font-weight: bold!important; color: #b50000!important; text-decoration: none;"></asp:Label>
                        </div>

                        <div class=" FormGroupContent4">
                           
                        </div>

                        <div class="FormGroupContent4">
                            <div class="gridpnl" id="pnlcreditreq" runat="server" visible="true">
                                <asp:GridView ID="Grd_MAsterCredit" CssClass="Grid FixedHeader" runat="server"
                                    OnSelectedIndexChanged="Grd_MAsterCredit_SelectedIndexChanged"
                                    OnRowDataBound="Grd_MAsterCredit_RowDataBound" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found">
                                    <%--AutoGenerateSelectButton="false" AutoGenerateColumns = "true" Visible="true" --%>

                                    <Columns>

                                        <asp:BoundField DataField="Customer" HeaderText="Customer" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="Product" HeaderText="Product" ItemStyle-Width="300px" HeaderStyle-Width="300px" />
                                        <asp:BoundField DataField="Volume" HeaderText="Expected Volume" />
                                        <asp:BoundField DataField="VolumeType" HeaderText="Expected Volume Type" />
                                        <asp:BoundField DataField="Revenue" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="Creditdays" HeaderText="Credit Days" ItemStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="CreditAmount" HeaderText="Credit Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Imgsb" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" Height="16px" OnClick="Imgsb_Click" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:BoundField DataField="crid" HeaderText="crid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="pEXMODE" HeaderText="Month" Visible="false" HeaderStyle-CssClass="hide" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="myGridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                    <%--    <Columns>

                                        <asp:BoundField DataField="Customer" HeaderText="Customer" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="Product" HeaderText="Product" ItemStyle-Width="300px" HeaderStyle-Width="300px" />
                                        <asp:BoundField DataField="Volume" HeaderText="Expected Volume" />
                                        <asp:BoundField DataField="VolumeType" HeaderText="Expected Volume Type" />
                                        <asp:BoundField DataField="Revenue" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="Creditdays" HeaderText="Credit Days" ItemStyle-CssClass="TxtAlign1" />
                                        <asp:BoundField DataField="CreditAmount" HeaderText="Credit Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Imgsb" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" Height="16px" OnClick="Imgsb_Click" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:BoundField DataField="crid" HeaderText="crid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="myGridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewSc--%><%--rollPager" />--%>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <asp:HiddenField ID="hid_crid" runat="server" />
     <asp:HiddenField ID="hidpaninput" runat="server" /> 
</asp:Content>
