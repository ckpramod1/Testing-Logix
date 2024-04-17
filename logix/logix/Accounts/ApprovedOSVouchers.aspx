<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ApprovedOSVouchers.aspx.cs" Inherits="logix.Accounts.ApprovedOSVouchers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>

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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .BLDropInputNewForNew {
            width: 5.8%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        .TotalInputosdn span {
            color: #000080;
            font-size: 12px;
        }

        div#logix_CPH_ddlTypes_chzn {
            width: 100% !important;
        }

        .JobNoInputN {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PreparedTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
        }

        .PrepareValue {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
        }

            .PrepareValue span {
                font-family: sans-serif;
            }

        .ApprovedByTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 13px;
            font-family: sans-serif;
            font-weight: bold;
            color: #4e4e4c;
        }

        .ApprovedValue {
            width: auto;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            font-family: sans-serif;
        }

            .ApprovedValue span {
                font-size: 11px;
                font-family: sans-serif;
            }

      /*  div#logix_CPH_lbl_txt {
            position: absolute;
            top: 40px;
            left: 10px;
            width: 74.5%;
            display: flex;
            justify-content: space-between;
        }*/

        a {
            font-size: 12px;
        }

        .FormGroupContent4 textarea {
            height: 98px !important;
        }
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
        .widget-content {
            padding: 0 10px !important;
        }

        .txtcustomer {
            float: left;
            width: 65%;
            margin: 0 0.5% 0 0;
        }

        .VendorRef {
            width: 10%;
            /*float: right;*/
            margin: 0px 0.5% 0px 0px;
        }

        .ChDrop {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VendorRefInput2 {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .chzn-container-single .chzn-single span {
            color: #4e4e4c;
        }

        .DateInput {
            width: 7.2%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        .VesselInput1 {
            width: 9.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        input#logix_CPH_txt_total {
            text-align: right;
        }

        input#logix_CPH_txttotal {
            text-align: right;
        }

        .AgentTextarea {
            width: 75%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipmentTextarea {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipperRight {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipperRight2 {
            width: 24.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .bordertopNew {
            float: left;
            min-height: 1px;
            margin: 5px 0px 0px 0px;
            border-top: 1px solid #807f7f;
            width: 100%;
        }

        .REFNo {
            width: 5.5%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        .TotalInputosdn {
            width: 3%;
            float: right;
            margin: 10px 0px 0px 0px;
        }

        .TotalInputosdn2 {
            width: 11%;
            float: right;
            margin: 0.5% 16px 0px 0px;
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

        .Grid4.MB05 {
            height: 132px !important;
            overflow: auto;
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

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 170px !important;
        }

        .TotalInputosdn3 {
            width: 11%;
            float: right;
            margin: 0.5% 16px 5px 0px;
        }

        .YearBox {
            width: 4.5%;
            float: right;
            margin: 0px 0.5% 0px 0px;
        }

        select#logix_CPH_lstagnst {
            height: 44px !important;
        }

        div#logix_CPH_pnlCCharge {
            margin: 10px 0 0 !important;
                height:140px !important;

        }
 
        select#logix_CPH_lstvol {
            height: 78px !important;
        }
 div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
         iframe#logix_CPH_iframe_outstd {
    height: 89vh !important;
}
         table#logix_CPH_grd td:nth-child(1) {
    width: 133px !important;
}
         table#logix_CPH_grd td:nth-child(2) {
    width: 50px !important;
}
         table#logix_CPH_grd td:nth-child(3) {
    width: 50px !important;
}
         table#logix_CPH_grd td:nth-child(4) {
    width: 70px !important;
}
         table#logix_CPH_grd td:nth-child(5) {
    width: 33px !important;
}





                  table#logix_CPH_grd th:nth-child(1) {
    width: 133px !important;
}
         table#logix_CPH_grd th:nth-child(2) {
    width: 50px !important;
}
         table#logix_CPH_grd th:nth-child(3) {
    width: 50px !important;
}
         table#logix_CPH_grd th:nth-child(4) {
    width: 70px !important;
}
         table#logix_CPH_grd th:nth-child(5) {
    width: 33px !important;
}
         .branch{
             width:15%;
             float:left;
             margin:0px 0.5% 0px 0px;
         }
          .Product{
     width:9%;
     float:left;
     margin:0px 0.5% 0px 0px;
 }
          table#logix_CPH_grd th:nth-child(3) {
    text-align: right;
}
          table#logix_CPH_grd th:nth-child(4) {
    text-align: right;
}
          table#logix_CPH_grd th:nth-child(5) {
    text-align: right;
}
          table#logix_CPH_grd th:nth-child(6) {
    text-align: right;
}
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            });

        }

    </script>

    <link href="../Styles/OSDCN.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:Panel ID="Panel1" runat="server">

        <!-- /Breadcrumbs line -->
        <div>
            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server" id="div_iframe">

                    <div class="widget-header">
                        <div>
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_Header" runat="server" Text="OS DN/CN"> </asp:Label></h4>

                            <!-- Breadcrumbs line -->
                            <div class="crumbs">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li id="homelbl" runat="server"><a href="#"></a>Documentation</li>
                                    <li><a href="#" title="" id="lblHead" runat="server"></a></li>
                                    <li><a href="#" title="" id="lblAcc" runat="server">Accounts</a> </li>
                                    <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">OS DN/CN</a> </li>
                                </ul>
                            </div>
                        </div>
                        <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
                            </div>

                         <div class="FixedButtons">
     <div class="right_btn">
         <div class="right_btn">
             <div class="btn ico-upload">
                 <asp:Button ID="btn_uploadpopup" runat="server" AutoPostBack="true" ToolTip="Upload" TabIndex="16" OnClick="btn_uploadpopup_Click" />

             </div>
             <div class="btn ico-view">
                 <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" TabIndex="14" OnClick="btnview_Click" />
             </div>
             <div class="btn ico-cancel" id="btnback1" runat="server">
                 <asp:Button ID="btnback" runat="server" ToolTip="Cancel" Text="Cancel" TabIndex="15" OnClick="btnback_Click" />
             </div>

         </div>
     </div>
      </div>



                    </div>
                    <div class="widget-content">

                       
                        <div class="FormGroupContent4">
                           
                            <div class="TotalInputosdn2">
                                <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True" placeholder="" TabIndex="1" ToolTip="Total" Visible="false"></asp:TextBox>
                            </div>
                            <div class="TotalInputosdn">
                                <asp:Label Text="Total" ID="Label8" runat="server" Visible="false"></asp:Label>
                            </div>

                        </div>

                        <div class="FormGroupContent4 boxmodal">

                            <div class="branch">
    <asp:Label Text="Branch" ID="Label17" runat="server"></asp:Label>
    <asp:DropDownList ID="ddl_branch" runat="server" CssClass="chzn-select" Data-PlaceHolder="Branch" AutoPostBack="true" BorderColor="#999997" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" TabIndex="8">
    </asp:DropDownList>
