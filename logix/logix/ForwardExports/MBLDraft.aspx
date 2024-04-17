<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MBLDraft.aspx.cs" Inherits="logix.ForwardExports.MBLDraft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
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
    <link href="../Theme/assets/css/ifact.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
        <script src="../js/helper.js"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

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
    <style type="text/css">
        .TypeDropForNew {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TypeDropForNew1 {
            width: 89%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .FormGroupContent4 textarea {
            height: 90px !important;
        }

        .ConsigneeInput1 {
            width: 99.7%;
            float: left;
            margin: 0px;
        }

        .FrieghtDropBL {
            width: 10.4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GrossWeightInput {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .NetweigInput {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PlaceInput1 {
            width: 14.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PortInput2 {
            width: 14.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DischargeInput {
            width: 14.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DestinationInputN {
            width: 18%;
            float: left;
            margin: 0px;
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

        .PlaceInput1 {
            width: 13.1%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DestinationInputN {
            width: 19.5%;
            float: left;
            margin: 0px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
 
    <div class="">
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <h4 class="hide"> <i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="MBL Draft"></asp:Label></h4>
                       
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Forwarding Exports</a> </li>
            <li class="current"><a href="#" title="">FEMBL Draft</a> </li>
        </ul>
    </div>

                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">

                        <div class="TypeDropForNew">
                            <asp:Label ID="Label1" runat="server" Text="Job #"> </asp:Label>
                            <asp:TextBox ID="txtJob" runat="server" CssClass="form-control" ToolTip="Job #" TabIndex="1" placeholder="" AutoPostBack="true" OnTextChanged="txtJob_TextChanged"></asp:TextBox>
                        </div>
                        <div class="TypeDropForNew1">
                            <asp:Label ID="Label2" runat="server" Text="Voyage/Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_voyageandvessel" runat="server" CssClass="form-control" TabIndex="2" placeholder="" ToolTip="Voyage/Vessel"></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent4">

                        <div class="ShipperInput4">
                            <asp:Label ID="Label3" runat="server" Text="Shipper Address"> </asp:Label>
                            <asp:TextBox ID="txt_shipperaddress" TabIndex="3" runat="server" Rows="5" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Shipper Address"></asp:TextBox>
                        </div>
                        <div class="ConsigneeInput">
                            <asp:Label ID="Label4" runat="server" Text="Consignee Address"> </asp:Label>
                            <asp:TextBox ID="txt_consigneeaddress" runat="server" TabIndex="4" Rows="5" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Consignee Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">

                        <div class="ShipperInput4">
                            <asp:Label ID="Label5" runat="server" Text="Container"> </asp:Label>
                            <asp:TextBox ID="txt_container" TabIndex="5" runat="server" Rows="5" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Container"></asp:TextBox>
                        </div>
                        <div class="ConsigneeInput">
                            <asp:Label ID="Label6" runat="server" Text="Marks & Remarks"> </asp:Label>
                            <asp:TextBox ID="txt_marks" runat="server" TabIndex="6" Rows="5" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Marks & Remarks"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="ShipperInput4">
                            <asp:Label ID="Label7" runat="server" Text="Notify Address"> </asp:Label>
                            <asp:TextBox ID="txt_notify" TabIndex="7" runat="server" Rows="5" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Notify Address"></asp:TextBox>
                        </div>
                        <div class="ConsigneeInput">
                            <asp:Label ID="Label8" runat="server" Text="Description"> </asp:Label>
                            <asp:TextBox ID="txt_descn" runat="server" TabIndex="8" Rows="5" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Description"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="FrieghtDropBL">
                            <asp:Label ID="Label9" runat="server" Text="Freight Status"> </asp:Label>
                            <asp:DropDownList ID="ddl_freight" TabIndex="9" data-placeholder="Freight Status" Height="25" runat="server" CssClass="chzn-select" ToolTip="Freight Status">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Value="P">Prepaid</asp:ListItem>
                                <asp:ListItem Value="C">TO Collect</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="GrossWeightInput">
                            <asp:Label ID="Label10" runat="server" Text="CBM"> </asp:Label>
                            <asp:TextBox ID="txt_cbm" runat="server" TabIndex="10" CssClass="form-control" placeholder="" ToolTip="CBM"></asp:TextBox>
                        </div>
                        <div class="GrossWeightInput">
                            <asp:Label ID="Label11" runat="server" Text="Grs Wt(KGS)"> </asp:Label>
                            <asp:TextBox ID="txt_grwt" runat="server" TabIndex="11" CssClass="form-control" placeholder="" ToolTip="Gross Weight KGS"></asp:TextBox>
                        </div>
                        <div class="NetweigInput">
                            <asp:Label ID="Label12" runat="server" Text="Net Wt(KGS)"> </asp:Label>
                            <asp:TextBox ID="txt_ntwt" runat="server" AutoPostBack="true" TabIndex="12" CssClass="form-control" placeholder="" ToolTip="Net Weight KGS"></asp:TextBox>
                        </div>

                        <div class="PlaceInput1">
                            <asp:Label ID="Label13" runat="server" Text="Place of Receipt"> </asp:Label>
                            <asp:TextBox ID="txt_receipt" runat="server" CssClass="form-control" TabIndex="13" placeholder="" ToolTip="Place of Receipt"></asp:TextBox>
                        </div>
                        <div class="PortInput2">
                            <asp:Label ID="Label14" runat="server" Text="Port of Loading"> </asp:Label>
                            <asp:TextBox ID="txt_loading" runat="server" CssClass="form-control" TabIndex="14" placeholder="" ToolTip="Port of Loading"></asp:TextBox>
                        </div>
                        <div class="DischargeInput">
                            <asp:Label ID="Label15" runat="server" Text="Port of Discharge"> </asp:Label>
                            <asp:TextBox ID="txt_discharge" runat="server" CssClass="form-control" TabIndex="15" placeholder="" ToolTip="Port of Discharge"></asp:TextBox>
                        </div>
                        <div class="DestinationInputN">
                            <asp:Label ID="Label16" runat="server" Text="Place of Delivery"> </asp:Label>
                            <asp:TextBox ID="txt_destination" runat="server" CssClass="form-control" TabIndex="16" placeholder="" ToolTip="Place of Delivery"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn MT15 MB10">
                            <div class="btn ico-save" id="btnSave1" runat="server">
                                <asp:Button ID="btnSave" runat="server" ToolTip="Save" OnClick="btnSave_Click" />
                            </div>
                            <div class="btn  ico-view">
                                <asp:Button ID="btnview" runat="server" ToolTip="View" OnClick="btnview_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btnClear1" runat="server">
                                <asp:Button ID="btnClear" runat="server" ToolTip="Cancel" OnClick="btnClear_Click" />

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hid_marks" runat="server" />
    <asp:HiddenField ID="hid_desc" runat="server" />
</asp:Content>
