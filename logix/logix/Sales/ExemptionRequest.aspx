<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ExemptionRequest.aspx.cs" Inherits="logix.Sales.ExemptionRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />   
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
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

    <script>
        $(document).ready(function () {

            $('.selectpicker').selectpicker();

            "use strict";

            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins

            //$('select.styled').customSelect();

        });

    </script>

    <link href="../Styles/ExemptionRequest.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

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

        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            margin-left: 96%;
            margin-top: -1.7%;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #table-container {
            position: relative;
            width: 99%;
            height: 400px;
            overflow: auto;
            padding: 0 0.1% 0 0;
            margin-top: 0.8%;
            margin-bottom: 1%;
            /*----------------*/
            font-family: sans-serif;
            margin-left: 0.3%;
        }

        table.gvTheGrid td,
        table.gvTheGrid th {
            padding: 3px 7px;
        }

        .crumbs1 {
            display: none;
        }

        #logix_CPH_popupsecond {
            top: 32.5px !important;
        }

        .modalPopupss {
            width: 99% !important;
        }

        .CompanyDropCreditProduct {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BlInput {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DateInputN1 {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditInput {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .CreditInput input {
                text-align: right;
            }

        .CreditDayInput {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 89vh;
    overflow-x: hidden;
    overflow-y: auto;
}

            .CreditDayInput input {
                text-align: right;
            }

        .TotalInput {
            width: 13.3%;
            float: right;
            margin: 0px;
        }

        .RemarkExe {
            width: 86%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        /*LOG DETAILS CSS*/

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
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
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

        .CreditLbl1 {
            float: left;
            width: 6%;
            margin: 4px 0.5% 0px 0px;
            font-size: 13px;
            font-weight: bold;
        }

        .ExemptInput {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditDaysLbl {
            float: left;
            width: 6%;
            margin: 4px 0.5% 0px 0px;
            font-size: 13px;
            font-weight: bold;
        }

        .LogHeadJobInput label {
            font-size: 11px;
            font-family: sans-serif;
            color: #4e4e4c;
        }

        .Txtcustomer {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipperBox {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ConsBox {
            width: 25%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .CustomerAddress {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipmentAddress {
            width: 50%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .grid_1 {
            height: 153px;
            width: 100%;
            margin-left: 0%;
            border: 1px solid #999997;
            margin-top: 0.5%;
        }
 
        .ApprovedByInput {
            width: 33%;
            float: left;
            margin: 0px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .ExemptedLabel {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            font-weight: 600;
        }

        .ExemonInput {
            float: right;
            font-size: 11px;
            margin: 0px 0px 0px 0px;
            width: 100%;
        }

        .ExemOnLabel {
            float: right;
            font-size: 11px;
            font-weight: 600;
            margin: 0;
            width: 8.5%;
        }
        .TotalInput input {
    text-align: right;
}
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 55px !important;
}
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_bl.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hiddenid.ClientID %>").val(0);
                        $.ajax({
                            url: "ExemptionRequest.aspx/GetLikeexcemption",
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
                    <%-- select: function (event, i) {
                         <%-- $("#<%=txt_bl.ClientID %>").val(i.item.label);
                         $("#<%=txt_bl.ClientID %>").change();
                         $("#<%=txt_bl.ClientID %>").val(i.item.label);
                         $("#<%=txt_bl.ClientID %>").change();
                         $("#<%=hiddenid.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txt_bl.ClientID %>").val(i.item.label);
                         $("#<%=hiddenid.ClientID %>").val(i.item.val);
                     },
                     change: function (event, i) {
                         $("#<%=txt_bl.ClientID %>").val(i.item.label);
                         $("#<%=hiddenid.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txt_bl.ClientID %>").val(i.item.label);
                         $("#<%=hiddenid.ClientID %>").val(i.item.val);
                     },--%>

                    select: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.label);
                        $("#<%=txt_bl.ClientID %>").change();
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.label);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.label);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.label);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->

    <div >
        <asp:HiddenField ID="hiddenid" runat="server" />
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="headerlbl" runat="server" Text="Credit Exemptions"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
    <div class="crumbs" id="crumbsid" runat="server">
        <ul id="breadcrumbs" class="breadcrumb" runat="server">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li id="lblEx1" runat="server"><a href="#" title="" runat="server" id="HeaderLabel1"></a></li>
            <li id="lblEx2" runat="server"><a href="#" title="" runat="server" id="headerlabel2"></a></li>
            <li class="current"><a href="#" title="">Credit Exemptions</a> </li>
        </ul>
    </div>
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons">
    
<div class="right_btn">
    <div class="btn ico-save" id="btn_save1" runat="server">
        <asp:Button ID="btn_save" runat="server"  Text="Save" ToolTip="Save" OnClick="btn_save_Click" TabIndex="17" />
    </div>
    <div class="btn ico-cancel" id="btn_cancel1" runat="server">
        <asp:Button ID="btn_Back" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btn_Back_Click" TabIndex="18" />
    </div>
</div>
</div>

                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CompanyDropCreditProduct">
                            <asp:Label ID="Label1" runat="server" Text="Product"> </asp:Label>
                            <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="BlInput">
                            <asp:Label ID="Label2" runat="server" Text="BL# / AWBL#"> </asp:Label>
                            <asp:TextBox ID="txt_bl" runat="server" CssClass="form-control" placeHolder="" ToolTip="BL# / AWBL#" AutoPostBack="true"
                                OnTextChanged="txt_bl_TextChanged" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="DateInputN1">
                            <asp:Label ID="Label3" runat="server" Text="Date"> </asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" Enabled="false" placeHolder="" ToolTip="Date" CssClass="form-control" TabIndex="4"></asp:TextBox>
                        </div>

                        <div class="CreditInput">
                            <asp:Label Text="Credit Limit Rs. " ID="creditlbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txt_credit" runat="server" Enabled="false" placeHolder="" ToolTip="Credit Limit Rs." CssClass="form-control" TabIndex="5"></asp:TextBox>
                        </div>

                        <div class="CreditDayInput">
                            <asp:Label ID="CrditDayLbl" Text="Credit Days" runat="server"></asp:Label>
                            <asp:TextBox ID="txt_cdays" runat="server" Enabled="false" placeHolder="" ToolTip="Credit Days" CssClass="form-control" TabIndex="6"></asp:TextBox>
                        </div>
                        <div class="ExemptInput">
                            <%--<div class="ExemptedLabel"><strong>Exempted By :</strong></div>--%>
                            <asp:Label Text="Exempted By" runat="server" />
                            <asp:TextBox ID="txt_req" runat="server" placeHolder="" BorderWidth="0" ToolTip="Exempted By" Enabled="false" CssClass="form-control" TabIndex="1"></asp:TextBox>
                        </div>
                        <div class="ExemOnLabel DateR">
                            <%--<div class="ExemonInput"><strong>Exempted On :</strong></div>--%>
                            <asp:Label Text="Exempted On " runat="server" />
                            <asp:TextBox ID="txt_reqdate" runat="server" placeHolder="" ToolTip="Exempted On" BorderWidth="0"
                                CssClass="form-control" Enabled="false" TabIndex="2"></asp:TextBox>
                        </div>

                    </div>
                      <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <div class="Txtcustomer">
                            <asp:Label ID="Label5" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txt_cus" runat="server" placeHolder="" ToolTip="Customer" CssClass="form-control" Enabled="false" TabIndex="7"></asp:TextBox>
                        </div>

                        <div class="ShipperBox">
                            <asp:Label ID="Label6" runat="server" Text="Shipper"> </asp:Label>
                            <asp:TextBox ID="txt_shipper" runat="server" placeHolder="" ToolTip="Shipper" Enabled="false" CssClass="form-control" TabIndex="9"></asp:TextBox>
                        </div>
                        <div class="ConsBox">
                            <asp:Label ID="Label7" runat="server" Text="Consignee"> </asp:Label>
                            <asp:TextBox ID="txt_consignee" runat="server" placeHolder="" ToolTip="Consignee" Enabled="false" CssClass="form-control" TabIndex="10"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4">
                        <div class="CustomerAddress">
                            <asp:Label ID="Label8" runat="server" Text="Customer Address"> </asp:Label>
                            <asp:TextBox ID="txt_cus_addre" TextMode="MultiLine" Style="resize: none" runat="server" Width="100%" Enabled="false" placeHolder="" ToolTip="Customer Address" CssClass="form-control" TabIndex="8"></asp:TextBox>
                        </div>

                        <div class="ShipmentAddress">
                            <asp:Label ID="Label9" runat="server" Text="Shipments"> </asp:Label>
                            <asp:TextBox ID="txt_sdetails" runat="server" TextMode="MultiLine" placeHolder="" ToolTip="Shipments" Enabled="false" CssClass="form-control" TabIndex="11"></asp:TextBox>
                        </div>

                    </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="Panel1" runat="server" CssClass="panel_05 MB0" >

                            <asp:GridView ID="grd" runat="server" Height="100%" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" OnPreRender="grd_PreRender" >
                                <Columns>
                                    <asp:BoundField HeaderText="Branch" DataField="shortname">
                                        <HeaderStyle />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="customername" HeaderText="Individual Customer Names">
                                        <HeaderStyle />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                                        <HeaderStyle  />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="invdate" HeaderText="Date">
                                        <HeaderStyle  />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="days" HeaderText="O/S Days">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle Width="100px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="osamount" HeaderText="O/S Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>

                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <div class="RemarkExe">
                            <asp:Label ID="Label10" runat="server" Text="Remarks"> </asp:Label>
                            <asp:TextBox ID="txt_remarks" runat="server" placeHolder="" ToolTip="Remarks" CssClass="form-control" TabIndex="13"></asp:TextBox>
                        </div>
                        <div class="TotalInput">
                            <asp:Label ID="Label11" runat="server" Text="Total"> </asp:Label>
                            <asp:TextBox ID="txt_tot" runat="server" Enabled="false" placeHolder="" ToolTip="Total" CssClass="form-control" TabIndex="12"></asp:TextBox>
                        </div>
                        </div>
                    <div class="FormGroupContent4">

                        <div class="ApproveInput">
                            <asp:Label ID="Label12" runat="server" Text="Approved Exemption Limit"> </asp:Label>
                            <asp:TextBox ID="txt_approv" runat="server" placeHolder="" ToolTip="Approved Exemption Limit" CssClass="form-control" TabIndex="14"></asp:TextBox>
                        </div>
                        <div class="UsedInput">
                            <asp:Label ID="Label13" runat="server" Text="No of Exemption Used"> </asp:Label>
                            <asp:TextBox ID="txt_excem" runat="server" Enabled="false" placeHolder="" ToolTip="No of Exemption Used" CssClass="form-control" TabIndex="15"></asp:TextBox>
                        </div>
                        <div class="ApprovedByInput">
                            <asp:Label ID="Label14" runat="server" Text="Approved by"> </asp:Label>
                            <asp:TextBox ID="txt_appro" Enabled="false" runat="server" placeHolder="" ToolTip="Approved by" CssClass="form-control" TabIndex="16" OnTextChanged="txt_appro_TextChanged"></asp:TextBox>
                        </div>
                        
                    </div>
                        </div>
                
                    <div class="bordertopNew"></div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="Panel2" runat="server" CssClass="panel_05" ScrollBars="auto">

                            <asp:GridView ID="GrdExe" runat="server" Height="100%" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" OnPreRender="GrdExe_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="docno" HeaderText="BL #" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                                    <asp:BoundField DataField="reqon" HeaderText="Requested On" />
                                    <asp:BoundField DataField="empname" HeaderText="Requested By" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4">

                        <asp:Label ID="lblquot" runat="server"></asp:Label>
                        <ajaxtoolkit:ModalPopupExtender ID="popupQuot" runat="server" TargetControlID="lblquot"
                            BehaviorID="programmaticModalPopupBehavior2"
                            DropShadow="false" PopupControlID="popupsecond" CancelControlID="imgok">
                        </ajaxtoolkit:ModalPopupExtender>
                        <asp:Panel ID="popupsecond" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <%--<div class="divRoated">--%>
                            <div class="DivSecPanel">
                                <asp:Image ID="imgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>
                            <div class="div_Grid">
                                <asp:Panel ID="Panel" runat="server" CssClass="Gridpnl">
                                    <asp:GridView ID="creditgrd" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" Width="100%" PageSize="20" AllowPaging="false"
                                        OnPageIndexChanging="creditgrd_PageIndexChanging" CssClass="Grid FixedHeader"  OnSelectedIndexChanged="creditgrd_SelectedIndexChanged" OnRowDataBound="creditgrd_RowDataBound">

                                        <Columns>
                                            <asp:BoundField DataField="branch" HeaderText="Branch">
                                                <ControlStyle />
                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                <ItemStyle Font-Bold="false" Wrap="false" HorizontalAlign="Justify" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="docno" HeaderText="Doc #">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle HorizontalAlign="left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="reqby" HeaderText="Requested by" DataFormatString="{0:F2}">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="customer" HeaderText="CustomerName">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="creditamt" HeaderText="CreditLimit" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="creditdays" HeaderText="Creditdays">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="bid" HeaderText="bid">
                                                <HeaderStyle HorizontalAlign="Center" CssClass="grd-mt" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Right" CssClass="grd-mt" Wrap="false" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="trantype" HeaderText="trantype">
                                                <HeaderStyle HorizontalAlign="Center" CssClass="grd-mt" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Right" CssClass="grd-mt" Wrap="false" />
                                            </asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </asp:Panel>
                        <asp:HiddenField ID="intcustid" runat="server" />

                    </div>

                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server"></label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

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
                </div>
            </div>
        </div>

    </div>
    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test3">
    </ajaxtoolkit:ModalPopupExtender>

</asp:Content>

