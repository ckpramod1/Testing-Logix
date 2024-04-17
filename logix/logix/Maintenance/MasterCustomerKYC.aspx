<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomerKYC.aspx.cs" Inherits="logix.Maintenance.MasterCustomerKYC" EnableEventValidation="false" %>

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

    <%--     <script type="text/javascript">
         function dropdownButton() {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }

    </script>--%>

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
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
        input[type="file"] {
            height: 36px;
            padding: 8px;
        }

        .custom-mt-2 {
            margin-top: 17px !important;
        }

        .CardLbl {
            padding: 5px 0 0 5px;
        }

        div#logix_CPH_ddlIDProof_chzn {
            width: 100% !important;
        }

        .KYCDETAILS {
            width: 20% !important;
            float: left;
        }

        .File {
            width: 20%;
            float: left;
        }
           }
 div#logix_CPH_plblan {
    margin: 0px 0px 0px 6px;
}
    .CustomerName12 {
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        span.headingName {
    font-weight: bold !important;
        font-size: 14px !important;
}
        div#logix_CPH_plblan {
    margin: 5px 0px 0 5px !important;
}
        .CardLbl.customerName {
    float: left;
    margin-right: 0.5%;
}
        .CardLbl {
    padding: 5px 0 0 5px;
    font-size: 11px;
}
        .PageHeight {
    padding-top: 0px;
    height: 100vh;
    padding-bottom: 8px;
}
        span#logix_CPH_Label58 {
    font-size: 20px !important;
}
        .CardLbl.customerName span {
    font-size: 14px !important;
}
        span#logix_CPH_lblpanno {
    font-size: 14px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="CardLbl">
        <asp:Label ID="Label58" class="headingName" runat="server">KYC Details </asp:Label>
    </div>
    <div class="CardLbl customerName">
        <span class="headingName">CUSTOMER NAME :</span>
        <asp:Label ID="lblcustomername" runat="server"> </asp:Label>
    </div>
    <div class="panno12" id="plblan" runat="server">
        <span class="headingName">PAN #       :</span>
        <asp:Label ID="lblpanno" runat="server"></asp:Label>
    </div>
                        <div class="bordertopNew" style=" float: right;min-height: 1px;width: 100%;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;" ></div>
    <div class="FormGroupContent4">
        <div class="custom-mr-05  custom-ml-05 KYCDETAILS">
            <asp:Label Text="KYC Details" ID="lbl_KYC" CssClass="hide" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlIDProof" runat="server" AppendDataBoundItems="True" TabIndex="40" CssClass=" form-control chzn-select"
                ToolTip="KYC Details" data-placeholder="KYC Details">
                <asp:ListItem Text="" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class=" File custom-mr-05 custom-mt-2">
            <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Always" runat="server">
                <ContentTemplate>
                    <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                    <asp:FileUpload ID="KycUpload" CssClass="bt" runat="server" />
                    <div class="div_btn">
                        <asp:Button ID="Button7" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnkyc" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="left_btn custom-mt-3">
            <div class="btn ico-upload" id="Div2" runat="server">
                <asp:Button ID="btnkyc" runat="server" ToolTip="KYC Update" OnClick="btnkyc_Click" TabIndex="41" />
                <asp:GridView ID="GridView11" CssClass="FixedHeader" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="FormGroupContent4">
        <div id="Pl_Proof" runat="server" class="panel_19 MB0">
            <asp:GridView ID="GrdProofkyc" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"
                OnSelectedIndexChanged="GrdProof_SelectedIndexChanged" OnRowDataBound="GrdProof_RowDataBound"
                OnRowDeleting="GrdProofkyc_RowDeleting" OnRowCommand="GrdProofkyc_RowCommand" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found">
                <%-- OnRowCommand="GrdProofkyc_RowCommand" Visible="true"--%>

                <Columns>
                    <asp:BoundField DataField="proof" HeaderText="KYC Proof" />
                    <asp:BoundField DataField="filename" HeaderText="FileName" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" OnClientClick="return confirm('Are you sure you want delete');" />
                        </ItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px" />
                        <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <RowStyle CssClass="GrdRow" />
            </asp:GridView>
        </div>
        <div class="CreditRight" style="display: none;">
            <asp:Panel ID="Book2" runat="server" Visible="true">
                <asp:GridView ID="test" runat="server" CssClass="Grid FixedHeader" Width="100%" OnRowDataBound="test_RowDataBound" OnPreRender="test_PreRender">
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle Font-Italic="False" />
                </asp:GridView>
                <div class="div_Break"></div>
            </asp:Panel>
        </div>


        <div class="FormGroupContent4 hide">
            <div class="lbl_btn">

                <div class="btns">
                    <div class="btn-save">
                        <asp:Button ID="Button8" runat="server" ToolTip="Save" />
                    </div>
                    <div class="btn-cancel">
                        <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" />
                        <%-- OnClick="btnCancel_Click" --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hf_customerid" runat="server" />
    <asp:HiddenField ID="hid_pan" runat="server" />
      <asp:HiddenField ID="hidpaninput" runat="server" />
</asp:Content>
