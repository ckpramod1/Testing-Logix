<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="TallyXML.aspx.cs" Inherits="logix.Accounts.TallyXML" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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

    <link href="../Styles/TallyEDI.css" rel="stylesheet" />

    <%--EDIT--%>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

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

        .TallyVoucher {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .TallyVoucher span {
                font-size: 11px;
            }

        .TallyVoucherDrop {
            width: 19.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TallyFromLbl {
            width: 2.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .TallyFromLbl span {
                font-size: 11px;
            }

        .TallyMonthInput1 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TallyYear {
            width: 3%;
            float: left;
            margin: 0px 0.5% 0px 0px 0px;
        }

            .TallyYear span {
                font-size: 11px;
            }

        .TallyYrInput {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TallyToYr {
            width: 4%;
            float: left;
            margin: 3px 0.5% 0px 0px;
        }

        .ToyrInput {
            width: 2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .ToyrInput span {
                font-size: 11px;
            }

        .ToInputV1 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FromInput3 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TallyNarration {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .TallyNarration span {
                font-size: 11px;
            }

        .NarrationDrop {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TallyReference {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .TallyReference span {
                font-size: 11px;
            }

        .RerferenceDropN1 {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddl_reference_chzn {
            width: 100% !important;
        }

        .widget.box {
            border: 1px solid #D9D9D9;
            float: left;
            width: 100%;
            margin-left: 0px;
            margin-top: 0px;
            height: 550px;
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
        div#UpdatePanel1 {
    /* height: 92vh; */
    height: 100vh;
    overflow-x: hidden;
    overflow-y: hidden;
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
            /*color: #000080;*/
            font-size: 11px;
        }

        .FormGroupContent4 label {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

            .widget.box .widget-content {
                padding: 10px;
                position: relative;
                background-color: #fff;
                display: block;
                /* top: -9px; */
                left: 0px;
            }
                 .chzn-container .chzn-results {
    margin: 0 4px 4px 0;
    height: calc(100vh - 357px) !important;
    padding: 0 0 0 4px;
    position: relative;
      overflow: auto !important;
}
  .widget.box .widget-content {
    top: 0px !important;
    padding-top: 50px !important;
}     
    </style>

    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <%--EDIT--%>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Tally EDI"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Operating Accounts</a></li>
                            <li><a href="#" title="">XML</a> </li>
                            <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Tally EDI</a> </li>
                        </ul>
                    </div>
                    <!-- /Breadcrumbs line -->
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                     <div  class="FixedButtons" >
      <div class="right_btn">

         <div class="btn ico-pdf" id="pdf_id" runat="server"  >
             <asp:Button ID="btn_pdf" runat="server" Text="PDF" ToolTip="PDF" TabIndex="20" OnClick="btn_pdf_Click" />
         </div>
         <div class="btn ico-transfer" id="transfer_id" runat="server"  >
             <asp:Button ID="btn_UnTransfer" runat="server" Text="UnTransfer EDI" ToolTip="UnTransfer EDI" OnClick="btn_UnTransfer_Click" />
         </div>
         <div class="btn ico-view" id="view_id" runat="server"  >  
             <asp:Button ID="btn_View" runat="server"  Text="View" ToolTip="View" OnClick="btn_View_Click" />
         </div>
         <div class="btn ico-generate-edi" id="edi_id" runat="server"  >
             <asp:Button ID="btn_EDI" runat="server" Text="EDI" ToolTip="EDI" OnClick="btn_EDI_Click" />
         </div>
         <div class="btn ico-cancel" id="btn_cancel1" runat="server">
             <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
         </div>
         <div class="btn ico-edi-all-day" id="ediall_id" runat="server" Visible="false" >
             <asp:Button ID="btnediall" runat="server" Text="EDI All Day" ToolTip="EDIALL/Day" OnClick="btnediall_Click" Visible="false" />
         </div>
     </div>
 </div>

                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">

                        <div class="TallyVoucherDrop fit-content">
                            <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Type"></asp:Label>
                            <asp:DropDownList ID="ddl_voucher" runat="server" AutoPostBack="True" Data-placeholder="Voucher Type" ToolTip="Voucher Type" CssClass="chzn-select"
                                OnSelectedIndexChanged="ddl_voucher_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="FromInput3">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" placeholder="From" ToolTip="From"></asp:TextBox>
                        </div>

                        <div class="ToInputV1">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" placeholder="To" ToolTip="To"></asp:TextBox>
                        </div>
                        <%--<div class="TallyMonthInput1"><asp:TextBox ID="txt_month" runat="server" MaxLength="2" CssClass="form-control" placeholder="Month" ToolTip="Month"></asp:TextBox></div>--%>

                        <div class="TallyYrInput">
                            <asp:Label ID="lbl_year" runat="server" Text="Year"></asp:Label>
                            <asp:TextBox ID="txt_year" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="Year" ToolTip="Year"
                                OnTextChanged="txt_year_TextChanged" MaxLength="4"></asp:TextBox>
                        </div>
                        <div class="TallyToYr hide">
                            <asp:Label ID="lbl_toyear" runat="server" Text="" Font-Size="12px"></asp:Label>
                        </div>

                       
                        <div class="TallyYrInput" id="lbl_JVmonth" runat="server"  Visible="false" >
                            <asp:Label ID="div_JVmonth" runat="server" Text="Month" ></asp:Label>

                            <asp:TextBox ID="txt_JVmonth" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="Month" ToolTip="Month"
                                MaxLength="2" Visible="false" ></asp:TextBox>

                        </div>

                        <div class="NarrationDrop">
                            <asp:Label ID="lbl_narration" runat="server" Text="Narration"></asp:Label>
                            <asp:DropDownList ID="ddl_narration" runat="server" AppendDataBoundItems="True" Data-placeholder="Narration" ToolTip="Narration" CssClass="chzn-select">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="RerferenceDropN1">
                            <asp:Label ID="lbl_Reference" runat="server" Text="Reference"></asp:Label>
                            <asp:DropDownList ID="ddl_reference" runat="server" AppendDataBoundItems="True" Data-placeholder="Reference" ToolTip="Reference Number" CssClass="chzn-select">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                       
                    </div>

                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_month" runat="server" />
    <asp:HiddenField ID="hid_shortname" runat="server" />
    <asp:HiddenField ID="hid_portcode" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Tally XML #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/images/close2.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

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
