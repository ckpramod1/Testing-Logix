<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ImportBlTransfer.aspx.cs" Inherits="logix.FI.ImportBlTransfer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

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

    <link href="../Styles/ImportBlTransfer.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .hide {
            display: none;
        }

        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .div_Grid1 {
            border: 1px solid gray;
            height: 200px;
            margin-bottom: 1%;
            margin-left: 0;
            margin-top: 0.1%;
            width: 100%;
        }

        #logix_CPH_Panel3 {
            height: 420px;
            overflow-x: hidden;
            overflow-y: auto;
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

       .Transfer {
    width: 35%;
    float: left;
    margin: 0 0.5% 0 0;
}

        .JobInput {
            float: left;
            width: 7%;
        }
        .JobDetailsInput1 {
    float: left;
    width: 65%;
    margin: 0px 0px 0px 5px;
}
         div#logix_CPH_div_iframe {
            height: 85vh;
        }
         div#logix_CPH_ddltransfer_chzn {
    width: 100%;
}
         table#logix_CPH_grdJob td:nth-child(9), table#logix_CPH_grdJob td:nth-child(10) {
    max-width: 175px;
    overflow: hidden;
    text-overflow: ellipsis;
}
         .girdpnl {
    overflow: auto;
    margin: 5px 0px;
    height: calc(100vh - 179px);
}
         

/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div>
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblimportbltransfer" runat="server" Text="ImportBLTransfer"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Documentation</a></li>
            <li><a href="#" title="">Ocean Imports</a> </li>
            <li class="current"><a href="#" title="">Import BL Transfer</a> </li>
        </ul>
    </div>
                    </div>
                    <div class="FixedButtons">
     <div class="right_btn">
        <div class="btn ico-transfer-to-icd">
            <asp:Button ID="btnTransfer" runat="server"  Text="Transfer" ToolTip="Transfer" OnClick="btnTransfer_Click" />
        </div>
        <div class="btn ico-back" id="btnBack1" runat="server">
            <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnBack_Click" />
        </div>
    </div>
</div>

                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4  custom-d-flex">
                        <div class="JobInput">
                            <span>Job #</span>
                            <asp:TextBox ID="txtJob" runat="server" AutoPostBack="true" placeholder=" " ToolTip="Job Number" CssClass="form-control" OnTextChanged="txtJob_TextChanged"></asp:TextBox>
                        </div>
                        <div class=" boxmodalLink_box">

                            <asp:LinkButton ID="lnkJob" runat="server" CssClass="anc ico-find-sm" ForeColor="Red" OnClick="lnkJob_Click"></asp:LinkButton>
                        </div>
                        <div class="custom-col custom-mr-05">
                            <asp:Label ID="Label3" runat="server" Text="Job Details"> </asp:Label>
                            <asp:TextBox ID="txtJobdetails" runat="server" placeholder="" ToolTip="Job Details" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="Transfer fit-content">
                            <asp:Label ID="Label2" runat="server" Text="Transfer"> </asp:Label>
                            <asp:DropDownList ID="ddltransfer" runat="server" CssClass="chzn-select" data-placeholder="Transfer" ToolTip="Transfer" AutoPostBack="true" OnSelectedIndexChanged="ddltransfer_SelectedIndexChanged"></asp:DropDownList>

                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="girdpnl MB0">
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" Width="100%" CssClass="Grid FixedHeader" OnPreRender="grd_PreRender" >
                                <Columns>
                                    <asp:BoundField DataField="blno" HeaderText="BL #" />
                                    <asp:BoundField DataField="bldate" HeaderText="Date" />
                                    <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                                    <asp:BoundField DataField="fd" HeaderText="Place of Delivery" />
                                    <asp:TemplateField HeaderText="Select" HeaderStyle-Font-Size="10pt">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkStatus" runat="server" AutoPostBack="true" />
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="volume" HeaderText="volume" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="bid" HeaderText="BID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="cid" HeaderText="CID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>
                    </div>
                
                  
                    <div class="FormGroupContent4">
                        <asp:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="Label1" BehaviorID="programmaticModalPopupBehavior1"
                            PopupControlID="pnlJobAE" DropShadow="false"
                            CancelControlID="close">
                        </asp:ModalPopupExtender>

                        <asp:Panel ID="pnlJobAE" runat="server" CssClass="modalPopup" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                                    <asp:GridView ID="grdJob" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true"
                                        Width="100%" ForeColor="Black" EmptyDataText="No Record Found" CssClass="Grid FixedHeader"  OnRowDataBound="grdJob_RowDataBound"
                                        OnSelectedIndexChanged="grdJob_SelectedIndexChanged" OnRowCommand="grdJob_RowCommand">
                                        <Columns>
                                        </Columns>

                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                        </asp:Panel>

                        <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hf_rbid" runat="server" />
    <asp:HiddenField ID="hf_portid" runat="server" />
</asp:Content>