</div>

<div class="Product">
    <asp:Label ID="Label13" runat="server" Text="Product"></asp:Label>
    <asp:TextBox ID="txtModule" runat="server" ToolTip="Product" placeholder="" TabIndex="9" CssClass="form-control"></asp:TextBox>
</div>



                            <%--<div class="LabelRef"><asp:Label ID="lbl" runat="server" Text="" style="text-align:center;"> </asp:Label></div>--%>
                            <div class="LblTextpro hide">

                                <asp:Label ID="lbl" runat="server" Text="" Style="text-align: center; color: Red; float: left; margin-left: 38%;"> </asp:Label>
                            </div>


                            <div class="DateInput MB05">
                                <%--<asp:Label ID="lbldate" runat="server" Text="Date" CssClass="LabelValue"></asp:Label>--%>
                                <asp:Label ID="Label12" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="txtvoudate" runat="server" CssClass="form-control" ToolTip="Date" TabIndex="3" placeholder=""></asp:TextBox>
                            </div>
                            <div class="REFNo">
                                <asp:Label Text="Vou #" ID="Label2" runat="server"></asp:Label>
                                <asp:TextBox ID="txtdcn" placeholder="" ToolTip=" Vou #" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="4" OnTextChanged="txtdcn_TextChanged" onkeypress="return isNumberKey(event,'Vou #');"></asp:TextBox>
                            </div>
                            <div class="YearBox">
                                <asp:Label Text="Year" ID="Label1" runat="server"></asp:Label>
                                <asp:TextBox ID="txtyear" runat="server" CssClass="form-control" placeholder="" ToolTip="Year" AutoPostBack="True" TabIndex="5"></asp:TextBox>
                            </div>
                            
                            <div class="BLDropInputNewForNew">
                                <asp:Label Text="Type" ID="Label3" runat="server" ></asp:Label>
                                <asp:DropDownList ID="ddlTypes" runat="server" ToolTip="Type" AutoPostBack="True" Width="100%" data-placeholder="Type" TabIndex="2" CssClass="chzn-select" OnSelectedIndexChanged="ddlTypes_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="5" Text="">OSSI</asp:ListItem>
                                    <asp:ListItem Value="6" Text="">OSPI</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="FormGroupContent4">

                            <div class="JobNoInputN">
                                <asp:Label Text="Job #" ID="lbljobno" runat="server" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtJobno" placeholder="" ToolTip="Job #" Visible="false" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="6" onkeypress="return isNumberKey(event,'Job #');" OnTextChanged="txtJobno_TextChanged"></asp:TextBox>
                            </div>

                            <div class="FormGroupContent4 boxmodal">
                                <div class="AgentTextarea">
                                    <div class="FormGroupContent4 custom-d-flex">

                                        <div class="txtcustomer">
                                            <asp:Label Text="Agent Details" ID="Label6" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtcustomer" placeholder=" " ToolTip="Agent Details" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="7" TextMode="MultiLine" Width="100%" onKeyUp="CheckTextLength(this,50)" Style="resize: none;" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="custom-col">
                                           
                                                
                                            
                                            <div class="FormGroupContent4 custom-d-flex">

                                                <div class="custom-col custom-mr-1">
                                                    <asp:Label Text="Vendor Ref #" ID="Label9" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtVendorRefno" runat="server" ToolTip="Vendor Ref Number" TabIndex="10" placeholder="" CssClass="form-control" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="custom-col">
                                                    <asp:Label Text="Vendor Ref Date" ID="Label10" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtVendorRefnodate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="11" placeholder="" ToolTip="Vendor Ref Date"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="FormGroupContent4 boxmodal">
                                        <div class="FormGroupContent4">
                                            <div class="DebitAdvise">
                                                <asp:Label ID="Label4" runat="server" Text="Receivable from Agent" CssClass="LabelValue" Visible="false"></asp:Label>
                                            </div>
                                            <asp:Panel ID="pnlCCharge" runat="server" CssClass="panel_04 MT0 MB0" ScrollBars="Auto">
                                                <asp:GridView ID="grddebit" TabIndex="12" ShowHeaderWhenEmpty="True" runat="server" BorderColor="#999997" AutoGenerateColumns="False" Width="100%" ForeColor="Black" CssClass="Grid FixedHeader" OnPreRender="grddebit_PreRender">
                                                    <Columns>
                                                        <asp:BoundField DataField="blno" HeaderText="HBL/ MBL #">
                                                            <ControlStyle />
                                                            <HeaderStyle Width="150px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                            <ControlStyle />
                                                            <HeaderStyle />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="curr" HeaderText="Curr" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="bASe" HeaderText="Base/Unit">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="fcamt" HeaderText="F Cur Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                                                        </asp:BoundField>

                                                        <%--<asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                <HeaderStyle HorizontalAlign="Center"  />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>--%>

                                                        <asp:BoundField DataField="amount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                            <ItemStyle HorizontalAlign="right" Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="chargeid" HeaderText="chargeid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>

                                                        <%--<asp:BoundField DataField="blno" HeaderText="HBL/ MBL #">
            <ControlStyle />
            <HeaderStyle  />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>

            <asp:BoundField DataField="chargename" HeaderText="Charges">
            <ControlStyle/>
            <HeaderStyle  />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="curr" HeaderText="Curr">
            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}"   ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Right"  />
            </asp:BoundField>
            <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}"   ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"  >
            <HeaderStyle HorizontalAlign="Center"  />
            <ItemStyle HorizontalAlign="Right"  />
            </asp:BoundField>
            <asp:BoundField DataField="bASe" HeaderText="Base/Unit" >
            <HeaderStyle HorizontalAlign="Center"  />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                <HeaderStyle HorizontalAlign="Center"  />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                <HeaderStyle HorizontalAlign="Center"  />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                <HeaderStyle HorizontalAlign="Center"  />
                <ItemStyle HorizontalAlign="right" />
            </asp:BoundField>
            <asp:BoundField DataField="chargeid" HeaderText="chargeid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>--%>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    <RowStyle Font-Italic="False" />
                                                </asp:GridView>

                                            </asp:Panel>
                                        </div>
                                    </div>

                                </div>

                                <div class="ShipperRight2">

                                    <div class="ConsigneeInput2 TextArea">
                                        <asp:Label Text="Against Ref Details" ID="Label16" runat="server"></asp:Label>
                                        <asp:ListBox ID="lstagnst" runat="server" Width="100%"  ></asp:ListBox>
                                    </div>
                                    <div class=" FormGroupContent4">
                                        <asp:Label Text="Shipment Details" ID="Label7" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtshipment" placeholder=" " ToolTip="Shipment Details" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="13" TextMode="MultiLine" Width="100%" onKeyUp="CheckTextLength(this,50)" Style="resize: none;" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="FormGroupContent4">

                                        <asp:Panel ID="pnlContlist" runat="server" CssClass="lst_cont" ScrollBars="Auto" Visible="false">
                                            <asp:ListBox ID="lstcon" runat="server" Width="100%" Height="100%"></asp:ListBox>
                                        </asp:Panel>

                                        <div class="ConsigneeInput1 TextField TextArea">
                                            <asp:Label Text="Container Details" ID="Label15" runat="server"></asp:Label>
                                            <asp:ListBox ID="lstvol" runat="server" Width="100%" Height="75px"></asp:ListBox>
                                        </div>

                                    </div>
                                </div>

                            </div>
                         
                      

                            <div class="FormGroupContent4" style="display: none;">
                                <div class="DebitAdvise">
                                    <asp:Label ID="Label5" runat="server" Text="Payable to Agent" CssClass="LabelValue" Visible="false"></asp:Label>
                                </div>
                                <asp:Panel ID="Panel2" runat="server" CssClass="panel_04 MT0" ScrollBars="Auto" Visible="false">
                                    <asp:GridView ID="grdcredit" TabIndex="16" ShowHeaderWhenEmpty="True" runat="server" BorderColor="#999997" AutoGenerateColumns="False" Width="100%" ForeColor="Black" CssClass="Grid FixedHeader" OnPreRender="grdcredit_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="blno" HeaderText="HBL/ MBL #">
                                                <ControlStyle />
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                <ControlStyle />
                                                <HeaderStyle />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="curr" HeaderText="Curr" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                <ItemStyle HorizontalAlign="Right" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                <ItemStyle HorizontalAlign="Right" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bASe" HeaderText="Base/Unit">
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                <ItemStyle HorizontalAlign="right" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="chargeid" HeaderText="chargeid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                    </asp:GridView>
                                    <div class="div_break"></div>
                                    <div class="div_break"></div>
                                    <div class="div_break"></div>
                                    <div class="div_break"></div>

                                </asp:Panel>

                            </div>
                            <div class="FormGroupContent4" style="display: none;">

                                <div class="TotalInputosdn3">
                                    <asp:TextBox ID="txttotal" runat="server" Visible="false" CssClass="form-control" AutoPostBack="True" ReadOnly="True" placeholder="" ToolTip="Total"></asp:TextBox>
                                </div>
                                <div class="TotalInputosdn">

                                    <asp:Label ID="Label11" runat="server" Text="Total" Visible="false"></asp:Label>
                                </div>

                            </div>

                            <div class="FormGroupContent4 boxmodal">
                                <div class="gridpnl">
                                    <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grd_RowDataBound" DataKeyNames="LedgerType" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grd_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="ledgername" HeaderText="Particulars" HeaderStyle-CssClass="TextAlignCenter">
                                               <HeaderStyle HorizontalAlign="Left" Width="180px" />
                                                <ItemStyle Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fcur" HeaderText="Curr" HeaderStyle-CssClass="TextAlignCenter">
                                                <HeaderStyle HorizontalAlign="Left" Width="130px" />
                                                <ItemStyle Width="130px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="famt" HeaderText="F Cur Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TextAlignCenter">
                                                <HeaderStyle HorizontalAlign="right" Width="80px" />
                                                <ItemStyle Width="80px" />

                                            </asp:BoundField>
                                            <asp:BoundField DataField="famt" HeaderText="F Cur Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TextAlignCenter">
                                                <HeaderStyle HorizontalAlign="right" Width="80px" />
                                                <ItemStyle Width="80px" />

                                            </asp:BoundField>
                                            <asp:BoundField DataField="ledgeramount" HeaderText="Debit Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TextAlignCenter">
                                                <HeaderStyle HorizontalAlign="right" Width="130px" />
                                                <ItemStyle Width="130px" />

                                            </asp:BoundField>
                                            <asp:BoundField DataField="ledgeramount" HeaderText="Credit Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TextAlignCenter">
                                                <HeaderStyle HorizontalAlign="right" Width="130px" />
                                                <ItemStyle Width="130px" />

                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>

                            <div class="FormGroupContent4">
                                 <div id="lbl_txt" runat="server" visible="false">
     <span class="bluetext">PREPARED BY
             <asp:Label ID="lbl_prepare" runat="server" Text="Prepare Value"></asp:Label></span>

     <div class="ApprovedValue" runat="server" id="lbl_appr">
         <span class="bluetext">APPROVED BY</span>
         <asp:Label ID="lbl_Approve" runat="server" Text="Approved Value"></asp:Label>
     </div>
 </div>
                            </div>

                   
                </div>
            </div>
        </div>
            </div>
    </asp:Panel>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_title" runat="server"></label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="16px" Height="16px" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="GridNew FixedHeader" runat="server" AutoGenerateColumns="true"
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
    <asp:Label ID="Label14" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>

                <asp:Panel runat="Server" ID="popup_upload"  CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
        <div class="DivSecPanel">
            <asp:Image ID="Image2" runat="server" ImageUrl="../Theme/assets/img/buttonIcon/active/close-sm.png" Width="20px" />
        </div>
        <asp:Panel ID="pnl_emp1" runat="server" >
            <div class="">
                <iframe id="iframe_outstd" runat="server" src="" frameborder="0"></iframe>
            </div>
        </asp:Panel>
            </div>
    </asp:Panel>

    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="popup_uploaddoc" runat="server" PopupControlID="popup_upload" TargetControlID="lbl1"
        CancelControlID="Image2">
    </asp:ModalPopupExtender>
    <asp:Label ID="lbl1" runat="server" Text="Label" Style="display: none;"></asp:Label>

            <asp:HiddenField ID="hf_updoc" runat="server" />

    <asp:HiddenField ID="Hid_trantype" runat="server" />
    <asp:HiddenField ID="Hid_HeadTrantype" runat="server" />
    <asp:HiddenField ID="Hid_Curr" runat="server" />
    <asp:HiddenField ID="hid_Tran" runat="server" />
    <asp:HiddenField ID="hid_branch" runat="server" />

</asp:Content>
