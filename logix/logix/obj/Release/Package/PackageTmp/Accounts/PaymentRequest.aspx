<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="PaymentRequest.aspx.cs" Inherits="logix.Accounts.PaymentRequest" %>


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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />



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

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Smartphone Touch Events -->








    <script src="../Scripts/x.js" type="text/javascript"></script>
    <script src="../Scripts/xtableheaderfixed.js" type="text/javascript"></script>

    <link href="../Styles/ChequeRequest.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
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

        div#logix_CPH_drp_SortedBy_chzn {
            width: 100px !important;
        }

        .CreditNoteO label, .CreditNote label {
               margin-left: 4px;
    font-size: 14px;
    font-weight: 500;
        }
        .div_lbl_remark {
    width: 71%;
    float: left;
    margin-top: 0.5%;
    margin-left: 0px !important;

}
    </style>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

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
            /*background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8; */
            background-color: Black;
            /* filter: alpha(opacity=40);*/
            /*opacity: 0.5; */
        }

        .modalPopup1 {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 1042px;
            Height: 555px;
            margin-left: -2%;
            margin-top: -1.5%;
            /*padding:1px;            
            display:none;*/
        }

        .modalPopup2 {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 100%;
            Height: 528px;
            margin-left: 0%;
            margin-top: 0%;
            /*padding:1px;            
            display:none;*/
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
            /*width: 100%;
    height: 90%;*/
            width: 200px;
            Height: 305px;
            float: left;
            text-align: center;
            /*overflow-y:scroll;*/
        }

        #logix_CPH_popup_favour_foregroundElement {
            top: 360px !important;
        }



        #logix_CPH_pln_cheque {
            left: 0px !important;
            top: 36px !important;
        }



        .div_lbl {
            font-size: 11px;
        }

        .CreditNote {
            float: left;
    margin: 15px 0px 0px 0px;
            width: 9%;
        }

        .TotlaChk {
            width: 55%;
            float: left;
            margin: 0px 1% 0px 0px;
            text-align: right;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

  
        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }



        .TotlaChk {
            width: 31%;
            float: left;
            margin: 20px 1% 0px 0px;
            text-align: right;
        }

        .CreditNoteO {
            width: 12%;
            float: left;
            margin: 15px 0.5% 0px 0px;
            color: #000080;
        }

       

        /*#logix_CPH_panel {
    height: 519px !important;
    border: 0px;
}*/
        .chzn-search span {
            display: none;
        }

        .PendingPayments {
            width: auto;
            margin-right: 0.5%;
        }
 
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
    </style>

    <script type="text/javascript" language="javascript">
        xAddEventListener(window, 'load',
       function () { new xTableHeaderFixed('gvTheGrid', 'table-container', 0); }, false);


        function TxtFocus() {
            var el = $("#<%=txt_search.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }

        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "ChequeRequest.aspx/GetVouno",
                data: '{Prefix: "' + $("#<%=txt_search.ClientID %>").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    //alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            $("#<%=btn_search.ClientID %>").click();
        }

    </script>


    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            $(document).ready(function () {
                $("#<%=txt_Filterby.ClientID %>").autocomplete({

                    source: function (request, response) {

                        $.ajax({
                            url: "../Accounts/ChequeRequest.aspx/ApprovedBy_Name",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Payment Request"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li id="menulbl" runat="server" visible="false"><a href="#"></a>Ops & Docs</li>
                            <li><a href="#" id="lblHead" runat="server"></a></li>
                            <li><a href="#" title="" id="HeaderID" runat="server"></a></li>
                            <li class="current"><a href="#" title="" id="headerid1" runat="server">Invoice</a> </li>
                        </ul>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FixedButtons">
                          <div class="right_btn">
                                    <div class="btn ico-update" runat="server"  id="btn_update_id" >
                                        <asp:Button ID="btn_update" runat="server" Text="Update" ToolTip="Update" OnClick="btn_update_Click" />

                                    </div>

                                    <div class="btn ico-send" style="display: none;">
                                        <asp:Button ID="btn_search" runat="server"  OnClick="btn_search_Click" />
                                    </div>
                                    <div class="btn ico-cancel" id="btn_cancel2" runat="server">
                                        <asp:Button ID="Btn_cancel" runat="server"  ToolTip="Cancel" Text="Cancel" OnClick="Btn_cancel_Click" Visible="false" />

                                    </div>
                                </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="CreditNoteO">
                            <asp:RadioButton ID="rbt_CNOP" runat="server" AutoPostBack="True" GroupName="rbt"
                                OnCheckedChanged="rbt_CNOP_CheckedChanged" /><label>Purchase Invoice</label>
                        </div>
                        <div class="CreditNote">
                            <asp:RadioButton ID="rbt_CN" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_CN_CheckedChanged" /><label>Credit Note</label>
                        </div>
                        <div class="CreditNoteO">
                            <asp:RadioButton ID="rbt_CNAdmin" runat="server" AutoPostBack="True" GroupName="rbt"
                                OnCheckedChanged="rbt_CNAdmin_CheckedChanged" Text="Credit Note - Admin" />
                        </div>
                        <div class="CreditNote">
                            <asp:RadioButton ID="rbt_cheque" runat="server" AutoPostBack="True" GroupName="rbt"
                                OnCheckedChanged="rbt_cheque_CheckedChanged" Text="Not Over Cheque" />
                        </div>

                        <%--<div style="border-bottom: 1px dotted #b1b1b1; height: 1px; float: left; width: 100%; margin: 5px 0px 5px 0px;"></div>--%>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div style="float: left; width: 41%; margin: 0px 0.5% 0px 0px;">
                            <asp:Label ID="lbl_Filterby" runat="server" Text="Vendor"> </asp:Label>
                            <asp:TextBox ID="txt_Filterby" runat="server" ToolTip="Vendor" Placeholder="" CssClass="form-control" Width="100%" AutoPostBack="true" OnTextChanged="txt_Filterby_TextChanged"></asp:TextBox>
                        </div>

                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <asp:Label ID="Label2" runat="server" Text="Sort By"></asp:Label>

                            <asp:DropDownList ID="drp_SortedBy" runat="server" CssClass="chzn-select" Height="23px" ToolTip="Sort By" OnSelectedIndexChanged="drp_SortedBy_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">Sort By</asp:ListItem>
                                <asp:ListItem Value="Vouno">Vou #</asp:ListItem>
                                <asp:ListItem Value="VouDate">Vou Date</asp:ListItem>
                                <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                <asp:ListItem Value="PAAmount">VouAmt</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="ETA">
                            <asp:Label ID="Label3" runat="server" Text="Search Vou#"> </asp:Label>
                            <asp:TextBox ID="txt_search" placeholder="" runat="server" ToolTip="Search Vou Number" AutoPostBack="True" CssClass="form-control" onkeyup="GetDetail();"></asp:TextBox>
                        </div>


                       <%-- commented by praveen 12-May-2023--%>
                        <%--<asp:LinkButton ID="Lnk_Pending" CssClass="boxmodalLink" runat="server" ForeColor="Red" OnClick="Lnk_Pending_Click">Pending Payment</asp:LinkButton>--%>


                 
                        
                        <asp:LinkButton ID="Lnk_Pending" CssClass="anc ico-find-sm" runat="server" ForeColor="Red" OnClick="Lnk_Pending_Click"></asp:LinkButton>
 
                    </div>

                    <%--PageSize="15" OnPageIndexChanging="Grd_Cheque_PageIndexChanging" AllowPaging="false" OnPreRender="Grd_Cheque_PreRender" OnSorting="Grd_Cheque_Sorting" AllowSorting="true"--%>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="panel" runat="server" CssClass="gridpnl MB0">
                            <asp:GridView ID="Grd_Cheque" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" DataKeyNames="vouyear,bid,blno,jobno,trantype,vouno"
                                OnRowDataBound="Grd_Cheque_DataBound" ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="false" PageSize="10"
                                OnPageIndexChanging="Grd_Cheque_PageIndexChanging" OnPreRender="Grd_Cheque_PreRender" OnSorting="Grd_Cheque_Sorting" AllowSorting="true">

                                <Columns>

                                    <asp:TemplateField HeaderText="PI #"><%-- 0--%>
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 40px;">
                                                <asp:LinkButton ID="Lnk_Vouno" runat="server" CommandName="select" ForeColor="Red" OnClick="Lnk_Vouno_Click" Text='<%#Eval("vouno")%>'></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="true" Width="20px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="voudate" HeaderText="Date"><%--1 SortExpression="voudate"--%>
                                        <HeaderStyle Width="50px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="duedate" HeaderText="Due Date"><%--2--%>
                                        <HeaderStyle Width="50px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Vendor" HeaderStyle-ForeColor="White"><%--3--%>
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 300px">
                                                <asp:Label ID="custname" runat="server" Text='<%# Bind("custname") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="45px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Favouring"><%--4--%>
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 300px">
                                                <asp:LinkButton ID="Lnk" runat="server" OnClick="lnkCheque_Click" Text='<%#Eval("custname")%>' ToolTip='<%#Eval("custname")%>'
                                                    ForeColor="Red"></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="approvedby" HeaderText="Approved By"><%--5--%>
                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="vouamt" HeaderText="Voucher Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--6--%>
                                        <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="TxtAlign1" Width="150px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="tdsamt" HeaderText="TDSAmount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--7--%>
                                        <HeaderStyle Wrap="false" Width="150px" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="TxtAlign1" Width="150px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Mode"><%--8--%>
                                        <HeaderStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_module" runat="server" CssClass="" placeholder="--MODE--" ToolTip="MODE">
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

                                    <asp:TemplateField><%--9--%>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chk_Select" runat="server" OnCheckedChanged="Chkselect_Click" AutoPostBack="true" />
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField><%--10--%>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hid_name" runat="server" Value='<%#Eval("favourname") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:TemplateField>

                                    <asp:TemplateField><%--11--%>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hid_remark" runat="server" Value='<%#Eval("remark") %>' />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="hidden"></ControlStyle>
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="vouyear" HeaderText="vouyear"><%--12--%>
                                        <ControlStyle CssClass="hidden"></ControlStyle>
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="bid" HeaderText="bid"><%--13--%>
                                        <ControlStyle CssClass="hidden"></ControlStyle>
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="blno" HeaderText="blno"><%--14--%>
                                        <ControlStyle CssClass="hidden"></ControlStyle>
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="jobno" HeaderText="jobno"><%--15--%>
                                        <ControlStyle CssClass="hidden"></ControlStyle>
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="trantype" HeaderText="trantype"><%--16--%>
                                        <ControlStyle CssClass="hidden"></ControlStyle>
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </asp:Panel>

                        <div class="FormGroupContent4">

                            <div class="FloatRight2 hide">
                                <div class="TotlaChk">
                                    <asp:Label ID="lbl_total" runat="server" Text="Total Payment Request Amount" Font-Bold="True"
                                        ></asp:Label>
                                </div>
                                <div class="TotalInput2">
                                    <asp:Label ID="Label4" runat="server" Text="VouAmt"> </asp:Label>
                                    <asp:TextBox ID="txt_PAamount" runat="server" CssClass="form-control" ToolTip="VouAmt" placeholder=""></asp:TextBox>
                                </div>
                                <div class="TotalInput3">
                                    <asp:Label ID="Label5" runat="server" Text="TDS Amount"> </asp:Label>
                                    <asp:TextBox ID="txt_TDSamount" runat="server" CssClass="form-control" ToolTip="TDS Amount" placeholder=""></asp:TextBox>
                                </div>
                              

                            </div>
                        </div>

                    </div>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_popup" runat="server" CssClass="div_frame1" Style="display: none;">
                        </asp:Panel>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="panel1" runat="server" Visible="false" ScrollBars="Both" CssClass="gridpnl">
                            <asp:GridView ID="Grd_Payment" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" EmptyDataText="No Record Found" BackColor="White"
                                CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" DataKeyNames="vouyear,remarks,bid,blno,jobno,trantype,favourname,approvedby,mode"
                                OnRowDataBound="Grd_Payment_RowDataBound">
                                <Columns>

                                    <asp:BoundField DataField="vouno" HeaderText="PI #">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Center" Width="50px" />
                                        <ItemStyle HorizontalAlign="Left" Width="50px" />
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
                            <div class="DivSecPanel" >
                                <asp:Image ID="img_detail" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>
                           
                          
                            <div class="div_lbl">
                                <asp:Label ID="lbl_favour" runat="server" Text="Favouring"></asp:Label>
                                <asp:TextBox ID="txt_favouring" runat="server"></asp:TextBox>
                            </div>
                           
                            <div class="div_lbl_mode">
                                <asp:Label ID="lbl_mode" runat="server" Text="Mode"></asp:Label>

                                <asp:TextBox ID="txt_mode" runat="server"></asp:TextBox>
                            </div>
                            <div class="div_lbl_remark">
                                <asp:Label ID="lbl_remark" runat="server" Text="Remark"></asp:Label>

                                <asp:TextBox ID="txt_remark" runat="server"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <%--<div class="FormGroupContent4">--%>
                    <asp:Panel ID="pln_favour" runat="server" CssClass="modalPopup" Style="display: none;">
                        <div class="divRoated">
                            <div class=" DivSecPanel">
                                <asp:Image ID="img_favour" runat="server" ImageAlign="Baseline" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>


                            <div class="div_lbl">
                                <asp:Label ID="lbl_favour_cheque" runat="server" Text="Favouring"></asp:Label>
                                <asp:TextBox ID="txt_favour_cheque" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_favour_cheque_TextChanged" runat="server"></asp:TextBox>
                            </div>


                            <div class="div_lbl">
                                <asp:Label ID="lbl_remark_cheque" runat="server" Text="Remark"></asp:Label>
                                <asp:TextBox ID="txt_remark_cheque" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_remark_cheque_TextChanged" runat="server"></asp:TextBox>
                            </div>

                            <%--<div class="right_btn MB10 Mt5 MR5">
                            <div class="btn btn-update">
                                <asp:Button ID="btn_add" runat="server" Text="Update" OnClick="btn_add_Click" />
                            </div>
                        </div>--%>
                        </div>
                    </asp:Panel>
                    <%--</div>--%>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_cheque" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="Close_Cheque" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                                </div>
                                <div class="div_Break">
                                </div>
                                <div class="">
                                    <iframe id="iframecost" runat="server" src="" frameborder="0" class="" style="background-color: #FFFFFF"></iframe>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:ModalPopupExtender runat="server" ID="pln_Grg"
                            PopupControlID="pln_popup" CancelControlID="close" TargetControlID="hid_id" DropShadow="false">
                        </asp:ModalPopupExtender>

                        <asp:ModalPopupExtender runat="server" ID="popup_detail"
                            PopupControlID="pln_detail" CancelControlID="img_detail" TargetControlID="hid_details" DropShadow="false">
                        </asp:ModalPopupExtender>

                        <asp:ModalPopupExtender runat="server" ID="popup_favour"
                            PopupControlID="pln_favour" CancelControlID="img_favour" TargetControlID="hid_favours" DropShadow="false">
                        </asp:ModalPopupExtender>


                        <asp:ModalPopupExtender runat="server" ID="popup_cheque"
                            PopupControlID="pln_cheque" CancelControlID="Close_Cheque" TargetControlID="hid_cheques" DropShadow="false">
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
    </div>


</asp:Content>








