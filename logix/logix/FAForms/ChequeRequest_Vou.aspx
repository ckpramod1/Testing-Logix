<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ChequeRequest_Vou.aspx.cs"
    Inherits="logix.FAForm.ChequeRequest_Vou" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    
    <link href="../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/icons.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/fontawesome/font-awesome.min.css" rel="stylesheet" />
    <link href="../Styles/ChequeRequest.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

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
        .widget.box{
    position: relative;
    top: -8px;
} 
        div#logix_CPH_div_iframe .widget-content {
    top: 12px !important;
}
.TotalInput3.TextField span ,.TotalInput2.TextField span{
    text-align: right;
}
    </style>

    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" />
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

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <script type="text/javascript">        
        function pageLoad(sender, args) {         

            $(document).ready(function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

                $('.selectpicker').selectpicker();

                "use strict";

                App.init(); // Init layout and core plugins
                Plugins.init(); // Init all plugins
                FormComponents.init(); // Init all form-specific plugins

                //$('select.styled').customSelect();

            });

        }

    </script>

    <%--<script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_Filterby.ClientID %>").autocomplete({
                    source: function (request, response) {
                     
                        $.ajax({
                            url: "../FAForms/ChequeRequest.aspx/ApprovedBy_Name",
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
                        $("#<%=txt_Filterby.ClientID %>").val(i.item.label);
                        $("#<%=txt_Filterby.ClientID %>").change();                     
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Filterby.ClientID %>").val(i.item.label);                       
                    },
                    change: function (event, i) {
                        $("#<%=txt_Filterby.ClientID %>").val(i.item.label);                       
                    },
                    close: function (event, i) {
                        $("#<%=txt_Filterby.ClientID %>").val(i.item.label);                        
                    },

                    minLength: 1
                });
            });
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }

        </script>--%>

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

        .CreditNote input {
            float: left;
            margin: 3px 5px;
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
    </style>

    <style type="text/css">
        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .modalBackground {
            background-color: Black;
        }

        .modalPopupss1 {
            background-color: #FFFFFF;
            border-style: solid;
            border-color: #CCCCCC;
            width: 1042px;
            Height: 555px;
            margin-left: -2%;
            margin-top: -1.5%;
        }

        .modalPopupss2 {
            background-color: #FFFFFF;
            border-style: solid;
            border-color: #CCCCCC;
            width: 100%;
            Height: 528px;
            margin-left: 0%;
            margin-top: 0%;
        }

        .modalPopupss {
            background-color: white;
            border-width: 3px;
            border: 1px solid black;
            width: 530px;
            height: 150px;
            margin-left: 0%;
            margin-top: -15%;
        }

        .Gridpnl {
            width: 1024px;
            Height: 500px;
        }

        .GridpnChk {
            width: 100%;
            Height: 465px;
        }

        .Hide {
            display: none;
        }

        .popupdiv {
            margin-top: 1%;
        }

        .div_frame1 {
            width: 200px;
            Height: 305px;
            float: left;
            text-align: center;
        }

        #logix_CPH_popup_favour_foregroundElement {
            top: 360px !important;
        }

        #logix_CPH_pln_cheque {
            left: 0px !important;
            top: 36px !important;
        }

        #logix_CPH_pln_favour {
            top: 410px !important;
        }

        .div_lbl {
            font-size: 11px;
        }
    </style>

    <%--<script type="text/javascript">
       function pageLoad(sender, args) {
           $(document).ready(function () {
               $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
           });
       }
    </script>--%>
    <style type="text/css">
        .Grid3 {
            border: 1px solid #b1b1b1;
            height: 100%;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 99%;
            margin: 0px auto 0px auto;
        }

        .CreditNote_vouyear {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .CreditNote_vouyear input {
                /*width:84%;
            height:19px;
            float:left;*/
            }

        .CreditNoteO {
            width: 12%;
    float: left;
    margin: 20px 0.5% 0px 6px;
    font-size: 14px;
    color: #06529c;
    font-weight: 500;
        }

        .Save-btn input {
            background-color: #99c794;
            border: none;
            float: left;
            padding: 3px 14px 3px 14px;
            color: #ffffff;
            font-size: 14px;
        }

        .SortBy {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditNote {
           float: left;
    margin: 20px 0 0;
    width: 8%;
    font-size: 14px;
    color: #06529c;
    font-weight: 500;
        }

        .CreditNoteRbt {
            float: left;
            margin: -2px 0 0;
            width: 10%;
            font-size: 11px;
        }

            .CreditNoteRbt input {
                float: left;
            }

        .CreditNoteOAdmin {
            float: left;
            margin: 0 0.5% 0 6px;
            width: 10%;
        }

            .CreditNoteOAdmin input {
                float: left;
                margin: 3px 5px 0px 0px;
            }

        .CreditNoteRbt input {
            float: left;
            margin: 3px 5px 0px 0px;
        }

        .CreditNote label {
            display: inline-block;
            float: left;
            font-size: 11px;
            margin: -4px 0 0 5px;
            width: 80px;
        }

        .ChkTillDate span, label {
            display: inline-block;
            float: left;
            font-size: 11px;
            width: 90px;
            margin: -3px 0 0 4px;
        }

        #logix_CPH_ddl_Sorting_chzn {
            width: 100% !important;
        }

        .chzn-drop {
            height: 210px !important;
            overflow: hidden;
            width: 159px !important;
        }

        .CreditNoteOAdmin {
            font-size: 11px;
        }

        .TotlaChk {
            width: 10%;
            float: left;
            margin: 5px 0.5% 0px 0px;
        }
        .btn.btn-update1 {
    margin: 10px 0px 0px;
}
        .TotalInput3 {
    width: 15%;
    float: left;
    margin: 0px 71px 0px 0px;
}
        .TotalInput2 {
    width: 17.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .FloatRight2 {
    width: 50%;
    display: flex;
    float: right;
    justify-content: flex-end;
    
}

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #4d4d4d;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
  
        .btn.btn-get1 {
    margin: 10px 0px 0px;
}
        .CreditNoteOAdmin {
           font-size: 14px;
    color: #06529c;
        font-weight: 500;
             margin: 20px  0.5% 0px 6px;
        }

        .CreditNoteRbt {
                float: left;
    margin: 20px 0 0;
    width: 10%;
    font-size: 14px;
    color: #06529c;
    font-weight: 500;
        }

       
        .CreditNoteO input {
    float: left;
    margin: 3px 5px 0px 0px;
}
        .btn.ico-get {
    margin-top: 7px;
}
        .PendingPayments {
    width: fit-content;
    float: right;
    margin: 0px 0px 0px 0px;
    width: 1.5%;
    text-align:right;
}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

        <div class="">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide" style="padding-left: 10px;"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text=""> </asp:Label></h4>
                      <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Vouchers</a> </li>
            <li><a href="#" title="">Payment Request Vouyearwise</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CreditNoteO">
                            <asp:RadioButton ID="rbt_CNOP" runat="server" GroupName="rbt" OnCheckedChanged="rbt_CNOP_CheckedChanged" AutoPostBack="true" /><div style="margin: 2px 0px 0px 0px;">Purchase Invoice</div>
                        </div>
                        <div class="CreditNote">
                            <asp:RadioButton ID="rbt_CN" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_CN_CheckedChanged" /><div style="margin: 2px 0px 0px 0px;">Credit Note</div>
                        </div>
                        <div class="CreditNoteOAdmin">
                            <asp:RadioButton ID="rbt_CNAdmin" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_CNAdmin_CheckedChanged" /><div id="rbt_CNAdmin_id" runat="server"  style="margin: 2px 0px 0px 0px;">Admin Purchase Invoice</div>
                        </div>
                        <div class="CreditNoteRbt" runat="server" id="notovercheque_rbt">
                            <asp:RadioButton ID="rbt_cheque" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_cheque_CheckedChanged" /><div style="margin: 2px 0px 0px 0px;">Not Over Cheque</div>
                        </div>
                        <div class="SortBy">
                            <asp:Label ID="Label1" runat="server" Text="Sort By"> </asp:Label>
                            
                            <asp:DropDownList ID="ddl_Sorting" runat="server" CssClass="chzn-select form-control" Height="23px" ToolTip="Sort By" OnSelectedIndexChanged="ddl_Sorting_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">Sort By</asp:ListItem>
                                <asp:ListItem Value="Vouno">Vou #</asp:ListItem>
                                <asp:ListItem Value="Vou Date">Vou Date</asp:ListItem>
                                <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                <asp:ListItem Value="PAAmount">VouAmt</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="CreditNote_vouyear">
                            <asp:Label ID="Label2" runat="server" Text="Vou Year"> </asp:Label>
                            <asp:TextBox ID="txt_VouYear" runat="server" CssClass="form-control" Placeholder="" ToolTip="Vouyear"></asp:TextBox>

                        </div>
                        <div class="btn ico-get">
                            <asp:Button ID="btn_Get" runat="server" Text="Get" ToolTip="Get" OnClick="btn_Get_Click" />
                        </div>
                        <div class="PendingPayments">
                            <asp:LinkButton ID="Lnk_Pending" runat="server" CssClass="anc ico-find-sm" ForeColor="Red" OnClick="Lnk_Pending_Click"></asp:LinkButton>
                        </div>

                    </div>

                    <div class="FormGroupContent4 boxmodal">

                    <div class="FormGroupContent4">
                        <asp:Panel ID="panel" runat="server" ScrollBars="Vertical" CssClass="gridpnl MB0">
                            <asp:GridView ID="Grd_Cheque" runat="server" AllowPaging="true" AutoGenerateColumns="false" class="Grid FixedHeader"  PageSize="15"
                                DataKeyNames="vouyear,bid,blno,jobno,trantype,vouno" ShowHeaderWhenEmpty="True" Width="100%" OnPageIndexChanging="Grd_Cheque_PageIndexChanging">
                                <%--PageSize="30"--%>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                <asp:LinkButton ID="Lnk_Vouno" runat="server" CommandName="select" ForeColor="Red" OnClick="Lnk_Vouno_Click" Text='<%#Eval("vouno")%>'></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="voudate" HeaderText="Date">
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="duedate" HeaderText="DueDate">
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="custname" HeaderText="Vendor" />
                                    <asp:TemplateField HeaderText="Favouring">
                                      
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 140px">
                                                <asp:LinkButton ID="custname" runat="server" OnClick="lnkCheque_Click" Text='<%#Eval("custname") %>' ToolTip='<%#Eval("custname")%>' ForeColor="Red"></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="150px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="approvedby" HeaderText="Approved By">
                                        <HeaderStyle Wrap="false" Width="150px"  HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="150px"  HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vouamt" HeaderText="Vou Amt" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Wrap="false" Width="150px"  HorizontalAlign="Center" />
                                        <ItemStyle CssClass="TxtAlign1" Width="150px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tdsamt" HeaderText="TDS Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="TxtAlign1" Width="150px"  />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Mode">
                                        <HeaderStyle Width="100px"  />
                                        <ItemStyle Width="100px"  />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_module" Width="100%" runat="server" Placeholder="--MODE--" ToolTip="MODE">
                                                <asp:ListItem Value="C">Cheque</asp:ListItem>
                                                <asp:ListItem Value="S">Cash</asp:ListItem>
                                                <asp:ListItem Value="D">DD</asp:ListItem>
                                                <asp:ListItem Value="N">NEFT</asp:ListItem>
                                                <asp:ListItem Value="R">RTGS</asp:ListItem>
                                                <asp:ListItem Value="A">Adjust</asp:ListItem>
                                                <asp:ListItem Value="T">Not Over</asp:ListItem>
                                                <asp:ListItem Value="O">Others</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chk_Select" runat="server" OnCheckedChanged="Chkselect_Click" AutoPostBack="true" />
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="20px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>

                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="FloatRight2">
                            <div class="TotlaChk hide">
                                <asp:Label ID="lbl_total" runat="server" Text="Total Amount" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                            </div>
                            <div class="TotalInput2">
                                <asp:Label ID="Label3" CssClass="hide"  runat="server" Text="Vou Amt"> </asp:Label>
                                <asp:TextBox ID="txt_PAamount" runat="server" CssClass="form-control" ToolTip="Vou Amt" placeholder=""></asp:TextBox>
                            </div>
                            <div class="TotalInput3">
                                <asp:Label ID="Label5" runat="server" CssClass="hide"  Text="TDS Amount"> </asp:Label>
                                <asp:TextBox ID="txt_TDSamount" runat="server" CssClass="form-control" ToolTip="TDS Amount" placeholder=""></asp:TextBox>
                            </div>
                            <div class="right_btn ">
                                <div class="btn ico-update">
                                    <asp:Button ID="btn_update" runat="server" Text="Update" ToolTip="Update" OnClick="btn_update_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                        </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_popup" runat="server" CssClass="" Style="display: none;"></asp:Panel>
                    </div>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="panel1" runat="server" Visible="false" ScrollBars="Both" CssClass="Grid div_Grd_popup">
                            <asp:GridView ID="Grd_Payment" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White"
                                CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" DataKeyNames="vouyear,remarks,bid,blno,jobno,trantype,favourname,approvedby,mode" OnRowDataBound="Grd_Payment_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="vouno" HeaderText="PI #">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="voudate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Vendor">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 195px">
                                                <asp:LinkButton ID="Lnk" runat="server" OnClick="lnkdetail_Click" Text='<%#Eval("custname")%>' ToolTip='<%#Eval("custname")%>'
                                                    ForeColor="Red"></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="vouamt" HeaderText="VouAmt" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tdsamt" HeaderText="TDSAmount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="VslVoy">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                <asp:Label ID="lbl" runat="server" Text='<%#Eval("Shipper")%>' ToolTip='<%#Eval("Shipper")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RequestedOn">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="lbl_chqreqon" runat="server" Text='<%#Eval("chqreqon")%>' ToolTip='<%#Eval("chqreqon")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BR AppOn">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="lbl_brappon" runat="server" Text='<%#Eval("brappon")%>' ToolTip='<%#Eval("brappon")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CO AppOn">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="lbl_coappon" runat="server" Text='<%#Eval("coappon")%>' ToolTip='<%#Eval("coappon")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_detail" runat="server" CssClass="modalPopup " Style="display: none;">
                         
                            <div class="divRoated">
                                   <div class=" DivSecPanel">
                                <asp:Image ID="img_detail" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>
                            <div class="div_Break">
                            </div>
                            <div class="div_lbl">
                                <asp:Label ID="lbl_favour" runat="server" Text="Favouring"></asp:Label>
                            </div>
                            <div class="div_Break">
                            </div>
                            <div class="div_lbl">
                                <asp:TextBox ID="txt_favouring" runat="server"></asp:TextBox>
                            </div>
                            <div class="div_Break">
                            </div>
                            <div class="div_lbl_mode">
                                <asp:Label ID="lbl_mode" runat="server" Text="Mode"></asp:Label>
                            </div>
                            <div class="div_lbl_remark">
                                <asp:Label ID="lbl_remark" runat="server" Text="Remark"></asp:Label>
                            </div>
                            <div class="div_Break">
                            </div>
                            <div class="div_lbl_mode">
                                <asp:TextBox ID="txt_mode" runat="server"></asp:TextBox>
                            </div>
                            <div class="div_lbl_remark">
                                <asp:TextBox ID="txt_remark" runat="server"></asp:TextBox>
                            </div>
                                </div>
                        </asp:Panel>
                    </div>

                    <asp:Panel ID="pln_favour" runat="server" CssClass="modalPopup" Style="display: none;">
                        <div class="divRoated">
                        <div class=" DivSecPanel">
                            <asp:Image ID="img_favour" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                        </div>
                        <div class="div_Break">
                        </div>
                        <div class="div_lbl">
                            <asp:Label ID="lbl_favour_cheque" runat="server" Text="Favouring"></asp:Label>
                        </div>
                        <div class="div_Break">
                        </div>
                        <div class="div_lbl">
                            <asp:TextBox ID="txt_favour_cheque" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_favour_cheque_TextChanged" runat="server"></asp:TextBox>
                        </div>
                        <div class="div_Break">
                        </div>
                        <div class="div_lbl">
                            <asp:Label ID="lbl_remark_cheque" runat="server" Text="Remark"></asp:Label>
                        </div>
                        <div class="div_Break">
                        </div>
                        <div class="div_lbl">
                            <asp:TextBox ID="txt_remark_cheque" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_remark_cheque_TextChanged" runat="server"></asp:TextBox>
                        </div>
                        <div class="div_Break">
                        </div>
                            </div>
                    </asp:Panel>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_cheque" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                            <div class=" DivSecPanel">
                                <asp:Image ID="Close_Cheque" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                            </div>
                            <div class="div_Break">
                            </div>
                            <div >
                                <iframe id="iframecost" runat="server" src="" frameborder="0" style="background-color: #FFFFFF"></iframe>
                            </div>
                                </div>
                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4">

                        <asp:ModalPopupExtender runat="server" ID="pln_Grg" PopupControlID="pln_popup" CancelControlID="close" TargetControlID="hid_id" DropShadow="false">
                        </asp:ModalPopupExtender>

                        <asp:ModalPopupExtender runat="server" ID="popup_detail" PopupControlID="pln_detail" CancelControlID="img_detail" TargetControlID="hid_details" DropShadow="false">
                        </asp:ModalPopupExtender>

                        <asp:ModalPopupExtender runat="server" ID="popup_favour" PopupControlID="pln_favour" CancelControlID="img_favour" TargetControlID="hid_favours" DropShadow="false">
                        </asp:ModalPopupExtender>

                        <asp:ModalPopupExtender runat="server" ID="popup_cheque" PopupControlID="pln_cheque" CancelControlID="Close_Cheque" TargetControlID="hid_cheques" DropShadow="false">
                        </asp:ModalPopupExtender>

                        <asp:Label ID="hid_id" runat="server"></asp:Label>
                        <asp:Label ID="hid_details" runat="server"></asp:Label>
                        <asp:Label ID="hid_favours" runat="server"></asp:Label>
                        <asp:HiddenField ID="hid_confirm" runat="server" />
                        <asp:HiddenField ID="hid_row" runat="server" />
                        <asp:Label ID="hid_cheques" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
   
    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>ChequeRequest Vouyearwise #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
    
</asp:Content>
