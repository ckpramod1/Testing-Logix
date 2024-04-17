<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ChequeRequest.aspx.cs"
    Inherits="logix.FAForm.ChequeRequest" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- For AutoComplete -->

    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />

    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/ChequeRequest.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

}

    </script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

                <%-- $(document).ready(function () {

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
            });--%>

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

            <%-------------------------VouNo----------------------%>

            $(document).ready(function () {

                $("#<%=txt_vouno.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../FAForms/ChequeRequest.aspx/Vouno",
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
                        $("#<%=txt_vouno.ClientID %>").val(i.item.label);
                        $("#<%=txt_vouno.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_vouno.ClientID %>").val(i.item.label);
                    },
                    change: function (event, i) {
                        $("#<%=txt_vouno.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        $("#<%=txt_vouno.ClientID %>").val(i.item.label);
                        },

                        minLength: 1
                });
            });

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

                }

    </script>

    <style type="text/css">
    .CreditNoteO label {
            width: fit-content!important;
    font-size: 11px;
    margin: -1px 0px 0px 0px;
    display: inline-block;
    float: left;
}
    .CreditNote label {
            width: fit-content!important;
    font-size: 11px;
    margin: 2px 0px 0px 5px;
    display: inline-block;
    float: left;
}

        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }
        .PendingPayments {
    width: 12%;
    float: right;
    text-align: right;
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
        .TotalInput3 {
    width: 16.3%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .TotlaChk {
    width: 32%;
    text-align: right;
    float: left;
    margin: 15px 1.5% 0px 66px;
}

        .TotalInput2 {
    width: 17.8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.FloatRight2 {
    width: 55%;
    float: right;
}
   
    </style>

    <style type="text/css">
        a img {
            border: none;
        }
        .panel_16 {
    height: 358px !important;
    overflow: auto !important;
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

      

        .div_lbl {
            font-size: 11px;
        }

        #logix_CPH_drp_SortedBy_chzn {
            width: 100% !important;
        }

        .CreditNoteO {
            width: 12.5%;
            float: left;
            margin: 0px 0.5% 0px 6px;
            color: #000080;
        }

        .CreditNote {
            width: 11%;
            float: left;
            margin: -2px 0px 0px 0px;
            color: #000080;
        }
        .widget.box{
    position: relative;
    top: -8px;
}
        .btn.btn-update1 {
    margin: 10px 0px 0px 0px;
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
                    //alertify.alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            $("#<%=btn_search.ClientID %>").click();
        }

    </script>

    <style type="text/css">
        .row {
            clear: both;
            width: 100%;
            height: 585px !important;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
        .gridpnl {
    height: calc(100vh - 280px);
}

        .div_lbl_remark {
    width: 71%;
    float: left;
    margin-left: 0px;
    margin-top: 0.5%;
}
        .Gridpnl {
    height: calc(100vh - 166px) !important;
}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box " runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text=""> </asp:Label>
                    </h4>
                     <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Vouchers</a> </li>
            <li><a href="#" title="">Payment Request </a></li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>




                </div>
                <div class="" runat="server" id="div_iframe">
                    <div class="widget-content">
                        <div class="FormGroupContent4" style="margin-top:30px!important;">
                            <div class="CreditNoteO">
                                <asp:RadioButton ID="rbt_CNOP" runat="server" GroupName="rbt" OnCheckedChanged="rbt_CNOP_CheckedChanged" AutoPostBack="true" /><label>Purchase Invoice</label>
                            </div>
                            <div class="CreditNote">
                                <asp:RadioButton ID="rbt_CN" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_CN_CheckedChanged" /><label>Credit Note</label>
                            </div>
                            <div class="CreditNoteO">
                                <asp:RadioButton ID="rbt_CNAdmin" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_CNAdmin_CheckedChanged" /><label>Admin Purchase Invoice</label>
                            </div>
                            <div class="CreditNote" runat="server" id="notovercheque_rbt">
                                <asp:RadioButton ID="rbt_cheque" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_cheque_CheckedChanged" /><label>Not Over Cheque</label>
                            </div>
                            
                           

                              <div class="FormGroupContent4 boxmodal">
                            <div style="float: left; width: 20%; margin: 0px 0.5% 0px 0px;">
                                <asp:Label ID="Label1" runat="server" Text="Vendor"> </asp:Label>
                                <asp:TextBox ID="txt_Filterby" runat="server" ToolTip="Vendor" Placeholder="" CssClass="form-control" Width="100%" AutoPostBack="true" OnTextChanged="txt_Filterby_TextChanged"></asp:TextBox>
                            </div>

                            <div style="float: left; width: 10%; margin: 0px;">
                                <asp:Label ID="Label2" runat="server" Text="Sort By"> </asp:Label>
                          
                                <asp:DropDownList ID="drp_SortedBy" runat="server" CssClass="chzn-select form-control" Height="23px" ToolTip="Sort By" OnSelectedIndexChanged="drp_SortedBy_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="0">Sort By</asp:ListItem>
                                    <asp:ListItem Value="Vouno">Vou #</asp:ListItem>
                                    <asp:ListItem Value="VouDate">Vou Date</asp:ListItem>
                                    <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                    <asp:ListItem Value="PAAmount">Vou Amt</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <asp:TextBox ID="txt_vouno" runat="server" Placeholder="Vou #" ToolTip="Vou #" Visible="false"></asp:TextBox>

                            <div class="PendingPayments">
                                <asp:LinkButton ID="Lnk_Pending" runat="server" CssClass="anc ico-find-sm"  ForeColor="Red" OnClick="Lnk_Pending_Click"></asp:LinkButton>
                            </div>
                            <div class="ETA">
                                <asp:TextBox ID="txt_search" placeholder="Search Vou #" runat="server" ToolTip="Search Vou #" AutoPostBack="True" CssClass="form-control" onkeyup="GetDetail();" Visible="false"></asp:TextBox>
                            </div>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <asp:Panel ID="panel" runat="server" ScrollBars="Vertical" CssClass="gridpnl">
                                <asp:GridView ID="Grd_Cheque" runat="server" AutoGenerateColumns="false" class="Grid FixedHeader" DataKeyNames="vouyear,bid,blno,jobno,trantype,vouno"
                                    OnRowDataBound="Grd_Cheque_RowDataBound" ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="true" PageSize="12" OnPageIndexChanging="Grd_Cheque_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="PI #"><%-- 0--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                    <asp:LinkButton ID="Lnk_Vouno" runat="server" CommandName="select" ForeColor="Red" OnClick="Lnk_Vouno_Click" Text='<%#Eval("vouno")%>'></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="voudate" HeaderText="Date"><%--1--%>
                                            <HeaderStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="duedate" HeaderText="DueDate"><%--2--%>
                                            <HeaderStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Vendor" HeaderStyle-ForeColor="White"><%--3--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 175px">
                                                    <asp:Label ID="custname" runat="server" Text='<%# Bind("custname") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="175px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Favouring"><%--4--%>
                                            <HeaderStyle Width="250px" />
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 300px">
                                                    <asp:LinkButton ID="Lnk" runat="server" OnClick="lnkCheque_Click" Text='<%#Eval("custname")%>' ToolTip='<%#Eval("custname")%>' ForeColor="Red"></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" Width="250px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="250px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="approvedby" HeaderText="ApprovedBy"><%--5--%>
                                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false"  Width="100px" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vouamt" HeaderText="Vou Amt" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--6--%>
                                            <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="Center" />
                                            <ItemStyle Width="120px" CssClass="TxtAlign1" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="tdsamt" HeaderText="TDS Amt" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--7--%>
                                            <HeaderStyle Wrap="false" Width="120px" HorizontalAlign="Center" />
                                            <ItemStyle CssClass="TxtAlign1" Width="120px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Mode"><%--8--%>
                                            <HeaderStyle Width="120px" />
                                            <ItemStyle Width="120px" />
                                            <ItemTemplate>

                                                <asp:DropDownList ID="ddl_module" runat="server" CssClass="" placeholder="--MODE--" ToolTip="MODE" Style="width: 100%;">
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
                                            <HeaderStyle Wrap="false" Width="30px" HorizontalAlign="Center" />
                                            <ItemStyle Wrap="false" Width="30px"  HorizontalAlign="Left"></ItemStyle>
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
                        </div>

                        <div class="FormGroupContent4 boxmodal">
                            <div class="FloatRight2">
                                <div class="TotlaChk">
                                    <asp:Label ID="lbl_total" runat="server" Text="Total Cheque Request Amount" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="TotalInput2">
                                    <asp:Label ID="Label3" runat="server" Text="Voc Amount" ToolTip="Total Cheque Request Amount"> </asp:Label>
                                    <asp:TextBox ID="txt_PAamount" runat="server" CssClass="form-control" ToolTip="Total Cheque Request Amount" placeholder=""></asp:TextBox>
                                </div>
                                <div class="TotalInput3">
                                    <asp:Label ID="Label5" runat="server" Text="TDS Amount" ToolTip="TDS Amount"> </asp:Label>
                                    <asp:TextBox ID="txt_TDSamount" runat="server" CssClass="form-control" ToolTip="TDS Amount" placeholder=""></asp:TextBox>
                                </div>
                                <div class="right_btn">
                                    <div class="btn ico-update">
                                        <asp:Button ID="btn_update" runat="server" Text="Update" ToolTip="Update" OnClick="btn_update_Click" />
                                    </div>
                                    <div class="btn ico-send" Style="display: none;">
                                        <asp:Button ID="btn_search" runat="server" Text=""  OnClick="btn_search_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Panel ID="pln_popup" runat="server" CssClass="div_frame1" Style="display: none;"></asp:Panel>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Panel ID="panel1" runat="server" Visible="false"  CssClass="Gridpnl">
                                <asp:GridView ID="Grd_Payment" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White"
                                    CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" DataKeyNames="vouyear,remarks,bid,blno,jobno,trantype,favourname,approvedby,mode" OnRowDataBound="Grd_Payment_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="vouno" HeaderText="CNOps #">
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
                            <div class=" divRoated">

                                <div class="DivSecPanel">
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
                                </div>
                            </asp:Panel>
                        </div>

                        <asp:Panel ID="pln_favour" runat="server" CssClass="modalPopup" Style="display: none;">

                            <div class="divRoated">
                            <div class="DivSecPanel">
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
                         </div>
                        </asp:Panel>

                        <div class="FormGroupContent4">
                            <asp:Panel ID="pln_cheque" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                              <div class="divRoated">
                                    <div class="DivSecPanel">
                                    <asp:Image ID="Close_Cheque" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                                </div>

                                <div class="">
                                    <iframe id="iframecost" runat="server" src="" frameborder="0" class="" style="background-color: #FFFFFF"></iframe>
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
        </div>
    </div>

    <%-- Filter By --%>

    <asp:HiddenField ID="hid_approvedby" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>ChequeRequest #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
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
